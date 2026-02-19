---
title: Tabelle
type: docs
weight: 120
url: /de/nodejs-java/examples/elements/table/
keywords:
- Codebeispiel
- Tabelle
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Arbeiten Sie mit Tabellen in Aspose.Slides für Node.js: Erstellen, formatieren, Zellen zusammenführen, Stile anwenden, Daten importieren und exportieren – mit Beispielen für PPT, PPTX und ODP."
---
Beispiele für das Hinzufügen von Tabellen, den Zugriff darauf, das Entfernen und das Zusammenführen von Zellen mit **Aspose.Slides for Node.js via Java**.

## **Tabelle hinzufügen**

Erstelle eine einfache Tabelle mit zwei Zeilen und zwei Spalten.

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

## **Zugriff auf eine Tabelle**

Rufe die erste Tabellengestalt von der Folie ab.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zugriff auf die erste Tabelle auf der Folie.
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

## **Tabelle entfernen**

Lösche eine Tabelle von einer Folie.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, das erste Shape ist eine Tabelle.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Tabellenzellen zusammenführen**

Führe benachbarte Zellen einer Tabelle zu einer einzigen Zelle zusammen.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Angenommen, das erste Shape ist eine Tabelle.
        let table = slide.getShapes().get_Item(0);

        // Zellen zusammenführen.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```