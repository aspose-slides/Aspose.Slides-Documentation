---
title: जावास्क्रिप्ट में प्रस्तुतियों से शैप के प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/nodejs-java/shape-effective-properties/
keywords:
- आकार गुण
- कैमरा गुण
- लाइट रिग
- बेवेल शैप
- टेक्स्ट फ्रेम
- टेक्स्ट स्टाइल
- फ़ॉन्ट ऊँचाई
- फ़िल फॉर्मेट
- PowerPoint
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट के माध्यम से Aspose.Slides for Node.js यह पता लगाएँ कि कैसे सटीक PowerPoint रेंडरिंग के लिए प्रभावी शैप गुणों की गणना और लागू करता है।"
---
## **अवलोकन**

यह विषय **local** और **effective** गुणों के बीच अंतर समझाता है। Local मान वे मान होते हैं जिन्हें किसी विशिष्ट फॉर्मेटिंग स्तर पर सीधे सेट किया जाता है, जैसे:

1. स्लाइड पर portion गुण।
1. लेआउट या मास्टर स्लाइड पर प्रोटोटाइप शैप टेक्स्ट शैलियाँ, जब portion के टेक्स्ट फ्रेम शैप में एक हो।
1. प्रेजेंटेशन में ग्लोबल टेक्स्ट सेटिंग्स।

Local मान किसी भी स्तर पर परिभाषित या छोड़े जा सकते हैं। जब Aspose.Slides को अंतिम "as rendered" फॉर्मेटिंग चाहिए होती है, तो यह इनहेरिटेंस चेन को हल करता है और **effective** मान लौटाता है। आप इन्हें स्थानीय फॉर्मेट ऑब्जेक्ट पर `getEffective` मेथड को कॉल करके प्राप्त कर सकते हैं।

निम्न उदाहरण दर्शाता है कि प्रभावी मान कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शैप एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) है जिसमें एक टेक्स्ट फ्रेम और कम से कम एक portion हो।

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Effective फॉर्मेटिंग डेटा वह वर्तमान गणना किया गया फॉर्मेटिंग दर्शाता है जो इनहेरिटेंस लागू होने के बाद प्राप्त होता है। वर्तमान कार्यान्वयन में, कुछ effective डेटा ऑब्जेक्ट्स आंतरिक रूप से कैश हो सकते हैं। पैरेंट या इनहेरिटेड फॉर्मेटिंग को बदलने के बाद `getEffective` को फिर से कॉल करने से कैश्ड डेटा रीफ़्रेश हो सकता है, और पहले प्राप्त किया गया ऑब्जेक्ट अब पूर्व अवस्था का प्रतिनिधित्व नहीं कर सकता। यदि आपको प्रभावी मानों को बाद में पुनः उपयोग के लिए संरक्षित करना है, तो आवश्यक गुणों जैसे फ़ॉन्ट की ऊँचाई, भरने का रंग, फ़ॉन्ट शैली, या अलाइनमेंट को अपने डेटा ऑब्जेक्ट में कॉपी करें।
{{% /alert %}}

## **कैमरा के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको कैमरे के प्रभावी गुण प्राप्त करने की अनुमति देता है। प्रभावी कैमरा डेटा ऑब्जेक्ट में अपरिवर्तनीय कैमरा गुण होते हैं और यह [ThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/) के लिए लौटाए गए प्रभावी मानों के माध्यम से उपलब्ध कराया जाता है।

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Light Rig के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको लाइट रिग के प्रभावी गुण प्राप्त करने की अनुमति देता है। प्रभावी लाइट रिग डेटा ऑब्जेक्ट में अपरिवर्तनीय लाइट रिग गुण होते हैं और यह [ThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/) के लिए लौटाए गए प्रभावी मानों के माध्यम से उपलब्ध कराया जाता है।

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Bevel Shape के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको बेवेल शेप के प्रभावी गुण प्राप्त करने की अनुमति देता है। प्रभावी शेप बेवेल डेटा ऑब्जेक्ट में शैप के अपरिवर्तनीय फेस‑रिलीफ गुण होते हैं और यह [ThreeDFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/) के लिए लौटाए गए प्रभावी मानों के माध्यम से उपलब्ध कराया जाता है।

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त करें**

Aspose.Slides का उपयोग करके आप टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त कर सकते हैं। लौटाया गया प्रभावी डेटा ऑब्जेक्ट टेक्स्ट फ्रेम फॉर्मेटिंग गुणों को शामिल करता है।

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट स्टाइल के प्रभावी गुण प्राप्त करें**

Aspose.Slides का उपयोग करके आप टेक्स्ट स्टाइल के प्रभावी गुण प्राप्त कर सकते हैं। लौटाया गया प्रभावी डेटा ऑब्जेक्ट टेक्स्ट स्टाइल गुणों को शामिल करता है।

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **प्रभावी फ़ॉन्ट ऊँचाई मान प्राप्त करें**

Aspose.Slides का उपयोग करके आप प्रभावी फ़ॉन्ट ऊँचाई प्राप्त कर सकते हैं। निम्न कोड दिखाता है कि विभिन्न प्रेजेंटेशन संरचना स्तरों पर स्थानीय फ़ॉन्ट ऊँचाई मान सेट होने के बाद एक portion की प्रभावी फ़ॉन्ट ऊँचाई कैसे बदलती है।

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **टेबल के लिए प्रभावी फ़िल फॉर्मेट प्राप्त करें**

Aspose.Slides का उपयोग करके आप विभिन्न टेबल भागों के लिए प्रभावी फ़िल फॉर्मेटिंग प्राप्त कर सकते हैं। लौटाया गया प्रभावी डेटा ऑब्जेक्ट फ़िल फॉर्मेटिंग गुणों को शामिल करता है। सेल फॉर्मेटिंग की प्राथमिकता रो फॉर्मेटिंग से अधिक होती है, रो फॉर्मेटिंग की प्राथमिकता कॉलम फॉर्मेटिंग से अधिक होती है, और कॉलम फॉर्मेटिंग की प्राथमिकता पूरे‑टेबल फॉर्मेटिंग से अधिक होती है।

परिणामस्वरूप, प्रभावी सेल फॉर्मेटिंग गुणों का उपयोग टेबल सेल को ड्रॉ करने के लिए किया जाता है। निम्न कोड उदाहरण विभिन्न टेबल भागों के लिए प्रभावी फ़िल फॉर्मेटिंग प्राप्त करने का तरीका दिखाता है। यह मानता है कि पहली स्लाइड पर पहला शैप एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/table/) है।

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या `getEffective` एक स्नैपशॉट लौटाता है?**

हमेशा नहीं। Effective डेटा वह गणना किया गया फॉर्मेटिंग दर्शाता है जो इनहेरिटेंस लागू होने के बाद प्राप्त होता है, लेकिन कुछ effective डेटा ऑब्जेक्ट्स आंतरिक रूप से कैश हो सकते हैं। एक बाद का `getEffective` कॉल फॉर्मेटिंग को पुनः गणना कर सकता है और कैश्ड डेटा को रीफ़्रेश कर सकता है, इसलिए पहले प्राप्त किया गया ऑब्जेक्ट स्थायी स्नैपशॉट माना नहीं जाना चाहिए।

**मुझे प्रभावी गुणों को फिर से कब पढ़ना चाहिए?**

स्थानीय फॉर्मेटिंग, पैरेंट स्टाइल्स, लेआउट फॉर्मेटिंग, मास्टर फॉर्मेटिंग या प्रेजेंटेशन‑स्तर डिफ़ॉल्ट बदलने के बाद `getEffective` को फिर से कॉल करें। अगली कॉल फॉर्मेटिंग पदानुक्रम का पुनर्मूल्यांकन करती है और वर्तमान प्रभावी परिणाम लौटाती है।

**क्या लेआउट/मास्टर स्लाइड में परिवर्तन या हटाना उन प्रभावी गुणों को प्रभावित करता है जो पहले ही प्राप्त किए जा चुके हैं?**

हां, लेकिन परिवर्तन अगली `getEffective` कॉल पर परिलक्षित होता है। यदि पैरेंट फॉर्मेटिंग स्रोत बदल या हटाया जाता है, तो पहले प्राप्त किया गया प्रभावी डेटा पुराना हो सकता है। एक बार फिर `getEffective` कॉल करने पर Aspose.Slides फॉर्मेटिंग ट्री को पुनः मूल्यांकन करता है और परिणामी फ़ॉन्ट, रंग, आकार या अन्य मान बदल सकते हैं।

**क्या मैं प्रभावी डेटा ऑब्जेक्ट्स के माध्यम से मानों में परिवर्तन कर सकता हूँ?**

नहीँ। Effective डेटा ऑब्जेक्ट्स गणना किए गए मानों को उजागर करते हैं। स्थानीय फॉर्मेटिंग ऑब्जेक्ट्स में परिवर्तन करें, फिर प्रभावी मानों को फिर से प्राप्त करें।

**यदि कोई गुण शैप स्तर पर, न लेआउट/मास्टर में, न ही वैश्विक सेटिंग्स में सेट नहीं है तो क्या होता है?**

प्रभावी मान डिफ़ॉल्ट मेकैनिज़्म द्वारा निर्धारित किया जाता है, जिसमें PowerPoint और Aspose.Slides के डिफ़ॉल्ट शामिल हैं। वह हल किया गया मान वर्तमान प्रभावी डेटा का हिस्सा बन जाता है।

**क्या प्रभावी फ़ॉन्ट मान से पता चल सकता है कि कौनसे स्तर ने आकार या टाइपफेस प्रदान किया?**

सीधे नहीं। Effective डेटा अंतिम मान लौटाता है। स्रोत पता करने के लिए portion, paragraph, टेक्स्ट फ्रेम, और लेआउट, मास्टर तथा प्रेजेंटेशन स्तर पर स्थानीय मानों को देखना पड़ता है कि पहली स्पष्ट परिभाषा कहाँ हुई।

**कभी-कभी प्रभावी मान स्थानीय मानों के समान क्यों दिखते हैं?**

क्योंकि स्थानीय मान अंत में अंतिम बन गया (उच्च‑स्तर इनहेरिटेंस की आवश्यकता नहीं पड़ी)। ऐसे मामलों में प्रभावी मान स्थानीय मान से मेल खाता है।

**मुझे प्रभावी गुण कब उपयोग करने चाहिए, और स्थानीय मानों के साथ केवल कब काम करना चाहिए?**

जब आपको सभी इनहेरिटेंस लागू होने के बाद "जैसे रेंडर किया गया" परिणाम चाहिए, जैसे रंग, इंडेंट या आकार को संरेखित करने के लिए, तो प्रभावी डेटा का उपयोग करें। यदि आपको उन मानों को बाद में फॉर्मेटिंग परिवर्तन के बावजूद संरक्षित रखना है, तो आवश्यक गुणों को अपने स्वयं के ऑब्जेक्ट में कॉपी करें। यदि आपको किसी विशेष स्तर पर फॉर्मेटिंग बदलनी है, तो स्थानीय गुणों को संशोधित करें और फिर, यदि आवश्यक हो, प्रभावी डेटा को फिर से पढ़ें ताकि परिणाम की पुष्टि हो सके।