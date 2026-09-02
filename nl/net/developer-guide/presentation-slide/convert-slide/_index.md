---
title: Presentatiedia's omzetten naar afbeeldingen in .NET
linktitle: Dia naar afbeelding
type: docs
weight: 41
url: /nl/net/convert-slide/
keywords:
- dia converteren
- dia exporteren
- dia naar afbeelding
- dia opslaan als afbeelding
- dia naar PNG
- dia naar JPEG
- dia naar bitmap
- dia naar TIFF
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Dia's converteren van PPT, PPTX en ODP naar afbeeldingen in C# met Aspose.Slides voor .NET—snelle, hoogwaardige weergave met heldere code‑voorbeelden."
---
## **Inleiding**

Aspose.Slides for .NET stelt u in staat om eenvoudig PowerPoint- en OpenDocument-presentatiedia's te converteren naar verschillende beeldformaten, waaronder BMP, PNG, JPG (JPEG), GIF en andere.

Om een dia naar een afbeelding te converteren, volgt u deze stappen:

1. Definieer de gewenste conversie‑instellingen en selecteer de dia's die u wilt exporteren met behulp van:
    - De [ITiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/itiffoptions/) interface, of
    - De [IRenderingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/irenderingoptions/) interface.
2. Genereer de dia‑afbeelding door de [GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/) methode aan te roepen.

In .NET is een [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) een object dat u in staat stelt te werken met afbeeldingen gedefinieerd door pixelgegevens. U kunt een instantie van deze klasse gebruiken om afbeeldingen op te slaan in een breed scala aan formaten (BMP, JPG, PNG, enz.).

## **Dia's converteren naar Bitmaps en de afbeeldingen opslaan in PNG**

U kunt een dia converteren naar een bitmap‑object en deze direct in uw applicatie gebruiken. Als alternatief kunt u een dia naar een bitmap converteren en vervolgens de afbeelding opslaan in JPEG of een ander gewenst formaat.

Deze C#‑code laat zien hoe u de eerste dia van een presentatie converteert naar een bitmap‑object en vervolgens de afbeelding opslaat in PNG‑formaat:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Converteer de eerste dia in de presentatie naar een bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Sla de afbeelding op in het PNG-formaat.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Dia's converteren naar Afbeeldingen met Aangepaste Afmetingen**

U heeft mogelijk een afbeelding van een bepaalde grootte nodig. Met een overload van de [GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/) kunt u een dia converteren naar een afbeelding met specifieke afmetingen (breedte en hoogte).

Deze voorbeeldcode toont hoe u dit doet:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Converteer de eerste dia in de presentatie naar een bitmap met de opgegeven grootte.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Sla de afbeelding op in het JPEG-formaat.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Dia's met Notities en Opmerkingen naar Afbeeldingen converteren**

Sommige dia's kunnen notities en opmerkingen bevatten.

Aspose.Slides biedt twee interfaces—[ITiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/itiffoptions/) en [IRenderingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/irenderingoptions/)—die u in staat stellen de weergave van presentatiedia's naar afbeeldingen te regelen. Beide interfaces bevatten de eigenschap `SlidesLayoutOptions`, waarmee u de weergave van notities en opmerkingen op een dia kunt configureren bij het omzetten naar een afbeelding.

Met de klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/notescommentslayoutingoptions/) kunt u de gewenste positie van notities en opmerkingen in de resulterende afbeelding opgeven.

Deze C#‑code laat zien hoe u een dia met notities en opmerkingen converteert:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Laad een presentatiebestand.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Maak de renderopties aan.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Stel de positie van de notities in.
            CommentsPosition = CommentsPositions.Right,      // Stel de positie van de opmerkingen in.
            CommentsAreaWidth = 500,                         // Stel de breedte van het opmerkingengebied in.
            CommentsAreaColor = Color.AntiqueWhite           // Stel de kleur van het opmerkingengebied in.
        }
    };

    // Converteer de eerste dia van de presentatie naar een afbeelding.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Sla de afbeelding op in GIF-formaat.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Opmerking" color="warning" %}} 

In elk dia-naar-afbeelding conversieproces kan de eigenschap [NotesPosition](https://reference.aspose.com/slides/nl/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) niet worden ingesteld op `BottomFull` (om de positie van notities op te geven) omdat de tekst van een notitie te groot kan zijn, waardoor deze niet in de gespecificeerde afbeeldingsgrootte past.

{{% /alert %}} 

## **Dia's converteren naar Afbeeldingen met TIFF‑opties**

De [ITiffOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/itiffoptions/) interface biedt meer controle over de resulterende TIFF‑afbeelding door u parameters zoals grootte, resolutie, kleurenpalet en meer te kunnen specificeren.

Deze C#‑code toont een conversieproces waarbij TIFF‑opties worden gebruikt om een zwart‑wit afbeelding te genereren met een resolutie van 300 DPI en een grootte van 2160 × 2800:

```cs
// Laad een presentatiebestand.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Haal de eerste dia uit de presentatie.
    ISlide slide = presentation.Slides[0];

    // Configureer de instellingen van de uitvoer TIFF-afbeelding.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Stel de afbeeldinggrootte in.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Stel het pixelformaat in (zwart-wit).
        DpiX = 300,                                        // Stel de horizontale resolutie in.
        DpiY = 300                                         // Stel de verticale resolutie in.
    };

    // Converteer de dia naar een afbeelding met de opgegeven opties.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Sla de afbeelding op in TIFF-formaat.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Alle dia's naar Afbeeldingen converteren**

Aspose.Slides stelt u in staat om alle dia's in een presentatie naar afbeeldingen te converteren, waardoor de volledige presentatie werd omgezet in een reeks afbeeldingen.

Deze voorbeeldcode laat zien hoe u alle dia's in een presentatie naar afbeeldingen converteert in C#:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Render de presentatie naar afbeeldingen dia voor dia.
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

## **Kleur‑emoji weergave**

{{% alert title="Opmerking" color="warning" %}} 
Om kleur‑emoji’s correct weer te geven bij het converteren van presentatiedia's naar afbeeldingen, moeten de emoji‑lettertypen die in de presentatie worden gebruikt geïnstalleerd en beschikbaar zijn op het systeem dat de conversie uitvoert. Bijvoorbeeld, als de presentatie **Segoe UI Emoji** gebruikt en dit lettertype ontbreekt, kunnen emoji’s in monochroom verschijnen in de gegenereerde afbeeldingen.
{{% /alert %}}

## **Veelgestelde vragen**

**Ondersteunt Aspose.Slides het weergeven van dia's met animaties?**

Nee, de `GetImage`‑methode slaat alleen een statische afbeelding van de dia op, zonder animaties.

**Kunnen verborgen dia's als afbeeldingen worden geëxporteerd?**

Ja, verborgen dia's kunnen net als normale dia's worden verwerkt. Zorg er alleen voor dat ze zijn opgenomen in de verwerkingslus.

**Kunnen afbeeldingen worden opgeslagen met schaduwen en effecten?**

Ja, Aspose.Slides ondersteunt het renderen van schaduwen, transparantie en andere grafische effecten bij het opslaan van dia's als afbeeldingen.