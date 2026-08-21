---
title: PHP में PowerPoint प्रस्तुतियों को TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/php-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint को बदलें
- OpenDocument को बदलें
- प्रस्तुति को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
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
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च गुणवत्ता वाले TIFF चित्रों में आसानी से कैसे बदलें, इसका सीखें, कोड उदाहरणों के साथ।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, बिना हानि वाला रास्टर इमेज फ़ॉर्मेट है, जिसे इसकी अपूर्व गुणवत्ता और ग्राफ़िक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिज़ाइनर, फ़ोटोग्राफ़र, और डेस्कटॉप पब्लिशर अक्सर TIFF को अपने इमेज में लेयर्स, रंग सटीकता, और मूल सेटिंग्स बनाए रखने के लिए चुनते हैं।

Aspose.Slides का उपयोग करके, आप आसानी से अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च-गुणवत्ता वाले TIFF चित्रों में बदल सकते हैं, जिससे आपकी प्रस्तुतियाँ अधिकतम दृश्य सटीकता बनाए रखें।

## **एक प्रस्तुति को TIFF में बदलें**

आप [save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) मेथड, जो कि [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास द्वारा प्रदान किया गया है, का उपयोग करके, जल्दी से पूरी PowerPoint प्रस्तुति को TIFF में बदल सकते हैं। परिणामी TIFF चित्र डिफ़ॉल्ट स्लाइड आकार के अनुरूप होते हैं।

यह कोड दिखाता है कि कैसे PowerPoint प्रस्तुति को TIFF में बदला जाए:

```php
// प्रेजेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाने वाली Presentation क्लास को इंस्टेन्शिएट करें।
$presentation = new Presentation("presentation.pptx");
try {
    // प्रेजेंटेशन को TIFF के रूप में सहेजें।
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **एक प्रस्तुति को श्याम-श्वेत TIFF में बदलें**

विधि [setBwConversionMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#setBwConversionMode) [TiffOptions] क्लास में आपको रंगीन स्लाइड या चित्र को श्याम-श्वेत TIFF में बदलने के लिए उपयोग किए जाने वाले एल्गोरिदम को निर्दिष्ट करने की अनुमति देती है। ध्यान दें कि यह सेटिंग केवल तभी लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#getCompressionType) मेथड `CCITT4` या `CCITT3` पर सेट हो।

{{% alert color="info" title="Note" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#setBwConversionMode) एक निर्यात-स्तर की सेटिंग है जो पूरी TIFF छवि के लिए पिक्सेल-परिवर्तन एल्गोरिदम चुनती है। जब श्याम-श्वेत डिस्प्ले मोड सक्रिय हो, तो किसी व्यक्तिगत आकार (shape) के दिखने को निर्धारित करने के लिए [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#setBlackWhiteMode) का उपयोग करें। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह कोड दिखाता है कि कैसे रंगीन स्लाइड को श्याम-श्वेत TIFF में बदला जाए:

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

![श्याम-श्वेत TIFF](TIFF_black_and_white.png)

## **एक प्रस्तुति को कस्टम आकार के साथ TIFF में बदलें**

यदि आपको विशिष्ट आयामों वाला TIFF चित्र चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) में उपलब्ध विधियों का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, [setImageSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#getImageSize) मेथड आपको परिणामस्वरूप चित्र का आकार निर्धारित करने की अनुमति देता है।

यह कोड दिखाता है कि कैसे PowerPoint प्रस्तुति को कस्टम आकार के साथ TIFF चित्रों में बदला जाए:

```php
// प्रेजेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाने वाली Presentation क्लास को इंस्टेन्शिएट करें।
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // संपीड़न प्रकार सेट करें।
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    संपीड़न प्रकार:
        Default - डिफ़ॉल्ट संपीड़न योजना (LZW) निर्दिष्ट करता है।
        None - कोई संपीड़न नहीं निर्दिष्ट करता।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई (depth) संपीड़न प्रकार पर निर्भर करती है और मैन्युअल रूप से सेट नहीं की जा सकती।

    // इमेज DPI सेट करें।
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // इमेज आकार सेट करें।
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **एक प्रस्तुति को कस्टम इमेज पिक्सेल फॉर्मेट के साथ TIFF में बदलें**

[TiffOptions] क्लास की [setPixelFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#getPixelFormat) मेथड का उपयोग करके, आप परिणामस्वरूप TIFF चित्र के लिए अपनी इच्छित पिक्सेल फॉर्मेट निर्दिष्ट कर सकते हैं।

यह कोड दिखाता है कि कैसे PowerPoint प्रस्तुति को कस्टम पिक्सेल फॉर्मेट वाले TIFF चित्र में बदला जाए:

```php
// प्रेजेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाने वाली Presentation क्लास को इंस्टेन्शिएट करें।
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में जैसा बताया गया है):
        Format1bppIndexed - प्रति पिक्सेल 1 बिट, अनुक्रमित।
        Format4bppIndexed - प्रति पिक्सेल 4 बिट, अनुक्रमित।
        Format8bppIndexed - प्रति पिक्सेल 8 बिट, अनुक्रमित।
        Format24bppRgb    - प्रति पिक्सेल 24 बिट, RGB।
        Format32bppArgb   - प्रति पिक्सेल 32 बिट, ARGB।
    */

    // निर्दिष्ट इमेज आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose के [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी PowerPoint प्रस्तुति के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों की व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF चित्रों में बदलने की अनुमति देता है।

**क्या प्रस्तुति को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रस्तुतियों को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या PowerPoint एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स स्लाइड्स को TIFF में बदलते समय संरक्षित रहते हैं?**

नहीं, TIFF एक स्थैतिक चित्र फ़ॉर्मेट है। इसलिए, एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं रहते; केवल स्लाइडों के स्थैतिक स्नैपशॉट निर्यात किए जाते हैं।