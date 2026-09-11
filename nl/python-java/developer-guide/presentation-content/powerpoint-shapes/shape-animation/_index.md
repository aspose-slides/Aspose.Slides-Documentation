---
title: "Vormanimaties toepassen in presentaties met Python via Java"
linktitle: "Vormanimatie"
type: docs
weight: 60
url: /nl/python-java/shape-animation/
keywords:
- vorm
- animatie
- effect
- geanimeerde vorm
- geanimeerde tekst
- animatie toevoegen
- animatie ophalen
- animatie extraheren
- effect toevoegen
- effect ophalen
- effect extraheren
- effectgeluid
- animatie toepassen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u vormanimaties, timing, geluiden, gedrag na animatie en geanimeerde tekst kunt toevoegen, inspecteren en aanpassen met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides for Python via Java stelt dia‑animaties voor als effecten in een diatijdlijn. Een effect heeft een doelvorm, een animatietype en -subtype, een trigger, timing‑instellingen en optionele eigenschappen zoals geluid of gedrag na de animatie.

De tijdlijn bevat twee soorten reeksen:

- De **hoofdreeks** wordt afgespeeld wanneer de dia wordt voortgezet.
- Een **interactieve reeks** start wanneer de trigger‑vorm wordt aangeklikt.

Omdat tekstvakken, afbeeldingen, diagrammen, tabellen en andere dia‑objecten afstammen van [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/), gebruik je dezelfde [Sequence.addEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/#addEffect)‑methode voor de meeste dia‑inhoud. De beschikbare effecten worden opgesomd in de klasse [EffectType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effecttype/).

## **Vormanimaties toevoegen**

Om een animatie toe te voegen, haal je de hoofdreeks van de dia op en roep je [Sequence.addEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/#addEffect) aan met de doelvorm, het effecttype, subtype en trigger. Voor een effect dat start wanneer een andere vorm wordt aangeklikt, maak je een interactieve reeks waarvan de trigger die andere vorm is.

Het volgende voorbeeld maakt beide soorten animaties en slaat het resultaat op in `shape-animations.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De trigger bepaalt wanneer een effect start:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effecttriggertype/#OnClick) wacht op een klik in de hoofdreeks, of op een klik op de trigger‑vorm in een interactieve reeks.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effecttriggertype/#WithPrevious) start met het voorgaande effect.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effecttriggertype/#AfterPrevious) start wanneer het voorgaande effect eindigt.

Om een afbeelding, diagram of een ander vormtype te animeren, geef je dat object door aan [Sequence.addEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/#addEffect) in plaats van `target_shape`. Voor diagram‑specifieke groepeeralternatieven, zie [Geanimeerde diagrammen](/slides/nl/python-java/animated-charts/).

## **Vormanimaties lezen**

Gebruik [Sequence.getEffectsByShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/#getEffectsByShape) wanneer je de doelvorm kent. Om elk effect te inspecteren, doorloop je de hoofdreeks en elke interactieve reeks. Doorlopen voorkomt dat je aanneemt dat een reeks een effect bevat op index `0`.

Het volgende voorbeeld maakt een vorm met hoofd‑ en interactieve effecten, haalt de effecten op die de vorm targeten, en doorloopt vervolgens elke reeks op de dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

Als je alleen de effecten voor één vorm nodig hebt, identificeer dan eerst de vorm op naam, placeholder‑type of een andere stabiele eigenschap; roep vervolgens [Sequence.getEffectsByShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/#getEffectsByShape) aan. Ga niet automatisch uit van [ShapeCollection.get_Item](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#get_Item) op index `0` als het beoogde object.

## **Werken met geërfde placeholder‑effecten**

Een placeholder op een normale dia kan animatiegedrag overnemen van de overeenkomstige placeholder op zijn lay-outdia en master‑dia. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getBasePlaceholder) retourneert die bovenliggende placeholder, of `None` als er geen bovenliggende bestaat.

In de volgende voorbeeldpresentatie heeft de voettekst **Random Bars** op de normale dia, **Split** op de lay-outdia, en **Fly In** op de master‑dia.

![Voettekstanimatie‑effect op de normale dia](slide-shape-animation.png)

![Voettekst‑placeholderanimatie‑effect op de lay-outdia](layout-shape-animation.png)

![Voettekst‑placeholderanimatie‑effect op de master‑dia](master-shape-animation.png)

Het volgende voorbeeld gebruikt een placeholder‑hiërarchie uit een nieuwe presentatie. Het voegt effecten toe aan een master‑placeholder, een lay-out‑placeholder en de overeenkomstige placeholder op een normale dia. Elke aanroep van [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getBasePlaceholder) wordt gecontroleerd voordat de geretourneerde vorm wordt gebruikt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animatietiming wijzigen**

Het PowerPoint **Timing**‑dialoogvenster correspondeert met de eigenschappen van [Timing](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/).

![PowerPoint Timing‑dialoog voor een animatie‑effect](shape-animation.png)

- **Start** correspondeert met [Timing.getTriggerType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getTriggerType).
- **Duur** correspondeert met [Timing.getDuration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getDuration), in seconden.
- **Vertraging** correspondeert met [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getTriggerDelayTime), in seconden.
- **Herhaal** correspondeert met [Timing.getRepeatCount](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getRepeatUntilNextClick), of [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Terugspoelen bij voltooid afspelen** correspondeert met [Timing.getRewind](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getRewind).

Dit zelfstandige voorbeeld voegt een effect toe, wijzigt de timing via het object dat wordt geretourneerd door [Sequence.addEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/#addEffect), en slaat het resultaat op. Het behouden van de geretourneerde [Effect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effect/)‑referentie voorkomt een onnodige collectie‑index.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gebruik bewust één herhaal‑modus. Het combineren van een herhaal‑aantal met een “until”-vlag kan verwarrende resultaten opleveren in verschillende weergaveprogramma's. Bij het wijzigen van herhaal‑modi, stel je [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#setRepeatUntilNextClick) en [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) in vóór [Timing.setRepeatCount](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#setRepeatCount), omdat het instellen van een van beide vlaggen ook de actieve herhaal‑modus wijzigt.

## **Animatiegeluiden toevoegen en extraheren**

Een animatie‑effect kan verwezen naar ingebedde audio via [Effect.getSound](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effect/#setStopPreviousSound) instrueert een effect om audio te stoppen die is gestart door een eerder effect.

### **Geluid aan een effect toevoegen**

Het volgende voorbeeld verwacht een lokaal audiobestand met de naam `animation-sound.wav`. Het maakt twee effecten, embed het bestand als geluid voor het eerste effect, en configureert het tweede effect om het geluid te stoppen. Het gebruikt de objecten die worden geretourneerd door [Sequence.addEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/#addEffect), dus een reeks‑index is niet nodig.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ingebedde effectgeluiden extraheren**

Het volgende voorbeeld verwacht een lokale presentatie met de naam `presentation-with-animation-sounds.pptx`. Het scant zowel de hoofd‑ als de interactieve reeksen en schrijft elk ingebed effectgeluid naar de map `extracted-animation-sounds`. De extensie wordt gekozen op basis van het audio‑MIME‑type dat wordt blootgesteld door [Audio.getContentType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audio/#getContentType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"
    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

Voor grote audio‑objecten, gebruik [Audio.getStream](https://reference.aspose.com/slides/nl/python-java/aspose.slides/audio/#getStream) en kopieer de stream naar een bestand in plaats van het volledige object in een byte‑array te laden.

## **Gedrag na animatie instellen**

De optie **After animation** bepaalt wat er met een vorm gebeurt nadat het effect is voltooid.

![PowerPoint Effect Options‑dialoog met instellingen voor After animation](shape-after-animation.png)

De klasse [AfterAnimationType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/afteranimationtype/) ondersteunt het onveranderd laten van de vorm, het wijzigen van de kleur, verbergen na de animatie, of verbergen bij de volgende klik. Wanneer het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/python-java/aspose.slides/afteranimationtype/#Color) is, stel dan ook [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effect/#getAfterAnimationColor) in.

Dit zelfstandige voorbeeld maakt een effect, stelt het gedrag na de animatie in via het geretourneerde effectobject, en slaat het resultaat op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het wijzigen van het type weg van [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/python-java/aspose.slides/afteranimationtype/#Color) wist de after‑animation‑kleurinstelling.

## **Tekst animeren**

Tekstanimatie heeft twee gerelateerde instellingen:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textanimation/#getBuildType) bepaalt of alinea's samen verschijnen of per alinea‑niveau.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effect/#getAnimateTextType) bepaalt of tekst in één keer, per woord, of per letter verschijnt. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effect/#getDelayBetweenTextParts) stelt de vertraging tussen woorden of letters in. Een positieve waarde is een percentage van de effectduur; een negatieve waarde is een vertraging in seconden.

Het volgende zelfstandige voorbeeld animeert de woorden in een tekstvak. [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/python-java/aspose.slides/buildtype/#AsOneObject) schakelt opbouw per alinea uit zodat de woordinstelling wordt toegepast op het volledige tekstframe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Om een tekstvak per alinea op te bouwen, stel je [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/nl/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) in (of een ander alinea‑niveau). Om een enkele alinea met een eigen effect te targeten, gebruik je de [Sequence.addEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/#addEffect)‑overload die een [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) accepteert. Zie [Geanimeerde tekst](/slides/nl/python-java/animated-text/) voor voorbeelden per alinea.

## **Export‑ en compatibiliteitsopmerkingen**

- Opslaan als PPT of PPTX behoudt het animatiemodel, maar de uiteindelijke weergave wordt gecontroleerd door de presentatie‑viewer.
- PDF en statische afbeeldingen spelen geen animaties af. Gebruik [HTML5 export](/slides/nl/python-java/export-to-html5/), geanimeerde GIF, of [video conversion](/slides/nl/python-java/convert-powerpoint-to-video/) wanneer de output beweging moet weergeven.
- Voor HTML5, schakel [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/#setAnimateShapes) in en, indien nodig, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/#setAnimateTransitions).
- Video‑rendering ondersteunt veel gangbare ingang‑, nadruk‑, uitstap‑ en bewegings‑pad‑effecten, maar niet elk PowerPoint‑effect wordt ondersteund. Controleer de huidige [supported animations and effects](/slides/nl/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) en test kritieke presentaties met de beoogde Aspose.Slides‑versie.
- Geavanceerde aangepaste effecten en effecten die zijn geïmporteerd uit andere presentatie‑formaten kunnen behouden blijven in het bestand, maar anders worden gerenderd in PowerPoint, HTML5 of video. Valideer het geëxporteerde resultaat in plaats van alleen op de effectnaam te vertrouwen.

## **FAQ**

**Waarom verschijnt een animatie in PowerPoint maar niet in een PDF?**

PDF is een statisch formaat, dus animaties en dia‑overgangen worden niet afgespeeld. Exporteer naar HTML5, geanimeerde GIF, of video wanneer beweging behouden moet blijven.

**Waarom wordt een effect anders afgespeeld in een video?**

Video‑export rendert animaties in plaats van het originele PowerPoint‑gedrag op te slaan. Sommige geavanceerde effecten worden niet ondersteund of slechts benaderd. Bekijk de tabel met ondersteunde effecten en test de daadwerkelijke presentatie voordat je het gebruikt in productie.

**Verandert het naar voren of naar achteren verplaatsen van een vorm de animatievolgorde?**

Nee. De z‑order van een vorm bepaalt de overlap, terwijl de volgorde van reeksen en triggers de animatie‑afspeelvolgorde bepalen. Wijzig de tijdlijn als je een andere afspeelvolgorde nodig hebt.