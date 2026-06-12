---
title: Poznámka
type: docs
weight: 240
url: /cs/php-java/examples/elements/note/
keywords:
- poznámka
- přidat poznámkový snímek
- přístup k poznámkovému snímku
- odstranit poznámkový snímek
- aktualizovat text poznámky
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Přidávejte, čtěte, upravujte a exportujte řečnické poznámky v PHP pomocí Aspose.Slides: formátujte text, spravujte poznámky pro jednotlivé snímky a řiďte viditelnost v PowerPoint a OpenDocument."
---
Ukazuje, jak přidávat, číst, odstraňovat a aktualizovat poznámkové snímky pomocí **Aspose.Slides for PHP via Java**.

## **Přidat poznámkový snímek**

Vytvořte poznámkový snímek a přiřaďte mu text.

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

## **Přístup k poznámkovému snímku**

Přečtěte text z existujícího poznámkového snímku.

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

## **Odstranit poznámkový snímek**

Odstraňte poznámkový snímek přidružený k snímku.

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

## **Aktualizovat text poznámkového snímku**

Změňte text poznámkového snímku.

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