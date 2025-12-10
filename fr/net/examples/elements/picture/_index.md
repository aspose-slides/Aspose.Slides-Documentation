---
title: Image
type: docs
weight: 50
url: /fr/net/examples/elements/picture/
keywords:
- exemple d'image
- cadre d'image
- ajouter une image
- accéder à l'image
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travailler avec les images en C# avec Aspose.Slides : insérer, remplacer, recadrer, compresser, ajuster la transparence et les effets, remplir des formes, et exporter vers PPT, PPTX et ODP."
---

Montre comment inserer et acceder aux images a partir d'images en memoire en utilisant **Aspose.Slides for .NET**. Les exemples ci-dessous creent une image en memoire, la placent sur une diapositive, puis la recuperent.

## **Ajouter une image**

Ce code genere un petit bitmap, le convertit en flux, et l'insere comme un cadre d'image sur la premiere diapositive.
```csharp
public static void Add_Picture()
{
    using var pres = new Presentation();

    // Crée une image simple en mémoire
    using var bmp = new Bitmap(width: 100, height: 100);
    using (var g = Graphics.FromImage(bmp))
    {
        g.Clear(Color.LightGreen);
    }

    // Convertit le Bitmap en MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Ajoute l'image à la présentation
    var ppImage = pres.Images.AddImage(imageStream);

    // Insère un cadre d'image affichant l'image sur la première diapositive
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bmp.Width, height: bmp.Height, ppImage);

    pres.Save(@"c:\_tmp\xxx.pptx", SaveFormat.Pptx);
}
```


## **Acceder à une image**

Cet exemple s'assure qu'une diapositive contient un cadre d'image, puis accede au premier trouve.
```csharp
public static void Access_Picture()
{
    using var pres = new Presentation();

    // Assurez-vous qu'il y a au moins un cadre d'image à utiliser
    using var bmp = new Bitmap(40, 40);

    // Convertir le Bitmap en MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Ajouter l'image à la présentation
    var ppImage = pres.Images.AddImage(imageStream);
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, ppImage);

    // Accéder au premier cadre d'image sur la diapositive
    var pictureFrame = pres.Slides[0].Shapes.OfType<PictureFrame>().First();
}
```
