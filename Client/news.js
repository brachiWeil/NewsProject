
$(() => {
    const api = "http://localhost:5168/api/news";
    const $loader = $('#loader');
    //שליפת החדשות מהשרת והצגתם כרשימת לינקים
    $loader.show();
    $.getJSON(api, data => {
        $loader.hide();
        $('#newsTitels').html(data.map((n, i) =>
            `<div class="news-item" data-id="${i}">${n.title}</div>`).join(''))
    });


    $(document).on('click', '.news-item', function () {
        $('.news-item').removeClass('activeLink');
        //צביעת הקישור הנבחר 
        $(this).addClass('activeLink');
        $.getJSON(`${api}/${$(this).data('id')}`, post => {
            //קבלת נתוני הפוסט על פי ID והזרקתם לHTML
            $('#postContent').show().html(`<h2>${post.title}</h2>
                <a href="${post.link}" style="color:green">read more</a>
                <hr>
                <div>${post.content}</div>`);
        });
    });
});