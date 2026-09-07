---
title: Python में नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में परिवर्तित करें
linktitle: PowerPoint को नोट्स के साथ PDF में
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
description: "Aspose.Slides for Python via Java का उपयोग करके PPT और PPTX प्रस्तुतियों को स्पीकर नोट्स के साथ PDF में बदलें। नोट्स की स्थिति को कॉन्फ़िगर करें और लंबी नोट्स को संरक्षित रखें।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों को स्पीकर नोट्स के साथ PDF में कैसे बदलें। आप प्रत्येक स्लाइड के नीचे नोट्स शामिल कर सकते हैं और लंबी नोट्स को अतिरिक्त पृष्ठों पर जारी रख सकते हैं। अन्य PDF निर्यात सेटिंग्स के लिए, देखें [PowerPoint को PDF में परिवर्तित करें](/slides/hi/python-java/convert-powerpoint-to-pdf/)।

## **PowerPoint को PDF में नोट्स के साथ परिवर्तित करें**

PPT या PPTX प्रस्तुति को PDF में निर्यात करने के लिए [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) विधि का उपयोग करें। स्पीकर नोट्स शामिल करने के लिए, एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/) ऑब्जेक्ट बनाएं और उसकी [setNotesPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) विधि को कॉन्फ़िगर करें। इस लेआउट को [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) में [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) का उपयोग करके असाइन करें।

निम्न उदाहरण `sample.pptx` को लोड करता है और इसे `output.pdf` में स्पीकर नोट्स स्लाइड्स के नीचे के साथ निर्यात करता है:

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

{{% alert color="info" title="नोट" %}}
आप भी [ऑनलाइन PowerPoint को PDF रूपांतरणकर्ता](https://products.aspose.app/slides/hi/conversion) आज़मा सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**लंबी स्पीकर नोट्स को कटने से कैसे रोकें?**

उपरोक्त उदाहरण की तरह [NotesPositions.BottomFull](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/#BottomFull) का उपयोग करें। यह सेटिंग पूरी नोट्स दिखाती है, आवश्यकतानुसार अतिरिक्त पृष्ठों का उपयोग करती है।

**क्या मैं प्रत्येक स्लाइड और उसके नोट्स को एक ही पृष्ठ पर रख सकता हूँ?**

[NotesPositions.BottomTruncated](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/#BottomTruncated) का उपयोग करें। यह सेटिंग नोट्स को एक पृष्ठ तक सीमित करती है, इसलिए जो नोट्स फिट नहीं होते हैं वे काटे जा सकते हैं।

**स्पीकर नोट्स के बिना स्लाइड्स को कैसे निर्यात करें?**

नोट्स लेआउट कॉन्फ़िगरेशन को छोड़ें और [PowerPoint को PDF में परिवर्तित करें](/slides/hi/python-java/convert-powerpoint-to-pdf/) में वर्णित मानक PDF निर्यात का उपयोग करें।