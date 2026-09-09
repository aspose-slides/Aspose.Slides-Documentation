---
title: PowerPoint प्रस्तुतियों को Python में TIFF में परिवर्तित करें
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
- पायथन
- जावा
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके, PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च-गुणवत्ता वाले TIFF इमेज में आसानी से बदलना सीखें, कोड उदाहरणों के साथ।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक रास्टर इमेज फॉर्मेट है जो कई पृष्ठों और लॉसलेस कंप्रेशन का समर्थन करता है। यह एकल इमेज फ़ाइल में रेंडर किए गए स्लाइड्स को संग्रहीत करने के लिए उपयोगी है।

Aspose.Slides for Python via Java का उपयोग करके, आप PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों को TIFF में कनवर्ट कर सकते हैं। नीचे दिए गए प्रत्येक उदाहरण आवश्यक होने पर जावा वर्चुअल मशीन शुरू करता है और उपयोग के बाद प्रस्तुति को रिलीज़ करता है। 

## **प्रस्तुति को TIFF में बदलें**

[Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास द्वारा प्रदान किए गए [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड का उपयोग करके, आप पूरी PowerPoint प्रस्तुति को शीघ्रता से TIFF में बदल सकते हैं। परिणामी मल्टीपेज़ TIFF प्रत्येक स्लाइड की डिफ़ॉल्ट आकार की रेंडर की गई इमेज रखता है।

यह कोड दर्शाता है कि PowerPoint प्रस्तुति को TIFF में कैसे परिवर्तित किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # सभी स्लाइड्स को एक बहु-पृष्ठ TIFF फ़ाइल में सहेजें।
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **प्रस्तुति को ब्लैक-एंड-व्हाइट TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/) क्लास में स्थित मेथड [setBwConversionMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#setBwConversionMode) आपको रंगीन स्लाइड या इमेज को ब्लैक-एंड-व्हाइट TIFF में बदलते समय उपयोग किए जाने वाले एल्गोरिद्म को निर्दिष्ट करने की अनुमति देता है। ध्यान रखें कि यह सेटिंग केवल तब लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#setCompressionType) मेथड को [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) या [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffcompressiontypes/#CCITT3) पर सेट किया गया हो।

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#setBwConversionMode) एक एक्सपोर्ट-लेवल सेटिंग है जो पूरी TIFF इमेज के लिए पिक्सेल-परिवर्तन एल्गोरिद्म चुनती है। जब ब्लैक-एंड-व्हाइट डिस्प्ले मोड सक्रिय हो, तो यह परिभाषित करने के लिए कि व्यक्तिगत शेप कैसे दिखे, उपयोग करें [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#setBlackWhiteMode)। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/slides/hi/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह कोड दर्शाता है कि रंगीन स्लाइड को ब्लैक-एंड-व्हाइट TIFF में कैसे परिवर्तित किया जाए:

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

![ब्लैक-एंड-व्हाइट TIFF](TIFF_black_and_white.png)

## **कस्टम आकार के साथ प्रस्तुति को TIFF में बदलें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके अपनी वांछित मान सेट कर सकते हैं। उदाहरण के लिए, [setImageSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#setImageSize) मेथड आपको परिणामी इमेज का आकार निर्धारित करने की अनुमति देता है।

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

    # क्षैतिज और ऊर्ध्वाधर रेज़ोल्यूशन सेट करें।
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

## **कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ प्रस्तुति को TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/) क्लास के [setPixelFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#setPixelFormat) मेथड का उपयोग करके, आप परिणामी TIFF इमेज के लिए अपना पसंदीदा पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

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

{{% alert title="Tip" color="success" %}}
Aspose के [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी PowerPoint प्रस्तुति के बजाय व्यक्तिगत स्लाइड को TIFF में परिवर्तित कर सकता हूँ?**

हां। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों से व्यक्तिगत स्लाइड को अलग-अलग TIFF इमेज में परिवर्तित करने की अनुमति देता है।

**क्या प्रस्तुति को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है?**

TIFF एक्सपोर्ट के लिए कोई स्थिर स्लाइड-गणना सीमा नहीं है। उपलब्ध मेमोरी, स्लाइड की जटिलता, और आउटपुट आयाम प्रभावित करते हैं कि आप कितनी बड़ी प्रस्तुतियों को प्रोसेस कर सकते हैं।

**क्या PowerPoint एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स स्लाइड को TIFF में बदलते समय संरक्षित रहते हैं?**

नहीं, TIFF एक स्थैतिक इमेज फ़ॉर्मेट है। इसलिए, एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं होते; केवल स्लाइड की स्थैतिक स्नैपशॉट्स एक्सपोर्ट किए जाते हैं।