---
title: Convertir presentaciones de PowerPoint a HTML en Python
linktitle: PowerPoint a HTML
type: docs
weight: 30
url: /es/python-net/convert-powerpoint-to-html/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a HTML
- presentación a HTML
- diapositiva a HTML
- PPT a HTML
- PPTX a HTML
- guardar PowerPoint como HTML
- guardar presentación como HTML
- guardar diapositiva como HTML
- guardar PPT como HTML
- guardar PPTX como HTML
- exportar PPT a HTML
- exportar PPTX a HTML
- Python
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint a HTML en Python. Utilice Aspose.Slides para exportar archivos PPT y PPTX, diapositivas seleccionadas, notas, fuentes, imágenes, SVG y medios."
---
## **Descripción general**

Aspose.Slides for Python via .NET puede guardar presentaciones de PowerPoint como HTML sin Microsoft PowerPoint. La conversión básica consiste en cargar una única [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y una llamada a `save` con [SaveFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/saveformat/). Utilice [HtmlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmloptions/) cuando necesite controlar el diseño exportado, fuentes, imágenes, notas, comentarios, salida SVG o recursos vinculados.

Esta guía se centra en escenarios prácticos de exportación a HTML:

- Exportar una presentación completa o diapositivas seleccionadas.
- Generar HTML con diseño fijo, adaptable o basado en SVG.
- Incluir notas del orador y comentarios.
- Controlar la calidad de la imagen y los datos de áreas recortadas.
- Incrustar fuentes o guardar los archivos de fuentes por separado.
- Elegir cómo se escriben y referencian los recursos externos y los archivos multimedia.

De forma predeterminada, la exportación a HTML produce un documento HTML autocontenido donde la mayoría de los recursos están incrustados. Esto es conveniente para compartir un único archivo, pero puede aumentar el tamaño de salida. Para la publicación web, considere recursos externos, reducir la DPI de las imágenes y solo incrustar fuentes que no estén disponibles de forma fiable en el entorno de destino.

## **Convertir una presentación a HTML**

Para exportar una presentación a HTML, cárguela con [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y guárdela con [SaveFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Este ejemplo escribe un archivo HTML. La sentencia `with` libera el objeto de presentación y libera los manejadores de archivo y los recursos de renderizado después de la exportación.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmloptions/) es la clase principal de configuración para la exportación a HTML. Los ajustes más comunes incluyen:

- `slides_layout_options`: agrega notas, comentarios, folletos u otra información de diseño.
- `html_formatter`: cambia la estructura del documento HTML o delega el formato a un controlador.
- `slide_image_format`: cambia cómo se representan las diapositivas, por ejemplo como SVG.
- `pictures_compression`: controla la DPI de la imagen y el tamaño de salida.
- `delete_pictures_cropped_areas`: conserva o elimina los datos de imágenes recortadas.
- `svg_responsive_layout`: hace que el contenido SVG exportado se adapte a su contenedor.
- `show_hidden_slides`: incluye diapositivas ocultas cuando sea necesario.

Las secciones siguientes muestran las opciones más comunes por separado para que pueda combinar solo las que su flujo de trabajo necesita.

## **Convertir diapositivas seleccionadas a HTML**

La sobrecarga de `save` que acepta números de diapositiva utiliza posiciones basadas en 1. El bucle a continuación guarda cada diapositiva en un archivo HTML separado.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Utilice este patrón cuando un sitio web o aplicación necesite una página HTML por diapositiva. Si cada diapositiva debe tener el mismo diseño, cree una única instancia de [HtmlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmloptions/) y pásela a cada llamada a `save`.

## **Crear HTML adaptable**

[ResponsiveHtmlController](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/responsivehtmlcontroller/) proporciona salida HTML adaptable mediante [HtmlFormatter](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmlformatter/). Úselo cuando la página exportada deba adaptarse mejor al ancho del navegador.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Para un diseño adaptable basado en SVG, establezca `svg_responsive_layout` en [HtmlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmloptions/). Esto es útil cuando el contenido de la diapositiva se exporta como marcado SVG escalable.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Incluir notas del orador y comentarios**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/notescommentslayoutingoptions/) a través de `html_options.slides_layout_options` para incluir notas del orador o comentarios. Las notas y los comentarios están ocultos por defecto a menos que elija sus posiciones.

Suponga que la presentación original contiene notas del orador:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

El siguiente código exporta el contenido de la diapositiva con las notas del orador debajo de la diapositiva.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

El HTML exportado incluye el área de notas:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Para exportar comentarios, establezca `comments_position`, por ejemplo a `CommentsPositions.RIGHT` o `CommentsPositions.BOTTOM`. Si solo necesita comentarios, omita `notes_position`. Si necesita tanto notas como comentarios, establezca ambas propiedades.

## **Controlar la calidad de la imagen y áreas recortadas**

La exportación a HTML puede comprimir las imágenes de las diapositivas para reducir el tamaño de salida. Establezca `pictures_compression` a un valor de [PicturesCompression](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/picturescompression/) cuando necesite mayor calidad de imagen.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

De forma predeterminada, las áreas recortadas de las imágenes pueden eliminarse del resultado exportado. Conserve los datos recortados solo cuando los usuarios deban poder recuperar o inspeccionar esas partes ocultas de la imagen. Mantenerlos puede aumentar el tamaño del HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Añadir CSS**

Para un estilo sencillo, pase una cadena CSS a [HtmlFormatter](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmlformatter/). Esto modifica el documento HTML circundante mientras Aspose.Slides sigue renderizando el contenido de la diapositiva.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Para un encabezado de documento personalizado, un archivo CSS vinculado o un marcado personalizado alrededor de diapositivas y formas, utilice un controlador de formato personalizado y páselo a [HtmlFormatter](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmlformatter/) con `create_custom_formatter`.

## **Incrustar fuentes**

Si el entorno de destino puede no tener instaladas las fuentes de la presentación, incruste las fuentes en el HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/embedallfontshtmlcontroller/). La incrustación mejora la fidelidad visual pero aumenta el tamaño de salida.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Excluya una fuente solo cuando esté seguro de que los navegadores o sistemas de destino ya la proporcionan. Para fuentes de marca o fuentes poco comunes, la incrustación suele ser más segura.

## **Vincular archivos de fuentes en lugar de incrustarlos**

Para reducir el tamaño del archivo HTML, puede escribir los datos de la fuente en archivos WOFF separados y añadir reglas `@font-face` al HTML. Esto requiere un controlador que personalice cómo se escriben los datos de la fuente durante la exportación. En Python via .NET, implemente ese controlador en un pequeño ensamblado auxiliar de .NET, cárguelo en Python y pase el objeto auxiliar a [HtmlFormatter](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmlformatter/) con `create_custom_formatter`.

Al externalizar fuentes, elija dos rutas de forma deliberada:

- El directorio de salida del sistema de archivos donde se escribirán los archivos WOFF generados.
- La ruta URL que aparecerá en el documento HTML y que el navegador usará para cargar esos archivos de fuentes.

Mantenga el archivo HTML y los archivos de fuentes generados juntos hasta que las rutas de implementación sean definitivas.

## **Guardar recursos externamente**

El HTML autocontenido es fácil de mover, pero los recursos incrustados en Base64 pueden hacer que el archivo sea grande. Si su aplicación necesita archivos externos de imagen, fuente, audio o video, use un controlador personalizado de enlace/incrustación y páselo al constructor de [HtmlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmloptions/).

Al externalizar recursos, elija dos rutas de forma deliberada:

- La ruta de salida del sistema de archivos, donde su aplicación escribe las imágenes, fuentes, audio o video generados.
- La ruta URL, que es la que el navegador usa desde el documento HTML para cargar esos archivos.

Para una discusión completa sobre la vinculación de imágenes, consulte [Export Presentations to HTML with Externally Linked Images](/slides/es/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Exportar archivos multimedia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/videoplayerhtmlcontroller/) exporta archivos de video y audio y genera HTML que puede reproducirlos en un navegador. Su constructor recibe:

- `path`: el directorio donde se escribirán los archivos multimedia generados.
- `file_name`: el nombre del archivo HTML que se está generando.
- `base_uri`: el prefijo URI absoluto utilizado en los enlaces HTML a los archivos multimedia.

Si el archivo HTML es `html-output/presentation.html` y los archivos multimedia se guardan en `html-output/media`, `path` debe apuntar al directorio multimedia en disco, mientras que `base_uri` debe apuntar al mismo directorio desde el punto de vista del navegador. Para una vista previa local, puede crear una URI `file:///` a partir del directorio multimedia. Para una aplicación desplegada, use la URL absoluta del directorio multimedia publicado.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Use directorios de salida que sean únicos por trabajo de exportación, especialmente en aplicaciones de servidor. Las rutas de salida compartidas pueden provocar que archivos de diferentes conversiones se sobrescriban entre sí.

## **Rendimiento y gestión de recursos**

La conversión a HTML es una operación de renderizado, por lo que el tiempo de procesamiento y el uso de memoria dependen del número de diapositivas, la resolución de las imágenes, fuentes, efectos, gráficos y medios incrustados. Valores mayores de DPI en `pictures_compression`, fuentes incrustadas, salida SVG y áreas de imagen recortadas retenidas pueden mejorar la fidelidad pero suelen aumentar el tamaño de salida.

Para conversiones por lotes:

- Libere rápidamente cada instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
- Use directorios de salida separados para trabajos distintos.
- Evite incrustar fuentes comunes a menos que la fidelidad lo requiera.
- Reduzca la DPI de la imagen cuando el HTML sea para vista previa o miniaturas.
- Mantenga la presentación fuente, el HTML generado y los recursos externos juntos hasta que las rutas de implementación sean definitivas.

## **FAQ**

**¿Se conservan los hipervínculos en el HTML exportado?**

Sí. Los hipervínculos de la presentación se exportan a HTML y siguen siendo clicables cuando la URL de destino es válida.

**¿Puedo convertir presentaciones a HTML en paralelo?**

Sí, pero no comparta una instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) entre hilos. Procese archivos diferentes con instancias de presentación separadas, flujos independientes y directorios de salida distintos. Consulte la [multithreading guidance](/slides/es/python-net/multithreading/) para más detalles.

**¿Es seguro usar un objeto Presentation en varios hilos?**

No. Una única instancia de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) debe cargarse, modificarse, guardarse y liberarse en un solo hilo. Para trabajo en paralelo, cree una instancia independiente por hilo o proceso.

**¿Por qué el archivo HTML generado es grande?**

La exportación predeterminada puede incrustar recursos directamente en el HTML. Las fuentes incrustadas, imágenes de alta DPI, medios, contenido SVG y áreas de imagen recortadas retenidas también aumentan el tamaño. Use recursos externos, excluya fuentes comunes de la incrustación y reduzca `pictures_compression` cuando un tamaño menor sea más importante que la máxima fidelidad.

**¿Cómo debo elegir base_uri para la exportación de medios?**

Elija `base_uri` desde el punto de vista del navegador y páselo como una URI absoluta. Para una vista previa local, puede derivarla del directorio de salida con `Path(media_directory).as_uri() + "/"`. Para implementación, use la URL absoluta del directorio de medios publicado. La ruta del sistema de archivos `path` y la `base_uri` del navegador no tienen que ser la misma cadena, pero deben describir la misma ubicación del recurso.

**¿Puedo incluir diapositivas ocultas?**

Sí. Establezca `show_hidden_slides = True` en [HtmlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmloptions/) cuando sea necesario exportar diapositivas ocultas.