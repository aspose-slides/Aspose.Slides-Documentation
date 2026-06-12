---
title: Beheer dia‑overgangen in presentaties met Python
linktitle: Dia‑overgang
type: docs
weight: 90
url: /nl/python-net/slide-transition/
keywords:
- dia‑overgang
- dia‑overgang toevoegen
- dia‑overgang toepassen
- geavanceerde dia‑overgang
- morph‑overgang
- overgangstype
- overgangseffect
- Python
- Aspose.Slides
description: "Ontdek hoe u dia‑overgangen kunt aanpassen in Aspose.Slides voor Python via .NET, met stapsgewijze begeleiding voor PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Aspose.Slides for Python biedt volledige controle over dia‑overgangen, van het selecteren van een overgangstype tot het configureren van timing en triggers als onderdeel van geautomatiseerde presentatieworkflows. Je kunt dia’s laten doorgaan bij een klik en/of na een opgegeven vertraging, en het visuele gedrag verfijnen met effecten zoals een zwarte overgang of directionele intredingen. De bibliotheek ondersteunt ook de Morph‑overgang die in PowerPoint 2019 is geïntroduceerd, inclusief modi die morphen per object, woord of teken om een vloeiende, samenhangende beweging tussen dia’s te creëren.

## **Diaovergangen toevoegen**

Om dit makkelijker te begrijpen, laat dit voorbeeld zien hoe je Aspose.Slides for Python gebruikt om eenvoudige dia‑overgangen te beheren. Ontwikkelaars kunnen verschillende overgangseffecten op dia’s toepassen en hun gedrag aanpassen. Volg deze stappen om een eenvoudige dia‑overgang te maken:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Pas een dia‑overgang toe met een van de effecten uit de [TransitionType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitiontype/)‑enum.
1. Sla het aangepaste presentatie‑bestand op.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om een presentatiebestand te laden.
with slides.Presentation("sample.pptx") as presentation:
    # Pas een cirkelovergang toe op dia 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Pas een kamovergang toe op dia 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Sla de presentatie op naar schijf.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Geavanceerde diaovergangen toevoegen**

In dit gedeelte hebben we een eenvoudig overgangseffect op een dia toegepast. Om dat effect meer gecontroleerd en verfijnd te maken, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Pas een dia‑overgang toe met een van de effecten uit de [TransitionType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitiontype/)‑enum.
1. Configureer de overgang om **Advance On Click**, na een specifieke tijdsperiode, of beide in te stellen.
1. Sla het aangepaste presentatie‑bestand op.

Als **Advance On Click** is ingeschakeld, gaat de dia alleen vooruit wanneer de gebruiker klikt. Als de eigenschap **Advance After Time** is ingesteld, gaat de dia automatisch verder na de opgegeven interval.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om een presentatiebestand te openen.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Pas een cirkelovergang toe op dia 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Schakel doorgaan bij klikken in en stel een automatische doorgang van 3 seconden in.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Pas een kamovergang toe op dia 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Schakel doorgaan bij klikken in en stel een automatische doorgang van 5 seconden in.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Pas een zoomovergang toe op dia 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Schakel doorgaan bij klikken in en stel een automatische doorgang van 7 seconden in.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Sla de presentatie op naar schijf.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph‑overgang**

Aspose.Slides for Python ondersteunt de [Morph transition](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/morphtransition/), die de soepele beweging van de ene dia naar de andere animeert. Dit gedeelte legt uit hoe je de Morph‑overgang gebruikt. Om het effectief te gebruiken, heb je twee dia’s nodig met minstens één object gemeenschappelijk. De eenvoudigste aanpak is een dia te dupliceren en vervolgens het object op de tweede dia naar een andere positie te verplaatsen.

De volgende code‑fragment toont hoe je een dia met tekst dupliceert en een Morph‑overgang op de tweede dia toepast.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Kloon de eerste dia om een tweede dia te maken met dezelfde vormen voor Morph‑continuïteit.
    slide1 = presentation.slides.add_clone(slide0)

    # Selecteer dezelfde rechthoek op de tweede dia en wijzig de positie en grootte.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Schakel de Morph‑overgang in op de tweede dia om de vormwijzigingen soepel te animeren.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph‑overgangstypen**

De [TransitionMorphType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitionmorphtype/)‑enum vertegenwoordigt de verschillende typen Morph‑dia‑overgangen.

Het volgende code‑fragment laat zien hoe je een Morph‑overgang op een dia toepast en het morph‑type wijzigt:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Overgangseffecten instellen**

Aspose.Slides for Python stelt je in staat om overgangseffecten in te stellen zoals **From Black**, **From Left**, **From Right**, enzovoort. Volg deze stappen om een overgangseffect te configureren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar de dia.
1. Stel het gewenste overgangseffect in.
1. Sla de presentatie op als een PPTX‑bestand.

In het voorbeeld hieronder stellen we verschillende overgangseffecten in.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om een presentatiebestand te openen.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Pas een Cut‑overgang toe en schakel From Black in.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Sla de presentatie op naar schijf.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Veelgestelde vragen**

**Kan ik de afspeelsnelheid van een dia‑overgang regelen?**

Ja. Stel de [speed](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/speed/) van de overgang in via de [TransitionSpeed](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitionspeed/)‑instelling (bijv. slow/medium/fast).

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. Je kunt een geluid voor de overgang insluiten en het gedrag beheren via instellingen zoals sound‑mode en looping (bijv. [sound](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), plus metadata zoals [sound_is_built_in](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) en [sound_name](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Configureer het gewenste overgangstype in de overgangsinstellingen van elke dia; overgangen worden per dia opgeslagen, dus het toepassen van hetzelfde type op alle dia’s levert een consistent resultaat op.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Inspecteer de [transition settings](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/slide_show_transition/) van de dia en lees het [transition type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/type/); die waarde geeft precies aan welk effect is toegepast.