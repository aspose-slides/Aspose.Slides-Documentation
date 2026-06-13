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
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint स्लाइड्स में फ़ॉन्ट्स को अनुकूलित करें, ताकि आपकी प्रस्तुतियाँ किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर इंस्टॉल किए। आप फ़ॉन्ट्स को कस्टम फ़ोल्डरों से लोड कर सकते हैं, विशेष प्रस्तुति के लिए दस्तावेज़‑स्तर फ़ॉन्ट स्रोतों के माध्यम से फ़ॉन्ट्स प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग प्रस्तुति को रेंडर या एक्सपोर्ट करते समय किया जाता है, उदाहरण के लिए PDF, छवियों और अन्य समर्थित फ़ॉर्मैट्स में। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट को सुसंगत रखने में मदद करता है। यह लेख Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डरों की जांच करने और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश को साफ़ करने के तरीके भी बताता है।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स का पंजीकरण PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि किसी फ़ॉन्ट को प्रस्तुति के भीतर ही संग्रहीत करना है, तो फ़ॉन्ट एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

{{% alert color="primary" %}} 
Aspose Slides आपको इन फ़ॉन्ट्स को लोड करने की सुविधा देता है [loadExternalFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड का उपयोग करके:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।
{{% /alert %}}

## **कस्टम फ़ॉन्ट लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग किए गए फ़ॉन्ट्स को सिस्टम पर इंस्टॉल किए बिना लोड करने की अनुमति देता है। यह एक्सपोर्ट आउटपुट को प्रभावित करता है—जैसे PDF, छवियां और अन्य समर्थित फ़ॉर्मैट्स—ताकि उत्पन्न दस्तावेज़ विभिन्न वातावरणों में सुसंगत दिखें। फ़ॉन्ट्स कस्टम डायरेक्टरियों से लोड किए जाते हैं।

1. फ़ॉन्ट फ़ाइलों वाले एक या अधिक फ़ोल्डरों को निर्दिष्ट करें।
2. स्थैतिक [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) मेथड को कॉल करके उन फ़ोल्डरों से फ़ॉन्ट्स लोड करें।
3. प्रेजेंटेशन को लोड और रेंडर/एक्सपोर्ट करें।
4. फ़ॉन्ट कैश को साफ़ करने के लिए [FontsLoader::clearCache](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#clearCache--) को कॉल करें।

फ़ॉन्ट लोडिंग प्रक्रिया को प्रदर्शित करने वाला निम्नलिखित कोड उदाहरण है:

```php
// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को निर्धारित करें।
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट्स लोड करें।
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/एक्सपोर्ट करें (जैसे PDF, छवियां, या अन्य फ़ॉर्मैट्स)।
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="नोट" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) फ़ॉन्ट खोज पथों में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन यह फ़ॉन्ट आरंभ क्रम को नहीं बदलता।  
फ़ॉन्ट्स इस क्रम में आरंभ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पाथ।
1. [FontsLoader](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/) के माध्यम से लोड किए गए पाथ।
{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**
Aspose.Slides [getFontFolders](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#getFontFolders--) मेथड प्रदान करता है जिससे आप फ़ॉन्ट फ़ोल्डर खोज सकें। यह मेथड `LoadExternalFonts` मेथड के माध्यम से जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर लौटाता है।

यह PHP कोड दिखाता है कि आप [getFontFolders](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#getFontFolders--) को कैसे उपयोग कर सकते हैं:

```php
# यह पंक्ति फ़ॉन्ट फ़ाइलों की खोज किए जाने वाले फ़ोल्डरों को आउटपुट करती है।
# यह फ़ोल्डर LoadExternalFonts मेथड और सिस्टम फ़ॉन्ट फ़ोल्डरों के माध्यम से जोड़े गए हैं।
$fontFolders = FontsLoader::getFontFolders();
```

## **प्रेजेंटेशन में उपयोग किए गए कस्टम फ़ॉन्ट्स निर्दिष्ट करें**
Aspose.Slides [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) मेथड प्रदान करता है जिससे आप प्रस्तुति के साथ उपयोग किए जाने वाले बाहरी फ़ॉन्ट्स निर्दिष्ट कर सकते हैं।

यह PHP कोड दिखाता है कि आप [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) मेथड को कैसे उपयोग कर सकते हैं:

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
    # CustomFont1, CustomFont2, और assets\fonts व global\fonts फ़ोल्डरों व उनके उपफ़ोल्डरों से फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**

Aspose.Slides [loadExternalFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) मेथड प्रदान करता है जिससे आप बाइनरी डेटा से बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

यह PHP कोड बाइट एरे फ़ॉन्ट लोडिंग प्रक्रिया को प्रदर्शित करता है:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कस्टम फ़ॉन्ट्स सभी फ़ॉर्मैट्स (PDF, PNG, SVG, HTML) में एक्सपोर्ट को प्रभावित करते हैं?**

हाँ। जुड़े हुए फ़ॉन्ट्स रेंडरर द्वारा सभी एक्सपोर्ट फ़ॉर्मैट्स में उपयोग किए जाते हैं।

**क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से परिणामी PPTX में एम्बेड हो जाते हैं?**

नहीं। रेंडरिंग के लिए फ़ॉन्ट पंजीकरण करना PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के अंदर ले जाना है, तो आपको स्पष्ट रूप से [embedding features](/slides/hi/php-java/embedded-font/) का उपयोग करना होगा।

**क्या मैं कस्टम फ़ॉन्ट में कुछ ग्लिफ़ नहीं होने पर फॉलबैक व्यवहार को नियंत्रित कर सकता हूं?**

हाँ। [font substitution](/slides/hi/php-java/font-substitution/), [replacement rules](/slides/hi/php-java/font-replacement/), और [fallback sets](/slides/hi/php-java/fallback-font/) को कॉन्फ़िगर करके आप यह निर्धारित कर सकते हैं कि अनुरोधित ग्लिफ़ गायब होने पर कौन सा फ़ॉन्ट उपयोग किया जाए।

**क्या मैं Linux/Docker कंटेनरों में फ़ॉन्ट्स को सिस्टम‑वाइड इंस्टॉल किए बिना उपयोग कर सकता हूं?**

हाँ। अपने स्वयं के फ़ॉन्ट फ़ोल्डरों की ओर इशारा करें या बाइट एरेज़ से फ़ॉन्ट लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरियों पर निर्भरता हट जाती है।

**लाइसेंसिंग के बारे में क्या—क्या मैं बिना प्रतिबंधों के किसी भी कस्टम फ़ॉन्ट को एम्बेड कर सकता हूं?**

आप फ़ॉन्ट लाइसेंस अनुशासन के लिए जिम्मेदार हैं। शर्तें अलग-अलग होती हैं; कुछ लाइसेंस एम्बेडिंग या वाणिज्यिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट के EULA की समीक्षा करें।