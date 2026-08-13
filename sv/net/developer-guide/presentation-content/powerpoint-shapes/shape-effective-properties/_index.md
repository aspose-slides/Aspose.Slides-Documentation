---
title: Hämta effektiva formegenskaper från presentationer i .NET
linktitle: Effektiva egenskaper
type: docs
weight: 50
url: /sv/net/shape-effective-properties/
keywords:
- formegenskaper
- kamerategenskaper
- ljusrigg
- avfasad form
- textram
- textstil
- teckenhöjd
- fyllningsformat
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för .NET beräknar och tillämpar effektiva formegenskaper för exakt PowerPoint-rendering."
---
## **Översikt**

Detta ämne förklarar skillnaden mellan **lokala** och **effektiva** egenskaper. Lokala värden är värden som anges direkt på en specifik formateringsnivå, såsom:

1. Portionsegenskaper på en bild.
1. Prototypformens textstilar på en layout eller masterbild, när portionens textramshap har en.
1. Globala textinställningar i en presentation.

Lokala värden kan definieras eller utelämnas på vilken nivå som helst. När Aspose.Slides behöver den slutgiltiga "as rendered"-formateringen, löser den arvskedjan och returnerar **effektiva** värden. Du kan hämta dem genom att anropa `GetEffective`-metoden på det lokala formatobjektet.

Följande exempel visar hur man får effektiva värden. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) med en textram och minst en portion.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
Effektiva formateringsdata representerar den aktuella beräknade formateringen efter att arv har tillämpats. I den nuvarande implementeringen kan vissa effektiva dataobjekt, såsom [IPortionFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformateffectivedata/), cachelagras internt. Att anropa `GetEffective` igen efter att ha ändrat föräldra- eller ärvd formatering kan uppdatera den cachade datan, och ett tidigare hämtat objekt kanske inte längre representerar det tidigare tillståndet. Om du behöver bevara effektiva värden för senare återanvändning, kopiera de nödvändiga egenskaperna, såsom teckenhöjd, fyllningsfärg, teckenstil eller justering, till ditt eget dataobjekt.
{{% /alert %}}

## **Hämta effektiva egenskaper för en kamera**

Aspose.Slides låter dig hämta effektiva egenskaper för en kamera. Gränssnittet [ICameraEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/icameraeffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva kamerapropertyer. En [ICameraEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/icameraeffectivedata/) instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/).

Följande kodexempel visar hur man får effektiva egenskaper för kameran. Det förutsätter att den första formen på den första bilden har 3D-formatering.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Hämta effektiva egenskaper för en ljusrigg**

Aspose.Slides låter dig hämta effektiva egenskaper för en ljusrigg. Gränssnittet [ILightRigEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ilightrigeffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva egenskaper för ljusriggen. En [ILightRigEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ilightrigeffectivedata/) instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/).

Följande kodexempel visar hur man får effektiva egenskaper för ljusriggen. Det förutsätter att den första formen på den första bilden har 3D-formatering.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Hämta effektiva egenskaper för en avfasad form**

Aspose.Slides låter dig hämta effektiva egenskaper för en avfasad form. Gränssnittet [IShapeBevelEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapebeveleffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva egenskaper för en formavfasning. En [IShapeBevelEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapebeveleffectivedata/) instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/).

Följande kodexempel visar hur man får effektiva egenskaper för den övre avfasningen av en form. Det förutsätter att den första formen på den första bilden har 3D-formatering.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Hämta effektiva egenskaper för en textram**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textram. Gränssnittet [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformateffectivedata/) innehåller effektiva formateringsegenskaper för textram.

Följande kodexempel visar hur man får effektiva formateringsegenskaper för textram. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) med en textram.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Hämta effektiva egenskaper för en textstil**

Med Aspose.Slides kan du hämta effektiva egenskaper för en textstil. Gränssnittet [ITextStyleEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/itextstyleeffectivedata/) innehåller effektiva egenskaper för textstil.

Följande kodexempel visar hur man får effektiva egenskaper för textstil. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) med en textram.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Hämta det effektiva teckenhöjdsvärdet**

Med Aspose.Slides kan du hämta den effektiva teckenhöjden. Följande kod demonstrerar hur en portions effektiva teckenhöjd ändras efter att lokala teckenhöjdsvärden ställts in på olika nivåer i presentationsstrukturen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Hämta den effektiva fyllningsformatet för en tabell**

Med Aspose.Slides kan du hämta effektiv fyllningsformatering för olika tabelldelar. Gränssnittet [IFillFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ifillformateffectivedata/) innehåller effektiva fyllningsformateringsegenskaper. Cellformatering har högre prioritet än radformatering, radformatering har högre prioritet än kolumnformatering, och kolumnformatering har högre prioritet än hela tabellens formatering.

Som ett resultat används [ICellFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/icellformateffectivedata/) egenskaper för att rita tabellcellen. Följande kodexempel visar hur man får effektiv fyllningsformatering för olika tabelldelar. Det förutsätter att den första formen på den första bilden är en [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/).

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **FAQ**

### Returnerar `GetEffective` en ögonblicksbild?

Inte alltid. Effektiva data representerar den beräknade formateringen efter att arv har tillämpats, men vissa effektiva dataobjekt kan cachelagras internt. Ett efterföljande anrop av `GetEffective` kan omräkna formateringen och uppdatera den cachade datan, så ett tidigare erhållet objekt bör inte behandlas som en beständig ögonblicksbild.

### När bör jag läsa effektiva egenskaper igen?

Anropa `GetEffective` igen efter att ha ändrat lokal formatering, förälderstilar, layoutformatering, masterformatering eller standardinställningar på presentationsnivå. Nästa anrop utvärderar formateringshierarkin på nytt och returnerar det aktuella effektiva resultatet.

### Påverkar ändring eller borttagning av en layout/master‑bild de effektiva egenskaper som redan har hämtats?

Ja, men förändringen reflekteras först vid nästa `GetEffective`-anrop. Om en förälder‑formateringskälla ändras eller tas bort kan tidigare erhållna effektiva data vara föråldrade. När `GetEffective` anropas igen utvärderar Aspose.Slides formateringsträdet på nytt och de resulterande teckensnitten, färgerna, storlekarna eller andra värden kan förändras.

### Kan jag modifiera värden genom effektiva dataobjekt?

Nej. Effektiva dataobjekt exponerar endast beräknade värden. Gör ändringar i de lokala formateringsobjekten och hämta sedan de effektiva värdena igen.

### Vad händer om en egenskap inte är inställd på formnivå, inte i layout/master och inte i globala inställningar?

Det effektiva värdet bestäms av standardmekanismen, som inkluderar PowerPoint‑ och Aspose.Slides‑standardvärden. Det lösta värdet blir en del av de aktuella effektiva data.

### Kan jag från ett effektivt teckenvärde avgöra vilken nivå som tillhandahöll storleken eller typsnittet?

Inte direkt. Effektiva data returnerar bara det slutgiltiga värdet. För att hitta källan, kontrollera de lokala värdena på portion, stycke, textram och textstilar på layout-, master‑ och presentationsnivå för att se var den första explicita definitionen finns.

### Varför ser effektiva värden ibland exakt likadana ut som de lokala?

För att det lokala värdet visade sig vara det slutgiltiga (ingen högre‑nivå‑ärvd värde behövdes). I sådana fall matchar det effektiva värdet det lokala.

### När bör jag använda effektiva egenskaper och när bör jag bara arbeta med lokala?

Använd effektiva data när du behöver resultatet \"as rendered\" efter att all ärvning har tillämpats, t.ex. för att matcha färger, indrag eller storlekar. Om du behöver bevara dessa värden oavsett framtida formateringsändringar, kopiera de behövda egenskaperna till ditt eget objekt. Om du vill ändra formatering på en specifik nivå, modifiera de lokala egenskaperna och läs sedan de effektiva data igen om du vill verifiera resultatet.