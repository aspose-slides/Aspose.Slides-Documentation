---
title: प्रेज़ेंटेशन में जावास्क्रिप्ट का उपयोग करके आकार इफ़ेक्ट लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/nodejs-java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- ग्लो प्रभाव
- नरम किनारे प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js का उपयोग करके उन्नत आकार इफ़ेक्ट्स के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड्स बनाएं।"
---
## **परिचय**

PowerPoint में इफ़ेक्ट्स का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, लेकिन ये [भराव](/slides/hi/nodejs-java/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint इफ़ेक्ट्स का उपयोग करके आप आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैला सकते हैं, आदि।

![आकार प्रभाव](shape-effect.png)

PowerPoint आकारों पर लागू किए जा सकने वाले छह इफ़ेक्ट्स प्रदान करता है। आप एक आकार पर एक या अधिक इफ़ेक्ट्स लागू कर सकते हैं।

कुछ इफ़ेक्ट संयोजन अन्य की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक इफ़ेक्ट्स के ऐसे संयोजन हैं जो अच्छे दिखने के लिए जाने जाते हैं। इस प्रकार, एक प्रीसेट चुनकर आपको विभिन्न इफ़ेक्ट्स को परीक्षण या संयोजन करने और एक अच्छा संयोजन खोजने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) क्लास के अंतर्गत प्रॉपर्टीज़ और मेथड्स प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान इफ़ेक्ट्स लागू करने की अनुमति देते हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Node.js via Java आकारों के लिए बाहरी और आंतरिक छायाओं का समर्थन करता है। आप इनकी रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिजाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

बैकग्राउंड के विरुद्ध कार्ड या पैनल को अलग दिखाने के लिए बाहरी छाया का उपयोग करें। छाया आकार की किनारों से बाहर तक विस्तारित होती है, जिससे ऐसा प्रभाव पैदा होता है कि आकार स्लाइड से ऊपर उठाया गया है। अपनी टेम्प्लेट की प्रकाश और शैली से मेल खाने के लिए इसका रंग, दिशा, दूरी और ब्लर त्रिज्या समायोजित करें।

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

टेम्प्लेट की दृश्य शैली को पुनः बनाने के दौरान, कार्ड या पैनल को आधी गहरी दिखाने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर तक फैली होती है और उसे उठाया हुआ दिखाती है, जबकि आंतरिक छाया किनारों के अंदर के हिस्से को छाया देती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) द्वारा लौटाए गए छाया को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान अधिक मुलायम किनारे उत्पन्न करती हैं।

यह JavaScript उदाहरण हल्के नीले कार्ड को गहरे ग्रे आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री है, दूरी 7 पॉइंट्स, और ब्लर त्रिज्या 6 पॉइंट्स है:

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

![हल्का नीला आयत आंतरिक छाया के साथ](inner_shadow_effect.png)

आंतरिक छाया हटाने के लिए, आकार के इफ़ेक्ट फ़ॉर्मेट पर [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) को कॉल करें।

## **प्रतिबिंब प्रभाव लागू करें**

Aspose.Slides for Node.js via Java में प्रतिबिंब प्रभाव लागू करने के लिए, आप आकारों पर दर्पण जैसी प्रतिबिंब जोड़ सकते हैं, पैरामीटर जैसे दूरी, पारदर्शिता और आकार को समायोजित कर सकते हैं। यह प्रभाव आपके प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, आकारों को अधिक पॉलिश और परिष्कृत दिखाता है। सरल कोड के साथ इसे आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर निरंतर डिज़ाइन के लिए तेज़ी से उपयोग संभव होता है।

यह JavaScript कोड दिखाता है कि कैसे [प्रतिबिंब प्रभाव](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) को एक आकार पर लागू किया जाए:

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

![प्रतिबिंब प्रभाव](reflection_effect.png)

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for Node.js via Java में आकार पर ग्लो प्रभाव लागू करने के लिए, आप आकारों के चारों ओर एक सौम्य, प्रकाशमान आभा जोड़ सकते हैं, रंग और आकार जैसी प्रॉपर्टीज़ को समायोजित कर सकते हैं। यह प्रभाव आकारों को प्रमुख बनाता है और आपके प्रेज़ेंटेशन में आकर्षक, ध्यान आकर्षित करने वाला दृश्य तत्व जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे आपकी स्लाइड्स की समग्र रूपरेखा सुधरती है।

यह JavaScript कोड दिखाता है कि कैसे [ग्लो प्रभाव](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) को एक आकार पर लागू किया जाए:

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

Aspose.Slides for Node.js via Java में नरम किनारों का प्रभाव लागू करने के लिए, आप आकार के किनारों के चारों ओर एक सुचारु, धुंधला संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत दिखावट जोड़ता है, जो उन डिज़ाइनों के लिए उपयुक्त है जिनमें हल्की, मुलायम उपस्थिति चाहिए। आप आसानी से त्रिज्या जैसी पैरामीटर को समायोजित कर विभिन्न आकारों में वांछित प्रभाव प्राप्त कर सकते हैं।

यह JavaScript कोड दिखाता है कि कैसे [नरम किनारों का प्रभाव](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) को एक आकार पर लागू किया जाए:

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

![नरम किनारों का प्रभाव](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

आकार की भराव और रूपरेखा को नरम करने के लिए shape blur का उपयोग करें, जबकि आकार को संपादन योग्य रखें। आकार के इफ़ेक्ट फ़ॉर्मेट पर [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करें। त्रिज्या पॉइंट्स में मापी जाती है (1/72 इंच): एक अपरिवर्तित मान का उपयोग करें, बड़े मान अधिक मजबूत ब्लर उत्पन्न करते हैं। शून्य त्रिज्या का अर्थ है कोई परिवर्तन नहीं।

[getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) सेटिंग प्रभाव की दृश्य सीमा को नियंत्रित करती है। `false` होने पर, ब्लर मूल पेंट की सीमाओं तक सीमित रहता है, जिसमें रूपरेखा भी शामिल है। `true` होने पर, ब्लर उन सीमाओं से बाहर तक फैल सकता है। दोनों सेटिंग्स आकार की स्थिति या आयामों को नहीं बदलतीं।

नीचे दिया गया तुलना समान भराव, रूपरेखा और आकार आयामों के साथ किया गया है। ऊपर की पंक्ति में `grow = false`; नीचे की पंक्ति में `grow = true`।

![मूल आयत की तुलना 5 और 15 पॉइंट ब्लर त्रिज्या के साथ, ग्रो अक्षम और सक्षम](shape_blur_comparison.png)

यह JavaScript उदाहरण एक नारंगी आयत को डार्क ब्लू रूपरेखा के साथ बनाता है, 5 पॉइंट ब्लर लागू करता है, और फिर फिर से [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) को कॉल करके 15 पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर स्थितियों को सहेजता है, फिर [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) को कॉल करके ब्लर के बिना आकार को सहेजता है।

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

Shape blur भराव और रूपरेखा दोनों को साथ में प्रभावित करता है। नरम किनारों का प्रभाव आकार के किनारों को फेड करता है, जबकि शैडो ब्लर केवल छाया को नरम करता है। इमेज ट्रांसफ़ॉर्मेशन इफ़ेक्ट्स इमेज सामग्री पर कार्य करते हैं; यह उदाहरण आकार को इमेज में बदलने के बिना सीधे आकार के इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर विभिन्न इफ़ेक्ट्स, जैसे छाया, प्रतिबिंब और ग्लो, को मिलाकर अधिक गतिशील दिखावट बना सकते हैं।

**मैं किन आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

आप विभिन्न आकारों पर इफ़ेक्ट्स लागू कर सकते हैं, जिनमें ऑटोशेप, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अधिक शामिल हैं।

**क्या मैं समूहित आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर इफ़ेक्ट्स लागू कर सकते हैं। इफ़ेक्ट पूरे समूह पर लागू होगा।