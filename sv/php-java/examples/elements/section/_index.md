---
title: Sektion
type: docs
weight: 90
url: /sv/php-java/examples/elements/section/
keywords:
- sektion
- bildsektion
- lägg till sektion
- komma åt sektion
- ta bort sektion
- byta namn på sektion
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera bildsektioner i PHP med Aspose.Slides: skapa, byta namn, enkelt ordna om, flytta bilder mellan sektioner och kontrollera synlighet för PPT, PPTX och ODP."
---
Exempel på hantering av presentationssektioner—lägga till, komma åt, ta bort och byta namn på dem programatiskt med **Aspose.Slides for PHP via Java**.

## **Lägg till en sektion**

Skapa en sektion som startar på en specifik bild.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Ange den bild som markerar början på sektionen.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Kom åt en sektion**

Läs sektionens information från en presentation.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Åtkomst till en sektion via index.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Ta bort en sektion**

Ta bort en tidigare tillagd sektion.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Ta bort sektionen.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Byt namn på en sektion**

Ändra namnet på en befintlig sektion.

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