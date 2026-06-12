---
title: Afbeelding
type: docs
weight: 50
url: /nl/net/examples/elements/picture/
keywords:
- afbeelding
- afbeeldingsframe
- afbeelding toevoegen
- afbeelding benaderen
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Werken met afbeeldingen in Aspose.Slides for .NET: afbeeldingen invoegen, bijsnijden, comprimeren, kleuren aanpassen en exporteren met C#-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel toont hoe u afbeeldingen uit in-memory-beelden kunt invoegen en benaderen met **Aspose.Slides for .NET**. De onderstaande voorbeelden maken een afbeelding in het geheugen, plaatsen deze op een dia en halen hem daarna weer op.

## **Afbeelding toevoegen**

Deze code maakt een kleine bitmap, zet deze om naar een stream en voegt hem in als een afbeeldingsframe op de eerste dia.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Maak een eenvoudige afbeelding in het geheugen.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Zet de bitmap om naar een MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Voeg de afbeelding toe aan de presentatie.
    var image = presentation.Images.AddImage(imageStream);

    // Voeg een afbeeldingsframe in dat de afbeelding toont op de eerste dia.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Afbeelding benaderen**

Dit voorbeeld controleert of een dia een afbeeldingsframe bevat en krijgt vervolgens de eerste die gevonden wordt.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Zorg dat er minstens één afbeeldingsframe is om mee te werken.
    using var bitmap = new Bitmap(40, 40);

    // Zet de bitmap om naar een MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Voeg de afbeelding toe aan de presentatie.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Benader het eerste afbeeldingsframe op de dia.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```