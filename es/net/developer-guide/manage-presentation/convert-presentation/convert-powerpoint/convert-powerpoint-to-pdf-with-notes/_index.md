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
- notas del presentador
- PDF con notas
- .NET
- C#
- Aspose.Slides
description: "Convertir formatos PPT y PPTX a PDF con notas usando Aspose.Slides para .NET. Conserva diseños y notas del presentador para presentaciones profesionales."
---
## **Descripción general**

En este artículo aprenderá a convertir presentaciones de PowerPoint al formato PDF con notas del presentador utilizando Aspose.Slides. Esta guía cubrirá los pasos necesarios y proporcionará ejemplos de código para ayudarle a realizar esta tarea de manera eficiente. Al final de este artículo podrá:

- Implementar el proceso de conversión para transformar las diapositivas de PowerPoint en documentos PDF manteniendo las notas del presentador.  
- Personalizar el PDF de salida para garantizar que las notas del presentador se incluyan y formateen según sus requisitos.

## **Convertir PowerPoint a PDF con notas**

El método `Save` en la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) puede usarse para convertir una presentación PPT o PPTX a un PDF con notas del presentador. Con Aspose.Slides, simplemente carga la presentación, configura las opciones de diseño mediante la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/notescommentslayoutingoptions/) para incluir las notas del presentador y, a continuación, guarda el archivo como PDF. El fragmento de código siguiente muestra cómo convertir una presentación de ejemplo a un PDF en vista de diapositiva con notas.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Configurar opciones PDF para renderizar notas del presentador.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Renderizar notas del presentador debajo de la diapositiva.
        }
    };

    // Guardar la presentación en PDF con notas del presentador.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Puede que desee consultar el Convertidor online de PowerPoint a PDF de Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/es/conversion). 
{{% /alert %}}