---
title: Hämta effektiva formsegenskaper från presentationer på Android
linktitle: Effektiva egenskaper
type: docs
weight: 50
url: /sv/androidjava/shape-effective-properties/
keywords:
- formsegenskaper
- kamerasegenskaper
- ljusanordning
- snedkantad form
- textram
- textstil
- teckenhöjd
- fyllningsformat
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Android via Java beräknar och tillämpar effektiva formsegenskaper för exakt PowerPoint-rendering."
---
## **Översikt**

Detta ämne förklarar skillnaden mellan **lokala** och **effektiva** egenskaper. Lokala värden är värden som sätts direkt på en specifik formateringsnivå, till exempel:

1. Portionsegenskaper på en bild.
1. Prototypformens textstilar på en layout‑ eller masterbild, när portionsens textram har en.
1. Globala textinställningar i en presentation.

Lokala värden kan definieras eller utelämnas på vilken nivå som helst. När Aspose.Slides behöver den slutgiltiga “som renderad” formateringen, löser den ärvningskedjan och returnerar **effektiva** värden. Du kan få dem genom att anropa metoden `getEffective()` på det lokala formatobjektet.

Följande exempel visar hur man hämtar effektiva värden. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) med en textram och minst en portion.

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
Effektiv formateringsdata representerar den aktuella beräknade formateringen efter att arv har tillämpats. I den nuvarande implementationen kan vissa effektiva dataobjekt, såsom [IPortionFormatEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportionformateffectivedata/), cachas internt. Att anropa `getEffective()` igen efter att ha ändrat föräldra‑ eller ärvd formatering kan uppdatera den cachade datan, och ett tidigare hämtat objekt kanske inte längre representerar det tidigare tillståndet. Om du behöver bevara effektiva värden för senare återanvändning, kopiera de nödvändiga egenskaperna, såsom teckenhöjd, fyllnadsfärg, teckenstil eller justering, till ditt eget dataobjekt.
{{% /alert %}}

## **Hämta effektiva egenskaper för en kamera**

Aspose.Slides låter dig hämta effektiva egenskaper för en kamera. Gränssnittet [ICameraEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icameraeffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva kameraegenskaper. En [ICameraEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icameraeffectivedata/) instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/).

Följande kodexempel visar hur man får effektiva egenskaper för kameran. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

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

## **Hämta effektiva egenskaper för en ljusanordning**

Aspose.Slides låter dig hämta effektiva egenskaper för en ljusanordning. Gränssnittet [ILightRigEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilightrigeffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva ljusanordningsegenskaper. En [ILightRigEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilightrigeffectivedata/) instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/).

Följande kodexempel visar hur man får effektiva egenskaper för ljusanordningen. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

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

## **Hämta effektiva egenskaper för en snedkantad form**

Aspose.Slides låter dig hämta effektiva egenskaper för en formavfasning. Gränssnittet [IShapeBevelEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapebeveleffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva ytrelief‑egenskaper för en form. En [IShapeBevelEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapebeveleffectivedata/) instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/).

Följande kodexempel visar hur man får effektiva egenskaper för den övre avfasningen av en form. Det förutsätter att den första formen på den första bilden har 3D‑formatering.

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

## **Hämta effektiva egenskaper för en textram**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textram. Gränssnittet [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframeformateffectivedata/) innehåller effektiva formateringsegenskaper för textram.

Följande kodexempel visar hur man får effektiva formateringsegenskaper för textram. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) med en textram.

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

## **Hämta effektiva egenskaper för en textstil**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textstil. Gränssnittet [ITextStyleEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextstyleeffectivedata/) innehåller effektiva egenskaper för textstil.

Följande kodexempel visar hur man får effektiva egenskaper för textstil. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) med en textram.

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

## **Hämta det effektiva teckenhöjdsvärdet**

Med Aspose.Slides kan du hämta den effektiva teckenhöjden. Följande kod visar hur en portions effektiva teckenhöjd förändras efter att lokala teckenhöjdsvärden har ställts in på olika nivåer i presentationens struktur.

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

## **Hämta den effektiva fyllnadsformatet för en tabell**

Med Aspose.Slides kan du hämta effektiv fyllningsformatering för olika delar av en tabell. Gränssnittet [IFillFormatEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifillformateffectivedata/) innehåller effektiva egenskaper för fyllningsformatering. Cellformatering har högre prioritet än radformatering, radformatering har högre prioritet än kolumnformatering, och kolumnformatering har högre prioritet än hela tabellens formatering.

Som ett resultat används [ICellFormatEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icellformateffectivedata/)‑egenskaper för att rita tabellcellen. Följande kodexempel visar hur man hämtar effektiv fyllningsformatering för olika tabelldelar. Det förutsätter att den första formen på den första bilden är en [ITable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itable/).

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

## **Vanliga frågor**

### Returnerar `getEffective()` en ögonblicksbild?

Inte alltid. Effektiva data representerar den beräknade formateringen efter att arv har tillämpats, men vissa effektiva dataobjekt kan cachas internt. ett efterföljande anrop av `getEffective()` kan omberäkna formateringen och uppdatera den cachade datan, så ett tidigare hämtat objekt bör inte behandlas som en beständig ögonblicksbild.

### När bör jag läsa effektiva egenskaper igen?

Anropa `getEffective()` igen efter att du ändrat lokal formatering, föräldra‑stilar, layout‑formatering, master‑formatering eller standardinställningar på presentationsnivå. nästa anrop utvärderar formateringshierarkin på nytt och returnerar det aktuella effektiva resultatet.

### Påverkar förändring eller borttagning av en layout-/masterslide redan hämtade effektiva egenskaper?

Ja, men förändringen syns först vid nästa anrop av `getEffective()`. Om en föräldra‑formateringskälla ändras eller tas bort kan tidigare hämtade effektiva data vara föråldrade. När `getEffective()` anropas igen utvärderar Aspose.Slides formatsträdet på nytt och de resulterande teckensnitten, färgerna, storlekarna eller andra värden kan förändras.

### Kan jag modifiera värden via effektiva dataobjekt?

Nej. Effektiva dataobjekt visar beräknade värden. Gör ändringar i de lokala formateringsobjekten och hämta sedan de effektiva värdena igen.

### Vad händer om en egenskap inte är satt på formnivå, varken i layout/master eller i globala inställningar?

Det effektiva värdet bestäms av standardmekanismen, som inkluderar PowerPoint‑ och Aspose.Slides‑standardvärden. Det lösta värdet blir en del av de aktuella effektiva data.

### Kan jag från ett effektivt teckenvärde avgöra vilken nivå som tillhandahöll storleken eller typsnittet?

Inte direkt. Effektiva data returnerar det slutgiltiga värdet. För att hitta källan, kontrollera de lokala värdena på portions‑, paragraf‑, textram‑nivå samt textstilar på layout‑, master‑ och presentationsnivå för att se var den första explicita definitionen finns.

### Varför ser effektiva värden ibland identiska ut som de lokala?

Eftersom det lokala värdet blev det slutgiltiga (ingen ärvning från högre nivå behövdes). I sådana fall matchar det effektiva värdet det lokala.

### När bör jag använda effektiva egenskaper, och när bör jag bara arbeta med lokala?

Använd effektiva data när du behöver resultatet ”som renderas” efter att all ärvning har tillämpats, till exempel för att matcha färger, indrag eller storlekar. Om du behöver bevara dessa värden oavsett senare formatändringar, kopiera de nödvändiga egenskaperna till ditt eget objekt. Om du behöver ändra formatering på en specifik nivå, modifiera de lokala egenskaperna och läs sedan, vid behov, de effektiva data igen för att verifiera resultatet.