---
title: Tabela
type: docs
weight: 120
url: /pl/php-java/examples/elements/table/
keywords:
- tabela
- dodaj tabelę
- dostęp do tabeli
- usuń tabelę
- scal komórki
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz i formatuj tabele w PHP przy użyciu Aspose.Slides: wstawiaj dane, scalaj komórki, stylizuj krawędzie, wyrównuj zawartość oraz importuj/eksportuj do PPT, PPTX i ODP."
---
Przykłady dodawania tabel, uzyskiwania do nich dostępu, usuwania ich oraz scalania komórek przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj tabelę**

Utwórz prostą tabelę z dwoma wierszami i dwiema kolumnami.

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

## **Uzyskaj dostęp do tabeli**

Pobierz pierwszy kształt tabeli na slajdzie.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do pierwszej tabeli na slajdzie.
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

## **Usuń tabelę**

Usuń tabelę ze slajdu.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że tabela jest pierwszym kształtem na slajdzie.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Scal komórki tabeli**

Scal sąsiadujące komórki tabeli w jedną komórkę.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że tabela jest pierwszym kształtem na slajdzie.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```