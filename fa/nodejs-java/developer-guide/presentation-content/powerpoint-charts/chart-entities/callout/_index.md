---
title: مدیریت فراخوانی‌ها در نمودارهای ارائه با استفاده از JavaScript
linktitle: فراخوانی
type: docs
url: /fa/nodejs-java/callout/
keywords:
- فراخوانی نمودار
- استفاده از فراخوانی
- برچسب داده
- قالب برچسب
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد و استایل‌دهی به فراخوانی‌ها در Aspose.Slides برای Node.js از طریق Java با مثال‌های کد مختصر، سازگار با PPT و PPTX برای خودکارسازی گردش کار ارائه‌ها."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با فراخوانی‌ها برای برچسب‌های داده نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه از روش `setShowLabelAsDataCallout` برای نمایش برچسب‌ها به عنوان فراخوانی استفاده کنید، چگونه تنظیمات برچسب مرتبط با فراخوانی را برای نمودار دونات پیکربندی کنید، و اینکه فراخوانی‌ها و ظاهر آن‌ها هنگام صادرات ارائه‌ها به فرمت‌های PDF، HTML5، SVG و تصاویر رستری حفظ می‌شوند.

## **استفاده از فراخوانی‌ها**

متدهای جدید [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) و [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) به کلاس [DataLabelFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datalabelformat) اضافه شده‌اند. این متدها تعیین می‌کنند که آیا برچسب دادهٔ نمودار مشخص شده به صورت فراخوانی داده یا به صورت برچسب داده نمایش داده شود.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 500, 400);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    pres.save("DisplayCharts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم فراخوانی برای نمودار دونات**

Aspose.Slides for Node.js via Java قابلیت تنظیم شکل فراخوانی برچسب داده سری برای نمودار دونات را فراهم می‌کند. نمونهٔ زیر ارائه شده است.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Doughnut, 10, 10, 500, 500, false);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    var seriesIndex = 0;
    while (seriesIndex < 15) {
        var series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize(20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    var categoryIndex = 0;
    while (categoryIndex < 15) {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        var i = 0;
        while (i < chart.getChartData().getSeries().size()) {
            var iCS = chart.getChartData().getSeries().get_Item(i);
            var dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
            if (i == (chart.getChartData().getSeries().size() - 1)) {
                var lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new aspose.slides.FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX(lbl.getX() + 0.5);
                lbl.setY(lbl.getY() + 0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سؤال‌های متداول**

**آیا فراخوانی‌ها هنگام تبدیل ارائه به PDF، HTML5، SVG یا تصاویر حفظ می‌شوند؟**

بله. فراخوانی‌ها بخشی از رندر نمودار هستند، بنابراین هنگام صادرات به [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/)، [HTML5](/slides/fa/nodejs-java/export-to-html5/)، [SVG](/slides/fa/nodejs-java/render-a-slide-as-an-svg-image/)، یا [تصاویر رستری](/slides/fa/nodejs-java/convert-powerpoint-to-png/)، همراه با قالب‌بندی اسلاید حفظ می‌شوند.

**آیا فونت‌های سفارشی در فراخوانی‌ها کار می‌کنند و آیا ظاهر آن‌ها می‌تواند هنگام صادرات حفظ شود؟**

بله. Aspose.Slides از [تعبیه فونت‌ها](/slides/fa/nodejs-java/embedded-font/) در ارائه پشتیبانی می‌کند و هنگام صادرات مانند [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) تعبیه فونت را کنترل می‌نماید، به‌طوری که فراخوانی‌ها در سیستم‌های مختلف یک‑صورت باقی بمانند.