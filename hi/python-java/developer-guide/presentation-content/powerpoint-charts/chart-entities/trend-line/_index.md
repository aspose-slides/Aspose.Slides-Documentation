---
title: Python में प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/python-java/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- घातांक ट्रेंड लाइन
- रैखिक ट्रेंड लाइन
- लघुगणकीय ट्रेंड लाइन
- चल औसत ट्रेंड लाइन
- बहुपद ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "PowerPoint चार्ट में Aspose.Slides for Python via Java के साथ तेजी से ट्रेंड लाइन्स जोड़ें और अनुकूलित करें — आपके दर्शकों को आकर्षित करने के लिए एक व्यावहारिक गाइड।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ने का तरीका समझाता है। यह दिखाता है कि चार्ट कैसे बनाया जा सकता है, चार्ट श्रृंखला में ट्रेंड लाइन्स कैसे जोड़ी जाएँ, और कई प्रकार की ट्रेंड लाइन्स के साथ कैसे काम किया जाए, जिसमें घातांक, रैखिक, लघुगणकीय, चल औसत, बहुपद और पावर शामिल हैं।

यह यह भी बताता है कि लाइन शेप डालकर चार्ट में कस्टम लाइन कैसे जोड़ी जाए, और इसमें अग्र और पश्च ट्रेंड लाइन प्रक्षेपण मानों तथा PDF या SVG में निर्यात या चार्ट को छवि के रूप में रेंडर करते समय ट्रेंड लाइन्स बरकरार रहती हैं या नहीं, के बारे में एक संक्षिप्त FAQ शामिल है।

## **ट्रेंड लाइन जोड़ें**

Aspose.Slides for Python via Java विभिन्न चार्ट ट्रेंड लाइन्स को प्रबंधित करने के लिए एक सरल API प्रदान करता है:

1. एक [प्रस्तुति](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. डिफ़ॉल्ट डेटा और वांछित प्रकार के साथ एक चार्ट जोड़ें (इस उदाहरण में [ChartType.ClusteredColumn](https://reference.aspose.com/slides/hi/python-java/aspose.slides/charttype/#ClusteredColumn) का उपयोग किया गया है)।
1. चार्ट श्रृंखला 1 में एक घातांक ट्रेंड लाइन जोड़ें।
1. चार्ट श्रृंखला 1 में एक रैखिक ट्रेंड लाइन जोड़ें।
1. चार्ट श्रृंखला 2 में एक लघुगणकीय ट्रेंड लाइन जोड़ें।
1. चार्ट श्रृंखला 2 में एक चल औसत ट्रेंड लाइन जोड़ें।
1. चार्ट श्रृंखला 3 में एक बहुपद ट्रेंड लाइन जोड़ें।
1. चार्ट श्रृंखला 3 में एक पावर ट्रेंड लाइन जोड़ें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल में लिखें।

निम्नलिखित कोड ट्रेंड लाइन्स के साथ एक चार्ट बनाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Presentation क्लास का एक उदाहरण बनाएं।
presentation = Presentation()
try:
    # एक क्लस्टर्ड कॉलम चार्ट बनाएं।
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # चार्ट सीरीज़ 1 में एक घातांक ट्रेंड लाइन जोड़ें।
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # चार्ट सीरीज़ 1 में एक रैखिक ट्रेंड लाइन जोड़ें।
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # चार्ट सीरीज़ 2 में एक लघुगणकीय ट्रेंड लाइन जोड़ें।
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # चार्ट सीरीज़ 2 में एक चल औसत ट्रेंड लाइन जोड़ें।
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # चार्ट सीरीज़ 3 में एक बहुपद ट्रेंड लाइन जोड़ें।
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # चार्ट सीरीज़ 3 में एक पावर ट्रेंड लाइन जोड़ें।
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # प्रस्तुति को सहेजें।
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **कस्टम लाइन जोड़ें**

Aspose.Slides for Python via Java चार्ट में कस्टम लाइन्स जोड़ने के लिए एक सरल API प्रदान करता है। चयनित स्लाइड पर एक साधारण लाइन जोड़ने के लिए, इन चरणों का पालन करें:

- एक [प्रस्तुति](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
- इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
- नया चार्ट [addChart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addChart) मेथड का उपयोग करके [ShapeCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/) क्लास से बनाएं।
- [addAutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addAutoShape) मेथड के साथ [ShapeType.Line](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#Line) का उपयोग करके एक लाइन शेप जोड़ें।
- शेप की लाइन का रंग सेट करें।
- परिवर्तित प्रस्तुति को PPTX फ़ाइल में लिखें।

निम्नलिखित कोड कस्टम लाइन के साथ एक चार्ट बनाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Presentation क्लास का एक उदाहरण बनाएं।
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**ट्रेंड लाइन में 'फॉरवर्ड' और 'बैकवर्ड' क्या मतलब रखते हैं?**

ये ट्रेंड लाइन की लंबाई हैं जो आगे या पीछे प्रोजेक्ट की गई हैं: स्कैटर (XY) चार्ट के लिए, इन्हें अक्ष इकाइयों में मापा जाता है; गैर-स्कैटर चार्ट के लिए, इन्हें श्रेणियों की संख्या में मापा जाता है। केवल गैर-नकारात्मक मान स्वीकार्य हैं।

**क्या प्रस्तुति को PDF या SVG में निर्यात करने या स्लाइड को छवि के रूप में रेंडर करने पर ट्रेंड लाइन बरकरार रहेगी?**

हां। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/hi/python-java/render-a-slide-as-an-svg-image/) में परिवर्तित करता है और चार्ट को छवियों में रेंडर करता है; ट्रेंड लाइन्स, चार्ट का हिस्सा होने के नाते, इन कार्यों के दौरान बरकरार रहती हैं। एक मेथड भी उपलब्ध है जो सीधे [चार्ट की छवि निर्यात](/slides/hi/python-java/create-shape-thumbnails/) करता है।