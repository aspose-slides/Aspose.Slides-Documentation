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
- efecto de resplandor
- efecto de bordes suaves
- formato de efecto
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Transforma tus archivos PPT, PPTX y ODP con efectos de forma avanzados usando Aspose.Slides para Python—crea diapositivas impactantes y profesionales en segundos."
---
## **Introducción**

Mientras que los efectos en PowerPoint pueden usarse para que una forma destaque, difieren de los [rellenos](/slides/es/python-net/shape-formatting/#gradient-fill) o contornos. Con los efectos de PowerPoint, puedes crear reflejos convincentes en una forma, difuminar el resplandor de una forma, etc.

![Efecto de forma](shape-effect.png)

PowerPoint ofrece seis efectos que pueden aplicarse a las formas. Puedes aplicar uno o varios efectos a una forma.

Algunas combinaciones de efectos lucen mejor que otras. Por esta razón, PowerPoint tiene opciones bajo **Preset**. Las opciones Preset son esencialmente una combinación conocida de dos o más efectos con buen aspecto. De este modo, al seleccionar un preset, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una combinación adecuada.

Aspose.Slides ofrece propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) que te permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar un efecto de sombra**

Aspose.Slides for Python via .NET admite sombras externas e internas para las formas. Puedes personalizar su color, dirección, distancia y radio de desenfoque para que coincidan con el diseño de tu presentación.

### **Aplicar una sombra externa**

Utiliza una sombra externa para que una tarjeta o panel destaque sobre el fondo de la diapositiva. La sombra se extiende más allá de los bordes de la forma, creando la impresión de que la forma está elevada sobre la diapositiva. Ajusta su color, dirección, distancia y radio de desenfoque para que coincidan con la iluminación y el estilo de tu plantilla.

Este código Python muestra cómo aplicar el [efecto de sombra externa](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) a un rectángulo:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efecto de sombra](shadow_effect.png)

### **Aplicar una sombra interna**

Al reproducir el estilo visual de una plantilla, utiliza una sombra interna para dar a una tarjeta o panel una apariencia hundida. Una sombra externa se extiende fuera de la forma y la hace parecer elevada, mientras que una sombra interna sombreará el interior de sus bordes.

Llama a [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), luego configura [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Los valores mayores de radio de desenfoque producen bordes más suaves.

Este ejemplo Python crea una tarjeta azul claro con una sombra interna gris oscuro y la guarda como archivo PPTX:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = draw.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Rectángulo azul claro con una sombra interna](inner_shadow_effect.png)

Para eliminar la sombra interna, llama a [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) en el formato de efectos de la forma.

## **Aplicar un efecto de reflexión**

Para aplicar un efecto de reflexión en Aspose.Slides for Python via .NET, puedes añadir una reflexión tipo espejo a las formas, ajustando parámetros como distancia, transparencia y tamaño. Este efecto mejora la estética de tus presentaciones al dar a las formas un aspecto más pulido y sofisticado. Es fácil de implementar con código sencillo, lo que permite una aplicación rápida en varios elementos para mantener un diseño coherente.

Este código Python muestra cómo aplicar el [efecto de reflexión](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) a una forma:

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

![Efecto de reflexión](reflection_effect.png)

## **Aplicar un efecto de resplandor**

Para aplicar un efecto de resplandor a una forma en Aspose.Slides for Python via .NET, puedes añadir una aura suave y luminosa alrededor de las formas, ajustando propiedades como color y tamaño. Este efecto ayuda a que las formas destaquen y añade un elemento visual atractivo y llamativo a tu presentación. Es fácil de implementar con poco código, realzando el aspecto general de tus diapositivas.

Este código Python muestra cómo aplicar el [efecto de resplandor](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) a una forma:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efecto de resplandor](glow_effect.png)

## **Aplicar un efecto de bordes suaves**

Para aplicar un efecto de bordes suaves en Aspose.Slides for Python via .NET, puedes crear una transición suave y difuminada alrededor de los bordes de una forma. Este efecto añade una apariencia más sutil y refinada, perfecta para diseños que requieren un aspecto delicado y más suave. Puedes ajustar fácilmente parámetros como el radio para conseguir el efecto deseado en diversas formas de tu presentación.

Este código Python muestra cómo aplicar los [bordes suaves](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) a una forma:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efecto de bordes suaves](soft_edges_effect.png)

## **FAQ**

**¿Puedo aplicar varios efectos a la misma forma?**

Sí, puedes combinar diferentes efectos, como sombra, reflexión y resplandor, en una sola forma para crear una apariencia más dinámica.

**¿A qué formas puedo aplicar efectos?**

Puedes aplicar efectos a varias formas, incluidas autoshapes, gráficos, tablas, imágenes, objetos SmartArt, objetos OLE y más.

**¿Puedo aplicar efectos a formas agrupadas?**

Sí, puedes aplicar efectos a formas agrupadas. El efecto se aplicará a todo el grupo.