---
title: नोट
type: docs
weight: 240
url: /hi/net/examples/elements/note/
aliases:
  - /net/examples/elements/elements/note/
keywords:
- नोट
- स्लाइड नोट जोड़ें
- स्लाइड नोट तक पहुंचें
- स्लाइड नोट हटाएँ
- नोट्स टेक्स्ट अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में स्लाइड नोट्स के साथ कार्य करें: स्पष्ट C# उदाहरणों का उपयोग करके PPT, PPTX और ODP में स्पीकर नोट्स जोड़ें, पढ़ें, संपादित करें और निर्यात करें।"
---
यह लेख **Aspose.Slides for .NET** का उपयोग करके नोट्स स्लाइड को जोड़ने, पढ़ने, हटाने और अपडेट करने का तरीका दर्शाता है।

## **नोट्स स्लाइड जोड़ें**

एक नोट्स स्लाइड बनाएं और उसमें टेक्स्ट असाइन करें।

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **नोट्स स्लाइड तक पहुंचें**

मौजूदा नोट्स स्लाइड से टेक्स्ट पढ़ें।

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **नोट्स स्लाइड हटाएं**

स्लाइड से जुड़ी नोट्स स्लाइड को हटाएं।

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **नोट्स टेक्स्ट अपडेट करें**

नोट्स स्लाइड के टेक्स्ट को बदलें।

```csharp
static void UpdateNoteText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```