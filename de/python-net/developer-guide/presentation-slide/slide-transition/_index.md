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
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folienübergänge in Aspose.Slides für Python via .NET anpassen, mit Schritt‑für‑Schritt‑Anleitungen für PowerPoint‑ und OpenDocument‑Präsentationen."
---

## **Übersicht**

Aspose.Slides für Python bietet vollständige Kontrolle über Folienübergänge – von der Auswahl eines Übergangstyps bis hin zur Konfiguration von Timing und Triggern als Teil automatisierter Präsentations‑Workflows. Sie können Folien so einstellen, dass sie bei einem Klick und/oder nach einer festgelegten Verzögerung weiterlaufen und das visuelle Verhalten mit Effekten wie „Schnitt von Schwarz“ oder richtungsweisenden Eingängen verfeinern. Die Bibliothek unterstützt außerdem den Morph‑Übergang, der in PowerPoint 2019 eingeführt wurde, einschließlich Modi, die nach Objekt, Wort oder Zeichen morphen, um eine flüssige, zusammenhängende Bewegung zwischen Folien zu erzeugen.

## **Folienübergänge hinzufügen**

Um das Verständnis zu erleichtern, demonstriert dieses Beispiel, wie Aspose.Slides für Python einfache Folienübergänge verwaltet. Entwickler können verschiedene Folienübergangseffekte auf Folien anwenden und ihr Verhalten anpassen. So erstellen Sie einen einfachen Folienübergang:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Wenden Sie einen Folienübergang mit einem der Effekte aus dem [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)‑Enum an.
1. Speichern Sie die geänderte Präsentationsdatei.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um eine Präsentationsdatei zu laden.
with slides.Presentation("sample.pptx") as presentation:
    # Wenden Sie einen Kreis‑Übergang auf Folie 1 an.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Wenden Sie einen Kamm‑Übergang auf Folie 2 an.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Erweiterte Folienübergänge hinzufügen**

Im vorherigen Abschnitt haben wir einen einfachen Übergangseffekt auf eine Folie angewendet. Um diesen Effekt kontrollierter und raffinierter zu gestalten, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Wenden Sie einen Folienübergang mit einem der Effekte aus dem [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)‑Enum an.
1. Konfigurieren Sie den Übergang, um bei Klick, nach einer bestimmten Zeit oder beides fortzuschreiten.
1. Speichern Sie die geänderte Präsentationsdatei.

Ist **Advance On Click** (Fortschritt bei Klick) aktiviert, wechselt die Folie nur, wenn der Benutzer klickt. Wird die Eigenschaft **Advance After Time** (Fortschritt nach Zeit) gesetzt, wechselt die Folie automatisch nach dem angegebenen Intervall.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um eine Präsentationsdatei zu öffnen.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Wenden Sie einen Kreis‑Übergang auf Folie 1 an.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Aktivieren Sie den Fortschritt bei Klick und setzen Sie einen 3‑Sekunden‑Auto‑Fortschritt.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Wenden Sie einen Kamm‑Übergang auf Folie 2 an.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Aktivieren Sie den Fortschritt bei Klick und setzen Sie einen 5‑Sekunden‑Auto‑Fortschritt.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Wenden Sie einen Zoom‑Übergang auf Folie 3 an.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Aktivieren Sie den Fortschritt bei Klick und setzen Sie einen 7‑Sekunden‑Auto‑Fortschritt.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph-Übergang**

Aspose.Slides für Python unterstützt den [Morph‑Übergang](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), der die glatte Bewegung von einer Folie zur nächsten animiert. Dieser Abschnitt erklärt die Nutzung des Morph‑Übergangs. Dafür benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Ansatz besteht darin, eine Folie zu duplizieren und das Objekt auf der zweiten Folie an eine andere Position zu verschieben.

Der nachfolgende Codeausschnitt zeigt, wie Sie eine Folie mit Text klonen und einen Morph‑Übergang auf die zweite Folie anwenden.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph-Übergang in PowerPoint-Präsentationen"

    # Klonen Sie die erste Folie, um eine zweite Folie mit denselben Formen für die Morph‑Kontinuität zu erstellen.
    slide1 = presentation.slides.add_clone(slide0)

    # Wählen Sie das gleiche Rechteck auf der zweiten Folie aus und ändern Sie Position und Größe.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Aktivieren Sie den Morph‑Übergang auf der zweiten Folie, um die Formänderungen flüssig zu animieren.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph-Übergangstypen**

Das [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/)‑Enum repräsentiert die verschiedenen Typen von Morph‑Folienübergängen.

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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz zur Folie.
1. Setzen Sie den gewünschten Übergangseffekt.
1. Speichern Sie die Präsentation als PPTX‑Datei.

Im folgenden Beispiel setzen wir mehrere Übergangseffekte.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um eine Präsentationsdatei zu öffnen.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Wenden Sie einen Schnitt‑Übergang an und aktivieren Sie From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Setzen Sie die [Geschwindigkeit](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) des Übergangs über die Einstellung [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (z. B. langsam/mittel/schnell).

**Kann ich einer Übergangsanimation Audio hinzufügen und es wiederholen lassen?**

Ja. Sie können einen Sound für den Übergang einbetten und das Verhalten über Einstellungen wie Sound‑Modus und Schleifen steuern (z. B. [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), sowie Metadaten wie [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) und [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Konfigurieren Sie den gewünschten Übergangstyp in den Übergangseinstellungen jeder Folie; Übergänge werden pro Folie gespeichert, sodass das Anwenden des gleichen Typs auf alle Folien ein konsistentes Ergebnis liefert.

**Wie kann ich prüfen, welcher Übergang aktuell auf einer Folie eingestellt ist?**

Untersuchen Sie die [Übergangseinstellungen](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) der Folie und lesen Sie deren [Übergangstyp](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); dieser Wert gibt exakt an, welcher Effekt angewendet wurde.