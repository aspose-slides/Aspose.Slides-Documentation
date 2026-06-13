---
title: Android पर नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में परिवर्तित करें
linktitle: PowerPoint को नोट्स के साथ PDF में
type: docs
weight: 50
url: /hi/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करके PPT और PPTX फ़ॉर्मेट को नोट्स के साथ PDF में बदलें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें।"
---
## **सारांश**

इस लेख में आप Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF प्रारूप में बदलना सीखेंगे। यह गाइड आवश्यक चरणों को कवर करता है और कोड उदाहरण प्रदान करता है जिससे आप यह कार्य कुशलता से कर सकें। लेख के अंत तक आप सक्षम होंगे:

- PowerPoint स्लाइड्स को PDF दस्तावेज़ में परिवर्तित करने की प्रक्रिया को लागू करना, जबकि स्पीकर नोट्स को संरक्षित रखा जाए।
- आउटपुट PDF को अनुकूलित करना ताकि स्पीकर नोट्स आपके आवश्यकताओं के अनुसार शामिल और फॉर्मेट किए जा सकें।

## **नोट्स के साथ PowerPoint को PDF में बदलें**

`save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास में उपयोग करके PPT या PPTX प्रस्तुतियों को स्पीकर नोट्स के साथ PDF में बदला जा सकता है। Aspose.Slides के साथ, आप बस प्रस्तुति को लोड करें, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्पों को कॉन्फ़िगर करें ताकि स्पीकर नोट्स शामिल हों, और फिर फ़ाइल को PDF के रूप में सेव करें। निम्नलिखित कोड स्निपेट दिखाता है कि कैसे एक नमूना प्रस्तुति को नोट्स स्लाइड व्यू में PDF में परिवर्तित किया जाए।

```java
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

{{% alert color="primary" %}} 

आप Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) को देखना चाह सकते हैं। 

{{% /alert %}}