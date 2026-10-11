---
title: जावा में नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में बदलें
linktitle: नोट्स के साथ PowerPoint से PDF
type: docs
weight: 50
url: /hi/java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
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
- नोट्स सहित PDF
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PPT और PPTX फ़ॉर्मैट को नोट्स के साथ PDF में बदलें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें।"
---
## **अवलोकन**

इस लेख में, आप Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF प्रारूप में बदलना सीखेंगे। यह मार्गदर्शिका आवश्यक चरणों को कवर करेगी और कोड उदाहरण प्रदान करेगी जिससे आप इस कार्य को कुशलता से पूरा कर सकेंगे। इस लेख के अंत तक, आप सक्षम होंगे:

- स्पीकर नोट्स को संरक्षित रखते हुए PowerPoint स्लाइड्स को PDF दस्तावेज़ों में बदलने की रूपांतरण प्रक्रिया को लागू करना।
- आउटपुट PDF को इस प्रकार कस्टमाइज़ करना कि स्पीकर नोट्स शामिल हों और आपके आवश्यकताओं के अनुसार फ़ॉर्मेट किए जाएँ।

निर्यात से पहले नोट्स पेज के आयाम और अभिविन्यास सेट करने के लिए, देखें [Notes Page Size](/slides/hi/java/notes-size/).

## **नोट्स के साथ PowerPoint को PDF में परिवर्तित करें**

`save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास में PPT या PPTX प्रस्तुति को स्पीकर नोट्स के साथ PDF में बदलने के लिए प्रयोग किया जा सकता है। Aspose.Slides के साथ, आप बस प्रस्तुति को लोड करते हैं, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्पों को कॉन्फ़िगर करते हैं ताकि स्पीकर नोट्स शामिल हों, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। निम्नलिखित कोड स्निपेट दिखाता है कि एक नमूना प्रस्तुति को नोट्स स्लाइड दृश्य में PDF में कैसे परिवर्तित किया जाए।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Configure PDF options for rendering speaker notes.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Render speaker notes below the slide.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
आप Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) देखना चाह सकते हैं।
{{% /alert %}}