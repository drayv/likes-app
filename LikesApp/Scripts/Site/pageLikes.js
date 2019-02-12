$(document).ready(function () {
    $.get("/api/PageLikes/Count", { pageName: window.location.pathname }, function (data) {
        $('#likes-counter').html(data);
    });

    $.get("/api/PageLikes/IsLiked", { pageName: window.location.pathname }, function (data) {
        if (data) {
            $('.unlike-container').show();
        } else {
            $('.like-container').show();
        }
    });
});

function likeThisPage() {
    $('.unlike-container > button').prop('disabled', true);

    $.ajax({
        type: 'POST',
        url: "/api/PageLikes/Like",
        data: JSON.stringify(window.location.pathname),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function () {
            var count = $('#likes-counter').html();
            $('#likes-counter').html(getLikesCount() + 1);
            $('.unlike-container').show();
            $('.like-container').hide();
        },
        complete: function () {
            $('.unlike-container > button').prop('disabled', false);
        }
    });
}

function unlikeThisPage() {
    $('.unlike-container > button').prop('disabled', true);

    $.ajax({
        type: 'POST',
        url: "/api/PageLikes/Unlike",
        data: JSON.stringify(window.location.pathname),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function () {
            $('#likes-counter').html(getLikesCount() - 1);
            $('.unlike-container').hide();
            $('.like-container').show();
        },
        complete: function () {
            $('.unlike-container > button').prop('disabled', false);
        }
    });
}

function getLikesCount() {
    return parseInt($('#likes-counter').html());
}
