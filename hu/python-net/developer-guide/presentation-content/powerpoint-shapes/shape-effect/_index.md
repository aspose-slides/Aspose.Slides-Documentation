---
title: Alakzat hatások alkalmazása prezentációkban Python segítségével
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/python-net/shape-effect
keywords:
- alakzat hatás
- árnyék hatás
- tükröződés hatás
- ragyogás hatás
- lágy szélek hatás
- hatásformátum
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Alakítsa át PPT, PPTX és ODP fájljait fejlett alakzat hatásokkal az Aspose.Slides for Python segítségével — hozzon létre lenyűgöző, professzionális diákat néhány másodperc alatt."
---
## **Bevezetés**

Míg a PowerPoint effektusait egy alakzat kiemelésére lehet használni, különböznek a [kitöltésektől](/slides/hu/python-net/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint effektusokkal meggyőző tükröződéseket hozhat létre egy alakzaton, szórhatja az alakzat ragyogását stb.

![Alakzat hatás](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Bizonyos hatáskombinációk jobban néznek ki, mint mások. Emiatt a PowerPointnek vannak **Preset** opciói. Az előbeállítások lényegében egy jól kinéző kombinációt jelentenek két vagy több effektusból. Így egy előbeállítás kiválasztásával nem kell időt vesztegetni különböző hatások tesztelésével vagy kombinálásával a megfelelő kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) osztály alatt biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik, hogy ugyanazokat a hatásokat alkalmazza a PowerPoint-prezentációk alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for Python via .NET támogatja a külső és belső árnyékokat alakzatok számára. Színét, irányát, távolságát és elmosódási sugarát testreszabhatja, hogy illeszkedjen a prezentációja dizájnjához.

### **Külső árnyék alkalmazása**

Egy külső árnyékot használva kiemelhet egy kártyát vagy panelt a dia háttérrel szemben. Az árnyék túlnyúlik a alakzat szélén, és azt a benyomást kelti, hogy az alakzat a dia felett emelkedik. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjen a sablon megvilágításához és stílusához.

Ez a Python kód megmutatja, hogyan lehet egy téglalapra alkalmazni a [külső árnyék hatást](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) :

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

![Árnyék hatás](shadow_effect.png)

### **Belső árnyék alkalmazása**

Egy sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy a kártya vagy panel mélyedő megjelenést kapjon. A külső árnyék a alakzatot kintől nyújtja, és emelkedettnek mutatja, míg egy belső árnyék az él belsejét árnyékolja.

Az [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) meghívásával, majd a [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) konfigurálásával. A nagyobb elmosódási sugárértékek lágyabb széleket eredményeznek.

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

### **Előre beállított árnyék alkalmazása, módosítása és eltávolítása**

Hívja meg a [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) metódust, és állítsa be az árnyék [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) tulajdonságát egy [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) értékre. A stílus váltásához változtassa meg a presetet ugyanazon az alakzaton. A [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) meghívásával eltávolíthatja az árnyékot, miközben megőrzi a kitöltést és a körvonalat.

Ez a példa négy szakaszt mutat egymás mellett egy dián. Minden változás előtt lemásolja a téglalapot, hogy összehasonlíthassa az eredményeket. Mindkét árnyék 10 ponttal van eltolva. A 225° irány az első árnyékot a téglalap felett és balra helyezi, míg a 45° a másodikat alul és jobbra.

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

| Eredeti | Első előbeállítás | Második előbeállítás | Eltávolítás után |
| :---: | :---: | :---: | :---: |
| ![Nincs árnyék](preset_shadow_original.png) | ![Bal felső vető árnyék](preset_shadow_top_left.png) | ![Jobb alsó vető árnyék](preset_shadow_bottom_right.png) | ![Nincs árnyék eltávolítás után](preset_shadow_removed.png) |

## **Tükröződés alkalmazása**

Az Aspose.Slides for Python via .NET segítségével tükröződés hatást alkalmazhat, hozzáadva a alakzatokhoz tükörszerű visszaverődést, a távolság, átlátszóság és méret paramétereinek beállításával. Ez a hatás javítja a prezentációk esztétikáját, kifinomultabb és elegánsabb megjelenést kölcsönözve az alakzatoknak. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemre a konzisztens dizájnért.

Ez a Python kód megmutatja, hogyan kell egy alakzatra alkalmazni a [tükröződés hatást](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) :

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

![Tükröződés hatás](reflection_effect.png)

## **Ragyogás alkalmazása**

Az Aspose.Slides for Python via .NET segítségével egy ragyogás hatást alkalmazhat egy alakzatra, puha, fényes aurát adva körülötte, a szín és méret tulajdonságok beállításával. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemrefénylő vizuális elemet ad a prezentációjához. Minimális kóddal könnyen megvalósítható, javítva a diák általános megjelenését.

Ez a Python kód megmutatja, hogyan kell egy alakzatra alkalmazni a [ragyogás hatást](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) :

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

![Ragyogás hatás](glow_effect.png)

## **Lágy szélek hatás alkalmazása**

Az Aspose.Slides for Python via .NET segítségével lágy szélek hatást lehet alkalmazni, így egy sima, elmosódott átmenetet hozva létre az alakzat szélein. Ez a hatás finomabb és kifinomultabb megjelenést ad, tökéletes azoknak a terveknek, amelyeknek gyengédebb, lágyabb hatásra van szükségük. Könnyen beállíthatja a paramétereket, például a sugarat, a kívánt hatás eléréséhez különböző alakzatokban a prezentációban.

Ez a Python kód megmutatja, hogyan kell egy alakzatra alkalmazni a [lágy széleket](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) :

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

## **Elmosódás hatás alkalmazása**

Egy alakzat elmosódásával lágyíthatja az alakzat kitöltését és körvonalát, miközben az alakzat szerkeszthető marad. Hívja meg a [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) metódust az alakzat efektusformátumán. A sugár pontban van mérve (1/72 hüvelyk): használjon nem negatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugarú beállítás változatlanul hagyja a megjelenést.

A [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) beállítás szabályozza a hatás látható határait. `False` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, lesz levágva. `True` esetén az elmosódás túlnyúlhat ezen határokon. Egyik beállítás sem változtatja meg az alakzat helyzetét vagy méreteit.

Az alábbi összehasonlításban ugyanazt a kitöltést, körvonalat és alakzati méreteket használjuk mindvégig. A felső sor `grow = False` értéket, az alsó sor `grow = True` értéket használ.

![Az eredeti téglalap összehasonlítva 5 és 15 pontú elmosódási sugárral, a grow kikapcsolt és bekapcsolt állapotban](shape_blur_comparison.png)

Ez a Python példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pontos elmosódást alkalmaz, majd a [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) újbóli meghívásával 15 pontos elmosódásra frissíti. Mindkét elmosódott állapotot menti, majd a [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) hívásával elmenti az alakzatot elmosódás nélkül.

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

Az alakzat elmosódás a kitöltést és a körvonalat együtt befolyásolja. A lágy szélek hatás elhalványítja az alakzat széleit, míg az árnyék elmosódás csak az árnyékot lágyítja. A képtranszformációs hatások a képtartalmon működnek; ez a példa közvetlenül az alakzat effektusformátumára alkalmazza az elmosódást anélkül, hogy az alakzatot képpé alakítaná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat – például árnyékot, tükröződést és ragyogást – kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Az effectusokat különféle alakzatokra alkalmazhatja, többek között autóalakzatokra, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és egyebekre.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, csoportosított alakzatokra is alkalmazhat hatásokat. A hatás az egész csoportra lesz alkalmazva.