---
title: Propiedades Efectivas de la Forma
type: docs
weight: 50
url: /python-net/shape-effective-properties/
keywords: "Propiedades de forma, propiedades de cámara, equipo de luz, forma de bisel, marco de texto, estilo de texto, valor de altura de fuente, formato de relleno para tabla, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Obtenga propiedades efectivas de forma en presentaciones de PowerPoint en Python"
---

En este tema, discutiremos las propiedades **efectivas** y **locales**. Cuando establecemos valores directamente en estos niveles

1. En las propiedades de porción en la diapositiva de la porción.
1. En el estilo de texto de forma prototipo en la diapositiva de diseño o maestro (si el marco de texto de la porción tiene uno).
1. En la configuración global de texto de la presentación.

entonces esos valores se llaman valores **locales**. En cualquier nivel, los valores **locales** pueden ser definidos u omitidos. Pero al final, cuando llega el momento en que la aplicación necesita saber cómo debe verse la porción, utiliza los valores **efectivos**. Puedes obtener valores efectivos utilizando el método **getEffective()** del formato local.

El siguiente ejemplo muestra cómo obtener valores efectivos.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    localTextFrameFormat = shape.text_frame.text_frame_format
    effectiveTextFrameFormat = localTextFrameFormat.get_effective()

    localPortionFormat = shape.text_frame.paragraphs[0].portions[0].portion_format
    effectivePortionFormat = localPortionFormat.get_effective()
```


## **Obtener Propiedades Efectivas de la Cámara**
Aspose.Slides para Python a través de .NET permite a los desarrolladores obtener propiedades efectivas de la cámara. Para este propósito, se ha añadido la clase **CameraEffectiveData** en Aspose.Slides. La clase CameraEffectiveData representa un objeto inmutable que contiene propiedades efectivas de la cámara. Una instancia de la clase **CameraEffectiveData** se usa como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas para la cámara.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

    print("= Propiedades efectivas de la cámara =")
    print("Tipo: " + str(threeDEffectiveData.camera.camera_type))
    print("Campo de visión: " + str(threeDEffectiveData.camera.field_of_view_angle))
    print("Zoom: " + str(threeDEffectiveData.camera.zoom))
```


## **Obtener Propiedades Efectivas del Equipo de Luz**
Aspose.Slides para Python a través de .NET permite a los desarrolladores obtener propiedades efectivas del equipo de luz. Para este propósito, se ha añadido la clase **LightRigEffectiveData** en Aspose.Slides. La clase LightRigEffectiveData representa un objeto inmutable que contiene propiedades efectivas del equipo de luz. Una instancia de la clase **LightRigEffectiveData** se usa como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas para el equipo de luz.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

    print("= Propiedades efectivas del equipo de luz =")
    print("Tipo: " + str(threeDEffectiveData.light_rig.light_type))
    print("Dirección: " + str(threeDEffectiveData.light_rig.direction))
```


## **Obtener Propiedades Efectivas de la Forma de Bisel**
Aspose.Slides para Python a través de .NET permite a los desarrolladores obtener propiedades efectivas de la forma de bisel. Para este propósito, se ha añadido la clase **ShapeBevelEffectiveData** en Aspose.Slides. La clase ShapeBevelEffectiveData representa un objeto inmutable que contiene propiedades de relieve de cara de la forma efectivas. Una instancia de la clase **ShapeBevelEffectiveData** se usa como parte de la clase **ThreeDFormatEffectiveData**, que es un par de valores efectivos para la clase ThreeDFormat.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas para la forma de bisel.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

    print("= Propiedades efectivas del relieve de la cara superior de la forma =")
    print("Tipo: " + str(threeDEffectiveData.bevel_top.bevel_type))
    print("Ancho: " + str(threeDEffectiveData.bevel_top.width))
    print("Altura: " + str(threeDEffectiveData.bevel_top.height))
```


## **Obtener Propiedades Efectivas del Marco de Texto**
Usando Aspose.Slides para Python a través de .NET, puedes obtener propiedades efectivas del marco de texto. Para este propósito, se ha añadido la clase **TextFrameFormatEffectiveData** en Aspose.Slides que contiene propiedades efectivas de formato del marco de texto.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas de formato del marco de texto.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    textFrameFormat = shape.text_frame.text_frame_format
    effectiveTextFrameFormat = textFrameFormat.get_effective()

    print("Tipo de anclaje: " + str(effectiveTextFrameFormat.anchoring_type))
    print("Tipo de ajuste automático: " + str(effectiveTextFrameFormat.autofit_type))
    print("Tipo de texto vertical: " + str(effectiveTextFrameFormat.text_vertical_type))
    print(" márgenes")
    print("   Izquierda: " + str(effectiveTextFrameFormat.margin_left))
    print("   Superior: " + str(effectiveTextFrameFormat.margin_top))
    print("   Derecha: " + str(effectiveTextFrameFormat.margin_right))
    print("   Inferior: " + str(effectiveTextFrameFormat.margin_bottom))
```


## **Obtener Propiedades Efectivas del Estilo de Texto**
Usando Aspose.Slides para Python a través de .NET, puedes obtener propiedades efectivas del estilo de texto. Para este propósito, se ha añadido la clase **TextStyleEffectiveData** en Aspose.Slides que contiene propiedades efectivas del estilo de texto.

El siguiente ejemplo de código muestra cómo obtener propiedades efectivas del estilo de texto.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    effectiveTextStyle = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effectiveTextStyle.get_level(i)
        print("= Formateo efectivo del párrafo para el nivel del estilo #" + str(i) + " =")

        print("Profundidad: " + str(effectiveStyleLevel.depth))
        print("Sangría: " + str(effectiveStyleLevel.indent))
        print("Alineación: " + str(effectiveStyleLevel.alignment))
        print("Alineación de fuente: " + str(effectiveStyleLevel.font_alignment))

```


## **Obtener Valor Efectivo de Altura de Fuente**
Usando Aspose.Slides para Python a través de .NET, puedes obtener propiedades efectivas de la altura de la fuente. Aquí está el código que demuestra el cambio del valor efectivo de altura de fuente de la porción después de establecer valores de altura de fuente locales en diferentes niveles de estructura de la presentación.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    newShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    newShape.add_text_frame("")
    newShape.text_frame.paragraphs[0].portions.clear()

    portion0 = slides.Portion("Texto de ejemplo con primera porción")
    portion1 = slides.Portion(" y segunda porción.")

    newShape.text_frame.paragraphs[0].portions.add(portion0)
    newShape.text_frame.paragraphs[0].portions.add(portion1)

    print("Altura de fuente efectiva justo después de la creación:")
    print("Porción #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Porción #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Altura de fuente efectiva después de establecer la altura de fuente predeterminada de toda la presentación:")
    print("Porción #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Porción #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 40

    print("Altura de fuente efectiva después de establecer la altura de fuente predeterminada del párrafo:")
    print("Porción #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Porción #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 55

    print("Altura de fuente efectiva después de establecer la altura de fuente de la porción #0:")
    print("Porción #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Porción #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[1].portion_format.font_height = 18

    print("Altura de fuente efectiva después de establecer la altura de fuente de la porción #1:")
    print("Porción #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Porción #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```


## **Obtener Formato de Relleno Efectivo para tabla**
Usando Aspose.Slides para Python a través de .NET, puedes obtener el formato de relleno efectivo para diferentes partes lógicas de la tabla. Para este propósito, se ha añadido la interfaz **IFillFormatEffectiveData** en Aspose.Slides que contiene propiedades de formato de relleno efectivo. Ten en cuenta que el formato de celda siempre tiene una prioridad más alta que el formato de fila, una fila tiene más prioridad que una columna y una columna más que toda la tabla.

Así que, al final, las propiedades **CellFormatEffectiveData** siempre se utilizan para dibujar la tabla. El siguiente ejemplo de código muestra cómo obtener el formato de relleno efectivo para diferentes partes lógicas de la tabla.

```py
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    tbl = pres.slides[0].shapes[0]
    tableFormatEffective = tbl.table_format.get_effective()
    rowFormatEffective = tbl.rows[0].row_format.get_effective()
    columnFormatEffective = tbl.columns[0].column_format.get_effective()
    cellFormatEffective = tbl[0, 0].cell_format.get_effective()

    tableFillFormatEffective = tableFormatEffective.fill_format
    rowFillFormatEffective = rowFormatEffective.fill_format
    columnFillFormatEffective = columnFormatEffective.fill_format
    cellFillFormatEffective = cellFormatEffective.fill_format
```