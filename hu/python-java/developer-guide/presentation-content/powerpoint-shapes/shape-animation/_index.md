---
title: Alakzatanimációk alkalmazása prezentációkban Python (Java) használatával
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/python-java/shape-animation/
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
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, ellenőrizhet és testre szabhat alakzatanimációkat, időzítést, hangokat, az animáció utáni viselkedést, valamint animált szöveget az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Python via Java a diaanimációkat effektusokként ábrázolja egy diavető idővonalában. Egy effektusnak van célforma, animációtípusa és altípusa, egy aktiválója, időzítési beállításai, valamint opcionális tulajdonságai, például hang vagy animáció utáni viselkedés.

Az idővonal kétféle szekvenciát tartalmaz:

- A **fő szekvencia** a dia előrehaladtával játszódik le.
- Az **interaktív szekvencia** akkor indul, amikor a hozzá tartozó aktiváló forma rá van kattintva.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diaképek a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) típusból származnak, a legtöbb diaelemet a [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) metódussal kezelheted. A rendelkezésre álló effektusok a [EffectType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effecttype/) osztályban vannak felsorolva.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához vedd a dia fő szekvenciáját, és hívd meg a [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) metódust a célformával, effektustípussal, altípussal és aktiválóval. Olyan effektus esetén, amely egy másik forma kattintására kezdődik, hozz létre egy interaktív szekvenciát, amelynek aktiválója az a másik forma.

A következő példa létrehozza mindkét típusú animációt, és elmenti az eredményt a `shape-animations.pptx` fájlba.

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

A trigger szabályozza, mikor indul egy effektus:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effecttriggertype/#OnClick) a fő szekvenciában egy kattintásra vár, vagy egy interaktív szekvenciában a trigger formára kattintásra.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effecttriggertype/#WithPrevious) az előző effektussal együtt kezdődik.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effecttriggertype/#AfterPrevious) akkor indul, amikor az előző effektus befejeződik.

Kép, diagram vagy más alakzat animálásához add át azt az objektumot a [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) hívásnak a `target_shape` helyett. Diagram-specifikus csoportosítási beállításokért lásd a [Animated Charts](/slides/hu/python-java/animated-charts/) oldalt.

## **Alakzatanimációk olvasása**

Használd a [Sequence.getEffectsByShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#getEffectsByShape) metódust, ha ismered a célformát. Minden effektus megtekintéséhez sorold fel a fő szekvenciát és minden interaktív szekvenciát. A felsorolás elkerüli azt a feltételezést, hogy egy szekvencia a `0` indexen tartalmaz effektust.

A következő példa egy alakzatot hoz létre fő-szekvenciás és interaktív effektusokkal, lekéri azok az effektusok, amelyek a alakzatra céloznak, majd felsorolja a dia minden szekvenciáját.

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

Ha csak egy alakzathoz szükségesek az effektusok, először azonosítsd az alakzatot név, placeholder típus vagy más stabil tulajdonság alapján; ezután hívd a [Sequence.getEffectsByShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#getEffectsByShape) metódust. Ne feltételezd, hogy a [ShapeCollection.get_Item](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#get_Item) a `0` indexen mindig a kívánt objektum.

## **Örökölt placeholder effektusok kezelése**

Egy normál dián található placeholder örökölheti az animációs viselkedést a megfelelő placeholderről a layout dián és a mesterdián. A [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getBasePlaceholder) visszaadja a szülő placeholdert, vagy `None`-t, ha nincs szülő.

A következő példaprezentációban a lábléc **Random Bars** animációval rendelkezik a normál dián, **Split** animációval a layout dián és **Fly In** animációval a mesterdián.

![Lábléc animációs effektus a normál dián](slide-shape-animation.png)

![Lábléc placeholder animációs effektus a layout dián](layout-shape-animation.png)

![Lábléc placeholder animációs effektus a mesterdián](master-shape-animation.png)

A következő példa egy új prezentáció placeholder hierarchiáját használja. Effektusokat ad egy mesterplaceholderhez, egy layout placeholderhez és a megfelelő placeholderhez a normál dián. Minden [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getBasePlaceholder) hívás ellenőrzésre kerül, mielőtt a visszakapott forma felhasználásra kerül.

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

## **Animáció időzítésének módosítása**

A PowerPoint **Timing** párbeszédpanel a [Timing](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/) tulajdonságaira vonatkozik.

![PowerPoint Timing párbeszédpanel egy animációs effektushoz](shape-animation.png)

- **Indítás** a [Timing.getTriggerType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getTriggerType) -re mutat.
- **Időtartam** a [Timing.getDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getDuration) -re mutat, másodpercben.
- **Késleltetés** a [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getTriggerDelayTime) -re mutat, másodpercben.
- **Ismétlés** a [Timing.getRepeatCount](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getRepeatCount), a [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getRepeatUntilNextClick) vagy a [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) -re mutat.
- **Visszatekerés lejátszás után** a [Timing.getRewind](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getRewind) -re mutat.

Ez a független példa egy effektust ad hozzá, módosítja annak időzítését a [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) által visszaadott objektumon keresztül, majd elmenti az eredményt. A visszakapott [Effect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/) hivatkozás megtartása elkerüli a felesleges gyűjtemény index használatát.

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

Használj egy ismétlési módot szándékosan. Egy ismétlési szám és egy “until” jelző kombinálása zavaró eredményeket okozhat különböző megjelenítőkben. Ismétlési módok módosításakor állítsd be a [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#setRepeatUntilNextClick) és a [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) metódusokat a [Timing.setRepeatCount](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#setRepeatCount) előtt, mivel bármelyik jelző beállítása is módosítja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus beágyazott hangot hivatkozhat a [Effect.getSound](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getSound) segítségével. A [Effect.setStopPreviousSound](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#setStopPreviousSound) azt mondja az effektusnak, hogy állítsa le az előző effektus által elindított hangot.

### **Hang hozzáadása egy effektushoz**

A következő példa egy helyi `animation-sound.wav` nevű hangfájlra számít. Két effektust hoz létre, az első effektus hangjaként beágyazza ezt a fájlt, és a második effektust úgy állítja be, hogy leállítsa a hangot. A [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) által visszaadott objektumokat használja, így nincs szükség szekvencia indexre.

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

### **Beágyazott effektus hangok kinyerése**

A következő példa egy helyi `presentation-with-animation-sounds.pptx` nevű prezentációra számít. Átvizsgálja a fő és interaktív szekvenciákat, és minden beágyazott effektus hangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztést az [Audio.getContentType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audio/#getContentType) által megadott hang MIME-típus alapján választja.

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

Nagy hangobjektumok esetén használd az [Audio.getStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audio/#getStream) metódust, és másold a streamet fájlba a teljes objektum bájt tömbbe betöltése helyett.

## **Animáció utáni viselkedés beállítása**

Az **After animation** (Animáció után) opció azt szabályozza, mi történik egy alakzattal az effektus befejezése után.

![PowerPoint Effektek beállítási párbeszédpanel az After animation beállításokkal](shape-after-animation.png)

A [AfterAnimationType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/afteranimationtype/) osztály támogatja az alakzat változatlanul hagyását, színének módosítását, az animáció után történő elrejtését, vagy a következő kattintásra történő elrejtését. Ha a típus [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/python-java/aspose.slides/afteranimationtype/#Color), akkor a [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getAfterAnimationColor) is beállítható.

Ez a független példa egy effektust hoz létre, beállítja annak animáció utáni viselkedését a visszaadott effektus objektumon keresztül, majd elmenti az eredményt.

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

A [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/python-java/aspose.slides/afteranimationtype/#Color) típusról való átváltás törli az animáció utáni színbeállítást.

## **Szöveg animálása**

A szöveg animáció két kapcsolódó vezérlővel rendelkezik:

- A [TextAnimation.getBuildType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textanimation/#getBuildType) szabályozza, hogy a bekezdések egyszerre vagy bekezdésenként jelenjenek meg.
- A [Effect.getAnimateTextType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getAnimateTextType) szabályozza, hogy a szöveg egyszerre, szó szerint vagy betű szerint jelenjen meg. A [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getDelayBetweenTextParts) beállítja a szavak vagy betűk közti késleltetést. A pozitív érték az effektus időtartamának százalékában van, a negatív érték másodpercben.

A következő független példa egy szövegdoboz szavait animálja. A [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/python-java/aspose.slides/buildtype/#AsOneObject) letiltja a bekezdésenkénti építést, így a szó beállítás az egész szövegkeretre vonatkozik.

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

Szövegdoboz bekezdésenkénti építéséhez állítsd be a [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hu/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (vagy más bekezdés szintet). Egyetlen bekezdés saját effektussal történő célzásához használd a [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) olyan túlterhelését, amely [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) objektumot fogad el. Lásd a [Animated Text](/slides/hu/python-java/animated-text/) oldalt a bekezdés szintű példákért.

## **Exportálás és kompatibilitási megjegyzések**

- A PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a végső lejátszást a prezentáció megjelenítője szabályozza.
- A PDF és a statikus képek nem játszanak le animációkat. Használd a [HTML5 export](/slides/hu/python-java/export-to-html5/), animált GIF vagy a [video conversion](/slides/hu/python-java/convert-powerpoint-to-video/) lehetőséget, ha a kimenetnek mozgást kell mutatnia.
- HTML5 esetén engedélyezd a [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setAnimateShapes) és szükség esetén a [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setAnimateTransitions) beállítást.
- A videó renderelés sok gyakori belépési, hangsúlyozási, kilépési és mozgáspálya effektust támogat, de nem minden PowerPoint effektus érhető el. Ellenőrizd a jelenlegi [supported animations and effects](/slides/hu/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) listát, és teszteld a kritikus prezentációkat a cél Aspose.Slides verzióval.
- Haladó egyéni effektusok és más prezentációs formátumokból importált effektusok megmaradhatnak a fájlban, de másként jelennek meg PowerPointban, HTML5-ben vagy videóban. Ellenőrizd az exportált eredményt, ne csak az effektus nevét vedd alapul.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem a PDF-ben?**

A PDF egy statikus formátum, ezért az animációk és diaátmenetek nem játszanak le. Exportálj HTML5-re, animált GIF-re vagy videóra, ha a mozgást meg kell őrizni.

**Miért játszódik le egy effektus másként a videóban?**

A videó exportálás animációkat renderel, nem a eredeti PowerPoint viselkedést tárolja. Néhány fejlett effektus nem támogatott vagy csak közelítő. Tekintsd át a támogatott effektusok táblázatát, és teszteld a tényleges prezentációt a termelés előtt.

**Módosítja egy alakzat előre vagy hátra helyezése az animációs sorrendet?**

Nem. Az alakzat z-rendje csak a átfedést szabályozza, míg a szekvencia sorrend és a triggerek az animáció lejátszását. Módosítsd az idővonalat, ha más lejátszási sorrendre van szükség.