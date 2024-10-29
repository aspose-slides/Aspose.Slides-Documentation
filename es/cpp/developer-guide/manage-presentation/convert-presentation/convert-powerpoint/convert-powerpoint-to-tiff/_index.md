---
title: Convertir PowerPoint a TIFF
type: docs
weight: 90
url: /es/cpp/convert-powerpoint-to-tiff/
keywords: "Convertir presentación de PowerPoint, PowerPoint a TIFF, PPT a TIFF, PPTX a TIFF, C++, CPP, Aspose.Slides"
description: "Convertir presentación de PowerPoint a TIFF en C++"
---

**TIFF** (Formato de archivo de imagen etiquetada) es un formato de imagen de trama sin pérdida y de alta calidad. Los profesionales utilizan TIFF para sus propósitos de diseño, fotografía y edición de escritorio. Por ejemplo, si desea conservar capas y configuraciones en su diseño o imagen, es posible que desee guardar su trabajo como un archivo de imagen TIFF.

Aspose.Slides le permite convertir las diapositivas de PowerPoint directamente a TIFF.

{{% alert title="Consejo" color="primary" %}}

Es posible que desee consultar el [convertidor GRATUITO de PowerPoint a Póster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) de Aspose.

{{% /alert %}}

## **Convertir PowerPoint a TIFF**

Utilizando el método [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) expuesto por la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), puede convertir rápidamente una presentación de PowerPoint completa a TIFF. Las imágenes TIFF resultantes corresponden al tamaño predeterminado de las diapositivas.

Este código en C++ le muestra cómo convertir PowerPoint a TIFF:

```c++
// La ruta al directorio de documentos.
String dataDir = GetDataPath();

// Instancia un objeto Presentation que representa un archivo de presentación
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

// Guarda la presentación como TIFF
presentation->Save(dataDir + u"Tiffoutput_out.tiff", SaveFormat::Tiff);
```

## **Convertir PowerPoint a TIFF en Blanco y Negro**

En Aspose.Slides 23.10, Aspose.Slides agregó una nueva propiedad ([BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/)) a la clase [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) para permitirle especificar el algoritmo que se sigue cuando una diapositiva o imagen en color se convierte a un TIFF en blanco y negro. Tenga en cuenta que esta configuración se aplica solo cuando la propiedad [CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) está configurada en `CCITT4` o `CCITT3`.

Este código en C++ le muestra cómo convertir una diapositiva o imagen en color a TIFF en blanco y negro:

```c++
System::SharedPtr<TiffOptions> tiffOptions = System::MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);
```

## **Convertir PowerPoint a TIFF con Tamaño Personalizado**

Si requiere una imagen TIFF con dimensiones definidas, puede definir sus figuras preferidas a través de las propiedades proporcionadas en [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options). Utilizando la propiedad [ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/), por ejemplo, puede establecer un tamaño para la imagen resultante.

Este código en C++ le muestra cómo convertir PowerPoint a imágenes TIFF con tamaño personalizado:

```c++
// La ruta al directorio de documentos.
System::String dataDir = GetDataPath();

// Instancia un objeto Presentation que representa un archivo de presentación
auto pres = System::MakeObject<Presentation>(dataDir + u"Convert_Tiff_Custom.pptx");
    
// Instancia la clase TiffOptions
auto opts = System::MakeObject<TiffOptions>();

// Establece el tipo de compresión
opts->set_CompressionType(TiffCompressionTypes::Default);

auto notesOptions = opts->get_NotesCommentsLayouting();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
// Tipos de compresión

// Default - Especifica el esquema de compresión por defecto (LZW).
// None - Especifica sin compresión.
// CCITT3
// CCITT4
// LZW
// RLE

// La profundidad depende del tipo de compresión y no se puede establecer manualmente.
// La unidad de resolución siempre es igual a "2" (puntos por pulgada)

// Establece el DPI de la imagen
opts->set_DpiX(200);
opts->set_DpiY(100);

// Establece el tamaño de la imagen
opts->set_ImageSize(System::Drawing::Size(1728, 1078));

// Guarda la presentación en TIFF con el tamaño especificado
pres->Save(dataDir + u"TiffWithCustomSize_out.tiff", SaveFormat::Tiff, opts);
```


## **Convertir PowerPoint a TIFF con Formato de Píxel de Imagen Personalizado**

Utilizando la propiedad [PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) de la clase [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options), puede especificar su formato de píxel preferido para la imagen TIFF resultante.

Este código en C++ le muestra cómo convertir PowerPoint a imagen TIFF con formato de píxel personalizado:

```c++
// La ruta al directorio de documentos.
System::String dataDir = GetDataPath();

// Instancia un objeto Presentation que representa un archivo de presentación
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

auto options = System::MakeObject<TiffOptions>();
options->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat contiene los siguientes valores (como se puede ver en la documentación):
Format1bppIndexed; // 1 bit por píxel, indexado.
Format4bppIndexed; // 4 bits por píxel, indexado.
Format8bppIndexed; // 8 bits por píxel, indexado.
Format24bppRgb; // 24 bits por píxel, RGB.
Format32bppArgb; // 32 bits por píxel, ARGB.
*/

// Guarda la presentación en TIFF con el formato de píxel especificado
presentation->Save(dataDir + u"Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat::Tiff, options);
```