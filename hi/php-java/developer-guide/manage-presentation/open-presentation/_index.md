---
title: PHP में प्रस्तुतियों को खोलें
linktitle: प्रस्तुति खोलें
type: docs
weight: 20
url: /hi/php-java/open-presentation/
keywords:
- PowerPoint खोलें
- OpenDocument खोलें
- प्रस्तुति खोलें
- PPTX खोलें
- PPT खोलें
- ODP खोलें
- प्रस्तुति लोड करें
- PPTX लोड करें
- PPT लोड करें
- ODP लोड करें
- संरक्षित प्रस्तुति
- बड़ी प्रस्तुति
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint (.pptx, .ppt) और OpenDocument (.odp) प्रस्तुतियों को आसानी से खोलें — तेज़, विश्वसनीय, पूरी तरह से सुविधायुक्त।"
---
## **परिचय**

शुरू से PowerPoint प्रस्तुतियों को बनाने के अलावा, Aspose.Slides आपको मौजूदा प्रस्तुतियों को खोलने की भी सुविधा देता है। एक प्रस्तुति लोड करने के बाद, आप इसके बारे में जानकारी प्राप्त कर सकते हैं, स्लाइड की सामग्री को संपादित कर सकते हैं, नई स्लाइड जोड़ सकते हैं, मौजूदा स्लाइड को हटाया जा सकता है, और अधिक।

## **प्रस्तुतियों को खोलें**

किसी मौजूदा प्रस्तुति को खोलने के लिए, [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ और फ़ाइल पथ को उसके कंस्ट्रक्टर में पास करें।

निम्नलिखित PHP उदाहरण दिखाता है कि कैसे एक प्रस्तुति खोलें और उसकी स्लाइड गिनती प्राप्त करें:

```php
// Presentation क्लास को इंस्टैंशिएट करें और कन्स्ट्रक्टर में फ़ाइल पथ पास करें।
$presentation = new Presentation("Sample.pptx");
try {
    // प्रस्तुति में कुल स्लाइड्स की संख्या प्रिंट करें।
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलें**

जब आपको किसी पासवर्ड-संरक्षित प्रस्तुति को खोलने की आवश्यकता हो, तो इसे डिक्रिप्ट करने और लोड करने के लिए [LoadOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/) क्लास के [setPassword](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setPassword) मेथड के माध्यम से पासवर्ड पास करें। निम्नलिखित PHP कोड इस कार्य को दर्शाता है:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति पर संचालन करें।
} finally {
    $presentation->dispose();
}
```

## **बड़ी प्रस्तुतियों को खोलें**

Aspose.Slides विकल्प प्रदान करता है—विशेषकर [LoadOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/) क्लास में [getBlobManagementOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) मेथड—जो आपको बड़ी प्रस्तुतियों को लोड करने में मदद करता है।

निम्नलिखित PHP कोड बड़ी प्रस्तुति (उदाहरण के लिए, 2 GB) लोड करने को दर्शाता है:

```php
$loadOptions = new LoadOptions();
// KeepLocked व्यवहार चुनें—प्रेज़ेंटेशन फ़ाइल जीवनकाल के दौरान लॉक रहेगी
// प्रेज़ेंटेशन इंस्टेंस के लिए, लेकिन इसे मेमोरी में लोड करने या अस्थायी फ़ाइल में कॉपी करने की ज़रूरत नहीं है।
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // बड़ी प्रस्तुति लोड हो गई है और उपयोग की जा सकती है, जबकि मेमोरी उपयोग कम रहता है।

    // प्रेज़ेंटेशन में बदलाव करें।
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // प्रेज़ेंटेशन को अन्य फ़ाइल में सहेजें। इस ऑपरेशन के दौरान मेमोरी उपयोग कम रहता है।
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// ऐसा न करें! I/O अपवाद फेंका जाएगा क्योंकि फ़ाइल तब तक लॉक रहती है जब तक प्रेज़ेंटेशन ऑब्जेक्ट डिस्पोज़ नहीं हो जाता।
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// यहाँ इसे करना ठीक है। स्रोत फ़ाइल अब प्रेज़ेंटेशन ऑब्जेक्ट द्वारा लॉक नहीं है।
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
स्ट्रीम के साथ काम करते समय कुछ सीमाओं को दूर करने के लिए, Aspose.Slides स्ट्रीम की सामग्री को कॉपी कर सकता है। एक स्ट्रीम से बड़ी प्रस्तुति लोड करने से प्रस्तुति की कॉपी बनती है और लोडिंग धीमी हो सकती है। इसलिए, जब आपको बड़ी प्रस्तुति लोड करनी हो, तो हम दृढ़ता से सुझाव देते हैं कि स्ट्रीम के बजाय प्रस्तुति फ़ाइल पथ का उपयोग करें।

जब आप ऐसी प्रस्तुति बना रहे हों जिसमें बड़े ऑब्जेक्ट (वीडियो, ऑडियो, हाई‑रेज़ोल्यूशन इमेज आदि) हों, तो आप मेमोरी खपत को कम करने के लिए [BLOB management](/slides/hi/php-java/manage-blob/) का उपयोग कर सकते हैं।
{{%/alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

Aspose.Slides [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iresourceloadingcallback/) इंटरफ़ेस प्रदान करता है जो आपको बाहरी संसाधनों का प्रबंधन करने देता है। निम्नलिखित PHP कोड दर्शाता है कि कैसे `IResourceLoadingCallback` इंटरफ़ेस का उपयोग करें:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // एक वैकल्पिक इमेज लोड करें।
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // एक वैकल्पिक URL सेट करें।
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // अन्य सभी इमेज को छोड़ें।
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **एम्बेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

PowerPoint प्रस्तुति में निम्नलिखित प्रकार के एम्बेडेड बाइनरी ऑब्जेक्ट हो सकते हैं:

- VBA प्रोजेक्ट (यहाँ पहुँचा जा सकता है: [Presentation.getVbaProject](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getVbaProject));
- OLE ऑब्जेक्ट एम्बेडेड डेटा (यहाँ पहुँचा जा सकता है: [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- ActiveX कंट्रोल बाइनरी डेटा (यहाँ पहुँचा जा सकता है: [Control.getActiveXControlBinary](https://reference.aspose.com/slides/hi/php-java/aspose.slides/control/#getActiveXControlBinary)).

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) मेथड का उपयोग करके, आप प्रस्तुति को बिना किसी एम्बेडेड बाइनरी ऑब्जेक्ट के लोड कर सकते हैं।

यह मेथड संभावित दुर्भावनापूर्ण बाइनरी सामग्री को हटाने में उपयोगी है। निम्नलिखित PHP कोड दर्शाता है कि कैसे किसी प्रस्तुति को बिना एम्बेडेड बाइनरी सामग्री के लोड किया जाए:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // प्रेज़ेंटेशन पर संचालन करें।
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पहचानूँ कि फ़ाइल दूषित है और नहीं खुल रही है?**  
लोड करने के दौरान आपको एक पार्सिंग/फ़ॉर्मेट वैधता अपवाद मिलेगा। ऐसे त्रुटियों में अक्सर एक अमान्य ZIP संरचना या टूटे हुए PowerPoint रिकॉर्ड का उल्लेख होता है।

**यदि खोलते समय आवश्यक फ़ॉन्ट गायब हों तो क्या होता है?**  
फ़ाइल खुल जाएगी, लेकिन बाद में [rendering/export](/slides/hi/php-java/convert-presentation/) फ़ॉन्ट प्रतिस्थापित कर सकता है। रन‑टाइम वातावरण में [फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर](/slides/hi/php-java/font-substitution/) करें या [आवश्यक फ़ॉन्ट जोड़ें](/slides/hi/php-java/custom-font/)।

**खोलते समय एम्बेडेड मीडिया (वीडियो/ऑडियो) के बारे में क्या?**  
वे प्रस्तुति संसाधनों के रूप में उपलब्ध हो जाते हैं। यदि मीडिया को बाहरी पथों के माध्यम से संदर्भित किया गया है, तो सुनिश्चित करें कि ये पथ आपके वातावरण में सुलभ हों; अन्यथा [rendering/export](/slides/hi/php-java/convert-presentation/) मीडिया को छोड़ सकता है।