﻿
angular.module("MessageServices", ["ngResource"]).factory("Message", [
  '$resource', function($resource) {
    return $resource("/api/message/:id", {
      id: '@id'
    }, {
      recent: {
        method: "GET",
        params: {
          action: "recent"
        }
      },
      add: {
        method: "PUT"
      },
      del: {
        method: "POST",
        params: {
          action: 'delete'
        }
      },
      renew: {
        method: "POST",
        params: {
          action: 'renew'
        }
      }
    });
  }
]);
