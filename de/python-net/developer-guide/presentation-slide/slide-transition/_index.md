---
title: Manage Slide Transitions in Presentations Using Python
linktitle: Slide Transition
type: docs
weight: 90
url: /de/python-net/slide-transition/
keywords:
- slide transition
- add slide transition
- apply slide transition
- advanced slide transition
- morph transition
- transition type
- transition effect
- Python
- Aspose.Slides
description: "Discover how to customize slide transitions in Aspose.Slides for Python via .NET, with step-by-step guidance for PowerPoint and OpenDocument presentations."
---

## **Übersicht**

Aspose.Slides für Python bietet vollständige Kontrolle über Folienübergänge, von der Auswahl eines Übergangstyps bis hin zur Konfiguration von Timing und Triggern im Rahmen automatisierter Präsentations-Workflows. Sie können Folien so einstellen, dass sie bei einem Klick und/oder nach einer festgelegten Verzögerung weiterblättern, und das visuelle Verhalten mit Effekten wie Schwarz-Blenden oder gerichteten Einblendungen verfeinern. Die Bibliothek unterstützt zudem den Morph‑Übergang, der mit PowerPoint 2019 eingeführt wurde, einschließlich Modi, die nach Objekt, Wort oder Zeichen morphen, um eine reibungslose, zusammenhängende Bewegung zwischen Folien zu erzeugen.

## **Folienübergänge hinzufügen**

Um das leichter verständlich zu machen, demonstriert dieses Beispiel, wie Sie Aspose.Slides für Python verwenden, um einfache Folienübergänge zu verwalten. Entwickler können verschiedene Folienübergangseffekte auf Folien anwenden und deren Verhalten anpassen. So erstellen Sie einen einfachen Folienübergang:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Wenden Sie einen Folienübergang mit einem der Effekte aus dem [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)-Enum an.
3. Speichern Sie die geänderte Präsentationsdatei.

```py
import aspose.slides as slides

# Instantiate the Presentation class to load a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Apply a circle transition to slide 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Apply a comb transition to slide 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Erweiterte Folienübergänge hinzufügen**

In diesem Abschnitt haben wir einen einfachen Übergangseffekt auf eine Folie angewendet. Um diesen Effekt kontrollierter und ausgefeilter zu gestalten, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Wenden Sie einen Folienübergang mit einem der Effekte aus dem [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)-Enum an.
3. Konfigurieren Sie den Übergang, sodass er bei Klick, nach einer bestimmten Zeitspanne oder beides fortschreitet.
4. Speichern Sie die geänderte Präsentationsdatei.

Wenn **Advance On Click** aktiviert ist, wird die Folie nur beim Klick des Benutzers weitergeschaltet. Ist die Eigenschaft **Advance After Time** gesetzt, wechselt die Folie automatisch nach dem angegebenen Intervall.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Apply a circle transition to slide 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Enable advance on click and set a 3-second auto-advance.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Apply a comb transition to slide 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Enable advance on click and set a 5-second auto-advance.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Apply a zoom transition to slide 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Enable advance on click and set a 7-second auto-advance.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph‑Übergang**

Aspose.Slides für Python unterstützt den [Morph‑Übergang](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), der die sanfte Bewegung von einer Folie zur nächsten animiert. Dieser Abschnitt erklärt, wie Sie den Morph‑Übergang verwenden. Dafür benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Ansatz ist, eine Folie zu duplizieren und das Objekt auf der zweiten Folie an eine andere Position zu verschieben.

Der folgende Codeausschnitt zeigt, wie Sie eine Folie, die Text enthält, klonen und den Morph‑Übergang auf die zweite Folie anwenden.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Clone the first slide to create a second slide with the same shapes for Morph continuity.
    slide1 = presentation.slides.add_clone(slide0)

    # Select the same rectangle on the second slide and change its position and size.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Enable the Morph transition on the second slide to animate the shape changes smoothly.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph‑Übergangstypen**

Das [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/)-Enum repräsentiert die verschiedenen Typen von Morph‑Folienübergängen.

Der folgende Codeausschnitt zeigt, wie Sie einen Morph‑Übergang auf eine Folie anwenden und den Morph‑Typ ändern:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Übergangseffekte festlegen**

Aspose.Slides für Python ermöglicht das Festlegen von Übergangseffekten wie **From Black**, **From Left**, **From Right** usw. So konfigurieren Sie einen Übergangseffekt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Holen Sie eine Referenz zur Folie.
3. Legen Sie den gewünschten Übergangseffekt fest.
4. Speichern Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel setzen wir mehrere Übergangseffekte.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Apply a Cut transition and enable From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Setzen Sie die [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)-Eigenschaft des Übergangs über die [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/)-Einstellung (z. B. slow/medium/fast).

**Kann ich einem Übergang Audio hinzufügen und es wiederholen lassen?**

Ja. Sie können einen Sound für den Übergang einbetten und das Verhalten über Einstellungen wie sound mode und looping steuern (z. B. [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), sowie Metadaten wie [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) und [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Wie setze ich denselben Übergang schnell auf alle Folien?**

Konfigurieren Sie den gewünschten Übergangstyp in den Übergangseinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden desselben Typs auf alle Folien ein konsistentes Ergebnis liefert.

**Wie kann ich prüfen, welcher Übergang aktuell auf einer Folie eingestellt ist?**

Untersuchen Sie die [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) der Folie und lesen Sie deren [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); dieser Wert gibt exakt an, welcher Effekt angewendet wurde.