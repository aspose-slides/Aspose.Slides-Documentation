---
title: जावास्क्रिप्ट में PowerPoint शैप्स को फ़ॉर्मेट करें
linktitle: शैप फ़ॉर्मेटिंग
type: docs
weight: 20
url: /hi/nodejs-java/shape-formatting/
keywords:
- शैप फ़ॉर्मेट
- रेखा फ़ॉर्मेट
- स्केच प्रभाव
- स्केच शैप रेखा
- जॉइन शैली फ़ॉर्मेट
- ग्रेडिएंट फिल
- पैटर्न फिल
- पिक्चर फिल
- टेक्सचर फिल
- सॉलिड कलर फिल
- शैप ट्रांसपेरेंसी
- काली-और-सफ़ेद शैप रेंडरिंग
- ग्रेस्केल शैप रेंडरिंग
- शैप घुमाएँ
- 3डी बिवेल प्रभाव
- 3डी घूर्णन प्रभाव
- फ़ॉर्मेट रीसेट करें
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके जावास्क्रिप्ट में PowerPoint शैप्स को फ़ॉर्मेट करें—PPT, PPTX, और ODP फ़ाइलों के लिए फ़िल, लाइन, और इफ़ेक्ट शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में शैप्स जोड़ सकते हैं। चूँकि शैप्स रेखाओं से बने होते हैं, आप उनकी रूपरेखा को संशोधित या प्रभाव लागू करके उन्हें फ़ॉर्मेट कर सकते हैं। अतिरिक्त रूप से, आप शैप्स को उनके आंतरिक भाग को भरने वाले सेटिंग्स को निर्दिष्ट करके भी फ़ॉर्मेट कर सकते हैं।

![फ़ॉर्मेट-शेप-पावरपॉइंट](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java क्लास और मेथड्स प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके शैप्स को फ़ॉर्मेट करने की अनुमति देते हैं।

## **रेखा स्वरूप**

Aspose.Slides का उपयोग करके, आप किसी शैप के लिए कस्टम लाइन स्टाइल निर्दिष्ट कर सकते हैं। नीचे दिए गए चरण इस प्रक्रिया को रेखांकित करते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. उसके सूचकांक द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शैप की [लाइन शैली](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) सेट करें।
5. लाइन की चौड़ाई सेट करें।
6. लाइन की [डैश शैली](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) सेट करें।
7. शैप के लिए लाइन रंग सेट करें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित कोड दिखाता है कि कैसे एक आयत `AutoShape` को फ़ॉर्मेट किया जाए:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // आयत शैप से फ़िल हटाएँ।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // आयत की रेखाओं पर फ़ॉर्मेटिंग लागू करें।
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // आयत की रेखा के लिए रंग सेट करें।
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![प्रस्तुति में स्वरूपित रेखाएँ](formatted-lines.png)

## **शेप रेखाओं पर स्केच प्रभाव लागू करें**

एक स्केच प्रभाव शैप की रेखा को हाथ से खींची हुई दिखाता है। लाइन सेटिंग्स तक पहुँचने के लिये [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) का उपयोग करें, स्केच सेटिंग्स तक पहुँचने के लिये [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) का उपयोग करें, और [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) से आप [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) एन्यूमरेशन में से कोई मान चुन सकते हैं।

निम्नलिखित JavaScript कोड दिखाता है कि कैसे एक [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) प्रभाव लागू किया जाए, स्पष्ट रूप से असाइन किए गए मान को पढ़ा जाए, और [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) के साथ प्रभाव को हटाया जाए:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // शेप की लाइन फ़ॉर्मेट और उसकी स्केच फ़ॉर्मेट तक पहुँचें।
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // स्केच प्रभाव लागू करें।
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // शेप को सीधे असाइन किए गए स्केच प्रभाव को पढ़ें।
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // स्केच प्रभाव हटाएँ।
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

जो मान [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) द्वारा लौटाया जाता है, वह शैप पर सीधे असाइन की गई सेटिंग को दर्शाता है। यदि लाइन फ़ॉर्मेट थीम, मास्टर स्लाइड, या लेआउट स्लाइड से विरासित हो सकता है, तो [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) का उपयोग करें, लौटाए गए ऑब्जेक्ट पर `getSketchFormat` कॉल करें, और फिर उसके `getSketchType` मेथड को कॉल करें। प्रभावी मान उन फ़ॉर्मेटिंग को दर्शाता है जो विरासत समाधान के बाद वास्तव में लागू होती है:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **जॉइन शैलियों को फ़ॉर्मेट करें**

तीन जॉइन प्रकार विकल्प यहाँ हैं:

* गोल
* माइटर
* बिवेल

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे शैप के कोने पर), यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोणों वाले शैप को ड्रॉ कर रहे हैं, तो आप **Miter** विकल्प को प्राथमिकता दे सकते हैं।

![प्रस्तुति में जॉइन शैली](join-style-powerpoint.png)

निम्नलिखित JavaScript कोड दर्शाता है कि ऊपर की छवि में दिखाए गए तीन आयतों को Miter, Bevel, और Round जॉइन प्रकार सेटिंग्स का उपयोग करके कैसे बनाया गया।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार के तीन ऑटो शैप जोड़ें।
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयत शैप के लिए फ़िल रंग सेट करें।
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // रेखा की चौड़ाई सेट करें।
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // प्रत्येक आयत की रेखा के लिए रंग सेट करें।
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // जॉइन शैली सेट करें।
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // प्रत्येक आयत में टेक्स्ट जोड़ें।
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ग्रेडिएंट फिल**

PowerPoint में, ग्रेडिएंट फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको शैप पर लगातार रंगों का मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंग इस प्रकार लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में मिल जाता है।

यहाँ Aspose.Slides का उपयोग करके शैप पर ग्रेडिएंट फिल लागू करने का तरीका दिया गया है:

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. उसके सूचकांक द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शैप का [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) `Gradient` पर सेट करें।
5. ग्रेडिएंट स्टॉप कलेक्शन की `add` मेथड्स का उपयोग करके, जिनका उल्लेख [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/) क्लास में है, दो वांछित रंगों को निर्धारित स्थितियों के साथ जोड़ें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Ellipse प्रकार का एक ऑटो शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // दीपवृत्त पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // ग्रेडिएंट की दिशा सेट करें।
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // दो ग्रेडिएंट स्टॉप जोड़ें।
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ग्रेडिएंट फिल के साथ दीर्घवृत्त](gradient-fill.png)

यदि किसी ग्रेडिएंट का निर्यातित छवि में दिखना PowerPoint से अलग हो, तो देखें [Choose a Gradient Rendering Style](/slides/hi/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)। आप प्रस्तुति में संग्रहीत ग्रेडिएंट फिल को बदले बिना एक रेंडरिंग शैली चुन सकते हैं।

## **पैटर्न फिल**

PowerPoint में, पैटर्न फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको शैप पर दो‑रंगी डिज़ाइन—जैसे बिंदु, धारीदार, क्रॉसहैच, या चेक—लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियाँ प्रदान करता है जिन्हें आप शैप्स पर लागू करके अपनी प्रस्तुतियों की दृश्य अपील बढ़ा सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी, आप उसे उपयोग करने वाले सटीक रंग निर्दिष्ट कर सकते हैं।

यहाँ Aspose.Slides का उपयोग करके शैप पर पैटर्न फिल लागू करने का तरीका है:

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. उसके सूचकांक द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शैप का [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) `Pattern` पर सेट करें।
5. पूर्वनिर्धारित विकल्पों में से एक पैटर्न शैली चुनें।
6. शैप के [पृष्ठभूमि रंग](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) सेट करें।
7. शैप के [अग्रभूमि रंग](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) सेट करें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // फ़िल टाइप को Pattern पर सेट करें।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // पैटर्न शैली सेट करें।
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // पैटर्न की पृष्ठभूमि और अग्रभूमि रंग सेट करें।
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैटर्न फिल के साथ आयत](pattern-fill.png)

## **पिक्चर फिल**

PowerPoint में, पिक्चर फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको शैप के भीतर एक छवि डालने की अनुमति देता है—वास्तव में छवि को शैप की पृष्ठभूमि के रूप में उपयोग करता है।

यहाँ Aspose.Slides का उपयोग करके शैप पर पिक्चर फिल लागू करने का तरीका दिया गया है:

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. उसके सूचकांक द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शैप का [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) `Picture` पर सेट करें।
5. पिक्चर फिल मोड को `Tile` (या कोई अन्य वांछित मोड) पर सेट करें।
6. इच्छित छवि से एक [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं।
7. छवि को `ISlidesPicture.setImage` मेथड में पास करें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास एक "lotus.png" फ़ाइल है जिसका चित्र नीचे दिया गया है:

![लोटस चित्र](lotus.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // फ़िल टाइप को Picture पर सेट करें।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // पिक्चर फ़िल मोड सेट करें।
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // एक छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // चित्र सेट करें।
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पिक्चर फिल के साथ शैप](picture-fill.png)

### **टाइल तस्वीर को बनावट के रूप में**

यदि आप एक टाइल वाली छवि को बनावट के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) क्लास की निम्नलिखित मेथड्स का प्रयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): चित्र फिल मोड सेट करता है — `Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): शैप के भीतर टाइलों की संरेखण निर्दिष्ट करता है।
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): टाइल को क्षैतिज, ऊर्ध्वाधर या दोनों दिशा में फ्लिप करने को नियंत्रित करता है।
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): टाइल का क्षैतिज ऑफ़सेट (पॉइंट में) शैप की मूल से सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): टाइल का ऊर्ध्वाधर ऑफ़सेट (पॉइंट में) शैप की मूल से सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): टाइल के क्षैतिज स्केल को प्रतिशत में निर्धारित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): टाइल के ऊर्ध्वाधर स्केल को प्रतिशत में निर्धारित करता है।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let firstSlide = presentation.getSlides().get_Item(0);

    // एक आयत ऑटो शैप जोड़ें।
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // शैप का फ़िल टाइप Picture पर सेट करें।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // छवि को शैप को असाइन करें।
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // पिक्चर फ़िल मोड और टाइलिंग गुण कॉन्फ़िगर करें।
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टाइल विकल्प](tile-options.png)

## **सॉलिड कलर फिल**

PowerPoint में, सॉलिड कलर फिल एक फ़ॉर्मेटिंग विकल्प है जो शैप को एकसमान रंग से भरता है। यह सादा पृष्ठभूमि रंग कोई ग्रेडिएंट, बनावट, या पैटर्न के बिना लागू किया जाता है।

एक शैप पर सॉलिड कलर फिल लागू करने के लिये Aspose.Slides का उपयोग करके, निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. उसके सूचकांक द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शैप का [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) `Solid` पर सेट करें।
5. शैप को अपना वांछित फ़िल रंग असाइन करें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // फ़िल टाइप को Solid पर सेट करें।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // फ़िल रंग सेट करें।
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![सॉलिड कलर फिल के साथ शैप](solid-color-fill.png)

## **ट्रांसपेरेंसी सेट करें**

PowerPoint में, जब आप सॉलिड कलर, ग्रेडिएंट, पिक्चर, या टेक्सचर फिल लागू करते हैं, तो आप ट्रांसपेरेंसी स्तर सेट करके फ़िल की अपारदर्शिता को नियंत्रित कर सकते हैं। अधिक ट्रांसपेरेंसी मान शैप को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे की वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल में उपयोग किए गए रंग की अल्फा वैल्यू को समायोजित करके ट्रांसपेरेंसी स्तर सेट करने देता है। इसे करने का तरीका इस प्रकार है:

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. उसके सूचकांक द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शैप का [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) `Solid` पर सेट करें।
5. फ़िल करने के लिये `Color` का उपयोग करके ट्रांसपेरेंसी के साथ एक रंग परिभाषित करें (अल्फा घटक ट्रांसपेरेंसी को नियंत्रित करता है)।
6. प्रस्तुति को सहेजें।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // एक ठोस आयत ऑटो शैप जोड़ें।
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // ठोस शैप के ऊपर एक पारदर्शी आयत ऑटो शैप जोड़ें।
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ट्रांसपेरेंट शैप](shape-transparency.png)

## **शैप घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में शैप्स को घुमाने की सुविधा देता है। यह विशिष्ट संरेखण या डिज़ाइन आवश्यकताओं वाले विज़ुअल तत्वों को स्थित करने में उपयोगी हो सकता है।

स्लाइड पर शैप को घुमाने के लिये, नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. उसके सूचकांक द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शैप की घूर्णन प्रॉपर्टी को वांछित कोण पर सेट करें।
5. प्रस्तुति को सहेजें।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // शैप को 5 डिग्री घुमाएँ।
    shape.setRotation(5);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![शैप घूर्णन](shape-rotation.png)

## **3D बिवेल प्रभाव जोड़ें**

Aspose.Slides आपको शैप्स पर 3D बिवेल प्रभाव लागू करने देता है, जिसके लिये आप उनके [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

शैप पर 3D बिवेल प्रभाव जोड़ने के लिये, नीचे दिए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. उसके सूचकांक द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. शैप के [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) को कॉन्फ़िगर करके बिवेल सेटिंग्स निर्धारित करें।
5. प्रस्तुति को सहेजें।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation क्लास का एक इंस्टेंस बनाएं।
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // स्लाइड में एक शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // शैप की ThreeDFormat प्रॉपर्टीज़ सेट करें।
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![3D बिवेल प्रभाव](3D-bevel-effect.png)

## **3D घूर्णन प्रभाव जोड़ें**

Aspose.Slides आपको शैप्स पर 3D घूर्णन प्रभाव लागू करने देता है, जिसके लिये आप उनके [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

शैप पर 3D घूर्णन लागू करने के लिये:

1. एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. उसके सूचकांक द्वारा स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) जोड़ें।
4. 3D घूर्णन को परिभाषित करने के लिये [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) और [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) का उपयोग करें।
5. प्रस्तुति को सहेजें।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation क्लास का एक इंस्टेंस बनाएं।
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![3D घूर्णन प्रभाव](3D-rotation-effect.png)

## **शैप्स के लिए काली-और-सफ़ेद रेंडरिंग नियंत्रित करें**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) मेथड यह निर्धारित करता है कि जब प्रस्तुति काली-और-सफ़ेद मोड में देखी या संसाधित की जाती है, तो व्यक्तिगत शैप कैसे रेंडर किया जाता है। यह स्वयं काली-और-सफ़ेद डिस्प्ले को सक्षम नहीं करता, और सामान्य रंग मोड में शैप की फ़िल, लाइन, या अन्य फ़ॉर्मेटिंग को नहीं बदलता।

इच्छित व्यवहार चुनने के लिये [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) एन्यूमरेशन से कोई मान उपयोग करें। उदाहरण के लिये, `Automatic` रेंडरिंग एप्लिकेशन को परिवर्तन चुनने देता है, `Gray` और `LightGray` ग्रे रंग का उपयोग करते हैं, `BlackWhite` केवल काला और सफेद उपयोग करता है, `Black` और `White` एकल रंग को बाध्य करते हैं, `Color` सामान्य रंग को बरकरार रखता है, और `Hidden` काली-और-सफ़ेद मोड में शैप को छोड़ देता है। `NotDefined` का अर्थ है कि कोई शैप-स्तर मोड असाइन नहीं किया गया है।

निम्नलिखित JavaScript कोड एक रंगीन शैप बनाता है और काली-और-सफ़ेद डिस्प्ले मोड में इसे ग्रे दिखाता है:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // रंग मोड में नारंगी फ़िल रखें, लेकिन काली-और-सफ़ेद मोड में शैप को ग्रे रंग में रेंडर करें।
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

साधारण रंग मोड में, आयत अपना नारंगी फ़िल बरकरार रखती है। काली-और-सफ़ेद डिस्प्ले कार्यप्रवाह में, यह ग्रे रंग का उपयोग करती है क्योंकि उसका मोड `Gray` पर सेट है। यह आपको पूर्ण‑रंग स्लाइड को संरक्षित रखने की अनुमति देता है, जबकि प्रिंटिंग, प्रीव्यू या अन्य कार्यप्रवाहों के लिये अलग दिखावट को परिभाषित करता है जो प्रस्तुति की काली-और-सफ़ेद डिस्प्ले सेटिंग्स का सम्मान करते हैं।

## **फ़ॉर्मेट रीसेट करें**

निम्नलिखित JavaScript कोड दर्शाता है कि कैसे स्लाइड की फ़ॉर्मेटिंग रीसेट की जाए और [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) पर प्लेसहोल्डर्स वाले सभी शैप्स की स्थिति, आकार, और फ़ॉर्मेटिंग को उनकी डिफ़ॉल्ट सेटिंग्स पर लौटाया जाए:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // लेआउट में प्लेसहोल्डर वाला प्रत्येक शैप स्लाइड पर रीसेट करें।
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**क्या शैप फ़ॉर्मेटिंग अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करती है?**

केवल न्यूनतम रूप से। एम्बेडेड छवियां और मीडिया फ़ाइल स्थान का अधिकांश भाग घेरती हैं, जबकि शैप पैरामीटर जैसे रंग, प्रभाव, और ग्रेडिएंट मेटाडेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे पहचान सकता हूं कि स्लाइड पर कौन से शैप समान फ़ॉर्मेटिंग साझा करते हैं ताकि मैं उन्हें समूहित कर सकूं?**

प्रत्येक शैप की मुख्य फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन, और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके स्टाइल को समान मानें और तर्कसंगत रूप से उन शैप्स को समूहित करें, जिससे बाद में स्टाइल प्रबंधन आसान हो जाता है।

**क्या मैं कस्टम शैप शैलियों को एक अलग फ़ाइल में सहेजकर अन्य प्रस्तुतियों में पुन: उपयोग कर सकता हूं?**

हां। वांछित शैलियों के साथ नमूना शैप्स को टेम्प्लेट स्लाइड डेक या .POTX टेम्प्लेट फ़ाइल में सहेजें। नई प्रस्तुति बनाते समय, टेम्प्लेट खोलें, आवश्यक शैलियों वाले शैप को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो, उनकी फ़ॉर्मेटिंग को पुनः लागू करें।