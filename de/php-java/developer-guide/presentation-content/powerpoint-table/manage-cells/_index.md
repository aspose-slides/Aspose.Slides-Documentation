---
title: Verwalten von Tabellenzellen in Präsentationen mit PHP
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/php-java/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rand entfernen
- Zelle aufteilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten von PowerPoint-Tabellenzellen in PHP: zusammengeführte Zellen identifizieren, Rahmen entfernen, Zellen aufteilen und Hintergrundfarben sowie Bilder mit Aspose.Slides für PHP via Java festlegen."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint‑Präsentationen und deren Modification. Dieser Artikel erklärt, wie zusammengeführte Tabellenzellen identifiziert, Zellrahmen entfernt, die Zellnummerierung nach dem Zusammenführen oder Aufteilen von Zellen behandelt, die Hintergrundfarbe einer Zelle geändert und ein Bild in einer Tabellenzelle hinzugefügt wird. Die Beispiele zeigen, wie eine Präsentation erstellt oder geöffnet, eine Tabelle von einer Folie abgerufen, die Zellenformatierung über Zellen‑Eigenschaften aktualisiert und die geänderte Präsentation als PPTX‑Datei gespeichert wird.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(column, row)` zuzugreifen.

## **Identifizieren einer zusammengeführten Tabellenzelle**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form der ersten Folie als Tabelle zu. Es wird davon ausgegangen, dass die Folie und die Form existieren und dass die Form eine Tabelle ist. Anschließend wird über alle Zeilen und Spalten iteriert und [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) verwendet, um Zellen in zusammengeführten Bereichen zu identifizieren. Für jede Übereinstimmung werden die Zellkoordinaten in der Reihenfolge `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/) sowie die Startkoordinaten des Bereichs, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) und [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/), ausgegeben.

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

## **Tabellenzellenrahmen entfernen**

Erstellen Sie ein [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und fügen Sie seiner ersten Folie mit [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) eine Tabelle hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellenposition werden in Punkten angegeben. Das Beispiel setzt alle vier Zellrahmen auf [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), sodass sie unsichtbar werden.

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

## **Tabellenzellen zusammenführen**

Verwenden Sie [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/), um einen rechteckigen Zellbereich zu einer einzelnen Zelle zu kombinieren. Geben Sie die Zellen in der oberen linken und der unteren rechten Ecke des Bereichs an. Das letzte Argument steuert, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `false` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt dann die vier mittleren Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrundeliegende Raster der Tabelle vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie ihre Position in der oberen linken Ecke: `$table->get_Item(1, 1)` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellenrasters, sodass die Indizes von Zellen außerhalb des Bereichs unverändert bleiben.

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

## **Tabellenzellen aufteilen**

Das Zusammenführen von Zellen im vorigen Beispiel erhält das Tabellengitter. Das Aufteilen einer Zelle kann eine neue Spalte im Raster erzeugen und die Spaltenindizes der Zellen rechts davon ändern. Aspose.Slides folgt dem Tabellenrastermodell von PowerPoint.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird übergeben, um zwei gleich breite Zellen zu erzeugen.

Nach diesem Aufteilen werden die beiden Hälften über `$table->get_Item(1, 1)` und `$table->get_Item(2, 1)` angesprochen. Das Tabellenraster hat nun fünf Spalten: Zellen, die ursprünglich in Spalte 2 und 3 waren, verschieben sich zu Spalte 3 bzw. 4. Die Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes beim Zugriff auf Zellen nach dem Aufteilen.

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

### **Zusammengeführte Zellen nach Zeilen‑ oder Spaltenumfang aufteilen**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/), um entlang einer bestehenden Zeilen­grenze zu teilen, oder [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/), um entlang einer Spalten­grenze zu teilen.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil des Aufteilens; es bezieht sich relativ auf den zusammengeführten Bereich:

- Zeilenaufteilung: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Spaltenaufteilung: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Das Beispiel erwartet, dass eine Präsentation auf der ersten Folie als erste Form eine Tabelle hat, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend vom unteren Teil verwendet es [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) und [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/), um den Ursprung zu bestimmen, und prüft beide Umfänge. `splitByRowSpan(1)` trennt dann die Zeilen 2 und 3 für Produktnamen. Für eine horizontale Zusammenführung über zwei Spalten verwenden Sie stattdessen `splitByColSpan(1)`.

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

Das Tabellengitter und die umliegenden Zellenindizes bleiben unverändert. Die resultierenden Zellen werden über ihre Koordinaten abgerufen; hier haben beide einen Umfang von 1 und [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) liefert `false`. Größere Bereiche können nach einem Aufteilen teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung bleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Rahmen und Ränder. Befüllen Sie die Zellen nach dem Aufteilen und setzen Sie ggf. die gewünschte Textformatierung explizit.

Die gespeicherte Präsentation enthält separate Zellen „Product A“ und „Product B“ mit dem beibehaltenen Zellformat der Vorlage. Siehe die [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) für Details.

## **Hintergrundfarbe der Tabellenzelle ändern**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es verwendet [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/), um eine Vollfüllung auszuwählen, und setzt die von [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) zurückgegebene Farbe für Zelle `(2, 3)` (dritte Spalte, vierte Zeile) auf Rot.

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

## **Ein Bild in einer Tabellenzelle einfügen**

Platzieren Sie das Eingabebild im Arbeitsverzeichnis, bevor Sie dieses Beispiel ausführen. Es lädt das Bild mit [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) und fügt es der Bildsammlung der Präsentation mit [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) hinzu. Anschließend wird das Bild dem Bildfüllmodus der Zelle `(0, 0)` (erste Zelle der Tabelle) zugewiesen.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) streckt das Bild, sodass die Zelle vollständig ausgefüllt wird, was das Seitenverhältnis ändern kann. Spaltenbreiten und Zeilenhöhen werden in Punkten angegeben. Das geladene Bild wird in einem `finally`‑Block verworfen, nachdem es zur Präsentation hinzugefügt wurde.

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

Ja. Die [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/)‑Rahmen besitzen separate Eigenschaften, sodass die Stärke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilengröße ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken passt sich das Bild der neuen Zelle an; beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem Hyperlink den gesamten Inhalt einer Zelle zuweisen?**

[Hyperlinks](/slides/de/php-java/manage-hyperlinks/) werden auf Text‑ (Part‑) Ebene innerhalb des Textframes der Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. In der Praxis weisen Sie den Link einem Textteil oder dem gesamten Text in der Zelle zu.

**Kann ich innerhalb einer einzelnen Zelle unterschiedliche Schriftarten festlegen?**

Ja. Der Textframe einer Zelle unterstützt [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (Runs) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.