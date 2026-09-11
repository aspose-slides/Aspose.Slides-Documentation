---
title: "Použít animace tvarů v prezentacích pomocí Pythonu přes Java"
linktitle: "Animace tvaru"
type: docs
weight: 60
url: /cs/python-java/shape-animation/
keywords:
- "tvar"
- "animace"
- "efekt"
- "animovaný tvar"
- "animovaný text"
- "přidat animaci"
- "získat animaci"
- "extrahovat animaci"
- "přidat efekt"
- "získat efekt"
- "extrahovat efekt"
- "zvuk efektu"
- "použít animaci"
- "PowerPoint"
- "prezentace"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Naučte se přidávat, prohlížet a přizpůsobovat animace tvarů, časování, zvuky, chování po animaci a animovaný text pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Aspose.Slides pro Python prostřednictvím Java představuje animace snímků jako efekty v časové ose snímku. Efekt má cílový tvar, typ a podtyp animace, spouštěč, nastavení časování a volitelné vlastnosti, jako je zvuk nebo chování po animaci.

Časová osa obsahuje dva druhy sekvencí:

- **Hlavní sekvence** se přehrává při postupu snímku.
- **Interaktivní sekvence** začíná, když se klikne na její spouštěcí tvar.

Protože textová pole, obrázky, grafy, tabulky a další objekty snímku jsou odvozeny od [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/), používáte stejnou metodu [Sequence.addEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/#addEffect) pro většinu obsahu snímku. Dostupné efekty jsou uvedeny ve třídě [EffectType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effecttype/).

## **Přidání animací tvarů**

Chcete-li přidat animaci, získejte hlavní sekvenci snímku a zavolejte [Sequence.addEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/#addEffect) s cílovým tvarem, typem efektu, podtypem a spouštěčem. Pro efekt, který začíná po kliknutí na jiný tvar, vytvořte interaktivní sekvenci, jejíž spouštěčem je tento jiný tvar.

Následující příklad vytvoří oba typy animací a uloží výsledek do souboru `shape-animations.pptx`.

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

Spouštěč určuje, kdy efekt začíná:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effecttriggertype/#OnClick) čeká na kliknutí v hlavní sekvenci nebo na kliknutí na spouštěcí tvar v interaktivní sekvenci.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effecttriggertype/#WithPrevious) začíná spolu s předchozím efektem.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effecttriggertype/#AfterPrevious) začíná po dokončení předchozího efektu.

Chcete-li animovat obrázek, graf nebo jiný typ tvaru, předávejte tento objekt metodě [Sequence.addEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/#addEffect), namísto `target_shape`. Pro možnosti seskupování specifické pro grafy viz [Animované grafy](/slides/cs/python-java/animated-charts/).

## **Čtení animací tvarů**

Použijte [Sequence.getEffectsByShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/#getEffectsByShape), když znáte cílový tvar. Chcete-li prozkoumat každý efekt, projděte hlavní sekvenci a všechny interaktivní sekvence. Enumerace zabraňuje předpokladu, že sekvence obsahuje efekt na indexu `0`.

Následující příklad vytvoří tvar s efekty v hlavní a interaktivní sekvenci, získá efekty, které cílí na tvar, a poté projde všechny sekvence na snímku.

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

Pokud potřebujete efekty pouze pro jeden tvar, nejprve identifikujte tvar podle názvu, typu zástupce nebo jiné stabilní vlastnosti; poté zavolejte [Sequence.getEffectsByShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/#getEffectsByShape). Nepředpokládejte, že [ShapeCollection.get_Item](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#get_Item) na indexu `0` je vždy požadovaný objekt.

## **Práce s děděnými efekty zástupců**

Zástupce na normálním snímku může zdědit chování animace z odpovídajícího zástupce na snímku rozvržení a hlavním snímku. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getBasePlaceholder) vrací tento nadřazený zástupce, nebo `None`, pokud žádný nadřazený neexistuje.

V následujícím příkladu prezentace má zápatí **Random Bars** na normálním snímku, **Split** na snímku rozvržení a **Fly In** na hlavním snímku.

![Efekt animace zápatí na normálním snímku](slide-shape-animation.png)

![Efekt animace zástupce zápatí na snímku rozvržení](layout-shape-animation.png)

![Efekt animace zástupce zápatí na hlavním snímku](master-shape-animation.png)

Následující příklad používá hierarchii zástupců z nové prezentace. Přidává efekty k hlavnímu zástupci, zástupci v rozvržení a odpovídajícímu zástupci na normálním snímku. Každé volání [Shape.getBasePlaceholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getBasePlaceholder) je před použitím vráceného tvaru zkontrolováno.

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

## **Změna časování animace**

Dialog PowerPoint **Timing** se mapuje na vlastnosti třídy [Timing](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/).

![Dialog PowerPoint Timing pro efekt animace](shape-animation.png)

- **Start** mapuje na [Timing.getTriggerType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getTriggerType).
- **Duration** mapuje na [Timing.getDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getDuration), v sekundách.
- **Delay** mapuje na [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getTriggerDelayTime), v sekundách.
- **Repeat** mapuje na [Timing.getRepeatCount](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getRepeatUntilNextClick), nebo [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** mapuje na [Timing.getRewind](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getRewind).

Tento samostatný příklad přidá efekt, změní jeho časování pomocí objektu vráceného metodou [Sequence.addEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/#addEffect), a uloží výsledek. Udržení reference na vrácený objekt [Effect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effect/) zabraňuje zbytečnému indexu v kolekci.

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

Úmyslně používejte jeden režim opakování. Kombinace počtu opakování s příznakem „until“ může v různých prohlížečích vést k matoucím výsledkům. Při změně režimů opakování nastavte [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#setRepeatUntilNextClick) a [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) před [Timing.setRepeatCount](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#setRepeatCount), protože nastavení některého z příznaků také mění aktivní režim opakování.

## **Přidání a extrahování zvuků animace**

Efekt animace může odkazovat na vložený zvuk pomocí [Effect.getSound](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effect/#setStopPreviousSound) říká efektu, aby zastavil zvuk spuštěný předchozím efektem.

### **Přidání zvuku k efektu**

Následující příklad očekává lokální audio soubor pojmenovaný `animation-sound.wav`. Vytvoří dva efekty, vloží tento soubor jako zvuk pro první efekt a nastaví druhý efekt tak, aby zvuk zastavil. Používá objekty vrácené metodou [Sequence.addEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/#addEffect), takže není potřeba index sekvence.

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

### **Extrahování vložených zvuků efektu**

Následující příklad očekává lokální prezentaci pojmenovanou `presentation-with-animation-sounds.pptx`. Prohledá hlavní i interaktivní sekvence a zapíše každý vložený zvuk efektu do adresáře `extracted-animation-sounds`. Přípona je vybrána podle audio MIME typu poskytovaného metodou [Audio.getContentType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audio/#getContentType).

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

Pro velké audio objekty použijte [Audio.getStream](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audio/#getStream) a zkopírujte stream do souboru místo načtení celého objektu do pole bajtů.

## **Nastavení chování po animaci**

Volba **After animation** určuje, co se stane s tvarem po dokončení jeho efektu.

![Dialog PowerPoint Effect Options zobrazující nastavení After animation](shape-after-animation.png)

Třída [AfterAnimationType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/afteranimationtype/) podporuje ponechání tvaru beze změny, změnu jeho barvy, skrytí po animaci nebo skrytí při dalším kliknutí. Když je typ [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/python-java/aspose.slides/afteranimationtype/#Color), nastavte také [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effect/#getAfterAnimationColor).

Tento samostatný příklad vytvoří efekt, nastaví jeho chování po animaci pomocí vráceného objektu efektu a uloží výsledek.

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

Změna typu od [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/python-java/aspose.slides/afteranimationtype/#Color) vymaže nastavení barvy po animaci.

## **Animace textu**

Animace textu má dva související ovladače:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textanimation/#getBuildType) určuje, zda se odstavce zobrazí najednou nebo po úrovních odstavců.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effect/#getAnimateTextType) určuje, zda se text zobrazí najednou, po slovech nebo po písmenech. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effect/#getDelayBetweenTextParts) nastavuje zpoždění mezi slovy nebo písmeny. Kladná hodnota je procento trvání efektu; záporná hodnota je zpoždění v sekundách.

Následující samostatný příklad animuje slova v textovém poli. [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/python-java/aspose.slides/buildtype/#AsOneObject) zakáže sestavování po odstavcích, takže nastavení slov se použije na celý textový rámec.

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

Chcete-li sestavit textové pole po odstavcích, nastavte [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/cs/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (nebo jinou úroveň odstavce). Pro cílení jediného odstavce s vlastním efektem použijte přetížení [Sequence.addEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/#addEffect), které přijímá [Paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/). Viz [Animovaný text](/slides/cs/python-java/animated-text/) pro příklady na úrovni odstavce.

## **Export a poznámky o kompatibilitě**

- Uložení do PPT nebo PPTX zachovává animační model, ale finální přehrávání řídí prohlížeč prezentace.
- PDF a statické obrázky nepřehrávají animace. Použijte [HTML5 export](/slides/cs/python-java/export-to-html5/), animovaný GIF nebo [video conversion](/slides/cs/python-java/convert-powerpoint-to-video/), když výstup musí ukazovat pohyb.
- Pro HTML5 povolte [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/html5options/#setAnimateShapes) a v případě potřeby [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/html5options/#setAnimateTransitions).
- Rendering videa podporuje mnoho běžných efektů vstupu, důrazu, odchodu a pohybových drah, ale ne každý PowerPoint efekt je podporován. Zkontrolujte aktuální [podporované animace a efekty](/slides/cs/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) a otestujte kritické prezentace s vaší cílovou verzí Aspose.Slides.
- Pokročilé vlastní efekty a efekty importované z jiných formátů prezentací mohou být v souboru zachovány, ale renderují se odlišně v PowerPointu, HTML5 nebo videu. Ověřte exportovaný výsledek místo spoléhaní se pouze na název efektu.

## **FAQ**

**Proč se animace zobrazí v PowerPointu, ale ne v PDF?**

PDF je statický formát, takže animace a přechody snímků se nepřehrávají. Exportujte do HTML5, animovaného GIFu nebo videa, když je nutný pohyb.

**Proč se efekt přehrává odlišně ve videu?**

Export do videa vykresluje animace místo ukládání původního chování PowerPointu. Některé pokročilé efekty nejsou podporovány nebo jsou aproximovány. Prostudujte tabulku podporovaných efektů a otestujte skutečnou prezentaci před použitím ve výrobě.

**Změní posunutí tvaru dopředu nebo dozadu pořadí jeho animací?**

Ne. Z‑order tvaru řídí překrývání, zatímco pořadí sekvence a spouštěče řídí přehrávání animací. Změňte časovou osu, pokud potřebujete jiný pořádek přehrávání.