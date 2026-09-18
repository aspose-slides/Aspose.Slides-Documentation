---
title: Erstellen und Ändern benutzerdefinierter Animationsverhalten in JavaScript
linktitle: Benutzerdefinierte Animation
type: docs
weight: 151
url: /de/nodejs-java/custom-animation/
keywords:
- benutzerdefinierte Animation
- Animationsverhalten
- Bewegungsweg
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen, inspizieren und ändern Sie benutzerdefinierte Animationsverhalten und editierbare Bewegungswege in PowerPoint-Präsentationen mit Aspose.Slides für Node.js via Java."
---
## **Übersicht**

Benutzerdefinierte Animationsverhalten ermöglichen es Ihnen, einzelne Vorgänge innerhalb eines Animationseffekts zu steuern, z. B. das Ändern einer Farbe, das Drehen einer Form oder das Folgen eines editierbaren Bewegungswegs. Dieses Handbuch zeigt, wie Verhaltensweisen erstellt und kombiniert, deren Zeitsteuerung konfiguriert, bestehende Animationen inspiziert und geändert sowie überprüft werden kann, dass ihre Eigenschaften das Speichern und erneute Öffnen einer Präsentation überstehen.

Für vordefinierte Effekte und Klick‑Trigger siehe [Shape Animation](/slides/de/nodejs-java/shape-animation/).

## **Verstehen des Animationsmodells**

Eine Animation ist organisiert als **Timeline → Sequence → Effect → Behaviors**:

- Die [getTimeline](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/#getTimeline)-Methode gibt die Folientimeline zurück, die ihre Hauptsequenz und interaktive Sequenzen enthält.
- Eine [Sequence](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sequence/) enthält Effekte, die ggf. verschiedene Formen ansprechen.
- Ein [Effect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effect/) identifiziert eine Ziel‑Form, eine Voreinstellung, einen Subtyp und die Timing‑Parameter des Effekts.
- Die von [Effect.getBehaviors](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effect/#getBehaviors) zurückgegebene Sammlung enthält die Vorgänge, die den Effekt umsetzen: Farbänderung, Verschiebung, Drehung, Setzen einer Eigenschaft usw.

## **Einzelne Verhaltensweisen erstellen**

Rufen Sie [Sequence.addEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sequence/#addEffect) auf, um einen Effekt zu erstellen und auf die [getBehaviors](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effect/#getBehaviors)-Sammlung zuzugreifen. Eine Voreinstellung kann diese Sammlung automatisch füllen. Behalten Sie deren Vorgänge bei, wenn Sie die Voreinstellung erweitern, oder verwenden Sie [clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorcollection/#clear), wenn Sie sie bewusst ersetzen.

Der [BehaviorFactory](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorfactory/) erstellt die unten dargestellten acht Verhaltensarten. Bewegung wird in [Build a Motion Path](#build-a-motion-path) behandelt. Jeder Codeausschnitt enthält die Modul‑Importe und kann als Node.js‑Skript mit den installierten Paketen `aspose.slides.via.java` und `java` ausgeführt werden. Führen Sie die Beispiele zur Dateierstellung vor den Beispielen aus, die deren Ausgabe lesen. Spätere Bearbeitungsbeispiele geben an, welche Ausgabedatei sie verwenden.

### **Rotation**

Verwenden Sie [createRotationEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect), um eine Drehung zu erstellen. [getBy](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/rotationeffect/#getBy) gibt einen relativen Winkel in Grad an; [getFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/rotationeffect/#getFrom) und [getTo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/rotationeffect/#getTo) geben die Endpunkte an.

Das Beispiel beginnt mit einem Spin‑Effekt, ersetzt dessen Voreinstellungs‑Vorgänge durch ein Drehverhalten und weist diesem Vorgang eine Dauer von zwei Sekunden zu. Ein relativer Winkel von 90 Grad entspricht einer Vierteldrehung von der Ausgangsausrichtung der Form, daher ist kein expliziter Startwinkel erforderlich.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` enthält eine Form und ein Drehverhalten. Die untenstehenden Beispiele für Sammlung, Timing und Drehbearbeitung verwenden diese Datei.

### **Skalierung**

Verwenden Sie [createScaleEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) mit X/Y‑Prozentwerten: [getFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/scaleeffect/#getFrom) und [getTo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/scaleeffect/#getTo) beschreiben die Anfangs‑ bzw. Endgröße, während [getBy](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/scaleeffect/#getBy) eine relative Änderung angibt. Hier bedeutet 100 % die Originalgröße.

Das Beispiel vergrößert beide Dimensionen von 100 % auf 125 % innerhalb von zwei Sekunden. Gleiche horizontale und vertikale Prozentsätze erhalten das Proportionsverhältnis der Form; unterschiedliche Prozentsätze würden eine Dimension stärker strecken.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Farbe**

Verwenden Sie [createColorEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect), um die Füllung von Blau zu Orange zu ändern. [getFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/coloreffect/#getFrom) und [getTo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/coloreffect/#getTo) sind Farben; [getBy](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/coloreffect/#getBy) ist ein Farbabstand. [Behavior.getProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behavior/#getProperties) ermittelt das animierte Attribut.

Die einfarbige Füllung der Form wird mit Blau initialisiert, was der Ausgangsfarbe der Animation entspricht. Die Auswahl des Fill‑Color‑Attributs teilt dem Verhalten mit, welchen Teil der Form es ändern soll; die Farbzielen allein identifizieren das Attribut nicht. Der gespeicherte Effekt beschreibt einen zweisekündigen Übergang zu Orange.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filter**

Verwenden Sie [createFilterEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect), um einen Wisch‑Effekt auszuwählen. [getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/filtereffect/#getSubtype) und [getReveal](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/filtereffect/#getReveal) geben den Filter, die Richtung und an, ob die Form gezeigt oder verborgen wird.

Dieses Beispiel konfiguriert einen zweisekündigen Wisch, der die Form mit dem Subtyp Richtung rechts sichtbar macht. Die Filtereinstellungen gehören zum Verhalten innerhalb des Effekts, daher werden sie konfiguriert, nachdem die ursprünglichen Vorgänge der Voreinstellung entfernt wurden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Eigenschaft**

Verwenden Sie [createPropertyEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect), um die Deckkraft zu animieren. [getFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/propertyeffect/#getTo) und [getBy](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/propertyeffect/#getBy) sind Zeichenketten, die mit [getValueType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/propertyeffect/#getValueType) und [getCalcMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/propertyeffect/#getCalcMode) interpretiert werden. Wählen Sie Endpunkte oder einen relativen Offset, anstatt alle drei wahllos zu setzen.

Hier ist das ausgewählte Attribut Deckkraft, und die numerischen Zeichenketten stellen eine Änderung von 25 % Deckkraft zu voller Deckkraft dar. Lineare Interpolation beschreibt eine schrittweise Änderung zwischen diesen Werten. Wenn Sie dieses Beispiel an ein anderes Attribut anpassen, wählen Sie einen Werttyp und Endwerte, die zu diesem Attribut passen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Setzen**

Verwenden Sie [createSetEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect), um die Sichtbarkeit über [getTo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/seteffect/#getTo) zuzuweisen. Ein Set‑Verhalten interpoliert nicht zwischen den Endpunkten.

Das Beispiel wählt das Sichtbarkeits‑Attribut aus und weist die Zeichenkette `visible` zu, wenn das Verhalten ausgeführt wird. Das Rechteck ist in dieser minimalen Präsentation bereits sichtbar, sodass die Zuweisung allein keine offensichtliche visuelle Änderung erzeugt. Eine solche Operation ist nützlich als Teil eines größeren Effekts, der ebenfalls steuert, wann die Form verborgen oder sichtbar wird.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Befehl**

Verwenden Sie [createCommandEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect), und konfigurieren Sie [getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/commandeffect/#getCommandString) und [getShapeTarget](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Legen Sie eine WAV‑Aufnahme mit dem Namen `sample.wav` im Arbeitsverzeichnis ab. Dieses Beispiel bindet sie mit [addAudioFrameEmbedded](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) ein und fügt dem Audio‑Frame einen Abspielbefehl hinzu.

Der Audio‑Frame ist sowohl Ziel des Effekts als auch Ziel des Befehls. Dadurch wird die Abspielanfrage mit der eingebetteten Aufnahme verknüpft; eine Befehlszeichenkette allein identifiziert nicht, welches Medienelement zu steuern ist. Der Effekt ist so konfiguriert, dass er bei einem Klick während der Bildschirmpräsentation startet.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

Beim Speichern wird der Befehl in `command.pptx` abgelegt; er spielt die Aufnahme nicht ab. Die Wiedergabe erfordert einen Bildschirmpräsentations‑Player, der den Befehl und sein Medienziel unterstützt.

## **Verwalten der Verhalten‑Sammlung**

[BehaviorCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorcollection/) unterstützt [add](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorcollection/#remove) und [removeAt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorcollection/#removeAt). Dieses Beispiel öffnet `rotation.pptx`, fügt eine Skalierung hinzu, verschiebt sie vor die Drehung und entfernt die Drehung. Das Entfernen und erneute Einfügen desselben Objekts ändert dessen gespeicherte Position, ohne eine Kopie zu erzeugen.

Die Abfolge der Änderungen wandelt die Sammlung von rotation–scale zu scale–rotation und schließlich zu nur scale um. Indizes beziehen sich auf die aktuelle Sammlung, sodass das Entfernen den neuen Index der Drehung nach der Neuordnung verwendet. Die abschließende Aufzählung bestätigt, welches Verhalten gespeichert wird.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Ausgabe ist `ScaleEffect`: nur die Skalierung bleibt. Die Reihenfolge der Sammlung plant nicht von selbst Verhaltensweisen nacheinander. Leeren Sie die Sammlung nur, wenn Sie alle Vorgänge ersetzen.

## **Verhalten‑Timing konfigurieren**

[Behavior.getTiming](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behavior/#getTiming) stellt [Timing](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/) bereit, unabhängig von [Effect.getTiming](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effect/#getTiming). Das Timing des Effekts plant den umschließenden Effekt; das Timing des Verhaltens beschreibt einen Vorgang darin.

### **Dauer, Verzögerung, Wiederholung und Beschleunigung festlegen**

Öffnen Sie `rotation.pptx` und setzen Sie die Dauer ([getDuration](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getDuration)) sowie die Auslöserverzögerung ([getTriggerDelayTime](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) in Sekunden, dann konfigurieren Sie die Wiederholungszahl über [setRepeatCount](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getAccelerate) und [getDecelerate](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getDecelerate) sind Bruchteile der Dauer; halten Sie deren Summe höchstens bei 1.

Die Eingabedatei ist die im Dreh‑Beispiel erstellte, bei der das erste Verhalten als Drehung bekannt ist. Dieses Beispiel ändert nur das Timing dieses Verhaltens; sein 90‑Grad‑Winkel bleibt unverändert. Das getrennte Halten von Winkel und Timing erleichtert das Anpassen des Tempos, ohne die Animation neu zu erstellen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Verhalten verwendet eine Dauer von zwei Sekunden, eine Verzögerung von einer halben Sekunde und eine Wiederholungszahl von 3. Die ersten und letzten 20 % seiner Dauer werden für Beschleunigung und Verzögerung genutzt.

Weitere Wiederholungs‑Policy‑Optionen sind [getRepeatDuration](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) und [getRepeatUntilNextClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); wählen Sie eine Policy, anstatt alle gleichzeitig zu aktivieren. [getAutoReverse](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getAutoReverse) spielt die Animation nach dem Vorwärtslauf rückwärts ab. Beschleunigung und Verzögerung gelten für kontinuierliche Änderungen, nicht für diskrete Zuweisungen oder Befehle.

## **Bewegungsweg erstellen**

Verwenden Sie [createMotionEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect), um Bewegung zu erzeugen. Sein [getFrom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motioneffect/#getTo) und [getBy](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motioneffect/#getBy) beschreiben prozentbasierte Koordinaten oder Offsets. Für eine editierbare Route erstellen Sie einen [MotionPath](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motionpath/) und weisen ihn mit [MotionEffect.setPath](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motioneffect/#setPath) zu. [MotionPath](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motionpath/) speichert die Pfadbefehle.

| Befehl | Punkte | Bedeutung |
| --- | --- | --- |
| MoveTo | Eins | Setzt die Ausgangsposition. |
| LineTo | Eins | Bewegt entlang eines geraden Segments zu dessen Endpunkt. |
| CurveTo | Drei | Folgt einer kubischen Kurve, definiert durch zwei Kontrollpunkte und einen Endpunkt. |
| CloseLoop | Keine | Kehrt zur Ausgangsposition zurück. |
| End | Keine | Beendet den Pfad. |

[MotionPathPointsType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motionpathpointstype/) beschreibt Eigenschaften der Punktbearbeitung, z. B. Eck‑ oder Glättungspunkte. Es ersetzt nicht den Befehls­typ. Verwenden Sie für das Kurvenbeispiel unten einen Kurven‑Punkttyp und für die geraden Segmente einen Eck‑Punkttyp.

Pfadkoordinaten sind auf die Folienmaße normalisiert: eine X‑Verschiebung von 0,25 entspricht einem Viertel der Folienbreite, nicht 0,25 Punkten. Positive Y verläuft nach unten. Absolute Befehle geben Positionen im Pfadkoordinatensystem an; relative Befehle geben Offsets zur aktuellen Position an. Dies ist getrennt von [getOrigin](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motioneffect/#getOrigin), das den Bezugsrahmen des Pfades auswählt, und [getPathEditMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), das steuert, wie sich der Pfad bewegt, wenn die Form verschoben wird.

### **Geraden Pfad erstellen**

Erstellen Sie ein Bewegungs‑Verhalten mit einem Startpunkt, einem geraden Segment und einem Endbefehl. [MotionPath.add](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motionpath/#add) nimmt den Befehls­typ, dessen Punkte, den Punkt‑Typ und ein Flag für relative Koordinaten.

Der Startbefehl legt (0, 0) fest, und die Linie endet bei (0,25, 0), wodurch die Route eine horizontale Verschiebung von einem Viertel der Folienbreite erhält. Der Endbefehl hat keine Koordinatenpunkte. Sobald der Pfad zugewiesen ist, verbindet das Hinzufügen des Bewegungs‑Verhaltens zum Effekt diese Route mit dem Rechteck.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` enthält ein Bewegungs‑Verhalten mit drei Pfadbefehlen. Die folgenden Beispiele zur Dateibearbeitung nutzen diese bekannte Struktur.

### **Absolute und relative Koordinaten vergleichen**

Diese beiden Pfadobjekte beschreiben dieselbe Route. Der absolute Befehl endet bei (0,3, 0,1); der relative Befehl addiert (0,1, 0,1) zur aktuellen Position (0,2, 0).

Beide Pfade beginnen an derselben Position. Für die relative Linie addieren Sie ihre X‑ und Y‑Offsets zur aktuellen Position, um den Endpunkt zu erhalten; für die absolute Linie lesen Sie den Endpunkt direkt. Das Umschalten des Flags ohne Konvertierung der Koordinaten würde eine andere Route beschreiben.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

Weisen Sie entweder Pfad einem Bewegungs‑Verhalten zu, um ihn in einer Präsentation zu nutzen. Das abschließende boolesche Argument wählt relative Koordinaten für diesen Befehl.

### **Eine Linie durch eine Kurve ersetzen**

Öffnen Sie `motion.pptx` und ersetzen Sie dessen Linienbefehl durch eine kubische Kurve. Geben Sie zuerst die beiden Kontrollpunkte und anschließend den Endpunkt an.

Die Startposition wird vom vorhergehenden Befehl geliefert. Die ersten beiden Punkte formen die Kurve, während der dritte ihr Ziel ist; sie sind nicht drei aufeinanderfolgende Ziele. Das gleichzeitige Aktualisieren des Befehls­typs, des Punkt‑Bearbeitungstyps und des Punkte‑Arrays hält das Segment konsistent mit seiner neuen Geometrie.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Pfad in `curve.pptx` hat weiterhin drei Befehle; sein mittlerer Befehl definiert nun eine Kurve.

## **Gespeicherten Pfad inspizieren und bearbeiten**

Jeder [MotionCmdPath](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motioncmdpath/) stellt [getPoints](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) und [isRelative](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motioncmdpath/#isRelative) bereit. Die folgenden Beispiele nutzen den bekannten Pfad mit drei Befehlen in `motion.pptx`. Für beliebige Eingaben suchen Sie den gewünschten Effekt und prüfen Befehls­typen sowie Punktzahlen, bevor Sie nach Index bearbeiten.

### **Befehle und Koordinaten lesen**

Lesen Sie den Pfad, ohne ihn zu ändern. End‑ und Close‑Loop‑Befehle benötigen keine Punkte, daher sollte ein null‑Punkte‑Array zulässig sein.

Die Ausgabe paart jeden numerischen Befehls­typ mit seinem Flag für relative Koordinaten, bevor die Punkte aufgelistet werden. Das ermöglicht, einen Endpunkt von einem Offset zu unterscheiden, bevor der Pfad geändert wird. Eine Kurve würde drei Punkte auflisten, während die gerade Linie in dieser Datei nur einen Punkt auflistet.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Die Auflistung enthält einen Startpunkt, eine absolute Linie, die bei (0,25, 0) endet, und einen Endbefehl.

### **Einen Endpunkt ändern**

Öffnen Sie `motion.pptx` und ersetzen Sie das Punkte‑Array der Linie, um ihren Endpunkt zu verschieben.

In der Eingabedatei ist Index 0 der Startbefehl und Index 1 die Linie. Das Ersetzen des einzelnen Punktes der Linie ändert ihr Ziel, ohne den Befehls­typ, das Timing oder die Position in der Sammlung zu ändern. Da der Befehl absolute Koordinaten verwendet, gibt das neue Paar eine Position anstelle eines hinzugefügten Offsets an.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Linie in `motion-endpoint.pptx` endet bei (0,4, 0,1); die Originaldatei bleibt unverändert.

### **Ein Segment ersetzen**

Verwenden Sie [insert](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motionpath/#insert) und [removeAt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/motionpath/#removeAt), um die Linie in `motion.pptx` zu ersetzen. Das Einfügen verschiebt die alte Linie auf Index 2.

Dies demonstriert das Ersetzen eines Befehls‑Objekts statt das Bearbeiten seiner bestehenden Koordinaten. Nach dem Einfügen enthält die Sammlung vorübergehend den Startbefehl, die neue Linie, die alte Linie und den Endbefehl. Das Entfernen von Index 2 verwirft die alte Linie und lässt die neue Route bestehen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der gespeicherte Pfad hat weiterhin drei Befehle, wobei die neue Linie bei (0,2, 0,1) endet und der Endbefehl zuletzt steht.

## **Vorhandenes Verhalten ändern und prüfen**

Wenn der Index des Verhaltens unbekannt ist, wählen Sie es nach Typ aus. Dieses Beispiel öffnet `rotation.pptx`, findet dessen [RotationEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/rotationeffect/), ändert den Winkel und prüft den gespeicherten Wert nach erneutem Öffnen.

Die Typprüfung lässt die Schleife Verhaltensweisen, die keine Drehungen sind, überspringen. Der zweite Ladevorgang liest die gespeicherte Datei in ein separates Präsentations‑Objekt, sodass der Vergleich persistente Daten prüft und nicht den noch im Speicher gehaltenen Wert. Dieses Beispiel geht weiterhin davon aus, dass der bekannte Effekt zuerst in der Hauptsequenz steht; die Auswahl eines Verhaltens nach Typ findet nicht notwendigerweise den korrekten Effekt in einer beliebigen Präsentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Die Ausgabe ist `Rotation preserved: true`. Wenden Sie dieselbe Typprüf‑Methode auf andere Verhaltensweisen an. Für eine vollständige Prü­fung der Persistenz vergleichen Sie die Ziel‑Form, den Effekt, die Verhaltenstypen und -reihenfolge, das Timing und die Pfadbefehl. Verwenden Sie für Fließkommawerte eine numerische Toleranz. Für eine Präsentation mit unbekanntem Animations‑Layout siehe [Read Shape Animations](/slides/de/nodejs-java/shape-animation/#read-shape-animations) zur Durchquerung der Haupt‑ und interaktiven Sequenzen.

## **Verhalten‑Reihenfolge, Voreinstellungen und Wiedergabe**

Die Reihenfolge in [BehaviorCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behaviorcollection/) ist die gespeicherte Reihenfolge der Vorgänge eines Effekts. Sie ist keine Wiedergabeliste, bei der jedes Verhalten automatisch auf das vorherige wartet. Timing und der umschließende Effekt bestimmen die Planung. Verhaltensweisen können sich überlappen, und Vorgänge derselben Eigenschaft können über [getAdditive](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behavior/#getAdditive) und [getAccumulate](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/behavior/#getAccumulate) interagieren. Verwenden Sie das reine Neuanordnen der Sammlung nicht, um “verschieben, dann drehen” zu planen; nutzen Sie explizites Timing oder separate Effekte, wie in [Shape Animation](/slides/de/nodejs-java/shape-animation/) beschrieben.

Der Effekt‑[getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effect/#getType) und [getSubtype](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effect/#getSubtype) beschreiben seine Voreinstellung. Sie stellen keine vollständige Beschreibung eines bearbeiteten Verhaltensbaums dar. Wählen Sie die Voreinstellung und den Subtyp, bevor Sie Verhaltensweisen anpassen: das Ändern der Voreinstellung kann die Sammlung neu aufbauen und Ihre benutzerdefinierten Vorgänge verwerfen. Zum Beispiel kann das Ändern eines angepassten Spin‑Effekts zu Fade dessen Dreh‑Verhalten durch Set‑ und Filter‑Verhaltensweisen ersetzen. Prüfen Sie die Sammlung nach dem Ändern einer Voreinstellung oder eines Subtyps erneut. Das Löschen von Voreinstellungs‑Verhalten kann ebenfalls Sichtbarkeits‑ oder Initialisierungs‑Vorgänge entfernen, die die Voreinstellung benötigt. Die Beispiele verwenden bewusst sichtbare Formen und ersetzen die Verhaltensweisen; sie rekonstruieren nicht jede Implementierung der Voreinstellung.

## **Formatkompatibilität**

Ein erhaltenes Verhaltens‑Baum garantiert nicht identische Wiedergabe in jedem Viewer oder Export‑Renderer. Prüfen Sie die gespeicherten Daten und die gerenderte Ausgabe separat.

| Format oder Ausgabe | Was zu prüfen ist |
| --- | --- |
| PPTX | Als primäres Format für diese Beispiele verwenden. Öffnen Sie es erneut, um den editierbaren Verhaltensbaum zu prüfen, und testen Sie anschließend die Wiedergabe in der gewünschten PowerPoint‑Version. |
| PPT | Die alte binäre Darstellung kann von PPTX abweichen. Testen Sie einen separaten Speicher‑und‑Wieder‑Öffnen‑Zyklus und die Wiedergabe; schließen Sie nicht aus jedem benutzerdefinierten Kombinationsfall aus, nur weil PPTX erfolgreich war. |
| PDF, PNG, JPEG und andere statische Folienbilder | Enthalten eine statische Foliendarstellung, keinen abspielbaren Verhaltens‑Zeitstrahl oder ein garantiertes finales Animations‑Frame. |
| [HTML5](/slides/de/nodejs-java/export-to-html5/) | Kann unterstützte Animationen abspielen, wenn Formanimation in den Exportoptionen aktiviert ist. Testen Sie benutzerdefinierte Kombinationen im Browser. |
| [Animated GIF](/slides/de/nodejs-java/convert-powerpoint-to-animated-gif/) | Speichert gerenderte Frames, nicht editierbare Verhaltensweisen oder klickgesteuerte Interaktionen. Prüfen Sie die tatsächlich gerenderte Bewegung. |
| [Video](/slides/de/nodejs-java/convert-powerpoint-to-video/) | Rendert Animations‑Frames und codiert sie als Video. Die Unterstützung ist auf die vom Renderer [unterstützten Animationen und Effekte](/slides/de/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) beschränkt; Befehle und interaktive Ereignisse werden nicht zu einem editierbaren Zeitstrahl. |

## **FAQ**

**Warum enthält mein Effekt Verhaltensweisen, bevor ich welche hinzufüge?**

Das Erstellen eines vordefinierten Effekts kann dessen zugrunde liegende Vorgänge erzeugen. Untersuchen Sie sie, bevor Sie entscheiden, ob Sie die Voreinstellung erweitern oder deren Verhaltensweisen ersetzen.

**Bewirkt das Verschieben eines Verhaltens an den Anfang, dass es zuerst abgespielt wird?**

Nicht unbedingt. Die Reihenfolge der Sammlung ersetzt nicht das Timing. Prüfen Sie Verzögerungen, Dauern und Wechselwirkungen zwischen Vorgängen derselben Eigenschaft.

**Warum hat ein End‑Befehl keine Punkte?**

Er markiert das Ende des Pfades und benötigt keine Koordinaten. Prüfen Sie beim Untersuchen eines aus einer Datei gelesenen Pfades auf ein null‑Punkte‑Array.

**Reicht ein erfolgreicher Round‑Trip aus, um die Wiedergabe zu bestätigen?**

Nein. Das erneute Öffnen bestätigt nur die Bewahrung der geprüften Eigenschaften. Testen Sie den Bildschirmpräsentations‑Player oder den animierten Export separat, um das visuelle Verhalten zu bestätigen.