---
title: Python में PowerPoint स्लाइड्स को PNG में बदलें
linktitle: PowerPoint को PNG
type: docs
weight: 30
url: /hi/python-java/convert-powerpoint-to-png/
keywords:
- PowerPoint रूपांतरित करें
- प्रेजेंटेशन रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
- PowerPoint से PNG
- प्रेजेंटेशन से PNG
- स्लाइड से PNG
- PPT से PNG
- PPTX से PNG
- PPT को PNG के रूप में सहेजें
- PPTX को PNG के रूप में सहेजें
- PPT को PNG में निर्यात करें
- PPTX को PNG में निर्यात करें
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java में PowerPoint स्लाइड्स को PNG छवियों में बदलें। कस्टम स्केल या सटीक छवि आकार के साथ PPT, PPTX और ODP प्रस्तुतियों को निर्यात करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों को PNG छवियों में बदलने की विधि समझाता है। आप PPT, PPTX, और ODP फ़ाइलों को लोड कर सकते हैं, प्रत्येक स्लाइड को रेंडर कर सकते हैं, और उसे अलग PNG छवि के रूप में सहेज सकते हैं।

उदाहरण यह भी दिखाते हैं कि आउटपुट आकार को स्केल फैक्टर या सटीक चौड़ाई और ऊँचाई द्वारा कैसे नियंत्रित किया जाए। प्रत्येक उदाहरण आवश्यक होने पर Java वर्चुअल मशीन शुरू करता है और उपयोग के बाद प्रस्तुति और छवि संसाधनों को रिलीज़ करता है।

## **PowerPoint को PNG में परिवर्तित करें**

1. इनपुट फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास से लोड करें।
2. [Presentation.getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) का उपयोग करके स्लाइड्स प्राप्त करें।
3. [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) का उपयोग करके प्रत्येक स्लाइड को रेंडर करें।
4. प्रत्येक रेंडर की गई छवि को [ImageFormat.Png](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imageformat/#Png) के साथ सहेजें, फिर उसकी संसाधनों को रिलीज़ करें।

निम्नलिखित Python उदाहरण सभी स्लाइडों को उनके डिफ़ॉल्ट आकार में निर्यात करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **कस्टम स्केल के साथ PowerPoint को PNG में परिवर्तित करें**

[Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) को क्षैतिज और लंबवत स्केल फैक्टर पास करके आउटपुट आकार को बढ़ाया या घटाया जा सकता है। उदाहरण के लिए, 720 × 540‑पॉइंट स्लाइड को दोनों अक्षों पर 2 का स्केल फैक्टर लागू करने से 1440 × 1080‑पिक्सेल छवि बनती है।

स्लाइड के अनुपात को बनाए रखने के लिए समान स्केल फैक्टर का उपयोग करें। अलग-अलग फैक्टर स्लाइड को क्षैतिज या लंबवत रूप से खींचेंगे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **कस्टम आकार के साथ PowerPoint को PNG में परिवर्तित करें**

सटीक पिक्सेल आयाम निर्दिष्ट करने के लिए, इच्छित चौड़ाई और ऊँचाई के साथ एक Java `Dimension` ऑब्जेक्ट को [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) को पास करें। स्रोत स्लाइड के समान अनुपात वाले आयाम चुनें ताकि विकृति न हो।

निम्नलिखित उदाहरण प्रत्येक स्लाइड को 960 × 720‑पिक्सेल PNG छवि के रूप में सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**क्या मैं पूरे स्लाइड के बजाय किसी व्यक्तिगत आकार, जैसे चार्ट या चित्र, को निर्यात कर सकता हूँ?**

हाँ। Aspose.Slides व्यक्तिगत आकारों के लिए थंबनेल उत्पन्न करने का समर्थन करता है[generating thumbnails for individual shapes](/slides/hi/python-java/create-shape-thumbnails/), जिसे आप PNG छवियों के रूप में सहेज सकते हैं।

**क्या मैं सर्वर पर प्रस्तुतियों को समानांतर रूप से परिवर्तित कर सकता हूँ?**

प्रत्येक थ्रैड या प्रक्रिया के लिए अलग प्रस्तुति इंस्टेंस उपयोग करें, और फ़ाइलों के अधिलेखित होने से बचाने के लिए विशिष्ट आउटपुट पथ उपयोग करें। थ्रेड्स के बीच प्रस्तुति इंस्टेंस साझा न करें। देखें[Multithreading](/slides/hi/python-java/multithreading/)।

**PNG में निर्यात करते समय ट्रायल‑वर्ज़न सीमाएँ क्या हैं?**

मूल्यांकन मोड आउटपुट छवियों पर वॉटरमार्क जोड़ता है और[other restrictions](/slides/hi/python-java/licensing/) लागू करता है। इन सीमाओं को हटाने के लिए लाइसेंस लागू करें।