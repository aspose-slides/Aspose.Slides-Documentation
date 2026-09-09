---
title: Python का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाना
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/python-java/3d-presentation/
keywords:
- 3D पावरपॉइंट
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
description: "Aspose.Slides के साथ Java के द्वारा Python में PowerPoint आकारों और टेक्स्ट के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, प्रकाश, सामग्री, एक्सट्रूज़न, फ़िल और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **समीक्षा**

Aspose.Slides for Python via Java आकारों और टेक्स्ट के लिए PowerPoint‑स्टाइल 3D फ़ॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बिवेल, प्रकाश, सामग्री, ग्रेडिएंट या चित्र फ़िल, और 3D टेक्स्ट जैसी 3D प्रभावों को कवर करता है।

{{% alert color="info" title="नोट" %}}
यह लेख PowerPoint आकारों और टेक्स्ट पर 3D फ़ॉर्मेटिंग प्रभावों के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप स्लाइड को छवि, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides इन 3D प्रभावों को निर्यात किए गए 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

पैकेज को [स्थापना](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण `asposeslides` को इम्पोर्ट करता है, आवश्यक होने पर JVM शुरू करता है, और फिर API को इम्पोर्ट करता है। चित्र‑फ़िल उदाहरण को कार्यशील डायरेक्टरी में `image.jpg` फ़ाइल की आवश्यकता होती है।

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

आकार पर 3D फ़ॉर्मेटिंग लागू करने के लिए [Shape.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getThreeDFormat) का उपयोग करें। लौटाया गया फ़ॉर्मेट ऑब्जेक्ट उस आकार के लिए 3D दृश्य को नियंत्रित करता है।

टेक्स्ट के लिए, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#getThreeDFormat) का उपयोग करें। यह आकार के बॉडी की बजाय टेक्स्ट फ्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण API सदस्य हैं:

| API सदस्य | यह किसको नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getCamera) | दृश्यबिंदु, पूर्वनिर्धारित कैमरा प्रकार, घूर्णन, ज़ूम, और परिप्रेक्ष्य। | ऑब्जेक्ट को 3D स्थान में घुमाने या PowerPoint के 3D घूर्णन प्रीसेट से मिलाने के लिए। |
| [getLightRig](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getLightRig) | प्रकाश प्रीसेट, दिशा, और प्रकाश घूर्णन। | 3D सतह पर हाइलाइट और छायाओं के दिखने के तरीके को बदलने के लिए। |
| [getMaterial](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getMaterial) और [setMaterial](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#setMaterial) | सतह सामग्री, जैसे सपाट, मैट, प्लास्टिक, या धातु। | एक ही ज्योमेट्री को अधिक सपाट, मुलायम, चमकदार, या धातु जैसा बनाने के लिए। |
| [getExtrusionHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getExtrusionHeight) और [setExtrusionHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#setExtrusionHeight) | आकार अपने सामने वाले चेहरे से पीछे कितनी दूरी तक बढ़ता है। | सपाट आकार को स्पष्ट रूप से मोटे 3D ऑब्जेक्ट में बदलने के लिए। |
| [getExtrensionColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getExtrusionColor) | एक्सट्रूडेड पक्षों का रंग। | गहराई को दृश्यमान बनाने या पक्ष के रंग को सामने के फ़िल के साथ समन्वयित करने के लिए। |
| [getDepth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getDepth) और [setDepth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकार या टेक्स्ट के लिए गहराई को बारीकी से समायोजित करने के लिए, विशेष रूप से बिवेल और सामग्री सेटिंग्स के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getBevelTop) और [getBevelBottom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getBevelBottom) | समने और पीछे के चेहरों पर उठे या गोल किनारे। | तेज़ सपाट चेहरे के बजाय नरम या ढले हुए किनारे जोड़ने के लिए। |
| [getContourColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getContourWidth), और [setContourWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#setContourWidth) | 3D ऑब्जेक्ट के चारों ओर का रूपरेखा। | रेंडर किए गए आउटपुट में ऑब्जेक्ट सीमा को उजागर करने के लिए। |

## **3D आकार बनाएं**

एक आकार को विश्वसनीय रूप से 3D दिखाने से पहले सामान्यतः चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट सामने वाला दृश्य एक्सट्रूज़न को छिपा सकता है।
- प्रकाश सेटिंग्स, क्योंकि प्रकाश चेहरे और पक्षों को पढ़ने योग्य बनाता है।
- सामग्री सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि सपाट आकार को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसके सामने वाले चेहरे पर टेक्स्ट जोड़ता है, 3D फ़ॉर्मेटिंग लागू करता है, प्रस्तुति को PPTX के रूप में सहेजता है, और स्लाइड को PNG छवि में रेंडर करता है।

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

रेंडर किया गया स्लाइड इमेज आयत को एक मोटे 3D ब्लॉक के रूप में दिखाता है:

![समने के चेहरे पर सफ़ेद 3D टेक्स्ट के साथ रेंडर किया गया नीला 3D आयत](img_01_01.png)

## **कैमरा के साथ आकार को घुमाएँ**

PowerPoint में, 3D घूर्णन को 3‑D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान उन घूर्णनों से मेल खाते हैं जिन्हें आप कैमरा API के माध्यम से सेट करते हैं।

![X, Y, और Z घूर्णन मानों को उजागर किया गया PowerPoint 3‑D Rotation पैन](img_02_01.png)

Aspose.Slides में, कैमरा प्रकार और घूर्णन को [Shape.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getThreeDFormat) द्वारा लौटाए गए 3D फ़ॉर्मेट से सेट करें:

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

जब आपको दर्शक के वस्तु देखने के तरीके को बदलना हो तो कैमरा का उपयोग करें। यह स्लाइड पर 2D आकार जियोमेट्री को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृश्य बिंदु को बदलता है।

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न आकार को आगे के चेहरे के पीछे बढ़ाकर मोटा दिखाता है। PowerPoint में, गहराई नियंत्रण इस दृश्यमान मोटाई को सेट करता है, और रंग नियंत्रण साइड फेस का रंग निर्धारित करता है।

![एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई गुणों से मैप किया गया PowerPoint गहराई नियंत्रण](img_02_02.png)

मोटाई के लिए एक्सट्रूज़न ऊँचाई और साइड रंग के लिए एक्सट्रूज़न रंग सेट करें:

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

जब आपको PowerPoint के गहराई मान को सीधे उपयोग करना हो या गहराई को बिवेल, सामग्री, और टेक्स्ट प्रभावों के साथ मिलाना हो, तब गहराई सेटिंग का उपयोग करें। कई आकार परिदृश्यों में, एक्सट्रूज़न ऊँचाई स्पष्ट सेटिंग होती है क्योंकि यह सीधे दृश्यमान एक्सट्रूज़न को दर्शाता है।

## **3D प्रभावों के साथ ग्रेडिएंट या चित्र फ़िल्स का उपयोग करें**

3D फ़ॉर्मेटिंग आकार के फ़िल से स्वतंत्र है। आप सामने की सतह पर ठोस रंग, ग्रेडिएंट, पैटर्न, या चित्र फ़िल लागू कर सकते हैं और फिर भी वही कैमरा, प्रकाश, सामग्री, और एक्सट्रूज़न सेटिंग्स उपयोग कर सकते हैं।

यह उदाहरण आकार पर ग्रेडिएंट फ़िल और पक्षों पर गहरा एक्सट्रूज़न रंग लागू करता है:

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

रेंडर किया गया आउटपुट सामने की सतह पर ग्रेडिएंट रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![नीले‑से‑संतरी ग्रेडिएंट फ़िल और संतरी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_03.png)

चित्र फ़िल का उपयोग करने के लिए, छवि को प्रस्तुति में जोड़ें और उसे आकार के फ़िल में असाइन करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

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

चित्र सामने की सतह पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![सामने की सतह पर फोटो फ़िल और संतरी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_04.png)

## **टेक्स्ट पर 3D फ़ॉर्मेटिंग लागू करें**

आकार की 3D फ़ॉर्मेटिंग आकार के बॉडी को प्रभावित करती है। टेक्स्ट की 3D फ़ॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt‑समान प्रभावों के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, सामग्री, प्रकाश, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण पैटर्न फ़िल के साथ टेक्स्ट बनाता है, WordArt ट्रांसफ़ॉर्म लागू करता है, और [TextFrameFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/) पर 3D सेटिंग्स कॉन्फ़िगर करता है:

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

टेक्स्ट को वक्र, एक्सट्रूज़न किया हुआ 3D लेटरिंग के रूप में रेंडर किया गया है:

![आर्च्ड WordArt ट्रांसफ़ॉर्म, संतरी पैटर्न फ़िल, और गहरा एक्सट्रूज़न के साथ रेंडर किया गया 3D टेक्स्ट](img_02_05.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PowerPoint फ़ॉर्मेट जैसे PPTX में सहेजने पर 3D फ़ॉर्मेटिंग को संरक्षित रखता है। जब स्थिर‑लेआउट फ़ॉर्मेट में रेंडर या निर्यात किया जाता है, तो 3D दृश्य को रैस्टराइज़ करके 2D परिणाम के रूप में आउटपुट में खींचा जाता है। यह PNG पर स्लाइड रेंडर करने, PDF निर्यात, HTML निर्यात, या वीडियो रूपांतरण के लिए फ्रेम जनरेट करने पर लागू होता है।

इन बिंदुओं को ध्यान में रखें:

- निर्यात की गई छवियां और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद ऑब्जेक्ट को दर्शक द्वारा घुमा नहीं सकते।
- अंतिम रूप कैमरा, लाइट रिग, सामग्री, एक्सट्रूज़न, फ़िल, और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।
- यदि आपको विरासत या थीम‑आधारित फ़ॉर्मेटिंग मानों को जांचना है, तो प्रभावी फ़ॉर्मेटिंग API का उपयोग करें।
- कुछ आउटपुट फ़ॉर्मेट संपादन योग्य PowerPoint 3D फ़ॉर्मेटिंग को संग्रहीत नहीं कर सकते। इन फ़ॉर्मेट में दृश्य परिणाम को रेंडर किया जाता है, न कि संपादन योग्य 3D सेटिंग्स के रूप में संरक्षित किया जाता है।

## **बार‑बार पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियों का निर्माण कर सकता है?**

Aspose.Slides आकारों और टेक्स्ट के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह निर्यात की गई छवियों, PDF, या HTML पेजों को इंटरैक्टिव 3D दृश्य नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फ़ॉर्मेटिंग PowerPoint में संपादन योग्य रहती है।

**3D मॉडल और 3D प्रभाव में क्या अंतर है?**

3D मॉडल प्रस्तुति में सम्मिलित किया गया अलग 3D ऑब्जेक्ट होता है। 3D प्रभाव सामान्य PowerPoint आकार या टेक्स्ट पर लागू फ़ॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूज़न, बिवेल, प्रकाश, और सामग्री। यह लेख 3D प्रभावों को कवर करता है।

**एक दिखाई देने वाला 3D आकार बनाने के लिए कौन सी सेटिंग्स आवश्यक हैं?**

कम से कम, कैमरा घूर्णन और एक्सट्रूज़न या गहराई सेट करें। व्यवहार में, लाइट रिग और सामग्री भी सेट करें ताकि रेंडर की गई सतहों में स्पष्ट हाइलाइट और शैडो हों।

**क्या मैं दोनों आकार और टेक्स्ट पर 3D प्रभाव लगा सकता हूँ?**

हां। आकार के बॉडी के लिए [Shape.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getThreeDFormat) और टेक्स्ट के लिए [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#getThreeDFormat) का उपयोग करें।

**क्या 3D प्रभाव छवियों, PDF, HTML, या वीडियो फ़्रेम में निर्यात करने पर दिखाई देंगे?**

हां। Aspose.Slides स्लाइड छवियों, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए उपयोग किए जाने वाले फ़्रेम उत्पन्न करते समय 3D प्रभाव रेंडर करता है। निर्यात किया गया आउटपुट रेंडर किया हुआ रूप दिखाता है, संपादन योग्य 3D ऑब्जेक्ट नहीं।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हां। अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मान पढ़ने के लिए [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getEffective) का उपयोग करें।