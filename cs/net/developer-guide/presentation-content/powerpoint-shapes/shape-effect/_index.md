---
title: Použití efektů tvarů v prezentacích v .NET
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/net/shape-effect/
keywords:
- efekt tvaru
- stínový efekt
- odrazový efekt
- efekt záře
- efekt měkkých okrajů
- formát efektu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů s Aspose.Slides pro .NET - vytvořte působivé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [výplní](/slides/cs/net/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit jeho záři atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Můžete použít jeden nebo více efektů na tvar.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu má PowerPoint možnosti pod **Preset**. Možnosti Preset jsou v podstatě osvědčenou kombinací dvou nebo více efektů, která vypadá dobře. Tímto způsobem, když vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli hezkou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/), které umožňují použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použití stínového efektu**

Aspose.Slides pro .NET podporuje vnější a vnitřní stíny pro tvary. Můžete upravit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Použití vnějšího stínu**

Použijte vnější stín, aby karta nebo panel vynikly na pozadí snímku. Stín přesahuje okraje tvaru a vytváří dojem, že je tvar nad snímkem. Upravením barvy, směru, vzdálenosti a poloměru rozostření jej přizpůsobíte osvětlení a stylu vaší šablony.

Tento C# kód ukazuje, jak použít [vnější stínový efekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) na obdélník:

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

#### **Řízení směru stínu při otáčení tvaru**

Ve výchozím nastavení je [RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) `true`, takže se stín otáčí spolu s tvarem. Pro dosažení toho, aby tvary s různými otáčkami vypadaly osvětlené stejným směrem, nastavte tuto vlastnost na `false` a přiřaďte jejich stínům stejný [Směr](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/).

Příklad vytvoří dvě šipky se šedými stíny posunutými doprava (`Direction = 0`). Poté duplikuje snímek a otočí obě šipky o 90° po směru hodinových ručiček.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var before = presentation.Slides[0];

var left = before.Shapes.AddAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
left.FillFormat.FillType = FillType.Solid;
left.FillFormat.SolidFillColor.Color = Color.SteelBlue;
left.LineFormat.FillFormat.FillType = FillType.NoFill;

left.EffectFormat.EnableOuterShadowEffect();
var shadow = left.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.Gray;
shadow.Direction = 0;
shadow.Distance = 42;
shadow.BlurRadius = 0;
shadow.RotateShadowWithShape = true;

var right = before.Shapes.AddClone(left);
right.X = 395;
right.EffectFormat.OuterShadowEffect.RotateShadowWithShape = false;

var after = presentation.Slides.AddClone(before);
foreach (var arrow in after.Shapes)
    arrow.Rotation = 90;

presentation.Save("arrow_shadows.pptx", SaveFormat.Pptx);
```

Na druhém snímku vrhá levá šipka svůj stín dolů, zatímco pravá šipka stále vrhá svůj stín doprava. Nastavený směr zůstává 0° pro oba stíny.

![Vykreslení PowerPointu před a po otočení o 90°. Oba stíny začínají vpravo. Po otočení se stín přesune pod levou šipku a zůstane vpravo od pravé šipky.](arrow-shadow-rotation.png)

### **Použití vnitřního stínu**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, který kartě nebo panelu dodá zapuštěný vzhled. Vnější stín přesahuje mimo tvar a způsobí, že vypadá zvýšený, zatímco vnitřní stín stínuje vnitřek jeho okrajů.  

Zavolejte [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), poté nakonfigurujte [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Větší hodnoty vytvářejí měkčí hrany.

Tento C# příklad vytvoří světlemodrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX:

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

### **Použití, změna a odstranění přednastaveného stínu**

Zavolejte [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) a nastavte [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) na pojmenovaný [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/). Pro změnu stylu změňte předvolbu na stejném tvaru. Zavolejte [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/), aby se stín odstranil při zachování výplně a obrysu.

Tento příklad uchovává kopii obdélníku v každém kroku. Oba stíny jsou posunuty o 10 bodů. Směr 225° umisťuje první stín nad a vlevo od obdélníku a 45° umisťuje druhý pod a vpravo.

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

| Originál | První předvolba | Druhá předvolba | Po odstranění |
| :---: | :---: | :---: | :---: |
| ![Žádný stín](preset_shadow_original.png) | ![Stín v levém horním rohu](preset_shadow_top_left.png) | ![Stín v pravém dolním rohu](preset_shadow_bottom_right.png) | ![Žádný stín po odstranění](preset_shadow_removed.png) |

## **Použití odrazového efektu**

Pro použití odrazového efektu v Aspose.Slides pro .NET můžete přidat zrcadlový odraz k tvarům a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že poskytuje tvarům hladší a elegantnější vzhled. Je snadno implementovatelný pomocí jednoduchého kódu, což umožňuje rychlé použití na více prvcích pro jednotný design.

Tento C# kód ukazuje, jak použít [odrazový efekt](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) na tvar:

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

![Odrazový efekt](reflection_effect.png)

## **Použití efektu záře**

Pro použití efektu záře na tvar v Aspose.Slides pro .NET můžete přidat měkkou, zářivou aurou kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá tvarům vyniknout a přidává atraktivní, upoutávající vizuální prvek do vaší prezentace. Je snadno implementovatelný s minimálním kódem, což zlepšuje celkový vzhled snímků.

Tento C# kód ukazuje, jak použít [efekt záře](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) na tvar:

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

## **Použití efektu měkkých okrajů**

Pro použití efektu měkkých okrajů v Aspose.Slides pro .NET můžete vytvořit hladký, rozostřený přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro návrhy, které vyžadují jemný, měkčejší vzhled. Parametry jako poloměr můžete snadno upravit, abyste dosáhli požadovaného efektu na různých tvarech v prezentaci.

Tento C# kód ukazuje, jak použít [měkké okraje](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) na tvar:

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

## **Použití rozostření**

Použijte rozostření tvaru k změkčení výplně a obrysu tvaru a zároveň zachovejte tvar editovatelný. Zavolejte [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) na formát efektu tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž větší hodnoty vytvářejí silnější rozostření. Poloměr nula ponechává vzhled beze změny.

Nastavení [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) řídí viditelné hranice efektu. S `false` je rozostření oříznuto na původní vykreslené hranice, včetně obrysu. S `true` může rozostření přesáhnout tyto hranice. Žádné nastavení nemění pozici ani rozměry tvaru.

Níže uvedené srovnání používá po celou dobu stejnou výplň, obrys a rozměry tvaru. Horní řada používá `grow = false`; dolní řada používá `grow = true`.

![Původní obdélník porovnaný s poloměry rozostření 5 a 15 bodů, s vypnutým a zapnutým nastavením grow](shape_blur_comparison.png)

Tento C# příklad vytvoří oranžový obdélník s tmavě modrým obrysem, aplikuje rozostření 5 bodů a poté jej aktualizuje na rozostření 15 bodů voláním [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) znovu. Uloží oba rozostřené stavy, poté zavolá [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) a uloží tvar bez rozostření.

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

Rozostření tvaru ovlivňuje výplň i obrys společně. Efekt měkkých okrajů rozplývá okraje tvaru, zatímco rozostření stínu změkčuje jen stín. Efekty transformace obrazu pracují s obsahem obrázku; tento příklad aplikuje rozostření přímo na formát efektu tvaru, aniž by tvar převáděl na obrázek.

## **Často kladené otázky**

**Mohu použít více efektů na stejný tvar?**

Ano, můžete kombinovat různé efekty, jako je stín, odraz a záře, na jediném tvaru a vytvořit tak dynamický vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt se použije na celou skupinu.