---
title: Convertir PPT a PPTX en C#
linktitle: Convertir PPT a PPTX
type: docs
weight: 20
url: /es/net/convert-ppt-to-pptx/
keywords: "C# Convertir PPT a PPTX, Convertir Presentación de PowerPoint, PPT a PPTX, C#, Csharp, .NET, Aspose.Slides"
description: "Convertir PowerPoint PPT a PPTX en C# o .NET"
---

## **Resumen**

Este artículo explica cómo convertir una Presentación de PowerPoint en formato PPT a formato PPTX usando C# y con la aplicación en línea de conversión de PPT a PPTX. Se cubre el siguiente tema.

- [Convertir PPT a PPTX en C#](#convertir-ppt-a-pptx)

## **C# Convertir PPT a PPTX**

Para el código de ejemplo en C# para convertir PPT a PPTX, consulte la sección a continuación, es decir, [Convertir PPT a PPTX](#convertir-ppt-a-pptx). Simplemente carga el archivo PPT y lo guarda en formato PPTX. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPT en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos.

- [C# Convertir PPT a PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convertir PPT a XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convertir PPT a HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convertir PPT a ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convertir PPT a Imagen](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Acerca de la Conversión de PPT a PPTX**
Convertir el antiguo formato PPT a PPTX con la API de Aspose.Slides. Si necesita convertir miles de presentaciones PPT a formato PPTX, la mejor solución es hacerlo programáticamente. Con la API de Aspose.Slides es posible hacerlo en pocas líneas de código. La API soporta compatibilidad total para convertir presentaciones PPT a PPTX y es posible:

- Convertir estructuras complicadas de maestros, diseños y diapositivas.
- Convertir presentaciones con gráficos.
- Convertir presentaciones con formas grupales, formas automáticas (como rectángulos y elipses), formas con geometría personalizada.
- Convertir presentaciones que tienen estilos de relleno de texturas e imágenes para formas automáticas.
- Convertir presentaciones con marcadores de posición, cuadros de texto y contenedores de texto.

{{% alert color="primary" %}} 

Echa un vistazo a [**Aspose.Slides Conversión de PPT a PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Esta aplicación está construida sobre la **API de Aspose.Slides**, por lo que puede ver un ejemplo en vivo de las capacidades básicas de conversión de PPT a PPTX. La Conversión de Aspose.Slides es una aplicación web, que permite soltar un archivo de presentación en formato PPT y descargarlo convertido a PPTX.

Encuentra otros ejemplos en vivo de [**Conversión de Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Convertir PPT a PPTX**
Para convertir un PPT a PPTX, simplemente pase el nombre del archivo y el formato de guardado al [**Guardar**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) método de la [**Presentación**](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase. El código de ejemplo en C# a continuación convierte una Presentación de PPT a PPTX usando opciones predeterminadas.

```c#
// Instanciar un objeto Presentación que representa un archivo PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Guardar la presentación PPTX en formato PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

Lea más sobre los formatos de presentación [**PPT vs PPTX**](/slides/es/net/ppt-vs-pptx/) y cómo [**Aspose.Slides soporta la conversión de PPT a PPTX**](/slides/es/net/convert-ppt-to-pptx/).