---
title: PHP में PowerPoint प्रस्तुतियों को TIFF में बदलें
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
- PowerPoint को TIFF में
- प्रस्तुति को TIFF में
- स्लाइड को TIFF में
- PPT को TIFF में
- PPTX को TIFF में
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च-गुणवत्ता वाले TIFF छवियों में आसानी से बदलना सीखें, कोड उदाहरणों के साथ।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फॉर्मेट है जो अपनी उत्कृष्ट गुणवत्ता और ग्राफिक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र और डेस्कटॉप पब्लिशर अक्सर TIFF को अपने चित्रों में लेयर्स, रंग सटीकता और मूल सेटिंग्स को बनाए रखने के लिए चुनते हैं।

Aspose.Slides का उपयोग करके आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च‑गुणवत्ता वाले TIFF इमेज में आसानी से बदल सकते हैं, जिससे आपके प्रस्तुतियों की दृश्य सत्यता अधिकतम बनी रहती है।

## **प्रेजेंटेशन को TIFF में बदलें**

[save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) मेथड को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास द्वारा प्रदान किया गया है, जिससे आप पूरी PowerPoint प्रेजेंटेशन को जल्दी से TIFF में बदल सकते हैं। उत्पन्न TIFF इमेज डिफॉल्ट स्लाइड आकार के अनुरूप होंगे।

यह कोड दिखाता है कि PowerPoint प्रेजेंटेशन को TIFF में कैसे बदलें:

```php
// Presentation क्लास को इंस्टेंशिएट करें जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) को प्रतिनिधित्व करता है।
$presentation = new Presentation("presentation.pptx");
try {
    // प्रस्तुति को TIFF के रूप में सहेजें।
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **प्रेजेंटेशन को ब्लैक‑एंड‑व्हाइट TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) क्लास में [setBwConversionMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#setBwConversionMode) मेथड आपको रंगीन स्लाइड या इमेज को ब्लैक‑एंड‑व्हाइट TIFF में बदलने के लिए उपयोग किए जाने वाले एल्गोरिद्म को निर्दिष्ट करने की अनुमति देता है। ध्यान रखें कि यह सेटिंग केवल तभी लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#getCompressionType) मेथड `CCITT4` या `CCITT3` पर सेट हो।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल में निम्नलिखित स्लाइड है:

![एक प्रेजेंटेशन स्लाइड](slide_black_and_white.png)

यह कोड दिखाता है कि रंगीन स्लाइड को ब्लैक‑एंड‑व्हाइट TIFF में कैसे बदलें:

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

![ब्लैक‑एंड‑व्हाइट TIFF](TIFF_black_and_white.png)

## **कस्टम साइज के साथ प्रेजेंटेशन को TIFF में बदलें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, [setImageSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#getImageSize) मेथड आपको परिणामस्वरूप इमेज का आकार निर्धारित करने की सुविधा देता है।

यह कोड दिखाता है कि PowerPoint प्रेजेंटेशन को कस्टम साइज वाले TIFF इमेज में कैसे बदलें:

```php
// Presentation क्लास को इंस्टेंशिएट करें जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // संपीड़न प्रकार निर्धारित करें।
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    संपीड़न प्रकार:
        Default - डिफ़ॉल्ट संपीड़न योजना (LZW) निर्दिष्ट करता है।
        None - कोई संपीड़न नहीं निर्दिष्ट करता है।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई संपीड़न प्रकार पर निर्भर करती है और इसे मैन्युअली सेट नहीं किया जा सकता।

    // इमेज DPI निर्धारित करें।
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // इमेज आकार निर्धारित करें।
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

## **कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ प्रेजेंटेशन को TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) क्लास के [setPixelFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#getPixelFormat) मेथड का उपयोग करके आप परिणामस्वरूप TIFF इमेज के लिए अपना पसंदीदा पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह कोड दिखाता है कि PowerPoint प्रेजेंटेशन को कस्टम पिक्सेल फ़ॉर्मेट वाले TIFF इमेज में कैसे बदलें:

```php
// Presentation क्लास को इंस्टेंशिएट करें जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat में निम्न मान होते हैं (दस्तावेज़ीकरण में जैसा बताया गया है):
        Format1bppIndexed - 1 बिट प्रति पिक्सेल, इंडेक्स्ड.
        Format4bppIndexed - 4 बिट प्रति पिक्सेल, इंडेक्स्ड.
        Format8bppIndexed - 8 बिट प्रति पिक्सेल, इंडेक्स्ड.
        Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB.
        Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB.
    */

    // निर्दिष्ट छवि आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose के **मुफ़्त** PowerPoint‑से‑पोस्टर परिवर्तक को देखें: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरे PowerPoint प्रेजेंटेशन के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रेजेंटेशन से व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेज में बदलने की सुविधा देता है।

**प्रेजेंटेशन को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है क्या?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रेजेंटेशन को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या स्लाइड्स को TIFF में बदलते समय PowerPoint एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित रहते हैं?**

नहीं, TIFF एक स्थैतिक इमेज फ़ॉर्मेट है। इसलिए एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं रहते; केवल स्लाइडों के स्थिर स्नैपशॉट निर्यात किए जाते हैं।