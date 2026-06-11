---
title: Obraz
type: docs
weight: 50
url: /pl/net/examples/elements/picture/
keywords:
- obraz
- ramka obrazu
- dodaj obraz
- dostęp do obrazu
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Pracuj z obrazami w Aspose.Slides dla .NET: wstawiaj, przycinaj, kompresuj, zmieniaj kolor i eksportuj obrazy przy użyciu przykładów C# dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje, jak wstawić i uzyskać dostęp do obrazów z pamięci przy użyciu **Aspose.Slides for .NET**. Poniższe przykłady tworzą obraz w pamięci, umieszczają go na slajdzie, a następnie go pobierają.

## **Dodaj obraz**

Ten kod generuje małą bitmapę, konwertuje ją na strumień i wstawia jako ramkę obrazu na pierwszym slajdzie.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Utwórz prosty obraz w pamięci.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Konwertuj bitmapę na MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Dodaj obraz do prezentacji.
    var image = presentation.Images.AddImage(imageStream);

    // Wstaw ramkę obrazu wyświetlającą obraz na pierwszym slajdzie.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Uzyskaj dostęp do obrazu**

Ten przykład zapewnia, że slajd zawiera ramkę obrazu, a następnie uzyskuje dostęp do pierwszej znalezionej.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Upewnij się, że istnieje co najmniej jedna ramka obrazu do użycia.
    using var bitmap = new Bitmap(40, 40);

    // Konwertuj bitmapę na MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Dodaj obraz do prezentacji.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Uzyskaj dostęp do pierwszej ramki obrazu na slajdzie.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```