---
title: Python द्वारा Java के साथ PowerPoint प्रस्तुतियों को SWF Flash में बदलें
linktitle: PowerPoint से SWF
type: docs
weight: 80
url: /hi/python-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint रूपांतरण
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
- PowerPoint से SWF
- प्रस्तुति से SWF
- स्लाइड से SWF
- PPT से SWF
- PPTX से SWF
- PowerPoint से Flash
- प्रस्तुति से Flash
- स्लाइड से Flash
- PPT से Flash
- PPTX से Flash
- PPT को SWF के रूप में सहेजें
- PPTX को SWF के रूप में सहेजें
- PPT को SWF में निर्यात करें
- PPTX को SWF में निर्यात करें
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Python द्वारा Java के माध्यम से PowerPoint प्रस्तुतियों को SWF Flash में बदलें। व्यूअर, नोट्स, छिपी स्लाइड्स, संपीड़न और फ़ॉन्ट्स को कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for Python via Java आपको Microsoft PowerPoint के बिना PowerPoint प्रस्तुतियों को SWF में बदलने की सुविधा देता है। प्रस्तुति को निर्यात करने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) का उपयोग करें और व्यूअर सेटिंग्स, छवि गुणवत्ता, तथा नोट्स या टिप्पणी के लेआउट को कॉन्फ़िगर करने के लिए [SwfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/swfoptions/) का उपयोग करें।

## **प्रस्तुतियों को Flash में बदलें**

[Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) से स्रोत फ़ाइल लोड करें, [SwfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/swfoptions/) को कॉन्फ़िगर करें, और इसे [SaveFormat.Swf](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Swf) का उपयोग करके सहेजें।

निम्नलिखित उदाहरण `presentation.pptx` को `presentation.swf` में निर्यात करता है। यह [setViewerIncluded](https://reference.aspose.com/slides/hi/python-java/aspose.slides/swfoptions/#setViewerIncluded) के द्वारा एम्बेडेड व्यूअर को निष्क्रिय करता है और स्लाइड्स के नीचे स्पीकर नोट्स को शामिल करने के लिये [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/) का उपयोग करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

उदाहरण चलाने से पहले, [Aspose.Slides for Python via Java स्थापित करें](/slides/hi/python-java/installation/) और `presentation.pptx` को कार्य निर्देशिका में रखें। JVM प्रत्येक Python प्रक्रिया के लिए एक बार शुरू किया जाता है।

उदाहरण [setNotesPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) के माध्यम से [NotesPositions.BottomFull](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/#BottomFull) लागू करता है और लेआउट को [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions) में पास करता है। टिप्पणी को भी शामिल करने के लिये, निर्यात करने से पहले [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) को कॉन्फ़िगर करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं SWF में छिपी स्लाइड्स शामिल कर सकता हूँ?**

हाँ। [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) को `True` के साथ कॉल करें। डिफ़ॉल्ट रूप से, छिपी स्लाइड्स निर्यात नहीं की जाती हैं।

**मैं संपीड़न और अंतिम SWF आकार को कैसे नियंत्रित कर सकता हूँ?**

[SwfOptions.setCompressed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/swfoptions/#setCompressed) का उपयोग करके संपीड़न को सक्षम या अक्षम करें और JPEG छवि गुणवत्ता को समायोजित करने के लिये [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/hi/python-java/aspose.slides/swfoptions/#setJpegQuality) का उपयोग करें। कम JPEG गुणवत्ता फ़ाइल आकार को घटा सकती है लेकिन छवि की स्पष्टता में कमी आती है।

**एम्बेडेड व्यूअर किस लिए है, और इसे मुझे कब निष्क्रिय करना चाहिए?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/hi/python-java/aspose.slides/swfoptions/#setViewerIncluded) यह निर्धारित करता है कि उत्पन्न SWF में व्यूअर शामिल है या नहीं। जब आपको एम्बेडेड व्यूअर के बिना निर्यात की गई स्लाइड्स चाहिए, तो `False` पास करें, जैसा कि ऊपर के उदाहरण में दिखाया गया है।

**यदि निर्यात मशीन पर स्रोत फ़ॉन्ट अनुपलब्ध हो तो क्या होता है?**

आप [setDefaultRegularFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) के साथ एक डिफ़ॉल्ट नियमित फ़ॉन्ट निर्दिष्ट कर सकते हैं, जो [SwfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/swfoptions/) द्वारा विरासत में मिलता है। निर्यात प्रक्रिया में उपलब्ध फ़ॉन्ट चुनें; फ़ॉन्ट प्रतिस्थापन से पाठ की उपस्थिति और लेआउट बदल सकता है।