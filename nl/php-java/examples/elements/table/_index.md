---
title: Tabel
type: docs
weight: 120
url: /nl/php-java/examples/elements/table/
keywords:
- tabel
- tabel toevoegen
- tabel benaderen
- tabel verwijderen
- cellen samenvoegen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Maak en formatteer tabellen in PHP met Aspose.Slides: gegevens invoegen, cellen samenvoegen, randen stijlen, inhoud uitlijnen, en importeren/exporteren voor PPT, PPTX en ODP."
---
Voorbeelden voor het toevoegen van tabellen, het benaderen ervan, het verwijderen en het samenvoegen van cellen met behulp van **Aspose.Slides for PHP via Java**.

## **Tabel toevoegen**

Maak een eenvoudige tabel met twee rijen en twee kolommen.

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

## **Tabel benaderen**

Haal de eerste tabelvorm op de dia op.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Benader de eerste tabel op de dia.
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

## **Tabel verwijderen**

Verwijder een tabel van een dia.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aangenomen dat de tabel de eerste vorm op de dia is.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Tabelcellen samenvoegen**

Voeg aangrenzende cellen van een tabel samen tot één cel.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aangenomen dat de tabel de eerste vorm op de dia is.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```