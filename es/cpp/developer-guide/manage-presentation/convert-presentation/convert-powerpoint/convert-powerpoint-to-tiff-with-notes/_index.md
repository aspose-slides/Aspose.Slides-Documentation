---
title: Convertir presentaciones PowerPoint a TIFF con notas en C++
linktitle: PowerPoint a TIFF con notas
type: docs
weight: 100
url: /es/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a TIFF
- presentación a TIFF
- diapositiva a TIFF
- PPT a TIFF
- PPTX a TIFF
- guardar PPT como TIFF
- guardar PPTX como TIFF
- exportar PPT a TIFF
- exportar PPTX a TIFF
- PowerPoint con notas
- presentación con notas
- diapositiva con notas
- PPT con notas
- PPTX con notas
- TIFF con notas
- C++
- Aspose.Slides
description: "Convertir presentaciones PowerPoint a TIFF con notas usando Aspose.Slides para C++. Aprende a exportar diapositivas con notas del presentador de forma eficiente."
---
## **Introducción**

Aspose.Slides for C++ ofrece una solución sencilla para convertir presentaciones de PowerPoint y OpenDocument (PPT, PPTX y ODP) con notas al formato TIFF. Este formato se usa ampliamente para el almacenamiento de imágenes de alta calidad, la impresión y el archivo de documentos. Con Aspose.Slides, no solo puede exportar presentaciones completas con notas del presentador, sino también generar miniaturas de diapositivas en la vista de diapositiva de notas. El proceso de conversión es simple y eficiente, utilizando el método `Save` de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) para transformar toda la presentación en una serie de imágenes TIFF conservando las notas y el diseño.

## **Convertir una presentación a TIFF con notas**

Guardar una presentación PowerPoint o OpenDocument en TIFF con notas usando Aspose.Slides for C++ implica los siguientes pasos:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/): Cargar un archivo PowerPoint o OpenDocument.  
1. Configurar las opciones de diseño de salida: Utilizar la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/notescommentslayoutingoptions/) para especificar cómo deben mostrarse las notas y los comentarios.  
1. Guardar la presentación en TIFF: Pasar las opciones configuradas al método [Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/).

Supongamos que tenemos un archivo "speaker_notes.pptx" con la siguiente diapositiva:

![La diapositiva de la presentación con notas del presentador](slide_with_notes.png)

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Mostrar las notas debajo de la diapositiva.

// Configure the TIFF options with Notes layouting.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

El resultado:

![La imagen TIFF con notas del presentador](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Echa un vistazo a Aspose [Convertidor gratuito de PowerPoint a póster](https://products.aspose.app/slides/es/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Preguntas frecuentes**

### ¿Puedo controlar la posición del área de notas en el TIFF resultante?

Sí. Utilice la [notes layout settings](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) para elegir entre opciones como `None`, `BottomTruncated` o `BottomFull`, que respectivamente ocultan las notas, las ajustan en una sola página o permiten que continúen en páginas adicionales.

### ¿Cómo puedo reducir el tamaño de un archivo TIFF con notas sin una pérdida visible de calidad?

Elija una [efficient compression](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (por ejemplo, `LZW` o `RLE`), establezca una DPI razonable y, si es aceptable, utilice un [pixel format](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) más bajo (como 8 bpp o 1 bpp para monocromo). Reducir ligeramente las [image dimensions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/set_imagesize/) también puede ayudar sin afectar notablemente la legibilidad.

### ¿Afecta la fuente de las notas al resultado si las fuentes originales no están instaladas en el sistema?

Sí. Las fuentes faltantes provocan una [substitution](/slides/es/cpp/font-selection-sequence/), lo que puede cambiar las métricas y la apariencia del texto. Para evitarlo, [supply the required fonts](/slides/es/cpp/custom-font/) o establezca una [fallback font](/slides/es/cpp/fallback-font/) predeterminada para que se utilicen los tipos de letra previstos.