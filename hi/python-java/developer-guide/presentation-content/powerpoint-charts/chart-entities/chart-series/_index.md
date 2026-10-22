---
title: Python में प्रस्तुतियों में चार्ट डेटा श्रृंखला प्रबंधित करें
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
description: "Aspose.Slides for Python via Java के साथ प्रस्तुतियों में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक कोशिकाओं, फॉर्मेटिंग, ओवरलैप, गैप की चौड़ाई और नकारात्मक मानों को कैसे प्रबंधित करें सीखें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए मानों को वर्कबुक कोशिकाओं में या सीधे संख्यात्मक लिटरल्स के रूप में संग्रहीत कर सकता है। एक [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) संबंधित मानों के एक सेट का प्रतिनिधित्व करता है, और प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) उस श्रृंखला में एक बिंदु का प्रतिनिधित्व करता है। [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स लेबल या समूह मान प्रदान करते हैं जो श्रृंखलाओं द्वारा साझा किए जाते हैं। डिफ़ॉल्ट डेटा के साथ बनाए गए चार्ट्स में, श्रृंखला नाम, श्रेणियां और बिंदु मान चार्ट वर्कबुक से [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स का उपयोग करके प्राप्त होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए स्तंभ 0, और शेष कोशिकाएं श्रृंखला मानों के लिए उपयोग करती है। [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) को पास किए गए वर्कशीट, पंक्ति और स्तंभ अनुक्रमणांक शून्य-आधारित हैं। यह लेआउट डिफ़ॉल्ट डेटा वाले चार्ट बनाने पर उपयोगी है, लेकिन यह मानना नहीं चाहिए कि प्रत्येक मौजूदा चार्ट इसे उपयोग करता है। लोड किए गए प्रेज़ेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखलाओं, श्रेणियों और डेटा पॉइंट्स द्वारा संदर्भित कोशिकाओं की जाँच करें।

चार्ट सेटिंग्स के तीन अलग-अलग दायरे होते हैं:

- श्रृंखला-स्तर की सेटिंग्स, जैसे [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), एक श्रृंखला के सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), एक बिंदु के लिए श्रृंखला रूप को ओवरराइड करती हैं।
- समूह सेटिंग्स समान [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) से संबंधित संगत श्रृंखलाओं पर लागू होती हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसी विकल्प सेट करने की आवश्यकता हो, तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से समूह तक पहुंचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल नहीं निर्धारित किया गया हो, तो चार्ट शैली और थीम स्वचालित रूप से दिखावट निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु फ़ॉर्मेट मौजूद हों, तो बिंदु फ़ॉर्मेट उस बिंदु के लिए प्राथमिकता लेता है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **संख्यात्मक लिटरल्स का उपयोग करके श्रृंखला मान निर्धारित करें**

जब श्रृंखला मान एप्लिकेशन डेटा या गणनाओं से आते हैं और उन्हें वर्कशीट कोशिका संदर्भों की आवश्यकता नहीं होती, तो संख्यात्मक लिटरल्स का उपयोग करें। प्रत्येक बिंदु के [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) परिणाम को [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble) के माध्यम से असाइन करने से पहले [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) को [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) के साथ कॉल करें।

यह संग्रह सेटिंग उस श्रृंखला में सभी बिंदु मानों के स्रोत प्रकार को नियंत्रित करती है। प्रत्येक बिंदु मान का [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) मेथड चयनित प्रकार को रिपोर्ट करता है; इसे संग्रह सेटिंग के माध्यम से बदलें। `Worksheet` के साथ, संदर्भित कोशिका तक पहुँचने के लिए [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) उपयोग करें। `DoubleLiterals` के साथ, संख्या को सीधे पढ़ने या लिखने के लिए [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) या `setAsLiteralDouble` का उपयोग करें।

निम्न उदाहरण एक कॉलम चार्ट बनाता है जिसमें डिफ़ॉल्ट श्रृंखला और श्रेणियां होती हैं, फिर उसकी पहली श्रृंखला के मौजूदा बिंदुओं को क्रमशः 10, 20 आदि की गणना किए गए मान असाइन करता है। यह प्रेज़ेंटेशन को सहेजता है, पुनः खोलता है, और संग्रहीत मानों को प्रिंट करता है।

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

बिंदु मान स्रोत प्रकार [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) से अलग होता है, जो चार्ट की आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन की पहचान करता है। संख्यात्मक लिटरल्स का उपयोग करने से एम्बेडेड वर्कबुक स्वयं नहीं हटता। इस उदाहरण में, वर्कबुक श्रेणी लेबल, श्रृंखला नाम और अन्य श्रृंखलाओं के लिए उपलब्ध रहती है। वर्कबुक प्रबंधन के लिए देखें [Chart Workbook](/slides/hi/python-java/chart-workbook/)।

स्कैटर और बबल चार्ट्स के लिए, क्रमशः [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) और [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) का उपयोग करके [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) और [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue) के स्रोत चुनें। बबल चार्ट्स के लिए [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) का उपयोग करके [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize) चुनें। प्रत्येक लागू स्रोत को `DoubleLiterals` पर सेट करें, फिर उस मान के `setAsLiteralDouble` मेथड के माध्यम से संख्याएँ असाइन करें।

## **चार्ट श्रृंखला ओवरलैप निर्धारित करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी ओवरलैप करती हैं, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल पढ़ने योग्य प्रोजेक्शन है। सभी संगत श्रृंखलाओं को अपडेट करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम प्रदर्शित करते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण उस समूह के लिए ओवरलैप सेट करता है जिसमें पहली श्रृंखला सम्मिलित है:

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

    # नया चार्ट नमूना श्रृंखला, श्रेणियां और मानों को शामिल करता है।
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

पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करने के लिए [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) का उपयोग करें। यदि किसी बिंदु का पहले से स्पष्ट फ़िल है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को ओवरराइड करती है।

निम्न उदाहरण पहली श्रृंखला पर ठोस नीला फ़िल लागू करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpake.startJVM()

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

![श्रृंखला का रंग](series_color.png)

## **श्रृंखला नाम बदलें**

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाई गई डिफ़ॉल्ट वर्कबुक में, कोशिका B1 (पंक्ति 0, स्तंभ 1) पहली श्रृंखला का नाम रखती है। नीचे दिए गए उदाहरण में नामित वेरिएबल्स इस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) द्वारा पहले से संदर्भित कोशिका को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशिष्ट पंक्ति या स्तंभ को मानने से बचता है:

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

### **कई कोशिकाओं से नाम वाला श्रृंखला बनाएँ**

जब उत्पाद नाम और रिपोर्टिंग अवधि अलग-अलग वर्कबुक कोशिकाओं में संग्रहीत हों, तब संयुक्त श्रृंखला नाम उपयोगी होता है। उदाहरण के लिए, आप B1 में `Product A` और C1 में `2026` को मिलाकर एकल श्रृंखला नाम बना सकते हैं, जबकि दोनों भाग अपने स्रोत कोशिकाओं से जुड़े रहें।

नाम रेंज प्राप्त करने के लिए [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) का उपयोग करें, फिर उस संग्रह को [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) को पास करें। `skipHiddenCells` आर्ग्युमेंट यह नियंत्रित करता है कि छुपी हुई कोशिकाएँ शामिल हों या नहीं: `True` उन्हें बाहर करता है, `False` उन्हें शामिल करता है। यह उदाहरण `False` का उपयोग करके नाम रेंज की हर कोशिका को शामिल करता है।

निम्न उदाहरण एक प्रेज़ेंटेशन बनाता है जिसमें एक श्रृंखला और दो डेटा पॉइंट्स होते हैं। कोशिकाएँ B1:C1 केवल श्रृंखला नाम देती हैं; A2:A3 श्रेणी लेबल देती हैं, और B2:B3 संख्यात्मक मान देती हैं।

```python
import jpase
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

    # ये दो कोशिकाएँ श्रृंखला का नाम प्रदान करती हैं।
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # अलग-अलग कोशिकाएँ श्रेणियाँ और संख्यात्मक डेटा पॉइंट्स प्रदान करती हैं।
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

परिणामी श्रृंखला नाम `Product A 2026` है, दो कोशिका मानों के बीच एक स्पेस के साथ। लेजेंड इसे दो कॉलमों के लिए एक प्रविष्टि के रूप में दर्शाता है। नीचे छवि परिणाम को दिखाती है:

![Composite series name in legend](composite_series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) श्रृंखला अनुक्रमांक और चार्ट शैली के आधार पर गणना किया गया रंग 반환 करता है। यह वह रंग है जिसका उपयोग तब किया जाता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं है। यह मेथड गणना किए गए रंग को पढ़ता है; यह नया फ़िल नहीं असाइन करता।

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

## **चार्ट श्रृंखला के लिए इनवर्ट फ़िल रंग निर्धारित करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इनवर्जन सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शन रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। कार्यपत्रक पंक्ति 0 श्रृंखला नाम रखती है, स्तंभ 0 श्रेणी नाम, और स्तंभ 1 मान रखता है:

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

आप एक बिंदु के लिए इनवर्जन को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) के माध्यम से सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिए इनवर्जन निष्क्रिय है और केवल चयनित बिंदु के लिए सक्रिय किया गया है। बिंदु को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दृष्टिगोचर हो:

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

एक बिंदु को खाली बनाने के लिए, उसके बैकिंग वर्कबुक कोशिका को `None` सेट करें, जबकि अन्य बिंदुओं को न हटाएँ। कॉलम चार्ट के लिए, प्लॉट किया गया मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से उपलब्ध है। डेटा पॉइंट अपनी श्रेणी स्थिति में बना रहता है, लेकिन चार्ट उसकी मान को ब्लैंक मान सेटिंग के अनुसार मानता है।

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

स्कैटर चार्ट्स अलग‑अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट्स आकार कोशिका का भी उपयोग करते हैं। केवल उस कोशिका को साफ़ करें जो आप हटाना चाहते हैं। यदि आप अन्य बिंदुओं को बनाए रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) न कॉल करें, क्योंकि यह मेथड पूरी श्रृंखला के सभी डेटा पॉइंट्स को हटा देता है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

छुपी हुई कोशिकाओं में मान होते हैं, जो खाली कोशिकाओं से अलग मामला है। छुपी हुई पंक्तियों और स्तंभों से डेटा को शामिल या बाहर करने के लिए देखें [Include Data from Hidden Rows and Columns](/slides/hi/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक कोशिका अनुपलब्ध डेटा को दर्शाती है; `0` वाली कोशिका ज्ञात संख्यात्मक मान दर्शाती है। एक कोशिका को खाली बनाने के लिए [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) को `None` पास करें। संख्यात्मक शून्य ब्लैंक‑सेल सेटिंग की परवाह किए बिना शून्य ही रहता है।

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) का उपयोग करके तय करें कि चार्ट खाली कोशिकाओं को कैसे प्रदर्शित करे। यह सेटिंग पूरे चार्ट पर लागू होती है और ब्लैंक को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक कोशिका को शून्य या इंटरपोलेशन मान से भरने के।

निम्न स्व‑निर्भर उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान हटाता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) कार्यपत्रक 0, श्रेणी लेबल के लिए स्तंभ 0, और मान के लिए स्तंभ 1 का उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    # Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा पॉइंट को बनाए रखें।
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

प्रत्येक आउटपुट फ़ाइल सहेजे जाने से पहले निर्धारित मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, वांछित मोड असाइन करें और प्रेज़ेंटेशन को एक बार सहेजें, सभी मोड्स पर इटरट नहीं करें।

नीचे तुलना में तीनों फ़ाइलों में समान डेटा दिखाया गया है। दिन 3 हर मामले में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दृश्य प्रभाव चार्ट प्रकार पर निर्भर करता है। एक लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट्स में कोई लाइन नहीं होती जिससे गायब श्रेणी पर जोड़ बन सके, इसलिए `Span` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को नहीं बना सकता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। यह न मानें कि हर चार्ट प्रकार के लिए तीन अलग परिणाम मिलेंगे; उपयोग किए जा रहे प्रकार के लिए आउटपुट जाँचें।

## **श्रृंखला गैप चौड़ाई निर्धारित करें**

गैप चौड़ाई आसन्न बार या कॉलम क्लस्टर्स के बीच का अंतराल है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह का हिस्सा है, न कि व्यक्तिगत श्रृंखला का। समूह के लिए एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। बड़ा मान क्लस्टर्स के बीच अधिक स्थान बनाता है; छोटा मान उन्हें अधिक घना बनाता है।

निम्न उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रेज़ेंटेशन सहेजता है:

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

**कौन से चार्ट प्रकार डेटा श्रृंखला का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) एनेमरेशन द्वारा दर्शाए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट्स में श्रेणियां और मान होते हैं, स्कैटर चार्ट्स में X और Y मान, और बबल चार्ट्स में बबल आकार शामिल होते हैं। श्रृंखला प्रकार के अनुसार उपयुक्त डेटा‑पॉइंट निर्माण मेथड चुनें। ओवरलैप और गैप चौड़ाई जैसे विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**एक चार्ट श्रृंखला समूह क्या है?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) संगत श्रृंखलाओं को शामिल करता है जो समूह‑स्तर के प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचे गए समूह को बदलने से जरूरी नहीं कि चार्ट की सभी श्रृंखलाएं बदल जाएँ।

**क्या नया बनाया गया चार्ट डिफ़ॉल्ट डेटा रखता है?**

हां। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) नमूना श्रृंखला, श्रेणियां और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। किसी ओवरलोड का उपयोग करके डिफ़ॉल्ट डेटा के बिना भी चार्ट बनाया जा सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक कोशिकाओं से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑पॉइंट मान एक [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) की कोशिकाओं को संदर्भित करते हैं। संदर्भित कोशिका बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय, सुनिश्चित करें कि श्रेणी पंक्तियां और श्रृंखला‑मान पंक्तियां संरेखित हों ताकि प्रत्येक बिंदु इच्छित श्रेणी के नीचे प्लॉट हो।

**मैं पूरी श्रृंखला के बजाय एक बिंदु को कैसे साफ़ करूँ?**

संबंधित मान कोशिका को `None` सेट करें ताकि बिंदु की श्रेणी स्थिति खाली बिंदु के रूप में बनी रहे। केवल तब [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) का उपयोग करें जब आप पूरी श्रृंखला के सभी बिंदुओं को हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**

परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) द्वारा कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। अपनी प्रस्तुति में अनुपलब्ध डेटा के अर्थ से मेल खाने वाला सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें [Control the Display of Empty Cells](#control-the-display-of-empty-cells)।

**नकारात्मक मानों को कैसे फॉर्मेट किया जाता है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) को कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) द्वारा लौटाए गए रंग को सेट करें। आप [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) से एकल बिंदु के लिए व्यवहार को ओवरराइड कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फॉर्मेट किए गए हों तो कौन जीतता है?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर फ़ॉर्मेटिंग को ओवरराइड नहीं करतीं।

**एक चार्ट अधिकतम कितनी श्रृंखला रख सकता है?**

Aspose.Slides पर कोई अलग निरंतर श्रृंखला‑गिनती सीमा नहीं है। व्यावहारिक रूप से, प्रेज़ेंटेशन फ़ाइल की सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट की पढ़ने की योग्यता एक उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत पास-पास या बहुत दूर हों तो क्या बदलें?**

उचित पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। क्लस्टर्स के बीच स्थान बढ़ाने के लिए मान बढ़ाएँ, या उन्हें पास लाने के लिए घटाएँ।