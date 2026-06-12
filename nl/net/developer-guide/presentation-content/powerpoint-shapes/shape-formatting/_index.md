---
title: PowerPoint-vormen opmaken in .NET
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/net/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- koppelstijl opmaken
- gradientvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- vorm roteren
- 3D-afschuiningseffect
- 3D-rotatie-effect
- opmaak resetten
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen kunt opmaken in C# met Aspose.Slides—stel vul-, lijn- en effectstijlen in voor PPT- en PPTX-bestanden met nauwkeurigheid en volledige controle."
---
## **Inleiding**

In PowerPoint kun je vormen aan dia's toevoegen. Aangezien vormen bestaan uit lijnen, kun je ze opmaken door de omlijning te wijzigen of effecten toe te passen. Daarnaast kun je vormen opmaken door instellingen op te geven die bepalen hoe hun binnenkant wordt gevuld.

![vorm-opmaken-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET biedt interfaces en eigenschappen waarmee je vormen kunt opmaken met dezelfde opties als in PowerPoint.

## **Lijnen opmaken**

Met Aspose.Slides kun je een aangepaste lijnstijl voor een vorm opgeven. De volgende stappen beschrijven de procedure:

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [line style](https://reference.aspose.com/slides/nl/net/aspose.slides/linestyle/) van de vorm in.
1. Stel de lijndikte in.
1. Stel de [dash style](https://reference.aspose.com/slides/nl/net/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de lijnkleur voor de vorm in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```c#
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto vorm van het type Rechthoek toe.
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

    // Sla het PPTX-bestand op naar schijf.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

## **Koppelstijlen opmaken**

Hier zijn de drie opties voor het type verbinding:

* Rond
* Scherp
* Afgeschuind

Standaard gebruikt PowerPoint, wanneer twee lijnen onder een hoek worden samengevoegd (bijvoorbeeld aan een hoek van een vorm), de **Rond**‑instelling. Als je echter een vorm met scherpe hoeken tekent, kun je de voorkeur geven aan de **Scherp**‑optie.

![De verbindingsstijl in de presentatie](join-style-powerpoint.png)

```c#
// Instantieer de Presentation-klasse die een presentatie‑bestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg drie auto‑vormen van het type Rechthoek toe.
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

    // Stel de verbindingsstijl in.
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

## **Gradientvulling**

In PowerPoint is Gradientvulling een opmaakoptie waarmee je een geleidelijke overgang van kleuren op een vorm kunt toepassen. Je kunt bijvoorbeeld twee of meer kleuren toepassen zodat de ene geleidelijk in de andere overloopt.

Zo pas je een gradientvulling toe op een vorm met Aspose.Slides:

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de vorm in op `Gradient`.
1. Voeg je twee gewenste kleuren met gedefinieerde posities toe met behulp van de `Add`‑methoden van de gradient‑stop‑collectie die wordt blootgesteld door de [IGradientFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/igradientformat/) interface.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```c#
// Instantieer de Presentation-klasse die een presentatie‑bestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto‑vorm van het type Ellips toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Pas gradient‑opmaak toe op de ellips.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Stel de richting van de gradient in.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Voeg twee gradient‑stops toe.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Sla het PPTX‑bestand op naar schijf.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

![De ellips met gradientvulling](gradient-fill.png)

## **Patroonvulling**

In PowerPoint is Patroonvulling een opmaakoptie waarmee je een tweekleurig ontwerp—zoals stippen, strepen, kruislijnen of raster—op een vorm kunt toepassen. Je kunt aangepaste kleuren kiezen voor de voorgrond en achtergrond van het patroon.

Aspose.Slides biedt meer dan 45 vooraf gedefinieerde patroonstijlen die je op vormen kunt toepassen om de visuele aantrekkingskracht van je presentaties te verbeteren. Zelfs nadat je een voorgedefinieerd patroon hebt gekozen, kun je nog steeds de exacte kleuren opgeven die het moet gebruiken.

Zo pas je een patroonvulling toe op een vorm met Aspose.Slides:

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de vorm in op `Pattern`.
1. Kies een patroonstijl uit de vooraf gedefinieerde opties.
1. Stel de [Background Color](https://reference.aspose.com/slides/nl/net/aspose.slides/ipatternformat/backcolor/) van het patroon in.
1. Stel de [Foreground Color](https://reference.aspose.com/slides/nl/net/aspose.slides/ipatternformat/forecolor/) van het patroon in.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```c#
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
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

    // Sla het PPTX-bestand op naar schijf.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

In PowerPoint is Afbeeldingsvulling een opmaakoptie waarmee je een afbeelding in een vorm kunt invoegen—de afbeelding wordt daarmee als achtergrond van de vorm gebruikt.

Zo gebruik je Aspose.Slides om een afbeeldingsvulling toe te passen op een vorm:

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de vorm in op `Picture`.
1. Stel de afbeeldingsvullingsmodus in op `Tile` (of een andere gewenste modus).
1. Maak een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) object van de afbeelding die je wilt gebruiken.
1. Wijs deze afbeelding toe aan de `Picture.Image`‑eigenschap van de `PictureFillFormat` van de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Stel dat we een bestand "lotus.png" hebben met de volgende afbeelding:

```c#
// Instantieer de Presentation-klasse die een presentatie‑bestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto‑vorm van het type Rechthoek toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Stel het vultype in op Afbeelding.
    shape.FillFormat.FillType = FillType.Picture;

    // Stel de afbeeldingsvullingsmodus in.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Laad een afbeelding en voeg deze toe aan de presentatieresources.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Stel de afbeelding in.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Sla het PPTX‑bestand op naar schijf.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding Tegelen als Textuur**

Als je een getegelde afbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kun je de volgende eigenschappen van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/) interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/) klasse gebruiken:

- [PictureFillMode](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/picturefillmode/): Stelt de afbeeldingsvullingsmodus in — `Tile` of `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tilealignment/): Specificeert de uitlijning van de tegels binnen de vorm.
- [TileFlip](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tileflip/): Bepaalt of de tegel horizontaal, verticaal of beide keren wordt gedraaid.
- [TileOffsetX](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tileoffsetx/): Stelt de horizontale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [TileOffsetY](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tileoffsety/): Stelt de verticale offset van de tegel (in points) ten opzichte van de oorsprong van de vorm in.
- [TileScaleX](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tilescalex/): Definieert de horizontale schaal van de tegel als een percentage.
- [TileScaleY](https://reference.aspose.com/slides/nl/net/aspose.slides/ipicturefillformat/tilescaley/): Definieert de verticale schaal van de tegel als een percentage.

```c#
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide firstSlide = presentation.Slides[0];

    // Voeg een rechthoek auto-vorm toe.
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

    // Configureer de afbeeldingsvullingsmodus en tegel-eigenschappen.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Sla het PPTX-bestand op naar schijf.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

![De tegelopties](tile-options.png)

## **Effen kleurvulling**

In PowerPoint is Vulling met effen kleur een opmaakoptie die een vorm vult met één enkele, egale kleur. Deze eenvoudige achtergrondkleur wordt toegepast zonder gradients, texturen of patronen.

Om een vulling met een effen kleur toe te passen op een vorm met Aspose.Slides, volg je deze stappen:

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de vorm in op `Solid`.
1. Wijs je gewenste vulkleur toe aan de vorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```c#
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto-vorm van het type Rechthoek toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Stel het vultype in op Effen.
    shape.FillFormat.FillType = FillType.Solid;

    // Stel de vulkleur in.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Sla het PPTX-bestand op naar schijf.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Transparantie instellen**

In PowerPoint kun je, wanneer je een effen kleur, gradient, afbeelding of textuurvulling op vormen toepast, ook een transparantieniveau instellen om de doorzichtigheid van de vulling te regelen. Een hogere transparantiewaarde maakt de vorm meer doorschijnend, zodat de achtergrond of onderliggende objecten gedeeltelijk zichtbaar worden.

Aspose.Slides laat je het transparantieniveau instellen door de alfa‑waarde van de gebruikte kleur voor de vulling aan te passen. Zo doe je dat:

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) in op `Solid`.
1. Gebruik `Color.FromArgb(alpha, baseColor)` om een kleur met transparantie te definiëren (de `alpha`‑component regelt de transparantie).
1. Sla de presentatie op.

```c#
const int alpha = 128;

// Instantieer de Presentation-klasse die een presentatie‑bestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een effen rechthoek auto‑vorm toe.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Voeg een transparante rechthoek auto‑vorm toe over de effen vorm.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Sla het PPTX‑bestand op naar schijf.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Aspose.Slides laat je vormen roteren in PowerPoint‑presentaties. Dit kan handig zijn bij het positioneren van visuele elementen met een specifieke uitlijning of ontwerpbehoefte.

Om een vorm op een dia te roteren, volg je deze stappen:

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de `Rotation`‑eigenschap van de vorm in op de gewenste hoek.
1. Sla de presentatie op.

```c#
// Instantieer de Presentation-klasse die een presentatie-bestand vertegenwoordigt.
using (Presentation presentation = new Presentation())
{
    // Haal de eerste dia op.
    ISlide slide = presentation.Slides[0];

    // Voeg een auto-vorm van het type Rechthoek toe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Roteer de vorm met 5 graden.
    shape.Rotation = 5;

    // Sla het PPTX-bestand op naar schijf.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

![De rotatie van de vorm](shape-rotation.png)

## **3D-afschuiningseffecten toevoegen**

Aspose.Slides stelt je in staat om 3D‑afschuiningseffecten op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑afschuiningseffecten aan een vorm toe te voegen, volg je deze stappen:

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Configureer de [ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/) van de vorm om de afschuining in te stellen.
1. Sla de presentatie op.

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

    // Sla de presentatie op als een PPTX‑bestand.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

![Het 3D‑afschuiningseffect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Aspose.Slides stelt je in staat om 3D‑rotatie op vormen toe te passen door hun [ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/)‑eigenschappen te configureren.

Om 3D‑rotatie op een vorm toe te passen:

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
1. Stel de [CameraType](https://reference.aspose.com/slides/nl/net/aspose.slides/icamera/cameratype/) en [LightType](https://reference.aspose.com/slides/nl/net/aspose.slides/ilightrig/lighttype/) van de vorm in om de 3D‑rotatie te definiëren.
1. Sla de presentatie op.

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

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Opmaak resetten**

De volgende C#‑code laat zien hoe je de opmaak van een dia reset en de positie, grootte en opmaak van alle vormen met tijdelijke aanduidingen op de [LayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutslide/) terugzet naar de standaardinstellingen:

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

**Heeft vormopmaak invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Alleen minimaal. Ingesloten afbeeldingen en media nemen het meeste van de bestandsgrootte in beslag, terwijl vormparameters zoals kleuren, effecten en gradients als metadata worden opgeslagen en vrijwel geen extra grootte toevoegen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm — vulling, lijn‑ en effectinstellingen. Als alle bijbehorende waarden overeenkomen, beschouw je hun stijlen als identiek en groepeer je die vormen logisch, wat later het beheer van stijlen vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Sla voorbeeldvormen met de gewenste stijlen op in een sjabloondia‑deck of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie, open je het sjabloon, kloon je de gewenste gestileerde vormen en pas je hun opmaak opnieuw toe waar nodig.