---
title: Convertir PowerPoint a HTML en Python
linktitle: Convertir PowerPoint a HTML
type: docs
weight: 30
url: /es/python-net/convert-powerpoint-to-html/
keywords: "Python PowerPoint a HTML, Convertir Presentación de PowerPoint, PPTX, PPT, PPT a HTML, PPTX a HTML, PowerPoint a HTML, Guardar PowerPoint como HTML, Guardar PPT como HTML, Guardar PPTX como HTML, Python, Aspose.Slides, exportación a HTML"
description: "Convertir PowerPoint a HTML: Guardar PPTX o PPT como HTML. Guardar diapositivas como HTML"
---

## **Resumen**

Este artículo explica cómo convertir una Presentación de PowerPoint en formato HTML utilizando Python. Cubre los siguientes temas.

- Convertir PowerPoint a HTML en Python
- Convertir PPT a HTML en Python
- Convertir PPTX a HTML en Python
- Convertir ODP a HTML en Python
- Convertir Diapositiva de PowerPoint a HTML en Python

## **Python PowerPoint a HTML**

Para ver un código de ejemplo en Python para convertir PowerPoint a HTML, consulte la sección a continuación, es decir, [Convertir PowerPoint a HTML](#convert-powerpoint-to-html). El código puede cargar varios formatos como PPT, PPTX y ODP en un objeto Presentación y guardarlo en formato HTML.


## **Acerca de la Conversión de PowerPoint a HTML**
Usando [**Aspose.Slides para Python a través de .NET**](https://products.aspose.com/slides/python-net/), las aplicaciones y desarrolladores pueden convertir una presentación de PowerPoint a HTML: **PPTX a HTML** o **PPT a HTML**. 

**Aspose.Slides** proporciona muchas opciones (principalmente de la clase [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)) que definen el proceso de conversión de PowerPoint a HTML:

* Convertir toda una presentación de PowerPoint a HTML.
* Convertir una diapositiva específica de una presentación de PowerPoint a HTML.
* Convertir medios de presentación (imágenes, videos, etc.) a HTML.
* Convertir una presentación de PowerPoint a HTML responsivo. 
* Convertir una presentación de PowerPoint a HTML con notas del hablante incluidas o excluidas. 
* Convertir una presentación de PowerPoint a HTML con comentarios incluidos o excluidos. 
* Convertir una presentación de PowerPoint a HTML con fuentes originales o integradas. 
* Convertir una presentación de PowerPoint a HTML utilizando el nuevo estilo CSS. 

{{% alert color="primary" %}} 

Usando su propia API, Aspose desarrolló convertidores gratuitos [de presentación a HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT a HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX a HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP a HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Es posible que desee consultar otros [convertidores gratuitos de Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}} 

Además de los procesos de conversión descritos aquí, Aspose.Slides también admite estas operaciones de conversión que involucran el formato HTML: 

* [HTML a imagen](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}


## **Convertir PowerPoint a HTML**
Usando Aspose.Slides, puedes convertir toda una presentación de PowerPoint a HTML de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Usa el método [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para guardar el objeto como un archivo HTML.

Este código te muestra cómo convertir un PowerPoint a HTML en python:

```python
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Guardar la presentación en HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **Convertir PowerPoint a HTML Responsivo**

Aspose.Slides proporciona la clase [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) que te permite generar archivos HTML responsivos. Este código te muestra cómo convertir una presentación de PowerPoint a HTML responsivo en python:

```py
# Instanciar un objeto Presentation que representa un archivo de presentación
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Guardar la presentación en HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **Convertir PowerPoint a HTML con Notas**
Este código te muestra cómo convertir un PowerPoint a HTML con notas en python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Convertir PowerPoint a HTML con Fuentes Originales**
Aspose.Slides proporciona la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) que permite incrustar todas las fuentes en una presentación al convertirla a HTML.

Para evitar que ciertas fuentes se incrusten, puedes pasar un arreglo de nombres de fuentes a un constructor parametrizado de la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Las fuentes populares, como Calibri o Arial, cuando se utilizan en una presentación, no necesitan ser incrustadas porque la mayoría de los sistemas ya contienen esas fuentes. Cuando esas fuentes se incrustan, el documento HTML resultante se vuelve innecesariamente grande.

La clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) soporta herencia y proporciona el método `WriteFont`, que está destinado a ser sobreescrito. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# excluir fuentes predeterminadas de la presentación
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Convertir Diapositiva a HTML**
Convierte una diapositiva de presentación separada a HTML. Para eso, usa el mismo método [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expuesto por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que se utiliza para convertir toda la presentación PPT(X) en un documento HTML. La clase [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) también puede usarse para establecer opciones de conversión adicionales:

```py
# [TODO[not_supported_yet]: implementación en python de la interfaz .net]
```


## **Guardar CSS e Imágenes al Exportar a HTML**
Usando nuevos archivos de estilo CSS, puedes cambiar fácilmente el estilo del archivo HTML resultante del proceso de conversión de PowerPoint a HTML. 

El código en python en este ejemplo te muestra cómo usar métodos sobreescribibles para crear un documento HTML personalizado con un enlace a un archivo CSS:

```py
# [TODO[not_supported_yet]: implementación en python de las interfaces .net]
```

## **Vincular Todas las Fuentes al Convertir Presentación a HTML**
Si no deseas incrustar fuentes (para evitar aumentar el tamaño del HTML resultante), puedes vincular todas las fuentes implementando tu propia versión de `LinkAllFontsHtmlController`. 

Este código en python te muestra cómo convertir un PowerPoint a HTML mientras vinculas todas las fuentes y excluyes "Calibri" y "Arial" (ya que ya existen en el sistema): 

```py
# [TODO[not_supported_yet]: implementación en python de las interfaces .net]
```

## **Soporte de Propiedad SVG Responsiva**
El siguiente ejemplo de código muestra cómo exportar una presentación PPT(X) a HTML con el diseño responsivo:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **Exportar Archivos de Medios a Archivo HTML**
Usando Aspose.Slides para python, puedes exportar archivos de medios de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a la diapositiva.
1. Agrega un video a la diapositiva.
1. Escribe la presentación como un archivo HTML.

Este código en python te muestra cómo agregar un video a la presentación y luego guardarlo como HTML:

```py
import aspose.slides as slides

# Cargando una presentación
presentation = slides.Presentation("Media File.pptx")

path = "C:\\"
fileName = "ExportMediaFiles_out.html"
baseUri = "http://www.example.com/"

controller = slides.export.VideoPlayerHtmlController(path, fileName, baseUri)

htmlOptions = slides.export.HtmlOptions(controller)
svgOptions = slides.export.SVGOptions(controller)

htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
htmlOptions.slide_image_format = slides.export.SlideImageFormat.svg(svgOptions)

presentation.save(path + "ExportMediaFiles_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```