---
title: Použití efektů tvarů v prezentacích v .NET
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/net/shape-effect/
keywords:
- efekt tvaru
- efekt stínu
- efekt odrazu
- efekt záře
- efekt měkkých okrajů
- formát efektu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů v Aspose.Slides pro .NET — vytvořte během okamžiku výrazné a profesionální snímky."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění objektu, liší se od [výplní](/slides/cs/net/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na objektu, rozprostřít jeho záři atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Můžete použít jeden nebo více efektů na tvar.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu má PowerPoint možnosti pod **Předvolba**. Možnosti Předvolby jsou v podstatě známou dobře vypadající kombinací dvou nebo více efektů. Tímto způsobem, výběrem předvolby, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli hezkou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/), které umožňují použít stejné efekty na tvary v prezentacích PowerPointu.

## **Použít efekt stínu**

Aspose.Slides pro .NET podporuje vnější a vnitřní stíny pro tvary. Můžete upravit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Použít vnější stín**

Použijte vnější stín, aby karta nebo panel vystoupaly proti pozadí snímku. Stín přesahuje okraje objektu, což vytváří dojem, že objekt je nad snímkem. Nastavte jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

Tento kód C# ukazuje, jak použít [vnější efekt stínu](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) na obdélník:

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

![Stínový efekt](shadow_effect.png)

### **Použít vnitřní stín**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel měly zapuštěný vzhled. Vnější stín se rozprostírá mimo objekt a způsobuje, že vypadá zdvižený, zatímco vnitřní stín ztmavuje vnitřní část jeho okrajů.

Zavolejte [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), poté nakonfigurujte [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Větší hodnoty produkují měkčí hrany.

Tento příklad v C# vytvoří světle modrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX:

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

Pro odebrání vnitřního stínu zavolejte [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) na formát efektu objektu.

## **Použít efekt odrazu**

Pro použití efektu odrazu v Aspose.Slides pro .NET můžete přidat zrcadlový odraz objektům a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že objektům dodá více uhlazený a sofistikovaný vzhled. Je snadné jej implementovat jednoduchým kódem, což umožňuje rychlé použití napříč více prvky pro konzistentní design.

Tento kód C# ukazuje, jak použít [efekt odrazu](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) na objekt:

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

Pro použití efektu záře na objekt v Aspose.Slides pro .NET můžete přidat měkkou, zářící auru kolem objektů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá objektům vyniknout a přidává atraktivní, upoutávající vizuální prvek vaší prezentaci. Je snadné jej implementovat s minimálním kódem, čímž se zlepšuje celkový vzhled vašich snímků.

Tento kód C# ukazuje, jak použít [efekt záře](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) na objekt:

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

## **Použít efekt měkkých okrajů**

Pro použití efektu měkkých okrajů v Aspose.Slides pro .NET můžete vytvořit hladký, rozostřený přechod kolem okrajů objektu. Tento efekt přidává jemnější a elegantnější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Parametry jako poloměr lze snadno upravit tak, aby se dosáhlo požadovaného efektu u různých objektů ve vaší prezentaci.

Tento kód C# ukazuje, jak použít [měkké okraje](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) na objekt:

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

![Efekt měkkých okrajů](soft_edges_effect.png)

## **Použít efekt rozostření**

Použijte rozostření objektu k změkčení výplně a obrysu objektu při zachování možnosti úpravy. Zavolejte [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) na formát efektu objektu. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž vyšší hodnoty produkují silnější rozostření. Poloměr nula ponechá vzhled nezměněný.

Nastavení [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) určuje viditelné hranice efektu. S hodnotou `false` je rozostření oříznuto na původní nakreslené hranice, včetně obrysu. S hodnotou `true` může rozostření přesáhnout tyto hranice. Žádné nastavení nemění pozici ani rozměry objektu.

Porovnání níže používá stejnou výplň, obrys a rozměry objektu. Horní řada používá `grow = false`; spodní řada používá `grow = true`.

![Původní obdélník porovnaný s poloměry rozostření 5 a 15 bodů, s vypnutým a zapnutým grow](shape_blur_comparison.png)

Tento příklad v C# vytvoří oranžový obdélník s tmavě modrým obrysem, použije rozostření o 5 bodů a poté jej aktualizuje na rozostření o 15 bodů voláním [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) znovu. Uloží oba rozostřené stavy, pak zavolá [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) a uloží objekt bez rozostření.

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

Rozostření objektu ovlivňuje výplň i obrys dohromady. Efekt měkkých okrajů rozostřuje hrany objektu, zatímco rozostření stínu změkčuje pouze stín. Efekty transformace obrázku působí na obsah obrázku; tento příklad aplikuje rozostření přímo na formát efektu objektu, aniž by objekt převáděl na obrázek.

## **Často kladené otázky**

**Mohu na stejný objekt použít více efektů?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jednom objektu a vytvořit tak dynamickyjší vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Můžete aplikovat efekty na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt bude aplikován na celou skupinu.