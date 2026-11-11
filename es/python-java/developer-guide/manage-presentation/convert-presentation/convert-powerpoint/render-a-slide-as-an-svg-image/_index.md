---
title: Renderizar diapositivas de presentación como imágenes SVG en Python mediante Java
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /es/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint a SVG
- presentación a SVG
- diapositiva a SVG
- PPT a SVG
- PPTX a SVG
- opciones de exportación SVG
- SVG interactivo
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Exporta diapositivas de PowerPoint como imágenes SVG en Python mediante Java y controla fuentes, texto, imágenes, IDs y eventos con Aspose.Slides."
---
## **Visión general**

SVG es un formato de imagen XML escalable que funciona bien para publicación web, visores de diapositivas, flujos de trabajo de accesibilidad y post‑procesado automático. Aspose.Slides exporta cada diapositiva a un archivo SVG separado y permite controlar cómo se escriben el texto, las fuentes, las imágenes y los elementos SVG.

Use [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) cuando el SVG exportado deba ser compacto, predecible en distintos navegadores o listo para uso interactivo.

## **Exportar una diapositiva como SVG**

Cree una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), seleccione una diapositiva y escríbala a un flujo con [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Los ejemplos requieren un archivo `presentation.pptx` existente. Cada ejemplo inicia la JVM si es necesario y cierra sus flujos de salida. El siguiente ejemplo exporta cada diapositiva de una presentación como un archivo SVG separado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

El nombre de archivo usa [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) en lugar del índice del bucle. También puede exportar una forma individual con [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) cuando un visor de diapositivas o una página web necesite solo esa forma.

## **Configurar la salida SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) controla el renderizado SVG. Para marcos de texto, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) incluye el marco de texto en el área de renderizado, y [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) determina si se aplica la rotación del marco. Establezca [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) a `True` cuando el texto deba renderizarse sin ligaduras.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Controlar el recorte al final de la línea en puntas de flecha**

SVG 1.1 no dispone de una configuración de inserción de marcador para especificar dónde debe detenerse una línea bajo una punta de flecha. De forma predeterminada, Aspose.Slides acorta la línea exportada para que su trazo no sobresalga del marcador. Llame a [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) con `True` para dibujar el trazo hasta el punto final original de la línea. Esta configuración afecta sólo a la salida SVG. La línea mantiene su posición y longitud en la diapositiva.

El ejemplo dibuja puntas de flecha triangular y de diamante en líneas de 2 pt y 10 pt de ancho. Exporta la misma diapositiva dos veces, cambiando sólo la opción de recorte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

La comparación muestra la punta triangular en la línea de 10 pt. Con el recorte habilitado, la punta es aguda. Con el recorte deshabilitado, el trazo sobresale por los lados inclinados del marcador y deja un extremo plano.

![Triángulo de 10 pt ampliado con una punta aguda cuando el recorte está habilitado y un extremo plano cuando está deshabilitado](line-end-cropping.png)

En las demás líneas del ejemplo, el trazo sobresaliente es menos visible en el triángulo de 2 pt. El diamante relleno cubre el extremo del trazo en ambos anchos.

## **Controlar texto y fuentes**

Al exportar diapositivas a SVG, puede controlar si el texto permanece como texto o se convierte en gráficos vectoriales, y cómo se incluyen o referencian las fuentes externas. Las siguientes opciones le ayudan a equilibrar la consistencia visual, la selección de texto y las dependencias de fuentes en el SVG exportado.

### **Vectorizar todo el texto**

Establezca [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) a `True` para escribir todo el texto de la diapositiva como gráficos vectoriales. Esto elimina las dependencias de fuentes y hace que el resultado visual sea más uniforme entre navegadores, pero el texto ya no será seleccionable ni buscable como texto SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Elegir cómo se manejan las fuentes externas**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) utiliza un valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) para las fuentes que se cargan externamente. Elija `AddLinksToFontFiles` para referenciar archivos de fuentes separados, `Embed` para incluir los datos de la fuente en el SVG, o `Vectorize` para renderizar solo el texto que usa fuentes externas como gráficos. Verifique la licencia de la fuente antes de incrustarla.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Reducir el tamaño de imágenes incrustadas**

Utilice [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) para reducir la resolución de las imágenes incrustadas, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) para omitir áreas recortadas de la fuente y [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) para controlar la calidad de codificación JPEG. Estas configuraciones reducen el tamaño del archivo a costa de la fidelidad de la imagen o de la cantidad de datos de imagen retenidos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Controlar la resolución de rasterización de metarchivos**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) establece el límite inferior de resolución para rasterizar metarchivos durante la exportación SVG. Úselo para equilibrar detalle y tamaño del archivo cuando una imagen EMF o WMF se rasteriza. No define un DPI global para el SVG ni obliga a que todos los objetos de la diapositiva se conviertan en imágenes rasterizadas.

Descargue [metafile-rasterization.pptx](metafile-rasterization.pptx), que contiene una imagen EMF con líneas diagonales muy próximas. El siguiente ejemplo exporta su primera diapositiva a tres resoluciones de rasterización mediante [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Todas las demás configuraciones de exportación permanecen idénticas para que los resultados puedan compararse.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

En la salida, el EMF se convirtió en un PNG incrustado en cada SVG. Las siguientes mediciones corresponden a la presentación suministrada; no representan una fórmula general para convertir DPI a dimensiones en píxeles.

| Resolución de rasterización de metarchivo DPI | Dimensiones del PNG incrustado | Tamaño del archivo SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

La comparación a continuación muestra la misma zona del rasterizado incrustado al mismo tamaño de visualización ampliado. Las líneas diagonales presentan pixelación visible a 72 DPI y bordes más suaves a resoluciones mayores, mientras que el archivo SVG crece. Incrementar el valor no mejora necesariamente cada detalle ni cambia cada imagen exportada.

![Detalle ampliado de línea diagonal a 72, 150 y 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) controla la reducción de resolución de imágenes y puede enmascarar el efecto de cambiar la resolución de rasterización de metarchivos. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) controla la calidad de codificación JPEG, no la resolución de rasterización de metarchivos.

## **Asignar IDs estables a formas y texto**

Utilice un controlador de formato Python registrado mediante `jpype.JProxy` para asignar valores [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) a las formas y valores [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) a los elementos de texto `tspan`. Asigne el proxy con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

El siguiente controlador usa [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), que es estable mientras exista la forma, y un contador repetible para sus fragmentos de texto. Esto hace que los IDs generados sean adecuados para el post‑procesado de una presentación sin cambios.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Agregar controladores de eventos SVG**

En un controlador de formato Python, llame a [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) con un valor [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) para añadir un controlador de eventos JavaScript a una forma exportada. Registre el controlador mediante `jpype.JProxy` y asígnele [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Defina la función JavaScript en la página o documento SVG que aloje el resultado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

La página anfitriona puede definir la función JavaScript referenciada por el controlador. Asignar IDs y controladores de eventos permite visores de diapositivas, mejoras de accesibilidad y otros flujos de trabajo SVG interactivos.

## **Preguntas frecuentes**

**¿Cuándo debo usar [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) en lugar de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) cuando todo el texto deba ser independiente de las fuentes. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) cuando sólo el texto que usa fuentes externas deba convertirse en gráficos.

**¿Cuál es la mejor manera de reducir el tamaño de un SVG?**

Comience comprimiendo las imágenes incrustadas, eliminando áreas recortadas y eligiendo archivos de fuentes enlazados cuando el entorno de destino pueda servirlos. Pruebe el resultado porque la reducción de resolución de imagen, la menor calidad JPEG y el texto vectorizado tienen diferentes compromisos de calidad y tamaño.

**¿Puedo modificar los elementos SVG exportados después de la exportación?**

Sí. Asigne IDs mediante un controlador de formato y luego seleccione los elementos SVG correspondientes en su herramienta de post‑procesado o script de navegador.