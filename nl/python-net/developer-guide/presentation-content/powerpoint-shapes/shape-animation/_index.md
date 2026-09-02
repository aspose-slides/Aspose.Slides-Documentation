---
title: Toepassen van vormanimaties in presentaties met Python
linktitle: Vormanimatie
type: docs
weight: 60
url: /nl/python-net/shape-animation/
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
- Aspose.Slides
description: "Leer hoe u vormanimaties, timing, geluiden, gedrag na animatie en geanimeerde tekst kunt toevoegen, inspecteren en aanpassen met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aspose.Slides for Python via .NET vertegenwoordigt dia‑animaties als effecten in een diatijdlijn. Een effect heeft een doelvorm, een animatietype en subtype, een trigger, timinginstellingen en optionele eigenschappen zoals geluid of gedrag na de animatie.

De tijdlijn bevat twee soorten reeksen:

- De **hoofdreeks** speelt af wanneer de dia doorgaat.
- Een **interactieve reeks** start wanneer de trigger‑vorm wordt aangeklikt.

Omdat tekstvakken, afbeeldingen, grafieken, tabellen en andere dia‑objecten [IShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ishape/) implementeren, gebruik je dezelfde [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/)‑methode voor de meeste dia‑inhoud. De beschikbare effecten staan opgesomd in de enumeratie [EffectType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttype/).

## **Vorm‑animaties toevoegen**

Om een animatie toe te voegen, haal je de hoofdreeks van de dia op en roep je [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/) aan met de doelvorm, het effecttype, subtype en trigger. Voor een effect dat start wanneer een andere vorm wordt aangeklikt, maak je een interactieve reeks waarvan de trigger die andere vorm is.

Het volgende voorbeeld maakt beide soorten animaties en slaat het resultaat op in `shape-animations.pptx`.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

De trigger bepaalt wanneer een effect start:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttriggertype/) wacht op een klik in de hoofdreeks, of op een klik op de trigger‑vorm in een interactieve reeks.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttriggertype/) start tegelijk met het voorafgaande effect.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttriggertype/) start wanneer het voorafgaande effect beëindigd is.

Om een afbeelding, grafiek of een ander type vorm te animeren, geef je dat object door aan [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/) in plaats van `target_shape`. Voor grafiek‑specifieke groeperingsopties, zie [Animated Charts](/slides/nl/python-net/animated-charts/).

## **Vorm‑animaties lezen**

Gebruik [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) wanneer je de doelvorm kent. Om elk effect te inspecteren, loop je door de hoofdreeks en elke interactieve reeks. Iteratie voorkomt de aanname dat een reeks een effect bevat op index `0`.

Het volgende voorbeeld maakt een vorm met hoofd‑ en interactieve effecten, haalt de effecten op die de vorm targeten, en loopt vervolgens door elke reeks op de dia.

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

Als je alleen de effecten voor één vorm nodig hebt, identificeer je eerst de vorm op naam, placeholder‑type of een andere stabiele eigenschap; roep daarna [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) aan. Ga er niet van uit dat de vorm op index `0` altijd het bedoelde object is.

## **Werken met geërfde placeholder‑effecten**

Een placeholder op een normale dia kan animatiegedrag erven van de corresponderende placeholder op de lay‑dia en de master‑dia. [Shape.get_base_placeholder](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_base_placeholder/) retourneert die bovenliggende placeholder, of `None` wanneer er geen bovenliggend element bestaat.

In de voorbeeldpresentatie hieronder heeft de voettekst **Random Bars** op de normale dia, **Split** op de lay‑dia, en **Fly In** op de master‑dia.

![Footer‑animatie‑effect op de normale dia](slide-shape-animation.png)

![Footer‑placeholder‑animatie‑effect op de lay‑dia](layout-shape-animation.png)

![Footer‑placeholder‑animatie‑effect op de master‑dia](master-shape-animation.png)

Het volgende voorbeeld bouwt zelf de placeholder‑hiërarchie. Het voegt effecten toe aan een master‑placeholder, een lay‑placeholder en de corresponderende placeholder op een normale dia. Elke oproep naar [Shape.get_base_placeholder](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_base_placeholder/) wordt gecontroleerd voordat de geretourneerde vorm wordt gebruikt.

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **Animatietiming wijzigen**

Het PowerPoint‑**Timing**‑dialoogvenster mappt op de eigenschappen van [Timing](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/).

![PowerPoint‑Timing‑dialoog voor een animatie‑effect](shape-animation.png)

- **Start** mappt op [Timing.trigger_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/trigger_type/).
- **Duur** mapt op [Timing.duration](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/duration/), in seconden.
- **Vertraging** mapt op [Timing.trigger_delay_time](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/trigger_delay_time/), in seconden.
- **Herhalen** mapt op [Timing.repeat_count](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_until_next_click/), of [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Terugspoelen na afspelen** mapt op [Timing.rewind](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/rewind/).

Dit onafhankelijke voorbeeld voegt een effect toe, wijzigt de timing via het object dat wordt geretourneerd door [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/), en slaat het resultaat op. Het bewaren van de geretourneerde [Effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/)‑referentie voorkomt een onnodige indexverwijzing.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

Gebruik één herhaal‑modus bewust. Het combineren van een herhaal‑aantal met een “until”‑vlag kan verwarrende resultaten geven in verschillende viewers. Wanneer je de herhaal‑modi wijzigt, stel je eerst [Timing.repeat_until_next_click](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_until_next_click/) en [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) in, voordat je [Timing.repeat_count](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_count/) zet, omdat het instellen van een vlag tevens de actieve herhaal‑modus wijzigt.

## **Animatie‑geluiden toevoegen en extraheren**

Een animatie‑effect kan een ingebed audio‑bestand refereren via [Effect.sound](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/sound/). [Effect.stop_previous_sound](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/stop_previous_sound/) instrueert een effect om audio die door een eerder effect gestart is, te stoppen.

### **Geluid aan een effect toevoegen**

Het volgende voorbeeld gaat uit van een lokaal audiobestand met de naam `animation-sound.wav`. Het maakt twee effecten, embedt dat bestand als geluid voor het eerste effect, en configureert het tweede effect om het geluid te stoppen. Het gebruikt de objecten die worden geretourneerd door [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/), zodat geen reeks‑index nodig is.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **Ingebedde effectgeluiden extraheren**

Het volgende voorbeeld gaat uit van een lokale presentatie met de naam `presentation-with-animation-sounds.pptx`. Het scant zowel de hoofd‑ als de interactieve reeksen en schrijft elk ingebed effectgeluid weg naar de map `extracted-animation-sounds`. De extensie wordt gekozen op basis van het audio‑MIME‑type dat wordt blootgesteld via [Audio.content_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audio/content_type/).

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

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
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

Voor grote audiobestanden, gebruik [Audio.get_stream](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audio/get_stream/) en kopieer de stroom naar een bestand in plaats van het volledige object in een byte‑array te laden.

## **Gedrag na animatie instellen**

De **After animation**‑optie bepaalt wat er met een vorm gebeurt nadat het effect voltooid is.

![PowerPoint‑Effect‑opties‑dialoog met After‑animation‑instellingen](shape-after-animation.png)

Enumeratie [AfterAnimationType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/afteranimationtype/) ondersteunt het ongewijzigd laten van de vorm, het veranderen van de kleur, de vorm verbergen na de animatie, of de vorm verbergen bij de volgende klik. Wanneer het type [AfterAnimationType.COLOR](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/afteranimationtype/) is, stel je tevens [Effect.after_animation_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/after_animation_color/) in.

Dit onafhankelijke voorbeeld maakt een effect, stelt het after‑animation‑gedrag in via het geretourneerde effectobject, en slaat het resultaat op.

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

Het wijzigen van het type van [AfterAnimationType.COLOR](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/afteranimationtype/) wist de after‑animation‑kleurinstelling.

## **Tekst animeren**

Tekstanimatie heeft twee gerelateerde instellingen:

- [TextAnimation.build_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/textanimation/build_type/) bepaalt of alinea’s tegelijk of per alinea‑niveau verschijnen.
- [Effect.animate_text_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/animate_text_type/) bepaalt of tekst in één keer, per woord, of per letter verschijnt. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/delay_between_text_parts/) stelt de vertraging tussen woorden of letters in. Een positieve waarde is een percentage van de effectduur; een negatieve waarde is een vertraging in seconden.

Het volgende onafhankelijke voorbeeld animeert de woorden in een tekstvak. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/buildtype/) schakelt opbouwen per alinea uit zodat de woordinstelling op het volledige tekstframe van toepassing is.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

Om een tekstvak per alinea op te bouwen, stel je [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/buildtype/) (of een ander alinea‑niveau) in. Om een enkele alinea met een eigen effect te targeten, gebruik je de overload van [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/) die een [IParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iparagraph/) accepteert. Zie [Animated Text](/slides/nl/python-net/animated-text/) voor voorbeelden op alinea‑niveau.

## **Export‑ en compatibiliteitsopmerkingen**

- Opslaan als PPT of PPTX behoudt het animatiemodel, maar de uiteindelijke weergave wordt bepaald door de presentatie‑viewer.
- PDF en statische afbeeldingen spelen geen animaties af. Gebruik [HTML5 export](/slides/nl/python-net/export-to-html5/), een geanimeerde GIF, of [video‑conversie](/slides/nl/python-net/convert-powerpoint-to-video/) wanneer de output beweging moet laten zien.
- Voor HTML5, schakel [Html5Options.animate_shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/html5options/animate_shapes/) in en, indien nodig, [Html5Options.animate_transitions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/html5options/animate_transitions/).
- Videorendering ondersteunt veel gangbare binnenkomst-, nadruk‑, uitgang‑ en bewegings‑pad‑effecten, maar niet elk PowerPoint‑effect wordt ondersteund. Controleer de actuele [supported animations and effects](/slides/nl/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) en test kritieke presentaties met de door jou gebruikte Aspose.Slides‑versie.
- Geavanceerde aangepaste effecten en effecten geïmporteerd uit andere presentatieformaten kunnen behouden blijven in het bestand maar verschillend renderen in PowerPoint, HTML5 of video. Valideer het geëxporteerde resultaat in plaats van alleen op de effectnaam te vertrouwen.

## **FAQ**

**Waarom wordt een animatie wel getoond in PowerPoint maar niet in een PDF?**

PDF is een statisch formaat, dus animaties en dia‑overgangen worden niet afgespeeld. Exporteer naar HTML5, een geanimeerde GIF, of een video wanneer beweging moet worden bewaard.

**Waarom speelt een effect anders af in een video?**

Video‑export rendert animaties in plaats van het originele PowerPoint‑gedrag op te slaan. Sommige geavanceerde effecten worden niet ondersteund of benaderd. Raadpleeg de tabel met ondersteunde effecten en test de daadwerkelijke presentatie vóór productie‑gebruik.

**Verandert het naar voren of naar achteren verplaatsen van een vorm de animatievolgorde?**

Nee. De z‑order van een vorm bepaalt overlappen, terwijl de volgorde van reeksen en triggers de afspeelvolgorde van animaties bepalen. Pas de tijdlijn aan als je een andere afspeelvolgorde nodig hebt.