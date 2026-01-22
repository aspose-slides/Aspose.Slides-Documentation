---
title: Convertir PPT a PPTX en .NET
linktitle: PPT a PPTX
type: docs
weight: 20
url: /es/net/convert-ppt-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Convierta presentaciones PPT heredadas a PPTX modernos rápidamente en .NET con Aspose.Slides — tutorial claro, ejemplos de código C# gratuitos, sin dependencia de Microsoft Office."
---

## **Visión general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPT a formato PPTX usando C# y la aplicación en línea de conversión de PPT a PPTX. Se cubre el siguiente tema.

- [Convertir PPT a PPTX en C#](#convert-ppt-to-pptx)

## **Convertir PPT a PPTX en .NET**

Para el código de ejemplo en C# que convierte PPT a PPTX, consulte la sección a continuación, es decir, [Convertir PPT a PPTX](#convert-ppt-to-pptx). Simplemente carga el archivo PPT y lo guarda en formato PPTX. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPT en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se comenta en estos artículos.

- [Convertir PPT a PDF en .NET](/slides/es/net/convert-powerpoint-to-pdf/)
- [Convertir PPT a XPS en .NET](/slides/es/net/convert-powerpoint-to-xps/)
- [Convertir PPT a HTML en .NET](/slides/es/net/convert-powerpoint-to-html/)
- [Convertir PPT a ODP en .NET](/slides/es/net/save-presentation/)
- [Convertir PPT a PNG en .NET](/slides/es/net/convert-powerpoint-to-png/)

## **Acerca de la conversión de PPT a PPTX**
Convierta el antiguo formato PPT a PPTX con la API Aspose.Slides. Si necesita convertir miles de presentaciones PPT a formato PPTX, la mejor solución es hacerlo programáticamente. Con la API Aspose.Slides es posible hacerlo en unas pocas líneas de código. La API admite plena compatibilidad para convertir una presentación PPT a PPTX y permite:

- Convertir estructuras complejas de masters, diseños y diapositivas.
- Convertir presentaciones con gráficos.
- Convertir presentaciones con formas de grupo, autoformas (como rectángulos y elipses), formas con geometría personalizada.
- Convertir presentaciones que tengan texturas y estilos de relleno de imágenes para autoformas.
- Convertir presentaciones con marcadores de posición, marcos de texto y contenedores de texto.

{{% alert color="primary" %}} 

Eche un vistazo a [**Conversión de Aspose.Slides PPT a PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Esta aplicación está construida sobre **Aspose.Slides API**, por lo que puede ver un ejemplo en vivo de las capacidades básicas de conversión de PPT a PPTX. Aspose.Slides Conversion es una aplicación web que permite arrastrar un archivo de presentación en formato PPT y descargarlo convertido a PPTX.

Encuentre otros ejemplos en vivo de [**Conversión de Aspose.Slides**](https://products.aspose.app/slides/conversion/) .
{{% /alert %}} 


## **Convertir PPT a PPTX**
Para convertir un PPT a PPTX simplemente pase el nombre del archivo y el formato de guardado al método [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) de la clase [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation). El fragmento de código C# a continuación convierte una presentación de PPT a PPTX usando opciones predeterminadas.
```c#
// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Guardando la presentación PPTX en formato PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


Lea más sobre los formatos de presentación [**PPT vs PPTX**](/slides/es/net/ppt-vs-pptx/) y cómo [**Aspose.Slides admite la conversión de PPT a PPTX**](/slides/es/net/convert-ppt-to-pptx/).

## **FAQ**

**¿Cuál es la diferencia entre los formatos PPT y PPTX?**

PPT es el antiguo formato binario utilizado por Microsoft PowerPoint, mientras que PPTX es el nuevo formato basado en XML introducido con Microsoft Office 2007. Los archivos PPTX ofrecen mejor rendimiento, menor tamaño y una recuperación de datos más eficaz.

**¿Puedo convertir PPT a PPTX usando .NET?**

Sí, con la biblioteca Aspose.Slides para .NET puede cargar fácilmente un archivo PPT y guardarlo en formato PPTX con solo unas pocas líneas de código.

**¿Aspose.Slides admite la conversión por lotes de varios archivos PPT a PPTX?**

Sí, puede usar Aspose.Slides en un bucle para convertir múltiples archivos PPT a PPTX de forma programática, lo que lo hace adecuado para escenarios de conversión por lotes.

**¿Se mantiene el contenido y el formato después de la conversión?**

Aspose.Slides mantiene una alta fidelidad al convertir presentaciones. Los diseños de diapositivas, animaciones, formas, gráficos y otros elementos de diseño se conservan durante la conversión de PPT a PPTX.

**¿Puedo convertir otros formatos como PDF o HTML desde archivos PPT?**

Sí, Aspose.Slides admite la conversión de archivos PPT a varios formatos, incluidos PDF, XPS, HTML, ODP y formatos de imagen como PNG y JPEG.

**¿Es posible convertir PPT a PPTX sin tener Microsoft PowerPoint instalado?**

Sí, Aspose.Slides para .NET es una API independiente y no requiere Microsoft PowerPoint ni ningún software de terceros para realizar la conversión.

**¿Existe una herramienta en línea disponible para la conversión de PPT a PPTX?**

Sí, puede usar la aplicación web gratuita [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) para realizar la conversión directamente en su navegador sin escribir código.