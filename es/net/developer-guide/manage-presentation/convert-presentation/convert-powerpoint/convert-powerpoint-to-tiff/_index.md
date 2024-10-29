---
title: Convertir PowerPoint a TIFF
type: docs
weight: 90
url: /es/net/convert-powerpoint-to-tiff/
keywords: "Convertir presentación de PowerPoint, PowerPoint a TIFF, PPT a TIFF, PPTX a TIFF, C#, Csharp, .NET, Aspose.Slides"
description: "Convierte presentación de PowerPoint a TIFF en C# o .NET."

---

TIFF (**Tagged Image File Format**) es un formato de imagen rasterizada sin pérdida y de alta calidad. Los profesionales utilizan TIFF para sus propósitos de diseño, fotografía y autoedición. Por ejemplo, si desea preservar capas y configuraciones en su diseño o imagen, puede que desee guardar su trabajo como un archivo de imagen TIFF.

Aspose.Slides le permite convertir las diapositivas de PowerPoint directamente a TIFF.

{{% alert title="Consejo" color="primary" %}}

Es posible que desee consultar el [convertidor GRATUITO de PowerPoint a Póster de Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Convertir PowerPoint a TIFF**

Usando el método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) expuesto por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), puede convertir rápidamente una presentación de PowerPoint completa a TIFF. Las imágenes TIFF resultantes corresponden al tamaño predeterminado de las diapositivas.

Este código C# le muestra cómo convertir PowerPoint a TIFF:

```c#
// Instancia un objeto Presentation que representa un archivo de presentación
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    // Guarda la presentación como TIFF
    presentation.Save("Tiffoutput_out.tiff", SaveFormat.Tiff);
}
```

## **Convertir PowerPoint a TIFF en blanco y negro**

En Aspose.Slides 23.10, Aspose.Slides agregó una nueva propiedad ([BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/)) a la clase [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) para permitirle especificar el algoritmo que se sigue cuando una diapositiva o imagen de color se convierte a TIFF en blanco y negro. Tenga en cuenta que esta configuración se aplica solo cuando la propiedad [CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) está establecida en `CCITT4` o `CCITT3`.

Este código C# le muestra cómo convertir una diapositiva o imagen de color a TIFF en blanco y negro:

```c#
var tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
```

## **Convertir PowerPoint a TIFF con tamaño personalizado**

Si necesita una imagen TIFF con dimensiones definidas, puede definir sus figuras preferidas a través de las propiedades proporcionadas en [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/). Usando la propiedad [ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/), por ejemplo, puede establecer un tamaño para la imagen resultante.

Este código C# le muestra cómo convertir PowerPoint a imágenes TIFF con tamaño personalizado:

```c#
// Instancia un objeto Presentation que representa un archivo de Presentación
using (Presentation pres = new Presentation("Convert_Tiff_Custom.pptx"))
{
    // Instancia la clase TiffOptions
    TiffOptions opts = new TiffOptions();

    // Establece el tipo de compresión
    opts.CompressionType = TiffCompressionTypes.Default;

    INotesCommentsLayoutingOptions notesOptions = opts.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;
    // Tipos de Compresión

    // Predeterminado - Especifica el esquema de compresión predeterminado (LZW).
    // Ninguno - Especifica sin compresión.
    // CCITT3
    // CCITT4
    // LZW
    // RLE

    // La profundidad depende del tipo de compresión y no se puede establecer manualmente.
    // La unidad de resolución siempre es igual a "2" (puntos por pulgada)

    // Establece la DPI de la imagen
    opts.DpiX = 200;
    opts.DpiY = 100;

    // Establece el tamaño de la imagen
    opts.ImageSize = new Size(1728, 1078);

    // Guarda la presentación en TIFF con el tamaño especificado
    pres.Save("TiffWithCustomSize_out.tiff", SaveFormat.Tiff, opts);
}
```

## **Convertir PowerPoint a TIFF con formato de píxel de imagen personalizado**

Usando la propiedad [PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) de la clase [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions), puede especificar su formato de píxel preferido para la imagen TIFF resultante.

Este código C# le muestra cómo convertir PowerPoint a imagen TIFF con formato de píxel personalizado:

```c#
// Instancia un objeto Presentation que representa un archivo de Presentación
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    TiffOptions options = new TiffOptions();
   
    options.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat contiene los siguientes valores (según lo indicado en la documentación):
    Format1bppIndexed; // 1 bit por píxel, indexado.
    Format4bppIndexed; // 4 bits por píxel, indexado.
    Format8bppIndexed; // 8 bits por píxel, indexado.
    Format24bppRgb; // 24 bits por píxel, RGB.
    Format32bppArgb; // 32 bits por píxel, ARGB.
    */

    // Guarda la presentación en TIFF con el tamaño de imagen especificado
    presentation.Save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat.Tiff, options);
}
```