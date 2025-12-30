---
title: Verwalten von Zeilen und Spalten in PowerPoint-Tabellen mit PHP
linktitle: Zeilen und Spalten
type: docs
weight: 20
url: /de/php-java/manage-rows-and-columns/
keywords:
- Tabellenzeile
- Tabellenspalte
- erste Zeile
- Tabellenkopfzeile
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
- PHP
- Aspose.Slides
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für PHP über Java und beschleunigen Sie die Bearbeitung von Präsentationen und Datenaktualisierungen."
---

Um Ihnen zu ermöglichen, Zeilen und Spalten einer Tabelle in einer PowerPoint‑Präsentation zu verwalten, stellt Aspose.Slides die Klasse [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) , das Interface [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) und viele weitere Typen bereit.

## **Erste Zeile als Kopfzeile festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und laden Sie die Präsentation.  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Erstellen Sie ein Objekt vom Typ [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) und setzen Sie es auf null.  
4. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) Objekte, um die relevante Tabelle zu finden.  
5. Setzen Sie die erste Zeile der Tabelle als Kopfzeile.  

Dieser PHP‑Code zeigt, wie Sie die erste Zeile einer Tabelle als Kopfzeile festlegen:
```php
  # Instanziiert die Presentation-Klasse
  $pres = new Presentation("table.pptx");
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Initialisiert das null TableEx
    $tbl = null;
    # Iteriert durch die Shapes und setzt eine Referenz auf die Tabelle
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Setzt die erste Zeile einer Tabelle als Kopfzeile
        $tbl->setFirstRow(true);
      }
    }
    # Speichert die Präsentation auf die Festplatte
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Tabellenzeile oder -spalte klonen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und laden Sie die Präsentation,  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Definieren Sie ein Array von `columnWidth`.  
4. Definieren Sie ein Array von `rowHeight`.  
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt mittels der Methode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---) hinzu.  
6. Klonen Sie die Tabellenzeile.  
7. Klonen Sie die Tabellenspalte.  
8. Speichern Sie die geänderte Präsentation.  

Dieser PHP‑Code zeigt, wie Sie eine Zeile oder Spalte einer PowerPoint‑Tabelle klonen:
```php
  # Instanziiert die Presentation-Klasse
  $pres = new Presentation("Test.pptx");
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Fügt der Folie ein Tabellenelement hinzu
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Fügt Text zu Zeile 1 Zelle 1 hinzu
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Fügt Text zu Zeile 1 Zelle 2 hinzu
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Klont Zeile 1 am Ende der Tabelle
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Fügt Text zu Zeile 2 Zelle 1 hinzu
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Fügt Text zu Zeile 2 Zelle 2 hinzu
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Klont Zeile 2 als 4. Zeile der Tabelle
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Klont die erste Spalte am Ende
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Klont die 2. Spalte am Index 4
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Speichert die Präsentation auf die Festplatte
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eine Zeile oder Spalte aus einer Tabelle entfernen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und laden Sie die Präsentation,  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Definieren Sie ein Array von `columnWidth`.  
4. Definieren Sie ein Array von `rowHeight`.  
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt mittels der Methode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---) hinzu.  
6. Entfernen Sie die Tabellenzeile.  
7. Entfernen Sie die Tabellenspalte.  
8. Speichern Sie die geänderte Präsentation.  

Dieser PHP‑Code zeigt, wie Sie eine Zeile oder Spalte aus einer Tabelle entfernen:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Textformatierung auf Zeilenebene der Tabelle festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und laden Sie die Präsentation,  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Greifen Sie vom Folienobjekt auf das entsprechende [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt zu.  
4. Setzen Sie für die Zellen der ersten Zeile [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Setzen Sie für die Zellen der ersten Zeile [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Setzen Sie für die Zellen der zweiten Zeile [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Speichern Sie die geänderte Präsentation.  

Dieser PHP‑Code demonstriert den Vorgang.
```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Angenommen, die erste Form auf der ersten Folie ist eine Tabelle
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Setzt die Schriftgröße der Zellen der ersten Zeile
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Setzt die Textausrichtung und den rechten Rand der Zellen der ersten Zeile
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Setzt den vertikalen Texttyp der Zellen der zweiten Zeile
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Speichert die Präsentation auf die Festplatte
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Textformatierung auf Spaltenebene der Tabelle festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und laden Sie die Präsentation,  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Greifen Sie vom Folienobjekt auf das entsprechende [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt zu.  
4. Setzen Sie für die Zellen der ersten Spalte [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Setzen Sie für die Zellen der ersten Spalte [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Setzen Sie für die Zellen der zweiten Spalte [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Speichern Sie die geänderte Präsentation.  

Dieser PHP‑Code demonstriert den Vorgang:
```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Angenommen, die erste Form auf der ersten Folie ist eine Tabelle
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Setzt die Schriftgröße der Zellen der ersten Spalte
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Setzt die Textausrichtung und den rechten Rand der Zellen der ersten Spalte in einem Aufruf
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Setzt den vertikalen Texttyp der Zellen der zweiten Spalte
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Tabellenstil‑Eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen der Stileigenschaften einer Tabelle, damit Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser PHP‑Code zeigt, wie Sie die Stileigenschaften aus einem vordefinierten Tabellestil erhalten:
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// ändert das Standard-Stilvorlagen-Thema

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich PowerPoint‑Themen/‑Stile auf eine bereits erstellte Tabelle anwenden?**  
Ja. Die Tabelle erbt das Thema der Folie/ des Layouts/ des Masters und Sie können dennoch Füllungen, Rahmen und Textfarben über diesem Thema überschreiben.

**Kann ich Tabellenzeilen wie in Excel sortieren?**  
Nein, Tabellen von Aspose.Slides besitzen keine integrierte Sortierung oder Filter. Sortieren Sie Ihre Daten zuerst im Speicher und füllen Sie anschließend die Tabellenzeilen in dieser Reihenfolge wieder.

**Kann ich banded (gestreifte) Spalten haben und dabei benutzerdefinierte Farben für bestimmte Zellen beibehalten?**  
Ja. Aktivieren Sie banded Spalten und überschreiben Sie dann bestimmte Zellen mit lokaler Formatierung; die Zellen‑Formatierung hat Vorrang vor dem Tabellenstil.