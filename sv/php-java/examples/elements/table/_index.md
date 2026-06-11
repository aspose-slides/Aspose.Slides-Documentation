---
title: Tabell
type: docs
weight: 120
url: /sv/php-java/examples/elements/table/
keywords:
- tabell
- lägg till tabell
- kom åt tabell
- ta bort tabell
- slå samman celler
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Skapa och formatera tabeller i PHP med Aspose.Slides: infoga data, slå samman celler, stilera kanter, justera innehåll och importera/exportera för PPT, PPTX och ODP."
---
Exempel på att lägga till tabeller, komma åt dem, ta bort dem och slå samman celler med **Aspose.Slides for PHP via Java**.

## **Lägg till en tabell**

Skapa en enkel tabell med två rader och två kolumner.

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

## **Kom åt en tabell**

Hämta den första tabellformen på bilden.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Åtkomst till den första tabellen på bilden.
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

## **Ta bort en tabell**

Ta bort en tabell från en bild.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antag att tabellen är den första formen på bilden.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Slå samman tabellceller**

Slå samman intilliggande celler i en tabell till en enda cell.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antag att tabellen är den första formen på bilden.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```