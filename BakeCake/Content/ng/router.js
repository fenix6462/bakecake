angular.module('app').config([
    '$routeProvider',
    '$locationProvider',
    function (
        $routeProvider,
        $locationProvider
    ) {

        $locationProvider.html5Mode(true).hashPrefix('');

        $routeProvider
            .when("/", {
                templateUrl: "app/Recipes/Index"
            })
            .when("/recipes", {
                templateUrl: "app/Recipes/Index"
            })
            .when("/recipes/create", {
                templateUrl: "app/Recipes/Create"
            })
            .when("/recipes/:id", {
                templateUrl: "app/Recipes/Details"
            })
            .when("/products", {
                templateUrl: "app/Products/Index"
            })
            .when("/products/create", {
                templateUrl: "app/Products/Create"
            })
            .when("/products/:id", {
                templateUrl: "app/Products/Details"
            })
            .when("/error404", {
                templateUrl: "app/Home/Error404"
            })
            .otherwise({
                redirectTo: '/'
            });

    }]);