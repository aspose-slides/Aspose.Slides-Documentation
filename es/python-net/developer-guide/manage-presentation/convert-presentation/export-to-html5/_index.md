---
title: Exportar a HTML5
type: docs
weight: 40
url: /python-net/export-to-html5/
keywords:
- PowerPoint a HTML
- diapositivas a HTML
- HTML5
- exportación a HTML
- exportar presentación
- convertir presentación
- convertir diapositivas
- Java
- Aspose.Slides para Python a través de .NET
description: "Exportar PowerPoint a HTML5 en Python"
---

{{% alert title="Info" color="info" %}}

En **Aspose.Slides 21.9**, implementamos soporte para la exportación a HTML5. Sin embargo, si prefieres exportar tu PowerPoint a HTML utilizando WebExtensions, consulta [este artículo](/slides/net/web-extensions/) en su lugar.

{{% /alert %}} 

El proceso de exportación a HTML5 aquí te permite convertir PowerPoint a HTML sin extensiones web o dependencias. De esta manera, utilizando tus propias plantillas, puedes aplicar opciones muy flexibles que definen el proceso de exportación y el HTML, CSS, JavaScript y atributos de animación resultantes.

## **Exportar PowerPoint a HTML5**

Este código en python muestra cómo exportar una presentación a HTML5 sin extensiones web y dependencias:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 

En este caso, obtienes HTML limpio.

{{% /alert %}}

Puedes querer especificar los ajustes para las animaciones de formas y las transiciones de diapositivas de esta manera:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

#### **Exportar PowerPoint a HTML**

Este código en python demuestra el proceso estándar de PowerPoint a HTML:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

En este caso, el contenido de la presentación se renderiza a través de SVG en una forma como esta:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> EL CONTENIDO DE LA DIAPOSITIVA VA AQUÍ </g>
     </svg>
</div>
</body>
```

{{% alert title="Nota" color="warning" %}} 

Cuando utilizas este método para exportar PowerPoint a HTML, debido al renderizado SVG, no podrás aplicar estilos o animar elementos específicos.

{{% /alert %}}

## **Exportar PowerPoint a HTML5 Vista Diapositiva**

**Aspose.Slides** te permite convertir una presentación de PowerPoint a un documento HTML5 en el que las diapositivas se presentan en un modo de vista de diapositiva. En este caso, cuando abres el archivo HTML5 resultante en un navegador, ves la presentación en modo de vista de diapositiva en una página web.

Este código en Python demuestra el proceso de exportación de PowerPoint a HTML5 Vista Diapositiva:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Exportar una presentación que contiene transiciones de diapositivas, animaciones y animaciones de formas a HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Guardar presentación
    pres.save("HTML5-vista-diapositiva.html", slides.export.SaveFormat.HTML5, options)
```

## Convertir una Presentación a un Documento HTML5 con Comentarios

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o comentarios sobre las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden agregar sus sugerencias o observaciones a elementos específicos de la diapositiva sin alterar el contenido principal. Cada comentario muestra el nombre del autor, lo que facilita rastrear quién dejó la observación.

Supongamos que tenemos la siguiente presentación de PowerPoint guardada en el archivo "sample.pptx".

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Cuando conviertes una presentación de PowerPoint a un documento HTML5, puedes especificar fácilmente si deseas incluir comentarios de la presentación en el documento de salida. Para hacer esto, necesitas especificar los parámetros de visualización para los comentarios en la propiedad `notes_comments_layouting` de la clase [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/).

El siguiente ejemplo de código convierte una presentación a un documento HTML5 con comentarios mostrados a la derecha de las diapositivas.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

El documento "output.html" se muestra en la imagen a continuación.

![Los comentarios en el documento HTML5 de salida](two_comments_html5.png)