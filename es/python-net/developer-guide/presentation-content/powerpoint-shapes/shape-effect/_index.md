---
title: Aplicar efectos de forma en presentaciones con Python
linktitle: Efecto de forma
type: docs
weight: 30
url: /es/python-net/shape-effect
keywords:
- efecto de forma
- efecto de sombra
- efecto de reflexión
- efecto de brillo
- efecto de bordes suaves
- formato de efecto
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Transforme sus archivos PPT, PPTX y ODP con efectos de forma avanzados usando Aspose.Slides para Python—crea diapositivas impactantes y profesionales en segundos."
---

Mientras que los efectos en PowerPoint pueden usarse para resaltar una forma, difieren de los [rellenos](/slides/es/python-net/shape-formatting/#gradient-fill) o de los contornos. Con los efectos de PowerPoint, puede crear reflejos convincentes en una forma, difundir el brillo de una forma, etc.

<img src="shape-effect.png" alt="efecto-de-forma" style="zoom:50%;" />

* PowerPoint ofrece seis efectos que pueden aplicarse a las formas. Puede aplicar uno o más efectos a una forma.  
* Algunas combinaciones de efectos lucen mejor que otras. Por esta razón, PowerPoint incluye opciones bajo **Preajuste**. Las opciones de Preajuste son esencialmente combinaciones probadas y de buen aspecto de dos o más efectos. De este modo, al seleccionar un preajuste, no tendrá que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides proporciona propiedades y métodos en la clase [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) que le permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar efecto de sombra**

Este código Python muestra cómo aplicar el efecto de sombra externa (`outer_shadow_effect`) a un rectángulo:

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

## **Aplicar efecto de reflexión**

Este código Python muestra cómo aplicar el efecto de reflexión a una forma:

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

## **Aplicar efecto de brillo**

Este código Python muestra cómo aplicar el efecto de brillo a una forma:

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

## **Aplicar efecto de bordes suaves**

Este código Python muestra cómo aplicar bordes suaves a una forma:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Puedo aplicar varios efectos a la misma forma?**

Sí, puede combinar diferentes efectos, como sombra, reflexión y brillo, en una sola forma para crear una apariencia más dinámica.

**¿A qué tipos de formas puedo aplicar efectos?**

Puede aplicar efectos a diversas formas, incluidas autoshapes, gráficos, tablas, imágenes, objetos SmartArt, objetos OLE y más.

**¿Puedo aplicar efectos a formas agrupadas?**

Sí, puede aplicar efectos a formas agrupadas. El efecto se aplicará a todo el grupo.