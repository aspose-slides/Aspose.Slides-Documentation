---
title: Skapa och tillämpa WordArt‑effekter i .NET
linktitle: WordArt
type: docs
weight: 110
url: /sv/net/wordart/
keywords:
- WordArt
- skapa WordArt
- WordArt‑mall
- WordArt‑effekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- WordArt‑transformation
- 3D‑effekt
- yttre skuggeffekt
- inre skuggeffekt
- .NET
- C#
- Aspose.Slides
description: "Skapa och anpassa WordArt‑effekter i Aspose.Slides för .NET. Denna steg‑för‑steg‑guide hjälper utvecklare att förbättra presentationer med professionell text i C#."
---
## **Översikt**

WordArt‑effekter låter dig formatera text med fyllningar, konturer, skuggor, reflektioner, glöd, transformationer och 3D‑formatering. Den här artikeln förklarar hur du skapar och anpassar dessa effekter i PowerPoint‑presentationer med Aspose.Slides för .NET, utan att Microsoft Office är installerat.

## **Skapa en enkel WordArt‑mall och tillämpa den på text**

Följande exempel bygger en enkel WordArt‑stil genom att ange text, teckensnitt, mönsterfyllning och kontur.

Varje exempel skapar en ny presentation och lägger till en rektangel på den första bilden; ingen indatafil krävs. Det första exemplet sätter texten till "Aspose.Slides". Formens position och dimensioner mäts i punkter:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Ställ in teckensnittet till Arial Black med 36 punkter för att göra formateringen mer tydlig:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

Applicera ett [SmallGrid](https://reference.aspose.com/slides/sv/net/aspose.slides/patternstyle/)‑mönster med en mörkorange förgrund och en vit bakgrund, lägg sedan till en svart textkontur med en bredd på 1 punkt:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Den resulterande texten:

![Den enkla WordArt‑mallen](WordArt_template.png)

## **Applicera andra WordArt‑effekter**

Följande exempel demonstrerar hur man applicerar skuggor, reflektioner, glöd, transformationer och 3D‑effekter på text.

### **Applicera yttre skuggeffekter**

En yttre skugga ger djup genom att placera en skugga bakom texten. Du kan anpassa dess färg, riktning, avstånd, oskärpediameter, skala och skevning.

Detta exempel anropar [EnableOuterShadowEffect](https://reference.aspose.com/slides/sv/net/aspose.slides/effectformat/enableoutershadoweffect/) och ställer in en svart skugga med en oskärpediameter på 4 punkter, en riktning på 230 grader och ett avstånd på 30 punkter. Skalavärden på 100 bevarar skuggans storlek, medan horisontell skevning lutar den 20 grader. Alfa‑transformen sätter dess opacitet till 32 %:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

Den resulterande texten:

![Yttre skuggeffekten](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- När yttre och förinställda skuggor används tillsammans appliceras endast den yttre skuggan.
- Om yttre och inre skuggor används samtidigt beror den resulterande effekten på PowerPoint‑versionen. Till exempel, i PowerPoint 2013 dubbleras effekten, medan i PowerPoint 2007 appliceras endast den yttre skuggan.
{{% /alert %}}

### **Applicera reflektionseffekter**

En reflektion skapar en spegelvänd kopia av texten. Justera dess position, skala, oskärpa och opacitet för att kontrollera dess utseende.

Detta exempel anropar [EnableReflectionEffect](https://reference.aspose.com/slides/sv/net/aspose.slides/effectformat/enablereflectioneffect/) och vänder reflektionen vertikalt med en skala på -100 %. Det använder en oskärpediameter på 0,5 punkt och ett avstånd på 4,72 punkt. Opaciteten minskar från 60 % till 0,9 % mellan positionerna 0 % och 60 % längs reflektionen:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
```

Den resulterande texten:

![Reflektionseffekten](reflection_effect.png)

### **Applicera glödeffekter**

En glöd lägger till en mjuk färgad kontur runt texten. Justera dess färg, opacitet och radie för att kontrollera effekten.

Detta exempel anropar [EnableGlowEffect](https://reference.aspose.com/slides/sv/net/aspose.slides/effectformat/enablegloweffect/) och applicerar en röd glöd med 54 % opacitet och en radie på 7 punkter:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Den resulterande texten:

![Glödeffekten](glow_effect.png)

### **Applicera WordArt‑transformationer**

WordArt‑transformationer böjer, sträcker eller förvränger ett textblock.

Ställ in [Transform](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat/transform/) till [ArchUpPour](https://reference.aspose.com/slides/sv/net/aspose.slides/textshapetype/) för att böja hela textramen uppåt:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Den resulterande texten:

![WordArt‑transformationen](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides för .NET tillhandahåller ett antal fördefinierade [transformationstyper](https://reference.aspose.com/slides/sv/net/aspose.slides/textshapetype/).
{{% /alert %}}

### **Applicera 3D‑effekter på former och text**

Du kan applicera 3D‑effekter på en form eller på dess text. Avfasningar, extrudering, belysning och kamerainställningar styr det resulterande utseendet.

Följande exempel använder [ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/) för att lägga till cirkulära avfasningar, orange extrudering och en mörkröd kontur på rektangeln. Avfasningsdimensioner, extruderingshöjd, konturbredd och djup mäts i punkter. Ett plastmaterial, balanserad belysning roterad 40 grader runt Z‑axeln och en perspektivkamera definierar dess utseende:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
autoShape.TextFrame.Text = "Aspose.Slides";

autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Den resulterande formen:

![Formens 3D‑effekt](shape_3D_effect.png)

Detta exempel tillämpar liknande 3D‑formatering på texten via [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat/threedformat/). Mindre avfasningar formar bokstavskanten, medan extrudering och belysning ger texten djup:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";

textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Den resulterande texten:

![Textens 3D‑effekt](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Tillämpning av 3D‑effekter på text eller deras former — och interaktionen mellan dessa effekter — styrs av specifika regler. Tänk på en scen som involverar både text och den form som innehåller den. En 3D‑effekt inkluderar objektets 3D‑representation och scenen den placeras i.

- Om en scen är inställd för både formen och texten får formens scen prioritet och textens scen ignoreras.
- Om formen saknar egen scen men har en 3D‑representation används textens scen.
- Om formen inte har någon 3D‑effekt överhuvudtaget behandlas den som platt, och 3D‑effekten tillämpas endast på texten.

Dessa beteenden relaterar till egenskaperna [ThreeDFormat.LightRig](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/lightrig/) och [ThreeDFormat.Camera](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

För att hålla texten platt och läsbar samtidigt som du behåller formens 3D‑formatering, se [Behåll text platt på en 3D‑form](/slides/sv/net/3d-presentation/) för en jämförelse av båda inställningarna och ett komplett C#‑exempel.

## **Vanliga frågor**

**Kan jag använda WordArt‑effekter med olika typsnitt eller skript (t.ex. arabiska, kinesiska)?**

Ja, Aspose.Slides för .NET stödjer Unicode och fungerar med alla vanliga typsnitt och skript. WordArt‑effekter som skugga, fyllning och kontur kan appliceras oavsett språk, även om typsnitts‑tillgänglighet och rendering kan bero på systemets typsnitt.

**Kan jag applicera WordArt‑effekter på bildmaster‑element?**

Ja, du kan applicera WordArt‑effekter på former i bildmaster, inklusive titel‑platshållare, sidfötter eller bakgrundstext. Ändringar som görs i masterlayouten kommer att återspeglas i alla associerade bilder.

**Påverkar WordArt‑effekter filstorleken på presentationen?**

Lite grann. WordArt‑effekter som skuggor, glöd och gradientfyllningar kan något öka filstorleken på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbar.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera bilder som innehåller WordArt till bildformat (t.ex. PNG, JPEG) med hjälp av [ISlide.GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/), eller rendera enskilda former med [IShape.GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/getimage/). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.