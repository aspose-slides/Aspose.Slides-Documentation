---
title: "Verwalten von Zeilen und Spalten in PowerPoint-Tabellen mit PHP"
linktitle: "Zeilen und Spalten"
type: docs
weight: 20
url: /de/php-java/manage-rows-and-columns/
keywords:
- Tabellenzeile
- Tabellenspalte
- erste Zeile
- Tabellenkopf
- Zeile duplizieren
- Spalte duplizieren
- Zeile kopieren
- Spalte kopieren
- Zeile entfernen
- Spalte entfernen
- Zeilentextformatierung
- Spaltentextformatierung
- Tabellenstil
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für PHP via Java und beschleunigen Sie die Bearbeitung von Präsentationen und Datenaktualisierungen."
---
## **Einleitung**

Aspose.Slides for PHP via Java ermöglicht es Ihnen, die Tabellenstruktur und -formatierung in PowerPoint‑Präsentationen über die Klasse [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) zu verwalten. Sie können eine Kopfzeilenzeile festlegen, Zeilen und Spalten duplizieren oder entfernen und Textformatierung auf eine ganze Zeile oder Spalte anwenden.

Dieser Artikel erklärt diese Vorgänge mit PHP‑Beispielen. Er zeigt außerdem, wie man das Stil‑Preset einer Tabelle abruft, um es wiederzuverwenden. Zeilen- und Spaltenindizes von Tabellen beginnen bei null.

## **Zeilenhöhe steuern**

Verwenden Sie [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) um die minimale Höhe einer Zeile in Punkt festzulegen. Es ist eine Untergrenze, keine feste Höhe. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) gibt die tatsächliche Höhe zurück. Greifen Sie über [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/) auf die Zeile zu.

Das Beispiel lädt [row-height-input.pptx](row-height-input.pptx), das eine Tabelle als erstes Shape auf der ersten Folie enthält. Die erste Zeile beginnt bei 70 Punkt. Die Zellen verwenden 18‑Punkt‑Arial‑Text, Zeilenumbruch und 6‑Punkt‑Abstände oben und unten; der längere Text in der zweiten Spalte wird auf mehrere Zeilen umgebrochen. Das Beispiel erhöht die Mindesthöhe auf 100 Punkt, reduziert sie dann auf 20 Punkt, gibt nach jeder Änderung die tatsächliche Höhe aus und speichert beide Ergebnisse.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bei der bereitgestellten Präsentation fügt das Erhöhen des Minimums der Zeile zusätzlichen Raum hinzu. Das Verringern entfernt diesen zusätzlichen Raum, aber die tatsächliche Höhe bleibt über 20 Punkt, weil Text und Zellabstände mehr Platz benötigen. Das alleinige Reduzieren des Minimums kann die Zeile nicht unter den von ihrem Inhalt erforderlichen Raum bringen.

- **Text und Schriftgröße:** Längerer Text, explizite Zeilenumbrüche oder eine größere Schrift können mehr vertikalen Raum benötigen.  
- **Umbruch und Spaltenbreite:** Bei aktiviertem Umbruch kann das Reduzieren der Spaltenbreite mit [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) zu mehr Zeilen führen. Eine breitere Spalte kann den vertikalen Platzbedarf verringern.  
- **Zellabstände:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) und [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) fügen vertikalen Abstand hinzu. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) und [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) verringern die für Text verfügbare Breite und können zusätzlichen Umbruch verursachen.

Bei dieser Tabelle ohne zusammengeführte Zellen bestimmt die Zelle, die den meisten vertikalen Raum benötigt, die inhaltlich getriebene Untergrenze für die gesamte Zeile. Um die Zeile zu verkürzen, müssen Sie möglicherweise den Text kürzen, die Schriftgröße oder die Abstände reduzieren oder eine Spalte verbreitern.

Die nachfolgenden Bilder zeigen dieselbe Tabelle im gleichen Maßstab. In den dargestellten Ergebnissen betrugen die tatsächlichen Höhen 70, 100 und 55,2 Punkt: Die letzte Zeile blieb höher als ihr Minimum von 20 Punkt. Exakte Textmessungen können je nach in Ihrer Umgebung verfügbaren Schriften variieren. Laden Sie die gespeicherten Ergebnisse herunter: [erhöhtes Minimum](row-height-increased.pptx) und [reduziertes Minimum](row-height-decreased.pptx).

| Original: Minimum 70 pt, tatsächliche Höhe 70 pt | Erhöht: Minimum 100 pt, tatsächliche Höhe 100 pt | Reduziert: Minimum 20 pt, tatsächliche Höhe 55,2 pt |
| --- | --- | --- |
| ![Originaltabelle mit einer ersten Zeile von 70 Punkt.](row-height-before.png) | ![Tabelle nach Erhöhen des Minimums der ersten Zeile auf 100 Punkt.](row-height-increased.png) | ![Tabelle nach Reduzieren des Minimums der ersten Zeile auf 20 Punkt; umbrochener Text hält die Zeile höher als das Minimum.](row-height-decreased.png) |

## **Erste Zeile als Header festlegen**

Verwenden Sie die Methode [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/), um die erste Zeile für die Header‑Formatierung zu kennzeichnen. Das Aussehen hängt vom auf die Tabelle angewendeten Tabellenstil ab.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Greifen Sie auf die Tabelle zu, die als erstes Shape auf der Folie gespeichert ist.
4. Aktivieren Sie die Header‑Formatierung für deren erste Zeile.
5. Speichern Sie die geänderte Präsentation.

Das Beispiel erfordert `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie. Es aktiviert die Header‑Formatierung für die erste Zeile und speichert `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Eine Tabellenzeile oder -spalte duplizieren**

Duplizieren Sie Zeilen oder Spalten, um deren Inhalt und Formatierung wiederzuverwenden. Sie können eine Kopie am Ende der Tabelle anhängen oder an einer bestimmten Position einfügen.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie eine Tabelle mit der Methode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) hinzu.
5. Duplizieren Sie die erforderlichen Zeilen.
6. Duplizieren Sie die erforderlichen Spalten.
7. Speichern Sie die geänderte Präsentation.

Das Beispiel erfordert `Test.pptx` mit mindestens einer Folie. Es erstellt eine Tabelle mit drei Spalten und fünf Zeilen, wobei die Abmessungen in Punkt angegeben sind. Es hängt Kopien der ersten Zeile und Spalte an, fügt dann Kopien der zweiten Zeile und Spalte an Index 3 (vierter Platz) ein. Die resultierende Tabelle hat sieben Zeilen und fünf Spalten. Das Argument `false` verhindert das Duplizieren in angrenzende zusammengeführte Zeilen oder Spalten; diese Tabelle enthält keine zusammengeführten Zellen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Eine Zeile oder Spalte aus einer Tabelle entfernen**

Entfernen Sie Zeilen oder Spalten, die in einer Tabelle nicht mehr benötigt werden. Das Entfernen eines Elements verschiebt die Indizes der nachfolgenden Zeilen oder Spalten.

1. Erstellen Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die erste Folie zu.
3. Definieren Sie die Spaltenbreiten und Zeilenhöhen.
4. Fügen Sie eine Tabelle mit der Methode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) hinzu.
5. Entfernen Sie die zweite Zeile und die zweite Spalte.
6. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 3 × 3‑Tabelle und entfernt die Zeile und Spalte an Index 1, sodass eine 2 × 2‑Tabelle in `TestTable_out.pptx` entsteht. Die Abmessungen sind in Punkt angegeben. Das Argument `false` verhindert das Entfernen angrenzender zusammengeführter Zeilen oder Spalten; diese Tabelle enthält keine zusammengeführten Zellen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Textformatierung auf Zeilenebene der Tabelle festlegen**

Wenden Sie Textformatierung auf eine gesamte Zeile an, um die Zellen konsistent zu halten. Sie können Schriftarteigenschaften, Absatzformatierung und Textausrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Verwenden Sie [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) für die erste Zeile.
4. Verwenden Sie [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) und [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) für die erste Zeile.
5. Verwenden Sie [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) für die zweite Zeile.
6. Speichern Sie die geänderte Präsentation.

Das Beispiel erfordert `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie und mindestens zwei Zeilen. Es wendet 25‑Punkt‑Text, rechtsbündige Ausrichtung und einen 20‑Punkt‑rechten Absatzabstand auf die erste Zeile an und setzt dann vertikalen Text in der zweiten Zeile.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Textformatierung auf Spaltenebene der Tabelle festlegen**

Wenden Sie Textformatierung auf eine gesamte Spalte an, um die Zellen konsistent zu halten. Sie können Schriftarteigenschaften, Absatzformatierung und Textausrichtung festlegen, ohne jede Zelle einzeln zu formatieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die Tabelle auf der ersten Folie zu.
3. Verwenden Sie [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) für die erste Spalte.
4. Verwenden Sie [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) und [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) für die erste Spalte.
5. Verwenden Sie [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) für die zweite Spalte.
6. Speichern Sie die geänderte Präsentation.

Das Beispiel erfordert `table.pptx` mit einer Tabelle als erstes Shape auf der ersten Folie und mindestens zwei Spalten. Es wendet 25‑Punkt‑Text, rechtsbündige Ausrichtung und einen 20‑Punkt‑rechten Absatzabstand auf die erste Spalte an und setzt dann vertikalen Text in der zweiten Spalte.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie die Methode [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/), um das auf eine Tabelle angewendete Preset abzurufen und es auf einer anderen Tabelle wiederzuverwenden. Damit wird das Preset statt einzelner Zellformatierungs‑Overrides identifiziert.

Das Beispiel erstellt eine Tabelle, wendet [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) an und liest das Preset wieder aus. Es gibt den ganzzahligen Wert für `DarkStyle1` aus und speichert die Tabelle in `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Kann ich PowerPoint‑Designs/‑Stile auf eine bereits erstellte Tabelle anwenden?**

Ja. Die Tabelle erbt das Folien‑/Layout‑/Master‑Design, und Sie können dennoch Füllungen, Rahmen und Textfarben über diesem Design überschreiben.

**Kann ich Tabell Zeilen wie in Excel sortieren?**

Nein, Aspose.Slides‑Tabellen besitzen keine integrierte Sortierung oder Filter. Sortieren Sie Ihre Daten zuerst im Speicher und füllen Sie dann die Tabell Zeilen in dieser Reihenfolge erneut.

**Kann ich banded (gestreifte) Spalten haben und gleichzeitig benutzerdefinierte Farben für bestimmte Zellen behalten?**

Ja. Schalten Sie banded Spalten ein, dann überschreiben Sie bestimmte Zellen mit lokaler Formatierung; die Zellenformatierung hat Vorrang vor dem Tabellenstil.