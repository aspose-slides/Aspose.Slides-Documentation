---
title: Skapa 3D-effekter i presentationer med .NET
linktitle: 3D-presentation
type: docs
weight: 232
url: /sv/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentation
- 3D-rotation
- 3D-djup
- 3D-extrudering
- 3D-gradient
- 3D-text
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Applicera och rendera 3D-effekter för PowerPoint-former och text i .NET med Aspose.Slides. Konfigurera kamera, ljussättning, material, extrudering, fyllningar och 3D-text."
---
## **Översikt**

Aspose.Slides for .NET kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Den här artikeln täcker 3D‑effekter såsom rotation, extrudering, avfasningar, ljussättning, material, gradient‑ eller bildfyllningar och 3D‑text.

{{% alert color="info" title="Note" %}}
Den här artikeln handlar om 3D‑formateringseffekter på PowerPoint‑former och text. Det handlar inte om att infoga eller redigera fristående 3D‑modelfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utdata.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd egenskapen [IShape.ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/properties/threedformat) för att tillämpa 3D‑formatering på en form. Egenskapen exponerar [IThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat), som styr 3D‑scenen för den formen.

För text, använd egenskapen [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/properties/threedformat). Detta tillämpar 3D‑formatering på textramen istället för formens kropp.

De viktigaste egenskaperna är:

| Egenskap | Vad den styr | När den ska användas |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/camera) | Vypunkt, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑rymd eller matcha en PowerPoint‑3D‑rotationsförinställning. |
| [LightRig](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/lightrig) | Ljusförinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [Material](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/material) | Ytmaterial, t.ex. platt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, glansigare eller metallisk ut. |
| [ExtrusionHeight](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/extrusionheight) | Hur långt formen sträcker sig bakåt från dess främre yta. | Omvandla en platt form till ett tydligt tjockt 3D‑objekt. |
| [ExtrusionColor](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Färg på de extruderade sidorna. | Gör djupet synligt eller koordinera sidfärgen med framsidans fyllning. |
| [Depth](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/depth) | Ytterligare 3D‑djup som används av PowerPoint‑3D‑formatering. | Finjustera djupet för former eller text, särskilt tillsammans med avfasning‑ och materialinställningar. |
| [BevelTop](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/bevelbottom) | Upphöjda eller avrundade kanter på främre och bakre ytor. | Lägg till en mjukare eller formad kant istället för en skarp plan yta. |
| [ContourColor](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/contourwidth) | Kontur runt 3D‑objektet. | Betona objektets gräns i den renderade utdata. |

## **Skapa en 3D‑form**

En form behöver vanligtvis fyra typer av inställningar innan den ser övertygande 3D ut:

- Kamerainställningar, eftersom standardframåtriktad vy kan dölja extruderingen.
- Ljuseinställningar, eftersom ljussättningen gör ytorna och sidorna läsbara.
- Materialinställningar, eftersom ytan påverkar hur ljuset renderas.
- Extruderings‑ eller djupinställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess främre yta och tillämpar 3D‑formatering. Kamerarotationsvärdena är i grader och extruderingshöjden är 100 punkter. Exemplet renderar bilden till en PNG‑fil med dubbla standarddimensioner och sparar presentationen som PPTX.

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

Den renderade bildfilen visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på den främre ytan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation från panelen 3‑D‑Rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar den rotation du ställer in via kamerans API.

![PowerPoint‑panelen 3‑D‑Rotation med X‑, Y‑ och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides får du åtkomst till kameran via [IThreeDFormat.Camera](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/camera). Detta exempel skapar en rektangel, väljer en ortografisk framåtriktad vy och sätter dess X‑, Y‑ och Z‑rotationer till 20, 30 respektive 40 grader. Det konfigurerar formen i minnet utan att spara en fil:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Använd kameran när du behöver ändra hur betraktaren ser objektet. Den ändrar inte 2D‑geometrin för formen på bilden. Den ändrar 3D‑vy‑punkten som används av PowerPoint och av Aspose.Slides vid rendering.

## **Lägg till extrudering och djup**

Extrudering får en form att se tjock ut genom att den sträcks bakåt bakom den främre ytan. I PowerPoint styr djupkontrollen den synliga tjockleken och färgkontrollen sätter färgen på sidoytorna.

![PowerPoint‑djupkontroller mappade till egenskaperna extrusion‑färg och extrusion‑höjd](img_02_02.png)

Ange [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/extrusionheight) för tjockleken och [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/extrusioncolor) för sidfärgen. Detta exempel ger en rektangel en 100‑punkts extrudering med lila sidor och roterar kameran för att visa dess tjocklek. Det konfigurerar formen i minnet utan att spara en fil:

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

[IThreeDFormat.Depth](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/depth)‑egenskapen anger djupet för en 3D‑form. [ExtrusionHeight](https://reference.aspose.com/slides/sv/net/aspose.slides/ithreedformat/properties/extrusionheight)‑egenskapen styr höjden på extruderings‑effekten, som visas i detta exempel.

## **Använd gradient‑ eller bildfyllningar med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan applicera en solid färg, gradient, mönster eller bildfyllning på den främre ytan och fortfarande använda samma kamera-, ljus-, material- och extruderingsinställningar.

Detta exempel applicerar en blå‑till‑orange gradient på den främre ytan och en mörkorange färg på 150‑punkts extruderingen. Gradientstopp vid 0 och 100 markerar början och slutet på gradienten. Kamerarotationsvärdena är i grader. Bilden renderas till en PNG‑fil med dubbla standarddimensioner:

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

Den renderade utdata behåller gradienten på den främre ytan och renderar extruderingen separat:

![Renderad 3D‑rektangel med blå‑till‑orange gradientfyllning och orange extrudering](img_02_03.png)

För att istället använda en bildfyllning, lägg till bilden i presentationen och tilldela den till formens fyllning. Detta exempel kräver en befintlig fil med namnet "image.jpg" i arbetskatalogen. Bilden sträcks för att fylla rektangeln, en 150‑punkts extrudering appliceras och kamerarotationen sätts i grader. Det konfigurerar formen i minnet utan att spara eller rendera en fil:

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

Bilden renderas på den främre ytan, medan extruderingen renderas som 3D‑sidorna:

![Renderad 3D‑rektangel med fotofyllning på den främre ytan och orange extrudering](img_02_04.png)

## **Tillämpa 3D‑formatering på text**

Formens 3D‑formatering påverkar formkroppen. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där bokstäverna själva behöver extrudering, material, ljussättning och kamerainställningar.

Följande exempel skapar text med ett orange‑och‑vitt rutnätsmönster, applicerar en uppåtarbåge och konfigurerar 3D‑inställningar via [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/properties/threedformat). Extruderingshöjden och djupet är i punkter och ljusrotationen är i grader. Formens fyllning och kontur är dolda så att endast texten syns. Exemplet renderar en PNG‑fil med dubbla standardbilddimensioner och sparar presentationen som PPTX:

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

Texten renderas som böjda, extruderade 3D‑bokstäver:

![Renderad 3D‑text med en bågformad WordArt‑transform, orange mönsterfyllning och mörk extrudering](img_02_05.png)

## **Behåll text platt på en 3D‑form**

För att hålla texten läsbar samtidigt som formens 3D‑utseende bevaras, sätt [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/keeptextflat/) via [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/textframeformat/). När värdet är `true` hålls texten utanför 3D‑scenen. När det är `false` deltar texten i scenen och följer dess 3D‑orientering.

Denna inställning tar inte bort formens 3D‑formatering: dess kamera, ljussättning, material och extrudering förblir konfigurerade via [IShape.ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/threedformat/). Det skiljer sig också från vanlig rotation. [IShape.Rotation](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/rotation/) roterar formen i bildens plan, medan [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/rotationangle/) styr textens anpassade rotation inom sin begränsningsruta. Att hålla texten utanför 3D‑scenen återställer inte någon av dessa vinklar.

Det följande självständiga exemplet skapar en blå rektangel med text och klonar den bredvid originalet. Båda formerna har samma 3D‑formatering; endast textinställningen skiljer sig: `false` till vänster och `true` till höger. Kameravinklarna är i grader och extruderingshöjden är 40 punkter. Exemplet sparar presentationen som PPTX och renderar jämförelsesliden till PNG med dubbla standarddimensioner.

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

Till vänster följer texten 3D‑orienteringen. Till höger förblir den platt och lättare att läsa. Båda rektanglarna behåller samma synliga extrudering och 3D‑orientering.

![Sida‑vid‑sida 3D‑rektanglar: KeepTextFlat är false till vänster och true till höger](keep_text_flat.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering när du sparar till PowerPoint‑format som PPTX. Vid rendering eller export till layout‑fast format rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/net/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/net/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/net/convert-powerpoint-to-html/), eller genererar ramar för [video conversion](/slides/sv/net/convert-powerpoint-to-video/).

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrudering, fyllning och bildskalning.
- Om du behöver inspektera ärvda eller temabaserade formateringsvärden, läs [effektiva formegenskaper](/slides/sv/net/shape-effective-properties/).
- Vissa utdataformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stödjer det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller text, såsom rotation, extrudering, avfasning, ljussättning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Som minimum, ange en kamerarotation och antingen extrudering eller djup. I praktiken bör du även ange en ljusrigg och material så att de renderade ytorna har tydliga högdagrar och skuggor.

**Kan jag applicera 3D‑effekter på både former och text?**

Ja. Använd [IShape.ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/properties/threedformat) för formkroppen och [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframeformat/properties/threedformat) för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videoram?**

Ja. Aspose.Slides renderar 3D‑effekter när du producerar bildfiler för bilder, PDF‑utdata, HTML‑utdata och ramar som används för video‑konvertering. Den exporterade utdata innehåller den renderade utsikten, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutgiltiga 3D‑värdena efter att arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API:erna som beskrivs i [effektiva formegenskaper](/slides/sv/net/shape-effective-properties/) för att läsa den slutgiltiga kameran, ljusriggen, avfasningen och relaterade 3D‑värden.