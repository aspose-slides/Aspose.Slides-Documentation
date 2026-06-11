---
title: Tabell
type: docs
weight: 120
url: /sv/nodejs-java/examples/elements/table/
keywords:
- kodexempel
- tabell
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Arbeta med tabeller i Aspose.Slides för Node.js: skapa, formatera, slå ihop celler, tillämpa stilar, importera data och exportera med exempel för PPT, PPTX och ODP."
---
Exempel på att lägga till tabeller, komma åt dem, ta bort dem och slå ihop celler med **Aspose.Slides for Node.js via Java**.

## **Lägg till en tabell**
Skapa en enkel tabell med två rader och två kolumner.

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

## **Kom åt en tabell**
Hämta den första tabellformen från bilden.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Kom åt den första tabellen på bilden.
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

## **Ta bort en tabell**
Ta bort en tabell från en bild.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Anta att den första formen är en tabell.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Slå ihop tabellceller**
Slå ihop intilliggande celler i en tabell till en enda cell.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Anta att den första formen är en tabell.
        let table = slide.getShapes().get_Item(0);

        // Slå ihop celler.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```