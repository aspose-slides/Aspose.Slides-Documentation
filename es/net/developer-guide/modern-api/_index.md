---
title: Mejorar el procesamiento de imágenes con la API moderna
linktitle: API moderna
type: docs
weight: 237
url: /es/net/modern-api/
keywords:
- System.Drawing
- API moderna
- dibujo
- miniatura de diapositiva
- diapositiva a imagen
- miniatura de forma
- forma a imagen
- miniatura de presentación
- presentación a imágenes
- añadir imagen
- añadir foto
- .NET
- C#
- Aspose.Slides
description: "Modernice el procesamiento de imágenes de diapositivas sustituyendo las API de imágenes obsoletas por la API Moderna de .NET para una automatización fluida de PowerPoint y OpenDocument."
---
## **Introducción**

Históricamente, Aspose Slides dependía de System.Drawing y exponía en la API pública las siguientes clases:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

A partir de la versión 24.4, esta API pública se declara obsoleta.

Como el soporte de System.Drawing en versiones .NET6 y superiores se elimina para plataformas distintas de Windows ([cambio importante](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides ha implementado un enfoque de dos paquetes:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – soporte para .NET6+ en Windows, .NETStandard para Windows/Linux/macOS, .NETFramework 2+ (Windows).  
  - depende de [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – versión para Windows/Linux/macOS sin dependencias.

El inconveniente de [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) es que implementa su propia versión de System.Drawing en el mismo espacio de nombres (para mantener la compatibilidad con la API pública). Por ello, si se utilizan Aspose.Slides.NET6.CrossPlatform y System.Drawing del .NET Framework o del paquete System.Drawing.Common al mismo tiempo, se produce un conflicto de nombres a menos que se use alias.

Para eliminar las dependencias de System.Drawing del paquete principal Aspose.Slides.NET, añadimos la llamada “API moderna”, es decir, la API que debe usarse en sustitución de la obsoleta, cuyas firmas contienen dependencias de los siguientes tipos de System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) y [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) y [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) se declaran obsoletos y su soporte se elimina de la API pública de Slides.

En las versiones actuales, trate la API pública que depende de System.Drawing como heredada/obsoleta. Use la API moderna para código nuevo y al migrar flujos de trabajo de procesamiento de imágenes existentes.

## **API moderna**

Se añadieron las siguientes clases y enumeraciones a la API pública:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) – representa la imagen raster o vectorial.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/es/net/aspose.slides/imageformat/) – representa el formato de archivo de la imagen.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/es/net/aspose.slides/images/) – métodos para instanciar y trabajar con la interfaz [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/).

Tenga en cuenta que [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) es desechable (implementa la interfaz [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) y su uso debe envolver un `using` o disponerse de otra forma conveniente).

Use `GetImage` para renderizar una diapositiva o forma individual. Use `GetImages` para renderizar varias diapositivas de una presentación. Use los métodos de [Images](https://reference.aspose.com/slides/es/net/aspose.slides/images/) para cargar imágenes, `AddImage` con [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) para añadirlas a una presentación, y `ReplaceImage` con [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) para actualizar una imagen existente en una presentación.

Un escenario típico de uso de la nueva API puede ser el siguiente:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // instanciar una instancia desechable de IImage desde el archivo en disco.  
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

## **Reemplazo del código antiguo con la API moderna**

Para facilitar la transición, la interfaz de la nueva [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) replica las firmas separadas de las clases [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) y [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). En general, solo será necesario sustituir la llamada al método antiguo que usa System.Drawing por la nueva.

### **Obtención de una miniatura de diapositiva**

API heredada/obsoleta:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

API moderna:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Obtención de una miniatura de forma**

API heredada/obsoleta:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

API moderna:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Obtención de una miniatura de presentación**

API heredada/obsoleta:

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

API moderna:

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

### **Añadir una imagen a una presentación**

API heredada/obsoleta:

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

API moderna:

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

## **Métodos/propiedades obsoletos y su sustitución en la API moderna**

### **Presentation**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No hay sustitución en la API moderna |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No hay sustitución en la API moderna |
| public void Print() | No hay sustitución en la API moderna |
| public void Print(PrinterSettings printerSettings) | No hay sustitución en la API moderna |
| public void Print(string printerName) | No hay sustitución en la API moderna |
| public void Print(PrinterSettings printerSettings, string presName) | No hay sustitución en la API moderna |

### **Shape**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/es/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/es/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/es/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/es/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/es/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/es/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/es/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No hay sustitución en la API moderna |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No hay sustitución en la API moderna |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No hay sustitución en la API moderna |

### **Output**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/es/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/es/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/es/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Firma del método/propiedad | Firma del método de sustitución |
|----------------------------|---------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/es/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/es/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/es/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/es/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/es/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Compatibilidad de la API con Graphics y PrinterSettings**

La clase [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) no se soporta en versiones multiplataforma de .NET6 y superiores. En Aspose Slides, utilice los métodos de renderizado de imágenes de la API moderna en lugar de la API que renderiza a [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/es/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/es/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/es/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/es/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Asimismo, la API relacionada con la impresión mediante [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) no tiene sustitución directa en la API moderna:

[IPresentation](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/print/#print_2)

## **Preguntas frecuentes**

**¿Por qué se eliminó [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)?**

El soporte de [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) se declara obsoleto en la API pública para unificar el trabajo con renderizado e imágenes, eliminar dependencias específicas de la plataforma y pasar a un enfoque multiplataforma con [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/). Use `GetImage` o `GetImages` en lugar de renderizar a [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

**¿Cuál es el beneficio práctico de [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) frente a [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?**

[IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) unifica el trabajo con imágenes raster y vectoriales, simplifica el guardado en varios formatos mediante [ImageFormat](https://reference.aspose.com/slides/es/net/aspose.slides/imageformat/), reduce la dependencia de `System.Drawing` y hace que el código sea más transportable entre entornos.

**¿Afectará la API moderna al rendimiento de la generación de miniaturas?**

Cambiar de `GetThumbnail` a `GetImage` no empeora los escenarios: los nuevos métodos ofrecen las mismas capacidades para producir imágenes con opciones y tamaños, manteniendo el soporte de opciones de renderizado. La ganancia o pérdida específica depende del caso, pero funcionalmente los sustitutos son equivalentes.