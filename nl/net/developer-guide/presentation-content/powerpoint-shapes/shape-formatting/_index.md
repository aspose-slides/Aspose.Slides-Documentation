---
title: Format PowerPoint-vormen in .NET
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/net/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets effect
- schets vormlijn
- aansluitingsstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart-wit vormrendering
- grijswaarden vormrendering
- vorm roteren
- 3D-schuineffect
- 3D-rotatie effect
- opmaak resetten
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen kunt formatteren in C# met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT- en PPTX-bestanden met nauwkeurigheid en volledige controle."
---
## **Inleiding**

In PowerPoint kun je vormen aan dia's toevoegen. Aangezien vormen bestaan uit lijnen, kun je ze opmaken door hun contouren te wijzigen of er effecten op toe te passen. Daarnaast kun je vormen opmaken door instellingen te specificeren die bepalen hoe hun binnenkant wordt gevuld.

![vorm-opmaken-powerpoint](format-shape-powerpoint.png)

Aspose.Slides voor .NET biedt interfaces en properties die je in staat stellen om vormen op te maken met dezelfde opties die in PowerPoint beschikbaar zijn.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm opgeven. De volgende stappen beschrijven de procedure:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [lijnstijl](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [streepjesstijl](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C#‑code toont hoe je een rechthoek‑`AutoShape` kunt opmaken:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een autoshape van het type Rechthoek toe.
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

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect laat een vormlijn eruitzien alsof deze met de hand is getekend. Gebruik [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) om toegang te krijgen tot de lijninstellingen, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) om toegang te krijgen tot de schetsinstellingen, en [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) om een waarde uit de [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)‑enumeratie te selecteren.

De volgende C#‑code laat zien hoe je een [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)‑effect toepast, de expliciet toegewezen waarde uitleest, en het effect verwijdert met [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

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

De waarde die wordt geretourneerd door `ISketchFormat.SketchType` vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnopmaak kan worden geërfd van een thema, masterslide of lay‑outs­slide, gebruik dan [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), krijg toegang tot [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), en lees [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). De effectieve waarde geeft de opmaak weer die daadwerkelijk wordt toegepast nadat erfenissen zijn opgelost:

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

## **Opmaak van aansluitingsstijlen**

Hier zijn de drie opties voor het type aansluitingsstijl:

* Rond
* Scherp
* Afsnij

Standaard, wanneer PowerPoint twee lijnen onder een hoek (bijvoorbeeld bij een hoek van een vorm) verbindt, wordt de **Rond**‑instelling gebruikt. Als je echter een vorm met scherpe hoeken tekent, kun je de voorkeur geven aan de **Scherp**‑optie.

![De aansluitingsstijl in de presentatie](join-style-powerpoint.png)

De volgende C#‑code toont hoe drie rechthoeken (zoals te zien in de afbeelding hierboven) werden gemaakt met de Miter‑, Bevel‑ en Round‑aansluitingsstijlinstellingen:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg drie autosvormen van het type Rechthoek toe.
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

    // Stel de aansluitingsstijl in.
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

## **Verloopvulling**

In PowerPoint is Verloopvulling een opmaakoptie waarmee je een continue kleurverloop op een vorm kunt toepassen. Je kunt bijvoorbeeld twee of meer kleuren toepassen op een manier waarbij de ene geleidelijk in de andere overloopt.

Zo pas je een verloopvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) van de vorm in op `Gradient`.
1. Voeg je twee favoriete kleuren toe met gedefinieerde posities via de `Add`‑methoden van de gradient‑stop‑collectie die wordt blootgesteld door de [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/) interface.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C#‑code toont hoe je een verloopvulling toepast op een ellips:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een autosvorm van het type Ellipse toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Pas verloopopmaak toe op de ellips.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Stel de richting van het verloop in.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Voeg twee verloopstops toe.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Sla het PPTX-bestand op schijf.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De ellips met verloopvulling](gradient-fill.png)

Als een verloop er anders uitziet in een geëxporteerde afbeelding dan in PowerPoint, zie dan [Kies een verloop‑renderingsstijl](/slides/nl/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Je kunt een renderingsstijl selecteren zonder de verloopvulling die in de presentatie is opgeslagen te wijzigen.

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, kruislings of vakken—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voor‑ en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te vergroten. Zelfs nadat je een vooraf gedefinieerd patroon hebt gekozen, kun je nog steeds de exacte kleuren opgeven die het moet gebruiken.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) van de vorm in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C#‑code toont hoe je een patroonvulling toepast op een rechthoek:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een autosvorm van het type Rectangle toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Pattern.
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

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt invoegen—effectief gebruikmakend van de afbeelding als achtergrond van de vorm.

Zo gebruik je Aspose.Slides om een afbeeldingvulling op een vorm toe te passen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) van de vorm in op `Picture`.
1. Stel de afbeeldingvullingsmodus in op `Tile` (of een andere gewenste modus).
1. Maak een [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) object aan van de afbeelding die je wilt gebruiken.
1. Wijs deze afbeelding toe aan de `Picture.Image`‑eigenschap van de `PictureFillFormat` van de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Stel dat we een bestand “lotus.png” hebben met de volgende afbeelding:

![De lotusafbeelding](lotus.png)

De volgende C#‑code toont hoe je een vorm vult met de afbeelding:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een autosvorm van het type Rectangle toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Stel het vultype in op Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Stel de afbeeldingvullingsmodus in.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Laad een afbeelding en voeg deze toe aan de presentatiebronnen.
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

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Beeldtegels als textuur**

Als je een getegelde afbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kun je de volgende eigenschappen van de [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) interface en de [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) klasse gebruiken:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Stelt de afbeeldingvullingsmodus in—`Tile` of `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Bepaalt de uitlijning van de tegels binnen de vorm.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Bepaalt of de tegel horizontaal, verticaal of beide keren wordt gespiegeld.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Stelt de horizontale verschuiving van de tegel (in points) ten opzichte van het oorsprongpunt van de vorm in.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Stelt de verticale verschuiving van de tegel (in points) ten opzichte van het oorsprongpunt van de vorm in.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Definieert de horizontale schaal van de tegel als percentage.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Definieert de verticale schaal van de tegel als percentage.

De volgende code laat zien hoe je een rechthoekige vorm toevoegt met een getegelde afbeeldingvulling en de tegelopties configureert:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide firstSlide = presentation.Slides[0];

    // Voeg een rechthoekige autosvorm toe.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Stel het vultype van de vorm in op Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Laad de afbeelding en voeg deze toe aan de presentatieresources.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Wijs de afbeelding toe aan de vorm.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Configureer de afbeeldingvullingsmodus en tegel-eigenschappen.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Sla het PPTX-bestand op schijf.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Vulling met effen kleur**

In PowerPoint is Vulling met effen kleur een opmaakoptie die een vorm vult met één enkele, uniforme kleur. Deze eenvoudige achtergrondkleur wordt toegepast zonder verloop, textuur of patroon.

Om een vulling met effen kleur op een vorm toe te passen met Aspose.Slides, volg je deze stappen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) van de vorm in op `Solid`.
1. Wijs je gewenste vulkleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende C#‑code toont hoe je een rechthoek in een PowerPoint‑dia vult met een effen kleur:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een autosvorm van het type Rectangle toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Stel de vulkleur in.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Sla het PPTX-bestand op schijf.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, wanneer je een effen kleur, verloop, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de dekkingsgraad van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, waardoor de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides laat je het transparantieniveau instellen door de alfabeta‑waarde in de kleur die voor de vulling wordt gebruikt aan te passen. Zo doe je dat:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color.FromArgb(alpha, baseColor)` om een kleur met transparantie te definiëren (de `alpha`‑component bepaalt de transparantie).
1. Sla de presentatie op.

De volgende C#‑code toont hoe je een transparante vulkleur toepast op een rechthoek:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een solide rechthoekige autosvorm toe.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoekige autosvorm toe boven de solide vorm.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Sla het PPTX-bestand op schijf.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides laat je vormen roteren in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met specifieke uitlijning‑ of ontwerpeisen.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de `Rotation`‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

De volgende C#‑code toont hoe je een vorm 5 graden roteert:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een autosvorm van het type Rectangle toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Roteer de vorm met 5 graden.
    shape.Rotation = 5;

    // Sla het PPTX-bestand op schijf.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De vormrotatie](shape-rotation.png)

## **3D‑schuineffecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑schuineffecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑schuineffecten aan een vorm toe te voegen, volg je deze stappen:

1. Instantieer de [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) van de vorm om de schuine‑instellingen te definiëren.
1. Sla de presentatie op.

De volgende C#‑code laat zien hoe je 3D‑schuineffecten toepast op een vorm:

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

![Het 3D‑schuineffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Aspose.Slides maakt het mogelijk om 3D‑rotatie‑effecten toe te passen op vormen door hun [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) en [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) van de vorm in om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

De volgende C#‑code toont hoe je 3D‑rotatie‑effecten op een vorm toepast:

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

    // Sla de presentatie op als een PPTX-bestand.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart‑witweergave van vormen beheren**

De eigenschap [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) bepaalt hoe een individuele vorm wordt gerenderd wanneer een presentatie wordt bekeken of verwerkt in zwart‑witmodus. De eigenschap activeert niet zelf een zwart‑witweergave en wijzigt de vul‑, lijn‑ of andere opmaak niet in de normale kleermodus.

Gebruik een waarde uit de [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/)‑enumeratie om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de render‑applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijstinten, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` dwingen één enkele kleur, `Color` behoudt de normale kleuring, en `Hidden` laat de vorm weg in zwart‑witmodus. `NotDefined` betekent dat er geen vorm‑specifieke modus is toegewezen.

De volgende C#‑code maakt een gekleurde vorm en laat deze grijs verschijnen in zwart‑witweergavemodus:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Behoud de oranje vulling in kleurmodus, maar render de vorm met grijze kleur in zwart-witmodus.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

In normale kleurmodus behoudt de rechthoek zijn oranje vulling. In een zwart‑witworkflow gebruikt hij grijstinten omdat de modus is ingesteld op `Gray`. Zo kun je een volledige‑kleur dia behouden terwijl je een aparte weergave voor afdrukken, preview of andere workflows definieert die respecteren dat de presentatie in zwart‑wit moet worden weergegeven.

## **Opmaak resetten**

De volgende C#‑code toont hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met placeholders op de [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) terugzet naar hun standaardinstellingen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

**Heeft de opmaak van vormen invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingebedde afbeeldingen en media nemen het grootste deel van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en verlopen als metadata worden opgeslagen en praktisch geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia identificeren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm—vul, lijn en effectinstellingen. Als alle overeenkomstige waarden overeenkomen, behandel dan hun stijlen als identiek en groepeer die vormen logisch, wat later style‑beheer vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloondiavoorstelling of een .POTX‑sjabloonbestand. Wanneer je een nieuwe presentatie maakt, open je het sjabloon, kloon je de benodigde gestylede vormen, en pas je hun opmaak overal toe waar nodig.