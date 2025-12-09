---
title: Administrar marcos de imagen en presentaciones en .NET
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/net/picture-frame/
keywords:
- marco de imagen
- agregar marco de imagen
- crear marco de imagen
- agregar imagen
- crear imagen
- extraer imagen
- imagen raster
- imagen vectorial
- recortar imagen
- área recortada
- propiedad StretchOff
- formateo de marco de imagen
- propiedades de marco de imagen
- escala relativa
- efecto de imagen
- relación de aspecto
- transparencia de imagen
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Agrega marcos de imagen a presentaciones de PowerPoint y OpenDocument con Aspose.Slides para .NET. Optimiza tu flujo de trabajo y mejora los diseños de diapositivas."
---

Un marco de imagen es una forma que contiene una imagen; es como una foto en un marco. 

Puedes agregar una imagen a una diapositiva mediante un marco de imagen. De esta manera, puedes dar formato a la imagen formateando el marco de imagen.

{{% alert  title="Tip" color="primary" %}} 
Aspose ofrece conversores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a las personas crear presentaciones rápidamente a partir de imágenes. 
{{% /alert %}} 

## **Crear marco de imagen**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) asociada al objeto de presentación que se utilizará para rellenar la forma.
4. Especifica el ancho y la altura de la imagen.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) basado en el ancho y la altura de la imagen mediante el método `AddPictureFrame` expuesto por el objeto de forma asociado a la diapositiva referenciada.
6. Agrega un marco de imagen (que contiene la foto) a la diapositiva.
7. Guarda la presentación modificada como un archivo PPTX.

Este código C# muestra cómo crear un marco de imagen:
```c#
// Instancia la clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{
    // Obtiene la primera diapositiva
    ISlide slide = pres.Slides[0];

    // Carga una imagen y la agrega a la colección de imágenes de la presentación
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Agrega un marco de imagen con la misma altura y anchura
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Aplica algo de formato al marco de imagen
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Guarda la presentación en un archivo PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" %}} 
Los marcos de imagen te permiten crear rápidamente diapositivas de presentación basadas en imágenes. Cuando combinas un marco de imagen con las opciones de guardado de Aspose.Slides, puedes manipular operaciones de entrada/salida para convertir imágenes de un formato a otro. Puede que desees ver estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/). 
{{% /alert %}}

## **Crear marco de imagen con escala relativa**

Al alterar la escala relativa de una imagen, puedes crear un marco de imagen más complejo. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Añade una imagen a la colección de imágenes de la presentación.
4. Crea un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) asociada al objeto de presentación que se utilizará para rellenar la forma.
5. Especifica el ancho y la altura relativos de la imagen en el marco de imagen.
6. Guarda la presentación modificada como un archivo PPTX.

Este código C# muestra cómo crear un marco de imagen con escala relativa:
```c#
// Instancia la clase Presentation que representa un archivo PPTX
using (Presentation presentation = new Presentation())
{
    // Carga una imagen y la agrega a la colección de imágenes de la presentación
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Agrega un marco de imagen a la diapositiva
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Establece la escala relativa de ancho y alto
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Guarda la presentación
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```


## **Extraer imágenes rasterizadas de marcos de imagen**

Puedes extraer imágenes rasterizadas de objetos [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) y guardarlas en PNG, JPG y otros formatos. El ejemplo de código a continuación demuestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.
```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```


## **Extraer imágenes SVG de marcos de imagen**

Cuando una presentación contiene gráficos SVG colocados dentro de formas [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), Aspose.Slides para .NET te permite recuperar las imágenes vectoriales originales con plena fidelidad. Al recorrer la colección de formas de la diapositiva, puedes identificar cada [PictureFrame], comprobar si el [IPPImage] subyacente contiene contenido SVG y luego guardar esa imagen en disco o en un flujo en su formato SVG nativo.

El siguiente ejemplo de código muestra cómo extraer una imagen SVG de un marco de imagen:
```cs
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```


## **Obtener la transparencia de la imagen**

Aspose.Slides te permite obtener el efecto de transparencia aplicado a una imagen. Este código C# muestra la operación:
```c#
using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```


{{% alert color="primary" %}} 
Todos los efectos aplicados a imágenes se pueden encontrar en [Aspose.Slides.Effects](https://reference.aspose.com/slides/net/aspose.slides.effects/). 
{{% /alert %}}

## **Formato de marco de imagen**

Aspose.Slides ofrece muchas opciones de formato que pueden aplicarse a un marco de imagen. Con esas opciones, puedes modificar un marco de imagen para que cumpla requisitos específicos.

1. Crea una instancia de la clase [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) asociada al objeto de presentación que se utilizará para rellenar la forma.
4. Especifica el ancho y la altura de la imagen.
5. Crea un `PictureFrame` basado en el ancho y la altura de la imagen mediante el método [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) expuesto por el objeto [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) asociado a la diapositiva referenciada.
6. Agrega un marco de imagen (que contiene la foto) a la diapositiva.
7. Establece el color de línea del marco de imagen.
8. Establece el ancho de línea del marco de imagen.
9. Rota el marco de imagen asignándole un valor positivo o negativo.  
   * Un valor positivo rota la imagen en sentido horario.  
   * Un valor negativo rota la imagen en sentido antihorario.
10. Agrega el marco de imagen (que contiene la foto) a la diapositiva.
11. Guarda la presentación modificada como un archivo PPTX.

Este código C# muestra el proceso de formato del marco de imagen:
```c#
// Instancia la clase Presentation que representa un archivo PPTX
using (Presentation presentation = new Presentation())
{
    // Obtiene la primera diapositiva
    ISlide slide = presentation.Slides[0];

    // Carga una imagen y la agrega a la colección de imágenes de la presentación
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Agrega un marco de imagen con la altura y anchura equivalentes de la imagen
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Aplica algo de formato al marco de imagen
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Guarda la presentación en un archivo PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}

Aspose ha desarrollado recientemente un [Collage Maker gratuito](https://products.aspose.app/slides/collage). Si alguna vez necesitas [combinar imágenes JPG/JPEG](https://products.aspose.app/slides/collage/jpg) o PNG, [crear cuadrículas a partir de fotos](https://products.aspose.app/slides/collage/photo-grid), puedes usar este servicio. 

{{% /alert %}}

## **Agregar imagen como enlace**

Para evitar tamaños grandes de presentación, puedes agregar imágenes (o videos) mediante enlaces en lugar de incrustar los archivos directamente en las presentaciones. Este código C# muestra cómo agregar una imagen y un video en un marcador de posición:
```c#
using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Recortar imagen**

Este código C# muestra cómo recortar una imagen existente en una diapositiva:
```c#
using (Presentation presentation = new Presentation())
{
    // Crea un nuevo objeto de imagen
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Agrega un PictureFrame a una diapositiva
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Recorta la imagen (valores de porcentaje)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Guarda el resultado
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```


## **Eliminar áreas recortadas de la imagen**

Si deseas eliminar las áreas recortadas de una imagen contenida en un marco, puedes usar el método [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Este método devuelve la imagen recortada o la imagen original si el recorte no es necesario.

Este código C# muestra la operación:
```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtiene el PictureFrame de la primera diapositiva
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Elimina las áreas recortadas de la imagen del PictureFrame y devuelve la imagen recortada
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Guarda el resultado
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```


{{% alert title="NOTE" color="warning" %}} 

El método [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) agrega la imagen recortada a la colección de imágenes de la presentación. Si la imagen solo se usa en el [PictureFrame] procesado, esta configuración puede reducir el tamaño de la presentación. De lo contrario, aumentará el número de imágenes en la presentación resultante.

Este método convierte archivos metafile WMF/EMF a imágenes PNG raster en la operación de recorte. 

{{% /alert %}}

## **Comprimir imagen**

Puedes comprimir una imagen en una presentación usando el método [`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/). Este método reduce el tamaño de una imagen según el tamaño de la forma y la resolución especificada, con la opción de eliminar áreas recortadas.

Ajusta el tamaño y la resolución de la imagen de forma similar a la función **Formato de imagen → Comprimir imágenes → Resolución** de PowerPoint.

Los siguientes ejemplos C# demuestran cómo comprimir una imagen en una presentación especificando una resolución objetivo y, opcionalmente, eliminando áreas recortadas:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtiene el PictureFrame de la diapositiva
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Comprime la imagen con una resolución objetivo de 150 DPI (resolución web) y elimina las áreas recortadas
    bool result = picFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Comprueba el resultado de la compresión
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }
}
```


O usando directamente un valor DPI personalizado:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Comprime la imagen a 150 DPI (resolución web), eliminando áreas recortadas
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```


{{% alert title="NOTE" color="warning" %}} 

El método convierte la imagen a una resolución inferior basada en el tamaño de la forma y el DPI proporcionado. Las regiones recortadas también pueden eliminarse para optimizar el tamaño del archivo.  
Si la imagen es un metafile (WMF/EMF) o SVG, no se aplicará compresión. Además, la calidad JPEG se conserva o se reduce ligeramente según la resolución, de manera similar a cómo PowerPoint maneja los JPEG de alta resolución. 

{{% /alert %}}

## **Bloquear relación de aspecto**

Si deseas que una forma que contiene una imagen mantenga su relación de aspecto incluso después de cambiar las dimensiones de la imagen, puedes usar la propiedad [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) para establecer la configuración *Lock Aspect Ratio*.

Este código C# muestra cómo bloquear la relación de aspecto de una forma:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Establece la forma para preservar la relación de aspecto al redimensionar
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```


{{% alert title="NOTE" color="warning" %}} 

Esta configuración *Lock Aspect Ratio* conserva solo la relación de aspecto de la forma y no la de la imagen que contiene. 
{{% /alert %}}

## **Usar la propiedad StretchOff**

Usando las propiedades [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) y [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) y la clase [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat), puedes especificar un rectángulo de relleno.

Cuando se especifica estiramiento para una imagen, un rectángulo fuente se escala para ajustarse al rectángulo de relleno especificado. Cada borde del rectángulo de relleno se define por un desplazamiento porcentual desde el borde correspondiente del cuadro delimitador de la forma. Un porcentaje positivo indica un interior mientras que un porcentaje negativo indica un exterior.

1. Crea una instancia de la [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) clase. 
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Añade un rectángulo `AutoShape`. 
4. Crea una imagen. 
5. Establece el tipo de relleno de la forma. 
6. Establece el modo de relleno de imagen de la forma. 
7. Añade una imagen establecida para rellenar la forma. 
8. Especifica los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma 
9. Guarda la presentación modificada como un archivo PPTX. 

Este código C# demuestra un proceso en el que se usa la propiedad StretchOff:
```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Establece la imagen estirada desde cada lado en el cuerpo de la forma
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Cómo puedo averiguar qué formatos de imagen son compatibles con PictureFrame?**

Aspose.Slides admite tanto imágenes raster (PNG, JPEG, BMP, GIF, etc.) como imágenes vectoriales (por ejemplo, SVG) mediante el objeto de imagen que se asigna a un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/). La lista de formatos compatibles generalmente coincide con las capacidades del motor de conversión de diapositivas e imágenes.

**¿Cómo afectará la incorporación de docenas de imágenes grandes al tamaño y rendimiento del PPTX?**

Incrustar imágenes grandes incrementa el tamaño del archivo y el uso de memoria; enlazar imágenes ayuda a mantener el tamaño de la presentación bajo pero requiere que los archivos externos sigan accesibles. Aspose.Slides permite agregar imágenes mediante enlaces para reducir el tamaño del archivo.

**¿Cómo puedo bloquear un objeto de imagen para evitar movimientos/redimensiones accidentales?**

Utiliza los [bloqueos de forma](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/) para un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) (por ejemplo, desactivar mover o redimensionar). El mecanismo de bloqueo se describe para formas en un artículo separado de [protección](/slides/es/net/applying-protection-to-presentation/) y es compatible con varios tipos de forma, incluido [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/).

**¿Se conserva la fidelidad vectorial SVG al exportar una presentación a PDF/imagenes?**

Aspose.Slides permite extraer un SVG de un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) como el vector original. Al [exportar a PDF](/slides/es/net/convert-powerpoint-to-pdf/) o a [formatos raster](/slides/es/net/convert-powerpoint-to-png/), el resultado puede rasterizarse según la configuración de exportación; el hecho de que el SVG original se almacene como vector se confirma mediante el comportamiento de extracción.