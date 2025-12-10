---
title: Convert PPTX a PPT en C++
linktitle: PPTX a PPT
type: docs
weight: 21
url: /es/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "Convierta fácilmente PPTX a PPT con Aspose.Slides para C++—garantice una compatibilidad sin problemas con los formatos de PowerPoint mientras preserva el diseño y la calidad de su presentación."
---

## **Descripción general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPTX a formato PPT usando C++. Se cubre el siguiente tema.

- Convertir PPTX a PPT en C++

## **Convertir PPTX a PPT en C++**

Para obtener el código de ejemplo en C++ que convierte PPTX a PPT, consulte la sección a continuación, es decir, [Convertir PPTX a PPT](#convert-pptx-to-ppt). Simplemente carga el archivo PPTX y lo guarda en formato PPT. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPTX en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos. 

- [C++ Convertir PPTX a PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Convertir PPTX a XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Convertir PPTX a HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Convertir PPTX a ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Convertir PPTX a Imagen](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **Convertir PPTX a PPT**
Para convertir un PPTX a PPT, simplemente pase el nombre del archivo y el formato de guardado al método **Save** de la clase [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). El siguiente ejemplo de código C++ convierte una presentación de PPTX a PPT usando las opciones predeterminadas.
```cpp
// Cargar el PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Guardar en formato PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **Preguntas frecuentes**

**¿Todos los efectos y características de PPTX se conservan al guardarse en el formato PPT heredado (97–2003)?**

No siempre. El formato PPT carece de algunas capacidades más recientes (p. ej., ciertos efectos, objetos y comportamientos), por lo que las características pueden simplificarse o rasterizarse durante la conversión.

**¿Puedo convertir solo diapositivas seleccionadas a PPT en lugar de toda la presentación?**

El guardado directo apunta a toda la presentación. Para convertir diapositivas específicas, cree una nueva presentación con solo esas diapositivas y guárdela como PPT; alternativamente, use un servicio/API que admita parámetros de conversión por diapositiva.

**¿Se admiten presentaciones protegidas con contraseña?**

Sí. Puede detectar si un archivo está protegido, abrirlo con una contraseña y también [configurar la protección/ajustes de cifrado](/slides/es/cpp/password-protected-presentation/) para el PPT guardado.