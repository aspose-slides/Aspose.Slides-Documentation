---
title: Präsentationstabellen in PHP verwalten
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
description: "Tabellen in PowerPoint‑Folien mit Aspose.Slides für PHP über Java erstellen & bearbeiten. Entdecken Sie einfache Codebeispiele, um Ihre Tabellen‑Workflows zu optimieren."
---
## **Einleitung**

Tabellen in PowerPoint organisieren Informationen in Zeilen und Spalten, wodurch das Lesen und Vergleichen von Werten erleichtert wird.

Aspose.Slides stellt die Klasse [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) , die Klasse [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) und weitere Typen zur Verfügung, mit denen Sie Tabellen in Präsentationen erstellen, aktualisieren und verwalten können.

## **Erstellen einer Tabelle von Grund auf**

Erstellen Sie eine Tabelle, indem Sie ihre Position, Spaltenbreiten und Zeilenhöhen angeben. Nachdem Sie sie zu einer Folie hinzugefügt haben, können Sie Zellenränder formatieren, Zellen zusammenführen und Text einfügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf die Folie über ihren Index.
3. Definieren Sie ein Array von Spaltenbreiten in Punkten.
4. Definieren Sie ein Array von Zeilenhöhen in Punkten.
5. Fügen Sie dem Folie ein [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/)-Objekt über die Methode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) hinzu.
6. Iterieren Sie über jedes [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/), um Formatierungen für die oberen, unteren, rechten und linken Ränder anzuwenden.
7. Führen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.
8. Greifen Sie über die Methode [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) auf die zusammengeführte Zelle zu.
9. Setzen Sie den Text in der zusammengeführten Zelle.
10. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel erstellt eine Tabelle mit drei Spalten und fünf Zeilen bei (100, 50) Punkten. Es wendet rote Ränder mit einer Breite von 5 Punkten an, führt die ersten beiden Zellen der ersten Zeile zusammen und speichert das Ergebnis als `table.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nummerierung in einer Standardtabelle**

In einer Standardtabelle sind Zellenindizes nullbasiert und verwenden die Reihenfolge (Spalte, Zeile). Die erste Zelle hat den Index (0, 0).

Beispielsweise werden die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen folgendermaßen nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieses Beispiel erstellt die oben dargestellte 4 × 4‑Tabelle mit Spaltenbreiten und Zeilenhöhen von 70 Punkten sowie roten Zellenrändern von 5 Punkten. Die Koordinaten veranschaulichen die Zellenindizes; das Beispiel lässt die Zellen leer und speichert die Tabelle als `StandardTables_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zugriff auf eine vorhandene Tabelle**

Tabellen werden in der Formensammlung einer Folie gespeichert. Durchlaufen Sie die Formen, um eine Tabelle zu finden, und verwenden Sie dann die Klasse [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/), um deren Zellen zu lesen oder zu aktualisieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf die Folie, die die Tabelle enthält, über ihren Index.
3. Durchlaufen Sie die Objekte vom Typ [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) und stoppen Sie, wenn eine Tabelle gefunden wird. Enthält die Folie mehrere Tabellen, verwenden Sie [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/), um die gewünschte zu identifizieren.
4. Aktualisieren Sie den Text in der Zielzelle.
5. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel öffnet `UpdateExistingTable.pptx` und findet die erste Tabelle auf der ersten Folie. Es setzt die Zelle in Spalte 0, Zeile 1 auf `New` und speichert das Ergebnis als `table1_out.pptx`. Die Eingabedatei muss mindestens eine Folie enthalten, und die erste Tabelle auf dieser Folie muss mindestens eine Spalte und zwei Zeilen haben.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Um eine Zeile in einer vorhandenen Tabelle zu ändern und zu verstehen, warum ihre tatsächliche Höhe das angeforderte Minimum überschreiten kann, siehe [Zeilenhöhe steuern](/slides/de/php-java/manage-rows-and-columns/#control-row-height).

## **Finden der Zelle, die einen Textrahmen besitzt**

Wenn generischer Textverarbeitungs‑Code ein [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) von einer Tabelle erhält, verwenden Sie die Methode [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell), um die zugehörige [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) abzurufen. Für einen Tabellenzellen‑TextFrame gibt [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) den Eigentümer zurück und [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) gibt `null` zurück, obwohl die Tabelle selbst eine Form ist.

Die Zellkoordinaten sind über die schreibgeschützten Methoden [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) und [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) verfügbar. [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) bietet ebenfalls schreibgeschützte Navigation: Sie gibt den Eigentümer zurück, ändert jedoch das Eigentum nicht. Prüfen Sie stets die zurückgegebene Zelle mit `java_is_null`, bevor Sie sie verwenden.

Ein vollständiges Beispiel, das Tabellenzellen‑ und Form‑Eigentümer identifiziert, einschließlich Formen, die mit SmartArt‑Knoten verknüpft sind, finden Sie unter [Suchen und Ersetzen von Text](/slides/de/php-java/search-and-replace-text/).

## **Text in einer Tabelle ausrichten**

Sie können die vertikale Verankerung und Textausrichtung einzelner Tabellenzellen steuern. Das Beispiel in diesem Abschnitt zentriert den Text in der ersten Zelle und dreht ihn um 270 Grad.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf die Folie über ihren Index.
3. Fügen Sie ein [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/)-Objekt zur Folie hinzu.
4. Greifen Sie auf ein [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)-Objekt der Tabelle zu.
5. Greifen Sie auf den ersten [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) zu und setzen Sie dessen Text und Farbe.
6. Setzen Sie die vertikale Verankerung und Textausrichtung der Zelle mithilfe von [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) und [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) .
7. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit Spaltenbreiten von 120 Punkten und Zeilenhöhen von 100 Punkten. Es formatiert den Text in Zelle (0, 0), fügt den restlichen Zellen der ersten Zeile Werte hinzu und speichert das Ergebnis als `Vertical_Align_Text_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Textformatierung auf Tabellenebene festlegen**

Verwenden Sie [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) , um die Textformatierung auf alle Zellen einer Tabelle anzuwenden. Sein Überladungen akzeptieren Formatierungen für Abschnitte, Absätze und Textframes, sodass Sie diese Eigenschaften festlegen können, ohne einzelne Zellen zu iterieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf die Folie über ihren Index.
3. Greifen Sie auf ein [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/)-Objekt der Folie zu.
4. Setzen Sie die Schriftgröße mit [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) für den Text.
5. Setzen Sie die Absatzausrichtung und den rechten Rand mit [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) und [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) .
6. Setzen Sie die Textausrichtung mit [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) .
7. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel öffnet `table.pptx`, das mindestens eine Folie mit einer Tabelle als erste Form enthalten muss. Es setzt die Schriftgröße auf 25 Punkte, richtet Absätze rechtsbündig mit einem rechten Rand von 20 Punkten aus und macht den Text vertikal. Die formatierte Präsentation wird als `result.pptx` gespeichert.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) , um den voreingestellten Stil einer Tabelle zu lesen, und [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) , um ihn zuzuweisen. Dieses Beispiel wendet [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) auf eine Tabelle an, gibt den voreingestellten Wert aus und weist denselben Stil einer zweiten Tabelle zu. Beide Tabellen werden in `table-style.pptx` gespeichert.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer Tabelle ist das Verhältnis ihrer Breite zu ihrer Höhe. Verwenden Sie [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) , um dieses Verhältnis für eine Tabelle zu sperren.

Das folgende Beispiel öffnet `pres.pptx`, das mindestens eine Folie mit einer Tabelle als erste Form enthalten muss. Es gibt den aktuellen Sperrzustand aus, aktiviert die Sperrung des Seitenverhältnisses, gibt den aktualisierten Zustand (`true`) aus und speichert das Ergebnis als `pres-out.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Kann ich die Leserichtung von rechts nach links (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle bietet die Methode [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) und Absätze besitzen [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). Die Verwendung beider stellt die korrekte RTL‑Reihenfolge und -Darstellung innerhalb der Zellen sicher.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder die Größe ändern?**

Verwenden Sie [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) , um das Verschieben, Ändern der Größe, Auswählen usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle einen [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) festlegen; das Bild deckt die Zellenfläche je nach gewähltem Modus (Dehnung oder Kachel) ab.