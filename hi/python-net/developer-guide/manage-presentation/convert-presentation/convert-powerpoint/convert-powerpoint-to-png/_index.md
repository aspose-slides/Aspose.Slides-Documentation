---
title: Python में PowerPoint स्लाइड्स को PNG में बदलें
linktitle: PowerPoint को PNG में
type: docs
weight: 30
url: /hi/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint को PNG में बदलें
- प्रस्तुति को PNG में बदलें
- स्लाइड को PNG में बदलें
- PPT को PNG में बदलें
- PPTX को PNG में बदलें
- ODP को PNG में बदलें
- PowerPoint को PNG में
- प्रस्तुति को PNG में
- स्लाइड को PNG में
- PPT को PNG में
- PPTX को PNG में
- ODP को PNG में
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों को तेज़ी से उच्च गुणवत्ता वाली PNG छवियों में बदलें, जिससे सटीक और स्वचालित परिणाम सुनिश्चित हों।"
---
## **सारांश**

यह लेख Aspose.Slides for Python via .NET का उपयोग करके प्रस्तुति स्लाइड्स को PNG छवियों में बदलने की विधि समझाता है। आप PPT, PPTX और ODP जैसे स्वरूपों में प्रस्तुतियों को लोड कर सकते हैं, प्रत्येक स्लाइड को रेंडर कर सकते हैं, और इसे एक अलग PNG छवि के रूप में सहेज सकते हैं।

निचे के उदाहरण डिफ़ॉल्ट स्केल पर रेंडरिंग, स्केल बढ़ाने, पिक्सल में आउटपुट आयाम निर्धारित करने, और ग्रेडिएंट रेंडरिंग स्टाइल चुनने को प्रदर्शित करते हैं।

## **PowerPoint को PNG में बदलें**

प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास से लोड करें और उसकी स्लाइड्स को [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) संग्रह के माध्यम से एक्सेस करें। उदाहरण प्रत्येक स्लाइड को [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) बिना पैरामीटर के थंबनेल बनाते हुए रेंडर करता है। फिर यह [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) को [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) के साथ कॉल करता है ताकि प्रत्येक रेंडर की गई स्लाइड को PNG छवि के रूप में सहेजा जा सके।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
बिना पैरामीटर वाला [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) ओवरलोड 0.2 स्केल पर रेंडर करता है। उदाहरण के लिए, 720 × 540 पॉइंट की स्लाइड 144 × 108 पिक्सेल थंबनेल बनाती है। आउटपुट आयाम नियंत्रित करने के लिए, नीचे दिखाए गए स्केल फ़ैक्टर या स्पष्ट इमेज आकार वाले ओवरलोड का उपयोग करें।
{{% /alert %}}

## **PowerPoint को कस्टम आयामों के साथ PNG में बदलें**

रेंडर किए गए आकार को नियंत्रित करने के लिए क्षैतिज और लंबवत स्केल फ़ैक्टर को [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) में पास करें। इस उदाहरण में दोनों फ़ैक्टर 2 हैं, इसलिए 720 × 540 पॉइंट की स्लाइड 1440 × 1080 पिक्सेल की छवि बनाती है। समान स्केल फ़ैक्टर स्लाइड के पहलू अनुपात को बनाए रखते हैं। प्रत्येक छवि को PNG फॉर्मेट में [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) के साथ सहेजा जाता है।

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **PowerPoint को कस्टम आकार के साथ PNG में बदलें**

आउटपुट आयाम पिक्सेल में निर्दिष्ट करने के लिए, स्केल फ़ैक्टर के बजाय [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) में आकार पास करें। यह उदाहरण प्रत्येक स्लाइड को 960 × 720 पिक्सेल पर रेंडर करता है और परिणाम को [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) के साथ सहेजता है। स्लाइड के पहलू अनुपात से मेल खाने वाले आयाम चुनें ताकि छवि खिंची न हो।

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **ग्रेडिएंट रेंडरिंग स्टाइल चुनें**

मान लीजिए किसी स्लाइड में ग्रेडिएंट फ़िल हैं, लेकिन निर्यातित PNG में परिवर्तन PowerPoint में देखे गए से हल्के या अलग दिखते हैं। आप [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) प्रॉपर्टी को [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) में उपयोग करके ग्रेडिएंट के रेंडरिंग का तरीका चुन सकते हैं।

[gradient-styles.pptx](gradient-styles.pptx) डाउनलोड करें और इसे एप्लिकेशन की कार्यशील डायरेक्टरी में रखें। इसकी पहली स्लाइड में दो रैखिक ग्रेडिएंट हैं: ऊपर सियान से ऑरेंज और नीचे ब्लू से येलो। प्रत्येक ग्रेडिएंट में दो स्टॉप हैं, 0 % और 100 % पर।

निम्न उदाहरण इस प्रस्तुति को लोड करता है और दोनों मोड में पहली स्लाइड को [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) के साथ रेंडर करता है।

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

| Default | PowerPointUI |
| --- | --- |
| ![सियान-से-ऑरेंज और ब्लू-से-येलो ग्रेडिएंट डिफ़ॉल्ट शैली में रेंडर किए गए](gradient-Default.png) | ![समान ग्रेडिएंट PowerPointUI शैली में रेंडर किए गए](gradient-PowerPointUI.png) |

इस उदाहरण में, `DEFAULT` हल्के मध्यवर्ती रंग उत्पन्न करता है, जबकि `POWER_POINT_UI` गहरे मध्यवर्ती रंग उत्पन्न करता है। अंतर ग्रेडिएंट के रंगों और स्टॉप्स पर निर्भर करता है।

जब मानक Aspose.Slides आउटपुट आपकी जरूरतों को पूरा करता है तो `DEFAULT` चुनें। जब आपका प्राथमिक लक्ष्य PowerPoint में दिखने वाले रूप से मेल खाना हो तो `POWER_POINT_UI` आज़माएँ। दोनों आउटपुट की अपनी इच्छित परिणाम से तुलना करें; कोई भी मोड सार्वभौमिक रूप से बेहतर नहीं है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरे स्लाइड की बजाय किसी विशिष्ट आकार, जैसे चार्ट या चित्र, को PNG के रूप में कैसे निर्यात करूँ?**

Aspose.Slides व्यक्तिगत आकारों के लिए [generating thumbnails for individual shapes](/slides/hi/python-net/create-shape-thumbnails/) को समर्थन देता है, जिससे आप आकार को PNG छवि के रूप में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**

हाँ। प्रत्येक थ्रेड या प्रोसेस के लिए अलग प्रस्तुति इंस्टेंस उपयोग करें; [do not share a single instance across threads](/slides/hi/python-net/multithreading/)।

**PNG निर्यात करते समय मूल्यांकन मोड की सीमाएँ क्या हैं?**

मूल्यांकन मोड आउटपुट छवियों में वॉटरमार्क जोड़ता है और लाइसेंस लागू होने तक [other restrictions](/slides/hi/python-net/licensing/) लागू करता है।