---
title: Effectieve vormeigenschappen ophalen uit presentaties op Android
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/androidjava/shape-effective-properties/
keywords:
- vormeigenschappen
- cameraeigenschappen
- lichtrig
- afgeschuinde vorm
- tekstvak
- tekststijl
- letterhoogte
- opvulformaat
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Android via Java effectieve vormeigenschappen berekent en toepast voor nauwkeurige PowerPoint-weergave."
---
## **Overzicht**

Deze onderwerp legt het verschil uit tussen **lokale** en **effectieve** eigenschappen. Lokale waarden zijn waarden die direct op een specifiek opmaakniveau worden ingesteld, zoals:

1. Deel‑eigenschappen op een dia.
1. Prototype‑vormtekststijlen op een lay‑out‑ of mastersdia, wanneer de vorm van het tekstvak van het deel er één heeft.
1. Globale tekstopmaakinstellingen in een presentatie.

Lokale waarden kunnen op elk niveau worden gedefinieerd of weggelaten. Wanneer Aspose.Slides de uiteindelijke "as rendered"‑opmaak nodig heeft, lost het de erfenisketen op en retourneert **effectieve** waarden. Je kunt ze verkrijgen door de `getEffective()`‑methode aan te roepen op het lokale opmaakobject.

Het volgende voorbeeld toont hoe je effectieve waarden kunt krijgen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) is met een tekstvak en minstens één deel.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Effectieve opmaakgegevens vertegenwoordigen de momenteel berekende opmaak nadat erfenis is toegepast. In de huidige implementatie kunnen sommige effectieve gegevensobjecten, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportionformateffectivedata/), intern worden gecached. Het opnieuw aanroepen van `getEffective()` na het wijzigen van ouder‑ of geërfde opmaak kan de cache vernieuwen, en een eerder verkregen object vertegenwoordigt mogelijk niet meer de eerdere staat. Als je effectieve waarden wilt behouden voor later hergebruik, kopieer dan de benodigde eigenschappen, zoals letterhoogte, opvulkleur, lettertype‑stijl of uitlijning, naar je eigen gegevensobject.
{{% /alert %}}

## **Effectieve eigenschappen van een camera ophalen**

Aspose.Slides maakt het mogelijk om effectieve eigenschappen van een camera op te halen. De [ICameraEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icameraeffectivedata/) interface vertegenwoordigt een onveranderlijk object dat effectieve camera‑eigenschappen bevat. Een [ICameraEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icameraeffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformateffectivedata/), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/).

De volgende codevoorbeelden tonen hoe je effectieve eigenschappen voor de camera kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Effectieve eigenschappen van een verlichtingsrig ophalen**

Aspose.Slides maakt het mogelijk om effectieve eigenschappen van een licht‑rig op te halen. De [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilightrigeffectivedata/) interface vertegenwoordigt een onveranderlijk object dat effectieve licht‑rig‑eigenschappen bevat. Een [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilightrigeffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformateffectivedata/), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/).

De volgende codevoorbeelden tonen hoe je effectieve eigenschappen voor het licht‑rig kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Effectieve eigenschappen van een afgeschuinde vorm ophalen**

Aspose.Slides maakt het mogelijk om effectieve eigenschappen van een vorm‑afschuining op te halen. De [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapebeveleffectivedata/) interface vertegenwoordigt een onveranderlijk object dat effectieve oppervlak‑reliefs‑eigenschappen voor een vorm bevat. Een [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapebeveleffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformateffectivedata/), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/).

De volgende codevoorbeelden tonen hoe je effectieve eigenschappen voor de bovenste afschuining van een vorm kunt verkrijgen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Effectieve eigenschappen van een tekstvak ophalen**

Met Aspose.Slides kun je effectieve eigenschappen van een tekstvak ophalen. De [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformateffectivedata/) interface bevat effectieve opmaak‑eigenschappen van een tekstvak.

De volgende codevoorbeelden tonen hoe je effectieve opmaak‑eigenschappen van een tekstvak kunt verkrijgen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) met een tekstvak is.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Effectieve eigenschappen van een tekststijl ophalen**

Met Aspose.Slides kun je effectieve eigenschappen van een tekststijl ophalen. De [ITextStyleEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextstyleeffectivedata/) interface bevat effectieve tekststijl‑eigenschappen.

De volgende codevoorbeelden tonen hoe je effectieve tekststijl‑eigenschappen kunt verkrijgen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) met een tekstvak is.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **De effectieve letterhoogte‑waarde ophalen**

Met Aspose.Slides kun je de effectieve letterhoogte ophalen. De volgende code demonstreert hoe de effectieve letterhoogte van een deel verandert nadat lokale letterhoogte‑waarden op verschillende niveaus van de presentatiestructuur zijn ingesteld.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Effectief opvulformaat van een tabel ophalen**

Met Aspose.Slides kun je effectieve opvulopmaak voor verschillende tabelonderdelen verkrijgen. De [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifillformateffectivedata/) interface bevat effectieve opvulopmaak‑eigenschappen. Cel‑opmaak heeft een hogere prioriteit dan rij‑opmaak, rij‑opmaak heeft een hogere prioriteit dan kolom‑opmaak, en kolom‑opmaak heeft een hogere prioriteit dan opmaak voor de hele tabel.

Als gevolg hiervan worden de eigenschappen van [ICellFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icellformateffectivedata/) gebruikt om de tabelcel te tekenen. De volgende codevoorbeelden tonen hoe je effectieve opvulopmaak voor verschillende tabelonderdelen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itable/) is.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Geeft `getEffective()` een momentopname terug?**

Nee, niet altijd. Effectieve gegevens vertegenwoordigen de berekende opmaak nadat erfenis is toegepast, maar sommige effectieve gegevensobjecten kunnen intern gecached worden. Een volgende `getEffective()`‑aanroep kan de opmaak opnieuw berekenen en de cache vernieuwen, waardoor een eerder verkregen object niet als een persistente momentopname moet worden beschouwd.

**Wanneer moet ik de effectieve eigenschappen opnieuw lezen?**

Roep `getEffective()` opnieuw aan nadat je lokale opmaak, ouder‑stijlen, lay‑out‑opmaak, master‑opmaak of de standaardinstellingen op presentatieniveau hebt gewijzigd. De volgende aanroep evalueert de opmaakhiërarchie opnieuw en retourneert het huidige effectieve resultaat.

**Heeft het wijzigen of verwijderen van een lay‑out‑/masterdia invloed op reeds opgehaalde effectieve eigenschappen?**

Ja, maar de wijziging wordt pas zichtbaar bij de volgende `getEffective()`‑aanroep. Als een ouder‑opmaakbron wordt gewijzigd of verwijderd, kan eerder verkregen effectieve data verouderd zijn. Zodra `getEffective()` opnieuw wordt aangeroepen, evalueert Aspose.Slides de opmaakboom opnieuw en kunnen de resulterende lettertypen, kleuren, groottes of andere waarden wijzigen.

**Kan ik waarden wijzigen via effectieve gegevensobjecten?**

Nee. Effectieve gegevensobjecten geven berekende waarden weer. Breng wijzigingen aan in de lokale opmaakobjecten en haal vervolgens opnieuw de effectieve waarden op.

**Wat gebeurt er als een eigenschap niet is ingesteld op vormeniveau, noch in de lay‑out/master, noch in de globale instellingen?**

De effectieve waarde wordt bepaald door het standaardmechanisme, dat zowel de standaarden van PowerPoint als die van Aspose.Slides omvat. Die afgevoerde waarde wordt onderdeel van de huidige effectieve gegevens.

**Kan ik aan de hand van een effectieve lettertype‑waarde zien op welk niveau de grootte of het lettertype is vastgesteld?**

Nee, niet rechtstreeks. Effectieve gegevens geven de uiteindelijke waarde terug. Om de bron te achterhalen, controleer je de lokale waarden op het deel, de alinea, het tekstvak en de tekststijlen op lay‑out-, master‑ en presentatieniveau om te zien waar de eerste expliciete definitie voorkomt.

**Waarom lijken effectieve waarden soms identiek aan de lokale waarden?**

Omdat de lokale waarde uiteindelijk definitief was (er was geen hoger‑niveau‑erfenis nodig). In dat geval komt de effectieve waarde overeen met de lokale waarde.

**Wanneer moet ik effectieve eigenschappen gebruiken en wanneer alleen met lokale werken?**

Gebruik effectieve gegevens wanneer je het "as rendered"‑resultaat nodig hebt nadat alle erfenis is toegepast, bijvoorbeeld om kleuren, inspringingen of groottes uit te lijnen. Als je die waarden wilt behouden, ongeacht latere opmaakwijzigingen, kopieer dan de benodigde eigenschappen naar je eigen object. Als je op een specifiek niveau de opmaak wilt wijzigen, pas dan de lokale eigenschappen aan en lees vervolgens, indien nodig, de effectieve gegevens opnieuw om het resultaat te verifiëren.