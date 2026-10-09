---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में आकृति प्रभाव लागू करें
linktitle: आकृति प्रभाव
type: docs
weight: 30
url: /hi/nodejs-java/shape-effect/
keywords:
- आकृति प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- ग्लो प्रभाव
- मुलायम किनारे प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js का उपयोग करके उन्नत आकृति प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को रूपांतरित करें—सेकण्डों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग करके आप किसी आकृति को अधिक प्रमुख बना सकते हैं, लेकिन वे [fills](/slides/hi/nodejs-java/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप आकृति पर विश्वसनीय प्रतिबिंब, आकृति की चमक आदि बना सकते हैं।

![आकृति प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकृतियों पर लागू किया जा सकता है। आप एक या अधिक प्रभावों को आकृति पर लागू कर सकते हैं।

कुछ प्रभाव संयोजन अन्य की तुलना में बेहतर दिखते हैं। इसी कारण से, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प दो या अधिक प्रभावों के उन संयोजनों को दर्शाते हैं जो सामान्यतः अच्छे दिखते हैं। इस तरह, किसी प्रीसेट का चयन करके आपको विभिन्न प्रभावों को परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) क्लास के तहत गुण और विधियां प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकृतियों पर समान प्रभाव लागू करने की अनुमति देती हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Node.js via Java आकृतियों के लिए बाहरी और आंतरिक छायाओं का समर्थन करता है। आप उनके रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिजाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

बाहरी छाया का उपयोग करके आप स्लाइड पृष्ठभूमि के मुकाबले कार्ड या पैनल को अधिक उभरा दिखा सकते हैं। छाया आकृति के किनारों से बाहर तक विस्तृत होती है, जिससे यह प्रतीत होता है कि आकृति स्लाइड से ऊपर उठी हुई है। अपने टेम्पलेट की प्रकाश व्यवस्था और शैली से मेल खाने के लिये इसका रंग, दिशा, दूरी और ब्लर त्रिज्या समायोजित करें।

यह JavaScript कोड दिखाता है कि कैसे आयत पर [outer shadow effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) लागू किया जाता है:

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

टेम्पलेट की दृश्य शैली को दोहराते समय, कार्ड या पैनल को एक अवसादित रूप देने के लिये आंतरिक छाया का उपयोग करें। बाहरी छाया आकृति के बाहर तक फैली होती है और इसे उठी हुई दिखाती है, जबकि आंतरिक छाया इसके किनारों के भीतर छाया डालती है।

[enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) को कॉल करें, फिर [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) द्वारा लौटाई गई छाया को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान मृदु किनारे उत्पन्न करती है।

यह JavaScript उदाहरण हल्के नीले कार्ड पर गहरे ग्रे आंतरिक छाया बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है। छाया की दिशा 225 डिग्री है, दूरी 7 पॉइंट है, और ब्लर त्रिज्या 6 पॉइंट है:

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

![आंतरिक छाया के साथ हल्का नीला आयत](inner_shadow_effect.png)

आंतरिक छाया हटाने के लिये, आकृति के effect format पर [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) को कॉल करें।

## **परावर्तन प्रभाव लागू करें**

Aspose.Slides for Node.js via Java में परावर्तन प्रभाव लागू करने के लिये, आप आकृतियों पर दर्पण जैसी परावर्तन जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर को समायोजित कर सकते हैं। यह प्रभाव आपकी प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, जिससे आकृतियों को अधिक पॉलिश्ड और परिष्कृत लुक मिलता है। यह सरल कोड के साथ लागू करना आसान है, जिससे कई तत्वों पर तेज़ी से समान डिज़ाइन लागू किया जा सकता है।

यह JavaScript कोड दिखाता है कि कैसे आकृति पर [reflection effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) लागू किया जाता है:

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

Aspose.Slides for Node.js via Java में किसी आकृति पर ग्लो प्रभाव लागू करने के लिये, आप आकृतियों के चारों ओर नरम, चमकदार आभा जोड़ सकते हैं, रंग और आकार जैसी गुणों को समायोजित कर सकते हैं। यह प्रभाव आकृतियों को प्रमुख बनाता है और आपकी प्रस्तुति में आकर्षक दृश्य तत्व जोड़ता है। यह न्यूनतम कोड के साथ लागू करना आसान है, जिससे आपके स्लाइड्स की समग्र रूपरचना बेहतर होती है।

यह JavaScript कोड दिखाता है कि कैसे आकृति पर [glow effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) लागू किया जाता है:

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

## **सॉफ्ट एजेज़ प्रभाव लागू करें**

Aspose.Slides for Node.js via Java में सॉफ्ट एजेज़ प्रभाव लागू करने के लिये, आप आकृति के किनारों केAround एक स्मूथ, धुंधली संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत लुक देता है, जो उन डिज़ाइनों के लिये उपयुक्त है जिन्हें नरम, कोमल उपस्थिति चाहिए। आप आसानी से त्रिज्या जैसे पैरामीटर को समायोजित करके अपनी प्रस्तुति की विभिन्न आकृतियों पर वांछित प्रभाव प्राप्त कर सकते हैं।

यह JavaScript कोड दिखाता है कि कैसे आकृति पर [soft edges effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) लागू किया जाता है:

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

![सॉफ्ट एजेज़ प्रभाव](soft_edges_effect.png)

## **FAQ**

**क्या मैं एक ही आकृति पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप छाया, परावर्तन और ग्लो जैसे विभिन्न प्रभावों को एक ही आकृति पर जोड़कर अधिक गतिशील रूप दे सकते हैं।

**मैं किन आकृतियों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकृतियों पर प्रभाव लागू कर सकते हैं, जिसमें ऑटॉशेप, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अधिक शामिल हैं।

**क्या मैं समूहबद्ध आकृतियों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहबद्ध आकृतियों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरे समूह पर लागू होगा।