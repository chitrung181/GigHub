var FollowingService = function () {
    var createFollowing = function (followeeId, done, fail) {
        $.post("/api/followings", { followeeId: followeeId })
            .done(done)
            .fail(fail);
    }

    var deleteFollowing = function (followeeId, done, fail) {
        $.ajax({
            url: "/api/followings/" + followeeId,
            type: "DELETE",
            success: done,
            error: fail
        });
    }

    return {
        createFollowing: createFollowing,
        deleteFollowing: deleteFollowing
    }
}();