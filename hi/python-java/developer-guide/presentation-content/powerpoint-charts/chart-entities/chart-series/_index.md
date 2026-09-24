---
title: Python में प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं का प्रबंधन
linktitle: डेटा श्रृंखला
type: docs
url: /hi/python-java/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रृंखला नाम
- डेटा बिंदु
- वर्कबुक कोशिका
- श्रृंखला गैप
- नकारात्मक मान
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके प्रस्तुतियों में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक कोशिकाओं, फॉर्मेटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को कैसे प्रबंधित करें, यह जानें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/) संबंधित मानों का एक सेट दर्शाता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/) एक या अधिक वर्कबुक कोशिकाओं को संदर्भित करता है। [ChartCategory](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स लेबल्स या समूह मान प्रदान करते हैं जो श्रृंखलाओं द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, श्रेणियां और बिंदु मान [ChartDataCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, न कि केवल प्रदर्शन पाठ के रूप में संग्रहीत।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, कॉलम 0 को श्रेणी नामों के लिए, और शेष कोशिकाओं को श्रृंखला मूल्यों के लिए उपयोग करती है। [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#getCell) को पास किए गए वर्कशीट, पंक्ति और कॉलम इंडेक्स शून्य-आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मानना नहीं चाहिए कि प्रत्येक मौजूदा चार्ट इसका उपयोग करता है। किसी लोडेड प्रेजेंटेशन के लिए, वर्कबुक मूल्यों को बदलने से पहले श्रृंखला, श्रेणियां और डेटा बिंदुओं द्वारा संदर्भित कोशिकाओं की जाँच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्तर होते हैं:

- श्रृंखला-स्तर की सेटिंग्स, जैसे [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getFormat), एक श्रृंखला में सभी बिंदुओं के लिए डिफ़ॉल्ट दिखावट प्रदान करती हैं।
- डेटा-बिंदु सेटिंग्स, जैसे [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getFormat), एक बिंदु के लिए श्रृंखला की दिखावट को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/) से संबंधित हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसे विकल्प सेट करने की आवश्यकता हो, तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से समूह तक पहुंचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल नहीं सेट किया जाता, तो चार्ट शैली और थीम स्वचालित दिखावट निर्धारित करती है। जब दोनों, श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद हों, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता प्राप्त करती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getOverlap) 2D चार्ट में बार या कॉलम के ओवरलैप प्रतिशत को -100 से 100 प्रतिशत तक रिपोर्ट करता है। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल-पढ़ने योग्य प्रोजेक्शन है। उस समूह में प्रत्येक संगत श्रृंखला को अपडेट करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दर्शाते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहले श्रृंखला को शामिल करने वाले समूह के लिए ओवरलैप सेट करता है:

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

    # नया चार्ट नमूना श्रृंखलाएं, श्रेणियां और मान शामिल करता है।
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

पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करने के लिए [ChartSeries.getFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getFormat) का उपयोग करें। यदि किसी बिंदु के पास पहले से ही स्पष्ट फ़िल है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को ओवरराइड करती है।

निम्न उदाहरण पहली श्रृंखला पर ठोस नीला फ़िल लागू करता है:

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

## **श्रृंखला का नाम बदलें**

एक श्रृंखला का नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाए गए डिफ़ॉल्ट वर्कबुक में, कोशिका B1 पंक्ति 0, कॉलम 1 पर स्थित है और पहली श्रृंखला का नाम रखती है। निम्न उदाहरण में नामित वेरिएबल्स इस संरचना को स्पष्ट बनाते हैं:

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

आप [ChartSeries.getName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getName) द्वारा पहले से संदर्भित कोशिका को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशिष्ट पंक्ति और कॉलम को मानने से बचाता है:

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

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) श्रृंखला इंडेक्स और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नई फ़िल असाइन नहीं करता।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

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

डिफ़ॉल्ट चार्ट शैली के लिए उदाहरण आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **एक चार्ट श्रृंखला के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मानों को एक अलग फ़िल के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इनवर्शन सक्षम करें, और नकारात्मक मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

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

आप एक बिंदु के लिए इनवर्शन को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) के माध्यम से सक्षम कर सकते हैं। निम्न उदाहरण में श्रृंखला के लिए इनवर्शन अक्षम है और केवल चयनित बिंदु के लिए सक्षम है। बिंदु को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव स्पष्ट दिखे:

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

## **एक विशिष्ट डेटा बिंदु मान को साफ़ करें**

एक बिंदु को खाली करने के लिए, उसकी बैकिंग वर्कबुक कोशिका को `None` सेट करें, जबकि अन्य बिंदुओं को नहीं हटाएँ। कॉलम चार्ट के लिए, प्लॉटेड मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से उपलब्ध है। डेटा बिंदु समान श्रेणी स्थिति पर रहता है, लेकिन चार्ट उसकी मान को खाली मानता है, जैसा कि चार्ट की खाली-मान सेटिंग्स निर्धारित करती हैं।

निम्न उदाहरण पहली श्रृंखला में केवल दूसरा बिंदु साफ़ करता है:

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

स्कैटर चार्ट अलग-अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट आकार की कोशिका भी उपयोग करता है। उस कोशिका को साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदुओं को रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapointcollection/#clear) को कॉल न करें, क्योंकि यह मेथड संग्रह से सभी डेटा बिंदु हटा देगा।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

एक खाली वर्कबुक कोशिका अनुपलब्ध डेटा को दर्शाती है; `0` वाली कोशिका ज्ञात संख्यात्मक मान को दर्शाती है। किसी कोशिका को खाली करने के लिए [ChartDataCell.setValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#setValue) को `None` के साथ कॉल करें। शून्य मान हमेशा शून्य बना रहता है, भले ही खाली-कोशिका सेटिंग कुछ भी हो।

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#setDisplayBlanksAs) का उपयोग करके निर्धारित करें कि चार्ट खाली कोशिकाओं को कैसे दिखाएगा। यह सेटिंग पूरे चार्ट पर लागू होती है। यह खाली मानों को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक कोशिका को शून्य या इंटरपोलेटेड मान से भरने के।

निम्न स्व-निहित उदाहरण एक लाइन चार्ट एक श्रृंखला के साथ बनाता है, दिन 3 के मान को साफ़ करता है, और प्रत्येक मोड के साथ समान चार्ट को सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/) शीट 0, कॉलम 0 को श्रेणी लेबल और कॉलम 1 को मान के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रखता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    # Day 3 को वास्तव में खाली छोड़ें, जबकि इसकी श्रेणी और डेटा बिंदु को बनाए रखें।
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले निर्धारित मोड को संग्रहीत करती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, इच्छित मोड असाइन करें और प्रस्तुति को एक बार सहेजें, मोड पर लूप न करें।

नीचे तुलना दिखाती है कि सभी तीन फ़ाइलों में डेटा समान है। प्रत्येक मामले में वर्कबुक में दिन 3 खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दृश्य प्रभाव चार्ट प्रकार पर निर्भर करता है। एक लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने की अनुमति देता है। बार और कॉलम चार्ट में कनेक्ट करने वाली रेखा नहीं होती, इसलिए `Span` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को नहीं बना सकता; एक गायब कॉलम और शून्य-ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी तरह, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। यह न मानें कि प्रत्येक चार्ट प्रकार के लिए तीन अलग परिणाम होंगे; अपने उपयोग किए गए प्रकार के लिए आउटपुट जाँचें।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई आसन्न बार या कॉलम क्लस्टर के बीच का अंतराल है, जो बार या कॉलम चौड़ाई के प्रतिशत के रूप में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि व्यक्तिगत श्रृंखला से। समूह के लिए एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। बड़ा मान क्लस्टर के बीच अधिक जगह बनाता है; छोटा मान उन्हें घना बना देता है।

निम्न उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

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

**कौन से चार्ट प्रकार डेटा श्रृंखलाओं का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/charttype/) एनोमरेशन द्वारा प्रतिनिधित्व किए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट श्रेणियां और मान उपयोग करते हैं, स्कैटर चार्ट X और Y मान उपयोग करते हैं, और बबल चार्ट बबल आकार जोड़ता है। श्रृंखला प्रकार से मेल खाती डेटा-बिंदु निर्माण विधि का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसे विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

एक [ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/) संगत श्रृंखलाओं को रखता है जो समूह-स्तरीय प्लॉटिंग सेटिंग्स साझा करते हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला से पहुँचा गया समूह सभी श्रृंखलाओं को आवश्यक नहीं कि बदल दे।

**क्या नया बना चार्ट डिफ़ॉल्ट डेटा रखता है?**

हां। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addChart) नमूना श्रृंखलाएं, श्रेणियां और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक कोशिकाओं से कैसे जुड़े हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा-बिंदु मान एक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/) में कोशिकाओं को संदर्भित करते हैं। किसी संदर्भित कोशिका को बदलने से सम्बंधित चार्ट तत्व अपडेट हो जाता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला-मान पंक्तियों को संरेखित रखें ताकि प्रत्येक बिंदु इच्छित श्रेणी के नीचे प्लॉट हो।

**मैं पूरी श्रृंखला के बजाय एक बिंदु कैसे साफ़ करूं?**

संबंधित मान कोशिका को `None` सेट करें ताकि बिंदु का श्रेणी स्थान खाली बिंदु के रूप में बनी रहे। केवल पूरी श्रृंखला के सभी बिंदुओं को हटाने के लिए ही [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapointcollection/#clear) का उपयोग करें। यदि आप श्रेणियां भी हटाते हैं, तो सभी श्रृंखलाओं को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**

परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#setDisplayBlanksAs) में कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट खाली को गैप, शून्य मान या निकटवर्ती बिंदुओं को जोड़कर प्रदर्शित कर सकते हैं। अपनी प्रस्तुति में अनुपस्थित डेटा के अर्थ के अनुसार सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखिए **[खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)**।

**नकारात्मक मान कैसे फ़ॉर्मेट होते हैं?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#setInvertIfNegative) कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) से प्राप्त रंग असाइन करें। आप एकल बिंदु के लिए व्यवहार को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) से ओवरराइड कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मेट किए गए हों तो कौन सा फ़ॉर्मेट जीतता है?**

स्पष्ट डेटा-बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, जब श्रृंखला फ़ॉर्मेट परिभाषित नहीं हो, स्वचालित चार्ट शैली और थीम का उपयोग करते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करती हैं और बिंदु-स्तर फ़ॉर्मेटिंग को ओवरराइड नहीं करतीं।

**एक चार्ट में अधिकतम कितनी श्रृंखलाएं हो सकती हैं?**

Aspose.Slides कोई अलग फ़िक्स्ड श्रृंखला-गणना सीमा नहीं लगाता। व्यावहारिक सीमा प्रस्तुति फ़ाइल प्रतिबंधों, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट पठनीयता पर निर्भर करती है।

**जब कॉलम बहुत करीब या बहुत दूर हों तो मुझे क्या बदलना चाहिए?**

उचित पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। क्लस्टर के बीच की जगह बढ़ाने के लिए मान बढ़ाएं, या क्लस्टर को करीब लाने के लिए मान घटाएं।