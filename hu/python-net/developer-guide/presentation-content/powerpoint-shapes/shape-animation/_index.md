---
title: Alakzatanimációk alkalmazása prezentációkban Python nyelven
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
description: "Ismerje meg, hogyan adhat hozzá, vizsgálhat meg és testre szabhat alakzatanimációkat, időzítést, hangokat, az animáció utáni viselkedést és animált szöveget az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Az effektuson belüli egyedi viselkedések kezeléséhez vagy a mozgású útvonal szegmensek szerkesztéséhez lásd a [Custom Animation](/slides/hu/python-net/custom-animation/).

Az Aspose.Slides for Python via .NET a diaanimációkat effektusokként jeleníti meg egy diát idővonalában. Egy effektus cél alakzatot, animációtípust és alttípust, aktiválót, időzítési beállításokat, valamint opcionális tulajdonságokat, például hangot vagy az animáció utáni viselkedést tartalmaz.

Az idővonal kétféle szekvenciát tartalmaz:

- A **fő szekvencia** játszódik le, amikor a dia előrehalad.
- Egy **interaktív szekvencia** akkor kezdődik, amikor az aktiváló alakzatra kattintanak.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diára helyezett objektumok a [IShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishape/) interfészt valósítják meg, ugyanazt a [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) metódust használhatja a legtöbb diatartalomhoz. Az elérhető effektusok a [EffectType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effecttype/) felsorolásban vannak felsorolva.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához szerezze be a dia fő szekvenciáját, és hívja meg a [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) metódust a cél alakzattal, effektustípussal, alttípussal és aktiválóval. Olyan effektus esetén, amely egy másik alakzatra kattintáskor kezdődik, hozzon létre egy interaktív szekvenciát, amelynek aktiválója az a másik alakzat.

Az alábbi példa mindkét animációtípust létrehozza, és az eredményt a `shape-animations.pptx` fájlba menti.

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

Az aktiváló határozza meg, mikor kezdődik egy effektus:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effecttriggertype/) a fő szekvenciában kattintásra vagy egy interaktív szekvenciában az aktiváló alakzatra vár.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effecttriggertype/) az előző effektussal kezdődik.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effecttriggertype/) akkor indul, amikor az előző effektus befejeződik.

Kép, diagram vagy más alakzat animálásához adja át azt az objektumot a [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) metódusnak a `target_shape` helyett. Diagramok speciális csoportosítási beállításaiért lásd a [Animated Charts](/slides/hu/python-net/animated-charts/).

## **Alakzatanimációk olvasása**

Használja a [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) metódust, ha ismeri a cél alakzatot. Minden effektus megvizsgálásához iteráljon a fő szekvencián és minden interaktív szekvencián. Az iteráció elkerüli annak feltételezését, hogy egy szekvencia a `0` indexű elemet tartalmazza.

Az alábbi példa egy alakzatot hoz létre fő‑szekvenciás és interaktív effektusokkal, lekéri a alakzatra mutató effektusokat, majd végigiterál minden szekvencián a dián.

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

Ha csak egy alakzatra van szüksége, először azonosítsa az alakzatot név, helyőrző típus vagy más stabil tulajdonság alapján; ezután hívja meg a [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) metódust. Ne feltételezze, hogy a `0` indexű alakzat mindig a kívánt objektum.

## **Örökölt helyőrző effektusok kezelése**

Egy helyőrző egy normál dián örökölheti az animációs viselkedést a layout dián vagy a mester dián található megfelelő helyőrzőtől. A [Shape.get_base_placeholder](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_base_placeholder/) visszaadja azt a szülőhelyőrzőt, vagy `None`‑t, ha nincs szülő.

Az alábbi példaprezentációban a lábléc **Random Bars** animációval rendelkezik a normál dián, **Split** animációval a layout dián, és **Fly In** animációval a mester dián.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

A következő példa magát a helyőrző hierarchiát építi fel. Effektusokat ad egy mester helyőrzőhöz, egy layout helyőrzőhöz, valamint a megfelelő helyőrzőhöz a normál dián. Minden [Shape.get_base_placeholder](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_base_placeholder/) hívást ellenőriz, mielőtt a visszakapott alakzatot felhasználná.

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

A PowerPoint **Timing** párbeszédablaka a [Timing](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/) tulajdonságaihoz térképeződik.

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** a [Timing.trigger_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/trigger_type/) tulajdonságához tartozik.
- **Duration** a [Timing.duration](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/duration/) tulajdonsághoz tartozik, másodpercben.
- **Delay** a [Timing.trigger_delay_time](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/trigger_delay_time/) tulajdonsághoz tartozik, másodpercben.
- **Repeat** a [Timing.repeat_count](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_until_next_click/) vagy [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) beállításokhoz tartozik.
- **Rewind when done playing** a [Timing.rewind](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/rewind/) tulajdonságot állítja be.

Ez a független példa egy effektust ad hozzá, módosítja annak időzítését a [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) által visszaadott objektumon keresztül, és elmenti az eredményt. A visszakapott [Effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/) referencia megtartása elkerüli egy felesleges gyűjteményindex használatát.

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

Használjon egy ismétlési módot tudatosan. Egy ismétlési számmal kombinált „until” jelző zavaró eredményeket okozhat különböző lejátszókban. Amikor ismétlési módokat változtat, állítsa be előbb a [Timing.repeat_until_next_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_until_next_click/) és a [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) értékeket, majd a [Timing.repeat_count](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_count/) értékét, mert az egyik jelző beállítása automatikusan megváltoztatja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus hivatkozhat beágyazott hangra a [Effect.sound](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/sound/) segítségével. A [Effect.stop_previous_sound](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/stop_previous_sound/) azt mondja az effektusnak, hogy állítsa le egy korábbi effektus által indított hangot.

### **Hang hozzáadása egy effektushoz**

Az alábbi példa egy helyi `animation-sound.wav` nevű hangfájlt vár. Két effektust hoz létre, az elsőhöz beágyazza a fájlt hangként, a második effektus pedig leállítja a hangot. A [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) által visszaadott objektumokat használja, ezért nem szükséges szekvencia indexet megadni.

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

### **Beágyazott effektushangok kinyerése**

Az alábbi példa egy helyi `presentation-with-animation-sounds.pptx` nevű prezentációt vár. A fő és az interaktív szekvenciákat bejárja, és minden beágyazott effektushangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztést az [Audio.content_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audio/content_type/) által visszaadott audio MIME‑típus alapján választja.

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

Nagy hangobjektumok esetén használja az [Audio.get_stream](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audio/get_stream/) metódust, és másolja a streamet egy fájlba ahelyett, hogy az egész objektumot egy byte tömbbe töltené be.

## **Az animáció utáni viselkedés beállítása**

Az **After animation** opció határozza meg, mi történik egy alakzattal, amikor az effektus befejeződik.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

A [AfterAnimationType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/afteranimationtype/) felsorolás lehetővé teszi, hogy az alakzat változatlan maradjon, színét megváltozzák, elrejtik az animáció után, vagy a következő kattintáskor rejtik el. Amikor a típus [AfterAnimationType.COLOR](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/afteranimationtype/), állítsa be a [Effect.after_animation_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/after_animation_color/) értékét is.

Ez a független példa egy effektust hoz létre, beállítja az animáció utáni viselkedést a visszakapott effektusobjektumon keresztül, és elmenti az eredményt.

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

A [AfterAnimationType.COLOR](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/afteranimationtype/) típusról való eltérés törli az animáció utáni színbeállítást.

## **Szöveg animálása**

A szöveganimációnak két kapcsolódó beállítása van:

- A [TextAnimation.build_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/textanimation/build_type/) határozza meg, hogy a bekezdések egyszerre vagy bekezdésenként jelennek meg.
- Az [Effect.animate_text_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/animate_text_type/) határozza meg, hogy a szöveg egyszerre, szó szerint vagy betű szerint jelenik meg. A [Effect.delay_between_text_parts](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/delay_between_text_parts/) beállítja a szavak vagy betűk közti késleltetést. A pozitív érték a effektus időtartamának százalékában, a negatív érték másodpercben adódik meg.

Az alábbi független példa egy szövegdoboz szavait animálja. A [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/buildtype/) letiltja a bekezdésenkénti építést, így a szó beállítás az egész szövegdobozra vonatkozik.

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

A szövegdoboz bekezdésenkénti felépítéséhez állítsa be a [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/buildtype/) (vagy egy másik bekezdés szintet). Egyetlen bekezdéshez, amely saját effektussal rendelkezik, használja a [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) olyan túlterhelését, amely egy [IParagraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iparagraph/) objektumot fogad. Lásd az [Animated Text](/slides/hu/python-net/animated-text/) oldalt a bekezdés‑szintű példákért.

## **Exportálás és kompatibilitási megjegyzések**

- PPT vagy PPTX mentése megőrzi az animációs modellt, de a végső lejátszást a prezentációs megjelenítő szabályozza.
- PDF és statikus képek nem játszanak animációkat. Használjon [HTML5 export](/slides/hu/python-net/export-to-html5/), animált GIF‑et vagy [videókonverziót](/slides/hu/python-net/convert-powerpoint-to-video/), ha a kimenetnek mozgást kell mutatnia.
- HTML5 esetén engedélyezze a [Html5Options.animate_shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/html5options/animate_shapes/) lehetőséget, és szükség esetén a [Html5Options.animate_transitions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/html5options/animate_transitions/) beállítást.
- A videó renderelés számos gyakori belépő, hangsúlyozó, kilépő és mozgás‑útvonal effektust támogat, de nem minden PowerPoint effektus érhető el. Ellenőrizze az aktuális [supported animations and effects](/slides/hu/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) listát, és tesztelje a kritikus prezentációkat a használt Aspose.Slides verzióval.
- Haladó egyéni effektusok és más prezentációs formátumokból importált effektusok megmaradhatnak a fájlban, de másképp jelenhetnek meg PowerPointban, HTML5‑ben vagy videóban. Validálja az exportált eredményt, ne csak az effektus nevét vegye alapul.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem PDF‑ben?**

A PDF egy statikus formátum, ezért az animációk és dia‑átmenetek nem játszhatók le. Exportáljon HTML5‑re, animált GIF‑re vagy videóra, ha a mozgást meg kell őrizni.

**Miért játszódik le egy effektus másként a videóban?**

A videóexport animációkat renderel, nem tárolja az eredeti PowerPoint viselkedést. Egyes haladó effektusok nem támogatottak vagy csak közelítőek. Nézze meg a támogatott‑effektus táblázatot, és tesztelje a tényleges prezentációt a gyártás előtt.

**Megváltoztatja egy alakzat előre vagy hátra mozdítása az animáció sorrendjét?**

Nem. Az alakzat z‑rendje az átfedést szabályozza, míg a szekvencia sorrend és az aktiválók határozzák meg az animáció lejátszási sorrendjét. Módosítsa az idővonalat, ha más lejátszási sorrendre van szükség.