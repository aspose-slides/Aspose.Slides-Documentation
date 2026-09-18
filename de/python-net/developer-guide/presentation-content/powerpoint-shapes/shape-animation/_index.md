---
title: Shape-Animationen in Präsentationen mit Python anwenden
linktitle: Shape-Animation
type: docs
weight: 60
url: /de/python-net/shape-animation/
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
- Effekt-Sound
- Animation anwenden
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Shape-Animationen, Timing, Sounds, Nach-Animation-Verhalten und animierten Text mit Aspose.Slides für Python via .NET hinzufügen, prüfen und anpassen."
---
## **Übersicht**

Um mit den einzelnen Verhaltensweisen innerhalb eines Effekts zu arbeiten oder Bewegungs‑Pfad‑Segmente zu bearbeiten, siehe [Benutzerdefinierte Animation](/slides/de/python-net/custom-animation/).

Aspose.Slides für Python via .NET stellt Folienanimationen als Effekte in einer Folientimeline dar. Ein Effekt hat ein Ziel‑Shape, einen Animationstyp und -untertyp, einen Trigger, Zeiteinstellungen und optionale Eigenschaften wie Sound oder Verhalten nach der Animation.

Die Timeline enthält zwei Arten von Sequenzen:

- Die **Hauptsequenz** wird abgespielt, wenn die Folie voranschreitet.
- Eine **interaktive Sequenz** beginnt, wenn ihr Trigger‑Shape angeklickt wird.

Da Textfelder, Bilder, Diagramme, Tabellen und andere Folienobjekte [IShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/ishape/) implementieren, verwenden Sie dieselbe Methode [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/) für die meisten Folieninhalte. Die verfügbaren Effekte sind in der Aufzählung [EffectType](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effecttype/) aufgeführt.

## **Shape‑Animationen hinzufügen**

Um eine Animation hinzuzufügen, holen Sie sich die Hauptsequenz der Folie und rufen Sie [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/) mit dem Ziel‑Shape, Effekt­typ, Untertyp und Trigger auf. Für einen Effekt, der startet, wenn ein anderes Shape angeklickt wird, erstellen Sie eine interaktive Sequenz, deren Trigger dieses andere Shape ist.

Das folgende Beispiel erstellt beide Animationsarten und speichert das Ergebnis in `shape-animations.pptx`.

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

Der Trigger bestimmt, wann ein Effekt startet:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effecttriggertype/) wartet auf einen Klick in der Hauptsequenz oder auf einen Klick auf das Trigger‑Shape in einer interaktiven Sequenz.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effecttriggertype/) startet zusammen mit dem vorherigen Effekt.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effecttriggertype/) startet, wenn der vorherige Effekt beendet ist.

Um ein Bild, Diagramm oder einen anderen Shape‑Typ zu animieren, übergeben Sie dieses Objekt an [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/) anstelle von `target_shape`. Für diagrammspezifische Gruppierungsoptionen siehe [Animierte Diagramme](/slides/de/python-net/animated-charts/).

## **Shape‑Animationen lesen**

Verwenden Sie [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/get_effects_by_shape/), wenn Sie das Ziel‑Shape kennen. Um jeden Effekt zu untersuchen, iterieren Sie über die Hauptsequenz und über jede interaktive Sequenz. Die Iteration verhindert die Annahme, dass eine Sequenz einen Effekt am Index `0` enthält.

Das folgende Beispiel erstellt ein Shape mit Haupt‑ und interaktiven Effekten, ermittelt die Effekte, die das Shape anvisieren, und iteriert anschließend über jede Sequenz auf der Folie.

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

Wenn Sie nur die Effekte für ein einzelnes Shape benötigen, ermitteln Sie das Shape zuerst nach Name, Platzhaltertyp oder einer anderen stabilen Eigenschaft; rufen Sie dann [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) auf. Gehen Sie nicht davon aus, dass das Shape am Index `0` immer das gewünschte Objekt ist.

## **Arbeiten mit geerbten Platzhalter‑Effekten**

Ein Platzhalter auf einer normalen Folie kann das Animationsverhalten vom entsprechenden Platzhalter auf der Layout‑Folie und der Master‑Folie erben. [Shape.get_base_placeholder](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_base_placeholder/) gibt diesen übergeordneten Platzhalter zurück oder `None`, wenn kein übergeordneter Platzhalter existiert.

Im folgenden Beispiel‑Präsentation hat die Fußzeile **Random Bars** auf der normalen Folie, **Split** auf der Layout‑Folie und **Fly In** auf der Master‑Folie.

![Animations‑Effekt der Fußzeile auf der normalen Folie](slide-shape-animation.png)

![Animations‑Effekt des Fußzeilen‑Platzhalters auf der Layout‑Folie](layout-shape-animation.png)

![Animations‑Effekt des Fußzeilen‑Platzhalters auf der Master‑Folie](master-shape-animation.png)

Das nächste Beispiel baut die Platzhalter‑Hierarchie selbst auf. Es fügt Effekte zu einem Master‑Platzhalter, einem Layout‑Platzhalter und dem entsprechenden Platzhalter auf einer normalen Folie hinzu. Jeder Aufruf von [Shape.get_base_placeholder](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_base_placeholder/) wird geprüft, bevor das zurückgegebene Shape verwendet wird.

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

## **Animations‑Timing ändern**

Der PowerPoint‑**Timing**‑Dialog entspricht den Eigenschaften von [Timing](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/).

![PowerPoint‑Timing‑Dialog für einen Animationseffekt](shape-animation.png)

- **Start** entspricht [Timing.trigger_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/trigger_type/).
- **Dauer** entspricht [Timing.duration](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/duration/), in Sekunden.
- **Verzögerung** entspricht [Timing.trigger_delay_time](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/trigger_delay_time/), in Sekunden.
- **Wiederholung** entspricht [Timing.repeat_count](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_until_next_click/) oder [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Zurückspulen nach dem Abspielen** entspricht [Timing.rewind](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/rewind/).

Dieses eigenständige Beispiel fügt einen Effekt hinzu, ändert dessen Timing über das von [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/) zurückgegebene Objekt und speichert das Ergebnis. Das Halten einer Referenz auf das zurückgegebene [Effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/) vermeidet einen unnötigen Indexzugriff.

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

Verwenden Sie bewusst nur einen Wiederholungsmodus. Die Kombination eines Wiederholungszählers mit einer „bis“-Flagge kann in verschiedenen Betrachtern verwirrende Ergebnisse erzeugen. Beim Ändern der Wiederholungsmodi setzen Sie zuerst [Timing.repeat_until_next_click](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_until_next_click/) und [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), bevor Sie [Timing.repeat_count](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_count/) setzen, da das Setzen einer Flagge auch den aktiven Wiederholungsmodus ändert.

## **Animations‑Sounds hinzufügen und extrahieren**

Ein Animationseffekt kann über [Effect.sound](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/sound/) auf eingebettete Audiodateien verweisen. [Effect.stop_previous_sound](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/stop_previous_sound/) weist einen Effekt an, den von einem früheren Effekt gestarteten Sound zu stoppen.

### **Einen Sound zu einem Effekt hinzufügen**

Das folgende Beispiel erwartet eine lokale Audiodatei namens `animation-sound.wav`. Es erstellt zwei Effekte, bettet diese Datei als Sound für den ersten Effekt ein und konfiguriert den zweiten Effekt so, dass er den Sound stoppt. Es verwendet die von [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/) zurückgegebenen Objekte, sodass kein Sequenz‑Index erforderlich ist.

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

### **Eingebettete Effekt‑Sounds extrahieren**

Das folgende Beispiel erwartet eine lokale Präsentation namens `presentation-with-animation-sounds.pptx`. Es durchsucht sowohl Haupt‑ als auch interaktive Sequenzen und schreibt jeden eingebetteten Effekt‑Sound in das Verzeichnis `extracted-animation-sounds`. Die Dateierweiterung wird aus dem Audio‑MIME‑Typ gewählt, der über [Audio.content_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/audio/content_type/) bereitgestellt wird.

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

Für große Audio‑Objekte verwenden Sie [Audio.get_stream](https://reference.aspose.com/slides/de/python-net/aspose.slides/audio/get_stream/) und kopieren den Stream in eine Datei, anstatt das gesamte Objekt in ein Byte‑Array zu laden.

## **Nach‑Animation‑Verhalten festlegen**

Die Option **After animation** steuert, was mit einem Shape geschieht, nachdem sein Effekt beendet ist.

![PowerPoint‑Effekt‑Optionen‑Dialog mit After‑Animation‑Einstellungen](shape-after-animation.png)

Die Aufzählung [AfterAnimationType](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/afteranimationtype/) unterstützt das Beibehalten des Shapes, das Ändern seiner Farbe, das Ausblenden nach der Animation oder das Ausblenden beim nächsten Klick. Wenn der Typ [AfterAnimationType.COLOR](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/afteranimationtype/) ist, setzen Sie zusätzlich [Effect.after_animation_color](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/after_animation_color/).

Dieses eigenständige Beispiel erstellt einen Effekt, legt sein Nach‑Animation‑Verhalten über das zurückgegebene Effekt‑Objekt fest und speichert das Ergebnis.

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

Wenn der Typ von [AfterAnimationType.COLOR](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/afteranimationtype/) geändert wird, wird die Einstellung für die Nach‑Animation‑Farbe gelöscht.

## **Text animieren**

Die Textanimation verfügt über zwei zusammengehörige Steuerungen:

- [TextAnimation.build_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/textanimation/build_type/) bestimmt, ob Absätze zusammen oder absatzweise erscheinen.
- [Effect.animate_text_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/animate_text_type/) bestimmt, ob Text auf einmal, Wort‑weise oder Buchstaben‑weise erscheint. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/delay_between_text_parts/) legt die Verzögerung zwischen Wörtern oder Buchstaben fest. Ein positiver Wert ist ein Prozentsatz der Effekt‑Dauer; ein negativer Wert ist eine Verzögerung in Sekunden.

Das folgende eigenständige Beispiel animiert die Wörter in einem Textfeld. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/buildtype/) deaktiviert das Absatze‑für‑Absatz‑Aufbauen, sodass die Wort‑Einstellung auf den gesamten Textrahmen angewendet wird.

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

Um ein Textfeld absatzweise aufzubauen, setzen Sie [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/buildtype/) (oder einen anderen Absatz‑Level). Um einen einzelnen Absatz mit eigenem Effekt zu targetieren, verwenden Sie die Überladung von [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/), die ein [IParagraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/iparagraph/) akzeptiert. Siehe [Animierter Text](/slides/de/python-net/animated-text/) für Beispiele auf Absatz‑Ebene.

## **Export‑ und Kompatibilitäts‑Hinweise**

- Das Speichern im PPT‑ oder PPTX‑Format bewahrt das Animationsmodell, aber die endgültige Wiedergabe wird vom Präsentations‑Viewer gesteuert.
- PDF und statische Bilder spielen keine Animationen ab. Verwenden Sie [HTML5‑Export](/slides/de/python-net/export-to-html5/), animierte GIFs oder [Video‑Konvertierung](/slides/de/python-net/convert-powerpoint-to-video/), wenn die Ausgabe Bewegung zeigen muss.
- Für HTML5 aktivieren Sie [Html5Options.animate_shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/html5options/animate_shapes/) und bei Bedarf [Html5Options.animate_transitions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/html5options/animate_transitions/).
- Die Videowiedergabe unterstützt viele gängige Eintritts‑, Betonungs‑, Austritts‑ und Bewegungs‑Pfad‑Effekte, aber nicht jeden PowerPoint‑Effekt. Prüfen Sie die aktuelle [unterstützten Animationen und Effekte](/slides/de/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) und testen Sie kritische Präsentationen mit Ihrer Ziel‑Aspose.Slides‑Version.
- Erweiterte benutzerdefinierte Effekte und aus anderen Präsentationsformaten importierte Effekte können in der Datei erhalten bleiben, werden jedoch in PowerPoint, HTML5 oder Video unterschiedlich gerendert. Validieren Sie das exportierte Ergebnis, anstatt sich ausschließlich auf den Effekt‑Namen zu verlassen.

## **FAQ**

**Warum wird eine Animation in PowerPoint angezeigt, aber nicht in einem PDF?**

PDF ist ein statisches Format, daher werden Animationen und Folienübergänge nicht abgespielt. Exportieren Sie zu HTML5, animiertem GIF oder Video, wenn Bewegung erhalten bleiben muss.

**Warum wird ein Effekt in einem Video anders wiedergegeben?**

Der Video‑Export rendert Animationen, anstatt das ursprüngliche PowerPoint‑Verhalten zu speichern. Einige erweiterte Effekte werden nicht unterstützt oder nur angenähert. Prüfen Sie die Tabelle der unterstützten Effekte und testen Sie die eigentliche Präsentation vor der Produktion.

**Ändert das Vor‑ oder Zurückverschieben eines Shapes seine Animationsreihenfolge?**

Nein. Die Z‑Reihenfolge eines Shapes steuert die Überlagerung, während die Sequenz‑Reihenfolge und Trigger die Animationswiedergabe bestimmen. Ändern Sie die Timeline, wenn Sie eine andere Wiedergabereihenfolge benötigen.