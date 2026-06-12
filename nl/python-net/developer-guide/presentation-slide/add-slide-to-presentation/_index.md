---
title: Dia's toevoegen aan presentaties met Python
linktitle: Dia toevoegen
type: docs
weight: 10
url: /nl/python-net/add-slide-to-presentation/
keywords:
- dia toevoegen
- dia maken
- lege dia
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Voeg eenvoudig dia's toe aan uw PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via .NET—naadloze, efficiënte dia-invoer in enkele seconden."
---
## **Overzicht**

Voordat u dia's aan een presentatie toevoegt, is het handig om te begrijpen hoe PowerPoint ze organiseert. Elke presentatie bevat een masterdia, optionele lay-outdia's en een of meer normale dia's. Elke dia heeft een unieke ID en normale dia's worden gesorteerd op een nulgebaseerde index. Dit artikel laat zien hoe u Aspose.Slides voor Python kunt gebruiken om dia's te maken en de juiste lay-outs te kiezen.

## **Dia's toevoegen aan presentaties**

Aspose.Slides stelt u in staat om nieuwe dia's toe te voegen op basis van bestaande lay-outdia's. Het onderstaande voorbeeld doorloopt elke lay-out in de presentatie, voegt een dia toe die die lay-out gebruikt en slaat vervolgens het bestand op.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
1. Toegang tot de [SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/).
1. Voor elk item in `presentation.layout_slides` roept u `add_empty_slide` aan om een dia toe te voegen die die lay-out gebruikt.
1. Optioneel kunt u de nieuw toegevoegde dia's aanpassen.
1. Sla de presentatie op als een PPTX‑bestand.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse.
with slides.Presentation() as presentation:
    # Toegang tot de dia-collectie.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Voeg een lege dia toe aan de dia-collectie.
        slides.add_empty_slide(layout_slide)

    # Voer wat bewerkingen uit op de nieuw toegevoegde dia's.

    # Sla de presentatie op schijf.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik een nieuwe dia op een specifieke positie invoegen, en niet alleen aan het einde?**

Ja. De bibliotheek ondersteunt dia‑collecties en de [insert](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/insert_clone/)‑bewerkingen, zodat u een dia kunt toevoegen op de benodigde index in plaats van alleen aan het einde.

**Worden de thema's/stijlen behouden bij het toevoegen van een dia op basis van een lay-out?**

Ja. Een lay-out erft de opmaak van zijn master, en de nieuwe dia erft van de geselecteerde lay-out en de bijbehorende master.

**Welke dia staat er in een nieuwe "lege" presentatie voordat er dia's worden toegevoegd?**

Een nieuw aangemaakte presentatie bevat al één lege dia met index nul. Dit is belangrijk om in acht te nemen bij het berekenen van invoegin‑indices.

**Hoe kies ik de "juiste" lay-out voor een nieuwe dia als de master veel opties heeft?**

Kies doorgaans de [LayoutSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/) die overeenkomt met de vereiste structuur ([Titel en inhoud, Twee inhoud, enz.](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidelayouttype/)). Als een dergelijke lay-out ontbreekt, kunt u deze [aan de master toevoegen](/slides/nl/python-net/slide-layout/) en vervolgens gebruiken.