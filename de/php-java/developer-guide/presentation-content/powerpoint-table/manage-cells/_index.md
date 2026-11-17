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
description: "Verwalten Sie PowerPoint-Tabellenzellen in PHP: Erkennen Sie zusammengeführte Zellen, entfernen Sie Ränder, teilen Sie Zellen und setzen Sie Hintergrundfarben und Bilder mit Aspose.Slides für PHP via Java."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint‑Präsentationen und deren Änderung. In diesem Artikel wird erklärt, wie zusammengeführte Tabellenzellen erkannt, Zellränder entfernt, die Zellen‑nummerierung nach dem Zusammenführen oder Aufteilen von Zellen verarbeitet, die Hintergrundfarbe einer Zelle geändert und ein Bild in einer Tabellenzelle eingefügt wird. Die Beispiele zeigen, wie eine Präsentation erstellt oder geöffnet, eine Tabelle aus einer Folie abgerufen, die Zellenformatierung über Zellen‑eigenschaften aktualisiert und die geänderte Präsentation als PPTX‑Datei gespeichert wird.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(column, row)` zu adressieren.

## **Zusammengeführte Tabellenzelle identifizieren**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird davon ausgegangen, dass die Folie und die Form existieren und dass die Form eine Tabelle ist. Anschließend wird über alle Zeilen und Spalten iteriert und [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) verwendet, um Zellen in zusammengeführten Bereichen zu identifizieren. Für jeden Treffer werden die Zellkoordinaten in der Reihenfolge `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), und die Startkoordinaten des Bereichs, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) und [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/), ausgegeben.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Tabellenzellenränder entfernen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und fügen Sie mit [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) eine Tabelle auf der ersten Folie hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellenposition werden in Punkt angegeben. Das Beispiel setzt alle vier Zellränder auf [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), wodurch sie unsichtbar werden.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Diagonale Zellränder hinzufügen**

Verwenden Sie [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/), um eine Linie von der oberen linken Ecke zur unteren rechten zu zeichnen, und [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/), um eine Linie von der unteren linken Ecke zur oberen rechten zu zeichnen. Eine Diagonale kann einen Eckkopf markieren; beide Diagonalen können ein X bilden, um eine Zelle als nicht anwendbar zu kennzeichnen.

Jede Diagonale hat ihr eigenes [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/). In dessen [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/), verwenden Sie [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/), um [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) auszuwählen und über [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) eine Farbe zu wählen. Die Linienbreite wird in Punkten mit [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) festgelegt.

Das Beispiel erstellt drei Zellen in einer Zeile: eine rote nach unten gerichtete Diagonale, eine blaue nach oben gerichtete Diagonale und beide Diagonalen. Die oberen, unteren, linken und rechten Zellränder bleiben unverändert.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Eine Diagonale ändert nur die Zellformatierung. Jede Zelle behält einen einzelnen Textrahmen, auf den über [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) zugegriffen wird. Die Bereiche auf beiden Seiten einer Diagonalen können nicht unabhängig bearbeitet werden.

The saved table, rendered in Microsoft PowerPoint:

![Drei Tabellenzellen mit einer roten Diagonale von oben links nach unten rechts, einer blauen Diagonale von unten links nach oben rechts und beiden Diagonalen, die ein X bilden.](diagonal-cell-borders.png)

*Von links nach rechts: nach unten gerichtete Diagonale (rot, 3 pt), nach oben gerichtete Diagonale (blau, 5 pt) und beide Diagonalen.*

## **Tabellenzellen zusammenführen**

Verwenden Sie [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/), um einen rechteckigen Zellbereich einer Tabelle zu einer einzigen Zelle zu kombinieren. Geben Sie die Zellen in der oberen linken bzw. unteren rechten Ecke des Bereichs an. Das letzte Argument bestimmt, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `false` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4‑by‑4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt dann die vier mittleren Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Tabellenraster vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie deren obere linke Position: `$table->get_Item(1, 1)` in diesem Beispiel. Die übrigen Positionen im zusammengeführten Bereich bleiben Teil des Tabellenrasters, sodass sich die Indizes der Zellen außerhalb des Bereichs nicht ändern.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tabellenzellen teilen**

Das Zusammenführen von Zellen im vorherigen Beispiel erhält das Raster der Tabelle. Das Teilen einer Zelle kann eine neue Rasterspalte einführen und die Spaltenindizes der Zellen rechts davon ändern. Aspose.Slides folgt dem Tabellenrastermodell von PowerPoint.

Dieses Beispiel erstellt eine 4‑by‑4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird übergeben, um zwei gleich breite Zellen zu erzeugen.

Nach diesem Teilvorgang werden die beiden Hälften über `$table->get_Item(1, 1)` und `$table->get_Item(2, 1)` angesprochen. Das Tabellenraster besitzt nun fünf Spalten: Zellen, die ursprünglich in Spalten 2 und 3 waren, verschieben sich zu Spalten 3 bzw. 4. Die Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Teilvorgang auf Zellen zugreifen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


<!-- visual-explanation:manage-cells:start -->
[![Eine nicht zusammengeführte 70‑Punkt‑Zelle wird in zwei 35‑Punkt‑Zellen aufgeteilt, wodurch eine fünfte Rasterspalte entsteht und die Indizes rechts davon verschoben werden.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Die Breitenaufteilung betrifft die Zelle (1, 1) und verwendet nullbasierte (column, row)-Indizes. Andere Zeilen behalten eine Zelle, die beide neuen Spaltenpositionen umfasst.*
<!-- visual-explanation:manage-cells:end -->

### **Zusammengeführte Zellen nach Zeilen‑ oder Spalten‑Span teilen**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) zum Aufteilen entlang einer vorhandenen Zeilengrenze oder [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) zum Aufteilen entlang einer Spaltengrenze.

`index`‑Argument zählt Zeilen im oberen Teil oder Spalten im linken Teil der Aufteilung; es ist relativ zum zusammengeführten Bereich:

- Zeilenaufteilung: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Spaltenaufteilung: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Das Beispiel geht davon aus, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) und [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/), um den Ursprung zu ermitteln, und prüft beide Spannen. `splitByRowSpan(1)` trennt dann die Zeilen 2 und 3 für Produktnamen. Für eine horizontale Zusammenführung über zwei Spalten verwenden Sie stattdessen `splitByColSpan(1)`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // Die resultierenden Zellen aus der Tabelle nach dem Aufteilen abrufen.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Das Tabellenraster und die umliegenden Zellindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; hier haben beide eine Span von 1 und [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) gibt `false` aus. Größere Bereiche können nach einem Aufteilen teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung bleiben in der oberen (oder linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Ränder und Ränder. Befüllen Sie die Zellen nach dem Aufteilen und setzen Sie erforderliche Textformatierungen explizit.

Die gespeicherte Präsentation enthält separate „Product A“‑ und „Product B“‑Zellen, wobei die Zellformatierung der Vorlage erhalten bleibt. Siehe die [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) für Details.

### **Eine Zelle an einer bestimmten Höhe teilen**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) nimmt die Höhe des oberen Teils in Punkten. [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) nimmt die Anzahl der vorhandenen Rasterzeilen im oberen Teil. Um eine 40‑Punkt‑Zelle in der rechten Spalte zu zentrieren, ziehen Sie 40 von der tatsächlichen Höhe der Zelle ab und teilen den verbleibenden Raum gleichmäßig ober- und unterhalb davon.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Der erste Aufteilvorgang fügt eine Rasterzeile hinzu und lässt die unteren 90 Punkte in Zelle `(1, 1)` verbleiben. Der zweite Aufteilvorgang teilt diese Zelle in eine mittlere Zelle von 40 Punkten und eine untere Zelle von 50 Punkten. Die rechte Spalte hat nun drei Zellen mit Höhen von 50, 40 bzw. 50 Punkten von oben nach unten. Die linke Zelle erstreckt sich über alle drei Zeilen und behält ihre ursprüngliche Höhe von 140 Punkten bei.

![Die linke Zelle erstreckt sich über die gesamte Tabellenhöhe neben drei Zellen, wobei die mittlere Zelle in der Mitte steht.](split-by-height.png)

## **Hintergrundfarbe der Tabellenzelle ändern**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es verwendet [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/), um eine einfarbige Füllung auszuwählen, und setzt die über [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) zurückgegebene Farbe für Zelle `(2, 3)` (dritte Spalte, vierte Zeile) auf Rot.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bild in einer Tabellenzelle hinzufügen**

Legen Sie das Eingabebild vor dem Ausführen dieses Beispiels im Arbeitsverzeichnis ab. Es lädt das Bild mit [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) und fügt es der Bildsammlung der Präsentation mit [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) hinzu. Anschließend wird das Bild der Bildfüllung der Zelle `(0, 0)`, der ersten Zelle in der Tabelle, zugewiesen.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) streckt das Bild, um die Zelle zu füllen, was das Seitenverhältnis verändern kann. Spaltenbreiten und Zeilenhöhen werden in Punkten angegeben. Das geladene Bild wird in einem `finally`‑Block nach dem Hinzufügen zur Präsentation freigegeben.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Kann ich unterschiedliche Linienstärken und -stile für verschiedene Seiten einer einzelnen Zelle festlegen?**

Ja. Die [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/)‑Ränder besitzen separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich nach dem Festlegen eines Bildes als Zellhintergrund die Spalten‑/Zeilengröße ändere?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken passt sich das Bild an die neue Zelle an; beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem ganzen Zelleninhalt einen Hyperlink zuweisen?**

[Hyperlinks](/slides/de/php-java/manage-hyperlinks/) werden auf Textebene (Portion) im Textrahmen der Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich unterschiedliche Schriftarten innerhalb einer einzelnen Zelle festlegen?**

Ja. Der Textrahmen einer Zelle unterstützt [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/), also Textabschnitte, mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.