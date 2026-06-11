---
title: Hämta hela bildbakgrunden från en presentation som en bild
linktitle: Hel bildbakgrund
type: docs
weight: 95
url: /sv/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- bild
- bakgrund
- bildbakgrund
- slutlig bakgrund
- bakgrund till bild
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Extrahera fullständiga bildbakgrunder som bilder från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET, vilket effektiviserar visuella arbetsflöden."
---
## **Översikt**

I PowerPoint‑presentationer kan en bildbakgrund bestå av flera element, inklusive bildens bakgrundsbild, presentationstema, färgschema och objekt som placerats på masterbilden eller layoutsliden.

Den här artikeln visar hur du extraherar hela bildbakgrunden som en bild med hjälp av Aspose.Slides. Eftersom det inte finns någon enkel metod för detta uppdrag, innebär tillvägagångssättet att klona den valda bilden till en tillfällig presentation, ta bort bildens former och sedan konvertera den resulterande bildbakgrunden till en bild.

## **Hämta hela bildbakgrunden**

Aspose.Slides för Python erbjuder inte en enkel metod för att extrahera hela presentationens bildbakgrund som en bild, men du kan följa stegen nedan för att göra detta:
1. Ladda presentationen med hjälp av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta bildens storlek från presentationen.
1. Välj en bild.
1. Skapa en tillfällig presentation.
1. Ställ in samma bildstorlek i den tillfälliga presentationen.
1. Klona den valda bilden till den tillfälliga presentationen.
1. Ta bort formerna från den klonade bilden.
1. Konvertera den klonade bilden till en bild.

Följande kodexempel extraherar hela presentationens bildbakgrund som en bild.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```

## **Vanliga frågor**

**Komplexa gradienter, texturer eller bildfyllningar från en masterbild bevaras i den resulterande bakgrundsbilden?**

Ja. Aspose.Slides renderar gradient‑, bild‑ och texturfyllningar som definierats på bilden, layouten eller masteren. Om du behöver isolera utseendet från ärvda mastrar, [ange en egen bakgrund](/slides/sv/python-net/presentation-background/) på den aktuella bilden innan du exporterar.

**Kan jag lägga till ett vattenstämpel i den resulterande bakgrundsbilden innan jag sparar den?**

Ja. Du kan [lägga till ett vattenstämpel](/slides/sv/python-net/watermark/) som en form eller bild på en arbetande [kopia av bilden](/slides/sv/python-net/clone-slides/) (placerad bakom annat innehåll) och sedan exportera. Detta låter dig skapa en bakgrundsbild med vattenstämpeln inbäddad.

**Kan jag hämta bakgrunden för en specifik layout eller master utan att koppla den till en befintlig bild?**

Ja. Åtkomst till önskad master eller layout, applicera den på en [tillfällig bild](/slides/sv/python-net/clone-slides/) med den erforderliga storleken och exportera den bilden för att erhålla bakgrunden hämtad från den layouten eller mastern.

**Finns det licensrestriktioner som påverkar bildexport?**

Renderingsfunktioner är fullt tillgängliga med en [giltig licens](/slides/sv/python-net/licensing/). I utvärderingsläge kan resultatet innehålla begränsningar som en vattenstämpel. Aktivera licensen en gång per process innan du kör batchexporter.