---
title: Alakzat hatásainak alkalmazása prezentációkban Python‑nal
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/python-net/shape-effect
keywords:
- alakzat hatás
- árnyék hatás
- tükrözési hatás
- fénylő hatás
- lágy szélű hatás
- hatásformátum
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Alakítsa át PPT, PPTX és ODP fájljait fejlett alakzat hatásokkal az Aspose.Slides for Python használatával – hozzon létre lenyűgöző, professzionális diaképeket pillanatok alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásait egy alakzat kiemelésére lehet használni, különböznek a [kitöltésektől](/slides/hu/python-net/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint hatásainak használatával meggyőző tükröződéseket hozhat létre egy alakzaton, szórhatja az alakzat fénylődését stb.

![Shape effect](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyek alakzatokra alkalmazhatók. Egy vagy több hatást alkalmazhat egy alakzatra.

Néhány hatáskombináció jobban néz ki, mint mások. Emiatt a PowerPointnek vannak **Preset** (előre beállított) opciói. A Preset opciók lényegében egy jól kinéző kombinációt jelentenek két vagy több hatásból. Így egy preset kiválasztásával nem kell időt vesztegetni a különböző hatások tesztelésével vagy kombinálásával egy szép kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) osztály alatt olyan tulajdonságokat és metódusokat biztosít, amelyek lehetővé teszik ugyanazoknak a hatásoknak az alkalmazását PowerPoint‑prezentációk alakzataira.

## **Árnyék hatás alkalmazása**

Az Aspose.Slides for Python via .NET külső és belső árnyékokat támogat alakzatokhoz. Testreszabhatja azok színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjen a prezentációja dizájnjához.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a diavetítés háttérrel szemben. Az árnyék a forma szélei túlra nyúlik, így a benyomást keltve, hogy a forma a dia fölé emelkedik. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjen a sablon fényviszonyaihoz és stílusához.

Ez a Python kód bemutatja, hogyan alkalmazhatja a [külső árnyék hatást](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) egy téglalapra:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Shadow effect](shadow_effect.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy egy kártya vagy panel mélyedett megjelenést kapjon. A külső árnyék a forma kívülére nyúlik, és emelkedett hatást kelt, míg a belső árnyék a szélek belsejét árnyékolja.

Hívja meg a [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) metódust, majd konfigurálja a [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) beállítást. A nagyobb elmosódási radiusz értékek lágyabb éleket eredményeznek.

Ez a Python példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) metódust az alakzat hatáformátumán.

## **Tükrözési hatás alkalmazása**

A tükrözési hatás alkalmazásához az Aspose.Slides for Python via .NET‑ben egy tükörszerű visszaverődést adhat a alakzatokhoz, és beállíthatja a távolságot, az átlátszóságot és a méretet. Ez a hatás javítja a prezentációk esztétikáját, elegánsabb és kifinomultabb megjelenést kölcsönözve a formáknak. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemre a következetes dizájn érdekében.

Ez a Python kód bemutatja, hogyan alkalmazhatja a [tükrözési hatást](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) egy alakzatra:

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

![Reflection effect](reflection_effect.png)

## **Fénylő hatás alkalmazása**

A fénylő hatás alkalmazásához egy alakzaton az Aspose.Slides for Python via .NET‑ben puha, fényes aurát adhat a formák köré, és szabályozhatja például a színt és a méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemét vonzó vizuális elemet biztosít a prezentációhoz. Minimális kóddal könnyen megvalósítható, javítva a diák átfogó megjelenését.

Ez a Python kód bemutatja, hogyan alkalmazhatja a [fénylő hatást](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) egy alakzatra:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Glow effect](glow_effect.png)

## **Lágy szélű hatás alkalmazása**

A lágy szélű hatás alkalmazásához az Aspose.Slides for Python via .NET‑ben sima, elmosódott átmenetet hozhat létre egy alakzat szélei körül. Ez a hatás finomabb és kifinomultabb megjelenést ad, ami ideális olyan tervekhez, amelyeknek enyhe, lágyabb hatásra van szükségük. Könnyen beállíthatja a sugár paraméterét, hogy a kívánt hatást elérje a prezentáció különböző alakzatai esetén.

Ez a Python kód bemutatja, hogyan alkalmazhatja a [lágy szélű](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) hatást egy alakzatra:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Soft edges effect](soft_edges_effect.png)

## **Elmosódás hatás alkalmazása**

Használja a forma elmosódását a forma kitöltésének és körvonalának lágyítására, miközben a forma szerkeszthető marad. Hívja meg a [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) metódust az alakzat hatáformátumán. A sugár pontban mérhető (1/72 hüvelyk): használjon nem negatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár nem változtatja a megjelenést.

A [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) beállítás szabályozza a hatás látható határait. `False` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, lesz vágva. `True` esetén az elmosódás túlnyúlhat a határokon. Egyik beállítás sem módosítja az alakzat pozícióját vagy méreteit.

Az alábbi összehasonlítás ugyanazzal a kitöltéssel, körvonallal és alakzati mérettel végzett egységes tesztet mutat. A felső sor `grow = False`‑et használ; az alsó sor `grow = True`‑t.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Ez a Python példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, alkalmaz egy 5 pontos elmosódást, majd a [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) újrahívásával 15 pontos elmosódásra frissíti. Mindkét elmosódott állapotot elmenti, majd meghívja a [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) metódust, és elmenti a formát elmosódás nélkül.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

Az alakzat elmosódása egyaránt érinti a kitöltést és a körvonalat. A lágy szélű hatás elhalványítja a forma széleit, míg az árnyék elmosódása csak az árnyékot lágyítja. A képtranszformációs hatások a képtartalmon működnek; ez a példa közvetlenül a forma hatáformátumára alkalmaz elmosódást, anélkül, hogy a formát képpé konvertálná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat, például árnyékot, tükrözést és fénylődést egyesíthet egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, beleértve az autoshape‑eket, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, hatásokat csoportosított alakzatokra is alkalmazhat. A hatás az egész csoportra lesz érvényes.