---
title: Tillämpa formanimationer i presentationer med Python via Java
linktitle: Formanimation
type: docs
weight: 60
url: /sv/python-java/shape-animation/
keywords:
- form
- animation
- effekt
- animerad form
- animerad text
- lägga till animation
- hämta animation
- extrahera animation
- lägga till effekt
- hämta effekt
- extrahera effekt
- effektsound
- tillämpa animation
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till, granskar och anpassar formanimationer, timing, ljud, efter‑animationsbeteende och animerad text med Aspose.Slides för Python via Java."
---
## **Översikt**

Aspose.Slides for Python via Java representerar bildanimationer som effekter i en bildtidslinje. En effekt har ett målobjekt, en animationstyp och undertyp, en trigger, tidsinställningar samt valfria egenskaper såsom ljud eller efter‑animationsbeteende.

Tidslinjen innehåller två typer av sekvenser:

- Den **huvudsekvensen** spelas när bilden avancerar.
- En **interaktiv sekvens** startar när dess trigger‑form klickas.

Eftersom textrutor, bilder, diagram, tabeller och andra bildobjekt härstammar från [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/), använder du samma [Sequence.addEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/#addEffect) metod för det mesta av bildinnehållet. De tillgängliga effekterna listas i klassen [EffectType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effecttype/).

## **Lägg till formanimationer**

För att lägga till en animation, hämta bildens huvudsekvens och anropa [Sequence.addEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/#addEffect) med målformen, effekt‑typ, undertyp och trigger. För en effekt som startar när en annan form klickas, skapa en interaktiv sekvens vars trigger är den andra formen.

Följande exempel skapar båda typerna av animation och sparar resultatet till `shape-animations.pptx`.

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

Triggern styr när en effekt startar:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effecttriggertype/#OnClick) väntar på ett klick i huvudsekvensen, eller på ett klick på trigger‑formen i en interaktiv sekvens.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effecttriggertype/#WithPrevious) startar med föregående effekt.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effecttriggertype/#AfterPrevious) startar när föregående effekt slutar.

För att animera en bild, ett diagram eller en annan formtyp, skicka det objektet till [Sequence.addEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/#addEffect) istället för `target_shape`. För diagramspecifika grupperingsalternativ, se [Animera diagram](/slides/sv/python-java/animated-charts/).

## **Läs formanimationer**

Använd [Sequence.getEffectsByShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/#getEffectsByShape) när du känner till målformen. För att inspektera varje effekt, enumerera huvudsekvensen och varje interaktiv sekvens. Enumerering undviker antagandet att en sekvens innehåller en effekt på index `0`.

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

Om du bara behöver effekterna för en form, identifiera först formen efter namn, platshållartyp eller en annan stabil egenskap; anropa sedan [Sequence.getEffectsByShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/#getEffectsByShape). Anta inte att [ShapeCollection.get_Item](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#get_Item) på index `0` alltid är det avsedda objektet.

## **Arbeta med ärvda platshållareffekter**

En platshållare på en normal bild kan ärva animationsbeteende från motsvarande platshållare på dess layout‑bild och mastern. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getBasePlaceholder) returnerar den överordnade platshållaren, eller `None` när ingen förälder finns.

I den följande exempelpresentationen har sidfoten **Random Bars** på den vanliga bilden, **Split** på layout‑bilden och **Fly In** på mastern.

![Fotanimationseffekt på den vanliga bilden](slide-shape-animation.png)
![Fotplatshållareffekt på layout‑bilden](layout-shape-animation.png)
![Fotplatshållareffekt på mastern](master-shape-animation.png)

Nästa exempel använder en platshållar‑hierarki från en ny presentation. Det lägger till effekter på en master‑platshållare, en layout‑platshållare och motsvarande platshållare på en normal bild. Varje anrop till [Shape.getBasePlaceholder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getBasePlaceholder) kontrolleras innan den returnerade formen används.

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

## **Ändra animationstiming**

PowerPoint‑dialogen **Timing** motsvarar egenskaperna i [Timing](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/).

![PowerPoint Timing‑dialog för en animationseffekt](shape-animation.png)

- **Start** mappar till [Timing.getTriggerType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getTriggerType).
- **Varaktighet** mappar till [Timing.getDuration](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getDuration), i sekunder.
- **Fördröjning** mappar till [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getTriggerDelayTime), i sekunder.
- **Upprepning** mappar till [Timing.getRepeatCount](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getRepeatUntilNextClick) eller [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Spola tillbaka när uppspelning är klar** mappar till [Timing.getRewind](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getRewind).

Detta fristående exempel lägger till en effekt, ändrar dess timing via objektet som returneras av [Sequence.addEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/#addEffect), och sparar resultatet. Att behålla den returnerade [Effect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effect/)‑referensen undviker ett onödigt samlingsindex.

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

Använd ett upprepningsläge med avsikt. Att kombinera ett upprepningsantal med ett ”until”‑flagg kan ge förvirrande resultat i olika visare. När du ändrar upprepningslägen, sätt [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#setRepeatUntilNextClick) och [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) innan du anropar [Timing.setRepeatCount](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#setRepeatCount), eftersom inställning av något av flaggorna också ändrar det aktiva upprepningsläget.

## **Lägg till och extrahera animationsljud**

En animationseffekt kan referera till inbäddat ljud via [Effect.getSound](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effect/#setStopPreviousSound) talar om för en effekt att stoppa ljud som startats av en tidigare effekt.

### **Lägg till ett ljud till en effekt**

Följande exempel förutsätter en lokal ljudfil med namnet `animation-sound.wav`. Det skapar två effekter, bäddar in filen som ljud för den första effekten och konfigurerar den andra effekten att stoppa ljudet. Det använder objekten som returneras av [Sequence.addEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/#addEffect), så inget sekvensindex behövs.

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

### **Extrahera inbäddade effektljud**

Följande exempel förutsätter en lokal presentation med namnet `presentation-with-animation-sounds.pptx`. Det skannar både huvud‑ och interaktiva sekvenser och skriver varje inbäddat effektljud till katalogen `extracted-animation-sounds`. Filändelsen väljs utifrån ljud‑MIME‑typen som exponeras av [Audio.getContentType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audio/#getContentType).

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

För stora ljudobjekt, använd [Audio.getStream](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audio/#getStream) och kopiera strömmen till en fil istället för att ladda hela objektet i en byte‑array.

## **Ställ in efter‑animationsbeteende**

Alternativet **After animation** styr vad som händer med en form när dess effekt avslutas.

![PowerPoint Effektalternativdialog som visar efter‑animationsinställningar](shape-after-animation.png)

Klassen [AfterAnimationType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/afteranimationtype/) stödjer att låta formen vara oförändrad, ändra dess färg, dölja den efter animationen eller dölja den vid nästa klick. När typen är [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/python-java/aspose.slides/afteranimationtype/#Color), sätt även [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effect/#getAfterAnimationColor).

Detta fristående exempel skapar en effekt, sätter dess efter‑animationsbeteende via det returnerade effekt‑objektet, och sparar resultatet.

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

Att byta typ från [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/python-java/aspose.slides/afteranimationtype/#Color) rensar inställningen för efter‑animationsfärgen.

## **Animera text**

Textanimation har två relaterade kontroller:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textanimation/#getBuildType) styr om stycken visas tillsammans eller på styckesnivå.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effect/#getAnimateTextType) styr om text visas på en gång, ord för ord eller bokstav för bokstav. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effect/#getDelayBetweenTextParts) anger fördröjningen mellan ord eller bokstäver. Ett positivt värde är en procentandel av effektens varaktighet; ett negativt värde är en fördröjning i sekunder.

Följande fristående exempel animerar orden i en textruta. [BuildType.AsOneObject](https://reference.aspose.com/slides/sv/python-java/aspose.slides/buildtype/#AsOneObject) inaktiverar byggande stycke för stycke så att ordinställningen gäller för hela textramen.

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

För att bygga en textruta stycke för stycke, sätt [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/sv/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (eller en annan styckesnivå). För att rikta en enskild paragraf med egen effekt, använd överlagringen av [Sequence.addEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/#addEffect) som accepterar ett [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/). Se [Animera text](/slides/sv/python-java/animated-text/) för exempel på styckesnivå.

## **Export- och kompatibilitetsanteckningar**

- Att spara som PPT eller PPTX bevarar animationsmodellen, men den slutgiltiga uppspelningen styrs av presentationsvisaren.
- PDF och statiska bilder spelar inte upp animationer. Använd [HTML5‑export](/slides/sv/python-java/export-to-html5/), animerad GIF eller [videokonvertering](/slides/sv/python-java/convert-powerpoint-to-video/) när utdata måste visa rörelse.
- För HTML5, aktivera [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/html5options/#setAnimateShapes) och, vid behov, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/html5options/#setAnimateTransitions).
- Videorendering stöder många vanliga inträde-, betoning-, utgångs‑ och rörelsesök‑effekter, men inte varje PowerPoint‑effekt stöds. Kontrollera de aktuella [stödda animationerna och effekterna](/slides/sv/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) och testa kritiska presentationer med din mål‑Aspose.Slides‑version.
- Avancerade anpassade effekter och effekter importerade från andra presentationsformat kan bevaras i filen men renderas annorlunda i PowerPoint, HTML5 eller video. Validera det exporterade resultatet snarare än att enbart lita på effektens namn.

## **FAQ**

**Varför visas en animation i PowerPoint men inte i en PDF?**

PDF är ett statiskt format, så animationer och bildövergångar spelas inte upp. Exportera till HTML5, animerad GIF eller video när rörelse måste bevaras.

**Varför spelas en effekt annorlunda i en video?**

Video‑export renderar animationer istället för att lagra det ursprungliga PowerPoint‑beteendet. Vissa avancerade effekter stöds inte eller approximeras. Granska tabellen över stödda effekter och testa den faktiska presentationen innan produktionsanvändning.

**Ändrar flyttning av en form framåt eller bakåt dess animationsordning?**

Nej. Formens z‑ordning styr överlappning, medan sekvensordning och trigger styr animationsuppspelning. Ändra tidslinjen om du behöver en annan uppspelningsordning.