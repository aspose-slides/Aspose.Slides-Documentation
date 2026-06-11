---
title: Konvertera PowerPoint-presentationer till TIFF med anteckningar i C++
linktitle: PowerPoint till TIFF med anteckningar
type: docs
weight: 100
url: /sv/cpp/convert-powerpoint-to-tiff-with-notes/
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
- C++
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till TIFF med anteckningar med Aspose.Slides för C++. Lär dig hur du effektivt exporterar bilder med talaranteckningar."
---
## **Introduktion**

Aspose.Slides för C++ erbjuder en enkel lösning för att konvertera PowerPoint- och OpenDocument‑presentationer (PPT, PPTX och ODP) med anteckningar till TIFF‑formatet. Detta format används i stor utsträckning för lagring av högkvalitativa bilder, utskrift och dokumentarkivering. Med Aspose.Slides kan du inte bara exportera hela presentationer med talaranteckningar utan även generera bildminiaturer i vy för Anteckningsbild. Konverteringsprocessen är enkel och effektiv och använder `Save`‑metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) för att omvandla hela presentationen till en serie TIFF‑bilder samtidigt som anteckningarna och layouten bevaras.

## **Konvertera en presentation till TIFF med anteckningar**

Att spara en PowerPoint‑ eller OpenDocument‑presentation till TIFF med anteckningar med hjälp av Aspose.Slides för C++ innebär följande steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/): Ladda en PowerPoint‑ eller OpenDocument‑fil.
1. Konfigurera utdata‑layoutalternativen: Använd klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notescommentslayoutingoptions/) för att ange hur anteckningar och kommentarer ska visas.
1. Spara presentationen till TIFF: Skicka de konfigurerade alternativen till metoden [Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/).

Anta att vi har en "speaker_notes.pptx"-fil med följande bild:

![Presentationens bild med talaranteckningar](slide_with_notes.png)

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Visa anteckningarna under bilden.

// Konfigurera TIFF-alternativen med anteckningslayout.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Spara presentationen till TIFF med talaranteckningarna.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Resultatet:

![TIFF-bilden med talaranteckningar](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Kolla in Aspose [Gratis PowerPoint till Poster‑konverterare](https://products.aspose.app/slides/sv/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Vanliga frågor**

**Kan jag styra placeringen av anteckningsområdet i den resulterande TIFF‑filen?**

Ja. Använd [notes layout settings](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) för att välja mellan alternativ som `None`, `BottomTruncated` eller `BottomFull`, vilka respektive döljer anteckningar, anpassar dem till en enda sida eller låter dem fortsätta på ytterligare sidor.

**Hur kan jag minska storleken på en TIFF‑fil med anteckningar utan synlig kvalitetsförlust?**

Välj en [efficient compression](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (t.ex. `LZW` eller `RLE`), ange ett rimligt DPI och, om det är acceptabelt, använd ett lägre [pixel format](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (såsom 8 bpp eller 1 bpp för monokrom). Att något minska [image dimensions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/set_imagesize/) kan också hjälpa utan att märkbart försämra läsbarheten.

**Påverkar teckensnittet i anteckningarna resultatet om de ursprungliga teckensnitten saknas i systemet?**

Ja. Saknade teckensnitt utlöser [substitution](/slides/sv/cpp/font-selection-sequence/), vilket kan ändra textmått och utseende. För att undvika detta, [supply the required fonts](/slides/sv/cpp/custom-font/) eller ange ett standard‑[fallback font](/slides/sv/cpp/fallback-font/) så att de avsedda typsnitten används.