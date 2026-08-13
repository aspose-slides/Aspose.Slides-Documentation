---
title: C++ में नोट्स सहित PowerPoint प्रस्तुतियों को PDF में बदलें
linktitle: नोट्स के साथ PowerPoint को PDF में बदलें
type: docs
weight: 50
url: /hi/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint रूपांतरण
- प्रेजेंटेशन रूपांतरण
- स्लाइड रूपांतरण
- PPT रूपांतरण
- PPTX रूपांतरण
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
description: "Aspose.Slides for C++ का उपयोग करके PPT और PPTX फ़ॉर्मेट को नोट्स के साथ PDF में बदलें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को सुरक्षित रखें।"
---
## **अवलोकन**

इस लेख में, आप Aspose.Slides का उपयोग करके स्पीकर नोट्स के साथ PowerPoint प्रस्तुतियों को PDF स्वरूप में बदलना सीखेंगे। यह गाइड आवश्यक चरणों को कवर करेगा और कोड उदाहरण प्रदान करेगा जिससे आप इस कार्य को कुशलतापूर्वक पूरा कर सकें। लेख के अंत तक, आप सक्षम होंगे:

- PowerPoint स्लाइड्स को PDF दस्तावेज़ में बदलने की प्रक्रिया को लागू करना, जबकि स्पीकर नोट्स को संरक्षित रखना।
- आउटपुट PDF को इस प्रकार अनुकूलित करना कि स्पीकर नोट्स शामिल हों और आपकी आवश्यकतानुसार स्वरूपित हों।

## **PowerPoint को नोट्स के साथ PDF में परिवर्तित करें**

`Save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास में उपयोग करके PPT या PPTX प्रस्तुति को स्पीकर नोट्स के साथ PDF में बदला जा सकता है। Aspose.Slides के साथ, आप केवल प्रस्तुति को लोड करते हैं, [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्प कॉन्फ़िगर करते हैं ताकि स्पीकर नोट्स शामिल हों, और फिर फ़ाइल को PDF के रूप में सहेजते हैं। निम्नलिखित कोड स्निपेट दर्शाता है कि नमूना प्रस्तुति को नोट्स स्लाइड व्यू में PDF में कैसे बदलें।

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

// स्पीकर नोट्स के रेंडरिंग के लिए PDF विकल्प कॉन्फ़िगर करें।
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // स्लाइड के नीचे स्पीकर नोट्स रेंडर करें.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// स्पीकर नोट्स के साथ प्रस्तुति को PDF में सहेजें।
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
आप Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) को देखना चाहेंगे। 
{{% /alert %}}