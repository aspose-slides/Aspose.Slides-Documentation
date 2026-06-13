---
title: इंक
type: docs
weight: 180
url: /hi/python-net/examples/elements/ink/
keywords:
- इंक
- इंक तक पहुंच
- इंक हटाएँ
- कोड उदाहरण
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- पायथन
- Aspose.Slides
description: "Python में Aspose.Slides के साथ स्लाइड्स पर डिजिटल इंक को संभालें: पेन स्ट्रोक जोड़ें, पाथ संपादित करें, रंग और चौड़ाई सेट करें, और PowerPoint और OpenDocument के लिए परिणाम निर्यात करें।"
---
मौजूदा इंक आकृतियों तक पहुँचने और उन्हें **Aspose.Slides for Python via .NET** का उपयोग करके हटाने के उदाहरण प्रदान करता है।

> ❗ **ध्यान दें:** इंक आकृतियां विशेष उपकरणों से उपयोगकर्ता इनपुट का प्रतिनिधित्व करती हैं। Aspose.Slides प्रोग्रामmatically नई इंक स्ट्रोक नहीं बना सकता, लेकिन आप मौजूदा इंक को पढ़ और संशोधित कर सकते हैं।

## **इंक तक पहुँच**

स्लाइड से पहला इंक आकार प्राप्त करें।

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **इंक हटाएँ**

स्लाइड से इंक आकार हटाएँ।

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहली आकृति एक Ink ऑब्जेक्ट है.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```