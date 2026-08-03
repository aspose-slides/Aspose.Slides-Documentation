---
title: Konvertera presentationsbildrutor till bilder i .NET
linktitle: Bildruta till bild
type: docs
weight: 41
url: /sv/net/convert-slide/
keywords:
- konvertera bildruta
- exportera bildruta
- bildruta till bild
- spara bildruta som bild
- bildruta till PNG
- bildruta till JPEG
- bildruta till bitmap
- bildruta till TIFF
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Konvertera bildrutor från PPT, PPTX och ODP till bilder i C# med Aspose.Slides för .NET—snabb, högkvalitativ rendering med tydliga kodexempel."
---
## **Introduktion**

Aspose.Slides för .NET gör det enkelt att konvertera PowerPoint- och OpenDocument-presentationer till olika bildformat, inklusive BMP, PNG, JPG (JPEG), GIF och andra.

För att konvertera en bildruta till en bild, följ dessa steg:

1. Definiera önskade konverteringsinställningar och välj de bildrutor du vill exportera genom att använda:
    - [ITiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/itiffoptions/)-gränssnittet, eller
    - [IRenderingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/irenderingoptions/)-gränssnittet.
2. Generera bildrute‑bilden genom att anropa metoden [GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/).

I .NET är en [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) ett objekt som gör att du kan arbeta med bilder definierade av pixeldata. Du kan använda en instans av denna klass för att spara bilder i ett brett spektrum av format (BMP, JPG, PNG osv.).

## **Konvertera bildrutor till bitmaps och spara bilderna i PNG**

Du kan konvertera en bildruta till ett bitmap‑objekt och använda det direkt i din applikation. Alternativt kan du konvertera en bildruta till en bitmap och sedan spara bilden i JPEG eller något annat föredraget format.

Den här C#‑koden visar hur du konverterar den första bildrutan i en presentation till ett bitmap‑objekt och sedan sparar bilden i PNG‑format:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Konvertera den första bildrutan i presentationen till en bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Spara bilden i PNG-format.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Konvertera bildrutor till bilder med anpassade storlekar**

Du kan behöva en bild i en viss storlek. Genom att använda en overlagring från [GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/), kan du konvertera en bildruta till en bild med specifika dimensioner (bredd och höjd).

Detta exempel visar hur du gör detta:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Konvertera den första bildrutan i presentationen till en bitmap med den angivna storleken.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Spara bilden i JPEG-format.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Konvertera bildrutor med anteckningar och kommentarer till bilder**

Vissa bildrutor kan innehålla anteckningar och kommentarer.

Aspose.Slides tillhandahåller två gränssnitt—[ITiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/itiffoptions/) och [IRenderingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/irenderingoptions/)—som låter dig styra rendering av presentationens bildrutor till bilder. Båda gränssnitten innehåller egenskapen `SlidesLayoutOptions`, som gör det möjligt att konfigurera rendering av anteckningar och kommentarer på en bildruta när den konverteras till en bild.

Med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/notescommentslayoutingoptions/) kan du ange önskad position för anteckningar och kommentarer i den resulterande bilden.

Den här C#‑koden visar hur du konverterar en bildruta med anteckningar och kommentarer:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Ladda en presentationsfil.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Skapa renderingsalternativen.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Sätt positionen för anteckningarna.
            CommentsPosition = CommentsPositions.Right,      // Sätt positionen för kommentarerna.
            CommentsAreaWidth = 500,                         // Sätt bredden på kommentarsområdet.
            CommentsAreaColor = Color.AntiqueWhite           // Sätt färgen för kommentarsområdet.
        }
    };

    // Konvertera den första bildrutan i presentationen till en bild.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Spara bilden i GIF-format.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
I någon bildruta‑till‑bild‑konverteringsprocess kan inte egenskapen [NotesPosition](https://reference.aspose.com/slides/sv/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) sättas till `BottomFull` (för att ange positionen för anteckningar) eftersom en antecknings text kan vara för stor, vilket gör att den inte får plats inom den angivna bildstorleken.
{{% /alert %}} 

## **Konvertera bildrutor till bilder med TIFF‑alternativ**

Gränssnittet [ITiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/itiffoptions/) ger större kontroll över den resulterande TIFF‑bilden genom att låta dig ange parametrar som storlek, upplösning, färgpalett och mer.

Den här C#‑koden visar en konverteringsprocess där TIFF‑alternativ används för att skapa en svart‑vit bild med 300 DPI‑upplösning och en storlek på 2160 × 2800:

```cs
// Ladda en presentationsfil.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Hämta den första bildrutan från presentationen.
    ISlide slide = presentation.Slides[0];

    // Konfigurera inställningarna för den resulterande TIFF‑bilden.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Ange bildstorleken.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Ange pixelformatet (svartvitt).
        DpiX = 300,                                        // Ange den horisontella upplösningen.
        DpiY = 300                                         // Ange den vertikala upplösningen.
    };

    // Konvertera bildrutan till en bild med de angivna alternativen.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Spara bilden i TIFF-format.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Konvertera alla bildrutor till bilder**

Aspose.Slides låter dig konvertera alla bildrutor i en presentation till bilder, vilket effektivt omvandlar hela presentationen till en serie bilder.

Detta exempel visar hur du konverterar alla bildrutor i en presentation till bilder i C#:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Rendera presentationen till bilder bild för bild.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // Kontrollera dolda bildrutor (rendera inte dolda bildrutor).
        if (presentation.Slides[i].Hidden)
            continue;

        // Konvertera bildrutan till en bild.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Spara bilden i JPEG-format.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **Rendering av färg‑emoji**

{{% alert title="Note" color="warning" %}} 
För att rendera färg‑emoji korrekt när du konverterar presentations‑bildrutor till bilder måste de emoji‑typsnitt som används i presentationen vara installerade och tillgängliga på det system som utför konverteringen. Till exempel, om presentationen använder **Segoe UI Emoji** och detta typsnitt saknas, kan emoji visas i monokrom i de genererade bilderna.
{{% /alert %}}

## **FAQ**

**Stöder Aspose.Slides rendering av bildrutor med animationer?**

Nej, metoden `GetImage` sparar endast en statisk bild av bildrutan, utan animationer.

**Kan dolda bildrutor exporteras som bilder?**

Ja, dolda bildrutor kan behandlas på samma sätt som vanliga. Se bara till att de inkluderas i bearbetningsloopen.

**Kan bilder sparas med skuggor och effekter?**

Ja, Aspose.Slides stödjer rendering av skuggor, genomskinlighet och andra grafiska effekter när bildrutor sparas som bilder.