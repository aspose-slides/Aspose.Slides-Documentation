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
description: "Erstellen und bearbeiten Sie Tabellen in PowerPoint-Folien mit Aspose.Slides für Android. Entdecken Sie einfache Java-Code-Beispiele, um Ihre Tabellen-Workflows zu optimieren."
---
## **Einleitung**

Eine Tabelle in PowerPoint ist eine effiziente Möglichkeit, Informationen darzustellen und zu präsentieren. Die Informationen in einem Raster aus Zellen (geordnet in Zeilen und Spalten) sind unkompliziert und leicht zu verstehen.

Aspose.Slides bietet die [Table](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Table) Klasse, das [ITable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITable) Interface, die [Cell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/cell/) Klasse, das [ICell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icell/) Interface und weitere Typen, mit denen Sie Tabellen in allen Arten von Präsentationen erstellen, aktualisieren und verwalten können.

## **Eine Tabelle von Grund auf erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.  
2. Holen Sie sich über den Index eine Referenz auf die Folie.  
3. Definieren Sie ein Array von `columnWidth`.  
4. Definieren Sie ein Array von `rowHeight`.  
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITable) Objekt über die Methode [addTable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) zur Folie hinzu.  
6. Iterieren Sie über jedes [ICell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icell/), um die Formatierung der oberen, unteren, rechten und linken Ränder anzuwenden.  
7. Führen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.  
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textframe/) eines [ICell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icell/) zu.  
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textframe/) etwas Text hinzu.  
10. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie eine Tabelle in einer Präsentation erstellen:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Fügt der Folie ein Tabellen‑Shape hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Legt das Rahmenformat für jede Zelle fest
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
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
    // Fügt die Zellen 1 und 2 der Zeile 1 zusammen
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // Fügt dem zusammengefügten Feld etwas Text hinzu
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Speichert die Präsentation auf der Festplatte
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nummerierung in einer Standardtabelle**

In einer Standardtabelle erfolgt die Nummerierung der Zellen einfach und nullbasiert. Die erste Zelle einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0).

Beispielhaft werden die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser Java‑Code zeigt, wie Sie die Nummerierung für Zellen in einer Tabelle festlegen:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt ein Tabellen‑Shape zur Folie hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Legt das Rahmenformat für jede Zelle fest
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Speichert die Präsentation auf der Festplatte
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Auf eine vorhandene Tabelle zugreifen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.  
2. Holen Sie sich über den Index eine Referenz auf die Folie, die die Tabelle enthält.  
3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITable) Objekt und setzen Sie es auf `null`.  
4. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/) Objekte, bis die Tabelle gefunden wird.  

   Wenn Sie vermuten, dass die betreffende Folie nur eine Tabelle enthält, können Sie einfach alle Formen prüfen, die sie enthält. Wird eine Form als Tabelle identifiziert, können Sie sie in ein [Table](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Table) Objekt casten. Enthält die Folie jedoch mehrere Tabellen, ist es besser, nach der gewünschten Tabelle über ihren [setAlternativeText(String value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) zu suchen.  

5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITable) Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel setzen wir den Text einer Zelle in der Tabelle.  
6. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie auf eine vorhandene Tabelle zugreifen und mit ihr arbeiten:

```java
import com.aspose.slides.*;

// Instanziert die Presentation‑Klasse, die eine PPTX‑Datei darstellt
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialisiert null TableEx
    ITable tbl = null;

    // Iteriert durch die Formen und setzt eine Referenz auf die gefundene Tabelle
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Setzt den Text für die erste Spalte der zweiten Zeile
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Speichert die geänderte Präsentation auf der Festplatte
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Die Zelle finden, die einen Textrahmen besitzt**

Wenn generischer Textverarbeitungscode ein [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) einer Tabelle erhält, verwenden Sie die Methode [ITextFrame.getParentCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentCell--) , um das zugehörige [ICell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icell/) zu ermitteln. Für einen Tabellen‑Zellen‑Textrahmen liefert [ITextFrame.getParentCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentCell--) den Besitzer, während [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentShape--) `null` zurückgibt, obwohl die Tabelle selbst eine Form ist.

Die Zellkoordinaten stehen über die schreibgeschützten Methoden [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) und [ICell.getFirstRowIndex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) zur Verfügung. [ITextFrame.getParentCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentCell--) bietet zudem eine schreibgeschützte Navigation: Sie gibt den Besitzer zurück, ändert jedoch nicht den Eigentümer. Prüfen Sie stets, ob die zurückgegebene Zelle `null` ist, bevor Sie sie verwenden.

Ein vollständiges Beispiel, das Tabellen‑Zellen‑ und Form‑Besitzer einschließlich der mit SmartArt‑Knoten verknüpften Formen ermittelt, finden Sie unter [Search and Replace Text](/slides/de/androidjava/search-and-replace-text/).

## **Text in einer Tabelle ausrichten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.  
2. Holen Sie sich über den Index eine Referenz auf die Folie.  
3. Fügen Sie ein [ITable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITable) Objekt zur Folie hinzu.  
4. Greifen Sie von der Tabelle aus auf ein [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) Objekt zu.  
5. Greifen Sie auf das [IParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/) des [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) zu.  
6. Richten Sie den Text vertikal aus.  
7. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie den Text in einer Tabelle ausrichten:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Erstellt eine Instanz der Presentation‑Klasse
Presentation pres = new Presentation();
try {
    // Holt die erste Folie 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Fügt das Tabellen‑Shape zur Folie hinzu
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Greift auf den Textrahmen zu
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Erstellt das Paragraph‑Objekt für den Textrahmen
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Erstellt das Portion‑Objekt für das Paragraph
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Richtet den Text vertikal aus
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Speichert die Präsentation auf der Festplatte
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Textformatierung auf Tabellenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.  
2. Holen Sie sich über den Index eine Referenz auf die Folie.  
3. Greifen Sie vom Slide aus auf ein [ITable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITable) Objekt zu.  
4. Setzen Sie die Schriftgröße mittels [setFontHeight(float value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Setzen Sie die Ausrichtung über [setAlignment(int value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) und den rechten Rand über [setMarginRight(float value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Setzen Sie den vertikalen Texttyp mit [setTextVerticalType(byte value)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie Ihre bevorzugten Formatierungsoptionen auf den Text in einer Tabelle anwenden:

```java
import com.aspose.slides.*;

// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Angenommen, die erste Form auf der ersten Folie ist eine Tabelle
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Setzt die Schriftgröße der Tabellenzellen
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Setzt die Textausrichtung und den rechten Rand der Tabellenzellen in einem Aufruf
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Setzt den vertikalen Texttyp der Tabellenzellen
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tabellen‑Stil Eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen der Stil‑Eigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser Java‑Code zeigt, wie Sie die Stil‑Eigenschaften aus einem vordefinierten Tabellenstil erhalten:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // ändert das Standard‑Stil‑Preset 

    // Ermittelt das Stil‑Preset der Tabelle
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // Wendet das abgerufene Stil‑Preset auf eine andere Tabelle an
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Abmessungen in verschiedenen Dimensionen. Aspose.Slides stellt die Eigenschaft [**setAspectRatioLocked**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) bereit, um das Seitenverhältnis von Tabellen und anderen Formen zu sperren.

Dieser Java‑Code zeigt, wie Sie das Seitenverhältnis für eine Tabelle sperren:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // invertieren

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kann ich die Leserichtung von rechts nach links (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Methode [setRightToLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) bereit, und Paragraphen besitzen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Die gleichzeitige Verwendung beider sorgt für die korrekte RTL‑Reihenfolge und -Darstellung innerhalb der Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder die Größe ändern?**

Verwenden Sie Form‑Sperren, um Verschieben, Größenänderung, Auswahl usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/picturefillformat/) festlegen; das Bild deckt den Zellenbereich entsprechend dem gewählten Modus (Strecken oder Kacheln) ab.