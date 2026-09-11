---
title: Python के माध्यम से Java में प्रस्तुति चार्ट निर्यात
linktitle: चार्ट निर्यात
type: docs
weight: 90
url: /hi/python-java/export-chart/
keywords:
- चार्ट
- चार्ट से छवि
- चार्ट को छवि के रूप में
- चार्ट छवि निकालें
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्रस्तुति चार्ट निर्यात करना सीखें, PPT और PPTX फ़ॉर्मैट का समर्थन करता है, और किसी भी कार्यप्रवाह में रिपोर्टिंग को सहज बनाता है।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति से चार्ट को छवि के रूप में निर्यात करने की अनुमति देता है। यह लेख दिखाता है कि चार्ट से छवि कैसे प्राप्त करें और उसे सहेजें, जो तब उपयोगी होता है जब आपको PowerPoint प्रस्तुति के बाहर चार्ट विज़ुअल्स को पुन: प्रयोग करना हो।

बेसिक छवि निर्यात वर्कफ़्लो के अलावा, लेख सामान्य निर्यात‑संबंधी प्रश्नों को भी संबोधित करता है, जिसमें चार्ट सामग्री को SVG में सहेजना, रेंडरिंग विकल्पों के माध्यम से आउटपुट आकार को नियंत्रित करना, लेबल और लेजेंड की उपस्थिति को बनाए रखने के लिए फ़ॉन्ट लोड करना, और रेंडरिंग के दौरान मूल प्रस्तुति फ़ॉर्मेटिंग जैसे थीम, स्टाइल, फ़िल और इफ़ेक्ट्स को बनाए रखना शामिल है।

## **चार्ट छवि प्राप्त करें**
Aspose.Slides for Python via Java किसी विशिष्ट चार्ट की छवि निकालने का समर्थन करता है। निम्न उदाहरण दर्शाता है कि इसे कैसे किया जाए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट को रास्टर छवि के बजाय एक वेक्टर (SVG) के रूप में निर्यात कर सकता हूँ?**

हाँ। एक चार्ट एक शेप है, और इसकी सामग्री को SVG में सहेजा जा सकता है, इसके लिए आप [shape-to-SVG saving method](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#writeAsSvgToBytes) का उपयोग कर सकते हैं।

**मैं निर्यात किए गए चार्ट का सटीक आकार पिक्सेल में कैसे सेट कर सकता हूँ?**

छवि‑रेंडरिंग के ओवरलोड का उपयोग करें जो आपको आकार या स्केल निर्दिष्ट करने की अनुमति देते हैं—यह लाइब्रेरी दिए गए आयाम/स्केल के साथ ऑब्जेक्ट्स को रेंडर करने का समर्थन करती है।

**निर्यात के बाद लेबल और लेजेंड में फ़ॉन्ट गलत दिखें तो मुझे क्या करना चाहिए?**

[Load the required fonts](/slides/hi/python-java/custom-font/) के माध्यम से [FontsLoader](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsloader/) का उपयोग करें ताकि चार्ट रेंडरिंग मीट्रिक्स और टेक्स्ट उपस्थिति को बनाए रखे।

**क्या निर्यात PowerPoint थीम, स्टाइल और इफ़ेक्ट्स का सम्मान करता है?**

हाँ। Aspose.Slides का रेंडरर प्रस्तुति की फ़ॉर्मेटिंग (थीम, स्टाइल, फ़िल, इफ़ेक्ट्स) का पालन करता है, इसलिए चार्ट की उपस्थिति बनी रहती है।

**चार्ट छवियों के अलावा उपलब्ध रेंडरिंग/निर्यात क्षमताएँ कहाँ मिलेंगी?**

आउटपुट टारगेट्स के लिए [API](https://reference.aspose.com/slides/hi/python-java/aspose.slides/)/[documentation](/slides/hi/python-java/convert-powerpoint/) देखें ([PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/hi/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/hi/python-java/convert-powerpoint-to-xps/), [HTML](/slides/hi/python-java/convert-powerpoint-to-html/), आदि) और संबंधित रेंडरिंग विकल्पों को देखें।