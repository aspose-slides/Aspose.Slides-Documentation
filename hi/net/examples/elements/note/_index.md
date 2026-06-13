---
title: नोट
type: docs
weight: 240
url: /hi/net/examples/elements/note/
keywords:
- नोट
- नोट्स स्लाइड जोड़ें
- नोट्स स्लाइड तक पहुँचें
- नोट्स स्लाइड हटाएँ
- नोट्स टेक्स्ट अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में स्लाइड नोट्स के साथ कार्य करें: PPT, PPTX और ODP में स्पष्ट C# उदाहरणों का उपयोग करके नोट्स जोड़ें, पढ़ें, संपादित करें और निर्यात करें।"
---
यह लेख Aspose.Slides for .NET का उपयोग करके नोट्स स्लाइड्स को जोड़ने, पढ़ने, हटाने और अपडेट करने का प्रदर्शन करता है।

## **नोट्स स्लाइड जोड़ें**

एक नोट्स स्लाइड बनाएँ और उसमें टेक्स्ट सौंपें।

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **नोट्स स्लाइड तक पहुँचें**

एक मौजूदा नोट्स स्लाइड से टेक्स्ट पढ़ें।

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **नोट्स स्लाइड हटाएँ**

स्लाइड से संबंधित नोट्स स्लाइड को हटाएँ।

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