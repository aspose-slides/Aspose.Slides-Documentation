---
title: Použití efektů tvarů v prezentacích v .NET
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/net/shape-effect
keywords:
- efekt tvaru
- stínový efekt
- reflexní efekt
- efekt záře
- efekt měkkých hran
- formát efektu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů s Aspose.Slides pro .NET—vytvořte působivé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [výplně](/slides/cs/net/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint poskytuje šest efektů, které lze použít na tvary. Můžete na tvar použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu má PowerPoint možnosti pod **Preset**. Volby Preset jsou v podstatě známá dobře vypadající kombinace dvou nebo více efektů. Tímto způsobem, když vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli hezkou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody pod třídou [EffectFormat], které vám umožní použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použít stínový efekt**

Chcete-li na tvar v Aspose.Slides pro .NET aplikovat stínový efekt, můžete snadno upravit parametry jako barvu, poloměr rozostření a směr. To vašim tvarům dodá dynamičtější a profesionálnější vzhled, přidá hloubku a zaměření. Pomocí jednoduchých úryvků kódu můžete tyto efekty aplikovat na více tvarů, čímž zvýšíte celkovou vizuální atraktivitu vašich prezentací.

Ukázkový C# kód ukazuje, jak aplikovat [vnější stínový efekt](https://reference.aspose.com/slides/cs/net/aspose.slides/effectformat/outershadoweffect/) na obdélník:

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

![Stínový efekt](shadow_effect.png)

## **Použít reflexní efekt**

Chcete-li v Aspose.Slides pro .NET použít reflexní efekt, můžete přidat zrcadlový odraz na tvary a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že tvarům dodá uhlazenější a sofistikovanější vzhled. Je snadné jej implementovat pomocí jednoduchého kódu, což umožňuje rychlé použití na více prvcích pro jednotný design.

Ukázkový C# kód ukazuje, jak aplikovat [reflexní efekt](https://reference.aspose.com/slides/cs/net/aspose.slides/effectformat/reflectioneffect/) na tvar:

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

![Reflexní efekt](reflection_effect.png)

## **Použít efekt záře**

Chcete-li na tvar v Aspose.Slides pro .NET aplikovat efekt záře, můžete přidat měkkou, svítivou aureolu kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá tvarům vyniknout a přidává atraktivní, poutavý vizuální prvek vaší prezentaci. Je snadné jej implementovat s minimálním kódem, čímž se zlepší celkový vzhled vašich snímků.

Ukázkový C# kód ukazuje, jak aplikovat [efekt záře](https://reference.aspose.com/slides/cs/net/aspose.slides/effectformat/gloweffect/) na tvar:

```c#
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

Chcete-li v Aspose.Slides pro .NET použít efekt měkkých hran, můžete vytvořit plynulý, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro designy, které potřebují jemný, měkčí vzhled. Parametry, například poloměr, můžete snadno upravit, abyste dosáhli požadovaného efektu na různých tvarech ve své prezentaci.

Ukázkový C# kód ukazuje, jak aplikovat [měkké hrany](https://reference.aspose.com/slides/cs/net/aspose.slides/effectformat/softedgeeffect/) na tvar:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Efekt měkkých hran](soft_edges_effect.png)

## **FAQ**

**Mohu na stejný tvar aplikovat více efektů?**

Ano, můžete kombinovat různé efekty, jako jsou stín, reflexe a záře, na jednom tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Můžete aplikovat efekty na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt se použije na celou skupinu.