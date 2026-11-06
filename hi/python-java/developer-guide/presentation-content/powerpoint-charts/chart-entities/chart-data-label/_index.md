---
title: पाइथन का उपयोग करके प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें
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
- प्रेजेंटेशन
- पाइथन
- जावा
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में Aspose.Slides for Python via Java का उपयोग करके चार्ट डेटा लेबल जोड़ने और स्वरूपित करने के बारे में सीखें ताकि अधिक आकर्षक स्लाइड्स बन सकें।"
---
## **परिचय**

डेटा लेबल चार्ट श्रृंखलाओं और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मानों की पहचान करने और चार्ट को समझने में मदद मिलती है। यह लेख मानों को स्वरूपित करने, प्रतिशत प्रदर्शित करने, लेबल पाठ को पढ़ने, अक्ष अधिकतम से परे लेबल नियंत्रित करने, श्रेणी अक्ष लेबल स्पेसिंग को समायोजित करने, और पाई चार्ट लेबल की स्थिति निर्धारित करने के तरीकों को समझाता है।

## **दृश्यमान डेटा लेबल की गणना**

प्रस्तुति प्रकाशित करने से पहले यह जांचने के लिए कि कितने डेटा लेबल प्रदर्शित करने के लिए सक्षम हैं, [getCountOfVisibleDataLabels](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCountOfVisibleDataLabels) का उपयोग करें। [getCount](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCount) से भिन्न, जो संग्रह में कुल लेबलों की संख्या लौटाता है, यह श्रृंखला डिफॉल्ट्स और व्यक्तिगत लेबल सेटिंग्स को ध्यान में रखता है।

यह उदाहरण एक कॉलम चार्ट बनाता है जिसमें एक श्रृंखला और तीन डेटा बिंदु होते हैं। यह श्रृंखला के लेबल संग्रह को [getLabels](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getLabels) के माध्यम से एक्सेस करता है और सेटिंग्स बदलने पर दृश्यमान गणना को प्रदर्शित करता है: **0, 3, 2, 3**। कुल गणना **3** ही रहती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    series_cell = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    for i in range(3):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JDouble((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    labels = series.getLabels()
    print(f"Total: {labels.getCount()}; visible: {labels.getCountOfVisibleDataLabels()}")  # कुल: 3; दृश्यमान: 0

    labels.getDefaultDataLabelFormat().setShowValue(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # दृश्यमान: 3

    labels.get_Item(1).getDataLabelFormat().setShowValue(False)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # दृश्यमान: 2

    labels.get_Item(1).getDataLabelFormat().setShowLegendKey(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # दृश्यमान: 3
finally:
    presentation.dispose()
```

श्रृंखला का [getDefaultDataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getDefaultDataLabelFormat) डिफॉल्ट सेटिंग्स प्रदान करता है। वहाँ [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) में `True` पास करने से तीनों लेबलों के मान प्रदर्शित होते हैं। एक लेबल के [getDataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getDataLabelFormat) के माध्यम से `False` पास करने से चयनित लेबल के लिए वह सेटिंग अधिलेखित हो जाती है। [setShowLegendKey](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLegendKey) में `True` पास करने से वह लेबल फिर से दृश्यमान गिना जाता है, भले ही उसका मान छिपा रहना जारी रहे।

दृश्यमान गणना दृश्यता सेटिंग्स को दर्शाती है। यह नहीं मापती कि लेबल ओवरलैप होते हैं, काटे गए हैं, या रेंडर किए गए चार्ट में पढ़ने योग्य हैं या नहीं।

## **चार्ट डेटा लेबल में डेटा सटीकता सेट करें**

श्रृंखला मानों को स्वरूपित करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) का उपयोग करें। यह उदाहरण डिफॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, इसकी डेटा तालिका प्रदर्शित करता है, और पहली श्रृंखला के लिए मान लेबल सक्षम करता है। स्वरूप `#,##0.00` हजारों विभाजक और दो दशमलव स्थान प्रदर्शित करता है बिना मूल मानों को बदले।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

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

एक चार्ट की एम्बेडेड वर्कबुक में संख्यात्मक कोशिकाओं को स्वरूपित करने के लिए, देखें [Set Custom Number Formats for Workbook Cells](/slides/hi/python-java/chart-workbook/#set-custom-number-formats-for-workbook-cells)। वह उदाहरण यह भी दर्शाता है कि मान लेबल उनके स्रोत कोशिका स्वरूपों का पालन करते हैं जबकि संग्रहित संख्यात्मक मानों को बरकरार रखते हैं।

## **लेबल के रूप में प्रतिशत प्रदर्शित करें**

एक स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल का प्रतिशत गणना करके टेक्स्ट फ्रेम में असाइन करें जो [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) द्वारा लौटाया जाता है। यह उदाहरण डिफॉल्ट चार्ट डेटा का उपयोग करता है और 8 पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत प्रदर्शित करता है। शून्य कुल वाली श्रेणियों को शून्य से भाग देने से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबल में प्रतिशत चिह्न सेट करें**

जब मान अंश के रूप में संग्रहीत होते हैं, तो प्रतिशत प्रदर्शित करने के लिए [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) का उपयोग करें। लेबल स्वरूप को स्रोत कोशिकाओं से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) में `False` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीले श्रृंखलाओं के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान युग्म का योग 1 होता है। लेबल स्वरूप `0.0%` 0.30 को 30.0% के रूप में प्रदर्शित करता है, जबकि लंबवत अक्ष दो दशमलव स्थानों का उपयोग करता है। दोनों श्रृंखलाएँ सफेद, 10 पॉइंट लेबल टेक्स्ट उपयोग करती हैं।

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

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट प्राप्त करने के लिए [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) का उपयोग करें। यह रिपोर्टों के लिए लेबल निकालते समय, प्रस्तुति सामग्री खोजते समय, या उत्पन्न चार्ट को वैध करते समय उपयोगी है। नीचे के उदाहरण में, डिफॉल्ट [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) प्रत्येक श्रेणी नाम, श्रृंखला नाम और मान को संयोजित करता है। एक बिंदु अपने मान को प्रतिशत के रूप में स्वरूपित करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा बिंदु में संग्रहीत संख्या `0.75` ही रहती है, भले ही उसका लेबल `75%` को श्रेणी और श्रृंखला नामों के साथ प्रदर्शित करे। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) दोनों स्थितियों में परिणामी लेबल स्ट्रिंग लौटाता है। जब आप केवल दृश्यमान लेबल निकालना चाहते हैं, तो ऊपर दिखाए अनुसार [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) को अलग से जांचें।

## **अक्ष अधिकतम से परे डेटा लेबल नियंत्रित करें**

जब आप अक्ष रेंज को मैन्युअली सीमित करते हैं, तो कुछ डेटा बिंदु उसके अधिकतम से अधिक हो सकते हैं। यह नियंत्रित करने के लिए कि उनके डेटा लेबल दिखाए जाएँ या नहीं, [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) का उपयोग करें। यह सेटिंग लेबल दृश्यता को बदलती है; यह अक्ष रेंज या अंतर्निहित डेटा मानों को नहीं बदलती।

निम्नलिखित उदाहरण 60 और 120 मानों के साथ एक 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) में `False` पास करता है और लंबवत अक्ष पर [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) के साथ अधिकतम को 100 पर सेट करता है। प्रथम स्लाइड अधिकतम से परे लेबल की अनुमति देती है; उस स्लाइड की एक कॉपी उन्हें अक्षम करती है। दोनों स्लाइडें `DataLabelsOverMaximum.pptx` में सहेजी जाती हैं।

[setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) के साथ मान लेबल सक्षम करें। चार्ट-स्तर की सेटिंग स्वयं मान प्रदर्शित नहीं करती या व्यक्तिगत लेबल के अक्षम मान प्रदर्शनीय को ओवरराइड नहीं करती। यह उदाहरण पूरी श्रृंखला के लिए मान सक्षम करता है और [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) का उपयोग करके प्रत्येक कॉलम के बाहरी सिरे पर लेबल रखता है।

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

निम्नलिखित छवियाँ Microsoft PowerPoint द्वारा रेंडर किए गए सहेजे गए स्लाइडों को दर्शाती हैं। `True` के साथ, लेबल **120** ऊपरी सीमा पर दृश्यमान होता है; `False` के साथ, वह छिपा रहता है। लेबल **60** दृश्यमान रहता है, अक्ष अधिकतम **100** पर बना रहता है, और दूसरा डेटा बिंदु दोनों स्थितियों में **120** ही रहता है।

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint चार्ट जो अक्ष अधिकतम 100 के साथ मान लेबल 120 दिखाता है](data-labels-over-maximum-true.png) | ![PowerPoint चार्ट जो अक्ष अधिकतम 100 के साथ मान लेबल 120 को छिपा रहा है](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण मान अक्ष वाला 2D कॉलम चार्ट उपयोग करता है। बिना मान अक्ष वाले चार्ट, जैसे पाई और डोनट चार्ट, इस प्रकार अक्ष अधिकतम को सीमित नहीं कर सकते।
{{% /alert %}}

## **अक्ष से लेबल दूरी सेट करें**

[setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच की दूरी नियंत्रित करें। मान अक्ष लेबल की अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफसेट को 500 पर सेट करता है। यह सेटिंग व्यक्तिगत डेटा बिंदुओं से जुड़े लेबल की बजाय श्रेणी अक्ष लेबल को प्रभावित करती है।

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

## **लेबल का स्थान समायोजित करें**

पाई चार्ट पर, डेटा लेबल की स्थितियों को समायोजित करके स्पेसिंग में सुधार करें और लीडर लाइनों के लिए जगह बनाएँ।

यह उदाहरण पहले डेटा बिंदु का मान प्रदर्शित करता है, उसका लेबल स्लाइस के बाहर रखता है, और [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) तथा [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) का उपयोग करके उसके क्षैतिज और लंबवत ऑफसेट को समायोजित करता है। ये ऑफसेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

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

## **लीडर लाइनों का स्वरूप**

जब पाई चार्ट लेबल उनके स्लाइस के बाहर स्थित होते हैं, तो लीडर लाइनों से पाठकों को प्रत्येक मान को सही स्लाइस से मिलाने में मदद मिलती है। विपरीत रंग और थोड़ी मोटी लाइन इन कनेक्शनों को अनुसरण करने में आसान बनाती है, जबकि पारदर्शिता और डैश्ड शैली लाइनों को दृश्य रूप से कम हस्तक्षेपकारी रखती है।

लीडर लाइनों को श्रृंखला के डेटा लेबल संग्रह स्तर पर स्वरूपित करने के लिए [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) का उपयोग करें। `series.getLabels().getLeaderLinesFormat().getLine()` में सेटिंग्स संग्रह पर लागू होती हैं, न कि व्यक्तिगत लेबल पर।

यह उदाहरण डिफॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, स्लाइस के बाहर मान प्रदर्शित करता है, और [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines) को सक्षम करता है। यह दो लेबल को उनके स्लाइस से अधिक दूर ले जाने के लिए [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) और [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) ऑफसेट का उपयोग करता है, जो चार्ट की चौड़ाई और ऊँचाई के अंश के रूप में व्यक्त होते हैं। इनपुट प्रस्तुति आवश्यक नहीं है।

लाइन की [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) 255 में से 191 अल्फा मान के साथ ठोस नीला रंग सेट करती है, जिससे लगभग 25% पारदर्शिता मिलती है। [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) मोटाई को 2 पॉइंट सेट करता है, और [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) लाइन को डैश्ड बनाता है।

```python
import jpype
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

    # दो लेबल को उनके स्लाइस से दूर ले जाएँ।
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

लीडर लाइनों को सक्षम करने से यह गारंटी नहीं होती कि प्रत्येक लेबल के लिए लाइन दिखाई देगी। दृश्यता लेबल की स्थिति और चार्ट के लेआउट व्यवहार पर निर्भर करती है। इस उदाहरण में, दो स्थानांतरित लेबलों के पास दृश्यमान लीडर लाइने हैं; जो लेबल अपने स्लाइस के करीब रहते हैं उन्हें इसकी आवश्यकता नहीं है।

निम्न छवि Aspose.Slides के साथ रेंडर किए गए सहेजे गए `FormattedLeaderLines.pptx` को दर्शाती है।

![पाई चार्ट जिसमें दो बाहर के लेबल को उनके स्लाइस से जोड़ने वाली नीली, अर्धपारदर्शी, डैश्ड लीडर लाइने हैं](formatted-leader-lines.png)

## **कॉलम चार्ट के ऊपर कई पंक्तियों के डेटा लेबल जोड़ें**

यह उदाहरण प्लॉट क्षेत्र के ऊपर दो पंक्तियों के डेटा लेबल के साथ एक कॉलम चार्ट बनाता है। श्रृंखला A दृश्यमान कॉलम दिखाती है, जबकि श्रृंखला B और C अतिरिक्त लेबल प्रदान करती हैं। उनके कॉलम भराव और आउटलाइन हटाकर छिपाए जाते हैं। [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) मेथड सभी तीन श्रृंखलाओं को समान श्रेणी केंद्रों के साथ संरेखित करता है।

[ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) सेटिंग्स लेबल पंक्तियों के लिए जगह आरक्षित करती हैं। [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) डिफॉल्ट स्थितियों की गणना करने के बाद, [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) और [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) क्षैतिज संरेखण को बनाए रखते हैं और दो पंक्तियों में लेबल व्यवस्थित करने के लिए लंबवत ऑफसेट लागू करते हैं। संख्याएँ श्रृंखला मानों से जुड़ी डेटा लेबल ही रहती हैं; केवल पंक्ति शीर्षक अलग टेक्स्ट शेप होते हैं।

```python
import jpace
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

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
            # B और C के कॉलम छिपाएँ, लेकिन उनके डेटा लेबल रखें।
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # सभी तीन श्रृंखलाओं को समान श्रेणी केंद्रों के साथ संरेखित करें।
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # इस संकुचित उदाहरण के लिए कम ग्रिड लाइनों का उपयोग करें।
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # दो पंक्तियों के डेटा लेबल के लिए प्लॉट के ऊपर स्थान आरक्षित करें।
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
            # डिफ़ॉल्ट क्षैतिज स्थिति रखें। Y का ऑफसेट है
            # डिफ़ॉल्ट लेबल स्थिति से, चार्ट-ऊँचाई के अंश के रूप में व्यक्त किया गया।
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # केवल पंक्ति शीर्षक एक अलग टेक्स्ट आकार है।
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

![प्लॉट क्षेत्र के ऊपर दो पंक्तियों के डेटा लेबल के साथ कॉलम चार्ट](multiple-rows-of-labels.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं घने चार्ट पर डेटा लेबल के ओवरलैप को कैसे रोक सकता हूँ?**  
स्वचालित लेबल प्लेसमेंट, लीडर लाइन्स और छोटे फ़ॉन्ट आकार को मिलाएँ; यदि आवश्यक हो तो कुछ फ़ील्ड (जैसे श्रेणी) को छिपाएँ या केवल अत्यधिक मानों या प्रमुख बिंदुओं के लिए लेबल दिखाएँ।

**मैं शून्य, नकारात्मक या खाली मानों के लिए केवल लेबल कैसे अक्षम करूँ?**  
लेबल सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक मान या गायब मानों के लिए प्रदर्शन बंद करें।

**PDF/इमेज में निर्यात करते समय लेबल शैली में निरंतरता कैसे सुनिश्चित करूँ?**  
फ़ॉन्ट फ़ैमिली और आकार को स्पष्ट रूप से सेट करें और यह सुनिश्चित करें कि रेंडरिंग पर्यावरण में फ़ॉन्ट उपलब्ध है ताकि फ़ॉलबैक से बच सकें।