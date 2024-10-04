---
title: Convertir PowerPoint a JPG en C#
linktitle: Convertir PowerPoint PPT a JPG
type: docs
weight: 60
url: /net/convert-powerpoint-to-jpg/
keywords: 
- Convertir presentación de PowerPoint
- JPG
- JPEG
- PowerPoint a JPG
- PowerPoint a JPEG
- PPT a JPG
- PPTX a JPG
- PPT a JPEG
- PPTX a JPEG
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Convertir PowerPoint a JPG en C# o .NET. Guardar diapositiva como imagen JPG"
---

## **Resumen**

Este artículo explica cómo convertir una presentación de PowerPoint a formato JPG utilizando C#. Cubre los siguientes temas:

- [C# Convertir PowerPoint a JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# Convertir PPT a JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# Convertir PPTX a JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# Convertir ODP a JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# Convertir diapositiva de PowerPoint a imagen](#convert-powerpoint-pptpptx-to-jpg)

## **C# PowerPoint a JPG**

Para código de muestra en C# para convertir PowerPoint a JPG, consulte la sección a continuación, es decir, [Convertir PowerPoint a JPG](#convert-powerpoint-pptpptx-to-jpg). El código puede cargar varios formatos como PPT, PPTX y ODP en el objeto Presentación y luego guardar su miniatura de diapositiva en formato JPG. Otras conversiones de PowerPoint a imagen que son algo similares, como PNG, BMP, TIFF y SVG, se discuten en estos artículos.

- [C# PowerPoint a PNG](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)
- [C# PowerPoint a BMP](#convert-powerpoint-pptpptx-to-jpg)
- [C# PowerPoint a TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint a SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **Acerca de la conversión de PowerPoint a JPG**
Con [**Aspose.Slides .NET API**](https://products.aspose.com/slides/net/) puedes convertir una presentación de PowerPoint PPT o PPTX a imagen JPG. También es posible convertir PPT/PPTX a BMP, PNG o SVG. Con esta función es fácil implementar tu propio visor de presentaciones, crear la miniatura de cada diapositiva. Esto puede ser útil si deseas proteger las diapositivas de la presentación contra derechos de autor, demostrar la presentación en modo de solo lectura. Aspose.Slides permite convertir toda la presentación o una diapositiva específica en formatos de imagen. 

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte PowerPoint en imágenes JPG, puedes probar estos conversores en línea gratuitos: PowerPoint [PPTX a JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) y [PPT a JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX a JPG**
Aquí están los pasos para convertir PPT/PPTX a JPG:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén el objeto de diapositiva del tipo [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) de la colección [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides).
3. Crea la miniatura de cada diapositiva y luego conviértela a JPG. El método [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) se utiliza para obtener una miniatura de una diapositiva, devuelve un objeto [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=netframework-4.8) como resultado. Se debe llamar al método [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) desde la diapositiva necesaria del tipo [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide), las escalas de la miniatura resultante se pasan al método.
4. Después de obtener la miniatura de la diapositiva, llama al método [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) del objeto de miniatura. Pasa el nombre del archivo resultante y el formato de la imagen en él. 

{{% alert color="primary" %}} 
**Nota**: La conversión de PPT/PPTX a JPG difiere de la conversión a otros tipos en Aspose.Slides .NET API. Para otros tipos, generalmente utilizas el método [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)** ](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5), pero aquí necesitas el método [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8).
{{% /alert %}} 

```c#
const int imageScale = 1;

using (Presentation pres = new Presentation("PowerPoint-Presentation.ppt"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Crea una imagen a escala completa
        using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
        {
            // Guarda la imagen en disco en formato JPEG
			string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Convertir PowerPoint PPT/PPTX a JPG con dimensiones personalizadas**
Para cambiar la dimensión de la miniatura resultante y la imagen JPG, puedes establecer los valores *ScaleX* y *ScaleY* pasándolos al método [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5):

```c#
using (Presentation pres = new Presentation("PowerPoint-Presentation.pptx"))
{
    // Define dimensiones
    int desiredX = 1200;
    int desiredY = 800;

    // Obtiene los valores escalados de X y Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    foreach (ISlide slide in pres.Slides)
    {
        // Crea una imagen a escala completa
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Guarda la imagen en disco en formato JPEG
			string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Renderizar comentarios al guardar la presentación como imagen**
Aspose.Slides para .NET proporciona una función que te permite renderizar comentarios en las diapositivas de una presentación cuando conviertes esas diapositivas en imágenes. Este código C# demuestra la operación:

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,
            CommentsAreaColor = Color.Red,
            CommentsAreaWidth = 200,
            CommentsPosition = CommentsPositions.Right
        }
    };

    using (IImage image = presentation.Slides[0].GetImage(options))
    {
        image.Save("OutPresBitmap.png", ImageFormat.Png);
    }

    System.Diagnostics.Process.Start("OutPresBitmap.png");
}
```

{{% alert title="Consejo" color="primary" %}}

Aspose proporciona una [aplicación web COLAGE GRATUITA](https://products.aspose.app/slides/collage). Usando este servicio en línea, puedes combinar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid), y más.

Utilizando los mismos principios descritos en este artículo, puedes convertir imágenes de un formato a otro. Para más información, consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **Ver también**

Consulta otras opciones para convertir PPT/PPTX en imagen como:

- [Conversión PPT/PPTX a SVG](/slides/net/render-a-slide-as-an-svg-image/).