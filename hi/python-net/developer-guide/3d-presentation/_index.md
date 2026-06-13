---
title: Python का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D प्रस्तुति
- 3D घुमाव
- 3D गहराई
- 3D एक्सट्रूज़न
- 3D ग्रेडियेंट
- 3D टेक्स्ट
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में PowerPoint आकार और टेक्स्ट के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, लाइटिंग, सामग्री, एक्सट्रूज़न, भराव, और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET आकार और टेक्स्ट के लिए PowerPoint‑शैली 3D स्वरूपण को बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घुमाव, एक्सट्रूज़न, बिवेल, लाइटिंग, सामग्री, ग्रेडियेंट या चित्र भराव, और 3D टेक्स्ट जैसे 3D प्रभावों को कवर करता है।

{{% alert color="primary" %}}
यह लेख PowerPoint आकार और टेक्स्ट पर 3D स्वरूपण प्रभावों के बारे में है। यह अलग‑था 3D मॉडल फ़ाइलों के सम्मिलन या संपादन के बारे में नहीं है। जब आप स्लाइड को इमेज, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides इन 3D प्रभावों को निर्यात किए गए 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D स्वरूपण अवधारणाएँ**

एक आकार पर 3D स्वरूपण लागू करने के लिए [Shape.three_d_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/three_d_format/) प्रॉपर्टी का उपयोग करें। यह प्रॉपर्टी [ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/) को उजागर करती है, जो उस आकार के लिए 3D दृश्य नियंत्रित करती है।

टेक्स्ट के लिए, [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/three_d_format/) प्रॉपर्टी का उपयोग करें। यह आकार बॉडी के बजाय टेक्स्ट फ़्रेम पर 3D स्वरूपण लागू करता है।

सबसे महत्वपूर्ण प्रॉपर्टीज़ हैं:

| प्रॉपर्टी | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [camera](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/camera/) | दृश्य बिंदु, प्रीसेट कैमरा प्रकार, घुमाव, ज़ूम, और परिप्रेक्ष्य। | 3D स्थान में वस्तु को घुमाने या PowerPoint के 3D घुमाव प्रीसेट से मेल करने के लिए। |
| [light_rig](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/light_rig/) | प्रकाश प्रीसेट, दिशा, और प्रकाश घुमाव। | 3D सतह पर हाइलाइट और छाया की उपस्थिति को बदलने के लिए। |
| [material](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/material/) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या धातु। | समान ज्यामिति को अधिक सपाट, मुलायम, चमकदार, या धातु जैसा दिखाने के लिए। |
| [extrusion_height](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/extrusion_height/) | आकार की सामने की सतह से पीछे की ओर कितनी दूरी तक विस्तारित होता है। | सपाट आकार को स्पष्ट रूप से मोटी 3D वस्तु में बदलने के लिए। |
| [extrusion_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/extrusion_color/) | एक्सट्रूडेड किनारों का रंग। | गहराई को दृश्य बनाना या साइड रंग को सामने के भराव के साथ मिलाना। |
| [depth](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/depth/) | PowerPoint 3D स्वरूपण द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकार या टेक्स्ट के लिए गहराई को सूक्ष्म रूप से समायोजित करने के लिए, विशेष रूप से बिवेल और सामग्री सेटिंग्स के साथ। |
| [bevel_top](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/bevel_top/) और [bevel_bottom](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/bevel_bottom/) | सामने और पीछे की सतहों पर उठे या गोलाकार किनारे। | तेज़ सपाट सतह के बजाय मुलायम या ढला हुआ किनारा जोड़ने के लिए। |
| [contour_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/contour_color/) और [contour_width](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/contour_width/) | 3D वस्तु के चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में वस्तु की सीमा को उजागर करने के लिए। |

## **3D आकार बनाएं**

एक आकार को विश्वसनीय रूप से 3D दिखाने से पहले आम तौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छिपा सकती है।
- लाइट सेटिंग्स, क्योंकि प्रकाश सतहों और पक्षों को पढ़ने योग्य बनाता है।
- सामग्री सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि सपाट आकार को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसके सामने वाले भाग में टेक्स्ट जोड़ता है, 3D स्वरूपण लागू करता है, प्रस्तुति को PPTX के रूप में सहेजता है, और स्लाइड को PNG इमेज में रेंडर करता है।

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

रेंडर किया गया स्लाइड इमेज आयत को एक मोटे 3D ब्लॉक के रूप में दर्शाता है:

![रेंडर किया गया नीला 3D आयत सफेद 3D टेक्स्ट के साथ सामने वाले भाग में](img_01_01.png)

## **कैमरा के साथ आकार घुमाएँ**

PowerPoint में, 3D घुमाव को 3‑D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घुमाव मान कैमरा API के माध्यम से सेट किए गए घुमाव के अनुरूप होते हैं।

![PowerPoint 3‑D Rotation पैन जिसमें X, Y, और Z घुमाव मान हाइलाइट किए गए हैं](img_02_01.png)

Aspose.Slides में, कैमरा प्रकार और घुमाव को [ThreeDFormat.camera](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/camera/) के माध्यम से सेट करें:

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

व्यूअर के वस्तु देखने के तरीके को बदलने की आवश्यकता होने पर कैमरा का उपयोग करें। यह स्लाइड पर 2D आकार ज्यामिति को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृश्य बिंदु को बदलता है।

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न आकार को मोटा बनाता है जिससे वह सामने वाली सतह के पीछे तक विस्तारित हो जाता है। PowerPoint में, गहराई नियंत्रण इस दृश्य मोटाई को निर्धारित करता है, और रंग नियंत्रण पक्षों के रंग को निर्धारित करता है।

![PowerPoint गहराई नियंत्रणों को एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई प्रॉपर्टीज़ से मैप किया गया](img_02_02.png)

मोटाई के लिए [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/extrusion_height/) और साइड रंग के लिए [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/extrusion_color/) सेट करें:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

जब आपको सीधे PowerPoint की गहराई वैल्यू के साथ काम करना हो या गहराई को बिवेल, सामग्री, और टेक्स्ट प्रभावों के साथ मिलाना हो, तो [ThreeDFormat.depth](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/depth/) का उपयोग करें। कई आकार परिदृश्यों में, [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/extrusion_height/) अधिक स्पष्ट सेटिंग है क्योंकि यह सीधे दृश्य एक्सट्रूज़न को व्यक्त करता है।

## **3D प्रभावों के साथ ग्रेडियेंट या चित्र भरण کا उपयोग करें**

3D स्वरूपण आकार भराव से स्वतंत्र है। आप सामने वाले भाग पर ठोस रंग, ग्रेडियेंट, पैटर्न, या चित्र भरण लगा सकते हैं और वही कैमरा, लाइट, सामग्री, और एक्सट्रूज़न सेटिंग्स उपयोग करना जारी रख सकते हैं।

निम्न उदाहरण आकार पर ग्रेडियेंट भराव लागू करता है और किनारों के लिए गहरा एक्सट्रूज़न रंग सेट करता है:

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

रेंडर किया गया आउटपुट सामने वाले भाग पर ग्रेडियेंट बनाए रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![रेंडर किया गया 3D आयत जिसमें नीले‑से‑संतरी ग्रेडियेंट भराव और संतरी एक्सट्रूज़न है](img_02_03.png)

चित्र भराव का उपयोग करने के लिए, चित्र को प्रस्तुति में जोड़ें और उसे आकार भराव को असाइन करें:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

चित्र सामने वाले भाग पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![रेंडर किया गया 3D आयत जिसमें सामने वाले भाग पर फोटो भराव और संतरी एक्सट्रूज़न है](img_02_04.png)

## **पाठ पर 3D स्वरूपण लागू करें**

आकार का 3D स्वरूपण आकार बॉडी को प्रभावित करता है। टेक्स्ट का 3D स्वरूपण टेक्स्ट फ्रेम को प्रभावित करता है। यह WordArt‑समान प्रभावों के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, सामग्री, लाइटिंग, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण पैटर्न भराव के साथ टेक्स्ट बनाता है, WordArt ट्रांसफ़ॉर्म लागू करता है, और [TextFrameFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/) पर 3D सेटिंग्स कॉन्फ़िगर करता है:

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

![रेंडर किया गया 3D टेक्स्ट जिसमें अर्च्ड WordArt ट्रांसफ़ॉर्म, संतरी पैटर्न भराव, और गहरा एक्सट्रूज़न है](img_02_05.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मैट में सहेजते समय 3D स्वरूपण को संरक्षित रखता है। जब रेंडरिंग या निर्यात स्थिर‑लेआउट फ़ॉर्मैट में किया जाता है, तो 3D दृश्य को रास्टराइज़ किया जाता है या आउटपुट में 2D परिणाम के रूप में चित्रित किया जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/python-net/convert-powerpoint-to-png/) पर रेंडर करते हैं, [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/python-net/convert-powerpoint-to-html/) में निर्यात करते हैं, या [video conversion](/slides/hi/python-net/convert-powerpoint-to-video/) के लिए फ्रेम उत्पन्न करते हैं।

इन बिंदुओं को ध्यान में रखें:

- निर्यात की गई इमेज और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद ऑब्जेक्ट को व्यूअर द्वारा घुमाया नहीं जा सकता।
- अंतिम रूप कैमरा, लाइट रिग, सामग्री, एक्सट्रूज़न, भराव, और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।
- यदि आपको विरासत या थीम‑आधारित स्वरूपण मानों की जांच करनी है, तो [effective shape properties](/slides/hi/python-net/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मैट्स संपादनीय PowerPoint 3D स्वरूपण को संग्रहीत नहीं कर सकते। उन फ़ॉर्मैट्स में दृश्य परिणाम रेंडर किया जाता है, न कि संपादनीय 3D सेटिंग्स के रूप में संरक्षित।

## **FAQ**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियाँ बना सकता है?**

Aspose.Slides आकार और टेक्स्ट के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह निर्यात की गई इमेज, PDF, या HTML पृष्ठों को ऐसे इंटरैक्टिव 3D दृश्यों में नहीं बदलता जिन्हें व्यूअर घुमा सके। PPTX में, जहाँ फ़ॉर्मैट समर्थन करता है, 3D स्वरूपण PowerPoint में संपादनीय रहता है।

**3D मॉडल और 3D प्रभाव में क्या अंतर है?**

3D मॉडल एक अलग 3D ऑब्जेक्ट है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D प्रभाव नियमित PowerPoint आकार या टेक्स्ट पर लागू किया गया स्वरूपण है, जैसे घुमाव, एक्सट्रूज़न, बिवेल, लाइटिंग, और सामग्री। यह लेख 3D प्रभावों को कवर करता है।

**दृश्यमान 3D आकार के लिए कौन सी सेटिंग्स आवश्यक हैं?**

न्यूनतम रूप से एक कैमरा घुमाव और या तो एक्सट्रूज़न या गहराई सेट करें। व्यावहारिक रूप से, लाइट रिग और सामग्री भी सेट करें ताकि रेंडर की गई सतहों पर स्पष्ट हाइलाइट और शैडो दिखें।

**क्या मैं आकार और टेक्स्ट दोनों पर 3D प्रभाव लागू कर सकता हूँ?**

हां। आकार बॉडी के लिए [Shape.three_d_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/three_d_format/) और टेक्स्ट के लिए [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/three_d_format/) का उपयोग करें।

**क्या 3D प्रभाव इमेज, PDF, HTML, या वीडियो फ्रेम में निर्यात करने पर दिखेंगे?**

हां। Aspose.Slides स्लाइड इमेज, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए उपयोग किए गए फ्रेम उत्पन्न करते समय 3D प्रभाव रेंडर करता है। निर्यातित आउटपुट में रेंडर किया हुआ स्वरूपण होता है, न कि संपादनीय 3D ऑब्जेक्ट।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हां। अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मान पढ़ने के लिए [Shape Effective Properties](/slides/hi/python-net/shape-effective-properties/) में वर्णित प्रभावी स्वरूपण API का उपयोग करें।