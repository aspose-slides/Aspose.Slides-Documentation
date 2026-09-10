---
title: Python में प्रस्तुतियों में चार्ट डेटा सीरीज़ प्रबंधित करें
linktitle: डेटा सीरीज़
type: docs
url: /hi/python-java/chart-series/
keywords:
- चार्ट सीरीज़
- सीरीज़ ओवरलैप
- सीरीज़ रंग
- सीरीज़ नाम
- डेटा बिंदु
- वर्कबुक सेल
- सीरीज़ गैप
- नकारात्मक मान
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्रस्तुतियों में चार्ट सीरीज़, डेटा बिंदु, वर्कबुक सेल, फॉर्मेटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मान को कैसे प्रबंधित करें, यह जानें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/) एक या अधिक वर्कबुक कोशिकाओं को संदर्भित करता है। [ChartCategory](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स सीरीज़ द्वारा साझा किए गए लेबल या समूह मान प्रदान करते हैं। इसलिए श्रृंखला का नाम, श्रेणियां, और बिंदु मान [ChartDataCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं न कि केवल प्रदर्शित पाठ के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए कॉलम 0, और शेष कोशिकाओं को श्रृंखला मानों के लिए उपयोग करता है। वर्कशीट, पंक्ति और कॉलम सूचकांक जो [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#getCell) को पास किए जाते हैं, शून्य-आधारित होते हैं। यह लेआउट तब उपयोगी है जब आप डिफ़ॉल्ट डेटा के साथ चार्ट बनाते हैं, लेकिन यह न मानें कि प्रत्येक मौजूदा चार्ट इसका उपयोग करता है। लोडेड प्रस्तुति के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियों और डेटा बिंदुओं द्वारा संदर्भित कोशिकाओं की जांच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- सीरीज़-स्तर सेटिंग्स, जैसे [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getFormat), एक सीरीज़ में सभी बिंदुओं के लिए डिफ़ॉल्ट उपस्थिति प्रदान करती हैं।
- डेटा-बिंदु सेटिंग्स, जैसे [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getFormat), एक बिंदु के लिए सीरीज़ की उपस्थिति को ओवरराइड करती हैं।
- ग्रुप सेटिंग्स समान [ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/) की अंतर्गत रहने वाली संगत सीरीज़ पर लागू होती हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसी विकल्प सेट करने की आवश्यकता हो, तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से समूह तक पहुंचें।

जब कोई स्पष्ट बिंदु या सीरीज़ भराव सेट नहीं किया गया हो, तब चार्ट स्टाइल और थीम स्वचालित उपस्थिति निर्धारित करते हैं। जब दोनों, सीरीज़ और बिंदु फॉर्मेटिंग मौजूद हों, तो उस बिंदु के लिए बिंदु फॉर्मेटिंग प्राधान्य लेती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट सीरीज़ ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getOverlap) 2D चार्ट में बार या कॉलम के ओवरलैप की मात्रा -100 से 100 प्रतिशत तक रिपोर्ट करता है। यह पैरेंट सीरीज़ ग्रुप पर सेटिंग का रीड-ओनली प्रोजेक्शन है। इस समूह में सभी संगत सीरीज़ को अपडेट करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो ग्रुपेड बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबंधित सीरीज़ ग्रुप को प्रभावित नहीं करता।

निम्नलिखित उदाहरण पहले सीरीज़ को शामिल करने वाले समूह के लिए ओवरलैप सेट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # नया चार्ट नमूना सीरीज़, श्रेणियां, और मान शामिल करता है।
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![सीरीज़ ओवरलैप](series_overlap.png)

## **सीरीज़ फ़िल रंग बदलें**

[ChartSeries.getFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getFormat) का उपयोग करके पूरी सीरीज़ के लिए डिफ़ॉल्ट भराव सेट करें। यदि किसी बिंदु में पहले से स्पष्ट भराव है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस बिंदु के लिए सीरीज़ भराव को ओवरराइड करता है।

निम्नलिखित उदाहरण पहली सीरीज़ पर ठोस नीला भराव लागू करता है:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![सीरीज़ का रंग](series_color.png)

## **सीरीज़ नाम बदलें**

एक सीरीज़ नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाई गई डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर स्थित है और पहली सीरीज़ का नाम रखता है। निम्नलिखित उदाहरण में नामित वेरिएबल्स इस संरचना को स्पष्ट करते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

आप [ChartSeries.getName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getName) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशेष पंक्ति और कॉलम मानने से बचाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![सीरीज़ नाम](series_name.png)

## **स्वचालित सीरीज़ भराव रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) सीरीज़ इंडेक्स और चार्ट स्टाइल से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब सीरीज़ भराव स्पष्ट रूप से निर्धारित नहीं किया गया हो। इस विधि को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया भराव असाइन नहीं करता।

निम्नलिखित उदाहरण प्रत्येक डिफ़ॉल्ट सीरीज़ के स्वचालित रंग को प्रिंट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

डिफ़ॉल्ट चार्ट स्टाइल के लिए उदाहरण आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट स्टाइल और थीम पर निर्भर करते हैं।

## **चार्ट सीरीज़ के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल सीरीज़ के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मूल्यों को अलग भराव के साथ दिखा सकता है। नियमित सीरीज़ भराव को ठोस सेट करें, इनवर्शन सक्षम करें, और नकारात्मक मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्नलिखित उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक सीरीज़ से बदलता है। वर्कशीट पंक्ति 0 में सीरीज़ नाम होता है, कॉलम 0 में श्रेणी नाम होते हैं, और कॉलम 1 में मान होते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![इनवर्टेड ठोस भराव रंग](inverted_solid_fill_color.png)

[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) के माध्यम से आप एक बिंदु के लिए इनवर्ज़न सक्षम कर सकते हैं। निम्नलिखित उदाहरण में, सीरीज़ के लिए इनवर्ज़न अक्षम है और केवल चयनित बिंदु के लिए सक्षम है। बिंदु को भी एक नकारात्मक मान असाइन किया गया है ताकि प्रभाव देखा जा सके:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **विशिष्ट डेटा बिंदु मान साफ़ करें**

एक बिंदु को अन्य बिंदुओं को हटाए बिना खाली करने के लिए, उसकी बैकिंग वर्कबुक सेल को `None` सेट करें। कॉलम चार्ट के लिए, प्लॉट किया गया मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से उपलब्ध होता है। डेटा बिंदु समान श्रेणी स्थान पर रहता है, लेकिन चार्ट अपने ब्लैंक-वैल्यू सेटिंग्स के अनुसार उस मान को खाली मानता है।

निम्नलिखित उदाहरण केवल पहली सीरीज़ में दूसरे बिंदु को साफ़ करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

स्कैटर चार्ट अलग-अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट एक आकार कोशिका भी उपयोग करता है। केवल वही कोशिका साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदुओं को रखे रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapointcollection/#clear) को कॉल न करें, क्योंकि वह मेथड संग्रह से सभी डेटा बिंदुओं को हटा देता है।

## **सीरीज़ गैप चौड़ाई सेट करें**

गैप चौड़ाई बार या कॉलम क्लस्टर के बीच की जगह है, जो बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त की जाती है। ओवरलैप की तरह, यह एक सीरीज़ के बजाय पैरेंट सीरीज़ ग्रुप से संबंधित है। समूह के लिए एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। बड़ा मान क्लस्टर के बीच अधिक जगह बनाता है; छोटा मान उन्हें अधिक घना बनाता है।

निम्नलिखित उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुति को सेव करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![गैप चौड़ाई](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन‑से चार्ट प्रकार डेटा सीरीज़ का समर्थन करते हैं?**  
सभी चार्ट प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/charttype/) एनेमैरेशन द्वारा दर्शाए गए हैं, चार्ट डेटा का उपयोग करते हैं, लेकिन उनकी सीरीज़ सभी के पास समान मान संरचना या सेटिंग्स नहीं होतीं। उदाहरण के लिए, श्रेणी चार्ट श्रेणियां और मान उपयोग करते हैं, स्कैटर चार्ट X और Y मान उपयोग करते हैं, और बबल चार्ट बबल आकार जोड़ते हैं। वह डेटा‑बिंदु निर्माण विधि उपयोग करें जो सीरीज़ प्रकार से मेल खाती हो। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम ग्रुप पर लागू होते हैं।

**चार्ट सीरीज़ ग्रुप क्या है?**  
[ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/) में संगत सीरीज़ होते हैं जो ग्रुप‑स्तर के प्लॉटिंग सेटिंग्स साझा करते हैं। एक कॉम्बिनेशन चार्ट में एक से अधिक ग्रुप हो सकते हैं, इसलिए एक सीरीज़ के माध्यम से पहुँचा गया ग्रुप बदलने से आवश्यक नहीं कि चार्ट की सभी सीरीज़ बदल जाएँ।

**क्या नया बनाया गया चार्ट डिफ़ॉल्ट डेटा रखता है?**  
हां। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addChart) नमूना सीरीज़, श्रेणियां और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी कस्टम डेटा सेट जोड़ने से पहले सीरीज़ और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक कोशिकाओं से कैसे जुड़े होते हैं?**  
सीरीज़ नाम, श्रेणी लेबल, और डेटा‑बिंदु मान [ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/) में कोशिकाओं का संदर्भ देते हैं। संदर्भित कोशिका को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और सीरीज़‑मान पंक्तियों को इस तरह संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**पूरी सीरीज़ के बजाय एक बिंदु कैसे साफ़ करें?**  
संबंधित मान कोशिका को `None` सेट करें ताकि बिंदु की श्रेणी स्थिति एक खाली बिंदु के रूप में बनी रहे। [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapointcollection/#clear) का उपयोग केवल तब करें जब आप उस सीरीज़ के सभी बिंदुओं को हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो सभी सीरीज़ को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**  
परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#setDisplayBlanksAs) द्वारा कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट खाली क्षेत्रों को गैप, शून्य मान या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। वह सेटिंग चुनें जो आपकी प्रस्तुति में गायब डेटा के अर्थ से मेल खाती हो।

**नकारात्मक मान कैसे फॉर्मेट किए जाते हैं?**  
समर्थित बार, कॉलम और बबल सीरीज़ के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#setInvertIfNegative) को कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) द्वारा लौटाए गए रंग को सेट करें। आप एक व्यक्तिगत बिंदु के लिए व्यवहार को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) से ओवरराइड कर सकते हैं। ये मेथड केवल फॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब दोनों सीरीज़ और बिंदु फॉर्मेट किए जाएँ, तो कौन‑सा फॉर्मेट जीतता है?**  
स्पष्ट डेटा‑बिंदु फॉर्मेटिंग उस बिंदु के लिए प्राधान्य लेती है। अन्य बिंदु स्पष्ट सीरीज़ फॉर्मेट का उपयोग जारी रखते हैं या जब सीरीज़ फॉर्मेट परिभाषित नहीं है तो स्वचालित चार्ट स्टाइल और थीम का। ओवरलैप और गैप चौड़ाई जैसी ग्रुप सेटिंग्स लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर की फॉर्मेटिंग ओवरराइड नहीं हैं।

**क्या किसी चार्ट में शामिल की जा सकने वाली सीरीज़ की संख्या पर कोई सीमा है?**  
Aspose.Slides कोई अलग स्थिर सीरीज़‑गणना सीमा नहीं लगाता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल सीमाओं, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट पढ़नेयोग्यता एक उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत पास या बहुत दूर हो तो मुझे क्या बदलना चाहिए?**  
उचित पैरेंट सीरीज़ ग्रुप पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। क्लस्टर के बीच की जगह बढ़ाने के लिए मान बढ़ाएँ, या क्लस्टर को एक‑दूसरे के करीब लाने के लिए इसे घटाएँ।