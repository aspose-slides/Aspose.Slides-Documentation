---
title: Python का उपयोग करके प्रस्तुतियों में 3D इफ़ेक्ट बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/python-java/3d-presentation/
keywords:
- 3D PowerPoint
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
description: "Aspose.Slides के साथ Java के माध्यम से Python में PowerPoint आकारों और टेक्स्ट के लिए 3D इफ़ेक्ट लागू करें और रेंडर करें। कैमरा, लाइटिंग, मैटेरियल, एक्सट्रूज़न, फ़िल और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **समग्र अवलोकन**

Aspose.Slides for Python via Java आकारों और टेक्स्ट के लिए PowerPoint‑स्टाइल 3D फॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बिवल, लाइटिंग, मैटेरियल, ग्रेडिएंट या पिक्चर फ़िल, और 3D टेक्स्ट जैसे 3D इफ़ेक्ट्स को कवर करता है।

{{% alert color="info" title="Note" %}}
यह लेख PowerPoint आकारों और टेक्स्ट पर 3D फॉर्मेटिंग इफ़ेक्ट्स के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलें सम्मिलित करने या संपादित करने के बारे में नहीं है। जब आप स्लाइड को इमेज, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D इफ़ेक्ट्स को निर्यातित 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

पैकेज को [इंस्टॉलेशन](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण `asposeslides` को आयात करता है, आवश्यक होने पर JVM शुरू करता है, और फिर API को आयात करता है। picture-fill उदाहरण को कार्य निर्देशिका में `image.jpg` फ़ाइल की आवश्यकता होती है।

## **3D फॉर्मेटिंग अवधारणाएँ**

एक आकार पर 3D फॉर्मेटिंग लागू करने के लिए [Shape.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getThreeDFormat) का उपयोग करें। लौटाया गया फ़ॉर्मेट ऑब्जेक्ट उस आकार के लिए 3D सीन को नियंत्रित करता है।

टेक्स्ट के लिए, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#getThreeDFormat) का उपयोग करें। यह आकार के बॉडी के बजाय टेक्स्ट फ़्रेम पर 3D फॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण API सदस्य हैं:

| API सदस्य | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getCamera) | दृश्य बिंदु, प्रीसेट कैमरा प्रकार, घूर्णन, ज़ूम, और परिप्रेक्ष्य। | ऑब्जेक्ट को 3D स्पेस में घुमाएँ या PowerPoint 3D घूर्णन प्रीसेट से मेल करें। |
| [getLightRig](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getLightRig) | लाइट प्रीसेट, दिशा, और लाइट घूर्णन। | 3D सतह पर हाइलाइट और छाया कैसे दिखें, इसे बदलें। |
| [getMaterial](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getMaterial) और [setMaterial](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#setMaterial) | सतह सामग्री, जैसे समतल, मैट, प्लास्टिक, या धातु। | समान ज्यामिति को अधिक समतल, मुलायम, चमकदार या धातु जैसी दिखावट दें। |
| [getExtrusionHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getExtrusionHeight) और [setExtrusionHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#setExtrusionHeight) | आकार की सामने वाली सतह से पीछे की ओर कितना विस्तार है। | एक समतल आकार को स्पष्ट रूप से मोटा 3D ऑब्जेक्ट बनाएं। |
| [getExtrusionColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getExtrusionColor) | एक्सट्रूडेड पक्षों का रंग। | गहराई को दृश्य बनाएं या साइड रंग को सामने की फ़िल के साथ मिलाएँ। |
| [getDepth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getDepth) और [setDepth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D फॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकार या टेक्स्ट के लिए गहराई को सूक्ष्म रूप से समायोजित करें, विशेषकर बिवल और मैटेरियल सेटिंग्स के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getBevelTop) और [getBevelBottom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getBevelBottom) | सामने और पीछे की सतहों पर उभरे या गोल किनारे। | तेज़ समतल सतह के बजाय नरम या ढाला हुआ किनारा जोड़ें। |
| [getContourColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getContourWidth), और [setContourWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#setContourWidth) | 3D ऑब्जेक्ट के चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में ऑब्जेक्ट की सीमा को उजागर करें। |

## **3D आकार बनाना**

एक आकार को विश्वसनीय रूप से 3D दिखाने के लिए आमतौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट सामने का दृश्य एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश साइड और फेस को पठनीय बनाता है।
- मैटेरियल सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि समतल आकार को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसके सामने वाले फेस पर टेक्स्ट जोड़ता है, 3D फॉर्मेटिंग लागू करता है, प्रस्तुति को PPTX के रूप में सहेजता है, और स्लाइड को PNG इमेज में रेंडर करता है।

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

रेंडर की गई स्लाइड इमेज आयत को एक मोटे 3D ब्लॉक के रूप में दिखाती है:

![सामने के सतह पर सफ़ेद 3D टेक्स्ट के साथ रेंडर किया गया नीला 3D आयत](img_01_01.png)

## **कैमरा के साथ आकार को घुमाएँ**

PowerPoint में, 3D घूर्णन को 3‑D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन के अनुरूप होते हैं।

![X, Y, और Z घूर्णन मानों के साथ PowerPoint 3‑D Rotation पैन हाइलाइट किया गया](img_02_01.png)

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

जब आपको दर्शक के ऑब्जेक्ट देखने के तरीके को बदलना हो तो कैमरा का उपयोग करें। यह स्लाइड पर 2D आकार ज्यामिति को नहीं बदलता, बल्कि PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृष्टिकोण को बदलता है।

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न आकार को सामने के फेस के पीछे तक फैलाकर मोटा दिखाता है। PowerPoint में, गहराई नियंत्रण इस दृश्यमान मोटाई को निर्धारित करता है, और रंग नियंत्रण साइड फेस के रंग को सेट करता है।

![एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई गुणों से मैप्ड PowerPoint गहराई नियंत्रण](img_02_02.png)

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

जब आपको सीधे PowerPoint की गहराई मान के साथ काम करना हो या गहराई को बिवल, मैटेरियल और टेक्स्ट इफ़ेक्ट्स के साथ मिलाना हो, तब गहराई सेटिंग का उपयोग करें। कई आकार परिदृश्यों में, एक्सट्रूज़न ऊँचाई स्पष्ट सेटिंग होती है क्योंकि यह सीधे दृश्य एक्सट्रूज़न को दर्शाती है।

## **3D इफ़ेक्ट्स के साथ ग्रेडिएंट या पिक्चर फ़िल का उपयोग करें**

3D फॉर्मेटिंग आकार के फ़िल से स्वतंत्र है। आप सामने के फेस पर सॉलिड रंग, ग्रेडिएंट, पैटर्न, या पिक्चर फ़िल लागू कर सकते हैं और फिर भी वही कैमरा, लाइट, मैटेरियल और एक्सट्रूज़न सेटिंग्स उपयोग कर सकते हैं।

यह उदाहरण आकार पर ग्रेडिएंट फ़िल और साइड्स के लिए गहरे एक्सट्रूज़न रंग लागू करता है:

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

रेंडर किया गया आउटपुट सामने के फेस पर ग्रेडिएंट को बनाए रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![नीले‑से‑नारंगी ग्रेडिएंट फ़िल और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_03.png)

पिक्चर फ़िल का उपयोग करने के लिए, इमेज को प्रस्तुति में जोड़ें और उसे आकार फ़िल के रूप में असाइन करें:

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

पिक्चर सामने के फेस पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![फ़्रंट फ़ेस पर फोटो फ़िल और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_04.png)

## **टेक्स्ट पर 3D फॉर्मेटिंग लागू करें**

आकार की 3D फॉर्मेटिंग आकार के बॉडी को प्रभावित करती है। टेक्स्ट की 3D फॉर्मेटिंग टेक्स्ट फ़्रेम को प्रभावित करती है। यह WordArt‑समान इफ़ेक्ट्स के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, मैटेरियल, लाइटिंग और कैमरा सेटिंग्स की आवश्यकता होती है।

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

टेक्स्ट को वक्र, एक्सट्रूडेड 3D लेटरिंग के रूप में रेंडर किया गया है:

![आर्क्ड WordArt ट्रांसफ़ॉर्म, नारंगी पैटर्न फ़िल, और डार्क एक्सट्रूज़न के साथ रेंडर किया गया 3D टेक्स्ट](img_02_05.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में सहेजते समय 3D फॉर्मेटिंग को संरक्षित रखता है। जब स्थिर‑लेआउट फ़ॉर्मेट में रेंडर या निर्यात किया जाता है, तो 3D सीन को 2D परिणाम के रूप में रास्टराइज़ या ड्रॉ किया जाता है। यह तब लागू होता है जब आप स्लाइड्स को PNG में रेंडर करते हैं, PDF, HTML में निर्यात करते हैं, या वीडियो रूपांतरण के लिए फ्रेम उत्पन्न करते हैं।

ध्यान देने योग्य बिंदु:

- निर्यातित इमेज और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक द्वारा ऑब्जेक्ट को घुमाया नहीं जा सकता।
- अंतिम दिखावट कैमरा, लाइट रिग, मैटेरियल, एक्सट्रूज़न, फ़िल, और स्लाइड स्केलिंग के संयोजन पर निर्भर करती है।
- यदि आपको विरासत या थीम‑आधारित फॉर्मेटिंग मानों की जांच करनी हो, तो प्रभावी फॉर्मेटिंग API का उपयोग करें।
- कुछ आउटपुट फ़ॉर्मेट संपादनीय PowerPoint 3D फॉर्मेटिंग को संग्रहीत नहीं कर सकते। उन फ़ॉर्मेट में, दृश्य परिणाम रेंडर किया जाता है न कि संपादन योग्य 3D सेटिंग्स के रूप में संरक्षित।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रेज़ेंटेशन बना सकता है?**

Aspose.Slides आकारों और टेक्स्ट के लिए PowerPoint 3D इफ़ेक्ट्स बनाता और रेंडर करता है। यह निर्यातित इमेज, PDF, या HTML पेजों को इंटरैक्टिव 3D सीन नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फॉर्मेटिंग PowerPoint में संपादनीय रहती है।

**3D मॉडल और 3D इफ़ेक्ट में क्या अंतर है?**

3D मॉडल एक अलग 3D ऑब्जेक्ट है जिसे प्रस्तुति में डाला जाता है। 3D इफ़ेक्ट एक सामान्य PowerPoint आकार या टेक्स्ट पर लागू फॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूज़न, बिवल, लाइटिंग, और मैटेरियल। यह लेख 3D इफ़ेक्ट्स को कवर करता है।

**एक दिखने योग्य 3D आकार के लिए कौन सी सेटिंग्स आवश्यक हैं?**

न्यूनतम रूप से, कैमरा घूर्णन और या तो एक्सट्रूज़न या गहराई सेट करें। व्यवहार में, लाइट रिग और मैटेरियल भी सेट करें ताकि रेंडर किए गए फेस में स्पष्ट हाइलाइट और शैडो हों।

**क्या मैं आकार और टेक्स्ट दोनों पर 3D इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ। आकार बॉडी के लिए [Shape.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getThreeDFormat) और टेक्स्ट के लिए [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#getThreeDFormat) उपयोग करें।

**क्या 3D इफ़ेक्ट्स इमेज, PDF, HTML, या वीडियो फ्रेम में निर्यात करते समय दिखते हैं?**

हाँ। Aspose.Slides स्लाइड इमेज, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए उपयोग किए जाने वाले फ्रेम उत्पन्न करते समय 3D इफ़ेक्ट्स को रेंडर करता है। निर्यातित आउटपुट में रेंडर किया हुआ दृश्य होता है, संपादन योग्य 3D ऑब्जेक्ट नहीं।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हाँ। अंतिम कैमरा, लाइट रिग, बिवल और संबंधित 3D मान पढ़ने के लिए [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getEffective) का उपयोग करें।