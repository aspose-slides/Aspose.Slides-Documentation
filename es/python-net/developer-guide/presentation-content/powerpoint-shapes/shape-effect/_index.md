---
title: Efecto de Forma
type: docs
weight: 30
url: /python-net/shape-effect
keywords: "Efecto de forma, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Aplicar efecto a la forma de PowerPoint en Python"
---

Mientras que los efectos en PowerPoint pueden ser utilizados para hacer que una forma resalte, se diferencian de [rellenos](/slides/python-net/shape-formatting/#gradient-fill) o contornos. Utilizando efectos de PowerPoint, puedes crear reflexiones convincentes en una forma, difundir el resplandor de una forma, etc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint proporciona seis efectos que se pueden aplicar a las formas. Puedes aplicar uno o más efectos a una forma. 

* Algunas combinaciones de efectos se ven mejor que otras. Por esta razón, las opciones de PowerPoint bajo **Preestablecido**. Las opciones de Preestablecido son esencialmente una combinación conocida y atractiva de dos o más efectos. De esta manera, al seleccionar un preestablecido, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides proporciona propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) que te permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar Efecto de Sombra**

Este código en Python te muestra cómo aplicar el efecto de sombra exterior (`outer_shadow_effect`) a un rectángulo:

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

## **Aplicar Efecto de Reflexión**

Este código en Python te muestra cómo aplicar el efecto de reflexión a una forma:

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

## **Aplicar Efecto de Resplandor**

Este código en Python te muestra cómo aplicar el efecto de resplandor a una forma:

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

## **Aplicar Efecto de Bordes Suaves**

Este código en Python te muestra cómo aplicar bordes suaves a una forma:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```