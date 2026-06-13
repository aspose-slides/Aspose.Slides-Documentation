---
title: مدیریت Calloutها در نمودارهای ارائه با استفاده از Java
linktitle: فراخوان
type: docs
url: /fa/java/callout/
keywords:
- فراخوان نمودار
- استفاده از فراخوان
- برچسب داده
- قالب برچسب
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد و استایل‌دهی به Calloutها در Aspose.Slides برای Java با مثال‌های کد مختصر، سازگار با PPT و PPTX برای خودکارسازی گردش کار ارائه‌ها."
---
## **بررسی کلی**

این مقاله نحوه کار با Calloutها برای برچسب‌های داده‌های نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه از متد `setShowLabelAsDataCallout` برای نمایش برچسب‌ها به صورت Callout استفاده می‌شود، چگونه تنظیمات مربوط به برچسب‌های Callout را برای یک نمودار دونات پیکربندی می‌کنید، و توضیح می‌دهد که Calloutها و ظاهر آن‌ها هنگام صادر کردن ارائه‌ها به PDF، HTML5، SVG و فرمت‌های تصویر رستر حفظ می‌شوند.

## **استفاده از Calloutها**
متدهای جدید [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) و [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) به کلاس [DataLabelFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/datalabelformat) و اینترفیس [IDataLabelFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idatalabelformat) افزوده شده‌اند. این متدها تعیین می‌کنند که آیا برچسب دادهٔ نمودار مشخص شده به‌صورت Callout یا به‌صورت برچسب داده نمایش داده شود.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400);
    
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    
    pres.save("DisplayCharts.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم Callout برای نمودار دونات**
Aspose.Slides for Java امکان تنظیم شکل Callout برچسب دادهٔ سری‌ها را برای نمودار دونات فراهم می‌کند. مثال نمونه زیر را مشاهده کنید.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, false);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    int seriesIndex = 0;
    while (seriesIndex < 15)
    {
        IChartSeries series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize((byte)20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    int categoryIndex = 0;
    while (categoryIndex < 15)
    {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        int i = 0;
        while (i < chart.getChartData().getSeries().size())
        {
            IChartSeries iCS = chart.getChartData().getSeries().get_Item(i);
            IChartDataPoint dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(LineDashStyle.Solid);
            if (i == chart.getChartData().getSeries().size() - 1)
            {
                IDataLabel lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.LIGHT_GRAY);
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX((float) lbl.getX()+ (float)0.5);
                lbl.setY((float)lbl.getY()+ (float)0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا Calloutها هنگام تبدیل ارائه به PDF، HTML5، SVG یا تصاویر رستر حفظ می‌شوند؟**

بله. Calloutها بخشی از رندر نمودار هستند، بنابراین هنگام صادرات به [PDF](/slides/fa/java/convert-powerpoint-to-pdf/)، [HTML5](/slides/fa/java/export-to-html5/)، [SVG](/slides/fa/java/render-a-slide-as-an-svg-image/)، یا [تصاویر رستر](/slides/fa/java/convert-powerpoint-to-png/)، همراه با قالب‌بندی اسلاید حفظ می‌شوند.

**آیا قلم‌های سفارشی در Calloutها کار می‌کنند و آیا می‌توان ظاهر آن‌ها را پس از صادرات حفظ کرد؟**

بله. Aspose.Slides از [قراردادن قلم‌ها](/slides/fa/java/embedded-font/) در ارائه پشتیبانی می‌کند و در فرآیندهای صادراتی مانند [PDF](/slides/fa/java/convert-powerpoint-to-pdf/) کنترل می‌شود تا Calloutها در سیستم‌های مختلف یک ظاهر مشابه داشته باشند.