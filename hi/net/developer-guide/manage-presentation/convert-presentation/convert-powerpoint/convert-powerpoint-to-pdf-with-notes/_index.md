---
title: .NET में नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में बदलें
linktitle: नोट्स के साथ PowerPoint से PDF
type: docs
weight: 50
url: /hi/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से PDF
- प्रस्तुति से PDF
- स्लाइड से PDF
- PPT से PDF
- PPTX से PDF
- प्रस्तुति को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- स्पीकर नोट्स
- नोट्स के साथ PDF
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides का उपयोग करके नोट्स के साथ PPT और PPTX प्रारूपों को PDF में बदलें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें।"
---
## **समीक्षा**

इस लेख में, आप Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF प्रारूप में परिवर्तित करना सीखेंगे। यह मार्गदर्शिका आवश्यक चरणों को कवर करेगी और कोड उदाहरण प्रदान करेगी जिससे आप यह कार्य कुशलतापूर्वक पूरा कर सकेंगे। लेख के अंत तक, आप सक्षम होंगे:

- स्पीकर नोट्स को कायम रखते हुए PowerPoint स्लाइड्स को PDF दस्तावेज़ों में बदलने की रूपांतरण प्रक्रिया को लागू करना।
- आउटपुट PDF को इस प्रकार अनुकूलित करना कि स्पीकर नोट्स शामिल हों और आपकी आवश्यकताओं के अनुसार स्वरूपित हों।

## **स्पीकर नोट्स के साथ PowerPoint को PDF में परिवर्तित करें**

`Save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास में उपयोग करके PPT या PPTX प्रस्तुति को स्पीकर नोट्स के साथ PDF में परिवर्तित किया जा सकता है। Aspose.Slides के साथ, आप सिर्फ प्रस्तुति को लोड करते हैं, स्पीकर नोट्स शामिल करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्पों को कॉन्फ़िगर करते हैं, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। निम्नलिखित कोड स्निपेट दर्शाता है कि नमूना प्रस्तुति को नोट्स स्लाइड व्यू में PDF में कैसे परिवर्तित किया जाए।

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // स्पीकर नोट्स को रेंडर करने के लिए PDF विकल्प कॉन्फ़िगर करें।
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // स्लाइड के नीचे स्पीकर नोट्स रेंडर करें।
        }
    };

    // स्पीकर नोट्स के साथ प्रस्तुति को PDF में सहेजें।
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 
आप Aspose के [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) को देख सकते हैं। 
{{% /alert %}}