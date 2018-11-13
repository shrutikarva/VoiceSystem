$(document).ready(function () {



    $(".clsliMedia").click(function () {

        var isOpen = $(this).parent().find('.clsIsOpen').val();
        if (isOpen == "0") {
            var objdiv = $(this).parent().find('.clsloadChatScreen');
            $(this).parent().find('.clsloadChatScreen').css('display', '');
            $(this).parent().find('.clsIsOpen').val("1");
            var serviceUrl = "/Voice/_details";
            var obj = {};
            obj.clientId = "123";
            $.ajax({
                type: "POST",
                url: serviceUrl,
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                success: successFunc,
                error: errorFunc
            });
            function successFunc(data, status) {
                $(objdiv).html(data);
                //$(this).parent().find('.clsloadChatScreen').html(data);


            }

            function errorFunc(err) {
                alert(err.responseText);
            }
        }

            

        
        else {
           
        $(this).parent().find('.clsIsOpen').val("0");
            $(this).parent().find('.clsloadChatScreen').css('display', 'none');
        }
        //window.location.href = "UserChatScreen?clientId =" + ClientId + "&recepientName=" + RecipientName + "&recepientPhoneNumber=" + RecipientPhoneNumber + "&loanNumber=" + loanNumber + "&userPhoneNumber=" + MaskedPhoneNumber + "&RecepientRole=1";

    });


    $(".minimize").click(function () {
        alert("clicked");

        var isMin = $(this).parent().find('.isMIn').val();
        if (isMin == "0") {
            $(this).child().find('ul').css('display', '');
            $(this).child().find('.isMin').val("1");


        }
        else {
            $(this).parent().find('.isMin').val("0");

            $(this).child().find('ul').css('display', 'none');

        }


    });

  
});

