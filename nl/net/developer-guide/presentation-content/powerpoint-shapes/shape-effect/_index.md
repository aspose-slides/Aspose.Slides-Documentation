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
- zacht-rand-effect
- effectformaat
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Transformeer uw PPT- en PPTX-bestanden met geavanceerde vormeffecten met Aspose.Slides voor .NET — maak in enkele seconden indrukwekkende, professionele dia's."
---
## **Inleiding**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [opvullingen](/slides/nl/net/shape-formatting/#gradient-fill) of contouren. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

![Vormeffect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meer effecten op een vorm toepassen.

Enkele combinaties van effecten zien er beter uit dan andere. Daarom heeft PowerPoint opties onder **Preset**. De preset‑opties vormen in feite een bekende, goed uitziende combinatie van twee of meer effecten. Op deze manier hoef je door het selecteren van een preset geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de klasse [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) die het mogelijk maken dezelfde effecten op vormen in PowerPoint‑presentaties toe te passen.

## **Een schaduweffect toepassen**

Aspose.Slides voor .NET ondersteunt buiten‑ en binnen‑schaduwen voor vormen. Je kunt hun kleur, richting, afstand en vervagingsstraal aanpassen om overeen te komen met het ontwerp van je presentatie.

### **Een buiten‑schaduw toepassen**

Gebruik een buiten‑schaduw om een kaart of paneel te laten opvallen tegen de achtergrond van de dia. De schaduw strekt zich uit voorbij de randen van de vorm, waardoor het lijkt alsof de vorm boven de dia zweeft. Pas de kleur, richting, afstand en vervagingsstraal aan om overeen te komen met de verlichting en stijl van je sjabloon.

Deze C#‑code toont hoe je het [buitenschaduweffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) op een rechthoek toepast:
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

### **Een binnen‑schaduw toepassen**

Bij het reproduceren van de visuele stijl van een sjabloon gebruik je een binnen‑schaduw om een kaart of paneel een verzonken uiterlijk te geven. Een buiten‑schaduw strekt zich buiten de vorm uit en laat deze lijken te zweven, terwijl een binnen‑schaduw de binnenkant van de randen verduistert.

Roep [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) aan, en configureer vervolgens [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Hogere waarden geven zachtere randen.

Dit C#‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnen‑schaduw en slaat deze op als een PPTX‑bestand:
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

![Lichtblauwe rechthoek met een binnen‑schaduw](inner_shadow_effect.png)

Om de binnen‑schaduw te verwijderen, roep je [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) aan op het effectformaat van de vorm.

### **Een preset‑schaduw toepassen, wijzigen en verwijderen**

Roep [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) aan en stel [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) in op een benoemd [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/). Om stijlen te wisselen, wijzig je de preset op dezelfde vorm. Roep [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) aan om de schaduw te verwijderen terwijl de opvulling en contour behouden blijven.

Dit voorbeeld houdt een kopie van de rechthoek bij elke stap bij. Beide schaduwen zijn met 10 punten verschoven. Een richting van 225° plaatst de eerste schaduw boven en links van de rechthoek, en 45° plaatst de tweede eronder en rechts.
```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| Origineel | Eerste preset | Tweede preset | Na verwijdering |
| :---: | :---: | :---: | :---: |
| ![Geen schaduw](preset_shadow_original.png) | ![BovenLinksDropShadow](preset_shadow_top_left.png) | ![OnderRechtsDropShadow](preset_shadow_bottom_right.png) | ![Geen schaduw na verwijdering](preset_shadow_removed.png) |

## **Een reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor .NET, kun je een spiegel‑achtige reflectie aan vormen toevoegen, waarbij je parameters zoals afstand, transparantie en grootte aanpast. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met eenvoudige code, waardoor snelle toepass­ing over meerdere elementen voor een consistent ontwerp mogelijk is.

Deze C#‑code toont hoe je het [reflectie‑effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) op een vorm toepast:
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

Om een gloed‑effect op een vorm toe te passen in Aspose.Slides voor .NET, kun je een zachte, lichtgevende aura rond vormen toevoegen, waarbij je eigenschappen zoals kleur en grootte aanpast. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het algemene uiterlijk van je dia's wordt verbeterd.

Deze C#‑code toont hoe je het [gloed‑effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) op een vorm toepast:
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

## **Een zacht‑rand‑effect toepassen**

Om een zacht‑rand‑effect toe te passen in Aspose.Slides voor .NET, kun je een soepele, vervaagde overgang rond de randen van een vorm creëren. Dit effect voegt een subtielere en verfijndere uitstraling toe, perfect voor ontwerpen die een zachte, subtiele look nodig hebben. Je kunt eenvoudig parameters zoals straal aanpassen om het gewenste effect te bereiken voor verschillende vormen in je presentatie.

Deze C#‑code toont hoe je de [zachte randen](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) op een vorm toepast:
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

![Zachte rand‑effect](soft_edges_effect.png)

## **Een vervagings‑effect toepassen**

Gebruik vormvervaging om de opvulling en contour van een vorm zachter te maken, terwijl de vorm bewerkbaar blijft. Roep [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) aan op het effectformaat van de vorm. De straal wordt gemeten in punten (1/72 inch): gebruik een niet‑negatieve waarde, waarbij grotere waarden een sterkere vervaging geven. Een straal van nul laat het uiterlijk ongewijzigd.

De instelling [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) bepaalt de zichtbare grenzen van het effect. Met `false` wordt de vervaging afgeknipt tot de oorspronkelijke geschilderde grenzen, inclusief de contour. Met `true` kan de vervaging zich uitbreiden buiten die grenzen. Geen van beide instellingen verandert de positie of afmetingen van de vorm.

De onderstaande vergelijking gebruikt dezelfde opvulling, contour en vormafmetingen gedurende het geheel. De bovenste rij gebruikt `grow = false`; de onderste rij gebruikt `grow = true`.

![Originele rechthoek vergeleken met vervagingsstraal van 5 en 15 punten, met grow uitgeschakeld en ingeschakeld](shape_blur_comparison.png)

Dit C#‑voorbeeld maakt een oranje rechthoek met een donkerblauwe contour, past een vervaging van 5 punten toe, en werkt deze vervolgens bij naar een vervaging van 15 punten door opnieuw [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) aan te roepen. Het slaat beide vervaagde toestanden op, roept daarna [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) aan en slaat de vorm op zonder vervaging.
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

Vormvervaging beïnvloedt de opvulling en contour samen. Een zacht‑rand‑effect vervaagt de randen van de vorm, terwijl schaduwwerking alleen de schaduw verzacht. Beeldtransformatie‑effecten werken op de afbeeldingsinhoud; dit voorbeeld past vervaging direct toe op het effectformaat van de vorm zonder de vorm om te zetten naar een afbeelding.

## **FAQ**

**Kan ik meerdere effecten op dezelfde vorm toepassen?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één enkele vorm om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autoshapes, diagrammen, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt op de hele groep toegepast.