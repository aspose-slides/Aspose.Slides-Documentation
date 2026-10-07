---
title: Tabellenzellen in Präsentationen mit JavaScript verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/nodejs-java/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rahmen entfernen
- Zelle aufteilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Tabellenzellen in JavaScript: Identifizieren Sie zusammengeführte Zellen, entfernen Sie Rahmen, teilen Sie Zellen und setzen Sie Hintergrundfarben sowie Bilder mit Aspose.Slides für Node.js via Java."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint‑Präsentationen und deren Bearbeitung. Dieser Artikel erklärt, wie man zusammengeführte Tabellenzellen identifiziert, Zellrahmen entfernt, mit Zellnummerierung nach dem Zusammenführen oder Aufteilen von Zellen arbeitet, die Hintergrundfarbe einer Zelle ändert und ein Bild innerhalb einer Tabellenzelle hinzufügt. Die Beispiele zeigen, wie man eine Präsentation erstellt oder öffnet, eine Tabelle aus einer Folie erhält, die Zellformatierung über Zelleigenschaften aktualisiert und die geänderte Präsentation als PPTX‑Datei speichert.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(Spalte, Zeile)` zu adressieren.

## **Identifizieren einer zusammengeführten Tabellenzelle**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf das erste Shape auf der ersten Folie als Tabelle zu. Es wird vorausgesetzt, dass die Folie und das Shape existieren und dass das Shape eine Tabelle ist. Anschließend werden alle Zeilen und Spalten durchlaufen und [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) verwendet, um Zellen in zusammengeführten Bereichen zu identifizieren. Für jede Übereinstimmung gibt das Beispiel die Zellkoordinaten in der Reihenfolge `Zeile;Spalte` aus, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), sowie die Startkoordinaten des Bereichs, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) und [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Entfernen von Tabellenzellenrahmen**

Erstellen Sie ein [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und fügen Sie seiner ersten Folie mit [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) eine Tabelle hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellenposition werden in Punkten angegeben. Das Beispiel setzt alle vier Zellrahmen auf [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), wodurch sie unsichtbar werden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zusammenführen von Tabellenzellen**

Verwenden Sie [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/), um einen rechteckigen Bereich von Tabellenzellen zu einer einzigen Zelle zu kombinieren. Geben Sie die Zellen an den oberen linken und unteren rechten Ecken des Bereichs an. Das letzte Argument steuert, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `false` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt dann die vier zentralen Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Raster der Tabelle vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie ihre obere linke Position: `table.get_Item(1, 1)` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass die Indizes von Zellen außerhalb des Bereichs unverändert bleiben.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aufteilen von Tabellenzellen**

Das Zusammenführen von Zellen im vorherigen Beispiel erhält das Tabellenraster. Das Aufteilen einer Zelle kann eine neue Rasterspalte einführen und die Spaltenindizes der Zellen rechts davon ändern. Aspose.Slides folgt dem Tabellenrastermodell von PowerPoint.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird übergeben, um zwei gleich breite Zellen zu erzeugen.

Nach diesem Aufteilen werden die beiden Hälften über `table.get_Item(1, 1)` und `table.get_Item(2, 1)` adressiert. Das Tabellengitter besitzt nun fünf Spalten: Zellen, die ursprünglich in den Spalten 2 und 3 lagen, verschieben sich zu Spalten 3 bzw. 4. Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Aufteilen auf Zellen zugreifen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Aufteilen zusammengeführter Zellen nach Zeilen‑ oder Spaltenbereich**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/), um entlang einer bestehenden Zeilengrenze zu teilen, oder [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/), um entlang einer Spaltengrenze zu teilen.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil des Aufteilens; es ist relativ zum zusammengeführten Bereich:

- Zeilenaufteilung: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Spaltenaufteilung: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Das Beispiel geht davon aus, dass die Präsentation auf der ersten Folie als erstes Shape eine Tabelle enthält, wobei die Zellen `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend vom unteren Teil verwendet es [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) und [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/), um den Ursprung zu ermitteln, und prüft beide Spannen. `splitByRowSpan(1)` trennt dann die Zeilen 2 und 3 für Produktnamen. Für eine horizontale Zweispalten‑Zusammenführung verwenden Sie stattdessen `splitByColSpan(1)`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // Die resultierenden Zellen aus der Tabelle nach dem Aufteilen abrufen.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Das Tabellengitter und die umliegenden Zellindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; beide haben eine Spanne von 1 und [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) liefert `false`. Größere Bereiche können nach einem Aufteilen teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung verbleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch Zellformatierungen wie Füllung, Rahmen und Ränder. Befüllen Sie die Zellen nach dem Aufteilen und setzen Sie bei Bedarf die Textformatierung explizit.

Die gespeicherte Präsentation enthält separate Zellen „Produkt A“ und „Produkt B“ mit dem ursprünglichen Zellformat. Siehe die [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) für Details.

## **Ändern der Tabellenzellen-Hintergrundfarbe**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es verwendet [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/), um eine Vollfüllung auszuwählen, und setzt die über [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) zurückgegebene Farbe für die Zelle `(2, 3)` (dritte Spalte, vierte Zeile) auf Rot.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ein Bild in einer Tabellenzelle hinzufügen**

Legen Sie das Eingabebild vor dem Ausführen dieses Beispiels in das Arbeitsverzeichnis. Das Bild wird mit [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) geladen und mit [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) zur Bildsammlung der Präsentation hinzugefügt. Anschließend wird das Bild dem Bildfüllmodus der Zelle `(0, 0)`, also der ersten Zelle der Tabelle, zugewiesen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) streckt das Bild, sodass die Zelle vollständig gefüllt wird, was das Seitenverhältnis ändern kann. Spaltenbreiten und Zeilenhöhen werden in Punkten angegeben. Das geladene Bild wird in einem `finally`‑Block nach dem Hinzufügen zur Präsentation freigegeben.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kann ich für die einzelnen Seiten einer einzelnen Zelle unterschiedliche Linienstärken und -stile festlegen?**

Ja. Die [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/)‑Rahmen besitzen separate Eigenschaften, sodass die Stärke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilengröße ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Stretchen passt sich das Bild der neuen Zelle an, beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem gesamten Zellinhalt einen Hyperlink zuweisen?**

[Hyperlinks](/slides/de/nodejs-java/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textfelds der Zelle oder auf Ebene der gesamten Tabelle/des Shapes gesetzt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich innerhalb einer einzelnen Zelle verschiedene Schriftarten festlegen?**

Ja. Das Textfeld einer Zelle unterstützt [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (Laufs), die unabhängig formatiert werden können – Schriftfamilie, Stil, Größe und Farbe.