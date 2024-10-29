---
title: Zeilen und Spalten verwalten
type: docs
weight: 20
url: /de/androidjava/manage-rows-and-columns/
keywords: "Tabelle, Tabellenzeilen und -spalten, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint-Präsentationen in Java"
---

Um Ihnen zu ermöglichen, die Zeilen und Spalten einer Tabelle in einer PowerPoint-Präsentation zu verwalten, bietet Aspose.Slides die [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) Klasse, das [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) Interface und viele andere Typen.

## **Setzen Sie die erste Zeile als Header**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse und laden Sie die Präsentation.
2. Erhalten Sie eine Referenz auf die Folie über ihren Index.
3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) Objekt und setzen Sie es auf null.
4. Iterieren Sie durch alle [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) Objekte, um die relevante Tabelle zu finden.
5. Setzen Sie die erste Zeile der Tabelle als ihren Header.

Dieser Java-Code zeigt Ihnen, wie Sie die erste Zeile einer Tabelle als ihren Header festlegen:

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
            
            //Setzt die erste Zeile einer Tabelle als ihren Header
            tbl.setFirstRow(true);
        }
    }
    
    // Speichert die Präsentation auf der Festplatte
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Clone Zeile oder Spalte der Tabelle**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse und laden Sie die Präsentation,
2. Erhalten Sie eine Referenz auf die Folie über ihren Index.
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) Objekt zur Folie über die [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) Methode hinzu.
6. Klonen Sie die Tabellenzeile.
7. Klonen Sie die Tabellenspalte.
8. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie eine Zeile oder Spalte einer PowerPoint-Tabelle klonen:

```java
 // Instanziiert die Presentation-Klasse
Presentation pres = new Presentation("Test.pptx");
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Fügt ein Tabellen-Shape zur Folie hinzu
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

    // Klont die erste Spalte am Ende
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Klont die 2. Spalte am 4. Spaltenindex
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Speichert die Präsentation auf der Festplatte
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Entfernen Sie Zeile oder Spalte aus der Tabelle**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse und laden Sie die Präsentation,
2. Erhalten Sie eine Referenz auf die Folie über ihren Index.
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) Objekt zur Folie über die [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) Methode hinzu.
6. Entfernen Sie die Tabellenzeile.
7. Entfernen Sie die Tabellenspalte.
8. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie eine Zeile oder Spalte aus einer Tabelle entfernen:

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

## **Setzen Sie die Textformatierung auf Tabellenzeilenebene**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse und laden Sie die Präsentation,
2. Erhalten Sie eine Referenz auf die Folie über ihren Index.
3. Greifen Sie auf das relevante [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) Objekt von der Folie zu.
4. Setzen Sie die Schriftgröße der Zellen der ersten Zeile mit [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Setzen Sie die Ausrichtung der Zellen der ersten Zeile mit [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setzen Sie den vertikalen Texttyp der Zellen der zweiten Zeile mit [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code demonstriert die Operation.

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Angenommen, dass die erste Form auf der ersten Folie eine Tabelle ist
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

## **Setzen Sie die Textformatierung auf Tabellenkolonnenebene**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse und laden Sie die Präsentation,
2. Erhalten Sie eine Referenz auf die Folie über ihren Index.
3. Greifen Sie auf das relevante [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) Objekt von der Folie zu.
4. Setzen Sie die Schriftgröße der Zellen der ersten Spalte mit [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Setzen Sie die Ausrichtung der Zellen der ersten Spalte mit [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setzen Sie den vertikalen Texttyp der Zellen der zweiten Spalte mit [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code demonstriert die Operation: 

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Angenommen, dass die erste Form auf der ersten Folie eine Tabelle ist
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

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

## **Tabellenstil Eigenschaften abrufen**

Aspose.Slides ermöglicht es Ihnen, die Stileigenschaften für eine Tabelle abzurufen, sodass Sie diese Details für eine andere Tabelle oder anderswo verwenden können. Dieser Java-Code zeigt Ihnen, wie Sie die Stileigenschaften aus einem vordefinierten Tabellenstil abrufen:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // Ändern Sie das Standardstilvorgabethema
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```