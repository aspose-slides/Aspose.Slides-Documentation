---
title: Python में नोट्स के साथ प्रस्तुतियों को PDF में बदलें
linktitle: नोट्स के साथ प्रस्तुति को PDF में बदलें
type: docs
weight: 50
url: /hi/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint को बदलें
- OpenDocument को बदलें
- प्रस्तुति को बदलें
- PPT को बदलें
- PPTX को बदलें
- ODP को बदलें
- PowerPoint से PDF
- OpenDocument से PDF
- प्रस्तुति से PDF
- PPT से PDF
- PPTX से PDF
- ODP से PDF
- स्पीकर नोट्स
- नोट्स के साथ PDF
- Python
- Aspose.Slides
description: "Aspose.Slides for Python का उपयोग करके PPT, PPTX और ODP फ़ॉर्मेट को नोट्स के साथ PDF में बदलें। पेशेवर प्रस्तुतियों के लिए लेआउट और स्पीकर नोट्स को संरक्षित रखें।"
---
## **अवलोकन**

इस लेख में, आप Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF फॉर्मेट में परिवर्तित करना सीखेंगे। यह गाइड आवश्यक चरणों को कवर करेगा और कोड उदाहरण प्रदान करेगा जिससे आप इस कार्य को कुशलता से पूरा कर सकें। लेख के अंत तक, आप सक्षम होंगे:

- परिवर्तन प्रक्रिया को लागू करके PowerPoint स्लाइड्स को PDF दस्तावेज़ में बदलना, जबकि स्पीकर नोट्स को संरक्षित रखना।
- आउटपुट PDF को इस तरह कस्टमाइज़ करना कि स्पीकर नोट्स आपके आवश्यकताओं के अनुसार शामिल और फ़ॉर्मेटेड हों।

## **PowerPoint को नोट्स के साथ PDF में बदलें**

`save` मेथड को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास में उपयोग करके PPT या PPTX प्रस्तुतियों को स्पीकर नोट्स के साथ PDF में बदला जा सकता है। Aspose.Slides के साथ, आप बस प्रस्तुति लोड करें, स्पीकर नोट्स शामिल करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notescommentslayoutingoptions/) क्लास का उपयोग करके लेआउट विकल्प कॉन्फ़िगर करें, और फिर फ़ाइल को PDF के रूप में सहेजें। नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे एक नमूना प्रस्तुति को नोट्स स्लाइड व्यू में PDF में बदलें।

```py
with slides.Presentation("sample.pptx") as presentation:

    # स्पीकर नोट्स को रेंडर करने के लिए PDF विकल्प कॉन्फ़िगर करें।
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # स्पीकर नोट्स के साथ प्रस्तुति को PDF में सहेजें।
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 
आप Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) को देख सकते हैं। 
{{% /alert %}}