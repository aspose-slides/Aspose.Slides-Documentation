---
title: Tworzenie i modyfikowanie niestandardowych zachowań animacji w PHP
linktitle: Niestandardowa animacja
type: docs
weight: 151
url: /pl/php-java/custom-animation/
keywords:
- niestandardowa animacja
- zachowanie animacji
- ścieżka ruchu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz, przeglądaj i modyfikuj niestandardowe zachowania animacji oraz edytowalne ścieżki ruchu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla PHP poprzez Java."
---
## **Przegląd**

Niestandardowe zachowania animacji pozwalają kontrolować poszczególne operacje w ramach efektu animacji, takie jak zmiana koloru, obracanie kształtu lub podążanie za edytowalną ścieżką ruchu. Ten przewodnik pokazuje, jak tworzyć i łączyć zachowania, konfigurować ich synchronizację, przeglądać i modyfikować istniejące animacje oraz weryfikować, że ich właściwości przetrwają zapisanie i ponowne otwarcie prezentacji.

Dla predefiniowanych efektów i wyzwalaczy kliknięcia zobacz [Animacja kształtów](/slides/pl/php-java/shape-animation/).

## **Zrozumienie modelu animacji**

Animacja jest zorganizowana jako **Oś czasu → Sekwencja → Efekt → Zachowania**:

- Każdy slajd posiada oś czasu zawierającą główną sekwencję oraz sekwencje interaktywne.
- Sekwencja ([Sequence](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sequence/)) zawiera efekty, które mogą dotyczyć różnych kształtów.
- Efekt ([Effect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effect/)) określa docelowy kształt, preset, podtyp i synchronizację efektu.
- Kolekcja zwracana przez [Effect::getBehaviors](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effect/getbehaviors/) zawiera operacje implementujące efekt: zmianę koloru, przemieszczanie, obracanie, ustawianie właściwości itp.

## **Tworzenie pojedynczych zachowań**

Wywołaj [Sequence::addEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sequence/addeffect/) aby utworzyć efekt i uzyskać dostęp do kolekcji [getBehaviors](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effect/getbehaviors/). Preset może automatycznie wypełnić tę kolekcję. Zachowaj jego operacje przy rozszerzaniu presetu lub użyj [clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorcollection/clear/) gdy świadomie je zastępujesz.

[BehaviorFactory](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorfactory/) tworzy osiem typów zachowań przedstawionych poniżej. Ruch jest opisany w sekcji [Build a Motion Path](#build-a-motion-path). Każdy fragment kodu zawiera importy i zakłada, że PHP/Java Bridge oraz biblioteka Aspose.Slides PHP zostały załadowane. Przykłady edycji podają, którego pliku wyjściowego używają.

### **Obrót**

Użyj [createRotationEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorfactory/createrotationeffect/) aby utworzyć obrót. [getBy](https://reference.aspose.com/slides/pl/php-java/aspose.slides/rotationeffect/getby/) określa względny kąt w stopniach; [getFrom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/rotationeffect/getfrom/) i [getTo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/rotationeffect/getto/) określają punkty końcowe.

Przykład rozpoczyna się od efektu Spin, zastępuje jego operacje presetowe jednym zachowaniem obrotu i nadaje temu zachowaniu dwusekundowy czas trwania. Względny kąt 90 stopni oznacza ćwierć obrotu od początkowej orientacji kształtu, więc nie jest potrzebny wyraźny kąt początkowy.

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

`rotation.pptx` zawiera jeden kształt i jedno zachowanie obrotu. Kolekcja, synchronizacja i przykłady edycji obrotu poniżej używają tego pliku.

### **Skala**

Użyj [createScaleEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorfactory/createscaleeffect/) z wartościami procentowymi X/Y: [getFrom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/scaleeffect/getfrom/) i [getTo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/scaleeffect/getto/) opisują początkowy i końcowy rozmiar, natomiast [getBy](https://reference.aspose.com/slides/pl/php-java/aspose.slides/scaleeffect/getby/) opisuje zmianę względną. Tutaj 100 oznacza rozmiar oryginalny.

Przykład zwiększa oba wymiary z 100 % do 125 % w ciągu dwóch sekund. Użycie równych wartości poziomych i pionowych zachowuje proporcje kształtu; różne wartości rozciągną jedną z osi bardziej niż drugą.

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

### **Kolor**

Użyj [createColorEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorfactory/createcoloreffect/) aby zmienić wypełnienie z niebieskiego na pomarańczowy. [getFrom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/coloreffect/getfrom/) i [getTo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/coloreffect/getto/) są kolorami; [getBy](https://reference.aspose.com/slides/pl/php-java/aspose.slides/coloreffect/getby/) jest przesunięciem koloru. [BehaviorPropertyCollection] zachowania identyfikuje atrybut, który jest animowany.

Stałe wypełnienie kształtu jest zainicjowane jako niebieskie, pasujące do początkowego koloru animacji. Wybranie atrybutu fill-color informuje zachowanie, którą część kształtu zmienić; same końcowe kolory nie określają tego atrybutu. Zapisany efekt opisuje dwusekundową przejście do pomarańczowego.

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

### **Filtr**

Użyj [createFilterEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorfactory/createfiltereffect/) aby wybrać wycieranie. [getType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/pl/php-java/aspose.slides/filtereffect/getsubtype/), i [getReveal](https://reference.aspose.com/slides/pl/php-java/aspose.slides/filtereffect/getreveal/) określają filtr, kierunek oraz czy odsłonić czy ukryć kształt.

Ten przykład konfiguruje dwusekundowe wycieranie, które odsłania kształt przy użyciu podtypu w prawo. Ustawienia filtru należą do zachowania wewnątrz efektu, więc są konfigurowane po usunięciu pierwotnych operacji presetu.

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

### **Właściwość**

Użyj [createPropertyEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) aby animować krycie. [getFrom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/propertyeffect/getto/), i [getBy](https://reference.aspose.com/slides/pl/php-java/aspose.slides/propertyeffect/getby/) są ciągami znaków interpretowanymi przy użyciu [getValueType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/propertyeffect/getvaluetype/) i [getCalcMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/propertyeffect/getcalcmode/). Wybierz końcowe wartości lub przesunięcie względne zamiast ustawiania wszystkich trzech jednocześnie.

W tym przykładzie wybranym atrybutem jest krycie, a numeryczne ciągi reprezentują zmianę z 25 % krycia do pełnego krycia. Liniowa interpolacja opisuje stopniową zmianę pomiędzy tymi wartościami. Przy dostosowywaniu tego przykładu do innego atrybutu, wybierz typ wartości i wartości końcowe odpowiednie dla tego atrybutu.

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

### **Ustaw**

Użyj [createSetEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorfactory/createseteffect/) aby przypisać widoczność przy użyciu [getTo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/seteffect/getto/). Zachowanie typu set nie interpoluje pomiędzy punktami końcowymi.

Przykład wybiera atrybut widoczności i przypisuje ciąg `visible` podczas wykonywania zachowania. Prostokąt jest już widoczny w tej minimalnej prezentacji, więc przypisanie może nie wywołać wyraźnej zmiany wizualnej samo w sobie. Taka operacja jest przydatna jako część większego efektu, który również kontroluje, kiedy kształt zostaje ukryty lub widoczny.

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

### **Polecenie**

Użyj [createCommandEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorfactory/createcommandeffect/) i skonfiguruj [getType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commandeffect/getcommandstring/), oraz [getShapeTarget](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commandeffect/getshapetarget/). Umieść nagranie WAV o nazwie `sample.wav` w katalogu roboczym. Ten przykład osadza je przy pomocy [addAudioFrameEmbedded](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addaudioframeembedded/) i dołącza polecenie odtworzenia do ramki audio.

Rama audio jest zarówno celem efektu, jak i celem polecenia. Łączy to żądanie odtworzenia z osadzonym nagraniem; sam ciąg polecenia nie określa, który obiekt multimedialny ma być kontrolowany. Efekt jest skonfigurowany tak, by rozpocząć się po kliknięciu podczas pokazu slajdów.

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

Zapis zapisuje polecenie w pliku `command.pptx`; nie odtwarza nagrania. Odtwarzanie wymaga odtwarzacza pokazu slajdów, który obsługuje polecenie i jego docelowy media.

## **Zarządzanie kolekcją zachowań**

[BehaviorCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorcollection/) obsługuje [add](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorcollection/remove/), oraz [removeAt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorcollection/removeat/). Ten przykład otwiera `rotation.pptx`, dodaje skalowanie, przenosi je przed obrót i usuwa obrót. Usunięcie i ponowne wstawienie tego samego obiektu zmienia jego zapisane położenie bez tworzenia kopii.

Ciąg edycji zmienia kolekcję z rotation–scale na scale–rotation, a następnie na sam scale. Indeksy odnoszą się do bieżącej kolekcji, więc usunięcie używa nowego indeksu obrotu po przestawieniu. Ostateczna enumeracja potwierdza, które zachowanie zostanie zapisane.

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

Wynik to `ScaleEffect`: pozostaje tylko skalowanie. Kolejność w kolekcji nie planuje zachowań jedno po drugim. Czyść kolekcję tylko wtedy, gdy zastępujesz wszystkie jej operacje.

## **Konfiguracja czasu zachowania**

Zachowanie ma własny [Timing](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/), niezależny od czasu zwracanego przez [Effect::getTiming](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effect/gettiming/). Czas efektu planuje otaczający efekt; czas zachowania opisuje operację wewnątrz niego.

### **Ustawienie czasu trwania, opóźnienia, powtórzeń i przyspieszenia**

Otwórz `rotation.pptx` i ustaw czas trwania ([getDuration](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/getduration/)) oraz opóźnienie wyzwalacza ([getTriggerDelayTime](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/gettriggerdelaytime/)) w sekundach, a następnie skonfiguruj liczbę powtórzeń przy pomocy [setRepeatCount](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/getaccelerate/) i [getDecelerate](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/getdecelerate/) są ułamkami czasu trwania; ich suma nie powinna przekraczać 1.

Plik wejściowy to ten utworzony w przykładzie obrotu, w którym pierwsze zachowanie jest znanym obrotem. Ten przykład zmienia tylko czas tego zachowania; jego kąt 90 stopni pozostaje niezmieniony. Rozdzielenie kąta i czasu ułatwia dostosowanie tempa bez przebudowywania animacji.

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

Zachowanie używa dwusekundowego czasu trwania, półsekundowego opóźnienia i liczby powtórzeń 3. Pierwsze i ostatnie 20 % jego czasu trwania służą do przyspieszenia i zwolnienia.

Inne polityki powtarzania obejmują [getRepeatDuration](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/getrepeatuntilendslide/), i [getRepeatUntilNextClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/getrepeatuntilnextclick/); wybierz jedną politykę zamiast włączania ich wszystkich jednocześnie. [getAutoReverse](https://reference.aspose.com/slides/pl/php-java/aspose.slides/timing/getautoreverse/) odtwarza animację wstecz po przejściu w przód. Przyspieszenie i zwolnienie mają zastosowanie do ciągłych zmian, a nie do dyskretnych przypisań lub poleceń.

## **Budowanie ścieżki ruchu**

Użyj [createMotionEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorfactory/createmotioneffect/) aby utworzyć ruch. Jego [getFrom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motioneffect/getto/), i [getBy](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motioneffect/getby/) opisują współrzędne lub przesunięcia wyrażone w procentach. Aby uzyskać edytowalną trasę, utwórz [MotionPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motionpath/) i przypisz ją przy pomocy [MotionEffect::setPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motioneffect/setpath/). [MotionPath] przechowuje polecenia ścieżki.

| Polecenie | Punkty | Znaczenie |
| --- | --- | --- |
| MoveTo | One | Ustaw początkową pozycję. |
| LineTo | One | Przemieść się wzdłuż prostej do jej punktu końcowego. |
| CurveTo | Three | Podążaj za krzywą sześcienną określoną przez dwa punkty kontrolne i punkt końcowy. |
| CloseLoop | None | Powróć do pozycji początkowej. |
| End | None | Zakończ ścieżkę. |

[MotionPathPointsType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motionpathpointstype/) opisuje charakterystyki edycji punktów, takie jak punkt narożny lub wygładzony. Nie zastępuje to typu polecenia. Użyj typu punktu krzywej w przykładzie krzywej poniżej oraz typu punktu narożnego dla segmentów prostych.

Współrzędne ścieżki są normalizowane do wymiarów slajdu: przemieszczenie X o 0,25 oznacza jedną czwartą szerokości slajdu, a nie 0,25 punktu. Dodatni Y biegnie w dół. Polecenia bezwzględne określają pozycje w układzie współrzędnych ścieżki; polecenia względne określają przesunięcia od bieżącej pozycji. To jest oddzielne od [getOrigin](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motioneffect/getorigin/), które wybiera ramkę odniesienia ścieżki, oraz [getPathEditMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motioneffect/getpatheditmode/), które steruje, jak ścieżka porusza się, gdy kształt jest przesuwany.

### **Utworzenie prostej ścieżki**

Utwórz zachowanie ruchu z punktem początkowym, jednym prostym segmentem i poleceniem końcowym. [MotionPath::add](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motionpath/add/) przyjmuje typ polecenia, jego punkty, typ punktu oraz flagę współrzędnych względnych.

Polecenie początkowe ustawia (0, 0), a linia kończy się w (0,25, 0), co daje trasie poziome przemieszczenie o jedną czwartą szerokości slajdu. Polecenie końcowe nie ma punktów współrzędnych. Po przypisaniu ścieżki, dodanie zachowania ruchu do efektu łączy tę trasę z prostokątem.

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

`motion.pptx` zawiera jedno zachowanie ruchu z trzema poleceniami ścieżki. Następujące przykłady edycji pliku używają tej znanej struktury.

### **Porównanie współrzędnych bezwzględnych i względnych**

Te dwa obiekty ścieżki opisują tę samą trasę. Polecenie bezwzględne kończy się w (0,3, 0,1); polecenie względne dodaje (0,1, 0,1) do bieżącej pozycji, czyli (0,2, 0).

Obie ścieżki zaczynają się w tej samej pozycji. Dla linii względnej, dodaj jej przesunięcia X i Y do bieżącej pozycji, aby uzyskać punkt końcowy; dla linii bezwzględnej, odczytaj punkt końcowy bezpośrednio. Zmiana flagi bez przeliczania współrzędnych opisałaby inną trasę.

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

Przypisz dowolną ścieżkę do zachowania ruchu, aby użyć jej w prezentacji. Ostatni argument typu Boolean wybiera współrzędne względne dla tego polecenia.

### **Zamiana linii na krzywą**

Otwórz `motion.pptx` i zamień jego polecenie linii na krzywą sześcienną. Najpierw podaj dwa punkty kontrolne, a następnie punkt końcowy.

Pozycja początkowa jest dostarczona przez poprzednie polecenie. Pierwsze dwa punkty kształtują krzywą, a trzeci jest jej docelowym punktem; nie są to trzy kolejne cele. Aktualizacja typu polecenia, typu edycji punktów i tablicy punktów razem utrzymuje segment spójny z nową geometrią.

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

Ścieżka w `curve.pptx` nadal ma trzy polecenia, a środkowe polecenie teraz definiuje krzywą.

## **Inspekcja i edycja zapisanej ścieżki**

Każdy [MotionCmdPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motioncmdpath/) udostępnia [getPoints](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motioncmdpath/getpointstype/), oraz [isRelative](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motioncmdpath/isrelative/). Poniższe przykłady używają znanej trójpoleceniowej ścieżki w `motion.pptx`. Dla dowolnego wejścia, znajdź zamierzony efekt i sprawdź typy poleceń oraz liczbę punktów przed edycją według indeksu.

### **Odczyt poleceń i współrzędnych**

Odczytaj ścieżkę bez jej modyfikacji. Polecenia End i CloseLoop nie wymagają punktów, więc uwzględnij możliwość pustej tablicy punktów.

Wynik paruje każdy numeryczny typ polecenia z flagą współrzędnych względnych przed wypisaniem jego punktów. Pozwala to odróżnić punkt końcowy od przesunięcia przed modyfikacją ścieżki. Krzywa wypisałaby trzy punkty, natomiast prosta linia w tym pliku wypisuje tylko jeden.

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

Lista zawiera punkt początkowy, bezwzględną linię kończącą się w (0,25, 0) oraz polecenie end.

### **Zmiana punktu końcowego**

Otwórz `motion.pptx` i zamień tablicę punktów linii, aby przenieść jej punkt końcowy.

W pliku wejściowym indeks 0 to polecenie początkowe, a indeks 1 to linia. Zamiana jednego punktu linii zmienia jej docelową pozycję bez zmiany typu polecenia, czasu ani pozycji w kolekcji. Ponieważ polecenie używa współrzędnych bezwzględnych, nowa para określa pozycję, a nie dodatkowe przesunięcie.

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

Linia w `motion-endpoint.pptx` kończy się w (0,4, 0,1); oryginalny plik pozostaje niezmieniony.

### **Zamiana segmentu**

Użyj [insert](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motionpath/insert/) i [removeAt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/motionpath/removeat/) aby zamienić linię w `motion.pptx`. Wstawienie przesuwa starą linię do indeksu 2.

To pokazuje zamianę obiektu polecenia zamiast edytowania jego istniejących współrzędnych. Po wstawieniu kolekcja tymczasowo zawiera polecenie początkowe, nową linię, starą linię i polecenie end. Usunięcie indeksu 2 usuwa starą linię i pozostawia nową trasę.

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

Zapisana ścieżka nadal ma trzy polecenia, przy czym nowa linia kończy się w (0,2, 0,1) a polecenie end jest ostatnie.

## **Modyfikacja i weryfikacja istniejącego zachowania**

Gdy indeks zachowania jest nieznany, wybierz je według typu. Ten przykład otwiera `rotation.pptx`, znajduje jego [RotationEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/rotationeffect/), zmienia kąt i sprawdza zapisaną wartość po ponownym otwarciu.

Sprawdzenie typu pozwala pętli pominąć zachowania, które nie są obrotami. Drugi odczyt wczytuje zapisany plik do osobnego obiektu prezentacji, więc porównanie sprawdza trwałe dane, a nie wartość wciąż trzymaną w pamięci. Ten przykład nadal zakłada, że znany efekt jest pierwszy w głównej sekwencji; wybieranie zachowania według typu nie znajduje właściwego efektu w dowolnej prezentacji.

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

Wynik to `Rotation preserved: true`. Zastosuj ten sam wzorzec sprawdzania typu do innych zachowań. Dla pełnej weryfikacji zachowania porównaj docelowy kształt, efekt, typy i kolejność zachowań, czas oraz polecenia ścieżki. Użyj tolerancji numerycznej dla wartości zmiennoprzecinkowych. Dla prezentacji o nieznanym układzie animacji, zobacz [Read Shape Animations](/slides/pl/php-java/shape-animation/#read-shape-animations) w celu przeglądu głównych i interaktywnych sekwencji.

## **Kolejność zachowań, presety i odtwarzanie**

Kolejność w [BehaviorCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behaviorcollection/) jest zapisaną kolejnością operacji efektu. Nie jest to playlista, w której każde zachowanie automatycznie czeka na poprzednie. Synchronizacja i otaczający efekt określają harmonogram. Zachowania mogą się nakładać, a operacje na tej samej właściwości mogą oddziaływać poprzez ustawienia [additive](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behavioradditivetype/) i [accumulation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behavioraccumulatetype/). Nie używaj samego przestawiania kolekcji, aby zaplanować „przesuń, a potem obróć”; użyj wyraźnej synchronizacji lub osobnych efektów, jak opisano w [Shape Animation](/slides/pl/php-java/shape-animation/).

[getType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effect/gettype/) i [getSubtype](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effect/getsubtype/) efektu opisują jego preset. Nie stanowią one pełnego opisu edytowanego drzewa zachowań. Wybierz preset i podtyp przed dostosowaniem zachowań: zmiana presetu może przebudować kolekcję i usunąć Twoje niestandardowe operacje. Na przykład, zmiana spersonalizowanego efektu Spin na Fade może zamienić jego zachowanie obrotu na zachowania set i filter. Ponownie sprawdź kolekcję po zmianie presetu lub podtypu. Czyszczenie zachowań presetu może również usunąć operacje widoczności lub inicjalizacji, których preset wymaga. Przykłady celowo używają widocznych kształtów i zastępują zachowania; nie rekonstruują one implementacji każdego presetu.

## **Kompatybilność formatów**

Zachowane drzewo zachowań nie gwarantuje identycznego odtwarzania we wszystkich przeglądarkach czy narzędziach eksportu. Sprawdź oddzielnie zapisane dane i wygenerowany wynik.

| Format lub wyjście | Co zweryfikować |
| --- | --- |
| PPTX | Używaj jako głównego formatu w tych przykładach. Otwórz ponownie, aby zweryfikować edytowalne drzewo zachowań, a następnie sprawdź odtwarzanie w docelowej wersji PowerPointa. |
| PPT | Starsza reprezentacja binarna może różnić się od PPTX. Przetestuj osobny cykl zapisu‑i‑ponownego otwarcia oraz odtwarzanie; nie zakładaj wsparcia dla każdej niestandardowej kombinacji na podstawie udanego wyniku PPTX. |
| PDF, PNG, JPEG i inne statyczne obrazy slajdów | Zawierają statyczną reprezentację slajdu, nie odtwarzalną oś czasu zachowań ani gwarantowaną finalną klatkę animacji. |
| [HTML5](/slides/pl/php-java/export-to-html5/) | Może odtwarzać obsługiwane animacje, gdy animacja kształtów jest włączona w opcjach eksportu. Przetestuj niestandardowe kombinacje w przeglądarce. |
| [Animated GIF](/slides/pl/php-java/convert-powerpoint-to-animated-gif/) | Zawiera renderowane klatki, nie edytowalne zachowania ani interakcję wyzwalaną kliknięciem. Sprawdź rzeczywisty rendowany ruch. |
| [Video](/slides/pl/php-java/convert-powerpoint-to-video/) | Renderuje klatki animacji i koduje je jako wideo. Obsługa jest ograniczona do [obsługiwanych animacji i efektów](/slides/pl/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) renderera; polecenia i zdarzenia interaktywne nie stają się edytowalną osią czasu. |

## **FAQ**

**Dlaczego mój efekt zawiera zachowania zanim coś dodałem?**  
Tworzenie predefiniowanego efektu może generować jego podstawowe operacje. Przejrzyj je przed podjęciem decyzji, czy rozszerzyć preset, czy zastąpić jego zachowania.

**Czy przeniesienie zachowania na początek sprawia, że odtwarzane jest najpierw?**  
Niekoniecznie. Kolejność w kolekcji nie zastępuje synchronizacji. Sprawdź opóźnienia, czasy trwania oraz interakcje między operacjami na tej samej właściwości.

**Dlaczego polecenie end nie ma punktów?**  
Zaznacza koniec ścieżki i nie wymaga współrzędnych. Sprawdź, czy tablica punktów nie jest pusta przy inspekcji ścieżki odczytanej z pliku.

**Czy udana pełna pętla wystarczy, aby potwierdzić odtwarzanie?**  
Nie. Ponowne otwarcie potwierdza zachowanie sprawdzonych właściwości. Przetestuj odtwarzacz pokazu slajdów lub eksport animacji osobno, aby zweryfikować jego zachowanie wizualne.