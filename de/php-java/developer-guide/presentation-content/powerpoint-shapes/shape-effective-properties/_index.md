---
title: "Effektive Formeigenschaften aus Präsentationen in PHP abrufen"
linktitle: "Effektive Eigenschaften"
type: docs
weight: 50
url: /de/php-java/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Licht-Setup
- Formabschrägung
- Textfeld
- Textstil
- Schriftgrad
- Füllformat
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für PHP über Java effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint-Darstellung zu ermöglichen."
---
## **Übersicht**

Dieser Abschnitt erklärt den Unterschied zwischen **lokalen** und **effektiven** Eigenschaften. Lokale Werte sind Werte, die direkt auf einer bestimmten Formatierungsebene festgelegt werden, beispielsweise:

1. Teil‑Eigenschaften auf einer Folie.
1. Prototyp‑Form‑Textstile auf einem Layout‑ oder Master‑Folien, wenn die Textfeld‑Form des Abschnitts einen hat.
1. Globale Texteinstellungen in einer Präsentation.

Lokale Werte können auf jeder Ebene definiert oder weggelassen werden. Wenn Aspose.Slides die endgültige „wie gerenderte“ Formatierung benötigt, löst es die Vererbungskette auf und liefert **effektive** Werte. Sie erhalten sie, indem Sie die Methode `getEffective` auf dem lokalen Formatobjekt aufrufen.

Das folgende Beispiel zeigt, wie man effektive Werte abruft. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) mit einem Textfeld und mindestens einem Abschnitt ist.

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

Effektive Formatierungsdaten stellen die aktuell berechnete Formatierung dar, nachdem die Vererbung angewendet wurde. In der aktuellen Implementierung können einige von Methoden wie [PortionFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/portionformat/geteffective/) zurückgegebene effektive Datenobjekte intern zwischengespeichert werden. Ein erneuter Aufruf von `getEffective` nach einer Änderung der übergeordneten oder vererbten Formatierung kann die zwischengespeicherten Daten aktualisieren, und ein zuvor erhaltenes Objekt stellt möglicherweise nicht mehr den früheren Zustand dar. Wenn Sie effektive Werte für spätere Verwendung aufbewahren müssen, kopieren Sie die benötigten Eigenschaften, wie Schriftgrad, Füllfarbe, Schriftsstil oder Ausrichtung, in Ihr eigenes Datenobjekt.

{{% /alert %}}

## **Effektive Eigenschaften einer Kamera abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Kamera. Die von [ThreeDFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/geteffective/) zurückgegebenen effektiven Daten enthalten die endgültigen Kameraeigenschaften für ein [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/).

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften der Kamera erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

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

## **Effektive Eigenschaften eines Licht‑Setups abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften eines Licht‑Setups. Die von [ThreeDFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/geteffective/) zurückgegebenen effektiven Daten enthalten die endgültigen Licht‑Setup‑Eigenschaften für ein [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/).

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften des Licht‑Setups erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

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

## **Effektive Eigenschaften einer Abschrägung einer Form abrufen**

Aspose.Slides ermöglicht das Abrufen effektiver Eigenschaften einer Formabschrägung. Die von [ThreeDFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/geteffective/) zurückgegebenen effektiven Daten enthalten die endgültigen Flächeneffekteigenschaften für ein [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/).

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften der oberen Abschrägung einer Form erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine 3D‑Formatierung besitzt.

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

## **Effektive Eigenschaften eines Textfelds abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textfelds abrufen. Die von [TextFrameFormat.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/geteffective/) zurückgegebenen effektiven Daten enthalten die Formatierungseigenschaften des Textfelds.

Das folgende Codebeispiel zeigt, wie man effektive Textfeldformatierungseigenschaften erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) mit einem Textfeld ist.

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

## **Effektive Eigenschaften eines Textstils abrufen**

Mit Aspose.Slides können Sie effektive Eigenschaften eines Textstils abrufen. Die von [TextStyle.getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/textstyle/geteffective/) zurückgegebenen effektiven Daten enthalten die Eigenschaften des Textstils.

Das folgende Codebeispiel zeigt, wie man effektive Textstileigenschaften erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) mit einem Textfeld ist.

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

## **Den effektiven Schriftgradwert erhalten**

Mit Aspose.Slides können Sie den effektiven Schriftgrad erhalten. Der folgende Code demonstriert, wie sich der effektive Schriftgrad eines Abschnitts ändert, nachdem lokale Schriftgradwerte auf verschiedenen Ebenen der Präsentationsstruktur festgelegt wurden.

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

## **Effektives FillFormat für eine Tabelle erhalten**

Mit Aspose.Slides können Sie effektive Füllformatierung für verschiedene Tabellenteile erhalten. Die von Formatobjekten zurückgegebenen effektiven Daten enthalten [FillFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/fillformat/)‑Eigenschaften. Zellenformatierung hat höhere Priorität als Zeilenformatierung, Zeilenformatierung hat höhere Priorität als Spaltenformatierung und Spaltenformatierung hat höhere Priorität als die Formatierung der gesamten Tabelle.

Infolgedessen werden effektive [CellFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/cellformat/)‑Eigenschaften zum Zeichnen der Tabellenzelle verwendet. Das folgende Codebeispiel zeigt, wie man effektive Füllformatierung für verschiedene Tabellenteile erhält. Es wird davon ausgegangen, dass die erste Form auf der ersten Folie eine [Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/table/) ist.

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

Nicht immer. Effektive Daten stellen die berechnete Formatierung nach Anwendung der Vererbung dar, aber einige effektive Datenobjekte können intern zwischengespeichert werden. Ein nachfolgender Aufruf von `getEffective` kann die Formatierung neu berechnen und die zwischengespeicherten Daten aktualisieren, sodass ein zuvor erhaltenes Objekt nicht als dauerhafter Schnappschuss behandelt werden sollte.

**Wann sollte ich effektive Eigenschaften erneut lesen?**

Rufen Sie `getEffective` erneut auf, nachdem Sie lokale Formatierung, übergeordnete Stile, Layout‑Formatierung, Master‑Formatierung oder Präsentations‑Standardwerte geändert haben. Der nächste Aufruf bewertet die Formatierungshierarchie neu und gibt das aktuelle effektive Ergebnis zurück.

**Wirkt sich das Ändern oder Entfernen eines Layout‑/Master‑Folien auf bereits abgerufene effektive Eigenschaften aus?**

Ja, die Änderung wird beim nächsten Aufruf von `getEffective` berücksichtigt. Wenn eine übergeordnete Formatierungsquelle geändert oder entfernt wird, können zuvor erhaltene effektive Daten veraltet sein. Sobald `getEffective` erneut aufgerufen wird, evaluiert Aspose.Slides den Formatierungsbaum neu und die resultierenden Schriftarten, Farben, Größen oder anderen Werte können sich ändern.

**Kann ich Werte über effektive Datenobjekte ändern?**

Nein. Effektive Datenobjekte geben nur berechnete Werte frei. Änderungen sollten in den lokalen Formatierungsobjekten vorgenommen werden, und dann die effektiven Werte erneut abgerufen werden.

**Was passiert, wenn eine Eigenschaft weder auf Formenebene, noch im Layout/Master, noch in den globalen Einstellungen festgelegt ist?**

Der effektive Wert wird durch den Standardmechanismus ermittelt, der die Vorgaben von PowerPoint und Aspose.Slides umfasst. Dieser aufgelöste Wert wird Teil der aktuellen effektiven Daten.

**Kann ich anhand eines effektiven Schriftwerts erkennen, welche Ebene die Größe oder Schriftart liefert?**

Nicht direkt. Effektive Daten geben den endgültigen Wert zurück. Um die Quelle zu finden, prüfen Sie die lokalen Werte im Abschnitt, Absatz, Textfeld und Textstilen auf Layout-, Master‑ und Präsentationsebene, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen effektive Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert schließlich endgültig war (keine höhere Vererbung war erforderlich). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur lokale?**

Verwenden Sie effektive Daten, wenn Sie das „wie gerenderte“ Ergebnis nach vollständiger Anwendung der Vererbung benötigen, z. B. zum Angleichen von Farben, Einzügen oder Größen. Wenn Sie diese Werte unabhängig von späteren Formatierungsänderungen beibehalten müssen, kopieren Sie die benötigten Eigenschaften in Ihr eigenes Objekt. Wenn Sie die Formatierung auf einer bestimmten Ebene ändern möchten, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf die effektiven Daten erneut, um das Ergebnis zu überprüfen.