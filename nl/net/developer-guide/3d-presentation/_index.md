---
title: 3D-effecten maken in presentaties met .NET
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
- 3D-verloop
- 3D-tekst
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas 3D-effecten toe en render ze voor PowerPoint-vormen en -tekst in .NET met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides for .NET kan PowerPoint-achtige 3D‑opmaak voor vormen en tekst maken, bewerken, bewaren en renderen. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, slagschijven, verlichting, materiaal, verloop‑ of afbeeldingvullingen en 3D‑tekst.

{{% alert color="info" title="Note" %}}
Dit artikel gaat over 3D‑opmaak‑effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van zelfstandige 3D‑modellen. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, renderen Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **3D‑opmaakconcepten**

Gebruik de eigenschap [IShape.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/properties/threedformat) om 3D‑opmaak toe te passen op een vorm. De eigenschap biedt toegang tot [IThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat), die de 3D‑scene voor die vorm regelt.

Voor tekst gebruikt u de eigenschap [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/properties/threedformat). Hiermee wordt 3D‑opmaak toegepast op het tekstkader in plaats van op het vormlichaam.

De belangrijkste eigenschappen zijn:

| Eigenschap | Waar het controleert | Wanneer te gebruiken |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/camera) | Kijkpunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Het object in 3D‑ruimte roteren of een PowerPoint‑rotatie‑preset gebruiken. |
| [LightRig](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/lightrig) | Lichtpreset, richting en rotatie van het licht. | Aanpassen hoe hooglichten en schaduwen op het 3D‑oppervlak verschijnen. |
| [Material](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/material) | Oppervlakte‑materiaal, zoals vlak, mat, plastic of metaal. | Eenzelfde geometrie er vlakker, zachter, glanzender of metallic uit laten zien. |
| [ExtrusionHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusionheight) | Hoe ver de vorm naar achteren uitstrekt vanaf de voorzijde. | Een platte vorm omvormen tot een duidelijk dik 3D‑object. |
| [ExtrusionColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Kleur van de uitgeknepen zijvlakken. | Diepte zichtbaar maken of de zijkleur afstemmen op de voorvulling. |
| [Depth](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/depth) | Extra 3D‑diepte die PowerPoint‑3D‑opmaak gebruikt. | Diepte fijn afstellen voor vormen of tekst, vooral in combinatie met slagschijven en materiaal. |
| [BevelTop](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/beveltop) en [BevelBottom](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/bevelbottom) | Verhoogde of afgeronde randen aan de voor‑ en achterkant. | Een verzachte of gevormde rand toevoegen i.p.v. een scherpe platte vlak. |
| [ContourColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/contourcolor) en [ContourWidth](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/contourwidth) | Omtrek rond het 3D‑object. | De objectgrens benadrukken in de gerenderde output. |

## **Een 3D‑vorm maken**

Een vorm heeft meestal vier soorten instellingen nodig voordat ze overtuigend 3D oogt:

- Camera‑instellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Licht‑instellingen, omdat verlichting de vlakken en zijden leesbaar maakt.
- Materiaal‑instellingen, omdat het oppervlak bepaalt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde en past 3D‑opmaak toe. De rotatiewaarden van de camera zijn in graden, en de extrusie‑hoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding met het dubbele van de standaardafmetingen en slaat de presentatie op als PPTX.

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

De gerenderde dia‑afbeelding toont de rechthoek als een dikke 3D‑blokken:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorzijde](img_01_01.png)

## **Een vorm roteren met de camera**

In PowerPoint wordt 3D‑rotatie ingesteld via het venster 3‑D‑rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u via de camera‑API instelt.

![PowerPoint‑venster 3‑D‑rotatie met X‑, Y‑ en Z‑rotatiewaarden gemarkeerd](img_02_01.png)

In Aspose.Slides krijgt u toegang tot de camera via [IThreeDFormat.Camera](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/camera). Dit voorbeeld maakt een rechthoek, selecteert een orthografisch vooraanzicht en stelt de X‑, Y‑ en Z‑rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Gebruik de camera wanneer u de weergave van het object wilt aanpassen. Het verandert niet de 2D‑geometrie van de vorm op de dia, maar wel het 3D‑kijkpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Extrusie en diepte toevoegen**

Extrusie maakt een vorm dik door deze achter de voorzijde uit te breiden. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en de kleur‑instelling bepaalt de kleur van de zijvlakken.

![PowerPoint‑diepte‑instellingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusionheight) in voor de dikte en [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusioncolor) voor de kleur van de zijkanten. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijden en roteert de camera om de dikte zichtbaar te maken. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

De eigenschap [IThreeDFormat.Depth](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/depth) bepaalt de diepte van een 3D‑vorm. De eigenschap [ExtrusionHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/properties/extrusionheight) regelt de hoogte van het extrusie‑effect, zoals in dit voorbeeld te zien is.

## **Verlopen of afbeeldingvullingen gebruiken met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeeldingvulling op de voorzijde toepassen en toch dezelfde camera, licht, materiaal en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauw‑naar‑oranje verloop toe op de voorzijde en een donkeroranje kleur op de 150‑punt‑extrusie. De verloopstops op 0 en 100 markeren het begin en einde van het verloop. De rotatiewaarden van de camera zijn in graden. De dia wordt gerenderd naar een PNG‑afbeelding met het dubbele van de standaardafmetingen:

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

De gerenderde output behoudt het verloop op de voorzijde en rendert de extrusie apart:

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om een afbeeldingvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en kent u deze toe aan de vormvulling. Dit voorbeeld vereist een bestaand bestand met de naam "image.jpg" in de werkmap. Het strekt de afbeelding uit om de rechthoek te vullen, past een extrusie van 150 punten toe en stelt de camera‑rotatie in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

De afbeelding wordt gerenderd op de voorzijde, terwijl de extrusie wordt weergegeven als het 3D‑zijvlak:

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **3D‑opmaak toepassen op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstkader. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑en‑witte rasterpatroon, past een opwaartse boog toe en configureert 3D‑instellingen via [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/properties/threedformat). De extrusie‑hoogte en diepte staan in punten, en de licht‑rotatie in graden. De vormvulling en omtrek zijn verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding met het dubbele van de standaarddia‑afmetingen en slaat de presentatie op als PPTX:

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

## **Tekst plat houden op een 3D‑vorm**

Om de tekst leesbaar te houden terwijl de vorm zijn 3D‑uiterlijk behoudt, stelt u [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/keeptextflat/) in via [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/textframeformat/). Wanneer de waarde `true` is, blijft de tekst buiten de 3D‑scene. Wanneer de waarde `false` is, neemt de tekst deel aan de scene en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert niet de 3D‑opmaak van de vorm: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [IShape.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/threedformat/). Het verschilt tevens van gewone rotatie. [IShape.Rotation](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/rotation/) roteert de vorm in het dia‑vlak, terwijl [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/rotationangle/) de aangepaste rotatie van de tekst binnen zijn begrenzingsvak bepaalt. Tekst buiten de 3D‑scene houden zet geen van beide hoeken terug.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstopstelling verschilt: `false` links en `true` rechts. De camera‑hoeken staan in graden en de extrusie‑hoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingdia naar PNG met het dubbele van de standaardafmetingen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

Links volgt de tekst de 3D‑oriëntatie. Rechts blijft de tekst plat en beter leesbaar. Beide rechthoeken behouden dezelfde zichtbare extrusie en 3D‑oriëntatie.

![Zij‑aan‑zij 3D‑rechthoeken: KeepTextFlat is false links en true rechts](keep_text_flat.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layout‑formaten wordt de 3D‑scene gerasterd of ingevoegd in de output als een 2D‑resultaat. Dit geldt wanneer u dia's rendert naar [PNG](/slides/nl/net/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/net/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/net/convert-powerpoint-to-html/), of frames genereert voor [videoconversie](/slides/nl/net/convert-powerpoint-to-video/).

Houd rekening met de volgende punten:

- Geëxporteerde afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet meer door de gebruiker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtset, materiaal, extrusie, vulling en schaal van de dia.
- Als u geërfde of thema‑gebaseerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vorm‑eigenschappen](/slides/nl/net/shape-effective-properties/).
- Sommige uitvoerformaten kunnen geen bewerkbare PowerPoint‑3D‑opmaak opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides creëert en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geen geëxporteerde afbeeldingen, PDF‑s of HTML‑pagina’s die interactieve 3D‑scènes zijn die een gebruiker kan roteren. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint wanneer het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, slagschijf, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet u een camera‑rotatie instellen en ofwel extrusie of diepte. In de praktijk stelt u ook een lichtset en materiaal in zodat de gerenderde vlakken duidelijke hooglichten en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [IShape.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/properties/threedformat) voor het vormlichaam en [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/properties/threedformat) voor tekst.

**Zien 3D‑effecten er uit bij export naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het maken van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor videoconversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat erfelijkheid en themainstellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Shape Effective Properties](/slides/nl/net/shape-effective-properties/) om de definitieve camera‑, lichtset‑, slagschijf‑ en gerelateerde 3D‑waarden te lezen.