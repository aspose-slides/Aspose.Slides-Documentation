---
title: Python के माध्यम से Java में प्रस्तुति पृष्ठभूमियों का प्रबंधन
linktitle: स्लाइड पृष्ठभूमि
type: docs
weight: 20
url: /hi/python-java/presentation-background/
keywords:
- प्रस्तुति पृष्ठभूमि
- स्लाइड पृष्ठभूमि
- सॉलिड रंग
- ग्रेडिएंट रंग
- छवि पृष्ठभूमि
- पृष्ठभूमि पारदर्शिता
- पृष्ठभूमि गुण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument फ़ाइलों में गतिशील पृष्ठभूमियां सेट करने का तरीका जानें, साथ ही अपने प्रस्तुतियों को सुधारने के लिए कोड टिप्स।"
---
## **परिचय**

सॉलिड रंग, ग्रेडिएंट और छवियों का अक्सर स्लाइड पृष्ठभूमि के लिए उपयोग किया जाता है। आप **समान स्लाइड** (एकल स्लाइड) या **मास्टर स्लाइड** (एक साथ कई स्लाइडों पर लागू) के लिए पृष्ठभूमि सेट कर सकते हैं।

![PowerPoint background](powerpoint-background.png)

## **समान स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में किसी विशिष्ट स्लाइड के लिए पृष्ठभूमि के रूप में सॉलिड रंग सेट करने की अनुमति देता है—भले ही प्रस्तुति में मास्टर स्लाइड हो। परिवर्तन केवल चयनित स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) `Solid` पर सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/) पर [getSolidFillColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/#getsolidfillcolor) मेथड का उपयोग करके सॉलिड पृष्ठभूमि रंग निर्धारित करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित Python उदाहरण दिखाता है कि सामान्य स्लाइड के लिए नीला सॉलिड रंग कैसे सेट किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Presentation क्लास का एक उदाहरण बनाएं।
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # स्लाइड की पृष्ठभूमि रंग को नीला सेट करें।
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # प्रेजेंटेशन को डिस्क पर सहेजें।
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **मास्टर स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में मास्टर स्लाइड के लिए पृष्ठभूमि के रूप में सॉलिड रंग सेट करने की अनुमति देता है। मास्टर स्लाइड एक टेम्पलेट के रूप में कार्य करता है जो सभी स्लाइडों के फ़ॉर्मेट को नियंत्रित करता है, इसलिए जब आप मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग चुनते हैं, तो यह प्रत्येक स्लाइड पर लागू हो जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. मास्टर स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/backgroundtype/) ( [getMasters](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getmasters) के माध्यम से) `OwnBackground` पर सेट करें।
3. मास्टर स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) `Solid` पर सेट करें।
4. सॉलिड पृष्ठभूमि रंग निर्धारित करने के लिए [getSolidFillColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/#getsolidfillcolor) मेथड का उपयोग करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित Python उदाहरण दिखाता है कि मास्टर स्लाइड के लिए हरा सॉलिड रंग कैसे सेट किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Presentation क्लास का एक उदाहरण बनाएं।
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # मास्टर स्लाइड की पृष्ठभूमि रंग को हरा सेट करें।
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # प्रेजेंटेशन को डिस्क पर सहेजें।
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्लाइड के लिए ग्रेडिएंट पृष्ठभूमि सेट करें**

ग्रेडिएंट एक ग्राफ़िकल प्रभाव है जो रंग में धीरे-धीरे परिवर्तन द्वारा बनता है। जब इसे स्लाइड पृष्ठभूमि के रूप में उपयोग किया जाता है, तो ग्रेडिएंट प्रस्तुतीकरण को अधिक कलात्मक और पेशेवर बना सकता है। Aspose.Slides आपको स्लाइडों के लिए ग्रेडिएंट रंग पृष्ठभूमि सेट करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) `Gradient` पर सेट करें।
4. अपनी पसंदीदा ग्रेडिएंट सेटिंग्स को कॉन्फ़िगर करने के लिए [FillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/) पर [getGradientFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/#getgradientformat) मेथड का उपयोग करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित Python उदाहरण दिखाता है कि स्लाइड के लिए ग्रेडिएंट रंग कैसे सेट किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Presentation क्लास का एक उदाहरण बनाएं।
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # पृष्ठभूमि पर ग्रेडिएंट प्रभाव लागू करें।
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # ग्रेडिएंट रंग जोड़ें। ग्रेडिएंट स्टॉप्स के बिना, पृष्ठभूमि डिफ़ॉल्ट काला-से-सफ़ेद रैंप पर वापस आती है।
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # प्रेजेंटेशन को डिस्क पर सहेजें।
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्लाइड पृष्ठभूमि के रूप में छवि सेट करें**

सॉलिड और ग्रेडिएंट फ़िल के अतिरिक्त, Aspose.Slides आपको छवियों को स्लाइड पृष्ठभूमि के रूप में उपयोग करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) `Picture` पर सेट करें।
4. वह छवि लोड करें जिसे आप स्लाइड पृष्ठभूमि के रूप में उपयोग करना चाहते हैं।
5. छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
6. [FillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/) पर [getPictureFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/#getpicturefillformat) मेथड का उपयोग करके छवि को पृष्ठभूमि के रूप में असाइन करें।
7. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित Python उदाहरण दिखाता है कि स्लाइड के लिए छवि को पृष्ठभूमि के रूप में कैसे सेट किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Presentation क्लास का एक उदाहरण बनाएं।
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # पृष्ठभूमि छवि गुण सेट करें।
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # छवि लोड करें।
    image = Images.fromFile("Tulips.jpg")
    # छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # प्रेजेंटेशन को डिस्क पर सहेजें।
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

निम्नलिखित कोड नमूना दिखाता है कि बैकग्राउंड फ़िल टाइप को टाइल्ड पिक्चर पर कैसे सेट करें और टाइलिंग प्रॉपर्टीज़ को संशोधित करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # पृष्ठभूमि फ़िल के लिए उपयोग की गई छवि सेट करें।
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # चित्र फ़िल मोड को टाइल पर सेट करें और टाइल गुण समायोजित करें।
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="नोट" %}}

और अधिक पढ़ें: [Tile Picture as Texture](/slides/hi/python-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **पृष्ठभूमि छवि की पारदर्शिता बदलें**

आप स्लाइड की पृष्ठभूमि छवि की पारदर्शिता को समायोजित करना चाह सकते हैं ताकि स्लाइड की सामग्री अधिक स्पष्ट दिखे। निम्नलिखित Python कोड दिखाता है कि स्लाइड पृष्ठभूमि छवि की पारदर्शिता को कैसे बदलें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # उदाहरण के लिए।

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # चित्र रूपांतरण संचालन का संग्रह प्राप्त करें।
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # मौजूदा निश्चित-प्रतिशत पारदर्शिता प्रभाव खोजें।
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # नया पारदर्शिता मान सेट करें।
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्लाइड पृष्ठभूमि मान प्राप्त करें**

Aspose.Slides आपको [Background](https://reference.aspose.com/slides/hi/python-java/aspose.slides/background/) पर [getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/background/#geteffective) मेथड का उपयोग करके स्लाइड के प्रभावी पृष्ठभूमि मान प्राप्त करने देता है। लौटाया गया डेटा प्रभावी फ़िल और इफ़ेक्ट फ़ॉर्मेट को उजागर करता है।

[BaseSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/) क्लास के [getBackground](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getbackground) मेथड का उपयोग करके आप स्लाइड की पृष्ठभूमि प्राप्त कर सकते हैं।

निम्नलिखित Python उदाहरण दिखाता है कि स्लाइड के प्रभावी पृष्ठभूमि मान को कैसे प्राप्त किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Presentation क्लास का एक उदाहरण बनाएं।
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # मास्टर, लेआउट और थीम को ध्यान में रखते हुए प्रभावी पृष्ठभूमि प्राप्त करें।
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कस्टम पृष्ठभूमि को रीसेट कर सकता हूँ और थीम/लेआउट पृष्ठभूमि को पुनर्स्थापित कर सकता हूँ?**

हाँ। स्लाइड की कस्टम फ़िल को हटा दें, और पृष्ठभूमि फिर से संबंधित [layout](/slides/hi/python-java/slide-layout/)/[master](/slides/hi/python-java/slide-master/) स्लाइड (अर्थात् [theme background](/slides/hi/python-java/presentation-theme/)) से विरासत में मिल जाएगी।

**यदि मैं बाद में प्रस्तुति की थीम बदलूँ तो पृष्ठभूमि पर क्या प्रभाव पड़ेगा?**

यदि किसी स्लाइड की अपनी फ़िल है, तो वह अपरिवर्तित रहेगी। यदि पृष्ठभूमि [layout](/slides/hi/python-java/slide-layout/)/[master](/slides/hi/python-java/slide-master/) से विरासत में मिली है, तो वह नए थीम के अनुसार अपडेट हो जाएगी।