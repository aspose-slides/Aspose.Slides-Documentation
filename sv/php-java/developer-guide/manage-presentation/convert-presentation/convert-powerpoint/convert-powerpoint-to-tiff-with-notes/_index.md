---
title: Konvertera PowerPoint-presentationer till TIFF med anteckningar i PHP
linktitle: PowerPoint till TIFF med anteckningar
type: docs
weight: 100
url: /sv/php-java/convert-powerpoint-to-tiff-with-notes/
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
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till TIFF med anteckningar med Aspose.Slides för PHP via Java. Lär dig hur du exporterar bilder med talaranteckningar på ett effektivt sätt."
---
## **Introduktion**

Aspose.Slides for PHP via Java erbjuder en enkel lösning för att konvertera PowerPoint- och OpenDocument-presentationer (PPT, PPTX och ODP) med anteckningar till TIFF-formatet. Detta format används ofta för lagring av högkvalitativa bilder, utskrift och dokumentarkivering. Med Aspose.Slides kan du inte bara exportera hela presentationer med talaranteckningar utan också skapa miniatyrbilder av bildspel i vyn Anteckningsbild. Konverteringsprocessen är enkel och effektiv, och använder `save`‑metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) för att omvandla hela presentationen till en serie TIFF‑bilder samtidigt som anteckningarna och layouten bevaras.

## **Konvertera en presentation till TIFF med anteckningar**

Att spara en PowerPoint‑ eller OpenDocument-presentation till TIFF med anteckningar med Aspose.Slides for PHP via Java innebär följande steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/): Ladda en PowerPoint‑ eller OpenDocument‑fil.
1. Konfigurera utdata‑layoutalternativen: Använd klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notescommentslayoutingoptions/) för att ange hur anteckningar och kommentarer ska visas.
1. Spara presentationen som TIFF: Skicka de konfigurerade alternativen till metoden [save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save).

Anta att vi har en fil "speaker_notes.pptx" med följande bild:

![Presentationens bild med talaranteckningar](slide_with_notes.png)

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // Visa anteckningarna under bilden.

    // Konfigurera TIFF-alternativen med anteckningslayout.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Spara presentationen som TIFF med talaranteckningarna.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![TIFF‑bilden med talaranteckningar](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Kolla in Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kan jag styra positionen för anteckningsområdet i den resulterande TIFF‑filen?**

Ja. Använd [notes layout settings](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) för att välja mellan alternativ som `None`, `BottomTruncated` eller `BottomFull`, som respektive döljer anteckningarna, får dem att passa på en enda sida eller låter dem flyta över till ytterligare sidor.

**Hur kan jag minska storleken på en TIFF‑fil med anteckningar utan synlig kvalitetsförlust?**

Välj en [efficient compression](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/setcompressiontype/) (t.ex. `LZW` eller `RLE`), sätt ett rimligt DPI och, om det är acceptabelt, använd ett lägre [pixel format](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/setpixelformat/) (t.ex. 8 bpp eller 1 bpp för monokrom). Att något minska [image dimensions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/setimagesize/) kan också hjälpa utan att märkbart försämra läsbarheten.

**Påverkar teckensnittet i anteckningarna resultatet om de ursprungliga teckensnitten saknas i systemet?**

Ja. Saknade teckensnitt utlöser [substitution](/slides/sv/php-java/font-selection-sequence/), vilket kan ändra textmått och utseende. För att undvika detta, [supply the required fonts](/slides/sv/php-java/custom-font/) eller ange ett standard-[fallback font](/slides/sv/php-java/fallback-font/) så att de avsedda typsnitten används.