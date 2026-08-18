---
title: Klona PowerPoint-bilder i Python
linktitle: Klona bilder
type: docs
weight: 40
url: /sv/python-net/clone-slides/
keywords:
- klona bild
- kopiera bild
- spara bild
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Klon snabbt eller duplicera PowerPoint-bilder med Aspose.Slides för Python via .NET. Följ våra tydliga kodexempel och tips för att automatisera PPT‑skapande på sekunder, öka produktiviteten och eliminera manuellt arbete."
---
## **Introduktion**

Kloning är processen att skapa en exakt kopia eller replik av något. Aspose.Slides tillåter också att du kopierar (klonar) valfri bild och sedan infogar den klonade bilden i den aktuella presentationen eller någon annan öppen presentation. Slidekloning skapar en ny bild som utvecklare kan modifiera utan att påverka den ursprungliga bilden. Det finns flera sätt att klona en bild:

- Klona i slutet av en presentation.
- Klona på en annan position inom en presentation.
- Klona i slutet av en annan presentation.
- Klona på en annan position i en annan presentation.
- Klona på en specifik position i en annan presentation.

I Aspose.Slides för Python via .NET ger den [slide collection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑objektet metoderna `add_clone` och `insert_clone` för att utföra dessa typer av slide‑kloning.

## **Installation**

```bash
pip install aspose.slides
```

## **Klona i slutet av samma presentation**

Om du vill klona en bild i samma presentation och lägga till den i slutet av de befintliga bilderna, använd metoden `add_clone`. Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta bildsamlingen från [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-objektet.
1. Anropa `add_clone` på [SlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/), och ange bilden som ska klonas.
1. Spara den modifierade presentationen.

I exemplet nedan klonas den första bilden (index 0) och läggs till i slutet av presentationen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att representera presentationsfilen.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Klona den önskade bilden till slutet av bildsamlingen i samma presentation.
    presentation.slides.add_clone(presentation.slides[0])
    # Spara den modifierade presentationen till disk.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona till en specifik position i samma presentation**

Om du vill klona en bild i samma presentation och placera den på en annan position, använd metoden `insert_clone`:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta bildsamlingen från [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-objektet.
1. Anropa `insert_clone` på [SlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/), ange den bild som ska klonas samt mål‑indexet för dess nya position.
1. Spara den modifierade presentationen.

I exemplet nedan klonas bilden på index 1 (position 2) till index 2 (position 3) inom samma presentation.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att representera presentationsfilen.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Klona den önskade bilden till den specificerade positionen (index) inom samma presentation.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Spara den modifierade presentationen till disk.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona i slutet av en annan presentation**

Om du behöver klona en bild från en presentation och lägga till den i slutet av en annan presentation:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för källpresentationen (den som innehåller bilden som ska klonas).
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för mål‑presentationen (där bilden ska läggas till).
1. Hämta bildsamlingen från mål‑presentationen.
1. Anropa `add_clone` på mål‑[SlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/), och ange bilden från källpresentationen.
1. Spara den modifierade mål‑presentationen.

I exemplet nedan klonas bilden på index 0 i källpresentationen till slutet av mål‑presentationen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att representera källpresentationens fil.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instansiera Presentation-klassen för destinations‑PPTX (där bilden kommer att klonas).
    with slides.Presentation() as target_presentation:
        # Klona den önskade bilden från källpresentationen till slutet av bildsamlingen i destinationspresentationen.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Spara destinationspresentationen till disk.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona till en specifik position i en annan presentation**

Om du behöver klona en bild från en presentation och infoga den i en annan presentation på en specifik position:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för källpresentationen (den som innehåller bilden som ska klonas).
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för mål‑presentationen (där bilden ska läggas till).
1. Hämta bildsamlingen från mål‑presentationen.
1. Anropa `insert_clone` på mål‑[SlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/), och ange bilden från källpresentationen samt det önskade mål‑indexet.
1. Spara den modifierade mål‑presentationen.

I exemplet nedan klonas bilden på index 0 i källpresentationen till index 2 (position 3) i mål‑presentationen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att representera källpresentationens fil.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instansiera Presentation-klassen för destinations-PPTX (där bilden ska klonas).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Infoga en klon av den första bilden från källan på index 2 i destinationspresentationen.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Spara destinationspresentationen till disk.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona en bild med dess masterbild till en annan presentation**

Om du behöver klona en bild **med sin master** från en presentation och använda den i en annan, klona först den erforderliga masterbilden från källpresentationen till mål‑presentationen. Använd sedan den mål‑masteren när du klonar bilden. Metoden `add_clone(Slide, MasterSlide)` förväntar sig en **masterbild från mål‑presentationen**, inte från källan.

Följ dessa steg för att klona en bild med dess master:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för källpresentationen (den som innehåller bilden som ska klonas).
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för mål‑presentationen.
1. Åtkomst den bild som ska klonas och dess masterbild.
1. Hämta [MasterSlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslidecollection/) från mål‑presentationens master‑samling.
1. Anropa `add_clone` på mål‑[MasterSlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslidecollection/), och ange käll‑masteren för att klona den till mål‑presentationen.
1. Hämta [SlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/) från mål‑presentationens bildsamling.
1. Anropa `add_clone` på mål‑[SlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/), och ange käll‑bilden samt den klonade mål‑masteren.
1. Spara den modifierade mål‑presentationen.

I exemplet nedan klonas bilden på index 0 i källpresentationen till slutet av mål‑presentationen med den master som klonats från källan.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att representera källpresentationens fil.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instansiera Presentation-klassen för destinationspresentationen där bilden kommer att klonas.
    with slides.Presentation() as target_presentation:
        # Hämta den första bilden från källpresentationen.
        source_slide = source_presentation.slides[0]
        # Hämta masterbilden som används av den första bilden.
        source_master = source_slide.layout_slide.master_slide
        # Klona masterbilden till destinationspresentationens master‑samling.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Klona bilden från källpresentationen till slutet av destinationspresentationen med den klonade masteren.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Spara destinationspresentationen till disk.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona i slutet i ett specificerat avsnitt**

Med Aspose.Slides för Python via .NET kan du klona en bild från ett avsnitt i en presentation och infoga den i ett annat avsnitt i samma presentation. Använd metoden `add_clone(Slide, Section)` i klassen [SlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/).

Följande Python‑exempel visar hur du klonar en bild och infogar klonen i ett specificerat avsnitt:

```py
import aspose.slides as slides

# Skapa en ny tom presentation.
with slides.Presentation() as presentation:
    # Lägg till en tom bild baserat på layouten för den första bilden.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Lägg till en ellipsform på den nya bilden; den här bilden kommer att klonas senare.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Lägg till ytterligare en tom bild baserat på layouten för den första bilden.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Skapa ett avsnitt med namnet "Section2" som börjar vid slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Klona den tidigare skapade bilden in i avsnittet "Section2".
    presentation.slides.add_clone(slide, section)
    # Spara presentationen som en PPTX-fil.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Säkerställ matchande bildstorlek**

När du klonar bilder till en annan presentation, se till att mål‑presentationen har samma bildstorlek som källan. Om bildstorlekarna skiljer sig, skalar inte Aspose.Slides automatiskt de klonade formerna – deras ursprungliga koordinater och dimensioner behålls, vilket kan leda till att innehållet blir feljusterat eller sträcker sig utanför bildens gränser.

Du kan sätta mål‑presentationens bildstorlek så att den matchar källans innan du klonar master‑ och bildobjekten:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Gör detta innan du klonar master‑ och bildobjekten.

## **FAQ**

**Kopieras anteckningssidor och granskningskommentarer?**

Ja. Anteckningssidan och granskningskommentarerna ingår i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/python-net/presentation-notes/) efter infogning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formatering och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok), bevaras den länken som ett [OLE‑objekt](/slides/sv/python-net/manage-ole/). Efter flytt mellan filer, verifiera datatillgänglighet och uppdateringsbeteende.

**Kan jag styra infogningspositionen och avsnitten för klonen?**

Ja. Du kan infoga klonen på ett specifikt bildindex och placera den i ett valt [avsnitt](/slides/sv/python-net/slide-section/). Om mål‑avsnittet inte finns, skapa det först och flytta sedan bilden dit.