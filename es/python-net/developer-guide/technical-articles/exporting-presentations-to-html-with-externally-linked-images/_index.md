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
description: "Aprenda cómo exportar presentaciones a HTML con imágenes vinculadas externamente en Aspose.Slides para Python a través de .NET, cubriendo los formatos PowerPoint y OpenDocument."
---

{{% alert color="primary" %}} 

El proceso de exportación de presentación a HTML permite especificar:

1. qué recursos se incrustan en el archivo HTML resultante, y
1. qué recursos se guardan externamente y se referencian desde el archivo HTML.

{{% /alert %}} 

## **Antecedentes**

Por defecto, la exportación a HTML incrusta todos los recursos directamente en el HTML usando codificación Base64. Esto produce un único archivo HTML autocontenible que resulta cómodo para visualizar y distribuir. Sin embargo, este enfoque tiene inconvenientes:

* El archivo resultante es significativamente más grande que los recursos originales debido al sobrecoste de Base64.
* Las imágenes incrustadas y otros activos son difíciles de actualizar o reemplazar.

## **Enfoque alternativo**

Un enfoque alternativo usando [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) elimina estas limitaciones.

La clase `LinkController` que se muestra a continuación implementa [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) y se pasa al constructor de [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller). La clase expone tres métodos que controlan cómo se incrustan o enlazan los recursos durante la exportación a HTML:

[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str): Se llama cuando el exportador encuentra un recurso y debe decidir dónde almacenarlo. Los parámetros más importantes son `id` (el identificador único del recurso para esta ejecución de exportación) y `content_type` (el tipo MIME del recurso). Devuelve [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) para enlazar el recurso, o [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) para incrustarlo.

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int): Devuelve la URL que aparecerá en el HTML resultante para el recurso identificado por `id` (opcionalmente considerando el objeto referenciador).

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes): Se llama cuando un recurso seleccionado para enlazarse necesita escribirse externamente. Como se proporcionan el identificador y el contenido (como matriz de bytes), puede persistir el recurso como desee.

A continuación se muestra la implementación en Python del `LinkController` de [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/).
```py
# [TODO[not_supported_yet]: implementación en Python de interfaces .NET]
```


Después de implementar la clase `LinkController`, puede utilizarla con la clase [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) para exportar la presentación a HTML con imágenes enlazadas externamente, como se muestra a continuación:
```py
# [TODO[not_supported_yet]: implementación en Python de interfaces .NET]
```


Asignamos `SlideImageFormat.SVG` a la propiedad `slide_image_format` para que el archivo HTML resultante contenga datos SVG que representen el contenido de la presentación.

Tipos de contenido: Si la presentación contiene mapas de bits rasterizados, entonces el código de la clase debe estar preparado para procesar tanto los tipos de contenido `image/jpeg` como `image/png`. El contenido de los mapas de bits exportados puede no coincidir con lo que estaba almacenado en la presentación. Los algoritmos internos de Aspose.Slides realizan optimización de tamaño y utilizan el códec JPEG o PNG (según cuál produzca un archivo más pequeño). Las imágenes que contienen un canal alfa (transparencia) siempre se codifican como PNG.