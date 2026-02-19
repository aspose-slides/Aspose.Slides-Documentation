---
title: Bild
type: docs
weight: 50
url: /de/net/examples/elements/picture/
keywords:
- Bild
- Bilderrahmen
- Bild hinzufügen
- Bildzugriff
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten mit Bildern in Aspose.Slides für .NET: Einfügen, Zuschneiden, Komprimieren, Nachfärben und Exportieren von Bildern mit C#-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel zeigt, wie man Bilder aus im Speicher befindlichen Grafiken mit **Aspose.Slides für .NET** einfügt und darauf zugreift. Die nachstehenden Beispiele erstellen ein Bild im Speicher, platzieren es auf einer Folie und rufen es anschließend ab.

## **Bild hinzufügen**

Dieser Code erzeugt ein kleines Bitmap, konvertiert es in einen Stream und fügt es als Bildrahmen auf der ersten Folie ein.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Erstelle ein einfaches Bild im Speicher.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Konvertiere das Bitmap in einen MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Füge das Bild zur Präsentation hinzu.
    var image = presentation.Images.AddImage(imageStream);

    // Füge einen Bilderrahmen ein, der das Bild auf der ersten Folie zeigt.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Zugriff auf ein Bild**

Dieses Beispiel stellt sicher, dass eine Folie einen Bildrahmen enthält, und greift anschließend auf den ersten zu, den es findet.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Stellen Sie sicher, dass mindestens ein Bilderrahmen zum Arbeiten vorhanden ist.
    using var bitmap = new Bitmap(40, 40);

    // Konvertiere das Bitmap in einen MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Füge das Bild zur Präsentation hinzu.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Greife auf den ersten Bilderrahmen der Folie zu.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```