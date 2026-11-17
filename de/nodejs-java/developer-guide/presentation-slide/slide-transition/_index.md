---
title: Folienübergänge in Präsentationen mit JavaScript verwalten
linktitle: Folienübergang
type: docs
weight: 80
url: /de/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Wenden Sie Folienübergänge an, konfigurieren Sie das automatische Weiterblättern von Folien und passen Sie Morph und andere Übergangseffekte mit Aspose.Slides für Node.js über Java an."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Bildschirmpräsentation angezeigt werden. Mit Aspose.Slides für Node.js über Java können Sie für jede Folie einen Übergangseffekt auswählen, das Weiterblättern per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen für einen Effekt anpassen. Dieser Artikel verwendet JavaScript‑Beispiele, um Übergänge anzuwenden, genaue Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen zudem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse und greifen über [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) auf die Übergangseinstellungen der Folie zu. Verwenden Sie [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) mit einem Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) und speichern Sie anschließend die Präsentation.

Das folgende Beispiel wendet einen Circle‑Übergang auf die erste Folie und einen Comb‑Übergang auf die zweite Folie an. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Rad‑Übergang**

Die Methode [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) von [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) steuert die Anzahl der radialen Sektoren, die die Ziel‑Folien enthüllen. Setzen Sie den Übergangstyp der Folie auf Wheel aus [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) mithilfe von [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType), bevor Sie über [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) als [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) darauf zugreifen.

Dieses Beispiel erstellt zwei identische Folienpaare: eine schwarze Folie, gefolgt von einer Folie mit einem goldenen Rechteck. Die Ziel‑Folien verwenden Schlitzzahlen von 1 bzw. 8, wobei dieselbe Geschwindigkeit über [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) festgelegt wird und eine explizite Dauer von 8.000 Millisekunden über [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) gesetzt wird, um den Unterschied leicht zu erkennen.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Öffnen Sie die Ausgabedatei in PowerPoint und starten Sie die Bildschirmpräsentation. Wechseln Sie von Folie 1 zu Folie 2 und anschließend von Folie 3 zu Folie 4. In der PowerPoint‑Wiedergabe enthüllt die bestätigte Schlitzzahl 1 die Folie mit einem einzigen im Uhrzeigersinn verlaufenden Sweep; die bestätigte Zahl 8 enthüllt sie durch acht radiale Sektoren gleichzeitig. Inhalt und Übergangszeit der Ziel‑Folien sind identisch, daher liegt der Unterschied in der Anzahl der Enthüllungs‑Sektoren.

## **Erweiterte Folienübergänge hinzufügen**

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ermöglicht dem Betrachter, durch Mausklick weiterzugehen.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) aktiviert das automatische Weiterblättern.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) gibt die Verzögerung vor dem automatischen Weiterblättern in Millisekunden an.

Ermöglichen Sie sowohl das Klicken als auch das zeitgesteuerte Weiterblättern, damit der Betrachter entweder per Klick fortfahren oder auf den Timer warten kann. Um nur den Timer zu verwenden, übergeben Sie `false` an [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Die Verzögerung steuert, wann die Präsentation weitergeht; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert das automatische Weiterblättern nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls weiterführen. Verwenden Sie eine `input.pptx`‑Datei mit mindestens drei Folien.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Um zu prüfen, ob das zeitgesteuerte Weiterblättern aktiviert ist, rufen Sie [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) auf. Eine gespeicherte Verzögerung allein weist nicht darauf hin, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, meldet jeden aktivierten Timer und deaktiviert das automatische Weiterblättern für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien werden Mausklicks aktiviert und die aktualisierten Einstellungen gespeichert.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Übergangszeiten exakt steuern**

Verwenden Sie [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration), um die genaue Länge eines Übergangseffekts in Millisekunden anzugeben. Die Methode [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie stellt diese Einstellungen über [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/) bereit:

| Methode | Zweck |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Legt die Dauer des eigentlichen Übergangseffekts in Millisekunden fest. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Legt die Verzögerung fest, bevor die Folie automatisch weitergeht, in Millisekunden. Übergeben Sie `true` an [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter), um diesen Timer zu aktivieren. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium oder Fast. Sie wird verwendet, wenn keine exakte Dauer angegeben ist. |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) steuert nur den Übergangseffekt; sie legt nicht fest, wie lange die Folie sichtbar bleibt. Konfigurieren Sie die Verzögerung für das automatische Weiterblättern separat. Wenn keine explizite Dauer festgelegt ist, ermittelt Aspose.Slides die Dauer des Effekts aus dem Übergangstyp und dem Wert von [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Separate Balken zeigen die 750‑ms Übergangsdauer und die 5.000‑ms Einstellung für das automatische Weiterblättern.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Das gemeinsame Beispiel gibt jeder Folie einen 750‑ms‑Fade‑Übergang und aktiviert separat das automatische Weiterblättern nach 5.000 ms. Die Übergangsdauer steuert den Effekt; das Weiterblättern bestimmt, wann die Folie verlassen wird. Diese Balken stellen schematische Einstellungen dar, keinen gemessenen kombinierten Zeitplan.*
<!-- visual-explanation:slide-transition:end -->

### **Gleiche Dauer auf alle Folien anwenden**

Für ein gleichmäßiges Tempo wendet man denselben Effekt und dieselbe genaue Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert separat das automatische Weiterblättern nach 5.000 Millisekunden und deaktiviert das Weiterblättern per Mausklick, dann speichert es das Ergebnis als PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Automatisches Weiterblättern unabhängig von der Effektdauer konfigurieren.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Unterschiedliche Dauern für einzelne Folien festlegen**

Verschiedene Folien können unterschiedliche Effekt‑dauern verwenden. Zum Beispiel einen kurzen Übergang für eine Titelfolie und einen längeren für eine Abschnittseinleitung. Dieses Beispiel setzt 500 Millisekunden für die erste Folie und 1.200 Millisekunden für die zweite. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Übergänge mit animierten Ausgaben koordinieren**

Beim Erstellen eines [animated GIF](/slides/de/nodejs-java/convert-powerpoint-to-animated-gif/), einer [HTML5 presentation](/slides/de/nodejs-java/export-to-html5/) oder eines [video](/slides/de/nodejs-java/convert-powerpoint-to-video/) sollten Sie vor dem Export die genauen Übergangsdauern festlegen, um das gewünschte Tempo zu erreichen. Verwenden Sie beispielsweise ein 600‑Millisekunden‑Fade zwischen Szenen und passen Sie die Weiterblätter‑Verzögerung jeder Folie separat an, um Zeit für deren Erzählung oder Inhalt zu ermöglichen.

Für GIF und Video koordinieren Sie die Ausgabebildrate mit der Effekt‑dauer: 600 Millisekunden entsprechen 18 Frames bei 30 Frames pro Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Export‑Einstellungen. Prüfen Sie die unterstützten Effekte und Zeitoptionen des gewählten Export‑Formats und prüfen Sie die Vorschau, um die Synchronisation zu bestätigen.

### **Vorhandene Übergangsdauer auslesen**

Rufen Sie [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) auf, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer festgelegt ist; ein nichtnegativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides verwendet den Übergangstyp und den Wert von [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed), um diese Dauer zu bestimmen. Das Festlegen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zunächst die ursprünglichen Einstellungen prüfen.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph‑Übergang**

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, duplizieren Sie eine Folie, verschieben oder skalieren ein Objekt auf dem Duplikat und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhält der Übergang die entsprechenden Objekte, die zwischen ihrem ursprünglichen und modifizierten Zustand animiert werden.

Das folgende Beispiel erstellt eine Folie mit einem Textrechteck, dupliziert die Folie und ändert die Position und Größe des Rechtecks im Duplikat. Anschließend wählt es Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) für die zweite Folie. Öffnen Sie die gespeicherte Datei in einem Präsentationsbetrachter, der Morph unterstützt, um den Effekt während einer Bildschirmpräsentation zu sehen.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph‑Übergangstypen**

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) steuert, wie Morph Inhalte zuordnet und animiert:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) betrachtet jede Form als ein gesamtes Objekt.
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) animiert Text, indem nach Möglichkeit Wörter abgeglichen werden.
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) animiert Text, indem nach Möglichkeit Zeichen abgeglichen werden.

Verwenden Sie [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType), um Morph auszuwählen, bevor Sie [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) aufrufen. Der zurückgegebene Wert liefert ein [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/)‑Objekt, dessen Methode [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) den Abgleich‑Modus auswählt.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Übergangseffekte festlegen**

Einige Übergänge bieten zusätzliche Optionen, z. B. Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom mit [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) gewählten Übergang ab. Setzen Sie zuerst den Typ und verwenden Sie dann das passende Übergangsobjekt aus [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es ruft [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) über [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) auf, sodass der Übergang von einem schwarzen Bildschirm startet.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Verwenden Sie vorzugsweise [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration), wenn Sie eine exakte Effekt‑dauer in Millisekunden benötigen. Nutzen Sie [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed), wenn eine vordefinierte Kategorie aus [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) – Slow, Medium oder Fast – ausreicht und keine explizite Dauer festgelegt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der Verzögerung für das automatische Weiterblättern.

**Kann ich einer Transition Audio hinzufügen und es wiederholen?**

Ja. Weisen Sie eingebettetes Audio mit [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound) zu, übergeben Sie StartSound aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) an [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) und aktivieren Sie [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) mit `true`. Das Audio wiederholt sich bis zum nächsten Soundereignis in der Bildschirmpräsentation.

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Durchlaufen Sie die [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides)‑Sammlung der Präsentation und rufen Sie für jede Folie [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) mit demselben Wert auf. Legen Sie Timing‑ und Effektoptionen im selben Durchlauf fest, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich prüfen, welcher Übergang aktuell auf einer Folie eingestellt ist?**

Rufen Sie [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) auf dem Ergebnis von [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie auf. Es liefert einen Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/); None bedeutet, dass kein Übergangseffekt angewendet wurde.