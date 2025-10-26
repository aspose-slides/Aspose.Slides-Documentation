---
title: Convert PowerPoint Presentations to HTML in Python
linktitle: PowerPoint to HTML
type: docs
weight: 30
url: /es/python-net/developer-guide/manage-presentation/convert-presentation/convert-powerpoint/convert-powerpoint-to-html/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to HTML
- presentation to HTML
- slide to HTML
- PPT to HTML
- PPTX to HTML
- save PowerPoint as HTML
- save presentation as HTML
- save slide as HTML
- save PPT as HTML
- save PPTX as HTML
- Python
- Aspose.Slides
description: "Convert PowerPoint presentations to responsive HTML in Python. Preserve layout, links, and images with Aspose.Slides conversion guide for fast, flawless results."
---

## **Resumen**

Este artículo explica cómo convertir una presentación de PowerPoint al formato HTML usando Python. Cubre los siguientes temas.

- Convertir PowerPoint a HTML en Python
- Convertir PPT a HTML en Python
- Convertir PPTX a HTML en Python
- Convertir ODP a HTML en Python
- Convertir diapositiva de PowerPoint a HTML en Python

## **PowerPoint a HTML con Python**

Para obtener el código de ejemplo en Python que convierte PowerPoint a HTML, consulte la siguiente sección, [Convertir PowerPoint a HTML](#convert-powerpoint-to-html). El código puede cargar varios formatos como PPT, PPTX y ODP en un objeto Presentation y guardarlo en formato HTML.

## **Acerca de la conversión de PowerPoint a HTML**
Usando [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), las aplicaciones y los desarrolladores pueden convertir una presentación de PowerPoint a HTML: **PPTX a HTML** o **PPT a HTML**. 

**Aspose.Slides** ofrece muchas opciones (principalmente de la clase [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export.htmloptions/)) que definen el proceso de conversión de PowerPoint a HTML:

* Convertir una presentación completa de PowerPoint a HTML.
* Convertir una diapositiva específica de una presentación de PowerPoint a HTML.
* Convertir los medios de la presentación (imágenes, videos, etc.) a HTML.
* Convertir una presentación de PowerPoint a HTML responsivo. 
* Convertir una presentación de PowerPoint a HTML con notas del ponente incluidas o excluidas. 
* Convertir una presentación de PowerPoint a HTML con comentarios incluidos o excluidos. 
* Convertir una presentación de PowerPoint a HTML con fuentes originales o incrustadas. 
* Convertir una presentación de PowerPoint a HTML utilizando el nuevo estilo CSS. 

{{% alert color="primary" %}} 

Con su propia API, Aspose desarrolló conversores gratuitos [de presentación a HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT a HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX a HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP a HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

También puede consultar otros [conversores gratuitos de Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Además de los procesos de conversión descritos aquí, Aspose.Slides también admite estas operaciones de conversión relacionadas con el formato HTML: 

* [HTML a imagen](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}


## **Convertir PowerPoint a HTML**
Usando Aspose.Slides, puede convertir una presentación completa de PowerPoint a HTML de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)  
1. Utilizar el método [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para guardar el objeto como un archivo HTML.

Este código muestra cómo convertir un PowerPoint a HTML en Python:

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

Aspose.Slides proporciona la clase [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export.responsivehtmlcontroller/) que permite generar archivos HTML responsivos. Este código muestra cómo convertir una presentación de PowerPoint a HTML responsivo en Python:

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

Este código muestra cómo convertir un PowerPoint a HTML con notas en Python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Convertir PowerPoint a HTML con fuentes originales**

Aspose.Slides proporciona la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export.embedallfontshtmlcontroller/) que permite incrustar todas las fuentes de una presentación al convertirla a HTML.

Para evitar que ciertas fuentes se incrusten, puede pasar una matriz de nombres de fuentes a un constructor parametrizado de la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export.embedallfontshtmlcontroller/). Fuentes populares, como Calibri o Arial, cuando se usan en una presentación, no necesitan incrustarse porque la mayoría de los sistemas ya las contienen. Cuando esas fuentes se incrustan, el documento HTML resultante se vuelve innecesariamente grande.

La clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export.embedallfontshtmlcontroller/) admite herencia y proporciona el método `WriteFont`, que está pensado para ser sobrescrito. 

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
Convertir una diapositiva independiente a HTML. Para ello, use el mismo método [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expuesto por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que se utiliza para convertir toda la presentación PPT(X) en un documento HTML. La clase [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export.htmloptions/) también puede usarse para establecer opciones de conversión adicionales:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```


## **Guardar CSS e imágenes al exportar a HTML**
Usando los nuevos archivos de estilo CSS, puede cambiar fácilmente el estilo del archivo HTML resultante del proceso de conversión de PowerPoint a HTML. 

El código Python en este ejemplo muestra cómo utilizar métodos sobrescribibles para crear un documento HTML personalizado con un enlace a un archivo CSS:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Enlazar todas las fuentes al convertir la presentación a HTML**
Si no desea incrustar fuentes (para evitar aumentar el tamaño del HTML resultante), puede enlazar todas las fuentes implementando su propia versión de `LinkAllFontsHtmlController`. 

Este código Python muestra cómo convertir un PowerPoint a HTML mientras se enlazan todas las fuentes y se excluyen "Calibri" y "Arial" (ya que existen en el sistema):

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Compatibilidad con la propiedad responsive de SVG**
El siguiente ejemplo de código muestra cómo exportar una presentación PPT(X) a HTML con el diseño responsive:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **Exportar archivos multimedia a un archivo HTML**
Usando Aspose.Slides para Python, puede exportar archivos multimedia de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Obtener una referencia a la diapositiva.  
1. Añadir un video a la diapositiva.  
1. Guardar la presentación como archivo HTML.

Este código Python muestra cómo agregar un video a la presentación y luego guardarla como HTML:

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

### **¿Aspose.Slides admite la conversión de diapositivas individuales de PowerPoint a HTML?**

Sí, Aspose.Slides permite convertir tanto la presentación completa como diapositivas específicas a HTML configurando `HtmlOptions` según sea necesario.

### **¿Puedo generar HTML responsivo a partir de presentaciones de PowerPoint?**

Sí, con la clase `ResponsiveHtmlController` puede exportar su presentación a un diseño HTML responsivo que se adapta a diferentes tamaños de pantalla.

### **¿Es posible incluir notas del ponente o comentarios en el HTML exportado?**

Sí, puede configurar `HtmlOptions` para incluir o excluir notas del ponente y comentarios al exportar presentaciones de PowerPoint a HTML.

### **¿Puedo incrustar fuentes al convertir una presentación a HTML?**

Sí, Aspose.Slides proporciona la clase `EmbedAllFontsHtmlController`, que permite incrustar fuentes o excluir ciertas fuentes para reducir el tamaño del archivo de salida.

### **¿La conversión de PowerPoint a HTML admite archivos multimedia como videos y audio?**

Sí, Aspose.Slides permite exportar contenido multimedia incrustado en diapositivas a HTML utilizando `VideoPlayerHtmlController` y clases de configuración relacionadas.

### **¿Qué formatos de archivo son compatibles para la conversión a HTML?**

Aspose.Slides admite la conversión de los formatos de presentación PPT, PPTX y ODP a HTML. También permite guardar contenido de diapositivas como SVG y exportar recursos multimedia.

### **¿Puedo evitar incrustar fuentes para reducir el tamaño del HTML resultante?**

Sí, puede enlazar fuentes del sistema comunes como Arial o Calibri en lugar de incrustarlas, mediante una implementación personalizada del `HtmlController`.

### **¿Existe una herramienta en línea para convertir PowerPoint a HTML?**

Sí, puede probar las herramientas web gratuitas de Aspose como [PPT a HTML](https://products.aspose.app/slides/conversion/ppt-to-html) o [PPTX a HTML](https://products.aspose.app/slides/conversion/pptx-to-html) para convertir presentaciones directamente en el navegador sin escribir código.

### **¿Puedo usar estilos CSS personalizados en el archivo HTML exportado?**

Sí, Aspose.Slides permite enlazar archivos CSS externos durante la conversión, lo que le permite personalizar completamente la apariencia del contenido HTML resultante.