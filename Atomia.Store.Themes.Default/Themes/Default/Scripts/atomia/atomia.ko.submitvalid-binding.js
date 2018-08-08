
(function ($, ko) {
    'use strict';

    /** Wraps default 'submit' binding with a validation check using jQuery Validation */
    ko.bindingHandlers.submitValid = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            var validatingValueAccessor = function () {
                return function (data, event) {
                    var submit = false;

                    if ($(element).valid()) {
                        var submitHandler = valueAccessor() || function () { return true; };

                        submit = submitHandler.call(viewModel, data, event);
                    }

                    return submit;
                };
            };

            ko.bindingHandlers.submit.init(element, validatingValueAccessor, allBindings, viewModel, bindingContext);
        }
    };

} (jQuery, ko));
