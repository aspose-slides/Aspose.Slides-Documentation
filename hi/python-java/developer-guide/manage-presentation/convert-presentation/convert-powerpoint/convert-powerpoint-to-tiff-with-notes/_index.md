---
title: "Python में नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें"
linktitle: "PowerPoint से TIFF नोट्स के साथ"
type: docs
weight: 100
url: /hi/python-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- "PowerPoint परिवर्तित करें"
- "प्रस्तुति परिवर्तित करें"
- "स्लाइड परिवर्तित करें"
- "PPT परिवर्तित करें"
- "PPTX परिवर्तित करें"
- "PowerPoint से TIFF"
- "प्रस्तुति से TIFF"
- "स्लाइड से TIFF"
- "PPT से TIFF"
- "PPTX से TIFF"
- "PPT को TIFF के रूप में सहेजें"
- "PPTX को TIFF के रूप में सहेजें"
- "PPT को TIFF में निर्यात करें"
- "PPTX को TIFF में निर्यात करें"
- "नोट्स के साथ PowerPoint"
- "नोट्स के साथ प्रस्तुति"
- "नोट्स के साथ स्लाइड"
- "नोट्स के साथ PPT"
- "नोट्स के साथ PPTX"
- "नोट्स के साथ TIFF"
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें। स्लाइड्स को स्पीकर नोट्स के साथ कुशलतापूर्वक निर्यात करना सीखें।"
---
## **परिचय**

Aspose.Slides for Python via Java एक सरल समाधान प्रदान करता है जिससे PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, और ODP) को नोट्स के साथ TIFF प्रारूप में परिवर्तित किया जा सकता है। यह प्रारूप उच्च‑गुणवत्ता वाली छवि संग्रह, प्रिंटिंग और दस्तावेज़ अभिलेख के लिए व्यापक रूप से उपयोग किया जाता है। एक ही बहु‑पृष्ठ TIFF फ़ाइल में स्लाइड्स और उनके स्पीकर नोट्स निर्यात करने के लिए [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) विधि का उपयोग करें।

## **नोट्स के साथ प्रस्तुति को TIFF में बदलें**

Aspose.Slides for Python via Java का उपयोग करके नोट्स के साथ PowerPoint या OpenDocument प्रस्तुति को TIFF में सहेजने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं: PowerPoint या OpenDocument फ़ाइल लोड करें।
1. आउटपुट लेआउट विकल्प कॉन्फ़िगर करें: नोट्स और टिप्पणियों को कैसे प्रदर्शित किया जाए, इसे निर्दिष्ट करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करें।
1. प्रस्तुति को TIFF में सहेजें: कॉन्फ़िगर किए गए विकल्पों को [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) विधि में पास करें।

मान लीजिए हमारे पास "speaker_notes.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![स्पीकर नोट्स वाली प्रस्तुति स्लाइड](slide_with_notes.png)

नीचे दिया गया कोड स्निपेट नोट्स स्लाइड दृश्य में प्रस्तुति को TIFF छवि में परिवर्तित करने के लिए [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) विधि का उपयोग दर्शाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # प्रत्येक स्लाइड के नीचे पूर्ण स्पीकर नोट्स प्रदर्शित करें।
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # TIFF रिज़ॉल्यूशन और नोट्स लेआउट को कॉन्फ़िगर करें।
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # स्पीकर नोट्स के साथ प्रस्तुति को TIFF में सहेजें।
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

परिणाम:

![नोट्स के साथ TIFF छवि](TIFF_with_notes.png)

{{% alert title="सलाह" color="success" %}}

Aspose के [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं उत्पन्न TIFF में नोट्स क्षेत्र की स्थिति नियंत्रित कर सकता हूँ?**

हाँ। नोट्स को एक पृष्ठ पर फिट करने के लिए (संभवतः उन्हें छोटा करके) [setNotesPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) को [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/#BottomTruncated) के साथ कॉन्फ़िगर करें, या सभी नोट्स को अतिरिक्त पृष्ठों पर दिखाने के लिए आवश्यकता अनुसार [NotesPositions.BottomFull](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/#BottomFull) का उपयोग करें। नोट्स के बिना स्लाइड्स निर्यात करने के लिए, नीचे दिखाए अनुसार नोट्स लेआउट कॉन्फ़िगरेशन को छोड़ दें [Convert PowerPoint to TIFF](/slides/hi/python-java/convert-powerpoint-to-tiff/)।

**मैं नोट्स के साथ TIFF फ़ाइल का आकार गुणवत्ता कम किए बिना कैसे घटा सकता हूँ?**

[setCompressionType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#setCompressionType) के माध्यम से lossless [LZW compression](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffcompressiontypes/#LZW) का उपयोग करें। रिज़ॉल्यूशन या रंग गहराई घटाने से फ़ाइल आकार और घट सकता है, लेकिन इससे छवि गुणवत्ता और नोट्स की पठनीयता प्रभावित हो सकती है। अतिरिक्त विकल्पों के लिए देखें [TIFF export settings](/slides/hi/python-java/convert-powerpoint-to-tiff/)।

**यदि सिस्टम में मूल फ़ॉन्ट नहीं हैं तो नोट्स में फ़ॉन्ट का परिणाम पर क्या प्रभाव पड़ता है?**

हाँ। गायब फ़ॉन्ट फ़ॉन्ट प्रतिस्थापन को ट्रिगर करते हैं [/slides/hi/python-java/font-selection-sequence/](), जो टेक्स्ट मेट्रिक और दिखावट बदल सकता है। इच्छित टाइपफेस बनाए रखने के लिए आवश्यक फ़ॉन्ट [/slides/hi/python-java/custom-font/]() आपूर्ति करें।