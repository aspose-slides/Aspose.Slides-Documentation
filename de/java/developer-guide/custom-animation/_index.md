---
title: Erstellen und Anpassen benutzerdefinierter Animationsverhalten in Java
linktitle: Benutzerdefinierte Animation
type: docs
weight: 151
url: /de/java/custom-animation/
keywords:
- benutzerdefinierte Animation
- Animationsverhalten
- Bewegungspfad
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen, inspizieren und anpassen benutzerdefinierter Animationsverhalten und editierbarer Bewegungspfade in PowerPoint-Präsentationen mit Aspose.Slides für Java."
---
## **Übersicht**

Benutzerdefinierte Animationsverhalten ermöglichen die Steuerung einzelner Vorgänge innerhalb eines Animationseffekts, wie das Ändern einer Farbe, das Drehen einer Form oder das Folgen eines editierbaren Bewegungspfads. Dieses Handbuch zeigt, wie man Verhaltensweisen erstellt und kombiniert, deren Zeitplanung konfiguriert, vorhandene Animationen inspiziert und ändert sowie überprüft, dass ihre Eigenschaften das Speichern und erneute Öffnen einer Präsentation überstehen.

Für vordefinierte Effekte und Klick‑Auslöser siehe [Shape Animation](/slides/de/java/shape-animation/).

## **Verstehen des Animationsmodells**

Eine Animation ist strukturiert als **Timeline → Sequence → Effect → Behaviors**:

- Die Methode [getTimeline](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/#getTimeline--) gibt die Folientimeline zurück, die ihre Hauptsequenz und interaktive Sequenzen enthält.
- Ein [ISequence](https://reference.aspose.com/slides/de/java/com.aspose.slides/isequence/) enthält Effekte, die ggf. verschiedene Formen ansprechen.
- Ein [IEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/) identifiziert eine Ziel­form, ein Preset, einen Subtyp und die Timing‑Angaben des Effekts.
- Die von [IEffect.getBehaviors](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#getBehaviors--) zurückgegebene Sammlung enthält die Operationen, die den Effekt umsetzen: Farbänderung, Verschiebung, Drehung, Setzen einer Eigenschaft usw.

## **Einzelne Verhaltensweisen erstellen**

Rufen Sie [ISequence.addEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) auf, um einen Effekt zu erstellen und auf die Sammlung [getBehaviors](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#getBehaviors--) zuzugreifen. Ein Preset kann diese Sammlung automatisch füllen. Behalten Sie dessen Vorgänge bei der Erweiterung des Presets, oder verwenden Sie [clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorcollection/#clear--) , wenn Sie sie bewusst ersetzen.

[IBehaviorFactory](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorfactory/) erstellt die acht unten dargestellten Verhaltens‑Typen. Motion wird in [Build a Motion Path](#build-a-motion-path) behandelt. Jeder Schnipsel enthält die benötigten Imports; setzen Sie die ausführbaren Anweisungen in eine Methode. Spätere Bearbeitungsbeispiele geben an, welche Ausgabedatei verwendet wird.

### **Drehung**

Verwenden Sie [createRotationEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) , um eine Drehung zu erzeugen. [getBy](https://reference.aspose.com/slides/de/java/com.aspose.slides/irotationeffect/#getBy--) gibt einen relativen Winkel in Grad an; [getFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/irotationeffect/#getFrom--) und [getTo](https://reference.aspose.com/slides/de/java/com.aspose.slides/irotationeffect/#getTo--) geben Endpunkte an.

Das Beispiel beginnt mit einem Spin‑Effekt, ersetzt dessen Preset‑Operationen durch ein Dreh‑Verhalten und gibt dieser Operation eine Dauer von zwei Sekunden. Ein relativer Winkel von 90 Grad entspricht einer Vierteldrehung von der Ausgangsausrichtung der Form, sodass kein expliziter Startwinkel nötig ist.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` enthält eine Form und ein Dreh‑Verhalten. Die Sammlung, das Timing und die nachfolgenden Dreh‑Bearbeitungsbeispiele verwenden diese Datei.

### **Skalierung**

Verwenden Sie [createScaleEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) mit X/Y‑Prozentwerten: [getFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/iscaleeffect/#getFrom--) und [getTo](https://reference.aspose.com/slides/de/java/com.aspose.slides/iscaleeffect/#getTo--) beschreiben die Start‑ bzw. Endgröße, während [getBy](https://reference.aspose.com/slides/de/java/com.aspose.slides/iscaleeffect/#getBy--) eine relative Änderung angibt. Hier bedeutet 100 die Originalgröße.

Das Beispiel vergrößert beide Dimensionen von 100 % auf 125 % über zwei Sekunden. Gleiche horizontale und vertikale Prozentsätze erhalten das Seitenverhältnis der Form; unterschiedliche Werte würden eine Dimension stärker strecken als die andere.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Farbe**

Verwenden Sie [createColorEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) , um die Füllung von Blau zu Orange zu ändern. [getFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/icoloreffect/#getFrom--) und [getTo](https://reference.aspose.com/slides/de/java/com.aspose.slides/icoloreffect/#getTo--) sind Farben; [getBy](https://reference.aspose.com/slides/de/java/com.aspose.slides/icoloreffect/#getBy--) ist ein Farb‑Offset. [IBehavior.getProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehavior/#getProperties--) identifiziert das animierte Attribut.

Die feste Füllfarbe der Form wird zu Beginn auf Blau gesetzt, sodass sie der Ausgangsfarbe der Animation entspricht. Das Auswählen des Füll‑Farb‑Attributs sagt dem Verhalten, welchen Teil der Form es ändern soll; die Farb‑Endpunkte allein identifizieren das Attribut nicht. Der gespeicherte Effekt beschreibt einen zweisekündigen Übergang zu Orange.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filter**

Verwenden Sie [createFilterEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) , um einen Wisch‑Effekt auszuwählen. [getType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifiltereffect/#getSubtype--), und [getReveal](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifiltereffect/#getReveal--) geben den Filter, die Richtung und ob die Form enthüllt oder verborgen werden soll, an.

Dieses Beispiel konfiguriert einen zweisekündigen Wisch, der die Form mit dem Subtyp „right“ enthüllt. Die Filtereinstellungen gehören zum Verhalten im Effekt, daher werden sie konfiguriert, nachdem die ursprünglichen Vorgänge des Presets entfernt wurden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Eigenschaft**

Verwenden Sie [createPropertyEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) , um die Deckkraft zu animieren. [getFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipropertyeffect/#getTo--), und [getBy](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipropertyeffect/#getBy--) sind Zeichenketten, die mit [getValueType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipropertyeffect/#getValueType--) und [getCalcMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipropertyeffect/#getCalcMode--) interpretiert werden. Wählen Sie Endpunkte oder einen relativen Offset, statt alle drei ununterscheidet zu setzen.

Hier ist das ausgewählte Attribut die Deckkraft, und die numerischen Zeichenketten repräsentieren eine Änderung von 25 % Deckkraft zu voller Deckkraft. Lineare Interpolation beschreibt einen graduellen Übergang zwischen diesen Werten. Beim Anpassen dieses Beispiels auf ein anderes Attribut wählen Sie einen Werttyp und Endwerte, die zu diesem Attribut passen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Setzen**

Verwenden Sie [createSetEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) , um die Sichtbarkeit über [getTo](https://reference.aspose.com/slides/de/java/com.aspose.slides/iseteffect/#getTo--) zuzuweisen. Ein Set‑Verhalten interpoliert nicht zwischen Endpunkten.

Das Beispiel wählt das Sichtbarkeits‑Attribut und weist beim Ausführen des Verhaltens die Zeichenkette `visible` zu. Das Rechteck ist in dieser Minimal‑Präsentation bereits sichtbar, sodass die Zuweisung allein möglicherweise keine offensichtliche visuelle Änderung bewirkt. Eine solche Operation ist nützlich als Teil eines größeren Effekts, der ebenfalls steuert, wann die Form verborgen oder sichtbar wird.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Befehl**

Verwenden Sie [createCommandEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) und konfigurieren Sie [getType](https://reference.aspose.com/slides/de/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/de/java/com.aspose.slides/icommandeffect/#getCommandString--), und [getShapeTarget](https://reference.aspose.com/slides/de/java/com.aspose.slides/icommandeffect/#getShapeTarget--). Legen Sie eine WAV‑Aufnahme mit dem Namen `sample.wav` im Arbeitsverzeichnis ab. Dieses Beispiel bettet sie mit [addAudioFrameEmbedded](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) ein und fügt einen Play‑Befehl zum Audi‑Frame hinzu.

Der Audi‑Frame ist sowohl Ziel des Effekts als auch Ziel des Befehls. Dadurch wird die Wiedergabe‑Anfrage mit der eingebetteten Aufnahme verknüpft; ein reiner Befehls‑String identifiziert nicht, welches Medienelement zu steuern ist. Der Effekt ist so konfiguriert, dass er bei einem Klick während der Slideshow startet.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

Das Speichern legt den Befehl in `command.pptx` ab; die Aufnahme wird nicht abgespielt. Die Wiedergabe erfordert einen Slideshow‑Player, der den Befehl und sein Medientarget unterstützt.

## **Verwalten der Verhaltenssammlung**

[IBehaviorCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorcollection/) unterstützt [add](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), und [removeAt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Dieses Beispiel öffnet `rotation.pptx`, fügt eine Skalierung hinzu, verschiebt sie vor die Drehung und entfernt die Drehung. Das Entfernen und erneute Einfügen desselben Objekts ändert dessen gespeicherte Position, ohne eine Kopie zu erzeugen.

Die Abfolge der Änderungen wandelt die Sammlung von Drehung‑Skalierung zu Skalierung‑Drehung und schließlich zu nur Skalierung um. Indizes beziehen sich auf die aktuelle Sammlung, sodass die Entfernung den neuen Index der Drehung nach der Neuordnung nutzt. Die abschließende Aufzählung bestätigt, welches Verhalten gespeichert wird.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Ausgabe ist `ScaleEffect`: Nur die Skalierung bleibt erhalten. Die Reihenfolge der Sammlung legt allein nicht fest, dass Verhaltensweisen nacheinander abgespielt werden. Leeren Sie die Sammlung nur, wenn Sie alle ihre Operationen ersetzen wollen.

## **Timing von Verhaltensweisen konfigurieren**

[IBehavior.getTiming](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehavior/#getTiming--) gibt [ITiming](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/) frei, unabhängig von [IEffect.getTiming](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#getTiming--). Das Effect‑Timing plant den umgebenden Effekt; das Verhalten‑Timing beschreibt einen Vorgang innerhalb davon.

### **Dauer, Verzögerung, Wiederholung und Beschleunigung festlegen**

Öffnen Sie `rotation.pptx` und setzen Sie die Dauer ([getDuration](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getDuration--)) sowie die Auslöse‑Verzögerung ([getTriggerDelayTime](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) in Sekunden, dann konfigurieren Sie die Wiederholungsanzahl über [setRepeatCount](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getAccelerate--) und [getDecelerate](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getDecelerate--) sind Bruchteile der Dauer; halten Sie deren Summe ≤ 1.

Die Eingabedatei ist die im Drehungsbeispiel erstellte, wobei das erste Verhalten als Drehung bekannt ist. Dieses Beispiel ändert nur das Timing dieses Verhaltens; sein 90‑Grad‑Winkel bleibt unverändert. Das getrennte Behandeln von Winkel und Timing erleichtert die Anpassung des Tempos, ohne die Animation neu zu bauen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Verhalten nutzt eine Dauer von zwei Sekunden, eine halbe Sekunde Verzögerung und eine Wiederholungsanzahl von 3. Die ersten und letzten 20 % seiner Dauer werden für Beschleunigung bzw. Verzögerung verwendet.

Weitere Wiederholungsrichtlinien umfassen [getRepeatDuration](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), und [getRepeatUntilNextClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--) ; wählen Sie eine Richtlinie, statt alle gleichzeitig zu aktivieren. [getAutoReverse](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getAutoReverse--) spielt die Animation nach dem Vorwärtslauf rückwärts ab. Beschleunigung und Verzögerung gelten für kontinuierliche Änderungen, nicht für diskrete Zuweisungen oder Befehle.

## **Einen Bewegungspfad erstellen**

Verwenden Sie [createMotionEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) , um Motion zu erzeugen. Seine [getFrom](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotioneffect/#getTo--), und [getBy](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotioneffect/#getBy--) beschreiben prozentbasierte Koordinaten oder Offsets. Für eine editierbare Route erzeugen Sie ein [MotionPath](https://reference.aspose.com/slides/de/java/com.aspose.slides/motionpath/) und weisen es mit [IMotionEffect.setPath](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) zu. [IMotionPath](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotionpath/) speichert die Pfad‑Kommandos.

[MotionCommandPathType](https://reference.aspose.com/slides/de/java/com.aspose.slides/motioncommandpathtype/) wählt die Operation:

| Befehl | Punkte | Bedeutung |
| --- | --- | --- |
| MoveTo | One | Setzt die Startposition. |
| LineTo | One | Bewegt entlang eines geraden Segments zum Endpunkt. |
| CurveTo | Three | Folgt einer kubischen Kurve, definiert durch zwei Kontrollpunkte und einen Endpunkt. |
| CloseLoop | None | Kehrt zur Startposition zurück. |
| End | None | Beendet den Pfad. |

[MotionPathPointsType](https://reference.aspose.com/slides/de/java/com.aspose.slides/motionpathpointstype/) beschreibt Eigenschaften der Punkt‑Bearbeitung, etwa Eck‑ oder Glättungspunkte. Es ersetzt nicht den Kommando‑Typ. Verwenden Sie einen Kurven‑Punkt‑Typ für das untenstehende Kurvenbeispiel und einen Eck‑Punkt‑Typ für die geraden Segmente.

Pfadkoordinaten sind an die Folienabmessungen normiert: eine X‑Verschiebung von 0,25 entspricht einem Viertel der Folienbreite, nicht 0,25 Punkte. Positives Y läuft nach unten. Absolute Kommandos geben Positionen im Pfad‑Koordinatensystem an; relative Kommandos geben Offsets zur aktuellen Position an. Das ist getrennt von [getOrigin](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotioneffect/#getOrigin--) , das den Referenzrahmen des Pfads wählt, und [getPathEditMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotioneffect/#getPathEditMode--) , das steuert, wie sich der Pfad bewegt, wenn die Form verschoben wird.

### **Einen geraden Pfad erstellen**

Erzeugen Sie ein Motion‑Verhalten mit einem Startpunkt, einem geraden Segment und einem End‑Kommando. [IMotionPath.add](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) nimmt den Kommando‑Typ, seine Punkte, den Punkt‑Typ und ein Flag für relative Koordinaten.

Das Startkommando legt (0, 0) fest, und die Linie endet bei (0,25, 0), wodurch die Route eine horizontale Verschiebung von einem Viertel der Folienbreite erhält. Das End‑Kommando besitzt keine Koordinatenpunkte. Sobald der Pfad zugewiesen ist, verbindet das Hinzufügen des Motion‑Verhaltens zum Effekt diese Route mit dem Rechteck.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` enthält ein Motion‑Verhalten mit drei Pfad‑Kommandos. Die folgenden Datei‑Bearbeitungsbeispiele nutzen diese bekannte Struktur.

### **Absolute und relative Koordinaten vergleichen**

Diese beiden Pfad‑Objekte beschreiben die gleiche Route. Das absolute Kommando endet bei (0,3, 0,1); das relative Kommando addiert (0,1, 0,1) zur aktuellen Position, (0,2, 0).

Beide Pfade starten an derselben Position. Für die relative Linie addieren Sie die X‑ und Y‑Offsets zur aktuellen Position, um den Endpunkt zu erhalten; für die absolute Linie lesen Sie den Endpunkt direkt. Das Flag zu wechseln, ohne die Koordinaten zu konvertieren, würde eine andere Route beschreiben.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Weisen Sie entweder den absoluten oder den relativen Pfad einem Motion‑Verhalten zu, um ihn in einer Präsentation zu nutzen. Das abschließende Boolesche Argument wählt relative Koordinaten für dieses Kommando aus.

### **Eine Linie durch eine Kurve ersetzen**

Öffnen Sie `motion.pptx` und ersetzen Sie das Linien‑Kommando durch eine kubische Kurve. Geben Sie zuerst die beiden Kontrollpunkte an, gefolgt vom Endpunkt.

Die Startposition wird vom vorherigen Kommando geliefert. Die ersten beiden Punkte formen die Kurve, während der dritte ihr Ziel ist; sie sind also nicht drei aufeinanderfolgende Ziele. Das gleichzeitige Aktualisieren von Kommando‑Typ, Punkt‑Bearbeitungs‑Typ und Punkt‑Array hält das Segment konsistent mit seiner neuen Geometrie.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Pfad in `curve.pptx` hat weiterhin drei Kommandos; sein mittleres Kommando definiert jetzt eine Kurve.

## **Gespeicherten Pfad prüfen und bearbeiten**

Jeder [IMotionCmdPath](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotioncmdpath/) gibt [getPoints](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotioncmdpath/#getPointsType--), und [isRelative](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotioncmdpath/#isRelative--) frei. Die folgenden Beispiele verwenden den bekannten dreikommando‑Pfad in `motion.pptx`. Für beliebige Eingaben lokalisieren Sie den gewünschten Effekt und prüfen Sie die Kommando‑Typen und Punkt‑Anzahlen, bevor Sie per Index bearbeiten.

### **Befehle und Koordinaten lesen**

Lesen Sie den Pfad, ohne ihn zu ändern. End‑ und Close‑Loop‑Kommandos benötigen keine Punkte, also erlauben Sie ein null‑Punkt‑Array.

Die Ausgabe stellt jeden numerischen Kommando‑Typ zusammen mit seinem relativen‑Koordinaten‑Flag dar, bevor die Punkte aufgelistet werden. So können Sie einen Endpunkt von einem Offset unterscheiden, bevor Sie den Pfad ändern. Eine Kurve würde drei Punkte listen, während die gerade Linie in dieser Datei nur einen Punkt auflistet.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Die Auflistung enthält einen Startpunkt, eine absolute Linie, die bei (0,25, 0) endet, und ein End‑Kommando.

### **Endpunkt ändern**

Öffnen Sie `motion.pptx` und ersetzen Sie das Punkt‑Array der Linie, um ihren Endpunkt zu verschieben.

Im Eingabefile ist Index 0 das Startkommando und Index 1 die Linie. Das Ersetzen des einzelnen Punktes der Linie ändert ihr Ziel, ohne den Kommando‑Typ, das Timing oder die Position in der Sammlung zu verändern. Da das Kommando absolute Koordinaten verwendet, gibt das neue Paar eine Position anstatt einen hinzuzufügenden Offset an.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Linie in `motion-endpoint.pptx` endet bei (0,4, 0,1); die Originaldatei bleibt unverändert.

### **Segment ersetzen**

Verwenden Sie [insert](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) und [removeAt](https://reference.aspose.com/slides/de/java/com.aspose.slides/imotionpath/#removeAt-int-) , um die Linie in `motion.pptx` zu ersetzen. Das Einfügen verschiebt die alte Linie zu Index 2.

Dies demonstriert das Ersetzen eines Kommando‑Objekts statt das Bearbeiten seiner bestehenden Koordinaten. Nach dem Einfügen enthält die Sammlung temporär das Startkommando, die neue Linie, die alte Linie und das End‑Kommando. Das Entfernen von Index 2 verwirft die alte Linie und lässt die neue Route bestehen.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der gespeicherte Pfad hat immer noch drei Kommandos, wobei die neue Linie bei (0,2, 0,1) endet und das End‑Kommando zuletzt steht.

## **Ein vorhandenes Verhalten ändern und prüfen**

Wenn der Index des Verhaltens unbekannt ist, wählen Sie es nach Typ aus. Dieses Beispiel öffnet `rotation.pptx`, findet sein [IRotationEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/irotationeffect/), ändert den Winkel und prüft den gespeicherten Wert nach erneutem Öffnen.

Der Typ‑Check lässt die Schleife Verhaltensweisen überspringen, die keine Drehungen sind. Der zweite Ladevorgang liest die gespeicherte Datei in ein separates Präsentations‑Objekt, sodass der Vergleich persistente Daten prüft und nicht den noch im Speicher gehaltenen Wert. Dieses Beispiel geht weiterhin davon aus, dass der bekannte Effekt an erster Stelle in der Hauptsequenz steht; das Auswählen eines Verhaltens nach Typ findet nicht unbedingt den korrekten Effekt in einer beliebigen Präsentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Die Ausgabe lautet `Rotation preserved: true`. Verwenden Sie dasselbe Typ‑Prüfmuster für andere Verhaltensweisen. Für einen vollständigen Erhaltungs‑Check vergleichen Sie Ziel‑Form, Effekt, Verhaltenstypen und -reihenfolge, Timing und Pfad‑Kommandos. Nutzen Sie eine numerische Toleranz für Gleitkomma‑Werte. Für eine Präsentation mit unbekanntem Animations‑Layout siehe [Read Shape Animations](/slides/de/java/shape-animation/#read-shape-animations) zur Traversierung von Haupt‑ und Interaktiv‑Sequenzen.

## **Reihenfolge von Verhaltensweisen, Presets und Wiedergabe**

Die Reihenfolge in [IBehaviorCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehaviorcollection/) ist die gespeicherte Reihenfolge der Vorgänge eines Effekts. Sie ist keine Wiedergabeliste, in der jedes Verhalten automatisch auf das vorherige wartet. Timing und der umgebende Effekt bestimmen die Planung. Verhaltensweisen können sich überschneiden, und Vorgänge am selben Attribut können über [getAdditive](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehavior/#getAdditive--) und [getAccumulate](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibehavior/#getAccumulate--) interagieren. Verwenden Sie nicht nur das Neuanordnen der Sammlung, um „verschieben, dann drehen“ zu planen; nutzen Sie explizites Timing oder separate Effekte, wie in [Shape Animation](/slides/de/java/shape-animation/) beschrieben.

Der [getType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#getType--) und [getSubtype](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#getSubtype--) des Effekts beschreiben sein Preset. Sie sind keine vollständige Beschreibung eines bearbeiteten Verhaltensbaums. Wählen Sie Preset und Subtyp, bevor Sie Verhaltensweisen anpassen: Das Ändern des Presets kann die Sammlung neu aufbauen und Ihre benutzerdefinierten Operationen verwerfen. Beispielsweise kann das Ändern eines benutzerdefinierten Spin‑Effekts zu Fade dessen Dreh‑Verhalten durch Set‑ und Filter‑Verhalten ersetzen. Prüfen Sie die Sammlung erneut, nachdem Sie ein Preset oder Subtyp geändert haben. Das Leeren von Preset‑Verhaltensweisen kann auch Sichtbarkeits‑ oder Initialisierungs‑Operationen entfernen, die das Preset benötigt. Die Beispiele verwenden bewusst sichtbare Formen und ersetzen die Verhaltensweisen; sie rekonstruieren nicht jede Implementierung eines Presets.

## **Formatkompatibilität**

Ein erhaltenes Verhaltens‑Baum garantiert keine identische Wiedergabe in jedem Viewer oder Export‑Renderer. Prüfen Sie die gespeicherten Daten und die gerenderte Ausgabe separat.

| Format oder Ausgabe | Was zu überprüfen ist |
| --- | --- |
| PPTX | Verwenden Sie als primäres Format für diese Beispiele. Öffnen Sie es erneut, um den editierbaren Verhaltensbaum zu prüfen, und testen Sie die Wiedergabe in der gewünschten PowerPoint‑Version. |
| PPT | Das alte binäre Format kann sich von PPTX unterscheiden. Testen Sie einen separaten Speicher‑ und Öffnungsvorgang sowie die Wiedergabe; schließen Sie nicht aus dem erfolgreichen PPTX‑Ausgabe‑Ergebnis auf die Unterstützung jeder benutzerdefinierten Kombination. |
| PDF, PNG, JPEG und andere statische Folienbilder | Enthalten eine statische Folienrepräsentation, keine abspielbare Verhaltens‑Timeline oder einen garantierten endgültigen Animationsrahmen. |
| [HTML5](/slides/de/java/export-to-html5/) | Kann unterstützte Animationen abspielen, wenn Formanimation in den Exportoptionen aktiviert ist. Testen Sie benutzerdefinierte Kombinationen im Browser. |
| [Animated GIF](/slides/de/java/convert-powerpoint-to-animated-gif/) | Speichert gerenderte Frames, nicht editierbare Verhaltensweisen oder klickgesteuerte Interaktionen. Prüfen Sie die tatsächlich gerenderte Bewegung. |
| [Video](/slides/de/java/convert-powerpoint-to-video/) | Rendert Animations‑Frames und codiert sie zu einem Video. Die Unterstützung ist auf die vom Renderer unterstützten Animationen und Effekte beschränkt; Befehle und interaktive Ereignisse werden nicht zu einer editierbaren Timeline. |

## **FAQ**

**Warum enthält mein Effekt Verhaltensweisen, bevor ich welche hinzufüge?**

Das Erstellen eines vordefinierten Effekts kann seine zugrunde liegenden Operationen erzeugen. Prüfen Sie sie, bevor Sie entscheiden, ob Sie das Preset erweitern oder seine Verhaltensweisen ersetzen.

**Bewirkt das Verschieben eines Verhaltens an den Anfang, dass es zuerst abgespielt wird?**

Nicht unbedingt. Die Reihenfolge der Sammlung ersetzt nicht das Timing. Prüfen Sie Verzögerungen, Dauern und Interaktionen zwischen Vorgängen am selben Attribut.

**Warum hat ein End‑Befehl keine Punkte?**

Er markiert das Ende des Pfads und benötigt keine Koordinaten. Achten Sie beim Inspektieren eines Pfads aus einer Datei auf ein null‑Punkt‑Array.

**Ist ein erfolgreicher Rundlauf ausreichend, um die Wiedergabe zu bestätigen?**

Nein. Das erneute Öffnen bestätigt die von Ihnen geprüften Eigenschaften. Testen Sie den Slideshow‑Player oder das animierte Exportformat separat, um das visuelle Verhalten zu verifizieren.