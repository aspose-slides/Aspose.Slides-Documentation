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
- Morph‑Übergang
- Übergangstyp
- Übergangseffekt
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Wenden Sie Folienübergänge an, konfigurieren Sie den automatischen Folienfortschritt und passen Sie Morph‑ und andere Übergangseffekte mit Aspose.Slides für PHP via Java an."
---
## **Übersicht**

Folienübergänge steuern, wie Folien während einer Diashow angezeigt werden. Mit Aspose.Slides für PHP via Java können Sie für jede Folie einen Übergangseffekt auswählen, den Fortschritt per Mausklick oder Timer konfigurieren und optionsspezifische Einstellungen eines Effekts anpassen. Dieser Artikel verwendet PHP‑Beispiele, um Übergänge anzuwenden, exakte Übergangsdauern festzulegen, die Folienzeit zu verwalten und einen Morph‑Übergang zwischen zwei Folien zu erstellen. Die Beispiele zeigen zudem, wie die Einstellungen in einer PPTX‑Datei gespeichert werden.

## **Folienübergang hinzufügen**

Um einen Übergang anzuwenden, laden Sie eine Präsentation mit der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse und greifen über [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) auf die Übergangseinstellungen der Folie zu. Verwenden Sie [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) mit einem Wert aus der [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)-Aufzählung und speichern Sie anschließend die Präsentation.

Das folgende Beispiel wendet einen Circle‑Übergang auf die erste Folie und einen Comb‑Übergang auf die zweite an. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

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

## **Radial‑Übergang**

Die [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes)‑Methode steuert, wie viele radiale Sektoren die Ziel‑Folie enthüllen. Verwenden Sie [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType), um Wheel aus der [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)-Aufzählung auszuwählen, und rufen Sie anschließend [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) auf, um auf die [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/)-Einstellungen zuzugreifen.

Das Beispiel erstellt zwei identische Folienpaare. Jedes Paar beginnt mit einer schwarzen Folie und endet mit einer Folie, die von einem goldenen Rechteck bedeckt ist. Folie 2 verwendet einen Strahl, Folie 4 acht Strahlen. Beide Übergänge nutzen dieselbe langsame Geschwindigkeit, die mit [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) festgelegt wird, und eine explizite Dauer von 8 000 Millisekunden, die mit [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) gesetzt wird.

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

Öffnen Sie die gespeicherte Präsentation in PowerPoint und starten Sie die Diashow. Wechseln Sie von Folie 1 zu Folie 2, um einen einzelnen, im Uhrzeigersinn verlaufenden Sweep zu sehen. Wechseln Sie dann von Folie 3 zu Folie 4, um acht radiale Sektoren zu beobachten, die das gleiche Rechteck gleichzeitig enthüllen.

## **Einblenden durch Schwarz mit dem Reveal‑Übergang**

Setzen Sie den Übergangstyp der Ziel‑Folie auf Reveal und rufen Sie dann [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) für deren [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/)‑Einstellungen auf. Das Beispiel erstellt eine türkisfarbene Quell‑Folie und eine korallenfarbene Ziel‑Folie und klont beide. Jedes Paar verwendet denselben zweisekündigen Reveal‑Übergang. Nur das zweite Paar blendet durch Schwarz ein.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Öffnen Sie die gespeicherte Präsentation in PowerPoint und starten Sie die Diashow. Wechseln Sie von Folie 1 zu Folie 2, um ein direktes Einblenden von Türkis nach Koralle zu sehen. Dann wechseln Sie von Folie 3 zu Folie 4. Der Bildschirm verdunkelt sich kurz fast vollständig, bevor die Korallen‑Folie erscheint. Beide Folien behalten ihre ursprünglichen Hintergrundfarben bei.

Die nachstehenden Reihen zeigen Frames aus PowerPoint im Abstand von einer halben Sekunde. Vergleichen Sie den mittleren Frame jeder Reihe, um den Effekt zu sehen.

![PowerPoint‑Wiedergabe mit deaktiviertem Einblenden durch Schwarz (oben) und aktiviertem (unten). Nur die untere Reihe blendet nahe Schwarz ein.](reveal-through-black.png)

## **Erweiterten Folienübergang hinzufügen**

Sie können konfigurieren, wie lange eine Folie angezeigt wird und ob ein Mausklick die Diashow voranbringt. Die folgenden Methoden steuern dieses Verhalten:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ermöglicht dem Betrachter, per Mausklick weiterzugehen.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) aktiviert den automatischen Fortschritt.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) gibt die Verzögerung vor dem automatischen Fortschritt in Millisekunden an.

Aktivieren Sie sowohl Klick‑ als auch Zeit‑Fortschritt, damit der Betrachter entweder per Klick weitergeht oder auf den Timer wartet. Um nur den Timer zu nutzen, übergeben Sie `false` an [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Die Verzögerung bestimmt, wann die Diashow voranschreitet; sie legt nicht die Dauer des visuellen Übergangseffekts fest.

Dieses Beispiel weist den ersten drei Folien unterschiedliche Effekte zu und aktiviert den automatischen Fortschritt nach 3, 5 bzw. 7 Sekunden. Mausklicks können diese Folien ebenfalls voranbringen. Verwenden Sie eine `input.pptx`‑Datei mit mindestens drei Folien.

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

Um zu prüfen, ob der zeitgesteuerte Fortschritt aktiviert ist, rufen Sie [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) auf. Ein gespeicherter Verzögerungswert allein bedeutet nicht, dass der Timer aktiv ist.

Das nächste Beispiel öffnet die oben gespeicherte Datei, meldet jeden aktivierten Timer und deaktiviert den automatischen Fortschritt für Folien mit einer Verzögerung von mehr als zwei Sekunden. Für diese Folien werden Mausklicks aktiviert und die aktualisierten Einstellungen gespeichert.

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

## **Übergangszeitpunkt präzise steuern**

Verwenden Sie [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration), um die genaue Länge eines Übergangseffekts in Millisekunden anzugeben. Die [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition)‑Methode der Folie stellt diese Einstellungen über [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) bereit:

| Methode | Zweck |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Legt die Dauer des eigentlichen Übergangseffekts in Millisekunden fest. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Legt die Verzögerung fest, bevor die Folie automatisch weitergeht, in Millisekunden. Übergeben Sie `true` an [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter), um diesen Timer zu aktivieren. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Wählt eine vordefinierte Geschwindigkeitskategorie aus [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium oder Fast. Sie wird verwendet, wenn keine exakte Dauer angegeben ist. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) steuert nur den Übergangseffekt; sie bestimmt nicht, wie lange die Folie sichtbar bleibt. Konfigurieren Sie die Verzögerung für den automatischen Fortschritt separat. Wenn keine explizite Dauer gesetzt ist, ermittelt Aspose.Slides die Effekt‑Dauer aus dem Übergangstyp und dem [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed)-Wert.

<!-- visual-explanation:slide-transition:start -->
[![Separate Balken zeigen die 750‑ms‑Übergangsdauer und die 5 000‑ms‑automatische Fortschritts‑Einstellung an.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Das gemeinsam genutzte Beispiel gibt jeder Folie einen 750‑ms‑Fade‑Übergang und aktiviert separat den automatischen Fortschritt nach 5 000 ms. Die Übergangsdauer steuert den Effekt; der Fortschritt bestimmt, wann die Folie verlassen wird. Diese Balken sind schematische Einstellungen, kein gemessener kombinierter Zeitstrahl.*
<!-- visual-explanation:slide-transition:end -->

### **Gleiche Dauer für jede Folie anwenden**

Für ein gleichmäßiges Tempo wenden Sie denselben Effekt und dieselbe exakte Dauer auf jede Folie an. Dieses Beispiel lädt `input.pptx`, wählt Fade aus der [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)-Aufzählung und gibt jedem Übergang eine Dauer von 750 Millisekunden. Es aktiviert separat den automatischen Fortschritt nach 5 000 Millisekunden und deaktiviert den Fortschritt per Mausklick, bevor das Ergebnis als PPTX gespeichert wird.

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

        // Automatisches Voranschreiten unabhängig von der Effektdauer konfigurieren.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Verschiedene Dauern für einzelne Folien festlegen**

Unterschiedliche Folien können verschiedene Effekt‑Dauern haben. Zum Beispiel einen kurzen Übergang für eine Titelfolie und einen längeren für eine Abschnittseinleitung. Dieses Beispiel setzt 500 Millisekunden für die erste Folie und 1 200 Millisekunden für die zweite. Verwenden Sie eine `input.pptx`‑Datei mit mindestens zwei Folien.

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

### **Übergänge mit animierten Ausgaben koordinieren**

Beim Erstellen eines [animated GIF](/slides/de/php-java/convert-powerpoint-to-animated-gif/), einer [HTML5‑Präsentation](/slides/de/php-java/export-to-html5/) oder eines [Videos](/slides/de/php-java/convert-powerpoint-to-video/) sollten Sie vor dem Export exakte Übergangsdauern festlegen, um das gewünschte Tempo zu erreichen. Verwenden Sie zum Beispiel einen 600‑ms‑Fade zwischen Szenen und passen Sie jede Folien‑Fortschrittsverzögerung separat an, um Zeit für Erzählungen oder Inhalte zu lassen.

Für GIF‑ und Videoausgaben koordinieren Sie die Bildrate mit der Effekt‑Dauer: 600 ms entsprechen 18 Frames bei 30 fps. In HTML5 aktivieren Sie animierte Übergänge in den Export‑Einstellungen. Prüfen Sie die unterstützten Effekte und Zeitoptionen des gewählten Export‑Formats und prüfen Sie die Vorschau, um die Synchronisation zu bestätigen.

### **Bestehende Übergangsdauer auslesen**

Rufen Sie [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) auf, bevor Sie den Übergang ändern, um festzustellen, ob ein expliziter Wert gespeichert ist. Ein Wert von `-1` bedeutet, dass keine explizite Dauer gesetzt ist; ein nicht‑negativer Wert gibt die gespeicherte Dauer in Millisekunden an. Der nicht gesetzte Wert ist nicht die berechnete Wiedergabedauer: Aspose.Slides ermittelt die Dauer aus dem Übergangstyp und dem [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed)-Wert. Das Setzen eines Übergangstyps kann eine Dauer initialisieren, daher sollten Sie zuerst die ursprünglichen Einstellungen prüfen.

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

Der Morph‑Übergang animiert Änderungen zwischen Objekten auf aufeinanderfolgenden Folien. Um einen einfachen Morph‑Effekt zu erzeugen, klonen Sie eine Folie, verschieben oder skalieren ein Objekt auf dem Klon und wenden den Morph‑Übergang auf die zweite Folie an. Dadurch erhalten die entsprechenden Objekte einen Animationspfad von ihrem ursprünglichen zu ihrem geänderten Zustand.

Das folgende Beispiel erstellt eine Folie mit einem Text‑Rechteck, klont die Folie und ändert Position und Größe des Rechtecks im Klon. Anschließend wählt es Morph aus der [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)-Aufzählung für die zweite Folie aus. Öffnen Sie die gespeicherte Datei in einem Präsentations‑Viewer, der Morph unterstützt, um den Effekt während einer Diashow zu sehen.

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

Die [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/)‑Aufzählung bestimmt, wie Morph Inhalte abgleicht und animiert:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) behandelt jede Form als ganzes Objekt.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) animiert Text, indem nach Möglichkeit Wörter abgeglichen werden.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) animiert Text, indem nach Möglichkeit Zeichen abgeglichen werden.

Verwenden Sie [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType), um Morph auszuwählen, bevor Sie [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) aufrufen. Der zurückgegebene Wert liefert ein [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/)-Objekt, dessen [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType)‑Methode den Abgleichmodus auswählt.

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

Einige Übergänge bieten zusätzliche Optionen, etwa Richtung oder ob der Effekt von einem schwarzen Bildschirm startet. Die verfügbaren Optionen hängen vom mit [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) ausgewählten Übergang ab. Setzen Sie zuerst den Typ und verwenden Sie dann das passende Übergangs‑Objekt aus [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

Das folgende Beispiel wendet einen Cut‑Übergang auf die erste Folie von `input.pptx` an. Es ruft über [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) die Methode [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) auf, sodass der Übergang von einem schwarzen Bildschirm startet.

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

Ja. Verwenden Sie bevorzugt [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration), wenn Sie eine genaue Effekt‑Dauer in Millisekunden benötigen. Nutzen Sie [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), wenn eine vordefinierte [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/)-Kategorie – Slow, Medium oder Fast – ausreicht und keine explizite Dauer gesetzt ist. Diese Einstellungen steuern den Übergangseffekt unabhängig von der automatischen Fortschrittsverzögerung.

**Kann ich einem Übergang Audio hinzufügen und es wiederholen lassen?**

Ja. Weisen Sie eingebettetes Audio mit [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) zu, übergeben Sie `StartSound` aus der [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/)-Aufzählung an [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) und aktivieren Sie [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) mit `true`. Das Audio wiederholt sich, bis das nächste Sound‑Ereignis in der Diashow eintritt.

**Was ist der schnellste Weg, denselben Übergang auf jede Folie anzuwenden?**

Durchlaufen Sie die [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides)-Sammlung der Präsentation und rufen Sie für jede Folie [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) mit dem gleichen Wert auf. Setzen Sie Timing‑ und Effekt‑Optionen im selben Durchlauf, um das Verhalten über alle Folien hinweg konsistent zu halten.

**Wie kann ich prüfen, welcher Übergang aktuell einer Folie zugewiesen ist?**

Rufen Sie [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) auf dem Ergebnis von [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie auf. Es liefert einen Wert aus der [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)-Aufzählung; `None` bedeutet, dass kein Übergangseffekt angewendet ist.