---
title: Nota
type: docs
weight: 240
url: /pt/php-java/examples/elements/note/
keywords:
- nota
- adicionar slide de notas
- acessar slide de notas
- remover slide de notas
- atualizar texto das notas
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Adicionar, ler, editar e exportar notas do apresentador em PHP com Aspose.Slides: formatar texto, gerenciar notas por slide e controlar a visibilidade no PowerPoint e no OpenDocument."
---
Mostra como adicionar, ler, remover e atualizar slides de notas usando **Aspose.Slides for PHP via Java**.

## **Adicionar um Slide de Notas**

Crie um slide de notas e atribua texto a ele.

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

## **Acessar um Slide de Notas**

Leia o texto de um slide de notas existente.

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

## **Remover um Slide de Notas**

Remova o slide de notas associado a um slide.

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

## **Atualizar Texto das Notas**

Altere o texto de um slide de notas.

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