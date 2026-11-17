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
description: "Wenden Sie Folienübergänge an, konfigurieren Sie das automatische Vorwärtsblättern von Folien und passen Sie Morph und andere Übergangseffekte mit Aspose.Slides für Python via Java an."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Bildschirmpräsentation angezeigt werden. Mit Aspose.Slides für Python via Java können Sie für jede Folie einen Übergangseffekt auswählen, den Fortschritt per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen anpassen. Dieser Artikel verwendet Python‑Beispiele, um Übergänge anzuwenden, genaue Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen außerdem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑Klasse und greifen über [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) auf die Übergabeeinstellungen der Folie zu. Verwenden Sie [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) mit einem Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), und speichern Sie anschließend die Präsentation.

Das folgende Beispiel wendet einen Circle‑Übergang auf die erste Folie und einen Comb‑Übergang auf die zweite an. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

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

## **Wheel‑Übergang**

Verwenden Sie [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType), um Wheel aus [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) auszuwählen. Rufen Sie anschließend [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) auf, um auf die Einstellungen von [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) zuzugreifen. Mit der Methode [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) wird festgelegt, wie viele radiale Segmente die Ziel‑Folie sichtbar machen.

Das Beispiel erstellt zwei identische Folienpaare. Jedes Paar beginnt mit einer schwarzen Folie und endet mit einem goldenen Rechteck, das die gesamte Folie einnimmt. Beide Ziel‑Folien verwenden dieselbe langsame Geschwindigkeit, die mit [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) festgelegt wird, und dieselbe explizite Dauer von 8.000 Millisekunden, die mit [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) gesetzt wird. Nur die Anzahl der Speichen ändert sich.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Öffnen Sie `wheel-transitions.pptx` in PowerPoint und starten Sie die Bildschirmpräsentation. Wechseln Sie von Folie 1 zu Folie 2, um zu sehen, wie ein einzelner im Uhrzeigersinn verlaufender Sweep das goldene Rechteck enthüllt. Wechseln Sie dann von Folie 3 zu Folie 4, um zu sehen, wie acht radiale Segmente das gleiche Rechteck gleichzeitig enthüllen.

## **Erweiterten Folienübergang hinzufügen**

Sie können festlegen, wie lange eine Folie auf dem Bildschirm bleibt und ob ein Mausklick die Bildschirmpräsentation weiterblättert. Die folgenden Methoden steuern dieses Verhalten:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ermöglicht dem Betrachter, durch Klicken der Maus weiterzublättern.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) aktiviert das automatische Vorwärtsblättern.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) gibt die Verzögerung vor dem automatischen Vorwärtsblättern in Millisekunden an.

Aktivieren Sie sowohl Klick‑ als auch Timer‑Fortschritt, damit der Betrachter entweder per Klick weitergeht oder auf den Timer wartet. Um nur den Timer zu verwenden, übergeben Sie `False` an [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Die Verzögerung bestimmt, wann die Bildschirmpräsentation weiterblättert; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert das automatische Vorwärtsblättern nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls weiterblättern. Verwenden Sie eine `input.pptx`‑Datei mit mindestens drei Folien.

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

Um zu prüfen, ob das zeitgesteuerte Vorwärtsblätten aktiviert ist, rufen Sie [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) auf. Ein gespeicherter Verzögerungswert allein zeigt nicht an, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, gibt für jede aktivierte Timer‑Einstellung aus und deaktiviert das automatische Vorwärtsblättern für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien werden Mausklicks aktiviert und die aktualisierten Einstellungen gespeichert.

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

Verwenden Sie [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration), um die genaue Länge eines Übergangseffekts in Millisekunden festzulegen. Die Methode [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie gibt diese Einstellungen über [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) frei:

| Methode | Zweck |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Legt die Dauer des eigentlichen Übergangseffekts in Millisekunden fest. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Legt die Verzögerung fest, bevor die Folie automatisch weiterblättert, in Millisekunden. übergeben Sie `True` an [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter), um diesen Timer zu aktivieren. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium oder Fast. Sie wird verwendet, wenn keine genaue Dauer angegeben ist. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) steuert nur den Übergangseffekt; er bestimmt nicht, wie lange die Folie sichtbar bleibt. Konfigurieren Sie die Verzögerung des automatischen Vorwärtsblätterns separat. Wenn keine explizite Dauer festgelegt ist, ermittelt Aspose.Slides die Effektdauer aus dem Übergangstyp und dem Wert von [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Getrennte Balken zeigen die Übergangsdauer von 750 ms und die automatische Vorwärtsblätter‑Einstellung von 5.000 ms an.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Das gemeinsame Beispiel gibt jeder Folie einen 750‑ms‑Fade‑Übergang und aktiviert separat das automatische Vorwärtsblättern nach 5.000 ms. Die Übergangsdauer steuert den Effekt; das Vorwärtsblättern bestimmt, wann die Folie verlassen wird. Diese Balken sind schematische Einstellungen, kein gemessener Gesamttimeline.*
<!-- visual-explanation:slide-transition:end -->

### **Gleiche Dauer auf jede Folie anwenden**

Für ein gleichmäßiges Tempo wenden Sie denselben Effekt und dieselbe genaue Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert separat das automatische Vorwärtsblättern nach 5.000 Millisekunden und deaktiviert das Vorwärtsblättern per Mausklick, dann speichert es das Ergebnis als PPTX.

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

        # Automatisches Vorwärtsblättern unabhängig von der Effektdauer konfigurieren.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Unterschiedliche Dauern für einzelne Folien festlegen**

Verschiedene Folien können unterschiedliche Effektdauern verwenden. Zum Beispiel kann ein kurzer Übergang für eine Titelfolie und ein längerer Übergang für eine Abschnittseinführung eingesetzt werden. Dieses Beispiel setzt 500 Millisekunden für die erste Folie und 1.200 Millisekunden für die zweite. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

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

Beim Erstellen eines [animated GIF](/slides/de/python-java/convert-powerpoint-to-animated-gif/), einer [HTML5‑Präsentation](/slides/de/python-java/export-to-html5/) oder eines [video](/slides/de/python-java/convert-powerpoint-to-video/), sollten Sie vor dem Export genaue Übergangsdauern festlegen, um das gewünschte Tempo zu erreichen. Verwenden Sie z. B. ein 600‑ms‑Fade zwischen den Szenen und passen Sie die Vorwärtsblätter‑Verzögerung jeder Folie separat an, um Zeit für die Erzählung oder den Inhalt zu lassen.  

Für GIF und Video koordinieren Sie die Ausgabebildrate mit der Effektdauer: 600 ms entsprechen 18 Bilder bei 30 Bilder pro Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Export‑Einstellungen. Prüfen Sie die vom gewählten Exportformat unterstützten Effekte und Zeitoptionen und sehen Sie sich die Ausgabe in der Vorschau an, um die Synchronisation zu bestätigen.

### **Vorhandene Übergangsdauer auslesen**

Rufen Sie [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) auf, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer festgelegt wurde; ein nicht‑negativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides verwendet den Übergangstyp und den Wert von [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed), um diese Dauer zu bestimmen. Das Festlegen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zuerst die ursprünglichen Einstellungen prüfen.

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

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, duplizieren Sie eine Folie, verschieben oder skalieren ein Objekt auf der Kopie und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die entsprechenden Objekte einen Animationspfad zwischen ihrem Original‑ und modifizierten Zustand.

Das folgende Beispiel erstellt eine Folie mit einem Text‑Rechteck, dupliziert die Folie und ändert Position und Größe des Rechtecks in der Kopie. Anschließend wählt es Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) für die zweite Folie. Öffnen Sie die gespeicherte Datei in einem Präsentations‑Viewer, der Morph unterstützt, um den Effekt während einer Bildschirmpräsentation zu sehen.

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

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) steuert, wie Morph Inhalte zuordnet und animiert:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) betrachtet jede Form als gesamtes Objekt.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) animiert Text, indem nach Möglichkeit Wörter abgeglichen werden.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) animiert Text, indem nach Möglichkeit Zeichen abgeglichen werden.

Verwenden Sie [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType), um Morph auszuwählen, bevor Sie [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) aufrufen. Der zurückgegebene Wert ist dann eine Instanz der Klasse [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), deren Methode [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) den Abgleichmodus auswählt.

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

Einige Übergänge bieten zusätzliche Optionen, z. B. Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom mit [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) gewählten Übergang ab. Legen Sie zuerst den Typ fest und verwenden Sie anschließend die passende Klasse aus [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es ruft [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) über [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) auf, sodass der Übergang von einem schwarzen Bildschirm startet.

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

Ja. Verwenden Sie nach Möglichkeit [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration), wenn Sie eine exakte Effektdauer in Millisekunden benötigen. Nutzen Sie [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed), wenn eine vordefinierte Kategorie von [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) : Slow, Medium oder Fast ausreicht und keine explizite Dauer festgelegt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der Verzögerung des automatischen Vorwärtsblätterns.

**Kann ich einem Übergang Audio hinzufügen und es wiederholen lassen?**

Ja. Weisen Sie eingebettetes Audio mit [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound) zu, übergeben Sie StartSound aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) an [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode), und aktivieren Sie [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) mit `True`. Das Audio wiederholt sich, bis das nächste Sound‑Ereignis in der Bildschirmpräsentation eintritt.

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Durchlaufen Sie die [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides)-Sammlung der Präsentation und rufen Sie für jede Folie [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) mit demselben Wert auf. Legen Sie Timing‑ und Effektoptionen im selben Durchlauf fest, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich prüfen, welcher Übergang aktuell für eine Folie eingestellt ist?**

Rufen Sie [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) auf dem Ergebnis von [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie auf. Es gibt einen Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) zurück; None_ bedeutet, dass kein Übergangseffekt angewendet wurde.