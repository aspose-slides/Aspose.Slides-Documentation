---
title: Not
type: docs
weight: 240
url: /tr/net/examples/elements/note/
aliases:
  - /net/examples/elements/elements/note/
keywords:
- not
- not slaytı ekle
- not slaytı eriş
- not slaytı kaldır
- not metnini güncelle
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te slayt notlarıyla çalışın: PPT, PPTX ve ODP'de net C# örnekleriyle not ekleyin, okuyun, düzenleyin ve dışa aktarın."
---
Bu makale, **Aspose.Slides for .NET** kullanarak not slaytlarını ekleme, okuma, kaldırma ve güncelleme işlemlerini gösterir.

## **Not Slaytı Ekle**

Bir not slaytı oluşturun ve ona metin atayın.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Not Slaytına Eriş**

Mevcut bir not slaytından metni okuyun.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Not Slaytı Kaldır**

Bir slayt ile ilişkili not slaytını kaldırın.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Not Metnini Güncelle**

Bir not slaytının metnini değiştirin.

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