---
title: Catatan
type: docs
weight: 240
url: /id/php-java/examples/elements/note/
keywords:
- catatan
- menambah slide catatan
- mengakses slide catatan
- menghapus slide catatan
- memperbarui teks catatan
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Menambahkan, membaca, mengedit, dan mengekspor catatan pembicara dalam PHP dengan Aspose.Slides: memformat teks, mengelola catatan per slide, dan mengontrol visibilitas di PowerPoint dan OpenDocument."
---
Menampilkan cara menambah, membaca, menghapus, dan memperbarui slide catatan menggunakan **Aspose.Slides for PHP via Java**.

## **Menambahkan Slide Catatan**

Buat slide catatan dan tetapkan teks ke dalamnya.

```php
function addNote() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("My note");

        $presentation->save("note.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mengakses Slide Catatan**

Baca teks dari slide catatan yang ada.

```php
function accessNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notes = $notesSlide->getNotesTextFrame()->getText();
    } finally {
        $presentation->dispose();
    }
}
```

## **Menghapus Slide Catatan**

Hapus slide catatan yang terkait dengan sebuah slide.

```php
function removeNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getNotesSlideManager()->removeNotesSlide();

        $presentation->save("note_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Memperbarui Teks Catatan**

Ubah teks slide catatan.

```php
function updateNoteText() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("Updated");

        $presentation->save("note_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```