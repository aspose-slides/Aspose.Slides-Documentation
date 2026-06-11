---
title: Anteckning
type: docs
weight: 240
url: /sv/java/examples/elements/note/
keywords:
- kodexempel
- anteckning
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Arbeta med bildanteckningar i Aspose.Slides för Java: lägg till, läs, redigera och exportera talaranteckningar i PPT, PPTX och ODP med tydliga Java-exempel."
---
Den här artikeln visar hur du lägger till, läser, tar bort och uppdaterar anteckningsbilder med **Aspose.Slides for Java**.

## **Lägg till en anteckningsbild**

Skapa en anteckningsbild och tilldela text till den.

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

## **Åtkomst till en anteckningsbild**

Läs text från en befintlig anteckningsbild.

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

## **Ta bort en anteckningsbild**

Ta bort anteckningsbilden som är kopplad till en bild.

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

## **Uppdatera anteckningstext**

Ändra texten i en anteckningsbild.

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