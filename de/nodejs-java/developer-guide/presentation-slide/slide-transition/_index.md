---
title: Verwalten von Folienübergängen in Präsentationen mit JavaScript
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
description: "Folienübergänge anwenden, den automatischen Folienfortschritt konfigurieren und Morph sowie andere Übergangseffekte mit Aspose.Slides für Node.js über Java anpassen."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Vorführung angezeigt werden. Mit Aspose.Slides für Node.js über Java können Sie für jede Folie einen Übergangseffekt auswählen, den Fortschritt per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen für einen Effekt anpassen. Dieser Artikel verwendet JavaScript‑Beispiele, um Übergänge anzuwenden, genaue Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erzeugen. Die Beispiele zeigen außerdem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Präsentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse und greifen über [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) auf die Übergangseinstellungen der Folie zu. Verwenden Sie [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) mit einem Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/), und speichern Sie die Präsentation anschließend.

Im folgenden Beispiel wird auf die erste Folie ein Circle‑Übergang und auf die zweite Folie ein Comb‑Übergang angewendet. Verwenden Sie eine Datei `input.pptx` mit mindestens zwei Folien.

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

## **Wheel‑Übergang**

Die Methode [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) von [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) steuert die Anzahl der radialen Sektoren, die die Ziel‑Folie sichtbar machen. Setzen Sie den Folien‑Übergangstyp auf Wheel aus [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) mittels [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType), bevor Sie über [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) als [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) zugreifen.

Dieses Beispiel erstellt zwei identische Folienpaare: eine schwarze Folie, gefolgt von einer Folie mit einem goldenen Rechteck. Die Ziel‑Folien verwenden Radialzahlen von 1 bzw. 8, dieselbe Geschwindigkeit über [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) und eine explizite Dauer von 8.000 Millisekunden über [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration), um den Unterschied leicht erkennbar zu machen.

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

Öffnen Sie die Ausgabepäsentation in PowerPoint und starten Sie die Vorführung. Gehen Sie von Folie 1 zu Folie 2 und anschließend von Folie 3 zu Folie 4. In der PowerPoint‑Wiedergabe enthüllt die bestätigte Radialzahl 1 die Folie mit einem einmaligen Uhrzeigersinn‑Sweep; die bestätigte Zahl 8 enthüllt sie gleichzeitig durch acht radiale Sektoren. Der Zielinhalt und die Übergangszeit sind identisch, sodass sich nur die Anzahl der Enthüllungssektoren unterscheidet.

## **Fade Through Black mit dem Reveal‑Übergang**

Setzen Sie den Übergangstyp der Ziel‑Folie auf Reveal und rufen Sie dann [setThroughBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/#setThroughBlack) auf deren [RevealTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/)-Einstellungen auf. Dieses Beispiel erstellt eine türkisfarbene Quell‑Folie und eine korallenfarbene Ziel‑Folie und klont anschließend beide. Jedes Paar verwendet denselben zweisekündigen Reveal‑Übergang. Nur das zweite Paar blendet über Schwarz ein.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const source = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addClone(source);
    const teal = java.newInstanceSync("java.awt.Color", 0, 128, 128);
    const coral = java.newInstanceSync("java.awt.Color", 255, 127, 80);

    for (const [slide, color, label] of [[source, teal, "Source"], [destination, coral, "Destination"]]) {
        slide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
        const fill = slide.getBackground().getFillFormat();
        fill.setFillType(java.newByte(slides.FillType.Solid));
        fill.getSolidFillColor().setColor(color);

        const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 160, 180, 400, 130);
        const textFrame = shape.getTextFrame();
        textFrame.setText(label);
        textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    const clonedDestination = presentation.getSlides().addClone(destination);
    for (const slide of [destination, clonedDestination]) {
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Reveal);
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(2000);

        const reveal = transition.getValue();
        reveal.setDirection(slides.TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide === clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Öffnen Sie die gespeicherte Präsentation in PowerPoint und starten Sie die Vorführung. Gehen Sie von Folie 1 zu Folie 2, um zu sehen, wie Türkis direkt in Koralle überblendet. Gehen Sie dann von Folie 3 zu Folie 4. Der Bildschirm wird kurz fast schwarz, bevor die Korallen‑Folie erscheint. Beide Folien behalten ihre ursprünglichen Hintergrundfarben bei.

Die nachfolgenden Zeilen zeigen Rahmen aus PowerPoint im Abstand von halben Sekunden. Vergleichen Sie den mittleren Rahmen jeder Zeile, um den Effekt zu sehen.

![PowerPoint‑Wiedergabe mit deaktiviertem (oben) und aktiviertem (unten) Fade‑Through‑Black. Nur die untere Zeile blendet fast schwarz ein.](reveal-through-black.png)

## **Erweiterten Folienübergang hinzufügen**

Sie können festlegen, wie lange eine Folie auf dem Bildschirm bleibt und ob ein Mausklick die Vorführung fortsetzt. Die folgenden Methoden steuern dieses Verhalten:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) erlaubt dem Betrachter, per Mausklick weiterzugehen.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) aktiviert die automatische Fortsetzung.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) gibt die Verzögerung bis zur automatischen Fortsetzung in Millisekunden an.

Aktivieren Sie sowohl Klick‑ als auch Timer‑Fortsetzung, damit der Betrachter entweder per Klick weitergeht oder auf den Timer wartet. Verwenden Sie nur den Timer, indem Sie `false` an [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) übergeben. Die Verzögerung bestimmt, wann die Vorführung fortschreitet; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert die automatische Fortsetzung nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls weiterblättern. Verwenden Sie eine Datei `input.pptx` mit mindestens drei Folien.

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

Um zu prüfen, ob die zeitgesteuerte Fortsetzung aktiviert ist, rufen Sie [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) auf. Ein gespeicherter Verzögerungswert allein bedeutet nicht, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, gibt jeden aktivierten Timer aus und deaktiviert die automatische Fortsetzung für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien wird der Mausklick wieder aktiviert und die geänderten Einstellungen werden gespeichert.

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

## **Übergangszeit exakt steuern**

Verwenden Sie [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration), um die genaue Länge eines Übergangseffekts in Millisekunden festzulegen. Die Methode [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie gibt diese Einstellungen über [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/) preis:

| Methode | Zweck |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Legt die Dauer des eigentlichen Übergangseffekts in Millisekunden fest. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Legt die Verzögerung bis zur automatischen Folienfortsetzung in Millisekunden fest. Übergeben Sie `true` an [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter), um den Timer zu aktivieren. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium oder Fast. Sie wird verwendet, wenn keine exakte Dauer angegeben wird. |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) steuert ausschließlich den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Die Verzögerung für die automatische Fortsetzung wird separat konfiguriert. Wenn keine explizite Dauer festgelegt ist, ermittelt Aspose.Slides die Effekt­dauer aus dem Übergangstyp und dem [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed)-Wert.

<!-- visual-explanation:slide-transition:start -->
[![Separate Balken zeigen die 750‑ms‑Übergangsdauer und die 5.000‑ms‑automatische Fortsetzung.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Das Beispiel gibt jeder Folie einen 750‑ms‑Fade‑Übergang und aktiviert getrennt die automatische Fortsetzung nach 5.000 ms. Die Übergangsdauer bestimmt den Effekt; die Fortsetzung bestimmt, wann die Folie verlassen wird. Diese Balken stellen schematische Einstellungen dar, keinen gemessenen kombinierten Zeitplan.*
<!-- visual-explanation:slide-transition:end -->

### **Die gleiche Dauer für jede Folie anwenden**

Für ein gleichmäßiges Tempo wenden Sie denselben Effekt und dieselbe exakte Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) und weist jedem Übergang eine Dauer von 750 Millisekunden zu. Es aktiviert getrennt die automatische Fortsetzung nach 5.000 Millisekunden und deaktiviert die Fortsetzung per Mausklick, dann wird das Ergebnis als PPTX gespeichert.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Konfigurieren Sie die automatische Fortsetzung unabhängig von der Effektdauer.
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

Verschiedene Folien können unterschiedliche Effekt­dauern besitzen. Zum Beispiel kann eine Titelfolie einen kurzen Übergang und eine Abschnittseinleitung einen längeren Übergang erhalten. Dieses Beispiel setzt 500 Millisekunden für die erste Folie und 1 200 Millisekunden für die zweite Folie. Verwenden Sie eine Datei `input.pptx` mit mindestens zwei Folien.

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

Beim Erstellen eines [animierten GIF](/slides/de/nodejs-java/convert-powerpoint-to-animated-gif/), einer [HTML5‑Präsentation](/slides/de/nodejs-java/export-to-html5/) oder eines [Videos](/slides/de/nodejs-java/convert-powerpoint-to-video/) sollten Sie vor dem Export exakte Übergangsdauern festlegen, um das gewünschte Timing zu erreichen. Verwenden Sie beispielsweise ein 600‑ms‑Fade zwischen Szenen und passen Sie jede Folien‑Fortsetzungs‑Verzögerung separat an, damit Zeit für Erzählung oder Inhalt bleibt.

Für GIF und Video koordinieren Sie die Bildrate mit der Effekt­dauer: 600 ms entsprechen 18 Bildern bei 30 fps. In HTML5 aktivieren Sie animierte Übergänge in den Export‑Einstellungen. Prüfen Sie die vom gewählten Exportformat unterstützten Effekte und Timing‑Optionen und prüfen Sie die Ausgabe, um die Synchronisation zu bestätigen.

### **Bestehende Übergangsdauer auslesen**

Rufen Sie [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) vor der Änderung des Übergangs auf, um festzustellen, ob ein expliziter Wert gespeichert ist. Der Wert `-1` bedeutet, dass keine explizite Dauer gesetzt ist; ein nicht‑negativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides verwendet den Übergangstyp und den [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed)-Wert, um diese Dauer zu bestimmen. Das Setzen eines Übergangstyps kann eine Dauer initialisieren, prüfen Sie also zuerst die Originaleinstellungen.

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

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, klonen Sie eine Folie, verschieben oder skalieren ein Objekt auf dem Klon und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die entsprechenden Objekte eine Animation von ihrem ursprünglichen zu ihrem geänderten Zustand.

Das folgende Beispiel erzeugt eine Folie mit einem Text‑Rechteck, klont die Folie und ändert die Position und Größe des Rechtecks auf dem Klon. Anschließend wählt es Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) für die zweite Folie. Öffnen Sie die gespeicherte Datei in einem Präsentations‑Viewer, der Morph unterstützt, um den Effekt während einer Vorführung zu sehen.

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

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) behandelt jede Form als ganzes Objekt.
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) animiert Text, indem wo möglich Worte abgeglichen werden.
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) animiert Text, indem wo möglich Zeichen abgeglichen werden.

Verwenden Sie [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType), um Morph auszuwählen, bevor Sie über [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) darauf zugreifen. Der zurückgegebene Wert liefert ein [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/)-Objekt, dessen Methode [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) den Abgleichmodus auswählt.

Dieses Beispiel öffnet die im vorherigen Abschnitt erstellte Präsentation und konfiguriert die zweite Folie so, dass sie eine wortbasierte Morph‑Animation verwendet.

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

Einige Übergänge besitzen zusätzliche Optionen, wie Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom über [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) gewählten Übergang ab. Setzen Sie zuerst den Typ und verwenden Sie dann das passende Übergangsobjekt über [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue).

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

Ja. Verwenden Sie bevorzugt [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration), wenn Sie eine exakte Effekt‑Dauer in Millisekunden benötigen. Nutzen Sie [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed), wenn eine vordefinierte [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/)-Kategorie – Slow, Medium oder Fast – ausreichend ist und keine explizite Dauer gesetzt wird. Diese Einstellungen steuern den Übergangseffekt unabhängig von der automatischen Fortsetzungs‑Verzögerung.

**Kann ich einem Übergang Audio hinzufügen und es in einer Schleife abspielen?**

Ja. Weisen Sie eingebettetes Audio mit [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound) zu, übergeben Sie `StartSound` aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) an [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) und aktivieren Sie [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) mit `true`. Das Audio wiederholt sich, bis das nächste Sound‑Ereignis in der Vorführung eintritt.

**Was ist der schnellste Weg, denselben Übergang für jede Folie anzuwenden?**

Durchlaufen Sie die [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides)-Sammlung der Präsentation und rufen Sie für jede Folie [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) mit demselben Wert auf. Setzen Sie Timing‑ und Effekt‑Optionen im selben Durchlauf, um ein konsistentes Verhalten über alle Folien hinweg zu gewährleisten.

**Wie kann ich prüfen, welcher Übergang aktuell einer Folie zugewiesen ist?**

Rufen Sie [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) auf dem Ergebnis von [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) der jeweiligen Folie auf. Der Rückgabewert stammt aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/); `None` bedeutet, dass kein Übergangseffekt angewendet ist.