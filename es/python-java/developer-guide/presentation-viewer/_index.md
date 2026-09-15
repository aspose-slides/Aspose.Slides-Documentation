---
title: Crear un visor de presentaciones en Python a través de Java
linktitle: Visor de presentaciones
type: docs
weight: 50
url: /es/python-java/presentation-viewer/
keywords:
- ver presentación
- visor de presentaciones
- crear visor de presentaciones
- ver PPT
- ver PPTX
- ver ODP
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Crear un visor de presentaciones personalizado en Python a través de Java usando Aspose.Slides. Mostrar fácilmente archivos PowerPoint y OpenDocument sin Microsoft PowerPoint."
---
## **Introducción**

Aspose.Slides para Python a través de Java se utiliza para crear archivos de presentación con diapositivas. Estas diapositivas pueden verse abriendo las presentaciones en Microsoft PowerPoint, por ejemplo. Sin embargo, a veces los desarrolladores pueden necesitar ver las diapositivas como imágenes en su visor de imágenes preferido o crear su propio visor de presentaciones. En esos casos, Aspose.Slides le permite exportar una diapositiva individual como una imagen. Este artículo describe cómo hacerlo.

## **Generar una imagen SVG a partir de una diapositiva**

Para generar una imagen SVG a partir de una diapositiva de presentación con Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva por su índice.
1. Abra un flujo de bytes.
1. Guarde la diapositiva como una imagen SVG en el flujo y escríbala en un archivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Generar un SVG con un ID de forma personalizado**

Aspose.Slides puede usarse para generar un [SVG](https://docs.fileformat.com/page-description-language/svg/) a partir de una diapositiva con un ID de forma personalizado. Para ello, utilice el método [SvgShape.setId](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgshape/#setId) de [SvgShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` puede usarse para establecer el ID de la forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Crear una imagen en miniatura de una diapositiva**

Aspose.Slides le ayuda a generar imágenes en miniatura de diapositivas. Para generar una miniatura de una diapositiva usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva por su índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con una escala definida.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Crear una miniatura de diapositiva con dimensiones definidas por el usuario**

Para crear una imagen en miniatura de diapositiva con dimensiones definidas por el usuario, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva por su índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con las dimensiones definidas.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Crear una miniatura de diapositiva con notas del presentador**

Para generar la miniatura de una diapositiva con notas del presentador usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase [RenderingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/renderingoptions/).
1. Utilice el método [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) para establecer la posición de las notas del presentador.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva por su índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con las opciones de renderizado.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Ejemplo en vivo**

Puede probar la aplicación gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/es/viewer/) para ver lo que puede implementar con la API de Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**¿Puedo incrustar un visor de presentaciones en una aplicación web?**

Sí. Puede usar Aspose.Slides en el lado del servidor para renderizar diapositivas como imágenes o HTML y mostrarlas en el navegador. Las funciones de navegación y zoom pueden implementarse con JavaScript para una experiencia interactiva.

**¿Cuál es la mejor manera de mostrar diapositivas dentro de un visor personalizado?**

El enfoque recomendado es renderizar cada diapositiva como una imagen (por ejemplo, PNG o SVG) o convertirla a HTML usando Aspose.Slides, y luego mostrar la salida dentro de un cuadro de imagen (para escritorio) o un contenedor HTML (para web).

**¿Cómo gestiono presentaciones grandes con muchas diapositivas?**

Para presentaciones extensas, considere la carga diferida o el renderizado bajo demanda de diapositivas. Esto implica generar el contenido de una diapositiva solo cuando el usuario navega a ella, reduciendo el uso de memoria y el tiempo de carga.