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
description: "Aprenda cómo convertir fácilmente presentaciones de PowerPoint (PPT, PPTX) a imágenes TIFF de alta calidad usando Aspose.Slides para C++, con ejemplos de código."
---

## **Visión general**

TIFF (**Tagged Image File Format**) es un formato de imagen rasterizada sin pérdida, de uso amplio, conocido por su calidad excepcional y la preservación detallada de los gráficos. Diseñadores, fotógrafos y maquetadores de escritorio suelen elegir TIFF para mantener capas, precisión de color y la configuración original en sus imágenes.

Usando Aspose.Slides, puede convertir sin esfuerzo sus diapositivas de PowerPoint (PPT, PPTX) y diapositivas OpenDocument (ODP) directamente en imágenes TIFF de alta calidad, garantizando que sus presentaciones mantengan la máxima fidelidad visual.

## **Convertir una presentación a TIFF**

Usando el método [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) proporcionado por la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), puede convertir rápidamente una presentación completa de PowerPoint a TIFF. Las imágenes TIFF resultantes corresponden al tamaño de diapositiva predeterminado.

Este código C++ muestra cómo convertir una presentación de PowerPoint a TIFF:
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```


## **Convertir una presentación a TIFF en blanco y negro**

El método [set_BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) en la clase [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) le permite especificar el algoritmo utilizado al convertir una diapositiva o imagen a color en un TIFF en blanco y negro. Tenga en cuenta que esta configuración se aplica solo cuando el método [set_CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) está establecido en `CCITT4` o `CCITT3`.

Supongamos que tenemos un archivo "sample.pptx" con la siguiente diapositiva:

![Una diapositiva de presentación](slide_black_and_white.png)

Este código C++ muestra cómo convertir la diapositiva a color en un TIFF en blanco y negro:
```cpp
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

Si necesita una imagen TIFF con dimensiones específicas, puede establecer los valores deseados mediante los métodos disponibles en [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/). Por ejemplo, el método [set_ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) le permite definir el tamaño de la imagen resultante.

Este código C++ muestra cómo convertir una presentación de PowerPoint a imágenes TIFF con un tamaño personalizado:
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Establecer el tipo de compresión.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Tipos de compresión:
    Default - Especifica el esquema de compresión predeterminado (LZW).
    None - Especifica que no se utiliza compresión.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// La profundidad depende del tipo de compresión y no puede establecerse manualmente.

// Establecer el DPI de la imagen.
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


## **Convertir una presentación a TIFF con formato de píxel de imagen personalizado**

Usando el método [set_PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) de la clase [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/), puede especificar el formato de píxel preferido para la imagen TIFF resultante.

Este código C++ muestra cómo convertir una presentación de PowerPoint a una imagen TIFF con un formato de píxel personalizado:
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat contiene los siguientes valores (según la documentación):
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


{{% alert title="Tip" color="primary" %}}
Descubra el [convertidor GRATUITO de PowerPoint a póster de Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Puedo convertir una diapositiva individual en lugar de toda la presentación de PowerPoint a TIFF?**

Sí. Aspose.Slides le permite convertir diapositivas individuales de presentaciones PowerPoint y OpenDocument en imágenes TIFF por separado.

**¿Existe algún límite en la cantidad de diapositivas al convertir una presentación a TIFF?**

No, Aspose.Slides no impone ninguna restricción en la cantidad de diapositivas. Puede convertir presentaciones de cualquier tamaño al formato TIFF.

**¿Se conservan las animaciones y efectos de transición de PowerPoint al convertir diapositivas a TIFF?**

No, TIFF es un formato de imagen estática. Por lo tanto, las animaciones y efectos de transición no se conservan; solo se exportan capturas estáticas de las diapositivas.