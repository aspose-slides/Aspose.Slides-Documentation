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
- वर्कबुक सेल
- श्रृंखला गैप
- नकारात्मक मान
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्रस्तुतियों में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक सेल, फ़ॉर्मेटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को कैसे प्रबंधित करें सीखें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) एक या अधिक वर्कबुक सेल का संदर्भ देता है। [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) ऑब्जेक्ट्स लेबल या समूहित मान प्रदान करते हैं जो श्रृंखलाओं द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, श्रेणियाँ, और बिंदु मान [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, केवल प्रदर्शित पाठ के रूप में नहीं रखे जाते।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, कॉलम 0 को श्रेणी नामों के लिए, और शेष सेल्स को श्रृंखला मानों के लिए उपयोग करती है। [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) को पास किए गए वर्कशीट, पंक्ति, और कॉलम इंडेक्स शून्य-आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मानने से बचें कि हर मौजूदा चार्ट इसे उपयोग करता है। किसी लोडेड प्रस्तुति में, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियाँ, और डेटा बिंदुओं द्वारा संदर्भित सेल्स की जांच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- श्रृंखला‑स्तर की सेटिंग्स, जैसे [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), एक श्रृंखला के सभी बिंदुओं के लिए डिफ़ॉल्ट दिखावट प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), किसी एक बिंदु के लिए श्रृंखला की दिखावट को ओवरराइड करती हैं।
- समूह सेटिंग्स समान [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) में मौजूद संगत श्रृंखलाओं पर लागू होती हैं। जब आपको ओवरलैप या गैप विथ जैसी विकल्प सेट करने की ज़रूरत हो, तो [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल सेट नहीं किया गया हो, तो चार्ट शैली और थीम स्वचालित दिखावट निर्धारित करती हैं। जब दोनों, श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद हों, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है।

![चार्ट‑श्रृंखला‑पावरपॉइंट](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी हद तक ओवरलैप करते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल रीड‑ओनली प्रोजेक्शन है। उस समूह में प्रत्येक संगत श्रृंखला को अपडेट करने के लिए [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम प्रदर्शित करते हैं; यह संयोजन चार्ट में असंबद्ध श्रृंखला समूहों को प्रभावित नहीं करता।

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

    # नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ और मान शामिल करता है।
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

पूरा श्रृंखला का डिफ़ॉल्ट फ़िल सेट करने के लिए [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) का उपयोग करें। यदि किसी बिंदु का फ़िल पहले से स्पष्ट है, तो उसका [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को ओवरराइड कर देती है।

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

![श्रृंखला का रंग](series_color.png)

## **श्रृंखला का नाम बदलें**

श्रृंखला का नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाए गए डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर स्थित है और पहली श्रृंखला का नाम रखता है। नीचे के उदाहरण में नामांकित वेरिएबल्स इस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशिष्ट पंक्ति और कॉलम को मानने से बचाता है:

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

![श्रृंखला का नाम](series_name.png)

### **कई सेल्स से नाम वाली श्रृंखला बनाएं**

जब उत्पाद का नाम और रिपोर्टिंग अवधि अलग-अलग वर्कबुक सेल में संग्रहीत होते हैं, तो संयुक्त श्रृंखला नाम उपयोगी होता है। उदाहरण के लिए, आप B1 में `Product A` और C1 में `2026` को मिलाकर एकल श्रृंखला नाम बना सकते हैं, जबकि दोनों भागों को उनके स्रोत सेल्स से जुड़ा रख सकते हैं।

नाम रेंज प्राप्त करने के लिए [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) का उपयोग करें, फिर उस कलेक्शन को [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) को पास करें। `skipHiddenCells` तर्क नियंत्रित करता है कि छिपे हुए सेल शामिल किए जाएँ या नहीं: `True` उन्हें बाहर करता है, जबकि `False` शामिल करता है। यह उदाहरण `False` का उपयोग करके नाम रेंज में प्रत्येक सेल को शामिल करता है।

निम्न उदाहरण एक प्रस्तुति बनाता है जिसमें एक श्रृंखला और दो डेटा बिंदु होते हैं। सेल B1:C1 केवल श्रृंखला नाम प्रदान करते हैं; A2:A3 श्रेणी लेबल देते हैं, और B2:B3 संख्यात्मक मान देते हैं।

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

    # ये दो सेल्स श्रृंखला नाम प्रदान करती हैं।
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # अलग-अलग सेल्स श्रेणियाँ और संख्यात्मक डेटा बिंदु प्रदान करती हैं।
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

परिणामस्वरूप श्रृंखला नाम `Product A 2026` है, दो सेल मानों के बीच एक स्पेस के साथ। लेजेंड इसे दोनों कॉलम के लिए एक प्रविष्टि के रूप में दिखाता है। चित्र नीचे परिणाम दर्शाता है:

![उत्तरी और दक्षिणी मानों के साथ कॉलम चार्ट और लेजेंड में सम्मिलित श्रृंखला नाम Product A 2026](composite_series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) श्रृंखला इंडेक्स और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

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

बार, कॉलम, और बबल श्रृंखला के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इनवर्ज़न सक्षम करें, और नकारात्मक‑मान रंग को [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) के माध्यम से असाइन करें। वर्कबुक में नकारात्मक संख्याएँ अपरिवर्तित रहती हैं; केवल उनका डिस्प्ले रंग बदलता है।

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

![इनवर्टेड ठोस फ़िल रंग](inverted_solid_fill_color.png)

आप एक बिंदु के लिए इनवर्ज़न को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) द्वारा सक्षम कर सकते हैं। अगले उदाहरण में श्रृंखला के लिए इनवर्ज़न अक्षम है और केवल चयनित बिंदु के लिए सक्षम है। बिंदु को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिखाई दे:

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

एक बिंदु को खाली करने के लिए, अन्य बिंदुओं को हटाए बिना, उसकी बैकिंग वर्कबुक सेल को `None` सेट करें। कॉलम चार्ट के लिए, प्लॉट किया गया मान [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) के माध्यम से उपलब्ध है। डेटा बिंदु वही श्रेणी स्थिति बनाए रखता है, लेकिन चार्ट ब्लैंक‑वैल्यू सेटिंग के अनुसार उसका मान खाली माना जाता है।

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

स्कैटर चार्ट अलग‑अलग X और Y सेल का उपयोग करते हैं, और बबल चार्ट में आकार सेल भी होता है। केवल वह सेल साफ़ करें जो आप हटाना चाहते हैं। यदि आप अन्य बिंदु बनाए रखना चाहते हैं, तो [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) को न कॉल करें, क्योंकि यह मेथड संग्रह से सभी डेटा बिंदु हटा देता है।

## **खाली सेल्स के प्रदर्शन को नियंत्रित करें**

छिपे हुए सेल जिनमें मान हैं, वे खाली सेल से अलग मामले हैं। छिपी हुई वर्कशीट पंक्तियों और कॉलमों से डेटा को शामिल या बाहर करने के लिए देखें [Include Data from Hidden Rows and Columns](/slides/hi/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपस्थित डेटा दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। किसी सेल को खाली करने के लिए [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) को `None` के साथ कॉल करें। शून्य मान ब्लैंक‑सेल सेटिंग से अप्रभावित रहता है।

खाली सेल्स को कैसे प्रदर्शित किया जाए, यह चुनने के लिए [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) का उपयोग करें। यह सेटिंग पूरी चार्ट पर लागू होती है। यह ब्लैंक को प्लॉट करने का तरीका बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरते हुए।

निम्न स्वनिर्भर उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) वर्कशीट 0, कॉलम 0 को श्रेणी लेबल, और कॉलम 1 को मान के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रखता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले सेट किए गए मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, इच्छित मोड असाइन करें और प्रस्तुति को एक बार सहेँ, मोड्स पर क्रमबद्ध नहीं करें।

नीचे तुलना दिखाती है कि सभी तीन फ़ाइलों में समान डेटा कैसे दिखता है। हर केस में वर्कबुक में दिन 3 खाली है:

![लाइन चार्ट्स में समान डेटा: Gap दिन 3 पर लाइन टूटता है, Zero लाइन को शून्य तक गिराता है, और Span दिन 2 को दिन 4 से जोड़ता है।](display_blanks_as.png)

दिखावट प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में कोई लाइन नहीं होती जो लापता श्रेणी को जोड़ सके, इसलिए `Span` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को नहीं बना पाता; एक लापता कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। समान रूप से, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों में तीन अलग परिणाम मिलने की अपेक्षा न रखें; जिस प्रकार का आप उपयोग कर रहे हैं, उसके आउटपुट की जाँच करें।

## **श्रृंखला गैप विथ सेट करें**

गैप विथ पड़ोसी बार या कॉलम क्लस्टर्स के बीच का अंतराल है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत के रूप में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि किसी एकल श्रृंखला से। समूह के लिए एक बार [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। बड़ा मान क्लस्टर्स के बीच अधिक स्थान बनाता है; छोटा मान उन्हें घना कर देता है।

निम्न उदाहरण गैप विथ बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

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

![गैप विथ](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखलाओं का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) enumeration द्वारा दर्शाए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की मान संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट्स श्रेणियों और मानों का उपयोग करते हैं, स्कैटर चार्ट्स X और Y मानों का, और बबल चार्ट्स बबल आकार जोड़ते हैं। डेटा‑बिंदु निर्माण मेथड चुनें जो श्रृंखला प्रकार से मेल खाता हो। ओवरलैप और गैप विथ जैसी सेटिंग्स केवल संगत बार या कॉलम समूहों पर लागू होती हैं।

**चार्ट श्रृंखला समूह क्या है?**

एक [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) में संगत श्रृंखलाएँ होती हैं जो समूह‑स्तर की प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुंचा गया समूह सभी श्रृंखलाओं को अनिवार्य रूप से नहीं बदलता।

**क्या नया बनाया गया चार्ट डिफ़ॉल्ट डेटा रखता है?**

हां। डिफ़ॉल्ट रूप से, [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) नमूना श्रृंखलाएँ, श्रेणियाँ, और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑बिंदु मान एक [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) में सेल्स को संदर्भित करते हैं। किसी संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट होता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को संरेखित रखें ताकि प्रत्येक बिंदु इच्छित श्रेणी के नीचे प्लॉट हो।

**मैं पूरे श्रृंखला के बजाय एक बिंदु कैसे साफ़ करूँ?**

संबंधित मान सेल को `None` सेट करें ताकि बिंदु की श्रेणी स्थिति खाली बिंदु के रूप में बनी रहे। केवल तब [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) कॉल करें जब आप पूरे श्रृंखला के सभी बिंदु हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो प्रत्येक श्रृंखला को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदुओं को कैसे प्रदर्शित किया जाता है?**

परिणाम चार्ट प्रकार और [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) में कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट्स ब्लैंक को गैप, शून्य मूल्य, या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। अपनी प्रस्तुति में अनुपस्थित डेटा के अर्थ के अनुसार सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें [खाली सेल्स के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)।

**नकारात्मक मान कैसे फ़ॉर्मेट किए जाते हैं?**

समर्थित बार, कॉलम, और बबल श्रृंखलाओं के लिए, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) कॉल करें और [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) द्वारा लौटाए गए रंग को असाइन करें। आप व्यक्तिगत बिंदु के लिए इनवर्ज़न को [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) से ओवरराइड कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मेट किए गए हों तो कौन सा फ़ॉर्मेट जीतता है?**

स्पष्ट डेटा‑बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप विथ लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर की फ़ॉर्मेटिंग को ओवरराइड नहीं करतीं।

**क्या चार्ट में श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides कोई अलग स्थिर श्रृंखला‑गणना सीमा नहीं लगाता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट पढ़ने योग्यपन उपयोगी सीमा निर्धारित करते हैं।

**जब कॉलम बहुत करीब या बहुत दूर हों तो मुझे क्या बदलना चाहिए?**

उचित पैरेंट श्रृंखला समूह पर [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) कॉल करें। मान बढ़ाएँ ताकि क्लस्टर्स के बीच का अंतराल बढ़े, या घटाएँ ताकि क्लस्टर्स करीब आएँ।