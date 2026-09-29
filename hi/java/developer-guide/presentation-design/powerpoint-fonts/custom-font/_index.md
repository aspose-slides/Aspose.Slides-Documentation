---
title: Java में PowerPoint फ़ॉन्ट्स को कस्टमाइज़ करें
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
description: "Java के लिए Aspose.Slides के साथ PowerPoint स्लाइड्स में फ़ॉन्ट्स को कस्टमाइज़ करें ताकि आपकी प्रस्तुतियाँ किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **समीक्षा**

Aspose.Slides आपको प्रस्तुतीकरण में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर स्थापित किए। आप कस्टम फ़ोल्डरों से फ़ॉन्ट्स लोड कर सकते हैं, दस्तावेज़‑स्तर फ़ॉन्ट स्रोतों के माध्यम से किसी विशेष प्रस्तुति के लिए फ़ॉन्ट्स प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग प्रस्तुति के रेंडर या निर्यात (जैसे PDF, इमेज, और अन्य समर्थित फ़ॉर्मैट) के समय किया जाता है। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट को सुसंगत रखने में मदद करता है। लेख यह भी बताता है कि Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डर को कैसे निरीक्षण करें और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश को कैसे साफ़ करें।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स को पंजीकृत करना PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि फ़ॉन्ट को प्रस्तुति के भीतर संग्रहीत करना आवश्यक है, तो फ़ॉन्ट एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

एक प्रस्तुति थीम विभिन्न लेखन प्रणालियों के लिए अलग‑अलग फ़ॉन्ट परिवारों को संदर्भित कर सकती है। ये मैपिंग्स फ़ॉन्ट नामों को संग्रहीत करती हैं लेकिन फ़ॉन्ट फ़ाइलों को स्थापित या लोड नहीं करतीं। मैपिंग्स को प्रबंधित करने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/java/script-specific-font-mappings/), और नीचे दिए गए लोडिंग विकल्पों का उपयोग करके संदर्भित फ़ॉन्ट्स को सुसंगत रेंडरिंग के लिए उपलब्ध कराएँ।

{{% alert color="info" title="Note" %}}
Aspose Slides आपको इन फ़ॉन्ट्स को लोड करने की अनुमति देता है [loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड का उपयोग करके:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।

{{% /alert %}}

## **कस्टम फ़ॉन्ट्स लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट्स को सिस्टम पर स्थापित किए बिना लोड करने की अनुमति देता है। यह निर्यात आउटपुट (जैसे PDF, इमेज, और अन्य समर्थित फ़ॉर्मैट) को प्रभावित करता है, जिससे उत्पन्न दस्तावेज़ विभिन्न वातावरणों में सुसंगत दिखते हैं। फ़ॉन्ट्स कस्टम डायरेक्टरी से लोड किए जाते हैं।

1. फ़ॉन्ट फ़ाइलों वाले एक या अधिक फ़ोल्डरों को निर्दिष्ट करें।
2. उन फ़ोल्डरों से फ़ॉन्ट्स लोड करने के लिए स्थैतिक [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड कॉल करें।
3. प्रस्तुति को लोड और रेंडर/निर्यात करें।
4. फ़ॉन्ट कैश को साफ़ करने के लिए [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#clearCache--) कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```java
import com.aspose.slides.*;

// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को परिभाषित करें।
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट्स लोड करें।
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/निर्यात करें (जैसे PDF, इमेज, या अन्य फ़ॉर्मैट)।
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // काम समाप्त होने के बाद फ़ॉन्ट कैश को साफ़ करें।
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) फ़ॉन्ट खोज पथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन फ़ॉन्ट इनिशियलाइजेशन क्रम को नहीं बदलता।
फ़ॉन्ट्स इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पाथ।
1. [FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/) के माध्यम से लोड किए गए पाथ।

{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**
Aspose.Slides [getFontFolders](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#getFontFolders--) मेथड प्रदान करता है जिससे आप फ़ॉन्ट फ़ोल्डर खोज सकते हैं। यह मेथड `LoadExternalFonts` मेथड के माध्यम से जोड़े गए फ़ोल्डरों और सिस्टम फ़ॉन्ट फ़ोल्डरों को लौटाता है।

यह Java कोड दर्शाता है कि आप [getFontFolders](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#getFontFolders--) का उपयोग कैसे कर सकते हैं:

```java
import com.aspose.slides.*;

// यह पंक्ति फ़ॉन्ट फ़ाइलों की खोज वाले फ़ोल्डरों को आउटपुट करती है.
// वे फ़ोल्डर हैं जो LoadExternalFonts मेथड और सिस्टम फ़ॉन्ट फ़ोल्डरों के माध्यम से जोड़े गए हैं।
String[] fontFolders = FontsLoader.getFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**
Aspose.Slides [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी प्रदान करता है जिससे आप बाहरी फ़ॉन्ट्स को निर्दिष्ट कर सकते हैं जो प्रस्तुति के साथ उपयोग होंगे।

यह Java कोड दर्शाता है कि आप [setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) प्रॉपर्टी का उपयोग कैसे कर सकते हैं:

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
    // CustomFont1, CustomFont2, और assets\fonts & global\fonts फ़ोल्डर और उनके सबफ़ोल्डर से फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
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

### क्या कस्टम फ़ॉन्ट्स सभी फ़ॉर्मैट्स (PDF, PNG, SVG, HTML) में निर्यात को प्रभावित करते हैं?

हाँ। कनेक्टेड फ़ॉन्ट्स को रेंडरर द्वारा सभी निर्यात फ़ॉर्मैट्स में उपयोग किया जाता है।

### क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से परिणामस्वरूप PPTX में एम्बेड हो जाते हैं?

नहीं। रेंडरिंग के लिए फ़ॉन्ट पंजीकृत करना इसे PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल में सम्मिलित करने की आवश्यकता है, तो आपको स्पष्ट रूप से [embedding features](/slides/hi/java/embedded-font/) का उपयोग करना चाहिए।

### क्या मैं तब भी फ़ॉन्ट फॉलबैक व्यवहार को नियंत्रित कर सकता हूँ जब कस्टम फ़ॉन्ट में कुछ ग्लिफ़ न हों?

हाँ। इच्छित ग्लिफ़ अनुपलब्ध होने पर कौन सा फ़ॉन्ट उपयोग किया जाए, इसे परिभाषित करने के लिए [font substitution](/slides/hi/java/font-substitution/), [replacement rules](/slides/hi/java/font-replacement/) और [fallback sets](/slides/hi/java/fallback-font/) को कॉन्फ़िगर करें।

### क्या मैं Linux/Docker कंटेनर्स में फ़ॉन्ट्स को सिस्टम‑वाइड स्थापित किए बिना उपयोग कर सकता हूँ?

आंशिक रूप से। Aspose.Slides आपके अपने फ़ोल्डरों या बाइट एरे से फ़ॉन्ट्स का उपयोग कर सकता है बिना उन्हें स्थापित किए, लेकिन Java की फ़ॉन्ट सपोर्ट को इमेज में कम से कम एक स्थापित फ़ॉन्ट की आवश्यकता होती है। यदि कोई नहीं है, तो लोडिंग विफल हो जाती है और त्रुटि "Fontconfig head is null, check your fonts or fonts configuration" दिखती है। देखें [Deploy Fonts](/slides/hi/java/deploy-fonts/)।

### लाइसेंसिंग के बारे में क्या—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंधों के एम्बेड कर सकता हूँ?

आप फ़ॉन्ट लाइसेंसिंग अनुपालन के लिए जिम्मेदार हैं। शर्तें अलग‑अलग हो सकती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट के EULA की समीक्षा करें।