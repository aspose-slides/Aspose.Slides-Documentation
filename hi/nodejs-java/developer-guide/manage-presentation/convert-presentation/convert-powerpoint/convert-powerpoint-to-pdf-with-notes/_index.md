---
title: JavaScript में नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में परिवर्तित करें
linktitle: PowerPoint को नोट्स के साथ PDF में बदलें
type: docs
weight: 50
url: /hi/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके JavaScript में PPT और PPTX फ़ाइलों को नोट्स के साथ PDF में परिवर्तित करें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें।"
---
## **परिचय**

इस लेख में आप Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF प्रारूप में बदलना सीखेंगे। यह गाइड आवश्यक चरणों को कवर करता है और कार्य को कुशलतापूर्वक पूरा करने के लिए कोड उदाहरण प्रदान करता है। लेख के अंत तक, आप सक्षम होंगे:

- PowerPoint स्लाइड्स को PDF दस्तावेज़ों में परिवर्तित करने की प्रक्रिया को लागू करना, जबकि स्पीकर नोट्स को संरक्षित रखा जाए।
- आउटपुट PDF को अनुकूलित करना ताकि स्पीकर नोट्स आपके आवश्यकताओं के अनुसार शामिल और स्वरूपित हों।

निर्यात से पहले नोट्स पेज के आयाम और अभिविन्यास सेट करने के लिए, देखें [नोट्स पेज आकार](/slides/hi/nodejs-java/notes-size/)।

## **स्पीकर नोट्स के साथ PowerPoint को PDF में बदलें**

`save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास में उपयोग करके PPT या PPTX प्रस्तुति को स्पीकर नोट्स के साथ PDF में बदला जा सकता है। Aspose.Slides के साथ, आप बस प्रस्तुति लोड करते हैं, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्प कॉन्फ़िगर करते हैं ताकि स्पीकर नोट्स शामिल हों, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे एक नमूना प्रस्तुति को नोट्स स्लाइड व्यू में PDF में बदला जाए।

```js
const asposeSlides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Note" %}}

आप Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) को देखना चाह सकते हैं।

{{% /alert %}}