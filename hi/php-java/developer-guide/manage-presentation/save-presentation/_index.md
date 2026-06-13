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
- पूर्वनिर्धारित दृश्य प्रकार
- कठोर Office Open XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रीफ़्रेश करना
- सेव प्रगति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP के माध्यम से प्रस्तुतियों को सहेजने के तरीकों की खोज करें — PowerPoint या OpenDocument में निर्यात करें और लेआउट, फ़ॉन्ट और इफ़ेक्ट्स को बनाए रखें।"
---
## **परिचय**

[PHP में प्रस्तुतियाँ खोलें](/slides/hi/php-java/open-presentation/) ने बताया कि प्रस्तुति खोलने के लिए [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का उपयोग कैसे करें। यह लेख बताता है कि प्रस्तुतियों को कैसे बनाएँ और सहेजें। [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास में प्रस्तुति की सामग्री रहती है। चाहे आप शून्य से प्रस्तुति बना रहे हों या मौज़ूदगी को संशोधित कर रहे हों, पूर्ण होने पर आपको इसे सहेजना चाहिए। Aspose.Slides for PHP के साथ, आप **फ़ाइल** या **स्ट्रीम** में सहेज सकते हैं। यह लेख प्रस्तुति को सहेजने के विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

स्प्रेज़न को फ़ाइल में सहेजने के लिए [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की `save` विधि को कॉल करें। विधि को फ़ाइल नाम और सहेजने का फ़ॉर्मेट पास करें। नीचे दिया गया उदाहरण Aspose.Slides के साथ प्रस्तुति को सहेजने का तरीका दर्शाता है।

```php
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएँ.
$presentation = new Presentation();
try {
    // यहाँ कुछ कार्य करें...

    // प्रस्तुति को फ़ाइल में सहेजें.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

आप [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की `save` विधि में आउटपुट स्ट्रीम पास करके प्रस्तुति को स्ट्रीम में सहेज सकते हैं। प्रस्तुति कई प्रकार की स्ट्रीम में लिखी जा सकती है। नीचे दिए उदाहरण में, हम नई प्रस्तुति बनाते हैं और इसे फ़ाइल स्ट्रीम में सहेजते हैं।

```php
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को उदाहरणित करें.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // प्रस्तुति को स्ट्रीम में सहेजें.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **पूर्वनिर्धारित दृश्य प्रकार के साथ प्रस्तुतियों को सहेजें**

Aspose.Slides आपको [ViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/) क्लास के माध्यम से यह निर्धारित करने की सुविधा देता है कि जनित प्रस्तुति खुलते समय PowerPoint कौन सा प्रारंभिक दृश्य उपयोग करे। [ViewType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewtype/) एन्यूमरेशन के किसी मान के साथ [setLastView](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/#setLastView) विधि का प्रयोग करें।

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **कठोर Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Aspose.Slides आपको प्रस्तुति को कठोर Office Open XML फ़ॉर्मेट में सहेजने की अनुमति देता है। सहेजते समय [PptxOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxoptions/) क्लास का उपयोग करें और उसकी conformance प्रॉपर्टी सेट करें। यदि आप [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) सेट करते हैं, तो आउटपुट फ़ाइल कठोर Office Open XML फ़ॉर्मेट में सहेजी जाती है।

नीचे दिया गया उदाहरण प्रस्तुति बनाता है और उसे कठोर Office Open XML फ़ॉर्मेट में सहेजता है।

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को उदाहरणित करें.
$presentation = new Presentation();
try {
    // कठोर Office Open XML फ़ॉर्मेट में प्रस्तुति को सहेजें.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Zip64 मोड में Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Office Open XML फ़ाइल एक ZIP आर्काइव है जो अनकम्प्रेस्ड फ़ाइल आकार, कम्प्रेस्ड फ़ाइल आकार और कुल आर्काइव आकार पर 4 GB (2^32 बाइट) की सीमा लगाता है, तथा आर्काइव को 65 535 (2^16‑1) फ़ाइलों तक सीमित करता है। ZIP64 फ़ॉर्मेट विस्तार इन सीमाओं को 2^64 तक बढ़ाते हैं।

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxoptions/#setZip64Mode) विधि आपको Office Open XML फ़ाइल सहेजते समय ZIP64 फ़ॉर्मेट विस्तार का उपयोग कब करना है चुनने देती है।

यह विधि निम्नलिखित मोड्स के साथ उपयोग की जा सकती है:

- [IfNecessary](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zip64mode/#IfNecessary) केवल तब ZIP64 फ़ॉर्मेट विस्तार का उपयोग करता है जब प्रस्तुति उपर्युक्त सीमाओं को पार करती है। यह डिफ़ॉल्ट मोड है।
- [Never](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zip64mode/#Never) कभी भी ZIP64 फ़ॉर्मेट विस्तार का उपयोग नहीं करता।
- [Always](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zip64mode/#Always) हमेशा ZIP64 फ़ॉर्मेट विस्तार का उपयोग करता है।

निम्न कोड PPTX को ZIP64 फ़ॉर्मेट विस्तार सक्षम करके सहेजने का तरीका दर्शाता है:

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
जब आप [Zip64Mode.Never](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zip64mode/#Never) के साथ सहेजते हैं, तो यदि प्रस्तुति ZIP32 फ़ॉर्मेट में सहेजी नहीं जा सकती, तो एक [PptxException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxexception/) फेंका जाता है।
{{% /alert %}}

## **थंबनेल रीफ़्रेश किए बिना प्रस्तुतियों को सहेजें**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) विधि PPTX में प्रस्तुति सहेजते समय थंबनेल जनरेशन को नियंत्रित करती है:

- यदि `true` पर सेट किया जाता है, तो सहेजने के दौरान थंबनेल रीफ़्रेश किया जाता है। यह डिफ़ॉल्ट है।
- यदि `false` पर सेट किया जाता है, तो मौजूदा थंबनेल संरक्षित रहता है। यदि प्रस्तुति में थंबनेल नहीं है, तो कोई थंबनेल जेनरेट नहीं किया जाता।

नीचे दिए कोड में, प्रस्तुति थंबनेल रीफ़्रेश किए बिना PPTX में सहेजी गई है।

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
यह विकल्प PPTX फ़ॉर्मेट में प्रस्तुति सहेजने में लगने वाले समय को घटाने में मदद करता है।
{{% /alert %}}

## **प्रगति अद्यतन को प्रतिशत में सहेजें**

सेव‑प्रोग्रेस रिपोर्टिंग को [SaveOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveoptions/) और उसकी सब‑क्लासेज़ पर [setProgressCallback](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveoptions/#setProgressCallback) विधि के माध्यम से कॉन्फ़िगर किया जाता है। एक Java प्रॉक्सी प्रदान करें जो [IProgressCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/) इंटरफ़ेस को लागू करता हो; निर्यात के दौरान, कॉलबैक समय‑समय पर प्रतिशत अद्यतन प्राप्त करता है।

नीचे `IProgressCallback` के उपयोग का示例 कोड दिया गया है:

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // यहाँ प्रगति प्रतिशत मान का उपयोग करें.
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
Aspose ने अपना स्वयं का API उपयोग करके एक [नि:शुल्क PowerPoint Splitter एप्लिकेशन](https://products.aspose.app/slides/hi/splitter) विकसित किया है। यह एप्लिकेशन चयनित स्लाइडों को नई PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रस्तुति को कई फ़ाइलों में विभाजित करने की सुविधा देती है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या "त्वरित सहेजें" (incremental save) समर्थित है ताकि केवल बदलाव लिखे जाएँ?**

नहीं। सहेजने पर प्रत्येक बार पूर्ण लक्ष्य फ़ाइल बनाई जाती है; इन्क्रिमेंटल "त्वरित सहेजें" समर्थित नहीं है।

**क्या एक ही Presentation इंस्टेंस को कई थ्रेड्स से सहेजना थ्रेड‑सेफ़ है?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ़ नहीं है](/slides/hi/php-java/multithreading/); इसे एक ही थ्रेड से सहेजें।

**सहेजने पर हाइपरलिंक और बाहरी रूप से लिंक की गई फ़ाइलें क्या होती हैं?**

[हाइपरलिंक](/slides/hi/php-java/manage-hyperlinks/) संरक्षित रहते हैं। बाहरी रूप से लिंक की गई फ़ाइलें (जैसे सापेक्ष पाथ वाली वीडियो) स्वचालित रूप से कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पाथ उपलब्ध रहें।

**क्या मैं दस्तावेज़ मेटाडेटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सहेज सकता हूँ?**

हाँ। मानक [दस्तावेज़ गुण](/slides/hi/php-java/presentation-properties/) समर्थित हैं और सहेजने पर फ़ाइल में लिखे जाएंगे।