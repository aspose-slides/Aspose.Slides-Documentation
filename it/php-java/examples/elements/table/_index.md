---
title: Tabella
type: docs
weight: 120
url: /it/php-java/examples/elements/table/
keywords:
- tabella
- aggiungere tabella
- accedere alla tabella
- rimuovere tabella
- unire celle
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Crea e formatta tabelle in PHP con Aspose.Slides: inserisci dati, unisci celle, stile dei bordi, allinea il contenuto e importa/esporta per PPT, PPTX e ODP."
---
Esempi di aggiunta di tabelle, accesso a esse, rimozione e unione delle celle usando **Aspose.Slides for PHP via Java**.

## **Aggiungere una tabella**

Crea una tabella semplice con due righe e due colonne.

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

## **Accedere a una tabella**

Recupera la prima forma di tabella nella diapositiva.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi alla prima tabella nella diapositiva.
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

## **Rimuovere una tabella**

Elimina una tabella da una diapositiva.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Presumendo che la tabella sia la prima forma sulla diapositiva.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Unire le celle della tabella**

Unisci le celle adiacenti di una tabella in un'unica cella.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Presumendo che la tabella sia la prima forma sulla diapositiva.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```