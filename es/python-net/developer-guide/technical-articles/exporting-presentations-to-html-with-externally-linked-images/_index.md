---
title: Exportando Presentaciones a HTML con Imágenes Enlazadas Externamente
type: docs
weight: 100
url: /es/python-net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

Este artículo describe una técnica avanzada que permite controlar qué recursos se incrustan en el archivo HTML resultante y cuáles se guardan externamente y se referencian desde el archivo HTML.

{{% /alert %}} 
## **Antecedentes**
El comportamiento predeterminado de exportación a HTML es incrustar cualquier recurso en el archivo HTML. Este enfoque resulta en un solo archivo HTML que es fácil de ver y distribuir. Todos los recursos necesarios están codificados en base64. Pero este enfoque tiene dos desventajas:

- El tamaño de salida es significativamente mayor debido a la codificación base64. Es difícil reemplazar las imágenes contenidas en el archivo.

En este artículo veremos cómo podemos cambiar el comportamiento predeterminado utilizando **Aspose.Slides para Python a través de .NET** para enlazar las imágenes externamente en lugar de incrustarlas en el archivo HTML. Usaremos la interfaz **ILinkEmbedController**, que contiene tres métodos para controlar el proceso de incrustación y almacenamiento de recursos. Podemos pasar esta interfaz al constructor de la clase HtmlOptions al preparar la exportación.

A continuación se muestra el código completo de la clase **LinkController**, que implementa la interfaz **ILinkEmbedController**. Como se mencionó anteriormente, el LinkController debe implementar la interfaz ILinkEmbedController. Esta interfaz especifica tres métodos:

- **public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)** Se llama cuando el exportador encuentra un recurso y necesita decidir cómo almacenarlo. Los parámetros más importantes son ‘id’ – el identificador único del recurso para toda la operación de exportación y ‘contentType’ – contiene el tipo MIME del recurso. Si decidimos enlazar el recurso, debemos retornar LinkEmbedDecision.Link desde este método. De lo contrario, se debe retornar LinkEmbedDecision.Embed para incrustar el recurso.
- **public string GetUrl(int id, int referrer)** 
  Se llama para obtener la URL del recurso en la forma en que se utiliza en el archivo resultante, digamos para una etiqueta <img src="%method_result_here%">. El recurso está identificado por ‘id’.
- **public void SaveExternal(int id, byte[] entityData)** 
  El método final de la secuencia, se llama cuando se trata de almacenar el recurso externamente. Tenemos el identificador del recurso y el contenido del recurso como un arreglo de bytes. Depende de nosotros qué hacer con los datos del recurso proporcionados.

```py
# [TODO[not_supported_yet]: implementación en python de interfaces .net]
```

Después de escribir la clase **LinkController**, ahora la usaremos con la clase **HTMLOptions** para exportar la presentación a HTML con imágenes enlazadas externamente utilizando el siguiente código.

```py
# [TODO[not_supported_yet]: implementación en python de interfaces .net]
```

Asignamos **SlideImageFormat.Svg** a la propiedad **SlideImageFormat**, lo que significa que el archivo HTML resultante contendrá datos SVG para dibujar el contenido de la presentación.

En cuanto a los tipos de contenido, depende de los datos de imagen reales contenidos en la presentación. Si hay bitmaps rasterizados en la presentación, entonces el código de la clase debe estar preparado para procesar ambos tipos de contenido ‘image/jpeg’ y ‘image/png’. El tipo de contenido real de las imágenes de bitmap rasterizadas exportadas puede no coincidir con el de las imágenes almacenadas en la presentación. Los algoritmos internos de Aspose.Slides realizan optimización de tamaño y utilizan el códec JPG o PNG que genere un tamaño de datos más pequeño. Las imágenes que contienen canal alfa (transparencia) siempre se codifican en PNG.