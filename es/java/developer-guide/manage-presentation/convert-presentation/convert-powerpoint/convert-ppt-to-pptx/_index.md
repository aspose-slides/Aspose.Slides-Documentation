---
title: Convertir PPT a PPTX en Java
linktitle: Convertir PPT a PPTX
type: docs
weight: 20
url: /java/convert-ppt-to-pptx/
keywords: "Java Convertir PPT a PPTX, PowerPoint PPT a PPTX en Java"
description: "Convertir PowerPoint PPT a PPTX en Java."
---

## **Descripción general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPT a formato PPTX utilizando Java y una aplicación en línea de conversión de PPT a PPTX. Se cubre el siguiente tema.

- Convertir PPT a PPTX en Java

## **Java Convertir PPT a PPTX**

Para obtener un ejemplo de código en Java para convertir PPT a PPTX, consulte la sección a continuación es decir, [Convertir PPT a PPTX](#convertir-ppt-a-pptx). Solo carga el archivo PPT y lo guarda en formato PPTX. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPT en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos.

- [Java Convertir PPT a PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java Convertir PPT a XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java Convertir PPT a HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java Convertir PPT a ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java Convertir PPT a Imagen](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **Acerca de la conversión de PPT a PPTX**
Convierte el antiguo formato PPT a PPTX con la API de Aspose.Slides. Si necesita convertir miles de presentaciones PPT a formato PPTX, la mejor solución es hacerlo de forma programática. Con la API de Aspose.Slides es posible hacerlo en solo unas pocas líneas de código. La API admite total compatibilidad para convertir presentaciones PPT a PPTX y es posible:

- Convertir estructuras complicadas de maestros, diseños y diapositivas.
- Convertir presentaciones con gráficos.
- Convertir presentaciones con formas grupales, formas automáticas (como rectángulos y elipses), formas con geometría personalizada.
- Convertir presentaciones, con estilos de relleno de texturas y imágenes para formas automáticas.
- Convertir presentaciones que tengan marcadores de posición, marcos de texto y portadores de texto.

{{% alert color="primary" %}} 

Echa un vistazo a la aplicación [**Conversión de Aspose.Slides PPT a PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Esta aplicación está construida sobre la [**API de Aspose.Slides**](https://products.aspose.com/slides/java/), por lo que puede ver un ejemplo vivo de las capacidades básicas de conversión de PPT a PPTX. La conversión de Aspose.Slides es una aplicación web que permite cargar archivos de presentación en formato PPT y descargarlos convertidos a PPTX.

Encuentra otros ejemplos en vivo de [**Conversión de Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Convertir PPT a PPTX**
Aspose.Slides para Java ahora facilita a los desarrolladores acceder a PPT mediante una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y convertirlo al formato respectivo [PPTX](https://docs.fileformat.com/presentation/pptx/). Actualmente, admite la conversión parcial de [PPT](https://docs.fileformat.com/presentation/ppt/) a PPTX. Para obtener más detalles sobre qué funciones son compatibles y cuáles no en la conversión de PPT a PPTX, vaya a este documento [enlace](/slides/java/ppt-to-pptx-conversion/).

Aspose.Slides para Java ofrece la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) que representa un archivo de presentación **PPTX**. La clase Presentation ahora también puede acceder a **PPT** a través de Presentation cuando el objeto se instancia. El siguiente ejemplo muestra cómo convertir una presentación PPT a una presentación PPTX.

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
|**Figura: Presentación PPT de origen**|

El fragmento de código anterior generó la siguiente presentación PPTX después de la conversión

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figura: Presentación PPTX generada después de la conversión**|