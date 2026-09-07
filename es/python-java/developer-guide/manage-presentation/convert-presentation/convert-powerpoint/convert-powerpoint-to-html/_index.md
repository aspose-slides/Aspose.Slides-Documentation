---
title: "Convertir presentaciones de PowerPoint a HTML en Python via Java"
linktitle: "PowerPoint a HTML"
type: docs
weight: 30
url: /es/python-java/convert-powerpoint-to-html/
keywords:
- "convertir PowerPoint"
- "convertir presentación"
- "convertir diapositiva"
- "convertir PPT"
- "convertir PPTX"
- "PowerPoint a HTML"
- "presentación a HTML"
- "diapositiva a HTML"
- "PPT a HTML"
- "PPTX a HTML"
- "guardar PowerPoint como HTML"
- "guardar presentación como HTML"
- "guardar diapositiva como HTML"
- "guardar PPT como HTML"
- "guardar PPTX como HTML"
- "exportar PPT a HTML"
- "exportar PPTX a HTML"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Convertir presentaciones de PowerPoint a HTML en Python mediante Java. Utilice Aspose.Slides para exportar archivos PPT y PPTX, diapositivas seleccionadas, notas, fuentes, imágenes, SVG y medios."
---
## **Visión general**

Aspose.Slides for Python via Java puede guardar presentaciones de PowerPoint como HTML sin Microsoft PowerPoint. La conversión básica consiste en una única carga de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y una llamada a [save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) con [SaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/). Utilice [HtmlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/) cuando necesite controlar el diseño exportado, fuentes, imágenes, notas, comentarios, salida SVG o recursos vinculados.

Esta guía se centra en escenarios prácticos de exportación a HTML:

- Exportar una presentación completa o diapositivas seleccionadas.
- Generar HTML de diseño fijo, adaptativo o basado en SVG.
- Incluir notas del orador y comentarios.
- Controlar la calidad de la imagen y los datos de imágenes recortadas.
- Incrustar fuentes o guardar los archivos de fuentes por separado.
- Elegir cómo se escriben y hacen referencia los recursos externos y los archivos multimedia.

Por defecto, la exportación a HTML produce un documento HTML autocontenido donde la mayoría de los recursos están incrustados. Esto es conveniente para compartir un solo archivo, pero puede aumentar el tamaño del resultado. Para la publicación web, considere recursos externos, reducir la DPI de las imágenes y solo incrustar fuentes que no estén disponibles de forma fiable en el entorno de destino.

## **Convertir una presentación a HTML**

Para exportar una presentación a HTML, cárguela con [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y guárdela con [SaveFormat.Html](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#Html).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Cada ejemplo carga `presentation.pptx` desde el directorio de trabajo actual. Instale Aspose.Slides for Python via Java y un entorno de ejecución Java compatible antes de ejecutarlo. La JVM se inicia una vez por proceso de Python.

Este ejemplo escribe un archivo HTML. El objeto de presentación se elimina en el bloque `finally`, lo que libera los manejadores de archivo y los recursos de renderizado después de la exportación.

## **Configurar la exportación a HTML**

[HtmlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/) es la clase principal de configuración para la exportación a HTML. Las configuraciones comunes incluyen:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): agrega notas, comentarios, folletos u otra información de diseño.
- [setHtmlFormatter](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setHtmlFormatter): cambia la estructura del documento HTML o delega el formateo a un controlador.
- [setSlideImageFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setSlideImageFormat): cambia la forma en que se representan las diapositivas, por ejemplo como SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setPicturesCompression): controla la DPI de la imagen y el tamaño del resultado.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): conserva o elimina los datos de imágenes recortadas.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): hace que el contenido SVG exportado se adapte a su contenedor.
- [setShowHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): incluye diapositivas ocultas cuando sea necesario.

Las secciones siguientes muestran por separado las opciones más habituales para que pueda combinar solo las que su flujo de trabajo necesita.

## **Convertir diapositivas seleccionadas a HTML**

La sobrecarga de [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) que acepta números de diapositiva utiliza posiciones de diapositiva basadas en 1. El bucle a continuación guarda cada diapositiva en un archivo HTML separado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

Utilice este patrón cuando un sitio web o una aplicación necesite una página HTML por diapositiva. Si cada diapositiva debe tener el mismo diseño, cree una instancia de [HtmlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/) y pásela a cada llamada de [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save).

## **Crear HTML adaptativo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/es/python-java/aspose.slides/responsivehtmlcontroller/) proporciona salida HTML adaptativa a través de [HtmlFormatter](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmlformatter/). Úselo cuando la página exportada deba adaptarse mejor al ancho del navegador.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Para un diseño responsivo basado en SVG, llame a [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) con `True`. Esto es útil cuando el contenido de la diapositiva se exporta como marcado SVG escalable.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Incluir notas del orador y comentarios**

Utilice [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/notescommentslayoutingoptions/) a través de [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) para incluir notas del orador o comentarios. Las notas y los comentarios están ocultos por defecto a menos que elija sus posiciones.

Supongamos que la presentación fuente contiene notas del orador:

![Diapositiva con notas del orador en PowerPoint](slide_with_notes.png)

El siguiente código exporta el contenido de la diapositiva con las notas del orador debajo de la diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

![Salida HTML con la diapositiva y notas del orador](HTML_with_notes.png)

Para exportar comentarios, llame a [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/es/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), por ejemplo con [CommentsPositions.Right](https://reference.aspose.com/slides/es/python-java/aspose.slides/commentspositions/#Right) o [CommentsPositions.Bottom](https://reference.aspose.com/slides/es/python-java/aspose.slides/commentspositions/#Bottom). Si solo necesita comentarios, omita [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/es/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Si necesita tanto notas como comentarios, llame a ambos métodos.

## **Controlar la calidad de la imagen y áreas recortadas**

La exportación a HTML puede comprimir las imágenes de las diapositivas para reducir el tamaño del resultado. Pase un valor a [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setPicturesCompression) desde [PicturesCompression](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturescompression/) cuando necesite mayor calidad de imagen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Por defecto, las áreas recortadas de las imágenes pueden eliminarse del resultado exportado. Mantenga los datos recortados solo cuando los usuarios deban poder recuperar o inspeccionar esas partes ocultas de la imagen. Conservarlos puede aumentar el tamaño del HTML.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Añadir CSS**

Para un estilo sencillo, pase una cadena CSS a [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Esto cambia el documento HTML circundante mientras Aspose.Slides sigue renderizando el contenido de la diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Para un encabezado de documento personalizado, un archivo CSS vinculado o un marcado personalizado alrededor de diapositivas y formas, utilice un controlador de formato personalizado a través de un proxy de interfaz JPype y páselo a [HtmlFormatter](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmlformatter/) con [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Incrustar fuentes**

Si el entorno de destino puede no tener instaladas las fuentes de la presentación, incruste fuentes en el HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/python-java/aspose.slides/embedallfontshtmlcontroller/). La incrustación mejora la fidelidad visual pero aumenta el tamaño del resultado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Excluya fuentes solo cuando esté seguro de que los navegadores o sistemas de destino ya las proporcionan. Para fuentes de marca o fuentes menos comunes, la incrustación suele ser más segura.

## **Guardar recursos externamente**

El HTML autocontenido es fácil de mover, pero los recursos incrustados en Base64 pueden hacer que el archivo sea grande. Si su aplicación necesita archivos de imagen externos, implemente un controlador de enlace de recursos a través de un proxy de interfaz JPype y páselo al constructor de [HtmlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/).

Al externalizar recursos, elija dos rutas de manera deliberada:

- La ruta de salida del sistema de archivos, donde su aplicación escribe imágenes, fuentes, audio o vídeo generados.
- La ruta URL, que es la que el navegador usa desde el documento HTML para cargar esos archivos.

## **Exportar archivos multimedia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoplayerhtmlcontroller/) exporta archivos de vídeo y audio y escribe HTML que puede reproducirlos en un navegador. Su constructor recibe:

- `path`: el directorio donde se escribirán los archivos multimedia generados.
- `fileName`: el nombre del archivo HTML que se está generando.
- `baseUri`: el prefijo URI absoluto usado en los enlaces HTML a los archivos multimedia.

El siguiente ejemplo exporta medios ya incrustados en `presentation.pptx`. El HTML generado hace referencia a los archivos multimedia solo por su nombre de archivo, relativo al documento HTML, por lo que `path` debe ser el directorio que también recibe el archivo HTML. `baseUri` debe ser una URI absoluta: para vista previa local, construya una URI `file:///` a partir del directorio de salida; para una aplicación desplegada, use la URL absoluta del directorio publicado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Utilice directorios de salida que sean únicos por trabajo de exportación, especialmente en aplicaciones de servidor. Las rutas de salida compartidas pueden provocar que archivos de diferentes conversiones se sobrescriban entre sí.

## **Rendimiento y gestión de recursos**

La conversión a HTML es una operación de renderizado, por lo que el tiempo de procesamiento y el uso de memoria dependen del número de diapositivas, la resolución de las imágenes, fuentes, efectos, gráficos y medios incrustados. Valores de DPI de imagen más altos pasados a [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setPicturesCompression), fuentes incrustadas, salida SVG y áreas recortadas de imágenes conservadas pueden mejorar la fidelidad pero generalmente aumentan el tamaño del resultado.

Para conversión por lotes:

- Libere cada instancia de [Presentation] de forma pronta.
- Utilice directorios de salida separados para trabajos separados.
- Evite incrustar fuentes comunes a menos que la fidelidad lo requiera.
- Reduzca la DPI de la imagen cuando el HTML sea para vista previa o miniaturas.
- Mantenga la presentación fuente, el HTML generado y los recursos externos juntos hasta que las rutas de despliegue sean definitivas.

## **Preguntas frecuentes**

**¿Se conservan los hipervínculos en la salida HTML?**

Sí. Los hipervínculos de la presentación se exportan a HTML y siguen siendo clicables cuando la URL de destino es válida.

**¿Puedo convertir presentaciones a HTML en paralelo?**

Sí, pero no comparta una instancia de [Presentation] entre hilos. Procese archivos diferentes con instancias de presentación separadas, flujos separados y directorios de salida distintos. Consulte la [guía de multiproceso](/slides/es/python-java/multithreading/) para más detalles.

**¿Es seguro usar un objeto de presentación en varios hilos?**

No. Una única instancia de [Presentation] debe cargarse, modificarse, guardarse y eliminarse en un solo hilo. Para trabajo paralelo, cree una instancia independiente por hilo o proceso.

**¿Por qué el archivo HTML generado es grande?**

La exportación predeterminada puede incrustar recursos directamente en el HTML. Las fuentes incrustadas, imágenes de alta DPI, medios, contenido SVG y áreas recortadas de imágenes conservadas también aumentan el tamaño. Use recursos externos, excluya fuentes comunes de la incrustación y pase un valor de DPI más bajo a [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setPicturesCompression) cuando un tamaño más pequeño sea más importante que la máxima fidelidad.

**¿Por qué los valores de font-size en HTML pueden diferir de los valores de PowerPoint?**

La página exportada puede usar sistemas de coordenadas SVG y transformaciones de escala. Un valor bruto de font-size en CSS o SVG por sí solo no describe el tamaño final mostrado. Compare la diapositiva renderizada al nivel de zoom previsto y verifique la disponibilidad de fuentes si el texto se ve diferente.

**¿Cómo debo elegir baseUri para la exportación de medios?**

Elija `baseUri` desde el punto de vista del navegador y páselo como una URI absoluta. Para vista previa local, puede derivarla del directorio de salida con `output_directory.as_uri() + "/"`. Para el despliegue, utilice la URL absoluta del directorio publicado. El `path` del sistema de archivos y el `baseUri` del navegador no tienen que ser la misma cadena, pero deben describir la misma ubicación, y esa ubicación debe ser el directorio que contiene el archivo HTML generado porque los enlaces a los medios se escriben de forma relativa a él.

**¿Puedo incluir diapositivas ocultas?**

Sí. Llame a [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) con `True` cuando sea necesario exportar diapositivas ocultas.