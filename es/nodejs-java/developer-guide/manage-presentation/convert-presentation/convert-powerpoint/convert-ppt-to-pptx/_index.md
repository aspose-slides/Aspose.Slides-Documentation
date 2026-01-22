---
title: Convertir PPT a PPTX en JavaScript
linktitle: PPT a PPTX
type: docs
weight: 20
url: /es/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convierte presentaciones PPT heredadas a PPTX modernas rápidamente con Aspose.Slides para Node.js — tutorial claro, ejemplos de código gratuitos, sin dependencia de Microsoft Office."
---

## **Descripción general**

Este artículo explica cómo convertir presentaciones de PowerPoint en formato PPT a formato PPTX utilizando JavaScript y una aplicación en línea de conversión de PPT a PPTX. Se cubre el siguiente tema.

- Convertir PPT a PPTX en JavaScript

## **Java Convertir PPT a PPTX**

Para el código de ejemplo en JavaScript que convierte PPT a PPTX, consulte la sección siguiente, es decir, [Convert PPT to PPTX](#convert-ppt-to-pptx). Simplemente carga el archivo PPT y lo guarda en formato PPTX. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPT en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se comenta en estos artículos.

- [Convertir PPT a PDF en JavaScript](/slides/es/nodejs-java/convert-powerpoint-to-pdf/)
- [Convertir PPT a XPS en JavaScript](/slides/es/nodejs-java/convert-powerpoint-to-xps/)
- [Convertir PPT a HTML en JavaScript](/slides/es/nodejs-java/convert-powerpoint-to-html/)
- [Convertir PPT a ODP en JavaScript](/slides/es/nodejs-java/save-presentation/)
- [Convertir PPT a PNG en JavaScript](/slides/es/nodejs-java/convert-powerpoint-to-png/)

## **Sobre la conversión de PPT a PPTX**

Convierta el antiguo formato PPT a PPTX con Aspose.Slides API. Si necesita convertir miles de presentaciones PPT a formato PPTX, la mejor solución es hacerlo programáticamente. Con Aspose.Slides API es posible hacerlo en solo unas pocas líneas de código. La API admite compatibilidad total para convertir presentaciones PPT a PPTX y es posible:

- Convertir estructuras complejas de maestros, diseños y diapositivas.
- Convertir presentaciones con gráficos.
- Convertir presentaciones con formas agrupadas, autoformas (como rectángulos y elipses), formas con geometría personalizada.
- Convertir presentaciones que tengan texturas y estilos de relleno de imágenes para autoformas.
- Convertir presentaciones con marcadores de posición, marcos de texto y contenedores de texto.

{{% alert color="primary" %}} 

Eche un vistazo a la aplicación [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Esta aplicación está construida sobre [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/), por lo que puede ver un ejemplo en funcionamiento de las capacidades básicas de conversión de PPT a PPTX. Aspose.Slides Conversion es una aplicación web que permite arrastrar un archivo de presentación en formato PPT y descargarlo convertido a PPTX.

Encuentre otros ejemplos en vivo de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **Convertir PPT a PPTX**

Aspose.Slides para Node.js a través de Java ahora facilita a los desarrolladores acceder al PPT mediante la instancia de clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) y convertirlo al formato [PPTX](https://docs.fileformat.com/presentation/pptx/) correspondiente. Actualmente, admite la conversión parcial de [PPT ](https://docs.fileformat.com/presentation/ppt/) a PPTX.

Aspose.Slides para Node.js a través de Java ofrece la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) que representa un archivo de presentación **PPTX**. La clase Presentation ahora también puede acceder a **PPT** a través de Presentation cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una presentación PPT en una presentación PPTX.

```javascript
// Instanciar un objeto Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // Guardar la presentación PPTX en formato PPTX
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figura : Presentación PPT origen**|

El fragmento de código anterior generó la siguiente presentación PPTX tras la conversión

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figura: Presentación PPTX generada tras la conversión**|

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre los formatos PPT y PPTX?**

PPT es el formato de archivo binario más antiguo usado por Microsoft PowerPoint, mientras que PPTX es el formato basado en XML más reciente introducido con Microsoft Office 2007. Los archivos PPTX ofrecen mejor rendimiento, menor tamaño de archivo y recuperación de datos mejorada.

**¿Aspose.Slides admite la conversión por lotes de varios archivos PPT a PPTX?**

Sí, puede usar Aspose.Slides en un bucle para convertir varios archivos PPT a PPTX de forma programática, lo que lo hace adecuado para escenarios de conversión por lotes.

**¿Se conservarán el contenido y el formato tras la conversión?**

Aspose.Slides mantiene una alta fidelidad al convertir presentaciones. Los diseños de diapositivas, animaciones, formas, gráficos y otros elementos de diseño se conservan durante la conversión de PPT a PPTX.

**¿Puedo convertir otros formatos como PDF o HTML a partir de archivos PPT?**

Sí, Aspose.Slides admite la conversión de archivos PPT a varios formatos, incluidos PDF, XPS, HTML, ODP y formatos de imagen como PNG y JPEG.

**¿Es posible convertir PPT a PPTX sin tener instalado Microsoft PowerPoint?**

Sí, Aspose.Slides es una API independiente y no requiere Microsoft PowerPoint ni ningún software de terceros para realizar la conversión.

**¿Existe una herramienta en línea disponible para la conversión de PPT a PPTX?**

Sí, puede usar la aplicación web gratuita [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) para realizar la conversión directamente en su navegador sin escribir código.