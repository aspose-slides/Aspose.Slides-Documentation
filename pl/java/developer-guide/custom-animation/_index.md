---
title: Tworzenie i modyfikowanie niestandardowych zachowań animacji w Javie
linktitle: Niestandardowa animacja
type: docs
weight: 151
url: /pl/java/custom-animation/
keywords:
- niestandardowa animacja
- zachowanie animacji
- ścieżka ruchu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Twórz, przeglądaj i modyfikuj niestandardowe zachowania animacji oraz edytowalne ścieżki ruchu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

Niestandardowe zachowania animacji pozwalają kontrolować pojedyncze operacje w ramach efektu animacji, takich jak zmiana koloru, obrót kształtu lub podążanie za edytowalną ścieżką ruchu. Ten przewodnik pokazuje, jak tworzyć i łączyć zachowania, konfigurować ich timing, przeglądać i modyfikować istniejące animacje oraz weryfikować, że ich właściwości przetrwają zapis i ponowne otwarcie prezentacji.

Dla predefiniowanych efektów i wyzwalaczy kliknięcia zobacz [Animacja kształtów](/slides/pl/java/shape-animation/).

## **Zrozumienie modelu animacji**

Animacja jest uporządkowana jako **Timeline → Sequence → Effect → Behaviors**:

- Metoda [getTimeline](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseslide/#getTimeline--) zwraca oś czasu slajdu, która zawiera główną sekwencję i sekwencje interaktywne.
- [ISequence](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isequence/) zawiera efekty, potencjalnie skierowane do różnych kształtów.
- [IEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ieffect/) identyfikuje docelowy kształt, preset, podtyp i timing efektu.
- Kolekcja zwracana przez [IEffect.getBehaviors](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ieffect/#getBehaviors--) zawiera operacje implementujące efekt: zmianę koloru, przesuwanie, obrót, ustawianie właściwości itp.

## **Tworzenie pojedynczych zachowań**

Wywołaj [ISequence.addEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) aby utworzyć efekt i uzyskać dostęp do kolekcji [getBehaviors](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ieffect/#getBehaviors--). Preset może automatycznie wypełnić tę kolekcję. Zachowaj jego operacje przy rozszerzaniu presetu lub użyj [clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorcollection/#clear--) przy celowym ich zastąpieniu.

[IBehaviorFactory](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorfactory/) tworzy osiem typów zachowań zilustrowanych poniżej. Ruch jest opisany w [Build a Motion Path](#build-a-motion-path). Każdy fragment kodu zawiera importy; umieść jego instrukcje wykonywalne wewnątrz metody. Przykłady późniejszej edycji podają, którego pliku wyjściowego używają.

### **Rotacja**

Użyj [createRotationEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) aby utworzyć rotację. [getBy](https://reference.aspose.com/slides/pl/java/com.aspose.slides/irotationeffect/#getBy--) określa względny kąt w stopniach; [getFrom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/irotationeffect/#getFrom--) i [getTo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/irotationeffect/#getTo--) określają punkty końcowe.

Przykład zaczyna się od efektu Spin, zastępuje jego operacje presetowe jedną rotacją i nadaje tej operacji dwusekundowy czas trwania. Względny kąt 90 stopni oznacza ćwierć obrotu od początkowej orientacji kształtu, więc nie jest potrzebny jawny kąt początkowy.

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

`rotation.pptx` zawiera jeden kształt i jedną rotację. Przykłady kolekcji, timingu i edycji rotacji poniżej używają tego pliku.

### **Skala**

Użyj [createScaleEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) z procentami X/Y: [getFrom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iscaleeffect/#getFrom--) i [getTo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iscaleeffect/#getTo--) opisują początkowy i końcowy rozmiar, a [getBy](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iscaleeffect/#getBy--) opisuje względną zmianę. Tutaj 100 oznacza rozmiar oryginalny.

Przykład zwiększa oba wymiary z 100 % do 125 % w ciągu dwóch sekund. Użycie jednakowych wartości poziomych i pionowych zachowuje proporcje kształtu; inne wartości rozciągną jedną oś bardziej niż drugą.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kolor**

Użyj [createColorEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) aby zmienić wypełnienie z niebieskiego na pomarańczowy. [getFrom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icoloreffect/#getFrom--) i [getTo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icoloreffect/#getTo--) są kolorami; [getBy](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icoloreffect/#getBy--) to offset koloru. [IBehavior.getProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehavior/#getProperties--) identyfikuje animowany atrybut.

Wypełnienie kształtu jest początkowo niebieskie, co odpowiada początkowemu kolorowi animacji. Wybranie atrybutu fill‑color mówi zachowaniu, którą część kształtu zmienić; same kolory końcowe nie określają tego atrybutu. Zapisany efekt opisuje dwusekundowe przejście do pomarańczowego.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtr**

Użyj [createFilterEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) aby wybrać wycieranie. [getType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifiltereffect/#getSubtype--), i [getReveal](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifiltereffect/#getReveal--) określają filtr, kierunek i to, czy odsłonić czy ukryć kształt.

Przykład konfiguruje dwusekundowe wycieranie odsłaniające kształt przy użyciu podtypu z kierunkiem w prawo. Ustawienia filtru należą do zachowania wewnątrz efektu, więc są konfigurowane po usunięciu oryginalnych operacji presetu.

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

Użyj [createPropertyEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) aby animować przezroczystość. [getFrom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipropertyeffect/#getTo--), i [getBy](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipropertyeffect/#getBy--) są ciągami interpretowanymi przy pomocy [getValueType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipropertyeffect/#getValueType--) i [getCalcMode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipropertyeffect/#getCalcMode--). Wybierz punkty końcowe lub względny offset zamiast ustawiać wszystkie trzy jednocześnie.

Tutaj wybranym atrybutem jest opacity, a ciągi liczbowe opisują zmianę z 25 % do pełnej nieprzezroczystości. Interpolacja liniowa opisuje płynną zmianę między tymi wartościami. Przy adaptacji przykładu do innego atrybutu wybierz typ wartości i odpowiednie wartości końcowe.

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

Użyj [createSetEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) aby przypisać widoczność przez [getTo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iseteffect/#getTo--). Zachowanie typu set nie interpoluje między punktami końcowymi.

Przykład wybiera atrybut visibility i przypisuje ciąg `visible` w czasie wykonywania zachowania. Prostokąt jest już widoczny w tej minimalnej prezentacji, więc przypisanie może nie wywołać wyraźnej zmiany wizualnej samo w sobie. Taka operacja jest przydatna jako część większego efektu, który także kontroluje, kiedy kształt ma być ukryty lub widoczny.

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

Użyj [createCommandEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) i skonfiguruj [getType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icommandeffect/#getCommandString--), oraz [getShapeTarget](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icommandeffect/#getShapeTarget--). Umieść nagranie WAV o nazwie `sample.wav` w katalogu roboczym. Ten przykład osadza je przy pomocy [addAudioFrameEmbedded](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) i dołącza polecenie odtwarzania do ramki audio.

Rama audio jest zarówno celem efektu, jak i celem polecenia. Łączy to żądanie odtworzenia z osadzonym nagraniem; sam ciąg polecenia nie określa, który obiekt multimedialny kontrolować. Efekt jest skonfigurowany, aby rozpocząć się po kliknięciu podczas pokazu slajdów.

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

Zapis zapisuje polecenie w `command.pptx`; nie odtwarza nagrania. Odtwarzanie wymaga odtwarzacza pokazu slajdów obsługującego polecenie i jego docelowy element multimedialny.

## **Zarządzanie kolekcją zachowań**

[IBehaviorCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorcollection/) obsługuje [add](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), i [removeAt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Przykład otwiera `rotation.pptx`, dodaje skalowanie, przenosi je przed rotację i usuwa rotację. Usunięcie i ponowne wstawienie tego samego obiektu zmienia jego zapisane położenie bez tworzenia kopii.

Sekwencja edycji zmienia kolekcję z rotation–scale na scale–rotation, a następnie tylko na scale. Indeksy odnoszą się do bieżącej kolekcji, więc usunięcie używa nowego indeksu rotacji po przerejestrowaniu. Końcowe wyliczenie potwierdza, które zachowanie zostanie zapisane.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
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

Wynik to `ScaleEffect`: pozostaje tylko skalowanie. Kolejność w kolekcji nie planuje automatycznie zachowań jedno po drugim. Czyść kolekcję tylko przy pełnym zastępowaniu jej operacji.

## **Konfigurowanie czasu zachowań**

[IBehavior.getTiming](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehavior/#getTiming--) udostępnia [ITiming](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiming/), niezależnie od [IEffect.getTiming](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ieffect/#getTiming--). Timing efektu planuje otaczający efekt; timing zachowania opisuje operację wewnątrz niego.

### **Ustawienie czasu trwania, opóźnienia, powtórzeń i przyspieszenia**

Otwórz `rotation.pptx` i ustaw czas trwania ([getDuration](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiming/#getDuration--)) oraz opóźnienie wyzwalacza ([getTriggerDelayTime](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) w sekundach, a następnie skonfiguruj liczbę powtórzeń przez [setRepeatCount](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiming/#getAccelerate--) i [getDecelerate](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiming/#getDecelerate--) to ułamki czasu trwania; ich suma nie powinna przekraczać 1.

Plik wejściowy to ten utworzony w przykładzie rotacji, gdzie pierwsze zachowanie jest znane jako rotacja. Przykład zmienia wyłącznie timing tego zachowania; kąt 90 stopni pozostaje niezmieniony. Rozdzielenie kąta i timingu ułatwia regulację tempa bez przebudowy animacji.

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

Zachowanie używa dwusekundowego czasu trwania, półsekundowego opóźnienia i trzykrotnego powtórzenia. Pierwsze i ostatnie 20 % jego czasu trwania służą przyspieszeniu i zwolnieniu.

Inne polityki powtórzeń obejmują [getRepeatDuration](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), i [getRepeatUntilNextClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--); wybierz jedną politykę zamiast włączania ich wszystkich jednocześnie. [getAutoReverse](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiming/#getAutoReverse--) odtwarza animację wstecz po przejściu do przodu. Przyspieszenie i zwolnienie mają zastosowanie do ciągłych zmian, nie do dyskretnych przypisań ani poleceń.

## **Tworzenie ścieżki ruchu**

Użyj [createMotionEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) aby utworzyć ruch. Jego [getFrom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotioneffect/#getTo--), i [getBy](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotioneffect/#getBy--) opisują współrzędne procentowe lub offsety. Aby uzyskać edytowalną trasę, utwórz [MotionPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/motionpath/) i przypisz ją przy pomocy [IMotionEffect.setPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotionpath/) przechowuje polecenia ścieżki.

[MotionCommandPathType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/motioncommandpathtype/) wybiera operację:

| Command | Points | Znaczenie |
| --- | --- | --- |
| MoveTo | One | Ustaw pozycję początkową. |
| LineTo | One | Przesuń wzdłuż odcinka prostego do jego punktu końcowego. |
| CurveTo | Three | Podążaj za krzywą sześcienną określoną dwoma punktami kontrolnymi i punktem końcowym. |
| CloseLoop | None | Powróć do pozycji początkowej. |
| End | None | Zakończ ścieżkę. |

[MotionPathPointsType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/motionpathpointstype/) opisuje charakterystyki edycji punktów, takie jak corner lub smooth. Nie zastępuje typu polecenia. Użyj typu punktu curve dla przykładu krzywej poniżej oraz typu corner dla odcinków prostych.

Współrzędne ścieżki są znormalizowane względem wymiarów slajdu: przemieszczenie X = 0,25 oznacza jedną czwartą szerokości slajdu, a nie 0,25 pt. Dodatni Y rośnie w dół. Polecenia bezwzględne określają pozycje w układzie współrzędnych ścieżki; polecenia względne określają offsety od bieżącej pozycji. To jest oddzielne od [getOrigin](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotioneffect/#getOrigin--), który wybiera ramę odniesienia ścieżki, oraz od [getPathEditMode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotioneffect/#getPathEditMode--), który kontroluje, jak ścieżka przemieszcza się wraz z kształtem.

### **Utworzenie prostej ścieżki**

Utwórz zachowanie ruchu z punktem startowym, jednym odcinkiem prostym i poleceniem końcowym. [IMotionPath.add](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) przyjmuje typ polecenia, jego punkty, typ punktu i flagę współrzędnych względnych.

Polecenie startowe ustawia (0, 0), a linia kończy się w (0,25, 0), dając trasie poziome przemieszczenie równe jednej czwartej szerokości slajdu. Polecenie końcowe nie ma punktów współrzędnych. Po przypisaniu ścieżki, dodanie zachowania ruchu do efektu łączy tę trasę z prostokątem.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

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
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` zawiera jedno zachowanie ruchu z trzema poleceniami ścieżki. Poniższe przykłady edycji plików używają tej znanej struktury.

### **Porównanie współrzędnych bezwzględnych i względnych**

Te dwa obiekty ścieżki opisują tę samą trasę. Polecenie bezwzględne kończy się w (0,3, 0,1); polecenie względne dodaje (0,1, 0,1) do bieżącej pozycji, czyli (0,2, 0).

Obie ścieżki zaczynają w tym samym miejscu. Dla linii względnej dodaj jej offsety X i Y do bieżącej pozycji, aby otrzymać punkt końcowy; dla linii bezwzględnej odczytaj punkt końcowy bezpośrednio. Przełączenie flagi bez konwersji współrzędnych opisałoby inną trasę.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Przypisz jedną z tych ścieżek do zachowania ruchu, aby użyć jej w prezentacji. Ostatni argument Boolean wybiera współrzędne względne dla tego polecenia.

### **Zamiana linii na krzywą**

Otwórz `motion.pptx` i zamień jej polecenie linii na krzywą sześcienną. Najpierw podaj dwa punkty kontrolne, a potem punkt końcowy.

Pozycja startowa jest dostarczona przez poprzednie polecenie. Pierwsze dwa punkty kształtują krzywą, trzeci jest jej docelowym punktem; nie są to trzy kolejne destynacje. Jednoczesna aktualizacja typu polecenia, typu edycji punktów i tablicy punktów utrzymuje segment spójny z nową geometrią.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ścieżka w `curve.pptx` nadal ma trzy polecenia; jej środkowe polecenie teraz definiuje krzywą.

## **Inspekcja i edycja zapisanej ścieżki**

Każdy [IMotionCmdPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotioncmdpath/) udostępnia [getPoints](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotioncmdpath/#getPointsType--), i [isRelative](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotioncmdpath/#isRelative--). Poniższe przykłady używają znanej trójpoleceniowej ścieżki w `motion.pptx`. Dla dowolnego wejścia zlokalizuj zamierzony efekt i sprawdź typy poleceń oraz liczbę punktów przed edycją według indeksu.

### **Odczyt poleceń i współrzędnych**

Odczytaj ścieżkę bez jej modyfikacji. Polecenia End i CloseLoop nie potrzebują punktów, więc obsłuż możliwość null w tablicy punktów.

Wynik paruje każdy numeryczny typ polecenia z flagą współrzędnych względnych, po czym wypisuje jego punkty. Dzięki temu możesz odróżnić punkt końcowy od offsetu przed modyfikacją ścieżki. Krzywa wypisze trzy punkty, natomiast prosta linia w tym pliku wypisuje tylko jeden.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Lista zawiera punkt startowy, bezwzględną linię kończącą się w (0,25, 0) oraz polecenie End.

### **Zmiana punktu końcowego**

Otwórz `motion.pptx` i zamień tablicę punktów linii, aby przesunąć jej punkt końcowy.

W pliku wejściowym indeks 0 to polecenie startowe, a indeks 1 to linia. Zastąpienie jedynego punktu linii zmienia jej destynację bez zmiany typu polecenia, timingu ani pozycji w kolekcji. Ponieważ polecenie używa współrzędnych bezwzględnych, nowa para określa pozycję, a nie dodatkowy offset.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Linia w `motion-endpoint.pptx` kończy się w (0,4, 0,1); oryginalny plik pozostaje niezmieniony.

### **Zamiana segmentu**

Użyj [insert](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) i [removeAt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imotionpath/#removeAt-int-) aby zamienić linię w `motion.pptx`. Wstawienie przesuwa starą linię na indeks 2.

To pokazuje zamianę obiektu polecenia zamiast edycji istniejących współrzędnych. Po wstawieniu kolekcja tymczasowo zawiera polecenie startowe, nową linię, starą linię i polecenie End. Usunięcie indeksu 2 usuwa starą linię, pozostawiając nową trasę.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zapisana ścieżka nadal ma trzy polecenia, nowa linia kończy się w (0,2, 0,1), a polecenie End jest ostatnie.

## **Modyfikacja i weryfikacja istniejącego zachowania**

Gdy indeks zachowania jest nieznany, wybierz je według typu. Ten przykład otwiera `rotation.pptx`, znajduje jego [IRotationEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/irotationeffect/), zmienia kąt i sprawdza zapisany wartość po ponownym otwarciu.

Sprawdzenie typu pozwala pętli pominąć zachowania, które nie są rotacjami. Drugi odczyt wczytuje zapisany plik do osobnego obiektu prezentacji, więc porównanie dotyczy danych utrwalonych, a nie wartości wciąż trzymanej w pamięci. Przykład wciąż zakłada, że znany efekt jest pierwszy w głównej sekwencji; wybór zachowania według typu nie lokalizuje właściwego efektu w dowolnej prezentacji.

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

Wynik to `Rotation preserved: true`. Zastosuj ten sam wzorzec sprawdzania typów do innych zachowań. Dla pełnej weryfikacji zachowania porównaj docelowy kształt, efekt, typy i kolejność zachowań, timing oraz polecenia ścieżki. Użyj tolerancji numerycznej dla wartości zmiennoprzecinkowych. Dla prezentacji o nieznanej strukturze animacji zobacz [Odczyt animacji kształtów](/slides/pl/java/shape-animation/#read-shape-animations) w celu przeglądania głównych i interaktywnych sekwencji.

## **Kolejność zachowań, predefiniowane ustawienia i odtwarzanie**

Kolejność w [IBehaviorCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehaviorcollection/) to zapisany porządek operacji efektu. Nie jest to lista odtwarzania, w której każde zachowanie automatycznie czeka na poprzednie. Timing i otaczający efekt decydują o planowaniu. Zachowania mogą się nakładać, a operacje na tej samej właściwości mogą oddziaływać poprzez [getAdditive](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehavior/#getAdditive--) i [getAccumulate](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibehavior/#getAccumulate--). Nie używaj samodzielnego przestawiania kolekcji, aby zaplanować „przesuń, potem obróć”; użyj wyraźnego timingu lub oddzielnych efektów, jak opisano w [Animacja kształtów](/slides/pl/java/shape-animation/).

Typ efektu [getType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ieffect/#getType--) i [getSubtype](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ieffect/#getSubtype--) opisują jego preset. Nie stanowią pełnego opisu edytowanego drzewa zachowań. Wybierz preset i podtyp przed dostosowaniem zachowań: zmiana presetu może odbudować kolekcję i usunąć Twoje własne operacje. Na przykład, zmiana spersonalizowanego efektu Spin na Fade może zastąpić jego rotację zachowaniami set i filter. Po zmianie presetu lub podtypu ponownie sprawdź kolekcję. Czyszczenie zachowań presetu może także usunąć operacje widoczności lub inicjalizacji, które preset wymaga. Przykłady celowo używają widocznych kształtów i zastępują zachowania; nie rekonstruują pełnej implementacji każdego presetu.

## **Kompatybilność formatów**

Zachowane drzewo zachowań nie gwarantuje identycznego odtwarzania w każdym podglądarce ani silniku eksportu. Sprawdź osobno zapisane dane i wyrenderowany wynik.

| Format lub wyjście | Co należy zweryfikować |
| --- | --- |
| PPTX | Użyj jako głównego formatu dla tych przykładów. Otwórz ponownie, aby zweryfikować edytowalne drzewo zachowań, a następnie sprawdź odtwarzanie w docelowej wersji PowerPoint. |
| PPT | Starsza reprezentacja binarna może różnić się od PPTX. Przeprowadź osobny cykl zapis‑odtwórz i odtwórz; nie wyciągaj wniosków o obsłudze każdej kombinacji z udanego wyniku PPTX. |
| PDF, PNG, JPEG i inne statyczne obrazy slajdów | Zawierają statyczną reprezentację slajdu, nie odtwarzalną oś czasu zachowań ani gwarantowaną ostateczną klatkę animacji. |
| [HTML5](/slides/pl/java/export-to-html5/) | Może odtwarzać obsługiwane animacje, gdy animacja kształtu jest włączona w opcjach eksportu. Testuj własne kombinacje w przeglądarce. |
| [Animated GIF](/slides/pl/java/convert-powerpoint-to-animated-gif/) | Przechowuje wyrenderowane klatki, nie edytowalne zachowania ani interakcje wyzwalane kliknięciem. Sprawdź rzeczywisty ruch w renderze. |
| [Video](/slides/pl/java/convert-powerpoint-to-video/) | Renderuje klatki animacji i koduje je jako wideo. Wsparcie jest ograniczone do [obsługiwanych animacji i efektów](/slides/pl/java/convert-powerpoint-to-video/#supported-animations-and-effects) renderera; polecenia i zdarzenia interaktywne nie stają się edytowalną osią czasu. |

## **FAQ**

**Dlaczego mój efekt zawiera zachowania zanim dodam jakiekolwiek?**  
Tworzenie predefiniowanego efektu może utworzyć jego podstawowe operacje. Przejrzyj je przed podjęciem decyzji, czy rozszerzyć preset, czy zastąpić jego zachowania.

**Czy przeniesienie zachowania na początek sprawia, że odtwarza się najpierw?**  
Niekoniecznie. Kolejność w kolekcji nie zastępuje timingu. Sprawdź opóźnienia, czasy trwania i interakcje między operacjami na tej samej właściwości.

**Dlaczego polecenie End nie ma punktów?**  
Oznacza koniec ścieżki i nie wymaga współrzędnych. Przy analizie ścieżki odczytanej z pliku sprawdzaj, czy tablica punktów jest null.

**Czy udany „round‑trip” wystarczy, aby potwierdzić odtwarzanie?**  
Nie. Ponowne otwarcie potwierdza zachowanie sprawdzonych właściwości. Przetestuj odtwarzacz pokazu slajdów lub eksport animacji oddzielnie, aby potwierdzić zachowanie wizualne.