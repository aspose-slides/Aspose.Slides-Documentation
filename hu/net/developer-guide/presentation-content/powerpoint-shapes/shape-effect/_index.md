---
title: Alakzat-hatások alkalmazása prezentációkban .NET-ben
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/net/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- reflexiós hatás
- ragyogás hatás
- lágy szélek hatás
- hatás formátum
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Átalakítsa PPT és PPTX fájljait fejlett alakzat-hatásokkal az Aspose.Slides for .NET segítségével—hozzon létre lenyűgöző, professzionális diákat másodpercek alatt."
---
## **Bevezetés**

Míg a PowerPoint‑ban a hatásokat arra használhatjuk, hogy egy alakzat kiemelkedjen, különböznek a [kitöltésektől](/slides/hu/net/shape-formatting/#gradient-fill) vagy a kontúroktól. A PowerPoint‑hatásokkal meggyőző tükröződéseket hozhatunk létre egy alakzaton, szórhatjuk a glow‑t, stb.

![Alakzat hatás](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Néhány hatáskombináció jobban néz ki, mint mások. Ezért a PowerPoint **Előbeállított** lehetőségeket kínál. Az előre beállított lehetőségek lényegében egy jól kinéző két vagy több hatás kombinációja. Így egy előre beállítást kiválasztva nem kell időt vesztegetni a különböző hatások tesztelésével vagy kombinálásával.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) osztályban olyan tulajdonságokat és metódusokat biztosít, amelyekkel ugyanazzal a hatással láthatja el a PowerPoint‑prezentációk alakzatait.

## **Árnyékhatás Alkalmazása**

Az Aspose.Slides for .NET támogatja a külső és belső árnyékokat az alakzatoknál. Testreszabhatja színüket, irányukat, távolságukat és elmosódási sugárukat, hogy illeszkedjenek a prezentáció tervezéséhez.

### **Külső Árnyék Alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérrel szemben. Az árnyék túlmutat az alakzat szélén, ezáltal azt a benyomást keltve, hogy az alakzat a dia fölött van. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjen a sablon világításához és stílusához.

Ez a C# kód azt mutatja, hogyan alkalmazzon [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) egy téglalapra:

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

![Árnyék hatás](shadow_effect.png)

#### **Az Árnyék Irányának Szabályozása, Amikor Egy Alakzat Forgat**

Alapértelmezés szerint a [RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) `true`, így az árnyék a formával együtt forog. Ahhoz, hogy a különböző forgatású alakzatok ugyanabból az irányból legyenek megvilágítva, állítsa ezt a tulajdonságot `false`‑ra, és adja meg az árnyékoknak ugyanazt a [Direction](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/) értéket.

A példa két nyilat hoz létre szürke árnyékokkal, amelyek jobbra vannak eltolva (`Direction = 0`). Ezután megkettőzi a diát, és mindkét nyilat 90°‑kal óramutató járásával megegyező irányba forgatja.

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

A második dián a bal nyíl árnyéka lefelé esik, míg a jobb nyíl árnyéka továbbra is jobbra mutat. A beállított irány mindkét árnyék esetén 0° marad.

![PowerPoint megjelenítés 90°-os forgatás előtt és után. Mindkét árnyék jobbra kezdődik. A forgatás után az árnyék a bal nyíl alatt helyezkedik el, a jobb nyíl mellett marad jobbra.](arrow-shadow-rotation.png)

### **Belső Árnyék Alkalmazása**

Egy sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy a kártya vagy panel benyomott megjelenést kapjon. A külső árnyék az alakzat kívülre nyúlik, és azt feltünteti, hogy kiemelkedik, míg a belső árnyék az élén belül árnyékol.

Hívja meg a [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) metódust, majd konfigurálja a [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) objektumot. A nagyobb értékek lágyabb éleket eredményeznek.

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

A belső árnyék eltávolításához hívja meg a [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) metódust az alakzat effect formátumán.

### **Előbeállított Árnyék Alkalmazása, Módosítása és Eltávolítása**

Hívja meg az [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) metódust, és állítsa be a [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) értékét egy neves [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) típusra. A stílus váltásához módosítsa az előre beállítást ugyanazon alakzaton. Az [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) meghívásával eltávolíthatja az árnyékot, miközben megőrzi a kitöltést és a körvonalat.

Ez a példa minden lépésnél egy másolatot tart meg a téglalapról. Mindkét árnyék 10 ponttal van eltolva. A 225°‑os irány az első árnyékot a téglalap bal felé és feljebb helyezi, a 45°‑os irány a másodikat alulra és jobbra.

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
| ![Nincs árnyék](preset_shadow_original.png) | ![Felső bal csapott árnyék](preset_shadow_top_left.png) | ![Alsó jobb csapott árnyék](preset_shadow_bottom_right.png) | ![Nincs árnyék eltávolítás után](preset_shadow_removed.png) |

## **Reflexiós Hatás Alkalmazása**

A reflexiós hatás Aspose.Slides for .NET‑ben való alkalmazásához hozzáadhat egy tükörszerű tükröződést az alakzatokhoz, és beállíthatja a távolságot, átlátszóságot és méretet. Ez a hatás javítja a prezentációk esztétikáját, egy letisztultabb és kifinomultabb megjelenést kölcsönözve az alakzatoknak. Könnyen megvalósítható egyszerű kóddal, gyorsan alkalmazható több elemre a konzisztens tervezés érdekében.

Ez a C# kód azt mutatja, hogyan alkalmazzon [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) egy alakzatra:

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

![Tükrözési hatás](reflection_effect.png)

## **Glow Hatás Alkalmazása**

A glow hatás alkalmazásához az Aspose.Slides for .NET‑ben hozzáadhat egy puha, fénylő aurát az alakzatok köré, és beállíthatja a színt és méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemfelkeltő vizuális elemet ad a prezentációnak. Könnyen megvalósítható minimális kóddal, javítva a diák általános megjelenését.

Ez a C# kód azt mutatja, hogyan alkalmazzon [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) egy alakzatra:

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

![Ragyogás hatás](glow_effect.png)

## **Lágy Szélek Hatás Alkalmazása**

A lágy szélek hatás alkalmazásához az Aspose.Slides for .NET‑ben létrehozhat egy sima, elmosódott átmenetet az alakzat szélei körül. Ez a hatás finomabb és kifinomultabb megjelenést kölcsönöz, tökéletes a puhább megjelenést igénylő tervekhez. Könnyen beállíthatja a sugár paramétert a kívánt hatás eléréséhez különböző alakzatok esetében.

Ez a C# kód azt mutatja, hogyan alkalmazzon [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) egy alakzatra:

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

![Lágy szélek hatás](soft_edges_effect.png)

## **Elmosódás Hatás Alkalmazása**

Használja a shape blur‑t a kitöltés és a körvonal elmosásához, miközben az alakzat szerkeszthető marad. Hívja meg a [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) metódust az alakzat effect formátumán. A sugár pontban (1/72 hüvelyk) van megadva: használjon nem negatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár esetén a megjelenés változatlan marad.

A [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) beállítás szabályozza a hatás látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, van vágva. `true` esetén az elmosódás túlnyúlhat ezekre a határokra. Egyik beállítás sem változtatja meg az alakzat pozícióját vagy méretét.

Az alábbi összehasonlítás ugyanazt a kitöltést, körvonalat és alakzateméretet használja. A felső sor a `grow = false` esetet, az alsó sor a `grow = true` esetet mutatja.

![Eredeti téglalap összehasonlítva 5‑ és 15‑pontos elmosódási sugárral, a növekedés letiltott és engedélyezett állapottal](shape_blur_comparison.png)

Ez a C# példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5‑pontos elmosódást alkalmaz, majd 15‑pontos elmosódásra frissíti a [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) újbóli meghívásával. Mindkét elmosódott állapotot menti, majd a [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) meghívásával menti az árnyék nélküli alakzatot.

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

A shape blur eg simultaneously a kitöltést és a körvonalat érinti. A lágy szélek hatás elhalványítja az alakzat szélét, míg az árnyék elmosódása csak az árnyékot lágyítja. A képarány‑átalakító hatások a kép tartalmára vonatkoznak; ez a példa közvetlenül az alakzat effect formátumára alkalmaz elmosódást, anélkül hogy az alakzatot képpé alakítaná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat – például árnyékot, reflexiót és glow‑t – kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, többek között autoshape‑okra, diagramokra, táblázatokra, képekre, SmartArt‑objektumokra, OLE‑objektumokra és egyebekre.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, hatásokat alkalmazhat csoportosított alakzatokra is. A hatás a teljes csoportra lesz alkalmazva.