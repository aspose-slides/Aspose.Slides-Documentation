---
title: Crear y aplicar efectos de WordArt en Python
linktitle: WordArt
type: docs
weight: 110
url: /es/python-net/wordart/
keywords:
- WordArt
- crear WordArt
- plantilla WordArt
- efecto WordArt
- efecto sombra
- efecto reflejo
- efecto resplandor
- transformación WordArt
- efecto 3D
- efecto sombra externa
- efecto sombra interna
- Python
- Aspose.Slides
description: "Cree y personalice efectos de WordArt en Aspose.Slides para Python a través de .NET. Esta guía paso a paso ayuda a los desarrolladores a mejorar presentaciones con texto profesional en Python."
---
## **Visión general**

Los efectos de WordArt le permiten dar estilo al texto con rellenos, contornos, sombras, reflejos, resplandor, transformaciones y formato 3D. Este artículo explica cómo crear y personalizar estos efectos en presentaciones de PowerPoint usando Aspose.Slides para Python a través de .NET, sin necesidad de tener instalado Microsoft Office.

## **Crear una plantilla de WordArt sencilla y aplicarla al texto**

Los siguientes ejemplos crean un estilo sencillo de WordArt configurando el texto, la fuente, el relleno de patrón y el contorno.

Cada ejemplo crea una nueva presentación y agrega un rectángulo a su primera diapositiva; no se requiere un archivo de entrada. El primer ejemplo establece el texto en "Aspose.Slides". La posición y las dimensiones de la forma se miden en puntos:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Establezca la fuente en Arial Black a 36 puntos para que el formato sea más visible:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

Aplique un patrón [SMALL_GRID](https://reference.aspose.com/slides/es/python-net/aspose.slides/patternstyle/) con un primer plano naranja oscuro y un fondo blanco, y luego añada un contorno de texto negro con un ancho de 1 punto:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

El texto resultante:

![La plantilla simple de WordArt](WordArt_template.png)

## **Aplicar otros efectos de WordArt**

Los siguientes ejemplos demuestran cómo aplicar sombras, reflejos, resplandor, transformaciones y efectos 3D al texto.

### **Aplicar efectos de sombra externa**

Una sombra externa añade profundidad colocando una sombra detrás del texto. Puede personalizar su color, dirección, distancia, radio de desenfoque, escala y sesgo.

Este ejemplo llama a [enable_outer_shadow_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) y establece una sombra negra con un radio de desenfoque de 4 puntos, una dirección de 230 grados y una distancia de 30 puntos. Los valores de escala de 100 conservan el tamaño de la sombra, mientras que el sesgo horizontal la inclina 20 grados. La transformación alfa define una opacidad del 32%:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

El texto resultante:

![El efecto de sombra externa](outer_shadow_effect.png)

{{% alert color="info" title="Nota" %}}
- Cuando se usan sombras externas y predefinidas juntas, solo se aplica la sombra externa.
- Si se usan sombras externas e internas simultáneamente, el efecto resultante depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013 el efecto se duplica, mientras que en PowerPoint 2007 solo se aplica la sombra externa.
{{% /alert %}}

### **Aplicar efectos de reflejo**

Un reflejo crea una copia espejo del texto. Ajuste su posición, escala, desenfoque y opacidad para controlar su apariencia.

Este ejemplo llama a [enable_reflection_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides/effectformat/enable_reflection_effect/) y voltea el reflejo verticalmente con una escala del -100 %. Utiliza un radio de desenfoque de 0,5 puntos y una distancia de 4,72 puntos. La opacidad disminuye del 60 % al 0,9 % entre las posiciones 0 % y 60 % a lo largo del reflejo:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

El texto resultante:

![El efecto de reflejo](reflection_effect.png)

### **Aplicar efectos de resplandor**

Un resplandor añade un contorno de color suave alrededor del texto. Ajuste su color, opacidad y radio para controlar el efecto.

Este ejemplo llama a [enable_glow_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides/effectformat/enable_glow_effect/) y aplica un resplandor rojo con un 54 % de opacidad y un radio de 7 puntos:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

El texto resultante:

![El efecto de resplandor](glow_effect.png)

### **Aplicar transformaciones de WordArt**

Las transformaciones de WordArt doblan, estiran o deforman un bloque de texto.

Establezca [transform](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/transform/) a [ARCH_UP_POUR](https://reference.aspose.com/slides/es/python-net/aspose.slides/textshapetype/) para curvar todo el marco de texto hacia arriba:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

El texto resultante:

![La transformación de WordArt](transform_effect.png)

{{% alert color="info" title="Nota" %}}
Aspose.Slides para Python a través de .NET proporciona un conjunto de [tipos de transformación](https://reference.aspose.com/slides/es/python-net/aspose.slides/textshapetype/) predefinidos.
{{% /alert %}}

### **Aplicar efectos 3D a formas y texto**

Puede aplicar efectos 3D a una forma o a su texto. Los biseles, la extrusión, la iluminación y la configuración de la cámara controlan la apariencia resultante.

El siguiente ejemplo utiliza [ThreeDFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/) para añadir biseles circulares, extrusión naranja y un contorno rojo oscuro al rectángulo. Las dimensiones del bisel, la altura de la extrusión, el ancho del contorno y la profundidad se miden en puntos. Un material plástico, iluminación equilibrada girada 40 grados alrededor del eje Z y una cámara en perspectiva definen su aspecto:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

La forma resultante:

![El efecto 3D de la forma](shape_3D_effect.png)

Este ejemplo aplica un formato 3D similar al texto mediante [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframeformat/three_d_format/). Biseles más pequeños modelan los bordes de las letras, mientras que la extrusión y la iluminación dan profundidad al texto:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

El texto resultante:

![El efecto 3D del texto](text_3D_effect.png)

{{% alert color="info" title="Nota" %}}
La aplicación de efectos 3D al texto o a sus formas —y la interacción entre estos efectos— está regida por reglas específicas. Considere una escena que incluya tanto el texto como la forma que lo contiene. Un efecto 3D incluye la representación 3D del objeto y la escena en la que se coloca.

- Si una escena está definida tanto para la forma como para el texto, la escena de la forma tiene prioridad y la escena del texto se ignora.
- Si la forma no tiene su propia escena pero sí una representación 3D, se utiliza la escena del texto.
- Si la forma no tiene ningún efecto 3D, se trata como plana y el efecto 3D se aplica solo al texto.

Estos comportamientos se relacionan con las propiedades [ThreeDFormat.light_rig](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/light_rig/) y [ThreeDFormat.camera](https://reference.aspose.com/slides/es/python-net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Para mantener el texto plano y legible mientras se conserva el formato 3D de su forma, consulte [Mantener el texto plano en una forma 3D](/slides/es/python-net/3d-presentation/) para comparar ambas configuraciones y ver un ejemplo completo en Python.

## **Preguntas frecuentes**

**¿Puedo usar los efectos de WordArt con diferentes fuentes o scripts (p. ej., árabe, chino)?**

Sí, Aspose.Slides para Python a través de .NET admite Unicode y funciona con todas las fuentes y scripts principales. Los efectos de WordArt como sombra, relleno y contorno pueden aplicarse independientemente del idioma, aunque la disponibilidad de fuentes y el renderizado pueden depender de las fuentes del sistema.

**¿Puedo aplicar efectos de WordArt a los elementos del patrón de diapositivas?**

Sí, puede aplicar efectos de WordArt a las formas de las diapositivas maestras, incluidos los marcadores de posición de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.

**¿Los efectos de WordArt afectan al tamaño del archivo de la presentación?**

Ligeramente. Los efectos de WordArt como sombras, resplandores y rellenos degradados pueden aumentar un poco el tamaño del archivo debido a los metadatos de formato añadidos, pero la diferencia suele ser insignificante.

**¿Puedo previsualizar el resultado de los efectos de WordArt sin guardar la presentación?**

Sí, puede renderizar diapositivas que contienen WordArt a imágenes (p. ej., PNG, JPEG) mediante [Slide.get_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/), o renderizar formas individuales usando [Shape.get_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/get_image/). Esto le permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.