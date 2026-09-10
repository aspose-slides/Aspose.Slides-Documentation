---
title: Python का उपयोग करके प्रेज़ेंटेशन चार्ट्स में कॉलआउट प्रबंधित करें
linktitle: कॉलआउट
type: docs
url: /hi/python-java/callout/
keywords:
- चार्ट कॉलआउट
- कॉलआउट का उपयोग
- डेटा लेबल
- लेबल फ़ॉर्मेट
- PowerPoint
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में कॉलआउट बनाएं और उनका स्वरूप डिज़ाइन करें, संक्षिप्त कोड उदाहरणों के साथ, जो PPT और PPTX के साथ संगत हैं, जिससे प्रेजेंटेशन कार्यप्रवाह स्वचालित हो सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा लेबल के लिए कॉलआउट का उपयोग कैसे किया जाए, इसे समझाता है। यह बताता है कि लेबल को कॉलआउट के रूप में प्रदर्शित करने के लिए [setShowLabelAsDataCallout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) मेथड का उपयोग कैसे किया जाता है, डोनट चार्ट के लिए कॉलआउट‑संबंधी लेबल सेटिंग्स कैसे कॉन्फ़िगर की जाती हैं, और यह नोट करता है कि प्रस्तुति को PDF, HTML5, SVG, और रास्टर इमेज फ़ॉर्मेट में निर्यात करने पर कॉलआउट और उनका स्वरूप संरक्षित रहता है।

## **कॉलआउट का उपयोग**

[DataLabelFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/) वर्ग के [getShowLabelAsDataCallout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) और [setShowLabelAsDataCallout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) मेथड यह निर्धारित करते हैं कि चार्ट डेटा लेबल को कॉलआउट के रूप में दिखाया जाए या सामान्य डेटा लेबल के रूप में।

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

## **डोनट चार्ट के लिए कॉलआउट सेट करें**

Aspose.Slides for Python via Java डोनट चार्ट के लिए श्रृंखला डेटा लेबल कॉलआउट आकार सेट करने का समर्थन करता है। निम्न उदाहरण इसको प्रदर्शित करता है।

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

## **FAQ**

**क्या प्रस्तुति को PDF, HTML5, SVG या छवियों में बदलते समय कॉलआउट संरक्षित रहते हैं?**

हाँ। कॉलआउट चार्ट रेंडरिंग का हिस्सा होते हैं, इसलिए जब आप इसे [PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/hi/python-java/export-to-html5/), [SVG](/slides/hi/python-java/render-a-slide-as-an-svg-image/), या [raster images](/slides/hi/python-java/convert-powerpoint-to-png/) में निर्यात करते हैं, तो वे स्लाइड के फॉर्मेटिंग के साथ संरक्षित रहते हैं।

**क्या कस्टम फ़ॉन्ट कॉलआउट में काम करते हैं, और क्या उनका स्वरूप निर्यात पर संरक्षित रहता है?**

हाँ। Aspose.Slides प्रस्तुति में [embedding fonts](/slides/hi/python-java/embedded-font/) को एम्बेड करने का समर्थन करता है और PDF जैसी निर्यात प्रक्रियाओं में फ़ॉन्ट एम्बेडिंग को नियंत्रित करता है, जिससे कॉलआउट विभिन्न सिस्टमों पर समान दिखते हैं।