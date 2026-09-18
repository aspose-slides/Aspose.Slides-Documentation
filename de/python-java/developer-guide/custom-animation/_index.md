---
title: Erstellen und Ändern benutzerdefinierter Animationsverhalten in Python über Java
linktitle: Benutzerdefinierte Animation
type: docs
weight: 151
url: /de/python-java/custom-animation/
keywords:
- benutzerdefinierte Animation
- Animationsverhalten
- Bewegungspfad
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen, prüfen und ändern benutzerdefinierter Animationsverhalten und editierbarer Bewegungspfade in PowerPoint-Präsentationen mit Aspose.Slides für Python über Java."
---
## **Übersicht**

Benutzerdefinierte Animationsverhalten ermöglichen es Ihnen, einzelne Operationen innerhalb eines Animationseffekts zu steuern, z. B. das Ändern einer Farbe, das Drehen einer Form oder das Folgen eines editierbaren Bewegungspfads. Dieser Leitfaden zeigt, wie man Verhaltensweisen erstellt und kombiniert, deren Timing konfiguriert, vorhandene Animationen inspiziert und bearbeitet sowie überprüft, dass ihre Eigenschaften das Speichern und erneute Öffnen einer Präsentation überstehen.

Für vordefinierte Effekte und Klick‑Trigger siehe [Shape Animation](/slides/de/python-java/shape-animation/).

## **Verstehen des Animationsmodells**

Eine Animation ist strukturiert als **Timeline → Sequence → Effect → Behaviors**:

- Die Methode [getTimeline](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getTimeline) gibt die Folien‑Timeline zurück, die ihre Hauptsequenz und interaktive Sequenzen enthält.
- Eine [Sequence](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/) enthält Effekte, die ggf. unterschiedliche Formen ansteuern.
- Ein [Effect](https://reference.aspose.com/slides/de/python-java/aspose.slides/effect/) identifiziert Ziel‑Shape, Vorgabe, Subtyp und Effekt‑Timing.
- Die Sammlung, die von [Effect.getBehaviors](https://reference.aspose.com/slides/de/python-java/aspose.slides/effect/#getBehaviors) zurückgegeben wird, enthält die Operationen, die den Effekt implementieren: Farbwechsel, Verschiebung, Drehung, Setzen einer Eigenschaft usw.

## **Einzelne Verhaltensweisen erstellen**

Rufen Sie [Sequence.addEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/#addEffect) auf, um einen Effekt zu erstellen und auf die Sammlung [getBehaviors](https://reference.aspose.com/slides/de/python-java/aspose.slides/effect/#getBehaviors) zuzugreifen. Eine Vorgabe kann diese Sammlung automatisch füllen. Behalten Sie deren Operationen, wenn Sie die Vorgabe erweitern, oder verwenden Sie [clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorcollection/#clear), wenn Sie sie bewusst ersetzen.

[BehaviorFactory](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorfactory/) erzeugt die acht unten illustrierten Verhaltenstypen. Motion wird in [Build a Motion Path](#build-a-motion-path) behandelt. Jeder Schnipsel enthält die notwendigen Importe und startet bei Bedarf die JVM. Java‑Punktobjekte und -Arrays werden über JPype erzeugt, wo die API sie benötigt. Spätere Bearbeitungsbeispiele geben an, welche Ausgabedatei sie verwenden.

### **Drehung**

Verwenden Sie [createRotationEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorfactory/#createRotationEffect), um eine Drehung zu erzeugen. [getBy](https://reference.aspose.com/slides/de/python-java/aspose.slides/rotationeffect/#getBy) gibt einen relativen Winkel in Grad an; [getFrom](https://reference.aspose.com/slides/de/python-java/aspose.slides/rotationeffect/#getFrom) und [getTo](https://reference.aspose.com/slides/de/python-java/aspose.slides/rotationeffect/#getTo) geben die Endpunkte an.

Das Beispiel startet mit einem Spin‑Effekt, ersetzt dessen Vorgabe‑Operationen durch ein Dreh‑Verhalten und gibt dieser Operation eine Dauer von zwei Sekunden. Ein relativer Winkel von 90 Grad entspricht einer Vierteldrehung von der Ausgangsausrichtung der Form, sodass kein expliziter Startwinkel nötig ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` enthält eine Form und ein Dreh‑Verhalten. Die Sammlung, das Timing und die nachfolgenden Beispiele zur Dreh‑Bearbeitung verwenden diese Datei.

### **Skalierung**

Verwenden Sie [createScaleEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorfactory/#createScaleEffect) mit X/Y‑Prozentwerten: [getFrom](https://reference.aspose.com/slides/de/python-java/aspose.slides/scaleeffect/#getFrom) und [getTo](https://reference.aspose.com/slides/de/python-java/aspose.slides/scaleeffect/#getTo) beschreiben die Anfangs‑ bzw. Endgröße, während [getBy](https://reference.aspose.com/slides/de/python-java/aspose.slides/scaleeffect/#getBy) eine relative Änderung angibt. Hier bedeutet 100 die Originalgröße.

Das Beispiel vergrößert beide Dimensionen von 100 % auf 125 % über zwei Sekunden. Gleiche horizontale und vertikale Prozentsätze erhalten das Seitenverhältnis der Form; unterschiedliche Prozentsätze würden eine Dimension stärker strecken als die andere.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Farbe**

Verwenden Sie [createColorEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorfactory/#createColorEffect), um die Füllung von Blau nach Orange zu ändern. [getFrom](https://reference.aspose.com/slides/de/python-java/aspose.slides/coloreffect/#getFrom) und [getTo](https://reference.aspose.com/slides/de/python-java/aspose.slides/coloreffect/#getTo) sind Farben; [getBy](https://reference.aspose.com/slides/de/python-java/aspose.slides/coloreffect/#getBy) ist ein Farb‑Offset. [Behavior.getProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/behavior/#getProperties) identifiziert das animierte Attribut.

Die feste Füllung der Form wird zu Beginn auf Blau gesetzt, passend zur Startfarbe der Animation. Das Auswählen des Füll‑Farb‑Attributs sagt dem Verhalten, welchen Teil der Form es ändern soll; die reinen Farb‑Endpunkte identifizieren dieses Attribut nicht. Der gespeicherte Effekt beschreibt einen zweisekündigen Übergang nach Orange.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Filter**

Verwenden Sie [createFilterEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorfactory/#createFilterEffect), um einen Wisch‑Effekt auszuwählen. [getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/de/python-java/aspose.slides/filtereffect/#getSubtype) und [getReveal](https://reference.aspose.com/slides/de/python-java/aspose.slides/filtereffect/#getReveal) geben den Filter, die Richtung und ob die Form sichtbar gemacht oder verborgen werden soll, an.

Dieses Beispiel konfiguriert einen zweisekündigen Wisch, der die Form mit dem Subtyp „right‑direction“ sichtbar macht. Die Filtereinstellungen gehören zu dem Verhalten innerhalb des Effekts und werden daher konfiguriert, nachdem die ursprünglichen Vorgabe‑Operationen entfernt wurden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Eigenschaft**

Verwenden Sie [createPropertyEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorfactory/#createPropertyEffect), um die Deckkraft zu animieren. [getFrom](https://reference.aspose.com/slides/de/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/de/python-java/aspose.slides/propertyeffect/#getTo) und [getBy](https://reference.aspose.com/slides/de/python-java/aspose.slides/propertyeffect/#getBy) sind Zeichenketten, die über [getValueType](https://reference.aspose.com/slides/de/python-java/aspose.slides/propertyeffect/#getValueType) und [getCalcMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/propertyeffect/#getCalcMode) interpretiert werden. Wählen Sie Endpunkte oder einen relativen Offset, anstatt indiscriminately alle drei zu setzen.

Hier ist das gewählte Attribut Deckkraft, und die numerischen Zeichenketten stellen einen Wechsel von 25 % Deckkraft zu voller Deckkraft dar. Lineare Interpolation beschreibt einen allmählichen Wechsel zwischen diesen Werten. Wenn Sie dieses Beispiel auf ein anderes Attribut anwenden, wählen Sie einen passenden Wertetyp und passende Endpunktwerte für dieses Attribut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Set**

Verwenden Sie [createSetEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorfactory/#createSetEffect), um die Sichtbarkeit über [getTo](https://reference.aspose.com/slides/de/python-java/aspose.slides/seteffect/#getTo) zuzuweisen. Ein Set‑Verhalten interpoliert nicht zwischen Endpunkten.

Das Beispiel wählt das Sichtbarkeits‑Attribut und weist die Zeichenkette `visible` zu, wenn das Verhalten ausgeführt wird. Das Rechteck ist in dieser Minimalpräsentation bereits sichtbar, sodass die Zuweisung allein möglicherweise keine offensichtliche visuelle Änderung bewirkt. Eine solche Operation ist nützlich als Teil eines größeren Effekts, der ebenfalls steuert, wann die Form verborgen oder sichtbar wird.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Befehl**

Verwenden Sie [createCommandEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorfactory/#createCommandEffect) und konfigurieren Sie [getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/de/python-java/aspose.slides/commandeffect/#getCommandString) und [getShapeTarget](https://reference.aspose.com/slides/de/python-java/aspose.slides/commandeffect/#getShapeTarget). Legen Sie eine WAV‑Aufnahme mit dem Namen `sample.wav` im Arbeitsverzeichnis ab. Dieses Beispiel bettet sie mit [addAudioFrameEmbedded](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) ein und hängt einen Abspiel‑Befehl an den Audio‑Frame an.

Der Audio‑Frame ist sowohl Ziel des Effekts als auch Ziel des Befehls. Dadurch wird die Abspiel‑Anforderung mit der eingebetteten Aufnahme verknüpft; ein reiner Befehls‑String identifiziert nicht, welches Medienobjekt er steuern soll. Der Effekt ist so konfiguriert, dass er beim Klicken während der Vorführung startet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Speichern legt den Befehl in `command.pptx` ab; es spielt die Aufnahme nicht ab. Die Wiedergabe erfordert einen Vorführungs‑Player, der den Befehl und sein Medien‑Ziel unterstützt.

## **Verwalten der Verhaltenssammlung**

[BehaviorCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorcollection/) unterstützt [add](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorcollection/#remove) und [removeAt](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorcollection/#removeAt). Dieses Beispiel öffnet `rotation.pptx`, fügt Skalierung hinzu, verschiebt sie vor die Drehung und entfernt die Drehung. Das Entfernen und erneute Einfügen desselben Objekts ändert dessen gespeicherte Position, ohne eine Kopie zu erzeugen.

Die Reihenfolge der Bearbeitungen ändert die Sammlung von Drehung–Skalierung zu Skalierung–Drehung und schließlich zu nur Skalierung. Indizes beziehen sich auf die aktuelle Sammlung, sodass das Entfernen den neuen Index der Drehung nach der Umordnung verwendet. Die abschließende Aufzählung bestätigt, welches Verhalten gespeichert wird.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Ausgabe ist `ScaleEffect`: Nur die Skalierung bleibt erhalten. Die Reihenfolge der Sammlung bestimmt nicht automatisch, dass Verhaltensweisen nacheinander ablaufen. Leeren Sie die Sammlung nur, wenn Sie alle Operationen ersetzen wollen.

## **Verhaltenstiming konfigurieren**

[Behavior.getTiming](https://reference.aspose.com/slides/de/python-java/aspose.slides/behavior/#getTiming) stellt [Timing](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/) bereit, unabhängig von [Effect.getTiming](https://reference.aspose.com/slides/de/python-java/aspose.slides/effect/#getTiming). Effekt‑Timing plant den umgebenden Effekt; Verhalten‑Timing beschreibt eine Operation darin.

### **Dauer, Verzögerung, Wiederholung und Beschleunigung festlegen**

Öffnen Sie `rotation.pptx` und setzen Sie die Dauer ([getDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getDuration)) sowie die Trigger‑Verzögerungszeit ([getTriggerDelayTime](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getTriggerDelayTime)) in Sekunden, dann konfigurieren Sie die Wiederholungszahl über [setRepeatCount](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getAccelerate) und [getDecelerate](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getDecelerate) sind Bruchteile der Dauer; ihre Summe darf höchstens 1 betragen.

Die Eingabedatei ist die im Dreh‑Beispiel erstellte, wobei das erste Verhalten als Drehung bekannt ist. Dieses Beispiel ändert nur das Timing dieses Verhaltens; sein 90‑Grad‑Winkel bleibt unverändert. Das getrennte Handhaben von Winkel und Timing erleichtert das Anpassen des Tempos, ohne die Animation neu aufzubauen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Verhalten nutzt eine Dauer von zwei Sekunden, eine halbe Sekunde Verzögerung und eine Wiederholungszahl von 3. Die ersten und letzten 20 % seiner Dauer werden für Beschleunigung bzw. Verzögerung verwendet.

Weitere Wiederholungs‑Richtlinien umfassen [getRepeatDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) und [getRepeatUntilNextClick](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getRepeatUntilNextClick); wählen Sie eine Richtlinie, anstatt alle gleichzeitig zu aktivieren. [getAutoReverse](https://reference.aspose.com/slides/de/python-java/aspose.slides/timing/#getAutoReverse) lässt die Animation nach dem Vorwärtspass rückwärts abspielen. Beschleunigung und Verzögerung gelten für kontinuierliche Änderungen, nicht für diskrete Zuweisungen oder Befehle.

## **Bewegungspfad erstellen**

Verwenden Sie [createMotionEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorfactory/#createMotionEffect), um Motion zu erzeugen. Seine [getFrom](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioneffect/#getTo) und [getBy](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioneffect/#getBy) beschreiben prozentbasierte Koordinaten oder Offsets. Für eine editierbare Route erzeugen Sie ein [MotionPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/motionpath/) und weisen es mit [MotionEffect.setPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioneffect/#setPath) zu. [MotionPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/motionpath/) speichert die Pfad‑Befehle.

[MotionCommandPathType](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioncommandpathtype/) wählt die Operation:

| Befehl | Punkte | Bedeutung |
| --- | --- | --- |
| MoveTo | One | Set the starting position. |
| LineTo | One | Move along a straight segment to its endpoint. |
| CurveTo | Three | Follow a cubic curve defined by two control points and an endpoint. |
| CloseLoop | None | Return to the starting position. |
| End | None | Finish the path. |

[MotionPathPointsType](https://reference.aspose.com/slides/de/python-java/aspose.slides/motionpathpointstype/) beschreibt Eigenschaften der Punktbearbeitung, wie Eck‑ oder glatte Punkte. Es ersetzt nicht den Befehls‑Typ. Verwenden Sie für das Kurven‑Beispiel unten den Kurven‑Punkt‑Typ und für die geraden Segmente den Eck‑Punkt‑Typ.

Pfad‑Koordinaten sind auf Folien‑Abmessungen normiert: Eine X‑Verschiebung von 0.25 entspricht einem Viertel der Folienbreite, nicht 0.25 Punkten. Positives Y läuft nach unten. Absolute Befehle geben Positionen im Pfad‑Koordinatensystem an; relative Befehle geben Offsets zur aktuellen Position an. Das ist getrennt von [getOrigin](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioneffect/#getOrigin), das den Referenzrahmen des Pfades wählt, und [getPathEditMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioneffect/#getPathEditMode), das steuert, wie sich der Pfad bewegt, wenn die Form verschoben wird.

### **Geraden Pfad erstellen**

Erzeugen Sie ein Motion‑Verhalten mit einem Startpunkt, einem geraden Segment und einem End‑Befehl. [MotionPath.add](https://reference.aspose.com/slides/de/python-java/aspose.slides/motionpath/#add) nimmt den Befehls‑Typ, seine Punkte, den Punkt‑Typ und ein Flag für relative Koordinaten.

Der Start‑Befehl legt (0, 0) fest, und die Linie endet bei (0.25, 0), wodurch die Route einen horizontalen Abstand von einem Viertel der Folienbreite hat. Der End‑Befehl hat keine Koordinatenpunkte. Sobald der Pfad zugewiesen ist, verbindet das Hinzufügen des Motion‑Verhaltens zum Effekt diese Route mit dem Rechteck.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` enthält ein Motion‑Verhalten mit drei Pfad‑Befehlen. Die folgenden Beispiele zum Datei‑Bearbeiten nutzen diese bekannte Struktur.

### **Absolute und relative Koordinaten vergleichen**

Diese beiden Pfad‑Objekte beschreiben dieselbe Route. Der absolute Befehl endet bei (0.3, 0.1); der relative Befehl addiert (0.1, 0.1) zur aktuellen Position, also (0.2, 0).

Beide Pfade starten an derselben Position. Für die relative Linie addieren Sie deren X‑ und Y‑Offsets zur aktuellen Position, um den Endpunkt zu erhalten; für die absolute Linie lesen Sie den Endpunkt direkt. Das Flag zu wechseln, ohne die Koordinaten zu konvertieren, würde eine andere Route ergeben.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

Weisen Sie entweder den einen oder den anderen Pfad einem Motion‑Verhalten zu, um ihn in einer Präsentation zu verwenden. Das abschließende boolesche Argument wählt relative Koordinaten für diesen Befehl.

### **Linie durch Kurve ersetzen**

Öffnen Sie `motion.pptx` und ersetzen Sie dessen Linien‑Befehl durch eine kubische Kurve. Geben Sie zuerst die beiden Steuerpunkte an, gefolgt vom Endpunkt.

Die Startposition wird vom vorherigen Befehl geliefert. Die ersten beiden Punkte formen die Kurve, während der dritte ihr Ziel ist; sie sind nicht drei aufeinanderfolgende Ziele. Das gleichzeitige Aktualisieren von Befehls‑Typ, Punkt‑Bearbeitungs‑Typ und Punkt‑Array hält das Segment konsistent mit seiner neuen Geometrie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der Pfad in `curve.pptx` hat weiterhin drei Befehle; sein mittlerer Befehl definiert nun eine Kurve.

## **Gespeicherten Pfad inspizieren und bearbeiten**

Jeder [MotionCmdPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioncmdpath/) stellt [getPoints](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioncmdpath/#getPointsType) und [isRelative](https://reference.aspose.com/slides/de/python-java/aspose.slides/motioncmdpath/#isRelative) bereit. Die folgenden Beispiele verwenden den bekannten drei‑Befehl‑Pfad in `motion.pptx`. Für beliebige Eingaben lokalisieren Sie den gewünschten Effekt und prüfen Sie Befehls‑Typen und Punkt‑Anzahlen, bevor Sie nach Index bearbeiten.

### **Befehle und Koordinaten lesen**

Lesen Sie den Pfad, ohne ihn zu ändern. End‑ und Close‑Loop‑Befehle benötigen keine Punkte, daher ist ein null‑Punkt‑Array zulässig.

Die Ausgabe paart jeden numerischen Befehls‑Typ mit seinem relative‑Koordinaten‑Flag, bevor die Punkte aufgelistet werden. So können Sie einen Endpunkt von einem Offset unterscheiden, bevor Sie den Pfad modifizieren. Eine Kurve würde drei Punkte auflisten, während die gerade Linie in dieser Datei nur einen Punkt listet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

Die Auflistung enthält einen Startpunkt, eine absolute Linie, die bei (0.25, 0) endet, und einen End‑Befehl.

### **Endpunkt ändern**

Öffnen Sie `motion.pptx` und ersetzen Sie das Punkte‑Array der Linie, um deren Endpunkt zu verschieben.

In der Eingabedatei ist Index 0 der Start‑Befehl und Index 1 die Linie. Das Ersetzen des einzigen Punktes der Linie ändert ihr Ziel, ohne den Befehls‑Typ, das Timing oder die Position in der Sammlung zu ändern. Da der Befehl absolute Koordinaten verwendet, gibt das neue Paar eine Position anstelle eines hinzugefügten Offsets an.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Linie in `motion-endpoint.pptx` endet bei (0.4, 0.1); die Originaldatei bleibt unverändert.

### **Segment ersetzen**

Verwenden Sie [insert](https://reference.aspose.com/slides/de/python-java/aspose.slides/motionpath/#insert) und [removeAt](https://reference.aspose.com/slides/de/python-java/aspose.slides/motionpath/#removeAt), um die Linie in `motion.pptx` zu ersetzen. Das Einfügen verschiebt die alte Linie zu Index 2.

Dies demonstriert das Ersetzen eines Befehlsobjekts statt das Bearbeiten seiner bestehenden Koordinaten. Nach dem Einfügen enthält die Sammlung temporär den Start‑Befehl, die neue Linie, die alte Linie und den End‑Befehl. Das Entfernen von Index 2 verwirft die alte Linie und lässt die neue Route bestehen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der gespeicherte Pfad hat weiterhin drei Befehle, wobei die neue Linie bei (0.2, 0.1) endet und der End‑Befehl zuletzt steht.

## **Vorhandenes Verhalten ändern und prüfen**

Wenn der Index des Verhaltens unbekannt ist, wählen Sie es nach Typ aus. Dieses Beispiel öffnet `rotation.pptx`, findet dessen [RotationEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/rotationeffect/), ändert den Winkel und prüft den gespeicherten Wert nach erneutem Öffnen.

Die Typprüfung lässt die Schleife Verhaltensweisen, die keine Drehungen sind, überspringen. Der zweite Ladevorgang liest die gespeicherte Datei in ein separates Präsentations‑Objekt, sodass der Vergleich persistente Daten prüft und nicht den noch im Speicher gehaltenen Wert. Dieses Beispiel geht weiterhin davon aus, dass der bekannte Effekt an erster Stelle in der Hauptsequenz steht; die Auswahl nach Typ findet nicht unbedingt den korrekten Effekt in einer beliebigen Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Die Ausgabe lautet `Rotation preserved: True`. Wenden Sie dasselbe Typ‑Prüfmuster auf andere Verhaltensweisen an. Für eine vollständige Persistenz‑Prüfung vergleichen Sie Ziel‑Shape, Effekt, Verhaltenstypen und -reihenfolge, Timing und Pfad‑Befehle. Verwenden Sie für Gleitkomma‑Werte eine numerische Toleranz. Für Präsentationen mit unbekannter Animations‑Struktur siehe [Read Shape Animations](/slides/de/python-java/shape-animation/#read-shape-animations) zum Durchlaufen von Haupt‑ und interaktiven Sequenzen.

## **Verhalten‑Reihenfolge, Vorgaben und Wiedergabe**

Die Reihenfolge in [BehaviorCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/behaviorcollection/) ist die gespeicherte Reihenfolge der Operationen eines Effekts. Sie stellt keine Playlist dar, in der jedes Verhalten automatisch auf das vorherige wartet. Timing und der umgebende Effekt bestimmen die Planung. Verhaltensweisen können sich überschneiden, und Operationen auf derselben Eigenschaft können über [getAdditive](https://reference.aspose.com/slides/de/python-java/aspose.slides/behavior/#getAdditive) und [getAccumulate](https://reference.aspose.com/slides/de/python-java/aspose.slides/behavior/#getAccumulate) interagieren. Verwenden Sie nicht allein das Umordnen der Sammlung, um „verschieben, dann drehen“ zu planen; nutzen Sie explizites Timing oder separate Effekte, wie in [Shape Animation](/slides/de/python-java/shape-animation/) beschrieben.

Der [getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/effect/#getType) und [getSubtype](https://reference.aspose.com/slides/de/python-java/aspose.slides/effect/#getSubtype) eines Effekts beschreiben seine Vorgabe. Sie stellen keine vollständige Beschreibung des bearbeiteten Verhalten‑Baums dar. Wählen Sie Vorgabe und Subtyp, bevor Sie Verhaltensweisen anpassen: Das Ändern der Vorgabe kann die Sammlung neu aufbauen und Ihre benutzerdefinierten Operationen verwerfen. Zum Beispiel kann das Ändern eines angepassten Spin‑Effekts zu Fade dessen Dreh‑Verhalten durch Set‑ und Filter‑Verhaltensweisen ersetzen. Prüfen Sie die Sammlung erneut, nachdem Sie Vorgabe oder Subtyp geändert haben. Das Leeren von Vorgabe‑Verhaltensweisen kann ebenfalls Sichtbarkeits‑ oder Initialisierungs‑Operationen entfernen, die die Vorgabe benötigt. Die Beispiele verwenden bewusst sichtbare Formen und ersetzen die Verhaltensweisen; sie rekonstruieren nicht jede Implementierung einer Vorgabe.

## **Formatkompatibilität**

Ein erhaltenes Verhalten‑Baum garantiert nicht identische Wiedergabe in jedem Viewer oder Export‑Renderer. Prüfen Sie die gespeicherten Daten und die gerenderte Ausgabe separat.

| Format oder Ausgabe | Zu überprüfende Aspekte |
| --- | --- |
| PPTX | Verwenden Sie dies als primäres Format für die Beispiele. Öffnen Sie die Datei erneut, um den editierbaren Verhalten‑Baum zu prüfen, und testen Sie die Wiedergabe in der gewünschten PowerPoint‑Version. |
| PPT | Das ältere binäre Format kann von PPTX abweichen. Testen Sie einen separaten Speicher‑und‑Lade‑Durchlauf und die Wiedergabe; schließen Sie nicht daraus, dass jede benutzerdefinierte Kombination unterstützt wird, nur weil PPTX funktioniert. |
| PDF, PNG, JPEG und andere statische Folienbilder | Enthalten eine statische Folien‑Darstellung, keinen abspielbaren Verhalten‑Zeitstrahl oder garantierten finalen Animations‑Frame. |
| [HTML5](/slides/de/python-java/export-to-html5/) | Kann unterstützte Animationen abspielen, wenn Shape‑Animation in den Export‑Optionen aktiviert ist. Testen Sie benutzerdefinierte Kombinationen im Browser. |
| [Animated GIF](/slides/de/python-java/convert-powerpoint-to-animated-gif/) | Speichert gerenderte Frames, nicht editierbare Verhaltensweisen oder klick‑gesteuerte Interaktionen. Prüfen Sie die tatsächlich gerenderte Bewegung. |
| [Video](/slides/de/python-java/convert-powerpoint-to-video/) | Rendert Animations‑Frames und kodiert sie als Video. Unterstützung ist auf die im Renderer [unterstützten Animationen und Effekte](/slides/de/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) beschränkt; Befehle und interaktive Ereignisse werden nicht zu einem editierbaren Zeitstrahl. |

## **FAQ**

**Warum enthält mein Effekt Verhaltensweisen, bevor ich welche hinzugefügt habe?**

Das Erzeugen eines vordefinierten Effekts kann seine zugrunde liegenden Operationen anlegen. Untersuchen Sie sie, bevor Sie entscheiden, ob Sie die Vorgabe erweitern oder deren Verhaltensweisen ersetzen.

**Führt das Verschieben eines Verhaltens an den Anfang dazu, dass es zuerst abgespielt wird?**

Nicht unbedingt. Die Reihenfolge der Sammlung ersetzt nicht das Timing. Prüfen Sie Verzögerungen, Dauer und Interaktionen zwischen Operationen auf derselben Eigenschaft.

**Warum hat ein End‑Befehl keine Punkte?**

Er markiert das Ende des Pfades und benötigt keine Koordinaten. Achten Sie beim Inspizieren eines aus einer Datei gelesenen Pfades auf ein null‑Punkt‑Array.

**Reicht ein erfolgreicher Round‑Trip aus, um die Wiedergabe zu bestätigen?**

Nein. Das erneute Öffnen bestätigt die Persistenz der geprüften Eigenschaften. Testen Sie den Vorführungs‑Player oder das animierte Exportformat separat, um das visuelle Verhalten zu verifizieren.