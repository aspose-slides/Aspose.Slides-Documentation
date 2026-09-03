---
title: Folienübergänge in Präsentationen auf Android verwalten
linktitle: Folienübergang
type: docs
weight: 80
url: /de/androidjava/slide-transition/
keywords:
- Folienübergang
- Folienübergang hinzufügen
- Folienübergang anwenden
- erweiterter Folienübergang
- Morph‑Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Folienübergänge anwenden, automatisches Vorwärtsschalten konfigurieren und Morph‑ sowie andere Übergangseffekte mit Aspose.Slides für Android via Java anpassen."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Diashow angezeigt werden. Mit Aspose.Slides für Android via Java können Sie für jede Folie einen Übergangseffekt auswählen, den Vorwärtswechsel per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen anpassen. Dieser Artikel verwendet Java‑Beispiele, um Übergänge anzuwenden, exakte Übergangsdauern festzulegen, die Folienzeitsteuerung zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen zudem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Klasse und greifen über [getSlideShowTransition](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) auf die Übergangseinstellungen der Folie zu. Verwenden Sie [setType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) mit einem Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/transitiontype/), und speichern Sie anschließend die Präsentation.

Das folgende Beispiel wendet einen Circle‑Übergang auf die erste Folie und einen Comb‑Übergang auf die zweite Folie an. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

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

## **Erweiterten Folienübergang hinzufügen**

Sie können festlegen, wie lange eine Folie angezeigt wird und ob ein Mausklick die Diashow vorwärts schaltet. Die folgenden Methoden steuern dieses Verhalten:

- [setAdvanceOnClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) ermöglicht dem Betrachter, durch Klicken der Maus voranzuschalten.
- [setAdvanceAfter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) aktiviert das automatische Vorwärtsschalten.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) gibt die Verzögerung vor dem automatischen Vorwärtsschalten in Millisekunden an.

Aktivieren Sie sowohl Klick‑ als auch Timer‑Vorwärtsschalten, damit der Betrachter entweder durch Klicken weitergehen oder auf den Timer warten kann. Um nur den Timer zu verwenden, übergeben Sie `false` an [setAdvanceOnClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Die Verzögerung bestimmt, wann die Diashow vorwärts schaltet; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert das automatische Vorwärtsschalten nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls vorwärts schalten. Verwenden Sie eine `input.pptx`‑Datei mit mindestens drei Folien.

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

Um zu prüfen, ob das zeitgesteuerte Vorwärtsschalten aktiviert ist, rufen Sie [getAdvanceAfter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) auf. Eine gespeicherte Verzögerung allein weist nicht darauf hin, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, gibt jede aktivierte Zeitschaltuhr aus und deaktiviert das automatische Vorwärtsschalten für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien wird das Klicken mit der Maus aktiviert und die aktualisierten Einstellungen werden gespeichert.

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

## **Übergangszeit präzise steuern**

Verwenden Sie [setDuration](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-), um die genaue Länge eines Übergangseffekts in Millisekunden anzugeben. Die Methode [getSlideShowTransition](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) der Folie stellt diese Einstellungen über [ISlideShowTransition](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/) bereit:

| Methode | Zweck |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Legt die Dauer des eigentlichen Übergangseffekts in Millisekunden fest. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Legt die Verzögerung fest, bevor die Folie automatisch weitergeschaltet wird, in Millisekunden. Übergeben Sie `true` an [setAdvanceAfter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-), um diesen Timer zu aktivieren. |
| [setSpeed](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium oder Fast. Sie wird verwendet, wenn keine genaue Dauer angegeben ist. |

[setDuration] steuert nur den Übergangseffekt; sie legt nicht fest, wie lange die Folie sichtbar bleibt. Die Verzögerung für das automatische Vorwärtsschalten muss separat konfiguriert werden. Wenn keine explizite Dauer angegeben ist, ermittelt Aspose.Slides die Effektdauer aus dem Übergangstyp und dem Wert von [getSpeed](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--).

### **Gleiche Dauer auf jede Folie anwenden**

Für ein konsistentes Tempo wenden Sie denselben Effekt und dieselbe genaue Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/transitiontype/), und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert separat das automatische Vorwärtsschalten nach 5.000 Millisekunden und deaktiviert das Vorwärtsschalten per Mausklick, anschließend wird das Ergebnis als PPTX gespeichert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Automatisches Vorwärtsschalten unabhängig von der Effektdauer konfigurieren.
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

Verschiedene Folien können unterschiedliche Effektzeiten verwenden. Zum Beispiel kann ein kurzer Übergang für die Titelfolie und ein längerer Übergang für die Einleitung eines Abschnitts verwendet werden. Dieses Beispiel setzt 500 Millisekunden für die erste Folie und 1.200 Millisekunden für die zweite. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

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

### **Übergänge mit animiertem Output koordinieren**

Bei der Vorbereitung eines [animierten GIF](/slides/de/androidjava/convert-powerpoint-to-animated-gif/), einer [HTML5‑Präsentation](/slides/de/androidjava/export-to-html5/) oder eines [Videos](/slides/de/androidjava/convert-powerpoint-to-video/) sollten Sie vor dem Export exakte Übergangszeiten festlegen, um das gewünschte Tempo zu erreichen. Verwenden Sie beispielsweise ein 600‑Millisekunden‑Fade zwischen Szenen und passen Sie die Vorwärtsschaltverzögerung jeder Folie separat an, um Zeit für deren Erzählung oder Inhalt zu geben.

Für GIF und Video koordinieren Sie die Ausgabebildrate mit der Effektdauer: 600 Millisekunden entsprechen 18 Frames bei 30 FPS. In HTML5 aktivieren Sie animierte Übergänge in den Export‑Einstellungen. Prüfen Sie die vom gewählten Exportformat unterstützten Effekte und Zeitoptionen und sehen Sie sich eine Vorschau an, um die Synchronisation zu bestätigen.

### **Vorhandene Übergangsdauer auslesen**

Rufen Sie [getDuration](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) auf, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer gesetzt ist; ein nicht‑negativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert entspricht nicht der berechneten Abspieldauer: Aspose.Slides verwendet den Übergangstyp und den Wert von [getSpeed](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) , um diese Dauer zu bestimmen. Das Setzen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zuerst die ursprünglichen Einstellungen prüfen.

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

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, klonen Sie eine Folie, verschieben oder ändern die Größe eines Objekts im Klon und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die entsprechenden Objekte einen Animationspfad zwischen ihrem ursprünglichen und modifizierten Zustand.

Das folgende Beispiel erstellt eine Folie mit einem Textrechteck, klont die Folie und ändert die Position und Größe des Rechtecks im Klon. Anschließend wird Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/transitiontype/) für die zweite Folie ausgewählt. Öffnen Sie die gespeicherte Datei in einem Präsentationsbetrachter, der Morph unterstützt, um den Effekt während einer Diashow zu sehen.

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

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/transitionmorphtype/) steuert, wie Morph Inhalte abgleicht und animiert:

- [ByObject](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) behandelt jede Form als ganzes Objekt.
- [ByWord](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) animiert Text, indem nach Möglichkeit Wörter abgeglichen werden.
- [ByChar](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) animiert Text, indem nach Möglichkeit Zeichen abgeglichen werden.

Verwenden Sie [setType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setType-int-), um Morph auszuwählen, bevor Sie [getValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#getValue--) aufrufen. Der zurückgegebene Wert liefert die Schnittstelle [IMorphTransition](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imorphtransition/), deren Methode [setMorphType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) den Abgleichmodus auswählt.

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

Einige Übergänge bieten zusätzliche Optionen, wie Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom mit [setType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) gewählten Übergang ab. Setzen Sie zuerst den Typ und verwenden Sie anschließend die passende Schnittstelle von [getValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es ruft [setFromBlack](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) über [IOptionalBlackTransition](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioptionalblacktransition/) auf, sodass der Übergang von einem schwarzen Bildschirm startet.

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

Ja. Verwenden Sie bevorzugt [setDuration](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-), wenn Sie eine exakte Effektdauer in Millisekunden benötigen. Nutzen Sie [setSpeed](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-), wenn eine vordefinierte [TransitionSpeed](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/transitionspeed/)-Kategorie — Slow, Medium oder Fast — ausreicht und keine explizite Dauer festgelegt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der Verzögerung für das automatische Vorwärtsschalten.

**Kann ich einer Transition Audio hinzufügen und es in einer Schleife abspielen?**

Ja. Weisen Sie eingebettetes Audio mit [setSound](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) zu, übergeben Sie StartSound aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/transitionsoundmode/) an [setSoundMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-), und aktivieren Sie [setSoundLoop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) mit `true`. Das Audio wiederholt sich, bis das nächste Tonevent in der Diashow eintritt.

**Was ist der schnellste Weg, denselben Transitionseffekt auf jede Folie anzuwenden?**

Durchlaufen Sie die [getSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSlides--)‑Sammlung der Präsentation und rufen Sie für jeden Folienübergang [setType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) mit demselben Wert auf. Setzen Sie alle Zeit- und Effektoptionen im selben Durchlauf, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich prüfen, welcher Transitionseffekt aktuell auf einer Folie eingestellt ist?**

Rufen Sie [getType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islideshowtransition/#getType--) auf dem Ergebnis von [getSlideShowTransition](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) der Folie auf. Es liefert einen Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/transitiontype/); None bedeutet, dass kein Transitionseffekt angewendet ist.