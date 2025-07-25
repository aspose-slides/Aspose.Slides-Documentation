---
title: Formanimationen in Präsentationen mit Python anwenden
linktitle: Formanimation
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
description: "Entdecken Sie, wie Sie Formanimationen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides for Python via .NET erstellen und anpassen. Heben Sie sich ab!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/de/python-net/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben.

### **Warum Animationen in Präsentationen verwenden?**

Durch die Verwendung von Animationen können Sie

* den Fluss von Informationen steuern
* wichtige Punkte hervorheben
* das Interesse oder die Beteiligung Ihres Publikums erhöhen
* Inhalte leichter lesbar, verständlich oder verarbeitbar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile der Präsentation lenken

PowerPoint bietet viele Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Hervorhebung** und **Bewegungsbahnen**.

### **Animationen in Aspose.Slides**

* Aspose.Slides bietet die Klassen und Typen, die Sie benötigen, um mit Animationen im [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) Namespace zu arbeiten,
* Aspose.Slides bietet über **150 Animationseffekte** unter der [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) Enumeration. Diese Effekte sind im Wesentlichen die gleichen (oder äquivalenten) Effekte, die in PowerPoint verwendet werden.

## **Animation auf TextBox anwenden**

Aspose.Slides für Python über .NET ermöglicht es Ihnen, Animationen auf den Text in einer Form anzuwenden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
4. Fügen Sie Text zu `IAutoShape.TextFrame` hinzu.
5. Holen Sie sich eine Hauptsequenz von Effekten.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
7. Setzen Sie die `TextAnimation.BuildType`-Eigenschaft auf den Wert aus der `BuildType`-Enumeration.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Python-Code zeigt Ihnen, wie Sie den `Fade`-Effekt auf AutoShape anwenden und die Textanimation auf den *Nach 1. Ebene Absätzen* Wert setzen:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Fügt eine neue AutoShape mit Text hinzu
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "Erster Absatz \nZweiter Absatz \n Dritter Absatz"

    # Holt sich die Hauptsequenz der Folie.
    sequence = sld.timeline.main_sequence

    # Fügt dem Shape einen Fade-Animationseffekt hinzu
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animiert den Text des Shapes nach den 1. Ebene Absätzen
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Speichern Sie die PPTX-Datei auf der Festplatte
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) anwenden. Siehe [**Animierter Text**](/slides/de/python-net/animated-text/).

{{% /alert %}} 

## **Animation auf PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Fügen Sie einen [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) auf der Folie hinzu oder holen Sie ihn.
4. Holen Sie sich die Hauptsequenz von Effekten.
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) hinzu.
6. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Python-Code zeigt Ihnen, wie Sie den `Fly`-Effekt auf einen Bildrahmen anwenden:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as pres:
    # Lädt ein Bild, das in der Präsentation hinzugefügt werden soll
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Fügt einen PictureFrame zur Folie hinzu
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Holt sich die Hauptsequenz der Folie.
    sequence = pres.slides[0].timeline.main_sequence

    # Fügt dem PictureFrame einen Fly von links-Animationseffekt hinzu
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Speichern Sie die PPTX-Datei auf der Festplatte
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animation auf Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Fügen Sie eine `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
4. Fügen Sie eine `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Sequenz von Effekten auf der Bevel-Form.
6. Erstellen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle hinzu, um zum `UserPath` zu bewegen.
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.

Dieser Python-Code zeigt Ihnen, wie Sie den `PathFootball` (Fußballpfad) Effekt auf eine Form anwenden:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Erstellt den PathFootball-Effekt für eine vorhandene Form von Grund auf.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animierter Textkasten")

    # Fügt den PathFootBall-Animationseffekt hinzu.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Erstellt eine Art "Schaltfläche".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Erstellt eine Sequenz von Effekten für die Schaltfläche.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Erstellt einen benutzerdefinierten Benutzerpfad. Unser Objekt wird nur bewegt, nachdem die Schaltfläche geklickt wurde.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Fügt Befehle zum Bewegen hinzu, da der erstellte Pfad leer ist.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Die auf eine Form angewendeten Animationseffekte abrufen**

Sie können sich entscheiden, alle auf eine bestimmte Form angewendeten Animationseffekte herauszufinden.

Dieser Python-Code zeigt Ihnen, wie Sie alle auf eine bestimmte Form angewendeten Effekte abrufen:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
with slides.Presentation("AnimExample_out.pptx") as pres:
    firstSlide = pres.slides[0]

    # Holt sich die Hauptsequenz der Folie.
    sequence = firstSlide.timeline.main_sequence

    # Holt sich die erste Form auf der Folie.
    shape = firstSlide.shapes[0]

    # Holt sich alle auf die Form angewendeten Animationseffekte.
    shapeEffects = sequence.get_effects_by_shape(shape)

    if len(shapeEffects) > 0:
        print("Die Form " + shape.name + " hat " + str(len(shapeEffects)) + " Animationseffekte.")
```

## **Animationseffekt-Zeitparameter ändern**

Aspose.Slides für Python über .NET ermöglicht Ihnen, die Zeitparameter eines Animationseffekts zu ändern.

Das ist das Animations-Zeitpaneel in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Diese sind die Entsprechungen zwischen PowerPoint-Zeiten und den `Effect.Timing`-Eigenschaften:

- PowerPoint Zeit **Start** Dropdown-Liste entspricht der [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) Eigenschaft. 
- PowerPoint Zeit **Dauer** entspricht der `Effect.Timing.Duration`-Eigenschaft. Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation benötigt, um einen Zyklus abzuschließen. 
- PowerPoint Zeit **Verzögerung** entspricht der `Effect.Timing.TriggerDelayTime`-Eigenschaft. 

So ändern Sie die Effekt-Zeitparameter:

1. [Wenden Sie an](#apply-animation-to-shape) oder holen Sie sich den Animationseffekt.
2. Setzen Sie neue Werte für die benötigten `Effect.Timing`-Eigenschaften. 
3. Speichern Sie die modifizierte PPTX-Datei.

Dieser Python-Code demonstriert die Operation:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Holt sich die Hauptsequenz der Folie.
    sequence = pres.slides[0].timeline.main_sequence

    # Holt sich den ersten Effekt der Hauptsequenz.
    effect = sequence[0]

    # Ändert den TriggerType des Effekts, um beim Klicken zu starten
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Ändert die Dauer des Effekts
    effect.timing.duration = 3

    # Ändert die TriggerDelayTime des Effekts
    effect.timing.trigger_delay_time = 0.5

    # Speichert die PPTX-Datei auf der Festplatte
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Animations-Effekt-Sound**

Aspose.Slides bietet diese Eigenschaften, die es Ihnen ermöglichen, mit Sounds in Animationseffekten zu arbeiten: 

- `sound`
- `stop_previous_sound`

### **Animationseffekt-Sound hinzufügen**

Dieser Python-Code zeigt Ihnen, wie Sie einen Animationseffekt-Sound hinzufügen und ihn stoppen, wenn der nächste Effekt beginnt:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Fügt Audio zur Präsentations-Audiosammlung hinzu
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Holt sich die Hauptsequenz der Folie.
    sequence = first_slide.timeline.main_sequence

    # Holt sich den ersten Effekt der Hauptsequenz
    first_effect = sequence[0]

    # Überprüft den Effekt auf "Kein Sound"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Fügt Sound für den ersten Effekt hinzu
        first_effect.sound = effect_sound

    # Holt sich die erste interaktive Sequenz der Folie.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Setzt den Effekt "Vorherigen Sound stoppen"-Flag
    interactive_sequence[0].stop_previous_sound = True

    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Animations-Effekt-Sound extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index. 
3. Holen Sie sich die Hauptsequenz von Effekten. 
4. Extrahieren Sie den `sound`, der in jeden Animationseffekt eingebettet ist. 

Dieser Python-Code zeigt Ihnen, wie Sie den in einem Animationseffekt eingebetteten Sound extrahieren:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Holt sich die Hauptsequenz der Folie.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extrahiert den Effekt-Sound in ein Byte-Array
        audio = effect.sound.binary_data
```

## **Nach Animation**

Aspose.Slides für .NET ermöglicht es Ihnen, die Nachanimations-Eigenschaft eines Animationseffekts zu ändern.

Das ist das Animations-Effekt-Paneel und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Die Effekt **Nach Animation** Dropdown-Liste entspricht diesen Eigenschaften: 

- `after_animation_type` Eigenschaft, die den Nachanimations-Typ beschreibt :
  * PowerPoint **Weitere Farben** entspricht dem [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) Typ;
  * PowerPoint **Nicht dimmen** Listenpunkt entspricht dem [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) Typ (Standard-Nachanimationstyp);
  * PowerPoint **Nach Animation ausblenden** Element entspricht dem [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) Typ;
  * PowerPoint **Bei der nächsten Mausklick ausblenden** Element entspricht dem [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) Typ;
- `after_animation_color` Eigenschaft, die ein Nachanimationsfarbformat definiert. Diese Eigenschaft funktioniert in Verbindung mit dem  [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) Typ. Wenn Sie den Typ auf einen anderen ändern, wird die Nachanimationsfarbe gelöscht.

Dieser Python-Code zeigt Ihnen, wie Sie einen Nachanimations-Effekt ändern:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Holt sich den ersten Effekt der Hauptsequenz
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändert den Nachanimations-Typ auf Farbe
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Setzt die Nachanimations-Dimfarbe
    first_effect.after_animation_color.color = Color.alice_blue

    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Text animieren**

Aspose.Slides bietet diese Eigenschaften, die es Ihnen ermöglichen, mit dem *Text animieren* Block eines Animationseffekts zu arbeiten:

- `animate_text_type`, die einen Animationstexttyp des Effekts beschreibt. Der Text der Form kann animiert werden:
  - Alles auf einmal ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) Typ)
  - Nach Wort ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) Typ)
  - Nach Buchstabe ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) Typ)
- `delay_between_text_parts` setzt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben). Ein positiver Wert gibt den Prozentsatz der Effekt-Dauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So ändern Sie die Eigenschaften des Effekt-Animierte Textes:

1. [Wenden Sie an](#apply-animation-to-shape) oder holen Sie sich den Animationseffekt.
2. Setzen Sie die `build_type`-Eigenschaft auf den [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) Wert, um den Animationsmodus *Nach Absätzen* auszuschalten.
3. Setzen Sie neue Werte für die `animate_text_type` und `delay_between_text_parts` Eigenschaften.
4. Speichern Sie die modifizierte PPTX-Datei.

Dieser Python-Code demonstriert die Operation:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Holt sich den ersten Effekt der Hauptsequenz
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändert den Effekt-Textanimationstyp auf "Als ein Objekt"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Ändert den Effekt-Animierte Texttyp auf "Nach Wort"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Setzt die Verzögerung zwischen den Wörtern auf 20% der Effekt-Dauer
    first_effect.delay_between_text_parts = 20

    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```