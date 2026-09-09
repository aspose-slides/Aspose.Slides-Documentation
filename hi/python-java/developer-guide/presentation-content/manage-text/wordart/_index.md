---
title: Python via Java में WordArt प्रभाव बनाएं और लागू करें
linktitle: WordArt
type: docs
weight: 110
url: /hi/python-java/wordart/
keywords:
- WordArt
- WordArt बनाएं
- WordArt टेम्प्लेट
- WordArt प्रभाव
- छाया प्रभाव
- प्रतिबिंब प्रभाव
- चमक प्रभाव
- WordArt रूपांतरण
- 3D प्रभाव
- बाहरी छाया प्रभाव
- आंतरिक छाया प्रभाव
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में WordArt प्रभाव बनाएं और अनुकूलित करें। यह चरण-दर-चरण मार्गदर्शिका डेवलपर्स को Python via Java में पेशेवर टेक्स्ट के साथ प्रस्तुतियों को बेहतर बनाने में सहायता करती है।"
---
## **सारांश**

WordArt प्रभाव आपको अपने PowerPoint प्रस्तुतियों में दृश्यात्मक रूप से आकर्षक, शैलीबद्ध टेक्स्ट जोड़ने की अनुमति देते हैं। Aspose.Slides के साथ, डेवलपर्स प्रोग्रामेटिक रूप से WordArt को बनाकर, कस्टमाइज़ करके और प्रबंधित करके Microsoft PowerPoint की तरह—बिना Office स्थापित किए—काम कर सकते हैं। यह लेख WordArt के साथ काम करने का सार प्रदान करता है, जिसमें टेक्स्ट ट्रांसफ़ॉर्मेशन, फ़िल स्टाइल, रूपरेखा, छाया और अन्य फ़ॉर्मेटिंग विकल्पों को लागू करने के तरीके शामिल हैं ताकि आपकी प्रस्तुति सामग्री अधिक अभिव्यक्तिपूर्ण और आकर्षक बन सके। WordArt आपको टेक्स्ट को एक ग्राफ़िकल ऑब्जेक्ट के रूप में मानने की अनुमति देता है। यह प्रभाव या विशेष बदलावों का समूह है जो टेक्स्ट पर लागू होते हैं ताकि वह अधिक आकर्षक या उल्लेखनीय हो।

## **एक सरल WordArt टेम्प्लेट बनाएँ और इसे टेक्स्ट पर लागू करें**

**Aspose.Slides का उपयोग करके**

पहले, हम इस Python कोड का उपयोग करके सरल टेक्स्ट बनाते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
अगला, प्रभाव को अधिक स्पष्ट बनाने के लिए फ़ॉन्ट आकार बढ़ाएँ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Microsoft PowerPoint का उपयोग करके**

Microsoft PowerPoint में WordArt प्रभाव मेनू पर जाएँ:

![PowerPoint में WordArt प्रभाव मेनू](image-20200930113926-1.png)

दाएँ मेनू से आप एक पूर्वनिर्धारित WordArt प्रभाव चुन सकते हैं। बाएँ मेनू से आप नए WordArt की सेटिंग्स निर्दिष्ट कर सकते हैं।

यहाँ कुछ उपलब्ध पैरामीटर या विकल्प हैं:

![WordArt फ़ॉर्मेटिंग विकल्प](image-20200930114015-3.png)

**Aspose.Slides का उपयोग करके**

यहाँ, हम टेक्स्ट पर [PatternStyle.SmallGrid](https://reference.aspose.com/slides/hi/python-java/aspose.slides/patternstyle/#SmallGrid) पैटर्न फ़िल लागू करते हैं और इस कोड के साथ काली टेक्स्ट बॉर्डर जोड़ते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

परिणामी टेक्स्ट:

![पैटर्न फ़िल और काली रूपरेखा के साथ टेक्स्ट](image-20200930114108-4.png)

## **अन्य WordArt प्रभाव लागू करना**

**Microsoft PowerPoint का उपयोग करके**

प्रोग्राम इंटरफ़ेस से आप इन प्रभावों को टेक्स्ट, टेक्स्ट ब्लॉक, शेप या समान तत्व पर लागू कर सकते हैं:

![PowerPoint में टेक्स्ट और शेप प्रभाव](image-20200930114129-5.png)

उदाहरण के लिए, Shadow, Reflection और Glow प्रभाव टेक्स्ट पर लागू किए जा सकते हैं; 3D Format और 3D Rotation प्रभाव टेक्स्ट ब्लॉक पर लागू किए जा सकते हैं; Soft Edges प्रभाव शेप पर लागू किया जा सकता है (जब 3D Format प्रभाव सेट न हो तब भी इसका प्रभाव रहता है)।

### **छाया प्रभाव लागू करना**

निम्नलिखित Python कोड केवल टेक्स्ट पर छाया प्रभाव लागू करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Aspose.Slides API तीन प्रकार की छाया को सपोर्ट करता है: [OuterShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/innershadow/), और [PresetShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presetshadow/)।

[PresetShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presetshadow/) के साथ आप प्रीसेट मानों का उपयोग करके टेक्स्ट पर छाया लागू कर सकते हैं।

**Microsoft PowerPoint का उपयोग करके**

PowerPoint में आप केवल एक प्रकार की छाया उपयोग कर सकते हैं। यहाँ एक उदाहरण है:

![PowerPoint में छाया सेटिंग्स](image-20200930114225-6.png)

**Aspose.Slides का उपयोग करके**

Aspose.Slides वास्तव में आपको एक साथ दो प्रकार की छाया लागू करने की अनुमति देता है: [InnerShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/innershadow/) और [PresetShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presetshadow/)।

**नोट्स:**

- जब [OuterShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/outershadow/) और [PresetShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presetshadow/) साथ में उपयोग होते हैं, केवल [OuterShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/outershadow/) प्रभाव लागू होता है।
- यदि [OuterShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/outershadow/) और [InnerShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/innershadow/) एक साथ उपयोग किए जाते हैं, तो लागू प्रभाव PowerPoint संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में प्रभाव दो गुना हो जाता है। लेकिन PowerPoint 2007 में [OuterShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/outershadow/) प्रभाव लागू होता है।

### **टेक्स्ट पर प्रतिबिंब लागू करें**

हम इस Python‑via‑Java कोड नमूने के माध्यम से टेक्स्ट में प्रतिबिंब जोड़ते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **टेक्स्ट पर चमक प्रभाव लागू करें**

हम इस कोड का उपयोग करके टेक्स्ट पर चमक प्रभाव लागू करते हैं ताकि वह चमके या उभरे:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

ऑपरेशन का परिणाम:

![चमक प्रभाव वाले टेक्स्ट](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
आप छाया, प्रतिबिंब और चमक के पैरामीटर बदल सकते हैं। प्रभावों की प्रॉपर्टीज़ प्रत्येक टेक्स्ट भाग पर अलग‑अलग सेट की जाती हैं।
{{% /alert %}}

### **WordArt में ट्रांसफ़ॉर्मेशन का उपयोग करना**

पूरे टेक्स्ट ब्लॉक को ट्रांसफ़ॉर्म करने के लिए [TextFrameFormat.setTransform](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setTransform) का उपयोग करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

परिणाम:

![आर्क ट्रांसफ़ॉर्मेशन वाले टेक्स्ट](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
Microsoft PowerPoint और Aspose.Slides for Python via Java दोनों ही एक निश्चित संख्या में पूर्वनिर्धारित ट्रांसफ़ॉर्मेशन प्रकार प्रदान करते हैं।
{{% /alert %}}

**PowerPoint का उपयोग करके**

पूर्वनिर्धारित ट्रांसफ़ॉर्मेशन प्रकारों तक पहुँचने के लिए जाएँ: **फ़ॉर्मेट** -> **टेक्स्ट इफ़ेक्ट** -> **ट्रांसफ़ॉर्म**।

**Aspose.Slides का उपयोग करके**

ट्रांसफ़ॉर्मेशन प्रकार चुनने के लिए [TextShapeType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textshapetype/) एनेमरेशन का उपयोग करें।

### **टेक्स्ट और शेप पर 3D प्रभाव लागू करें**

हम इस नमूना कोड का उपयोग करके एक टेक्स्ट शेप पर 3D प्रभाव लागू करते हैं:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

परिणामी टेक्स्ट और उसका शेप:

![3D प्रभाव वाले टेक्स्ट शेप](image-20200930114816-9.png)

हम इस Python कोड से टेक्स्ट पर 3D प्रभाव लागू करते हैं:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

ऑपरेशन का परिणाम:

![3D प्रभाव वाले टेक्स्ट](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
टेक्स्ट या उसके शेप पर 3D प्रभावों का अनुप्रयोग और प्रभावों के बीच अंतःक्रिया कुछ नियमों पर आधारित है।

टेक्स्ट और जिस शेप में वह टेक्स्ट है, उसके लिए एक दृश्य (scene) माना जाता है। 3D प्रभाव एक 3D ऑब्जेक्ट प्रतिनिधित्व और उस दृश्य को शामिल करता है जिसमें ऑब्जेक्ट रखा जाता है।

- जब दृश्य दोनों, शेप और टेक्स्ट के लिए सेट होता है, तो शेप का दृश्य प्राथमिकता लेता है—टेक्स्ट का दृश्य उपेक्षित रहता है।
- जब शेप का अपना दृश्य नहीं होता लेकिन उसका 3D प्रतिनिधित्व है, तो टेक्स्ट का दृश्य उपयोग किया जाता है।
- अन्यथा—जब मूलतः शेप में कोई 3D प्रभाव नहीं होता—शेप समतल रहता है और 3D प्रभाव केवल टेक्स्ट पर लागू होता है।

ये नियम [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getLightRig) और [ThreeDFormat.getCamera](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getCamera) विधियों से संबंधित हैं।
{{% /alert %}}

## **टेक्स्ट पर बाहरी छाया प्रभाव लागू करें**

Aspose.Slides for Python via Java [OuterShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/outershadow/) और [InnerShadow](https://reference.aspose.com/slides/hi/python-java/aspose.slides/innershadow/) क्लास प्रदान करता है जो आपको एक [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) में टेक्स्ट पर छाया प्रभाव लागू करने देता है। नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड में एक आयताकार शेप जोड़ें।  
4. शेप से जुड़े टेक्स्ट फ्रेम तक पहुँचें।  
5. शेप फिल को निष्क्रिय करें।  
6. बाहरी छाया प्रभाव को सक्रिय करें।  
7. छाया की ब्लर रेडियस सेट करें।  
8. छाया की दिशा सेट करें।  
9. छाया की दूरी सेट करें।  
10. छाया को ऊपरी बाएँ किनारे पर संरेखित करें।  
11. छाया का रंग काला सेट करें।  
12. प्रेज़ेंटेशन को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

नीचे दिया गया Python‑via‑Java नमूना कोड, ऊपर बताए गए चरणों को लागू करने का तरीका दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # स्लाइड का रेफ़रेंस प्राप्त करें
    slide = presentation.getSlides().get_Item(0)

    # आयत प्रकार का AutoShape जोड़ें
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # आयत में TextFrame जोड़ें
    auto_shape.addTextFrame("Aspose TextBox")

    # यदि हम टेक्स्ट की छाया चाहते हैं तो शेप फ़िल को निष्क्रिय करें
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # बाहरी छाया जोड़ें और सभी आवश्यक पैरामीटर सेट करें
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # प्रस्तुति को डिस्क पर सहेजें
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **शेप पर आंतरिक छाया प्रभाव लागू करें**

नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।  
2. स्लाइड का रेफ़रेंस प्राप्त करें।  
3. एक आयताकार शेप जोड़ें।  
4. आंतरिक छाया प्रभाव को सक्रिय करें।  
5. सभी आवश्यक पैरामीटर सेट करें।  
6. छाया रंग प्रकार को थीम रंग उपयोग करने के लिए सेट करें।  
7. थीम रंग सेट करें।  
8. प्रेज़ेंटेशन को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

नीचे दिया गया (उपरोक्त चरणों पर आधारित) नमूना कोड Python‑via‑Java में दिखाता है कि कैसे शेप के टेक्स्ट पर आंतरिक छाया प्रभाव लागू किया जाता है:

```python
import jpase
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # स्लाइड का रेफ़रेंस प्राप्त करें
    slide = presentation.getSlides().get_Item(0)

    # आयत प्रकार का AutoShape जोड़ें
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # आयत में TextFrame जोड़ें
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # InnerShadowEffect सक्षम करें
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # सभी आवश्यक पैरामीटर सेट करें
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # ColorType को Scheme सेट करें
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Scheme रंग सेट करें
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # प्रस्तुति सहेजें
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं WordArt प्रभाव विभिन्न फ़ॉन्ट या स्क्रिप्ट (जैसे अरबी, चीनी) के साथ उपयोग कर सकता हूँ?**

हाँ, Aspose.Slides Unicode को सपोर्ट करता है और सभी प्रमुख फ़ॉन्ट और स्क्रिप्ट के साथ काम करता है। Shadow, Fill और Outline जैसे WordArt प्रभाव भाषा की परवाह किए बिना लागू किए जा सकते हैं, हालांकि फ़ॉन्ट उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट पर निर्भर कर सकती है।

**क्या मैं स्लाइड मास्टर तत्वों पर WordArt प्रभाव लागू कर सकता हूँ?**

हाँ, आप मास्टर स्लाइड पर स्थित शेप, जैसे शीर्षक प्लेसहोल्डर, फुटर या बैकग्राउंड टेक्स्ट पर WordArt प्रभाव लागू कर सकते हैं। मास्टर लेआउट में किए गए परिवर्तन सभी सम्बंधित स्लाइडों में परिलक्षित होंगे।

**क्या WordArt प्रभाव प्रेज़ेंटेशन फ़ाइल आकार को प्रभावित करते हैं?**

थोड़ा। Shadow, Glow और Gradient Fill जैसे WordArt प्रभाव फ़ॉर्मेटिंग मेटाडाटा जोड़ने के कारण फ़ाइल आकार को हल्का बढ़ा सकते हैं, लेकिन अंतर आमतौर पर नगण्य होता है।

**क्या मैं प्रेज़ेंटेशन सहेजे बिना WordArt प्रभाव का परिणाम पूर्वादर्शित कर सकता हूँ?**

हाँ, आप WordArt वाले स्लाइड को [Shape.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) या [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) का उपयोग करके इमेज (जैसे PNG, JPEG) रूप में रेंडर कर सकते हैं। इससे आप पूरी प्रेज़ेंटेशन को सहेजने या एक्सपोर्ट करने से पहले मेमोरी या स्क्रीन पर परिणाम देख सकते हैं।