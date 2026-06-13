---
title: JavaScript में PowerPoint फ़ॉन्ट्स को अनुकूलित करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/nodejs-java/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाह्य फ़ॉन्ट
- फ़ॉन्ट लोड करें
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js के साथ Java के माध्यम से PowerPoint स्लाइड्स में फ़ॉन्ट्स को कस्टमाइज़ करें, ताकि आपकी प्रस्तुतियाँ किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम में स्थापित किए। आप कस्टम फ़ोल्डरों से फ़ॉन्ट लोड कर सकते हैं, दस्तावेज़-स्तर फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुति के लिए फ़ॉन्ट प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाह्य फ़ॉन्ट लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुति को रेंडर या निर्यात किया जाता है, उदाहरण के लिए PDF, चित्रों और अन्य समर्थित स्वरूपों में। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट को समान रखने में मदद करता है। यह लेख यह भी बताता है कि Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डरों की जाँच कैसे करें और बाह्य फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश को कैसे साफ़ करें।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स को पंजीकृत करना PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि फ़ॉन्ट को प्रस्तुति में ही संग्रहीत करना है, तो फ़ॉन्ट एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

{{% alert color="primary" %}} 
Aspose Slides आपको इन फ़ॉन्ट्स को [loadExternalFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड का उपयोग करके लोड करने की अनुमति देता है:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **कस्टम फ़ॉन्ट्स लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट्स को सिस्टम में स्थापित किए बिना लोड करने की अनुमति देता है। यह निर्यात आउटपुट को प्रभावित करता है—जैसे PDF, चित्र, और अन्य समर्थित स्वरूपों—ताकि परिणामी दस्तावेज़ विभिन्न वातावरणों में समान दिखें। फ़ॉन्ट्स कस्टम डायरेक्टरीज़ से लोड होते हैं।

1. फ़ॉन्ट फ़ाइलों वाले एक या अधिक फ़ोल्डर निर्दिष्ट करें।  
2. उन फ़ोल्डरों से फ़ॉन्ट लोड करने के लिए स्थैतिक [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) मेथड को कॉल करें।  
3. प्रस्तुति को लोड करें और रेंडर/निर्यात करें।  
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/clearcache/) को कॉल करके फ़ॉन्ट कैश साफ़ करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```js
// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को परिभाषित करें।
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट्स लोड करें।
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/निर्यात करें (उदाहरण के लिए, PDF, छवियों, या अन्य फ़ॉर्मेट में)।
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // काम समाप्त होने के बाद फ़ॉन्ट कैश को साफ़ करें।
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) फ़ॉन्ट खोज पथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन फ़ॉन्ट प्रारम्भ क्रम को नहीं बदलता है।  
फ़ॉन्ट्स इस क्रम में प्रारम्भ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पथ।  
1. [FontsLoader](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/) के माध्यम से लोड किए गए पथ।  
{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**
Aspose.Slides [getFontFolders](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) मेथड प्रदान करता है जो आपको फ़ॉन्ट फ़ोल्डर खोजने की अनुमति देता है। यह मेथड `LoadExternalFonts` मेथड और सिस्टम फ़ॉन्ट फ़ोल्डरों के माध्यम से जोड़े गए फ़ोल्डर लौटाता है।

यह जावास्क्रिप्ट कोड आपको दिखाता है कि [getFontFolders](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) का उपयोग कैसे करें:

```javascript
// यह पंक्ति फ़ॉन्ट फ़ाइलों की खोज किए जाने वाले फ़ोल्डरों को आउटपुट करती है.
// ये वे फ़ोल्डर हैं जो LoadExternalFonts मेथड तथा सिस्टम फ़ॉन्ट फ़ोल्डरों के माध्यम से जोड़े गए हैं।
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **प्रस्तुति के साथ उपयोग होने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**
Aspose.Slides [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) प्रॉपर्टी प्रदान करता है जो आपको प्रस्तुति के साथ उपयोग होने वाले बाहरी फ़ॉन्ट्स निर्दिष्ट करने की अनुमति देती है।

यह जावास्क्रिप्ट कोड आपको दिखाता है कि [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) प्रॉपर्टी का उपयोग कैसे करें:

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // प्रस्तुति के साथ काम करें
    // CustomFont1, CustomFont2, तथा assets\fonts और global\fonts फ़ोल्डरों व उनके उपफ़ोल्डरों से फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **फ़ॉन्ट्स को बाह्य रूप से प्रबंधित करें**
Aspose.Slides [loadExternalFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) मेथड प्रदान करता है जो आपको बाइनरी डेटा से बाह्य फ़ॉन्ट लोड करने की अनुमति देता है।

यह जावास्क्रिप्ट कोड बाइट एरे फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // प्रस्तुति के जीवनकाल के दौरान बाहरी फ़ॉन्ट लोड किया गया
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कस्टम फ़ॉन्ट्स सभी स्वरूपों (PDF, PNG, SVG, HTML) में निर्यात को प्रभावित करते हैं?**  
हाँ। कनेक्टेड फ़ॉन्ट्स को रेंडरर सभी निर्यात स्वरूपों में उपयोग करता है।

**क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से परिणामी PPTX में एम्बेड होते हैं?**  
नहीं। रेंडरिंग के लिए फ़ॉन्ट पंजीकृत करना इसे PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के भीतर रखना है, तो आपको स्पष्ट रूप से [embedding features](/slides/hi/nodejs-java/embedded-font/) का उपयोग करना चाहिए।

**क्या मैं कस्टम फ़ॉन्ट में कुछ glyphs न होने पर फॉलबैक व्यवहार को नियंत्रित कर सकता हूँ?**  
हाँ। आप [font substitution](/slides/hi/nodejs-java/font-substitution/), [replacement rules](/slides/hi/nodejs-java/font-replacement/), और [fallback sets](/slides/hi/nodejs-java/fallback-font/) को कॉन्फ़िगर करके यह निर्धारित कर सकते हैं कि अनुरोधित glyph न मिलने पर कौन सा फ़ॉन्ट उपयोग किया जाए।

**क्या मैं फ़ॉन्ट्स को Linux/Docker कंटेनरों में सिस्टम-व्यापी स्थापना के बिना उपयोग कर सकता हूँ?**  
हाँ। अपनी फ़ॉन्ट फ़ोल्डरों की ओर इशारा करें या बाइट एरे से फ़ॉन्ट लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरी पर निर्भरता हट जाती है।

**लाइसेंसिंग के बारे में क्या—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंध के एम्बेड कर सकता हूँ?**  
आप फ़ॉन्ट लाइसेंस अनुपालन के लिए ज़िम्मेदार हैं। शर्तें अलग-अलग हो सकती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग पर प्रतिबंध लगाते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें।