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
- Effekt Sound
- Animation anwenden
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formanimationen, Timing, Sounds, Nach‑Animations‑Verhalten und animierten Text mit Aspose.Slides für Python via .NET hinzufügen, inspizieren und anpassen."
---
## **Übersicht**

Aspose.Slides for Python via .NET stellt Folienanimationen als Effekte in einer Folien‑Zeitleiste dar. Ein Effekt hat eine Zielform, einen Animationstyp und -untertyp, einen Auslöser, Zeiteinstellungen und optionale Eigenschaften wie Sound oder ein Nach‑Animations‑Verhalten.

Die Zeitleiste enthält zwei Arten von Sequenzen:

- Die **Hauptsequenz** wird abgespielt, wenn die Folie fortschreitet.
- Eine **interaktive Sequenz** startet, wenn ihre Auslöserform angeklickt wird.

Da Textfelder, Bilder, Diagramme, Tabellen und andere Folienobjekte [IShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/ishape/) implementieren, verwenden Sie für die meisten Folieninhalte dieselbe Methode [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/) . Die verfügbaren Effekte sind in der Aufzählung [EffectType](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effecttype/) aufgelistet.

## **Formanimationen hinzufügen**

Um eine Animation hinzuzufügen, holen Sie die Hauptsequenz der Folie und rufen Sie [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/) mit der Zielform, dem Effekttyp, Untertyp und Auslöser auf. Für einen Effekt, der startet, wenn eine andere Form angeklickt wird, erstellen Sie eine interaktive Sequenz, deren Auslöser diese andere Form ist.

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

Der Auslöser steuert, wann ein Effekt beginnt:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effecttriggertype/) wartet in der Hauptsequenz auf einen Klick oder in einer interaktiven Sequenz auf einen Klick auf die Auslöserform.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effecttriggertype/) startet zusammen mit dem vorherigen Effekt.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effecttriggertype/) startet, wenn der vorherige Effekt beendet ist.

Um ein Bild, Diagramm oder einen anderen Formtyp zu animieren, übergeben Sie dieses Objekt an [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/) anstelle von `target_shape`. Für diagrammspezifische Gruppierungsoptionen siehe [Animated Charts](/slides/de/python-net/animated-charts/).

## **Formanimationen lesen**

Verwenden Sie [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) , wenn Sie die Zielform kennen. Um jeden Effekt zu inspizieren, iterieren Sie über die Hauptsequenz und jede interaktive Sequenz. Durch Iteration wird vermieden, anzunehmen, dass eine Sequenz einen Effekt am Index `0` enthält.

Das folgende Beispiel erstellt eine Form mit Haupt‑ und interaktiven Effekten, ruft die Effekte ab, die die Form anvisieren, und iteriert anschließend über jede Sequenz auf der Folie.

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

Wenn Sie nur die Effekte für eine einzelne Form benötigen, identifizieren Sie zunächst die Form nach Namen, Platzhaltertyp oder einer anderen stabilen Eigenschaft; rufen Sie dann [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) auf. Gehen Sie nicht davon aus, dass die Form am Index `0` stets das gewünschte Objekt ist.

## **Arbeiten mit geerbten Platzhalter‑Effekten**

Ein Platzhalter auf einer normalen Folie kann das Animationsverhalten vom entsprechenden Platzhalter auf ihrer Layout‑Folie und Master‑Folie erben. [Shape.get_base_placeholder](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_base_placeholder/) gibt diesen übergeordneten Platzhalter zurück oder `None`, wenn kein übergeordneter Platzhalter existiert.

In der folgenden Beispielpräsentation hat die Fußzeile **Random Bars** auf der normalen Folie, **Split** auf der Layout‑Folie und **Fly In** auf der Master‑Folie.

![Animationseffekt der Fußzeile auf der normalen Folie](slide-shape-animation.png)

![Animationseffekt der Fußzeile auf der Layout‑Folie](layout-shape-animation.png)

![Animationseffekt der Fußzeile auf der Master‑Folie](master-shape-animation.png)

Das nächste Beispiel erstellt die Platzhalterhierarchie selbst. Es fügt Effekte zu einem Master‑Platzhalter, einem Layout‑Platzhalter und dem entsprechenden Platzhalter auf einer normalen Folie hinzu. Jeder Aufruf von [Shape.get_base_placeholder](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_base_placeholder/) wird geprüft, bevor die zurückgegebene Form verwendet wird.

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

- **Start** entspricht [Timing.trigger_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/trigger_type/) .
- **Dauer** entspricht [Timing.duration](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/duration/) in Sekunden.
- **Verzögerung** entspricht [Timing.trigger_delay_time](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/trigger_delay_time/) in Sekunden.
- **Wiederholen** entspricht [Timing.repeat_count](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_until_next_click/) oder [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) .
- **Zurückspulen nach dem Abspielen** entspricht [Timing.rewind](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/rewind/) .

Dieses unabhängige Beispiel fügt einen Effekt hinzu, ändert sein Timing über das von [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/) zurückgegebene Objekt und speichert das Ergebnis. Das Beibehalten der zurückgegebenen [Effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/)‑Referenz vermeidet einen unnötigen Sammlungs‑Index.

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

Verwenden Sie bewusst nur einen Wiederholungsmodus. Das Kombinieren eines Wiederholungszählers mit einem „bis“-Flag kann in verschiedenen Betrachtern verwirrende Ergebnisse erzeugen. Beim Ändern der Wiederholungsmodi setzen Sie zuerst [Timing.repeat_until_next_click](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_until_next_click/) und [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) und erst danach [Timing.repeat_count](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_count/) , da das Setzen eines Flags ebenfalls den aktiven Wiederholungsmodus ändert.

## **Animations‑Sounds hinzufügen und extrahieren**

Ein Animationseffekt kann über [Effect.sound](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/sound/) auf eingebettetes Audio verweisen. [Effect.stop_previous_sound](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/stop_previous_sound/) weist einen Effekt an, Audio zu stoppen, das von einem früheren Effekt gestartet wurde.

### **Einen Sound zu einem Effekt hinzufügen**

Das folgende Beispiel erwartet eine lokale Audiodatei namens `animation-sound.wav`. Es erstellt zwei Effekte, bettet diese Datei als Sound für den ersten Effekt ein und konfiguriert den zweiten Effekt so, dass er den Sound stoppt. Es verwendet die von [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/) zurückgegebenen Objekte, daher ist kein Sequenz‑Index erforderlich.

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

Das folgende Beispiel erwartet eine lokale Präsentation namens `presentation-with-animation-sounds.pptx`. Es durchsucht sowohl die Haupt‑ als auch die interaktiven Sequenzen und schreibt jeden eingebetteten Effekt‑Sound in das Verzeichnis `extracted-animation-sounds`. Die Erweiterung wird aus dem von [Audio.content_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/audio/content_type/) bereitgestellten Audio‑MIME‑Typ ausgewählt.

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

## **Nach‑Animations‑Verhalten festlegen**

Die Option **After animation** steuert, was mit einer Form geschieht, nachdem ihr Effekt beendet ist.

![PowerPoint‑Effektoptionen‑Dialog, der After‑Animation‑Einstellungen zeigt](shape-after-animation.png)

Die Aufzählung [AfterAnimationType](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/afteranimationtype/) unterstützt das Belassen der Form unverändert, das Ändern ihrer Farbe, das Ausblenden nach der Animation oder das Ausblenden beim nächsten Klick. Wenn der Typ [AfterAnimationType.COLOR](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/afteranimationtype/) ist, setzen Sie außerdem [Effect.after_animation_color](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/after_animation_color/) .

Dieses unabhängige Beispiel erstellt einen Effekt, legt sein Nach‑Animations‑Verhalten über das zurückgegebene Effekt‑Objekt fest und speichert das Ergebnis.

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

Das Ändern des Typs von [AfterAnimationType.COLOR](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/afteranimationtype/) löscht die Nach‑Animations‑Farbeinstellung.

## **Text animieren**

Textanimation hat zwei verwandte Steuerungen:

- **[TextAnimation.build_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/textanimation/build_type/)** steuert, ob Absätze zusammen oder nach Absatz‑Ebene erscheinen.
- **[Effect.animate_text_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/animate_text_type/)** steuert, ob Text gleichzeitig, Wort für Wort oder Buchstabe für Buchstabe erscheint. **[Effect.delay_between_text_parts](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/delay_between_text_parts/)** legt die Verzögerung zwischen Worten oder Buchstaben fest. Ein positiver Wert ist ein Prozentsatz der Effekt‑Dauer; ein negativer Wert ist eine Verzögerung in Sekunden.

Das folgende unabhängige Beispiel animiert die Wörter in einem Textfeld. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/buildtype/) deaktiviert das Absatz‑für‑Absatz‑Aufbauen, sodass die Wort‑Einstellung auf den gesamten Textrahmen wirkt.

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

Um ein Textfeld absatzweise aufzubauen, setzen Sie [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/buildtype/) (oder eine andere Absatz‑Ebene). Um einen einzelnen Absatz mit einem eigenen Effekt anzusteuern, verwenden Sie die [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/)‑Überladung, die ein [IParagraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/iparagraph/) akzeptiert. Siehe [Animated Text](/slides/de/python-net/animated-text/) für Beispiele auf Absatz‑Ebene.

## **Export‑ und Kompatibilitäts‑Hinweise**

- Das Speichern im PPT‑ oder PPTX‑Format bewahrt das Animationsmodell, aber die endgültige Wiedergabe wird vom Präsentations‑Betrachter gesteuert.
- PDF und statische Bilder spielen keine Animationen ab. Verwenden Sie [HTML5 export](/slides/de/python-net/export-to-html5/), animierte GIFs oder [Video‑Konvertierung](/slides/de/python-net/convert-powerpoint-to-video/), wenn die Ausgabe Bewegungen zeigen muss.
- Für HTML5 aktivieren Sie [Html5Options.animate_shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/html5options/animate_shapes/) und bei Bedarf [Html5Options.animate_transitions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/html5options/animate_transitions/) .
- Video‑Rendering unterstützt viele gängige Eingangs‑, Betonungs‑, Ausgangs‑ und Bewegungs‑Pfad‑Effekte, aber nicht jeder PowerPoint‑Effekt wird unterstützt. Prüfen Sie die aktuelle [supported animations and effects](/slides/de/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) und testen Sie kritische Präsentationen mit Ihrer Ziel‑Aspose.Slides‑Version.
- Erweiterte benutzerdefinierte Effekte und aus anderen Präsentationsformaten importierte Effekte können in der Datei erhalten bleiben, werden jedoch in PowerPoint, HTML5 oder Video anders gerendert. Validieren Sie das exportierte Ergebnis, anstatt sich ausschließlich auf den Effekt‑Namen zu verlassen.

## **FAQ**

**Warum wird eine Animation in PowerPoint angezeigt, aber nicht in einem PDF?**

PDF ist ein statisches Format, daher werden Animationen und Folienübergänge nicht abgespielt. Exportieren Sie nach HTML5, animiertem GIF oder Video, wenn Bewegung erhalten bleiben muss.

**Warum wird ein Effekt im Video anders wiedergegeben?**

Der Video‑Export rendert Animationen, anstatt das ursprüngliche PowerPoint‑Verhalten zu speichern. Einige fortgeschrittene Effekte werden nicht unterstützt oder nur angenähert. Prüfen Sie die Tabelle der unterstützten Effekte und testen Sie die tatsächliche Präsentation vor dem Produktionseinsatz.

**Verändert das Vorwärts‑ oder Rückwärtsverschieben einer Form ihre Animationsreihenfolge?**

Nein. Die Z‑Reihenfolge einer Form steuert die Überlappung, während die Sequenzreihenfolge und die Auslöser die Animationswiedergabe bestimmen. Ändern Sie die Zeitleiste, wenn Sie eine andere Wiedergabereihenfolge benötigen.