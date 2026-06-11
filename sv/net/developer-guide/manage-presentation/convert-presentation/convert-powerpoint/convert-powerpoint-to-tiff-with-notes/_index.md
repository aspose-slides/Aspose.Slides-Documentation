---
title: Konvertera PowerPoint‑presentationer till TIFF med anteckningar i .NET
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
description: "Konvertera PowerPoint‑presentationer till TIFF med anteckningar med hjälp av Aspose.Slides för .NET. Lär dig hur du effektivt exporterar bilder med talaranteckningar."
---
## **Introduktion**

Aspose.Slides för .NET erbjuder en enkel lösning för att konvertera PowerPoint‑ och OpenDocument‑presentationer (PPT, PPTX och ODP) med anteckningar till TIFF‑formatet. Detta format används ofta för lagring av högkvalitativa bilder, utskrift och dokumentarkivering. Med Aspose.Slides kan du inte bara exportera hela presentationer med talaranteckningar utan också skapa miniatyrbilder av bilder i vyn Anteckningsbild. Konverteringsprocessen är enkel och effektiv, och använder `Save`‑metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) för att omvandla hela presentationen till en serie TIFF‑bilder samtidigt som anteckningarna och layouten bevaras.

## **Konvertera en presentation till TIFF med anteckningar**

Att spara en PowerPoint‑ eller OpenDocument‑presentation till TIFF med anteckningar med hjälp av Aspose.Slides för .NET innebär följande steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/): Ladda en PowerPoint‑ eller OpenDocument‑fil.  
1. Konfigurera alternativ för utdata‑layout: Använd klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/notescommentslayoutingoptions/) för att ange hur anteckningar och kommentarer ska visas.  
1. Spara presentationen som TIFF: Skicka de konfigurerade alternativen till metoden [Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/methods/save/index).

Låt oss säga att vi har en fil "speaker_notes.pptx" med följande bild:

![Presentationsbilden med talaranteckningar](slide_with_notes.png)

Kodsnutten nedan visar hur du konverterar presentationen till en TIFF‑bild i vyn Anteckningsbild genom att använda egenskapen [SlidesLayoutOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/slideslayoutoptions/).

```c#
// Skapa en instans av Presentation‑klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Konfigurera TIFF‑alternativen med anteckningslayout.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Visa anteckningarna under bilden.
        }
    };

    // Spara presentationen som TIFF med talaranteckningarna.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Resultatet:

![TIFF‑bilden med talaranteckningar](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Ta en titt på Aspose [Gratis PowerPoint‑till‑Poster‑konverterare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Vanliga frågor**

**Kan jag kontrollera positionen för anteckningsområdet i den resulterande TIFF‑filen?**

Ja. Använd [notes layout settings](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) för att välja mellan alternativ som `None`, `BottomTruncated` eller `BottomFull`, vilka respektive döljer anteckningar, passar in dem på en enda sida eller låter dem flöda över flera sidor.

**Hur kan jag minska storleken på en TIFF‑fil med anteckningar utan synlig kvalitetsförlust?**

Välj en [efficient compression](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/compressiontype/) (t.ex. `LZW` eller `RLE`), ange en rimlig DPI och, om det är acceptabelt, använd ett lägre [pixel format](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/pixelformat/) (såsom 8 bpp eller 1 bpp för monokrom). Att något minska [image dimensions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/imagesize/) kan också hjälpa utan att märkbart försämra läsbarheten.

**Påverkar teckensnittet i anteckningarna resultatet om de ursprungliga teckensnitten saknas i systemet?**

Ja. Saknade teckensnitt utlöser [substitution](/slides/sv/net/font-selection-sequence/), vilket kan ändra textmått och utseende. För att undvika detta, [tillhandahåll de nödvändiga teckensnitten](/slides/sv/net/custom-font/) eller ange ett standard-[fallback font](/slides/sv/net/fallback-font/) så att de avsedda typsnitten används.