---
title: Convertir PPTX a PPT en PHP
linktitle: PPTX a PPT
type: docs
weight: 21
url: /es/php-java/convert-pptx-to-ppt/
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
- PHP
- Aspose.Slides
description: "Convierta fácilmente PPTX a PPT con Aspose.Slides — garantice una compatibilidad perfecta con los formatos de PowerPoint mientras preserva el diseño y la calidad de su presentación."
---

## **Visión general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPTX a formato PPT usando PHP. El siguiente tema está cubierto.

- Convertir PPTX a PPT

## **Convertir PPTX a PPT en PHP**

Para el código de ejemplo en Java para convertir PPTX a PPT, vea la sección a continuación, es decir, [Convertir PPTX a PPT](#convert-pptx-to-ppt). Simplemente carga el archivo PPTX y lo guarda en formato PPT. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPTX en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos. 

- [Convertir PPTX a PDF en PHP](/slides/es/php-java/convert-powerpoint-to-pdf/)
- [Convertir PPTX a XPS en PHP](/slides/es/php-java/convert-powerpoint-to-xps/)
- [Convertir PPTX a HTML en PHP](/slides/es/php-java/convert-powerpoint-to-html/)
- [Convertir PPTX a ODP en PHP](/slides/es/php-java/save-presentation/)
- [Convertir PPTX a PNG en PHP](/slides/es/php-java/convert-powerpoint-to-png/)

## **Convertir PPTX a PPT**
Para convertir un PPTX a PPT simplemente pase el nombre del archivo y el formato de guardado al método **Save** de la clase [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). El ejemplo de código PHP a continuación convierte una Presentation de PPTX a PPT usando las opciones predeterminadas.
```php
  # instanciar un objeto Presentation que representa un archivo PPTX
  $presentation = new Presentation("template.pptx");
  # guardar la presentación como PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```


## **Preguntas frecuentes**

**¿Se conservan todos los efectos y características de PPTX al guardarlos en el formato PPT heredado (97–2003)?**

No siempre. El formato PPT carece de algunas capacidades más recientes (por ejemplo, ciertos efectos, objetos y comportamientos), por lo que las funciones pueden simplificarse o rasterizarse durante la conversión.

**¿Puedo convertir solo diapositivas seleccionadas a PPT en lugar de toda la presentación?**

El guardado directo apunta a toda la presentación. Para convertir diapositivas específicas, cree una nueva presentación con solo esas diapositivas y guárdela como PPT; alternativamente, use un servicio/API que admita parámetros de conversión por diapositiva.

**¿Se admiten presentaciones protegidas con contraseña?**

Sí. Puede detectar si un archivo está protegido, abrirlo con una contraseña y también [configurar la protección/ajustes de cifrado](/slides/es/php-java/password-protected-presentation/) para el PPT guardado.