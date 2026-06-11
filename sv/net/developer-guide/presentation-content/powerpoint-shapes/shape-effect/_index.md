---
title: Applicera formseffekter i presentationer i .NET
linktitle: Formseffekt
type: docs
weight: 30
url: /sv/net/shape-effect
keywords:
- formseffekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- mjuk kantseffekt
- effektformat
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Transformera dina PPT- och PPTX-filer med avancerade formseffekter med Aspose.Slides för .NET - skapa slående, professionella bilder på sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fyllningar](/slides/sv/net/shape-formatting/#gradient-fill) eller konturer. Genom att använda PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en forms glöd, osv.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan tillämpa en eller flera effekter på en form.

Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen har PowerPoint alternativ under **Preset**. Preset‑alternativen är i princip en välkänd, bra‑utseende kombination av två eller fler effekter. På så sätt, genom att välja ett förinställt alternativ, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en fin kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/effectformat/) som låter dig tillämpa samma effekter på former i PowerPoint‑presentationer.

## **Applicera en skuggeffekt**

För att applicera en skuggeffekt på en form i Aspose.Slides för .NET kan du enkelt justera parametrar som färg, oskärpedistans och riktning. Detta ger dina former ett mer dynamiskt och professionellt utseende, med djup och fokus. Genom att använda enkla kodsnuttar kan du applicera dessa effekter på flera former, vilket förbättrar den övergripande visuella attraktiviteten i dina presentationer.

Denna C#‑kod visar hur du tillämpar [yttre skuggeffekt](https://reference.aspose.com/slides/sv/net/aspose.slides/effectformat/outershadoweffect/) på en rektangel:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Skuggeffekt](shadow_effect.png)

## **Applicera en reflektionseffekt**

För att applicera en reflektionseffekt i Aspose.Slides för .NET kan du lägga till en spegelliknande reflektion på former, justera parametrar som avstånd, transparens och storlek. Denna effekt förbättrar estetiken i dina presentationer genom att ge former ett mer polerat och sofistikerat utseende. Det är enkelt att implementera med enkel kod, vilket möjliggör snabb tillämpning på flera element för en enhetlig design.

Denna C#‑kod visar hur du tillämpar [reflektionseffekt](https://reference.aspose.com/slides/sv/net/aspose.slides/effectformat/reflectioneffect/) på en form:

```c#
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

![Reflektionseffekt](reflection_effect.png)

## **Applicera en glödeffekt**

För att applicera en glödeffekt på en form i Aspose.Slides för .NET kan du lägga till en mjuk, lysande aura runt former, justera egenskaper som färg och storlek. Denna effekt hjälper former att sticka ut och ger ett attraktivt, iögonfallande visuellt element till din presentation. Det är enkelt att implementera med minimal kod, vilket förbättrar det övergripande utseendet på dina bilder.

Denna C#‑kod visar hur du tillämpar [glödeffekt](https://reference.aspose.com/slides/sv/net/aspose.slides/effectformat/gloweffect/) på en form:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Glödeffekt](glow_effect.png)

## **Applicera en mjuk kant‑effekt**

För att applicera en mjuk kant‑effekt i Aspose.Slides för .NET kan du skapa en jämn, suddig övergång runt en formes kanter. Denna effekt ger ett mer subtilt och raffinerat utseende, perfekt för designer som behöver ett mjukt, mjukare utseende. Du kan enkelt justera parametrar som radie för att uppnå önskad effekt på olika former i din presentation.

Denna C#‑kod visar hur du tillämpar [mjuk kant‑effekt](https://reference.aspose.com/slides/sv/net/aspose.slides/effectformat/softedgeeffect/) på en form:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Mjuk kant‑effekt](soft_edges_effect.png)

## **FAQ**

**Kan jag tillämpa flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag applicera effekter på?**

Du kan applicera effekter på olika former, inklusive autoshapes, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag applicera effekter på grupperade former?**

Ja, du kan applicera effekter på grupperade former. Effekten kommer att tillämpas på hela gruppen.