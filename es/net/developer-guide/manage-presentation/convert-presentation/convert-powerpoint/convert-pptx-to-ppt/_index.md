---
title: Convertir PPTX a PPT en .NET
linktitle: PPTX a PPT
type: docs
weight: 21
url: /es/net/convert-pptx-to-ppt/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPTX
- PPTX a PPT
- guardar PPTX como PPT
- exportar PPTX a PPT
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Convierta fácilmente PPTX a PPT con Aspose.Slides para .NET—garantice una compatibilidad perfecta con los formatos de PowerPoint mientras preserva el diseño y la calidad de su presentación."
---

## **Resumen**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPTX a formato PPT usando C#. Se cubren los siguientes temas.

- Convertir PPTX a PPT en C#

## **C# Convertir PPTX a PPT**

Para el código de ejemplo en C# que convierte PPTX a PPT, consulte la sección a continuación, es decir, [Convertir PPTX a PPT](#convert-pptx-to-ppt). Simplemente carga el archivo PPTX y lo guarda en formato PPT. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPTX en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos.

- [C# Convertir PPTX a PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convertir PPTX a XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convertir PPTX a HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convertir PPTX a ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convertir PPTX a Imagen](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Convertir PPTX a PPT**
Para convertir un PPTX a PPT simplemente pase el nombre de archivo y el formato de guardado al método [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) de la clase [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). El ejemplo de código C# a continuación convierte una Presentation de PPTX a PPT usando las opciones predeterminadas.
```c#
 // Instanciar un objeto Presentation que representa un archivo PPTX
 Presentation pres = new Presentation("presentation.pptx");

// Guardar la presentación PPTX en formato PPT
 pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **Preguntas frecuentes**

**¿Los efectos y características de PPTX se conservan al guardar en el formato PPT heredado (97–2003)?**

No siempre. El formato PPT carece de algunas capacidades más nuevas (p. ej., ciertos efectos, objetos y comportamientos), por lo que las características pueden simplificarse o rasterizarse durante la conversión.

**¿Puedo convertir solo diapositivas seleccionadas a PPT en lugar de toda la presentación?**

El guardado directo apunta a toda la presentación. Para convertir diapositivas específicas, cree una nueva presentación con solo esas diapositivas y guárdela como PPT; alternativamente, use un servicio/API que admita parámetros de conversión por diapositiva.

**¿Se admiten presentaciones protegidas con contraseña?**

Sí. Puede detectar si un archivo está protegido, abrirlo con una contraseña y también [configurar la protección/ajustes de cifrado](/slides/es/net/password-protected-presentation/) para el PPT guardado.