---
title: Alakzat hatások alkalmazása prezentációkban Python használatával
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/python-net/shape-effect
keywords:
- alakzat hatás
- árnyék hatás
- reflexió hatás
- ragyogás hatás
- lágy szélek hatás
- hatás formátum
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Alakítsa át PPT, PPTX és ODP fájljait fejlett alakzat hatásokkal az Aspose.Slides for Python segítségével—hozzon létre lenyűgöző, professzionális diákat percek alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásait használhatja egy alakzat kiemelésére, különböznek a [kitöltésektől](/slides/hu/python-net/shape-formatting/#gradient-fill) vagy körvonalaktól. A PowerPoint hatásainak használatával meggyőző tükröződéseket hozhat létre egy alakzaton, illetve szórhatja annak ragyogását, stb.

![Alakzat hatás](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Egyes hatáskombinációk jobban néznek ki, mint mások. Emiatt a PowerPointnek vannak **Preset** opciói. A Preset lehetőségek lényegében egy ismert, jól kinéző kombinációja két vagy több hatásnak. Így egy előre beállítást kiválasztva nem kell időt vesztegetnie a különböző hatások tesztelésével vagy kombinálásával, hogy szép kombinációt találjon.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) osztály alatt tulajdonságokat és metódusokat biztosít, amelyek lehetővé teszik, hogy ugyanazokat a hatásokat alkalmazza a PowerPoint előadások alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for Python via .NET külső és belső árnyékokat támogat alakzatokhoz. Testreszabhatja azok színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a bemutató tervezésének.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérből. Az árnyék a forma szélein túlnyúlik, így a forma a dia felett lebegőnek tűnik. Állítsa be színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjen a sablon világításához és stílusához.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [külső árnyék hatást](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) egy téglalapra:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Árnyék hatás](shadow_effect.png)

### **Belső árnyék alkalmazása**

Ha egy sablon vizuális stílusát szeretné reprodukálni, használjon belső árnyékot, hogy a kártya vagy panel üreges megjelenést kapjon. A külső árnyék a forma külső részén helyezkedik el, és emelkedettnek mutatja, míg a belső árnyék az élén belül árnyékol.

Hívja meg a [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), majd konfigurálja a [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). A nagyobb elmosódási sugár értékek lágyabb széleket eredményeznek.

Ez a Python példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, majd PPTX fájlként menti:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = draw.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Világoskék téglalap belső árnyékkal](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) metódust az alakzat effektus formátumán.

## **Reflexió hatás alkalmazása**

A reflexió hatás alkalmazásához az Aspose.Slides for Python via .NET-ben hozzáadhat tükörszerű tükröződést alakzatokhoz, beállítva a távolságot, átlátszóságot és méretet. Ez a hatás növeli a bemutatók esztétikáját, elegánsabb megjelenést kölcsönözve az alakzatoknak. Egyszerű kóddal könnyen megvalósítható, és gyorsan alkalmazható több elemre a konzisztens tervezés érdekében.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [reflexió hatás](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) hatást egy alakzatra:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Reflexió hatás](reflection_effect.png)

## **Ragyogás hatás alkalmazása**

A ragyogás hatás alkalmazásához egy alakzatra az Aspose.Slides for Python via .NET-ben hozzáadhat egy lágy, fényes aurát alakzatok köré, beállítva a színt és méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemkáprázó vizuális elemet ad a bemutatónak. Egyszerű kóddal könnyen megvalósítható, javítva a diák általános megjelenését.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [ragyogás hatás](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) hatást egy alakzatra:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Ragyogás hatás](glow_effect.png)

## **Lágy szélek hatás alkalmazása**

A lágy szélek hatás alkalmazásához az Aspose.Slides for Python via .NET-ben létrehozhat egy sima, elmosódott átmenetet egy alakzat szélein. Ez a hatás finomabb és kifinomultabb megjelenést kölcsönöz, tökéletes azoknak a tervezéseknek, amelyeknek enyhe, lágyabb megjelenésre van szükségük. Könnyedén beállíthatja a sugár értékét, hogy a kívánt hatást elérje különböző alakzatoknál a bemutatóban.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [lágy szélek](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) hatást egy alakzatra:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Lágy szélek hatás](soft_edges_effect.png)

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, kombinálhat különböző hatásokat, például árnyékot, reflexiót és ragyogást, egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Alkalmazhat hatásokat különféle alakzatokra, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, alkalmazhat hatásokat csoportosított alakzatokra. A hatás az egész csoportra lesz érvényes.