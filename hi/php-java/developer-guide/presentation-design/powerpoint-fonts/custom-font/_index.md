---
title: PHP में PowerPoint फ़ॉन्ट्स को अनुकूलित करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/php-java/custom-font/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP के माध्यम से Java का उपयोग करके PowerPoint स्लाइड्स में फ़ॉन्ट्स को अनुकूलित करें ताकि आपके प्रस्तुतियों किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर इंस्टॉल किए। आप कस्टम फ़ोल्डर्स से फ़ॉन्ट्स लोड कर सकते हैं, दस्तावेज़‑स्तर फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुति के लिए फ़ॉन्ट्स प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुति को रेंडर या निर्यात किया जाता है, उदाहरण के तौर पर PDF, इमेजेज़ और अन्य समर्थित फ़ॉर्मैट्स में। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट को सुसंगत रखने में मदद करता है। इस लेख में यह भी बताया गया है कि Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डर्स को कैसे जांचें और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश को कैसे साफ़ करें।

फ़ॉन्ट्स को रेंडरिंग के लिए पंजीकृत करना और फ़ॉन्ट्स को PPTX फ़ाइल में एम्बेड करना अलग प्रक्रियाएँ हैं। यदि फ़ॉन्ट को प्रस्तुति के भीतर संग्रहित करना आवश्यक है, तो फ़ॉन्ट एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

एक प्रस्तुति थीम विभिन्न लेखन प्रणालियों के लिए अलग‑अलग फ़ॉन्ट परिवारों का संदर्भ दे सकती है। ये मैपिंग्स फ़ॉन्ट नामों को संग्रहीत करती हैं लेकिन फ़ॉन्ट फ़ाइलों को इंस्टॉल या लोड नहीं करतीं। मैपिंग्स को प्रबंधित करने के लिए [Script-Specific Theme Fonts](/slides/hi/php-java/script-specific-font-mappings/) देखें, और नीचे दिए गए लोडिंग विकल्पों का उपयोग करके संदर्भित फ़ॉन्ट्स को सुसंगत रेंडरिंग के लिए उपलब्ध कराएँ।

{{% alert color="info" title="ध्यान दें" %}}

Aspose Slides आपको इन फ़ॉन्ट्स को [loadExternalFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड का उपयोग करके लोड करने की अनुमति देता है:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।
* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।

{{% /alert %}}

## **कस्टम फ़ॉन्ट्स लोड करें**

Aspose.Slides आपको प्रणाली पर फ़ॉन्ट्स को इंस्टॉल किए बिना प्रस्तुति में उपयोग होने वाले फ़ॉन्ट्स को लोड करने की अनुमति देता है। यह निर्यात आउटपुट—जैसे PDF, इमेजेज़ और अन्य समर्थित फ़ॉर्मैट्स—को प्रभावित करता है, जिससे उत्पन्न दस्तावेज़ विभिन्न वातावरणों में सुसंगत दिखते हैं। फ़ॉन्ट्स कस्टम डायरेक्टरीज़ से लोड किए जाते हैं।

1. उन फ़ोल्डर्स को निर्दिष्ट करें जिनमें फ़ॉन्ट फाइलें हों।
2. स्थिर [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड को कॉल करके उन फ़ोल्डर्स से फ़ॉन्ट्स लोड करें।
3. प्रस्तुति को लोड और रेंडर/निर्यात करें।
4. फ़ॉन्ट कैश को साफ़ करने के लिए [FontsLoader::clearCache](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#clearCache--) को कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```php
// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डर्स को परिभाषित करें।
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Load custom fonts from the specified folders.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/निर्यात करें (जैसे PDF, इमेजेज़, या अन्य फ़ॉर्मैट्स)।
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // काम समाप्त करने के बाद फ़ॉन्ट कैश साफ़ करें।
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="ध्यान दें" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) अतिरिक्त फ़ोल्डर्स को फ़ॉन्ट खोज पाथ में जोड़ता है, लेकिन फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता। फ़ॉन्ट्स इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पाथ।
1. [FontsLoader](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/) के माध्यम से लोड किए गए पाथ।

{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर्स प्राप्त करें**
Aspose.Slides [getFontFolders](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#getFontFolders--) मेथड प्रदान करता है ताकि आप फ़ॉन्ट फ़ोल्डर्स खोज सकें। यह मेथड `LoadExternalFonts` मेथड के माध्यम से जोड़े गए फ़ोल्डर्स और सिस्टम फ़ॉन्ट फ़ोल्डर्स को लौटाता है।

यह PHP कोड दिखाता है कि आप [getFontFolders](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#getFontFolders--) को कैसे उपयोग कर सकते हैं:

```php
# यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जहाँ फ़ॉन्ट फ़ाइलें खोजी जाती हैं।
# ये फ़ोल्डर LoadExternalFonts मेथड द्वारा जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर हैं।
$fontFolders = FontsLoader::getFontFolders();
```

## **प्रस्तुति के साथ उपयोग होने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**
Aspose.Slides [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) मेथड प्रदान करता है ताकि आप प्रस्तुति के साथ उपयोग होने वाले बाहरी फ़ॉन्ट्स को निर्दिष्ट कर सकें।

यह PHP कोड दिखाता है कि आप [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) को कैसे उपयोग कर सकते हैं:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # प्रस्तुति के साथ काम करें
    # CustomFont1, CustomFont2, और assets\fonts एवं global\fonts फ़ोल्डर्स तथा उनके उपफ़ोल्डर्स से फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**

Aspose.Slides [loadExternalFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) मेथड प्रदान करता है ताकि आप बाइनरी डेटा से बाहरी फ़ॉन्ट्स लोड कर सकें।

यह PHP कोड बाइट एरे फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # प्रस्तुति के जीवनकाल के दौरान बाहरी फ़ॉन्ट लोड किया गया
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **FAQ**

### क्या कस्टम फ़ॉन्ट्स सभी फ़ॉर्मैट्स (PDF, PNG, SVG, HTML) में निर्यात को प्रभावित करते हैं?

हाँ। कनेक्टेड फ़ॉन्ट्स को रेंडरर सभी निर्यात फ़ॉर्मैट्स में उपयोग करता है।

### क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से उत्पन्न PPTX में एम्बेड हो जाते हैं?

नहीं। रेंडरिंग के लिए फ़ॉन्ट को पंजीकृत करना इसका अर्थ नहीं है कि वह PPTX में एम्बेड हो गया। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के भीतर ले जाना है, तो स्पष्ट रूप से [embedding features](/slides/hi/php-java/embedded-font/) का उपयोग करना होगा।

### क्या मैं उन स्थितियों को नियंत्रित कर सकता हूँ जब कस्टम फ़ॉन्ट में कुछ ग्लाइफ़ न हों?

हाँ। [font substitution](/slides/hi/php-java/font-substitution/), [replacement rules](/slides/hi/php-java/font-replacement/) और [fallback sets](/slides/hi/php-java/fallback-font/) को कॉन्फ़िगर करके आप यह तय कर सकते हैं कि अनुरोधित ग्लाइफ़ अनुपलब्ध होने पर कौन सा फ़ॉन्ट उपयोग किया जाए।

### क्या मैं Linux/Docker कंटेनरों में सिस्टम‑व्यापी इंस्टॉल किए बिना फ़ॉन्ट्स उपयोग कर सकता हूँ?

हाँ। अपनी फ़ॉन्ट फ़ोल्डर्स की ओर संकेत करें या बाइट एरे से फ़ॉन्ट्स लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरी पर कोई निर्भरता नहीं रहती।

### लाइसेंसिंग के बारे में—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंधों के एम्बेड कर सकता हूँ?

आप फ़ॉन्ट लाइसेंसिंग अनुपालन के लिए स्वयं जिम्मेदार हैं। शर्तें विभिन्न होती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग पर रोक लगाते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की जाँच करें।