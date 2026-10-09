---
title: Toepassen van vormeffecten in presentaties in .NET
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/net/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie-effect
- gloeieffect
- zachte randen effect
- effectformaat
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Transformeer uw PPT- en PPTX-bestanden met geavanceerde vormeffecten met Aspose.Slides voor .NET - maak binnen enkele seconden opvallende, professionele dia's."
---
## **Inleiding**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/net/shape-formatting/#gradient-fill) of contouren. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

![Vormeffect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meer effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Daarom heeft PowerPoint opties onder **Preset**. De Preset‑opties zijn in feite een bekend goed uitziende combinatie van twee of meer effecten. Op deze manier hoef je bij het kiezen van een preset geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de klasse [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) die je in staat stellen dezelfde effecten toe te passen op vormen in PowerPoint‑presentaties.

## **Een schaduweffect toepassen**

Aspose.Slides voor .NET ondersteunt buiten- en binnenschaduwen voor vormen. Je kunt hun kleur, richting, afstand en vervagingsradius aanpassen aan het ontwerp van je presentatie.

### **Een buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de achtergrond van de dia. De schaduw strekt zich uit voorbij de randen van de vorm, waardoor de indruk ontstaat dat de vorm verheven is boven de dia. Pas de kleur, richting, afstand en vervagingsradius aan om overeen te komen met de belichting en stijl van je sjabloon.

Deze C#‑code laat zien hoe je het [buitenste schaduweffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) op een rechthoek toepast:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Schaduweffect](shadow_effect.png)

### **Een binnenste schaduw toepassen**

Wanneer je de visuele stijl van een sjabloon reproduceert, gebruik je een binnenste schaduw om een kaart of paneel een ingezonken uiterlijk te geven. Een buitenste schaduw strekt zich buiten de vorm uit en laat deze verheven lijken, terwijl een binnenste schaduw de binnenkant van de randen verduistert.

Roep [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) aan en configureer vervolgens [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Grotere waarden geven zachtere randen.

Dit C#‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenste schaduw en slaat deze op als een PPTX‑bestand:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![Lichtblauwe rechthoek met een binnenste schaduw](inner_shadow_effect.png)

Om de binnenste schaduw te verwijderen, roep je [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) aan op het effectformaat van de vorm.

## **Een reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor .NET, kun je een spiegelachtige reflectie aan vormen toevoegen, waarbij je parameters zoals afstand, transparantie en grootte aanpast. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met eenvoudige code, waardoor je het snel kunt toepassen op meerdere elementen voor een consistent ontwerp.

Deze C#‑code laat zien hoe je het [reflectie‑effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) op een vorm toepast:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![Reflectie‑effect](reflection_effect.png)

## **Een gloed‑effect toepassen**

Om een gloed‑effect toe te passen op een vorm in Aspose.Slides voor .NET, kun je een zachte, lichtgevende aura rond vormen toevoegen, waarbij je eigenschappen zoals kleur en grootte aanpast. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het uiterlijk van je dia's wordt verbeterd.

Deze C#‑code laat zien hoe je het [gloed‑effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) op een vorm toepast:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Gloed‑effect](glow_effect.png)

## **Een zacht‑randen‑effect toepassen**

Om een zacht‑randen‑effect toe te passen in Aspose.Slides voor .NET, kun je een gladde, vervaagde overgang rondom de randen van een vorm creëren. Dit effect geeft een subtielere en verfijndere uitstraling, perfect voor ontwerpen die een zachte, zachtere look nodig hebben. Je kunt eenvoudig parameters zoals radius aanpassen om het gewenste effect te bereiken op verschillende vormen in je presentatie.

Deze C#‑code laat zien hoe je de [zachte randen](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) op een vorm toepast:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Zachte randen‑effect](soft_edges_effect.png)

## **Veelgestelde vragen**

**Kan ik meerdere effecten toepassen op dezelfde vorm?**  
Ja, je kunt verschillende effecten combineren, zoals schaduw, reflectie en gloed, op één vorm om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**  
Je kunt effecten toepassen op diverse vormen, waaronder autoshapes, diagrammen, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**  
Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt toegepast op de gehele groep.