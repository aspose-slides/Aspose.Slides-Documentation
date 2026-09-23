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
description: "PowerPoint प्रस्तुतियों में अधिक आकर्षक स्लाइड्स के लिए Aspose.Slides for Python via Java का उपयोग करके चार्ट डेटा लेबल जोड़ना और स्वरूपित करना सीखें।"
---
## **परिचय**

डेटा लेबल चार्ट सीरीज़ और व्यक्तिगत डेटा पॉइंट्स के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मान पहचानने और चार्ट समझने में मदद मिलती है। यह लेख बताता है कि मानों को कैसे स्वरूपित करें, प्रतिशत कैसे दिखाएँ, लेबल टेक्स्ट कैसे पढ़ें, श्रेणी अक्ष लेबल स्पेसिंग को कैसे समायोजित करें, और पाई चार्ट लेबल को कैसे स्थित करें।

## **डेटा लेबल में डेटा सटीकता सेट करें**

सीरीज़ मानों को स्वरूपित करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसकी डेटा टेबल दिखाता है, और पहली सीरीज़ के लिए मान लेबल सक्षम करता है। फ़ॉर्मेट `#,##0.00` हजार विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मानों को बदले।

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

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल का प्रतिशत गणना करें और टेक्स्ट को उस टेक्स्ट फ्रेम में असाइन करें जो [getTextFrameForOverriding](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) द्वारा लौटाया जाता है। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8‑पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को शून्य से विभाजन से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

जब मान अंश के रूप में संग्रहीत होते हैं, तो प्रतिशत दिखाने के लिए [setNumberFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/#setNumberFormat) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत सेल्स से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) को `False` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीले सीरीज़ के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान जोड़ी का योग 1 होता है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0% के रूप में दिखाता है, जबकि लम्बवत अक्ष दो दशमलव स्थान उपयोग करता है। दोनों सीरीज़ सफेद, 10‑पॉइंट लेबल टेक्स्ट प्रयोग करते हैं।

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

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट को प्राप्त करने के लिए [getActualLabelText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#getActualLabelText) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकालते समय, प्रस्तुतिकरण सामग्री खोजते समय, या जेनरेटेड चार्ट्स को वैध करते समय उपयोगी है। नीचे दिए गए उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम, और मान को संयोजित करता है। एक पॉइंट अपना मान प्रतिशत के रूप में स्वरूपित करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा पॉइंट में संग्रहीत संख्या `0.75` ही रहती है, भले ही उसका लेबल `75%` के साथ श्रेणी और सीरीज़ नाम दिखाए। कस्टम टेक्स्ट जेनरेटेड लेबल टेक्स्ट को प्रतिस्थापित करता है। [getActualLabelText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#getActualLabelText) दोनों स्थितियों में परिणामी लेबल स्ट्रिंग लौटाता है। जब आप केवल दृश्य लेबल निकालना चाहते हैं, तो ऊपर दिखाए अनुसार [isVisible](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#isVisible) को अलग से जांचें।

## **एक अक्ष से लेबल दूरी सेट करें**

[setLabelOffset](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#setLabelOffset) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच दूरी नियंत्रित करें। यह मूल्य अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा पॉइंट के साथ जुड़े लेबल के बजाय श्रेणी अक्ष लेबल को प्रभावित करती है।

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

पाई चार्ट पर, स्पेसिंग बेहतर करने और लीडर लाइनों के लिए जगह बनाने हेतु डेटा लेबल स्थितियों को समायोजित करें।

यह उदाहरण पहले डेटा पॉइंट का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और [setX](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#setX) और [setY](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabel/#setY) का उपयोग करके उसके क्षैतिज और ऊर्ध्वाधर ऑफ़सेट को समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**भरे हुए चार्ट्स में डेटा लेबल के ओवरलैप को कैसे रोकें?**  
स्वचालित लेबल प्लेसमेंट, लीडर लाइन्स और फ़ॉन्ट आकार घटाकर संयोजन करें; यदि आवश्यक हो तो कुछ फ़ील्ड (जैसे श्रेणी) को छिपाएँ या केवल अत्यधिक मानों या प्रमुख बिंदुओं के लिए लेबल दिखाएँ।

**शून्य, नकारात्मक या खाली मानों के लिए केवल लेबल को कैसे अक्षम करें?**  
लेबल सक्षम करने से पहले डेटा पॉइंट्स को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक या अनुपलब्ध मानों के लिए डिस्प्ले बंद कर दें।

**PDF/चित्रों में निर्यात करते समय एकसमान लेबल शैली कैसे सुनिश्चित करें?**  
फ़ॉन्ट फैAMILY और आकार स्पष्ट रूप से सेट करें और रेंडरिंग पर्यावरण में फ़ॉन्ट उपलब्ध है यह पुष्टि करें ताकि फ़ॉलबैक न हो।