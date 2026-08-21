---
title: Convertir presentaciones de PowerPoint a TIFF en C++
titlelink: PowerPoint a TIFF
type: docs
weight: 90
url: /es/cpp/convert-powerpoint-to-tiff/
keywords:
- convertir PowerPoint
- convertir OpenDocument
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
- C++
- Aspose.Slides
description: "Aprende a convertir fácilmente presentaciones de PowerPoint (PPT, PPTX) a imágenes TIFF de alta calidad usando Aspose.Slides para C++, con ejemplos de código."
---
## **Introducción**

TIFF (**Tagged Image File Format**) es un formato de imagen raster sin pérdida, muy usado, conocido por su calidad excepcional y la preservación detallada de los gráficos. Diseñadores, fotógrafos y maquetadores de escritorio suelen elegir TIFF para mantener capas, precisión de color y la configuración original en sus imágenes.

Con Aspose.Slides, puedes convertir sin esfuerzo tus diapositivas de PowerPoint (PPT, PPTX) y diapositivas OpenDocument (ODP) directamente en imágenes TIFF de alta calidad, asegurando que tus presentaciones mantengan la máxima fidelidad visual.

## **Convertir una presentación a TIFF**

Usando el método [Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/) provisto por la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/), puedes convertir rápidamente una presentación completa de PowerPoint a TIFF. Las imágenes TIFF resultantes corresponden al tamaño de diapositiva predeterminado.

Este código C++ muestra cómo convertir una presentación de PowerPoint a TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar la clase Presentation que representa un archivo de presentación (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Convertir una presentación a TIFF en blanco y negro**

El método [set_BwConversionMode](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) en la clase [TiffOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/) permite especificar el algoritmo utilizado al convertir una diapositiva o imagen en color a un TIFF en blanco y negro. Ten en cuenta que esta configuración se aplica solo cuando el método [set_CompressionType](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) está configurado a `CCITT4` o `CCITT3`.

{{% alert color="info" title="Nota" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) es una configuración a nivel de exportación que selecciona un algoritmo de conversión de píxeles para la imagen TIFF completa. Para definir cómo debe aparecer una forma individual cuando el modo de visualización en blanco y negro está activo, usa [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/set_blackwhitemode/). Consulta [Control Black-and-White Rendering for Shapes](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) para ejemplos.
{{% /alert %}}

Supongamos que tenemos un archivo "sample.pptx" con la siguiente diapositiva:

![Una diapositiva de presentación](slide_black_and_white.png)

Este código C++ muestra cómo convertir la diapositiva coloreada a un TIFF en blanco y negro:

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

El resultado:

![TIFF en blanco y negro](TIFF_black_and_white.png)

## **Convertir una presentación a TIFF con tamaño personalizado**

Si necesitas una imagen TIFF con dimensiones específicas, puedes establecer los valores deseados usando los métodos disponibles en [TiffOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/). Por ejemplo, el método [set_ImageSize](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/set_imagesize/) te permite definir el tamaño de la imagen resultante.

Este código C++ muestra cómo convertir una presentación de PowerPoint a imágenes TIFF con un tamaño personalizado:

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar la clase Presentation que representa un archivo de presentación (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Establecer el tipo de compresión.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Tipos de compresión:
    Default - Especifica el esquema de compresión predeterminado (LZW).
    None - Especifica que no hay compresión.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// La profundidad depende del tipo de compresión y no puede establecerse manualmente.

// Establecer la DPI de la imagen.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Establecer el tamaño de la imagen.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Guardar la presentación como TIFF con el tamaño especificado.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Convertir una presentación a TIFF con formato de píxel personalizado**

Usando el método [set_PixelFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) de la clase [TiffOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/), puedes especificar el formato de píxel preferido para la imagen TIFF resultante.

Este código C++ muestra cómo convertir una presentación de PowerPoint a una imagen TIFF con un formato de píxel personalizado:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar la clase Presentation que representa un archivo de presentación (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat contiene los siguientes valores (según lo indicado en la documentación):
    Format1bppIndexed - 1 bit por píxel, indexado.
    Format4bppIndexed - 4 bits por píxel, indexado.
    Format8bppIndexed - 8 bits por píxel, indexado.
    Format24bppRgb    - 24 bits por píxel, RGB.
    Format32bppArgb   - 32 bits por píxel, ARGB.
*/

// Guardar la presentación como TIFF con el tamaño de imagen especificado.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Consejo" color="info" %}}
Echa un vistazo al [convertidor GRATUITO de PowerPoint a póster de Aspose](https://products.aspose.app/slides/es/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Puedo convertir una diapositiva individual en lugar de toda la presentación de PowerPoint a TIFF?**

Sí. Aspose.Slides permite convertir diapositivas individuales de presentaciones PowerPoint y OpenDocument en imágenes TIFF por separado.

**¿Existe algún límite en el número de diapositivas al convertir una presentación a TIFF?**

No, Aspose.Slides no impone restricciones en el número de diapositivas. Puedes convertir presentaciones de cualquier tamaño al formato TIFF.

**¿Se conservan las animaciones y los efectos de transición de PowerPoint al convertir diapositivas a TIFF?**

No, TIFF es un formato de imagen estático. Por lo tanto, las animaciones y los efectos de transición no se conservan; solo se exportan instantáneas estáticas de las diapositivas.