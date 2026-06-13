---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها با استفاده از JavaScript
linktitle: برچسب داده
type: docs
url: /fa/nodejs-java/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- موقعیت برچسب
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید که چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از JavaScript و Aspose.Slides برای Node.js از طریق Java اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده در نمودار جزئیاتی دربارهٔ سری‌های دادهٔ نمودار یا نقاط دادهٔ فردی نشان می‌دهند. این برچسب‌ها به خوانندگان امکان می‌دهند تا سری‌های داده را به‌سرعت شناسایی کنند و همچنین درک نمودارها را آسان‌تر می‌سازند.

## **تنظیم دقت داده‌ها در برچسب‌های دادهٔ نمودار**

این کد جاوااسکریپت نشان می‌دهد که چگونه دقت داده‌ها را در یک برچسب دادهٔ نمودار تنظیم کنید:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **نمایش درصد به‌صورت برچسب‌ها**

Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد برچسب‌های درصدی را روی نمودارهای نمایش داده شده تنظیم کنید. این کد جاوااسکریپت عملکرد را نشان می‌دهد:
```javascript
// یک نمونه از کلاس Presentation ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);
    var series;
    var total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (var k = 0; k < chart.getChartData().getCategories().size(); k++) {
        var cat = chart.getChartData().getCategories().get_Item(k);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData();
        }
    }
    var dataPontPercent = 0.0;
    for (var x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
        for (var j = 0; j < series.getDataPoints().size(); j++) {
            var lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (series.getDataPoints().get_Item(j).getValue().getData() / total_for_Cat[j]) * 100;
            var port = new aspose.slides.Portion();
            port.setText(java.callStaticMethodSync("java.lang.String", "format", "{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8.0);
            lbl.getTextFrameForOverriding().setText("");
            var para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    // ارائه حاوی نمودار را ذخیره می‌کند
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم علامت درصد در برچسب‌های دادهٔ نمودار**

این کد جاوااسکریپت نشان می‌دهد که چگونه علامت درصد را برای یک برچسب دادهٔ نمودار تنظیم کنید:
```javascript
// یک نمونه از کلاس Presentation ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // مرجع یک اسلاید را از طریق ایندکس آن دریافت می‌کند
    var slide = pres.getSlides().get_Item(0);
    // نمودار PercentsStackedColumn را بر روی اسلاید ایجاد می‌کند
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    // NumberFormatLinkedToSource را به false تنظیم می‌کند
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    chart.getChartData().getSeries().clear();
    var defaultWorksheetIndex = 0;
    // ورک‌شیت دادهٔ نمودار را دریافت می‌کند
    var workbook = chart.getChartData().getChartDataWorkbook();
    // سری جدیدی اضافه می‌کند
    var series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    // رنگ پر کردن سری را تنظیم می‌کند
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // ویژگی‌های LabelFormat را تنظیم می‌کند
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // سری جدیدی اضافه می‌کند
    var series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.7));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.5));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.2));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    // نوع پر کردن و رنگ را تنظیم می‌کند
    series2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم فاصله برچسب‌ها از محور**

این کد جاوااسکریپت نشان می‌دهد که چگونه فاصله برچسب را از محور دسته‌بندی تنظیم کنید هنگامی که با نموداری که از محورها ترسیم شده سروکار دارید:
```javascript
// یک نمونه از کلاس Presentation ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // مرجع یک اسلاید را دریافت می‌کند
    var sld = pres.getSlides().get_Item(0);
    // یک نمودار را بر روی اسلاید ایجاد می‌کند
    var ch = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    // فاصله برچسب را از یک محور تنظیم می‌کند
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم موقعیت برچسب**

هنگامی که نموداری ایجاد می‌کنید که به هیچ محوری وابسته نیست، مانند نمودار پای، ممکن است برچسب‌های دادهٔ نمودار بسیار نزدیک به حاشیهٔ آن شوند. در چنین مواردی باید موقعیت برچسب داده را تنظیم کنید تا خطوط راهنما به‌وضوح نمایش داده شوند.
این کد جاوااسکریپت نشان می‌دهد که چگونه موقعیت برچسب را در یک نمودار پای تنظیم کنید:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    var series = chart.getChartData().getSeries();
    var label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71);
    label.setY(0.04);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **سؤالات متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای پرجمعیت جلوگیری کنم؟**

از جایگذاری خودکار برچسب‌ها، خطوط راهنما و کاهش اندازه قلم استفاده کنید؛ در صورت لزوم برخی فیلدها (مثلاً دسته‌بندی) را مخفی کنید یا فقط برای نقاط انتهایی/کلیدی برچسب‌ها را نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

نقاط داده را پیش از فعال‌سازی برچسب‌ها فیلتر کنید و نمایش مقادیر صفر، مقادیر منفی یا مقادیر گمشده را بر اساس یک قانون تعریف‌شده غیرفعال کنید.

**چگونه می‌توانم اطمینان حاصل کنم که سبک برچسب هنگام خروجی به PDF/تصاویر ثابت باشد؟**

قلم‌ها (نام خانوادگی، اندازه) را به‌صورت صریح تنظیم کنید و اطمینان حاصل کنید که قلم بر روی سمت رندر موجود است تا از استفادهٔ قلم پیش‌فرض جلوگیری شود.