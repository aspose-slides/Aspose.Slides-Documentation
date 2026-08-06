---
title: "Kloon PowerPoint-dia's in Python"
linktitle: "Kloon dia's"
type: docs
weight: 40
url: /nl/python-net/clone-slides/
keywords:
- "kloon dia"
- "kopieer dia"
- "sla dia op"
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Kloon of dupliceer snel PowerPoint-dia's met Aspose.Slides voor Python via .NET. Volg onze duidelijke code-voorbeelden en tips om het maken van PPT's te automatiseren in enkele seconden, de productiviteit te verhogen en handmatig werk te elimineren."
---
## **Inleiding**

Klonen is het proces van het maken van een exacte kopie of replica van iets. Aspose.Slides stelt je ook in staat om (een) dia te kopiëren (klonen) en vervolgens de gekloonde dia in de huidige presentatie of een andere geopende presentatie in te voegen. Dia‑klonen maakt een nieuwe dia die ontwikkelaars kunnen wijzigen zonder de oorspronkelijke dia te beïnvloeden. Er zijn verschillende manieren om een dia te klonen:

- Kloon aan het einde van een presentatie.
- Kloon op een andere positie binnen een presentatie.
- Kloon aan het einde van een andere presentatie.
- Kloon op een andere positie in een andere presentatie.
- Kloon op een specifieke positie in een andere presentatie.

In Aspose.Slides voor Python via .NET, de [dia collectie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/) die wordt blootgesteld door het [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) object biedt de methoden `add_clone` en `insert_clone` om deze soorten dia‑klonen uit te voeren.

## **Installatie**

```bash
pip install aspose.slides
```

## **Kloon aan het einde binnen dezelfde presentatie**

Als je een dia binnen dezelfde presentatie wilt klonen en aan het einde van de bestaande dia's wilt toevoegen, gebruik dan de methode `add_clone`. Volg deze stappen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
1. Haal de dia collectie op uit het [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) object.
1. Roep de `add_clone` methode aan op de [SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/), en geef de te klonen dia door.
1. Sla de gewijzigde presentatie op.

In het onderstaande voorbeeld wordt de eerste dia (index 0) geklond en aan het einde van de presentatie toegevoegd.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om het presentatiebestand te vertegenwoordigen.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Kloon de gewenste dia naar het einde van de dia-collectie in dezelfde presentatie.
    presentation.slides.add_clone(presentation.slides[0])
    # Sla de gewijzigde presentatie op schijf.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon naar een specifieke positie binnen dezelfde presentatie**

Als je een dia binnen dezelfde presentatie wilt klonen en op een andere positie wilt plaatsen, gebruik dan de methode `insert_clone`:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
1. Haal de dia collectie op uit het [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) object.
1. Roep de `insert_clone` methode aan op de [SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/), en geef de te klonen dia en de doelindex voor de nieuwe positie door.
1. Sla de gewijzigde presentatie op.

In het onderstaande voorbeeld wordt de dia op index 1 (positie 2) geklond naar index 2 (positie 3) binnen dezelfde presentatie.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om het presentatiebestand te vertegenwoordigen.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Kloon de gewenste dia naar de opgegeven positie (index) binnen dezelfde presentatie.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Sla de gewijzigde presentatie op schijf.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon aan het einde van een andere presentatie**

Als je een dia van de ene presentatie wilt klonen en aan het einde van een andere presentatie wilt toevoegen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse voor de bronpresentatie (de presentatie die de te klonen dia bevat).
1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse voor de bestemmingspresentatie (waar de dia zal worden toegevoegd).
1. Haal de dia collectie op uit de bestemmingspresentatie.
1. Roep `add_clone` aan op de bestemmings-[SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/), en geef de dia uit de bronpresentatie door.
1. Sla de gewijzigde bestemmingspresentatie op.

In het onderstaande voorbeeld wordt de dia op index 0 in de bronpresentatie geklond naar het einde van de bestemmingspresentatie.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om het bronpresentatiebestand te vertegenwoordigen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instantieer de Presentation-klasse voor de doelfile PPTX (waar de dia wordt gekloond).
    with slides.Presentation() as target_presentation:
        # Kloon de gewenste dia van de bronpresentatie naar het einde van de dia-collectie in de doelpresentatie.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Sla de doelpresentatie op schijf.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon naar een specifieke positie in een andere presentatie**

Als je een dia van de ene presentatie wilt klonen en deze in een andere presentatie op een specifieke positie wilt invoegen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse voor de bronpresentatie (de presentatie die de te klonen dia bevat).
1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse voor de bestemmingspresentatie (waar de dia zal worden toegevoegd).
1. Haal de dia collectie op uit de bestemmingspresentatie.
1. Roep de `insert_clone` methode aan op de bestemmings-[SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/), en geef de dia uit de bronpresentatie en de gewenste doelindex door.
1. Sla de gewijzigde bestemmingspresentatie op.

In het onderstaande voorbeeld wordt de dia op index 0 in de bronpresentatie geklond naar index 2 (positie 3) in de bestemmingspresentatie.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om het bronpresentatiebestand te vertegenwoordigen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instantieer de Presentation-klasse voor de bestemmings-PPTX (waar de dia moet worden gekloond).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Voeg een kloon van de eerste dia uit de bron in op index 2 in de bestemmingspresentatie.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Sla de bestemmingspresentatie op schijf.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon een dia met zijn masterdia in een andere presentatie**

Als je een dia **met zijn master** van de ene presentatie wilt klonen en in een andere wilt gebruiken, kloon dan eerst de benodigde masterdia van de bronpresentatie naar de bestemmingspresentatie. Gebruik daarna die bestemmingsmaster bij het klonen van de dia. De methode `add_clone(Slide, MasterSlide)` verwacht een **masterdia van de bestemmingspresentatie**, niet van de bron.

Om een dia met zijn master te klonen, volg deze stappen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse voor de bronpresentatie (de presentatie die de te klonen dia bevat).
1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse voor de bestemmingspresentatie.
1. Toegang tot de te klonen bron‑dia en zijn masterdia.
1. Haal de [MasterSlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/) op uit de mastercollectie van de bestemmingspresentatie.
1. Roep `add_clone` aan op de bestemmings-[MasterSlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/), en geef de bronmaster door om deze naar de bestemming te klonen.
1. Haal de [SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/) op uit de dia collectie van de bestemmingspresentatie.
1. Roep `add_clone` aan op de bestemmings-[SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/), en geef de bron‑dia en de gekloonde bestemmingsmaster door.
1. Sla de gewijzigde bestemmingspresentatie op.

In het onderstaande voorbeeld wordt de dia op index 0 in de bronpresentatie geklond naar het einde van de bestemmingspresentatie met behulp van de master die van de bron is gekloond.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om het bronpresentatiebestand te vertegenwoordigen.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instantieer de Presentation-klasse voor de bestemmingspresentatie waar de dia gekloond zal worden.
    with slides.Presentation() as target_presentation:
        # Haal de eerste dia op uit de bronpresentatie.
        source_slide = source_presentation.slides[0]
        # Haal de masterdia op die door de eerste dia wordt gebruikt.
        source_master = source_slide.layout_slide.master_slide
        # Kloon de masterdia naar de mastercollectie van de bestemmingspresentatie.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Kloon de dia van de bronpresentatie naar het einde van de bestemmingspresentatie met gebruik van de gekloonde master.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Sla de bestemmingspresentatie op schijf.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon aan het einde in een opgegeven sectie**

Met Aspose.Slides voor Python via .NET kun je een dia uit een sectie van een presentatie klonen en invoegen in een andere sectie binnen dezelfde presentatie. Gebruik hiervoor de methode `add_clone(Slide, Section)` van de [SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/) klasse.

Het volgende Python‑voorbeeld toont hoe je een dia kunt klonen en de kloon in een opgegeven sectie kunt invoegen:

```py
import aspose.slides as slides

# Maak een nieuwe lege presentatie.
with slides.Presentation() as presentation:
    # Voeg een lege dia toe gebaseerd op de lay-out van de eerste dia.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Voeg een ellipsvorm toe aan de nieuwe dia; deze dia wordt later gekloond.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Voeg nog een lege dia toe gebaseerd op de lay-out van de eerste dia.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Maak een sectie genaamd "Section2" die start bij slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Kloon de eerder aangemaakte dia naar de sectie "Section2".
    presentation.slides.add_clone(slide, section)
    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Worden sprekeropmerkingen en beoordelingscommentaren gekloond?

Ja. De notitiepagina en beoordelingscommentaren zijn opgenomen in de kloon. Als je ze niet wilt, [verwijder ze](/slides/nl/python-net/presentation-notes/) na het invoegen.

### Hoe worden grafieken en hun gegevensbronnen behandeld?

Het grafiekobject, de opmaak en de ingesloten gegevens worden gekopieerd. Als de grafiek gekoppeld was aan een externe bron (bijv. een OLE‑ingesloten werkmap), blijft die koppeling behouden als een [OLE‑object](/slides/nl/python-net/manage-ole/). Na het verplaatsen tussen bestanden, controleer de beschikbaarheid van de gegevens en het refresh‑gedrag.

### Kan ik de invoegpositie en secties van de kloon beheersen?

Ja. Je kunt de kloon invoegen op een specifieke dia‑index en plaatsen in een gekozen [sectie](/slides/nl/python-net/slide-section/). Als de doelsectie niet bestaat, maak deze dan eerst aan en verplaats vervolgens de dia erin.