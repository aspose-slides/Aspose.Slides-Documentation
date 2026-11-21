---
title: PowerPoint प्रस्तुतियों को .NET में नोट्स के साथ PDF में बदलें
linktitle: PowerPoint से PDF में नोट्स के साथ
type: docs
weight: 50
url: /hi/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint को PDF में
- प्रस्तुति को PDF में
- स्लाइड को PDF में
- PPT को PDF में
- PPTX को PDF में
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
description: "Aspose.Slides for .NET का उपयोग करके नोट्स के साथ PPT और PPTX को PDF में बदलें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें."
---
## **सारांश**

इस लेख में, आप सीखेंगे कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF प्रारूप में कैसे परिवर्तित किया जाए। यह मार्गदर्शिका आवश्यक चरणों को कवर करेगी और इस कार्य को कुशलता से पूर्ण करने में सहायता के लिए कोड उदाहरण प्रदान करेगी। लेख के अंत तक, आप सक्षम होंगे:

- परिवर्तन प्रक्रिया को लागू करें ताकि PowerPoint स्लाइड्स को PDF दस्तावेज़ों में परिवर्तित किया जा सके जबकि स्पीकर नोट्स को संरक्षित रखा जाए।
- आउटपुट PDF को अनुकूलित करें ताकि स्पीकर नोट्स को शामिल किया जा सके और आपकी आवश्यकताओं के अनुसार स्वरूपित किया जा सके।

निर्यात से पहले नोट्स पृष्ठ के आकार और अभिविन्यास को सेट करने के लिए, देखें [Notes Page Size](/slides/hi/net/notes-size/)।

## **स्पीकर नोट्स के साथ PowerPoint को PDF में बदलें**

`Save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास में उपयोग करके PPT या PPTX प्रस्तुति को स्पीकर नोट्स के साथ PDF में बदला जा सकता है। Aspose.Slides के साथ, आप बस प्रस्तुति को लोड करते हैं, स्पीकर नोट्स शामिल करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्प कॉन्फ़िगर करते हैं, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। नीचे दिया गया कोड स्निपेट दर्शाता है कि कैसे नमूना प्रस्तुति को नोट्स स्लाइड व्यू में PDF में बदला जाए।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // स्पीकर नोट्स को रेंडर करने के लिये PDF विकल्प कॉन्फ़िगर करें।
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

{{% alert color="info" %}} 
आप Aspose [ऑनलाइन PowerPoint से PDF कन्वर्टर](https://products.aspose.app/slides/hi/conversion) को देख सकते हैं। 
{{% /alert %}}