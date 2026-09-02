---
title: "Präsentationstabellen in JavaScript verwalten"
linktitle: "Tabelle verwalten"
type: docs
weight: 10
url: /de/nodejs-java/manage-table/
keywords:
- "Tabelle hinzufügen"
- "Tabelle erstellen"
- "Zugriff auf Tabelle"
- "Seitenverhältnis"
- "Text ausrichten"
- "Textformatierung"
- "Tabellenstil"
- "PowerPoint"
- "Präsentation"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Erstellen & bearbeiten Sie Tabellen in PowerPoint‑Folien mit JavaScript und Aspose.Slides für Node.js. Entdecken Sie einfache Codebeispiele, um Ihre Tabellen‑Workflows zu optimieren."
---
## **Einleitung**

Eine Tabelle in PowerPoint ist eine effiziente Möglichkeit, Informationen darzustellen und zu präsentieren. Die Informationen in einem Gitter aus Zellen (angeordnet in Zeilen und Spalten) sind klar und leicht zu verstehen.

Aspose.Slides stellt die Klasse [Table](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Table), die Klasse [Cell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cell/) und weitere Typen bereit, mit denen Sie Tabellen in allen Arten von Präsentationen erstellen, aktualisieren und verwalten können.

## **Tabelle von Grund auf neu erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [Table](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Table) Objekt über die Methode [addTable](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) zur Folie hinzu.
6. Iterieren Sie über jede [Cell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cell/), um die Formatierung der oberen, unteren, rechten und linken Ränder anzuwenden.
7. Fügen Sie die vier Zellen in der oberen linken Ecke der Tabelle (die ersten beiden Spalten der ersten beiden Reihen) zu einer einzigen Zelle zusammen. 
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) einer [Cell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cell/) zu.
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) Text hinzu.
10. Speichern Sie die geänderte Präsentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Erstellt eine Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var sld = pres.getSlides().get_Item(0);
    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Fügt der Folie ein Tabellenshape hinzu
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Setzt das Randformat für jede Zelle
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Fügt den 2x2‑Block oben links zu einer Zelle zusammen
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Fügt der zusammengefügten Zelle Text hinzu
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Speichert die Präsentation auf dem Datenträger
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nummerierung in Standardtabelle**

In einer Standardtabelle ist die Nummerierung der Zellen unkompliziert und nullbasiert. Die erste Zelle einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0). 

Beispielsweise werden die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser JavaScript-Code zeigt, wie Sie die Nummerierung für Zellen in einer Tabelle festlegen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var sld = pres.getSlides().get_Item(0);
    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Fügt der Folie ein Tabellenshape hinzu
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Setzt das Randformat für jede Zelle
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Speichert die Präsentation auf dem Datenträger
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zugriff auf vorhandene Tabelle**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation).

2. Holen Sie sich eine Referenz zur Folie, die die Tabelle enthält, über ihren Index. 

3. Erstellen Sie ein [Table](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Table) Objekt und setzen Sie es auf `null`.

4. Iterieren Sie über alle [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/) Objekte, bis die Tabelle gefunden wird.

   Wenn Sie vermuten, dass die betroffene Folie nur eine einzige Tabelle enthält, können Sie einfach alle enthaltenen Formen prüfen. Wird eine Form als Tabelle erkannt, können Sie sie zu einem [Table](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Table) Objekt casten. Enthält die Folie jedoch mehrere Tabellen, ist es besser, die gewünschte Tabelle über ihren [setAlternativeText(String value)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) zu suchen.

5. Verwenden Sie das [Table](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Table) Objekt, um mit der Tabelle zu arbeiten. Im nachfolgenden Beispiel setzen wir den Text einer Zelle in der Tabelle.

6. Speichern Sie die geänderte Präsentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Greift auf die erste Folie zu
    var sld = pres.getSlides().get_Item(0);
    // Initialisiert null TableEx
    var tbl = null;
    // Durchläuft die Shapes und setzt eine Referenz auf die gefundene Tabelle
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Setzt den Text für die erste Spalte der zweiten Zeile
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Speichert die geänderte Präsentation auf dem Datenträger
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Die Zelle finden, die einen Textrahmen enthält**

Wenn generischer Textverarbeitungscode ein [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) einer Tabelle erhält, verwenden Sie die Methode [TextFrame.getParentCell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getParentCell--) um die zugehörige [Cell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cell/) zu ermitteln. Für einen Tabellenzellen‑Textframe liefert [TextFrame.getParentCell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getParentCell--) den Eigentümer und [TextFrame.getParentShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getParentShape--) gibt `null` zurück, obwohl die Tabelle selbst eine Form ist.

Die Zellkoordinaten sind über die schreibgeschützten Methoden [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) und [Cell.getFirstRowIndex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) verfügbar. [TextFrame.getParentCell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getParentCell--) bietet zudem nur lesende Navigation: Sie gibt den Eigentümer zurück, ändert jedoch nichts an der Besitzstruktur. Prüfen Sie immer, ob der zurückgegebene Zellwert `null` ist, bevor Sie ihn verwenden.

Ein vollständiges Beispiel, das Tabellenzellen‑ und Form‑Eigentümer identifiziert, einschließlich Formen, die zu SmartArt‑Knoten gehören, finden Sie unter [Search and Replace Text](/slides/de/nodejs-java/search-and-replace-text/).

## **Text in Tabelle ausrichten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Fügen Sie ein [Table](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Table) Objekt zur Folie hinzu.
4. Greifen Sie von der Tabelle aus auf ein [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) Objekt zu.
5. Greifen Sie auf das [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) des [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) zu.
6. Richten Sie den Text vertikal aus.
7. Speichern Sie die geänderte Präsentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Erstellt eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var slide = pres.getSlides().get_Item(0);
    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Fügt der Folie das Tabellenshape hinzu
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Greift auf den Textrahmen zu
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Erstellt das Paragraph-Objekt für den Textrahmen
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Erstellt das Portion-Objekt für den Paragraphen
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Richtet den Text vertikal aus
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // Speichert die Präsentation auf dem Datenträger
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Textformatierung auf Tabellenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Greifen Sie von der Folie aus auf ein [Table](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Table) Objekt zu.
4. Setzen Sie die [setFontHeight(float value)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) für den Text.
5. Setzen Sie die [setAlignment(int value)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Setzen Sie die [setTextVerticalType(byte value)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die geänderte Präsentation. 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Erstellt eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Angenommen, das erste Shape auf der ersten Folie ist eine Tabelle
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Setzt die Schriftgröße der Tabellenzellen
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Setzt die Textausrichtung und den rechten Rand der Tabellenzellen in einem Aufruf
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Setzt den vertikalen Texttyp der Tabellenzellen
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tabellenstil‑Vorgabe festlegen**

Aspose.Slides liefert die integrierten PowerPoint‑Tabellenstile als Aufzählung [TableStylePreset](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tablestylepreset/), sodass Sie das gleiche Aussehen auf jede Tabelle anwenden können. Dieser JavaScript-Code zeigt, wie Sie den Standardstil einer Tabelle durch einen Vorgabestil ersetzen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// ändert das Standard-Style-Vorgabe-Thema
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Seitenverhältnis der Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Größen in unterschiedlichen Dimensionen. Aspose.Slides stellt die Eigenschaft [**setAspectRatioLocked**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) bereit, um das Seitenverhältnis für Tabellen und andere Formen zu sperren.

Dieser JavaScript‑Code zeigt, wie Sie das Seitenverhältnis für eine Tabelle sperren:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invertieren
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kann ich die Rechts‑nach‑Links‑Lesrichtung (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Methode [setRightToLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/table/setrighttoleft/) bereit, und Absätze besitzen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Die Verwendung beider gewährleistet die korrekte RTL‑Reihenfolge und -Darstellung innerhalb der Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder ihre Größe ändern?**

Verwenden Sie Form‑Sperren, um das Verschieben, die Größenänderung, die Auswahl usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/) festlegen; das Bild deckt die Zellenfläche je nach gewähltem Modus (Dehnen oder Kacheln) ab.