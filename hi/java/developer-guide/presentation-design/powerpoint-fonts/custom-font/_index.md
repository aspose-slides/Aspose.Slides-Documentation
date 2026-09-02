---
title: जावा में PowerPoint फ़ॉन्ट्स को अनुकूलित करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/java/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाहरी फ़ॉन्ट
- फ़ॉन्ट लोड
- फ़ॉन्ट प्रबंधन
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint स्लाइड्स में फ़ॉन्ट्स को अनुकूलित करें ताकि आपकी प्रस्तुतियां किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **Overview**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर इंस्टॉल किए। आप फ़ॉन्ट्स को कस्टम फ़ोल्डरों से लोड कर सकते हैं, दस्तावेज़‑स्तर फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुति के लिए फ़ॉन्ट प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुति को रेंडर या एक्सपोर्ट किया जाता है, जैसे PDF, छवियों, और अन्य समर्थित फ़ॉर्मैट्स में। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट को सुसंगत रखता है। लेख यह भी बताता है कि Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डरों की जाँच कैसे करें और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश कैसे साफ़ करें।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स को पंजीकृत करना PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि फ़ॉन्ट को स्वयं प्रस्तुति में संग्रहीत करना आवश्यक है, तो एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

एक प्रस्तुति थीम व्यक्तिगत लिपि प्रणालियों के लिए विभिन्न फ़ॉन्ट परिवारों का संदर्भ दे सकती है। ये मैपिंग्स फ़ॉन्ट नामों को संग्रहित करती हैं लेकिन फ़ॉन्ट फ़ाइलों को इंस्टॉल या लोड नहीं करतीं। मैपिंग्स को प्रबंधित करने के लिए देखें [Script-Specific Theme Fonts](/slides/hi/java/script-specific-font-mappings/), और नीचे दी गई लोडिंग विकल्पों का उपयोग करके संदर्भित फ़ॉन्ट्स को सुसंगत रेंडरिंग के लिए उपलब्ध कराएँ।

{{% alert color="info" title="Note" %}}

Aspose Slides आपको इन फ़ॉन्ट्स को लोड करने की अनुमति देता है [loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड द्वारा:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides आपको प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट्स को सिस्टम पर इंस्टॉल किए बिना लोड करने देता है। यह निर्यात आउटपुट—जैसे PDF, छवियां, और अन्य समर्थित फ़ॉर्मैट्स—को प्रभावित करता है, जिससे उत्पन्न दस्तावेज़ विभिन्न वातावरणों में समान दिखते हैं। फ़ॉन्ट्स को कस्टम निर्देशिकाओं से लोड किया जाता है।

1. उन एक या अधिक फ़ोल्डरों को निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें हैं।  
2. स्थिर [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड को कॉल करके उन फ़ोल्डरों से फ़ॉन्ट्स लोड करें।  
3. प्रस्तुति को लोड एवं रेंडर/एक्सपोर्ट करें।  
4. फ़ॉन्ट कैश साफ़ करने के लिए [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsLoader#clearCache--) को कॉल करें।

निम्न कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```java
import com.aspose.slides.*;

// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को परिभाषित करें।
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट्स लोड करें।
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/एक्सपोर्ट करें (जैसे PDF, छवियों या अन्य फ़ॉर्मैट्स)।
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) अतिरिक्त फ़ोल्डरों को फ़ॉन्ट खोज पथ में जोड़ता है, लेकिन फ़ॉन्ट प्रारंभ क्रम को नहीं बदलता। फ़ॉन्ट्स का प्रारम्भिक क्रम इस प्रकार है:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पथ।  
1. [FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/) द्वारा लोड किए गए पथ।

{{%/alert %}}

## **Get Custom Font Folders**

Aspose.Slides [getFontFolders](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#getFontFolders--) मेथड प्रदान करता है जिससे आप फ़ॉन्ट फ़ोल्डर ढूंढ सकें। यह मेथड `LoadExternalFonts` मेथड के द्वारा जोड़े गए फ़ोल्डरों और सिस्टम फ़ॉन्ट फ़ोल्डरों को लौटाता है।

यह Java कोड दिखाता है कि आप [getFontFolders](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#getFontFolders--) कैसे उपयोग कर सकते हैं:

```java
import com.aspose.slides.*;

// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जहां फ़ॉन्ट फ़ाइलें खोजी जाती हैं。
// वे फ़ोल्डर LoadExternalFonts मेथड और सिस्टम फ़ॉन्ट फ़ोल्डरों के माध्यम से जोड़े गए हैं।
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Specify Custom Fonts Used with a Presentation**

Aspose.Slides [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी प्रदान करता है जिससे आप बाहरी फ़ॉन्ट्स निर्दिष्ट कर सकें जो प्रस्तुति के साथ उपयोग किए जाएंगे।

यह Java कोड दिखाता है कि आप [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी कैसे उपयोग कर सकते हैं:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // प्रस्तुति के साथ काम करें
    // CustomFont1, CustomFont2, तथा assets\fonts और global\fonts फ़ोल्डरों व उनके उपफ़ोल्डरों के फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manage Fonts Externally**

Aspose.Slides [loadExternalFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) मेथड प्रदान करता है जिससे आप बाइनरी डेटा से बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

यह Java कोड बाइट एरे फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // प्रस्तुति के जीवनकाल के दौरान लोड किया गया बाहरी फ़ॉन्ट
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?

हाँ। जुड़े फ़ॉन्ट्स रेंडरर द्वारा सभी निर्यात फ़ॉर्मैट्स में उपयोग किए जाते हैं।

### Are custom fonts automatically embedded into the resulting PPTX?

नहीं। रेंडरिंग के लिए फ़ॉन्ट पंजीकृत करना इसे PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के भीतर रखना है, तो स्पष्ट रूप से [embedding features](/slides/hi/java/embedded-font/) का उपयोग करें।

### Can I control fallback behavior when a custom font lacks certain glyphs?

हाँ। आवश्यक ग्लिफ़ अनुपलब्ध होने पर कौन सा फ़ॉन्ट उपयोग किया जाए, इसे परिभाषित करने के लिए [font substitution](/slides/hi/java/font-substitution/), [replacement rules](/slides/hi/java/font-replacement/) और [fallback sets](/slides/hi/java/fallback-font/) कॉन्फ़िगर करें।

### Can I use fonts in Linux/Docker containers without installing them system‑wide?

हाँ। अपने स्वयं के फ़ॉन्ट फ़ोल्डरों की ओर संकेत करें या बाइट एरे से फ़ॉन्ट्स लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरीज़ पर निर्भरता हट जाती है।

### What about licensing—can I embed any custom font without restrictions?

आप फ़ॉन्ट लाइसेंसिंग अनुपालन के लिए जिम्मेदार हैं। शर्तें विभिन्न होती हैं; कुछ लाइसेंस एम्बेडिंग या वाणिज्यिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले फ़ॉन्ट की EULA की हमेशा समीक्षा करें।