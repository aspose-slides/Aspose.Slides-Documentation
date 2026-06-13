---
title: .NET में फ़ॉन्ट प्रतिस्थापन के लिए चेतावनी कॉलबैक प्राप्त करें
type: docs
weight: 120
url: /hi/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- चेतावनी कॉलबैक
- फ़ॉन्ट प्रतिस्थापन
- रेंडरिंग प्रक्रिया
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में फ़ॉन्ट प्रतिस्थापन के लिए चेतावनी कॉलबैक प्राप्त करना सीखें और PowerPoint तथा OpenDocument प्रस्तुतियों को सटीक रूप से प्रदर्शित करें।"
---
## **परिचय**

Aspose.Slides for .NET आपको फ़ॉन्ट प्रतिस्थापन के लिए चेतावनी कॉलबैक प्राप्त करने की अनुमति देता है जब रेंडरिंग के दौरान आवश्यक फ़ॉन्ट मशीन पर उपलब्ध नहीं होता है। ये कॉलबैक गायब या अप्राप्य फ़ॉन्टों से संबंधित समस्याओं का निदान करने में मदद करते हैं।

## **चेतावनी कॉलबैक सक्षम करें**

Aspose.Slides for .NET प्रस्तुति स्लाइड्स को रेंडर करते समय चेतावनी कॉलबैक प्राप्त करने के लिए सरल APIs प्रदान करता है। चेतावनी कॉलबैक को कॉन्फ़िगर करने के लिए निम्न चरणों का पालन करें:

1. एक कस्टम कॉलबैक क्लास बनाएं जो [IWarningCallback](https://reference.aspose.com/slides/hi/net/aspose.slides.warnings/iwarningcallback/) इंटरफ़ेस को लागू करती है ताकि चेतावनियों को संभाला जा सके।
1. विकल्प क्लासों जैसे [RenderingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmloptions/) आदि का उपयोग करके चेतावनी कॉलबैक सेट करें।
1. एक प्रस्तुति लोड करें जिसमें ऐसे फ़ॉन्ट का उपयोग किया गया हो जो लक्ष्य मशीन पर उपलब्ध नहीं है।
1. प्रभाव को देखने के लिए एक स्लाइड थंबनेल जनरेट करें या प्रस्तुति निर्यात करें।

**कस्टम चेतावनी कॉलबैक क्लास:**  

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// उदाहरण आउटपुट:
//
// फ़ॉन्ट XYZ से {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}} में प्रतिस्थापित किया जाएगा
```

**स्लाइड थंबनेल उत्पन्न करें:**  

```c#
// स्लाइड रेंडरिंग के दौरान फ़ॉन्ट-सम्बंधी चेतावनियों को संभालने के लिए चेतावनी कॉलबैक सेट करें।
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// निर्दिष्ट फ़ाइल पथ से प्रस्तुति लोड करें।
using var presentation = new Presentation("sample.pptx");

// प्रस्तुति में प्रत्येक स्लाइड के लिए थंबनेल छवि उत्पन्न करें।
foreach (var slide in presentation.Slides)
{
    // निर्दिष्ट रेंडरिंग विकल्पों का उपयोग करके स्लाइड थंबनेल छवि प्राप्त करें।
    using var image = slide.GetImage(options);
    // ...
}
```

**PDF प्रारूप में निर्यात करें:**  

```c#
// PDF निर्यात के दौरान फ़ॉन्ट-सम्बंधी चेतावनियों को संभालने के लिए चेतावनी कॉलबैक सेट करें।
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// निर्दिष्ट फ़ाइल पथ से प्रस्तुति लोड करें।
using var presentation = new Presentation("sample.pptx");

// प्रस्तुति को PDF के रूप में निर्यात करें।
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**HTML प्रारूप में निर्यात करें:**  

```c#
// HTML निर्यात के दौरान फ़ॉन्ट-सम्बंधी चेतावनियों को संभालने के लिए चेतावनी कॉलबैक सेट करें।
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// निर्दिष्ट फ़ाइल पथ से प्रस्तुति लोड करें।
using var presentation = new Presentation("sample.pptx");

// प्रस्तुति को HTML प्रारूप में निर्यात करें।
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```