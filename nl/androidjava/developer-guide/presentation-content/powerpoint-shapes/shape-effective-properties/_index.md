---
title: Shape-effectieve eigenschappen ophalen uit presentaties op Android
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/androidjava/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtopstelling
- schuine vormrand
- tekstframe
- tekststijl
- letterhoogte
- opvulopmaak
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Android via Java effectieve shape-eigenschappen berekent en toepast voor een nauwkeurige weergave in PowerPoint."
---
## **Overzicht**

Deze pagina legt het verschil uit tussen **lokale** en **effectieve** eigenschappen. Lokale waarden zijn waarden die direct op een specifiek opmaak‑niveau worden ingesteld, zoals:

1. Portie‑eigenschappen op een dia.
2. Prototype‑vormtekststijlen op een lay‑out‑ of masterslide, wanneer de vorm van het tekstframe van de portie er een heeft.
3. Globale tekstopmaak‑instellingen in een presentatie.

Lokale waarden kunnen op elk niveau worden gedefinieerd of weggelaten. Wanneer Aspose.Slides de definitieve “as rendered”‑opmaak nodig heeft, lost het de erfelijkheidsketen op en geeft **effectieve** waarden terug. Je kunt ze verkrijgen door de `getEffective()`‑methode aan te roepen op het lokale opmaakobject.

Het volgende voorbeeld laat zien hoe je effectieve waarden kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) met een tekstframe en ten minste één portie is.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
Effectieve opmaak‑gegevens vertegenwoordigen de momenteel berekende opmaak nadat erfelijkheid is toegepast. In de huidige implementatie kunnen sommige effectieve gegevensobjecten, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportionformateffectivedata/), intern worden gecached. Het opnieuw aanroepen van `getEffective()` nadat de bovenliggende of geërfde opmaak is gewijzigd, kan de cache vernieuwen, en een eerder verkregen object vertegenwoordigt mogelijk niet meer de eerdere staat. Als je effectieve waarden later opnieuw wilt gebruiken, kopieer dan de benodigde eigenschappen, zoals letterhoogte, opvulkleur, lettertype‑stijl of uitlijning, naar je eigen gegevensobject.
{{% /alert %}}

## **Effectieve eigenschappen van een camera ophalen**

Aspose.Slides maakt het mogelijk om de effectieve eigenschappen van een camera op te halen. De [ICameraEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icameraeffectivedata/)‑interface vertegenwoordigt een onveranderlijk object dat effectieve camera‑eigenschappen bevat. Een [ICameraEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icameraeffectivedata/)‑instantie wordt blootgelegd via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformateffectivedata/), die effectieve waarden voor [IThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/) levert.

Het volgende code‑voorbeeld laat zien hoe je effectieve eigenschappen voor de camera kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```java
import com.aspose.slides.*;

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

## **Effectieve eigenschappen van een lichtopstelling ophalen**

Aspose.Slides maakt het mogelijk om de effectieve eigenschappen van een lichtopstelling op te halen. De [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilightrigeffectivedata/)‑interface vertegenwoordigt een onveranderlijk object dat effectieve licht‑opstellings‑eigenschappen bevat. Een [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilightrigeffectivedata/)‑instantie wordt blootgelegd via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformateffectivedata/), die effectieve waarden voor [IThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/) levert.

Het volgende code‑voorbeeld laat zien hoe je effectieve eigenschappen voor de lichtopstelling kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```java
import com.aspose.slides.*;

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

## **Effectieve eigenschappen van een vormschuine rand ophalen**

Aspose.Slides maakt het mogelijk om de effectieve eigenschappen van een vormschuine rand op te halen. De [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapebeveleffectivedata/)‑interface vertegenwoordigt een onveranderlijk object dat effectieve vlak‑relief‑eigenschappen voor een vorm bevat. Een [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapebeveleffectivedata/)‑instantie wordt blootgelegd via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformateffectivedata/), die effectieve waarden voor [IThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/) levert.

Het volgende code‑voorbeeld laat zien hoe je effectieve eigenschappen voor de bovenste schuine rand van een vorm kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```java
import com.aspose.slides.*;

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

## **Effectieve eigenschappen van een tekstframe ophalen**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekstframe ophalen. De [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformateffectivedata/)‑interface bevat effectieve tekstframe‑opmaak‑eigenschappen.

Het volgende code‑voorbeeld laat zien hoe je effectieve tekstframe‑opmaak‑eigenschappen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) met een tekstframe is.

```java
import com.aspose.slides.*;

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

Met Aspose.Slides kun je de effectieve eigenschappen van een tekststijl ophalen. De [ITextStyleEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextstyleeffectivedata/)‑interface bevat effectieve tekststijl‑eigenschappen.

Het volgende code‑voorbeeld laat zien hoe je effectieve tekststijl‑eigenschappen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) met een tekstframe is.

```java
import com.aspose.slides.*;

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

## **De effectieve letterhoogtewaarde ophalen**

Met Aspose.Slides kun je de effectieve letterhoogte ophalen. De volgende code toont hoe de effectieve letterhoogte van een portie verandert nadat lokale letterhoogte‑waarden op verschillende niveaus van de presentatie‑structuur zijn ingesteld.

```java
import com.aspose.slides.*;

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

## **Effectieve opvulopmaak voor een tabel ophalen**

Met Aspose.Slides kun je de effectieve opvulopmaak voor verschillende tabelonderdelen ophalen. De [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifillformateffectivedata/)‑interface bevat effectieve opvulopmaak‑eigenschappen. Cel‑opmaak heeft een hogere prioriteit dan rij‑opmaak, rij‑opmaak heeft een hogere prioriteit dan kolom‑opmaak, en kolom‑opmaak heeft een hogere prioriteit dan opmaak voor de gehele tabel.

Als gevolg hiervan worden de eigenschappen van [ICellFormatEffectiveData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icellformateffectivedata/) gebruikt om de tabelcel te tekenen. Het volgende code‑voorbeeld laat zien hoe je effectieve opvulopmaak voor verschillende tabelonderdelen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itable/) is.

```java
import com.aspose.slides.*;

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

### Geeft `getEffective()` een momentopname terug?

Niet altijd. Effectieve gegevens vertegenwoordigen de berekende opmaak nadat erfelijkheid is toegepast, maar sommige effectieve gegevensobjecten kunnen intern gecached worden. Een volgende `getEffective()`‑aanroep kan de opmaak opnieuw berekenen en de cache verversen, waardoor een eerder verkregen object niet meer als een duurzame momentopname moet worden beschouwd.

### Wanneer moet ik effectieve eigenschappen opnieuw lezen?

Roep `getEffective()` opnieuw aan nadat je lokale opmaak, bovenliggende stijlen, lay‑out‑opmaak, master‑opmaak of presentatie‑standaardinstellingen hebt gewijzigd. De volgende aanroep evalueert de opmaakhiërarchie opnieuw en geeft het huidige effectieve resultaat terug.

### Heeft het wijzigen of verwijderen van een lay‑out/master‑dia invloed op effectieve eigenschappen die al opgehaald zijn?

Ja, maar de wijziging wordt pas zichtbaar bij de volgende `getEffective()`‑aanroep. Als een bovenbron van opmaak wordt gewijzigd of verwijderd, kunnen eerder opgehaalde effectieve gegevens verouderd zijn. Zodra `getEffective()` opnieuw wordt aangeroepen, evalueert Aspose.Slides de opmaakboom opnieuw en kunnen de resulterende lettertypen, kleuren, groottes of andere waarden veranderen.

### Kan ik waarden wijzigen via effectieve gegevensobjecten?

Nee. Effectieve gegevensobjecten geven alleen berekende waarden weer. Breng wijzigingen aan in de lokale opmaakobjecten en haal vervolgens de effectieve waarden opnieuw op.

### Wat gebeurt er als een eigenschap niet is ingesteld op vorm‑niveau, noch in de lay‑out/master, noch in globale instellingen?

De effectieve waarde wordt bepaald door het standaardmechanisme, dat de standaardinstellingen van PowerPoint en Aspose.Slides omvat. Die berekende waarde wordt onderdeel van de huidige effectieve gegevens.

### Kan ik vanuit een effectieve lettertype‑waarde afleiden op welk niveau de grootte of het lettertype is vastgesteld?

Niet direct. Effectieve gegevens geven de uiteindelijke waarde terug. Om de bron te vinden, moet je de lokale waarden controleren op portie‑, alinea‑, tekstframe‑ en tekststijl‑niveau in de lay‑out, master en presentatie om te zien waar de eerste expliciete definitie voorkomt.

### Waarom lijken effectieve waarden soms identiek aan de lokale waarden?

Omdat de lokale waarde uiteindelijk de definitieve blijkt te zijn (er was geen hogere‑niveau‑erfelijkheid nodig). In dat geval komt de effectieve waarde overeen met de lokale waarde.

### Wanneer moet ik effectieve eigenschappen gebruiken en wanneer alleen met lokale werken?

Gebruik effectieve gegevens wanneer je het “as rendered”‑resultaat nodig hebt na volledige erfelijkheid, bijvoorbeeld om kleuren, inspringen of groottes uit te lijnen. Als je die waarden wilt bewaren ongeacht latere opmaakwijzigingen, kopieer dan de benodigde eigenschappen naar je eigen object. Als je op een specifiek niveau wilt formatteren, wijzig dan de lokale eigenschappen en lees, indien nodig, de effectieve gegevens opnieuw om het resultaat te verifiëren.