---
title: ".NET में PowerPoint प्रस्तुतियों को Word दस्तावेज़ों में बदलें"
linktitle: "PowerPoint से Word"
type: docs
weight: 110
url: /hi/net/convert-powerpoint-to-word/
keywords:
- PowerPoint रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
- PowerPoint से Word
- प्रस्तुति से Word
- स्लाइड से Word
- PPT से Word
- PPTX से Word
- PowerPoint से DOCX
- प्रस्तुति से DOCX
- स्लाइड से DOCX
- PPT से DOCX
- PPTX से DOCX
- PowerPoint से DOC
- प्रस्तुति से DOC
- स्लाइड से DOC
- PPT से DOC
- PPTX से DOC
- PPT को DOCX के रूप में सहेजें
- PPTX को DOCX के रूप में सहेजें
- PPT निर्यात करें DOCX में
- PPTX निर्यात करें DOCX में
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके C# में PowerPoint PPT और PPTX स्लाइड्स को संपादन योग्य Word दस्तावेज़ों में सटीक लेआउट, छवियों और स्वरूपण को संरक्षित रखते हुए बदलें।"
---
## **परिचय**

यह लेख डेवलपर्स को Aspose.Slides for .NET और Aspose.Words for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में बदलने का समाधान प्रदान करता है। चरण‑दर‑चरण मार्गदर्शिका आपको रूपांतरण प्रक्रिया के हर चरण से ले जाती है।

## **एक प्रस्तुति को Word दस्तावेज़ में बदलें**

PowerPoint या OpenDocument प्रस्तुति को Word दस्तावेज़ में बदलने के लिए नीचे दिए गए निर्देशों का पालन करें:

1. [Presentation] क्लास का उदाहरण बनाकर एक प्रस्तुति फ़ाइल लोड करें।
2. [Document] और [DocumentBuilder] क्लासेज़ को instantiate करके एक Word दस्तावेज़ उत्पन्न करें।
3. [DocumentBuilder.PageSetup] प्रॉपर्टी का उपयोग करके Word दस्तावेज़ का पृष्ठ आकार प्रस्तुति के समान सेट करें।
4. [DocumentBuilder.PageSetup] प्रॉपर्टी का उपयोग करके Word दस्तावेज़ में मार्जिन सेट करें।
5. [Presentation.Slides] प्रॉपर्टी का उपयोग करके सभी प्रस्तुति स्लाइड्स पर जाएँ।
   - `GetImage` मेथड को [ISlide] इंटरफ़ेस से उपयोग करके स्लाइड छवि उत्पन्न करें और उसे मेमोरी स्ट्रीम में सहेजें।
   - `InsertImage` मेथड को [DocumentBuilder] क्लास से उपयोग करके स्लाइड छवि को Word दस्तावेज़ में जोड़ें।
6. Word दस्तावेज़ को फ़ाइल में सहेजें।

मान लीजिए हमारे पास एक प्रस्तुति "sample.pptx" है जो इस प्रकार दिखती है:

![PowerPoint प्रस्तुति](PowerPoint.png)

निम्नलिखित C# कोड उदाहरण दिखाता है कि PowerPoint प्रस्तुति को Word दस्तावेज़ में कैसे बदलें:

```cs
// एक प्रस्तुति फ़ाइल लोड करें।
using var presentation = new Presentation("sample.pptx");

// Document और DocumentBuilder ऑब्जेक्ट बनाएं।
var document = new Document();
var builder = new DocumentBuilder(document);

// Word दस्तावेज़ में पृष्ठ आकार सेट करें।
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Word दस्तावेज़ में मार्जिन सेट करें.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// सभी प्रस्तुति स्लाइड्स पर जाएँ.
foreach (var slide in presentation.Slides)
{
    // स्लाइड छवि उत्पन्न करें और उसे मेमोरी स्ट्रीम में सहेजें.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // स्लाइड छवि को Word दस्तावेज़ में जोड़ें.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Word दस्तावेज़ को फ़ाइल में सहेजें.
document.Save("output.docx");
```

परिणाम:

![Word दस्तावेज़](Word.png)

{{% alert color="primary" %}} 

हमारे [**ऑनलाइन PPT to Word कनवर्टर**](https://products.aspose.app/slides/hi/conversion/ppt-to-word) को आज़माएँ ताकि आप PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में बदलने से क्या लाभ पा सकते हैं, देख सकें। 

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में बदलने के लिए कौन से घटक स्थापित करने आवश्यक हैं?**

आपको केवल अपने C# प्रोजेक्ट में [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) और [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) के संबंधित NuGet पैकेज जोड़ने की आवश्यकता है। दोनों लाइब्रेरीं स्टैंडअलोन API के रूप में काम करती हैं, और Microsoft Office स्थापित करने की कोई आवश्यकता नहीं है।

**क्या सभी PowerPoint और OpenDocument प्रस्तुति फ़ॉर्मैट समर्थित हैं?**

Aspose.Slides for .NET [सभी प्रस्तुति फ़ॉर्मैट का समर्थन करता है](/slides/hi/net/supported-file-formats/), जिसमें PPT, PPTX, ODP, और अन्य सामान्य फ़ाइल प्रकार शामिल हैं। इससे आप विभिन्न संस्करणों के Microsoft PowerPoint में बनी प्रस्तुतियों के साथ काम कर सकते हैं।