---
title: Tworzenie i modyfikowanie niestandardowych zachowań animacji w Pythonie
linktitle: Animacja niestandardowa
type: docs
weight: 151
url: /pl/python-net/custom-animation/
keywords:
- animacja niestandardowa
- zachowanie animacji
- ścieżka ruchu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Twórz, przeglądaj i modyfikuj niestandardowe zachowania animacji oraz edytowalne ścieżki ruchu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona w środowisku .NET."
---
## **Przegląd**

Dostosowane zachowania animacji pozwalają kontrolować poszczególne operacje w ramach efektu animacji, takie jak zmiana koloru, obrót kształtu lub podążanie za edytowalną ścieżką ruchu. Ten przewodnik pokazuje, jak tworzyć i łączyć zachowania, konfigurować ich czas, przeglądać i modyfikować istniejące animacje oraz sprawdzić, czy ich właściwości przetrwają zapis i ponowne otwarcie prezentacji.

For predefined effects and click triggers, see [Animacja Kształtów](/slides/pl/python-net/shape-animation/).

## **Zrozumienie modelu animacji**

Animacja jest zorganizowana jako **Oś czasu → Sekwencja → Efekt → Zachowania**:

- Linia czasu slajdu ([timeline](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/timeline/)) zawiera jej główną sekwencję oraz sekwencje interaktywne.  
- [Sekwencja](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/) zawiera efekty, potencjalnie skierowane do różnych kształtów.  
- [Efekt](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effect/) identyfikuje docelowy kształt, predefiniowany zestaw, podtyp i czas trwania efektu.  
- [Zachowania efektu](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effect/behaviors/) zawierają operacje implementujące efekt: zmianę koloru, przemieszczenie, obrót, ustawienie właściwości itp.

## **Utworzenie pojedynczych zachowań**

Wywołaj [Sequence.add_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/add_effect/) aby utworzyć efekt i uzyskać dostęp do jego kolekcji [zachowań](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effect/behaviors/). Predefiniowany zestaw może automatycznie wypełnić tę kolekcję. Zachowaj jego operacje przy rozszerzaniu zestawu lub użyj [clear](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorcollection/clear/) przy celowym ich zastąpieniu.

[BehaviorFactory](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorfactory/) tworzy osiem typów zachowań zilustrowanych poniżej. Ruch jest opisany w sekcji [Tworzenie ścieżki ruchu](#tworzenie-ścieżki-ruchu). Każdy przykład tworzenia jest kompletnym programem; późniejsze przykłady edycji wskazują, który plik wyjściowy jest używany.

### **Obrót**

Użyj [create_rotation_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) aby utworzyć obrót. [by](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/rotationeffect/by/) określa kąt względny w stopniach; [from_address](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/rotationeffect/from_address/) i [to](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/rotationeffect/to/) określają punkty końcowe.

Przykład zaczyna się od efektu Spin, zastępuje jego operacje predefiniowane jednym zachowaniem obrotu i nadaje temu zachowaniu dwusekundowy czas trwania. Kąt względny 90 stopni oznacza ćwierć obrotu względem początkowej orientacji kształtu, więc nie jest potrzebny jawny kąt początkowy.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` zawiera jeden kształt i jedno zachowanie obrotu. Kolekcja, czas oraz przykłady edycji obrotu poniżej używają tego pliku.

### **Skalowanie**

Użyj [create_scale_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) z procentami X/Y: [from_address](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/scaleeffect/from_address/) i [to](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/scaleeffect/to/) opisują początkowy i końcowy rozmiar, a [by](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/scaleeffect/by/) opisuje zmianę względną. Tutaj 100 oznacza oryginalny rozmiar.

Przykład powiększa oba wymiary z 100 % do 125 % w ciągu dwóch sekund. Użycie równych wartości poziomych i pionowych zachowuje proporcje kształtu; inne wartości rozciągną jedną z osi bardziej niż drugą.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Kolor**

Użyj [create_color_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) aby zmienić wypełnienie z niebieskiego na pomarańczowy. [from_address](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/coloreffect/from_address/) i [to](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/coloreffect/to/) są kolorami; [by](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/coloreffect/by/) jest przesunięciem koloru. [Behavior.properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behavior/properties/) identyfikuje animowaną właściwość.

Kształt ma początkowo wypełnienie stałe niebieskim, co odpowiada początkowemu kolorowi animacji. Wybranie atrybutu wypełnienia informuje zachowanie, którą część kształtu zmienić; same kolory końcowe nie określają tego atrybutu. Zapisany efekt opisuje dwusekundowy przejściowy do pomarańczowego.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Filtr**

Użyj [create_filter_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) aby wybrać wyczyszczenie. [type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/filtereffect/subtype/) i [reveal](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/filtereffect/reveal/) określają filtr, kierunek oraz to, czy odsłonić czy ukryć kształt.

Przykład konfiguruje dwusekundowy wyczyszczenie odsłaniający kształt w kierunku prawego podtypu. Ustawienia filtru należą do zachowania wewnątrz efektu, więc są konfigurowane po usunięciu pierwotnych operacji zestawu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Właściwość**

Użyj [create_property_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) aby animować nieprzezroczystość. [from_address](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/propertyeffect/to/) i [by](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/propertyeffect/by/) są łańcuchami interpretowanymi przy użyciu [value_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/propertyeffect/value_type/) i [calc_mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/propertyeffect/calc_mode/). Wybierz punkty końcowe lub offset względny zamiast ustawiać wszystkie trzy wartości jednocześnie.

Tutaj wybraną właściwością jest nieprzezroczystość, a łańcuchy liczbowe reprezentują zmianę z 25 % nieprzezroczystości do pełnej nieprzezroczystości. Liniowa interpolacja opisuje stopniową zmianę między tymi wartościami. Przy dostosowywaniu tego przykładu do innej właściwości wybierz odpowiedni typ wartości i wartości końcowe odpowiednie dla tej właściwości.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Ustawienie**

Użyj [create_set_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) aby przypisać widoczność przez [to](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/seteffect/to/). Zachowanie ustawiające nie interpoluje między punktami końcowymi.

Przykład wybiera atrybut widoczności i przypisuje łańcuch `visible` podczas wykonywania zachowania. Prostokąt jest już widoczny w tej minimalnej prezentacji, więc przypisanie może nie wywołać oczywistej zmiany wizualnej samodzielnie. Taka operacja jest przydatna jako część większego efektu, który również kontroluje moment ukrycia lub pokazania kształtu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Polecenie**

Użyj [create_command_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) i skonfiguruj [type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/commandeffect/command_string/) oraz [shape_target](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/commandeffect/shape_target/). Umieść nagranie WAV o nazwie `sample.wav` w katalogu roboczym. Ten przykład osadza je przy pomocy [add_audio_frame_embedded](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) i dołącza polecenie odtworzenia do ramki audio.

Rama audio jest jednocześnie celem efektu i celem polecenia. Łączy to żądanie odtworzenia z osadzonym nagraniem; sam ciąg polecenia nie określa, który obiekt multimedialny ma być kontrolowany. Efekt jest skonfigurowany tak, aby rozpocząć się po kliknięciu podczas pokazu slajdów.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

Zapis zapisuje polecenie w `command.pptx`; nie odtwarza ono nagrania. Odtwarzanie wymaga odtwarzacza pokazu slajdów, który obsługuje polecenie i jego docelowy element multimedialny.

## **Zarządzanie kolekcją zachowań**

[BehaviorCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorcollection/) obsługuje [add](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorcollection/remove/) i [remove_at](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorcollection/remove_at/). Ten przykład otwiera `rotation.pptx`, dodaje skalowanie, przemieszcza je przed obrotem i usuwa obrót. Usunięcie i ponowne wstawienie tego samego obiektu zmienia jego przechowywaną pozycję bez tworzenia kopii.

Sekwencja edycji zmienia kolekcję z obrót‑skalowanie na skalowanie‑obrót, a potem tylko skalowanie. Indeksy odnoszą się do bieżącej kolekcji, więc usunięcie używa nowego indeksu obrotu po przestawieniu. Końcowe wyliczenie potwierdza, które zachowanie zostanie zapisane.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

Wynik to `ScaleEffect`: pozostało tylko skalowanie. Sam porządek kolekcji nie planuje kolejności odtwarzania zachowań. Czyść kolekcję tylko wtedy, gdy zamierzasz zastąpić wszystkie jej operacje.

## **Konfigurowanie czasu zachowania**

[Behavior.timing](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behavior/timing/) udostępnia [Timing](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/), niezależnie od [Effect.timing](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effect/timing/). Czas efektu planuje otaczający efekt; czas zachowania opisuje operację wewnątrz niego.

### **Ustawienie czasu trwania, opóźnienia, powtórzenia i przyspieszenia**

Otwórz `rotation.pptx` i ustaw [duration](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/duration/) oraz [trigger_delay_time](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/trigger_delay_time/) w sekundach, a następnie skonfiguruj [repeat_count](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/repeat_count/). [accelerate](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/accelerate/) i [decelerate](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/decelerate/) są ułamkami czasu trwania; ich suma nie powinna przekraczać 1.

Plik wejściowy to ten utworzony w przykładzie obrotu, gdzie pierwsze zachowanie jest znane jako obrót. Ten przykład zmienia wyłącznie czas tego zachowania; kąt 90 stopni pozostaje niezmieniony. Rozdzielenie kąta i czasu ułatwia dostosowanie tempa bez przebudowy animacji.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

Zachowanie używa dwusekundowego czasu trwania, półsekundowego opóźnienia i trzykrotnego powtórzenia. Pierwsze i ostatnie 20 % jego czasu przeznaczone jest na przyspieszenie i zwolnienie.

Inne polityki powtórzeń obejmują [repeat_duration](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) i [repeat_until_next_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/repeat_until_next_click/); wybierz jedną politykę zamiast włączania ich wszystkich jednocześnie. [auto_reverse](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/auto_reverse/) odtwarza animację wstecz po przejściu w przód. Przyspieszenie i zwolnienie mają zastosowanie do ciągłych zmian, a nie do dyskretnych przypisań czy poleceń.

## **Tworzenie ścieżki ruchu**

Użyj [create_motion_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) aby utworzyć ruch. Jego [from_address](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioneffect/to/) i [by](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioneffect/by/) opisują współrzędne procentowe lub offsety. Aby uzyskać edytowalną trasę, utwórz [MotionPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motionpath/) i przypisz go do [MotionEffect.path](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioneffect/path/). [MotionPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motionpath/) przechowuje polecenia ścieżki.

[MotionCommandPathType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioncommandpathtype/) wybiera operację:

| Command | Points | Meaning |
| --- | --- | --- |
| MOVE_TO | One | Ustaw początkową pozycję. |
| LINE_TO | One | Przemieszcz się po prostym odcinku do jego punktu końcowego. |
| CURVE_TO | Three | Śledź krzywą sześcienną określoną przez dwa punkty kontrolne i punkt końcowy. |
| CLOSE_LOOP | None | Wróć do pozycji początkowej. |
| END | None | Zakończ ścieżkę. |

[MotionPathPointsType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motionpathpointstype/) opisuje charakterystykę edycji punktów, np. wierzchołki narożne lub wygładzone. Nie zastępuje typu polecenia. Użyj typu punktu krzywej dla przykładu krzywej poniżej oraz typu punktu narożnego dla odcinków prostych.

Współrzędne ścieżki są znormalizowane do wymiarów slajdu: przemieszczenie X równe 0.25 oznacza jedną czwartą szerokości slajdu, a nie 0.25 punktu. Pozytywne Y rośnie w dół. Polecenia bezwzględne określają pozycje w układzie współrzędnych ścieżki; polecenia względne określają offsety od bieżącej pozycji. To jest oddzielne od [origin](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioneffect/origin/), które wybiera ramę odniesienia ścieżki, oraz [path_edit_mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), które kontroluje, jak ścieżka przemieszcza się razem z kształtem.

### **Utworzenie prostej ścieżki**

Utwórz zachowanie ruchu z punktem początkowym, jednym odcinkiem prostym i poleceniem końcowym. [MotionPath.add](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motionpath/add/) przyjmuje typ polecenia, jego punkty, typ punktu oraz flagę współrzędnej względnej.

Polecenie początkowe ustawia (0, 0), a linia kończy się w (0.25, 0), dając trasę przesunięcia poziomego o jedną czwartą szerokości slajdu. Polecenie końcowe nie posiada punktów współrzędnych. Po przypisaniu ścieżki, dodanie zachowania ruchu do efektu łączy tę trasę z prostokątem.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` zawiera jedno zachowanie ruchu z trzema poleceniami ścieżki. Poniższe przykłady edycji pliku używają tej znanej struktury.

### **Porównanie współrzędnych bezwzględnych i względnych**

Te dwa obiekty ścieżki opisują tę samą trasę. Polecenie bezwzględne kończy się w (0.3, 0.1); polecenie względne dodaje (0.1, 0.1) do bieżącej pozycji (0.2, 0).

Obie ścieżki zaczynają się w tym samym miejscu. Dla linii względnej dodaj jej offsety X i Y do bieżącej pozycji, aby otrzymać punkt końcowy; dla linii bezwzględnej odczytaj punkt końcowy bezpośrednio. Przełączenie flagi bez konwersji współrzędnych opisze inną trasę.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

Przypisz dowolną ścieżkę do zachowania ruchu, aby użyć jej w prezentacji. Ostatni argument logiczny wybiera współrzędne względne dla tego polecenia.

### **Zastąpienie linii krzywą**

Otwórz `motion.pptx` i zamień jego polecenie linii na krzywą sześcienną. Najpierw podaj dwa punkty kontrolne, a na końcu punkt końcowy.

Pozycja początkowa jest określona przez poprzednie polecenie. Dwa pierwsze punkty kształtują krzywą, trzeci jest jej docelowym punktem; nie są to trzy kolejne cele. Aktualizacja typu polecenia, typu edycji punktów i tablicy punktów razem utrzymuje segment spójny z nową geometrią.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

Ścieżka w `curve.pptx` nadal ma trzy polecenia; jej środkowe polecenie teraz definiuje krzywą.

## **Inspekcja i edycja zapisanej ścieżki**

Każdy [MotionCmdPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioncmdpath/) udostępnia [points](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioncmdpath/points_type/) oraz [is_relative](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioncmdpath/is_relative/). Poniższe przykłady używają znanej trójpoleceniowej ścieżki w `motion.pptx`. Dla dowolnego wejścia znajdź docelowy efekt i sprawdź typy poleceń oraz liczbę punktów przed edycją po indeksie.

### **Odczyt poleceń i współrzędnych**

Odczytaj ścieżkę bez jej zmieniania. Polecenia end i close-loop nie potrzebują punktów, więc dopuszczalne jest `None` jako tablica punktów.

Wynik wymienia każde polecenie wraz ze flagą współrzędnych względnych, a następnie wymienia jego punkty. Pozwala to odróżnić punkt końcowy od offsetu przed modyfikacją ścieżki. Krzywa wymieniłaby trzy punkty, podczas gdy prosta linia w tym pliku wymienia tylko jeden.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

Lista zawiera punkt początkowy, bezwzględną linię kończącą się w (0.25, 0) oraz polecenie end.

### **Zmienianie punktu końcowego**

Otwórz `motion.pptx` i zamień tablicę punktów linii, aby przesunąć jej punkt końcowy.

W pliku wejściowym indeks 0 to polecenie początkowe, a indeks 1 to linia. Zastąpienie jednego punktu linii zmienia jej docelową pozycję bez zmiany typu polecenia, czasu ani pozycji w kolekcji. Ponieważ polecenie używa współrzędnych bezwzględnych, nowa para określa pozycję, a nie dodatkowy offset.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

Linia w `motion-endpoint.pptx` kończy się w (0.4, 0.1); oryginalny plik pozostaje niezmieniony.

### **Zastąpienie segmentu**

Użyj [insert](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motionpath/insert/) i [remove_at](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motionpath/remove_at/) aby zastąpić linię w `motion.pptx`. Wstawienie przesuwa starą linię na indeks 2.

To pokazuje zastąpienie obiektu polecenia zamiast edycji jego istniejących współrzędnych. Po wstawieniu kolekcja tymczasowo zawiera polecenie początkowe, nową linię, starą linię i polecenie end. Usunięcie indeksu 2 usuwa starą linię, pozostawiając nową trasę.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

Zapisana ścieżka nadal ma trzy polecenia, przy czym nowa linia kończy się w (0.2, 0.1), a polecenie end pozostaje ostatnie.

## **Modyfikacja i weryfikacja istniejącego zachowania**

Gdy indeks zachowania jest nieznany, wybierz je po typie. Ten przykład otwiera `rotation.pptx`, znajduje jego [RotationEffect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/rotationeffect/), zmienia kąt i sprawdza zapisaną wartość po ponownym otwarciu.

Sprawdzenie typu pozwala pętli pominąć zachowania, które nie są obrotami. Drugie wczytanie odczytuje zapisany plik do osobnego obiektu prezentacji, więc porównanie weryfikuje utrwalone dane, a nie wartość wciąż trzymaną w pamięci. Ten przykład nadal zakłada, że znany efekt jest pierwszy w głównej sekwencji; wybieranie zachowania po typie nie znajduje prawidłowego efektu w dowolnej prezentacji.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

Wynik to `Rotation preserved: True`. Zastosuj ten sam wzorzec sprawdzania typu do innych zachowań. Dla pełnego sprawdzenia zachowania porównaj docelowy kształt, efekt, typy i kolejność zachowań, czas oraz polecenia ścieżki. Użyj tolerancji numerycznej dla wartości zmiennoprzecinkowych. Dla prezentacji o nieznanym układzie animacji zobacz [Read Shape Animations](/slides/pl/python-net/shape-animation/#read-shape-animations) w celu przejścia po głównych i interaktywnych sekwencjach.

## **Kolejność zachowań, predefiniowane ustawienia i odtwarzanie**

Kolejność w [BehaviorCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behaviorcollection/) jest przechowywaną kolejnością operacji efektu. Nie jest to odtwarzacz, w którym każde zachowanie automatycznie czeka na poprzednie. Czas i otaczający efekt określają harmonogram. Zachowania mogą się nakładać, a operacje na tej samej właściwości mogą oddziaływać poprzez [additive](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behavior/additive/) i [accumulate](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behavior/accumulate/). Nie używaj samego przestawiania kolekcji, aby zaplanować „przesuń, potem obróć”; zastosuj wyraźny czas lub oddzielne efekty, jak opisano w [Animacja Kształtów](/slides/pl/python-net/shape-animation/).

Typ efektu ([type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effect/type/)) i podtyp ([subtype](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effect/subtype/)) opisują jego predefiniowany zestaw. Nie są pełnym opisem edytowanego drzewa zachowań. Wybierz preset i podtyp przed dostosowaniem zachowań: zmiana predefiniowanego zestawu może przebudować kolekcję i usunąć własne operacje. Na przykład zmiana spersonalizowanego efektu Spin na Fade może zastąpić zachowanie obrotu zachowaniami set i filter. Po zmianie predefiniowanego zestawu lub podtypu ponownie sprawdź kolekcję. Czyszczenie zachowań predefiniowanego zestawu może także usunąć operacje widoczności lub inicjalizacji, które preset wymaga. Przykłady celowo używają widocznych kształtów i zastępują zachowania; nie rekonstruują one pełnej implementacji każdego zestawu.

## **Kompatybilność formatów**

Zachowane drzewo zachowań nie gwarantuje identycznego odtwarzania we wszystkich przeglądarkach lub rendererach eksportu. Sprawdź zapisane dane i oddzielnie wynik renderingu.

| Format lub wyjście | Co zweryfikować |
| --- | --- |
| PPTX | Używaj jako głównego formatu dla tych przykładów. Otwórz ponownie, aby zweryfikować edytowalne drzewo zachowań, a następnie sprawdź odtwarzanie w docelowej wersji PowerPoint. |
| PPT | Legacy binary representation może różnić się od PPTX. Przeprowadź oddzielny cykl zapisu‑odczytu i odtwarzania; nie wnioskować o wsparciu każdej kombinacji na podstawie pomyślnego wyniku PPTX. |
| PDF, PNG, JPEG i inne statyczne obrazy slajdów | Zawierają statyczną reprezentację slajdu, nie odtwarzalną oś czasu ani gwarantowaną końcową klatkę animacji. |
| [HTML5](/slides/pl/python-net/export-to-html5/) | Może odtwarzać obsługiwane animacje, gdy animacja kształtów jest włączona w opcjach eksportu. Testuj własne kombinacje w przeglądarce. |
| [Animated GIF](/slides/pl/python-net/convert-powerpoint-to-animated-gif/) | Przechowuje wyrenderowane klatki, nie edytowalne zachowania ani interakcje wyzwalane kliknięciem. Sprawdź rzeczywisty wyrenderowany ruch. |
| [Video](/slides/pl/python-net/convert-powerpoint-to-video/) | Renderuje klatki animacji i koduje je jako wideo. Wsparcie jest ograniczone do [obsługiwanych animacji i efektów](/slides/pl/python-net/convert-powerpoint-to-video/#supported-animations-and-effects); polecenia i zdarzenia interaktywne nie stają się edytowalną osią czasu. |

## **Najczęściej zadawane pytania**

**Dlaczego mój efekt zawiera zachowania zanim dodam jakiekolwiek?**

Tworzenie predefiniowanego efektu może utworzyć jego podstawowe operacje. Przejrzyj je, zanim zdecydujesz, czy rozbudować preset, czy zastąpić jego zachowania.

**Czy przeniesienie zachowania na początek powoduje, że odtworzy się jako pierwsze?**

Niekoniecznie. Kolejność w kolekcji nie zastępuje czasu. Sprawdź opóźnienia, czasy trwania i interakcje między operacjami na tej samej właściwości.

**Dlaczego polecenie end nie ma punktów?**

Oznacza koniec ścieżki i nie wymaga współrzędnych. Przy przeglądaniu ścieżki odczytanej z pliku sprawdzaj `None` jako tablicę punktów.

**Czy udany cykl zapisu‑odczytu wystarczy, żeby potwierdzić odtwarzanie?**

Nie. Otworzenie potwierdza zachowanie sprawdzonych właściwości. Testuj odtwarzacz pokazu slajdów lub eksport animacji osobno, aby potwierdzić jego wizualne zachowanie.