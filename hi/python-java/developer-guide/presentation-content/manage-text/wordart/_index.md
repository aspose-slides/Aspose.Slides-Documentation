---
title: Python के माध्यम से Java में WordArt इफ़ेक्ट्स बनाएं और लागू करें
linktitle: WordArt
type: docs
weight: 110
url: /hi/python-java/wordart/
keywords:
- WordArt
- WordArt बनाएं
- WordArt टेम्प्लेट
- WordArt इफ़ेक्ट
- छाया इफ़ेक्ट
- परावर्तन इफ़ेक्ट
- चमक इफ़ेक्ट
- WordArt ट्रांसफ़ॉर्मेशन
- 3D इफ़ेक्ट
- बाहरी छाया इफ़ेक्ट
- अन्तरिक छाया इफ़ेक्ट
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में WordArt इफ़ेक्ट्स बनाएं और अनुकूलित करें। यह चरण-दर-चरण गाइड डेवलपर्स को Python via Java में पेशेवर टेक्स्ट के साथ प्रस्तुतियों को बेहतर बनाने में मदद करता है।"
---
## **अवलोकन**

WordArt इफ़ेक्ट्स आपको टेक्स्ट को फ़िल, रूपरेखा, शैडो, प्रतिबिंब, चमक, ट्रांसफ़ॉर्मेशन और 3D फॉर्मेटिंग के साथ शैलीबद्ध करने देते हैं। यह लेख Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों में इन इफ़ेक्ट्स को बनाने और अनुकूलित करने के तरीके को समझाता है, बिना Microsoft Office स्थापित किए।

## **एक साधारण WordArt टेम्पलेट बनाएं और इसे टेक्स्ट पर लागू करें**

निम्नलिखित उदाहरण टेक्स्ट, फ़ॉन्ट, पैटर्न फ़िल और रूपरेखा सेट करके एक साधारण WordArt शैली बनाते हैं।

प्रत्येक उदाहरण एक नई प्रस्तुति बनाता है और उसकी पहली स्लाइड में एक आयत जोड़ता है; किसी इनपुट फ़ाइल की आवश्यकता नहीं है। पहला उदाहरण टेक्स्ट को "Aspose.Slides" सेट करता है। आकार की स्थिति और आयाम पॉइंट्स में मापे जाते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

फ़ॉर्मेटिंग को अधिक स्पष्ट बनाने के लिए फ़ॉन्ट को 36 पॉइंट्स पर Arial Black सेट करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

डार्क ऑरेंज फ़ोरग्राउंड और सफ़ेद बैकग्राउंड के साथ एक [SmallGrid](https://reference.aspose.com/slides/hi/python-java/aspose.slides/patternstyle/#SmallGrid) पैटर्न लागू करें, फिर 1 पॉइंट की चौड़ाई के साथ काली टेक्स्ट रूपरेखा जोड़ें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

![सरल WordArt टेम्पलेट](WordArt_template.png)

## **अन्य WordArt इफ़ेक्ट्स लागू करें**

निम्नलिखित उदाहरण दिखाते हैं कि टेक्स्ट पर शैडो, प्रतिबिंब, चमक, ट्रांसफ़ॉर्मेशन और 3D इफ़ेक्ट्स कैसे लागू किए जाएँ।

### **बाहरी शैडो इफ़ेक्ट लागू करें**

एक बाहरी शैडो टेक्स्ट के पीछे शैडो रखकर गहराई जोड़ता है। आप इसके रंग, दिशा, दूरी, ब्लर रेडियस, स्केल और स्क्यू को अनुकूलित कर सकते हैं।

यह उदाहरण [enableOuterShadowEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) को कॉल करता है और 4‑पॉइंट ब्लर रेडियस, 230‑डिग्री दिशा और 30‑पॉइंट दूरी वाला काला शैडो सेट करता है। स्केल मान 100 शैडो का आकार बरकरार रखता है, जबकि क्षैतिज स्क्यू इसे 20 डिग्री टिल्ट करता है। अल्फा ट्रांसफ़ॉर्म इसकी अपारदर्शिता को 32 % सेट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

![बाहरी शैडो इफ़ेक्ट](outer_shadow_effect.png)

{{% alert color="info" title="ध्यान दें" %}}
- जब बाहरी और प्रीसेट शैडो एक साथ उपयोग किए जाते हैं, तो केवल बाहरी शैडो लागू होता है।
- यदि बाहरी और अन्तरिक शैडो एक साथ उपयोग किए जाएँ, तो परिणामस्वरूप इफ़ेक्ट PowerPoint संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में इफ़ेक्ट दोगुना हो जाता है, जबकि PowerPoint 2007 में केवल बाहरी शैडो लागू होता है।
{{% /alert %}}

### **परावर्तन इफ़ेक्ट लागू करें**

एक परावर्तन टेक्स्ट की प्रतिबिंबित प्रति बनाता है। उसकी स्थिति, स्केल, ब्लर और अपारदर्शिता को समायोजित करके उसकी उपस्थिति को नियंत्रित किया जा सकता है।

यह उदाहरण [enableReflectionEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effectformat/#enableReflectionEffect) को कॉल करता है और -100 % स्केल के साथ परावर्तन को लंबवत उलटता है। यह 0.5‑पॉइंट ब्लर रेडियस और 4.72‑पॉइंट दूरी का उपयोग करता है। अपारदर्शिता 0 % और 60 % स्थितियों के बीच 60 % से 0.9 % तक घटती है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

![परावर्तन इफ़ेक्ट](reflection_effect.png)

### **चमक इफ़ेक्ट लागू करें**

एक चमक टेक्स्ट के चारों ओर एक नरम रंगीन रूपरेखा जोड़ता है। उसके रंग, अपारदर्शिता और रेडियस को समायोजित करके इफ़ेक्ट को नियंत्रित किया जा सकता है।

यह उदाहरण [enableGlowEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effectformat/#enableGlowEffect) को कॉल करता है और 54 % अपारदर्शिता और 7 पॉइंट रेडियस के साथ लाल चमक लागू करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

![चमक इफ़ेक्ट](glow_effect.png)

### **WordArt ट्रांसफ़ॉर्मेशन लागू करें**

WordArt ट्रांसफ़ॉर्मेशन टेक्स्ट के ब्लॉक को मोड़ता, खींचता या विकृत करता है।

[setTransform](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setTransform) को [ArchUpPour](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textshapetype/#ArchUpPour) पर सेट करके पूरे टेक्स्ट फ्रेम को ऊपर की ओर घुमाया जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

![WordArt ट्रांसफ़ॉर्मेशन](transform_effect.png)

{{% alert color="info" title="ध्यान दें" %}}
Aspose.Slides for Python via Java पूर्वनिर्धारित [transformation types](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textshapetype/) का एक सेट प्रदान करता है।
{{% /alert %}}

### **आकार और टेक्स्ट पर 3D इफ़ेक्ट्स लागू करें**

आप आकार या उसके टेक्स्ट पर 3D इफ़ेक्ट्स लागू कर सकते हैं। बीवेल, एक्सट्रूज़न, लाइटिंग और कैमरा सेटिंग्स परिणामस्वरूप उपस्थिति को नियंत्रित करती हैं।

निम्नलिखित उदाहरण [ThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/) का उपयोग करके आयत में गोलाकार बीवेल, नारंगी एक्सट्रूज़न और गहरा लाल कंटूर जोड़ता है। बीवेल आयाम, एक्सट्रूज़न ऊँचाई, कंटूर चौड़ाई और गहराई पॉइंट्स में मापी जाती हैं। प्लास्टिक सामग्री, Z-अक्ष के चारों ओर 40 डिग्री घुमाई गई संतुलित लाइटिंग, और परस्पेक्टिव कैमरा उसकी उपस्थिति को निर्धारित करते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

![आकार 3D इफ़ेक्ट](shape_3D_effect.png)

यह उदाहरण [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#getThreeDFormat) के माध्यम से टेक्स्ट पर समान 3D फ़ॉर्मेटिंग लागू करता है। छोटे बीवेल अक्षर की किनारों को आकार देते हैं, जबकि एक्सट्रूज़न और लाइटिंग टेक्स्ट को गहराई देती है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

![टेक्स्ट 3D इफ़ेक्ट](text_3D_effect.png)

{{% alert color="info" title="ध्यान दें" %}}
टेक्स्ट या उसके आकार पर 3D इफ़ेक्ट्स का उपयोग—और इन इफ़ेक्ट्स के बीच का इंटरैक्शन—विशिष्ट नियमों द्वारा नियंत्रित होता है। ऐसे दृश्य पर विचार करें जिसमें टेक्स्ट और उसे सम्मिलित करने वाला आकार दोनों शामिल हों। एक 3D इफ़ेक्ट में वस्तु का 3D प्रतिनिधित्व और वह दृश्य जिसमें वह स्थित है, दोनों शामिल होते हैं।

- यदि दोनों आकार और टेक्स्ट के लिए दृश्य सेट किया गया है, तो आकार का दृश्य प्राथमिकता लेता है और टेक्स्ट का दृश्य अनदेखा हो जाता है।
- यदि आकार के पास अपना स्वयं का दृश्य नहीं है लेकिन उसका 3D प्रतिनिधित्व है, तो टेक्स्ट का दृश्य उपयोग किया जाता है।
- यदि आकार में कोई 3D इफ़ेक्ट नहीं है, तो उसे समतल माना जाता है, और 3D इफ़ेक्ट केवल टेक्स्ट पर लागू किया जाता है।

इन व्यवहारों का संबंध [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getLightRig) और [ThreeDFormat.getCamera](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getCamera) मेथड्स से है।
{{% /alert %}}

टेक्स्ट को समतल और पढ़ने योग्य रखने के साथ-साथ उसके आकार की 3D फ़ॉर्मेटिंग को बनाए रखने के लिए, दोनों सेटिंग्स की तुलना और पूर्ण Python उदाहरण के लिए देखें [Keep Text Flat on a 3D Shape](/slides/hi/python-java/3d-presentation/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं WordArt इफ़ेक्ट्स को विभिन्न फ़ॉन्ट्स या स्क्रिप्ट्स (जैसे, अरबी, चीनी) के साथ उपयोग कर सकता हूँ?**

हाँ, Aspose.Slides for Python via Java यूनिकोड का समर्थन करता है और सभी प्रमुख फ़ॉन्ट्स और स्क्रिप्ट्स के साथ काम करता है। शैडो, फ़िल, रूपरेखा जैसे WordArt इफ़ेक्ट्स भाषा से स्वतंत्र रूप से लागू किए जा सकते हैं, हालांकि फ़ॉन्ट की उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट्स पर निर्भर हो सकती है।

**क्या मैं स्लाइड मास्टर तत्वों पर WordArt इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप मास्टर स्लाइड्स के आकारों, शीर्षक प्लेसहोल्डर्स, फ़ुटर या बैकग्राउंड टेक्स्ट पर WordArt इफ़ेक्ट्स लागू कर सकते हैं। मास्टर लेआउट में किए गए परिवर्तन सभी संबंधित स्लाइड्स में प्रतिबिंबित होंगे।

**क्या WordArt इफ़ेक्ट्स प्रस्तुति फ़ाइल के आकार को प्रभावित करते हैं?**

थोड़ा। शैडो, चमक और ग्रेडिएंट फ़िल जैसे WordArt इफ़ेक्ट्स फ़ॉर्मेटिंग मेटाडेटा जोड़ते हैं, जिससे फ़ाइल आकार में हल्का वृद्धि हो सकती है, लेकिन आमतौर पर अंतर नगण्य होता है।

**क्या मैं प्रस्तुति को सहेजे बिना WordArt इफ़ेक्ट्स के परिणाम का पूर्वावलोकन कर सकता हूँ?**

हाँ, आप WordArt वाले स्लाइड्स को इमेज (जैसे PNG, JPEG) में रेंडर कर सकते हैं — [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) का उपयोग करके, या व्यक्तिगत आकारों को [Shape.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) से रेंडर कर सकते हैं। इससे आप संपूर्ण प्रस्तुति को सहेजने या निर्यात करने से पहले मेमोरी या स्क्रीन पर परिणाम का पूर्वावलोकन कर सकते हैं।