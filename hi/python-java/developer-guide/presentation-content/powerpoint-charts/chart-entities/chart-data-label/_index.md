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
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और स्वरूपित करने के बारे में सीखें, ताकि स्लाइड्स अधिक आकर्षक बनें।"
---
## **परिचय**

चार्ट पर डेटा लेबल्स चार्ट डेटा सीरीज़ या व्यक्तिगत डेटा पॉइंट्स के विवरण दिखाते हैं। यह पाठकों को जल्दी से डेटा सीरीज़ पहचानने में मदद करता है, और चार्ट को समझना भी आसान बनाता है।

## **चार्ट डेटा लेबल्स में डेटा प्रेसिशन सेट करें**

यह Python कोड दिखाता है कि चार्ट डेटा लेबल में डेटा प्रेसिशन कैसे सेट करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **प्रतिशत को लेबल के रूप में दिखाएँ**
Aspose.Slides for Python via Java आपको प्रदर्शित चार्ट्स पर प्रतिशत लेबल सेट करने की अनुमति देता है। यह Python कोड इस ऑपरेशन को दर्शाता है:

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
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट डेटा लेबल्स के साथ प्रतिशत चिह्न सेट करें**
यह Python कोड दिखाता है कि चार्ट डेटा लेबल के लिए प्रतिशत चिह्न कैसे सेट करें:

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
    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # लाल श्रृंखला जोड़ें।
    series_cell = workbook.getCell(worksheet_index, 0, 1, "Reds")
    red_series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, value in enumerate([0.30, 0.50, 0.80, 0.65], start=1):
        data_cell = workbook.getCell(worksheet_index, row_index, 1, jpype.JDouble(value))
        red_series.getDataPoints().addDataPointForBarSeries(data_cell)

    red_series.getFormat().getFill().setFillType(FillType.Solid)
    red_series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    red_label_format = red_series.getLabels().getDefaultDataLabelFormat()
    red_label_format.setShowValue(True)
    red_label_format.setNumberFormatLinkedToSource(False)
    red_label_format.setNumberFormat("0.0%")
    red_portion_format = red_label_format.getTextFormat().getPortionFormat()
    red_portion_format.setFontHeight(10)
    red_portion_format.getFillFormat().setFillType(FillType.Solid)
    red_portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    # नीली श्रृंखला जोड़ें।
    series_cell = workbook.getCell(worksheet_index, 0, 2, "Blues")
    blue_series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, value in enumerate([0.70, 0.50, 0.20, 0.35], start=1):
        data_cell = workbook.getCell(worksheet_index, row_index, 2, jpype.JDouble(value))
        blue_series.getDataPoints().addDataPointForBarSeries(data_cell)

    blue_series.getFormat().getFill().setFillType(FillType.Solid)
    blue_series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)
    blue_label_format = blue_series.getLabels().getDefaultDataLabelFormat()
    blue_label_format.setShowValue(True)
    blue_label_format.setNumberFormatLinkedToSource(False)
    blue_label_format.setNumberFormat("0.0%")
    blue_portion_format = blue_label_format.getTextFormat().getPortionFormat()
    blue_portion_format.setFontHeight(10)
    blue_portion_format.getFillFormat().setFillType(FillType.Solid)
    blue_portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **एक अक्ष से लेबल दूरी सेट करें**
यह Python कोड दिखाता है कि जब आप अक्षों से बने चार्ट के साथ काम कर रहे हों तो श्रेणी अक्ष से लेबल दूरी कैसे सेट करें:

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

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लेबल स्थान समायोजित करें**

जब आप ऐसा चार्ट बनाते हैं जो किसी भी अक्ष पर निर्भर नहीं करता, जैसे पाई चार्ट, तो चार्ट के डेटा लेबल्स उसकी किनारी के बहुत करीब हो सकते हैं। ऐसे मामलों में, आपको डेटा लेबल का स्थान समायोजित करना चाहिए ताकि लीडर लाइन्स स्पष्ट रूप से दिखें।

यह Python कोड दिखाता है कि पाई चार्ट पर लेबल स्थान कैसे समायोजित करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं घनी चार्ट्स में डेटा लेबल्स के ओवरलैप को कैसे रोक सकता हूँ?**

ऑटोमैटिक लेबल प्लेसमेंट, लीडर लाइन्स, और छोटे फ़ॉन्ट आकार को मिलाएँ; आवश्यकता होने पर कुछ फ़ील्ड्स (जैसे श्रेणी) को छुपाएँ या केवल अत्यधिक/मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**मैं केवल शून्य, नकारात्मक, या खाली मानों के लिए लेबल कैसे अक्षम कर सकता हूँ?**

लेबल्स सक्षम करने से पहले डेटा पॉइंट्स को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक या अनुपलब्ध मानों के लिए डिस्प्ले बंद कर दें।

**PDF/छवियों में निर्यात करते समय एक सुसंगत लेबल शैली कैसे सुनिश्चित करूँ?**

फ़ॉन्ट (फ़ैमिली, आकार) को स्पष्ट रूप से सेट करें और रेंडरिंग पक्ष पर फ़ॉन्ट उपलब्ध है या नहीं, इसे जांचें ताकि फ़ॉलबैक न हो।