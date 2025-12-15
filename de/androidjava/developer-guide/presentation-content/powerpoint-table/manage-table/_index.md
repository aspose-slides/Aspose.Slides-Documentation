---
title: Tabellen in Präsentationen auf Android verwalten
linktitle: Tabelle verwalten
type: docs
weight: 10
url: /de/androidjava/manage-table/
keywords:
- Tabelle hinzufügen
- Tabelle erstellen
- Tabelle zugreifen
- Seitenverhältnis
- Text ausrichten
- Textformatierung
- Tabellenstil
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Tabellen in PowerPoint-Folien mit Aspose.Slides für Android erstellen und bearbeiten. Entdecken Sie einfache Java-Codebeispiele, um Ihre Tabellen-Workflows zu optimieren."
---

Eine Tabelle in PowerPoint ist ein effizienter Weg, Informationen darzustellen und zu präsentieren. Die Informationen in einem Gitter von Zellen (angeordnet in Zeilen und Spalten) sind klar und leicht zu verstehen.

Aspose.Slides bietet die [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table)-Klasse, das [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable)-Interface, die [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/)-Klasse, das [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/)-Interface und weitere Typen, um Tabellen in allen Arten von Präsentationen zu erstellen, zu aktualisieren und zu verwalten.

## **Eine Tabelle aus dem Nichts erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.  
2. Holen Sie über den Index eine Referenz auf die Folie.  
3. Definieren Sie ein Array von `columnWidth`.  
4. Definieren Sie ein Array von `rowHeight`.  
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable)-Objekt über die Methode [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) hinzu.  
6. Durchlaufen Sie jedes [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/), um die Formatierung der oberen, unteren, rechten und linken Ränder anzuwenden.  
7. Fügen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.  
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/)-Objekt einer [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/)-Zelle zu.  
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) Text hinzu.  
10. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie eine Tabelle in einer Präsentation erstellen:
```java
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Fügt der Folie ein Tabellenelement hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Legt das Randformat für jede Zelle fest
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
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Fügt dem zusammengefügten Feld Text hinzu
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Speichert die Präsentation auf dem Datenträger
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Nummerierung in einer Standardtabelle**

In einer Standardtabelle ist die Nummerierung der Zellen einfach und nullbasiert. Die erste Zelle einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0).

Beispielsweise werden die Zellen einer Tabelle mit 4 Spalten und 4 Zeilen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser Java‑Code zeigt, wie Sie die Nummerierung für Zellen in einer Tabelle festlegen:
```java
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie ein Tabellenelement hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Legt das Randformat für jede Zelle fest
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

    // Speichert die Präsentation auf dem Datenträger
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eine vorhandene Tabelle zugreifen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.  

2. Holen Sie über den Index eine Referenz auf die Folie, die die Tabelle enthält.  

3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable)-Objekt und setzen Sie es auf null.  

4. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)-Objekte, bis die Tabelle gefunden wird.  

   Wenn Sie vermuten, dass die betreffende Folie nur eine einzelne Tabelle enthält, können Sie einfach alle Shapes prüfen. Wird ein Shape als Tabelle identifiziert, können Sie es in ein [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table)-Objekt casten. Enthält die Folie mehrere Tabellen, sollten Sie die gewünschte Tabelle über deren [setAlternativeText(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) suchen.  

5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable)-Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel fügen wir der Tabelle eine neue Zeile hinzu.  

6. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie auf eine vorhandene Tabelle zugreifen und mit ihr arbeiten:
```java
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialisiert null TableEx
    ITable tbl = null;

    // Durchläuft die Shapes und setzt eine Referenz auf die gefundene Tabelle
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Setzt den Text für die erste Spalte der zweiten Zeile
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Speichert die modifizierte Präsentation auf dem Datenträger
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Text in einer Tabelle ausrichten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.  
2. Holen Sie über den Index eine Referenz auf die Folie.  
3. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable)-Objekt hinzu.  
4. Greifen Sie von der Tabelle aus auf ein [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)-Objekt zu.  
5. Greifen Sie auf das [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/)-Objekt des [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) zu.  
6. Richten Sie den Text vertikal aus.  
7. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie den Text in einer Tabelle ausrichten:
```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Holt die erste Folie 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Fügt der Folie das Tabellenelement hinzu
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Greift auf den Textrahmen zu
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Erstellt das Paragraph-Objekt für den Textrahmen
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Erstellt das Portion-Objekt für den Paragraphen
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Richtet den Text vertikal aus
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Speichert die Präsentation auf dem Datenträger
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Textformatierung auf Tabellenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.  
2. Holen Sie über den Index eine Referenz auf die Folie.  
3. Greifen Sie von der Folie aus auf ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable)-Objekt zu.  
4. Setzen Sie die Schriftgröße über [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Verwenden Sie [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Setzen Sie die vertikale Textausrichtung mit [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie Ihre bevorzugten Formatierungsoptionen auf den Text in einer Tabelle anwenden:
```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Angenommen, das erste Shape auf der ersten Folie ist eine Tabelle
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


## **Tabellenstil‑Eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen von Stil‑Eigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser Java‑Code zeigt, wie Sie die Stil‑Eigenschaften aus einem Tabellenvorlagenstil erhalten:
```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // ändert das Standard-Style-Preset-Thema
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Größen in verschiedenen Dimensionen. Aspose.Slides stellt die Eigenschaft [**setAspectRatioLocked**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) bereit, um das Seitenverhältnis von Tabellen und anderen Formen zu sperren.

Dieser Java‑Code zeigt, wie Sie das Seitenverhältnis für eine Tabelle sperren:
```java
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

**Kann ich die Lesrichtung von rechts nach links (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Methode [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) bereit, und Absätze besitzen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Die Kombination sorgt für die korrekte RTL‑Reihenfolge und Darstellung in den Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der finalen Datei verschieben oder deren Größe ändern?**

Verwenden Sie [Shape‑Locks](/slides/de/androidjava/applying-protection-to-presentation/), um Bewegung, Größenänderung, Auswahl usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) festlegen; das Bild bedeckt den Zellenbereich gemäß dem gewählten Modus (Strecken oder Kacheln).