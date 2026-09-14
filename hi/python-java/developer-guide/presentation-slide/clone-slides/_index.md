---
title: "Python में प्रस्तुति स्लाइड्स क्लोन करें"
linktitle: "स्लाइड्स क्लोन करें"
type: docs
weight: 35
url: /hi/python-java/clone-slides/
keywords:
- "स्लाइड क्लोन"
- "स्लाइड कॉपी"
- "स्लाइड सहेजें"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java के साथ PowerPoint स्लाइड्स को तेज़ी से दोहराएँ। हमारे स्पष्ट कोड उदाहरणों का पालन करके सेकंड में PPT निर्माण को स्वचालित करें और मैन्युअल कार्य समाप्त करें।"
---
## **परिचय**

क्लोनिंग वह प्रक्रिया है जिससे किसी वस्तु की बिल्कुल समान प्रतिलिपि या प्रतिकृति बनाई जाती है। Aspose.Slides for Python via Java यह भी संभव बनाता है कि किसी भी स्लाइड की कॉपी या क्लोन बनाया जा सके और फिर उस क्लोन की गई स्लाइड को वर्तमान प्रस्तुति या किसी अन्य खुली प्रस्तुति में डाल दिया जाए। स्लाइड क्लोनिंग की प्रक्रिया एक नई स्लाइड बनाती है जिसे डेवलपर्स मूल स्लाइड को बदले बिना संशोधित कर सकते हैं। स्लाइड को क्लोन करने के कई संभावित तरीके हैं:

- प्रस्तुति के भीतर अंत में क्लोन करें।
- प्रस्तुति के भीतर किसी अन्य स्थिति पर क्लोन करें।
- अन्य प्रस्तुति में अंत में क्लोन करें।
- अन्य प्रस्तुति में किसी अन्य स्थिति पर क्लोन करें।
- इसके मास्टर स्लाइड के साथ मिलाकर अन्य प्रस्तुति में क्लोन करें।

Aspose.Slides for Python via Java में, स्लाइड संग्रह (जो कि [Slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) ऑब्जेक्ट्स का संग्रह है) जिसे [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट द्वारा उजागर किया गया है, उपरोक्त स्लाइड क्लोनिंग प्रकारों को करने के लिए [addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) और [insertClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#insertClone) मेथड्स प्रदान करता है।

## **प्रेजेंटेशन के अंत में एक स्लाइड क्लोन करें**

यदि आप किसी स्लाइड को क्लोन करना चाहते हैं और फिर उसी प्रस्तुति फ़ाइल में मौजूदा स्लाइडों के अंत में उपयोग करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार [addClone] मेथड का उपयोग करें।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) ऑब्जेक्ट प्राप्त करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) ऑब्जेक्ट द्वारा प्रदर्शित [addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड को [addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) मेथड में पैरामीटर के रूप में पास करें।
1. संशोधित प्रस्तुति फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति के पहले स्थान (शून्य इंडेक्स) पर स्थित एक स्लाइड को प्रस्तुति के अंत में क्लोन किया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # इसी प्रस्तुति में स्लाइडों के संग्रह के अंत में वांछित स्लाइड को क्लोन करें
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # संशोधित प्रस्तुति को डिस्क पर लिखें
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **प्रेजेंटेशन के भीतर किसी अन्य स्थिति में स्लाइड क्लोन करें**

यदि आप स्लाइड को क्लोन करना चाहते हैं और फिर उसी प्रस्तुति फ़ाइल में इसे अलग स्थिति पर उपयोग करना चाहते हैं, तो [insertClone] मेथड का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट पर [getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) द्वारा लौटाए गए स्लाइड संग्रह का एक संदर्भ प्राप्त करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) ऑब्जेक्ट द्वारा प्रदर्शित [insertClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#insertClone) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड को नए स्थान के इंडेक्स के साथ [insertClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#insertClone) मेथड में पैरामीटर के रूप में पास करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति के इंडेक्स 1 (स्थिति 2) पर स्थित स्लाइड को इंडेक्स 2 (स्थिति 3) पर क्लोन किया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # प्रस्तुति में स्लाइड्स के संग्रह को प्राप्त करें
    slides = presentation.getSlides()

    # उसी प्रस्तुति में निर्दिष्ट इंडेक्स पर वांछित स्लाइड को क्लोन करें
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # संशोधित प्रस्तुति को डिस्क पर लिखें
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **एक अन्य प्रस्तुति के अंत में स्लाइड क्लोन करें**

यदि आपको एक प्रस्तुति से स्लाइड को क्लोन करके दूसरे प्रस्तुति फ़ाइल में मौजूदा स्लाइडों के अंत में उपयोग करने की आवश्यकता है:

1. जिस प्रस्तुति से स्लाइड क्लोन किया जाएगा, उसकी शामिल करने वाले [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. जिस लक्ष्य प्रस्तुति में स्लाइड जोड़ी जाएगी, उसे शामिल करने वाले [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. लक्ष्य प्रस्तुति के [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट पर [getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) द्वारा लौटाए गए स्लाइड संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) ऑब्जेक्ट प्राप्त करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) ऑब्जेक्ट द्वारा प्रदर्शित [addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) मेथड को कॉल करें और स्रोत प्रस्तुति से स्लाइड को [addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) मेथड में पैरामीटर के रूप में पास करें।
1. संशोधित लक्ष्य प्रस्तुति फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के इंडेक्स 0 से स्लाइड को लक्ष्य प्रस्तुति के अंत में क्लोन किया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंशिएट करें
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # लक्ष्य PPTX (जहां स्लाइड को क्लोन करना है) के लिए Presentation क्लास को इंस्टैंशिएट करें
    destination_presentation = Presentation()
    try:
        # स्रोत प्रस्तुति से वांछित स्लाइड को लक्ष्य प्रस्तुति में स्लाइडों के संग्रह के अंत में क्लोन करें
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # लक्ष्य प्रस्तुति को डिस्क पर लिखें
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **एक अन्य प्रस्तुति में किसी अन्य स्थिति में स्लाइड क्लोन करें**

यदि आपको एक प्रस्तुति से स्लाइड को क्लोन करके दूसरे प्रस्तुति फ़ाइल में एक विशिष्ट स्थिति पर उपयोग करने की आवश्यकता है:

1. स्रोत प्रस्तुति को शामिल करने वाले [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. लक्ष्य प्रस्तुति को शामिल करने वाले [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. लक्ष्य प्रस्तुति के Slides संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) ऑब्जेक्ट प्राप्त करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) ऑब्जेक्ट द्वारा प्रदर्शित [insertClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#insertClone) मेथड को कॉल करें और स्रोत प्रस्तुति से स्लाइड को वांछित स्थिति के साथ [insertClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#insertClone) मेथड में पैरामीटर के रूप में पास करें।
1. संशोधित लक्ष्य प्रस्तुति फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के शून्य इंडेक्स से स्लाइड को लक्ष्य प्रस्तुति के इंडेक्स 1 (स्थिति 2) पर क्लोन किया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंशिएट करें
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # लक्ष्य PPTX (जहां स्लाइड को क्लोन किया जाना है) के लिए Presentation क्लास को इंस्टैंशिएट करें
    destination_presentation = Presentation()
    try:
        # स्रोत प्रस्तुति से वांछित स्लाइड को लक्ष्य प्रस्तुति में निर्दिष्ट इंडेक्स पर क्लोन करें
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # लक्ष्य प्रस्तुति को डिस्क पर लिखें
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **एक स्लाइड को उसके मास्टर स्लाइड के साथ अन्य प्रस्तुति में क्लोन करें**

यदि आपको एक प्रस्तुति से मास्टर स्लाइड के साथ स्लाइड को क्लोन करके दूसरे प्रस्तुति में उपयोग करने की आवश्यकता है, तो पहले आपको स्रोत प्रस्तुति से वांछित मास्टर स्लाइड को लक्ष्य प्रस्तुति में क्लोन करना होगा। फिर स्लाइड को क्लोन करते समय क्लोन किए गए मास्टर स्लाइड का उपयोग करें। [addClone] मेथड लक्ष्य प्रस्तुति से मास्टर स्लाइड की अपेक्षा करता है, न कि स्रोत प्रस्तुति से। मास्टर के साथ स्लाइड को क्लोन करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. स्रोत प्रस्तुति को शामिल करने वाले [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. लक्ष्य प्रस्तुति को शामिल करने वाले [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. क्लोन की जाने वाली स्लाइड को उसके मास्टर स्लाइड के साथ एक्सेस करें।
1. लक्ष्य प्रस्तुति के [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट द्वारा उजागर किए गए Masters संग्रह को संदर्भित करके [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/) ऑब्जेक्ट प्राप्त करें।
1. लक्ष्य प्रस्तुति के [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/) ऑब्जेक्ट द्वारा प्रदर्शित [addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/#addClone) मेथड को कॉल करें और स्रोत PPTX से क्लोन करने हेतु मास्टर को [addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/#addClone) मेथड में पैरामीटर के रूप में पास करें।
1. लक्ष्य प्रस्तुति के [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) ऑब्जेक्ट प्राप्त करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) ऑब्जेक्ट द्वारा प्रदर्शित [addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) मेथड को कॉल करें और स्रोत प्रस्तुति से क्लोन की जाने वाली स्लाइड तथा मास्टर स्लाइड को [addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) मेथड में पैरामीटर के रूप में पास करें।
1. संशोधित लक्ष्य प्रस्तुति फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के शून्य इंडेक्स पर स्थित स्लाइड को उसके मास्टर के साथ लक्ष्य प्रस्तुति के अंत में क्लोन किया है, जहाँ स्रोत स्लाइड का मास्टर उपयोग किया गया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंशिएट करें
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # गंतव्य प्रस्तुति (जहां स्लाइड को क्लोन किया जाना है) के लिए Presentation क्लास को इंस्टैंशिएट करें
    destination_presentation = Presentation()
    try:
        # स्रोत प्रस्तुति में स्लाइड्स के संग्रह से स्लाइड को इंस्टैंशिएट करें साथ में
        # मास्टर स्लाइड
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # स्रोत प्रस्तुति से वांछित मास्टर स्लाइड को गंतव्य प्रस्तुति के मास्टर्स संग्रह में क्लोन करें
        # गंतव्य प्रस्तुति
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # स्रोत प्रस्तुति से वांछित स्लाइड को इच्छित मास्टर के साथ गंतव्य प्रस्तुति में स्लाइड्स के संग्रह के अंत में क्लोन करें
        # गंतव्य प्रस्तुति में स्लाइड्स के संग्रह
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # गंतव्य प्रस्तुति को डिस्क पर सहेजें
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **निर्दिष्ट सेक्शन के अंत में स्लाइड क्लोन करें**

यदि आप स्लाइड को क्लोन करके उसे उसी प्रस्तुति फ़ाइल में लेकिन एक अलग सेक्शन में उपयोग करना चाहते हैं, तो [**addClone**] मेथड का उपयोग करें जो कि [**SlideCollection**] क्लास द्वारा प्रदर्शित है। Aspose.Slides for Python via Java पहली सेक्शन से स्लाइड को क्लोन करना और फिर उस क्लोन की गई स्लाइड को उसी प्रस्तुति के दूसरे सेक्शन में सम्मिलित करना संभव बनाता है।

निम्नलिखित कोड स्निपेट दिखाता है कि कैसे स्लाइड को क्लोन किया जाए और क्लोन की गई स्लाइड को एक निर्दिष्ट सेक्शन में डालें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # लक्ष्य प्रस्तुति को डिस्क पर सहेजें
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्लाइड आकार का मेल सुनिश्चित करें**

जब स्लाइडों को किसी अन्य प्रस्तुति में क्लोन किया जाता है, तो सुनिश्चित करें कि लक्ष्य प्रस्तुति का स्लाइड आकार स्रोत के समान हो। यदि स्लाइड आकार अलग हैं, तो Aspose.Slides क्लोन किए गए आकारों का स्वतः पुनः स्केल नहीं करता—उनके मूल निर्देशांक और आयाम संरक्षित रहते हैं, जिससे सामग्री असंतुलित दिख सकती है या स्लाइड की सीमाओं से बाहर जा सकती है।

आप क्लोन करने से पहले लक्ष्य प्रस्तुति के स्लाइड आकार को स्रोत के समान सेट कर सकते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

मास्टर और स्लाइड को क्लोन करने से पहले यह करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्पीकर नोट्स और रिव्युअर कमेंट्स क्लोन होते हैं?**

हां। नोट्स पेज और रिव्यू कमेंट्स क्लोन में शामिल होते हैं। यदि आप इन्हें नहीं चाहते, तो डालने के बाद उन्हें [remove them](/slides/hi/python-java/presentation-notes/) करें।

**चार्ट और उनके डेटा स्रोत कैसे संभाले जाते हैं?**

चार्ट ऑब्जेक्ट, फ़ॉर्मेटिंग और एम्बेडेड डेटा कॉपी किए जाते हैं। यदि चार्ट किसी बाहरी स्रोत (जैसे OLE-एम्बेडेड वर्कबुक) से लिंक किया गया था, तो वह लिंक एक [OLE object](/slides/hi/python-java/manage-ole/) के रूप में संरक्षित रहता है। फ़ाइलों के बीच स्थानांतरित करने के बाद, डेटा की उपलब्धता और रिफ्रेश व्यवहार की जाँच करें।

**क्या मैं क्लोन की इंसर्शन पोजीशन और सेक्शन नियंत्रित कर सकता हूँ?**

हां। आप क्लोन को एक विशिष्ट स्लाइड इंडेक्स पर डाल सकते हैं और इसे चुनिंदा [section](/slides/hi/python-java/slide-section/) में रख सकते हैं। यदि लक्ष्य सेक्शन मौजूद नहीं है, तो पहले उसे बनाएं और फिर स्लाइड को उसमें स्थानांतरित करें।