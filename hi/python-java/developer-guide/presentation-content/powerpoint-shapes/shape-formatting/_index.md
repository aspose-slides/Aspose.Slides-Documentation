---
title: "Python के माध्यम से Java में PowerPoint आकृतियों को स्वरूपित करें"
linktitle: "आकृति स्वरूपण"
type: docs
weight: 20
url: /hi/python-java/shape-formatting/
keywords:
- "आकृति स्वरूपित करें"
- "लाइन स्वरूपित करें"
- "स्केच प्रभाव"
- "आकृति रेखा स्केच"
- "जॉइन शैली स्वरूपित करें"
- "ग्रेडिएंट फ़िल"
- "पैटर्न फ़िल"
- "पिक्चर फ़िल"
- "टेक्सचर फ़िल"
- "सॉलिड कलर फ़िल"
- "आकृति पारदर्शिता"
- "ब्लैक-एंड-व्हाइट आकृति रेंडरिंग"
- "ग्रेस्केल आकृति रेंडरिंग"
- "आकृति घुमाएँ"
- "3डी बिवेल प्रभाव"
- "3डी घूर्णन प्रभाव"
- "फ़ॉर्मेट रीसेट करें"
- "PowerPoint"
- "प्रेजेंटेशन"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides का उपयोग करके Python के माध्यम से Java में PowerPoint आकृतियों को स्वरूपित करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिए फ़िल, लाइन और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में आकृतियां जोड़ सकते हैं। चूंकि आकृतियां रेखाओं से बनी होती हैं, आप उनके रूपरेखा को बदलकर या प्रभाव लागू करके उन्हें स्वरूपित कर सकते हैं। अतिरिक्त रूप से, आप आकृतियों के अंदरूनी भाग को भरने की सेटिंग्स निर्दिष्ट करके स्वरूपित कर सकते हैं।

![आकृति स्वरूपण PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java क्लासेस और मेथड्स प्रदान करता है जो आपको PowerPoint में उपलब्ध वही विकल्पों का उपयोग करके आकृतियों को स्वरूपित करने की अनुमति देता है।

## **रेखाओं का स्वरूपण**

Aspose.Slides का उपयोग करके, आप किसी आकृति के लिए कस्टम लाइन शैली निर्दिष्ट कर सकते हैं। निम्नलिखित चरण प्रक्रिया को रेखांकित करते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की [line style](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई सेट करें।
1. लाइन की [dash style](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linedashstyle/) सेट करें।
1. आकृति के लिए लाइन रंग सेट करें।
1. परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित कोड एक आयत [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) को स्वरूपित करने का प्रदर्शन करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Rectangle आकृति के लिए फ़िल रंग सेट करें।
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Rectangle की रेखाओं पर स्वरूपण लागू करें।
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Rectangle की रेखा का रंग सेट करें।
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![प्रेजेंटेशन में स्वरूपित रेखाएँ](formatted-lines.png)

## **आकृति रेखाओं पर स्केच प्रभाव लागू करें**

एक स्केच प्रभाव आकृति की रेखा को हाथ से ड्रा किया हुआ दिखाता है। लाइन सेटिंग्स तक पहुँचने के लिए [Shape.getLineFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getLineFormat) का उपयोग करें, स्केच सेटिंग्स तक पहुँचने के लिए [LineFormat.getSketchFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/lineformat/#getSketchFormat) का उपयोग करें, और मान चुनने के लिए [SketchFormat.setSketchType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sketchformat/#setSketchType) का उपयोग करके [LineSketchType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linesketchtype/) एन्नुमरेशन से चुनें।

निम्नलिखित Python कोड एक [LineSketchType.Curved](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linesketchtype/#Curved) प्रभाव लागू करने, स्पष्ट रूप से असाइन किए गए मान को पढ़ने, और [LineSketchType.None_](https://reference.aspose.com/slides/hi/python-java/aspose.slides/linesketchtype/#None) के साथ प्रभाव हटाने को दर्शाता है:

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

    # आकृति के लाइन फ़ॉर्मेट और उसके स्केच फ़ॉर्मेट तक पहुँचें.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # एक स्केच प्रभाव लागू करें.
    sketch_format.setSketchType(LineSketchType.Curved)

    # आकृति को सीधे असाइन किए गए स्केच प्रभाव को पढ़ें.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # स्केच प्रभाव को हटाएँ.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sketchformat/#getSketchType) द्वारा लौटाई गई वैल्यू सीधे आकृति को असाइन की गई सेटिंग को दर्शाती है। यदि लाइन फ़ॉर्मेटिंग थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में मिल सकती है, तो [LineFormat.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/lineformat/#getEffective) का उपयोग करें, `LineFormatEffectiveData.getSketchFormat` तक पहुंचें, और `SketchFormatEffectiveData.getSketchType` पढ़ें। प्रभावी वैल्यू विरासत के समाधान के बाद वास्तविक लागू फ़ॉर्मेटिंग को प्रतिबिंबित करती है:

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

## **जॉइन शैली का स्वरूपण**

यहां तीन जॉइन प्रकार विकल्प हैं:

* गोल
* माइटर
* बिवेल

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को किसी कोण पर (जैसे आकृति के कोने पर) जोड़ता है, तो वह **गोल** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोणों वाली आकृति बना रहे हैं, तो आप **माइटर** विकल्प को प्राथमिकता दे सकते हैं।

![प्रेजेंटेशन में जॉइन शैली](join-style-powerpoint.png)

निम्नलिखित Python कोड दर्शाता है कि कैसे ऊपर दिखाए गए चित्र में Miter, Bevel, और Round जॉइन प्रकार सेटिंग्स का उपयोग करके तीन आयतें बनाई गईं:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें.
    slide = presentation.getSlides().get_Item(0)

    # Rectangle प्रकार की तीन ऑटो शैप्स जोड़ें.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # प्रत्येक आयत आकृति के लिए फ़िल रंग सेट करें.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # लाइन की चौड़ाई सेट करें.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # प्रत्येक आयत की रेखा का रंग सेट करें.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # जॉइन शैली सेट करें.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # प्रत्येक आयत में टेक्स्ट जोड़ें.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # PPTX फ़ाइल को डिस्क पर सहेजें.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ग्रेडिएंट फ़िल**

PowerPoint में, Gradient Fill एक स्वरूपण विकल्प है जो आपको एक आकृति पर लगातार रंगों का मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंगों को इस तरह लागू कर सकते हैं कि एक धीरे-धीरे दूसरे में मिल जाता है।

PowerPoint में ग्रेडिएंट फ़िल को Aspose.Slides का उपयोग करके कैसे लागू करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) को `Gradient` पर सेट करें।
1. ग्रेडिएंट स्टॉप कलेक्शन द्वारा उजागर [GradientFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/gradientformat/) क्लास के [addPresetColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/gradientstopcollection/#addPresetColor) मेथड का उपयोग करके परिभाषित स्थितियों के साथ अपनी दो पसंदीदा रंग जोड़ें।
1. परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड एक दीर्घवृत्त पर ग्रेडिएंट फ़िल प्रभाव लागू करने का प्रदर्शन करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # Ellipse प्रकार की एक ऑटो शैप जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Ellipse पर ग्रेडिएंट स्वरूपण लागू करें।
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

![ग्रेडिएंट फ़िल वाली दीर्घवृत्त](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में, Pattern Fill एक स्वरूपण विकल्प है जो आपको दो‑रंगीय डिज़ाइन—जैसे बिंदु, धारी, क्रॉसहैच, या चेक—आकृति पर लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियों को प्रदान करता है जिन्हें आप आकृतियों पर लागू करके प्रस्तुतियों की दृश्य आकर्षण बढ़ा सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप इसके लिए उपयोग किए जाने वाले सटीक रंग निर्धारित कर सकते हैं।

Aspose.Slides का उपयोग करके आकृति पर पैटर्न फ़िल कैसे लागू करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) को `Pattern` पर सेट करें।
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न की [Background Color](https://reference.aspose.com/slides/hi/python-java/aspose.slides/patternformat/#getBackColor) सेट करें।
1. पैटर्न की [Foreground Color](https://reference.aspose.com/slides/hi/python-java/aspose.slides/patternformat/#getForeColor) सेट करें।
1. परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड एक आयत पर पैटर्न फ़िल लागू करने का प्रदर्शन करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # फ़िल प्रकार को Pattern पर सेट करें।
    shape.getFillFormat().setFillType(FillType.Pattern)

    # पैटर्न शैली सेट करें।
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # पैटर्न की पृष्ठभूमि और अग्रभूमि के रंग सेट करें।
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पैटर्न फ़िल वाली आयत](pattern-fill.png)

## **पिक्चर फ़िल**

PowerPoint में, Picture Fill एक स्वरूपण विकल्प है जो आपको आकृति के भीतर एक छवि सम्मिलित करने की अनुमति देता है — प्रभावी रूप से छवि को आकृति की पृष्ठभूमि के रूप में उपयोग करता है।

Aspose.Slides का उपयोग करके आकृति पर पिक्चर फ़िल कैसे लागू करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) को `Picture` पर सेट करें।
1. पिक्चर फ़िल मोड को `Tile` (या कोई अन्य वांछित मोड) पर सेट करें।
1. जिस छवि का उपयोग करना चाहते हैं, उससे एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं।
1. छवि को `SlidesPicture.setImage` मेथड को पास करें।
1. परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास "lotus.png" फ़ाइल है जिसमें निम्नलिखित चित्र है:

![लॉटस चित्र](lotus.png)

निम्नलिखित Python कोड आकृति को पिक्चर फ़िल के साथ भरने का प्रदर्शन करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # फ़िल प्रकार को Picture पर सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture)

    # पिक्चर फ़िल मोड सेट करें।
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # एक छवि लोड करें और उसे प्रेजेंटेशन संसाधनों में जोड़ें।
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

![पिक्चर फ़िल वाली आकृति](picture-fill.png)

### **टाइल चित्र को टेक्सचर के रूप में सेट करें**

यदि आप टाइल्ड चित्र को टेक्सचर के रूप में सेट करना और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [PictureFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/) क्लास के निम्नलिखित मेथड्स का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#setPictureFillMode): चित्र फ़िल मोड सेट करता है — `Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#setTileAlignment): आकृति के भीतर टाइलों की संरेखण निर्दिष्ट करता है।
- [setTileFlip](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#setTileFlip): टाइल को क्षैतिज, लंबवत या दोनों रूपों में फ़्लिप करने को नियंत्रित करता है।
- [setTileOffsetX](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#setTileOffsetX): टाइल का क्षैतिज ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#setTileOffsetY): टाइल का लंबवत ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#setTileScaleX): टाइल का क्षैतिज स्केल प्रतिशत में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/#setTileScaleY): टाइल का लंबवत स्केल प्रतिशत में परिभाषित करता है।

निम्नलिखित कोड नमूना दिखाता है कि कैसे टाइल्ड पिक्चर फ़िल के साथ एक आयत आकृति जोड़ें और टाइल विकल्प कॉन्फ़िगर करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    first_slide = presentation.getSlides().get_Item(0)

    # एक आयत ऑटो शैप जोड़ें।
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # आकृति के फ़िल प्रकार को Picture पर सेट करें।
    shape.getFillFormat().setFillType(FillType.Picture)

    # छवि लोड करें और उसे प्रेजेंटेशन संसाधनों में जोड़ें।
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # छवि को आकृति को असाइन करें।
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # पिक्चर फ़िल मोड और टाइलिंग प्रॉपर्टीज़ को कॉन्फ़िगर करें।
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

## **सॉलिड कलर फ़िल**

PowerPoint में, Solid Color Fill एक स्वरूपण विकल्प है जो आकृति को एक ही समान रंग से भरता है। यह साधारण पृष्ठभूमि रंग ग्रेडिएंट, टेक्सचर या पैटर्न के बिना लागू किया जाता है।

Aspose.Slides का उपयोग करके आकृति पर सॉलिड कलर फ़िल कैसे लागू करें, नीचे चरण दिए गए हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) को `Solid` पर सेट करें।
1. आकृति को अपनी इच्छित फ़िल रंग सौंपें।
1. परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड एक PowerPoint स्लाइड में आयत पर सॉलिड कलर फ़िल लागू करने का प्रदर्शन करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # फ़िल प्रकार को Solid पर सेट करें।
    shape.getFillFormat().setFillType(FillType.Solid)

    # फ़िल रंग सेट करें।
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![सॉलिड कलर फ़िल वाली आकृति](solid-color-fill.png)

## **पारदर्शिता सेट करें**

PowerPoint में, जब आप आकृतियों पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिए पारदर्शिता स्तर भी सेट कर सकते हैं। उच्च पारदर्शिता मान आकृति को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे की वस्तुएं आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल में उपयोग किए गए रंग के अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने की अनुमति देता है। इसे इस प्रकार करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) को `Solid` पर सेट करें।
1. पारदर्शिता के साथ रंग परिभाषित करने के लिए [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) का उपयोग करें (alpha घटक पारदर्शिता को नियंत्रण करता है)।
1. प्रेजेंटेशन को सहेजें।

निम्नलिखित Python कोड एक आयत पर पारदर्शी फ़िल रंग लागू करने का प्रदर्शन करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # एक ठोस आयत ऑटो शैप जोड़ें।
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # ठोस शैप के ऊपर एक पारदर्शी आयत ऑटो शैप जोड़ें।
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

![पारदर्शी आकृति](shape-transparency.png)

## **आकृतियों को घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकृतियों को घुमाने की सुविधा देता है। यह विशिष्ट संरेखण या डिज़ाइन आवश्यकताओं वाले दृश्य तत्वों को स्थित करने में उपयोगी हो सकता है।

स्लाइड पर आकृति को घुमाने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
1. आकृति की घूर्णन प्रॉपर्टी को इच्छित कोण पर सेट करें।
1. प्रेजेंटेशन को सहेजें।

निम्नलिखित Python कोड आकृति को 5 डिग्री से घुमाने का प्रदर्शन करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
presentation = Presentation()
try:
    # पहली स्लाइड प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # Rectangle प्रकार की एक ऑटो शैप जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # आकृति को 5 डिग्री घुमाएँ।
    shape.setRotation(5)

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("shape_rotation.ppta", SaveFormat.Pptx)
finally:
    presentation.save

```

परिणाम:

![आकृति घूर्णन](shape-rotation.png)

## **3D बिवेल प्रभाव जोड़ें**

Aspose.Slides आपको आकृतियों पर 3D बिवेल प्रभाव लागू करने की अनुमति देता है, जिससे आप उनकी [ThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर कर सकते हैं।

आकृति पर 3D बिवेल प्रभाव जोड़ने के लिए चरण निम्नलिखित हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
1. बिवेल सेटिंग्स को परिभाषित करने के लिए आकृति की [ThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/) कॉन्फ़िगर करें।
1. प्रेजेंटेशन को सहेजें।

निम्नलिखित Python कोड एक आकृति पर 3D बिवेल प्रभाव लागू करने को दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Presentation क्लास का एक इंस्टेंस बनाएं।
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

    # प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![3D बिवेल प्रभाव](3D-bevel-effect.png)

## **3D घूर्णन प्रभाव जोड़ें**

Aspose.Slides आपको आकृतियों पर 3D घूर्णन प्रभाव लागू करने की अनुमति देता है, जिससे आप उनकी [ThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर कर सकते हैं।

आकृति पर 3D घूर्णन प्रभाव लागू करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
1. 3D घूर्णन को परिभाषित करने के लिए [setCameraType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/camera/#setCameraType) और [setLightType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/lightrig/#setLightType) मेथड्स का उपयोग करें।
1. प्रेजेंटेशन को सहेजें।

निम्नलिखित Python कोड एक आकृति पर 3D घूर्णन प्रभाव लागू करने को दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Presentation क्लास का एक इंस्टेंस बनाएं।
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![3D घूर्णन प्रभाव](3D-rotation-effect.png)

## **आकृतियों के लिए ब्लैक‑एंड‑व्हाइट रेंडरिंग नियंत्रित करें**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#setBlackWhiteMode) मेथड निर्धारित करता है कि व्यक्तिगत आकृति को ब्लैक‑एंड‑व्हाइट मोड में देखा या प्रोसेस किया जाने पर कैसे रेंडर किया जाए। यह स्वयं ब्लैक‑एंड‑व्हाइट डिस्प्ले को सक्षम नहीं करता, और सामान्य रंग मोड में आकृति के फ़िल, लाइन या अन्य फ़ॉर्मेटिंग को नहीं बदलता।

वांछित व्यवहार चुनने के लिए आप [BlackWhiteMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/blackwhitemode/) क्लास से मान उपयोग कर सकते हैं। उदाहरण के लिए, `Automatic` रेंडरिंग एप्लिकेशन को रूपांतरण चुनने देता है, `Gray` और `LightGray` ग्रे रंग का उपयोग करते हैं, `BlackWhite` केवल काला और सफेद उपयोग करता है, `Black` और `White` एकल रंग को बलपूर्वक लागू करते हैं, `Color` सामान्य रंग को बनाए रखता है, और `Hidden` ब्लैक‑एंड‑व्हाइट मोड में आकृति को हटाता है। `NotDefined` का अर्थ है कि कोई आकृति‑स्तरीय मोड असाइन नहीं किया गया है।

निम्नलिखित Python कोड एक रंगीन आकृति बनाता है और उसे ब्लैक‑एंड‑व्हाइट डिस्प्ले मोड में ग्रे दिखाता है:

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

    # रंग मोड में ऑरेंज फ़िल रखें, लेकिन ब्लैक-एंड-व्हाइट मोड में आकृति को ग्रे रंग में रेंडर करें।
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

सामान्य रंग मोड में, आयत अपना नारंगी फ़िल रखती है। ब्लैक‑एंड‑व्हाइट वर्कफ़्लो में, उसका मोड `Gray` होने के कारण ग्रे रंग दिखता है। इससे आप पूरी‑रंग की स्लाइड को संरक्षित रख सकते हैं और प्रिंटिंग, प्रीव्यू या अन्य वर्कफ़्लो में अलग दिखावट को परिभाषित कर सकते हैं जो ब्लैक‑एंड‑व्हाइट डिस्प्ले सेटिंग्स का सम्मान करते हैं।

## **फ़ॉर्मेट रीसेट करें**

निम्नलिखित Python कोड स्लाइड की फ़ॉर्मेटिंग को रीसेट करने और सभी प्लेसहोल्डर वाले आकृतियों की स्थिति, आकार और फ़ॉर्मेटिंग को उनके डिफ़ॉल्ट सेटिंग्स पर लाने को दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # लेआउट में प्लेसहोल्डर वाली प्रत्येक आकृति को स्लाइड पर रीसेट करें।
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**क्या आकृति फ़ॉर्मेटिंग अंतिम प्रेजेंटेशन फ़ाइल आकार को प्रभावित करती है?**

केवल न्यूनतम रूप से। एंबेडेड छवियां और मीडिया अधिकांश फ़ाइल स्थान लेते हैं, जबकि रंग, प्रभाव और ग्रेडिएंट जैसी आकृति पैरामीटर मेटाडेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे पता लगा सकता हूँ कि स्लाइड पर कौन सी आकृतियों का फ़ॉर्मेटिंग समान है ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकृति की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन और प्रभाव सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके शैलियों को समान मानें और उन आकृतियों को तर्कसंगत रूप से समूहित करें, जिससे बाद में शैली प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकृति शैलियों का सेट एक अलग फ़ाइल में सहेज सकता हूँ ताकि अन्य प्रेजेंटेशन में पुनः उपयोग कर सकूँ?**

हाँ। वांछित शैलियों वाली नमूना आकृतियों को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में सहेजें। नई प्रेजेंटेशन बनाते समय टेम्पलेट खोलें, आवश्यक शैली वाली आकृतियों को क्लोन करें, और जहाँ भी जरूरत हो फ़ॉर्मेटिंग पुनः लागू करें।