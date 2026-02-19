---
title: Note
type: docs
weight: 240
url: /fr/androidjava/examples/elements/note/
keywords:
- exemple de code
- note
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Travaillez avec les notes de diapositives dans Aspose.Slides for Android : ajoutez, lisez, modifiez et exportez les notes du présentateur au format PPT, PPTX et ODP à l'aide d'exemples Java clairs."
---
Cet article montre comment ajouter, lire, supprimer et mettre à jour des diapositives de notes en utilisant **Aspose.Slides for Android via Java**.

## **Ajouter une diapositive de notes**

Créez une diapositive de notes et affectez du texte à celle-ci.

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

Lisez le texte d'une diapositive de notes existante.

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

Modifiez le texte d'une diapositive de notes.

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