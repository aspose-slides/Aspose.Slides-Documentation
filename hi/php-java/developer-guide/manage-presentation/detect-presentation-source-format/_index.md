---
title: PHP में मूल प्रस्तुति फ़ॉर्मेट निर्धारित करें
linktitle: स्रोत फ़ॉर्मेट
type: docs
weight: 35
url: /hi/php-java/detect-presentation-source-format/
keywords:
- स्रोत फ़ॉर्मेट
- प्रस्तुति फ़ॉर्मेट का पता लगाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PHP में लोड की गई प्रस्तुति का मूल फ़ॉर्मेट पढ़ें, पहचान API की तुलना करें, और फ़ाइलों, स्ट्रीम, तथा लिगेसी फ़ॉर्मेट को संभालें।"
---
## **अवलोकन**

एक प्रस्तुति लोड करने के बाद, उसके मूल प्रारूप को निर्धारित करने के लिए [Presentation::getSourceFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSourceFormat) मेथड को कॉल करें। इसका उपयोग तब करें जब बाद की प्रक्रिया इस बात पर निर्भर करती है कि वर्तमान इंस्टेंस किस प्रारूप से लोड किया गया था।

SourceFormat वह प्रारूप है जो आउटपुट फ़ाइल के लिए चयनित [SaveFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) से अलग होता है। किसी अन्य फ़ॉर्मेट में सहेजने से मौजूदा इंस्टेंस का स्रोत फ़ॉर्मेट नहीं बदलता।

## **फ़ाइल की स्रोत प्रारूप पढ़ें**

यह उदाहरण एक मौजूदा `sample.pptx` फ़ाइल की आवश्यकता रखता है। यह फ़ाइल को लोड करता है और फ़ाइल नाम के बजाय [Presentation::getSourceFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSourceFormat) का उपयोग करके एप्लिकेशन प्रोसेसिंग नीति चुनता है। अन्य फ़ॉर्मेट आज़माने के लिये इनपुट पाथ बदलें। उदाहरण चयनित नीति को प्रिंट करता है; अपने एप्लिकेशन लॉजिक के साथ संदेश बदलें।

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **समर्थित मानों की पहचान करें**

[SourceFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sourceformat/) क्लास पूर्णांक स्थिरांक निर्धारित करती है जो नीचे दिए गए प्रस्तुति फ़ॉर्मेट को अलग करते हैं। नीचे दिखाए गए एक्सटेंशन पारंपरिक एक्सटेंशन हैं, मूल फ़ाइल नाम का पुनर्निर्माण नहीं हैं।

| SourceFormat मान | एक्सटेंशन | फ़ॉर्मेट |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 प्रस्तुति |
| `Pptx` | `.pptx` | Office Open XML प्रस्तुति |
| `Pptm` | `.pptm` | मैक्रो‑सक्षम Office Open XML प्रस्तुति |
| `Pps` | `.pps` | PowerPoint 97–2003 स्लाइड शो |
| `Ppsx` | `.ppsx` | Office Open XML स्लाइड शो |
| `Ppsm` | `.ppsm` | मैक्रो‑सक्षम Office Open XML स्लाइड शो |
| `Pot` | `.pot` | PowerPoint 97–2003 टेम्पलेट |
| `Potx` | `.potx` | Office Open XML टेम्पलेट |
| `Potm` | `.potm` | मैक्रो‑सक्षम Office Open XML टेम्पलेट |
| `Odp` | `.odp` | OpenDocument प्रस्तुति |
| `Otp` | `.otp` | OpenDocument प्रस्तुति टेम्पलेट |
| `Fodp` | `.fodp` | Flat XML ODF प्रस्तुति |
| `Xml` | `.xml` | PowerPoint XML प्रस्तुति |

## **स्ट्रीम की स्रोत प्रारूप पढ़ें**

यह उदाहरण एक मौजूदा `sample.pps` फ़ाइल की आवश्यकता रखता है। इसके बाइट्स को मेमोरी स्ट्रीम में पढ़ना ऐसे इनपुट का मॉडल बनाता है जिसमें फ़ाइल नाम नहीं होता, जैसे डेटाबेस मान या अपलोड किया गया बाइट एरे। [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) कंस्ट्रक्टर केवल स्ट्रीम प्राप्त करता है।

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS और POT एक ही बाइनरी फ़ॉर्मेट का उपयोग करते हैं। फ़ाइल पाथ से लोड करने पर एक्सटेंशन स्लाइड शो या टेम्पलेट को अलग करने में मदद कर सकता है। फ़ाइल नाम के बिना, लिगेसी PPS और POT सामग्री को `SourceFormat::Ppt` के रूप में रिपोर्ट किया जा सकता है; ऊपर दिया गया PPS उदाहरण `SourceFormat::Ppt` का पूर्णांक मान प्रिंट करता है।

यदि आपके एप्लिकेशन को यह अंतर बनाए रखना आवश्यक है, तो मूल फ़ाइल नाम या उपप्रकार मेटाडेटा को अलग से रखें। इन लिगेसी उपप्रकारों के लिये एक्सटेंशन एक उपयोगी संकेत है, लेकिन इसे केवल आधार नहीं बनाना चाहिए।

## **लोड करने से पहले और बाद में पहचान की तुलना करें**

फ़ाइल को पूरी प्रस्तुति ऑब्जेक्ट मॉडल में लोड करने से पहले निरीक्षण करने हेतु [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) और [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#getLoadFormat) का उपयोग करें। जब इंस्टेंस पहले से मौजूद हो तो [Presentation::getSourceFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSourceFormat) उपयोग करें।

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और क्रमशः `LoadFormat::Pptx` तथा `SourceFormat::Pptx` के पूर्णांक मान प्रिंट करता है। प्रोडक्शन में, अपने प्रोसेसिंग स्टेज के अनुसार उपयुक्त API चुनें; पहले से लोड किया गया प्रस्तुति स्रोत फ़ॉर्मेट प्राप्त करने के लिये अतिरिक्त निरीक्षण की आवश्यकता नहीं है।

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

परिणाम विभिन्न क्लासों से स्थिरांक उपयोग करते हैं: [LoadFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadformat/) और [SourceFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sourceformat/)। उनके संख्यात्मक मानों की तुलना न करें या यह न मानें कि प्रत्येक फ़ॉर्मेट के पास समान पहचान परिणाम हैं। PowerPoint XML को लोड करने से पहले `LoadFormat::Unknown` और लोड करने के बाद `SourceFormat::Xml` के रूप में रिपोर्ट किया जा सकता है।

## **स्रोत और आउटपुट फ़ॉर्मेट को अलग रखें**

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और `converted.odp` लिखता है। यह मूल इंस्टेंस को सहेजने से पहले और बाद दोनों में `SourceFormat::Pptx` का पूर्णांक मान प्रिंट करता है। केवल ODP आउटपुट से लोड किया गया नया इंस्टेंस `Odp` रिपोर्ट करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

`new Presentation()` से शून्य से बनाई गई प्रस्तुति `SourceFormat::Pptx` रिपोर्ट करती है। इसका कोई इनपुट फ़ाइल नहीं होता: यह नव निर्मित इंस्टेंस का डिफ़ॉल्ट मान है, यह संकेत नहीं है कि PPTX फ़ाइल लोड हुई है। यदि यह अंतर महत्वपूर्ण है तो अपने एप्लिकेशन में यह ट्रैक रखें कि इंस्टेंस बनाया गया या लोड किया गया।

## **स्रोत फ़ॉर्मेट को एक्सटेंशन में मैप करें**

निम्नलिखित उदाहरण को `sample.pptx` की आवश्यकता है। यह प्रत्येक वर्तमान में समर्थित [SourceFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sourceformat/) मान को पारंपरिक एक्सटेंशन में मैप करता है, बिना इनपुट फ़ाइल नाम को पार्स किए। फ़ॉलबैक अनपहचाने मान के लिये अनजाने में एक्सटेंशन असाइन करने से बचाता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

यह मैपिंग फ़ाइल को परिवर्तित नहीं करती या स्ट्रीम लोडिंग के दौरान खोए हुए लिगेसी PPS/POT उपप्रकार को पुनर्प्राप्त नहीं करती। वास्तविक सहेजने के लिये स्पष्ट रूप से [SaveFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) चुनें, या [Save Presentations in Their Original Format](/slides/hi/php-java/save-presentation/#save-presentations-in-their-original-format) में दिखाए गए रूपांतरण का उपयोग करें।

## **सेव और पुनः खोलकर फ़ॉर्मेट की पुष्टि करें**

यह स्वतंत्र उदाहरण एक प्रस्तुति बनाता है और कार्य निर्देशिका में तीन फ़ाइलें लिखता है, समान नाम वाली फ़ाइलों को ओवरराइट करता है। यह प्रत्येक आउटपुट को पाथ तथा मेमोरी स्ट्रीम दोनों से पुनः खोलता है। PPTX और ODP के लिये, दोनों मार्ग सहेजे गए फ़ॉर्मेट को रिपोर्ट करते हैं। PPS के लिये, पाथ से लोड करने पर `Pps` रिपोर्ट होता है, जबकि फ़ाइल नाम के बिना समान बाइट्स लोड करने पर `Ppt` रिपोर्ट होता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

निम्न तालिका मिलते-जुलते एक्सटेंशन वाली प्रस्तुतियों के स्रोत‑फ़ॉर्मेट पहचान को संक्षेप में दर्शाती है। नामों में स्थिरांक दर्शाए गए हैं; PHP उदाहरण उनके पूर्णांक मान प्रिंट करते हैं:

| सहेजा गया फ़ॉर्मेट | फ़ाइल पाथ से SourceFormat | नामरहित स्ट्रीम से SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` क्रमशः | फ़ाइल पाथ समान |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` क्रमशः | फ़ाइल पाथ समान |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` क्रमशः | फ़ाइल पाथ समान |
| ODP, OTP | `Odp`, `Otp` क्रमशः | फ़ाइल पाथ समान |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT सामग्री को नामरहित स्ट्रीम के लिये `Ppt` के रूप में पहचाना जाता है। तालिका फ़ॉर्मेट पहचान को दर्शाती है, न कि रूपांतरण के दौरान प्रत्येक प्रस्तुति फीचर के संरक्षण को।

## **अक्सर पूछे जाने वाले प्रश्न**

**ODP में सहेजने से PPTX से लोड किए गए प्रस्तुति का स्रोत फ़ॉर्मेट बदलता है क्या?**  
नहीं। मौजूदा इंस्टेंस अभी भी `Pptx` रिपोर्ट करता है। सहेजे गए ODP फ़ाइल से लोड किया गया इंस्टेंस `Odp` रिपोर्ट करता है।

**क्या स्ट्रीम हमेशा लिगेसी प्रस्तुति, स्लाइड शो और टेम्पलेट को अलग पहचान सकता है?**  
नहीं। PPT, PPS और POT समान बाइनरी फ़ॉर्मेट साझा करते हैं। जब यह अंतर आवश्यक हो तो फ़ाइल नाम या उपप्रकार मेटाडेटा को अलग से रखें।

**यदि प्रस्तुति पहले से लोड हो चुकी है तो कौन सा API उपयोग करना चाहिए?**  
[Presentation::getSourceFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSourceFormat) पढ़ें। लोड करने से पहले निरीक्षण के लिये [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करें।