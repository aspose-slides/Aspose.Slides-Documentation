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
- notas del presentador
- PDF con notas
- C++
- Aspose.Slides
description: "Convertir formatos PPT y PPTX a PDF con notas usando Aspose.Slides para C++. Conservar diseños y notas del presentador para presentaciones profesionales."
---
## **Visión general**

En este artículo aprenderá a convertir presentaciones de PowerPoint a formato PDF con notas del presentador utilizando Aspose.Slides. Esta guía cubrirá los pasos necesarios y proporcionará ejemplos de código para ayudarle a realizar esta tarea de manera eficiente. Al final de este artículo, podrá:

- Implementar el proceso de conversión para transformar diapositivas de PowerPoint en documentos PDF mientras se conservan las notas del presentador.
- Personalizar el PDF de salida para asegurarse de que las notas del presentador se incluyan y se formateen según sus requisitos.

Para establecer las dimensiones y la orientación de la página de notas antes de la exportación, consulte [Tamaño de página de notas](/slides/es/cpp/notes-size/).

## **Convertir PowerPoint a PDF con notas**

El método `Save` de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) se puede usar para convertir una presentación PPT o PPTX a un PDF con notas del presentador. Con Aspose.Slides, simplemente carga la presentación, configura las opciones de diseño utilizando la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/notescommentslayoutingoptions/) para incluir las notas del presentador, y luego guarda el archivo como PDF. El fragmento de código siguiente muestra cómo convertir una presentación de ejemplo a un PDF en vista de diapositiva de notas.

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

// Configurar opciones PDF para renderizar notas del presentador.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Renderizar notas del presentador debajo de la diapositiva.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Guardar la presentación en PDF con notas del presentador.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 

Puede que quiera consultar el [Convertidor en línea de PowerPoint a PDF de Aspose](https://products.aspose.app/slides/es/conversion).

{{% /alert %}}