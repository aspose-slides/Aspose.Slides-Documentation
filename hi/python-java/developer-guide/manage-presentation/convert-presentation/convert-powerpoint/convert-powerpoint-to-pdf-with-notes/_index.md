---
title: Python में नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में बदलें
linktitle: नोट्स के साथ PowerPoint से PDF
type: docs
weight: 50
url: /hi/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- PPT को बदलें
- PPTX को बदलें
- PowerPoint से PDF
- प्रस्तुति से PDF
- PPT से PDF
- PPTX से PDF
- प्रस्तुति को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- स्पीकर नोट्स
- नोट्स के साथ PDF
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PPT और PPTX प्रस्तुतियों को स्पीकर नोट्स के साथ PDF में बदलें। नोट की स्थिति कॉन्फ़िगर करें और लंबी नोट्स को संरक्षित रखें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF में परिवर्तित करने का तरीका बताता है। आप प्रत्येक स्लाइड के नीचे नोट्स शामिल कर सकते हैं और लंबे नोट्स को अतिरिक्त पृष्ठों पर जारी रखने की अनुमति दे सकते हैं। अन्य PDF निर्यात सेटिंग्स के लिए, देखें [PowerPoint को PDF में परिवर्तित करें](/slides/hi/python-java/convert-powerpoint-to-pdf/)।

## **PowerPoint को नोट्स के साथ PDF में परिवर्तित करें**

PDF में PPT या PPTX प्रस्तुति निर्यात करने के लिए [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) विधि का उपयोग करें। स्पीकर नोट्स शामिल करने के लिए, एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/) ऑब्जेक्ट बनाएँ और उसकी [setNotesPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) विधि से नोट की स्थिति कॉन्फ़िगर करें। इस लेआउट को [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) में [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) का उपयोग करके असाइन करें।

निम्नलिखित उदाहरण `sample.pptx` को लोड करता है और इसे `output.pdf` में स्पीकर नोट्स स्लाइड के नीचे के साथ निर्यात करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # स्पीकर नोट्स को रेंडर करने के लिए PDF विकल्प कॉन्फ़िगर करें।
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # स्पीकर नोट्स के साथ प्रस्तुति को PDF में सहेजें।
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="ध्यान दें" %}}
आप ऑनलाइन PowerPoint से PDF रूपांतरणकर्ता भी आज़मा सकते हैं: [ऑनलाइन PowerPoint से PDF रूपांतरणकर्ता](https://products.aspose.app/slides/hi/conversion)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**लंबे स्पीकर नोट्स को कट होने से कैसे रोकें?**

उपरोक्त उदाहरण की तरह [NotesPositions.BottomFull](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/#BottomFull) का उपयोग करें। यह सेटिंग पूरी नोट्स को दिखाती है, और आवश्यकता पड़ने पर अतिरिक्त पृष्ठों का उपयोग करती है।

**क्या मैं प्रत्येक स्लाइड और उसके नोट्स को एक ही पृष्ठ पर रख सकता हूँ?**

[NotesPositions.BottomTruncated](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/#BottomTruncated) का उपयोग करें। यह सेटिंग नोट्स को एक पृष्ठ तक सीमित कर देती है, इसलिए जो नोट्स फिट नहीं होते, उन्हें काट दिया जाता है।

**स्पीकर नोट्स के बिना स्लाइड्स को कैसे निर्यात करें?**

नोट लेआउट कॉन्फ़िगरेशन को छोड़ दें और [PowerPoint को PDF में परिवर्तित करें](/slides/hi/python-java/convert-powerpoint-to-pdf/) में वर्णित मानक PDF निर्यात का उपयोग करें।