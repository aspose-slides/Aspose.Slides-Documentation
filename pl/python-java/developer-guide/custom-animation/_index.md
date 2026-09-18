---
title: Utwórz i modyfikuj niestandardowe zachowania animacji w Pythonie za pomocą Javy
linktitle: Niestandardowa animacja
type: docs
weight: 151
url: /pl/python-java/custom-animation/
keywords:
- niestandardowa animacja
- zachowanie animacji
- ścieżka ruchu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Twórz, przeglądaj i modyfikuj niestandardowe zachowania animacji oraz edytowalne ścieżki ruchu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona za pośrednictwem Javy."
---
## **Przegląd**

Niestandardowe zachowania animacji pozwalają kontrolować poszczególne operacje w ramach efektu animacji, takie jak zmiana koloru, obrót kształtu lub podążanie edytowalną ścieżką ruchu. Ten przewodnik pokazuje, jak tworzyć i łączyć zachowania, konfigurować ich timing, przeglądać i modyfikować istniejące animacje oraz weryfikować, że ich właściwości przetrwają zapis i ponowne otwarcie prezentacji.

For predefined effects and click triggers, see [Animacje Kształtów](/slides/pl/python-java/shape-animation/).

## **Zrozumienie Modelu Animacji**

An animation is organized as **Timeline → Sequence → Effect → Behaviors**:

- Metoda [getTimeline](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getTimeline) zwraca oś czasu slajdu, która zawiera jego główną sekwencję i sekwencje interaktywne.
- [Sequence](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/) zawiera efekty, potencjalnie skierowane do różnych kształtów.
- [Effect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effect/) określa docelowy kształt, preset, podtyp i timing efektu.
- Kolekcja zwracana przez [Effect.getBehaviors](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effect/#getBehaviors) zawiera operacje realizujące efekt: zmianę koloru, przemieszczanie, obrót, ustawianie właściwości i tak dalej.

## **Tworzenie Pojedynczych Zachowań**

Wywołaj [Sequence.addEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/#addEffect), aby utworzyć efekt i uzyskać dostęp do kolekcji [getBehaviors](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effect/#getBehaviors). Preset może automatycznie wypełnić tę kolekcję. Zachowaj jego operacje przy rozszerzaniu presetu lub użyj [clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorcollection/#clear), gdy zamierzasz je zastąpić.

BehaviorFactory tworzy osiem typów zachowań przedstawionych poniżej. Ruch jest opisany w sekcji [Build a Motion Path](#build-a-motion-path). Każdy fragment kodu zawiera importy i uruchamia JVM, jeśli to konieczne. Obiekty punktów i tablice Java są tworzone przez JPype tam, gdzie API tego wymaga. Przykłady późniejszej edycji podają, którego pliku wyjściowego używują.

### **Obrót**

Użyj [createRotationEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorfactory/#createRotationEffect), aby utworzyć obrót. [getBy](https://reference.aspose.com/slides/pl/python-java/aspose.slides/rotationeffect/#getBy) określa kąt względny w stopniach; [getFrom](https://reference.aspose.com/slides/pl/python-java/aspose.slides/rotationeffect/#getFrom) i [getTo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/rotationeffect/#getTo) określają punkty końcowe.

Przykład zaczyna się od efektu Spin, zastępuje jego operacje presetowe jednym zachowaniem obrotu i nadaje temu zachowaniu dwusekundową długość. Relative kąt 90 stopni oznacza ćwiartkowy obrót względem początkowej orientacji kształtu, więc nie jest potrzebny jawny kąt początkowy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` zawiera jeden kształt i jedno zachowanie obrotu. Kolekcja, timing i przykłady edycji obrotu poniżej używają tego pliku.

### **Skalowanie**

Użyj [createScaleEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorfactory/#createScaleEffect) z procentami X/Y: [getFrom](https://reference.aspose.com/slides/pl/python-java/aspose.slides/scaleeffect/#getFrom) i [getTo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/scaleeffect/#getTo) opisują początkowy i końcowy rozmiar, natomiast [getBy](https://reference.aspose.com/slides/pl/python-java/aspose.slides/scaleeffect/#getBy) opisuje zmianę względną. Tutaj 100 oznacza oryginalny rozmiar.

Przykład zwiększa oba wymiary z 100 % do 125 % w ciągu dwóch sekund. Użycie równych procentów w poziomie i pionie zachowuje proporcje kształtu; różne procenty rozciągną jedną płaszczyznę bardziej niż drugą.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kolor**

Użyj [createColorEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorfactory/#createColorEffect), aby zmienić wypełnienie z niebieskiego na pomarańczowy. [getFrom](https://reference.aspose.com/slides/pl/python-java/aspose.slides/coloreffect/#getFrom) i [getTo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/coloreffect/#getTo) są kolorami; [getBy](https://reference.aspose.com/slides/pl/python-java/aspose.slides/coloreffect/#getBy) jest przesunięciem koloru. [Behavior.getProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behavior/#getProperties) identyfikuje atrybut animowany.

Stałe wypełnienie kształtu jest zainicjowane na niebiesko, co odpowiada początkowemu kolorowi animacji. Wybranie atrybutu wypełnienia kolorem informuje zachowanie, którą część kształtu zmienić; same kolory końcowe nie określają tego atrybutu. Zapisany efekt opisuje dwusekundowe przejście do pomarańczowego.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Filtr**

Użyj [createFilterEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorfactory/#createFilterEffect), aby wybrać wycieranie. [getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filtereffect/#getSubtype) i [getReveal](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filtereffect/#getReveal) określają filtr, kierunek i czy ujawnić lub ukryć kształt.

Ten przykład konfiguruje dwusekundowe wycieranie, które ujawnia kształt przy użyciu podtypu kierunku w prawo. Ustawienia filtru należą do zachowania wewnątrz efektu, więc są konfigurowane po usunięciu oryginalnych operacji presetu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Właściwość**

Użyj [createPropertyEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorfactory/#createPropertyEffect), aby animować przezroczystość. [getFrom](https://reference.aspose.com/slides/pl/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/propertyeffect/#getTo) i [getBy](https://reference.aspose.com/slides/pl/python-java/aspose.slides/propertyeffect/#getBy) są łańcuchami znaków interpretowanymi przy użyciu [getValueType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/propertyeffect/#getValueType) i [getCalcMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/propertyeffect/#getCalcMode). Wybierz końcowe punkty lub przesunięcie względne zamiast ustawiać wszystkie trzy niepostrzeżenie.

Tutaj wybraną właściwością jest przezroczystość, a numeryczne łańcuchy reprezentują zmianę z 25 % przezroczystości do pełnej nieprzezroczystości. Interpolacja liniowa opisuje stopniową zmianę pomiędzy tymi wartościami. Przy adaptacji tego przykładu do innej właściwości wybierz typ wartości i wartości końcowe odpowiednie dla tej właściwości.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ustawienie**

Użyj [createSetEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorfactory/#createSetEffect), aby przypisać widoczność przy użyciu [getTo]. Zachowanie set nie interpoluje pomiędzy punktami końcowymi.

Przykład wybiera atrybut widoczności i przypisuje łańcuch `visible` podczas działania zachowania. Prostokąt jest już widoczny w tej minimalnej prezentacji, więc przypisanie może nie wywołać oczywistej zmiany wizualnej. Taka operacja jest użyteczna jako część większego efektu, który również kontroluje, kiedy kształt ma być ukryty lub widoczny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Polecenie**

Użyj [createCommandEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorfactory/#createCommandEffect) i skonfiguruj [getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/pl/python-java/aspose.slides/commandeffect/#getCommandString) oraz [getShapeTarget](https://reference.aspose.com/slides/pl/python-java/aspose.slides/commandeffect/#getShapeTarget). Umieść nagranie WAV o nazwie `sample.wav` w katalogu roboczym. Ten przykład osadza je przy pomocy [addAudioFrameEmbedded](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) i dołącza polecenie odtwarzania do ramki audio.

Rama audio jest jednocześnie celem efektu i celem polecenia. Łączy to żądanie odtworzenia z osadzonym nagraniem; sam ciąg polecenia nie identyfikuje, który obiekt multimedialny kontrolować. Efekt jest skonfigurowany, by rozpocząć się po kliknięciu podczas pokazu slajdów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Zapis zapisuje polecenie w `command.pptx`; nie odtwarza nagrania. Odtwarzanie wymaga odtwarzacza pokazu slajdów, który obsługuje polecenie i jego docelowy plik multimedialny.

## **Zarządzanie Kolekcją Zachowań**

Kolekcja [BehaviorCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorcollection/) obsługuje [add](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorcollection/#remove) i [removeAt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorcollection/#removeAt). Ten przykład otwiera `rotation.pptx`, dodaje skalowanie, przesuwa je przed obrót i usuwa obrót. Usunięcie i ponowne wstawienie tego samego obiektu zmienia jego zapisane położenie bez tworzenia kopii.

Sekwencja edycji zmienia kolekcję z obrót‑skalowanie na skalowanie‑obrót, a następnie tylko skalowanie. Indeksy odnoszą się do bieżącej kolekcji, więc usunięcie używa nowego indeksu obrotu po przestawieniu. Ostateczna enumeracja potwierdza, które zachowanie zostanie zapisane.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wyjściem jest `ScaleEffect`: pozostaje tylko skalowanie. Kolejność w kolekcji sama w sobie nie planuje zachowań jedno po drugim. Czyść kolekcję tylko wtedy, gdy zamierzasz zastąpić wszystkie jej operacje.

## **Konfiguracja Timingów Zachowań**

[Behavior.getTiming](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behavior/#getTiming) udostępnia [Timing](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/), niezależnie od [Effect.getTiming](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effect/#getTiming). Timing efektu planuje otaczający go efekt; timing zachowania opisuje operację wewnątrz niego.

### **Ustawienie Czasu Trwania, Opóźnienia, Powtórzeń i Przyspieszenia**

Otwórz `rotation.pptx` i ustaw czas trwania ([getDuration](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getDuration)) oraz opóźnienie wyzwalacza ([getTriggerDelayTime](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getTriggerDelayTime)) w sekundach, a następnie skonfiguruj liczbę powtórzeń przy pomocy [setRepeatCount](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getAccelerate) i [getDecelerate](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getDecelerate) są ułamkami czasu trwania; ich suma nie powinna przekraczać 1.

Plik wejściowy to ten utworzony w przykładzie obrotu, gdzie pierwsze zachowanie jest obrotem. Ten przykład zmienia tylko timing tego zachowania; kąt 90 stopni pozostaje niezmieniony. Trzymanie kąta i timingu osobno ułatwia regulację tempa bez przebudowywania animacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Zachowanie używa dwusekundowego czasu trwania, półsekundowego opóźnienia oraz trzykrotnego powtórzenia. Pierwsze i ostatnie 20 % jego czasu trwania służy przyspieszeniu i zwolnieniu.

Inne polityki powtórzeń obejmują [getRepeatDuration](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) i [getRepeatUntilNextClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getRepeatUntilNextClick); wybierz jedną politykę zamiast włączania ich wszystkich jednocześnie. [getAutoReverse](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getAutoReverse) odtwarza animację od tyłu po przejściu w przód. Przyspieszenie i zwolnienie mają zastosowanie do ciągłych zmian, a nie do dyskretnych przypisań lub poleceń.

## **Tworzenie Ścieżki Ruchu**

Użyj [createMotionEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorfactory/#createMotionEffect), aby utworzyć ruch. Jego [getFrom](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motioneffect/#getTo) i [getBy](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motioneffect/#getBy) opisują współrzędne lub przesunięcia oparte na procentach. Aby uzyskać edytowalną trasę, utwórz [MotionPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motionpath/) i przypisz go przy pomocy [MotionEffect.setPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motionpath/) przechowuje polecenia ścieżki.

[MotionCommandPathType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motioncommandpathtype/) wybiera operację:

| Komenda | Punkty | Znaczenie |
| --- | --- | --- |
| MoveTo | One | Ustaw początkową pozycję. |
| LineTo | One | Przesuń wzdłuż prostej do punktu końcowego. |
| CurveTo | Three | Śledź krzywą sześcienną zdefiniowaną przez dwa punkty kontrolne i punkt końcowy. |
| CloseLoop | None | Powróć do pozycji początkowej. |
| End | None | Zakończ ścieżkę. |

[MotionPathPointsType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motionpathpointstype/) opisuje cechy edycji punktów, takie jak punkty narożne lub wygładzone. Nie zastępuje typu komendy. Użyj typu punktu krzywej dla przykładu krzywej poniżej, oraz typu punktu narożnego dla segmentów prostych.

Współrzędne ścieżki są znormalizowane do wymiarów slajdu: przemieszczenie X o 0,25 odpowiada jednej czwartej szerokości slajdu, nie 0,25 punktu. Dodatni Y biegnie w dół. Polecenia bezwzględne określają pozycje w systemie współrzędnych ścieżki; polecenia względne określają przesunięcia od bieżącej pozycji. To jest oddzielne od [getOrigin](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motioneffect/#getOrigin), które wybiera ramkę odniesienia ścieżki, oraz [getPathEditMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motioneffect/#getPathEditMode), które kontroluje, jak ścieżka przemieszcza się przy ruchu kształtu.

### **Utworzenie Prostej Ścieżki**

Utwórz zachowanie ruchu z punktem początkowym, jednym prostym segmentem i poleceniem końcowym. [MotionPath.add](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motionpath/#add) przyjmuje typ polecenia, jego punkty, typ punktu i flagę współrzędnych względnych.

Początkowe polecenie ustawia (0, 0), a linia kończy się w (0.25, 0), dając trasę przemieszczenie poziome o jedną czwartą szerokości slajdu. Polecenie końcowe nie ma punktów współrzędnych. Po przypisaniu ścieżki, dodanie zachowania ruchu do efektu łączy tę trasę z prostokątem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` zawiera jedno zachowanie ruchu z trzema poleceniami ścieżki. Następujące przykłady edycji plików używają tej znanej struktury.

### **Porównanie Współrzędnych Bezwzględnych i Względnych**

Te dwa obiekty ścieżki opisują tę samą trasę. Polecenie bezwzględne kończy się w (0.3, 0.1); polecenie względne dodaje (0.1, 0.1) do bieżącej pozycji, (0.2, 0).

Obie ścieżki zaczynają się w tej samej pozycji. Dla linii względnej dodaj jej przesunięcia X i Y do bieżącej pozycji, aby uzyskać punkt końcowy; dla linii bezwzględnej odczytaj punkt końcowy bezpośrednio. Zmiana flagi bez konwersji współrzędnych opisałaby inną trasę.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

Przypisz jedną z ścieżek do zachowania ruchu, aby użyć jej w prezentacji. Ostatni argument Boolean wybiera współrzędne względne dla tego polecenia.

### **Zastąpienie Linii Krzywą**

Otwórz `motion.pptx` i zamień jego polecenie linii na krzywą sześcienną. Najpierw podaj dwa punkty kontrolne, a następnie punkt końcowy.

Pozycja początkowa jest dostarczona przez poprzednie polecenie. Pierwsze dwa punkty kształtują krzywą, a trzeci jest jej celem; nie są to trzy kolejne cele. Aktualizacja typu polecenia, typu edycji punktów i tablicy punktów razem utrzymuje segment spójny z nową geometrią.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ścieżka w `curve.pptx` nadal ma trzy polecenia; jej środkowe polecenie teraz definiuje krzywą.

## **Inspekcja i Edycja Zapisanej Ścieżki**

Każdy [MotionCmdPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motioncmdpath/) udostępnia [getPoints](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motioncmdpath/#getPointsType) i [isRelative](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motioncmdpath/#isRelative). Poniższe przykłady używają znanej ścieżki z trzema poleceniami w `motion.pptx`. Dla dowolnego wejścia odnajdź docelowy efekt i sprawdź typy poleceń oraz liczbę punktów przed edycją według indeksu.

### **Odczyt Poleceń i Współrzędnych**

Odczytaj ścieżkę bez jej modyfikacji. Polecenia End i CloseLoop nie wymagają punktów, więc należy uwzględnić możliwość nullowej tablicy punktów.

Wyjście łączy każdy numeryczny typ polecenia z jego flagą współrzędnych względnych przed wypisaniem punktów. Pozwala to odróżnić punkt końcowy od offsetu przed modyfikacją ścieżki. Krzywa wypisze trzy punkty, podczas gdy prosta linia w tym pliku wypisuje tylko jeden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

Lista zawiera punkt początkowy, bezwzględną linię kończącą się w (0.25, 0) oraz polecenie end.

### **Zmiana Punktu Końcowego**

Otwórz `motion.pptx` i zamień tablicę punktów linii, aby przesunąć jej punkt końcowy.

W pliku wejściowym indeks 0 to polecenie początkowe, a indeks 1 to linia. Zastąpienie jednego punktu linii zmienia jej docelową pozycję bez zmiany typu polecenia, timingu lub pozycji w kolekcji. Ponieważ polecenie używa współrzędnych bezwzględnych, nowa para określa pozycję, a nie dodany offset.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Linia w `motion-endpoint.pptx` kończy się w (0.4, 0.1); oryginalny plik pozostaje niezmieniony.

### **Zastąpienie Segmentu**

Użyj [insert](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motionpath/#insert) i [removeAt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/motionpath/#removeAt), aby zastąpić linię w `motion.pptx`. Wstawienie przesuwa starą linię do indeksu 2.

To pokazuje zamianę obiektu polecenia zamiast edycji jego istniejących współrzędnych. Po wstawieniu kolekcja tymczasowo zawiera polecenie startowe, nową linię, starą linię i polecenie end. Usunięcie indeksu 2 usuwa starą linię i pozostawia nową trasę.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Zapisana ścieżka nadal ma trzy polecenia, przy czym nowa linia kończy się w (0.2, 0.1), a polecenie end jest ostatnie.

## **Modyfikacja i Weryfikacja Istniejącego Zachowania**

Gdy indeks zachowania jest nieznany, wybierz je według typu. Ten przykład otwiera `rotation.pptx`, znajduje jego [RotationEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/rotationeffect/), zmienia kąt i sprawdza zapisaną wartość po ponownym otwarciu.

Sprawdzenie typu pozwala pętli pominąć zachowania, które nie są obrotami. Drugi odczyt wczytuje zapisany plik do osobnego obiektu prezentacji, więc porównanie sprawdza utrwalone dane, a nie wartość wciąż trzymaną w pamięci. Ten przykład nadal zakłada, że znany efekt jest pierwszy w głównej sekwencji; wybór zachowania według typu nie znajduje właściwego efektu w dowolnej prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Wyjściem jest `Rotation preserved: True`. Zastosuj ten sam schemat sprawdzania typu do innych zachowań. Aby przeprowadzić pełną weryfikację zachowania, porównaj docelowy kształt, efekt, typy i kolejność zachowań, timing oraz polecenia ścieżki. Użyj tolerancji numerycznej dla wartości zmiennoprzecinkowych. Dla prezentacji o nieznanej strukturze animacji, zobacz [Read Shape Animations](/slides/pl/python-java/shape-animation/#read-shape-animations) aby przejść przez główne i interaktywne sekwencje.

## **Kolejność Zachowań, Presety i Odtwarzanie**

Kolejność w [BehaviorCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behaviorcollection/) jest zapisaną kolejnością operacji efektu. Nie jest to lista odtwarzania, w której każde zachowanie automatycznie czeka na poprzednie. Timing i otaczający efekt określają planowanie. Zachowania mogą się nakładać, a operacje na tej samej właściwości mogą współdziałać poprzez [getAdditive](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behavior/#getAdditive) i [getAccumulate](https://reference.aspose.com/slides/pl/python-java/aspose.slides/behavior/#getAccumulate). Nie używaj samodzielnie przestawiania kolekcji, aby zaplanować „przesuń, a potem obróć”; użyj wyraźnego timingu lub oddzielnych efektów, jak opisano w [Animacje Kształtów](/slides/pl/python-java/shape-animation/).

Typ efektu [getType] i [getSubtype] opisują jego preset. Nie stanowią pełnego opisu edytowanego drzewa zachowań. Wybierz preset i podtyp przed dostosowywaniem zachowań: zmiana presetu może odbudować kolekcję i odrzucić twoje niestandardowe operacje. Na przykład zmiana spersonalizowanego efektu Spin na Fade może zastąpić jego zachowanie rotacji zachowaniami set i filter. Ponownie sprawdź kolekcję po zmianie presetu lub podtypu. Czyszczenie zachowań presetu może także usunąć operacje widoczności lub inicjalizacji, które preset wymaga. Przykłady celowo używają widocznych kształtów i zastępują zachowania; nie odtwarzają pełnej implementacji każdego presetu.

## **Kompatybilność Formatu**

Zachowane drzewo zachowań nie gwarantuje identycznego odtwarzania w każdym przeglądarce ani rendererze eksportu. Sprawdź osobno zapisane dane i wygenerowany wynik.

| Format lub wynik | Co zweryfikować |
| --- | --- |
| PPTX | Używaj jako głównego formatu w tych przykładach. Otwórz ponownie, aby zweryfikować edytowalne drzewo zachowań, następnie sprawdź odtwarzanie w docelowej wersji PowerPoint. |
| PPT | Legacy binary representation może różnić się od PPTX. Przetestuj oddzielny cykl zapisu‑odczytu i odtwarzanie; nie wnioskować o wsparciu każdej niestandardowej kombinacji na podstawie udanego wyniku PPTX. |
| PDF, PNG, JPEG i inne statyczne obrazy slajdów | Zawierają statyczną reprezentację slajdu, nie odtwarzalną oś czasu zachowań ani gwarantowaną finalną klatkę animacji. |
| HTML5 | Może odtwarzać obsługiwane animacje, gdy animacja kształtu jest włączona w opcjach eksportu. Przetestuj własne kombinacje w przeglądarce. |
| Animated GIF | Przechowuje wyrenderowane klatki, nie edytowalne zachowania ani interakcje wyzwalane kliknięciem. Sprawdź rzeczywisty wyrenderowany ruch. |
| Video | Renderuje klatki animacji i koduje je jako wideo. Wsparcie jest ograniczone do [supported animations and effects](/slides/pl/python-java/convert-to-video/#supported-animations-and-effects); polecenia i zdarzenia interaktywne nie stają się edytowalną osią czasu. |

## **FAQ**

**Dlaczego mój efekt zawiera zachowania zanim je dodam?**

Tworzenie predefiniowanego efektu może utworzyć jego podstawowe operacje. Przejrzyj je zanim zdecydujesz, czy rozszerzyć preset, czy zastąpić jego zachowania.

**Czy przeniesienie zachowania na początek powoduje, że odtwarza się jako pierwsze?**

Niekoniecznie. Kolejność w kolekcji nie zastępuje timingu. Sprawdź opóźnienia, czasy trwania i interakcje między operacjami na tej samej właściwości.

**Dlaczego polecenie end nie ma punktów?**

Oznacza koniec ścieżki i nie wymaga współrzędnych. Sprawdź, czy tablica punktów nie jest null podczas przeglądania ścieżki odczytanej z pliku.

**Czy udany round‑trip wystarczy, aby potwierdzić odtwarzanie?**

Nie. Ponowne otwarcie potwierdza zachowanie sprawdzonych właściwości. Przetestuj odtwarzacz pokazu slajdów lub eksport animacji osobno, aby potwierdzić jego zachowanie wizualne.