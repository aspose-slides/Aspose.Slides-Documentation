---
title: PowerPoint-vormen opmaken in .NET
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/net/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets‑effect
- schetsvormlijn
- samenvoegingsstijl opmaken
- gradiëntvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart‑wit weergave van vorm
- grijswaarden weergave van vorm
- vorm roteren
- 3D‑schuineffect
- 3D‑draaieffect
- opmaak resetten
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u PowerPoint‑vormen kunt opmaken in C# met Aspose.Slides—stelt vul-, lijn- en effectstijlen in voor PPT- en PPTX-bestanden met precisie en volledige controle."
---
## **Introductie**

In PowerPoint kun je vormen aan dia's toevoegen. Aangezien vormen uit lijnen bestaan, kun je ze opmaken door de omtrek te wijzigen of effecten toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET biedt interfaces en eigenschappen waarmee je vormen kunt opmaken met dezelfde opties als in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepast lijnstijl voor een vorm opgeven. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [line style](https://reference.aspose.com/slides/nl/net/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/nl/net/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C#‑code toont hoe je een rechthoek‑`AutoShape` kunt opmaken:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto-vorm van het type Rechthoek toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel de vulkleur in voor de rechthoekvorm.
    shape.FillFormat.FillType = FillType.NoFill;

    // Pas de opmaak toe op de lijnen van de rechthoek.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Stel de kleur in voor de lijn van de rechthoek.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Sla het PPTX-bestand op schijf.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![The formatted lines in the presentation](formatted-lines.png)

## **Schets‑effecten op lijnen toepassen**

Een schets‑effect maakt een vormlijn handgetekend. Gebruik [IShape.LineFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/lineformat/) om de lijninstellingen te benaderen, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ilineformat/sketchformat/) voor de schetsettingen en [ISketchFormat.SketchType](https://reference.aspose.com/slides/nl/net/aspose.slides/isketchformat/sketchtype/) om een waarde uit de [LineSketchType](https://reference.aspose.com/slides/nl/net/aspose.slides/linesketchtype/)‑enumeratie te kiezen.

De volgende C#‑code laat zien hoe je een [LineSketchType.Curved](https://reference.aspose.com/slides/nl/net/aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde uitleest en het effect verwijdert met [LineSketchType.None](https://reference.aspose.com/slides/nl/net/aspose.slides/linesketchtype/):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

De waarde die wordt geretourneerd door `ISketchFormat.SketchType` vertegenwoordigt de instelling die rechtstreeks op de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, masterdia of lay‑outdia, gebruik dan [ILineFormat.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/ilineformat/geteffective/), benader [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ilineformateffectivedata/sketchformat/) en lees [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/nl/net/aspose.slides/isketchformateffectivedata/sketchtype/). De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat erfelijkheid is opgelost:

```csharp
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

## **Aansluit‑stijlen opmaken**

Hier zijn de drie opties voor het type aansluiting:

* Round
* Miter
* Bevel

Standaard gebruikt PowerPoint, wanneer twee lijnen onder een hoek (bijvoorbeeld bij een hoek van een vorm) worden samengevoegd, de instelling **Round**. Als je echter een vorm met scherpe hoeken tekent, geef je misschien de voorkeur aan **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

De volgende C#‑code toont hoe drie rechthoeken (zoals afgebeeld) werden gemaakt met de Miter‑, Bevel‑ en Round‑aansluit‑instellingen:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg drie auto-vormen van het type Rechthoek toe.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Stel de vulkleur in voor elke rechthoekvorm.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Stel de lijndikte in.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Stel de kleur in voor de lijn van elke rechthoek.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Stel de aansluitstijl in.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Voeg tekst toe aan elke rechthoek.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Sla het PPTX-bestand op schijf.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Gradiëntenvulling**

In PowerPoint is Gradiëntenvulling een opmaakoptie waarmee je een continue kleurverloop op een vorm kunt toepassen. Je kunt bijvoorbeeld twee of meer kleuren gebruiken zodat de ene geleidelijk in de andere vervaagt.

Zo pas je een gradiëntenvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de vorm in op `Gradient`.
1. Voeg je twee voorkeurs‑kleuren toe met gedefinieerde posities via de `Add`‑methoden van de gradiënt‑stopcollectie die door de [IGradientFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/igradientformat/)‑interface wordt blootgelegd.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C#‑code toont hoe je een gradiëntenvulling toepast op een ellips:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto-vorm van het type Ellips toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Pas gradiëntenopmaak toe op de ellips.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Stel de richting van de gradiënt in.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Voeg twee gradiëntstops toe.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Sla het PPTX-bestand op schijf.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![The ellipse with gradient fill](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, kruislings of ruitjes—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om je presentaties visueel aantrekkelijker te maken. Zelfs nadat je een vooraf gedefinieerd patroon hebt gekozen, kun je nog steeds de exacte kleuren specificeren die het moet gebruiken.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de vorm in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/nl/net/aspose.slides/ipatternformat/backcolor/) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/net/aspose.slides/ipatternformat/forecolor/) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C#‑code toont hoe je een patroonvulling toepast op een rechthoek:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto-vorm van het type Rechthoek toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Patroon.
    shape.FillFormat.FillType = FillType.Pattern;

    // Stel de patroonstijl in.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Stel de achtergrond- en voorgrondkleuren van het patroon in.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Sla het PPTX-bestand op schijf.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![The rectangle with pattern fill](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt opnemen—de afbeelding fungeert dan als achtergrond van de vorm.

Zo gebruik je Aspose.Slides om een afbeeldingvulling op een vorm toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de vorm in op `Picture`.
1. Stel de afbeeldingsvullingsmodus in op `Tile` (of een andere gewenste modus).
1. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/)‑object van de afbeelding die je wilt gebruiken.
1. Wijs deze afbeelding toe aan de `Picture.Image`‑eigenschap van de `PictureFillFormat` van de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Stel dat we een bestand `lotus.png` hebben met de volgende afbeelding:

![The lotus picture](lotus.png)

De volgende C#‑code toont hoe je een vorm met de afbeelding vult:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto-vorm van het type Rechthoek toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Stel het vultype in op Afbeelding.
    shape.FillFormat.FillType = FillType.Picture;

    // Stel de afbeeldingsvullingsmodus in.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Laad een afbeelding en voeg deze toe aan de presentatie-resources.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Stel de afbeelding in.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Sla het PPTX-bestand op schijf.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![The shape with picture fill](picture-fill.png)

### **Afbeelding als tegeltekstuur**

Wil je een getegelde afbeelding als textuur gebruiken en het tegelgedrag aanpassen, dan kun je de volgende eigenschappen van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/)‑interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/)‑klasse gebruiken:

- [PictureFillMode](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/picturefillmode/): Stelt de afbeeldingsvullingsmodus in—`Tile` of `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tilealignment/): Bepaalt de uitlijning van de tegels binnen de vorm.
- [TileFlip](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tileflip/): Bepaalt of de tegel horizontaal, verticaal of beide keer wordt gedraaid.
- [TileOffsetX](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tileoffsetx/): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [TileOffsetY](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tileoffsety/): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [TileScaleX](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tilescalex/): Definieert de horizontale schaal van de tegel als percentage.
- [TileScaleY](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tilescaley/): Definieert de verticale schaal van de tegel als percentage.

De volgende code‑voorbeeld toont hoe je een rechthoek met een getegelde afbeeldingvulling toevoegt en de tegelopties configureert:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide firstSlide = presentation.Slides[0];

    // Voeg een auto-vorm van het type Rechthoek toe.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Stel het vultype van de vorm in op Afbeelding.
    shape.FillFormat.FillType = FillType.Picture;

    // Laad de afbeelding en voeg deze toe aan de presentatieresources.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Wijs de afbeelding toe aan de vorm.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Configureer de afbeeldingsvullingsmodus en tegel‑eigenschappen.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Sla het PPTX‑bestand op schijf.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![The tile options](tile-options.png)

## **Vulling met effen kleur**

In PowerPoint is Vulling met effen kleur een opmaakoptie die een vorm vult met één enkele, uniforme kleur. Deze effen achtergrondkleur wordt toegepast zonder gradiënten, texturen of patronen.

Zo pas je een effen kleurvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de vorm in op `Solid`.
1. Wijs je gewenste opvulkleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C#‑code toont hoe je een effen kleurvulling toepast op een rechthoek in een PowerPoint‑dia:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto-vorm van het type Rechthoek toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Stel de vulkleur in.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Sla het PPTX‑bestand op schijf.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![The shape with solid color fill](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, naast een effen kleur, een gradiënt, afbeelding of textuur, ook een transparantieniveau instellen om de doorzichtigheid van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, zodat de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides laat je het transparantieniveau instellen door de alfa‑waarde van de gebruikte vulkleur aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color.FromArgb(alpha, baseColor)` om een kleur met transparantie te definiëren (de `alpha`‑component bepaalt de transparantie).
1. Sla de presentatie op.

De volgende C#‑code toont hoe je een transparante vulkleur toepast op een rechthoek:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een solide rechthoek‑auto‑shape toe.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoek‑auto‑shape toe boven de solide vorm.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Sla het PPTX‑bestand op schijf.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![The transparent shape](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides laat je vormen roteren in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning‑ of ontwerpnoden.

Zo roteer je een vorm op een dia:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de `Rotation`‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

De volgende C#‑code toont hoe je een vorm 5 graden roteert:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto-vorm van het type Rechthoek toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Roteer de vorm met 5 graden.
    shape.Rotation = 5;

    // Sla het PPTX-bestand op schijf.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![The shape rotation](shape-rotation.png)

## **3D‑schuinstijl toevoegen**

Aspose.Slides maakt het mogelijk 3D‑schuinstijl toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/)‑eigenschappen te configureren.

Zo voeg je 3D‑schuinstijl toe aan een vorm:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/) van de vorm om de schuinstijl te definiëren.
1. Sla de presentatie op.

De volgende C#‑code laat zien hoe je 3D‑schuinstijl toepast op een vorm:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Voeg een vorm toe aan de dia.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Stel de ThreeDFormat‑eigenschappen van de vorm in.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Sla de presentatie op als een PPTX‑bestand.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D‑draai‑effect toevoegen**

Aspose.Slides maakt het mogelijk 3D‑draai‑effecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/)‑eigenschappen te configureren.

Zo pas je 3D‑draaien toe op een vorm:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [CameraType](https://reference.aspose.com/slides/nl/net/aspose.slides/icamera/cameratype/) en [LightType](https://reference.aspose.com/slides/nl/net/aspose.slides/ilightrig/lighttype/) van de vorm in om de 3D‑draai te definiëren.
1. Sla de presentatie op.

De volgende C#‑code toont hoe je 3D‑draai‑effecten toepast op een vorm:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Sla de presentatie op als een PPTX‑bestand.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![The 3D rotation effect](3D-rotation-effect.png)

## **Zwart‑wit‑rendering voor vormen regelen**

De eigenschap [IShape.BlackWhiteMode](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/blackwhitemode/) geeft aan hoe een individuele vorm wordt gerenderd wanneer een presentatie in zwart‑wit‑modus wordt bekeken of verwerkt. Deze eigenschap activeert niet zelf de zwart‑wit‑weergave en verandert de vulling, lijn of andere opmaak in de normale kleurenmodus niet.

Gebruik een waarde uit de enumeratie [BlackWhiteMode](https://reference.aspose.com/slides/nl/net/aspose.slides/blackwhitemode/) om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de renderingsapplicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijstinten, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` dwingen één kleur, `Color` behoudt de normale kleur, en `Hidden` laat de vorm weg in zwart‑wit‑modus. `NotDefined` betekent dat er geen vormspecifieke modus is toegewezen.

De volgende C#‑code maakt een gekleurde vorm aan en laat deze grijs verschijnen in zwart‑wit‑weergavemodus:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Houd de oranje vulling in kleurmodus, maar render de vorm met grijze kleuring in zwart‑wit‑modus.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

In de normale kleurenmodus behoudt de rechthoek zijn oranje vulling. In een zwart‑wit‑workflow wordt een grijze kleur gebruikt omdat de modus is ingesteld op `Gray`. Zo kun je een dia in volledige kleur behouden en toch een aparte weergave definiëren voor afdrukken, preview‑ of andere workflows die rekening houden met de zwart‑wit‑instellingen van de presentatie.

## **Opmaak resetten**

De volgende C#‑code toont hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutslide/) terugzet naar de standaardinstellingen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Reset elke vorm op de dia die een placeholder heeft op de lay-out.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Heeft de opmaak van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingesloten afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en gradiënten als metadata worden opgeslagen en praktisch geen extra ruimte innemen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vulling, lijn en effectinstellingen. Als alle overeenkomstige waarden gelijk zijn, beschouw je hun stijlen als identiek en groepeer je die vormen logisch, wat later beheer van stijlen vereenvoudigt.

**Kan ik een verzameling aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Bewaar voorbeeldvormen met de gewenste stijlen in een sjabloondia‑deck of een .POTX‑sjabloonbestand. Wanneer je een nieuwe presentatie maakt, open je de sjabloon, kloon je de gestylede vormen die je nodig hebt en pas je hun opmaak opnieuw toe waar nodig.