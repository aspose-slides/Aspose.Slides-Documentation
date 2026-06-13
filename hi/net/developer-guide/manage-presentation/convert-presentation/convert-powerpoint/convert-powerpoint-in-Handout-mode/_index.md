---
title: .NET में हैंडआउट मोड में PowerPoint प्रस्तुतियों को परिवर्तित करें
linktitle: हैंडआउट मोड
type: docs
weight: 150
url: /hi/net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- हैंडआउट मोड
- हैंडआउट
- PowerPoint
- प्रस्तुति
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: ".NET में प्रस्तुतियों को हैंडआउट में परिवर्तित करें। प्रति पृष्ठ स्लाइड्स सेट करें, नोट्स रखें, Aspose.Slides के साथ PDF या छवियों में निर्यात करें, नमूना C# कोड के साथ। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुतियों को उन आउटपुट फ़ॉर्मेट में कन्वर्ट करने की सुविधा देता है जो हैंडआउट मोड का समर्थन करते हैं। इस मोड में, कई स्लाइड्स एक पृष्ठ पर व्यवस्थित की जाती हैं, जो सम्मेलनों, सेमिनारों और समान घटनाओं के लिए प्रस्तुति सामग्री प्रिंट करने में उपयोगी है।

Handout मोड को `SlidesLayoutOptions` प्रॉपर्टी के माध्यम से कॉन्फ़िगर किया जाता है, जो [IPdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ihtmloptions/), और [ITiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/itiffoptions/) में उपलब्ध है। Handout लेआउट को परिभाषित करने के लिए, [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें।

## **हैंडआउट मोड निर्यात**

Handout मोड में एक प्रस्तुति निर्यात करने के लिए, लक्ष्य निर्यात विकल्पों के लिए `SlidesLayoutOptions` प्रॉपर्टी सेट करें और एक [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/handoutlayoutingoptions/) इंस्टेंस असाइन करें जो प्रति पृष्ठ स्लाइड्स की संख्या और संबंधित प्रदर्शन पैरामीटर निर्धारित करता है।

नीचे एक कोड उदाहरण दिया गया है जो Handout मोड में प्रस्तुति को PDF में बदलने को दर्शाता है।

```c#
// प्रस्तुति लोड करें.
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // एक पृष्ठ पर 4 स्लाइड्स क्षैतिज रूप से
        PrintSlideNumbers = true,                   // स्लाइड नंबर प्रिंट करें
        PrintFrameSlide = true,                     // स्लाइड्स के चारों ओर फ्रेम प्रिंट करें
        PrintComments = false                       // कोई टिप्पणी नहीं
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
ध्यान रखें कि `SlidesLayoutOptions` प्रॉपर्टी केवल कुछ आउटपुट फ़ॉर्मेट के लिए ही उपलब्ध है, जैसे PDF, HTML, TIFF, और जब छवियों के रूप में रेंडर किया जाता है। 
{{% /alert %}} 

## **FAQ**

**Handout मोड में प्रति पृष्ठ अधिकतम कितने स्लाइड थंबनेल हो सकते हैं?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/net/aspose.slides.export/handouttype/) को समर्थन देता है जो क्षैतिज या ऊर्ध्वाधर क्रम में प्रति पृष्ठ अधिकतम 9 थंबनेल तक होते हैं: 1, 2, 3, 4 (क्षैतिज/ऊर्ध्वाधर), 6 (क्षैतिज/ऊर्ध्वाधर), और 9 (क्षैतिज/ऊर्ध्वाधर)।

**क्या मैं 5 या 8 स्लाइड्स प्रति पृष्ठ जैसे कस्टम ग्रिड को परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम को पूरी तरह से [HandoutType](https://reference.aspose.com/slides/hi/net/aspose.slides.export/handouttype/) एनेमरेशन द्वारा नियंत्रित किया जाता है; मनमाने लेआउट का समर्थन नहीं किया जाता।

**क्या मैं Handout आउटपुट में छिपी हुई स्लाइड्स शामिल कर सकता हूँ?**

हाँ। लक्ष्य फ़ॉर्मेट के लिए निर्यात सेटिंग्स में, जैसे [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/), `ShowHiddenSlides` विकल्प को सक्षम करें।