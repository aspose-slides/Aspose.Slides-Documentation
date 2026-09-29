---
title: प्रेजेंटेशन में Python के साथ चार्ट डेटा श्रृंखला को प्रबंधित करें
linktitle: डेटा श्रृंखला
type: docs
url: /hi/python-java/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रृंखला नाम
- डेटा बिंदु
- वर्कबुक सेल
- श्रृंखला गैप
- नकारात्मक मान
- PowerPoint
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्रेजेंटेशन में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक सेल, फ़ॉर्मेटिंग, ओवरलैप, गैप विथ और नकारात्मक मानों को कैसे प्रबंधित करें सीखें।"
---
## **परिचय**

एक चार्ट अपने प्लॉट किए गए डेटा को एक चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/) एक या अधिक वर्कबुक सेल्स को संदर्भित करता है। [ChartCategory](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartcategory/) वस्तुएँ लेबल या समूह मान प्रदान करती हैं जो श्रृंखला द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, श्रेणियाँ और बिंदु मान [ChartDataCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/) वस्तुओं से जुड़े होते हैं, न कि केवल प्रदर्शित पाठ के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफॉल्ट वर्कबुक में पंक्ति 0 श्रृंखला नामों के लिये, स्तंभ 0 श्रेणी नामों के लिये, और शेष सेल्स श्रृंखला मानों के लिये उपयोग होते हैं। [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#getCell) को पास किए जाने वाले वर्कशीट, पंक्ति और स्तंभ सूचकांक शून्य‑आधारित होते हैं। यह लेआउٹ डिफॉल्ट डेटा के साथ चार्ट बनाने पर उपयोगी है, लेकिन यह मानना सही नहीं है कि प्रत्येक मौजूदा चार्ट इसका उपयोग करता है। लोड किए गए प्रेजेंटेशन के लिये, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियों और डेटा बिंदुओं द्वारा संदर्भित सेल्स की जाँच करें।

चार्ट सेटिंग्स के तीन अलग‑अलग दायरे होते हैं:

- श्रृंखला‑स्तर की सेटिंग्स, जैसे कि [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getFormat), एक श्रृंखला में सभी बिंदुओं के लिये डिफॉल्ट रूप प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे कि [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getFormat), एक बिंदु के लिये श्रृंखला की रूपरेखा को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/) से संबंधित होती हैं। जब आपको ओवरलैप या गैप‑विथ जैसी विकल्प सेट करने की आवश्यकता हो तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल नहीं सेट किया गया हो, तो चार्ट शैली और थीम स्वचालित रूप से स्वरूप निर्धारित करती है। जब दोनों—श्रृंखला और बिंदु—फ़ॉर्मेटिंग मौजूद होते हैं, तो बिंदु की फ़ॉर्मेटिंग उस बिंदु के लिये प्राथमिकता लेती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैپ सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getOverlap) 2D चार्ट में बार या कॉलम के ओवरलैप को प्रतिशत के रूप में दर्शाता है, -100 से 100 % तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने‑योग्य प्रतिबिंब है। सभी संगत श्रृंखलाओं को अद्यतन करने के लिये [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबद्ध श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहले श्रृंखला को शामिल करने वाले समूह के लिये ओवरलैप सेट करता है:

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

        # नया चार्ट नमूना श्रृंखलाएँ, श्रेणियां और मान शामिल करता है।
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![The series overlap](series_overlap.png)

## **श्रृंखला फ़िल रंग बदलें**

पूरी श्रृंखला के लिये डिफॉल्ट फ़िल सेट करने के लिये [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getFormat) का प्रयोग करें। यदि किसी बिंदु का फ़िल पहले से स्पष्ट रूप से निर्धारित है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस बिंदु के लिये श्रृंखला फ़िल को ओवरराइड करती है।

निम्न उदाहरण पहले श्रृंखला को ठोस नीला फ़िल लागू करता है:

```python
import jpype
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

![The color of the series](series_color.png)

## **श्रृंखला नाम बदलें**

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लीजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के लिये निर्मित डिफॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, स्तंभ 1 पर स्थित है और पहली श्रृंखला का नाम रखता है। नीचे के उदाहरण में नामित चर इस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [ChartSeries.getName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getName) द्वारा पहले से संदर्भित सेल को भी अद्यतन कर सकते हैं। यह तरीका यह मानने से बचाता है कि मौजूदा चार्ट में कोई विशेष पंक्ति और स्तंभ मौजूद है:

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

![The series name](series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) श्रृंखला सूचकांक और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। यह विधि गणना किया गया रंग पढ़ती है; यह नया फ़िल असाइन नहीं करती।

निम्न उदाहरण प्रत्येक डिफॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

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

डिफॉल्ट चार्ट शैली के लिये उदाहरण आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **एक चार्ट श्रृंखला के लिये इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिये, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित कर सकता है। सामान्य श्रृंखला फ़िल को ठोस सेट करें, इनवर्ज़न सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से असाइन करें। वर्कबुक में नकारात्मक संख्याएँ अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्न उदाहरण डिफॉल्ट चार्ट डेटा को एक श्रृंखला से बदल देता है। वर्कशीट की पंक्ति 0 में श्रृंखला नाम, स्तंभ 0 में श्रेणी नाम, और स्तंभ 1 में मान होते हैं:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

आप [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) के माध्यम से एक बिंदु के लिये इनवर्ज़न सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिये इनवर्ज़न अक्षम है और केवल चयनित बिंदु के लिये सक्षम किया गया है। प्रभाव को दिखाने के लिये बिंदु को नकारात्मक मान भी दिया गया है:

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

## **एक विशिष्ट डेटा बिंदु मान साफ़ करें**

एक बिंदु को अन्य बिंदुओं को हटाए बिना खाली बनाने के लिये, उसके बैकिंग वर्कबुक सेल को `None` सेट करें। कॉलम चार्ट में, प्लॉट किया गया मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से प्राप्त किया जाता है। डेटा बिंदु वही श्रेणी स्थिति बनाए रखता है, लेकिन चार्ट उसकी मान को ब्लैंक मान सेटिंग के अनुसार खाली मान लेता है।

निम्न उदाहरण पहली श्रृंखला के दूसरे बिंदु को ही साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट अतिरिक्त आकार सेल का उपयोग करते हैं। केवल वह सेल साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदु बनाए रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapointcollection/#clear) को न बुलाएँ, क्योंकि यह विधि संग्रह से सभी बिंदु हटाती है।

## **खाली सेल्स के प्रदर्शन को नियंत्रित करें**

छिपे हुए सेल्स जिनमें मान हों, वे खाली सेल्स से अलग होते हैं। छिपी हुई वर्कशीट पंक्तियों और स्तंभों से डेटा को शामिल या बाहर करने के लिये, देखें [Include Data from Hidden Rows and Columns](/slides/hi/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपस्थित डेटा को दर्शाता है; `0` वाले सेल को ज्ञात संख्यात्मक मान माना जाता है। किसी सेल को खाली करने के लिये [ChartDataCell.setValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#setValue) को `None` के साथ कॉल करें। एक संख्यात्मक शून्य ब्लैंक‑सेल सेटिंग के बावजूद शून्य ही बना रहता है।

खाली सेल्स को चार्ट कैसे दिखाता है, इसे चुनने के लिये [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#setDisplayBlanksAs) का उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है। यह ब्लैंक्स को कैसे प्लॉट किया जाता है, इसे बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेशन मान से भरें।

निम्न स्वयं‑समावेशी उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 के लिये मान को साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/) वर्कशीट 0, स्तंभ 0 को श्रेणी लेबल के लिये, और स्तंभ 1 को मानों के लिये उपयोग करता है; पंक्ति 0 में श्रृंखला नाम होता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा बिंदु को बनाए रखें।
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले चयनित मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिये, इच्छित मोड असाइन करें और प्रेज़ेंटेशन को एक बार सहेजें, सभी मोड पर इटरेट न करें।

नीचे तुलना तीन फ़ाइलों में समान डेटा दिखाती है। दिन 3 प्रत्येक केस में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दिखाया गया प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को तुलना करना आसान बनाता है। बार और कॉलम चार्ट में कोई लाइन नहीं होती जिससे गायब श्रेणी के ऊपर कनेक्शन बन सके, इसलिए `Span` उपरोक्त कनेक्टिंग सेगमेंट नहीं बना सकता; एक गायब कॉलम और शून्य‑उँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर्स वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। हर चार्ट प्रकार के लिये तीन अलग‑अलग परिणामों की अपेक्षा न रखें; अपने उपयोग के प्रकार के लिये आउटपुट जाँचें।

## **श्रृंखला गैप‑विथ सेट करें**

गैप‑विथ आसन्न बार या कॉलम क्लस्टर के बीच की दूरी है, जो बार या कॉलम की चौड़ाई के प्रतिशत के रूप में व्यक्त होती है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से जुड़ी होती है, न कि व्यक्तिगत श्रृंखला से। समूह के लिये एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। बड़ा मान क्लस्टर के बीच अधिक जगह बनाता है; छोटा मान उन्हें अधिक घनिष्ठ बनाता है।

निम्न उदाहरण गैप‑विथ बदलता है और केवल अंतिम प्रेज़ेंटेशन को सहेजता है:

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

![The gap width](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन‑से चार्ट प्रकार डेटा श्रृंखला को सपोर्ट करते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/charttype/) एन्ह्यूमरेशन द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिये, श्रेणी चार्ट श्रेणियों और मानों का उपयोग करते हैं, स्कैटर चार्ट X और Y मानों का, और बबल चार्ट में बबल आकार भी जोड़ता है। डेटा‑बिंदु निर्माण विधि चुनें जो श्रृंखला प्रकार से मेल खाती हो। ओवरलैप और गैप‑विथ जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

एक [ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/) उन संगत श्रृंखलाओं को रखता है जो समूह‑स्तर की प्लॉटिंग सेटिंग्स साझा करती हैं। एक कॉम्बिनेशन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को बदल नहीं सकता।

**क्या नवीन निर्मित चार्ट में डिफॉल्ट डेटा रहता है?**

हां। डिफॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addChart) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले दोनों—श्रृंखला और श्रेणी—संग्रह को साफ़ कर सकते हैं। एक ओवरलोड भी डिफॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑बिंदु मान एक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/) में सेल्स को संदर्भित करते हैं। किसी संदर्भित सेल को बदलने से सम्बंधित चार्ट तत्व अद्यतन हो जाता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**मैं पूरी श्रृंखला की बजाय एक बिंदु कैसे साफ़ करूँ?**

संबंधित मान सेल को `None` सेट करके बिंदु की श्रेणी स्थिति को बनाए रखते हुए उसे खाली बिंदु बना दें। केवल तब [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapointcollection/#clear) का प्रयोग करें जब आप पूरी श्रृंखला के सभी बिंदु हटाना चाहते हों। यदि आप श्रेणियाँ भी हटाते हैं, तो प्रत्येक श्रृंखला को इस प्रकार अपडेट करें कि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**

परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#setDisplayBlanksAs) द्वारा कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान, या निकटवर्ती बिंदुओं को जोड़कर दिखा सकते हैं। अपनी प्रस्तुति में अनुपस्थित डेटा का अर्थ जो दिखाना चाहते हैं, उसके अनुसार सेटिंग चुनें। विस्तृत उदाहरण और दृश्य तुलना के लिये देखें **[खाली सेल्स के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)**।

**नकारात्मक मानों को कैसे फ़ॉर्मेट किया जाता है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिये, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#setInvertIfNegative) कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) द्वारा लौटाए गए रंग को सेट करें। आप [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) के माध्यम से व्यक्तिगत बिंदु के लिये व्यवहार को ओवरराइड कर सकते हैं। ये विधियाँ स्वरूपण को प्रभावित करती हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों स्वरूपित हों तो कौन‑सा स्वरूप जीतता है?**

स्पष्ट डेटा‑बिंदु स्वरूपण उस बिंदु के लिये प्राथमिकता लेता है। अन्य बिंदु स्पष्ट श्रृंखला स्वरूप या, जब श्रृंखला स्वरूप परिभाषित नहीं हो, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप‑विथ लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर की स्वरूपण ओवरराइड नहीं हैं।

**क्या कोई सीमा है कि चार्ट में कितनी श्रृंखलाएँ हो सकती हैं?**

Aspose.Slides कोई अलग‑से स्थिर श्रृंखला‑गणना सीमा नहीं लगाता। व्यावहारिक रूप से, प्रेज़ेंटेशन फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती है।

**जब कॉलम बहुत निकट या बहुत दूर हों तो क्या करें?**

संबंधित पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। मान बढ़ाएँ ताकि क्लस्टर के बीच की जगह बढ़े, या मान घटाएँ ताकि क्लस्टर एक‑दूसरे के अधिक निकट हों।