---
title: PHP में प्रस्तुतियों को पासवर्ड-प्रोटेक्ट करें
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/php-java/password-protected-presentation/
keywords:
- पासवर्ड-सुरक्षित प्रस्तुति
- खोलने वाला पासवर्ड
- PowerPoint एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति पासवर्ड को मान्य करें
- प्रस्तुति पासवर्ड जाँचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में पासवर्ड-सुरक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पहचान, मान्य, खोल और डिक्रिप्ट करें।"
---
## **अवलोकन**

एक खोलने वाला पासवर्ड एक प्रस्तुति को एन्क्रिप्ट करता है। प्रस्तुति सामग्री को लोड और देखने के लिए सही पासवर्ड आवश्यक है, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

एक खोलने वाला पासवर्ड लिखने-रक्षा पासवर्ड से अलग होता है। लिखने-रक्षा संशोधन को प्रतिबंधित करती है लेकिन सामग्री को एन्क्रिप्ट नहीं करती या प्रस्तुति को लोड होने से रोकती नहीं है। प्रस्तुतियों को संशोधित करने के पासवर्ड को प्रबंधित करने के लिए, देखें [Write-Protect Presentations](/slides/hi/php-java/write-protected-presentation/)।

नीचे दिए गए वर्कफ़्लो दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों स्वरूपों का उपयोग करते हैं जहाँ उनकी फ़ाइल-आधारित और स्ट्रीम-आधारित व्यवहार महत्वपूर्ण होता है।

## **एक खोलने वाले पासवर्ड से प्रस्तुति एन्क्रिप्ट करें**

एक खोलने वाला पासवर्ड निर्धारित करने के लिए [ProtectionManager::encrypt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#encrypt) का उपयोग करें। फिर एन्क्रिप्टेड प्रस्तुति को सुरक्षित करने के लिए [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) का उपयोग करें।

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

## **दस्तावेज़ गुण सार्वजनिक रखें**

डिफ़ॉल्ट रूप से, Aspose.Slides प्रस्तुति एन्क्रिप्शन में दस्तावेज़ गुण शामिल करता है। [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) मेथड इस व्यवहार को स्लाइड-सामग्री एन्क्रिप्शन से स्वतंत्र रूप से नियंत्रित करता है। जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़-प्रबंधन प्रणाली को खोलने वाला पासवर्ड बिना मेटाडेटा पढ़ना आवश्यक हो, तो [ProtectionManager::encrypt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#encrypt) को कॉल करने से पहले `false` पास करें।

निम्न उदाहरण एक एन्क्रिप्टेड PPTX प्रस्तुति बनाता है जबकि इसके встроित दस्तावेज़ गुण सार्वजनिक रखता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`false` को [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) में पास करने से स्लाइड्स, मास्टर्स, लेआउट्स, शैलियां, मीडिया, या अन्य प्रस्तुति सामग्री सार्वजनिक नहीं होती। यह केवल दस्तावेज़ गुणों को प्रभावित करता है। एन्क्रिप्टेड सामग्री लोड किए बिना उन गुणों को पढ़ने के लिए, देखें [Manage Presentation Properties](/slides/hi/php-java/presentation-properties/)।

## **एन्क्रिप्टेड प्रस्तुति लोड करें**

फ़ाइल लोड करते समय [LoadOptions::setPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setPassword) को खोलने वाले पासवर्ड पर सेट करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) को पास करें। लोडिंग तब विफल होती है जब खोलने वाला पासवर्ड आवश्यक हो लेकिन प्रदान किया गया पासवर्ड अनुपस्थित या गलत हो।

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

## **एक प्रस्तुति से एन्क्रिप्शन हटाएं**

प्रस्तुति को उसके खोलने वाले पासवर्ड के साथ लोड करें, फिर [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#removeEncryption) को कॉल करें और परिणाम को सहेजें। सहेजी गई प्रस्तुति को अब पासवर्ड के बिना लोड किया जा सकता है।

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

## **लोड करने से पहले खोलने वाले पासवर्ड को मान्य करें**

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करके पूर्ण प्रस्तुति इंस्टेंस बनाए बिना [PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/) प्राप्त करें। पासवर्ड का अनुरोध करने या वैध करने से पहले [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#isPasswordProtected) जाँचें। जब सुरक्षा मौजूद हो, तो प्रदान किए गए मान को [PresentationInfo::checkPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#checkPassword) से मान्य करें।

### **फ़ाइल-पाथ वर्कफ़्लो**

निम्न उदाहरण PPTX फ़ाइल के लिए खोलने वाले पासवर्ड को मान्य करता है, मान्य किए गए मान को [LoadOptions::setPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setPassword) को पास करता है, और फिर पूर्ण प्रस्तुति लोड करता है:

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

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) का स्ट्रीम ओवरलोड वही वर्कफ़्लो प्रदान करता है। उस स्ट्रीम से पूर्ण प्रस्तुति लोड करने से पहले एक सर्चेबल स्ट्रीम की स्थिति रीसेट करें।

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

### **checkPassword वापसी मान**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#checkPassword) `true` तब ही देता है जब प्रस्तुति में खोलने वाला पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह `false` प्रत्येक निम्नलिखित मामलों में देता है:

- पासवर्ड गलत है।
- प्रस्तुति में खोलने वाला पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड `null` या खाली है।

यह व्यवहार PPT और PPTX प्रस्तुतियों के लिए समान है।

## **जाँचें कि लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, स्रोत प्रस्तुति एन्क्रिप्टेड थी यह सुनिश्चित करने के लिए [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#isEncrypted) देखें। लोड करने से पहले खोलने वाले पासवर्ड सुरक्षा का पता लगाने के लिए, ऊपर दिखाए अनुसार [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#isPasswordProtected) का उपयोग करें।

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

## **सुरक्षा सिफ़ारिशें**

{{% alert color="warning" title="Security" %}}
खोलने वाले पासवर्ड को लॉग न करें या उन्हें निदान संदेशों में शामिल न करें। अनावश्यक दोहराए गए मान्यकरण प्रयासों से बचें, पासवर्ड को मेमोरी में केवल आवश्यक समय तक रखें, और प्रस्तुति को तुरंत लोड करते समय सफल मान्यकरण परिणाम को पुन: उपयोग करें।

सार्वजनिक दस्तावेज़ गुण लेखक के नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी और कस्टम मानों का खुलासा कर सकते हैं, भले ही प्रस्तुति सामग्री एन्क्रिप्टेड हो। संवेदनशील मेटाडेटा को प्रस्तुति के साथ एन्क्रिप्ट करें। गुणों को सार्वजनिक रखने का निर्णय केवल तब स्पष्ट रूप से लेना चाहिए जब सिस्टम को फ़ाइल को बिना खोलने वाले पासवर्ड के इंडेक्स, वर्गीकृत, खोज या प्रबंधित करना आवश्यक हो।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड-प्रोटेक्ट करें**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
2. प्रस्तुति चुनें या अपलोड करें।
3. व्यू सुरक्षा के लिए पासवर्ड दर्ज करें।
4. वैकल्पिक रूप से संपादन सुरक्षा के लिए एक अलग पासवर्ड दर्ज करें।
5. सुरक्षा लागू करें और परिणामी फ़ाइल डाउनलोड करें।

{{% alert color="info" title="See also" %}}
- [प्रस्तुतियों को लिखने से सुरक्षित करें](/slides/hi/php-java/write-protected-presentation/)
- [PowerPoint में डिजिटल सिग्नेचर](/slides/hi/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**खोलने वाले पासवर्ड और लिखने-रक्षा पासवर्ड में क्या अंतर है?**

एक खोलने वाला पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री को लोड करने के लिए आवश्यक होता है। एक लिखने-रक्षा पासवर्ड सामग्री को एन्क्रिप्ट किए बिना संशोधन को प्रतिबंधित करता है।

**क्या मैं सभी स्लाइड्स लोड किए बिना खोलने वाले पासवर्ड को मान्य कर सकता हूँ?**

हाँ। प्रस्तुति जानकारी प्राप्त करें, जांचें कि खोलने वाले पासवर्ड की सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनाने से पहले पासवर्ड को मान्य करें।

**क्या कोई एप्लिकेशन खोलने वाले पासवर्ड के बिना मेटाडेटा पढ़ सकता है?**

हाँ, लेकिन केवल तब जब प्रस्तुति को दस्तावेज़-गुण एन्क्रिप्शन अक्षम करके एन्क्रिप्ट किया गया हो। तब एप्लिकेशन को [Manage Presentation Properties](/slides/hi/php-java/presentation-properties/) में वर्णित केवल दस्तावेज़-गुण लोड करने के मोड का उपयोग करना होगा।

**क्या पासवर्ड जाँच वर्कफ़्लो दोनों PPT और PPTX को समर्थन देते हैं?**

हाँ। फ़ाइल-पाथ और स्ट्रीम-आधारित पासवर्ड पहचान और मान्यकरण दोनों PPT और PPTX प्रस्तुतियों के लिए समान व्यवहार करते हैं।