---
title: Effectieve vormeigenschappen ophalen uit presentaties in Java
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/java/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtinstallatie
- bevel-vorm
- tekstframe
- tekststijl
- letterhoogte
- opvulopmaak
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides for Java effectieve vormeigenschappen berekent en toepast voor nauwkeurige weergave in PowerPoint."
---
## **Overzicht**

Dit onderwerp legt het verschil uit tussen **lokale** en **effectieve** eigenschappen. Lokale waarden zijn waarden die direct op een specifiek opmaakniveau worden ingesteld, zoals:

1. Portie‑eigenschappen op een dia.
1. Prototype‑vormtekststijlen op een lay‑out‑ of mastersdia, wanneer de vorm van het tekstframe van de portie er één heeft.
1. Globale tekstopmaakinstellingen in een presentatie.

Lokale waarden kunnen op elk niveau worden gedefinieerd of weggelaten. Wanneer Aspose.Slides de uiteindelijke “zoals weergegeven” opmaak nodig heeft, doorloopt het de overervingsketen en retourneert **effectieve** waarden. Je kunt ze verkrijgen door de `getEffective`‑methode aan te roepen op het lokale opmaakobject.

Het volgende voorbeeld laat zien hoe je effectieve waarden kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) met een tekstframe en ten minste één portie is.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
Effectieve opmaakgegevens vertegenwoordigen de momenteel berekende opmaak nadat overerving is toegepast. In de huidige implementatie kunnen sommige effectieve gegevensobjecten, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPortionFormatEffectiveData), intern worden gecached. Het opnieuw aanroepen van `getEffective` nadat ouder‑ of geërfde opmaak is gewijzigd, kan de cache vernieuwen, en een eerder verkregen object vertegenwoordigt mogelijk niet langer de eerdere staat. Als je effectieve waarden later opnieuw wilt gebruiken, kopieer dan de benodigde eigenschappen, zoals letterhoogte, vulkleur, lettertype‑stijl of uitlijning, naar je eigen gegevensobject.
{{% /alert %}}

## **Effectieve eigenschappen van een camera**

Aspose.Slides stelt je in staat om effectieve eigenschappen van een camera op te halen. Het [ICameraEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICameraEffectiveData)-interface vertegenwoordigt een onveranderlijk object dat effectieve camera‑eigenschappen bevat. Een [ICameraEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICameraEffectiveData)-instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IThreeDFormatEffectiveData), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IThreeDFormat).

De volgende code‑voorbeeld toont hoe je effectieve eigenschappen voor de camera kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Effectieve eigenschappen van een lichtrig**

Aspose.Slides stelt je in staat om effectieve eigenschappen van een lichtrig op te halen. Het [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ILightRigEffectiveData)-interface vertegenwoordigt een onveranderlijk object dat effectieve lichtrig‑eigenschappen bevat. Een [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ILightRigEffectiveData)-instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IThreeDFormatEffectiveData), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IThreeDFormat).

De volgende code‑voorbeeld toont hoe je effectieve eigenschappen voor het lichtrig kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Effectieve eigenschappen van een bevelvorm**

Aspose.Slides stelt je in staat om effectieve eigenschappen van een bevelvorm op te halen. Het [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeBevelEffectiveData)-interface vertegenwoordigt een onveranderlijk object dat effectieve vlak‑relief‑eigenschappen voor een vorm bevat. Een [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeBevelEffectiveData)-instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IThreeDFormatEffectiveData), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IThreeDFormat).

De volgende code‑voorbeeld toont hoe je effectieve eigenschappen voor de bovenste bevel van een vorm kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Effectieve eigenschappen van een tekstframe**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekstframe ophalen. Het [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextFrameFormatEffectiveData)‑interface bevat effectieve opmaak‑eigenschappen van een tekstframe.

De volgende code‑voorbeeld toont hoe je effectieve tekstframe‑opmaak‑eigenschappen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) met een tekstframe is.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Effectieve eigenschappen van een tekststijl**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekststijl ophalen. Het [ITextStyleEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextStyleEffectiveData)‑interface bevat effectieve tekststijl‑eigenschappen.

De volgende code‑voorbeeld toont hoe je effectieve tekststijl‑eigenschappen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) met een tekstframe is.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Krijg de effectieve letterhoogte‑waarde**

Met Aspose.Slides kun je de effectieve letterhoogte verkrijgen. De volgende code demonstreert hoe de effectieve letterhoogte van een portie verandert nadat lokale letterhoogte‑waarden op verschillende niveaus van de presentatiestructuur zijn ingesteld.

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

## **Effectief opvulformaat voor een tabel ophalen**

Met Aspose.Slides kun je effectieve opvulopmaak verkrijgen voor verschillende tabelonderdelen. Het [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IFillFormatEffectiveData)‑interface bevat effectieve opvulopmaak‑eigenschappen. Celopmaak heeft een hogere prioriteit dan rij‑opmaak, rij‑opmaak heeft een hogere prioriteit dan kolom‑opmaak, en kolom‑opmaak heeft een hogere prioriteit dan de opmaak van de volledige tabel.

Als gevolg hiervan worden de eigenschappen van [ICellFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICellFormatEffectiveData) gebruikt om de tabelcel te tekenen. De volgende code‑voorbeeld toont hoe je effectieve opvulopmaak voor verschillende tabelonderdelen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [ITable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITable) is.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Retourneert `getEffective` een momentopname?

Niet altijd. Effectieve gegevens vertegenwoordigen de berekende opmaak nadat overerving is toegepast, maar sommige effectieve gegevensobjecten kunnen intern worden gecached. Een volgende `getEffective`‑aanroep kan de opmaak opnieuw berekenen en de cache verversen, zodat een eerder verkregen object niet als een permanente momentopname moet worden beschouwd.

### Wanneer moet ik de effectieve eigenschappen opnieuw lezen?

Roep `getEffective` opnieuw aan nadat je lokale opmaak, bovenliggende stijlen, lay‑out‑opmaak, master‑opmaak of de standaardinstellingen van de presentatie hebt gewijzigd. De volgende aanroep evalueert de opmaakhiërarchie opnieuw en retourneert het actuele effectieve resultaat.

### Heeft het wijzigen of verwijderen van een lay‑out‑/mastersdia invloed op reeds opgehaalde effectieve eigenschappen?

Ja, maar de wijziging wordt pas zichtbaar bij de volgende `getEffective`‑aanroep. Als een bovenliggende opmaakbron wordt gewijzigd of verwijderd, kan eerder verkregen effectieve data verouderd raken. Zodra `getEffective` opnieuw wordt aangeroepen, herwaardeert Aspose.Slides de opmaakboom en kunnen de resulterende lettertypen, kleuren, groottes of andere waarden veranderen.

### Kan ik waarden aanpassen via effectieve gegevensobjecten?

Nee. Effectieve gegevensobjecten geven alleen berekende waarden weer. Breng wijzigingen aan in de lokale opmaakobjecten en haal daarna opnieuw de effectieve waarden op.

### Wat gebeurt er als een eigenschap niet is ingesteld op vormniveau, noch in de lay‑out/masters, noch in de globale instellingen?

De effectieve waarde wordt bepaald door het standaardmechanisme, dat de standaardinstellingen van PowerPoint en Aspose.Slides omvat. Die opgeloste waarde wordt onderdeel van de huidige effectieve gegevens.

### Kan ik aan de hand van een effectieve letterwaarde zien welk niveau de grootte of het lettertype heeft geleverd?

Niet rechtstreeks. Effectieve gegevens geven de uiteindelijke waarde terug. Om de bron te vinden, controleer je de lokale waarden op portie‑, alinea‑, tekstframe‑ en tekstopmaak‑niveaus in de lay‑out, master en presentatie om te zien waar de eerste expliciete definitie voorkomt.

### Waarom lijken effectieve waarden soms identiek aan de lokale waarden?

Omdat de lokale waarde uiteindelijk definitief bleek te zijn (geen hoger‑niveau er boven nodig was). In dat geval komt de effectieve waarde overeen met de lokale.

### Wanneer moet ik effectieve eigenschappen gebruiken en wanneer alleen met lokale werken?

Gebruik effectieve gegevens wanneer je het “zoals weergegeven” resultaat nodig hebt nadat alle overerving is toegepast, bijvoorbeeld om kleuren, inspringingen of groottes op elkaar af te stemmen. Als je deze waarden wilt behouden ongeacht latere opmaakwijzigingen, kopieer dan de benodigde eigenschappen naar je eigen object. Als je op een specifiek niveau de opmaak wilt aanpassen, wijzig dan de lokale eigenschappen en lees, indien nodig, de effectieve gegevens opnieuw om het resultaat te verifiëren.