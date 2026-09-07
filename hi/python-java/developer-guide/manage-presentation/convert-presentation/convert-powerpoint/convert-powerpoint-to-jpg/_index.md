---
title: Python में PPT और PPTX को JPG में बदलें
linktitle: PowerPoint से JPG
type: docs
weight: 60
url: /hi/python-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PowerPoint से JPG
- PPT से JPG
- PPTX से JPG
- स्लाइड को JPG के रूप में सहेजें
- PPT को JPG में निर्यात करें
- PPTX को JPG में निर्यात करें
- Python
- Java
- Aspose.Slides
description: "Python via Java में PowerPoint (PPT, PPTX) स्लाइडों को JPG छवियों में बदलें। कस्टम इमेज डाइमेंशन सेट करें और Aspose.Slides के साथ नोट्स और कमेंट्स रेंडर करें।"
---
## **परिचय**

Aspose.Slides for Python via Java आपको PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, और ODP) को JPEG छवियों में बदलने देता है। आप प्रत्येक स्लाइड या चयनित स्लाइड को निर्यात करके थंबनेल बना सकते हैं, एक प्रस्तुति व्यूअर बना सकते हैं, या वेबसाइट या एप्लिकेशन में स्लाइड प्रीव्यू एम्बेड कर सकते हैं।

## **PowerPoint PPT/PPTX को JPG में परिवर्तित करें**

1. प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) के साथ लोड करें।
2. [getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) का उपयोग करके स्लाइड्स को प्राप्त करें।
3. [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) को क्षैतिज और लंबवत स्केल फ़ैक्टर्स के साथ कॉल करें ताकि प्रत्येक स्लाइड को रेंडर किया जा सके।
4. [ImageFormat.Jpeg](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imageformat/#Jpeg) का उपयोग करके प्रत्येक रेंडर की गई छवि को JPEG के रूप में सहेजें, फिर इमेज रिसोर्सेज़ को रिलीज़ करें।

{{% alert color="info" title="Note" %}}
JPG में निर्यात करने से प्रत्येक स्लाइड के लिए एक अलग छवि बनती है। प्रस्तुति को सीधे किसी इमेज फ़ॉर्मेट में सहेजने के बजाय रेंडर की गई छवि को सहेजें।
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint PPT/PPTX को कस्टमाइज़्ड डाइमेंशन्स के साथ JPG में परिवर्तित करें**

वांछित पिक्सेल आयामों और मूल स्लाइड आकार से क्षैतिज और लंबवत स्केल फ़ैक्टर्स की गणना करें, फिर उन्हें [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) को पास करें। निम्न उदाहरण प्रत्येक स्लाइड के लिए 1200 × 800 छवि को लक्षित करता है।

विभिनन स्केल फ़ैक्टर्स का उपयोग स्लाइड को खिंचा सकता है। इसका अनुपात बनाए रखने के लिए, दोनों अक्षों के लिए समान स्केल फ़ैक्टर उपयोग करें; परिणामस्वरूप चौड़ाई और ऊँचाई मूल स्लाइड के अनुपात का पालन करेंगे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **छवियों के रूप में स्लाइड्स सहेजते समय टिप्पणियों को रेंडर करें**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/) का उपयोग करके नोट्स और टिप्पणियों को कॉन्फ़िगर करें, और लेआउट को [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) के माध्यम से लागू करें। यह उदाहरण नोट्स को नीचे रखता है, जो फिट नहीं होते उन्हें काट देता है, और टिप्पणियों को दाईं ओर 200 पिक्सेल चौड़ी क्षेत्र में दिखाता है। यह प्रत्येक रेंडर की गई स्लाइड को JPG छवि के रूप में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई स्लाइड्स या प्रस्तुतियों को JPG में बदल सकता हूँ?**  
हां। उदाहरण सभी स्लाइड्स पर लूप करते हैं और प्रत्येक स्लाइड के लिए एक JPG सहेजते हैं। कई प्रस्तुतियों को प्रोसेस करने के लिए, प्रत्येक इनपुट फ़ाइल के लिए परिवर्तन दोहराएँ और ओवरराइट से बचने के लिए अलग आउटपुट फ़ोल्डर या अद्वितीय फ़ाइल नाम उपयोग करें।

**क्या चार्ट, SmartArt, तालिकाएँ, और शेप्स छवियों में शामिल हैं?**  
इन ऑब्जेक्ट्स को स्लाइड का हिस्सा के रूप में रेंडर किया जाता है। फ़ॉन्ट परिवर्तन के कारण होने वाले अंतर को कम करने के लिए प्रस्तुतियों में उपयोग किए गए फ़ॉन्ट को रूपांतरण पर्यावरण में उपलब्ध कराएँ।

**बड़ी प्रस्तुतियों को निर्यात करते समय मेमोरी उपयोग को कैसे कम करें?**  
छवियों को एक-एक करके प्रोसेस करें, सहेजने के बाद प्रत्येक छवि को रिलीज़ करें, और अनावश्यक रूप से बड़ी आउटपुट डाइमेंशन्स से बचें। मेमोरी आवश्यकताएँ स्लाइड की सामग्री और छवि आकार पर निर्भर करती हैं।

## **संबंधित देखें**

- [PowerPoint को PNG में बदलें](/slides/hi/python-java/convert-powerpoint-to-png/).
- [एक स्लाइड को SVG छवि के रूप में रेंडर करें](/slides/hi/python-java/render-a-slide-as-an-svg-image/).