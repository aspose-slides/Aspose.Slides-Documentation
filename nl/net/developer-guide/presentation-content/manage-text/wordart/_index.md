---
title: Maak en pas WordArt-effecten toe in .NET
linktitle: WordArt
type: docs
weight: 110
url: /nl/net/wordart/
keywords:
- WordArt
- WordArt maken
- WordArt-sjabloon
- WordArt-effect
- schaduw-effect
- reflectie-effect
- gloed-effect
- WordArt-transformatie
- 3D-effect
- buitenschaduw-effect
- interne schaduw-effect
- .NET
- C#
- Aspose.Slides
description: "Maak en pas WordArt-effecten aan in Aspose.Slides voor .NET. Deze stapsgewijze gids helpt ontwikkelaars presentaties te verbeteren met professionele tekst in C#."
---
## **Overzicht**

WordArt-effecten laten u tekst opmaken met vullingen, contouren, schaduwen, reflecties, gloed, transformaties en 3D-opmaak. Dit artikel legt uit hoe u deze effecten kunt maken en aanpassen in PowerPoint‑presentaties met Aspose.Slides voor .NET, zonder dat Microsoft Office geïnstalleerd is.

## **Maak een eenvoudige WordArt‑sjabloon en pas deze toe op tekst**

De volgende voorbeelden bouwen een eenvoudige WordArt‑stijl door de tekst, het lettertype, de patroonvulling en de contour in te stellen.

Elk voorbeeld maakt een nieuwe presentatie aan en voegt een rechthoek toe aan de eerste dia; er is geen invoerbestand nodig. Het eerste voorbeeld stelt de tekst in op "Aspose.Slides". De positie en afmetingen van de vorm worden gemeten in punten:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Stel het lettertype in op Arial Black met 36 punten zodat de opmaak duidelijker is:

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

Pas een [SmallGrid](https://reference.aspose.com/slides/nl/net/aspose.slides/patternstyle/) patroon toe met een donkeroranje voorgrond en een witte achtergrond, en voeg vervolgens een zwarte tekstcontour toe met een breedte van 1 punt:

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

De resulterende tekst:

![The simple WordArt template](WordArt_template.png)

## **Pas andere WordArt‑effecten toe**

### **Pas buitenschaduweffecten toe**

Een buitenschaduw voegt diepte toe door een schaduw achter de tekst te plaatsen. U kunt de kleur, richting, afstand, vervagingsradius, schaal en scheefstand aanpassen.

Dit voorbeeld roept [EnableOuterShadowEffect](https://reference.aspose.com/slides/nl/net/aspose.slides/effectformat/enableoutershadoweffect/) aan en stelt een zwarte schaduw in met een vervagingsradius van 4 punten, een richting van 230 graden en een afstand van 30 punten. Schaalwaarden van 100 behouden de grootte van de schaduw, terwijl horizontale scheefstand deze met 20 graden kantelt. De alfa‑transformatie zet de dekking op 32%:

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

De resulterende tekst:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Wanneer zowel buitenschaduwen als vooraf ingestelde schaduwen samen worden gebruikt, wordt alleen de buitenschaduw toegepast.
- Als buitenschaduwen en binnenschaduwen gelijktijdig worden gebruikt, hangt het resulterende effect af van de versie van PowerPoint. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld, terwijl in PowerPoint 2007 alleen de buitenschaduw wordt toegepast.
{{% /alert %}}

### **Pas reflectie‑effecten toe**

Een reflectie maakt een spiegelbeeld van de tekst. Pas de positie, schaal, vervaging en dekking aan om het uiterlijk te regelen.

Dit voorbeeld roept [EnableReflectionEffect](https://reference.aspose.com/slides/nl/net/aspose.slides/effectformat/enablereflectioneffect/) aan en keert de reflectie verticaal om met een schaal van -100%. Het gebruikt een vervagingsradius van 0,5 punt en een afstand van 4,72 punt. De dekking daalt van 60% naar 0,9% tussen posities 0% en 60% langs de reflectie:

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

De resulterende tekst:

![The Reflection effect](reflection_effect.png)

### **Pas gloed‑effecten toe**

Een gloed voegt een zachte gekleurde omtrek rond de tekst toe. Pas de kleur, dekking en straal aan om het effect te regelen.

Dit voorbeeld roept [EnableGlowEffect](https://reference.aspose.com/slides/nl/net/aspose.slides/effectformat/enablegloweffect/) aan en past een rode gloed toe met 54% dekking en een straal van 7 punten:

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

De resulterende tekst:

![The Glow effect](glow_effect.png)

### **Pas WordArt‑transformaties toe**

WordArt‑transformaties buigen, rekken of vervormen een blok tekst.

Stel [Transform](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat/transform/) in op [ArchUpPour](https://reference.aspose.com/slides/nl/net/aspose.slides/textshapetype/) om het volledige tekstkader omhoog te buigen:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

De resulterende tekst:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET biedt een reeks voorgedefinieerde [transformation types](https://reference.aspose.com/slides/nl/net/aspose.slides/textshapetype/).
{{% /alert %}}

### **Pas 3D‑effecten toe op vormen en tekst**

U kunt 3D‑effecten toepassen op een vorm of op de bijbehorende tekst. Afschuining, extrusie, verlichting en camerainstellingen bepalen het uiteindelijke uiterlijk.

Het volgende voorbeeld gebruikt [ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/) om ronde afschuiningen, oranje extrusie en een donkerrode contour aan de rechthoek toe te voegen. De afschuiningsafmetingen, extrusiehoogte, contourbreedte en diepte worden gemeten in punten. Een kunststofmateriaal, gebalanceerde verlichting die 40 graden draait rond de Z‑as, en een perspectiefcamera bepalen het uiterlijk:

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

De resulterende vorm:

![The shape 3D effect](shape_3D_effect.png)

Dit voorbeeld past een soortgelijke 3D‑opmaak toe op de tekst via [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat/threedformat/). Kleinere afschuiningen vormen de letterranden, terwijl extrusie en verlichting de tekst diepte geven:

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

De resulterende tekst:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
De toepassing van 3D‑effecten op tekst of hun vormen — en de interactie tussen deze effecten — wordt beheerst door specifieke regels. Beschouw een scène waarin zowel tekst als de vorm die de tekst bevat aanwezig zijn. Een 3D‑effect omvat de 3D‑representatie van het object en de scène waarin het zich bevindt.

- Als een scène is ingesteld voor zowel de vorm als de tekst, heeft de scène van de vorm voorrang en wordt de scène van de tekst genegeerd.
- Als de vorm geen eigen scène heeft maar wel een 3D‑representatie, wordt de scène van de tekst gebruikt.
- Als de vorm helemaal geen 3D‑effect heeft, wordt deze als plat beschouwd en wordt het 3D‑effect alleen op de tekst toegepast.

Deze gedragingen hebben betrekking op de eigenschappen [ThreeDFormat.LightRig](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/lightrig/) en [ThreeDFormat.Camera](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Om tekst plat en leesbaar te houden terwijl u de 3D‑opmaak van de vorm behoudt, zie [Keep Text Flat on a 3D Shape](/slides/nl/net/3d-presentation/) voor een vergelijking van beide instellingen en een volledig C#‑voorbeeld.

## **Veelgestelde vragen**

**Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides for .NET ondersteunt Unicode en werkt met alle belangrijke lettertypen en scripts. WordArt‑effecten zoals schaduw, vulling en contour kunnen worden toegepast ongeacht de taal, hoewel de beschikbaarheid van lettertypen en weergave afhankelijk kunnen zijn van de systeemlettertypen.

**Kan ik WordArt‑effecten toepassen op elementen van de masterdia?**

Ja, u kunt WordArt‑effecten toepassen op vormen op masterdia's, inclusief titel‑plaatsenhouders, voetteksten of achtergrondtekst. Wijzigingen die in de master‑lay‑out worden aangebracht, worden doorgevoerd in alle bijbehorende dia's.

**Hebben WordArt‑effecten invloed op de bestandsgrootte van de presentatie?**

Een beetje. WordArt‑effecten zoals schaduwen, glows en verloopvullingen kunnen de bestandsgrootte licht verhogen door toegevoegde opmaakmetadata, maar het verschil is doorgaans verwaarloosbaar.

**Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?**

Ja, u kunt dia's met WordArt renderen naar afbeeldingen (bijv. PNG, JPEG) met behulp van [ISlide.GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/), of individuele vormen renderen met [IShape.GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/getimage/). Hiermee kunt u het resultaat in het geheugen of op het scherm bekijken voordat u de volledige presentatie opslaat of exporteert.