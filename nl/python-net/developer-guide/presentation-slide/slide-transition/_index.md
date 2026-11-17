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
- morph-overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Pas diaovergangen toe, configureer automatische voortzetting van dia's en pas Morph en andere overgangseffecten aan met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Diaovergangen bepalen hoe dia's verschijnen tijdens een diavoorstelling. Met Aspose.Slides voor Python via .NET kunt u een overgangseffect kiezen voor elke dia, de voortgang configureren via muisklik of timer, en opties aanpassen die specifiek zijn voor een effect. Dit artikel gebruikt Python‑voorbeelden om overgangen toe te passen, exacte overgangsduur in te stellen, de timing van dia's te beheren en een Morph‑overgang te maken tussen twee dia's. De voorbeelden laten ook zien hoe u de instellingen opslaat in een PPTX‑bestand.

## **Diaovergang toevoegen**

Om een overgang toe te passen, laadt u een presentatie met de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse en krijgt u de eigenschap [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) van de dia. Stel de [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) in op een waarde uit de enumeratie [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), en sla vervolgens de presentatie op.

Het volgende voorbeeld past een Circle‑overgang toe op de eerste dia en een Comb‑overgang op de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

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

## **Wiel‑overgang**

De [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) eigenschap van [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) regelt het aantal radiale sectoren dat de doel‑dia onthult. Stel de overgang [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) van de dia in op WHEEL vanuit [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) voordat u de [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) benadert als [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

Dit voorbeeld maakt twee identieke paren dia's: een zwarte dia, gevolgd door een dia met een gouden rechthoek. De doel‑dia's gebruiken een aantal spaken van 1 en 8, met dezelfde [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) en een expliciete [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) van 8.000 milliseconden om het verschil duidelijk waar te nemen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Open de uitvoerpresentatie in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2, daarna van dia 3 naar dia 4. In PowerPoint wordt bij een spaken‑aantal van 1 de dia onthuld met één klokwijzerbeweging; bij een spaken‑aantal van 8 gebeurt dit gelijktijdig via acht radiale sectoren. De inhoud en de timing van de overgang zijn identiek, dus het verschil zit in het aantal onthullingssectoren.

## **Geavanceerde diaovergang toevoegen**

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) laat de kijker toe de diavoorstelling te voortzetten door op de muis te klikken.  
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) schakelt automatische voortzetting in.  
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) geeft de vertraging vóór automatische voortzetting op, in milliseconden.

Schakel zowel klik‑ als timer‑voortzetting in zodat de kijker kan doorgaan met een klik of kan wachten op de timer. Om alleen de timer te gebruiken, stelt u [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) in op `False`. De vertraging bepaalt wanneer de diavoorstelling wordt voortgezet; ze stelt niet de duur van het visuele overgangseffect in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia's en schakelt automatische voortzetting in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia's ook voortzetten. Gebruik een `input.pptx`‑bestand met minstens drie dia's.

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

Om te controleren of de timer‑voortzetting is ingeschakeld, leest u [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Een opgeslagen vertraging op zichzelf geeft niet aan dat de timer actief is.

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

## **Transitietiming nauwkeurig regelen**

Gebruik [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) om de exacte lengte van een overgangseffect in milliseconden op te geven. De eigenschap [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) van de dia maakt deze instellingen beschikbaar via [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Eigenschap | Doel |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Stelt de vertraging vóór het automatische voortzetten van de dia in, in milliseconden. Schakel [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) in om deze timer te activeren. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Selecteert een voorgedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM of FAST. Deze wordt gebruikt wanneer geen exacte duur is opgegeven. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) regelt alleen het overgangseffect; hij bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de timer‑vertraging afzonderlijk. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur op basis van het overgangstype en de [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)-waarde.

<!-- visual-explanation:slide-transition:start -->
[![Aparte balken identificeren de overgangsduur van 750 ms en de automatische voortzettingsinstelling van 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Het gedeelde voorbeeld geeft elke dia een Fade‑overgang van 750 ms en schakelt apart automatische voortzetting in op 5 000 ms. De duur van de overgang bepaalt het effect; de voortzetting bepaalt wanneer de dia wordt verlaten. Deze balken zijn schematische instellingen, geen gemeten gecombineerde tijdlijn.*
<!-- visual-explanation:slide-transition:end -->

### **Zelfde duur toepassen op elke dia**

Voor een consistente pacing past u hetzelfde effect en dezelfde exacte duur toe op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), en geeft elke overgang een duur van 750 milliseconden. Het schakelt apart automatische voortzetting in na 5 000 milliseconden en schakelt voortzetting via muisklik uit, waarna het resultaat als PPTX wordt opgeslagen.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Configureer de automatische voortzetting onafhankelijk van de duur van het effect.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Verschillende duur instellen voor individuele dia's**

Verschillende dia's kunnen verschillende effectduren gebruiken. Gebruik bijvoorbeeld een korte overgang voor een titel-dia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1 200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

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

### **Overgangen coördineren met geanimeerde output**

Wanneer u een [animated GIF](/slides/nl/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/nl/python-net/export-to-html5/) of [video](/slides/nl/python-net/convert-powerpoint-to-video/) voorbereidt, stelt u exacte overgangsduren in vóór export zodat ze overeenkomen met het gewenste tempo. Gebruik bijvoorbeeld een fade van 600 ms tussen scènes en pas elke dia‑vervolgingstijd apart aan om tijd te geven aan de voice‑over of inhoud.

Voor GIF en video moet de uitvoer‑frame‑rate op de effectduur worden afgestemd: 600 ms komt overeen met 18 frames bij 30 fps. In HTML5 schakelt u geanimeerde overgangen in de exportinstellingen in. Controleer de ondersteunde effecten en timingopties van het gekozen exportformaat en bekijk een voorbeeld van de output om de synchronisatie te bevestigen.

### **Bestaande overgangsduur lezen**

Lees [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) voordat u de overgang wijzigt om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden aan. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides bepaalt de effectduur op basis van het overgangstype en de [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)-waarde. Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de oorspronkelijke instellingen.

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

De Morph‑overgang animeert wijzigingen tussen objecten op opeenvolgende dia's. Om een eenvoudige Morph‑effect te creëren, dupliceert u een dia, verplaatst of schaalt u een object op de duplicaat, en past u de Morph‑overgang toe op de tweede dia. Dit geeft de overgang de bijbehorende objecten om te animeren tussen hun oorspronkelijke en gewijzigde status.

Het volgende voorbeeld maakt een dia met een tekst‑rechthoek, dupliceert de dia en wijzigt de positie en grootte van de rechthoek op de duplicaat. Vervolgens selecteert het Morph uit de [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatiesoftware die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

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

De [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) enumeratie regelt hoe Morph inhoud matcht en animeert:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) behandelt elke vorm als één geheel.  
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door, waar mogelijk, woorden te koppelen.  
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door, waar mogelijk, tekens te koppelen.

Stel de overgang [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) in op Morph vóór u de [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) benadert. De waarde levert vervolgens het [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/)‑object, waarvan de [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) eigenschap de match‑modus selecteert.

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

Sommige overgangen geven extra opties weer, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van het geselecteerde overgangs-[type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/). Stel eerst het type in, en gebruik vervolgens het juiste overgangsobject via zijn [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het stelt [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) in via [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

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

Ja. Geef de voorkeur aan [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) wanneer u een exacte effectduur in milliseconden nodig hebt. Gebruik [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) categorie — SLOW, MEDIUM of FAST — voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de timer‑vervolging.

**Kan ik audio aan een overgang koppelen en deze laten herhalen?**

Ja. Koppel ingebedde audio aan [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), stel [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) in op START_SOUND vanuit de [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) enumeratie, en schakel [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) in. De audio wordt herhaald totdat er een volgend geluidsevenement plaatsvindt in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)‑collectie van de presentatie en stel voor elke dia de overgangs-[type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) in op dezelfde waarde. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia's.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Lees de [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) eigenschap van de dia‑[slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Het retourneert een waarde uit de [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) enumeratie; NONE betekent dat er geen overgangseffect is toegepast.