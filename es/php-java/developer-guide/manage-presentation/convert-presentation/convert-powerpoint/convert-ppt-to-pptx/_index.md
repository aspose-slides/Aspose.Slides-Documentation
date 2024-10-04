---
title: Convertir PPT a PPTX
linktitle: Convertir PPT a PPTX
type: docs
weight: 20
url: /es/php-java/convert-ppt-to-pptx/
keywords: "PHP Convertir PPT a PPTX, PowerPoint PPT a PPTX"
description: "Convertir PowerPoint PPT a PPTX."
---

## **Descripción general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPT a formato PPTX utilizando PHP y con una aplicación en línea de conversión de PPT a PPTX. Se cubre el siguiente tema.

- Convertir PPT a PPTX

## **Java Convertir PPT a PPTX**

Para obtener un código de muestra en Java para convertir PPT a PPTX, consulte la sección a continuación i.e. [Convertir PPT a PPTX](#convert-ppt-to-pptx). Simplemente carga el archivo PPT y lo guarda en formato PPTX. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPT en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos.

- [Java Convertir PPT a PDF](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java Convertir PPT a XPS](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java Convertir PPT a HTML](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java Convertir PPT a ODP](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java Convertir PPT a Imagen](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **Acerca de la conversión de PPT a PPTX**
Convierta el antiguo formato PPT a PPTX con la API de Aspose.Slides. Si necesita convertir miles de presentaciones PPT a formato PPTX, la mejor solución es hacerlo de forma programática. Con la API de Aspose.Slides es posible hacerlo en solo unas pocas líneas de código. La API soporta la compatibilidad total para convertir presentaciones PPT a PPTX y es posible:

- Convertir estructuras complicadas de maestros, diseños y diapositivas.
- Convertir presentaciones con gráficos.
- Convertir presentaciones con formas agrupadas, formas automáticas (como rectángulos y elipses), formas con geometría personalizada.
- Convertir presentaciones que tienen estilos de relleno de texturas e imágenes para formas automáticas.
- Convertir presentaciones con marcadores de posición, marcos de texto y contenedores de texto.

{{% alert color="primary" %}} 

Eche un vistazo a la aplicación [**Conversión PPT a PPTX de Aspose.Slides**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Esta aplicación está construida sobre la [**API de Aspose.Slides**](https://products.aspose.com/slides/php-java/), por lo que puede ver un ejemplo en vivo de las capacidades básicas de conversión de PPT a PPTX. La conversión de Aspose.Slides es una aplicación web que permite arrastrar un archivo de presentación en formato PPT y descargarlo convertido a PPTX.

Encuentre otros ejemplos en vivo de [**Conversión de Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Convertir PPT a PPTX**
Aspose.Slides para PHP a través de Java ahora facilita a los desarrolladores acceder al PPT utilizando la instancia de clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y convirtiéndolo al respectivo formato [PPTX](https://docs.fileformat.com/presentation/pptx/). Actualmente, admite la conversión parcial de [PPT](https://docs.fileformat.com/presentation/ppt/) a PPTX. Para más detalles sobre qué características son compatibles y no compatibles en la conversión de PPT a PPTX, consulte esta documentación [enlace](/slides/es/php-java/ppt-to-pptx-conversion/).

Aspose.Slides para PHP a través de Java ofrece la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) que representa un archivo de presentación **PPTX**. La clase Presentation también puede acceder a **PPT** a través de Presentation cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una presentación PPT en una presentación PPTX.

```php
  # Instanciar un objeto Presentation que representa un archivo PPTX
  $pres = new Presentation("Aspose.ppt");
  try {
    # Guardar la presentación PPTX en formato PPTX
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figura: Presentación PPT fuente**|

El fragmento de código anterior generó la siguiente presentación PPTX después de la conversión

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figura: Presentación PPTX generada después de la conversión**|