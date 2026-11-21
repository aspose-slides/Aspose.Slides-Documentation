---
title: Convertir presentaciones de PowerPoint a PDF con notas en JavaScript
linktitle: PowerPoint a PDF con notas
type: docs
weight: 50
url: /es/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir formatos PPT y PPTX a PDF con notas en JavaScript usando Aspose.Slides para Node.js. Conservar diseños y notas del orador para presentaciones profesionales."
---
## **Visión general**

En este artículo aprenderá cómo convertir presentaciones de PowerPoint al formato PDF con notas del orador utilizando Aspose.Slides. Esta guía cubrirá los pasos necesarios y proporcionará ejemplos de código para ayudarle a realizar esta tarea de manera eficiente. Al final de este artículo, podrá:

- Implementar el proceso de conversión para transformar diapositivas de PowerPoint en documentos PDF conservando las notas del orador.
- Personalizar el PDF de salida para garantizar que las notas del orador se incluyan y se formateen según sus requisitos.

Para establecer las dimensiones y la orientación de la página de notas antes de la exportación, consulte [Tamaño de página de notas](/slides/es/nodejs-java/notes-size/).

## **Convertir PowerPoint a PDF con notas**

El método `save` de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) se puede usar para convertir una presentación PPT o PPTX a un PDF con notas del orador. Con Aspose.Slides, simplemente carga la presentación, configura las opciones de diseño utilizando la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notescommentslayoutingoptions/) para incluir las notas del orador y luego guarda el archivo como PDF. El siguiente fragmento de código muestra cómo convertir una presentación de ejemplo a PDF en la vista de diapositiva de notas.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// Configurar opciones PDF para renderizar notas del orador.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Renderizar notas del orador debajo de la diapositiva.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Guardar la presentación en PDF con notas del orador.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Nota" %}}

Es posible que desee probar el Aspose [Convertidor en línea de PowerPoint a PDF](https://products.aspose.app/slides/es/conversion).

{{% /alert %}}