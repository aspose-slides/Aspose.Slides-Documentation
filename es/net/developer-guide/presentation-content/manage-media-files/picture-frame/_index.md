---
title: Marco de Imagen
type: docs
weight: 10
url: /net/picture-frame/
keywords: 
- agregar marco de imagen
- crear marco de imagen
- agregar imagen
- crear imagen
- extraer imagen
- propiedad StretchOff
- formato de marco de imagen
- propiedades del marco de imagen
- presentación de PowerPoint
- C#
- Csharp
- Aspose.Slides para .NET
description: "Agrega un marco de imagen a la presentación de PowerPoint en C# o .NET"
---

Un marco de imagen es una forma que contiene una imagen; es como una imagen en un marco.

Puedes agregar una imagen a una diapositiva a través de un marco de imagen. De esta manera, puedes dar formato a la imagen formateando el marco de imagen.

{{% alert  title="Consejo" color="primary" %}} 

Aspose proporciona convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a las personas crear presentaciones rápidamente a partir de imágenes.

{{% /alert %}} 

## **Crear Marco de Imagen**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección [IImages](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) asociada con el objeto de presentación que se utilizará para llenar la forma.
4. Especifica la anchura y la altura de la imagen.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) basado en la anchura y la altura de la imagen a través del método `AddPictureFrame` expuesto por el objeto de forma asociado con la diapositiva referenciada.
6. Agrega un marco de imagen (contiene la imagen) a la diapositiva.
7. Escribe la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo crear un marco de imagen:

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

    // Aplica algún formato al marco de imagen
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Escribe la presentación en un archivo PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Los marcos de imagen te permiten crear rápidamente diapositivas de presentación basadas en imágenes. Cuando combinas un marco de imagen con las opciones de guardado de Aspose.Slides, puedes manipular las operaciones de entrada/salida para convertir imágenes de un formato a otro. Puede que quieras ver estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **Crear Marco de Imagen con Escala Relativa**

Al alterar la escala relativa de una imagen, puedes crear un marco de imagen más complicado. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una imagen a la colección de imágenes de la presentación.
4. Crea un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección [IImages](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) asociada con el objeto de presentación que se utilizará para llenar la forma.
5. Especifica la anchura y la altura relativas de la imagen en el marco de imagen.
6. Escribe la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo crear un marco de imagen con escala relativa:

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

    // Establece la escala relativa de la anchura y la altura
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Guarda la presentación
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Extraer Imagen del Marco de Imagen**

Puedes extraer imágenes de objetos [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) y guardarlas en formatos PNG, JPG y otros. El siguiente ejemplo de código demuestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.

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

## **Obtener Transparencia de la Imagen**

Aspose.Slides te permite obtener la transparencia de una imagen. Este código C# demuestra la operación:

```c#
using (var presentation = new Presentation(folderPath + "Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparencia de la imagen: " + transparencyValue);
        }
    }
}
```

## **Formato de Marco de Imagen**

Aspose.Slides proporciona muchas opciones de formato que se pueden aplicar a un marco de imagen. Usando esas opciones, puedes alterar un marco de imagen para que coincida con requisitos específicos.

1. Crea una instancia de la clase [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección [IImages](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) asociada con el objeto de presentación que se utilizará para llenar la forma.
4. Especifica la anchura y la altura de la imagen.
5. Crea un `PictureFrame` basado en la anchura y la altura de la imagen a través del método [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) expuesto por el objeto [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) asociado con la diapositiva referenciada.
6. Agrega el marco de imagen (contiene la imagen) a la diapositiva.
7. Establece el color de línea del marco de imagen.
8. Establece el ancho de línea del marco de imagen.
9. Rota el marco de imagen dándole un valor positivo o negativo.
   * Un valor positivo rota la imagen en sentido horario. 
   * Un valor negativo rota la imagen en sentido antihorario.
10. Agrega el marco de imagen (contiene la imagen) a la diapositiva.
11. Escribe la presentación modificada como un archivo PPTX.

Este código C# demuestra el proceso de formateo del marco de imagen:

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

    // Agrega un marco de imagen con la altura y la anchura equivalentes de la imagen
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Aplica algún formato al marco de imagen
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Escribe la presentación en un archivo PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose desarrolló recientemente un [Creador de Collages gratuito](https://products.aspose.app/slides/collage). Si alguna vez necesitas [fusionar JPG/JPEG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG, [crear rejillas a partir de fotos](https://products.aspose.app/slides/collage/photo-grid), puedes utilizar este servicio. 

{{% /alert %}}

## **Agregar Imagen como Enlace**

Para evitar tamaños grandes de presentación, puedes agregar imágenes (o videos) a través de enlaces en lugar de incrustar los archivos directamente en las presentaciones. Este código C# te muestra cómo agregar una imagen y un video en un marcador de posición:

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

## **Recortar Imagen**

Este código C# te muestra cómo recortar una imagen existente en una diapositiva:

```c#
using (Presentation presentation = new Presentation())
{
    // Crea un nuevo objeto de imagen
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Agrega un PictureFrame a una Diapositiva
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Recorta la imagen (valores en porcentaje)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Guarda el resultado
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## Eliminar Áreas Recortadas de Imagen

Si deseas eliminar las áreas recortadas de una imagen contenida en un marco, puedes usar el método [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Este método devuelve la imagen recortada o la imagen original si el recorte no es necesario.

Este código C# demuestra la operación:

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

{{% alert title="NOTA" color="warning" %}} 

El método [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) agrega la imagen recortada a la colección de imágenes de la presentación. Si la imagen solo se usa en el [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) procesado, esta configuración puede reducir el tamaño de la presentación. De lo contrario, el número de imágenes en la presentación resultante aumentará.

Este método convierte archivos WMF/EMF a una imagen rasterizada PNG en la operación de recorte. 

{{% /alert %}}

## **Bloquear Relación de Aspecto**

Si deseas que una forma que contiene una imagen mantenga su relación de aspecto incluso después de cambiar las dimensiones de la imagen, puedes usar la propiedad [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) para establecer la configuración *Bloquear Relación de Aspecto*. 

Este código C# te muestra cómo bloquear la relación de aspecto de una forma:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Establece la forma para preservar la relación de aspecto al cambiar su tamaño
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTA" color="warning" %}} 

Esta configuración *Bloquear Relación de Aspecto* preserva solo la relación de aspecto de la forma y no de la imagen que contiene.

{{% /alert %}}

## **Usar Propiedad StretchOff**

Usando las propiedades [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight,](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) y [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) y de la clase [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat), puedes especificar un rectángulo de relleno. 

Cuando se especifica un estiramiento para una imagen, un rectángulo fuente se escala para ajustarse al rectángulo de relleno especificado. Cada borde del rectángulo de relleno está definido por un desplazamiento porcentual del borde correspondiente de la caja delimitadora de la forma. Un porcentaje positivo especifica un inseto, mientras que un porcentaje negativo especifica un outset.

1. Crea una instancia de la clase [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una **AutoShape** de rectángulo. 
4. Crea una imagen.
5. Establece el tipo de relleno de la forma.
6. Establece el modo de relleno de imagen de la forma.
7. Agrega una imagen fijada para llenar la forma.
8. Especifica los desplazamientos de la imagen desde el borde correspondiente de la caja delimitadora de la forma.
9. Escribe la presentación modificada como un archivo PPTX.

Este código C# demuestra un proceso en el que se usa una propiedad StretchOff:

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