---
title: जावास्क्रिप्ट में प्रस्तुतियों में फ़ॉन्ट एम्बेड करें
linktitle: एम्बेडेड फ़ॉन्ट्स
type: docs
weight: 40
url: /hi/nodejs-java/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एम्बेड करें
- फ़ॉन्ट एम्बेडिंग
- एम्बेडेड फ़ॉन्ट प्राप्त करें
- एम्बेडेड फ़ॉन्ट जोड़ें
- एम्बेडेड फ़ॉन्ट हटाएँ
- एम्बेडेड फ़ॉन्ट संकुचित करें
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint में एम्बेडेड फ़ॉन्ट्स का प्रबंधन करें। फ़ॉन्ट्स को जोड़ें, प्राप्त करें, हटाएँ और संकुचित करें ताकि पाठ की उपस्थिति बनी रहे और फ़ाइल आकार कम हो।"
---
## **परिचय**

फ़ॉन्ट एम्बेड करने से फ़ॉन्ट डेटा PowerPoint प्रस्तुति के भीतर संग्रहीत होता है। जब एक दर्शक एम्बेडेड फ़ॉन्ट का समर्थन करता है, तो वह लक्ष्य सिस्टम पर स्थापित न होने वाले फ़ॉन्ट का उपयोग करके भी पाठ प्रदर्शित कर सकता है। यह पंक्तियों के विराम, पाठ अंतराल और स्लाइड लेआउट को बनाए रखने में मदद करता है।

Aspose.Slides for Node.js via Java आपको एम्बेडेड फ़ॉन्ट को पुनः प्राप्त करने, जोड़ने और हटाने की अनुमति देता है, जिसे आप [FontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/) क्लास के माध्यम से कर सकते हैं जो [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getfontsmanager/) द्वारा लौटाया जाता है। आप प्रस्तुति द्वारा उपयोग न किए गए अक्षरों को हटाकर एम्बेडेड फ़ॉन्ट डेटा का आकार भी कम कर सकते हैं।

नीचे के उदाहरण PPTX फाइलों के साथ काम करते हैं। फ़ॉन्ट एम्बेड करने से पहले सुनिश्चित करें कि उसका फ़ॉन्ट डेटा Aspose.Slides के लिए उपलब्ध है और उसका लाइसेंस एम्बेडिंग की अनुमति देता है।

## **एम्बेडेड फ़ॉन्ट प्राप्त करें और हटाएँ**

प्रस्तुति में संग्रहीत फ़ॉन्ट की सूची प्राप्त करने के लिए आप [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) का उपयोग कर सकते हैं। किसी फ़ॉन्ट को हटाने के लिए, सूची में से उस फ़ॉन्ट को [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/) को पास करें, फिर प्रस्तुति सहेजें।

निम्नलिखित उदाहरण `EmbeddedFonts.pptx` में एम्बेडेड फ़ॉन्ट को सूचीबद्ध करता है और यदि मौजूद हो तो Calibri को हटाता है:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

एम्बेडेड फ़ॉन्ट को हटाने से उसका संग्रहीत फ़ॉन्ट डेटा हट जाता है; यह पाठ को सौंपे गए फ़ॉन्ट को नहीं बदलता। यदि फ़ॉन्ट लक्ष्य सिस्टम पर स्थापित है, तो पाठ फिर भी उसे उपयोग कर सकता है। अन्यथा, रेंडरिंग के लिए [font substitution](/slides/hi/nodejs-java/font-substitution/) की आवश्यकता पड़ सकती है, जिससे लेआउट पर प्रभाव पड़ सकता है।

## **फ़ॉन्ट डेटा और एम्बेडिंग अनुमतियों की जाँच करें**

फ़ॉन्ट को एम्बेड करने से पहले उनका निरीक्षण करने के लिए आप [FontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/) क्लास का उपयोग करें। प्रस्तुति में उपयोग किए गए फ़ॉन्ट को प्राप्त करने के लिए आप [FontsManager.getFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getfonts/) को कॉल करें। प्रत्येक फ़ॉन्ट के लिए, एक [FontData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontdata/) ऑब्जेक्ट और आवश्यक [FontStyleType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontstyletype/) मान को [FontsManager.getFontBytes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/#getFontBytes) को पास करें। यह मेथड उस फ़ॉन्ट शैली के बाइनरी डेटा को वापस करता है, या जब अनुरोधित फ़ॉन्ट या शैली उपलब्ध नहीं हो तो `null` लौटाता है। `null` परिणाम को [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) को पास न करें, क्योंकि इस मेथड को बाइट एरे की आवश्यकता होती है। Node.js में, `java.newArray` का उपयोग करके लौटाए गए JavaScript एरे को Java बाइट एरे में परिवर्तित करें, फिर इसे `getFontEmbeddingLevel` को पास करें।

[EmbeddingLevel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/embeddinglevel/) फ़ॉन्ट में संग्रहीत एम्बेडिंग प्रतिबंधों को फ़्लैग्स के सेट के रूप में रिपोर्ट करता है:

- `Installable` एम्बेडिंग और दूसरे सिस्टम पर स्थायी स्थापना की अनुमति देता है, फ़ॉन्ट लाइसेंस के अधीन।
- `Restricted` एम्बेडिंग को प्रतिबंधित करता है जब तक फ़ॉन्ट के कानूनी मालिक से अनुमति न प्राप्त की जाए, जब यह एकमात्र उपयोग-अनुमति फ़्लैग हो।
- `PreviewPrint` देखने और प्रिंट करने के लिए अस्थायी उपयोग की अनुमति देता है; फ़ॉन्ट युक्त दस्तावेज़ केवल-पढ़ने योग्य होना चाहिए।
- `Editable` अस्थायी उपयोग की अनुमति देता है और दस्तावेज़ को संपादित और सहेजने की अनुमति देता है।
- `NoSubsetting` एक अतिरिक्त प्रतिबंध है जो ग्लिफ़ के केवल एक उपसमुच्चय को एम्बेड करने से रोकता है। जब यह फ़्लैग मौजूद हो तो सभी अक्षर एम्बेड करें।
- `BitmapOnly` एक अतिरिक्त प्रतिबंध है जो केवल बिटमैप स्ट्राइक्स को एम्बेड करने की अनुमति देता है, आउटलाइन डेटा नहीं। यदि फ़ॉन्ट में बिटमैप स्ट्राइक्स नहीं हैं, तो इसे एम्बेड नहीं किया जा सकता।

पहले चार मान उपयोग अनुमति को वर्णित करते हैं, जबकि `NoSubsetting` और `BitmapOnly` को उनके साथ मिलाया जा सकता है। संशोधकों की जाँच बिटवाइज़ ऑपरेशनों से करें। क्योंकि `Installable` शून्य है, उपयोग-अनुमति बिट्स को मास्क करें और परिणाम की तुलना `Installable` से करें, न कि इसे फ़्लैग के रूप में देखें। वर्तमान फ़ॉन्ट्स को अधिकतम एक उपयोग-अनुमति बिट सेट करना चाहिए। पुराने फ़ॉन्ट्स के साथ संगतता के लिए जो एक से अधिक सेट करते हैं, नीचे दिया गया हेल्पर सबसे कम प्रतिबंधात्मक अनुमति चुनता है: `Editable`, फिर `PreviewPrint`, फिर `Restricted`।

निम्नलिखित उदाहरण प्रत्येक फ़ॉन्ट के नियमित, बोल्ड, इटैलिक और बोल्ड-इटैलिक डेटा को ऑडिट करता है जो `getFonts` द्वारा लौटाए जाते हैं। यह अनुपलब्ध शैलियों, प्रतिबंधित फ़ॉन्ट्स, केवल-बिटमैप फ़ॉन्ट्स, प्रीव्यू और प्रिंट तक सीमित फ़ॉन्ट्स (क्योंकि आउटपुट संपादन योग्य रहता है), और पहले से एम्बेडेड फ़ॉन्ट्स को छोड़ देता है। यदि कोई उपलब्ध शैली `NoSubsetting` रखती है, तो यह फ़ॉन्ट परिवार के सभी अक्षरों को एम्बेड करता है।
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यह निरीक्षण प्रत्येक फ़ॉन्ट फ़ाइल में एन्कोड किए गए प्रतिबंधों की रिपोर्ट करता है। यह लाइसेंस नहीं देता, यह प्रमाणित नहीं करता कि आपने फ़ॉन्ट कानूनी रूप से प्राप्त किया है, या एम्बेडेड प्रतिलिपि वितरित करने से पहले फ़ॉन्ट के लाइसेंस समझौते की जाँच का विकल्प नहीं बनता।

## **एम्बेडेड फ़ॉन्ट जोड़ें**

फ़ॉन्ट को एम्बेड करने के लिए आप [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) का उपयोग करें। इसके ओवरलोड या तो एक [FontData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontdata/) ऑब्जेक्ट या फ़ॉन्ट डेटा वाला बाइट एरे स्वीकार करते हैं। [EmbedFontCharacters](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/embedfontcharacters/) निर्धारित करता है कि कौन से अक्षर शामिल किए जाएँ:

- `All` फ़ॉन्ट के सभी अक्षरों को एम्बेड करता है। इस विकल्प का उपयोग तब करें जब प्राप्तकर्ताओं को प्रस्तुति को संपादित करने और नया पाठ दर्ज करने की आवश्यकता हो।
- `OnlyUsed` केवल प्रस्तुति में उपयोग किए गए अक्षरों को एम्बेड करता है ताकि फ़ाइल आकार कम हो सके। इस विकल्प को उस पूर्ण प्रस्तुति के लिए चुनें जिसका मुख्य उद्देश्य देखने का है।

निम्नलिखित उदाहरण [FontsManager.getFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getfonts/) का उपयोग करके `Fonts.pptx` में उपयोग किए गए फ़ॉन्ट को प्राप्त करता है और उन फ़ॉन्ट्स को एम्बेड करता है जो अभी तक एम्बेडेड नहीं हैं। जोड़ने वाले फ़ॉन्ट कोड चलाने वाली मशीन पर उपलब्ध होने चाहिए। मौजूदा एम्बेडेड फ़ॉन्ट अपने वर्तमान अक्षर सेट को बरकरार रखते हैं।
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एम्बेडेड फ़ॉन्ट संकुचित करें**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/compressembeddedfonts/) अप्रयुक्त अक्षरों को हटाकर एम्बेडेड फ़ॉन्ट डेटा को कम करता है। यह पहले से एम्बेडेड फ़ॉन्ट्स पर काम करता है, इसलिए आकार में कमी इस पर निर्भर करती है कि प्रस्तुति में कितना अप्रयुक्त फ़ॉन्ट डेटा है।

निम्नलिखित उदाहरण `EmbeddedFonts.pptx` में फ़ॉन्ट को संकुचित करता है और परिणाम को एक अलग फ़ाइल के रूप में सहेजता है:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि प्राप्तकर्ताओं को बाद में टेक्स्ट जोड़ने की आवश्यकता हो सकती है तो मूल फ़ाइल रखें। संपीड़न के दौरान हटाए गए अक्षर अब एम्बेडेड फ़ॉन्ट से उपलब्ध नहीं रहेंगे, भले ही आपने मूल रूप से सभी अक्षर एम्बेड किए हों।

## **अक्सर पूछे जाने वाले प्रश्न**

**एक एम्बेडेड फ़ॉन्ट रेंडरिंग के दौरान अभी भी प्रतिस्थापित होगा या नहीं, इसे कैसे जांचें?**

प्रस्तुति को रेंडर करने वाले वातावरण में आप [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) को कॉल करके देख सकते हैं कि Aspose.Slides कौन से फ़ॉन्ट को बदल देगा। साथ ही [font substitution](/slides/hi/nodejs-java/font-substitution/) सेटिंग्स और [font fallback](/slides/hi/nodejs-java/fallback-font/) नियमों की जाँच करें। फॉलबैक गायब अक्षरों को संभालता है, इसलिए फ़ॉन्ट को एम्बेड करने से उन अक्षरों का समाधान नहीं होता जो स्वयं फ़ॉन्ट में नहीं होते।

**क्या मुझे Arial और Calibri जैसे सामान्य फ़ॉन्ट्स को एम्बेड करना चाहिए?**

निर्णय लक्ष्य वातावरण पर आधारित होना चाहिए। यदि आवश्यक फ़ॉन्ट्स प्रत्येक मशीन पर उपलब्ध हैं जो प्रस्तुति को खोलती या रेंडर करती है, तो उन्हें एम्बेड करने से अनावश्यक फ़ाइल आकार बढ़ सकता है। यदि प्राप्तकर्ताओं या सर्वरों में ये फ़ॉन्ट नहीं हैं, तो उन्हें एम्बेड करने से इच्छित रूपांतरण संरक्षित रखने में मदद मिल सकती है, बशर्ते उनके लाइसेंस इसे अनुमति दें।