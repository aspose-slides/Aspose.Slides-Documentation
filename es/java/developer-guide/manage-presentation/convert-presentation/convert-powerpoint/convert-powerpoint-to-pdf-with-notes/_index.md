---
title: Convertir presentaciones de PowerPoint a PDF con notas en Java
linktitle: PowerPoint a PDF con notas
type: docs
weight: 50
url: /es/java/convert-powerpoint-to-pdf-with-notes/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a PDF
- presentación a PDF
- diapositiva a PDF
- PPT a PDF
- PPTX a PDF
- guardar presentación como PDF
- guardar PPT como PDF
- guardar PPTX como PDF
- exportar PPT a PDF
- exportar PPTX a PDF
- notas del presentador
- PDF con notas
- Java
- Aspose.Slides
description: "Convierta los formatos PPT y PPTX a PDF con notas usando Aspose.Slides para Java. Preserve diseños y notas del presentador para presentaciones profesionales."
---

## **Visión general**

En este artículo, aprenderá cómo convertir presentaciones de PowerPoint a formato PDF con notas del presentador usando Aspose.Slides. Esta guía cubrirá los pasos necesarios y proporcionará ejemplos de código para ayudarle a realizar esta tarea de manera eficiente. Al final de este artículo, podrá:

- Implementar el proceso de conversión para transformar diapositivas de PowerPoint en documentos PDF mientras preserva las notas del presentador.
- Personalizar el PDF de salida para asegurar que las notas del presentador estén incluidas y formateadas según sus requerimientos.

## **Convertir PowerPoint a PDF con notas**

El método `save` en la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) se puede usar para convertir una presentación PPT o PPTX a PDF con notas del presentador. Con Aspose.Slides, simplemente carga la presentación, configura las opciones de diseño usando la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) para incluir las notas del presentador y luego guarda el archivo como PDF. El siguiente fragmento de código demuestra cómo convertir una presentación de ejemplo a PDF en vista de diapositiva con notas.
```java
Presentation presentation = new Presentation("sample.pptx");

// Configurar opciones PDF para renderizar notas del presentador.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Renderizar notas del presentador bajo la diapositiva.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Guardar la presentación en PDF con notas del presentador.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```


{{% alert color="primary" %}} 
Es posible que desee consultar el Conversor en línea de PowerPoint a PDF de Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion). 
{{% /alert %}}