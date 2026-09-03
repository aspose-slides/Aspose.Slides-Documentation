---  
title: Folienübergänge in Präsentationen mit Java verwalten  
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
description: "Folienübergänge anwenden, automatisches Vorwärtsspringen konfigurieren und Morph sowie weitere Übergangseffekte mit Aspose.Slides für Java anpassen."  
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Diashow erscheinen. Mit Aspose.Slides für Java können Sie einen Übergangseffekt für jede Folie auswählen, das Vorwärtsspringen per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen anpassen. Dieser Artikel verwendet Java‑Beispiele, um Übergänge anzuwenden, genaue Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen außerdem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)-Klasse und greifen über [getSlideShowTransition](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) auf die Übergangseinstellungen der Folie zu. Verwenden Sie [setType](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#setType-int-) mit einem Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/java/com.aspose.slides/transitiontype/), und speichern Sie anschließend die Präsentation.

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

Sie können konfigurieren, wie lange eine Folie auf dem Bildschirm bleibt und ob ein Mausklick die Diashow vorwärts springt. Die folgenden Methoden steuern dieses Verhalten:

- [setAdvanceOnClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) ermöglicht dem Betrachter, durch Klicken der Maus voranzuschreiten.
- [setAdvanceAfter](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) aktiviert automatisches Vorwärtsspringen.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) gibt die Verzögerung vor dem automatischen Vorwärtsspringen in Millisekunden an.

Aktivieren Sie sowohl Klick‑ als auch Timer‑Vorwärtsspringen, damit der Betrachter entweder per Klick weiterkommt oder auf den Timer wartet. Um nur den Timer zu verwenden, übergeben Sie `false` an [setAdvanceOnClick]. Die Verzögerung bestimmt, wann die Diashow vorwärts springt; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert automatisches Vorwärtsspringen nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls vorwärts springen lassen. Verwenden Sie eine `input.pptx`‑Datei mit mindestens drei Folien.

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

Um zu prüfen, ob das zeitgesteuerte Vorwärtsspringen aktiviert ist, rufen Sie [getAdvanceAfter](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) auf. Ein gespeicherter Verzögerungswert allein zeigt nicht an, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, gibt für jede aktivierte Timer‑Einstellung einen Bericht aus und deaktiviert das automatische Vorwärtsspringen für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien wird das Vorwärtsspringen per Mausklick wieder aktiviert und die aktualisierten Einstellungen werden gespeichert.

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

Verwenden Sie [setDuration](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#setDuration-int-), um die genaue Länge eines Übergangseffekts in Millisekunden anzugeben. Die Folie liefert über [getSlideShowTransition](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) diese Einstellungen über [ISlideShowTransition](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/):

| Methode | Zweck |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Legt die Dauer des Übergangseffekts selbst in Millisekunden fest. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Legt die Verzögerung fest, bevor die Folie automatisch vorwärts springt, in Millisekunden. Übergeben Sie `true` an [setAdvanceAfter], um diesen Timer zu aktivieren. |
| [setSpeed](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/de/java/com.aspose.slides/transitionspeed/): Slow, Medium oder Fast. Wird verwendet, wenn keine exakte Dauer angegeben ist. |

[setDuration] steuert nur den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Die Verzögerung für das automatische Vorwärtsspringen muss separat konfiguriert werden. Wenn keine explizite Dauer festgelegt ist, ermittelt Aspose.Slides die Effektdauer aus dem Übergangstyp und dem [getSpeed](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#getSpeed--)‑Wert.

### **Dieselben Dauer auf jede Folie anwenden**

Für ein gleichmäßiges Tempo wenden Sie denselben Effekt und dieselbe exakte Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/de/java/com.aspose.slides/transitiontype/) und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert zudem das automatische Vorwärtsspringen nach 5 000 Millisekunden und deaktiviert das Vorwärtsspringen per Mausklick, bevor das Ergebnis als PPTX gespeichert wird.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Automatisches Vorwärtsspringen unabhängig von der Dauer des Effekts konfigurieren.
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

Verschiedene Folien können unterschiedliche Effektdauern verwenden. Zum Beispiel kann ein kurzer Übergang für eine Titelfolie und ein längerer Übergang für eine Abschnittseinleitung eingesetzt werden. Dieses Beispiel legt 500 Millisekunden für die erste Folie und 1 200 Millisekunden für die zweite Folie fest. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

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

### **Übergänge mit animierter Ausgabe koordinieren**

Beim Vorbereiten eines [animated GIF](/slides/de/java/convert-powerpoint-to-animated-gif/), einer [HTML5 presentation](/slides/de/java/export-to-html5/) oder eines [video](/slides/de/java/convert-powerpoint-to-video/) sollten Sie vor dem Export genaue Übergangsdauern festlegen, um das gewünschte Tempo zu erreichen. Verwenden Sie beispielsweise einen 600‑Millisekunden‑Fade zwischen Szenen und passen Sie jede Folien‑Verzögerung separat an, damit genug Zeit für die Erzählung oder den Inhalt bleibt.

Für GIF und Video koordinieren Sie die Ausgabebildrate mit der Effektdauer: 600 Millisekunden entsprechen 18 Frames bei 30 Frames pro Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Exporteinstellungen. Prüfen Sie die unterstützten Effekte und Timing‑Optionen des gewählten Exportformats und überprüfen Sie die Vorschau, um die Synchronisation zu bestätigen.

### **Eine vorhandene Übergangsdauer auslesen**

Rufen Sie [getDuration](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#getDuration--) auf, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer gesetzt ist; ein nicht‑negative Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides verwendet den Übergangstyp und den [getSpeed](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#getSpeed--)‑Wert, um diese Dauer zu bestimmen. Das Setzen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zuerst die Originaleinstellungen prüfen.

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

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, duplizieren Sie eine Folie, verschieben oder skalieren ein Objekt auf der Kopie und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhält der Übergang die entsprechenden Objekte, die zwischen ihrem Ausgangs‑ und geänderten Zustand animiert werden.

Das folgende Beispiel erstellt eine Folie mit einem Textrechteck, dupliziert die Folie und ändert die Position und Größe des Rechtecks auf der Kopie. Anschließend wählt es Morph aus der [TransitionType](https://reference.aspose.com/slides/de/java/com.aspose.slides/transitiontype/)-Aufzählung für die zweite Folie aus. Öffnen Sie die gespeicherte Datei in einem Präsentationsviewer, der Morph unterstützt, um den Effekt während einer Diashow zu sehen.

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

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/de/java/com.aspose.slides/transitionmorphtype/) steuert, wie Morph Inhalte abgleicht und animiert:

- [ByObject](https://reference.aspose.com/slides/de/java/com.aspose.slides/transitionmorphtype/#ByObject) behandelt jede Form als ein ganzes Objekt.
- [ByWord](https://reference.aspose.com/slides/de/java/com.aspose.slides/transitionmorphtype/#ByWord) animiert Text, indem wo möglich Wörter abgeglichen werden.
- [ByChar](https://reference.aspose.com/slides/de/java/com.aspose.slides/transitionmorphtype/#ByChar) animiert Text, indem wo möglich Zeichen abgeglichen werden.

Verwenden Sie [setType](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#setType-int-) zum Auswählen von Morph, bevor Sie [getValue](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#getValue--) aufrufen. Der zurückgegebene Wert liefert die [IMorphTransition](https://reference.aspose.com/slides/de/java/com.aspose.slides/imorphtransition/)-Schnittstelle, deren [setMorphType](https://reference.aspose.com/slides/de/java/com.aspose.slides/imorphtransition/#setMorphType-int-)‑Methode den Abgleichmodus auswählt.

Dieses Beispiel öffnet die in dem vorherigen Abschnitt erstellte Präsentation und konfiguriert die zweite Folie so, dass sie eine wortbasierte Morph‑Animation verwendet.

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

Einige Übergänge bieten zusätzliche Optionen, etwa Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom mit [setType](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#setType-int-) ausgewählten Übergang ab. Setzen Sie zuerst den Typ und verwenden Sie dann die passende Schnittstelle von [getValue](https://reference.aspose.com/slides/de/java/com.aspose.slides/islideshowtransition/#getValue--).

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es ruft [setFromBlack](https://reference.aspose.com/slides/de/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) über [IOptionalBlackTransition](https://reference.aspose.com/slides/de/java/com.aspose.slides/ioptionalblacktransition/) auf, sodass der Übergang von einem schwarzen Bildschirm startet.

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

Ja. Verwenden Sie [setDuration], wenn Sie eine exakte Effektdauer in Millisekunden benötigen. Verwenden Sie [setSpeed], wenn eine vordefinierte [TransitionSpeed]-Kategorie (Slow, Medium oder Fast) ausreicht und keine explizite Dauer gesetzt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der Verzögerung für das automatische Vorwärtsspringen.

**Kann ich einer Folie einen Ton zuweisen und ihn wiederholen lassen?**

Ja. Weisen Sie eingebetteten Ton mit [setSound] zu, übergeben Sie `StartSound` aus der Aufzählung [TransitionSoundMode] an [setSoundMode] und aktivieren Sie [setSoundLoop] mit `true`. Der Ton wird wiederholt, bis das nächste Tonevent in der Diashow eintritt.

**Wie ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Durchlaufen Sie die [getSlides]-Sammlung der Präsentation und rufen Sie für jede Folie [setType] mit demselben Wert auf. Setzen Sie Timing‑ und Effektoptionen im selben Schleifendurchlauf, um ein konsistentes Verhalten über alle Folien hinweg zu gewährleisten.

**Wie kann ich prüfen, welcher Übergang derzeit für eine Folie eingestellt ist?**

Rufen Sie [getType] auf dem Ergebnis von [getSlideShowTransition] der Folie auf. Es wird ein Wert aus der Aufzählung [TransitionType] zurückgegeben; `None` bedeutet, dass kein Übergangseffekt angewendet wurde.