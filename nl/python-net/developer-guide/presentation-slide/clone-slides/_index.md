---
title: "Kloon PowerPoint-dia's in Python"
linktitle: "Kloon dia's"
type: docs
weight: 40
url: /nl/python-net/clone-slides/
keywords:
- "dia klonen"
- "dia kopiëren"
- "dia opslaan"
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Kloon of dupliceer snel PowerPoint-dia's met Aspose.Slides voor Python via .NET. Volg onze duidelijke codevoorbeelden en tips om in enkele seconden PPT‑creatie te automatiseren, de productiviteit te verhogen en handmatig werk te elimineren."
---
## **Inleiding**

Klonen is het proces waarbij een exacte kopie of replica van iets wordt gemaakt. Aspose.Slides stelt u ook in staat om (een) dia te kopiëren (klonen) en vervolgens de gekloonde dia in de huidige presentatie of een andere geopende presentatie in te voegen. Het klonen van dia's creëert een nieuwe dia die ontwikkelaars kunnen aanpassen zonder de oorspronkelijke dia te beïnvloeden. Er zijn verschillende manieren om een dia te klonen:

- Kloon aan het einde van een presentatie.
- Kloon op een andere positie binnen een presentatie.
- Kloon aan het einde van een andere presentatie.
- Kloon op een andere positie in een andere presentatie.
- Kloon op een specifieke positie in een andere presentatie.

In Aspose.Slides for Python via .NET biedt de [dia collectie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/) die door het [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) object wordt blootgesteld de methoden `add_clone` en `insert_clone` om deze soorten dia‑klonen uit te voeren.

## **Kloon aan het einde binnen dezelfde presentatie**

Als u een dia binnen dezelfde presentatie wilt klonen en aan het einde van de bestaande dia's wilt toevoegen, gebruikt u de `add_clone`‑methode. Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
1. Haal de dia collectie op van het [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) object.
1. Roep de `add_clone`‑methode aan op de [SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/), waarbij u de te klonen dia opgeeft.
1. Sla de gewijzigde presentatie op.

In het onderstaande voorbeeld wordt de eerste dia (index 0) gekloond en aan het einde van de presentatie toegevoegd.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse om het presentatiebestand te vertegenwoordigen.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Kloon de gewenste dia naar het einde van de dia-collectie in dezelfde presentatie.
    presentation.slides.add_clone(presentation.slides[0])
    # Sla de gewijzigde presentatie op schijf.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon naar een specifieke positie binnen dezelfde presentatie**

Als u een dia binnen dezelfde presentatie wilt klonen en op een andere positie wilt plaatsen, gebruikt u de `insert_clone`‑methode:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
1. Haal de dia collectie op van het [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) object.
1. Roep de `insert_clone`‑methode aan op de [SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/), waarbij u de te klonen dia en de doel‑index voor de nieuwe positie opgeeft.
1. Sla de gewijzigde presentatie op.

In het onderstaande voorbeeld wordt de dia op index 0 (positie 1) gekloond naar index 1 (positie 2) binnen dezelfde presentatie.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse om het presentatiebestand te vertegenwoordigen.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Kloon de gewenste dia naar de opgegeven positie (index) binnen dezelfde presentatie.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Sla de gewijzigde presentatie op schijf.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon aan het einde van een andere presentatie**

Als u een dia van de ene presentatie moet klonen en deze aan het einde van een andere presentatie wilt toevoegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse voor de bronpresentatie (de presentatie die de te klonen dia bevat).
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse voor de bestemmingspresentatie (waar de dia wordt toegevoegd).
1. Haal de dia collectie op van de bestemmingspresentatie.
1. Roep `add_clone` aan op de bestemmings-[SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/), waarbij u de dia uit de bronpresentatie opgeeft.
1. Sla de gewijzigde bestemmingspresentatie op.

In het onderstaande voorbeeld wordt de dia op index 0 in de bronpresentatie gekloond naar het einde van de bestemmingspresentatie.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse om het bronpresentatiebestand te vertegenwoordigen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Maak een instantie van de Presentation-klasse voor de doel‑PPTX (waar de dia wordt gekloond).
    with slides.Presentation() as target_presentation:
        # Kloon de gewenste dia van de bronpresentatie naar het einde van de dia‑collectie in de doelpresentatie.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Sla de doelpresentatie op schijf.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon naar een specifieke positie in een andere presentatie**

Als u een dia van de ene presentatie moet klonen en deze op een specifieke positie in een andere presentatie wilt invoegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse voor de bronpresentatie (de presentatie die de te klonen dia bevat).
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse voor de bestemmingspresentatie (waar de dia wordt toegevoegd).
1. Haal de dia collectie op van de bestemmingspresentatie.
1. Roep de `insert_clone`‑methode aan op de bestemmings-[SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/), waarbij u de dia uit de bronpresentatie en de gewenste doel‑index opgeeft.
1. Sla de gewijzigde bestemmingspresentatie op.

In het onderstaande voorbeeld wordt de dia op index 0 in de bronpresentatie gekloond naar index 1 (positie 2) in de bestemmingspresentatie.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse om het bronpresentatiebestand te vertegenwoordigen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Maak een instantie van de Presentation-klasse voor de doel‑PPTX (waar de dia moet worden gekloond).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Voeg een kloon van de eerste dia uit de bron in op index 2 in de doelpresentatie.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Sla de doelpresentatie op schijf.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon een dia met zijn master‑dia naar een andere presentatie**

Als u een dia **met zijn master** van de ene presentatie wilt klonen en in een andere wilt gebruiken, kloont u eerst de benodigde master‑dia van de bronpresentatie naar de bestemmingspresentatie. Gebruik vervolgens die bestemmingsmaster bij het klonen van de dia. De methode `add_clone(Slide, MasterSlide)` verwacht een **master‑dia van de bestemmingspresentatie**, niet van de bron.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse voor de bronpresentatie (de presentatie die de te klonen dia bevat).
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse voor de bestemmingspresentatie.
1. Toegang tot de bron‑dia die gekloond moet worden en zijn master‑dia.
1. Haal de [MasterSlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/) op uit de master‑collectie van de bestemmingspresentatie.
1. Roep `add_clone` aan op de bestemmings-[MasterSlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslidecollection/), waarbij u de bron‑master opgeeft om deze naar de bestemming te klonen.
1. Haal de [SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/) op uit de dia‑collectie van de bestemmingspresentatie.
1. Roep `add_clone` aan op de bestemmings-[SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/), waarbij u de bron‑dia en de gekloonde bestemmings‑master opgeeft.
1. Sla de gewijzigde bestemmingspresentatie op.

In het onderstaande voorbeeld wordt de dia op index 0 in de bronpresentatie gekloond naar het einde van de bestemmingspresentatie met gebruik van de van de bron gekloonde master‑dia.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse om het bronpresentatiebestand te vertegenwoordigen.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Maak een instantie van de Presentation-klasse voor de doelpresentatie waar de dia zal worden gekloond.
    with slides.Presentation() as target_presentation:
        # Haal de eerste dia op uit de bronpresentatie.
        source_slide = source_presentation.slides[0]
        # Haal de master‑dia op die door de eerste dia wordt gebruikt.
        source_master = source_slide.layout_slide.master_slide
        # Kloon de master‑dia naar de master‑collectie van de doelpresentatie.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Kloon de dia uit de bronpresentatie naar het einde van de doelpresentatie met gebruik van de gekloonde master.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Sla de doelpresentatie op schijf.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon aan het einde in een opgegeven sectie**

Met Aspose.Slides for Python via .NET kunt u een dia uit één sectie van een presentatie klonen en deze in een andere sectie binnen dezelfde presentatie invoegen. Gebruik hiervoor de `add_clone(Slide, Section)`‑methode van de [SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/) klasse.

Het volgende Python‑voorbeeld laat zien hoe u een dia kloont en de kloon in een opgegeven sectie invoegt:

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
    # Kloon de eerder aangemaakte dia naar de "Section2" sectie.
    presentation.slides.add_clone(slide, section)
    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Worden spreker‑notities en beoordelingscommentaren gekloond?**

Ja. De notitiepagina en beoordelingscommentaren zijn opgenomen in de kloon. Als u ze niet wilt, [verwijder ze](/slides/nl/python-net/presentation-notes/) na het invoegen.

**Hoe worden grafieken en hun gegevensbronnen beheerd?**

Het grafiekobject, de opmaak en de ingesloten gegevens worden gekopieerd. Als de grafiek was gekoppeld aan een externe bron (bijv. een OLE‑ingesloten werkmap), wordt die koppeling bewaard als een [OLE‑object](/slides/nl/python-net/manage-ole/). Na het verplaatsen tussen bestanden, controleer de beschikbaarheid van de gegevens en het vernieuwingsgedrag.

**Kan ik de invoegpositie en secties voor de kloon aanpassen?**

Ja. U kunt de kloon invoegen op een specifieke dia‑index en deze plaatsen in een gekozen [sectie](/slides/nl/python-net/slide-section/). Als de doelsectie niet bestaat, maakt u deze eerst aan en verplaatst u vervolgens de dia erin.