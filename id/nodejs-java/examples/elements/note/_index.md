---
title: Catatan
type: docs
weight: 240
url: /id/nodejs-java/examples/elements/note/
keywords:
- contoh kode
- catatan
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Bekerja dengan catatan slide di Aspose.Slides untuk Node.js: tambahkan, baca, edit, dan ekspor catatan pembicara dalam PPT, PPTX, dan ODP menggunakan contoh JavaScript yang jelas."
---
Artikel ini menunjukkan cara menambahkan, membaca, menghapus, dan memperbarui slide catatan menggunakan **Aspose.Slides for Node.js via Java**.

## **Menambahkan Slide Catatan**

Buat slide catatan dan tetapkan teks padanya.

```js
function addNote() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().addNotesSlide();
        notesSlide.getNotesTextFrame().setText("My note");

        presentation.save("note.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengakses Slide Catatan**

Baca teks dari slide catatan yang ada.

```js
function accessNote() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().getNotesSlide();

        let notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Slide Catatan**

Hapus slide catatan yang terkait dengan sebuah slide.

```js
function removeNote() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getNotesSlideManager().removeNotesSlide();

        presentation.save("note_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Memperbarui Teks Catatan**

Ubah teks pada slide catatan.

```js
function updateNoteText() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().getNotesSlide();
        notesSlide.getNotesTextFrame().setText("Updated");

        presentation.save("note_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```