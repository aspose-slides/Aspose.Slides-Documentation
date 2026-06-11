---
title: Hämta effektiva egenskaper för former från presentationer i JavaScript
linktitle: Effektiva egenskaper
type: docs
weight: 50
url: /sv/nodejs-java/shape-effective-properties/
keywords:
- formegenskaper
- kameraregenskaper
- ljusrigg
- fasningsform
- textram
- textstil
- teckenhöjd
- fyllningsformat
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Node.js via Java beräknar och tillämpar effektiva formegenskaper för exakt PowerPoint-rendering."
---
## **Översikt**

Det här ämnet förklarar skillnaden mellan **lokala** och **effektiva** egenskaper. Lokala värden är värden som sätts direkt på en specifik formateringsnivå, såsom:

1. Segmentegenskaper på en bild.
1. Prototypformers textstilar på en layout eller huvudbild, när segmentets textramarform har en.
1. Globala textinställningar i en presentation.

Lokala värden kan definieras eller utelämnas på vilken nivå som helst. När Aspose.Slides behöver den slutgiltiga "som renderad" formateringen, löser den arvskedjan och returnerar **effektiva** värden. Du kan få dem genom att anropa `getEffective`-metoden på det lokala formatobjektet.

Följande exempel visar hur man får effektiva värden. Det förutsätter att den första formen på den första bilden är en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) med en textram och minst ett segment.

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
Effektiv formateringsdata representerar den aktuella beräknade formateringen efter att arv har tillämpats. I den nuvarande implementeringen kan vissa effektiva dataobjekt cachelagras internt. Att anropa `getEffective` igen efter att ha ändrat förälder- eller ärvd formatering kan uppdatera den cachade datan, och ett tidigare hämtat objekt kanske inte längre representerar det tidigare tillståndet. Om du behöver bevara effektiva värden för senare återanvändning, kopiera de nödvändiga egenskaperna, såsom teckenhöjd, fyllningsfärg, teckensnittsstil eller justering, till ditt eget dataobjekt.
{{% /alert %}}

## **Hämta effektiva egenskaper för en kamera**

Aspose.Slides låter dig hämta effektiva egenskaper för en kamera. Det effektiva kamera-dataobjektet innehåller oföränderliga kameraegenskaper och exponeras via de effektiva värden som returneras för [ThreeDFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/).

Följande kodexempel visar hur man får effektiva egenskaper för kameran. Det förutsätter att den första formen på den första bilden har 3D-formatering.

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

## **Hämta effektiva egenskaper för en ljusrigg**

Aspose.Slides låter dig hämta effektiva egenskaper för en ljusrigg. Det effektiva ljusriggs-dataobjektet innehåller oföränderliga ljusriggs-egenskaper och exponeras via de effektiva värden som returneras för [ThreeDFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/).

Följande kodexempel visar hur man får effektiva egenskaper för ljusriggen. Det förutsätter att den första formen på den första bilden har 3D-formatering.

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

## **Hämta effektiva egenskaper för en fasningsform**

Aspose.Slides låter dig hämta effektiva egenskaper för en formavfasning. Det effektiva dataobjektet för formavfasning innehåller oföränderliga ytreliefsegenskaper för en form och exponeras via de effektiva värden som returneras för [ThreeDFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/).

Följande kodexempel visar hur man får effektiva egenskaper för den övre avfasningen av en form. Det förutsätter att den första formen på den första bilden har 3D-formatering.

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

## **Hämta effektiva egenskaper för en textram**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textram. Det returnerade effektiva dataobjektet innehåller formateringsegenskaper för textramen.

Följande kodexempel visar hur man får effektiva formateringsegenskaper för en textram. Det förutsätter att den första formen på den första bilden är en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) med en textram.

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

## **Hämta effektiva egenskaper för en textstil**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textstil. Det returnerade effektiva dataobjektet innehåller egenskaper för textstilen.

Följande kodexempel visar hur man får effektiva egenskaper för en textstil. Det förutsätter att den första formen på den första bilden är en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) med en textram.

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

## **Hämta det effektiva teckenhöjdsvärdet**

Med Aspose.Slides kan du hämta den effektiva teckenhöjden. Följande kod visar hur en segments effektiva teckenhöjd förändras efter att lokala teckenhöjdsvärden har satts på olika nivåer i presentationsstrukturen.

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

## **Hämta den effektiva fyllningsformatet för en tabell**

Med Aspose.Slides kan du hämta effektiv fyllningsformatering för olika tabelldelar. Det returnerade effektiva dataobjektet innehåller fyllningsformaterings-egenskaper. Cellformatering har högre prioritet än radformatering, radformatering har högre prioritet än kolumnformatering, och kolumnformatering har högre prioritet än tabellens hela formatering.

Som ett resultat används de effektiva cellformaterings-egenskaperna för att rita tabellcellen. Följande kodexempel visar hur man får effektiv fyllningsformatering för olika tabelldelar. Det förutsätter att den första formen på den första bilden är en [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/table/).

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

## **Vanliga frågor**

**Returnerar `getEffective` ett ögonblicksavtryck?**

Inte alltid. Effektiva data representerar den beräknade formateringen efter att arv har tillämpats, men vissa effektiva dataobjekt kan cachelagras internt. Ett efterföljande anrop av `getEffective` kan omberäkna formateringen och uppdatera den cachade datan, så ett tidigare erhållet objekt bör inte betraktas som ett bestående ögonblicksavtryck.

**När bör jag läsa de effektiva egenskaperna igen?**

Anropa `getEffective` igen efter att ha ändrat lokal formatering, förälderstilar, layout-formatering, huvud-formatering eller standardinställningar på presentationsnivå. Nästa anrop utvärderar format-hierarkin på nytt och returnerar det aktuella effektiva resultatet.

**Påverkar ändring eller borttagning av en layout-/huvudbild de effektiva egenskaper som redan har hämtats?**

Ja, men förändringen reflekteras vid nästa anrop av `getEffective`. Om en föräldrakälla för formatering ändras eller tas bort kan tidigare hämtade effektiva data vara föråldrade. När `getEffective` anropas igen utvärderar Aspose.Slides format-trädet på nytt och de resulterande typsnitten, färgerna, storlekarna eller andra värden kan förändras.

**Kan jag ändra värden via effektiva dataobjekt?**

Nej. Effektiva dataobjekt visar beräknade värden. Gör ändringar i de lokala formateringsobjekten och hämta sedan de effektiva värdena igen.

**Vad händer om en egenskap inte är angiven på formnivå, i layout-/huvudbild eller i globala inställningar?**

Det effektiva värdet bestäms av standardmekanismen, som inkluderar standardinställningarna i PowerPoint och Aspose.Slides. Det resolved värdet blir en del av de aktuella effektiva data.

**Kan jag utifrån ett effektivt typsnittsvärde se vilken nivå som angav storleken eller teckensnittet?**

Inte direkt. Effektiva data returnerar det slutgiltiga värdet. För att hitta källan, kontrollera lokala värden på segment, stycke, textram och textstilar på layout-, huvud- och presentationsnivå för att se var den första explicita definitionen finns.

**Varför ser effektiva värden ibland identiska ut med de lokala?**

Eftersom det lokala värdet blev det slutgiltiga (ingen högre nivå av arv krävdes). I sådana fall matchar det effektiva värdet det lokala.

**När bör jag använda effektiva egenskaper och när bör jag arbeta enbart med lokala?**

Använd effektiva data när du behöver resultatet "som renderas" efter att all arv har tillämpats, till exempel för att justera färger, indrag eller storlekar. Om du vill bevara dessa värden oavsett framtida format‑ändringar, kopiera de nödvändiga egenskaperna till ditt eget objekt. Om du behöver ändra formatering på en specifik nivå, modifiera de lokala egenskaperna och läs sedan, vid behov, de effektiva data igen för att verifiera resultatet.