---
title: Python के माध्यम से Java का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 80
url: /hi/python-java/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मॉर्फ़ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन प्रभाव
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ने को कॉन्फ़िगर करें, और Morph तथा अन्य ट्रांज़िशन प्रभावों को अनुकूलित करें।"
---
## **Overview**

स्लाइड ट्रांज़िशन निर्धारित करते हैं कि स्लाइड शो के दौरान स्लाइड कैसे दिखाई देती हैं। Aspose.Slides for Python via Java के साथ आप प्रत्येक स्लाइड के लिए एक ट्रांज़िशन प्रभाव चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और प्रभाव के विशिष्ट विकल्प समायोजित कर सकते हैं। यह लेख Python उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड टाइमिंग प्रबंधित करता है, और दो स्लाइडों के बीच Morph ट्रांज़िशन बनाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **Add Slide Transition**

ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास से एक प्रेजेंटेशन लोड करें और [getSlideShowTransition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getSlideShowTransition) के माध्यम से स्लाइड की ट्रांज़िशन सेटिंग्स तक पहुँचें। [TransitionType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/transitiontype/) एनेमरेशन के मान के साथ [setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setType) का उपयोग करके ट्रांज़िशन प्रकार सेट करें, फिर प्रेजेंटेशन सहेजें।

निम्न उदाहरण पहला स्लाइड पर Circle ट्रांज़िशन और दूसरे पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Add Advanced Slide Transition**

आप कॉन्फ़िगर कर सकते हैं कि स्लाइड स्क्रीन पर कितनी देर रहती है और क्या माउस क्लिक स्लाइड शो को आगे बढ़ाता है। निम्न विधियाँ इस व्यवहार को नियंत्रित करती हैं:

- [setAdvanceOnClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) दर्शक को माउस क्लिक करके आगे बढ़ने की अनुमति देती है।
- [setAdvanceAfter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) स्वचालित आगे बढ़ने को सक्षम करती है।
- [setAdvanceAfterTime](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) स्वचालित आगे बढ़ने से पहले का विलंब (मिलिसेकंड में) निर्दिष्ट करता है।

क्लिक और टाइमर दोनों को सक्षम करें ताकि दर्शक क्लिक से या टाइमर के इंतजार से आगे बढ़ सके। केवल टाइमर का उपयोग करने के लिए, [setAdvanceOnClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) को `False` पास करें। विलंब यह नियंत्रित करता है कि स्लाइड शो कब आगे बढ़ेगा; यह दृश्य ट्रांज़िशन प्रभाव की अवधि निर्धारित नहीं करता।

यह उदाहरण पहले तीन स्लाइडों को विभिन्न प्रभाव देता है और क्रमशः 3, 5 और 7 सेकंड के बाद स्वचालित आगे बढ़ने को सक्षम करता है। माउस क्लिक भी इन स्लाइडों को आगे बढ़ा सकता है। कम से कम तीन स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

यह जांचने के लिए कि टाइम्ड आगे बढ़ना सक्षम है या नहीं, [getAdvanceAfter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) को कॉल करें। केवल संग्रहीत विलंब यह संकेत नहीं देता कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक विलंब वाली स्लाइडों के लिए स्वचालित आगे बढ़ने को निष्क्रिय करता है। उन स्लाइडों के लिए माउस क्लिक को सक्षम करता है और अद्यतन सेटिंग्स सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Control Transition Timing Precisely**

[setDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setDuration) का उपयोग करके ट्रांज़िशन प्रभाव की सटीक लंबाई (मिलिसेकंड में) निर्दिष्ट करें। स्लाइड का [getSlideShowTransition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getSlideShowTransition) मेथड इन सेटिंग्स को [SlideShowTransition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/) के माध्यम से उजागर करता है:

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setDuration) | ट्रांज़िशन प्रभाव की स्वयं की अवधि (मिलिसेकंड) सेट करता है। |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | स्लाइड के स्वचालित आगे बढ़ने से पहले का विलंब (मिलिसेकंड) सेट करता है। इसे सक्रिय करने के लिए [setAdvanceAfter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) को `True` पास करें। |
| [setSpeed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/transitionspeed/) से एक पूर्वनिर्धारित गति श्रेणी (Slow, Medium, Fast) चुनता है। यह तब उपयोग किया जाता है जब सटीक अवधि निर्दिष्ट नहीं की गई हो। |

[setDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setDuration) केवल ट्रांज़िशन प्रभाव को नियंत्रित करता है; यह यह निर्धारित नहीं करता कि स्लाइड कितनी देर तक दिखाई देती रहे। स्वचालित आगे बढ़ने के विलंब को अलग से कॉन्फ़िगर करें। जब स्पष्ट अवधि सेट नहीं होती, तब Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#getSpeed) मान के आधार पर प्रभाव अवधि निर्धारित करता है।

### **Apply the Same Duration to Every Slide**

समान गति बनाए रखने के लिए, प्रत्येक स्लाइड पर समान प्रभाव और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलिसेकंड की अवधि देता है। यह स्वचालित आगे बढ़ने को 5,000 मिलिसेकंड के बाद सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ने को निष्क्रिय करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # इफ़ेक्ट अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ने को कॉन्फ़िगर करें।
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Set Different Durations for Individual Slides**

विभिन्न स्लाइडें विभिन्न प्रभाव अवधि का उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए छोटा ट्रांज़िशन और सेक्शन परिचय के लिए लंबा ट्रांज़िशन उपयोग करें। यह उदाहरण प्रथम स्लाइड को 500 मिलिसेकंड और द्वितीय स्लाइड को 1,200 मिलिसेकंड की अवधि देता है। कम से कम दो स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Coordinate Transitions with Animated Output**

जब आप एक [animated GIF](/slides/hi/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/python-java/export-to-html5/), या [video](/slides/hi/python-java/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि इच्छित गति से मेल खा सके। उदाहरण के लिए, दृश्यों के बीच 600 मिलिसेकंड का फेड उपयोग करें, और प्रत्येक स्लाइड की आगे बढ़ने की देरी को अलग से समायोजित करें ताकि उसकी वॉयसओवर या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिए, फ्रेम रेट को प्रभाव अवधि के साथ समन्वयित करें: 600 मिलिसेकंड 30 fps पर 18 फ्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में एनीमेटेड ट्रांज़िशन को सक्षम करें। चुने गए निर्यात स्वरूप के समर्थित प्रभाव और टाइमिंग विकल्पों की जाँच करें, और सिंक्रनाइज़ेशन की पुष्टि करने के लिए आउटपुट का पूर्वावलोकन करें।

### **Read an Existing Transition Duration**

संशोधित करने से पहले वर्तमान ट्रांज़िशन अवधि जानने के लिए [getDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#getDuration) को कॉल करें। `-1` का मान संकेत देता है कि कोई स्पष्ट अवधि सेट नहीं है; गैर‑नकारात्मक मान मिलिसेकंड में संग्रहीत अवधि दर्शाता है। यह अनसेट मान गणना किए गए प्लेबैक अवधि का प्रतिनिधित्व नहीं करता: Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#getSpeed) मान के आधार पर अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से एक डिफ़ॉल्ट अवधि प्रारंभ हो सकती है, इसलिए पहले मूल सेटिंग्स की जाँच करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Morph Transition**

Morph ट्रांज़िशन लगातार दो स्लाइडों में वस्तुओं के बीच होने वाले बदलावों को एनीमेट करता है। एक सरल Morph प्रभाव बनाना है तो एक स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को ले जाएँ या आकार बदलें, और दूसरी स्लाइड पर Morph ट्रांज़िशन लागू करें। इससे संबंधित वस्तुएँ अपने मूल और संशोधित स्थितियों के बीच एनीमेट होंगी।

निम्न उदाहरण एक टेक्स्ट आयत के साथ एक स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति और आकार बदलता है। फिर द्वितीय स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/transitiontype/) एनेमरेशन से Morph चुनता है। Morph का समर्थन करने वाले प्रेजेंटेशन व्यूअर में सहेजी गई फ़ाइल खोलें ताकि स्लाइड शो के दौरान प्रभाव देखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Morph Transition Types**

[TransitionMorphType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/transitionmorphtype/) एनेमरेशन यह नियंत्रित करता है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [ByObject](https://reference.aspose.com/slides/hi/python-java/aspose.slides/transitionmorphtype/#ByObject) प्रत्येक आकार को एक संपूर्ण वस्तु के रूप में मानता है।
- [ByWord](https://reference.aspose.com/slides/hi/python-java/aspose.slides/transitionmorphtype/#ByWord) जहां संभव हो शब्दों को मिलाकर पाठ को एनीमेट करता है।
- [ByChar](https://reference.aspose.com/slides/hi/python-java/aspose.slides/transitionmorphtype/#ByChar) जहां संभव हो अक्षरों को मिलाकर पाठ को एनीमेट करता है।

Morph चुनने के लिए [setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setType) का उपयोग करें, फिर [getValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#getValue) तक पहुँचें। प्राप्त मान फिर [MorphTransition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/morphtransition/) क्लास का एक उदाहरण होता है, जिसकी [setMorphType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/morphtransition/#setMorphType) मेथड मिलान मोड चुनती है।

यह उदाहरण पिछले अनुभाग में बनाए गए प्रेजेंटेशन को खोलता है और दूसरी स्लाइड को शब्द‑आधारित Morph एनीमेशन के लिए कॉन्फ़िगर करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Set Transition Effects**

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या क्या प्रभाव काली स्क्रीन से शुरू होता है। उपलब्ध विकल्प इस पर निर्भर करते हैं कि आप [setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setType) के साथ कौन सा ट्रांज़िशन चुनते हैं। पहले प्रकार सेट करें, फिर [getValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#getValue) से उपयुक्त क्लास का उपयोग करें।

निम्न उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [OptionalBlackTransition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/optionalblacktransition/) के माध्यम से [setFromBlack](https://reference.aspose.com/slides/hi/python-java/aspose.slides/optionalblacktransition/#setFromBlack) को कॉल करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति को नियंत्रित कर सकता हूँ?**

हाँ। जब आपको मिलिसेकंड में सटीक प्रभाव अवधि चाहिए तो [setDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setDuration) को प्राथमिकता दें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/transitionspeed/) श्रेणी (Slow, Medium, Fast) पर्याप्त हो और कोई स्पष्ट अवधि सेट न की गई हो तो [setSpeed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setSpeed) का उपयोग करें। ये सेटिंग्स ट्रांज़िशन प्रभाव को स्वचालित आगे बढ़ने के विलंब से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन में ऑडियो जोड़ सकता हूँ और उसे लूप करा सकता हूँ?**

हाँ। [setSound](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setSound) के साथ एंबेडेड ऑडियो असाइन करें, [TransitionSoundMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/transitionsoundmode/) एनेमरेशन से `StartSound` को [setSoundMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setSoundMode) में पास करें, और `True` के साथ [setSoundLoop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setSoundLoop) को सक्षम करें। ऑडियो स्लाइड शो में अगले साउंड इवेंट तक लूप करेगा।

**हर स्लाइड पर समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेजेंटेशन के [getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) संग्रह पर लूप चलाएँ और प्रत्येक स्लाइड के ट्रांज़िशन के लिए समान मान के साथ [setType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#setType) को कॉल करें। उसी लूप में किसी भी टाइमिंग और प्रभाव विकल्प को सेट करें ताकि सभी स्लाइडों में व्यवहार समान रहे।

**मैं कैसे जांच सकता हूँ कि किसी स्लाइड में वर्तमान में कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [getSlideShowTransition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getSlideShowTransition) परिणाम पर [getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowtransition/#getType) को कॉल करें। यह [TransitionType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/transitiontype/) एनेमरेशन से एक मान लौटाता है; `None_` का अर्थ है कि कोई ट्रांज़िशन प्रभाव लागू नहीं हुआ है।