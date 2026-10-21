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
description: "PowerPoint प्रस्तुतियों में Aspose.Slides for Python via Java का उपयोग करके चार्ट डेटा लेबल जोड़ना और फ़ॉर्मेट करना सीखें, ताकि अधिक आकर्षक स्लाइड्स बन सकें।"
---
## **परिचय**

डेटा लेबल चार्ट श्रृंखलाओं और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी दिखाते हैं, जिससे पाठकों को मानों की पहचान करने और चार्ट को समझने में मदद मिलती है। यह लेख बताता है कि मानों को कैसे फ़ॉर्मेट किया जाए, प्रतिशत कैसे दिखाए जाएँ, लेबल टेक्स्ट कैसे पढ़ें, अक्ष अधिकतम से परे लेबल कैसे नियंत्रित करें, श्रेणी अक्ष लेबल स्पेसिंग को कैसे समायोजित करें, और पाई चार्ट लेबलों की स्थिति कैसे निर्धारित करें।

## **चार्ट डेटा लेबल में डेटा सटीकता सेट करें**

सीरीज़ मानों को फ़ॉर्मेट करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसका डेटा टेबल प्रदर्शित करता है, और पहली श्रृंखला के लिए वैल्यू लेबल सक्षम करता है। फ़ॉर्मेट `#,##0.00` थाउज़ेंड सेपरेटर और दो दशमलव स्थान दिखाता है बिना मूल मानों को बदले।

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

चार्ट की एम्बेडेड वर्कबुक में संख्यात्मक सेल्स को फ़ॉर्मेट करने के लिए, देखें [Set Custom Number Formats for Workbook Cells](/slides/hi/python-java/chart-workbook/#set-custom-number-formats-for-workbook-cells)। वह उदाहरण यह भी दर्शाता है कि वैल्यू लेबल उनके स्रोत सेल फ़ॉर्मेट का पालन करते हैं जबकि संग्रहीत संख्यात्मक मानों को संरक्षित रखा जाता है।

## **लेबल के रूप में प्रतिशत दिखाएँ**

एक स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट को उस टेक्स्ट फ्रेम में असाइन करें जो [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) द्वारा लौटाया जाता है। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8‑पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को विभाजन शून्य से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबल के साथ प्रतिशत संकेत सेट करें**

जब मानों को भिन्नों के रूप में सहेजा जाता है, तो प्रतिशत दिखाने के लिए [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत सेल्स से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) को `False` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीली श्रृंखलाओं के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मानों की जोड़ी 1 के बराबर होती है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0% के रूप में दिखाता है, जबकि वर्टिकल अक्ष दो दशमलव स्थान का उपयोग करता है। दोनों श्रृंखलाएँ सफ़ेद, 10‑पॉइंट लेबल टेक्स्ट उपयोग करती हैं।

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

## **डेटा लेबल का वास्तविक टेक्स्ट पढ़ें**

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट को प्राप्त करने के लिए [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) का उपयोग करें। यह रिपोर्टों के लिए लेबल निकालते समय, प्रस्तुति सामग्री खोजते समय, या जेनरेटेड चार्ट्स को वैलिडेट करते समय उपयोगी है। नीचे के उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) प्रत्येक श्रेणी नाम, श्रृंखला नाम, और मान को मिलाता है। एक बिंदु अपने मान को प्रतिशत के रूप में फ़ॉर्मेट करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा बिंदु में संग्रहीत संख्या `0.75` बनी रहती है, भले ही उसका लेबल `75%` दिखाए और श्रेणी व श्रृंखला नाम भी दिखाए। कस्टम टेक्स्ट जेनरेटेड लेबल टेक्स्ट को प्रतिस्थापित करता है। [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) किसी भी स्थिति में परिणामी लेबल स्ट्रिंग लौटाता है। जब आप केवल दृश्य लेबल निकालना चाहते हैं, तो ऊपर दिखाए अनुसार [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) को अलग से जांचें।

## **अक्ष अधिकतम से परे डेटा लेबल नियंत्रित करें**

जब आप मैन्युअल रूप से किसी अक्ष की रेंज सीमित करते हैं, तो कुछ डेटा बिंदु उसके अधिकतम से अधिक हो सकते हैं। यह नियंत्रित करने के लिए [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) का उपयोग करें कि उनके डेटा लेबल दिखाए जाएँ या नहीं। यह सेटिंग लेबल दृश्यता को बदलती है; यह अक्ष रेंज या मूल डेटा मानों को नहीं बदलती।

नीचे का उदाहरण 60 और 120 मानों के साथ 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह वर्टिकल अक्ष पर [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) को `False` पास करता है और [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) से अधिकतम को 100 सेट करता है। पहली स्लाइड अधिकतम से परे लेबल को अनुमति देती है; उस स्लाइड की एक प्रति उन्हें निष्क्रिय करती है। दोनों स्लाइड्स `DataLabelsOverMaximum.pptx` में सहेजी जाती हैं।

[value labels को [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) के साथ सक्षम करें। चार्ट-स्तर की सेटिंग स्वयं वैल्यू प्रदर्शित नहीं करती या किसी व्यक्तिगत लेबल के निष्क्रिय वैल्यू प्रदर्शन को ओवरराइड नहीं करती। यह उदाहरण पूरे श्रृंखला के लिए वैल्यू सक्षम करता है और [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) का उपयोग करके लेबल को प्रत्येक कॉलम के बाहरी सिरे पर रखता है।

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

निम्नलिखित छवियाँ Microsoft PowerPoint द्वारा रेंडर किए गए सहेजे गए स्लाइड्स दिखाती हैं। `True` के साथ, लेबल **120** ऊपर की सीमा पर दिखाई देता है; `False` के साथ, वह छिपा रहता है। लेबल **60** दृश्य रहता है, अक्ष अधिकतम **100** पर बना रहता है, और दूसरा डेटा बिंदु दोनों मामलों में **120** रहता है।

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint चार्ट जिसमें मान लेबल 120 दिखाया गया है और अक्ष अधिकतम 100 है](data-labels-over-maximum-true.png) | ![PowerPoint चार्ट जो मान लेबल 120 को छिपा रहा है और अक्ष अधिकतम 100 है](data-labels-over-maximum-false.png) |

{{% alert color="info" title="चार्ट प्रकार" %}}
यह उदाहरण वैल्यू अक्ष के साथ 2D कॉलम चार्ट का उपयोग करता है। वैल्यू अक्ष के बिना चार्ट, जैसे पाई और डोनट चार्ट, इस प्रकार के लिए अक्ष अधिकतम नहीं रखते हैं।
{{% /alert %}}

## **अक्ष से लेबल दूरी सेट करें**

[setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच दूरी नियंत्रित करें। मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और हॉरिज़ॉन्टल अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा बिंदुओं से जुड़े लेबल के बजाय श्रेणी अक्ष लेबल को प्रभावित करती है।

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

पाई चार्ट में, डेटा लेबल की स्थितियों को समायोजित करके स्पेसिंग सुधारें और लीडर लाइन्स के लिए जगह बनाएं।

यह उदाहरण पहले डेटा बिंदु का मान दर्शाता है, उसका लेबल स्लाइस के बाहर रखता है, और [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) और [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) का उपयोग करके उसकी हॉरिज़ॉन्टल और वर्टिकल ऑफ़सेट को समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के अनुसार होते हैं।

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

![समायोजित डेटा लेबल स्थिति वाला पाई चार्ट](pie-chart-adjusted-label.png)

## **लीडर लाइन्स को फ़ॉर्मेट करें**

जब पाई चार्ट लेबल अपने स्लाइस के बाहर स्थित होते हैं, तो लीडर लाइन्स पाठकों को प्रत्येक मान को सही स्लाइस से मिलाने में मदद करती हैं। एक विपरीत रंग और थोड़ा मोटी लाइन इन कनेक्शनों को आसानी से फॉलो करने योग्य बनाती है, जबकि ट्रांसपेरेंसी और डैश्ड शैली लाइन्स को दृश्य रूप से कम बाधित रखती है।

सीरीज़ के डेटा लेबल कलेक्शन स्तर पर लीडर लाइन्स को फ़ॉर्मेट करने के लिए [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) का उपयोग करें। `series.getLabels().getLeaderLinesFormat().getLine()` में सेटिंग्स कलेक्शन पर लागू होती हैं, न कि व्यक्तिगत लेबल पर।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, स्लाइसेस के बाहर मान दिखाता है, और [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines) को सक्षम करता है। यह दो लेबल्स को उनके स्लाइसेस से अधिक दूर ले जाता है, [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) और [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) ऑफ़सेट का उपयोग करके, जो चार्ट की चौड़ाई और ऊँचाई के अंश के रूप में व्यक्त होते हैं। इनपुट प्रेजेंटेशन की आवश्यकता नहीं है।

लाइन की [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) 255 में से 191 अल्फा मान के साथ ठोस नीला रंग सेट करती है, जिससे लगभग 25% ट्रांसपेरेंसी मिलती है। [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) मोटाई को 2 पॉइंट सेट करता है, और [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) लाइन को डैश्ड बनाता है।

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # दो लेबल्स को उनके स्लाइस से अधिक दूर ले जाएँ.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

लीडर लाइन्स को सक्षम करने से यह गारंटी नहीं मिलती कि प्रत्येक लेबल के लिए लाइन दिखाई देगी। दृश्यता लेबल की स्थिति और चार्ट के लेआउट व्यवहार पर निर्भर करती है। इस उदाहरण में, दो हटाए गए लेबल्स के पास दृश्य लीडर लाइन्स हैं; जो लेबल्स अपने स्लाइसेस के पास रहते हैं उन्हें इसकी आवश्यकता नहीं है।

निम्नलिखित छवि में Aspose.Slides के साथ रेंडर किया गया सहेजा गया `FormattedLeaderLines.pptx` दिखाया गया है:

![नीले, अ半-ट्रांसपेरेंट डैश्ड लीडर लाइन्स के साथ पाई चार्ट, जो दो बाहरी लेबल्स को उनके स्लाइस से जोड़ता है](formatted-leader-lines.png)

## **कॉलम चार्ट के ऊपर कई पंक्तियों के डेटा लेबल जोड़ें**

यह उदाहरण प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल के साथ एक कॉलम चार्ट बनाता है। Series A दृश्यमान कॉलम दिखाता है, जबकि Series B और Series C अतिरिक्त लेबल प्रदान करते हैं। उनके कॉलम फ़िल और आउटलाइन हटाकर छिपाए जाते हैं। [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) विधि सभी तीन श्रृंखलाओं को एक ही श्रेणी केंद्र के साथ संरेखित करती है।

[ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) सेटिंग्स लेबल पंक्तियों के लिए जगह आरक्षित करती हैं। जब [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) डिफ़ॉल्ट पोज़िशन की गणना करता है, तो [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) और [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) हॉरिज़ॉन्टल एलाइनमेंट को बनाए रखते हैं और दो पंक्तियों में लेबल व्यवस्थित करने के लिए वर्टिकल ऑफ़सेट लागू करते हैं। संख्याएँ श्रृंखला मानों से जुड़ी डेटा लेबल रहती हैं; केवल पंक्ति शीर्षकों को अलग टेक्स्ट शैप्स होते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpile.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # B और C की कॉलम को छिपाएँ, लेकिन उनके डेटा लेबल रखें।
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # सभी तीन श्रृंखलाओं को एक ही श्रेणी केंद्रों के साथ संरेखित करें।
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # इस संक्षिप्त उदाहरण के लिए कम ग्रिडलाइन उपयोग करें।
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # प्लॉट के ऊपर दो पंक्तियों के डेटा लेबलों के लिए स्थान आरक्षित करें।
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # डिफ़ॉल्ट क्षैतिज स्थिति रखें। Y एक ऑफ़सेट है
            # डिफ़ॉल्ट लेबल स्थिति से, जो चार्ट-ऊँचाई के भाग के रूप में व्यक्त है।
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # केवल पंक्ति शीर्षक एक अलग टेक्स्ट शेप है।
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल वाला कॉलम चार्ट](multiple-rows-of-labels.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं घने चार्ट्स पर डेटा लेबल के ओवरलैप को कैसे रोक सकता हूँ?**  
ऑटोमेटिक लेबल प्लेसमेंट, लीडर लाइन्स और छोटे फ़ॉन्ट आकार को मिलाएँ; यदि आवश्यक हो तो कुछ फ़ील्ड्स (जैसे श्रेणी) को छिपाएँ या केवल अत्यधिक मानों या मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**मैं शून्य, नकारात्मक या खाली मानों के लिए केवल लेबल कैसे अक्षम करूँ?**  
लेबल सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक या अनुपलब्ध मानों के प्रदर्शन को बंद करें।

**PDF/छवियों में निर्यात करते समय लेबल शैली को सुसंगत कैसे रखें?**  
फ़ॉन्ट फ़ैमिली और आकार को स्पष्ट रूप से सेट करें और सुनिश्चित करें कि रेंडरिंग वातावरण में फ़ॉन्ट उपलब्ध है ताकि फ़ॉलबैक न हो।