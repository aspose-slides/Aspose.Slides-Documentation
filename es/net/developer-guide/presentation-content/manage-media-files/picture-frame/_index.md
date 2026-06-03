---
title: Gestionar marcos de imagen en presentaciones en .NET
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/net/picture-frame/
keywords:
- marco de imagen
- añadir marco de imagen
- crear marco de imagen
- añadir imagen
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
description: "Añade marcos de imagen a presentaciones PowerPoint y OpenDocument con Aspose.Slides para .NET. Optimiza tu flujo de trabajo y mejora el diseño de las diapositivas."
---
## **Introducción**

Un marco de imagen es una forma que contiene una imagen: es como una foto dentro de un marco.  

Puedes añadir una imagen a una diapositiva mediante un marco de imagen. De este modo, puedes formatear la imagen formateando el marco de imagen.

{{% alert  title="Tip" color="primary" %}} 

Aspose ofrece conversores gratuitos—[JPEG to PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG to PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

## **Crear un marco de imagen**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).  
2. Obtén la referencia a una diapositiva mediante su índice.  
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/es/net/aspose.slides/iimagecollection) asociada al objeto presentación que se utilizará para rellenar la forma.  
4. Especifica el ancho y la altura de la imagen.  
5. Crea un [PictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/pictureframe) basándote en el ancho y la altura de la imagen mediante el método `AddPictureFrame` expuesto por el objeto shape asociado a la diapositiva referenciada.  
6. Añade un marco de imagen (que contiene la foto) a la diapositiva.  
7. Guarda la presentación modificada como archivo PPTX.  

Este código C# muestra cómo crear un marco de imagen:

```c#
// Instancia la clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{
    // Obtiene la primera diapositiva
    ISlide slide = pres.Slides[0];

    // Carga una imagen y la añade a la colección de imágenes de la presentación
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Añade un marco de imagen con la misma altura y anchura
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

Los marcos de imagen permiten crear rápidamente diapositivas de presentación basadas en imágenes. Cuando combináis el marco de imagen con las opciones de guardado de Aspose.Slides, podéis manipular operaciones de entrada/salida para convertir imágenes de un formato a otro. Puede que os interese consultar estas páginas: convertir [image to JPG](https://products.aspose.com/slides/es/net/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/es/net/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/es/net/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/es/net/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/es/net/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/es/net/conversion/svg-to-png/). 

{{% /alert %}}

## **Crear un marco de imagen con escala relativa**

Al modificar la escala relativa de una imagen, puedes crear un marco de imagen más complejo.  

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation).  
2. Obtén la referencia a una diapositiva mediante su índice.  
3. Añade una imagen a la colección de imágenes de la presentación.  
4. Crea un objeto [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/es/net/aspose.slides/iimagecollection) asociada al objeto presentación que se utilizará para rellenar la forma.  
5. Especifica el ancho y la altura relativos de la imagen en el marco de imagen.  
6. Guarda la presentación modificada como archivo PPTX.  

Este código C# muestra cómo crear un marco de imagen con escala relativa:

```c#
    // Instancia la clase Presentation que representa un archivo PPTX
    using (Presentation presentation = new Presentation())
    {
        // Carga una imagen y la añade a la colección de imágenes de la presentación
        IImage image = Images.FromFile("aspose-logo.jpg");
        IPPImage ppImage = presentation.Images.AddImage(image);
        image.Dispose();

        // Añade un marco de imagen a la diapositiva
        IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

        // Establece el ancho y la altura de la escala relativa
        pictureFrame.RelativeScaleHeight = 0.8f;
        pictureFrame.RelativeScaleWidth = 1.35f;

        // Guarda la presentación
        presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
    }
```

## **Extraer imágenes raster de los marcos de imagen**

Puedes extraer imágenes raster de objetos [PictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/pictureframe) y guardarlas en PNG, JPG y otros formatos. El ejemplo de código a continuación muestra cómo extraer una imagen del documento “sample.pptx” y guardarla en formato PNG.

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

## **Extraer imágenes SVG de los marcos de imagen**

Cuando una presentación contiene gráficos SVG situados dentro de formas [PictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/pictureframe/), Aspose.Slides para .NET permite recuperar las imágenes vectoriales originales con total fidelidad. Recorriendo la colección de formas de la diapositiva, puedes identificar cada [PictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/pictureframe/), comprobar si el [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) subyacente contiene contenido SVG y, a continuación, guardar esa imagen en disco o en un flujo en su formato nativo SVG.

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

## **Obtener la transparencia de una imagen**

Aspose.Slides permite obtener el efecto de transparencia aplicado a una imagen. Este código C# muestra la operación:

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
Todos los efectos aplicados a imágenes pueden encontrarse en [Aspose.Slides.Effects](https://reference.aspose.com/slides/es/net/aspose.slides.effects/).
{{% /alert %}}

## **Formato de marcos de imagen**

Aspose.Slides ofrece muchas opciones de formato que pueden aplicarse a un marco de imagen. Con esas opciones, puedes modificar un marco de imagen para que cumpla requisitos específicos.

1. Crea una instancia de la clase [Presentation](http://www.aspose.com/api/net/slides/es/aspose.slides/) .  
2. Obtén la referencia a una diapositiva mediante su índice.  
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/es/net/aspose.slides/iimagecollection) asociada al objeto presentación que se utilizará para rellenar la forma.  
4. Especifica el ancho y la altura de la imagen.