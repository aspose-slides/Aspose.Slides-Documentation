---
title: Android पर PowerPoint फ़ॉन्ट को कस्टमाइज़ करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Android के लिए Aspose.Slides के साथ Java के माध्यम से PowerPoint स्लाइड्स में फ़ॉन्ट कस्टमाइज़ करें ताकि आपके प्रेजेंटेशन किसी भी डिवाइस पर स्पष्ट और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट बिना ऑपरेटिंग सिस्टम पर इंस्टॉल किए उपयोग करने देता है। आप कस्टम फ़ोल्डर्स से फ़ॉन्ट लोड कर सकते हैं, दस्तावेज़‑स्तरीय फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुति के लिए फ़ॉन्ट प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट प्रस्तुति के रेंडर या निर्यात (जैसे PDF, इमेज, और अन्य समर्थित फ़ॉर्मेट) के समय उपयोग होते हैं। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट को सुसंगत रखने में मदद करता है। यह लेख यह भी बताता है कि Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डर कैसे जांचें और बाहरी फ़ॉन्ट के साथ काम करने के बाद फ़ॉन्ट कैश कैसे साफ़ करें।

रेंडरिंग के लिए कस्टम फ़ॉन्ट रजिस्टर करना PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि फ़ॉन्ट को प्रस्तुति के भीतर संग्रहीत करना हो, तो फ़ॉन्ट एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

{{% alert color="info" %}} 

Aspose Slides आपको ये फ़ॉन्ट निम्नलिखित मेथड से लोड करने देता है: [loadExternalFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।

{{% /alert %}}

## **कस्टम फ़ॉन्ट लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट को सिस्टम पर इंस्टॉल किए बिना लोड करने देता है। यह निर्यात आउटपुट—जैसे PDF, इमेज, और अन्य समर्थित फ़ॉर्मेट—को प्रभावित करता है, जिससे उत्पन्न दस्तावेज़ विभिन्न वातावरणों में सुसंगत दिखते हैं। फ़ॉन्ट कस्टम डायरेक्टरी से लोड होते हैं।

1. उन फ़ोल्डर्स को निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें हैं।
2. स्थिर मेथड [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) को कॉल करके उन फ़ोल्डरों से फ़ॉन्ट लोड करें।
3. प्रस्तुति को लोड और रेंडर/निर्यात करें।
4. फ़ॉन्ट कैश को साफ़ करने के लिए [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontsLoader#clearCache--) को कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```java
import com.aspose.slides.*;

// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को परिभाषित करें।
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Load custom fonts from the specified folders.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // लोड किए गए फ़ॉन्ट का उपयोग करके प्रस्तुति को रेंडर/निर्यात करें (जैसे PDF, इमेज, या अन्य फ़ॉर्मेट)।
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // कार्य समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) अतिरिक्त फ़ोल्डर को फ़ॉन्ट खोज पथ में जोड़ता है, परंतु फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता है। फ़ॉन्ट इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पाथ।
1. [FontsLoader](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/) द्वारा लोड किए गए पाथ।

{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**
Aspose.Slides [getFontFolders](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) मेथड प्रदान करता है जिससे आप फ़ॉन्ट फ़ोल्डर खोज सकते हैं। यह मेथड `LoadExternalFonts` मेथड के माध्यम से जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर लौटाता है।

यह Java कोड आपको दिखाता है कि कैसे [getFontFolders](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) का उपयोग करें:

```java
import com.aspose.slides.*;

// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जहाँ फ़ॉन्ट फ़ाइलों की खोज की जाती है.
// ये फ़ोल्डर LoadExternalFonts मेथड के द्वारा जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर हैं।
String[] fontFolders = FontsLoader.getFontFolders();
```

## **प्रेजेंटेशन में उपयोग किए जाने वाले कस्टम फ़ॉन्ट निर्दिष्ट करें**
Aspose.Slides [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी प्रदान करता है जिससे आप उन बाहरी फ़ॉन्ट को निर्दिष्ट कर सकते हैं जो प्रस्तुति के साथ उपयोग होंगे।

यह Java कोड आपको दिखाता है कि कैसे [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी का उपयोग करें:

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
    // प्रेज़ेंटेशन के साथ काम करें
    // CustomFont1, CustomFont2, और assets\fonts तथा global\fonts फ़ोल्डरों और उनके सबफ़ोल्डरों के फ़ॉन्ट प्रेज़ेंटेशन के लिए उपलब्ध हैं
} finally {
    if (pres != null) pres.dispose();
}
```

## **फ़ॉन्ट को बाहरी रूप से प्रबंधित करें**

Aspose.Slides [loadExternalFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) मेथड प्रदान करता है जिससे आप बाइनरी डेटा से बाहरी फ़ॉन्ट लोड कर सकते हैं।

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
        // प्रेज़ेंटेशन लाइफटाइम के दौरान बाहरी फ़ॉन्ट लोड किया गया
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या कस्टम फ़ॉन्ट सभी फ़ॉर्मेट्स (PDF, PNG, SVG, HTML) पर निर्यात को प्रभावित करते हैं?

हां। कनेक्टेड फ़ॉन्ट रेंडरर द्वारा सभी निर्यात फ़ॉर्मेट्स में उपयोग किए जाते हैं।

### क्या कस्टम फ़ॉन्ट स्वचालित रूप से परिणामी PPTX में एम्बेड हो जाते हैं?

नहीं। रेंडरिंग के लिए फ़ॉन्ट रजिस्टर्ड करना PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के भीतर रखना है, तो स्पष्ट रूप से [embedding features](/slides/hi/androidjava/embedded-font/) का उपयोग करना होगा।

### क्या मैं तब फॉलबैक व्यवहार नियंत्रित कर सकता हूँ जब कस्टम फ़ॉन्ट में कुछ glyph नहीं होते?

हां। आप [font substitution](/slides/hi/androidjava/font-substitution/), [replacement rules](/slides/hi/androidjava/font-replacement/), और [fallback sets](/slides/hi/androidjava/fallback-font/) को कॉन्फ़िगर कर सकते हैं ताकि अनुरोधित glyph नहीं मिलने पर कौन सा फ़ॉन्ट उपयोग होगा, इसे परिभाषित किया जा सके।

### क्या मैं Linux/Docker कंटेनर में फ़ॉन्ट को सिस्टम‑वाइड इंस्टॉल किए बिना उपयोग कर सकता हूँ?

हां। अपने स्वयं के फ़ॉन्ट फ़ोल्डर की ओर इशारा करें या बाइट एरे से फ़ॉन्ट लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरी पर किसी भी निर्भरता को हटाया जा सकता है।

### लाइसेंसिंग के बारे में—क्या मैं बिना प्रतिबंध के कोई भी कस्टम फ़ॉन्ट एम्बेड कर सकता हूँ?

आप फ़ॉन्ट लाइसेंस अनुपालन के लिए जिम्मेदार हैं। शर्तें विविध होती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले फ़ॉन्ट की EULA की हमेशा समीक्षा करें।