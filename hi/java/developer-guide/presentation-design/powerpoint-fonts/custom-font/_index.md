---
title: Java में PowerPoint फ़ॉन्ट्स को कस्टमाइज़ करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/java/custom-font/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint स्लाइड्स में फ़ॉन्ट्स को कस्टमाइज़ करें ताकि आपकी प्रस्तुतियों को किसी भी डिवाइस पर तेज़ और सुसंगत रखा जा सके।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर स्थापित किए। आप फ़ॉन्ट्स को कस्टम फ़ोल्डरों से लोड कर सकते हैं, दस्तावेज़‑स्तर फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुतिकरण के लिए फ़ॉन्ट प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुतिकरण को रेंडर या एक्सपोर्ट किया जाता है, उदाहरण के लिए PDF, छवियों और अन्य समर्थित फ़ॉर्मैट्स में। इससे विभिन्न वातावरणों में प्रस्तुतिकरण आउटपुट सुसंगत रहता है। लेख में यह भी बताया गया है कि Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डरों की जाँच कैसे करें और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश कैसे साफ़ करें।

फ़ॉन्ट्स को रेंडरिंग के लिए पंजीकृत करना PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि फ़ॉन्ट को स्वयं प्रस्तुतिकरण में संग्रहीत करना आवश्यक है, तो एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

{{% alert color="primary" %}} 
Aspose Slides आपको इन फ़ॉन्ट्स को [loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड का उपयोग करके लोड करने की अनुमति देता है:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।
{{% /alert %}}

## **कस्टम फ़ॉन्ट्स लोड करें**

Aspose.Slides आपको फ़ॉन्ट्स को स्थापित किए बिना ही प्रस्तुतिकरण में उपयोग करने की सुविधा देता है। यह निर्यात आउटपुट—जैसे PDF, छवियां और अन्य समर्थित फ़ॉर्मैट्स—को प्रभावित करता है, जिससे उत्पन्न दस्तावेज़ विभिन्न वातावरणों में समान दिखते हैं। फ़ॉन्ट्स को कस्टम डायरेक्टरियों से लोड किया जाता है।

1. उन फ़ोल्डरों को निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें हों।
2. उन फ़ोल्डरों से फ़ॉन्ट्स लोड करने के लिए स्थैतिक [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड को कॉल करें।
3. प्रस्तुतिकरण को लोड और रेंडर/एक्सपोर्ट करें।
4. फ़ॉन्ट कैश को साफ़ करने के लिए [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsLoader#clearCache--) को कॉल करें।

फ़ॉन्ट लोड करने की प्रक्रिया का प्रदर्शित निम्न कोड उदाहरण देखें:

```java
// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को परिभाषित करें।
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट लोड करें।
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/एक्सपोर्ट करें (जैसे PDF, छवियां, या अन्य फ़ॉर्मैट्स)।
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) फ़ॉन्ट खोज पथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता। फ़ॉन्ट्स इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पथ।
1. उन पथों को जो [FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/) के माध्यम से लोड किए गए हैं।
{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**
Aspose.Slides [getFontFolders](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#getFontFolders--) मेथड प्रदान करता है जिससे आप फ़ॉन्ट फ़ोल्डर खोज सकते हैं। यह मेथड `LoadExternalFonts` मेथड के माध्यम से जोड़े गए फ़ोल्डर तथा सिस्टम फ़ॉन्ट फ़ोल्डर को लौटाता है।

इस Java कोड में दिखाया गया है कि आप [getFontFolders](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#getFontFolders--) का उपयोग कैसे कर सकते हैं:

```java
// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जहाँ फ़ॉन्ट फ़ाइलें खोजी जाती हैं.
// ये वे फ़ोल्डर हैं जो LoadExternalFonts मेथड के माध्यम से और सिस्टम फ़ॉन्ट फ़ोल्डरों के द्वारा जोड़े गए हैं।
String[] fontFolders = FontsLoader.getFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**
Aspose.Slides [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी प्रदान करता है जिससे आप बाहरी फ़ॉन्ट्स निर्दिष्ट कर सकते हैं जो प्रस्तुति के साथ उपयोग किए जाएंगे।

इस Java कोड में दिखाया गया है कि आप [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी का उपयोग कैसे कर सकते हैं:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // प्रस्तुति के साथ काम करें
    // CustomFont1, CustomFont2, और assets\fonts एवं global\fonts फ़ोल्डरों और उनके सबफ़ोल्डरों के फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
} finally {
    if (pres != null) pres.dispose();
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**

Aspose.Slides [loadExternalFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) मेथड प्रदान करता है जिससे आप बाइनरी डेटा से बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

इस Java कोड में बाइट ऐरे फ़ॉन्ट लोड करने की प्रक्रिया दर्शाई गई है:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // प्रस्तुति के जीवनकाल के दौरान बाहरी फ़ॉन्ट लोड किया गया
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कस्टम फ़ॉन्ट सभी फ़ॉर्मैट्स (PDF, PNG, SVG, HTML) में निर्यात को प्रभावित करते हैं?**  
हाँ। कनेक्टेड फ़ॉन्ट्स रेंडरर द्वारा सभी निर्यात फ़ॉर्मैट्स में उपयोग किए जाते हैं।

**क्या कस्टम फ़ॉन्ट स्वचालित रूप से उत्पन्न PPTX में एम्बेड हो जाते हैं?**  
नहीं। रेंडरिंग के लिए फ़ॉन्ट पंजीकृत करना PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के भीतर रखना है, तो स्पष्ट रूप से [embedding features](/slides/hi/java/embedded-font/) का उपयोग करें।

**क्या मैं कस्टम फ़ॉन्ट में कुछ ग्लाइफ़्स न हों तो फॉलबैक व्यवहार नियंत्रित कर सकता हूँ?**  
हाँ। आप [font substitution](/slides/hi/java/font-substitution/), [replacement rules](/slides/hi/java/font-replacement/), और [fallback sets](/slides/hi/java/fallback-font/) को कॉन्फ़िगर करके यह निर्धारित कर सकते हैं कि अनुरोधित ग्लाइफ़ अनुपलब्ध होने पर कौन सा फ़ॉन्ट उपयोग किया जाए।

**क्या मैं Linux/Docker कंटेनरों में सिस्टम‑वाइड स्थापित किए बिना फ़ॉन्ट्स उपयोग कर सकता हूँ?**  
हाँ। अपने स्वयं के फ़ॉन्ट फ़ोल्डर की ओर इशारा करें या बाइट ऐरे से फ़ॉन्ट्स लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरी पर निर्भरता समाप्त हो जाती है।

**लाइसेंसिंग के बारे में—क्या मैं कोई भी कस्टम फ़ॉन्ट बिना प्रतिबंधों के एम्बेड कर सकता हूँ?**  
फ़ॉन्ट लाइसेंस अनुपालन की ज़िम्मेदारी आपके ऊपर है। शर्तें विभिन्न होती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग पर रोक लगाते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें。