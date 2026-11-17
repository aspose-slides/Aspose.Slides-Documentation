---
title: Verwalten von Folienübergängen in Präsentationen mit Java
linktitle: Folienübergang
type: docs
weight: 80
url: /de/java/slide-transition/
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
- Java
- Aspose.Slides
description: "Folienübergänge anwenden, automatisches Voranschreiten von Folien konfigurieren und Morph- sowie andere Übergangseffekte mit Aspose.Slides für Java anpassen."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Bildschirmpräsentation angezeigt werden. Mit Aspose.Slides für Java können Sie für jede Folie einen Übergangseffekt auswählen, das Voranschreiten per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen für einen Effekt anpassen. Dieser Artikel verwendet Java‑Beispiele, um Übergänge anzuwenden, genaue Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen außerdem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) und greifen über [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) auf die Übergabeeinstellungen der Folie zu. Verwenden Sie [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) mit einem Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/), und speichern Sie anschließend die Präsentation.

Das folgende Beispiel wendet einen Circle‑Übergang auf die erste Folie und einen Comb‑Übergang auf die zweite Folie an. Verwenden Sie eine Datei `input.pptx` mit mindestens zwei Folien.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Rad‑Übergang**

Die Methode [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) von [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) steuert die Anzahl der radialen Sektoren, die die Ziel‑Folien enthüllen. Setzen Sie den Folienübergangstyp auf Wheel aus [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) mittels [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-), bevor Sie [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) als [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) abrufen.

Dieses Beispiel erstellt zwei identische Folienpaare: eine schwarze Folie, gefolgt von einer Folie mit einem goldenen Rechteck. Die Ziel‑Folien verwenden Rad‑Zähler von 1 bzw. 8, mit derselben über [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) eingestellten Geschwindigkeit und einer expliziten Dauer von 8.000 Millisekunden, die über [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) festgelegt wird, um den Unterschied leicht erkennbar zu machen.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Öffnen Sie die Ausgabedatei in PowerPoint und starten Sie die Bildschirmpräsentation. Wechseln Sie von Folie 1 zu Folie 2 und dann von Folie 3 zu Folie 4. In der PowerPoint‑Wiedergabe enthüllt die bestätigte Rad‑Anzahl von 1 die Folie mit einem einzigen, im Uhrzeigersinn verlaufenden Sweep; die bestätigte Anzahl von 8 enthüllt sie gleichzeitig über acht radiale Sektoren. Der Zielinhalt und die Übergangszeit sind identisch, sodass sich nur die Anzahl der Enthüllungssektoren unterscheidet.

## **Erweiterten Folienübergang hinzufügen**

Sie können festlegen, wie lange eine Folie auf dem Bildschirm bleibt und ob ein Mausklick die Präsentation voranbringt. Die folgenden Methoden steuern dieses Verhalten:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) ermöglicht dem Betrachter, per Mausklick voranzuschalten.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) aktiviert das automatische Voranschreiten.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) gibt die Verzögerung vor dem automatischen Voranschreiten in Millisekunden an.

Aktivieren Sie sowohl Klick‑ als auch Timer‑Voranschreiten, damit der Betrachter entweder per Klick weitergeht oder auf den Timer wartet. Um nur den Timer zu verwenden, übergeben Sie `false` an [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Die Verzögerung bestimmt, wann die Präsentation weiterschaltet; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert das automatische Voranschreiten nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls voranbringen. Verwenden Sie eine Datei `input.pptx` mit mindestens drei Folien.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Um zu prüfen, ob das zeitgesteuerte Voranschreiten aktiviert ist, rufen Sie [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) auf. Ein gespeicherter Verzögerungswert allein zeigt nicht an, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, gibt für jede aktivierte Zeitsteuerung eine Meldung aus und deaktiviert das automatische Voranschreiten für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien wird das Voranschreiten per Klick wieder aktiviert und die aktualisierten Einstellungen werden gespeichert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Übergangszeit exakt steuern**

Verwenden Sie [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-), um die genaue Länge eines Übergangseffekts in Millisekunden anzugeben. Die Folie liefert über [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) die Einstellungen über das Interface [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/):

| Methode | Zweck |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Legt die Dauer des Übergangseffekts selbst in Millisekunden fest. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Legt die Verzögerung fest, bevor die Folie automatisch weitergeht, in Millisekunden. Übergeben Sie `true` an [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-), um diesen Timer zu aktivieren. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow, Medium oder Fast. Wird verwendet, wenn keine exakte Dauer angegeben ist. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) steuert nur den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Die Verzögerung für das automatische Voranschreiten wird separat konfiguriert. Wenn keine explizite Dauer festgelegt ist, ermittelt Aspose.Slides die Effektdauer aus dem Übergangstyp und dem [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--)‑Wert.

<!-- visual-explanation:slide-transition:start -->
[![Separate Balken zeigen die 750‑ms Übergangsdauer und die 5.000‑ms Einstellung für automatisches Voranschreiten.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Das Beispiel weist jeder Folie einen 750‑ms Fade‑Übergang zu und aktiviert separat das automatische Voranschreiten nach 5.000 ms. Die Übergangsdauer steuert den Effekt; das Voranschreiten bestimmt, wann die Folie verlassen wird. Diese Balken stellen schematische Einstellungen dar, nicht eine gemessene kombinierte Zeitleiste.*
<!-- visual-explanation:slide-transition:end -->

### **Für jede Folie die gleiche Dauer anwenden**

Um ein gleichmäßiges Tempo zu erreichen, wenden Sie denselben Effekt und dieselbe exakte Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert separat das automatische Voranschreiten nach 5.000 Millisekunden und deaktiviert das Voranschreiten per Mausklick, bevor das Ergebnis als PPTX gespeichert wird.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Automatisches Voranschreiten unabhängig von der Dauer des Effekts konfigurieren.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Unterschiedliche Dauern für einzelne Folien festlegen**

Verschiedene Folien können unterschiedliche Effektdauern verwenden. Zum Beispiel kann für eine Titelfolie ein kurzer Übergang und für eine Abschnittseinleitung ein längerer Übergang eingesetzt werden. Dieses Beispiel legt 500 Millisekunden für die erste Folie und 1.200 Millisekunden für die zweite Folie fest. Verwenden Sie eine Datei `input.pptx` mit mindestens zwei Folien.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Übergänge mit animierten Ausgaben koordinieren**

Wenn Sie ein [animiertes GIF](/slides/de/java/convert-powerpoint-to-animated-gif/) , eine [HTML5‑Präsentation](/slides/de/java/export-to-html5/) oder ein [Video](/slides/de/java/convert-powerpoint-to-video/) vorbereiten, setzen Sie genaue Übergangsdauern vor dem Export, um das gewünschte Tempo zu treffen. Beispiel: Verwenden Sie einen 600‑ms‑Fade zwischen Szenen und passen Sie die Verzögerung für das Voranschreiten jeder Folie separat an, damit genügend Zeit für die Erzähler‑ oder Inhaltspräsentation bleibt.

Für GIF und Video koordinieren Sie die Bildrate der Ausgabe mit der Effektdauer: 600 Millisekunden entsprechen 18 Frames bei 30 Frames pro Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Exporteinstellungen. Prüfen Sie die unterstützten Effekte und Timing‑Optionen des gewählten Exportformats und prüfen Sie die Ausgabe, um die Synchronisation zu bestätigen.

### **Bestehende Übergangsdauer auslesen**

Rufen Sie [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) auf, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Der Wert `-1` bedeutet, dass keine explizite Dauer gesetzt ist; ein nicht‑negativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides verwendet den Übergangstyp und den [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--)‑Wert, um diese Dauer zu bestimmen. Das Setzen eines Übergangstyps kann eine Dauer initialisieren, prüfen Sie daher zunächst die Originaleinstellungen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph‑Übergang**

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, kopieren Sie eine Folie, verschieben oder skalieren Sie ein Objekt auf der Kopie und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die entsprechenden Objekte die Animation zwischen ihren ursprünglichen und modifizierten Zuständen.

Das folgende Beispiel erstellt eine Folie mit einem Textrechteck, kopiert die Folie und ändert Position und Größe des Rechtecks auf der Kopie. Anschließend wählt es Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) für die zweite Folie aus. Öffnen Sie die gespeicherte Datei in einem Präsentations‑Viewer, der Morph unterstützt, um den Effekt während einer Bildschirmpräsentation zu sehen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph‑Übergangstypen**

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) steuert, wie Morph Inhalte abgleicht und animiert:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) behandelt jede Form als ganzes Objekt.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) animiert Text, indem wo möglich Wörter abgeglichen werden.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) animiert Text, indem wo möglich Zeichen abgeglichen werden.

Verwenden Sie [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-), um Morph auszuwählen, bevor Sie [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) aufrufen. Der zurückgegebene Wert liefert das Interface [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/), dessen Methode [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) den Abgleichmodus auswählt.

Dieses Beispiel öffnet die im vorherigen Abschnitt erstellte Präsentation und konfiguriert die zweite Folie so, dass sie eine wortbasierte Morph‑Animation verwendet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Übergangseffekte festlegen**

Einige Übergänge bieten zusätzliche Optionen, etwa Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom mit [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) gewählten Übergang ab. Setzen Sie zuerst den Typ und verwenden dann das passende Interface, das Sie über [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) erhalten.

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es ruft über [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) die Methode [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) auf, sodass der Übergang von einem schwarzen Bildschirm startet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Verwenden Sie [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-), wenn Sie eine exakte Effektdauer in Millisekunden benötigen. Nutzen Sie [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-), wenn eine vordefinierte [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/)‑Kategorie — Slow, Medium oder Fast — ausreicht und keine explizite Dauer gesetzt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der Verzögerung für das automatische Voranschreiten.

**Kann ich einer Transition Audio anhängen und es wiederholen lassen?**

Ja. Weisen Sie über [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) eingebettetes Audio zu, übergeben Sie `StartSound` aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) an [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), und aktivieren Sie [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) mit `true`. Das Audio wiederholt sich, bis das nächste Sound‑Ereignis in der Präsentation eintritt.

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Durchlaufen Sie die [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--)‑Sammlung der Präsentation und rufen Sie für jede Folie [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) mit demselben Wert auf. Legen Sie Timing‑ und Effektoptionen in derselben Schleife fest, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich prüfen, welcher Übergang derzeit einer Folie zugewiesen ist?**

Rufen Sie [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) auf dem Ergebnis von [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) der Folie auf. Der Rückgabewert stammt aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/); None bedeutet, dass kein Übergangseffekt angewendet wurde.