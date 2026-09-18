---
title: Erstellen und Ändern benutzerdefinierter Animationsverhalten unter Android
linktitle: Benutzerdefinierte Animation
type: docs
weight: 151
url: /de/androidjava/custom-animation/
keywords:
- benutzerdefinierte Animation
- Animationsverhalten
- Bewegungsweg
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen, prüfen und ändern Sie benutzerdefinierte Animationsverhalten und editierbare Bewegungswege in PowerPoint‑Präsentationen mit Aspose.Slides für Android über Java."
---
## **Übersicht**

Benutzerdefinierte Animations‑Verhalten ermöglichen die Steuerung einzelner Vorgänge innerhalb eines Animationseffekts, z. B. das Ändern einer Farbe, das Drehen einer Form oder das Folgen eines bearbeitbaren Bewegungswegs. Dieser Leitfaden zeigt, wie Sie Verhaltensweisen erstellen und kombinieren, deren Timing konfigurieren, vorhandene Animationen prüfen und ändern sowie überprüfen, dass deren Eigenschaften das Speichern und erneute Öffnen einer Präsentation überstehen.

Für vordefinierte Effekte und Klick‑Trigger siehe [Shape Animation](/slides/de/androidjava/shape-animation/).

## **Das Animationsmodell verstehen**

Eine Animation ist strukturiert als **Timeline → Sequence → Effect → Behaviors**:

- Die Methode [getTimeline](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) liefert die Folien‑Timeline, die ihre Hauptsequenz und interaktive Sequenzen enthält.
- Ein [ISequence](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isequence/) enthält Effekte, die potenziell unterschiedliche Formen ansprechen.
- Ein [IEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/) identifiziert Ziel‑Form, Vorgabe, Untertyp und Effekt‑Timing.
- Die von [IEffect.getBehaviors](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#getBehaviors--) zurückgegebene Sammlung enthält die Vorgänge, die den Effekt umsetzen: Farbwechsel, Verschieben, Drehen, Setzen einer Eigenschaft usw.

## **Einzelne Verhaltensweisen erstellen**

Rufen Sie [ISequence.addEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) auf, um einen Effekt zu erzeugen und auf die Sammlung [getBehaviors](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#getBehaviors--) zuzugreifen. Eine Vorgabe kann diese Sammlung automatisch füllen. Bewahren Sie deren Vorgänge, wenn Sie die Vorgabe erweitern, oder verwenden Sie [clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) beim bewussten Ersetzen.

[IBehaviorFactory](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorfactory/) erzeugt die unten dargestellten acht Verhaltens‑Typen. Motion wird in [Build a Motion Path](#build-a-motion-path) behandelt. Jeder Snippet enthält seine Imports; setzen Sie die ausführbaren Anweisungen in eine Methode. Spätere Bearbeitungsbeispiele geben an, welche Ausgabedatei sie verwenden. Unter Android ersetzen Sie die Beispiel‑Dateinamen durch vollständige Pfade in einem für die App zugänglichen Verzeichnis, z. B. dem files‑Verzeichnis Ihrer App.

### **Rotation**

Verwenden Sie [createRotationEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) zum Erzeugen einer Rotation. [getBy](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/irotationeffect/#getBy--) gibt einen relativen Winkel in Grad an; [getFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/irotationeffect/#getFrom--) und [getTo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/irotationeffect/#getTo--) geben Endpunkte an.

Das Beispiel beginnt mit einem Spin‑Effekt, ersetzt dessen Vorgaben durch ein Rotations‑Verhalten und gibt diesem Vorgang eine zweisekündige Dauer. Ein relativer Winkel von 90 Grad entspricht einer Vierteldrehung von der Ausgangsausrichtung der Form, sodass kein expliziter Startwinkel nötig ist.

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

`rotation.pptx` enthält eine Form und ein Rotations‑Verhalten. Die untenstehenden Beispiele zu Sammlung, Timing und Rotations‑Bearbeitung verwenden diese Datei.

### **Skalierung**

Verwenden Sie [createScaleEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) mit X/Y‑Prozentsätzen: [getFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) und [getTo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iscaleeffect/#getTo--) beschreiben die Ausgangs‑ bzw. Endgröße, während [getBy](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iscaleeffect/#getBy--) eine relative Änderung angibt. Hier bedeutet 100 % die Originalgröße.

Das Beispiel vergrößert beide Dimensionen von 100 % auf 125 % über zwei Sekunden. Gleiche horizontale und vertikale Prozentsätze erhalten das Seitenverhältnis der Form; unterschiedliche Prozentsätze würden eine Dimension stärker strecken als die andere.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Farbe**

Verwenden Sie [createColorEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) um die Füllfarbe von Blau zu Orange zu ändern. [getFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icoloreffect/#getFrom--) und [getTo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icoloreffect/#getTo--) sind Farben; [getBy](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icoloreffect/#getBy--) ist ein Farb‑Offset. [IBehavior.getProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehavior/#getProperties--) identifiziert das animierte Attribut.

Die feste Füllung der Form wird zu Beginn auf Blau gesetzt, passend zur Startfarbe der Animation. Das Auswählen des Füll‑Farbe‑Attributs sagt dem Verhalten, welchen Teil der Form es ändern soll; die reinen Farb‑Endpunkte identifizieren das Attribut nicht. Der gespeicherte Effekt beschreibt einen zweisekündigen Übergang zu Orange.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filter**

Verwenden Sie [createFilterEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) um einen Wisch‑Effekt auszuwählen. [getType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--) und [getReveal](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) geben den Filter, die Richtung und ob die Form enthüllt oder verborgen werden soll, an.

Dieses Beispiel konfiguriert einen zweisekündigen Wisch, der die Form mit Subtyp „right“ enthüllt. Die Filter‑Einstellungen gehören zum Verhalten im Effekt, daher werden sie konfiguriert, nachdem die ursprünglichen Vorgaben entfernt wurden.

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

Verwenden Sie [createPropertyEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) um die Deckkraft zu animieren. [getFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipropertyeffect/#getTo--) und [getBy](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) sind Zeichenketten, die mittels [getValueType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) und [getCalcMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--) ausgewertet werden. Wählen Sie Endpunkte oder einen relativen Offset, statt alle drei indiscriminat festzulegen.

Hier ist das ausgewählte Attribut „opacity“ und die numerischen Zeichenketten beschreiben eine Änderung von 25 % Deckkraft zu voller Deckkraft. Lineare Interpolation beschreibt einen graduellen Übergang zwischen diesen Werten. Beim Anpassen dieses Beispiels auf ein anderes Attribut wählen Sie einen passenden Werte‑Typ und passende Endpunkt‑Werte.

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

### **Set**

Verwenden Sie [createSetEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) um Sichtbarkeit über [getTo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iseteffect/#getTo--) zuzuweisen. Ein Set‑Verhalten interpoliert nicht zwischen Endpunkten.

Das Beispiel wählt das Sichtbarkeits‑Attribut und weist den String `visible` zu, wenn das Verhalten ausgeführt wird. Das Rechteck ist in dieser minimalen Präsentation bereits sichtbar, sodass die Zuweisung allein keine offensichtliche visuelle Änderung bewirkt. Eine solche Operation ist nützlich als Teil eines größeren Effekts, der ebenfalls steuert, wann die Form verborgen oder sichtbar wird.

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

Verwenden Sie [createCommandEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) und konfigurieren Sie [getType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icommandeffect/#getCommandString--) sowie [getShapeTarget](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--). Legen Sie eine WAV‑Aufnahme namens `sample.wav` im Arbeitsverzeichnis ab. Dieses Beispiel bindet sie mit [addAudioFrameEmbedded](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) ein und verknüpft einen Play‑Befehl mit dem Audio‑Frame.

Der Audio‑Frame ist sowohl Ziel des Effekts als auch Ziel des Befehls. Das verbindet die Wiedergabeanfrage mit der eingebetteten Aufnahme; ein reiner Befehls‑String identifiziert nicht, welches Medien‑Objekt gesteuert werden soll. Der Effekt ist so konfiguriert, dass er bei einem Klick während der Bildschau startet.

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

Das Speichern legt den Befehl in `command.pptx` ab; die Aufnahme wird nicht abgespielt. Die Wiedergabe erfordert einen Bildschau‑Player, der den Befehl und sein Medien‑Ziel unterstützt.

## **Die Verhaltens‑Sammlung verwalten**

[IBehaviorCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorcollection/) unterstützt [add](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-) und [removeAt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Dieses Beispiel öffnet `rotation.pptx`, fügt Skalierung hinzu, verschiebt sie vor die Rotation und entfernt die Rotation. Das Entfernen und erneute Einfügen desselben Objekts ändert dessen gespeicherte Position, ohne eine Kopie zu erzeugen.

Die Abfolge der Änderungen verwandelt die Sammlung von Rotation–Scale zu Scale–Rotation und schließlich zu nur Scale. Indizes beziehen sich auf die aktuelle Sammlung, sodass das Entfernen den neuen Index der Rotation nach der Neuanordnung verwendet. Die abschließende Aufzählung bestätigt, welches Verhalten gespeichert wird.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
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

Die Ausgabe ist `ScaleEffect`: nur die Skalierung bleibt erhalten. Die Reihenfolge der Sammlung bestimmt nicht per se, dass Verhaltensweisen nacheinander abgespielt werden. Leeren Sie die Sammlung nur, wenn Sie alle Vorgänge ersetzen wollen.

## **Verhalten‑Timing konfigurieren**

[IBehavior.getTiming](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehavior/#getTiming--) gibt [ITiming](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/) zurück, unabhängig von [IEffect.getTiming](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#getTiming--). Effekt‑Timing plant den umschließenden Effekt; Verhaltens‑Timing beschreibt einen Vorgang innerhalb dieses Effekts.

### **Dauer, Verzögerung, Wiederholung und Beschleunigung festlegen**

Öffnen Sie `rotation.pptx` und setzen Sie die Dauer ([getDuration](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getDuration--)) sowie die Trigger‑Verzögerungszeit ([getTriggerDelayTime](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) in Sekunden, dann konfigurieren Sie die Wiederholungs‑Anzahl über [setRepeatCount](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getAccelerate--) und [getDecelerate](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getDecelerate--) sind Bruchteile der Dauer; ihre Summe darf höchstens 1 betragen.

Die Eingabedatei ist jene, die im Rotations‑Beispiel erzeugt wurde, wobei das erste Verhalten als Rotation bekannt ist. Dieses Beispiel ändert nur das Timing dieses Verhaltens; der 90‑Grad‑Winkel bleibt unverändert. Das getrennte Behandeln von Winkel und Timing erleichtert die Anpassung des Tempos, ohne die Animation neu zu bauen.

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

Das Verhalten verwendet eine zweisekündige Dauer, eine halbe Sekunde Verzögerung und eine Wiederholungs‑Anzahl von 3. Die ersten und letzten 20 % der Dauer werden für Beschleunigung bzw. Verzögerung verwendet.

Weitere Wiederholungs‑Richtlinien umfassen [getRepeatDuration](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) und [getRepeatUntilNextClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--); wählen Sie eine Richtlinie, anstatt alle zusammen zu aktivieren. [getAutoReverse](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getAutoReverse--) spielt die Animation nach dem Vorwärtspass rückwärts ab. Beschleunigung und Verzögerung gelten für kontinuierliche Änderungen, nicht für diskrete Zuweisungen oder Befehle.

## **Einen Bewegungsweg erstellen**

Verwenden Sie [createMotionEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) um Motion zu erzeugen. Seine [getFrom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotioneffect/#getTo--) und [getBy](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotioneffect/#getBy--) beschreiben prozentuale Koordinaten oder Offsets. Für eine editierbare Route erzeugen Sie einen [MotionPath](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/motionpath/) und setzen ihn mit [IMotionEffect.setPath](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotionpath/) speichert die Pfad‑Befehle.

[MotionCommandPathType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/motioncommandpathtype/) wählt die Operation aus:

| Befehl | Punkte | Bedeutung |
| --- | --- | --- |
| MoveTo | Einer | Startposition festlegen. |
| LineTo | Einer | Auf gerader Strecke zum Endpunkt bewegen. |
| CurveTo | Drei | Eine kubische Kurve folgen, definiert durch zwei Kontrollpunkte und einen Endpunkt. |
| CloseLoop | Keine | Zum Startpunkt zurückkehren. |
| End | Keine | Pfad beenden. |

[MotionPathPointsType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/motionpathpointstype/) beschreibt die Eigenschaften der Punktbearbeitung, z. B. Ecken‑ oder glatte Punkte. Es ersetzt nicht den Befehlstyp. Verwenden Sie für das Kurven‑Beispiel unten einen Kurven‑Punkt‑Typ und für die geraden Segmente einen Eck‑Punkt‑Typ.

Pfad‑Koordinaten sind relativ zu den Folienabmessungen normiert: Eine X‑Verschiebung von 0.25 entspricht einem Viertel der Folienbreite, nicht 0.25 Punkten. Positives Y verläuft nach unten. Absolute Befehle geben Positionen im Pfad‑Koordinatensystem an; relative Befehle geben Offsets zur aktuellen Position an. Das ist unabhängig von [getOrigin](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotioneffect/#getOrigin--), das den Referenzrahmen des Pfads wählt, und [getPathEditMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--), das steuert, wie sich der Pfad bewegt, wenn die Form verschoben wird.

### **Einen geraden Pfad erstellen**

Erzeugen Sie ein Bewegungs‑Verhalten mit Startpunkt, einem geraden Segment und einem End‑Befehl. [IMotionPath.add](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) nimmt den Befehls‑Typ, seine Punkte, den Punkt‑Typ und ein Flag für relative Koordinaten.

Der Start‑Befehl legt (0, 0) fest, und die Linie endet bei (0.25, 0), wodurch die Route eine horizontale Verschiebung von einem Viertel der Folienbreite erhält. Der End‑Befehl hat keine Koordinatenpunkte. Sobald der Pfad zugewiesen ist, verbindet das Hinzufügen des Bewegungs‑Verhaltens zum Effekt diese Route mit dem Rechteck.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` enthält ein Bewegungs‑Verhalten mit drei Pfad‑Befehlen. Die nachfolgenden Datei‑Bearbeitungs‑Beispiele nutzen diese bekannte Struktur.

### **Absolute und relative Koordinaten vergleichen**

Diese beiden Pfad‑Objekte beschreiben dieselbe Route. Der absolute Befehl endet bei (0.3, 0.1); der relative Befehl addiert (0.1, 0.1) zur aktuellen Position (0.2, 0).

Beide Pfade starten am selben Punkt. Für die relative Linie addieren Sie die X‑ und Y‑Offsets zur aktuellen Position, um den Endpunkt zu erhalten; bei der absoluten Linie lesen Sie den Endpunkt direkt. Das Flag ohne Koordinatenumrechnung zu ändern, würde eine andere Route beschreiben.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Weisen Sie entweder den einen oder den anderen Pfad einem Bewegungs‑Verhalten zu, um ihn in einer Präsentation zu nutzen. Das letzte boolesche Argument wählt relative Koordinaten für diesen Befehl.

### **Eine Linie durch eine Kurve ersetzen**

Öffnen Sie `motion.pptx` und ersetzen Sie dessen Linien‑Befehl durch eine kubische Kurve. Geben Sie zuerst die beiden Kontrollpunkte an, gefolgt vom Endpunkt.

Die Startposition wird durch den vorhergehenden Befehl bereitgestellt. Die ersten beiden Punkte formen die Kurve, der dritte ist ihr Ziel; sie sind nicht drei aufeinanderfolgende Ziele. Das gleichzeitige Aktualisieren von Befehls‑Typ, Punkt‑Bearbeitungs‑Typ und Punkt‑Array hält das Segment konsistent mit seiner neuen Geometrie.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Pfad in `curve.pptx` hat weiterhin drei Befehle; sein mittlerer Befehl definiert jetzt eine Kurve.

## **Einen gespeicherten Pfad prüfen und bearbeiten**

Jeder [IMotionCmdPath](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotioncmdpath/) liefert [getPoints](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--) und [isRelative](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--). Die folgenden Beispiele benutzen den bekannten Pfad mit drei Befehlen aus `motion.pptx`. Für beliebige Eingaben lokalisieren Sie zunächst den gewünschten Effekt und prüfen Sie Befehls‑Typen und Punkt‑Anzahlen, bevor Sie nach Index bearbeiten.

### **Befehle und Koordinaten auslesen**

Lesen Sie den Pfad, ohne ihn zu ändern. End‑ und Close‑Loop‑Befehle benötigen keine Punkte, erlauben Sie also ein null‑Punkt‑Array.

Die Ausgabe paart jeden numerischen Befehls‑Typ mit seinem Flag für relative Koordinaten, bevor die Punkte aufgelistet werden. So können Sie vor einer Pfad‑Änderung unterscheiden, ob ein Wert ein Endpunkt oder ein Offset ist. Eine Kurve würde drei Punkte auflisten, während die gerade Linie in dieser Datei nur einen Punkt listet.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Die Auflistung enthält einen Startpunkt, eine absolute Linie, die bei (0.25, 0) endet, und einen End‑Befehl.

### **Einen Endpunkt ändern**

Öffnen Sie `motion.pptx` und ersetzen Sie das Punkt‑Array der Linie, um deren Endpunkt zu verschieben.

Im Eingabefile ist Index 0 der Start‑Befehl und Index 1 die Linie. Das Ersetzen des einzigen Punktes der Linie ändert ihr Ziel, ohne den Befehls‑Typ, das Timing oder die Position in der Sammlung zu verändern. Da der Befehl absolute Koordinaten nutzt, gibt das neue Paar eine Position an, nicht ein zusätzliches Offset.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Linie in `motion-endpoint.pptx` endet bei (0.4, 0.1); die Originaldatei bleibt unverändert.

### **Ein Segment ersetzen**

Verwenden Sie [insert](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) und [removeAt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) um die Linie in `motion.pptx` zu ersetzen. Das Einfügen verschiebt die alte Linie zu Index 2.

Damit wird gezeigt, wie ein Befehls‑Objekt ersetzt wird, anstatt dessen bestehende Koordinaten zu editieren. Nach dem Einfügen enthält die Sammlung temporär den Start‑Befehl, die neue Linie, die alte Linie und den End‑Befehl. Das Entfernen von Index 2 verwirft die alte Linie und lässt die neue Route bestehen.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der gespeicherte Pfad hat weiterhin drei Befehle, wobei die neue Linie bei (0.2, 0.1) endet und der End‑Befehl zuletzt steht.

## **Ein vorhandenes Verhalten ändern und überprüfen**

Wenn der Index des Verhaltens unbekannt ist, wählen Sie es nach Typ aus. Dieses Beispiel öffnet `rotation.pptx`, findet den [IRotationEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/irotationeffect/), ändert den Winkel und prüft den gespeicherten Wert nach erneutem Öffnen.

Der Typ‑Check lässt die Schleife Verhaltensweisen überspringen, die keine Rotationen sind. Der zweite Ladevorgang liest die gespeicherte Datei in ein separates Präsentations‑Objekt ein, sodass der Vergleich persistente Daten prüft und nicht den noch im Speicher gehaltenen Wert. Dieses Beispiel geht weiterhin davon aus, dass der bekannte Effekt zuerst in der Hauptsequenz steht; das Auswählen eines Verhaltens nach Typ findet nicht unbedingt den korrekten Effekt in einer beliebigen Präsentation.

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

Die Ausgabe lautet `Rotation preserved: true`. Wenden Sie dieselbe Typ‑Prüfung für andere Verhaltensweisen an. Für eine vollständige Erhaltungs‑Prüfung vergleichen Sie Ziel‑Form, Effekt, Verhaltenstypen und -reihenfolge, Timing und Pfad‑Befehle. Verwenden Sie eine numerische Toleranz für Gleitkomma‑Werte. Für eine Präsentation mit unbekanntem Animations‑Layout siehe [Read Shape Animations](/slides/de/androidjava/shape-animation/#read-shape-animations) für die Traversierung von Haupt‑ und Interaktions‑Sequenzen.

## **Verhalten‑Reihenfolge, Vorgaben und Wiedergabe**

Die Reihenfolge in [IBehaviorCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehaviorcollection/) ist die gespeicherte Reihenfolge der Vorgänge eines Effekts. Sie ist keine Wiedergabeliste, in der jedes Verhalten automatisch auf das vorherige wartet. Timing und der umschließende Effekt bestimmen die Planung. Verhaltensweisen können sich überschneiden, und Vorgänge am selben Attribut können über [getAdditive](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehavior/#getAdditive--) und [getAccumulate](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibehavior/#getAccumulate--) interagieren. Verwenden Sie nicht allein das Umordnen der Sammlung, um „verschieben, dann drehen“ zu planen; benutzen Sie explizites Timing oder separate Effekte wie in [Shape Animation](/slides/de/androidjava/shape-animation/).

Der [getType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#getType--) und [getSubtype](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#getSubtype--) des Effekts beschreiben seine Vorgabe. Sie sind keine vollständige Beschreibung eines bearbeiteten Verhalten‑Baums. Wählen Sie Vorgabe und Untertyp, bevor Sie Verhaltensweisen anpassen: Das Ändern der Vorgabe kann die Sammlung neu aufbauen und Ihre benutzerdefinierten Vorgänge verwerfen. Ändert man z. B. einen angepassten Spin‑Effekt zu Fade, werden Rotations‑Verhalten durch Set‑ und Filter‑Verhalten ersetzt. Prüfen Sie die Sammlung erneut nach dem Ändern einer Vorgabe oder eines Untertyps. Das Leeren von Vorgabe‑Verhalten kann ebenfalls Sichtbarkeits‑ oder Initialisierungs‑Vorgänge entfernen, die die Vorgabe benötigt. Die Beispiele verwenden bewusst sichtbare Formen und ersetzen die Verhaltensweisen; sie rekonstruieren nicht jede Implementierung einer Vorgabe.

## **Format‑Kompatibilität**

Ein erhaltenes Verhalten‑Baumgarantiert nicht identische Wiedergabe in jedem Viewer oder Export‑Renderer. Prüfen Sie die gespeicherten Daten und die gerenderte Ausgabe getrennt.

| Format oder Ausgabe | Was zu prüfen ist |
| --- | --- |
| PPTX | Verwenden Sie dieses Format als primäres Beispiel. Öffnen Sie es erneut, um den editierbaren Verhalten‑Baum zu prüfen, dann testen Sie die Wiedergabe in der vorgesehenen PowerPoint‑Version. |
| PPT | Das alte binäre Format kann sich von PPTX unterscheiden. Testen Sie einen separaten Save‑und‑Reopen‑Zyklus und die Wiedergabe; schließen Sie nicht daraus, dass jede benutzerdefinierte Kombination unterstützt wird, weil PPTX erfolgreich war. |
| PDF, PNG, JPEG und andere statische Folien‑Bilder | Enthalten eine statische Folien‑Darstellung, keine abspielbare Verhalten‑Zeitlinie oder garantierten End‑Animations‑Frame. |
| [HTML5](/slides/de/androidjava/export-to-html5/) | Kann unterstützte Animationen abspielen, wenn Shape Animation in den Export‑Optionen aktiviert ist. Testen Sie benutzerdefinierte Kombinationen im Browser. |
| [Animated GIF](/slides/de/androidjava/convert-powerpoint-to-animated-gif/) | Speichert gerenderte Frames, nicht editierbare Verhaltensweisen oder klick‑gesteuerte Interaktion. Prüfen Sie die tatsächlich gerenderte Bewegung. |
| [Video](/slides/de/androidjava/convert-powerpoint-to-video/) | Rendert Animations‑Frames und kodiert sie als Video. Unterstützt werden nur die im Renderer dokumentierten [supported animations and effects](/slides/de/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects); Befehle und interaktive Events werden nicht zu einer editierbaren Zeitlinie. |

## **FAQ**

**Warum enthält mein Effekt Verhaltensweisen, bevor ich welche hinzugefügt habe?**

Das Erzeugen eines vordefinierten Effekts kann dessen zugrunde liegende Vorgänge erzeugen. Prüfen Sie sie, bevor Sie entscheiden, ob Sie die Vorgabe erweitern oder deren Verhaltensweisen ersetzen.

**Bewirkt das Verschieben eines Verhaltens an den Anfang, dass es zuerst abgespielt wird?**

Nicht zwingend. Die Reihenfolge der Sammlung ersetzt nicht das Timing. Prüfen Sie Verzögerungen, Dauern und Wechselwirkungen zwischen Vorgängen am selben Attribut.

**Warum hat ein End‑Befehl keine Punkte?**

Er markiert das Ende des Pfads und benötigt keine Koordinaten. Achten Sie beim Inspektieren eines aus einer Datei gelesenen Pfads auf ein null‑Punkt‑Array.

**Reicht ein erfolgreicher Round‑Trip aus, um die Wiedergabe zu bestätigen?**

Nein. Das erneute Öffnen bestätigt das Beibehalten der geprüften Eigenschaften. Testen Sie den Präsentations‑Player oder den animierten Export separat, um das visuelle Verhalten zu verifizieren.