---
title: PowerPoint प्रस्तुतियों को .NET में Word दस्तावेज़ों में बदलें
linktitle: PowerPoint से Word
type: docs
weight: 110
url: /hi/net/convert-powerpoint-to-word/
keywords:
- PowerPoint बदलें
- प्रेज़ेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से Word
- प्रेज़ेंटेशन से Word
- स्लाइड से Word
- PPT से Word
- PPTX से Word
- PowerPoint से DOCX
- प्रेज़ेंटेशन से DOCX
- स्लाइड से DOCX
- PPT से DOCX
- PPTX से DOCX
- PowerPoint से DOC
- प्रेज़ेंटेशन से DOC
- स्लाइड से DOC
- PPT से DOC
- PPTX से DOC
- PPT को DOCX के रूप में सहेजें
- PPTX को DOCX के रूप में सहेजें
- PPT को DOCX में निर्यात करें
- PPTX को DOCX में निर्यात करें
- .NET
- C#
- Aspose.Slides
description: "C# में Aspose.Slides for .NET का उपयोग करके PowerPoint PPT और PPTX स्लाइड्स को संपादन योग्य Word दस्तावेज़ों में बदलें, जिसमें सटीक लेआउट, छवियां और फॉर्मेटिंग संरक्षित रहती है।"
---
## **अवलोकन**

यह लेख डेवलपर्स को Aspose.Slides for .NET और Aspose.Words for .NET का उपयोग करके PowerPoint और OpenDocument प्रेजेंटेशनों को Word दस्तावेज़ों में बदलने का समाधान प्रदान करता है। चरण-दर-चरण गाइड आपके परिवर्तन प्रक्रिया के हर चरण को बताता है।

## **प्रेजेंटेशन को Word दस्तावेज़ में परिवर्तित करें**

PowerPoint या OpenDocument प्रेजेंटेशन को Word दस्तावेज़ में परिवर्तित करने के लिए नीचे दिए गए निर्देशों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास को instantiate करें और प्रेजेंटेशन फ़ाइल लोड करें।
2. [Document](https://reference.aspose.com/words/net/aspose.words/document/) और [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) क्लासेज़ को instantiate करके एक Word दस्तावेज़ जनरेट करें।
3. Word दस्तावेज़ का पेज आकार प्रेजेंटेशन के समान करने के लिए [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) प्रॉपर्टी सेट करें।
4. Word दस्तावेज़ में मार्जिन सेट करने के लिए [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) प्रॉपर्टी का उपयोग करें।
5. सभी प्रेजेंटेशन स्लाइड्स को [Presentation.Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slides/hi/) प्रॉपर्टी के माध्यम से क्रमिक रूप से प्रोसेस करें।
    - `GetImage` मेथड का उपयोग करके [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/) इंटरफ़ेस से स्लाइड इमेज जनरेट करें और इसे मेमोरी स्ट्रीम में सेव करें।
    - `InsertImage` मेथड का उपयोग करके स्लाइड इमेज को [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) क्लास से Word दस्तावेज़ में जोड़ें।
6. Word दस्तावेज़ को फ़ाइल में सेव करें।

मान लीजिए हमारे पास "sample.pptx" नामक एक प्रेजेंटेशन है जो इस प्रकार दिखता है:

![PowerPoint presentation](PowerPoint.png)

नीचे दिया गया C# कोड उदाहरण दिखाता है कि PowerPoint प्रेजेंटेशन को Word दस्तावेज़ में कैसे कन्वर्ट किया जाता है:

```cs
using Aspose.Slides;
using Aspose.Words;

// प्रस्तुति फ़ाइल लोड करें।
using var presentation = new Presentation("sample.pptx");

// Document और DocumentBuilder ऑब्जेक्ट बनाएं।
var document = new Document();
var builder = new DocumentBuilder(document);

// Word दस्तावेज़ में पेज आकार सेट करें।
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Word दस्तावेज़ में मार्जिन सेट करें।
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// सभी प्रस्तुति स्लाइड्स को क्रम में प्रोसेस करें।
foreach (var slide in presentation.Slides)
{
    // स्लाइड इमेज जेनरेट करें और मेमोरी स्ट्रीम में सेव करें।
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // स्लाइड इमेज को Word दस्तावेज़ में जोड़ें।
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Save the Word document to a file.
document.Save("output.docx");
```

परिणाम:

![Word document](Word.png)

{{% alert color="info" %}} 

हमारे [**Online PPT to Word Converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-word) को आज़माएँ और जानें कि PowerPoint और OpenDocument प्रेजेंटेशनों को Word दस्तावेज़ों में बदलने से आपको क्या लाभ मिल सकता है। 

{{% /alert %}}

## **FAQ**

### PowerPoint और OpenDocument प्रेजेंटेशनों को Word दस्तावेज़ों में बदलने के लिए कौन से कॉम्पोनेन्ट्स इंस्टॉल करने आवश्यक हैं?

आपको केवल अपने C# प्रोजेक्ट में [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) और [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) के संबंधित NuGet पैकेज जोड़ने की जरूरत है। दोनों लाइब्रेरीज़ स्वतंत्र APIs के रूप में कार्य करती हैं और माइक्रोसॉफ्ट ऑफिस स्थापित होना आवश्यक नहीं है।

### क्या सभी PowerPoint और OpenDocument प्रेजेंटेशन फ़ॉर्मैट्स समर्थित हैं?

Aspose.Slides for .NET सभी प्रेजेंटेशन फ़ॉर्मैट्स [समर्थित करता है](/slides/hi/net/supported-file-formats/), जिसमें PPT, PPTX, ODP और अन्य सामान्य फ़ाइल प्रकार शामिल हैं। इससे आप विभिन्न संस्करणों के Microsoft PowerPoint में बनाए गए प्रेजेंटेशनों के साथ काम कर सकते हैं।