---
title: PHP में प्रस्तुतियों को सहेजें
linktitle: प्रस्तुति सहेजें
type: docs
weight: 80
url: /hi/php-java/save-presentation/
keywords:
- PowerPoint सहेजें
- OpenDocument सहेजें
- प्रस्तुति सहेजें
- स्लाइड सहेजें
- PPT सहेजें
- PPTX सहेजें
- ODP सहेजें
- फ़ाइल में प्रस्तुति
- स्ट्रीम में प्रस्तुति
- पूर्वनिर्धारित दृश्य प्रकार
- स्ट्रिक्ट Office Open XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रीफ़्रेश करना
- सहेजने की प्रगति
- PHP
- Aspose.Slides
description: "PHP में Aspose.Slides के साथ PowerPoint और OpenDocument प्रस्तुतियों को फ़ाइलों या स्ट्रीम में सहेजें, और PPTX आउटपुट तथा प्रगति रिपोर्टिंग को कॉन्फ़िगर करें।"
---
## **अवलोकन**

जब आप एक प्रस्तुति बनाते हैं या [एक मौजूदा खोलें](/slides/hi/php-java/open-presentation/), तो परिणाम लिखने के लिए [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) मेथड का उपयोग करें। Aspose.Slides for PHP via Java एक प्रस्तुति को PowerPoint, OpenDocument, PDF और अन्य फॉर्मेट में फ़ाइल या स्ट्रीम में सहेज सकता है। निम्नलिखित सेक्शन में मानक सहेजने के ऑपरेशन्स और PPTX आउटपुट के लिए उपलब्ध विकल्पों को कवर किया गया है।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

किसी प्रस्तुति को फ़ाइल में सहेजने के लिए, आउटपुट पाथ और एक [SaveFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) मान को [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) मेथड को पास करें। फॉर्मेट मान यह निर्धारित करता है कि Aspose.Slides किस प्रकार की फ़ाइल बनाता है।

निम्नलिखित उदाहरण एक प्रस्तुति बनाता है और उसे PPTX फ़ाइल के रूप में सहेजता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // प्रस्तुति सामग्री यहाँ जोड़ें या संशोधित करें।

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अपनी मूल प्रारूप में प्रस्तुतियों को सहेजें**

फ़ाइल और स्ट्रीम डिटेक्शन उदाहरणों, नई बनाई गई प्रस्तुतियों के व्यवहार, और स्रोत व आउटपुट फॉर्मेट के अंतर के लिए देखें [मूल प्रस्तुति प्रारूप निर्धारित करें](/slides/hi/php-java/detect-presentation-source-format/)।

बैच‑प्रोसेसिंग एप्लिकेशन में इनपुट फॉर्मेट पहले से ज्ञात नहीं हो सकता। फ़ाइल लोड करने के बाद उसका मूल फॉर्मेट [Presentation::getSourceFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSourceFormat) मेथड से पढ़ें। प्राप्त [SourceFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sourceformat/) मान को [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideutil/#toSaveFormat) को पास करके संबंधित [SaveFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) मान प्राप्त करें, और फिर संशोधित प्रस्तुति को लिखने के लिए [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) का प्रयोग करें।

निम्नलिखित पूर्ण उदाहरण इनपुट डायरेक्टरी में प्रत्येक फ़ाइल को प्रोसेस करता है, उसका शीर्षक अपडेट करता है, और जिस फॉर्मेट से वह लोड हुई थी, उसी फॉर्मेट में आउटपुट डायरेक्टरी में सहेजता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideutil/#toSaveFormat) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP और PowerPoint XML को उनके संबंधित प्रस्तुति सहेजने के फॉर्मेट में मैप करता है। यह केवल प्रस्तुति स्रोत फॉर्मेट को मैप करता है; PDF, HTML, TIFF या इमेज जैसी एक्सपोर्ट फॉर्मेट चुनने के लिए नहीं है। असमर्थित या अमान्य [SourceFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sourceformat/) मान पास करने पर एक [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) उत्पन्न होता है।

Legacy PPT, PPS और POT फ़ाइलें समान बाइनरी कंटेनर का उपयोग करती हैं। जब ऐसी प्रस्तुति को किसी फ़ाइल एक्सटेंशन के बिना स्ट्रीम से लोड किया जाता है, तो एक PPS या POT फ़ाइल को PPT के रूप में पहचाना जा सकता है। यदि इन लेगेसी सबटाइप को संरक्षित करना आवश्यक है, तो मूल फ़ाइलनाम या फॉर्मेट मेटाडेटा को अलग से रखें और आउटपुट फ़ाइलनाम व फॉर्मेट चुनते समय उनका उपयोग करें।

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

फ़ाइल पाथ पर निर्भर हुए बिना प्रस्तुति को लिखने के लिए, एक लिखने योग्य स्ट्रीम और एक [SaveFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) मान को [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) मेथड को पास करें। यह तरीका तब उपयोगी होता है जब आउटपुट को वेब सर्विस से लौटाना हो, डेटाबेस में संग्रहीत करना हो, या मेमोरी में प्रोसेस करना हो।

निम्नलिखित उदाहरण एक नई प्रस्तुति को फ़ाइल स्ट्रीम में सहेजता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **पूर्वनिर्धारित दृश्य प्रकार के साथ प्रस्तुतियों को सहेजें**

आप सहेजी गई प्रस्तुति को PowerPoint में प्रारंभिक रूप से किस दृश्य में खोलना है, यह निर्दिष्ट कर सकते हैं। सहेजने से पहले एक [ViewType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewtype/) मान के साथ [ViewProperties::setLastView](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/#setLastView) मेथड का उपयोग करें।

निम्नलिखित उदाहरण स्लाइड‑मास्टर दृश्य को प्रारम्भिक दृश्य के रूप में कॉन्फ़िगर करता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

एक ऐसा PPTX फ़ाइल बनाने के लिए जो Office Open XML के स्ट्रिक्ट प्रोफ़ाइल का पालन करता हो, एक [PptxOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxoptions/) इंस्टेंस बनाएं और उसके [PptxOptions::setConformance](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxoptions/#setConformance) मेथड को [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/php-java/aspose.slides/conformance/#Iso29500-2008-Strict) मान के साथ सेट करें। फिर विकल्पों को [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) मेथड को पास करें।

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Zip64 मोड में ऑफिस ओपन XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

एक मानक ZIP आर्काइव प्रत्येक एंट्री के संपीड़ित व असंपीड़ित आकार, कुल आर्काइव आकार और एंट्री की संख्या को सीमित करता है। चूँकि PPTX फ़ाइल एक ZIP आर्काइव है, बहुत बड़ी प्रस्तुति इन सीमाओं को पार कर सकती है। ZIP64 एक्सटेंशन इन आकार व एंट्री‑काउंट सीमाओं को बढ़ाते हैं।

क्या ZIP64 एक्सटेंशन लिखना है, यह नियंत्रित करने के लिए [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxoptions/#setZip64Mode) मेथड का उपयोग करें:

- [IfNecessary](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zip64mode/#IfNecessary) केवल तब ZIP64 का उपयोग करता है जब प्रस्तुति मानक ZIP सीमाओं से अधिक हो। यह डिफ़ॉल्ट मोड है।
- [Never](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zip64mode/#Never) ZIP64 एक्सटेंशन को बंद कर देता है।
- [Always](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zip64mode/#Always) हमेशा ZIP64 एक्सटेंशन लिखता है।

निम्नलिखित उदाहरण आउटपुट प्रस्तुति के लिए हमेशा ZIP64 एक्सटेंशन सक्षम करता है:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
यदि [Zip64Mode::Never](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zip64mode/#Never) का उपयोग किया जाता है और प्रस्तुति मानक ZIP सीमाओं में फिट नहीं होती, तो सहेजने का ऑपरेशन एक [PptxException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxexception/) फेंकेगा।
{{% /alert %}}

## **संपीड़न स्तरों के साथ ऑफिस ओपन XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

PPTX आउटपुट के लिए आप [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxoptions/#setCompressionLevel) मेथड का उपयोग करके सहेजने की गति और फ़ाइल आकार के बीच संतुलन बना सकते हैं। [CompressionLevel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/) क्लास निम्न मान प्रदान करता है:

- [None](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#None) डेटा को बिना संपीड़न के संग्रहीत करता है।
- [Level1](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level1) सबसे तेज़ संपीड़न और सबसे बड़ा संपीड़ित आउटपुट देता है।
- [Level2](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level2) से [Level5](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level5) तक क्रमशः छोटा आउटपुट लेकिन धीमी सहेजने की गति को प्राथमिकता देते हैं।
- [Level6](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level6) सहेजने की गति और फ़ाइल आकार के बीच संतुलन रखता है। यह डिफ़ॉल्ट स्तर है।
- [Level7](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level7) और [Level8](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level8) छोटे आउटपुट को अधिक प्राथमिकता देते हैं।
- [Level9](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level9) सबसे मजबूत संपीड़न प्रदान करता है और सबसे अधिक प्रोसेसिंग समय लेता है।

निम्नलिखित उदाहरण बिना संपीड़न के प्रस्तुति को सहेजता है:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

निम्नलिखित उदाहरण अधिकतम संपीड़न स्तर का उपयोग करता है:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **थंबनेल को रीफ्रेश किए बिना प्रस्तुतियों को सहेजें**

जब PPTX के रूप में प्रस्तुति सहेजी जाती है, तो [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) मेथड उसके डाक्यूमेंट थंबनेल को नियंत्रित करता है:

- `true` सहेजने के दौरान थंबनेल को पुनः उत्पन्न करता है। यह डिफ़ॉल्ट मान है।
- `false` मौजूदा थंबनेल को बरकरार रखता है। यदि प्रस्तुति में थंबनेल नहीं है, तो Aspose.Slides नया थंबनेल नहीं बनाता।

निम्नलिखित उदाहरण थंबनेल को रीफ्रेश किए बिना प्रस्तुति को सहेजता है:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
थंबनेल रीफ्रेश को अक्षम करने से PPTX फ़ाइल को सहेजने में लगने वाला समय कम हो सकता है।
{{% /alert %}}

## **प्रतिशत में सहेजने की प्रगति अपडेट करें**

सहेजने की प्रक्रिया की निगरानी करने के लिए, एक जावा प्रॉक्सी लागू करें जो [IProgressCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/) इंटरफ़ेस को इम्प्लीमेंट करे और इसे [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveoptions/#setProgressCallback) मेथड को पास करें। Aspose.Slides तब निर्यात के दौरान प्रगति मानों के साथ [IProgressCallback::reporting](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/#reporting-double-) मेथड को कॉल करता है।

निम्नलिखित उदाहरण PDF निर्यात की प्रगति को कंसोल पर रिपोर्ट करता है:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त [PowerPoint Splitter](https://products.aspose.app/slides/hi/splitter) प्रदान करता है जो Aspose.Slides API से बना है। यह चयनित स्लाइड्स को अलग-अलग PPT या PPTX फ़ाइलों के रूप में सहेजता है।
{{% /alert %}}

## **FAQ**

**क्या Aspose.Slides इंक्रीमेंटल या “फास्ट सेव” को सपोर्ट करता है?**

नहीं। प्रत्येक सहेजने का ऑपरेशन पूरा आउटपुट फ़ाइल लिखता है, न कि केवल बदल भागों को अपडेट करता है।

**क्या कई थ्रेड एक ही Presentation इंस्टेंस को सहेज सकते हैं?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ़ नहीं है](/slides/hi/php-java/multithreading/)। प्रत्येक इंस्टेंस को एक समय में केवल एक थ्रेड से एक्सेस और सहेजें।

**जब मैं प्रस्तुति सहेजता हूँ तो हाइपरलिंक और बाहरी लिंक वाली फ़ाइलों का क्या होता है?**

[हाइपरलिंक](/slides/hi/php-java/manage-hyperlinks/) प्रस्तुति में बने रहते हैं। Aspose.Slides बाहरी लिंक वाली फ़ाइलों को कॉपी नहीं करता, इसलिए सहेजी गई प्रस्तुति को अभी भी उन स्थानों तक पहुँचने में सक्षम होना चाहिए।

**क्या मैं लेखक, शीर्षक, कंपनी और निर्माण तिथि जैसी डॉक्यूमेंट मेटाडाटा को सहेज सकता हूँ?**

हां। सहेजने से पहले उपयुक्त [डॉक्यूमेंट प्रॉपर्टीज़](/slides/hi/php-java/presentation-properties/) सेट करें, और Aspose.Slides उन्हें आउटपुट फ़ाइल में लिखेगा।