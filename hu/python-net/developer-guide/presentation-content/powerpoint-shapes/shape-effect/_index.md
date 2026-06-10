---
title: Alakzat hatások alkalmazása előadásokban Python segítségével
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
- hatás formátum
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Alakítsa át PPT, PPTX és ODP fájljait fejlett alakzat hatásokkal az Aspose.Slides for Python segítségével—hozzon létre lenyűgöző, professzionális diákat pillanatok alatt."
---
## **Bevezetés**

Míg a PowerPoint‑ban a hatások segítségével kiemelhetünk egy alakzatot, ezek különböznek a [kitöltésektől](/slides/hu/python-net/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint‑hatásokkal meggyőző tükröződéseket hozhatunk létre egy alakzaton, szórhatjuk az alakzat ragyogását stb.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* A PowerPoint hat hatást kínál, amelyeket alakzatokra lehet alkalmazni. Egy alakzatra egy vagy több hatást is alkalmazhatunk.  
* Néhány hatáskombináció jobb hatást kelt, mint mások. Emiatt a PowerPoint a **Preset** (előre beállított) lehetőségek alatt kínál opciókat. Az előre beállított opciók lényegében egy jól kinéző, két vagy több hatásból álló kombinációt jelentenek. Így egy előre beállított kiválasztásával nem kell időt vesztegetni a különböző hatások tesztelésével vagy kombinálásával a megfelelő eredmény megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/effectformat/) osztályban olyan tulajdonságokat és metódusokat biztosít, amelyekkel ugyanazokat a hatásokat alkalmazhatja a PowerPoint‑prezentációk alakzataira.

## **Árnyék hatás alkalmazása**

Ez a Python‑kód megmutatja, hogyan alkalmazhatja a külső árnyék hatást (`outer_shadow_effect`) egy téglalapra:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Tükröződés hatás alkalmazása**

Ez a Python‑kód megmutatja, hogyan alkalmazhatja a tükröződés hatást egy alakzatra:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **Ragyogás hatás alkalmazása**

Ez a Python‑kód megmutatja, hogyan alkalmazhatja a ragyogás hatást egy alakzatra:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **Lágy szélek hatás alkalmazása**

Ez a Python‑kód megmutatja, hogyan alkalmazhatja a lágy széleket egy alakzatra:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat – például árnyékot, tükröződést és ragyogást – kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra – például önálló alakzatokra, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és egyebekre – alkalmazhat hatásokat.

**Alkalmazhatok hatásokat csoportos alakzatokra?**

Igen, hatásokat alkalmazhat csoportos alakzatokra is. A hatás a teljes csoportra lesz érvényes.