---
title: Catatan
type: docs
weight: 240
url: /id/net/examples/elements/note/
keywords:
- catatan
- menambahkan slide catatan
- mengakses slide catatan
- menghapus slide catatan
- memperbarui teks catatan
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Bekerja dengan catatan slide di Aspose.Slides untuk .NET: menambahkan, membaca, mengedit, dan mengekspor catatan pembicara dalam format PPT, PPTX, dan ODP menggunakan contoh C# yang jelas."
---
Artikel ini menunjukkan cara menambahkan, membaca, menghapus, dan memperbarui slide catatan menggunakan **Aspose.Slides for .NET**.

## **Menambahkan Slide Catatan**

Buat slide catatan dan tetapkan teks ke dalamnya.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Mengakses Slide Catatan**

Baca teks dari slide catatan yang ada.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Menghapus Slide Catatan**

Hapus slide catatan yang terkait dengan sebuah slide.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Memperbarui Teks Catatan**

Ubah teks pada slide catatan.

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