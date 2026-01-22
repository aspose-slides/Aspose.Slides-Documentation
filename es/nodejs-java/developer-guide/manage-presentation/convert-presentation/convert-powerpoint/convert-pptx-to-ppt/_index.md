---
title: Convertir PPTX a PPT en JavaScript
linktitle: PPTX a PPT
type: docs
weight: 21
url: /es/nodejs-java/convert-pptx-to-ppt/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convierta fácilmente PPTX a PPT con Aspose.Slides—garantice una compatibilidad sin problemas con los formatos de PowerPoint mientras preserva el diseño y la calidad de su presentación."
---

## **Visión general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPTX a formato PPT mediante JavaScript. Se cubre el siguiente tema.

- Convertir PPTX a PPT en JavaScript

## **JavaScript: Convertir PPTX a PPT**

Para obtener código de muestra de JavaScript que convierta PPTX a PPT, consulte la sección a continuación, es decir, [Convertir PPTX a PPT](#convert-pptx-to-ppt). Simplemente carga el archivo PPTX y lo guarda en formato PPT. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPTX en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se comenta en estos artículos.

- [Convertir PPTX a PDF en JavaScript](/slides/es/nodejs-java/convert-powerpoint-to-pdf/)
- [Convertir PPTX a XPS en JavaScript](/slides/es/nodejs-java/convert-powerpoint-to-xps/)
- [Convertir PPTX a HTML en JavaScript](/slides/es/nodejs-java/convert-powerpoint-to-html/)
- [Convertir PPTX a ODP en JavaScript](/slides/es/nodejs-java/save-presentation/)
- [Convertir PPTX a PNG en JavaScript](/slides/es/nodejs-java/convert-powerpoint-to-png/)

## **Convertir PPTX a PPT**

Para convertir un PPTX a PPT, basta con pasar el nombre del archivo y el formato de guardado al método **Save** de la clase [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). El fragmento de código JavaScript a continuación convierte una presentación de PPTX a PPT usando opciones predeterminadas.
```javascript
// instanciar un objeto Presentation que representa un archivo PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// guardar la presentación como PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **Preguntas frecuentes**

**¿Todos los efectos y características de PPTX se conservan al guardar en el formato PPT heredado (97–2003)?**

No siempre. El formato PPT carece de algunas capacidades más recientes (por ejemplo, ciertos efectos, objetos y comportamientos), por lo que las características pueden simplificarse o rasterizarse durante la conversión.

**¿Puedo convertir solo diapositivas seleccionadas a PPT en lugar de toda la presentación?**

El guardado directo apunta a la presentación completa. Para convertir diapositivas específicas, cree una nueva presentación que contenga solo esas diapositivas y guárdela como PPT; alternativamente, utilice un servicio/API que admita parámetros de conversión por diapositiva.

**¿Se admiten presentaciones protegidas con contraseña?**

Sí. Puede detectar si un archivo está protegido, abrirlo con una contraseña y también [configurar la protección/los ajustes de cifrado](/slides/es/nodejs-java/password-protected-presentation/) para el PPT guardado.