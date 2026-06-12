---
title: Snímek
type: docs
weight: 10
url: /cs/php-java/examples/elements/slide/
keywords:
- snímek
- přidat snímek
- přístup ke snímku
- index snímku
- klonovat snímek
- změnit pořadí snímků
- odstranit snímek
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte snímky v PHP pomocí Aspose.Slides: vytvářejte, klonujte, měňte pořadí, skrývejte, nastavujte pozadí a velikost, aplikujte přechody a exportujte pro PowerPoint a OpenDocument."
---
Tento článek poskytuje sérii příkladů, které demonstrují, jak pracovat s snímy pomocí **Aspose.Slides for PHP via Java**. Naučíte se, jak přidávat, přistupovat, klonovat, měnit pořadí a odstraňovat snímky pomocí třídy `Presentation`.

Každý příklad níže obsahuje stručné vysvětlení následované úryvkem kódu v PHP.

## **Přidat snímek**

Pro přidání nového snímku musíte nejprve zvolit rozvržení. V tomto příkladu používáme rozvržení `Blank` a přidáváme prázdný snímek do prezentace.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Každý snímek je založen na rozvržení, které samo vychází z hlavního snímku.
        // Použijte rozvržení Blank k vytvoření nového snímku.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Přidejte nový prázdný snímek pomocí vybraného rozvržení.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip:** Každé rozvržení snímku je odvozeno od hlavního snímku, který určuje celkový design a strukturu zástupných objektů. Obrázek níže ukazuje, jak jsou hlavní snímky a jejich související rozvržení v PowerPointu uspořádány.

![Vztah mezi hlavním snímkem a rozvržením](master-layout-slide.png)

## **Přístup k snímkům podle indexu**

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Přístup ke snímku podle indexu.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Klonovat snímek**

Tento příklad ukazuje, jak klonovat existující snímek. Zklonovaný snímek je automaticky přidán na konec kolekce snímků.

```php
function cloneSlide() {
    // Ve výchozím nastavení obsahuje prezentace jeden prázdný snímek.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zklonujte první snímek; bude přidán na konec prezentace.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // Index zklonovaného snímku je 1 (druhý snímek v prezentaci).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Změna pořadí snímků**

Můžete změnit pořadí snímků přesunutím jednoho na nový index. V tomto případě přesuneme snímek na první pozici.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Přesuňte snímek na první pozici (ostatní se posunou dolů).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranit snímek**

Pro odstranění snímku jej jednoduše odkažte a zavolejte `remove`. Tento příklad odstraňuje snímky podle indexu i podle reference.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Odstraňte snímek podle indexu.
        $presentation->getSlides()->removeAt(0);

        // Odstraňte snímek podle reference.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```