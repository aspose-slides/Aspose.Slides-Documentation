---
title: स्लाइड ट्रांज़िशन
type: docs
weight: 110
url: /hi/python-net/examples/elements/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन तक पहुँचें
- स्लाइड ट्रांज़िशन हटाएँ
- ट्रांज़िशन अवधि
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में स्लाइड ट्रांज़िशन नियंत्रित करें: प्रकार, गति, ध्वनि और टाइमिंग चुनें ताकि PPT, PPTX और ODP में प्रस्तुतियों को संवार सकें।"
---
**Aspose.Slides for Python via .NET** के साथ स्लाइड ट्रांज़िशन इफ़ेक्ट और टाइमिंग लागू करने का प्रदर्शन करता है।

## **स्लाइड ट्रांज़िशन जोड़ें**

पहली स्लाइड पर एक फ़ेड ट्रांज़िशन इफ़ेक्ट लागू करें।

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # फ़ेड ट्रांज़िशन लागू करें।
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड ट्रांज़िशन तक पहुँचें**

स्लाइड को वर्तमान में सौंपे गये ट्रांज़िशन प्रकार को पढ़ें।

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # ट्रांज़िशन प्रकार तक पहुँचें।
        transition_type = slide.slide_show_transition.type
```

## **स्लाइड ट्रांज़िशन हटाएँ**

ट्रांज़िशन प्रकार को `NONE` सेट करके किसी भी ट्रांज़िशन इफ़ेक्ट को साफ़ करें।

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # NONE सेट करके ट्रांज़िशन हटाएँ।
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ट्रांज़िशन अवधि सेट करें**

स्लाइड को स्वचालित रूप से आगे बढ़ने से पहले कितनी देर तक प्रदर्शित किया जाए, यह निर्दिष्ट करें।

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # मिलीसेकंड में।

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```