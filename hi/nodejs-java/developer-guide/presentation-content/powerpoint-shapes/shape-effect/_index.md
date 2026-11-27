---
title: JavaScript का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/nodejs-java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- ग्लो प्रभाव
- सॉफ्ट एजेज प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js का उपयोग करके अपने PPT और PPTX फ़ाइलों को उन्नत आकार प्रभावों के साथ बदलें—सेकंडों में आकर्षक, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

जबकि PowerPoint में इफ़ेक्ट्स का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, वे [भराव](/slides/hi/nodejs-java/shape-formatting/#gradient-fill) या outlines से अलग हैं। PowerPoint इफ़ेक्ट्स का उपयोग करके आप एक आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैल सकते हैं, आदि।

![आकार प्रभाव](shape-effect.png)

PowerPoint छह इफ़ेक्ट्स प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक आकार पर एक या अधिक इफ़ेक्ट्स लागू कर सकते हैं।

कुछ इफ़ेक्ट संयोजन दूसरों की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक इफ़ेक्ट्स के ऐसे संयोजन हैं जो अच्छे दिखने के लिए जाने जाते हैं। इस प्रकार, एक प्रीसेट चुनकर, आपको विभिन्न इफ़ेक्ट्स का परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides उन गुणों और विधियों को प्रदान करता है जो [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) क्लास के अंतर्गत हैं, जिससे आप PowerPoint प्रस्तुतियों में आकारों पर समान इफ़ेक्ट्स लागू कर सकते हैं।

## **छाया इफ़ेक्ट लागू करें**

Aspose.Slides for Node.js via Java आकारों के लिए बाहरी और अंतः छायाएँ समर्थन करता है। आप उनके रंग, दिशा, दूरी और धुंधलापन त्रिज्या को अपनी प्रस्तुति के डिजाइन से मिलाने के लिए अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

स्लाइड पृष्ठभूमि के खिलाफ कार्ड या पैनल को प्रमुख बनाने के लिए बाहरी छाया का उपयोग करें। छाया आकार के किनारों से परे फैलती है, जिससे ऐसा प्रभाव बनता है कि आकार स्लाइड के ऊपर उभरा हुआ है। अपनी टेम्प्लेट की रोशनी और शैली से मेल खाने के लिए इसका रंग, दिशा, दूरी और धुंधलापन त्रिज्या समायोजित करें।

यह JavaScript कोड दिखाता है कि कैसे [बाहरी छाया इफ़ेक्ट](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) को आयत पर लागू किया जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![छाया इफ़ेक्ट](shadow_effect.png)

#### **जब आकार घूमता है तो छाया दिशा नियंत्रित करें**

डिफ़ॉल्ट रूप से, बाहरी छाया आकार के साथ घुमती है। विभिन्न घुमाव वाले आकारों को एक ही दिशा से प्रकाशित दिखाने के लिए, [setRotateShadowWithShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setRotateShadowWithShape) को `false` के साथ कॉल करें और अपनी छायाओं को समान दिशा देने के लिए [setDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setDirection) का उपयोग करें।

उदाहरण दो नीली तीर बनाता है जिनकी ग्रे छायाएँ 42 पॉइंट्स दाईं ओर (0°) ऑफ़सेट होती हैं। फिर यह स्लाइड को डुप्लिकेट करता है और दोनों तीरों को 90° घड़ी की दिशा में घुमाता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const before = presentation.getSlides().get_Item(0);
    
    const left = before.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    left.getFillFormat().getSolidFillColor().setColor(fillColor);
    left.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    left.getEffectFormat().enableOuterShadowEffect();
    const shadow = left.getEffectFormat().getOuterShadowEffect();
    const shadowColor = java.getStaticFieldValue("java.awt.Color", "GRAY");
    shadow.getShadowColor().setColor(shadowColor);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    const right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    const after = presentation.getSlides().addClone(before);
    const arrows = after.getShapes();
    for (let i = 0; i < arrows.size(); i++) {
        arrows.get_Item(i).setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

दूसरी स्लाइड पर, बाएँ तीर की छाया नीचे की ओर पड़ती है, जबकि दाएँ तीर की छाया अभी भी दाईं ओर पड़ती है। दोनों छायाओं के लिए कॉन्फ़िगर की गई दिशा 0° बनी रहती है।

![90° घुमाव से पहले और बाद में PowerPoint रेंडरिंग। दोनों छायाएँ दाईं ओर शुरू होती हैं। घुमाव के बाद, छाया बाएँ तीर के नीचे चली जाती है और दाएँ तीर के दाईं ओर बनी रहती है।](arrow-shadow-rotation.png)

### **आंतरिक छाया लागू करें**

टेम्प्लेट की दृश्य शैली को पुनः निर्मित करते समय, कार्ड या पैनल को गहरी दिखाने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर विस्तारित होती है और इसे उभरा हुआ बनाती है, जबकि आंतरिक छाया उसके किनारों के अंदर को शेड करती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) द्वारा लौटाए गए छाया को कॉन्फ़िगर करें। बड़ी धुंधलापन त्रिज्या मान नरम किनारे उत्पन्न करती हैं।

यह JavaScript उदाहरण हल्के नीले कार्ड को गहरे ग्रे आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री, दूरी 7 पॉइंट, और धुंधलापन त्रिज्या 6 पॉइंट है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![हल्के नीले आयत में अंदर की छाया](inner_shadow_effect.png)

आंतरिक छाया को हटाने के लिए, आकार की इफ़ेक्ट फॉर्मेट पर [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) को कॉल करें।

### **प्रीसेट छाया लागू करें, बदलें, और हटाएँ**

[enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) को कॉल करें और [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) का उपयोग करके [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/) चुनें। शैली बदलने के लिए, समान आकार पर प्रीसेट बदलें। छाया को हटाने के लिए लेकिन भराव और रूपरेखा को बनाए रखने के लिए, [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) को कॉल करें।

यह उदाहरण एक ही स्लाइड पर चार चरणों को साइड बाय साइड दिखाता है। दोनों छायाएँ 10 पॉइंट्स ऑफ़सेट हैं। 225° दिशा पहली छाया को आयत के ऊपर और बाएँ रखती है, और 45° दिशा दूसरी को नीचे और दाएँ रखती है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, aspose.slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const shape = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    const shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(aspose.slides.PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(aspose.slides.PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| मूल | पहला प्रीसेट | दूसरा प्रीसेट | हटाने के बाद |
| :---: | :---: | :---: | :---: |
| ![कोई छाया नहीं](preset_shadow_original.png) | ![ऊपर-बाएँ ड्रॉप शैडो](preset_shadow_top_left.png) | ![नीचे-दाएँ ड्रॉप शैडो](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई छाया नहीं](preset_shadow_removed.png) |

## **परावर्तन इफ़ेक्ट लागू करें**

Aspose.Slides for Node.js via Java में परावर्तन इफ़ेक्ट लागू करने के लिए, आप आकारों में दर्पण जैसी परावर्तन जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह इफ़ेक्ट आपकी प्रस्तुतियों की सौंदर्यशास्त्र को बेहतर बनाता है, जिससे आकार अधिक परिष्कृत दिखते हैं। इसे सरल कोड के साथ लागू करना आसान है, जिससे कई तत्वों पर एकसमान डिज़ाइन तेज़ी से लागू हो सकता है।

यह JavaScript कोड दिखाता है कि कैसे [परावर्तन इफ़ेक्ट](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) को आकार पर लागू किया जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![परावर्तन इफ़ेक्ट](reflection_effect.png)

## **ग्लो इफ़ेक्ट लागू करें**

Aspose.Slides for Node.js via Java में आकार पर ग्लो इफ़ेक्ट लागू करने के लिए, आप आकारों के आसपास एक नरम, चमकीला परिप्रेक्ष्य जोड़ सकते हैं, रंग और आकार जैसी गुणों को समायोजित कर सकते हैं। यह इफ़ेक्ट आकारों को प्रमुख बनाता है और आपके प्रस्तुति में आकर्षक दृश्य तत्व जोड़ता है। इसे न्यूनतम कोड के साथ लागू करना आसान है, जिससे आपकी स्लाइड्स का समग्र स्वरूप बेहतर होता है।

यह JavaScript कोड दिखाता है कि कैसे [ग्लो इफ़ेक्ट](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) को आकार पर लागू किया जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ग्लो इफ़ेक्ट](glow_effect.png)

## **सॉफ्ट एजेज इफ़ेक्ट लागू करें**

Aspose.Slides for Node.js via Java में सॉफ्ट एजेज इफ़ेक्ट लागू करने के लिए, आप आकार के किनारों के आसपास एक सुगम, धुंधला संक्रमण बना सकते हैं। यह इफ़ेक्ट अधिक सूक्ष्म और परिष्कृत दिखावट जोड़ता है, जो उन डिज़ाइनों के लिए उपयुक्त है जिन्हें हल्का, नरम रूप चाहिए। आप विभिन्न आकारों में इच्छित प्रभाव प्राप्त करने के लिए त्रिज्या जैसे पैरामीटर को आसानी से समायोजित कर सकते हैं।

यह JavaScript कोड दिखाता है कि कैसे [सॉफ्ट एजेज इफ़ेक्ट](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) को आकार पर लागू किया जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![सॉफ्ट एजेज इफ़ेक्ट](soft_edges_effect.png)

## **ब्लर इफ़ेक्ट लागू करें**

शेप ब्लर का उपयोग आकार की भराव और रूपरेखा को नरम करने के लिए किया जाता है जबकि आकार संपादनीय रहता है। आकार की इफ़ेक्ट फॉर्मेट पर [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करें। त्रिज्या पॉइंट्स (1/72 इंच) में मापी जाती है: एक गैर-नकारात्मक मान का उपयोग करें, बड़ा मान अधिक तेज़ ब्लर दर्शाता है। शून्य त्रिज्या होने पर दिखावट अपरिवर्तित रहती है।

[getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) सेटिंग इफ़ेक्ट की दृश्यमान सीमाओं को नियंत्रित करती है। `false` होने पर, ब्लर मूल पेंटेड सीमाओं (रूपरेखा सहित) तक ही सीमित रहता है। `true` होने पर, ब्लर उन सीमाओं से बाहर भी जा सकता है। इन सेटिंग्स से आकार की स्थिति या आयाम नहीं बदलते।

नीचे का तुलना वही भराव, रूपरेखा और आकार आयामों का उपयोग करके बनाई गई है। शीर्ष पंक्ति में `grow = false` है; नीचे की पंक्ति में `grow = true`।

![मूल आयत का 5 और 15 पॉइंट ब्लर त्रिज्या के साथ तुलना, जहाँ grow निष्क्रिय और सक्रिय है](shape_blur_comparison.png)

यह JavaScript उदाहरण एक नारंगी आयत को डार्क ब्लू रूपरेखा के साथ बनाता है, 5 पॉइंट ब्लर लागू करता है, फिर [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) को फिर से कॉल करके 15 पॉइंट ब्लर में अद्यतन करता है। दोनों ब्लर स्थितियों को सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) को कॉल करके ब्लर के बिना आकार को सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

शेप ब्लर भराव और रूपरेखा दोनों को साथ ही प्रभावित करता है। सॉफ्ट एजेज इफ़ेक्ट आकार के किनारों को फेड करता है, जबकि शैडो ब्लर केवल शैडो को नरम करता है। छवि रूपांतरण इफ़ेक्ट छवि सामग्री पर काम करते हैं; यह उदाहरण आकार को छवि में बदलें बिना सीधे उसके इफ़ेक्ट फॉर्मेट पर ब्लर लागू करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई इफ़ेक्ट्स लागू कर सकता हूँ?**

हां, आप एक ही आकार पर शैडो, परावर्तन और ग्लो जैसे विभिन्न इफ़ेक्ट्स को संयोजित कर अधिक गतिशील दिखावट बना सकते हैं।

**मैं किन आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

आप विभिन्न आकारों पर इफ़ेक्ट्स लागू कर सकते हैं, जिसमें ऑटoshapes, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अन्य शामिल हैं।

**क्या मैं समूहित आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

हां, आप समूहित आकारों पर इफ़ेक्ट्स लागू कर सकते हैं। इफ़ेक्ट पूरे समूह पर लागू होगा।