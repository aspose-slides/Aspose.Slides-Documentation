---
title: ".NET में नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में बदलें"
linktitle: "नोट्स के साथ PowerPoint से PDF"
type: docs
weight: 50
url: /hi/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- "PowerPoint को बदलें"
- "प्रस्तुति को बदलें"
- "स्लाइड को बदलें"
- "PPT को बदलें"
- "PPTX को बदलें"
- "PowerPoint से PDF"
- "प्रस्तुति से PDF"
- "स्लाइड से PDF"
- "PPT से PDF"
- "PPTX से PDF"
- "प्रस्तुति को PDF के रूप में सहेजें"
- "PPT को PDF के रूप में सहेजें"
- "PPTX को PDF के रूप में सहेजें"
- "PPT को PDF में निर्यात करें"
- "PPTX को PDF में निर्यात करें"
- "स्पीकर नोट्स"
- "नोट्स के साथ PDF"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET का उपयोग करके PPT और PPTX फ़ॉर्मेट को नोट्स के साथ PDF में बदलें। लेआउट और स्पीकर नोट्स को संरक्षित रखें ताकि पेशेवर प्रस्तुतियों को सुनिश्चित किया जा सके।"
---
## **अवलोकन**

इस लेख में, आप Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को नोट्स के साथ PDF प्रारूप में बदलना सीखेंगे। यह गाइड आवश्यक कदमों को कवर करेगा और कोड उदाहरण प्रदान करेगा ताकि आप इस कार्य को कुशलतापूर्वक पूरा कर सकें। लेख के अंत में, आप सक्षम होंगे:

- PowerPoint स्लाइड्स को PDF दस्तावेज़ों में परिवर्तित करने की प्रक्रिया लागू करें, जबकि स्पीकर नोट्स को संरक्षित रखें।
- आउटपुट PDF को इस प्रकार कस्टमाइज़ करें कि स्पीकर नोट्स शामिल हों और आपके आवश्यकताओं के अनुसार स्वरूपित हों।

## **PowerPoint को नोट्स के साथ PDF में परिवर्तित करें**

`Presentation` वर्ग में `Save` मेथड का उपयोग करके PPT या PPTX प्रस्तुति को स्पीकर नोट्स के साथ PDF में परिवर्तित किया जा सकता है। Aspose.Slides के साथ, आप बस प्रस्तुति को लोड करते हैं, स्पीकर नोट्स को शामिल करने के लिए `[NotesCommentsLayoutingOptions]` क्लास का उपयोग करके लेआउट विकल्प कॉन्फ़िगर करते हैं, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। नीचे दिया गया कोड स्निपेट दर्शाता है कि कैसे एक नमूना प्रस्तुति को नोट्स स्लाइड दृश्य में PDF में परिवर्तित किया जाए।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert color="info" %}} 
आप Aspose का [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) देखना चाह सकते हैं। 
{{% /alert %}}