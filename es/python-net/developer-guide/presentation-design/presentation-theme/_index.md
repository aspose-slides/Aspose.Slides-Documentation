---
title: Administrar temas de presentaciones PowerPoint en Python
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/python-net/presentation-theme/
keywords:
- Tema PowerPoint
- Tema de presentación
- Tema de diapositiva
- Establecer tema
- Cambiar tema
- Gestionar tema
- Color del tema
- Paleta adicional
- Fuente del tema
- Estilo del tema
- Efecto del tema
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Dominar los temas de presentación en Aspose.Slides para Python a través de .NET para crear, personalizar y convertir archivos PowerPoint con una marca coherente."
---

## **Visión general**

Un tema de presentación define las propiedades de sus elementos de diseño. Cuando seleccionas un tema, estás eligiendo un conjunto coordinado de elementos visuales y sus propiedades.

En PowerPoint, un tema incluye colores, [fuentes](/slides/es/python-net/powerpoint-fonts/), [estilos de fondo](/slides/es/python-net/presentation-background/), y efectos.

![theme-constituents](theme-constituents.png)

## **Cambiar el color del tema**

Un tema de PowerPoint utiliza un conjunto específico de colores para diferentes elementos en una diapositiva. Si no te gustan los valores predeterminados, puedes cambiarlos aplicando nuevos colores de tema. Para permitirte seleccionar un nuevo color de tema, Aspose.Slides proporciona valores en la enumeración [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/).

Este código Python muestra cómo cambiar el color de acento de un tema:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```


Puedes determinar el valor efectivo del color resultante de la siguiente manera:
```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# La salida del ejemplo:
#
# ff8064a2 (Color [A=255, R=128, G=100, B=162])
```


Para demostrar aún más el cambio de color, creamos otro elemento, le asignamos el color de acento del paso inicial y luego actualizamos el color del tema.
```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```


El nuevo color se aplica automáticamente a ambos elementos.

### **Establecer un color de tema desde la paleta adicional**

Cuando aplicas transformaciones de luminancia al color principal del tema (1), se generan colores de la paleta adicional (2). Luego puedes establecer y recuperar esos colores de tema.

![additional-palette-colors](additional-palette-colors.png)

**1** — Colores principales del tema

**2** — Colores de la paleta adicional

Este código Python demuestra cómo se derivan los colores de la paleta adicional del color principal del tema y luego se utilizan en formas:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Acento 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Acento 4, más claro 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Acento 4, más claro 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Acento 4, más claro 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Acento 4, más oscuro 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Acento 4, más oscuro 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```


## **Cambiar la fuente del tema**

Para permitirte seleccionar fuentes para temas y otros propósitos, Aspose.Slides usa estos identificadores especiales (similares a los de PowerPoint):

- **+mn-lt** — Fuente del cuerpo Latin (Minor Latin Font)
- **+mj-lt** — Fuente del encabezado Latin (Major Latin Font)
- **+mn-ea** — Fuente del cuerpo East Asian (Minor East Asian Font)
- **+mj-ea** — Fuente del encabezado East Asian (Major East Asian Font)

Este código Python muestra cómo asignar la fuente Latin a un elemento del tema:
```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```


Este ejemplo Python muestra cómo cambiar la fuente del tema de la presentación:
```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```


Todos los cuadros de texto se actualizarán a la nueva fuente.

{{% alert color="primary" title="TIP" %}}

Para más información, consulta [Master PowerPoint Fonts with Python](/slides/es/python-net/powerpoint-fonts/).

{{% /alert %}}

## **Cambiar el estilo de fondo del tema**

De forma predeterminada, PowerPoint proporciona 12 fondos predefinidos, pero una presentación típica solo almacena 3 de ellos.

![todo:image_alt_text](presentation-design_8.png)

Por ejemplo, después de guardar una presentación en PowerPoint, puedes ejecutar el siguiente código Python para determinar cuántos fondos predefinidos contiene:
```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```


{{% alert color="warning" %}}

Usando la propiedad `background_fill_styles` de la clase [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/), puedes agregar o acceder a los estilos de fondo en un tema de PowerPoint.

{{% /alert %}}

Este ejemplo Python muestra cómo establecer el fondo de la presentación:
```python
presentation.masters[0].background.style_index = 2  # 0 indica sin relleno; la indexación comienza en 1.
```


{{% alert color="primary" title="TIP" %}}

Para más información, consulta [Manage Presentation Backgrounds in Python](/slides/es/python-net/presentation-background/).

{{% /alert %}}

## **Cambiar los efectos del tema**

Un tema de PowerPoint normalmente incluye tres valores en cada matriz de estilo. Estas matrices se combinan en tres niveles de efecto: sutil, moderado e intenso. Por ejemplo, aquí está el resultado cuando esos efectos se aplican a una forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando las tres propiedades —`FillStyles`, `LineStyles` y `EffectStyles`— de la clase [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/), puedes modificar los elementos del tema (incluso con mayor flexibilidad que en PowerPoint).

Este código Python muestra cómo cambiar un efecto del tema alterando partes de esos elementos:
```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Los cambios resultantes incluyen actualizaciones del color de relleno, tipo de relleno, efecto de sombra y otras propiedades:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el maestro?**

Sí. Aspose.Slides admite anulación de tema a nivel de diapositiva, por lo que puedes aplicar un tema local solo a esa diapositiva mientras mantienes intacto el tema maestro (a través del [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/)).

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

[Clonar diapositivas](/slides/es/python-net/clone-slides/) junto con su maestro en la presentación de destino. Esto conserva el maestro original, los diseños y el tema asociado, de modo que la apariencia permanezca consistente.

**¿Cómo puedo ver los valores "efectivos" después de toda la herencia y anulación?**

Utiliza las vistas ["effective"](/slides/es/python-net/shape-effective-properties/) de la API para tema/color/fuente/efecto. Estas devuelven las propiedades resueltas y finales después de aplicar el maestro más cualquier anulación local.