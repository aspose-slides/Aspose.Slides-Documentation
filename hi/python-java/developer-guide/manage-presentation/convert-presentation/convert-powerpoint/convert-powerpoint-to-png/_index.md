---
title: "PowerPoint स्लाइड्स को Python में PNG में परिवर्तित करें"
linktitle: "PowerPoint को PNG में"
type: docs
weight: 30
url: /hi/python-java/convert-powerpoint-to-png/
keywords:
  - "PowerPoint को परिवर्तित करें"
  - "प्रस्तुति को परिवर्तित करें"
  - "स्लाइड को परिवर्तित करें"
  - "PPT को परिवर्तित करें"
  - "PPTX को परिवर्तित करें"
  - "PowerPoint को PNG में"
  - "प्रस्तुति को PNG में"
  - "स्लाइड को PNG में"
  - "PPT को PNG में"
  - "PPTX को PNG में"
  - "PPT को PNG के रूप में सहेजें"
  - "PPTX को PNG के रूप में सहेजें"
  - "PPT को PNG में निर्यात करें"
  - "PPTX को PNG में निर्यात करें"
  - "Python"
  - "Java"
  - "Aspose.Slides"
description: "Python के माध्यम से Java में PowerPoint स्लाइड्स को PNG छवियों में परिवर्तित करें। कस्टम स्केल या सटीक छवि आयामों के साथ PPT, PPTX और ODP प्रस्तुतियों को निर्यात करें।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides for Python via Java का उपयोग करके प्रस्तुति स्लाइड्स को PNG छवियों में कैसे परिवर्तित किया जाए। आप PPT, PPTX, और ODP जैसे फ़ॉर्मेट में प्रस्तुति लोड कर सकते हैं, प्रत्येक स्लाइड को रेंडर कर सकते हैं और उसे अलग PNG छवि के रूप में सहेज सकते हैं।

निम्न उदाहरण डिफ़ॉल्ट स्केल पर रेंडरिंग, स्केल बढ़ाने, पिक्सेल में आउटपुट आयाम निर्दिष्ट करने, और ग्रेडिएंट रेंडरिंग स्टाइल चुनने को दर्शाते हैं।

## **PowerPoint को PNG में बदलें**

एक प्रस्तुति को [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास से लोड करें और उसकी स्लाइड्स तक [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) कलेक्शन के माध्यम से पहुँचें। यह उदाहरण प्रत्येक स्लाइड को बिना पैरामीटर के [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) द्वारा रेंडर करता है जिससे एक थंबनेल बनता है। फिर यह प्रत्येक रेंडर की गई स्लाइड को PNG छवि के रूप में सहेजने के लिये [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) को [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) के साथ कॉल करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
पैरामीटर रहित [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) ओवरलोड 0.2 स्केल पर रेंडर करता है। उदाहरण के रूप में, 720 × 540 पॉइंट्स की स्लाइड 144 × 108 पिक्सेल थंबनेल बनाती है। आउटपुट आयाम को नियंत्रित करने के लिए, नीचे दिखाए गए स्केल फैक्टर्स या स्पष्ट इमेज साइज के साथ ओवरलोड्स का उपयोग करें।
{{% /alert %}}

## **कस्टम आयामों के साथ PowerPoint को PNG में बदलें**

[Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) को क्षैतिज और लंबवत स्केल फैक्टर्स पास करके रेंडर किए गए आयामों को नियंत्रित करें। इस उदाहरण में दोनों फैक्टर्स 2 हैं, इसलिए 720 × 540 पॉइंट्स की स्लाइड 1440 × 1080 पिक्सेल छवि बनाती है। समान स्केल फैक्टर्स स्लाइड का अनुपात बनाए रखते हैं। प्रत्येक रेंडर की गई छवि PNG स्वरूप में सहेजी जाती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **कस्टम आकार के साथ PowerPoint को PNG में बदलें**

आउटपुट आयाम पिक्सेल में निर्दिष्ट करने के लिए, स्केल फैक्टर्स के बजाय [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) को एक आकार पास करें। यह उदाहरण प्रत्येक स्लाइड को 960 × 720 पिक्सेल पर रेंडर करता है और परिणाम को PNG स्वरूप में सहेजता है। छवि को खिंचाव से बचाने के लिये स्लाइड के अनुपात से मेल खाने वाले आयाम चुनें।

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

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **ग्रेडिएंट रेंडरिंग शैली चुनें**

मान लें कि कोई स्लाइड ग्रेडिएंट भराव रखती है, लेकिन निर्यातित PNG में संक्रमण PowerPoint में दिखने वाले से हल्के या अलग दिखते हैं। आप [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) मेथड का उपयोग कर सकते हैं, जो [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) द्वारा विरासत में मिला है, ताकि आप तय कर सकें कि ग्रेडिएंट कैसे रेंडर हों।

[gradient-styles.pptx](gradient-styles.pptx) डाउनलोड करें और इसे एप्लिकेशन की कार्यनिर्देशिका में रखें। इसकी पहली स्लाइड में दो रैखिक ग्रेडिएंट हैं: ऊपर साइन से ऑरेंज और नीचे ब्लू से येलो। प्रत्येक ग्रेडिएंट में दो स्टॉप होते हैं, 0% और 100% पर।

निम्न उदाहरण इस प्रस्तुति को लोड करता है और [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) के साथ दोनों मोडों में वही पहली स्लाइड रेंडर करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

नीचे की छवियाँ उसी स्लाइड के आउटपुट को दिखाती हैं, जहाँ प्रत्येक छवि में दोनों ग्रेडिएंट हैं:
| डिफ़ॉल्ट | PowerPointUI |
| --- | --- |
| ![डिफ़ॉल्ट के साथ साइन से ऑरेंज और ब्लू से येलो ग्रेडिएंट रेंडर किए गए](gradient-Default.png) | ![PowerPointUI के साथ वही ग्रेडिएंट रेंडर किए गए](gradient-PowerPointUI.png) |

इस उदाहरण में, `Default` हल्के मध्यवर्ती रंग उत्पन्न करता है, जबकि `PowerPointUI` गहरे मध्यवर्ती रंग उत्पन्न करता है। अंतर ग्रेडिएंट में रंगों और स्टॉप्स पर निर्भर करता है।

`Default` चुनें जब मानक Aspose.Slides आउटपुट आपकी जरूरतों के अनुकूल हो। `PowerPointUI` आज़माएं जब आपका प्राथमिक लक्ष्य PowerPoint में दिखावट से मिलाना हो। दोनों आउटपुट को अपने इच्छित परिणाम से तुलना करें; कोई भी मोड सार्वभौमिक रूप से बेहतर नहीं है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरी स्लाइड के बजाय एक विशिष्ट आकार, जैसे चार्ट या चित्र, को कैसे निर्यात कर सकता हूँ?**

Aspose.Slides [व्यक्तिगत आकारों के लिए थंबनेल उत्पन्न करने](/slides/hi/python-java/create-shape-thumbnails/) का समर्थन करता है, जिससे आप किसी आकार को PNG छवि के रूप में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**

हाँ। प्रत्येक थ्रेड या प्रोसेस के लिए एक अलग प्रस्तुति इंस्टेंस उपयोग करें; [थ्रेड्स के बीच एक ही इंस्टेंस साझा न करें](/slides/hi/python-java/multithreading/)।

**PNG में निर्यात करते समय मूल्यांकन सीमाएँ क्या हैं?**

मूल्यांकन मोड आउटपुट छवियों पर वाटरमार्क जोड़ता है और लाइसेंस लागू होने तक [अन्य प्रतिबंध](/slides/hi/python-java/licensing/) लागू करता है।