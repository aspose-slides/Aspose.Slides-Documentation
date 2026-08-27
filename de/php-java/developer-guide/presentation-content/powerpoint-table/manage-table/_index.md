---
title: Verwalten von Präsentationstabellen in PHP
linktitle: Tabelle verwalten
type: docs
weight: 10
url: /de/php-java/manage-table/
keywords:
- Tabelle hinzufügen
- Tabelle erstellen
- Zugriff auf Tabelle
- Seitenverhältnis
- Text ausrichten
- Textformatierung
- Tabellenstil
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Tabellen in PowerPoint‑Folien mit Aspose.Slides für PHP über Java erstellen und bearbeiten. Entdecken Sie einfache Code‑Beispiele, um Ihre Tabellenerstellung zu optimieren."
---
## **Einführung**

Eine Tabelle in PowerPoint ist ein effizientes Mittel, um Informationen darzustellen und zu vermitteln. Die Angaben in einem Raster aus Zellen (angeordnet in Zeilen und Spalten) sind übersichtlich und leicht zu verstehen.

Aspose.Slides stellt die Klasse [Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/Table), die Klasse [Cell](https://reference.aspose.com/slides/de/php-java/aspose.slides/cell/) und weitere Typen zur Verfügung, mit denen Sie Tabellen in beliebigen Präsentationen erstellen, aktualisieren und verwalten können.

## **Erstellen einer Tabelle von Grund auf**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation).
2. Holen Sie sich den Verweis auf eine Folie über ihren Index. 
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie über die Methode [addTable](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addtable/) ein [Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/table/)‑Objekt zur Folie hinzu.
6. Durchlaufen Sie jede [Cell](https://reference.aspose.com/slides/de/php-java/aspose.slides/cell/), um die oberen, unteren, rechten und linken Rahmen zu formatieren.
7. Fügen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen. 
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) einer [Cell](https://reference.aspose.com/slides/de/php-java/aspose.slides/cell/) zu.
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) Text hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie Sie in einer Präsentation eine Tabelle erstellen:

```php
  # Instanziiert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Fügt der Folie ein Tabellenelement hinzu
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Setzt das Rahmenformat für jede Zelle
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
    # Fügt die Zellen 1 und 2 der Zeile 1 zusammen
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Fügt dem zusammengefügten Feld etwas Text hinzu
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Speichert die Präsentation auf die Festplatte
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nummerierung in einer Standardtabelle**

In einer Standardtabelle ist die Numerierung der Zellen einfach und nullbasiert. Die erste Zelle einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0). 

Beispielsweise werden die Zellen einer Tabelle mit 4 Spalten und 4 Zeilen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser PHP‑Code zeigt, wie Sie die Nummerierung von Zellen in einer Tabelle festlegen:

```php
  # Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Fügt der Folie ein Tabellenelement hinzu
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Setzt das Rahmenformat für jede Zelle
    $rows = $tbl->getRows();
    foreach($rows as $row) {
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
    # Speichert die Präsentation auf die Festplatte
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zugriff auf eine bestehende Tabelle**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation).

2. Holen Sie sich über den Index den Verweis auf die Folie, die die Tabelle enthält. 

3. Erzeugen Sie ein [Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/Table)-Objekt und setzen Sie es auf `null`.

4. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/)-Objekte, bis die Tabelle gefunden ist.

   Wenn Sie vermuten, dass die betreffende Folie nur eine Tabelle enthält, können Sie einfach alle enthaltenen Formen prüfen. Wird eine Form als Tabelle identifiziert, können Sie sie in ein [Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/Table)-Objekt casten. Enthält die Folie jedoch mehrere Tabellen, ist es besser, die gesuchte Tabelle über ihren [setAlternativeText(String value)](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/setalternativetext/) zu finden.

5. Verwenden Sie das [Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/Table)-Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel fügen wir der Tabelle eine neue Zeile hinzu.

6. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie Sie auf eine vorhandene Tabelle zugreifen und mit ihr arbeiten:

```php
  # Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Initialisiert null TableEx
    $tbl = null;
    # Durchläuft die Shapes und setzt einen Verweis auf die gefundene Tabelle
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Setzt den Text für die erste Spalte der zweiten Zeile
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Speichert die geänderte Präsentation auf die Festplatte
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ermitteln der Zelle, zu der ein Textfeld gehört**

Wenn generischer Textverarbeitungscode ein [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) aus einer Tabelle erhält, verwenden Sie die Methode [TextFrame::getParentCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentCell), um die zugehörige [Cell](https://reference.aspose.com/slides/de/php-java/aspose.slides/cell/) zu erhalten. Für ein Tabellen‑Zellen‑Textfeld liefert [TextFrame::getParentCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentCell) den Eigentümer und [TextFrame::getParentShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentShape) gibt `null` zurück, obwohl die Tabelle selbst eine Form ist.

Die Zellkoordinaten stehen über die schreibgeschützten Methoden [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/de/php-java/aspose.slides/cell/#getFirstColumnIndex) und [Cell::getFirstRowIndex](https://reference.aspose.com/slides/de/php-java/aspose.slides/cell/#getFirstRowIndex) zur Verfügung. [TextFrame::getParentCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentCell) bietet zudem eine schreibgeschützte Navigation: Sie gibt den Eigentümer zurück, ändert aber nichts an der Besitzverhältnisses. Überprüfen Sie immer die zurückgegebene Zelle mit `java_is_null`, bevor Sie sie verwenden.

Ein vollständiges Beispiel, das Tabellen‑Zellen‑ und Form‑Eigentümer ermittelt, einschließlich Formen, die mit SmartArt‑Knoten verbunden sind, finden Sie unter [Search and Replace Text](/slides/de/php-java/search-and-replace-text/).

## **Text in einer Tabelle ausrichten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation).
2. Holen Sie sich den Verweis auf eine Folie über ihren Index. 
3. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/Table)-Objekt hinzu.
4. Greifen Sie von der Tabelle aus auf ein [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/)-Objekt zu.
5. Greifen Sie auf das [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/)-Objekt zu.
6. Richten Sie den Text vertikal aus.
7. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie Sie den Text in einer Tabelle ausrichten:

```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Fügt das Tabellenelement zur Folie hinzu
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Greift auf den Textrahmen zu
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Erstellt das Paragraph-Objekt für den Textrahmen
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Erstellt das Portion-Objekt für den Paragraphen
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Richtet den Text vertikal aus
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Speichert die Präsentation auf die Festplatte
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Textformatierung auf Tabellenebene festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation).
2. Holen Sie sich den Verweis auf eine Folie über ihren Index. 
3. Greifen Sie von der Folie aus auf ein [Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/Table)-Objekt zu.
4. Setzen Sie die Schriftgröße mit [setFontHeight(float value)](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setFontHeight).
5. Setzen Sie die Ausrichtung mit [setAlignment(int value)](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setalignment/) und den rechten Rand mit [setMarginRight(float value)](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Setzen Sie den vertikalen Texttyp mit [setTextVerticalType(byte value)](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Speichern Sie die geänderte Präsentation. 

Dieser PHP‑Code zeigt, wie Sie Ihre gewünschten Formatierungsoptionen auf den Text in einer Tabelle anwenden:

```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation("simpletable.pptx");
  try {
    # Angenommen, die erste Form auf der ersten Folie ist eine Tabelle
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Setzt die Schriftgröße der Tabellenzellen
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Setzt die Textausrichtung und den rechten Rand der Tabellenzellen in einem Aufruf
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Setzt den vertikalen Texttyp der Tabellenzellen
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

## **Tabellen‑Stil‑Eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen der Stil‑Eigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser PHP‑Code zeigt, wie Sie die Stil‑Eigenschaften aus einem vordefinierten Tabellendesign erhalten:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// ändert das Standard-Style-Preset-Thema

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Abmessungen in verschiedenen Dimensionen. Aspose.Slides stellt die Methode [setAspectRatioLocked](https://reference.aspose.com/slides/de/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) bereit, um das Seitenverhältnis für Tabellen und andere Formen zu sperren.

Dieser PHP‑Code zeigt, wie Sie das Seitenverhältnis einer Tabelle sperren:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invertieren

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kann ich die Schreibrichtung von rechts nach links (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Methode [setRightToLeft](https://reference.aspose.com/slides/de/php-java/aspose.slides/table/setrighttoleft/) bereit, und Absätze haben [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setrighttoleft/). Die Kombination sorgt für die korrekte RTL‑Reihenfolge und Darstellung innerhalb der Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der finalen Datei verschieben oder ihre Größe ändern?**

Verwenden Sie Form‑Sperren, um Verschieben, Größenänderung, Auswahl usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/) festlegen; das Bild bedeckt dann den Zellenbereich gemäß dem gewählten Modus (Strecken oder Kacheln).