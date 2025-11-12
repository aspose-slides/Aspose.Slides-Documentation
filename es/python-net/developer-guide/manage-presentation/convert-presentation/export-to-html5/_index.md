---
title: Convertir presentaciones a HTML5 en Python
linktitle: Exportar a HTML5
type: docs
weight: 40
url: /es/python-net/export-to-html5/
keywords:
- PowerPoint a HTML5
- OpenDocument a HTML5
- presentación a HTML5
- diapositiva a HTML5
- PPT a HTML5
- PPTX a HTML5
- ODP a HTML5
- convertir PowerPoint
- convertir OpenDocument
- convertir presentación
- convertir diapositiva
- exportación HTML5
- exportar presentación
- exportar diapositiva
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Exporta presentaciones de PowerPoint y OpenDocument a HTML5 responsivo con Aspose.Slides para Python a través de .NET. Conserva el formato, animaciones e interactividad."
---

{{% alert title="Info" color="info" %}}
En **Aspose.Slides 21.9**, implementamos soporte para la exportación a HTML5. Sin embargo, si prefieres exportar tu PowerPoint a HTML usando WebExtensions, consulta [este artículo](/slides/es/net/web-extensions/) en su lugar. 
{{% /alert %}} 

El proceso de exportación a HTML5 aquí te permite convertir PowerPoint a HTML sin extensiones web ni dependencias. De esta forma, usando tus propias plantillas, puedes aplicar opciones muy flexibles que definen el proceso de exportación y el HTML, CSS, JavaScript y atributos de animación resultantes. 

## **Exportar PowerPoint a HTML5**

Este código Python muestra cómo exportar una presentación a HTML5 sin extensiones web ni dependencias:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
En este caso, obtienes HTML limpio. 
{{% /alert %}}

Puedes especificar la configuración para animaciones de formas y transiciones de diapositivas de esta manera:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **Exportar PowerPoint a HTML**

Este código Python demuestra el proceso estándar de PowerPoint a HTML:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

En este caso, el contenido de la presentación se renderiza mediante SVG en una forma como esta:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
Cuando utilizas este método para exportar PowerPoint a HTML, debido a la renderización SVG, no podrás aplicar estilos ni animar elementos específicos. 
{{% /alert %}}

## **Exportar PowerPoint a Vista de Diapositivas HTML5**

**Aspose.Slides** permite convertir una presentación de PowerPoint a un documento HTML5 en el que las diapositivas se presentan en modo vista de diapositiva. En este caso, al abrir el archivo HTML5 resultante en un navegador, verás la presentación en modo vista de diapositiva en una página web. 

Este código Python demuestra el proceso de exportación de PowerPoint a Vista de Diapositivas HTML5:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Exportar una presentación que contiene transiciones de diapositivas, animaciones y animaciones de formas a HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Save presentation
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Convertir una presentación a un documento HTML5 con comentarios**

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o comentarios en las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden añadir sus sugerencias u observaciones a elementos específicos de la diapositiva sin modificar el contenido principal. Cada comentario muestra el nombre del autor, facilitando rastrear quién dejó la observación.

Supongamos que tenemos la siguiente presentación de PowerPoint guardada en el archivo "sample.pptx".

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Al convertir una presentación de PowerPoint a un documento HTML5, puedes especificar fácilmente si incluir los comentarios de la presentación en el documento de salida. Para ello, debes especificar los parámetros de visualización de los comentarios en la propiedad `notes_comments_layouting` de la clase [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/).

El siguiente ejemplo de código convierte una presentación a un documento HTML5 con los comentarios mostrados a la derecha de las diapositivas.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

El documento "output.html" se muestra en la imagen a continuación.

![Los comentarios en el documento HTML5 de salida](two_comments_html5.png)

## **Preguntas frecuentes**

**¿Puedo controlar si las animaciones de objetos y las transiciones de diapositivas se reproducirán en HTML5?**

Sí, HTML5 ofrece opciones separadas para habilitar o deshabilitar [animaciones de formas](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) y [transiciones de diapositivas](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**¿Se admite la salida de comentarios y dónde pueden ubicarse respecto a la diapositiva?**

Sí, los comentarios pueden añadirse en HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) mediante [configuraciones de diseño](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/notes_comments_layouting/) para notas y comentarios.

**¿Puedo omitir enlaces que invoquen JavaScript por razones de seguridad o CSP?**

Sí, existe una [configuración](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) que permite omitir hipervínculos con llamadas a JavaScript durante el guardado. Esto ayuda a cumplir con políticas de seguridad estrictas.