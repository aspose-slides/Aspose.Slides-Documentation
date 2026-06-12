---
title: Effectieve vormeigenschappen ophalen uit presentaties in JavaScript
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/nodejs-java/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtinstallatie
- schuine rand
- tekstkader
- tekststijl
- letterhoogte
- opvulopmaak
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Node.js via Java effectieve vormeigenschappen berekent en toepast voor nauwkeurige PowerPoint-weergave."
---
## **Overzicht**

Dit onderwerp legt het verschil uit tussen **lokale** en **effectieve** eigenschappen. Lokale waarden zijn waarden die rechtstreeks worden ingesteld op een specifiek opmaakniveau, zoals:

1. Gedeelte‑eigenschappen op een dia.  
1. Prototypevorm‑tekststijlen op een lay‑out of masterslide, wanneer de vorm van het tekstkader van het gedeelte er een heeft.  
1. Globale tekstopmaakinstellingen in een presentatie.

Lokale waarden kunnen op elk niveau worden gedefinieerd of weggelaten. Wanneer Aspose.Slides de uiteindelijke “zoals gerenderd” opmaak nodig heeft, lost het de erven‑keten op en retourneert **effectieve** waarden. U kunt ze verkrijgen door de `getEffective`‑methode aan te roepen op het lokale opmaakobject.

Het volgende voorbeeld toont hoe u effectieve waarden kunt krijgen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) is met een tekstkader en ten minste één gedeelte.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Effectieve opmaakgegevens vertegenwoordigen de huidige berekende opmaak nadat erven is toegepast. In de huidige implementatie kunnen sommige effectieve gegevensobjecten intern worden gecached. Het opnieuw aanroepen van `getEffective` nadat de bovenliggende of geërfde opmaak is gewijzigd, kan de gecachete gegevens vernieuwen, en een eerder verkregen object vertegenwoordigt mogelijk niet langer de eerdere staat. Als u effectieve waarden wilt behouden voor later hergebruik, kopieer dan de vereiste eigenschappen, zoals letterhoogte, opvulkleur, lettertype‑stijl of uitlijning, naar uw eigen gegevensobject.
{{% /alert %}}

## **Effectieve eigenschappen van een camera ophalen**

Aspose.Slides stelt u in staat om de effectieve eigenschappen van een camera op te halen. Het effectieve camera‑gegevensobject bevat onveranderlijke camera‑eigenschappen en wordt beschikbaar gesteld via de effectieve waarden die worden geretourneerd voor [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/).

Het volgende codevoorbeeld toont hoe u de effectieve eigenschappen voor de camera kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Effectieve eigenschappen van een lichtinstallatie ophalen**

Aspose.Slides stelt u in staat om de effectieve eigenschappen van een lichtinstallatie op te halen. Het effectieve lichtinstallatie‑gegevensobject bevat onveranderlijke lichtinstallatie‑eigenschappen en wordt beschikbaar gesteld via de effectieve waarden die worden geretourneerd voor [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/).

Het volgende codevoorbeeld toont hoe u de effectieve eigenschappen voor de lichtinstallatie kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Effectieve eigenschappen van een schuine rand (bevel) van een vorm ophalen**

Aspose.Slides stelt u in staat om de effectieve eigenschappen van een vormschuine rand op te halen. Het effectieve vorm‑schuine‑rand‑gegevensobject bevat onveranderlijke reliefeigenschappen voor een vorm en wordt beschikbaar gesteld via de effectieve waarden die worden geretourneerd voor [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/).

Het volgende codevoorbeeld toont hoe u de effectieve eigenschappen voor de bovenste schuine rand van een vorm kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Effectieve eigenschappen van een tekstkader ophalen**

Met Aspose.Slides kunt u de effectieve eigenschappen van een tekstkader ophalen. Het geretourneerde effectieve gegevensobject bevat eigenschappen voor de opmaak van het tekstkader.

Het volgende codevoorbeeld toont hoe u de effectieve opmaak van een tekstkader kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) met een tekstkader is.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Effectieve eigenschappen van een tekststijl ophalen**

Met Aspose.Slides kunt u de effectieve eigenschappen van een tekststijl ophalen. Het geretourneerde effectieve gegevensobject bevat eigenschappen voor de tekststijl.

Het volgende codevoorbeeld toont hoe u de effectieve tekststijleigenschappen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) met een tekstkader is.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **De effectieve waarde van de letterhoogte ophalen**

Met Aspose.Slides kunt u de effectieve letterhoogte ophalen. De volgende code laat zien hoe de effectieve letterhoogte van een gedeelte verandert nadat lokale letterhoogte‑waarden op verschillende niveaus van de presentatiestructuur zijn ingesteld.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **De effectieve opvulling voor een tabel ophalen**

Met Aspose.Slides kunt u effectieve opvulopmaak ophalen voor verschillende tabelonderdelen. Het geretourneerde effectieve gegevensobject bevat opvulopmaak‑eigenschappen. Celopmaak heeft een hogere prioriteit dan rij‑opmaak; rij‑opmaak heeft een hogere prioriteit dan kolom‑opmaak; en kolom‑opmaak heeft een hogere prioriteit dan opmaak van de hele tabel.

Als gevolg hiervan worden de effectieve celopmaak‑eigenschappen gebruikt om de tabelcel te tekenen. Het volgende codevoorbeeld toont hoe u de effectieve opvulopmaak voor verschillende tabelonderdelen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/table/) is.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Retourneert `getEffective` een momentopname?**

Niet altijd. Effectieve gegevens vertegenwoordigen de berekende opmaak nadat erfelijkheid is toegepast, maar sommige effectieve gegevensobjecten kunnen intern worden gecached. Een daaropvolgende `getEffective`‑aanroep kan de opmaak opnieuw berekenen en de gecachete gegevens vernieuwen, waardoor een eerder verkregen object niet als een duurzame momentopname moet worden beschouwd.

**Wanneer moet ik de effectieve eigenschappen opnieuw lezen?**

Roep `getEffective` opnieuw aan nadat u lokale opmaak, bovenliggende stijlen, lay‑out‑opmaak, masters‑opmaak of presentatie‑standaardinstellingen hebt gewijzigd. De volgende aanroep evalueert de opmaakhiërarchie opnieuw en retourneert het huidige effectieve resultaat.

**Heeft het wijzigen of verwijderen van een lay‑out‑/masterslide invloed op reeds opgehaalde effectieve eigenschappen?**

Ja, maar de wijziging wordt pas zichtbaar bij de volgende `getEffective`‑aanroep. Als een bron van bovenliggende opmaak wordt gewijzigd of verwijderd, kunnen eerder verkregen effectieve gegevens verouderd zijn. Zodra `getEffective` opnieuw wordt aangeroepen, evalueert Aspose.Slides de opmaakboom opnieuw en kunnen de resulterende lettertypen, kleuren, groottes of andere waarden veranderen.

**Kan ik waarden wijzigen via effectieve gegevensobjecten?**

Nee. Effectieve gegevensobjecten geven alleen berekende waarden weer. Breng wijzigingen aan in de lokale opmaakobjecten en haal vervolgens de effectieve waarden opnieuw op.

**Wat gebeurt er als een eigenschap niet is ingesteld op vormniveau, noch in de lay‑out/masters, noch in globale instellingen?**

De effectieve waarde wordt bepaald door het standaardmechanisme, dat de standaardinstellingen van PowerPoint en Aspose.Slides omvat. Die opgeloste waarde wordt onderdeel van de huidige effectieve gegevens.

**Kan ik aan de hand van een effectieve lettertype‑waarde zien op welk niveau de grootte of het lettertype is bepaald?**

Niet rechtstreeks. Effectieve gegevens geven alleen de uiteindelijke waarde terug. Om de bron te vinden, controleert u de lokale waarden op gedeelte, alinea, tekstkader en tekststijlen op lay‑out-, master‑ en presentatieniveau om te zien waar de eerste expliciete definitie voorkomt.

**Waarom lijken effectieve waarden soms identiek aan de lokale waarden?**

Omdat de lokale waarde uiteindelijk definitief was (er was geen hogere erfelijkheid nodig). In zulke gevallen komt de effectieve waarde overeen met de lokale waarde.

**Wanneer moet ik effectieve eigenschappen gebruiken en wanneer alleen lokale?**

Gebruik effectieve gegevens wanneer u het “zoals gerenderd” resultaat nodig heeft na toepassing van alle erfelijkheid, bijvoorbeeld om kleuren, inspringingen of groottes uit te lijnen. Als u die waarden wilt behouden ongeacht latere opmaakwijzigingen, kopieer dan de vereiste eigenschappen naar uw eigen object. Als u op een specifiek niveau de opmaak wilt wijzigen, pas dan de lokale eigenschappen aan en lees, indien nodig, de effectieve gegevens opnieuw om het resultaat te verifiëren.