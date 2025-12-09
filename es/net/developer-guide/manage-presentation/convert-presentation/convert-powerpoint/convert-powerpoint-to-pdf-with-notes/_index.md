---
title: Convertir presentaciones de PowerPoint a PDF con notas en .NET
linktitle: PowerPoint a PDF con notas
type: docs
weight: 50
url: /es/net/convert-powerpoint-to-pdf-with-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Convierta los formatos PPT y PPTX a PDF con notas usando Aspose.Slides para .NET. Preserve los diseños y notas del orador para presentaciones profesionales."
---

## **Visión general**

En este artículo, aprenderá cómo convertir presentaciones de PowerPoint al formato PDF con notas del orador usando Aspose.Slides. Esta guía cubrirá los pasos necesarios y proporcionará ejemplos de código para ayudarle a realizar esta tarea de manera eficiente. Al final de este artículo, podrá:

- Implementar el proceso de conversión para transformar diapositivas de PowerPoint en documentos PDF conservando las notas del orador.
- Personalizar el PDF de salida para asegurarse de que las notas del orador estén incluidas y formateadas según sus requisitos.

## **Convertir PowerPoint a PDF con notas**

El método `Save` de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) se puede usar para convertir una presentación PPT o PPTX a un PDF con notas del orador. Con Aspose.Slides, simplemente carga la presentación, configura las opciones de diseño usando la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) para incluir las notas del orador, y luego guarda el archivo como PDF. El siguiente fragmento de código muestra cómo convertir una presentación de ejemplo a un PDF en la vista de diapositivas con notas.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Configurar opciones PDF para renderizar notas del orador.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Renderizar notas del orador debajo de la diapositiva.
        }
    };

    // Guardar la presentación en PDF con notas del orador.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 
Es posible que desee consultar el Conversor en línea de PowerPoint a PDF de Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion). 
{{% /alert %}}