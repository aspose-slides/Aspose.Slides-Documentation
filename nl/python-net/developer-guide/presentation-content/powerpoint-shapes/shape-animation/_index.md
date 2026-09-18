---
title: Pas vormanimaties toe in presentaties met Python
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

Om met de individuele gedragingen binnen een effect of bewerkings‑motion‑path‑segmenten te werken, zie [Aangepaste animatie](/slides/nl/python-net/custom-animation/).

Aspose.Slides for Python via .NET vertegenwoordigt dia‑animaties als effecten in een dia‑tijdlijn. Een effect heeft een doelfiguur, een animatietype en subtype, een trigger, tijdinstellingen en optionele eigenschappen zoals geluid of gedrag na de animatie.

De tijdlijn bevat twee soorten reeksen:

- De **hoofdreeks** wordt afgespeeld terwijl de dia wordt voortgezet.
- Een **interactieve reeks** start wanneer de trigger‑figuur wordt aangeklikt.

Omdat tekstvakken, afbeeldingen, grafieken, tabellen en andere dia‑objecten [IShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ishape/) implementeren, gebruik je dezelfde methode [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/) voor de meeste dia‑inhoud. De beschikbare effecten staan opgesomd in de enumeratie [EffectType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttype/).

## **Vormanimaties toevoegen**

Om een animatie toe te voegen, haal je de hoofdreeks van de dia op en roep je [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/) aan met de doelfiguur, effecttype, subtype en trigger. Voor een effect dat start wanneer een andere figuur wordt aangeklikt, maak je een interactieve reeks waarvan de trigger die andere figuur is.

Het volgende voorbeeld maakt beide typen animatie en slaat het resultaat op in `shape-animations.pptx`.

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

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttriggertype/) wacht op een klik in de hoofdreeks, of op een klik op de trigger‑figuur in een interactieve reeks.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttriggertype/) start gelijktijdig met het voorgaande effect.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttriggertype/) start wanneer het voorgaande effect eindigt.

Om een afbeelding, grafiek of een ander figuurtype te animeren, geef je dat object door aan [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/) in plaats van `target_shape`. Voor grafiek‑specifieke groepeeropties, zie [Geanimeerde grafieken](/slides/nl/python-net/animated-charts/).

## **Vormanimaties lezen**

Gebruik [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) wanneer je de doelfiguur kent. Om elk effect te inspecteren, doorloop je de hoofdreeks en elke interactieve reeks. Itereren voorkomt de aanname dat een reeks een effect op index `0` bevat.

Het volgende voorbeeld maakt een figuur met hoofd‑ en interactieve effecten, haalt de effecten op die de figuur targeten en doorloopt daarna elke reeks op de dia.

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

Als je alleen de effecten voor één figuur nodig hebt, identificeer je eerst de figuur op naam, placeholder‑type of een andere stabiele eigenschap; roep dan [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) aan. Ga niet ervan uit dat de figuur op index `0` altijd het bedoelde object is.

## **Werken met overgeërfde placeholder‑effecten**

Een placeholder op een normale dia kan animatiegedrag overerven van de overeenkomstige placeholder op de lay‑outdia en de master‑dia. [Shape.get_base_placeholder](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_base_placeholder/) retourneert die bovenliggende placeholder, of `None` wanneer er geen bovenliggend element bestaat.

In de volgende voorbeeldpresentatie heeft de voettekst **Random Bars** op de normale dia, **Split** op de lay‑outdia en **Fly In** op de master‑dia.

![Animatie‑effect van de voettekst op de normale dia](slide-shape-animation.png)

![Animatie‑effect van de voettekst‑placeholder op de lay‑outdia](layout-shape-animation.png)

![Animatie‑effect van de voettekst‑placeholder op de master‑dia](master-shape-animation.png)

Het volgende voorbeeld bouwt de placeholder‑hiërarchie zelf op. Het voegt effecten toe aan een master‑placeholder, een lay‑out‑placeholder en de overeenkomstige placeholder op een normale dia. Elke oproep van [Shape.get_base_placeholder](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_base_placeholder/) wordt gecontroleerd voordat de geretourneerde figuur wordt gebruikt.

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

Het PowerPoint **Timing**‑dialoogvenster correspondeert met de eigenschappen van [Timing](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/).

![PowerPoint Timing‑dialoog voor een animatie‑effect](shape-animation.png)

- **Start** correspondeert met [Timing.trigger_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/trigger_type/).
- **Duur** correspondeert met [Timing.duration](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/duration/), in seconden.
- **Vertraging** correspondeert met [Timing.trigger_delay_time](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/trigger_delay_time/), in seconden.
- **Herhalen** correspondeert met [Timing.repeat_count](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_until_next_click/) of [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Terugspoelen wanneer afgespeeld** correspondeert met [Timing.rewind](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/rewind/).

Dit zelfstandige voorbeeld voegt een effect toe, wijzigt de timing via het object dat wordt geretourneerd door [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/), en slaat het resultaat op. Het behouden van de geretourneerde [Effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/)‑referentie voorkomt een onnodige verzameling‑index.

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

Gebruik één herhaalmodus doelbewust. Het combineren van een herhaal‑aantal met een “until”‑vlag kan verwarrende resultaten opleveren in verschillende viewers. Wanneer je herhaal‑modi wijzigt, stel dan eerst [Timing.repeat_until_next_click](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_until_next_click/) en [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) in voordat je [Timing.repeat_count](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_count/) aanpast, omdat het instellen van een van beide vlaggen tevens de actieve herhaalmodus wijzigt.

## **Animatie‑geluiden toevoegen en extraheren**

Een animatie‑effect kan een ingesloten audio‑bestand refereren via [Effect.sound](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/sound/). [Effect.stop_previous_sound](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/stop_previous_sound/) geeft een effect de opdracht om audio die door een eerder effect gestart is, te stoppen.

### **Een geluid aan een effect toevoegen**

Het volgende voorbeeld verwacht een lokaal audiobestand genaamd `animation-sound.wav`. Het maakt twee effecten, embeddit dat bestand als het geluid voor het eerste effect en configureert het tweede effect om het geluid te stoppen. Het gebruikt de objecten die worden geretourneerd door [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/), zodat geen reeks‑index nodig is.

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

### **Ingesloten effectgeluiden extraheren**

Het volgende voorbeeld verwacht een lokale presentatie genaamd `presentation-with-animation-sounds.pptx`. Het doorzoekt zowel de hoofd‑ als interactieve reeksen en schrijft elk ingesloten effectgeluid weg naar de map `extracted-animation-sounds`. De extensie wordt gekozen op basis van het audio‑MIME‑type dat wordt blootgesteld door [Audio.content_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audio/content_type/).

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

Voor grote audio‑objecten, gebruik [Audio.get_stream](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audio/get_stream/) en kopieer de stream naar een bestand in plaats van het hele object in een byte‑array te laden.

## **Gedrag na animatie instellen**

De optie **After animation** bepaalt wat er met een figuur gebeurt nadat het effect is afgerond.

![PowerPoint Effect Options‑dialoog met After‑animation‑instellingen](shape-after-animation.png)

De enumeratie [AfterAnimationType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/afteranimationtype/) ondersteunt het ongewijzigd laten van de figuur, het wijzigen van de kleur, het verbergen na de animatie, of het verbergen bij de volgende klik. Wanneer het type [AfterAnimationType.COLOR](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/afteranimationtype/) is, stel dan ook [Effect.after_animation_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/after_animation_color/) in.

Dit zelfstandige voorbeeld maakt een effect, stelt het gedrag na de animatie in via het geretourneerde effect‑object, en slaat het resultaat op.

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

- [TextAnimation.build_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/textanimation/build_type/) bepaalt of alinea’s samen of per alinea‑niveau verschijnen.
- [Effect.animate_text_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/animate_text_type/) bepaalt of tekst in één keer, per woord of per letter verschijnt. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/delay_between_text_parts/) stelt de vertraging tussen woorden of letters in. Een positieve waarde is een percentage van de effect‑duur; een negatieve waarde is een vertraging in seconden.

Het volgende zelfstandige voorbeeld animeert de woorden in een tekstvak. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/buildtype/) schakelt het opbouwen per alinea uit zodat de woordinstelling op het volledige tekstkader van toepassing is.

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

Om een tekstvak per alinea op te bouwen, stel je [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/buildtype/) (of een ander alinea‑niveau) in. Om een enkele alinea met een eigen effect te targeten, gebruik je de overload van [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/) die een [IParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iparagraph/) accepteert. Zie [Geanimeerde tekst](/slides/nl/python-net/animated-text/) voor voorbeelden op alinea‑niveau.

## **Export‑ en compatibiliteits­opmerkingen**

- Opslaan naar PPT of PPTX behoudt het animatiemodel, maar de uiteindelijke weergave wordt bepaald door de presentatiesoftware.
- PDF en statische afbeeldingen spelen geen animaties af. Gebruik [HTML5‑export](/slides/nl/python-net/export-to-html5/), een geanimeerde GIF of [video‑conversie](/slides/nl/python-net/convert-powerpoint-to-video/) wanneer de output beweging moet tonen.
- Voor HTML5, schakel [Html5Options.animate_shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/html5options/animate_shapes/) in en, indien nodig, [Html5Options.animate_transitions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/html5options/animate_transitions/).
- Video‑rendering ondersteunt veel veelvoorkomende entree‑, nadruk‑, exit‑ en motion‑path‑effecten, maar niet elk PowerPoint‑effect wordt ondersteund. Controleer de huidige [ondersteunde animaties en effecten](/slides/nl/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) en test kritieke presentaties met jouw doel‑Aspose.Slides‑versie.
- Geavanceerde aangepaste effecten en effecten geïmporteerd uit andere presentaties kunnen in het bestand behouden blijven maar anders worden gerenderd in PowerPoint, HTML5 of video. Valideer het geëxporteerde resultaat in plaats van alleen op de effectnaam te vertrouwen.

## **FAQ**

**Waarom verschijnt een animatie wel in PowerPoint maar niet in een PDF?**

PDF is een statisch formaat, dus animaties en dia‑overgangen worden niet afgespeeld. Exporteer naar HTML5, een geanimeerde GIF of video wanneer beweging bewaard moet blijven.

**Waarom wordt een effect anders afgespeeld in een video?**

Video‑export rendert animaties in plaats van het oorspronkelijke PowerPoint‑gedrag op te slaan. Sommige geavanceerde effecten worden niet ondersteund of benaderd. Bekijk de tabel met ondersteunde effecten en test de daadwerkelijke presentatie voordat je deze in productie neemt.

**Verandert het naar voren of naar achteren verplaatsen van een figuur de animatievolgorde?**

Nee. De Z‑order van een figuur bepaalt de overlapping, terwijl de volgorde van reeksen en triggers de animatie‑weergave regelen. Wijzig de tijdlijn als je een andere afspeelvolgorde nodig hebt.