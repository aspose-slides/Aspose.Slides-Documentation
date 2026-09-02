---
title: PHP में प्रस्तुतियों की लिखने-से-रोकथाम
linktitle: लिखने-से-रोकथाम
type: docs
weight: 25
url: /hi/php-java/write-protected-presentation/
keywords:
- लिखने-से-रोकथाम
- PowerPoint में लिखने-से-रोकथाम
- संशोधित करने के लिये पासवर्ड
- प्रस्तुति संपादन प्रतिबंधित करना
- लिखने-से-रोकथाम हटाएँ
- संशोधन पासवर्ड मान्य करें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP का उपयोग करके PowerPoint PPT और PPTX प्रस्तुतियों में लिखने-से-रोकथाम पासवर्ड सेट, पता, मान्य और हटाएँ।"
---
## **परिचय**

एक लिखने‑से‑रोकथाम पासवर्ड प्रस्तुति में संशोधन को प्रतिबंधित करता है, लेकिन इसकी सामग्री को एन्क्रिप्ट नहीं करता। उपयोगकर्ता लिखने‑से‑रोकथाम वाली प्रस्तुति को पासवर्ड के बिना लोड और देख सकते हैं। एप्लिकेशन पर निर्भर करता है, वे सामग्री को संपादित कर सकते हैं और इसे एक अलग नाम से सहेज सकते हैं, इसलिए लिखने‑से‑रोकथाम को गोपनीयता तंत्र के रूप में नहीं माना जाना चाहिए।

एक खोलने‑का‑पासवर्ड अलग उद्देश्य पूरा करता है: यह प्रस्तुति को एन्क्रिप्ट करता है और इसकी सामग्री लोड करने के लिए आवश्यक होता है। प्रस्तुति को एन्क्रिप्ट करने या खोलने‑के‑पासवर्ड को मान्य करने के लिए, देखें [Password-Protect Presentations](/slides/hi/php-java/password-protected-presentation/)।

इस लेख की कार्य‑प्रणाली PPT और PPTX दोनों प्रकार की प्रस्तुतियों पर लागू होती है। उदाहरण PPTX फ़ाइलों का उपयोग करते हैं; PPT में सहेजते समय `.ppt` एक्सटेंशन और संबंधित PPT सहेजने के प्रारूप का उपयोग करें।

## **प्रेजेंटेशन पर लिखने‑से‑रोकथाम सेट करें**

[ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#setWriteProtection) का उपयोग करके प्रस्तुति में संशोधन के लिए पासवर्ड निर्धारित करें। प्रस्तुति को सहेजने से सुरक्षा सेटिंग स्थायी हो जाएगी।

नीचे दिया गया उदाहरण PPTX प्रस्तुति पर लिखने‑से‑रोकथाम सेट करता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **लिखने‑से‑रोकथाम वाली प्रस्तुति लोड करें**

क्योंकि लिखने‑से‑रोकथाम प्रस्तुति की सामग्री को एन्क्रिप्ट नहीं करती, इसलिए प्रस्तुति को लोड करने के लिए पासवर्ड आवश्यक नहीं है। पासवर्ड केवल संरक्षित प्रस्तुति को संशोधित करने की अधिकारिता की जाँच के दौरान प्रासंगिक होता है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

[LoadOptions::setPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setPassword) को लिखने‑से‑रोकथाम पासवर्ड न दें। यह मेथड एन्क्रिप्टेड सामग्री के लिए खोलने‑का‑पासवर्ड स्वीकार करता है। यदि प्रस्तुति में दोनों प्रकार के पासवर्ड हों, तो लोड करने के लिए खोलने‑का‑पासवर्ड प्रदान करें और लिखने‑से‑रोकथाम पासवर्ड को अलग से संभालें।

## **प्रेजेंटेशन से लिखने‑से‑रोकथाम हटाएँ**

[ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#removeWriteProtection) का उपयोग करके संशोधन प्रतिबंध हटाएँ, फिर प्रस्तुति को सहेजें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **जाँचें कि प्रस्तुति लिखने‑से‑रोकथाम वाली है या नहीं**

पूरी [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस बनाए बिना फ़ाइल का निरीक्षण करने के लिए, [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) को कॉल करें और [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#isWriteProtected) को देखें। यह मेथड [NullableBool](https://reference.aspose.com/slides/hi/php-java/aspose.slides/nullablebool/) का उपयोग करता है और लिखने‑से‑रोकथाम पाए जाने पर `NullableBool::True` लौटाता है।

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) का स्ट्रीम ओवरलोड उसी जानकारी को स्ट्रीम के रूप में प्रदान की गई प्रस्तुति के लिए देता है।

## **लिखने‑से‑रोकथाम पासवर्ड को मान्य करें**

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#checkWriteProtection) का उपयोग करके पूर्ण प्रस्तुति लोड किए बिना संशोधन पासवर्ड को मान्य करें। पहले [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#isWriteProtected) की जाँच करें ताकि एप्लिकेशन केवल लिखने‑से‑रोकथाम मौजूद होने पर ही पासवर्ड का अनुरोध या मान्यता करे।

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#checkWriteProtection) केवल लिखने‑से‑रोकथाम पासवर्ड को मान्य करता है। यह खोलने‑का‑पासवर्ड नहीं मान्य करता और न ही यह निर्धारित करता है कि एन्क्रिप्टेड सामग्री लोड की जा सकती है या नहीं। इसके विपरीत, [PresentationInfo::checkPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#checkPassword) केवल खोलने‑का‑पासवर्ड मान्य करता है। यदि पूरी प्रस्तुति पहले से लोड हो चुकी है, तो [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/protectionmanager/#checkWriteProtection) समान लिखने‑से‑रोकथाम जाँच अपनी सुरक्षा प्रबंधक के माध्यम से प्रदान करता है।

उत्पादन एप्लिकेशन में, पासवर्ड को लॉग न करें या उन्हें निदान संदेशों में शामिल न करें। अनावश्यक पुनः‑मान्यताओं से बचें, और पासवर्ड को केवल आवश्यक समय तक मेमोरी में रखें।

{{% alert color="info" title="देखें" %}}
- [Password-Protect Presentations](/slides/hi/php-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/hi/php-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या लिखने‑से‑रोकथाम प्रस्तुति को एन्क्रिप्ट करती है?**

नहीं। यह संशोधन को प्रतिबंधित करती है लेकिन प्रस्तुति की सामग्री को लोड और देखने के लिए उपलब्ध रखती है।

**क्या लिखने‑से‑रोकथाम पासवर्ड को प्रस्तुति खोलने के लिए आवश्यक है?**

नहीं। केवल खोलने‑का‑पासवर्ड एन्क्रिप्टेड प्रस्तुति सामग्री को लोड करने के लिए आवश्यक है।

**क्या किसी प्रस्तुति में दोनों, खोलने‑का‑पासवर्ड और लिखने‑से‑रोकथाम पासवर्ड, हो सकते हैं?**

हां। एन्क्रिप्टेड प्रस्तुति को खोलने के लिए लोड विकल्पों के माध्यम से खोलने‑का‑पासवर्ड प्रदान करें, और संशोधन प्राधिकरण की आवश्यकता होने पर लिखने‑से‑रोकथाम पासवर्ड को अलग से मान्य करें।