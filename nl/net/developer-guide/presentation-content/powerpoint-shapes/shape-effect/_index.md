---
title: Vormeffecten toepassen in presentaties in .NET
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
description: "Transformeer uw PPT- en PPTX-bestanden met geavanceerde vormeffecten via Aspose.Slides voor .NET - maak binnen enkele seconden opvallende, professionele dia's."
---
## **Introductie**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/net/shape-formatting/#gradient-fill) of contouren. Met PowerPoint-effecten kun je overtuigende reflecties op een vorm maken, de gloed van een vorm verspreiden, enz.

![Vormeffect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meerdere effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan anderen. Om die reden heeft PowerPoint opties onder **Voorinstelling**. De Voorinstelling‑opties zijn in wezen een bekende, goed uitziende combinatie van twee of meer effecten. Op deze manier hoef je bij het selecteren van een voorinstelling geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) klasse die je in staat stellen dezelfde effecten toe te passen op vormen in PowerPoint‑presentaties.

## **Schaduweffect toepassen**

Aspose.Slides voor .NET ondersteunt buiten‑ en binnenschaduwen voor vormen. Je kunt hun kleur, richting, afstand en vervagingsstraal aanpassen om overeen te komen met het ontwerp van je presentatie.

### **Een buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de achtergrond van de dia. De schaduw strekt zich uit voorbij de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de dia zweeft. Pas de kleur, richting, afstand en vervagingsstraal aan om overeen te komen met de belichting en stijl van je sjabloon.

Deze C#‑code toont hoe je het [buitenste schaduweffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) toepast op een rechthoek:

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

### **Een binnenschaduw toepassen**

Wanneer je de visuele stijl van een sjabloon nabootst, gebruik je een binnenschaduw om een kaart of paneel een verzonken uiterlijk te geven. Een buitenste schaduw strekt zich buiten de vorm uit en laat deze verhoogd lijken, terwijl een binnenschaduw de binnenkant van de randen schaduwt.

Roep [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) aan en configureer vervolgens [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Grotere waarden geven zachtere randen.

Dit C#‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenschaduw en slaat deze op als een PPTX‑bestand:

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

![Lichtblauwe rechthoek met een binnenschaduw](inner_shadow_effect.png)

Om de binnenschaduw te verwijderen, roep je [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) aan op het effectformaat van de vorm.

## **Een reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor .NET, kun je een spiegelachtige reflectie aan vormen toevoegen en parameters zoals afstand, transparantie en grootte aanpassen. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met eenvoudige code, waardoor snelle toepassing over meerdere elementen voor een consistent ontwerp mogelijk is.

Deze C#‑code toont hoe je het [reflectie‑effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) toepast op een vorm:

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

## **Een gloeieffect toepassen**

Om een gloeieffect toe te passen op een vorm in Aspose.Slides voor .NET, kun je een zachte, lichtgevende aura rond vormen toevoegen en eigenschappen zoals kleur en grootte aanpassen. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het algehele uiterlijk van je dia's verbetert.

Deze C#‑code toont hoe je het [gloeieffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) toepast op een vorm:

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

![Gloeieffect](glow_effect.png)

## **Zacht rand‑effect toepassen**

Om een zacht rand‑effect toe te passen in Aspose.Slides voor .NET, kun je een vloeiende, vervaagde overgang rond de randen van een vorm creëren. Dit effect voegt een subtielere en verfijnde uitstraling toe, perfect voor ontwerpen die een zachte, zachtere uitstraling nodig hebben. Je kunt gemakkelijk parameters zoals straal aanpassen om het gewenste effect te bereiken over verschillende vormen in je presentatie.

Deze C#‑code toont hoe je de [zachte randen](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) toepast op een vorm:

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

![Zacht‑rand‑effect](soft_edges_effect.png)

## **Een vervageffect toepassen**

Gebruik vormvervaging om de vulling en contour van een vorm te verzachten terwijl de vorm bewerkbaar blijft. Roep [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) aan op het effectformaat van de vorm. De straal wordt gemeten in punten (1/72 inch): gebruik een niet‑negatieve waarde, waarbij grotere waarden sterkere vervaging geven. Een straal van nul laat het uiterlijk onveranderd.

De [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) instelling regelt de zichtbare grenzen van het effect. Met `false` wordt de vervaging bijgesneden tot de oorspronkelijke geschilderde grenzen, inclusief de contour. Met `true` kan de vervaging zich buiten die grenzen uitstrekken. Geen van beide instellingen verandert de positie of afmetingen van de vorm.

De onderstaande vergelijking gebruikt dezelfde vulling, contour en vormafmetingen overal. De bovenste rij gebruikt `grow = false`; de onderste rij gebruikt `grow = true`.

![Originele rechthoek vergeleken met vervagingsstraal van 5 en 15 punten, met grow uitgeschakeld en ingeschakeld](shape_blur_comparison.png)

Dit C#‑voorbeeld maakt een oranje rechthoek met een donkerblauwe contour, past een vervaging van 5 punten toe, en werkt deze vervolgens bij naar een vervaging van 15 punten door opnieuw [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) aan te roepen. Het slaat beide vervaagde toestanden op, roept daarna [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) aan en slaat de vorm zonder vervaging op.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

Vormvervaging beïnvloedt zowel de vulling als de contour samen. Een zachtrand‑effect vervaagt de randen van de vorm, terwijl vervaging van schaduw alleen de schaduw verzacht. Beeldtransformatie‑effecten werken op afbeeldingsinhoud; dit voorbeeld past vervaging direct toe op het effectformaat van de vorm zonder de vorm naar een afbeelding te converteren.

## **Veelgestelde vragen**

**Kan ik meerdere effecten toepassen op dezelfde vorm?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, op één enkele vorm combineren om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autosjablonen, diagrammen, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt op de hele groep toegepast.