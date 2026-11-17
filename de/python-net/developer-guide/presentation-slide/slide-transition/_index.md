---
title: Folienübergänge in Präsentationen mit Python verwalten
linktitle: Folienübergang
type: docs
weight: 90
url: /de/python-net/slide-transition/
keywords:
- Folienübergang
- Folienübergang hinzufügen
- Folienübergang anwenden
- erweiterter Folienübergang
- Morph-Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Folienübergänge anwenden, automatisches Voranschreiten von Folien konfigurieren und Morph- sowie andere Übergangseffekte mit Aspose.Slides für Python via .NET anpassen."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Diashow angezeigt werden. Mit Aspose.Slides for Python via .NET können Sie für jede Folie einen Übergangseffekt auswählen, den Fortschritt per Mausklick oder Timer konfigurieren und Optionen, die für einen Effekt spezifisch sind, anpassen. Dieser Artikel verwendet Python‑Beispiele, um Übergänge anzuwenden, genaue Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen außerdem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der Klasse [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und greifen auf die Folie‑Eigenschaft [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) zu. Setzen Sie deren [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) auf einen Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) und speichern Sie dann die Präsentation.

Das folgende Beispiel wendet einen Circle‑Übergang auf die erste Folie und einen Comb‑Übergang auf die zweite an. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Rad‑Übergang**

Die [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/)‑Eigenschaft von [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) steuert die Anzahl der radialen Sektoren, die die Ziel‑Folie enthüllen. Setzen Sie den [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) der Folie auf WHEEL aus [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), bevor Sie auf [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) als [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) zugreifen.

Dieses Beispiel erstellt zwei identische Folienpaare: eine schwarze Folie, gefolgt von einer Folie mit einem goldenen Rechteck. Die Ziel‑Folien verwenden Spokenzahlen von 1 und 8, mit derselben [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) und einer expliziten [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) von 8 000 Millisekunden, um den Unterschied leicht zu erkennen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Öffnen Sie die Ausgabedatei in PowerPoint und starten Sie die Diashow. Wechseln Sie von Folie 1 zu Folie 2 und dann von Folie 3 zu Folie 4. In der PowerPoint‑Wiedergabe enthüllt die verifizierte Spokenzahl 1 die Folie mit einem einzigen im Uhrzeigersinn verlaufenden Schnitt; die verifizierte Zahl 8 enthüllt sie gleichzeitig durch acht radiale Sektoren. Der Zielinhalt und die Übergangszeit sind identisch, sodass sich nur die Anzahl der Enthüllungssektoren unterscheidet.

## **Erweiterten Folienübergang hinzufügen**

Sie können konfigurieren, wie lange eine Folie angezeigt wird und ob ein Mausklick die Diashow voranbringt. Die folgenden Eigenschaften steuern dieses Verhalten:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) ermöglicht dem Betrachter, per Mausklick voranzuschalten.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) aktiviert das automatische Voranschalten.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) gibt die Verzögerung vor dem automatischen Voranschalten in Millisekunden an.

Aktivieren Sie sowohl Klick‑ als auch Timer‑Fortschritt, damit der Betrachter entweder per Klick weitergeht oder auf den Timer wartet. Um nur den Timer zu verwenden, setzen Sie [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) auf `False`. Die Verzögerung steuert, wann die Diashow weitergeht; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert das automatische Voranschalten nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls voranbringen. Verwenden Sie eine `input.pptx`‑Datei mit mindestens drei Folien.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Um zu prüfen, ob der zeitgesteuerte Fortschritt aktiviert ist, lesen Sie [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Ein gespeicherter Verzögerungswert allein bedeutet nicht, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, gibt für jede aktivierte Zeiteinstellung eine Meldung aus und deaktiviert das automatische Voranschalten für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien wird der Mausklick wieder aktiviert und die aktualisierten Einstellungen werden gespeichert.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Übergangszeitpunkt genau steuern**

Verwenden Sie [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/), um die genaue Länge eines Übergangseffekts in Millisekunden anzugeben. Die Eigenschaft [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) der Folie stellt diese Einstellungen über [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/) bereit:

| Eigenschaft | Zweck |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Legt die Dauer des eigentlichen Übergangseffekts in Millisekunden fest. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Legt die Verzögerung fest, bevor die Folie automatisch weitergeschaltet wird, in Millisekunden. Aktivieren Sie [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/), um diesen Timer zu aktivieren. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM oder FAST. Sie wird verwendet, wenn keine exakte Dauer angegeben ist. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) steuert nur den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Konfigurieren Sie die Verzögerung für das automatische Voranschalten separat. Wenn keine explizite Dauer gesetzt ist, bestimmt Aspose.Slides die Effektdauer aus dem Übergangstyp und dem [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)-Wert.

<!-- visual-explanation:slide-transition:start -->
[![Getrennte Balken zeigen die 750‑ms Übergangsdauer und die 5.000‑ms Einstellung für die automatische Weiterleitung.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Das gezeigte Beispiel gibt jeder Folie einen 750‑ms Fade‑Übergang und aktiviert zusätzlich das automatische Voranschalten nach 5.000 ms. Die Übergangsdauer steuert den Effekt; das Voranschalten legt fest, wann die Folie verlassen wird. Diese Balken sind schematische Einstellungen, kein gemessener kombinierter Zeitstrahl.*
<!-- visual-explanation:slide-transition:end -->

### **Die gleiche Dauer für jede Folie anwenden**

Für ein konsistentes Tempo wenden Sie denselben Effekt und dieselbe exakte Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert separat das automatische Voranschalten nach 5.000 Millisekunden und deaktiviert das Voranschalten per Mausklick, dann speichert es das Ergebnis als PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Automatisches Voranschreiten unabhängig von der Effektdauer konfigurieren.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Unterschiedliche Dauern für einzelne Folien festlegen**

Verschiedene Folien können unterschiedliche Effektdauern verwenden. Zum Beispiel kann eine Titelfolie einen kurzen Übergang erhalten, während eine Abschnittseinleitung einen längeren Übergang nutzt. Dieses Beispiel setzt 500 ms für die erste Folie und 1 200 ms für die zweite. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Übergänge mit animierter Ausgabe koordinieren**

Wenn Sie ein [animiertes GIF](/slides/de/python-net/convert-powerpoint-to-animated-gif/), eine [HTML5‑Präsentation](/slides/de/python-net/export-to-html5/) oder ein [Video](/slides/de/python-net/convert-powerpoint-to-video/) erstellen, setzen Sie exakte Übergangsdauern vor dem Export, um das gewünschte Tempo zu erreichen. Zum Beispiel verwenden Sie ein 600‑ms‑Fade zwischen Szenen und passen für jede Folie die Verzögerung des Voranschreitens separat an, um Zeit für die Erzählung oder den Inhalt zu lassen.

Für GIF und Video koordinieren Sie die Bildrate des Ausganges mit der Effektdauer: 600 ms entsprechen 18 Frames bei 30 Frames pro Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Exporteinstellungen. Prüfen Sie die unterstützten Effekte und Timing‑Optionen des gewählten Formats und prüfen Sie die Ausgabe, um die Synchronisation zu bestätigen.

### **Eine vorhandene Übergangsdauer lesen**

Lesen Sie [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/), bevor Sie den Übergang ändern, um zu bestimmen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer gesetzt ist; ein nicht‑negativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides ermittelt die Dauer aus dem Übergangstyp und dem [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/). Das Setzen eines Übergangstyps kann eine Dauer initialisieren, prüfen Sie also zuerst die Originaleinstellungen.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Morph‑Übergang**

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erstellen, duplizieren Sie eine Folie, verschieben oder skalieren Sie ein Objekt auf der Kopie und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die entsprechenden Objekte die Animation zwischen ihrem ursprünglichen und modifizierten Zustand.

Das folgende Beispiel erstellt eine Folie mit einem Textrechteck, dupliziert die Folie und ändert Position und Größe des Rechtecks auf der Kopie. Anschließend wählt es Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) für die zweite Folie. Öffnen Sie die gespeicherte Datei in einem Präsentationsviewer, der Morph unterstützt, um den Effekt während einer Diashow zu sehen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph‑Übergangstypen**

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) bestimmt, wie Morph Inhalte zuordnet und animiert:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) behandelt jede Form als ein ganzes Objekt.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animiert Text, indem nach Möglichkeit Wörter zugeordnet werden.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animiert Text, indem nach Möglichkeit Zeichen zugeordnet werden.

Setzen Sie den Übergang [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) auf Morph, bevor Sie auf dessen [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) zugreifen. Der zurückgegebene Wert liefert das [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/)-Objekt, dessen Eigenschaft [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) den Zuordnungsmodus auswählt.

Dieses Beispiel öffnet die im vorherigen Abschnitt erstellte Präsentation und konfiguriert die zweite Folie für eine wortbasierte Morph‑Animation.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Übergangseffekte festlegen**

Einige Übergänge bieten zusätzliche Optionen, etwa Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom gewählten Übergang [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) ab. Setzen Sie zuerst den Typ und verwenden Sie dann das passende Übergangsobjekt aus dessen [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es setzt [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) über [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/), sodass der Übergang von einem schwarzen Bildschirm startet.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Verwenden Sie [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/), wenn Sie eine exakte Effektdauer in Millisekunden benötigen. Nutzen Sie [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/), wenn eine vordefinierte [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/)-Kategorie – SLOW, MEDIUM oder FAST – ausreicht und keine explizite Dauer gesetzt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der Verzögerung des automatischen Voranschreitens.

**Kann ich einer Übergangsanimation Audio hinzufügen und es wiederholen lassen?**

Ja. Weisen Sie eingebettetes Audio [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) zu, setzen Sie [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) auf START_SOUND aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) und aktivieren Sie [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Das Audio wiederholt sich, bis das nächste Sound‑Ereignis in der Diashow eintritt.

**Was ist der schnellste Weg, denselben Übergang auf alle Folien anzuwenden?**

Durchlaufen Sie die [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)-Sammlung der Präsentation und setzen Sie für jede Folie den Übergang [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) auf denselben Wert. Setzen Sie Timing‑ und Effektoptionen im selben Durchlauf, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich überprüfen, welcher Übergang derzeit für eine Folie eingestellt ist?**

Lesen Sie die Eigenschaft [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) aus der [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) der Folie. Sie gibt einen Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) zurück; NONE bedeutet, dass kein Übergangseffekt angewendet wurde.