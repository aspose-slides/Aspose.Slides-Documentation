---
title: PowerPoint-vormen opmaken in .NET
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/net/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets-effect
- schetslijn van vorm
- join-stijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- vorm roteren
- 3D-schuinteffect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen kunt opmaken in C# met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT- en PPTX-bestanden met precisie en volledige controle."
---
## **Introductie**

In PowerPoint kunt u vormen aan dia's toevoegen. Omdat vormen bestaan uit lijnen, kunt u ze opmaken door hun omtreklijnen te wijzigen of er effecten op toe te passen. Daarnaast kunt u vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![vorm-opmaken-powerpoint](format-shape-powerpoint.png)

Aspose.Slides voor .NET biedt interfaces en eigenschappen waarmee u vormen kunt opmaken met dezelfde opties als in PowerPoint.

## **Lijnen Opmaak**

Met Aspose.Slides kunt u een aangepaste lijnstijl voor een vorm opgeven. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [lijnstijl](https://reference.aspose.com/slides/nl/net/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [streepstijl](https://reference.aspose.com/slides/nl/net/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C#‑code toont hoe u een rechthoek‑`AutoShape` kunt opmaken:

```c#
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto‑shape van het type Rechthoek toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel de vulkleur in voor de rechthoekvorm.
    shape.FillFormat.FillType = FillType.NoFill;

    // Pas opmaak toe op de lijnen van de rechthoek.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Stel de kleur in voor de lijn van de rechthoek.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Sla het PPTX‑bestand op naar schijf.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets‑effecten op Vormlijnen Toepassen**

Een schets‑effect laat een vormlijn er handgetekend uitzien. Gebruik [IShape.LineFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/lineformat/) om toegang te krijgen tot de lijninstellingen, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ilineformat/sketchformat/) om de schets‑instellingen te benaderen, en [ISketchFormat.SketchType](https://reference.aspose.com/slides/nl/net/aspose.slides/isketchformat/sketchtype/) om een waarde uit de enumeratie [LineSketchType](https://reference.aspose.com/slides/nl/net/aspose.slides/linesketchtype/) te selecteren.

De volgende C#‑code laat zien hoe u een [LineSketchType.Curved](https://reference.aspose.com/slides/nl/net/aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde uitleest en het effect verwijdert met [LineSketchType.None](https://reference.aspose.com/slides/nl/net/aspose.slides/linesketchtype/):

```csharp
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

De waarde die wordt geretourneerd door `ISketchFormat.SketchType` vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, master‑dia of lay‑out‑dia, gebruik dan [ILineFormat.GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/ilineformat/geteffective/), benader [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ilineformateffectivedata/sketchformat/), en lees [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/nl/net/aspose.slides/isketchformateffectivedata/sketchtype/). De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat de erfenis is opgehelderd:

```csharp
using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Join‑stijlen Opmaak**

Hier zijn de drie opties voor join‑type:

* Rond
* Hoek
* Verweken

Standaard, wanneer PowerPoint twee lijnen onder een hoek verbindt (bijvoorbeeld op een hoek van een vorm), gebruikt het de instelling **Rond**. Als u echter een vorm met scherpe hoeken tekent, geeft u wellicht de voorkeur aan de **Hoek**‑optie.

![De join‑stijl in de presentatie](join-style-powerpoint.png)

De volgende C#‑code toont hoe drie rechthoeken (zoals weergegeven in de afbeelding hierboven) werden gemaakt met de join‑type‑instellingen Hoek, Verweken en Rond:

```c#
// Instantieer de Presentation-klasse die een presentatiebestand representeert.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg drie auto‑shapes van het type Rectangle toe.
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

    // Stel de join‑stijl in.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Voeg tekst toe aan elke rechthoek.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Sla het PPTX‑bestand op naar schijf.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie waarmee u een continue kleurverloop op een vorm kunt toepassen. U kunt bijvoorbeeld twee of meer kleuren toepassen zodat de ene geleidelijk in de andere overloopt.

Zo past u een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de vorm in op `Gradient`.
1. Voeg uw twee gewenste kleuren toe met gedefinieerde posities via de `Add`‑methoden van de gradient‑stop‑collectie die wordt blootgesteld door de [IGradientFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/igradientformat/)‑interface.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C#‑code toont hoe u een verloopvulling op een ellips toepast:

```c#
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto‑shape van het type Ellipse toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Pas een verloopopmaak toe op de ellips.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Stel de richting van het verloop in.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Voeg twee verloopstops toe.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Sla het PPTX‑bestand op naar schijf.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De ellips met verloopvulling](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee u een tweekleurig ontwerp—zoals stippen, strepen, kruispatronen of geruite patronen—op een vorm kunt toepassen. U kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die u op vormen kunt toepassen om de visuele aantrekkingskracht van uw presentaties te verbeteren. Zelfs na het kiezen van een vooraf gedefinieerd patroon kunt u de exacte kleuren specificeren die moeten worden gebruikt.

Zo past u een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de vorm in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Achtergrondkleur](https://reference.aspose.com/slides/nl/net/aspose.slides/ipatternformat/backcolor/) van het patroon in.
1. Stel de [Voorgrondkleur](https://reference.aspose.com/slides/nl/net/aspose.slides/ipatternformat/forecolor/) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C#‑code laat zien hoe u een patroonvulling op een rechthoek toepast:

```c#
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto‑shape van het type Rectangle toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Stel de patroonstijl in.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Stel de achtergrond- en voorgrondkleuren van het patroon in.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Sla het PPTX‑bestand op naar schijf.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee u een afbeelding in een vorm kunt invoegen—effectief als achtergrond van de vorm.

Zo gebruikt u Aspose.Slides om een afbeeldingvulling op een vorm toe te passen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de vorm in op `Picture`.
1. Stel de afbeeldingsvullingsmodus in op `Tile` (of een andere gewenste modus).
1. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/)‑object van de afbeelding die u wilt gebruiken.
1. Wijs deze afbeelding toe aan de eigenschap `Picture.Image` van de `PictureFillFormat` van de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Stel dat we een bestand “lotus.png” hebben met de volgende afbeelding:

![De lotus‑afbeelding](lotus.png)

De volgende C#‑code toont hoe u een vorm met de afbeelding vult:

```c#
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto‑shape van het type Rectangle toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Stel het vultype in op Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Stel de afbeeldingvullingsmodus in.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Laad een afbeelding en voeg deze toe aan de presentatie‑resources.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Stel de afbeelding in.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Sla het PPTX‑bestand op naar schijf.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De vorm met afbeeldingvulling](picture-fill.png)

### **Afbeelding Tegelen als Textuur**

Als u een tegel‑afbeelding als textuur wilt instellen en het tegel‑gedrag wilt aanpassen, kunt u de volgende eigenschappen van de interface [IPictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/) en de klasse [PictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/) gebruiken:

- [PictureFillMode](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/picturefillmode/): Stelt de afbeeldingsvullingsmodus in—`Tile` of `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tilealignment/): Bepaalt de uitlijning van de tegels binnen de vorm.
- [TileFlip](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tileflip/): Regelt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.
- [TileOffsetX](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tileoffsetx/): Stelt de horizontale verschuiving van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [TileOffsetY](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tileoffsety/): Stelt de verticale verschuiving van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [TileScaleX](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tilescalex/): Definieert de horizontale schaal van de tegel als percentage.
- [TileScaleY](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tilescaley/): Definieert de verticale schaal van de tegel als percentage.

De volgende code‑voorbeeld laat zien hoe u een rechthoekige vorm met een getegelde afbeeldingvulling toevoegt en de tegelopties configureert:

```c#
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide firstSlide = presentation.Slides[0];

    // Voeg een rechthoekige auto‑shape toe.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Stel het vultype van de vorm in op Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Laad de afbeelding en voeg deze toe aan de presentatie‑resources.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Wijs de afbeelding toe aan de vorm.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Configureer de afbeeldingvullingsmodus en tegel‑eigenschappen.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Sla het PPTX‑bestand op naar schijf.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Effen Kleurvulling**

In PowerPoint is Effen Kleurvulling een opmaakoptie die een vorm vult met één uniforme kleur. Deze effen achtergrondkleur wordt toegepast zonder verlopen, texturen of patronen.

Om een effen kleurvulling op een vorm toe te passen met Aspose.Slides, volgt u deze stappen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de vorm in op `Solid`.
1. Wijs uw gewenste vulkleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C#‑code toont hoe u een effen kleurvulling op een rechthoek in een PowerPoint‑dia toepast:

```c#
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto‑shape van het type Rectangle toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Stel de vulkleur in.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Sla het PPTX‑bestand op naar schijf.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie Instellen**

In PowerPoint kunt u, wanneer u een effen kleur, verloop, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de doorzichtigheid van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, waardoor de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides stelt u in staat het transparantieniveau aan te passen door de alfa‑waarde in de gebruikte kleur voor de vulling te wijzigen. Zo gaat u te werk:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color.FromArgb(alpha, baseColor)` om een kleur met transparantie te definiëren (de `alpha`‑component regelt de transparantie).
1. Sla de presentatie op.

De volgende C#‑code toont hoe u een transparante vulkleur op een rechthoek toepast:

```c#
const int alpha = 128;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een solide rechthoekige auto-shape toe.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoekige auto-shape toe boven de solide vorm.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Sla het PPTX-bestand op naar schijf.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De doorzichtige vorm](shape-transparency.png)

## **Vormen Roteren**

Aspose.Slides maakt het mogelijk om vormen in PowerPoint‑presentaties te roteren. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijnings‑ of ontwerpbehoeften.

Om een vorm op een dia te roteren, volgt u deze stappen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de eigenschap `Rotation` van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

De volgende C#‑code toont hoe u een vorm met 5 grad draait:

```c#
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto‑shape van het type Rectangle toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Roteer de vorm met 5 graden.
    shape.Rotation = 5;

    // Sla het PPTX‑bestand op naar schijf.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D‑Schuinteffecten Toevoegen**

Aspose.Slides stelt u in staat 3D‑schuinteffecten op vormen toe te passen door de eigenschappen van hun [ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/) te configureren.

Om 3D‑schuinteffecten aan een vorm toe te voegen, volgt u deze stappen:

1. Instantieer de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/) van de vorm om de schuinte‑instellingen te definiëren.
1. Sla de presentatie op.

De volgende C#‑code laat zien hoe u 3D‑schuinteffecten op een vorm toepast:

```c#
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

    // Stel de ThreeDFormat-eigenschappen van de vorm in.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Sla de presentatie op als een PPTX-bestand.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![Het 3D‑schuinteffect](3D-bevel-effect.png)

## **3D‑Rotatie‑effecten Toevoegen**

Aspose.Slides maakt het mogelijk 3D‑rotatie‑effecten op vormen toe te passen door de eigenschappen van hun [ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/) te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [CameraType](https://reference.aspose.com/slides/nl/net/aspose.slides/icamera/cameratype/) en [LightType](https://reference.aspose.com/slides/nl/net/aspose.slides/ilightrig/lighttype/) van de vorm in om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

De volgende C#‑code toont hoe u 3D‑rotatie‑effecten op een vorm toepast:

```c#
// Maak een instantie van de Presentation-klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Sla de presentatie op als een PPTX-bestand.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Opmaak Resetten**

De volgende C#‑code toont hoe u de opmaak van een dia kunt resetten en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Reset elke vorm op de dia die een placeholder op de lay-out heeft.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Heeft het opmaken van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Ja, maar slechts minimaal. Ingevoegde afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en praktisch geen extra ruimte innemen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak hebben zodat ik ze kan groeperen?**

Vergelijk de sleutel‑opmaak‑eigenschappen van elke vorm — vul‑, lijn‑ en effectinstellingen. Als alle corresponderende waarden overeenkomen, beschouw dan hun stijlen als identiek en groepeer de vormen logisch, wat later beheer van stijlen vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een afzonderlijk bestand voor hergebruik in andere presentaties?**

Ja. Bewaar voorbeeldvormen met de gewenste stijlen in een sjabloondiep of een .POTX‑sjabloonbestand. Wanneer u een nieuwe presentatie maakt, opent u het sjabloon, kloont u de benodigde stijlvormen en past u hun opmaak toe waar nodig.