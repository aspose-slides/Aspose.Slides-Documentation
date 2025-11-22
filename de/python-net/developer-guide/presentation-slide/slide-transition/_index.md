---
title: Verwalten von Folienübergängen in Präsentationen mit Python
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
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folienübergänge in Aspose.Slides für Python über .NET anpassen, mit schrittweiser Anleitung für PowerPoint- und OpenDocument-Präsentationen."
---

## **Übersicht**

Aspose.Slides for Python bietet vollständige Kontrolle über Folienübergänge, vom Auswählen eines Übergangstyps bis zum Konfigurieren von Timing und Triggern im Rahmen automatisierter Präsentationsabläufe. Sie können Folien so einstellen, dass sie bei einem Klick und/oder nach einer festgelegten Verzögerung weiterblättern und das visuelle Verhalten mit Effekten wie **From Black** oder richtungsabhängigen Eingängen verfeinern. Die Bibliothek unterstützt außerdem den Morph‑Übergang, der mit PowerPoint 2019 eingeführt wurde, einschließlich Modi, die nach Objekt, Wort oder Zeichen morphen, um eine sanfte, zusammenhängende Bewegung zwischen Folien zu erzeugen.

## **Folienübergänge hinzufügen**

Um dies leichter verständlich zu machen, demonstriert dieses Beispiel, wie Aspose.Slides for Python verwendet wird, um einfache Folienübergänge zu verwalten. Entwickler können verschiedene Folienübergangseffekte auf Folien anwenden und ihr Verhalten anpassen. Um einen einfachen Folienübergang zu erstellen, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
1. Wenden Sie einen Folienübergang mit einem der Effekte aus dem [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)‑Enum an.  
1. Speichern Sie die geänderte Präsentationsdatei.  
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um eine Präsentationsdatei zu laden.
with slides.Presentation("sample.pptx") as presentation:
    # Wenden Sie einen Kreis-Übergang auf Folie 1 an.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Wenden Sie einen Kamm-Übergang auf Folie 2 an.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Speichern Sie die Präsentation auf der Festplatte.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Erweiterte Folienübergänge hinzufügen**

In diesem Abschnitt haben wir einen einfachen Übergangseffekt auf eine Folie angewendet. Um diesen Effekt kontrollierter und polierter zu gestalten, führen Sie folgende Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
1. Wenden Sie einen Folienübergang mit einem der Effekte aus dem [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)‑Enum an.  
1. Konfigurieren Sie den Übergang so, dass er **Advance On Click**, nach einer bestimmten Zeit oder beides erfolgt.  
1. Speichern Sie die geänderte Präsentationsdatei.

Ist **Advance On Click** aktiviert, wird die Folie nur beim Klicken des Benutzers weitergeschaltet. Ist die Eigenschaft **Advance After Time** gesetzt, wird die Folie automatisch nach dem angegebenen Intervall weitergeschaltet.  
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um eine Präsentationsdatei zu öffnen.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Wenden Sie einen Kreis‑Übergang auf Folie 1 an.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Aktivieren Sie das Weiterblättern bei Klick und setzen Sie eine automatische Weiterleitung nach 3 Sekunden.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Wenden Sie einen Kamm‑Übergang auf Folie 2 an.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Aktivieren Sie das Weiterblättern bei Klick und setzen Sie eine automatische Weiterleitung nach 5 Sekunden.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Wenden Sie einen Zoom‑Übergang auf Folie 3 an.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Aktivieren Sie das Weiterblättern bei Klick und setzen Sie eine automatische Weiterleitung nach 7 Sekunden.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Speichern Sie die Präsentation auf der Festplatte.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Morph‑Übergang**

Aspose.Slides for Python unterstützt den [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), der die sanfte Bewegung von einer Folie zur nächsten animiert. Dieser Abschnitt erklärt, wie der Morph‑Übergang verwendet wird. Dafür benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Ansatz besteht darin, eine Folie zu duplizieren und das Objekt dann auf der zweiten Folie an eine andere Position zu verschieben.

Der folgende Codeausschnitt zeigt, wie eine Folie, die Text enthält, geklont und der Morph‑Übergang auf die zweite Folie angewendet wird.  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Klonen Sie die erste Folie, um eine zweite Folie mit denselben Formen für die Morph‑Kontinuität zu erstellen.
    slide1 = presentation.slides.add_clone(slide0)

    # Wählen Sie das gleiche Rechteck auf der zweiten Folie aus und ändern Sie dessen Position und Größe.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Aktivieren Sie den Morph‑Übergang auf der zweiten Folie, um die Formänderungen reibungslos zu animieren.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Morph‑Übergangstypen**

Der [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/)‑Enum repräsentiert die verschiedenen Arten von Morph‑Folienübergängen.

Der folgende Codeausschnitt zeigt, wie ein Morph‑Übergang auf eine Folie angewendet und der Morph‑Typ geändert wird:  
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Übergangseffekte festlegen**

Aspose.Slides for Python lässt Sie Übergangseffekte wie **From Black**, **From Left**, **From Right** usw. festlegen. So konfigurieren Sie einen Übergangseffekt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich eine Referenz auf die Folie.  
1. Setzen Sie den gewünschten Übergangseffekt.  
1. Speichern Sie die Präsentation als PPTX‑Datei.

Im folgenden Beispiel setzen wir mehrere Übergangseffekte.  
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um eine Präsentationsdatei zu öffnen.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Wenden Sie einen Cut-Übergang an und aktivieren Sie From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Speichern Sie die Präsentation auf der Festplatte.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Legen Sie die [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) des Übergangs über die Einstellung [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) fest (z. B. slow/medium/fast).

**Kann ich einem Übergang Audio anhängen und es wiederholen lassen?**

Ja. Sie können einen Sound für den Übergang einbetten und das Verhalten über Einstellungen wie sound‑Mode und sound‑Loop steuern (z. B. [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), plus Metadaten wie [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) und [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Wie wende ich denselben Übergang auf alle Folien am schnellsten an?**

Konfigurieren Sie den gewünschten Übergangstyp in den Übergangseinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden desselben Typs auf alle Folien ein konsistentes Ergebnis liefert.

**Wie kann ich prüfen, welcher Übergang derzeit auf einer Folie eingestellt ist?**

Untersuchen Sie die [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) der Folie und lesen Sie deren [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); dieser Wert gibt genau an, welcher Effekt angewendet ist.