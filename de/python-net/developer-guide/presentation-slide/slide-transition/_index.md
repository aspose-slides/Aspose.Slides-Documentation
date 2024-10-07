---
title: Folienübergang
type: docs
weight: 90
url: /python-net/slide-transition/
keywords: "Folienübergang hinzufügen, PowerPoint-Folienübergang, Morphübergang, erweiterte Folienübergänge, Übergangseffekte, Python, Aspose.Slides"
description: "Folienübergang und Übergangseffekte in Python hinzufügen"
---

## **Folienübergang hinzufügen**
Um das Verständnis zu erleichtern, haben wir die Verwendung von Aspose.Slides für Python über .NET zum Verwalten einfacher Folienübergänge demonstriert. Entwickler können nicht nur verschiedene Folienübergangseffekte auf die Folien anwenden, sondern auch das Verhalten dieser Übergangseffekte anpassen. Um einen einfachen Folienübergangseffekt zu erstellen, befolgen Sie die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie aus einem der von Aspose.Slides für Python über .NET angebotenen Übergangseffekte über das TransitionType-Enum an.
1. Schreiben Sie die modifizierte Präsentationsdatei.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Wenden Sie den Übergangstyp "Kreis" auf Folie 1 an
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Wenden Sie den Übergangstyp "Kamm" auf Folie 2 an
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Schreiben Sie die Präsentation auf die Festplatte
    presentation.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Erweiterter Folienübergang hinzufügen**
Im obigen Abschnitt haben wir nur einen einfachen Übergangseffekt auf die Folie angewendet. Um diesen einfachen Übergangseffekt noch besser und kontrollierbarer zu machen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Wenden Sie einen Folienübergangstyp auf die Folie aus einem der von Aspose.Slides für Python über .NET angebotenen Übergangseffekte an.
1. Sie können den Übergang auch auf "Nach Klick fortfahren", nach einem bestimmten Zeitraum oder beides einstellen.
1. Wenn der Folienübergang auf "Nach Klick fortfahren" aktiviert ist, wird der Übergang nur fortgesetzt, wenn jemand mit der Maus klickt. Darüber hinaus wird, wenn die Eigenschaft "Nach Zeit fortfahren" festgelegt ist, der Übergang automatisch fortgesetzt, nachdem die angegebene Zeit vergangen ist.
1. Schreiben Sie die modifizierte Präsentation als Präsentationsdatei.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
with slides.Presentation(path + "BetterSlideTransitions.pptx") as pres:
    # Wenden Sie den Übergangstyp "Kreis" auf Folie 1 an
    pres.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE


    # Legen Sie die Übergangszeit auf 3 Sekunden fest
    pres.slides[0].slide_show_transition.advance_on_click = True
    pres.slides[0].slide_show_transition.advance_after_time = 3000

    # Wenden Sie den Übergangstyp "Kamm" auf Folie 2 an
    pres.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB


    # Legen Sie die Übergangszeit auf 5 Sekunden fest
    pres.slides[1].slide_show_transition.advance_on_click = True
    pres.slides[1].slide_show_transition.advance_after_time = 5000

    # Wenden Sie den Übergangstyp "Zoom" auf Folie 3 an
    pres.slides[2].slide_show_transition.type = slides.slideshow.TransitionType.ZOOM


    # Legen Sie die Übergangszeit auf 7 Sekunden fest
    pres.slides[2].slide_show_transition.advance_on_click = True
    pres.slides[2].slide_show_transition.advance_after_time = 7000

    # Schreiben Sie die Präsentation auf die Festplatte
    pres.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Morphübergang**
Aspose.Slides für Python über .NET unterstützt jetzt den [Morphübergang](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/). Er stellt einen neuen Morphübergang dar, der in PowerPoint 2019 eingeführt wurde. Der Morphübergang ermöglicht es Ihnen, eine sanfte Bewegung von einer Folie zur nächsten zu animieren. Dieser Artikel beschreibt das Konzept und die Verwendung des Morphübergangs. Um den Morphübergang effektiv zu nutzen, benötigen Sie zwei Folien mit mindestens einem gemeinsamen Objekt. Der einfachste Weg besteht darin, die Folie zu duplizieren und das Objekt auf der zweiten Folie an einen anderen Ort zu verschieben.

Der folgende Codeausschnitt zeigt Ihnen, wie Sie einen Klon der Folie mit etwas Text zur Präsentation hinzufügen und einen Übergang vom [morph-Typ](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/) zur zweiten Folie setzen.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoshape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    autoshape.text_frame.text = "Morphübergang in PowerPoint-Präsentationen"

    presentation.slides.add_clone(presentation.slides[0])

    presentation.slides[1].shapes[0].x += 100
    presentation.slides[1].shapes[0].y += 50
    presentation.slides[1].shapes[0].width -= 200
    presentation.slides[1].shapes[0].height -= 10

    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **Morphübergangsarten**
Das neue [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) Enum wurde hinzugefügt. Es repräsentiert verschiedene Arten von Morph-Folienübergängen.

Das TransitionMorphType-Enum hat drei Mitglieder:

- ByObject: Der Morphübergang wird unter Berücksichtigung der Formen als unteilbare Objekte ausgeführt.
- ByWord: Der Morphübergang wird mit dem Übertragen von Text nach Wörtern durchgeführt, wo möglich.
- ByChar: Der Morphübergang wird mit dem Übertragen von Text nach Zeichen durchgeführt, wo möglich.

Der folgende Codeausschnitt zeigt Ihnen, wie Sie den Morphübergang auf die Folie setzen und den Morph-Typ ändern:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    presentation.slides[0].slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **Übergangseffekte festlegen**
Aspose.Slides für Python über .NET unterstützt das Festlegen von Übergangseffekten wie von schwarz, von links, von rechts usw. Um den Übergangseffekt festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)Klasse.
- Holen Sie sich die Referenz der Folie.
- Festlegen des Übergangseffekts.
- Schreiben Sie die Präsentation als [PPTX ](https://docs.fileformat.com/presentation/pptx/)Datei.

Im folgenden Beispiel haben wir die Übergangseffekte festgelegt.

```py
import aspose.slides as slides

# Erstellen Sie eine Instanz der Presentation-Klasse
with slides.Presentation(path + "AccessSlides.pptx") as presentation:

    # Effekt festlegen
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CUT
    presentation.slides[0].slide_show_transition.value.from_black = True

    # Schreiben Sie die Präsentation auf die Festplatte
    presentation.save("SetTransitionEffects_out.pptx", slides.export.SaveFormat.PPTX)
```