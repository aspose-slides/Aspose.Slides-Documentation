---
title: Tworzenie i modyfikowanie własnych zachowań animacji w JavaScript
linktitle: Własna animacja
type: docs
weight: 151
url: /pl/nodejs-java/custom-animation/
keywords:
- własna animacja
- zachowanie animacji
- ścieżka ruchu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz, przeglądaj i modyfikuj własne zachowania animacji oraz edytowalne ścieżki ruchu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Node.js za pośrednictwem Java."
---
## **Przegląd**

Niestandardowe zachowania animacji pozwalają sterować poszczególnymi operacjami w ramach efektu animacji, takimi jak zmiana koloru, obrót kształtu lub podążanie za edytowalną ścieżką ruchu. Ten przewodnik pokazuje, jak tworzyć i łączyć zachowania, konfigurować ich czasowanie, przeglądać i modyfikować istniejące animacje oraz weryfikować, że ich właściwości przetrwają zapis i ponowne otwarcie prezentacji.

Dla predefiniowanych efektów i wyzwalaczy kliknięcia, zobacz [Animacja Kształtów](/slides/pl/nodejs-java/shape-animation/).

## **Zrozumienie Modelu Animacji**

Animacja jest zorganizowana jako **Timeline → Sequence → Effect → Behaviors**:

- Metoda [getTimeline](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/#getTimeline) zwraca oś czasu slajdu, która zawiera jego główną sekwencję oraz sekwencje interaktywne.
- Obiekt [Sequence](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sequence/) zawiera efekty, które mogą być skierowane do różnych kształtów.
- Obiekt [Effect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/) określa docelowy kształt, preset, podtyp oraz czas trwania efektu.
- Kolekcja zwracana przez [Effect.getBehaviors](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#getBehaviors) zawiera operacje realizujące efekt: zmianę koloru, przemieszczenie, obrót, ustawienie właściwości i tak dalej.

## **Tworzenie Poszczególnych Zachowań**

Wywołaj [Sequence.addEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sequence/#addEffect), aby utworzyć efekt i uzyskać dostęp do kolekcji [getBehaviors](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#getBehaviors). Preset może automatycznie wypełnić tę kolekcję. Zachowaj jego operacje przy rozszerzaniu presetu lub użyj [clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorcollection/#clear), gdy zamierzasz je zastąpić.

[BehaviorFactory](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorfactory/) tworzy osiem typów zachowań zilustrowanych poniżej. Ruch jest opisany w sekcji [Build a Motion Path](#build-a-motion-path). Każdy fragment zawiera importy modułów i może być uruchomiony jako skrypt Node.js z zainstalowanymi pakietami `aspose.slides.via.java` i `java`. Uruchom przykłady tworzenia plików przed przykładami odczytującymi ich zawartość. Przykłady edycji podają, którego pliku wyjściowego używają.

### **Rotacja**

Użyj [createRotationEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect), aby utworzyć rotację. [getBy](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/rotationeffect/#getBy) określa kąt względny w stopniach; [getFrom](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/rotationeffect/#getFrom) i [getTo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/rotationeffect/#getTo) określają punkty końcowe.

Przykład zaczyna się od efektu Spin, zastępuje jego operacje presetowe jedną zachowaniem rotacji i nadaje temu zachowaniu dwusekundowe trwanie. Kąt względny 90 stopni oznacza ćwierć obrotu od początkowej orientacji kształtu, więc nie jest potrzebny wyraźny kąt początkowy.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` zawiera jeden kształt i jedną zachowanie rotacji. Kolekcja, czasowanie i przykłady edycji rotacji poniżej używają tego pliku.

### **Skalowanie**

Użyj [createScaleEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) z procentami X/Y: [getFrom](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/scaleeffect/#getFrom) i [getTo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/scaleeffect/#getTo) opisują początkowy i końcowy rozmiar, a [getBy](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/scaleeffect/#getBy) opisuje zmianę względną. Tutaj 100 oznacza rozmiar oryginalny.

Przykład zwiększa oba wymiary z 100 % do 125 % w ciągu dwóch sekund. Użycie równych wartości procentowych w poziomie i pionie zachowuje proporcje kształtu; różne wartości rozciągną jedną ze stron bardziej niż drugą.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kolor**

Użyj [createColorEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect), aby zmienić wypełnienie z niebieskiego na pomarańczowy. [getFrom](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/coloreffect/#getFrom) i [getTo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/coloreffect/#getTo) są kolorami; [getBy](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/coloreffect/#getBy) to przesunięcie koloru. [Behavior.getProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behavior/#getProperties) identyfikuje animowaną właściwość.

Wypełnienie kształtu jest początkowo ustawione na niebieskie, co odpowiada początkowemu kolorowi animacji. Wybranie atrybutu wypełnienia określa, którą część kształtu zmienić; same kolory końcowe nie wskazują tego atrybutu. Zapisany efekt opisuje dwusekundowe przejście do pomarańczowego.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtr**

Użyj [createFilterEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect), aby wybrać przetarcie. [getType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filtereffect/#getSubtype) i [getReveal](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filtereffect/#getReveal) określają filtr, kierunek oraz czy ujawnić, czy ukryć kształt.

Przykład konfiguruje dwusekundowe przetarcie, które ujawnia kształt przy użyciu podtypu right-direction. Ustawienia filtru należą do zachowania wewnątrz efektu, więc są konfigurowane po usunięciu oryginalnych operacji presetu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Właściwość**

Użyj [createPropertyEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect), aby animować przezroczystość. [getFrom](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/propertyeffect/#getTo) i [getBy](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/propertyeffect/#getBy) są ciągami interpretowanymi przy użyciu [getValueType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/propertyeffect/#getValueType) i [getCalcMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Wybierz punkty końcowe lub offset względny, zamiast ustawiać wszystkie trzy wartości jednocześnie.

Tutaj wybraną właściwością jest opacity, a ciągi liczbowe reprezentują zmianę z 25 % przezroczystości do pełnej nieprzezroczystości. Interpolacja liniowa opisuje stopniową zmianę między tymi wartościami. Przy dostosowywaniu tego przykładu do innej właściwości, wybierz odpowiedni typ wartości i wartości końcowe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ustawienie**

Użyj [createSetEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect), aby przypisać widoczność przez [getTo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/seteffect/#getTo). Zachowanie typu set nie interpoluje między punktami końcowymi.

Przykład wybiera atrybut visibility i przypisuje ciąg `visible` w momencie uruchomienia zachowania. Prostokąt jest już widoczny w tej minimalnej prezentacji, więc przypisanie może nie wywołać oczywistej zmiany wizualnej samo w sobie. Taka operacja jest przydatna jako część większego efektu, który dodatkowo kontroluje, kiedy kształt staje się ukryty lub widoczny.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Polecenie**

Użyj [createCommandEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) i skonfiguruj [getType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/commandeffect/#getCommandString) oraz [getShapeTarget](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Umieść nagranie WAV o nazwie `sample.wav` w katalogu roboczym. Przykład osadza je przy pomocy [addAudioFrameEmbedded](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) i dołącza polecenie odtwarzania do ramki audio.

Rama audio jest zarówno celem efektu, jak i celem polecenia. Łączy to żądanie odtworzenia z osadzonym nagraniem; sam ciąg polecenia nie wskazuje, który obiekt multimedialny kontrolować. Efekt jest skonfigurowany do rozpoczęcia po kliknięciu podczas pokazu slajdów.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

Zapisuje polecenie w `command.pptx`; nie odtwarza nagrania. Odtworzenie wymaga odtwarzacza pokazu slajdów, który obsługuje polecenie i jego cel multimedialny.

## **Zarządzanie Kolekcją Zachowań**

[BehaviorCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorcollection/) obsługuje [add](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorcollection/#remove) i [removeAt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorcollection/#removeAt). Ten przykład otwiera `rotation.pptx`, dodaje skalowanie, przenosi je przed rotację i usuwa rotację. Usunięcie i ponowne wstawienie tego samego obiektu zmienia jego pozycję w kolekcji bez tworzenia kopii.

Sekwencja edycji zmienia kolejność kolekcji z rotation–scale na scale–rotation, a następnie do samego skalowania. Indeksy odnoszą się do bieżącej kolekcji, więc usunięcie używa nowego indeksu rotacji po przestawieniu. Końcowe wyliczenie potwierdza, które zachowanie zostanie zapisane.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik to `ScaleEffect`: pozostało tylko skalowanie. Sam porządek w kolekcji nie planuje zachowań jedno po drugim. Czyść kolekcję tylko wtedy, gdy zamierzasz zastąpić wszystkie jej operacje.

## **Konfigurowanie Czasowania Zachowań**

[Behavior.getTiming](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behavior/#getTiming) udostępnia [Timing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/), niezależnie od [Effect.getTiming](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#getTiming). Czasowanie efektu planuje otaczający efekt; czasowanie zachowania opisuje operację wewnątrz niego.

### **Ustaw Trwanie, Opóźnienie, Powtórzenie i Przyspieszenie**

Otwórz `rotation.pptx` i ustaw trwanie ([getDuration](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getDuration)) oraz opóźnienie wyzwalacza ([getTriggerDelayTime](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) w sekundach, a następnie skonfiguruj liczbę powtórzeń przez [setRepeatCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getAccelerate) i [getDecelerate](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getDecelerate) są ułamkami trwania; ich suma nie może przekraczać 1.

Plik wejściowy to ten utworzony w przykładzie rotacji, w którym pierwsze zachowanie jest znane jako rotacja. Ten przykład modyfikuje wyłącznie czasowanie tego zachowania; kąt 90 stopni pozostaje niezmieniony. Rozdzielenie kąta i czasowania ułatwia dostosowanie tempa bez przebudowy animacji.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zachowanie używa dwusekundowego trwania, półsekundowego opóźnienia i liczby powtórzeń równej 3. Pierwsze i ostatnie 20 % trwania jest przeznaczone na przyspieszenie i zwolnienie.

Inne polityki powtarzania obejmują [getRepeatDuration](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) i [getRepeatUntilNextClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); wybierz jedną politykę zamiast włączania ich wszystkich jednocześnie. [getAutoReverse](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getAutoReverse) odtwarza animację wstecz po przejściu w przód. Przyspieszenie i zwolnienie mają zastosowanie do ciągłych zmian, nie do dyskretnych przypisań czy poleceń.

## **Tworzenie Ścieżki Ruchu**

Użyj [createMotionEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect), aby utworzyć ruch. Jego [getFrom](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motioneffect/#getTo) i [getBy](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motioneffect/#getBy) opisują współrzędne procentowe lub offsety. Dla edytowalnej trasy utwórz [MotionPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motionpath/) i przypisz go metodą [MotionEffect.setPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motionpath/) przechowuje polecenia ścieżki.

[MotionCommandPathType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motioncommandpathtype/) wybiera operację:

| Polecenie | Punkty | Znaczenie |
| --- | --- | --- |
| MoveTo | One | Ustala pozycję początkową. |
| LineTo | One | Przemieszcza się wzdłuż prostego odcinka do jego punktu końcowego. |
| CurveTo | Three | Podąża za krzywą sześcienną określoną dwoma punktami kontrolnymi i punktem końcowym. |
| CloseLoop | None | Powraca do pozycji początkowej. |
| End | None | Zakończa ścieżkę. |

[MotionPathPointsType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motionpathpointstype/) opisuje cechy edycji punktów, takie jak wierzchołki narożne lub wygładzone. Nie zastępuje on typu polecenia. Użyj typu punktu krzywej dla przykładu krzywej poniżej oraz typu punktu narożnego dla odcinków prostych.

Współrzędne ścieżki są znormalizowane do wymiarów slajdu: przesunięcie X = 0.25 oznacza jedną czwartą szerokości slajdu, a nie 0.25 punktu. Dodatni Y rośnie w dół. Polecenia bezwzględne określają pozycje w układzie współrzędnych ścieżki; polecenia względne określają offsety od bieżącej pozycji. To jest oddzielne od [getOrigin](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motioneffect/#getOrigin), który wybiera ramę odniesienia ścieżki, oraz [getPathEditMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), który kontroluje, jak ścieżka przemieszcza się przy ruchu kształtu.

### **Utworzenie Prostej Ścieżki**

Utwórz zachowanie ruchu z punktem początkowym, jednym odcinkiem prostym i poleceniem końcowym. [MotionPath.add](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motionpath/#add) przyjmuje typ polecenia, jego punkty, typ punktu i flagę współrzędnych względnych.

Polecenie początkowe ustala (0, 0), a linia kończy się w (0.25, 0), co daje trasę z poziomym przesunięciem jednej czwartej szerokości slajdu. Polecenie końcowe nie ma punktów współrzędnych. Po przypisaniu ścieżki, dodanie zachowania ruchu do efektu łączy tę trasę z prostokątem.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` zawiera jedno zachowanie ruchu z trzema poleceniami ścieżki. Poniższe przykłady edycji plików używają tej znanej struktury.

### **Porównanie Współrzędnych Bezwzględnych i Względnych**

Te dwa obiekty ścieżki opisują tę samą trasę. Polecenie bezwzględne kończy się w (0.3, 0.1); polecenie względne dodaje (0.1, 0.1) do bieżącej pozycji, czyli (0.2, 0).

Obie ścieżki zaczynają się w tym samym miejscu. Dla linii względnej dodaj jej offsety X i Y do bieżącej pozycji, aby uzyskać punkt końcowy; dla linii bezwzględnej odczytaj punkt końcowy bezpośrednio. Przełączenie flagi bez konwersji współrzędnych opisałoby inną trasę.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

Przypisz jedną z tych ścieżek do zachowania ruchu, aby użyć jej w prezentacji. Ostatni argument Boolean wybiera współrzędne względne dla tego polecenia.

### **Zastąpienie Linii Krzywą**

Otwórz `motion.pptx` i zamień jego polecenie linii na krzywą sześcienną. Najpierw podaj dwa punkty kontrolne, a na końcu punkt docelowy.

Pozycja początkowa jest określona przez poprzednie polecenie. Dwa pierwsze punkty kształtują krzywą, a trzeci jest jej miejscem docelowym; nie są to trzy kolejne punkty docelowe. Aktualizacja typu polecenia, typu punktu i tablicy punktów jednocześnie utrzymuje segment spójny z nową geometrią.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ścieżka w `curve.pptx` nadal ma trzy polecenia; jej środkowe polecenie teraz definiuje krzywą.

## **Inspekcja i Edycja Zapisanej Ścieżki**

Każdy [MotionCmdPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motioncmdpath/) udostępnia [getPoints](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) i [isRelative](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motioncmdpath/#isRelative). Poniższe przykłady używają znanej trzypoleceniowej ścieżki w `motion.pptx`. Dla dowolnego wejścia, znajdź docelowy efekt i sprawdź typy poleceń oraz liczbę punktów przed edycją po indeksie.

### **Odczyt Poleceń i Współrzędnych**

Odczytaj ścieżkę bez jej modyfikacji. Polecenia end i close-loop nie wymagają punktów, więc pozwól na tablicę punktów równą null.

Wynik paruje każdy numeryczny typ polecenia z jego flagą współrzędnych względnych przed wypisaniem punktów. Dzięki temu możesz odróżnić punkt końcowy od offsetu przed modyfikacją ścieżki. Krzywa wypisze trzy punkty, podczas gdy prosty odcinek w tym pliku wypisuje tylko jeden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Wymieniono punkt początkowy, bezwzględną linię kończącą się w (0.25, 0) oraz polecenie end.

### **Zmiana Punktu Końcowego**

Otwórz `motion.pptx` i zamień tablicę punktów linii, aby przenieść jej punkt końcowy.

W pliku wejściowym indeks 0 to polecenie początkowe, a indeks 1 to linia. Zamiana jedynego punktu linii zmienia jej miejsce docelowe bez zmiany typu polecenia, czasowania ani pozycji w kolekcji. Ponieważ polecenie używa współrzędnych bezwzględnych, nowa para określa pozycję, a nie dodatkowy offset.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Linia w `motion-endpoint.pptx` kończy się w (0.4, 0.1); oryginalny plik pozostaje niezmieniony.

### **Zastąpienie Segmentu**

Użyj [insert](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motionpath/#insert) i [removeAt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/motionpath/#removeAt), aby zastąpić linię w `motion.pptx`. Wstawienie przesuwa starą linię do indeksu 2.

To pokazuje zastąpienie obiektu polecenia zamiast edycji jego istniejących współrzędnych. Po wstawieniu kolekcja tymczasowo zawiera polecenie początkowe, nową linię, starą linię i polecenie end. Usunięcie indeksu 2 usuwa starą linię i pozostawia nową trasę na miejscu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zapisana ścieżka nadal ma trzy polecenia, przy czym nowa linia kończy się w (0.2, 0.1), a polecenie end pozostaje ostatnie.

## **Modyfikacja i Weryfikacja Istniejącego Zachowania**

Gdy indeks zachowania jest nieznany, wybierz je po typie. Ten przykład otwiera `rotation.pptx`, znajduje jego [RotationEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/rotationeffect/), zmienia kąt i sprawdza zapisaną wartość po ponownym otwarciu.

Sprawdzenie typu pozwala pętli pominąć zachowania, które nie są rotacjami. Drugi odczyt wczytuje zapisany plik do oddzielnego obiektu prezentacji, więc porównanie sprawdza trwałe dane, a nie wartość nadal trzymaną w pamięci. Przykład nadal zakłada, że znany efekt jest pierwszy w głównej sekwencji; wybór zachowania po typie nie znajduje właściwego efektu w dowolnej prezentacji.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Wynik to `Rotation preserved: true`. Zastosuj ten sam schemat sprawdzania typu do innych zachowań. Dla pełnej kontroli zachowania porównaj docelowy kształt, efekt, typy i kolejność zachowań, czasowanie oraz polecenia ścieżki. Użyj tolerancji numerycznej dla wartości zmiennoprzecinkowych. Dla prezentacji o nieznanym układzie animacji zobacz [Odczyt Animacji Kształtów](/slides/pl/nodejs-java/shape-animation/#read-shape-animations) w celu przeglądania głównych i interaktywnych sekwencji.

## **Kolejność Zachowań, Presety i Odtwarzanie**

Kolejność w [BehaviorCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behaviorcollection/) jest zapisaną kolejnością operacji efektu. Nie jest to lista odtwarzania, w której każde zachowanie automatycznie czeka na poprzednie. Czasowanie i otaczający efekt decydują o harmonogramie. Zachowania mogą się nakładać, a operacje na tej samej właściwości mogą współdziałać przez [getAdditive](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behavior/#getAdditive) i [getAccumulate](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behavior/#getAccumulate). Nie używaj samego przestawienia kolejności kolekcji, aby zaplanować „przesuń, potem obróć”; użyj jawnego czasowania lub oddzielnych efektów, jak opisano w [Animacja Kształtów](/slides/pl/nodejs-java/shape-animation/).

Typ efektu ([getType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#getType)) i podtyp ([getSubtype](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#getSubtype)) opisują jego preset. Nie są one pełnym opisem edytowanego drzewa zachowań. Wybierz preset i podtyp przed dostosowaniem zachowań: zmiana presetu może odtworzyć kolekcję i usunąć własne operacje. Na przykład zmiana spersonalizowanego efektu Spin na Fade może zastąpić zachowanie rotacji zachowaniami set i filter. Po zmianie presetu lub podtypu ponownie sprawdź kolekcję. Czyszczenie zachowań presetu może także usunąć operacje widoczności lub inicjalizacji, które preset wymaga. Przykłady używają widocznych kształtów i zastępują zachowania; nie odtwarzają pełnej implementacji każdego presetu.

## **Kompatybilność Formatów**

Zachowane drzewo zachowań nie gwarantuje identycznego odtwarzania w każdym podglądarce lub silniku eksportu. Sprawdź osobno zapisane dane i wyrenderowany wynik.

| Format lub wyjście | Co zweryfikować |
| --- | --- |
| PPTX | Użyj jako głównego formatu dla tych przykładów. Otwórz ponownie, aby zweryfikować edytowalne drzewo zachowań, a następnie sprawdź odtwarzanie w docelowej wersji PowerPointa. |
| PPT | Starsza reprezentacja binarna może różnić się od PPTX. Przetestuj osobny cykl zapisu‑odczytu i odtworzenia; nie zakładaj wsparcia dla każdej niestandardowej kombinacji na podstawie udanego wyniku PPTX. |
| PDF, PNG, JPEG i inne statyczne obrazy slajdów | Zawierają statyczną reprezentację slajdu, nie odtwarzalną oś czasu zachowań ani zapewnioną finalną klatkę animacji. |
| [HTML5](/slides/pl/nodejs-java/export-to-html5/) | Może odtwarzać obsługiwane animacje, gdy animacja kształtów jest włączona w opcjach eksportu. Przetestuj niestandardowe kombinacje w przeglądarce. |
| [Animated GIF](/slides/pl/nodejs-java/convert-powerpoint-to-animated-gif/) | Zapisuje wyrenderowane klatki, nie edytowalne zachowania ani interakcje wyzwalane kliknięciem. Sprawdź rzeczywisty wyrenderowany ruch. |
| [Video](/slides/pl/nodejs-java/convert-powerpoint-to-video/) | Renderuje klatki animacji i koduje je jako wideo. Wsparcie jest ograniczone do [obsługiwanych animacji i efektów](/slides/pl/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) renderera; polecenia i zdarzenia interaktywne nie stają się edytowalną osią czasu. |

## **FAQ**

**Dlaczego mój efekt zawiera zachowania zanim je dodam?**

Tworzenie predefiniowanego efektu może automatycznie utworzyć jego podstawowe operacje. Przeglądnij je, zanim zdecydujesz, czy rozszerzyć preset, czy zastąpić jego zachowania.

**Czy przeniesienie zachowania na początek powoduje, że odtwarza się jako pierwsze?**

Niekoniecznie. Kolejność w kolekcji nie zastępuje czasowania. Sprawdź opóźnienia, trwania i interakcje między operacjami na tej samej właściwości.

**Dlaczego polecenie end nie ma punktów?**

Oznacza koniec ścieżki i nie wymaga współrzędnych. Podczas przeglądania ścieżki odczytanej z pliku uwzględnij możliwość, że tablica punktów może być null.

**Czy udany cykl zapisu‑odczytu wystarczy, aby potwierdzić poprawne odtwarzanie?**

Nie. Otworzenie pliku potwierdza zachowanie zapisanych właściwości, ale odtwarzanie wymaga przetestowania w odtwarzaczu pokazu slajdów lub w eksporcie animacji, aby zweryfikować rzeczywistą wizualizację.