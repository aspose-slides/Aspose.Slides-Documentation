---
title: Tabellenzellen in Präsentationen mit PHP verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/php-java/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rand entfernen
- Zelle teilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie mühelos Tabellenzellen in PowerPoint mit Aspose.Slides für PHP. Beherrschen Sie das schnelle Zugreifen, Ändern und Stylen von Zellen für eine nahtlose Folienautomatisierung."
---

## **Identifizieren einer zusammengeführten Tabellenzelle**
1. Erstellen Sie eine Instanz der  [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie die Tabelle von der ersten Folie.
3. Iterieren Sie durch die Zeilen und Spalten der Tabelle, um zusammengeführte Zellen zu finden.
4. Geben Sie eine Meldung aus, wenn zusammengeführte Zellen gefunden werden.

Dieser PHP-Code zeigt, wie man zusammengeführte Tabellenzellen in einer Präsentation identifiziert:
```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// Annahme: Slide#0.Shape#0 ist eine Tabelle

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Tabellenzellenränder entfernen**
1. Erstellen Sie eine Instanz der  [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie der Folie über die Methode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) eine Tabelle hinzu.
6. Iterieren Sie über jede Zelle, um die oberen, unteren, rechten und linken Ränder zu entfernen.
7. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt, wie man die Ränder von Tabellenzellen entfernt:
```php
  # Instanziert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Fügt der Folie ein Tabellenshape hinzu
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Setzt das Randformat für jede Zelle
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Speichert die PPTX auf die Festplatte
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Nummerierung in zusammengeführten Zellen**
Wenn wir 2 Paare von Zellen (1, 1) x (2, 1) und (1, 2) x (2, 2) zusammenführen, wird die resultierende Tabelle nummeriert. Dieser PHP-Code demonstriert den Vorgang:
```php
  # Instanziert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Fügt der Folie ein Tabellenshape hinzu
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
    # Fügt Zellen (1, 1) x (2, 1) zusammen
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Fügt Zellen (1, 2) x (2, 2) zusammen
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Anschließend führen wir die Zellen weiter zusammen, indem wir (1, 1) und (1, 2) zusammenführen. Das Ergebnis ist eine Tabelle mit einer großen zusammengeführten Zelle in ihrer Mitte:
```php
  # Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Fügt der Folie ein Tabellenshape hinzu
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
    # Fügt Zellen (1, 1) x (2, 1) zusammen
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Fügt Zellen (1, 2) x (2, 2) zusammen
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Fügt Zellen (1, 1) x (1, 2) zusammen
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Nummerierung in einer geteilten Zelle**
In vorherigen Beispielen, wenn Tabellenzellen zusammengeführt wurden, änderte sich die Numerierung oder das Nummerierungssystem in anderen Zellen nicht.

Diesmal nehmen wir eine reguläre Tabelle (eine Tabelle ohne zusammengeführte Zellen) und versuchen, Zelle (1,1) zu teilen, um eine spezielle Tabelle zu erhalten. Sie sollten die Nummerierung dieser Tabelle beachten, die möglicherweise ungewöhnlich erscheint. Das ist jedoch die Art und Weise, wie Microsoft PowerPoint Tabellenzellen nummeriert, und Aspose.Slides tut dasselbe.

Dieser PHP-Code demonstriert den beschriebenen Vorgang:
```php
  # Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Fügt der Folie ein Tabellenshape hinzu
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
    # Fügt Zellen (1, 1) x (2, 1) zusammen
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Fügt Zellen (1, 2) x (2, 2) zusammen
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Teilt die Zelle (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Hintergrundfarbe der Tabellenzelle ändern**
Dieser PHP-Code zeigt, wie man die Hintergrundfarbe einer Tabellenzelle ändert:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # erstelle eine neue Tabelle
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # setze die Hintergrundfarbe für eine Zelle
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Bild in einer Tabellenzelle einfügen**
1. Erstellen Sie eine Instanz der  [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie der Folie über die Methode [AddTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) eine Tabelle hinzu.
6. Erstellen Sie ein `Images`-Objekt, um die Bilddatei zu halten.
7. Fügen Sie das `IImage`-Bild dem Objekt `IPPImage` hinzu.
8. Setzen Sie das `FillFormat` der Tabellenzelle auf `Picture`.
9. Fügen Sie das Bild der ersten Zelle der Tabelle hinzu.
10. Speichern Sie die modifizierte Präsentation als PPTX-Datei

Dieser PHP-Code zeigt, wie man ein Bild in einer Tabellenzelle platziert, wenn man eine Tabelle erstellt:
```php
  # Instanziert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $islide = $pres->getSlides()->get_Item(0);
    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Fügt der Folie ein Tabellenshape hinzu
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Erzeugt ein IPPImage-Objekt mithilfe der Bilddatei
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Fügt das Bild zur ersten Tabellenzelle hinzu
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Speichert die PPTX-Datei auf der Festplatte
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich unterschiedliche Linienstärken und -stile für die verschiedenen Seiten einer einzelnen Zelle festlegen?**

Ja. Die [oberen](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[unteren](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[linken](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[rechten](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) Ränder besitzen separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können. Dies folgt logisch aus der seitenspezifischen Randsteuerung für eine Zelle, die im Artikel demonstriert wird.

**Was passiert mit dem Bild, wenn ich die Spalten-/Zeilengröße ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [Füllmodus](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken passt sich das Bild der neuen Zelle an; beim Kacheln werden die Kacheln neu berechnet. Der Artikel erwähnt die Anzeige‑Modi von Bildern in einer Zelle.

**Kann ich einem Hyperlink den gesamten Inhalt einer Zelle zuweisen?**

[Hyperlinks](/slides/de/php-java/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textfelds der Zelle oder auf Ebene der gesamten Tabelle/Form festgelegt. In der Praxis weist man den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich unterschiedliche Schriftarten innerhalb einer einzelnen Zelle festlegen?**

Ja. Das Textfeld einer Zelle unterstützt [Portionen](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (Laufabschnitte) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.