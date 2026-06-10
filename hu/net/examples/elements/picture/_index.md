---
title: Kép
type: docs
weight: 50
url: /hu/net/examples/elements/picture/
keywords:
- kép
- képkocka
- kép hozzáadása
- kép elérése
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Képek kezelése az Aspose.Slides for .NET-ben: beszúrás, vágás, tömörítés, újraszínezés és képek exportálása C# példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan szúrhat be és érhet el képeket a memóriában lévő képekből a **Aspose.Slides for .NET** használatával. Az alábbi példák memóriában hoznak létre egy képet, elhelyezik azt egy dián, majd lekérik.

## **Kép hozzáadása**

Ez a kód egy kis bitmapet generál, átalakítja streammá, és a első diára képkockaként illeszti be.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Hozzon létre egy egyszerű memória-alapú képet.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Alakítsa át a bitmapet MemoryStream-re.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Adja hozzá a képet a bemutatóhoz.
    var image = presentation.Images.AddImage(imageStream);

    // Illessze be a képet megjelenítő képkockát az első diára.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Kép elérése**

Ez a példa biztosítja, hogy egy dia tartalmazzon képkockát, majd eléri az elsőként megtaláltat.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Biztosítsa, hogy legalább egy képkocka legyen, amivel dolgozhat.
    using var bitmap = new Bitmap(40, 40);

    // Alakítsa át a bitmapet MemoryStream-re.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Adja hozzá a képet a bemutatóhoz.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Hozzáférés a dia első képkockájához.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```