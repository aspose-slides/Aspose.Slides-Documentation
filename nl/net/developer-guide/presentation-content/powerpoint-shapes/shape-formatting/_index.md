---
title: PowerPoint-vormen opmaken in .NET
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/net/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schetseffect
- schets vormlijn
- aansluitstijl opmaken
- gradiëntvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart-wit vormrendering
- grijstint vormrendering
- vorm draaien
- 3D schuineffect
- 3D rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u PowerPoint‑vormen kunt opmaken in C# met Aspose.Slides—stel vullings-, lijn- en effectstijlen in voor PPT‑ en PPTX‑bestanden met precisie en volledige controle."
---
## **Inleiding**

Formateer vormen in PowerPoint door hun contouren, vullingen en effecten aan te passen. Aspose.Slides for .NET stelt u in staat deze instellingen programmatisch te beheren, inclusief transparantie, rotatie en 3D-opmaak.

![Opties voor vormopmaak in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET biedt interfaces en eigenschappen die u in staat stellen vormen te formatteren met dezelfde opties die beschikbaar zijn in PowerPoint.

## **Lijnen formatteren**

Gebruik [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) om de contour van een vorm te beheersen. Dit voorbeeld maakt een niet‑gevulde rechthoek met een blauwe, gestippelde contour. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) kiest een dikke‑dunne samengestelde lijn, terwijl [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) de breedte op 7 punten zet en [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) het streeppatroon selecteert.

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

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

### **Aangepaste lijnstreeppatronen instellen**

Gebruik [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) wanneer vooraf gedefinieerde lijnstijlen niet de gewenste streklengtes en onderbrekingen bieden, bijvoorbeeld voor merkgebonden contouren of technische diagrammen. Het toewijzen van een patroon stelt automatisch [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) in op [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

Array‑items wisselen tussen streep‑ en onderbrekingslengtes, beginnend met een streep. Elke waarde is een veelvoud van de lijndikte: `{ 4, 2 }` bij een breedte van 3 punten produceert een 12‑punt streep gevolgd door een 6‑punt onderbreking. Gebruik paren van eindige, niet‑negatieve waarden om volledige streep‑en‑onderbrekingssegmenten te definiëren. Het voorbeeld gebruikt positieve waarden om elke streep en onderbreking zichtbaar te houden.

Dit voorbeeld maakt vijf blauwe lijnen met dezelfde lengte en platte uiteinden. De eerste drie vergelijken patronen bij een breedte van 3 punten. De vierde herhaalt het eerste patroon met dubbele breedte, waardoor zowel de streep‑ als de onderbrekingslengte verdubbelt. De vijfde schakelt van een aangepast patroon naar een doorlopende lijn.

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

// Return the last line to a solid style.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Om terug te keren naar een vooraf gedefinieerde gestippelde stijl, wijs [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) toe aan [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). De geselecteerde stijl regelt het uiterlijk van de lijn.

Het resultaat in PowerPoint, van boven naar beneden: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; en **Solid, 3 pt**.

![Drie aangepaste streeppatronen, een bredere lijn die het eerste patroon gebruikt, en een doorlopende lijn in PowerPoint](custom-dash-patterns.png)

### **Lijneinden instellen**

Gebruik [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) om de uiteinden van een open lijn in te stellen. De [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/)‑enumeratie biedt drie expliciete cap‑stijlen:

- `Flat`: De lijn stopt bij het eindpunt.
- `Round`: Een halve cirkelvormige cap strekt zich uit tot halverwege de lijndikte voorbij het eindpunt.
- `Square`: Een vierkante cap strekt zich uit tot halverwege de lijndikte voorbij het eindpunt.

De enumeratie bevat ook `NotDefined`, wat betekent dat er geen cap‑stijl expliciet is toegewezen.

Caps verschillen van pijlpuntjes, die symbolen aan lijnuiteinden toevoegen, en van verbindingen, die hoeken tussen lijnsegmenten regelen. Dit voorbeeld schakelt pijlpuntjes uit via [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) en [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) zodat alleen de cap‑vormen worden vergeleken.

Het volgende voorbeeld maakt drie verder identieke horizontale lijnen, 20 punten breed. Van boven naar beneden gebruiken ze respectievelijk platte, ronde en vierkante caps. Hun eindpunten hebben dezelfde horizontale coördinaten; de ronde en vierkante caps strekken zich 10 punten voorbij elk eindpunt uit.

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

Het resultaat in PowerPoint, van boven naar beneden: **Flat**, **Round**, en **Square**.

![Platte, ronde en vierkante caps op identieke dikke lijnen in PowerPoint](line-caps.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schetseffect laat een vormlijn handgetekend lijken. Gebruik [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) om de lijninstellingen te benaderen, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) voor de schetsettings, en [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) om een waarde uit de [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)‑enumeratie te selecteren.

De onderstaande C#‑code toont hoe een [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)‑effect toe te passen, de expliciet toegewezen waarde uit te lezen, en het effect te verwijderen met [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

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

De waarde die teruggegeven wordt door [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) representeert de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak geërfd kan worden van een thema, masterslide of layoutslide, gebruik dan [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), bereik [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), en lees [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast na het oplossen van de erfenis. Dit voorbeeld vereist een bestaande presentatie met minstens één vorm op de eerste dia en drukt beide waarden af:

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

## **Aansluit‑stijlen formatteren**

Hier zijn de drie aansluit‑type opties:

* Round
* Miter
* Bevel

De aansluit‑stijl bepaalt hoe twee contoursegmenten bij een hoek elkaar ontmoeten. Gebruik **Round** voor afgeronde hoeken, **Miter** voor scherpe hoeken, of **Bevel** voor afgevlakte hoeken.

![De aansluit‑stijl in de presentatie](join-style-powerpoint.png)

Dit voorbeeld maakt drie zwarte rechthoeken met blauwe contouren van 15 punten breed. Het stelt [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) in op respectievelijk de miter-, bevel- en round‑waarden van [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) om te vergelijken hoe de hoeken worden getekend.

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

### **Miter‑aansluitingen beperken bij scherpe hoeken**

Gebruik [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) met [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) ingesteld op [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) om te beperken hoe ver een scherpe hoek kan uitstrekken.

De limiet is een verhouding tussen de afstand tussen de binnen- en buitenhoeken van de aansluiting en de lijndikte. Bijvoorbeeld, een waarde van `8` staat een miter‑lengte toe tot acht keer de lijndikte; het is geen meting in punten. Als de hoek de limiet zou overschrijden, gebruikt PowerPoint een afgevlakte aansluiting op die hoek. Een grotere limiet maakt scherpere punten mogelijk. De instelling beïnvloedt alleen miter‑aansluitingen, en een wijziging heeft geen zichtbaar effect wanneer de hoek binnen beide limieten blijft.

Dit voorbeeld maakt twee identieke, niet‑gevulde driehoeken met contouren van 20 punten breed. De linker driehoek gebruikt een limiet van `2`, en de rechter gebruikt `8`. Elke driehoek is 80 punten breed en 160 punten hoog, waardoor de bovenste hoek een miter‑lengte‑tot‑lijndikte‑verhouding van ongeveer `4.12` heeft. Daardoor vlakt PowerPoint de linkerpunt af en behoudt de rechterpunt.

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

Het resultaat in PowerPoint: **Miter limit 2** links en **miter limit 8** rechts.

![Een afgevlakt punt met miter‑limiet 2 en een puntig punt met miter‑limiet 8 in PowerPoint](miter-limits.png)

## **Gradiëntenvulling**

Een gradiëntenvulling mengt kleuren over een vorm. Dit voorbeeld vult een ellips met een lineaire gradiënt onder een hoek van 45 graad van rood naar paars met behulp van [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). De methode [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) plaatst de kleurenstops bij 0 en 1, het begin en einde van de gradiënt. Het wissen van de bestaande stops zorgt ervoor dat alleen deze twee kleuren worden gebruikt.

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

Het resultaat:

![De ellips met gradiëntenvulling](gradient-fill.png)

Als een gradiënt er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, zie [Choose a Gradient Rendering Style](/slides/nl/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). U kunt een renderingsstijl selecteren zonder de gradiëntenvulling die in de presentatie is opgeslagen te wijzigen.

### **De lineaire gradiënthoek instellen**

Gebruik [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) om de oriëntatie van een [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) vulling te regelen. De hoek wordt gemeten in graden en neemt met de klok mee toe: `0` loopt van links naar rechts, `90` van boven naar beneden, `180` van rechts naar links, en `270` van onder naar boven. Fractionele hoeken worden ondersteund. Eindige hoeken buiten `[0, 360)` worden genormaliseerd naar één omwenteling; bijvoorbeeld, `-45` wordt `315` en `360` wordt `0`.

Dit voorbeeld maakt zes rechthoeken met identieke rode, groene en blauwe stops op posities `0`, `0.5` en `1`. Schalen is uitgeschakeld zodat de hoek onafhankelijk van de verhoudingen van de rechthoeken kan worden vergeleken. De hoeken, van links naar rechts, zijn `0`, `45` en `90` in de eerste rij, en `135`, `180` en `270` in de tweede rij.

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

Het resultaat in PowerPoint:

![Lineaire gradiënten op 0, 45 en 90 graden in de bovenste rij, en 135, 180 en 270 graden in de onderste rij](linear-gradient-angles.png)

### **Een lineaire gradiënt schalen met de vorm**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) accepteert een [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) waarde. Stel deze expliciet in op `False` om de geometrische gradiënthoek te behouden terwijl de proporties van de vorm veranderen, of op `True` om de gradiënt te schalen met de breedte en hoogte van de vorm. Met scaling ingeschakeld kan de zichtbare hoek afwijken van de toegewezen hoek op een niet‑vierkante vorm.

Het volgende voorbeeld gebruikt een hoek van `45` graden en dezelfde kleurenstops als de hoekvergelijking. De linkerkolom gebruikt `False`; de rechterkolom gebruikt `True`. Elke kolom bevat een brede rechthoek boven een hoge rechthoek. Beide beginnen met dezelfde brede afmetingen; het wijzigen van de breedte en hoogte van de tweede rechthoek toont hoe de vulling reageert op schalen zonder de gradiëntinstellingen te wijzigen.

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

Het resultaat in PowerPoint, met scaling uitgeschakeld links en ingeschakeld rechts:

![Brede en hoge rechthoeken met een 45‑graden gradiënt, vergelijking LinearGradientScaled False links met True rechts](linear-gradient-scaling.png)

Met scaling uitgeschakeld behouden de diagonale kleurbanden dezelfde oriëntatie in beide rechthoeken. Met scaling ingeschakeld rekken de banden zich uit volgens de proporties van de vorm. Dit helpt om de gradiënt van een sjabloon te reproduceren bij het aanpassen van een vorm naar een andere grootte. Op een vierkant verandert het inschakelen van scaling het uiterlijk van deze `45`‑graden gradiënt niet.

Zowel de hoek‑ als scaling‑instellingen zijn van toepassing op lineaire gradiënten. Ze regelen geen [GradientShape.Radial of GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) vullingen.

### **De hoek combineren met gradiënt‑richting**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) selecteert een gradiëntstijl uit de [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/)‑enumeratie; het is geen vervanging voor een numerieke hoek. Voor een lineaire gradiënt kunnen de hoek‑stijlen het gebied waarin de kleuren worden verdeeld veranderen zonder [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) te wijzigen. Houd de richting onveranderd bij het vergelijken van hoeken of scaling.

Het volgende voorbeeld past dezelfde instellingen toe in omgekeerde volgorde. De twee rechthoeken hebben dezelfde weergave: de richting toewijzen vóór of na de hoek verandert het resultaat niet.

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

## **Patroonvulling**

Een patroonvulling past een tweekleurig ontwerp toe, zoals stippen, strepen of vakken. Dit voorbeeld gebruikt [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) om een trellis‑patroon te selecteren. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) levert de lichtgrijze achtergrond, en [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) levert de gele patroonkleur.

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

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

Een afbeeldingsvulling gebruikt een afbeelding binnen een vorm. Dit voorbeeld vereist een lokale afbeelding en gebruikt [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) om deze te laden in de afbeeldingscollectie van de presentatie. Het instellen van [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) op de tegelmodus herhaalt de afbeelding binnen de rechthoek. De bronafbeelding die hier wordt gebruikt, staat hieronder:

![De lotusafbeelding](lotus.png)

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

Het resultaat:

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding als tegeltextuur gebruiken**

Als u een getegelde afbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kunt u de volgende eigenschappen van de interface [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) en de klasse [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) gebruiken:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Stelt de afbeeldingsvullingsmodus in — `Tile` of `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Geeft de uitlijning van de tegels binnen de vorm aan.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Regelt of de tegel horizontaal, verticaal, of beide keren wordt gedraaid.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Stelt de horizontale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm in.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Stelt de verticale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm in.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Definieert de horizontale schaal van de tegel als een percentage.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Definieert de verticale schaal van de tegel als een percentage.

Dit voorbeeld vereist een lokale afbeelding en configureert [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) om deze op 50 % van de oorspronkelijke grootte te herhalen. Offsets van −32 punten verschuiven de tegels horizontaal en verticaal; uitlijning rechtsonder en draaien in beide richtingen bepalen hoe de herhaalde textuur wordt gerangschikt.

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

Het resultaat:

![De tegelopties](tile-options.png)

## **Vulling met effen kleur**

Een effen vulling geeft een vorm een enkele, uniforme kleur. Dit voorbeeld stelt [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) in op de effen vullingsmodus en kent geel toe via [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/), waarna de rechthoek in een presentatie wordt opgeslagen.

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

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **De dia‑achtergrond gebruiken als vormvulling**

Gebruik [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) wanneer een vorm moet overeenkomen met de dia‑achtergrond, bijvoorbeeld in een presentatiesjabloon. Stel eerst [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) in op [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) om eventuele expliciete vulling te verwijderen. Met deze combinatie gebruikt de vorm de dia‑achtergrond in plaats van zijn stijl‑vulling. Het inschakelen van de vlag alleen verwijdert geen bestaande expliciete vulling.

Dit verschilt van [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): achtergrondvulling bedekt objecten achter de vorm met het overeenkomstige gebied van de dia‑achtergrond, terwijl geen vulling die objecten zichtbaar laat. Een gradiënt blijft uitgelijnd met de dia in plaats van opnieuw te beginnen binnen elke vorm.

Het volgende voorbeeld creëert een master‑achtergrond die door de dia wordt geërfd en plaatst een magenta‑band achter drie rechthoeken. De linkse rechthoek gebruikt de achtergrond, de middelste rechthoek heeft geen vulling, en de rechter rechthoek schakelt van achtergrondvulling naar een expliciete oranje vulling.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// Erf de gradiënt van de master.
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

// Voeg dit object eerst toe zodat het achter de rechthoeken verschijnt.
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

// Schakel achtergrondvulling uit voordat je een expliciete vulling toepast.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

Het resultaat, van links naar rechts: **background fill**, **no fill**, en **explicit fill**. De magenta‑band wordt verborgen door de linker en rechter rechthoeken maar blijft zichtbaar door de middelste rechthoek.

![Achtergrondvulling, geen vulling, en expliciete oranje vulling over een magenta‑band](background-fill.png)

Hetzelfde gedrag geldt voor een achtergrond die direct op de dia is gedefinieerd of van een lay‑out wordt geërfd. De vorm gebruikt de opgeloste achtergrond van de dia; het voorbeeld laat zowel de dia‑ als de lay‑out‑achtergronden ongedefinieerd zodat de master deze levert.

## **Transparantie instellen**

Voor een effen vulling bepaalt de alfa‑component van de kleur de opaciteit: 0 is volledig transparant en 255 volledig ondoorzichtig. Dit voorbeeld gebruikt een alfa‑waarde van 128 voor een gele rechthoek, waardoor deze ongeveer 50 % transparant wordt zodat de onderliggende rechthoek zichtbaar blijft. De kleur wordt toegewezen via [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

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

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Gebruik [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) om een vorm in het dia‑vlak te draaien. De hoek wordt gemeten in graden; dit voorbeeld roteert een rechthoek 5 graden met de klok mee en slaat de presentatie op.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D‑schuineffecten toevoegen**

Gebruik [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) om een vorm diepte en schuine randen te geven. Dit voorbeeld maakt een groene ellips met een oranje contour, stelt [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) in op 4 punten, en past een ronde bovenste schuine rand toe met een breedte en hoogte van 6 punten via [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). Een front‑facing orthografische camera en drie‑puntverlichting maken de schuine rand zichtbaar.

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

Het resultaat:

![Het 3D‑schuineffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Het 3D‑beeld van een vorm wordt beheerd door de camera‑instellingen. Dit voorbeeld gebruikt [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) met breedtegraad, lengtegraad en revolutiehoeken van respectievelijk 40, 35 en 20 graden. Het selecteert een isometrische camera via [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) en gebalanceerde verlichting via [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), waarna de opgemaakte rechthoek wordt opgeslagen.

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

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart‑wit‑rendering voor vormen beheren**

De eigenschap [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) geeft aan hoe een individuele vorm wordt gerenderd wanneer een presentatie wordt bekeken of verwerkt in zwart‑wit‑modus. Het activeert niet vanzelf een zwart‑wit‑weergave en verandert de vulling, lijn of andere opmaak van de vorm niet in de normale kleermodus.

Gebruik een waarde uit de enumeratie [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) om het gewenste gedrag te kiezen. Bijvoorbeeld, `Automatic` laat de rendering‑applicatie de conversie bepalen, `Gray` en `LightGray` gebruiken grijstinten, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` dwingen één kleur, `Color` behoudt de normale kleur, en `Hidden` laat de vorm weg in zwart‑wit‑modus. `NotDefined` betekent dat er geen vorm‑specifieke modus is toegewezen.

Dit voorbeeld maakt een oranje rechthoek en stelt [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) in op gray. De opgeslagen vorm behoudt zijn oranje vulling voor normale kleurweergave en vraagt grijze kleur aan applicaties die zwart‑wit‑weergave‑instellingen respecteren:

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

In de normale kleermodus behoudt de rechthoek zijn oranje vulling. In een zwart‑wit‑weergave‑workflow gebruikt hij grijze kleur omdat de modus is ingesteld op `Gray`. Hiermee kunt u een volledige‑kleur dia behouden terwijl u een aparte weergave definieert voor afdrukken, voorvertonen of andere workflows die de zwart‑wit‑weergave‑instellingen van de presentatie respecteren.

## **Opmaak resetten**

Gebruik [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) om de positie, grootte en opmaak van dia‑plaatsaanduidingen te herstellen vanuit de bijbehorende lay‑out‑plaatsaanduidingen. Dit voorbeeld vereist een bestaande presentatie met lay‑out‑gekoppelde plaatsaanduidingen en reset elke dia vóór het opslaan. Vormen zonder corresponderende lay‑out‑plaatsaanduidingen worden niet gereset.

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

**Heeft vormopmaak invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Kleuren, lijnstijlen en effectinstellingen voegen over het algemeen weinig data toe vergeleken met ingevoegde afbeeldingen en media. Afbeeldingsvullingen kunnen de bestandsgrootte vergroten omdat hun afbeeldingen in de presentatie worden opgeslagen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm — vulling, lijn en effectinstellingen. Als alle overeenkomstige waarden overeenkomen, beschouw dan hun stijlen als identiek en groepeer die vormen logisch, wat later het stijlbeheer vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Bewaar voorbeeldvormen met de gewenste stijlen in een sjabloondia‑set of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie, open het sjabloon, kloon de benodigde gestylede vormen, en pas hun opmaak opnieuw toe waar nodig.