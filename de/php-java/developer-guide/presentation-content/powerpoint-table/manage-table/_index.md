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
description: "Erstellen und Bearbeiten von Tabellen in PowerPoint-Folien mit Aspose.Slides für PHP über Java. Entdecken Sie einfache Codebeispiele, um Ihre Tabellen-Workflows zu optimieren."
---

Eine Tabelle in PowerPoint ist ein effizienter Weg, Informationen darzustellen und zu visualisieren. Die Daten in einem Raster aus Zellen (angeordnet in Zeilen und Spalten) sind klar und leicht zu verstehen.

Aspose.Slides stellt die [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table)-Klasse, das [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)-Interface, die [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)-Klasse, das [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/)-Interface und weitere Typen bereit, mit denen Sie Tabellen in allen Arten von Präsentationen erstellen, aktualisieren und verwalten können.

## **Eine Tabelle von Grund auf erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.  
2. Holen Sie sich über den Index einen Verweis auf die Folie.  
3. Definieren Sie ein Array von `columnWidth`.  
4. Definieren Sie ein Array von `rowHeight`.  
5. Fügen Sie über die Methode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)-Objekt zur Folie hinzu.  
6. Durchlaufen Sie jede [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/), um die oberen, unteren, rechten und linken Rahmen zu formatieren.  
7. Fügen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.  
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)-Objekt einer [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/)-Zelle zu.  
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) Text hinzu.  
10. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie Sie eine Tabelle in einer Präsentation erstellen:
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
    # Sets the border format for each cell
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
    # Fügt dem zusammengeführten Zellbereich Text hinzu
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Speichert die Präsentation auf der Festplatte
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **Nummerierung in einer Standardtabelle**

In einer Standardtabelle erfolgt die Nummerierung der Zellen einfach und nullbasiert. Die erste Zelle einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0).

Beispielhaft werden die Zellen einer Tabelle mit 4 Spalten und 4 Zeilen folgendermaßen nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser PHP‑Code zeigt, wie Sie die Nummerierung für Zellen in einer Tabelle festlegen:
```php
  # Erstellt eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
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


## **Zugriff auf eine vorhandene Tabelle**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.  

2. Holen Sie sich über den Index einen Verweis auf die Folie, die die Tabelle enthält.  

3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)-Objekt und setzen Sie es auf null.  

4. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/)-Objekte, bis die Tabelle gefunden ist.  

   Wenn Sie vermuten, dass die betreffende Folie nur eine einzige Tabelle enthält, können Sie einfach alle ihre Shapes prüfen. Sobald ein Shape als Tabelle identifiziert ist, können Sie es per Cast in ein [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table)-Objekt umwandeln. Enthält die Folie jedoch mehrere Tabellen, ist es besser, die gewünschte Tabelle über ihr [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-) zu finden.  

5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)-Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel fügen wir der Tabelle eine neue Zeile hinzu.  

6. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie Sie auf eine vorhandene Tabelle zugreifen und mit ihr arbeiten:
```php
  # Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Initialisiert null TableEx
    $tbl = null;
    # Iteriert durch die Shapes und setzt eine Referenz auf die gefundene Tabelle
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Setzt den Text für die erste Spalte der zweiten Zeile
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Speichert die geänderte Präsentation auf der Festplatte
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Text in einer Tabelle ausrichten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.  
2. Holen Sie sich über den Index einen Verweis auf die Folie.  
3. Fügen Sie ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)-Objekt zur Folie hinzu.  
4. Greifen Sie von der Tabelle aus auf ein [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)-Objekt zu.  
5. Greifen Sie auf das [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/)-Objekt des [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) zu.  
6. Richten Sie den Text vertikal aus.  
7. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie Sie den Text in einer Tabelle ausrichten:
```php
  # Erzeugt eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Fügt das Tabellenelement zur Folie hinzu
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Greift auf das Textfeld zu
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Erstellt das Paragraph-Objekt für das Textfeld
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Erstellt das Portion-Objekt für den Absatz
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Richtet den Text vertikal aus
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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.  
2. Holen Sie sich über den Index einen Verweis auf die Folie.  
3. Greifen Sie von der Folie aus auf ein [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)-Objekt zu.  
4. Setzen Sie die [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) für den Text.  
5. Setzen Sie die [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) und [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Setzen Sie die [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie Sie Ihre bevorzugten Formatierungsoptionen auf den Text in einer Tabelle anwenden:
```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation("simpletable.pptx");
  try {
    # Angenommen, das erste Shape auf der ersten Folie ist eine Tabelle
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Setzt die Schrifthöhe der Tabellenzellen
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Setzt die Textausrichtung und den rechten Rand der Tabellenzellen in einem Aufruf
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Setzt die vertikale Textausrichtung der Tabellenzellen
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


## **Tabellenstil‑Eigenschaften abrufen**

Aspose.Slides ermöglicht es Ihnen, die Stil‑Eigenschaften einer Tabelle abzurufen, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser PHP‑Code zeigt, wie Sie die Stil‑Eigenschaften aus einem vordefinierten Tabellensstil erhalten:
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// ändert das Standard-Stil-Preset-Thema

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Abmessungen in verschiedenen Dimensionen. Aspose.Slides stellt die [**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-)‑Eigenschaft bereit, mit der Sie das Seitenverhältnis für Tabellen und andere Formen sperren können.

Dieser PHP‑Code zeigt, wie Sie das Seitenverhältnis für eine Tabelle sperren:
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

**Kann ich die Rechts‑zu‑Links‑Leserichtung (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Methode [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) zur Verfügung, und Absätze haben [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). Die Kombination sorgt für die korrekte RTL‑Reihenfolge und -Darstellung innerhalb der Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder die Größe ändern?**

Verwenden Sie [Shape‑Locks](/slides/de/php-java/applying-protection-to-presentation/), um das Verschieben, Ändern der Größe, Auswählen usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) festlegen; das Bild wird den Zellenbereich je nach gewähltem Modus (Strecken oder Kacheln) abdecken.