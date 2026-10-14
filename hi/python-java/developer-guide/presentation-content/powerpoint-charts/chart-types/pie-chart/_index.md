---
title: Python के माध्यम से Java का उपयोग करके प्रस्तुतियों में पाई चार्ट को कस्टमाइज़ करें
linktitle: पाई चार्ट
type: docs
url: /hi/python-java/pie-chart/
keywords:
- पाई चार्ट
- चार्ट प्रबंधित करें
- चार्ट कस्टमाइज़ करें
- चार्ट विकल्प
- चार्ट सेटिंग्स
- प्लॉट विकल्प
- स्लाइस रंग
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Python के माध्यम से Java में पाई चार्ट बनाएं और कस्टमाइज़ करें। द्वितीयक प्लॉट कॉन्फ़िगर करें, डेटा लेबल दिखाएँ, और PowerPoint में स्वचालित स्लाइस रंग लागू करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पाई चार्ट्स के साथ काम करने के तरीके को समझाता है। यह Pie of Pie और Bar of Pie चार्ट्स के लिए द्वितीयक प्लॉट विकल्पों को कॉन्फ़िगर करने तथा मानक पाई चार्ट के लिए स्वचालित स्लाइस रंगीकरण सक्षम करने को दिखाता है।

उदाहरण चार्ट अनुकूलन कार्यों पर केंद्रित हैं जैसे स्लाइड में चार्ट जोड़ना, श्रृंखला और लेबल सेटिंग्स को समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से बदलना, और अपडेटेड प्रस्तुति को सहेजना।

## **Pie of Pie और Bar of Pie चार्ट्स के लिए द्वितीयक प्लॉट विकल्प**

Aspose.Slides for Python via Java Pie of Pie और Bar of Pie चार्ट्स के लिए द्वितीयक प्लॉट विकल्पों का समर्थन करता है। ये विकल्प द्वितीयक प्लॉट का आकार और दो प्लॉट्स के बीच डेटा पॉइंट्स को कैसे विभाजित किया जाता है, नियंत्रित करते हैं।

निम्न उदाहरण नई प्रस्तुति में एक Pie of Pie चार्ट बनाता है और डेटा पॉइंट मानों को लेबल के रूप में प्रदर्शित करता है। The [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) मेथड द्वितीयक प्लॉट का आकार मुख्य प्लॉट के 149% पर सेट करता है। [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) प्रतिशत-आधारित विभाजन चुनता है, और [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) थ्रेशहोल्ड को 53% पर सेट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # मान दिखाएँ और द्वितीयक प्लॉट को कॉन्फ़िगर करें।
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **द्वितीयक प्लॉट के लिए श्रेणियों का चयन**

जब आप द्वितीयक प्लॉट में विशिष्ट श्रेणियों को उनके प्रतिशत मानों की परवाह किए बिना समूहित करना चाहते हैं, तब कस्टम विभाजन का उपयोग करें। उदाहरण के लिए, एक बिक्री रिपोर्ट में Online और Events को साथ दिखाया जा सकता है ताकि पाठक इन दो चैनलों की तुलना कर सकें, भले ही वे कुल बिक्री का 35% और 10% हों।

कॉल करें [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) को [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) के साथ और बिंदुओं को [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) के माध्यम से चुनें। संग्रह का [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) मेथड सीरीज़ में शून्य‑आधारित इंडेक्स स्वीकार करता है; डेटा पॉइंट ऑब्जेक्ट जोड़ने के लिए [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) का उपयोग करें। इस उदाहरण में, इंडेक्स 1 Online को चुनता है, और इंडेक्स 3 का पॉइंट Events को चुनता है। Partners को भी अस्थायी रूप से जोड़ा गया है, फिर [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem) का उपयोग करके बहिष्कृत किया गया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # डिफ़ॉल्ट डेटा को चैनल के अनुसार बिक्री डेटा से बदलें।
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Online को उसके शून्य‑आधारित इंडेक्स द्वारा और Events को उसके डेटा पॉइंट ऑब्जेक्ट द्वारा चुनें।
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Partners को चयन से बाहर करें बिना उसके स्रोत डेटा को हटाए।
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) और Events (10) द्वितीयक प्लॉट में अलग-अलग स्लाइस के रूप में दिखाई देते हैं। प्राथमिक प्लॉट में, वे 45 मान वाले एक संयुक्त स्लाइस द्वारा दर्शाए जाते हैं, साथ ही Retail (40) और Partners (15) भी। कस्टम चयन से Partners को हटाने से वह प्राथमिक प्लॉट में बना रहता है; यह श्रेणी या उसके मान को चार्ट के स्रोत डेटा से नहीं हटाता।

निम्न चित्र PowerPoint में सहेजी गई प्रस्तुति को दर्शाता है:
![द्वितीयक प्लॉट में Online और Events के साथ Pie of Pie चार्ट और प्राथमिक प्लॉट में उनका संयुक्त मान 45](pie_of_pie_custom.png)

## **पाई चार्ट स्लाइस के स्वचालित रंग सेट करें**

Aspose.Slides for Python via Java पाई चार्ट स्लाइसों को स्वचालित रूप से विभिन्न रंग असाइन कर सकता है। निम्न उदाहरण केंद्रित शीर्षक के साथ एक पाई चार्ट बनाता है और डिफ़ॉल्ट डेटा को तीन त्रैमासिक श्रेणियों और उनके मानों से बदलता है। [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) मेथड 20, 50, और 30 मानों को लेबल के रूप में दिखाता है, जबकि [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) प्रत्येक स्लाइस के लिए अलग रंग सक्षम करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # केंद्रित चार्ट शीर्षक जोड़ें।
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # पहले कार्यपत्रक का उपयोग करके डिफ़ॉल्ट डेटा को बदलें।
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # मान दिखाएँ और स्लाइसों को विभिन्न रंग असाइन करें।
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**क्या Pie of Pie और Bar of Pie विविधताएँ समर्थित हैं?**

हाँ, लाइब्रेरी [supports](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) पाई चार्ट्स के लिए द्वितीयक प्लॉट को समर्थन देती है, जिसमें Pie of Pie और Bar of Pie प्रकार शामिल हैं।

**क्या मैं केवल चार्ट को एक छवि (उदाहरण के लिए, PNG) के रूप में निर्यात कर सकता हूँ?**

हाँ, आप पूरे प्रस्तुतीकरण को निर्यात किए बिना [export the chart itself as an image](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (जैसे PNG) को निर्यात कर सकते हैं।