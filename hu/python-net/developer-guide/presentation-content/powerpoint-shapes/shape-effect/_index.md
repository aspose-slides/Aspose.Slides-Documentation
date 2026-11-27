---
title: Alakzat effektusok alkalmazása a prezentációkban Python segítségével
linktitle: Alakzat effektus
type: docs
weight: 30
url: /hu/python-net/shape-effect
keywords:
- alakzat effektus
- árnyék effektus
- tükrözés effektus
- ragyogás effektus
- lágy szélek effektus
- effektus formátum
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Alakítsa át PPT, PPTX és ODP fájljait fejlett alakzat effektusokkal az Aspose.Slides for Python segítségével – hozzon létre lenyűgöző, professzionális diáket pillanatok alatt."
---
## **Bevezetés**

Miközben a PowerPoint effektusok használhatók egy alakzat kiemelésére, különböznek a [kitöltések](/slides/hu/python-net/shape-formatting/#gradient-fill) vagy a körvonalaktól. PowerPoint effektusok segítségével meggyőző tükrözéseket hozhatunk létre egy alakzaton, szétteríthetjük egy alakzat ragyogását stb.

![Alakzati effektus](shape-effect.png)

A PowerPoint hat effektust biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több effektust alkalmazhat egy alakzatra.

Egyes effektus-kombinációk jobban néznek ki, mint mások. Emiatt a PowerPointnek vannak **Preset** opciói. A Preset opciók lényegében egy jól kinéző kombinációja két vagy több effektusnak. Így egy preset kiválasztásával nem kell időt pazarolni különböző effektusok tesztelésére vagy kombinálására a megfelelő kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) osztály alatt biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik, hogy ugyanazokat az effektusokat alkalmazza PowerPoint-prezentációk alakzataira.

## **Árnyék effektus alkalmazása**

Az Aspose.Slides for Python via .NET támogatja a külső és belső árnyékokat alakzatoknál. Testreszabhatja a színüket, irányukat, távolságukat és a homály sugarát, hogy illeszkedjenek a prezentáció tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a diavetítés háttérén. Az árnyék a alakzat szélén túl nyúlik, és azt a benyomást kelti, mintha az alakzat a dia fölé lenne emelve. Állítsa be a színét, irányát, távolságát és a homály sugarát, hogy megfeleljen a sablon megvilágításának és stílusának.

Ez a Python kód bemutatja, hogyan lehet alkalmazni a [külső árnyék effektust](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) egy téglalapra:

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

![Árnyék effektus](shadow_effect.png)

#### **Az árnyék irányának szabályozása alakzat forgatásakor**

Alapértelmezés szerint az [OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/) `True`, így az árnyék az alakzattal együtt forog. Ahhoz, hogy a különböző forgatású alakzatok ugyanabból az irányból legyenek megvilágítva, állítsa ezt a tulajdonságot `False`-ra, és adja meg az árnyékoknak ugyanazt a [irányt](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/).

A példa két nyilat hoz létre szürke árnyékokkal, amelyek 42 ponttal jobbra vannak eltolva (`direction = 0`). Ezután megkettőzi a diát, és mindkét nyilat 90°-kal az óramutató járásával megegyező irányba forgatja.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    before = presentation.slides[0]

    left = before.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 55, 130, 110, 60)
    left.fill_format.fill_type = slides.FillType.SOLID
    left.fill_format.solid_fill_color.color = slides.Color.steel_blue
    left.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    left.effect_format.enable_outer_shadow_effect()
    shadow = left.effect_format.outer_shadow_effect
    shadow.shadow_color.color = slides.Color.gray
    shadow.direction = 0
    shadow.distance = 42
    shadow.blur_radius = 0
    shadow.rotate_shadow_with_shape = True

    right = before.shapes.add_clone(left)
    right.x = 395
    right.effect_format.outer_shadow_effect.rotate_shadow_with_shape = False

    after = presentation.slides.add_clone(before)
    for arrow in after.shapes:
        arrow.rotation = 90

    presentation.save("arrow_shadows.pptx", slides.export.SaveFormat.PPTX)
```

A második dián a bal nyíl az árnyékot lefelé vetíti, míg a jobb nyíl árnyéka továbbra is jobbra mutat. A beállított irány mindkét árnyéknál 0° marad.

![PowerPoint megjelenítés 90° forgatás előtt és után. Mindkét árnyék jobbra kezdődik. A forgatás után az árnyék a bal nyíl alá kerül, és a jobb nyílnál továbbra is jobbra marad.](arrow-shadow-rotation.png)

### **Belső árnyék alkalmazása**

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy egy kártya vagy panel visszavonult megjelenést kapjon. A külső árnyék az alakzat kívülére nyúlik, és azt a benyomást kelti, hogy az emelkedett, míg a belső árnyék az alakzat szélein belül árnyékol.  

Hívja meg a [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) metódust, majd konfigurálja a [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) beállítást. A nagyobb blur-radius értékek lágyabb éleket eredményeznek.

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

![Világoskék téglalap belső árnyékkal](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) metódust az alakzat effektusformátumán.

### **Preset árnyék alkalmazása, módosítása és eltávolítása**

Hívja meg a [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) metódust, és állítsa be az árnyék [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) tulajdonságát egy [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) értékre. A stílusok váltásához módosítsa a presetet ugyanazon az alakzaton. Hívja meg a [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) metódust az árnyék eltávolításához, miközben megőrzi a kitöltést és a körvonalat.

Ez a példa négy szakaszt mutat egymás mellett egy dián. Minden változás előtt klónozza a téglalapot, hogy összehasonlíthassa az eredményeket. Mindkét árnyék 10 ponttal van eltolva. A 225°-os irány az első árnyékot a téglalap fölé és balra helyezi, míg a 45°-os a másodikat alulra és jobbra.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| Eredeti | Első preset | Második preset | Eltávolítás után |
| :---: | :---: | :---: | :---: |
| ![Nincs árnyék](preset_shadow_original.png) | ![Bal-felső vetett árnyék](preset_shadow_top_left.png) | ![Jobb-alsó vetett árnyék](preset_shadow_bottom_right.png) | ![Nincs árnyék eltávolítás után](preset_shadow_removed.png) |

## **Tükrözés effektus alkalmazása**

Az Aspose.Slides for Python via .NET-ben a tükrözés effektus alkalmazásához hozzáadhat tükörszerű tükrözést alakzatokhoz, és módosíthatja a paramétereket, mint a távolság, átlátszóság és méret. Ez az effektus növeli a prezentációk esztétikáját, mivel az alakzatoknak letisztultabb és kifinomultabb megjelenést kölcsönöz. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemre a következetes tervezés érdekében.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [tükrözés effektust](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) egy alakzatra:

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

![Tükrözés effektus](reflection_effect.png)

## **Ragyogás effektus alkalmazása**

Az Aspose.Slides for Python via .NET-ben a ragyogás effektus alkalmazásához körül egy alakzatot lágy, fényes aurával láthat el, és állíthatja a szín és a méret tulajdonságait. Ez az effektus segít kiemelni az alakzatokat és vonzó, szemét vonzó vizuális elemet ad a prezentációhoz. Egyszerű kóddal könnyen megvalósítható, fokozva a diák általános megjelenését.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [ragyogás effektust](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) egy alakzatra:

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

![Ragyogás efektus](glow_effect.png)

## **Lágy szélek effektus alkalmazása**

Az Aspose.Slides for Python via .NET-ben a lágy szélek effektus használatával sima, elmosódott átmenetet hozhat létre az alakzat szélén. Ez az effektus finomabb és kifinomultabb megjelenést ad, amely tökéletes olyan tervekhez, amelyeknek gyengéd, lágyabb megjelenésre van szükségük. Különböző alakzatokra könnyen szabályozhatja a sugár paramétereit a kívánt hatás eléréséhez.

Ez a Python kód bemutatja, hogyan kell alkalmazni a [lágy széleket](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) egy alakzatra:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Lágy szélek effektus](soft_edges_effect.png)

## **Homály effektus alkalmazása**

Használja a forma-homályt a forma kitöltésének és körvonalának lágyításához, miközben a forma szerkeszthető marad. Hívja meg a [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) metódust a forma effektusformátumán. A sugár pontban van mérve (1/72 hüvelyk): használjon nem negatív értéket, a nagyobb értékek erősebb homályt eredményeznek. A nulla sugár változatlanul hagyja a megjelenést.

A [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) beállítás a hatás látható határait szabályozza. `False` értéknél a homály az eredeti festett határokra, beleértve a körvonalat, lesz vágva. `True` értéknél a homály túlnyúlhat ezeken a határokon. Egyik beállítás sem változtatja meg a forma pozícióját vagy méretét.

Az alábbi összehasonlítás minden esetben ugyanazzal a kitöltéssel, körvonallal és forma méretekkel dolgozik. A felső sorban `grow = False`; az alsó sorban `grow = True`.

![Eredeti téglalap összehasonlítva 5 és 15 pontos homály sugarakkal, a grow letiltva és engedélyezve](shape_blur_comparison.png)

Ez a Python példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pontos homályt alkalmaz, majd újra meghívja a [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) metódust 15 pontos homályra. Mindkét homályos állapotot menti, majd meghívja a [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) metódust és elmenti a formát homály nélkül.

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

A forma-homály együtt érinti a kitöltést és a körvonalat. A lágy szélek effektus elhalványítja a forma széleit, míg az árnyék homály csak az árnyékot lágyítja. A képtranszformációs effektusok a képtartalmon működnek; ez a példa közvetlenül a forma effektusformátumára alkalmaz homályt anélkül, hogy a formát képpé konvertálná.

## **GYIK**

**Alkalmazhatok több effektust ugyanarra az alakzatra?**

Igen, több különböző effektust, például árnyékot, tükrözést és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok effektusokat?**

Effektusokat különféle alakzatokra alkalmazhat, beleértve az autoshape-okat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok effektusokat csoportos alakzatokra?**

Igen, csoportos alakzatokra is alkalmazhat effektusokat. Az effektus az egész csoportra lesz alkalmazva.