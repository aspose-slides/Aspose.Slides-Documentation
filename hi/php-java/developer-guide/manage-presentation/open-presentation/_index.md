---
title: PHP में प्रस्तुतियाँ खोलें
linktitle: प्रस्तुति खोलें
type: docs
weight: 20
url: /hi/php-java/open-presentation/
keywords:
- PowerPoint खोलें
- प्रस्तुति खोलें
- PPTX खोलें
- PPT खोलें
- ODP खोलें
- प्रस्तुति लोड करें
- PPTX लोड करें
- PPT लोड करें
- ODP लोड करें
- सुरक्षित प्रस्तुति
- बड़ी प्रस्तुति
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- PHP
- Aspose.Slides
description: "PHP में PowerPoint और OpenDocument प्रस्तुतियों को खोलना सीखें, खोलने के पासवर्ड प्रदान करें, संसाधन लोडिंग को नियंत्रित करें, और Aspose.Slides for PHP via Java के साथ मेमोरी उपयोग को कम करें।"
---
## **परिचय**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/hi/php-java/) फ़ाइलों और स्ट्रीम्स से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। एक प्रस्तुति लोड होने के बाद, आप उसकी संरचना का निरीक्षण कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और इसे मूल या किसी अन्य समर्थित फ़ॉर्मेट में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/) क्लास के माध्यम से अनुकूलित किया जा सकता है। उदाहरण के लिए, आप एक खोलने वाला पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को Java हीप मेमोरी से बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुति खोलें**

एक मौजूदा प्रस्तुति खोलने के लिए, उसके फ़ाइल पथ को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) कंस्ट्रक्टर में पास करें। उपयोग के बाद प्रस्तुति को डिस्पोज़ करें ताकि फ़ाइल हैंडल, अस्थायी डेटा और अन्य संसाधन तुरंत मुक्त हो सकें।

निम्नलिखित PHP उदाहरण दिखाता है कि कैसे प्रस्तुति खोलें और उसकी स्लाइड संख्या प्राप्त करें:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलना**

एक खोलने वाला पासवर्ड प्रस्तुति सामग्री को एन्क्रिप्ट करता है। पूरी प्रस्तुति को लोड करने के लिए, सही पासवर्ड को [LoadOptions::setPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setPassword) में पास करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) कंस्ट्रक्टर को प्रदान करें। पासवर्ड गायब या गलत होने पर लोडिंग विफल हो जाती है।

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

पासवर्ड पहचान, सत्यापन और एन्क्रिप्शन वर्कफ़्लो के लिए, देखें [पासवर्ड-रक्षित प्रस्तुतियाँ](/slides/hi/php-java/password-protected-presentation/). यदि एन्क्रिप्टेड प्रस्तुति जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजी गई है, तो उन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [प्रस्तुति गुणों का प्रबंधन](/slides/hi/php-java/presentation-properties/).

## **बड़ी प्रस्तुतियों को खोलना**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) विकल्प प्रदान करता है जो नियंत्रित करता है कि Aspose.Slides बाइनरी बड़े ऑब्जेक्ट्स जैसे छवियां, ऑडियो, और वीडियो को कैसे संभालता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे गए BLOB डेटा की मात्रा को सीमित कर सकते हैं।

निम्नलिखित PHP कोड बड़े आकार की प्रस्तुति (उदाहरण के लिए, 2 GB) को लोड करने का प्रदर्शन करता है:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
यदि आप [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) का उपयोग करते हैं, तो स्रोत फ़ाइल तब तक लॉक रहती है जब तक प्रस्तुति इंस्टेंस को डिस्पोज़ नहीं किया जाता। उस इंस्टेंस के जीवित रहने के दौरान स्रोत फ़ाइल को न तो स्थानांतरित करें, न ही अधिलेखित करें, और न ही हटाएँ।

Aspose.Slides लोडिंग के दौरान इनपुट स्ट्रीम की सामग्री की एक प्रतिलिपि बना सकता है। बड़ी प्रस्तुतियों के लिए, फ़ाइल पथ आमतौर पर स्ट्रीम की तुलना में अधिक कुशल होता है। अतिरिक्त संग्रहण और मेमोरी-प्रबंधन विकल्पों के लिए देखें [BLOBs का प्रबंधन](/slides/hi/php-java/manage-blob/).
{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करना**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) PHP/Java Bridge के माध्यम से जावा [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iresourceloadingcallback/) इंटरफ़ेस की कार्यान्वयन स्वीकार करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, किसी संसाधन को पुनर्निर्देशित कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को छोड़ सकता है। यह तब उपयोगी होता है जब प्रस्तुतियों में बाहरी छवियां होती हैं जिन्हें एप्लिकेशन-विशिष्ट सुरक्षा या संग्रहण नियमों के अनुसार हल करना आवश्यक होता है।

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **बिना एम्बेडेड बाइनरी ऑब्जेक्ट्स के प्रस्तुतियों को लोड करना**

एक प्रस्तुति में एम्बेडेड बाइनरी डेटा हो सकता है जिसकी एप्लिकेशन को आवश्यकता नहीं है या वह उसे बनाए नहीं रखना चाहती। उदाहरणों में शामिल हैं:

- VBA प्रोजेक्ट, उपलब्ध है [Presentation::getVbaProject](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getVbaProject) द्वारा;
- एम्बेडेड OLE डेटा, उपलब्ध है [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) द्वारा;
- ActiveX कंट्रोल डेटा, उपलब्ध है [Control::getActiveXControlBinary](https://reference.aspose.com/slides/hi/php-java/aspose.slides/control/#getActiveXControlBinary) द्वारा।

[LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) को `true` पर सेट करें ताकि लोडिंग के दौरान यह बाइनरी डेटा हटाया जा सके। लोड की गई प्रस्तुति को सहेजें ताकि शुद्ध किया गया परिणाम बना रहे।

यह विकल्प अनचाहे एम्बेडेड पेलोड्स के संपर्क को कम करता है, लेकिन यह पूर्ण मालवेयर-डिटेक्शन या कंटेंट-सैनिटाइज़ेशन सिस्टम नहीं है।

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता कर सकता हूँ कि फ़ाइल भ्रष्ट है और नहीं खुल सकती?**

Aspose.Slides लोडिंग के दौरान पार्सिंग या फॉर्मेट अपवाद फेंकता है। इस विफलता को गलत पासवर्ड त्रुटि से अलग तरीके से संभालें ताकि एप्लिकेशन कारण को सटीक रूप से रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स गायब हों तो क्या होता है?**

प्रस्तुति अभी भी लोड हो सकती है, लेकिन रेंडरिंग और एक्सपोर्ट फ़ॉन्ट्स को प्रतिस्थापित कर सकते हैं। आप आउटपुट को अधिक पूर्वानुमेय बनाने के लिए [फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर](/slides/hi/php-java/font-substitution/) कर सकते हैं या [कस्टम फ़ॉन्ट प्रदान](/slides/hi/php-java/custom-font/) कर सकते हैं।

**क्या एक प्रस्तुति लोड करने से उसकी एम्बेडेड मीडिया भी लोड हो जाती है?**

एम्बेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधनों को कॉन्फ़िगर किए गए संसाधन-लोडिंग व्यवहार के अनुसार हल किया जाता है और यदि उनके स्थानों तक पहुँच नहीं हो पाती तो वे उपलब्ध नहीं हो सकते।