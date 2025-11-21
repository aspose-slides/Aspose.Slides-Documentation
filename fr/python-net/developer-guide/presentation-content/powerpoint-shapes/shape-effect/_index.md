---
title: Appliquer des effets de forme dans les présentations avec Python
linktitle: Effet de forme
type: docs
weight: 30
url: /fr/python-net/shape-effect
keywords:
- effet de forme
- effet d'ombre
- effet de réflexion
- effet de lueur
- effet de bords doux
- format d'effet
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Transformez vos fichiers PPT, PPTX et ODP avec des effets de forme avancés en utilisant Aspose.Slides pour Python—créez des diapositives percutantes et professionnelles en quelques secondes."
---


Bien que les effets dans PowerPoint puissent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/python-net/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets PowerPoint, vous pouvez créer des reflets convaincants sur une forme, diffuser la lueur d'une forme, etc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme. 

* Certaines combinaisons d'effets sont plus esthétiques que d'autres. Pour cette raison, les options PowerPoint sous **Preset**. Les options Preset sont essentiellement une combinaison reconnue de deux effets ou plus qui a bonne apparence. Ainsi, en sélectionnant un preset, vous n'aurez pas à perdre de temps à tester ou combiner différents effets pour trouver une belle combinaison.

Aspose.Slides fournit des propriétés et des méthodes dans la classe [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) qui permettent d'appliquer les mêmes effets aux formes dans les présentations PowerPoint.

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


## **Appliquer l'effet de bord doux**

Ce code Python vous montre comment appliquer les bords doux à une forme :
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

**Puis-je appliquer plusieurs effets à la même forme ?**

Oui, vous pouvez combiner différents effets, tels que l'ombre, la réflexion et la lueur, sur une seule forme pour créer une apparence plus dynamique.

**Sur quelles formes puis‑je appliquer des effets ?**

Vous pouvez appliquer des effets à diverses formes, notamment les autoshapes, les graphiques, les tableaux, les images, les objets SmartArt, les objets OLE, etc.

**Puis‑je appliquer des effets aux formes groupées ?**

Oui, vous pouvez appliquer des effets aux formes groupées. L'effet sera appliqué à l'ensemble du groupe.