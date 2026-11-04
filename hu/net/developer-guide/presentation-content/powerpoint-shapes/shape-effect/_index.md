---
title: Alakzateffektusok alkalmazása prezentációkban .NET-ben
linktitle: Alakzateffektus
type: docs
weight: 30
url: /hu/net/shape-effect/
keywords:
- alakzateffektus
- árnyékhatás
- tükröződés hatás
- fénylődés hatás
- lágy szegélyek hatás
- effektus formátum
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzateffektusokkal az Aspose.Slides for .NET használatával—hozzon létre lenyűgöző, professzionális diákat pillanatok alatt."
---
## **Bevezetés**

Miközben a PowerPoint effektusok használhatók egy alakzat kiemelésére, különböznek a [kitöltésektől](/slides/hu/net/shape-formatting/#gradient-fill) vagy a körvonaltól. A PowerPoint effektusokkal meggyőző tükröződéseket hozhatunk létre egy alakzaton, terjeszthetjük az alakzat fénylődését stb.

![Shape effect](shape-effect.png)

A PowerPoint hat effektust kínál, amelyeket alakzatokra lehet alkalmazni. Egy alakzatra egy vagy több hatást is alkalmazhat.

Egyes effektuskombinációk jobban néznek ki, mint mások. Ezért a PowerPoint a **Preset** (Előre beállított) menüpont alatt lehetőségeket biztosít. Az Előre beállított opciók lényegében egy jól kinéző, két vagy több effektusból álló kombinációt jelentenek. Így egy előre beállítottot kiválasztva nem kell időt vesztegetni különböző effektusok tesztelésével vagy kombinálásával a megfelelő megjelenés megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) osztály alatt olyan tulajdonságokat és metódusokat biztosít, amelyekkel ugyanezeket az effektusokat alkalmazhatja PowerPoint‑prezentációkban lévő alakzatokra.

## **Árnyék hatás alkalmazása**

Az Aspose.Slides for .NET külső és belső árnyékot támogat alakzatokhoz. Színüket, irányukat, távolságukat és elmosódási sugárukat testre szabhatja, hogy illeszkedjen a bemutatója dizájnjához.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérből. Az árnyék túlnyúlik az alakzat szélén, és azt a benyomást kelti, mintha az alakzat a dia felett volna. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a sablonja világításának és stílusának.

Ez a C# kód bemutatja, hogyan kell alkalmazni a [külső árnyék hatást](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) egy téglalapra:

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

![Shadow effect](shadow_effect.png)

### **Belső árnyék alkalmazása**

Amikor egy sablon vizuális stílusát reprodukálja, használjon belső árnyékot, hogy a kártya vagy panel recesszív megjelenést kapjon. A külső árnyék az alakzat kívülre nyúlik, és azt a benyomást kelti, hogy felemelkedett, míg a belső árnyék az alakzat széleinek belsejét árnyékolja.

Hívja meg az [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), majd konfigurálja a [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). A nagyobb értékek lágyabb széleket eredményeznek.

Ez a C# példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti:

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) metódust az alakzat effektusformátumán.

## **Tükröződés hatás alkalmazása**

Az Aspose.Slides for .NET‑ben a tükröződés hatás alkalmazásához hozzáadhat tükörszerű tükröződést az alakzatokhoz, beállítva olyan paramétereket, mint a távolság, átlátszóság és méret. Ez a hatás fokozza a prezentációk esztétikáját, elegánsabb megjelenést kölcsönözve az alakzatoknak. Könnyen megvalósítható egyszerű kóddal, lehetővé téve a gyors alkalmazást több elemre a konzisztens dizájn érdekében.

Ez a C# kód bemutatja, hogyan kell alkalmazni a [tükröződés hatást](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) egy alakzatra:

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

![Reflection effect](reflection_effect.png)

## **Fénylődés hatás alkalmazása**

Az Aspose.Slides for .NET‑ben a fénylődés hatás alkalmazásához puha, ragyogó aurát vehet fel az alakzatok köré, beállítva a színt és a méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemrevaló vizuális elemet ad a prezentációnak. Könnyen megvalósítható minimális kóddal, javítva a diák általános kinézetét.

Ez a C# kód bemutatja, hogyan kell alkalmazni a [fénylődés hatást](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) egy alakzatra:

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

![Glow effect](glow_effect.png)

## **Lágy szegélyek hatás alkalmazása**

Az Aspose.Slides for .NET‑ben a lágy szegélyek hatás alkalmazásához sima, elmosódott átmenetet hozhat létre az alakzat szélei körül. Ez a hatás finomabb és kifinomultabb megjelenést ad, ideális olyan tervezésekhez, amelyeknek enyhe, lágy hatásra van szüksége. Könnyen állíthatja a sugár értékét, hogy a kívánt hatást elérje a prezentáció különböző alakzataiban.

Ez a C# kód bemutatja, hogyan kell alkalmazni a [lágy szegélyek](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) hatást egy alakzatra:

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

![Soft edges effect](soft_edges_effect.png)

## **Elmosódás hatás alkalmazása**

Használja az alakzat elmosódását a kitöltés és a körvonal elmosásához, miközben az alakzat szerkeszthető marad. Hívja meg a [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) metódust az alakzat effektusformátumán. A sugár pontban (1/72 hüvelyk) van mérve: használjon nem negatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár változatlan megjelenést hagy.

A [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) beállítás szabályozza a hatás látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat is, lesz vágva. `true` esetén az elmosódás túlnyúlhat ezeken a határokon. Egyik beállítás sem változtatja meg az alakzat helyzetét vagy méreteit.

Az alábbi összehasonlítás ugyanazt a kitöltést, körvonalat és alakzatemérettel mutatja be. A felső sor `grow = false`; az alsó sor `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Ez a C# példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pont elmosódást alkalmaz, majd [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) újbóli hívásával 15 pont elmosódásra frissíti. Mindkét elmosódott állapotot menti, majd a [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) meghívásával menti az alakzatot elmosódás nélkül.

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

Az alakzat elmosódása a kitöltést és a körvonalat együtt érinti. A lágy szegélyek hatás a forma széleit halványítja, míg az árnyék elmosódása csak az árnyékot lágyítja. A képtranszformációs hatások a képtartalomra hatnak; ez a példa közvetlenül az alakzat effektusformátumára alkalmaz elmosódást, anélkül, hogy az alakzatot képpé konvertálná.

## **GYIK**

**Alkalmazhatok-e több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat – például árnyékot, tükröződést és fénylődést – kombinálhat egyetlen alakzaton, dinamikusabb megjelenést érve el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, beleértve az autoshape‑eket, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok-e hatásokat csoportosított alakzatokra?**

Igen, hatásokat alkalmazhat csoportosított alakzatokra is. A hatás az egész csoportra lesz érvényes.