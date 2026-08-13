---
title: Maak en pas WordArt‑effecten toe in .NET
linktitle: WordArt
type: docs
weight: 110
url: /nl/net/wordart/
keywords:
- WordArt
- WordArt maken
- WordArt‑sjabloon
- WordArt‑effect
- schaduweffect
- weergave‑effect
- gloeieffect
- WordArt‑transformatie
- 3D‑effect
- buitenste schaduw effect
- inner schaduw effect
- .NET
- C#
- Aspose.Slides
description: "Maak en personaliseer WordArt‑effecten in Aspose.Slides voor .NET. Deze stapsgewijze handleiding helpt ontwikkelaars presentaties te verbeteren met professionele tekst in C#."
---
## **Overzicht**

WordArt‑effecten stellen je in staat om visueel aantrekkelijke, gestileerde tekst toe te voegen aan je PowerPoint‑presentaties. Met Aspose.Slides for .NET kunnen ontwikkelaars programmatically WordArt maken, aanpassen en beheren, net zoals in Microsoft PowerPoint—zonder dat Office geïnstalleerd hoeft te zijn. Dit artikel geeft een overzicht van het werken met WordArt in .NET, inclusief hoe je teksttransformaties, vulstijlen, lijnen, schaduwen en andere opmaakopties toepast om je presentaties aantrekkelijker en expressiever te maken. WordArt laat je tekst behandelen als een grafisch object. Het bestaat uit effecten of speciale aanpassingen die op tekst worden toegepast om deze opvallender of aantrekkelijker te maken.

## **Een eenvoudige WordArt‑sjabloon maken en toepassen op tekst**

In dit gedeelte verkennen we hoe je een eenvoudig WordArt‑sjabloon maakt en toepast op tekst met Aspose.Slides for .NET. WordArt biedt een eenvoudige manier om het uiterlijk van tekst te verbeteren met opvallende visuele effecten en stijlen. Door de basisstappen voor het maken en gebruiken van WordArt te leren, kun je deze technieken gemakkelijk aanpassen aan elk project, waardoor je presentaties levendiger en gedenkwaardiger worden.

Eerst maken we eenvoudige tekst met de volgende C#‑code:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Nu stellen we de letterhoogte van de tekst in op een grotere waarde zodat het effect beter zichtbaar wordt met de volgende code:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

Hier passen we de SmallGrid‑patroonvulling toe op de tekst en voegen we een zwarte tekstrand van 1 pt toe met de volgende code:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

De resulterende tekst:

![Het eenvoudige WordArt‑sjabloon](WordArt_template.png)

## **Andere WordArt‑effecten toepassen**

Naast eenvoudige transformaties kun je met Aspose.Slides for .NET een verscheidenheid aan geavanceerde WordArt‑effecten toepassen om het uiterlijk van je tekst te verbeteren. Deze omvatten omlijningen, vullingen, schaduwen, weerspiegelingen en gloed‑effecten. Door deze functies te combineren, kun je opvallende tekststijlen creëren die opvallen in je presentaties. Dit gedeelte toont hoe je deze effecten programmatically toepast met eenvoudige, duidelijke code‑voorbeelden.

### **Buitenste schaduweffecten toepassen**

Buitenste schaduweffecten laten tekst opvallen door een schaduw achter de omtrek toe te voegen, waardoor er een gevoel van diepte en scheiding van de achtergrond ontstaat. Aspose.Slides for .NET maakt het gemakkelijk om buitenste schaduwen op WordArt‑tekst toe te passen en aan te passen. In dit gedeelte leer je hoe je de schaduwkleur, richting, afstand, vervagingsradius en meer instelt om de gewenste visuele impact te bereiken.

De onderstaande C#‑codefragment past een schaduweffect toe op de eerder gemaakte tekst.

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
}
```

De resulterende tekst:

![Het buitenste schaduweffect](outer_shadow_effect.png)

{{% alert color="info" %}} 
- Wanneer OuterShadow en PresetShadow samen worden gebruikt, wordt alleen het OuterShadow‑effect toegepast.
- Als OuterShadow en InnerShadow gelijktijdig worden gebruikt, hangt het resulterende effect af van de PowerPoint‑versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld, terwijl in PowerPoint 2007 alleen het OuterShadow‑effect wordt toegepast.
{{% /alert %}}

### **Weerspiegelingseffecten toepassen**

In dit gedeelte verkennen we hoe je weerspiegelingseffecten toepast in je dia's met Aspose.Slides for .NET. Weerspiegelingseffecten kunnen een effectieve manier zijn om tekst of vormen een stijlvolle en moderne uitstraling te geven, waardoor belangrijke elementen opvallen en diepte aan je presentatie wordt toegevoegd. Door het proces van toepassen en aanpassen van deze effecten te begrijpen, kun je ze eenvoudig afstemmen op je ontwerpbehoeften en merkidentiteit.

Voeg een weerspiegelingseffect toe aan de tekst met dit C#‑codevoorbeeld:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
}
```

De resulterende tekst:

![Het weerspiegelingseffect](reflection_effect.png)

### **Gloedeffecten toepassen**

In dit gedeelte laten we zien hoe je een gloedeffect op tekst toepast met Aspose.Slides for .NET. Het gloedeffect kan je tekst laten opvallen met een stralende omtrek, waardoor de visuele aantrekkingskracht van je dia's wordt vergroot. Door instellingen zoals kleur en intensiteit aan te passen, kun je de gloed eenvoudig afstemmen op je ontwerp en branding, zodat belangrijke punten in je presentatie de aandacht van het publiek trekken.

Pas een gloedeffect toe op de tekst zodat deze schittert of opvalt met de volgende code:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

De resulterende tekst:

![Het gloedeffect](glow_effect.png)

### **WordArt‑transformaties toepassen**

In dit gedeelte onderzoeken we hoe je transformaties in WordArt gebruikt met Aspose.Slides for .NET. Transformaties stellen je in staat om tekst te buigen, uit te rekken of te vervormen, waardoor unieke en visueel opvallende effecten ontstaan. Door deze technieken onder de knie te krijgen, kun je tekstvormen en -stijlen eenvoudig aanpassen aan je branding of creatieve visie, wat zorgt voor een overtuigende en gepolijste presentatie.

Gebruik de `Transform`‑eigenschap (die van toepassing is op het volledige tekstblok) met de volgende code:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

De resulterende tekst:

![De WordArt‑transformatie](transform_effect.png)

{{% alert color="info" %}} 
Aspose.Slides for .NET levert een set vooraf gedefinieerde [transformation types](https://reference.aspose.com/slides/nl/net/aspose.slides/textshapetype/).
{{% /alert %}} 

### **3D‑effecten toepassen op vormen en tekst**

Realistische, opvallende visuals kunnen de impact van je presentaties aanzienlijk vergroten. In dit gedeelte onderzoeken we hoe je driedimensionale (3D)‑effecten toepast op vormen met Aspose.Slides for .NET. Door parameters zoals diepte, hoek en verlichting te manipuleren, kun je indrukwekkende 3‑D‑transformaties maken die direct de aandacht van je publiek trekken. Of je nu subtiele accenten of dramatische illusies wilt, deze functies bieden flexibele manieren om je ontwerp te verbeteren en ideeën op een boeiendere manier over te brengen.

Gebruik de onderstaande voorbeeldcode om een 3D‑effect op de vorm toe te passen:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
}
```

De resulterende vorm:

![Het 3D‑effect op de vorm](shape_3D_effect.png)

Gebruik de onderstaande voorbeeldcode om een 3D‑effect op de tekst toe te passen:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
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
}
```

De resulterende tekst:

![Het 3D‑effect op de tekst](text_3D_effect.png)

{{% alert color="info" %}} 
De toepassing van 3D‑effecten op tekst of hun vormen—en de interactie tussen deze effecten—wordt bepaald door specifieke regels. Beschouw een scène met zowel een tekst als de vorm die die tekst bevat. Een 3D‑effect omvat de 3‑D‑representatie van het object en de scène waarop het wordt geplaatst.

- Als er een scène is ingesteld voor zowel de vorm als de tekst, heeft de scène van de vorm voorrang en wordt de scène van de tekst genegeerd.
- Als de vorm geen eigen scène heeft maar wel een 3‑D‑representatie, wordt de scène van de tekst gebruikt.
- Als de vorm helemaal geen 3D‑effect heeft, wordt deze als plat behandeld en wordt het 3D‑effect alleen op de tekst toegepast.

Deze gedragingen hebben betrekking op de eigenschappen [ThreeDFormat.LightRig](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/lightrig/) en [ThreeDFormat.Camera](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/camera/).
{{% /alert %}} 

## **FAQ**

### Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?

Ja, Aspose.Slides for .NET ondersteunt Unicode en werkt met alle gangbare lettertypen en scripts. WordArt‑effecten zoals schaduw, vulling en omtrek kunnen worden toegepast ongeacht de taal, hoewel de beschikbaarheid en weergave van lettertypen afhankelijk kan zijn van de systeemlettertypen.

### Kan ik WordArt‑effecten toepassen op elementen van de dia‑master?

Ja, je kunt WordArt‑effecten toepassen op vormen op de master‑dia’s, inclusief titel‑plaatsaanduidingen, voetteksten of achtergrondtekst. Wijzigingen in de master‑lay-out worden dan doorgevoerd naar alle bijbehorende dia’s.

### Beïnvloeden WordArt‑effecten de bestandsgrootte van de presentatie?

In geringe mate. WordArt‑effecten zoals schaduwen, gloed en verloopvullingen kunnen de bestandsgrootte enigszins verhogen door extra opmaakmetadata, maar het verschil is meestal verwaarloosbaar.

### Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?

Ja, je kunt dia’s met WordArt renderen naar afbeeldingen (bijv. PNG, JPEG) met de `GetImage`‑methode van de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) of [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/) interfaces. Hiermee kun je het resultaat in‑memory of op het scherm bekijken voordat je de volledige presentatie opslaat of exporteert.