---
title: "Android पर PowerPoint फ़ॉन्ट अनुकूलित करें"
linktitle: "कस्टम फ़ॉन्ट"
type: docs
weight: 20
url: /hi/androidjava/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाहरी फ़ॉन्ट
- फ़ॉन्ट लोड करें
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ Java का उपयोग करके PowerPoint स्लाइड्स में फ़ॉन्ट अनुकूलित करें ताकि आपके प्रेज़ेंटेशन किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको ऑपरेटिंग सिस्टम पर फ़ॉन्ट स्थापित किए बिना प्रेज़ेंटेशन में कस्टम फ़ॉन्ट उपयोग करने की अनुमति देता है। आप फ़ॉन्ट को कस्टम फ़ोल्डरों से लोड कर सकते हैं, दस्तावेज़‑स्तर फ़ॉन्ट स्रोतों के माध्यम से विशिष्ट प्रेज़ेंटेशन के लिए फ़ॉन्ट प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट प्रेज़ेंटेशन के रेंडर या एक्सपोर्ट होने पर उपयोग किए जाते हैं, उदाहरण के लिए PDF, इमेज और अन्य समर्थित फ़ॉर्मैट्स में। यह विभिन्न परिवेशों में प्रेज़ेंटेशन आउटपुट को सुसंगत रखने में मदद करता है। लेख यह भी दर्शाता है कि Aspose.Slides द्वारा उपयोग किए गए फ़ॉन्ट फ़ोल्डरों की जाँच कैसे करें और बाहरी फ़ॉन्ट के साथ काम करने के बाद फ़ॉन्ट कैश कैसे साफ़ करें।

रेंडरिंग के लिए कस्टम फ़ॉन्ट पंजीकरण करना PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि फ़ॉन्ट को प्रेज़ेंटेशन के भीतर ही संग्रहित करना आवश्यक है, तो फ़ॉन्ट एम्बेडिंग सुविधाओं को स्पष्ट रूप से उपयोग करें।

एक प्रेज़ेंटेशन थीम व्यक्तिगत लेखन प्रणालियों के लिए अलग‑अलग फ़ॉन्ट परिवारों को संदर्भित कर सकती है। ये मैपिंग्स फ़ॉन्ट नाम संग्रहीत करती हैं लेकिन फ़ॉन्ट फ़ाइलों को स्थापित या लोड नहीं करतीं। मैपिंग्स को प्रबंधित करने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/androidjava/script-specific-font-mappings/), और नीचे दी गई लोडिंग विकल्पों का उपयोग करके संदर्भित फ़ॉन्ट को सुसंगत रेंडरिंग के लिए उपलब्ध कराएँ।

{{% alert color="info" title="Note" %}}
Aspose Slides आपको इन फ़ॉन्ट को [loadExternalFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड का उपयोग करके लोड करने की अनुमति देता है:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) फ़ॉन्ट। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **कस्टम फ़ॉन्ट लोड करें**

Aspose.Slides आपको प्रेज़ेंटेशन में उपयोग किए जाने वाले फ़ॉन्ट को सिस्टम पर इंस्टॉल किए बिना लोड करने की अनुमति देता है। यह एक्सपोर्ट आउटपुट को प्रभावित करता है—जैसे PDF, इमेज और अन्य समर्थित फ़ॉर्मैट्स—जिससे उत्पन्न दस्तावेज़ विभिन्न परिवेशों में सुसंगत दिखते हैं। फ़ॉन्ट कस्टम निर्देशिकाओं से लोड किए जाते हैं।

1. फ़ॉन्ट फ़ाइलों वाले एक या अधिक फ़ोल्डर निर्दिष्ट करें।
2. स्टैटिक [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड को कॉल करके उन फ़ोल्डरों से फ़ॉन्ट लोड करें.
3. प्रेज़ेंटेशन को लोड और रेंडर/एक्सपोर्ट करें.
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FontsLoader#clearCache--) को कॉल करके फ़ॉन्ट कैश साफ़ करें.

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

    // रेंडर/एक्सपोर्ट करें प्रेज़ेंटेशन को (जैसे PDF, इमेज, या अन्य फ़ॉर्मैट्स) लोड किए गए फ़ॉन्ट्स का उपयोग करके।
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) फ़ॉन्ट खोज पथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता।
फ़ॉन्ट इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पाथ.
1. [FontsLoader](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/) द्वारा लोड किए गए पथ.
{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**
Aspose.Slides [getFontFolders](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) मेथड प्रदान करता है जिससे आप फ़ॉन्ट फ़ोल्डर खोज सकते हैं। यह मेथड `LoadExternalFonts` मेथड के द्वारा जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर लौटाता है।

यह जावा कोड दर्शाता है कि आप [getFontFolders](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) को कैसे उपयोग करें:

```java
import com.aspose.slides.*;

// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जहाँ फ़ॉन्ट फ़ाइलें खोजी जाती हैं。
// ये फ़ोल्डर LoadExternalFonts मेथड और सिस्टम फ़ॉन्ट फ़ोल्डरों के माध्यम से जोड़े गये हैं।
String[] fontFolders = FontsLoader.getFontFolders();
```

## **प्रेज़ेंटेशन के साथ उपयोग होने वाले कस्टम फ़ॉन्ट निर्दिष्ट करें**
Aspose.Slides [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी प्रदान करता है जिससे आप उन बाहरी फ़ॉन्ट को निर्दिष्ट कर सकते हैं जो प्रेज़ेंटेशन के साथ उपयोग होंगे।

यह जावा कोड दिखाता है कि आप [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी को कैसे उपयोग करें:

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
    // CustomFont1, CustomFont2, तथा assets\fonts और global\fonts फ़ोल्डरों व उनके उपफ़ोल्डरों से फ़ॉन्ट प्रस्तुति के लिए उपलब्ध हैं
} finally {
    if (pres != null) pres.dispose();
}
```

## **फ़ॉन्ट को बाहरी रूप से प्रबंधित करें**
Aspose.Slides [loadExternalFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) मेथड प्रदान करता है जिससे आप बाइनरी डेटा से बाहरी फ़ॉन्ट लोड कर सकते हैं।

यह जावा कोड बाइट ऐरे फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

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

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या कस्टम फ़ॉन्ट सभी फ़ॉर्मैट्स (PDF, PNG, SVG, HTML) में एक्सपोर्ट को प्रभावित करते हैं?
हाँ। जुड़े हुए फ़ॉन्ट रेंडरर द्वारा सभी एक्सपोर्ट फ़ॉर्मैट्स में उपयोग किए जाते हैं।

### क्या कस्टम फ़ॉन्ट स्वचालित रूप से परिणामी PPTX में एम्बेड होते हैं?
नहीं। रेंडरिंग के लिए फ़ॉन्ट पंजीकरण करना इसे PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रेज़ेंटेशन फ़ाइल के अंदर ले जाना है, तो आपको स्पष्ट रूप से [embedding features](/slides/hi/androidjava/embedded-font/) का उपयोग करना होगा।

### क्या मैं कस्टम फ़ॉन्ट में कुछ ग्लिफ़ न होने पर फ़ॉलबैक व्यवहार को नियंत्रित कर सकता हूँ?
हाँ। आप [font substitution](/slides/hi/androidjava/font-substitution/), [replacement rules](/slides/hi/androidjava/font-replacement/), और [fallback sets](/slides/hi/androidjava/fallback-font/) को कॉन्फ़िगर करके यह निर्धारित कर सकते हैं कि अनुरोधित ग्लिफ़ अनुपलब्ध होने पर कौन सा फ़ॉन्ट उपयोग किया जाएगा।

### क्या मैं Linux/Docker कंटेनरों में फ़ॉन्ट्स को सिस्टम‑वाइड इंस्टॉल किए बिना उपयोग कर सकता हूँ?
हाँ। अपने फ़ॉन्ट फ़ोल्डर की ओर संकेत करें या बाइट ऐरे से फ़ॉन्ट लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरी पर निर्भरता समाप्त हो जाती है।

### लाइसेंसिंग के बारे में क्या—क्या मैं कोई भी कस्टम फ़ॉन्ट बिना प्रतिबंध के एम्बेड कर सकता हूँ?
आप फ़ॉन्ट लाइसेंस अनुपालन के लिए जिम्मेदार हैं। शर्तें बदलती हैं; कुछ लाइसेंस एम्बेडिंग या वाणिज्यिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट के EULA की समीक्षा करें।