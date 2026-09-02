---
title: Gestionar marcadores de posición de presentación en Python
linktitle: Gestionar marcadores
type: docs
weight: 10
url: /es/python-net/manage-placeholder/
keywords:
- marcador de posición
- marcador de posición de texto
- marcador de posición de imagen
- marcador de posición de gráfico
- marcador de posición de contenido
- texto de sugerencia
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo inspeccionar y editar marcadores de posición de texto, imagen, gráfico y contenido, y comprender la herencia de marcadores de posición con Aspose.Slides para Python a través de .NET."
---
## **Visión general**

Un marcador de posición es una forma que reserva una posición para un tipo particular de contenido en una plantilla de presentación. Los ejemplos más comunes son marcadores de posición de título, cuerpo, imagen, gráfico y de contenido de uso general. A diferencia de una forma ordinaria, un marcador de posición puede heredar su posición, tamaño, formato y otras configuraciones de una diapositiva de diseño o de una diapositiva maestra.

Aspose.Slides expone la información de los marcadores de posición a través de la propiedad [Shape.placeholder](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/placeholder/). La propiedad devuelve un objeto [Placeholder](https://reference.aspose.com/slides/es/python-net/aspose.slides/placeholder/) o `None` para una forma normal. Utilice [Placeholder.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/placeholder/type/) para determinar qué se pretende que contenga el marcador de posición.

La clase de la forma sigue siendo importante después de conocer el tipo de marcador de posición:

- Un marcador de posición vacío de texto, imagen, gráfico o contenido suele representarse mediante un [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/).
- Un marcador de posición de imagen rellenado puede representarse mediante un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/).
- Un marcador de posición de gráfico rellenado puede representarse mediante un [Chart](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/).
- Un marcador de posición de contenido puede contener varios tipos de contenido. Compruebe tanto [Placeholder.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/placeholder/type/) como la clase de forma en tiempo de ejecución en lugar de asumir que todo marcador de posición es un [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Advertencia" %}}
[Placeholder.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/placeholder/type/) describe el papel de un marcador de posición; no garantiza la clase de forma en tiempo de ejecución. Siempre utilice una verificación de tipo antes de acceder a los miembros específicos de texto, imagen, gráfico, tabla o medios.
{{% /alert %}}

## **Entender la herencia de marcadores de posición**

Los marcadores de posición forman una jerarquía:

1. Una diapositiva maestra define estilos reutilizables y, en algunos casos, marcadores de posición a nivel de maestra.
2. Una diapositiva de diseño define la disposición utilizada por una o más diapositivas normales y puede heredar de la maestra.
3. Una diapositiva normal contiene los marcadores de posición para esa diapositiva y puede heredar de su diseño.

Llame a [Shape.get_base_placeholder](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/get_base_placeholder/) para subir un nivel en esta jerarquía. Un marcador de posición de diapositiva normalmente devuelve su marcador de posición de diseño; un marcador de posición de diseño puede devolver su marcador de posición maestro. El método devuelve `None` cuando la forma no tiene un marcador de posición base.

El siguiente ejemplo enumera los marcadores de posición en la primera diapositiva y muestra sus marcadores de posición base:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Editar un marcador de posición en una diapositiva normal crea o modifica una anulación local para esa diapositiva. Editar el diseño o la maestra relacionada puede afectar a todas las diapositivas que aún heredan esa configuración. Una forma ordinaria local no tiene marcador de posición base y no comienza a heredar simplemente porque ocupa las mismas coordenadas.

## **Cambiar texto en un marcador de posición**

Los marcadores de posición de título, título centrado, subtítulo, cuerpo y texto suelen admitir texto. Verifique si se trata de un [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) antes de usar su propiedad [text_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/text_frame/).

Este ejemplo actualiza el primer marcador de posición de título en la primera diapositiva y guarda el resultado:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Este patrón evita tratar los marcadores de posición de imagen, gráfico, tabla o medios como objetos [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/). También identifica el marcador de posición por su finalidad en lugar de depender de un índice de forma frágil.

## **Establecer texto de sugerencia en un diseño**

El texto de sugerencia es la instrucción en tiempo de diseño que se muestra en un marcador de posición vacío, como *Haga clic para agregar título*. Establezca un texto de sugerencia personalizado en el marcador de posición del diseño en lugar de intentar acceder a él a través de la colección de formas de una diapositiva normal. Acceda al diseño mediante [Slide.layout_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/layout_slide/) y recorra [LayoutSlide.shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/shapes/).

El siguiente ejemplo cambia las sugerencias de título y subtítulo en el diseño usado por la primera diapositiva:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

El texto de sugerencia no es contenido normal de la diapositiva. Está destinado a marcadores de posición vacíos en aplicaciones de edición como PowerPoint. Una vez que un usuario o programa proporciona contenido real, la sugerencia deja de mostrarse. Cambiar una sugerencia tampoco sustituye el texto existente en las diapositivas que usan el diseño.

## **Actualizar un marcador de posición de imagen**

Hay dos casos que abordar:

- Si el marcador de posición de imagen ya está rellenado y se representa mediante un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/), reemplace la imagen mediante [PictureFillFormat.picture](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/picture/) y [Picture.image](https://reference.aspose.com/slides/es/python-net/aspose.slides/picture/image/).
- Si sigue siendo un marcador de posición vacío, añada un marco de imagen en las coordenadas del marcador de posición con [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_picture_frame/) y elimine el marcador de posición vacío.

El siguiente ejemplo admite ambos casos y guarda la presentación:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

El reemplazo creado para un marcador de posición vacío es un marco de imagen local, no un nuevo marcador de posición, porque [Shape.placeholder](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/placeholder/) es de solo lectura. Conserva la posición reservada pero ya no hereda el comportamiento específico del marcador de posición. Si es esencial mantener la relación del marcador de posición, prepare y rellene el marcador de posición en PowerPoint primero, y luego actualice el [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) resultante con Aspose.Slides.

Para transparencia de imagen, recorte y otros efectos específicos de imágenes, consulte [Manage Picture Frames](/slides/es/python-net/picture-frame/). esas operaciones pertenecen al marco de imagen o al relleno de imagen, no a los metadatos del marcador de posición.

## **Trabajar con marcadores de posición de gráfico y contenido**

Un marcador de posición de gráfico rellenado puede representarse mediante un [Chart](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/). Este ejemplo encuentra dicho gráfico tanto por tipo de marcador de posición como por clase en tiempo de ejecución, cambia su título y guarda el archivo:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Un marcador de posición de contenido general suele tener [PlaceholderType.OBJECT](https://reference.aspose.com/slides/es/python-net/aspose.slides/placeholdertype/). En PowerPoint actúa como un lanzador para varios tipos de contenido, incluidos gráficos, tablas, diagramas, imágenes y medios. Después de que se haya rellenado, inspeccione la clase de forma real para saber qué contiene. Los diseños especializados también pueden exponer [PlaceholderType.CHART](https://reference.aspose.com/slides/es/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/es/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/es/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/es/python-net/aspose.slides/placeholdertype/), o [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/es/python-net/aspose.slides/placeholdertype/).

Aspose.Slides no convierte un marcador de posición vacío de [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) en un [Chart](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/) simplemente cambiando [Placeholder.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/placeholder/type/); el tipo es de solo lectura. Para rellenar programáticamente un área de gráfico o contenido vacía, añada el objeto necesario en las coordenadas del marcador de posición y luego elimine el marcador de posición vacío. El siguiente ejemplo hace eso para un gráfico:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

El gráfico añadido es un gráfico local ordinario. Ocupa el área del marcador de posición pero no hereda del marcador de posición de diseño. Utilice los artículos dedicados de [chart management articles](/slides/es/python-net/powerpoint-charts/) cuando necesite reemplazar sus categorías, series o datos del libro de trabajo.

## **Ejemplo completo: actualizar texto o contenido de imagen**

El siguiente ejemplo completo abre una plantilla, busca en la primera diapositiva un marcador de posición de título o de imagen, comprueba los tipos de marcador de posición y de forma, actualiza el contenido correspondiente y guarda el resultado. El ejemplo evita deliberadamente asumir un índice de forma o tratar todos los marcadores de posición como la misma clase de forma.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Qué es un marcador de posición base?**

Un marcador de posición base es la forma correspondiente en el diseño o la maestra de la que hereda otro marcador de posición. Utilice [Shape.get_base_placeholder](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/get_base_placeholder/) para recuperarlo. Una forma local ordinaria devuelve `None` porque no forma parte de la jerarquía de marcadores de posición.

**¿Puedo cambiar todos los títulos de diapositiva editando un marcador de posición de diseño?**

Puede cambiar el formato heredado o el texto de sugerencia mediante un diseño, pero el contenido del título existente se almacena en las diapositivas normales. Para sustituir el texto real del título en toda la presentación, recorra las diapositivas y actualice cada marcador de posición de título.

**¿Cómo gestiono los marcadores de posición de fecha, número de diapositiva, encabezado y pie de página?**

Utilice los administradores de encabezado y pie de página en la diapositiva, diseño, maestra, notas o alcance de folleto correspondiente. Consulte [Manage Presentation Header and Footer](/slides/es/python-net/presentation-header-and-footer/) para ejemplos completos.