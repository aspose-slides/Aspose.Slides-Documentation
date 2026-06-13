---
title: जावा स्क्रिप्ट में नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में बदलें
linktitle: नोट्स के साथ PowerPoint से PDF
type: docs
weight: 50
url: /hi/nodejs-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint बदलें
- प्रेजेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से PDF
- प्रेजेंटेशन से PDF
- स्लाइड से PDF
- PPT से PDF
- PPTX से PDF
- प्रेजेंटेशन को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- स्पीकर नोट्स
- नोट्स के साथ PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "जावा स्क्रिप्ट में Aspose.Slides for Node.js का उपयोग करके PPT और PPTX फ़ॉर्मेट को नोट्स के साथ PDF में बदलें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें।"
---
## **सारांश**

इस लेख में, आप Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF प्रारूप में बदलना सीखेंगे। यह मार्गदर्शिका आवश्यक चरणों को कवर करेगी और कोड उदाहरण प्रदान करेगी जिससे आप इस कार्य को प्रभावी रूप से पूरा कर सकें। इस लेख के अंत में, आप सक्षम होंगे:

- स्पीकर नोट्स को संरक्षित रखते हुए PowerPoint स्लाइड्स को PDF दस्तावेज़ों में परिवर्तित करने की प्रक्रिया को लागू करना।
- आउटपुट PDF को अनुकूलित करना ताकि स्पीकर नोट्स शामिल हों और आपकी आवश्यकताओं के अनुसार स्वरूपित हों।

## **नोट्स के साथ PowerPoint को PDF में परिवर्तित करें**

`save` विधि को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) वर्ग में उपयोग करके PPT या PPTX प्रस्तुति को स्पीकर नोट्स के साथ PDF में परिवर्तित किया जा सकता है। Aspose.Slides के साथ, आप बस प्रस्तुति लोड करते हैं, स्पीकर नोट्स शामिल करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) वर्ग का उपयोग करके लेआउट विकल्प कॉन्फ़िगर करते हैं, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे एक नमूना प्रस्तुति को नोट्स स्लाइड व्यू में PDF में बदलें।

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// स्पीकर नोट्स को रेंडर करने के लिए PDF विकल्प कॉन्फ़िगर करें।
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // स्लाइड के नीचे स्पीकर नोट्स रेंडर करें।

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// स्पीकर नोट्स के साथ प्रस्तुति को PDF में सहेजें।
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
आप Aspose के [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) को देखना चाह सकते हैं। 
{{% /alert %}}