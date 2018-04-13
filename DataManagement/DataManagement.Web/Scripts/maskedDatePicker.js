(function ($) {
    var kendo = window.kendo,
        ui = kendo.ui,
        Widget = ui.Widget,
        proxy = $.proxy,
        CHANGE = "change",
        PROGRESS = "progress",
        ERROR = "error",
        NS = ".generalInfo";

    var MaskedDatePicker = Widget.extend({
        init: function (element, options) {
            var that = this;
            Widget.fn.init.call(this, element, options);

            $(element).kendoMaskedTextBox({ mask: that.options.dateOptions.mask || "00/00/0000" })
            .kendoDatePicker({
                format: that.options.dateOptions.format || "dd/MM/yyyy",
                parseFormats: that.options.dateOptions.parseFormats || ["dd/MM/yyyy"]
            })
            .closest(".k-datepicker")
            .add(element)
            .removeClass("k-textbox");

            that.element.data("kendoDatePicker").bind("change", function () {
                that.trigger(CHANGE);
            });
        },
        options: {
            name: "MaskedDatePicker",
            dateOptions: {}
        },
        events: [
          CHANGE
        ],
        destroy: function () {
            var that = this;
            Widget.fn.destroy.call(that);

            kendo.destroy(that.element);
        },
        value: function (value) {
            var datepicker = this.element.data("kendoDatePicker");

            if (value === undefined) {
                return datepicker.value();
            }

            datepicker.value(value);
        }
    });

    ui.plugin(MaskedDatePicker);

})(window.kendo.jQuery);

(function ($) {
    var kendo = window.kendo,
        ui = kendo.ui,
        Widget = ui.Widget,
        proxy = $.proxy,
        CHANGE = "change",
        PROGRESS = "progress",
        ERROR = "error",
        NS = ".generalInfo";

    var MaskedDateTimePicker = Widget.extend({
        init: function (element, options) {
            var that = this;
            Widget.fn.init.call(this, element, options);

            $(element).kendoMaskedTextBox({ mask: that.options.dateOptions.mask || "00/00/0000 00:00" })
            .kendoDateTimePicker({
                format: that.options.dateOptions.format || "dd/MM/yyyy HH:mm",
                parseFormats: that.options.dateOptions.parseFormats || ["dd/MM/yyyy HH:mm"]
            })
            .closest(".k-datetimepicker")
            .add(element)
            .removeClass("k-textbox");

            that.element.data("kendoDateTimePicker").bind("change", function () {
                that.trigger(CHANGE);
            });
        },
        options: {
            name: "MaskedDateTimePicker",
            dateOptions: {}
        },
        events: [
          CHANGE
        ],
        destroy: function () {
            var that = this;
            Widget.fn.destroy.call(that);

            kendo.destroy(that.element);
        },
        value: function (value) {
            var datetimepicker = this.element.data("kendoDateTimePicker");

            if (value === undefined) {
                return datetimepicker.value();
            }

            datetimepicker.value(value);
        }
    });

    ui.plugin(MaskedDateTimePicker);

})(window.kendo.jQuery);