---
title: Convertir PPT a PPTX en Android
linktitle: PPT a PPTX
type: docs
weight: 20
url: /es/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Convierte presentaciones PPT heredadas a PPTX modernos rápidamente en Java con Aspose.Slides para Android — tutorial claro, ejemplos de código gratuitos, sin dependencia de Microsoft Office."
---

## **Visión general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPT a formato PPTX utilizando Java y una aplicación en línea de conversión de PPT a PPTX. Los temas siguientes se cubren.

- Convertir PPT a PPTX en Java

## **Convertir PPT a PPTX en Android**

Para obtener un ejemplo de código Java que convierta PPT a PPTX, consulte la sección a continuación, es decir, [Convertir PPT a PPTX](#convert-ppt-to-pptx). Simplemente carga el archivo PPT y lo guarda en formato PPTX. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPT en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos.

- [Convertir PPT a PDF en Android](/slides/es/androidjava/convert-powerpoint-to-pdf/)
- [Convertir PPT a XPS en Android](/slides/es/androidjava/convert-powerpoint-to-xps/)
- [Convertir PPT a HTML en Android](/slides/es/androidjava/convert-powerpoint-to-html/)
- [Convertir PPT a ODP en Android](/slides/es/androidjava/save-presentation/)
- [Convertir PPT a PNG en Android](/slides/es/androidjava/convert-powerpoint-to-png/)

## **Acerca de la conversión de PPT a PPTX**
Convierta el antiguo formato PPT a PPTX con Aspose.Slides API. Si necesita convertir miles de presentaciones PPT a formato PPTX, la mejor solución es hacerlo de forma programática. Con Aspose.Slides API es posible hacerlo en solo unas pocas líneas de código. La API ofrece compatibilidad total para convertir presentaciones PPT a PPTX y permite:

- Convertir estructuras complejas de maestros, diseños y diapositivas.
- Convertir presentaciones con gráficos.
- Convertir presentaciones con formas agrupadas, autoformas (como rectángulos y elipses), formas con geometría personalizada.
- Convertir presentaciones que tengan texturas y estilos de relleno de imágenes para autoformas.
- Convertir presentaciones con marcadores de posición, marcos de texto y contenedores de texto.

{{% alert color="primary" %}} 

Échele un vistazo a la aplicación [**Conversión de PPT a PPTX de Aspose.Slides**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Esta aplicación está construida sobre la [**API de Aspose.Slides**](https://products.aspose.com/slides/androidjava/), por lo que podrá ver un ejemplo en funcionamiento de las capacidades básicas de conversión de PPT a PPTX. Aspose.Slides Conversion es una aplicación web que permite arrastrar un archivo de presentación en formato PPT y descargarlo convertido a PPTX.

Encuentre otros ejemplos en vivo de [**Conversión de Aspose.Slides**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Convertir PPT a PPTX**
Aspose.Slides para Android mediante Java ahora facilita a los desarrolladores acceder al PPT mediante la instancia de clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) y convertirlo al formato [PPTX](https://docs.fileformat.com/presentation/pptx/). Actualmente, admite la conversión parcial de [PPT](https://docs.fileformat.com/presentation/ppt/) a PPTX.

Aspose.Slides para Android mediante Java ofrece la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) que representa un archivo de presentación **PPTX**. La clase Presentation ahora también puede acceder a **PPT** a través de Presentation cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una presentación PPT en una presentación PPTX.
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
|**Figura: Presentación PPT de origen**|

El fragmento de código anterior generó la siguiente presentación PPTX tras la conversión

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figura: Presentación PPTX generada tras la conversión**|

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre los formatos PPT y PPTX?**

PPT es el formato binario más antiguo utilizado por Microsoft PowerPoint, mientras que PPTX es el formato más reciente basado en XML introducido con Microsoft Office 2007. Los archivos PPTX ofrecen mejor rendimiento, tamaño de archivo reducido y una recuperación de datos mejorada.

**¿Aspose.Slides admite la conversión por lotes de varios archivos PPT a PPTX?**

Sí, puede usar Aspose.Slides en un bucle para convertir múltiples archivos PPT a PPTX de forma programática, lo que lo hace adecuado para escenarios de conversión por lotes.

**¿Se conservará el contenido y el formato después de la conversión?**

Aspose.Slides mantiene una alta fidelidad al convertir presentaciones. Los diseños de diapositivas, animaciones, formas, gráficos y otros elementos de diseño se conservan durante la conversión de PPT a PPTX.

**¿Puedo convertir otros formatos, como PDF o HTML, a partir de archivos PPT?**

Sí, Aspose.Slides admite la conversión de archivos PPT a [múltiples formatos](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/), incluidos PDF, XPS, HTML, ODP y formatos de imagen como PNG y JPEG.

**¿Es posible convertir PPT a PPTX sin tener Microsoft PowerPoint instalado?**

Sí, Aspose.Slides es una API independiente y no requiere Microsoft PowerPoint ni ningún software de terceros para realizar la conversión.

**¿Existe una herramienta en línea disponible para la conversión de PPT a PPTX?**

Sí, puede utilizar la aplicación web gratuita [Conversor de PPT a PPTX de Aspose.Slides](https://products.aspose.app/slides/conversion/ppt-to-pptx) para realizar la conversión directamente en su navegador sin escribir código.