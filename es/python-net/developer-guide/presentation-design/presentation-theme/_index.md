---
title: Tema de Presentación
type: docs
weight: 10
url: /es/python-net/presentation-theme/
keywords: "Tema, tema de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Tema de presentación de PowerPoint en Python"
---

Un tema de presentación define las propiedades de los elementos de diseño. Al seleccionar un tema de presentación, en esencia estás eligiendo un conjunto específico de elementos visuales y sus propiedades.

En PowerPoint, un tema comprende colores, [fuentes](/slides/es/python-net/powerpoint-fonts/), [estilos de fondo](/slides/es/python-net/presentation-background/), y efectos.

![theme-constituents](theme-constituents.png)

## **Cambiar el Color del Tema**

Un tema de PowerPoint utiliza un conjunto específico de colores para diferentes elementos en una diapositiva. Si no te gustan los colores, puedes cambiarlos aplicando nuevos colores al tema. Para permitirte seleccionar un nuevo color de tema, Aspose.Slides proporciona valores bajo la enumeración [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/).

Este código Python te muestra cómo cambiar el color de acento para un tema:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Puedes determinar el valor efectivo del color resultante de esta manera:

```python
fillEffective = shape.fill_format.get_effective()
print("{0} ({1})".format(fillEffective.solid_fill_color.name, fillEffective.solid_fill_color)) # ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

Para demostrar aún más la operación de cambio de color, creamos otro elemento y le asignamos el color de acento (de la operación inicial). Luego cambiamos el color en el tema:

```python
otherShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
otherShape.fill_format.fill_type = slides.FillType.SOLID
otherShape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

pres.master_theme.color_scheme.accent4.color = draw.Color.red
```

El nuevo color se aplica automáticamente a ambos elementos.

### **Establecer el Color del Tema desde una Paleta Adicional**

Cuando aplicas transformaciones de luminancia al color principal del tema(1), se forman colores de la paleta adicional(2). Luego puedes establecer y obtener esos colores de tema.

![additional-palette-colors](additional-palette-colors.png)

**1**- Colores principales del tema

**2** - Colores de la paleta adicional.

Este código Python demuestra una operación donde se obtienen colores de la paleta adicional a partir del color principal del tema y luego se utilizan en las formas:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Acento 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Acento 4, Más Claro 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Acento 4, Más Claro 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Acento 4, Más Claro 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Acento 4, Más Oscuro 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Acento 4, Más Oscuro 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar la Fuente del Tema**

Para permitirte seleccionar fuentes para temas y otros propósitos, Aspose.Slides utiliza estos identificadores especiales (similares a los utilizados en PowerPoint):

* **+mn-lt** - Fuente del Cuerpo Latino (Fuente Menor Latina)
* **+mj-lt** - Fuente de Encabezado Latino (Fuente Mayor Latina)
* **+mn-ea** - Fuente del Cuerpo de Asia Oriental (Fuente Menor de Asia Oriental)
* **+mj-ea** - Fuente del Cuerpo de Asia Oriental (Fuente Mayor de Asia Oriental)

Este código Python te muestra cómo asignar la fuente latina a un elemento del tema:

```python
shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)

paragraph = slides.Paragraph()
portion = slides.Portion("Formato de texto del tema")
paragraph.portions.add(portion)
shape.text_frame.paragraphs.add(paragraph)
portion.portion_format.latin_font = slides.FontData("+mn-lt")
```

Este código Python te muestra cómo cambiar la fuente del tema de presentación:

```python
pres.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

La fuente en todos los cuadros de texto se actualizará.

{{% alert color="primary" title="CONSEJO" %}} 

Puede que desees ver [fuentes de PowerPoint](/slides/es/python-net/powerpoint-fonts/).

{{% /alert %}}

## **Cambiar el Estilo de Fondo del Tema**

Por defecto, la aplicación de PowerPoint proporciona 12 fondos predefinidos, pero solo 3 de esos 12 fondos se guardan en una presentación típica. 

![todo:image_alt_text](presentation-design_8.png)

Por ejemplo, después de guardar una presentación en la aplicación de PowerPoint, puedes ejecutar este código Python para averiguar el número de fondos predefinidos en la presentación:

```python
with slides.Presentation() as pres:
    numberOfBackgroundFills = len(pres.master_theme.format_scheme.background_fill_styles)
    print("El número de estilos de relleno de fondo para el tema es {0}".format(numberOfBackgroundFills))
```

{{% alert color="warning" %}} 

Usando la propiedad `BackgroundFillStyles` de la clase [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/), puedes agregar o acceder al estilo de fondo en un tema de PowerPoint. 

{{% /alert %}}

Este código Python te muestra cómo establecer el fondo para una presentación:

```python
pres.masters[0].background.style_index = 2
```

**Guía de índice**: 0 se utiliza para sin relleno. El índice comienza en 1.

{{% alert color="primary" title="CONSEJO" %}} 

Puede que desees ver [Fondo de PowerPoint](/slides/es/python-net/presentation-background/).

{{% /alert %}}

## **Cambiar el Efecto del Tema**

Un tema de PowerPoint generalmente contiene 3 valores para cada arreglo de estilos. Esos arreglos se combinan en estos 3 efectos: sutil, moderado e intenso. Por ejemplo, este es el resultado cuando se aplican los efectos a una forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propiedades (`FillStyles`, `LineStyles`, `EffectStyles`) de la clase [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) puedes cambiar los elementos en un tema (incluso más flexiblemente que las opciones en PowerPoint).

Este código Python te muestra cómo cambiar un efecto de tema alterando partes de los elementos:

```python
with slides.Presentation("combined_with_master.pptx") as pres:
    pres.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    pres.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    pres.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    pres.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", slides.export.SaveFormat.PPTX)
```

Los cambios resultantes en el color de relleno, tipo de relleno, efecto de sombra, etc:

![todo:image_alt_text](presentation-design_11.png)