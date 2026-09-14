---
title: Python में प्रस्तुति स्लाइड्स तक पहुँचें
linktitle: स्लाइड पहुँचें
type: docs
weight: 20
url: /hi/python-java/access-slide-in-presentation/
keywords:
- स्लाइड पहुँचें
- स्लाइड अनुक्रमणिका
- स्लाइड आईडी
- स्लाइड स्थिति
- स्थिति बदलें
- स्लाइड गुण
- स्लाइड संख्या
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स तक पहुँचने और उन्हें प्रबंधित करने के तरीके सीखें। कोड उदाहरणों के साथ उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides का उपयोग करके प्रस्तुति में स्लाइड्स तक कैसे पहुँचा जाए और उनका प्रबंधन कैसे किया जाए। यह दिखाता है कि स्लाइड संग्रह से शून्य‑आधारित अनुक्रमणिका के द्वारा स्लाइड्स को कैसे प्राप्त किया जाए और [getSlideById](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlideById) मेथड का उपयोग करके किसी स्लाइड को उसके अद्वितीय आईडी द्वारा कैसे पहुँचा जाए।

आप यह भी सीखेंगे कि [setSlideNumber](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#setSlideNumber) मेथड का प्रयोग करके स्लाइड की स्थिति कैसे बदलें और [setFirstSlideNumber](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#setFirstSlideNumber) मेथड के साथ प्रस्तुति के लिए प्रारम्भिक स्लाइड संख्या कैसे निर्धारित करें। उदाहरणों में प्रस्तुति लोड करना, स्लाइड संदर्भ प्राप्त करना, स्लाइड क्रम या क्रमांक अपडेट करना, और संशोधित प्रस्तुति सहेजना दर्शाया गया है।

## **इंडेक्स द्वारा स्लाइड तक पहुँचें**

एक प्रस्तुति में सभी स्लाइड्स को क्रमांकित रूप में व्यवस्थित किया जाता है, जहाँ स्लाइड स्थिति 0 से शुरू होती है। पहली स्लाइड को अनुक्रमणिका 0 के माध्यम से पहुँचा जा सकता है; दूसरी स्लाइड को अनुक्रमणिका 1 के माध्यम से पहुँचा जाता है; आदि।

[Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास, जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है, सभी स्लाइड्स को एक [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) संग्रह (जिसमें [Slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) ऑब्जेक्ट्स होते हैं) के रूप में प्रस्तुत करता है। यह Python कोड आपको दिखाता है कि इंडेक्स द्वारा स्लाइड तक कैसे पहुँचा जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
presentation = Presentation("demo.pptx")
try:
    # इंडेक्स का उपयोग करके एक स्लाइड तक पहुँचें।
    slide = presentation.getSlides().get_Item(0)
finally:
    presentation.dispose()
```

## **आईडी द्वारा स्लाइड तक पहुँचें**

प्रत्येक स्लाइड का एक अद्वितीय आईडी होता है। आप उस आईडी को लक्ष्य बनाने के लिए [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास द्वारा प्रदत्त [getSlideById](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlideById) मेथड का उपयोग कर सकते हैं। यह Python कोड आपको दिखाता है कि वैध स्लाइड आईडी प्रदान करके [getSlideById](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlideById) मेथड के माध्यम से स्लाइड तक कैसे पहुँचा जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
presentation = Presentation("demo.pptx")
try:
    # एक स्लाइड आईडी प्राप्त करें।
    slide_id = presentation.getSlides().get_Item(0).getSlideId()

    # आईडी के माध्यम से स्लाइड तक पहुँचें।
    slide = presentation.getSlideById(slide_id)
finally:
    presentation.dispose()
```

## **स्लाइड की स्थिति बदलें**

Aspose.Slides आपको स्लाइड की स्थिति बदलने की अनुमति देता है। उदाहरण के तौर पर, आप निर्दिष्ट कर सकते हैं कि पहली स्लाइड दूसरी स्लाइड बन जाए।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. उस स्लाइड का संदर्भ प्राप्त करें (जिसकी स्थिति बदलनी है) उसकी इंडेक्स के माध्यम से।
1. स्लाइड की नई स्थिति को [setSlideNumber](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#setSlideNumber) मेथड द्वारा सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

यह Python कोड यह दर्शाता है कि स्थिति 1 में स्थित स्लाइड को स्थिति 2 में कैसे ले जाया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
presentation = Presentation("Presentation.pptx")
try:
    # वह स्लाइड प्राप्त करें जिसकी स्थिति बदली जाएगी।
    slide = presentation.getSlides().get_Item(0)

    # स्लाइड के लिए नई स्थिति सेट करें।
    slide.setSlideNumber(2)

    # संशोधित प्रस्तुति को सहेजें।
    presentation.save("helloworld_Pos.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

पहली स्लाइड दूसरी बन गई; दूसरी स्लाइड पहली बन गई। जब आप स्लाइड की स्थिति बदलते हैं, तो अन्य स्लाइड्स स्वतः समायोजित हो जाती हैं।

## **स्लाइड संख्या निर्धारित करें**

[Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास द्वारा प्रदान किए गए [setFirstSlideNumber](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#setFirstSlideNumber) मेथड का उपयोग करके आप प्रस्तुति में पहली स्लाइड के लिए नई संख्या निर्धारित कर सकते हैं। यह ऑपरेशन अन्य स्लाइड नंबरों को पुनः गणना करने का कारण बनता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. स्लाइड संख्या प्राप्त करें।
1. स्लाइड संख्या निर्धारित करें।
1. संशोधित प्रस्तुति को सहेजें।

यह Python कोड यह दर्शाता है कि पहली स्लाइड संख्या को 10 पर सेट किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
presentation = Presentation("HelloWorld.pptx")
try:
    # स्लाइड संख्या प्राप्त करें।
    first_slide_number = presentation.getFirstSlideNumber()

    # स्लाइड संख्या सेट करें।
    presentation.setFirstSlideNumber(10)

    # संशोधित प्रस्तुति को सहेजें।
    presentation.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यदि आप पहली स्लाइड को छोड़ना चाहते हैं, तो आप दूसरी स्लाइड से क्रमांकन शुरू कर सकते हैं (और पहली स्लाइड के लिए क्रमांकन को छिपा सकते हैं) इस प्रकार:

```python
import jpype
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    # पहली प्रस्तुति स्लाइड के लिए संख्या सेट करें।
    presentation.setFirstSlideNumber(0)

    # सभी स्लाइड्स के लिए स्लाइड संख्या दिखाएँ।
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(True)

    # पहली स्लाइड के लिए स्लाइड संख्या छिपाएँ।
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(False)

    # संशोधित प्रस्तुति सहेजें।
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या उपयोगकर्ता द्वारा देखी गई स्लाइड संख्या संग्रह की शून्य‑आधारित अनुक्रमणिका से मेल खाती है?**

स्लाइड पर दिखायी जाने वाली संख्या मनचाहे मान (जैसे 10) से शुरू हो सकती है और उसे अनुक्रमणिका से मेल खाना आवश्यक नहीं है; यह संबंध प्रस्तुति की [first slide number](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#setFirstSlideNumber) सेटिंग द्वारा नियंत्रित होता है।

**क्या छिपी हुई स्लाइड्स अनुक्रमणिका को प्रभावित करती हैं?**

हां। एक छिपी हुई स्लाइड संग्रह में बनी रहती है और अनुक्रमणिका में गिनी जाती है; “छिपी हुई” का मतलब केवल प्रदर्शन से है, न कि संग्रह में उसकी स्थिति से।

**क्या अन्य स्लाइड्स जोड़ने या हटाने पर स्लाइड की अनुक्रमणिका बदलती है?**

हां। अनुक्रमणिकाएँ हमेशा वर्तमान स्लाइड क्रम को प्रतिबिंबित करती हैं और सम्मिलन, विलोपन, या स्थानांतरण संचालन के बाद पुनः गणना की जाती हैं।