---
title: Maak 3D-effecten in presentaties met .NET
linktitle: 3D-presentatie
type: docs
weight: 232
url: /nl/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentatie
- 3D-rotatie
- 3D-diepte
- 3D-extrusie
- 3D-kleurverloop
- 3D-tekst
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas 3D-effecten toe en render ze voor PowerPoint-vormen en -tekst in .NET met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides voor .NET kan 3D‑opmaak in PowerPoint‑stijl voor vormen en tekst maken, bewerken, behouden en renderen. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, schuine randen, verlichting, materiaal, kleurverloop‑ of afbeeldingsvullingen en 3D‑tekst.

{{% alert color="primary" %}}
Dit artikel gaat over 3D‑opmaakeffecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van losse 3D‑modelbestanden. Wanneer je een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **Concepten voor 3D‑opmaak**

Gebruik de eigenschap [IShape.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/properties/threedformat) om 3D‑opmaak op een vorm toe te passen. Deze eigenschap biedt toegang tot [IThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruik je de eigenschap [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/properties/threedformat). Hiermee wordt 3D‑opmaak op het tekstframe toegepast in plaats van op het vormlichaam.

De belangrijkste eigenschappen zijn:

| Eigenschap | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/camera) | Standpunt, vooringestelde cameratype, rotatie, zoom en perspectief. | Roteer het object in de 3D‑ruimte of stem overeen met een vooringestelde 3D‑rotatie in PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/lightrig) | Vooraf ingestelde verlichting, richting en rotatie van het licht. | Verander hoe hooglichten en schaduwen verschijnen op het 3D‑oppervlak. |
| [Material](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/material) | Oppervlakmateriaal, zoals vlak, mat, plastic of metaal. | Laat dezelfde geometrie er vlakker, zachter, glanzender of metalen uitzien. |
| [ExtrusionHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusionheight) | Hoe ver de vorm achterwaarts uitstrekt vanaf de voorzijde. | Verander een platte vorm in een duidelijk dik 3D‑object. |
| [ExtrusionColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Kleur van de uitgeschoven zijden. | Maak diepte zichtbaar of stem de kleur van de zijkant af op de voorzijde‑vulling. |
| [Depth](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/depth) | Aanvullende 3D‑diepte die PowerPoint‑3D‑opmaak gebruikt. | Fijn-afstemmen van diepte voor vormen of tekst, vooral in combinatie met schuine randen en materiaalinstellingen. |
| [BevelTop](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/beveltop) en [BevelBottom](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/bevelbottom) | Verhoogde of afgeronde randen op de voor‑ en achtervlakken. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe platte vlak. |
| [ContourColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/contourcolor) en [ContourWidth](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/contourwidth) | Omtrek rond het 3D‑object. | Benadruk de rand van het object in de gerenderde output. |

## **Een 3D‑vorm maken**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D lijkt:

- Camerainstellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Verlichtingsinstellingen, omdat verlichting de vlakken en zijkanten beter leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak beïnvloedt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde, past 3D‑opmaak toe, slaat de presentatie op als PPTX en rendert de dia naar een PNG‑afbeelding.

```csharp
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

De gerenderde dia‑afbeelding toont de rechthoek als een dikke 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorzijde](img_01_01.png)

## **Een vorm roteren met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het paneel 3‑D‑rotatie. De X-, Y- en Z‑rotatiewaarden komen overeen met de rotatie die je via de camera‑API instelt.

![PowerPoint‑paneel 3‑D‑rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides stel je het cameratype en de rotatie in via [IThreeDFormat.Camera](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/camera):

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Gebruik de camera wanneer je moet wijzigen hoe de kijker het object ziet. Het verandert niet de 2D‑vormgeometrie op de dia. Het wijzigt het 3D‑zichtpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Extrusie en diepte toevoegen**

Extrusie laat een vorm dikker lijken door deze achter de voorzijde uit te strekken. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en de kleur‑instelling bepaalt de kleur van de zijkanten.

![PowerPoint‑diepte‑instellingen gekoppeld aan de eigenschappen extrusiekleur en extrusiehoogte](img_02_02.png)

Stel [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusionheight) in voor de dikte en [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusioncolor) voor de kleur van de zijkanten:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Gebruik [IThreeDFormat.Depth](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/depth) wanneer je direct met de diepte‑waarde van PowerPoint moet werken of diepte wilt combineren met schuine randen, materiaal en texteffecten. In veel vormscenario's is `ExtrusionHeight` de duidelijkere instelling omdat deze de zichtbare extrusie direct weergeeft.

## **Kleurverloop‑ of afbeeldingsvullingen gebruiken met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. Je kunt een effen kleur, kleurverloop, patroon of afbeeldingsvulling op de voorzijde toepassen en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een kleurverloopvulling op de vorm toe en een donkerdere extrusiekleur op de zijkanten:

```csharp
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

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje kleurverloop en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingsvulling te gebruiken, voeg je de afbeelding toe aan de presentatie en wijs je deze toe aan de vormvulling:

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **3D‑opmaak toepassen op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstframe. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een patroonvulling, past een WordArt‑transformatie toe en configureert 3D‑instellingen op [ITextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat):

```csharp
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

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Export- en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan in PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de output getekend als een 2D‑resultaat. Dit geldt wanneer je dia's rendert naar [PNG](/slides/nl/net/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/net/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/net/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/net/convert-powerpoint-to-video/).

- Exported afbeeldingen en PDF‑bestanden zijn niet interactief. Het object kan door de kijker na export niet meer worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtinstallatie, materiaal, extrusie, vulling en dia‑schaling.
- Als je erven of themagerelateerde opmaakwaarden wilt inspecteren, lees dan de [effective shape properties](/slides/nl/net/shape-effective-properties/).
- Sommige outputformaten kunnen bewerkbare PowerPoint‑3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides creëert en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geen van de geëxporteerde afbeeldingen, PDF‑bestanden of HTML‑pagina's interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint, mits het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, schuine rand, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet je een camera‑rotatie en ofwel extrusie of diepte instellen. In de praktijk stel je ook een lichtinstallatie en materiaal in zodat de gerenderde vlakken duidelijke hooglichten en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [IShape.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/properties/threedformat) voor het vormlichaam en [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/properties/threedformat) voor tekst.

**Zullen 3D‑effecten verschijnen bij export naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het maken van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor videoconversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de definitieve 3D‑waarden lezen nadat er erfelijkheid en themainstellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API’s die worden beschreven in [Shape Effective Properties](/slides/nl/net/shape-effective-properties/) om de definitieve camera‑, lichtinstallatie‑, schuine‑rand‑ en gerelateerde 3D‑waarden te lezen.