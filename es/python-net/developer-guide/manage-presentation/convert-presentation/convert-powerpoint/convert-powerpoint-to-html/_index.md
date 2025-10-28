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
- Python
- Aspose.Slides
description: "Convierte presentaciones de PowerPoint a HTML responsivo en Python. Conserva el diseño, los enlaces y las imágenes con la guía de conversión de Aspose.Slides para obtener resultados rápidos y perfectos."
---

## **Resumen**

Este artículo explica cómo convertir una presentación de PowerPoint a formato HTML usando Python. Cubre los siguientes temas.

- Convertir PowerPoint a HTML en Python
- Convertir PPT a HTML en Python
- Convertir PPTX a HTML en Python
- Convertir ODP a HTML en Python
- Convertir diapositiva de PowerPoint a HTML en Python

## **PowerPoint a HTML con Python**

Para el código de ejemplo en Python que convierte PowerPoint a HTML, consulte la sección a continuación, es decir, [Convert PowerPoint to HTML](#convert-powerpoint-to-html). El código puede cargar varios formatos como PPT, PPTX y ODP en el objeto Presentation y guardarlo en formato HTML.

## **Acerca de la conversión de PowerPoint a HTML**
Usando [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), aplicaciones y desarrolladores pueden convertir una presentación de PowerPoint a HTML: **PPTX a HTML** o **PPT a HTML**. 

**Aspose.Slides** proporciona muchas opciones (principalmente de la clase [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)) que definen el proceso de conversión de PowerPoint a HTML:

* Convertir una presentación completa de PowerPoint a HTML.
* Convertir una diapositiva específica de una presentación de PowerPoint a HTML.
* Convertir los medios de la presentación (imágenes, videos, etc.) a HTML.
* Convertir una presentación de PowerPoint a HTML responsivo. 
* Convertir una presentación de PowerPoint a HTML con notas del presentador incluidas o excluidas. 
* Convertir una presentación de PowerPoint a HTML con comentarios incluidos o excluidos. 
* Convertir una presentación de PowerPoint a HTML con fuentes originales o incrustadas. 
* Convertir una presentación de PowerPoint a HTML utilizando el nuevo estilo CSS. 

{{% alert color="primary" %}} 

Usando su propia API, Aspose desarrolló conversores gratuitos de [presentación a HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT a HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX a HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP a HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Puede que quiera revisar otros [conversores gratuitos de Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Además de los procesos de conversión descritos aquí, Aspose.Slides también admite estas operaciones de conversión relacionadas con el formato HTML: 

* [HTML a imagen](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}


## **Convertir PowerPoint a HTML**
Usando Aspose.Slides, puede convertir una presentación completa de PowerPoint a HTML de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. Utilice el método [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para guardar el objeto como un archivo HTML.

Este código le muestra cómo convertir un PowerPoint a HTML en python:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Saving the presentation to HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **Convertir PowerPoint a HTML responsivo**

Aspose.Slides proporciona la clase [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) que permite generar archivos HTML responsivos. Este código le muestra cómo convertir una presentación de PowerPoint a HTML responsivo en python:

```py
# Instantiate a Presentation object that represents a presentation file
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Saving the presentation to HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **Convertir PowerPoint a HTML con notas**
Este código le muestra cómo convertir un PowerPoint a HTML con notas en python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Convertir PowerPoint a HTML con fuentes originales**
Aspose.Slides proporciona la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) que permite incrustar todas las fuentes en una presentación mientras se convierte a HTML.

Para evitar que ciertas fuentes se incrusten, puede pasar una matriz de nombres de fuentes a un constructor parametrizado de la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Las fuentes populares, como Calibri o Arial, cuando se usan en una presentación, no tienen que incrustarse porque la mayoría de los sistemas ya las contienen. Cuando esas fuentes se incrustan, el documento HTML resultante se vuelve innecesariamente grande.

La clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) soporta herencia y provee el método `WriteFont`, que debe sobrescribirse. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# exclude default presentation fonts
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Convertir diapositiva a HTML**
Convertir una diapositiva individual a HTML. Para ello use el mismo método [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expuesto por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que se usa para convertir toda la presentación PPT(X) en un documento HTML. La clase [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) también puede usarse para establecer opciones de conversión adicionales:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **Guardar CSS e imágenes al exportar a HTML**
Usando los nuevos archivos de estilo CSS, puede cambiar fácilmente el estilo del archivo HTML resultante del proceso de conversión de PowerPoint a HTML. 

El código python en este ejemplo le muestra cómo usar métodos sobrescribibles para crear un documento HTML personalizado con un enlace a un archivo CSS:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Enlazar todas las fuentes al convertir una presentación a HTML**
Si no desea incrustar fuentes (para evitar aumentar el tamaño del HTML resultante), puede enlazar todas las fuentes implementando su propia versión de `LinkAllFontsHtmlController`. 

Este código python le muestra cómo convertir un PowerPoint a HTML enlazando todas las fuentes y excluyendo "Calibri" y "Arial" (ya que existen en el sistema): 

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Compatibilidad con la propiedad responsive de SVG**
El siguiente ejemplo muestra cómo exportar una presentación PPT(X) a HTML con el diseño responsive:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Exportar archivos multimedia a archivo HTML**
Usando Aspose.Slides para python, puede exportar archivos multimedia de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a la diapositiva.
1. Agregue un video a la diapositiva.
1. Escriba la presentación como un archivo HTML.

Este código python le muestra cómo agregar un video a la presentación y luego guardarla como HTML:

```py
import aspose.slides as slides

# Loading a presentation
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

## Preguntas frecuentes

### **¿Cómo puedo convertir una presentación de PowerPoint a HTML usando Python?**

Puede usar la biblioteca Aspose.Slides for Python via .NET para cargar archivos PPT, PPTX o ODP y convertirlos a HTML mediante el método `save()` con `SaveFormat.HTML`.

### **¿Aspose.Slides admite convertir diapositivas individuales de PowerPoint a HTML?**

Sí, Aspose.Slides permite convertir tanto la presentación completa como diapositivas específicas a HTML configurando `HtmlOptions` según sea necesario.

### **¿Puedo generar HTML responsivo a partir de presentaciones de PowerPoint?**

Sí, con la clase `ResponsiveHtmlController` puede exportar su presentación a un diseño HTML responsivo que se adapta a diferentes tamaños de pantalla.

### **¿Es posible incluir notas del presentador o comentarios en el HTML exportado?**

Sí, puede configurar `HtmlOptions` para incluir o excluir notas del presentador y comentarios al exportar presentaciones de PowerPoint a HTML.

### **¿Puedo incrustar fuentes al convertir una presentación a HTML?**

Sí, Aspose.Slides proporciona la clase `EmbedAllFontsHtmlController`, que permite incrustar fuentes o excluir ciertas fuentes para reducir el tamaño del archivo de salida.

### **¿La conversión de PowerPoint a HTML admite archivos multimedia como videos y audio?**

Sí, Aspose.Slides permite exportar contenido multimedia incrustado en diapositivas a HTML usando `VideoPlayerHtmlController` y clases de configuración relacionadas.

### **¿Qué formatos de archivo son compatibles para la conversión a HTML?**

Aspose.Slides admite la conversión de los formatos de presentación PPT, PPTX y ODP a HTML. También permite guardar contenido de diapositivas como SVG y exportar activos multimedia.

### **¿Puedo evitar incrustar fuentes para reducir el tamaño del HTML resultante?**

Sí, puede enlazar fuentes del sistema como Arial o Calibri en lugar de incrustarlas, implementando una versión personalizada del `HtmlController`.

### **¿Existe una herramienta en línea para convertir PowerPoint a HTML?**

Sí, puede probar las herramientas web gratuitas de Aspose, como [PPT a HTML](https://products.aspose.app/slides/conversion/ppt-to-html) o [PPTX a HTML](https://products.aspose.app/slides/conversion/pptx-to-html), para convertir presentaciones directamente en su navegador sin escribir código.

### **¿Puedo usar CSS personalizado en el archivo HTML exportado?**

Sí, Aspose.Slides permite enlazar a archivos CSS externos durante la conversión, lo que le permite personalizar completamente la apariencia del contenido HTML resultante.