---
title: Python का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाना
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/python-java/3d-presentation/
keywords:
- 3D पॉवरपॉइंट
- 3D प्रस्तुति
- 3D घूर्णन
- 3D गहराई
- 3D एक्सट्रूज़न
- 3D ग्रेडिएंट
- 3D टेक्स्ट
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java के साथ Aspose.Slides का उपयोग करके PowerPoint आकृतियों और टेक्स्ट के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, लाइटिंग, सामग्री, एक्सट्रूज़न, भराव और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **सारांश**

Aspose.Slides for Python via Java shapes और text के लिए PowerPoint‑style 3D फ़ॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बिवल, लाइटिंग, मैटेरियल, ग्रेडिएंट या चित्र भराव, और 3D टेक्स्ट जैसी 3D प्रभावों को कवर करता है।

{{% alert color="info" title="Note" %}}
यह लेख PowerPoint shapes और टेक्स्ट पर 3D फ़ॉर्मेटिंग प्रभावों के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित करने या संपादित करने से संबंधित नहीं है। जब आप स्लाइड को इमेज, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D प्रभावों को निर्यातित 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

पैकेज को [स्थापना](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण `asposeslides` को इम्पोर्ट करता है, आवश्यकता होने पर JVM शुरू करता है, और फिर API को इम्पोर्ट करता है। चित्र‑भरण उदाहरण के लिए कार्य निर्देशिका में `image.jpg` फ़ाइल आवश्यक है।

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

एक shape पर 3D फ़ॉर्मेटिंग लागू करने के लिए [Shape.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getThreeDFormat) का उपयोग करें। लौटाया गया फ़ॉर्मेट ऑब्जेक्ट उस shape के 3D दृश्य को नियंत्रित करता है।

टेक्स्ट के लिए, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#getThreeDFormat) का उपयोग करें। यह shape बॉडी के बजाय टेक्स्ट फ्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण API सदस्य हैं:

| API सदस्य | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getCamera) | व्यूपॉइंट, प्रीसेट कैमरा प्रकार, घूर्णन, ज़ूम, और परिप्रेक्ष्य। | ऑब्जेक्ट को 3D स्थान में घुमाएँ या PowerPoint 3D घूर्णन प्रीसेट से मिलाएँ। |
| [getLightRig](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getLightRig) | लाइट प्रीसेट, दिशा, और लाइट घूर्णन। | 3D सतह पर हाइलाइट और शैडो कैसे दिखते हैं इसे बदलें। |
| [getMaterial](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getMaterial) और [setMaterial](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#setMaterial) | सतह सामग्री, जैसे समतल, मैट, प्लास्टिक, या धातु। | एक ही ज्यामिति को अधिक समतल, नरम, चमकीला, या धातु जैसा बनाएं। |
| [getExtrusionHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getExtrusionHeight) और [setExtrusionHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#setExtrusionHeight) | आकार अपने सामने की सतह से कितनी दूरी पीछे तक विस्तारित होता है। | एक समतल आकार को स्पष्ट रूप से मोटा 3D वस्तु में बदलें। |
| [getExtrusionColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getExtrusionColor) | एक्सट्रूड की गई साइडों का रंग। | गहराई प्रदर्शित करें या साइड रंग को सामने के भराव के साथ समन्वयित करें। |
| [getDepth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getDepth) और [setDepth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग की गई अतिरिक्त 3D गहराई। | आकार या टेक्स्ट के लिए गहराई को सूक्ष्म रूप से समायोजित करें, विशेषकर बिवल और मैटेरियल सेटिंग के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getBevelTop) और [getBevelBottom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getBevelBottom) | सामने और पीछे की सतहों पर उठे या गोल किनारे। | तीखा समतल चेहरा के बजाय मुलायम या ढाला हुआ किनारा जोड़ें। |
| [getContourColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getContourWidth), और [setContourWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#setContourWidth) | 3D वस्तु के चारों ओर रूपरेखा। | रेंडर आउटपुट में वस्तु की सीमा पर ज़ोर दें। |

## **3D आकार बनाएँ**

एक shape को विश्वसनीय 3D दिखने से पहले आमतौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छुपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश से चेहरे और साइड्स स्पष्ट दिखते हैं।
- मैटेरियल सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि प्रकाश कैसे प्रस्तुत होता है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि एक समतल shape को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसकी सामने की सतह पर टेक्स्ट जोड़ता है, 3D फ़ॉर्मेटिंग लागू करता है, प्रस्तुति को PPTX के रूप में सहेजता है, और स्लाइड को PNG इमेज में रेंडर करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

रेंडर किया गया स्लाइड इमेज आयत को एक मोटे 3D ब्लॉक के रूप में दर्शाता है:

![सामने की सतह पर सफेद 3D टेक्स्ट के साथ रेंडर किया गया नीला 3D आयत](img_01_01.png)

## **कैमरा के साथ Shape घुमाएँ**

PowerPoint में, 3D घूर्णन को 3‑D Rotation पैनल से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन से मेल खाते हैं।

![PowerPoint 3‑D Rotation पैनल जिसमें X, Y, और Z घूर्णन मान हाइलाइट किए गए हैं](img_02_01.png)

Aspose.Slides में, [Shape.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getThreeDFormat) द्वारा लौटाए गए 3D फ़ॉर्मेट के माध्यम से कैमरा प्रकार और घूर्णन सेट करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

जब आपको दर्शक की वस्तु को देखने के तरीके को बदलने की आवश्यकता हो, तब कैमरा का उपयोग करें। यह स्लाइड पर 2D shape ज्योमेट्री को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D व्यू पॉइंट को बदलता है।

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न shape को मोटा दिखाता है, इसे सामने की सतह के पीछे विस्तारित करके। PowerPoint में, गहराई नियंत्रण इस दृश्य मोटाई को सेट करता है, और रंग नियंत्रण साइड सतहों के रंग को सेट करता है।

![PowerPoint गहराई नियंत्रण जो एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई गुणों से जुड़े हैं](img_02_02.png)

मोटाई के लिए एक्सट्रूज़न ऊँचाई और साइड के रंग के लिए एक्सट्रूज़न रंग सेट करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

जब आपको PowerPoint के गहराई मान को सीधे काम करना हो या गहराई को बिवल, मैटेरियल, और टेक्स्ट प्रभावों के साथ संयोजित करना हो, तब गहराई सेटिंग का उपयोग करें। कई shape परिदृश्यों में, एक्सट्रूज़न ऊँचाई स्पष्ट सेटिंग है क्योंकि यह सीधे दृश्य एक्सट्रूज़न को दर्शाती है।

## **3D प्रभावों के साथ ग्रेडिएंट या चित्र भराव का उपयोग करें**

3D फ़ॉर्मेटिंग shape भराव से स्वतंत्र है। आप सामने की सतह पर सॉलिड रंग, ग्रेडिएंट, पैटर्न, या चित्र भराव लागू कर सकते हैं और फिर भी समान कैमरा, लाइट, मैटेरियल, और एक्सट्रूज़न सेटिंग्स का उपयोग कर सकते हैं।

यह उदाहरण shape पर ग्रेडिएंट भराव और साइड्स पर गहरा एक्सट्रूज़न रंग लागू करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

रेंडर किया गया आउटपुट सामने की सतह पर ग्रेडिएंट को रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![नीले से नारंगी ग्रेडिएंट भराव और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_03.png)

यदि आप चित्र भराव का उपयोग करना चाहते हैं, तो प्रस्तुति में चित्र जोड़ें और उसे shape भराव को असाइन करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

सामने की सतह पर फोटो भराव और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत:

![सामने की सतह पर फोटो भराव और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_04.png)

## **टेक्स्ट पर 3D फ़ॉर्मेटिंग लागू करें**

Shape 3D फ़ॉर्मेटिंग shape बॉडी को प्रभावित करती है। टेक्स्ट 3D फ़ॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt‑समान प्रभावों के लिए उपयोगी है जहाँ अक्षर स्वयं को एक्सट्रूज़न, मैटेरियल, लाइटिंग, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण पैटर्न भराव के साथ टेक्स्ट बनाता है, WordArt ट्रांसफ़ॉर्म लागू करता है, और [TextFrameFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/) पर 3D सेटिंग्स कॉन्फ़िगर करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

आर्क्ड WordArt ट्रांसफ़ॉर्म, नारंगी पैटर्न भराव, और गहरा एक्सट्रूज़न के साथ रेंडर किया गया 3D टेक्स्ट:

![आर्क्ड WordArt ट्रांसफ़ॉर्म, नारंगी पैटर्न भराव, और गहरा एक्सट्रूज़न के साथ रेंडर किया गया 3D टेक्स्ट](img_02_05.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसी PowerPoint फ़ॉर्मेट में सहेजते समय 3D फ़ॉर्मेटिंग को संरक्षित रखता है। जब रेंडरिंग या निर्यात स्थिर‑लेआउट फ़ॉर्मेट में किया जाता है, तो 3D दृश्य को रास्टर किया जाता है या 2D परिणाम के रूप में आउटपुट में खींचा जाता है। यह तब लागू होता है जब आप स्लाइड को PNG में रेंडर करते हैं, PDF में निर्यात करते हैं, HTML में निर्यात करते हैं, या वीडियो रूपांतरण के लिए फ्रेम उत्पन्न करते हैं।

- निर्यात किए गए इमेज और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक ऑब्जेक्ट को घुमा नहीं सकता।
- अंतिम स्वरूप कैमरा, लाइट रिग, मैटेरियल, एक्सट्रूज़न, भराव, और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।
- यदि आपको विरासत में मिले या थीम‑आधारित फ़ॉर्मेटिंग मानों की जाँच करनी हो, तो effective फ़ॉर्मेटिंग API का उपयोग करें।
- कुछ आउटपुट फ़ॉर्मेट संपादनीय PowerPoint 3D फ़ॉर्मेटिंग को संग्रहीत नहीं कर सकते। उन फ़ॉर्मेट में दृश्य परिणाम रेंडर किया जाता है न कि संपादनीय 3D सेटिंग्स के रूप में संरक्षित किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियाँ बना सकता है?**

Aspose.Slides shapes और टेक्स्ट के लिए PowerPoint 3D प्रभाव बनाता है और रेंडर करता है। यह निर्यात किए गए इमेज, PDF, या HTML पेजों को ऐसा इंटरैक्टिव 3D दृश्य नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फ़ॉर्मेटिंग PowerPoint में संपादनीय रहती है।

**एक 3D मॉडल और एक 3D प्रभाव में क्या अंतर है?**

3D मॉडल वह अलग‑अलग 3D वस्तु है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D प्रभाव सामान्य PowerPoint shape या टेक्स्ट पर लागू किया जाने वाला फ़ॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूज़न, बिवल, लाइटिंग, और मैटेरियल। यह लेख 3D प्रभावों को कवर करता है।

**दृश्य 3D shape के लिए कौन सी सेटिंग्स आवश्यक हैं?**

न्यूनतम रूप से, कैमरा घूर्णन और या तो एक्सट्रूज़न या गहराई सेट करें। व्यवहार में, स्पष्ट हाइलाइट और शैडो के लिए लाइट रिग और मैटेरियल भी सेट करना उपयोगी होता है।

**क्या मैं shape और टेक्स्ट दोनों पर 3D प्रभाव लागू कर सकता हूँ?**

हाँ। shape बॉडी के लिये [Shape.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getThreeDFormat) और टेक्स्ट के लिये [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#getThreeDFormat) का उपयोग करें।

**क्या 3D प्रभाव इमेज, PDF, HTML, या वीडियो फ्रेम में निर्यात करते समय दिखाई देंगे?**

हाँ। Aspose.Slides स्लाइड इमेज, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए उपयोग किए जाने वाले फ्रेम उत्पन्न करते समय 3D प्रभाव रेंडर करता है। निर्यातित आउटपुट में रेंडर किया हुआ रूप दिखता है, न कि संपादनीय 3D वस्तु।

**क्या मैं विरासत और थीम सेटिंग लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हाँ। अंतिम कैमरा, लाइट रिग, बिवल, और संबंधित 3D मान पढ़ने के लिये [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getEffective) का उपयोग करें।