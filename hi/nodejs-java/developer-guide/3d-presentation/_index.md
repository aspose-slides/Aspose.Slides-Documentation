---
title: Node.js का उपयोग करके प्रस्तुतियों में 3D इफ़ेक्ट्स बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides के साथ Node.js में PowerPoint शैप्स और टेक्स्ट के लिए 3D इफ़ेक्ट्स लागू करें और रेंडर करें। कैमरा, लाइटिंग, मैटेरियल, एक्सट्रूज़न, फ़िल्स और 3D टेक्स्ट कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java shapes और text के लिए PowerPoint‑style 3D फ़ॉर्मेटिंग बना, संपादित, सुरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बिवल्स, लाइटिंग, मैटेरियल, ग्रेडिएंट या पिक्चर फ़िल्स, और 3D टेक्स्ट जैसी 3D इफ़ेक्ट्स को कवर करता है।

{{% alert color="info" title="Note" %}}
यह लेख PowerPoint shapes और text पर 3D फ़ॉर्मेटिंग इफ़ेक्ट्स के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित करने या संपादित करने के बारे में नहीं है। जब आप एक स्लाइड को इमेज, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D इफ़ेक्ट्स को निर्यात किए गए 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

किसी shape पर 3D फ़ॉर्मेटिंग लागू करने के लिए [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) मेथड का उपयोग करें। यह मेथड [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) लौटाता है, जो उस shape के लिए 3D सीन को नियंत्रित करता है।

टेक्स्ट के लिए, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) मेथड का उपयोग करें। यह shape बॉडी के बजाय टेक्स्ट फ्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण API सदस्य हैं:

| API सदस्य | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | दृष्टिकोण, प्रीसेट कैमरा प्रकार, घूर्णन, ज़ूम, और परिप्रेक्ष्य। | ऑब्जेक्ट को 3D स्पेस में घुमाने या PowerPoint 3D घूर्णन प्रीसेट से मिलाने के लिए। |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | लाइट प्रीसेट, दिशा, और लाइट घूर्णन। | 3D सतह पर हाइलाइट्स और शैडोज़ के दिखने के तरीके को बदलने के लिए। |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या मेटल। | एक ही ज्योमेट्री को अधिक फ्लैट, सॉफ्ट, चमकदार, या धातु जैसा दिखाने के लिए। |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | shape अपने सामने वाले चेहरे से पीछे कितनी दूर तक विस्तार करता है। | एक फ्लैट shape को स्पष्ट रूप से मोटी 3D वस्तु में बदलने के लिए। |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | एक्सट्रूडेड किनारों का रंग। | गहराई को दृश्यमान बनाने या किनारों के रंग को सामने के फ़िल के साथ समन्वयित करने के लिए। |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | shape या टेक्स्ट के लिए गहराई को बारीकी से समायोजित करने के लिए, विशेषकर बिवेल और मैटेरियल सेटिंग्स के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | सामने और पीछे के चेहरों पर उठे या गोल किए हुए किनारे। | एक तीखा फ्लैट चेहरा की बजाय नरम या आकारित किनारा जोड़ने के लिए। |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D वस्तु के चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में वस्तु की सीमा को उजागर करने के लिए। |

## **3D Shape बनाएं**

एक shape को विश्वसनीय 3D दिखाने से पहले सामान्यतः चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफॉल्ट फ्रंट व्यू एक्सट्रूज़न को छुपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश चेहरों और किनारों को पठनीय बनाता है।
- मैटेरियल सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूज़न या डेप्थ सेटिंग्स, क्योंकि एक फ्लैट shape को मोटाई चाहिए।

निम्नलिखित उदाहरण एक आयत बनाता है, उसकी सामने वाली सतह पर टेक्स्ट जोड़ता है, और 3D फ़ॉर्मेटिंग लागू करता है। कैमरा घूर्णन मान डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 100 पॉइंट्स है। यह उदाहरण स्लाइड को PNG इमेज में दो गुना डिफॉल्ट आकार में रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है।

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

रेंडर की गई स्लाइड इमेज आयत को एक मोटी 3D ब्लॉक के रूप में दिखाती है:

![फ़्रंट फेस पर सफ़ेद 3D टेक्स्ट के साथ रेंडर किया गया नीला 3D आयत](img_01_01.png)

## **कैमरा से Shape को घुमाना**

PowerPoint में, 3‑D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन के अनुरूप होते हैं।

![PowerPoint 3-D Rotation पैन जिसमें X, Y, और Z घूर्णन मान हाइलाइट किए गए हैं](img_02_01.png)

Aspose.Slides में, कैमरा तक पहुंचने के लिए [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) का उपयोग करें। यह उदाहरण एक आयत बनाता है, एक ऑर्थोग्राफिक फ्रंट व्यू चुनता है, और इसके X, Y, और Z घूर्णन को क्रमशः 20, 30, और 40 डिग्री सेट करता है। यह shape को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

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

जब आपको दर्शक के ऑब्जेक्ट देखने के तरीके को बदलना हो, तब कैमरा का उपयोग करें। यह स्लाइड पर 2D shape ज्योमेट्री को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृष्टिकोण को बदलता है।

### **टेम्पलेट Shape से कैमरा अभिविन्यास कॉपी करें**

टेम्पलेट shape की अभिविन्यास से मेल करने के लिए, उसके कैमरा प्रीसेट को [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) से पढ़ें और उसकी घूर्णन कोणों को [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation) से पढ़ें। यह उदाहरण `template.pptx` खोलता है और पहले स्लाइड के पहले shape से कैमरा अभिविन्यास को दूसरे shape में कॉपी करता है। दोनों shapes में पहले से ही 3D लाइटिंग है, और दूसरे shape में कोई स्पष्ट कैमरा घूर्णन नहीं है।

कोण डिग्री में हैं। इंडेक्स `0` अक्षांश है, इंडेक्स `1` देशांतर है, और इंडेक्स `2` घूर्णन है। उन्हें उस क्रम में [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) को पास करें। यदि स्रोत `null` लौटाता है, तो उसके पास कोई स्पष्ट घूर्णन नहीं है, इसलिए दूसरे shape के कोण को अनसेट रखें। `(0, 0, 0)` जैसे स्पष्ट घूर्णन में तीन शून्य होते हैं और उसे कॉपी किया जाना चाहिए।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

When आप `camera-copy.pptx` को PowerPoint में पुनः खोलते हैं, दाएँ तरफ़ का तीर बाएँ के आयत के समान कैमरा प्रीसेट और घूर्णन रखता है। दोनों shapes एक ही लाइटिंग और एक्सट्रूज़न डेप्थ उपयोग करते हैं।

![एक नीला 3D आयत और दायें की ओर तीर जिसका कैमरा अभिविन्यास मेल खाता है, ऊपर और दाएँ से दृश्य](camera-orientation.png)

## **एक्सट्रूज़न और डेप्थ जोड़ें**

एक्सट्रूज़न shape को मोटा दिखाता है जिससे वह सामने वाले चेहरे के पीछे बढ़ जाता है। PowerPoint में, डेप्थ नियंत्रण इस दृश्य मोटाई को सेट करता है, और रंग नियंत्रण साइड फेसेस का रंग सेट करता है।

![PowerPoint डेप्थ नियंत्रण को एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई गुणों से मानचित्रित किया गया](img_02_02.png)

भारीपन सेट करने के लिए [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) का उपयोग करें और साइड रंग प्राप्त करने के लिए [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) का उपयोग करें। यह उदाहरण आयत को 100‑पॉइंट एक्सट्रूज़न देता है जिसमें बैंगनी साइड्स हैं और मोटाई दिखाने के लिए कैमरा को घुमाता है। यह shape को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

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

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) मेथड 3D shape की डेप्थ सेट करता है। [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) मेथड एक्सट्रूज़न इफ़ेक्ट की ऊँचाई को नियंत्रित करता है, जैसा कि इस उदाहरण में दिखाया गया है।

## **3D इफ़ेक्ट्स के साथ ग्रेडिएंट या पिक्चर फ़िल्स का उपयोग करें**

3D फ़ॉर्मेटिंग shape फ़िल से स्वतंत्र है। आप सामने वाले चेहरे पर ठोस रंग, ग्रेडिएंट, पैटर्न, या पिक्चर फ़िल लागू कर सकते हैं और फिर भी वही कैमरा, लाइट, मैटेरियल, और एक्सट्रूज़न सेटिंग्स उपयोग कर सकते हैं।

यह उदाहरण सामने वाले चेहरे पर नीले‑से‑संतरे ग्रेडिएंट लागू करता है और 150‑पॉइंट एक्सट्रूज़न पर डार्क ऑरेंज रंग सेट करता है। ग्रेडिएंट के स्टॉप 0 और 100 पर क्रमशः ग्रेडिएंट की शुरुआत और अंत को दर्शाते हैं। कैमरा घूर्णन मान डिग्री में हैं। स्लाइड को डिफॉल्ट आकार के दो गुना PNG इमेज में रेंडर किया गया है:

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

![नीले‑से‑संतरे ग्रेडिएंट फ़िल और ऑरेंज एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_03.png)

पिक्चर फ़िल का उपयोग करने के लिए, इमेज को प्रस्तुति में जोड़ें और उसे shape फ़िल को असाइन करें। यह उदाहरण कार्यशील निर्देशिका में "image.jpg" नाम की मौजूदा फ़ाइल की आवश्यकता रखता है। यह पिक्चर को आयत को भरने के लिए फैलाता है, 150‑पॉइंट एक्सट्रूज़न लागू करता है, और कैमरा घूर्णन को डिग्री में सेट करता है। यह shape को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे या रेंडर किए:

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

![सामने वाले चेहरे पर फोटो फ़िल और ऑरेंज एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_04.png)

## **टेक्स्ट पर 3D फ़ॉर्मेटिंग लागू करें**

Shape की 3D फ़ॉर्मेटिंग shape बॉडी को प्रभावित करती है। टेक्स्ट की 3D फ़ॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt‑समान इफ़ेक्ट्स के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, मैटेरियल, लाइटिंग, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्नलिखित उदाहरण एक ऑरेंज‑एंड‑व्हाइट ग्रिड पैटर्न के साथ टेक्स्ट बनाता है, एक ऊपर की ओर आर्च लागू करता है, और [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) के माध्यम से 3D सेटिंग्स कॉन्फ़िगर करता है। एक्सट्रूज़न ऊँचाई और डेप्थ पॉइंट्स में हैं, और लाइट घूर्णन डिग्री में है। shape फ़िल और आउटलाइन छिपे हुए हैं ताकि केवल टेक्स्ट दिखाई दे। यह उदाहरण डिफॉल्ट स्लाइड आकार के दो गुना PNG इमेज रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है:

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

![आर्च्ड WordArt ट्रांसफ़ॉर्म, ऑरेंज पैटर्न फ़िल, और डार्क एक्सट्रूज़न के साथ रेंडर किया गया 3D टेक्स्ट](img_02_05.png)

## **3D Shape पर टेक्स्ट को फ्लैट रखें**

shape की 3D उपस्थिति को बनाए रखते हुए टेक्स्ट को पठनीय रखने के लिए, [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) के माध्यम से [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) को कॉल करें। जब मान `true` है, तो टेक्स्ट 3D सीन से बाहर रहता है। जब यह `false` होता है, तो टेक्स्ट सीन में भाग लेता है और उसकी 3D अभिविन्यास का पालन करता है।

यह सेटिंग shape की 3D फ़ॉर्मेटिंग को हटाती नहीं है: उसका कैमरा, लाइटिंग, मैटेरियल, और एक्सट्रूज़न अभी भी [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) से कॉन्फ़िगर रहता है। यह सामान्य घूर्णन से भी अलग है। [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) स्लाइड प्लेन में shape को घुमाता है, जबकि [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) टेक्स्ट के बाउंडिंग बॉक्स के भीतर कस्टम घूर्णन को नियंत्रित करता है। टेक्स्ट को 3D सीन से बाहर रखने से इन कोणों में से कोई भी रीसेट नहीं होता।

निम्नलिखित आत्म-निहित उदाहरण एक नीला आयत टेक्स्ट के साथ बनाता है और उसे मूल के बगल में क्लोन करता है। दोनों shapes में एक ही 3D फ़ॉर्मेटिंग है; केवल टेक्स्ट सेटिंग अलग है: बाएँ पर `false` और दाएँ पर `true`। कैमरा कोण डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 40 पॉइंट्स है। यह उदाहरण प्रस्तुति को PPTX के रूप में सहेजता है और तुलना स्लाइड को PNG में डिफॉल्ट आकार के दो गुना रेंडर करता है।

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

बाएँ पर, टेक्स्ट 3D अभिविन्यास का अनुसरण करता है। दाएँ पर, यह फ्लैट रहता है और पढ़ने में आसान है। दोनों आयत समान दिखने वाला एक्सट्रूज़न और 3D अभिविन्यास रखती हैं।

![साइड‑बाय‑साइड 3D आयत: बाएँ पर टेक्स्ट 3D अभिविन्यास का अनुसरण करता है और दाएँ पर फ्लैट रहता है](keep_text_flat.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में सहेजते समय 3D फ़ॉर्मेटिंग को बनाए रखता है। जब रेंडरिंग या निर्यात फ़िक्स्ड‑लेआउट फ़ॉर्मेट में किया जाता है, तो 3D सीन को रास्टराइज़ या 2D परिणाम के रूप में आउटपुट में ड्रॉ किया जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/nodejs-java/convert-powerpoint-to-png/) में रेंडर करते हैं, [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/) में निर्यात करते हैं, या [video conversion](/slides/hi/nodejs-java/convert-powerpoint-to-video/) के लिए फ्रेम उत्पन्न करते हैं।

इन बिंदुओं को ध्यान में रखें:

- निर्यात किए गए इमेज और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक ऑब्जेक्ट को घुमा नहीं सकता।
- अंतिम दिखावट कैमरा, लाइट रिग, मैटेरियल, एक्सट्रूज़न, फ़िल, और स्लाइड स्केलिंग के संयोजन पर निर्भर करती है।
- यदि आपको इनहेरिटेड या थीम‑आधारित फ़ॉर्मेटिंग मानों की जाँच करनी है, तो [effective shape properties](/slides/hi/nodejs-java/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट संपादनीय PowerPoint 3D फ़ॉर्मेटिंग को संग्रहीत नहीं कर सकते। उन फ़ॉर्मेट में, दृश्य परिणाम को रेंडर किया जाता है न कि संपादनीय 3D सेटिंग्स के रूप में संरक्षित किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियाँ बना सकता है?**

Aspose.Slides shapes और टेक्स्ट के लिए PowerPoint 3D इफ़ेक्ट्स बनाता और रेंडर करता है। यह निर्यात किए गए इमेज, PDF, या HTML पेज को इंटरैक्टिव 3D सीन नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फ़ॉर्मेटिंग PowerPoint में संपादनीय बनी रहती है।

**3D मॉडल और 3D इफ़ेक्ट के बीच क्या अंतर है?**

एक 3D मॉडल एक अलग 3D वस्तु है जिसे प्रस्तुति में डाला जाता है। एक 3D इफ़ेक्ट सामान्य PowerPoint shape या टेक्स्ट पर लागू फ़ॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, और मैटेरियल। यह लेख 3D इफ़ेक्ट्स को कवर करता है।

**एक दृश्यमान 3D shape के लिए कौन सी सेटिंग्स आवश्यक हैं?**

न्यूनतम रूप से, कैमरा घूर्णन और या तो एक्सट्रूज़न या डेप्थ सेट करें। व्यावहारिक रूप से, लाइट रिग और मैटेरियल भी सेट करें ताकि रेंडर किए गए चेहरे में स्पष्ट हाइलाइट्स और शैडोज़ हों।

**क्या मैं 3D इफ़ेक्ट्स दोनों shape और टेक्स्ट पर लागू कर सकता हूँ?**

हां। shape बॉडी के लिए [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) और टेक्स्ट के लिए [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) का उपयोग करें।

**क्या 3D इफ़ेक्ट्स इमेज, PDF, HTML, या वीडियो फ्रेम्स में निर्यात करने पर दिखेंगे?**

हां। Aspose.Slides स्लाइड इमेज, PDF आउटपुट, HTML आउटपुट, और वीडियो कन्वर्ज़न के लिए उपयोग किए जाने वाले फ्रेम बनाते समय 3D इफ़ेक्ट्स को रेंडर करता है। निर्यातित आउटपुट में रेंडर किया गया रूप दिखाई देता है, न कि संपादनीय 3D ऑब्जेक्ट।

**क्या मैं इनहेरिटेंस और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मानों को पढ़ सकता हूँ?**

हां। अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मानों को पढ़ने के लिए [Shape Effective Properties](/slides/hi/nodejs-java/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग API का उपयोग करें।