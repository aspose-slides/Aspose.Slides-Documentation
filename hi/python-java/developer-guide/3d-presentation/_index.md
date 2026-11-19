---
title: Python का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएं
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
- 3D पाठ
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Java के माध्यम से Python में PowerPoint आकारों और पाठ के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, प्रकाश, सामग्री, एक्सट्रूज़न, भराव, और 3D पाठ को कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for Python via Java आकारों और पाठ के लिए PowerPoint‑style 3D फॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, सामग्री, ग्रेडिएंट या चित्र भराव, और 3D पाठ जैसी 3D प्रभावों को कवर करता है।

{{% alert color="info" title="Note" %}}
यह लेख PowerPoint आकारों और पाठ पर 3D फॉर्मेटिंग प्रभावों के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप स्लाइड को छवि, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D प्रभावों को निर्यात किए गए 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फॉर्मेटिंग अवधारणाएँ**

एक आकार पर 3D फॉर्मेटिंग लागू करने के लिए [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) विधि का उपयोग करें। यह विधि [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) लौटाती है, जो उस आकार के लिए 3D दृश्य को नियंत्रित करती है।

पाठ के लिए, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) विधि का उपयोग करें। यह आकार बॉडी के बजाय टेक्स्ट फ्रेम पर 3D फॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण API सदस्य हैं:

| API सदस्य | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | दृश्य बिंदु, प्रीसेट कैमरा प्रकार, घूर्णन, ज़ूम, और दृष्टिकोण। | वस्तु को 3D स्थान में घुमाएँ या PowerPoint 3D घूर्णन प्रीसेट से मिलाएँ। |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | प्रकाश प्रीसेट, दिशा, और प्रकाश घूर्णन। | 3D सतह पर हाइलाइट और छाया कैसे दिखाई दें, इसे बदलें। |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) और [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | सतह सामग्री, जैसे समतल, मैट, प्लास्टिक, या धातु। | उसी ज्यामिति को अधिक समतल, नरम, चमकदार, या धात्वीय बनाएं। |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) और [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | आकार अपनी सामने की सतह से पीछे कितनी दूर तक विस्तारित होता है। | समतल आकार को स्पष्ट रूप से मोटा 3D वस्तु बनाएं। |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | निकाले गए किनारों का रंग। | गहराई को दृश्यमान बनाएं या साइड रंग को सामने की भराव के साथ समन्वयित करें। |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) और [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D फॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकार या टेक्स्ट के लिए गहराई को सूक्ष्म रूप से समायोजित करें, विशेष रूप से बिवेल और सामग्री सेटिंग्स के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) और [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | सामने और पीछे की सतहों पर उभरे या गोल किनारे। | तीक्ष्ण समतल सतह के बजाय नरम या आकारित किनारा जोड़ें। |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) और [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) और [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | 3D वस्तु के चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में वस्तु की सीमा को उजागर करें। |

## **3D आकार बनाएँ**

एक आकार को विश्वसनीय रूप से 3D दिखाने से पहले आम तौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट सामने का दृश्य एक्सट्रूज़न को छुपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश सतहों और किनारों को पढ़ने योग्य बनाता है।
- मैटेरियल सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि समतल आकार को मोटाई चाहिए।

नीचे दिया गया उदाहरण आयत बनाता है, उसकी सामने वाली सतह पर पाठ जोड़ता है, और 3D फॉर्मेटिंग लागू करता है। कैमरा घूर्णन मान डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 100 पॉइंट है। उदाहरण स्लाइड को PNG छवि में दो गुना डिफ़ॉल्ट आकार में रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है।

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
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

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

रेंडर की गई स्लाइड छवि आयत को मोटे 3D ब्लॉक के रूप में दिखाती है:

![रेंडर किया गया नीला 3D आयत जिसमें सामने की सतह पर सफेद 3D टेक्स्ट है](img_01_01.png)

## **कैमरा के साथ आकार घुमाएँ**

PowerPoint में, 3D घूर्णन 3‑D Rotation पेन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन से मेल खाते हैं।

![PowerPoint 3‑D Rotation पेन जिसमें X, Y, और Z घूर्णन मान उजागर किए गए हैं](img_02_01.png)

Aspose.Slides में, कैमरा को [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) के माध्यम से एक्सेस करें। यह उदाहरण आयत बनाता है, एक ऑर्थोग्राफिक फ्रंट व्यू चुनता है, और क्रमशः X, Y, और Z घूर्णन को 20, 30, और 40 डिग्री पर सेट करता है। यह आकार को स्मृति में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

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

जब आपको दिखाने वाले के दृष्टिकोण को बदलना हो तो कैमरा का उपयोग करें। यह स्लाइड पर 2D आकार ज्योमेट्री को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृश्य बिंदु को बदलता है।

### **टेम्पलेट आकार से कैमरा अभिविन्यास कॉपी करें**

टेम्पलेट आकार के अभिविन्यास से मेल खाने के लिए, उसके कैमरा प्रीसेट को [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) से पढ़ें और उसके घूर्णन कोणों को [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation) से पढ़ें। यह उदाहरण `template.pptx` खोलता है और पहले स्लाइड के पहले आकार से कैमरा अभिविन्यास को दूसरे आकार में कॉपी करता है। दोनों आकारों में पहले से ही 3D लाइटिंग है, और दूसरे आकार में कोई स्पष्ट कैमरा घूर्णन नहीं है।

कोण डिग्री में हैं। इंडेक्स `0` अक्षांश, इंडेक्स `1` देशान्तर, और इंडेक्स `2` परिसंचरण है। इन्हें उसी क्रम में [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) को पास करें। यदि स्रोत `None` लौटाता है, तो उसके पास कोई स्पष्ट घूर्णन नहीं है, इसलिए दूसरे आकार के कोण अनसेट रहें। `(0, 0, 0)` का स्पष्ट घूर्णन तीन शून्य लौटाता है और उसे कॉपी किया जाना चाहिए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

जब आप `camera-copy.pptx` को PowerPoint में फिर से खोलते हैं, तो दाएँ ओर वाले तीर का कैमरा प्रीसेट और घूर्णन बाएँ ओर वाले आयत के समान होता है। दोनों आकार एक ही लाइटिंग और एक्सट्रूज़न गहराई का उपयोग करते हैं।

![एक नीला 3D आयत और दाएँ तीर जिसका कैमरा अभिविन्यास मेल खाता है, ऊपर और दाईं ओर से देखा गया](camera-orientation.png)

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न आयत को मोटा बनाता है क्योंकि यह सामने वाली सतह के पीछे विस्तारित होता है। PowerPoint में, गहराई नियंत्रण इस दृश्यमान मोटाई को निर्धारित करता है, और रंग नियंत्रण साइड सतहों के रंग को निर्धारित करता है।

![PowerPoint गहराई नियंत्रणों को एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई गुणों से मैप किया गया](img_02_02.png)

[ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) का उपयोग करके मोटाई सेट करें और [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) से साइड रंग प्राप्त करें। यह उदाहरण आयत को 100‑point एक्सट्रूज़न के साथ बैंगनी साइड देता है और उसकी मोटाई दिखाने के लिए कैमरा घूर्णन करता है। यह आकार को स्मृति में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) विधि 3D आकार की गहराई सेट करती है। [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) विधि एक्सट्रूज़न प्रभाव की ऊँचाई को नियंत्रित करती है, जैसा कि इस उदाहरण में दिखाया गया है।

## **ग्रेडिएंट या चित्र भराव के साथ 3D प्रभाव उपयोग करें**

3D फॉर्मेटिंग आकार भराव से स्वतंत्र है। आप सामने की सतह पर ठोस रंग, ग्रेडिएंट, पैटर्न, या चित्र भराव लागू कर सकते हैं और फिर भी वही कैमरा, लाइट, सामग्री, और एक्सट्रूज़न सेटिंग्स उपयोग कर सकते हैं।

यह उदाहरण फ़्रंट फेस पर नीले‑से‑नारंगी ग्रेडिएंट लागू करता है और 150‑point एक्सट्रूज़न पर गहरा नारंगी रंग देता है। ग्रेडिएंट स्टॉप 0 और 100 पर क्रमशः ग्रेडिएंट की शुरुआत और समाप्ति को दर्शाते हैं। कैमरा घूर्णन मान डिग्री में हैं। स्लाइड को दो गुना डिफ़ॉल्ट आकार में PNG छवि में रेंडर किया गया है:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

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

रेंडर किया गया आउटपुट फ्रंट फेस पर ग्रेडिएंट को बरकरार रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![रेंडर किया गया 3D आयत जिसमें नीले‑से‑नारंगी ग्रेडिएंट भराव और नारंगी एक्सट्रूज़न है](img_02_03.png)

चित्र भराव उपयोग करने के लिए, चित्र को प्रस्तुति में जोड़ें और उसे आकार भराव को असाइन करें। इस उदाहरण के लिए कार्य निर्देशिका में "image.jpg" नामक मौजूदा फ़ाइल आवश्यक है। यह चित्र को आयत में भरने के लिए विस्तारित करता है, 150‑point एक्सट्रूज़न लागू करता है, और कैमरा घूर्णन को डिग्री में सेट करता है। यह आकार को स्मृति में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे या रेंडर किए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

चित्र फ्रंट फेस पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![रेंडर किया गया 3D आयत जिसमें फ्रंट फेस पर फोटो भराव और नारंगी एक्सट्रूज़न है](img_02_04.png)

## **पाठ पर 3D फॉर्मेटिंग लागू करें**

आकार 3D फॉर्मेटिंग आकार बॉडी को प्रभावित करती है। टेक्स्ट 3D फॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt‑जैसे प्रभावों के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, सामग्री, लाइटिंग, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्नलिखित उदाहरण नारंगी‑और‑सफ़ेद ग्रिड पैटर्न के साथ पाठ बनाता है, एक ऊपर की ओर आर्च लागू करता है, और [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) के माध्यम से 3D सेटिंग्स कॉन्फ़िगर करता है। एक्सट्रूज़न ऊँचाई और गहराई पॉइंट में हैं, और लाइट घूर्णन डिग्री में है। आकार भराव और रूपरेखा छिपी हुई हैं ताकि केवल पाठ दिखाई दे। उदाहरण डिफ़ॉल्ट स्लाइड आयामों के दो गुना PNG छवि रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है:

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

पाठ को वक्रित, एक्सट्रूडेड 3D अक्षर के रूप में रेंडर किया गया है:

![रेंडर किया गया 3D पाठ जिसमें आर्च्ड WordArt ट्रांसफ़ॉर्म, नारंगी पैटर्न भराव, और गहरा एक्सट्रूज़न है](img_02_05.png)

## **3D आकार पर पाठ को समतल रखें**

पाठ को पठनीय बनाए रखने के लिये जबकि आकार की 3D उपस्थिति बनी रहे, [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat) के माध्यम से [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) को कॉल करें। जब मान `True` हो, तो पाठ 3D दृश्य से बाहर रहता है। जब `False` हो, तो पाठ दृश्य में भाग लेता है और उसकी 3D अभिविन्यास का अनुसरण करता है।

यह सेटिंग आकार की 3D फॉर्मेटिंग को नहीं हटाती: उसका कैमरा, लाइटिंग, सामग्री, और एक्सट्रूज़न अभी भी [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) के माध्यम से कॉन्फ़िगर होते हैं। यह सामान्य घूर्णन से भी अलग है। [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) स्लाइड प्लेन में आकार को घुमाता है, जबकि [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) बॉन्डिंग बॉक्स के भीतर पाठ के कस्टम घूर्णन को नियंत्रित करता है। पाठ को 3D दृश्य से बाहर रखना उन कोणों को रीसेट नहीं करता।

निम्नलिखित स्वावलंबी उदाहरण नीला आयत पाठ के साथ बनाता है और उसे मूल के बगल में क्लोन करता है। दोनों आकारों में समान 3D फॉर्मेटिंग है; केवल पाठ सेटिंग अलग है: बाएँ पर `False` और दाएँ पर `True`। कैमरा कोण डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 40 पॉइंट है। उदाहरण प्रस्तुति को PPTX के रूप में सहेजता है और तुलना स्लाइड को दो गुना डिफ़ॉल्ट आयामों में PNG के रूप में रेंडर करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

बाएँ पर पाठ 3D अभिविन्यास का अनुसरण करता है। दाएँ पर यह समतल रहता है और पढ़ना आसान होता है। दोनों आयत समान दृश्यमान एक्सट्रूज़न और 3D अभिविन्यास को बरकरार रखते हैं।

![साइड‑बाय‑साइड 3D आयत: बाएँ पर पाठ 3D अभिविन्यास का अनुसरण करता है और दाएँ पर समतल रहता है](keep_text_flat.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसी PowerPoint फ़ॉर्मेट में सहेजते समय 3D फॉर्मेटिंग को संरक्षित रखता है। जब रेंडरिंग या निर्यात निश्चित‑लेआउट फ़ॉर्मेट में किया जाता है, तो 3D दृश्य को रास्टराइज़ या 2D परिणाम के रूप में आउटपुट में खींचा जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/python-java/convert-powerpoint-to-png/), [PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/hi/python-java/convert-powerpoint-to-html/), या [video conversion](/slides/hi/python-java/convert-powerpoint-to-video/) के फ़्रेम के लिए रेंडर करते हैं।

इन बातों को याद रखें:

- निर्यात की गई छवियां और PDFs इंटरैक्टिव नहीं हैं। निर्यात के बाद दर्शक वस्तु को घुमा नहीं सकता।
- अंतिम रूपरेखा कैमरा, लाइट रिग, सामग्री, एक्सट्रूज़न, फ़ाइल, और स्लाइड स्केलिंग के संयोजन पर निर्भर करती है।
- यदि आपको विरासत में मिली या थीम‑आधारित फॉर्मेटिंग मान देखनी हों, तो [effective shape properties](/slides/hi/python-java/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट संपादन योग्य PowerPoint 3D फॉर्मेटिंग को संग्रहीत नहीं कर सकते। उन फ़ॉर्मेट में, दृश्य परिणाम को रेंडर किया जाता है न कि संपादन योग्य 3D सेटिंग के रूप में संरक्षित किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियां बना सकता है?**

Aspose.Slides आकार और पाठ के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह निर्यात की गई छवियों, PDFs, या HTML पृष्ठों को इंटरैक्टिव 3D दृश्यों में नहीं बदलता जिसे दर्शक घुमा सके। PPTX में, 3D फॉर्मेटिंग PowerPoint में संपादन योग्य बनी रहती है जहाँ फ़ॉर्मेट इसका समर्थन करता है।

**3D मॉडल और 3D प्रभाव में क्या अंतर है?**

3D मॉडल एक अलग 3D वस्तु है जिसे प्रस्तुति में जोड़ा जाता है। 3D प्रभाव सामान्य PowerPoint आकार या पाठ पर लागू फॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, और सामग्री। यह लेख 3D प्रभावों को कवर करता है।

**एक दिखाई देने वाले 3D आकार के लिए कौन सी सेटिंग्स जरूरी हैं?**

कम से कम कैमरा घूर्णन और या तो एक्सट्रूज़न या गहराई सेट करें। व्यवहारिक रूप से, लाइट रिग और सामग्री भी सेट करें ताकि रेंडर की गई सतहों पर स्पष्ट हाइलाइट और छायाएं हों।

**क्या मैं 3D प्रभाव दोनों आकार और पाठ पर लागू कर सकता हूँ?**

हाँ। आकार बॉडी के लिए [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) और पाठ के लिए [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) उपयोग करें।

**क्या 3D प्रभाव छवियों, PDF, HTML, या वीडियो फ़्रेम में निर्यात करने पर दिखते हैं?**

हाँ। Aspose.Slides स्लाइड छवियां, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए फ़्रेम बनाते समय 3D प्रभाव रेंडर करता है। निर्यातित आउटपुट में रेंडर किया हुआ रूप दिखता है, न कि संपादन योग्य 3D वस्तु।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हाँ। अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मान पढ़ने के लिए [Shape Effective Properties](/slides/hi/python-java/shape-effective-properties/) में वर्णित प्रभावी फॉर्मेटिंग API का उपयोग करें।