---
title: Python में प्रस्तुति चार्ट के प्लॉट क्षेत्रों को अनुकूलित करें
linktitle: प्लॉट एरिया
type: docs
url: /hi/python-java/chart-plot-area/
keywords:
- चार्ट
- प्लॉट एरिया
- प्लॉट एरिया चौड़ाई
- प्लॉट एरिया ऊँचाई
- प्लॉट एरिया आकार
- लेआउट मोड
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में Aspose.Slides for Python via Java के साथ चार्ट प्लॉट क्षेत्रों को कैसे अनुकूलित करें, जानें। अपने स्लाइड दृश्य को सहजता से सुधारें।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट के प्लॉट क्षेत्र के साथ काम करने का तरीका दर्शाता है। यह चार्ट लेआउट को मान्य करके और फिर उसके X, Y, चौड़ाई और ऊँचाई मान पढ़कर प्लॉट क्षेत्र की वास्तविक स्थिति और आकार प्राप्त करने की प्रक्रिया समझाता है।

यह यह भी दर्शाता है कि लेआउट को हाथ से सेट करने पर प्लॉट क्षेत्र की लेआउट मोड को कैसे कॉन्फ़िगर किया जाए, जिसमें [LayoutTargetType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layouttargettype/) का उपयोग करके यह निर्धारित किया जाता है कि प्लॉट क्षेत्र का आकार उसकी आंतरिक क्षेत्र द्वारा गणना किया जाए या बाहरी क्षेत्र द्वारा, जिसमें अक्ष और अक्ष लेबल शामिल हों।

## **चार्ट प्लॉट क्षेत्र की चौड़ाई और ऊँचाई प्राप्त करें**

Aspose.Slides for Python via Java एक सरल API प्रदान करता है जिससे आप चार्ट के प्लॉट क्षेत्र की वास्तविक स्थिति और आकार पढ़ सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. पहली स्लाइड तक पहुँचें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. वास्तविक मान प्राप्त करने से पहले [Chart.validateChartLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#validateChartLayout) मेथड को कॉल करें।
1. चार्ट के शीर्ष‑बाएँ कोने के सापेक्ष चार्ट तत्व की वास्तविक X स्थिति (बाएँ) प्राप्त करें।
1. चार्ट के शीर्ष‑बाएँ कोने के सापेक्ष चार्ट तत्व की वास्तविक Y स्थिति (ऊपर) प्राप्त करें।
1. चार्ट तत्व की वास्तविक चौड़ाई प्राप्त करें।
1. चार्ट तत्व की वास्तविक ऊँचाई प्राप्त करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Presentation क्लास का एक उदाहरण बनाएं।
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **चार्ट प्लॉट क्षेत्र की लेआउट मोड सेट करें**

Aspose.Slides for Python via Java चार्ट प्लॉट क्षेत्र की लेआउट मोड सेट करने के लिए एक सरल API प्रदान करता है। [setLayoutTargetType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) और [getLayoutTargetType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) मेथड [ChartPlotArea](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartplotarea/) क्लास में उपलब्ध हैं। यदि प्लॉट क्षेत्र का लेआउट मैन्युअली परिभाषित किया गया हो, तो यह सेटिंग यह तय करती है कि प्लॉट क्षेत्र को उसकी अंदरूनी हिस्से (अक्ष और अक्ष लेबल को छोड़कर) या बाहरी हिस्से (अक्ष और अक्ष लेबल सहित) के आधार पर लेआउट किया जाए। इनमें दो संभावित मान हैं जो [LayoutTargetType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layouttargettype/) enumeration में परिभाषित हैं।

- [Inner](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layouttargettype/#Inner) यह निर्दिष्ट करता है कि प्लॉट क्षेत्र का आकार टिक मार्क्स और अक्ष लेबल को बाहर रखता है।
- [Outer](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layouttargettype/#Outer) यह निर्दिष्ट करता है कि प्लॉट क्षेत्र का आकार टिक मार्क्स और अक्ष लेबल को शामिल करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Presentation क्लास का एक उदाहरण बनाएं।
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**वास्तविक X, वास्तविक Y, वास्तविक चौड़ाई और वास्तविक ऊँचाई कौन से इकाइयों में लौटाए जाते हैं?**

पॉइंट्स में; 1 इंच = 72 पॉइंट्स। ये Aspose.Slides के निर्देशांक इकाइयाँ हैं।

**सामग्री के दृष्टिकोण से प्लॉट एरिया चार्ट एरिया से कैसे अलग है?**

प्लॉट एरिया डेटा ड्राइंग क्षेत्र है (सीरीज़, ग्रिडलाइन, ट्रेंडलाइन आदि); चार्ट एरिया में आसपास के तत्व (शीर्षक, लेजेंड आदि) शामिल होते हैं। 3D चार्ट में, प्लॉट एरिया में दीवारें/फ़्लोर और अक्ष भी शामिल होते हैं।

**जब लेआउट मैन्युअल हो तो प्लॉट एरिया के X, Y, चौड़ाई और ऊँचाई को कैसे व्याख्यायित किया जाता है?**

वे चार्ट के कुल आकार के अंश (0‑1) होते हैं; इस मोड में, ऑटो‑पोजिशनिंग अक्षम हो जाता है और आपने जो अंश सेट किए हैं, उनका उपयोग होता है।

**लेजेंड जोड़ने या लेजेंड को स्थानांतरित करने के बाद प्लॉट एरिया की स्थिति क्यों बदल गई?**

लेजेंड चार्ट एरिया के बाहर प्लॉट एरिया में बैठता है, लेकिन लेआउट और उपलब्ध स्थान को प्रभावित करता है, इसलिए ऑटो‑पोजिशनिंग के प्रभाव में प्लॉट एरिया शिफ्ट हो सकता है। (यह PowerPoint चार्ट का मानक व्यवहार है।)