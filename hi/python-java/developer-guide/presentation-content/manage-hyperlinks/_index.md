---
title: पाइथन द्वारा जावा में प्रस्तुति हाइपरलिंक प्रबंधन
linktitle: हाइपरलिंक प्रबंधन
type: docs
weight: 20
url: /hi/python-java/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक स्वरूपित करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- टेक्स्ट हाइपरलिंक
- स्लाइड हाइपरलिंक
- शेप हाइपरलिंक
- इमेज हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनशील हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक को सहजता से प्रबंधित करें—मिनटों में इंटरैक्टिविटी और कार्यप्रवाह को बढ़ाएँ।"
---
## **परिचय**

हाइपरलिंक एक वस्तु, डेटा या किसी स्थान का संदर्भ है। ये PowerPoint प्रस्तुतियों में सामान्य हाइपरलिंक हैं:

* टेक्स्ट, आकार, या मीडिया के भीतर वेबसाइट के लिंक
* स्लाइड के लिंक

Aspose.Slides for Python via Java आपको प्रस्तुतियों में हाइपरलिंक से संबंधित कई कार्य करने की अनुमति देता है।

{{% alert color="info" title="Note" %}} 
आप Aspose सरल, [नि:शुल्क ऑनलाइन PowerPoint संपादक.](https://products.aspose.app/slides/hi/editor) देखना चाह सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

### **पाठ में URL हाइपरलिंक जोड़ें**

यह Python कोड आपको दिखाता है कि टेक्स्ट में वेबसाइट हाइपरलिंक कैसे जोड़ें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **आकार या फ्रेम में URL हाइपरलिंक जोड़ें**

यह Python via Java नमूना कोड आपको दिखाता है कि आकार में वेबसाइट हाइपरलिंक कैसे जोड़ें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **मीडिया में URL हाइपरलिंक जोड़ें**

Aspose.Slides आपको छवियों, ऑडियो और वीडियो फ़ाइलों में हाइपरलिंक जोड़ने की अनुमति देता है।

यह नमूना कोड आपको दिखाता है कि **image** में हाइपरलिंक कैसे जोड़ें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # प्रस्तुति में छवि जोड़ता है
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # स्लाइड 1 पर पहले जोड़ी गई छवि के आधार पर चित्र फ्रेम बनाता है
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यह नमूना कोड आपको दिखाता है कि **audio file** में हाइपरलिंक कैसे जोड़ें:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यह नमूना कोड आपको दिखाता है कि **video** में हाइपरलिंक कैसे जोड़ें:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}} 
आप *[Manage OLE](/slides/hi/python-java/manage-ole/)* देखना चाह सकते हैं।
{{% /alert %}}

## **हाइपरलिंक का उपयोग करके सामग्री तालिका बनाएं**

चूँकि हाइपरलिंक आपको वस्तुओं या स्थानों के संदर्भ जोड़ने की अनुमति देते हैं, आप उनका उपयोग करके सामग्री तालिका बना सकते हैं।

यह नमूना कोड आपको दिखाता है कि हाइपरलिंक के साथ सामग्री तालिका कैसे बनाएं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **हाइपरलिंक स्वरूपित करें**

### **रंग**

[Hyperlink.setColorSource](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setColorSource) प्रॉपर्टी को [Hyperlink](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/) क्लास में उपयोग करके आप हाइपरलिंक का रंग सेट कर सकते हैं और हाइपरलिंक से रंग की जानकारी प्राप्त कर सकते हैं। यह सुविधा PowerPoint 2019 में पहली बार प्रस्तुत की गई थी, इसलिए इस प्रॉपर्टी से संबंधित परिवर्तन पुराने PowerPoint संस्करणों पर लागू नहीं होते।

यह नमूना कोड एक ऑपरेशन दर्शाता है जहाँ विभिन्न रंगों वाले हाइपरलिंक एक ही स्लाइड में जोड़े गए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **प्रेजेंटेशन से हाइपरलिंक हटाएँ**

### **पाठ से हाइपरलिंक हटाएँ**

यह Python कोड आपको दिखाता है कि प्रस्तुति स्लाइड के टेक्स्ट से हाइपरलिंक कैसे हटाएँ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **आकार या फ्रेम से हाइपरलिंक हटाएँ**

यह Python कोड आपको दिखाता है कि प्रस्तुति स्लाइड के आकार से हाइपरलिंक कैसे हटाएँ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **परिवर्तनीय हाइपरलिंक**

[Hyperlink](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/) क्लास परिवर्तनशील है। इस क्लास के साथ आप निम्न प्रॉपर्टियों के मान बदल सकते हैं:

- [setTargetFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

यह कोड स्निपेट आपको दिखाता है कि स्लाइड में हाइपरलिंक कैसे जोड़ें और बाद में उसका टूलटिप कैसे संपादित करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # पहले से जोड़ी गई हाइपरलिंक के टूलटिप को बदलता है
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **HyperlinkQueries में समर्थित गुण**

आप एक प्रस्तुति, स्लाइड, या टेक्स्ट से [HyperlinkQueries](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/) तक पहुंच सकते हैं जहाँ हाइपरलिंक परिभाषित है।

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/#getHyperlinkQueries)

[HyperlinkQueries](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/) क्लास इन मेथड्स और प्रॉपर्टीज़ का समर्थन करता है:

- [getHyperlinkClicks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं सिर्फ स्लाइड नहीं, बल्कि "सेक्शन" या एक सेक्शन की पहली स्लाइड के लिए आंतरिक नेविगेशन कैसे बना सकता हूँ?**  
PowerPoint में सेक्शन स्लाइड्स के समूह होते हैं; नेविगेशन तकनीकी तौर पर एक विशिष्ट स्लाइड को लक्षित करता है। "सेक्शन पर नेविगेट करने" के लिए आपको आमतौर पर उसकी पहली स्लाइड से लिंक करना पड़ता है।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि वह सभी स्लाइड्स पर काम करे?**  
हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। ऐसे लिंक चाइल्ड स्लाइड्स पर दिखाई देते हैं और स्लाइडशो के दौरान क्लिक करने योग्य होते हैं।

**क्या हाइपरलिंक PDF, HTML, छवियों या वीडियो में निर्यात करने पर संरक्षित रहेंगे?**  
[PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/python-java/convert-powerpoint-to-html/) में, हाँ—लिंक सामान्यतः संरक्षित रहते हैं। जब आप [images](/slides/hi/python-java/convert-powerpoint-to-png/) और [video](/slides/hi/python-java/convert-powerpoint-to-video/) में निर्यात करते हैं, तो क्लिक करने की क्षमता नहीं रहती क्योंकि उन फ़ॉर्मैट्स (रैस्टर फ्रेम/वीडियो) हाइपरलिंक का समर्थन नहीं करते।