---
title: PHP में प्रस्तुति गुणों का प्रबंधन
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/php-java/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुति गुण
- दस्तावेज़ गुण
- बिल्ट‑इन गुण
- कस्टम गुण
- उन्नत गुण
- गुणों का प्रबंधन
- गुणों में संशोधन
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में प्रस्तुति गुणों को मास्टर करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सरल बनाएँ।"
---
## **परिचय**

Aspose.Slides for PHP via Java **बिल्ट‑इन** और **कस्टम** दस्तावेज़ गुणों का समर्थन करता है। इन गुणों का उपयोग करके आप प्रस्तुति मेटाडेटा पढ़ और अपडेट कर सकते हैं, जैसे लेखक, शीर्षक, और उपयोगकर्ता‑परिभाषित मान।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) क्लास के माध्यम से। इस क्लास की एक इंस्टेंस को [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) द्वारा लौटाया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ें, संशोधित करें और प्रबंधित करें। ये मानते हैं कि PHP/Java Bridge और Aspose.Slides PHP रैपर को प्रारंभ किया गया है।

{{% alert color="info" title="Note" %}}
जब प्रस्तुति को सहेजा जाता है तो Aspose.Slides एप्लिकेशन और निर्माता मेटाडेटा का प्रबंधन करता है; ये फ़ील्ड उस सॉफ़्टवेयर की पहचान करती हैं जिसने आउटपुट बनाया।
{{% /alert %}}

## **प्रस्तुति गुणों का प्रबंधन**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। वे दो श्रेणियों में विभाजित होते हैं:

- **बिल्ट‑इन गुण** मानक मेटाडेटा रखते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ आँकड़े।
- **कस्टम गुण** उपयोगकर्ता‑परिभाषित नाम/मान युग्म संग्रहीत करते हैं।

Aspose.Slides for PHP via Java दोनों श्रेणियों तक पहुँच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडेटा निरीक्षण करने के लिए **File → Info → Properties → Advanced Properties** चुनें। संवाद जानकारी को **Summary**, **Statistics**, **Contents**, और **Custom** जैसे टैब में समूहित करता है। उपयोगकर्ता‑परिभाषित गुणों को प्रबंधित करने के लिए **Custom** टैब का उपयोग करें।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक खोलने वाला पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुणों दोनों की सुरक्षा करता है। जब प्रस्तुति को [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) को `false` के साथ कॉल करने के बाद एन्क्रिप्ट किया जाता है, तो उसके दस्तावेज़ गुण सार्वजनिक रह जाते हैं। फिर एक एप्लिकेशन [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) को `true` के साथ कॉल करके खोलने वाला पासवर्ड प्रदान किए बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल किए गए हों, तो पासवर्ड के बिना उन्हें लोड करने पर विफल होता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड होती है।

उदाहरण को एक एन्क्रिप्टेड प्रस्तुति चाहिए जिसकी दस्तावेज़ गुण सार्वजनिक रूप से छोड़े गए हों। यह [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) के माध्यम से लोड मोड को सत्यापित करता है और फिर [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) के माध्यम से बिल्ट‑इन गुण पढ़ता है:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

इस मोड में स्लाइड सामग्री लोड नहीं होती। स्लाइड, मास्टर, लेआउट, शेप, मीडिया और अन्य प्रस्तुति ऑब्जेक्ट उपलब्ध नहीं होते। एप्लिकेशन को हमेशा [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) जांचना चाहिए जब कोई ऐसा ऑपरेशन किया जाए जिसमें पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="Warning" %}}
सार्वजनिक मेटाडेटा लेखक नाम, शीर्षक, विषय, कीवर्ड, कंपनी सूचना, टिप्पणी और कस्टम मान उजागर कर सकता है। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। उन्हें केवल तभी सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज या दस्तावेज़‑प्रबंधन प्रणाली को पासवर्ड के बिना एक्सेस करने की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुणों को अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) को `true` के साथ कॉल करने के बाद लोड की गई प्रस्तुति सार्वजनिक मेटाडेटा पढ़ने के लिए अभिप्रेत है। Aspose.Slides उस केवल‑मेटाडेटा ऑब्जेक्ट से बदले गए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ संगत रहना चाहिए। इसलिए उन्हें अपडेट करने के लिए सही खोलने वाला पासवर्ड और पूरी लोड आवश्यक है।

उदाहरण को एक एन्क्रिप्टेड PPTX प्रस्तुति चाहिए जिसमें सार्वजनिक दस्तावेज़ गुण और ज्ञात खोलने वाला पासवर्ड हो। यह [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) के साथ पूरी प्रस्तुति खोलता है, सार्वजनिक बिल्ट‑इन गुणों को अपडेट करता है, और परिणाम को सहेजता है। फिर यह [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isEncrypted) का उपयोग करके एन्क्रिप्शन बना रहने की पुष्टि करता है और सार्वजनिक मेटाडेटा को पासवर्ड के बिना पुनः खोलता है ताकि नए मानों की जाँच की जा सके:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

यदि कोई एप्लिकेशन प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं रखता, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने योग्य मानना चाहिए।

## **बिल्ट‑इन गुणों तक पहुँच**

[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) क्लास getter मेथड्स के माध्यम से बिल्ट‑इन मेटाडेटा उजागर करती है, जिसमें [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitle) और [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCreatedTime) शामिल हैं। यह उदाहरण मौजूदा प्रस्तुति खोलता है और उसके संग्रहीत मेटाडेटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड खाली हो सकते हैं।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

### **संस्करण संख्या और संपादन समय की रिपोर्ट**

`presentations` फ़ोल्डर में प्रत्येक PPTX फ़ाइल के लिए संस्करण संख्या और कुल संपादन समय की रिपोर्ट करने के लिए, [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) का उपयोग करके स्लाइड्स को संपादन के लिए लोड किए बिना उसके [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) को पढ़ें। PHP via Java API संपादन समय को मिलिसेकंड में लौटाता है। उदाहरण इसे घंटों, मिनटों और सेकंड में परिवर्तित करता है और 24 घंटे या अधिक अवधि के लिए दिन गिनती शामिल करता है।

```php
use aspose\slides\PresentationFactory;

echo "File | RevisionNumber | TotalEditingTime\n";
foreach (new GlobIterator("presentations/*.pptx") as $file) {
    if (!$file->isFile()) {
        continue;
    }

    $info = PresentationFactory::getInstance()->getPresentationInfo($file->getRealPath());
    $properties = $info->readDocumentProperties();
    $totalSeconds = (int) (java_values($properties->getTotalEditingTime()) / 1000);
    $days = intdiv($totalSeconds, 86400);
    $time = sprintf("%02d:%02d:%02d", intdiv($totalSeconds, 3600) % 24, intdiv($totalSeconds, 60) % 60, $totalSeconds % 60);
    $editingTime = $days > 0 ? $days . "." . $time : $time;
    printf("%s | %d | %s\n", $file->getFilename(), java_values($properties->getRevisionNumber()), $editingTime);
}
```

एक प्रस्तुति जिसमें संस्करण संख्या 17 है और रिकॉर्ड किया गया संपादन समय 1 दिन, 2 घंटे, और 5 मिनट है, रिपोर्ट निम्नलिखित आउटपुट दिखाती है।

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[DocumentProperties::getRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getRevisionNumber) एक मान पढ़ता है जिसे एप्लिकेशन [DocumentProperties::setRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setRevisionNumber) से बदल सकते हैं। केवल संस्करण संख्या यह निर्धारित नहीं कर सकती कि प्रस्तुति कितनी बार सहेजी गई या उसका संस्करण इतिहास कैसे पुनर्स्थापित हो।

[DocumentProperties::getTotalEditingTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTotalEditingTime) फ़ाइल में रिकॉर्ड किए गए संपादन अवधि को पढ़ता है। भले ही कोई उसे संपादित करे, प्रस्तुति का संग्रहित अवधि शून्य (`00:00:00`) हो सकता है।

## **बिल्ट‑इन गुणों में संशोधन करें**

बिल्ट‑इन मेटाडेटा को अपडेट करने के लिए, [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) द्वारा लौटाए गए ऑब्जेक्ट पर setter मेथड्स का उपयोग करें। यह उदाहरण मौजूदा प्रस्तुति खोलता है, [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setComments) और [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setManager) को कॉल करता है, फिर अपडेटेड प्रस्तुति को [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) से सहेजता है। सहेजे गए PPTX में नया मेटाडेटा होता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **हाइपरलिंक बेस का प्रबंधन**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHyperlinkBase) रिलेटिव हाइपरलिंक के लिए दस्तावेज़‑स्तर बेस लौटाता है। इसे बदलने या साफ़ करने के लिए [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setHyperlinkBase) का उपयोग करें। यह तब उपयोगी होता है जब आप प्रस्तुति और उसकी लिंक की गई फ़ाइलों को किसी अन्य स्थान पर ले जाते हैं। यह व्यक्तिगत हाइपरलिंक के [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/#getExternalUrl) से अलग है: बेस बदलने से संग्रहीत लिंक पते पुनः लिखे नहीं जाते और निरपेक्ष गंतव्य नहीं बदलते।

उदाहरण को एक प्रस्तुति चाहिए जिसमें एक रिलेटिव लिंक जैसे `target.html` और एक एब्सोल्यूट लिंक जैसे `https://example.org/absolute.html` दोनों हों। यह मौजूदा बेस पढ़ता है, नया बेस पता असाइन करता है, और मूल्य जांचने के लिए प्रस्तुति को सहेज कर पुनः खोलता है। फिर यह बेस को खाली स्ट्रिंग से साफ़ करता है और अलग सहेजी गई फ़ाइल में खाली मूल्य की पुष्टि करता है। उदाहरण बेस पते को अपने लिंक फ़ाइलों के स्थान से बदलें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

दो सत्यापन संदेश `true` प्रिंट करने चाहिए। बेस साफ़ करने से व्यक्तिगत हाइपरलिंक पते अछूते रहते हैं।

रिलेटिव लिंक `target.pptx` ने `old/target.pptx` खोला जब बेस `old` फ़ोल्डर की ओर इशारा करता था। बेस को `new` फ़ोल्डर में बदलने, सहेजने और प्रस्तुति को पुनः खोलने के बाद वही लिंक `new/target.pptx` खोलता है। एब्सोल्यूट लिंक वही फ़ाइल खोलता रहता है। प्रस्तुति को स्थानांतरित करने या उसका बेस बदलने से पहले और बाद में PowerPoint में अपने रिलेटिव लिंक का परीक्षण करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण ऐसे मेटाडेटा संग्रहीत करते हैं जिनका कोई सम्बंधित बिल्ट‑इन फ़ील्ड नहीं होता। [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) मेथड आपको गुण नाम द्वारा मान असाइन करने की अनुमति देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक इंटीजर संस्करण मान जोड़ता है, और प्रस्तुति को [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) से सहेजता है। मौजूदा नाम को मान असाइन करने से उस गुण का मान बदल जाता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **कस्टम गुणों तक पहुँच और संशोधन**

यह उदाहरण कस्टम गुणों वाली एक प्रस्तुति खोलता है और [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCountOfCustomProperties) का उपयोग करके उनपर इटररेट करता है। [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCustomPropertyName) शून्य‑आधारित इंडेक्स स्वीकार करता है और वह नाम लौटाता है जिसका उपयोग [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) करता है। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, प्रत्येक मान को एक क्रमांकित स्ट्रिंग से बदल देता है चाहे उसका मूल प्रकार कुछ भी हो, और परिवर्तन सहेजता है। यदि कस्टम गुण नहीं हैं, तो लूप कोई बदलाव नहीं करता।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **लाइव उदाहरण**

Aspose.Slides API का उपयोग करके दस्तावेज़ गुणों के साथ काम करने का तरीका देखने के लिए ऑनलाइन ऐप [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) आज़माएँ:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से बिल्ट‑इन गुण कैसे हटाएँ?**

बिल्ट‑इन गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह हटाया नहीं जा सकता। हालांकि, आप उन्हें बदल सकते हैं या यदि विशेष गुण अनुमति देता है तो खाली सेट कर सकते हैं।

**यदि मैं पहले से मौजूद कस्टम गुण जोड़ूँ तो क्या होता है?**

यदि आप पहले से मौजूद कस्टम गुण जोड़ते हैं, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको गुण को पहले हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण का मान अपडेट कर देता है।

**क्या मैं प्रस्तुति को पूरी तरह लोड किए बिना उसके गुणों तक पहुँच सकता हूँ?**

हाँ। पहले [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) को कॉल करें और फिर [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) का उपयोग करके बिना [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) इंस्टेंस बनाए संग्रहीत दस्तावेज़ मेटाडेटा पढ़ें। संपूर्ण रिपोर्ट के उदाहरण और फॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/php-java/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को उसके खोलने वाले पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। प्रस्तुति को तब एन्क्रिप्ट किया जाना चाहिए जब [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) को `false` के साथ कॉल किया गया हो, और इसे [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) को `true` के साथ कॉल करने के बाद लोड किया गया हो।

**क्या मैं दस्तावेज़‑गुण‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को संगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही खोलने वाला पासवर्ड के साथ पूरी प्रस्तुति लोड करनी होगी।