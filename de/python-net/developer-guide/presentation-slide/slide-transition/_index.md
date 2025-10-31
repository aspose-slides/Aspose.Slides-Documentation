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
- Python
- Aspose.Slides
description: "Entdecken Sie, wie Sie Folienübergänge in Aspose.Slides für Python via .NET anpassen, mit Schritt-für-Schritt-Anleitung für PowerPoint‑ und OpenDocument‑Präsentationen."
---

## **Übersicht**

Aspose.Slides für Python bietet vollständige Kontrolle über Folienübergänge, von der Auswahl eines Übergangstyps bis zur Konfiguration von Timing und Triggern im Rahmen automatisierter Präsentations‑Workflows. Sie können Folien so festlegen, dass sie bei einem Klick und/oder nach einer angegebenen Verzögerung fortschreiten und das visuelle Verhalten mit Effekten wie Schwarz‑Ausschnitten oder gerichteten Einstiegen verfeinern. Die Bibliothek unterstützt außerdem den Morph‑Übergang, der mit PowerPoint 2019 eingeführt wurde, einschließlich Modi, die nach Objekt, Wort oder Zeichen morphen, um eine sanfte, zusammenhängende Bewegung zwischen Folien zu erzeugen.

## **Folienübergänge hinzufügen**

Um das einfacher zu verstehen, demonstriert dieses Beispiel, wie Sie Aspose.Slides für Python verwenden, um einfache Folienübergänge zu verwalten. Entwickler können unterschiedliche Folienübergangseffekte auf Folien anwenden und deren Verhalten anpassen. Um einen einfachen Folienübergang zu erstellen, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Wenden Sie einen Folienübergang mit einem der Effekte aus dem [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)-Enum an.
1. Speichern Sie die geänderte Präsentationsdatei.

```py
import aspose.slides as slides

# Instanziieren der Presentation‑Klasse, um eine Präsentationsdatei zu laden.
with slides.Presentation("sample.pptx") as presentation:
    # Kreis‑Übergang auf Folie 1 anwenden.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Kamm‑Übergang auf Folie 2 anwenden.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Präsentation auf die Festplatte speichern.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Erweiterte Folienübergänge hinzufügen**

In diesem Abschnitt haben wir einen einfachen Übergangseffekt auf eine Folie angewendet. Um diesen Effekt kontrollierter und polierter zu gestalten, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Wenden Sie einen Folienübergang mit einem der Effekte aus dem [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)-Enum an.
1. Konfigurieren Sie den Übergang, sodass er bei Klick, nach einer bestimmten Zeit oder beides fortschreitet.
1. Speichern Sie die geänderte Präsentationsdatei.

Wenn **Advance On Click** aktiviert ist, läuft die Folie nur bei einem Klick des Benutzers weiter. Ist die **Advance After Time**‑Eigenschaft gesetzt, springt die Folie nach dem angegebenen Intervall automatisch weiter.

```py
import aspose.slides as slides

# Instanziieren der Presentation‑Klasse, um eine Präsentationsdatei zu öffnen.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Kreis‑Übergang auf Folie 1 anwenden.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Fortschritt bei Klick aktivieren und 3‑Sekunden‑Auto‑Fortschritt festlegen.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Kamm‑Übergang auf Folie 2 anwenden.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Fortschritt bei Klick aktivieren und 5‑Sekunden‑Auto‑Fortschritt festlegen.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Zoom‑Übergang auf Folie 3 anwenden.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Fortschritt bei Klick aktivieren und 7‑Sekunden‑Auto‑Fortschritt festlegen.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Präsentation auf die Festplatte speichern.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph‑Übergang**

Aspose.Slides für Python unterstützt den [Morph‑Übergang](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), der eine sanfte Bewegung von einer Folie zur nächsten animiert. Dieser Abschnitt erklärt, wie Sie den Morph‑Übergang verwenden. Um ihn effektiv zu nutzen, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Ansatz ist, eine Folie zu duplizieren und das Objekt dann auf der zweiten Folie an eine andere Position zu verschieben.

Der folgende Codeausschnitt zeigt, wie man eine Folie, die Text enthält, klont und den Morph‑Übergang auf die zweite Folie anwendet.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Klonen der ersten Folie, um eine zweite Folie mit denselben Formen für Morph‑Kontinuität zu erstellen.
    slide1 = presentation.slides.add_clone(slide0)

    # Das gleiche Rechteck auf der zweiten Folie auswählen und seine Position und Größe ändern.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Morph‑Übergang auf der zweiten Folie aktivieren, um die Formänderungen flüssig zu animieren.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph‑Übergangstypen**

Das [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/)-Enum repräsentiert die verschiedenen Typen von Morph‑Folienübergängen.

Der folgende Codeausschnitt zeigt, wie man einen Morph‑Übergang auf eine Folie anwendet und den Morph‑Typ ändert:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Übergangseffekte festlegen**

Aspose.Slides für Python ermöglicht das Festlegen von Übergangseffekten wie **From Black**, **From Left**, **From Right** usw. Um einen Übergangseffekt zu konfigurieren, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz zur Folie.
1. Setzen Sie den gewünschten Übergangseffekt.
1. Speichern Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel setzen wir mehrere Übergangseffekte.

```py
import aspose.slides as slides

# Instanziieren der Presentation‑Klasse, um eine Präsentationsdatei zu öffnen.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Schnitt‑Übergang anwenden und Von‑Schwarz aktivieren.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Präsentation auf die Festplatte speichern.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Stellen Sie die [Geschwindigkeit](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) des Übergangs über die Einstellung [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) ein (z. B. langsam/mittel/schnell).

**Kann ich einem Übergang Audio anhängen und es wiederholen lassen?**

Ja. Sie können einen Ton für den Übergang einbetten und das Verhalten über Einstellungen wie Sound‑Modus und Wiederholung steuern (z. B. [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), sowie Metadaten wie [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) und [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Was ist der schnellste Weg, denselben Übergang auf alle Folien anzuwenden?**

Konfigurieren Sie den gewünschten Übergangstyp in den Übergangseinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden desselben Typs auf alle Folien ein konsistentes Ergebnis liefert.

**Wie kann ich überprüfen, welcher Übergang derzeit auf einer Folie eingestellt ist?**

Untersuchen Sie die [Übergangseinstellungen](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) der Folie und lesen Sie deren [Übergangstyp](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); dieser Wert gibt genau an, welcher Effekt angewendet wurde.