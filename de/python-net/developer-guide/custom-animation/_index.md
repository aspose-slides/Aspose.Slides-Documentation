---
title: Erstellen und Ändern benutzerdefinierter Animationsverhalten in Python
linktitle: Benutzerdefinierte Animation
type: docs
weight: 151
url: /de/python-net/custom-animation/
keywords:
- benutzerdefinierte Animation
- Animationsverhalten
- Bewegungspfad
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen, inspizieren und modifizieren benutzerdefinierter Animationsverhalten und editierbarer Bewegungspfade in PowerPoint-Präsentationen mit Aspose.Slides für Python via .NET."
---
## **Übersicht**

Benutzerdefinierte Animationsverhalten ermöglichen die Kontrolle einzelner Vorgänge innerhalb eines Animationseffekts, z. B. das Ändern einer Farbe, das Drehen einer Form oder das Folgen eines editierbaren Bewegungsweges. Dieses Handbuch zeigt, wie man Verhaltensweisen erstellt und kombiniert, deren Timing konfiguriert, vorhandene Animationen inspiziert und ändert sowie prüft, dass deren Eigenschaften das Speichern und erneute Öffnen einer Präsentation überstehen.

Für vordefinierte Effekte und Klickauslöser siehe [Shape Animation](/slides/de/python-net/shape-animation/).

## **Verstehen des Animationsmodells**

Eine Animation ist strukturiert als **Timeline → Sequence → Effect → Behaviors**:

- Die Folien‑[timeline](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/timeline/) enthält ihre Hauptsequenz und interaktive Sequenzen.
- Eine [Sequence](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/) enthält Effekte, die ggf. unterschiedliche Formen ansprechen.
- Ein [Effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/) identifiziert Ziel‑Shape, Vorgabe, Subtyp und Timing des Effekts.
- [Effect.behaviors](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/behaviors/) enthält die Vorgänge, die den Effekt umsetzen: Farbe ändern, Bewegung, Drehung, Eigenschaft festlegen usw.

## **Einzelne Verhaltensweisen erstellen**

Rufen Sie [Sequence.add_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/sequence/add_effect/) auf, um einen Effekt zu erzeugen und auf seine [behaviors](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/behaviors/)‑Sammlung zuzugreifen. Eine Vorgabe kann diese Sammlung automatisch füllen. Bewahren Sie deren Vorgänge, wenn Sie die Vorgabe erweitern, oder verwenden Sie [clear](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorcollection/clear/), wenn Sie sie bewusst ersetzen wollen.

[BehaviorFactory](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorfactory/) erzeugt die acht unten illustrierten Verhaltenstypen. Bewegung wird in [Build a Motion Path](#build-a-motion-path) behandelt. Jeder Erstellungs‑Beispielcode ist ein vollständiges Programm; spätere Bearbeitungsbeispiele geben an, welche Ausgabedatei sie verwenden.

### **Rotation**

Verwenden Sie [create_rotation_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/), um eine Drehung zu erzeugen. [by](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/rotationeffect/by/) gibt einen relativen Winkel in Grad an; [from_address](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/rotationeffect/from_address/) und [to](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/rotationeffect/to/) geben Endpunkte an.

Das Beispiel startet mit einem Spin‑Effekt, ersetzt dessen Vorgabeverfahren durch ein Rotationsverhalten und gibt diesem Vorgang eine Dauer von zwei Sekunden. Ein relativer Winkel von 90 Grad bedeutet eine Vierteldrehung von der Ausgangsausrichtung der Form, sodass kein expliziter Startwinkel nötig ist.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` enthält eine Form und ein Rotationsverhalten. Die Sammlung, das Timing und die nachfolgenden Rotations‑Bearbeitungsbeispiele verwenden diese Datei.

### **Scale**

Verwenden Sie [create_scale_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) mit X/Y‑Prozentwerten: [from_address](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/scaleeffect/from_address/) und [to](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/scaleeffect/to/) beschreiben die Start‑ bzw. Endgröße, während [by](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/scaleeffect/by/) eine relative Änderung angibt. Hier bedeutet 100 % die Originalgröße.

Das Beispiel vergrößert beide Dimensionen von 100 % auf 125 % über zwei Sekunden. Gleiche horizontale und vertikale Prozentsätze erhalten das Seitenverhältnis der Form; unterschiedliche Werte würden eine Dimension stärker strecken als die andere.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Color**

Verwenden Sie [create_color_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/), um die Füllung von Blau zu Orange zu ändern. [from_address](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/coloreffect/from_address/) und [to](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/coloreffect/to/) sind Farben; [by](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/coloreffect/by/) ist ein Farb‑Offset. [Behavior.properties](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behavior/properties/) identifiziert das animierte Attribut.

Die feste Füllung der Form wird zu Beginn auf Blau gesetzt, passend zur Startfarbe der Animation. Die Auswahl des Fill‑Color‑Attributs sagt dem Verhalten, welchen Teil der Form es ändern soll; die Farb‑Endpunkte allein identifizieren das Attribut nicht. Der gespeicherte Effekt beschreibt einen zweisekündigen Übergang zu Orange.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Filter**

Verwenden Sie [create_filter_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/), um einen Wisch‑Effekt auszuwählen. [type](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/filtereffect/subtype/) und [reveal](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/filtereffect/reveal/) geben Filter, Richtung und ob die Form gezeigt oder verborgen werden soll, an.

Dieses Beispiel konfiguriert einen zweisekündigen Wisch, der die Form in Rechts‑Richtung enthüllt. Die Filtereinstellungen gehören zum Verhalten innerhalb des Effekts und werden daher konfiguriert, nachdem die ursprünglichen Vorgaben entfernt wurden.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Property**

Verwenden Sie [create_property_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/), um die Deckkraft zu animieren. [from_address](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/propertyeffect/to/) und [by](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/propertyeffect/by/) sind Zeichenketten, die über [value_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/propertyeffect/value_type/) und [calc_mode](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/propertyeffect/calc_mode/) interpretiert werden. Wählen Sie Endpunkte oder einen relativen Offset, anstatt alle drei willkürlich zu setzen.

Hier ist das ausgewählte Attribut Deckkraft, und die numerischen Zeichenketten stellen eine Änderung von 25 % Deckkraft zu voller Deckkraft dar. Lineare Interpolation beschreibt eine allmähliche Änderung zwischen diesen Werten. Beim Anpassen dieses Beispiels an ein anderes Attribut wählen Sie einen passenden Wert‑Typ und geeignete Endwerte.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Set**

Verwenden Sie [create_set_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/), um die Sichtbarkeit über [to](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/seteffect/to/) zuzuweisen. Ein Set‑Verhalten interpoliert nicht zwischen Endpunkten.

Das Beispiel wählt das Sichtbarkeits‑Attribut und weist den String `visible` zu, wenn das Verhalten ausgeführt wird. Das Rechteck ist in dieser Minimalpräsentation bereits sichtbar, sodass die Zuweisung allein möglicherweise keine offensichtliche visuelle Änderung erzeugt. Ein solcher Vorgang ist nützlich als Teil eines größeren Effekts, der ebenfalls steuert, wann die Form verborgen oder sichtbar wird.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Command**

Verwenden Sie [create_command_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) und konfigurieren Sie [type](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/commandeffect/command_string/) und [shape_target](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/commandeffect/shape_target/). Platzieren Sie eine WAV‑Aufnahme namens `sample.wav` im Arbeitsverzeichnis. Dieses Beispiel bindet sie mit [add_audio_frame_embedded](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) ein und verknüpft einen Play‑Befehl mit dem Audio‑Frame.

Der Audio‑Frame ist sowohl Ziel des Effekts als auch Ziel des Befehls. So wird die Wiedergabeanfrage mit der eingebetteten Aufnahme verknüpft; ein reiner Befehls‑String gibt nicht an, welches Medienobjekt gesteuert werden soll. Der Effekt ist so konfiguriert, dass er bei einem Klick während der Bildpräsentation startet.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

Beim Speichern wird der Befehl in `command.pptx` abgelegt; die Aufnahme wird nicht abgespielt. Die Wiedergabe erfordert einen Präsentations‑Player, der den Befehl und das zugehörige Medium unterstützt.

## **Verwalten der Behavior‑Collection**

[BehaviorCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorcollection/) unterstützt [add](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorcollection/remove/) und [remove_at](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorcollection/remove_at/). Dieses Beispiel öffnet `rotation.pptx`, fügt Skalierung hinzu, verschiebt sie vor die Drehung und entfernt die Drehung. Entfernen und erneutes Einfügen desselben Objekts ändert dessen gespeicherte Position, ohne eine Kopie zu erzeugen.

Die Abfolge der Änderungen wandelt die Sammlung von Drehung‑Skalierung zu Skalierung‑Drehung und schließlich zu nur Skalierung um. Indizes beziehen sich auf die aktuelle Sammlung, sodass das Entfernen den neuen Index der Drehung nach der Umordnung verwendet. Die abschließende Aufzählung bestätigt, welches Verhalten gespeichert wird.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

Die Ausgabe ist `ScaleEffect`: Es bleibt nur die Skalierung. Die Reihenfolge der Sammlung bestimmt nicht automatisch das sequentielle Abspielen von Verhaltensweisen. Löschen Sie die Sammlung nur, wenn Sie alle Vorgänge ersetzen wollen.

## **Timing der Behaviors konfigurieren**

[Behavior.timing](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behavior/timing/) gibt [Timing](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/) frei, unabhängig von [Effect.timing](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/timing/). Effect‑Timing plant den umschließenden Effekt; Behavior‑Timing beschreibt einen Vorgang darin.

### **Dauer, Verzögerung, Wiederholung und Beschleunigung festlegen**

Öffnen Sie `rotation.pptx` und setzen Sie [duration](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/duration/) sowie [trigger_delay_time](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/trigger_delay_time/) in Sekunden, dann konfigurieren Sie [repeat_count](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_count/). [accelerate](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/accelerate/) und [decelerate](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/decelerate/) sind Bruchteile der Dauer; ihr Summenwert darf höchstens 1 betragen.

Die Eingabedatei ist die im Rotations‑Beispiel erstellte, bei der das erste Verhalten als Drehung bekannt ist. Dieses Beispiel ändert ausschließlich das Timing dieses Verhaltens; der 90‑Grad‑Winkel bleibt unverändert. Die Trennung von Winkel und Timing erleichtert das Anpassen des Tempos, ohne die Animation neu zu erstellen.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

Das Verhalten nutzt eine Dauer von zwei Sekunden, eine halbe Sekunde Verzögerung und eine Wiederholungszahl von 3. Die ersten und letzten 20 % der Dauer werden für Beschleunigung bzw. Verzögerung verwendet.

Weitere Wiederholungs‑Policies umfassen [repeat_duration](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), und [repeat_until_next_click](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/repeat_until_next_click/); wählen Sie eine Policy, anstatt alle gleichzeitig zu aktivieren. [auto_reverse](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/timing/auto_reverse/) spielt die Animation nach dem Vorwärtslauf rückwärts ab. Beschleunigung und Verzögerung gelten für kontinuierliche Änderungen, nicht für diskrete Zuweisungen oder Befehle.

## **Einen Motion Path erstellen**

Verwenden Sie [create_motion_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/), um Bewegung zu erzeugen. Seine [from_address](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioneffect/to/) und [by](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioneffect/by/) beschreiben prozentbasierte Koordinaten oder Offsets. Für eine editierbare Route erzeugen Sie einen [MotionPath](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motionpath/) und weisen ihn [MotionEffect.path](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioneffect/path/) zu. [MotionPath](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motionpath/) speichert die Pfadbefehle.

[MotionCommandPathType](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioncommandpathtype/) wählt die Operation:

| Command | Points | Meaning |
| --- | --- | --- |
| MOVE_TO | One | Set the starting position. |
| LINE_TO | One | Move along a straight segment to its endpoint. |
| CURVE_TO | Three | Follow a cubic curve defined by two control points and an endpoint. |
| CLOSE_LOOP | None | Return to the starting position. |
| END | None | Finish the path. |

[MotionPathPointsType](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motionpathpointstype/) beschreibt die Eigenschaften der Punktbearbeitung, z. B. Ecke oder glatter Punkt. Es ersetzt nicht den Befehlstyp. Verwenden Sie für das Kurven‑Beispiel unten einen Curve‑Punkttyp und für die geraden Segmente einen Corner‑Punkttyp.

Pfadkoordinaten werden an die Folienmaße normalisiert: Eine X‑Verschiebung von 0.25 entspricht einem Viertel der Folienbreite, nicht 0.25 Punkten. Positive Y‑Werte verlaufen nach unten. Absolute Befehle geben Positionen im Pfad‑Koordinatensystem an; relative Befehle geben Offsets zur aktuellen Position an. Das ist getrennt von [origin](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioneffect/origin/), das den Referenzrahmen des Pfads wählt, und [path_edit_mode](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), das steuert, wie sich der Pfad bewegt, wenn die Form verschoben wird.

### **Geraden Pfad erstellen**

Erstellen Sie ein Bewegungs‑Verhalten mit einem Startpunkt, einem geraden Segment und einem End‑Befehl. [MotionPath.add](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motionpath/add/) nimmt den Befehlstyp, seine Punkte, den Punkt‑Typ und ein Flag für relative Koordinaten entgegen.

Der Startbefehl legt (0, 0) fest, und die Linie endet bei (0.25, 0), wodurch die Route eine horizontale Verschiebung von einem Viertel der Folienbreite erhält. Der End‑Befehl hat keine Koordinatenpunkte. Sobald der Pfad zugewiesen ist, verbindet das Hinzufügen des Bewegungs‑Verhaltens zum Effekt diese Route mit dem Rechteck.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` enthält ein Bewegungs‑Verhalten mit drei Pfadbefehlen. Die folgenden Beispiele zur Dateibearbeitung nutzen diese bekannte Struktur.

### **Absolute vs. relative Koordinaten vergleichen**

Diese beiden Pfadobjekte beschreiben dieselbe Route. Der absolute Befehl endet bei (0.3, 0.1); der relative Befehl addiert (0.1, 0.1) zur aktuellen Position (0.2, 0).

Beide Pfade starten an derselben Position. Für die relative Linie addieren Sie die X‑ und Y‑Offsets zur aktuellen Position, um den Endpunkt zu erhalten; für die absolute Linie lesen Sie den Endpunkt direkt. Das Umstellen des Flags, ohne die Koordinaten zu konvertieren, würde eine andere Route beschreiben.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

Weisen Sie entweder den einen oder den anderen Pfad einem Bewegungs‑Verhalten zu, um ihn in einer Präsentation zu verwenden. Das abschließende boolesche Argument wählt relative Koordinaten für diesen Befehl.

### **Eine Linie durch eine Kurve ersetzen**

Öffnen Sie `motion.pptx` und ersetzen Sie den Linien‑Befehl durch eine kubische Kurve. Geben Sie zuerst die beiden Steuerpunkte und dann den Endpunkt an.

Die Startposition wird vom vorhergehenden Befehl bereitgestellt. Die ersten beiden Punkte formen die Kurve, der dritte ist das Ziel; sie sind also nicht drei aufeinanderfolgende Ziele. Das gleichzeitige Aktualisieren von Befehls‑Typ, Punkt‑Bearbeitungstyp und Punkte‑Array hält das Segment konsistent mit seiner neuen Geometrie.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

Der Pfad in `curve.pptx` hat weiterhin drei Befehle; sein mittlerer Befehl definiert nun eine Kurve.

## **Gespeicherten Pfad inspizieren und bearbeiten**

Jeder [MotionCmdPath](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioncmdpath/) stellt [points](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioncmdpath/points_type/) und [is_relative](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motioncmdpath/is_relative/) bereit. Die folgenden Beispiele verwenden den bekannten Dreifach‑Befehl‑Pfad in `motion.pptx`. Für beliebige Eingaben lokalisieren Sie den gewünschten Effekt und prüfen Sie Befehls‑Typen und Punktzahlen, bevor Sie per Index bearbeiten.

### **Befehle und Koordinaten lesen**

Lesen Sie den Pfad, ohne ihn zu verändern. End‑ und Close‑Loop‑Befehle benötigen keine Punkte, daher sollte ein `None`‑Punkte‑Array erlaubt sein.

Die Ausgabe paart jeden Befehl mit seinem Flag für relative Koordinaten, bevor die Punkte aufgelistet werden. So können Sie einen Endpunkt von einem Offset unterscheiden, bevor Sie den Pfad ändern. Eine Kurve würde drei Punkte auflisten, während die gerade Linie in dieser Datei nur einen Punkt listet.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

Die Auflistung enthält einen Startpunkt, eine absolute Linie, die bei (0.25, 0) endet, und einen End‑Befehl.

### **Endpunkt ändern**

Öffnen Sie `motion.pptx` und ersetzen Sie das Punkte‑Array der Linie, um deren Endpunkt zu verschieben.

Im Eingabefile hat Index 0 den Startbefehl und Index 1 die Linie. Das Ersetzen des einzigen Punktes der Linie ändert ihr Ziel, ohne den Befehlstyp, das Timing oder die Position in der Sammlung zu ändern. Da der Befehl absolute Koordinaten verwendet, gibt das neue Paar eine Position anstelle eines zusätzlichen Offsets an.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

Die Linie in `motion-endpoint.pptx` endet bei (0.4, 0.1); die Originaldatei bleibt unverändert.

### **Ein Segment ersetzen**

Verwenden Sie [insert](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motionpath/insert/) und [remove_at](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/motionpath/remove_at/), um die Linie in `motion.pptx` zu ersetzen. Das Einfügen verschiebt die alte Linie zu Index 2.

Dies demonstriert das Ersetzen eines Befehlsobjekts statt das Bearbeiten seiner bestehenden Koordinaten. Nach dem Einfügen enthält die Sammlung temporär den Startbefehl, die neue Linie, die alte Linie und den End‑Befehl. Das Entfernen von Index 2 wirft die alte Linie weg und lässt die neue Route bestehen.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

Der gespeicherte Pfad hat weiterhin drei Befehle, wobei die neue Linie bei (0.2, 0.1) endet und der End‑Befehl zuletzt steht.

## **Ein vorhandenes Verhalten ändern und prüfen**

Wenn der Index des Verhaltens unbekannt ist, wählen Sie es nach Typ. Dieses Beispiel öffnet `rotation.pptx`, findet dessen [RotationEffect](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/rotationeffect/), ändert den Winkel und prüft den gespeicherten Wert nach erneutem Öffnen.

Der Typ‑Check lässt die Schleife Verhaltensweisen überspringen, die keine Drehungen sind. Der zweite Ladevorgang liest die gespeicherte Datei in ein separates Präsentationsobjekt, sodass der Vergleich persistente Daten prüft und nicht den noch im Speicher gehaltenen Wert. Dieses Beispiel geht weiterhin davon aus, dass der bekannte Effekt zuerst in der Hauptsequenz steht; die Auswahl nach Typ findet den korrekten Effekt nicht in einer beliebigen Präsentation.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

Die Ausgabe lautet `Rotation preserved: True`. Wenden Sie dasselbe Typ‑Check‑Muster auf andere Verhaltensweisen an. Für einen vollständigen Erhaltungs‑Check vergleichen Sie Ziel‑Shape, Effekt, Verhaltenstypen und -reihenfolge, Timing und Pfadbefehle. Verwenden Sie eine numerische Toleranz für Gleitkommawerte. Für Präsentationen mit unbekannter Animationsstruktur siehe [Read Shape Animations](/slides/de/python-net/shape-animation/#read-shape-animations) zur Traversierung von Haupt‑ und Interaktivsequenzen.

## **Verhaltensreihenfolge, Vorgaben und Wiedergabe**

Die Reihenfolge in [BehaviorCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behaviorcollection/) ist die gespeicherte Reihenfolge der Vorgänge eines Effekts. Sie ist keine Wiedergabeliste, bei der jedes Verhalten automatisch auf das vorherige wartet. Timing und der umschließende Effekt bestimmen die Planung. Verhaltensweisen können überlappen, und Vorgänge am selben Attribut können über [additive](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behavior/additive/) und [accumulate](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/behavior/accumulate/) interagieren. Verwenden Sie das reine Umordnen der Sammlung nicht, um “verschieben, dann drehen” zu planen; nutzen Sie explizites Timing oder separate Effekte wie in [Shape Animation](/slides/de/python-net/shape-animation/) beschrieben.

Der [type](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/type/) und [subtype](https://reference.aspose.com/slides/de/python-net/aspose.slides.animation/effect/subtype/) des Effekts beschreiben dessen Vorgabe. Sie stellen keine vollständige Beschreibung eines bearbeiteten Verhaltensbaums dar. Wählen Sie Vorgabe und Subtyp, bevor Sie Verhaltensweisen anpassen: Das Ändern der Vorgabe kann die Sammlung neu aufbauen und Ihre benutzerdefinierten Vorgänge verwerfen. Beispiel: Das Ändern eines angepassten Spin‑Effekts zu Fade kann das Rotations‑Verhalten durch Set‑ und Filter‑Verhalten ersetzen. Prüfen Sie die Sammlung erneut nach einer Änderung der Vorgabe oder des Subtyps. Das Löschen von Vorgabe‑Verhalten kann auch Sichtbarkeits‑ oder Initialisierungs‑Vorgänge entfernen, die die Vorgabe benötigt. Die Beispiele verwenden sichtbare Formen und ersetzen die Verhaltensweisen; sie rekonstruieren nicht jede Vorgabe‑Implementierung.

## **Formatkompatibilität**

Ein erhaltenes Verhaltens‑Baumdiagramm garantiert nicht identische Wiedergabe in jedem Viewer oder Export‑Renderer. Prüfen Sie die gespeicherten Daten und die gerenderte Ausgabe separat.

| Format oder Ausgabe | Was zu prüfen ist |
| --- | --- |
| PPTX | Als primäres Format für diese Beispiele verwenden. Nach dem erneuten Öffnen die editierbare Verhaltensstruktur prüfen und dann die Wiedergabe in der gewünschten PowerPoint‑Version testen. |
| PPT | Das alte Binärformat kann von PPTX abweichen. Einen separaten Speicher‑und‑Lade‑Zyklus sowie die Wiedergabe testen; schließen Sie nicht daraus, dass jede benutzerdefinierte Kombination unterstützt wird, nur weil PPTX funktioniert. |
| PDF, PNG, JPEG und weitere statische Folienbilder | Enthalten eine statische Folien‑Darstellung, keine abspielbare Verhaltens‑Timeline und keinen garantierten End‑Animations‑Frame. |
| [HTML5](/slides/de/python-net/export-to-html5/) | Kann unterstützte Animationen abspielen, wenn Shape‑Animation in den Exportoptionen aktiviert ist. Benutzerdefinierte Kombinationen im Browser testen. |
| [Animated GIF](/slides/de/python-net/convert-powerpoint-to-animated-gif/) | Speichert gerenderte Frames, nicht editierbare Verhaltensweisen oder klick‑gesteuerte Interaktion. Das tatsächlich gerenderte Motion prüfen. |
| [Video](/slides/de/python-net/convert-powerpoint-to-video/) | Rendert Animations‑Frames und kodiert sie als Video. Unterstützung ist auf die im Renderer [unterstützten Animationen und Effekte](/slides/de/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) beschränkt; Befehle und interaktive Events werden nicht zu einer editierbaren Timeline. |

## **FAQ**

**Warum enthält mein Effekt Verhaltensweisen, bevor ich welche hinzugefügt habe?**

Das Erzeugen eines vordefinierten Effekts kann seine zugrunde liegenden Vorgänge erzeugen. Inspizieren Sie sie, bevor Sie entscheiden, die Vorgabe zu erweitern oder ihre Verhaltensweisen zu ersetzen.

**Bewirkt das Verschieben eines Verhaltens an den Anfang, dass es zuerst abgespielt wird?**

Nicht notwendigerweise. Die Reihenfolge der Sammlung ersetzt nicht das Timing. Prüfen Sie Verzögerungen, Dauern und Wechselwirkungen zwischen Vorgängen am selben Attribut.

**Warum hat ein End‑Befehl keine Punkte?**

Er markiert das Ende des Pfads und benötigt keine Koordinaten. Beim Inspizieren eines aus einer Datei gelesenen Pfads auf ein `None`‑Punkte‑Array prüfen.

**Ist ein erfolgreicher Rundlauf ausreichend, um die Wiedergabe zu bestätigen?**

Nein. Das erneute Öffnen bestätigt die Erhaltung der geprüften Eigenschaften. Testen Sie den Präsentations‑Player oder den animierten Export separat, um das visuelle Verhalten zu verifizieren.