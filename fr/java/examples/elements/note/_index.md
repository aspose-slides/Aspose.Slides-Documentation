---
title: Note
type: docs
weight: 240
url: /fr/java/examples/elements/note/
keywords:
- exemple de code
- note
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Travaillez avec les notes de diapositive dans Aspose.Slides for Java : ajoutez, lisez, modifiez et exportez les notes du présentateur dans PPT, PPTX et ODP à l’aide d’exemples Java clairs."
---
Cet article montre comment ajouter, lire, supprimer et mettre à jour les diapositives de notes en utilisant **Aspose.Slides for Java**.

## **Ajouter une diapositive de notes**

Créez une diapositive de notes et attribuez‑lui du texte.

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

## **Accéder à une diapositive de notes**

Lisez le texte d’une diapositive de notes existante.

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

## **Supprimer une diapositive de notes**

Supprimez la diapositive de notes associée à une diapositive.

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

## **Mettre à jour le texte des notes**

Modifiez le texte d’une diapositive de notes.

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