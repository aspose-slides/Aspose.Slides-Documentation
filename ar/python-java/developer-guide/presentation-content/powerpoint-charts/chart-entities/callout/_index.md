---
title: إدارة الفقاعات في مخططات العروض التقديمية باستخدام بايثون
linktitle: فقاعة
type: docs
url: /ar/python-java/callout/
keywords:
- فقاعة المخطط
- استخدام الفقاعة
- ملصق البيانات
- تنسيق الملصق
- PowerPoint
- عرض تقديمي
- بايثون
- جافا
- Aspose.Slides
description: "إنشاء وتنسيق الفقاعات في Aspose.Slides للبايثون عبر جافا باستخدام أمثلة شفرة مختصرة، متوافقة مع PPT و PPTX لأتمتة سير عمل العروض التقديمية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع الفقاعات لملصقات بيانات المخطط في Aspose.Slides. توضح كيفية استخدام طريقة [setShowLabelAsDataCallout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) لعرض الملصقات كفقاعات، وكيفية تكوين إعدادات الملصق المتعلقة بالفقاعة لمخطط الحلقة، وتلاحظ أن الفقاعات ومظهرها يتم الحفاظ عليها عند تصدير العروض إلى PDF وHTML5 وSVG وصيغ الصور النقطية.

## **استخدام الفقاعات**

تحدد طريقتا [getShowLabelAsDataCallout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) و[setShowLabelAsDataCallout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) في فئة [DataLabelFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datalabelformat/) ما إذا كان يتم عرض ملصق بيانات المخطط كفقاعة أو كملصق بيانات عادي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400)
    labels = chart.getChartData().getSeries().get_Item(0).getLabels()
    default_label_format = labels.getDefaultDataLabelFormat()
    default_label_format.setShowValue(True)
    default_label_format.setShowLabelAsDataCallout(True)
    labels.get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(False)

    presentation.save("DisplayCharts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين فقاعة لمخطط الحلقة**

يدعم Aspose.Slides للـ Python عبر Java تعيين شكل فقاعة ملصق بيانات السلسلة لمخطط الحلقة. المثال التالي يوضح ذلك.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat, TextAutofitType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, False)
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(False)

    for series_index in range(15):
        series_cell = workbook.getCell(0, 0, series_index + 1, f"SERIES {series_index}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        series.setExplosion(0)
        series.getParentSeriesGroup().setDoughnutHoleSize(jpype.JByte(20))
        series.getParentSeriesGroup().setFirstSliceAngle(351)

    for category_index in range(15):
        category_cell = workbook.getCell(0, category_index + 1, 0, f"CATEGORY {category_index}")
        chart.getChartData().getCategories().add(category_cell)
        for i in range(chart.getChartData().getSeries().size()):
            series = chart.getChartData().getSeries().get_Item(i)
            data_cell = workbook.getCell(0, category_index + 1, i + 1, jpype.JInt(1))
            data_point = series.getDataPoints().addDataPointForDoughnutSeries(data_cell)
            data_point.getFormat().getFill().setFillType(FillType.Solid)
            line_format = data_point.getFormat().getLine()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)
            line_format.setWidth(1)
            line_format.setStyle(LineStyle.Single)
            line_format.setDashStyle(LineDashStyle.Solid)
            if i == chart.getChartData().getSeries().size() - 1:
                label = data_point.getLabel()
                label.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape)
                label_format = label.getDataLabelFormat()
                portion_format = label_format.getTextFormat().getPortionFormat()
                portion_format.setFontBold(NullableBool.True_)
                font = FontData("DINPro-Bold")
                portion_format.setLatinFont(font)
                portion_format.setFontHeight(12)
                portion_format.getFillFormat().setFillType(FillType.Solid)
                portion_format.getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)
                label_format.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.WHITE)
                label_format.setShowValue(False)
                label_format.setShowCategoryName(True)
                label_format.setShowSeriesName(False)
                label_format.setShowLeaderLines(True)
                label_format.setShowLabelAsDataCallout(False)
                chart.validateChartLayout()
                label.setX(label.getX() + 0.5)
                label.setY(label.getY() + 0.5)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يتم الحفاظ على الفقاعات عند تحويل العرض إلى PDF أو HTML5 أو SVG أو صور؟**

نعم. الفقاعات هي جزء من عرض المخطط، لذا عند تصديرك إلى [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)، [HTML5](/slides/ar/python-java/export-to-html5/)، [SVG](/slides/ar/python-java/render-a-slide-as-an-svg-image/)، أو [raster images](/slides/ar/python-java/convert-powerpoint-to-png/)، يتم الحفاظ عليها مع تنسيق الشريحة.

**هل تعمل الخطوط المخصصة في الفقاعات، وهل يمكن الحفاظ على مظهرها عند التصدير؟**

نعم. يدعم Aspose.Slides [embedding fonts](/slides/ar/python-java/embedded-font/) في العرض ويتحكم في تضمين الخطوط أثناء عمليات التصدير مثل [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)، مما يضمن بقاء الفقاعات بنفس الشكل عبر الأنظمة المختلفة.