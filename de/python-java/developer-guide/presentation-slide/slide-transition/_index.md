---
title: Verwalten von Folienübergängen in Präsentationen mit Python via Java
linktitle: Folienübergang
type: docs
weight: 80
url: /de/python-java/slide-transition/
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
- Java
- Aspose.Slides
description: "Wenden Sie Folienübergänge an, konfigurieren Sie das automatische Voranschreiten der Folien und passen Sie Morph- und andere Übergangseffekte mit Aspose.Slides für Python via Java an."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Bildschirmpräsentation angezeigt werden. Mit Aspose.Slides für Python via Java können Sie für jede Folie einen Übergangseffekt auswählen, den Fortschritt per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen für einen Effekt anpassen. Dieser Artikel verwendet Python‑Beispiele, um Übergänge anzuwenden, genaue Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen außerdem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und greifen über [getSlideShowTransition](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getSlideShowTransition) auf die Übergangseinstellungen der Folie zu. Verwenden Sie [setType](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setType) mit einem Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/python-java/aspose.slides/transitiontype/), und speichern Sie anschließend die Präsentation.

Das folgende Beispiel wendet einen Circle‑Übergang auf die erste Folie und einen Comb‑Übergang auf die zweite Folie an. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Erweiterten Folienübergang hinzufügen**

Sie können festlegen, wie lange eine Folie auf dem Bildschirm bleibt und ob ein Mausklick die Bildschirmpräsentation fortsetzt. Die folgenden Methoden steuern dieses Verhalten:

- [setAdvanceOnClick](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ermöglicht dem Betrachter, durch Klicken der Maus fortzuschalten.
- [setAdvanceAfter](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) aktiviert das automatische Voranschreiten.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) gibt die Verzögerung vor dem automatischen Voranschalten in Millisekunden an.

Aktivieren Sie sowohl das Klicken als auch den zeitgesteuerten Fortschritt, damit der Betrachter entweder per Klick weitergeht oder auf den Timer wartet. Um nur den Timer zu verwenden, übergeben Sie `False` an [setAdvanceOnClick](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Die Verzögerung steuert, wann die Präsentation fortschreitet; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert das automatische Voranschreiten nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls vorwärts schalten. Verwenden Sie eine `input.pptx`‑Datei mit mindestens drei Folien.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

Um zu prüfen, ob das zeitgesteuerte Voranschreiten aktiviert ist, rufen Sie [getAdvanceAfter](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) auf. Ein gespeicherter Delay allein bedeutet nicht, dass der Timer aktiv ist.

Das folgende Beispiel öffnet die oben gespeicherte Datei, meldet jeden aktivierten Timer und deaktiviert das automatische Voranschreiten für Folien mit einer Verzögerung von mehr als zwei Sekunden. Es aktiviert Mausklicks für diese Folien und speichert die aktualisierten Einstellungen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Übergangszeit exakt steuern**

Verwenden Sie [setDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setDuration), um die genaue Länge eines Übergangseffekts in Millisekunden festzulegen. Die Methode [getSlideShowTransition](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie stellt diese Einstellungen über [SlideShowTransition](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/) bereit:

| Methode | Zweck |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setDuration) | Legt die Dauer des Übergangseffekts selbst in Millisekunden fest. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Legt die Verzögerung fest, bevor die Folie automatisch voranschreitet, in Millisekunden. Übergeben Sie `True` an [setAdvanceAfter](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter), um diesen Timer zu aktivieren. |
| [setSpeed](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setSpeed) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/de/python-java/aspose.slides/transitionspeed/): Slow, Medium oder Fast. Sie wird verwendet, wenn keine genaue Dauer angegeben ist. |

[setDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setDuration) steuert nur den Übergangseffekt; sie legt nicht fest, wie lange die Folie sichtbar bleibt. Konfigurieren Sie die automatische Voranschreitungsverzögerung separat. Wenn keine explizite Dauer festgelegt ist, ermittelt Aspose.Slides die Effektdauer aus dem Übergangstyp und dem Wert von [getSpeed](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#getSpeed).

### **Gleiche Dauer auf jede Folie anwenden**

Für ein gleichmäßiges Tempo wenden Sie für jede Folie denselben Effekt und dieselbe genaue Dauer an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/de/python-java/aspose.slides/transitiontype/) und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert separat das automatische Voranschreiten nach 5.000 Millisekunden und deaktiviert das Voranschreiten per Mausklick, anschließend wird das Ergebnis als PPTX gespeichert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Automatisches Voranschreiten unabhängig von der Effektdauer konfigurieren.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Unterschiedliche Dauern für einzelne Folien festlegen**

Verschiedene Folien können unterschiedliche Effektzeiten verwenden. Zum Beispiel einen kurzen Übergang für eine Titelfolie und einen längeren Übergang für eine Abschnittseinführung. Dieses Beispiel legt 500 Millisekunden für die erste Folie und 1.200 Millisekunden für die zweite fest. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Übergänge mit animierter Ausgabe koordinieren**

Wenn Sie ein [animiertes GIF](/slides/de/python-java/convert-powerpoint-to-animated-gif/), eine [HTML5-Präsentation](/slides/de/python-java/export-to-html5/) oder ein [Video](/slides/de/python-java/convert-powerpoint-to-video/) vorbereiten, setzen Sie genaue Übergangsdauern vor dem Export, um das gewünschte Tempo zu erreichen. Verwenden Sie beispielsweise ein 600‑Millisekunden‑Fade zwischen Szenen und passen Sie die Voranschreitungsverzögerung jeder Folie separat an, um Zeit für die Erzählung oder den Inhalt zu lassen.

Für GIF und Video koordinieren Sie die Ausgaberate mit der Effektdauer: 600 Millisekunden entsprechen 18 Bildern bei 30 Bildern pro Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Exporteinstellungen. Prüfen Sie die unterstützten Effekte und Timing‑Optionen des gewählten Exportformats und sehen Sie sich eine Vorschau an, um die Synchronisation zu bestätigen.

### **Bestehende Übergangsdauer auslesen**

Rufen Sie [getDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#getDuration) auf, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer festgelegt ist; ein nichtnegativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides verwendet den Übergangstyp und den Wert von [getSpeed](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#getSpeed), um diese Dauer zu bestimmen. Das Festlegen eines Übergangstyps kann eine Dauer initialisieren, prüfen Sie daher zuerst die ursprünglichen Einstellungen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Morph‑Übergang**

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, duplizieren Sie eine Folie, verschieben oder skalieren ein Objekt auf der Kopie und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die entsprechenden Objekte einen Animationspfad zwischen ihrem ursprünglichen und modifizierten Zustand.

Das folgende Beispiel erstellt eine Folie mit einem Textrechteck, dupliziert die Folie und ändert die Position und Größe des Rechtecks in der Kopie. Anschließend wählt es Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/python-java/aspose.slides/transitiontype/) für die zweite Folie aus. Öffnen Sie die gespeicherte Datei in einem Präsentationsviewer, der Morph unterstützt, um den Effekt während einer Bildschirmpräsentation zu sehen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Morph‑Übergangstypen**

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/de/python-java/aspose.slides/transitionmorphtype/) steuert, wie Morph Inhalte abgleicht und animiert:

- [ByObject](https://reference.aspose.com/slides/de/python-java/aspose.slides/transitionmorphtype/#ByObject) behandelt jede Form als ein komplettes Objekt.
- [ByWord](https://reference.aspose.com/slides/de/python-java/aspose.slides/transitionmorphtype/#ByWord) animiert Text, indem nach Möglichkeit Wörter abgeglichen werden.
- [ByChar](https://reference.aspose.com/slides/de/python-java/aspose.slides/transitionmorphtype/#ByChar) animiert Text, indem nach Möglichkeit Zeichen abgeglichen werden.

Verwenden Sie [setType](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setType), um Morph auszuwählen, bevor Sie [getValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#getValue) aufrufen. Der zurückgegebene Wert ist dann eine Instanz der Klasse [MorphTransition](https://reference.aspose.com/slides/de/python-java/aspose.slides/morphtransition/), deren Methode [setMorphType](https://reference.aspose.com/slides/de/python-java/aspose.slides/morphtransition/#setMorphType) den Abgleichmodus auswählt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Übergangseffekte festlegen**

Einige Übergänge bieten zusätzliche Optionen, z. B. Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom mit [setType](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setType) gewählten Übergang ab. Legen Sie zuerst den Typ fest und verwenden Sie dann die passende Klasse aus [getValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#getValue).

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es ruft [setFromBlack](https://reference.aspose.com/slides/de/python-java/aspose.slides/optionalblacktransition/#setFromBlack) über [OptionalBlackTransition](https://reference.aspose.com/slides/de/python-java/aspose.slides/optionalblacktransition/) auf, damit der Übergang von einem schwarzen Bildschirm startet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Verwenden Sie [setDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setDuration), wenn Sie eine genaue Effektdauer in Millisekunden benötigen. Nutzen Sie [setSpeed](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setSpeed), wenn eine vordefinierte Kategorie aus [TransitionSpeed](https://reference.aspose.com/slides/de/python-java/aspose.slides/transitionspeed/) – Slow, Medium oder Fast – ausreicht und keine explizite Dauer festgelegt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der automatischen Voranschreitungsverzögerung.

**Kann ich einer Transition Audio anhängen und es wiederholen lassen?**

Ja. Weisen Sie eingebettetes Audio mit [setSound](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setSound) zu, übergeben Sie StartSound aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/transitionsoundmode/) an [setSoundMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setSoundMode), und aktivieren Sie [setSoundLoop](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setSoundLoop) mit `True`. Das Audio wiederholt sich, bis das nächste Tonevent in der Präsentation eintritt.

**Wie kann ich am schnellsten denselben Übergang auf jede Folie anwenden?**

Durchlaufen Sie die [getSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlides)-Sammlung der Präsentation und rufen Sie für jeden Folienübergang [setType](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#setType) mit demselben Wert auf. Legen Sie alle Timing‑ und Effektoptionen im selben Durchlauf fest, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich prüfen, welcher Übergang derzeit auf einer Folie eingestellt ist?**

Rufen Sie [getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideshowtransition/#getType) auf dem Ergebnis von [getSlideShowTransition](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie auf. Es gibt einen Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/python-java/aspose.slides/transitiontype/) zurück; None_ bedeutet, dass kein Übergangseffekt angewendet ist.