---
title: Zeilen und Spalten verwalten
type: docs
weight: 20
url: /de/java/manage-rows-and-columns/
keywords: "Tabelle, Tabellenzeilen und -spalten, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Verwalten von Tabellenzeilen und -spalten in PowerPoint-Präsentationen in Java"
---

Um Ihnen die Verwaltung der Zeilen und Spalten einer Tabelle in einer PowerPoint-Präsentation zu ermöglichen, bietet Aspose.Slides die [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) Klasse, das [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) Interface und viele andere Typen an.

## **Erste Zeile als Kopfzeile festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse und laden Sie die Präsentation.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) Objekt und setzen Sie es auf null.
4. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) Objekte, um die relevante Tabelle zu finden.
5. Setzen Sie die erste Zeile der Tabelle als Kopfzeile.

Dieser Java-Code zeigt, wie Sie die erste Zeile einer Tabelle als Kopfzeile festlegen:

```java
// Instanziiert die Presentation-Klasse
Presentation pres = new Presentation("table.pptx");
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialisiert die null TableEx
    ITable tbl = null;

    // Durchläuft die Shapes und setzt eine Referenz auf die Tabelle
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Setzt die erste Zeile einer Tabelle als Kopfzeile
            tbl.setFirstRow(true);
        }
    }
    
    // Speichert die Präsentation auf der Festplatte
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tabelle Zeile oder Spalte klonen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse und laden Sie die Präsentation,
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) Objekt zur Folie über die [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) Methode hinzu.
6. Klonen Sie die Tabellenzeile.
7. Klonen Sie die Tabellenspalte.
8. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt, wie Sie eine Zeile oder Spalte einer PowerPoint-Tabelle klonen:

```java
 // Instanziiert die Presentation-Klasse
Presentation pres = new Presentation("Test.pptx");
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Fügt eine Tabellenform zur Folie hinzu
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Fügt etwas Text zur Zeile 1 Zelle 1 hinzu
    table.get_Item(0, 0).getTextFrame().setText("Zeile 1 Zelle 1");

    // Fügt etwas Text zur Zeile 1 Zelle 2 hinzu
    table.get_Item(1, 0).getTextFrame().setText("Zeile 1 Zelle 2");

    // Klont Zeile 1 am Ende der Tabelle
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Fügt etwas Text zur Zeile 2 Zelle 1 hinzu
    table.get_Item(0, 1).getTextFrame().setText("Zeile 2 Zelle 1");

    // Fügt etwas Text zur Zeile 2 Zelle 2 hinzu
    table.get_Item(1, 1).getTextFrame().setText("Zeile 2 Zelle 2");

    // Klont Zeile 2 als 4. Zeile der Tabelle
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Klont die erste Spalte ans Ende
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Klont die 2. Spalte am 4. Spaltenindex
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Speichert die Präsentation auf der Festplatte
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zeile oder Spalte aus der Tabelle entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse und laden Sie die Präsentation,
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) Objekt zur Folie über die [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) Methode hinzu.
6. Entfernen Sie die Tabellenzeile.
7. Entfernen Sie die Tabellenspalte.
8. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt, wie Sie eine Zeile oder Spalte aus einer Tabelle entfernen:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Textformatierung auf Zeilenebene in der Tabelle festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse und laden Sie die Präsentation,
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Greifen Sie auf das relevante [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) Objekt von der Folie zu.
4. Setzen Sie die Schriftgröße der Zellen der ersten Zeile [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Setzen Sie die Textausrichtung und den rechten Rand der Zellen der ersten Zeile [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setzen Sie den vertikalen Texttyp der Zellen der zweiten Zeile [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code demonstriert die Operation.

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Angenommen, die erste Form auf der ersten Folie ist eine Tabelle
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Setzt die Schriftgröße der Zellen der ersten Zeile
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Setzt die Textausrichtung und den rechten Rand der Zellen der ersten Zeile
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Setzt den vertikalen Texttyp der Zellen der zweiten Zeile
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Speichert die Präsentation auf der Festplatte
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Textformatierung auf Spaltenebene in der Tabelle festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse und laden Sie die Präsentation,
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Greifen Sie auf das relevante [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) Objekt von der Folie zu.
4. Setzen Sie die Schriftgröße der Zellen der ersten Spalte [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Setzen Sie die Textausrichtung und den rechten Rand der Zellen der ersten Spalte [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setzen Sie den vertikalen Texttyp der Zellen der zweiten Spalte [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code demonstriert die Operation:

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Angenommen, die erste Form auf der ersten Folie ist eine Tabelle
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Setzt die Schriftgröße der Zellen der ersten Spalte
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Setzt die Textausrichtung und den rechten Rand der Zellen der ersten Spalte in einem Aufruf
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Setzt den vertikalen Texttyp der Zellen der zweiten Spalte
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tabelle Stil Eigenschaften abrufen**

Aspose.Slides ermöglicht es Ihnen, die Stileigenschaften für eine Tabelle abzurufen, sodass Sie diese Details für eine andere Tabelle oder anderswo verwenden können. Dieser Java-Code zeigt Ihnen, wie Sie die Stileigenschaften aus einem vordefinierten Tabellenstil abrufen:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // Ändert das Standardstil-Voreinstellungs-Theme
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```