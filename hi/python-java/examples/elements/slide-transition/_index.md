---
title: स्लाइड ट्रांज़िशन
type: docs
weight: 110
url: /hi/python-java/examples/elements/slide-transition/
keywords:
- कोड उदाहरण
- स्लाइड ट्रांज़िशन
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java कोड उदाहरणों के साथ स्लाइड ट्रांज़िशन लागू करने और हटाने, तथा PPT, PPTX, और ODP प्रस्तुतियों के लिए स्वचालित स्लाइड आगे बढ़ने के टाइमिंग सेट करने के लिए।"
---
यह लेख **Aspose.Slides for Python via Java** के साथ स्लाइड ट्रांज़िशन इफ़ेक्ट और टाइमिंग लागू करने को दर्शाता है।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार इंस्टॉल करें। प्रत्येक उदाहरण `asposeslides` को JVM शुरू करने से पहले इम्पोर्ट करता है, फिर JVM चलने के बाद API इम्पोर्ट करता है।

## **Add a Slide Transition**

पहले स्लाइड पर फेड ट्रांज़िशन इफ़ेक्ट लागू करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # फेड ट्रांज़िशन लागू करें.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Access a Slide Transition**

स्लाइड को वर्तमान में असाइन किए गए ट्रांज़िशन प्रकार को पढ़ें।

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # ट्रांज़िशन प्रकार तक पहुंचें.
finally:
    presentation.dispose()
```

## **Remove a Slide Transition**

किसी भी ट्रांज़िशन इफ़ेक्ट को साफ़ करें। JPype जावा कॉन्स्टेंट `None` को `None_` के रूप में उजागर करता है क्योंकि `None` पाइथन में एक रिज़र्व्ड शब्द है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # ट्रांज़िशन इफ़ेक्ट हटाएँ.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Set Transition Duration**

स्लाइड के स्वतः आगे बढ़ने से पहले उसकी प्रदर्शित समयावधी निर्धारित करें। यह उदाहरण दो सेकंड के बाद आगे बढ़ता है और माउस क्लिक से भी आगे बढ़ने की अनुमति देता है। यह टाइमिंग स्लाइड के आगे बढ़ने को नियंत्रित करती है, ट्रांज़िशन इफ़ेक्ट की गति को नहीं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # मिलीसेकंड में।
finally:
    presentation.dispose()
```