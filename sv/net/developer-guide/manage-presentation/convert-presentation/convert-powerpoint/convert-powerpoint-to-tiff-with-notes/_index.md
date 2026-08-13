---
title: Konvertera PowerPoint-presentationer till TIFF med anteckningar i .NET
linktitle: PowerPoint till TIFF med anteckningar
type: docs
weight: 100
url: /sv/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till TIFF
- presentation till TIFF
- bild till TIFF
- PPT till TIFF
- PPTX till TIFF
- spara PPT som TIFF
- spara PPTX som TIFF
- exportera PPT till TIFF
- exportera PPTX till TIFF
- PowerPoint med anteckningar
- presentation med anteckningar
- bild med anteckningar
- PPT med anteckningar
- PPTX med anteckningar
- TIFF med anteckningar
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till TIFF med anteckningar med Aspose.Slides för .NET. Lär dig hur du exporterar bilder med talarnoter på ett effektivt sätt."
---
## **Introduktion**

Aspose.Slides för .NET tillhandahåller en enkel lösning för att konvertera PowerPoint- och OpenDocument-presentationer (PPT, PPTX och ODP) med anteckningar till TIFF-formatet. Detta format används ofta för lagring av högkvalitativa bilder, utskrift och dokumentarkivering. Med Aspose.Slides kan du inte bara exportera hela presentationer med talarnoter utan även generera bildminiatyrer i vyn Anteckningsbild. Konverteringsprocessen är enkel och effektiv och använder `Save`‑metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) för att omvandla hela presentationen till en serie TIFF‑bilder samtidigt som anteckningarna och layouten bevaras.

## **Konvertera en presentation till TIFF med anteckningar**

Att spara en PowerPoint- eller OpenDocument-presentation till TIFF med anteckningar med hjälp av Aspose.Slides för .NET innebär följande steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/): Ladda en PowerPoint- eller OpenDocument-fil.
2. Konfigurera alternativ för utmatningslayout: Använd klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/notescommentslayoutingoptions/) för att ange hur anteckningar och kommentarer ska visas.
3. Spara presentationen som TIFF: Skicka de konfigurerade alternativen till metoden [Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/methods/save/index).

Anta att vi har en fil "speaker_notes.pptx" med följande bild:

![Presentationsbilden med talarnoter](slide_with_notes.png)

Kodsnutten nedan demonstrerar hur man konverterar presentationen till en TIFF‑bild i vyn Notesslides med hjälp av egenskapen [SlidesLayoutOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/slideslayoutoptions/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Konfigurera TIFF-alternativen med anteckningslayout.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Visa anteckningarna under bilden.
        }
    };

    // Spara presentationen som TIFF med talarnoterna.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Resultatet:

![TIFF‑bilden med talarnoter](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Kolla in Aspose [Gratis PowerPoint‑till‑Poster‑konverterare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Vanliga frågor**

### Kan jag styra positionen för anteckningsområdet i den resulterande TIFF‑filen?

Ja. Använd [notes layout settings](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) för att välja mellan alternativ som `None`, `BottomTruncated` eller `BottomFull`, vilka respektive döljer anteckningar, placerar dem på en enda sida eller låter dem flöda över flera sidor.

### Hur kan jag minska storleken på en TIFF‑fil med anteckningar utan synlig kvalitetsförlust?

Välj en [efficient compression](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/compressiontype/) (t.ex. `LZW` eller `RLE`), ange ett rimligt DPI‑värde och, om det är acceptabelt, använd ett lägre [pixel format](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/pixelformat/) (t.ex. 8 bpp eller 1 bpp för monokrom). Att något minska [image dimensions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/imagesize/) kan också hjälpa utan att märkbart försämra läsbarheten.

### Påverkar teckensnittet i anteckningarna resultatet om de ursprungliga teckensnitten saknas i systemet?

Ja. Saknade teckensnitt utlöser [substitution](/slides/sv/net/font-selection-sequence/), vilket kan förändra textrutor och utseende. För att undvika detta, [supply the required fonts](/slides/sv/net/custom-font/) eller ange ett standard‑[fallback font](/slides/sv/net/fallback-font/) så att de avsedda teckensnitten används.