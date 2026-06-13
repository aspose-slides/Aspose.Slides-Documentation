---
title: PHP में नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में बदलें
linktitle: PowerPoint को नोट्स के साथ PDF में बदलें
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
description: "Aspose.Slides for PHP via Java का उपयोग करके PPT और PPTX स्वरूपों को नोट्स के साथ PDF में बदलें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें।"
---
## **अवलोकन**

इस लेख में आप सीखेंगे कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF प्रारूप में कैसे बदलें। यह गाइड आवश्यक चरणों को कवर करेगा और कोड उदाहरण प्रदान करेगा ताकि आप इस कार्य को प्रभावी ढंग से पूरा कर सकें। लेख के समाप्ति तक, आप सक्षम होंगे:

- PowerPoint स्लाइड्स को PDF दस्तावेज़ में बदलने के लिए परिवर्तन प्रक्रिया को लागू करना, जबकि स्पीकर नोट्स को संरक्षित रखना।
- आउटपुट PDF को अनुकूलित करना ताकि स्पीकर नोट्स शामिल हों और आपके आवश्यकताओं के अनुसार स्वरूपित हों।

## **स्पीकर नोट्स के साथ PowerPoint को PDF में बदलें**

`save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास में उपयोग करके आप PPT या PPTX प्रस्तुति को स्पीकर नोट्स के साथ PDF में बदल सकते हैं। Aspose.Slides के साथ, आप प्रस्तुति को लोड करते हैं, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्पों को कॉन्फ़िगर करके स्पीकर नोट्स शामिल करते हैं, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे एक नमूना प्रस्तुति को नोट्स स्लाइड दृश्य में PDF में बदला जाए।

```php
$presentation = new Presentation("sample.pptx");

// स्पीकर नोट्स को रेंडर करने के लिए PDF विकल्प कॉन्फ़िगर करें।
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // स्लाइड के नीचे स्पीकर नोट्स रेंडर करें।

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Save the presentation to PDF with speaker notes.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 

आप Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) को देख सकते हैं। 

{{% /alert %}}