---
title: PHP में PPT को PPTX में परिवर्तित करें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint बदलें
- प्रेज़ेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में लेगेसी PPT फ़ाइलों को PPTX में परिवर्तित करें। इसमें एकल फ़ाइल और बैच रूपांतरण, त्रुटि प्रबंधन, और सटीकता नोट्स के लिए PHP उदाहरण शामिल हैं।"
---
## **अवलोकन**

PPT पुरानी बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX नया Open XML फ़ॉर्मेट है। Aspose.Slides for PHP via Java Microsoft PowerPoint के बिना PPT फ़ाइल को लोड कर उसे PPTX के रूप में सहेज सकता है। यह लेख दिखाता है कि एक फ़ाइल या फ़ाइलों की डायरेक्टरी को कैसे परिवर्तित किया जाए और परिवर्तित करने के बाद क्या जांचना चाहिए।

## **PPT फ़ाइल को PPTX में परिवर्तित करें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास से लोड करें, फिर [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) को [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/#Pptx) के साथ कॉल करें। `finally` ब्लॉक प्रेज़ेंटेशन को डिस्पोज़ करता है और उसके संसाधनों को रिलीज़ करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// पुरानी PPT प्रस्तुति लोड करें।
$presentation = new Presentation("presentation.ppt");
try {
    // प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें।
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

फ़ाइल एक्सटेंशन स्वयं आउटपुट फ़ॉर्मेट को निर्धारित नहीं करता; यह कार्य [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/#Pptx) आर्गुमेंट करता है। यदि आपको मूल PPT फ़ाइल को बरकरार रखना है तो इनपुट और आउटपुट पाथ को अलग रखें।

## **एकाधिक PPT फ़ाइलों को परिवर्तित करें**

निम्नलिखित उदाहरण एक डायरेक्टरी में प्रत्येक `.ppt` फ़ाइल को परिवर्तित करता है। प्रत्येक फ़ाइल स्वतंत्र रूप से प्रोसेस होती है, इसलिए एक विफल परिवर्तन शेष बैच को नहीं रोकता।

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

प्रोडक्शन वर्कलोड के लिए, पूरी एक्सेप्शन को लॉग करें, निर्धारित करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और असफल फ़ाइल नामों को रीट्राई या रिव्यू क्यू में लिखें। खराब फ़ाइलें, पासवर्ड‑सुरक्षित फ़ाइलें जिन्हें आवश्यक पासवर्ड के बिना खोला गया है, पहुँच न योग्य पाथ, और अनसमर्थित कंटेंट सभी परिवर्तन को विफल कर सकते हैं। एन्क्रिप्टेड फ़ाइलों को लोड करने के लिए देखें [Password-Protected Presentations](/php-java/password-protected-presentation/)।

## **सटीकता और पुरानी विशेषताएँ**

परिवर्तन सामान्यतः स्लाइड्स, मास्टर, लेआउट, टेक्स्ट, शैप्स, इमेजेज, टेबल्स और चार्ट्स को संरक्षित रखता है। हालांकि, PPT और PPTX हर विशेषता को बिल्कुल समान तरीके से प्रस्तुत नहीं करते। कोई लेगेसी फीचर जिसका PPTX में समकक्ष नहीं है, या लाइब्रेरी द्वारा समर्थित नहीं है, उसे सामान्यीकृत, हटाया या अलग तरीके से दिखाया जा सकता है।

परिवर्तित फ़ाइल को तब जांचें जब उसमें एनीमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, दुर्लभ फ़ॉन्ट्स, या VBA मैक्रो शामिल हों। एक साधारण PPTX फ़ाइल मैक्रो‑एनेबल्ड फॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना आवश्यक हो तो उपयुक्त मैक्रो‑एनेबल्ड वर्कफ़्लो का उपयोग करें। यह भी सत्यापित करें कि आवश्यक फ़ॉन्ट्स और बाहरी संसाधन उस वातावरण में मौजूद हैं जहाँ बदलित प्रेज़ेंटेशन को खोला या रेंडर किया जाएगा।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामmatically पुनः खोलें और प्रमुख स्लाइड काउंट और कंटेंट की जाँच करें, फिर इच्छित व्यूअर में उसकी उपस्थिति और स्लाइड‑शो व्यवहार की तुलना करें। यह न मानें कि एक सफल [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) कॉल यह साबित करता है कि हर लेगेसी फीचर का सटीक PPTX प्रतिनिधित्व है।

## **PPTX कब उपयोग करें**

PPTX का उपयोग तब करें जब प्रस्तुति को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेजों के साथ काम करने वाले सिस्टमों के साथ साझा किया जाएगा, या ऐसी फ़ॉर्मेट में संग्रहीत किया जाएगा जो लेगेसी बाइनरी PPT की तुलना में निरीक्षण और पुनर्प्राप्ति में आसान हो। तब तक मूल PPT को संग्रह या रोलबैक कॉपी के रूप में रखें जब तक कि परिवर्तित प्रस्तुति आपके सटीकता जांचों को पास न कर ले।

यदि आपको PDF, HTML, इमेजेज, XPS, या कोई अन्य आउटपुट प्रकार चाहिए, तो सभी लक्ष्यों के संपादन योग्य PowerPoint फीचर्स को संरक्षित रखने की धारण करने के बजाय [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) में दिये गए फ़ॉर्मेट‑विशिष्ट मार्गदर्शन का उपयोग करें।

## **ऑनलाइन कन्वर्टर**

अवसरिक फ़ाइल या त्वरित तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। दोहराए जाने वाले परिवर्तन, बैच प्रोसेसिंग, या एप्लिकेशन‑लेवल एरर हैंडलिंग के लिए, PHP API का उपयोग करें।

## **संबंधित लेख**

- [PPT बनाम PPTX](/php-java/ppt-vs-pptx/)
- [PHP में प्रस्तुतियों को सहेजें](/php-java/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मेट्स](/php-java/supported-file-formats/)
- [PHP में प्रस्तुतियों को खोलें](/php-java/open-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में बदल सकता हूँ?**

हाँ। Aspose.Slides for PHP via Java Microsoft PowerPoint की आवश्यकता बिना प्रस्तुति फ़ाइलों को लोड और सहेजता है।

**क्या PPT‑to‑PPTX परिवर्तन सभी सामग्री को बिल्कुल समान रखेगा?**

यह सामान्य प्रस्तुति सामग्री को संरक्षित रखता है, लेकिन हर लेगेसी या असमर्थित फीचर की सटीक सटीकता की गारंटी नहीं देता। उत्पन्न फ़ाइल की समीक्षा करें जब उसमें मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशेष एनीमेशन, या दुर्लभ फ़ॉन्ट्स हों।

**क्या मैं पासवर्ड‑सुरक्षित PPT फ़ाइल को बदल सकता हूँ?**

हाँ, यदि आप फ़ाइल को लोड करते समय सही पासवर्ड प्रदान करते हैं। गायब या गलत पासवर्ड लोड ऑपरेशन को विफल कर देता है।

**क्या मुझे परिवर्तन के बाद PPT फ़ाइल को हटाना चाहिए?**

मूल फ़ाइल को तब तक रखें जब तक आप PPTX को उन व्यूअर और वर्कफ़्लो में सत्यापित न कर लें जो आपके लिए महत्वपूर्ण हैं। इससे यदि कोई लेगेसी फीचर अलग तरीके से बदलता है तो आप रोलबैक कॉपी रख सकेंगे।