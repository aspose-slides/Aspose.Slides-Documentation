---
title: Convertir presentaciones a HTML5 en Python
linktitle: Presentación a HTML5
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
- guardar PPT como HTML5
- guardar PPTX como HTML5
- guardar ODP como HTML5
- exportar PPT a HTML5
- exportar PPTX a HTML5
- exportar ODP a HTML5
- Python
- Aspose.Slides
description: "Exportar presentaciones PowerPoint y OpenDocument a HTML5 responsivo con Aspose.Slides para Python mediante .NET. Conservar el formato, animaciones e interactividad."
---
## **Visión general**

Este artículo explica cómo convertir presentaciones de PowerPoint a HTML5 usando Aspose.Slides para Python mediante .NET. Cubre la exportación básica, el control de animaciones de formas y transiciones de diapositivas, y el diseño de comentarios. Además, compara la salida HTML5 con la salida basada en SVG de la exportación HTML estándar.

## **Exportar PowerPoint a HTML5**

El siguiente ejemplo carga una presentación desde el directorio de trabajo y la guarda en formato HTML5. Utiliza la configuración de exportación predeterminada; el siguiente ejemplo muestra cómo controlar la reproducción de animaciones de forma explícita. Reemplace la ruta de entrada con la ruta a su presentación.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
Además del documento HTML, la exportación escribe archivos CSS y JavaScript de soporte para el estilo de diapositivas, animaciones, efectos y navegación. Mantenga estos archivos junto al documento HTML al mover o publicar la salida. La página generada también carga jQuery y Anime.js desde CDNs públicos; sin ellos, la navegación de diapositivas y las animaciones no se ejecutan.
{{% /alert %}}

Para exportar sin reproducir animaciones de formas o transiciones de diapositivas, establezca [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) y [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) en `False` en [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Estas configuraciones son independientes, por lo que puede habilitar una mientras deshabilita la otra. El ejemplo exporta la presentación con ambos tipos de animación desactivados en la página generada.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Exportar PowerPoint a HTML**

La exportación estándar a HTML utiliza un enfoque de renderizado diferente: el contenido de la diapositiva se representa mediante SVG dentro de una página HTML. El siguiente ejemplo convierte una presentación a un documento HTML usando este enfoque de renderizado.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

El marcado simplificado a continuación ilustra la estructura de la página generada. El elemento SVG contiene el contenido de la diapositiva renderizado; el texto de marcador de posición representa ese contenido y no es la salida literal de la exportación.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
La exportación basada en SVG no expone las formas de PowerPoint como elementos HTML individuales. Utilice la exportación a HTML5 cuando necesite las opciones de animación de formas y transición de diapositivas demostradas en este artículo.
{{% /alert %}}

## **Exportar PowerPoint a Vista de diapositivas HTML5**

La exportación a HTML5 genera una página para visualizar y navegar por las diapositivas de la presentación en un navegador. Este ejemplo habilita tanto [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) como [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) para que la vista de diapositivas exportada pueda reproducir los efectos de la presentación original.

Utilice una presentación que ya contenga animaciones de formas y transiciones de diapositivas para ver el efecto de estas configuraciones. Habilitarlas no añade nuevos efectos a diapositivas que no los tengan. Después de la exportación, abra el documento HTML5 generado en un navegador con sus archivos de soporte disponibles.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Convertir una presentación a un documento HTML5 con comentarios**

Puede incluir los comentarios de diapositiva existentes en la salida HTML5 para que los lectores vean la retroalimentación junto al contenido de la diapositiva. El ejemplo en esta sección asume que la presentación de origen contiene comentarios, como se muestra a continuación. Exporta esos comentarios; no crea nuevos.

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Asigne un objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) a la propiedad [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) de [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Establezca [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) en `RIGHT` de la enumeración [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) para colocar los comentarios a la derecha de cada diapositiva.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

El siguiente ejemplo exporta la presentación a HTML5 con este diseño de comentarios. Una presentación sin comentarios no tendrá texto de comentario para mostrar.

La imagen a continuación muestra el documento HTML5 exportado con los comentarios mostrados junto a la diapositiva.

![Los comentarios en el documento HTML5 de salida](two_comments_html5.png)

## **Excluir hipervínculos JavaScript durante la exportación**

Suponga que `hyperlinks.pptx` contiene texto enlazado con un objetivo `javascript:alert('Hello')` y un enlace ordinario `https://example.com/`. Para excluir el hipervínculo JavaScript durante la exportación, establezca [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) en `True`. El valor predeterminado es `False`, por lo que estos enlaces no se filtran a menos que habilite la opción.

El siguiente ejemplo carga la presentación desde el directorio de trabajo y la exporta usando [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

El archivo exportado omite el hipervínculo JavaScript mientras conserva su texto y el enlace HTTPS ordinario. La presentación de origen permanece sin cambios.

Esta opción filtra los hipervínculos JavaScript; no elimina todos los scripts u otro contenido activo, ni garantiza el cumplimiento de CSP. Por ejemplo, la salida HTML5 sigue incluyendo scripts para la navegación de diapositivas y animaciones.

## **Preguntas frecuentes**

**¿Puedo controlar si las animaciones de objetos y las transiciones de diapositivas se reproducirán en HTML5?**

Sí, la exportación a HTML5 proporciona opciones independientes para habilitar o deshabilitar [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) y [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**¿Se admiten los comentarios y dónde pueden ubicarse respecto a la diapositiva?**

Sí, los comentarios existentes pueden incluirse en la salida HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) mediante [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) para notas y comentarios.

**¿Puedo omitir enlaces que invocan JavaScript por motivos de seguridad o CSP?**

Sí, la configuración [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) permite omitir los hipervínculos con llamadas a JavaScript durante el guardado. El valor predeterminado es `False`. Consulte [Exclude JavaScript Hyperlinks During Export](/slides/es/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) para un ejemplo de exportación a HTML5 y el alcance del filtro. Esta configuración no elimina el JavaScript usado por el visor HTML5 para la navegación y las animaciones.