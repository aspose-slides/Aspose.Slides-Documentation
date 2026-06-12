---
title: Presentatieslides converteren naar afbeeldingen in .NET
linktitle: Slide naar afbeelding
type: docs
weight: 41
url: /nl/net/convert-slide/
keywords:
- slide converteren
- slide exporteren
- slide naar afbeelding
- slide opslaan als afbeelding
- slide naar PNG
- slide naar JPEG
- slide naar bitmap
- slide naar TIFF
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Converteer slides van PPT, PPTX en ODP naar afbeeldingen in C# met Aspose.Slides voor .NET — snelle, hoogwaardige weergave met duidelijke codevoorbeelden."
---
## **Introductie**

Aspose.Slides voor .NET stelt u in staat om eenvoudig PowerPoint- en OpenDocument-presentatieslides te converteren naar verschillende afbeeldingsformaten, waaronder BMP, PNG, JPG (JPEG), GIF en andere.

Om een slide naar een afbeelding te converteren, volgt u deze stappen:

1. Definieer de gewenste conversie‑instellingen en selecteer de slides die u wilt exporteren door gebruik te maken van:
    - De [ITiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/itiffoptions/) interface, of
    - De [IRenderingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/irenderingoptions/) interface.
2. Genereer de slide‑afbeelding door de [GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/)‑methode aan te roepen.

In .NET is een [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) een object waarmee u kunt werken met afbeeldingen die zijn gedefinieerd door pixelgegevens. U kunt een instantie van deze klasse gebruiken om afbeeldingen op te slaan in een breed scala aan formaten (BMP, JPG, PNG, enz.).

## **Slides converteren naar Bitmaps en de afbeeldingen opslaan in PNG**

U kunt een slide converteren naar een bitmap‑object en deze direct in uw applicatie gebruiken. Alternatief kunt u een slide converteren naar een bitmap en vervolgens de afbeelding opslaan in JPEG of een ander gewenst formaat.

Deze C#‑code laat zien hoe u de eerste slide van een presentatie kunt converteren naar een bitmap‑object en vervolgens de afbeelding opslaat in PNG‑formaat:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Converteer de eerste slide in de presentatie naar een bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Sla de afbeelding op in PNG-formaat.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Slides converteren naar afbeeldingen met aangepaste afmetingen**

U wilt misschien een afbeelding van een bepaalde grootte verkrijgen. Met een overload van de [GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/) kunt u een slide converteren naar een afbeelding met specifieke afmetingen (breedte en hoogte). 

Deze voorbeeldcode laat zien hoe u dit doet:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Converteer de eerste slide in de presentatie naar een bitmap met de opgegeven grootte.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Sla de afbeelding op in JPEG-formaat.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Slides met aantekeningen en opmerkingen converteren naar afbeeldingen**

Sommige slides kunnen aantekeningen en opmerkingen bevatten.

Aspose.Slides biedt twee interfaces—[ITiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/itiffoptions/) en [IRenderingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/irenderingoptions/)—die u in staat stellen de rendering van presentatieslides naar afbeeldingen te beheersen. Beide interfaces bevatten de eigenschap `SlidesLayoutOptions`, waarmee u de rendering van aantekeningen en opmerkingen op een slide kunt configureren bij het converteren naar een afbeelding.

Met de klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/notescommentslayoutingoptions/) kunt u de gewenste positie voor aantekeningen en opmerkingen in de resulterende afbeelding opgeven.

Deze C#‑code laat zien hoe u een slide met aantekeningen en opmerkingen kunt converteren:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Laad een presentatiebestand.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Maak de rendering‑opties aan.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Stel de positie van de notities in.
            CommentsPosition = CommentsPositions.Right,      // Stel de positie van de opmerkingen in.
            CommentsAreaWidth = 500,                         // Stel de breedte van het opmerkingen‑gebied in.
            CommentsAreaColor = Color.AntiqueWhite           // Stel de kleur van het opmerkingen‑gebied in.
        }
    };

    // Converteer de eerste slide van de presentatie naar een afbeelding.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Sla de afbeelding op in GIF‑formaat.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
In elk slide‑naar‑afbeelding‑conversieproces kan de eigenschap [NotesPosition](https://reference.aspose.com/slides/nl/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) niet worden ingesteld op `BottomFull` (om de positie van aantekeningen te bepalen) omdat de tekst van een aantekening mogelijk te groot is, waardoor deze niet binnen de opgegeven afbeeldingsgrootte past.
{{% /alert %}} 

## **Slides converteren naar afbeeldingen met TIFF‑opties**

De [ITiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/itiffoptions/) interface biedt meer controle over de resulterende TIFF‑afbeelding door u parameters zoals grootte, resolutie, kleurenpalet en meer te laten specificeren.

Deze C#‑code laat een conversieproces zien waarbij TIFF‑opties worden gebruikt om een zwart‑wit afbeelding te genereren met een resolutie van 300 DPI en een grootte van 2160 × 2800:

```cs
// Laad een presentatiebestand.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Haal de eerste slide uit de presentatie.
    ISlide slide = presentation.Slides[0];

    // Configureer de instellingen van de uitvoer-TIFF-afbeelding.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Stel de afbeeldingsgrootte in.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Stel het pixelformaat in (zwart-wit).
        DpiX = 300,                                        // Stel de horizontale resolutie in.
        DpiY = 300                                         // Stel de verticale resolutie in.
    };

    // Converteer de slide naar een afbeelding met de opgegeven opties.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Sla de afbeelding op in TIFF-formaat.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Alle slides converteren naar afbeeldingen**

Aspose.Slides stelt u in staat om alle slides in een presentatie te converteren naar afbeeldingen, waardoor de volledige presentatie wordt omgezet in een reeks afbeeldingen.

Deze voorbeeldcode laat zien hoe u alle slides in een presentatie kunt converteren naar afbeeldingen in C#:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Render de presentatie naar afbeeldingen dia per dia.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // Beheer verborgen dia's (render geen verborgen dia's).
        if (presentation.Slides[i].Hidden)
            continue;

        // Converteer de dia naar een afbeelding.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Sla de afbeelding op in JPEG-formaat.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **FAQ**

**1. Ondersteunt Aspose.Slides het renderen van slides met animaties?**

Nee, de methode `GetImage` slaat alleen een statische afbeelding van de slide op, zonder animaties.

**2. Kunnen verborgen slides worden geëxporteerd als afbeeldingen?**

Ja, verborgen slides kunnen net als reguliere slides worden verwerkt. Zorg er alleen voor dat ze zijn opgenomen in de verwerkingslus.

**3. Kunnen afbeeldingen worden opgeslagen met schaduwen en effecten?**

Ja, Aspose.Slides ondersteunt het renderen van schaduwen, transparantie en andere grafische effecten bij het opslaan van slides als afbeeldingen.