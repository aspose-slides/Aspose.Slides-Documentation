---
title: Alakzatanimációk alkalmazása prezentációkban Python via Java segítségével
linktitle: Alakzatanimáció
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
- animáció lekérdezése
- animáció kinyerése
- effektus hozzáadása
- effektus lekérdezése
- effektus kinyerése
- effektus hangja
- animáció alkalmazása
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan adjon hozzá, vizsgáljon meg és testre szabjon alakzatanimációkat, időzítést, hangokat, az animáció utáni viselkedést és animált szöveget az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Az egyes viselkedések egy effektuson belül való kezeléséhez vagy a mozgásút szegmensek szerkesztéséhez lásd a [Custom Animation](/slides/hu/python-java/custom-animation/) oldalt.

Az Aspose.Slides for Python via Java a diavetítések animációit effektusként ábrázolja egy diátimeline-ben. Egy effektusnak van cél alakzata, animáció típusa és altípusa, egy trigger, időzítési beállítások, valamint opcionális tulajdonságai, például hang vagy az animáció utáni viselkedés.

A timeline kétféle szekvenciát tartalmaz:

- A **main sequence** a dia előrehaladtával lejátszódik.
- Az **interactive sequence** akkor kezdődik, amikor a trigger alakzatát rákattintanak.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diaobjektumok a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) osztályból származnak, a legtöbb diaelemnél ugyanazt a [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) metódust használhatod. Az elérhető effektusok a [EffectType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effecttype/) osztályban vannak felsorolva.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához szerezd meg a dia fő szekvenciáját, és hívd meg a [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) metódust a cél alakzattal, effektustípussal, altípussal és triggerrel. Egy olyan effektushoz, amely egy másik alakzat kattintására indul, hozz létre egy interactive sequence‑t, amelynek a triggerje az a másik alakzat.

Az alábbi példa létrehozza mindkét típusú animációt, és a `shape-animations.pptx` fájlba menti az eredményt.

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

A trigger határozza meg, mikor kezdődik egy effektus:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effecttriggertype/#OnClick) a fő szekvenciában kattintásra vár, vagy egy interactive sequence‑ben a trigger alakzatra.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effecttriggertype/#WithPrevious) az előző effektussal együtt indul.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effecttriggertype/#AfterPrevious) az előző effektus befejezése után kezdődik.

Kép, diagram vagy más alakzat animálásához add át azt az objektumot a [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) metódusnak a `target_shape` helyett. Diagram-specifikus csoportosítási beállításokért lásd az [Animated Charts](/slides/hu/python-java/animated-charts/).

## **Alakzatanimációk olvasása**

Használd a [Sequence.getEffectsByShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#getEffectsByShape) metódust, ha ismered a cél alakzatot. Minden effektus megtekintéséhez sorold fel a fő szekvenciát és minden interactive sequence‑t. A felsorolás elkerüli annak feltételezését, hogy egy szekvencia a `0` indexű effektust tartalmazza.

Az alábbi példa létrehozza egy alakzatot fő‑ és interactive effektusokkal, lekéri a alakzatra mutató effektusokat, majd felsorolja a dia minden szekvenciáját.

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

Ha csak egy alakzathoz szükségesek az effektusok, először azonosítsd az alakzatot név, helyőrző típus vagy más stabil tulajdonság alapján; ezután hívd meg a [Sequence.getEffectsByShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#getEffectsByShape) metódust. Ne feltételezd, hogy a [ShapeCollection.get_Item](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#get_Item) a `0` indexen mindig a kívánt objektum.

## **Örökölt helyőrző effektusok kezelése**

Egy normál dián található helyőrző örökölheti az animációs viselkedést a hozzá tartozó elrendezés‑ és mesterdián lévő helyőrzőtől. A [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getBasePlaceholder) visszaadja ezt a szülőhelyőrzőt, vagy `None`‑t, ha nincs szülő.

Az alábbi példaprezentációban a lábléc **Random Bars** animációval rendelkezik a normál dián, **Split**‑el az elrendezés‑dián, és **Fly In**‑el a mester‑dián.

![Lábléc animációs effektus a normál dián](slide-shape-animation.png)

![Lábléc helyőrző animációs effektus az elrendezés‑dián](layout-shape-animation.png)

![Lábléc helyőrző animációs effektus a mester‑dián](master-shape-animation.png)

A következő példa egy új prezentáció helyőrző‑hierarchiáját használja. Effektusokat ad egy mesterhelyőrzőhöz, egy elrendezéshelyőrzőhöz és a megfelelő helyőrzőhöz a normál dián. Minden [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getBasePlaceholder) hívás előtt ellenőrzés történik, mielőtt a visszakapott alakzatot felhasználnák.

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

- **Start** a [Timing.getTriggerType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getTriggerType) értékéhez van rendelve.
- **Duration** a [Timing.getDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getDuration) értékéhez van rendelve, másodpercben.
- **Delay** a [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getTriggerDelayTime) értékéhez van rendelve, másodpercben.
- **Repeat** a [Timing.getRepeatCount](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getRepeatCount), a [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getRepeatUntilNextClick) vagy a [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) értékéhez van rendelve.
- **Rewind when done playing** a [Timing.getRewind](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getRewind) értékéhez van rendelve.

Ez az önálló példa egy effektust ad hozzá, a [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) által visszaadott objektummal módosítja annak időzítését, és menti az eredményt. A visszakapott [Effect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/) hivatkozás megtartása elkerüli a felesleges kollekció‑index használatát.

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

Használj egy ismert ismétlési módot. Egy ismétlési szám és egy „until” (amíg) jelző kombinálása zavaró eredményeket produkálhat különböző lejátszókban. Ismétlési módok módosításakor állítsd be a [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#setRepeatUntilNextClick) és a [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) értékeket a [Timing.setRepeatCount](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#setRepeatCount) előtt, mivel bármelyik jelző beállítása megváltoztatja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus beágyazott hangra hivatkozhat a [Effect.getSound](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getSound) segítségével. A [Effect.setStopPreviousSound](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#setStopPreviousSound) azt mondja az effektusnak, hogy állítsa le az előző effektus által indított hangot.

### **Hang hozzáadása egy effektushoz**

Az alábbi példa egy helyi `animation-sound.wav` nevű hangfájlt vár. Két effektust hoz létre, beágyazza a fájlt az első effektus hangjaként, és beállítja a második effektust a hang leállítására. A [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) által visszaadott objektumokat használja, ezért nincs szükség szekvencia‑indexre.

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

Az alábbi példa egy helyi `presentation-with-animation-sounds.pptx` nevű prezentációt vár. Átvizsgálja a fő és az interactive szekvenciákat, és minden beágyazott effektushangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztést az [Audio.getContentType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audio/#getContentType) által visszaadott audio MIME‑típus alapján választja.

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

Nagy audioobjektumok esetén használd az [Audio.getStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audio/#getStream) metódust, és másold a streamet fájlba ahelyett, hogy az egész objektumot egy byte‑tömbbe töltenéd be.

## **Az animáció utáni viselkedés beállítása**

A **After animation** beállítás azt szabályozza, mi történik az alakzattal, amikor az effektus befejeződik.

![PowerPoint Effect Options párbeszédpanel az After animation beállításokkal](shape-after-animation.png)

Az [AfterAnimationType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/afteranimationtype/) osztály lehetővé teszi, hogy az alakzat változatlan maradjon, színe megváltozzon, az animáció után elrejtődjön, vagy a következő kattintásra tűnjön el. Ha a típus [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/python-java/aspose.slides/afteranimationtype/#Color), akkor állítsd be a [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getAfterAnimationColor) értékét is.

Ez az önálló példa létrehoz egy effektust, a visszakapott effektusobjektummal beállítja az animáció utáni viselkedést, és elmenti az eredményt.

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

A [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/python-java/aspose.slides/afteranimationtype/#Color) típus megváltoztatása törli az animáció utáni színbeállítást.

## **Szöveg animálása**

A szöveg animáció két kapcsolódó vezérléssel rendelkezik:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textanimation/#getBuildType) szabályozza, hogy a bekezdések egyszerre vagy bekezdésenként jelenjenek meg.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getAnimateTextType) szabályozza, hogy a szöveg egyszerre, szó szerint vagy betű szerint jelenjen meg. A [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getDelayBetweenTextParts) állítja be a szavak vagy betűk közötti késleltetést. A pozitív érték az effektus időtartamának százaléka; a negatív érték másodpercben megadott késleltetés.

Az alábbi önálló példa a szövegdoboz szavait animálja. A [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/python-java/aspose.slides/buildtype/#AsOneObject) letiltja a bekezdésenkénti építést, így a szóbeállítás az egész szövegdobozra vonatkozik.

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

A szövegdoboz bekezdésenkénti építéséhez állítsd be a [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hu/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (vagy másik bekezdés‑szintet). Egyetlen bekezdés saját effektusához használd a [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) olyan túlterhelését, amely egy [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) objektumot fogad el. Lásd a [Animated Text](/slides/hu/python-java/animated-text/) oldalt bekezdés‑szintű példákért.

## **Exportálási és kompatibilitási megjegyzések**

- A PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a végső lejátszást a prezentáció‑megtekintő szabályozza.
- A PDF és a statikus képek nem játszanak le animációkat. Használd a [HTML5 export](/slides/hu/python-java/export-to-html5/), animált GIF vagy a [video conversion](/slides/hu/python-java/convert-powerpoint-to-video/) lehetőséget, ha a kimenetnek mozgást kell mutatnia.
- HTML5 esetén engedélyezd a [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setAnimateShapes) beállítást, és szükség esetén a [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/html5options/#setAnimateTransitions) beállítást.
- A videórenderelés sok gyakori belépő, hangsúlyozó, kilépő és mozgásút‑effektust támogat, de nem minden PowerPoint‑effektus érhető el. Ellenőrizd a jelenlegi [supported animations and effects](/slides/hu/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) listát, és teszteld a kritikus prezentációkat a célzott Aspose.Slides verzióval.
- A fejlett egyéni effektusok és más formátumokból importált effektusok megmaradhatnak a fájlban, de PowerPointban, HTML5‑ben vagy videóban eltérően jelenhetnek meg. Ellenőrizd az exportált eredményt, ne csak az effektus nevét vedd alapul.

## **GYIK**

**Miért jelenik meg az animáció PowerPoint‑ban, de nem PDF‑ben?**

A PDF statikus formátum, így az animációk és diaváltások nem játszhatók le. Exportálj HTML5‑re, animált GIF‑re vagy videóra, ha a mozgást meg kell őrizni.

**Miért játszik le egy effektus eltérően videóban?**

A videóexport animációkat renderel, nem az eredeti PowerPoint‑viselkedést tárolja. Egyes fejlett effektusok nem támogatottak vagy közelítőek. Tekintsd át a támogatott‑effektus táblázatot, és teszteld a tényleges prezentációt a termelés előtt.

**Megváltoztatja-e egy alakzat előre‑ vagy hátratevése az animáció sorrendjét?**

Nem. Az alakzat z‑rendje az átfedést szabályozza, míg a szekvencia sorrendje és a triggerek az animáció lejátszását. Változtasd meg a timeline‑t, ha más lejátszási sorrendre van szükséged.