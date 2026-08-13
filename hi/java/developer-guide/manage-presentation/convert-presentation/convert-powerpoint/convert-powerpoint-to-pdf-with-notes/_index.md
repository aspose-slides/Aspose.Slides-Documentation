---
title: Java में नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में परिवर्तित करें
linktitle: नोट्स के साथ PowerPoint से PDF
type: docs
weight: 50
url: /hi/java/convert-powerpoint-to-pdf-with-notes/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PPT और PPTX फ़ॉर्मेट को नोट्स के साथ PDF में बदलें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें।"
---
## **सारांश**

इस लेख में आप सीखेंगे कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को speaker notes के साथ PDF फ़ॉर्मेट में कैसे बदलें। यह गाइड आवश्यक चरणों को कवर करेगा और कार्य को कुशलता से पूरा करने में मदद करने के लिए कोड उदाहरण प्रदान करेगा। इस लेख के अंत तक आप सक्षम होंगे:

- PowerPoint स्लाइड्स को PDF दस्तावेज़ में बदलने की प्रक्रिया को लागू करने के लिए, जबकि speaker notes को संरक्षित रखा जाए।
- आउटपुट PDF को अनुकूलित करने के लिए ताकि speaker notes आपके आवश्यकतानुसार शामिल और स्वरूपित हों।

## **PowerPoint को नोट्स सहित PDF में परिवर्तित करें**

`save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास में उपयोग करके PPT या PPTX प्रस्तुति को speaker notes के साथ PDF में बदला जा सकता है। Aspose.Slides के साथ, आप बस प्रस्तुति को लोड करते हैं, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्प कॉन्फ़िगर करते हैं ताकि speaker notes शामिल हों, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे नमूना प्रस्तुति को Notes Slide दृश्य में PDF में परिवर्तित किया जाए।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// स्पीकर नोट्स को रेंडर करने के लिए PDF विकल्प कॉन्फ़िगर करें।
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // स्लाइड के नीचे स्पीकर नोट्स रेंडर करें।

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 
आप Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) को देख सकते हैं। 
{{% /alert %}}