---
title: Tabella
type: docs
weight: 120
url: /it/nodejs-java/examples/elements/table/
keywords:
- esempio di codice
- tabella
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Lavora con le tabelle in Aspose.Slides per Node.js: crea, formatta, unisci celle, applica stili, importa dati ed esporta con esempi per PPT, PPTX e ODP."
---
Esempi di aggiunta di tabelle, accesso, rimozione e unione di celle utilizzando **Aspose.Slides for Node.js via Java**.

## **Aggiungi una tabella**
Crea una tabella semplice con due righe e due colonne.

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

## **Accedi a una tabella**
Recupera la prima forma di tabella dalla diapositiva.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accedi alla prima tabella nella diapositiva.
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

## **Rimuovi una tabella**
Elimina una tabella da una diapositiva.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supponi che la prima forma sia una tabella.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Unisci le celle della tabella**
Unisci le celle adiacenti di una tabella in una singola cella.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supponi che la prima forma sia una tabella.
        let table = slide.getShapes().get_Item(0);

        // Unisci le celle.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```