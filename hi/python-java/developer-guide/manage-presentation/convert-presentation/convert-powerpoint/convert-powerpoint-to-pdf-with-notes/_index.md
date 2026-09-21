---
title: Python में नोट्स के साथ PowerPoint प्रस्तुतियों को PDF में परिवर्तित करें
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
description: "Aspose.Slides for Python via Java का उपयोग करके PPT और PPTX प्रस्तुतियों को स्पीकर नोट्स के साथ PDF में बदलें। नोट स्थान को कॉन्फ़िगर करें और लंबी नोट्स को बनाए रखें।"
---
## **अवलोकन**

यह लेख बताता है कि कैसे Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों को नोट्स के साथ PDF में बदलें। आप प्रत्येक स्लाइड के नीचे नोट्स जोड़ सकते हैं और लंबी नोट्स को अतिरिक्त पृष्ठों पर जारी रख सकते हैं। अन्य PDF निर्यात सेटिंग्स के लिए, देखें [Convert PowerPoint to PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/).

निर्यात से पहले नोट्स पृष्ठ का आकार और अभिविन्यास सेट करने के लिए, देखें [Notes Page Size](/slides/hi/python-java/notes-size/).

## **नोट्स के साथ PowerPoint को PDF में बदलें**

PPT या PPTX प्रस्तुति को PDF में निर्यात करने के लिए [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड का उपयोग करें। स्पीकर नोट्स शामिल करने के लिए, एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/) ऑब्जेक्ट बनाएं और उसके [setNotesPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) मेथड से नोट स्थान कॉन्फ़िगर करें। इस लेआउट को [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) का उपयोग करके [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) को असाइन करें।

निम्नलिखित उदाहरण `sample.pptx` को लोड करता है और इसे `output.pdf` में स्पीकर नोट्स स्लाइडों के नीचे के साथ निर्यात करता है:

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

{{% alert color="info" title="Note" %}}
आप [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hi/conversion) को भी आज़मा सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**लंबी स्पीकर नोट्स को कटने से मैं कैसे रोक सकता हूँ?**

[NotesPositions.BottomFull](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/#BottomFull) का उपयोग करें, जैसा कि उपरोक्त उदाहरण में है। यह सेटिंग पूर्ण नोट्स को दिखाती है, और आवश्यकता पड़ने पर अतिरिक्त पृष्ठों का उपयोग करती है।

**क्या मैं प्रत्येक स्लाइड और उसके नोट्स को एक ही पृष्ठ पर रख सकता हूँ?**

[NotesPositions.BottomTruncated](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/#BottomTruncated) का उपयोग करें। यह सेटिंग नोट्स को एक पृष्ठ तक सीमित करती है, इसलिए जो नोट्स फिट नहीं होते हैं वे कट सकते हैं।

**मैं स्पीकर नोट्स के बिना स्लाइड्स को कैसे निर्यात करूँ?**

नोट्स लेआउट कॉन्फ़िगरेशन को हटाएँ और [Convert PowerPoint to PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/) में वर्णित मानक PDF निर्यात का उपयोग करें।