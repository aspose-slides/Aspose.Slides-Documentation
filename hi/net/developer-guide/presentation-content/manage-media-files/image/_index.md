---
title: ".NET में प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें"
linktitle: "छवियों का प्रबंधन"
type: docs
weight: 10
url: /hi/net/image/
keywords:
- "छवि जोड़ें"
- "चित्र जोड़ें"
- "बिटमैप जोड़ें"
- "छवि बदलें"
- "चित्र बदलें"
- "वेब से"
- "पृष्ठभूमि"
- "PNG जोड़ें"
- "JPG जोड़ें"
- "SVG जोड़ें"
- "बाहरी SVG संसाधन"
- "SVG रिज़ॉल्वर"
- "लिंक्ड SVG छवियाँ"
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
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument में छवि प्रबंधन को सरल बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियाँ प्रस्तुतियों को अधिक आकर्षक और दृश्य रूप से सुखद बनाती हैं। Microsoft PowerPoint में, आप फ़ाइलों, इंटरनेट या अन्य स्रोतों से चित्रों को स्लाइड्स पर सम्मिलित कर सकते हैं। इसी तरह, Aspose.Slides आपको विभिन्न तरीकों से प्रस्तुति स्लाइड्स में छवियों को जोड़ने की अनुमति देता है।

{{% alert  title="Tip" color="info" %}} 

Aspose मुफ्त रूपांतरणकर्ताओं—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—को प्रदान करता है जो आपको छवियों से जल्दी प्रस्तुतियां बनाने की सुविधा देते हैं। 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

यदि आप एक छवि को चित्र फ्रेम के रूप में जोड़ना चाहते हैं—विशेष रूप से यदि आप इसे आकार बदलने, प्रभाव लागू करने, या अन्य मानक स्वरूपण विकल्पों का उपयोग करने की योजना बना रहे हैं—देखें [Picture Frame](/slides/hi/net/picture-frame/)। 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

आप छवियों को एक स्वरूप से दूसरे स्वरूप में परिवर्तित कर सकते हैं। निम्नलिखित पृष्ठ देखें: convert [image to JPG](https://products.aspose.com/slides/hi/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hi/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hi/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hi/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hi/net/conversion/png-to-svg/), और [SVG to PNG](https://products.aspose.com/slides/hi/net/conversion/svg-to-png/)।

{{% /alert %}}

Aspose.Slides लोकप्रिय स्वरूपों जैसे JPEG, PNG, BMP, GIF, और अन्य में छवियों का समर्थन करता है। 

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

## **वेब से स्लाइड्स में छवियाँ जोड़ें**

यदि वह छवि जो आप स्लाइड में जोड़ना चाहते हैं आपके कंप्यूटर पर संग्रहीत नहीं है, तो आप इसे सीधे वेब से जोड़ सकते हैं। 

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

## **स्लाइड मास्टर में छवियाँ जोड़ें**

एक स्लाइड मास्टर थीम और लेआउट जैसी जानकारी को संग्रहीत और नियंत्रित करता है जो इसके उपयोग वाली स्लाइड्स के लिए होती है। जब आप स्लाइड मास्टर में एक छवि जोड़ते हैं, तो वह छवि उस मास्टर पर आधारित प्रत्येक स्लाइड में दिखाई देती है। 

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

## **स्लाइड पृष्ठभूमि के रूप में छवियों को जोड़ें**

आप एक या अधिक स्लाइड्स की पृष्ठभूमि के रूप में चित्र का उपयोग कर सकते हैं। विवरण के लिए देखें *[Setting Images as Backgrounds for Slides](/slides/hi/net/presentation-background/#setting-images-as-background-for-slides)*।

## **प्रस्तुतियों में SVG जोड़ें**

SVG सामग्री को [SvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/svgimage/) क्लास का उपयोग करके प्रस्तुति में जोड़ा जा सकता है। परिणामी [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) ऑब्जेक्ट को फिर प्रस्तुति की इमेज कलेक्शन में जोड़ा जा सकता है और इसे एक चित्र फ्रेम बनाने के लिए उपयोग किया जा सकता है। 

निम्नलिखित C# उदाहरण एक आत्म-contained SVG स्ट्रिंग आयात करता है। इस SVG द्वारा उपयोग की गई सभी छवियाँ, शैलियाँ, और अन्य संसाधन सीधे SVG सामग्री में एम्बेड किए जाते हैं।

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

डिज़ाइन टूल्स, आरेख संपादकों, आइकन सिस्टम और वेब पाइपलाइन से निर्यात की गई SVG फ़ाइलें ऐसे संसाधनों का संदर्भ दे सकती हैं जो SVG दस्तावेज़ के बाहर संग्रहीत होते हैं। उदाहरण के लिए, एक SVG में `images/photo.png` जैसी छवि लिंक, CSS `url(...)` मान, या फ़ॉन्ट URL हो सकता है। 

ऐसी SVG सामग्री आयात करने के लिए, एक [IExternalResourceResolver](https://reference.aspose.com/slides/hi/net/aspose.slides.import/iexternalresourceresolver/) कार्यान्वयन बनाएं और इसे बेस URI के साथ उपयुक्त `SvgImage` कंस्ट्रक्टर में पास करें। बेस URI SVG दस्तावेज़ के स्थान की पहचान करता है और सापेक्ष लिंक को हल करने के लिए उपयोग किया जाता है। 

[ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) इंटरफ़ेस आयातित SVG के बारे में जानकारी तक पहुंच प्रदान करता है:

- `SvgContent` SVG मार्कअप को स्ट्रिंग के रूप में लौटाता है।
- `SvgData` SVG सामग्री को बाइट ऐरे के रूप में लौटाता है।
- `BaseUri` सापेक्ष लिंक के लिए उपयोग किए गए बेस URI को लौटाता है।
- `ExternalResourceResolver` SVG छवि को सौंपे गए रिज़ॉल्वर को लौटाता है।

### **बाहरी संसाधन रिज़ॉल्वर लागू करें**

रिज़ॉल्वर में दो मेथड हैं:

- [ResolveUri](https://reference.aspose.com/slides/hi/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) बेस URI और सापेक्ष संसाधन लिंक को मिलाकर एक पूर्ण URI लौटाता है। जब लिंक हल नहीं हो सके या अनुमति नहीं हो तो `null` लौटाएँ। 
- [GetEntity](https://reference.aspose.com/slides/hi/net/aspose.slides.import/iexternalresourceresolver/getentity/) पूर्ण संसाधन URI के लिए एक पढ़ने योग्य स्ट्रीम लौटाता है। जब संसाधन अनुपलब्ध, अवरुद्ध या नहीं मिला हो तो `null` लौटाएँ। उपयुक्त होने पर एक फॉलबैक स्ट्रीम भी लौटाई जा सकती है। 

निम्नलिखित रिज़ॉल्वर लिंक किए गए संसाधनों को केवल अनुमति वाले स्थानीय निर्देशिका से लोड करता है। नेटवर्क संसाधन और अनुमति निर्देशिका के बाहर के पथ अवरुद्ध होते हैं। अनसुलझे चित्र लिंक के लिए वैकल्पिक फॉलबैक छवि लौटाई जाती है।

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

        // यह रिज़ॉल्वर जानबूझकर केवल स्थानीय फ़ाइलों की अनुमति देता है।
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

        // केवल छवि संसाधनों के लिए फॉलबैक का उपयोग करें। इमेज स्ट्रीम लौटाना
        // गायब फ़ॉन्ट या स्टाइलशीट के लिए वैध नहीं होगा।
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

निम्नलिखित C# उदाहरण SVG फ़ाइल URI को बेस URI के रूप में पास करता है और एक कस्टम रिज़ॉल्वर प्रदान करता है। रिज़ॉल्वर सापेक्ष चित्र लिंक को पूर्ण URI में बदलता है और Aspose.Slides के SVG प्रोसेस करते समय लिंक्ड संसाधन को शामिल करने वाली स्ट्रीम वापस देता है।

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// बेस URI SVG दस्तावेज़ के स्थान को दर्शाता है।
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage स्रोत सामग्री, बाइनरी डेटा, बेस URI और रिज़ॉल्वर को उजागर करता है।
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

`SvgImage` क्लास अतिरिक्त ओवरलोड भी प्रदान करता है जो SVG डेटा को बाइट ऐरे या स्ट्रीम के रूप में, साथ ही एक बाहरी संसाधन रिज़ॉल्वर और बेस URI को स्वीकार करता है।

{{% alert title="Important" color="warning" %}}

रिसोर्स रिज़ॉल्वर Aspose.Slides के SVG को प्रोसेस और रेंडर करते समय बाहरी संसाधनों को उपलब्ध कराता है। यह मूल SVG मार्कअप को संशोधित नहीं करता और न ही स्वचालित रूप से हल किए गए संसाधनों को उसमें एम्बेड करता है।

जब `ISvgImage` को प्रस्तुति इमेज कलेक्शन में जोड़ा जाता है, तो PPTX फ़ाइल मूल SVG प्रतिनिधित्व और एक रास्टर फॉलबैक इमेज दोनों को समाहित कर सकती है। लिंक्ड रिसोर्स उत्पन्न फॉलबैक इमेज में दिखाई दे सकता है जबकि सापेक्ष लिंक जैसे `images/photo.png` संग्रहीत SVG में अपरिवर्तित रहता है। मूल बाहरी संसाधन अनुपलब्ध होने पर मूल SVG प्रतिनिधित्व को रेंडर करने वाला एप्लिकेशन लिंक्ड कंटेंट को छोड़ सकता है।

{{% /alert %}}

### **एक पोर्टेबल SVG चित्र बनाएं**

एक ऐसा SVG चित्र बनाने के लिए जो बाहरी फ़ाइलों पर निर्भर न हो, `SvgImage` बनाने से पहले SVG को आत्म-contained बनाएं। उदाहरण के लिए, लिंक्ड इमेज URL को `data:` URI से बदलें जिसमें इमेज डेटा हो:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

जब सभी आवश्यक संसाधन SVG सामग्री में एम्बेड हो जाएँ, `SvgImage` बनाएं, इसे प्रस्तुति इमेज कलेक्शन में जोड़ें, और पिछले उदाहरण में दिखाए अनुसार इसे एक चित्र फ्रेम में सम्मिलित करें।

### **गुम या ब्लॉक किए गए संसाधनों को संभालें**

`ResolveUri` से `null` लौटाएँ जब संसाधन URI अमान्य, प्रतिबंधित या असहल हो। `GetEntity` से `null` लौटाएँ जब संसाधन को पढ़ा नहीं जा सकता। जब संभव हो, Aspose.Slides उस संसाधन के बिना SVG प्रोसेसिंग जारी रखता है।

एक फॉलबैक स्ट्रीम गुम संसाधन के लिए लौटाई जा सकती है, लेकिन उसकी सामग्री अनुरोधित संसाधन प्रकार के साथ संगत होनी चाहिए। उदाहरण के लिए, केवल एक गुम इमेज के लिए इमेज स्ट्रीम लौटाएँ, फ़ॉन्ट या स्टाइलशीट के लिए नहीं।

{{% alert title="Security" color="warning" %}}

अविश्वसनीय SVG फ़ाइलों से मनमाने फ़ाइल पथ या अनिर्बंधित नेटवर्क URL को हल न करें। अनुमत स्कीम, निर्देशिकाएँ, और होस्ट को प्रतिबंधित करें। नेटवर्क संसाधनों के लिए, कनेक्शन टाइमआउट, प्रतिक्रिया आकार सीमाएँ, और सामग्री वैधता भी लागू करें।

{{% /alert %}}

## **SVG को आकारों के सेट में परिवर्तित करें**
Aspose.Slides एक SVG को आकारों के सेट में परिवर्तित कर सकता है, जैसा कि PowerPoint में संबंधित कार्यक्षमता है:

![PowerPoint Popup Menu](img_01_01.png)

यह कार्यक्षमता [AddGroupShape](https://reference.aspose.com/slides/hi/net/aspose.slides.ishapecollection/addgroupshape/methods/1) मेथड के ओवरलोड द्वारा प्रदान की जाती है, जो [IShapeCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection) इंटरफ़ेस का है और जिसका पहला तर्क एक [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage) ऑब्जेक्ट होता है। 

निम्नलिखित C# नमूना कोड दिखाता है कि इस मेथड का उपयोग करके SVG फ़ाइल को आकारों के सेट में कैसे परिवर्तित किया जाए:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// स्रोत SVG फ़ाइल नाम
string svgFileName = "sample.svg";

// आउटपुट प्रस्तुति फ़ाइल नाम
string outPptxPath = "presentation.pptx";

// नई प्रस्तुति बनाएँ
using (IPresentation presentation = new Presentation())
{
    // SVG फ़ाइल की सामग्री पढ़ें
    string svgContent = File.ReadAllText(svgFileName);

    // एक SvgImage ऑब्जेक्ट बनाएँ
    ISvgImage svgImage = new SvgImage(svgContent);

    // स्लाइड का आकार प्राप्त करें
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG छवि को आकारों के समूह में परिवर्तित करें और इसे स्लाइड आकार के अनुसार स्केल करें
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // प्रस्तुति को PPTX प्रारूप में सहेजें
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **EMF के रूप में छवियों को स्लाइड्स में जोड़ें**
Aspose.Slides for .NET आपको Aspose.Cells के साथ Excel वर्कशीट्स से EMF छवियों को जनरेट करने और उन्हें प्रस्तुति स्लाइड्स में जोड़ने की अनुमति देता है।

निम्नलिखित C# नमूना कोड दिखाता है कि यह कैसे किया जाए:

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

    // कार्यपुस्तिका को स्ट्रीम में सहेजें
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

## **इमेज कलेक्शन में छवियों को बदलें**
Aspose.Slides आपको प्रस्तुति की इमेज कलेक्शन में संग्रहीत छवियों को बदलने की सुविधा देता है, जिसमें स्लाइड शैप्स द्वारा उपयोग की गई छवियाँ भी शामिल हैं। यह अनुभाग कलेक्शन में छवियों को अपडेट करने के कई तरीकों का वर्णन करता है। आप कच्चा बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में पहले से मौजूद किसी अन्य छवि का उपयोग करके छवि बदल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उपयोग करके छवियों वाली प्रस्तुति फ़ाइल लोड करें।  
2. फ़ाइल से एक नई छवि को बाइट ऐरे में लोड करें।  
3. बाइट ऐरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।  
4. दूसरे तरीके में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और लक्ष्य छवि को उस ऑब्जेक्ट से बदलें।  
5. तीसरे तरीके में, लक्ष्य छवि को प्रस्तुति की इमेज कलेक्शन में पहले से मौजूद छवि से बदलें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रेजेंटेशन फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं।
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

// प्रेजेंटेशन को फ़ाइल में सहेजें।
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Aspose के मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) रूपांतरणकर्ता के साथ, आप आसानी से टेक्स्ट को एनीमेट कर सकते हैं और टेक्स्ट से GIF बना सकते हैं। 

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या इन्सर्ट करने के बाद मूल छवि रिज़ॉल्यूशन अपरिवर्तित रहता है?**

हाँ। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम दिखावट इस बात पर निर्भर करती है कि स्लाइड पर [picture](/slides/hi/net/picture-frame/) कैसे स्केल किया गया है और बचत पर लागू किसी भी संपीड़न पर।

**कई स्लाइड्स में एक ही लोगो को एक साथ बदलने का सबसे अच्छा तरीका क्या है?**

लोगो को मास्टर स्लाइड या लेआउट पर रखें और प्रस्तुति की इमेज कलेक्शन में उसे बदलें—अपडेट उसी संसाधन का उपयोग करने वाले सभी तत्वों में प्रसारित हो जाएंगे।

**क्या सम्मिलित SVG को संपादन योग्य शैप्स में बदल सकते हैं?**

हाँ। आप SVG को शैप्स के समूह में बदल सकते हैं, जिसके बाद व्यक्तिगत भाग मानक शैप प्रॉपर्टीज़ के साथ संपादन योग्य हो जाते हैं।

**मैं एक चित्र को कई स्लाइड्स की पृष्ठभूमि के रूप में एक साथ कैसे सेट करूँ?**

[चित्र को पृष्ठभूमि के रूप में असाइन करें](/slides/hi/net/presentation-background/) मास्टर स्लाइड या संबंधित लेआउट पर—जिस भी स्लाइड में वह मास्टर/लेआउट उपयोग हो रहा है, वह पृष्ठभूमि विरासत में ले लेगी।

**बहुत सारी छवियों के कारण प्रस्तुति का आकार बहुत बड़ा होने से कैसे बचें?**

डुप्लिकेट्स के बजाय एक ही इमेज रिसोर्स का पुन: उपयोग करें, उचित रिज़ॉल्यूशन चुनें, बचत पर संपीड़न लागू करें, और जहाँ उपयुक्त हो, दोहराई गई ग्राफ़िक्स को मास्टर पर रखें।