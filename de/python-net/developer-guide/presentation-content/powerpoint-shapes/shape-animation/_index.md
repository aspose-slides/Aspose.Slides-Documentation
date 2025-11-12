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
- Effektton
- Animation anwenden
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie, wie Sie Shape-Animationen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET erstellen und anpassen. Heben Sie sich ab!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/de/python-net/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben.

## **Warum Animationen in Präsentationen verwenden?**

* den Fluss der Informationen steuern  
* wichtige Punkte hervorheben  
* das Interesse oder die Teilnahme Ihres Publikums erhöhen  
* Inhalte leichter lesbar, verdaulich oder verarbeitbar machen  
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken  

PowerPoint bietet viele Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfad**.

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) zu arbeiten,  
* Aspose.Slides bietet über **150 Animationseffekte** im Aufzählungstyp [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) an. Diese Effekte entsprechen im Wesentlichen den in PowerPoint verwendeten Effekten (oder sind äquivalent).

## **Animation auf TextBox anwenden**

Aspose.Slides für Python via .NET ermöglicht es Ihnen, eine Animation auf den Text in einer Form anzuwenden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Fügen Sie ein `rectangle`‑[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.  
4. Fügen Sie Text zu `IAutoShape.TextFrame` hinzu.  
5. Rufen Sie die Hauptsequenz der Effekte ab.  
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.  
7. Setzen Sie die Eigenschaft `TextAnimation.BuildType` auf den Wert aus der `BuildType`‑Aufzählung.  
8. Speichern Sie die Präsentation als PPTX-Datei auf der Festplatte.

Dieser Python-Code zeigt, wie Sie den `Fade`‑Effekt auf ein AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* einstellen:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Fügt ein neues AutoShape mit Text hinzu
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Ruft die Hauptsequenz der Folie ab.
    sequence = sld.timeline.main_sequence

    # Fügt der Form den Fade-Animationseffekt hinzu
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animiert den Formtext nach Absätzen der ersten Ebene
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](/slides/de/python-net/animated-charts/) anwenden. Siehe [**Animierter Text**](/slides/de/python-net/animated-text/).

{{% /alert %}} 

## **Animation auf PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Fügen Sie einen [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) hinzu oder rufen Sie ihn ab.  
4. Rufen Sie die Hauptsequenz der Effekte ab.  
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) hinzu.  
6. Speichern Sie die Präsentation als PPTX-Datei auf der Festplatte.

Dieser Python-Code zeigt, wie Sie den `Fly`‑Effekt auf einen Bildrahmen anwenden:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation() as pres:
    # Lädt ein Bild, das zur Bildersammlung der Präsentation hinzugefügt werden soll
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Fügt einen Bildrahmen zur Folie hinzu
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Ruft die Hauptsequenz der Folie ab.
    sequence = pres.slides[0].timeline.main_sequence

    # Fügt dem Bildrahmen den Fly-from-Left-Animationseffekt hinzu
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animation auf Shape anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Fügen Sie ein `rectangle`‑[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.  
4. Fügen Sie ein `Bevel`‑[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).  
5. Erstellen Sie eine Sequenz von Effekten auf der Bevel-Form.  
6. Erstellen Sie einen benutzerdefinierten `UserPath`.  
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.  
8. Speichern Sie die Präsentation als PPTX-Datei auf der Festplatte.

Dieser Python-Code zeigt, wie Sie den `PathFootball`‑Effekt (Pfad‑Football) auf eine Form anwenden:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Erstellt den PathFootball-Effekt für die vorhandene Form von Grund auf.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Fügt den PathFootBall-Animationseffekt hinzu.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Erstellt eine Art „Button“.
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Erstellt eine Sequenz von Effekten für den Button.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird erst bewegt, nachdem der Button geklickt wurde.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Fügt Befehle zum Bewegen hinzu, da der erstellte Pfad leer ist.
    motionBvh = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBvh.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBvh.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBvh.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Schreibt die PPTX-Datei auf das Laufwerk
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animationseffekte einer Form abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `get_effects_by_shape` der [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) Klasse verwenden, um alle auf eine Form angewendeten Animationseffekte zu erhalten.

**Beispiel 1: Animationseffekte einer Form auf einer normalen Folie abrufen**

Zuvor haben Sie erfahren, wie Sie Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzufügen. Der folgende Beispielcode zeigt, wie Sie die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendeten Effekte abrufen.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Ruft die Hauptsequenz der Folie ab.
    sequence = first_slide.timeline.main_sequence

    # Ruft die erste Form der ersten Folie ab.
    shape = first_slide.shapes[0]

    # Ruft die auf die Form angewendeten Animationseffekte ab.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Beispiel 2: Alle Animationseffekte, einschließlich der von Platzhaltern geerbten, abrufen**

Wenn eine Form auf einer normalen Folie Platzhalter hat, die sich auf der Layout‑ oder Master‑Folien befinden, und diesen Platzhaltern Animationseffekte zugewiesen wurden, dann werden beim Vorführen alle Effekte der Form abgespielt, einschließlich der von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Datei `sample.pptx` mit einer Folie, die nur eine Fußzeilen‑Form mit dem Text **„Made with Aspose.Slides“** enthält und der **Random Bars**‑Effekt ist auf die Form angewendet.

![Slide shape animation effect](slide-shape-animation.png)

Nehmen wir weiter an, dass der **Split**‑Effekt auf den Fußzeilen‑Platzhalter der **Layout**‑Folien angewendet wurde.

![Layout shape animation effect](layout-shape-animation.png)

Und schließlich ist der **Fly In**‑Effekt auf den Fußzeilen‑Platzhalter der **Master**‑Folien angewendet.

![Master shape animation effect](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie Sie die Methode `get_base_placeholder` der [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) Klasse verwenden, um auf die Platzhalter der Form zuzugreifen und die auf die Fußzeilen‑Form angewendeten Animationseffekte zu erhalten, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten Effekte.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get animation effects of the shape on the normal slide.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Get animation effects of the placeholder on the layout slide.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Get animation effects of the placeholder on the master slide.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Ausgabe:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Timing‑Eigenschaften eines Animationseffekts ändern**

Aspose.Slides für Python via .NET ermöglicht das Ändern der Timing‑Eigenschaften eines Animationseffekts.

Dies ist das Animations‑Timing‑Fenster in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dies sind die Entsprechungen zwischen PowerPoint‑Timing und den `Effect.Timing`‑Eigenschaften:

- Die Dropdown‑Liste **Start** im PowerPoint‑Timing entspricht der Eigenschaft [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/).  
- PowerPoint‑Timing **Dauer** entspricht der Eigenschaft `Effect.Timing.Duration`. Die Dauer einer Animation (in Sekunden) ist die Gesamtzeit, die die Animation für einen Durchlauf benötigt.  
- PowerPoint‑Timing **Verzögerung** entspricht der Eigenschaft `Effect.Timing.TriggerDelayTime`.  

So ändern Sie die Timing‑Eigenschaften eines Effekts:

1. [Animation auf Form anwenden](#apply-animation-to-shape) oder den Animationseffekt abrufen.  
2. Setzen Sie neue Werte für die benötigten `Effect.Timing`‑Eigenschaften.  
3. Speichern Sie die geänderte PPTX‑Datei.

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Ruft die Hauptsequenz der Folie ab.
    sequence = pres.slides[0].timeline.main_sequence

    # Ruft den ersten Effekt der Hauptsequenz ab.
    effect = sequence[0]

    # Ändert den TriggerType des Effekts, sodass er beim Klicken startet
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Ändert die Dauer des Effekts
    effect.timing.duration = 3

    # Ändert die TriggerDelayTime des Effekts
    effect.timing.trigger_delay_time = 0.5

    # Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sound eines Animationseffekts**

Aspose.Slides stellt diese Eigenschaften zur Verfügung, um mit Geräuschen in Animationseffekten zu arbeiten:

- `sound`
- `stop_previous_sound`

### **Animationseffekt‑Sound hinzufügen**

Dieser Python-Code zeigt, wie Sie einem Animationseffekt einen Sound hinzufügen und ihn stoppen, wenn der nächste Effekt startet:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Fügt Audio zur Audiosammlung der Präsentation hinzu
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Ruft die Hauptsequenz der Folie ab.
    sequence = first_slide.timeline.main_sequence

    # Ruft den ersten Effekt der Hauptsequenz ab.
    first_effect = sequence[0]

    # Prüft, ob der Effekt "Kein Ton" hat
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Fügt den ersten Effekt ein Geräusch hinzu
        first_effect.sound = effect_sound

    # Ruft die erste interaktive Sequenz der Folie ab.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Setzt das Flag "Vorherigen Ton stoppen" für den Effekt
    interactive_sequence[0].stop_previous_sound = True

    # Schreibt die PPTX-Datei auf das Laufwerk
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Animationseffekt‑Sound extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Rufen Sie die Hauptsequenz der Effekte ab.  
4. Extrahieren Sie das in jedem Animationseffekt eingebettete `sound`.

Dieser Python-Code zeigt, wie Sie den in einem Animationseffekt eingebetteten Sound extrahieren:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Ruft die Hauptsequenz der Folie ab.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extrahiert den Effektton als Byte-Array
        audio = effect.sound.binary_data
```

## **After‑Animation**

Aspose.Slides für .NET ermöglicht das Ändern der After‑Animation‑Eigenschaft eines Animationseffekts.

Dies ist das Fenster „Animationseffekt“ und das erweiterte Menü in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Die Dropdown‑Liste **After animation** im PowerPoint‑Effekt entspricht diesen Eigenschaften:

- `after_animation_type`‑Eigenschaft, die den Typ der After‑Animation beschreibt:
  * PowerPoint **Mehr Farben** entspricht dem [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)‑Typ;
  * PowerPoint **Nicht dimmen** entspricht dem [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)‑Typ (Standard‑After‑Animation‑Typ);
  * PowerPoint **Nach Animation ausblenden** entspricht dem [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)‑Typ;
  * PowerPoint **Beim nächsten Mausklick ausblenden** entspricht dem [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)‑Typ;
- `after_animation_color`‑Eigenschaft, die ein After‑Animation‑Farbformat definiert. Diese Eigenschaft arbeitet zusammen mit dem [COLOR]‑Typ. Wenn Sie den Typ ändern, wird die After‑Animation‑Farbe gelöscht.

Dieser Python-Code zeigt, wie Sie einen After‑Animation‑Effekt ändern:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Ruft den ersten Effekt der Hauptsequenz ab
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändert den After‑Animation‑Typ zu Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Setzt die After‑Animation‑Dim‑Farbe
    first_effect.after_animation_color.color = Color.alice_blue

    # Schreibt die PPTX-Datei auf das Laufwerk
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Text animieren**

Aspose.Slides stellt diese Eigenschaften zur Verfügung, um mit dem *Animate‑text*‑Block eines Animationseffekts zu arbeiten:

- `animate_text_type`, die den Typ des animierten Textes des Effekts beschreibt. Der Formtext kann animiert werden:
  - Alle gleichzeitig ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)‑Typ)
  - Nach Wort ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)‑Typ)
  - Nach Buchstabe ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)‑Typ)
- `delay_between_text_parts` legt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effektdauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.

So können Sie die Eigenschaften *Effect Animate text* ändern:

1. [Animation auf Form anwenden](#apply-animation-to-shape) oder den Animationseffekt abrufen.  
2. Setzen Sie die Eigenschaft `build_type` auf den Wert [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/), um den *By Paragraphs*‑Modus zu deaktivieren.  
3. Setzen Sie neue Werte für `animate_text_type` und `delay_between_text_parts`.  
4. Speichern Sie die geänderte PPTX‑Datei.

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Ruft den ersten Effekt der Hauptsequenz ab.
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändert den Textanimationstyp des Effekts zu "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Ändert den Animate‑Text‑Typ des Effekts zu "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Setzt die Verzögerung zwischen den Wörtern auf 20 % der Effektdauer
    first_effect.delay_between_text_parts = 20

    # Schreibt die PPTX-Datei auf das Laufwerk
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?**

[Export to HTML5](/slides/de/python-net/export-to-html5/) und aktivieren Sie die [Optionen](/slides/de/python-net/aspose.slides.export/html5options/), die für [shape](/slides/de/python-net/aspose.slides.export/html5options/animate_shapes/) und [transition](/slides/de/python-net/aspose.slides.export/html5options/animate_transitions/)‑Animationen verantwortlich sind. Reines HTML spielt Folienanimationen nicht ab, HTML5 jedoch.

**Wie wirkt sich das Ändern der Z‑Reihenfolge (Ebene) von Formen auf die Animation aus?**

Animation und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinens/Verschwindens, während die [z‑order](/slides/de/python-net/aspose.slides/shape/z_order_position/) bestimmt, was was überdeckt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das generelle Verhalten von PowerPoint; das Modell von Aspose.Slides für Effekte und Formen folgt derselben Logik.)

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**

Im Allgemeinen werden [Animationen unterstützt](/slides/de/python-net/convert-powerpoint-to-video/), doch seltene Fälle oder bestimmte Effekte können anders gerendert werden. Es wird empfohlen, die von Ihnen genutzten Effekte und die Bibliotheksversion zu testen.