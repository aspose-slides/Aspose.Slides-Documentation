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
- Effektton
- Animation anwenden
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formanimationen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET erstellen und anpassen. Heben Sie sich ab!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/de/python-net/animated-charts/) angewendet werden können. Sie verleihen Präsentationen oder deren Bestandteilen Leben. 

## **Warum Animationen in Präsentationen verwenden?**

* den Fluss der Informationen steuern  
* wichtige Punkte hervorheben  
* das Interesse oder die Beteiligung des Publikums steigern  
* Inhalte leichter lesbar, erfassbar oder verarbeitbar machen  
* die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken  

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfad**. 

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) zu arbeiten,  
* Aspose.Slides bietet über **150 Animationseffekte** im [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) Aufzählungstyp. Diese Effekte entsprechen im Wesentlichen den in PowerPoint verwendeten Effekten (oder sind äquivalent).  

## **Animation auf TextBox anwenden**

Aspose.Slides für Python via .NET ermöglicht es Ihnen, Animationen auf den Text in einer Form anzuwenden. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich die Referenz einer Folie über ihren Index.  
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.  
4. Fügen Sie Text zu `IAutoShape.TextFrame` hinzu.  
5. Holen Sie die Hauptsequenz von Effekten.  
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.  
7. Setzen Sie die `TextAnimation.BuildType` Eigenschaft auf den Wert aus der `BuildType` Aufzählung.  
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Dieser Python-Code zeigt, wie Sie den `Fade`-Effekt auf AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* setzen:  
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

    # Fügt dem Shape den Fade-Animationseffekt hinzu
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animiert den Shape-Text nach Absätzen der ersten Ebene
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```


{{%  alert color="primary"  %}} 
Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.iparagraph/) anwenden. Siehe [**Animated Text**](/slides/de/python-net/animated-text/).  
{{% /alert %}} 

## **Animation auf PictureFrame anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich die Referenz einer Folie über ihren Index.  
3. Fügen Sie ein [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) hinzu oder holen Sie es von der Folie.  
4. Holen Sie die Hauptsequenz von Effekten.  
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) hinzu.  
6. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Dieser Python-Code zeigt, wie Sie den `Fly`-Effekt auf einen Bildrahmen anwenden:  
```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as pres:
    # Bild laden, das zur Bildsammlung der Präsentation hinzugefügt wird
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Fügt ein Bildrahmen zur Folie hinzu
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Holt die Hauptsequenz der Folie.
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
2. Holen Sie sich die Referenz einer Folie über ihren Index.  
3. Fügen Sie ein `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.  
4. Fügen Sie ein `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).  
5. Erstellen Sie eine Sequenz von Effekten für die Bevel-Form.  
6. Erstellen Sie einen benutzerdefinierten `UserPath`.  
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.  
8. Schreiben Sie die Präsentation als PPTX-Datei auf die Festplatte.  

Dieser Python-Code zeigt, wie Sie den `PathFootball` (Pfad-Football) Effekt auf eine Form anwenden:  
```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt.
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Erstellt den PathFootball-Effekt für eine vorhandene Form von Grund auf.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Fügt den PathFootBall-Animationseffekt hinzu.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Erstellt eine Art "button".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Erstellt eine Sequenz von Effekten für den Button.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Erstellt einen benutzerdefinierten Pfad. Unser Objekt wird erst bewegt, nachdem der Button geklickt wurde.
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


## **Animationseffekte, die einer Form zugewiesen sind, abrufen**

Die folgenden Beispiele zeigen, wie Sie die Methode `get_effects_by_shape` der [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) Klasse verwenden, um alle auf eine Form angewendeten Animationseffekte zu erhalten.  

**Beispiel 1: Animationseffekte, die auf eine Form einer normalen Folie angewendet wurden, abrufen**

Vorher haben Sie gelernt, wie man Animationseffekte zu Formen in PowerPoint-Präsentationen hinzufügt. Der folgende Beispielcode zeigt, wie Sie die Effekte erhalten, die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendet wurden.  
```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Holt die Hauptanimationssequenz der Folie.
    sequence = first_slide.timeline.main_sequence

    # Holt die erste Form auf der ersten Folie.
    shape = first_slide.shapes[0]

    # Holt die auf die Form angewendeten Animationseffekte.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```


**Beispiel 2: Alle Animationseffekte erhalten, einschließlich der von Platzhaltern geerbten**

Hat eine Form auf einer normalen Folie Platzhalter, die sich auf der Layout‑Folie und/oder der Master‑Folie befinden, und wurden diesen Platzhaltern Animationseffekte hinzugefügt, dann werden alle Effekte der Form während der Bildschirminstallation abgespielt, einschließlich der von den Platzhaltern geerbten.  

Angenommen, wir haben eine PowerPoint‑Präsentationsdatei `sample.pptx` mit einer Folie, die nur eine Fußzeilenform mit dem Text "Made with Aspose.Slides" enthält und auf die der **Random Bars**‑Effekt angewendet wurde.  

![Slide shape animation effect](slide-shape-animation.png)  

Nehmen wir außerdem an, dass der **Split**‑Effekt auf den Fußzeilen‑Platzhalter der **Layout**‑Folie angewendet wurde.  

![Layout shape animation effect](layout-shape-animation.png)  

Und schließlich wurde der **Fly In**‑Effekt auf den Fußzeilen‑Platzhalter der **Master**‑Folie angewendet.  

![Master shape animation effect](master-shape-animation.png)  

Der folgende Beispielcode zeigt, wie Sie die Methode `get_base_placeholder` der [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) Klasse verwenden, um auf die Form‑Platzhalter zuzugreifen und die auf die Fußzeilenform angewendeten Animationseffekte zu erhalten, einschließlich der von Platzhaltern auf Layout‑ und Master‑Folien geerbten.  
```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Animationseffekte der Form auf der normalen Folie abrufen.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Animationseffekte des Platzhalters auf der Layoutfolie abrufen.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Animationseffekte des Platzhalters auf der Masterfolie abrufen.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```


```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```


## **Timing‑Eigenschaften von Animationseffekten ändern**

Aspose.Slides für Python via .NET ermöglicht es Ihnen, die Timing‑Eigenschaften eines Animationseffekts zu ändern.  

Dies ist das Animations‑Timing‑Paneel in Microsoft PowerPoint:  

![example1_image](shape-animation.png)  

Dies sind die Entsprechungen zwischen PowerPoint‑Timing und den `Effect.Timing` Eigenschaften:  

- Die PowerPoint‑Timing‑Auswahl **Start** entspricht der [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) Eigenschaft.  
- Die PowerPoint‑Timing‑Auswahl **Duration** entspricht der `Effect.Timing.Duration` Eigenschaft. Die Dauer einer Animation (in Sekunden) ist die Gesamtdauer, die die Animation für einen Durchlauf benötigt.  
- Die PowerPoint‑Timing‑Auswahl **Delay** entspricht der `Effect.Timing.TriggerDelayTime` Eigenschaft.  

So ändern Sie die Effekt‑Timing‑Eigenschaften:  

1. [Apply](#apply-animation-to-shape) oder holen Sie den Animationseffekt.  
2. Setzen Sie neue Werte für die benötigten `Effect.Timing` Eigenschaften.  
3. Speichern Sie die geänderte PPTX‑Datei.  

Dieser Python-Code demonstriert die Vorgehensweise:  
```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Holt die Hauptsequenz der Folie.
    sequence = pres.slides[0].timeline.main_sequence

    # Holt den ersten Effekt der Hauptsequenz.
    effect = sequence[0]

    # Ändert den TriggerType des Effekts, um beim Klick zu starten
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Ändert die Dauer des Effekts
    effect.timing.duration = 3

    # Ändert die TriggerDelayTime des Effekts
    effect.timing.trigger_delay_time = 0.5

    # Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```


## **Ton des Animationseffekts**

Aspose.Slides stellt diese Eigenschaften zur Verfügung, um mit Geräuschen in Animationseffekten zu arbeiten:  

- `sound`  
- `stop_previous_sound`  

### **Ton zum Animationseffekt hinzufügen**

Dieser Python-Code zeigt, wie Sie einem Animationseffekt einen Ton hinzufügen und diesen stoppen, wenn der nächste Effekt startet:  
```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Fügt Audio zur Audio‑Sammlung der Präsentation hinzu
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Holt die Hauptsequenz der Folie.
    sequence = first_slide.timeline.main_sequence

    # Holt den ersten Effekt der Hauptsequenz
    first_effect = sequence[0]

    # Überprüft den Effekt auf "Kein Sound"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Fügt dem ersten Effekt einen Sound hinzu
        first_effect.sound = effect_sound

    # Holt die erste interaktive Sequenz der Folie.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Setzt das Flag "Vorherigen Sound stoppen" für den Effekt
    interactive_sequence[0].stop_previous_sound = True

    # Schreibt die PPTX‑Datei auf die Festplatte
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```


### **Ton des Animationseffekts extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich die Referenz einer Folie über ihren Index.  
3. Holen Sie die Hauptsequenz von Effekten.  
4. Extrahieren Sie das in jeden Animationseffekt eingebettete `sound`.  

Dieser Python-Code zeigt, wie Sie den in einen Animationseffekt eingebetteten Ton extrahieren:  
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

        # Extrahiert den Sound des Effekts als Byte‑Array
        audio = effect.sound.binary_data
```


## **Nach Animation**

Aspose.Slides für .NET ermöglicht es Ihnen, die After‑Animation‑Eigenschaft eines Animationseffekts zu ändern.  

Dies ist das Animation‑Effekt‑Fenster und das erweiterte Menü in Microsoft PowerPoint:  

![example1_image](shape-after-animation.png)  

Die PowerPoint‑Effekt‑Auswahl **After animation** entspricht diesen Eigenschaften:  

- Die `after_animation_type` Eigenschaft, die den After‑Animation‑Typ beschreibt:  
  * PowerPoint **More Colors** entspricht dem Typ [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).  
  * PowerPoint **Don't Dim** entspricht dem Typ [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (Standard‑After‑Animation‑Typ).  
  * PowerPoint **Hide After Animation** entspricht dem Typ [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).  
  * PowerPoint **Hide on Next Mouse Click** entspricht dem Typ [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).  
- Die `after_animation_color` Eigenschaft definiert ein Farbschema für die After‑Animation. Diese Eigenschaft funktioniert zusammen mit dem [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) Typ. Ändern Sie den Typ, wird die After‑Animation‑Farbe gelöscht.  

Dieser Python-Code zeigt, wie Sie einen After‑Animation‑Effekt ändern:  
```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Holt den ersten Effekt der Hauptsequenz
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändert den After-Animation-Typ auf Farbe
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Setzt die Dim-Farbe der Nach-Animation
    first_effect.after_animation_color.color = Color.alice_blue

    # Schreibt die PPTX-Datei auf die Festplatte
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```


## **Text animieren**

Aspose.Slides stellt diese Eigenschaften zur Verfügung, um mit dem *Animate text* Block eines Animationseffekts zu arbeiten:  

- `animate_text_type`, das den Animations‑Text‑Typ des Effekts beschreibt. Der Text einer Form kann animiert werden:  
  - Alles auf einmal ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) Typ)  
  - Wortweise ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) Typ)  
  - Buchstabenweise ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) Typ)  
- `delay_between_text_parts` legt eine Verzögerung zwischen den animierten Textteilen (Wörter oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effektdauer an. Ein negativer Wert gibt die Verzögerung in Sekunden an.  

So können Sie die Eigenschaften des Effekt‑Animate‑Text ändern:  

1. [Apply](#apply-animation-to-shape) oder holen Sie den Animationseffekt.  
2. Setzen Sie die `build_type` Eigenschaft auf den Wert [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/), um den *By Paragraphs* Animationsmodus zu deaktivieren.  
3. Setzen Sie neue Werte für die Eigenschaften `animate_text_type` und `delay_between_text_parts`.  
4. Speichern Sie die geänderte PPTX‑Datei.  

Dieser Python-Code demonstriert die Vorgehensweise:  
```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Holt den ersten Effekt der Hauptsequenz
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändert den Textanimations-Typ des Effekts zu "Als ein Objekt"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Ändert den Animations-Text-Typ des Effekts zu "Nach Wort"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Setzt die Verzögerung zwischen Wörtern auf 20% der Effektdauer
    first_effect.delay_between_text_parts = 20

    # Speichert die PPTX-Datei auf dem Datenträger
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```


## **FAQ**

**Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?**  
[Export to HTML5](/slides/de/python-net/export-to-html5/) und aktivieren Sie die [Optionen](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/), die für [shape](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) und [transition](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) Animationen verantwortlich sind. Reines HTML spielt Folienanimationen nicht ab, HTML5 jedoch schon.  

**Wie wirkt sich das Ändern der Z‑Reihenfolge (Layer‑Reihenfolge) von Formen auf die Animation aus?**  
Animationen und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinens/Verscheidens, während die [z-order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) bestimmt, was was überlagert. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das allgemeine PowerPoint‑Verhalten; das Aspose.Slides‑Effekte‑und‑Formen‑Modell folgt derselben Logik.)  

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**  
Im Allgemeinen werden [Animationen unterstützt](/slides/de/python-net/convert-powerpoint-to-video/), jedoch können seltene Fälle oder bestimmte Effekte anders gerendert werden. Es wird empfohlen, die von Ihnen verwendeten Effekte und die Bibliotheksversion zu testen.