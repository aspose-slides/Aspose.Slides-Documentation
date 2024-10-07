---
title: Tabelle verwalten
type: docs
weight: 10
url: /php-java/manage-table/
keywords: "Tabelle, Tabelle erstellen, auf Tabelle zugreifen, Seitenverhältnis der Tabelle, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Erstellen und verwalten Sie Tabellen in PowerPoint-Präsentationen"
---

Eine Tabelle in PowerPoint ist eine effiziente Möglichkeit, Informationen darzustellen und darzubieten. Die Informationen in einem Gitter von Zellen (angeordnet in Zeilen und Spalten) sind klar und leicht verständlich.

Aspose.Slides bietet die [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) Klasse, das [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Interface, die [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) Klasse, das [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) Interface und andere Typen, um Ihnen zu ermöglichen, Tabellen in allen Arten von Präsentationen zu erstellen, zu aktualisieren und zu verwalten.

## **Tabelle von Grund auf erstellen**

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index. 
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt zur Folie über die [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) Methode hinzu.
6. Iterieren Sie durch jede [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/), um das Formatieren der oberen, unteren, rechten und linken Ränder anzuwenden.
7. Führen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen. 
8. Greifen Sie auf das [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
9. Fügen Sie etwas Text zum [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) hinzu.
10. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Tabelle in einer Präsentation erstellen:

```php
  # Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Fügt eine Tabellenform zur Folie hinzu
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Setzt das Randformat für jede Zelle
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # Führt die Zellen 1 & 2 der Zeile 1 zusammen
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Fügt etwas Text in die zusammengeführte Zelle ein
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Zusammengeführte Zellen");
    # Speichert die Präsentation auf der Festplatte
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nummerierung in Standardtabelle**

In einer Standardtabelle ist die Nummerierung der Zellen unkompliziert und nullbasiert. Die erste Zelle in einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0). 

Zum Beispiel sind die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen so nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser PHP-Code zeigt Ihnen, wie Sie die Nummerierung für Zellen in einer Tabelle angeben:

```php
  # Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Fügt eine Tabellenform zur Folie hinzu
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Setzt das Randformat für jede Zelle
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Speichert die Präsentation auf der Festplatte
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Auf vorhandene Tabelle zugreifen**

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.

2. Holen Sie sich eine Referenz auf die Folie mit der Tabelle über ihren Index. 

3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt und setzen Sie es auf null.

4. Iterieren Sie durch alle [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) Objekte, bis die Tabelle gefunden ist.

   Wenn Sie vermuten, dass die Folie, mit der Sie es zu tun haben, eine einzelne Tabelle enthält, können Sie einfach alle Formen überprüfen, die sie enthält. Wenn eine Form als Tabelle identifiziert wird, können Sie sie in ein [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) Objekt umwandeln. Wenn die Folie, mit der Sie es zu tun haben, mehrere Tabellen enthält, ist es besser, nach der Tabelle zu suchen, die Sie benötigen, über deren [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel haben wir eine neue Zeile zur Tabelle hinzugefügt.

6. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie auf eine vorhandene Tabelle zugreifen und damit arbeiten:

```php
  # Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Initialisiert null TableEx
    $tbl = null;
    # Iteriert durch die Formen und setzt eine Referenz auf die gefundene Tabelle
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Setzt den Text für die erste Spalte der zweiten Zeile
        $tbl->get_Item(0, 1)->getTextFrame()->setText("Neu");
      }
    }
    # Speichert die modifizierte Präsentation auf der Festplatte
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Text in Tabelle ausrichten**

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index. 
3. Fügen Sie ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt zur Folie hinzu.
4. Greifen Sie auf ein [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) Objekt aus der Tabelle zu.
5. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/).
6. Richten Sie den Text vertikal aus.
7. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie den Text in einer Tabelle ausrichten:

```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Fügt die Tabellenform zur Folie hinzu
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Greift auf das Textfeld zu
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Erstellt das Paragraph-Objekt für das Textfeld
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Erstellt das Portion-Objekt für das Paragraph
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text hier");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Richten Sie den Text vertikal aus
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Speichert die Präsentation auf der Festplatte
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Textformatierung auf Tabellenebene festlegen**

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index. 
3. Greifen Sie auf ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) Objekt von der Folie zu.
4. Setzen Sie die [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) für den Text.
5. Setzen Sie die [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setzen Sie die [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie Ihre bevorzugten Formatierungsoptionen auf den Text in einer Tabelle anwenden:

```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation("simpletable.pptx");
  try {
    # Nehmen wir an, dass die erste Form auf der ersten Folie eine Tabelle ist
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Setzt die Schriftgröße der Tabellenzellen
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Setzt die Textausrichtung und rechten Rand der Tabellenzellen in einem Aufruf
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Setzt den vertikalen Typ des Textes der Tabellenzellen
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tabellenstil-Attribute abrufen**

Aspose.Slides ermöglicht Ihnen, die Stilattribute für eine Tabelle abzurufen, sodass Sie diese Details für eine andere Tabelle oder woanders verwenden können. Dieser PHP-Code zeigt Ihnen, wie Sie die Stilattribute aus einem vordefinierten Tabellenstil abrufen:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// Ändert das standardmäßige Stilvorgabenthema

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Seitenverhältnis der Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Größen in verschiedenen Dimensionen. Aspose.Slides bietet die [**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) Eigenschaft, die es Ihnen ermöglicht, das Seitenverhältnis für Tabellen und andere Formen zu sperren.

Dieser PHP-Code zeigt Ihnen, wie Sie das Seitenverhältnis für eine Tabelle sperren:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Seitenverhältnis gesperrt: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// umkehren

    echo("Seitenverhältnis gesperrt: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```