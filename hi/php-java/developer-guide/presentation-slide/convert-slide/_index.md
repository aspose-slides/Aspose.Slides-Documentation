---
title: PHP में प्रस्तुति स्लाइड्स को इमेज में बदलें
linktitle: स्लाइड को इमेज
type: docs
weight: 35
url: /hi/php-java/convert-slide/
keywords:
- स्लाइड कनवर्ट करें
- स्लाइड निर्यात करें
- स्लाइड को इमेज में
- स्लाइड को इमेज के तौर पर सहेजें
- स्लाइड को EMF में
- स्लाइड को PNG में
- स्लाइड को JPEG में
- स्लाइड को बिटमैप में
- स्लाइड को TIFF में
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में PPT, PPTX और ODP प्रस्तुतियों की स्लाइड्स को PNG, JPEG, GIF, TIFF, EMF और अन्य इमेज फ़ॉर्मेट्स में बदलें।"
---
## **परिचय**

Aspose.Slides for PHP via Java PowerPoint और OpenDocument प्रस्तुतियों से व्यक्तिगत स्लाइड्स को PNG, JPEG, GIF, TIFF और अन्य इमेज फ़ॉर्मेट्स के रूप में रेंडर कर सकता है।

स्लाइड को इमेज में बदलने के लिए, नीचे दिए गए चरणों का पालन करें:

1. प्रस्तुति को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का उपयोग करके लोड करें।  
2. उस स्लाइड का चयन करें जिसे आप रेंडर करना चाहते हैं।  
3. यदि आवश्यक हो, तो रेंडरिंग को [RenderingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/renderingoptions/) या [TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) क्लास के साथ कॉन्फ़िगर करें।  
4. [Slide::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getImage) मेथड को कॉल करें। यह एक [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) ऑब्जेक्ट वापस करता है।  
5. [IImage::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/#save) मेथड को कॉल करें और आउटपुट फ़ॉर्मेट को एक [ImageFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imageformat/) मान के साथ निर्दिष्ट करें।

## **स्लाइड को PNG इमेज में बदलें**

सबसे आसान रूपांतरण डिफ़ॉल्ट रेंडरिंग सेटिंग्स का उपयोग करता है। परिणामस्वरूप [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) ऑब्जेक्ट को मेमोरी में प्रोसेस किया जा सकता है या फ़ाइल में सेव किया जा सकता है।

निम्नलिखित PHP उदाहरण पहले स्लाइड को रेंडर करता है और इसे PNG इमेज के रूप में सहेजता है:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **कस्टम आकारों के साथ स्लाइड्स को इमेज में बदलें**

स्लाइड को सटीक पिक्सेल आयामों के साथ रेंडर करने के लिए [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) मान स्वीकार करने वाले [Slide::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getImage) ओवरलोड का उपयोग करें।

निम्नलिखित उदाहरण 1820 × 1040 JPEG इमेज बनाता है:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **नोट्स और कमेंट्स के साथ स्लाइड्स को इमेज में बदलें**

डिफ़ॉल्ट रूप से, स्लाइड इमेज में नोट्स या कमेंट्स शामिल नहीं होते। नोट्स और कमेंट्स के प्रदर्शित होने के स्थान को नियंत्रित करने के लिए एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notescommentslayoutingoptions/) ऑब्जेक्ट को [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) मेथड में पास करें।

निम्नलिखित उदाहरण स्लाइड के नीचे ट्रंकेटेड नोट्स और दाईं ओर कमेंट्स रखता है:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
स्लाइड-से-इमेज रूपांतरण के लिए, [BottomFull](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notespositions/) को [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) मेथड में पास न करें। नोट्स में ऐसी अधिक मात्रा में टेक्स्ट हो सकता है जो निर्धारित इमेज आकार में फिट न हो। इसके बजाय [BottomTruncated](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notespositions/) का उपयोग करें।
{{% /alert %}}

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को इमेज में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) क्लास आपको रेंडर किए गए TIFF इमेज के आकार, रिज़ॉल्यूशन और अन्य गुणों को नियंत्रित करने देता है।

निम्नलिखित उदाहरण पहले स्लाइड को 300 DPI पर 2160 × 2880 TIFF इमेज के रूप में रेंडर करता है:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
JDK 9 से पहले के Java संस्करणों में TIFF समर्थन गारंटीकृत नहीं है।
{{% /alert %}}

## **सभी स्लाइड्स को इमेज में बदलें**

पूरी प्रस्तुति को इमेजों की श्रृंखला में बदलने के लिए स्लाइड संग्रह पर इटरेट करें। छिपी हुई स्लाइड्स को तब तक शामिल किया जाता है जब तक आप उन्हें स्पष्ट रूप से छोड़ नहीं देते।

निम्नलिखित उदाहरण प्रत्येक स्लाइड को क्षैतिज और लंबवत स्केल कारकों 2 के साथ JPEG इमेज के रूप में रेंडर करता है:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **एन्हांस्ड मेटाफाइल आउटपुट बनाएँ**

Enhanced Metafile (EMF) तब उपयोगी होता है जब वेक्टर-आधारित ग्राफ़िक्स को Microsoft Office या अन्य Windows एप्लिकेशन्स के साथ आदान‑प्रदान करना हो जो Windows मेटाफाइल को सपोर्ट करते हैं। पिक्सेल-आधारित इमेज के विपरीत, EMF वेक्टर ड्राइंग ऑपरेशन्स को बनाए रख सकता है जो स्केल होने पर भी तीक्ष्णता नहीं खोते। हालांकि, EMF मुख्यतः Windows मेटाफाइल समर्थन वाले एप्लिकेशन्स के लिए एक संगतता फ़ॉर्मेट है, सार्वभौमिक इंटरचेंज फ़ॉर्मेट नहीं। इसके अलावा, जटिल स्लाइड कंटेंट जैसे बिटमैप इमेज और कुछ इफ़ेक्ट्स को वेक्टर मेटाफाइल कंटेनर के अंदर रास्टराइज़्ड तत्वों के रूप में संग्रहित किया जा सकता है।

### **स्लाइड को EMF में एक्सपोर्ट करें**

[Slide::writeAsEmf](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#writeAsEmf) मेथड एक स्लाइड को लक्ष्य स्ट्रीम में EMF फ़ॉर्मेट में लिखता है। निम्नलिखित उदाहरण एक प्रस्तुति को लोड करता है, पहला स्लाइड चुनता है, और इसे EMF फ़ाइल स्ट्रीम में लिखता है:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

उपयोगकर्ता वह स्ट्रीम का मालिक होता है जो [Slide::writeAsEmf](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#writeAsEmf) को पास किया गया है और उसे बंद करने के लिए जिम्मेदार होता है, जैसा कि ऊपर दिखाया गया है।

### **SVG इमेज को EMF में बदलें और प्रस्तुति में जोड़ें**

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/#writeAsEmf) का उपयोग करके SVG कंटेंट को EMF में बदलें। उत्पन्न बाइट्स को [ImageCollection::addImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/#addImage) के जरिए प्रस्तुति में जोड़ा जा सकता है और [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addPictureFrame) से स्लाइड पर रखा जा सकता है।

निम्नलिखित उदाहरण SVG मार्कअप से एक [SvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/) बनाता है, इसे इन‑मेमोरी EMF में बदलता है, मेटाफाइल को पहले स्लाइड पर इनसर्ट करता है, और प्रस्तुति को सहेजता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/#writeAsEmf) डेस्टिनेशन स्ट्रीम की स्वामित्व नहीं लेता। एक [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) सभी उत्पन्न डेटा को मेमोरी में संग्रहीत करता है, इसलिए `toByteArray` कॉल करने से पहले कोई पोजीशन रीसेट आवश्यक नहीं है। लौटाई गई बाइट ऐरे स्ट्रीम बंद होने के बाद भी वैध रहती है।

EMF जनरेशन उन ऑपरेटिंग सिस्टम्स पर उपलब्ध है जो चयनित Aspose.Slides for PHP via Java और JDK कॉन्फ़िगरेशन द्वारा समर्थित हैं, लेकिन यदि फ़ॉन्ट्स या ग्राफ़िक्स निर्भरताएँ उपलब्ध नहीं हैं तो रेंडरिंग प्लेटफ़ॉर्मों में भिन्न हो सकता है। स्रोत कंटेंट द्वारा उपयोग किए गए फ़ॉन्ट्स को इंस्टॉल करें या उचित प्रतिस्थापन कॉन्फ़िगर करें, Aspose.Slides for PHP via Java के लिए [platform requirements](/slides/hi/php-java/system-requirements/) का पालन करें, और लक्ष्य EMF-उपयोग करने वाले एप्लिकेशन में परिणाम को मान्य करें। Linux और macOS एप्लिकेशन्स अक्सर Windows मेटाफाइल को दिखाने और एडिट करने में सीमित या असंगत समर्थन रखते हैं।

## **कलर ईमोजी रेंडरिंग**

{{% alert title="Note" color="info" %}}
प्रेजेंटेशन स्लाइड्स को इमेज में बदलते समय कलर ईमोजी को सही तरीके से रेंडर करने के लिए, प्रस्तुति में उपयोग किए गए ईमोजी फ़ॉन्ट्स को उस सिस्टम पर इंस्टॉल और उपलब्ध होना चाहिए जहाँ रूपांतरण किया जा रहा है। उदाहरण के तौर पर, यदि प्रस्तुति में **Segoe UI Emoji** फ़ॉन्ट उपयोग किया गया है और वह फ़ॉन्ट नहीं है, तो ईमोजी आउटपुट इमेज में मोनोक्रोम दिख सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides एनीमेशन वाली स्लाइड्स को रेंडर करने का समर्थन करता है?**  
नहीं। [Slide::getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getImage) मेथड स्लाइड की स्थिर इमेज रेंडर करता है और एनीमेशन को एक्सपोर्ट नहीं करता।

**क्या छिपी स्लाइड्स को इमेज के रूप में एक्सपोर्ट किया जा सकता है?**  
हां। छिपी स्लाइड्स को सामान्य स्लाइड्स की तरह रेंडर किया जा सकता है। उपरोक्त उदाहरण में दिखाए अनुसार उन्हें प्रोसेसिंग लूप में शामिल करें।

**क्या शैडोज़ और अन्य इफ़ेक्ट्स स्लाइड इमेज में संरक्षित रहते हैं?**  
हां। Aspose.Slides स्लाइड इमेज में शैडोज़, ट्रांसपरेंसी और अन्य समर्थित ग्राफ़िकल इफ़ेक्ट्स को रेंडर करता है।