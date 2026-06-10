---
title: Megjegyzés
type: docs
weight: 240
url: /hu/androidjava/examples/elements/note/
keywords:
- kód példa
- jegyzet
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Munka a diák jegyzeteivel az Aspose.Slides for Android-ban: jegyzetek hozzáadása, olvasása, szerkesztése és előadójegyzetek exportálása PPT, PPTX és ODP formátumban, világos Java példákkal."
---
Ez a cikk bemutatja, hogyan lehet hozzáadni, olvasni, eltávolítani és frissíteni a jegyzetdiákat a **Aspose.Slides for Android via Java** használatával.

## **Jegyzetdia hozzáadása**

Hozzon létre egy jegyzetdiát, és rendelje hozzá a szöveget.

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

## **Jegyzetdia elérése**

Olvassa be a szöveget egy meglévő jegyzetdiából.

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

## **Jegyzetdia eltávolítása**

Távolítsa el a diára vonatkozó jegyzetdiát.

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

## **Jegyzet szövegének frissítése**

Módosítsa egy jegyzetdia szövegét.

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