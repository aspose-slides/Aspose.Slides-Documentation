---
title: Convertir PPTX a PPT en JavaScript
linktitle: Convertir PPTX a PPT
type: docs
weight: 21
url: /es/nodejs-java/convert-pptx-to-ppt/
keywords: "Java Convertir PPTX a PPT, Convertir presentación de PowerPoint, PPTX a PPT, Java, Aspose.Slides"
description: "Convertir PowerPoint PPTX a PPT en JavaScript"
---

## **Visión general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPTX a formato PPT usando JavaScript. Se cubre el siguiente tema.

- Convertir PPTX a PPT en JavaScript

## **Java Convertir PPTX a PPT**

Para el código de muestra en JavaScript que convierte PPTX a PPT, vea la sección a continuación, es decir, [Convert PPTX to PPT](#convert-pptx-to-ppt). Simplemente carga el archivo PPTX y lo guarda en formato PPT. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPTX en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos. 

- [Java Convertir PPTX a PDF](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [Java Convertir PPTX a XPS](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [Java Convertir PPTX a HTML](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [Java Convertir PPTX a ODP](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [Java Convertir PPTX a Imagen](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **Convertir PPTX a PPT**

Para convertir un PPTX a PPT, simplemente pase el nombre del archivo y el formato de guardado al método **Save** de la clase [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). El ejemplo de código JavaScript a continuación convierte una Presentation de PPTX a PPT usando opciones predeterminadas.
```javascript
// instancia un objeto Presentation que representa un archivo PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// guarda la presentación como PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **Preguntas frecuentes**

**¿Todos los efectos y características de PPTX se conservan al guardar en el formato PPT heredado (97–2003)?**

No siempre. El formato PPT carece de algunas capacidades más recientes (p. ej., ciertos efectos, objetos y comportamientos), por lo que las características pueden simplificarse o rasterizarse durante la conversión.

**¿Puedo convertir solo diapositivas seleccionadas a PPT en lugar de toda la presentación?**

El guardado directo se aplica a toda la presentación. Para convertir diapositivas específicas, cree una nueva presentación con solo esas diapositivas y guárdela como PPT; alternativamente, utilice un servicio/API que admita parámetros de conversión por diapositiva.

**¿Se admiten presentaciones protegidas con contraseña?**

Sí. Puede detectar si un archivo está protegido, abrirlo con una contraseña y también [configurar la protección/ajustes de cifrado](/slides/es/nodejs-java/password-protected-presentation/) para el PPT guardado.