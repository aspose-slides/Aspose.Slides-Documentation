---
title: Formatera PowerPoint‑former i .NET
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/net/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss‑effekt
- skisslinje för form
- formatera fogstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- solid färgfyllning
- formtransparens
- svart‑vit formrendering
- gråskala formrendering
- rotera form
- 3D‑fasadeffekt
- 3D‑rotereffekt
- återställ formatering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i C# med Aspose.Slides—sätt fyllnings-, linje‑ och effektstilar för PPT‑ och PPTX‑filer med precision och full kontroll."
---
## **Introduktion**

Formatera former i PowerPoint genom att justera deras konturer, fyllningar och effekter. Aspose.Slides för .NET låter dig kontrollera dessa inställningar programmässigt, inklusive transparens, rotation och 3D-formatering.

![Formateringsalternativ för former i PowerPoint](format-shape-powerpoint.png)

Aspose.Slides för .NET tillhandahåller gränssnitt och egenskaper som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Använd [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) för att styra en formes kontur. Detta exempel skapar en oifylld rektangel med en blå, streckad kontur. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) väljer en tjock‑tunn kombinationslinje, medan [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) sätter dess bredd till 7 punkter och [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) väljer dash‑mönstret.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

### **Ange anpassade dash‑mönster för linjer**

Använd [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) när fördefinierade linjestilar inte tillhandahåller de dash‑längder och mellanrum du behöver, till exempel för varumärkeskonturer eller tekniska diagram. Att tilldela ett mönster sätter automatiskt [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) till [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

Array‑poster alternerar mellan dash‑ och gap‑längder, med dash först. Varje värde är en multipel av linjebredden: `{ 4, 2 }` vid en bredd på 3 punkter ger ett 12‑punkts dash följt av ett 6‑punkts gap. Använd par av ändliga, icke‑negativa värden för att definiera kompletta dash‑och‑gap‑segment. Exemplet använder positiva värden för att hålla varje dash och gap synliga.

Detta exempel skapar fem blå linjer med samma längd och platta ändar. De tre första jämför mönster vid en bredd på 3 punkter. Den fjärde upprepar det första mönstret med dubbel bredd, vilket fördubblar både dash‑ och gap‑längderna. Den femte växlar från ett anpassat mönster till en solid linje.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Återställ den sista linjen till en solid stil.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

För att återgå till en fördefinierad streckad stil, tilldela [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) till [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). Den valda stilen styr linjens utseende.

Resultatet i PowerPoint, från topp till botten: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; och **Solid, 3 pt**.

![Tre anpassade dash‑mönster, en bredare linje som använder det första mönstret, och en solid linje i PowerPoint](custom-dash-patterns.png)


### **Ställ in linjeändar**

Använd [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) för att definiera ändarna på en öppen linje. [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/)-enumerationen erbjuder tre explicita ändstilar:

- `Flat`: Stöket slutar vid slutpunkten.
- `Round`: En halvcirkelformad ändelse sträcker sig bortom slutpunkten med halva linjebredden.
- `Square`: En fyrkantig ändelse sträcker sig bortom slutpunkten med halva linjebredden.

Enumerationen innehåller även `NotDefined`, vilket betyder att ingen ändstil är explicit tilldelad.

Ändar skiljer sig från pilspetsar, som lägger till symboler i linjeändarna, och fogar, som styr hörnen mellan linjesegment. Detta exempel inaktiverar pilspetsar via [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) och [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) så att endast ändformer jämförs.

Följande exempel skapar tre i övrigt identiska horisontella linjer, 20 punkter breda. Från topp till botten använder de platta, runda och fyrkantiga ändar. Deras slutpunkter har samma horisontella koordinater; de runda och fyrkantiga ändarna sträcker sig 10 punkter bortom varje slutpunkt.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

Resultatet i PowerPoint, från topp till botten: **Flat**, **Round** och **Square**.

![Platta, runda och fyrkantiga ändar på identiska tjocka linjer i PowerPoint](line-caps.png)

## **Tillämpa skiss‑effekter på formens linjer**

En skiss‑effekt får en formlinje att se handritad ut. Använd [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) för att komma åt linjeinställningarna, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) för att komma åt skissinställningarna, och [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) för att välja ett värde från [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)-enumerationen.

Följande C#‑kod visar hur man tillämpar en [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)‑effekt, läser det explicit tilldelade värdet och tar bort effekten med [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

Värdet som returneras av [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) representerar inställningen som tilldelats direkt till formen. Om linjeformatet kan ärvas från ett tema, en master‑bild eller en layout‑bild, använd [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), åtkom [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), och läs [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Det effektiva värdet speglar den formatering som faktiskt tillämpas efter arv har lösts. Detta exempel kräver en befintlig presentation med minst en form på den första bilden och skriver ut båda värdena:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var shape = presentation.Slides[0].Shapes[0];

var lineFormat = shape.LineFormat;
var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Formatera fogstilar**

Här är de tre alternativen för fogtyp:

* Round
* Miter
* Bevel

Fogstilen styr hur två kontursegment möts vid ett hörn. Använd **Round** för avrundade hörn, **Miter** för vassa hörn, eller **Bevel** för platta hörn.

![Fogstilen i presentationen](join-style-powerpoint.png)

Detta exempel skapar tre svarta rektanglar med blå konturer 15 punkter breda. Det sätter [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) till miter-, bevel- och round‑värdena i [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/), respektive, för att jämföra hur hörnen ritas.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **Begränsa Miter-fogar vid vassa hörn**

Använd [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) med [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) satt till [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) för att begränsa hur långt ett vasst hörn kan sträcka sig.

Gränsen är ett förhållande mellan avståndet mellan det inre och yttre hörnet i fogvinkeln och linjebredden. Till exempel tillåter ett värde på `8` en miter‑längd på upp till åtta gånger linjebredden; det är ingen mätning i punkter. Om hörnet skulle överskrida gränsen använder PowerPoint en fasad fog vid det hörnet. En större gräns möjliggör vassare punkter. Inställningen påverkar endast miter-fogar, och en ändring har ingen synlig effekt när hörnet förblir inom båda gränserna.

Detta exempel skapar två identiska, oifyllda trianglar med konturer 20 punkter breda. Den vänstra triangeln använder en gräns på `2`, och den högra använder `8`. Varje triangel är 80 punkter bred och 160 punkter hög, vilket ger dess översta hörn ett miter‑längd‑till‑linjebredd‑förhållande på ungefär `4,12`. Följaktligen fasar PowerPoint det vänstra spetsen och behåller den högra spetsen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

Resultatet i PowerPoint: **Miter limit 2** till vänster och **miter limit 8** till höger.

![En fasad spets med miter‑gräns 2 och en spetsig spets med miter‑gräns 8 i PowerPoint](miter-limits.png)

## **Gradientfyllning**

En gradientfyllning blandar färger över en form. Detta exempel fyller en ellips med en linjär gradient i en 45‑gradig vinkel från rött till lila med hjälp av [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). Metoden [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) placerar färgstopp vid 0 och 1, början och slutet av gradienten. Att rensa befintliga stopp säkerställer att endast dessa två färger används.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

Resultatet:

![Ellipsen med gradientfyllning](gradient-fill.png)

Om en gradient ser annorlunda ut i en exporterad bild än i PowerPoint, se [Choose a Gradient Rendering Style](/slides/sv/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kan välja en renderingsstil utan att ändra gradientfyllningen som lagras i presentationen.

### **Ställ in vinkeln för linjär gradient**

Använd [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) för att styra orienteringen av en [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/)-fyllning. Vinkeln mäts i grader och ökar medurs: `0` går från vänster till höger, `90` från topp till botten, `180` från höger till vänster, och `270` från botten till topp. Bråkvinklar stöds. Ändliga vinklar utanför `[0, 360)` normaliseras till en hel varv; till exempel blir `-45` `315` och `360` blir `0`.

Detta exempel skapar sex rektanglar med identiska röd, grön och blå stopp på positionerna `0`, `0.5` och `1`. Skalning är inaktiverad så att vinkeln kan jämföras oberoende av rektanglarnas proportioner. Vinklarna, från vänster till höger, är `0`, `45` och `90` i den första raden, samt `135`, `180` och `270` i den andra raden.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

Resultatet i PowerPoint:

![Linjär gradient vid 0, 45 och 90 grader i översta raden, och 135, 180 och 270 grader i nedersta raden](linear-gradient-angles.png)

### **Skala en linjär gradient med formen**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) tar emot ett [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/)-värde. Sätt det explicit till `False` för att behålla den geometriska gradientvinkeln när formens proportioner ändras, eller till `True` för att skala gradienten med formens bredd och höjd. Med skalning aktiverad kan den synliga vinkeln skilja sig från den tilldelade vinkeln på en icke‑kvadratisk form.

Följande exempel använder en `45`‑gradig vinkel och samma färgstopp som vinkelför jämförelsen. Den vänstra kolumnen använder `False`; den högra kolumnen använder `True`. Varje kolumn innehåller en bred rektangel ovanför en hög rektangel. Båda börjar med samma breda dimensioner; förändring av den andra rektangelns bredd och höjd demonstrerar hur fyllningen reagerar på storleksändring utan att ändra dess gradientinställningar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

Resultatet i PowerPoint, med skalning inaktiverad till vänster och aktiverad till höger:

![Breda och höga rektanglar med en 45‑gradig gradient, jämför LinearGradientScaled False till vänster med True till höger](linear-gradient-scaling.png)

Med skalning inaktiverad behåller de diagonala färgbanden samma orientering i båda rektanglarna. Med skalning aktiverad sträcks banden med formens proportioner. Detta hjälper till att reproducera ett mallgradient när en form anpassas till en annan storlek. På en kvadrat förändras inte utseendet på denna `45`‑gradiga gradient när skalning är på.

Både vinkel‑ och skalningsinställningarna gäller för linjära gradienter. De styr inte fyllningar av [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **Kombinera vinkeln med gradientriktning**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) väljer en gradientstil från [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/)-enumerationen; den är inte en ersättning för en numerisk vinkel. För en linjär gradient kan hörnstilar ändra området där färgerna fördelas utan att ändra [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/). Behåll riktningen oförändrad när du jämför vinklar eller skalning.

Följande exempel tillämpar samma inställningar i omvänd ordning. De två rektanglarna har samma utseende: att tilldela riktningen före eller efter vinkeln förändrar inte resultatet.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **Mönsterfyllning**

En mönsterfyllning applicerar en tvåfärgsdesign, såsom prickar, ränder eller rutnät. Detta exempel använder [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) för att välja ett spalettmönster. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) ger den ljusgrå bakgrunden, och [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) ger den gula mönsterfärgen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

Resultatet:

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

En bildfyllning använder en bild inuti en form. Detta exempel kräver en lokal bild och använder [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) för att ladda den i presentationens bildsamling. Genom att sätta [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) till tiled‑läget upprepas bilden inom rektangeln. Källbilden som används här visas nedan:

![Lotus‑bilden](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

Resultatet:

![Formen med bildfyllning](picture-fill.png)

### **Tile Bild som Textur**

Om du vill ställa in en tiled bild som en textur och anpassa tile‑beteendet, kan du använda följande egenskaper i [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/)‑gränssnittet och [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/)‑klassen:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Ställer in bildfylldläge — antingen `Tile` eller `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Anger justeringen av plattorna inom formen.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Styr om plattan vänds horisontellt, vertikalt eller båda.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Ställer in horisontell förskjutning av plattan (i punkter) från formens ursprung.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Ställer in vertikal förskjutning av plattan (i punkter) från formens ursprung.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Definierar horisontell skala av plattan i procent.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Definierar vertikal skala av plattan i procent.

Detta exempel kräver en lokal bild och konfigurerar [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) för att upprepa den till 50 % av dess originalstorlek. Förskjutningar på −32 punkter flyttar plattorna horisontellt och vertikalt; justering längst ner till höger och vändning i båda riktningarna bestämmer hur den upprepade texturen organiseras.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

Resultatet:

![Tile‑alternativen](tile-options.png)

## **Solid färgfyllning**

En solid fyllning ger en form en enda, enhetlig färg. Detta exempel sätter [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) till solid‑fyllningsläge och tilldelar gult via [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/), och sparar sedan rektangeln i en presentation.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

Resultatet:

![Formen med solid färgfyllning](solid-color-fill.png)

### **Kopiera färger samtidigt som temareferenser bevaras**

Använd [IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) för att kopiera en färgdefinition, inklusive dess färgtyp, temareferens och transformationer. Detta är användbart när man överför en fyllningsfärg mellan former som ska fortsätta följa presentationens tema. Metoden kopierar endast färgen: den kopierar inte fyllningstyp, kontur eller annan formformatering. Sätt destinationens [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) explicit.

Detta exempel skapar tre rektanglar, från vänster till höger: källan, en temakännande kopia och en fast RGB‑kopia. Källan använder [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) för att referera till den första accentfärgen och lägger till en nyans via [IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/). RGB‑kopian använder källans effektiva fyllningsfärg så att alla tre initialt ser identiska ut. Tilldelning av [IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) sätter ett fast RGB‑värde och rensar eventuella befintliga färgtransformationer.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// Theme references follow the new accent color; the fixed RGB value does not.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

Innan temabytet matchar alla tre fyllningar:

![Källa, CopyFrom‑destination och fast RGB‑destination med identiska blå fyllningar](color-copy-before.png)

Efter temabytet följer källan och den temakännande kopian den nya accentfärgen och behåller sin nyans. Den fasta RGB‑kopian förblir blå:

![Källa och CopyFrom‑destination med orange fyllningar, medan den fasta RGB‑destinationen förblir blå](color-copy-after.png)

Den kopierade definitionen är oberoende av källan. Att senare ändra källans temareferens, tilldela en annan färg eller lägga till eller ta bort dess transformationer ändrar inte destinationen. Ett temabyte påverkar fortfarande båda formerna eftersom var och en refererar oberoende till samma temafärg.

Att spara och öppna PPTX igen bevarar den kopierade färgens [IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/), temareferens och [IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/)-samling; den plattar inte av definitionen till RGB.

När du kopierar mellan olika temakontexter, såsom presentationer med olika accentpaletter, löses den kopierade referensen mot destinationens tema. Samma referens och transformationer kan därför ge en annan synlig färg. Se [Presentation Theme](/slides/sv/net/presentation-theme/) för mer om att konfigurera temafärger.

## **Använd bildbakgrund som formfyllning**

Använd [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) när en form ska matcha bildbakgrunden, till exempel i en presentationsmall. Sätt [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) till [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) först för att ta bort eventuell explicit fyllning. Med denna kombination använder formen bildbakgrunden istället för sin stilfyllning. Att bara aktivera flaggan tar inte bort en befintlig explicit fyllning.

Detta skiljer sig från [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): bakgrundsfyllning täcker objekt bakom formen med motsvarande område av bildbakgrunden, medan ingen fyllning låter dessa objekt vara synliga. En gradient förblir anpassad till bilden snarare än att starta om i varje form.

Följande exempel skapar en masterbakgrund som ärvd av bilden och placerar ett magentaband bakom tre rektanglar. Den vänstra rektangeln använder bakgrunden, den mellersta rektangeln har ingen fyllning, och den högra rektangeln växlar från bakgrundsfyllning till en explicit orange fyllning.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// Ärva gradienten från mastern.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// Lägg till detta objekt först så att det visas bakom rektanglarna.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// Inaktivera bakgrundsfyllning innan en explicit fyllning appliceras.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

Resultatet, från vänster till höger: **background fill**, **no fill** och **explicit fill**. Magentabandet är dolt av de vänstra och högra rektanglarna men förblir synligt genom den mellersta rektangeln.

![Bakgrundsfyllning, ingen fyllning och explicit orange fyllning över ett magentaband](background-fill.png)

Samma beteende gäller för en bakgrund som definieras direkt på bilden eller ärvs från en layout. Formen använder bildens lösta bakgrund; exemplet lämnar både bildens och layoutens bakgrunder odefinierade så att master‑bakgrunden levererar den.

## **Ställ in transparens**

För en solid fyllning styr färgens alfakomponent opaciteten: 0 är helt transparent och 255 är helt opak. Detta exempel använder ett alfavärde på 128 för en gul rektangel, vilket gör den ungefär 50 % transparent så att rektangeln under förblir synlig. Färgen tilldelas via [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Använd [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) för att rotera en form i bildplanet. Vinkeln mäts i grader; detta exempel roterar en rektangel 5 grader medurs och sparar presentationen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

![Formens rotation](shape-rotation.png)

## **Lägg till 3D‑fasadeffekter**

Använd [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) för att ge en form djup och fasade kanter. Detta exempel skapar en grön ellips med orange kontur, sätter [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) till 4 punkter, och applicerar en cirkulär top‑bevel med bredd och höjd på 6 punkter via [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). En framåtriktad ortografisk kamera och tre‑punkts belysning gör fasen synlig.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

![3D‑fasadeffekten](3D-bevel-effect.png)

## **Lägg till 3D‑rotereffekter**

En forms 3D‑vy styrs av dess kamerainställningar. Detta exempel använder [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) med latitud, longitud och rotationsvinklar på 40, 35 och 20 grader. Det väljer en isometrisk kamera via [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) och balanserad belysning via [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), och sparar sedan den formaterade rektangeln.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

![3D‑rotereffekten](3D-rotation-effect.png)

## **Styr svart‑vit rendering för former**

[IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/)‑egenskapen specificerar hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vit läge. Den aktiverar inte svart‑vit visning i sig och ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/)‑enumerationen för att välja önskat beteende. Till exempel låter `Automatic` renderingsprogrammet välja konverteringen, `Gray` och `LightGray` använder grå färgning, `BlackWhite` använder endast svart och vitt, `Black` och `White` tvingar en enda färg, `Color` bevarar normal färgning, och `Hidden` utelämnar formen i svart‑vit läge. `NotDefined` betyder att inget form‑nivå läge har tilldelats.

Detta exempel skapar en orange rektangel och sätter [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) till gray. Den sparade formen behåller sin orange fyllning för normal färgvisning och begär grå färgning från applikationer som respekterar svart‑vit visningsinställningar:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

I normalt färgläge behåller rektangeln sin orange fyllning. I ett svart‑vit arbetsflöde använder den grå färgning eftersom dess läge är satt till `Gray`. Detta låter dig bevara en fullfärgsbild samtidigt som du definierar ett tydligt utseende för utskrift, förhandsgranskning eller andra arbetsflöden som respekterar presentationens svart‑vita visningsinställningar.

## **Återställ formatering**

Använd [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) för att återställa position, storlek och formatering av bildplatshållare från deras motsvarande layout‑platshållare. Detta exempel kräver en befintlig presentation med layout‑länkade platshållare och återställer varje bild innan den sparas. Former utan motsvarande layout‑platshållare återställs inte.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Påverkar formatering av former den slutliga presentationsfilens storlek?**

Färger, linjestilar och effektinställningar tillför generellt sett lite data jämfört med inbäddade bilder och media. Bildfyllningar kan öka filstorleken eftersom deras bilder lagras i presentationen.

**Hur kan jag identifiera former på en bild som delar identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckelformaterings‑egenskaper — fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, betraktas deras stilar som identiska och du kan logiskt gruppera dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall‑bildspel eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de formaterade former du behöver och återapplicera deras formatering där det krävs.