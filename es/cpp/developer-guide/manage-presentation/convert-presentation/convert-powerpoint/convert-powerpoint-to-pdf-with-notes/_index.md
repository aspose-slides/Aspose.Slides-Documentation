---
title: Convertir presentaciones de PowerPoint a PDF con notas en C++
linktitle: PowerPoint a PDF con notas
type: docs
weight: 50
url: /es/cpp/convert-powerpoint-to-pdf-with-notes/
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
- C++
- Aspose.Slides
description: "Convertir los formatos PPT y PPTX a PDF con notas usando Aspose.Slides para C++. Conservar diseños y notas del orador para presentaciones profesionales."
---
## **Resumen**

En este artículo aprenderá cómo convertir presentaciones de PowerPoint a formato PDF con notas del orador utilizando Aspose.Slides. Esta guía cubrirá los pasos necesarios y proporcionará ejemplos de código para ayudarle a realizar esta tarea de forma eficiente. Al final de este artículo podrá:

- Implementar el proceso de conversión para transformar las diapositivas de PowerPoint en documentos PDF conservando las notas del orador.
- Personalizar el PDF de salida para garantizar que las notas del orador se incluyan y se formateen según sus requisitos.

## **Convertir PowerPoint a PDF con notas**

El método `Save` en la [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) de la clase puede usarse para convertir una presentación PPT o PPTX a un PDF con notas del orador. Con Aspose.Slides, simplemente carga la presentación, configura las opciones de diseño usando la [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/notescommentslayoutingoptions/) para incluir las notas del orador y luego guarda el archivo como PDF. El siguiente fragmento de código muestra cómo convertir una presentación de ejemplo a PDF en vista de diapositiva de notas.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configurar opciones PDF para renderizar notas del orador.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Renderizar notas del orador debajo de la diapositiva.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Guardar la presentación en PDF con notas del orador.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Puede que desee consultar el [Convertidor en línea de PowerPoint a PDF](https://products.aspose.app/slides/es/conversion) de Aspose. 
{{% /alert %}}