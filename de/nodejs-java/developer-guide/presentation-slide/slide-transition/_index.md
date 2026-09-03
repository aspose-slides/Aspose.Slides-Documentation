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
- Morph‑Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Folienübergänge anwenden, automatisches Voranschreiten von Folien konfigurieren und Morph sowie andere Übergangseffekte mit Aspose.Slides für Node.js via Java anpassen."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Diashow angezeigt werden. Mit Aspose.Slides für Node.js via Java können Sie für jede Folie einen Übergangseffekt auswählen, das Voranschreiten per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen für einen Effekt anpassen. Dieser Artikel verwendet JavaScript‑Beispiele, um Übergänge anzuwenden, exakte Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen außerdem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse und greifen über [getSlideShowTransition](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) auf die Übergangseinstellungen der Folie zu. Verwenden Sie [setType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setType) mit einem Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/transitiontype/), und speichern Sie dann die Präsentation.

Das folgende Beispiel wendet einen Kreis‑Übergang auf die erste Folie und einen Kamm‑Übergang auf die zweite Folie an. Verwenden Sie eine Datei `input.pptx` mit mindestens zwei Folien.

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

## **Erweiterte Folienübergänge hinzufügen**

Sie können konfigurieren, wie lange eine Folie angezeigt wird und ob ein Mausklick die Diashow voranbringt. Die folgenden Methoden steuern dieses Verhalten:

- [setAdvanceOnClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ermöglicht dem Betrachter, durch Klicken der Maus voranzuschreiten.
- [setAdvanceAfter](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) aktiviert das automatische Voranschreiten.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) gibt die Verzögerung bis zum automatischen Voranschreiten in Millisekunden an.

Aktivieren Sie sowohl Klick‑ als auch Timer‑Voranschreiten, damit der Betrachter per Klick weiterkommt oder auf den Timer wartet. Verwenden Sie nur den Timer, übergeben Sie `false` an [setAdvanceOnClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Die Verzögerung steuert, wann die Diashow voranschreitet; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert das automatische Voranschreiten nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls voranbringen. Verwenden Sie eine Datei `input.pptx` mit mindestens drei Folien.

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

Um zu prüfen, ob das zeitgesteuerte Voranschreiten aktiviert ist, rufen Sie [getAdvanceAfter](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) auf. Ein gespeicherter Verzögerungswert allein bedeutet nicht, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, meldet jeden aktivierten Timer und deaktiviert das automatische Voranschreiten für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien wird das Klicken aktiviert und die aktualisierten Einstellungen werden gespeichert.

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

## **Übergangszeiten präzise steuern**

Verwenden Sie [setDuration](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setDuration), um die exakte Länge eines Übergangseffekts in Millisekunden anzugeben. Die Methode [getSlideShowTransition](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie gibt diese Einstellungen über [SlideShowTransition](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/) frei:

| Methode | Zweck |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Legt die Dauer des eigentlichen Übergangseffekts in Millisekunden fest. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Legt die Verzögerung fest, bevor die Folie automatisch voranschreitet, in Millisekunden. Aktivieren Sie den Timer, indem Sie `true` an [setAdvanceAfter](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) übergeben. |
| [setSpeed](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium oder Fast. Sie wird verwendet, wenn keine exakte Dauer angegeben ist. |

[setDuration](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setDuration) beeinflusst nur den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Die Verzögerung für das automatische Voranschreiten muss separat konfiguriert werden. Wenn keine explizite Dauer gesetzt ist, ermittelt Aspose.Slides die Effekt­dauer aus dem Übergangstyp und dem Wert von [getSpeed](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

### **Die gleiche Dauer auf jede Folie anwenden**

Für ein einheitliches Tempo wenden Sie denselben Effekt und dieselbe exakte Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/transitiontype/) und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert separat das automatische Voranschreiten nach 5 000 Millisekunden und deaktiviert das Voranschreiten per Mausklick, dann wird das Ergebnis als PPTX gespeichert.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Automatisches Voranschreiten unabhängig von der Effektdauer konfigurieren.
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

Verschiedene Folien können unterschiedliche Effekt­dauern verwenden. Zum Beispiel einen kurzen Übergang für eine Titelfolie und einen längeren für eine Abschnittseinleitung. Dieses Beispiel setzt 500 Millisekunden für die erste Folie und 1 200 Millisekunden für die zweite. Verwenden Sie eine Datei `input.pptx` mit mindestens zwei Folien.

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

Beim Vorbereiten eines [animated GIF](/slides/de/nodejs-java/convert-powerpoint-to-animated-gif/), einer [HTML5 presentation](/slides/de/nodejs-java/export-to-html5/) oder eines [video](/slides/de/nodejs-java/convert-powerpoint-to-video/) sollten Sie die exakten Übergangsdauern vor dem Export festlegen, um das gewünschte Tempo zu erreichen. Verwenden Sie zum Beispiel ein 600‑Millisekunden‑Fade zwischen Szenen und passen Sie jede Folien‑Verzögerung separat an, um Zeit für die jeweilige Erzählung oder den Inhalt zu lassen.

Für GIF und Video koordinieren Sie die Bildfrequenz des Ausgabemediums mit der Effekt­dauer: 600 Millisekunden entsprechen 18 Bildern bei 30 Frames pro Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Export‑Einstellungen. Prüfen Sie die unterstützten Effekte und Timing‑Optionen des gewählten Exportformats und prüfen Sie die Vorschau, um die Synchronisation zu bestätigen.

### **Eine vorhandene Übergangs‑Dauer auslesen**

Rufen Sie [getDuration](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#getDuration) auf, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer gesetzt ist; ein nicht‑negativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Abspieldauer: Aspose.Slides verwendet den Übergangstyp und den Wert von [getSpeed](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#getSpeed), um diese Dauer zu bestimmen. Das Setzen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zunächst die Originaleinstellungen prüfen.

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

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erstellen, duplizieren Sie eine Folie, verschieben oder skalieren Sie ein Objekt auf der Kopie und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die entsprechenden Objekte eine Animation zwischen ihrem Original‑ und modifizierten Zustand.

Das folgende Beispiel erstellt eine Folie mit einem Text‑Rechteck, dupliziert die Folie und ändert die Position und Größe des Rechtecks auf der Kopie. Anschließend wählt es Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/transitiontype/) für die zweite Folie. Öffnen Sie die gespeicherte Datei in einem Präsentationsviewer, der Morph unterstützt, um den Effekt während einer Diashow zu sehen.

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

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/transitionmorphtype/) bestimmt, wie Morph Inhalte abgleicht und animiert:

- [ByObject](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) behandelt jede Form als Ganzes.
- [ByWord](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) animiert Text, indem nach Möglichkeit Wörter abgeglichen werden.
- [ByChar](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) animiert Text, indem nach Möglichkeit Zeichen abgeglichen werden.

Verwenden Sie [setType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setType), um Morph auszuwählen, bevor Sie [getValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#getValue) aufrufen. Der zurückgegebene Wert liefert ein [MorphTransition](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/morphtransition/)-Objekt, dessen Methode [setMorphType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/morphtransition/#setMorphType) den Abgleich‑Modus auswählt.

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

Einige Übergänge bieten zusätzliche Optionen, etwa Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom mit [setType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setType) gewählten Übergang ab. Setzen Sie zuerst den Typ und verwenden dann das passende Übergangs‑Objekt aus [getValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es ruft [setFromBlack](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) über [OptionalBlackTransition](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/optionalblacktransition/) auf, sodass der Übergang von einem schwarzen Bildschirm beginnt.

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

Ja. Verwenden Sie bevorzugt [setDuration](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setDuration), wenn Sie eine exakte Effekt­dauer in Millisekunden benötigen. Nutzen Sie [setSpeed](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setSpeed), wenn eine vordefinierte [TransitionSpeed](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/transitionspeed/)-Kategorie – Slow, Medium oder Fast – ausreicht und keine explizite Dauer gesetzt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der Verzögerung für das automatische Voranschreiten.

**Kann ich einer Folie einen Ton zuweisen und ihn wiederholen lassen?**

Ja. Weisen Sie eingebetteten Ton mit [setSound](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setSound) zu, übergeben Sie `StartSound` aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/transitionsoundmode/) an [setSoundMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) und aktivieren Sie [setSoundLoop](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) mit `true`. Der Ton wiederholt sich, bis das nächste Sound‑Ereignis in der Diashow eintritt.

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Durchlaufen Sie die [getSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSlides)-Sammlung der Präsentation und rufen Sie für jede Folie [setType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#setType) mit dem gleichen Wert auf. Setzen Sie Timing‑ und Effekt‑Optionen im gleichen Schleifendurchlauf, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich prüfen, welcher Übergang aktuell auf einer Folie eingestellt ist?**

Rufen Sie [getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideshowtransition/#getType) auf dem Ergebnis von [getSlideShowTransition](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie auf. Es wird ein Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/transitiontype/) zurückgegeben; `None` bedeutet, dass kein Übergangseffekt angewendet wurde.