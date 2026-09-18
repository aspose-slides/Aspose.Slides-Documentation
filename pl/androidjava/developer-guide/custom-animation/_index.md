---
title: Tworzenie i modyfikacja niestandardowych zachowań animacji na Androidzie
linktitle: Niestandardowa animacja
type: docs
weight: 151
url: /pl/androidjava/custom-animation/
keywords:
- niestandardowa animacja
- zachowanie animacji
- ścieżka ruchu
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Twórz, przeglądaj i modyfikuj niestandardowe zachowania animacji oraz edytowalne ścieżki ruchu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida w języku Java."
---
## **Przegląd**

Niestandardowe zachowania animacji pozwalają kontrolować poszczególne operacje w ramach efektu animacji, takie jak zmiana koloru, obracanie kształtu lub podążanie za edytowalną ścieżką ruchu. Ten przewodnik pokazuje, jak tworzyć i łączyć zachowania, konfigurować ich synchronizację, przeglądać i modyfikować istniejące animacje oraz sprawdzić, czy ich właściwości przetrwają zapis i ponowne otwarcie prezentacji.

Dla gotowych efektów i wyzwalaczy kliknięcia zobacz [Shape Animation](/slides/pl/androidjava/shape-animation/).

## **Zrozumienie modelu animacji**

Animacja jest zorganizowana jako **Timeline → Sequence → Effect → Behaviors**:

- Metoda [getTimeline](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) zwraca oś czasu slajdu, która zawiera jego główną sekwencję oraz sekwencje interaktywne.
- [ISequence](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isequence/) zawiera efekty, potencjalnie skierowane do różnych kształtów.
- [IEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ieffect/) identyfikuje docelowy kształt, preset, podtyp i synchronizację efektu.
- Kolekcja zwracana przez [IEffect.getBehaviors](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ieffect/#getBehaviors--) zawiera operacje implementujące efekt: zmianę koloru, przemieszczenie, obrót, ustawienie właściwości itd.

## **Tworzenie pojedynczych zachowań**

Wywołaj [ISequence.addEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) aby utworzyć efekt i uzyskać dostęp do kolekcji [getBehaviors](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ieffect/#getBehaviors--). Preset może automatycznie wypełnić tę kolekcję. Zachowaj jego operacje przy rozszerzaniu presetu lub użyj [clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) przy celowym ich zastępowaniu.

[IBehaviorFactory](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorfactory/) tworzy osiem typów zachowań zilustrowanych poniżej. Ruch jest opisany w [Build a Motion Path](#build-a-motion-path). Każdy fragment zawiera importy; umieść jego instrukcje wykonywalne wewnątrz metody. Przykłady edycji później wskazują, którego pliku wyjściowego używają. Na Androidzie zamień nazwy plików przykładowych na pełne ścieżki w katalogu dostępnym dla aplikacji, np. w katalogu plików aplikacji.

### **Obrót**

Użyj [createRotationEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) aby utworzyć obrót. [getBy](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/irotationeffect/#getBy--) określa kąt względny w stopniach; [getFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/irotationeffect/#getFrom--) i [getTo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/irotationeffect/#getTo--) określają punkty końcowe.

Przykład zaczyna się od efektu Spin, zastępuje jego operacje presetowe jednym zachowaniem obrotu i nadaje temu zachowaniu dwusekundowy czas trwania. Kąt względny 90 stopni oznacza ćwierć obrotu względem początkowej orientacji kształtu, więc nie jest potrzebny explicite określony kąt początkowy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` zawiera jeden kształt i jedno zachowanie obrotu. Kolekcja, synchronizacja i przykłady edycji obrotu poniżej używają tego pliku.

### **Skalowanie**

Użyj [createScaleEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) z procentami X/Y: [getFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) i [getTo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iscaleeffect/#getTo--) opisują początkowy i końcowy rozmiar, natomiast [getBy](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iscaleeffect/#getBy--) opisuje zmianę względną. Tutaj 100 oznacza rozmiar oryginalny.

Przykład zwiększa oba wymiary z 100 % do 125 % w ciągu dwóch sekund. Używanie równych wartości poziomych i pionowych zachowuje proporcje kształtu; różne wartości rozciągną jedną z nich bardziej niż drugą.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kolor**

Użyj [createColorEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) aby zmienić wypełnienie z niebieskiego na pomarańczowy. [getFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icoloreffect/#getFrom--) i [getTo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icoloreffect/#getTo--) są kolorami; [getBy](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icoloreffect/#getBy--) to offset koloru. [IBehavior.getProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehavior/#getProperties--) identyfikuje atrybut podlegający animacji.

Wypełnienie kształtu jest początkowo ustawione na niebieskie, co odpowiada początkowemu kolorowi animacji. Wybranie atrybutu wypełnienia mówi zachowaniu, którą część kształtu zmienić; same kolory końcowe nie określają tego atrybutu. Zapisany efekt opisuje dwusekundową przejściową zmianę na pomarańczowy.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtr**

Użyj [createFilterEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) aby wybrać wycieranie. [getType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), i [getReveal](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) określają filtr, kierunek oraz to, czy odsłonić, czy ukryć kształt.

Ten przykład konfiguruje dwusekundowe wycieranie, które odsłania kształt przy użyciu podtypu kierunku „right”. Ustawienia filtru należą do zachowania wewnątrz efektu, więc są konfigurowane po usunięciu oryginalnych operacji presetu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Właściwość**

Użyj [createPropertyEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) aby animować nieprzezroczystość. [getFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), i [getBy](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) są łańcuchami interpretowanymi przy użyciu [getValueType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) i [getCalcMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--). Wybierz punkty końcowe lub offset względny zamiast ustawiać wszystkie trzy wartości jednocześnie.

Tutaj wybranym atrybutem jest nieprzezroczystość, a łańcuchy liczbowe reprezentują zmianę z 25 % nieprzezroczystości do pełnej nieprzezroczystości. Interpolacja liniowa opisuje stopniową zmianę między tymi wartościami. Adaptując przykład do innego atrybutu, wybierz typ wartości i wartości końcowe odpowiednie dla tego atrybutu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ustawienie**

Użyj [createSetEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) aby przypisać widoczność przez [getTo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iseteffect/#getTo--). Zachowanie typu „set” nie interpoluje pomiędzy punktami końcowymi.

Przykład wybiera atrybut widoczności i przypisuje łańcuch `visible` w momencie uruchomienia zachowania. Prostokąt jest już widoczny w tej minimalnej prezentacji, więc przypisanie może nie wywołać oczywistej zmiany wizualnej samodzielnie. Taka operacja jest przydatna jako element większego efektu, który również steruje momentem ukrywania lub pokazywania kształtu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Polecenie**

Użyj [createCommandEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) i skonfiguruj [getType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), oraz [getShapeTarget](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--). Umieść nagranie WAV o nazwie `sample.wav` w katalogu roboczym. Ten przykład osadza je przy użyciu [addAudioFrameEmbedded](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) i dołącza polecenie odtworzenia do ramki audio.

Ramka audio jest zarówno celem efektu, jak i celem polecenia. Łączy żądanie odtworzenia z osadzonym nagraniem; sam łańcuch polecenia nie wskazuje, który obiekt multimedialny kontrolować. Efekt jest skonfigurowany, aby rozpoczął się po kliknięciu podczas pokazu slajdów.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

Zapis zapisuje polecenie w `command.pptx`; nie odtwarza nagrania. Odtwarzanie wymaga odtwarzacza pokazu slajdów obsługującego polecenie i jego cel multimedialny.

## **Zarządzanie kolekcją zachowań**

[IBehaviorCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorcollection/) obsługuje [add](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), oraz [removeAt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Ten przykład otwiera `rotation.pptx`, dodaje skalowanie, przenosi je przed obrót i usuwa obrót. Usunięcie i ponowne wstawienie tego samego obiektu zmienia jego pozycję w kolekcji bez tworzenia kopii.

Sekwencja edycji zmienia kolejność z rotation–scale na scale–rotation, a następnie pozostawia tylko skalowanie. Indeksy odnoszą się do bieżącej kolekcji, więc usunięcie wykorzystuje nowy indeks obrotu po przestawieniu. Ostateczne wyliczenie potwierdza, które zachowanie zostanie zapisane.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wyjściem jest `ScaleEffect`: pozostaje wyłącznie skalowanie. Sam porządek w kolekcji nie ustawia zachowań jedno po drugim. Czyść kolekcję tylko wtedy, gdy zamierzasz zastąpić wszystkie jej operacje.

## **Konfiguracja synchronizacji zachowań**

[IBehavior.getTiming](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehavior/#getTiming--) udostępnia [ITiming](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/), niezależnie od [IEffect.getTiming](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ieffect/#getTiming--). Synchronizacja efektu określa harmonogram otaczającego efektu; synchronizacja zachowania opisuje operację wewnątrz niego.

### **Ustawienie czasu trwania, opóźnienia, powtórzeń i przyspieszenia**

Otwórz `rotation.pptx` i ustaw czas trwania ([getDuration](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getDuration--)) oraz opóźnienie wyzwalania ([getTriggerDelayTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) w sekundach, a następnie skonfiguruj liczbę powtórzeń przez [setRepeatCount](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getAccelerate--) i [getDecelerate](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getDecelerate--) to ułamki czasu trwania; ich suma nie powinna przekraczać 1.

Plik wejściowy to ten utworzony w przykładzie obrotu, w którym pierwsze zachowanie jest obrotem. Ten przykład zmienia wyłącznie synchronizację tego zachowania; jego kąt 90 stopni pozostaje niezmieniony. Rozdzielenie kąta i synchronizacji ułatwia dostosowanie tempa bez przebudowy animacji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zachowanie używa dwusekundowego czasu trwania, półsekundowego opóźnienia i trzykrotnego powtórzenia. Pierwsze i ostatnie 20 % czasu trwania jest przeznaczone na przyspieszenie i zwolnienie.

Inne polityki powtórzeń obejmują [getRepeatDuration](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), oraz [getRepeatUntilNextClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--); wybierz jedną, zamiast włączać je wszystkie jednocześnie. [getAutoReverse](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getAutoReverse--) odtwarza animację wstecz po przejściu w przód. Przyspieszenie i zwolnienie dotyczą ciągłych zmian, nie dyskretnych przypisań ani poleceń.

## **Budowanie ścieżki ruchu**

Użyj [createMotionEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) aby utworzyć ruch. Jego [getFrom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotioneffect/#getTo--), i [getBy](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotioneffect/#getBy--) opisują współrzędne lub offsety w procentach. Dla edytowalnej trasy utwórz [MotionPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/motionpath/) i przypisz ją przy pomocy [IMotionEffect.setPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotionpath/) przechowuje polecenia ścieżki.

[MotionCommandPathType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/motioncommandpathtype/) wybiera operację:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Ustaw początkową pozycję. |
| LineTo | One | Przemieszcz się po prostej linii do jej końcowego punktu. |
| CurveTo | Three | Podążaj za krzywą sześcienną określoną przez dwa punkty kontrolne i punkt końcowy. |
| CloseLoop | None | Powróć do pozycji początkowej. |
| End | None | Zakończ ścieżkę. |

[MotionPathPointsType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/motionpathpointstype/) opisuje charakterystykę edycji punktów, taką jak punkt narożny czy gładki. Nie zastępuje typu polecenia. Użyj typu punktu krzywej dla przykładu krzywej poniżej oraz typu punktu narożnego dla odcinków prostych.

Współrzędne ścieżki są normalizowane do wymiarów slajdu: przesunięcie X o 0,25 oznacza jedną czwartą szerokości slajdu, a nie 0,25 punktu. Pozytywne Y rośnie w dół. Polecenia bezwzględne określają pozycje w układzie współrzędnych ścieżki; polecenia względne określają offsety od bieżącej pozycji. To jest oddzielne od [getOrigin](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotioneffect/#getOrigin--), które wybiera ramkę odniesienia ścieżki, oraz [getPathEditMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--), które kontroluje, jak ścieżka przemieszcza się przy przemieszczaniu kształtu.

### **Tworzenie prostej ścieżki**

Utwórz zachowanie ruchu z punktem początkowym, jednym odcinkiem prostym i poleceniem zakończenia. [IMotionPath.add](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) przyjmuje typ polecenia, jego punkty, typ punktu oraz flagę współrzędnych względnych.

Polecenie początkowe ustala (0, 0), a linia kończy się w (0.25, 0), dając trasę przesunięcia poziomego o jedną czwartą szerokości slajdu. Polecenie końcowe nie ma punktów współrzędnych. Po przypisaniu ścieżki, dodanie zachowania ruchu do efektu łączy tę trasę z prostokątem.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` zawiera jedno zachowanie ruchu z trzema poleceniami ścieżki. Poniższe przykłady edycji plików używają tej znanej struktury.

### **Porównanie współrzędnych bezwzględnych i względnych**

Te dwa obiekty ścieżki opisują tę samą trasę. Polecenie bezwzględne kończy się w (0.3, 0.1); polecenie względne dodaje (0.1, 0.1) do bieżącej pozycji, czyli (0.2, 0).

Obie ścieżki zaczynają się w tej samej pozycji. Dla linii względnej dodaj jej offsety X i Y do bieżącej pozycji, aby uzyskać punkt końcowy; dla linii bezwzględnej odczytaj punkt końcowy bezpośrednio. Zmiana flagi bez konwersji współrzędnych opisze inną trasę.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Przypisz dowolną z tych ścieżek do zachowania ruchu, aby użyć jej w prezentacji. Ostatni argument Boolean wybiera współrzędne względne dla tego polecenia.

### **Zastąpienie linii krzywą**

Otwórz `motion.pptx` i zamień jej polecenie linii na krzywą sześcienną. Najpierw podaj dwa punkty kontrolne, a na końcu punkt docelowy.

Pozycja początkowa jest określona przez poprzednie polecenie. Pierwsze dwa punkty kształtują krzywą, trzeci jest jej docelowym punktem; nie są to trzy kolejne cele. Aktualizacja typu polecenia, typu edycji punktów i tablicy punktów razem utrzymuje segment spójny z nową geometrią.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ścieżka w `curve.pptx` nadal ma trzy polecenia; jej środkowe polecenie teraz definiuje krzywą.

## **Odczyt i edycja zapisanej ścieżki**

Każdy [IMotionCmdPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotioncmdpath/) udostępnia [getPoints](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), oraz [isRelative](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--). Poniższe przykłady używają znanej trzy‑poleceniowej ścieżki w `motion.pptx`. Dla dowolnego wejścia znajdź docelowy efekt i sprawdź typy poleceń oraz liczbę punktów przed edycją przez indeks.

### **Odczyt poleceń i współrzędnych**

Odczytaj ścieżkę bez jej modyfikacji. Polecenia końcowe i zamykające nie wymagają punktów, więc należy obsłużyć możliwość null w tablicy punktów.

Wyjście paruje każdy numeryczny typ polecenia z flagą współrzędnych względnych przed wypisaniem jego punktów. To pozwala odróżnić punkt końcowy od offsetu przed zmianą ścieżki. Krzywa wypisze trzy punkty, natomiast linia prosta w tym pliku wypisze tylko jeden.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Wykaz zawiera punkt początkowy, bezwzględną linię kończącą się w (0.25, 0) oraz polecenie końcowe.

### **Zmiana punktu końcowego**

Otwórz `motion.pptx` i zamień tablicę punktów linii, aby przenieść jej punkt końcowy.

W pliku wejściowym indeks 0 to polecenie początkowe, a indeks 1 to linia. Zastąpienie jednego punktu linii zmienia jej docelową pozycję bez zmiany typu polecenia, synchronizacji ani pozycji w kolekcji. Ponieważ polecenie używa współrzędnych bezwzględnych, nowa para określa pozycję, a nie dodatkowy offset.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Linia w `motion-endpoint.pptx` kończy się w (0.4, 0.1); oryginalny plik pozostaje niezmieniony.

### **Zastąpienie segmentu**

Użyj [insert](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) oraz [removeAt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) aby zamienić linię w `motion.pptx`. Wstawienie przesuwa starą linię na indeks 2.

To pokazuje zamianę obiektu polecenia, a nie edycję jego istniejących współrzędnych. Po wstawieniu kolekcja tymczasowo zawiera polecenie początkowe, nową linię, starą linię i polecenie końcowe. Usunięcie indeksu 2 usuwa starą linię, pozostawiając nową trasę.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zapisana ścieżka wciąż ma trzy polecenia, przy czym nowa linia kończy się w (0.2, 0.1), a polecenie końcowe pozostaje ostatnie.

## **Modyfikacja i weryfikacja istniejącego zachowania**

Gdy indeks zachowania jest nieznany, wybierz je po typie. Ten przykład otwiera `rotation.pptx`, znajduje jego [IRotationEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/irotationeffect/), zmienia kąt i sprawdza zapisaną wartość po ponownym otwarciu.

Sprawdzenie typu pozwala pętli pominąć zachowania, które nie są obrotami. Drugi odczyt wczytuje zapisany plik do osobnego obiektu prezentacji, więc porównanie sprawdza utrwalone dane, a nie wartość wciąż trzymaną w pamięci. Przykład nadal zakłada, że znany efekt znajduje się jako pierwszy w głównej sekwencji; wybór zachowania po typie nie znajduje prawidłowego efektu w dowolnej prezentacji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Wynik to `Rotation preserved: true`. Zastosuj ten sam schemat sprawdzania typu do innych zachowań. Dla pełnej weryfikacji zachowania porównaj docelowy kształt, efekt, typy i kolejność zachowań, synchronizację oraz polecenia ścieżki. Użyj tolerancji liczbowej dla wartości zmiennoprzecinkowych. Dla prezentacji o nieznanym układzie animacji zobacz [Read Shape Animations](/slides/pl/androidjava/shape-animation/#read-shape-animations) w celu przeglądu głównych i interaktywnych sekwencji.

## **Kolejność zachowań, presety i odtwarzanie**

Kolejność w [IBehaviorCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehaviorcollection/) to przechowywana kolejność operacji efektu. To nie jest lista odtwarzania, w której każde zachowanie automatycznie czeka na poprzednie. Synchronizacja i otaczający efekt określają harmonogram. Zachowania mogą się nakładać, a operacje na tej samej właściwości mogą wchodzić w interakcję poprzez [getAdditive](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehavior/#getAdditive--) i [getAccumulate](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibehavior/#getAccumulate--). Nie używaj samego przestawiania kolekcji do planowania „przesuń, potem obróć”; użyj wyraźnej synchronizacji lub oddzielnych efektów, jak opisano w [Shape Animation](/slides/pl/androidjava/shape-animation/).

[IEffect.getType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ieffect/#getType--) i [IEffect.getSubtype](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ieffect/#getSubtype--) opisują preset efektu. Nie stanowią pełnego opisu edytowanego drzewa zachowań. Wybierz preset i podtyp przed dostosowywaniem zachowań: zmiana presetu może odbudować kolekcję i usunąć twoje niestandardowe operacje. Na przykład zmiana spersonalizowanego efektu Spin na Fade może zastąpić jego zachowanie obrotu zachowaniami set i filter. Sprawdź kolekcję ponownie po zmianie presetu lub podtypu. Czyszczenie zachowań presetu może również usunąć operacje widoczności lub inicjalizacji, które preset wymaga. Przykłady celowo używają widocznych kształtów i zamieniają zachowania; nie odtwarzają całej implementacji każdego presetu.

## **Zgodność formatów**

Zachowane drzewo zachowań nie gwarantuje identycznego odtwarzania we wszystkich przeglądarkach czy silnikach eksportu. Sprawdź osobno zapisane dane i wyrenderowany rezultat.

| Format lub wyjście | Co weryfikować |
| --- | --- |
| PPTX | Używaj jako głównego formatu w tych przykładach. Otwórz ponownie, aby zweryfikować edytowalne drzewo zachowań, a następnie sprawdź odtwarzanie w docelowej wersji PowerPoint. |
| PPT | Starsza binarna reprezentacja może różnić się od PPTX. Przeprowadź osobny cykl zapisu‑odczytu i odtwarzania; nie wnioskuj o wsparciu każdego niestandardowego połączenia na podstawie udanego wyjścia PPTX. |
| PDF, PNG, JPEG i inne statyczne obrazy slajdów | Zawierają statyczną reprezentację slajdu, nie odtwarzalną oś czasu zachowań ani gwarantowaną ostateczną klatkę animacji. |
| [HTML5](/slides/pl/androidjava/export-to-html5/) | Może odtwarzać obsługiwane animacje, gdy w opcjach eksportu włączono animację kształtów. Testuj niestandardowe kombinacje w przeglądarce. |
| [Animated GIF](/slides/pl/androidjava/convert-powerpoint-to-animated-gif/) | Zapisuje wyrenderowane klatki, nie edytowalne zachowania ani interakcje wyzwalane kliknięciem. Sprawdź rzeczywisty wyrenderowany ruch. |
| [Video](/slides/pl/androidjava/convert-powerpoint-to-video/) | Renderuje klatki animacji i koduje je jako wideo. Wsparcie jest ograniczone do [obsługiwanych animacji i efektów](/slides/pl/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) renderera; polecenia i zdarzenia interaktywne nie stają się edytowalną osią czasu. |

## **FAQ**

**Dlaczego mój efekt zawiera zachowania, zanim je dodam?**

Tworzenie gotowego efektu może utworzyć jego podstawowe operacje. Przejrzyj je, zanim zdecydujesz, czy rozbudować preset, czy zastąpić jego zachowania.

**Czy przeniesienie zachowania na początek sprawia, że odtwarza się jako pierwsze?**

Niekoniecznie. Kolejność w kolekcji nie zastępuje synchronizacji. Sprawdź opóźnienia, czasy trwania i interakcje między operacjami na tej samej właściwości.

**Dlaczego polecenie końcowe nie ma punktów?**

Oznacza koniec ścieżki i nie wymaga współrzędnych. Podczas inspekcji ścieżki odczytanej z pliku sprawdzaj możliwość null w tablicy punktów.

**Czy udany cykl zapisu‑odczytu wystarczy do potwierdzenia odtwarzania?**

Nie. Otworzenie ponownie potwierdza zachowanie sprawdzonych właściwości. Przetestuj odtwarzacz pokazu slajdów lub eksport animacji osobno, aby potwierdzić jego zachowanie wizualne.