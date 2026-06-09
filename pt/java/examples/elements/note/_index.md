---
title: Nota
type: docs
weight: 240
url: /pt/java/examples/elements/note/
keywords:
- exemplo de código
- nota
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Trabalhe com notas de slides no Aspose.Slides for Java: adicione, leia, edite e exporte notas do apresentador em PPT, PPTX e ODP usando exemplos claros em Java."
---
Este artigo demonstra como adicionar, ler, remover e atualizar slides de notas usando **Aspose.Slides for Java**.

## **Adicionar um Slide de Notas**

Crie um slide de notas e atribua texto a ele.

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

## **Acessar um Slide de Notas**

Leia o texto de um slide de notas existente.

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

## **Remover um Slide de Notas**

Remova o slide de notas associado a um slide.

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

## **Atualizar Texto das Notas**

Altere o texto de um slide de notas.

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