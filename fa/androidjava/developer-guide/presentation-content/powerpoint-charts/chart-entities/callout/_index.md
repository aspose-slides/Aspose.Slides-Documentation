---
title: مدیریت نکات در نمودارهای ارائه در Android
linktitle: نکته
type: docs
url: /fa/androidjava/callout/
keywords:
- نکته نمودار
- استفاده از نکته
- برچسب داده
- قالب برچسب
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "ایجاد و استایل‌دهی نکات در Aspose.Slides برای Android با مثال‌های مختصر کد Java، سازگار با PPT و PPTX برای خودکارسازی گردش کار ارائه‌ها."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با نکات برای برچسب‌های داده‌ای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه از متد `setShowLabelAsDataCallout` برای نمایش برچسب‌ها به‌صورت نکات استفاده کنید، چگونه تنظیمات برچسب مرتبط با نکات را برای نمودار دونات پیکربندی کنید، و اینکه نکات و ظاهر آن‌ها هنگام خروجی گرفتن ارائه‌ها به فرمت‌های PDF، HTML5، SVG و تصاویر رستری حفظ می‌شوند.

## **استفاده از نکات**
متدهای جدید [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) و [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) به کلاس [DataLabelFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/datalabelformat) و اینترفیس [IDataLabelFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idatalabelformat) اضافه شده‌اند. این متدها تعیین می‌کنند که آیا برچسب داده‌ای نمودار مشخص به‌صورت نکته داده یا به‌صورت برچسب داده نمایش داده شود.

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

## **تنظیم نکته برای نمودار دونات**
Aspose.Slides برای Android از طریق Java پشتیبانی از تنظیم شکل نکته برچسب داده‌ای سری برای نمودار دونات را فراهم می‌کند. مثال نمونه زیر ارائه شده است.

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

**آیا نکات هنگام تبدیل یک ارائه به PDF، HTML5، SVG یا تصاویر حفظ می‌شوند؟**

بله. نکات بخشی از رندر نمودار هستند، بنابراین هنگامی که به [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/)، [HTML5](/slides/fa/androidjava/export-to-html5/)، [SVG](/slides/fa/androidjava/render-a-slide-as-an-svg-image/) یا [تصاویر رستری](/slides/fa/androidjava/convert-powerpoint-to-png/) خروجی می‌گیرید، همراه با قالب‌بندی اسلاید حفظ می‌شوند.

**آیا قلم‌های سفارشی در نکات کار می‌کنند و آیا ظاهر آن‌ها می‌تواند در حین خروجی حفظ شود؟**

بله. Aspose.Slides از [ام embed کردن قلم‌ها](/slides/fa/androidjava/embedded-font/) در ارائه پشتیبانی می‌کند و در طول خروجی‌ها مانند [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/) کنترل می‌کند که قلم‌ها تعبیه شوند، به‌طوری که نکات در سیستم‌های مختلف یکسان به‌نظر برسند.