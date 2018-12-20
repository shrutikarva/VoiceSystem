var PlaceCall = function (object) {
    var obj = {};
    obj.fromNumber = $(object).parent().find(".clsUserPhoneNumber").val();
    obj.toNumber = $(object).parent().find(".clsBusinessPhone1").val();;
    $.ajax({
        type: "POST",
        url: "/Service/CallPhoneNumber",
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: successFunc,
        error: errorFunc
    });
    function successFunc(data, status) {
        alert("calling..");


    }

    function errorFunc(err) {
        alert(err.responseText);
    }
}

$(document).ready(function () {



    $(".clsliMedia").click(function () {
        //string BusinessPhone1, string BusinessPhone2,string MainPhone1, string MainPhone2,string Attn1, string Attn2, string position1, string position2
        var isOpen = $(this).parent().find('.clsIsOpen').val();
        if (isOpen == "0") {
            var objdiv = $(this).parent().find('.clsloadChatScreen');
            $(this).parent().find('.clsloadChatScreen').css('display', '');
            $(this).parent().find('.clsIsOpen').val("1");
            var serviceUrl = "/UserVoice/_details";
            var obj = {};
            obj.BusinessPhone1 = $(this).parent().find('.clsBusinessPhone1').val();
            obj.BusinessPhone2 = $(this).parent().find('.clsBusinessPhone2').val();
            obj.BusinessPhone3 = $(this).parent().find('.clsBusinessPhone3').val();
            obj.BusinessPhone4 = $(this).parent().find('.clsBusinessPhone4').val();
            obj.MainPhone1 = $(this).parent().find('.clsMainPhone1').val();
            obj.MainPhone2 = $(this).parent().find('.clsMainPhone2').val();
            obj.MainPhone3 = $(this).parent().find('.clsMainPhone3').val();
            obj.MainPhone4 = $(this).parent().find('.clsMainPhone4').val();
            obj.Attn1 = $(this).parent().find('.clsAttn1').val();
            obj.Attn2 = $(this).parent().find('.clsAttn2').val();
            obj.Attn3 = $(this).parent().find('.clsAttn3').val();
            obj.Attn4 = $(this).parent().find('.clsAttn4').val();
            obj.position1 = $(this).parent().find('.clsPosition1').val();
            obj.position2 = $(this).parent().find('.clsPosition2').val();
            obj.position3 = $(this).parent().find('.clsPosition3').val();
            obj.position4 = $(this).parent().find('.clsPosition4').val();
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

