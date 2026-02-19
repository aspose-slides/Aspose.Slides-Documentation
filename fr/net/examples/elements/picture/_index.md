---
title: Image
type: docs
weight: 50
url: /fr/net/examples/elements/picture/
keywords:
- image
- cadre d'image
- ajouter une image
- accéder à une image
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travailler avec les images dans Aspose.Slides pour .NET : insérer, recadrer, compresser, recolorer et exporter des images avec des exemples C# pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment insérer et accéder à des images à partir d'images en mémoire en utilisant **Aspose.Slides for .NET**. Les exemples ci-dessous créent une image en mémoire, la placent sur une diapositive, puis la récupèrent.

## **Ajouter une image**

Ce code génère un petit bitmap, le convertit en flux et l'insère comme cadre d'image sur la première diapositive.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Créer une image simple en mémoire.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Convertir le bitmap en MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Ajouter l'image à la présentation.
    var image = presentation.Images.AddImage(imageStream);

    // Insérer un cadre d'image affichant l'image sur la première diapositive.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Accéder à une image**

Cet exemple vérifie qu'une diapositive contient un cadre d'image puis accède au premier trouvé.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // S'assurer qu'il y a au moins un cadre d'image à manipuler.
    using var bitmap = new Bitmap(40, 40);

    // Convertir le bitmap en MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Ajouter l'image à la présentation.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Accéder au premier cadre d'image sur la diapositive.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```