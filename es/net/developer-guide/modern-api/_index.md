---
title: Mejorar el procesamiento de imágenes con la API Moderna
linktitle: API Moderna
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
- agregar imagen
- agregar foto
- .NET
- C#
- Aspose.Slides
description: "Moderniza el procesamiento de imágenes de diapositivas reemplazando las API de imágenes obsoletas con la API Moderna de .NET para una automatización fluida de PowerPoint y OpenDocument."
---

## **Introducción**

Históricamente, Aspose Slides tiene una dependencia de System.Drawing y tiene en la API pública las siguientes clases de allí:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

A partir de la versión 24.4, esta API pública se declara obsoleta.

Como el soporte de System.Drawing en versiones .NET6 y superiores se elimina para versiones que no son Windows ([cambio de ruptura](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides ha implementado un enfoque de dos versiones de biblioteca:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - soporte para .NET6+ en Windows, .NETStandard para Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - tiene una dependencia de [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - versión Windows/Linux/MacOS sin dependencias.

Inconvenientemente, [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) implementa su propia versión de System.Drawing en el mismo espacio de nombres (para soportar la compatibilidad hacia atrás con la API pública). Por lo tanto, cuando Aspose.Slides.NET6.CrossPlatform y System.Drawing del .NETFramework o del paquete System.Drawing.Common se usan al mismo tiempo, ocurre un conflicto de nombres a menos que se use un alias.

Para eliminar las dependencias de System.Drawing en el paquete principal Aspose.Slides.NET, añadimos lo que se llama "API Moderna" — es decir, la API que debe usarse en lugar de la obsoleta, cuyas firmas contienen dependencias de los siguientes tipos de System.Drawing: Image y Bitmap. PrinterSettings y Graphics se declaran obsoletos y su soporte se elimina de la API pública de Slides.

La eliminación de la API pública obsoleta con dependencias en System.Drawing será en la versión 24.8.

## **API Moderna**

Se han añadido las siguientes clases y enumeraciones a la API pública:

- Aspose.Slides.IImage - representa la imagen raster o vectorial.
- Aspose.Slides.ImageFormat - representa el formato de archivo de la imagen.
- Aspose.Slides.Images - métodos para instanciar y trabajar con la interfaz IImage.

Nota: IImage es desechable (implementa la interfaz IDisposable y su uso debe envolver en una sentencia using o liberarse de otra forma conveniente).

Un escenario típico de uso de la nueva API puede verse como sigue:
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // instanciar una instancia descartable de IImage desde el archivo en disco.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // crear una imagen de PowerPoint añadiendo una instancia de IImage a las imágenes de la presentación.
        ppImage = pres.Images.AddImage(image);
    }

    // agregar una forma de imagen en la diapositiva #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // obtener una instancia de IImage que representa la diapositiva #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // guardar la imagen en el disco.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```


## **Reemplazando código antiguo con la API Moderna**

Para facilitar la transición, la interfaz del nuevo IImage repite las firmas separadas de las clases Image y Bitmap. En general, solo necesitará reemplazar la llamada al método antiguo que usa System.Drawing por la nueva.

### **Obtener una miniatura de diapositiva**

Código usando una API obsoleta:
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


### **Obtener una miniatura de forma**

Código usando una API obsoleta:
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


### **Obtener una miniatura de presentación**

Código usando una API obsoleta:
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


### **Agregar una imagen a una presentación**

Código usando una API obsoleta:
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


## **Métodos/propiedades que se eliminarán y su reemplazo en la API Moderna**

### **Presentation**
| Firma del método | Firma del método de reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | Will be deleted completely |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | Will be deleted completely |
| public void Print() | Will be deleted completely |
| public void Print(PrinterSettings printerSettings) | Will be deleted completely |
| public void Print(string printerName) | Will be deleted completely |
| public void Print(PrinterSettings printerSettings, string presName) | Will be deleted completely |

### **Shape**
| Firma del método | Firma del método de reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Firma del método | Firma del método de reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | Will be deleted completely |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | Will be deleted completely |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | Will be deleted completely |

### **Output**
| Firma del método | Firma del método de reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Firma del método | Firma del método de reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Firma del método | Firma del método de reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Firma del método/propiedad | Firma del método de reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Firma del método | Firma del método de reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Firma del método | Firma del método de reemplazo |
|-----------------------------------------------|---------------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **El soporte de API para Graphics y PrinterSettings será descontinuado**

El clase [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) no es compatible con versiones multiplataforma de .NET6 y superiores. En Aspose Slides, la parte de la API que lo utiliza será eliminada:
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

También se eliminará la parte de la API relacionada con la impresión:

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

# **Preguntas frecuentes**

**¿Por qué se eliminó System.Drawing.Graphics?**

El soporte para `Graphics` se está eliminando de la API pública para unificar el trabajo con renderizado e imágenes, eliminar dependencias específicas de plataforma y pasar a un enfoque multiplataforma con [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Todos los métodos de renderizado a `Graphics` serán eliminados.

**¿Cuál es el beneficio práctico de IImage comparado con Image/Bitmap?**

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) unifica el trabajo con imágenes raster y vectoriales, simplifica el guardado en varios formatos mediante [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), reduce la dependencia de `System.Drawing` y hace que el código sea más portable entre entornos.

**¿Afectará la API Moderna el rendimiento de la generación de miniaturas?**

Cambiar de `GetThumbnail` a `GetImage` no empeora los escenarios: los nuevos métodos proporcionan las mismas capacidades para producir imágenes con opciones y tamaños, manteniendo el soporte para opciones de renderizado. La ganancia o pérdida específica depende del escenario, pero funcionalmente los reemplazos son equivalentes.