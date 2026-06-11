---
title: Konvertera PowerPoint-presentationer till TIFF med anteckningar i Python
linktitle: PowerPoint till TIFF med anteckningar
type: docs
weight: 100
url: /sv/python-net/convert-powerpoint-to-tiff-with-notes/
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
- PowerPoint med anteckningar
- presentation med anteckningar
- bild med anteckningar
- PPT med anteckningar
- PPTX med anteckningar
- TIFF med anteckningar
- Python
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till TIFF med anteckningar med Aspose.Slides för Python via .NET. Lär dig hur du effektivt exporterar bilder med talaranteckningar."
---
## **Introduktion**

Aspose.Slides för Python via .NET erbjuder en enkel lösning för att konvertera PowerPoint‑ och OpenDocument‑presentationer (PPT, PPTX och ODP) med anteckningar till TIFF‑format. Detta format används ofta för högkvalitativ bildlagring, utskrift och dokumentarkivering. Med Aspose.Slides kan du inte bara exportera hela presentationer med talaranteckningar utan också generera bildminiatyrer i Bild med anteckningar‑vyn. Konverteringsprocessen är enkel och effektiv och använder `save`‑metoden i [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑klassen för att omvandla hela presentationen till en serie TIFF‑bilder samtidigt som anteckningarna och layouten bevaras.

## **Konvertera en presentation till TIFF med anteckningar**

Att spara en PowerPoint‑ eller OpenDocument‑presentation till TIFF med anteckningar med Aspose.Slides för Python via .NET innebär följande steg:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑klassen: Ladda en PowerPoint‑ eller OpenDocument‑fil.  
2. Konfigurera alternativ för utdata‑layout: Använd [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notescommentslayoutingoptions/)‑klassen för att ange hur anteckningar och kommentarer ska visas.  
3. Spara presentationen till TIFF: Skicka de konfigurerade alternativen till [save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions)‑metoden.

Låt oss säga att vi har en fil med namnet "speaker_notes.pptx" med följande bild:

![Presentationsbilden med talaranteckningar](slide_with_notes.png)

Kodsnutten nedan visar hur du konverterar presentationen till en TIFF‑bild i Bild med anteckningar‑vyn med hjälp av egenskapen [slides_layout_options](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/slides_layout_options/).

```py
# Skapa en instans av Presentation‑klassen som representerar en presentationsfil.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # Visa anteckningarna under bilden.
    
    # Konfigurera TIFF‑alternativen med anteckningslayout.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # Spara presentationen till TIFF med talaranteckningarna.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Resultatet:

![TIFF-bilden med talaranteckningar](TIFF_with_notes.png)

{{% alert title="Tips" color="primary" %}}
Kolla in Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Vanliga frågor**

**Kan jag styra positionen för anteckningsområdet i den resulterande TIFF‑filen?**

Ja. Använd [notes layout settings](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) för att välja mellan alternativ som `NONE`, `BOTTOM_TRUNCATED` eller `BOTTOM_FULL`, som respektive döljer anteckningarna, passar dem på en enda sida eller låter dem flöda över flera sidor.

**Hur kan jag minska storleken på en TIFF‑fil med anteckningar utan synlig kvalitetstapp?**

Välj en [efficient komprimering](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/compression_type/) (t.ex. `LZW` eller `RLE`), ange en rimlig DPI och, om det är acceptabelt, använd ett lägre [pixel format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/pixel_format/) (såsom 8 bpp eller 1 bpp för monokrom). Att något minska [image dimensions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/tiffoptions/image_size/) kan också hjälpa utan att märkbart försämra läsbarheten.

**Påverkar teckensnittet i anteckningarna resultatet om de ursprungliga teckensnitten saknas på systemet?**

Ja. Saknade teckensnitt utlöser [substitution](/slides/sv/python-net/font-selection-sequence/), vilket kan förändra textmått och utseende. För att undvika detta, [tillhandahåll de nödvändiga teckensnitten](/slides/sv/python-net/custom-font/) eller ange ett standard‑[fallback font](/slides/sv/python-net/fallback-font/) så att de avsedda teckensnitten används.