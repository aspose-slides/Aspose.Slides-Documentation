---
title: Bild
type: docs
weight: 50
url: /de/net/examples/elements/picture/
keywords:
- Bildbeispiel
- Bilderrahmen
- Bild hinzufügen
- Bild abrufen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit Bildern in C# unter Verwendung von Aspose.Slides: Einfügen, Ersetzen, Zuschneiden, Komprimieren, Transparenz und Effekte anpassen, Formen füllen und für PPT, PPTX und ODP exportieren."
---

Zeigt, wie man Bilder aus im Speicher befindlichen Bildern mit **Aspose.Slides for .NET** einfügt und darauf zugreift. Die nachstehenden Beispiele erzeugen ein Bild im Speicher, platzieren es auf einer Folie und rufen es anschließend ab.

## Bild hinzufügen

Dieser Code erzeugt ein kleines Bitmap, konvertiert es in einen Stream und fügt es als Bilderrahmen auf der ersten Folie ein.
```csharp
public static void Add_Picture()
{
    using var pres = new Presentation();

    // Erstelle ein einfaches Bild im Speicher
    using var bmp = new Bitmap(width: 100, height: 100);
    using (var g = Graphics.FromImage(bmp))
    {
        g.Clear(Color.LightGreen);
    }

    // Konvertiere Bitmap in MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Füge das Bild zur Präsentation hinzu
    var ppImage = pres.Images.AddImage(imageStream);

    // Füge einen Bilderrahmen ein, der das Bild auf der ersten Folie anzeigt
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bmp.Width, height: bmp.Height, ppImage);

    pres.Save(@"c:\_tmp\xxx.pptx", SaveFormat.Pptx);
}
```


## Zugriff auf ein Bild

Dieses Beispiel stellt sicher, dass eine Folie einen Bilderrahmen enthält, und greift dann auf den ersten gefundene zu.
```csharp
public static void Access_Picture()
{
    using var pres = new Presentation();

    // Stelle sicher, dass mindestens ein Bilderrahmen vorhanden ist
    using var bmp = new Bitmap(40, 40);

    // Konvertiere Bitmap in MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Füge das Bild zur Präsentation hinzu
    var ppImage = pres.Images.AddImage(imageStream);
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, ppImage);

    // Greife auf den ersten Bilderrahmen der Folie zu
    var pictureFrame = pres.Slides[0].Shapes.OfType<PictureFrame>().First();
}
```
