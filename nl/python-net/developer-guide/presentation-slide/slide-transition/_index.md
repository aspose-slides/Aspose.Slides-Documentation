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
- Morph‑overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Pas dia‑overgangen toe, configureer automatische dia‑voortzetting en pas Morph en andere overgangseffecten aan met Aspose.Slides for Python via .NET."
---
## **Overzicht**

Dia‑overgangen bepalen hoe dia’s verschijnen tijdens een diavoorstelling. Met Aspose.Slides for Python via .NET kun je een overgangseffect voor elke dia kiezen, de voortgang per muisklik of timer configureren en opties die specifiek zijn voor een effect aanpassen. Dit artikel gebruikt Python‑voorbeelden om overgangen toe te passen, exacte overgangsduren in te stellen, diatiming te beheren en een Morph‑overgang tussen twee dia’s te maken. De voorbeelden laten ook zien hoe je de instellingen opslaat in een PPTX‑bestand.

## **Dia‑overgang toevoegen**

Om een overgang toe te passen, laad je een presentatie met de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑klasse en krijg je toegang tot de eigenschap van de dia [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Stel de [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) in op een waarde uit de [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)‑enumeratie en sla vervolgens de presentatie op.

Het volgende voorbeeld past een Circle‑overgang toe op de eerste dia en een Comb‑overgang op de tweede. Gebruik een bestand `input.pptx` met minimaal twee dia’s.

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

## **Wheel‑overgang**

De eigenschap [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) van [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) bepaalt het aantal radiale sectoren dat de bestemmingsdia onthult. Stel het [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) van de dia‑overgang in op WHEEL vanuit [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) voordat je toegang krijgt tot [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) als [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

Dit voorbeeld maakt twee identieke dia‑paren: een zwarte dia gevolgd door een dia met een gouden rechthoek. De bestemmingsdia’s gebruiken respectievelijk 1 en 8 spaken, met dezelfde [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) en een expliciete [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) van 8 000 ms om het verschil duidelijk waar te nemen.

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

Open de uitvoer‑presentatie in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2 en vervolgens van dia 3 naar dia 4. In de PowerPoint‑weergave onthult de geverifieerde spraakinstelling van 1 de dia met één klokrichting‑vegen; de geverifieerde instelling van 8 onthult deze via acht radiale sectoren tegelijk. De inhoud van de bestemmingsdia´s en de timing van de overgang zijn identiek, dus het verschil zit in het aantal onthullingssectoren.

## **Fade Through Black met de Reveal‑overgang**

Stel het [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) van de bestemmingsdia in op Reveal en zet vervolgens [through_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/through_black/) op het resulterende [RevealTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/)‑object. Het voorbeeld maakt een teal‑brondia en een coral‑bestemmingsdia, waarna het paar wordt gekloond. Beide paren gebruiken dezelfde twee‑seconden Reveal‑overgang. Alleen het tweede paar vervaagt via zwart.

```python
import aspose.slides as slides


def style_slide(slide, background_color, label):
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.preset_color = background_color

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 160, 180, 400, 130)
    shape.text_frame.text = label
    shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 44


with slides.Presentation() as presentation:
    source = presentation.slides[0]
    destination = presentation.slides.add_clone(source)
    style_slide(source, slides.PresetColor.TEAL, "Source")
    style_slide(destination, slides.PresetColor.CORAL, "Destination")
    presentation.slides.add_clone(source)
    presentation.slides.add_clone(destination)

    for index in (1, 3):
        transition = presentation.slides[index].slide_show_transition
        transition.type = slides.slideshow.TransitionType.REVEAL
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 2000
        
        reveal = transition.value
        reveal.direction = slides.slideshow.TransitionLeftRightDirectionType.LEFT
        reveal.through_black = index == 3

    presentation.save("reveal-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Open `reveal-transitions.pptx` in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2 om teal rechtstreeks in coral te laten vervagen. Ga vervolgens van dia 3 naar dia 4. Het scherm wordt kort donker tot bijna zwart voordat de coral‑dia verschijnt. Beide dia’s behouden hun oorspronkelijke achtergrondkleuren.

De rijen hieronder tonen frames uit PowerPoint met tussenpozen van een halve seconde. Vergelijk het middelste frame in elke rij om het effect van de instelling te zien.

![PowerPoint‑weergave met through_black uitgeschakeld (boven) en ingeschakeld (onder). Alleen de onderste rij gaat door bijna zwart.](reveal-through-black.png)

## **Geavanceerde dia‑overgang toevoegen**

Je kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortzet. De volgende eigenschappen regelen dit gedrag:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) stelt de kijker in staat om door te klikken.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) maakt automatische voortzetting mogelijk.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) bepaalt de wachttijd vóór automatische voortzetting, in milliseconden.

Schakel zowel klik‑ als timer‑voortzetting in zodat de kijker kan doorgaan met een klik of wachten op de timer. Om alleen de timer te gebruiken, zet je [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) op `False`. De wachttijd bepaalt wanneer de diavoorstelling voortgaat; hij stelt de duur van het visuele overgangseffect niet in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia’s en schakelt automatische voortzetting in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia’s ook voortzetten. Gebruik een bestand `input.pptx` met ten minste drie dia’s.

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

Om te controleren of timer‑voortzetting is ingeschakeld, lees je [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Een opgeslagen wachttijd alleen geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingeschakelde timer en schakelt automatische voortzetting uit voor dia’s met een wachttijd groter dan twee seconden. Het schakelt muisklikken in voor die dia’s en slaat de bijgewerkte instellingen op.

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

Gebruik [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) om de exacte lengte van een overgangseffect in milliseconden te specificeren. De eigenschap [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) van de dia exposeert deze instellingen via [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Eigenschap | Doel |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Stelt de wachttijd in voordat de dia automatisch wordt voortgezet, in milliseconden. Schakel [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) in om deze timer te activeren. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Selecteert een vooraf gedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM of FAST. Wordt gebruikt wanneer geen exacte duur is opgegeven. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) regelt alleen het overgangseffect; hij bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de automatische voortzettings‑wachttijd apart. Wanneer geen expliciete duur is opgegeven, bepaalt Aspose.Slides de effectduur op basis van het overgangstype en de [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)‑waarde.


<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Het gedeelde voorbeeld geeft elke dia een 750‑ms Fade‑overgang en schakelt apart automatische voortzetting in op 5 000 ms. De overgangsduur regelt het effect; de voortzetting regelt wanneer de dia wordt verlaten. Deze balken zijn schematische instellingen, niet een gemeten gecombineerde tijdlijn.*
<!-- visual-explanation:slide-transition:end -->

### **Dezelfde duur toepassen op elke dia**

Voor een consistent tempo, gebruik je hetzelfde effect en dezelfde exacte duur op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade vanuit [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), en geeft elke overgang een duur van 750 milliseconden. Het schakelt automatisch voortzetten in na 5 000 milliseconden en schakelt voortzetten per muisklik uit, vervolgens wordt het resultaat opgeslagen als PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Configureer automatische voortzetting onafhankelijk van de effectduur.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Verschillende duur per individuele dia instellen**

Verschillende dia’s kunnen verschillende effectduren hebben. Bijvoorbeeld, gebruik een korte overgang voor een titel­dia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 ms in voor de eerste dia en 1 200 ms voor de tweede. Gebruik een `input.pptx`‑bestand met ten minste twee dia’s.

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

Bij het voorbereiden van een [animated GIF](/slides/nl/python-net/convert-powerpoint-to-animated-gif/), een [HTML5 presentation](/slides/nl/python-net/export-to-html5/) of een [video](/slides/nl/python-net/convert-powerpoint-to-video/), stel je exacte overgangsduren in vóór export om het beoogde tempo te laten overeenkomen. Gebruik bijvoorbeeld een vervaging van 600 ms tussen scènes en pas elke dia‑voortzettings‑vertraging apart aan zodat er tijd is voor de bijbehorende voice‑over of inhoud.

Voor GIF‑ en video‑output, stem de framesnelheid af op de effectduur: 600 ms komt overeen met 18 frames bij 30 fps. In HTML5, schakel geanimeerde overgangen in de exportinstellingen in. Controleer welke effecten en timingopties de gekozen export‑indeling ondersteunt en bekijk een voorbeeld van de output om synchronisatie te bevestigen.

### **Een bestaande overgangsduur uitlezen**

Lees [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) uit voordat je de overgang wijzigt om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden aan. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides gebruikt het overgangstype en de [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) om die duur te bepalen. Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de oorspronkelijke instellingen.

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

De Morph‑overgang animeert wijzigingen tussen objecten op opeenvolgende dia’s. Om een eenvoudige Morph‑effect te maken, kloon je een dia, verplaats of wijzig je de grootte van een object op de kloon, en pas je de Morph‑overgang toe op de tweede dia. Dit geeft de overgang bijbehorende objecten om te animeren tussen hun originele en gewijzigde toestand.

Het volgende voorbeeld maakt een dia met een tekst‑rechthoek, kloont de dia, en verandert de positie en grootte van de rechthoek op de kloon. Vervolgens selecteert het Morph vanuit de [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)‑enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatie‑viewer die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

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

De enumeratie [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) bepaalt hoe Morph inhoud overeenstemt en animeert:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) behandelt elke vorm als één geheel.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door woorden waar mogelijk te koppelen.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animeert tekst door karakters waar mogelijk te koppelen.

Stel het [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) van de overgang in op Morph voordat je toegang krijgt tot de [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). De waarde levert dan het [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/)‑object, waarvan de eigenschap [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) de te kiezen overeenkomende modus bepaalt.

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

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van het geselecteerde [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/). Stel eerst het type in en gebruik vervolgens het juiste overgangsobject via zijn [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

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

**Kan ik de afspeelsnelheid van een dia‑overgang regelen?**

Ja. Geef de voorkeur aan [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) wanneer je een exacte effectduur in milliseconden nodig hebt. Gebruik [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/)‑categorie — SLOW, MEDIUM of FAST — voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de automatische voortzettings‑vertraging.

**Kan ik audio aan een overgang toevoegen en laten herhalen?**

Ja. Koppel ingebouwde audio aan [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), stel [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) in op START_SOUND vanuit de [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/)‑enumeratie, en activeer [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Het geluid blijft herhalen tot het volgende geluid‑evenement in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)‑collectie van de presentatie en stel de [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) van elke dia‑overgang in op dezelfde waarde. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia’s.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Lees de [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/)‑eigenschap van de [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) van de dia. Deze retourneert een waarde uit de [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)‑enumeratie; NONE betekent dat er geen overgangseffect is toegepast.