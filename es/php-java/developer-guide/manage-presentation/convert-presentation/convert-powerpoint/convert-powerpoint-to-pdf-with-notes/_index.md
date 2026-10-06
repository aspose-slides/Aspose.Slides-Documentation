---
title: Convertir presentaciones de PowerPoint a PDF con notas en PHP
linktitle: PowerPoint a PDF con notas
type: docs
weight: 50
url: /es/php-java/convert-powerpoint-to-pdf-with-notes/
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
- PHP
- Aspose.Slides
description: "Convertir los formatos PPT y PPTX a PDF con notas usando Aspose.Slides para PHP mediante Java. Preserve los diseños y las notas del presentador para presentaciones profesionales."
---
## **Visión general**

En este artículo aprenderá a convertir presentaciones de PowerPoint al formato PDF con notas del presentador utilizando Aspose.Slides. Esta guía cubrirá los pasos necesarios y proporcionará ejemplos de código para ayudarle a realizar esta tarea de manera eficiente. Al final de este artículo podrá:

- Implementar el proceso de conversión para transformar diapositivas de PowerPoint en documentos PDF conservando las notas del presentador.
- Personalizar el PDF de salida para garantizar que las notas del presentador se incluyan y se formateen según sus requisitos.

Para establecer las dimensiones y la orientación de la página de notas antes de la exportación, consulte [Notes Page Size](/slides/es/php-java/notes-size/).

## **Convertir PowerPoint a PDF con notas**

El método `save` de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) puede usarse para convertir una presentación PPT o PPTX a PDF con notas del presentador. Con Aspose.Slides, simplemente carga la presentación, configura las opciones de diseño mediante la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/notescommentslayoutingoptions/) para incluir las notas del presentador y, a continuación, guarda el archivo como PDF. El siguiente fragmento de código muestra cómo convertir una presentación de ejemplo a PDF en la vista de diapositiva de notas.

```php
$presentation = new Presentation("sample.pptx");

// Configurar opciones PDF para renderizar notas del presentador.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Renderizar notas del presentador debajo de la diapositiva.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Guardar la presentación en PDF con notas del presentador.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}

Puede que le interese el Conversor en línea de PowerPoint a PDF de Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/es/conversion).

{{% /alert %}}