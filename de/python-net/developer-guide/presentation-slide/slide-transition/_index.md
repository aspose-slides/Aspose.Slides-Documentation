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
- Erweiterter Folienübergang
- Morph-Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Folienübergänge anwenden, automatisches Vorwärtsblättern konfigurieren und Morph sowie andere Übergangseffekte mit Aspose.Slides für Python via .NET anpassen."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Bildschirmpräsentation angezeigt werden. Mit Aspose.Slides für Python via .NET können Sie für jede Folie einen Übergangseffekt auswählen, den Fortschritt per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen vornehmen. Dieser Artikel verwendet Python‑Beispiele, um Übergänge anzuwenden, exakte Übergangsdauern festzulegen, Folienzeiten zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen außerdem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und greifen auf die Folie‑Eigenschaft [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) zu. Setzen Sie deren [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) auf einen Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), dann speichern Sie die Präsentation.

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

Die [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) Eigenschaft von [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) steuert die Anzahl der radialen Sektoren, die die Ziel‑Folie sichtbar machen. Setzen Sie den Folien‑Übergangs‑[type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) auf WHEEL aus [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), bevor Sie auf [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) als [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) zugreifen.

Dieses Beispiel erzeugt zwei identische Folienpaare: eine schwarze Folie, gefolgt von einer Folie mit einem goldenen Rechteck. Die Ziel‑Folien verwenden eine Speichen‑Anzahl von 1 bzw. 8, mit derselben [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) und einer expliziten [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) von 8 000 Millisekunden, um den Unterschied leicht erkennbar zu machen.

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

Öffnen Sie die Ausgabedatei in PowerPoint und starten Sie die Bildschirmpräsentation. Wechseln Sie von Folie 1 zu Folie 2 und anschließend von Folie 3 zu Folie 4. In der PowerPoint‑Wiedergabe deckt die verifizierte Speichen‑Anzahl 1 die Folie mit einem einzigen, im Uhrzeigersinn verlaufenden Schwung auf; die verifizierte Anzahl 8 deckt sie gleichzeitig über acht radiale Sektoren ab. Inhalt und Timing der Ziel‑Folien sind identisch, der Unterschied liegt in der Zahl der Aufdeck‑Sektoren.

## **Durch Schwarz ausblenden mit dem Reveal‑Übergang**

Setzen Sie den Ziel‑Folien‑[type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) auf Reveal und aktivieren Sie anschließend [through_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/through_black/) am resultierenden [RevealTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/) Objekt. Das Beispiel erstellt eine teal‑Quellfolie und eine korallenfarbene Ziel‑folie, klont das Paar und verwendet für beide Paare denselben zweisekündigen Reveal‑Übergang. Nur das zweite Paar blendet über Schwarz ein.

```python
import aspose.slides as slides


def style_slide(slide, background_color, label):
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.preset_color = background_color

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 160, 180, 400, 130)
    shape.text_frame.text = label
    shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 44


with slides.Presentation() as presentation:
    source = presentation.slides[0]
    destination = presentation.slides.add_clone(source)
    style_slide(source, slides.PresetColor.TEAL, "Source")
    style_slide(destination, slides.PresetColor.CORAL, "Destination")
    presentation.slides.add_clone(source)
    presentation.slides.add_clone(destination)

    for index in (1, 3):
        transition = presentation.slides[index].slide_show_transition
        transition.type = slides.slideshow.TransitionType.REVEAL
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 2000
        
        reveal = transition.value
        reveal.direction = slides.slideshow.TransitionLeftRightDirectionType.LEFT
        reveal.through_black = index == 3

    presentation.save("reveal-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Öffnen Sie `reveal-transitions.pptx` in PowerPoint und starten Sie die Bildschirmpräsentation. Wechseln Sie von Folie 1 zu Folie 2, um das direkte Fade von teal nach coral zu sehen. Dann von Folie 3 zu Folie 4. Der Bildschirm wird kurz fast schwarz, bevor die coral‑Folie erscheint. Beide Folien behalten ihre ursprünglichen Hintergrundfarben.

Die Zeilen unten zeigen Bildausschnitte aus PowerPoint im Abstand von halben Sekunden. Vergleichen Sie den mittleren Frame jeder Zeile, um den Effekt der Einstellung zu erkennen.

![PowerPoint-Wiedergabe mit deaktiviertem through_black (oben) und aktiviertem (unten). Nur die untere Zeile geht fast durch Schwarz.](reveal-through-black.png)

*Das gemeinsam genutzte Beispiel gibt jeder Folie einen 750‑ms Fade‑Übergang und aktiviert separat die automatische Fortsetzung nach 5 000 ms. Die Übergangsdauer steuert den Effekt; die Fortsetzung bestimmt, wann die Folie verlassen wird. Diese Balken sind schematische Einstellungen, kein gemessener kombinierter Zeitplan.*

### **Erweiterten Folienübergang hinzufügen**

Sie können konfigurieren, wie lange eine Folie angezeigt wird und ob ein Mausklick die Präsentation fortsetzt. Die folgenden Eigenschaften steuern dieses Verhalten:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) ermöglicht dem Betrachter, durch Klicken der Maus fortzuschalten.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) aktiviert die automatische Fortschreitung.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) gibt die Verzögerung vor der automatischen Fortschreitung in Millisekunden an.

Aktivieren Sie sowohl Klick‑ als auch Zeit‑Fortschritt, damit der Betrachter entweder per Klick weitergeht oder auf den Timer wartet. Um nur den Timer zu verwenden, setzen Sie [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) auf `False`. Die Verzögerung bestimmt, wann die Präsentation fortschreitet; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert die automatische Fortsetzung nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls voranbringen. Verwenden Sie eine `input.pptx`‑Datei mit mindestens drei Folien.

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

Um zu prüfen, ob die zeitgesteuerte Fortsetzung aktiviert ist, lesen Sie [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Ein gespeicherter Verzögerungswert allein zeigt nicht an, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, meldet jeden aktivierten Timer und deaktiviert die automatische Fortsetzung für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien wird der Mausklick aktiviert und die aktualisierten Einstellungen werden gespeichert.

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

## **Übergangszeit exakt steuern**

Verwenden Sie [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/), um die genaue Länge eines Übergangseffekts in Millisekunden anzugeben. Die Folien‑Eigenschaft [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) gibt diese Einstellungen über [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/) frei:

| Eigenschaft | Zweck |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Legt die Dauer des eigentlichen Übergangseffekts in Millisekunden fest. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Gibt die Verzögerung vor dem automatischen Vorwärtswechsel der Folie in Millisekunden an. Aktivieren Sie [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/), um diesen Timer zu nutzen. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM oder FAST. Sie wird verwendet, wenn keine exakte Dauer angegeben ist. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) steuert nur den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Konfigurieren Sie die automatische Fortschrittsverzögerung separat. Wenn keine explizite Dauer gesetzt ist, ermittelt Aspose.Slides die Effekt‑Dauer aus dem Übergangstyp und dem [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)-Wert.

<!-- visual-explanation:slide-transition:start -->
[![Separate Balken zeigen die 750‑ms Übergangsdauer und die 5 000‑ms automatische Fortschritts‑Einstellung.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Das gemeinsam genutzte Beispiel gibt jeder Folie einen 750‑ms Fade‑Übergang und aktiviert separat die automatische Fortsetzung nach 5 000 ms. Die Übergangsdauer steuert den Effekt; die Fortsetzung bestimmt, wann die Folie verlassen wird. Diese Balken sind schematische Einstellungen, kein gemessener kombinierter Zeitplan.*
<!-- visual-explanation:slide-transition:end -->

### **Die gleiche Dauer auf jede Folie anwenden**

Um ein gleichmäßiges Tempo zu gewährleisten, wenden Sie denselben Effekt und dieselbe exakte Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) und gibt jedem Übergang eine Dauer von 750 Millisekunden. Zusätzlich wird die automatische Fortsetzung nach 5 000 Millisekunden aktiviert und der Mausklick‑Fortschritt deaktiviert, dann wird das Ergebnis als PPTX gespeichert.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Automatischen Fortschritt unabhängig von der Dauer des Effekts konfigurieren.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Unterschiedliche Dauern für einzelne Folien festlegen**

Verschiedene Folien können unterschiedliche Effektdauern verwenden. Zum Beispiel kann eine Titelfolie einen kurzen Übergang und eine Abschnittseinleitung einen längeren Übergang erhalten. Dieses Beispiel setzt 500 Millisekunden für die erste Folie und 1 200 Millisekunden für die zweite. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

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

Wenn Sie ein [animated GIF](/slides/de/python-net/convert-powerpoint-to-animated-gif/), eine [HTML5‑Präsentation](/slides/de/python-net/export-to-html5/) oder ein [Video](/slides/de/python-net/convert-powerpoint-to-video/) erzeugen, setzen Sie exakte Übergangszeiten vor dem Export, um das gewünschte Tempo zu erreichen. Beispielsweise können Sie zwischen Szenen ein 600‑ms‑Fade verwenden und für jede Folie die Fortschrittsverzögerung separat anpassen, damit genügend Zeit für Sprechertext oder Inhalte bleibt.

Für GIF und Video sollte die Bildrate der Effektdauer entsprechen: 600 Millisekunden entsprechen 18 Frames bei 30 fps. In HTML5 aktivieren Sie animierte Übergänge in den Exporteinstellungen. Prüfen Sie die von dem gewählten Exportformat unterstützten Effekte und Timing‑Optionen und prüfen Sie die Ausgabe, um die Synchronisation zu bestätigen.

### **Vorhandene Übergangs‑dauer auslesen**

Lesen Sie [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) aus, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer gesetzt ist; ein nicht‑negativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides ermittelt die Dauer aus dem Übergangstyp und dem [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/). Das Setzen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zuerst die ursprünglichen Einstellungen prüfen.

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

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, klonen Sie eine Folie, verschieben oder skalieren ein Objekt auf dem Klon und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch bekommen die zugehörigen Objekte einen Animationspfad zwischen ihrem ursprünglichen und geänderten Zustand.

Das folgende Beispiel erstellt eine Folie mit einem Text‑Rechteck, klont die Folie und ändert Position und Größe des Rechtecks im Klon. Anschließend wird für die zweite Folie Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) gewählt. Öffnen Sie die gespeicherte Datei in einem Präsentationsviewer, der Morph unterstützt, um den Effekt während einer Bildschirmpräsentation zu sehen.

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

Setzen Sie den Übergangs‑[type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) auf Morph, bevor Sie auf dessen [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) zugreifen. Der zurückgegebene Wert liefert dann das [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) Objekt, dessen [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) Eigenschaft den Zuordnungsmodus auswählt.

Dieses Beispiel öffnet die im vorherigen Abschnitt erstellte Präsentation und konfiguriert die zweite Folie so, dass sie eine wortbasierte Morph‑Animation verwendet.

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

Einige Übergänge bieten zusätzliche Optionen, beispielsweise Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom gewählten Übergangs‑[type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) ab. Setzen Sie zuerst den Typ und verwenden Sie dann das passende Übergangs‑Objekt aus dessen [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

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

Ja. Verwenden Sie [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/), wenn Sie eine exakte Effekt‑Dauer in Millisekunden benötigen. Nutzen Sie [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/), wenn eine vordefinierte [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/)-Kategorie — SLOW, MEDIUM oder FAST — ausreichend ist und keine explizite Dauer gesetzt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der automatischen Fortschrittsverzögerung.

**Kann ich einer Transition Audio hinzufügen und es wiederholen lassen?**

Ja. Weisen Sie eingebettetes Audio [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) zu, setzen Sie [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) auf START_SOUND aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) und aktivieren Sie [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Das Audio wiederholt sich, bis das nächste Sound‑Ereignis in der Präsentation eintritt.

**Wie ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Durchlaufen Sie die [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) Sammlung der Präsentation und setzen Sie für jede Folie den Übergangs‑[type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) auf denselben Wert. Setzen Sie Timing‑ und Effekt‑Optionen im selben Durchlauf, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich überprüfen, welcher Übergang aktuell für eine Folie festgelegt ist?**

Lesen Sie die [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) Eigenschaft der Folien‑[slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Sie liefert einen Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); NONE bedeutet, dass kein Übergangseffekt angewendet wird.