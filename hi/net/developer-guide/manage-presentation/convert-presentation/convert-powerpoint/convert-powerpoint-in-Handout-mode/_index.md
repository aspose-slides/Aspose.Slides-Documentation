---
title: Handout Mode में .NET में PowerPoint प्रस्तुतियों को परिवर्तित करें
linktitle: हैंडआउट मोड
type: docs
weight: 150
url: /hi/net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- हैंडआउट मोड
- हैंडआउट
- PowerPoint
- प्रस्तुति
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: ".NET में प्रस्तुतियों को हैंडआउट में परिवर्तित करें। प्रति पृष्ठ स्लाइड्स सेट करें, नोट्स रखें, Aspose.Slides के साथ PDF या इमेजेस में निर्यात करें, साथ ही नमूना C# कोड। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुतियों को ऐसे आउटपुट फॉर्मैट में बदलने की सुविधा देता है जो हैंडआउट मोड को समर्थन देते हैं। इस मोड में, कई स्लाइड्स को एक पृष्ठ पर व्यवस्थित किया जाता है, जो सम्मेलनों, सेमिनारों और समान कार्यक्रमों के लिए प्रस्तुति सामग्री प्रिंट करने में उपयोगी है।

हैंडआउट मोड को `SlidesLayoutOptions` प्रॉपर्टी के माध्यम से कॉन्फ़िगर किया जाता है, जो [IPdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ihtmloptions/), और [ITiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/itiffoptions/) में उपलब्ध है। हैंडआउट लेआउट को परिभाषित करने के लिए, [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें।

एक्सपोर्ट से पहले हैंडआउट पेज आयाम और अभिविन्यास सेट करने के लिए, देखें [नोट पेज आकार](/slides/hi/net/notes-size/)।

## **हैंडआउट मोड निर्यात**

हैंडआउट मोड में प्रस्तुति को निर्यात करने के लिए, लक्ष्य निर्यात विकल्पों के लिए `SlidesLayoutOptions` प्रॉपर्टी सेट करें और एक [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/handoutlayoutingoptions/) इंस्टेंस असाइन करें जो प्रति पृष्ठ स्लाइड्स की संख्या और संबंधित प्रदर्शन पैरामीटर निर्धारित करता है।

नीचे एक कोड उदाहरण दिया गया है जो दिखाता है कि कैसे हैंडआउट मोड में प्रस्तुति को PDF में परिवर्तित किया जाए।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रस्तुति लोड करें।
using var presentation = new Presentation("sample.pptx");

// निर्यात विकल्प सेट करें।
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // एक पृष्ठ पर क्षैतिज रूप से 4 स्लाइड्स
        PrintSlideNumbers = true,                   // स्लाइड नंबर प्रिंट करें
        PrintFrameSlide = true,                     // स्लाइड्स के चारों ओर फ्रेम प्रिंट करें
        PrintComments = false                       // कोई टिप्पणी नहीं
    }
};

// चयनित लेआउट के साथ प्रस्तुति को PDF में निर्यात करें।
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
ध्यान रखें कि `SlidesLayoutOptions` प्रॉपर्टी केवल कुछ आउटपुट फॉर्मैट्स के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और इमेजेस के रूप में रेंडरिंग करते समय। 
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

### हैंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल्स की संख्या क्या है?

Aspose.Slides [प्रेसेट](https://reference.aspose.com/slides/hi/net/aspose.slides.export/handouttype/) को समर्थन देता है, जो क्षैतिज या लंबवत क्रम में प्रति पृष्ठ अधिकतम 9 थंबनेल तक होते हैं: 1, 2, 3, 4 (क्षैतिज/लंबवत), 6 (क्षैतिज/लंबवत), और 9 (क्षैतिज/लंबवत)।

### क्या मैं कस्टम ग्रिड, जैसे 5 या 8 स्लाइड्स प्रति पृष्ठ, परिभाषित कर सकता हूँ?

नहीं। थंबनेल्स की संख्या और क्रम को सख्ती से [HandoutType](https://reference.aspose.com/slides/hi/net/aspose.slides.export/handouttype/) एनोमरेशन द्वारा नियंत्रित किया जाता है; मनमाने लेआउट समर्थित नहीं हैं।

### क्या मैं हैंडआउट आउटपुट में छिपी हुई स्लाइड्स को शामिल कर सकता हूँ?

हां। लक्ष्य फॉर्मैट के लिए निर्यात सेटिंग्स में `ShowHiddenSlides` विकल्प सक्षम करें, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/)।