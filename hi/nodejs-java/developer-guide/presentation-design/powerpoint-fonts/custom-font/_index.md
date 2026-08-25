---
title: जावास्क्रिप्ट में PowerPoint फ़ॉन्ट कस्टमाइज़ करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/nodejs-java/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाहरी फ़ॉन्ट
- फ़ॉन्ट लोड
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js के साथ Java द्वारा PowerPoint स्लाइड्स में फ़ॉन्ट कस्टमाइज़ करें ताकि आपकी प्रस्तुतियां किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर इंस्टॉल किए। आप फ़ॉन्ट्स को कस्टम फ़ोल्डरों से लोड कर सकते हैं, डॉक्यूमेंट‑लेवल फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुति के लिए फ़ॉन्ट्स प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुति को रेंडर या एक्सपोर्ट किया जाता है, जैसे PDF, इमेज, और अन्य समर्थन किए गए फ़ॉर्मेट्स में। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट को समान रखने में मदद करता है। यह लेख यह भी समझाता है कि Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डर कैसे जांचें और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश कैसे साफ़ करें।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स को रजिस्टर करना PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि फ़ॉन्ट को प्रस्तुति के भीतर संग्रहीत करना आवश्यक है, तो फ़ॉन्ट एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

एक प्रस्तुति थीम विभिन्न लेखन प्रणालियों के लिए अलग-अलग फ़ॉन्ट परिवारों का संदर्भ दे सकती है। ये मैपिंग्स फ़ॉन्ट नाम संग्रहीत करती हैं लेकिन फ़ॉन्ट फ़ाइलों को इंस्टॉल या लोड नहीं करतीं। मैपिंग्स को प्रबंधित करने के लिए देखें [Script-Specific Theme Fonts](/slides/hi/nodejs-java/script-specific-font-mappings/), और नीचे दिए गए लोडिंग विकल्पों का उपयोग करके संदर्भित फ़ॉन्ट्स को सुसंगत रेंडरिंग के लिए उपलब्ध कराएँ।

{{% alert color="info" title="Note" %}}

Aspose Slides आपको इन फ़ॉन्ट्स को [loadExternalFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड का उपयोग करके लोड करने की अनुमति देता है:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।

{{% /alert %}}

## **कस्टम फ़ॉन्ट्स लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट्स को सिस्टम पर इंस्टॉल किए बिना लोड करने की सुविधा देता है। यह निर्यात आउटपुट—जैसे PDF, इमेज, और अन्य समर्थित फ़ॉर्मेट्स—को प्रभावित करता है, जिससे उत्पन्न दस्तावेज़ विभिन्न वातावरणों में समान दिखते हैं। फ़ॉन्ट्स को कस्टम डायरेक्टरीज़ से लोड किया जाता है।

1. उन फ़ोल्डरों को निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें हों।
2. उन फ़ोल्डरों से फ़ॉन्ट्स लोड करने के लिए स्थैतिक [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) मेथड को कॉल करें।
3. प्रस्तुति को लोड और रेंडर/एक्सपोर्ट करें।
4. फ़ॉन्ट कैश साफ़ करने के लिए [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/clearcache/) कॉल करें।

निम्न कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को परिभाषित करें।
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट्स लोड करें।
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/एक्सपोर्ट करें (जैसे PDF, इमेज, या अन्य फ़ॉर्मेट्स)।
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) अतिरिक्त फ़ोल्डरों को फ़ॉन्ट खोज पाथ्स में जोड़ता है, लेकिन फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता। फ़ॉन्ट्स इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पाथ।
1. फ़ॉन्ट्स जो [FontsLoader](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/) के माध्यम से लोड किए गए हैं।

{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**

Aspose.Slides [getFontFolders](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) मेथड प्रदान करता है जिससे आप फ़ॉन्ट फ़ोल्डर खोज सकते हैं। यह मेथड `LoadExternalFonts` मेथड के माध्यम से जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर दोनों को लौटाता है।

नीचे दिया गया JavaScript कोड दिखाता है कि आप [getFontFolders](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) का कैसे उपयोग कर सकते हैं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जहाँ फ़ॉन्ट फ़ाइलों की तलाश की जाती है.
// ये फ़ोल्डर LoadExternalFonts मेथड के द्वारा जोड़े गए हैं और सिस्टम फ़ॉन्ट फ़ोल्डर हैं।
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**

Aspose.Slides [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) प्रॉपर्टी प्रदान करता है जिससे आप बाहरी फ़ॉन्ट्स को निर्दिष्ट कर सकते हैं जो प्रस्तुति के साथ उपयोग किए जाएँगे।

नीचे दिया गया JavaScript कोड दिखाता है कि आप [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) प्रॉपर्टी का कैसे उपयोग कर सकते हैं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // प्रस्तुति के साथ काम करें
    // CustomFont1, CustomFont2, और assets\fonts तथा global\fonts फ़ोल्डरों और उनके उपफ़ोल्डरों से फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**

Aspose.Slides [loadExternalFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) मेथड प्रदान करता है जिससे आप बाइनरी डेटा से बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

नीचे दिया गया JavaScript कोड बाइट एरे फ़ॉन्ट लोडिंग प्रक्रिया को प्रदर्शित करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // प्रस्तुति के जीवनकाल के दौरान लोड किया गया बाहरी फ़ॉन्ट
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

### क्या कस्टम फ़ॉन्ट्स सभी फ़ॉर्मेट्स (PDF, PNG, SVG, HTML) में एक्सपोर्ट को प्रभावित करते हैं?

हाँ। कनेक्टेड फ़ॉन्ट्स को रेंडरर सभी एक्सपोर्ट फ़ॉर्मेट्स में उपयोग करता है।

### क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से परिणामी PPTX में एम्बेड हो जाते हैं?

नहीं। रेंडरिंग के लिए फ़ॉन्ट रजिस्टर करना PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के भीतर ले जाना है, तो आपको स्पष्ट रूप से [embedding features](/slides/hi/nodejs-java/embedded-font/) का उपयोग करना होगा।

### क्या मैं कस्टम फ़ॉन्ट में कुछ ग्लाइफ़्स न होने पर फॉलबैक व्यवहार नियंत्रित कर सकता हूँ?

हाँ। आप [font substitution](/slides/hi/nodejs-java/font-substitution/), [replacement rules](/slides/hi/nodejs-java/font-replacement/), और [fallback sets](/slides/hi/nodejs-java/fallback-font/) को कॉन्फ़िगर करके यह निर्धारित कर सकते हैं कि अनुरोधित ग्लाइफ़ अनुपलब्ध होने पर कौन सा फ़ॉन्ट उपयोग किया जाए।

### क्या मैं Linux/Docker कंटेनर्स में फ़ॉन्ट्स को सिस्टम‑वाइड इंस्टॉल किए बिना उपयोग कर सकता हूँ?

हाँ। अपने स्वयं के फ़ॉन्ट फ़ोल्डर की ओर इशारा करें या बाइट एरे से फ़ॉन्ट्स लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरी पर किसी भी निर्भरता को हटाया जाता है।

### लाइसेंसिंग के बारे में क्या—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंध के एम्बेड कर सकता हूँ?

आप फ़ॉन्ट लाइसेंसिंग अनुपालन के लिए जिम्मेदार हैं। शर्तें भिन्न होती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें।