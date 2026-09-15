---
title: Beheer diaovergangen in presentaties met Python via Java
linktitle: Diaovergang
type: docs
weight: 80
url: /nl/python-java/slide-transition/
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
- Java
- Aspose.Slides
description: "Pas diaovergangen toe, configureer automatische dia-voortzetting en pas Morph en andere overgangseffecten aan met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Diaovergangen bepalen hoe dia's verschijnen tijdens een diavoorstelling. Met Aspose.Slides voor Python via Java kunt u voor elke dia een overgangen effect kiezen, de voortgang via muisklik of timer configureren en opties die specifiek zijn voor een effect aanpassen. Dit artikel gebruikt Python‑voorbeelden om overgangen toe te passen, exacte transitie‑duur in te stellen, de timing van dia's te beheren en een Morph‑overgang tussen twee dia's te maken. De voorbeelden laten ook zien hoe de instellingen op te slaan in een PPTX‑bestand.

## **Diaovergang toevoegen**

Om een overgang toe te passen, laad een presentatie met de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en krijg toegang tot de overgangsinstellingen van de dia via [getSlideShowTransition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getSlideShowTransition). Gebruik [setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setType) met een waarde uit de [TransitionType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/transitiontype/)‑enumeratie, en sla vervolgens de presentatie op.

Het onderstaande voorbeeld past een Circle‑overgang toe op de eerste dia en een Comb‑overgang op de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

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

## **Geavanceerde diaovergang toevoegen**

U kunt configureren hoe lang een dia op het scherm blijft en of een muisklik de diavoorstelling voortzet. De volgende methoden beheersen dit gedrag:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) stelt de kijker in staat om door te klikken met de muis.
- [setAdvanceAfter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) schakelt automatische voortzetting in.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) geeft de vertraging vóór automatische voortzetting op, in milliseconden.

Schakel zowel klik‑ als timer‑voortzetting in zodat de kijker kan doorgaan met een klik of kan wachten op de timer. Om alleen de timer te gebruiken, geef `False` door aan [setAdvanceOnClick]. De vertraging bepaalt wanneer de diavoorstelling voortgaat; het stelt niet de duur van het visuele overgangseffect in.

Dit voorbeeld kent verschillende effecten toe aan de eerste drie dia's en schakelt automatische voortzetting in na respectievelijk 3, 5 en 7 seconden. Muisklikken kunnen deze dia's ook voortzetten. Gebruik een `input.pptx`‑bestand met minstens drie dia's.

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

Om te controleren of timer‑voortzetting is ingeschakeld, roep [getAdvanceAfter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) aan. Een opgeslagen vertraging alleen geeft niet aan dat de timer actief is.

Het volgende voorbeeld opent het hierboven opgeslagen bestand, meldt elke ingeschakelde timer en schakelt automatische voortzetting uit voor dia's met een vertraging van meer dan twee seconden. Het schakelt muisklikken in voor die dia's en slaat de bijgewerkte instellingen op.

```python
import jpype
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

## **Precisie bij overgangstiming**

Gebruik [setDuration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setDuration) om de exacte lengte van een overgangseffect in milliseconden op te geven. De [getSlideShowTransition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getSlideShowTransition)‑methode van de dia maakt deze instellingen beschikbaar via [SlideShowTransition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/):

| Methode | Doel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setDuration) | Stelt de duur van het overgangseffect zelf in, in milliseconden. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Stelt de vertraging vóór automatische voortzetting van de dia in, in milliseconden. Geef `True` door aan [setAdvanceAfter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) om deze timer te activeren. |
| [setSpeed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setSpeed) | Selecteert een vooraf gedefinieerde snelheidscategorie uit [TransitionSpeed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/transitionspeed/): Slow, Medium of Fast. Het wordt gebruikt wanneer geen exacte duur is opgegeven. |

[setDuration] regelt alleen het overgangseffect; het bepaalt niet hoe lang de dia zichtbaar blijft. Configureer de automatische voortzettingsvertraging apart. Wanneer geen expliciete duur is ingesteld, bepaalt Aspose.Slides de effectduur op basis van het overgangstype en de [getSpeed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#getSpeed)‑waarde.

### **Zelfde duur toepassen op elke dia**

Voor een consistent tempo, pas hetzelfde effect en dezelfde exacte duur toe op elke dia. Dit voorbeeld laadt `input.pptx`, selecteert Fade uit [TransitionType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/transitiontype/), en geeft elke overgang een duur van 750 milliseconden. Het schakelt apart automatische voortzetting in na 5.000 milliseconden en schakelt voortzetting via muisklik uit, waarna het resultaat als PPTX wordt opgeslagen.

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

        # Configureer automatische voortzetting, onafhankelijk van de duur van het effect.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Verschillende duur instellen voor individuele dia's**

Verschillende dia's kunnen verschillende effectduur gebruiken. Gebruik bijvoorbeeld een korte overgang voor een titel‑dia en een langere overgang voor een sectie‑introductie. Dit voorbeeld stelt 500 milliseconden in voor de eerste dia en 1.200 milliseconden voor de tweede. Gebruik een `input.pptx`‑bestand met minstens twee dia's.

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

Bij het voorbereiden van een [animated GIF](/slides/nl/python-java/convert-powerpoint-to-animated-gif/), [HTML5‑presentatie](/slides/nl/python-java/export-to-html5/) of [video](/slides/nl/python-java/convert-powerpoint-to-video/), stel exacte overgangsduren in vóór export om het beoogde tempo te halen. Gebruik bijvoorbeeld een fade van 600 milliseconden tussen de scènes en pas de voortzettingsvertraging van elke dia apart aan om tijd te geven aan de bijbehorende vertelling of inhoud.

Voor GIF en video, stem de uitvoer‑frame‑rate af op de effectduur: 600 milliseconden komt overeen met 18 frames bij 30 frames per seconde. In HTML5 schakelt u geanimeerde overgangen in de exportinstellingen in. Controleer de ondersteunde effecten en timing‑opties van het gekozen exportformaat en bekijk een voorbeeld van de output om synchronisatie te bevestigen.

### **Bestaande overgangsduur lezen**

Roep [getDuration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#getDuration) aan voordat u de overgang wijzigt om te bepalen of er een expliciete waarde is opgeslagen. Een waarde van `-1` betekent dat er geen expliciete duur is ingesteld; een niet‑negatieve waarde geeft de opgeslagen duur in milliseconden weer. De niet‑ingestelde waarde is niet de berekende afspeelduur: Aspose.Slides gebruikt het overgangstype en de [getSpeed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#getSpeed)‑waarde om die duur te bepalen. Het instellen van een overgangstype kan een duur initialiseren, dus inspecteer eerst de originele instellingen.

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

De Morph‑overgang animeert veranderingen tussen objecten op opeenvolgende dia's. Om een eenvoudige Morph‑effect te maken, kloont u een dia, verplaatst of schaalt u een object op de kloon, en past u de Morph‑overgang toe op de tweede dia. Hierdoor krijgt de overgang de bijbehorende objecten om te animeren tussen hun oorspronkelijke en gewijzigde staat.

Het onderstaande voorbeeld maakt een dia met een tekst‑rechthoek, kloont de dia en wijzigt de positie en grootte van de rechthoek op de kloon. Vervolgens selecteert het Morph uit de [TransitionType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/transitiontype/)‑enumeratie voor de tweede dia. Open het opgeslagen bestand in een presentatieweergave die Morph ondersteunt om het effect tijdens een diavoorstelling te zien.

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

De [TransitionMorphType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/transitionmorphtype/)‑enumeratie bepaalt hoe Morph inhoud koppelt en animeert:

- [ByObject](https://reference.aspose.com/slides/nl/python-java/aspose.slides/transitionmorphtype/#ByObject) behandelt elke vorm als één geheel.
- [ByWord](https://reference.aspose.com/slides/nl/python-java/aspose.slides/transitionmorphtype/#ByWord) animeert tekst door woorden te koppelen waar mogelijk.
- [ByChar](https://reference.aspose.com/slides/nl/python-java/aspose.slides/transitionmorphtype/#ByChar) animeert tekst door tekens te koppelen waar mogelijk.

Gebruik [setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setType) om Morph te selecteren voordat u [getValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#getValue) aanroept. De waarde is dan een instantie van de [MorphTransition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/morphtransition/)‑klasse, waarvan de [setMorphType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/morphtransition/#setMorphType)‑methode de koppelingsmodus selecteert.

Dit voorbeeld opent de presentatie die in de vorige sectie is gemaakt en configureert de tweede dia om woordgebaseerde Morph‑animatie te gebruiken.

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

Sommige overgangen bieden extra opties, zoals richting of of het effect begint vanaf een zwart scherm. De beschikbare opties hangen af van de overgang die met [setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setType) is geselecteerd. Stel eerst het type in en gebruik vervolgens de juiste klasse via [getValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#getValue).

Het onderstaande voorbeeld past een Cut‑overgang toe op de eerste dia van `input.pptx`. Het roept [setFromBlack](https://reference.aspose.com/slides/nl/python-java/aspose.slides/optionalblacktransition/#setFromBlack) aan via [OptionalBlackTransition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/optionalblacktransition/) zodat de overgang start vanaf een zwart scherm.

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

**Kan ik de afspeelsnelheid van een diaovergang regelen?**

Ja. Geef de voorkeur aan [setDuration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setDuration) wanneer u een exacte effectduur in milliseconden nodig heeft. Gebruik [setSpeed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setSpeed) wanneer een vooraf gedefinieerde [TransitionSpeed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/transitionspeed/)‑categorie — Slow, Medium of Fast — voldoende is en er geen expliciete duur is ingesteld. Deze instellingen regelen het overgangseffect onafhankelijk van de automatische voortzettingsvertraging.

**Kan ik audio aan een overgang toevoegen en laten loopen?**

Ja. Wijs ingesloten audio toe met [setSound](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setSound), geef StartSound uit de [TransitionSoundMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/transitionsoundmode/)‑enumeratie door aan [setSoundMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setSoundMode), en schakel [setSoundLoop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setSoundLoop) in met `True`. De audio loopt tot het volgende geluidsevenement in de diavoorstelling.

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Loop door de [getSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlides)‑collectie van de presentatie en roep [setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#setType) aan met dezelfde waarde voor de overgang van elke dia. Stel eventuele timing‑ en effectopties in dezelfde lus in om het gedrag consistent te houden over de dia's heen.

**Hoe kan ik controleren welke overgang momenteel is ingesteld op een dia?**

Roep [getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowtransition/#getType) aan op het resultaat van de dia‑[getSlideShowTransition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getSlideShowTransition). Het retourneert een waarde uit de [TransitionType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/transitiontype/)‑enumeratie; None_ betekent dat er geen overgangseffect is toegepast.