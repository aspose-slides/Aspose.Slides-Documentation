---
title: Exportar presentaciones a HTML con imágenes vinculadas externamente en Python
linktitle: Exportar presentaciones a HTML con imágenes vinculadas externamente
type: docs
weight: 100
url: /es/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar presentación
- exportar diapositiva
- exportar PPT
- exportar PPTX
- exportar ODP
- PowerPoint a HTML
- OpenDocument a HTML
- presentación a HTML
- diapositiva a HTML
- PPT a HTML
- PPTX a HTML
- ODP a HTML
- imagen vinculada
- imagen vinculada externamente
- Python
- Aspose.Slides
description: "Aprenda cómo exportar presentaciones a HTML con imágenes vinculadas externamente en Aspose.Slides para Python mediante .NET, abarcando los formatos PowerPoint y OpenDocument."
---

{{% alert color="primary" %}} 

El proceso de exportación de presentación a HTML le permite especificar:

1. qué recursos se incrustan en el archivo HTML resultante, y
1. qué recursos se guardan externamente y se referencian desde el archivo HTML.

{{% /alert %}} 

## **Antecedentes**

Por defecto, la exportación a HTML incrusta todos los recursos directamente en el HTML usando codificación Base64. Esto produce un único archivo HTML autocontenible que resulta práctico para visualizar y distribuir. Sin embargo, este enfoque tiene desventajas:

* El archivo resultante es significativamente más grande que los recursos originales debido al sobrecoste del Base64.
* Las imágenes incrustadas y otros recursos son difíciles de actualizar o reemplazar.

## **Enfoque alternativo**

Un enfoque alternativo que utiliza [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) evita estas limitaciones.

La clase `LinkController` a continuación implementa [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) y se pasa al constructor de [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller). La clase expone tres métodos que controlan cómo se incrustan o enlazan los recursos durante la exportación a HTML:

[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str): Se llama cuando el exportador encuentra un recurso y debe decidir dónde almacenarlo. Los parámetros más importantes son `id` (el identificador único del recurso para esta ejecución de exportación) y `content_type` (el tipo MIME del recurso). Devuelva [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) para enlazar el recurso, o [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) para incrustarlo.

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int): Devuelve la URL que aparecerá en el HTML resultante para el recurso identificado por `id` (opcionalmente considerando el objeto referenciador).

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes): Se llama cuando un recurso seleccionado para enlazar necesita ser escrito externamente. Dado que el identificador y el contenido se proporcionan (como una matriz de bytes), puede almacenar el recurso como desee.

A continuación se muestra la implementación en Python de `LinkController` de [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/).
```py
# [TODO[not_supported_yet]: implementación en python de interfaces .NET]
```


Después de implementar la clase `LinkController`, puede usarla con la clase [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/htmloptions/) para exportar la presentación a HTML con imágenes enlazadas externamente, como se muestra a continuación:
```py
# [TODO[not_supported_yet]: implementación de interfaces .NET en python]
```


Asignamos `SlideImageFormat.SVG` a la propiedad `slide_image_format` para que el archivo HTML resultante contenga datos SVG que representen el contenido de la presentación.

Tipos de contenido: Si la presentación contiene mapas de bits rasterizados, el código de la clase debe estar preparado para procesar tanto los tipos de contenido `image/jpeg` como `image/png`. El contenido de las imágenes de mapa de bits exportadas puede no coincidir con lo que se almacenó en la presentación. Los algoritmos internos de Aspose.Slides realizan una optimización de tamaño y usan el códec JPEG o PNG (según cuál produzca un archivo más pequeño). Las imágenes que contienen un canal alfa (transparencia) siempre se codifican como PNG.