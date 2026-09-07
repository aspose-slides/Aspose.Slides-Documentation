---
title: Konvertera PowerPoint-presentationer till TIFF med anteckningar i Python
linktitle: PowerPoint till TIFF med anteckningar
type: docs
weight: 100
url: /sv/python-java/convert-powerpoint-to-tiff-with-notes/
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
- Python
- Java
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till TIFF med anteckningar med hjälp av Aspose.Slides för Python via Java. Lär dig hur du exporterar bilder med talaranteckningar på ett effektivt sätt."
---
## **Introduktion**

Aspose.Slides för Python via Java erbjuder en enkel lösning för att konvertera PowerPoint- och OpenDocument‑presentationer (PPT, PPTX och ODP) med anteckningar till TIFF‑formatet. Detta format används ofta för lagring av högkvalitativa bilder, utskrift och dokumentarkivering. Använd save‑metoden i Presentation‑klassen för att exportera bilder och deras talaranteckningar till en enda flersidig TIFF‑fil.

## **Konvertera en presentation till TIFF med anteckningar**

Att spara en PowerPoint‑ eller OpenDocument‑presentation till TIFF med anteckningar med Aspose.Slides för Python via Java innebär följande steg:

1. Skapa en instans av Presentation‑klassen: Ladda en PowerPoint‑ eller OpenDocument‑fil.
1. Konfigurera utdata‑layoutalternativen: Använd NotesCommentsLayoutingOptions‑klassen för att ange hur anteckningar och kommentarer ska visas.
1. Spara presentationen som TIFF: Skicka de konfigurerade alternativen till save‑metoden.

Anta att vi har en "speaker_notes.pptx"-fil med följande bild:

![Presentationsbilden med talaranteckningar](slide_with_notes.png)

Kodsnutten nedan visar hur du konverterar presentationen till en TIFF‑bild i Noter‑bild‑vyn med setSlidesLayoutOptions‑metoden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # Visa de kompletta talaranteckningarna under varje bild.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # Konfigurera TIFF-upplösning och anteckningslayouten.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # Spara presentationen som TIFF med talaranteckningar.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Resultatet:

![TIFF‑bilden med talaranteckningar](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
Kolla in Aspose Free PowerPoint to Poster Converter.
{{% /alert %}}

## **Vanliga frågor**

**Kan jag styra positionen för anteckningsområdet i den resulterande TIFF‑filen?**

Ja. Konfigurera setNotesPosition med NotesPositions.BottomTruncated för att få plats med anteckningarna på en sida, eventuellt genom att trunkera dem, eller NotesPositions.BottomFull för att visa alla anteckningar med extra sidor vid behov. För att exportera bilder utan anteckningar, utelämna konfigurationen för anteckningslayout som visas i [Konvertera PowerPoint till TIFF](/slides/sv/python-java/convert-powerpoint-to-tiff/).

**Hur kan jag minska storleken på en TIFF‑fil med anteckningar utan att förlora bildkvalitet?**

Använd förlustfri LZW‑komprimering via setCompressionType. Att minska upplösning eller färgdjup kan ytterligare minska filstorleken, men kan påverka bildkvaliteten och läsbarheten i anteckningarna. Se [TIFF‑exportinställningar](/slides/sv/python-java/convert-powerpoint-to-tiff/) för fler alternativ.

**Påverkar teckensnittet i anteckningarna resultatet om de ursprungliga teckensnitten saknas i systemet?**

Ja. Saknade teckensnitt utlöser teckensnittsbyte, vilket kan förändra textmått och utseende. Tillhandahåll de nödvändiga teckensnitten för att bevara de avsedda typsnitten.