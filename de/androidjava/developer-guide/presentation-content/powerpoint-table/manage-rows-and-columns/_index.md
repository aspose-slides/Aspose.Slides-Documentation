---
title: Verwalten von Zeilen und Spalten in PowerPoint-Tabellen unter Android
linktitle: Zeilen und Spalten
type: docs
weight: 20
url: /de/androidjava/manage-rows-and-columns/
keywords:
- Tabellenzeile
- Tabellenspalte
- erste Zeile
- Tabellenkopf
- Zeile duplizieren
- Spalte duplizieren
- Zeile kopieren
- Spalte kopieren
- Zeile entfernen
- Spalte entfernen
- Textformatierung der Zeile
- Textformatierung der Spalte
- Tabellenstil
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für Android über Java und beschleunigen Sie die Bearbeitung von Präsentationen sowie Datenaktualisierungen."
---

Um Ihnen zu ermöglichen, Zeilen und Spalten einer Tabelle in einer PowerPoint‑Präsentation zu verwalten, stellt Aspose.Slides die Klasse [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) , das Interface [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) und viele weitere Typen bereit.

## **Erste Zeile als Header festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und laden Sie die Präsentation.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Erzeugen Sie ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) Objekt und setzen Sie es auf null.
4. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) Objekte, um die relevante Tabelle zu finden.
5. Setzen Sie die erste Zeile der Tabelle als Header. 

```java
// Instanziert die Presentation-Klasse
Presentation pres = new Presentation("table.pptx");
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialisiert das null TableEx
    ITable tbl = null;

    // Durchläuft die Shapes und setzt eine Referenz auf die Tabelle
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Setzt die erste Zeile einer Tabelle als Header
            tbl.setFirstRow(true);
        }
    }
    
    // Speichert die Präsentation auf dem Datenträger
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Kopieren einer Tabellenzeile oder -spalte**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und laden Sie die Präsentation,
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index. 
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) Objekt über die Methode [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) hinzu.
6. Kopieren Sie die Tabellenzeile.
7. Kopieren Sie die Tabellenspalte.
8. Speichern Sie die geänderte Präsentation.

```java
 // Instanziert die Presentation-Klasse
Presentation pres = new Presentation("Test.pptx");
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Fügt der Folie ein Tabellen-Shape hinzu
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Fügt der Zeile 1, Zelle 1 Text hinzu
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Fügt der Zeile 1, Zelle 2 Text hinzu
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Klont Zeile 1 am Ende der Tabelle
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Fügt der Zeile 2, Zelle 1 Text hinzu
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Fügt der Zeile 2, Zelle 2 Text hinzu
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Klont Zeile 2 als vierte Zeile der Tabelle
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Klont die erste Spalte am Ende
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Klont die zweite Spalte am Index der vierten Spalte
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Speichert die Präsentation auf dem Datenträger
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Entfernen einer Zeile oder Spalte aus einer Tabelle**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und laden Sie die Präsentation,
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index. 
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) Objekt über die Methode [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) hinzu.
6. Entfernen Sie die Tabellenzeile.
7. Entfernen Sie die Tabellenspalte.
8. Speichern Sie die geänderte Präsentation. 

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


## **Textformatierung auf Zeilenebene der Tabelle festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und laden Sie die Präsentation,
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index. 
3. Greifen Sie vom Folienobjekt auf das relevante [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) Objekt zu.
4. Setzen Sie für die Zellen der ersten Zeile die [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Setzen Sie für die Zellen der ersten Zeile [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setzen Sie für die Zellen der zweiten Zeile [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die geänderte Präsentation.

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Nehmen wir an, dass das erste Shape auf der ersten Folie eine Tabelle ist
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
    
    // Setzt die vertikale Textausrichtung der Zellen der zweiten Zeile
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Speichert die Präsentation auf dem Datenträger
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Textformatierung auf Spaltenebene der Tabelle festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und laden Sie die Präsentation,
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index. 
3. Greifen Sie vom Folienobjekt auf das relevante [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) Objekt zu.
4. Setzen Sie für die Zellen der ersten Spalte die [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Setzen Sie für die Zellen der ersten Spalte [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setzen Sie für die Zellen der zweiten Spalte [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die geänderte Präsentation. 

```java
// Erstelle eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Nehmen wir an, dass das erste Shape auf der ersten Folie eine Tabelle ist
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Setzt die Schrifthöhe der Zellen der ersten Spalte
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


## **Tabellenstil‑Eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen der Stil‑Eigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser Java‑Code zeigt, wie Sie die Stil‑Eigenschaften aus einem vordefinierten Tabellenstil erhalten:
```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // ändert das standardmäßige Stilvorlagen-Thema
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich PowerPoint‑Designs/‑Stile auf eine bereits erstellte Tabelle anwenden?**

Ja. Die Tabelle erbt das Design der Folie/ des Layouts/ des Masters und Sie können dennoch Füllungen, Rahmen und Textfarben über diesem Design überschreiben.

**Kann ich Tabellenzeilen wie in Excel sortieren?**

Nein, Tabellen von Aspose.Slides verfügen nicht über integrierte Sortier‑ oder Filterfunktionen. Sortieren Sie Ihre Daten zuerst im Speicher und füllen Sie anschließend die Tabellenzeilen in dieser Reihenfolge erneut.

**Kann ich banded (gestreifte) Spalten haben und gleichzeitig benutzerdefinierte Farben für bestimmte Zellen beibehalten?**

Ja. Aktivieren Sie banded‑Spalten und überschreiben Sie dann bestimmte Zellen mit lokaler Formatierung; die Zell‑Formatierung hat Vorrang vor dem Tabellenstil.