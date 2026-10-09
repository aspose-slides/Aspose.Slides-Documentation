---
title: Aplikovat efekty tvarů v prezentacích v .NET
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/net/shape-effect/
keywords:
- efekt tvaru
- efekt stínu
- efekt odrazu
- efekt záře
- efekt měkkých hran
- formát efektu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přetvořte své soubory PPT a PPTX pomocí pokročilých efektů tvarů pomocí Aspose.Slides pro .NET—vytvořte úchvatné, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [vyplnění](/slides/cs/net/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Můžete použít jeden nebo více efektů na jeden tvar.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu má PowerPoint možnosti pod **Preset**. Možnosti Preset jsou v podstatě osvědčená dobře vypadající kombinace dvou nebo více efektů. Tímto způsobem, když vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli hezkou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/), které vám umožní aplikovat stejné efekty na tvary v prezentacích PowerPoint.

## **Použít efekt stínu**

Aspose.Slides pro .NET podporuje vnější a vnitřní stíny pro tvary. Můžete upravit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Použít vnější stín**

Použijte vnější stín, aby karta nebo panel vynikl na pozadí snímku. Stín se rozprostírá za okraji tvaru a vytváří dojem, že je tvar nadsnímkový. Upravit jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

Tento kód C# ukazuje, jak použít [efekt vnějšího stínu](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) na obdélník:

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

![Efekt stínu](shadow_effect.png)

### **Použít vnitřní stín**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel získaly zapuštěný vzhled. Vnější stín se rozprostírá mimo tvar a způsobuje, že vypadá zdviženě, zatímco vnitřní stín stíní vnitřní část jeho okrajů.

Zavolejte [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), pak nakonfigurujte [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Větší hodnoty vytvářejí měkčí okraje.

Tento příklad C# vytvoří světle modrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX:

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

![Světle modrý obdélník s vnitřním stínem](inner_shadow_effect.png)

Pro odstranění vnitřního stínu zavolejte [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) na formátu efektu tvaru.

## **Použít efekt odrazu**

Pro použití efektu odrazu v Aspose.Slides pro .NET můžete přidat do tvarů zrcadlový odraz a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že tvary získají hladší a sofistikovanější vzhled. Je snadno implementovatelný pomocí jednoduchého kódu, což umožňuje rychlé nasazení napříč více prvky pro jednotný design.

Tento kód C# ukazuje, jak použít [efekt odrazu](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) na tvar:

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

![Efekt odrazu](reflection_effect.png)

## **Použít efekt záře**

Pro použití efektu záře na tvar v Aspose.Slides pro .NET můžete přidat kolem tvarů měkkou, zářivou auru a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá tvarům vyniknout a přidává atraktivní, poutavý vizuální prvek do vaší prezentace. Je snadno implementovatelný s minimálním kódem, čímž zlepšuje celkový vzhled vašich snímků.

Tento kód C# ukazuje, jak použít [efekt záře](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) na tvar:

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

![Efekt záře](glow_effect.png)

## **Použít efekt měkkých hran**

Pro použití efektu měkkých hran v Aspose.Slides pro .NET můžete vytvořit hladký, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Můžete snadno upravit parametry jako poloměr, abyste dosáhli požadovaného efektu u různých tvarů ve vaší prezentaci.

Tento kód C# ukazuje, jak použít [měkké hrany](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) na tvar:

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

![Efekt měkkých hran](soft_edges_effect.png)

## **Často kladené otázky**

**Mohu na stejný tvar použít více efektů?**

Ano, můžete kombinovat různé efekty, jako stín, odraz a záři, na jednom tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt se použije na celou skupinu.