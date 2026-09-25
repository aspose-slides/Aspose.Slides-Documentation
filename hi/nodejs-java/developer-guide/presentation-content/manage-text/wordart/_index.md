---
title: Node.js में WordArt प्रभाव बनाएं और लागू करें
linktitle: WordArt
type: docs
weight: 110
url: /hi/nodejs-java/wordart/
keywords:
- WordArt
- WordArt बनाना
- WordArt टेम्प्लेट
- WordArt प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- ग्लो प्रभाव
- WordArt रूपांतरण
- 3D प्रभाव
- बाहरी छाया प्रभाव
- आंतरिक छाया प्रभाव
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java में WordArt प्रभाव बनाएं और अनुकूलित करें। यह क्रमवार मार्गदर्शिका डेवलपर्स को Node.js में पेशेवर टेक्स्ट के साथ प्रस्तुतियों को बेहतर बनाने में मदद करती है।"
---
## **अवलोकन**

WordArt प्रभाव आपको टेक्स्ट को फ़िल, आउटलाइन, शैडो, रिफ्लेक्शन, ग्लो, ट्रांसफ़ॉर्मेशन और 3D फ़ॉर्मेटिंग के साथ स्टाइल करने देते हैं। यह लेख Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint प्रस्तुतियों में इन प्रभावों को बनाने और अनुकूलित करने का तरीका समझाता है, बिना Microsoft Office स्थापित किए।

## **एक सरल WordArt टेम्प्लेट बनाएं और इसे टेक्स्ट पर लागू करें**

निम्न उदाहरण टेक्स्ट, फ़ॉन्ट, पैटर्न फ़िल और आउटलाइन सेट करके एक सरल WordArt शैली बनाते हैं।

प्रत्येक उदाहरण नया प्रेजेंटेशन बनाता है और उसकी पहली स्लाइड में एक आयत जोड़ता है; कोई इनपुट फ़ाइल आवश्यक नहीं है। पहला उदाहरण टेक्स्ट को "Aspose.Slides" सेट करता है। आकार की स्थिति और आयाम पॉइंट्स में मापे जाते हैं:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

फ़ॉर्मेटिंग को अधिक स्पष्ट करने के लिए फ़ॉन्ट को Arial Black 36 पॉइंट पर सेट करें:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

एक गहरा नारंगी फ़ॉरग्राउंड और सफ़ेद बैकग्राउंड वाला [SmallGrid](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/patternstyle/#SmallGrid) पैटर्न लागू करें, फिर 1 पॉइंट की चौड़ाई वाला काले टेक्स्ट आउटलाइन जोड़ें:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

परिणामस्वरूप टेक्स्ट:

![सरल WordArt टेम्प्लेट](WordArt_template.png)

## **अन्य WordArt प्रभाव लागू करें**

निम्न उदाहरण शैडो, रिफ्लेक्शन, ग्लो, ट्रांसफ़ॉर्मेशन और 3D प्रभावों को टेक्स्ट पर लागू करने का प्रदर्शन करते हैं।

### **बाहरी छाया प्रभाव लागू करें**

एक बाहरी छाया टेक्स्ट के पीछे छाया रखकर गहराई जोड़ती है। आप इसका रंग, दिशा, दूरी, ब्लर रेडियस, स्केल और स्क्यू कस्टमाइज़ कर सकते हैं।

यह उदाहरण [enableOuterShadowEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) को कॉल करता है और 4‑पॉइंट ब्लर रेडियस, 230‑डिग्री दिशा और 30‑पॉइंट दूरी वाला काला शैडो सेट करता है। स्केल मान 100 छाया का आकार बनाए रखते हैं, जबकि क्षैतिज स्क्यू इसे 20 डिग्री झुकाता है। अल्फ़ा ट्रांसफ़ॉर्म इसकी अपारदर्शिता को 32 % सेट करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

परिणामस्वरूप टेक्स्ट:

![बाहरी छाया प्रभाव](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- जब बाहरी और प्रीसेट शैडो एक साथ उपयोग किए जाते हैं, तब केवल बाहरी शैडो लागू होता है।
- यदि बाहरी और आंतरिक शैडो एक साथ उपयोग किए जाते हैं, तो परिणामस्वरूप प्रभाव PowerPoint संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में प्रभाव दो倍 हो जाता है, जबकि PowerPoint 2007 में केवल बाहरी शैडो लागू होता है।
{{% /alert %}}

### **परावर्तन प्रभाव लागू करें**

परावर्तन टेक्स्ट की एक प्रतिबिंबित प्रतिलिपि बनाता है। उसकी स्थिति, स्केल, ब्लर और अपारदर्शिता को समायोजित करके आप उसकी उपस्थिति नियंत्रित कर सकते हैं।

यह उदाहरण [enableReflectionEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) को कॉल करता है और -100 % स्केल के साथ परावर्तन को लंबवत घुमा देता है। यह 0.5‑पॉइंट ब्लर रेडियस और 4.72‑पॉइंट दूरी का उपयोग करता है। अपारदर्शिता 60 % से 0.9 % तक घटती है जब परावर्तन 0 % से 60 % स्थितियों के बीच जाता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

परिणामस्वरूप टेक्स्ट:

![परावर्तन प्रभाव](reflection_effect.png)

### **ग्लो प्रभाव लागू करें**

ग्लो टेक्स्ट के चारों ओर एक कोमल रंगीन आउटलाइन जोड़ता है। आप इसका रंग, अपारदर्शिता और रेडियस समायोजित करके प्रभाव को नियंत्रित कर सकते हैं।

यह उदाहरण [enableGlowEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) को कॉल करता है और 54 % अपारदर्शिता तथा 7 पॉइंट रेडियस वाला लाल ग्लो लागू करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

परिणामस्वरूप टेक्स्ट:

![ग्लो प्रभाव](glow_effect.png)

### **WordArt रूपांतरण लागू करें**

WordArt रूपांतरण टेक्स्ट ब्लॉक को मोड़ते, खींचते या विकृत करते हैं।

[setTransform](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setTransform) को [ArchUpPour](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textshapetype/#ArchUpPour) पर सेट करके पूरे टेक्स्ट फ्रेम को ऊपर की ओर वक्र बनाएं:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

परिणामस्वरूप टेक्स्ट:

![WordArt रूपांतरण](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java पूर्वनिर्धारित [रूपांतरण प्रकार](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textshapetype/) का सेट प्रदान करता है।
{{% /alert %}}

### **आकार और टेक्स्ट पर 3D प्रभाव लागू करें**

आप आकार या उसके टेक्स्ट पर 3D प्रभाव लगा सकते हैं। बिवेल, एक्सट्रूज़न, लाइटिंग और कैमरा सेटिंग्स परिणामस्वरूप उपस्थिति को नियंत्रित करती हैं।

निम्न उदाहरण [ThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/) का उपयोग करके आयत में वृत्ताकार बिवेल, नारंगी एक्सट्रूज़न और गहरे लाल कॉर्नर जोड़ता है। बिवेल आयाम, एक्सट्रूज़न ऊँचाई, कॉर्नर चौड़ाई और गहराई पॉइंट्स में मापे जाते हैं। प्लास्टिक सामग्री, Z‑अक्ष के चारों ओर 40 डिग्री रोटेटेड बैलेंस्ड लाइटिंग और परस्पेक्टिव कैमरा इसकी उपस्थिति को परिभाषित करते हैं:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

परिणामस्वरूप आकार:

![आकार 3D प्रभाव](shape_3D_effect.png)

यह उदाहरण टेक्स्ट पर समान 3D फ़ॉर्मेटिंग लागू करता है, इसके लिए [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) का उपयोग किया जाता है। छोटे बिवेल अक्षर किनारों को आकार देते हैं, जबकि एक्सट्रूज़न और लाइटिंग टेक्स्ट को गहराई देते हैं:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

परिणामस्वरूप टेक्स्ट:

![टेक्स्ट 3D प्रभाव](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
टेक्स्ट या उसके आकार पर 3D प्रभावों का अनुप्रयोग—और इन प्रभावों के बीच की परस्पर क्रिया—विशिष्ट नियमों द्वारा निर्धारित होती है। विचार करें कि टेक्स्ट और उसे सम्मिलित करने वाला आकार दोनों एक ही दृश्य में हैं। 3D प्रभाव में वस्तु का 3D प्रतिनिधित्व और वह दृश्य शामिल है जिसमें वह रखा गया है।

- यदि दोनों आकार और टेक्स्ट के लिए दृश्य निर्धारित किया गया है, तो आकार का दृश्य प्राथमिकता लेता है और टेक्स्ट का दृश्य अनदेखा किया जाता है।
- यदि आकार का अपना दृश्य नहीं है लेकिन उसके पास 3D प्रतिनिधित्व है, तो टेक्स्ट का दृश्य उपयोग किया जाता है।
- यदि आकार में बिल्कुल भी 3D प्रभाव नहीं है, तो इसे समतल माना जाता है, और 3D प्रभाव केवल टेक्स्ट पर लागू होता है।

ये व्यवहार [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getLightRig) और [ThreeDFormat.getCamera](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getCamera) विधियों से संबंधित हैं।
{{% /alert %}}

टेक्स्ट को सपाट और पठनीय रखने के साथ-साथ उसके आकार के 3D फ़ॉर्मेटिंग को बनाए रखने के लिए, दोनों सेटिंग्स की तुलना और एक पूर्ण JavaScript उदाहरण के लिए देखें [Keep Text Flat on a 3D Shape](/slides/hi/nodejs-java/3d-presentation/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं WordArt प्रभावों को विभिन्न फ़ॉन्ट या स्क्रिप्ट (जैसे Arabic, Chinese) के साथ उपयोग कर सकता हूँ?**  
हाँ, Aspose.Slides for Node.js via Java Unicode का समर्थन करता है और सभी प्रमुख फ़ॉन्ट तथा स्क्रिप्ट के साथ काम करता है। शैडो, फ़िल और आउटलाइन जैसे WordArt प्रभाव भाषा की परवाह किए बिना लागू किए जा सकते हैं, हालांकि फ़ॉन्ट की उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट पर निर्भर हो सकती है।

**क्या मैं स्लाईड मास्टर तत्वों पर WordArt प्रभाव लागू कर सकता हूँ?**  
हाँ, आप मास्टर स्लाइड्स पर स्थित आकारों, जैसे शीर्षक प्लेसहोल्डर, फुटर या बैकग्राउंड टेक्स्ट, पर WordArt प्रभाव लागू कर सकते हैं। मास्टर लेआउट में किए गए परिवर्तन सभी संबंधित स्लाइड्स में परिलक्षित होंगे।

**क्या WordArt प्रभाव प्रस्तुति फ़ाइल के आकार को प्रभावित करते हैं?**  
थोड़ा। शैडो, ग्लो और ग्रेडिएंट फ़िल जैसे WordArt प्रभाव स्वरूपण मेटाडेटा जोड़ते हैं, जिससे फ़ाइल आकार में हल्का वृद्धि हो सकता है, लेकिन आमतौर पर यह नगण्य रहता है।

**क्या मैं प्रस्तुति को सहेजे बिना WordArt प्रभावों का परिणाम पूर्वावलोकन कर सकता हूँ?**  
हाँ, आप WordArt वाले स्लाइड्स को छवियों (जैसे PNG, JPEG) में रेंडर कर सकते हैं, इसके लिए [Slide.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#getImage) का उपयोग करें, या व्यक्तिगत आकारों को रेंडर करने के लिए [Shape.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getImage) का उपयोग करें। यह आपको पूर्ण प्रस्तुति सहेजने या निर्यात करने से पहले मेमोरी या स्क्रीन पर परिणाम का पूर्वावलोकन करने देता है।