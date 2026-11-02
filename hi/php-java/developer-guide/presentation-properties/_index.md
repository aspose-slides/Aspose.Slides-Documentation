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
- बिल्ट-इन गुण
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
description: "Aspose.Slides for PHP via Java में प्रस्तुति गुणों का मास्टर करें और अपने PowerPoint व OpenDocument फाइलों में खोज, ब्रांडिंग और वर्कफ़्लो को सुव्यवस्थित करें।"
---
## **परिचय**

Aspose.Slides for PHP via Java **built-in** और **custom** दस्तावेज़ गुणों का समर्थन करता है। इन गुणों का उपयोग प्रस्तुति मेटाडेटा, जैसे लेखक, शीर्षक, और उपयोगकर्ता‑परिभाषित मानों को पढ़ने और अद्यतन करने के लिए करें।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) क्लास के माध्यम से। इस क्लास का एक उदाहरण [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) से प्राप्त होता है। निम्न उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए। ये उदाहरण इस बात को मानते हैं कि PHP/Java Bridge और Aspose.Slides PHP रैपर आरंभ किए गए हैं।

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुति को सहेजते समय एप्लिकेशन और निर्माता मेटाडेटा का प्रबंधन करता है; ये फ़ील्ड उस सॉफ़्टवेयर की पहचान करते हैं जिसने आउटपुट बनाया।
{{% /alert %}}

## **प्रस्तुति गुणों का प्रबंधन**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। वे दो श्रेणियों में आते हैं:

- **Built-in properties** मानक मेटाडेटा रखती हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ आँकड़े।
- **Custom properties** उपयोगकर्ता‑परिभाषित नाम/मान जोड़े संग्रहीत करती हैं।

Aspose.Slides for PHP via Java दोनों श्रेणियों तक पहुँच प्रदान करता है। PowerPoint में **File → Info → Properties → Advanced Properties** चुनें ताकि दस्तावेज़ मेटाडेटा का निरीक्षण किया जा सके। संवाद जानकारी को **Summary**, **Statistics**, **Contents**, और **Custom** जैसी टैब में समूहित करता है। उपयोगकर्ता‑परिभाषित गुणों का प्रबंधन करने के लिए **Custom** टैब का उपयोग करें।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ना**

एक खोलने वाला पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुण दोनों की रक्षा करता है। जब [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) को `false` के साथ कॉल किया जाता है और प्रस्तुति एन्क्रिप्ट की जाती है, तो उसके दस्तावेज़ गुण सार्वजनिक रहते हैं। तब कोई एप्लिकेशन [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) को `true` के साथ कॉल कर सकता है और खोलने वाला पासवर्ड प्रदान किए बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) यह नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल हो जाता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

उदाहरण के लिये एक एन्क्रिप्टेड प्रस्तुति आवश्यक है जहाँ दस्तावेज़ गुण सार्वजनिक रखे गए हों। यह [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) के माध्यम से लोडिंग मोड की जाँच करता है और फिर [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) से बिल्ट‑इन गुण पढ़ता है:

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

इस मोड में स्लाइड सामग्री लोड नहीं होती। स्लाइड, मास्टर, लेआउट, आकृतियां, मीडिया और अन्य प्रस्तुति वस्तुएँ अनुपलब्ध रहती हैं। एप्लिकेशन को हमेशा [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) की जाँच करनी चाहिए इससे पहले कि वह ऐसा ऑपरेशन करे जिसके लिये संपूर्ण प्रस्तुति ऑब्जेक्ट मॉडल आवश्यक हो।

{{% alert color="warning" title="Warning" %}}
सार्वजनिक मेटाडेटा में लेखक के नाम, शीर्षक, विषय, कुंजी‑शब्द, कंपनी सूचना, टिप्पणी और कस्टम मान उजागर हो सकते हैं। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। केवल तब सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन सिस्टम को पासवर्ड के बिना पहुँच की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुणों को अद्यतन करना**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिये, [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) को `true` के साथ कॉल करने के बाद लोड की गई प्रस्तुति सार्वजनिक मेटाडेटा पढ़ने के लिये अभिप्रेत होती है। Aspose.Slides उस मेटाडेटा‑केवल ऑब्जेक्ट से बदलते गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के अंदर के संबंधित डेटा के साथ सुसंगत रहना चाहिए। इसलिए उन्हें अद्यतन करने के लिये सही खोलने वाला पासवर्ड और संपूर्ण लोड आवश्यक है।

उदाहरण में एक एन्क्रिप्टेड PPTX प्रस्तुति आवश्यक है जहाँ दस्तावेज़ गुण सार्वजनिक हों और पासवर्ड ज्ञात हो। यह [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/) से पूरी प्रस्तुति खोलता है, सार्वजनिक बिल्ट‑इन गुणों को अद्यतन करता है, और परिणाम सहेजता है। फिर यह [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) से एन्क्रिप्शन की पुष्टि करता है और पासवर्ड के बिना सार्वजनिक मेटाडेटा पुनः खोलकर नए मानों की जाँच करता है:

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

यदि कोई एप्लिकेशन प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं रखता, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने‑योग्य मानना चाहिए।

## **बिल्ट‑इन गुणों तक पहुँच**

[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) क्लास getter मेथड्स के माध्यम से बिल्ट‑इन मेटाडेटा उपलब्ध कराती है, जिनमें [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/), और [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/) शामिल हैं। यह उदाहरण मौजूदा प्रस्तुति खोलता है और उसकी संग्रहीत मेटाडेटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड खाली हो सकते हैं।

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

## **बिल्ट‑इन गुणों को संशोधित करना**

बिल्ट‑इन मेटाडेटा को अद्यतन करने के लिये [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) से प्राप्त ऑब्जेक्ट पर setter मेथड्स का उपयोग करें। यह उदाहरण मौजूदा प्रस्तुति खोलता है, [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/), और [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/) को कॉल करता है, फिर [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) से अद्यतन प्रस्तुति सहेजता है। सहेजी गई PPTX में नया मेटाडेटा होगा।

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

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) दस्तावेज़‑स्तरीय रिलेटिव हाइपरलिंक के बेस को प्राप्त करता है। इसे बदलने या साफ़ करने के लिये [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) का उपयोग करें। यह तब उपयोगी होता है जब आप प्रस्तुति और उसकी लिंक की फ़ाइलों को किसी अन्य स्थान पर ले जाते हैं। यह individual hyperlink के [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) से अलग है: बेस बदलने से संग्रहित लिंक पते नहीं बदले जाते और ना ही पूर्ण गंतव्य बदलते हैं।

उदाहरण में एक प्रस्तुति आवश्यक है जिसमें एक रिलेटिव लिंक (`target.html`) और एक एब्सोल्यूट लिंक (`https://example.org/absolute.html`) दोनों हों। यह मौजूदा बेस पढ़ता है, नया बेस पता सेट करता है, और मूल्य जाँचने के लिये प्रस्तुति सहेजकर पुनः खोलता है। फिर यह बेस को खाली स्ट्रिंग से साफ़ करता है और अलग सहेजी फ़ाइल में खाली मान की जाँच करता है। उदाहरण बेस पते को अपनी लिंक फ़ाइलों के स्थान से बदलें।

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

दो सत्यापन संदेश `true` प्रिंट करने चाहिए। बेस को साफ़ करने से व्यक्तिगत हाइपरलिंक पते अपरिवर्तित रहते हैं।

रिलेटिव लिंक `target.pptx` ने `old/target.pptx` खोल दिया जब बेस `old` फ़ोल्डर की ओर इशारा करता था। बेस को `new` फ़ोल्डर में बदलने, सहेजने और प्रस्तुति को पुनः खोलने पर वही लिंक `new/target.pptx` खोलता है। एब्सोल्यूट लिंक वही फ़ाइल खोलता ही रहता है। प्रस्तुति को स्थानांतरित करने या उसका बेस बदलने से पहले और बाद में PowerPoint में अपने रिलेटिव लिंक का परीक्षण करें।

## **कस्टम प्रस्तुति गुण जोड़ना**

कस्टम गुण उन मेटाडेटा को संग्रहीत करते हैं जिनका कोई बिल्ट‑इन फ़ील्ड नहीं होता। [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) मेथड आपको गुण नाम द्वारा मान असाइन करने देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक पूर्णांक संस्करण मान जोड़ता है, और [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) से प्रस्तुति सहेजता है। मौजूदा नाम को फिर से असाइन करने से उस गुण का मान बदल जाता है।

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

यह उदाहरण कस्टम गुणों वाली प्रस्तुति खोलता है और [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) से उन्हें क्रमबद्ध करता है। [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) एक शून्य‑आधारित सूचकांक स्वीकार करता है और उस नाम को लौटाता है जिसका उपयोग [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) करता है। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, सभी मानों को क्रमांकित स्ट्रिंग में बदल देता है (उनके मूल प्रकार की परवाह किए बिना), और परिवर्तन सहेजता है। यदि कोई कस्टम गुण नहीं हैं, तो लूप कोई परिवर्तन नहीं करता।

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

ऑनलाइन एप [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) का उपयोग करके देखें कि Aspose.Slides API के माध्यम से दस्तावेज़ गुणों के साथ कैसे काम किया जाता है:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से एक बिल्ट‑इन गुण कैसे हटाऊँ?**

बिल्ट‑इन गुण प्रस्तुति का अभिन्न भाग होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालाँकि, आप उनका मान बदल सकते हैं या यदि विशेष गुण अनुमतिकरता देता है तो उसे खाली सेट कर सकते हैं।

**यदि मैं कोई कस्टम गुण जोड़ूँ जो पहले से मौजूद है तो क्या होगा?**

यदि आप कोई कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले से उसे हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट कर देता है।

**क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुँच सकता हूँ?**

हाँ। [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करें और फिर [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) से संग्रहित दस्तावेज़ मेटाडेटा पढ़ें, बिना [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) इंस्टेंस बनाए। पूर्ण रिपोर्ट उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिये [Build a Lightweight Presentation Inventory](/slides/hi/php-java/examine-presentation/) देखें।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को उसके खोलने वाले पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। प्रस्तुति को [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) को `false` के साथ कॉल करने के बाद एन्क्रिप्ट किया गया होना चाहिए, और उसे [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) को `true` के साथ कॉल करके लोड किया गया होना चाहिए।

**क्या मैं डॉक्यूमेंट‑प्रॉपर्टीज़‑ओनली मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को सुसंगत रहना आवश्यक है, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिये सही खोलने वाला पासवर्ड के साथ पूरी प्रस्तुति लोड करनी होगी।