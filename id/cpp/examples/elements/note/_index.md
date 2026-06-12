---
title: Catatan
type: docs
weight: 240
url: /id/cpp/examples/elements/note/
keywords:
- contoh kode
- catatan
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Bekerja dengan catatan slide di Aspose.Slides for C++: menambahkan, membaca, menyunting, dan mengekspor catatan pembicara dalam format PPT, PPTX, dan ODP menggunakan contoh C++ yang jelas."
---
Artikel ini menunjukkan cara menambahkan, membaca, menghapus, dan memperbarui slide catatan menggunakan **Aspose.Slides for C++**.

## **Menambahkan Slide Catatan**

Buat slide catatan dan tetapkan teks padanya.

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

## **Mengakses Slide Catatan**

Baca teks dari slide catatan yang ada.

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

## **Menghapus Slide Catatan**

Hapus slide catatan yang terkait dengan sebuah slide.

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

## **Memperbarui Teks Catatan**

Ubah teks slide catatan.

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