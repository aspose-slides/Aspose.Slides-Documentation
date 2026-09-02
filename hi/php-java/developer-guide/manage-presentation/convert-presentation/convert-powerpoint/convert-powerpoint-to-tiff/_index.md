---
title: PowerPoint प्रस्तुतियों को PHP में TIFF में परिवर्तित करें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/php-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint परिवर्तित करें
- OpenDocument परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से TIFF
- प्रस्तुति से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP के साथ Java के माध्यम से PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च‑गुणवत्ता वाले TIFF इमेज में आसानी से बदलना सीखें, कोड उदाहरणों के साथ।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से प्रयुक्त, नुकसान‑रहित रास्टर इमेज फ़ॉर्मेट है जो अपनी उत्कृष्ट गुणवत्ता और ग्राफ़िक्स का विस्तृत संरक्षण करने के लिए जाना जाता है। डिज़ाइनर, फ़ोटोग्राफ़र, और डेस्कटॉप प्रकाशक अक्सर TIFF को लेयर्स, रंग सटीकता, और अपनी छवियों में मूल सेटिंग्स बनाए रखने के लिए चुनते हैं।

Aspose.Slides का उपयोग करके, आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च‑गुणवत्ता वाले TIFF इमेज में आसानी से बदल सकते हैं, जिससे आपकी प्रस्तुतियों में अधिकतम दृश्य सटीकता बनी रहती है।

## **प्रेजेंटेशन को TIFF में बदलें**

दिए गए [save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) मेथड का उपयोग करके, जो [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास द्वारा प्रदान किया गया है, आप शीघ्रता से पूरी PowerPoint प्रेजेंटेशन को TIFF में बदल सकते हैं। उत्पन्न हुए TIFF इमेज डिफ़ॉल्ट स्लाइड आकार के अनुरूप होते हैं।

यह कोड दिखाता है कि PowerPoint प्रेजेंटेशन को TIFF में कैसे बदलें:

```php
// प्रेजेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
$presentation = new Presentation("presentation.pptx");
try {
    // प्रेजेंटेशन को TIFF के रूप में सहेजें।
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **प्रेजेंटेशन को ब्लैक-एंड-व्हाइट TIFF में बदलें**

[setBwConversionMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#setBwConversionMode) मेथड [TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) क्लास में आपको यह निर्दिष्ट करने की अनुमति देता है कि रंगीन स्लाइड या इमेज को ब्लैक-एंड-व्हाइट TIFF में बदलते समय कौन सा एल्गोरिद्म उपयोग किया जाएगा। ध्यान दें कि यह सेटिंग केवल तभी लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#getCompressionType) मेथड `CCITT4` या `CCITT3` पर सेट हो।

{{% alert color="info" title="Note" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#setBwConversionMode) एक एक्सपोर्ट-लेवल सेटिंग है जो पूर्ण TIFF इमेज के लिए पिक्सेल‑कन्वर्ज़न एल्गोरिद्म चुनती है। यह निर्धारित करने के लिए कि जब ब्लैक‑एंड‑व्हाइट डिस्प्ले मोड सक्रिय हो तो व्यक्तिगत शेप कैसे दिखेगा, [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#setBlackWhiteMode) का उपयोग करें। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/slides/hi/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह कोड दिखाता है कि रंगीन स्लाइड को ब्लैक-एंड-व्हाइट TIFF में कैसे बदला जाए:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![ब्लैक-एंड-व्हाइट TIFF](TIFF_black_and_white.png)

## **प्रेजेंटेशन को कस्टम साइज के साथ TIFF में बदलें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके अपनी वांछित मान सेट कर सकते हैं। उदाहरण के लिए, [setImageSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#getImageSize) मेथड आपको उत्पन्न इमेज का आकार निर्धारित करने की अनुमति देता है।

यह कोड दर्शाता है कि PowerPoint प्रेजेंटेशन को कस्टम साइज वाले TIFF इमेज में कैसे बदला जाए:

```php
// Presentation क्लास का इंस्टेंस बनाएं जो एक प्रेजेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // कॉम्प्रेशन प्रकार सेट करें।
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    कॉम्प्रेशन प्रकार:
        Default - डिफ़ॉल्ट संपीड़न योजना (LZW) को निर्दिष्ट करता है।
        None - कोई संपीड़न नहीं निर्दिष्ट करता।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई संपीड़न प्रकार पर निर्भर करती है और इसे मैन्युअली सेट नहीं किया जा सकता।

    // इमेज DPI सेट करें।
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // इमेज आकार सेट करें।
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // निर्दिष्ट आकार के साथ प्रेजेंटेशन को TIFF के रूप में सहेजें।
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **प्रेजेंटेशन को कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) क्लास की [setPixelFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#getPixelFormat) मेथड का उपयोग करके, आप उत्पन्न TIFF इमेज के लिए अपना पसंदीदा पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह कोड दर्शाता है कि PowerPoint प्रेजेंटेशन को कस्टम पिक्सेल फ़ॉर्मेट वाले TIFF इमेज में कैसे बदला जाए:

```php
// Presentation क्लास का इंस्टेंस बनाएं जो एक प्रेजेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में जैसा बताया गया है):
        Format1bppIndexed - 1 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format4bppIndexed - 4 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format8bppIndexed - 8 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB।
        Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB।
    */

    // निर्दिष्ट इमेज आकार के साथ प्रेजेंटेशन को TIFF के रूप में सहेजें।
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose के [नि:शुल्क PowerPoint से पोस्टर कन्वर्टर](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी PowerPoint प्रेजेंटेशन के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रेजेंटेशन से व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेज में बदलने की अनुमति देता है।

**क्या प्रेजेंटेशन को TIFF में बदलते समय स्लाइड्स की संख्या पर कोई सीमा है?**

नहीं, Aspose.Slides स्लाइड्स की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार के प्रेजेंटेशन को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या PowerPoint एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स स्लाइड्स को TIFF में बदलते समय संरक्षित रहते हैं?**

नहीं, TIFF एक स्थिर इमेज फ़ॉर्मेट है। इसलिए, एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं होते; केवल स्लाइड्स के स्थिर स्नैपशॉट निर्यात होते हैं।