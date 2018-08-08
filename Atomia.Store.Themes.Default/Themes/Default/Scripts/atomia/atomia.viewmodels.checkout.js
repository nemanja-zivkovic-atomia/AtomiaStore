var Atomia = Atomia || {};
Atomia.ViewModels = Atomia.ViewModels || {};

(function (exports, _, ko, utils, checkoutApi) {
    'use strict';

    function TermsOfService(terms) {
        var self = this;

        self.termsOfService = ko.observableArray(terms);
        self.disableCheckoutAction = ko.observable(false);

        utils.subscribe('cart:remove', function (removedItem) {
            checkoutApi.getTermsOfService(function (result) {
                self.termsOfService(result);
            })
        });

        self.submit = function () {
            self.disableCheckoutAction(true);
            return true;
        };
    }

    _.extend(exports, {
        TermsOfService: TermsOfService
    });
})(Atomia.ViewModels, _, ko, Atomia.Utils, Atomia.Api.Checkout);