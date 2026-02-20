---
title: Tabelle
type: docs
weight: 120
url: /de/php-java/examples/elements/table/
keywords:
- Tabelle
- Tabelle hinzufügen
- Zugriff auf Tabelle
- Tabelle entfernen
- Zellen zusammenführen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und formatieren Sie Tabellen in PHP mit Aspose.Slides: Daten einfügen, Zellen zusammenführen, Rahmen stylen, Inhalte ausrichten und für PPT, PPTX und ODP importieren/exportieren."
---
Beispiele zum Hinzufügen von Tabellen, zum Zugriff darauf, zum Entfernen und zum Zusammenführen von Zellen mit **Aspose.Slides for PHP via Java**.

## **Tabelle hinzufügen**

Erstellen Sie eine einfache Tabelle mit zwei Zeilen und zwei Spalten.

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

## **Zugriff auf eine Tabelle**

Ermitteln Sie die erste Tabellengrafik auf der Folie.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zugriff auf die erste Tabelle auf der Folie.
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

## **Tabelle entfernen**

Löschen Sie eine Tabelle von einer Folie.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, die Tabelle ist die erste Form auf der Folie.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Tabellenzellen zusammenführen**

Fügen Sie benachbarte Zellen einer Tabelle zu einer einzigen Zelle zusammen.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, die Tabelle ist die erste Form auf der Folie.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```