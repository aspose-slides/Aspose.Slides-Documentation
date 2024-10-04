---
title: Convertir PPT a PPTX en Java
linktitle: Convertir PPT a PPTX
type: docs
weight: 20
url: /androidjava/convert-ppt-to-pptx/
keywords: "Java Convertir PPT a PPTX, PowerPoint PPT a PPTX en Java"
description: "Convertir PowerPoint PPT a PPTX en Java."
---

## **Resumen**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPT a formato PPTX utilizando Java y una aplicación en línea de conversión de PPT a PPTX. Se cubre el siguiente tema.

- Convertir PPT a PPTX en Java

## **Java Convertir PPT a PPTX**

Para obtener un código de muestra en Java para convertir PPT a PPTX, consulte la sección a continuación es decir, [Convertir PPT a PPTX](#convertir-ppt-a-pptx). Simplemente carga el archivo PPT y lo guarda en formato PPTX. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPT en muchos otros formatos como PDF, XPS, ODP, HTML, etc. como se discute en estos artículos.

- [Java Convertir PPT a PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Convertir PPT a XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Convertir PPT a HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Convertir PPT a ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Convertir PPT a Imagen](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **Acerca de la Conversión de PPT a PPTX**
Convierte el antiguo formato PPT a PPTX con la API de Aspose.Slides. Si necesita convertir miles de presentaciones PPT a formato PPTX, la mejor solución es hacerlo programáticamente. Con la API de Aspose.Slides es posible hacerlo en solo unas pocas líneas de código. La API soporta total compatibilidad para convertir presentaciones PPT a PPTX y es posible:

- Convertir estructuras complicadas de maestros, diseños y diapositivas.
- Convertir presentaciones con gráficos.
- Convertir presentaciones con formas grupales, autoformas (como rectángulos y elipses), formas con geometría personalizada.
- Convertir presentaciones que tienen estilos de llenado de texturas e imágenes para autoformas.
- Convertir presentaciones con marcadores de posición, cuadros de texto y contenedores de texto.

{{% alert color="primary" %}} 

Echa un vistazo a [**Aspose.Slides Conversión de PPT a PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Esta aplicación se basa en [**API de Aspose.Slides**](https://products.aspose.com/slides/androidjava/), por lo que puede ver un ejemplo en vivo de las capacidades básicas de conversión de PPT a PPTX. Aspose.Slides Conversion es una aplicación web, que permite soltar el archivo de presentación en formato PPT y descargarlo convertido a PPTX.

Encuentre otros ejemplos en vivo de [**Conversión de Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Convertir PPT a PPTX**
Aspose.Slides para Android a través de Java ahora facilita a los desarrolladores acceder al PPT utilizando la instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) y convertir eso al respectivo formato [PPTX](https://docs.fileformat.com/presentation/pptx/). Actualmente, admite la conversión parcial de [PPT ](https://docs.fileformat.com/presentation/ppt/)a PPTX. Para obtener más detalles sobre qué características son soportadas y no soportadas en la conversión de PPT a PPTX, por favor proceda a este enlace de documentación [link](/slides/androidjava/ppt-to-pptx-conversion/).

Aspose.Slides para Android a través de Java ofrece la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) que representa un archivo de presentación **PPTX**. La clase Presentation ahora también puede acceder a **PPT** a través de Presentation cuando el objeto está instanciado. El siguiente ejemplo muestra cómo convertir una presentación PPT en presentación PPTX.

```java
// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// Guardando la presentación PPTX en formato PPTX
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