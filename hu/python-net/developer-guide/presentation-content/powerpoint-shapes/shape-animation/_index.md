---
title: Alakzatanimációk alkalmazása prezentációkban Python segítségével
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/python-net/shape-animation/
keywords:
- alakzat
- animáció
- effektus
- animált alakzat
- animált szöveg
- animáció hozzáadása
- animáció lekérése
- animáció kinyerése
- effektus hozzáadása
- effektus lekérése
- effektus kinyerése
- effektus hang
- animáció alkalmazása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet hozzáadni, ellenőrizni és testreszabni az alakzatanimációkat, az időzítést, a hangokat, az animáció utáni viselkedést és az animált szöveget az Aspose.Slides for Python via .NET használatával."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET a diavetítés animációkat effektusokként ábrázolja a dia idővonalán. Egy effektusnak van célobjektuma, animáció típusa és altípusa, egy trigger, időzítési beállítások, valamint opcionális tulajdonságok, például hang vagy az animáció utáni viselkedés.

Az idővonal kétféle szekvenciát tartalmaz:

- A **fő szekvencia** lejátszódik, amikor a dia előrehalad.
- Egy **interaktív szekvencia** akkor indul, amikor a trigger alakzatára kattintanak.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diaobjektumok a [IShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishape/) interfészt valósítják meg, a legtöbb diaelemnél ugyanazt a [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) metódust használja. A rendelkezésre álló effektusok a [EffectType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effecttype/) felsorolásban vannak felsorolva.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához szerezze be a dia fő szekvenciáját, és hívja meg a [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) metódust a cél alakzattal, effektustípussal, altípussal és triggerrel. Olyan effektus esetén, amely egy másik alakzatra kattintáskor indul, hozzon létre egy interaktív szekvenciát, amelynek triggerje az a másik alakzat.

Az alábbi példa mindkét típusú animációt létrehozza, és az eredményt a `shape-animations.pptx` fájlba menti.

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

A trigger határozza meg, mikor kezdődik egy effektus:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effecttriggertype/) a fő szekvenciában kattintásra, vagy egy interaktív szekvenciában a trigger alakzatra vár.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effecttriggertype/) a megelőző effektussal együtt indul.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effecttriggertype/) amikor a megelőző effektus befejeződik.

Kép, diagram vagy más alakzat animálásához adja át azt az objektumot a [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) hívásnak a `target_shape` helyett. A diagramokhoz kapcsolódó csoportosítási beállításokért lásd a [Animated Charts](/slides/hu/python-net/animated-charts/) oldalt.

## **Alakzatanimációk olvasása**

Használja a [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) metódust, ha ismeri a cél alakzatot. Minden effektus vizsgálatához iteráljon a fő szekvencián és az összes interaktív szekvencián. Az iteráció elkerüli azt a feltételezést, hogy egy szekvencia 0‑ás indexű elemként tartalmaz effektust.

Az alábbi példa létrehoz egy alakzatot fő‑ és interaktív effektusokkal, lekéri az alakzatot célzó effektusokat, majd végigiterál a dián lévő minden szekvencián.

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

Ha csak egy alakzathoz szükséges az effektuslista, először azonosítsa az alakzatot név, helyőrző típus vagy más stabil tulajdonság alapján; ezután hívja meg a [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) metódust. Ne feltételezze, hogy a 0‑ás indexű alakzat mindig a kívánt objektum.

## **Örökölt helyőrző effektusok kezelése**

Egy normál dián található helyőrző örökölheti az animációs viselkedést a hozzá tartozó helyőrzőből az elrendezési dián és a mester dián. A [Shape.get_base_placeholder](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_base_placeholder/) visszaadja azt a szülőhelyőrzőt, vagy `None`‑t, ha nincs szülő.

Az alábbi példaprezentációban a lábléc **Random Bars** animációval rendelkezik a normál dián, **Split** animációval az elrendezési dián, és **Fly In** animációval a mester dián.

![Lábléc animációs effektus a normál dián](slide-shape-animation.png)

![Lábléc helyőrző animációs effektus az elrendezési dián](layout-shape-animation.png)

![Lábléc helyőrző animációs effektus a mester dián](master-shape-animation.png)

A következő példa magát a helyőrző hierarchiát építi fel. Effektusokat ad hozzá egy mester helyőrzőhöz, egy elrendezési helyőrzőhöz, és a megfelelő helyőrzőhöz a normál dián. Minden [Shape.get_base_placeholder](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_base_placeholder/) hívást ellenőriznek, mielőtt a visszakapott alakzatot felhasználnák.

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

## **Animáció időzítésének módosítása**

A PowerPoint **Timing** párbeszédablaka megfelel a [Timing](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/) tulajdonságainak.

![PowerPoint időzítési párbeszédablak egy animációs effektushoz](shape-animation.png)

- **Start** a [Timing.trigger_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/trigger_type/) megfelelőjére mutat.
- **Duration** a [Timing.duration](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/duration/) másodpercekben.
- **Delay** a [Timing.trigger_delay_time](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/trigger_delay_time/) másodpercekben.
- **Repeat** a [Timing.repeat_count](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_count/), a [Timing.repeat_until_next_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_until_next_click/) vagy a [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) szerint állítható.
- **Rewind when done playing** a [Timing.rewind](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/rewind/) megfelelőjére mutat.

Ez a független példa hozzáad egy effektust, módosítja annak időzítését a [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) által visszaadott objektumon keresztül, majd elmenti az eredményt. A visszakapott [Effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/) hivatkozás megtartása megakadályoz egy felesleges gyűjtési indexet.

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

Használjon egy ismétlési módot szándékosan. Az ismétlési számláló és egy „until” jelző kombinálása zavaró eredményeket produkálhat különböző lejátszókban. Ismétlési mód módosításakor állítsa be a [Timing.repeat_until_next_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_until_next_click/) és a [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) értékeket, mielőtt a [Timing.repeat_count](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_count/) beállításra kerülne, mivel bármely jelző beállítása megváltoztatja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus hivatkozhat beágyazott hangra a [Effect.sound](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/sound/) segítségével. A [Effect.stop_previous_sound](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/stop_previous_sound/) azt mondja az effektusnak, hogy állítsa le a korábbi effektus által indított hangot.

### **Hang hozzáadása egy effektushoz**

Az alábbi példa egy helyi `animation-sound.wav` nevű hangfájlt vár. Két effektust hoz létre, az elsőt beágyazza a hangfájlként, a másodikat úgy konfigurálja, hogy leállítsa a hangot. A [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) által visszaadott objektumokat használja, így nem szükséges szekvencia indexet megadni.

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

### **Beágyazott effektus hangok kinyerése**

Az alábbi példa egy helyi `presentation-with-animation-sounds.pptx` nevű prezentációt vár. Mind a fő, mind az interaktív szekvenciákat bejárja, és minden beágyazott effektus hangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztés a [Audio.content_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audio/content_type/) által visszaadott audio MIME‑típusból kerül kiválasztásra.

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

Nagy audio objektumok esetén használja a [Audio.get_stream](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audio/get_stream/) metódust, és másolja a streamet egy fájlba ahelyett, hogy az egész objektumot egy byte tömbbe töltené be.

## **Utóanimációs viselkedés beállítása**

A **After animation** opció azt határozza meg, mi történjen egy alakzattal, miután az effektus befejeződött.

![PowerPoint effektus beállítások párbeszédablak az After animation beállításokkal](shape-after-animation.png)

Az [AfterAnimationType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/afteranimationtype/) felsorolás támogatja az alakzat változatlan hagyását, színének megváltoztatását, elrejtését az animáció után, vagy elrejtését a következő kattintáskor. Amikor a típus a [AfterAnimationType.COLOR](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/afteranimationtype/), állítsa be a [Effect.after_animation_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/after_animation_color/)-t is.

Ez a független példa létrehoz egy effektust, beállítja annak utóanimációs viselkedését a visszakapott effektus objektumon keresztül, majd elmenti az eredményt.

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

A típus [AfterAnimationType.COLOR](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/afteranimationtype/)‑ról való eltávolítása törli az utóanimációs színbeállítást.

## **Szöveg animálása**

A szöveganimációnak két kapcsolódó vezérlése van:

- A [TextAnimation.build_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/textanimation/build_type/) határozza meg, hogy a bekezdések egyszerre vagy bekezdésenként jelenjenek meg.
- Az [Effect.animate_text_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/animate_text_type/) szabályozza, hogy a szöveg egyszerre, szó szerint vagy betűként jelenjen meg. A [Effect.delay_between_text_parts](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/delay_between_text_parts/) beállítja a szavak vagy betűk közti késleltetést. A pozitív érték a hatás időtartamának százaléka; a negatív érték másodpercekben megadott késleltetés.

Az alábbi független példa a szövegdoboz szavait animálja. A [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/buildtype/) letiltja a bekezdésenkénti felépítést, így a szó beállítása az egész szövegkeretre vonatkozik.

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

A szövegdoboz bekezdésenkénti felépítéséhez állítsa be a [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/buildtype/) (vagy más bekezdés‑szint) értéket. Egyetlen bekezdést saját effektussal célozni a [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) olyan túlterhelésével lehet, amely egy [IParagraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iparagraph/) elfogadására képes. Tekintse meg az [Animated Text](/slides/hu/python-net/animated-text/) oldalt bekezdés‑szintű példákért.

## **Exportálás és kompatibilitási megjegyzések**

- PPT vagy PPTX formátumba mentve megmarad az animációs modell, de a végső lejátszást a prezentációs nézővezérli.
- PDF és statikus képek nem játszanak le animációkat. Használja a [HTML5 export](/slides/hu/python-net/export-to-html5/), animált GIF vagy [videó konvertálás](/slides/hu/python-net/convert-powerpoint-to-video/) lehetőséget, ha a kimenetnek mozgást kell mutatnia.
- HTML5 esetén engedélyezze a [Html5Options.animate_shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/html5options/animate_shapes/) beállítást, és szükség esetén a [Html5Options.animate_transitions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/html5options/animate_transitions/)-t.
- A videó renderelés sok általános belépő, hangsúlyos, kilépő és mozgás‑út effektust támogat, de nem minden PowerPoint‑effektus van támogatva. Ellenőrizze a jelenlegi [supported animations and effects](/slides/hu/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) listát, és tesztelje a kritikus prezentációkat a cél Aspose.Slides verzióval.
- Haladó egyedi effektusok és más prezentációformátumokból importált effektusok megmaradhatnak a fájlban, de eltérően jelenhetnek meg PowerPointban, HTML5‑ben vagy videóban. Ellenőrizze az exportált eredményt, ne csak az effektus nevét vegye alapul.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem a PDF‑ben?**

A PDF statikus formátum, ezért az animációk és diaátmenetek nem játszódnak le. Exportáljon HTML5‑re, animált GIF‑re vagy videóra, ha a mozgást meg kell őrizni.

**Miért játszódik le egy effektus másként a videóban?**

A videó exportálás animációkat renderel, nem tárolja az eredeti PowerPoint‑viselkedést. Néhány fejlett effektus nem támogatott vagy csak közelítőleg jelenik meg. Tekintse át a támogatott‑effektus táblázatot, és tesztelje a tényleges prezentációt a gyártás előtt.

**Megváltoztatja egy alakzat előre vagy hátra helyezése annak animációs sorrendjét?**

Nem. Az alakzat z‑rendje a rétegezést szabályozza, míözben a szekvencia sorrend és a triggerek az animáció lejátszását irányítják. Módosítsa az idővonalat, ha más lejátszási sorrendre van szükség.