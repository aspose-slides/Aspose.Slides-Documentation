---
title: जावास्क्रिप्ट में प्रस्तुति पाठ को स्वरूपित करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/nodejs-java/text-formatting/
keywords:
- अनुच्छेद संरेखित करें
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घुमाव
- घुमाव कोण
- पाठ फ्रेम
- पंक्ति अंतराल
- ऑटोफ़िट गुण
- पाठ फ्रेम एंकर
- पाठ टैबुलेशन
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

यह लेख Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फ़ॉर्मेट करने के तरीके को दर्शाता है। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घुमाव, अनुच्छेद अंतराल, ऑटोफ़िट व्यवहार, पाठ एंकरिंग, टैब स्टॉप्स, और भाषा सेटिंग्स को कवर करता है।

नीचे दिए गए उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स है जिसमें निम्नलिखित पाठ है:

![उदाहरण पाठ](sample_text.png)

पाठ खोजें और बदलें: [पाठ खोजें और बदलें](/slides/hi/nodejs-java/search-and-replace-text/).

## **पाठ की पृष्ठभूमि रंग सेट करें**

एक अनुच्छेद के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) का उपयोग करें, या व्यक्तिगत पाठ भागों के लिए [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) का उपयोग करें।

निम्नलिखित कोड उदाहरण दिखाता है कि कैसे **पूरे अनुच्छेद** की पृष्ठभूमि रंग सेट करें:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पूरे अनुच्छेद के लिए हाइलाइट रंग सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![धूसर अनुच्छेद](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण दर्शाता है कि कैसे **बोल्ड फ़ॉन्ट वाले पाठ भागों** की पृष्ठभूमि रंग सेट करें:

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
            // पाठ भाग के लिए हाइलाइट रंग सेट करें।
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

## **पाठ अनुच्छेद संरेखित करें**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) का उपयोग करके टेक्स्ट फ़्रेम के भीतर अनुच्छेद संरेखण सेट करें। मान मध्य, बायाँ संरेखित, दायाँ संरेखित, समानान्तर, आदि हो सकता है।

नीचे दिया गया कोड उदाहरण दिखाता है कि कैसे अनुच्छेद को **केन्द्र** में संरेखित करें:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // पैराग्राफ का संरेखण केन्द्र में सेट करें।
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![संरेखित अनुच्छेद](aligned_paragraph.png)

## **पाठ की पारदर्शिता सेट करें**

पाठ की पारदर्शिता को [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) को सौंपे गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0–255 पैमाने पर ARGB अल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण दर्शाता है कि कैसे **पूरे अनुच्छेद** पर पारदर्शिता लागू की जाए:

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

    // पाठ के भराव रंग को पारदर्शी रंग पर सेट करें।
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![पारदर्शी अनुच्छेद](transparent_paragraph.png)

नीचे दिया गया कोड उदाहरण दर्शाता है कि कैसे **बोल्ड फ़ॉन्ट वाले पाठ भागों** पर पारदर्शिता लागू की जाए:

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

## **पाठ के अक्षर अंतराल सेट करें**

[BasePortionFormat.setSpacing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) का उपयोग करके टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को विस्तारित या संकुचित करें।

निम्नलिखित जावास्क्रिप्ट कोड दिखाता है कि कैसे **पूरे अनुच्छेद** में अक्षर अंतराल को विस्तारित किया जाए:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![अनुच्छेद में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण दर्शाता है कि कैसे **बोल्ड फ़ॉन्ट वाले पाठ भागों** में अक्षर अंतराल को विस्तारित किया जाए:

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

### **विशिष्ट फ़ॉन्ट्स के लिए कर्निंग निष्क्रिय करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाए गए समान पाठ से थोड़ा अधिक सघन दिख सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए कर्निंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में मान्य कर्निंग जानकारी हो और PowerPoint सेटिंग्स में कर्निंग सक्षम हो।

ऐसे मामलों में रेंडर किया गया आउटपुट PowerPoint के करीब लाने के लिये, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले पाठ भागों के लिये कर्निंग को निष्क्रिय कर सकते हैं। वास्तविक फ़ॉन्ट आकार से स्पष्ट रूप से बड़ा मान सेट करने के लिये [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) को उपयोग करें:

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

यह सेटिंग समान पाठ भागों पर कर्निंग लागू होने से रोकती है और इस PowerPoint-विशिष्ट व्यवहार से प्रभावित फ़ॉन्ट्स के लिये Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुणों को अनुच्छेद स्तर पर [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) के माध्यम से या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/) के माध्यम से सेट किया जा सकता है।

निम्नलिखित कोड पूरे अनुच्छेद के लिये फ़ॉन्ट और पाठ शैली सेट करता है: यह फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन, और Times New Roman फ़ॉन्ट को अनुच्छेद के सभी भागों पर लागू करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // अनुच्छेद के लिए फ़ॉन्ट गुण सेट करें।
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

नीचे दिया गया कोड उदाहरण समान गुणों को **बोल्ड फ़ॉन्ट वाले पाठ भागों** पर लागू करता है:

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

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) का उपयोग करके आकार के भीतर पूर्वनिर्धारित पाठ अभिविन्यास सेट करें।

निम्नलिखित कोड उदाहरण आकार में पाठ अभिविन्यास को `Vertical270` पर सेट करता है, जो पाठ को **90 डिग्री प्रतिक्लॉकवाइस** घुमा देता है:

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

## **टेक्स्ट फ्रेम्स के लिए कस्टम घुमाव सेट करें**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) का उपयोग करके किसी [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) के लिये कस्टम घुमाव कोण सेट करें।

नीचे दिया गया कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइस घुमा देता है:

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

Aspose.Slides [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-), और [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) प्रदान करता है ताकि अनुच्छेद स्पेसिंग को नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने हेतु सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को बिंदुओं में निर्दिष्ट करने हेतु नकारात्मक मान उपयोग करें।

निम्नलिखित कोड उदाहरण दर्शाता है कि कैसे अनुच्छेद के भीतर लाइन स्पेसिंग निर्दिष्ट करें:

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

## **टेक्स्ट फ्रेम्स के लिए ऑटोफ़िट प्रकार सेट करें**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) निर्धारित करता है कि कंटेनर की सीमा से अधिक होने पर पाठ कैसे व्यवहार करता है। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि पाठ छोटा हो, ओवरफ़्लो हो, या आकार को स्वतः पुनः आकार दे।

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

## **टेक्स्ट फ्रेम्स का एंकर सेट करें**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) निर्धारित करता है कि आकार के भीतर पाठ को लंबवत रूप से कैसे स्थित किया जाए, उदाहरण के लिये शीर्ष, मध्य, या निचले हिस्से में।

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

## **पाठ टॅबुलेशन सेट करें**

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) और [ParagraphFormat.getTabs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#getTabs--) का उपयोग करके अनुच्छेद में टैब स्टॉप्स कॉन्फ़िगर करें।

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

Aspose.Slides [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) प्रदान करता है, जो आपको टेक्स्ट भाग के लिये प्रूफ़िंग भाषा सेट करने की अनुमति देता है। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिये उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्नलिखित कोड उदाहरण दिखाता है कि कैसे टेक्स्ट भाग के लिये प्रूफ़िंग भाषा सेट की जाए:

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

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके प्रस्तुति लोड या बनाते समय निर्मित पाठ के लिये डिफ़ॉल्ट भाषा निर्धारित करें।

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

    // पहले भाग की भाषा जांचें।
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिये, [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) का उपयोग करें।

निम्नलिखित कोड उदाहरण दर्शाता है कि कैसे नई प्रस्तुति में सभी स्लाइड्स के सभी पाठ के लिये 14 पॉइंट आकार के साथ डिफ़ॉल्ट बोल्ड फ़ॉन्ट सेट किया जाए।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // शीर्ष स्तर के अनुच्छेद फ़ॉर्मेट प्राप्त करें।
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

## **ऑल-कैप्स इफ़ेक्ट के साथ पाठ निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से पाठ स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसे पाठ भाग को प्राप्त करते हैं, तो लाइब्रेरी पाठ को बिल्कुल वही रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित पाठ से मेल खाने के लिये, [TextCapType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textcaptype/) जाँचें और जब मान `All` हो, तब लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![ऑल कैप्स प्रभाव](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण दर्शाता है कि कैसे **All Caps** प्रभाव लागू किए हुए पाठ को निकालें:

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

**स्लाइड पर तालिका में पाठ को कैसे संशोधित करें?**

स्लाइड पर तालिका में पाठ संशोधित करने के लिये, [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/table/) का उपयोग करें। सेल्स के माध्यम से क्रमबद्ध ढंग से जाएँ और प्रत्येक सेल को [Cell.getTextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/#getTextFrame--) के माध्यम से तथा अनुच्छेद फ़ॉर्मेटिंग को [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड में पाठ पर ग्रेडिएंट रंग कैसे लागू करें?**

पाठ पर ग्रेडिएंट रंग लागू करने के लिये, [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) का उपयोग करें। [FillFormat.setFillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) को [FillType.Gradient](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।