---
title: Zeilen und Spalten verwalten
type: docs
weight: 20
url: /de/php-java/manage-rows-and-columns/
keywords: "Tabelle, Tabellenzeilen und -spalten, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint-Präsentationen"
---

Um Ihnen die Verwaltung der Zeilen und Spalten einer Tabelle in einer PowerPoint-Präsentation zu ermöglichen, stellt Aspose.Slides die [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) Klasse, das [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Interface und viele andere Typen bereit.

## **Die erste Zeile als Kopfzeile festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse und laden Sie die Präsentation.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt und setzen Sie es auf null.
4. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) Objekte, um die relevante Tabelle zu finden.
5. Setzen Sie die erste Zeile der Tabelle als Kopfzeile.

Dieser PHP-Code zeigt Ihnen, wie Sie die erste Zeile einer Tabelle als Kopfzeile festlegen:

```php
  # Instanziiert die Presentation-Klasse
  $pres = new Presentation("table.pptx");
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Initialisiert die null TableEx
    $tbl = null;
    # Durchläuft die Shapes und setzt eine Referenz zur Tabelle
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Setzt die erste Zeile einer Tabelle als Kopfzeile
        $tbl->setFirstRow(true);
      }
    }
    # Speichert die Präsentation auf der Festplatte
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Zeile oder Spalte der Tabelle klonen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse und laden Sie die Präsentation,
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt zur Folie mit der [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---) Methode hinzu.
6. Klonen Sie die Tabellenzeile.
7. Klonen Sie die Tabellenspalte.
8. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Zeile oder Spalte einer PowerPoint-Tabelle klonen:

```php
  # Instanziiert die Presentation-Klasse
  $pres = new Presentation("Test.pptx");
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Fügt eine Tabellenform zur Folie hinzu
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Fügt etwas Text zur Zeile 1, Zelle 1 hinzu
    $table->get_Item(0, 0)->getTextFrame()->setText("Zeile 1 Zelle 1");
    # Fügt etwas Text zur Zeile 1, Zelle 2 hinzu
    $table->get_Item(1, 0)->getTextFrame()->setText("Zeile 1 Zelle 2");
    # Klont Zeile 1 am Ende der Tabelle
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Fügt etwas Text zur Zeile 2, Zelle 1 hinzu
    $table->get_Item(0, 1)->getTextFrame()->setText("Zeile 2 Zelle 1");
    # Fügt etwas Text zur Zeile 2, Zelle 2 hinzu
    $table->get_Item(1, 1)->getTextFrame()->setText("Zeile 2 Zelle 2");
    # Klont Zeile 2 als 4. Zeile der Tabelle
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Klont die erste Spalte am Ende
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Klont die 2. Spalte an der 4. Spaltenposition
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Speichert die Präsentation auf der Festplatte
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zeile oder Spalte aus der Tabelle entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse und laden Sie die Präsentation,
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt zur Folie mit der [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---) Methode hinzu.
6. Entfernen Sie die Tabellenzeile.
7. Entfernen Sie die Tabellenspalte.
8. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Zeile oder Spalte aus einer Tabelle entfernen:

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

## **Textformatierung auf Tabellenzeilenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse und laden Sie die Präsentation,
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Greifen Sie auf das relevante [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt von der Folie zu.
4. Setzen Sie die Schriftgröße der Zellen der ersten Zeile mit [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).
5. Setzen Sie die Textausrichtung und den rechten Rand der Zellen der ersten Zeile mit [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setzen Sie den vertikalen Texttyp der Zellen der zweiten Zeile mit [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code demonstriert den Vorgang:

```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Angenommen, dass die erste Form auf der ersten Folie eine Tabelle ist
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
    # Speichert die Präsentation auf der Festplatte
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Textformatierung auf Tabellen-Spaltenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse und laden Sie die Präsentation,
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Greifen Sie auf das relevante [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt von der Folie zu.
4. Setzen Sie die Schriftgröße der Zellen der ersten Spalte mit [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).
5. Setzen Sie die Textausrichtung und den rechten Rand der Zellen der ersten Spalte mit [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setzen Sie den vertikalen Texttyp der Zellen der zweiten Spalte mit [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code demonstriert den Vorgang:

```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Angenommen, dass die erste Form auf der ersten Folie eine Tabelle ist
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

## **Tabellenstil-Eigenschaften abrufen**

Aspose.Slides ermöglicht es Ihnen, die Stileigenschaften für eine Tabelle abzurufen, sodass Sie diese Details für eine andere Tabelle oder anderswo verwenden können. Dieser PHP-Code zeigt Ihnen, wie Sie die Stileigenschaften von einem vordefinierten Stil einer Tabelle abrufen:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// Ändert das Standard-Stilvorgabethema

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```