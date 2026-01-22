---
title: Convertir PPTX a PPT en Android
linktitle: PPTX a PPT
type: docs
weight: 21
url: /es/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "Convierta fácilmente PPTX a PPT con Aspose.Slides para Android a través de Java—garantice una compatibilidad perfecta con los formatos de PowerPoint mientras preserva el diseño y la calidad de su presentación."
---

## **Visión general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPTX a formato PPT usando Java. Se cubre el siguiente tema.

- Convert PPTX to PPT in Java

## **Convertir PPTX a PPT en Android**

Para obtener el código de ejemplo en Java que convierte PPTX a PPT, consulte la sección siguiente, es decir, [Convert PPTX to PPT](#convert-pptx-to-ppt). Simplemente carga el archivo PPTX y lo guarda en formato PPT. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPTX en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se comenta en estos artículos. 

- [Convert PPTX to PDF on Android](/slides/es/androidjava/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS on Android](/slides/es/androidjava/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML on Android](/slides/es/androidjava/convert-powerpoint-to-html/)
- [Convert PPTX to ODP on Android](/slides/es/androidjava/save-presentation/)
- [Convert PPTX to PNG on Android](/slides/es/androidjava/convert-powerpoint-to-png/)

## **Convertir PPTX a PPT**

Para convertir un PPTX a PPT, simplemente pase el nombre de archivo y el formato de guardado al método **Save** de la clase [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). El ejemplo de código Java a continuación convierte una presentación de PPTX a PPT usando las opciones predeterminadas.
```java
// instanciar un objeto Presentation que representa un archivo PPTX
Presentation presentation = new Presentation("template.pptx");

// guardar la presentación como PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **Preguntas frecuentes**

**¿Todos los efectos y características de PPTX se conservan al guardar en el formato PPT heredado (97–2003)?**

No siempre. El formato PPT carece de algunas capacidades más recientes (p. ej., ciertos efectos, objetos y comportamientos), por lo que las características pueden simplificarse o rasterizarse durante la conversión.

**¿Puedo convertir solo diapositivas seleccionadas a PPT en lugar de toda la presentación?**

El guardado directo apunta a toda la presentación. Para convertir diapositivas específicas, cree una nueva presentación con solo esas diapositivas y guárdela como PPT; también puede usar un servicio/API que admita parámetros de conversión por diapositiva.

**¿Se admiten presentaciones protegidas con contraseña?**

Sí. Puede detectar si un archivo está protegido, abrirlo con una contraseña y también [configure protection/encryption settings](/slides/es/androidjava/password-protected-presentation/) para el PPT guardado.