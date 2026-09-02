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
description: "Lär dig hur du använder Aspose.Slides för .NET för att särskilja lokal, ärvd och effektiv formatering av former i PowerPoint-presentationer."
---
## **Förstå lokala, ärvda och effektiva egenskaper**

PowerPoint-formatering kan komma från flera platser. Värdet som lagras direkt på ett objekt är dess **lokala värde**. Om det värdet inte är angivet söker PowerPoint i föräldraformateringskällor, såsom ett standardvärde för stycke, en textstil, en layout‑ eller mastern slide, ett tema eller standardinställningar på presentationsnivå. Dessa värden är **ärvda värden**. Värdet som återstår efter att hela hierarkin har lösts är **effektivt värde** — värdet som används för att rendera objektet.

Till exempel kanske en textdel inte definierar sin egen teckenhöjd. Dess lokala [FontHeight](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/fontheight/) är då `float.NaN`, vilket betyder "inte angivet här." Delen kan ärva en höjd från sitt stycke, presentationens standard‑textstil eller en annan tillämplig källa. Att anropa [GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformat/geteffective/) på delens format returnerar den slutgiltigt lösta höjden.

Använd de två typerna av formateringsdata för olika ändamål:

- Läs eller ändra ett lokalt formatobjekt, till exempel [IPortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformat/), när du behöver kontrollera var ett värde definieras.
- Läs ett effektivt dataobjekt, till exempel [IPortionFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformateffectivedata/), när du behöver det slutgiltiga, renderade resultatet. Effektiva data är skrivskyddade.

## **Jämför lokala, ärvda och effektiva värden**

Följande kompletta exempel skapar en form och tillämpar teckenhöjder på presentations-, stycke- och delnivå. Varje steg skriver ut de värden som definierats på dessa nivåer och det resulterande effektiva värdet för samma textdel. Det visar också varför effektiv data måste läsas igen efter formateringsändringar.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Definiera ärvda värden på två olika nivåer.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Ett lokalt värde på delen åsidosätter båda ärvda värden.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Att ändra ett ärvt värde överskrider inte ett befintligt lokalt värde.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Rensa det lokala värdet. Delen ärver nu återigen från stycket.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Rensa styckets värde. Presentationens standardvärde levererar nu resultatet.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Läs effektiv data efter föregående ändringar.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

Prioriteten i detta exempel är delens lokala formatering, därefter styckeformatering och slutligen presentationsstandard. Andra objekt kan ha olika arvs kedjor, men principen är densamma: ett mer specifikt explicit värde vinner, och [GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformat/geteffective/) returnerar det slutgiltiga resultatet.

## **Hämta effektiva textegenskaper**

Textformatering är uppdelad över flera objekt:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/geteffective/) löser text‑ramegenskaper såsom marginaler, förankring, autofit och vertikal textorientering.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/sv/net/aspose.slides/itextstyle/geteffective/) löser styckeformatering för varje textstilsnivå.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/geteffective/) löser styckegenskaper såsom justering, indrag och punktlistor.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/sv/net/aspose.slides/iportionformat/geteffective/) löser teckengegenskaper såsom teckenhöjd, typsnitt, färg, fetstil och kursiv.

För nästa exempel måste `text-formatting.pptx` innehålla minst en bild och en [AutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/) med en icke‑tom textram. AutoShape kan ligga på vilken position som helst i formsamlingen; koden söker efter ett lämpligt objekt och validerar det innan användning.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Hämta effektiva 3D‑egenskaper**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/geteffective/) returnerar ett [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformateffectivedata/)‑objekt som samlar alla lösta 3D‑inställningar. Dess [Camera](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformateffectivedata/beveltop/) och [BevelBottom](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) egenskaper visar motsvarande effektiv data. Att läsa dessa relaterade inställningar tillsammans gör det enklare att förstå den slutgiltiga 3D‑utseendet på en form.

För detta exempel måste `shape-3d.pptx` innehålla minst en form på sin första bild. Tillämpa 3D‑kamera, belysning eller avfasningsinställningar på den formen om du vill att utdata ska innehålla andra värden än standardvärdena.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Hämta effektiv tabellformatering**

Tabellformatering kan komma från tabellstilen samt från format som tillämpas på hela tabellen, en kolumn, en rad eller en enskild cell. Vid konflikter mellan explicit definierade fyllningar är prioriteten cell, rad, kolumn och därefter hela tabellen. Den effektiva formaten för en cell är det slutgiltiga format som används för att rita cellen.

För detta exempel måste `table-formatting.pptx` innehålla minst en tabell på sin första bild. Tabellen måste ha minst en rad och en kolumn. Koden söker efter ett [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/) istället för att anta att `Shapes[0]` är en tabell.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Om du behöver färgen snarare än bara fyllningstypen, kontrollera först den effektiva [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/ifillformateffectivedata/filltype/), och läs sedan egenskapen som gäller för den typen — till exempel [SolidFillColor](https://reference.aspose.com/slides/sv/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) för en solid fyllning.

## **Läs effektiv data på nytt efter ändringar**

Effektiv data beskriver formateringshierarkin vid den tidpunkt den lösts. Anropa `GetEffective` igen efter att ha ändrat något som kan delta i den hierarkin, inklusive:

- objektets lokala formatering;
- standardvärden för stycke eller textram;
- en tabellstil, tabell, kolumn, rad eller cellformat;
- layout‑ eller mastern‑slide‑formatering;
- temadata eller standardvärden på presentationsnivå;
- layouten eller mastern som tilldelats en slide.

Behåll inte ett effektivt dataobjekt som en permanent avbildning. Aspose.Slides kan cachelagra viss effektiv data internt, och ett senare anrop av `GetEffective` kan uppdatera den datan. Om du behöver jämföra värden före och efter en ändring, kopiera de skalära värden du behöver — till exempel teckenhöjd, färg, justering eller avfasningsbredd — till dina egna variabler innan du gör ändringen.

För att ändra ett värde, uppdatera det lämpliga lokala formatobjektet och anropa sedan `GetEffective` för att verifiera resultatet. Effektiva dataobjekt är i sig skrivskyddade.

## **FAQ**

**Hur kan jag avgöra vilken nivå som levererade ett effektivt värde?**

Effektiv data innehåller det slutgiltiga värdet, inte dess källa. Inspektera de tillämpliga lokala objekten från den mest specifika nivån och utåt. För text kan detta inkludera delen, stycket, textramen, layouten, mastern, temat och presentationsstandarderna. Odefinierade värden såsom `float.NaN` eller `null` indikerar att sökningen fortsätter på en annan nivå.

**Vad händer när ingen nivå definierar en egenskap?**

Aspose.Slides löser den lämpliga PowerPoint‑ eller biblioteksstandardvärdet. Det lösta värdet visas i den effektiva data även om inget lokalt objekt explicit definierar det.

**Varför kan ett effektivt värde ibland vara lika med det lokala värdet?**

Det lokala värdet vann arvberäkningen. Detta är förväntat när egenskapen är explicit angiven på objektet och ingen mer specifik regel åsidosätter den.

**När bör jag använda lokala data istället för effektiva data?**

Använd lokala data för att inspektera eller redigera en specifik formateringsnivå. Använd effektiva data när du behöver den slutgiltiga utseendet efter arv, temaregelverk och tillämpliga stilar har lösts. Det [kompletta jämförelseexemplet](#compare-local-inherited-and-effective-values) demonstrerar båda i samma arbetsflöde.