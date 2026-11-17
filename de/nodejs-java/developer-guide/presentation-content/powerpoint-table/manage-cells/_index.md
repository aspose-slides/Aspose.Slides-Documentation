---
title: Tabellzellen in Präsentationen mit JavaScript verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/nodejs-java/manage-cells/
keywords:
- Tabellzelle
- Zellen zusammenführen
- Rahmen entfernen
- Zelle teilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie PowerPoint‑Tabellzellen in JavaScript: Erkennen zusammengeführter Zellen, Entfernen von Rahmen, Teilen von Zellen und Festlegen von Hintergrundfarben sowie Bildern mit Aspose.Slides für Node.js über Java."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf und die Modifikation von Tabellzellen in PowerPoint‑Präsentationen. Dieser Artikel erklärt, wie Sie zusammengeführte Tabellzellen erkennen, Zellrahmen entfernen, mit Zellnummerierung nach dem Zusammenführen oder Aufteilen von Zellen arbeiten, die Hintergrundfarbe einer Zelle ändern und ein Bild in einer Tabellzelle hinzufügen. Die Beispiele zeigen, wie man eine Präsentation erstellt oder öffnet, eine Tabelle aus einer Folie abruft, die Zellenformatierung über Zellen‑Eigenschaften aktualisiert und die modifizierte Präsentation als PPTX‑Datei speichert.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellzellen in der Reihenfolge `(column, row)` zu adressieren.

## **Zusammengeführte Tabellzelle erkennen**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird angenommen, dass Folie und Form existieren und dass die Form eine Tabelle ist. Anschließend iteriert es über alle Zeilen und Spalten und verwendet [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) um Zellen in zusammengeführten Bereichen zu identifizieren. Für jede Übereinstimmung gibt es die Zellkoordinaten in der Reihenfolge `row;column`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), und die Startkoordinaten des Bereichs, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) und [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/), aus.

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

## **Tabellenzellenrahmen entfernen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und fügen Sie auf der ersten Folie mit [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) eine Tabelle hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellenposition werden in Punkten angegeben. Das Beispiel setzt alle vier Zellrahmen auf [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), wodurch sie unsichtbar werden.

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

## **Diagonale Zellrahmen hinzufügen**

Verwenden Sie [getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/) , um eine Linie von der oberen linken Ecke zur unteren rechten zu zeichnen, und [getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/) , um eine Linie von der unteren linken Ecke zur oberen rechten zu zeichnen. Eine Diagonale kann eine Ecküberschrift kennzeichnen; beide Diagonalen können ein X bilden, um eine Zelle als nicht anwendbar zu markieren.

Jede Diagonale ist ein [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/). In seinem [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) , verwenden Sie [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) , um [FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) auszuwählen und eine Farbe über [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) zu bestimmen. Setzen Sie die Linienstärke in Punkten mit [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/).

Das Beispiel erstellt drei Zellen in einer Zeile: eine rote nach unten gerichtete Diagonale, eine blaue nach oben gerichtete Diagonale und beide Diagonalen. Die oberen, unteren, linken und rechten Zellrahmen bleiben unverändert.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eine Diagonale ist eine Formatierungseigenschaft, keine Zellaufteilung. Jede Zelle behält einen einzelnen Textrahmen, der über [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/) zugänglich ist; die Bereiche auf beiden Seiten einer Diagonale können nicht unabhängig voneinander bearbeitet werden.

The saved table, rendered in Microsoft PowerPoint:

![Drei Tabellzellen mit einer roten Diagonale von oben links nach unten rechts, einer blauen Diagonale von unten links nach oben rechts und beiden Diagonalen, die ein X bilden.](diagonal-cell-borders.png)

*Von links nach rechts: abwärts gerichtete Diagonale (rot, 3 pt), aufwärts gerichtete Diagonale (blau, 5 pt) und beide Diagonalen.*

## **Tabellenzellen zusammenführen**

Verwenden Sie [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) , um einen rechteckigen Bereich von Tabellzellen zu einer Zelle zu kombinieren. Geben Sie die Zellen an den oberen linken und unteren rechten Ecken des Bereichs an. Das letzte Argument steuert, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `false` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4‑by‑4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt dann die vier mittleren Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Tabellengitter vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie deren obere linke Position: `table.get_Item(1, 1)` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass die Indizes der Zellen außerhalb des Bereichs unverändert bleiben.

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

## **Tabellenzellen teilen**

Das Zusammenführen von Zellen im vorherigen Beispiel erhält das Tabellengitter. Das Teilen einer Zelle kann eine neue Gitterspalte einführen und die Spaltenindizes der Zellen rechts davon ändern. Aspose.Slides folgt dem Tabellengittermodell von PowerPoint.

Dieses Beispiel erstellt eine 4‑by‑4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) für Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird übergeben, um zwei Zellen gleicher Breite zu erzeugen.

Nach diesem Split werden die beiden Hälften über `table.get_Item(1, 1)` bzw. `table.get_Item(2, 1)` zugegriffen. Das Tabellengitter hat nun fünf Spalten: Zellen, die ursprünglich in Spalte 2 und 3 waren, verschieben sich zu Spalte 3 bzw. 4. Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Split auf Zellen zugreifen.

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

<!-- visual-explanation:manage-cells:start -->
[![Eine nicht zusammengeführte 70‑Punkt‑Zelle wird in zwei 35‑Punkt‑Zellen aufgeteilt, wodurch eine fünfte Gitterspalte hinzugefügt und die Indizes rechts davon verschoben werden.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Der Breiten‑Split wirkt sich auf Zelle (1, 1) aus und verwendet nullbasierte (column, row)-Indizes. Andere Zeilen behalten eine Zelle, die beide neuen Spaltenpositionen überspannt.*
<!-- visual-explanation:manage-cells:end -->

### **Zusammengeführte Zellen nach Zeilen‑ oder Spalten‑Spanne teilen**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) , um entlang einer bestehenden Zeilen­grenze zu teilen, oder [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) , um entlang einer Spalten­grenze zu teilen.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil des Splits; es ist relativ zum zusammengeführten Bereich:

- Zeilen‑Split: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Spalten‑Split: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Das Beispiel geht davon aus, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) und [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/), um den Ursprung zu finden, und prüft beide Spannen. `splitByRowSpan(1)` trennt dann die Zeilen 2 und 3 für Produktnamen. Für ein horizontales Zusammenführen von zwei Spalten verwenden Sie stattdessen `splitByColSpan(1)`.

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

Das Tabellengitter und die umgebenden Zellindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; hier haben beide eine Spanne von 1 und [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) gibt `false` aus. Größere Bereiche können nach einem Split teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung bleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Rahmen und Ränder. Befüllen Sie die Zellen nach dem Split und setzen Sie erforderliche Textformatierungen explizit.

Die gespeicherte Präsentation enthält separate „Product A“- und „Product B“-Zellen, wobei die Zellformatierung der Vorlage beibehalten wird. Siehe die [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) für Details.

### **Eine Zelle an einer bestimmten Höhe teilen**

[splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/) nimmt die Höhe des oberen Teils in Punkten. [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) nimmt die Anzahl der vorhandenen Gitterzeilen im oberen Teil. Um eine 40‑Punkt‑Zelle in der rechten Spalte zu zentrieren, subtrahieren Sie 40 von der tatsächlichen Höhe der Zelle und teilen den verbleibenden Raum gleichmäßig darüber und darunter.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der erste Split fügt eine Gitterzeile hinzu und lässt die unteren 90 Punkte in Zelle `(1, 1)` stehen. Der zweite Split teilt diese Zelle in eine mittlere Zelle von 40 Punkten und eine untere Zelle von 50 Punkten. Die rechte Spalte hat nun drei Zellen mit Höhen von 50, 40 und 50 Punkten von oben nach unten. Die linke Zelle erstreckt sich über alle drei Zeilen und behält ihre ursprüngliche Höhe von 140 Punkten bei.

![Die linke Zelle erstreckt die gesamte Tabellenhöhe neben drei Zellen mit Mittel in der Mitte.](split-by-height.png)

## **Hintergrundfarbe der Tabellenzelle ändern**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es verwendet [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) , um eine Vollfüllung auszuwählen, und setzt die von [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) zurückgegebene Farbe für Zelle `(2, 3)`, in der dritten Spalte und vierten Zeile, auf Rot.

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

Platzieren Sie das Eingabebild im Arbeitsverzeichnis, bevor Sie dieses Beispiel ausführen. Es lädt das Bild mit [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) und fügt es der Bildsammlung der Präsentation mit [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) hinzu. Anschließend wird das Bild der Bildfüllung der Zelle `(0, 0)`, der ersten Zelle in der Tabelle, zugewiesen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) streckt das Bild, um die Zelle zu füllen, was das Seitenverhältnis ändern kann. Spaltenbreiten und Zeilenhöhen werden in Punkten angegeben. Das geladene Bild wird in einem `finally`‑Block freigegeben, nachdem es zur Präsentation hinzugefügt wurde.

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

**Kann ich unterschiedliche Linienstärken und Stile für verschiedene Seiten einer einzelnen Zelle festlegen?**

Ja. Die [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/)‑Rahmen besitzen separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilen‑Größe ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) ab. Beim Strecken passt sich das Bild an die neue Zelle an; beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem Hyperlink den gesamten Inhalt einer Zelle zuweisen?**

[Hyperlinks](/slides/de/nodejs-java/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textrahmens der Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich verschiedene Schriftarten innerhalb einer einzelnen Zelle festlegen?**

Ja. Der Textrahmen einer Zelle unterstützt [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) , also Textabschnitte, mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.