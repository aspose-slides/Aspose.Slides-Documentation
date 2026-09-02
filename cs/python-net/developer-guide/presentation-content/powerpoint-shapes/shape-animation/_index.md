---
title: Použití animací tvarů v prezentacích s Pythonem
linktitle: Animace tvaru
type: docs
weight: 60
url: /cs/python-net/shape-animation/
keywords:
- tvar
- animace
- efekt
- animovaný tvar
- animovaný text
- přidat animaci
- získat animaci
- extrahovat animaci
- přidat efekt
- získat efekt
- extrahovat efekt
- zvuk efektu
- aplikovat animaci
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak přidávat, kontrolovat a přizpůsobovat animace tvarů, načasování, zvuky, chování po animaci a animovaný text pomocí Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Aspose.Slides for Python via .NET představuje animace snímků jako efekty v časové ose snímku. Efekt má cílový tvar, typ a podtyp animace, spouštěč, nastavení načasování a volitelné vlastnosti, jako je zvuk nebo chování po animaci.

Časová osa obsahuje dva typy sekvencí:

- **Hlavní sekvence** se přehrává při postupu snímku.
- **Interaktivní sekvence** se spustí, když je kliknuto na její spouštěcí tvar.

Protože textová pole, obrázky, grafy, tabulky a další objekty snímku implementují [IShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ishape/), používáte stejnou metodu [Sequence.add_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/add_effect/) pro většinu obsahu snímku. Dostupné efekty jsou uvedeny v výčtu [EffectType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effecttype/) .

## **Přidání animací tvarů**

Pro přidání animace získáte hlavní sekvenci snímku a zavoláte [Sequence.add_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/add_effect/) s cílovým tvarem, typem efektu, podtypem a spouštěčem. Pro efekt, který se spustí po kliknutí na jiný tvar, vytvořte interaktivní sekvenci, jejímž spouštěčem je tento jiný tvar.

Následující příklad vytvoří oba typy animací a uloží výsledek do `shape-animations.pptx`.

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

Spouštěč určuje, kdy se efekt spustí:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effecttriggertype/) čeká na kliknutí v hlavní sekvenci nebo na kliknutí na spouštěcí tvar v interaktivní sekvenci.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effecttriggertype/) začíná současně s předchozím efektem.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effecttriggertype/) začíná po dokončení předchozího efektu.

Pro animaci obrázku, grafu nebo jiného typu tvaru předáte tento objekt metodě [Sequence.add_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/add_effect/) místo `target_shape`. Pro možnosti seskupování specifické pro grafy viz [Animated Charts](/slides/cs/python-net/animated-charts/).

## **Čtení animací tvarů**

Použijte [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) když znáte cílový tvar. Pro prohlédnutí každého efektu iterujte hlavní sekvenci a každou interaktivní sekvenci. Iterace zabraňuje předpokladu, že sekvence obsahuje efekt na indexu `0`.

Následující příklad vytvoří tvar s hlavními a interaktivními efekty, získá efekty zaměřené na tento tvar a poté iteruje přes všechny sekvence na snímku.

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

Pokud potřebujete efekty jen pro jeden tvar, nejprve tvar identifikujte podle názvu, typu placeholderu nebo jiné stabilní vlastnosti; pak zavolejte [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). Nepředpokládejte, že tvar na indexu `0` je vždy požadovaný objekt.

## **Práce s děděnými efekty placeholderů**

Placeholder na běžném snímku může dědit chování animace z odpovídajícího placeholderu na jeho rozložení a hlavním snímku. [Shape.get_base_placeholder](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_base_placeholder/) vrací tohoto nadřazeného placeholderu nebo `None`, pokud žádný nadřazený neexistuje.

V následující ukázkové prezentaci má zápatí **Random Bars** na běžném snímku, **Split** na snímku rozložení a **Fly In** na hlavním snímku.

![Animace patičky na běžném snímku](slide-shape-animation.png)

![Animace placeholderu patičky na snímku rozložení](layout-shape-animation.png)

![Animace placeholderu patičky na hlavním snímku](master-shape-animation.png)

Další příklad staví samotnou hierarchii placeholderů. Přidává efekty k hlavnímu placeholderu, placeholderu rozložení a odpovídajícímu placeholderu na běžném snímku. Každé volání [Shape.get_base_placeholder](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_base_placeholder/) je před použitím vráceného tvaru zkontrolováno.

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

## **Změna načasování animace**

Dialog **Timing** v PowerPointu mapuje na vlastnosti [Timing](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/).

![Dialog načasování PowerPointu pro animaci efektu](shape-animation.png)

- **Start** mapuje na [Timing.trigger_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/trigger_type/).
- **Duration** mapuje na [Timing.duration](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/duration/), v sekundách.
- **Delay** mapuje na [Timing.trigger_delay_time](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/trigger_delay_time/), v sekundách.
- **Repeat** mapuje na [Timing.repeat_count](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/repeat_until_next_click/) nebo [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Rewind when done playing** mapuje na [Timing.rewind](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/rewind/).

Tento samostatný příklad přidá efekt, změní jeho načasování pomocí objektu vráceného metodou [Sequence.add_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/add_effect/) a výsledek uloží. Uložení odkazu na vrácený [Effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effect/) zabraňuje zbytečnému použití indexu kolekce.

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

Používejte jeden režim opakování záměrně. Kombinace počtu opakování s příznakem „until“ může v různých prohlížečích vést k nejasným výsledkům. Při změně režimů opakování nastavte [Timing.repeat_until_next_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/repeat_until_next_click/) a [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) před [Timing.repeat_count](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/repeat_count/), protože nastavení některého z příznaků také mění aktivní režim opakování.

## **Přidání a extrahování zvuků animace**

Animovaný efekt může odkazovat na vložený audio soubor přes [Effect.sound](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effect/sound/). [Effect.stop_previous_sound](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effect/stop_previous_sound/) říká efektu, aby zastavil zvuk zahájený dříve.

### **Přidání zvuku k efektu**

Následující příklad očekává lokální audio soubor pojmenovaný `animation-sound.wav`. Vytvoří dva efekty, vloží tento soubor jako zvuk pro první efekt a nastaví druhý efekt tak, aby zvuk zastavil. Používá objekty vrácené metodou [Sequence.add_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/add_effect/), takže není potřeba index sekvence.

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

### **Extrahování vložených zvuků efektu**

Následující příklad očekává lokální prezentaci pojmenovanou `presentation-with-animation-sounds.pptx`. Prohledá hlavní i interaktivní sekvence a zapíše každý vložený zvuk efektu do adresáře `extracted-animation-sounds`. Přípona je vybrána podle MIME typu audia vystaveného [Audio.content_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audio/content_type/).

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

Pro velké audio objekty použijte [Audio.get_stream](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audio/get_stream/) a zkopírujte proud do souboru místo načtení celého objektu do pole bajtů.

## **Nastavení chování po animaci**

Možnost **After animation** určuje, co se stane s tvarem po dokončení jeho efektu.

![Dialog možností efektu PowerPointu zobrazující nastavení po animaci](shape-after-animation.png)

Výčet [AfterAnimationType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/afteranimationtype/) podporuje ponechání tvaru beze změny, změnu jeho barvy, skrytí po animaci nebo skrytí při dalším kliknutí. Když je typ [AfterAnimationType.COLOR](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/afteranimationtype/), nastavte také [Effect.after_animation_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effect/after_animation_color/).

Tento samostatný příklad vytvoří efekt, nastaví jeho chování po animaci pomocí vráceného objektu efektu a výsledek uloží.

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

Změna typu od [AfterAnimationType.COLOR](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/afteranimationtype/) vymaže nastavení barvy po animaci.

## **Animace textu**

Animace textu má dvě související nastavení:

- [TextAnimation.build_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/textanimation/build_type/) řídí, zda se odstavce zobrazují najednou nebo po odstavcích.
- [Effect.animate_text_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effect/animate_text_type/) určuje, zda se text zobrazí najednou, po slovech nebo po znacích. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effect/delay_between_text_parts/) nastavuje prodlevu mezi slovy nebo znaky. Kladná hodnota představuje procento trvání efektu; záporná hodnota je prodleva v sekundách.

Následující samostatný příklad animuje slova v textovém poli. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/buildtype/) vypne postupné budování odstavců, takže nastavení pro slova platí pro celý textový rámec.

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

Pro budování textového pole po odstavcích nastavte [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/buildtype/) (nebo jinou úroveň odstavce). Pro cílení na jediný odstavec s vlastním efektem použijte přetíženou verzi [Sequence.add_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/add_effect/), která přijímá [IParagraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iparagraph/). Viz [Animated Text](/slides/cs/python-net/animated-text/) pro příklady na úrovni odstavce.

## **Export a poznámky o kompatibilitě**

- Uložení do PPT nebo PPTX zachová model animací, ale finální přehrávání řídí prohlížeč prezentace.
- PDF a statické obrázky animace nepřehrávají. Použijte [HTML5 export](/slides/cs/python-net/export-to-html5/), animovaný GIF nebo [konverzi videa](/slides/cs/python-net/convert-powerpoint-to-video/), pokud výstup musí ukazovat pohyb.
- Pro HTML5 povolte [Html5Options.animate_shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/html5options/animate_shapes/) a podle potřeby [Html5Options.animate_transitions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/html5options/animate_transitions/).
- Videa podporují mnoho běžných vstupních, zdůrazňovacích, ukončovacích a pohybových efektů, ale ne každý PowerPoint efekt je podporován. Zkontrolujte aktuální [supported animations and effects](/slides/cs/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) a otestujte kritické prezentace s verzí Aspose.Slides, kterou používáte.
- Pokročilé vlastní efekty a efekty importované z jiných formátů prezentací mohou být v souboru zachovány, ale vykreslí se odlišně v PowerPointu, HTML5 nebo videu. Ověřte exportovaný výsledek místo spoléhaní se pouze na název efektu.

## **Často kladené otázky**

**Proč se animace zobrazí v PowerPointu, ale ne v PDF?**

PDF je statický formát, takže animace a přechody snímků se nepřehrávají. Exportujte do HTML5, animovaného GIFu nebo videa, pokud je třeba zachovat pohyb.

**Proč se efekt v videu přehrává jinak?**

Export videa rendruje animace namísto uložení původního chování PowerPointu. Některé pokročilé efekty nejsou podporovány nebo jsou aproximovány. Zkontrolujte tabulku podporovaných efektů a otestujte skutečnou prezentaci před produkčním nasazením.

**Změní přesunutí tvaru dopředu nebo dozadu jeho pořadí animace?**

Ne. Z‑order tvaru určuje překrývání, zatímco pořadí sekvence a spouštěče řídí přehrávání animace. Změňte časovou osu, pokud potřebujete jiný pořadí přehrávání.