---
title: Form‑Animationen in Präsentationen mit Python anwenden
linktitle: Form‑Animation
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
- Effekt Ton
- Animation anwenden
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie, wie Sie Form‑Animationen in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python via .NET erstellen und anpassen. Setzen Sie Akzente!"
---

Animationen sind visuelle Effekte, die auf Texte, Bilder, Formen oder [Diagramme](/slides/de/python-net/animated-charts/) angewendet werden können. Sie verleihen Präsentationen und ihren Bestandteilen Leben.

## **Warum Animationen in Präsentationen verwenden?**

Durch den Einsatz von Animationen können Sie  

* den Informationsfluss steuern  
* wichtige Punkte hervorheben  
* das Interesse oder die Beteiligung des Publikums erhöhen  
* den Inhalt leichter lesbar, verständlich oder verarbeitbar machen  
* die Aufmerksamkeit der Leser oder Zuschauer auf wichtige Teile einer Präsentation lenken  

PowerPoint bietet zahlreiche Optionen und Werkzeuge für Animationen und Animationseffekte in den Kategorien **Eingang**, **Ausgang**, **Betonung** und **Bewegungspfad**.

## **Animationen in Aspose.Slides**

* Aspose.Slides stellt die Klassen und Typen bereit, die Sie benötigen, um mit Animationen im Namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) zu arbeiten,  
* Aspose.Slides bietet über **150 Animationseffekte** im Aufzählungstyp [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Diese Effekte entsprechen im Wesentlichen den gleichen (oder äquivalenten) Effekten, die in PowerPoint verwendet werden.

## **Animation auf Textfeld anwenden**

Aspose.Slides for Python via .NET ermöglicht es, Animationen auf den Text einer Form anzuwenden.  

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Fügen Sie eine `Rechteck`‑[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.  
4. Fügen Sie Text zu `IAutoShape.TextFrame` hinzu.  
5. Holen Sie die Hauptsequenz der Effekte.  
6. Fügen Sie einen Animationseffekt zu [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.  
7. Setzen Sie die Eigenschaft `TextAnimation.BuildType` auf einen Wert aus der Aufzählung `BuildType`.  
8. Speichern Sie die Präsentation als PPTX‑Datei auf dem Datenträger.  

Dieses Python‑Beispiel zeigt, wie Sie den `Fade`‑Effekt auf eine AutoShape anwenden und die Textanimation auf den Wert *By 1st Level Paragraphs* setzen:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Fügt eine neue AutoShape mit Text hinzu
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Holt die Hauptsequenz der Folie.
    sequence = sld.timeline.main_sequence

    # Fügt den Fade‑Animationseffekt zur Form hinzu
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animiert den Formtext nach 1. Ebene‑Absätzen
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Speichert die PPTX‑Datei auf dem Datenträger
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Neben der Anwendung von Animationen auf Text können Sie auch Animationen auf einen einzelnen [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) anwenden. Siehe [**Animierter Text**](/slides/de/python-net/animated-text/).

{{% /alert %}} 

## **Animation auf Bildrahmen anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Fügen Sie einen [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) zur Folie hinzu oder holen Sie ihn.  
4. Holen Sie die Hauptsequenz der Effekte.  
5. Fügen Sie einen Animationseffekt zu [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) hinzu.  
6. Speichern Sie die Präsentation als PPTX‑Datei auf dem Datenträger.  

Dieses Python‑Beispiel zeigt, wie Sie den `Fly`‑Effekt auf einen Bildrahmen anwenden:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation() as pres:
    # Laden Sie das Bild, das in die Präsentations‑Bilder‑Sammlung eingefügt werden soll
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Fügt Bildrahmen zur Folie hinzu
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Holt die Hauptsequenz der Folie.
    sequence = pres.slides[0].timeline.main_sequence

    # Fügt den Fly‑von‑Links‑Animationseffekt zum Bildrahmen hinzu
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Speichert die PPTX‑Datei auf dem Datenträger
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animation auf Form anwenden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Fügen Sie eine `Rechteck`‑[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu.  
4. Fügen Sie ein `Bevel`‑[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) hinzu (wenn dieses Objekt angeklickt wird, wird die Animation abgespielt).  
5. Erstellen Sie eine Sequenz von Effekten für die Bevel‑Form.  
6. Erstellen Sie einen benutzerdefinierten `UserPath`.  
7. Fügen Sie Befehle zum Bewegen zum `UserPath` hinzu.  
8. Speichern Sie die Präsentation als PPTX‑Datei auf dem Datenträger.  

Dieses Python‑Beispiel zeigt, wie Sie den `PathFootball`‑Effekt (Pfad‑Fußball) auf eine Form anwenden:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiert eine Presentation‑Klasse, die eine PPTX‑Datei repräsentiert
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Erstellt den PathFootball‑Effekt für eine bereits vorhandene Form.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Fügt den PathFootball‑Animationseffekt hinzu.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Erstellt so etwas wie einen „Button“.
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

    # Speichert die PPTX‑Datei auf dem Datenträger
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animationseffekte ermitteln, die einer Form zugewiesen wurden**

Die folgenden Beispiele zeigen, wie Sie die Methode `get_effects_by_shape` der [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) Klasse verwenden, um alle Animationseffekte zu erhalten, die einer Form zugewiesen wurden.

**Beispiel 1: Animationseffekte einer Form auf einer normalen Folie ermitteln**

Zuvor haben Sie gelernt, wie Animationseffekte zu Formen in PowerPoint‑Präsentationen hinzugefügt werden. Der folgende Beispielcode zeigt, wie Sie die auf die erste Form der ersten normalen Folie in der Präsentation `AnimExample_out.pptx` angewendeten Effekte ermitteln.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Holt die Haupt‑Animationssequenz der Folie.
    sequence = first_slide.timeline.main_sequence

    # Holt die erste Form auf der ersten Folie.
    shape = first_slide.shapes[0]

    # Holt die auf die Form angewendeten Animationseffekte.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("Die Form", shape.name, "hat", len(shape_effects), "Animationseffekte.")
```

**Beispiel 2: Alle Animationseffekte, einschließlich der von Platzhaltern geerbten, ermitteln**

Hat eine Form auf einer normalen Folie Platzhalter, die sich auf der Layout‑ bzw. Master‑Folie befinden, und wurden diesen Platzhaltern Animationseffekte zugewiesen, dann werden alle Effekte der Form während der Bildschirmanzeige abgespielt – auch die von den Platzhaltern geerbten.

Angenommen, wir haben eine PowerPoint‑Datei `sample.pptx` mit einer Folie, die ausschließlich eine Fußzeilen‑Form mit dem Text **„Made with Aspose.Slides“** enthält, und der **Random Bars**‑Effekt ist auf die Form angewendet.

![Folienformen‑Animations‑Effekt](slide-shape-animation.png)

Nehmen wir außerdem an, dass auf der **Layout‑**Folie der **Split**‑Effekt auf den Fußzeilen‑Platzhalter angewendet wurde.

![Layout‑Form‑Animations‑Effekt](layout-shape-animation.png)

Und schließlich ist auf der **Master‑**Folie der **Fly In**‑Effekt auf den Fußzeilen‑Platzhalter angewendet.

![Master‑Form‑Animations‑Effekt](master-shape-animation.png)

Der folgende Beispielcode zeigt, wie Sie die Methode `get_base_placeholder` der [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) Klasse nutzen, um zu den Platzhaltern zu gelangen und die auf die Fußzeilen‑Form angewendeten Animationseffekte, einschließlich der von Platzhaltern geerbten, zu erhalten.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Holt die Animationseffekte der Form auf der normalen Folie.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Holt die Animationseffekte des Platzhalters auf der Layout‑Folie.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Holt die Animationseffekte des Platzhalters auf der Master‑Folie.
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

Aspose.Slides for Python via .NET ermöglicht das Ändern der Timing‑Eigenschaften eines Animationseffekts.

Dies ist das **Animation Timing**‑Fenster in Microsoft PowerPoint:

![Beispiel1_Bild](shape-animation.png)

Die Entsprechungen zwischen PowerPoint‑Timing und den Eigenschaften `Effect.Timing` lauten:

- PowerPoint Timing **Start**‑Dropdown‑Liste entspricht der [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/)‑Eigenschaft.  
- PowerPoint Timing **Duration** entspricht der Eigenschaft `Effect.Timing.Duration`. Die Dauer (in Sekunden) ist die gesamte Zeit, die ein Effekt für einen Durchlauf benötigt.  
- PowerPoint Timing **Delay** entspricht der Eigenschaft `Effect.Timing.TriggerDelayTime`.  

So ändern Sie die Timing‑Eigenschaften eines Effekts:

1. [Animation auf Form anwenden](#animation-auf-form-anwenden) oder den Animationseffekt holen.  
2. Neue Werte für die gewünschten `Effect.Timing`‑Eigenschaften setzen.  
3. Die geänderte PPTX‑Datei speichern.

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Holt die Hauptsequenz der Folie.
    sequence = pres.slides[0].timeline.main_sequence

    # Holt den ersten Effekt der Hauptsequenz.
    effect = sequence[0]

    # Ändert den Trigger‑Typ zu „Bei Klick“
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Ändert die Dauer
    effect.timing.duration = 3

    # Ändert die Verzögerungszeit
    effect.timing.trigger_delay_time = 0.5

    # Speichert die PPTX‑Datei auf dem Datenträger
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ton für Animationseffekt**

Aspose.Slides stellt folgende Eigenschaften bereit, um mit Tönen in Animationseffekten zu arbeiten:  

- `sound`  
- `stop_previous_sound`

### **Ton zu Animationseffekt hinzufügen**

Dieses Python‑Beispiel zeigt, wie Sie einem Animationseffekt einen Ton hinzufügen und den Ton stoppen, wenn der nächste Effekt beginnt:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Fügt Audio zur Präsentations‑Audio‑Sammlung hinzu
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Holt die Hauptsequenz der Folie.
    sequence = first_slide.timeline.main_sequence

    # Holt den ersten Effekt der Hauptsequenz
    first_effect = sequence[0]

    # Prüft, ob der Effekt „Kein Ton“ hat
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Fügt dem ersten Effekt einen Ton hinzu
        first_effect.sound = effect_sound

    # Holt die erste interaktive Sequenz der Folie.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Setzt das Flag „Vorherigen Ton stoppen“
    interactive_sequence[0].stop_previous_sound = True

    # Speichert die PPTX‑Datei auf dem Datenträger
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Ton aus Animationseffekt extrahieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Holen Sie die Hauptsequenz der Effekte.  
4. Extrahieren Sie das in jedem Animationseffekt eingebettete `sound`.  

Dieses Python‑Beispiel zeigt, wie Sie den in einem Animationseffekt eingebetteten Ton extrahieren:

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

        # Extrahiert den Effekt‑Ton als Byte‑Array
        audio = effect.sound.binary_data
```

## **Nach Animation**

Aspose.Slides for .NET erlaubt das Ändern der **After animation**‑Eigenschaft eines Animationseffekts.

Dies ist das **Animation Effect**‑Fenster und das erweiterte Menü in Microsoft PowerPoint:

![Beispiel1_NachAnimation](shape-after-animation.png)

Die Dropdown‑Liste **After animation** in PowerPoint entspricht den folgenden Eigenschaften:  

- Die Eigenschaft `after_animation_type`, die den Typ der Nachanimation beschreibt:  
  * PowerPoint **Weitere Farben** entspricht dem Typ [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).  
  * PowerPoint **Nicht abdunkeln** entspricht dem Typ [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (Standard‑Nachanimationstyp).  
  * PowerPoint **Nach Animation ausblenden** entspricht dem Typ [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).  
  * PowerPoint **Bei nächstem Mausklick ausblenden** entspricht dem Typ [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).  

- Die Eigenschaft `after_animation_color`, die ein Farbschema für die Nachanimation definiert. Diese Eigenschaft arbeitet zusammen mit dem Typ [COLOR]. Wird ein anderer Typ gewählt, wird die Nachanimationsfarbe zurückgesetzt.

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Holt den ersten Effekt der Hauptsequenz
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändert den Nachanimationstyp zu Farbe
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Setzt die Nachanimations‑Dimmfarbe
    first_effect.after_animation_color.color = Color.alice_blue

    # Speichert die PPTX‑Datei auf dem Datenträger
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Text animieren**

Aspose.Slides bietet folgende Eigenschaften, um den *Animate text*‑Block eines Animationseffekts zu steuern:

- `animate_text_type` beschreibt den Typ der Textanimation des Effekts. Der Formtext kann animiert werden:  
  * Alles auf einmal ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)‑Typ)  
  * Wortweise ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)‑Typ)  
  * Buchstabenweise ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)‑Typ)  

- `delay_between_text_parts` legt eine Verzögerung zwischen den animierten Textteilen (Wörtern oder Buchstaben) fest. Ein positiver Wert gibt den Prozentsatz der Effekt‑Dauer an; ein negativer Wert gibt die Verzögerung in Sekunden an.

So ändern Sie die Eigenschaften *Animate text* eines Effekts:

1. [Animation auf Form anwenden](#animation-auf-form-anwenden) oder den Animationseffekt holen.  
2. Setzen Sie die Eigenschaft `build_type` auf den Wert [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/), um den Modus *By Paragraphs* zu deaktivieren.  
3. Neue Werte für die Eigenschaften `animate_text_type` und `delay_between_text_parts` setzen.  
4. Die geänderte PPTX‑Datei speichern.

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Holt den ersten Effekt der Hauptsequenz
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändert den Text‑Animationstyp zu „Als ein Objekt“
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Ändert den Typ der Textanimation zu „Wortweise“
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Setzt die Verzögerung zwischen Wörtern auf 20 % der Effekt‑Dauer
    first_effect.delay_between_text_parts = 20

    # Speichert die PPTX‑Datei auf dem Datenträger
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie kann ich sicherstellen, dass Animationen beim Veröffentlichen der Präsentation im Web erhalten bleiben?**  
Exportieren Sie zu **HTML5** ([Export to HTML5](/slides/de/python-net/export-to-html5/)) und aktivieren Sie die entsprechenden Optionen, die für **shape**‑ und **transition**‑Animationen verantwortlich sind. Reines HTML spielt Folienanimationen nicht ab, HTML5 hingegen schon.

**Wie wirkt sich das Ändern der Z‑Reihenfolge (Ebenenreihenfolge) von Formen auf Animationen aus?**  
Animation‑ und Zeichenreihenfolge sind unabhängig: Ein Effekt steuert das Timing und den Typ des Erscheinens/Verschwindens, während die **z_order_position** bestimmt, was was überdeckt. Das sichtbare Ergebnis ergibt sich aus ihrer Kombination. (Dies ist das generelle PowerPoint‑Verhalten; das Modell von Aspose.Slides folgt derselben Logik.)

**Gibt es Einschränkungen beim Konvertieren von Animationen in Video für bestimmte Effekte?**  
Im Allgemeinen werden Animationen unterstützt ([Animationen werden unterstützt](/slides/de/python-net/convert-powerpoint-to-video/)), jedoch können seltene Fälle oder spezielle Effekte anders gerendert werden. Es wird empfohlen, die von Ihnen genutzten Effekte und die Library‑Version zu testen.