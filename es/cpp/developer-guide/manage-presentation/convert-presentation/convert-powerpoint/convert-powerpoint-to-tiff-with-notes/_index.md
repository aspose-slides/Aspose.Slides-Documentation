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
description: "Convertir presentaciones PowerPoint a TIFF con notas usando Aspose.Slides para C++. Aprenda cómo exportar diapositivas con notas del orador de manera eficiente."
---

## **Visión general**

Aspose.Slides for C++ proporciona una solución sencilla para convertir presentaciones PowerPoint y OpenDocument (PPT, PPTX y ODP) con notas al formato TIFF. Este formato se usa ampliamente para el almacenamiento de imágenes de alta calidad, impresión y archivado de documentos. Con Aspose.Slides, no solo puedes exportar presentaciones completas con notas del orador, sino también generar miniaturas de diapositivas en la vista de Diapositiva de notas. El proceso de conversión es simple y eficiente, utilizando el método `Save` de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) para transformar toda la presentación en una serie de imágenes TIFF conservando las notas y el diseño.

## **Convertir una presentación a TIFF con notas**

Guardar una presentación PowerPoint o OpenDocument en TIFF con notas usando Aspose.Slides for C++ implica los siguientes pasos:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/): cargar un archivo PowerPoint o OpenDocument.  
2. Configurar las opciones de disposición de salida: usar la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) para especificar cómo se deben mostrar las notas y los comentarios.  
3. Guardar la presentación en TIFF: pasar las opciones configuradas al método [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

Supongamos que tenemos un archivo **speaker_notes.pptx** con la siguiente diapositiva:

![La diapositiva de la presentación con notas del orador](slide_with_notes.png)

El fragmento de código a continuación muestra cómo convertir la presentación a una imagen TIFF en la vista de Diapositiva de notas usando el método [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Mostrar las notas debajo de la diapositiva.

// Configurar las opciones TIFF con el diseño de notas.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Guardar la presentación en TIFF con las notas del orador.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


El resultado:

![La imagen TIFF con notas del orador](TIFF_with_notes.png)

{{% alert title="Consejo" color="primary" %}}

Descubre el [Convertidor gratuito de PowerPoint a póster de Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**¿Puedo controlar la posición del área de notas en el TIFF resultante?**

Sí. Usa la [configuración de diseño de notas](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) para elegir entre opciones como `None`, `BottomTruncated` o `BottomFull`, que respectivamente ocultan las notas, las ajustan en una sola página o permiten que fluyan a páginas adicionales.

**¿Cómo puedo reducir el tamaño de un archivo TIFF con notas sin pérdida visible de calidad?**

Elige una [compresión eficiente](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (por ejemplo, `LZW` o `RLE`), establece un DPI razonable y, si es aceptable, usa un formato de píxel más bajo [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (como 8 bpp o 1 bpp para monocromo). Reducir ligeramente las [dimensiones de la imagen](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) también ayuda sin afectar notablemente la legibilidad.

**¿Afecta la fuente de las notas al resultado si las fuentes originales no están instaladas en el sistema?**

Sí. Las fuentes faltantes provocan una [sustitución](/slides/es/cpp/font-selection-sequence/), lo que puede modificar las métricas y la apariencia del texto. Para evitarlo, [proporciona las fuentes requeridas](/slides/es/cpp/custom-font/) o establece una [fuente de reserva](/slides/es/cpp/fallback-font/) predeterminada para que se usen los tipos de letra previstos.