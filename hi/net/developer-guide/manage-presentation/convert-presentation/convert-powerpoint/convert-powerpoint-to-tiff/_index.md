---
title: PowerPoint प्रस्तुतियों को .NET में TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint रूपांतरित करें
- OpenDocument रूपांतरित करें
- प्रेज़ेंटेशन रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
- PowerPoint से TIFF
- प्रेज़ेंटेशन से TIFF
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
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च-गुणवत्ता वाले TIFF चित्रों में आसानी से बदलना सीखें। C# कोड उदाहरण।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलैस रास्टर इमेज फ़ॉर्मेट है, जो अपनी उत्कृष्ट गुणवत्ता और ग्राफ़िक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिज़ाइनर, फ़ोटोग्राफ़र और डेस्कटॉप प्रकाशक अक्सर अपनी छवियों में लेयर, रंग की सटीकता और मूल सेटिंग्स को बनाए रखने के लिए TIFF चुनते हैं।

Aspose.Slides का उपयोग करके आप अपने PowerPoint स्लाइड (PPT, PPTX) और OpenDocument स्लाइड (ODP) को सीधे उच्च‑गुणवत्ता वाले TIFF इमेज में आसानी से बदल सकते हैं, जिससे आपकी प्रस्तुतियाँ अधिकतम दृश्य सटीकता बनाए रखें।

## **प्रेज़ेंटेशन को TIFF में बदलें**

आप [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास द्वारा प्रदान किए गए [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड का उपयोग करके पूरी PowerPoint प्रेज़ेंटेशन को जल्दी से TIFF में रूपांतरित कर सकते हैं। परिणामी TIFF इमेज डिफ़ॉल्ट स्लाइड आकार के अनुरूप होंगी।

यह C# कोड दिखाता है कि PowerPoint प्रेज़ेंटेशन को TIFF में कैसे रूपांतरित किया जाता है:

```cs
// एक Presentation क्लास का उदाहरण बनाइए जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **प्रेज़ेंटेशन को काली-श्वेत TIFF में बदलें**

क्लास [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/) में स्थित प्रॉपर्टी [BwConversionMode](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/bwconversionmode/) आपको यह निर्धारित करने की अनुमति देती है कि रंगीन स्लाइड या इमेज को काली-श्वेत TIFF में परिवर्तित करते समय कौन-सा एल्गोरिद्म उपयोग किया जाना चाहिए। ध्यान दें कि यह सेटिंग केवल तब लागू होती है जब प्रॉपर्टी [CompressionType](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/compressiontype/) को `CCITT4` या `CCITT3` पर सेट किया गया हो।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह C# कोड दिखाता है कि रंगीन स्लाइड को काली-श्वेत TIFF में कैसे बदलें:

```cs
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

![काली-श्वेत TIFF](TIFF_black_and_white.png)

## **कस्टम आकार के साथ प्रेज़ेंटेशन को TIFF में बदलें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/) में उपलब्ध प्रॉपर्टीज़ का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, प्रॉपर्टी [ImageSize](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/imagesize/) आपको परिणामी इमेज का आकार निर्धारित करने की सुविधा देती है।

यह C# कोड दिखाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम आकार वाले TIFF इमेज में कैसे रूपांतरित किया जाता है:

```cs
// एक Presentation क्लास का उदाहरण बनाइए जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // संपीडन प्रकार सेट करें।
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    संपीडन प्रकार:
        Default - डिफ़ॉल्ट संपीडन योजना (LZW) को निर्दिष्ट करता है।
        None - कोई संपीडन नहीं दर्शाता है।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई संपीडन प्रकार पर निर्भर करती है और मैन्युअली सेट नहीं की जा सकती।

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

## **कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ प्रेज़ेंटेशन को TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions) क्लास की [PixelFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/pixelformat/) प्रॉपर्टी का उपयोग करके आप परिणामी TIFF इमेज के लिए अपनी पसंदीदा पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह C# कोड दिखाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम पिक्सेल फ़ॉर्मेट वाले TIFF इमेज में कैसे रूपांतरित किया जाता है:

```cs
// एक Presentation क्लास का उदाहरण बनाइए जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (डॉक्यूमेंटेशन में बताए अनुसार):
        Format1bppIndexed - 1 बिट प्रति पिक्सेल, इंडेक्स्ड.
        Format4bppIndexed - 4 बिट प्रति पिक्सेल, इंडेक्स्ड.
        Format8bppIndexed - 8 बिट प्रति पिक्सेल, इंडेक्स्ड.
        Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB.
        Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB.
    */

    // प्रस्तुति को निर्दिष्ट छवि आकार के साथ TIFF के रूप में सहेजें।
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="primary" %}}
Aspose के [मुफ़्त PowerPoint से पोस्टर कनवर्टर](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरे PowerPoint प्रेज़ेंटेशन के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रेज़ेंटेशनों से व्यक्तिगत स्लाइड को अलग‑अलग TIFF इमेज में बदलने की सुविधा देता है।

**क्या प्रेज़ेंटेशन को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रेज़ेंटेशन को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या PowerPoint ऐनिमेशन और ट्रांज़िशन इफ़ेक्ट्स स्लाइडों को TIFF में बदलते समय संरक्षित रहते हैं?**

नहीं, TIFF एक स्थिर इमेज फ़ॉर्मेट है। इसलिए, ऐनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं होते; केवल स्लाइडों के स्थिर स्नैपशॉट निर्यात होते हैं।