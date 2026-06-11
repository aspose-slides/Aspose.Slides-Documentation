---
title: Konvertera PowerPoint-presentationer till TIFF med anteckningar på Android
linktitle: PowerPoint till TIFF med anteckningar
type: docs
weight: 100
url: /sv/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till TIFF med anteckningar med Aspose.Slides för Android via Java. Lär dig hur du exporterar bilder med talarnoteringar på ett effektivt sätt."
---
## **Introduktion**

Aspose.Slides for Android via Java erbjuder en enkel lösning för att konvertera PowerPoint‑ och OpenDocument‑presentationer (PPT, PPTX och ODP) med anteckningar till TIFF‑format. Detta format används ofta för högkvalitativ bildlagring, utskrift och dokumentarkivering. Med Aspose.Slides kan du inte bara exportera hela presentationer med talarnoteringar utan även skapa bildminiatyrer i vyet Noter‑bild. Konverteringsprocessen är enkel och effektiv och använder `save`‑metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) för att omvandla hela presentationen till en serie TIFF‑bilder samtidigt som anteckningarna och layouten bevaras.

## **Konvertera en presentation till TIFF med anteckningar**

Att spara en PowerPoint‑ eller OpenDocument‑presentation till TIFF med anteckningar med Aspose.Slides for Android via Java innebär följande steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/): Läs in en PowerPoint‑ eller OpenDocument‑fil.  
1. Konfigurera alternativ för utdatalayout: Använd klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/notescommentslayoutingoptions/) för att ange hur anteckningar och kommentarer ska visas.  
1. Spara presentationen som TIFF: Skicka de konfigurerade alternativen till metoden [save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

Låt oss säga att vi har en fil **speaker_notes.pptx** med följande bild:

![Presentationens bild med talarnoteringar](slide_with_notes.png)

Kodsnutten nedan visar hur man konverterar presentationen till en TIFF‑bild i vyet Noter‑bild med metoden [setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-).

```java
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Visa anteckningarna under bilden.

    // Konfigurera TIFF-alternativen med anteckningslayout.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Spara presentationen som TIFF med talarnoteringarna.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Resultatet:

![TIFF‑bilden med talarnoteringar](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Kolla in Aspose [Gratis PowerPoint till Poster‑konverterare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kan jag styra positionen för anteckningsområdet i den resulterande TIFF‑filen?**

Ja. Använd [notes layout settings](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) för att välja mellan alternativ som `None`, `BottomTruncated` eller `BottomFull`, som respektive döljer anteckningar, placerar dem på en enda sida eller låter dem fortsätta på ytterligare sidor.

**Hur kan jag minska storleken på en TIFF‑fil med anteckningar utan synbar kvalitetsförlust?**

Välj en [efficient compression](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (t.ex. `LZW` eller `RLE`), ange ett rimligt DPI‑värde och, om det är acceptabelt, använd ett lägre [pixel format](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (såsom 8 bpp eller 1 bpp för monokrom). Att något minska [image dimensions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) kan också hjälpa utan att märkbart försämra läsbarheten.

**Påverkar teckensnittet i anteckningarna resultatet om de ursprungliga teckensnitten saknas i systemet?**

Ja. Saknade teckensnitt utlöser [substitution](/slides/sv/androidjava/font-selection-sequence/), vilket kan ändra textmått och utseende. För att undvika detta, [tillhandahåll de erforderliga teckensnitten](/slides/sv/androidjava/custom-font/) eller ange ett standard‑[fallback font](/slides/sv/androidjava/fallback-font/) så att avsedda typsnitt används.