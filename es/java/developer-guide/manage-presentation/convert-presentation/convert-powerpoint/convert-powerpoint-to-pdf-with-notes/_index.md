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
- notas del orador
- PDF con notas
- Java
- Aspose.Slides
description: "Convertir los formatos PPT y PPTX a PDF con notas usando Aspose.Slides para Java. Conservar diseños y notas del orador para presentaciones profesionales."
---
## **Descripción general**

En este artículo, aprenderá cómo convertir presentaciones de PowerPoint al formato PDF con notas del orador usando Aspose.Slides. Esta guía cubrirá los pasos necesarios y proporcionará ejemplos de código para ayudarle a realizar esta tarea de manera eficiente. Al final de este artículo, podrá:

- Implementar el proceso de conversión para transformar diapositivas de PowerPoint en documentos PDF mientras conserva las notas del orador.
- Personalizar el PDF de salida para garantizar que las notas del orador se incluyan y se formateen según sus requisitos.

## **Convertir PowerPoint a PDF con notas**

El método `save` en la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) puede usarse para convertir una presentación PPT o PPTX a un PDF con notas del orador. Con Aspose.Slides, simplemente carga la presentación, configura las opciones de diseño usando la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/notescommentslayoutingoptions/) para incluir las notas del orador y luego guarda el archivo como PDF. El siguiente fragmento de código muestra cómo convertir una presentación de ejemplo a PDF en la vista de diapositiva con notas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Configura las opciones PDF para renderizar las notas del orador.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Renderiza las notas del orador debajo de la diapositiva.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 
Puede que desee consultar el [Convertidor en línea de PowerPoint a PDF de Aspose](https://products.aspose.app/slides/es/conversion). 
{{% /alert %}}