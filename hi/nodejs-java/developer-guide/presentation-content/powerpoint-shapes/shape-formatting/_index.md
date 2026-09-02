---
title: JavaScript में PowerPoint आकारों को फ़ॉर्मेट करें
linktitle: आकार फ़ॉर्मेटिंग
type: docs
weight: 20
url: /hi/nodejs-java/shape-formatting/
keywords:
- आकार फ़ॉर्मेट
- रेखा फ़ॉर्मेट
- स्केच प्रभाव
- स्केच आकार रेखा
- जॉइन स्टाइल फ़ॉर्मेट
- ग्रेडिएंट फिल
- पैटर्न फिल
- पिक्चर फिल
- टेक्सचर फिल
- सॉलिड कलर फिल
- आकार पारदर्शिता
- आकार घुमाएँ
- 3D बिवेल प्रभाव
- 3D रोटेशन प्रभाव
- फ़ॉर्मेट रीसेट
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके JavaScript में PowerPoint आकारों को फ़ॉर्मेट करें—PPT, PPTX और ODP फ़ाइलों के लिए भराव, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में आकार (शेप्स) जोड़ सकते हैं। क्योंकि आकार रेखाओं से बनते हैं, आप उनके आउटलाइन को संशोधित करके या उन पर प्रभाव लागू करके उन्हें स्वरूपित कर सकते हैं। अतिरिक्त रूप से, आप आकारों को उन सेटिंग्स को निर्दिष्ट करके स्वरूपित कर सकते हैं जो नियंत्रित करती हैं कि उनका भीतर हिस्सा कैसे भरा जाए।

![PowerPoint में आकार फ़ॉर्मेट](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java ऐसे क्लास और मेथड प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकारों को फ़ॉर्मेट करने की अनुमति देते हैं।

## **रेखाओं को फ़ॉर्मेट करें**

Aspose.Slides का उपयोग करके, आप किसी आकार के लिए एक कस्टम लाइन शैली निर्दिष्ट कर सकते हैं। नीचे दिया गया चरण इस प्रक्रिया को दर्शाता है:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
1. आकार की [line style](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई सेट करें।
1. लाइन का [dash style](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/linedashstyle/) सेट करें।
1. आकार के लिए लाइन का रंग सेट करें।
1. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न कोड दिखाता है कि कैसे एक आयत `AutoShape` को फ़ॉर्मेट किया जाता है:

```js
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // आयत आकार के लिए भराव रंग सेट करें।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // आयत की रेखाओं पर फ़ॉर्मेटिंग लागू करें।
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // आयत की रेखा का रंग सेट करें।
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![प्रेज़ेंटेशन में फ़ॉर्मेट की गई रेखाएँ](formatted-lines.png)

## **आकार रेखाओं पर स्केچ प्रभाव लागू करें**

एक स्केच प्रभाव आकार की रेखा को हाथ से खींचे जैसा दिखाता है। लाइन सेटिंग्स तक पहुँचने के लिए [Shape.getLineFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) का उपयोग करें, स्केच सेटिंग्स तक पहुँचने के लिए [LineFormat.getSketchFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/lineformat/) का उपयोग करें, और [SketchFormat.setSketchType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sketchformat/) से [LineSketchType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/linesketchtype/) enumeration में से मान चुनें।

निम्न JavaScript कोड दिखाता है कि कैसे [LineSketchType.Curved](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/linesketchtype/) प्रभाव लागू किया जाता है, स्पष्ट रूप से असाइन किए गए मान को पढ़ा जाता है, और [LineSketchType.None](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/linesketchtype/) द्वारा प्रभाव हटाया जाता है:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // आकार के लाइन फ़ॉर्मेट और उसके स्केच फ़ॉर्मेट तक पहुँचें।
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // एक स्केच प्रभाव लागू करें।
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // स्केच प्रभाव को सीधे आकार को असाइन किया गया पढ़ें।
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // स्केच प्रभाव हटाएँ।
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sketchformat/) द्वारा लौटाया गया मान आकार को सीधे असाइन की गई सेटिंग को दर्शाता है। यदि लाइन फ़ॉर्मेटिंग थीम, मास्टर स्लाइड या लेआउट स्लाइड से इनहेरिट की जा सकती है, तो [LineFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/lineformat/) का उपयोग करें, लौटाए गए ऑब्जेक्ट पर `getSketchFormat` कॉल करें, और फिर उसके `getSketchType` मेथड को कॉल करें। प्रभावी मान वह फ़ॉर्मेटिंग दर्शाता है जो इनहेरिटेंस हल होने के बाद वास्तविक रूप से लागू होती है:

```js
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

## **जॉइन स्टाइल्स फ़ॉर्मेट करें**

तीन जॉइन टाइप विकल्प हैं:

* राउंड
* मिटर
* बीवेल

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे आकार के कोने पर), तो यह **राउंड** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीक्ष्ण कोण वाले आकार को ड्रॉ कर रहे हैं, तो आप **मिटर** विकल्प को प्राथमिकता दे सकते हैं।

![प्रेज़ेंटेशन में जॉइन स्टाइल](join-style-powerpoint.png)

निम्न JavaScript कोड दिखाता है कि कैसे ऊपर की छवि में दिखाए गए तीन आयतों को मिटर, बीवेल और राउंड जॉइन टाइप सेटिंग्स का उपयोग करके बनाया गया:

```js
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार के तीन ऑटो शैप जोड़ें।
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // प्रत्येक आयत आकार के लिए भराव रंग सेट करें।
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

    // जॉइन स्टाइल सेट करें।
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

PowerPoint में, ग्रेडिएंट फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार पर निरंतर रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंग इस तरह लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में मिल जाता है।

Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट फिल कैसे लागू करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
1. आकार का [FillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) `Gradient` पर सेट करें।
1. ग्रेडिएंट फ़ॉर्मेट द्वारा प्रदान किए गए ग्रेडिएंट स्टॉप कलेक्शन की `add` मेथड्स का उपयोग करके परिभाषित स्थितियों के साथ दो पसंदीदा रंग जोड़ें।
1. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न JavaScript कोड दिखाता है कि कैसे एक अंडाकार पर ग्रेडिएंट फिल इफ़ेक्ट लागू किया जाता है:

```js
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Ellipse प्रकार का एक ऑटो शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Ellipse पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
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

![ग्रेडिएंट फिल के साथ अंडाकार](gradient-fill.png)

## **पैटर्न फिल**

PowerPoint में, पैटर्न फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको दो‑रंग के डिज़ाइन—जैसे डॉट्स, स्ट्राइप्स, क्रॉसहैचेज़ या चेक्स—को आकार पर लागू करने देता है। आप पैटर्न के फोरग्राउंड और बैकग्राउंड के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक प्री‑डिफ़ाइन्ड पैटर्न स्टाइल प्रदान करता है जिन्हें आप अपनी प्रस्तुतियों की दृश्य अपील बढ़ाने के लिए आकारों पर लागू कर सकते हैं। प्री‑डिफ़ाइन्ड पैटर्न चुनने के बाद भी, आप उपयोग किए जाने वाले सटीक रंग निर्दिष्ट कर सकते हैं।

Aspose.Slides का उपयोग करके आकार पर पैटर्न फिल कैसे लागू करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
1. आकार का [FillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) `Pattern` पर सेट करें।
1. प्री‑डिफ़ाइन्ड विकल्पों में से एक पैटर्न स्टाइल चुनें।
1. पैटर्न के [Background Color](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/patternformat/#getBackColor--) को सेट करें।
1. पैटर्न के [Foreground Color](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/patternformat/#getForeColor--) को सेट करें।
1. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न JavaScript कोड दिखाता है कि कैसे एक आयत पर पैटर्न फिल लागू किया जाता है:

```js
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // भराव प्रकार को पैटर्न पर सेट करें।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // पैटर्न शैली सेट करें।
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // पैटर्न के बैकग्राउंड और फोरग्राउंड रंग सेट करें।
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

PowerPoint में, पिक्चर फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार के अंदर एक छवि सम्मिलित करने देता है—वास्तव में छवि को आकार की पृष्ठभूमि के रूप में उपयोग करता है।

Aspose.Slides का उपयोग करके आकार पर पिक्चर फिल कैसे लागू करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
1. आकार का [FillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) `Picture` पर सेट करें।
1. पिक्चर फिल मोड को `Tile` (या कोई अन्य पसंदीदा मोड) पर सेट करें।
1. जिस छवि का उपयोग करना चाहते हैं, उससे एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं।
1. छवि को `ISlidesPicture.setImage` मेथड के द्वारा पास करें।
1. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

लो़टस चित्र:

![लो़टस चित्र](lotus.png)

निम्न JavaScript कोड दिखाता है कि कैसे आकार को पिक्चर से भरा जाता है:

```js
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // भराव प्रकार को Picture पर सेट करें।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // पिक्चर भराव मोड सेट करें।
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // एक छवि लोड करें और उसे प्रेज़ेंटेशन संसाधनों में जोड़ें।
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

![पिक्चर फिल के साथ आकार](picture-fill.png)

### **टाइल पिक्चर को टेक्सचर के रूप में**

यदि आप टाइल की गई छवि को टेक्सचर के रूप में सेट करना और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [PictureFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/) क्लास की निम्न मेथड्स का उपयोग कर सकते हैं:

- [setPictureFillMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): चित्र भरने के मोड को सेट करता है—`Tile` या `Stretch`।
- [setTileAlignment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): आकार के भीतर टाइल्स की अलाइमेंट निर्दिष्ट करता है।
- [setTileFlip](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): नियंत्रित करता है कि टाइल को क्षैतिज, लंबवत या दोनों दिशा में फ़्लिप किया जाए।
- [setTileOffsetX](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): आकार की मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [setTileOffsetY](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): आकार की मूल बिंदु से टाइल का लंबवत ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [setTileScaleX](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): टाइल का क्षैतिज स्केल प्रतिशत में परिभाषित करता है।
- [setTileScaleY](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): टाइल का लंबवत स्केल प्रतिशत में परिभाषित करता है।

निम्न कोड सैंपल दिखाता है कि कैसे एक आयत आकार को टाइल्ड पिक्चर फिल के साथ जोड़ा जाता है और टाइल विकल्प कॉन्फ़िगर किए जाते हैं:

```js
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let firstSlide = presentation.getSlides().get_Item(0);

    // एक आयत ऑटो शैप जोड़ें।
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // आकार का भराव प्रकार Picture पर सेट करें।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // छवि को लोड करें और उसे प्रेज़ेंटेशन संसाधनों में जोड़ें।
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // चित्र को आकार को असाइन करें।
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // पिक्चर फ़िल मोड और टाइलिंग प्रॉपर्टीज़ को कॉन्फ़िगर करें।
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

PowerPoint में, सॉलिड कलर फिल एक फ़ॉर्मेटिंग विकल्प है जो आकार को एक ही समान रंग से भर देता है। यह साधारण पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, टेक्सचर या पैटर्न के लागू होता है।

Aspose.Slides का उपयोग करके आकार पर सॉलिड कलर फिल कैसे लागू करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
1. आकार का [FillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) `Solid` पर सेट करें।
1. आकार को अपनी पसंद का फ़िल रंग असाइन करें।
1. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न JavaScript कोड दिखाता है कि कैसे एक आयत पर सॉलिड कलर फिल लागू किया जाता है:

```js
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // भराव प्रकार को Solid पर सेट करें।
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // भराव रंग सेट करें।
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![सॉलिड कलर फिल के साथ आकार](solid-color-fill.png)

## **ट्रांसपेरेंसी सेट करें**

PowerPoint में, जब आप आकारों पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फिल लागू करते हैं, तो आप पारदर्शिता स्तर भी सेट कर सकते हैं जिससे फिल की अपारदर्शिता नियंत्रित होती है। अधिक पारदर्शिता मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या अंतर्निहित वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल में उपयोग किए गए रंग के अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने देता है। इसे करने का तरीका यहाँ है:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) को `Solid` पर सेट करें।
1. `Color` का उपयोग करके पारदर्शिता वाला रंग परिभाषित करें (अल्फा कंपोनेंट पारदर्शिता को नियंत्रित करता है)।
1. प्रेज़ेंटेशन को सहेजें।

निम्न JavaScript कोड दिखाता है कि कैसे एक आयत पर पारदर्शी फिल रंग लागू किया जाता है:

```js
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
let presentation = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // एक ठोस आयत ऑटो शैप जोड़ें।
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // ठोस आकार के ऊपर एक पारदर्शी आयत ऑटो शैप जोड़ें।
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

## **आकार घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकारों को घुमाने की अनुमति देता है। यह विशेष संरेखण या डिज़ाइन आवश्यकताओं के साथ दृश्य तत्वों को स्थित करने में उपयोगी हो सकता है।

किसी स्लाइड पर आकार को घुमाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
1. आकार की घूर्णन प्रॉपर्टी को इच्छित कोण पर सेट करें।
1. प्रेज़ेंटेशन को सहेजें।

निम्न JavaScript कोड दिखाता है कि कैसे आकार को 5 डिग्री घुमाया जाता है:

```js
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
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

## **3D बिवेल इफेक्ट जोड़ें**

Aspose.Slides आपको आकारों पर 3D बिवेल इफेक्ट लागू करने की अनुमति देता है, जिसमें आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/) प्रॉपर्टी को कॉन्फ़िगर करते हैं।

आकार में 3D बिवेल इफेक्ट जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास इंस्टैंशिएट करें।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
1. आकार के [ThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/) को कॉन्फ़िगर करके बिवेल सेटिंग्स परिभाषित करें।
1. प्रेज़ेंटेशन को सहेजें।

निम्न JavaScript कोड दिखाता है कि कैसे एक आकार पर 3D बिवेल इफेक्ट लागू किया जाता है:

```js
// Presentation क्लास का एक इंस्टेंस बनाएं।
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

    // आकार की ThreeDFormat प्रॉपर्टीज़ सेट करें।
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![3D बिवेल इफ़ेक्ट](3D-bevel-effect.png)

## **3D रोटेशन इफेक्ट जोड़ें**

Aspose.Slides आपको आकारों पर 3D रोटेशन इफेक्ट लागू करने की अनुमति देता है, जिसमें आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/) प्रॉपर्टी को कॉन्फ़िगर करते हैं।

आकार पर 3D रोटेशन लागू करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
1. 3D रोटेशन को परिभाषित करने के लिए [setCameraType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/camera/#setCameraType) और [setLightType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/lightrig/#setLightType) का उपयोग करें।
1. प्रेज़ेंटेशन को सहेजें।

निम्न JavaScript कोड दिखाता है कि कैसे एक आकार पर 3D रोटेशन इफेक्ट लागू किया जाता है:

```js
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

    // प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![3D रोटेशन इफ़ेक्ट](3D-rotation-effect.png)

## **फ़ॉर्मेट रीसेट करें**

निम्न Java कोड दिखाता है कि कैसे स्लाइड के फ़ॉर्मेटिंग को रीसेट किया जाता है और [LayoutSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/) में प्लेसहोल्डर वाले सभी आकारों की स्थिति, आकार और फ़ॉर्मेटिंग को उनके डिफ़ॉल्ट सेटिंग्स में लौटाया जाता है:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // लेआउट में प्लेसहोल्डर वाले प्रत्येक आकार को स्लाइड पर रीसेट करें।
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या आकार फ़ॉर्मेटिंग अंतिम प्रेज़ेंटेशन फ़ाइल आकार को प्रभावित करती है?**

बहुत कम मात्रा में। एम्बेडेड इमेज़ और मीडिया फ़ाइलें फ़ाइल स्पेस का अधिकांश हिस्सा लेती हैं, जबकि आकार पैरामीटर जैसे रंग, प्रभाव और ग्रेडिएंट मेटाडेटा के रूप में संग्रहीत होते हैं और अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे उन आकारों का पता लगा सकता हूँ जो स्लाइड पर समान फ़ॉर्मेटिंग साझा करते हैं ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकार की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान समान हैं, तो उनकी शैली को समान मानें और उन आकारों को तार्किक रूप से समूहित करें, जिससे बाद में शैली प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकार स्टाइल्स के सेट को एक अलग फ़ाइल में सहेज सकता हूँ ताकि उन्हें अन्य प्रस्तुतियों में पुनः उपयोग किया जा सके?**

हां। इच्छित शैलियों वाले नमूना आकारों को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में रखें। नई प्रस्तुति बनाते समय टेम्पलेट खोलें, आवश्यक स्टाइल्ड आकारों को क्लोन करें, और जहाँ भी आवश्यक हो उनके फ़ॉर्मेटिंग को पुनः लागू करें।