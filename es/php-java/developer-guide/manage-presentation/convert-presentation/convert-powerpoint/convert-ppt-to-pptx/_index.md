---
title: Convertir PPT a PPTX en PHP
linktitle: PPT a PPTX
type: docs
weight: 20
url: /es/php-java/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- PPT a PPTX
- guardar PPT como PPTX
- exportar PPT a PPTX
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Convierte presentaciones PPT heredadas a PPTX modernas rápidamente con Aspose.Slides para PHP mediante Java — tutorial claro, ejemplos de código gratuitos, sin dependencia de Microsoft Office."
---

## **Descripción general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPT a formato PPTX usando PHP y una aplicación en línea de conversión PPT a PPTX. Se cubre el siguiente tema.

- Convertir PPT a PPTX

## **Convertir PPT a PPTX en PHP**

Para el código de muestra Java para convertir PPT a PPTX, consulte la sección a continuación, es decir, [Convertir PPT a PPTX](#convert-ppt-to-pptx). Simplemente carga el archivo PPT y lo guarda en formato PPTX. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPT en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos.

- [Java Convertir PPT a PDF](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java Convertir PPT a XPS](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java Convertir PPT a HTML](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java Convertir PPT a ODP](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java Convertir PPT a Imagen](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **Acerca de la conversión de PPT a PPTX**

Convierta el formato PPT antiguo a PPTX con Aspose.Slides API. Si necesita convertir miles de presentaciones PPT a formato PPTX, la mejor solución es hacerlo programáticamente. Con Aspose.Slides API es posible hacerlo en solo unas pocas líneas de código. La API admite plena compatibilidad para convertir presentaciones PPT a PPTX y permite:

- Convertir estructuras complicadas de maestros, diseños y diapositivas.
- Convertir presentaciones con gráficos.
- Convertir presentaciones con formas agrupadas, autoformas (como rectángulos y elipses), formas con geometría personalizada.
- Convertir presentaciones que tengan texturas y estilos de relleno de imágenes para autoformas.
- Convertir presentaciones con marcadores de posición, marcos de texto y contenedores de texto.

{{% alert color="primary" %}} 

Echa un vistazo a [**Aspose.Slides PPT a PPTX Conversión**](https://products.aspose.app/slides/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Esta aplicación está basada en [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/), por lo que puede ver un ejemplo vivo de las capacidades básicas de conversión de PPT a PPTX. Aspose.Slides Conversion es una aplicación web, que permite arrastrar un archivo de presentación en formato PPT y descargarlo convertido a PPTX.

Encuentre otros ejemplos en vivo de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Convertir PPT a PPTX**

Aspose.Slides for PHP via Java ahora facilita a los desarrolladores acceder al PPT usando la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y convertirla al formato [PPTX](https://docs.fileformat.com/presentation/pptx/). Actualmente, soporta conversión parcial de [PPT](https://docs.fileformat.com/presentation/ppt/) a PPTX. Para obtener más detalles sobre qué características son compatibles e incompatibles en la conversión de PPT a PPTX, continúe a esta documentación [enlace](/slides/es/php-java/ppt-to-pptx-conversion/).

Aspose.Slides for PHP via Java ofrece la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) que representa un archivo de presentación **PPTX**. La clase Presentation ahora también puede acceder a **PPT** cuando el objeto se instancia. El siguiente ejemplo muestra cómo convertir una presentación PPT en una presentación PPTX.
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
|**Figura : Presentación PPT de origen**|

El fragmento de código anterior genera la siguiente presentación PPTX después de la conversión

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figura: Presentación PPTX generada después de la conversión**|

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre los formatos PPT y PPTX?**

PPT es el formato binario antiguo utilizado por Microsoft PowerPoint, mientras que PPTX es el formato basado en XML introducido con Microsoft Office 2007. Los archivos PPTX ofrecen mejor rendimiento, tamaño de archivo reducido y recuperación de datos mejorada.

**¿Aspose.Slides admite la conversión por lotes de varios archivos PPT a PPTX?**

Sí, puede usar Aspose.Slides en un bucle para convertir múltiples archivos PPT a PPTX programáticamente, lo que lo hace adecuado para escenarios de conversión por lotes.

**¿Se conservará el contenido y el formato después de la conversión?**

Aspose.Slides mantiene alta fidelidad al convertir presentaciones. Los diseños de diapositivas, animaciones, formas, gráficos y otros elementos de diseño se conservan durante la conversión de PPT a PPTX.

**¿Puedo convertir otros formatos como PDF o HTML a partir de archivos PPT?**

Sí, Aspose.Slides admite la conversión de archivos PPT a [múltiples formatos](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/), incluidos PDF, XPS, HTML, ODP y formatos de imagen como PNG y JPEG.

**¿Es posible convertir PPT a PPTX sin tener Microsoft PowerPoint instalado?**

Sí, Aspose.Slides es una API independiente y no requiere Microsoft PowerPoint ni ningún software de terceros para realizar la conversión.

**¿Existe una herramienta en línea disponible para la conversión de PPT a PPTX?**

Sí, puede usar la aplicación web gratuita [Aspose.Slides PPT a PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) para realizar la conversión directamente en su navegador sin escribir código.