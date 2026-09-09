---
title: Administrar marcadores de posición de presentación en Python
linktitle: Administrar marcadores de posición
type: docs
weight: 10
url: /es/python-java/manage-placeholder/
keywords:
- marcador de posición
- marcador de posición de texto
- marcador de posición de imagen
- marcador de posición de gráfico
- marcador de posición de contenido
- texto de ayuda
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a inspeccionar y editar marcadores de posición de texto, imagen, gráfico y contenido, y comprenda la herencia de marcadores de posición con Aspose.Slides para Python mediante Java."
---
## **Visión general**

Un marcador de posición es una forma que reserva una posición para un tipo particular de contenido en una plantilla de presentación. Los ejemplos más comunes son marcadores de posición de título, cuerpo, imagen, gráfico y de contenido de propósito general. A diferencia de una forma ordinaria, un marcador de posición puede heredar su posición, tamaño, formato y otras configuraciones de una diapositiva de diseño o de la diapositiva maestra.

Aspose.Slides expone la información de los marcadores de posición a través del método [Shape.getPlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getPlaceholder). El método devuelve un objeto [Placeholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/placeholder/) o `None` para una forma normal. Utilice [Placeholder.getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/placeholder/#getType) para determinar qué se pretende que contenga el marcador de posición.

El tipo de forma sigue siendo importante después de conocer el tipo de marcador de posición:

- Un marcador de posición vacío de texto, imagen, gráfico o contenido suele representarse mediante un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/).
- Un marcador de posición de imagen rellenado puede representarse mediante un [PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/).
- Un marcador de posición de gráfico rellenado puede representarse mediante un [Chart](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/).
- Un marcador de posición de contenido puede contener varios tipos de contenido. Verifique tanto [Placeholder.getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/placeholder/#getType) como el tipo de forma en tiempo de ejecución en lugar de asumir que cada marcador de posición es un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Advertencia" %}}
[Placeholder.getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/placeholder/#getType) describe el rol de un marcador de posición; no garantiza el tipo de forma en tiempo de ejecución. Siempre realice una comprobación de tipo antes de acceder a los miembros específicos de texto, imagen, gráfico, tabla o multimedia.
{{% /alert %}}

## **Comprender la herencia de marcadores de posición**

Los marcadores de posición forman una jerarquía:

1. Una diapositiva maestra define estilos reutilizables y, en algunos casos, marcadores de posición a nivel de maestro.
2. Una diapositiva de diseño define la disposición utilizada por una o más diapositivas normales y puede heredar del maestro.
3. Una diapositiva normal contiene los marcadores de posición de esa diapositiva y puede heredar de su diseño.

Llame a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getBasePlaceholder) para subir un nivel en esta jerarquía. Un marcador de posición de diapositiva normalmente devuelve su marcador de posición de diseño; un marcador de posición de diseño puede devolver su marcador de posición maestro. El método devuelve `None` cuando la forma no tiene marcador de posición base.

El siguiente ejemplo enumera los marcadores de posición en la primera diapositiva y muestra sus marcadores de posición base:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Editar un marcador de posición en una diapositiva normal crea o modifica una sobreescritura local para esa diapositiva. Editar el diseño o el maestro relacionado puede afectar a todas las diapositivas que aún heredan esa configuración. Una forma ordinaria local no tiene marcador de posición base y no comienza a heredar solo porque ocupa las mismas coordenadas.

## **Cambiar texto en un marcador de posición**

Los marcadores de posición de título, título centrado, subtítulo, cuerpo y texto normalmente admiten texto. Verifique que sea un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) antes de usar su método [getTextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/#getTextFrame).

Este ejemplo actualiza el primer marcador de posición de título en la primera diapositiva y guarda el resultado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Este patrón evita tratar los marcadores de posición de imagen, gráfico, tabla o multimedia como [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/). También identifica el marcador de posición por su propósito en lugar de depender de un índice de forma frágil.

## **Establecer texto de ayuda en un diseño**

El texto de ayuda es la instrucción en tiempo de diseño que se muestra en un marcador de posición vacío, como *Haga clic para agregar título*. Establezca texto de ayuda personalizado en el marcador de posición del diseño en lugar de intentar acceder a él mediante la colección de formas de una diapositiva normal. Acceda al diseño mediante [Slide.getLayoutSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getLayoutSlide) e itere sobre la colección devuelta por [BaseSlide.getShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getShapes).

El siguiente ejemplo cambia los textos de ayuda de título y subtítulo en el diseño utilizado por la primera diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El texto de ayuda no es contenido normal de la diapositiva. Está destinado a marcadores de posición vacíos en aplicaciones de edición como PowerPoint. Una vez que un usuario o programa proporciona contenido real, el texto de ayuda ya no se muestra. Cambiar un texto de ayuda tampoco sustituye el texto existente en las diapositivas que usan el diseño.

## **Actualizar un marcador de posición de imagen**

Hay dos casos a manejar:

- Si el marcador de posición de imagen ya está rellenado y se representa mediante un [PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/), reemplace la imagen mediante [PictureFillFormat.getPicture](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#getPicture) y [Picture.setImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/picture/#setImage).
- Si sigue siendo un marcador de posición vacío, añada un marco de imagen en las coordenadas del marcador de posición con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addPictureFrame) y elimine el marcador de posición vacío.

El siguiente ejemplo admite ambos casos y guarda la presentación:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El reemplazo creado para un marcador de posición vacío es un marco de imagen local, no un nuevo marcador de posición, porque [Shape.getPlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getPlaceholder) no proporciona un setter. Conserva la posición reservada pero ya no hereda el comportamiento específico del marcador de posición. Si es esencial mantener la relación de marcador de posición, prepare y rellene el marcador de posición en PowerPoint primero, y luego actualice el [PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/) resultante con Aspose.Slides.

Para transparencia de imagen, recorte y otros efectos específicos de la imagen, consulte [Manage Picture Frames](/slides/es/python-java/picture-frame/). esas operaciones pertenecen al marco de imagen o al relleno de imagen, no a los metadatos del marcador de posición.

## **Trabajar con marcadores de posición de gráfico y contenido**

Un marcador de posición de gráfico rellenado puede representarse mediante un [Chart](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/). Este ejemplo busca dicho gráfico tanto por tipo de marcador de posición como por tipo de forma en tiempo de ejecución, cambia su título y guarda el archivo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Un marcador de posición de contenido general suele tener [PlaceholderType.Object](https://reference.aspose.com/slides/es/python-java/aspose.slides/placeholdertype/#Object). En PowerPoint actúa como lanzador de varios tipos de contenido, incluidos gráficos, tablas, diagramas, imágenes y medios. Después de rellenarse, inspeccione el tipo de forma real para saber qué contiene. Los diseños especializados también pueden exponer [PlaceholderType.Chart](https://reference.aspose.com/slides/es/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/es/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/es/python-java/aspose.slides/placeholdertype/#Media) o [PlaceholderType.Diagram](https://reference.aspose.com/slides/es/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides no convierte un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) vacío en un [Chart] simplemente cambiando [Placeholder.getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/placeholder/#getType); el tipo no puede modificarse mediante la API. Para rellenar programáticamente un gráfico o área de contenido vacío, añada el objeto necesario en las coordenadas del marcador de posición y luego elimine el marcador de posición vacío. El siguiente ejemplo hace eso para un gráfico:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El gráfico añadido es un gráfico local ordinario. Ocupa el área del marcador de posición pero no hereda del marcador de posición del diseño. Utilice los artículos dedicados a la gestión de gráficos [chart management articles](/slides/es/python-java/powerpoint-charts/) cuando necesite reemplazar sus categorías, series o datos del libro de trabajo.

## **Ejemplo completo: actualizar contenido de texto o imagen**

El siguiente ejemplo de extremo a extremo abre una plantilla, busca en la primera diapositiva un marcador de posición de título o de imagen, comprueba los tipos de marcador de posición y de forma, actualiza el contenido correspondiente y guarda la salida. El ejemplo evita deliberadamente suponer un índice de forma o tratar cada marcador de posición como del mismo tipo:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué es un marcador de posición base?**

Un marcador de posición base es la forma correspondiente en el diseño o maestro de la que otro marcador de posición hereda. Use [Shape.getBasePlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getBasePlaceholder) para obtenerlo. Una forma local ordinaria devuelve `None` porque no forma parte de la jerarquía de marcadores de posición.

**¿Puedo cambiar todos los títulos de diapositiva editando un marcador de posición de diseño?**

Puede cambiar el formato heredado o el texto de ayuda a través de un diseño, pero el contenido real del título está almacenado en las diapositivas normales. Para reemplazar el texto del título en toda la presentación, itere sobre las diapositivas y actualice cada marcador de posición de título.

**¿Cómo gestiono los marcadores de posición de fecha, número de diapositiva, encabezado y pie de página?**

Utilice los administradores de encabezado y pie de página en el ámbito apropiado: diapositiva, diseño, maestro, notas o folleto. Consulte [Manage Presentation Header and Footer](/slides/es/python-java/presentation-header-and-footer/) para ejemplos completos.