---
title: Zeilen und Spalten in PowerPoint-Tabellen mit Java verwalten
linktitle: Zeilen und Spalten
type: docs
weight: 20
url: /de/java/manage-rows-and-columns/
keywords:
- Tabellenzeile
- Tabellenspalte
- erste Zeile
- Tabellenkopf
- Zeile klonen
- Spalte klonen
- Zeile kopieren
- Spalte kopieren
- Zeile entfernen
- Spalte entfernen
- Textformatierung der Zeile
- Textformatierung der Spalte
- Tabellenstil
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für Java und beschleunigen Sie die Präsentationsbearbeitung sowie Datenaktualisierungen."
---

Um Ihnen zu ermöglichen, die Zeilen und Spalten einer Tabelle in einer PowerPoint‑Präsentation zu verwalten, stellt Aspose.Slides die Klasse [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) bereit, das Interface [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) und viele weitere Typen. 

## **Erste Zeile als Header festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation. 
2. Rufen Sie über den Index eine Folienreferenz ab. 
3. Erzeugen Sie ein [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)‑Objekt und setzen Sie es auf null. 
4. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑Objekte, um die gewünschte Tabelle zu finden. 
5. Legen Sie die erste Zeile der Tabelle als Header fest. 

Dieser Java‑Code zeigt, wie Sie die erste Zeile einer Tabelle als Header festlegen:
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
            
            //Setzt die erste Zeile einer Tabelle als Header
            tbl.setFirstRow(true);
        }
    }
    
    // Speichert die Präsentation auf der Festplatte
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Tabellenzeile oder -spalte klonen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, 
2. Rufen Sie über den Index eine Folienreferenz ab. 
3. Definieren Sie ein Array von `columnWidth`. 
4. Definieren Sie ein Array von `rowHeight`. 
5. Fügen Sie der Folie über die Methode [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) ein [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)‑Objekt hinzu. 
6. Klonen Sie die Tabellenzeile. 
7. Klonen Sie die Tabellenspalte. 
8. Speichern Sie die geänderte Präsentation. 

Dieser Java‑Code zeigt, wie Sie eine Zeile oder Spalte einer PowerPoint‑Tabelle klonen:
```java
 // Instanziert die Presentation-Klasse
Presentation pres = new Presentation("Test.pptx");
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Fügt der Folie ein Tabellenshape hinzu
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Fügt Text in Zeile 1, Zelle 1 ein
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Fügt Text in Zeile 1, Zelle 2 ein
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Klont Zeile 1 am Ende der Tabelle
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Fügt Text in Zeile 2, Zelle 1 ein
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Fügt Text in Zeile 2, Zelle 2 ein
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Klont Zeile 2 als vierte Zeile der Tabelle
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Klont die erste Spalte am Ende
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Klont die zweite Spalte an vierter Spaltenposition
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Speichert die Präsentation auf die Festplatte
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zeile oder Spalte aus einer Tabelle entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, 
2. Rufen Sie über den Index eine Folienreferenz ab. 
3. Definieren Sie ein Array von `columnWidth`. 
4. Definieren Sie ein Array von `rowHeight`. 
5. Fügen Sie der Folie über die Methode [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) ein [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)‑Objekt hinzu. 
6. Entfernen Sie die Tabellenzeile. 
7. Entfernen Sie die Tabellenspalte. 
8. Speichern Sie die geänderte Präsentation. 

Dieser Java‑Code zeigt, wie Sie eine Zeile oder Spalte aus einer Tabelle entfernen:
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


## **Textformatierung auf Zeilenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, 
2. Rufen Sie über den Index eine Folienreferenz ab. 
3. Greifen Sie von der Folie auf das entsprechende [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)‑Objekt zu. 
4. Setzen Sie für die Zellen der ersten Zeile [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Setzen Sie für die Zellen der ersten Zeile [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Setzen Sie für die Zellen der zweiten Zeile [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Speichern Sie die geänderte Präsentation. 

Dieser Java‑Code demonstriert die Vorgehensweise.
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


## **Textformatierung auf Spaltenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse und laden Sie die Präsentation, 
2. Rufen Sie über den Index eine Folienreferenz ab. 
3. Greifen Sie von der Folie auf das entsprechende [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)‑Objekt zu. 
4. Setzen Sie für die Zellen der ersten Spalte [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Setzen Sie für die Zellen der ersten Spalte [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Setzen Sie für die Zellen der zweiten Spalte [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Speichern Sie die geänderte Präsentation. 

Dieser Java‑Code demonstriert die Vorgehensweise: 
```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Angenommen, die erste Form auf der ersten Folie ist eine Tabelle
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


## **Tabellen‑Stileigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen der Stileigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser Java‑Code zeigt, wie Sie die Stileigenschaften aus einem vordefinierten Tabellensstil erhalten:
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


## **FAQ**

**Kann ich PowerPoint‑Designs/‑Stile auf eine bereits erstellte Tabelle anwenden?**

Ja. Die Tabelle erbt das Design der Folie/Layouts/Master und Sie können dennoch Füllungen, Rahmen und Textfarben über diesem Design überschreiben.

**Kann ich Tabellenzeilen wie in Excel sortieren?**

Nein, Aspose.Slides‑Tabellen besitzen keine integrierte Sortier‑ oder Filterfunktion. Sortieren Sie Ihre Daten zuerst im Speicher und füllen Sie anschließend die Tabellenzeilen in dieser Reihenfolge erneut.

**Kann ich banded (gestreifte) Spalten haben und gleichzeitig individuelle Farben für bestimmte Zellen beibehalten?**

Ja. Aktivieren Sie banded Spalten und überschreiben Sie dann einzelne Zellen mit lokaler Formatierung; die Zellen‑Formatierung hat Vorrang vor dem Tabellensstil.