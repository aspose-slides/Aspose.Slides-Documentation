---
title: PHP में प्रस्तुतियों को खोलें
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
description: "PHP में PowerPoint और OpenDocument प्रस्तुतियों को कैसे खोलें, ओपनिंग पासवर्ड प्रदान करें, संसाधन लोडिंग को नियंत्रित करें, और Aspose.Slides for PHP via Java के साथ मेमोरी उपयोग को कम करें।"
---
## **परिचय**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/hi/php-java/) फ़ाइलों और स्ट्रीमों से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। एक बार प्रस्तुति लोड हो जाने पर, आप इसकी संरचना की जाँच कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और इसे मूल या किसी अन्य समर्थित फ़ॉर्मेट में सहेज सकते हैं।

[LoadOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/) क्लास के माध्यम से लोडिंग व्यवहार को अनुकूलित किया जा सकता है। उदाहरण के लिए, आप एक ओपनिंग पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को Java हीप मेमोरी के बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुति खोलें**

फ़ाइल या स्ट्रीम को लोड करने के बाद, आप [उसके मूल प्रस्तुति फ़ॉर्मेट का निर्धारण करें](/slides/hi/php-java/detect-presentation-source-format/) ताकि आप तय कर सकें कि आपका एप्लिकेशन इसे कैसे प्रोसेस करेगा।

एक मौजूदा प्रस्तुति खोलने के लिए, उसके फ़ाइल पथ को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) कॉन्स्ट्रक्टर में पास करें। उपयोग के बाद प्रस्तुति को डिस्पोज़ करें ताकि फ़ाइल हैंडल, अस्थायी डेटा, और अन्य संसाधन तुरंत मुक्त हो जाएँ।

निम्नलिखित PHP उदाहरण दिखाता है कि प्रस्तुति को कैसे खोला जाए और उसकी स्लाइड गिनती कैसे प्राप्त की जाए:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **पासवर्ड-संरक्षित प्रस्तुतियाँ**

एक ओपनिंग पासवर्ड प्रस्तुति की सामग्री को एन्क्रिप्ट करता है। पूरी प्रस्तुति लोड करने के लिए, सही पासवर्ड को [LoadOptions::setPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setPassword) को पास करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) कॉन्स्ट्रक्टर में प्रदान करें। जब पासवर्ड गायब या गलत होता है तो लोडिंग विफल हो जाती है।

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

पासवर्ड पहचान, मान्यकरण, और एन्क्रिप्शन वर्कफ़्लो के लिए, देखें [Password-Protect Presentations](/slides/hi/php-java/password-protected-presentation/). यदि एक एन्क्रिप्टेड प्रस्तुति को जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजा गया था, तो उन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [Manage Presentation Properties](/slides/hi/php-java/presentation-properties/).

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) विकल्प लौटाता है जो नियंत्रित करता है कि Aspose.Slides बाइनरी बड़े ऑब्जेक्ट्स जैसे इमेज, ऑडियो, और वीडियो को कैसे संभालता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे जाने वाले BLOB डेटा की मात्रा को सीमित कर सकते हैं।

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
[PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक प्रस्तुति इंस्टेंस को डिस्पोज़ नहीं किया जाता। उस इंस्टेंस के जीवित रहने के दौरान स्रोत फ़ाइल को स्थानांतरित, अधिलेखित या हटाते नहीं।

Aspose.Slides लोड करते समय इनपुट स्ट्रीम की सामग्री को कॉपी कर सकता है। बड़ी प्रस्तुतियों के लिए, फ़ाइल पथ आमतौर पर स्ट्रीम की तुलना में अधिक कुशल होता है। अतिरिक्त संग्रहण और मेमोरी-प्रबंधन विकल्पों के लिए देखें [Manage BLOBs](/slides/hi/php-java/manage-blob/).
{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) PHP/Java Bridge के माध्यम से जावा [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iresourceloadingcallback/) इंटरफ़ेस के कार्यान्वयन को स्वीकार करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, किसी संसाधन को पुनर्निर्देशित कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को छोड़ सकता है। यह तब उपयोगी होता है जब प्रस्तुतियों में बाहरी छवियाँ होती हैं जिन्हें एप्लिकेशन-विशिष्ट सुरक्षा या संग्रहण नियमों के अनुसार हल किया जाना चाहिए।

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

## **एम्बेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

एक प्रस्तुति में एम्बेडेड बाइनरी डेटा हो सकता है जिसे एप्लिकेशन को आवश्यकता नहीं होती या वह रखना नहीं चाहता। उदाहरण शामिल हैं:

- VBA प्रोजेक्ट्स, उपलब्ध है [Presentation::getVbaProject] के माध्यम से;
- एम्बेडेड OLE डेटा, उपलब्ध है [OleEmbeddedDataInfo::getEmbeddedFileData] के माध्यम से;
- ActiveX कंट्रोल डेटा, उपलब्ध है [Control::getActiveXControlBinary] के माध्यम से.

[LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) को `true` पर सेट करें ताकि लोड करते समय इस बाइनरी डेटा को हटा दिया जाए। लोड की गई प्रस्तुति को सहेजें ताकि सफ़ाई परिणाम बना रहे।

यह विकल्प अनचाहे एम्बेडेड पेलोड्स के एक्सपोजर को कम करता है, लेकिन यह पूर्ण मैलवेयर-डिटेक्शन या कंटेंट-सेनिटाइज़ेशन सिस्टम नहीं है।

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

**मैं कैसे पता करूँ कि फ़ाइल भ्रष्ट है और खोल नहीं सकती?**  
Aspose.Slides लोडिंग के दौरान पार्सिंग या फ़ॉर्मेट अपवाद फेंकता है। इस विफलता को गलत पासवर्ड त्रुटि से अलग ढंग से हैंडल करें ताकि एप्लिकेशन सही कारण की रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स मौजूद नहीं हैं तो क्या होता है?**  
प्रस्तुति अभी भी लोड हो सकती है, लेकिन रेंडरिंग और एक्सपोर्ट में फ़ॉन्ट्स बदल सकते हैं। आप आउटपुट को अधिक पूर्वानुमानित बनाने के लिए [configure font substitution](/slides/hi/php-java/font-substitution/) या [provide custom fonts](/slides/hi/php-java/custom-font/) कर सकते हैं।

**क्या प्रस्तुति लोड करने से उसके एम्बेडेड मीडिया भी लोड हो जाते हैं?**  
एम्बेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधनों को कॉन्फ़िगर किए गए रिसोर्स-लोडिंग व्यवहार के अनुसार हल किया जाता है और यदि उनके स्थानों तक पहुँच नहीं सके तो अनुपलब्ध हो सकते हैं।