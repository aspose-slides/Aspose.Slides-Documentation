---
title: "Node.js का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएँ"
linktitle: "3D प्रस्तुति"
type: docs
weight: 232
url: /hi/nodejs-java/3d-presentation/
keywords:
- "3D PowerPoint"
- "3D प्रस्तुति"
- "3D घूर्णन"
- "3D गहराई"
- "3D एक्सट्रूज़न"
- "3D ग्रेडिएंट"
- "3D टेक्स्ट"
- "PowerPoint"
- "प्रस्तुति"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Node.js में Aspose.Slides के साथ PowerPoint shapes और टेक्स्ट के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, प्रकाश, सामग्री, एक्सट्रूज़न, फ़िल, और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java shapes और text के लिए PowerPoint‑स्टाइल 3D फ़ॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, extrusion, bevels, प्रकाश, सामग्री, ग्रेडिएंट या चित्र भराव, और 3D टेक्स्ट जैसे 3D प्रभावों को कवर करता है।

{{% alert color="primary" %}}
यह लेख PowerPoint shapes और text पर 3D फ़ॉर्मेटिंग प्रभावों के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप किसी स्लाइड को छवि, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D प्रभावों को निर्यातित 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

[Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` का उपयोग करके shape पर 3D फ़ॉर्मेटिंग लागू करें। लौटाई गई [ThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/) ऑब्जेक्ट उस shape के लिए 3D दृश्य को नियंत्रित करती है।

टेक्स्ट के लिए, [TextFrameFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` का उपयोग करें। यह shape के शरीर के बजाय टेक्स्ट फ्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण API सदस्य हैं:

| API सदस्य | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getCamera) | दृश्य बिंदु, प्रीसेट कैमरा प्रकार, घूर्णन, ज़ूम, और परिप्रेक्ष्य। | 3D स्थान में वस्तु को घुमाने या PowerPoint के 3D घूर्णन प्रीसेट से मेल करने के लिए। |
| [getLightRig](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getLightRig) | प्रकाश प्रीसेट, दिशा, और प्रकाश घूर्णन। | 3D सतह पर हाईलाइट और छाया के स्वरूप को बदलने के लिए। |
| [getMaterial](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getMaterial) और [setMaterial](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#setMaterial) | सतह सामग्री, जैसे फ़्लैट, मैट, प्लास्टिक, या मेटल। | समान ज्यामिति को अधिक फ़्लैट, नरम, चमकदार, या धातु जैसा बनाने के लिए। |
| [getExtrusionHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) और [setExtrusionHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | shape की सामने वाली सतह से पीछे तक कितनी दूरी तक विस्तारित होती है। | एक फ़्लैट shape को स्पष्ट रूप से मोटी 3D वस्तु में बदलने के लिए। |
| [getExtrusionColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Extruded पक्षों का रंग। | गहराई को दृश्य बनाने या साइड के रंग को सामने की भराव के साथ समन्वयित करने के लिए। |
| [getDepth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getDepth) और [setDepth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग की जाने वाली अतिरिक्त 3D गहराई। | shape या टेक्स्ट के लिए गहराई को सूक्ष्म रूप से समायोजित करने के लिए, विशेषकर bevel और material सेटिंग्स के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getBevelTop) और [getBevelBottom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | सामने और पीछे के चेहरों पर उठे या गोल किनारे। | तीखे फ़्लैट चेहरे के बजाय नरम या ढला हुआ किनारा जोड़ने के लिए। |
| [getContourColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getContourWidth), और [setContourWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D वस्तु के चारों ओर रूपरेखा। | रेंडर आउटपुट में वस्तु की सीमा को स्पष्ट करने के लिए। |

## **3D Shape बनाएं**

एक shape को विश्वसनीय 3D दिखाने के लिए आमतौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट सामने दृश्य extrusion को छिपा सकता है।
- प्रकाश सेटिंग्स, क्योंकि प्रकाश चेहरे और पक्षों को पढ़ने योग्य बनाता है।
- सामग्री सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि प्रकाश कैसे रेंडर होता है।
- extrusion या depth सेटिंग्स, क्योंकि फ़्लैट shape को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसकी सामने वाली सतह पर टेक्स्ट जोड़ता है, 3D फ़ॉर्मेटिंग लागू करता है, प्रस्तुति को PPTX के रूप में सहेजता है, और स्लाइड को PNG छवि में रेंडर करता है।

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

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

रेंडर की गई स्लाइड छवि आयत को मोटे 3D ब्लॉक के रूप में दिखाती है:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **कैमरा के साथ Shape को घुमाएँ**

PowerPoint में, 3D घूर्णन 3‑D Rotation पेन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन के अनुरूप होते हैं।

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides में, `shape.getThreeDFormat()` द्वारा लौटाए गए 3D फ़ॉर्मेट के माध्यम से कैमरा प्रकार और घूर्णन सेट करें:

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

जब आपको दर्शक के वस्तु को देखने के तरीके को बदलना हो, तो कैमरा का उपयोग करें। यह स्लाइड पर 2D shape ज्यामिति को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृश्य बिंदु को बदलता है।

## **Extrusion और Depth जोड़ें**

Extrusion shape को मोटा बनाता है, जिससे वह सामने वाली सतह के पीछे तक बढ़ता है। PowerPoint में, depth नियंत्रण इस दृश्यमान मोटाई को निर्धारित करता है, और रंग नियंत्रण साइड फेस के रंग को निर्धारित करता है।

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

मोटाई के लिए extrusion height सेट करें और साइड रंग के लिए extrusion color सेट करें:

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

जब आपको सीधे PowerPoint के depth मूल्य के साथ काम करना हो या depth को bevel, material, और text प्रभावों के साथ मिलाना हो, तो depth सेटिंग का उपयोग करें। कई shape परिदृश्यों में, extrusion height स्पष्ट सेटिंग है क्योंकि यह सीधे दृश्यमान extrusion को व्यक्त करता है।

## **3D प्रभावों के साथ Gradient या Picture Fill का उपयोग करें**

3D फ़ॉर्मेटिंग shape fill से स्वतंत्र है। आप सामने वाली सतह पर ठोस रंग, ग्रेडिएंट, पैटर्न, या चित्र भराव लागू कर सकते हैं और फिर भी वही कैमरा, प्रकाश, सामग्री, और extrusion सेटिंग्स का उपयोग कर सकते हैं।

यह उदाहरण shape पर एक ग्रेडिएंट भराव और किनारों पर गहरा extrusion रंग लागू करता है:

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

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

रेंडर किया गया आउटपुट सामने वाली सतह पर ग्रेडिएंट को बनाए रखता है और extrusion को अलग से रेंडर करता है:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

चित्र भराव का उपयोग करने के लिए, चित्र को प्रस्तुति में जोड़ें और उसे shape भराव को असाइन करें:

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

चित्र सामने वाली सतह पर रेंडर होता है, जबकि extrusion 3D साइड सतह के रूप में रेंडर होता है:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **टेक्स्ट पर 3D फ़ॉर्मेटिंग लागू करें**

Shape 3D फ़ॉर्मेटिंग shape के शरीर को प्रभावित करती है। टेक्स्ट 3D फ़ॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt‑समान प्रभावों के लिए उपयोगी है जहाँ अक्षरों को स्वयं extrusion, material, प्रकाश, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण एक पैटर्न भराव के साथ टेक्स्ट बनाता है, WordArt ट्रांसफ़ॉर्म लागू करता है, और [TextFrameFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` पर 3D सेटिंग्स कॉन्फ़िगर करता है:

```javascript
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
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
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

टेक्स्ट को वक्र, extruded 3D अक्षरों के रूप में रेंडर किया गया है:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में सहेजते समय 3D फ़ॉर्मेटिंग को संरक्षित रखता है। जब आप स्थिर‑लेआउट फ़ॉर्मेट में रेंडर या निर्यात करते हैं, तो 3D दृश्य को रास्टराइज़ या 2D परिणाम के रूप में आउटपुट में खींचा जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/nodejs-java/convert-powerpoint-to-png/) में रेंडर करते हैं, [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/) में निर्यात करते हैं, या [video conversion](/slides/hi/nodejs-java/convert-powerpoint-to-video/) के लिए फ्रेम उत्पन्न करते हैं।

इन बिंदुओं को ध्यान में रखें:

- निर्यातित छवियां और PDFs इंटरैक्टिव नहीं होतीं। निर्यात के बाद दर्शक वस्तु को घुमा नहीं सकता।
- अंतिम स्वरूप कैमरा, लाइट रिग, मैटेरियल, extrusion, fill, और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।
- यदि आपको विरासत या थीम‑आधारित फ़ॉर्मेटिंग मानों की जांच करनी है, तो [effective shape properties](/slides/hi/nodejs-java/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट संपादन योग्य PowerPoint 3D फ़ॉर्मेटिंग को संग्रहीत नहीं कर सकते। उन फ़ॉर्मेट में दृश्य परिणाम को रेंडर किया जाता है, न कि संपादन योग्य 3D सेटिंग्स के रूप में संरक्षित किया जाता है।

## **FAQ**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुति बना सकता है?**

Aspose.Slides shapes और text के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह निर्यातित छवियों, PDFs, या HTML पृष्ठों को ऐसे इंटरैक्टिव 3D दृश्य नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फ़ॉर्मेटिंग PowerPoint में संपादन योग्य रहती है।

**3D मॉडल और 3D प्रभाव में क्या अंतर है?**

3D मॉडल एक अलग 3D ऑब्जेक्ट है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D प्रभाव एक सामान्य PowerPoint shape या टेक्स्ट पर लागू फ़ॉर्मेटिंग है, जैसे घूर्णन, extrusion, bevel, प्रकाश, और सामग्री। यह लेख 3D प्रभावों को कवर करता है।

**एक दृश्य 3D shape के लिए कौन-सी सेटिंग्स आवश्यक हैं?**

कम से कम कैमरा घूर्णन और extrusion या depth सेट करें। व्यावहारिक रूप से, प्रकाश रिग और सामग्री भी सेट करें ताकि रेंडर किए गए चेहरे में स्पष्ट हाईलाइट और छाया हों।

**क्या मैं shapes और text दोनों पर 3D प्रभाव लागू कर सकता हूँ?**

हाँ। shape शरीर के लिए [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` और टेक्स्ट के लिए [TextFrameFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` का उपयोग करें।

**क्या 3D प्रभाव छवियों, PDF, HTML, या वीडियो फ्रेम में निर्यात करते समय दिखाई देंगे?**

हाँ। Aspose.Slides स्लाइड छवियों, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए प्रयुक्त फ्रेम बनाते समय 3D प्रभाव रेंडर करता है। निर्यातित आउटपुट में रेंडर किया गया स्वरूप शामिल होता है, न कि संपादन योग्य 3D ऑब्जेक्ट।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हाँ। [Shape Effective Properties](/slides/hi/nodejs-java/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग API का उपयोग करके अंतिम कैमरा, लाइट रिग, bevel, और संबंधित 3D मान पढ़ सकते हैं।