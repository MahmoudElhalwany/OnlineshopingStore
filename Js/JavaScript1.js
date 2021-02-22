/// <reference path="jquery-3.2.1.min.js" />
/*$(document).ready(function () {
    $(".owl-carousel").owlCarousel({
        items: 4,
        loop: true,
        margin: 10,
        autoplay: true,
        autoplayTimeout: 2000,
        autoplayHoverPause: true
    });
});*/
$(document).ready(function(){
    $(".ready p").fadeIn(1000, function () { $(".ready").fadeOut(1000) })
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })


})
function clicked(){
  
    $("newwindow").fadeIn(500);
    $("blur").show();

}

var x;
$("#countitemdown").click(
    function () {
        x = $("#countofitem").text();
        if (x > 0) {
          
            x--;
            console.log(x);
            $("#countofitem").text(x);
        }

    }


    )
$("#countitemup").mousedown(
   
    function () {
        
        x = $("#countofitem").text();
        

            x++;
            console.log(x);
            $("#countofitem").text(x);
        

    }



    )



