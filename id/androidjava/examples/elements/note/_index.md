---
title: Catatan
type: docs
weight: 240
url: /id/androidjava/examples/elements/note/
keywords:
- contoh kode
- catatan
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Bekerja dengan catatan slide di Aspose.Slides untuk Android: menambahkan, membaca, mengedit, dan mengekspor catatan pembicara dalam format PPT, PPTX, dan ODP menggunakan contoh Java yang jelas."
---
Artikel ini menunjukkan cara menambahkan, membaca, menghapus, dan memperbarui slide catatan menggunakan **Aspose.Slides for Android via Java**.

## **Menambahkan Slide Catatan**

Buat slide catatan dan tetapkan teks ke dalamnya.

```java
static void addNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("My note");
    } finally {
        presentation.dispose();
    }
}
```

## **Mengakses Slide Catatan**

Baca teks dari slide catatan yang ada.

```java
static void accessNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        String notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Slide Catatan**

Hapus slide catatan yang terkait dengan slide.

```java
static void removeNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().removeNotesSlide();
    } finally {
        presentation.dispose();
    }
}
```

## **Memperbarui Teks Catatan**

Ubah teks pada slide catatan.

```java
static void updateNoteText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Old");
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Updated");
    } finally {
        presentation.dispose();
    }
}
```