---
title: Tabela
type: docs
weight: 120
url: /pl/nodejs-java/examples/elements/table/
keywords:
- przykład kodu
- tabela
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Pracuj z tabelami w Aspose.Slides for Node.js: twórz, formatuj, scalaj komórki, stosuj style, importuj dane i eksportuj z przykładami dla PPT, PPTX i ODP."
---
Przykłady dodawania tabel, odczytywania ich, usuwania oraz scalania komórek przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj tabelę**

Utwórz prostą tabelę z dwoma wierszami i dwoma kolumnami.

```js
function addTable() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let widths = java.newArray("double", [80, 80]);
        let heights = java.newArray("double", [30, 30]);
        let table = slide.getShapes().addTable(50, 50, widths, heights);

        presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do tabeli**

Pobierz pierwszy kształt tabeli ze slajdu.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Uzyskaj dostęp do pierwszej tabeli na slajdzie.
        let firstTable = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
                firstTable = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń tabelę**

Usuń tabelę ze slajdu.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Załóżmy, że pierwszy kształt jest tabelą.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Scal komórki tabeli**

Scal sąsiadujące komórki tabeli w jedną komórkę.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Załóżmy, że pierwszy kształt jest tabelą.
        let table = slide.getShapes().get_Item(0);

        // Scal komórki.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```