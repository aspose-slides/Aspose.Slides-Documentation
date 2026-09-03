---
title: Folienübergänge in Präsentationen mit PHP verwalten
linktitle: Folienübergang
type: docs
weight: 80
url: /de/php-java/slide-transition/
keywords:
- Folienübergang
- Folienübergang hinzufügen
- Folienübergang anwenden
- erweiterter Folienübergang
- Morph-Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Folienübergänge anwenden, automatisches Vorankommen der Folien konfigurieren und Morph sowie andere Übergangseffekte mit Aspose.Slides für PHP über Java anpassen."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Bildschirmpräsentation angezeigt werden. Mit Aspose.Slides für PHP über Java können Sie für jede Folie einen Übergangseffekt auswählen, den Fortschritt per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen anpassen. Dieser Artikel verwendet PHP-Beispiele, um Übergänge anzuwenden, genaue Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen zudem, wie die Einstellungen in eine PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse und greifen Sie über [getSlideShowTransition](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/#getSlideShowTransition) auf die Übergangseinstellungen der Folie zu. Verwenden Sie [setType](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setType) mit einem Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/php-java/aspose.slides/transitiontype/), dann speichern Sie die Präsentation.

Das folgende Beispiel wendet einen Kreis‑Übergang auf die erste Folie und einen Kamm‑Übergang auf die zweite Folie an. Verwenden Sie eine Datei `input.pptx` mit mindestens zwei Folien.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Erweiterten Folienübergang hinzufügen**

Sie können konfigurieren, wie lange eine Folie auf dem Bildschirm bleibt und ob ein Mausklick die Präsentation voranbringt. Die folgenden Methoden steuern dieses Verhalten:

- [setAdvanceOnClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ermöglicht dem Betrachter das Vorankommen durch Mausklick.
- [setAdvanceAfter](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) aktiviert die automatische Vorwärtsbewegung.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) legt die Verzögerung vor der automatischen Vorwärtsbewegung in Millisekunden fest.

Aktivieren Sie sowohl Klick‑ als auch Timer‑Vorwärtsbewegung, damit der Betrachter entweder per Klick weitergehen oder auf den Timer warten kann. Um nur den Timer zu verwenden, übergeben Sie `false` an [setAdvanceOnClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Die Verzögerung bestimmt, wann die Präsentation voranschreitet; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert die automatische Vorwärtsbewegung nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls weiterführen. Verwenden Sie eine Datei `input.pptx` mit mindestens drei Folien.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Um zu prüfen, ob die zeitgesteuerte Vorwärtsbewegung aktiviert ist, rufen Sie [getAdvanceAfter](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) auf. Ein gespeicherter Verzögerungswert allein zeigt nicht an, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, gibt für jede aktivierte Zeitschaltuhr eine Meldung aus und deaktiviert die automatische Vorwärtsbewegung für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien wird der Mausklick aktiviert und die geänderten Einstellungen werden gespeichert.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Übergangszeit genau steuern**

Verwenden Sie [setDuration](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setDuration), um die exakte Länge eines Übergangseffekts in Millisekunden festzulegen. Die Methode [getSlideShowTransition](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie stellt diese Einstellungen über [SlideShowTransition](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/) bereit:

| Methode | Zweck |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setDuration) | Legt die Dauer des Übergangseffekts selbst in Millisekunden fest. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Legt die Verzögerung fest, bevor die Folie automatisch weitergeschaltet wird, in Millisekunden. Übergeben Sie `true` an [setAdvanceAfter](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter), um diesen Timer zu aktivieren. |
| [setSpeed](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setSpeed) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/de/php-java/aspose.slides/transitionspeed/): Slow, Medium oder Fast. Sie wird verwendet, wenn keine exakte Dauer angegeben ist. |

[setDuration](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setDuration) steuert nur den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Die Verzögerung für die automatische Vorwärtsbewegung muss separat konfiguriert werden. Wenn keine explizite Dauer gesetzt ist, ermittelt Aspose.Slides die Effektdauer aus dem Übergangstyp und dem Wert von [getSpeed](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#getSpeed).

### **Gleiche Dauer auf jeder Folie anwenden**

Für ein konstant gleichmäßiges Tempo wenden Sie denselben Effekt und dieselbe exakte Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/de/php-java/aspose.slides/transitiontype/) und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert zudem automatisch die Vorwärtsbewegung nach 5.000 Millisekunden und deaktiviert die Vorwärtsbewegung per Mausklick, dann wird das Ergebnis als PPTX gespeichert.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // Automatisches Vorankommen unabhängig von der Effektdauer konfigurieren.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Unterschiedliche Dauern für einzelne Folien festlegen**

Verschiedene Folien können unterschiedliche Effektdauern verwenden. Beispielsweise kann ein Titel‑Slide einen kurzen Übergang erhalten, während ein Abschnitts‑Intro einen längeren Übergang nutzt. Dieses Beispiel legt 500 Millisekunden für die erste Folie und 1.200 Millisekunden für die zweite Folie fest. Verwenden Sie eine Datei `input.pptx` mit mindestens zwei Folien.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Übergänge mit animierter Ausgabe koordinieren**

Wenn Sie ein [animiertes GIF](/slides/de/php-java/convert-powerpoint-to-animated-gif/), eine [HTML5‑Präsentation](/slides/de/php-java/export-to-html5/) oder ein [Video](/slides/de/php-java/convert-powerpoint-to-video/) erstellen, setzen Sie exakte Übergangsdauern vor dem Export, um das gewünschte Tempo zu treffen. Verwenden Sie z. B. ein 600‑Millisekunden‑Fade zwischen Szenen und passen Sie die Vorwärtsbewegungs‑Verzögerung jeder Folie separat an, um Zeit für die jeweiligen Erzählungen oder Inhalte zu lassen.

Für GIF und Video koordinieren Sie die Bildrate der Ausgabe mit der Effektdauer: 600 Millisekunden entsprechen 18 Frames bei 30 Frames‑pro‑Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Exporteinstellungen. Prüfen Sie die unterstützten Effekte und Zeiteinstellungen des gewählten Exportformats und prüfen Sie die Ausgabe, um die Synchronisation zu bestätigen.

### **Vorhandene Übergangsdauer auslesen**

Rufen Sie [getDuration](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#getDuration) auf, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer gesetzt ist; ein nicht‑negativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides ermittelt die Dauer aus dem Übergangstyp und dem Wert von [getSpeed](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#getSpeed). Das Setzen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zunächst die Originaleinstellungen prüfen.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Morph‑Übergang**

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erstellen, duplizieren Sie eine Folie, verschieben oder skalieren Sie ein Objekt auf der Kopie und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die zugehörigen Objekte eine Animation zwischen ihrem ursprünglichen und geänderten Zustand.

Das folgende Beispiel erstellt eine Folie mit einem Text‑Rechteck, dupliziert die Folie und ändert Position sowie Größe des Rechtecks auf der Kopie. Anschließend wird Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/php-java/aspose.slides/transitiontype/) für die zweite Folie ausgewählt. Öffnen Sie die gespeicherte Datei in einem Präsentations‑Viewer, der Morph unterstützt, um den Effekt während einer Bildschirmpräsentation zu sehen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Morph‑Übergangstypen**

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/de/php-java/aspose.slides/transitionmorphtype/) bestimmt, wie Morph Inhalte zuordnet und animiert:

- [ByObject](https://reference.aspose.com/slides/de/php-java/aspose.slides/transitionmorphtype/#ByObject) behandelt jede Form als Ganzes.
- [ByWord](https://reference.aspose.com/slides/de/php-java/aspose.slides/transitionmorphtype/#ByWord) animiert Text, indem nach Möglichkeit Wörter zugeordnet werden.
- [ByChar](https://reference.aspose.com/slides/de/php-java/aspose.slides/transitionmorphtype/#ByChar) animiert Text, indem nach Möglichkeit Zeichen zugeordnet werden.

Verwenden Sie [setType](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setType), um Morph auszuwählen, bevor Sie [getValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#getValue) aufrufen. Der zurückgegebene Wert liefert ein [MorphTransition](https://reference.aspose.com/slides/de/php-java/aspose.slides/morphtransition/)-Objekt, dessen Methode [setMorphType](https://reference.aspose.com/slides/de/php-java/aspose.slides/morphtransition/#setMorphType) den Zuordnungsmodus auswählt.

Dieses Beispiel öffnet die im vorherigen Abschnitt erstellte Präsentation und konfiguriert die zweite Folie so, dass die Wort‑basierte Morph‑Animation verwendet wird.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Übergangseffekte festlegen**

Einige Übergänge bieten zusätzliche Optionen, z. B. Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom mit [setType](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setType) gewählten Übergang ab. Setzen Sie zuerst den Typ und verwenden Sie dann das passende Übergangsobjekt aus [getValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#getValue).

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es ruft [setFromBlack](https://reference.aspose.com/slides/de/php-java/aspose.slides/optionalblacktransition/#setFromBlack) über [OptionalBlackTransition](https://reference.aspose.com/slides/de/php-java/aspose.slides/optionalblacktransition/) auf, sodass der Übergang von einem schwarzen Bildschirm startet.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Kann ich die Wiedergabegeschwindigkeit eines Folienübergangs steuern?**

Ja. Verwenden Sie vorzugsweise [setDuration](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setDuration), wenn Sie eine exakte Effektdauer in Millisekunden benötigen. Nutzen Sie [setSpeed](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setSpeed), wenn eine vordefinierte [TransitionSpeed](https://reference.aspose.com/slides/de/php-java/aspose.slides/transitionspeed/)-Kategorie – Slow, Medium oder Fast – ausreicht und keine explizite Dauer festgelegt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der Verzögerung für die automatische Vorwärtsbewegung.

**Kann ich einer Folienübergang Audio hinzufügen und es wiederholen?**

Ja. Weisen Sie eingebettetes Audio mit [setSound](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setSound) zu, übergeben Sie `StartSound` aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/transitionsoundmode/) an [setSoundMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setSoundMode) und aktivieren Sie [setSoundLoop](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setSoundLoop) mit `true`. Das Audio wird wiederholt, bis das nächste Sound‑Ereignis in der Präsentation eintritt.

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Durchlaufen Sie die [getSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSlides)-Sammlung der Präsentation und rufen Sie für jede Folie [setType](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#setType) mit demselben Wert auf. Setzen Sie eventuelle Zeit‑ und Effektoptionen innerhalb derselben Schleife, um ein konsistentes Verhalten über alle Folien hinweg zu gewährleisten.

**Wie kann ich prüfen, welcher Übergang derzeit für eine Folie eingestellt ist?**

Rufen Sie [getType](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideshowtransition/#getType) auf dem Ergebnis von [getSlideShowTransition](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie auf. Der zurückgegebene Wert stammt aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/de/php-java/aspose.slides/transitiontype/); `None` bedeutet, dass kein Übergangseffekt angewendet ist.