---
title: Rozložení snímku
type: docs
weight: 20
url: /cs/php-java/examples/elements/layout-slide/
keywords:
- rozložení snímku
- přidat rozložení snímku
- přístup k rozložení snímku
- odstranit rozložení snímku
- nepoužité rozložení snímku
- klonovat rozložení snímku
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Použijte PHP k správě rozložení snímků pomocí Aspose.Slides: vytvářejte, aplikujte, klonujte, přejmenovávejte a přizpůsobujte zástupce a motivy v prezentacích pro PPT, PPTX a ODP."
---
This article demonstrates how to work with **Layout Slides** in Aspose.Slides for PHP via Java. A layout slide defines the design and formatting inherited by normal slides. You can add, access, clone, and remove layout slides, as well as clean up unused ones to reduce presentation size.

## **Přidat rozložení snímku**

You can create a custom layout slide to define reusable formatting. For example, you might add a text box that appears on all slides using this layout.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Vytvořte rozložení snímku s prázdným typem rozložení a vlastním názvem.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Layout slides act as templates for individual slides. You can define common elements once and reuse them across many slides.

> 💡 **Tip 2:** When you add shapes or text to a layout slide, all slides based on that layout will display this shared content automatically.
> The screenshot below shows two slides, each inheriting a text box from the same layout slide.

![Snímky dědící obsah rozložení](layout-slide-result.png)


## **Přístup k rozložení snímku**

Layout slides can be accessed by index or by layout type (e.g., `Blank`, `Title`, `SectionHeader`, etc.).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Přístup podle indexu.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Přístup podle typu rozložení.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranit layout snímek**

You can remove a specific layout slide if it's no longer needed.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Získejte rozložení snímku podle typu a odstraňte jej.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranit nepoužívané layout snímky**

To reduce the presentation size, you may want to remove layout slides that are not used by any normal slides.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Automaticky odstraní všechna rozložení snímků, která nejsou použita v žádném snímku.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Klonovat layout snímek**

You can duplicate a layout slide using the `addClone` method.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Získejte existující rozložení snímku podle typu.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Klonujte rozložení snímku na konec kolekce rozložení snímků.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Shrnutí:** Layout slides are powerful tools for managing consistent formatting across slides. Aspose.Slides allows full control over creating, managing, and optimizing layout slides.