---
title: Sekce
type: docs
weight: 90
url: /cs/php-java/examples/elements/section/
keywords:
- sekce
- sekce snímku
- přidat sekci
- přístup k sekci
- odstranit sekci
- přejmenovat sekci
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte sekce snímků v PHP pomocí Aspose.Slides: snadno vytvářejte, přejmenovávejte, přeuspořádávejte, přesouvejte snímky mezi sekcemi a řiďte viditelnost pro PPT, PPTX a ODP."
---
Příklady pro správu sekcí prezentace — přidání, přístup, odstranění a přejmenování pomocí **Aspose.Slides for PHP via Java**.

## **Přidat sekci**

Vytvořte sekci, která začíná na konkrétním snímku.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Určete snímek, který označuje začátek sekce.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Přístup k sekci**

Načtěte informace o sekci z prezentace.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Přístup k sekci podle indexu.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranit sekci**

Odstraňte dříve přidanou sekci.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Odstraňte sekci.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Přejmenovat sekci**

Změňte název existující sekce.

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