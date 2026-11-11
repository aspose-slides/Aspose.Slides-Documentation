---
title: PowerPoint प्रस्तुतियों को नोट्स के साथ PDF में C++ के साथ परिवर्तित करें
linktitle: PowerPoint को नोट्स के साथ PDF में
type: docs
weight: 50
url: /hi/cpp/convert-powerpoint-to-pdf-with-notes/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PPT और PPTX फ़ॉर्मेट को नोट्स के साथ PDF में परिवर्तित करें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें।"
---
## **परिचय**

इस लेख में आप Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF प्रारूप में कैसे बदलें, यह सीखेंगे। यह गाइड आवश्यक चरणों को कवर करेगा और कोड उदाहरण प्रदान करेगा जिससे आप इस कार्य को कुशलतापूर्वक पूरा कर सकें। लेख के अंत तक आप सक्षम होंगे:

- PowerPoint स्लाइड्स को PDF दस्तावेज़ों में रूपांतरित करने की प्रक्रिया को लागू करना, जबकि स्पीकर नोट्स को संरक्षित रखना।
- आउटपुट PDF को अनुकूलित करना ताकि स्पीकर नोट्स शामिल हों और आपकी आवश्यकताओं के अनुसार स्वरूपित हों।

निर्यात से पहले नोट्स पेज के आयाम और अभिविन्यास सेट करने के लिए देखें [नोट्स पेज आकार](/slides/hi/cpp/notes-size/)।

## **नोट्स के साथ PowerPoint को PDF में परिवर्तित करें**

`Save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास में PPT या PPTX प्रस्तुति को स्पीकर नोट्स के साथ PDF में बदलने के लिए इस्तेमाल किया जा सकता है। Aspose.Slides के साथ, आप बस प्रस्तुति को लोड करें, स्पीकर नोट्स सम्मिलित करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्प कॉन्फ़िगर करें, और फिर फ़ाइल को PDF के रूप में सहेजें। निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे नमूना प्रस्तुति को नोट्स स्लाइड दृश्य में PDF में परिवर्तित किया जाए।

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// PDF विकल्पों को कॉन्फ़िगर करें ताकि स्पीकर नोट्स रेंडर हों।
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // स्लाइड के नीचे स्पीकर नोट्स रेंडर करें।
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// प्रस्तुति को स्पीकर नोट्स के साथ PDF में सहेजें।
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
आप Aspose के [ऑनलाइन PowerPoint से PDF कन्वर्टर](https://products.aspose.app/slides/hi/conversion) को देखना चाह सकते हैं।
{{% /alert %}}