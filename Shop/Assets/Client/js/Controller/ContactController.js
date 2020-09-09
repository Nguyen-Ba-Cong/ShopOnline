var contact =
{
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#txtName').val().toString();
            var email = $('#txtEmail').val().toString();
            var content = $('#txtContent').val().toString();
            $.ajax({
                url: '/Contact/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    email: email,
                    content: content
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Send Successful');
                    }
                }
            });
        });
       
    }
}
contact.init();