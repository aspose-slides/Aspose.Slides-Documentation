---
title: Python का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/python-net/3d-presentation/
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
- Aspose.Slides
description: "Aspose.Slides के साथ Python में PowerPoint आकारों और टेक्स्ट के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, लाइटिंग, मटीरियल, एक्सट्रूज़न, फ़िल्स, और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET आकारों और टेक्स्ट के लिए PowerPoint‑शैली 3D फ़ॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, मटीरियल, ग्रेडिएंट या चित्र फ़िल्स, और 3D टेक्स्ट जैसे 3D इफ़ेक्ट्स को कवर करता है।

{{% alert color="info" title="Note" %}}
यह लेख PowerPoint आकारों और टेक्स्ट पर 3D फ़ॉर्मेटिंग इफ़ेक्ट्स के बारे में है। यह अलग‑थलग 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप एक स्लाइड को इमेज, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D इफ़ेक्ट्स को निर्यातित 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

एक आकार पर 3D फ़ॉर्मेटिंग लागू करने के लिए [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) प्रॉपर्टी का उपयोग करें। यह प्रॉपर्टी [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) को उजागर करती है, जो उस आकार के लिए 3D सीन को नियंत्रित करती है।

टेक्स्ट के लिए, [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) प्रॉपर्टी का उपयोग करें। यह आकार के बॉडी की बजाय टेक्स्ट फ्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण प्रॉपर्टीज़ हैं:

| प्रॉपर्टी | यह क्या नियंत्रित करता है | इसे कब उपयोग करना है |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | व्यूपॉइंट, प्रीसेट कैमरा प्रकार, घूर्णन, ज़ूम, और पर्स्पेक्टिव। | ऑब्जेक्ट को 3D स्पेस में घुमाएँ या PowerPoint 3D घूर्णन प्रीसेट से मिलाएँ। |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | लाइट प्रीसेट, दिशा, और लाइट रोटेशन। | हाइलाइट और शैडो 3D सतह पर कैसे दिखते हैं, इसे बदलें। |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या मेटल। | एक ही ज्योमेट्री को अधिक सपाट, मुलायम, चमकदार, या धातु जैसा दिखाएँ। |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | आकार अपने फ्रंट फेस से पीछे कितनी दूरी तक एक्सट्रूद होता है। | एक फ्लैट आकार को दृश्यमान रूप से मोटा 3D ऑब्जेक्ट बनाएं। |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | एक्सट्रूडेड साइड्स का रंग। | गहराई को दृश्यमान बनाएँ या साइड रंग को फ्रंट फ़िल के साथ समन्वयित करें। |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D डेप्थ। | आकार या टेक्स्ट के लिए डेप्थ को बारीकी से समायोजित करें, विशेष रूप से बेवेल और मटीरियल सेटिंग्स के साथ। |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) and [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | फ़्रंट और बैक फेसेज़ पर उठे या गोल किनारे। | एक तेज़ सपाट फेस की बजाय मुलायम या मोल्डेड किनारा जोड़ें। |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) and [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | 3D ऑब्जेक्ट के चारों ओर आउटलाइन। | रेंडर किए गए आउटपुट में ऑब्जेक्ट सीमा को उभारें। |

## **3D आकार बनाना**

एक आकार को आम तौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है ताकि वह विश्वसनीय रूप से 3D दिखाई दे:
- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि लाइटिंग से फेस और साइड्स स्पष्ट दिखते हैं।
- मटीरियल सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूज़न या डेप्थ सेटिंग्स, क्योंकि एक फ्लैट आकार को मोटाई चाहिए।

निम्नलिखित उदाहरण एक आयत बनाता है, उसके फ्रंट फेस पर टेक्स्ट जोड़ता है, और 3D फ़ॉर्मेटिंग लागू करता है। कैमरा घूर्णन मान डिग्री में हैं, और एक्सट्रूज़न हाईट 100 पॉइंट्स है। उदाहरण स्लाइड को PNG इमेज में डिफ़ॉल्ट आकार के दो गुना पर रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है।

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

रेंडर की गई स्लाइड इमेज आयत को एक मोटी 3D ब्लॉक के रूप में दर्शाती है:
![फ़्रंट फेस पर सफ़ेद 3D टेक्स्ट के साथ रेंडर्ड नीला 3D आयत](img_01_01.png)

## **कैमरा से आकार घुमाना**

PowerPoint में, 3‑D Rotation पेन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन के अनुरूप होते हैं।

![PowerPoint 3‑D Rotation पेन जिसमें X, Y, और Z घूर्णन मान हाइलाइटेड हैं](img_02_01.png)

Aspose.Slides में, कैमरा तक पहुंचने के लिए [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) का प्रयोग करें। यह उदाहरण एक आयत बनाता है, एक ऑर्थोग्राफिक फ्रंट व्यू चुनता है, और क्रमशः X, Y, Z घूर्णन को 20, 30, और 40 डिग्री सेट करता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

जब आपको दर्शक द्वारा ऑब्जेक्ट को देखने के तरीके को बदलना हो, तब कैमरा का उपयोग करें। यह स्लाइड पर 2D आकार ज्योमेट्री को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D व्यूपॉइंट को बदलता है।

### **टेम्प्लेट आकार से कैमरा अभिविन्यास कॉपी करना**

टेम्प्लेट आकार के अभिविन्यास से मेल खाने के लिए, उसका [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) प्रीसेट कॉपी करें और उसकी घूर्णन को [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/) से पढ़ें। यह उदाहरण `template.pptx` खोलता है और पहले स्लाइड की पहली आकार से दोरी आकार में कैमरा अभिविन्यास कॉपी करता है। दोनों आकारों में पहले से ही 3D लाइटिंग है, और दूसरे आकार में स्पष्ट कैमरा घूर्णन नहीं है।

कोण डिग्री में होते हैं। सूचकांक `0`, `1`, और `2` क्रमशः लैटिट्यूड, लॉन्गिट्यूड, और रिवॉल्यूशन रखते हैं। इन्हें उसी क्रम में [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) को पास करें। यदि स्रोत में स्पष्ट घूर्णन नहीं है, तो `get_rotation` `None` लौटाता है, इसलिए गंतव्य के कोण को अनसेट रखें। यदि स्रोत स्पष्ट रूप से सभी तीन कोण शून्य सेट करता है, तो उन शून्य को कॉपी करें।

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

`camera-copy.pptx` को PowerPoint में पुनः खोलने पर, दोनों आकारों का कैमरा प्रीसेट और घूर्णन समान होता है। दाएं तीर का अभिविन्यास बाएं आयत से कॉपी किया गया है। दोनों आकार समान लाइटिंग और एक्सट्रूज़न डेप्थ का उपयोग करते हैं।

![एक नीला 3D आयत और दायें तीर, समान कैमरा अभिविन्यास के साथ, ऊपर और दायें से देखा गया](camera-orientation.png)

## **एक्सट्रूज़न और डेप्थ जोड़ें**

एक्सट्रूज़न आकार को मोटा दिखाता है क्योंकि यह फ्रंट फेस के पीछे विस्तार करता है। PowerPoint में, डेप्थ कंट्रोल इस दृश्य मोटाई को सेट करता है, और कलर कंट्रोल साइड फेस का रंग निर्धारित करता है।

![PowerPoint डेप्थ नियंत्रण जो एक्सट्रूज़न रंग और एक्सट्रूज़न हाईट प्रॉपर्टीज़ से जुड़े हैं](img_02_02.png)

मोटाई के लिए [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) सेट करें और साइड के रंग के लिए [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) सेट करें। यह उदाहरण एक आयत को 100‑पॉइंट एक्सट्रूज़न के साथ बैंगनी साइड्स देता है और कैमरा को घुमाकर उसकी मोटाई दिखाता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सेव किए:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

[ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) प्रॉपर्टी 3D आकार की डेप्थ सेट करती है। [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) प्रॉपर्टी एक्सट्रूज़न इफ़ेक्ट की ऊँचाई को नियंत्रित करती है, जैसा कि इस उदाहरण में दिखाया गया है।

## **3D इफ़ेक्ट्स के साथ ग्रेडिएंट या पिक्चर फ़िल्स का उपयोग करें**

3D फ़ॉर्मेटिंग आकार के फ़िल से स्वतंत्र है। आप फ्रंट फेस पर ठोस रंग, ग्रेडिएंट, पैटर्न, या पिक्चर फ़िल लागू कर सकते हैं और फिर भी समान कैमरा, लाइट, मटीरियल, और एक्सट्रूज़न सेटिंग्स का उपयोग कर सकते हैं।

यह उदाहरण फ्रंट फेस पर नीले‑से‑ऑरेंज ग्रेडिएंट लागू करता है और 150‑पॉइंट एक्सट्रूज़न पर गहरा ऑरेंज रंग देता है। ग्रेडिएंट 0 और 100 पर शुरू और अंत को चिह्नित करता है। कैमरा घूर्णन मान डिग्री में हैं। स्लाइड को PNG इमेज में डिफ़ॉल्ट आकार के दो गुना पर रेंडर किया गया है:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

![नीले‑से‑ऑरेंज ग्रेडिएंट फ़िल और ऑरेंज एक्सट्रूज़न के साथ रेंडर्ड 3D आयत](img_02_03.png)

पिक्चर फ़िल का उपयोग करने के लिए, छवि को प्रस्तुति में जोड़ें और उसे आकार फ़िल को असाइन करें। यह उदाहरण कार्य निर्देशिका में "image.jpg" नाम की मौजूदा फ़ाइल की आवश्यकता रखता है। यह चित्र को आयत में भरने के लिए फैलाता है, 150‑पॉइंट एक्सट्रूज़न लागू करता है, और कैमरा घूर्णन को डिग्री में सेट करता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे या रेंडर किए:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

![फ़्रंट फेस पर फ़ोटो फ़िल और ऑरेंज एक्सट्रूज़न के साथ रेंडर्ड 3D आयत](img_02_04.png)

## **टेक्स्ट पर 3D फ़ॉर्मेटिंग लागू करें**

आकार की 3D फ़ॉर्मेटिंग आकार के बॉडी को प्रभावित करती है। टेक्स्ट की 3D फ़ॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt‑जैसे इफ़ेक्ट्स के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, मटीरियल, लाइटिंग, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्नलिखित उदाहरण ऑरेंज‑और‑व्हाइट ग्रिड पैटर्न के साथ टेक्स्ट बनाता है, एक ऊपर की ओर तीर (arch) लागू करता है, और [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) के माध्यम से 3D सेटिंग्स कॉन्फ़िगर करता है। एक्सट्रूज़न हाईट और डेप्थ पॉइंट्स में हैं, और लाइट घूर्णन डिग्री में है। आकार फ़िल और आउटलाइन छिपाए गए हैं ताकि केवल टेक्स्ट दिखे। उदाहरण PNG इमेज को डिफ़ॉल्ट स्लाइड आकार के दो गुना पर रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

![एक आर्च्ड WordArt ट्रांसफॉर्म, ऑरेंज पैटर्न फ़िल, और डार्क एक्सट्रूज़न के साथ रेंडर्ड 3D टेक्स्ट](img_02_05.png)

## **3D आकार पर टेक्स्ट को सपाट रखें**

एक आकार की 3D उपस्थिति को बनाए रखते हुए टेक्स्ट को पढ़ने योग्य रखने के लिए, [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/) के माध्यम से [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) सेट करें। जब मान `True` होता है, तो टेक्स्ट 3D सीन से बाहर रहता है। जब यह `False` होता है, तो टेक्स्ट सीन में भाग लेता है और उसकी 3D अभिविन्यास का पालन करता है।

यह सेटिंग आकार की 3D फ़ॉर्मेटिंग को नहीं हटाती: उसका कैमरा, लाइटिंग, मटीरियल, और एक्सट्रूज़न [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) के माध्यम से कॉन्फ़िगर रहता है। यह सामान्य घूर्णन से भी अलग है। [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) स्लाइड प्लेन में आकार को घुमाता है, जबकि [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) टेक्स्ट के बाउंडिंग बॉक्स के भीतर कस्टम घूर्णन नियंत्रित करता है। टेक्स्ट को 3D सीन से बाहर रखने से इन कोणों में से कोई भी रीसेट नहीं होता।

निम्नलिखित स्वतंत्र उदाहरण एक नीली आयत को टेक्स्ट के साथ बनाता है और उसे मूल के बगल में क्लोन करता है। दोनों आकारों में समान 3D फ़ॉर्मेटिंग है; केवल टेक्स्ट सेटिंग अलग है: बाएँ पर `False` और दाएँ पर `True`। कैमरा कोण डिग्री में हैं, और एक्सट्रूज़न हाईट 40 पॉइंट्स है। यह उदाहरण प्रस्तुति को PPTX के रूप में सहेजता है और तुलना स्लाइड को PNG में डिफ़ॉल्ट आकार के दो गुना पर रेंडर करता है।

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

![साइड‑बाय‑साइड 3D आयतें: बाएँ keep_text_flat `False` है और दाएँ `True` है](keep_text_flat.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में सहेजते समय 3D फ़ॉर्मेटिंग को बनाए रखता है। जब रेंडरिंग या निर्यात स्थिर‑लेआउट फ़ॉर्मेट में किया जाता है, तो 3D सीन को रास्टराइज़ या 2D परिणाम के रूप में आउटपुट में ड्रॉ किया जाता है। यह तब लागू होता है जब आप स्लाइड्स को [PNG](/slides/hi/python-net/convert-powerpoint-to-png/) में रेंडर करते हैं, [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/python-net/convert-powerpoint-to-html/) में निर्यात करते हैं, या [वीडियो कन्वर्ज़न](/slides/hi/python-net/convert-powerpoint-to-video/) के लिए फ्रेम उत्पन्न करते हैं।

इन बिंदुओं को ध्यान में रखें:
- निर्यातित इमेज और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक ऑब्जेक्ट को घुमा नहीं सकता।
- अंतिम रूप कैमरा, लाइट रिग, मटीरियल, एक्सट्रूज़न, फ़िल, और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।
- यदि आपको विरासत में प्राप्त या थीम‑आधारित फ़ॉर्मेटिंग मानों की जांच करनी हो, तो [effective shape properties](/slides/hi/python-net/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट संपाद्य PowerPoint 3D फ़ॉर्मेटिंग को संग्रहीत नहीं कर सकते। उन फ़ॉर्मेट में, दृश्य परिणाम को रेंडर किया जाता है न कि संपाद्य 3D सेटिंग्स के रूप में संरक्षित किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियाँ बना सकता है?**  
Aspose.Slides आकारों और टेक्स्ट के लिए PowerPoint 3D इफ़ेक्ट्स बनाता और रेंडर करता है। यह निर्यातित इमेज, PDF, या HTML पेज को इंटरैक्टिव 3D सीन नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फ़ॉर्मेटिंग PowerPoint में संपाद्य बनी रहती है।

**3D मॉडल और 3D इफ़ेक्ट में क्या अंतर है?**  
3D मॉडल वह अलग 3D ऑब्जेक्ट है जिसे प्रस्तुति में जोड़ा जाता है। 3D इफ़ेक्ट नियमित PowerPoint आकार या टेक्स्ट पर लागू फ़ॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, और मटीरियल। यह लेख 3D इफ़ेक्ट्स को कवर करता है।

**एक दृश्यमान 3D आकार के लिए कौन सी सेटिंग्स आवश्यक हैं?**  
न्यूनतम रूप से, कैमरा घूर्णन और या तो एक्सट्रूज़न या डेप्थ सेट करें। व्यावहारिक रूप से, लाइट रिग और मटीरियल भी सेट करें ताकि रेंडर किए गए फ़ेस में स्पष्ट हाइलाइट और शैडो हों।

**क्या मैं आकारों और टेक्स्ट दोनों पर 3D इफ़ेक्ट लागू कर सकता हूँ?**  
हाँ। आकार के बॉडी के लिए [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) का उपयोग करें और टेक्स्ट के लिए [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) का उपयोग करें।

**क्या इमेज, PDF, HTML, या वीडियो फ्रेम्स में निर्यात करने पर 3D इफ़ेक्ट्स दिखेंगे?**  
हाँ। Aspose.Slides स्लाइड इमेज, PDF आउटपुट, HTML आउटपुट, और वीडियो कन्वर्ज़न के लिए उपयोग किए गए फ़्रेम्स बनाते समय 3D इफ़ेक्ट्स रेंडर करता है। निर्यातित आउटपुट में रेंडर किया हुआ रूप दिखता है, न कि संपाद्य 3D ऑब्जेक्ट।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**  
हाँ। [Shape Effective Properties](/slides/hi/python-net/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग APIs का उपयोग करके अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मान पढ़ें।