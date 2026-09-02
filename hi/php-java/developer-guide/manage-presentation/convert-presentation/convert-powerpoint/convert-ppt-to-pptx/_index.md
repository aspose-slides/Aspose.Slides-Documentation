---
title: PHP में PPT को PPTX में परिवर्तित करें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में लेगेसी PPT फ़ाइलों को PPTX में परिवर्तित करें। एकल फ़ाइल और बैच रूपांतरण, त्रुटि हैंडलिंग, और सटीकता नोट्स के लिए PHP उदाहरण शामिल हैं।"
---
## **अवलोकन**

PPT लेगेसी बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX नया Open XML फ़ॉर्मेट है। Aspose.Slides for PHP via Java Microsoft PowerPoint के बिना PPT फ़ाइल लोड कर सकता है और उसे PPTX में सहेज सकता है। यह लेख दिखाता है कि कैसे एक फ़ाइल या फ़ाइलों की डायरेक्टरी को बदलें और रूपांतरण के बाद क्या सत्यापित करना है।

## **PPT फ़ाइल को PPTX में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास से लोड करें, फिर [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) को [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/#Pptx) के साथ कॉल करें। `finally` ब्लॉक प्रस्तुति को समाप्त करता है और उसके संसाधनों को मुक्त करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// पुरानी PPT प्रस्तुति लोड करें.
$presentation = new Presentation("presentation.ppt");
try {
    // प्रस्तुति को PPTX प्रारूप में सहेजें.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

फ़ाइल एक्सटेंशन स्वयं आउटपुट फ़ॉर्मेट नहीं चुनता; यह [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/#Pptx) तर्क करता है। यदि आपको मूल PPT फ़ाइल रखनी है तो इनपुट और आउटपुट पाथ अलग रखें।

## **कई PPT फ़ाइलों को बदलें**

निम्नलिखित उदाहरण एक डायरेक्टरी में प्रत्येक `.ppt` फ़ाइल को बदलता है। प्रत्येक फ़ाइल स्वतंत्र रूप से प्रोसेस की जाती है, इसलिए एक विफल रूपांतरण बाकी बैच को नहीं रोकता।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

उत्पादन कार्यभार के लिए, पूरे अपवाद को लॉग करें, तय करें कि मौजूदा आउटपुट फ़ाइल को अधिलेखित किया जा सकता है या नहीं, और विफल फ़ाइल नामों को पुनः प्रयास या समीक्षा कतार में लिखें। क्षतिग्रस्त फ़ाइलें, पासवर्ड‑सुरक्षित फ़ाइलें बिना आवश्यक पासवर्ड के खुलना, पहुँच न योग्य पाथ, और असमर्थित सामग्री सभी रूपांतरण विफल कर सकते हैं। एन्क्रिप्टेड फ़ाइलें लोड करने के लिए [Password-Protected Presentations](/slides/hi/php-java/password-protected-presentation/) देखें।

## **सटीकता और लेगेसी फ़ीचर्स**

रूपांतरण सामान्यतः स्लाइड्स, मास्टर्स, लेआउट्स, टेक्स्ट, शेप्स, इमेजेज, टेबल्स और चार्ट्स को संरक्षित करता है। हालांकि, PPT और PPTX प्रत्येक फ़ीचर को बिल्कुल समान रूप में प्रस्तुत नहीं करते। एक लेगेसी फ़ीचर जिसका PPTX समतुल्य नहीं है, या जो लाइब्रेरी द्वारा समर्थित नहीं है, उसे सामान्यीकृत, छोड़ा या अलग तरह से प्रदर्शित किया जा सकता है।

परिवर्तित फ़ाइल को जांचें जब उसमें एनीमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, दुर्लभ फ़ॉन्ट्स, या VBA मैक्रो हों। एक साधारण PPTX फ़ाइल मैक्रो‑सक्षम फ़ॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना चाहिए तब उपयुक्त मैक्रो‑सक्षम वर्कफ़्लो उपयोग करें। साथ ही यह भी सत्यापित करें कि आवश्यक फ़ॉन्ट्स और बाहरी संसाधन उस वातावरण में मौजूद हैं जहाँ परिवर्तित प्रस्तुति खोली या रेंडर की जाएगी।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामेटिकली फिर से खोलें और प्रमुख स्लाइड संख्या और सामग्री की जाँच करें, फिर इसे इच्छित व्यूअर में उसके रूप और स्लाइड‑शो व्यवहार से तुलना करें। सफल [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) कॉल को यह प्रमाण न समझें कि प्रत्येक लेगेसी फ़ीचर का सटीक PPTX प्रतिनिधित्व है।

## **PPTX कब उपयोग करें**

PPTX का उपयोग तब करें जब प्रस्तुति को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेजों के साथ काम करने वाले सिस्टमों के साथ आदान‑प्रदान किया जाएगा, या ऐसे फ़ॉर्मेट में संग्रहीत किया जाएगा जो लेगेसी बाइनरी PPT की तुलना में निरीक्षण और पुनर्प्राप्ति में आसान हो। मूल PPT को एक अभिलेखीय या रोलबैक कॉपी के रूप में रखें जब तक कि परिवर्तित प्रस्तुति आपके सटीकता जांच पास न कर ले।

यदि आपको PDF, HTML, इमेजेज, XPS, या कोई अन्य आउटपुट प्रकार चाहिए, तो सभी लक्ष्यों को संपादन योग्य PowerPoint फीचर्स बनाए रखने की धारणा न रखें बल्कि [Convert Presentations to Multiple Formats](/slides/hi/php-java/convert-presentation/) में दिए गए फ़ॉर्मेट‑विशिष्ट मार्गदर्शन का उपयोग करें।

## **ऑनलाइन कनवर्टर**

कभी‑कभार फ़ाइल या त्वरित तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। दोहरावदार रूपांतरण, बैच प्रोसेसिंग, या एप्लिकेशन‑स्तर त्रुटि प्रबंधन के लिए, PHP API का उपयोग करें।

## **संबंधित लेख**

- [PPT बनाम PPTX](/slides/hi/php-java/ppt-vs-pptx/)
- [PHP में प्रस्तुतियों को सहेजें](/slides/hi/php-java/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मेट](/slides/hi/php-java/supported-file-formats/)
- [PHP में प्रस्तुतियों को खोलें](/slides/hi/php-java/open-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में बदल सकता हूँ?**

हाँ। Aspose.Slides for PHP via Java Microsoft PowerPoint की आवश्यकता के बिना प्रस्तुति फ़ाइलों को लोड और सहेजता है।

**क्या PPT‑to‑PPTX रूपांतरण सभी सामग्री को बिल्कुल सटीक रखेगा?**

यह सामान्य प्रस्तुति सामग्री को संरक्षित करता है, लेकिन प्रत्येक लेगेसी या असमर्थित फीचर के लिए सटीक सटीकता गारंटीकृत नहीं है। उत्पन्न फ़ाइल की समीक्षा करें जब उसमें मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशेष एनीमेशन, या दुर्लभ फ़ॉन्ट्स हों।

**क्या मैं पासवर्ड‑सुरक्षित PPT फ़ाइल को बदल सकता हूँ?**

हाँ, यदि फ़ाइल लोड करते समय आप सही पासवर्ड प्रदान करते हैं। अनुपस्थित या गलत पासवर्ड लोड ऑपरेशन को विफल कर देता है।

**क्या मुझे रूपांतरण के बाद PPT फ़ाइल को हटाना चाहिए?**

मूल फ़ाइल को तब तक रखें जब तक आप PPTX को उन व्यूअर और वर्कफ़्लो में सत्यापित न कर लें जो आपके लिए महत्वपूर्ण हैं। यदि कोई लेगेसी फीचर अलग रूप से बदला है तो यह एक रोलबैक कॉपी प्रदान करता है।