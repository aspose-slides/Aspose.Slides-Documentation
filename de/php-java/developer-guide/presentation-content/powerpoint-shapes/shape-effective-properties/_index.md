---
title: Formeigenschaften effektiv aus Präsentationen in PHP abrufen
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/php-java/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtgestell
- Abschrägungsform
- Textrahmen
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für PHP über Java effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint‑Wiedergabe zu gewährleisten."
---
## **Übersicht**

Dieses Thema erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene festgelegt werden, zum Beispiel:

1. Portionseigenschaften auf einer Folie.
1. Prototyp‑Form‑Textstile auf einem Layout‑ oder Master‑Slide, wenn das Text‑Frame‑Shape der Portion eines hat.
1. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides das endgültige „wie gerenderte“ Format benötigt, löst es die Vererbungskette auf und gibt **effektive** Werte zurück. Sie können diese erhalten, indem Sie die `getEffective`‑Methode auf dem lokalen Formatobjekt aufrufen.

Das folgende Beispiel zeigt, wie man effektive Werte abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) mit einem Text‑Frame und mindestens einer Portion ist.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}

Effektive Formatierungsdaten repräsentieren das aktuelle berechnete Format, nachdem die Vererbung angewendet wurde. In der aktuellen Implementierung können einige effektive Datenobjekte, die von Methoden wie [PortionFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/portionformat/geteffective/) zurückgegeben werden, intern zwischengespeichert sein. Ein erneuter Aufruf von `getEffective` nach Änderung von übergeordneten oder vererbten Formaten kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt stellt möglicherweise nicht mehr den früheren Zustand dar. Wenn Sie effektive Werte für die spätere Wiederverwendung behalten müssen, kopieren Sie die benötigten Eigenschaften wie Schriftgröße, Füllfarbe, Schriftstil oder Ausrichtung in Ihr eigenes Datenobjekt.

{{% /alert %}}

## **Effektive Eigenschaften einer Kamera abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Die effektiven Daten, die von [ThreeDFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/geteffective/) zurückgegeben werden, enthalten die endgültigen Kameraeigenschaften für ein [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/).

Der folgende Code‑Auszug zeigt, wie man effektive Kameraeigenschaften abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung hat.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Effektive Eigenschaften eines Lichtgestells abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften eines Lichtgestells. Die effektiven Daten, die von [ThreeDFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/geteffective/) zurückgegeben werden, enthalten die endgültigen Lichtgestell‑Eigenschaften für ein [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/).

Der folgende Code‑Auszug zeigt, wie man effektive Lichtgestell‑Eigenschaften abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung hat.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Effektive Eigenschaften einer Abschrägungsform abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Formabschrägung. Die effektiven Daten, die von [ThreeDFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/geteffective/) zurückgegeben werden, enthalten die endgültigen Relief‑Eigenschaften für ein [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/).

Der folgende Code‑Auszug zeigt, wie man effektive Eigenschaften der oberen Abschrägung einer Form abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung hat.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Effektive Eigenschaften eines Text‑Frames abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Text‑Frames abrufen. Die effektiven Daten, die von [TextFrameFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/geteffective/) zurückgegeben werden, enthalten die Formatierungseigenschaften des Text‑Frames.

Der folgende Code‑Auszug zeigt, wie man effektive Text‑Frame‑Formatierungseigenschaften abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) mit einem Text‑Frame ist.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Effektive Eigenschaften eines Text‑Stils abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Text‑Stils abrufen. Die effektiven Daten, die von [TextStyle.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/textstyle/geteffective/) zurückgegeben werden, enthalten die Eigenschaften des Text‑Stils.

Der folgende Code‑Auszug zeigt, wie man effektive Text‑Stil‑Eigenschaften abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) mit einem Text‑Frame ist.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Den effektiven Schriftgrößenwert abrufen**

Mit Aspose.Slides können Sie die effektive Schriftgröße erhalten. Der folgende Code demonstriert, wie sich die effektive Schriftgröße einer Portion ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Ebenen der Präsentationsstruktur festgelegt wurden.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Effektives Füllformat für eine Tabelle abrufen**

Mit Aspose.Slides können Sie das effektive Füllformat für verschiedene Tabellenteile erhalten. Die effektiven Daten, die von Formatobjekten zurückgegeben werden, enthalten [FillFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/fillformat/)‑Eigenschaften. Zellformatierung hat höhere Priorität als Zeilenformatierung, Zeilenformatierung hat höhere Priorität als Spaltenformatierung und Spaltenformatierung hat höhere Priorität als die Formatierung der gesamten Tabelle.

Infolgedessen werden die effektiven [CellFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellformat/)‑Eigenschaften zum Zeichnen der Tabellenzelle verwendet. Der folgende Code‑Auszug zeigt, wie man das effektive Füllformat für verschiedene Tabellenteile abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine [Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/table/) ist.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Gibt `getEffective` einen Schnappschuss zurück?**

Nicht immer. Effektive Daten repräsentieren das berechnete Format, nachdem die Vererbung angewendet wurde, aber einige effektive Datenobjekte können intern zwischengespeichert sein. Ein nachfolgender Aufruf von `getEffective` kann das Format neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss behandelt werden sollte.

**Wann sollte ich effektive Eigenschaften erneut lesen?**

Rufen Sie `getEffective` erneut auf, nachdem Sie lokale Formatierungen, übergeordnete Stile, Layout‑Formatierungen, Master‑Formatierungen oder Präsentations‑Standardwerte geändert haben. Der nächste Aufruf bewertet die Formatierungshierarchie neu und gibt das aktuelle effektive Ergebnis zurück.

**Wirkt sich das Ändern oder Entfernen eines Layout‑/Master‑Slides auf bereits abgerufene effektive Eigenschaften aus?**

Ja, die Änderung wird beim nächsten Aufruf von `getEffective` berücksichtigt. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Sobald `getEffective` erneut aufgerufen wird, bewertet Aspose.Slides den Formatierungsbaum neu und die resultierenden Schriftarten, Farben, Größen oder andere Werte können sich ändern.

**Kann ich Werte über effektive Datenobjekte ändern?**

Nein. Effektive Datenobjekte geben nur berechnete Werte zurück. Ändern Sie die lokalen Formatierungsobjekte und holen Sie sich dann erneut die effektiven Werte.

**Was passiert, wenn an der Form‑Ebene, im Layout/Master und in den globalen Einstellungen kein Wert gesetzt ist?**

Der effektive Wert wird durch den Standardmechanismus bestimmt, der die Vorgaben von PowerPoint und Aspose.Slides enthält. Dieser aufgelöste Wert wird Teil der aktuellen effektiven Daten.

**Kann ich anhand eines effektiven Schriftwertes erkennen, welche Ebene die Größe oder den Schriftsatz bereitgestellt hat?**

Nicht direkt. Effektive Daten geben nur den Endwert zurück. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte auf Portion‑, Absatz‑, Text‑Frame‑ und Text‑Stil‑Ebene im Layout, Master und Präsentations‑Level, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen effektive Werte manchmal identisch mit den lokalen aus?**

Weil der lokale Wert letztlich final war (keine höhere Vererbung war nötig). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur lokale?**

Verwenden Sie effektive Daten, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen, etwa zum Angleichen von Farben, Einrückungen oder Größen. Wenn Sie diese Werte unabhängig von späteren Formatierungsänderungen bewahren wollen, kopieren Sie die benötigten Eigenschaften in Ihr eigenes Objekt. Wenn Sie die Formatierung auf einer bestimmten Ebene ändern wollen, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf die effektiven Daten erneut, um das Ergebnis zu überprüfen.)