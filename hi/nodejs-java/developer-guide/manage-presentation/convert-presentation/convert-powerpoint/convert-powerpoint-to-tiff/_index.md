---
title: PowerPoint प्रस्तुतियों को JavaScript में TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/nodejs-java/convert-powerpoint-to-tiff/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च-गुणवत्ता वाले TIFF चित्रों में आसानी से बदलना सीखें, साथ में JavaScript कोड उदाहरण।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फॉर्मेट है, जो अपनी शानदार गुणवत्ता और ग्राफिक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र और डेस्कटॉप प्रकाशक अक्सर TIFF का चयन लेयर, रंग सटीकता और उनकी छवियों में मूल सेटिंग्स को बनाए रखने के लिए करते हैं।

Aspose.Slides का उपयोग करके, आप आसानी से अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च-गुणवत्ता वाले TIFF इमेजेज़ में परिवर्तित कर सकते हैं, जिससे आपकी प्रस्तुतियाँ अधिकतम दृश्य सटीकता बनाए रखें।

## **प्रेजेंटेशन को TIFF में परिवर्तित करें**

Using the [सहेजें](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) method provided by the [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the default slide size.

यह JavaScript कोड दिखाता है कि कैसे PowerPoint प्रेजेंटेशन को TIFF में परिवर्तित किया जाए:

```js
// प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **प्रेजेंटेशन को श्वेत-श्याम TIFF में परिवर्तित करें**

The method [setBwConversionMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) in the [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) class allows you to specify the algorithm used when converting a colored slide or image to a black-and-white TIFF. Note that this setting applies only when the [setCompressionType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) method is set to `CCITT4` or `CCITT3`.

मान लीजिए हमारे पास एक "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह JavaScript कोड दिखाता है कि कैसे रंगीन स्लाइड को श्वेत-श्याम TIFF में परिवर्तित किया जाए:

```js
let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

परिणाम:

![श्वेत-श्याम TIFF](TIFF_black_and_white.png)

## **प्रेजेंटेशन को कस्टम आकार के साथ TIFF में परिवर्तित करें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, [setImageSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setImageSize) मेथड आपको परिणामी इमेज का आकार परिभाषित करने की अनुमति देता है।

यह JavaScript कोड दिखाता है कि कैसे PowerPoint प्रेजेंटेशन को कस्टम आकार के साथ TIFF इमेजेज़ में परिवर्तित किया जाए:

```js
// प्रेजेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // संपीड़न प्रकार सेट करें।
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    संपीड़न प्रकार:
        Default - डिफ़ॉल्ट संपीड़न योजना (LZW) को निर्दिष्ट करता है।
        None - कोई संपीड़न नहीं निर्दिष्ट करता।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई संपीड़न प्रकार पर निर्भर करती है और मैन्युअल रूप से सेट नहीं की जा सकती।

    // इमेज DPI सेट करें।
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // इमेज आकार सेट करें।
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **प्रेजेंटेशन को कस्टम इमेज पिक्सेल फॉर्मेट के साथ TIFF में परिवर्तित करें**

Using the [setPixelFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) method from the [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) class, you can specify your preferred pixel format for the resulting TIFF image.

यह JavaScript कोड दिखाता है कि कैसे PowerPoint प्रेजेंटेशन को कस्टम पिक्सेल फॉर्मेट वाले TIFF इमेज में परिवर्तित किया जाए:

```js
// प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में निर्दिष्ट अनुसार):
        Format1bppIndexed - 1 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format4bppIndexed - 4 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format8bppIndexed - 8 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB।
        Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB।
    */

    /// निर्दिष्ट इमेज आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose के [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी PowerPoint प्रस्तुति के बजाय व्यक्तिगत स्लाइड को TIFF में परिवर्तित कर सकता हूँ?**

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों से व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेजेज़ में परिवर्तित करने की सुविधा देता है।

**क्या प्रेजेंटेशन को TIFF में परिवर्तित करने पर स्लाइडों की संख्या पर कोई सीमा है?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रस्तुतियों को TIFF फॉर्मेट में परिवर्तित कर सकते हैं।

**क्या स्लाइडों को TIFF में परिवर्तित करने पर PowerPoint एनीमेशन और ट्रांज़िशन इफेक्ट्स संरक्षित रहते हैं?**

नहीं, TIFF एक स्थैतिक इमेज फॉर्मेट है। इसलिए एनीमेशन और ट्रांज़िशन इफेक्ट्स संरक्षित नहीं होते; केवल स्लाइडों के स्थैतिक स्नैपशॉट निर्यात होते हैं।