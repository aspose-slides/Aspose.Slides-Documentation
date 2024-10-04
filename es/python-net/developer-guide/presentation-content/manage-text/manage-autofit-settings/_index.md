---
title: Administrar la Configuración de Autofit
type: docs
weight: 30
url: /es/python-net/manage-autofit-settings/
keywords: "Caja de texto, Autofit, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Configurar la configuración de autofit para la caja de texto en PowerPoint en Python"
---

Por defecto, cuando agregas una caja de texto, Microsoft PowerPoint utiliza la configuración de **Cambiar el tamaño de la forma para ajustar el texto** para la caja de texto; redimensiona automáticamente la caja de texto para asegurarse de que su texto siempre se ajuste a ella.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Cuando el texto en la caja de texto se vuelve más largo o grande, PowerPoint automáticamente agranda la caja de texto—incrementa su altura—para permitir que contenga más texto.
* Cuando el texto en la caja de texto se vuelve más corto o pequeño, PowerPoint reduce automáticamente la caja de texto—disminuye su altura—para liberar espacio redundante.

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de autofit para una caja de texto:

* **No ajustar automáticamente**
* **Reducir texto en desbordamiento**
* **Cambiar el tamaño de la forma para ajustar el texto**
* **Ajustar texto en la forma.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides para Python a través de .NET proporciona opciones similares—algunas propiedades bajo la clase [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)—que te permiten controlar el comportamiento de autofit para las cajas de texto en presentaciones.

## **Cambiar el Tamaño de la Forma para Ajustar el Texto**

Si deseas que el texto en una caja se ajuste siempre dentro de esa caja después de que se realicen cambios en el texto, debes utilizar la opción **Cambiar el tamaño de la forma para ajustar el texto**. Para especificar esta configuración, establece la propiedad [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (de la clase [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) en `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Este código Python te muestra cómo especificar que un texto debe ajustarse siempre dentro de su caja en una presentación de PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.SHAPE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

Si el texto se vuelve más largo o grande, la caja de texto se redimensionará automáticamente (aumento en altura) para asegurar que todo el texto se ajuste a ella. Si el texto se vuelve más corto, ocurre lo contrario.

## **No Ajustar Automáticamente**

Si deseas que una caja de texto o forma mantenga sus dimensiones sin importar los cambios realizados en el texto que contiene, debes utilizar la opción **No ajustar automáticamente**. Para especificar esta configuración, establece la propiedad [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (de la clase [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) en `NONE`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Este código Python te muestra cómo especificar que una caja de texto debe mantener siempre sus dimensiones en una presentación de PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

Cuando el texto se vuelve demasiado largo para su caja, se desborda.

## **Reducir Texto en Desbordamiento**

Si un texto se vuelve demasiado largo para su caja, a través de la opción **Reducir texto en desbordamiento**, puedes especificar que el tamaño y el espaciado del texto deben reducirse para que quepa en su caja. Para especificar esta configuración, establece la propiedad [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (de la clase [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) en `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código Python te muestra cómo especificar que un texto debe reducirse en desbordamiento en una presentación de PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NORMAL

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}

Cuando se utiliza la opción **Reducir texto en desbordamiento**, la configuración se aplica únicamente cuando el texto se vuelve demasiado largo para su caja.

{{% /alert %}}

## **Ajustar Texto**

Si deseas que el texto en una forma se ajuste dentro de esa forma cuando el texto exceda el borde de la forma (solo ancho), debes usar el parámetro **Ajustar texto en la forma**. Para especificar esta configuración, debes establecer la propiedad [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) en `1`.

Este código Python te muestra cómo usar la configuración Ajustar Texto en una presentación de PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE
    textFrameFormat.wrap_text = 1

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Nota" color="warning" %}} 

Si estableces la propiedad `wrap_text` en `0` para una forma, cuando el texto dentro de la forma se vuelve más largo que el ancho de la forma, el texto se extiende más allá de los bordes de la forma en una sola línea.

{{% /alert %}}