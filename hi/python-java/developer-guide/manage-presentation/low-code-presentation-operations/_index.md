---
title: Python के माध्यम से Java में लो-कोड प्रेजेंटेशन ऑपरेशन्स
linktitle: लो-कोड API
type: docs
weight: 50
url: /hi/python-java/low-code-presentation-operations/
keywords:
- लो-कोड प्रेजेंटेशन API
- प्रेजेंटेशन बदलें
- प्रेजेंटेशन मर्ज करें
- स्लाइड्स पर पुनरावृत्ति करें
- शेप्स पर पुनरावृत्ति करें
- टेक्स्ट पर पुनरावृत्ति करें
- शेप्स एकत्रित करें
- प्रेजेंटेशन संपीड़ित करें
- अप्रयोगित मास्टर स्लाइड्स हटाएँ
- अप्रयोगित लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट्स संपीड़ित करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides लो-कोड API को Python के माध्यम से Java में उपयोग करके प्रेजेंटेशन को बदलें और मर्ज करें, सामग्री पर पुनरावृत्ति करें, शैप्स एकत्रित करें, और प्रेजेंटेशन का आकार कम करें।"
---
## **अवलोकन**

The [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/hi/python-java/aspose.slides/) API सामान्य प्रस्तुति संचालन के लिए स्थिर सहायक क्लासेज़ प्रदान करता है। ये सहायक अक्सर उपयोग किए जाने वाले ऑब्जेक्ट‑मॉडल वर्कफ़्लो को केंद्रित मेथड्स में समेटते हैं, जिससे आप फ़ाइलें बदल या मिलान कर सकते हैं, प्रस्तुति तत्वों को प्रोसेस कर सकते हैं, शैप्स इकट्ठा कर सकते हैं, और कम कोड के साथ अप्रयोगित सामग्री हटा सकते हैं।

Low-code सहायक सबसे उपयोगी होते हैं जब क्रिया पूरी फ़ाइल या प्रस्तुति पर लागू होती है और डिफ़ॉल्ट वर्कफ़्लो आपकी आवश्यकताओं से मेल खाता है। पूर्ण [Aspose.Slides object model](https://reference.aspose.com/slides/hi/python-java/aspose.slides/) उपयोग करें जब आपको व्यक्तिगत स्लाइड्स, मास्टर, लेआउट्स, शैप्स, निर्यात सेटिंग्स, या प्रस्तुति तत्वों के बीच संबंधों पर सूक्ष्म नियंत्रण चाहिए।

निम्न तालिका उपलब्ध सहायक को सारांशित करती है:

| सहायक | उपयोग हेतु |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/python-java/aspose.slides/convert/) | एक प्रस्तुति को दूसरे फ़ॉर्मेट में सीधे फ़ाइल‑से‑फ़ाइल कॉल के साथ बदलना। |
| [Merger](https://reference.aspose.com/slides/hi/python-java/aspose.slides/merger/) | एक ही फ़ॉर्मेट की पूरी प्रस्तुति फ़ाइलों को मिलाना। |
| [ForEach](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/) | प्रत्येक स्लाइड, शैप, पैराग्राफ या टेक्स्ट भाग के लिए कार्रवाई चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/collect/) | पूरी प्रस्तुति से शैप्स प्राप्त करना ताकि उन्हें बार‑बार प्रोसेस या विश्लेषण किया जा सके। |
| [Compress](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/) | अप्रयोगित मास्टर और लेआउट हटाना और एम्बेडेड फ़ॉन्ट डेटा को कम करना। |

## **प्रेजेंटेशन रूपांतरण**

जब आउटपुट फ़ाइल एक्सटेंशन निर्यात फ़ॉर्मेट चुनने के लिए पर्याप्त हो तब [Convert.autoByExtension](https://reference.aspose.com/slides/hi/python-java/aspose.slides/convert/#autoByExtension) का उपयोग करें। यह मेथड स्रोत प्रस्तुति खोलता है, आउटपुट पाथ से आवश्यक फ़ॉर्मेट निर्धारित करता है, और परिणाम लिखता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

The [Convert](https://reference.aspose.com/slides/hi/python-java/aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. फ़ॉर्मेट‑विशिष्ट वर्कफ़्लो और विकल्पों के लिए देखें [Convert Presentation](/slides/hi/python-java/convert-presentation/)।

## **प्रेजेंटेशन मर्ज**

एक कॉल से पूरी प्रस्तुति फ़ाइलों को सम्मिलित करने के लिए [Merger.process](https://reference.aspose.com/slides/hi/python-java/aspose.slides/merger/#process) का उपयोग करें। इनपुट प्रस्तुतियों का फ़ाइल फ़ॉर्मेट समान होना चाहिए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/hi/python-java/merge-presentation/) for those scenarios.

## **प्रेजेंटेशन तत्वों पर पुनरावृत्ति**

The [ForEach](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/#paragraph), and [ForEach.portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/#portion) to inspect the corresponding elements:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **शेप्स एकत्रित करें**

Use [Collect.shapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/collect/#shapes) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Use [ForEach.shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/#shape) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **प्रेजेंटेशन सामग्री को संपीड़ित करें**

The [Compress](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) लेआउट स्लाइड हटाता है जो किसी सामान्य स्लाइड द्वारा संदर्भित नहीं हैं।
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/#removeUnusedMasterSlides) मास्टर स्लाइड हटाता है जो अब उपयोग में नहीं हैं।
- [compressEmbeddedFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/#compressEmbeddedFonts) एम्बेडेड फ़ॉन्ट्स से अप्रयोगित अक्षर हटाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

लेआउट साफ़ करने के बाद अप्रयोगित मास्टर हटाएं ताकि लेआउट सफ़ाई के बाद अनउद्धृत मास्टर भी हटाया जा सके। यदि आपको बाद में मूल मास्टर, लेआउट या पूरी एम्बेडेड फ़ॉन्ट डेटा की आवश्यकता हो सकती है तो अनुकूलित प्रस्तुति को नई फ़ाइल में सहेजें। अधिक विवरण के लिए देखें [Slide Master](/slides/hi/python-java/slide-master/) और [Embedded Font](/slides/hi/python-java/embedded-font/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब मुझे पूर्ण ऑब्जेक्ट मॉडल के बजाय लो‑कोड API का उपयोग करना चाहिए?**

जब एक मानक कार्य पूरी फ़ाइल या प्रस्तुति पर लागू हो और व्यक्तिगत तत्वों पर विस्तृत नियंत्रण की आवश्यकता न हो, तब लो‑कोड सहायक उपयोग करें। जब आपको विशिष्ट स्लाइड्स चुननी हों, मास्टर और लेआउट संबंधों को नियंत्रित करना हो, मध्यवर्ती स्थिति की जाँच करनी हो, या ऐसी विधि कॉन्फ़िगर करनी हो जो सहायक में उपलब्ध न हो, तब पूर्ण ऑब्जेक्ट मॉडल उपयोग करें।

**क्या Merger विभिन्न फ़ाइल फ़ॉर्मेट की प्रस्तुतियों को संयोजित कर सकता है?**

नहीं। [Merger.process](https://reference.aspose.com/slides/hi/python-java/aspose.slides/merger/#process) को इनपुट प्रस्तुतियों का एक ही फ़ॉर्मेट होना आवश्यक है। पहले इन फ़ाइलों को सामान्य फ़ॉर्मेट में बदलें, उदाहरण के लिए [Convert.autoByExtension](https://reference.aspose.com/slides/hi/python-java/aspose.slides/convert/#autoByExtension) के साथ, फिर परिवर्तित फ़ाइलों को मर्ज करें।

**क्या ForEach मास्टर, लेआउट और नोट्स स्लाइड्स को प्रोसेस करता है?**

[ForEach.slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/#slide) सामान्य प्रस्तुति स्लाइड्स पर पुनरावृत्ति करता है। प्रस्तुति‑व्यापी [ForEach.shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/#paragraph) और [ForEach.portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/#portion) डिफ़ॉल्ट रूप से सामान्य, मास्टर और लेआउट स्लाइड्स को शामिल करते हैं। नोट्स स्लाइड्स को शामिल करने के लिए `includeNotes` को `True` सेट करके उनके ओवरलोड का उपयोग करें।

**ForEach.shape और Collect.shapes में क्या अंतर है?**

प्रत्येक शैप को तुरंत कॉलबैक के माध्यम से प्रोसेस करने के लिए [ForEach.shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/#shape) उपयोग करें। जब आपको शैप्स का इटेरेबल परिणाम चाहिए जिसे बरकरार रखा, फ़िल्टर किया, गिना या कई बार पार किया जा सके, तब [Collect.shapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/collect/#shapes) उपयोग करें।

**क्या Compress हमेशा प्रस्तुति फ़ाइल को छोटा बनाता है?**

ज़रूरी नहीं। परिणाम इस बात पर निर्भर करता है कि प्रस्तुति में अप्रयोगित लेआउट, अप्रयोगित मास्टर या अप्रयोगित अक्षर वाले एम्बेडेड फ़ॉन्ट्स हैं या नहीं। यदि इनमें से कुछ नहीं है, तो संबंधित [Compress](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/) ऑपरेशन्स फ़ाइल आकार को कम नहीं कर सकते।

**क्या ForEach या Compress द्वारा किए गए परिवर्तन स्वचालित रूप से सहेजे जाते हैं?**

नहीं। ये सहायक लोड किए हुए [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट पर मेमोरी में काम करते हैं। [ForEach](https://reference.aspose.com/slides/hi/python-java/aspose.slides/foreach/) कॉलबैक में तत्व बदलने या [Compress](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/) चलाने के बाद, परिणाम लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) को कॉल करें।

## **संबंधित लेख**

- [प्रेजेंटेशन रूपांतरण](/slides/hi/python-java/convert-presentation/)
- [प्रेजेंटेशन मर्ज](/slides/hi/python-java/merge-presentation/)
- [Slide Master](/slides/hi/python-java/slide-master/)
- [Manage Text Box](/slides/hi/python-java/manage-textbox/)
- [Embedded Font](/slides/hi/python-java/embedded-font/)