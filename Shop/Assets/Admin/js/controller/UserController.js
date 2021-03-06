﻿var User =
{
    init: function()
    {
        User.registerEvents();
    },
    registerEvents: function()
    {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type:"POST",
                success: function (response)
                {
                    if (response.status == true) {
                        btn.text('Kích hoạt');
                    }
                    else
                    {
                        btn.text('Khóa');
                    }
                }
            })
        });
    }
}
User.init();