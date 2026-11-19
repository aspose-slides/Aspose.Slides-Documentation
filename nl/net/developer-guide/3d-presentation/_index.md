---
title: Maak 3D-effecten in presentaties met .NET
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

Aspose.Slides voor .NET kan 3D‑opmaak in PowerPoint‑stijl maken, bewerken, behouden en weergeven voor vormen en tekst. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, afschuiningen, verlichting, materiaal, verloop‑ of afbeeldingvullingen en 3D‑tekst.

{{% alert color="info" title="Note" %}}
Dit artikel gaat over 3D‑opmaak‑effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van afzonderlijke 3D‑modelbestanden. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑uitvoer.
{{% /alert %}}

## **Concepten voor 3D‑opmaak**

Gebruik de [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat)‑eigenschap om 3D‑opmaak toe te passen op een vorm. Deze eigenschap geeft toegang tot [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat), die de 3D‑scene voor die vorm regelt.

Voor tekst gebruikt u de [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat)‑eigenschap. Hiermee wordt 3D‑opmaak toegepast op het tekstkader in plaats van op het vormlichaam.

De belangrijkste eigenschappen zijn:

| Eigenschap | Waar het controleert | Wanneer te gebruiken |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | Kijkpunt, vooraf ingestelde cameratypen, rotatie, zoom en perspectief. | Het object roteren in 3D‑ruimte of een PowerPoint‑3D‑rotatie‑preset nabootsen. |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | Lichtvoorkeur, richting en lichtrotatie. | Wijzigen hoe hoogtepunten en schaduwen op het 3D‑oppervlak verschijnen. |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | Oppervlakte‑materiaal, zoals vlak, mat, plastic of metaal. | Dezelfde geometrie er vlakker, zachter, glanzender of metalischer uit laten zien. |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | Hoe ver de vorm naar achteren uitschuift vanaf de voorkant. | Een vlakke vorm omtoveren tot een duidelijk dik 3D‑object. |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Kleur van de geëxtrudeerde zijkanten. | Diepte zichtbaar maken of de kleur van de zijkanten afstemmen op de vulkleur van de voorkant. |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | Extra 3D‑diepte gebruikt door PowerPoint‑3D‑opmaak. | De diepte van vormen of tekst nauwkeurig afstellen, vooral in combinatie met afschuiningen en materiaalinstellingen. |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) en [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | Verhoogde of afgeronde randen op de voor‑ en achterkant. | Een zachtere of gevormde rand toevoegen in plaats van een scherpe, vlakke rand. |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) en [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | Omlijning rond het 3D‑object. | De grens van het object benadrukken in de gerenderde output. |

## **Maak een 3D‑vorm**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D oogt:

- Camera‑instellingen, omdat de standaard voorkantweergave de extrusie kan verbergen.
- Lichtinstellingen, omdat verlichting de vlakken en zijkanten leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak invloed heeft op hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een vlakke vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorkant en past 3D‑opmaak toe. De camerarotatiewaarden staan in graden en de extrusiehoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding met tweemaal de standaardafmetingen en slaat de presentatie op als PPTX.

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

De gerenderde dia-afbeelding toont de rechthoek als een dik 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorkant](img_01_01.png)

## **Roteer een vorm met de camera**

In PowerPoint wordt 3D‑rotatie ingesteld via het paneel 3‑D‑rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u via de camera‑API instelt.

![PowerPoint‑paneel 3‑D‑rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides krijgt u toegang tot de camera via [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera). Dit voorbeeld maakt een rechthoek, selecteert een orthografisch frontaanzicht en zet de X‑, Y‑ en Z‑rotaties respectievelijk op 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Gebruik de camera wanneer u de manier wilt aanpassen waarop de kijker het object ziet. Het verandert niet de 2D‑vormgeometrie op de dia. Het wijzigt het 3D‑viewpoint dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

### **Kopieer camera‑oriëntatie van een sjabloonvorm**

Om een vorm in een sjabloon overeen te laten komen, kopieert u de [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/)‑preset en leest u de hoeken met [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/). Het voorbeeld opent `template.pptx`, leest de camera van de eerste vorm op de eerste dia en past de oriëntatie toe op de tweede vorm. Beide vormen hebben al 3D‑verlichting, en de tweede vorm heeft geen expliciete camerrotatie.

De hoeken staan in graden. Index `0` is breedtegraad, index `1` is lengtegraad en index `2` is omwenteling. Geef ze in die volgorde door aan [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/). Als de bron `null` retourneert, heeft deze geen expliciete rotatie, dus laat u de hoeken van de tweede vorm ongewijzigd. Een expliciete rotatie van `(0, 0, 0)` geeft drie nullen terug en moet worden gekopieerd.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

Wanneer u `camera-copy.pptx` opnieuw opent, hebben beide vormen dezelfde camera‑preset en rotatie. In PowerPoint gebruikt de pijl aan de rechterkant de camera‑oriëntatie die van de rechthoek aan de linkerkant is gekopieerd. Beide vormen gebruiken dezelfde verlichting en extrusiediepte.

![Een blauwe 3D‑rechthoek en een rechts‑wijzende pijl met overeenkomende camera‑oriëntatie, bekeken van boven en van rechts](camera-orientation.png)

## **Voeg extrusie en diepte toe**

Extrusie zorgt ervoor dat een vorm dik lijkt door deze achter de voorkant uit te breiden. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en de kleur‑instelling bepaalt de kleur van de zijkanten.

![PowerPoint-diepte‑instellingen gekoppeld aan eigenschappen voor extrusiekleur en extrusiehoogte](img_02_02.png)

Stel [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) in voor de dikte en [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) voor de kleur van de zijkanten. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijkanten en roteert de camera om de dikte te onthullen. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

De eigenschap [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) stelt de diepte van een 3D‑vorm in. De eigenschap [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) regelt de hoogte van het extrusie‑effect, zoals in dit voorbeeld wordt getoond.

## **Gebruik verloop‑ of afbeeldingvullingen met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeeldingvulling op de voorkant toepassen en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauw‑naar‑oranje verloop toe op de voorkant en een donkeroranje kleur op de 150‑punts extrusie. De verloopstops bij 0 en 100 geven respectievelijk het begin en einde van het verloop aan. De camerarotatiewaarden staan in graden. De dia wordt gerenderd naar een PNG‑afbeelding met tweemaal de standaardafmetingen:

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

De gerenderde output behoudt het verloop op de voorkant en rendert de extrusie apart:

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en wijst u deze toe aan de vormvulling. Dit voorbeeld vereist een bestaand bestand met de naam "image.jpg" in de werkmap. Het rekent de afbeelding uit om de rechthoek te vullen, past een extrusie van 150 punten toe en stelt de camerarotatie in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

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

De afbeelding wordt gerenderd op de voorkant, terwijl de extrusie wordt weergegeven als het 3D‑zijoppervlak:

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorkant en oranje extrusie](img_02_04.png)

## **Pas 3D‑opmaak toe op tekst**

3D‑opmaak van een vorm heeft invloed op het vormlichaam. 3D‑opmaak van tekst heeft invloed op het tekstkader. Dit is nuttig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑en‑wit rasterpatroon, past een opwaartse boog toe en configureert 3D‑instellingen via [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). De extrusiehoogte en diepte staan in punten, en de lichtrotatie in graden. De vormvulling en -omtrek zijn verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding met tweemaal de standaarddia‑afmetingen en slaat de presentatie op als PPTX:

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

## **Houd tekst plat op een 3D‑vorm**

Om tekst leesbaar te houden terwijl de 3D‑uiterlijk van een vorm behouden blijft, stelt u [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) in via [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/). Wanneer de waarde `true` is, blijft de tekst buiten de 3D‑scene. Wanneer deze `false` is, neemt de tekst deel aan de scene en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert de 3D‑opmaak van de vorm niet: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/). Het verschilt ook van gewone rotatie. [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) roteert de vorm in het dia‑vlak, terwijl [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) de aangepaste rotatie van de tekst binnen de omhullende doos regelt. Het buiten de 3D‑scene houden van de tekst zet geen van die hoeken terug.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstinstelling verschilt: `false` links en `true` rechts. De camerahoeken staan in graden en de extrusiehoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingsdia naar PNG met tweemaal de standaardafmetingen.

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

## **Export‑ en render‑gedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de output getekend als een 2D‑resultaat. Dit geldt wanneer u dia's rendert naar [PNG](/slides/nl/net/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/net/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/net/convert-powerpoint-to-html/), of frames genereert voor [video‑conversie](/slides/nl/net/convert-powerpoint-to-video/).

Houd de volgende punten in gedachten:

- Geëxporteerde afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet door de kijker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtrig, materiaal, extrusie, vulling en schaal van de dia.
- Als u geërfde of thema‑gebaseerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vorm‑eigenschappen](/slides/nl/net/shape-effective-properties/).
- Sommige uitvoerformaten kunnen de bewerkbare PowerPoint‑3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geëxporteerde afbeeldingen, PDF’s of HTML‑pagina’s geen interactieve 3D‑scènes die een kijker kan roteren. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint waar het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een apart 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, afschuining, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet u een camerarotatie en ofwel een extrusie of diepte instellen. In de praktijk stelt u ook een lichtrig en materiaal in zodat de gerenderde vlakken duidelijke hooglichten en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) voor het vormlichaam en [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) voor tekst.

**Zullen 3D‑effecten verschijnen bij het exporteren naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het genereren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat erfelijkheid en thema‑instellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API's beschreven in [Shape Effective Properties](/slides/nl/net/shape-effective-properties/) om de uiteindelijke camera‑, lichtrig‑, afschuinings‑ en gerelateerde 3D‑waarden te lezen.