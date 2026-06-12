---
title: Catatan
type: docs
weight: 240
url: /id/python-net/examples/elements/note/
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
- Python
- Aspose.Slides
description: "Menambahkan, membaca, mengedit, dan mengekspor catatan pembicara di Python dengan Aspose.Slides: memformat teks, mengelola catatan per slide, dan mengontrol visibilitas di PowerPoint dan OpenDocument."
---
Menampilkan cara menambah, membaca, menghapus, dan memperbarui slide catatan menggunakan **Aspose.Slides for Python via .NET**.

## **Tambahkan Slide Catatan**

Buat slide catatan dan tetapkan teks padanya.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Slide Catatan**

Baca teks dari slide catatan yang ada.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Hapus Slide Catatan**

Hapus slide catatan yang terkait dengan sebuah slide.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Hapus slide catatan.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Perbarui Teks Catatan**

Ubah teks slide catatan.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Perbarui teks catatan.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```