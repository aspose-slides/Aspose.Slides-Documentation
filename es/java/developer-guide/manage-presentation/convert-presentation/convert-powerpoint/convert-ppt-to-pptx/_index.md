---
title: Convertir PPT a PPTX en Java
linktitle: PPT a PPTX
type: docs
weight: 20
url: /es/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Convierte presentaciones PPT heredadas a PPTX modernas rápidamente en Java con Aspose.Slides — tutorial claro, ejemplos de código gratuitos, sin dependencia de Microsoft Office."
---

## **Visión general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPT a formato PPTX usando Java y con la aplicación en línea de conversión de PPT a PPTX. Se cubre el siguiente tema.

- Convertir PPT a PPTX en Java

## **Convertir PPT a PPTX en Java**

Para obtener código de ejemplo en Java que convierta PPT a PPTX, consulte la sección a continuación, es decir, [Convert PPT to PPTX](#convert-ppt-to-pptx). Simplemente carga el archivo PPT y lo guarda en formato PPTX. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPT en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos.

- [Convertir PPT a PDF con Java](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Convertir PPT a XPS con Java](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Convertir PPT a HTML con Java](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Convertir PPT a ODP con Java](https://docs.aspose.com/slides/java/save-presentation/)
- [Convertir PPT a Imagen con Java](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **Acerca de la conversión de PPT a PPTX**
Convertir el formato PPT antiguo a PPTX con Aspose.Slides API. Si necesita convertir miles de presentaciones PPT a formato PPTX, la mejor solución es hacerlo programáticamente. Con Aspose.Slides API es posible hacerlo en solo unas pocas líneas de código. La API admite compatibilidad total para convertir presentaciones PPT a PPTX y es posible:

- Convertir estructuras complejas de maestros, diseños y diapositivas.
- Convertir presentaciones con gráficos.
- Convertir presentaciones con formas agrupadas, autoformas (como rectángulos y elipses), formas con geometría personalizada.
- Convertir presentaciones con texturas y estilos de relleno de imágenes para autoformas.
- Convertir presentaciones con marcadores de posición, marcos de texto y contenedores de texto.

{{% alert color="primary" %}} 

Eche un vistazo a la aplicación [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Esta aplicación está construida sobre [**Aspose.Slides API**](https://products.aspose.com/slides/java/), por lo que puede ver un ejemplo en vivo de las capacidades básicas de conversión de PPT a PPTX. Aspose.Slides Conversion es una aplicación web que permite arrastrar un archivo de presentación en formato PPT y descargarlo convertido a PPTX.

Encuentre otros ejemplos en vivo de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .
{{% /alert %}} 

## **Convertir PPT a PPTX**
Aspose.Slides para Java ahora facilita a los desarrolladores acceder al PPT mediante la instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y convertirlo al formato [PPTX](https://docs.fileformat.com/presentation/pptx/). Actualmente, admite la conversión parcial de [PPT ](https://docs.fileformat.com/presentation/ppt/) a PPTX. Para obtener más detalles sobre qué funciones son compatibles e incompatibles en la conversión de PPT a PPTX, consulte esta documentación [link](/slides/es/java/ppt-to-pptx-conversion/).

Aspose.Slides para Java ofrece la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) que representa un archivo de presentación **PPTX**. La clase Presentation ahora también puede acceder a **PPT** a través de Presentation cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una presentación PPT en una presentación PPTX.
```java
// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// Guardar la presentación PPTX en formato PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figura : Presentación PPT de origen**|

El fragmento de código anterior generó la siguiente presentación PPTX después de la conversión

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figura: Presentación PPTX generada después de la conversión**|

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre los formatos PPT y PPTX?**

PPT es el formato de archivo binario más antiguo usado por Microsoft PowerPoint, mientras que PPTX es el formato basado en XML introducido con Microsoft Office 2007. Los archivos PPTX ofrecen mejor rendimiento, tamaño de archivo reducido y recuperación de datos mejorada.

**¿Aspose.Slides admite la conversión por lotes de varios archivos PPT a PPTX?**

Sí, puede usar Aspose.Slides en un bucle para convertir múltiples archivos PPT a PPTX programáticamente, lo que lo hace adecuado para escenarios de conversión por lotes.

**¿Se conservarán el contenido y el formato después de la conversión?**

Aspose.Slides mantiene alta fidelidad al convertir presentaciones. Los diseños de diapositivas, animaciones, formas, gráficos y otros elementos de diseño se conservan durante la conversión de PPT a PPTX.

**¿Puedo convertir otros formatos como PDF o HTML a partir de archivos PPT?**

Sí, Aspose.Slides admite la conversión de archivos PPT a [múltiples formatos](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/), incluidos PDF, XPS, HTML, ODP y formatos de imagen como PNG y JPEG.

**¿Es posible convertir PPT a PPTX sin que Microsoft PowerPoint esté instalado?**

Sí, Aspose.Slides es una API independiente y no requiere Microsoft PowerPoint ni ningún software de terceros para realizar la conversión.

**¿Existe una herramienta en línea disponible para la conversión de PPT a PPTX?**

Sí, puede usar la aplicación web gratuita [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) para realizar la conversión directamente en su navegador sin escribir código.