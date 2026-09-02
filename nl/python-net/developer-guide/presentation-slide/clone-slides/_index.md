---
title: Kloon PowerPoint-dia's in Python
linktitle: Kloon dia's
type: docs
weight: 40
url: /nl/python-net/clone-slides/
keywords:
  - kloon dia
  - kopieer dia
  - sla dia op
  - PowerPoint
  - presentatie
  - Python
  - Aspose.Slides
description: "Kloon of dupliceer snel PowerPoint-dia's met Aspose.Slides voor Python via .NET. Volg onze duidelijke codevoorbeelden en tips om PPT-creatie in enkele seconden te automatiseren, de productiviteit te verhogen en handmatig werk te elimineren."
---
## **Inleiding**

Klonen is het proces waarbij een exacte kopie of replica van iets wordt gemaakt. Aspose.Slides stelt u ook in staat om (een) dia te kopiëren (klonen) en vervolgens de gekloonde dia in de huidige presentatie of een andere geopende presentatie in te voegen. Dia‑klonen maakt een nieuwe dia aan die ontwikkelaars kunnen aanpassen zonder de originele dia te beïnvloeden. Er zijn verschillende manieren om een dia te klonen:

- Een dia klonen aan het einde van een presentatie.
- Een dia klonen op een andere positie binnen een presentatie.
- Een dia klonen aan het einde van een andere presentatie.
- Een dia klonen op een andere positie in een andere presentatie.
- Een dia klonen op een specifieke positie in een andere presentatie.

In Aspose.Slides voor Python via .NET biedt de [dia collectie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/) die door het [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) object wordt blootgesteld, de methoden `add_clone` en `insert_clone` om deze vormen van dia‑klonen uit te voeren.

## **Installatie**

```bash
pip install aspose.slides
```

## **Kloon aan het einde binnen dezelfde presentatie**

Als u een dia binnen dezelfde presentatie wilt klonen en aan het einde van de bestaande dia's wilt toevoegen, gebruik dan de `add_clone` methode. Volg deze stappen:

1. Maak een instantie van de Presentatie‑klasse.
1. Haal de dia collectie op uit het Presentatie‑object.
1. Roep de `add_clone`‑methode aan op de DiaCollectie, waarbij u de te klonen dia doorgeeft.
1. Sla de gewijzigde presentatie op.

In het voorbeeld hieronder wordt de eerste dia (index 0) gekloond en aan het einde van de presentatie toegevoegd.

```py
import aspose.slides as slides

# Instantieer de Presentation‑klasse om het presentatiebestand te vertegenwoordigen.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Kloon de gewenste dia naar het einde van de diacollectie in dezelfde presentatie.
    presentation.slides.add_clone(presentation.slides[0])
    # Sla de gewijzigde presentatie op naar schijf.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon naar een specifieke positie binnen dezelfde presentatie**

Als u een dia binnen dezelfde presentatie wilt klonen en deze op een andere positie wilt plaatsen, gebruikt u de `insert_clone`‑methode:

1. Maak een instantie van de Presentatie‑klasse.
1. Haal de dia collectie op uit het Presentatie‑object.
1. Roep de `insert_clone`‑methode aan op de DiaCollectie, waarbij u de te klonen dia en de doel‑index voor de nieuwe positie doorgeeft.
1. Sla de gewijzigde presentatie op.

In het voorbeeld hieronder wordt de dia op index 1 (positie 2) gekloond naar index 2 (positie 3) binnen dezelfde presentatie.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om het presentatiebestand te vertegenwoordigen.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Kloon de gewenste dia naar de opgegeven positie (index) binnen dezelfde presentatie.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Sla de gewijzigde presentatie op naar schijf.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon aan het einde van een andere presentatie**

Als u een dia uit één presentatie wilt klonen en aan het einde van een andere presentatie wilt toevoegen:

1. Maak een instantie van de Presentatie‑klasse voor de bronpresentatie (de presentatie die de te klonen dia bevat).
1. Maak een instantie van de Presentatie‑klasse voor de doelpresentatie (waar de dia wordt toegevoegd).
1. Haal de dia collectie op uit de doelpresentatie.
1. Roep `add_clone` aan op de doel‑DiaCollectie, waarbij u de dia uit de bronpresentatie doorgeeft.
1. Sla de gewijzigde doelpresentatie op.

In het voorbeeld hieronder wordt de dia op index 0 in de bronpresentatie gekloond naar het einde van de doelpresentatie.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om het bronpresentatie‑bestand te vertegenwoordigen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instantieer de Presentation-klasse voor de doel‑PPTX (waar de dia gekloond wordt).
    with slides.Presentation() as target_presentation:
        # Kloon de gewenste dia van de bronpresentatie naar het einde van de diacollectie in de doelpresentatie.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Sla de doelpresentatie op naar schijf.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon naar een specifieke positie in een andere presentatie**

Als u een dia uit één presentatie wilt klonen en deze in een andere presentatie op een specifieke positie wilt invoegen:

1. Maak een instantie van de Presentatie‑klasse voor de bronpresentatie (de presentatie die de te klonen dia bevat).
1. Maak een instantie van de Presentatie‑klasse voor de doelpresentatie (waar de dia wordt toegevoegd).
1. Haal de dia collectie op uit de doelpresentatie.
1. Roep de `insert_clone`‑methode aan op de doel‑DiaCollectie, waarbij u de bron‑dia en de gewenste doel‑index doorgeeft.
1. Sla de gewijzigde doelpresentatie op.

In het voorbeeld hieronder wordt de dia op index 0 in de bronpresentatie gekloond naar index 2 (positie 3) in de doelpresentatie.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om het bronpresentatie-bestand te vertegenwoordigen.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instantieer de Presentation-klasse voor de doel-PPTX (waar de dia gekloond moet worden).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Voeg een kloon van de eerste dia uit de bron toe op index 2 in de doelpresentatie.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Sla de doelpresentatie op naar schijf.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon een dia met zijn masterslide naar een andere presentatie**

Als u een dia **met zijn master** uit één presentatie wilt klonen en in een andere wilt gebruiken, kloont u eerst de benodigde masterslide van de bronpresentatie naar de doelpresentatie. Vervolgens gebruikt u die doel‑master bij het klonen van de dia. De methode `add_clone(Slide, MasterSlide)` verwacht een **master‑slide van de doelpresentatie**, niet van de bron.

Om een dia met zijn master te klonen, volgt u deze stappen:

1. Maak een instantie van de Presentatie‑klasse voor de bronpresentatie (de presentatie die de te klonen dia bevat).
1. Maak een instantie van de Presentatie‑klasse voor de doelpresentatie.
1. Toegang krijgen tot de bron‑dia die gekloond moet worden en zijn masterslide.
1. Haal de MasterSlideCollection op uit de master‑collectie van de doelpresentatie.
1. Roep `add_clone` aan op de doel‑MasterSlideCollection, waarbij u de bron‑master doorgeeft om deze in de doelpresentatie te klonen.
1. Haal de DiaCollectie op uit de dia‑collectie van de doelpresentatie.
1. Roep `add_clone` aan op de doel‑DiaCollectie, waarbij u de bron‑dia en de gekloonde doel‑master doorgeeft.
1. Sla de gewijzigde doelpresentatie op.

In het voorbeeld hieronder wordt de dia op index 0 in de bronpresentatie gekloond naar het einde van de doelpresentatie met gebruik van de master die uit de bron is gekloond.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om het bronpresentatie-bestand te vertegenwoordigen.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instantieer de Presentation-klasse voor de doelpresentatie waarin de dia gekloond zal worden.
    with slides.Presentation() as target_presentation:
        # Haal de eerste dia uit de bronpresentatie.
        source_slide = source_presentation.slides[0]
        # Haal de masterdia op die door de eerste dia wordt gebruikt.
        source_master = source_slide.layout_slide.master_slide
        # Kloon de masterdia naar de mastercollectie van de doelpresentatie.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Kloon de dia uit de bronpresentatie naar het einde van de doelpresentatie met behulp van de gekloonde master.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Sla de doelpresentatie op naar schijf.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloon aan het einde in een opgegeven sectie**

Met Aspose.Slides voor Python via .NET kunt u een dia uit een sectie van een presentatie klonen en deze in een andere sectie binnen dezelfde presentatie invoegen. Gebruik hiervoor de `add_clone(Slide, Section)`‑methode van de [DiaCollectie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/) klasse.

Het volgende Python‑voorbeeld toont hoe een dia te klonen en de kloon in een opgegeven sectie in te voegen:

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
    # Maak een sectie met de naam "Section2" die begint bij slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Kloon de eerder gemaakte dia naar de sectie "Section2".
    presentation.slides.add_clone(slide, section)
    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Zorg voor overeenkomende dia‑grootte**

Wanneer u dia's in een andere presentatie kloont, moet de doelpresentatie dezelfde dia‑grootte hebben als de bron. Als de dia‑groottes verschillen, schaalt Aspose.Slides de gekloonde vormen niet automatisch; hun oorspronkelijke coördinaten en afmetingen blijven behouden, wat kan leiden tot misaligned inhoud of elementen die buiten de dia‑grenzen vallen.

U kunt de dia‑grootte van de doelpresentatie aanpassen zodat deze overeenkomt met de bron vóór het klonen van de master en de dia:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Doe dit vóór het klonen van de master en de dia.

## **Veelgestelde vragen**

### Worden aantekeningen van spreker en recensenten gekloond?

Ja. De notitie‑pagina en recensent‑commentaren zijn opgenomen in de kloon. Als u ze niet wilt, [verwijder ze](/slides/nl/python-net/presentation-notes/) na het invoegen.

### Hoe worden grafieken en hun gegevensbronnen behandeld?

Het grafiekobject, de opmaak en de ingebedde gegevens worden gekopieerd. Als de grafiek gekoppeld is aan een externe bron (bijv. een OLE‑ingebedde werkmap), blijft die koppeling behouden als een [OLE‑object](/slides/nl/python-net/manage-ole/). Na verplaatsing tussen bestanden moet u de beschikbaarheid van de gegevens en het vernieuwingsgedrag controleren.

### Kan ik de invoegpositie en secties voor de kloon regelen?

Ja. U kunt de kloon invoegen op een specifieke dia‑index en deze in een gekozen [sectie](/slides/nl/python-net/slide-section/) plaatsen. Als de doelsectie nog niet bestaat, maakt u die eerst aan en verplaatst u daarna de dia ernaar.
