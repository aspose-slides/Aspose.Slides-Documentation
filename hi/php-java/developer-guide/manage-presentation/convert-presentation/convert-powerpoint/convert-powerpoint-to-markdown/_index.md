---
title: PHP में PowerPoint प्रस्तुतियों को Markdown में परिवर्तित करें
linktitle: PowerPoint से Markdown
type: docs
weight: 140
url: /hi/php-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint को रूपांतरित करें
- प्रस्तुति को रूपांतरित करें
- स्लाइड को रूपांतरित करें
- PPT को रूपांतरित करें
- PPTX को रूपांतरित करें
- PowerPoint को MD में
- प्रस्तुति को MD में
- स्लाइड को MD में
- PPT को MD में
- PPTX को MD में
- PowerPoint को Markdown के रूप में सहेजें
- प्रस्तुति को Markdown के रूप में सहेजें
- स्लाइड को Markdown के रूप में सहेजें
- PPT को MD के रूप में सहेजें
- PPTX को MD के रूप में सहेजें
- PPT को MD में निर्यात करें
- PPTX को MD में निर्यात करें
- Markdown छवि निर्यात
- CDN छवि लिंक
- PowerPoint
- प्रस्तुति
- Markdown
- PHP
- Aspose.Slides
description: "PHP में PPT और PPTX प्रस्तुतियों को Markdown में परिवर्तित करें और निर्यात की गई बिटमैप, मेटाफाइल और SVG छवियों को कहाँ सहेजा और संदर्भित किया जाए, इसे नियंत्रित करें."
---
## **अवलोकन**

Aspose.Slides for PHP via Java PPT और PPTX प्रस्तुतियों को दस्तावेजीकरण, स्थैतिक‑साइट, सामग्री‑स्थानांतरण और संस्करण‑नियंत्रण कार्यप्रवाहों के लिए Markdown में बदल सकता है। आप एक Markdown फ़्लेवर चुन सकते हैं, स्लाइड सामग्री के रेंडरिंग को नियंत्रित कर सकते हैं, और यह तय कर सकते हैं कि निर्यात की गई छवियां कहाँ संग्रहीत होंगी और उत्पन्न Markdown उन पर कैसे संदर्भित करता है।

डिफ़ॉल्ट रूप से, Markdown निर्यात केवल‑पाठ आउटपुट का उपयोग करता है। दृश्य सामग्री निर्यात करने के लिए, निर्यात प्रकार को [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) मेथड से `Sequential` या `Visual` मान पर सेट करें, जो [MarkdownExportType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownexporttype/) एनेमरेशन से प्राप्त होते हैं। `Sequential` स्लाइड आइटम को अलग‑अलग और क्रम में रेंडर करता है, जबकि `Visual` समूहित आइटम को एक साथ रखता है ताकि उनका दृश्य संबंध बना रहे। `TextOnly` मान छवि संसाधन नहीं उत्पन्न करता, इसलिए उस मोड में इमेज‑सेविंग कॉलबैक नहीं चलाए जाते।

## **प्रेजेंटेशन को Markdown में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास से लोड करें, और फिर [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) मेथड को `Md` मान के साथ कॉल करें, जो [SaveFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) एनेमरेशन से लिया गया है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Markdown फ़्लेवर चुनें**

[MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) मेथड आउटपुट के लिए उपयोग की जाने वाली Markdown विशिष्टता को नियंत्रित करता है। [Flavor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/flavor/) एनेमरेशन में CommonMark, GitHub Flavored Markdown और अन्य समर्थित वेरिएंट शामिल हैं।

निम्न उदाहरण एक प्रेजेंटेशन को CommonMark के रूप में निर्यात करता है:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **डिफ़ॉल्ट स्थानीय‑सहेजने वाले व्यवहार के साथ छवियों को निर्यात करें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) क्लास स्थानीय रूप से सहेजी गई छवियों को कॉन्फ़िगर करने के दो मेथड प्रदान करता है:

- [setBasePath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) Markdown दस्तावेज़ और उसके संसाधनों के लिए आधार निर्देशिका निर्धारित करता है।
- [setImagesSaveFolderName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) छवि उपनिर्देशिका निर्धारित करता है। इसका डिफ़ॉल्ट मान `Images` है।

निम्न उदाहरण दृश्य सामग्री रेंडर करता है, छवियों को `output/assets` में लिखता है, और Markdown दस्तावेज़ में सापेक्ष छवि संदर्भ बनाता है:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

यह व्यवहार तब भी लागू होता है जब कस्टम इमेज‑सेविंग हैंडलर `false` लौटाता है।

## **छवि सहेजना और Markdown लिंक को अनुकूलित करें**

[MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) मेथड का उपयोग करके आप Markdown निर्यात के दौरान उत्पन्न गैर‑SVG बिटमैप और मेटाफाइल संसाधनों के लिए एक कॉलबैक पंजीकृत कर सकते हैं। इसका `MarkdownImageSavingHandler` कॉलबैक [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) ऑब्जेक्ट, उसका [ImageFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imageformat/) मान, और उत्पन्न Markdown लिंक को एक‑तत्वीय Java स्ट्रिंग एरे के रूप में प्राप्त करता है। प्रदान किए गए फ़ॉर्मेट के साथ छवि को सहेजें या अपलोड करें, और `$link[0]` को उस संदर्भ से बदलें जो Markdown आउटपुट में दिखाई देना चाहिए।

SVG फ़ॉर्मेट में उत्पन्न संसाधनों को अलग से संभाला जाता है। [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) मेथड के साथ एक कॉलबैक पंजीकृत करें। इसका `MarkdownSvgImageSavingHandler` कॉलबैक एक [ISvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/isvgimage/) ऑब्जेक्ट और एक‑तत्वीय Java स्ट्रिंग एरे `$link` प्राप्त करता है। SVG में `ImageFormat` तर्क नहीं होता; इसके बजाय [ISvgImage::getSvgData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/isvgimage/) मेथड से उसका XML डेटा लिखें या अपलोड करें। निर्यात मोड और दृश्य समूहबद्धता के आधार पर स्रोत प्रेजेंटेशन में SVG को रास्टराइज़ या अन्य सामग्री के साथ संयोजित किया जा सकता है; परिणामस्वरूप गैर‑SVG संसाधन तब इमेज‑सेविंग कॉलबैक को पास किया जाता है। जब प्रत्येक निर्यातित दृश्य संसाधन को कस्टम प्रोसेसिंग की आवश्यकता हो तो दोनों कॉलबैक पंजीकृत करें।

PHP via Java में प्रत्येक कॉलबैक को एक PHP क्लास में लागू करें और `java_closure` का उपयोग करके उस ऑब्जेक्ट को संबंधित Java इंटरफ़ेस के रूप में एक्सपोज़ करें।

{{% alert color="info" title="Note" %}}
`JAVA_PREFER_VALUES` सक्षम करके PHP/Java ब्रिज को `Java.inc` लोड करने से पहले इनिशियलाइज़ करें। [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) मेथड `void` लौटाता है, और ब्रिज का डिफ़ॉल्ट स्ट्रीम मोड उस क्यू किए कॉल के दौरान PHP कॉलबैक को नहीं चलाता। नीचे दिया गया पूरा उदाहरण आवश्यक इनिशियलाइज़ेशन शामिल करता है।
{{% /alert %}}

हैंडलर का रिटर्न वैल्यू यह निर्धारित करता है कि छवि कौन प्रोसेस करता है:

- यदि हैंडलर ने छवि को सहेजा, अपलोड किया, ट्रांसफ़ॉर्म किया या अन्यथा प्रोसेस किया और `$link[0]` को वैध मान दिया, तो `true` लौटाएँ। Aspose.Slides उस मान को Markdown दस्तावेज़ में लिखता है और उसका डिफ़ॉल्ट स्थानीय सहेजना नहीं करता।
- `false` लौटाएँ ताकि Aspose.Slides छवि को स्थानीय रूप से सहेजे और लिंक को [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) और [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) द्वारा सेट किए गए मानों के अनुसार उत्पन्न करे।

{{% alert color="warning" title="Important" %}}
एक हैंडलर जो `true` लौटाता है, छवि की ज़िम्मेदारी लेता है। यदि वह वैध, गैर‑खाली लिंक असाइन किए बिना `true` लौटाता है, तो निर्यात `InvalidOperationException` के साथ विफल हो जाएगा।
{{% /alert %}}

### **छवियों को CDN मूल निर्देशिका में सहेजें और बाहरी URLs का उपयोग करें**

निम्न उदाहरण `cdn-origin/presentations/quarterly-report` को माउंटेड या सिंक्रोनाइज़्ड CDN मूल निर्देशिका मानता है। प्रत्येक हैंडलर उत्पन्न फ़ाइलनाम निकालता है, छवि को उस कस्टम निर्देशिका में सहेजता है, और उत्पन्न स्थानीय संदर्भ को सार्वजनिक CDN URL से बदल देता है। नमूना स्वयं कोई नेटवर्क अपलोड नहीं करता: URL केवल तब वैध बनता है जब निर्देशिका को CDN मूल के रूप में माउंट किया गया हो या उसकी फ़ाइलें CDN पर प्रकाशित हों। ऑब्जेक्ट स्टोरेज के लिए, फ़ाइल‑सिस्टम लिखने को स्टोरेज SDK के अपलोड ऑपरेशन से बदलें और केवल अपलोड सफल होने पर `$link[0]` असाइन करें।

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

बिटमैप हैंडलर जानबूझकर 128 × 128 पिक्सेल से छोटी छवियों के लिए `false` लौटाता है, इसलिए Aspose.Slides उन छवियों को `output/fallback-images` में डिफ़ॉल्ट व्यवहार का उपयोग करके सहेजता है। बड़ी बिटमैप और मेटाफाइल संसाधन, साथ ही SVG संसाधन, कस्टम कोड द्वारा संभाले जाते हैं। उदाहरण के लिए, उत्पन्न स्थानीय संदर्भ `fallback-images/image1.png` बन जाता है `https://cdn.example.com/presentations/quarterly-report/image1.png`। हैंडलर फ़ाइल‑सिस्टम पाथ लिखते समय केवल ऑपरेटिंग‑सिस्टम पाथ का उपयोग करते हैं; Markdown में लिखे गए लिंक फ़ॉरवर्ड स्लैश और URL‑escaped फ़ाइलनाम का उपयोग करते हैं। सापेक्ष लिंक बनाते समय भी वही नियम अपनाएँ: `/` प्रयोग करें, प्लेटफ़ॉर्म‑विशिष्ट डिरेक्टरी सेपरेटर नहीं।

## **FAQ**

**क्या एक ही हैंडलर रास्टर छवियों और SVG छवियों दोनों को प्रोसेस कर सकता है?**

नहीं। उत्पन्न बिटमैप और मेटाफाइल संसाधनों के लिए [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) और SVG के रूप में उत्पन्न संसाधनों के लिए [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) का उपयोग करें। former एक [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) ऑब्जेक्ट और एक [ImageFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imageformat/) मान प्रदान करता है; latter एक [ISvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/isvgimage/) ऑब्जेक्ट देता है जिसका SVG डेटा [ISvgImage::getSvgData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/isvgimage/) से पढ़ा जा सकता है। निर्यात के दौरान रास्टराइज़ किया गया स्रोत SVG इमेज‑सेविंग कॉलबैक द्वारा प्रोसेस किया जाता है।

**जब इमेज‑सेविंग हैंडलर `false` लौटाता है तो क्या होता है?**

Aspose.Slides अपना डिफ़ॉल्ट स्थानीय‑सहेजने वाला व्यवहार उपयोग करता है। छवि स्थान और उत्पन्न संदर्भ को [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) और [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/markdownsaveoptions/) द्वारा सेट किए गए मान नियंत्रित करते हैं।

**क्या हैंडलर बिना छवि को स्थानीय रूप से सहेजे URL प्रदान कर सकता है?**

हां। हैंडलर छवि को ऑब्जेक्ट स्टोरेज में अपलोड कर सकता है या किसी अन्य सेवा को पास कर सकता है, परिणामी URL को `$link[0]` में असाइन कर सकता है, और `true` लौटाए। हैंडलर को स्वयं प्रोसेसिंग पूरी करनी होगी; `true` लौटाने से डिफ़ॉल्ट स्थानीय सहेजना रोक जाता है।

**Markdown निर्यात हैंडलर से `InvalidOperationException` क्यों फेंकता है?**

यह तब होता है जब हैंडलर `true` लौटाता है लेकिन वैध लिंक प्रदान नहीं करता। `true` लौटाने से पहले वह सापेक्ष पाथ या बाहरी URL असाइन करें जो Markdown में लिखा जाना चाहिए।

**छवि लिंक के लिए कौन सा पाथ सेपरेटर उपयोग करना चाहिए?**

Markdown लिंक और URLs में फ़ॉरवर्ड स्लैश (`/`) उपयोग करें। फ़ाइल‑सिस्टम पाथ के लिए केवल `DIRECTORY_SEPARATOR` प्रयोग करें, फिर Markdown संदर्भ को अलग से बनाएं या सामान्यीकृत करें।

**क्या Markdown निर्यात के दौरान हाइपरलिंक संरक्षित रहते हैं?**

हां। टेक्स्ट [hyperlinks](/slides/hi/php-java/manage-hyperlinks/) को मानक Markdown लिंक के रूप में संरक्षित रखा जाता है। स्लाइड [transitions](/slides/hi/php-java/slide-transition/) और [animations](/slides/hi/php-java/powerpoint-animation/) को परिवर्तित नहीं किया जाता।

**क्या प्रेजेंटेशन को समानांतर में Markdown में बदला जा सकता है?**

आप विभिन्न प्रेजेंटेशन फ़ाइलों को समानांतर में प्रोसेस कर सकते हैं, लेकिन एक ही [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स के बीच साझा नहीं करें। [multithreading guidelines](/slides/hi/php-java/multithreading/) का पालन करें और प्रत्येक फ़ाइल के लिए एक अलग इंस्टेंस उपयोग करें।