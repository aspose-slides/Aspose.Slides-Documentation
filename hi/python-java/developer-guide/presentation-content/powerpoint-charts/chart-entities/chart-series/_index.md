---
title: Python में प्रस्तुतियों में चार्ट डेटा श्रृंखलाएँ प्रबंधित करें
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
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्रस्तुतियों में चार्ट श्रृंखलाएँ, डेटा बिंदु, वर्कबुक सेल्स, फ़ॉर्मेटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को प्रबंधित करना सीखें।"
---
## **परिचय**

एक चार्ट अपने प्लॉट किए गए मानों को वर्कबुक सेल्स में या सीधे संख्यात्मक लिटरल के रूप में संग्रहीत कर सकता है। एक [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) संबंधित मानों के एक सेट का प्रतिनिधित्व करता है, और प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) उस श्रृंखला में एक बिंदु का प्रतिनिधित्व करता है। [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स श्रृंखला द्वारा साझा किए गए लेबल या समूह मान प्रदान करते हैं। डिफ़ॉल्ट डेटा के साथ बनाए गए चार्टों में, श्रृंखला नाम, श्रेणियाँ और बिंदु मान चार्ट वर्कबुक से [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स का उपयोग करते हैं।

एक सामान्य वर्गीकरण चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, स्तंभ 0 को वर्गीकरण नामों के लिए, और शेष कोशिकाओं को श्रृंखला मानों के लिए उपयोग करता है। [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) को पास किए गए शीट, पंक्ति और स्तंभ अनुक्रमणिकाएँ शून्य‑आधारित होती हैं। यह व्यवस्था तब उपयोगी है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मान कर न चलें कि प्रत्येक मौजूदा चार्ट इसका उपयोग करता है। लोडेड प्रेज़ेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, वर्गीकरण और डेटा पॉइंट द्वारा संदर्भित कोशिकाओं की जाँच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्तर होते हैं:

- श्रृंखला‑स्तर सेटिंग्स, जैसे कि [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे कि [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), एक बिंदु के लिए श्रृंखला रूप को ओवरराइड करती हैं।
- समूह सेटिंग्स संगत श्रृंखलाओं पर लागू होती हैं जो समान [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) से संबंधित होती हैं। जब आपको ओवरलैप या गैप विड्थ जैसी विकल्प सेट करने की आवश्यकता हो, तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल नहीं सेट किया गया हो, तो चार्ट शैली और थीम स्वचालित रूप से रूप निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद होते हैं, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिये प्राथमिकता रखती है।

![चार्ट-सीरीज़-पावरपॉइंट](chart-series-powerpoint.png)

क्लस्टर सिलेंडर चार्ट के लिए, देखें कि कैसे [3D श्रृंखला प्रकार या बार आकार बदलना](/slides/hi/python-java/3d-chart/#change-the-3d-series-type-and-bar-shape) प्रथम श्रृंखला को प्रभावित करता है।

## **संख्यात्मक लिटरल का उपयोग करके श्रृंखला मान सेट करें**

जब श्रृंखला मान एप्लिकेशन डेटा या गणनाओं से आते हैं और कार्यपत्रक सेल संदर्भों की आवश्यकता नहीं होती, तो संख्यात्मक लिटरल का उपयोग करें। प्रत्येक बिंदु के [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) परिणाम को [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble) के माध्यम से असाइन करने से पहले [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) को [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) के साथ कॉल करें।

कलेक्शन सेटिंग उस श्रृंखला में सभी बिंदु मानों के स्रोत प्रकार को नियंत्रित करती है। प्रत्येक बिंदु मान की [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) मेथड चयनित प्रकार को रिपोर्ट करती है; कलेक्शन सेटिंग के माध्यम से इसे बदलें। `Worksheet` के साथ, संदर्भित सेल तक पहुँचने के लिए [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) का उपयोग करें। `DoubleLiterals` के साथ, संख्या को सीधे पढ़ने या लिखने के लिए [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) या `setAsLiteralDouble` का उपयोग करें।

निम्न उदाहरण एक कॉलम चार्ट बनाता है जिसमें डिफ़ॉल्ट श्रृंखला और वर्गीकरण होते हैं, फिर पहले श्रृंखला के मौजूदा बिंदुओं को 10, 20 आदि के गणना किए हुए मान असाइन करता है। यह प्रेज़ेंटेशन को सहेजता है, पुनः खोलता है, और संग्रहीत मान प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

बिंदु मान स्रोत प्रकार [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) से अलग है, जो चार्ट के आंतरिक या बाह्य वर्कबुक कॉन्फ़िगरेशन को पहचानता है। संख्यात्मक लिटरल का उपयोग करने से स्वचालित रूप से एम्बेडेड वर्कबुक हटता नहीं है। इस उदाहरण में, वर्कबुक वर्गीकरण लेबल, श्रृंखला नाम और अन्य श्रृंखलाओं के लिये उपलब्ध रहती है। वर्कबुक प्रबंधन के लिये देखें [Chart Workbook](/slides/hi/python-java/chart-workbook/)।

स्कैटर और बबल चार्ट के लिये, [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) और [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) का उपयोग करके क्रमशः [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) और [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue) के स्रोत चुनें। बबल चार्ट additionally [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) का प्रयोग [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize) के लिये करता है। प्रत्येक लागू स्रोत को `DoubleLiterals` पर सेट करें, फिर उस मान के `setAsLiteralDouble` मेथड के माध्यम से संख्याएँ असाइन करें।

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) बताता है कि 2D चार्ट में बार या कॉलम कितनी प्रतिशत ओवरलैप करते हैं, -100 से 100 % तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल पढ़ने योग्य प्रतिबिंब है। सभी संगत श्रृंखलाओं को अपडेट करने के लिये [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; इसका संयोजन चार्ट में असंबंधित श्रृंखला समूहों पर कोई प्रभाव नहीं पड़ता।

निम्न उदाहरण पहले श्रृंखला को सम्मिलित करने वाले समूह के लिये ओवरलैप सेट करता है:

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

    # नया चार्ट नमूना श्रृंखलाएँ, वर्गीकरण और मान शामिल करता है।
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![श्रृंखला ओवरलैप](series_overlap.png)

## **श्रृंखला फ़िल रंग बदलें**

पूरी श्रृंखला के लिये डिफ़ॉल्ट फ़िल सेट करने हेतु [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) का उपयोग करें। यदि किसी बिंदु का फ़िल पहले से स्पष्ट रूप से सेट है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस बिंदु के लिये श्रृंखला फ़िल को ओवरराइड करती है।

निम्न उदाहरण पहले श्रृंखला पर ठोस नीला फ़िल लागू करता है:

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

![श्रृंखला रंग](series_color.png)

## **श्रृंखला नाम बदलें**

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिये डिफ़ॉल्ट वर्कबुक में, सेल B1 (पंक्ति 0, स्तंभ 1) पहला श्रृंखला नाम रखती है। नीचे के उदाहरण में नामित वेरिएबल्स इस संरचना को स्पष्ट करते हैं:

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

आप [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशिष्ट पंक्ति या स्तंभ को मानने से बचता है:

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

![श्रृंखला नाम](series_name.png)

### **कई कोशिकाओं से नाम वाली श्रृंखला बनाएं**

जब उत्पाद नाम और रिपोर्टिंग अवधि अलग-अलग वर्कबुक कोशिकाओं में संग्रहीत होते हैं, तो संयुक्त श्रृंखला नाम उपयोगी होता है। उदाहरण के लिये, आप B1 में `Product A` और C1 में `2026` को मिलाकर एक ही श्रृंखला नाम बना सकते हैं, जबकि दोनों भाग स्रोत कोशिकाओं से जुड़े रहते हैं।

[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) का उपयोग करके नाम रेंज प्राप्त करें, फिर उस कलेक्शन को [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) को पास करें। `skipHiddenCells` आर्ग्यूमेंट नियंत्रित करता है कि छिपी हुई कोशिकाएँ शामिल हों या नहीं: `True` उन्हें बाहर करता है, `False` उन्हें शामिल करता है। इस उदाहरण में `False` का प्रयोग करके नाम रेंज में प्रत्येक कोशिका को शामिल किया गया है।

निम्न उदाहरण एक प्रेज़ेंटेशन बनाता है जिसमें एक श्रृंखला और दो डेटा पॉइंट होते हैं। कोशिकाएँ B1:C1 केवल श्रृंखला नाम देती हैं; A2:A3 वर्गीकरण लेबल देती हैं, और B2:B3 संख्यात्मक मान देती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # इन दोनों कोशिकाओं से श्रृंखला का नाम प्राप्त होता है।
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # अलग-अलग कोशिकाओं से वर्गीकरण और संख्यात्मक डेटा बिंदु प्राप्त होते हैं।
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणामी श्रृंखला नाम `Product A 2026` है, दो सेल मानों के बीच एक स्पेस के साथ। लेजेंड इसे दो स्तंभों के लिये एक ही प्रविष्टि के रूप में दिखाता है। नीचे की छवि परिणाम दर्शाती है:

![उत्तरी और दक्षिणी मानों तथा संयोजित श्रृंखला नाम Product A 2026 के साथ कॉलम चार्ट](composite_series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) श्रृंखला अनुक्रमांक और चार्ट शैली से गणना किए गए रंग को लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं होती। मेथड को कॉल करने से केवल गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

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

डिफ़ॉल्ट चार्ट शैली के लिये उदाहरण आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **एक चार्ट श्रृंखला के लिये इन्वर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिये, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मानों को अलग फ़िल के साथ दिखा सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इनवर्ज़न सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शन रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। शीट पंक्ति 0 में श्रृंखला नाम, स्तंभ 0 में वर्गीकरण नाम, और स्तंभ 1 में मान होते हैं:

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

![इनवर्टेड ठोस फ़िल रंग](inverted_solid_fill_color.png)

आप एक बिंदु के लिये इनवर्ज़न को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) के जरिए सक्षम कर सकते हैं। नीचे के उदाहरण में, श्रृंखला के लिये इनवर्ज़न निष्क्रिय है और केवल चयनित बिंदु के लिये सक्रिय किया गया है। बिंदु को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिखे:

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

## **विशिष्ट डेटा पॉइंट मान साफ़ करें**

एक बिंदु को खाली करने के लिये, उसके बैकिंग वर्कबुक सेल को `None` सेट करें, जबकि अन्य बिंदु बरकरार रहें। कॉलम चार्ट में, प्लॉट किया गया मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से उपलब्ध है। डेटा पॉइंट वही वर्गीकरण स्थिति पर रहता है, पर चार्ट उस मान को खाली मान जैसा ट्रीट करता है।

निम्न उदाहरण पहले श्रृंखला के दूसरे बिंदु को ही साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाओं का प्रयोग करते हैं, और बबल चार्ट additionally आकार कोशिका का उपयोग करता है। केवल वह सेल साफ़ करें जो आप हटाना चाहते हैं। यदि आप अन्य बिंदु रखना चाहते हैं तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) को न बुलाएँ, क्योंकि यह मेथड सभी डेटा पॉइंट को कलेक्शन से हटाता है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

छिपी हुई कोशिकाएँ जिनमें मान होते हैं, उन्हें खाली कोशिकाओं से अलग माना जाता है। छिपी हुई पंक्तियों और स्तंभों से डेटा शामिल या बहिष्कृत करने के लिये देखें [Hidden Rows and Columns से डेटा शामिल करें](/slides/hi/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपस्थित डेटा दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। किसी सेल को खाली करने के लिये [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) को `None` पास करें। शून्य मान सेटिंग चाहे जो भी हो, शून्य बना रहेगा।

खाली कोशिकाओं को चार्ट कैसे दिखाए, यह चुनने के लिये [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) का उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है। यह खाली कोशिकाओं को शून्य या इंटरपोलेटेड मान से भरने के बिना प्लॉट व्यवहार को बदलती है।

निम्न स्व‑निहित उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, Day 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ एक ही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं। [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) शीट 0, स्तंभ 0 को वर्गीकरण लेबल के लिये, और स्तंभ 1 को मान के लिये उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

प्रत्येक आउटपुट फ़ाइल को सहेजते समय मोड का नाम दिया जाता है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिये, इच्छित मोड सेट करें और प्रेज़ेंटेशन को एक बार सहेजें।

नीचे तुलना दर्शाती है कि सभी तीन फ़ाइलों में एक ही डेटा कैसे दिखता है। Day 3 हर केस में वर्कबुक में खाली है:

![लाइन चार्ट जिसमें समान डेटा: Gap लाइन को Day 3 पर तोड़ता है, Zero लाइन को शून्य तक गिराता है, और Span Day 2 को Day 4 से जोड़ता है।](display_blanks_as.png)

दृश्यमान प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में एक गुम श्रेणी के ऊपर जोड़ने के लिये कोई लाइन नहीं होती, इसलिए `Span` उपरोक्त जैसा कनेक्टिंग सेगमेंट नहीं बना सकता; एक गुम कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिखाई दे सकता है। इसी प्रकार, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। प्रत्येक चार्ट प्रकार में तीन अलग-अलग परिणाम की उम्मीद न करें; अपने उपयोग के प्रकार के लिये आउटपुट की जाँच करें।

## **श्रृंखला गैप विड्थ सेट करें**

गैप विड्थ समान बार या कॉलम क्लस्टर के बीच की दूरी है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत में दर्शाया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, ना कि व्यक्तिगत श्रृंखला से। समूह के लिये एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। बड़ा मान क्लस्टर के बीच अधिक जगह बनाता है; छोटा मान उन्हें सघन करता है।

निम्न उदाहरण गैप विड्थ बदलता है और केवल अंतिम प्रेज़ेंटेशन को सहेजता है:

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

![गैप विड्थ](gap_width.png)

## **श्रृंखला रेखाएँ दिखाएँ या छिपाएँ**

श्रृंखला रेखाएँ चार्ट के संबंधित भागों को दृश्य रूप से जोड़ती हैं। समर्थित स्टैक्ड बार और ऑफ‑पाई चार्ट में उन्हें दिखाने या छिपाने के लिये [ChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSeriesLines) का उपयोग करें। दो‑आयामी स्टैक्ड बार और कॉलम चार्ट में, वे श्रेणियों के पार स्टैक सीमा को जोड़ती हैं। पाई ऑफ़ पाई और बार ऑफ़ पाई चार्ट में, वे मुख्य प्लॉट को द्वितीयक प्लॉट से जोड़ती हैं। यह सेटिंग अन्य चार्ट प्रकारों के लिये सामान्य कनेक्टर नहीं है।

समूह तक पहुँचने के लिये [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) का उपयोग करें। यह सेटिंग समूह के प्रत्येक श्रृंखला पर लागू होती है। [ChartSeries.hasSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#hasSeriesLines) केवल पढ़ने योग्य है और पैरेंट समूह की सेटिंग को दर्शाता है; इसे अपडेट करने के लिये समूह के सेट्टर को कॉल करें।

निम्न उदाहरण एक [PieOfPie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#PieOfPie) चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा होता है। यह श्रृंखला रेखाएँ सक्षम और फिर निष्क्रिय करके दो प्रेज़ेंटेशन सहेजता है, तुलना के लिये।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400)
    series = chart.getChartData().getSeries().get_Item(0)
    series_group = series.getParentSeriesGroup()

    series_group.setSeriesLines(True)
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx)

    series_group.setSeriesLines(False)
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| श्रृंखला रेखाएँ सक्षम | श्रृंखला रेखाएँ निष्क्रिय |
| --- | --- |
| ![श्रृंखला रेखाएँ सक्षम पाई ऑफ़ पाई चार्ट](series_lines_enabled.png) | ![श्रृंखला रेखाएँ निष्क्रिय पाई ऑफ़ पाई चार्ट](series_lines_disabled.png) |
| दो रेखाएँ मुख्य पाई को द्वितीयक पाई से जोड़ती हैं। | दोनों पाई दिखाई देते हैं, लेकिन कनेक्टिंग रेखाएँ छिपी होती हैं। |

श्रृंखला रेखाएँ डेटा लेबल लीडर रेखाओं से अलग होती हैं, जो लेबल को उनके डेटा बिंदुओं से जोड़ती हैं; ग्रिडलाइन, जो चार्ट अक्षों पर अंतराल को चिह्नित करती हैं; और लाइन चार्ट की रेखाएँ, जो डेटा मानों को दर्शाती हैं। यह सेटिंग उन तत्वों को नियंत्रित नहीं करती।

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन‑से चार्ट प्रकार डेटा श्रृंखला को समर्थन देते हैं?**

[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) enumeration द्वारा प्रदर्शित सभी चार्ट प्रकार डेटा उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं में मूल्य संरचना या सेटिंग्स समान नहीं हो सकती। उदाहरण के लिये, वर्गीकरण चार्ट में वर्गीकरण और मान होते हैं, स्कैटर चार्ट में X और Y मान, और बबल चार्ट में बबल आकार जोड़ते हैं। डेटा‑पॉइंट निर्माण विधि का चयन श्रृंखला प्रकार के अनुसार करें। ओवरलैप और गैप विड्थ जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) में संगत श्रृंखलाएँ होती हैं जो समूह‑स्तर के प्लॉट सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को आवश्यक रूप से बदल नहीं सकता।

**क्या नए बनाए गए चार्ट में डिफ़ॉल्ट डेटा होता है?**

हाँ। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) नमूना श्रृंखलाएँ, वर्गीकरण और मान बनाता है। आप इन कोशिकाओं को संपादित कर सकते हैं या पूर्णतः कस्टम डेटा सेट जोड़ने से पहले श्रृंखला एवं वर्गीकरण कलेक्शन को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट वर्कबुक कोशिकाओं से कैसे जुड़ते हैं?**

श्रृंखला नाम, वर्गीकरण लेबल और डेटा‑पॉइंट मान [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) में कोशिकाओं को संदर्भित करते हैं। किसी संदर्भित कोशिका को बदलने से संबंधित चार्ट तत्व अपडेट होते हैं। कस्टम डेटा बनाते समय, सुनिश्चित करें कि वर्गीकरण पंक्तियाँ और श्रृंखला‑मान पंक्तियाँ संरेखित हों ताकि प्रत्येक बिंदु इच्छित वर्गीकरण के तहत प्लॉट हो।

**एक श्रृंखला के बजाय एक बिंदु कैसे साफ़ करूँ?**

`None` सेट करके संबंधित मान कोशिका को खाली रखें, जिससे बिंदु की वर्गीकरण स्थिति बनी रहती है। केवल पूरी श्रृंखला हटाने के लिये [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) न उपयोग करें, क्योंकि यह सभी बिंदुओं को कलेक्शन से हटाता है।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**

परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) द्वारा निर्धारित सेटिंग पर निर्भर करता है। समर्थित चार्ट खाली को गैप, शून्य मान या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। अपनी प्रस्तुति में अनुपलब्ध डेटा के अर्थ से मेल खाने वाला सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिये देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)।

**नकारात्मक मानों का फ़ॉर्मेट क्या है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिये, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) को कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) से प्राप्त रंग सेट करें। आप व्यक्तिगत बिंदु के लिये [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) से व्यवहार को ओवरराइड कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मेटेड हों, तो कौन जीतता है?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस बिंदु के लिये प्राथमिकता रखती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप विड्थ लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर के फ़ॉर्मेट ओवरराइड नहीं होतीं।

**क्या किसी चार्ट में श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides कोई अलग‑से‑स्थिर श्रृंखला‑गणना सीमा नहीं लगाता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल प्रतिबंध, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट की पठनीयता उपयोगी सीमा तय करती है।

**जब कॉलम बहुत करीब या बहुत दूर हों, तो क्या बदलूँ?**

उचित पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) को कॉल करें। मान बढ़ाकर क्लस्टर के बीच की दूरी बढ़ाएँ, या घटाकर उन्हें करीब लाएँ।