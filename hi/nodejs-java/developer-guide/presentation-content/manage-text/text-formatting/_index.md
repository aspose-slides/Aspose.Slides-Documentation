---
title: जावास्क्रिप्ट में प्रस्तुति टेक्स्ट को फ़ॉर्मेट करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/nodejs-java/text-formatting/
keywords:
- पैराग्राफ को संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घूर्णन
- घूर्णन कोण
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटॉफ़िट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और शैली दें। फ़ॉन्ट, रंग, संरेखण और अन्य विकल्पों को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को कैसे फॉर्मेट किया जाए। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटॉफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा न बताया गया हो, उदाहरण [sample.pptx](sample.pptx) का उपयोग करते हैं। पहले स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाया गया टेक्स्ट रखता है। दोनों स्लाइड और आकार इंडेक्स शून्य-आधारित हैं। वे उदाहरण जो बोल्ड भागों का चयन करते हैं प्रभावी फॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में मिला हुआ बोल्ड फॉर्मेटिंग शामिल है:

![उदाहरण टेक्स्ट](sample_text.png)

टेक्स्ट या रेगुलर-एक्सप्रेशन मिलान को खोजने और हाइलाइट करने के लिए देखें [पाठ खोजें और बदलें](/slides/hi/nodejs-java/search-and-replace-text/)।

## **टेक्स्ट पृष्ठभूमि रंग सेट करें**

एक पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) का उपयोग करें।

निम्नलिखित उदाहरण पहले पैराग्राफ के लिए डिफ़ॉल्ट रूप में हल्का ग्रे हाइलाइट सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ के पूरे भाग के लिए हाइलाइट रंग सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

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
            // टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें।
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

एक टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) का उपयोग करें। मान को केंद्रित, बाएँ-व्यवस्थित, दाएँ-व्यवस्थित, व्यवस्थित आदि किया जा सकता है।

निम्नलिखित कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ को केंद्र में संरेखित करें।
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **लाइन के भीतर फ़ॉन्ट संरेखित करें**

एक लाइन के भीतर विभिन्न फ़ॉन्ट आकारों के टेक्स्ट भागों को लंबवत संरेखित करने के लिए [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक पंक्तियों में संरेखण को नियंत्रित करती है।

निम्नलिखित स्वतंत्र उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36, और 54 पॉइंट पर समान पाठ होता है, लेकिन विभिन्न फ़ॉन्ट संरेखण के साथ। यह Arial का उपयोग करता है, ऑटॉफ़िट और रैपिंग को निष्क्रिय करता है, और टेक्स्ट फ्रेम को एक पंक्ति के लिए पर्याप्त बड़ा रखता है।

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

![मिश्रित फ़ॉन्ट आकारों के साथ बेसलाइन, टॉप, सेंटर, और बॉटम फ़ॉन्ट संरेखण की तुलना](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक्स का उपयोग करता है, इसलिए व्यक्तिगत अक्षरों के दृश्यमान किनारे आवश्यक रूप से बिल्कुल संरेखित नहीं होते। उदाहरण में एक बड़े अक्षर और एक नीचे उतरने वाला अक्षर शामिल है ताकि बेसलाइन और बॉटम संरेखण के बीच अंतर दिखाया जा सके। फ़ॉन्ट उपलब्धता और प्रतिस्थापन, उपयोग किए गए अक्षर, और फ़ॉन्ट आकार में अंतर परिणाम को प्रभावित करते हैं। फ्रेम आयाम, मार्जिन, लाइन स्पेसिंग, रैपिंग, और ऑटॉफ़िट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) से अलग है, जो क्षैतिज पैराग्राफ संरेखण को नियंत्रित करता है, और [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) से भी, जो टेक्स्ट ब्लॉक को उसके आकार के भीतर ऊर्ध्वाधर रूप से स्थित करता है। [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट फॉर्मेटिंग व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करती है, बजाय पैराग्राफ लाइनों के लिए फ़ॉन्ट संरेखण सेट करने के।

## **टेक्स्ट के लिए पारदर्शिता सेट करें**

टेक्स्ट की पारदर्शिता [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat) को सौंपे गए रंग के अल्फा घटक के माध्यम से नियंत्रित की जाती है। नीचे दिए गए उदाहरणों में, `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर पारदर्शिता कैसे लागू की जाए:

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

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्नलिखित कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर पारदर्शिता कैसे लागू की जाए:

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

![पारदर्शी टेक्स्ट भाग](transparent_text_portions.png)

## **टेक्स्ट के लिए अक्षर अंतराल सेट करें**

[BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) का उपयोग करके टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को बढ़ाया या घटाया जा सकता है। उदाहरण 3 पॉइंट का अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को घटाते हैं।

निम्न JavaScript कोड दिखाता है कि **पूरे पैराग्राफ** में अक्षर अंतराल को कैसे बढ़ाया जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतराल को विस्तारित करें।

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में अक्षर अंतराल को कैसे बढ़ाया जाए:

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
            // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            portion.getPortionFormat().setSpacing(3); // अक्षर अंतराल को विस्तारित करें।
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग निष्क्रिय करें**

कभी-कभी, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए समान टेक्स्ट की तुलना में थोड़ा अधिक टाइट दिख सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर किए गए आउटपुट को PowerPoint के समान बनाने के लिए, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले टेक्स्ट भागों के लिए केरनिंग निष्क्रिय कर सकते हैं। इसके लिए [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। यह उदाहरण "presentation.pptx" के first slide पर first shape के रूप में टेक्स्ट बॉक्स की आवश्यकता रखता है। यह प्रभावी फ़ॉन्ट नामों की जाँच करता है, जिसमें विरासत में मिला फ़ॉन्ट भी शामिल है, और Roboto उपयोग करने वाले भागों के लिए 100 पॉइंट थ्रेशोल्ड सेट करता है। यह मिलते जुलते भागों के लिए, जिनका फ़ॉन्ट आकार 100 पॉइंट से नीचे है, केरनिंग को निष्क्रिय करता है:

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

थ्रेशोल्ड से नीचे के मिलते टेक्स्ट के लिए, यह सेटिंग केरनिंग को रोकता है और इससे उस फ़ॉन्ट के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ मिलाने में मदद मिल सकती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) के माध्यम से या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न उदाहरण पहले पैराग्राफ का डिफ़ॉल्ट फ़ॉन्ट 12 पॉइंट Times New Roman सेट करता है, जिसमें बोल्ड, इटैलिक और डॉटेड अंडरलाइन फॉर्मेटिंग है। व्यक्तिगत भागों पर स्पष्ट फॉर्मेटिंग इन डिफ़ॉल्ट्स पर प्राथमिकता लेती है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें।
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

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण 13 पॉइंट Times New Roman, इटैलिक फॉर्मेटिंग, और डॉटेड अंडरलाइन को उन भागों पर लागू करता है जिनकी प्रभावी फॉर्मेटिंग बोल्ड है:

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

            // टेक्स्ट भाग के लिए फ़ॉन्ट गुण सेट करें।
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

![टेक्स्ट भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट ऊँचाई सामान्यीकरण नियंत्रित करें**

[BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) का उपयोग टेम्पलेट टाइपोग्राफी को पुन: उत्पन्न करने या अक्षर ऊँचाई में अंतर की जाँच करने के लिए किया जाता है। PowerPoint में, सामान्यीकरण को सक्षम करने से व्यक्तिगत अक्षर ऊर्ध्वाधर रूप से खिंचे या संकुचित होते हैं ताकि वे टेक्स्ट भाग के भीतर समान दृश्यमान ऊँचाई प्राप्त करें। यह विभिन्न फ़ॉन्ट्स में समान टेक्स्ट ऊँचाई की गारंटी नहीं देता।

इस प्रॉपर्टी को [NullableBool.True या False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) पर सेट करके स्पष्ट रूप से सामान्यीकरण को सक्षम या निष्क्रिय किया जा सकता है। `NullableBool.NotDefined` स्थानीय सेटिंग को अनसेट छोड़ देता है ताकि भाग पैराग्राफ के [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) से इसका मान विरासत में ले। इसका अर्थ `False` नहीं है।

[PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) का उपयोग करें और [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) पढ़ें ताकि रिज़ॉल्व्ड बूलियन मान प्राप्त हो सके।

निम्न स्वतंत्र उदाहरण को **Arial** स्थापित होने की आवश्यकता है। यह दो टेक्स्ट ब्लॉक बनाता है जिनमें समान बड़े अक्षर, छोटे अक्षर, नीचे उतरने वाले अक्षर, और 54 पॉइंट पर उच्चारित अक्षर होते हैं। दोनों पैराग्राफ डिफ़ॉल्ट रूप में सामान्यीकरण को सक्षम करते हैं। ऊपर वाला भाग स्पष्ट रूप से इसे निष्क्रिय करता है; नीचे वाला भाग इसे विरासत में लेता है। फ्रेम आकार, मार्जिन और पैराग्राफ स्पेसिंग समान हैं, और तुलना को सुसंगत रखने के लिए रैपिंग और ऑटॉफ़िट निष्क्रिय हैं। उदाहरण `False: false` और `NotDefined: true` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

नीचे की तुलना सहेजी गई प्रस्तुति से निर्यात की गई है। शीर्ष पंक्ति में सामान्यीकरण निष्क्रिय (`False`) है; निचली पंक्ति में सक्षम सेटिंग (`NotDefined` → `True`) विरासत में मिलती है। इस दिखावट को फिर से प्राप्त करने के लिए Arial स्थापित रखें।

![नॉर्मलाइज़ेशन निष्क्रिय ऊपर और विरासत में मिला नॉर्मलाइज़ेशन सक्षम नीचे के साथ Arial 54 पॉइंट टेक्स्ट](text_height_normalization.png)

नॉर्मलाइज़ेशन अक्षर की ऊँचाई को बदलता है बिना असाइन किए गए [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight) मान को बदले, जो फ़ॉन्ट आकार पॉइंट में निर्दिष्ट करता है। पैराग्राफ का [setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) लाइन स्पेसिंग को नियंत्रित करता है, जबकि टेक्स्ट-फ़्रेम का [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) यह नियंत्रित करता है कि टेक्स्ट या उसका कंटेनर फिट होने के लिए कैसे समायोजित होता है। ये सेटिंग्स अलग-अलग उद्देश्यों की सेवा करती हैं और कुल लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। पैराग्राफ फॉर्मेटिंग और विरासत पर अधिक जानकारी के लिए देखें [Manage Paragraph](/slides/hi/nodejs-java/manage-paragraph/)।

## **स्ट्राइकथ्रु लागू करें और हटाएँ**

[BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) का उपयोग करके टेक्स्ट भाग पर स्ट्राइकथ्रु लागू किया जा सकता है, जिससे संशोधन, रद्द शब्द या पूर्व कीमतें दिखाई जा सकती हैं बिना मूल टेक्स्ट को हटाए। इसे [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) पर सेट करके टेक्स्ट पर एक या दो रेखाएँ लगाई जा सकती हैं।

स्ट्राइकथ्रु हटाने के लिए, [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None) पास करें। यह प्रभाव को स्पष्ट रूप से निष्क्रिय करता है, भले ही आसपास की फॉर्मेटिंग स्ट्राइकथ्रु निर्दिष्ट करे। इसके विपरीत, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) स्थानीय सेटिंग को अनपरिभाषित छोड़ देता है, जिससे भाग पैराग्राफ आदि से फॉर्मेटिंग विरासत में ले सकता है। यह गारंटी नहीं देता कि स्ट्राइकथ्रु हट गया है। परिणामस्वरूप फॉर्मेटिंग, जिसमें विरासत मान शामिल हैं, पढ़ने के लिए [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) का उपयोग करें।

निम्न स्वतंत्र उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पूर्व कीमत, और वर्तमान कीमत के लिए अलग-अलग भाग होते हैं, इसलिए केवल पूर्व कीमत प्रभावित होती है। पहली पंक्ति स्ट्राइकथ्रु लागू करती है और फिर हटाती है; अन्य पंक्तियाँ क्रमशः सिंगल और डबल स्ट्राइकथ्रु रखती हैं। इस सेटिंग को बदलने से टेक्स्ट और उसके अन्य फॉर्मेटिंग, जिसमें बोल्ड पूर्व कीमत शामिल है, संरक्षित रहती है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // स्ट्राइकथ्रु लागू करें, फिर पहले पिछले मूल्य से इसे स्पष्ट रूप से हटाएँ।
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम, ऊपर से नीचे: कोई स्ट्राइकथ्रु नहीं, सिंगल स्ट्राइकथ्रु, और डबल स्ट्राइकथ्रु।

![स्ट्राइकथ्रु बिना पिछले कीमतें, सिंगल स्ट्राइकथ्रु के साथ, और डबल स्ट्राइकथ्रु के साथ](strikethrough.png)

## **टेक्स्ट घूर्णन सेट करें**

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) का उपयोग करके आकार के भीतर एक पूर्व निर्धारित टेक्स्ट ओरिएंटेशन सेट किया जा सकता है।

निम्न कोड उदाहरण आकार में टेक्स्ट ओरिएंटेशन को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री घड़ी की दिशा के विपरीत** घुमाता है:

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

![टेक्स्ट घूर्णन](text_rotation.png)

## **ऊर्ध्वाधर टेक्स्ट में अंक को साइड बाय साइड दिखाएँ**

ऊर्ध्वाधर जापानी लेबल में दो-अंकीय संख्या को साथ रखने के लिए, दोनों अंकों को एक टेक्स्ट भाग में रखें और उस भाग की फॉर्मेटिंग पर [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKumimoji) कॉल करें। उदाहरण में [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/#EastAsianVertical) और 40 पॉइंट MS Gothic दोनों लेबलों के लिए उपयोग किए जाते हैं। केवल संख्यात्मक भाग को पास किया गया [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) मान अलग है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const font = new aspose.slides.FontData("MS Gothic");
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const settings = [aspose.slides.NullableBool.True, aspose.slides.NullableBool.False];
    let x = 120;

    for (const kumimoji of settings) {
        const label = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.EastAsianVertical));

        const paragraph = frame.getParagraphs().get_Item(0);
        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const digits = new aspose.slides.Portion("12");
        digits.getPortionFormat().setKumimoji(java.newByte(kumimoji));

        const portions = paragraph.getPortions();
        portions.clear();
        portions.add(new aspose.slides.Portion("令和"));
        portions.add(digits);
        portions.add(new aspose.slides.Portion("年"));
        x += 240;
    }
    presentation.save("vertical_date.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint में, बायाँ लेबल (`True`) अंक को सीधा और 和 और 年 के बीच साइड बाय साइड दिखाता है। दायाँ लेबल (`False`) में, अंक 90 डिग्री घड़ी की दिशा में घुमे हुए हैं। दोनों लेबलों में आसपास के जापानी अक्षर सीधे रहते हैं।

![ऊर्ध्वाधर तिथि लेबल की PowerPoint तुलना, बाएँ में सीधे अंक और दाएँ में घुमा हुए अंक](vertical_date.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) का उपयोग करके [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) के लिए कस्टम घूर्णन एंगल सेट किया जा सकता है।

नीचे दिया गया कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

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

![कस्टम टेक्स्ट घूर्णन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore), और [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) प्रदान करता है ताकि पैराग्राफ स्पेसिंग नियंत्रित की जा सके। इन प्रॉपर्टीज़ का उपयोग इस प्रकार किया जाता है:

* सकारात्मक मान का उपयोग करके लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करें।  
* नकारात्मक मान का उपयोग करके लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करें।

निम्न उदाहरण पहले पैराग्राफ के भीतर स्पेसिंग को लाइन की ऊँचाई के 200% (डबल स्पेसिंग) पर सेट करता है:

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

पैराग्राफ लाइन-ब्रेकिंग नियम संकरी टेक्स्ट ब्लॉक्स और उन प्रस्तुतियों में उपयोगी होते हैं जो लैटिन और पूर्वी एशियाई टेक्स्ट को मिश्रित करती हैं। निम्न विधियाँ [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/) से आती हैं, इसलिए वे पूरे पैराग्राफ पर लागू होती हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) लैटिन लाइन-ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित टेक्स्ट में, इसे बदलने से ईस्ट एशियन टेक्स्ट और विराम चिह्नों के रैपिंग स्थान भी बदल सकते हैं।  
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ईस्ट एशियन लाइन-ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग सक्षम करता है। ये लेआउट को प्रभावित करते हैं जब रैपिंग होती है; वे लाइन-ब्रेक कैरेक्टर जोड़ते नहीं हैं। एक स्पष्ट लाइन ब्रेक पैराग्राफ के भीतर उपलब्ध चौड़ाई से स्वतंत्र रूप से नई पंक्ति बनाता है।

निम्न स्वतंत्र उदाहरण एक संकरी टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन टेक्स्ट शामिल है। यह दोनों लाइन-ब्रेकिंग विकल्पों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम को आज़माने के लिए, अन्य सेटिंग को स्थिर रखते हुए सम्बंधित मान बदलें। उदाहरण 24 पॉइंट Arial और SimSun का उपयोग करता है, 160 पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट-फ़्रेम मार्जिन के साथ। [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) को [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) के साथ कॉल किया गया है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

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

## **हैंगिंग पंक्चर कंट्रोल करें**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) योग्य विराम चिह्नों को टेक्स्ट लाइन के दाएँ किनारे से बाहर विस्तारित बनने देता है, बजाय अगले लाइन में जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्वतंत्र उदाहरण 100 पॉइंट चौड़ाई वाले टेक्स्ट फ्रेम में हैंगिंग पंक्चर को सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24 पॉइंट Arial और शून्य क्षैतिज टेक्स्ट-फ़्रेम मार्जिन के साथ, अंतिम डॉट "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर विस्तारित होता है। तुलना के लिए प्रॉपर्टी को [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ, डॉट एक अलग लाइन लेता है। रैपिंग सक्षम है और ऑटॉफ़िट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिह्न नहीं लटक सकता। ऊपर वर्णित [फ़ॉन्ट और लेआउट स्थितियों](#control-line-breaking) इस तुलना पर भी लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन, या ऑटॉफ़िट सेटिंग्स बदलने से दृश्यमान अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटॉफ़िट प्रकार सेट करें**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) निर्धारित करता है कि कंटेनर की सीमाओं से अधिक होने पर टेक्स्ट कैसे व्यवहार करता है। इसका उपयोग यह नियंत्रित करने के लिए किया जाता है कि टेक्स्ट सिकुड़े, ओवरफ़्लो करे, या आकार को स्वतः री‑साइज़ करे। निम्न उदाहरण आकार को उसके टेक्स्ट के अनुसार री‑साइज़ करने के लिए कॉन्फ़िगर करता है और परिणाम "autofit_type.pptx" में सहेजता है।

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

ऑटोमैटिक रैपिंग के बाद लाइनों की गिनती करने और यह देखने के लिए कि टेक्स्ट या आकार की चौड़ाई परिणाम को कैसे बदलती है, देखें [Count Rendered Lines](/slides/hi/nodejs-java/manage-paragraph/). केवल लाइनों की गिनती यह नहीं बताती कि टेक्स्ट कंटेनर से ओवरफ़्लो हो रहा है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) निर्धारित करता है कि टेक्स्ट आकार के भीतर ऊर्ध्वाधर रूप से कहाँ स्थित है, जैसे शीर्ष, मध्य, या नीचे। निम्न उदाहरण टेक्स्ट को पहले आकार के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

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

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) और [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) का उपयोग करके पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑व्यवस्थित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

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

![पैराग्राफ टैब](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) प्रदान करता है, जो टेक्स्ट भाग के लिए प्रूफिंग भाषा सेट करने की अनुमति देता है। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

यह उदाहरण "presentation.pptx" की आवश्यकता रखता है, जिसमें पहले स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स हो और कम से कम एक पैराग्राफ हो। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और सरल चीनी प्रूफिंग भाषा (`zh-CN`) असाइन करता है। यह परिणाम "proofing_language.pptx" में सहेजता है।

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

### **भाषा मेटाडेटा कॉपी करें**

टेम्प्लेट से बहुभाषी टेक्स्ट कॉपी करते समय, दोनों [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) और [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) को संरक्षित रखें। निम्न स्वतंत्र उदाहरण एक स्रोत भाग बनाता है जिसमें भाषा US English और वैकल्पिक भाषा French है, और टेक्स्ट तथा पहचानकर्ताओं को नई प्रस्तुति के एक भाग में कॉपी करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // यदि स्रोत में वैकल्पिक भाषा नहीं है, तो null गंतव्य मान को साफ़ करता है।
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

एक स्रोत को वैकल्पिक भाषा के बिना आज़माने के लिए, `"fr-FR"` असाइनमेंट को छोड़ें। वैकल्पिक पहचानकर्ता तब `null` होगा, और वही कॉपी स्टेटमेंट उसकी अनुपस्थिति को संरक्षित करेगा बिना डिफ़ॉल्ट मान दिया, भले ही गंतव्य में पहले वैकल्पिक भाषा असाइन की गई हो।

ये पहचानकर्ता भाषा मेटाडेटा के रूप में संग्रहीत होते हैं। इन्हें संरक्षित करने से यह स्थापित नहीं होता कि PowerPoint वर्तनी या व्याकरण जांच के लिए कौन‑सा शब्दकोश चुनता है।

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करके प्रस्तुति लोड या बनाते समय बनाए गए टेक्स्ट की डिफ़ॉल्ट भाषा निर्धारित करें। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के साथ प्रस्तुति बनाता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिए `en-US` प्रिंट करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // एक नया आयताकार आकार और टेक्स्ट जोड़ें।
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // पहले भाग की भाषा जांचें।
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए, [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle) का उपयोग करें। निम्न उदाहरण नई प्रस्तुति में शीर्ष स्तर के पैराग्राफ के लिए डिफ़ॉल्ट रूप में 14 पॉइंट बोल्ड फ़ॉन्ट सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है, जब तक कि अधिक विशिष्ट फॉर्मेटिंग उन्हें ओवरराइड न करे।

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

## **ऑल‑कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट भाग पुनः प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को बिल्कुल उसी रूप में लौटाती है जैसे वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) को जांचें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है, जिसमें पहले स्लाइड पर पहला आकार टेक्स्ट बॉक्स हो। उसका पहला पैराग्राफ का पहला भाग "Hello, Aspose!" को All Caps इफ़ेक्ट के साथ रखता है, जैसा कि नीचे दिखाया गया है।

![ऑल कैप्स इफ़ेक्ट](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **All Caps** इफ़ेक्ट लागू किए हुए टेक्स्ट को कैसे निकाला जाए:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड पर तालिका में टेक्स्ट को कैसे संशोधित करूँ?**

स्लाइड पर तालिका में टेक्स्ट संशोधित करने के लिए, [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) का उपयोग करें। सेल्स के माध्यम से इटररेट करें और प्रत्येक सेल को [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) और पैराग्राफ फ़ॉर्मेटिंग को [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat) के माध्यम से अपडेट करें।

**मैं PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए, [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat) का उपयोग करें। [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) को [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, और पारदर्शिता को कॉन्फ़िगर करें।