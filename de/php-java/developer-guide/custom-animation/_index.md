---
title: Erstellen und Anpassen benutzerdefinierter Animationsverhalten in PHP
linktitle: Benutzerdefinierte Animation
type: docs
weight: 151
url: /de/php-java/custom-animation/
keywords:
- benutzerdefinierte Animation
- Animationsverhalten
- Bewegungspfad
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen, inspizieren und anpassen benutzerdefinierter Animationsverhalten und editierbarer Bewegungspfade in PowerPoint‑Präsentationen mit Aspose.Slides für PHP via Java."
---
## **Übersicht**

Benutzerdefinierte Animationsverhalten ermöglichen die Kontrolle einzelner Vorgänge innerhalb eines Animationseffekts, z. B. das Ändern einer Farbe, das Drehen einer Form oder das Folgen eines editierbaren Bewegungspfads. Dieser Leitfaden zeigt, wie man Verhaltensweisen erstellt und kombiniert, deren Timing konfiguriert, bestehende Animationen inspiziert und bearbeitet sowie überprüft, dass ihre Eigenschaften das Speichern und erneute Öffnen einer Präsentation überstehen.

Für vordefinierte Effekte und Klick‑Auslöser siehe [Formanimation](/slides/de/php-java/shape-animation/).

## **Verstehen des Animationsmodells**

Eine Animation ist strukturiert als **Timeline → Sequence → Effect → Behaviors**:

- Jede Folie besitzt eine Zeitleiste, die ihre Hauptsequenz und interaktive Sequenzen enthält.
- Eine [Sequence](https://reference.aspose.com/slides/de/php-java/aspose.slides/sequence/) enthält Effekte, die ggf. unterschiedliche Formen ansprechen.
- Ein [Effect](https://reference.aspose.com/slides/de/php-java/aspose.slides/effect/) identifiziert Ziel‑Form, Vorgabe, Untertyp und Timing des Effekts.
- Die von [Effect::getBehaviors](https://reference.aspose.com/slides/de/php-java/aspose.slides/effect/getbehaviors/) zurückgegebene Sammlung enthält die Vorgänge, die den Effekt umsetzen: Farbwechsel, Verschieben, Drehen, Setzen einer Eigenschaft usw.

## **Einzelne Verhaltensweisen erstellen**

Rufen Sie [Sequence::addEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/sequence/addeffect/) auf, um einen Effekt zu erzeugen und auf die [getBehaviors](https://reference.aspose.com/slides/de/php-java/aspose.slides/effect/getbehaviors/)‑Sammlung zuzugreifen. Eine Vorgabe kann diese Sammlung automatisch füllen. Behalten Sie deren Vorgänge bei, wenn Sie die Vorgabe erweitern, oder verwenden Sie [clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorcollection/clear/), wenn Sie sie bewusst ersetzen wollen.

[BehaviorFactory](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorfactory/) erzeugt die acht unten dargestellten Verhaltensarten. Bewegung wird in [Build a Motion Path](#build-a-motion-path) behandelt. Jeder Code‑Abschnitt enthält die erforderlichen Importe und setzt voraus, dass die PHP/Java‑Bridge und die Aspose.Slides‑PHP‑Bibliothek geladen sind. Spätere Bearbeitungsbeispiele geben an, welche Ausgabedatei sie verwenden.

### **Drehung**

Verwenden Sie [createRotationEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorfactory/createrotationeffect/), um eine Drehung zu erzeugen. [getBy](https://reference.aspose.com/slides/de/php-java/aspose.slides/rotationeffect/getby/) gibt einen relativen Winkel in Grad an; [getFrom](https://reference.aspose.com/slides/de/php-java/aspose.slides/rotationeffect/getfrom/) und [getTo](https://reference.aspose.com/slides/de/php-java/aspose.slides/rotationeffect/getto/) geben Endpunkte an.

Das Beispiel beginnt mit einem Spin‑Effekt, ersetzt seine Vorgabevergänge durch ein Dreh‑Verhalten und weist diesem Vorgang eine Dauer von zwei Sekunden zu. Ein relativer Winkel von 90 Grad entspricht einer Vierteldrehung von der Ausgangsausrichtung der Form, sodass kein expliziter Startwinkel nötig ist.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` enthält eine Form und ein Dreh‑Verhalten. Die unten gezeigten Beispiele für Sammlung, Timing und Dreh‑Bearbeitung verwenden diese Datei.

### **Skalierung**

Verwenden Sie [createScaleEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorfactory/createscaleeffect/) mit X/Y‑Prozentsätzen: [getFrom](https://reference.aspose.com/slides/de/php-java/aspose.slides/scaleeffect/getfrom/) und [getTo](https://reference.aspose.com/slides/de/php-java/aspose.slides/scaleeffect/getto/) beschreiben die Ausgangs‑ bzw. Endgröße, während [getBy](https://reference.aspose.com/slides/de/php-java/aspose.slides/scaleeffect/getby/) eine relative Änderung angibt. Hier bedeutet 100 % die Originalgröße.

Das Beispiel vergrößert beide Dimensionen von 100 % auf 125 % innerhalb von zwei Sekunden. Gleiche horizontale und vertikale Prozentsätze erhalten das Seitenverhältnis der Form; unterschiedliche Werte würden eine Dimension stärker strecken als die andere.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Farbe**

Verwenden Sie [createColorEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorfactory/createcoloreffect/), um die Füllung von Blau zu Orange zu ändern. [getFrom](https://reference.aspose.com/slides/de/php-java/aspose.slides/coloreffect/getfrom/) und [getTo](https://reference.aspose.com/slides/de/php-java/aspose.slides/coloreffect/getto/) sind Farben; [getBy](https://reference.aspose.com/slides/de/php-java/aspose.slides/coloreffect/getby/) ist ein Farb‑Offset. Die [BehaviorPropertyCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorpropertycollection/) des Verhaltens gibt das animierte Attribut an.

Die feste Füllung der Form wird initial auf Blau gesetzt, passend zur Ausgangsfarbe der Animation. Die Auswahl des Füll‑Farbattributs teilt dem Verhalten mit, welcher Teil der Form geändert werden soll; die Farbanfänge allein identifizieren das Attribut nicht. Der gespeicherte Effekt beschreibt einen zweisekündigen Übergang zu Orange.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Filter**

Verwenden Sie [createFilterEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorfactory/createfiltereffect/), um einen Wisch‑Effekt auszuwählen. [getType](https://reference.aspose.com/slides/de/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/de/php-java/aspose.slides/filtereffect/getsubtype/) und [getReveal](https://reference.aspose.com/slides/de/php-java/aspose.slides/filtereffect/getreveal/) geben den Filter, die Richtung und an, ob die Form gezeigt oder versteckt werden soll.

Dieses Beispiel konfiguriert einen zweisekündigen Wisch, der die Form in Richtung rechts sichtbar macht. Die Filtereinstellungen gehören zum Verhalten innerhalb des Effekts und werden daher konfiguriert, nachdem die ursprünglichen Vorgaben entfernt wurden.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Eigenschaft**

Verwenden Sie [createPropertyEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorfactory/createpropertyeffect/), um die Deckkraft zu animieren. [getFrom](https://reference.aspose.com/slides/de/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/de/php-java/aspose.slides/propertyeffect/getto/) und [getBy](https://reference.aspose.com/slides/de/php-java/aspose.slides/propertyeffect/getby/) sind Zeichenketten, die mit [getValueType](https://reference.aspose.com/slides/de/php-java/aspose.slides/propertyeffect/getvaluetype/) und [getCalcMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/propertyeffect/getcalcmode/) interpretiert werden. Wählen Sie Endpunkte oder einen relativen Offset, anstatt alle drei unkritisch zu setzen.

Hier ist das ausgewählte Attribut Deckkraft, und die numerischen Zeichenketten beschreiben eine Änderung von 25 % Deckkraft zu voller Deckkraft. Lineare Interpolation beschreibt einen allmählichen Übergang zwischen diesen Werten. Beim Anpassen dieses Beispiels an ein anderes Attribut wählen Sie einen geeigneten Werttyp und passende Endwerte.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Setzen**

Verwenden Sie [createSetEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorfactory/createseteffect/), um die Sichtbarkeit über [getTo](https://reference.aspose.com/slides/de/php-java/aspose.slides/seteffect/getto/) zuzuweisen. Ein Set‑Verhalten interpoliert nicht zwischen Endpunkten.

Das Beispiel wählt das Sichtbarkeits‑Attribut und weist beim Ausführen des Verhaltens die Zeichenkette `visible` zu. Das Rechteck ist in dieser Minimalpräsentation bereits sichtbar, sodass die Zuweisung allein keine offensichtliche visuelle Änderung bewirkt. Eine solche Operation ist nützlich als Teil eines größeren Effekts, der ebenfalls steuert, wann die Form verborgen oder sichtbar wird.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Befehl**

Verwenden Sie [createCommandEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorfactory/createcommandeffect/) und konfigurieren Sie [getType](https://reference.aspose.com/slides/de/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/de/php-java/aspose.slides/commandeffect/getcommandstring/) und [getShapeTarget](https://reference.aspose.com/slides/de/php-java/aspose.slides/commandeffect/getshapetarget/). Legen Sie im Arbeitsverzeichnis eine WAV‑Aufzeichnung namens `sample.wav` ab. Dieses Beispiel bettet sie mit [addAudioFrameEmbedded](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addaudioframeembedded/) ein und verbindet einen Abspiel‑Befehl mit dem Audio‑Frame.

Der Audio‑Frame ist sowohl Ziel des Effekts als auch Ziel des Befehls. Dadurch wird die Abspiel‑Anfrage mit der eingebetteten Aufnahme verknüpft; eine reine Befehlszeichenkette identifiziert nicht, welches Medienelement zu steuern ist. Der Effekt ist so konfiguriert, dass er bei einem Klick während der Diashow startet.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Das Speichern legt den Befehl in `command.pptx` ab; die Aufnahme wird nicht abgespielt. Für die Wiedergabe ist ein Diashow‑Player nötig, der den Befehl und sein Medientarget unterstützt.

## **Verwalten der Verhaltenssammlung**

[BehaviorCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorcollection/) unterstützt [add](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorcollection/remove/) und [removeAt](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorcollection/removeat/). Dieses Beispiel öffnet `rotation.pptx`, fügt Skalierung hinzu, verschiebt sie vor die Drehung und entfernt die Drehung. Das Entfernen und erneute Einfügen desselben Objekts ändert dessen gespeicherte Position, ohne eine Kopie zu erzeugen.

Die Abfolge der Bearbeitungen ändert die Sammlung von Drehung‑Skalierung zu Skalierung‑Drehung und schließlich zu reiner Skalierung. Indizes beziehen sich auf die aktuelle Sammlung, sodass das Entfernen den neuen Index der Drehung nach der Neuordnung verwendet. Die abschließende Aufzählung bestätigt, welches Verhalten gespeichert wird.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Ausgabe ist `ScaleEffect`: Es bleibt nur die Skalierung. Die Reihenfolge der Sammlung legt nicht automatisch das sequentielle Abspielen fest. Leeren Sie die Sammlung nur, wenn Sie alle Vorgänge ersetzen möchten.

## **Timing des Verhaltens konfigurieren**

Ein Verhalten besitzt ein eigenes [Timing](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/), unabhängig vom Timing, das über [Effect::getTiming](https://reference.aspose.com/slides/de/php-java/aspose.slides/effect/gettiming/) zurückgegeben wird. Das Effekt‑Timing plant den umgebenden Effekt; das Verhalten‑Timing beschreibt einen Vorgang innerhalb dieses Effekts.

### **Dauer, Verzögerung, Wiederholung und Beschleunigung festlegen**

Öffnen Sie `rotation.pptx` und setzen Sie die Dauer ([getDuration](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/getduration/)) sowie die Auslöser‑Verzögerung ([getTriggerDelayTime](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/gettriggerdelaytime/)) in Sekunden, dann konfigurieren Sie die Wiederholungszahl mittels [setRepeatCount](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/getaccelerate/) und [getDecelerate](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/getdecelerate/) sind Bruchteile der Dauer; ihre Summe darf höchstens 1 betragen.

Die Eingabedatei ist die im Drehungs‑Beispiel erstellte, bei der das erste Verhalten eine Drehung ist. Dieses Beispiel ändert nur das Timing dieses Verhaltens; der 90‑Grad‑Winkel bleibt unverändert. Das Separate Halten von Winkel und Timing erleichtert die Anpassung des Tempos, ohne die Animation neu zu bauen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Verhalten verwendet eine Dauer von zwei Sekunden, eine halbe Sekunde Verzögerung und eine Wiederholungszahl von 3. Die ersten und letzten 20 % der Dauer werden für Beschleunigung bzw. Verzögerung verwendet.

Weitere Wiederholungs‑Policies umfassen [getRepeatDuration](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/getrepeatuntilendslide/), und [getRepeatUntilNextClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/getrepeatuntilnextclick/); wählen Sie eine Policy, anstatt sie alle gleichzeitig zu aktivieren. [getAutoReverse](https://reference.aspose.com/slides/de/php-java/aspose.slides/timing/getautoreverse/) spielt die Animation nach dem Vorwärtslauf rückwärts ab. Beschleunigung und Verzögerung gelten für kontinuierliche Änderungen, nicht für diskrete Zuweisungen oder Befehle.

## **Einen Bewegungspfad erstellen**

Verwenden Sie [createMotionEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorfactory/createmotioneffect/), um Bewegung zu erzeugen. Seine [getFrom](https://reference.aspose.com/slides/de/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/de/php-java/aspose.slides/motioneffect/getto/) und [getBy](https://reference.aspose.com/slides/de/php-java/aspose.slides/motioneffect/getby/) beschreiben prozentbasierte Koordinaten oder Offsets. Für eine editierbare Route erzeugen Sie einen [MotionPath](https://reference.aspose.com/slides/de/php-java/aspose.slides/motionpath/) und weisen ihn mit [MotionEffect::setPath](https://reference.aspose.com/slides/de/php-java/aspose.slides/motioneffect/setpath/) zu. [MotionPath](https://reference.aspose.com/slides/de/php-java/aspose.slides/motionpath/) speichert die Pfadbefehle.

[MotionCommandPathType](https://reference.aspose.com/slides/de/php-java/aspose.slides/motioncommandpathtype/) wählt die Operation:

| Befehl | Punkte | Bedeutung |
| --- | --- | --- |
| MoveTo | Einer | Setzt die Startposition. |
| LineTo | Einer | Bewegt entlang eines geraden Segments zum Endpunkt. |
| CurveTo | Drei | Folgt einer kubischen Kurve, definiert durch zwei Kontrollpunkte und einen Endpunkt. |
| CloseLoop | Keine | Kehrt zur Startposition zurück. |
| End | Keine | Abschließen des Pfads. |

[MotionPathPointsType](https://reference.aspose.com/slides/de/php-java/aspose.slides/motionpathpointstype/) beschreibt Eigenschaften der Punktbearbeitung, z. B. Eck‑ oder glatte Punkte. Es ersetzt nicht den Befehlstyp. Verwenden Sie für das untenstehende Kurven‑Beispiel einen Kurven‑Punktetyp und für die geraden Segmente einen Eck‑Punktetyp.

Pfadkoordinaten sind auf die Folienmaße normiert: Eine X‑Verschiebung von 0,25 entspricht einem Viertel der Folienbreite, nicht 0,25 Punkt. Positives Y verläuft nach unten. Absolute Befehle geben Positionen im Pfadkoordinatensystem an; relative Befehle geben Offsets zur aktuellen Position an. Das ist separat von [getOrigin](https://reference.aspose.com/slides/de/php-java/aspose.slides/motioneffect/getorigin/), das den Referenzrahmen des Pfads wählt, und [getPathEditMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/motioneffect/getpatheditmode/), das steuert, wie sich der Pfad bewegt, wenn die Form verschoben wird.

### **Geraden Pfad erstellen**

Erzeugen Sie ein Bewegungs‑Verhalten mit einem Startpunkt, einem geraden Segment und einem Endbefehl. [MotionPath::add](https://reference.aspose.com/slides/de/php-java/aspose.slides/motionpath/add/) nimmt den Befehlstyp, seine Punkte, den Punktetyp und ein Flag für relative Koordinaten.

Der Startbefehl legt (0, 0) fest, und die Linie endet bei (0.25, 0), wodurch die Route eine horizontale Verschiebung von einem Viertel der Folienbreite erhält. Der Endbefehl hat keine Koordinatenpunkte. Sobald der Pfad zugewiesen ist, verbindet das Hinzufügen des Bewegungs‑Verhaltens zum Effekt diese Route mit dem Rechteck.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` enthält ein Bewegungs‑Verhalten mit drei Pfadbefehlen. Die nachfolgenden Dateibearbeitungs‑Beispiele nutzen diese bekannte Struktur.

### **Absolute und relative Koordinaten vergleichen**

Diese beiden Pfadobjekte beschreiben dieselbe Route. Der absolute Befehl endet bei (0.3, 0.1); der relative Befehl addiert (0.1, 0.1) zur aktuellen Position, also (0.2, 0).

Beide Pfade beginnen am selben Punkt. Für die relative Linie addieren Sie deren X‑ und Y‑Offsets zur aktuellen Position, um den Endpunkt zu erhalten; bei der absoluten Linie lesen Sie den Endpunkt direkt. Das Umschalten des Flags, ohne die Koordinaten zu konvertieren, würde eine andere Route ergeben.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

Weisen Sie entweder Pfad einer Bewegungs‑Verhalten zu, um ihn in einer Präsentation zu verwenden. Das abschließende Boolesche Argument wählt relative Koordinaten für diesen Befehl.

### **Eine Linie durch eine Kurve ersetzen**

Öffnen Sie `motion.pptx` und ersetzen Sie dessen Linien‑Befehl durch eine kubische Kurve. Geben Sie zuerst die beiden Kontrollpunkte an, gefolgt vom Endpunkt.

Die Startposition wird durch den vorhergehenden Befehl bereitgestellt. Die ersten beiden Punkte formen die Kurve, der dritte ist ihr Ziel; es handelt sich nicht um drei aufeinanderfolgende Ziele. Das gleichzeitige Aktualisieren von Befehlstyp, Punkt‑Bearbeitungstyp und Punkt‑Array hält das Segment konsistent zur neuen Geometrie.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Der Pfad in `curve.pptx` hat weiterhin drei Befehle; sein mittlerer Befehl definiert nun eine Kurve.

## **Einen gespeicherten Pfad inspizieren und bearbeiten**

Jeder [MotionCmdPath](https://reference.aspose.com/slides/de/php-java/aspose.slides/motioncmdpath/) stellt [getPoints](https://reference.aspose.com/slides/de/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/de/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/de/php-java/aspose.slides/motioncmdpath/getpointstype/) und [isRelative](https://reference.aspose.com/slides/de/php-java/aspose.slides/motioncmdpath/isrelative/) bereit. Die folgenden Beispiele verwenden den bekannten Drei‑Befehl‑Pfad in `motion.pptx`. Für beliebige Eingaben ermitteln Sie zunächst den gewünschten Effekt und prüfen Befehlstypen und Punktzahlen, bevor Sie per Index bearbeiten.

### **Befehle und Koordinaten lesen**

Lesen Sie den Pfad, ohne ihn zu verändern. End‑ und CloseLoop‑Befehle benötigen keine Punkte, daher muss ein null‑Punkt‑Array zugelassen werden.

Die Ausgabe paart jeden numerischen Befehlstyp mit seinem Flag für relative Koordinaten, bevor die Punkte aufgelistet werden. Das ermöglicht, Endpunkte von Offsets zu unterscheiden, bevor der Pfad modifiziert wird. Eine Kurve würde drei Punkte listen, während die gerade Linie in dieser Datei nur einen Punkt aufweist.

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Die Auflistung enthält einen Startpunkt, eine absolute Linie, die bei (0.25, 0) endet, und einen Endbefehl.

### **Einen Endpunkt ändern**

Öffnen Sie `motion.pptx` und ersetzen Sie das Punkt‑Array der Linie, um deren Endpunkt zu verschieben.

Im Eingabedokument ist Index 0 der Startbefehl und Index 1 die Linie. Das Ersetzen des einzigen Punktes der Linie ändert ihr Ziel, ohne den Befehlstyp, das Timing oder die Position in der Sammlung zu ändern. Da der Befehl absolute Koordinaten verwendet, gibt das neue Paar eine Position statt eines zusätzlichen Offsets an.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Linie in `motion-endpoint.pptx` endet bei (0.4, 0.1); die Originaldatei bleibt unverändert.

### **Ein Segment ersetzen**

Verwenden Sie [insert](https://reference.aspose.com/slides/de/php-java/aspose.slides/motionpath/insert/) und [removeAt](https://reference.aspose.com/slides/de/php-java/aspose.slides/motionpath/removeat/), um die Linie in `motion.pptx` zu ersetzen. Das Einfügen verschiebt die alte Linie zu Index 2.

Dies demonstriert das Ersetzen eines Befehls‑Objekts statt das Bearbeiten seiner bestehenden Koordinaten. Nach dem Einfügen enthält die Sammlung vorübergehend den Startbefehl, die neue Linie, die alte Linie und den Endbefehl. Das Entfernen von Index 2 verwirft die alte Linie und lässt die neue Route verbleiben.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Der gespeicherte Pfad hat weiterhin drei Befehle, wobei die neue Linie bei (0.2, 0.1) endet und der Endbefehl zuletzt steht.

## **Ein vorhandenes Verhalten ändern und prüfen**

Wenn der Index des Verhaltens unbekannt ist, wählen Sie ihn nach Typ aus. Dieses Beispiel öffnet `rotation.pptx`, findet dessen [RotationEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/rotationeffect/), ändert den Winkel und prüft den gespeicherten Wert nach erneutem Öffnen.

Der Typ‑Check lässt die Schleife Verhaltensweisen überspringen, die keine Drehungen sind. Der zweite Ladevorgang liest die gespeicherte Datei in ein separates Präsentationsobjekt, sodass der Vergleich persistente Daten prüft und nicht den noch im Speicher gehaltenen Wert. Dieses Beispiel geht weiterhin davon aus, dass der bekannte Effekt zuerst in der Hauptsequenz steht; das Auswählen eines Verhaltens nach Typ findet nicht unbedingt den korrekten Effekt in einer beliebigen Präsentation.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Die Ausgabe lautet `Rotation preserved: true`. Wenden Sie das gleiche Typ‑Prüfmuster auf andere Verhaltensweisen an. Für eine vollständige Erhaltungs‑Prüfung vergleichen Sie Ziel‑Form, Effekt, Verhaltenstypen und Reihenfolge, Timing und Pfadbefehle. Verwenden Sie eine numerische Toleranz für Gleitkomma‑Werte. Für eine Präsentation mit unbekanntem Animations‑Layout siehe [Read Shape Animations](/slides/de/php-java/shape-animation/#read-shape-animations) zur Durchquerung von Haupt‑ und Interaktionssequenzen.

## **Reihenfolge der Verhaltensweisen, Vorgaben und Wiedergabe**

Die Reihenfolge in [BehaviorCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/behaviorcollection/) ist die gespeicherte Reihenfolge der Vorgänge eines Effekts. Sie ist keine Wiedergabeliste, in der jedes Verhalten automatisch auf das vorherige wartet. Timing und der umschließende Effekt bestimmen die Planung. Verhaltensweisen können überlappen, und Vorgänge am selben Attribut können über [additive](https://reference.aspose.com/slides/de/php-java/aspose.slides/behavioradditivetype/) und [accumulation](https://reference.aspose.com/slides/de/php-java/aspose.slides/behavioraccumulatetype/) Einstellungen interagieren. Verwenden Sie nicht allein das Neuordnen der Sammlung, um „Bewegen, dann Drehen“ zu planen; nutzen Sie explizites Timing oder separate Effekte, wie in [Formanimation](/slides/de/php-java/shape-animation/) beschrieben.

Der [getType](https://reference.aspose.com/slides/de/php-java/aspose.slides/effect/gettype/) und [getSubtype](https://reference.aspose.com/slides/de/php-java/aspose.slides/effect/getsubtype/) des Effekts beschreiben seine Vorgabe. Sie stellen keine vollständige Beschreibung eines bearbeiteten Verhaltensbaums dar. Wählen Sie Vorgabe und Untertyp, bevor Sie Verhaltensweisen anpassen: Das Ändern der Vorgabe kann die Sammlung neu aufbauen und Ihre benutzerdefinierten Vorgänge verwerfen. Beispielsweise kann das Ändern eines angepassten Spin‑Effekts zu Fade dessen Dreh‑Verhalten durch Set‑ und Filter‑Verhalten ersetzen. Prüfen Sie die Sammlung erneut, nachdem Sie Vorgabe oder Untertyp geändert haben. Das Löschen von Vorgabe‑Verhaltensweisen kann auch Sichtbarkeits‑ oder Initialisierungs‑Vorgänge entfernen, die die Vorgabe benötigt. Die Beispiele verwenden bewusst sichtbare Formen und ersetzen die Verhaltensweisen; sie rekonstruieren nicht jede Vorgabe‑Implementierung.

## **Formatkompatibilität**

Ein erhaltenes Verhaltens‑Baum garantiert nicht identische Wiedergabe in jedem Viewer oder Export‑Renderer. Prüfen Sie die gespeicherten Daten und die gerenderte Ausgabe getrennt.

| Format oder Ausgabe | Was zu prüfen ist |
| --- | --- |
| PPTX | Verwenden Sie es als primäres Format für diese Beispiele. Öffnen Sie es erneut, um den editierbaren Verhaltens‑Baum zu prüfen, und testen Sie dann die Wiedergabe in der gewünschten PowerPoint‑Version. |
| PPT | Das veraltete Binärformat kann vom PPTX abweichen. Testen Sie einen separaten Speicher‑und‑Öffnen‑Zyklus und die Wiedergabe; schließen Sie nicht daraus, dass jede benutzerdefinierte Kombination unterstützt wird, nur weil PPTX‑Ausgabe funktioniert. |
| PDF, PNG, JPEG und andere statische Folienbilder | Enthalten eine statische Foliendarstellung, keinen abspielbaren Verhaltens‑Zeitstrahl oder ein garantiertes End‑Animations‑Bild. |
| [HTML5](/slides/de/php-java/export-to-html5/) | Kann unterstützte Animationen abspielen, wenn Formanimation in den Export‑Optionen aktiviert ist. Testen Sie benutzerdefinierte Kombinationen im Browser. |
| [Animated GIF](/slides/de/php-java/convert-powerpoint-to-animated-gif/) | Speichert gerenderte Frames, keine editierbaren Verhaltensweisen oder Klick‑gesteuerte Interaktionen. Prüfen Sie die tatsächlich gerenderte Bewegung. |
| [Video](/slides/de/php-java/convert-powerpoint-to-video/) | Rendert Animations‑Frames und kodiert sie als Video. Die Unterstützung ist auf die im Renderer [unterstützten Animationen und Effekte](/slides/de/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) beschränkt; Befehle und interaktive Ereignisse werden nicht zu einer editierbaren Zeitleiste. |

## **FAQ**

**Warum enthält mein Effekt Verhaltensweisen, bevor ich welche hinzugefügt habe?**

Das Erzeugen eines vordefinierten Effekts kann dessen zugrunde liegende Vorgänge erzeugen. Inspizieren Sie sie, bevor Sie entscheiden, ob Sie die Vorgabe erweitern oder deren Verhaltensweisen ersetzen.

**Bewirkt das Verschieben eines Verhaltens an den Anfang, dass es zuerst abgespielt wird?**

Nicht zwingend. Die Reihenfolge der Sammlung ersetzt nicht das Timing. Prüfen Sie Verzögerungen, Dauren und Interaktionen zwischen Vorgängen am gleichen Attribut.

**Warum hat ein End‑Befehl keine Punkte?**

Er markiert das Ende des Pfads und benötigt keine Koordinaten. Achten Sie bei der Inspektion eines aus einer Datei gelesenen Pfads auf ein null‑Punkt‑Array.

**Reicht ein erfolgreicher Round‑Trip aus, um die Wiedergabe zu bestätigen?**

Nein. Das erneute Öffnen bestätigt die Erhaltung der geprüften Eigenschaften. Testen Sie den Diashow‑Player oder das animierte Export‑Format separat, um das visuelle Verhalten zu verifizieren.