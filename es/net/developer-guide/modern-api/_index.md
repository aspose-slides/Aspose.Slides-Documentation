---
title: API Moderna
type: docs
weight: 237
url: /net/modern-api/
keywords: "CrossPlatform API Moderna System.Drawing"
description: "API Moderna"
---

## Introducción

Históricamente, Aspose Slides tiene una dependencia de System.Drawing y tiene en la API pública las siguientes clases de allí:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

A partir de la versión 24.4, esta API pública se declara obsoleta.

Dado que el soporte para System.Drawing en versiones .NET6 y superiores se ha eliminado para versiones que no son de Windows ([cambio importante](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides ha implementado un enfoque de dos versiones de biblioteca:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - soporte para .NET6+ para Windows, .NETStandard para Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - tiene una dependencia de [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - versión para Windows/Linux/MacOS sin dependencias.

La inconveniencia de [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) es que implementa su propia versión de System.Drawing en el mismo espacio de nombres (para mantener la compatibilidad con versiones anteriores con la API pública). Así, cuando Aspose.Slides.NET6.CrossPlatform y System.Drawing de .NETFramework o paquete System.Drawing.Common se utilizan al mismo tiempo, ocurre un conflicto de nombres a menos que se use un alias.

Con el fin de eliminar dependencias de System.Drawing en el paquete principal Aspose.Slides.NET, añadimos lo que se denomina "API Moderna", es decir, la API que debe ser utilizada en lugar de la obsoleta, cuyas firmas contienen dependencias en los siguientes tipos de System.Drawing: Image y Bitmap. PrinterSettings y Graphics se declaran obsoletas y su soporte se elimina de la API pública de Slides.

La eliminación de la API pública obsoleta con dependencias en System.Drawing estará en la versión 24.8.

## API Moderna

Se añadieron las siguientes clases y enums a la API pública:

- Aspose.Slides.IImage - representa la imagen raster o vectorial.
- Aspose.Slides.ImageFormat - representa el formato de archivo de la imagen.
- Aspose.Slides.Images - métodos para instanciar y trabajar con la interfaz IImage.

Tenga en cuenta que IImage es desechable (implementa la interfaz IDisposable y su uso debe estar envuelto en using o liberado de otra manera conveniente).

Un escenario típico de uso de la nueva API puede verse de la siguiente manera:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // instanciar una instancia desechable de IImage desde el archivo en el disco.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // crear una imagen de PowerPoint añadiendo una instancia de IImage a las imágenes de la presentación.
        ppImage = pres.Images.AddImage(image);
    }

    // añadir una forma de imagen en la diapositiva #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // obtener una instancia de IImage que representa la diapositiva #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // guardar la imagen en el disco.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## Reemplazo de código antiguo con API Moderna

Para facilitar la transición, la interfaz de la nueva IImage repite las firmas separadas de las clases Image y Bitmap. En general, solo necesitará reemplazar la llamada al antiguo método utilizando System.Drawing con el nuevo.

### Obtener una miniatura de diapositiva

Código utilizando una API obsoleta:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

API Moderna:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### Obtener una miniatura de forma

Código utilizando una API obsoleta:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

API Moderna:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### Obtener una miniatura de presentación

Código utilizando una API obsoleta:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var bitmaps = pres.GetThumbnails(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < bitmaps.Length; index++)
        {
            Bitmap thumbnail = bitmaps[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (Bitmap bitmap in bitmaps)
        {
            bitmap.Dispose();
        }
    }
}
```

API Moderna:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var images = pres.GetImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < images.Length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (IImage image in images)
        {
            image.Dispose();
        }
    }
}
```

### Añadir una imagen a una presentación

Código utilizando una API obsoleta:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image image = Image.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

API Moderna:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (IImage image = Aspose.Slides.Images.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```
## Métodos/propiedades que se eliminarán y su reemplazo en API Moderna

### Presentación
| Firma del Método                                   | Firma del Método de Reemplazo                                 |
|---------------------------------------------------|---------------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | Se eliminará por completo |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | Se eliminará por completo |
| public void Print()                                 | Se eliminará por completo                                   |
| public void Print(PrinterSettings printerSettings)  | Se eliminará por completo                                   |
| public void Print(string printerName)               | Se eliminará por completo                                   |
| public void Print(PrinterSettings printerSettings, string presName) | Se eliminará por completo                                   |

### Forma
| Firma del Método                                                      | Firma del Método de Reemplazo                                   |
|----------------------------------------------------------------------|-----------------------------------------------------------------|
| public Bitmap GetThumbnail()                                          | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage)                                                           |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### Diapositiva
| Firma del Método                                                      | Firma del Método de Reemplazo                                     |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY)                | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5)                                 |
| public Bitmap GetThumbnail()                                         | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage)                                                              |
| public Bitmap GetThumbnail(IRenderingOptions options)                | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1)                                  |
| public Bitmap GetThumbnail(Size imageSize)                           | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6)                                             |
| public Bitmap GetThumbnail(ITiffOptions options)                    | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4)                                      |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3)               |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | Se eliminará por completo                                       |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | Se eliminará por completo                                  |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | Se eliminará por completo                                         |

#### Salida
| Firma del Método                                                | Firma del Método de Reemplazo                                |
|-----------------------------------------------------------------|---------------------------------------------------------------|
| public IOutputFile Add(string path, Image image)               | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1)                               |

### ImageCollection
| Firma del Método                          | Firma del Método de Reemplazo               |
|-------------------------------------------|----------------------------------------------|
| IPPImage AddImage(Image image)           | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage)                      |

### ImageWrapperFactory
| Firma del Método                                         | Firma del Método de Reemplazo                            |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image)           | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper)                        |

### PPImage
| Firma/Método                                         | Firma del Método de Reemplazo   |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage)   | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage)            |
| Image SystemImage { get; }          | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image)                    |

### PatternFormat
| Firma del Método                                          | Firma del Método de Reemplazo                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1)         |
| Bitmap GetTileImage(Color styleColor)                     | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile)                           |

### IPatternFormatEffectiveData
| Firma del Método                                          | Firma del Método de Reemplazo                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage)                    |

## El soporte para Aspose.Slides.NET6.CrossPlatform se descontinuará

Tras el lanzamiento de [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) versión 24.8, el soporte para [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) se descontinuará.

## El soporte de API para Graphics y PrinterSettings se descontinuará

La clase [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) no es compatible con versiones multiplataforma de .NET6 y superiores. En Aspose Slides, se eliminará la parte de la API que la utiliza:
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Además, se eliminará la parte de la API relacionada con la impresión:

[Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)