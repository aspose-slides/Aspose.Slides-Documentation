---
title: إدارة التعليقات التوضيحية في مخططات العرض باستخدام Java
linktitle: شرح بياني
type: docs
url: /ar/java/callout/
keywords:
- شرح المخطط
- استخدام التعليق التوضيحي
- تسمية البيانات
- تنسيق التسمية
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء وتنسيق التعليقات التوضيحية في Aspose.Slides for Java مع أمثلة شفرة مختصرة، متوافقة مع PPT و PPTX لأتمتة سير عمل العروض التقديمية."
---

## **استخدام التعليقات التوضيحية**
تمت إضافة طريقتين جديدتين [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) و [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) إلى فئة [DataLabelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/datalabelformat) والواجهة [IDataLabelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat). تحدد هاتان الطريقتان ما إذا كانت تسمية البيانات المحددة للمخطط ستُعرض كشرح بياني أو كـ تسمية بيانات.
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


## **تعيين شرح لمخطط Doughnut**
توفر Aspose.Slides for Java دعمًا لتعيين شكل شرح تسمية بيانات السلسلة لمخطط Doughnut. فيما يلي مثال عيني.
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


## **الأسئلة الشائعة**

**هل يتم الاحتفاظ بالتعليقات التوضيحية عند تحويل عرض تقديمي إلى PDF أو HTML5 أو SVG أو صور؟**

نعم. التعليقات التوضيحية هي جزء من رسم المخطط، لذا عند التصدير إلى [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، [HTML5](/slides/ar/java/export-to-html5/)، [SVG](/slides/ar/java/render-a-slide-as-an-svg-image/)، أو [صور نقطية](/slides/ar/java/convert-powerpoint-to-png/)، يتم الاحتفاظ بها مع تنسيق الشريحة.

**هل تعمل الخطوط المخصصة في التعليقات التوضيحية، وهل يمكن الحفاظ على مظهرها عند التصدير؟**

نعم. تدعم Aspose.Slides [تضمين الخطوط](/slides/ar/java/embedded-font/) في العرض وتتحكم في تضمين الخطوط أثناء عمليات التصدير مثل [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، مما يضمن أن تبدو التعليقات التوضيحية نفسها عبر الأنظمة المختلفة.