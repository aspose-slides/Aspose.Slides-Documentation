---
title: जावास्क्रिप्ट में प्रस्तुति पाठ को स्वरूपित करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/nodejs-java/text-formatting/
keywords:
- पाठ हाइलाइट करें
- नियमित अभिव्यक्ति
- अनुच्छेद संरेखित करें
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घुमाव
- घुमाव कोण
- पाठ फ़्रेम
- लाइन स्पेसिंग
- ऑटॉफिट गुण
- पाठ फ़्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण आदि को अनुकूलित करें।
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को कैसे फॉर्मेट किया जाए। यह हाइलाइटिंग, पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घुमाव, अनुच्छेद अंतराल, ऑटोफिट व्यवहार, पाठ एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

नीचे दिए गए उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहले स्लाइड पर एकल टेक्स्ट बॉक्स है जिसमें निम्नलिखित पाठ है:

![नमूना पाठ](sample_text.png)

## **पाठ को हाइलाइट करें**

जब आपको टेक्स्ट फ़्रेम के भीतर किसी विशिष्ट नमूने से मेल खाने वाले पाठ को हाइलाइट करने की आवश्यकता हो, तो [TextFrame.highlightText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) विधि का उपयोग करें। इस विधि से मेल खाने वाले पाठ टुकड़ों पर हाइलाइट रंग लागू होता है और इसे [TextSearchOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/) के साथ उपयोग करके खोज का तरीका नियंत्रित किया जा सकता है, उदाहरण के लिए केवल पूर्ण शब्दों से मेल करने के लिए।

नीचे दिया गया कोड उदाहरण सभी पैटर्न **"try"** की घटनाओं को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है।

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // शेप में शब्द "try" को हाइलाइट करें।
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // शेप में शब्द "to" को हाइलाइट करें।
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![हाइलाइट किया गया पाठ](highlighted_text.png)

## **नियमित अभिव्यक्तियों का उपयोग करके पाठ को हाइलाइट करना**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) विधि नियमित अभिव्यक्ति द्वारा पाए गए पाठ मिलानों को हाइलाइट करती है। Node.js via Java में इस API को [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) पर एक्सपोज़ किया गया है।

नीचे दिया गया कोड उदाहरण सभी वे शब्द हाइलाइट करता है जिनमें **सात या अधिक अक्षर** होते हैं:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // सात या अधिक अक्षरों वाले सभी शब्दों को हाइलाइट करें।
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![नियमित अभिव्यक्ति का उपयोग करके हाइलाइट किया गया पाठ](highlighted_text_using_regex.png)

## **पाठ की पृष्ठभूमि रंग सेट करें**

पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने के लिए [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत टेक्स्ट हिस्सों के लिए [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) का उपयोग करें।

निम्नलिखित कोड उदाहरण पूरे **अनुच्छेद** के लिए पृष्ठभूमि रंग सेट करता है:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![धूसर अनुच्छेद](gray_paragraph.png)

निम्नलिखित कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के लिए पृष्ठभूमि रंग सेट करता है:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![धूसर पाठ भाग](gray_text_portions.png)

## **पाठ अनुच्छेदों को संरेखित करें**

टेक्स्ट फ़्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) का उपयोग करें। मान केंद्रित, बाएँ संरेखित, दाएँ संरेखित, समानांतर आदि हो सकते हैं।

निम्नलिखित कोड उदाहरण पैराग्राफ को **केंद्र** में संरेखित करता है:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ का संरेखण केंद्र में सेट करें।
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![संरेखित अनुच्छेद](aligned_paragraph.png)

## **पाठ की पारदर्शिता सेट करें**

पारदर्शिता को [PortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/#getFillFormat--) को असाइन किए गए रंग के अल्फा कंपोनेंट के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0‑255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

निम्नलिखित कोड उदाहरण पूरे **अनुच्छेद** पर पारदर्शिता लागू करता है:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // पाठ के फ़िल रंग को पारदर्शी रंग पर सेट करें।
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी अनुच्छेद](transparent_paragraph.png)

निम्नलिखित कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर पारदर्शिता लागू करता है:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // पाठ भाग की पारदर्शिता सेट करें।
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

![पारदर्शी पाठ भाग](transparent_text_portions.png)

## **पाठ के अक्षर अंतराल को सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को बढ़ाने या घटाने के लिए [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) का उपयोग करें।

निम्नलिखित JavaScript कोड पूरे **अनुच्छेद** के लिए अक्षर अंतराल बढ़ाता है:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतराल का विस्तार करें।

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![अनुच्छेद में अक्षर अंतराल](character_spacing_in_paragraph.png)

निम्नलिखित कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में अक्षर अंतराल बढ़ाता है:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
            portion.getPortionFormat().setSpacing(3); // अक्षर अंतराल का विस्तार करें।
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पाठ भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए कर्निंग अक्षम करें**

कभी‑कभी, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में प्रदर्शित समान पाठ से थोड़ा अधिक घनत्व वाला दिख सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए कर्निंग डेटा को नजरअंदाज कर सकता है, भले ही फ़ॉन्ट में वैध कर्निंग जानकारी हो और PowerPoint सेटिंग्स में कर्निंग सक्षम हो।

ऐसे मामलों में, आप उन टेक्स्ट भागों के लिए कर्निंग अक्षम कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यह सेटिंग मेल खाने वाले टेक्स्ट भागों पर कर्निंग लागू होने से रोकती है और Aspose.Slides के रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) के माध्यम से या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/) के माध्यम से सेट किया जा सकता है।

निम्नलिखित कोड पूरे अनुच्छेद के लिए फ़ॉन्ट और टेक्स्ट शैली सेट करता है: यह सभी भागों में फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन और Times New Roman फ़ॉन्ट लागू करता है।

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // अनुच्छेद के फ़ॉन्ट गुण सेट करें।
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

![अनुच्छेद के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्नलिखित कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर समान गुण लागू करता है:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![पाठ भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ घुमाव सेट करें**

टेक्स्ट को किसी आकार के भीतर पूर्वनिर्धारित अभिविन्यास सेट करने के लिए [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) का उपयोग करें।

निम्नलिखित कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को `Vertical270` पर सेट करता है, जो पाठ को **90 डिग्री घड़ी की विपरीत दिशा में** घुमा देता है:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पाठ घुमाव](text_rotation.png)

## **टेक्स्ट फ़्रेम्स के लिए कस्टम घुमाव सेट करें**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) का उपयोग करके आप किसी [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) के लिए कस्टम घुमाव कोण सेट कर सकते हैं।

निम्नलिखित कोड उदाहरण आकार के भीतर टेक्स्ट फ़्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![कस्टम टेक्स्ट घुमाव](custom_text_rotation.png)

## **अनुच्छेदों की लाइन स्पेसिंग सेट करें**

Aspose.Slides द्वारा प्रदान किए गए [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-), और [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) का उपयोग करके आप पैराग्राफ स्पेसिंग नियंत्रित कर सकते हैं। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट्स में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्नलिखित कोड उदाहरण पैराग्राफ के भीतर लाइन स्पेसिंग निर्दिष्ट करता है:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![अनुच्छेद के भीतर लाइन स्पेसिंग](line_spacing.png)

## **टेक्स्ट फ़्रेम्स के लिए ऑटोफिट प्रकार सेट करें**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) निर्धारित करता है कि जब पाठ अपने कंटेनर की सीमाओं से बाहर हो जाता है तो वह कैसे व्यवहार करता है। इसका उपयोग यह नियंत्रित करने के लिए किया जाता है कि पाठ छोटा हो, अधिक हो, या आकार स्वतः बदलता रहे।

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट फ़्रेम्स का एंकर सेट करें**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) आकार के भीतर टेक्स्ट को लंबवत रूप से कहाँ स्थित किया जाए, जैसे शीर्ष, मध्य या नीचे, इसे निर्धारित करता है।

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट टैबुलेशन सेट करें**

टैब स्टॉप को कॉन्फ़िगर करने के लिए [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) और [ParagraphFormat.getTabs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#getTabs--) का उपयोग करें।

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![अनुच्छेद टैब्स](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides द्वारा प्रदान किया गया [PortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) आपको टेक्स्ट भाग के लिए प्रूफिंग भाषा सेट करने की अनुमति देता है। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्नलिखित कोड उदाहरण टेक्स्ट भाग के लिए प्रूफिंग भाषा सेट करता है:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // प्रूफ़िंग भाषा का Id सेट करें।
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके आप प्रस्तुति लोड या बनाते समय बनाए गए पाठ की डिफ़ॉल्ट भाषा निर्धारित कर सकते हैं।

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // नई आयताकार आकृति को पाठ के साथ जोड़ें।
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

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) का उपयोग करें।

निम्नलिखित कोड उदाहरण नई प्रस्तुति में सभी स्लाइड्स के लिए 14 pt आकार का डिफ़ॉल्ट बोल्ड फ़ॉन्ट सेट करता है।

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // शीर्ष स्तर पैराग्राफ फ़ॉर्मेट प्राप्त करें।
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

## **ऑल-कैप्स प्रभाव के साथ पाठ निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से स्लाइड पर पाठ बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा पाठ भाग पुनः प्राप्त करते हैं, तो लाइब्रेरी पाठ को ठीक वैसे ही लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित पाठ से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textcaptype/) जांचें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में बदलें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![ऑल कैप्स प्रभाव](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण **All Caps** प्रभाव लागू किए गए पाठ को निकालता है:

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

**स्लाइड पर टेबल में पाठ को कैसे संशोधित करें?**

स्लाइड पर टेबल में पाठ को संशोधित करने के लिए, [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/table/) का उपयोग करें। सेल्स के माध्यम से इटररेट करें और प्रत्येक सेल को [Cell.getTextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/#getTextFrame--) तथा पैराग्राफ फ़ॉर्मेट को [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) के द्वारा अपडेट करें।

**PowerPoint स्लाइड में पाठ पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए, [PortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/#getFillFormat--) का उपयोग करें। [FillFormat.setFillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा और पारदर्शिता को कॉन्फ़िगर करें।