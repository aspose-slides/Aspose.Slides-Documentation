---
title: Convertir PPTX a PPT en C++
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
description: "Convierta fácilmente PPTX a PPT con Aspose.Slides para C++ -- garantice una compatibilidad perfecta con los formatos de PowerPoint sin perder el diseño y la calidad de su presentación."
---

## **Visión general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPTX al formato PPT usando C++. Se cubre el siguiente tema.

- Convertir PPTX a PPT en C++

## **Convertir PPTX a PPT en C++**

Para obtener el código de ejemplo en C++ que convierta PPTX a PPT, consulte la sección a continuación, es decir, [Convertir PPTX a PPT](#convert-pptx-to-ppt). Simplemente carga el archivo PPTX y lo guarda en formato PPT. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPTX en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos.

- [Convertir PPTX a PDF en C++](/slides/es/cpp/convert-powerpoint-to-pdf/)
- [Convertir PPTX a XPS en C++](/slides/es/cpp/convert-powerpoint-to-xps/)
- [Convertir PPTX a HTML en C++](/slides/es/cpp/convert-powerpoint-to-html/)
- [Convertir PPTX a ODP en C++](/slides/es/cpp/save-presentation/)
- [Convertir PPTX a PNG en C++](/slides/es/cpp/convert-powerpoint-to-png/)

## **Convertir PPTX a PPT**

Para convertir un PPTX a PPT simplemente pase el nombre de archivo y el formato de guardado al método **Save** de la clase [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). El ejemplo de código C++ a continuación convierte una Presentation de PPTX a PPT usando las opciones predeterminadas.
```cpp
// Cargar el PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Guardar en formato PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **Preguntas frecuentes**

**¿Sobreviven todos los efectos y características de PPTX al guardarse en el formato PPT heredado (97–2003)?**

No siempre. El formato PPT carece de algunas capacidades más recientes (p. ej., ciertos efectos, objetos y comportamientos), por lo que las características pueden simplificarse o rasterizarse durante la conversión.

**¿Puedo convertir solo diapositivas seleccionadas a PPT en lugar de toda la presentación?**

El guardado directo se dirige a toda la presentación. Para convertir diapositivas específicas, cree una nueva presentación que contenga solo esas diapositivas y guárdela como PPT; alternativamente, utilice un servicio/API que admita parámetros de conversión por diapositiva.

**¿Se admiten presentaciones protegidas con contraseña?**

Sí. Puede detectar si un archivo está protegido, abrirlo con una contraseña y también [configurar la protección/ajustes de cifrado](/slides/es/cpp/password-protected-presentation/) para el PPT guardado.