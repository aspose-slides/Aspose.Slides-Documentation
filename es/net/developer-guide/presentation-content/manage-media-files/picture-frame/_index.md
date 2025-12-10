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
- imagen rasterizada
- imagen vectorial
- recortar imagen
- área recortada
- propiedad StretchOff
- formato de marco de imagen
- propiedades del marco de imagen
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
description: "Agregue marcos de imagen a presentaciones PowerPoint y OpenDocument con Aspose.Slides para .NET. Optimice su flujo de trabajo y mejore los diseños de diapositivas."
---

Un marco de imagen es una forma que contiene una imagen; es como una foto en un marco. 

Puedes agregar una imagen a una diapositiva mediante un marco de imagen. De esta manera, puedes dar formato a la imagen formateando el marco de imagen.

{{% alert  title="Tip" color="primary" %}} 
Aspose ofrece convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 
{{% /alert %}} 

## **Crear un Marco de Imagen**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Obtén una referencia a una diapositiva a través de su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) asociada al objeto presentation que se utilizará para rellenar la forma.
4. Especifica el ancho y la altura de la imagen.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) basado en el ancho y la altura de la imagen mediante el método `AddPictureFrame` expuesto por el objeto shape asociado a la diapositiva referenciada.
6. Añade un marco de imagen (que contiene la foto) a la diapositiva.
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

    // Escribe la presentación en un archivo PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" %}} 
Los marcos de imagen te permiten crear rápidamente diapositivas de presentación basadas en imágenes. Cuando combinas un marco de imagen con las opciones de guardado de Aspose.Slides, puedes manipular operaciones de entrada/salida para convertir imágenes de un formato a otro. Puede que quieras ver estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).
{{% /alert %}}

## **Crear un Marco de Imagen con Escala Relativa**

Al alterar la escala relativa de una imagen, puedes crear un marco de imagen más complejo. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Obtén una referencia a una diapositiva a través de su índice. 
3. Añade una imagen a la colección de imágenes de la presentación.
4. Crea un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) asociada al objeto presentation que se utilizará para rellenar la forma.
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


## **Extraer Imágenes Rasterizadas de los Marcos de Imagen**

Puedes extraer imágenes rasterizadas de objetos [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) y guardarlas en PNG, JPG y otros formatos. El ejemplo de código a continuación muestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.
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


## **Extraer Imágenes SVG de los Marcos de Imagen**

Cuando una presentación contiene gráficos SVG colocados dentro de formas [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), Aspose.Slides para .NET permite recuperar las imágenes vectoriales originales con plena fidelidad. Al recorrer la colección de formas de la diapositiva, puedes identificar cada [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), comprobar si el [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) subyacente contiene contenido SVG y, a continuación, guardar esa imagen en disco o en un flujo en su formato SVG nativo.

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


## **Obtener Transparencia de una Imagen**

Aspose.Slides te permite obtener el efecto de transparencia aplicado a una imagen. Este código C# demuestra la operación:
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

## **Formato de Marcos de Imagen**

Aspose.Slides ofrece muchas opciones de formato que pueden aplicarse a un marco de imagen. Con esas opciones, puedes modificar un marco de imagen para que cumpla requisitos específicos.

1. Crea una instancia de la clase [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Obtén una referencia a una diapositiva a través de su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) asociada al objeto presentation que se utilizará para rellenar la forma.
4. Especifica el ancho y la altura de la imagen.
5. Crea un `PictureFrame` basado en el ancho y la altura de la imagen mediante el método [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) expuesto por el objeto [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) asociado a la diapositiva referenciada.
6. Añade el marco de imagen (que contiene la foto) a la diapositiva.
7. Establece el color de línea del marco de imagen.
8. Establece el ancho de línea del marco de imagen.
9. Rota el marco de imagen dándole un valor positivo o negativo.
   * Un valor positivo rota la imagen en sentido horario. 
   * Un valor negativo rota la imagen en sentido antihorario.
10. Añade el marco de imagen (que contiene la foto) a la diapositiva.
11. Guarda la presentación modificada como un archivo PPTX.

Este código C# muestra el proceso de formateo del marco de imagen:
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

    // Agrega un marco de imagen con la misma altura y anchura de la imagen
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Aplica algo de formato al marco de imagen
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Escribe la presentación en un archivo PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}

Aspose ha desarrollado recientemente un [Collage Maker gratuito](https://products.aspose.app/slides/collage). Si alguna vez necesitas [fusionar JPG/JPEG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG, [crear cuadrículas a partir de fotos](https://products.aspose.app/slides/collage/photo-grid), puedes usar este servicio. 

{{% /alert %}}

## **Agregar una Imagen como Enlace**

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


## **Recortar Imágenes**

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


## **Eliminar Áreas Recortadas de una Imagen**

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


{{% alert title="NOTE" color="warning" %}} 

El método [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) agrega la imagen recortada a la colección de imágenes de la presentación. Si la imagen se usa solo en el [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) procesado, esta configuración puede reducir el tamaño de la presentación. De lo contrario, aumentará el número de imágenes en la presentación resultante.

Este método convierte los metarchivos WMF/EMF a imágenes PNG raster en la operación de recorte. 

{{% /alert %}}

## **Comprimir Imágenes**

Puedes comprimir una imagen en una presentación usando el método [`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/). 
Este método comprime una imagen reduciendo su tamaño según el tamaño de la forma y la resolución especificada, con la opción de eliminar áreas recortadas. 

Ajusta el tamaño y la resolución de la imagen de forma similar a la característica **Formato de Imagen → Comprimir Imágenes → Resolución** de PowerPoint.

Los siguientes ejemplos en C# demuestran cómo comprimir una imagen en una presentación especificando una resolución objetivo y, opcionalmente, eliminando áreas recortadas:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtiene el PictureFrame de la diapositiva
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Comprime la imagen con una resolución objetivo de 150 DPI (resolución web) y elimina áreas recortadas
    bool result = picFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Verifica el resultado de la compresión
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


O usando un valor DPI personalizado directamente:
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

El método convierte la imagen a una resolución inferior según el tamaño de la forma y el DPI proporcionado. Las regiones recortadas también pueden eliminarse para optimizar el tamaño del archivo.  
Si la imagen es un metarchivo (WMF/EMF) o SVG, no se aplicará compresión. Además, la calidad JPEG se conserva o se reduce ligeramente según la resolución, de forma similar a cómo PowerPoint maneja JPEGs de alta resolución.

{{% /alert %}}

## **Bloquear Relación de Aspecto**

Si deseas que una forma que contiene una imagen mantenga su relación de aspecto incluso después de cambiar las dimensiones de la imagen, puedes usar la propiedad [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) para establecer la configuración *Bloquear relación de aspecto*. 

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

    // Establece que la forma preserve la relación de aspecto al cambiar el tamaño
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```


{{% alert title="NOTE" color="warning" %}} 

Esta configuración *Bloquear relación de aspecto* conserva solo la relación de aspecto de la forma y no la de la imagen que contiene.

{{% /alert %}}

## **Usar la Propiedad StretchOff**

Usando las propiedades [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) y [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) y la clase [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat), puedes especificar un rectángulo de relleno. 

Cuando se especifica estiramiento para una imagen, un rectángulo de origen se escala para ajustarse al rectángulo de relleno especificado. Cada borde del rectángulo de relleno se define mediante un desplazamiento porcentual desde el borde correspondiente del cuadro delimitador de la forma. Un porcentaje positivo indica una inserción mientras que un porcentaje negativo indica una expansión.

1. Crea una instancia de la clase [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Obtén una referencia a una diapositiva a través de su índice.
3. Añade un rectángulo `AutoShape`. 
4. Crea una imagen.
5. Establece el tipo de relleno de la forma.
6. Establece el modo de relleno de imagen de la forma.
7. Añade una imagen establecida para rellenar la forma.
8. Especifica los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma
9. Guarda la presentación modificada como un archivo PPTX.

Este código C# muestra un proceso en el que se utiliza la propiedad StretchOff:
```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

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

**¿Cómo puedo saber qué formatos de imagen son compatibles con PictureFrame?**

Aspose.Slides admite tanto imágenes raster (PNG, JPEG, BMP, GIF, etc.) como imágenes vectoriales (por ejemplo, SVG) mediante el objeto de imagen asignado a un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/). La lista de formatos compatibles generalmente se superpone con las capacidades del motor de conversión de diapositivas e imágenes.

**¿Cómo afectará la incorporación de decenas de imágenes grandes al tamaño y rendimiento del PPTX?**

Incrustar imágenes grandes aumenta el tamaño del archivo y el uso de memoria; enlazar imágenes ayuda a mantener bajo el tamaño de la presentación pero requiere que los archivos externos permanezcan accesibles. Aspose.Slides permite agregar imágenes mediante enlace para reducir el tamaño del archivo.

**¿Cómo puedo bloquear un objeto de imagen para que no se mueva o redimensione accidentalmente?**

Utiliza los bloqueos de forma ([shape locks](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/)) para un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) (por ejemplo, desactivar mover o redimensionar). El mecanismo de bloqueo se describe para formas en un artículo de [protección separado](/slides/es/net/applying-protection-to-presentation/) y es compatible con varios tipos de formas, incluido [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/).

**¿Se conserva la fidelidad vectorial SVG al exportar una presentación a PDF/imágenes?**

Aspose.Slides permite extraer un SVG de un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) como el vector original. Al [exportar a PDF](/slides/es/net/convert-powerpoint-to-pdf/) o a [formatos raster](/slides/es/net/convert-powerpoint-to-png/), el resultado puede rasterizarse según la configuración de exportación; el hecho de que el SVG original se almacene como vector se confirma mediante el comportamiento de extracción.