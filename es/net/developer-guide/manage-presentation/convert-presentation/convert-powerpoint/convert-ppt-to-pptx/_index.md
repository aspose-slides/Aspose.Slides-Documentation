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

## **Descripción general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPT a formato PPTX utilizando C# y con la aplicación en línea de conversión de PPT a PPTX. Se cubre el siguiente tema.

- [Convertir PPT a PPTX en C#](#convert-ppt-to-pptx)

## **Convertir PPT a PPTX en .NET**

Para obtener código de ejemplo en C# que convierta PPT a PPTX, consulte la sección a continuación, es decir, [Convertir PPT a PPTX](#convert-ppt-to-pptx). Sólo carga el archivo PPT y lo guarda en formato PPTX. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPT en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se describe en estos artículos. 

- [C# Convertir PPT a PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convertir PPT a XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convertir PPT a HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convertir PPT a ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convertir PPT a Imagen](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Acerca de la conversión de PPT a PPTX**

Convierta el formato PPT antiguo a PPTX con Aspose.Slides API. Si necesita convertir miles de presentaciones PPT a formato PPTX, la mejor solución es hacerlo programáticamente. Con Aspose.Slides API es posible hacerlo con solo unas pocas líneas de código. La API admite compatibilidad total para convertir presentaciones PPT a PPTX y es posible:

- Convertir estructuras complejas de maestros, diseños y diapositivas.
- Convertir presentaciones con gráficos.
- Convertir presentaciones con formas grupales, autoformas (como rectángulos y elipses), formas con geometría personalizada.
- Convertir presentaciones que tengan texturas y estilos de relleno de imágenes para autoformas.
- Convertir presentaciones con marcadores de posición, marcos de texto y contenedores de texto.

{{% alert color="primary" %}} 

Echa un vistazo a [**Conversión de PPT a PPTX con Aspose.Slides**](https://products.aspose.app/slides/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Esta aplicación está construida sobre **Aspose.Slides API**, por lo que puede ver un ejemplo en funcionamiento de las capacidades básicas de conversión de PPT a PPTX. Aspose.Slides Conversion es una aplicación web que permite arrastrar un archivo de presentación en formato PPT y descargarlo convertido a PPTX.

Find other live [**Conversión de Aspose.Slides**](https://products.aspose.app/slides/conversion/) examples.
{{% /alert %}} 

## **Convertir PPT a PPTX**

Para convertir un PPT a PPTX simplemente pase el nombre del archivo y el formato de guardado al método [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) de la clase [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation). El ejemplo de código C# a continuación convierte una presentación de PPT a PPTX usando las opciones predeterminadas.
```c#
// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Guardar la presentación PPTX en formato PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


Read more about [**PPT vs PPTX**](/slides/es/net/ppt-vs-pptx/) presentation formats and how [**Aspose.Slides admite la conversión de PPT a PPTX**](/slides/es/net/convert-ppt-to-pptx/).

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre los formatos PPT y PPTX?**

PPT es el formato binario más antiguo utilizado por Microsoft PowerPoint, mientras que PPTX es el formato basado en XML introducido con Microsoft Office 2007. Los archivos PPTX ofrecen mejor rendimiento, tamaño de archivo reducido y una recuperación de datos mejorada.

**¿Puedo convertir PPT a PPTX usando .NET?**

Sí, utilizando la biblioteca Aspose.Slides para .NET, puede cargar fácilmente un archivo PPT y guardarlo en formato PPTX con solo unas pocas líneas de código.

**¿Aspose.Slides admite la conversión por lotes de varios archivos PPT a PPTX?**

Sí, puede usar Aspose.Slides en un bucle para convertir múltiples archivos PPT a PPTX de forma programática, lo que lo hace adecuado para escenarios de conversión por lotes.

**¿Se conservará el contenido y el formato después de la conversión?**

Aspose.Slides mantiene una alta fidelidad al convertir presentaciones. Los diseños de diapositivas, animaciones, formas, gráficos y otros elementos de diseño se conservan durante la conversión de PPT a PPTX.

**¿Puedo convertir otros formatos como PDF o HTML a partir de archivos PPT?**

Sí, Aspose.Slides admite la conversión de archivos PPT a varios formatos, incluidos PDF, XPS, HTML, ODP y formatos de imagen como PNG y JPEG.

**¿Es posible convertir PPT a PPTX sin Microsoft PowerPoint instalado?**

Sí, Aspose.Slides para .NET es una API independiente y no requiere Microsoft PowerPoint ni ningún software de terceros para realizar la conversión.

**¿Existe una herramienta en línea disponible para la conversión de PPT a PPTX?**

Sí, puede usar la aplicación web gratuita [Conversor de PPT a PPTX de Aspose.Slides](https://products.aspose.app/slides/conversion/ppt-to-pptx) para realizar la conversión directamente en su navegador sin escribir código.