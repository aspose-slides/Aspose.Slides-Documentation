---
title: Hämta effektiva formategenskaper för former från presentationer i Java
linktitle: Effektiva egenskaper
type: docs
weight: 50
url: /sv/java/shape-effective-properties/
keywords:
- formegenskaper
- kameraegenskaper
- ljusrigg
- kägelform
- textram
- textstil
- teckenhöjd
- fyllningsformat
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Java beräknar och tillämpar effektiva formegenskaper för exakt PowerPoint-rendering."
---
## **Översikt**

Detta ämne förklarar skillnaden mellan **lokala** och **effektiva** egenskaper. Lokala värden är värden som sätts direkt på en specifik formateringsnivå, till exempel:

1. Delsegenskaper på en bild.
1. Prototypformens textstilar på en layout‑ eller mästarbild, när delens textramhänseende har ett sådant.
1. Globala textinställningar i en presentation.

Lokala värden kan definieras eller utelämnas på någon nivå. När Aspose.Slides behöver den slutgiltiga “så som den renderas”-formateringen löser den arvskedjan och returnerar **effektiva** värden. Du kan hämta dem genom att anropa `getEffective`‑metoden på det lokala formatobjektet.

Följande exempel visar hur man får effektiva värden. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape) med en textram och minst en del.

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
Effektiv formateringsdata representerar den aktuella beräknade formateringen efter att arv har tillämpats. I den nuvarande implementeringen kan vissa effektiva dataobjekt, såsom [IPortionFormatEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPortionFormatEffectiveData), cachas internt. Att anropa `getEffective` igen efter att föräldra‑ eller ärvd formatering har ändrats kan uppdatera den cachade datan, och ett tidigare erhållet objekt kanske inte längre representerar det tidigare tillståndet. Om du behöver bevara effektiva värden för senare återanvändning, kopiera de nödvändiga egenskaperna, såsom teckenhöjd, fyllningsfärg, teckenstil eller justering, till ditt eget dataobjekt.
{{% /alert %}}

## **Hämta effektiva egenskaper för en kamera**

Aspose.Slides låter dig hämta effektiva egenskaper för en kamera. Gränssnittet [ICameraEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ICameraEffectiveData) representerar ett oförändrat objekt som innehåller effektiva kameraparametrar. En [ICameraEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ICameraEffectiveData)-instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IThreeDFormatEffectiveData), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IThreeDFormat).

Följande kodexempel visar hur man får effektiva egenskaper för kameran. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

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

## **Hämta effektiva egenskaper för en ljusrigg**

Aspose.Slides låter dig hämta effektiva egenskaper för en ljusrigg. Gränssnittet [ILightRigEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ILightRigEffectiveData) representerar ett oförändrat objekt som innehåller effektiva ljusriggegenskaper. En [ILightRigEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ILightRigEffectiveData)-instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IThreeDFormatEffectiveData), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IThreeDFormat).

Följande kodexempel visar hur man får effektiva egenskaper för ljusriggen. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

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

## **Hämta effektiva egenskaper för en kägelform**

Aspose.Slides låter dig hämta effektiva egenskaper för en formkägel. Gränssnittet [IShapeBevelEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeBevelEffectiveData) representerar ett oförändrat objekt som innehåller effektiva ytgående egenskaper för en form. En [IShapeBevelEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeBevelEffectiveData)-instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IThreeDFormatEffectiveData), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IThreeDFormat).

Följande kodexempel visar hur man får effektiva egenskaper för den övre kägelen på en form. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

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

## **Hämta effektiva egenskaper för en textram**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textram. Gränssnittet [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITextFrameFormatEffectiveData) innehåller effektiva formateringsegenskaper för textramar.

Följande kodexempel visar hur man får effektiva formateringsegenskaper för textram. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape) med en textram.

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

## **Hämta effektiva egenskaper för en textstil**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textstil. Gränssnittet [ITextStyleEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITextStyleEffectiveData) innehåller effektiva textstilegenskaper.

Följande kodexempel visar hur man får effektiva egenskaper för textstil. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape) med en textram.

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

## **Hämta den effektiva teckenhöjdsvärdet**

Med Aspose.Slides kan du hämta den effektiva teckenhöjden. Följande kod demonstrerar hur en svars effektiva teckenhöjd förändras efter att lokala teckenhöjdsvärden har satts på olika nivåer i presentationsstrukturen.

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

## **Hämta den effektiva fyllningsformatet för en tabell**

Med Aspose.Slides kan du hämta effektiv fyllningsformatering för olika tabelldelar. Gränssnittet [IFillFormatEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IFillFormatEffectiveData) innehåller effektiva fyllningsformateringsegenskaper. Cellformatering har högre prioritet än radformatering, radformatering har högre prioritet än kolumnformatering, och kolumnformatering har högre prioritet än formatering för hela tabellen.

Som resultat används [ICellFormatEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ICellFormatEffectiveData)-egenskaper för att rita tabellcellen. Följande kodexempel visar hur man får effektiv fyllningsformatering för olika tabelldelar. Det förutsätter att den första formen på den första bilden är en [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable).

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

### Returnerar `getEffective` ett ögonblicksbild?

Inte alltid. Effektiv data representerar den beräknade formateringen efter att arv har tillämpats, men vissa effektiva dataobjekt kan cachas internt. Ett efterföljande anrop av `getEffective` kan omberäkna formateringen och uppdatera den cachade datan, så ett tidigare erhållet objekt bör inte betraktas som en beständig ögonblicksbild.

### När bör jag läsa effektiva egenskaper igen?

Anropa `getEffective` igen efter att du ändrat lokal formatering, föräldra‑stilar, layout‑formatering, mästar‑formatering eller presentations‑standardvärden. Nästa anrop utvärderar formateringshierarkin på nytt och returnerar det aktuella effektiva resultatet.

### Påverkar ändring eller borttagning av en layout/mästarbild effektiva egenskaper som redan har hämtats?

Ja, men förändringen syns först vid nästa `getEffective`‑anrop. Om en föräldrakälla för formatering ändras eller tas bort kan tidigare erhållen effektiv data bli föråldrad. När `getEffective` anropas igen utvärderar Aspose.Slides formaträdet på nytt och de resulterande tecknen, färgerna, storlekarna eller andra värden kan förändras.

### Kan jag modifiera värden via effektiva dataobjekt?

Nej. Effektiva dataobjekt exponerar beräknade värden. Gör ändringar i de lokala formateringsobjekten och hämta sedan de effektiva värdena igen.

### Vad händer om en egenskap inte är satt på formnivå, varken i layout/mästar eller i globala inställningar?

Det effektiva värdet bestäms av standardmekanismen, som inkluderar PowerPoint‑ och Aspose.Slides‑standardvärden. Det lösta värdet blir en del av den aktuella effektiva datan.

### Kan jag utifrån ett effektivt teckenvärde se vilken nivå som tillhandahöll storleken eller teckensnittet?

Inte direkt. Effektiv data returnerar det slutgiltiga värdet. För att hitta källan, kontrollera lokala värden på del, stycke, textram och textstilar på layout‑, mästar‑ och presentationsnivå för att se var den första explicita definitionen förekommer.

### Varför ser effektiva värden ibland identiska ut som de lokala?

För att det lokala värdet blev det slutgiltiga (ingen högre‑nivåers arv behövdes). I sådana fall matchar det effektiva värdet det lokala.

### När bör jag använda effektiva egenskaper, och när bör jag bara arbeta med lokala?

Använd effektiv data när du behöver resultatet “så som det renderas” efter att allt arv har tillämpats, exempelvis för att synkronisera färger, indrag eller storlekar. Om du vill bevara dessa värden oavsett senare formateringsändringar, kopiera de nödvändiga egenskaperna till ditt eget objekt. Om du behöver ändra formatering på en specifik nivå, modifiera lokala egenskaper och läs sedan, om så behövs, den effektiva datan igen för att verifiera resultatet.