---
title: Jegyzet
type: docs
weight: 240
url: /hu/java/examples/elements/note/
keywords:
- kódpélda
- jegyzet
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Dolgozzon a diák jegyzeteivel az Aspose.Slides for Java-ban: adjon hozzá, olvasson, szerkesszen, és exportálja az előadói jegyzeteket PPT, PPTX és ODP formátumban, világos Java példákkal."
---
Ez a cikk bemutatja, hogyan adhatunk hozzá, olvashatunk, eltávolíthatunk és frissíthetünk jegyzetdiákat a **Aspose.Slides for Java** segítségével.

## **Jegyzetdia hozzáadása**

Hozzon létre egy jegyzetdiát, és adjon hozzá szöveget.

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

Olvassa el a szöveget egy meglévő jegyzetdiából.

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

Távolítsa el a diához tartozó jegyzetdiát.

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

Módosítsa a jegyzetdia szövegét.

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