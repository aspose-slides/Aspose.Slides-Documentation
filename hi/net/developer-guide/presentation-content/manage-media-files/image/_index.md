---
title: ".NET में प्रस्तुतियों में चित्र प्रबंधन को अनुकूलित करें"
linktitle: "चित्र प्रबंधन"
type: docs
weight: 10
url: /hi/net/image/
keywords:
- "चित्र जोड़ें"
- "फ़ोटो जोड़ें"
- "बिटमैप जोड़ें"
- "चित्र बदलें"
- "फ़ोटो बदलें"
- "वेब से"
- "पृष्ठभूमि"
- "PNG जोड़ें"
- "JPG जोड़ें"
- "SVG जोड़ें"
- "बाहरी SVG संसाधन"
- "SVG रिजॉल्वर"
- "लिंक्ड SVG चित्र"
- "SVG फ़ॉन्ट"
- "EMF जोड़ें"
- "WMF जोड़ें"
- "TIFF जोड़ें"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument में चित्र प्रबंधन को सरल बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियां प्रस्तुतियों को अधिक आकर्षक और दृश्य रूप से आकर्षक बनाती हैं। Microsoft PowerPoint में, आप फ़ाइलों, इंटरनेट या अन्य स्रोतों से स्लाइड पर चित्र सम्मिलित कर सकते हैं। इसी प्रकार, Aspose.Slides आपको कई तरीकों से प्रस्तुति स्लाइड्स में छवियां जोड़ने की अनुमति देता है।

{{% alert  title="सलाह" color="primary" %}} 
Aspose मुफ्त कनवर्टर्स प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो आपको छवियों से शीघ्रता से प्रस्तुतियां बनाने की अनुमति देते हैं। 
{{% /alert %}} 

{{% alert title="सूचना" color="info" %}}
यदि आप छवि को चित्र फ्रेम के रूप में जोड़ना चाहते हैं—विशेष रूप से यदि आप उसे आकार बदलने, प्रभाव लागू करने, या अन्य मानक फ़ॉर्मेटिंग विकल्पों का उपयोग करने की योजना बना रहे हैं—देखें [Picture Frame](/slides/hi/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="ध्यान" color="warning" %}}
आप एक स्वरूप से दूसरी में छवियों को परिवर्तित कर सकते हैं। निम्नलिखित पृष्ठ देखें: convert [image to JPG](https://products.aspose.com/slides/hi/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hi/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hi/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hi/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hi/net/conversion/png-to-svg/), और [SVG to PNG](https://products.aspose.com/slides/hi/net/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides JPEG, PNG, BMP, GIF आदि लोकप्रिय स्वरूपों में छवियों का समर्थन करता है। 

## **स्थानीय रूप से संग्रहीत छवियों को स्लाइड्स में जोड़ें**

आप अपने कंप्यूटर पर संग्रहीत एक या अधिक छवियों को प्रस्तुति स्लाइड में जोड़ सकते हैं। निम्नलिखित C# नमूना कोड दिखाता है कि स्लाइड में छवि कैसे जोड़ें:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **वेब से छवियों को स्लाइड्स में जोड़ें**

यदि आप स्लाइड में जोड़ने वाली छवि आपके कंप्यूटर पर संग्रहीत नहीं है, तो आप उसे सीधे वेब से जोड़ सकते हैं। 

निम्नलिखित C# नमूना कोड दिखाता है कि वेब से छवि को स्लाइड में कैसे जोड़ें:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **स्लाइड मास्टर में छवियां जोड़ें**

स्लाइड मास्टर उन स्लाइड्स के लिए थीम और लेआउट जैसी जानकारी को संग्रहीत और नियंत्रित करता है जो इसका उपयोग करती हैं। जब आप स्लाइड मास्टर में छवि जोड़ते हैं, तो वह छवि उस मास्टर पर आधारित प्रत्येक स्लाइड पर दिखाई देती है। 

निम्नलिखित C# नमूना कोड दिखाता है कि स्लाइड मास्टर में छवि कैसे जोड़ें:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **स्लाइड पृष्ठभूमि के रूप में छवियां जोड़ें**

आप एक या अधिक स्लाइड्स की पृष्ठभूमि के रूप में चित्र का उपयोग कर सकते हैं। विवरण के लिए देखें *[Setting Images as Backgrounds for Slides](/slides/hi/net/presentation-background/#setting-images-as-background-for-slides)*।

## **प्रस्तुतियों में SVG जोड़ें**

SVG सामग्री को प्रस्तुति में [SvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/svgimage/) क्लास का उपयोग करके जोड़ा जा सकता है। परिणामी [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) ऑब्जेक्ट को फिर प्रस्तुति इमेज कलेक्शन में जोड़ा जा सकता है और इसे एक पिक्चर फ्रेम बनाने के लिए उपयोग किया जा सकता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **बाहरी संसाधनों के साथ SVG सामग्री आयात करें**

डिज़ाइन टूल्स, डायग्राम एडिटर्स, आइकन सिस्टम, और वेब पाइपलाइन से निर्यात की गई SVG फ़ाइलें उन संसाधनों को संदर्भित कर सकती हैं जो SVG दस्तावेज़ के बाहर संग्रहीत होते हैं। उदाहरण के लिए, एक SVG में `images/photo.png` जैसी छवि लिंक, CSS `url(...)` मान, या फ़ॉन्ट URL हो सकता है। 

ऐसी SVG सामग्री आयात करने के लिए, एक [IExternalResourceResolver](https://reference.aspose.com/slides/hi/net/aspose.slides.import/iexternalresourceresolver/) कार्यान्वयन बनाएं और इसे बेस URI के साथ उपयुक्त `SvgImage` कंस्ट्रक्टर में पास करें। बेस URI SVG दस्तावेज़ के स्थान की पहचान करता है और सापेक्ष लिंक को हल करने के लिए उपयोग किया जाता है। 

[ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) इंटरफ़ेस आयातित SVG के बारे में जानकारी तक पहुँच प्रदान करता है:
- `SvgContent` SVG मार्कअप को स्ट्रिंग के रूप में लौटाता है।
- `SvgData` SVG सामग्री को बाइट एरे के रूप में लौटाता है।
- `BaseUri` सापेक्ष लिंक के लिए प्रयुक्त बेस URI लौटाता है।
- `ExternalResourceResolver` SVG इमेज को असाइन किया गया रिजॉल्वर लौटाता है।

### **बाहरी संसाधन रेजॉल्वर लागू करें**

रेजॉल्वर में दो मेथड होते हैं:
- [ResolveUri](https://reference.aspose.com/slides/hi/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) बेस URI और सापेक्ष संसाधन लिंक को मिलाकर एक पूर्ण URI लौटाता है। जब लिंक हल नहीं हो सकें या अनुमति न हो तो `null` लौटाएँ।
- [GetEntity](https://reference.aspose.com/slides/hi/net/aspose.slides.import/iexternalresourceresolver/getentity/) पूर्ण संसाधन URI के लिए एक रीडेबल स्ट्रीम लौटाता है। जब संसाधन अनुपलब्ध, अवरुद्ध या नहीं मिला हो तो `null` लौटाएँ। आवश्यक होने पर एक फॉलबैक स्ट्रीम भी लौटाई जा सकती है। 

निम्नलिखित रेजॉल्वर केवल अनुमत स्थानीय डायरेक्टरी से लिंक्ड संसाधनों को लोड करता है। नेटवर्क संसाधन और अनुमत डायरेक्टरी के बाहर के पाथ ब्लॉक किए जाते हैं। अनहैंडल्ड इमेज लिंक के लिए वैकल्पिक फॉलबैक छवि लौटाई जाती है।

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // यह रिजॉल्वर जानबूझकर केवल स्थानीय फ़ाइलों की अनुमति देता है।
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // केवल चित्र संसाधनों के लिए फॉलबैक का उपयोग करें। छवि स्ट्रीम लौटाना
        // एक गायब फ़ॉन्ट या स्टाइलशीट के लिए वैध नहीं होगा।
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **SVG आयात के दौरान लिंक्ड संसाधनों को हल करें**

मान लें कि `assets/diagram.svg` में निम्नलिखित सापेक्ष संदर्भ है:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

निम्नलिखित C# उदाहरण SVG फ़ाइल URI को बेस URI के रूप में पास करता है और एक कस्टम रिजॉल्वर प्रदान करता है। रिजॉल्वर सापेक्ष इमेज लिंक को पूर्ण URI में बदलता है और लिंक्ड संसाधन वाली स्ट्रीम लौटाता है जबकि Aspose.Slides SVG को प्रोसेस कर रहा है।

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// बेस URI SVG दस्तावेज़ के स्थान का प्रतिनिधित्व करता है।
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage स्रोत सामग्री, बाइनरी डेटा, बेस URI, और रिजॉल्वर को उजागर करता है।
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

`SvgImage` क्लास ऐसे ओवरलोड भी प्रदान करता है जो SVG डेटा को बाइट एरे या स्ट्रीम के रूप में, साथ ही एक बाहरी संसाधन रिजॉल्वर और बेस URI को स्वीकार करता है।

{{% alert title="महत्वपूर्ण" color="warning" %}}
संसाधन रिजॉल्वर SVG प्रोसेस और रेंडर करते समय बाहरी संसाधनों को उपलब्ध कराता है। यह मूल SVG मार्कअप को संशोधित नहीं करता और स्वचालित रूप से हल किए गए संसाधनों को उसमें एम्बेड नहीं करता। 

जब `ISvgImage` को प्रस्तुति इमेज कलेक्शन में जोड़ा जाता है, तो PPTX फ़ाइल मूल SVG प्रतिनिधित्व और एक रास्टर फॉलबैक इमेज दोनों को रख सकती है। लिंक्ड संसाधन जेनरेटेड फॉलबैक इमेज में दिखाई दे सकता है जबकि `images/photo.png` जैसी सापेक्ष लिंक संग्रहित SVG में अपरिवर्तित रहती है। मूल बाहरी संसाधन अनुपलब्ध होने पर नेटिव SVG प्रतिनिधित्व रेंडर करने वाला एप्लिकेशन लिंक्ड कंटेंट को छोड़ सकता है। 
{{% /alert %}}

### **एक पोर्टेबल SVG चित्र बनाएं**

एक पोर्टेबल SVG चित्र बनाने के लिए जिससे बाहरी फ़ाइलों पर निर्भरता न रहे, `SvgImage` बनाने से पहले SVG को स्वयं-समाहित बनाएं। उदाहरण के लिए, लिंक्ड इमेज URL को `data:` URI में बदलें जिसमें इमेज डेटा शामिल हो:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

सभी आवश्यक संसाधनों को SVG सामग्री में एम्बेड करने के बाद, `SvgImage` बनाएं, इसे प्रस्तुति इमेज कलेक्शन में जोड़ें, और पिछले उदाहरण जैसा पिक्चर फ्रेम में सम्मिलित करें।

### **गायब या अवरुद्ध संसाधनों को संभालें**

जब संसाधन URI अमान्य, प्रतिबंधित, या हल नहीं किया जा सकता हो, तो `ResolveUri` से `null` लौटाएँ। जब संसाधन पढ़ा नहीं जा सकता हो तो `GetEntity` से `null` लौटाएँ। संभव हो तो Aspose.Slides उस संसाधन के बिना SVG प्रोसेस करना जारी रखता है। 

एक फॉलबैक स्ट्रीम गायब संसाधन के लिए लौटाई जा सकती है, लेकिन उसकी सामग्री अनुरोधित संसाधन प्रकार के साथ संगत होनी चाहिए। उदाहरण के लिए, केवल इमेज के लिए इमेज स्ट्रीम लौटाएँ, फ़ॉन्ट या स्टाइलशीट के लिए नहीं। 

{{% alert title="सुरक्षा" color="warning" %}}
अनविश्वसनीय SVG फ़ाइलों से मनमाने फ़ाइल पाथ या अनियंत्रित नेटवर्क URL को हल न करें। अनुमत स्कीम, डायरेक्टरी और होस्ट को सीमित रखें। नेटवर्क संसाधन के लिए कनेक्शन टाइमआउट, रिस्पॉन्स‑साइज़ लिमिट और कंटेंट वैलिडेशन लागू करें। 
{{% /alert %}}

## **SVG को आकारों के समूह में परिवर्तित करें**
Aspose.Slides SVG को आकारों के समूह में परिवर्तित कर सकता है, जैसे PowerPoint में समान कार्यक्षमता उपलब्ध है:

![PowerPoint Popup Menu](img_01_01.png)

यह कार्यक्षमता [AddGroupShape](https://reference.aspose.com/slides/hi/net/aspose.slides.ishapecollection/addgroupshape/methods/1) मेथड के एक ओवरलोड द्वारा प्रदान की जाती है, जो [IShapeCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection) इंटरफ़ेस का भाग है और पहला आर्गुमेंट के रूप में एक [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage) ऑब्जेक्ट लेता है। 

निम्नलिखित C# नमूना कोड दर्शाता है कि इस मेथड का उपयोग करके SVG फ़ाइल को आकारों के समूह में कैसे परिवर्तित किया जाए:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// स्रोत SVG फ़ाइल नाम
string svgFileName = "sample.svg";

// आउटपुट प्रस्तुति फ़ाइल नाम
string outPptxPath = "presentation.pptx";

// नई प्रस्तुति बनाएं
using (IPresentation presentation = new Presentation())
{
    // SVG फ़ाइल की सामग्री पढ़ें
    string svgContent = File.ReadAllText(svgFileName);

    // एक SvgImage ऑब्जेक्ट बनाएं
    ISvgImage svgImage = new SvgImage(svgContent);

    // स्लाइड आकार प्राप्त करें
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG छवि को आकारों के समूह में परिवर्तित करें और स्लाइड आकार के अनुसार स्केल करें
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // प्रस्तुति को PPTX प्रारूप में सहेजें
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **EMF के रूप में छवियां स्लाइड्स में जोड़ें**
Aspose.Slides for .NET आपको Aspose.Cells के साथ Excel वर्कशीट्स से EMF छवियां उत्पन्न करने और उन्हें प्रस्तुति स्लाइड्स में जोड़ने की अनुमति देता है। 

निम्नलिखित C# नमूना कोड इस कार्य को दर्शाता है:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // वर्कबुक को स्ट्रीम में सहेजें
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **छवि संग्रह में छवियों को बदलें**
Aspose.Slides आपको प्रस्तुति की इमेज कलेक्शन में संग्रहीत छवियों को बदलने की सुविधा देता है, जिसमें स्लाइड आकारों द्वारा प्रयुक्त छवियां भी शामिल हैं। यह अनुभाग संग्रह में छवियों को अपडेट करने के कई तरीकों को वर्णित करता है। आप कच्चे बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) इंस्टेंस, या संग्रह में पहले से मौजूद दूसरी छवि का उपयोग करके छवि बदल सकते हैं। 

नीचे दिए गए चरणों का पालन करें:
1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उपयोग करके छवियों वाली प्रस्तुति फ़ाइल लोड करें।
1. नई छवि को फ़ाइल से बाइट एरे में लोड करें।
1. बाइट एरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।
1. दूसरे तरीके में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और लक्ष्य छवि को उस ऑब्जेक्ट से बदलें।
1. तीसरे तरीके में, लक्ष्य छवि को प्रस्तुति की इमेज कलेक्शन में पहले से मौजूद छवि से बदलें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// एक Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
using Presentation presentation = new Presentation("sample.pptx");

// पहला तरीका।
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// दूसरा तरीका।
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// तीसरा तरीका।
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// प्रस्तुति को फ़ाइल में सहेजें।
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="सूचना" color="info" %}}
Aspose के मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कनवर्टर के साथ आप आसानी से टेक्स्ट को एनिमेट कर GIF बना सकते हैं। 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या चित्र डालने के बाद मूल छवि का रिज़ॉल्यूशन बना रहता है?**  
हां। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम रूप स्लाइड पर [picture](/slides/hi/net/picture-frame/) के स्केलिंग और सहेजते समय लागू की गई किसी भी संपीड़न पर निर्भर करता है।

**एक साथ दर्जनों स्लाइड्स में एक ही लोगो को बदलने का सबसे अच्छा तरीका क्या है?**  
लोगो को मास्टर स्लाइड या लेआउट पर रखें और प्रस्तुति की इमेज कलेक्शन में बदलें—अपडेट सभी उन तत्वों में प्रसारित हो जाएंगे जो उस संसाधन का उपयोग करते हैं।

**क्या डाली गई SVG को संपादनीय आकारों में बदला जा सकता है?**  
हां। आप SVG को आकारों के समूह में परिवर्तित कर सकते हैं, जिसके बाद व्यक्तिगत भाग मानक आकार गुणों के साथ संपादनीय हो जाते हैं।

**एक साथ कई स्लाइड्स की पृष्ठभूमि के रूप में चित्र कैसे सेट करूँ?**  
[इमेज को पृष्ठभूमि के रूप में असाइन करें](/slides/hi/net/presentation-background/) मास्टर स्लाइड या संबंधित लेआउट पर—उस मास्टर/लेआउट का उपयोग करने वाली सभी स्लाइड्स पृष्ठभूमि को विरासत में ले लेंगी।

**कई चित्रों के कारण प्रस्तुति बहुत बड़ी हो जाने से कैसे बचा जाए?**  
एक ही इमेज संसाधन को पुन: उपयोग करें, उचित रिज़ॉल्यूशन चुनें, सहेजते समय संपीड़न लागू करें, और जहाँ उचित हो ग्राफिक्स को मास्टर पर रखें।