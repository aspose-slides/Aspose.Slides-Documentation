---
title: Verwalten von Folienübergängen in Präsentationen mit PHP
linktitle: Folienübergang
type: docs
weight: 80
url: /de/php-java/slide-transition/
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
- PHP
- Aspose.Slides
description: "Folienübergänge anwenden, die automatische Folienweiterleitung konfigurieren und Morph sowie andere Übergangseffekte mit Aspose.Slides für PHP via Java anpassen."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Bildschirmpräsentation angezeigt werden. Mit Aspose.Slides für PHP via Java können Sie für jede Folie einen Übergangseffekt auswählen, den Fortschritt per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen vornehmen. Dieser Artikel verwendet PHP‑Beispiele, um Übergänge anzuwenden, genaue Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen außerdem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse und greifen über [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) auf die Übergangseinstellungen der Folie zu. Verwenden Sie [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) mit einem Wert aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), und speichern Sie anschließend die Präsentation.

Das folgende Beispiel wendet einen Circle‑Übergang auf die erste Folie und einen Comb‑Übergang auf die zweite Folie an. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

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

## **Wheel Transition**

Die Methode [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) steuert, wie viele radiale Sektoren die Ziel‑Folien enthüllen. Verwenden Sie [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType), um Wheel aus [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) auszuwählen, und rufen Sie anschließend [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) auf, um auf die Einstellungen des [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) zuzugreifen.

Das Beispiel erstellt zwei identische Paare von Folien. Jedes Paar beginnt mit einer schwarzen Folie und endet mit einer Folie, die von einem goldenen Rechteck bedeckt ist. Folie 2 verwendet einen Strahl und Folie 4 acht Strahlen. Beide Übergänge verwenden dieselbe langsame Geschwindigkeit, die mit [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) festgelegt wird, und eine explizite Dauer von 8 000 Millisekunden, die mit [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) gesetzt wird.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Öffnen Sie die gespeicherte Präsentation in PowerPoint und starten Sie die Bildschirmpräsentation. Wechseln Sie von Folie 1 zu Folie 2, um einen einzelnen im Uhrzeigersinn verlaufenden Sweep zu sehen. Wechseln Sie dann von Folie 3 zu Folie 4, um acht radiale Sektoren zu sehen, die das gleiche Rechteck gleichzeitig enthüllen.

## **Erweiterten Folienübergang hinzufügen**

Sie können konfigurieren, wie lange eine Folie auf dem Bildschirm bleibt und ob ein Mausklick die Bildschirmpräsentation voranbringt. Die folgenden Methoden steuern dieses Verhalten:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ermöglicht dem Betrachter, per Mausklick weiterzublättern.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) aktiviert die automatische Weiterleitung.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) gibt die Verzögerung vor, bevor die Folie automatisch weiterblättert, in Millisekunden.

Aktivieren Sie sowohl Klick‑ als auch Zeit‑Weiterleitung, damit der Betrachter entweder per Klick weitergehen oder warten kann. Um nur den Timer zu verwenden, übergeben Sie `false` an [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Die Verzögerung bestimmt, wann die Präsentation weitergeht; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien verschiedene Effekte zu und aktiviert die automatische Weiterleitung nach 3 s, 5 s bzw. 7 s. Mausklicks können diese Folien ebenfalls weiterleiten. Verwenden Sie eine `input.pptx`‑Datei mit mindestens drei Folien.

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

Um zu prüfen, ob die zeitgesteuerte Weiterleitung aktiviert ist, rufen Sie [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) auf. Ein gespeicherter Verzögerungswert allein zeigt nicht, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, gibt für jede aktivierte Zeitangabe eine Meldung aus und deaktiviert die automatische Weiterleitung für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien wird der Mausklick wieder aktiviert und die aktualisierten Einstellungen werden gespeichert.

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

## **Übergangszeit präzise steuern**

Verwenden Sie [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration), um die genaue Länge eines Übergangseffekts in Millisekunden festzulegen. Die Methode [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie gibt über das Objekt [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) Zugriff auf diese Einstellungen:

| Methode | Zweck |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Legt die Dauer des eigentlichen Übergangseffekts in Millisekunden fest. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Legt die Verzögerung fest, bevor die Folie automatisch weiterblättert, in Millisekunden. Aktivieren Sie den Timer, indem Sie `true` an [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) übergeben. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium oder Fast. Sie wird verwendet, wenn keine exakte Dauer angegeben ist. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) beeinflusst nur den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Die automatische Weiterleitungs-Verzögerung muss separat konfiguriert werden. Wenn keine explizite Dauer gesetzt ist, ermittelt Aspose.Slides die Effektdauer aus dem Übergangstyp und dem Wert von [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Separate Balken zeigen die 750‑ms Übergangsdauer und die 5 000‑ms automatische Weiterleitungs‑Einstellung.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Das gezeigte Beispiel weist jeder Folie einen 750‑ms Fade‑Übergang zu und aktiviert separat die automatische Weiterleitung nach 5 000 ms. Die Übergangsdauer steuert den Effekt; die Weiterleitung bestimmt, wann die Folie verlassen wird. Diese Balken sind schematische Einstellungen, nicht eine gemessene kombinierte Zeitleiste.*
<!-- visual-explanation:slide-transition:end -->

### **Gleiche Dauer auf alle Folien anwenden**

Für ein einheitliches Tempo wenden Sie denselben Effekt und dieselbe exakte Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert separat die automatische Weiterleitung nach 5 000 Millisekunden, deaktiviert die Weiterleitung per Mausklick und speichert das Ergebnis als PPTX.

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

        // Automatisches Vorwärtsschalten unabhängig von der Effektdauer konfigurieren.
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

Verschiedene Folien können unterschiedliche Effektdauern besitzen. Beispielsweise kann eine Titelfolie einen kurzen Übergang erhalten, während eine Abschnittseinleitung einen längeren Übergang bekommt. Dieses Beispiel setzt 500 Millisekunden für die erste Folie und 1 200 Millisekunden für die zweite. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

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

Wenn Sie ein [animated GIF](/slides/de/php-java/convert-powerpoint-to-animated-gif/), eine [HTML5 presentation](/slides/de/php-java/export-to-html5/) oder ein [video](/slides/de/php-java/convert-powerpoint-to-video/) erstellen, setzen Sie exakte Übergangsdauern vor dem Export, um das gewünschte Tempo zu erreichen. Beispielsweise können Sie einen 600‑ms Fade‑Übergang zwischen Szenen verwenden und für jede Folie die Weiterleitungs‑Verzögerung separat einstellen, um Zeit für Erzählen oder Inhalte zu lassen.

Für GIF und Video koordinieren Sie die Bildrate des Outputs mit der Effektdauer: 600 ms entsprechen 18 Frames bei 30 Frames pro Sekunde. In HTML5 aktivieren Sie animierte Übergänge in den Exportoptionen. Prüfen Sie die vom gewählten Exportformat unterstützten Effekte und Zeiteinstellungen und betrachten Sie eine Vorschau, um die Synchronisation zu bestätigen.

### **Bestehende Übergangsdauer lesen**

Rufen Sie [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) auf, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Der Wert `-1` bedeutet, dass keine explizite Dauer gesetzt ist; ein nicht‑negativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides ermittelt die Dauer aus dem Übergangstyp und dem Wert von [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed). Das Setzen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zunächst die Originaleinstellungen prüfen.

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

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, duplizieren Sie eine Folie, verschieben oder skalieren Sie ein Objekt auf der Kopie und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die entsprechenden Objekte einen Animationspfad zwischen ihrem ursprünglichen und modifizierten Zustand.

Das folgende Beispiel erstellt eine Folie mit einem Text‑Rechteck, dupliziert die Folie und ändert Position und Größe des Rechtecks auf der Kopie. Anschließend wählt es Morph aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) für die zweite Folie aus. Öffnen Sie die gespeicherte Datei in einem Präsentationsviewer, der Morph unterstützt, um den Effekt während einer Bildschirmpräsentation zu sehen.

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

Die Aufzählung [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) steuert, wie Morph Inhalte zuordnet und animiert:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) behandelt jede Form als ganzes Objekt.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) animiert Text, indem nach Möglichkeit Wörter zugeordnet werden.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) animiert Text, indem nach Möglichkeit Zeichen zugeordnet werden.

Verwenden Sie [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType), um Morph auszuwählen, bevor Sie [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) aufrufen. Der erhaltene Wert liefert ein [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/)-Objekt, dessen Methode [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) den Zuordnungsmodus festlegt.

Dieses Beispiel öffnet die im vorherigen Abschnitt erstellte Präsentation und konfiguriert die zweite Folie so, dass sie eine wortbasierte Morph‑Animation verwendet.

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

Einige Übergänge bieten zusätzliche Optionen, etwa Richtung oder ob der Effekt von einem schwarzen Bildschirm ausgeht. Die verfügbaren Optionen hängen vom mit [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) ausgewählten Übergang ab. Setzen Sie zuerst den Typ und verwenden Sie dann das passende Übergangsobjekt aus [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es ruft [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) über [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) auf, sodass der Übergang von einem schwarzen Bildschirm startet.

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

Ja. Verwenden Sie [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration), wenn Sie eine exakte Effektdauer in Millisekunden benötigen. Nutzen Sie [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), wenn eine vordefinierte Kategorie aus [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) – Slow, Medium oder Fast – ausreicht und keine explizite Dauer gesetzt ist. Diese Einstellungen beeinflussen den Übergangseffekt unabhängig von der automatischen Weiterleitungs‑Verzögerung.

**Kann ich einem Übergang Audio anhängen und es wiederholen?**

Ja. Weisen Sie eingebettetes Audio mit [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) zu, übergeben Sie `StartSound` aus der Aufzählung [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) an [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) und aktivieren Sie [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) mit `true`. Das Audio wird wiederholt, bis das nächste Sound‑Ereignis in der Präsentation eintritt.

**Wie kann ich am schnellsten denselben Übergang auf alle Folien anwenden?**

Durchlaufen Sie die [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides)-Sammlung der Präsentation und rufen Sie für jede Folie [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) mit demselben Wert auf. Setzen Sie eventuelle Zeit‑ und Effektoptionen im selben Durchlauf, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich prüfen, welcher Übergang aktuell für eine Folie eingestellt ist?**

Rufen Sie [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) auf dem Ergebnis von [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie auf. Der Rückgabewert stammt aus der Aufzählung [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); `None` bedeutet, dass kein Übergangseffekt angewendet wurde.