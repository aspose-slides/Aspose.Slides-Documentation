---
title: SmartArt
type: docs
weight: 140
url: /cs/php-java/examples/elements/smartart/
keywords:
- SmartArt
- přidat SmartArt
- přístup k SmartArt
- odstranit SmartArt
- rozvržení SmartArt
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte a upravujte SmartArt v PHP pomocí Aspose.Slides: přidávejte uzly, měňte rozvržení a styly, přesně převádějte na tvary a exportujte do PPT, PPTX a ODP."
---
Ukazuje, jak přidat grafiku SmartArt, přistupovat k ní, odstranit ji a měnit rozvržení pomocí **Aspose.Slides for PHP via Java**.

## **Přidat SmartArt**

Vložte grafiku SmartArt pomocí jednoho ze zabudovaných rozvržení.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Přístup k SmartArt**

Získejte první objekt SmartArt na snímku.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k prvnímu SmartArt na snímku.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranit SmartArt**

Odstraňte tvar SmartArt ze snímku.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Změnit rozvržení SmartArt**

Aktualizujte typ rozvržení existující grafiky SmartArt.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Změnit rozvržení SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```