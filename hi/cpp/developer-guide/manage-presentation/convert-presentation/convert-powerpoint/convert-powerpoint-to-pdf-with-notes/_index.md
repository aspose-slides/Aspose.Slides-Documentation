---
title: स्पीकर नोट्स के साथ C++ में PowerPoint प्रस्तुतियों को PDF में परिवर्तित करें
linktitle: PowerPoint को नोट्स के साथ PDF में
type: docs
weight: 50
url: /hi/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint को परिवर्तित करें
- प्रेज़ेंटेशन को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- PowerPoint को PDF में
- प्रेज़ेंटेशन को PDF में
- स्लाइड को PDF में
- PPT को PDF में
- PPTX को PDF में
- प्रेज़ेंटेशन को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में एक्सपोर्ट करें
- PPTX को PDF में एक्सपोर्ट करें
- स्पीकर नोट्स
- नोट्स के साथ PDF
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PPT और PPTX फ़ॉर्मैट को नोट्स के साथ PDF में परिवर्तित करें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को सुरक्षित रखें।"
---
## **परिचय**

इस लेख में, आप Aspose.Slides का उपयोग करके पॉवरपॉइंट प्रस्तुतियों को स्पीकर नोट्स के साथ PDF फ़ॉर्मेट में कनवर्ट करना सीखेंगे। यह गाइड आवश्यक चरणों को कवर करेगा और कोड उदाहरण प्रदान करेगा जिससे आप इस कार्य को प्रभावी रूप से पूरा कर सकेंगे। लेख के अंत तक, आप सक्षम होंगे:

- स्पीकर नोट्स को संरक्षित रखते हुए पॉवरपॉइंट स्लाइड्स को PDF दस्तावेज़ों में परिवर्तित करने की प्रक्रिया को लागू करना।
- आउटपुट PDF को कस्टमाइज़ करना ताकि स्पीकर नोट्स शामिल हों और आपकी आवश्यकताओं के अनुसार फ़ॉर्मेट किए जाएँ।

## **नोट्स के साथ PowerPoint को PDF में परिवर्तित करें**

`Save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास में उपयोग करके PPT या PPTX प्रस्तुतियों को स्पीकर नोट्स के साथ PDF में बदला जा सकता है। Aspose.Slides के साथ, आप केवल प्रस्तुति को लोड करते हैं, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्प कॉन्फ़िगर करके स्पीकर नोट्स शामिल करते हैं, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे एक नमूना प्रस्तुति को नोट्स स्लाइड व्यू में PDF में बदलें।

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// स्पीकर नोट्स के रेंडरिंग के लिए PDF विकल्प कॉन्फ़िगर करें।
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // स्लाइड के नीचे स्पीकर नोट्स रेंडर करें.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// स्पीकर नोट्स के साथ प्रस्तुति को PDF में सहेजें.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 
आप Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) को देख सकते हैं। 
{{% /alert %}}