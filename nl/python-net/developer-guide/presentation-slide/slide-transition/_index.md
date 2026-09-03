---
title: Beheer diaovergangen in presentaties met Python
linktitle: Diaovergang
type: docs
weight: 90
url: /nl/python-net/slide-transition/
keywords:
- diaovergang
- diaovergang toevoegen
- diaovergang toepassen
- geavanceerde diaovergang
- Morph-overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Pas diaovergangen toe, configureer automatische voortzetting van dia's, en pas Morph en andere overgangseffecten aan met Aspose.Slides for Python via .NET."
---
## **Overzicht**

Diaovergangen bepalen hoe dia's verschijnen tijdens een diavoorstelling. Met Aspose.Slides for Python via .NET kun je voor elke dia een overgangseffect kiezen, de voortgang instellen op muisklik of timer, en opties aanpassen die specifiek zijn voor een effect. Dit artikel gebruikt Python‑voorbeelden om overgangen toe te passen, exacte overgangsduren in te stellen, diatiming te beheren en een Morph‑overgang tussen twee dia's te maken. De voorbeelden laten ook zien hoe je de instellingen opslaat in een PPTX‑bestand.

## **Diaovergang toevoegen**

Om een overgang toe te passen, laad je een presentatie met de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse en krijg je toegang tot de eigenschap [slide_show_transition](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/slide_show_transition/) van de dia. Stel de [type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/type/) in op een waarde uit de enumeratie [TransitionType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitiontype/), sla vervolgens de presentatie op.

Het volgende voorbeeld past een Circle‑overgang toe op de eerste dia en een Comb‑overgang op de tweede. Gebruik een bestand `input.pptx` met minstens twee dia's.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Geavanceerde diaovergang toevoegen**

Je kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortzet. De volgende eigenschappen regelen dit gedrag:

- [advance_on_click](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) laat de kijker de diavoorstelling voortzetten door te klikken.
- [advance_after](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) maakt automatische voortzetting mogelijk.
- [advance_after_time](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) geeft de vertraging vóór automatische voortzetting op, in milliseconden.

Schakel zowel klik‑ als timer‑voortzetting in zodat de kijker kan doorgaan met een klik of kan wachten op de timer. Om alleen de timer te gebruiken, stel je [advance_on_click](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) in op `False`. De vertraging bepaalt wanneer de diavoorstelling doorgaat; hij stelt niet de duur van het visuele overgangseffect in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia's en schakelt automatische voortzetting in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia's ook voortzetten. Gebruik een bestand `input.pptx` met minstens drie dia's.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Om te controleren of timer‑voortzetting ingeschakeld is, lees je [advance_after](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Een opgeslagen vertraging alleen geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingeschakelde timer en schakelt automatische voortzetting uit voor dia's met een vertraging groter dan twee seconden. Het schakelt muisklikken in voor die dia's en slaat de bijgewerkte instellingen op.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Overgangstiming nauwkeurig regelen**

Gebruik [duration](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/duration/) om de exacte lengte van een overgangseffect op te geven in milliseconden. De eigenschap [slide_show_transition](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/slide_show_transition/) van de dia maakt deze instellingen beschikbaar via [SlideShowTransition](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/):

| Eigenschap | Doel |
| --- | --- |
| [duration](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [advance_after_time](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Stelt de vertraging vóór automatische voortzetting van de dia in, in milliseconden. Schakel [advance_after](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) in om deze timer te activeren. |
| [speed](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Selecteert een vooraf gedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM of FAST. Wordt gebruikt wanneer geen exacte duur is opgegeven. |

[duration](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/duration/) beïnvloedt alleen het overgangseffect; hij bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de automatische voortzettingstimer apart. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur aan de hand van het overgangstype en de [speed](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/speed/)‑waarde.

### **Zelfde duur toepassen op elke dia**

Voor een gelijk tempo kun je hetzelfde effect en dezelfde exacte duur op elke dia toepassen. Dit voorbeeld laadt `input.pptx`, kiest Fade uit [TransitionType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitiontype/), en geeft elke overgang een duur van 750 milliseconden. Het schakelt bovendien automatische voortzetting in na 5.000 milliseconden en schakelt voortzetting via muisklik uit, waarna het resultaat als PPTX wordt opgeslagen.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Stel automatische voortzetting in, onafhankelijk van de duur van het effect.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Verschillende duur per individuele dia instellen**

Verschillende dia's kunnen verschillende effectduurtijd hebben. Bijvoorbeeld, gebruik een korte overgang voor een titeldia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1.200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Overgangen afstemmen op geanimeerde output**

Wanneer je een [animated GIF](/slides/nl/python-net/convert-powerpoint-to-animated-gif/), [HTML5‑presentatie](/slides/nl/python-net/export-to-html5/) of [video](/slides/nl/python-net/convert-powerpoint-to-video/) maakt, stel dan exacte overgangsduren in vóór export zodat ze overeenstemmen met het beoogde tempo. Gebruik bijvoorbeeld een fade‑overgang van 600 milliseconden tussen scènes en pas de voortzettingstimer van elke dia apart aan om tijd te geven voor de bijbehorende commentaar of inhoud.

Voor GIF‑ en video‑output stem je de framesnelheid af op de effectduur: 600 milliseconden komen overeen met 18 frames bij 30 fps. In HTML5 schakelt je geanimeerde overgangen in via de exportinstellingen. Controleer de ondersteunde effecten en timingopties van het gekozen exportformaat en bekijk een preview om synchronisatie te bevestigen.

### **Bestaande overgangsduur uitlezen**

Lees [duration](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/duration/) uit voordat je de overgang wijzigt om te bepalen of er een expliciete waarde opgeslagen is. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden weer. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides gebruikt het overgangstype en de [speed](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/speed/) om die duur te bepalen. Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de oorspronkelijke instellingen.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Morph‑overgang**

De Morph‑overgang animeert wijzigingen tussen objecten op opeenvolgende dia's. Om een eenvoudige Morph‑animatie te maken, kloon je een dia, verplaats of wijzig je de grootte van een object op de kloon, en pas je de Morph‑overgang toe op de tweede dia. Zo krijgt de overgang de corresponderende objecten om te animeren tussen hun oorspronkelijke en gewijzigde status.

Het volgende voorbeeld maakt een dia met een tekst‑rechthoek, kloont de dia en verandert de positie en grootte van de rechthoek op de kloon. Vervolgens selecteert het Morph uit de enumeratie [TransitionType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitiontype/) voor de tweede dia. Open het opgeslagen bestand in een presentatieweergave die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph‑overgangstypen**

De enumeratie [TransitionMorphType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitionmorphtype/) bepaalt hoe Morph content koppelt en animeert:

- [BY_OBJECT](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitionmorphtype/) behandelt elke vorm als één geheel.
- [BY_WORD](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door woorden te koppelen waar mogelijk.
- [BY_CHAR](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door karakters te koppelen waar mogelijk.

Stel het overgangs[t]ype](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/type/) in op Morph voordat je de [value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/value/) benadert. De waarde levert vervolgens het [MorphTransition](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/morphtransition/)‑object, waarvan de eigenschap [morph_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/morphtransition/morph_type/) de koppelmodus selecteert.

Dit voorbeeld opent de presentatie die in de vorige sectie is gemaakt en configureert de tweede dia om woord‑gebaseerde Morph‑animatie te gebruiken.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Overgangseffecten instellen**

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van het gekozen overgangs[t]ype](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/type/). Stel eerst het type in en gebruik daarna het juiste overgangsobject via zijn [value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het stelt [from_black](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) in via [OptionalBlackTransition](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/optionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**Kan ik de afspeelsnelheid van een diaovergang regelen?**

Ja. Geef de voorkeur aan [duration](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/duration/) wanneer je een exacte effectduur in milliseconden nodig hebt. Gebruik [speed](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/speed/) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitionspeed/)‑categorie — SLOW, MEDIUM of FAST — voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de timer voor automatische voortzetting.

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. Wijs ingesloten audio toe aan [sound](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/sound/), stel [sound_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) in op START_SOUND uit de enumeratie [TransitionSoundMode](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitionsoundmode/), en schakel [sound_loop](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) in. Het geluid blijft herhalen tot het volgende geluidsevenement in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de [slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/slides/nl/)‑collectie van de presentatie en stel voor elke dia de overgangs[t]ype](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/type/) in op dezelfde waarde. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia's.

**Hoe kan ik controleren welke overgang momenteel op een dia staat?**

Lees de eigenschap [type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/slideshowtransition/type/) uit van de dia‑eigenschap [slide_show_transition](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/slide_show_transition/). Deze retourneert een waarde uit de enumeratie [TransitionType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.slideshow/transitiontype/); NONE betekent dat er geen overgangseffect is toegepast.