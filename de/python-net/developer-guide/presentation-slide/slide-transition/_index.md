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
- Morph‑Übergang
- Übergangstyp
- Übergangseffekt
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folienübergänge in Aspose.Slides für Python über .NET anpassen können, mit Schritt‑für‑Schritt‑Anleitungen für PowerPoint‑ und OpenDocument‑Präsentationen."
---

## **Übersicht**

Aspose.Slides für Python bietet vollständige Kontrolle über Folienübergänge, vom Auswählen eines Übergangstyps bis zum Konfigurieren von Timing und Triggern im Rahmen automatisierter Präsentationsabläufe. Sie können Folien so einstellen, dass sie bei einem Klick und/oder nach einer festgelegten Verzögerung weiterblättern und das visuelle Verhalten mit Effekten wie dem Ausschneiden von Schwarz oder gerichteten Eingängen verfeinern. Die Bibliothek unterstützt außerdem den in PowerPoint 2019 eingeführten Morph‑Übergang, einschließlich Modi, die nach Objekt, Wort oder Zeichen morphieren, um eine glatte, zusammenhängende Bewegung zwischen Folien zu erzeugen.

## **Folienübergänge hinzufügen**

Um dies leichter verständlich zu machen, zeigt dieses Beispiel, wie Aspose.Slides für Python verwendet wird, um einfache Folienübergänge zu verwalten. Entwickler können verschiedene Folienübergangseffekte auf Folien anwenden und deren Verhalten anpassen. Um einen einfachen Folienübergang zu erstellen, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Wenden Sie einen Folienübergang an, indem Sie einen der Effekte aus dem [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) Enum verwenden.
3. Speichern Sie die geänderte Präsentationsdatei.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um eine Präsentationsdatei zu laden.
with slides.Presentation("sample.pptx") as presentation:
    # Wenden Sie einen Kreis-Übergang auf Folie 1 an.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Wenden Sie einen Kamm-Übergang auf Folie 2 an.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Erweiterte Folienübergänge hinzufügen**

In diesem Abschnitt haben wir einen einfachen Übergangseffekt auf eine Folie angewendet. Um diesen Effekt kontrollierter und verfeinerter zu gestalten, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Wenden Sie einen Folienübergang an, indem Sie einen der Effekte aus dem [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) Enum verwenden.
3. Konfigurieren Sie den Übergang so, dass er bei Klick weitergeht, nach einem bestimmten Zeitraum oder beides.
4. Speichern Sie die geänderte Präsentationsdatei.

Wenn **Advance On Click** aktiviert ist, wird die Folie nur weitergeschaltet, wenn der Benutzer klickt. Ist die Eigenschaft **Advance After Time** gesetzt, wird die Folie nach dem angegebenen Intervall automatisch weitergeschaltet.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um eine Präsentationsdatei zu öffnen.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Wenden Sie einen Kreis-Übergang auf Folie 1 an.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Aktivieren Sie das Weiterblättern bei Klick und setzen Sie ein automatisches Weiterblättern nach 3 Sekunden.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Wenden Sie einen Kamm-Übergang auf Folie 2 an.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Aktivieren Sie das Weiterblättern bei Klick und setzen Sie ein automatisches Weiterblättern nach 5 Sekunden.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Wenden Sie einen Zoom-Übergang auf Folie 3 an.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Aktivieren Sie das Weiterblättern bei Klick und setzen Sie ein automatisches Weiterblättern nach 7 Sekunden.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Morph-Übergang**

Aspose.Slides für Python unterstützt den [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), der die flüssige Bewegung von einer Folie zur nächsten animiert. Dieser Abschnitt erklärt, wie der Morph‑Übergang verwendet wird. Um ihn effektiv zu nutzen, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Ansatz besteht darin, eine Folie zu duplizieren und das Objekt dann auf der zweiten Folie an eine andere Position zu verschieben.

Das folgende Codebeispiel zeigt, wie eine Folie, die Text enthält, geklont und ein Morph‑Übergang auf die zweite Folie angewendet wird.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Klonen Sie die erste Folie, um eine zweite Folie mit denselben Formen für die Morph-Kontinuität zu erstellen.
    slide1 = presentation.slides.add_clone(slide0)

    # Wählen Sie das gleiche Rechteck auf der zweiten Folie aus und ändern Sie dessen Position und Größe.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Aktivieren Sie den Morph-Übergang auf der zweiten Folie, um die Formänderungen glatt zu animieren.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Morph-Übergangstypen**

Das [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) Enum repräsentiert die verschiedenen Typen von Morph‑Folienübergängen.

Das folgende Codebeispiel zeigt, wie ein Morph‑Übergang auf eine Folie angewendet und der Morph‑Typ geändert wird:
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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie eine Referenz zur Folie.
3. Legen Sie den gewünschten Übergangseffekt fest.
4. Speichern Sie die Präsentation als PPTX‑Datei.

Im folgenden Beispiel setzen wir mehrere Übergangseffekte.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um eine Präsentationsdatei zu öffnen.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Wenden Sie einen Cut-Übergang an und aktivieren Sie From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Setzen Sie die [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) des Übergangs über die [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) Einstellung (z. B. slow/medium/fast).

**Kann ich einer Transition Audio anhängen und es in einer Schleife wiedergeben?**

Ja. Sie können einen Sound für den Übergang einbetten und das Verhalten über Einstellungen wie [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) steuern, plus Metadaten wie [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) und [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/).

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Konfigurieren Sie den gewünschten Übergangstyp in den Übergangseinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden desselben Typs auf alle Folien ein konsistentes Ergebnis liefert.

**Wie kann ich prüfen, welcher Übergang derzeit auf einer Folie eingestellt ist?**

Untersuchen Sie die [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) der Folie und lesen Sie deren [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); dieser Wert gibt genau an, welcher Effekt angewendet wird.