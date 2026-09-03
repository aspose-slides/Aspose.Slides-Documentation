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
description: "Folienübergänge anwenden, automatisches Voranschreiten der Folien konfigurieren und Morph sowie weitere Übergangseffekte mit Aspose.Slides für Python via .NET anpassen."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Bildschirmpräsentation angezeigt werden. Mit Aspose.Slides für Python via .NET können Sie für jede Folie einen Übergangseffekt auswählen, das Voranschreiten per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen für einen Effekt anpassen. Dieser Artikel verwendet Python‑Beispiele, um Übergänge anzuwenden, genaue Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen zudem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) und greifen auf die Eigenschaft [slide_show_transition](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/slide_show_transition/) der Folie zu. Setzen Sie deren [type](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/type/) auf einen Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/transitiontype/), und speichern Sie anschließend die Präsentation.

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

## **Erweiterten Folienübergang hinzufügen**

Sie können konfigurieren, wie lange eine Folie auf dem Bildschirm bleibt und ob ein Mausklick die Vorführung fortsetzt. Die folgenden Eigenschaften steuern dieses Verhalten:

- [advance_on_click](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) ermöglicht dem Betrachter, durch Klicken der Maus voranzuschreiten.
- [advance_after](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) aktiviert das automatische Voranschreiten.
- [advance_after_time](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) gibt die Verzögerung vor dem automatischen Voranschreiten in Millisekunden an.

Aktivieren Sie sowohl Klick‑ als auch Timer‑Fortschritt, damit der Betrachter entweder per Klick weitergeht oder auf den Timer wartet. Um ausschließlich den Timer zu verwenden, setzen Sie [advance_on_click](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) auf `False`. Die Verzögerung bestimmt, wann die Vorführung weitergeht; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert das automatische Voranschreiten nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls voranbringen. Verwenden Sie eine `input.pptx`‑Datei mit mindestens drei Folien.

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

Um zu prüfen, ob das zeitgesteuerte Voranschreiten aktiviert ist, lesen Sie [advance_after](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Ein gespeicherter Verzögerungswert allein bedeutet nicht, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, gibt jeden aktivierten Timer aus und deaktiviert das automatische Voranschreiten für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien wird der Mausklick aktiviert und die aktualisierten Einstellungen werden gespeichert.

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

Verwenden Sie [duration](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/duration/), um die genaue Länge eines Übergangseffekts in Millisekunden anzugeben. Die Eigenschaft [slide_show_transition](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/slide_show_transition/) der Folie stellt diese Einstellungen über [SlideShowTransition](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/) bereit:

| Eigenschaft | Zweck |
| --- | --- |
| [duration](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Setzt die Dauer des Übergangseffekts selbst, in Millisekunden. |
| [advance_after_time](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Legt die Verzögerung fest, bevor die Folie automatisch weitergeht, in Millisekunden. Aktivieren Sie [advance_after](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/), um diesen Timer zu aktivieren. |
| [speed](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM oder FAST. Sie wird verwendet, wenn keine genaue Dauer angegeben ist. |

[duration](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/duration/) beeinflusst nur den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Die Verzögerung für das automatische Voranschreiten muss separat konfiguriert werden. Wenn keine explizite Dauer festgelegt ist, ermittelt Aspose.Slides die Effektdauer anhand des Übergangstyps und des [speed](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/speed/)-Werts.

### **Gleiche Dauer für jede Folie anwenden**

Für ein gleichmäßiges Tempo wenden Sie denselben Effekt und dieselbe genaue Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/transitiontype/), und gibt jedem Übergang eine Dauer von 750 Millisekunden. Zusätzlich wird das automatische Voranschreiten nach 5 000 Millisekunden aktiviert und das Voranschreiten per Mausklick deaktiviert, bevor das Ergebnis als PPTX gespeichert wird.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Konfigurieren Sie das automatische Voranschreiten unabhängig von der Effektdauer.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Unterschiedliche Dauern für einzelne Folien festlegen**

Verschiedene Folien können unterschiedliche Effektdauern verwenden. Beispielweise kann ein kurzer Übergang für eine Titelfolie und ein längerer für eine Abschnittseinleitung eingesetzt werden. Dieses Beispiel setzt 500 Millisekunden für die erste Folie und 1 200 Millisekunden für die zweite. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

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

### **Übergänge mit animierter Ausgabe abstimmen**

Wenn Sie ein [animated GIF](/slides/de/python-net/convert-powerpoint-to-animated-gif/), eine [HTML5 presentation](/slides/de/python-net/export-to-html5/) oder ein [video](/slides/de/python-net/convert-powerpoint-to-video/) vorbereiten, setzen Sie genaue Übergangsdauern vor dem Export, um das gewünschte Tempo zu erreichen. Beispielsweise können Sie ein 600‑Millisekunden‑Fade zwischen Szenen verwenden und jede Folienverzögerung separat anpassen, damit Zeit für die zugehörige Erzählung oder den Inhalt bleibt.

Für GIF‑ und Videoausgabe koordinieren Sie die Bildrate mit der Effektdauer: 600 Millisekunden entsprechen 18 Frames bei 30 Frames pro Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Exporteinstellungen. Prüfen Sie die vom gewählten Exportformat unterstützten Effekte und Timing‑Optionen und sehen Sie sich eine Vorschau an, um die Synchronisation zu bestätigen.

### **Bestehende Übergangsdauer auslesen**

Lesen Sie [duration](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/duration/) aus, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer festgelegt wurde; ein nichtnegativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides ermittelt die Dauer aus dem Übergangstyp und dem [speed](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/speed/). Das Festlegen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zunächst die ursprünglichen Einstellungen prüfen.

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

## **Morph-Übergang**

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, duplizieren Sie eine Folie, verschieben oder skalieren Sie ein Objekt auf der Kopie und wenden Sie den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die entsprechenden Objekte einen Animationspfad zwischen ihrem ursprünglichen und modifizierten Zustand.

Das folgende Beispiel erstellt eine Folie mit einem Textrechteck, dupliziert die Folie und ändert Position und Größe des Rechtecks auf der Kopie. Anschließend wird Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/transitiontype/) für die zweite Folie ausgewählt. Öffnen Sie die gespeicherte Datei in einem Präsentationsviewer, der Morph unterstützt, um den Effekt während einer Vorführung zu sehen.

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

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/transitionmorphtype/) bestimmt, wie Morph Inhalte abgleicht und animiert:

- [BY_OBJECT](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/transitionmorphtype/) behandelt jede Form als gesamtes Objekt.
- [BY_WORD](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/transitionmorphtype/) animiert Text, indem nach Möglichkeit Wörter abgeglichen werden.
- [BY_CHAR](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/transitionmorphtype/) animiert Text, indem nach Möglichkeit Zeichen abgeglichen werden.

Setzen Sie den Übergang [type](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/type/) auf Morph, bevor Sie auf dessen [value](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/value/) zugreifen. Der Wert liefert dann das Objekt [MorphTransition](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/morphtransition/), dessen Eigenschaft [morph_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/morphtransition/morph_type/) den Abgleichmodus auswählt.

Dieses Beispiel öffnet die in dem vorherigen Abschnitt erstellte Präsentation und konfiguriert die zweite Folie so, dass sie eine wortbasierte Morph‑Animation verwendet.

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

Einige Übergänge bieten zusätzliche Optionen, etwa die Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom gewählten Übergangs-[type](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/type/) ab. Setzen Sie zunächst den Typ und verwenden Sie dann das passende Übergangsobjekt aus dessen [value](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es setzt [from_black](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) über [OptionalBlackTransition](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/optionalblacktransition/), sodass der Übergang von einem schwarzen Bildschirm startet.

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

Ja. Verwenden Sie [duration](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/duration/), wenn Sie eine exakte Effektdauer in Millisekunden benötigen. Nutzen Sie [speed](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/speed/), wenn eine vordefinierte Kategorie aus [TransitionSpeed](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/transitionspeed/) — SLOW, MEDIUM oder FAST — ausreicht und keine explizite Dauer festgelegt ist. Diese Einstellungen beeinflussen den Übergangseffekt unabhängig von der automatischen Voranschrittsverzögerung.

**Kann ich einem Übergang Audio hinzufügen und es wiederholen lassen?**

Ja. Weisen Sie eingebettetes Audio der Eigenschaft [sound](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/sound/) zu, setzen Sie [sound_mode](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) auf START_SOUND aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/transitionsoundmode/), und aktivieren Sie [sound_loop](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Das Audio wird wiederholt, bis das nächste Sound‑Ereignis in der Vorführung eintritt.

**Was ist der schnellste Weg, denselben Übergang auf alle Folien anzuwenden?**

Durchlaufen Sie die [slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/slides/de/)-Sammlung der Präsentation und setzen Sie für jede Folie den Übergangs-[type](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/type/) auf denselben Wert. Setzen Sie Timing‑ und Effektoptionen im selben Durchlauf, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich prüfen, welcher Übergang gerade für eine Folie eingestellt ist?**

Lesen Sie die Eigenschaft [type](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/slideshowtransition/type/) aus der [slide_show_transition](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/slide_show_transition/)-Eigenschaft der Folie. Sie liefert einen Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/python-net/aspose.slides.slideshow/transitiontype/); NONE bedeutet, dass kein Übergangseffekt angewendet ist.