---
title: إدارة الإشارات في مخططات العرض التقديمي باستخدام Java
linktitle: إشارة
type: docs
url: /ar/java/callout/
keywords:
- إشارة المخطط
- استخدام الإشارة
- تسمية البيانات
- تنسيق التسمية
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء وتنسيق الإشارات في Aspose.Slides for Java مع أمثلة شفرة مختصرة، ومتوافقة مع PPT و PPTX لأتمتة سير عمل العروض التقديمية."
---

## **استخدام الملاحظات المرفقة**
تمت إضافة طرق جديدة [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) و[**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) إلى الفئة [DataLabelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/datalabelformat) والواجهة [IDataLabelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat). تحدد هذه الطرق ما إذا كان يتم عرض تسمية البيانات للمخطط المحدد كإشارة بيانات أم كعلامة بيانات.
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


## **تعيين إشارة لمخطط الدونات**
Aspose.Slides for Java يدعم ضبط شكل إشارة تسمية بيانات السلسلة لمخطط الدونات. فيما يلي مثال توضيحي.
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


## **الأسئلة المتكررة**

**هل يتم الحفاظ على الإشارات عند تحويل العرض التقديمي إلى PDF أو HTML5 أو SVG أو صور؟**

نعم. الإشارات هي جزء من عرض المخطط، لذا عند تصدير إلى [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، [HTML5](/slides/ar/java/export-to-html5/)، [SVG](/slides/ar/java/render-a-slide-as-an-svg-image/)، أو [raster images](/slides/ar/java/convert-powerpoint-to-png/)، يتم الحفاظ عليها مع تنسيق الشريحة.

**هل تعمل الخطوط المخصصة في الإشارات، وهل يمكن الحفاظ على مظهرها عند التصدير؟**

نعم. Aspose.Slides يدعم [embedding fonts](/slides/ar/java/embedded-font/) في العرض التقديمي ويتحكم في تضمين الخطوط أثناء التصدير مثل [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، لضمان أن تبدو الإشارات بنفس الشكل عبر الأنظمة المختلفة.