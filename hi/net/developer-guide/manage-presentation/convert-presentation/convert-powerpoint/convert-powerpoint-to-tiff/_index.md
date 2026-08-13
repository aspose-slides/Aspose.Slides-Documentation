---
title: .NET में PowerPoint प्रस्तुतियों को TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/net/convert-powerpoint-to-tiff/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च गुणवत्ता वाले TIFF चित्रों में आसानी से कैसे बदलें, सीखें। C# कोड उदाहरण।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लोसलैस रास्टर इमेज फ़ॉर्मेट है जो अपनी असाधारण गुणवत्ता और ग्राफ़िक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र और डेस्कटॉप पब्लिशर अक्सर TIFF को लेयर्स, रंग सटीकता और चित्रों में मूल सेटिंग्स बनाए रखने के लिए चुनते हैं।

Aspose.Slides का उपयोग करके, आप आसानी से अपनी PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च‑गुणवत्ता वाले TIFF इमेज में बदल सकते हैं, यह सुनिश्चित करते हुए कि आपके प्रस्तुतियों में अधिकतम दृश्य सच्चाई बनी रहे।

## **प्रस्तुति को TIFF में बदलें**

[Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड का उपयोग करके, जिसे [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास प्रदान करता है, आप जल्दी से पूरी PowerPoint प्रस्तुति को TIFF में बदल सकते हैं। परिणामी TIFF छवियां डिफ़ॉल्ट स्लाइड आकार के अनुरूप होंगी।

यह C# कोड दर्शाता है कि कैसे एक PowerPoint प्रस्तुति को TIFF में बदला जाए:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का एक उदाहरण बनाएं जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **प्रस्तुति को काली‑और‑सफ़ेद TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/) क्लास में प्रॉपर्टी [BwConversionMode](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/bwconversionmode/) आपको यह निर्दिष्ट करने देती है कि रंगीन स्लाइड या इमेज को काली‑और‑सफ़ेद TIFF में बदलते समय कौन सा एल्गोरिद्म उपयोग किया जाए। ध्यान दें कि यह सेटिंग केवल तब लागू होती है जब [CompressionType](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/compressiontype/) प्रॉपर्टी को `CCITT4` या `CCITT3` पर सेट किया गया हो।

मान लीजिए हमारे पास “sample.pptx” फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह C# कोड दर्शाता है कि कैसे रंगीन स्लाइड को काली‑और‑सफ़ेद TIFF में बदला जाए:

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

![काली-और-सफ़ेद TIFF](TIFF_black_and_white.png)

## **कस्टम आकार के साथ प्रस्तुति को TIFF में बदलें**

यदि आपको विशिष्ट आयामों के साथ TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/) में उपलब्ध प्रॉपर्टीज़ का उपयोग करके अपने इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, [ImageSize](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/imagesize/) प्रॉपर्टी आपको परिणामी इमेज का आकार निर्धारित करने देती है।

यह C# कोड दर्शाता है कि कैसे एक PowerPoint प्रस्तुति को कस्टम आकार की TIFF छवियों में बदला जाए:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का एक उदाहरण बनाएं जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // संपीड़न प्रकार सेट करें।
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    संपीड़न प्रकार:
        Default - डिफ़ॉल्ट संपीड़न स्कीम (LZW) निर्धारित करता है।
        None - कोई संपीड़न नहीं निर्धारित करता।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई संपीड़न प्रकार पर निर्भर करती है और इसे मैन्युअल रूप से सेट नहीं किया जा सकता।

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

## **कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ प्रस्तुति को TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions) क्लास से [PixelFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/pixelformat/) प्रॉपर्टी का उपयोग करके, आप परिणामी TIFF इमेज के लिए अपनी पसंदीदा पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह C# कोड दर्शाता है कि कैसे एक PowerPoint प्रस्तुति को कस्टम पिक्सेल फ़ॉर्मेट वाली TIFF इमेज में बदला जाए:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का एक उदाहरण बनाएं जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में बताया गया है):
        Format1bppIndexed - 1 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format4bppIndexed - 4 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format8bppIndexed - 8 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB।
        Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB।
    */

    // निर्दिष्ट छवि आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
Aspose के मुफ्त PowerPoint से पोस्टर कन्वर्टर को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं पूरी PowerPoint प्रस्तुति के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?

हां। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों से व्यक्तिगत स्लाइड को अलग‑अलग TIFF इमेज में बदलने की अनुमति देता है।

### प्रस्तुति को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है क्या?

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रस्तुतियों को TIFF फ़ॉर्मेट में बदल सकते हैं।

### क्या PowerPoint एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स स्लाइड को TIFF में बदलते समय संरक्षित रहते हैं?

नहीं, TIFF एक स्थिर इमेज फ़ॉर्मेट है। इसलिए एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं होते; केवल स्लाइड्स के स्थिर स्नैपशॉट निर्यात होते हैं।