---
title: Alakzathatások alkalmazása prezentációkban .NET-ben
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/net/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- tükröződés hatás
- sugárzás hatás
- puhitott szélek hatás
- hatás formátum
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzathatásokkal az Aspose.Slides for .NET segítségével—hozzon létre lenyűgöző, professzionális diákat másodpercek alatt."
---
## **Bevezetés**

Miközben a PowerPoint‑hatásokat a alakzat kiemelésére lehet használni, különböznek a [kitöltésektől](/slides/hu/net/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint‑hatások segítségével meggyőző tükröződéseket hozhat létre egy alakzaton, terjesztheti az alakzat sugárzását stb.

![Alakzati hatás](shape-effect.png)

A PowerPoint hat hatást kínál, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Egyes hatáskombinációk jobban néznek ki, mint mások. Emiatt a PowerPoint a **Előbeállítás** alatt kínál opciókat. Az előbeállítások lényegében egy ismert, jól kinéző kombinációja két vagy több hatásnak. Így egy előre beállítást kiválasztva nem kell időt pazarolnia a különböző hatások tesztelésével vagy kombinálásával, hogy megfelelő kombinációt találjon.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) osztályon keresztül biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik ugyanazon hatások alkalmazását PowerPoint‑prezentációk alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for .NET külső és belső árnyékokat támogat alakzatokhoz. Testreszabhatja a színüket, irányukat, távolságukat és elmosódási sugarukat, hogy illeszkedjenek a bemutatója tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttér előtt. Az árnyék az alakzat szélei túlra nyúlik, így a benyomás alakul ki, hogy az alakzat a dia fölött felemelkedett. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a sablon világításának és stílusának.

Ez a C# kód bemutatja, hogyan alkalmazhatja a [külső árnyék hatást](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) egy téglalapra:

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

![Árnyékhatás](shadow_effect.png)

### **Belső árnyék alkalmazása**

Amikor egy sablon vizuális stílusát reprodukálja, használjon belső árnyékot, hogy a kártya vagy panel recesszív megjelenést kapjon. A külső árnyék a alakzat kívülére nyúlik, és felemelkedettnek tűnik, míg a belső árnyék az élek belsejét árnyékolja.

Hívja meg a [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) metódust, majd konfigurálja a [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) beállítást. A nagyobb értékek lágyabb széleket eredményeznek.

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

![Világoskék téglalap belső árnyékkal](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) metódust az alakzat effektusformátumán.

### **Előre beállított árnyék alkalmazása, módosítása és eltávolítása**

Hívja meg a [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) metódust, és állítsa be a [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) értékét egy névvel ellátott [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) típusra. A stílusok váltásához változtassa meg az előbeállítást ugyanazon az alakzaton. Hívja meg a [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) metódust az árnyék eltávolításához, miközben a kitöltést és a körvonalat megőrzi.

Ez a példa minden lépésnél megőriz egy másolatot a téglalapról. Mindkét árnyék 10 ponttal el van tolva. A 225° irány az első árnyékot a téglalap fölé és balra helyezi, míg a 45° a másodikat alulra és jobbra helyezi.

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

| Eredeti | Első előbeállítás | Második előbeállítás | Eltávolítás után |
| :---: | :---: | :---: | :---: |
| ![Nincs árnyék](preset_shadow_original.png) | ![Bal‑felső árnyék](preset_shadow_top_left.png) | ![Jobb‑alsó árnyék](preset_shadow_bottom_right.png) | ![Nincs árnyék az eltávolítás után](preset_shadow_removed.png) |

## **Tükröződés hatás alkalmazása**

Az Aspose.Slides for .NET-ben a tükröződés hatás alkalmazásához tükörszerű tükröződést adhat a alakzatokhoz, beállítva olyan paramétereket, mint a távolság, átlátszóság és méret. Ez a hatás javítja a bemutatók esztétikáját azzal, hogy az alakzatoknak kifinomultabb és letisztultabb megjelenést kölcsönöz. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemre, egységes dizájn érdekében.

Ez a C# kód bemutatja, hogyan alkalmazhatja a [tükröződés hatást](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) egy alakzatra:

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

![Tükröződés hatás](reflection_effect.png)

## **Sugárzás hatás alkalmazása**

Az Aspose.Slides for .NET-ben a sugárzás hatás alkalmazásához egy lágy, fényes aurát adhat a alakzatok köré, beállítva például a színt és a méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, figyelemfelkeltő vizuális elemet ad a bemutatóhoz. Minimális kóddal könnyen megvalósítható, javítva a diák összképét.

Ez a C# kód bemutatja, hogyan alkalmazhatja a [sugárzás hatást](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) egy alakzatra:

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

![Sugárzás hatás](glow_effect.png)

## **Puhított szélek hatás alkalmazása**

Az Aspose.Slides for .NET-ben a puhitott szélek hatás alkalmazásához létrehozhat egy sima, elmosódott átmenetet az alakzat szélein. Ez a hatás finomabb és kifinomultabb megjelenést ad, ami tökéletes olyan tervekhez, amelyeknek enyhe, lágyabb megjelenésre van szükségük. Könnyen beállíthatja a paramétereket, például a sugarat, hogy a kívánt hatást elérje a bemutató különböző alakzatai között.

Ez a C# kód bemutatja, hogyan alkalmazhatja a [puhított széleket](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) egy alakzatra:

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

![Puhított szélek hatás](soft_edges_effect.png)

## **Elmosódás hatás alkalmazása**

Használja az alakzat elmosódás funkciót a kitöltés és a körvonal lágyításához, miközben az alakzat szerkeszthető marad. Hívja meg a [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) metódust az alakzat effektusformátumán. A sugarat pontokban (1/72 hüvelyk) mérik: használjon nem negatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugarú beállítás változatlanul hagyja a megjelenést.

A [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) beállítás szabályozza a hatás látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, van vágva. `true` esetén az elmosódás túlnyúlhat ezeken a határokon. Egyik beállítás sem változtatja meg az alakzat helyét vagy méreteit.

Az alábbi összehasonlításban minden esetben ugyanazt a kitöltést, körvonalat és alakzati méreteket használjuk. A felső sor `grow = false` értéket, az alsó sor `grow = true` értéket használ.

![Eredeti téglalap 5 és 15 pontos elmosódással, grow ki‑ és bekapcsolva](shape_blur_comparison.png)

Ez a C# példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5‑pontos elmosódást alkalmaz, majd egy újabb [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) hívással 15‑pontos elmosódásra frissíti. Mindkét elmosódott állapotot elmenti, majd a [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) metódussal eltávolítja az elmosódást, és menti az alakzatot elmosódás nélkül.

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

Az alakzat elmosódás a kitöltést és a körvonalat együtt érinti. A puhitott szélek hatás az alakzat széleit halványítja, míg az árnyék elmosódás csak az árnyékot lágyítja. A képtranszformációs hatások a képtartalmon működnek; ez a példa közvetlenül az alakzat effektusformátumára alkalmaz elmosódást anélkül, hogy alakzatot képpé konvertálná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, több különböző hatást, például árnyékot, tükröződést és sugárzást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és másokat.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, csoportosított alakzatokra is alkalmazhat hatásokat. A hatás az egész csoportra vonatkozik.