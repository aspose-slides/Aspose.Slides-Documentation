---
title: Effectieve vormeigenschappen ophalen uit presentaties in PHP
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/php-java/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtinstallatie
- afgeschuinde vorm
- tekstframe
- tekststijl
- letterhoogte
- opvulopmaak
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor PHP via Java effectieve vormeigenschappen berekent en toepast voor nauwkeurige PowerPoint-weergave."
---
## **Overzicht**

Dit onderwerp legt het verschil uit tussen **lokale** en **effectieve** eigenschappen. Lokale waarden zijn waarden die direct op een specifiek opmaakniveau worden ingesteld, zoals:

1. Portie‑eigenschappen op een dia.
1. Prototype‑vormtekststijlen op een lay‑out‑ of masterslide, wanneer de vorm van het tekstframe van de portie er één heeft.
1. Globale tekstinstellingen in een presentatie.

Lokale waarden kunnen op elk niveau worden gedefinieerd of weggelaten. Wanneer Aspose.Slides de uiteindelijke “as rendered” opmaak nodig heeft, lost het de erfelijkheidsketen op en retourneert **effectieve** waarden. Je kunt ze verkrijgen door de `getEffective`‑methode aan te roepen op het lokale opmaakobject.

Het volgende voorbeeld toont hoe je effectieve waarden kunt verkrijgen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) met een tekstframe en ten minste één portie is.

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
Effectieve opmaakgegevens vertegenwoordigen de huidige berekende opmaak nadat erfelijkheid is toegepast. In de huidige implementatie kunnen sommige effectieve gegevensobjecten die door methoden zoals [PortionFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/geteffective/) worden geretourneerd intern worden gecached. Het opnieuw aanroepen van `getEffective` nadat ouder‑ of geërfde opmaak is gewijzigd, kan de gecachte gegevens vernieuwen, en een eerder verkregen object vertegenwoordigt mogelijk niet meer de vorige staat. Als je effectieve waarden wilt behouden voor later hergebruik, kopieer dan de benodigde eigenschappen, zoals letterhoogte, vulkleur, lettertype‑stijl of uitlijning, naar je eigen gegevensobject.
{{% /alert %}}

## **Effectieve eigenschappen van een camera ophalen**

Aspose.Slides stelt je in staat om effectieve eigenschappen van een camera op te halen. De effectieve gegevens die door [ThreeDFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/geteffective/) worden geretourneerd, bevatten de uiteindelijke camera‑eigenschappen voor een [ThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/).

De volgende code‑voorbeeld laat zien hoe je effectieve eigenschappen voor de camera kunt ophalen. Er wordt aangenomen dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

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

## **Effectieve eigenschappen van een lichtinstallatie ophalen**

Aspose.Slides stelt je in staat om effectieve eigenschappen van een lichtinstallatie op te halen. De effectieve gegevens die door [ThreeDFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/geteffective/) worden geretourneerd, bevatten de uiteindelijke lichtinstallatie‑eigenschappen voor een [ThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/).

De volgende code‑voorbeeld laat zien hoe je effectieve eigenschappen voor de lichtinstallatie kunt ophalen. Er wordt aangenomen dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

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

## **Effectieve eigenschappen van een afgeschuinde vorm ophalen**

Aspose.Slides stelt je in staat om effectieve eigenschappen van een afgeschuinde vorm op te halen. De effectieve gegevens die door [ThreeDFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/geteffective/) worden geretourneerd, bevatten de uiteindelijke vlak‑relief‑eigenschappen voor een [ThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/).

De volgende code‑voorbeeld laat zien hoe je effectieve eigenschappen voor de bovenste afschuining van een vorm kunt ophalen. Er wordt aangenomen dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

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

## **Effectieve eigenschappen van een tekstframe ophalen**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekstframe ophalen. De effectieve gegevens die door [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/geteffective/) worden geretourneerd, bevatten de opmaak‑eigenschappen van het tekstframe.

De volgende code‑voorbeeld laat zien hoe je effectieve opmaak‑eigenschappen van een tekstframe kunt ophalen. Er wordt aangenomen dat de eerste vorm op de eerste dia een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) met een tekstframe is.

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

## **Effectieve eigenschappen van een tekststijl ophalen**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekststijl ophalen. De effectieve gegevens die door [TextStyle.getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textstyle/geteffective/) worden geretourneerd, bevatten de eigenschappen van de tekststijl.

De volgende code‑voorbeeld laat zien hoe je effectieve tekststijl‑eigenschappen kunt ophalen. Er wordt aangenomen dat de eerste vorm op de eerste dia een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) met een tekstframe is.

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

## **De effectieve letterhoogtewaarde ophalen**

Met Aspose.Slides kun je de effectieve letterhoogte verkrijgen. De volgende code demonstreert hoe de effectieve letterhoogte van een portie verandert nadat lokale letterhoogte‑waarden op verschillende niveaus van de presentatiestructuur zijn ingesteld.

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

## **De effectieve opvulopmaak voor een tabel ophalen**

Met Aspose.Slides kun je de effectieve opvulopmaak voor verschillende tabelonderdelen ophalen. De effectieve gegevens die door formatobjecten worden geretourneerd, bevatten [FillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/)‑eigenschappen. Celopmaak heeft een hogere prioriteit dan rij‑opmaak, rij‑opmaak heeft een hogere prioriteit dan kolom‑opmaak, en kolom‑opmaak heeft een hogere prioriteit dan de opmaak van de volledige tabel.

Daarom worden de effectieve [CellFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellformat/)‑eigenschappen gebruikt om de tabelcel te tekenen. De volgende code‑voorbeeld laat zien hoe je de effectieve opvulopmaak voor verschillende tabelonderdelen kunt ophalen. Er wordt aangenomen dat de eerste vorm op de eerste dia een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/table/) is.

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

**Retourneert `getEffective` een momentopname?**

Niet altijd. Effectieve gegevens vertegenwoordigen de berekende opmaak nadat erfelijkheid is toegepast, maar sommige effectieve gegevensobjecten kunnen intern worden gecached. Een daaropvolgende `getEffective`‑aanroep kan de opmaak herberekenen en de gecachte gegevens vernieuwen, dus een eerder verkregen object mag niet worden beschouwd als een duurzame momentopname.

**Wanneer moet ik effectieve eigenschappen opnieuw uitlezen?**

Roep `getEffective` opnieuw aan nadat lokale opmaak, bovenliggende stijlen, lay‑out‑opmaak, master‑opmaak of standaardinstellingen op presentatieniveau zijn gewijzigd. De volgende aanroep evalueert de opmaakhiërarchie opnieuw en retourneert het actuele effectieve resultaat.

**Heeft het wijzigen of verwijderen van een lay‑out‑/masterslide invloed op reeds opgehaalde effectieve eigenschappen?**

Ja, maar de wijziging wordt pas zichtbaar bij de volgende `getEffective`‑aanroep. Als een bovenliggende opmaakbron wordt gewijzigd of verwijderd, kan eerder verkregen effectieve data verouderd zijn. Zodra `getEffective` opnieuw wordt aangeroepen, evalueert Aspose.Slides de opmaakboom opnieuw en kunnen de resulterende lettertypen, kleuren, groottes of andere waarden veranderen.

**Kan ik waarden aanpassen via effectieve gegevensobjecten?**

Nee. Effectieve gegevensobjecten geven alleen berekende waarden weer. Breng wijzigingen aan in de lokale opmaakobjecten en haal vervolgens opnieuw de effectieve waarden op.

**Wat gebeurt er als een eigenschap niet is ingesteld op vormniveau, noch in de lay‑out/master, noch in de globale instellingen?**

De effectieve waarde wordt bepaald door het standaardmechanisme, dat de standaardinstellingen van PowerPoint en Aspose.Slides omvat. Die opgeloste waarde wordt onderdeel van de huidige effectieve gegevens.

**Kan ik aan de hand van een effectieve lettertype‑waarde zien op welk niveau de grootte of het lettertype is gedefinieerd?**

Niet rechtstreeks. Effectieve gegevens geven alleen de uiteindelijke waarde terug. Om de bron te vinden, moet je de lokale waarden controleren op portie‑, alinea‑, tekstframe‑ en tekststijlniveau in de lay‑out, master en presentatie om te zien waar de eerste expliciete definitie voorkomt.

**Waarom lijken effectieve waarden soms identiek aan de lokale waarden?**

Omdat de lokale waarde uiteindelijk definitief bleek te zijn (er was geen erfelijkheid van een hoger niveau nodig). In dat geval komt de effectieve waarde overeen met de lokale waarde.

**Wanneer moet ik effectieve eigenschappen gebruiken en wanneer alleen met lokale werken?**

Gebruik effectieve gegevens wanneer je het “as rendered” resultaat nodig hebt na toepassing van alle erfelijkheid, bijvoorbeeld om kleuren, inspringingen of groottes op elkaar af te stemmen. Als je die waarden wilt behouden, ongeacht latere opmaakwijzigingen, kopieer je de benodigde eigenschappen naar je eigen object. Als je opmaak op een specifiek niveau wilt wijzigen, pas je de lokale eigenschappen aan en lees je, indien nodig, de effectieve gegevens opnieuw uit om het resultaat te verifiëren.