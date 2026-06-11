---
title: Hämta effektiva egenskaper för former från presentationer i .NET
linktitle: Effektiva egenskaper
type: docs
weight: 50
url: /sv/net/shape-effective-properties/
keywords:
- formegenskaper
- kameraegenskaper
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

Detta ämne förklarar skillnaden mellan **lokala** och **effektiva** egenskaper. Lokala värden är värden som sätts direkt på en specifik formateringsnivå, såsom:

1. Egenskaper för en textdel på en bild.
1. Prototypformens textstilar på en layout‑ eller masterns bild, när textramformen för delen har en.
1. Globala textinställningar i en presentation.

Lokala värden kan definieras eller utelämnas på vilken nivå som helst. När Aspose.Slides behöver den slutgiltiga ”renderade” formateringen, löser den arvskedjan och returnerar **effektiva** värden. Du kan hämta dem genom att anropa metoden `GetEffective` på det lokala formatobjektet.

Följande exempel visar hur man hämtar effektiva värden. Det förutsätter att den första formen på den första bilden är en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) med en textruta och minst en textdel.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Effektiv formateringsdata representerar den aktuella beräknade formateringen efter att arv har tillämpats. I den nuvarande implementeringen kan vissa effektiva dataobjekt, såsom [IPortionFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformateffectivedata/), cachas internt. Att anropa `GetEffective` igen efter att ha ändrat föräldra‑ eller ärvd formatering kan uppdatera den cachade datan, och ett tidigare hämtat objekt kanske inte längre representerar det tidigare tillståndet. Om du behöver bevara effektiva värden för senare återanvändning, kopiera de nödvändiga egenskaperna, såsom teckenhöjd, fyllningsfärg, teckenstil eller justering, till ditt eget dataobjekt.
{{% /alert %}}

## **Hämta effektiva egenskaper för en kamera**

Aspose.Slides låter dig hämta effektiva egenskaper för en kamera. Gränssnittet [ICameraEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/icameraeffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva kameraegenskaper. En [ICameraEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/icameraeffectivedata/)‑instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/).

```csharp
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

Aspose.Slides låter dig hämta effektiva egenskaper för en ljusrigg. Gränssnittet [ILightRigEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ilightrigeffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva ljusriggs‑egenskaper. En [ILightRigEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ilightrigeffectivedata/)‑instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/).

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Hämta effektiva egenskaper för en avfasad form**

Aspose.Slides låter dig hämta effektiva egenskaper för en forms avfasning. Gränssnittet [IShapeBevelEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapebeveleffectivedata/) representerar ett oföränderligt objekt som innehåller effektiva egenskaper för en forms avfasning. En [IShapeBevelEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapebeveleffectivedata/)‑instans exponeras via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformateffectivedata/), som tillhandahåller effektiva värden för [IThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/).

```csharp
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

```csharp
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

```csharp
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

Med Aspose.Slides kan du hämta den effektiva teckenhöjden. Följande kod demonstrerar hur en textsdel's effektiva teckenhöjd förändras efter att lokala teckenhöjdsvärden har satts på olika nivåer i presentationens struktur.

```csharp
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

Med Aspose.Slides kan du hämta effektiv fyllningsformatering för olika delar av en tabell. Gränssnittet [IFillFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ifillformateffectivedata/) innehåller effektiva fyllningsformateringsegenskaper. Cellformatering har högre prioritet än radformatering, radformatering har högre prioritet än kolumnformatering, och kolumnformatering har högre prioritet än hela tabellens formatering.

Som ett resultat används egenskaper från [ICellFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/icellformateffectivedata/) för att rita tabellcellen. Följande kodexempel visar hur man hämtar effektiv fyllningsformatering för olika tabelldelar. Det förutsätter att den första formen på den första bilden är en [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/).

```csharp
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

## **Vanliga frågor**

**Returnerar `GetEffective` ett ögonblicksbilder?**

Inte alltid. Effektiv data representerar den beräknade formateringen efter att arv har tillämpats, men vissa effektiva dataobjekt kan cachas internt. ett efterföljande anrop av `GetEffective` kan omberäkna formateringen och uppdatera den cachade datan, så ett tidigare hämtat objekt bör inte betraktas som en beständig ögonblicksbild.

**När bör jag läsa effektiva egenskaper igen?**

Anropa `GetEffective` igen efter att du har ändrat lokal formatering, förälderstilar, layout‑formatering, master‑formatering eller standardinställningar på presentationsnivå. nästa anrop utvärderar formateringshierarkin på nytt och returnerar det aktuella effektiva resultatet.

**Påverkar ändring eller borttagning av en layout‑/mastern bild de effektiva egenskaper som redan har hämtats?**

Ja, men förändringen visas vid nästa `GetEffective`‑anrop. Om en föräldrakälla ändras eller tas bort kan tidigare erhållen effektiv data vara föråldrad. När `GetEffective` anropas igen utvärderar Aspose.Slides formateringsträdet på nytt och de resulterande teckensnitten, färgerna, storlekarna eller andra värden kan förändras.

**Kan jag ändra värden via effektiva dataobjekt?**

Nej. Effektiva dataobjekt exponerar beräknade värden. Gör ändringar i de lokala formateringsobjekten och hämta sedan de effektiva värdena igen.

**Vad händer om en egenskap inte är angiven på formnivå, i layout/master eller i globala inställningar?**

Det effektiva värdet bestäms av standardmekanismen, som inkluderar PowerPoint‑ och Aspose.Slides‑standardinställningar. Det resolveda värdet blir en del av den aktuella effektiva datan.

**Kan jag utifrån ett effektivt teckenvärde avgöra vilken nivå som tillhandahöll storleken eller teckensnittet?**

Inte direkt. Effektiv data returnerar det slutgiltiga värdet. För att hitta källan, kontrollera lokala värden på textdelen, paragrafen, textramen och textstilarna på layout‑, master‑ och presentationsnivå för att se var den första explicita definitionen förekommer.

**Varför ser effektiva värden ibland identiska ut som de lokala?**

För att det lokala värdet visade sig bli det slutgiltiga (ingen högre nivå behövde ärvas). I sådana fall matchar det effektiva värdet det lokala värdet.

**När bör jag använda effektiva egenskaper och när bör jag bara arbeta med lokala?**

Använd effektiv data när du behöver resultatet ”som renderat” efter att all arv har tillämpats, t.ex. för att synkronisera färger, indrag eller storlekar. Om du vill bevara dessa värden oavsett senare formatändringar, kopiera de nödvändiga egenskaperna till ditt eget objekt. Om du behöver ändra formatering på en specifik nivå, modifiera de lokala egenskaperna och läs sedan den effektiva datan igen för att verifiera resultatet.