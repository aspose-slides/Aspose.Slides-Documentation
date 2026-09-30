---
title: Verwalten von Präsentationstabellen in JavaScript
linktitle: Tabelle verwalten
type: docs
weight: 10
url: /de/nodejs-java/manage-table/
keywords:
- Tabelle hinzufügen
- Tabelle erstellen
- Zugriff auf Tabelle
- Seitenverhältnis
- Text ausrichten
- Textformatierung
- Tabellenstil
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen und bearbeiten Sie Tabellen in PowerPoint‑Folien mit JavaScript und Aspose.Slides für Node.js. Entdecken Sie einfache Code‑Beispiele, um Ihre Tabellen‑Workflows zu optimieren."
---
## **Einführung**

Tabellen in PowerPoint organisieren Informationen in Zeilen und Spalten und erleichtern das Lesen und den Vergleich von Werten.

Aspose.Slides stellt die Klasse [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) , die Klasse [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) und andere Typen zur Verfügung, mit denen Sie Tabellen in Präsentationen erstellen, aktualisieren und verwalten können.

## **Erstellen einer Tabelle von Grund auf**

Erstellen Sie eine Tabelle, indem Sie ihre Position, Spaltenbreiten und Zeilenhöhen angeben. Nach dem Hinzufügen zu einer Folie können Sie Zellenrahmen formatieren, Zellen zusammenführen und Text einfügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Definieren Sie ein Array von Spaltenbreiten in Punkten.
4. Definieren Sie ein Array von Zeilenhöhen in Punkten.
5. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) Objekt über die Methode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) hinzu.
6. Iterieren Sie über jede [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/), um die Formatierung der oberen, unteren, rechten und linken Rahmen anzuwenden.
7. Fügen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.
8. Greifen Sie über die Methode [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) auf die zusammengeführte Zelle zu.
9. Setzen Sie den Text in der zusammengeführten Zelle.
10. Speichern Sie die geänderte Präsentation.

Das nachstehende Beispiel erstellt eine Tabelle mit drei Spalten und fünf Zeilen bei (100, 50) Punkten. Es wendet rote Rahmen mit einer Breite von 5 Punkten an, fügt die ersten beiden Zellen der ersten Zeile zusammen und speichert das Ergebnis als `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nummerierung in einer Standardtabelle**

In einer Standardtabelle sind Zellindizes nullbasiert und verwenden die Reihenfolge (Spalte, Zeile). Die erste Zelle hat den Index (0, 0).

Beispielsweise werden die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieses Beispiel erstellt die oben dargestellte 4 × 4‑Tabelle mit Spaltenbreiten und Zeilenhöhen von 70 Punkten sowie roten Zellenrahmen mit einer Breite von 5 Punkten. Die Koordinaten veranschaulichen Zellindizes; das Beispiel lässt die Zellen leer und speichert die Tabelle als `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zugriff auf eine vorhandene Tabelle**

Tabellen werden in der Formsammlung einer Folie gespeichert. Durchlaufen Sie die Formen, um eine Tabelle zu finden, und verwenden Sie dann die Klasse [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/), um deren Zellen zu lesen oder zu aktualisieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf die Folie, die die Tabelle enthält, über ihren Index.
3. Durchlaufen Sie die [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑Objekte und stoppen Sie, wenn eine Tabelle gefunden wird. Enthält die Folie mehrere Tabellen, verwenden Sie [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) , um die gewünschte zu identifizieren.
4. Aktualisieren Sie den Text in der Zielzelle.
5. Speichern Sie die geänderte Präsentation.

Das nachstehende Beispiel öffnet `UpdateExistingTable.pptx` und findet die erste Tabelle auf der ersten Folie. Es setzt die Zelle in Spalte 0, Zeile 1 auf `New` und speichert das Ergebnis als `table1_out.pptx`. Die Eingabedatei muss mindestens eine Folie enthalten, und die erste Tabelle auf dieser Folie muss mindestens eine Spalte und zwei Zeilen besitzen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Um eine Zeile in einer vorhandenen Tabelle zu ändern und zu verstehen, warum die tatsächliche Höhe das angeforderte Minimum überschreiten kann, siehe [Zeilenhöhe steuern](/slides/de/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Finden der Zelle, die einen TextFrame besitzt**

Wenn generischer Textverarbeitungscode ein [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) von einer Tabelle erhält, verwenden Sie die Methode [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) , um die zugehörige [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) abzurufen. Für ein Tabellenzellen‑TextFrame liefert [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) den Eigentümer und [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) gibt `null` zurück, obwohl die Tabelle selbst eine Form ist.

Die Zellkoordinaten sind über die schreibgeschützten Methoden [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) und [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) verfügbar. [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) bietet ebenfalls schreibgeschützte Navigation: Sie gibt den Eigentümer zurück, ändert jedoch den Besitz nicht. Überprüfen Sie stets, ob die zurückgegebene Zelle `null` ist, bevor Sie sie verwenden.

Für ein komplettes Beispiel, das Tabellenzellen‑ und Form‑Eigentümer identifiziert, einschließlich Formen, die mit SmartArt‑Knoten verbunden sind, siehe [Suchen und Ersetzen von Text](/slides/de/nodejs-java/search-and-replace-text/).

## **Text in einer Tabelle ausrichten**

Sie können die vertikale Verankerung und Textausrichtung einzelner Tabellenzellen steuern. Das Beispiel in diesem Abschnitt zentriert den Text in der ersten Zelle und dreht ihn um 270 Grad.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) Objekt hinzu.
4. Greifen Sie auf ein [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) Objekt der Tabelle zu.
5. Greifen Sie auf den ersten [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) zu und setzen Sie dessen Text und Farbe.
6. Setzen Sie die vertikale Verankerung und Textausrichtung der Zelle mithilfe von [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) und [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-).
7. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit Spaltenbreiten von 120 Punkten und Zeilenhöhen von 100 Punkten. Es formatiert den Text in Zelle (0, 0), fügt den übrigen Zellen der ersten Zeile Werte hinzu und speichert das Ergebnis als `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Textformatierung auf Tabellenebene festlegen**

Verwenden Sie [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) , um Textformatierungen auf alle Zellen einer Tabelle anzuwenden. Die Überladungen akzeptieren Abschnitts‑, Absatz‑ und Textframe‑Formatierungen, sodass Sie diese Eigenschaften festlegen können, ohne einzelne Zellen zu durchlaufen.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Greifen Sie auf ein [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) Objekt der Folie zu.
4. Setzen Sie die Schriftgröße mit [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) für den Text.
5. Setzen Sie die Absatzausrichtung und den rechten Rand mit [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) und [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Setzen Sie die Textausrichtung mit [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die geänderte Präsentation.

Das nachstehende Beispiel öffnet `table.pptx`, das mindestens eine Folie mit einer Tabelle als erstes Shape enthalten muss. Es setzt die Schriftgröße auf 25 Punkte, richtet Absätze rechtsbündig mit einem rechten Rand von 20 Punkten aus und macht den Text vertikal. Die formatierte Präsentation wird als `result.pptx` gespeichert.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) , um den voreingestellten Stil einer Tabelle auszulesen, und [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) , um ihn zuzuweisen. Dieses Beispiel wendet [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) auf eine Tabelle an, gibt den Preset‑Wert aus und weist denselben Preset einer zweiten Tabelle zu. Beide Tabellen werden in `table-style.pptx` gespeichert.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer Tabelle ist das Verhältnis ihrer Breite zu ihrer Höhe. Verwenden Sie [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) , um dieses Verhältnis für eine Tabelle zu sperren.

Das nachstehende Beispiel öffnet `pres.pptx`, das mindestens eine Folie mit einer Tabelle als erstes Shape enthalten muss. Es gibt den aktuellen Sperrzustand aus, aktiviert die Sperrung des Seitenverhältnisses, gibt den aktualisierten Zustand (`true`) aus und speichert das Ergebnis als `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kann ich die Rechts-nach-Links‑Lese­richtung (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle bietet die Methode [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) , und Absätze verfügen über [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-) . Die Verwendung beider gewährleistet die korrekte RTL‑Reihenfolge und das Rendering innerhalb der Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der finalen Datei verschieben oder ihrer Größe ändern?**

Verwenden Sie [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) , um das Verschieben, Ändern der Größe, Auswählen usw. zu deaktivieren. Diese Sperren gelten ebenfalls für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) festlegen; das Bild deckt die Zellenfläche je nach gewähltem Modus (Strecken oder Kacheln) ab.