---
title: JavaScript में प्रेजेंटेशनों से आकार के प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/nodejs-java/shape-effective-properties/
keywords:
- आकार गुण
- कैमरा गुण
- लाइट रिग
- बेवेल आकार
- टेक्स्ट फ़्रेम
- टेक्स्ट शैली
- फ़ॉन्ट ऊँचाई
- फ़िल फ़ॉर्मैट
- PowerPoint
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: Aspose.Slides के Node.js via Java उपयोग करके PowerPoint प्रेजेंटेशनों में स्थानीय, विरासतित, और प्रभावी आकार फ़ॉर्मेटिंग को कैसे अलग करें, यह सीखें।
---
## **स्थानीय, विरासतित, और प्रभावी गुणों को समझें**

PowerPoint फॉर्मैटिंग कई स्थानों से आ सकती है। किसी ऑब्जेक्ट पर सीधे संग्रहीत मान उसका **local value** है। यदि वह मान सेट नहीं है, तो PowerPoint पैरेंट फॉर्मैटिंग स्रोतों को देखता है, जैसे पैराग्राफ डिफ़ॉल्ट, टेक्स्ट स्टाइल, लेआउट या मास्टर स्लाइड, थीम, या प्रेजेंटेशन‑स्तर के डिफ़ॉल्ट। ये मान **inherited values** हैं। पूरी हायरेरकी हल होने के बाद जो मान बचता है वह **effective value** है—ऑब्जेक्ट को रेंडर करने के लिए प्रयुक्त मान।

उदाहरण के लिए, किसी टेक्स्ट पोर्शन ने अपनी फ़ॉन्ट ऊँचाई परिभाषित नहीं की हो सकती है। उसका स्थानीय [getFontHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/#getFontHeight) मान फिर `NaN` होता है, जिसका अर्थ है "यहाँ सेट नहीं है"। पोर्शन अपनी पैराग्राफ, प्रेजेंटेशन के डिफ़ॉल्ट टेक्स्ट स्टाइल, या किसी अन्य लागू स्रोत से ऊँचाई विरासत में ले सकता है। पोर्शन फ़ॉर्मेट पर [getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/#getEffective) को कॉल करने से अंतिम हल किया गया ऊँचाई प्राप्त होती है।

विभिन्न उद्देश्यों के लिए दो प्रकार के फॉर्मैटिंग डेटा का उपयोग करें:

- जब आपको नियंत्रित करना हो कि मान कहाँ परिभाषित है, तब स्थानीय फ़ॉर्मेट ऑब्जेक्ट, जैसे [PortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/), को पढ़ें या बदलें।
- जब आपको अंतिम, रेंडर किया गया परिणाम चाहिए, तब [effective data returned by PortionFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/#getEffective) को पढ़ें। प्रभावी डेटा केवल पढ़ने योग्य है।

[Aspose.Slides for Node.js via Java स्थापित करें](/slides/hi/nodejs-java/installation/)।

## **स्थानीय, विरासतित, और प्रभावी मानों की तुलना**

निम्नलिखित पूर्ण उदाहरण एक शैप बनाता है और प्रस्तुति, पैराग्राफ, और पोर्शन स्तरों पर फ़ॉन्ट ऊँचाइयाँ लागू करता है। प्रत्येक चरण उन स्तरों पर परिभाषित मानों और उसी टेक्स्ट पोर्शन के परिणामस्वरूप प्रभावी मान को प्रिंट करता है। यह यह भी दर्शाता है कि फॉर्मेटिंग परिवर्तन के बाद प्रभावी डेटा को फिर से पढ़ना क्यों आवश्यक है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // पहले किए गए परिवर्तनों के बाद प्रभावी डेटा पढ़ें।
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // दो अलग-अलग स्तरों पर विरासतित मानों को परिभाषित करें।
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // पोर्शन पर स्थानीय मान दोनों विरासतित मानों को ओवरराइड करता है।
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // विरासतित मान बदलने से मौजूदा स्थानीय मान ओवरराइड नहीं होता।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // स्थानीय मान को साफ़ करें। अब पोर्शन फिर से पैराग्राफ से विरासत में लेता है।
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // पैराग्राफ मान को साफ़ करें। अब प्रेजेंटेशन का डिफ़ॉल्ट परिणाम प्रदान करता है।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

इस उदाहरण में प्राथमिकता पोर्शन स्थानीय फॉर्मेटिंग, फिर पैराग्राफ फॉर्मेटिंग, फिर प्रस्तुति डिफ़ॉल्ट है। अन्य ऑब्जेक्ट्स की विरासत श्रृंखलाएँ अलग हो सकती हैं, पर सिद्धांत समान है: एक अधिक विशिष्ट स्पष्ट मान जीतता है, और [getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/#getEffective) अंतिम परिणाम लौटाता है।

## **प्रभावी टेक्स्ट गुण प्राप्त करें**

टेक्स्ट फॉर्मैटिंग कई ऑब्जेक्ट्स में विभाजित है:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#getEffective) मार्जिन, एंकरिंग, ऑटोफिट, और वर्टिकल टेक्स्ट दिशा जैसे टेक्स्ट‑फ़्रेम गुणों को हल करता है।
- [TextStyle.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textstyle/#getEffective) प्रत्येक टेक्स्ट स्टाइल स्तर के लिए पैराग्राफ फॉर्मेटिंग को हल करता है।
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#getEffective) संरेक्षण, इंडेंटेशन, और बुलेट्स जैसे पैराग्राफ गुणों को हल करता है।
- [PortionFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/#getEffective) फ़ॉन्ट ऊँचाई, फ़ॉन्ट, रंग, बोल्ड, और इटैलिक जैसे कैरेक्टर गुणों को हल करता है।

अगले उदाहरण के लिए, `text-formatting.pptx` में कम से कम एक स्लाइड और एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) होना चाहिए जिसमें गैर‑खाली टेक्स्ट फ़्रेम हो। AutoShape शैप संग्रह में किसी भी स्थान पर हो सकता है; कोड एक उपयुक्त ऑब्जेक्ट की खोज करता है और उपयोग से पहले उसकी वैधता जाँचता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **प्रभावी 3D गुण प्राप्त करें**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getEffective) एक प्रभावी डेटा ऑब्जेक्ट लौटाता है जो सभी हल किए गए 3D सेटिंग्स को समूहित करता है। इसके [getCamera](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getBevelTop), और [getBevelBottom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/threedformat/#getBevelBottom) मेथड्स संबंधित प्रभावी डेटा को उजागर करते हैं। इन संबंधित सेटिंग्स को साथ में पढ़ने से शैप के अंतिम 3D रूप को समझना आसान हो जाता है।

इस उदाहरण के लिए, `shape-3d.pptx` में पहली स्लाइड पर कम से कम एक शैप होना चाहिए। यदि आप आउटपुट में डिफ़ॉल्ट से अलग मान चाहते हैं तो उस शैप पर 3D कैमरा, लाइटिंग, या बवेल सेटिंग्स लागू करें।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **प्रभावी तालिका स्वरूपण प्राप्त करें**

तालिका स्वरूपण तालिका शैली और पूरी तालिका, एक कॉलम, एक पंक्ति, या व्यक्तिगत सेल पर लागू फॉर्मेट्स से आ सकता है। स्पष्ट रूप से परिभाषित फ़िल्स के बीच संघर्ष की स्थिति में प्राथमिकता सेल, पंक्ति, कॉलम, और फिर पूरी तालिका की होती है। किसी सेल का प्रभावी फॉर्मेट वह अंतिम फॉर्मेट है जो उस सेल को ड्रॉ करने के लिए उपयोग किया जाता है।

इस उदाहरण के लिए, `table-formatting.pptx` में पहली स्लाइड पर कम से कम एक तालिका होनी चाहिए। तालिका में कम से कम एक पंक्ति और एक कॉलम होना चाहिए। कोड यह मानने के बजाय कि `getShapes().get_Item(0)` एक तालिका है, एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/table/) की खोज करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

यदि आपको केवल फ़िल टाइप नहीं बल्कि रंग चाहिए, तो पहले प्रभावी [getFillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/#getFillType) को जाँचें, और फिर उस टाइप पर लागू मेथड पढ़ें—उदाहरण के लिए, सॉलिड फ़िल के लिए [getSolidFillColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/#getSolidFillColor)।

## **परिवर्तनों के बाद प्रभावी डेटा को फिर से पढ़ें**

प्रभावी डेटा उन क्षण में हल की गई फॉर्मेटिंग हायरेरकी को वर्णित करता है। उस हायरेरकी में भाग लेने वाले किसी भी चीज़ को बदलने के बाद `getEffective` को फिर से कॉल करें, जिसमें शामिल हैं:

- ऑब्जेक्ट का स्थानीय फॉर्मेटिंग;
- पैराग्राफ या टेक्स्ट‑फ़्रेम डिफ़ॉल्ट;
- तालिका शैली, तालिका, कॉलम, पंक्ति, या सेल फॉर्मेट;
- लेआउट या मास्टर स्लाइड फॉर्मेटिंग;
- थीम डेटा या प्रेजेंटेशन‑स्तर डिफ़ॉल्ट;
- स्लाइड को असाइन किया गया लेआउट या मास्टर।

एक प्रभावी डेटा ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में न रखें। Aspose.Slides कुछ प्रभावी डेटा को आंतरिक रूप से कैश कर सकता है, और बाद में `getEffective` कॉल उस डेटा को रीफ़्रेश कर सकती है। यदि आपको परिवर्तन से पहले और बाद के मानों की तुलना करनी है, तो परिवर्तन करने से पहले आवश्यक स्केलर मानों—जैसे फ़ॉन्ट ऊँचाई, रंग, संरेक्षण, या बवेल चौड़ाई—को अपनी स्वयं की वेरिएबल्स में कॉपी कर लें।

किसी मान को बदलने के लिए, उपयुक्त स्थानीय फ़ॉर्मेट ऑब्जेक्ट को अपडेट करें और फिर परिणाम सत्यापित करने के लिए `getEffective` को कॉल करें। प्रभावी डेटा ऑब्जेक्ट स्वयं केवल‑पढ़ने योग्य होते हैं।

## **FAQ**

**मैं कैसे पता लगा सकता हूँ कि कौन‑से स्तर ने प्रभावी मान प्रदान किया?**

प्रभावी डेटा अंतिम मान रखता है, उसके स्रोत को नहीं। सबसे विशिष्ट स्तर से बाहर की ओर लागू स्थानीय ऑब्जेक्ट्स की जांच करें। टेक्स्ट के लिए इसमें पोर्शन, पैराग्राफ, टेक्स्ट फ्रेम, लेआउट, मास्टर, थीम, और प्रेजेंटेशन डिफ़ॉल्ट शामिल हो सकते हैं। `NaN` या `null` जैसे अपरिभाषित मान दर्शाते हैं कि खोज अगले स्तर पर जारी रहती है।

**जब कोई स्तर किसी प्रॉपर्टी को परिभाषित नहीं करता तो क्या होता है?**

Aspose.Slides उपयुक्त PowerPoint या लाइब्रेरी डिफ़ॉल्ट को हल करता है। वह हल किया गया मान प्रभावी डेटा में दिखाई देता है, भले ही कोई स्थानीय ऑब्जेक्ट स्पष्ट रूप से उसे परिभाषित न करता हो।

**कभी‑कभी प्रभावी मान स्थानीय मान के बराबर क्यों होता है?**

स्थानीय मान ने विरासत गणना जीत ली है। यह तब अपेक्षित है जब प्रॉपर्टी स्पष्ट रूप से ऑब्जेक्ट पर सेट हो और कोई अधिक विशिष्ट नियम उसे ओवरराइड न करे।

**कब मुझे स्थानीय डेटा की बजाय प्रभावी डेटा का उपयोग करना चाहिए?**

विशिष्ट फॉर्मेटिंग स्तर का निरीक्षण या संपादन करने के लिए स्थानीय डेटा का उपयोग करें। विरासत, थीम नियम, और लागू स्टाइल्स के हल होने के बाद अंतिम रूप चाहिए तो प्रभावी डेटा का उपयोग करें। [पूरा तुलना उदाहरण](#compare-local-inherited-and-effective-values) दोनों को समान वर्कफ़्लो में दर्शाता है।