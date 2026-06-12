---
title: Immagine
type: docs
weight: 50
url: /it/net/examples/elements/picture/
keywords:
- immagine
- fotogramma immagine
- aggiungi immagine
- accedi immagine
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Lavora con le immagini in Aspose.Slides per .NET: inserisci, ritaglia, comprimi, cambia colore ed esporta le immagini con esempi C# per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come inserire e accedere alle immagini da immagini in memoria usando **Aspose.Slides for .NET**. Gli esempi seguenti creano un'immagine in memoria, la posizionano su una diapositiva e poi la recuperano.

## **Aggiungi un'immagine**
Questo codice genera un piccolo bitmap, lo converte in un flusso e lo inserisce come fotogramma immagine nella prima diapositiva.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Crea un'immagine semplice in memoria.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Converti il bitmap in MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Aggiungi l'immagine alla presentazione.
    var image = presentation.Images.AddImage(imageStream);

    // Inserisci un fotogramma immagine che mostra l'immagine nella prima diapositiva.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Accedi a un'immagine**
Questo esempio garantisce che una diapositiva contenga un fotogramma immagine e poi accede al primo che trova.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Assicurati che ci sia almeno un fotogramma immagine con cui lavorare.
    using var bitmap = new Bitmap(40, 40);

    // Converti il bitmap in MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Aggiungi l'immagine alla presentazione.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Accedi al primo fotogramma immagine nella diapositiva.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```