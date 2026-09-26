---
title: एंड्रॉयड पर नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में परिवर्तित करें
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
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करके PPT और PPTX प्रारूपों को नोट्स के साथ PDF में परिवर्तित करें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें।"
---
## **अवलोकन**

इस लेख में, आप सीखेंगे कि Aspose.Slides का उपयोग करके स्पीकर नोट्स के साथ PowerPoint प्रस्तुतियों को PDF प्रारूप में कैसे परिवर्तित किया जाए। यह मार्गदर्शिका आवश्यक चरणों को कवर करेगी और कोड उदाहरण प्रदान करेगी जिससे आप इस कार्य को कुशलतापूर्वक पूरा कर सकें। लेख के अंत तक, आप सक्षम होंगे:

- PowerPoint स्लाइड्स को PDF दस्तावेज़ों में परिवर्तित करने की प्रक्रिया लागू करें जबकि स्पीकर नोट्स को संरक्षित रखें।
- आउटपुट PDF को अनुकूलित करें ताकि स्पीकर नोट्स आपके आवश्यकताओं के अनुसार शामिल और स्वरूपित हों।

नोट्स पेज आयाम और अभिविन्यास को निर्यात से पहले सेट करने के लिए, देखें [नोट्स पेज आकार](/slides/hi/androidjava/notes-size/)।

## **स्पीकर नोट्स के साथ PowerPoint को PDF में परिवर्तित करें**

`save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास में उपयोग करके PPT या PPTX प्रस्तुति को स्पीकर नोट्स के साथ PDF में परिवर्तित किया जा सकता है। Aspose.Slides के साथ, आप बस प्रस्तुति को लोड करते हैं, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्प कॉन्फ़िगर करते हैं ताकि स्पीकर नोट्स शामिल हों, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। निम्न कोड स्निपेट दर्शाता है कि कैसे एक नमूना प्रस्तुति को नोट्स स्लाइड व्यू में PDF में बदलें।

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

{{% alert color="info" title="Note" %}}
आप Aspose [ऑनलाइन PowerPoint से PDF कन्वरटर](https://products.aspose.app/slides/hi/conversion) देखना चाह सकते हैं।
{{% /alert %}}