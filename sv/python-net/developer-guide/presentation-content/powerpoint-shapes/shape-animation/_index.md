---
title: Applicera formanimationer i presentationer med Python
linktitle: Formanimation
type: docs
weight: 60
url: /sv/python-net/shape-animation/
keywords:
- form
- animation
- effekt
- animerad form
- animerad text
- lägg till animation
- hämta animation
- extrahera animation
- lägg till effekt
- hämta effekt
- extrahera effekt
- effektljud
- applicera animation
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du lägger till, granskar och anpassar formanimationer, timing, ljud, efter-animationsbeteende och animerad text med Aspose.Slides för Python via .NET."
---
## **Översikt**

Aspose.Slides för Python via .NET representerar bildanimationer som effekter i en bildtidslinje. En effekt har en målform, en animationstyp och -undertyp, en trigger, tidsinställningar och valfria egenskaper såsom ljud eller beteende efter animationen.

Tidslinjen innehåller två typer av sekvenser:

- Den **huvudsekvensen** spelas upp när bilden avancerar.
- En **interaktiv sekvens** startar när dess triggerform klickas.

Eftersom textrutor, bilder, diagram, tabeller och andra bildobjekt implementerar [IShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ishape/), använder du samma [Sequence.add_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/sequence/add_effect/) metod för de flesta bildinnehåll. De tillgängliga effekterna listas i uppräkningen [EffectType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effecttype/).

## **Lägg till formanimationer**

För att lägga till en animation, hämta bildens huvudsekvens och anropa [Sequence.add_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/sequence/add_effect/) med målformen, effekttypen, undertypen och triggern. För en effekt som startar när en annan form klickas, skapa en interaktiv sekvens vars trigger är den andra formen.

Följande exempel skapar båda typerna av animation och sparar resultatet till `shape-animations.pptx`.

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

Triggern styr när en effekt startar:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effecttriggertype/) väntar på ett klick i huvudsekvensen, eller på ett klick på triggerformen i en interaktiv sekvens.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effecttriggertype/) startar tillsammans med föregående effekt.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effecttriggertype/) startar när föregående effekt avslutas.

För att animera en bild, ett diagram eller en annan formtyp, skicka det objektet till [Sequence.add_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/sequence/add_effect/) istället för `target_shape`. För diagramspecifika grupperingsalternativ, se [Animated Charts](/slides/sv/python-net/animated-charts/).

## **Läs formanimationer**

Använd [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) när du känner till målformen. För att inspektera varje effekt, iterera genom huvudsekvensen och varje interaktiv sekvens. Iteration undviker att anta att en sekvens innehåller en effekt på index `0`.

Följande exempel skapar en form med huvudsekvens- och interaktiva effekter, hämtar de effekter som riktar sig mot formen, och itererar sedan igenom varje sekvens på bilden.

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

Om du bara behöver effekterna för en form, identifiera först formen efter namn, platshållartyp eller en annan stabil egenskap; anropa sedan [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). Anta inte att formen på index `0` alltid är det avsedda objektet.

## **Arbeta med ärvda platshållareffekter**

En platshållare på en normal bild kan ärva animationsegenskaper från motsvarande platshållare på dess layoutbild och mastern. [Shape.get_base_placeholder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_base_placeholder/) returnerar den överordnade platshållaren, eller `None` när ingen förälder finns.

I den följande exempelpresentationen har footern **Random Bars** på den normala bilden, **Split** på layoutbilden och **Fly In** på masterbilden.

![Footer-animeringseffekt på den normala bilden](slide-shape-animation.png)

![Footer-platshållaranimeringseffekt på layoutbilden](layout-shape-animation.png)

![Footer-platshållaranimeringseffekt på masterbilden](master-shape-animation.png)

Nästa exempel bygger själva platshållarhierarkin. Det lägger till effekter på en master-platshållare, en layout-platshållare och motsvarande platshållare på en normal bild. Varje anrop till [Shape.get_base_placeholder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_base_placeholder/) kontrolleras innan den returnerade formen används.

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

## **Ändra animationstiming**

PowerPoint‑dialogen **Timing** motsvarar egenskaperna i [Timing](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/).

![PowerPoint Timing‑dialog för en animationseffekt](shape-animation.png)

- **Start** motsvarar [Timing.trigger_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/trigger_type/).
- **Duration** motsvarar [Timing.duration](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/duration/), i sekunder.
- **Delay** motsvarar [Timing.trigger_delay_time](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/trigger_delay_time/), i sekunder.
- **Repeat** motsvarar [Timing.repeat_count](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/repeat_until_next_click/), eller [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Rewind when done playing** motsvarar [Timing.rewind](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/rewind/).

Detta fristående exempel lägger till en effekt, ändrar dess timing via objektet som returneras av [Sequence.add_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/sequence/add_effect/), och sparar resultatet. Att behålla den returnerade [Effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effect/)‑referensen undviker ett onödigt samlingsindex.

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

Använd ett repetitionsläge med avsikt. Att kombinera ett repetitionsantal med en ”until”-flagga kan ge förvirrande resultat i olika visare. När du ändrar repetitionslägen, sätt [Timing.repeat_until_next_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/repeat_until_next_click/) och [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) innan [Timing.repeat_count](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/repeat_count/), eftersom att sätta någon av flaggorna också ändrar det aktiva repetitionsläget.

## **Lägg till och extrahera animationsljud**

En animationseffekt kan referera till inbäddat ljud via [Effect.sound](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effect/sound/). [Effect.stop_previous_sound](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effect/stop_previous_sound/) instruerar en effekt att stoppa ljud som startats av en tidigare effekt.

### **Lägg till ett ljud till en effekt**

Följande exempel förväntar sig en lokal ljudfil med namn `animation-sound.wav`. Det skapar två effekter, bäddar in den filen som ljud för den första effekten, och konfigurerar den andra effekten att stoppa ljudet. Det använder objekten som returneras av [Sequence.add_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/sequence/add_effect/), så inget sekvensindex behövs.

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

### **Extrahera inbäddade effektljud**

Följande exempel förväntar sig en lokal presentation med namnet `presentation-with-animation-sounds.pptx`. Det skannar både huvud- och interaktiva sekvenser och skriver varje inbäddat effektljud till katalogen `extracted-animation-sounds`. Filändelsen väljs utifrån den ljud‑MIME‑typ som exponeras av [Audio.content_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audio/content_type/).

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

För stora ljudobjekt, använd [Audio.get_stream](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audio/get_stream/) och kopiera strömmen till en fil i stället för att ladda hela objektet i en byte‑array.

## **Ange efter‑animationbeteende**

**After animation**‑alternativet styr vad som händer med en form efter att dess effekt avslutats.

![PowerPoint‑dialog för effektalternativ som visar After animation‑inställningar](shape-after-animation.png)

Uppräkningen [AfterAnimationType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/afteranimationtype/) stödjer att låta formen förbli oförändrad, ändra dess färg, dölja den efter animationen eller dölja den vid nästa klick. När typen är [AfterAnimationType.COLOR](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/afteranimationtype/), sätt även [Effect.after_animation_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effect/after_animation_color/).

Detta fristående exempel skapar en effekt, sätter dess efter‑animationbeteende via den returnerade effekt‑objektet, och sparar resultatet.

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

Att ändra typen från [AfterAnimationType.COLOR](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/afteranimationtype/) rensar inställningen för efter‑animationens färg.

## **Animera text**

Textanimation har två relaterade kontroller:

- [TextAnimation.build_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/textanimation/build_type/) styr om stycken visas tillsammans eller på stycknivå.
- [Effect.animate_text_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effect/animate_text_type/) styr om text visas på en gång, per ord eller per bokstav. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effect/delay_between_text_parts/) anger fördröjningen mellan ord eller bokstäver. Ett positivt värde är en procent av effektens varaktighet; ett negativt värde är en fördröjning i sekunder.

Följande fristående exempel animera orden i en textruta. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/buildtype/) inaktiverar uppbyggnad stycke för stycke så att ordinställningen gäller hela textrutan.

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

För att bygga en textruta stycke för stycke, sätt [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/buildtype/) (eller en annan stycknivå). För att rikta in ett enskilt stycke med sin egen effekt, använd överbelastningen av [Sequence.add_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/sequence/add_effect/) som accepterar ett [IParagraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iparagraph/). Se [Animated Text](/slides/sv/python-net/animated-text/) för exempel på stycknivå.

## **Export‑ och kompatibilitetsanteckningar**

- Att spara till PPT eller PPTX bevarar animationsmodellen, men den slutgiltiga uppspelningen styrs av presentationsvisaren.
- PDF och statiska bilder spelar inte upp animationer. Använd [HTML5 export](/slides/sv/python-net/export-to-html5/), animerad GIF eller [video conversion](/slides/sv/python-net/convert-powerpoint-to-video/) när utdata måste visa rörelse.
- För HTML5, aktivera [Html5Options.animate_shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/html5options/animate_shapes/) och, vid behov, [Html5Options.animate_transitions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/html5options/animate_transitions/).
- Videorendering stöder många vanliga entré‑, betoning‑, avslutnings‑ och rörelsespårseffekter, men inte alla PowerPoint‑effekter stöds. Kontrollera de aktuella [supported animations and effects](/slides/sv/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) och testa kritiska presentationer med din mål‑Aspose.Slides‑version.
- Avancerade anpassade effekter och effekter importerade från andra presentationsformat kan bevaras i filen men renderas olika i PowerPoint, HTML5 eller video. Validera det exporterade resultatet istället för att enbart förlita dig på effektens namn.

## **FAQ**

**Varför visas en animation i PowerPoint men inte i en PDF?**

PDF är ett statiskt format, så animationer och bildövergångar spelas inte upp. Exportera till HTML5, animerad GIF eller video när rörelse måste bevaras.

**Varför spelas en effekt annorlunda i en video?**

Videoexport renderar animationer istället för att lagra det ursprungliga PowerPoint‑beteendet. Vissa avancerade effekter stöds inte eller approximeras. Granska tabellen med stödjade effekter och testa den faktiska presentationen innan produktionsanvändning.

**Påverkar det att flytta en form framåt eller bakåt dess animationsordning?**

Nej. Formens z‑ordning styr överlappning, medan sekvensordning och trigger styr animationsuppspelning. Ändra tidslinjen om du behöver en annan uppspelningsordning.