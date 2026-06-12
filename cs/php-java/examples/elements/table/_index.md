---
title: Tabulka
type: docs
weight: 120
url: /cs/php-java/examples/elements/table/
keywords:
- tabulka
- přidat tabulku
- přístup k tabulce
- odstranit tabulku
- sloučit buňky
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vytvořte a formátujte tabulky v PHP pomocí Aspose.Slides: vložte data, sloučte buňky, stylizujte okraje, zarovnejte obsah a importujte/exportujte pro PPT, PPTX a ODP."
---
Příklady přidávání tabulek, přístupu k nim, odstraňování a slučování buněk pomocí **Aspose.Slides for PHP via Java**.

## **Přidat tabulku**

Vytvořte jednoduchou tabulku se dvěma řádky a dvěma sloupci.

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Přístup k tabulce**

Získejte první tvar tabulky na snímku.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k první tabulce na snímku.
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranit tabulku**

Odstraňte tabulku ze snímku.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že tabulka je první tvar na snímku.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Sloučit buňky tabulky**

Sloučte sousední buňky tabulky do jedné buňky.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že tabulka je první tvar na snímku.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```