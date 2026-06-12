---
title: Toepassen van vormeffecten in presentaties met Python
linktitle: Vorm Effect
type: docs
weight: 30
url: /nl/python-net/shape-effect
keywords:
- vormeffect
- schaduweffect
- reflectie-effect
- gloeieffect
- zachte randen-effect
- effectformaat
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Transformeer uw PPT-, PPTX- en ODP-bestanden met geavanceerde vormeffecten via Aspose.Slides voor Python — maak in enkele seconden opvallende, professionele dia's."
---
## **Inleiding**

Hoewel effecten in PowerPoint gebruikt kunnen worden om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/python-net/shape-formatting/#gradient-fill) of contouren. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm maken, de gloed van een vorm verspreiden, enzovoort.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meerdere effecten op een vorm toepassen. 

* Sommige combinaties van effecten zien er beter uit dan andere. Om die reden biedt PowerPoint opties onder **Voorinstelling**. De Voorinstelling‑opties zijn in feite een bekend goed uitziende combinatie van twee of meer effecten. Op deze manier hoef je bij het selecteren van een voorinstelling geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/effectformat/)‑klasse die je in staat stellen dezelfde effecten toe te passen op vormen in PowerPoint‑presentaties.

## **Schaduweffect toepassen**

Deze Python‑code laat zien hoe je het buitenste schaduweffect (`outer_shadow_effect`) op een rechthoek toepast:

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

## **Reflectie‑effect toepassen**

Deze Python‑code laat zien hoe je het reflectie‑effect op een vorm toepast:

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

## **Gloeieffect toepassen**

Deze Python‑code laat zien hoe je het gloeieffect op een vorm toepast:

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

## **Zachte rand‑effect toepassen**

Deze Python‑code laat zien hoe je de zachte randen op een vorm toepast:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik meerdere effecten op dezelfde vorm toepassen?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één vorm om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autovormen, diagrammen, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt toegepast op de volledige groep.