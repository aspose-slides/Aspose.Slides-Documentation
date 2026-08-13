---
title: जावा में PowerPoint फ़ॉन्ट कस्टमाइज़ करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/java/custom-font/
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
- Java
- Aspose.Slides
description: "जावा के लिए Aspose.Slides के साथ PowerPoint स्लाइड्स में फ़ॉन्ट कस्टमाइज़ करें, ताकि आपकी प्रस्तुतियाँ किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर इंस्टॉल किए। आप कस्टम फ़ोल्डरों से फ़ॉन्ट्स लोड कर सकते हैं, दस्तावेज़‑स्तर फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुति के लिए फ़ॉन्ट्स प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग प्रस्तुति के रेंडर या निर्यात (जैसे PDF, छवियों और अन्य समर्थित फ़ॉर्मैट) के समय किया जाता है। यह विभिन्न वातावरणों में आउटपुट को सुसंगत रखने में मदद करता है। लेख यह भी बताता है कि Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डरों की जाँच कैसे की जाए और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश को कैसे साफ़ किया जाए।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स को पंजीकृत करना PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि फ़ॉन्ट को स्वयं प्रस्तुति में संग्रहित करना आवश्यक हो, तो फ़ॉन्ट एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

{{% alert color="info" %}} 
Aspose Slides आपको इन फ़ॉन्ट्स को [loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड का उपयोग करके लोड करने की सुविधा देता है:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।

{{% /alert %}}

## **कस्टम फ़ॉन्ट लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट्स को सिस्टम पर इंस्टॉल किए बिना लोड करने की अनुमति देता है। यह निर्यात आउटपुट (जैसे PDF, छवियाँ और अन्य समर्थित फ़ॉर्मैट) को प्रभावित करता है, जिससे निर्मित दस्तावेज़ विभिन्न पर्यावरणों में समान दिखते हैं। फ़ॉन्ट्स कस्टम डायरेक्टरीज़ से लोड किए जाते हैं।

1. उन फ़ोल्डरों को निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें मौजूद हैं।  
2. स्थैतिक [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड को कॉल करके उन फ़ोल्डरों से फ़ॉन्ट्स लोड करें।  
3. प्रस्तुति को लोड करके रेंडर/निर्यात करें।  
4. फ़ॉन्ट कैश को साफ़ करने के लिए [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsLoader#clearCache--) को कॉल करें।

निम्न कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```java
import com.aspose.slides.*;

// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को परिभाषित करें।
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट लोड करें।
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/निर्यात करें (जैसे PDF, छवियों या अन्य फ़ॉर्मैट में)।
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) फ़ॉन्ट खोज पाथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता।  
फ़ॉन्ट्स इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पाथ।  
1. [FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/) के माध्यम से लोड किए गए पाथ।

{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर्स प्राप्त करें**
Aspose.Slides [getFontFolders](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#getFontFolders--) मेथड प्रदान करता है जिससे आप फ़ॉन्ट फ़ोल्डर्स खोज सकते हैं। यह मेथड `LoadExternalFonts` मेथड के द्वारा जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर दोनों को लौटाता है।

यह Java कोड दिखाता है कि आप [getFontFolders](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#getFontFolders--) को कैसे उपयोग कर सकते हैं:

```java
import com.aspose.slides.*;

// यह पंक्ति फ़ॉन्ट फ़ाइलों के खोजे जाने वाले फ़ोल्डरों को आउटपुट करती है।
// ये फ़ोल्डर LoadExternalFonts मेथड और सिस्टम फ़ॉन्ट फ़ोल्डरों के द्वारा जोड़े गए हैं।
String[] fontFolders = FontsLoader.getFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट निर्दिष्ट करें**
Aspose.Slides [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी प्रदान करता है जिससे आप बाहरी फ़ॉन्ट्स को निर्दिष्ट कर सकते हैं जो प्रस्तुति के साथ उपयोग किए जाएंगे।

यह Java कोड दिखाता है कि आप [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी को कैसे उपयोग कर सकते हैं:

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
    // प्रस्तुति के साथ कार्य करें
    // CustomFont1, CustomFont2, और assets\fonts तथा global\fonts फ़ोल्डरों और उनके उपफ़ोल्डरों के फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
} finally {
    if (pres != null) pres.dispose();
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**

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

### क्या कस्टम फ़ॉन्ट्स सभी फ़ॉर्मैट (PDF, PNG, SVG, HTML) में निर्यात को प्रभावित करते हैं?

हाँ। कनेक्टेड फ़ॉन्ट्स रेंडरर द्वारा सभी निर्यात फ़ॉर्मैट में उपयोग किए जाते हैं।

### क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से परिणामी PPTX में एम्बेड हो जाते हैं?

नहीं। रेंडरिंग के लिए फ़ॉन्ट को पंजीकृत करना PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को फ़ाइल के भीतर रखना है, तो स्पष्ट रूप से [एम्बेडिंग सुविधाओं](/slides/hi/java/embedded-font/) का उपयोग करें।

### क्या मैं फ़ॉन्ट के कुछ ग्लिफ़ न होने पर फॉलबैक व्यवहार को नियंत्रित कर सकता हूँ?

हां। आप [फ़ॉन्ट प्रतिस्थापन](/slides/hi/java/font-substitution/), [रिप्लेसमेंट नियम](/slides/hi/java/font-replacement/) और [फ़ॉलबैक सेट](/slides/hi/java/fallback-font/) को कॉन्फ़िगर करके तय कर सकते हैं कि अनुरोधित ग्लिफ़ अनुपलब्ध होने पर कौन सा फ़ॉन्ट उपयोग किया जाएगा।

### क्या मैं Linux/Docker कंटेनर में बिना सिस्टम‑वाइड इंस्टॉल किए फ़ॉन्ट्स का उपयोग कर सकता हूँ?

हां। अपने स्वयं के फ़ॉन्ट फ़ोल्डर की ओर संकेत करें या बाइट एरे से फ़ॉन्ट्स लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरी पर निर्भरता समाप्त हो जाती है।

### लाइसेंसिंग के बारे में क्या—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंध के एम्बेड कर सकता हूँ?

आप फ़ॉन्ट लाइसेंस अनुपालन के लिए जिम्मेदार हैं। शर्तें अलग-अलग हो सकती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग पर रोक लगाते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें।