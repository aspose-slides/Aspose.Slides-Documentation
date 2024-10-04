---
title: Convertir Diapositiva
type: docs
weight: 41
url: /es/net/convert-slide/
keywords: 
- convertir diapositiva a imagen
- exportar diapositiva como imagen
- guardar diapositiva como imagen
- diapositiva a imagen
- diapositiva a PNG
- diapositiva a JPEG
- diapositiva a bitmap
- C#
- Csharp
- .NET
- Aspose.Slides para .NET
description: "Convierte diapositivas de PowerPoint a imágenes (bitmap, PNG o JPG) en C# o .NET"
---

Aspose.Slides para .NET te permite convertir diapositivas (en presentaciones) a imágenes. Estos son los formatos de imagen soportados: BMP, PNG, JPG (JPEG), GIF y otros.

Para convertir una diapositiva a una imagen, haz lo siguiente:

1. Primero, establece los parámetros de conversión y los objetos de diapositiva a convertir utilizando:
   * la interfaz [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) o
   * la interfaz [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions).

2. Segundo, convierte la diapositiva a una imagen utilizando el método [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

## **Sobre Bitmap y Otros Formatos de Imagen**

En .NET, un [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) es un objeto que te permite trabajar con imágenes definidas por datos de píxeles. Puedes usar una instancia de esta clase para guardar imágenes en una amplia gama de formatos (BMP, JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose desarrolló recientemente un convertidor en línea de [Texto a GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **Convirtiendo Diapositivas a Bitmap y Guardando las Imágenes en PNG**

Este código en C# te muestra cómo convertir la primera diapositiva de una presentación a un objeto bitmap y luego cómo guardar la imagen en formato PNG:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Convierte la primera diapositiva en la presentación a un objeto Bitmap
    using (IImage image = pres.Slides[0].GetImage())
    {
        // Guarda la imagen en formato PNG
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert title="Consejo" color="primary" %}} 

Puedes convertir una diapositiva a un objeto bitmap y luego usar el objeto directamente en otro lugar. O puedes convertir una diapositiva a un bitmap y luego guardar la imagen en JPEG o cualquier otro formato que prefieras.

{{% /alert %}}  

## **Convirtiendo Diapositivas a Imágenes con Tamaños Personalizados**

Puede que necesites obtener una imagen de un cierto tamaño. Usando una sobrecarga del método [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/), puedes convertir una diapositiva a una imagen con dimensiones específicas (largo y ancho).

Este código de ejemplo demuestra la conversión propuesta usando el método [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) en C#:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Convierte la primera diapositiva en la presentación a un Bitmap con el tamaño especificado
    using (IImage image = pres.Slides[0].GetImage(new Size(1820, 1040)))
    {
        // Guarda la imagen en formato JPEG
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Convirtiendo Diapositivas con Notas y Comentarios a Imágenes**

Algunas diapositivas contienen notas y comentarios.

Aspose.Slides proporciona dos interfaces—[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) y [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions)—que te permiten controlar el renderizado de las diapositivas de presentación a imágenes. Ambas interfaces albergan la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) que te permite agregar notas y comentarios en una diapositiva cuando conviertes esa diapositiva a una imagen.

{{% alert title="Info" color="info" %}} 

Con la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions), puedes especificar tu posición preferida para notas y comentarios en la imagen resultante.

{{% /alert %}} 

Este código en C# demuestra el proceso de conversión de una diapositiva con notas y comentarios:

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Crea las opciones de renderizado
    IRenderingOptions options = new RenderingOptions();

    // Establece la posición de las notas en la página
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // Establece la posición de los comentarios en la página 
    options.NotesCommentsLayouting.CommentsPosition = CommentsPositions.Right;

    // Establece el ancho del área de salida de comentarios
    options.NotesCommentsLayouting.CommentsAreaWidth = 500;

    // Establece el color para el área de comentarios
    options.NotesCommentsLayouting.CommentsAreaColor = Color.AntiqueWhite;

    // Convierte la primera diapositiva de la presentación a un objeto Bitmap
    using (IImage image = pres.Slides[0].GetImage(options, 2f, 2f))
    {
        // Guarda la imagen en formato GIF
        image.Save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Nota" color="warning" %}} 

En cualquier proceso de conversión de diapositivas a imágenes, la propiedad [NotesPositions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/properties/notesposition) no puede establecerse en BottomFull (para especificar la posición de las notas) porque el texto de una nota puede ser grande, lo que significa que puede que no quepa en el tamaño de imagen especificado.

{{% /alert %}} 

## **Convirtiendo Diapositivas a Imágenes Usando ITiffOptions**

La interfaz [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) te da más control (en términos de parámetros) sobre la imagen resultante. Usando esta interfaz, puedes especificar el tamaño, la resolución, la paleta de colores y otros parámetros para la imagen resultante.

Este código en C# demuestra un proceso de conversión donde se utiliza ITiffOptions para obtener una imagen en blanco y negro con una resolución de 300dpi y tamaño 2160 × 2800:

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Obtiene una diapositiva por su índice
    ISlide slide = pres.Slides[0];

    // Crea un objeto TiffOptions
    TiffOptions options = new TiffOptions() { ImageSize = new Size(2160, 2880) };

    // Establece la fuente utilizada en caso de que no se encuentre la fuente de origen
    options.DefaultRegularFont = "Arial Black";

    // Establece la posición de las notas en la página 
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // Establece el formato de píxeles (blanco y negro)
    options.PixelFormat = ImagePixelFormat.Format1bppIndexed;

    // Establece la resolución
    options.DpiX = 300;
    options.DpiY = 300;

    // Convierte la diapositiva a un objeto Bitmap
    using (IImage image = slide.GetImage(options))
    {
        // Guarda la imagen en formato BMP
        image.Save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    }
}  
```

## **Convirtiendo Todas las Diapositivas a Imágenes**

Aspose.Slides te permite convertir todas las diapositivas en una única presentación a imágenes. Esencialmente, obtienes convertir la presentación (en su totalidad) a imágenes.

Este código de ejemplo te muestra cómo convertir todas las diapositivas en una presentación a imágenes en C#:

```csharp
// Especifica la ruta al directorio de salida
string outputDir = @"D:\PresentationImages";

using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Renderiza la presentación a un arreglo de imágenes diapositiva por diapositiva
    for (int i = 0; i < pres.Slides.Count; i++)
    {
        // Especifica la configuración para diapositivas ocultas (no renderizar diapositivas ocultas)
        if (pres.Slides[i].Hidden)
            continue;

        // Convierte la diapositiva a un objeto Bitmap
        using (IImage image = pres.Slides[i].GetImage(2f, 2f))
        {
            // Crea un nombre de archivo para una imagen
            string outputFilePath = Path.Combine(outputDir, "Slide_" + i + ".jpg");

            // Guarda la imagen en formato JPEG
            image.Save(outputFilePath, ImageFormat.Jpeg);
        }
    }
}
```