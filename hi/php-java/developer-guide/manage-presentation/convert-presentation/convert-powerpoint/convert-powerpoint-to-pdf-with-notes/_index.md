---
title: PowerPoint प्रस्तुतियों को नोट्स के साथ PDF में बदलें PHP में
linktitle: PowerPoint को नोट्स के साथ PDF में
type: docs
weight: 50
url: /hi/php-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके नोट्स के साथ PPT और PPTX को PDF में बदलें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें।"
---
## **अवलोकन**

इस लेख में, आप Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को नोट्स के साथ PDF प्रारूप में कैसे परिवर्तित किया जाए, सीखेंगे। यह गाइड आवश्यक चरणों को कवर करता है और कोड उदाहरण प्रदान करता है ताकि आप यह कार्य कुशलता से पूरा कर सकें। इस लेख के अंत तक, आप सक्षम होंगे:

- PowerPoint स्लाइड्स को PDF दस्तावेज़ों में बदलने की प्रक्रिया को लागू करना, जबकि स्पीकर नोट्स को संरक्षित रखना।
- आउटपुट PDF को अनुकूलित करना ताकि नोट्स शामिल हों और आपकी आवश्यकताओं के अनुसार स्वरूपित हों।

निर्यात से पहले नोट्स पेज के आयाम और अभिविन्यास सेट करने के लिए, देखें [Notes Page Size](/slides/hi/php-java/notes-size/)।

## **नोट्स के साथ PowerPoint को PDF में परिवर्तित करें**

`save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास में उपयोग करके PPT या PPTX प्रस्तुति को नोट्स के साथ PDF में बदला जा सकता है। Aspose.Slides के साथ, आप बस प्रस्तुति को लोड करते हैं, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्पों को कॉन्फ़िगर करते हैं ताकि स्पीकर नोट्स शामिल हों, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। निम्नलिखित कोड स्निपेट दर्शाता है कि नोट्स स्लाइड व्यू में नमूना प्रस्तुति को PDF में कैसे परिवर्तित किया जाए।

```php
$presentation = new Presentation("sample.pptx");

// स्पीकर नोट्स रेंडर करने के लिए PDF विकल्प कॉन्फ़िगर करें।
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // स्लाइड के नीचे स्पीकर नोट्स रेंडर करें।

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// स्पीकर नोट्स के साथ प्रस्तुति को PDF में सहेजें।
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}
आप Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) को देखना चाह सकते हैं।
{{% /alert %}}