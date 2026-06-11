---
title: Bild
type: docs
weight: 50
url: /sv/net/examples/elements/picture/
keywords:
- bild
- bildram
- lägg till bild
- åtkomst till bild
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Arbeta med bilder i Aspose.Slides för .NET: infoga, beskära, komprimera, färga om och exportera bilder med C#-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur du infogar och får åtkomst till bilder från minnesbilder med hjälp av **Aspose.Slides for .NET**. Exemplen nedan skapar en bild i minnet, placerar den på en bild och hämtar den sedan.

## **Lägg till en bild**

Den här koden genererar en liten bitmap, konverterar den till en ström och infogar den som en bildram på den första bilden.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Skapa en enkel bild i minnet.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Konvertera bitmappen till MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Lägg till bilden i presentationen.
    var image = presentation.Images.AddImage(imageStream);

    // Infoga en bildram som visar bilden på den första bilden.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Få åtkomst till en bild**

Det här exemplet säkerställer att en bild innehåller en bildram och får sedan åtkomst till den första den hittar.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Säkerställ att det finns minst en bildram att arbeta med.
    using var bitmap = new Bitmap(40, 40);

    // Konvertera bitmappen till MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Lägg till bilden i presentationen.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Få åtkomst till den första bildramen på bilden.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```