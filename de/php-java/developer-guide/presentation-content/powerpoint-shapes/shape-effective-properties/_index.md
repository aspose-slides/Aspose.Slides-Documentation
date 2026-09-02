---
title: Abrufen effektiver Formeigenschaften aus Präsentationen in PHP
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/php-java/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Beleuchtungssystem
- Abgeschrägte Form
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für PHP via Java verwenden, um lokale, geerbte und effektive Formformatierungen in PowerPoint-Präsentationen zu unterscheiden."
---
## **Lokale, geerbte und effektive Eigenschaften verstehen**

PowerPoint-Formatierungen können von mehreren Stellen kommen. Der direkt an einem Objekt gespeicherte Wert ist sein **lokaler Wert**. Wenn dieser Wert nicht gesetzt ist, sucht PowerPoint nach übergeordneten Formatierungsquellen, wie einem Absatzstandard, einem Textstil, einem Layout‑ oder Master‑Folie, einem Design oder präsentationsweiten Vorgaben. Diese Werte sind **geerbte Werte**. Der Wert, der nach Auflösung der gesamten Hierarchie verbleibt, ist der **effektive Wert** – der zum Rendern des Objekts verwendete Wert.

Beispielsweise definiert ein Textabschnitt möglicherweise nicht seine eigene Schriftgröße. Sein lokaler [getFontHeight](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/) Wert ist dann `NAN`, was „hier nicht gesetzt“ bedeutet. Der Abschnitt kann eine Höhe vom Absatz, vom standardmäßigen Textstil der Präsentation oder einer anderen zutreffenden Quelle erben. Ein Aufruf von [getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/portionformat/geteffective/) auf das PortionFormat liefert die endgültig aufgelöste Höhe.

Verwenden Sie die beiden Arten von Formatierungsdaten für unterschiedliche Zwecke:

- Lesen oder ändern Sie ein lokales Formatobjekt, wie z. B. [PortionFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/portionformat/), wenn Sie steuern müssen, wo ein Wert definiert ist.
- Lesen Sie ein effektives Datenobjekt, wie die [von PortionFormat.getEffective zurückgegebenen Daten](https://reference.aspose.com/slides/de/php-java/aspose.slides/portionformat/geteffective/), wenn Sie das endgültige, gerenderte Ergebnis benötigen. Effektive Daten sind schreibgeschützt.

Bevor Sie die Beispiele ausführen, [installieren Sie Aspose.Slides für PHP via Java](/slides/de/php-java/installation/).

## **Lokale, geerbte und effektive Werte vergleichen**

Das folgende vollständige Beispiel erstellt eine Form und wendet Schriftgrößen auf Präsentations-, Absatz- und Abschnittsebene an. Jeder Schritt gibt die an diesen Ebenen definierten Werte sowie den resultierenden effektiven Wert für denselben Textabschnitt aus. Es zeigt auch, warum effektive Daten nach Formatierungsänderungen erneut gelesen werden müssen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Effektive Daten nach den vorherigen Änderungen lesen.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Geerbte Werte auf zwei verschiedenen Ebenen definieren.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Ein lokaler Wert im Abschnitt überschreibt beide geerbten Werte.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Das Ändern eines geerbten Wertes überschreibt keinen bereits vorhandenen lokalen Wert.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Den lokalen Wert löschen. Der Abschnitt erbt jetzt wieder vom Absatz.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Den Absatzwert löschen. Der Präsentationsstandard liefert nun das Ergebnis.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Priorität in diesem Beispiel liegt zuerst auf der lokalen Formatierung des Abschnitts, dann auf der Absatzformatierung und schließlich auf dem Präsentationsstandard. Andere Objekte können unterschiedliche Vererbungsketten haben, aber das Prinzip ist dasselbe: ein spezifischerer expliziter Wert gewinnt, und [getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/portionformat/geteffective/) liefert das Endergebnis.

## **Effektive Texteigenschaften abrufen**

Textformatierung ist auf mehrere Objekte verteilt:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/geteffective/) löst Text‑Frame‑Eigenschaften wie Ränder, Verankerung, AutoFit und vertikale Textausrichtung auf.
- [TextStyle.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/textstyle/geteffective/) löst Absatzformatierungen für jede Textstilebene auf.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/geteffective/) löst Absatzeigenschaften wie Ausrichtung, Einrückung und Aufzählungszeichen auf.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/portionformat/geteffective/) löst Zeicheneigenschaften wie Schriftgröße, Schriftart, Farbe, Fettdruck und Kursivschrift auf.

Für das nächste Beispiel muss `text-formatting.pptx` mindestens eine Folie und eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) mit einem nicht leeren Textfeld enthalten. Die AutoShape kann an beliebiger Stelle in der Formensammlung vorkommen; der Code sucht nach einem geeigneten Objekt und validiert es vor der Verwendung.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Effektive 3D‑Eigenschaften abrufen**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/geteffective/) liefert ein effektives Datenobjekt, das alle aufgelösten 3D‑Einstellungen gruppiert. Seine Methoden [getCamera](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/geteffective/) und [getBevelBottom](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/geteffective/) geben die entsprechenden effektiven Daten frei. Das gleichzeitige Lesen dieser zusammengehörigen Einstellungen erleichtert das Verständnis des endgültigen 3D‑Aussehens einer Form.

Für dieses Beispiel muss `shape-3d.pptx` mindestens eine Form auf der ersten Folie enthalten. Wenden Sie 3D‑Kamera-, Beleuchtungs- oder Abschrägungs‑Einstellungen auf diese Form an, wenn die Ausgabe Werte enthalten soll, die von den Vorgabewerten abweichen.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Effektive Tabellenformatierung abrufen**

Tabellenformatierung kann aus dem Tabellenstil und aus Formaten stammen, die auf die gesamte Tabelle, eine Spalte, eine Zeile oder eine einzelne Zelle angewendet werden. Bei Konflikten zwischen explizit definierten Füllungen ist die Priorität: Zelle, Zeile, Spalte und dann die gesamte Tabelle. Das effektive Format einer Zelle ist das endgültige Format, das zum Zeichnen dieser Zelle verwendet wird.

Für dieses Beispiel muss `table-formatting.pptx` mindestens eine Tabelle auf der ersten Folie enthalten. Die Tabelle muss mindestens eine Zeile und eine Spalte haben. Der Code sucht nach einer [Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/table/), anstatt anzunehmen, dass `getShapes()->get_Item(0)` eine Tabelle ist.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Wenn Sie die Farbe statt nur des Fülltyps benötigen, prüfen Sie zuerst den effektiven [getFillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/fillformat/geteffective/)‑Wert und lesen Sie dann die für diesen Typ passende Methode – zum Beispiel [getSolidFillColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/fillformat/geteffective/) für eine einfarbige Füllung.

## **Effektive Daten nach Änderungen erneut lesen**

Effektive Daten beschreiben die Formatierungshierarchie zum Zeitpunkt ihrer Auflösung. Rufen Sie `getEffective` erneut auf, nachdem Sie etwas geändert haben, das an dieser Hierarchie beteiligt sein kann, einschließlich:

- der lokalen Formatierung des Objekts;
- der Absatz- oder Text‑Frame‑Standardwerte;
- eines Tabellenstils, einer Tabelle, Spalte, Zeile oder Zellenformat;
- Layout‑ oder Master‑Folienformatierung;
- Design‑Daten oder präsentationsweite Vorgaben;
- das dem Folie zugewiesene Layout oder Master.

Bewahren Sie ein effektives Datenobjekt nicht als dauerhaften Schnappschuss auf. Aspose.Slides kann einige effektive Daten intern zwischenspeichern, und ein späterer Aufruf von `getEffective` kann diese Daten aktualisieren. Wenn Sie Werte vor und nach einer Änderung vergleichen müssen, kopieren Sie die benötigten skalaren Werte – etwa Schriftgröße, Farbe, Ausrichtung oder Abschrägungsbreite – in eigene Variablen, bevor Sie die Änderung vornehmen.

Um einen Wert zu ändern, aktualisieren Sie das entsprechende lokale Formatobjekt und rufen Sie anschließend `getEffective` auf, um das Ergebnis zu prüfen. Effektive Datenobjekte selbst sind schreibgeschützt.

## **FAQ**

**Wie kann ich erkennen, welche Ebene einen effektiven Wert bereitgestellt hat?**

Effektive Daten enthalten den endgültigen Wert, nicht dessen Quelle. Untersuchen Sie die zutreffenden lokalen Objekte von der spezifischsten Ebene ausgehend nach außen. Für Text können das der Abschnitt, Absatz, Text‑Frame, Layout, Master, Design und die Präsentationsvorgaben sein. Nicht definierte Werte wie `NAN` oder `null` zeigen an, dass die Suche zur nächsten Ebene fortgesetzt wird.

**Was passiert, wenn keine Ebene eine Eigenschaft definiert?**

Aspose.Slides löst den entsprechenden PowerPoint‑ oder Bibliotheksstandard auf. Dieser aufgelöste Wert erscheint in den effektiven Daten, obwohl kein lokales Objekt ihn explizit definiert.

**Warum entspricht ein effektiver Wert manchmal dem lokalen Wert?**

Der lokale Wert hat die Vererberechnung gewonnen. Das ist zu erwarten, wenn die Eigenschaft am Objekt explizit gesetzt ist und keine spezifischere Regel sie überschreibt.

**Wann sollte ich lokale Daten statt effektiver Daten verwenden?**

Verwenden Sie lokale Daten, um eine bestimmte Formatierungsebene zu prüfen oder zu bearbeiten. Nutzen Sie effektive Daten, wenn Sie das endgültige Erscheinungsbild nach Vererbung, Design‑Regeln und angewandten Stilen benötigen. Das [vollständige Vergleichsbeispiel](#compare-local-inherited-and-effective-values) zeigt beides im selben Arbeitsablauf.