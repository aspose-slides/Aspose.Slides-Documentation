---
title: JavaScript में PowerPoint आकार स्वरूपित करना
linktitle: आकार स्वरूपण
type: docs
weight: 20
url: /hi/nodejs-java/shape-formatting/
keywords:
- आकार स्वरूपित करें
- लाइन स्वरूपित करें
- स्केच प्रभाव
- स्केच आकार रेखा
- जॉइन शैली स्वरूपित करें
- ग्रेडिएंट फ़िल
- पैटर्न फ़िल
- पिक्चर फ़िल
- बनावट फ़िल
- ठोस रंग फ़िल
- आकार पारदर्शिता
- काली-सफ़ेद आकार रेंडरिंग
- ग्रेस्केल आकार रेंडरिंग
- आकार घुमाएँ
- 3d बिवेल प्रभाव
- 3d घुमाव प्रभाव
- स्वरूपण रीसेट
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके JavaScript में PowerPoint आकार स्वरूपित करें—PPT, PPTX, और ODP फ़ाइलों के लिए सटीकता और पूर्ण नियंत्रण के साथ फ़िल, रेखा, और प्रभाव शैलियाँ सेट करें।"
---
## **परिचय**

PowerPoint में आप स्लाइड्स में आकार (shapes) जोड़ सकते हैं। चूँकि आकार रेखाओं (lines) से बनते हैं, आप उनके रूपरेखा (outline) को संशोधित या प्रभाव (effects) लागू करके स्वरूपित कर सकते हैं। साथ ही, आप आकार के आंतरिक भाग को भरने (fill) के लिए सेटिंग्स निर्दिष्ट करके स्वरूपित कर सकते हैं।

![फ़ॉर्मेट शापे पॉवरपॉइंट](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java क्लास और मेथड्स प्रदान करता है जो PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकारों को स्वरूपित करने की अनुमति देते हैं।

## **लाइन स्वरूपित करना**

Aspose.Slides का उपयोग करके आप किसी आकार के लिए कस्टम लाइन शैली (custom line style) निर्दिष्ट कर सकते हैं। नीचे दी गई चरणों में प्रक्रिया दर्शाई गई है:

1. [Presentation] क्लास की एक इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape] जोड़ें।
1. आकार की [line style] सेट करें।
1. लाइन की चौड़ाई निर्धारित करें।
1. लाइन की [dash style] सेट करें।
1. आकार के लिए लाइन रंग निर्धारित करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया कोड एक आयताकार `AutoShape` को स्वरूपित करने का उदाहरण है:

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
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Rectangle आकार से फ़िल हटाएँ।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Rectangle की लाइनों पर स्वरूपण लागू करें।
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Rectangle की रेखा का रंग सेट करें।
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![प्रेज़ेंटेशन में स्वरूपित लाइन्स](formatted-lines.png)

## **आकार लाइनों पर स्केच प्रभाव लागू करना**

स्केच प्रभाव आकार की लाइनों को हाथ से खींचे जैसा दिखाता है। लाइन सेटिंग्स तक पहुँचने के लिए आप [Shape.getLineFormat] का उपयोग कर सकते हैं, स्केच सेटिंग्स तक पहुँचने के लिए [LineFormat.getSketchFormat] और स्केच प्रकार चुनने के लिए [SketchFormat.setSketchType] का उपयोग करके [LineSketchType] एन्‍युमरेशन में से मान चुन सकते हैं।

नीचे दिया गया JavaScript कोड दिखाता है कि कैसे [LineSketchType.Curved] प्रभाव लागू किया जाए, स्पष्ट रूप से असाइन किया गया मान पढ़ा जाए, और [LineSketchType.None] का उपयोग करके प्रभाव हटाया जाए:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // आकार के लाइन फॉर्मेट और उसके स्केच फॉर्मेट तक पहुँचें।
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // स्केच प्रभाव लागू करें।
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // आकार को सीधे असाइन किए गए स्केच प्रभाव को पढ़ें।
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // स्केच प्रभाव हटाएँ।
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[SketchFormat.getSketchType] द्वारा लौटाया गया मान वह सेटिंग दर्शाता है जो सीधे आकार पर असाइन की गई है। यदि लाइन स्वरूपण थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में मिला है, तो [LineFormat.getEffective] का उपयोग करें, लौटाए गए ऑब्जेक्ट पर `getSketchFormat` कॉल करें, और फिर उसका `getSketchType` मेथड कॉल करें। प्रभावी मान विरासत समाधान के बाद वास्तविक रूप से लागू स्वरूपण को दर्शाता है:

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

## **जॉइन शैलियों को स्वरूपित करना**

तीन जॉइन प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो लाइनों को कोण पर जोड़ता है (जैसे आकार के कोने पर), वह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीक्ष्ण कोण वाले आकार बना रहे हैं, तो आप **Miter** विकल्प को पसंद कर सकते हैं।

![प्रेज़ेंटेशन में जॉइन शैली](join-style-powerpoint.png)

नीचे दिया गया JavaScript कोड दिखाता है कि कैसे ऊपर चित्रित तीन आयतों को Miter, Bevel, और Round जॉइन प्रकार सेटिंग्स के साथ बनाया गया:

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

    // प्रत्येक आयत आकार के लिए फ़िल रंग सेट करें।
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

    // प्रत्येक आयत की रेखा का रंग सेट करें।
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

## **ग्रेडिएंट फ़िल**

PowerPoint में ग्रेडिएंट फ़िल एक स्वरूपण विकल्प है जो आकार पर लगातार रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंगों को इस प्रकार लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में मिल जाए।

Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट फ़िल लागू करने के चरण:

1. [Presentation] क्लास की एक इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape] जोड़ें।
1. आकार की [FillType] को `Gradient` सेट करें।
1. [GradientFormat] क्लास द्वारा प्रदर्शित ग्रेडिएंट स्टॉप संग्रह की `add` मेथड्स का उपयोग करके परिभाषित स्थितियों के साथ दो पसंदीदा रंग जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया JavaScript कोड दिखाता है कि कैसे अण्डाकार पर ग्रेडिएंट फ़िल प्रभाव लागू किया जाए:

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

    // एलिप्स पर ग्रेडिएंट स्वरूपण लागू करें।
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

![ग्रेडिएंट फ़िल वाला अण्डाकार](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में पैटर्न फ़िल एक स्वरूपण विकल्प है जो आपको दो‑रंगीन डिज़ाइन (जैसे बिंदु, धारियाँ, क्रॉसहैच, या चेक) आकार पर लागू करने देता है। आप पैटर्न के अग्रभूमि (foreground) और पृष्ठभूमि (background) रंगों को अनुकूलित कर सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियाँ प्रदान करता है जिन्हें आप अपने प्रस्तुति की दृश्यता बढ़ाने के लिए आकारों पर लागू कर सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप सटीक रंग निर्दिष्ट कर सकते हैं।

Aspose.Slides का उपयोग करके आकार पर पैटर्न फ़िल लागू करने के चरण:

1. [Presentation] क्लास की एक इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape] जोड़ें।
1. आकार की [FillType] को `Pattern` सेट करें।
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न के [Background Color] को सेट करें।
1. पैटर्न के [Foreground Color] को सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया JavaScript कोड दिखाता है कि कैसे एक आयत पर पैटर्न फ़िल लागू किया जाए:

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

    // फ़िल प्रकार को Pattern सेट करें।
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

![पैटर्न फ़िल वाला आयत](pattern-fill.png)

## **पिक्चर फ़िल**

PowerPoint में पिक्चर फ़िल एक स्वरूपण विकल्प है जो आपको आकार के भीतर एक छवि (image) सम्मिलित करने देता है—वह छवि आकार की पृष्ठभूमि बन जाती है।

Aspose.Slides का उपयोग करके आकार पर पिक्चर फ़िल लागू करने के चरण:

1. [Presentation] क्लास की एक इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape] जोड़ें।
1. आकार की [FillType] को `Picture` सेट करें।
1. पिक्चर फ़िल मोड को `Tile` (या कोई अन्य पसंदीदा मोड) सेट करें।
1. उपयोग करने वाली छवि से एक [PPImage] ऑब्जेक्ट बनाएँ।
1. छवि को `ISlidesPicture.setImage` मेथड में पास करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास "lotus.png" फ़ाइल है, जिसमें निम्नलिखित चित्र है:

![लोटस चित्र](lotus.png)

नीचे दिया गया JavaScript कोड दिखाता है कि कैसे आकार को चित्र से भरें:

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
    
    // फ़िल प्रकार को Picture सेट करें।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // पिक्चर फ़िल मोड सेट करें।
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // एक छवि लोड करें और इसे प्रस्तुति संसाधनों में जोड़ें।
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

![पिक्चर फ़िल वाला आकार](picture-fill.png)

### **टाइल पिक्चर को टेक्सचर के रूप में सेट करना**

यदि आप टाइल्ड पिक्चर को टेक्सचर के रूप में सेट करना और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप नीचे दिए गए [PictureFillFormat] क्लास की विधियों का उपयोग कर सकते हैं:

- [setPictureFillMode]: पिक्चर फ़िल मोड सेट करता है — `Tile` या `Stretch`।
- [setTileAlignment]: आकार के भीतर टाइल की संरेखण (alignment) निर्दिष्ट करता है।
- [setTileFlip]: टाइल को क्षैतिज, लंबवत या दोनों दिशा में फ़्लिप करने को नियंत्रित करता है।
- [setTileOffsetX]: आकार की मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट में) सेट करता है।
- [setTileOffsetY]: आकार की मूल बिंदु से टाइल का लंबवत ऑफ़सेट (पॉइंट में) सेट करता है।
- [setTileScaleX]: टाइल के क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [setTileScaleY]: टाइल के लंबवत स्केल को प्रतिशत में परिभाषित करता है।

नीचे दिया गया कोड नमूना दिखाता है कि कैसे टाइल्ड पिक्चर फ़िल के साथ एक आयताकार आकार जोड़ें और टाइल विकल्प कॉन्फ़िगर करें:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let firstSlide = presentation.getSlides().get_Item(0);

    // एक आयताकार ऑटो शैप जोड़ें।
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // आकार के फ़िल प्रकार को Picture सेट करें।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // चित्र को आकार को असाइन करें।
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // पिक्चर फ़िल मोड और टाइलिंग गुणों को कॉन्फ़िगर करें।
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

## **सॉलिड कलर फ़िल**

PowerPoint में सॉलिड कलर फ़िल एक स्वरूपण विकल्प है जो आकार को एकयु (समान) रंग से भरता है। यह साधारण पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, टेक्सचर या पैटर्न के लागू किया जाता है।

Aspose.Slides का उपयोग करके आकार पर सॉलिड कलर फ़िल लागू करने के चरण:

1. [Presentation] क्लास की एक इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape] जोड़ें।
1. आकार की [FillType] को `Solid` सेट करें।
1. अपनी पसंद का फ़िल रंग आकार को असाइन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया JavaScript कोड दर्शाता है कि कैसे PowerPoint स्लाइड में एक आयत पर सॉलिड कलर फ़िल लागू किया जाए:

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

    // फ़िल प्रकार को Solid सेट करें।
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

![सॉलिड कलर फ़िल वाला आकार](solid-color-fill.png)

## **ट्रांसपैरेंसी सेट करना**

PowerPoint में, जब आप आकार पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फिल की अपारदर्शिता (opacity) को नियंत्रित करने के लिए ट्रांसपैरेंसी स्तर सेट कर सकते हैं। उच्च ट्रांसपैरेंसी मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे स्थित वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल के लिए उपयोग किए गए रंग के अल्फा मान को समायोजित करके ट्रांसपैरेंसी स्तर सेट करने देता है। इसे करने के चरण:

1. [Presentation] क्लास की एक इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape] जोड़ें।
1. [FillType] को `Solid` सेट करें।
1. `Color` का उपयोग करके ट्रांसपैरेंसी (alpha घटक) के साथ एक रंग परिभाषित करें।
1. प्रस्तुति को सहेजें।

नीचे दिया गया JavaScript कोड दर्शाता है कि कैसे एक आयत पर पारदर्शी फ़िल रंग लागू किया जाए:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // एक ठोस आयताकार ऑटो शैप जोड़ें।
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // ठोस आकार के ऊपर एक पारदर्शी आयताकार ऑटो शैप जोड़ें।
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

![पारदर्शी आकार](shape-transparency.png)

## **आकार घुमाना**

Aspose.Slides आपको PowerPoint प्रस्तुति में आकारों को घुमाने की सुविधा देता है। यह विशिष्ट संरेखण या डिज़ाइन आवश्यकताओं के साथ दृश्य तत्वों को स्थिति देने में उपयोगी हो सकता है।

स्लाइड में किसी आकार को घुमाने के चरण:

1. [Presentation] क्लास की एक इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape] जोड़ें।
1. आकार की घूर्णन (rotation) प्रॉपर्टी को इच्छित कोण पर सेट करें।
1. प्रस्तुति को सहेजें।

नीचे दिया गया JavaScript कोड दिखाता है कि कैसे आकार को 5 डिग्री घुमाया जाए:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // आकार को 5 डिग्री घुमाएँ।
    shape.setRotation(5);

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![आकार घुमाव](shape-rotation.png)

## **3D बिवेल प्रभाव जोड़ना**

Aspose.Slides आपको आकारों पर 3D बिवेल प्रभाव लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat] गुणों को कॉन्फ़िगर करते हैं।

आकार पर 3D बिवेल प्रभाव जोड़ने के चरण:

1. [Presentation] क्लास की एक इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape] जोड़ें।
1. आकार के [ThreeDFormat] को बिवेल सेटिंग्स निर्धारित करने के लिए कॉन्फ़िगर करें।
1. प्रस्तुति को सहेजें।

नीचे दिया गया JavaScript कोड दर्शाता है कि कैसे आकार पर 3D बिवेल प्रभाव लागू किया जाए:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation क्लास की एक इंस्टेंस बनाएं।
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // स्लाइड में एक आकार जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // आकार की ThreeDFormat प्रॉपर्टी सेट करें।
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // प्रस्तुति को PPTP फ़ाइल के रूप में सहेजें।
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![3D बिवेल प्रभाव](3D-bevel-effect.png)

## **3D घुमाव प्रभाव जोड़ना**

Aspose.Slides आपको आकारों पर 3D घुमाव प्रभाव लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat] गुणों को कॉन्फ़िगर करते हैं।

आकार पर 3D घुमाव लागू करने के चरण:

1. [Presentation] क्लास की एक इंस्टेंस बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape] जोड़ें।
1. 3D घुमाव को परिभाषित करने के लिए [setCameraType] और [setLightType] का उपयोग करें।
1. प्रस्तुति को सहेजें।

नीचे दिया गया JavaScript कोड दिखाता है कि कैसे आकार पर 3D घुमाव प्रभाव लागू किया जाए:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation क्लास की एक इंस्टेंस बनाएं।
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![3D घुमाव प्रभाव](3D-rotation-effect.png)

## **आकारों के लिए काली‑सफ़ेद रेंडरिंग नियंत्रित करना**

[Shape.setBlackWhiteMode] मेथड यह निर्दिष्ट करता है कि जब प्रस्तुति को काली‑सफ़ेद मोड में देखा या प्रोसेस किया जाए, तो व्यक्तिगत आकार कैसे रेंडर होता है। यह स्वयं काली‑सफ़ेद डिस्प्ले को सक्षम नहीं करता, न ही यह सामान्य रंग मोड में आकार के फ़िल, लाइन या अन्य स्वरूपण को बदलता है।

वांछित व्यवहार चुनने के लिए आप [BlackWhiteMode] एन्‍युमरेशन से एक मान उपयोग करते हैं। उदाहरण के लिए, `Automatic` रेंडरिंग एप्लिकेशन को रूपांतरण चुनने देता है, `Gray` और `LightGray` ग्रे रंग उपयोग करते हैं, `BlackWhite` केवल काला‑सफ़ेद उपयोग करता है, `Black` और `White` एकल रंग को मजबूर करते हैं, `Color` सामान्य रंग बनाए रखता है, और `Hidden` काली‑सफ़ेद मोड में आकार को छोड़ देता है। `NotDefined` का अर्थ है कि कोई आकार‑स्तर मोड असाइन नहीं किया गया है।

नीचे दिया गया JavaScript कोड एक रंगीन आकार बनाता है और काली‑सफ़ेद डिस्प्ले मोड में उसे ग्रे दिखाता है:

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

    // ऑरेंज फ़िल को रंग मोड में रखें, लेकिन काली‑सफ़ेद मोड में आकार को ग्रे रंग में रेंडर करें।
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सामान्य रंग मोड में, आयत अपने नारंगी फ़िल को बनाए रखता है। काली‑सफ़ेद डिस्प्ले वर्कफ़्लो में, इसका मोड `Gray` सेट होने के कारण ग्रे रंग उपयोग करता है। यह आपको पूर्ण‑रंग स्लाइड को संरक्षित रखने और प्रिंटिंग, पूर्वावलोकन या अन्य वर्कफ़्लो में अलग दिखावट परिभाषित करने की सुविधा देता है जो काली‑सफ़ेद डिस्प्ले सेटिंग्स का सम्मान करता है।

## **स्वरूपण रीसेट करना**

नीचे दिया गया JavaScript कोड दिखाता है कि स्लाइड की स्वरूपण को कैसे रीसेट करें और सभी प्लेसहोल्डर वाले आकारों के स्थान, आकार और स्वरूपण को उनके डिफ़ॉल्ट सेटिंग पर पुनर्स्थापित करें, जो [LayoutSlide] पर स्थित हैं:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // लेआउट में प्लेसहोल्डर वाले स्लाइड पर प्रत्येक आकार को रीसेट करें।
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या आकार स्वरूपण अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करता है?**

बहुत ही न्यूनतम रूप से। एम्बेडेड छवियों और मीडिया की मात्रा फ़ाइल आकार का अधिकांश हिस्सा बनाती है, जबकि आकार पैरामीटर जैसे रंग, प्रभाव और ग्रेडिएंट मेटाडाटा के रूप में संग्रहीत होते हैं और वास्तविक आकार में लगभग कोई अतिरिक्त स्थान नहीं जोड़ते।

**मैं कैसे पहचानूँ कि कौन‑से आकार एक ही स्वरूपण साझा करते हैं ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकार की प्रमुख स्वरूपण विशेषताओं—फ़िल, लाइन और प्रभाव सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनकी शैलियों को समान मानें और उन आकारों को तर्कसंगत रूप से समूहित करें, जिससे बाद में शैली प्रबंधन आसान हो जाता है।

**क्या मैं कस्टम आकार शैलियों का एक सेट अलग फ़ाइल में सहेज सकता हूँ ताकि अन्य प्रस्तुतियों में पुनः उपयोग कर सकूँ?**

हाँ। इच्छित शैलियों वाले नमूना आकारों को एक टेम्प्लेट स्लाइड डेक या .POTX टेम्प्लेट फ़ाइल में सहेजें। नया प्रस्तुति बनाते समय टेम्प्लेट खोलें, आवश्यक शैली वाले आकारों को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो उनका स्वरूपण पुनः लागू करें।