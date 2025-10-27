---
title: Apply Shape Animations in Presentations with Python
linktitle: Shape Animation
type: docs
weight: 60
url: /de/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-animation/
keywords:
- shape
- animation
- effect
- animated shape
- animated text
- add animation
- get animation
- extract animation
- add effect
- get effect
- extract effect
- effect sound
- apply animation
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Discover how to create and customize shape animations in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET. Stand out!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [charts](/slides/de/python-net/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben.

## **Warum Animationen in Präsentationen verwenden?**

Mit Animationen können Sie

* den Informationsfluss steuern
* wichtige Punkte hervorheben
* das Interesse oder die Beteiligung Ihres Publikums steigern
* Inhalte leichter lesbar, verdaulich oder verarbeitbar machen
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken

PowerPoint bietet viele Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfad**.

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) zu arbeiten,
* Aspose.Slides bietet über **150 Animationseffekte** im Aufzählungstyp [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Diese Effekte entsprechen im Wesentlichen denselben (oder äquivalenten) Effekten, die in PowerPoint verwendet werden.

## **Animation auf TextBox anwenden**

Aspose.Slides for Python via .NET ermöglicht es Ihnen, eine Animation auf den Text in einer Form anzuwenden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
4. Fügen Sie Text zu `IAutoShape.TextFrame` hinzu.
5. Holen Sie die Hauptsequenz der Effekte.
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
7. Setzen Sie die Eigenschaft `TextAnimation.BuildType` auf den Wert aus der `BuildType`‑Aufzählung.
8. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.

Der folgende Python‑Code zeigt, wie Sie den Effekt `Fade` auf ein AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* setzen:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Fügt ein neues AutoShape mit Text hinzu
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Holt die Hauptsequenz der Folie.
    sequence = sld.timeline.main_sequence

    # Fügt dem Shape den Fade‑Animationseffekt hinzu
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animiert den Shape‑Text nach Absätzen der 1. Ebene
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Speichert die PPTX‑Datei auf die Festplatte
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf ein einzelnes [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) anwenden. Siehe [**Animated Text**](/slides/de/python-net/animated-text/).

{{% /alert %}} 

## **Animation auf PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) zur Folie hinzu oder holen Sie es.
4. Holen Sie die Hauptsequenz der Effekte.
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) hinzu.
6. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.

Der folgende Python‑Code demonstriert, wie Sie den Effekt `Fly` auf ein Bild‑Frame anwenden:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as pres:
    # Bild laden, das zur Bildsammlung der Präsentation hinzugefügt werden soll
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Fügt der Folie ein Bild‑Frame hinzu
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Holt die Hauptsequenz der Folie.
    sequence = pres.slides[0].timeline.main_sequence

    # Fügt dem Bild‑Frame den Fly‑from‑Left‑Animationseffekt hinzu
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Speichert die PPTX‑Datei auf die Festplatte
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animation auf Shape anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.
4. Fügen Sie ein `Bevel`‑[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).
5. Erstellen Sie eine Sequenz von Effekten für die Bevel‑Form.
6. Erzeugen Sie einen benutzerdefinierten `UserPath`.
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.
8. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.

Der folgende Python‑Code zeigt, wie Sie den Effekt `PathFootball` (Pfad‑Fußball) auf eine Form anwenden:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiert eine Prseetation‑Klasse, die eine PPTX‑Datei darstellt
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Erstellt den PathFootball‑Effekt für eine vorhandene Form von Grund auf.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Fügt den PathFootBall‑Animationseffekt hinzu.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Erstellt eine Art „Button“.
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Erstellt eine Sequenz von Effekten für den Button.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Erstellt einen benutzerdefinierten User‑Path. Unser Objekt wird erst nach dem Klick auf den Button bewegt.
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

    # Schreibt die PPTX‑Datei auf die Festplatte
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Die auf eine Shape angewendeten Animationseffekte abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `get_effects_by_shape` der Klasse [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) verwenden, um alle auf eine Shape angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte einer Shape auf einer normalen Folie abrufen**

Zuvor haben Sie gelernt, wie Sie Animationseffekte zu Shapes in PowerPoint‑Präsentationen hinzufügen. Der folgende Beispielcode zeigt, wie Sie die auf die erste Shape der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendeten Effekte abrufen.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Holt die Hauptanimationssequenz der Folie.
    sequence = first_slide.timeline.main_sequence

    # Holt die erste Shape der ersten Folie.
    shape = first_slide.shapes[0]

    # Holt die auf die Shape angewendeten Animationseffekte.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("Die Shape", shape.name, "hat", len(shape_effects), "Animationseffekte.")
```

**Beispiel 2: Alle Animationseffekte, einschließlich der von Platzhaltern geerbten, abrufen**

Verfügt eine Shape auf einer normalen Folie über Platzhalter, die sich auf der Layout‑Folie und/oder Master‑Folie befinden, und wurden diesen Platzhaltern Animationseffekte zugewiesen, dann werden alle Effekte der Shape während der Bildschirmpräsentation abgespielt – einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Datei `sample.pptx` mit einer Folie, die ausschließlich eine Fußzeilen‑Shape mit dem Text **„Made with Aspose.Slides“** enthält und der Effekt **Random Bars** auf die Shape angewendet wurde.

![Slide shape animation effect](slide-shape-animation.png)

Angenommen, auf dem **Layout**‑Slide wurde auf den Fußzeilen‑Platzhalter der Effekt **Split** angewendet.

![Layout shape animation effect](layout-shape-animation.png)

Und schließlich wurde auf dem **Master**‑Slide auf den Fußzeilen‑Platzhalter der Effekt **Fly In** angewendet.

![Master shape animation effect](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie Sie die Methode `get_base_placeholder` der Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) nutzen, um die Platzhalter‑Shapes zu erreichen und die auf die Fußzeilen‑Shape angewendeten Animationseffekte, einschließlich der geerbten von Layout‑ und Master‑Platzhaltern, abzurufen.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Animationseffekte der Shape auf der normalen Folie holen.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Animationseffekte des Platzhalters auf dem Layout‑Slide holen.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Animationseffekte des Platzhalters auf dem Master‑Slide holen.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Hauptsequenz der Shape‑Effekte:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Ausgabe:
```text
Hauptsequenz der Shape‑Effekte:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Timing‑Eigenschaften von Animationseffekten ändern**

Aspose.Slides for Python via .NET ermöglicht das Ändern der Timing‑Eigenschaften eines Animationseffekts.

Dies ist das **Animation Timing**‑Fenster in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Die Zuordnungen zwischen PowerPoint‑Timing und den Eigenschaften `Effect.Timing` lauten:

- Das Dropdown‑Feld **Start** in PowerPoint entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/).
- **Duration** entspricht der Eigenschaft `Effect.Timing.Duration`. Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Zyklus benötigt.
- **Delay** entspricht der Eigenschaft `Effect.Timing.TriggerDelayTime`.

So ändern Sie die Timing‑Eigenschaften eines Effekts:

1. [Wenden](#apply-animation-to-shape) Sie den Animationseffekt an oder holen Sie ihn.
2. Setzen Sie neue Werte für die gewünschten `Effect.Timing`‑Eigenschaften.
3. Speichern Sie die modifizierte PPTX‑Datei.

Der folgende Python‑Code demonstriert die Vorgehensweise:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Holt die Hauptsequenz der Folie.
    sequence = pres.slides[0].timeline.main_sequence

    # Holt den ersten Effekt der Hauptsequenz.
    effect = sequence[0]

    # Ändert den TriggerType, sodass die Animation beim Klicken startet
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Ändert die Dauer des Effekts
    effect.timing.duration = 3

    # Ändert die Verzögerung des Triggers
    effect.timing.trigger_delay_time = 0.5

    # Speichert die PPTX‑Datei auf die Festplatte
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sound für Animationseffekte**

Aspose.Slides stellt folgende Eigenschaften bereit, um mit Sounds in Animationseffekten zu arbeiten:

- `sound`
- `stop_previous_sound`

### **Sound zu einem Animationseffekt hinzufügen**

Der folgende Python‑Code zeigt, wie Sie einem Animationseffekt einen Sound hinzufügen und diesen stoppen, sobald der nächste Effekt beginnt:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Fügt der Präsentations‑Audio‑Sammlung Audio hinzu
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Holt die Hauptsequenz der Folie.
    sequence = first_slide.timeline.main_sequence

    # Holt den ersten Effekt der Hauptsequenz
    first_effect = sequence[0]

    # Prüft den Effekt auf „Kein Sound“
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Fügt dem ersten Effekt einen Sound hinzu
        first_effect.sound = effect_sound

    # Holt die erste interaktive Sequenz der Folie.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Setzt das Flag „Stop previous sound“
    interactive_sequence[0].stop_previous_sound = True

    # Speichert die PPTX‑Datei auf die Festplatte
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Sound aus einem Animationseffekt extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Holen Sie die Hauptsequenz der Effekte.
4. Extrahieren Sie das eingebettete `sound` aus jedem Animationseffekt.

Der folgende Python‑Code zeigt, wie Sie den in einem Animationseffekt eingebetteten Sound extrahieren:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Holt die Hauptsequenz der Folie.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extrahiert den Effekt‑Sound als Byte‑Array
        audio = effect.sound.binary_data
```

## **After‑Animation**

Aspose.Slides for .NET ermöglicht das Ändern der **After‑Animation**‑Eigenschaft eines Animationseffekts.

Dies ist das **Animation Effect**‑Fenster und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Das Dropdown‑Feld **After animation** in PowerPoint entspricht diesen Eigenschaften:

- Der Eigenschaft `after_animation_type`, die den Typ der Nachanimation beschreibt:
  * **More Colors** entspricht dem Typ [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
  * **Don't Dim** entspricht dem Typ [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (Standard‑Nachanimationstyp);
  * **Hide After Animation** entspricht dem Typ [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
  * **Hide on Next Mouse Click** entspricht dem Typ [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
- Der Eigenschaft `after_animation_color`, die das Farbformat der Nachanimation definiert. Diese Eigenschaft funktioniert zusammen mit dem Typ [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/). Wird der Typ auf einen anderen geändert, wird die Nachanimationsfarbe zurückgesetzt.

Der folgende Python‑Code zeigt, wie Sie den Nachanimationseffekt ändern:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Holt den ersten Effekt der Hauptsequenz
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändert den Nachanimationstyp zu Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Setzt die Nachanimations‑Dim‑Farbe
    first_effect.after_animation_color.color = Color.alice_blue

    # Speichert die PPTX‑Datei auf die Festplatte
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Text animieren**

Aspose.Slides stellt folgende Eigenschaften bereit, um den *Animate text*‑Block eines Animationseffekts zu bearbeiten:

- `animate_text_type`, das den Animations‑Text‑Typ des Effekts beschreibt. Der Shape‑Text kann animiert werden:
  - Alles auf einmal ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)‑Typ)
  - Wortweise ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)‑Typ)
  - Buchstabenweise ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)‑Typ)
- `delay_between_text_parts` legt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt‑Dauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So ändern Sie die **Animate‑text**‑Eigenschaften eines Effekts:

1. [Wenden](#apply-animation-to-shape) Sie den Animationseffekt an oder holen Sie ihn.
2. Setzen Sie die Eigenschaft `build_type` auf den Wert [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/), um den Modus *By Paragraphs* zu deaktivieren.
3. Setzen Sie neue Werte für die Eigenschaften `animate_text_type` und `delay_between_text_parts`.
4. Speichern Sie die modifizierte PPTX‑Datei.

Der folgende Python‑Code demonstriert dies:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Holt den ersten Effekt der Hauptsequenz
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändert den Text‑Animationstyp zu „As One Object“
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Ändert den Animate‑text‑Typ zu „By word“
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Setzt die Verzögerung zwischen den Wörtern auf 20 % der Effekt‑Dauer
    first_effect.delay_between_text_parts = 20

    # Speichert die PPTX‑Datei auf die Festplatte
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?**

[Export nach HTML5](/slides/de/python-net/export-to-html5/) und aktivieren Sie die [Optionen](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/), die für die Animation von [Shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) und [Transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) verantwortlich sind. Reines HTML spielt keine Folien‑Animationen ab, HTML5 jedoch.

**Wie wirkt sich die Reihenfolge (Z‑Order) von Shapes auf Animationen aus?**

Animation‑ und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinens/Ver‑schwindens, während der [z‑order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) bestimmt, was was überdeckt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das generelle Verhalten von PowerPoint; das Aspose.Slides‑Modell für Effekte und Shapes folgt derselben Logik.)

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**

Im Allgemeinen werden [Animationen unterstützt](/slides/de/python-net/convert-powerpoint-to-video/), jedoch können seltene Fälle oder spezielle Effekte anders gerendert werden. Es wird empfohlen, die von Ihnen genutzten Effekte und die verwendete Bibliotheksversion zu testen.