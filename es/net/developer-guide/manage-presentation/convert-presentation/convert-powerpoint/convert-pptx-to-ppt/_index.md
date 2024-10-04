---
title: Convertir PPTX a PPT en C#
linktitle: Convertir PPTX a PPT
type: docs
weight: 21
url: /net/convert-pptx-to-ppt/
keywords: "C# Convertir PPTX a PPT, Convertir Presentación de PowerPoint, PPTX a PPT, C#, Aspose.Slides"
description: "Convertir PPTX de PowerPoint a PPT en C#"
---

## **Descripción general**

Este artículo explica cómo convertir una Presentación de PowerPoint en formato PPTX a formato PPT utilizando C#. El siguiente tema se cubre.

- Convertir PPTX a PPT en C#

## **C# Convertir PPTX a PPT**

Para el código de ejemplo en C# para convertir PPTX a PPT, consulte la sección a continuación es decir, [Convertir PPTX a PPT](#convert-pptx-a-ppt). Solo carga el archivo PPTX y lo guarda en formato PPT. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPTX en muchos otros formatos como PDF, XPS, ODP, HTML, etc. como se discute en estos artículos.

- [C# Convertir PPTX a PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convertir PPTX a XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convertir PPTX a HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convertir PPTX a ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convertir PPTX a Imagen](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Convertir PPTX a PPT**
Para convertir un PPTX a PPT, simplemente pase el nombre del archivo y el formato de guardado al método [**Guardar**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) de la clase [**Presentación**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). El siguiente ejemplo de código en C# convierte una Presentación de PPTX a PPT utilizando opciones predeterminadas.

```c#
// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation("presentation.pptx");

// Guardar la presentación PPTX en formato PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```