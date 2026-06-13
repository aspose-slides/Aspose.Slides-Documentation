---
title: नोट
type: docs
weight: 240
url: /hi/python-net/examples/elements/note/
keywords:
- नोट
- नोट्स स्लाइड जोड़ें
- नोट्स स्लाइड तक पहुंचें
- नोट्स स्लाइड हटाएँ
- नोट्स टेक्स्ट अपडेट करें
- कोड उदाहरण
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रेजेंटेशन
- पायथन
- Aspose.Slides
description: "Python में Aspose.Slides के साथ स्पीकर नोट्स जोड़ें, पढ़ें, संपादित करें और निर्यात करें: टेक्स्ट फ़ॉर्मेट करें, स्लाइड प्रति नोट्स प्रबंधित करें, और PowerPoint और OpenDocument में दृश्यता नियंत्रित करें।"
---
दिखाता है कि **Aspose.Slides for Python via .NET** का उपयोग करके नोट्स स्लाइड को कैसे जोड़ें, पढ़ें, हटाएँ और अपडेट करें।

## **एक नोट्स स्लाइड जोड़ें**

एक नोट्स स्लाइड बनाएं और उसमें टेक्स्ट असाइन करें।

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **नोट्स स्लाइड तक पहुंचें**

मौजूदा नोट्स स्लाइड से टेक्स्ट पढ़ें।

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **एक नोट्स स्लाइड हटाएँ**

एक स्लाइड से जुड़ी नोट्स स्लाइड को हटाएँ।

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # नोट्स स्लाइड हटाएँ।
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **नोट्स टेक्स्ट अपडेट करें**

नोट्स स्लाइड का टेक्स्ट बदलें।

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # नोट टेक्स्ट अपडेट करें।
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```