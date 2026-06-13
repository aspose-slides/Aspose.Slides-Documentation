---
title: Android पर PowerPoint फ़ॉन्ट्स को कस्टमाइज़ करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/androidjava/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाहरी फ़ॉन्ट
- फ़ॉन्ट लोड करें
- फ़ॉन्ट्स का प्रबंधन
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ Java के माध्यम से PowerPoint स्लाइड्स में फ़ॉन्ट्स को कस्टमाइज़ करें ताकि आपके प्रेज़ेंटेशन किसी भी डिवाइस पर स्पष्ट और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर स्थापित किए। आप कस्टम फ़ोल्डरों से फ़ॉन्ट्स लोड कर सकते हैं, दस्तावेज़‑स्तर फ़ॉन्ट स्रोतों के माध्यम से किसी विशेष प्रस्तुति के लिए फ़ॉन्ट्स प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुति को रेंडर या निर्यात किया जाता है, उदाहरण के लिए PDF, छवियों और अन्य समर्थित स्वरूपों में। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट को समान रखने में मदद करता है। लेख यह भी बताता है कि Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डरों की जाँच कैसे की जाए और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश को कैसे साफ़ किया जाए।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स को पंजीकृत करना PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि फ़ॉन्ट को प्रस्तुति के भीतर ही संग्रहीत करना आवश्यक है, तो फ़ॉन्ट एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

{{% alert color="primary" %}} 
Aspose Slides आपको इन फ़ॉन्ट्स को [loadExternalFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड का उपयोग करके लोड करने की अनुमति देता है:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।

{{% /alert %}}

## **कस्टम फ़ॉन्ट्स लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग होने वाले फ़ॉन्ट्स को सिस्टम पर स्थापित किए बिना लोड करने की अनुमति देता है। यह निर्यात आउटपुट—जैसे PDF, छवियां और अन्य समर्थित स्वरूप—को प्रभावित करता है ताकि उत्पन्न दस्तावेज़ विभिन्न वातावरणों में समान दिखें। फ़ॉन्ट्स कस्टम डायरेक्टरीज़ से लोड किए जाते हैं।

1. उन फ़ोल्डरों को निर्दिष्ट करें जिसमें फ़ॉन्ट फ़ाइलें मौजूद हों।  
2. स्थैतिक [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड को कॉल करके उन फ़ोल्डरों से फ़ॉन्ट्स लोड करें।  
3. प्रस्तुति को लोड और रेंडर/निर्यात करें।  
4. फ़ॉन्ट कैश को साफ़ करने के लिए [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontsLoader#clearCache--) को कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```java
// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डर्स को परिभाषित करें.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// कस्टम फ़ॉन्ट्स को निर्दिष्ट फ़ोल्डरों से लोड करें.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/निर्यात करें (उदा., PDF, छवियों, या अन्य स्वरूपों में).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) अतिरिक्त फ़ोल्डरों को फ़ॉन्ट खोज पथ में जोड़ता है, लेकिन फ़ॉन्ट प्रारम्भ क्रम को नहीं बदलता। फ़ॉन्ट्स इस क्रम में प्रारम्भ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पथ।  
1. वे पथ जो [FontsLoader](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/) के माध्यम से लोड किए गए हैं।

{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**
Aspose.Slides वह [getFontFolders](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) मेथड प्रदान करता है जिससे आप फ़ॉन्ट फ़ोल्डर खोज सकते हैं। यह मेथड `LoadExternalFonts` मेथड द्वारा जोड़े गए फ़ोल्डरों और सिस्टम फ़ॉन्ट फ़ोल्डरों को लौटाता है।

यह Java कोड दिखाता है कि आप [getFontFolders](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) को कैसे उपयोग कर सकते हैं:

```java
// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जहाँ फ़ॉन्ट फ़ाइलें खोजी जाती हैं.
// वे फ़ोल्डर LoadExternalFonts मेथड के माध्यम से जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर हैं.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**
Aspose.Slides वह [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी प्रदान करता है जिससे आप प्रस्तुति के साथ उपयोग किए जाने वाले बाहरी फ़ॉन्ट्स को निर्दिष्ट कर सकते हैं।

यह Java कोड दिखाता है कि आप [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी को कैसे उपयोग कर सकते हैं:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // प्रस्तुति के साथ कार्य करें
    // CustomFont1, CustomFont2, और assets\fonts और global\fonts फ़ोल्डरों तथा उनके उपफ़ोल्डरों के फ़ॉन्ट्स प्रस्तुति में उपलब्ध हैं
} finally {
    if (pres != null) pres.dispose();
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**

Aspose.Slides वह [loadExternalFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) मेथड प्रदान करता है जिससे आप बाइनरी डेटा से बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

यह Java कोड बाइट एरे फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // presentation के जीवनकाल के दौरान बाहरी फ़ॉन्ट लोड किया गया
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

**क्या कस्टम फ़ॉन्ट्स सभी स्वरूपों (PDF, PNG, SVG, HTML) के निर्यात को प्रभावित करते हैं?**

हाँ। जुड़े हुए फ़ॉन्ट्स रेंडरर द्वारा सभी निर्यात स्वरूपों में उपयोग किए जाते हैं।

**क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से उत्पन्न PPTX में एम्बेड हो जाते हैं?**

नहीं। रेंडरिंग के लिए फ़ॉन्ट पंजीकृत करने का अर्थ PPTX में एम्बेड करना नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के भीतर ले जाना है, तो आपको स्पष्ट रूप से [embedding features](/slides/hi/androidjava/embedded-font/) का उपयोग करना चाहिए।

**क्या मैं कस्टम फ़ॉन्ट में कुछ ग्लिफ़ न होने पर फ़ॉलबैक व्यवहार को नियंत्रित कर सकता हूँ?**

हाँ। आप [font substitution](/slides/hi/androidjava/font-substitution/), [replacement rules](/slides/hi/androidjava/font-replacement/) और [fallback sets](/slides/hi/androidjava/fallback-font/) को कॉन्फ़िगर करके यह निर्धारित कर सकते हैं कि अनुरोधित ग्लिफ़ के अनुपलब्ध होने पर कौन सा फ़ॉन्ट उपयोग किया जाएगा।

**क्या मैं Linux/Docker कंटेनर में फ़ॉन्ट्स को सिस्टम‑व्यापी स्थापित किए बिना उपयोग कर सकता हूँ?**

हाँ। अपनी स्वयं की फ़ॉन्ट फ़ोल्डर की ओर इशारा करें या फ़ॉन्ट्स को बाइट एरे से लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरीज़ पर निर्भरता समाप्त हो जाती है।

**लाइसेंसिंग के बारे में—क्या मैं किसी भी कस्टम फ़ॉन्ट को प्रतिबंधों के बिना एम्बेड कर सकता हूँ?**

आप फ़ॉन्ट लाइसेंसिंग अनुपालन के लिए जिम्मेदार हैं। शर्तें भिन्न होती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें।