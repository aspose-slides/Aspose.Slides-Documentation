---
title: JavaScript में PowerPoint प्रस्तुतियों में टेक्स्ट खोजें और बदलें
linktitle: टेक्स्ट खोजें और बदलें
type: docs
weight: 55
url: /hi/nodejs-java/search-and-replace-text/
keywords:
- टेक्स्ट खोज
- टेक्स्ट हाइलाइट
- टेक्स्ट बदलें
- नियमित अभिव्यक्ति
- परिणाम कॉलबैक
- टेक्स्ट फ़्रेम
- ऑडिट रिपोर्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ प्रत्येक मिलान को एकत्रित करते हुए PowerPoint प्रस्तुतियों में टेक्स्ट खोजें, हाइलाइट करें और बदलें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java व्यक्तिगत टेक्स्ट फ़्रेम या पूरी प्रस्तुति में टेक्स्ट को खोज, हाइलाइट और बदल सकता है। प्रत्येक ऑपरेशन परिणाम कॉलबैक के माध्यम से प्रत्येक मिलान के बारे में एप्लिकेशन को सूचित भी कर सकता है। इससे प्रस्तुति को अपडेट करने और साथ ही मिलाए गए टेक्स्ट, उसका संदर्भ, स्थिति, टेक्स्ट फ़्रेम और स्लाइड नंबर सहित एक ऑडिट ट्रेल बनाने की संभावना बनती है।

इन क्षमताओं का उपयोग समीक्षा, संपादन, शब्दावली जाँच, टेम्प्लेट सफ़ाई और स्वचालित रिपोर्टिंग वर्कफ़्लो में किया जा सकता है।

नीचे पहले उदाहरणों में हम "sample.pptx" नामक फ़ाइल का उपयोग करते हैं, जिसमें पहले स्लाइड पर एक ही टेक्स्ट बॉक्स है और उसमें निम्नलिखित टेक्स्ट है:

![नमूना पाठ](sample_text.png)

## **खोज का दायरा चुनें**

एक ऑपरेशन को केवल एक टेक्स्ट फ़्रेम तक सीमित करने के लिए [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) पर मौजूद मेथड्स का उपयोग करें। पूरी प्रस्तुति में सभी लागू टेक्स्ट को प्रोसेस करने के लिए [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) पर मौजूद मेथड्स का उपयोग करें।

| ऑपरेशन | एक टेक्स्ट फ़्रेम | पूरी प्रस्तुति |
|---|---|---|
| लिटरल टेक्स्ट को हाइलाइट करें | [TextFrame.highlightText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| रेगुलर‑एक्सप्रेशन मिलानों को हाइलाइट करें | [TextFrame.highlightRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| लिटरल टेक्स्ट को बदलें | [TextFrame.replaceText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| रेगुलर‑एक्सप्रेशन मिलानों को बदलें | [TextFrame.replaceRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **टेक्स्ट मिलान को कॉन्फ़िगर करें**

लिटरल‑टेक्स्ट ऑपरेशनों के लिए, मिलान को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/) का उपयोग करें:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) पूरे शब्दों के मिलान को सीमित करता है।
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) अक्षर आकार मिलान की आवश्यकता को नियंत्रित करता है।
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) प्रस्तुति‑स्तर की खोज, प्रतिस्थापन और हाइलाइटिंग ऑपरेशनों में स्लाइड नोट्स को शामिल करता है।

रेगुलर‑एक्सप्रेशन ऑपरेशनों में जावा `Pattern` का उपयोग किया जाता है, इसलिए केस‑सेंसिटिविटी और शब्द‑सीमाएँ जैसी नियम अभिव्यक्ति तथा उसके फ़्लैग्स द्वारा परिभाषित होते हैं।

## **टेक्स्ट फ़्रेम के मालिक की पहचान करें**

जनरल टेक्स्ट‑प्रोसेसिंग वर्कफ़्लो अक्सर एक [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) प्राप्त करते हैं जबकि वे खोज, प्रतिस्थापन, वैधता या निर्यात कर रहे होते हैं। टेक्स्ट फ़्रेम के मालिक ऑब्जेक्ट को निर्धारित करने के लिए [TextFrame.getParentShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getParentShape--) और [TextFrame.getParentCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getParentCell--) का उपयोग करें।

अपेक्षित मान मालिक पर निर्भर करते हैं:

| टेक्स्ट फ़्रेम मालिक | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape या कोई अन्य टेक्स्ट‑धारक shape | संबंधित [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) | `null` |
| टेबल सेल | `null` | संबंधित [Cell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/) |

दोनों मेथड्स केवल रीड‑ऑनली नेविगेशन प्रदान करते हैं। इन्हें कॉल करने से टेक्स्ट फ़्रेम नहीं हटता और न ही उसके मालिक में परिवर्तन होता है। सामान्य कोड को दोनों मानों को `null` के लिये जाँचनी चाहिए और इस संभावना को संभालना चाहिए कि कोई भी मालिक उपलब्ध न हो।

निम्न उदाहरण में [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) का उपयोग करके प्रस्तुति के सभी टेक्स्ट फ़्रेम पर इटरेट किया गया है। Shapes के लिए यह shape का नाम, Java रन‑टाइम टाइप और सम्मिलित स्लाइड को रिपोर्ट करता है। Table cells के लिए यह शून्य‑आधारित कॉलम और रो कोऑर्डिनेट्स तथा सम्मिलित स्लाइड को रिपोर्ट करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

SmartArt सामग्री के लिये, [SmartArtNode.getShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartartnode/#getShapes--) में स्थित शेप्स पर इटरेट करें और प्रत्येक [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) तक पहुँचें। टेक्स्ट फ़्रेम को उसके संबंधित शेप के माध्यम से [TextFrame.getParentShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getParentShape--) द्वारा ट्रेस किया जा सकता है, जबकि [TextFrame.getParentCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getParentCell--) `null` लौटाता है। इसलिए, उदाहरण में shape शाखा SmartArt नोड्स से टेक्स्ट को भी संभालती है।

## **कॉलबैक के साथ मिलान जानकारी एकत्र करें**

एक जावा प्रॉक्सी बनाकर परिणाम कॉलबैक को हर मिलान की सूचना प्राप्त हो सके। प्रॉक्सी फ़ंक्शन संबंधित टेक्स्ट फ़्रेम, स्रोत टेक्स्ट, मिलाया गया टेक्स्ट और मिलान की स्थिति प्राप्त करता है।

कॉलबैक को सीधे स्लाइड नंबर नहीं मिलता। नीचे दिया गया कार्यान्वयन टेक्स्ट फ़्रेम के मालिक shape या table cell के माध्यम से, [TextFrame.getSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getSlide--) को फ़ॉलबैक के रूप में उपयोग करके स्लाइड नंबर व्युत्पन्न करता है। यह स्लाइड नोट्स में मिलने वाले टेक्स्ट को भी संभालता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

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

प्रतिस्थापन ऑपरेशनों के लिये, `foundText` में मूल मिलाया गया टेक्स्ट होता है, इसलिए कॉलबैक सटीक रूप से रिकॉर्ड कर सकता है कि कौन‑से शब्द बदले गये।

## **टेक्स्ट को हाइलाइट करें**

एक टेक्स्ट फ़्रेम में लिटरल‑टेक्स्ट मिलानों को हाइलाइट करने के लिये [TextFrame.highlightText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) मेथड का उपयोग करें। खोज को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/) पास करें।

नीचे दिया गया कोड उदाहरण सभी **"try"** अक्षरों को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है।

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

    // टेक्स्ट फ़्रेम में "try" की प्रत्येक उपस्थिति को हाइलाइट करें।
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // केवल पूर्ण शब्द "to" को हाइलाइट करें।
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![हाइलाइट किया गया टेक्स्ट](highlighted_text.png)

## **रेगुलर एक्सप्रेशन्स के साथ टेक्स्ट हाइलाइट करें**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) मेथड रेगुलर एक्सप्रेशन द्वारा पाए गए टेक्स्ट मिलानों को एक टेक्स्ट फ़्रेम में हाइलाइट करता है।

निम्न कोड सभी सात या अधिक अक्षर वाले शब्दों को हाइलाइट करता है:

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

![रेगुलर एक्सप्रेशन के साथ हाइलाइट किया गया टेक्स्ट](highlighted_text_using_regex.png)

## **पूरी प्रस्तुति में टेक्स्ट हाइलाइट करें**

[Presentation.highlightText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [Presentation.highlightRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) का उपयोग करके प्रस्तुति के सभी लागू टेक्स्ट फ़्रेम में खोज करें। नीचे दिया गया उदाहरण एक लिटरल टर्म और सभी ई‑मेल पतों को हाइलाइट करता है:

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

## **टेक्स्ट फ़्रेम में टेक्स्ट बदलें**

लिटरल टेक्स्ट के लिये [TextFrame.replaceText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और पैटर्न‑आधारित प्रतिस्थापन के लिये [TextFrame.replaceRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) का उपयोग करें। ये मेथड्स मौजूदा टेक्स्ट फ़्रेम के भीतर मिलाए गये टेक्स्ट को अपडेट करते हैं, जिससे आसपास के भाग की फ़ॉर्मेटिंग बरकरार रहती है और पूर्ण स्ट्रिंग से फ़्रेम का पुनर्निर्माण नहीं होता।

नीचे दिया गया उदाहरण एक वर्तनी भिन्नता को मानकीकृत करता है और फिर संस्करण लेबल को बदलता है:

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

यदि कोई मिलान विभिन्न फ़ॉर्मेटिंग वाले भागों को कवर करता है, तो आउटपुट की समीक्षा करें ताकि यह सुनिश्चित किया जा सके कि प्रतिस्थापित टेक्स्ट पर कौन‑सी फ़ॉर्मेटिंग लागू होनी चाहिए।

## **पूरी प्रस्तुति में टेक्स्ट बदलें**

[Presentation.replaceText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [Presentation.replaceRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) का उपयोग करके समान ऑपरेशनों को पूरी प्रस्तुति में लागू करें। यह टेम्प्लेट सफ़ाई, शब्दावली अपडेट और संपादन हेतु उपयोगी है।

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

चूंकि प्रत्येक संग्रहीत परिणाम अपने स्लाइड नंबर और टेक्स्ट फ़्रेम को रखता है, एप्लिकेशन मिलानों को ऑडिट, रिपोर्टिंग या रिव्यू वर्कफ़्लो के लिये समूहित कर सकते हैं। नीचे दिया गया उदाहरण परिणामों को पहले स्लाइड और फिर टेक्स्ट फ़्रेम के अनुसार समूहित करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

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

**मैं पूरी प्रस्तुति के बजाय केवल एक टेक्स्ट बॉक्स में कैसे खोज करूँ?**

शेप के टेक्स्ट फ़्रेम को प्राप्त करें और उस फ़्रेम पर [TextFrame.highlightText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), या [TextFrame.replaceRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) कॉल करें। प्रस्तुति‑स्तर के मेथड सभी लागू टेक्स्ट फ़्रेम को प्रोसेस करते हैं।

**कैसे पूरे शब्दों को सही बड़े‑छोटे अक्षर के साथ मिलाएँ?**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) और [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) को `true` सेट करें और विकल्पों को लिटरल‑टेक्स्ट हाइलाइट या रिप्लेस मेथड को पास करें। रेगुलर एक्सप्रेशन के लिये, शब्द सीमाएँ और केस‑सेंसिटिविटी को जावा `Pattern` में स्वयं परिभाषित करें।

**क्या खोज और प्रतिस्थापन में स्लाइड नोट्स का टेक्स्ट भी शामिल हो सकता है?**

हाँ। प्रस्तुति‑स्तर की लिटरल‑टेक्स्ट ऑपरेशन के दौरान [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) को `true` सेट करें। ऊपर दिखाए गए कॉलबैक इम्प्लीमेंटेशन नोट्स स्लाइड में मिलने वाले मिलान को उसके मूल स्लाइड नंबर से मैप करता है।

**मैं प्रस्तुति को दोबारा स्कैन किए बिना रिपोर्ट कैसे बनाऊँ?**

हाइलाइटिंग या रिप्लेसमेंट ऑपरेशन के दौरान जावा परिणाम‑कॉलबैक प्रॉक्सी पास करें। कॉलबैक ऑपरेशन चलने के दौरान प्रत्येक मिलान प्राप्त करता है, जिससे एप्लिकेशन स्रोत टेक्स्ट, मिलाया गया टेक्स्ट, स्थिति, टेक्स्ट फ़्रेम और व्युत्पन्न स्लाइड नंबर को बाद में समूहित या निर्यात करने के लिये संग्रहीत कर सकता है।

**क्या टेक्स्ट को बदलते समय उसकी फ़ॉर्मेटिंग बनी रहती है?**

[TextFrame.replaceText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और [TextFrame.replaceRegex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) मिलाए गये टेक्स्ट को मौजूदा टेक्स्ट फ़्रेम के भीतर संशोधित करते हैं और आसपास की फ़ॉर्मेटिंग को बरकरार रखते हैं। यदि कोई मिलान विभिन्न फ़ॉर्मेटिंग वाले भागों को कवर करता है, तो सुनिश्चित करने हेतु परिणाम की जाँच करें कि प्रतिस्थापन वांछित शैली का उपयोग करता है।