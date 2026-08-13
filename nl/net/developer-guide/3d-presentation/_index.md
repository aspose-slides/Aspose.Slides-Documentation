---
title: 3D-effecten maken in presentaties met .NET
linktitle: 3D-presentatie
type: docs
weight: 232
url: /nl/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D presentatie
- 3D rotatie
- 3D diepte
- 3D extrusie
- 3D verloop
- 3D tekst
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas 3D-effecten toe en render ze voor PowerPoint-vormen en -tekst in .NET met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides for .NET kan 3D‑opmaak in PowerPoint‑stijl voor vormen en tekst creëren, bewerken, behouden en renderen. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, schuine randen, verlichting, materiaal, verloop‑ of afbeeldingsvullingen en 3D‑tekst.

{{% alert color="info" %}}
Dit artikel gaat over 3D‑opmaakeffecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van losstaande 3D‑modellen. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, renderen Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **Concepten van 3D‑opmaak**

Gebruik de eigenschap [IShape.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/properties/threedformat) om 3D‑opmaak toe te passen op een vorm. De eigenschap exposeert [IThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruikt u de eigenschap [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/properties/threedformat). Deze past 3D‑opmaak toe op het tekstframe in plaats van op het lichaam van de vorm.

De belangrijkste eigenschappen zijn:

| Eigenschap | Waar het controleert | Wanneer te gebruiken |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/camera) | Kijkpunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Draai het object in 3D‑ruimte of stem overeen met een vooraf ingestelde 3D‑rotatie in PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/lightrig) | Lichtvoorinstelling, richting en lichtrotatie. | Verander hoe hooglichten en schaduwen verschijnen op het 3D‑oppervlak. |
| [Material](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/material) | Oppervlakte‑materiaal, zoals vlak, mat, kunststof of metaal. | Laat dezelfde geometrie er vlakker, zachter, glanzender of metallic uitzien. |
| [ExtrusionHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusionheight) | Hoe ver de vorm zich naar achteren uitstrekt vanaf het voorste vlak. | Maak van een platte vorm een duidelijk dik 3D‑object. |
| [ExtrusionColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Kleur van de geëxtrudeerde zijden. | Maak diepte zichtbaar of stem de zijkleur af op de voorvulling. |
| [Depth](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/depth) | Extra 3D‑diepte die door PowerPoint‑3D‑opmaak wordt gebruikt. | Fijn afstemmen van diepte voor vormen of tekst, vooral in combinatie met bevel‑ en materiaalin­stellingen. |
| [BevelTop](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/beveltop) en [BevelBottom](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/bevelbottom) | Verhoogde of afgeronde randen op de voor‑ en achtervlakken. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe vlakke rand. |
| [ContourColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/contourcolor) en [ContourWidth](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/contourwidth) | Omtreklijn rondom het 3D‑object. | Benadruk de grens van het object in de gerenderde uitvoer. |

## **Maak een 3D‑vorm**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D lijkt:

- Camera‑instellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Licht‑instellingen, omdat verlichting de vlakken en zijkanten leesbaar maakt.
- Materiaal‑instellingen, omdat het oppervlak beïnvloedt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan het voorvlak, past 3D‑opmaak toe, slaat de presentatie op als PPTX en rendert de dia naar een PNG‑afbeelding.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

De gerenderde dia‑afbeelding toont de rechthoek als een dik 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op het voorvlak](img_01_01.png)

## **Een vorm roteren met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het paneel 3‑D‑rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u instelt via de camera‑API.

![PowerPoint‑paneel 3‑D‑rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides stelt u het cameratype en de rotatie in via [IThreeDFormat.Camera](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/camera):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Gebruik de camera wanneer u wilt wijzigen hoe de kijker het object ziet. Het verandert niet de 2D‑vormgeometrie op de dia. Het wijzigt het 3D‑kijkpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Extrusie en diepte toevoegen**

Extrusie maakt een vorm dikker door deze achter het voorvlak uit te breiden. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en de kleur‑instelling bepaalt de kleur van de zijvlakken.

![PowerPoint‑diepte‑instellingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusionheight) in voor de dikte en [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusioncolor) voor de zijkleur:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Gebruik [IThreeDFormat.Depth](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/depth) wanneer u direct met de dieptewaarde van PowerPoint wilt werken of diepte wilt combineren met bevel‑, materiaal‑ en teksteffecten. In veel vormen‑scenario's is `ExtrusionHeight` de duidelijkere instelling omdat deze de zichtbare extrusie rechtstreeks uitdrukt.

## **Verloop‑ of afbeeldingsvullingen gebruiken met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeeldingsvulling op het voorvlak toepassen en toch dezelfde camera-, licht-, materiaal- en extrusie‑instellingen gebruiken.

Dit voorbeeld past een verloopvulling toe op de vorm en een donkerdere extrusiekleur op de zijkanten:

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

De gerenderde output behoudt het verloop op het voorvlak en rendert de extrusie apart:

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingsvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en wijst u deze toe aan de vormvulling:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

De afbeelding wordt gerenderd op het voorvlak, terwijl de extrusie wordt gerenderd als het 3D‑zijoppervlak:

![Gerenderde 3D‑rechthoek met een foto‑vulling op het voorvlak en oranje extrusie](img_02_04.png)

## **3D‑opmaak toepassen op tekst**

3D‑opmaak van een vorm beïnvloedt het lichaamsdeel van de vorm. 3D‑opmaak van tekst beïnvloedt het tekstframe. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een patroonvulling, past een WordArt‑transformatie toe en configureert 3D‑instellingen op [ITextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat):

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

De tekst wordt gerenderd als gebogen, geëxtrudeerde 3D‑letters:

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑indelingsformaten wordt de 3D‑scene gerasterd of in de uitvoer getekend als een 2D‑resultaat. Dit geldt wanneer u dia's rendert naar [PNG](/slides/nl/net/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/net/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/net/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/net/convert-powerpoint-to-video/).

Houd de volgende punten in gedachten:

- Geëxporteerde afbeeldingen en PDF‑bestanden zijn niet interactief. Het object kan na export niet door de kijker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, licht‑rig, materiaal, extrusie, vulling en diavergroting.
- Als u geërfde of themagebaseerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vormeigenschappen](/slides/nl/net/shape-effective-properties/).
- Sommige uitvoerformaten kunnen de bewerkbare PowerPoint‑3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **Veelgestelde vragen**

### Kan Aspose.Slides interactieve 3D‑presentaties maken?

Aspose.Slides creëert en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt van geëxporteerde afbeeldingen, PDF‑bestanden of HTML‑pagina's geen interactieve 3D‑scènes die een kijker kan roteren. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint wanneer het formaat dit ondersteunt.

### Wat is het verschil tussen een 3D‑model en een 3D‑effect?

Een 3D‑model is een apart 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, bevel, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

### Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?

Minstens moeten een camera‑rotatie en ofwel extrusie of diepte worden ingesteld. In de praktijk stelt u ook een licht‑rig en materiaal in zodat de gerenderde vlakken duidelijke hooglichten en schaduwen hebben.

### Kan ik 3D‑effecten toepassen op zowel vormen als tekst?

Ja. Gebruik [IShape.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/properties/threedformat) voor het lichaam van de vorm en [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/properties/threedformat) voor tekst.

### Zullen 3D‑effecten verschijnen bij het exporteren naar afbeeldingen, PDF, HTML of videoframes?

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

### Kan ik de uiteindelijke 3D‑waarden lezen nadat overerving en themainstellingen zijn toegepast?

Ja. Gebruik de API's voor effectieve opmaak beschreven in [Shape Effective Properties](/slides/nl/net/shape-effective-properties/) om de uiteindelijke camera-, licht‑rig-, bevel‑ en gerelateerde 3D‑waarden te lezen.