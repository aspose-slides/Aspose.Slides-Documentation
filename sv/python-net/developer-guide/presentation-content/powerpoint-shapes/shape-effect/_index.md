---
title: Tillämpa formseffekter i presentationer med Python
linktitle: Formseffekt
type: docs
weight: 30
url: /sv/python-net/shape-effect
keywords:
- formseffekt
- skuggeffekt
- reflektionseffekt
- glödseffekt
- mjuka kanter-effekt
- effektformat
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Transformera dina PPT-, PPTX- och ODP-filer med avancerade formseffekter med Aspose.Slides för Python—skapa slående, professionella bilder på sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fills](/slides/sv/python-net/shape-formatting/#gradient-fill) eller konturer. Med PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en glöd runt en form osv.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan applicera en eller flera effekter på en form. 

* Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen finns PowerPoint‑alternativ under **Preset**. Preset‑alternativen är i princip en beprövad, bra‑utseende kombination av två eller fler effekter. På så sätt, genom att välja ett förinställt alternativ, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en fin kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/effectformat/) som låter dig tillämpa samma effekter på former i PowerPoint‑presentationer.

## **Tillämpa skuggeffekt**

Den här Python‑koden visar hur du applicerar den yttre skuggeffekten (`outer_shadow_effect`) på en rektangel:

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

## **Tillämpa reflektionseffekt**

Den här Python‑koden visar hur du applicerar reflektionseffekten på en form:

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

## **Tillämpa glödseffekt**

Den här Python‑koden visar hur du applicerar glödseffekten på en form:

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

## **Tillämpa mjuka kanter‑effekt**

Den här Python‑koden visar hur du applicerar mjuka kanter på en form:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Kan jag applicera flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag applicera effekter på?**

Du kan applicera effekter på olika former, inklusive autoformer, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag applicera effekter på grupperade former?**

Ja, du kan applicera effekter på grupperade former. Effekten kommer att gälla för hela gruppen.