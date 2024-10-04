---
title: Convertir PPTX a PPT en C++
linktitle: Convertir PPTX a PPT
type: docs
weight: 21
url: /cpp/convert-pptx-to-ppt/
keywords: "C++ Convertir PPTX a PPT, Convertir Presentación de PowerPoint, PPTX a PPT, Python, Aspose.Slides"
description: "Convertir PPTX de PowerPoint a PPT en C++"
---

## **Descripción general**

Este artículo explica cómo convertir una Presentación de PowerPoint en formato PPTX a formato PPT utilizando C++. Se cubre el siguiente tema.

- Convertir PPTX a PPT en C++

## **C++ Convertir PPTX a PPT**

Para obtener un código de muestra en C++ para convertir PPTX a PPT, consulte la sección a continuación, es decir, [Convertir PPTX a PPT](#convertir-pptx-a-ppt). Simplemente carga el archivo PPTX y lo guarda en formato PPT. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPTX en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos.

- [C++ Convertir PPTX a PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Convertir PPTX a XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Convertir PPTX a HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Convertir PPTX a ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Convertir PPTX a Imagen](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **Convertir PPTX a PPT**
Para convertir un PPTX a PPT, simplemente pase el nombre del archivo y el formato de guardado al método **Save** de la clase [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). El siguiente ejemplo de código en C++ convierte una Presentación de PPTX a PPT utilizando opciones predeterminadas.

```cpp
// Cargar el PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Guardar en formato PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```