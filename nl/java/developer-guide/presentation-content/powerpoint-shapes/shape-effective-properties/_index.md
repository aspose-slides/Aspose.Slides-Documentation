---
title: Effectieve vormeigenschappen ophalen uit presentaties in Java
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/java/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtinrichting
- schuine vorm
- tekstvak
- tekstopmaak
- letterhoogte
- vulindeling
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides for Java effectieve vormeigenschappen berekent en toepast voor nauwkeurige PowerPoint-weergave."
---
## **Overzicht**

Dit onderwerp legt het verschil uit tussen **lokale** en **effectieve** eigenschappen. Lokale waarden zijn waarden die rechtstreeks op een specifiek opmaakniveau zijn ingesteld, bijvoorbeeld:

1. Deel‑eigenschappen op een dia.
1. Prototype‑vorm‑tekststijlen op een indeling of master‑dia, wanneer de tekstvak‑vorm van het deel er één heeft.
1. Globale tekstinstellingen in een presentatie.

Lokale waarden kunnen op elk niveau worden gedefinieerd of weggelaten. Wanneer Aspose.Slides de uiteindelijke “zoals gerenderd” opmaak nodig heeft, lost het de overervingsketen op en retourneert **effectieve** waarden. Je kunt ze ophalen door de `getEffective`‑methode aan te roepen op het lokale opmaakobject.

Het volgende voorbeeld laat zien hoe je effectieve waarden kunt verkrijgen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) is met een tekstvak en minstens één deel.

```java
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

{{% alert color="primary" %}}

Effectieve opmaakdata vertegenwoordigt de huidig berekende opmaak nadat er erfelijkheid is toegepast. In de huidige implementatie kunnen sommige effectieve data‑objecten, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPortionFormatEffectiveData), intern worden gecached. Een tweede aanroep van `getEffective` na het wijzigen van de bovenliggende of geërfde opmaak kan de cache vernieuwen, en een eerder verkregen object vertegenwoordigt mogelijk niet meer de eerdere toestand. Als je effectieve waarden later opnieuw wilt gebruiken, kopieer dan de benodigde eigenschappen, zoals lettergrootte, vulkleur, lettertype‑stijl of uitlijning, naar je eigen data‑object.

{{% /alert %}}

## **Effectieve eigenschappen van een camera ophalen**

Aspose.Slides stelt je in staat om de effectieve eigenschappen van een camera op te halen. De [ICameraEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICameraEffectiveData)‑interface vertegenwoordigt een onmutable object dat effectieve cameragegevens bevat. Een [ICameraEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICameraEffectiveData)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IThreeDFormatEffectiveData), die effectieve waarden voor [IThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IThreeDFormat) levert.

De volgende code‑voorbeeld laat zien hoe je effectieve eigenschappen van de camera kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```java
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

## **Effectieve eigenschappen van een lichtinrichting ophalen**

Aspose.Slides stelt je in staat om de effectieve eigenschappen van een lichtinrichting op te halen. De [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ILightRigEffectiveData)‑interface vertegenwoordigt een onmutable object dat effectieve lichtinrichtings‑eigenschappen bevat. Een [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ILightRigEffectiveData)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IThreeDFormatEffectiveData), die effectieve waarden voor [IThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IThreeDFormat) biedt.

De volgende code‑voorbeeld laat zien hoe je effectieve eigenschappen van de lichtinrichting kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```java
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

## **Effectieve eigenschappen van een schuine vorm ophalen**

Aspose.Slides stelt je in staat om de effectieve eigenschappen van een vormschuine (bevel) op te halen. De [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeBevelEffectiveData)‑interface vertegenwoordigt een onmutable object dat effectieve hoek‑relief‑eigenschappen voor een vorm bevat. Een [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeBevelEffectiveData)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IThreeDFormatEffectiveData), die effectieve waarden voor [IThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IThreeDFormat) levert.

De volgende code‑voorbeeld toont hoe je effectieve eigenschappen van de bovenste bevel van een vorm kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```java
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

## **Effectieve eigenschappen van een tekstvak ophalen**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekstvak ophalen. De [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextFrameFormatEffectiveData)‑interface bevat effectieve tekstvak‑opmaak‑eigenschappen.

De volgende code‑voorbeeld laat zien hoe je effectieve tekstvak‑opmaak‑eigenschappen kunt verkrijgen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) is met een tekstvak.

```java
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

## **Effectieve eigenschappen van een tekstopmaak ophalen**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekstopmaak ophalen. De [ITextStyleEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITextStyleEffectiveData)‑interface bevat effectieve tekstopmaak‑eigenschappen.

De volgende code‑voorbeeld laat zien hoe je effectieve tekstopmaak‑eigenschappen kunt verkrijgen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) is met een tekstvak.

```java
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

## **Effectieve vulopmaak voor een tabel ophalen**

Met Aspose.Slides kun je effectieve vulopmaak ophalen voor verschillende tabelonderdelen. De [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IFillFormatEffectiveData)‑interface bevat effectieve vulopmaak‑eigenschappen. Cel‑opmaak heeft een hogere prioriteit dan rij‑opmaak, rij‑opmaak heeft een hogere prioriteit dan kolom‑opmaak, en kolom‑opmaak heeft een hogere prioriteit dan opmaak voor de gehele tabel.

Als gevolg hiervan worden de eigenschappen van [ICellFormatEffectiveData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICellFormatEffectiveData) gebruikt om de tabelcel te tekenen. De volgende code‑voorbeeld laat zien hoe je effectieve vulopmaak voor verschillende tabelonderdelen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [ITable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITable) is.

```java
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

## **Veelgestelde vragen**

**Retourneert `getEffective` een momentopname?**

Niet altijd. Effectieve data vertegenwoordigt de berekende opmaak nadat erfelijkheid is toegepast, maar sommige effectieve data‑objecten kunnen intern worden gecached. Een volgende aanroep van `getEffective` kan de opmaak opnieuw berekenen en de cache vernieuwen, waardoor een eerder verkregen object niet als een duurzame momentopname mag worden beschouwd.

**Wanneer moet ik effectieve eigenschappen opnieuw lezen?**

Roep `getEffective` opnieuw aan nadat je lokale opmaak, bovenliggende stijlen, indelings‑opmaak, master‑opmaak of presentatie‑standaardinstellingen hebt gewijzigd. De volgende aanroep herziet de opmaakhiërarchie en retourneert het actuele effectieve resultaat.

**Heeft het wijzigen of verwijderen van een indeling/master‑dia invloed op reeds opgehaalde effectieve eigenschappen?**

Ja, maar de wijziging wordt zichtbaar bij de volgende `getEffective`‑aanroep. Als een bron van bovenliggende opmaak wordt gewijzigd of verwijderd, kunnen eerder verkregen effectieve data verouderd zijn. Zodra `getEffective` opnieuw wordt aangeroepen, evalueert Aspose.Slides de opmaakboom opnieuw en kunnen lettertypes, kleuren, afmetingen of andere waarden veranderen.

**Kan ik waarden wijzigen via effectieve data‑objecten?**

Nee. Effectieve data‑objecten exposeren berekende waarden. Breng wijzigingen aan in de lokale opmaakobjecten en haal daarna de effectieve waarden opnieuw op.

**Wat gebeurt er als een eigenschap niet is ingesteld op vormniveau, noch in de indeling/master, noch in globale instellingen?**

De effectieve waarde wordt bepaald door het standaardmechanisme, dat de standaardinstellingen van PowerPoint en Aspose.Slides omvat. Die berekende waarde maakt deel uit van de huidige effectieve data.

**Kan ik aan de hand van een effectieve letterwaarde afleiden op welk niveau de grootte of het lettertype is gedefinieerd?**

Niet rechtstreeks. Effectieve data geeft de uiteindelijke waarde terug. Om de bron te vinden, controleer je de lokale waarden op het deel, de alinea, het tekstvak en de tekststijlen op indelings‑, master‑ en presentatieniveau om te zien waar de eerste expliciete definitie voorkomt.

**Waarom lijken effectieve waarden soms identiek aan de lokale waarden?**

Omdat de lokale waarde uiteindelijk de definitieve waarde bleek te zijn (er was geen hogere‑niveau‑erfenis nodig). In dat geval komt de effectieve waarde overeen met de lokale.

**Wanneer moet ik effectieve eigenschappen gebruiken en wanneer alleen lokale?**

Gebruik effectieve data wanneer je het “zoals gerenderd” resultaat nodig hebt na toepassing van alle erfelijkheid, bijvoorbeeld om kleuren, inspringingen of afmetingen uit te lijnen. Als je die waarden wilt behouden, ongeacht latere opmaakwijzigingen, kopieer je de benodigde eigenschappen naar je eigen object. Als je op een specifiek niveau de opmaak wilt wijzigen, pas dan de lokale eigenschappen aan en lees desgewenst de effectieve data opnieuw om het resultaat te verifiëren.