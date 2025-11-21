---
title: Imagen
type: docs
weight: 50
url: /es/net/examples/elements/picture/
keywords:
- ejemplo de imagen
- marco de imagen
- agregar imagen
- acceder a imagen
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con imágenes en C# usando Aspose.Slides: inserte, reemplace, recorte, comprima, ajuste la transparencia y los efectos, rellene formas y exporte a PPT, PPTX y ODP."
---

Muestra cómo insertar y acceder a imágenes desde imágenes en memoria usando **Aspose.Slides for .NET**. Los ejemplos a continuación crean una imagen en memoria, la colocan en una diapositiva y luego la recuperan.

## Añadir una imagen

Este código genera un bitmap pequeño, lo convierte en un flujo y lo inserta como un marco de imagen en la primera diapositiva.
```csharp
public static void Add_Picture()
{
    using var pres = new Presentation();

    // Crear una imagen simple en memoria
    using var bmp = new Bitmap(width: 100, height: 100);
    using (var g = Graphics.FromImage(bmp))
    {
        g.Clear(Color.LightGreen);
    }

    // Convertir Bitmap a MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Añadir la imagen a la presentación
    var ppImage = pres.Images.AddImage(imageStream);

    // Insertar un marco de imagen que muestra la imagen en la primera diapositiva
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bmp.Width, height: bmp.Height, ppImage);

    pres.Save(@"c:\_tmp\xxx.pptx", SaveFormat.Pptx);
}
```


## Acceder a una imagen

Este ejemplo verifica que una diapositiva contenga un marco de imagen y luego accede al primero que encuentra.
```csharp
public static void Access_Picture()
{
    using var pres = new Presentation();

    // Asegúrese de que haya al menos un marco de imagen para trabajar
    using var bmp = new Bitmap(40, 40);

    // Convertir Bitmap a MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Añadir la imagen a la presentación
    var ppImage = pres.Images.AddImage(imageStream);
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, ppImage);

    // Acceder al primer marco de imagen en la diapositiva
    var pictureFrame = pres.Slides[0].Shapes.OfType<PictureFrame>().First();
}
```
