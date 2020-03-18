var GigDetailsController = function (followingService) {
    var button;

    var done = function () {
        var text = (button.text() == "Follow") ? "Following" : "Follow";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    }

    var fail = function () {
        alert("Something failed!");
    }

    var toggleFollowing = function (e) {
        button = $(e.target);
        var followeeId = button.attr("data-user-id");

        if (button.hasClass("btn-default"))
            followingService.createFollowing(followeeId, done, fail);
        else
            followingService.deleteFollowing(followeeId, done, fail);
    }

    var init = function () {
        $(".js-toggle-follow").click(toggleFollowing);
    };

    return {
        init: init
    }
}(FollowingService);