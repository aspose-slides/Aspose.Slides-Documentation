---
title: एनिमेशन
type: docs
weight: 100
url: /hi/python-java/examples/elements/animation/
keywords:
- कोड उदाहरण
- एनिमेशन
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java एनीमेशन उदाहरणों का अन्वेषण करें: PPT, PPTX, और ODP प्रस्तुतियों में प्रभाव जोड़ें, पहुँचें, हटाएँ, और क्रमबद्ध करें।"
---
यह लेख सरल एनीमेशन बनाने और उनका क्रम प्रबंधित करने का प्रदर्शन करता है **Aspose.Slides for Python via Java** का उपयोग करके।

पैकेज को स्थापित करने के लिए जैसा कि [स्थापना](/slides/hi/python-java/installation/) में बताया गया है, स्थापित करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` को इम्पोर्ट करता है, फिर JVM चलने के बाद API को इम्पोर्ट करता है।

## **एनिमेशन जोड़ें**

एक आयताकार आकृति बनाएं और क्लिक पर ट्रिगर होने वाले फ़ेड इफ़ेक्ट को लागू करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)

    # फ़ेड प्रभाव लागू करें।
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
finally:
    presentation.dispose()
```

## **एनिमेशन पहुँचें**

स्लाइड टाइमलाइन से पहला एनीमेशन इफ़ेक्ट पुनर्प्राप्त करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    # पहले एनीमेशन प्रभाव तक पहुँचें।
    effect = slide.getTimeline().getMainSequence().get_Item(0)
    print("Effect type:", effect.getType())
finally:
    presentation.dispose()
```

## **एनिमेशन हटाएँ**

क्रम से एक एनीमेशन इफ़ेक्ट हटाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    # प्रभाव हटाएँ।
    slide.getTimeline().getMainSequence().remove(effect)
finally:
    presentation.dispose()
```

## **एनिमेशन क्रमित करें**

कई इफ़ेक्ट जोड़ें और एनीमेशन के क्रम को नियंत्रित करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Ellipse, 200, 50, 100, 100)

    sequence = slide.getTimeline().getMainSequence()
    sequence.addEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
    sequence.addEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
finally:
    presentation.dispose()
```