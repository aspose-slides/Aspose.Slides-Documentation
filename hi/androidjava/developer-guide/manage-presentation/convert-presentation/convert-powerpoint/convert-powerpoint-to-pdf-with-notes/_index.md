---
title: Android पर नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में बदलें
linktitle: नोट्स के साथ PowerPoint से PDF
type: docs
weight: 50
url: /hi/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- नोट्स के साथ PDF
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करके PPT और PPTX स्वरूपों को नोट्स के साथ PDF में बदलें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें।"
---
## **अवलोकन**

इस लेख में, आप Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF प्रारूप में परिवर्तित करना सीखेंगे। यह गाइड आवश्यक चरणों को कवर करेगा और कोड उदाहरण प्रदान करेगा ताकि आप इस कार्य को कुशलतापूर्वक पूरा कर सकें। लेख के अंत तक, आप सक्षम होंगे:

- स्पीकर नोट्स को संरक्षित रखते हुए PowerPoint स्लाइड्स को PDF दस्तावेज़ में रूपांतरित करने की प्रक्रिया को लागू करें।
- आउटपुट PDF को कस्टमाइज़ करें ताकि स्पीकर नोट्स शामिल हों और आपके आवश्यकतानुसार फॉर्मेट किए जाएँ।

## **स्पीकर नोट्स के साथ PowerPoint को PDF में बदलें**

`save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास में उपयोग करके PPT या PPTX प्रस्तुति को स्पीकर नोट्स के साथ PDF में परिवर्तित किया जा सकता है। Aspose.Slides के साथ, आप बस प्रस्तुति को लोड करते हैं, स्पीकर नोट्स शामिल करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्प कॉन्फ़िगर करते हैं, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। निम्नलिखित कोड स्निपेट एक नमूना प्रस्तुति को नोट्स स्लाइड व्यू में PDF में बदलने का प्रदर्शन करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// स्पीकर नोट्स को रेंडर करने के लिए PDF विकल्प कॉन्फ़िगर करें।
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // स्लाइड के नीचे स्पीकर नोट्स रेंडर करें।

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// स्पीकर नोट्स के साथ प्रस्तुति को PDF में सहेजें।
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 
आप Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) को देखना चाह सकते हैं। 
{{% /alert %}}