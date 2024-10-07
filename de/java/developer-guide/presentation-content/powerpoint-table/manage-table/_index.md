---
title: Tabelle verwalten
type: docs
weight: 10
url: /java/manage-table/
keywords: "Tabelle, Tabelle erstellen, auf Tabelle zugreifen, Seitenverhältnis der Tabelle, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Erstellen und Verwalten von Tabellen in PowerPoint-Präsentationen in Java"
---

Eine Tabelle in PowerPoint ist eine effiziente Möglichkeit, Informationen darzustellen und zu veranschaulichen. Die Informationen in einem Gitter aus Zellen (angeordnet in Zeilen und Spalten) sind klar und leicht verständlich.

Aspose.Slides bietet die [Table](https://reference.aspose.com/slides/java/com.aspose.slides/Table) Klasse, das [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) Interface, die [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) Klasse, das [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) Interface und andere Typen, um Ihnen zu ermöglichen, Tabellen in allen Arten von Präsentationen zu erstellen, zu aktualisieren und zu verwalten.

## **Tabelle von Grund auf erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich einen Verweis auf die Folie durch ihren Index.
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie über die [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) Methode ein [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) Objekt zur Folie hinzu.
6. Durchlaufen Sie jede [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/), um die Formatierung der oberen, unteren, rechten und linken Ränder anzuwenden.
7. Fügen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) einer [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) zu.
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) Text hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie eine Tabelle in einer Präsentation erstellen:

```java
// Erstellt eine Instanz der Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Fügt der Folie eine Tabellenform hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Setzt die Randformatierung für jede Zelle
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
    // Fügt die Zellen 1 & 2 der Zeile 1 zusammen
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Fügt der zusammengeführten Zelle Text hinzu
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Zusammengeführte Zellen");

    // Speichert die Präsentation auf der Festplatte
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nummerierung in Standardtabelle**

In einer Standardtabelle ist die Nummerierung der Zellen einfach und nullbasiert. Die erste Zelle in einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0).

Zum Beispiel sind die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen so nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser Java-Code zeigt Ihnen, wie Sie die Nummerierung für Zellen in einer Tabelle festlegen:

```java
// Erstellt eine Instanz der Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie eine Tabellenform hinzu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Setzt die Randformatierung für jede Zelle
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

## **Auf vorhandene Tabelle zugreifen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.

2. Holen Sie sich einen Verweis auf die Folie, die die Tabelle enthält, durch ihren Index.

3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) Objekt und setzen Sie es auf null.

4. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) Objekte, bis die Tabelle gefunden wird.

   Wenn Sie vermuten, dass die Folie nur eine Tabelle enthält, können Sie einfach alle Formen prüfen, die sie enthält. Wenn eine Form als Tabelle identifiziert wird, können Sie sie als [Table](https://reference.aspose.com/slides/java/com.aspose.slides/Table) Objekt umwandeln. Wenn die Folie jedoch mehrere Tabellen enthält, ist es besser, die Tabelle, die Sie benötigen, über ihre [setAlternativeText(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) zu suchen.

5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel haben wir eine neue Zeile zur Tabelle hinzugefügt.

6. Speichern Sie die geänderte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie auf eine vorhandene Tabelle zugreifen und mit ihr arbeiten:

```java
// Erstellt die Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialisiert null TableEx
    ITable tbl = null;

    // Durchläuft die Formen und setzt einen Verweis auf die gefundene Tabelle
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Setzt den Text für die erste Spalte der zweiten Zeile
            tbl.get_Item(0, 1).getTextFrame().setText("Neu");
        }
    }
    
    // Speichert die geänderte Präsentation auf der Festplatte
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Text in der Tabelle ausrichten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich einen Verweis auf die Folie durch ihren Index.
3. Fügen Sie ein [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) Objekt zur Folie hinzu.
4. Greifen Sie auf ein [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) Objekt aus der Tabelle zu.
5. Greifen Sie auf den [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) zu.
6. Richten Sie den Text vertikal aus.
7. Speichern Sie die geänderte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie den Text in einer Tabelle ausrichten:

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Fügt der Folie die Tabellenform hinzu
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Greift auf das Textfeld zu
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Erstellt das Paragraph-Objekt für das Textfeld
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Erstellt das Portion-Objekt für den Absatz
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text hier");
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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich einen Verweis auf die Folie durch ihren Index.
3. Greifen Sie auf ein [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) Objekt von der Folie zu.
4. Setzen Sie die [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) für den Text.
5. Setzen Sie die [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setzen Sie den [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die geänderte Präsentation. 

Dieser Java-Code zeigt Ihnen, wie Sie die von Ihnen bevorzugten Formatierungsoptionen auf den Text in einer Tabelle anwenden:

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Angenommen, die erste Form auf der ersten Folie ist eine Tabelle
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Setzt die Schriftgröße in den Tabellenzellen
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Setzt die Textausrichtung und den rechten Rand der Tabellenzellen mit einem Aufruf
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Setzt die vertikale Textausrichtung für die Tabellenzellen
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tabellenstil-Eigenschaften abrufen**

Aspose.Slides ermöglicht es Ihnen, die Stileigenschaften für eine Tabelle abzurufen, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser Java-Code zeigt Ihnen, wie Sie die Stileigenschaften aus einem vordefinierten Tabellendesign abrufen:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // Ändert das standardmäßige Stilvordefinitionsthema
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Seitenverhältnis der Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Größen in verschiedenen Dimensionen. Aspose.Slides stellt die [**setAspectRatioLocked**](https://reference.aspose.com/slides/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) Eigenschaft zur Verfügung, die es Ihnen ermöglicht, die Seitenverhältnis-Einstellung für Tabellen und andere Formen zu sperren.

Dieser Java-Code zeigt Ihnen, wie Sie das Seitenverhältnis für eine Tabelle sperren:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Seitenverhältnis gesperrt: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // umkehren

    System.out.println("Seitenverhältnis gesperrt: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```