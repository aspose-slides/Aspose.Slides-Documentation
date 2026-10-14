---
title: Python के द्वारा Java में PowerPoint आकृतियों को स्वरूपित करें
linktitle: आकृति स्वरूपण
type: docs
weight: 20
url: /hi/python-java/shape-formatting/
keywords:
- आकृति स्वरूपण
- रेखा स्वरूपण
- स्केच प्रभाव
- आकृति रेखा स्केच
- जॉइन शैली स्वरूपित करें
- ग्रेडिएंट फिल
- पैटर्न फिल
- पिक्चर फिल
- टेक्सचर फिल
- सॉलिड कलर फिल
- आकृति ट्रांसपेरेंसी
- काला-और-सफ़ेद आकृति रेंडरिंग
- ग्रेस्केल आकृति रेंडरिंग
- आकृति घुमाएँ
- 3डी बीवल प्रभाव
- 3डी घूर्णन प्रभाव
- फ़ॉर्मेटिंग रीसेट करें
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python के माध्यम से Java में PowerPoint आकृतियों को स्वरूपित करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिये फिल, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में आकृतियों को जोड़ सकते हैं। चूँकि आकृतियाँ लाइनों से बनी होती हैं, आप उनकी रूपरेखा को संशोधित करके या प्रभाव लागू करके उन्हें स्वरूपित कर सकते हैं। अतिरिक्त रूप से, आप आकृतियों को उनके अंदरूनी भाग को भरने वाले सेटिंग्स निर्दिष्ट करके स्वरूपित कर सकते हैं।

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java क्लास और मेथड प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकृतियों को स्वरूपित करने की अनुमति देता है।

## **रेखाओं का स्वरूपण**

Aspose.Slides का उपयोग करके, आप किसी आकृति के लिये एक कस्टम लाइन शैली निर्दिष्ट कर सकते हैं। नीचे दिए गए चरण इस प्रक्रिया को दर्शाते हैं:

1. एक नया [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की [line style](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई सेट करें।
1. लाइन का [dash style](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) सेट करें।
1. आकृति के लिये लाइन का रंग सेट करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

एक आयत [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) को स्वरूपित करने का उदाहरण नीचे दिया गया है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

    # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टैंस बनाएं।
    presentation = Presentation()
    try:
        # पहली स्लाइड प्राप्त करें।
        slide = presentation.getSlides().get_Item(0)

        # Rectangle प्रकार की एक ऑटो शैप जोड़ें।
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

        # आयत आकृति के लिए भरने का रंग सेट करें।
        shape.getFillFormat().setFillType(FillType.NoFill)

        # आयत की रेखाओं पर स्वरूपण लागू करें।
        shape.getLineFormat().setStyle(LineStyle.ThickThin)
        shape.getLineFormat().setWidth(7)
        shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

        # आयत की रेखा का रंग सेट करें।
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

        # PPTX फ़ाइल को डिस्क पर सहेजें।
        presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

परिणाम:

![प्रस्तुति में स्वरूपित रेखाएँ](formatted-lines.png)

## **आकृति रेखाओं पर स्केच प्रभाव लागू करें**

स्केच प्रभाव एक आकृति रेखा को हाथ से खींची हुई दिखाता है। रेखा सेटिंग्स तक पहुँचने के लिये आप [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) का उपयोग करें, स्केच सेटिंग्स तक पहुँचने के लिये [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) उपयोग करें, और स्केच प्रकार चुनने के लिये [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) का उपयोग करके [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) एन्यूमरेशन से मान चुनें।

निम्न Python कोड दिखाता है कि कैसे आप [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved) प्रभाव लागू कर सकते हैं, स्पष्ट रूप से निर्धारित मान को पढ़ सकते हैं, और [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None) के माध्यम से प्रभाव को हटाते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # आकृति के लाइन फ़ॉर्मेट और उसकी स्केच फ़ॉर्मेट तक पहुँचें।
    sketch_format = shape.getLineFormat().getSketchFormat()

    # एक स्केच प्रभाव लागू करें।
    sketch_format.setSketchType(LineSketchType.Curved)

    # आकृति को सीधे सौंपे गए स्केच प्रभाव को पढ़ें।
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # स्केच प्रभाव को हटाएँ।
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) द्वारा लौटाया गया मान सीधे आकृति को सौंपे गए सेटिंग को दर्शाता है। यदि लाइन फ़ॉर्मेट थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में मिल सकता है, तो [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) का उपयोग करें, `LineFormatEffectiveData.getSketchFormat` तक पहुँचें, और `SketchFormatEffectiveData.getSketchType` पढ़ें। प्रभावी मान विरासत समाधान के बाद वास्तव में लागू फ़ॉर्मेटिंग को दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **जॉइन शैलियों का स्वरूपण**

तीन जॉइन प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को किसी कोण (जैसे आकृति के कोने) पर जोड़ता है, तो यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोण वाली आकृति बना रहे हैं, तो आप **Miter** विकल्प को प्राथमिकता दे सकते हैं।

![प्रेजेंटेशन में जॉइन स्टाइल](join-style-powerpoint.png)

निम्न Python कोड दिखाता है कि कैसे ऊपर की छवि में दिखाए गए तीन आयतें Miter, Bevel, और Round जॉइन प्रकार सेटिंग का उपयोग करके बनाई गई थीं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टैंस बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # Rectangle प्रकार की तीन ऑटो शैप जोड़ें।
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # प्रत्येक आयत आकृति के लिए भरने का रंग सेट करें।
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # रेखा की चौड़ाई सेट करें।
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # प्रत्येक आयत की रेखा का रंग सेट करें।
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # जॉइन शैली सेट करें।
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # प्रत्येक आयत में टेक्स्ट जोड़ें।
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ग्रेडिएंट फिल**

PowerPoint में, ग्रेडिएंट फिल एक फ़ॉर्मेटिंग विकल्प है जो आप किसी आकृति पर लगातार रंगों का मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिये, आप दो या अधिक रंग इस प्रकार लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में मिल जाता है।

Aspose.Slides का उपयोग करके आकृति पर ग्रेडिएंट फिल लागू करने के लिये:

1. एक नया [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति के [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) को `Gradient` सेट करें।
1. ग्रेडिएंट स्टॉप संग्रह के द्वारा प्रदान किए गए [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) मेथड का उपयोग करके दो इच्छित रंगों को परिभाषित स्थितियों के साथ जोड़ें, जो [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/) क्लास द्वारा उजागर किया गया है।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

एक दीर्घवृत्त पर ग्रेडिएंट फिल प्रभाव लागू करने का उदाहरण नीचे दिया गया है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टैंस बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # Ellipse प्रकार की एक ऑटो शैप जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # एलिप्स पर ग्रेडिएंट स्वरूपण लागू करें।
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # ग्रेडिएंट की दिशा सेट करें।
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # दो ग्रेडिएंट स्टॉप जोड़ें।
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![ग्रेडिएंट फिल वाला दीर्घवृत्त](gradient-fill.png)

यदि एक ग्रेडिएंट निर्यात की गई छवि में PowerPoint से अलग दिखता है, तो देखें [Choose a Gradient Rendering Style](/slides/hi/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)। आप प्रस्तुति में संग्रहीत ग्रेडिएंट फिल को बदले बिना रेंडरिंग शैली का चयन कर सकते हैं।

## **पैटर्न फिल**

PowerPoint में, पैटर्न फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको दो‑रंगीय डिज़ाइन—जैसे बिंदु, धारियाँ, क्रॉसहैच या चेकबोर्ड—आकृति पर लागू करने की अनुमति देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिये कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वपरिभाषित पैटर्न शैलियाँ प्रदान करता है जिन्हें आप अपनी प्रस्तुतियों की दृश्य अपील बढ़ाने के लिये आकृतियों पर लागू कर सकते हैं। पूर्वपरिभाषित पैटर्न चुनने के बाद भी, आप अभी भी सटीक रंग निर्दिष्ट कर सकते हैं।

Aspose.Slides का उपयोग करके आकृति पर पैटर्न फिल लागू करने के लिये:

1. एक नया [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति के [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) को `Pattern` सेट करें।
1. पूर्वपरिभाषित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न के [Background Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) को सेट करें।
1. पैटर्न के [Foreground Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) को सेट करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

एक आयत पर पैटर्न फिल लागू करने का उदाहरण नीचे दिया गया है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टैंस बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # फिल प्रकार को Pattern सेट करें।
    shape.getFillFormat().setFillType(FillType.Pattern)

    # पैटर्न शैली सेट करें।
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # पैटर्न की पृष्ठभूमि और अग्रभूमि रंग सेट करें।
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पैटर्न फिल वाला आयत](pattern-fill.png)

## **पिक्चर फिल**

PowerPoint में, पिक्चर फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको आकृति के अंदर एक छवि सम्मिलित करने की अनुमति देता है—वास्तव में छवि को आकृति की पृष्ठभूमि के रूप में उपयोग करते हुए।

Aspose.Slides का उपयोग करके आकृति पर पिक्चर फिल लागू करने के लिये:

1. एक नया [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति के [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) को `Picture` सेट करें।
1. पिक्चर फिल मोड को `Tile` (या कोई अन्य वांछित मोड) सेट करें।
1. उपयोग करने वाली छवि से एक [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं।
1. छवि को `SlidesPicture.setImage` मेथड में पास करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास "lotus.png" फ़ाइल है जिसमें निम्नलिखित चित्र है:

![लोटस चित्र](lotus.png)

एक आकृति को पिक्चर से भरने का उदाहरण नीचे दिया गया है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टैंस बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # फिल प्रकार को Picture सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture)

    # पिक्चर फिल मोड सेट करें।
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # एक छवि लोड करें और इसे प्रस्तुति संसाधनों में जोड़ें।
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # पिक्चर सेट करें।
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पिक्चर फिल वाला आकृति](picture-fill.png)

### **टाइल चित्र को बनावट के रूप में सेट करें**

यदि आप टाइल्ड चित्र को बनावट के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) क्लास की निम्न मेथड्स का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): चित्र भराव मोड सेट करता है—`Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): आकृति के भीतर टाइलों की संरेखण निर्दिष्ट करता है।
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): टाइल को क्षैतिज, लंबवत या दोनों दिशा में फ्लिप करने को नियंत्रित करता है।
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): आकृति की मूल स्थिति से टाइल का क्षैतिज ऑफ़सेट (पॉइंट में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): आकृति की मूल स्थिति से टाइल का लंबवत ऑफ़सेट (पॉइंट में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): टाइल के क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): टाइल के लंबवत स्केल को प्रतिशत में परिभाषित करता है।

निम्न कोड नमूना दिखाता है कि कैसे एक आयत आकृति को टाइल्ड पिक्चर फिल के साथ जोड़ें और टाइल विकल्प कॉन्फ़िगर करें:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टैंस बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    first_slide = presentation.getSlides().get_Item(0)

    # एक आयत ऑटो शैप जोड़ें।
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # आकृति का फिल प्रकार Picture सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture)

    # छवि लोड करें और इसे प्रस्तुति संसाधनों में जोड़ें।
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # छवि को आकृति को असाइन करें।
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # पिक्चर फिल मोड और टाइलिंग गुण कॉन्फ़िगर करें।
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![टाइल विकल्प](tile-options.png)

## **सॉलिड कलर फिल**

PowerPoint में, सॉलिड कलर फिल एक फ़ॉर्मेटिंग विकल्प है जो किसी आकृति को एकसमान रंग से भरता है। यह साधारण पृष्ठभूमि रंग कोई ग्रेडिएंट, बनावट या पैटर्न के बिना लागू किया जाता है।

Aspose.Slides के साथ सॉलिड कलर फिल लागू करने के लिये:

1. एक नया [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति के [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) को `Solid` सेट करें।
1. आकृति को अपने वांछित भराव रंग सौंपें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

एक आयत पर सॉलिड कलर फिल लागू करने का उदाहरण नीचे दिया गया है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टैंस बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # फिल प्रकार को Solid सेट करें।
    shape.getFillFormat().setFillType(FillType.Solid)

    # भरने का रंग सेट करें।
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![सॉलिड कलर फिल वाला आकृति](solid-color-fill.png)

## **ट्रांसपेरेंसी सेट करें**

PowerPoint में, जब आप सॉलिड, ग्रेडिएंट, पिक्चर या बनावट फिल को आकृतियों पर लागू करते हैं, तो आप फिल की अपारदर्शिता स्तर को सेट करके फ़िल की अस्पष्टता को नियंत्रित कर सकते हैं। उच्च ट्रांसपेरेंसी मान आकृति को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे की वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फिल में उपयोग किए गए रंग के अल्फा मान को समायोजित करके ट्रांसपेरेंसी स्तर सेट करने की अनुमति देता है। इसे करने के लिये:

1. एक नया [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) को `Solid` सेट करें।
1. फिल के लिये ट्रांसपेरेंट रंग परिभाषित करने हेतु [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) का उपयोग करें (अल्फा घटक ट्रांसपेरेंसी नियंत्रित करता है)।
1. प्रस्तुति को सहेजें।

निचले आयत पर ट्रांसपेरेंट फिल रंग लागू करने का कोड नीचे दिया गया है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टैंस बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # एक ठोस आयत ऑटो शैप जोड़ें।
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # ठोस आकृति के ऊपर एक पारदर्शी आयत ऑटो शैप जोड़ें।
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![ट्रांसपेरेंट आकृति](shape-transparency.png)

## **आकृतियों को घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकृतियों को घुमाने की सुविधा देता है। यह विशेष संरेखण या डिज़ाइन आवश्यकताओं के साथ दृश्य तत्वों को स्थित करने में उपयोगी हो सकता है।

स्लाइड पर किसी आकृति को घुमाने के लिये, नीचे दिए चरणों का पालन करें:

1. एक नया [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति के घूर्णन गुण को इच्छित कोण पर सेट करें।
1. प्रस्तुति को सहेजें।

आकृति को 5 डिग्री तक घुमाने का कोड नीचे दिया गया है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टैंस बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # आकृति को 5 डिग्री घुमाएँ।
    shape.setRotation(5)

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![आकृति घूर्णन](shape-rotation.png)

## **3D बीवल प्रभाव जोड़ें**

Aspose.Slides आपको [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) गुणों को कॉन्फ़िगर करके आकृतियों पर 3D बीवल प्रभाव लागू करने देता है।

एक आकृति में 3D बीवल प्रभाव जोड़ने के लिये, नीचे दिए चरणों का पालन करें:

1. एक नया [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति के [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) को कॉन्फ़िगर करके बीवल सेटिंग्स निर्धारित करें।
1. प्रस्तुति को सहेजें।

नीचे दिया गया Python कोड दिखाता है कि कैसे एक आकृति पर 3D बीवल प्रभाव लागू किया जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Presentation क्लास का एक इंस्टैंस बनाएं।
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # स्लाइड में एक आकृति जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # आकृति की ThreeDFormat प्रॉपर्टीज़ सेट करें।
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # प्रस्तुति को PPTP फ़ाइल के रूप में सहेजें।
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![3D बीवल प्रभाव](3D-bevel-effect.png)

## **3D घूर्णन प्रभाव जोड़ें**

Aspose.Slides आपको [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) गुणों को कॉन्फ़िगर करके आकृतियों पर 3D घूर्णन प्रभाव लागू करने देता है।

3D घूर्णन लागू करने के लिये:

1. एक नया [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
1. इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) जोड़ें।
1. 3D घूर्णन को परिभाषित करने के लिये [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) और [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) मेथड का उपयोग करें।
1. प्रस्तुति को सहेजें।

नीचे दिया गया Python कोड दिखाता है कि कैसे एक आकृति पर 3D घूर्णन प्रभाव लागू किया जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Presentation क्लास का एक इंस्टैंस बनाएं।
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![3D घूर्णन प्रभाव](3D-rotation-effect.png)

## **आकृतियों के लिए ब्लैक-एंड-वाइट रेंडरिंग नियंत्रित करें**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) मेथड यह निर्दिष्ट करता है कि जब प्रस्तुति को ब्लैक‑एंड‑वाइट मोड में देखा या प्रोसेस किया जाता है तो व्यक्तिगत आकृति कैसे रेंडर की जाती है। यह स्वयं ब्लैक‑एंड‑वाइट डिस्प्ले को सक्षम नहीं करता, न ही सामान्य रंग मोड में आकृति की फिल, लाइन या अन्य फ़ॉर्मेटिंग को बदलता है।

इच्छित व्यवहार चुनने के लिये आप [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) क्लास के मान का उपयोग कर सकते हैं। उदाहरण के लिये, `Automatic` रेंडरिंग एप्लिकेशन को परिवर्तन चुनने देता है, `Gray` और `LightGray` ग्रे रंग का उपयोग करते हैं, `BlackWhite` केवल काला और सफ़ेद उपयोग करता है, `Black` और `White` एकल रंग को मजबूर करता है, `Color` सामान्य रंग संरक्षित रखता है, और `Hidden` ब्लैक‑एंड‑वाइट मोड में आकृति को छोड़ देता है। `NotDefined` का अर्थ है कि कोई आकृति‑स्तर मोड असाइन नहीं किया गया है।

नीचे दिया गया Python कोड एक रंगीन आकृति बनाता है और ब्लैक‑एंड‑वाइट डिस्प्ले मोड में इसे ग्रे दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # रंग मोड में नारंगी भराव रखें, लेकिन ब्लैक‑एंड‑वाइट मोड में आकृति को ग्रे रंग में रेंडर करें।
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

सामान्य रंग मोड में, आयत अपनी नारंगी फ़िल को बनाए रखता है। ब्लैक‑एंड‑वाइट डिस्प्ले कार्यप्रवाह में, इसका मोड `Gray` होने के कारण ग्रे रंग दिखाता है। यह आपको पूरी‑रंग प्रस्तुति को बरकरार रखते हुए प्रिंटिंग, प्रीव्यू या अन्य कार्यप्रवाहों के लिये अलग दिखावट परिभाषित करने की सुविधा देता है।

## **फ़ॉर्मेटिंग रीसेट करें**

नीचे दिया गया Python कोड दिखाता है कि कैसे स्लाइड की फ़ॉर्मेटिंग रीसेट की जा सकती है और [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) पर सभी प्लेसहोल्डर वाली आकृतियों की स्थिति, आकार और फ़ॉर्मेटिंग को उनके डिफ़ॉल्ट सेटिंग्स पर लाया जा सकता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # लेआउट पर प्लेसहोल्डर वाले प्रत्येक आकृति को स्लाइड पर रीसेट करें।
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या आकृति फ़ॉर्मेटिंग अंतिम प्रस्तुति फ़ाइल के आकार को प्रभावित करती है?**

केवल न्यूनतम रूप से। एम्बेडेड छवियां और मीडिया अधिकांश फ़ाइल स्थान लेते हैं, जबकि रंग, प्रभाव और ग्रेडिएंट जैसी आकृति पैरामीटर मेटाडेटा के रूप में संग्रहित होते हैं और व्यावहारिक रूप से अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे उन आकृतियों का पता लगा सकता हूँ जो समान फ़ॉर्मेटिंग साझा करती हैं ताकि उन्हें समूहित कर सकूँ?**

प्रत्येक आकृति की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनकी शैलियों को समान मानें और उन आकृतियों को तार्किक रूप से समूहित करें, जिससे बाद में शैली प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकृति शैलियों का एक सेट अलग फ़ाइल में सहेज कर अन्य प्रस्तुतियों में पुन: उपयोग कर सकता हूँ?**

हां। वांछित शैलियों वाले नमूना आकृतियों को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में रखें। नई प्रस्तुति बनाते समय टेम्पलेट खोलें, आवश्यक शैली वाली आकृतियों को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो उनकी फ़ॉर्मेटिंग पुनः लागू करें।