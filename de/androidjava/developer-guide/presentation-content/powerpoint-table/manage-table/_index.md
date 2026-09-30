---
title: Verwalten von Präsentationstabellen auf Android
linktitle: Tabelle verwalten
type: docs
weight: 10
url: /de/androidjava/manage-table/
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
- Android
- Java
- Aspose.Slides
description: "Erstellen und Bearbeiten von Tabellen in PowerPoint-Folien mit Aspose.Slides für Android. Entdecken Sie einfache Java-Code-Beispiele, um Ihre Tabellen-Workflows zu optimieren."
---
## **Einleitung**

Tabellen in PowerPoint organisieren Informationen in Zeilen und Spalten, was das Lesen und den Vergleich von Werten erleichtert.

Aspose.Slides stellt die [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) Klasse, das [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) Interface, die [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) Klasse, das [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) Interface und weitere Typen zur Verfügung, mit denen Sie Tabellen in Präsentationen erstellen, aktualisieren und verwalten können.

## **Erstellen einer Tabelle von Grund auf**

Erstellen Sie eine Tabelle, indem Sie ihre Position sowie Spaltenbreiten und Zeilenhöhen angeben. Nach dem Hinzufügen zu einer Folie können Sie Zellrahmen formatieren, Zellen zusammenführen und Text einfügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Definieren Sie ein Array von Spaltenbreiten in Punkten.
4. Definieren Sie ein Array von Zeilenhöhen in Punkten.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) Objekt über die [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) Methode zur Folie hinzu.
6. Iterieren Sie über jedes [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) , um die Formatierung für die oberen, unteren, rechten und linken Rahmen anzuwenden.
7. Fügen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.
8. Greifen Sie über die [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) Methode auf die zusammengeführte Zelle zu.
9. Setzen Sie den Text in der zusammengeführten Zelle.
10. Speichern Sie die geänderte Präsentation.

Das nachstehende Beispiel erstellt eine Tabelle mit drei Spalten und fünf Zeilen bei (100, 50) Punkten. Es wendet rote Rahmen mit einer Breite von 5 Punkten an, fügt die ersten beiden Zellen in der ersten Zeile zusammen und speichert das Ergebnis als `table.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
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

Dieses Beispiel erstellt die oben dargestellte 4 × 4‑Tabelle mit Spaltenbreiten und Zeilenhöhen von 70 Punkten sowie roten Zellrahmen mit einer Breite von 5 Punkten. Die Koordinaten veranschaulichen die Zellindizes; das Beispiel lässt die Zellen leer und speichert die Tabelle als `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zugriff auf eine vorhandene Tabelle**

Tabellen werden in der Formen‑Sammlung einer Folie gespeichert. Durchlaufen Sie die Formen, um eine Tabelle zu finden, und verwenden Sie dann das [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) Interface, um deren Zellen zu lesen oder zu aktualisieren.

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz auf die Folie, die die Tabelle enthält, über ihren Index.
3. Durchlaufen Sie die [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) Objekte und stoppen Sie, wenn eine Tabelle gefunden wird. Enthält die Folie mehrere Tabellen, verwenden Sie [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) , um die gewünschte zu identifizieren.
4. Aktualisieren Sie den Text in der Zielzelle.
5. Speichern Sie die geänderte Präsentation.

Das nachstehende Beispiel öffnet `UpdateExistingTable.pptx` und findet die erste Tabelle auf der ersten Folie. Es setzt die Zelle in Spalte 0, Zeile 1 auf `New` und speichert das Ergebnis als `table1_out.pptx`. Die Eingabedatei muss mindestens eine Folie enthalten, und die erste Tabelle auf dieser Folie muss mindestens eine Spalte und zwei Zeilen haben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Um die Höhe einer Zeile in einer vorhandenen Tabelle zu ändern und zu verstehen, warum ihre tatsächliche Höhe das angeforderte Minimum überschreiten kann, siehe [Zeilenhöhe steuern](/slides/de/androidjava/manage-rows-and-columns/#control-row-height).

## **Finden Sie die Zelle, die einen Textrahmen besitzt**

Wenn generischer Textverarbeitungscode ein [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) von einer Tabelle erhält, verwenden Sie die [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) Methode, um die zugehörige [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) abzurufen. Für einen Tabellenzellen‑Textrahmen gibt [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) den Eigentümer zurück und [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) liefert `null`, obwohl die Tabelle selbst ein Shape ist.

Die Zellkoordinaten sind über die schreibgeschützten [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) und [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) Methoden verfügbar. [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) bietet zudem eine schreibgeschützte Navigation: Sie gibt den Eigentümer zurück, ändert jedoch nichts am Eigentum. Prüfen Sie stets, ob die zurückgegebene Zelle `null` ist, bevor Sie sie verwenden.

Für ein komplettes Beispiel, das Tabellenzellen‑ und Shape‑Eigentümer identifiziert, einschließlich Shapes, die mit SmartArt‑Knoten verbunden sind, siehe [Suchen und Ersetzen von Text](/slides/de/androidjava/search-and-replace-text/).

## **Text in einer Tabelle ausrichten**

Sie können die vertikale Verankerung und Textausrichtung einzelner Tabellenzellen steuern. Das Beispiel in diesem Abschnitt zentriert den Text in der ersten Zelle und dreht ihn um 270 Grad.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Fügen Sie ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) Objekt zur Folie hinzu.
4. Greifen Sie auf ein [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) Objekt der Tabelle zu.
5. Greifen Sie auf das erste [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) zu und setzen Sie dessen Text und Farbe.
6. Setzen Sie die vertikale Verankerung und Textausrichtung der Zelle mittels [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) und [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-).
7. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit Spaltenbreiten von 120 Punkten und Zeilenhöhen von 100 Punkten. Es formatiert den Text in Zelle (0, 0), fügt Werte zu den übrigen Zellen der ersten Zeile hinzu und speichert das Ergebnis als `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Textformatierung auf Tabellenebene festlegen**

Verwenden Sie [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) , um Textformatierungen auf alle Zellen einer Tabelle anzuwenden. Seine Überladungen akzeptieren Portion-, Absatz- und Textrahmen‑Formatierung, sodass Sie diese Eigenschaften festlegen können, ohne einzelne Zellen zu iterieren.

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Greifen Sie auf ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) Objekt der Folie zu.
4. Setzen Sie die Schriftgröße mit [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) für den Text.
5. Setzen Sie die Absatzausrichtung und den rechten Rand mittels [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setzen Sie die Textausrichtung mit [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die geänderte Präsentation.

Das nachstehende Beispiel öffnet `table.pptx`, das mindestens eine Folie mit einer Tabelle als erstes Shape enthalten muss. Es setzt die Schriftgröße auf 25 Punkte, richtet Absätze rechtsbündig mit einem rechten Rand von 20 Punkten aus und macht den Text vertikal. Die formatierte Präsentation wird als `result.pptx` gespeichert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) , um den voreingestellten Stil einer Tabelle zu lesen, und [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) , um ihn zuzuweisen. Dieses Beispiel wendet [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) auf eine Tabelle an, gibt den Vorgabewert aus und weist dieselbe Vorgabe einer zweiten Tabelle zu. Beide Tabellen werden in `table-style.pptx` gespeichert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer Tabelle ist das Verhältnis ihrer Breite zu ihrer Höhe. Verwenden Sie [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) , um dieses Verhältnis für eine Tabelle zu sperren.

Das nachstehende Beispiel öffnet `pres.pptx`, das mindestens eine Folie mit einer Tabelle als erstes Shape enthalten muss. Es gibt den aktuellen Sperrzustand aus, aktiviert die Sperre des Seitenverhältnisses, gibt den aktualisierten Zustand (`true`) aus und speichert das Ergebnis als `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kann ich die Rechts‑zu‑Links‑(RTL‑)Leserichtung für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt eine [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) Methode bereit, und Absätze besitzen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Die Verwendung beider sorgt für die korrekte RTL‑Reihenfolge und -Darstellung in den Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder die Größe ändern?**

Verwenden Sie [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) , um das Verschieben, Ändern der Größe, Auswählen usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) festlegen; das Bild deckt die Zellenfläche gemäß dem gewählten Modus (Streckung oder Kachel) ab.