---
title: Dia-overgangen beheren in presentaties met Python via Java
linktitle: Dia-overgang
type: docs
weight: 80
url: /nl/python-java/slide-transition/
keywords:
- dia-overgang
- dia-overgang toevoegen
- dia-overgang toepassen
- geavanceerde dia-overgang
- Morph-overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Dia-overgangen toepassen, automatische voortgang van dia's configureren en Morph en andere overgangseffecten aanpassen met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Dia‑overgangen bepalen hoe dia’s verschijnen tijdens een diavoorstelling. Met Aspose.Slides for Python via Java kun je voor elke dia een overgangseffect kiezen, de vooruitgang per muisklik of timer configureren en opties die specifiek zijn voor een effect aanpassen. Dit artikel gebruikt Python‑voorbeelden om overgangen toe te passen, exacte overgangsduren in te stellen, diatiming te beheren en een Morph‑overgang tussen twee dia’s te creëren. De voorbeelden laten ook zien hoe je de instellingen opslaat in een PPTX‑bestand.

## **Dia‑overgang toevoegen**

Om een overgang toe te passen, laad je een presentatie met de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑klasse en krijg je toegang tot de overgangsinstellingen van de dia via [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Gebruik [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) met een waarde uit de [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/)‑enumeratie, en sla daarna de presentatie op.

Het volgende voorbeeld past een Circle‑overgang toe op de eerste dia en een Comb‑overgang op de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia’s.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Wheel‑overgang**

Gebruik [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) om Wheel te selecteren uit [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Roep vervolgens [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) aan om de instellingen van [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) te benaderen. Met de [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes)‑methode bepaal je hoeveel radiale sectoren de bestemmingsdia onthullen.

Het voorbeeld maakt twee identieke paren dia’s. Elk paar begint met een zwarte dia en eindigt met een goudkleurige rechthoek die de volledige dia vult. Beide bestemmingsdia’s gebruiken dezelfde trage snelheid ingesteld met [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) en dezelfde expliciete duur van 8.000 ms ingesteld met [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Alleen het aantal spaken verandert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Open `wheel-transitions.pptx` in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2 om één klokwijzer‑beweging de gouden rechthoek te laten onthullen. Ga vervolgens van dia 3 naar dia 4 om acht radiale sectoren dezelfde rechthoek tegelijk te laten onthullen.

## **Fade Through Black met de Reveal‑overgang**

Stel het overgangstype van de bestemmingsdia in op Reveal en roep vervolgens [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) aan op de instellingen van [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/). Het voorbeeld maakt een teal‑bron-dia en een koraal‑bestemmingsdia, en kloont beide. Elk paar gebruikt dezelfde twee‑seconden Reveal‑overgang. Alleen het tweede paar vervaagt via zwart.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Open `reveal-transitions.pptx` in PowerPoint en start de diavoorstelling. Ga van dia 1 naar dia 2 om teal direct in koraal te laten vervagen. Ga vervolgens van dia 3 naar dia 4. Het scherm wordt kort donker, bijna zwart, voordat de koraal‑dia verschijnt. Beide dia’s behouden hun oorspronkelijke achtergrondkleuren.

De rijen hieronder tonen frames uit PowerPoint met intervallen van een halve seconde. Vergelijk het middelste frame in elke rij om het effect te zien.

![PowerPoint playback with fade through black disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **Geavanceerde dia‑overgang toevoegen**

Je kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortzet. De volgende methoden regelen dit gedrag:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) maakt het mogelijk om door te gaan door te klikken.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) schakelt automatische voortgang in.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) specificeert de vertraging vóór automatische voortgang, in milliseconden.

Schakel zowel klik‑ als tijdsgebaseerde voortgang in zodat de kijker kan doorgaan met een klik of kan wachten op de timer. Om alleen de timer te gebruiken, geef `False` door aan [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). De vertraging bepaalt wanneer de diavoorstelling voortschrijdt; hij zet de duur van het visuele overgangseffect niet.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia’s en schakelt automatische voortgang in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia’s ook voortzetten. Gebruik een `input.pptx`‑bestand met minstens drie dia’s.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

Om te controleren of tijdsgebaseerde voortgang ingeschakeld is, roep je [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) aan. Een opgeslagen vertraging alleen geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingeschakelde timer en schakelt automatische voortgang uit voor dia’s met een vertraging van meer dan twee seconden. Het schakelt muisklikken in voor die dia’s en slaat de bijgewerkte instellingen op.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Overgangstiming nauwkeurig regelen**

Gebruik [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) om de exacte lengte van een overgangseffect in milliseconden op te geven. De [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition)‑methode van de dia maakt deze instellingen beschikbaar via [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Methode | Doel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Stelt de vertraging vóór automatische voortgang in, in milliseconden. Geef `True` aan [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) om deze timer te activeren. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Selecteert een vooraf gedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium of Fast. Wordt gebruikt wanneer geen exacte duur is opgegeven. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) regelt alleen het overgangseffect; hij bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de automatische voortgangsvertraging apart. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur op basis van het overgangstype en de [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed)‑waarde.


<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **Zelfde duur toepassen op elke dia**

Voor een gelijkmatig tempo kun je hetzelfde effect en dezelfde exacte duur op elke dia toepassen. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) en geeft elke overgang een duur van 750 milliseconden. Het schakelt automatisch voortgang in na 5.000 milliseconden en schakelt voortgang via muisklik uit, waarna het resultaat als PPTX wordt opgeslagen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Configureer automatische voortgang onafhankelijk van de duur van het effect.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Verschillende duren instellen voor individuele dia’s**

Verschillende dia’s kunnen verschillende effectduren hebben. Bijvoorbeeld een korte overgang voor een titeldia en een langere voor een sectie‑introductie. Dit voorbeeld stelt 500 ms in voor de eerste dia en 1.200 ms voor de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia’s.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Overgangen coördineren met geanimeerde output**

Wanneer je een [animated GIF](/slides/nl/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/nl/python-java/export-to-html5/) of [video](/slides/nl/python-java/convert-powerpoint-to-video/) maakt, stel dan exacte overgangsduren in vóór export zodat ze overeenkomen met het beoogde tempo. Gebruik bijvoorbeeld een fade van 600 ms tussen scènes en pas elke dia‑voortgangsvertraging apart aan om tijd te geven aan de bijbehorende voice‑over of inhoud.

Voor GIF‑ en video‑export moet je de framesnelheid afstemmen op de effectduur: 600 ms komt overeen met 18 frames bij 30 fps. In HTML5 kun je geanimeerde overgangen activeren in de exportinstellingen. Controleer welke effecten en timingopties het gekozen exportformaat ondersteunt en bekijk een voorbeeld om synchronisatie te bevestigen.

### **Bestaande overgangsduur uitlezen**

Roep [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) aan vóór je een overgang wijzigt om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden aan. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides gebruikt het overgangstype en de [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed)‑waarde om die duur te bepalen. Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de oorspronkelijke instellingen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Morph‑overgang**

De Morph‑overgang animeert veranderingen tussen objecten op opeenvolgende dia’s. Om een eenvoudige Morph‑effect te maken, kloon je een dia, verplaats of wijzig je de grootte van een object op de kloon, en pas je de Morph‑overgang toe op de tweede dia. Hierdoor krijgen de overeenkomstige objecten animatie‑overgangen tussen hun oorspronkelijke en aangepaste toestand.

Het volgende voorbeeld maakt een dia met een tekst‑rechthoek, kloont de dia en wijzigt de positie en grootte van de rechthoek op de kloon. Vervolgens selecteert het Morph uit de [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/)‑enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatiewatcher die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Morph‑overgangstypen**

De [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/)‑enumeratie bepaalt hoe Morph overeenkomende inhoud matcht en animeert:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) behandelt elke vorm als één geheel.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) animeert tekst door woorden waar mogelijk te matchen.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) animeert tekst door tekens waar mogelijk te matchen.

Gebruik [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) om Morph te selecteren voordat je [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) aanroept. De geretourneerde waarde is dan een instantie van de [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/)‑klasse, waarvan de [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType)‑methode de match‑modus selecteert.

Dit voorbeeld opent de presentatie die in het vorige gedeelte is gemaakt en configureert de tweede dia om woord‑gebaseerde Morph‑animatie te gebruiken.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Overgangseffecten instellen**

Sommige overgangen bieden extra opties, zoals richting of of het effect start vanaf een zwart scherm. De beschikbare opties hangen af van de overgang die met [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) is geselecteerd. Stel eerst het type in, en gebruik vervolgens de juiste klasse via [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

Het volgende voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het roept [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) aan via [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik de afspeelsnelheid van een dia‑overgang regelen?**

Ja. Geef de voorkeur aan [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) wanneer je een exacte effectduur in milliseconden nodig hebt. Gebruik [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/)‑categorie — Slow, Medium of Fast — volstaat en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de automatische voortgangsvertraging.

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. Wijs ingesloten audio toe met [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), geef `StartSound` uit de [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/)‑enumeratie door aan [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode), en schakel [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) in met `True`. De audio blijft herhalen totdat het volgende geluidsevent in de diavoorstelling plaatsvindt.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides)‑collectie van de presentatie en roep [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) aan met dezelfde waarde voor elke dia‑overgang. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over alle dia’s.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Roep [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) aan op het resultaat van [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) van de dia. Het retourneert een waarde uit de [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/)‑enumeratie; `None_` betekent dat er geen overgangseffect is toegepast.