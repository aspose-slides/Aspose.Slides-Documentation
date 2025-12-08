---
title: Mejora tus presentaciones con AutoFit en Python
linktitle: Configuraciones de Autofit
type: docs
weight: 30
url: /es/python-net/manage-autofit-settings/
keywords:
- cuadro de texto
- autofit
- no autofit
- ajustar texto
- reducir texto
- envolver texto
- redimensionar forma
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprende a gestionar la configuración AutoFit en Aspose.Slides para Python mediante .NET para optimizar la visualización del texto en tus presentaciones PowerPoint y OpenDocument y mejorar la legibilidad del contenido."
---

Por defecto, cuando agrega un cuadro de texto, Microsoft PowerPoint usa la configuración **Resize shape to fix text** para el cuadro de texto—redimensiona automáticamente el cuadro de texto para garantizar que su texto siempre quepa en él. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Cuando el texto en el cuadro de texto se vuelve más largo o más grande, PowerPoint amplía automáticamente el cuadro de texto—incrementa su altura—para permitir que contenga más texto. 
* Cuando el texto en el cuadro de texto se vuelve más corto o más pequeño, PowerPoint reduce automáticamente el cuadro de texto—disminuye su altura—para eliminar el espacio redundante. 

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de autofit para un cuadro de texto: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides para Python a través de .NET ofrece opciones similares—algunas propiedades de la clase [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)—que le permiten controlar el comportamiento de autofit para los cuadros de texto en presentaciones. 

## **Resize Shapes to Fit Text**

Si desea que el texto en un cuadro siempre quepa en ese cuadro después de modificar el texto, debe usar la opción **Resize shape to fix text**. Para especificar esta configuración, establezca la propiedad [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) de la clase [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) a `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumentará su altura) para garantizar que todo el texto quepa en él. Si el texto se vuelve más corto, ocurre lo contrario. 

## **Do Not Autofit**

Si desea que un cuadro de texto o una forma mantenga sus dimensiones sin importar los cambios en el texto que contiene, debe usar la opción **Do not Autofit**. Para especificar esta configuración, establezca la propiedad [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) de la clase [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) a `NONE`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Cuando el texto se vuelve demasiado largo para su cuadro, se desborda. 

## **Shrink Text on Overflow**

Si un texto se vuelve demasiado largo para su cuadro, mediante la opción **Shrink text on overflow** puede especificar que el tamaño y el espaciado del texto se reduzcan para que quepan en su cuadro. Para especificar esta configuración, establezca la propiedad [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) de la clase [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) a `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Info" color="info" %}}
Al usar la opción **Shrink text on overflow**, la configuración se aplica solo cuando el texto se vuelve demasiado largo para su cuadro. 
{{% /alert %}}

## **Wrap Text**

Si desea que el texto dentro de una forma se ajuste dentro de esa forma cuando el texto supera el borde (solo el ancho) de la forma, debe usar el parámetro **Wrap text in shape**. Para especificar esta configuración, debe establecer la propiedad [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) de la clase [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) a `NullableBool.TRUE`. 

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Note" color="warning" %}} 
Si establece la propiedad `wrap_text` a `NullableBool.FALSE` para una forma, cuando el texto dentro de la forma supera el ancho de la forma, el texto se extenderá más allá de los bordes de la forma en una sola línea. 
{{% /alert %}}

## **FAQ**

**¿Los márgenes internos del marco de texto afectan a AutoFit?**

Sí. El relleno (márgenes internos) reduce el área usable para el texto, por lo que AutoFit se activará antes—encogiendo la fuente o redimensionando la forma más pronto. Revise y ajuste los márgenes antes de afinar AutoFit.

**¿Cómo interactúa AutoFit con los saltos de línea manuales y suaves?**

Los saltos forzados permanecen, y AutoFit adapta el tamaño de fuente y el espaciado alrededor de ellos. Eliminar saltos innecesarios suele reducir la agresividad con la que AutoFit necesita encoger el texto.

**¿Cambiar la fuente del tema o activar la sustitución de fuentes afecta los resultados de AutoFit?**

Sí. Sustituir a una fuente con métricas de glifos diferentes cambia el ancho/alto del texto, lo que puede alterar el tamaño de fuente final y el ajuste de líneas. Tras cualquier cambio o sustitución de fuente, vuelva a revisar las diapositivas.