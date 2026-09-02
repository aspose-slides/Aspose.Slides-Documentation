---
title: .NET में PowerPoint प्रस्तुतियों को TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint परिवर्तित करें
- OpenDocument परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से TIFF
- प्रेजेंटेशन से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च-गुणवत्ता वाले TIFF इमेजेज़ में आसानी से कैसे बदलें, सीखें। C# कोड उदाहरण।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फ़ॉर्मेट है, जो अपनी विशिष्ट गुणवत्ता और ग्राफिक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र, और डेस्कटॉप प्रकाशक अक्सर TIFF चुनते हैं ताकि वे अपनी छवियों में लेयर्स, रंग की सटीकता, और मूल सेटिंग्स बनाए रख सकें।

Aspose.Slides का उपयोग करके, आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च-गुणवत्ता वाले TIFF इमेजेज़ में आसानी से कनवर्ट कर सकते हैं, जिससे आपकी प्रस्तुतियों में अधिकतम दृश्य सत्यता बनी रहती है।

## **एक प्रस्तुति को TIFF में बदलें**

Using the [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) method provided by the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the default slide size.

यह C# कोड दर्शाता है कि कैसे PowerPoint प्रस्तुति को TIFF में परिवर्तित किया जाता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **एक प्रस्तुति को ब्लैक-एंड-व्हाइट TIFF में बदलें**

The property [BwConversionMode](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/bwconversionmode/) in the [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/) class allows you to specify the algorithm used when converting a colored slide or image to a black-and-white TIFF. Note that this setting applies only when the [CompressionType](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/compressiontype/) property is set to `CCITT4` or `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/bwconversionmode/) एक निर्यात-स्तर की सेटिंग है जो पूरे TIFF इमेज के लिए पिक्सेल-कन्वर्ज़न एल्गोरिद्म चुनती है। जब ब्लैक-एंड-व्हाइट डिस्प्ले मोड सक्रिय हो, तो किसी व्यक्तिगत shape को कैसे प्रदर्शित किया जाना चाहिए, इसे परिभाषित करने के लिए आप [IShape.BlackWhiteMode](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/blackwhitemode/) का उपयोग करें। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/slides/hi/net/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास एक "sample.pptx" फ़ाइल है जिसमें निम्न स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह C# कोड दर्शाता है कि कैसे रंगीन स्लाइड को ब्लैक-एंड-व्हाइट TIFF में परिवर्तित किया जाता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

परिणाम:

![ब्लैक-एंड-व्हाइट TIFF](TIFF_black_and_white.png)

## **एक प्रस्तुति को कस्टम आकार के साथ TIFF में बदलें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/) में उपलब्ध प्रॉपर्टीज़ का उपयोग करके अपनी वांछित मान सेट कर सकते हैं। उदाहरण के लिए, [ImageSize](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/imagesize/) प्रॉपर्टी आपको परिणामी इमेज का आकार निर्धारित करने की अनुमति देती है।

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का उदाहरण बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // संपीड़न प्रकार निर्धारित करें।
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    संपीड़न प्रकार:
        Default - डिफ़ॉल्ट संपीड़न योजना (LZW) को निर्दिष्ट करता है।
        None - कोई संपीड़न नहीं होने को निर्दिष्ट करता है।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // डेप्थ संपीड़न प्रकार पर निर्भर करती है और इसे मैन्युअली सेट नहीं किया जा सकता।

    // छवि DPI सेट करें।
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // छवि आकार सेट करें।
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **एक प्रस्तुति को कस्टम इमेज पिक्सेल फॉर्मेट के साथ TIFF में बदलें**

[PixelFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/pixelformat/) प्रॉपर्टी को [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions) क्लास से उपयोग करके, आप परिणामी TIFF इमेज के लिए अपना पसंदीदा पिक्सेल फॉर्मेट निर्दिष्ट कर सकते हैं।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का उदाहरण बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (प्रलेखन में उल्लिखित अनुसार):
        Format1bppIndexed - प्रति पिक्सेल 1 बिट, अनुक्रमित।
        Format4bppIndexed - प्रति पिक्सेल 4 बिट, अनुक्रमित।
        Format8bppIndexed - प्रति पिक्सेल 8 बिट, अनुक्रमित।
        Format24bppRgb    - प्रति पिक्सेल 24 बिट, RGB।
        Format32bppArgb   - प्रति पिक्सेल 32 बिट, ARGB।
    */

    // निर्दिष्ट छवि आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
Aspose के [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी PowerPoint प्रस्तुति के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों की व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेजेज़ में बदलने की अनुमति देता है।

**क्या प्रस्तुति को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रस्तुतियों को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या PowerPoint एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स स्लाइड्स को TIFF में बदलने पर संरक्षित रहते हैं?**

नहीं, TIFF एक स्थिर छवि फ़ॉर्मेट है। इसलिए, एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं रहते; केवल स्लाइड्स के स्थिर स्नैपशॉट निर्यात किए जाते हैं।