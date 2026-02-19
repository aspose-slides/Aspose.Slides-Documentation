---
title: Notiz
type: docs
weight: 240
url: /de/java/examples/elements/note/
keywords:
- Codebeispiel
- Notiz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Arbeiten Sie mit Foliennotizen in Aspose.Slides für Java: Hinzufügen, Lesen, Bearbeiten und Exportieren von Sprecher-Notizen in PPT, PPTX und ODP mit klaren Java-Beispielen."
---
Dieser Artikel demonstriert, wie man Notizfolien hinzufügt, liest, entfernt und aktualisiert, indem man **Aspose.Slides for Java** verwendet.

## **Notizfolie hinzufügen**

Erstellen Sie eine Notizfolie und weisen Sie ihr Text zu.

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

## **Zugriff auf eine Notizfolie**

Lesen Sie den Text einer vorhandenen Notizfolie.

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

## **Entfernen einer Notizfolie**

Entfernen Sie die mit einer Folie verbundene Notizfolie.

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

## **Notiztext aktualisieren**

Ändern Sie den Text einer Notizfolie.

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