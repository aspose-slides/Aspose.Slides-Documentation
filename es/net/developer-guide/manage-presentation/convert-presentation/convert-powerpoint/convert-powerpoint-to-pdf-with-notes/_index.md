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
description: "Convertir los formatos PPT y PPTX a PDF con notas utilizando Aspose.Slides para .NET. Preservar diseños y notas del orador para presentaciones profesionales."
---
## **Resumen**

En este artículo aprenderá a convertir presentaciones de PowerPoint a formato PDF con notas del orador utilizando Aspose.Slides. Esta guía cubrirá los pasos necesarios y proporcionará ejemplos de código para ayudarle a realizar esta tarea de manera eficiente. Al final de este artículo, podrá:

- Implementar el proceso de conversión para transformar diapositivas de PowerPoint en documentos PDF manteniendo las notas del orador.
- Personalizar el PDF de salida para garantizar que las notas del orador se incluyan y se formateen según sus requisitos.

Para establecer las dimensiones y la orientación de la página de notas antes de la exportación, consulte [Notes Page Size](/slides/es/net/notes-size/).

## **Convertir PowerPoint a PDF con notas**

El método `Save` de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) se puede utilizar para convertir una presentación PPT o PPTX a PDF con notas del orador. Con Aspose.Slides, simplemente carga la presentación, configura las opciones de diseño mediante la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/notescommentslayoutingoptions/) para incluir las notas del orador y luego guarda el archivo como PDF. El siguiente fragmento de código muestra cómo convertir una presentación de ejemplo a PDF en vista de diapositiva con notas.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert color="info" %}} 
Puede que desee consultar el [Convertidor en línea de PowerPoint a PDF de Aspose](https://products.aspose.app/slides/es/conversion). 
{{% /alert %}}