---
title: Formanimationen in Präsentationen mit Python via Java anwenden
linktitle: Formanimation
type: docs
weight: 60
url: /de/python-java/shape-animation/
keywords:
- Form
- Animation
- Effekt
- animierte Form
- animierter Text
- Animation hinzufügen
- Animation abrufen
- Animation extrahieren
- Effekt hinzufügen
- Effekt abrufen
- Effekt extrahieren
- Effektton
- Animation anwenden
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Python via Java Formanimationen, Timing, Sounds, Nach‑Animations‑Verhalten und animierten Text hinzufügen, prüfen und anpassen."
---
## **Übersicht**

Um mit den einzelnen Verhaltensweisen innerhalb eines Effekts zu arbeiten oder Bewegungspfad‑Segmente zu bearbeiten, siehe [Benutzerdefinierte Animation](/slides/de/python-java/custom-animation/).

Aspose.Slides for Python via Java stellt Folienanimationen als Effekte in einer Folien‑Zeitleiste dar. Ein Effekt hat eine Ziel‑Shape, einen Animationstyp und -untertyp, einen Auslöser, Zeiteinstellungen und optionale Eigenschaften wie Sound oder ein Verhalten nach der Animation.

Die Zeitleiste enthält zwei Arten von Sequenzen:

- Die **Hauptsequenz** wird abgespielt, wenn die Folie fortschreitet.
- Eine **interaktive Sequenz** startet, wenn ihre Auslöser‑Shape angeklickt wird.

Weil Textfelder, Bilder, Diagramme, Tabellen und andere Folienobjekte von [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/) abgeleitet sind, verwenden Sie die gleiche [Sequence.addEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/#addEffect)‑Methode für die meisten Folieninhalte. Die verfügbaren Effekte sind in der Klasse [EffectType](https://reference.aspose.com/slides/de/python-java/aspose.slides/effecttype/) aufgelistet.

## **Formanimationen hinzufügen**

Um eine Animation hinzuzufügen, holen Sie die Hauptsequenz der Folie und rufen Sie [Sequence.addEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/#addEffect) mit der Ziel‑Shape, dem Effekt‑Typ, Untertyp und Auslöser auf. Für einen Effekt, der startet, wenn eine andere Shape angeklickt wird, erstellen Sie eine interaktive Sequenz, deren Auslöser diese andere Shape ist.

Das folgende Beispiel erstellt beide Animationsarten und speichert das Ergebnis in `shape-animations.pptx`.

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

Der Auslöser steuert, wann ein Effekt startet:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/de/python-java/aspose.slides/effecttriggertype/#OnClick) wartet auf einen Klick in der Hauptsequenz oder auf einen Klick auf die Auslöser‑Shape in einer interaktiven Sequenz.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/de/python-java/aspose.slides/effecttriggertype/#WithPrevious) startet zusammen mit dem vorherigen Effekt.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/de/python-java/aspose.slides/effecttriggertype/#AfterPrevious) startet, wenn der vorherige Effekt beendet ist.

Um ein Bild, Diagramm oder einen anderen Shape‑Typ zu animieren, übergeben Sie dieses Objekt an [Sequence.addEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/#addEffect), anstatt `target_shape`. Für diagrammspezifische Gruppierungsoptionen siehe [Animated Charts](/slides/de/python-java/animated-charts/).

## **Formanimationen lesen**

Verwenden Sie [Sequence.getEffectsByShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/#getEffectsByShape), wenn Sie die Ziel‑Shape kennen. Um jeden Effekt zu untersuchen, enumerieren Sie die Hauptsequenz und jede interaktive Sequenz. Durch Enumerieren wird vermieden, anzunehmen, dass eine Sequenz einen Effekt am Index `0` enthält.

Das folgende Beispiel erstellt eine Shape mit Haupt‑ und interaktiven Effekten, ermittelt die Effekte, die die Shape ansprechen, und enumeriert anschließend jede Sequenz auf der Folie.

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

Wenn Sie nur die Effekte für eine einzelne Shape benötigen, identifizieren Sie zunächst die Shape anhand von Name, Platzhaltertyp oder einer anderen stabilen Eigenschaft; rufen Sie dann [Sequence.getEffectsByShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/#getEffectsByShape) auf. Gehen Sie nicht davon aus, dass [ShapeCollection.get_Item](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#get_Item) am Index `0` immer das gewünschte Objekt ist.

## **Arbeiten mit geerbten Platzhalter‑Effekten**

Ein Platzhalter auf einer normalen Folie kann das Animationsverhalten vom entsprechenden Platzhalter auf seiner Layout‑Folie und Master‑Folie erben. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getBasePlaceholder) gibt diesen übergeordneten Platzhalter zurück oder `None`, wenn kein übergeordneter Platzhalter existiert.

In der folgenden Beispiel‑Präsentation hat die Fußzeile **Random Bars** auf der normalen Folie, **Split** auf der Layout‑Folie und **Fly In** auf der Master‑Folie.

![Animations­effekt der Fußzeile auf der normalen Folie](slide-shape-animation.png)

![Platzhalter‑Animations­effekt der Fußzeile auf der Layout‑Folie](layout-shape-animation.png)

![Platzhalter‑Animations­effekt der Fußzeile auf der Master‑Folie](master-shape-animation.png)

Das nächste Beispiel verwendet eine Platzhalter‑Hierarchie aus einer neuen Präsentation. Es fügt Effekte zu einem Master‑Platzhalter, einem Layout‑Platzhalter und dem entsprechenden Platzhalter auf einer normalen Folie hinzu. Jeder Aufruf von [Shape.getBasePlaceholder](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getBasePlaceholder) wird geprüft, bevor die zurückgegebene Shape verwendet wird.

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

## **Animations‑Timing ändern**

Der PowerPoint‑**Timing**‑Dialog entspricht den Eigenschaften von [Timing](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/).

![PowerPoint‑Timing‑Dialog für einen Animations­effekt](shape-animation.png)

- **Start** entspricht [Timing.getTriggerType](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getTriggerType).
- **Dauer** entspricht [Timing.getDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getDuration), in Sekunden.
- **Verzögerung** entspricht [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getTriggerDelayTime), in Sekunden.
- **Wiederholung** entspricht [Timing.getRepeatCount](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getRepeatUntilNextClick) oder [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Zurückspulen nach Abspielen** entspricht [Timing.getRewind](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getRewind).

Dieses unabhängige Beispiel fügt einen Effekt hinzu, ändert dessen Timing über das von [Sequence.addEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/#addEffect) zurückgegebene Objekt und speichert das Ergebnis. Das Beibehalten der zurückgegebenen [Effect]-Referenz verhindert einen unnötigen Sammlungs‑Index.

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

Verwenden Sie bewusst nur einen Wiederholungsmodus. Das Kombinieren einer Wiederholungsanzahl mit einem „until“-‑Flag kann in verschiedenen Betrachtern verwirrende Ergebnisse erzeugen. Beim Ändern der Wiederholungsmodi setzen Sie [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#setRepeatUntilNextClick) und [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) vor [Timing.setRepeatCount](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#setRepeatCount), da das Setzen eines Flags ebenfalls den aktiven Wiederholungsmodus ändert.

## **Animations‑Sounds hinzufügen und extrahieren**

Ein Animations‑Effekt kann über [Effect.getSound](https://reference.aspose.com/slides/de/python-java/aspose.slides/effect/#getSound) auf eingebettetes Audio verweisen. [Effect.setStopPreviousSound](https://reference.aspose.com/slides/de/python-java/aspose.slides/effect/#setStopPreviousSound) weist einen Effekt an, Audio zu stoppen, das von einem vorherigen Effekt gestartet wurde.

### **Einen Sound zu einem Effekt hinzufügen**

Das folgende Beispiel erwartet eine lokale Audiodatei mit dem Namen `animation-sound.wav`. Es erstellt zwei Effekte, bettet diese Datei als Sound für den ersten Effekt ein und konfiguriert den zweiten Effekt so, dass er den Sound stoppt. Es verwendet die von [Sequence.addEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/#addEffect) zurückgegebenen Objekte, sodass kein Sequenz‑Index erforderlich ist.

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

### **Eingebettete Effekt‑Sounds extrahieren**

Das folgende Beispiel erwartet eine lokale Präsentation mit dem Namen `presentation-with-animation-sounds.pptx`. Es durchsucht sowohl Haupt‑ als auch interaktive Sequenzen und schreibt jeden eingebetteten Effekt‑Sound in das Verzeichnis `extracted-animation-sounds`. Die Dateierweiterung wird anhand des Audio‑MIME‑Typs, der von [Audio.getContentType](https://reference.aspose.com/slides/de/python-java/aspose.slides/audio/#getContentType) bereitgestellt wird, ausgewählt.

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

Für große Audio‑Objekte verwenden Sie [Audio.getStream](https://reference.aspose.com/slides/de/python-java/aspose.slides/audio/#getStream), um den Stream in eine Datei zu kopieren, anstatt das gesamte Objekt in ein Byte‑Array zu laden.

## **Nach‑Animations‑Verhalten festlegen**

Die Option **After animation** steuert, was mit einer Shape passiert, nachdem ihr Effekt beendet ist.

![PowerPoint‑Effekt‑Optionen‑Dialog mit After‑Animation‑Einstellungen](shape-after-animation.png)

Die Klasse [AfterAnimationType](https://reference.aspose.com/slides/de/python-java/aspose.slides/afteranimationtype/) unterstützt das Belassen der Shape unverändert, das Ändern ihrer Farbe, das Ausblenden nach der Animation oder das Ausblenden beim nächsten Klick. Wenn der Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/de/python-java/aspose.slides/afteranimationtype/#Color) ist, setzen Sie zusätzlich [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/effect/#getAfterAnimationColor).

Dieses unabhängige Beispiel erstellt einen Effekt, legt sein Nach‑Animations‑Verhalten über das zurückgegebene Effekt‑Objekt fest und speichert das Ergebnis.

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

Das Ändern des Typs von [AfterAnimationType.Color](https://reference.aspose.com/slides/de/python-java/aspose.slides/afteranimationtype/#Color) löscht die Nach‑Animations‑Farbeinstellung.

## **Text animieren**

Die Textanimation hat zwei zugehörige Einstellungen:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textanimation/#getBuildType) steuert, ob Absätze zusammen oder absatzweise angezeigt werden.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/de/python-java/aspose.slides/effect/#getAnimateTextType) steuert, ob Text auf einmal, Wort für Wort oder Buchstabe für Buchstabe erscheint. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/effect/#getDelayBetweenTextParts) legt die Verzögerung zwischen Wörtern oder Buchstaben fest. Ein positiver Wert ist ein Prozentsatz der Effektdauer; ein negativer Wert ist eine Verzögerung in Sekunden.

Das folgende unabhängige Beispiel animiert die Wörter in einem Textfeld. [BuildType.AsOneObject](https://reference.aspose.com/slides/de/python-java/aspose.slides/buildtype/#AsOneObject) deaktiviert das absatzweise Aufbauprinzip, sodass die Wort‑Einstellung auf den gesamten Textrahmen angewendet wird.

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

Um ein Textfeld absatzweise aufzubauen, setzen Sie [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/de/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (oder ein anderes Absatz‑Level). Um einen einzelnen Absatz mit einem eigenen Effekt zu versehen, verwenden Sie die Überladung von [Sequence.addEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/#addEffect), die ein [Paragraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/) akzeptiert. Siehe [Animated Text](/slides/de/python-java/animated-text/) für Beispiele auf Absatz‑Ebene.

## **Export‑ und Kompatibilitäts‑Hinweise**

- Das Speichern als PPT oder PPTX bewahrt das Animationsmodell, aber die endgültige Wiedergabe wird vom Präsentations‑Viewer gesteuert.
- PDF und statische Bilder spielen keine Animationen ab. Verwenden Sie [HTML5 export](/slides/de/python-java/export-to-html5/), animierte GIFs oder [video conversion](/slides/de/python-java/convert-powerpoint-to-video/), wenn die Ausgabe Bewegung zeigen muss.
- Für HTML5 aktivieren Sie [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/html5options/#setAnimateShapes), und bei Bedarf [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/de/python-java/aspose.slides/html5options/#setAnimateTransitions).
- Die Video‑Renderung unterstützt viele gängige Eingangs‑, Betonungs‑, Ausgangs‑ und Bewegungspfad‑Effekte, aber nicht jeden PowerPoint‑Effekt. Prüfen Sie die aktuelle [supported animations and effects](/slides/de/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) und testen Sie kritische Präsentationen mit Ihrer Ziel‑Aspose.Slides‑Version.
- Erweiterte benutzerdefinierte Effekte und aus anderen Präsentationsformaten importierte Effekte können in der Datei erhalten bleiben, werden jedoch in PowerPoint, HTML5 oder Video unterschiedlich gerendert. Validieren Sie das exportierte Ergebnis, anstatt sich ausschließlich auf den Effekt‑namen zu verlassen.

## **FAQ**

**Warum erscheint eine Animation in PowerPoint, aber nicht in einem PDF?**

PDF ist ein statisches Format, daher werden Animationen und Folienübergänge nicht abgespielt. Exportieren Sie nach HTML5, animierten GIFs oder Video, wenn Bewegung erhalten bleiben muss.

**Warum wird ein Effekt in einem Video anders wiedergegeben?**

Der Video‑Export rendert Animationen, anstatt das ursprüngliche PowerPoint‑Verhalten zu speichern. Einige fortgeschrittene Effekte werden nicht unterstützt oder approximiert. Prüfen Sie die Tabelle der unterstützten Effekte und testen Sie die tatsächliche Präsentation vor dem Produktionseinsatz.

**Ändert das Vor‑ oder Zurückbewegen einer Shape ihre Animationsreihenfolge?**

Nein. Die z‑Reihenfolge einer Shape steuert die Überlappung, während die Sequenzreihenfolge und Auslöser die Wiedergabe der Animation bestimmen. Ändern Sie die Zeitleiste, wenn Sie eine andere Wiedergabereihenfolge benötigen.