---
title: Skapa 3D‑effekter i presentationer med .NET
linktitle: 3D‑presentation
type: docs
weight: 232
url: /sv/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑presentation
- 3D‑rotation
- 3D‑djup
- 3D‑extrudering
- 3D‑gradient
- 3D‑text
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Applicera och rendera 3D‑effekter för PowerPoint‑former och -text i .NET med Aspose.Slides. Konfigurera kamera, belysning, material, extrusion, fyllningar och 3D‑text."
---
## **Översikt**

Aspose.Slides för .NET kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Den här artikeln täcker 3D‑effekter såsom rotation, extrusion, fasydningar, belysning, material, gradient‑ eller bildfyllningar samt 3D‑text.

{{% alert color="primary" %}}
Den här artikeln handlar om 3D‑formaterings‑effekter på PowerPoint‑former och -text. Den handlar inte om att infoga eller redigera fristående 3D‑modellfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utmatningen.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd egenskapen [IShape.ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/properties/threedformat) för att applicera 3D‑formatering på en form. Egenskapen exponerar [IThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat), som styr 3D‑scenen för den formen.

För text, använd egenskapen [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/properties/threedformat). Detta applicerar 3D‑formatering på textramen istället för på formens kropp.

De viktigaste egenskaperna är:

| Egenskap | Vad den styr | När den ska användas |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/camera) | Vypunkt, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑utrymme eller matcha en förinställd 3D‑rotation i PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/lightrig) | Ljusförinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [Material](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/material) | Ytmaterial, t.ex. platt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, glansigare eller metallisk ut. |
| [ExtrusionHeight](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/extrusionheight) | Hur långt formen sträcker sig bakåt från sin framsida. | Omvandla en platt form till ett synligt tjockt 3D‑objekt. |
| [ExtrusionColor](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Färg på de extruderade sidorna. | Gör djupet synligt eller samordna sidornas färg med framlidets fyllning. |
| [Depth](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/depth) | Ytterligare 3D‑djup som används av PowerPoints 3D‑formatering. | Finjustera djupet för former eller text, särskilt i kombination med fasydnings‑ och materialinställningar. |
| [BevelTop](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/bevelbottom) | Upphöjda eller avrundade kanter på fram- och baksidan. | Lägg till en mjukad eller formad kant istället för en skarp platt yta. |
| [ContourColor](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/contourwidth) | Kontur runt 3D‑objektet. | Betona objektets gräns i den renderade utmatningen. |

## **Skapa en 3D‑form**

En form brukar behöva fyra typer av inställningar innan den ser övertygande 3D‑ut.

- Kamerainställningar, eftersom standardframsidan kan dölja extrusionen.
- Ljuseinställningar, eftersom belysning gör ytor och sidor läsbara.
- Materialinställningar, eftersom ytan påverkar hur ljus renderas.
- Extrusion‑ eller djupinställningar, eftersom en platt form saknar tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess framsida, applicerar 3D‑formatering, sparar presentationen som PPTX och renderar bilden till en PNG‑fil.

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

Den renderade bildsliden visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på framsidan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation från panelen 3‑D‑Rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar den rotation du anger via kamerans API.

![PowerPoint‑panelen 3‑D‑Rotation med X‑, Y‑ och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides ställer du in kameratyp och rotation via [IThreeDFormat.Camera](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/camera):

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Använd kameran när du behöver ändra hur betraktaren ser objektet. Det ändrar inte 2D‑formgeometrin på bilden. Det ändrar 3D‑vyerpunkten som används av PowerPoint och av Aspose.Slides vid rendering.

## **Lägg till extrusion och djup**

Extrusion får en form att se tjock ut genom att den sträcks bakom framsidan. I PowerPoint styr djupkontrollen den synliga tjockleken, och färgkontrollen anger färgen på sidoytorna.

![PowerPoint‑djupkontroller mappade till extrusion‑färg‑ och extrusion‑höjd‑egenskaper](img_02_02.png)

Ställ in [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/extrusionheight) för tjockleken och [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/extrusioncolor) för sidofärgen:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Använd [IThreeDFormat.Depth](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/depth) när du behöver arbeta med PowerPoints djupvärde direkt eller kombinera djup med fasydning, material och texteffekter. I många form‑scenarier är `ExtrusionHeight` den tydligare inställningen eftersom den direkt uttrycker den synliga extrusionen.

## **Använd gradient‑ eller bildfyllningar med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan applicera en solid färg, gradient, mönster eller bildfyllning på framsidan och fortfarande använda samma kamera-, ljus-, material- och extrusion‑inställningar.

Detta exempel applicerar en gradientfyllning på formen och en mörkare extrusion‑färg på sidorna:

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

Den renderade utmatningen behåller gradienten på framsidan och renderar extrusionen separat:

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrusion](img_02_03.png)

För att använda en bildfyllning istället, lägg till bilden i presentationen och tilldela den till formens fyllning:

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

Bilden renderas på framsidan, medan extrusionen renderas som den 3D‑sidoytan:

![Renderad 3D‑rektangel med ett foto‑fyllning på framsidan och orange extrusion](img_02_04.png)

## **Applicera 3D‑formatering på text**

Formens 3D‑formatering påverkar formens kropp. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där själva bokstäverna behöver extrusion, material, belysning och kamerainställningar.

Följande exempel skapar text med en mönsterfyllning, applicerar en WordArt‑transformering och konfigurerar 3D‑inställningar på [ITextFrameFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat):

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

Texten renderas som böjd, extruderad 3D‑bokstav:

![Renderad 3D‑text med en bågformad WordArt‑transformering, orange mönsterfyllning och mörk extrusion](img_02_05.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering vid sparande till PowerPoint‑format såsom PPTX. Vid rendering eller export till fast‑layout‑format rasteriseras 3D‑scenen eller ritas in i resultatet som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/net/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/net/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/net/convert-powerpoint-to-html/), eller genererar bildrutor för [videokonvertering](/slides/sv/net/convert-powerpoint-to-video/).

Kom ihåg följande punkter:

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutliga utseendet beror på kombinationen av kamera, ljusrigg, material, extrusion, fyllning och bildskalning.
- Om du behöver granska ärvda eller temabaserade formateringsvärden, läs [effektiva formegenskaper](/slides/sv/net/shape-effective-properties/).
- Vissa exportformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stöder det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller -text, som rotation, extrusion, fasydning, belysning och material. Den här artikeln täcker 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Som minimum ska du ställa in en kamerarotation och antingen extrusion eller djup. I praktiken bör du också ange en ljusrigg och material så att de renderade ytorna får tydliga högdagrar och skuggor.

**Kan jag applicera 3D‑effekter på både former och text?**

Ja. Använd [IShape.ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/properties/threedformat) för formens kropp och [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/properties/threedformat) för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videobildrutor?**

Ja. Aspose.Slides renderar 3D‑effekter när slide‑bilder, PDF‑utmatning, HTML‑utmatning och bildrutor för videokonvertering skapas. Den exporterade utmatningen innehåller det renderade utseendet, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutgiltiga 3D‑värdena efter att arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API‑erna som beskrivs i [Shape Effective Properties](/slides/sv/net/shape-effective-properties/) för att läsa slutgiltiga kamera‑, ljusrigg‑, fasydnings‑ och relaterade 3D‑värden.