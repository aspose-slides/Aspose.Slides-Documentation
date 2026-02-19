---
title: Imagen
type: docs
weight: 50
url: /es/net/examples/elements/picture/
keywords:
- imagen
- marco de imagen
- añadir imagen
- acceder a la imagen
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con imágenes en Aspose.Slides for .NET: inserte, recorte, comprima, recoloree y exporte imágenes con ejemplos en C# para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo insertar y acceder a imágenes desde imágenes en memoria usando **Aspose.Slides for .NET**. Los ejemplos siguientes crean una imagen en memoria, la colocan en una diapositiva y luego la recuperan.

## **Añadir una imagen**

Este código genera un pequeño mapa de bits, lo convierte en un flujo y lo inserta como un marco de imagen en la primera diapositiva.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Crear una imagen sencilla en memoria.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Convertir el mapa de bits a MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Añadir la imagen a la presentación.
    var image = presentation.Images.AddImage(imageStream);

    // Insertar un marco de imagen que muestra la imagen en la primera diapositiva.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Acceder a una imagen**

Este ejemplo garantiza que una diapositiva contenga un marco de imagen y luego accede al primero que encuentra.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Asegúrese de que haya al menos un marco de imagen con el que trabajar.
    using var bitmap = new Bitmap(40, 40);

    // Convertir el mapa de bits a MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Añadir la imagen a la presentación.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Acceder al primer marco de imagen en la diapositiva.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```