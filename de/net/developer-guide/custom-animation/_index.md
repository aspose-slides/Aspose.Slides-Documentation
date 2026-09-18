---
title: Erstellen und Anpassen benutzerdefinierter Animationsverhalten in .NET
linktitle: Benutzerdefinierte Animation
type: docs
weight: 151
url: /de/net/custom-animation/
keywords:
- benutzerdefinierte Animation
- Animationsverhalten
- Bewegungspfad
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen, inspizieren und anpassen benutzerdefinierter Animationsverhalten und editierbarer Bewegungspfade in PowerPoint-Präsentationen mit Aspose.Slides für .NET."
---
## **Überblick**

Benutzerdefinierte Animationsverhalten ermöglichen die Steuerung einzelner Vorgänge innerhalb eines Animationseffekts, z. B. das Ändern einer Farbe, das Drehen einer Form oder das Folgen eines bearbeitbaren Bewegungspfads. Dieser Leitfaden zeigt, wie Sie Verhaltensweisen erstellen und kombinieren, deren Timing konfigurieren, vorhandene Animationen inspizieren und ändern sowie überprüfen, dass ihre Eigenschaften das Speichern und erneute Öffnen einer Präsentation überstehen.

Für vordefinierte Effekte und Klick‑Trigger siehe [Formanimation](/slides/de/net/shape-animation/).

## **Verstehen des Animationsmodells**

Eine Animation ist strukturiert als **Timeline → Sequence → Effect → Behaviors**:

- Die Folie's [Timeline](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/timeline/) enthält ihre Hauptsequenz und interaktive Sequenzen.
- Ein [ISequence](https://reference.aspose.com/slides/de/net/aspose.slides.animation/isequence/) enthält Effekte, die ggf. verschiedene Formen ansprechen.
- Ein [IEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/) identifiziert eine Zielform, ein Preset, einen Subtyp und das Timing des Effekts.
- [IEffect.Behaviors](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/behaviors/) enthält die Vorgänge, die den Effekt umsetzen: Farbe ändern, bewegen, drehen, eine Eigenschaft setzen usw.

## **Einzelne Verhaltensweisen erstellen**

Rufen Sie [ISequence.AddEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/isequence/addeffect/) auf, um einen Effekt zu erzeugen und auf dessen [Behaviors](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/behaviors/)‑Sammlung zuzugreifen. Ein Preset kann diese Sammlung automatisch füllen. Bewahren Sie die Vorgänge, wenn Sie das Preset erweitern, oder verwenden Sie [Clear](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorcollection/clear/), wenn Sie sie bewusst ersetzen.

[IBehaviorFactory](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorfactory/) erzeugt die acht unten illustrierten Verhaltenstypen. Bewegung wird in [Erstellen eines Bewegungspfads](#build-a-motion-path) behandelt. Jeder Erstellungscode ist ein vollständiges Programm; spätere Bearbeitungsbeispiele geben an, welche Ausgabedatei sie verwenden.

### **Drehung**

Verwenden Sie [CreateRotationEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/), um eine Drehung zu erzeugen. [By](https://reference.aspose.com/slides/de/net/aspose.slides.animation/irotationeffect/by/) gibt einen relativen Winkel in Grad an; [From](https://reference.aspose.com/slides/de/net/aspose.slides.animation/irotationeffect/from/) und [To](https://reference.aspose.com/slides/de/net/aspose.slides.animation/irotationeffect/to/) geben Endpunkte an.

Das Beispiel startet mit einem Spin‑Effekt, ersetzt dessen Preset‑Vorgänge durch ein Dreh‑Verhalten und gibt diesem Vorgang eine zweisekündige Dauer. Ein relativer Winkel von 90 Grad entspricht einer Vierteldrehung von der Ausgangsausrichtung der Form, sodass kein expliziter Startwinkel nötig ist.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` enthält eine Form und ein Dreh‑Verhalten. Die Sammlung, das Timing und die nachfolgenden Dreh‑Bearbeitungsbeispiele verwenden diese Datei.

### **Skalierung**

Verwenden Sie [CreateScaleEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) mit X/Y‑Prozentwerten: [From](https://reference.aspose.com/slides/de/net/aspose.slides.animation/iscaleeffect/from/) und [To](https://reference.aspose.com/slides/de/net/aspose.slides.animation/iscaleeffect/to/) beschreiben die Ausgangs‑ bzw. Endgröße, während [By](https://reference.aspose.com/slides/de/net/aspose.slides.animation/iscaleeffect/by/) eine relative Änderung angibt. Hier bedeutet 100 % die Originalgröße.

Das Beispiel vergrößert beide Dimensionen von 100 % auf 125 % über zwei Sekunden. Gleiche horizontale und vertikale Prozentsätze erhalten das Seitenverhältnis der Form; unterschiedliche Werte würden eine Dimension stärker strecken als die andere.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **Farbe**

Verwenden Sie [CreateColorEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/), um die Füllung von Blau nach Orange zu ändern. [From](https://reference.aspose.com/slides/de/net/aspose.slides.animation/icoloreffect/from/) und [To](https://reference.aspose.com/slides/de/net/aspose.slides.animation/icoloreffect/to/) sind Farben; [By](https://reference.aspose.com/slides/de/net/aspose.slides.animation/icoloreffect/by/) ist ein Farb‑Offset. [IBehavior.Properties](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehavior/properties/) identifiziert das animierte Attribut.

Die feste Füllung der Form wird initial auf Blau gesetzt, passend zur Startfarbe der Animation. Die Auswahl des Füll‑Farb‑Attributes teilt dem Verhalten mit, welchen Teil der Form es ändern soll; allein die Farb‑Endpunkte identifizieren das Attribut nicht. Der gespeicherte Effekt beschreibt einen zweisekündigen Übergang zu Orange.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **Filter**

Verwenden Sie [CreateFilterEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/), um einen Wisch‑Effekt auszuwählen. [Type](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ifiltereffect/subtype/) und [Reveal](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ifiltereffect/reveal/) geben Filter, Richtung und ob die Form enthüllt oder verborgen werden soll an.

Dieses Beispiel konfiguriert einen zweisekündigen Wisch, der die Form mit dem Subtyp „right‑direction“ enthüllt. Die Filtereinstellungen gehören zum Verhalten innerhalb des Effekts und werden deshalb konfiguriert, nachdem die ursprünglichen Vorgänge des Presets entfernt wurden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **Eigenschaft**

Verwenden Sie [CreatePropertyEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/), um die Opazität zu animieren. [From](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ipropertyeffect/to/) und [By](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ipropertyeffect/by/) sind Zeichenketten, die über [ValueType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ipropertyeffect/valuetype/) und [CalcMode](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ipropertyeffect/calcmode/) interpretiert werden. Wählen Sie Endpunkte oder einen relativen Offset, anstatt alle drei wahllos zu setzen.

Hier ist das ausgewählte Attribut Opazität, und die numerischen Zeichenketten beschreiben eine Änderung von 25 % Opazität auf volle Opazität. Lineare Interpolation beschreibt einen allmählichen Übergang zwischen diesen Werten. Wenn Sie dieses Beispiel auf ein anderes Attribut anpassen, wählen Sie einen passenden Werttyp und passende Endwerte für das Attribut.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **Setzen**

Verwenden Sie [CreateSetEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorfactory/createseteffect/), um die Sichtbarkeit über [To](https://reference.aspose.com/slides/de/net/aspose.slides.animation/iseteffect/to/) zuzuweisen. Ein Set‑Verhalten interpoliert nicht zwischen Endpunkten.

Das Beispiel wählt das Sichtbarkeits‑Attribut und weist beim Ausführen des Verhaltens die Zeichenkette `visible` zu. Das Rechteck ist in dieser Minimalpräsentation bereits sichtbar, sodass die Zuweisung allein keine offensichtliche visuelle Änderung bewirkt. Eine solche Aktion ist nützlich im Rahmen eines größeren Effekts, der ebenfalls steuert, wann die Form verborgen oder sichtbar wird.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **Befehl**

Verwenden Sie [CreateCommandEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) und konfigurieren Sie [Type](https://reference.aspose.com/slides/de/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/de/net/aspose.slides.animation/icommandeffect/commandstring/) und [ShapeTarget](https://reference.aspose.com/slides/de/net/aspose.slides.animation/icommandeffect/shapetarget/). Legen Sie eine WAV‑Aufnahme namens `sample.wav` im Arbeitsverzeichnis ab. Dieses Beispiel bettet sie mit [AddAudioFrameEmbedded](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addaudioframeembedded/) ein und fügt einen Wiedergabe‑Befehl zum Audio‑Frame hinzu.

Der Audio‑Frame ist sowohl Ziel des Effekts als auch Ziel des Befehls. Dadurch wird die Wiedergabeanforderung mit der eingebetteten Aufnahme verknüpft; ein reiner Befehls‑String identifiziert nicht, welches Medien‑Objekt zu steuern ist. Der Effekt ist so konfiguriert, dass er bei einem Klick während der Bildschirmpräsentation startet.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

Das Speichern legt den Befehl in `command.pptx` ab; die Aufnahme wird nicht abgespielt. Die Wiedergabe erfordert einen Präsentations‑Player, der den Befehl und sein Medienziel unterstützt.

## **Verwalten der Verhaltenssammlung**

[IBehaviorCollection](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorcollection/) unterstützt [Add](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorcollection/remove/), und [RemoveAt](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorcollection/removeat/). Dieses Beispiel öffnet `rotation.pptx`, fügt Skalierung hinzu, verschiebt sie vor die Drehung und entfernt die Drehung. Das Entfernen und erneute Einfügen desselben Objekts ändert dessen gespeicherte Position, ohne eine Kopie zu erzeugen.

Die Abfolge von Änderungen wandelt die Sammlung von rotation–scale zu scale–rotation und schließlich zu nur scale um. Indizes beziehen sich auf die aktuelle Sammlung, sodass die Entfernung den neuen Index der Drehung nach der Neuordnung verwendet. Die abschließende Aufzählung bestätigt, welches Verhalten gespeichert wird.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

Die Ausgabe lautet `ScaleEffect`: nur die Skalierung bleibt erhalten. Die Reihenfolge der Sammlung allein plant Verhaltensweisen nicht nacheinander. Leeren Sie die Sammlung nur, wenn Sie alle Vorgänge ersetzen wollen.

## **Timing der Verhaltensweisen konfigurieren**

[IBehavior.Timing](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehavior/timing/) stellt [ITiming](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/) bereit, unabhängig von [IEffect.Timing](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/timing/). Das Effekt‑Timing plant den umgebenden Effekt; das Verhaltens‑Timing beschreibt einen Vorgang darin.

### **Dauer, Verzögerung, Wiederholung und Beschleunigung festlegen**

Öffnen Sie `rotation.pptx` und setzen Sie [Duration](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/duration/) sowie [TriggerDelayTime](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/triggerdelaytime/) in Sekunden, dann konfigurieren Sie [RepeatCount](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/accelerate/) und [Decelerate](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/decelerate/) sind Bruchteile der Dauer; deren Summe darf höchstens 1 betragen.

Die Eingabedatei ist die im Drehungsbeispiel erstellte, bei der das erste Verhalten als Drehung bekannt ist. Dieses Beispiel ändert nur das Timing dieses Verhaltens; sein 90‑Grad‑Winkel bleibt unverändert. Die Trennung von Winkel und Timing erleichtert das Anpassen des Tempos, ohne die Animation neu aufzubauen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

Das Verhalten nutzt eine zweisekündige Dauer, eine halbe Sekunde Verzögerung und einen Wiederholungs‑Count von 3. Die ersten und letzten 20 % seiner Dauer werden für Beschleunigung bzw. Verzögerung verwendet.

Weitere Wiederholungs‑Richtlinien umfassen [RepeatDuration](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatuntilendslide/), und [RepeatUntilNextClick](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatuntilnextclick/); wählen Sie eine Richtlinie, anstatt sie alle gleichzeitig zu aktivieren. [AutoReverse](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/autoreverse/) spielt die Animation nach dem Vorwärtslauf rückwärts ab. Beschleunigung und Verzögerung gelten für kontinuierliche Änderungen, nicht für diskrete Zuweisungen oder Befehle.

## **Erstellen eines Bewegungspfads**

Verwenden Sie [CreateMotionEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/), um Bewegung zu erzeugen. Seine [From](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotioneffect/to/), und [By](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotioneffect/by/) beschreiben prozentuale Koordinaten oder Offsets. Für eine editierbare Route erzeugen Sie einen [MotionPath](https://reference.aspose.com/slides/de/net/aspose.slides.animation/motionpath/) und weisen ihn [IMotionEffect.Path](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotioneffect/path/) zu. [IMotionPath](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotionpath/) speichert die Pfad‑Befehle.

[MotionCommandPathType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/motioncommandpathtype/) wählt die Operation:

| Befehl | Punkte | Bedeutung |
| --- | --- | --- |
| MoveTo | One | Setzt die Startposition. |
| LineTo | One | Bewegt sich entlang eines geraden Segments zu dessen Endpunkt. |
| CurveTo | Three | Folgt einer kubischen Kurve, definiert durch zwei Kontrollpunkte und einen Endpunkt. |
| CloseLoop | None | Kehrt zur Startposition zurück. |
| End | None | Beendet den Pfad. |

[MotionPathPointsType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/motionpathpointstype/) beschreibt Eigenschaften zur Punktbearbeitung, etwa Eck‑ oder glatte Punkte. Es ersetzt nicht den Befehlstyp. Verwenden Sie für das Kurven‑Beispiel unten einen Kurven‑Punktetyp und für die Geradensegmente einen Eck‑Punktetyp.

Pfadkoordinaten sind auf die Folienmaße normalisiert: Eine X‑Verschiebung von 0,25 entspricht einem Viertel der Folienbreite, nicht 0,25 Punkten. Positives Y läuft nach unten. Absolute Befehle geben Positionen im Pfad‑Koordinatensystem an; relative Befehle geben Offsets zur aktuellen Position an. Das ist unabhängig von [Origin](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotioneffect/origin/), das den Referenzrahmen des Pfads wählt, und von [PathEditMode](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotioneffect/patheditmode/), das steuert, wie sich der Pfad bewegt, wenn die Form verschoben wird.

### **Erstelle einen geraden Pfad**

Erzeugen Sie ein Bewegungs‑Verhalten mit einem Startpunkt, einem geraden Segment und einem End‑Befehl. [IMotionPath.Add](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotionpath/add/) nimmt den Befehlstyp, seine Punkte, den Punktetyp und ein Flag für relative Koordinaten.

Der Startbefehl legt (0, 0) fest, und die Linie endet bei (0.25, 0), wodurch die Route eine horizontale Verschiebung von einem Viertel der Folienbreite erhält. Der End‑Befehl hat keine Koordinatenpunkte. Sobald der Pfad zugewiesen ist, verbindet das Hinzufügen des Bewegungs‑Verhaltens zum Effekt diese Route mit dem Rechteck.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` enthält ein Bewegungs‑Verhalten mit drei Pfad‑Befehlen. Die nachfolgenden Datei‑Bearbeitungsbeispiele nutzen diese bekannte Struktur.

### **Vergleiche absolute und relative Koordinaten**

Diese beiden Pfad‑Objekte beschreiben dieselbe Route. Der absolute Befehl endet bei (0.3, 0.1); der relative Befehl addiert (0.1, 0.1) zur aktuellen Position, (0.2, 0).

Beide Pfade starten an derselben Position. Für die relative Linie addieren Sie deren X‑ und Y‑Offsets zur aktuellen Position, um den Endpunkt zu erhalten; für die absolute Linie lesen Sie den Endpunkt direkt. Das Wechseln des Flags ohne Umrechnung der Koordinaten würde eine andere Route beschreiben.

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Weisen Sie entweder den einen oder den anderen Pfad einem Bewegungs‑Verhalten zu, um ihn in einer Präsentation zu verwenden. Das abschließende Boolesche Argument wählt relative Koordinaten für diesen Befehl aus.

### **Ersetze eine Linie durch eine Kurve**

Öffnen Sie `motion.pptx` und ersetzen Sie dessen Linien‑Befehl durch eine kubische Kurve. Geben Sie zuerst die beiden Kontrollpunkte, dann den Endpunkt an.

Die Startposition wird vom vorhergehenden Befehl geliefert. Die ersten beiden Punkte formen die Kurve, der dritte ist ihr Ziel; sie sind nicht drei aufeinanderfolgende Ziele. Das gleichzeitige Aktualisieren von Befehlstyp, Punkt‑Bearbeitungstyp und Punkt‑Array hält das Segment konsistent mit seiner neuen Geometrie.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

Der Pfad in `curve.pptx` hat weiterhin drei Befehle; sein mittlerer Befehl definiert nun eine Kurve.

## **Gespeicherten Pfad inspizieren und bearbeiten**

Jeder [IMotionCmdPath](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotioncmdpath/) stellt [Points](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotioncmdpath/pointstype/), und [IsRelative](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotioncmdpath/isrelative/) bereit. Die folgenden Beispiele nutzen den bekannten dreibefehligen Pfad in `motion.pptx`. Bei beliebigen Eingaben lokalisieren Sie zunächst den gewünschten Effekt und prüfen Sie Befehls‑Typen und Punktzahlen, bevor Sie per Index bearbeiten.

### **Befehle und Koordinaten lesen**

Lesen Sie den Pfad, ohne ihn zu verändern. End‑ und CloseLoop‑Befehle benötigen keine Punkte, also erlauben Sie ein null‑Punkt‑Array.

Die Ausgabe kombiniert jeden Befehl mit seinem Flag für relative Koordinaten, bevor die Punkte aufgelistet werden. So können Sie einen Endpunkt von einem Offset unterscheiden, bevor Sie den Pfad ändern. Eine Kurve würde drei Punkte listen, während die gerade Linie in dieser Datei nur einen Punkt auflistet.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

Die Auflistung enthält einen Startpunkt, eine absolute Linie, die bei (0.25, 0) endet, und einen End‑Befehl.

### **Endpunkt ändern**

Öffnen Sie `motion.pptx` und ersetzen Sie das Punkt‑Array der Linie, um deren Endpunkt zu verschieben.

Im Eingabefile ist Index 0 der Startbefehl und Index 1 die Linie. Das Ersetzen des einzigen Punkts der Linie ändert ihr Ziel, ohne den Befehlstyp, das Timing oder die Position in der Sammlung zu verändern. Da der Befehl absolute Koordinaten verwendet, gibt das neue Paar eine Position anstatt eines hinzugefügten Offsets an.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

Die Linie in `motion-endpoint.pptx` endet bei (0.4, 0.1); die Originaldatei bleibt unverändert.

### **Segment ersetzen**

Verwenden Sie [Insert](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotionpath/insert/) und [RemoveAt](https://reference.aspose.com/slides/de/net/aspose.slides.animation/imotionpath/removeat/), um die Linie in `motion.pptx` zu ersetzen. Das Einfügen verschiebt die alte Linie zu Index 2.

Damit wird gezeigt, dass ein Befehls‑Objekt ersetzt wird, anstatt seine bestehenden Koordinaten zu editieren. Nach dem Einfügen enthält die Sammlung vorübergehend den Startbefehl, die neue Linie, die alte Linie und den End‑Befehl. Das Entfernen von Index 2 verwirft die alte Linie und lässt die neue Route bestehen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

Der gespeicherte Pfad hat weiterhin drei Befehle, wobei die neue Linie bei (0.2, 0.1) endet und der End‑Befehl zuletzt steht.

## **Vorhandenes Verhalten ändern und überprüfen**

Wenn der Index eines Verhaltens unbekannt ist, wählen Sie es nach Typ aus. Dieses Beispiel öffnet `rotation.pptx`, findet dessen [IRotationEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/irotationeffect/), ändert den Winkel und prüft den gespeicherten Wert nach erneutem Öffnen.

Die Typprüfung lässt die Schleife Verhaltensweisen überspringen, die keine Drehungen sind. Der zweite Ladevorgang liest die gespeicherte Datei in ein separates Präsentationsobjekt ein, sodass der Vergleich persistente Daten prüft und nicht den noch im Speicher befindlichen Wert. Dieses Beispiel geht weiterhin davon aus, dass der bekannte Effekt zuerst in der Hauptsequenz steht; die Auswahl nach Typ findet nicht zwingend den richtigen Effekt in einer beliebigen Präsentation.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

Die Ausgabe lautet `Rotation preserved: True`. Wenden Sie das gleiche Typ‑Prüfmuster auf andere Verhaltensweisen an. Für eine vollständige Erhaltungs‑Prüfung vergleichen Sie Ziel‑Form, Effekt, Verhaltenstypen und -reihenfolge, Timing und Pfadbefehle. Verwenden Sie eine numerische Toleranz für Gleitkommawerte. Für eine Präsentation mit unbekannter Animationsstruktur siehe [Formanimation lesen](/slides/de/net/shape-animation/#read-shape-animations) für die Durchquerung von Haupt‑ und Interaktionssequenzen.

## **Verhaltensreihenfolge, Presets und Wiedergabe**

Die Reihenfolge in [IBehaviorCollection](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehaviorcollection/) ist die gespeicherte Reihenfolge der Vorgänge eines Effekts. Sie ist keine Wiedergabeliste, in der jedes Verhalten automatisch auf das vorherige wartet. Timing und der umgebende Effekt bestimmen die Planung. Verhaltensweisen können sich überschneiden, und Vorgänge am selben Attribut können über [Additive](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehavior/additive/) und [Accumulate](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ibehavior/accumulate/) interagieren. Verwenden Sie nicht allein das Neuordnen der Sammlung, um „Bewegen, dann Drehen“ zu planen; nutzen Sie explizites Timing oder separate Effekte, wie in [Formanimation](/slides/de/net/shape-animation/) beschrieben.

Der Effekt‑[Type](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/type/) und [Subtype](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/subtype/) beschreiben sein Preset. Sie sind keine vollständige Beschreibung eines bearbeiteten Verhaltensbaums. Wählen Sie Preset und Subtyp, bevor Sie Verhaltensweisen anpassen: Das Ändern des Presets kann die Sammlung neu aufbauen und Ihre eigenen Vorgänge verwerfen. Beispiel: Das Umstellen eines angepassten Spin‑Effekts auf Fade kann das Dreh‑Verhalten durch Set‑ und Filter‑Verhalten ersetzen. Prüfen Sie die Sammlung erneut nach einer Preset‑ oder Subtyp‑Änderung. Das Leeren von Preset‑Verhaltensweisen kann zudem Sichtbarkeits‑ oder Initialisierungs‑Vorgänge entfernen, die das Preset benötigt. Die Beispiele verwenden bewusst sichtbare Formen und ersetzen die Verhaltensweisen; sie rekonstruieren nicht die gesamte Implementierung jedes Presets.

## **Formatkompatibilität**

Ein erhaltenes Verhaltens‑Baumdiagramm garantiert nicht identische Wiedergabe in jedem Viewer oder Export‑Renderer. Prüfen Sie die gespeicherten Daten und die gerenderte Ausgabe getrennt.

| Format oder Ausgabe | Was zu überprüfen ist |
| --- | --- |
| PPTX | Verwenden Sie dieses Format als primäres für die Beispiele. Öffnen Sie es erneut, um den editierbaren Verhaltensbaum zu prüfen, und testen Sie dann die Wiedergabe in der vorgesehenen PowerPoint‑Version. |
| PPT | Das klassische binäre Format kann von PPTX abweichen. Testen Sie einen separaten Speicher‑und‑Öffnen‑Zyklus und die Wiedergabe; schließen Sie nicht auf Unterstützung jeder benutzerdefinierten Kombination nur aus erfolgreichem PPTX‑Ausstoß. |
| PDF, PNG, JPEG und andere statische Folienbilder | Enthalten eine statische Folien­darstellung, keinen abspielbaren Verhaltens‑Zeitstrahl oder einen garantierten End‑Animations‑Frame. |
| [HTML5](/slides/de/net/export-to-html5/) | Kann unterstützte Animationen abspielen, wenn Formanimation in den Export‑Optionen aktiviert ist. Testen Sie benutzerdefinierte Kombinationen im Browser. |
| [Animated GIF](/slides/de/net/convert-powerpoint-to-animated-gif/) | Speichert gerenderte Frames, nicht editierbare Verhaltensweisen oder klick‑basierte Interaktion. Prüfen Sie die tatsächlich gerenderte Bewegung. |
| [Video](/slides/de/net/convert-powerpoint-to-video/) | Rendert Animations‑Frames und kodiert sie als Video. Der Support ist auf die vom Renderer [unterstützten Animationen und Effekte](/slides/de/net/convert-powerpoint-to-video/#supported-animations-and-effects) beschränkt; Befehle und interaktive Ereignisse werden nicht zu einer editierbaren Zeitleiste. |

## **FAQ**

**Warum enthält mein Effekt Verhaltensweisen, bevor ich welche hinzufüge?**  
Ein vordefinierter Effekt kann seine zugrunde liegenden Vorgänge bereits erzeugen. Inspizieren Sie sie, bevor Sie entscheiden, das Preset zu erweitern oder seine Verhaltensweisen zu ersetzen.

**Führt das Verschieben eines Verhaltens an den Anfang dazu, dass es zuerst abgespielt wird?**  
Nicht unbedingt. Die Reihenfolge der Sammlung ersetzt nicht das Timing. Prüfen Sie Verzögerungen, Dauern und Interaktionen zwischen Vorgängen am selben Attribut.

**Warum hat ein End‑Befehl keine Punkte?**  
Er markiert das Ende des Pfads und benötigt keine Koordinaten. Beim Inspizieren eines Pfads aus einer Datei sollten Sie ein null‑Punkt‑Array berücksichtigen.

**Reicht ein erfolgreicher Round‑Trip aus, um die Wiedergabe zu bestätigen?**  
Nein. Das erneute Öffnen bestätigt nur die erhaltenen Eigenschaften. Testen Sie den Präsentations‑Player oder den animierten Export separat, um das visuelle Verhalten zu verifizieren.