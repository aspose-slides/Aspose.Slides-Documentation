---
title: Effet de forme
type: docs
weight: 30
url: /python-net/shape-effect
keywords: "Effet de forme, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Appliquer un effet à une forme PowerPoint en Python"
---

Bien que les effets dans PowerPoint puissent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/python-net/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets PowerPoint, vous pouvez créer des réflexions convaincantes sur une forme, étendre la lueur d'une forme, etc.

<img src="shape-effect.png" alt="effet-de-forme" style="zoom:50%;" />

* PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme. 

* Certaines combinaisons d'effets ont meilleure allure que d'autres. Pour cette raison, PowerPoint propose des options sous **Préréglage**. Les options de préréglage sont essentiellement une combinaison connue et esthétique de deux effets ou plus. De cette manière, en sélectionnant un préréglage, vous n'aurez pas à perdre du temps à tester ou à combiner différents effets pour trouver une belle combinaison.

Aspose.Slides fournit des propriétés et des méthodes sous la classe [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) qui vous permettent d'appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer l'effet d'ombre**

Ce code Python vous montre comment appliquer l'effet d'ombre externe (`outer_shadow_effect`) à un rectangle :

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

## **Appliquer l'effet de réflexion**

Ce code Python vous montre comment appliquer l'effet de réflexion à une forme :

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

## **Appliquer l'effet de lueur**

Ce code Python vous montre comment appliquer l'effet de lueur à une forme :

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

## **Appliquer l'effet de bords adoucis**

Ce code Python vous montre comment appliquer les bords adoucis à une forme :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```