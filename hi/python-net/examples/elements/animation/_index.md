---
title: एनीमेशन
type: docs
weight: 100
url: /hi/python-net/examples/elements/animation/
keywords:
- एनीमेशन
- एनीमेशन जोड़ें
- एनीमेशन तक पहुँचें
- एनीमेशन हटाएँ
- एनीमेशन क्रम
- कोड उदाहरण
- पॉवरपॉइंट
- ओपनडॉक्युमेंट
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में स्लाइड एनीमेशन का मास्टर: प्रभाव, समय‑सारणी और ट्रिगर को जोड़ें, संपादित करें, और हटाएँ ताकि PPT, PPTX और ODP में गतिशील प्रस्तुतियाँ बना सकें।"
---
सादे एनीमेशन बनाना और उनकी श्रृंखला को प्रबंधित करना **Aspose.Slides for Python via .NET** का उपयोग करके दिखाता है।

## **एनीमेशन जोड़ें**

एक आयताकार आकार बनाएं और क्लिक पर ट्रिगर होने वाला फेड इफ़ेक्ट लागू करें।

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # फ़ेड इन इफ़ेक्ट जोड़ें।
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **एनीमेशन तक पहुँचें**

स्लाइड टाइमलाइन से पहला एनीमेशन इफ़ेक्ट प्राप्त करें।

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # पहले एनीमेशन इफ़ेक्ट तक पहुँचें।
        effect = slide.timeline.main_sequence[0]
```

## **एनीमेशन हटाएँ**

श्रृंखला से एनीमेशन इफ़ेक्ट हटाएँ।

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि मुख्य क्रम में कम से कम एक प्रभाव है।
        effect = slide.timeline.main_sequence[0]

        # प्रभाव हटाएँ।
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **एनीमेशन क्रमबद्ध करें**

एकाधिक इफ़ेक्ट जोड़ें और दिखाएँ कि एनीमेशन किस क्रम में होते हैं।

```py
def sequence_animations():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 200, 50, 100, 100)

        sequence = slide.timeline.main_sequence
        sequence.add_effect(
            shape1,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)
        sequence.add_effect(
            shape2,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation_sequence.pptx", slides.export.SaveFormat.PPTX)
```