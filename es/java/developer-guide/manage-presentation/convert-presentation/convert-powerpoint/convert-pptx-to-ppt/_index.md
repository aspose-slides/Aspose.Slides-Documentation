---
title: Convertir PPTX a PPT en Java
linktitle: Convertir PPTX a PPT
type: docs
weight: 21
url: /es/java/convert-pptx-to-ppt/
keywords: "Java Convertir PPTX a PPT, Convertir Presentación de PowerPoint, PPTX a PPT, Java, Aspose.Slides"
description: "Convertir PowerPoint PPTX a PPT en Java"
---

## **Descripción general**

Este artículo explica cómo convertir una Presentación de PowerPoint en formato PPTX a formato PPT utilizando Java. Se cubre el siguiente tema.

- Convertir PPTX a PPT en Java

## **Java Convertir PPTX a PPT**

Para ver un código de muestra en Java para convertir PPTX a PPT, consulte la sección a continuación es decir, [Convertir PPTX a PPT](#convertir-pptx-a-ppt). Simplemente carga el archivo PPTX y lo guarda en formato PPT. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPTX en muchos otros formatos como PDF, XPS, ODP, HTML, etc. como se discute en estos artículos.

- [Java Convertir PPTX a PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java Convertir PPTX a XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java Convertir PPTX a HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java Convertir PPTX a ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java Convertir PPTX a Imagen](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **Convertir PPTX a PPT**
Para convertir un PPTX a PPT, simplemente pase el nombre del archivo y el formato de guardado al método **Save** de la clase [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). El siguiente código de muestra en Java convierte una Presentación de PPTX a PPT utilizando opciones predeterminadas.

```java
// crear un objeto Presentation que representa un archivo PPTX
Presentation presentation = new Presentation("template.pptx");

// guardar la presentación como PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```