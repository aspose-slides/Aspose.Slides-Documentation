---
title: पायथन में प्रस्तुतिकरण चार्ट में ट्रेंड लाइनों को जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/python-java/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- एक्स्पोनेन्शियल ट्रेंड लाइन
- रैखिक ट्रेंड लाइन
- लॉगारिदमिक ट्रेंड लाइन
- मूविंग औसत ट्रेंड लाइन
- पोलीनॉमियल ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "PowerPoint चार्ट में Aspose.Slides के साथ पायथन के लिए जावा के माध्यम से ट्रेंड लाइनों को शीघ्रता से जोड़ें और अनुकूलित करें — दर्शकों को जोड़ने के लिए एक व्यावहारिक गाइड।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतिकरण चार्ट में ट्रेंड लाइनों को जोड़ने का तरीका समझाता है। यह दर्शाता है कि चार्ट कैसे बनाया जाए, चार्ट श्रृंखला में ट्रेंड लाइनों को जोड़ा जाए, और एक्स्पोनेन्शियल, रैखिक, लॉगरिदमिक, मूविंग औसत, पोलीनॉमियल और पावर सहित कई ट्रेंड लाइन प्रकारों के साथ काम किया जाए।

यह यह भी बताता है कि लाइन आकार डालकर चार्ट में एक कस्टम लाइन कैसे जोड़ी जाती है, और एक छोटा FAQ शामिल करता है जिसमें फॉरवर्ड और बैकवर्ड ट्रेंड लाइन प्रोजेक्शन मानों के बारे में तथा PDF या SVG में निर्यात के दौरान तथा चार्ट को छवि के रूप में रेंडर करने पर ट्रेंड लाइनों की संरक्षा के बारे में बताया गया है।

## **ट्रेंड लाइन जोड़ें**

उपयोग करें [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) एक ट्रेंड लाइन को चार्ट श्रृंखला में जोड़ने के लिए, और उसका प्रकार [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/) से चुनें। उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा है और प्रत्येक तीन श्रृंखलाओं में दो ट्रेंड लाइनों को जोड़ता है।

एक्स्पोनेन्शियल ट्रेंड लाइन अपनी समीकरण और R‑squared मान को [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) और [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue) के द्वारा छिपाती है, जबकि रैखिक ट्रेंड लाइन लाल होती है। लॉगरिदमिक ट्रेंड लाइन एक कस्टम लेबल के लिए [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) का उपयोग करती है। मूविंग औसत एक तीन डेटा पॉइंट्स के [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) और एक कस्टम [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName) का उपयोग करता है।

पोलीनॉमियल ट्रेंड लाइन का क्रम तीन है, जिसे [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) से सेट किया जाता है और एक वर्ग को आगे बढ़ाते हुए [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward) से विस्तारित किया जाता है। पावर ट्रेंड लाइन को एक वर्ग पीछे ले जाने के लिए [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward) से विस्तारित किया जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ट्रेंड लाइन इंटरसेप्ट सेट करें**

उपयोग करें [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) एक ट्रेंड लाइन के Y मान को X = 0 पर स्थिर करने के लिए। यह सेटिंग रैखिक, एक्स्पोनेन्शियल और पोलीनॉमियल ट्रेंड लाइनों के लिए समर्थित है।

उदाहरण के लिए, उत्पादन लागत मॉडल को ज्ञात स्थिर लागत 100 से शुरू करने की आवश्यकता हो सकती है, भले ही शून्य से अलग उत्पादन मात्रा पर माप अलग आधाररेखा का सुझाव देते हों। रैखिक ट्रेंड लाइन के लिए, इंटरसेप्ट फिक्स करने से समीकरण `y = ax + b` को `b = 100` पर प्रतिबंधित किया जाता है; ढलान उस प्रतिबंध के तहत डेटा के साथ फिट होती है। यह केवल पहले से फिट की गई लाइन को स्थानांतरित नहीं करता। धुरी पार करने की सेटिंग्स यह नियंत्रित करती हैं कि चार्ट धुरियां कहाँ मिलती हैं, न कि फिटेड ट्रेंड लाइन के गुणांक को।

निम्नलिखित उदाहरण 1 से 4 तक की उत्पादन मात्राओं और 170, 200, 230 और 260 की लागतों के साथ एक स्कैटर (XY) चार्ट बनाता है। यह चार्ट को डिफ़ॉल्ट स्वचालित इंटरसेप्ट के साथ सहेजता है, इंटरसेप्ट को 100 पर सेट करता है, और दूसरी PPTX सहेजता है। दो फ़ाइलें केवल इंटरसेप्ट सेटिंग में भिन्न होती हैं। ट्रेंड लाइन अपना समीकरण प्रदर्शित करती है और X = 0 तक वापस विस्तारित होती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

स्वचालित गणना के साथ, ये डेटा `y = 30x + 140` उत्पन्न करते हैं। इंटरसेप्ट को 100 पर सेट करने से लगभग `y = 43.33x + 100` प्राप्त होता है: शून्य पर फिटेड मान ज्ञात आधाररेखा से मेल खाता है, जबकि लाइन अब प्रत्येक डेटा पॉइंट से नहीं गुजरती।

| स्वचालित इंटरसेप्ट | 100 का निश्चित इंटरसेप्ट |
| --- | --- |
| ![स्वचालित रूप से गणना किया गया इंटरसेप्ट 140 वाला रैखिक ट्रेंड लाइन](intercept-automatic.png) | ![स्थिर इंटरसेप्ट 100 वाला रैखिक ट्रेंड लाइन](intercept-fixed.png) |

दोनों छवियाँ समान डेटा और धुरी स्केल का उपयोग करती हैं। ट्रेंड लाइनों को X = 0 तक वापस विस्तारित किया गया है ताकि उनका इंटरसेप्ट दिखाया जा सके।

डिफ़ॉल्ट रूप से, [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) `NaN` लौटाता है, जो शून्य नहीं बल्कि अनिर्दिष्ट इंटरसेप्ट को दर्शाता है। फिर इंटरसेप्ट डेटा से स्वचालित रूप से गणना किया जाता है।

## **कस्टम लाइन जोड़ें**

एक कस्टम लाइन वह आकार है जो चार्ट के ऊपर खींचा जाता है, न कि श्रृंखला डेटा से गणना की गई ट्रेंड लाइन। यह उदाहरण [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) का उपयोग करके चार्ट के ऊपर स्लाइड पर एक क्षैतिज रेखा जोड़ता है। रेखा की स्थिति स्लाइड निर्देशांक में बिंदुओं में मापी जाती है, इसलिए यह चार्ट के बाएं किनारे से शुरू होती है और चार्ट के मध्य में स्थित होती है। इसकी चौड़ाई चार्ट की चौड़ाई के बराबर होती है। [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) मेथड ठोस लाल रंग लागू करने के लिए लाइन फ़ॉर्मेट तक पहुंच प्रदान करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**ट्रेंड लाइन के लिए 'फ़ॉरवर्ड' और 'बैकवर्ड' का क्या अर्थ है?**

ये ट्रेंड लाइन की आगे/पीछे प्रोजेक्ट की गई लंबाइयाँ हैं: स्कैटर (XY) चार्ट के लिए — धुरी इकाइयों में; गैर‑स्कैटर चार्ट के लिए — वर्गों की संख्या में। केवल गैर‑नकारात्मक मानों की अनुमति है।

**क्या प्रस्तुतीकरण को PDF या SVG में निर्यात करने पर, या स्लाइड को छवि में रेंडर करने पर ट्रेंड लाइन संरक्षित रहती है?**

हाँ। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/) या [SVG](/slides/hi/python-java/render-a-slide-as-an-svg-image/) में बदलता है और चार्ट को छवियों में रेंडर करता है; ट्रेंड लाइन्स, चार्ट का हिस्सा होने के नाते, इन क्रियाओं के दौरान संरक्षित रहती हैं। एक मेथड भी उपलब्ध है जिससे [चार्ट की छवि निर्यात करें](/slides/hi/python-java/create-shape-thumbnails/) स्वयं किया जा सकता है।