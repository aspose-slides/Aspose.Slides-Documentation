---
title: Sekcja
type: docs
weight: 90
url: /pl/php-java/examples/elements/section/
keywords:
- sekcja
- sekcja slajdu
- dodaj sekcję
- dostęp do sekcji
- usuń sekcję
- zmień nazwę sekcji
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów w PHP przy użyciu Aspose.Slides: twórz, zmieniaj nazwy, łatwo zmieniaj kolejność, przenoś slajdy między sekcjami oraz kontroluj widoczność w formatach PPT, PPTX i ODP."
---
Przykłady zarządzania sekcjami prezentacji — dodawanie, dostęp, usuwanie i zmienianie ich nazw programowo przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj sekcję**

Utwórz sekcję, która zaczyna się od określonego slajdu.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Określ slajd, który oznacza początek sekcji.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Uzyskaj dostęp do sekcji**

Odczytaj informacje o sekcji z prezentacji.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Uzyskaj dostęp do sekcji po indeksie.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Usuń sekcję**

Usuń wcześniej dodaną sekcję.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Usuń sekcję.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Zmień nazwę sekcji**

Zmień nazwę istniejącej sekcji.

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