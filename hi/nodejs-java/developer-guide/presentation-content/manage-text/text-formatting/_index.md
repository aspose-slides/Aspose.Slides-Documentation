---
title: जावास्क्रिप्ट में प्रस्तुति पाठ को स्वरूपित करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/nodejs-java/text-formatting/
keywords:
- अनुच्छेद संरेखण
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घुमाव
- घुमाव कोण
- टेक्स्ट फ्रेम
- पंक्ति अंतराल
- ऑटॉफ़िट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण आदि को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख दर्शाता है कि Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को कैसे स्वरूपित किया जाए। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घुमाव, अनुच्छेद स्पेसिंग, ऑटॉफ़िट व्यवहार, पाठ एंकरिंग, टैब स्टॉप, और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा न बताया गया हो, उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया गया है। पहले स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसके पहले अनुच्छेद में नीचे दिखाया गया पाठ शामिल है। स्लाइड और आकार दोनों की सूचकांक शून्य‑आधारित है। बोल्ड हिस्सों का चयन करने वाले उदाहरण प्रभावी स्वरूपण का उपयोग करते हैं, जिसमें विरासत में मिला बोल्ड स्वरूपण भी शामिल है:

![उदाहरण पाठ](sample_text.png)

अक्षर शाब्दिक पाठ या नियमित अभिव्यक्ति मेलों को खोजने और हाइलाइट करने के लिए, देखें [Search and Replace Text](/slides/hi/nodejs-java/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

डिफ़ॉल्ट रूप से अनुच्छेद के लिए हाइलाइट रंग सेट करने के लिए [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत पाठ हिस्सों के लिए [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) उपयोग करें।

निम्न उदाहरण पहले अनुच्छेद के लिए हल्का धूसर हाइलाइट डिफ़ॉल्ट रूप से सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट को अधिलेखित करते हैं:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // संपूर्ण अनुच्छेद के लिए हाइलाइट रंग सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![धूसर अनुच्छेद](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** के लिए पृष्ठभूमि रंग सेट करने का प्रदर्शन करता है:

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

![धूसर पाठ भाग](gray_text_portions.png)

## **पाठ अनुच्छेदों को संरेखित करें**

टेक्स्ट फ्रेम के भीतर अनुच्छेद संरेखण सेट करने के लिए [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) का उपयोग करें। मान केंद्रित, बाएँ‑संरेखित, दाएँ‑संरेखित, समान‑व्याप्ति आदि हो सकते हैं।

निम्न कोड अनुच्छेद को **केंद्र** में संरेखित करने का उदाहरण है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // अनुच्छेद का संरेखण केंद्र में सेट करें।
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![संतुलित अनुच्छेद](aligned_paragraph.png)

## **पाठ के लिए पारदर्शिता सेट करें**

पाठ पारदर्शिता को [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) को सौंपे गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` 0‑255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

निम्न कोड उदाहरण **पूरे अनुच्छेद** पर पारदर्शिता लागू करने का प्रदर्शन करता है:

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

    // टेक्स्ट की फ़िल रंग को पारदर्शी रंग पर सेट करें।
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी अनुच्छेद](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** पर पारदर्शिता लागू करने का प्रदर्शन करता है:

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

![पारदर्शी पाठ भाग](transparent_text_portions.png)

## **पाठ के लिए अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को विस्तारित या संकुचित करने के लिए [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) का उपयोग करें। नीचे के उदाहरण 3 पॉइंट अंतराल जोड़ते हैं; नकारात्मक मान पाठ को संकुचित करते हैं।

निम्न JavaScript कोड **पूरे अनुच्छेद** में अक्षर अंतराल को बढ़ाने का उदाहरण है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![अनुच्छेद में अक्षर अंतराल](character_spacing_in_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** में अक्षर अंतराल को बढ़ाने का प्रदर्शन करता है:

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
            // ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            portion.getPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ।
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पाठ भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए करनिंग अक्षम करें**

कुछ मामलों में Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाए गए पाठ से थोड़ा टाइट लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए करनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध करनिंग जानकारी हो और PowerPoint सेटिंग्स में करनिंग सक्षम हो।

ऐसे मामलों में आप उन फ़ॉन्ट के उपयोग वाले पाठ भागों के लिए करनिंग अक्षम कर सकते हैं। [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) को वास्तविक फ़ॉन्ट आकार से बड़ा मान दें। यह उदाहरण "presentation.pptx" की आवश्यकता रखता है जिसमें पहले स्लाइड पर पहला आकार टेक्स्ट बॉक्स है। यह प्रभावी फ़ॉन्ट नामों (विरासत में मिले फ़ॉन्ट सहित) को जाँचता है और Roboto फ़ॉन्ट वाले भागों के लिए 100‑पॉइंट थ्रेशोल्ड सेट करता है। यह 100 पॉइंट से कम आकार के मिलते भागों के लिए करनिंग अक्षम करता है:

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

थ्रेशोल्ड से नीचे के मिलते पाठ के लिए यह सेटिंग करनिंग को रोकती है और PowerPoint‑विशिष्ट व्यवहार से प्रभावित फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के करीब लाने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को अनुच्छेद स्तर पर [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) से या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/) से सेट किया जा सकता है।

निम्न उदाहरण पहले अनुच्छेद की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और बिंदीदार रेखांकित स्वरूपण के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट स्वरूपण इन डिफ़ॉल्ट को अधिलेखित करता है:

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

![अनुच्छेद के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण 13‑पॉइंट Times New Roman, इटैलिक स्वरूपण, और बिंदीदार रेखांकित को उन भागों पर लागू करता है जिनका प्रभावी स्वरूपण बोल्ड है:

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

            // पाठ भाग के लिए फ़ॉन्ट गुण सेट करें।
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

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) का उपयोग करके आकार के भीतर एक पूर्वनिर्धारित पाठ अभिविन्यास सेट किया जा सकता है।

निम्न कोड उदाहरण आकार में पाठ अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textverticaltype/) पर सेट करता है, जो पाठ को **90 डिग्री उल्टे दिशा में** घुमाता है:

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

![पाठ घुमाव](text_rotation.png)

## **पाठ फ्रेम के लिए कस्टम घुमाव सेट करें**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) का उपयोग करके किसी [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) का कस्टम घुमाव कोण सेट किया जा सकता है।

निम्न कोड उदाहरण आकार के भीतर पाठ फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

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

![कस्टम पाठ घुमाव](custom_text_rotation.png)

## **अनुच्छेदों की लाइन स्पेसिंग सेट करें**

Aspose.Slides प्रदान करता है [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-), और [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) ताकि अनुच्छेद स्पेसिंग को नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान प्रयोग करें।
* पॉइंट में लाइन स्पेसिंग निर्दिष्ट करने के लिए नकारात्मक मान प्रयोग करें।

निम्न उदाहरण पहली अनुच्छेद की भीतर स्पेसिंग को लाइन ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

![अनुच्छेद के भीतर लाइन स्पेसिंग](line_spacing.png)

## **लाइन ब्रेकिंग नियंत्रित करें**

अनुच्छेद लाइन‑ब्रेकिंग नियम संकीर्ण टेक्स्ट ब्लॉकों और लैटिन व ईस्ट एशिया पाठ मिश्रित प्रस्तुतियों में उपयोगी होते हैं। नीचे दिए गये मेथड्स [ParagraphFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/) से संबंधित हैं, इसलिए वे पूरे अनुच्छेद पर लागू होते हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) लैटिन लाइन‑ब्रेकिंग नियम नियंत्रित करता है। मिश्रित पाठ में इसे बदलने से ईस्ट एशिया पाठ और विराम चिह्नों के रैपिंग स्थान भी बदल सकते हैं।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) ईस्ट एशिया लाइन‑ब्रेकिंग नियम नियंत्रित करता है, जिसमें लाइन की शुरुआत व समाप्ति पर अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-) को बदलते नहीं हैं, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। ये रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक कैरेक्टर नहीं डालते। एक स्पष्ट लाइन ब्रेक अनुच्छेद के भीतर नई पंक्ति बनाता है, उपलब्ध चौड़ाई से स्वतंत्र।

निम्न स्वनिर्भर उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन पाठ शामिल है। यह दोनों लाइन‑ब्रेक विकल्प स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम का प्रयोग करने के लिए, दूसरा सेटिंग स्थिर रखते हुए संबंधित मान बदलें। उदाहरण 24‑पॉइंट Arial और SimSun, 160‑पॉइंट फ्रेम चौड़ाई और क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन शून्य के साथ उपयोग करता है। [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) को [TextAutofitType.None](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textautofittype/) के साथ कॉल किया गया है ताकि पाठ आकार और फ्रेम आयाम स्थिर रहें:

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

## **हैंगिंग विराम चिह्न नियंत्रित करें**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) योग्य विराम चिह्नों को पाठ पंक्ति के दाएँ किनारे से बाहर तक विस्तारित करने की अनुमति देता है, बजाय इसके कि वह अगली पंक्ति में आए। यह पूरे अनुच्छेद पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्वनिर्भर उदाहरण 100‑पॉइंट‑चौड़े टेक्स्ट फ्रेम में हैंगिंग विराम चिह्न सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर तक विस्तारित होता है। तुलना के लिए प्रॉपर्टी को [NullableBool.False](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ, बिंदु एक अलग पंक्ति में आ जाता है। रैपिंग सक्षम है और ऑटॉफ़िट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

सभी विराम चिह्न हैंग नहीं कर सकते। दृश्य परिणाम फ़ॉन्ट उपलब्धता और लेआउट पर निर्भर करता है: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटॉफ़िट सेटिंग बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटॉफ़िट प्रकार सेट करें**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) निर्धारित करता है कि टेक्स्ट अपने कंटेनर की सीमाओं से अधिक होने पर कैसे व्यवहार करे। इसका उपयोग इस बात को नियंत्रित करने के लिए किया जाता है कि_text_ छोटा हो, अधिक हो, या आकार स्वचालित रूप से बदले। निम्न उदाहरण आकार को उसके पाठ के अनुसार आकार बदलने के लिए कॉन्फ़िगर करता है और परिणाम को "autofit_type.pptx" में सहेजता है:

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

स्वचालित रैपिंग के बाद पंक्तियों की गिनती करने और यह देखने के लिए कि पाठ या आकार की चौड़ाई परिवर्तन परिणाम को कैसे बदलते हैं, देखें [Count Rendered Lines](/slides/hi/nodejs-java/manage-paragraph/). पंक्ति गिनती अकेले यह संकेत नहीं देती कि पाठ अपने कंटेनर से बाहर निकलता है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) यह परिभाषित करता है कि टेक्स्ट आकार के भीतर लंबवत कैसे स्थित हो, उदाहरण के लिए शीर्ष, मध्य या निचले भाग में। निम्न उदाहरण पहले आकार के नीचे टेक्स्ट को एंकर करता है और परिणाम को "text_anchor.pptx" में सहेजता है:

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

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) और [ParagraphFormat.getTabs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#getTabs--) का उपयोग करके अनुच्छेद में टैब स्टॉप कॉन्फ़िगर किए जा सकते हैं। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट सेट करता है और 30 पॉइंट पर बाएं‑संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले पाठ को प्रभावित करती हैं:

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

![अनुच्छेद टैब्स](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides प्रदान करता है [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) जिससे आप टेक्स्ट भाग के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा निर्धारित करती है कि PowerPoint में वर्तनी और व्याकरण जांच किस भाषा में की जाएगी।

निम्न उदाहरण में "presentation.pptx" चाहिए जिसमें पहले स्लाइड पर पहला आकार टेक्स्ट बॉक्स हो और कम से कम एक अनुच्छेद हो। यह पहले अनुच्छेद की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और प्रूफ़िंग भाषा को Simplified Chinese (`zh-CN`) निर्धारित करता है। परिणाम को "proofing_language.pptx" में सहेजा जाता है:

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

    // प्रूफ़िंग भाषा का Id सेट करें।
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके प्रस्तुतिकरण लोड या बनाते समय उत्पन्न पाठ के लिए डिफ़ॉल्ट भाषा परिभाषित की जा सकती है। निम्न उदाहरण US English को डिफ़ॉल्ट पाठ भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले पाठ भाग के लिए `en-US` प्रिंट करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // नया आयत आकार टेक्स्ट के साथ जोड़ें।
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // पहले भाग भाषा की जाँच करें।
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुतिकरण स्तर पर डिफ़ॉल्ट टेक्स्ट स्वरूपण लागू करने के लिए [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुतिकरण में शीर्ष‑स्तरीय अनुच्छेदों के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट को विरासत में ले सकता है जब तक कि अधिक विशिष्ट स्वरूपण उन्हें ओवरराइड न करे।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // शीर्ष स्तर के अनुच्छेद स्वरूप प्राप्त करें।
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

## **ऑल‑कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से स्लाइड पर पाठ बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides से ऐसा पाठ भाग प्राप्त करते हैं, तो लाइब्रेरी पाठ को वही रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित पाठ से मिलाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textcaptype/) जांचें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है जिसमें पहले स्लाइड पर पहला आकार टेक्स्ट बॉक्स हो। उसके पहले अनुच्छेद के पहले भाग में "Hello, Aspose!" है, जिस पर All Caps प्रभाव लागू है, जैसा कि नीचे दिखाया गया है।

![ऑल कैप्स प्रभाव](all_caps_effect.png)

निम्न कोड उदाहरण दिखाता है कि **All Caps** प्रभाव लागू होते हुए टेक्स्ट को कैसे निकालें:

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

**मैं स्लाइड पर तालिका में पाठ कैसे संशोधित करूँ?**

स्लाइड पर तालिका में पाठ संशोधित करने के लिए [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/table/) का उपयोग करें। कोशिकाओं के माध्यम से इटररेट करें और प्रत्येक को [Cell.getTextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/#getTextFrame--) के माध्यम से अपडेट करें तथा पैराग्राफ स्वरूपण को [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड पर पाठ में ग्रेडिएंट रंग कैसे लागू करूँ?**

पाठ में ग्रेडिएंट रंग लागू करने के लिए [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) का उपयोग करें। [FillFormat.setFillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।