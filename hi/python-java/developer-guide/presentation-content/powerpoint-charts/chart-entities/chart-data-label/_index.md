---
title: Python का उपयोग करके प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/python-java/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में अधिक आकर्षक स्लाइड्स के लिए Aspose.Slides for Python via Java का उपयोग करके चार्ट डेटा लेबल जोड़ना और फ़ॉर्मेट करना सीखें।"
---
## **परिचय**

डेटा लेबल चार्ट सीरीज़ और व्यक्तिगत डेटा पॉइंट्स के बारे में जानकारी दर्शाते हैं, जिससे पाठकों को मानों को पहचानने और चार्ट को समझने में मदद मिलती है। यह लेख मानों को फॉर्मेट करने, प्रतिशत दिखाने, लेबल टेक्स्ट पढ़ने, अक्ष अधिकतम से परे लेबल नियंत्रित करने, श्रेणी अक्ष लेबल स्पेसिंग समायोजित करने, और पाई चार्ट लेबल की स्थिति निर्धारित करने के तरीकों को समझाता है।

## **चार्ट डेटा लेबल में डेटा सटीकता निर्धारित करें**

[setNumberFormatOfValues](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) का उपयोग करके सीरीज़ के मानों को फॉर्मेट करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसका डेटा टेबल दिखाता है, और पहले सीरीज़ के लिए मान लेबल सक्षम करता है। फ़ॉर्मेट `#,##0.00` एक हजार विभाजक और दो दशमलव स्थान प्रदर्शित करता है बिना मूल मानों को बदले।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लेबल के रूप में प्रतिशत दिखाएँ**

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट को [getTextFrameForOverriding](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) द्वारा लौटाए गए टेक्स्ट फ्रेम में असाइन करें। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8‑पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को विभाजन शून्य से बचने के लिए छोड़ा जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः‑गणना करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट डेटा लेबल के साथ प्रतिशत संकेत निर्धारित करें**

यदि मान अंश के रूप में संग्रहीत हों, तो [setNumberFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/#setNumberFormat) का उपयोग करके प्रतिशत दिखाएँ। लेबल फ़ॉर्मेट को स्रोत कोशिकाओं से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) में `False` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीले सीरीज़ के साथ 100 % स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान जोड़ी का योग 1 होता है। लेबल फ़ॉर्मेट `0.0%` `0.30` को 30.0 % के रूप में दिखाता है, जबकि लंबवत अक्ष दो दशमलव स्थान का उपयोग करता है। दोनों सीरीज़ में सफेद, 10‑पॉइंट लेबल टेक्स्ट होता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **डेटा लेबल के वास्तविक टेक्स्ट को पढ़ें**

[getActualLabelText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#getActualLabelText) का उपयोग करके डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट प्राप्त करें। यह रिपोर्ट के लिए लेबल निकालने, प्रस्तुति सामग्री खोजने, या उत्पन्न चार्ट की वैधता जांचने में उपयोगी है। नीचे के उदाहरण में डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम, और मान को जोड़ता है। एक पॉइंट अपना मान प्रतिशत के रूप में फ़ॉर्मेट करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) से कस्टम टेक्स्ट उपयोग करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

डेटा पॉइंट में संग्रहीत संख्या `0.75` रहती है, जबकि उसका लेबल `75%` के साथ श्रेणी और सीरीज़ नाम दिखा सकता है। कस्टम टेक्स्ट जेनरेटेड लेबल टेक्स्ट को प्रतिस्थापित करता है। [getActualLabelText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#getActualLabelText) दोनों स्थितियों में परिणामी लेबल स्ट्रिंग लौटाता है। जैसा कि ऊपर दिखाया गया है, केवल दृश्यमान लेबल निकालने के लिए [isVisible](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#isVisible) को अलग से जांचें।

## **अक्ष अधिकतम से परे डेटा लेबल नियंत्रित करें**

जब आप मैन्युअल रूप से अक्ष रेंज सीमित करते हैं, तो कुछ डेटा पॉइंट्स उसका अधिकतम पार कर सकते हैं। [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) का उपयोग करके तय करें कि उनके डेटा लेबल दिखाए जाएँ या नहीं। यह सेटिंग लेबल की दृश्यता बदलती है; यह अक्ष रेंज या मूल डेटा मानों को नहीं बदलती।

नीचे का उदाहरण 60 और 120 के मानों के साथ 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह [setAutomaticMaxValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#setAutomaticMaxValue) में `False` पास करता है और लंबवत अक्ष पर [setMaxValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#setMaxValue) के साथ अधिकतम 100 सेट करता है। पहली स्लाइड में अधिकतम से परे लेबल सक्षम होते हैं; उसी स्लाइड की एक कॉपी में इन्हें निष्क्रिय किया गया है। दोनों स्लाइड्स `DataLabelsOverMaximum.pptx` में सहेजी गई हैं।

[setShowValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/#setShowValue) के साथ मान लेबल सक्षम करें। चार्ट‑स्तर की यह सेटिंग स्वयं मान प्रदर्शित नहीं करती और न ही व्यक्तिगत लेबल की डिसेबल्ड वैल्यू डिस्प्ले को ओवरराइड करती है। यह उदाहरण पूरी सीरीज़ के लिए मान सक्षम करता है और [setPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/#setPosition) का प्रयोग करके प्रत्येक कॉलम के बाहरी सिरे पर लेबल रखता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

निम्नलिखित चित्र Microsoft PowerPoint द्वारा रेंडर की गई सहेजी गई स्लाइड्स को दर्शाते हैं। `True` होने पर लेबल **120** ऊपर की सीमा पर दृश्यमान रहता है; `False` होने पर वह छिप जाता है। लेबल **60** दृश्यमान रहता है, अक्ष अधिकतम **100** पर बना रहता है, और दूसरा डेटा पॉइंट दोनों स्थितियों में **120** बना रहता है।

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण 2D कॉलम चार्ट को मान अक्ष के साथ उपयोग करता है। मान अक्ष के बिना चार्ट, जैसे पाई और डोनट चार्ट, इस प्रकार की अक्ष अधिकतम सीमा नहीं रखते।
{{% /alert %}}

## **अक्ष से लेबल की दूरी निर्धारित करें**

[setLabelOffset](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#setLabelOffset) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच की दूरी नियंत्रित करें। यह मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार के प्रतिशत के रूप में होता है। यह उदाहरण क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफसेट को 500 सेट करता है। यह सेटिंग श्रेणी अक्ष लेबल को प्रभावित करती है, न कि व्यक्तिगत डेटा पॉइंट्स से जुड़े लेबल को।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लेबल स्थान समायोजित करें**

पाई चार्ट पर, डेटा लेबल की स्थिति को समायोजित करके स्पेसिंग सुधारें और लीडर लाइनों के लिए जगह बनायें।

यह उदाहरण पहले डेटा पॉइंट का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और [setX](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#setX) एवं [setY](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#setY) के माध्यम से क्षैतिज व लंबवत ऑफसेट समायोजित करता है। ये ऑफसेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **FAQ**

**घने चार्ट्स में डेटा लेबल ओवरलैप को कैसे रोकूँ?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइनों, और छोटे फ़ॉन्ट आकार का मिश्रण करें; यदि आवश्यक हो, तो कुछ फ़ील्ड्स (जैसे श्रेणी) को छिपाएँ या केवल अत्यधिक या प्रमुख मानों के लिए लेबल दिखाएँ।

**शून्य, नकारात्मक या खाली मानों के लिए लेबल केवल कैसे निष्क्रिय करूँ?**

लेबल सक्षम करने से पहले डेटा पॉइंट्स को फ़िल्टर करें और 0, नकारात्मक या अनुपस्थित मानों के लिए डिस्प्ले को बंद करें, जैसा कि परिभाषित नियम में बताया गया है।

**PDF/इमेज एक्सपोर्ट पर लेबल शैली सुसंगत कैसे रखें?**

फ़ॉन्ट परिवार और आकार को स्पष्ट रूप से सेट करें तथा यह सुनिश्चित करें कि रेंडरिंग वातावरण में फ़ॉन्ट उपलब्ध हो, ताकि फ़ॉन्ट फॉलबैक न हो।