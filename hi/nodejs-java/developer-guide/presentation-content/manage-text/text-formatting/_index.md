---
title: JavaScript में प्रस्तुति टेक्स्ट स्वरूपित करें
linktitle: टेक्स्ट स्वरूपण
type: docs
weight: 50
url: /hi/nodejs-java/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घूर्णन
- घूर्णन कोण
- टेक्स्ट फ्रेम
- लाइन अंतराल
- ऑटॉफिट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को स्वरूपित और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण आदि को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को कैसे फॉर्मेट किया जाए। यह बैकग्राउंड रंग, ट्रांसपैरेंसी, कैरेक्टर स्पेसिंग, फ़ॉन्ट प्रॉपर्टीज़, रोटेशन, पैराग्राफ स्पेसिंग, ऑटोफिट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप्स, और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा नहीं कहा गया हो, उदाहरण [sample.pptx](sample.pptx) का उपयोग करते हैं। उसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए टेक्स्ट को शामिल करता है। दोनों स्लाइड और आकार के इंडेक्स शून्य-आधारित हैं। जो उदाहरण बोल्ड भागों को चुनते हैं, वे प्रभावी फॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में मिला बोल्ड फॉर्मेटिंग शामिल है:

![नमूना पाठ](sample_text.png)

टेक्स्ट खोजें और बदलें के लिए देखें [टेक्स्ट खोजें और बदलें](/slides/hi/nodejs-java/search-and-replace-text/).

## **टेक्स्ट बैकग्राउंड रंग सेट करें**

डिफ़ॉल्ट पैरा के लिए डिफ़ॉल्ट हाईलाइट रंग सेट करने हेतु [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए हल्का ग्रे हाईलाइट को डिफ़ॉल्ट रूप में सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाईलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता रखते हैं:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पूरे पैराग्राफ के लिए हाईलाइट रंग सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के लिए बैकग्राउंड रंग सेट करने का प्रदर्शन करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // टेक्स्ट भाग के लिए हाईलाइट रंग सेट करें।
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ग्रे टेक्स्ट भाग](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ संरेखित करें**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) का उपयोग करके टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करें। मान केंद्रित, बाएँ संरेखित, दाएँ संरेखित, जस्टिफाइड आदि हो सकता है।

निम्न कोड उदाहरण दर्शाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ की संरेखण को केंद्र में सेट करें।
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **एक लाइन में फ़ॉन्ट संरेखित करें**

[ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment-int-) का उपयोग करके एक लाइन में विभिन्न फ़ॉन्ट आकार के टेक्स्ट भागों को ऊर्ध्वाधर रूप से संरेखित करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक पंक्ति के भीतर संरेखण को नियंत्रित करती है।

निम्न स्व-निहित उदाहरण एक स्लाइड पर चार लेबलयुक्त टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में समान टेक्स्ट 18, 36, और 54 पॉइंट पर होता है, विभिन्न फ़ॉन्ट संरेखण के साथ। यह Arial उपयोग करता है, ऑटोफिट और रैपिंग को निष्क्रिय करता है, और टेक्स्ट फ्रेम को एक लाइনের लिए पर्याप्त बड़ा रखता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![मिक्स्ड फ़ॉन्ट आकार के साथ बेसलाइन, टॉप, सेंटर और बॉटम फ़ॉन्ट संरेखण की तुलना](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक का उपयोग करता है, इसलिए व्यक्तिगत अक्षरों के दृश्य किनारे जरूरी नहीं कि बिल्कुल मिलें। यह उदाहरण एक अपरकेस अक्षर और एक डिसेंडर दोनों शामिल करता है ताकि बेसलाइन और बॉटम संरेखण के अंतर को दिखाया जा सके। फ़ॉन्ट उपलब्धता और प्रतिस्थापन, उपयोग किए गए अक्षर, और फ़ॉन्ट आकार में अंतर परिणाम को प्रभावित करते हैं। फ्रेम आयाम, मार्जिन, लाइन स्पेसिंग, रैपिंग, और ऑटोफिट भी लेआउट को प्रभावित करते हैं; मॉड्स की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स उपयोग करें।

यह सेटिंग [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) से अलग है, जो क्षैतिज पैराग्राफ संरेखण को नियंत्रित करता है, और [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) से अलग है, जो आकार के भीतर टेक्स्ट ब्लॉक को लंबवत स्थित करता है। [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement-float-) के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट फॉर्मेटिंग व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करती है, न कि पैराग्राफ की लाइनों के लिए फ़ॉन्ट संरेखण सेट करती।

## **टेक्स्ट के लिए ट्रांसपैरेंसी सेट करें**

टेक्स्ट ट्रांसपैरेंसी को [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) को सौंपे गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` ARGB अल्फा-चैनल मान 0–255 स्केल पर है, न कि ट्रांसपैरेंसी प्रतिशत।

नीचे दिया गया कोड उदाहरण दिखाता है कि कैसे **पूरे पैराग्राफ** पर ट्रांसपैरेंसी लागू की जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // टेक्स्ट के भराव रंग को पारदर्शी रंग पर सेट करें।
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ट्रांसपेरेंट पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि कैसे **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर ट्रांसपैरेंसी लागू की जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // टेक्स्ट भाग की पारदर्शिता सेट करें।
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ट्रांसपेरेंट टेक्स्ट भाग](transparent_text_portions.png)

## **टेक्स्ट के लिए कैरेक्टर स्पेसिंग सेट करें**

[BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) का उपयोग करके टेक्स्ट बॉक्स में अक्षरों के बीच स्पेसिंग को बढ़ाया या घटाया जा सकता है। उदाहरण 3 पॉइंट की स्पेसिंग जोड़ते हैं; नकारात्मक मान टेक्स्ट को संकुचित करते हैं।

निम्न JavaScript कोड दिखाता है कि कैसे **पूरे पैराग्राफ** में कैरेक्टर स्पेसिंग बढ़ाई जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // नोट: अक्षर स्पेसिंग को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर स्पेसिंग बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ में कैरेक्टर स्पेसिंग](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि कैसे **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में कैरेक्टर स्पेसिंग बढ़ाई जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // नोट: अक्षर स्पेसिंग को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
            portion.getPortionFormat().setSpacing(3); // अक्षर स्पेसिंग बढ़ाएँ।
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टेक्स्ट भागों में कैरेक्टर स्पेसिंग](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केर्निंग अक्षम करें**

कभी-कभी, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए समान टेक्स्ट से थोड़ा अधिक टाइट लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केर्निंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केर्निंग जानकारी हो और PowerPoint सेटिंग्स में केर्निंग सक्रिय हो।

ऐसे मामलों में रेंडर किए गए आउटपुट को PowerPoint के करीब लाने के लिए, आप प्रभावित फ़ॉन्ट के उपयोग वाले टेक्स्ट भागों के लिए केर्निंग अक्षम कर सकते हैं। [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। इस उदाहरण को पहली स्लाइड के पहले आकार पर टेक्स्ट बॉक्स वाले "presentation.pptx" की आवश्यकता है। यह प्रभावी फ़ॉन्ट नामों (विरासत में मिले फ़ॉन्ट सहित) जाँचता है और Roboto उपयोग करने वाले भागों के लिए 100 पॉइंट थ्रेशोल्ड सेट करता है। यह 100 पॉइंट से कम फ़ॉन्ट आकार वाले मिलते-जुलते भागों के लिए केर्निंग अक्षम करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

थ्रेशोल्ड से नीचे के मिलते-जुलते टेक्स्ट के लिए, यह सेटिंग केर्निंग को रोकती है और इस PowerPoint-विशिष्ट व्यवहार से प्रभावित फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के विज़ुअल आउटपुट के साथ संरेखित करने में मदद कर सकती है।

## **टेक्स्ट फ़ॉन्ट प्रॉपर्टीज़ प्रबंधित करें**

फ़ॉन्ट प्रॉपर्टीज़ को पैराग्राफ स्तर पर [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) द्वारा या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) द्वारा सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12-पॉइंट Times New Roman, बोल्ड, इटैलिक, और डॉटेड अंडरलाइन फॉर्मेटिंग के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट फॉर्मेटिंग इन डिफ़ॉल्ट्स पर प्राथमिकता रखती है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // पैराग्राफ की फ़ॉन्ट प्रॉपर्टीज़ सेट करें।
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ के फ़ॉन्ट प्रॉपर्टीज़](font_properties_for_paragraph.png)

निम्न उदाहरण 13-पॉइंट Times New Roman, इटैलिक फॉर्मेटिंग, और डॉटेड अंडरलाइन को उन भागों पर लागू करता है जिनकी प्रभावी फॉर्मेटिंग बोल्ड है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // टेक्स्ट भाग के लिए फ़ॉन्ट प्रॉपर्टीज़ सेट करें।
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टेक्स्ट भागों के फ़ॉन्ट प्रॉपर्टीज़](font_properties_for_text_portions.png)

## **टेक्स्ट रोटेशन सेट करें**

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) का उपयोग करके आकार के भीतर प्री-डिफाइंड टेक्स्ट ओरिएंटेशन सेट किया जा सकता है।

निम्न कोड उदाहरण आकार में टेक्स्ट ओरिएंटेशन को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिक्लॉकवाइज** घुमाता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टेक्स्ट रोटेशन](text_rotation.png)

## **टेक्स्ट फ्रेम्स के लिए कस्टम रोटेशन सेट करें**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) का उपयोग करके एक [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) के लिए कस्टम रोटेशन एंगल सेट किया जा सकता है।

नीचे दिया गया कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइज घुमाता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![कस्टम टेक्स्ट रोटेशन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-), और [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) प्रदान करता है ताकि पैराग्राफ स्पेसिंग को नियंत्रित किया जा सके। इन प्रॉपर्टीज़ का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के भीतर स्पेसिंग को लाइन ऊँचाई के 200% (डबल स्पेसिंग) पर सेट करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **लाइन ब्रेकिंग नियंत्रित करें**

पैराग्राफ लाइन-ब्रेकिंग नियम संकीर्ण टेक्स्ट ब्लॉक्स और लैटिन तथा ईस्ट एशियन टेक्स्ट मिश्रित प्रस्तुतियों में उपयोगी होते हैं। निम्न मेथड्स [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) लैटिन लाइन-ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित टेक्स्ट में, इसे बदलने से पास के ईस्ट एशियन टेक्स्ट और विराम चिह्नों का रैप भी बदल सकता है।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) ईस्ट एशियन लाइन-ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल है।

ये नियम [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। वे रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन-ब्रेक कैरेक्टर नहीं डालते। एक स्पष्ट लाइन ब्रेक उपलब्ध चौड़ाई से स्वतंत्र रूप से पैराग्राफ के भीतर नई पंक्ति बनाता है।

निम्न स्व-निहित उदाहरण चीनी और लैटिन टेक्स्ट वाला संकीर्ण टेक्स्ट ब्लॉक बनाता है। यह दोनों लाइन-ब्रेकिंग विकल्पों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम के साथ प्रयोग करने के लिए, अन्य सेटिंग को स्थिर रखते हुए संबंधित मान बदलें। उदाहरण 24-पॉइंट Arial और SimSun का उपयोग 160-पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट-फ़्रेम मार्जिन के साथ करता है। [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) को [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) के साथ बुलाया जाता है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **हैंगिंग पंक्चुएशन नियंत्रित करें**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) पात्र विराम चिह्नों को टेक्स्ट लाइन के दाएँ किनारे से बाहर तक विस्तार करने देता है, बजाय अगले लाइन में जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्व-निहित उदाहरण 100-पॉइंट चौड़े टेक्स्ट फ्रेम में हैंगिंग पंक्चुएशन सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24-पॉइंट Arial और शून्य क्षैतिज टेक्स्ट-फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर तक विस्तारित होता है। तुलना के लिए प्रॉपर्टी को [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ बिंदु अलग लाइन ले लेता है। रैपिंग सक्षम है और ऑटोफिट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सभी विराम चिह्न हैंग नहीं कर सकते। ऊपर वर्णित [फ़ॉन्ट और लेआउट शर्तें](#control-line-breaking) भी इस तुलना पर लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन, या ऑटोफिट सेटिंग्स बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ्रेम्स के लिए ऑटोफिट टाइप सेट करें**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) निर्धारित करता है कि कंटेनर की सीमाओं से टेक्ट्स बाहर निकलने पर टेक्स्ट कैसे व्यवहार करता है। इसका उपयोग करके तय किया जा सकता है कि टेक्स्ट छोटा हो, ओवरफ़्लो करे, या आकार को स्वचालित रूप से रिसाइज़ करे। निम्न उदाहरण आकार को उसके टेक्स्ट के अनुसार रिसाइज़ करने के लिए कॉन्फ़िगर करता है और परिणाम "autofit_type.pptx" में सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

स्वचालित रैपिंग के बाद लाइनों की गिनती करने और देखे कि टेक्स्ट या आकार की चौड़ाई परिणाम को कैसे बदलती है, के लिए देखें [Count Rendered Lines](/slides/hi/nodejs-java/manage-paragraph/)। केवल लाइनों की संख्या यह नहीं दर्शाती कि टेक्स्ट कंटेनर से बाहर निकलता है या नहीं।

## **टेक्स्ट फ्रेम्स का एंकर सेट करें**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) यह निर्धारित करता है कि टेक्स्ट आकार के भीतर लंबवत कैसे स्थित है, जैसे शीर्ष, मध्य या निचला। निम्न उदाहरण टेक्स्ट को पहले आकार के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट टैबुलेशन सेट करें**

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) और [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs--) का उपयोग करके पैराग्राफ में टैब स्टॉप कॉन्फ़िगर किए जा सकते हैं। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट सेट करता है और 30 पॉइंट पर बाएँ संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) प्रदान करता है, जो टेक्स्ट भाग के लिए प्रूफिंग भाषा सेट करने की अनुमति देता है। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न उदाहरण को "presentation.pptx" चाहिए, जिसमें पहली स्लाइड के पहले आकार पर टेक्स्ट बॉक्स और कम से कम एक पैराग्राफ हो। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और सरलित चीनी प्रूफिंग भाषा (`zh-CN`) असाइन करता है। यह परिणाम "proofing_language.pptx" में सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // प्रूफिंग भाषा का Id सेट करें।
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके लोड या बनाते समय निर्मित टेक्स्ट के लिए डिफ़ॉल्ट भाषा परिभाषित की जा सकती है। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के साथ एक प्रस्तुति बनाता है, टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिए `en-US` प्रिंट करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // एक नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // पहले भाग की भाषा जाँचें।
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रेजेंटेशन स्तर पर डिफ़ॉल्ट टेक्स्ट फॉर्मेटिंग लागू करने के लिए, [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) का उपयोग करें।

निम्न उदाहरण 14-पॉइंट बोल्ड फ़ॉन्ट को नई प्रस्तुति के टॉप-लेवल पैराग्राफ़ के लिए डिफ़ॉल्ट सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फॉर्मेटिंग उन्हें ओवरराइड न करे।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // शीर्ष स्तर पैराग्राफ फॉर्मेट प्राप्त करें।
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ऑल-कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर अपरकेस दिखता है, चाहे वह मूल रूप से लोअरकेस में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को ठीक वैसा ही लौटाती है जैसा वह दर्ज किया गया था। दिखाए गए टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) जांचें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में बदलें।

यह उदाहरण "sample2.pptx" चाहता है, जिसमें पहली स्लाइड के पहले आकार पर टेक्स्ट बॉक्स हो। इसके पहले पैराग्राफ के पहले भाग में "Hello, Aspose!" All Caps प्रभाव के साथ है, जैसा कि नीचे दिखाया गया है।

![ऑल कैप्स प्रभाव](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **All Caps** प्रभाव के साथ टेक्स्ट को कैसे निकाला जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

आउटपुट:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**स्लाइड पर टेबल में टेक्स्ट कैसे संशोधित करें?**

स्लाइड पर टेबल में टेक्स्ट संशोधित करने के लिए, [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) का उपयोग करें। सेल्स पर इटरनेट करें और प्रत्येक सेल को [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) और पैराग्राफ फॉर्मेटिंग को [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करें?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए, [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) का उपयोग करें। [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशा, और ट्रांसपैरेंसी कॉन्फ़िगर करें।