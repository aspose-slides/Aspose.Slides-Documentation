---
title: Zeilen und Spalten verwalten
type: docs
weight: 20
url: /de/nodejs-java/manage-rows-and-columns/
keywords: "Tabelle, Tabellenzeilen und -spalten, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "Verwalten von Tabellenzeilen und -spalten in PowerPoint-Präsentationen in JavaScript"
---

Um Ihnen zu ermöglichen, die Zeilen und Spalten einer Tabelle in einer PowerPoint-Präsentation zu verwalten, stellt Aspose.Slides die Klasse [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) bereit, die Klasse [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) und viele weitere Typen.

## **Erste Zeile als Kopfzeile festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und laden Sie die Präsentation.  
2. Holen Sie sich eine Referenz auf die Folie über deren Index.  
3. Erstellen Sie ein [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table)‑Objekt und setzen Sie es auf null.  
4. Iterieren Sie über alle [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑Objekte, um die entsprechende Tabelle zu finden.  
5. Setzen Sie die erste Zeile der Tabelle als deren Kopfzeile.  

Dieser JavaScript‑Code zeigt, wie Sie die erste Zeile einer Tabelle als Kopfzeile festlegen:
```javascript
// Instanziert die Presentation-Klasse
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Greift auf die erste Folie zu
    var sld = pres.getSlides().get_Item(0);
    // Initialisiert das null TableEx
    var tbl = null;
    // Durchläuft die Shapes und setzt eine Referenz auf die Tabelle
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Setzt die erste Zeile einer Tabelle als deren Kopfzeile
            tbl.setFirstRow(true);
        }
    }
    // Speichert die Präsentation auf dem Datenträger
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zeile oder Spalte einer Tabelle klonen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und laden Sie die Präsentation,  
2. Holen Sie sich eine Referenz auf die Folie über deren Index.  
3. Definieren Sie ein Array für `columnWidth`.  
4. Definieren Sie ein Array für `rowHeight`.  
5. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table)‑Objekt über die Methode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) hinzu.  
6. Klonen Sie die Tabellenzeile.  
7. Klonen Sie die Tabellenspalte.  
8. Speichern Sie die modifizierte Präsentation.  

Dieser JavaScript‑Code zeigt, wie Sie eine Zeile oder Spalte einer PowerPoint‑Tabelle klonen:
```javascript
// Instanziert die Presentation-Klasse
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Greift auf die erste Folie zu
    var sld = pres.getSlides().get_Item(0);
    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Fügt ein Tabellen-Shape zur Folie hinzu
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Fügt Text zur Zeile 1, Zelle 1 hinzu
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Fügt Text zur Zeile 1, Zelle 2 hinzu
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Klont Zeile 1 am Ende der Tabelle
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Fügt Text zur Zeile 2, Zelle 1 hinzu
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Fügt Text zur Zeile 2, Zelle 2 hinzu
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Klont Zeile 2 als 4. Zeile der Tabelle
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Klont die erste Spalte am Ende
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Klont die 2. Spalte am Index 4
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Speichert die Präsentation auf dem Datenträger
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zeile oder Spalte aus einer Tabelle entfernen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und laden Sie die Präsentation,  
2. Holen Sie sich eine Referenz auf die Folie über deren Index.  
3. Definieren Sie ein Array für `columnWidth`.  
4. Definieren Sie ein Array für `rowHeight`.  
5. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table)‑Objekt über die Methode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) hinzu.  
6. Entfernen Sie die Tabellenzeile.  
7. Entfernen Sie die Tabellenspalte.  
8. Speichern Sie die modifizierte Präsentation.  

Dieser JavaScript‑Code zeigt, wie Sie eine Zeile oder Spalte aus einer Tabelle entfernen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Textformatierung auf Zeilenebene einer Tabelle festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und laden Sie die Präsentation,  
2. Holen Sie sich eine Referenz auf die Folie über deren Index.  
3. Greifen Sie vom Folienobjekt auf das entsprechende [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table)‑Objekt zu.  
4. Setzen Sie für die Zellen der ersten Zeile die [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Setzen Sie für die Zellen der ersten Zeile [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Setzen Sie für die Zellen der zweiten Zeile [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Speichern Sie die modifizierte Präsentation.  

Dieser JavaScript‑Code demonstriert den Vorgang.
```javascript
// Instanziert die Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Angenommen, die erste Form auf der ersten Folie ist eine Tabelle
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Setzt die Schriftgröße der Zellen der ersten Zeile
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Setzt die Textausrichtung und den rechten Rand der Zellen der ersten Zeile
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Setzt den vertikalen Texttyp der Zellen der zweiten Zeile
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Speichert die Präsentation auf dem Datenträger
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Textformatierung auf Spaltenebene einer Tabelle festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und laden Sie die Präsentation,  
2. Holen Sie sich eine Referenz auf die Folie über deren Index.  
3. Greifen Sie vom Folienobjekt auf das entsprechende [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table)‑Objekt zu.  
4. Setzen Sie für die Zellen der ersten Spalte die [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Setzen Sie für die Zellen der ersten Spalte [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Setzen Sie für die Zellen der zweiten Spalte [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Speichern Sie die modifizierte Präsentation.  

Dieser JavaScript‑Code demonstriert den Vorgang:
```javascript
// Erstellt eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Angenommen, die erste Form auf der ersten Folie ist eine Tabelle
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Setzt die Schriftgröße der Zellen der ersten Spalte
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Setzt die Textausrichtung und den rechten Rand der Zellen der ersten Spalte in einem Aufruf
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Setzt den vertikalen Texttyp der Zellen der zweiten Spalte
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Tabellenstil‑Eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen der Stileigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser JavaScript‑Code zeigt, wie Sie die Stileigenschaften aus einem vordefinierten Tabellensstil erhalten:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// ändert das Standard-Stilvorlagen-Thema
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich PowerPoint-Themen/‑Stile auf eine bereits erstellte Tabelle anwenden?**

Ja. Die Tabelle erbt das Folien‑/Layout‑/Master‑Thema, und Sie können trotzdem Füllungen, Rahmen und Textfarben darüber hinweg überschreiben.

**Kann ich Tabellenzeilen wie in Excel sortieren?**

Nein, Aspose.Slides‑Tabellen besitzen keine integrierte Sortierung oder Filter. Sortieren Sie Ihre Daten zuerst im Speicher und füllen Sie dann die Tabellenzeilen in dieser Reihenfolge erneut.

**Kann ich banded (gestreifte) Spalten haben und gleichzeitig individuelle Farben für bestimmte Zellen beibehalten?**

Ja. Aktivieren Sie gestreifte Spalten und überschreiben Sie dann bestimmte Zellen mit lokaler Formatierung; die Formatierung auf Zellebene hat Vorrang vor dem Tabellenstil.