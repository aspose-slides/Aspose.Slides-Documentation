---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/nodejs-java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- ग्लो प्रभाव
- नरम किनारों का प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेकंडों में आकर्षक, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

जबकि PowerPoint में इफ़ेक्ट्स का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, वे [भरण](/slides/hi/nodejs-java/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint इफ़ेक्ट्स का उपयोग करके आप किसी आकार पर भरोसेमंद प्रतिबिंब, आकार की चमक आदि बना सकते हैं।

![आकार प्रभाव](shape-effect.png)

PowerPoint छह इफ़ेक्ट्स प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक आकार पर एक या अधिक इफ़ेक्ट्स लागू कर सकते हैं।

कुछ इफ़ेक्ट्स के संयोजन दूसरों की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। प्रीसेट विकल्प दो या अधिक इफ़ेक्ट्स के ऐसे संयोजन होते हैं जो सामान्यतः अच्छा दिखते हैं। इस तरह, एक प्रीसेट चुनकर आपको विभिन्न इफ़ेक्ट्स का परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) क्लास के अंतर्गत प्रॉपर्टीज़ और मेथड्स प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान इफ़ेक्ट्स लागू करने की अनुमति देते हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Node.js via Java आकारों के लिए बाहरी और आंतरिक छाया का समर्थन करता है। आप उनके रंग, दिशा, दूरी, और ब्लर त्रिज्या को अपनी प्रस्तुति की डिज़ाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

एक बाहरी छाया का उपयोग करके कार्ड या पैनल को स्लाइड पृष्ठभूमि के सामने प्रमुख बनाएँ। छाया आकार की किनारों से बाहर तक विस्तार करती है, जिससे ऐसा प्रभाव बनता है कि आकार स्लाइड के ऊपर उठाया गया हो। रंग, दिशा, दूरी, और ब्लर त्रिज्या को अपने टेम्पलेट की प्रकाश और शैली के अनुसार समायोजित करें।

यह JavaScript कोड दिखाता है कि कैसे [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) को एक आयत पर लागू किया जाए:

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

![छाया प्रभाव](shadow_effect.png)

### **आंतरिक छाया लागू करें**

टेम्पलेट की दृश्य शैली को पुन: उत्पन्न करते समय, एक आंतरिक छाया का उपयोग करके कार्ड या पैनल को अवतल दिखाएँ। बाहरी छाया आकार के बाहर तक विस्तार करती है और उसे उठे हुए दिखाती है, जबकि आंतरिक छाया उसके किनारों के भीतर छाया डालती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) द्वारा लौटाई गई छाया को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान नरम किनारे उत्पन्न करते हैं।

यह JavaScript उदाहरण हल्के नीले रंग का कार्ड बनाता है जिसमें गहरा ग्रे आंतरिक छाया है और इसे PPTX फाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री है, उसकी दूरी 7 पॉइंट है, और ब्लर त्रिज्या 6 पॉइंट है:

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

![हल्का नीला आयताकार आंतरिक छाया के साथ](inner_shadow_effect.png)

आंतरिक छाया को हटाने के लिए, shape की effect format पर [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) को कॉल करें।

### **प्रीसेट छाया लागू करें, बदलें और हटाएँ**

[enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) को कॉल करें और [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) का उपयोग करके एक [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/) चुनें। शैली बदलने के लिए, उसी आकार पर प्रीसेट बदलें। छाया को हटाने के लिए, fill और outline को संरक्षित रखते हुए [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) को कॉल करें।

यह उदाहरण एक स्लाइड पर चार चरणों को एक साथ दिखाता है। दोनों छायाएँ 10 पॉइंट से ऑफ़सेट हैं। 225° दिशा पहली छाया को आयत के ऊपर बाएँ रखती है, और 45° दिशा दूसरी को नीचे दाएँ रखती है।

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
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **परावर्तन प्रभाव लागू करें**

Aspose.Slides for Node.js via Java में परावर्तन प्रभाव लागू करने के लिए, आप आकारों में दर्पण जैसी परावर्तन जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर को समायोजित कर सकते हैं। यह प्रभाव आपके प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, आकारों को अधिक परिष्कृत और आकर्षक बनाता है। यह सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर तेज़ी से एकसमान डिज़ाइन लागू किया जा सके।

यह JavaScript कोड दिखाता है कि कैसे [परावर्तन प्रभाव](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) को किसी आकार पर लागू किया जाए:

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

![परावर्तन प्रभाव](reflection_effect.png)

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for Node.js via Java में किसी आकार पर ग्लो प्रभाव लागू करने के लिए, आप आकारों के चारों ओर एक मुलायम, प्रकाशमान आभा जोड़ सकते हैं, रंग और आकार जैसी प्रॉपर्टीज़ को समायोजित कर सकते हैं। यह प्रभाव आकारों को प्रमुख बनाता है और आपके प्रस्तुति में एक आकर्षक दृश्य तत्व जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे आपके स्लाइड्स की कुल लुक में सुधार होता है।

यह JavaScript कोड दिखाता है कि कैसे [ग्लो प्रभाव](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) को किसी आकार पर लागू किया जाए:

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

![ग्लो प्रभाव](glow_effect.png)

## **नरम किनारों का प्रभाव लागू करें**

Aspose.Slides for Node.js via Java में नरम किनारों का प्रभाव लागू करने के लिए, आप आकार के किनारों के आसपास एक सुगम, धुंधला संक्रमण बना सकते हैं। यह प्रभाव एक अधिक सूक्ष्म और परिष्कृत दिखावट जोड़ता है, जो उन डिजाइन के लिए उपयुक्त है जिन्हें कोमल, नरम उपस्थिति चाहिए। आप विभिन्न आकारों में वांछित प्रभाव प्राप्त करने के लिए त्रिज्या जैसे पैरामीटर को आसानी से समायोजित कर सकते हैं।

यह JavaScript कोड दिखाता है कि कैसे [नरम किनारों का प्रभाव](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) को किसी आकार पर लागू किया जाए:

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

![नरम किनारे प्रभाव](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

shape blur का उपयोग करके आप आकार की fill और outline दोनों को नरम बना सकते हैं जबकि आकार को संपादन योग्य रखते हैं। shape की effect format पर [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करें। त्रिज्या पॉइंट में मापी जाती है (1/72 इंच): नॉन‑नेगेटिव मान उपयोग करें, बड़ी मान अधिक तेज़ ब्लर उत्पन्न करेंगे। शून्य त्रिज्या रखे जाने पर रूप बदल नहींता।

[getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) सेटिंग प्रभाव की दृश्य सीमाओं को नियंत्रित करती है। `false` होने पर, ब्लर मूल पेंट की सीमाओं तक ही सीमित रहता है, जिसमें outline भी शामिल है। `true` होने पर, ब्लर उन सीमाओं से बाहर भी जा सकता है। कोई भी सेटिंग shape की स्थिति या आयाम को नहीं बदलती।

नीचे का तुलना समान fill, outline और shape आयामों का उपयोग करते हुए किया गया है। शीर्ष पंक्ति `grow = false` के साथ; निचली पंक्ति `grow = true` के साथ।

![5 और 15 पॉइंट ब्लर रेडियस के साथ मूल आयत, ग्रो अक्षम और सक्षम अवस्था में](shape_blur_comparison.png)

यह JavaScript उदाहरण नारंगी आयत को डार्क ब्लू outline के साथ बनाता है, 5‑पॉइंट ब्लर लागू करता है, फिर फिर से [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करके 15‑पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर किए गए स्थितियों को सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) को कॉल करके बिना ब्लर के shape को सहेजता है।

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

Shape blur fill और outline को साथ‑साथ प्रभावित करता है। नरम किनारों का प्रभाव shape के किनारों को फेड करता है, जबकि शैडो ब्लर केवल शैडो को नरम करता है। इमेज ट्रांसफ़ॉर्मेशन इफ़ेक्ट्स इमेज कंटेंट पर काम करते हैं; यह उदाहरण shape को इमेज में बदलें बिना सीधे shape की effect format पर ब्लर लागू करता है।

## **FAQ**

**क्या मैं एक ही आकार पर कई इफ़ेक्ट्स लागू कर सकता हूँ?**

हां, आप विभिन्न इफ़ेक्ट्स जैसे शैडो, परावर्तन और ग्लो को एक ही आकार पर संयोजित करके अधिक गतिशील रूप दे सकते हैं।

**मैं किन आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

आप विभिन्न आकारों पर इफ़ेक्ट्स लगा सकते हैं, जिनमें ऑटोक shape, चार्ट, तालिकाएँ, चित्र, SmartArt वस्तुएँ, OLE वस्तुएँ और अन्य शामिल हैं।

**क्या मैं समूहित आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

हां, आप समूहित आकारों पर इफ़ेक्ट्स लागू कर सकते हैं। प्रभाव पूरी समूह पर लागू होगा।