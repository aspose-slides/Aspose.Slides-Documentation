---
title: Abschnitt
type: docs
weight: 90
url: /de/php-java/examples/elements/section/
keywords:
- Abschnitt
- Folienabschnitt
- Abschnitt hinzufügen
- Abschnitt abrufen
- Abschnitt entfernen
- Abschnitt umbenennen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte in PHP mit Aspose.Slides: Erstellen, umbenennen, einfach neu anordnen, Folien zwischen Abschnitten verschieben und die Sichtbarkeit für PPT, PPTX und ODP steuern."
---
Beispiele für die Verwaltung von Präsentationsabschnitten—Hinzufügen, Zugreifen, Entfernen und Umbenennen programmgesteuert mit **Aspose.Slides for PHP via Java**.

## **Abschnitt hinzufügen**

Erstellen Sie einen Abschnitt, der an einer bestimmten Folie beginnt.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Geben Sie die Folie an, die den Beginn des Abschnitts markiert.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Abschnitt abrufen**

Lesen Sie Abschnittsinformationen aus einer Präsentation.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Zugriff auf einen Abschnitt nach Index.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Abschnitt entfernen**

Löschen Sie einen zuvor hinzugefügten Abschnitt.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Entferne den Abschnitt.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Abschnitt umbenennen**

Ändern Sie den Namen eines bestehenden Abschnitts.

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