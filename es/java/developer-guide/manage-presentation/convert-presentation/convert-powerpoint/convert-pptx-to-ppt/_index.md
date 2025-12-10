---
title: Convertir PPTX a PPT en Java
linktitle: PPTX a PPT
type: docs
weight: 21
url: /es/java/convert-pptx-to-ppt/
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
- Java
- Aspose.Slides
description: "Convierta fácilmente PPTX a PPT con Aspose.Slides para Java — garantice una compatibilidad perfecta con los formatos de PowerPoint mientras preserva el diseño y la calidad de su presentación."
---

## **Descripción general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPTX a formato PPT utilizando Java. Los siguientes temas están cubiertos.

- Convertir PPTX a PPT en Java

## **Convertir PPTX a PPT en Java**

Para obtener código de ejemplo en Java que convierta PPTX a PPT, consulte la sección a continuación, es decir, [Convert PPTX to PPT](#convert-pptx-to-ppt). Simplemente carga el archivo PPTX y lo guarda en formato PPT. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPTX en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos. 

- [Java Convertir PPTX a PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java Convertir PPTX a XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java Convertir PPTX a HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java Convertir PPTX a ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java Convertir PPTX a Imagen](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **Convertir PPTX a PPT**
Para convertir un PPTX a PPT, simplemente pase el nombre del archivo y el formato de guardado al método **Save** de la clase [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). El siguiente ejemplo de código Java convierte una Presentation de PPTX a PPT usando las opciones predeterminadas.
```java
// instanciar un objeto Presentation que representa un archivo PPTX
Presentation presentation = new Presentation("template.pptx");

// guardar la presentación como PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **Preguntas frecuentes**

**¿Todos los efectos y características de PPTX se conservan al guardar en el formato PPT heredado (97–2003)?**

No siempre. El formato PPT carece de algunas capacidades más nuevas (por ejemplo, ciertos efectos, objetos y comportamientos), por lo que las características pueden simplificarse o rasterizarse durante la conversión.

**¿Puedo convertir solo diapositivas seleccionadas a PPT en lugar de toda la presentación?**

El guardado directo se aplica a toda la presentación. Para convertir diapositivas específicas, cree una nueva presentación con solo esas diapositivas y guárdela como PPT; alternativamente, use un servicio/API que admita parámetros de conversión por diapositiva.

**¿Se admiten presentaciones protegidas con contraseña?**

Sí. Puede detectar si un archivo está protegido, abrirlo con una contraseña y también [configurar la protección/ajustes de cifrado](/slides/es/java/password-protected-presentation/) para el PPT guardado.