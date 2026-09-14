---
title: Python में प्रस्तुति स्लाइड्स को इमेज में परिवर्तित करें
linktitle: स्लाइड से इमेज
type: docs
weight: 35
url: /hi/python-java/convert-slide/
keywords:
- स्लाइड परिवर्तित करें
- स्लाइड निर्यात करें
- स्लाइड से इमेज
- स्लाइड को इमेज के रूप में सहेजें
- स्लाइड से EMF
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "PPT, PPTX, और ODP प्रस्तुतियों से स्लाइड्स को PNG, JPEG, GIF, TIFF, EMF और अन्य इमेज फ़ॉर्मेट्स में Python के साथ Aspose.Slides का उपयोग करके परिवर्तित करें।"
---
## **परिचय**

Aspose.Slides for Python via Java व्यक्तिगत स्लाइड्स को PowerPoint और OpenDocument प्रस्तुतियों से PNG, JPEG, GIF, TIFF और अन्य छवि प्रारूपों में रेंडर कर सकता है।

स्लाइड को इमेज में परिवर्तित करने के लिए, नीचे दिए गए चरणों का पालन करें:

1. प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास के साथ लोड करें।
2. उस स्लाइड का चयन करें जिसे आप रेंडर करना चाहते हैं।
3. यदि आवश्यक हो, तो रेंडरिंग को [RenderingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/renderingoptions/) या [TiffOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/) क्लास के साथ कॉन्फ़िगर करें।
4. [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) मेथड को कॉल करें। यह एक इमेज ऑब्जेक्ट लौटाता है।
5. इमेज को सहेजें और आउटपुट फॉर्मेट को [ImageFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imageformat/) मान के साथ निर्दिष्ट करें।

## **स्लाइड को PNG इमेज में बदलें**

सबसे सरल रूपांतरण डिफ़ॉल्ट रेंडरिंग सेटिंग्स का उपयोग करता है। उत्पन्न इमेज ऑब्जेक्ट को मेमोरी में प्रोसेस किया जा सकता है या फाइल में सहेजा जा सकता है।

निम्नलिखित Python उदाहरण पहले स्लाइड को रेंडर करता है और इसे PNG इमेज के रूप में सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **कस्टम आकार के साथ स्लाइड्स को इमेज में बदलें**

[Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) ओवरलोड का उपयोग करें जो एक [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) मान स्वीकार करता है ताकि स्लाइड को सटीक पिक्सेल आकार के साथ रेंडर किया जा सके।

निम्नलिखित उदाहरण 1820 × 1040 JPEG इमेज बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **नोट्स और कॉमेंट्स के साथ स्लाइड्स को इमेज में बदलें**

डिफ़ॉल्ट रूप से, स्लाइड इमेज में नोट्स या कॉमेंट्स शामिल नहीं होते हैं। नोट्स और कॉमेंट्स कहां दिखेंगे इसे नियंत्रित करने के लिए एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/) ऑब्जेक्ट को [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) मेथड में पास करें।

निम्नलिखित उदाहरण ट्रंकेटेड नोट्स को स्लाइड के नीचे और कॉमेंट्स को दाईं तरफ रखता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
स्लाइड-से-इमेज रूपांतरण के लिए, [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) मेथड में [BottomFull](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/#BottomFull) को पास न करें। नोट्स में स्थिर इमेज आकार से अधिक टेक्स्ट हो सकता है। इसके बजाय [BottomTruncated](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/#BottomTruncated) का उपयोग करें।
{{% /alert %}}

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को इमेज में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/) क्लास आपको रेंडर किए गए TIFF इमेज के आकार, रिज़ॉल्यूशन और अन्य गुणों को नियंत्रित करने की अनुमति देती है।

निम्नलिखित उदाहरण पहला स्लाइड को 2160 × 2880 TIFF इमेज के रूप में 300 DPI पर रेंडर करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
JDK 9 से पहले के Java संस्करणों में TIFF समर्थन की गारंटी नहीं है।
{{% /alert %}}

## **सभी स्लाइड्स को इमेज में बदलें**

पूरी प्रस्तुति को इमेज श्रृंखला में बदलने के लिए स्लाइड कलेक्शन पर इटेरेट करें। छिपी हुई स्लाइड्स शामिल की जाती हैं जब तक आप उन्हें स्पष्ट रूप से स्किप न करें।

निम्नलिखित उदाहरण प्रत्येक स्लाइड को क्षैतिज और लंबवत स्केल फ़ैक्टर 2 के साथ JPEG इमेज के रूप में रेंडर करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Enhanced Metafile आउटपुट बनाएं**

Enhanced Metafile (EMF) उपयोगी है जब वेक्टर-आधारित ग्राफिक्स को Microsoft Office या अन्य Windows अनुप्रयोगों के साथ आदान‑प्रदान करना हो जो Windows metafiles का समर्थन करते हैं। पिक्सेल‑आधारित इमेज के विपरीत, EMF वेक्टर ड्रॉइंग ऑपरेशन्स को बनाए रख सकता है जो स्केल होने पर भी समान स्पष्टता रखता है। हालांकि, EMF मुख्यतः Windows metafile समर्थन वाले अनुप्रयोगों के लिए एक संगतता स्वरूप है, सार्वभौमिक विनिमय स्वरूप नहीं। अतिरिक्त रूप से, जटिल स्लाइड सामग्री जैसे बिटमैप इमेज और कुछ इफ़ेक्ट्स को वेक्टर metafile कंटेनर के भीतर रास्टराइज़्ड तत्वों के रूप में संग्रहीत किया जा सकता है।

### **स्लाइड को EMF में निर्यात करें**

[Slide.writeAsEmf](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) मेथड एक [Slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) को EMF स्वरूप में लक्ष्य स्ट्रीम पर लिखता है। निम्नलिखित उदाहरण एक प्रेज़ेंटेशन लोड करता है, पहली स्लाइड का चयन करता है, और इसे EMF फ़ाइल स्ट्रीम में लिखता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

कॉलर को उस स्ट्रीम का स्वामित्व होता है जो [Slide.writeAsEmf](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) को पास किया गया है और उसे बंद करने की जिम्मेदारी स्वयं को ही लेनी पड़ती है, जैसा कि ऊपर दिखाया गया है।

### **SVG इमेज को EMF में बदलें और प्रेज़ेंटेशन में जोड़ें**

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/) का उपयोग करके SVG सामग्री को EMF में बदलें। परिणामी बाइट्स को [ImageCollection.addImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/#addImage) के माध्यम से प्रेज़ेंटेशन में जोड़ा जा सकता है और [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addPictureFrame) से स्लाइड पर रखा जा सकता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgimage/) गंतव्य स्ट्रीम का स्वामित्व नहीं लेता है। एक [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) सभी जनरेटेड डेटा को मेमोरी में संग्रहीत करता है, इसलिए [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--) को कॉल करने से पहले कोई पोजीशन रीसेट आवश्यक नहीं है। लौटाया गया बाइट एरे स्ट्रीम बंद होने के बाद भी वैध रहता है।

EMF जनरेशन चयनित Aspose.Slides for Python via Java और JDK कॉन्फ़िगरेशन द्वारा समर्थित ऑपरेटिंग सिस्टम पर उपलब्ध है, लेकिन फ़ॉन्ट या ग्राफ़िक्स निर्भरताओं की अनुपलब्धता होने पर प्लेटफ़ॉर्म के बीच रेंडरिंग में अंतर हो सकता है। स्रोत सामग्री द्वारा प्रयुक्त फ़ॉन्ट्स को स्थापित करें या उपयुक्त प्रतिस्थापन कॉन्फ़िगर करें, Aspose.Slides for Python via Java के लिए [platform requirements](/slides/hi/python-java/system-requirements/) का अनुसरण करें, और लक्ष्य EMF‑उपभोक्ता एप्लिकेशन में परिणाम की जाँच करें। Linux और macOS एप्लिकेशन अक्सर Windows metafiles को प्रदर्शित या संपादित करने में सीमित या असंगत समर्थन रखते हैं।

## **कलर इमोजी रेंडरिंग**

{{% alert title="Note" color="info" %}}
प्रेज़ेंटेशन स्लाइड्स को इमेज में बदलते समय कलर इमोजी को सही ढंग से रेंडर करने के लिए, प्रस्तुति में उपयोग किए गए इमोजी फ़ॉन्ट्स को उस सिस्टम पर इंस्टॉल किया जाना चाहिए जहाँ रूपांतरण किया जा रहा है। उदाहरण के लिए, यदि प्रस्तुति **Segoe UI Emoji** का उपयोग करती है और यह फ़ॉन्ट अनुपलब्ध है, तो आउटपुट इमेज में इमोजी मोनोक्रोम दिखाई दे सकते हैं।
{{% /alert %}}

## **FAQ**

**क्या Aspose.Slides एनीमेशन के साथ स्लाइड्स को रेंडर करने का समर्थन करता है?**

नहीं। [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) मेथड स्लाइड की स्थिर इमेज रेंडर करता है और एनीमेशन को निर्यात नहीं करता।

**क्या छिपी हुई स्लाइड्स को इमेज के रूप में निर्यात किया जा सकता है?**

हाँ। छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह रेंडर किया जा सकता है। उन्हें प्रोसेसिंग लूप में शामिल करें, जैसा कि ऊपर के उदाहरण में दिखाया गया है।

**क्या स्लाइड इमेज में छाया और अन्य प्रभाव संरक्षित रहते हैं?**

हाँ। Aspose.Slides स्लाइड इमेज में छाया, ट्रांसपेरेंसी और अन्य समर्थित ग्राफिकल प्रभावों को रेंडर करता है।