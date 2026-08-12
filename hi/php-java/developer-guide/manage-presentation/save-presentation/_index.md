---
title: PHP में प्रस्तुतियों को सहेजें
linktitle: प्रस्तुति सहेजें
type: docs
weight: 80
url: /hi/php-java/save-presentation/
keywords:
- PowerPoint सहेजें
- OpenDocument सहेजें
- प्रस्तुति सहेजें
- स्लाइड सहेजें
- PPT सहेजें
- PPTX सहेजें
- ODP सहेजें
- फ़ाइल में प्रस्तुति
- स्ट्रीम में प्रस्तुति
- पूर्वनिर्धारित व्यू टाइप
- स्ट्रिक्ट Office Open XML फॉर्मेट
- Zip64 मोड
- थंबनेल रीफ़्रेश करना
- सेव प्रोग्रेस
- PHP
- Aspose.Slides
description: "जाने कि कैसे Aspose.Slides for PHP को Java के माध्यम से उपयोग करके प्रस्तुतियों को सहेजा जाए — PowerPoint या OpenDocument में निर्यात करते समय लेआउट, फ़ॉन्ट और इफ़ेक्ट को बनाए रखते हुए।"
---
## **समीक्षा**

[Open Presentations in PHP](/slides/hi/php-java/open-presentation/) ने बताया कि प्रस्तुति खोलने के लिए [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का कैसे उपयोग किया जाता है। यह लेख बताता है कि प्रस्तुति कैसे बनाई और सहेजी जाए। [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास में प्रस्तुति की सामग्री होती है। चाहे आप नई प्रस्तुति बना रहे हों या मौजूदा को संशोधित कर रहे हों, समाप्ति पर आपको इसे सहेजना होगा। Aspose.Slides for PHP के साथ, आप **फ़ाइल** या **स्ट्रीम** में सहेज सकते हैं। यह लेख प्रस्तुति सहेजने के विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रस्तुति सहेजें**

फ़ाइल में प्रस्तुति सहेजने के लिए [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की `save` मेथड को कॉल करें। मेथड में फ़ाइल नाम और सहेजने का फ़ॉर्मेट पास करें। नीचे का उदाहरण Aspose.Slides के साथ प्रस्तुति सहेजने का तरीका दिखाता है।

```php
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
$presentation = new Presentation();
try {
    // यहाँ कुछ काम करें...

    // प्रस्तुति को फ़ाइल में सहेजें।
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **स्ट्रीम में प्रस्तुति सहेजें**

आप आउटपुट स्ट्रीम को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की `save` मेथड में पास करके प्रस्तुति को स्ट्रीम में सहेज सकते हैं। प्रस्तुति कई प्रकार की स्ट्रीम में लिखी जा सकती है। नीचे के उदाहरण में, हम नई प्रस्तुति बनाकर उसे फ़ाइल स्ट्रीम में सहेजते हैं।

```php
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // प्रस्तुति को स्ट्रीम में सहेजें।
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **पूर्वनिर्धारित व्यू टाइप के साथ प्रस्तुति सहेजें**

Aspose.Slides आपको उत्पन्न प्रस्तुति के खोलते समय PowerPoint द्वारा उपयोग किए जाने वाले प्रारंभिक व्यू को [ViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/) क्लास के द्वारा सेट करने देता है। [setLastView](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/#setLastView) मेथड को [ViewType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewtype/) एन्यूमेरेशन के मान के साथ प्रयोग करें।

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **स्ट्रिक्ट Office Open XML फॉर्मेट में प्रस्तुति सहेजें**

Aspose.Slides आपको प्रस्तुति को स्ट्रिक्ट Office Open XML फॉर्मेट में सहेजने देता है। सहेजते समय [PptxOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxoptions/) क्लास का उपयोग करके उसकी `conformance` प्रॉपर्टी सेट करें। यदि आप [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) सेट करते हैं, तो आउटपुट फ़ाइल स्ट्रिक्ट Office Open XML फॉर्मेट में सहेजी जाती है।

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
$presentation = new Presentation();
try {
    // स्ट्रिक्ट Office Open XML फॉर्मेट में प्रस्तुति सहेजें।
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Zip64 मोड में Office Open XML फॉर्मेट में प्रस्तुति सहेजें**

Office Open XML फ़ाइल एक ZIP आर्काइव है जिसमें अनकम्प्रेस्ड फ़ाइल आकार, कम्प्रेस्ड फ़ाइल आकार और कुल आर्काइव आकार पर 4 GB (2^32 बाइट) की सीमा होती है, और आर्काइव में अधिकतम 65 535 (2^16‑1) फ़ाइलें रखी जा सकती हैं। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ा देते हैं।

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxoptions/#setZip64Mode) मेथड आपको Office Open XML फ़ाइल सहेजते समय ZIP64 फ़ॉर्मेट एक्सटेंशन कब उपयोग करना है, चुनने देता है।

यह मेथड निम्नलिखित मोड्स के साथ उपयोग किया जा सकता है:

- [IfNecessary](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zip64mode/#IfNecessary) केवल तभी ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करता है जब प्रस्तुति ऊपर दी गई सीमाओं को पार कर जाती है। यह डिफ़ॉल्ट मोड है।
- [Never](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zip64mode/#Never) कभी भी ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग नहीं करता।
- [Always](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zip64mode/#Always) हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करता है।

निचे का कोड दिखाता है कि कैसे ZIP64 फ़ॉर्मेट एक्सटेंशन सक्षम करके प्रस्तुति को PPTX फ़ाइल के रूप में सहेजा जाए:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
जब आप [Zip64Mode.Never](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zip64mode/#Never) के साथ सहेजते हैं, तो यदि प्रस्तुति को ZIP32 फ़ॉर्मेट में सहेजा नहीं जा सकता तो एक [PptxException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxexception/) फेंका जाता है।
{{% /alert %}}

## **संपीड़न स्तरों के साथ Office Open XML फॉर्मेट में प्रस्तुति सहेजें**

बड़ी प्रस्तुतियों के साथ काम करते समय आप फ़ाइल आकार और प्रोसेसिंग समय के बीच संतुलन बनाने के लिये संपीड़न स्तर को समायोजित कर सकते हैं। आपकी आवश्यकता के अनुसार आप तेज़ प्रोसेसिंग या छोटी आउटपुट फ़ाइलें पसंद कर सकते हैं।

Aspose.Slides [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxoptions/#setCompressionLevel) मेथड प्रदान करता है, जिससे आप Office Open XML फॉर्मेट में प्रस्तुति सहेजते समय उपयोग किए जाने वाले संपीड़न स्तर को निर्दिष्ट कर सकते हैं।

उपलब्ध संपीड़न स्तर इस प्रकार हैं:

- [**None**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#None): कोई संपीड़न नहीं लागू किया जाता है। फ़ाइलें जैसा है वैसी ही संग्रहीत होती हैं।
- [**Level1**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level1): सबसे तेज़ संपीड़न, लेकिन सबसे कम संपीड़न अनुपात।
- [**Level2**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level2): **Level1** से थोड़ा बेहतर संपीड़न अनुपात के साथ तेज़ संपीड़न।
- [**Level3**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level3): **Level2** से बेहतर संपीड़न, साथ ही मध्यम प्रोसेसिंग समय प्रभाव।
- [**Level4**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level4): **Level3** से बेहतर संपीड़न।
- [**Level5**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level5): **Level4** से बेहतर संपीड़न, लेकिन अतिरिक्त प्रोसेसिंग समय के साथ।
- [**Level6**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level6): मानक संपीड़न जो प्रोसेसिंग गति और फ़ाइल आकार के बीच अच्छा संतुलन देता है। यह *डिफ़ॉल्ट संपीड़न स्तर* है।
- [**Level7**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level7): **Level6** से बेहतर संपीड़न, लेकिन धीमी प्रोसेसिंग के साथ।
- [**Level8**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level8): **Level7** से बेहतर संपीड़न।
- [**Level9**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compressionlevel/#Level9): अधिकतम संपीड़न। सबसे छोटी फ़ाइल आकार, लेकिन सबसे अधिक प्रोसेसिंग समय के साथ।

निचे का उदाहरण दिखाता है कि कैसे *बिना संपीड़न* के प्रस्तुति को PPTX फ़ाइल के रूप में सहेजा जाए:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

यह उदाहरण दिखाता है कि कैसे *अधिकतम संपीड़न* के साथ प्रस्तुति को PPTX फ़ाइल के रूप में सहेजा जाए:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **थंबनेल रीफ़्रेश किए बिना प्रस्तुति सहेजें**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) मेथड PPTX में प्रस्तुति सहेजते समय थंबनेल जनरेशन को नियंत्रित करता है:

- यदि `true` पर सेट किया गया है, तो सहेजने के दौरान थंबनेल रीफ़्रेश होता है। यह डिफ़ॉल्ट है।
- यदि `false` पर सेट किया गया है, तो वर्तमान थंबनेल बना रहता है। यदि प्रस्तुति के पास थंबनेल नहीं है, तो कोई थंबनेल उत्पन्न नहीं होता।

निचे के कोड में, प्रस्तुति को थंबनेल रीफ़्रेश किए बिना PPTX में सहेजा गया है।

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
यह विकल्प PPTX फ़ॉर्मेट में प्रस्तुति सहेजने के लिये आवश्यक समय कम करने में मदद करता है।
{{% /alert %}}

## **सेव प्रोग्रेस अपडेट प्रतिशत में**

सेव‑प्रोग्रेस रिपोर्टिंग को [setProgressCallback](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveoptions/#setProgressCallback) मेथड के द्वारा [SaveOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveoptions/) और उसके सब‑क्लासेज़ पर कॉन्फ़िगर किया जाता है। एक Java प्रोक्सी प्रदान करें जो [IProgressCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/) इंटरफ़ेस को लागू करता हो; निर्यात के दौरान, कॉलबैक को नियमित रूप से प्रतिशत अपडेट प्राप्त होते हैं।

निचे का कोड स्निपेट दिखाता है कि कैसे `IProgressCallback` का उपयोग किया जाए।

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // यहाँ प्रोग्रेस प्रतिशत मान का प्रयोग करें।
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose ने अपने API का उपयोग करके एक [free PowerPoint Splitter app](https://products.aspose.app/slides/hi/splitter) विकसित किया है। यह ऐप आपको चयनित स्लाइड्स को नए PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रस्तुति को कई फ़ाइलों में विभाजित करने की सुविधा देता है।
{{% /alert %}}

## **FAQ**

**क्या "फास्ट सहेजें" (इन्क्रिमेंटल सहेजें) समर्थित है ताकि केवल परिवर्तन लिखे जाएँ?**  
नहीं। सहेजने पर प्रत्येक बार पूरी लक्ष्य फ़ाइल बनाई जाती है; इन्क्रिमेंटल “फास्ट सहेजें” समर्थित नहीं है।

**क्या एक ही Presentation इंस्टेंस को कई थ्रेड्स से सहेजना थ्रेड‑सेफ है?**  
नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ नहीं है](/slides/hi/php-java/multithreading/); इसे केवल एक थ्रेड से सहेजें।

**सहेजते समय हाइपरलिंक और बाहरी रूप से लिंक की गई फ़ाइलों के साथ क्या होता है?**  
[Hyperlinks](/slides/hi/php-java/manage-hyperlinks/) बनी रहती हैं। बाहरी लिंक की गई फ़ाइलें (जैसे रिलेटिव पाथ वाले वीडियो) स्वतः कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पाथ्स सुलभ रहें।

**क्या मैं दस्तावेज़ मेटाडेटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सहेज सकता हूँ?**  
हां। मानक [document properties](/slides/hi/php-java/presentation-properties/) समर्थित हैं और सहेजने पर फ़ाइल में लिखे जाते हैं।