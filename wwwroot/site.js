const uri = 'api/tarefas/';

let tarefas = null;

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: 'GET',
        url: uri,
        success: function (data) {
            $('#todos').empty();
            getCount(data.length);

            $.each(data, function (key, item) {
                const checked = item.finalizada ? 'checked' : '';

                $('<tr><td><input disabled="true" type="checkbox"' + checked + '></td>' +
                    '<td>' + item.nome + '</td>' +
                    '<td> <button onclick="editItem(' + item.id + ')">Editar</button> </td>' +
                    '<td> <button onclick="deleteItem(' + item.id + ')">Apagar</button> </td>' +
                    '</tr>').appendTo($('#todos'));
            });
            tarefas = data;
        }
    });
}

function addItem() {
    const item = {
        'nome': $('#add-name').val(),
        'finalizada': false
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            getData();
            $('#add-name').val('');
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: function (result) {
            getData();
        }
    });
}

function editItem(id) {
    $.each(tarefas, function (key, item) {
        if (item != null && item.id === id) {
            $('#edit-name').val(item.nome);
            $('#edit-id').val(item.id);
            $('#edit-isComplete')[0].checked = item.finalizada;
        }
    });

    $('#spoiler').show();

    $('#tblTarefas').hide();
}

$('.my-form').on('submit', function () {
    const item = {
        'nome': $('#edit-name').val(),
        'finalizada': $('#edit-isComplete').is(':checked'),
        'id': $('#edit-id').val()
    };

    $.ajax({
        url: uri + '/' + $('#edit-id').val(),
        type: 'PUT',
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $('#spoiler').hide();

    $('#tblTarefas').show();
}

function getCount(data) {
    const el = $('#counter');
    let name = 'Tarefa';
    if (data) {
        if (data > 1) {
            name = 'Tarefas';
        }
        $('#tblTarefas').show();
        el.text(data + ' ' + name);
    } else {
        $('#tblTarefas').hide();
        el.html('Não existe nenhuma ' + name + ' cadastrada.');
    }
}