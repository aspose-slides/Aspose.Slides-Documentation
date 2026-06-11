---
title: Konvertera PowerPoint-presentationer till TIFF med anteckningar i JavaScript
linktitle: PowerPoint till TIFF med anteckningar
type: docs
weight: 100
url: /sv/nodejs-java/convert-powerpoint-to-tiff-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till TIFF med anteckningar i JavaScript med hjälp av Aspose.Slides för Node.js. Lär dig hur du exporterar bilder med talarnoter på ett effektivt sätt."
---
## **Introduktion**

Aspose.Slides för Node.js via Java erbjuder en enkel lösning för att konvertera PowerPoint- och OpenDocument-presentationer (PPT, PPTX och ODP) med anteckningar till TIFF-formatet. Detta format används ofta för högkvalitativ bildlagring, utskrift och dokumentarkivering. Med Aspose.Slides kan du inte bara exportera hela presentationer med talarnoter utan även skapa miniatyrbilder av bilder i vyn Noter Bild. Konverteringsprocessen är enkel och effektiv, och använder `save`-metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) för att omvandla hela presentationen till en serie TIFF-bilder samtidigt som anteckningarna och layouten bevaras.

## **Konvertera en presentation till TIFF med anteckningar**

Att spara en PowerPoint- eller OpenDocument-presentation till TIFF med anteckningar med Aspose.Slides för Node.js via Java innebär följande steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/): Ladda en PowerPoint- eller OpenDocument-fil.
1. Konfigurera utdata‑layoutalternativen: Använd klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notescommentslayoutingoptions/) för att specificera hur anteckningar och kommentarer ska visas.
1. Spara presentationen som TIFF: Skicka de konfigurerade alternativen till metoden [save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save).

Anta att vi har en fil "speaker_notes.pptx" med följande bild:

![Presentationens bild med talarnoter](slide_with_notes.png)

Kodsnutten nedan demonstrerar hur man konverterar presentationen till en TIFF-bild i vyn Noter Bild med hjälp av metoden [setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```js
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // Visa anteckningarna under bilden.

    // Konfigurera TIFF-alternativen med anteckningslayout.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Spara presentationen som TIFF med talarnoterna.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Resultatet:

![TIFF-bilden med talarnoter](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Kolla in Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kan jag kontrollera positionen för anteckningsområdet i den resulterande TIFF-filen?**

Ja. Använd [notes layout settings](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) för att välja mellan alternativ som `None`, `BottomTruncated` eller `BottomFull`, som respektive döljer anteckningarna, anpassar dem till en enda sida eller låter dem fortsätta på ytterligare sidor.

**Hur kan jag minska storleken på en TIFF‑fil med anteckningar utan synlig kvalitetspåverkan?**

Välj en [efficient compression](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (t.ex. `LZW` eller `RLE`), ange ett rimligt DPI och, om det är acceptabelt, använd ett lägre [pixel format](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) (såsom 8 bpp eller 1 bpp för monokrom). Att minska [image dimensions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/setimagesize/) något kan också hjälpa utan att märkbart försämra läsbarheten.

**Påverkar typsnittet i anteckningarna resultatet om de ursprungliga typsnitten saknas i systemet?**

Ja. Saknade typsnitt utlöser [substitution](/slides/sv/nodejs-java/font-selection-sequence/), vilket kan förändra textmått och utseende. För att undvika detta, [supply the required fonts](/slides/sv/nodejs-java/custom-font/) eller ange ett standard-[fallback font](/slides/sv/nodejs-java/fallback-font/) så att de avsedda teckensnitten används.