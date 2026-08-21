---
title: .NET में PowerPoint प्रेजेंटेशन्स को TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint को परिवर्तित करें
- OpenDocument को परिवर्तित करें
- प्रेजेंटेशन को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- PowerPoint से TIFF
- प्रेजेंटेशन से TIFF
- स्लाइड से TIFF
- PPT को TIFF में बदलें
- PPTX को TIFF में बदलें
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint (PPT, PPTX) प्रेजेंटेशन्स को उच्च गुणवत्ता वाली TIFF छवियों में आसानी से बदलना सीखें। C# कोड उदाहरण।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलैस रास्टर इमेज फॉर्मेट है जो अपनी असाधारण गुणवत्ता और ग्राफिक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र और डेस्कटॉप प्रकाशक अक्सर TIFF का चयन लेयर, रंग की शुद्धता और अपनी छवियों की मूल सेटिंग्स को बनाए रखने के लिए करते हैं।

Aspose.Slides का उपयोग करके, आप आसानी से अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च-गुणवत्ता वाली TIFF छवियों में परिवर्तित कर सकते हैं, जिससे आपकी प्रस्तुतियों में अधिकतम दृश्य सटीकता बनी रहती है। 

## **प्रेजेंटेशन को TIFF में परिवर्तित करें**

आप [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास द्वारा प्रदान किए गए [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड का उपयोग करके, पूरी PowerPoint प्रेजेंटेशन को जल्दी से TIFF में परिवर्तित कर सकते हैं। परिणामस्वरूप TIFF छवियां डिफ़ॉल्ट स्लाइड आकार के अनुरूप होंगी।

यह C# कोड दिखाता है कि PowerPoint प्रेजेंटेशन को TIFF में कैसे परिवर्तित करें:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का उदाहरण बनाते हैं जो एक प्रेजेंटेशन फाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // प्रेजेंटेशन को TIFF के रूप में सहेजें।
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **प्रेजेंटेशन को ब्लैक-एंड-व्हाइट TIFF में परिवर्तित करें**

क्लास [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/) में स्थित प्रॉपर्टी [BwConversionMode](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/bwconversionmode/) आपको रंगीन स्लाइड या छवि को ब्लैक-एंड-व्हाइट TIFF में परिवर्तित करने के लिए उपयोग किए जाने वाले एल्गोरिद्म को निर्दिष्ट करने की अनुमति देती है। ध्यान दें कि यह सेटिंग केवल तब लागू होती है जब प्रॉपर्टी [CompressionType](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/compressiontype/) को `CCITT4` या `CCITT3` पर सेट किया गया हो।

{{% alert color="info" title="नोट" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/bwconversionmode/) एक एक्सपोर्ट-लेवल सेटिंग है जो पूर्ण TIFF छवि के लिए पिक्सेल-कन्वर्ज़न एल्गोरिद्म चुनती है। यह निर्धारित करने के लिए कि जब ब्लैक-एंड-व्हाइट डिस्प्ले मोड सक्रिय हो तो व्यक्तिगत शेप कैसे दिखेगा, आप [IShape.BlackWhiteMode](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/blackwhitemode/) का उपयोग करें। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/net/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास एक "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रेजेंटेशन स्लाइड](slide_black_and_white.png)

यह C# कोड दर्शाता है कि रंगीन स्लाइड को ब्लैक-एंड-व्हाइट TIFF में कैसे परिवर्तित किया जाए:

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

## **प्रेजेंटेशन को कस्टम आकार के साथ TIFF में परिवर्तित करें**

यदि आपको विशिष्ट आयामों वाली TIFF छवि चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/) में उपलब्ध प्रॉपर्टीज़ का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, प्रॉपर्टी [ImageSize](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/imagesize/) आपको परिणामस्वरूप छवि का आकार निर्धारित करने की अनुमति देती है।

यह C# कोड दिखाता है कि PowerPoint प्रेजेंटेशन को कस्टम आकार वाली TIFF छवियों में कैसे परिवर्तित किया जाए:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का उदाहरण बनाते हैं जो एक प्रेजेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // संपीड़न प्रकार सेट करें।
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
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

    // छवि DPI सेट करें।
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // छवि आकार सेट करें।
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // निर्दिष्ट आकार के साथ प्रेजेंटेशन को TIFF के रूप में सहेजें।
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **प्रेजेंटेशन को कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions) क्लास की प्रॉपर्टी [PixelFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/pixelformat/) का उपयोग करके, आप परिणामस्वरूप TIFF छवि के लिए अपना इच्छित पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह C# कोड दर्शाता है कि PowerPoint प्रेजेंटेशन को कस्टम पिक्सेल फ़ॉर्मेट वाली TIFF छवि में कैसे परिवर्तित किया जाए:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का उदाहरण बनाते हैं जो एक प्रेजेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में उल्लेखित अनुसार):
        Format1bppIndexed - 1 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format4bppIndexed - 4 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format8bppIndexed - 8 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB।
        Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB।
    */

    // निर्दिष्ट छवि आकार के साथ प्रेजेंटेशन को TIFF के रूप में सहेजें।
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="सलाह" color="info" %}}
Aspose के [निःशुल्क PowerPoint से पोस्टर कनवर्टर](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरे PowerPoint प्रेज़ेंटेशन के बजाय व्यक्तिगत स्लाइड को TIFF में परिवर्तित कर सकता हूँ?**

हां। Aspose.Slides आपको PowerPoint और OpenDocument प्रेजेंटेशन से व्यक्तिगत स्लाइड्स को अलग-अलग TIFF छवियों में परिवर्तित करने की सुविधा देता है।

**क्या प्रेजेंटेशन को TIFF में परिवर्तित करते समय स्लाइडों की संख्या में कोई सीमा है?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रेजेंटेशन को TIFF फ़ॉर्मेट में परिवर्तित कर सकते हैं।

**क्या स्लाइडों को TIFF में परिवर्तित करने पर PowerPoint एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित रहते हैं?**

नहीं, TIFF एक स्थिर छवि फ़ॉर्मेट है। इसलिए, एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं रहते; केवल स्लाइडों के स्थिर स्नैपशॉट निर्यात किए जाते हैं।