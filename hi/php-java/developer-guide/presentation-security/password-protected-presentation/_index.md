---
title: PHP में प्रस्तुति पर पासवर्ड सुरक्षा
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/php-java/password-protected-presentation/
keywords:
- पासवर्ड-सुरक्षित प्रस्तुति
- ओपनिंग पासवर्ड
- PowerPoint एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति पासवर्ड वैध करें
- प्रस्तुति पासवर्ड जाँचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP में Aspose.Slides के साथ पासवर्ड-सुरक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पहचानें, वैध करें, खोलें और डिक्रिप्ट करें।"
---
## **सारांश**

एक ओपनिंग पासवर्ड एक प्रस्तुति को एन्क्रिप्ट करता है। सही पासवर्ड आवश्यक होता है ताकि प्रस्तुति की सामग्रियों को लोड और देखा जा सके, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

ओपनिंग पासवर्ड लिखने-से-रक्षा पासवर्ड से अलग होता है। लिखने की सुरक्षा संशोधन को प्रतिबंधित करती है लेकिन सामग्री को एन्क्रिप्ट नहीं करती और प्रस्तुति को लोड होने से नहीं रोकती। प्रस्तुतियों को संशोधित करने के पासवर्ड को प्रबंधित करने के लिए देखें [Write-Protect Presentations](/slides/hi/php-java/write-protected-presentation/)।

नीचे के वर्कफ़्लो दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों फॉर्मेट का उपयोग करते हैं जहाँ उनकी फ़ाइल-आधारित और स्ट्रीम-आधारित व्यवहार महत्वपूर्ण है।

## **एक ओपनिंग पासवर्ड के साथ प्रस्तुति को एन्क्रिप्ट करें**

[ProtectionManager::encrypt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#encrypt) का उपयोग करके ओपनिंग पासवर्ड असाइन करें। फिर [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) का उपयोग करके एन्क्रिप्टेड प्रस्तुति को सहेजें।

निम्न उदाहरण PPTX प्रस्तुति को एन्क्रिप्ट करता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **एक एन्क्रिप्टेड प्रस्तुति लोड करें**

[LoadOptions::setPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setPassword) को ओपनिंग पासवर्ड पर सेट करें और फ़ाइल लोड करते समय विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) को पास करें। यदि ओपनिंग पासवर्ड आवश्यक है लेकिन प्रदान किया गया पासवर्ड अनुपलब्ध या गलत है तो लोडिंग विफल हो जाएगी।

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # डिक्रिप्टेड प्रस्तुति के साथ काम करें।
} finally {
    $presentation->dispose();
}
```

## **एक प्रस्तुति से एन्क्रिप्शन हटाएँ**

प्रस्तुति को उसके ओपनिंग पासवर्ड के साथ लोड करें, [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#removeEncryption) को कॉल करें, और परिणाम को सहेजें। सहेजी गई प्रस्तुति को फिर पासवर्ड के बिना लोड किया जा सकता है।

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **लोड करने से पहले ओपनिंग पासवर्ड को वैध बनाएँ**

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करके पूर्ण प्रस्तुति इंस्टेंस बनाए बिना [PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/) प्राप्त करें। पासवर्ड का अनुरोध या वैधता जांचने से पहले [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#isPasswordProtected) को जांचें। जब सुरक्षा मौजूद हो, प्रदान किए गए मान को [PresentationInfo::checkPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#checkPassword) से वैध करें।

### **फ़ाइल‑पाथ वर्कफ़्लो**

निम्न उदाहरण PPTX फ़ाइल के लिए ओपनिंग पासवर्ड को वैध करता है, वैध मान को [LoadOptions::setPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setPassword) में पास करता है, और फिर पूर्ण प्रस्तुति को लोड करता है:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **स्ट्रीम वर्कफ़्लो**

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) का स्ट्रीम ओवरलोड वही वर्कफ़्लो प्रदान करता है। उस स्ट्रीम से पूर्ण प्रस्तुति लोड करने से पहले खोज योग्य स्ट्रीम की स्थिति रीसेट करें।

निम्न उदाहरण PPT फ़ाइल का उपयोग करता है:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **checkPassword रिटर्न मान**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#checkPassword) केवल तभी `true` लौटाता है जब प्रस्तुति में ओपनिंग पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह इन मामलों में `false` लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में ओपनिंग पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड `null` या खाली है।

यह व्यवहार PPT और PPTX प्रस्तुतियों के लिए समान है।

## **जाँचें कि लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, स्रोत प्रस्तुति एन्क्रिप्टेड थी यह पुष्टि करने के लिए [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#isEncrypted) की जांच करें। लोड करने से पहले ओपनिंग‑पासवर्ड सुरक्षा को पहचानने के लिए ऊपर दिखाए अनुसार [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#isPasswordProtected) का उपयोग करें।

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **सुरक्षा सिफारिशें**
{{% alert color="warning" title="Security" %}}
ओपनिंग पासवर्ड को लॉग न करें या उन्हें निदान संदेशों में शामिल न करें। अनावश्यक बार-बार वैधता प्रयासों से बचें, पासवर्ड को मेमोरी में केवल आवश्यक अवधि तक रखें, और प्रस्तुति को तुरंत लोड करते समय सफल वैधता परिणाम को पुनः उपयोग करें।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड‑सुरक्षित बनाएँ**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
2. प्रस्तुति चुनें या अपलोड करें।
3. व्यू सुरक्षा के लिए पासवर्ड दर्ज करें।
4. वैकल्पिक रूप से संपादन सुरक्षा के लिए एक अलग पासवर्ड दर्ज करें।
5. सुरक्षा लागू करें और प्राप्त फ़ाइल डाउनलोड करें।

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/hi/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**एक ओपनिंग पासवर्ड और एक लिखने‑से‑रक्षा पासवर्ड में क्या अंतर है?**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री लोड करने के लिए आवश्यक है। एक लिखने‑से‑रक्षा पासवर्ड सामग्री को एन्क्रिप्ट किए बिना संशोधन को प्रतिबंधित करता है।

**क्या मैं सभी स्लाइड्स लोड किए बिना ओपनिंग पासवर्ड की वैधता जाँच सकता हूँ?**

हाँ। प्रस्तुति जानकारी प्राप्त करें, जाँचें कि ओपनिंग‑पासवर्ड सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनाने से पहले पासवर्ड को वैध करें।

**क्या पासवर्ड‑जाँच वर्कफ़्लो दोनों PPT और PPTX को समर्थन देते हैं?**

हाँ। फ़ाइल‑पाथ और स्ट्रीम‑आधारित पासवर्ड पहचान एवं वैधता PPT और PPTX प्रस्तुतियों के लिए समान रूप से कार्य करती है।