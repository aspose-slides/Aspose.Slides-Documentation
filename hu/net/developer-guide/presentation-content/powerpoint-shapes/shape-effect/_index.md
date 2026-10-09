---
title: Alakzat effektusok alkalmazása prezentációkban .NET-ben
linktitle: Alakzat effektus
type: docs
weight: 30
url: /hu/net/shape-effect/
keywords:
- alakzat effektus
- árnyék effektus
- tükröződés effektus
- ragyogás effektus
- lágy szélek effektus
- effektus formátum
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat effektusokkal az Aspose.Slides for .NET segítségével—hozzon létre lenyűgöző, professzionális diákat pillanatok alatt."
---
## **Bevezetés**

A PowerPointban használt effektusok segítségével kiemelhetünk egy alakzatot, de eltérnek a [kitöltésektől](/slides/hu/net/shape-formatting/#gradient-fill) vagy a körvonalaktól. PowerPoint effektusok használatával meggyőző tükröződéseket hozhatunk létre egy alakzaton, szórhatjuk a fényt, stb.

![Alakzat effektus](shape-effect.png)

A PowerPoint hat effektust biztosít, amelyeket alakzatokra lehet alkalmazni. Egy alakzatra egy vagy több effektust is alkalmazhat.

Néhány effektuskombináció jobban néz ki, mint mások. Emiatt a PowerPoint a **Preset** (Előbeállítás) alatt kínál lehetőségeket. Az előbeállítások lényegében egy jól kinéző, két vagy több effektusból álló kombinációt jelentenek. Így egy előre beállított kombinációt kiválasztva nem kell időt vesztegetni különböző effektusok tesztelésével vagy kombinálásával a megfelelő hatás eléréséhez.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) osztályban biztosít tulajdonságokat és metódusokat, amelyekkel ugyanazokat az effektusokat alkalmazhatja PowerPoint‑prezentációk alakzataira.

## **Árnyék effektus alkalmazása**

Az Aspose.Slides for .NET a külső és belső árnyékokat támogatja alakzatoknál. Testreszabhatja azok színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjen a bemutató tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérrel szemben. Az árnyék túlnyúlik az alakzat szélén, így a térben felemelkedett hatást keltve. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a sablon világításának és stílusának.

Ez a C# kód bemutatja, hogyan kell alkalmazni az [külső árnyék effektus](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) egy téglalaphoz:
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

![Árnyék effektus](shadow_effect.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy egy kártya vagy panel recesszív megjelenést kapjon. A külső árnyék az alakzat külső részén terjed, így emelt hatást kelt, míg a belső árnyék az él belső részét sötétíti.

Hívja meg az [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) metódust, majd konfigurálja az [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) beállításait. Nagyobb értékek puhább éleket eredményeznek.

Ez a C# példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti el:
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

A belső árnyék eltávolításához hívja meg a [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) metódust az alakzat effectformat objektumán.

## **Tükröződés effektus alkalmazása**

Az Aspose.Slides for .NET-ben a tükröződés effektust úgy alkalmazhatja, hogy tükörszerű visszaverődést ad az alakzatokhoz, beállítva például a távolságot, átlátszatlanságot és méretet. Ez az effektus javítja a prezentációk esztétikáját, finomabb, kifinomultabb megjelenést kölcsönözve az alakzatoknak. Egyszerű kóddal könnyen megvalósítható, így gyorsan alkalmazható több elemre a konzisztens design érdekében.

Ez a C# kód bemutatja, hogyan kell alkalmazni a [tükröződés effektus](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) egy alakzatra:
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

![Tükröződés effektus](reflection_effect.png)

## **Ragyogás effektus alkalmazása**

Az Aspose.Slides for .NET-ben a ragyogás effektust úgy alkalmazhatja, hogy lágy, fényes aurát ad az alakzatok köré, módosítva például a színt és a méretet. Ez az effektus segít kiemelni az alakzatokat, valamint vonzó, szemrevaló vizuális elemet ad a prezentációnak. Könnyen megvalósítható minimális kóddal, javítva a diák általános megjelenését.

Ez a C# kód bemutatja, hogyan kell alkalmazni a [ragyogás effektus](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) egy alakzatra:
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

![Ragyogás effektus](glow_effect.png)

## **Lágy szélek effektus alkalmazása**

Az Aspose.Slides for .NET-ben a lágy szélek effektust úgy alkalmazhatja, hogy sima, elmosódott átmenetet hoz a forma szélein. Ez az effektus finomabb, kifinomultabb megjelenést ad, tökéletes a gyengébb, lágyabb dizájnokhoz. A paramétereket, például a sugarat, könnyen beállíthatja a kívánt hatás eléréséhez különböző alakzatoknál.

Ez a C# kód bemutatja, hogyan kell alkalmazni a [lágy szélek](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) egy alakzatra:
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

![Lágy szélek effektus](soft_edges_effect.png)

## **GYIK**

**Alkalmazhatok több effektust ugyanarra az alakzatra?**

Igen, különböző effektusokat, például árnyékot, tükröződést és ragyogást kombinálhat egyetlen alakzaton, dinamikusabb megjelenést érve el.

**Milyen alakzatokra alkalmazhatok effektusokat?**

Különböző alakzatokra, beleértve az autoshape‑eket, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok effektusokat csoportosított alakzatokra?**

Igen, a csoportosított alakzatokra is alkalmazhat effektusokat. Az effektus az egész csoportra vonatkozik.