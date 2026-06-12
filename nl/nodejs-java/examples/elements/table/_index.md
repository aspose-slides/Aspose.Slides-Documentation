---
title: Tabel
type: docs
weight: 120
url: /nl/nodejs-java/examples/elements/table/
keywords:
- codevoorbeeld
- tabel
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Werken met tabellen in Aspose.Slides voor Node.js: maken, opmaken, cellen samenvoegen, stijlen toepassen, gegevens importeren en exporteren met voorbeelden voor PPT, PPTX en ODP."
---
Voorbeelden voor het toevoegen van tabellen, ze te benaderen, te verwijderen en cellen samen te voegen met **Aspose.Slides for Node.js via Java**.

## **Tabel toevoegen**

Maak een eenvoudige tabel met twee rijen en twee kolommen.

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

## **Toegang tot een tabel**

Haal de eerste tabelvorm van de dia op.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Toegang tot de eerste tabel op de dia.
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

## **Tabel verwijderen**

Verwijder een tabel van een dia.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Neem aan dat de eerste vorm een tabel is.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Tabelcellen samenvoegen**

Voeg aangrenzende cellen van een tabel samen tot één cel.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Neem aan dat de eerste vorm een tabel is.
        let table = slide.getShapes().get_Item(0);

        // Cellen samenvoegen.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```