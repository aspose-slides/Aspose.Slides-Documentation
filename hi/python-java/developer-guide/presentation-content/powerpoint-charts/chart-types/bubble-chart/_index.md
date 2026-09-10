---
title: "Python का उपयोग करके प्रस्तुतियों में बबल चार्ट को अनुकूलित करें"
linktitle: "बबल चार्ट"
type: docs
url: /hi/python-java/bubble-chart/
keywords:
- "बबल चार्ट"
- "बबल आकार"
- "आकार स्केलिंग"
- "आकार प्रतिनिधित्व"
- "PowerPoint"
- "प्रस्तुति"
- "Python"
- "Java"
- "Aspose.Slides"
description: "PowerPoint में Aspose.Slides for Python via Java का उपयोग करके शक्तिशाली बबल चार्ट बनाएं और अनुकूलित करें, जिससे आप अपने डेटा विज़ुअलाइज़ेशन को आसानी से सुधार सकें।"
---
## **परिचय**

यह लेख Aspose.Slides में बबल चार्ट के साथ काम करने का तरीका दिखाता है। यह दो विशिष्ट अनुकूलन विकल्पों को कवर करता है: [setBubbleSizeScale](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) विधि के माध्यम से बबल आकार को स्केल करना और [setBubbleSizeRepresentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) विधि के माध्यम से बबल आकार मानों के प्रतिनिधित्व को नियंत्रित करना।

उदाहरण दिखाते हैं कि बबल चार्ट कैसे बनाया जाता है, उसका आकार स्केलिंग कैसे समायोजित किया जाता है, और बबल आकार प्रतिनिधित्व को चौड़ाई (width) में कैसे बदला जाता है। लेख में एक छोटा FAQ सेक्शन भी शामिल है जो “Bubble with 3-D” चार्ट प्रकार के समर्थन को स्पष्ट करता है, बताता है कि व्यावहारिक चार्ट सीमाएँ प्रदर्शन और लक्ष्य PowerPoint संस्करण पर निर्भर करती हैं, और समझाता है कि निर्यात (export) Aspose.Slides रेंडरिंग इंजन के माध्यम से चार्ट की उपस्थिति को कैसे बनाये रखता है।

## **Bubble Chart Size Scaling**
Aspose.Slides for Python via Java बबल चार्ट आकार स्केलिंग को [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale), और [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) विधियों के माध्यम से समर्थन देता है। नीचे दिया गया उदाहरण बबल आकार को स्केल करने का तरीका दर्शाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Represent Data as Bubble Chart Sizes**
विधियाँ [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) और [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) [ChartSeriesGroup](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseriesgroup/) वर्ग में उपलब्ध हैं। बबल आकार प्रतिनिधित्व यह निर्धारित करता है कि बबल चार्ट में बबल आकार मानों को कैसे प्रस्तुत किया जाता है। संभावित मान हैं [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bubblesizerepresentationtype/#Area) और [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bubblesizerepresentationtype/#Width)। [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/hi/python-java/aspose.slides/bubblesizerepresentationtype/) एन्उमरेशन डेटा को बबल चार्ट आकारों के रूप में प्रस्तुत करने के संभावित तरीकों को निर्दिष्ट करता है। नीचे दिया गया उदाहरण चौड़ाई (width) का उपयोग करके बबल आकार को प्रस्तुत करने का तरीका दिखाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**क्या “Bubble with 3-D effect” का समर्थन किया जाता है, और यह सामान्य बबल चार्ट से कैसे अलग है?**

हाँ। एक अलग चार्ट प्रकार “Bubble with 3-D” उपलब्ध है। यह बब्बलों पर 3‑डी स्टाइलिंग लागू करता है, लेकिन अतिरिक्त अक्ष (axis) नहीं जोड़ता; डेटा अभी भी X‑Y‑S (size) रहता है। यह प्रकार [chart type](https://reference.aspose.com/slides/hi/python-java/aspose.slides/charttype/) वर्ग में उपलब्ध है।

**क्या बबल चार्ट में श्रृंखला (series) और बिंदुओं (points) की संख्या पर कोई सीमा है?**

API स्तर पर कोई कठोर सीमा नहीं है; सीमाएँ प्रदर्शन और लक्ष्य PowerPoint संस्करण पर निर्भर करती हैं। पढ़ने योग्यता और रेंडरिंग गति को ध्यान में रखते हुए बिंदुओं की संख्या को उचित स्तर पर रखने की सलाह दी जाती है।

**निर्यात (PDF, छवियाँ) बबल चार्ट की उपस्थिति को कैसे प्रभावित करता है?**

समर्थित फ़ॉर्मेट्स में निर्यात करने पर चार्ट की उपस्थिति बनी रहती है; रेंडरिंग Aspose.Slides इंजन द्वारा की जाती है। रास्टर/वेक्टर फ़ॉर्मेट्स के लिए सामान्य चार्ट‑ग्राफ़िक्स रेंडरिंग नियम लागू होते हैं (रेज़ोल्यूशन, एंटी‑एलियासिंग), इसलिए प्रिंटिंग के लिए उचित DPI चुना जाना चाहिए।