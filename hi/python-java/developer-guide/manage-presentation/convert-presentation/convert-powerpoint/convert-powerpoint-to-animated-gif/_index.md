---
title: Python में PowerPoint प्रस्तुतियों को एनिमेटेड GIF में परिवर्तित करें
linktitle: PowerPoint से GIF
type: docs
weight: 65
url: /hi/python-java/convert-powerpoint-to-animated-gif/
keywords:
- एनिमेटेड GIF
- PowerPoint को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- PowerPoint से GIF
- प्रस्तुति को GIF में
- स्लाइड को GIF में
- PPT को GIF में
- PPTX को GIF में
- PPT को GIF के रूप में सहेजें
- PPTX को GIF के रूप में सहेजें
- PPT को GIF के रूप में निर्यात करें
- PPTX को GIF के रूप में निर्यात करें
- डिफ़ॉल्ट सेटिंग्स
- कस्टम सेटिंग्स
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint प्रस्तुतियों (PPT, PPTX) को आसानी से एनिमेटेड GIF में परिवर्तित करें। तेज, उच्च-गुणवत्ता परिणाम।"
---
## **अवलोकन**

Aspose.Slides for Python via Java आपको कुछ ही लाइनों के कोड के साथ PowerPoint प्रस्तुतियों को एनिमेटेड GIF फ़ाइलों में परिवर्तित करने की सुविधा देता है। यह वेब पेज, मैसेंजर या दस्तावेज़ों में स्लाइड सामग्री साझा करने के लिए उपयोगी है। यह लेख डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुति को निर्यात करने और [GifOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/gifoptions/) के माध्यम से फ्रेम आकार, स्लाइड देरी, और ट्रांज़िशन फ्रेम रेट को अनुकूलित करने के तरीकों को समझाता है।

## **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को एनिमेटेड GIF में परिवर्तित करें**

निम्नलिखित Python उदाहरण `pres.pptx` को लोड करता है और मानक सेटिंग्स का उपयोग करके इसे एनिमेटेड GIF के रूप में सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
GIF आउटपुट को अनुकूलित करने के लिए, सहेजते समय एक [GifOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/gifoptions/) ऑब्जेक्ट पास करें, जैसा कि नीचे दिखाया गया है।
{{% /alert %}}

## **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को एनिमेटेड GIF में परिवर्तित करें**

आउटपुट आयाम पिक्सेल में निर्दिष्ट करने के लिए [setFrameSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/gifoptions/#setFrameSize) का उपयोग करें, डिफ़ॉल्ट स्लाइड देरी मिलिसेकंड में सेट करने के लिए [setDefaultDelay](https://reference.aspose.com/slides/hi/python-java/aspose.slides/gifoptions/#setDefaultDelay), और ट्रांज़िशन फ्रेम रेट नियंत्रित करने के लिए [setTransitionFps](https://reference.aspose.com/slides/hi/python-java/aspose.slides/gifoptions/#setTransitionFps) का उपयोग करें।

निम्नलिखित उदाहरण 960 × 720 GIF को दो सेकंड की डिफ़ॉल्ट स्लाइड देरी और ट्रांज़िशन के लिए 35 फ्रेम प्रति सेकंड के साथ निर्यात करता है। डिफ़ॉल्ट देरी तब लागू होती है जब स्लाइड की advance-after समय सेट नहीं हो।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
आप Aspose के मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कनवर्टर को भी आज़मा सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि प्रस्तुति में उपयोग किए गए फ़ॉन्ट सिस्टम पर स्थापित नहीं हैं तो क्या होगा?**

गुम फ़ॉन्ट स्थापित करें या [configure fallback fonts](/slides/hi/python-java/powerpoint-fonts/)। फ़ॉन्ट प्रतिस्थापन निर्यात किए गए GIF की रूपरेखा को बदल सकता है। प्रस्तुति की डिज़ाइन से मेल खाने के लिए मूल फ़ॉन्ट उपलब्ध कराना महत्वपूर्ण है।

**क्या मैं GIF फ्रेम्स पर वॉटरमार्क ओवरले कर सकता हूँ?**

हां। निर्यात से पहले संबंधित मास्टर स्लाइड्स या व्यक्तिगत स्लाइड्स में एक अर्ध-पारदर्शी वस्तु या लोगो [Add a semi-transparent object or logo](/slides/hi/python-java/watermark/) जोड़ें। वॉटरमार्क रेंडर किए गए स्लाइड सामग्री का भाग बन जाता है।