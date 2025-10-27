---
title: Formanimationen in Präsentationen mit Python anwenden
linktitle: Formanimation
type: docs
weight: 60
url: /de/python-net/shape-animation/
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
description: "Entdecken Sie, wie Sie Formanimationen in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python via .NET erstellen und anpassen. Machen Sie den Unterschied!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/de/python-net/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben.

## **Warum Animationen in Präsentationen verwenden?**

Mit Animationen können Sie  

* den Informationsfluss steuern  
* wichtige Punkte hervorheben  
* das Interesse oder die Beteiligung Ihres Publikums steigern  
* Inhalte leichter les‑ und verdaulich machen  
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken  

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfad**.

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie zum Arbeiten mit Animationen im Namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) benötigen,  
* Aspose.Slides bietet über **150 Animationseffekte** in der Aufzählung [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Diese Effekte entsprechen im Wesentlichen den in PowerPoint verwendeten (oder äquivalenten) Effekten.

## **Animation auf TextBox anwenden**

Aspose.Slides für Python via .NET ermöglicht es Ihnen, Animationen auf den Text in einer Form anzuwenden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Folien‑Referenz über deren Index.  
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.  
4. Fügen Sie Text zu `IAutoShape.TextFrame` hinzu.  
5. Holen Sie die Hauptsequenz der Effekte.  
6. Fügen Sie der [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) einen Animationseffekt hinzu.  
7. Setzen Sie die Eigenschaft `TextAnimation.BuildType` auf den gewünschten Wert der Aufzählung `BuildType`.  
8. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.

Dieser Python‑Code zeigt, wie Sie den `Fade`‑Effekt auf ein AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* setzen:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Fügt ein neues AutoShape mit Text hinzu
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Holt die Hauptsequenz der Folie.
    sequence = sld.timeline.main_sequence

    # Fügt den Fade‑Animationseffekt zur Form hinzu
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animiert den Formtext nach 1. Ebene‑Absätzen
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Speichert die PPTX‑Datei auf der Festplatte
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf ein einzelnes [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.iparagraph/) anwenden. Siehe [**Animierter Text**](/slides/de/python-net/animated-text/).

{{% /alert %}} 

## **Animation auf PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Folien‑Referenz über deren Index.  
3. Fügen Sie auf der Folie ein [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides.pictureframe/) hinzu oder holen Sie ein bestehendes.  
4. Holen Sie die Hauptsequenz der Effekte.  
5. Fügen Sie dem [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides.pictureframe/) einen Animationseffekt hinzu.  
6. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.

Dieser Python‑Code demonstriert, wie Sie den `Fly`‑Effekt auf ein Bildrahmen‑Objekt anwenden:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation() as pres:
    # Bild laden, das zur Präsentations‑Bildsammlung hinzugefügt werden soll
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Bildrahmen zur Folie hinzufügen
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Holt die Hauptsequenz der Folie.
    sequence = pres.slides[0].timeline.main_sequence

    # Fügt den Fly‑From‑Left‑Animationseffekt zum Bildrahmen hinzu
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Speichert die PPTX‑Datei auf der Festplatte
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animation auf Shape anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Folien‑Referenz über deren Index.  
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.  
4. Fügen Sie ein `Bevel`‑[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).  
5. Erstellen Sie eine Sequenz von Effekten für die Bevel‑Form.  
6. Erstellen Sie einen benutzerdefinierten `UserPath`.  
7. Fügen Sie Befehle zum Bewegen des `UserPath` hinzu.  
8. Schreiben Sie die Präsentation als PPTX‑Datei auf die Festplatte.

Dieser Python‑Code zeigt, wie Sie den `PathFootball`‑Effekt (Pfad‑Fußball) auf eine Form anwenden:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiert eine Presentation‑Klasse, die eine PPTX‑Datei repräsentiert
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

    # Erstellt ein gewisses „Button“-Objekt.
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

## **Die für eine Form angewendeten Animationseffekte abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `get_effects_by_shape` der [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/)‑Klasse verwenden, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte einer Form auf einer normalen Folie abrufen**

Zuvor haben Sie gelernt, wie Sie Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügen. Der folgende Beispielcode zeigt, wie Sie die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendeten Effekte abrufen.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Holt die Hauptanimationssequenz der Folie.
    sequence = first_slide.timeline.main_sequence

    # Holt die erste Form der ersten Folie.
    shape = first_slide.shapes[0]

    # Holt die auf die Form angewendeten Animationseffekte.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("Die Form", shape.name, "hat", len(shape_effects), "Animationseffekte.")
```

**Beispiel 2: Alle Animationseffekte, einschließlich der von Platzhaltern geerbten, abrufen**

Wenn eine Form auf einer normalen Folie Platzhalter hat, die sich auf der Layout‑ oder Master‑Folien befinden, und diesen Platzhaltern Animationseffekte zugewiesen wurden, werden sämtliche Effekte der Form während der Bildschirmanzeige abgespielt – einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Datei `sample.pptx` mit einer Folie, die ausschließlich eine Fußzeilen‑Form mit dem Text „Made with Aspose.Slides“ enthält und der Effekt **Random Bars** auf die Form angewendet wurde.

![Slide shape animation effect](slide-shape-animation.png)

Nehmen wir weiter an, dass auf dem **Layout**‑Slide der Effekt **Split** auf den Fußzeilen‑Platzhalter angewendet wurde.

![Layout shape animation effect](layout-shape-animation.png)

Und schließlich wurde auf dem **Master**‑Slide der Effekt **Fly In** auf den Fußzeilen‑Platzhalter angewendet.

![Master shape animation effect](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie Sie die Methode `get_base_placeholder` der [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)‑Klasse verwenden, um die Platzhalter zu erreichen und die auf die Fußzeilen‑Form angewendeten Animationseffekte, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten, abzurufen.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Animationseffekte der Form auf der normalen Folie holen.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Animationseffekte des Platzhalters auf der Layout‑Folien holen.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Animationseffekte des Platzhalters auf der Master‑Folien holen.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Hauptsequenz der Formeffekte:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Ausgabe:
```text
Hauptsequenz der Formeffekte:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Timing‑Eigenschaften von Animationseffekten ändern**

Aspose.Slides für Python via .NET ermöglicht das Ändern der Timing‑Eigenschaften eines Animationseffekts.

Dies ist das „Animation Timing“-Paneel in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Die Entsprechungen zwischen PowerPoint‑Timing und den Eigenschaften `Effect.Timing` sind:

- Das Dropdown‑Feld **Start** in PowerPoint entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/).  
- **Duration** entspricht der Eigenschaft `Effect.Timing.Duration`. Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Durchlauf benötigt.  
- **Delay** entspricht der Eigenschaft `Effect.Timing.TriggerDelayTime`.  

So ändern Sie die Timing‑Eigenschaften eines Effekts:

1. [Wenden](#apply-animation-to-shape) Sie den Animationseffekt an oder holen Sie ihn.  
2. Setzen Sie neue Werte für die gewünschten `Effect.Timing`‑Eigenschaften.  
3. Speichern Sie die geänderte PPTX‑Datei.

Dieser Python‑Code demonstriert den Vorgang:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Holt die Hauptsequenz der Folie.
    sequence = pres.slides[0].timeline.main_sequence

    # Holt den ersten Effekt der Hauptsequenz.
    effect = sequence[0]

    # Ändert TriggerType zu „Bei Klick starten“
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Ändert die Dauer des Effekts
    effect.timing.duration = 3

    # Ändert die Verzögerungszeit des Triggers
    effect.timing.trigger_delay_time = 0.5

    # Speichert die PPTX‑Datei auf der Festplatte
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sound für Animationseffekte**

Aspose.Slides stellt folgende Eigenschaften bereit, um mit Sounds in Animationseffekten zu arbeiten:  

- `sound`  
- `stop_previous_sound`

### **Sound zu einem Animationseffekt hinzufügen**

Dieser Python‑Code zeigt, wie Sie einem Animationseffekt einen Sound hinzufügen und diesen stoppen, wenn der nächste Effekt beginnt:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Fügt dem Präsentations‑Audio‑Katalog Audio hinzu
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Holt die Hauptsequenz der Folie.
    sequence = first_slide.timeline.main_sequence

    # Holt den ersten Effekt der Hauptsequenz
    first_effect = sequence[0]

    # Prüft, ob der Effekt „Kein Sound“ hat
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Fügt dem ersten Effekt einen Sound hinzu
        first_effect.sound = effect_sound

    # Holt die erste interaktive Sequenz der Folie.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Setzt das Flag „Stop previous sound“ für den Effekt
    interactive_sequence[0].stop_previous_sound = True

    # Speichert die PPTX‑Datei auf der Festplatte
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Sound aus einem Animationseffekt extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Folien‑Referenz über deren Index.  
3. Holen Sie die Hauptsequenz der Effekte.  
4. Extrahieren Sie den in jedem Animationseffekt eingebetteten `sound`.  

Dieser Python‑Code zeigt, wie Sie den in einem Animationseffekt eingebetteten Sound extrahieren:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Holt die Hauptsequenz der Folie.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extrahiert den Sound des Effekts als Byte‑Array
        audio = effect.sound.binary_data
```

## **After‑Animation**

Aspose.Slides für .NET erlaubt das Ändern der „After‑Animation“-Eigenschaft eines Animationseffekts.

Dies ist das „Animation Effect“-Paneel und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Das Dropdown‑Feld **After animation** in PowerPoint entspricht folgenden Eigenschaften:

- `after_animation_type` – beschreibt den After‑Animation‑Typ:  
  * **More Colors** → der Typ [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)  
  * **Don't Dim** → der Typ [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (Standard)  
  * **Hide After Animation** → der Typ [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)  
  * **Hide on Next Mouse Click** → der Typ [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)  
- `after_animation_color` – definiert das Farbformat für die After‑Animation. Diese Eigenschaft wird nur zusammen mit dem Typ **COLOR** verwendet. Wird ein anderer Typ gewählt, wird die Farbe zurückgesetzt.

Der folgende Python‑Code zeigt, wie Sie einen After‑Animation‑Effekt ändern:

```python
import aspose.slides as slides

# Instanziert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Holt den ersten Effekt der Hauptsequenz
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändert den After‑Animation‑Typ zu „Color“
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Setzt die Dim‑Farbe für die After‑Animation
    first_effect.after_animation_color.color = Color.alice_blue

    # Schreibt die PPTX‑Datei auf die Festplatte
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Text animieren**

Aspose.Slides stellt folgende Eigenschaften bereit, um den *Animate text*‑Block eines Animationseffekts zu steuern:

- `animate_text_type` – beschreibt, wie der Text der Form animiert wird:  
  - **All at once** → [ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)  
  - **By word** → [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)  
  - **By letter** → [BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)  
- `delay_between_text_parts` – legt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt‑Dauer an, ein negativer Wert die Verzögerung in Sekunden.

So ändern Sie die Eigenschaften *Animate Text* eines Effekts:

1. [Wenden](#apply-animation-to-shape) Sie den Animationseffekt an oder holen Sie ihn.  
2. Setzen Sie die Eigenschaft `build_type` auf den Wert [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/), um den Modus *By Paragraphs* zu deaktivieren.  
3. Setzen Sie neue Werte für `animate_text_type` und `delay_between_text_parts`.  
4. Speichern Sie die geänderte PPTX‑Datei.

Der folgende Python‑Code demonstriert das Vorgehen:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Holt den ersten Effekt der Hauptsequenz
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändert den Text‑Animationstyp zu „Als ein Objekt“
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Ändert den Animate‑Text‑Typ zu „Nach Wort“
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Setzt die Verzögerung zwischen den Wörtern auf 20 % der Effekt‑Dauer
    first_effect.delay_between_text_parts = 20

    # Speichert die PPTX‑Datei auf der Festplatte
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?**

[Export nach HTML5](/slides/de/python-net/export-to-html5/) und aktivieren Sie die entsprechenden [Optionen](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/), die für [Formen](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) und [Übergänge](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) verantwortlich sind. Reines HTML spielt Folienanimationen nicht ab, HTML5 hingegen schon.

**Wie wirkt sich die Änderung der Z‑Reihenfolge (Layer‑Reihenfolge) von Formen auf Animationen aus?**

Animations‑ und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinen/Verblassen, während die [z‑order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) bestimmt, was was überlagert. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies entspricht dem allgemeinen PowerPoint‑Verhalten; das Modell von Aspose.Slides folgt derselben Logik.)

**Gibt es Beschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**

Grundsätzlich werden [Animationen unterstützt](/slides/de/python-net/convert-powerpoint-to-video/), jedoch können seltene Fälle oder spezielle Effekte anders gerendert werden. Es wird empfohlen, die von Ihnen genutzten Effekte und die verwendete Bibliotheksversion zu testen.