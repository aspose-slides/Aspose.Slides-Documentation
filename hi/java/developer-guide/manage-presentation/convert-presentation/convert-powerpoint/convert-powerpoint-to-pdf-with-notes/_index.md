---
title: Java में नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में परिवर्तित करें
linktitle: नोट्स के साथ PowerPoint से PDF
type: docs
weight: 50
url: /hi/java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint को बदलें
- प्रेज़ेंटेशन को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
- PowerPoint से PDF
- प्रेज़ेंटेशन को PDF
- स्लाइड को PDF
- PPT को PDF
- PPTX को PDF
- प्रेज़ेंटेशन को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- स्पीकर नोट्स
- नोट्स के साथ PDF
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PPT और PPTX फॉर्मैट को नोट्स के साथ PDF में परिवर्तित करें। पेशेवर प्रस्तुतियों के लिए लेआउट्स और स्पीकर नोट्स को संरक्षित रखें।"
---
## **समीक्षा**

इस लेख में, आप Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF प्रारूप में बदलना सीखेंगे। यह गाइड आवश्यक चरणों को कवर करेगा और कोड उदाहरण प्रदान करेगा ताकि आप इस कार्य को प्रभावी रूप से पूरा कर सकें। लेख के अंत तक आप सक्षम होंगे:

- PowerPoint स्लाइड्स को PDF दस्तावेज़ों में परिवर्तित करने की प्रक्रिया को लागू करना तथा स्पीकर नोट्स को संरक्षित रखना।
- आउटपुट PDF को कस्टमाइज़ करना ताकि स्पीकर नोट्स शामिल हों और आपकी आवश्यकताओं के अनुसार स्वरूपित हों।

## **PowerPoint को नोट्स के साथ PDF में परिवर्तित करें**

`save` मेथड, जो [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास में है, का उपयोग PPT या PPTX प्रेज़ेंटेशन को स्पीकर नोट्स के साथ PDF में बदलने के लिए किया जा सकता है। Aspose.Slides के साथ, आप बस प्रेज़ेंटेशन लोड करते हैं, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्प कॉन्फ़िगर करते हैं ताकि स्पीकर नोट्स शामिल हों, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे एक नमूना प्रेज़ेंटेशन को नोट्स स्लाइड व्यू में PDF में परिवर्तित किया जाए।

```java
Presentation presentation = new Presentation("sample.pptx");

// स्पीकर नोट्स को रेंडर करने के लिए PDF विकल्प कॉन्फ़िगर करें।
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // स्लाइड के नीचे स्पीकर नोट्स रेंडर करें।

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// स्पीकर नोट्स के साथ प्रस्तुति को PDF में सहेजें।
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
आप Aspose [ऑनलाइन PowerPoint से PDF कनवर्टर](https://products.aspose.app/slides/hi/conversion) को देखना चाहेंगे। 
{{% /alert %}}