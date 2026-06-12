---
title: "WordArt‑effecten maken en toepassen in .NET"
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
- buitenste schaduweffect
- inner schaduweffect
- .NET
- C#
- Aspose.Slides
description: "Maak en pas WordArt‑effecten aan in Aspose.Slides voor .NET. Deze stapsgewijze gids helpt ontwikkelaars presentaties te verbeteren met professionele tekst in C#."
---
## **Overzicht**

WordArt‑effecten stellen u in staat om visueel aantrekkelijke, gestileerde tekst toe te voegen aan uw PowerPoint‑presentaties. Met Aspose.Slides voor .NET kunnen ontwikkelaars programmatic WordArt maken, aanpassen en beheren, net als in Microsoft PowerPoint—zonder dat Office geïnstalleerd hoeft te zijn. Dit artikel geeft een overzicht van het werken met WordArt in .NET, inclusief hoe u teksttransformaties, opvullingsstijlen, omlijningen, schaduwen en andere opmaakopties toepast om de inhoud van uw presentatie expressiever en boeiender te maken. WordArt behandelt tekst als een grafisch object. Het bestaat uit effecten of speciale aanpassingen die op tekst worden toegepast om deze aantrekkelijker of opvallender te maken.

## **Maak een eenvoudige WordArt‑sjabloon en pas deze toe op tekst**

In dit gedeelte bekijken we hoe u een eenvoudige WordArt‑sjabloon maakt en toepast op tekst met Aspose.Slides voor .NET. WordArt biedt een gemakkelijke manier om het uiterlijk van tekst te verbeteren met opvallende visuele effecten en stijlen. Door de basisstappen voor het maken en gebruiken van WordArt te leren, kunt u deze technieken eenvoudig aanpassen aan elk project, waardoor uw presentaties levendiger en memorabeler worden.

Eerst maken we eenvoudige tekst met de volgende C#‑code:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Vervolgens stellen we de letterhoogte van de tekst in op een grotere waarde zodat het effect beter zichtbaar is, met de volgende code:

```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```

Hier passen we een SmallGrid‑patroonvulling toe op de tekst en voegen we een zwarte tekstrand van 1 pt toe met de volgende code:

```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

De resulterende tekst:

![Het eenvoudige WordArt‑sjabloon](WordArt_template.png)

## **Pas andere WordArt‑effecten toe**

Naast basis‑transformaties laat Aspose.Slides voor .NET u een verscheidenheid aan geavanceerde WordArt‑effecten toepassen om het uiterlijk van uw tekst te verbeteren. Deze omvatten omlijningen, vullingen, schaduwen, reflecties en gloeieffecten. Door deze functies te combineren, kunt u opvallende tekststijlen creëren die uit de presentatie springen. Deze sectie toont hoe u deze effecten programmatisch toepast met eenvoudige, duidelijke code‑voorbeelden.

### **Pas buitenste schaduweffecten toe**

Buitenste schaduweffecten laten tekst opvallen door een schaduw achter de omlijning toe te voegen, waardoor er diepte en scheiding van de achtergrond ontstaat. Aspose.Slides voor .NET maakt het eenvoudig om buitenste schaduwen op WordArt‑tekst toe te passen en aan te passen. In dit gedeelte leert u hoe u schaduwkleur, richting, afstand, vervagingsradius en meer instelt om het gewenste visuele effect te bereiken.

De volgende C#‑codefragment past een schaduweffect toe op de tekst die hierboven is gemaakt.

```cs
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

![Het buitenste schaduweffect](outer_shadow_effect.png)

{{% alert color="primary" %}} 
- Wanneer OuterShadow en PresetShadow samen worden gebruikt, wordt alleen het OuterShadow‑effect toegepast.
- Als OuterShadow en InnerShadow gelijktijdig worden gebruikt, hangt het resulterende effect af van de versie van PowerPoint. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld, terwijl in PowerPoint 2007 alleen het OuterShadow‑effect wordt toegepast.
{{% /alert %}}

### **Pas reflectie‑effecten toe**

In dit gedeelte onderzoeken we hoe reflectie‑effecten in uw dia's kunnen worden toegepast met Aspose.Slides voor .NET. Reflectie‑effecten kunnen een effectieve manier zijn om tekst of vormen een stijlvolle en moderne look te geven, waardoor belangrijke elementen opvallen en diepte aan uw presentatie wordt toegevoegd. Door het proces van toepassen en aanpassen van deze effecten te begrijpen, kunt u ze gemakkelijk afstemmen op uw ontwerp‑ en merkbehoeften.

Voeg een reflectie‑effect toe aan de tekst met dit C#‑codevoorbeeld:

```cs
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

![Het reflectie‑effect](reflection_effect.png)

### **Pas gloeieffecten toe**

In dit gedeelte bekijken we hoe een gloeieffect op tekst kan worden toegepast met Aspose.Slides voor .NET. Het gloeieffect kan uw tekst laten opvallen met een lumineuze omlijning, waardoor de visuele aantrekkingskracht van uw dia's wordt vergroot. Door instellingen zoals kleur en intensiteit aan te passen, kunt u het gloei‑effect eenvoudig afstemmen op uw ontwerp‑ en merkbehoeften, zodat belangrijke punten in uw presentatie de aandacht van het publiek trekken.

Pas een gloeieffect toe op de tekst zodat deze straalt of opvalt met de volgende code:

```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

De resulterende tekst:

![Het gloei‑effect](glow_effect.png)

### **Pas WordArt‑transformaties toe**

In dit gedeelte verkennen we hoe transformaties in WordArt kunnen worden gebruikt met Aspose.Slides voor .NET. Transformaties stellen u in staat tekst te buigen, uit te rekken of te vervormen, waardoor unieke en visueel opvallende effecten ontstaan. Door deze technieken onder de knie te krijgen, kunt u tekstvormen en stijlen eenvoudig afstemmen op uw branding of creatieve visie, wat zorgt voor een overtuigende en gepolijste presentatie.

Gebruik de `Transform`‑eigenschap (die van toepassing is op het gehele tekstblok) met de volgende code:

```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

De resulterende tekst:

![De WordArt‑transformatie](transform_effect.png)

{{% alert color="primary" %}} 
Aspose.Slides voor .NET biedt een reeks vooraf gedefinieerde [transformation types](https://reference.aspose.com/slides/nl/net/aspose.slides/textshapetype/).
{{% /alert %}} 

### **Pas 3D‑effecten toe op vormen en tekst**

Realistische, oogverblindende visuals kunnen de impact van uw presentaties aanzienlijk vergroten. In dit gedeelte onderzoeken we hoe drie‑dimensionale (3D)‑effecten op vormen kunnen worden toegepast met Aspose.Slides voor .NET. Door parameters zoals diepte, hoek en verlichting te manipuleren, kunt u indrukwekkende 3D‑transformaties produceren die direct de aandacht van uw publiek trekken. Of u nu subtiele accenten of dramatische illusies nastreeft, deze functies bieden flexibele manieren om uw ontwerp te verheffen en ideeën op een boeiendere manier over te brengen.

Gebruik de volgende voorbeeldcode om een 3D‑effect op de vorm toe te passen:

```cs
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

![Het vorm‑3D‑effect](shape_3D_effect.png)

Gebruik de volgende voorbeeldcode om een 3D‑effect op de tekst toe te passen:

```cs
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

De resulterende tekst:

![Het tekst‑3D‑effect](text_3D_effect.png)

{{% alert color="primary" %}} 
De toepassing van 3D‑effecten op tekst of hun vormen—en de interactie tussen deze effecten—wordt beheerst door specifieke regels. Beschouw een scène met zowel een tekst als de vorm die die tekst bevat. Een 3D‑effect omvat de 3D‑representatie van het object en de scène waarop het geplaatst is.

- Als een scène zowel voor de vorm als voor de tekst is ingesteld, krijgt de scène van de vorm voorrang en wordt de scène van de tekst genegeerd.
- Als de vorm geen eigen scène heeft maar wel een 3D‑representatie, wordt de scène van de tekst gebruikt.
- Als de vorm helemaal geen 3D‑effect heeft, wordt deze als plat beschouwd en wordt het 3D‑effect alleen op de tekst toegepast.

Deze gedragingen hebben betrekking op de eigenschappen [ThreeDFormat.LightRig](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/lightrig/) en [ThreeDFormat.Camera](https://reference.aspose.com/slides/nl/net/aspose.slides/threedformat/camera/).
{{% /alert %}} 

## **FAQ**

**Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides voor .NET ondersteunt Unicode en werkt met alle gangbare lettertypen en scripts. WordArt‑effecten zoals schaduw, vulling en omlijning kunnen worden toegepast ongeacht de taal, hoewel de beschikbaarheid van lettertypen en de weergave afhankelijk kunnen zijn van de systeemlettertypen.

**Kan ik WordArt‑effecten toepassen op elementen in de slide‑master?**

Ja, u kunt WordArt‑effecten toepassen op vormen in de master‑dia’s, inclusief titel‑plaatsaanduidingen, voetteksten of achtergrondtekst. Wijzigingen in de master‑lay‑out worden doorgevoerd in alle bijbehorende dia’s.

**Beïnvloeden WordArt‑effecten de bestandsgrootte van de presentatie?**

Een beetje. WordArt‑effecten zoals schaduwen, gloeien en verloopvullingen kunnen de bestandsgrootte licht vergroten door extra opmaakmetadata, maar het verschil is doorgaans verwaarloosbaar.

**Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?**

Ja, u kunt dia’s die WordArt bevatten renderen naar afbeeldingen (bijv. PNG, JPEG) met de `GetImage`‑methode van de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) of [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/) interfaces. Hierdoor kunt u het resultaat in‑memory of op het scherm bekijken voordat u de volledige presentatie opslaat of exporteert.