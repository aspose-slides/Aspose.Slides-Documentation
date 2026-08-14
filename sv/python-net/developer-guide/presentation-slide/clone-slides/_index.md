---
title: Klona PowerPoint-bilder i Python
linktitle: Klona bilder
type: docs
weight: 40
url: /sv/python-net/clone-slides/
keywords:
- "klona bild"
- "kopiera bild"
- "spara bild"
- "PowerPoint"
- "presentation"
- "Python"
- "Aspose.Slides"
description: "Klona eller duplicera PowerPoint-bilder snabbt med Aspose.Slides för Python via .NET. Följ våra tydliga kodexempel och tips för att automatisera skapandet av PPT på några sekunder, öka produktiviteten och eliminera manuellt arbete."
---
## **Introduktion**

Kloning är processen att göra en exakt kopia eller replik av något. Aspose.Slides låter dig även kopiera (klona) vilken bild som helst och sedan infoga den klonade bilden i den aktuella presentationen eller någon annan öppen presentation. Bildkloning skapar en ny bild som utvecklare kan modifiera utan att påverka den ursprungliga bilden. Det finns flera sätt att klona en bild:

- Klona i slutet av en presentation.
- Klona på en annan position i en presentation.
- Klona i slutet av en annan presentation.
- Klona på en annan position i en annan presentation.
- Klona på en specifik position i en annan presentation.

I Aspose.Slides för Python via .NET tillhandahåller [bildsamling](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/) som exponeras av objektet [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) metoderna `add_clone` och `insert_clone` för att utföra dessa typer av bildkloning.

## **Installation**

```bash
pip install aspose.slides
```

## **Klona i slutet i samma presentation**

Om du vill klona en bild inom samma presentation och lägga till den i slutet av de befintliga bilderna, använd metoden `add_clone`. Följ dessa steg:

1. Skapa en instans av klassen [Presentation].
2. Hämta bildsamlingen från objektet [Presentation].
3. Anropa metoden `add_clone` på [SlideCollection] och skicka med bilden som ska klonas.
4. Spara den ändrade presentationen.

I exemplet nedan klonas den första bilden (index 0) och läggs till i slutet av presentationen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att representera presentationsfilen.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Klona den önskade bilden till slutet av bildsamlingen i samma presentation.
    presentation.slides.add_clone(presentation.slides[0])
    # Spara den ändrade presentationen till disk.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona till en specifik position i samma presentation**

Om du vill klona en bild inom samma presentation och placera den på en annan position, använd metoden `insert_clone`:

1. Skapa en instans av klassen [Presentation].
2. Hämta bildsamlingen från objektet [Presentation].
3. Anropa metoden `insert_clone` på [SlideCollection] och skicka med bilden som ska klonas samt målindexet för dess nya position.
4. Spara den ändrade presentationen.

I exemplet nedan klonas bilden med index 1 (position 2) till index 2 (position 3) inom samma presentation.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att representera presentationsfilen.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Klona den önskade bilden till den specificerade positionen (index) inom samma presentation.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Spara den ändrade presentationen till disk.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona i slutet av en annan presentation**

Om du behöver klona en bild från en presentation och lägga till den i slutet av en annan presentation:

1. Skapa en instans av klassen [Presentation] för källpresentationen (den som innehåller bilden som ska klonas).
2. Skapa en instans av klassen [Presentation] för målpresentationen (där bilden kommer att läggas till).
3. Hämta bildsamlingen från målpresentationen.
4. Anropa `add_clone` på destinationens [SlideCollection] och skicka med bilden från källpresentationen.
5. Spara den ändrade målpresentationen.

I exemplet nedan klonas bilden med index 0 i källpresentationen till slutet av målpresentationen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att representera källpresentationsfilen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instansiera Presentation-klassen för mål PPTX (där bilden kommer att klonas).
    with slides.Presentation() as target_presentation:
        # Klona den önskade bilden från källpresentationen till slutet av bildsamlingen i målpresentationen.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Spara målpresentationen till disk.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona till en specifik position i en annan presentation**

Om du behöver klona en bild från en presentation och infoga den i en annan presentation på en specifik position:

1. Skapa en instans av klassen [Presentation] för källpresentationen (den som innehåller bilden som ska klonas).
2. Skapa en instans av klassen [Presentation] för målpresentationen (där bilden kommer att läggas till).
3. Hämta bildsamlingen från målpresentationen.
4. Anropa metoden `insert_clone` på destinationens [SlideCollection] och skicka med bilden från källpresentationen samt det önskade målindexet.
5. Spara den ändrade målpresentationen.

I exemplet nedan klonas bilden med index 0 i källpresentationen till index 2 (position 3) i målpresentationen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att representera källpresentationsfilen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instansiera Presentation-klassen för mål-PPTX (där bilden ska klonas).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Infoga en klon av den första bilden från källan på index 2 i målpresentationen.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Spara målpresentationen till disk.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona en bild med dess mastersida till en annan presentation**

Om du behöver klona en bild **med dess master** från en presentation och använda den i en annan, klona först den erforderliga mastersidan från källpresentationen till målpresentationen. Använd sedan den målmastern när du klonar bilden. Metoden `add_clone(Slide, MasterSlide)` förväntar sig en **mastersida från målpresentationen**, inte från källan.

För att klona en bild med dess master, följ dessa steg:

1. Skapa en instans av klassen [Presentation] för källpresentationen (den som innehåller bilden som ska klonas).
2. Skapa en instans av klassen [Presentation] för målpresentationen.
3. Åtkom källbilden som ska klonas och dess mastersida.
4. Hämta [MasterSlideCollection] från destinationens presentations mastersamling.
5. Anropa `add_clone` på destinationens [MasterSlideCollection] och skicka med källmasteren för att klona den till destinationen.
6. Hämta [SlideCollection] från destinationens bildsamling.
7. Anropa `add_clone` på destinationens [SlideCollection] och skicka med källbilden samt den klonade destinationens master.
8. Spara den ändrade målpresentationen.

I exemplet nedan klonas bilden med index 0 i källpresentationen till slutet av målpresentationen med den master som klonats från källan.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att representera källpresentationsfilen.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instansiera Presentation-klassen för målpresentationen där bilden ska klonas.
    with slides.Presentation() as target_presentation:
        # Hämta den första bilden från källpresentationen.
        source_slide = source_presentation.slides[0]
        # Hämta mastersidan som används av den första bilden.
        source_master = source_slide.layout_slide.master_slide
        # Klona mastersidan till målpresentationens mastersamling.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Klona bilden från källpresentationen till slutet av målpresentationen med den klonade mastern.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Spara målpresentationen till disk.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona i slutet i en specificerad sektion**

Med Aspose.Slides för Python via .NET kan du klona en bild från ett avsnitt i en presentation och infoga den i ett annat avsnitt i samma presentation. För att göra detta, använd metoden `add_clone(Slide, Section)` i klassen [SlideCollection].

Följande Python‑exempel visar hur man klonar en bild och infogar klonen i en specificerad sektion:

```py
import aspose.slides as slides

# Skapa en ny tom presentation.
with slides.Presentation() as presentation:
    # Lägg till en tom bild baserad på layouten för den första bilden.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Lägg till en ellipsform på den nya bilden; den här bilden kommer att klonas senare.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Lägg till ytterligare en tom bild baserad på layouten för den första bilden.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Skapa ett avsnitt med namnet "Section2" som börjar vid slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Klona den tidigare skapade bilden till avsnittet "Section2".
    presentation.slides.add_clone(slide, section)
    # Spara presentationen som en PPTX-fil.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Säkerställ matchande bildstorlek**

När du klonar bilder till en annan presentation, se till att målpresentationen har samma bildstorlek som källan. Om bildstorlekarna skiljer sig, skalar inte Aspose.Slides automatiskt de klonade formerna – deras ursprungliga koordinater och dimensioner bevaras, vilket kan leda till att innehållet blir felplacerat eller sträcker sig utanför bildens kanter.

Du kan sätta målpresentationens bildstorlek så att den matchar källan innan du klonar master och bild:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Gör detta innan du klonar mastern och bilden.

## **Vanliga frågor**

### Klonas talarnoter och granskningskommentarer?

Ja. Notssidan och granskningskommentarerna inkluderas i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/python-net/presentation-notes/) efter infogning.

### Hur hanteras diagram och deras datakällor?

Diagramobjektet, formateringen och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok) bevaras den länken som ett [OLE-objekt](/slides/sv/python-net/manage-ole/). Efter flyttning mellan filer, verifiera datatillgänglighet och uppdateringsbeteende.

### Kan jag styra infogningspositionen och sektionerna för klonen?

Ja. Du kan infoga klonen på ett specifikt bildindex och placera den i en vald [sektion](/slides/sv/python-net/slide-section/). Om målsektionen inte finns, skapa den först och flytta sedan bilden till den.