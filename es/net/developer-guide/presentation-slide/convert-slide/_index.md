---
title: Convertir diapositivas de presentación a imágenes en .NET
linktitle: Diapositiva a Imagen
type: docs
weight: 41
url: /es/net/convert-slide/
keywords:
- convertir diapositiva
- exportar diapositiva
- diapositiva a imagen
- guardar diapositiva como imagen
- diapositiva a EMF
- diapositiva a PNG
- diapositiva a JPEG
- diapositiva a mapa de bits
- diapositiva a TIFF
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Convierta diapositivas de presentaciones PPT, PPTX y ODP a PNG, JPEG, GIF, TIFF, EMF y otros formatos de imagen en C# con Aspose.Slides para .NET."
---
## **Introducción**

Aspose.Slides for .NET puede renderizar diapositivas individuales de presentaciones PowerPoint y OpenDocument como PNG, JPEG, GIF, TIFF y otros formatos de imagen.

Para convertir una diapositiva en una imagen, siga estos pasos:

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/).
2. Seleccione la diapositiva que desea renderizar.
3. Si es necesario, configure la renderización con la clase [RenderingOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/tiffoptions/).
4. Llame al método [GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/islide/getimage/). Devuelve un objeto [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/).
5. Llame al método [IImage.Save](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/save/) y especifique el formato de salida con un valor [ImageFormat](https://reference.aspose.com/slides/es/net/aspose.slides/imageformat/).

## **Convertir una diapositiva a una imagen PNG**

La conversión más simple usa la configuración de renderizado predeterminada. El objeto [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) resultante puede procesarse en memoria o guardarse en un archivo.

El siguiente ejemplo en C# renderiza la primera diapositiva y la guarda como una imagen PNG:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Convertir diapositivas a imágenes con tamaños personalizados**

Utilice la sobrecarga de [GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/islide/getimage/) que acepta un valor [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) para renderizar una diapositiva con dimensiones de píxel exactas.

El siguiente ejemplo crea una imagen JPEG de 1820 × 1040:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Convertir diapositivas con notas y comentarios a imágenes**

De forma predeterminada, las imágenes de diapositivas no incluyen notas ni comentarios. Asigne un objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/notescommentslayoutingoptions/) a la propiedad [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) para controlar dónde aparecen las notas y los comentarios.

El siguiente ejemplo coloca notas truncadas bajo la diapositiva y los comentarios a su derecha:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
Para la conversión de diapositiva a imagen, no establezca la propiedad [NotesPosition](https://reference.aspose.com/slides/es/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) a [BottomFull](https://reference.aspose.com/slides/es/net/aspose.slides.export/notespositions/). Las notas pueden contener más texto del que el tamaño fijo de la imagen puede albergar. Use [BottomTruncated](https://reference.aspose.com/slides/es/net/aspose.slides.export/notespositions/) en su lugar.
{{% /alert %}}

## **Convertir diapositivas a imágenes usando opciones TIFF**

La clase [TiffOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/tiffoptions/) le permite controlar el tamaño, la resolución y otras propiedades de la imagen TIFF renderizada.

El siguiente ejemplo renderiza la primera diapositiva como una imagen TIFF de 2160 × 2880 a 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Convertir todas las diapositivas a imágenes**

Itere a través de la colección de diapositivas para convertir toda la presentación en una serie de imágenes. Las diapositivas ocultas se incluyen a menos que las omita explícitamente.

El siguiente ejemplo renderiza cada diapositiva como una imagen JPEG con factores de escala horizontal y vertical de 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Crear salida Enhanced Metafile**

Enhanced Metafile (EMF) es útil cuando se deben intercambiar gráficos vectoriales con Microsoft Office u otras aplicaciones de Windows que admiten metarchivos de Windows. A diferencia de una imagen basada en píxeles, un EMF puede conservar las operaciones de dibujo vectorial que se escalan sin la misma pérdida de nitidez. Sin embargo, EMF es principalmente un formato de compatibilidad para aplicaciones con soporte de metarchivos de Windows, no un formato universal de intercambio. Además, el contenido complejo de la diapositiva, como imágenes de mapa de bits y algunos efectos, puede almacenarse como elementos rasterizados dentro del contenedor de metarchivo vectorial.

### **Exportar una diapositiva a EMF**

El método [ISlide.WriteAsEmf](https://reference.aspose.com/slides/es/net/aspose.slides/islide/writeasemf/) escribe un [ISlide](https://reference.aspose.com/slides/es/net/aspose.slides/islide/) en un flujo de destino en formato EMF. El siguiente ejemplo carga una presentación, selecciona la primera diapositiva y la escribe en un flujo de archivo EMF:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

El llamador es responsable del flujo pasado a [ISlide.WriteAsEmf](https://reference.aspose.com/slides/es/net/aspose.slides/islide/writeasemf/) y debe cerrarlo o disponerlo. Aspose.Slides escribe en la posición actual del flujo y deja el flujo abierto.

### **Convertir una imagen SVG a EMF y añadirla a una presentación**

Utilice [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage/writeasemf/) para convertir contenido SVG a EMF. Los bytes resultantes pueden añadirse a la presentación mediante [IImageCollection.AddImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimagecollection/addimage/) y colocarse en una diapositiva con [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addpictureframe/).

El siguiente ejemplo crea un [SvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/svgimage/) a partir de marcado SVG, lo convierte a un EMF en memoria, inserta el metarchivo en la primera diapositiva y guarda la presentación:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage/writeasemf/) no toma posesión del flujo de destino. Después de escribir, la posición del flujo está al final de los datos generados. Restablezca `Position` al principio antes de pasar el mismo flujo buscable a un lector, como se muestra arriba. Mantenga el flujo abierto hasta que el consumidor haya terminado de leerlo y dispóngalo después. Alternativamente, llame a `ToArray` y pase el arreglo de bytes devuelto a [IImageCollection.AddImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimagecollection/addimage/); `ToArray` devuelve el búfer completo sin importar la posición actual del flujo.

La generación de EMF está disponible en los sistemas operativos compatibles con la compilación seleccionada de Aspose.Slides for .NET, pero la renderización puede variar entre plataformas cuando faltan fuentes o dependencias gráficas nativas. Instale las fuentes usadas por el contenido de origen o configure sustituciones adecuadas, siga los [requisitos de plataforma](/slides/es/net/system-requirements/) para su paquete Aspose.Slides y valide el resultado en la aplicación que consumirá el EMF. Las aplicaciones Linux y macOS a menudo tienen soporte limitado o inconsistente para mostrar y editar metarchivos de Windows.

## **Renderizado de emoji en color**

{{% alert title="Note" color="info" %}}
Para renderizar correctamente los emojis en color al convertir diapositivas de presentación a imágenes, las fuentes de emoji usadas en la presentación deben estar instaladas y disponibles en el sistema que realiza la conversión. Por ejemplo, si la presentación usa **Segoe UI Emoji** y esa fuente falta, los emojis pueden aparecer en monocromo en las imágenes resultantes.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Aspose.Slides admite renderizar diapositivas con animaciones?**

No. El método [GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/islide/getimage/) renderiza una imagen estática de la diapositiva y no exporta animaciones.

**¿Se pueden exportar diapositivas ocultas como imágenes?**

Sí. Las diapositivas ocultas pueden renderizarse como diapositivas normales. Inclúyalas en el bucle de procesamiento, como se muestra en el ejemplo anterior.

**¿Se conservan las sombras y otros efectos en las imágenes de diapositivas?**

Sí. Aspose.Slides renderiza sombras, transparencias y otros efectos gráficos compatibles en las imágenes de diapositivas.