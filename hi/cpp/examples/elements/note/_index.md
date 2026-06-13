---
title: नोट
type: docs
weight: 240
url: /hi/cpp/examples/elements/note/
keywords:
- कोड उदाहरण
- नोट
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में स्लाइड नोट्स के साथ काम करें: स्पष्ट C++ उदाहरणों का उपयोग करके PPT, PPTX, और ODP में स्पीकर नोट्स को जोड़ें, पढ़ें, संपादित करें और निर्यात करें।"
---
यह लेख **Aspose.Slides for C++** का उपयोग करके नोट्स स्लाइड को जोड़ने, पढ़ने, हटाने और अपडेट करने का प्रदर्शन करता है।

## **नोट्स स्लाइड जोड़ें**

एक नोट्स स्लाइड बनाएं और उसमें टेक्स्ट असाइन करें।

```cpp
static void AddNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"My note");

    presentation->Dispose();
}
```

## **नोट्स स्लाइड तक पहुंचें**

एक मौजूदा नोट्स स्लाइड से टेक्स्ट पढ़ें।

```cpp
static void AccessNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    auto notes = notesSlide->get_NotesTextFrame()->get_Text();

    presentation->Dispose();
}
```

## **नोट्स स्लाइड हटाएँ**

स्लाइड से जुड़ी नोट्स स्लाइड हटाएँ।

```cpp
static void RemoveNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->RemoveNotesSlide();

    presentation->Dispose();
}
```

## **नोट्स टेक्स्ट अपडेट करें**

नोट्स स्लाइड के टेक्स्ट को बदलें।

```cpp
static void UpdateNoteText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Old");
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Updated");

    presentation->Dispose();
}
```