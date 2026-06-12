---
title: Sectie
type: docs
weight: 90
url: /nl/php-java/examples/elements/section/
keywords:
- sectie
- dia sectie
- sectie toevoegen
- sectie openen
- sectie verwijderen
- sectie hernoemen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer dia-secties in PHP met Aspose.Slides: maak, hernoem, hersorteer eenvoudig, verplaats dia's tussen secties en beheer de zichtbaarheid voor PPT, PPTX en ODP."
---
Voorbeelden voor het beheren van presentatiesecties — toevoegen, openen, verwijderen en hernoemen via code met **Aspose.Slides for PHP via Java**.

## **Sectie toevoegen**

Maak een sectie die begint op een specifieke dia.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Geef de dia op die het begin van de sectie aangeeft.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Sectie openen**

Lees sectie‑informatie uit een presentatie.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Toegang tot een sectie via index.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Sectie verwijderen**

Verwijder een eerder toegevoegde sectie.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Verwijder de sectie.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Sectie hernoemen**

Verander de naam van een bestaande sectie.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```