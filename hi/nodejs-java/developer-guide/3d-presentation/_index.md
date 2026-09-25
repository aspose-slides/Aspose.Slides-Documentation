---
title: Node.js का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/nodejs-java/3d-presentation/
keywords:
- 3D पॉवरपॉइंट
- 3D प्रस्तुति
- 3D घूर्णन
- 3D गहराई
- 3D एक्सट्रूज़न
- 3D ग्रेडिएंट
- 3D पाठ
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js में Aspose.Slides के साथ PowerPoint आकृतियों और पाठ के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, प्रकाश, सामग्री, एक्सट्रूज़न, भराव, और 3D पाठ को कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java आकृतियों और पाठ के लिए PowerPoint‑शैली 3D स्वरूपण को बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बीवल, लाइटिंग, सामग्री, ग्रेडिएंट या चित्र भराव, और 3D पाठ जैसे 3D प्रभावों को कवर करता है।

{{% alert color="info" title="Note" %}}

यह लेख PowerPoint आकृतियों और पाठ पर 3D स्वरूपण प्रभावों के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप किसी स्लाइड को चित्र, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D प्रभावों को निर्यातित 2D आउटपुट में रेंडर करता है।

{{% /alert %}}

## **3D स्वरूपण अवधारणाएँ**

[Shape.getThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getThreeDFormat) मेथड का प्रयोग करके आप किसी आकृति पर 3D स्वरूपण लागू कर सकते हैं। यह मेथड [ThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/) लौटाता है, जो उस आकृति के लिए 3D दृश्य को नियंत्रित करता है।

पाठ के लिए, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) मेथड का प्रयोग करें। यह रूपरेखा के बजाय पाठ फ्रेम पर 3D स्वरूपण लागू करता है।

सबसे महत्वपूर्ण API सदस्य हैं:

| API सदस्य | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getCamera) | दर्शनीय बिंदु, पूर्वनिर्धारित कैमरा प्रकार, घूर्णन, ज़ूम, और परिप्रेक्ष्य। | ऑब्जेक्ट को 3D स्पेस में घुमाने या PowerPoint 3D घूर्णन प्रीसेट से मेल खाने के लिए। |
| [getLightRig](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getLightRig) | लाइट प्रीसेट, दिशा, और लाइट घूर्णन। | 3D सतह पर हाइलाइट और छाया कैसे दिखें, इसे बदलने के लिए। |
| [getMaterial](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getMaterial) और [setMaterial](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#setMaterial) | सतह सामग्री, जैसे सपाट, मैट, प्लास्टिक, या धातु। | समान ज्यामिति को अधिक सपाट, मुलायम, चमकदार, या धातु जैसा बनाना। |
| [getExtrusionHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) और [setExtrusionHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | आकृति के सामने के चेहरे से पीछे की ओर कितना विस्तार है। | सपाट आकृति को दृष्टिगत रूप से मोटी 3D वस्तु में बदलना। |
| [getExtrusionColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | एक्सट्रूज़न पक्षों का रंग। | गहराई को दृश्य बनाना या पक्ष के रंग को सामने के भराव के साथ समन्वयित करना। |
| [getDepth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getDepth) और [setDepth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D स्वरूपण द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकृतियों या पाठ के लिए गहराई को बारीकी से समायोजित करना, विशेष रूप से बीवल और सामग्री सेटिंग्स के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getBevelTop) और [getBevelBottom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | सामने और पीछे के चेहरों पर उभरा या गोल किनारा। | तीखा सपाट चेहरा के बजाय मुलायम या ढाला हुआ किनारा जोड़ना। |
| [getContourColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getContourWidth), और [setContourWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D वस्तु के चारों ओर रूपरेखा। | रेंडरित आउटपुट में वस्तु की सीमा पर ज़ोर देना। |

## **3D आकार बनाएं**

एक आकृति को विश्वसनीय रूप से 3D दिखाने के लिए आम तौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट सामने वाला दृश्य एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश द्वारा चेहरे और पक्षों को पठनीय बनाया जाता है।
- सामग्री सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि प्रकाश कैसे रेंडर होगा।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि सपाट आकृति को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसकी सामने की सतह पर पाठ जोड़ता है, और 3D स्वरूपण लागू करता है। कैमरा घूर्णन मान डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 100 पॉइंट है। उदाहरण स्लाइड को डिफ़ॉल्ट आकार का दोगुना PNG चित्र में रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

रेंडर किया हुआ स्लाइड चित्र आयत को मोटी 3D ब्लॉक के रूप में दिखाता है:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **कैमरा के साथ आकार को घुमाएँ**

PowerPoint में, 3D घूर्णन को 3‑D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन के बराबर होते हैं।

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides में, कैमरा तक पहुँचने के लिए [ThreeDFormat.getCamera](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getCamera) का उपयोग करें। यह उदाहरण एक आयत बनाता है, ऑर्थोग्राफ़िक सामने वाला दृश्य चुनता है, और क्रमशः X, Y, Z घूर्णन को 20, 30, और 40 डिग्री पर सेट करता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

कैमरा का उपयोग तब करें जब आपको दृश्यकर्ता के द्वारा वस्तु को देखने के तरीके को बदलने की आवश्यकता हो। यह स्लाइड पर 2D आकार ज्यामिति को नहीं बदलता; यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृश्य बिंदु को बदलता है।

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न एक आकृति को सामने के चेहरे के पीछे विस्तार देकर मोटा बनाता है। PowerPoint में, गहराई नियंत्रण इस दृश्य मोटाई को सेट करता है, और रंग नियंत्रण पक्षों के रंग को निर्धारित करता है।

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

[ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) का उपयोग करके मोटाई सेट करें और [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) से पक्षों का रंग प्राप्त करें। यह उदाहरण आयत को 100‑point एक्सट्रूज़न के साथ बैंगनी पक्षों वाला बनाता है और मोटाई दिखाने के लिए कैमरा घुमाता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#setDepth) मेथड 3D आकार की गहराई सेट करता है। [setExtrusionHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) मेथड एक्सट्रूज़न प्रभाव की ऊँचाई को नियंत्रित करता है, जैसा कि इस उदाहरण में दिखाया गया है।

## **3D प्रभावों के साथ ग्रेडिएंट या चित्र भराव का उपयोग करें**

3D स्वरूपण आकृति के भराव से स्वतंत्र है। आप सामने के चेहरे पर ठोस रंग, ग्रेडिएंट, पैटर्न, या चित्र भराव लागू कर सकते हैं और फिर भी उसी कैमरा, लाइट, सामग्री, और एक्सट्रूज़न सेटिंग्स का उपयोग कर सकते हैं।

यह उदाहरण सामने के चेहरे पर नीले‑से‑संतरे ग्रेडिएंट और 150‑point एक्सट्रूज़न पर गहरा संतरा रंग लागू करता है। ग्रेडिएंट स्टॉप 0 और 100 पर क्रमशः ग्रेडिएंट की शुरुआत और अंत को दर्शाते हैं। कैमरा घूर्णन मान डिग्री में हैं। स्लाइड को डिफ़ॉल्ट आकार का दोगुना PNG चित्र में रेंडर किया गया है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

रेंडर किया गया आउटपुट सामने के चेहरे पर ग्रेडिएंट को बरकरार रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

चित्र भराव उपयोग करने के लिए, चित्र को प्रस्तुति में जोड़ें और उसे आकृति भराव में असाइन करें। यह उदाहरण कार्य निर्देशिका में मौज़ूद "image.jpg" नामक फ़ाइल को मानता है। यह चित्र को आयत में पूरी तरह खींचता है, 150‑point एक्सट्रूज़न लागू करता है, और कैमरा घूर्णन को डिग्री में सेट करता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे या रेंडर किए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

चित्र सामने के चेहरे पर रेंडर होता है, जबकि एक्सट्रूज़न 3D पक्ष सतह के रूप में रेंडर होता है:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **पाठ पर 3D स्वरूपण लागू करें**

आकृति का 3D स्वरूपण आकृति बॉडी को प्रभावित करता है। पाठ का 3D स्वरूपण पाठ फ्रेम को प्रभावित करता है। यह WordArt‑समान प्रभावों के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, सामग्री, प्रकाश, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण एक पाठ बनाता है जिसमें नारंगी‑और‑सफ़ेद ग्रिड पैटर्न है, एक ऊपर की ओर चाप लागू करता है, और [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) के माध्यम से 3D सेटिंग्स कॉन्फ़िगर करता है। एक्सट्रूज़न ऊँचाई और गहराई पॉइंट में हैं, और लाइट घूर्णन डिग्री में है। आकृति भराव और रूपरेखा छिपी हुई है ताकि केवल पाठ दिखे। उदाहरण डिफ़ॉल्ट स्लाइड आकार का दोगुना PNG चित्र रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

पाठ को घुमावदार, एक्सट्रूडेड 3D अक्षर के रूप में रेंडर किया गया है:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **3D आकार पर पाठ को सपाट रखें**

पाठ को पढ़ने योग्य रखने और आकार की 3D उपस्थिति को बनाए रखने के लिए, [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) को [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) के माध्यम से कॉल करें। जब मान `true` हो, तो पाठ 3D दृश्य से बाहर रहता है। जब यह `false` हो, तो पाठ दृश्य में भाग लेता है और उसकी 3D अभिविन्यास का पालन करता है।

यह सेटिंग आकृति के 3D स्वरूपण—कैमरा, प्रकाश, सामग्री, और एक्सट्रूज़न—को नहीं हटाती। यह सामान्य घूर्णन से भी अलग है। [Shape.setRotation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#setRotation) स्लाइड प्लेन में आकृति को घुमाता है, जबकि [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) पाठ के बॉन्डिंग बॉक्स के भीतर कस्टम घूर्णन को नियंत्रित करता है। पाठ को 3D दृश्य से बाहर रखना इन कोणों को रीसेट नहीं करता।

निम्न स्व-निहित उदाहरण एक नीले आयत को पाठ के साथ बनाता है और इसे मूल के बगल में क्लोन करता है। दोनों आकारों में समान 3D स्वरूपण है; केवल पाठ सेटिंग भिन्न है: बाएँ में `false` और दाएँ में `true`। कैमरा कोण डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 40 पॉइंट है। उदाहरण प्रस्तुति को PPTX के रूप में सहेजता है और तुलना स्लाइड को दो गुना डिफ़ॉल्ट आकार में PNG में रेंडर करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

बाएँ पर, पाठ 3D अभिविन्यास का अनुसरण करता है। दाएँ पर, यह सपाट रहता है और पढ़ने में आसान होता है। दोनों आयतें समान दृश्य एक्सट्रूज़न और 3D अभिविन्यास को बरकरार रखती हैं।

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में 3D स्वरूपण को संरक्षित रखता है। जब स्थिर‑लेआउट फ़ॉर्मेट में रेंडर या निर्यात किया जाता है, तो 3D दृश्य को रास्टर किया जाता है या 2D परिणाम के रूप में आउटपुट में चित्रित किया जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/nodejs-java/convert-powerpoint-to-png/) में रेंडर करते हैं, [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/) में निर्यात करते हैं, या [वीडियो रूपांतरण](/slides/hi/nodejs-java/convert-powerpoint-to-video/) के लिए फ़्रेम उत्पन्न करते हैं।

इन बिंदुओं को ध्यान में रखें:

- निर्यातित चित्र और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक द्वारा वस्तु को घुमाया नहीं जा सकता।
- अंतिम रूपांतरण कैमरा, लाइट रिग, सामग्री, एक्सट्रूज़न, भराव, और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।
- यदि आपको विरासत या थीम‑आधारित स्वरूपण मानों को निरीक्षण करने की आवश्यकता है, तो [effective shape properties](/slides/hi/nodejs-java/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट संपादन योग्य PowerPoint 3D स्वरूपण को संग्रहीत नहीं कर सकते। ऐसे फ़ॉर्मेट में दृश्य परिणाम रेंडर किया जाता है, न कि संपादन योग्य 3D सेटिंग्स के रूप में।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियां बना सकता है?**

Aspose.Slides आकृतियों और पाठ के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह निर्यातित चित्र, PDF, या HTML पृष्ठों को इंटरैक्टिव 3D दृश्य नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D स्वरूपण PowerPoint में संपादन योग्य रहता है।

**3D मॉडल और 3D प्रभाव में क्या अंतर है?**

3D मॉडल एक अलग 3D वस्तु है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D प्रभाव सामान्य PowerPoint आकृति या पाठ पर लागू किया गया स्वरूपण है, जैसे घूर्णन, एक्सट्रूज़न, बीवल, प्रकाश, और सामग्री। यह लेख 3D प्रभावों को कवर करता है।

**दृश्यमान 3D आकृति के लिए कौनसी सेटिंग्स आवश्यक हैं?**

कम से कम कैमरा घूर्णन और या तो एक्सट्रूज़न या गहराई सेट करें। व्यावहारिक रूप से, लाइट रिग और सामग्री भी सेट करें ताकि रेंडरेड चेहरों में स्पष्ट हाइलाइट और छाया दिखे।

**क्या मैं दोनों आकृतियों और पाठ पर 3D प्रभाव लागू कर सकता हूँ?**

हाँ। आकृति बॉडी के लिए [Shape.getThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getThreeDFormat) और पाठ के लिए [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) का उपयोग करें।

**क्या 3D प्रभाव चित्रों, PDF, HTML, या वीडियो फ़्रेम में निर्यात करने पर दिखाई देंगे?**

हाँ। Aspose.Slides स्लाइड चित्र, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए फ़्रेम उत्पन्न करते समय 3D प्रभाव को रेंडर करता है। निर्यातित आउटपुट में रेंडर किया गया रूप दिखता है, न कि संपादन योग्य 3D ऑब्जेक्ट।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हाँ। अंतिम कैमरा, लाइट रिग, बीवल, और संबंधित 3D मान पढ़ने के लिए [Shape Effective Properties](/slides/hi/nodejs-java/shape-effective-properties/) में वर्णित प्रभावी स्वरूपण API का उपयोग करें।