---
title: Python में PowerPoint प्रस्तुतियों को TIFF में परिवर्तित करें
linktitle: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/python-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint परिवर्तित करें
- OpenDocument परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से TIFF
- प्रस्तुति से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च-गुणवत्ता वाले TIFF छवियों में आसानी से परिवर्तित करना सीखें, साथ में कोड उदाहरण।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक रैस्टर इमेज फॉर्मैट है जो कई पृष्ठों और लॉसलेस कम्प्रेशन का समर्थन करता है। यह एकल इमेज फ़ाइल में रेंडर किए गए स्लाइड्स को संग्रहीत करने के लिए उपयोगी है।

Aspose.Slides for Python via Java का उपयोग करके, आप PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों को TIFF में बदल सकते हैं। नीचे प्रत्येक उदाहरण आवश्यक होने पर Java वर्चुअल मशीन को शुरू करता है और उपयोग के बाद प्रस्तुति को रिलीज़ करता है।

## **प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

[save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड का उपयोग करके, जो [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास द्वारा प्रदान किया गया है, आप पूरे PowerPoint प्रेज़ेंटेशन को जल्दी से TIFF में परिवर्तित कर सकते हैं। प्राप्त बहु‑पृष्ठ TIFF में प्रत्येक स्लाइड की रेंडर की गई इमेज डिफ़ॉल्ट आकार पर होती है।

यह कोड दर्शाता है कि PowerPoint प्रेज़ेंटेशन को TIFF में कैसे परिवर्तित किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # सभी स्लाइड्स को मल्टीपेज़ TIFF फ़ाइल में सहेजें।
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **प्रेज़ेंटेशन को ब्लैक‑एंड‑व्हाइट TIFF में परिवर्तित करें**

क्लास [TiffOptions] में मौजूद मेथड [setBwConversionMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#setBwConversionMode) आपको रंगीन स्लाइड या इमेज को ब्लैक‑एंड‑व्हाइट TIFF में बदलते समय उपयोग किए जाने वाले एल्गोरिद्म को निर्धारित करने की अनुमति देता है। ध्यान दें कि यह सेटिंग केवल तभी लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#setCompressionType) मेथड को [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) या [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffcompressiontypes/#CCITT3) पर सेट किया गया हो।

{{% alert color="info" title="नोट" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#setBwConversionMode) एक एक्सपोर्ट‑लेवल सेटिंग है जो पूर्ण TIFF इमेज के लिए पिक्सेल‑कन्वर्ज़न एल्गोरिद्म चुनती है। जब ब्लैक‑एंड‑व्हाइट डिस्प्ले मोड सक्रिय हो, तो व्यक्तिगत शैप कैसे दिखेगा, इसे निर्धारित करने के लिए [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#setBlackWhiteMode) का उपयोग करें। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/slides/hi/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास एक "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रेज़ेंटेशन स्लाइड](slide_black_and_white.png)

यह कोड दर्शाता है कि रंगीन स्लाइड को ब्लैक‑एंड‑व्हाइट TIFF में कैसे परिवर्तित किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

परिणाम:

![ब्लैक‑एंड‑व्हाइट TIFF](TIFF_black_and_white.png)

## **प्रेज़ेंटेशन को कस्टम साइज के साथ TIFF में परिवर्तित करें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके वांछित मान सेट कर सकते हैं। उदाहरण के लिए, [setImageSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#setImageSize) मेथड आपको परिणामी इमेज का आकार निर्धारित करने की अनुमति देता है।

यह कोड दर्शाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम साइज वाली TIFF इमेजेज में कैसे परिवर्तित किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # क्षैतिज और अनुलंब रिज़ॉल्यूशन सेट करें।
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # आउटपुट आयाम पिक्सेल में सेट करें।
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # प्रत्येक स्लाइड के नीचे पूर्ण स्पीकर नोट्स शामिल करें।
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **प्रेज़ेंटेशन को कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/) क्लास के [setPixelFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#setPixelFormat) मेथड का उपयोग करके, आप परिणामी TIFF इमेज के लिए अपना पसंदीदा पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह कोड दर्शाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम पिक्सेल फ़ॉर्मेट वाली TIFF इमेज में कैसे परिवर्तित किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="टिप" color="success" %}}
[Aspose के मुफ्त PowerPoint से पोस्टर कनवर्टर](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरे PowerPoint प्रेज़ेंटेशन के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**

हां। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों की व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेज में बदलने की सुविधा देता है।

**क्या प्रेज़ेंटेशन को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है?**

TIFF निर्यात के लिए कोई निश्चित स्लाइड‑काउंट सीमा नहीं है। उपलब्ध मेमोरी, स्लाइड की जटिलता, और आउटपुट आयाम यह निर्धारित करते हैं कि आप कितनी बड़ी प्रस्तुतियां प्रोसेस कर सकते हैं।

**क्या स्लाइड्स को TIFF में बदलते समय PowerPoint एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित रहते हैं?**

नहीं, TIFF एक स्थैतिक इमेज फ़ॉर्मैट है। इसलिए, एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं होते; केवल स्लाइड्स की स्थैतिक स्नैपशॉट्स निर्यात किए जाते हैं।