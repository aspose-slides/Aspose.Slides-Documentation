---
title: JavaScript में PowerPoint प्रस्तुतियों में पाठ खोजें और प्रतिस्थापित करें
linktitle: पाठ खोजें और प्रतिस्थापित करें
type: docs
weight: 55
url: /hi/nodejs-java/search-and-replace-text/
keywords:
- पाठ खोज
- पाठ हाइलाइट
- पाठ बदलें
- नियमित अभिव्यक्ति
- परिणाम कॉलबैक
- टेक्स्ट फ्रेम
- ऑडिट रिपोर्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में पाठ को खोजें, हाइलाइट करें और बदलें, जबकि Aspose.Slides for Node.js via Java के साथ प्रत्येक मिलान को एकत्रित किया जाता है।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java व्यक्तिगत टेक्स्ट फ़्रेम में या पूरी प्रस्तुति में पाठ को खोज, हाइलाइट और बदल सकता है। प्रत्येक ऑपरेशन परिणाम कॉलबैक के माध्यम से प्रत्येक मिलान के बारे में एप्लिकेशन को सूचित भी कर सकता है। इससे प्रस्तुति को अपडेट करने के साथ‑साथ मिलते हुए पाठ, उसका संदर्भ, स्थिति, टेक्स्ट फ़्रेम और स्लाइड नंबर वाली ऑडिट ट्रेल बनाना संभव हो जाता है।

इन क्षमताओं का उपयोग समीक्षा, प्रतिबंध, शब्दावली जाँच, टेम्प्लेट सफाई और स्वचालित रिपोर्टिंग कार्यप्रवाहों के लिए किया जा सकता है।

नीचे दिए गए पहले उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करते हैं, जिसमें पहले स्लाइड पर एकल टेक्स्ट बॉक्स है जिसमें निम्नलिखित पाठ है:

![उदाहरण पाठ](sample_text.png)

## **खोज सीमा चुनें**

एक टेक्स्ट फ़्रेम तक ऑपरेशन को सीमित करने के लिए [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) पर उपलब्ध विधियों का उपयोग करें। प्रस्तुति में सभी लागू पाठ को संसाधित करने के लिए [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) पर उपलब्ध विधियों का उपयोग करें।

| ऑपरेशन | एक टेक्स्ट फ़्रेम | पूरी प्रस्तुति |
|---|---|---|
| Highlight literal text | [TextFrame.highlightText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [TextFrame.highlightRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [TextFrame.replaceText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [TextFrame.replaceRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **पाठ मिलान कॉन्फ़िगर करें**

साबित-टेक्स्ट ऑपरेशनों के लिए, मिलान नियंत्रण करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/) का उपयोग करें:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) मिलानों को केवल पूर्ण शब्दों तक सीमित करता है।
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) यह नियंत्रित करता है कि अक्षर का केस मेल करना चाहिए या नहीं।
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) प्रस्तुति‑स्तर के खोज, प्रतिस्थापन और हाइलाइटिंग ऑपरेशनों में स्लाइड नोट्स को शामिल करता है।

रेगुलर‑एक्सप्रेशन ऑपरेशन्स Java `Pattern` का उपयोग करते हैं, इसलिए केस संवेदनशीलता और शब्द सीमाओं जैसे मिलान नियम अभिव्यक्ति और उसके फ़्लैग्स द्वारा निर्धारित होते हैं।

## **कॉलबैक के साथ मिलान जानकारी एकत्रित करें**

परिणाम कॉलबैक के लिए एक Java प्रॉक्सी बनाएं ताकि हर मिलान पर सूचना प्राप्त हो सके। प्रॉक्सी फ़ंक्शन संबंधित टेक्स्ट फ़्रेम, स्रोत पाठ, मिलित पाठ और मिलान स्थिति प्राप्त करता है।

कॉलबैक को सीधे स्लाइड नंबर नहीं मिलता। नीचे दिया गया कार्यान्वयन इसे [TextFrame.getSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#getSlideNumber--), और [NotesSlide.getParentSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notesslide/#getParentSlide--) के माध्यम से प्राप्त करता है। यह स्लाइड नोट्स में पाया गया पाठ भी संभालता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

प्रतिस्थापन ऑपरेशनों के लिए, `foundText` मूल मिलित पाठ रखता है, इसलिए कॉलबैक सटीक रूप से रिकॉर्ड कर सकता है कि कौन से शब्द बदले गए।

## **पाठ को हाइलाइट करें**

टेक्स्ट फ़्रेम में साबित‑टेक्स्ट मिलानों को हाइलाइट करने के लिए [TextFrame.highlightText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) विधि का उपयोग करें। खोज को नियंत्रित करने के लिए [TextSearchOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/) पास करें।

नीचे दिया गया कोड उदाहरण सभी **"try"** अक्षरों की घटनाओं को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // "try" के प्रत्येक प्रकट होने को टेक्स्ट फ्रेम में हाईलाइट करें।
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // केवल पूर्ण शब्द "to" को हाईलाइट करें।
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![हाइलाइट किया गया पाठ](highlighted_text.png)

## **रेगुलर एक्सप्रेशन का उपयोग कर पाठ को हाइलाइट करें**

रेगुलर एक्सप्रेशन द्वारा पाया गया पाठ तालिका में हाइलाइट करने के लिए [TextFrame.highlightRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) विधि का उपयोग करें।

निम्न कोड सभी शब्दों को हाइलाइट करता है जिनमें सात या अधिक अक्षर हैं:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![रेगुलर एक्सप्रेशन का उपयोग कर हाइलाइट किया गया पाठ](highlighted_text_using_regex.png)

## **पूर्ण प्रस्तुति में पाठ को हाइलाइट करें**

[Presentation.highlightText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [Presentation.highlightRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) का उपयोग करके प्रस्तुति में सभी लागू टेक्स्ट फ़्रेम खोजें। नीचे दिया गया उदाहरण एक साबित शब्द और सभी ई‑मेल पते को हाइलाइट करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट फ्रेम में पाठ को बदलें**

साबित‑टेक्स्ट के लिए [TextFrame.replaceText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और पैटर्न‑आधारित प्रतिस्थापन के लिए [TextFrame.replaceRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) का उपयोग करें। ये विधियाँ मौजूदा टेक्स्ट फ़्रेम के भीतर मिलित पाठ को अपडेट करती हैं, जिससे आसपास के भाग की फ़ॉर्मेटिंग बनी रहती है, बजाय पूरी स्ट्रिंग से टेक्स्ट फ़्रेम को पुनः बनाने के।

निम्न उदाहरण एक वर्तनी विविधता को मानकीकृत करता है और फिर संस्करण लेबल बदलता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि कोई मिलान विभिन्न फ़ॉर्मेटिंग वाले भागों को कवर करता है, तो आउटपुट की समीक्षा करें कि प्रतिस्थापन पाठ पर कौन सी फ़ॉर्मेटिंग लागू होनी चाहिए।

## **पूरा प्रस्तुति में पाठ को बदलें**

[Presentation.replaceText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [Presentation.replaceRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) का उपयोग करके समान ऑपरेशन्स पूरे प्रस्तुति में लागू करें। यह टेम्प्लेट सफाई, शब्दावली अपडेट और प्रतिबंध के लिए उपयोगी है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **रिपोर्टिंग के लिये मिलानों को समूहित करें**

क्योंकि प्रत्येक संग्रहीत परिणाम अपना स्लाइड नंबर और टेक्स्ट फ़्रेम रखता है, एप्लिकेशन ऑडिट, रिपोर्टिंग या समीक्षा कार्यप्रवाहों के लिये मिलानों को समूहित कर सकते हैं। नीचे दिया गया उदाहरण परिणामों को पहले स्लाइड के आधार पर फिर टेक्स्ट फ़्रेम के आधार पर समूहित करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरी प्रस्तुति के बजाय केवल एक टेक्स्ट बॉक्स को कैसे खोज सकता हूँ?**

आकार (shape) का टेक्स्ट फ्रेम प्राप्त करें और उस पर [TextFrame.highlightText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), या [TextFrame.replaceRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) को कॉल करें। प्रस्तुति‑स्तर की विधियां सभी लागू टेक्स्ट फ़्रेम को प्रोसेस करती हैं।

**मैं पूरे शब्दों को सही बड़े‑छोटे अक्षरों के साथ कैसे मिलाऊँ?**

[TextSearchOptions.setWholeWordsOnly] और [TextSearchOptions.setCaseSensitive] को `true` पर सेट करें, और विकल्पों को साबित‑टेक्स्ट हाइलाइटिंग या प्रतिस्थापन विधि में पास करें। रेगुलर एक्सप्रेशन्स के लिये, शब्द सीमा और केस संवेदनशीलता को स्वयं Java `Pattern` में परिभाषित करें।

**क्या खोज और प्रतिस्थापन स्लाइड नोट्स के पाठ को भी शामिल कर सकते हैं?**

हां। प्रस्तुति‑स्तर की साबित‑टेक्स्ट ऑपरेशन उपयोग करते समय [TextSearchOptions.setIncludeNotes] को `true` पर सेट करें। ऊपर दिखाए गए कॉलबैक कार्यान्वयन में नोट्स स्लाइड के मिलान को उसकी पैरेंट स्लाइड नंबर से मैप किया गया है।

**मैं प्रस्तुति को दूसरी बार स्कैन किए बिना रिपोर्ट कैसे बना सकता हूँ?**

हाइलाइटिंग या प्रतिस्थापन ऑपरेशन में Java परिणाम‑कॉलबैक प्रॉक्सी पास करें। कॉलबैक ऑपरेशन चलाते समय प्रत्येक मिलान प्राप्त करता है, जिससे एप्लिकेशन स्रोत पाठ, मिलित पाठ, स्थिति, टेक्स्ट फ्रेम और निकाला गया स्लाइड नंबर संग्रहित कर सके, जिसे बाद में समूहित या निर्यात किया जा सके।

**क्या पाठ को बदलने से उसकी फ़ॉर्मेटिंग बनी रहती है?**

[TextFrame.replaceText] और [TextFrame.replaceRegex] मौजूदा टेक्स्ट फ्रेम के भीतर मिलित पाठ को संशोधित करती हैं और आसपास के भाग की फ़ॉर्मेटिंग बरकरार रखती हैं। यदि कोई मिलान विभिन्न फ़ॉर्मेटिंग वाले भागों को कवर करता है, तो परिणाम की जांच करें कि प्रतिस्थापन वांछित शैली का उपयोग करता है या नहीं।