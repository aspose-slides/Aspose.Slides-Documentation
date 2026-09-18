---
title: Tworzenie i modyfikacja niestandardowych zachowań animacji w .NET
linktitle: Animacja niestandardowa
type: docs
weight: 151
url: /pl/net/custom-animation/
keywords:
- animacja niestandardowa
- zachowanie animacji
- ścieżka ruchu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Twórz, przeglądaj i modyfikuj niestandardowe zachowania animacji oraz edytowalne ścieżki ruchu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Niestandardowe zachowania animacji pozwalają kontrolować poszczególne operacje w ramach efektu animacji, takie jak zmiana koloru, obracanie kształtu lub podążanie za edytowalną ścieżką ruchu. Ten przewodnik pokazuje, jak tworzyć i łączyć zachowania, konfigurować ich czasowanie, przeglądać i modyfikować istniejące animacje oraz sprawdzić, czy ich właściwości przetrwają zapis i ponowne otwarcie prezentacji.

Aby uzyskać informacje o predefiniowanych efektach i wyzwalaczach kliknięcia, zobacz [Animacja Kształtów](/slides/pl/net/shape-animation/).

## **Zrozumienie modelu animacji**

Animacja jest zorganizowana jako **Oś czasu → Sekwencja → Efekt → Zachowania**:

- Oś czasu slajdu [Timeline](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/timeline/) zawiera główną sekwencję oraz sekwencje interaktywne.
- [ISequence](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/) zawiera efekty, potencjalnie skierowane do różnych kształtów.
- [IEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/) określa docelowy kształt, preset, podtyp oraz czas trwania efektu.
- [IEffect.Behaviors](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/behaviors/) zawiera operacje realizujące efekt: zmianę koloru, przemieszczenie, obrót, ustawienie właściwości i tak dalej.

## **Utwórz poszczególne zachowania**

Wywołaj [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/) aby utworzyć efekt i uzyskać dostęp do jego kolekcji [Behaviors](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/behaviors/). Preset może automatycznie wypełnić tę kolekcję. Zachowaj jego operacje przy rozszerzaniu presetu lub użyj [Clear](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorcollection/clear/) przy świadomym ich zamienianiu.

[IBehaviorFactory](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorfactory/) tworzy osiem typów zachowań zilustrowanych poniżej. Ruch jest omówiony w [Build a Motion Path](#build-a-motion-path). Każdy przykład tworzenia to pełny program; późniejsze przykłady edycji wskazują, którego pliku wyjściowego używają.

### **Obrót**

Użyj [CreateRotationEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) aby utworzyć obrót. [By](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/irotationeffect/by/) określa kąt względny w stopniach; [From](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/irotationeffect/from/) i [To](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/irotationeffect/to/) określają punkty końcowe.

Przykład zaczyna się od efektu Spin, zamienia jego operacje presetowe na jedno zachowanie obrotu i nadaje temu działaniu dwusekundowy czas trwania. Kąt względny 90 stopni oznacza ćwierć obrotu od początkowej orientacji kształtu, więc nie jest potrzebny jawny kąt początkowy.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` zawiera jeden kształt i jedno zachowanie obrotu. Kolekcja, czasowanie i przykłady edycji obrotu poniżej używają tego pliku.

### **Skalowanie**

Użyj [CreateScaleEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) z procentami X/Y: [From](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/iscaleeffect/from/) i [To](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/iscaleeffect/to/) opisują początkowy i końcowy rozmiar, natomiast [By](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/iscaleeffect/by/) opisuje zmianę względną. Tutaj 100 oznacza oryginalny rozmiar.

Przykład zwiększa oba wymiary z 100 % do 125 % w ciągu dwóch sekund. Użycie równych wartości poziomych i pionowych zachowuje proporcje kształtu; różne wartości rozciągałyby jedną osię bardziej niż drugą.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **Kolor**

Użyj [CreateColorEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) aby zmienić wypełnienie z niebieskiego na pomarańczowy. [From](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/icoloreffect/from/) i [To](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/icoloreffect/to/) są kolorami; [By](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/icoloreffect/by/) jest offsetem koloru. [IBehavior.Properties](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehavior/properties/) identyfikuje animowaną właściwość.

Wypełnienie kształtu jest początkowo ustawione na niebieskie, co odpowiada początkowemu kolorowi animacji. Wybranie atrybutu wypełnienia kolorystycznego informuje zachowanie, którą część kształtu zmienić; same kolory końcowe nie identyfikują tej właściwości. Zapisany efekt opisuje dwusekundową przejście do pomarańczowego.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **Filtr**

Użyj [CreateFilterEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) aby wybrać wycieranie. [Type](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ifiltereffect/subtype/), i [Reveal](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ifiltereffect/reveal/) określają filtr, kierunek oraz to, czy odkrywać czy ukrywać kształt.

Przykład konfiguruje dwusekundowe wycieranie, które odsłania kształt przy użyciu podtypu kierunku w prawo. Ustawienia filtru należą do zachowania wewnątrz efektu, więc są konfigurowane po usunięciu oryginalnych operacji presetu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **Właściwość**

Użyj [CreatePropertyEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) aby animować krycie (opacity). [From](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ipropertyeffect/to/), i [By](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ipropertyeffect/by/) są ciągami interpretowanymi przy użyciu [ValueType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ipropertyeffect/valuetype/) i [CalcMode](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ipropertyeffect/calcmode/). Wybierz punkty końcowe lub offset względny zamiast ustawiać wszystkie trzy bezkrytycznie.

Tutaj wybraną właściwością jest krycie, a ciągi liczbowe reprezentują zmianę z 25 % krycia do pełnego krycia. Interpolacja liniowa opisuje płynną zmianę między tymi wartościami. Przy adaptacji tego przykładu do innej właściwości wybierz typ wartości i wartości końcowe odpowiednie dla tej właściwości.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **Ustaw**

Użyj [CreateSetEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) aby przypisać widoczność przez [To](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/iseteffect/to/). Zachowanie typu set nie interpoluje między punktami końcowymi.

Przykład wybiera atrybut widoczności i przypisuje ciąg `visible` podczas uruchomienia zachowania. Prostokąt jest już widoczny w tej minimalnej prezentacji, więc przydział może nie wywołać wyraźnej zmiany wizualnej samodzielnie. Taka operacja jest przydatna jako część większego efektu, który kontroluje również moment ukrycia lub pokazania kształtu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **Polecenie**

Użyj [CreateCommandEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) i skonfiguruj [Type](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/icommandeffect/commandstring/), oraz [ShapeTarget](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/icommandeffect/shapetarget/). Umieść nagranie WAV o nazwie `sample.wav` w katalogu roboczym. Ten przykład osadza je za pomocą [AddAudioFrameEmbedded](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addaudioframeembedded/) i dołącza polecenie odtwarzania do ramki audio.

Ramka audio jest jednocześnie celem efektu i celem polecenia. Łączy to żądanie odtworzenia z osadzonym nagraniem; sam ciąg polecenia nie określa, jaki obiekt multimedialny ma być kontrolowany. Efekt jest skonfigurowany, aby rozpocząć się po kliknięciu podczas pokazu slajdów.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

Zapis przechowuje polecenie w `command.pptx`; nie odtwarza nagrania. Odtwarzanie wymaga odtwarzacza pokazu slajdów, który obsługuje polecenie i jego docelowy element multimedialny.

## **Zarządzanie kolekcją zachowań**

[IBehaviorCollection](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorcollection/) obsługuje [Add](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorcollection/remove/), i [RemoveAt](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorcollection/removeat/). Ten przykład otwiera `rotation.pptx`, dodaje skalowanie, przenosi je przed obrót i usuwa obrót. Usunięcie i ponowne wstawienie tego samego obiektu zmienia jego przechowywaną pozycję bez tworzenia kopii.

Sekwencja edycji zmienia kolekcję z rotation–scale na scale–rotation, a potem tylko na scale. Indeksy odnoszą się do bieżącej kolekcji, więc usunięcie używa nowego indeksu obrotu po przestawieniu. Końcowe wyliczenie potwierdza, które zachowanie zostanie zapisane.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

Wynik to `ScaleEffect`: pozostaje tylko skalowanie. Kolejność w kolekcji nie powoduje automatycznego sekwencyjnego odtwarzania zachowań. Czyść kolekcję tylko wtedy, gdy zamierzasz zastąpić wszystkie jej operacje.

## **Konfiguracja czasu zachowań**

[IBehavior.Timing](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehavior/timing/) udostępnia [ITiming](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/), niezależnie od [IEffect.Timing](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/timing/). Czasowanie efektu ustala harmonogram otaczającego efektu; czasowanie zachowania opisuje operację wewnątrz niego.

### **Ustaw czas trwania, opóźnienie, powtórzenia i przyspieszenie**

Otwórz `rotation.pptx` i ustaw [Duration](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/duration/) oraz [TriggerDelayTime](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/triggerdelaytime/) w sekundach, a następnie skonfiguruj [RepeatCount](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/accelerate/) i [Decelerate](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/decelerate/) to ułamki czasu trwania; ich suma nie może przekraczać 1.

Plik wejściowy to ten utworzony w przykładzie obrotu, gdzie pierwsze zachowanie jest znane jako obrót. Ten przykład zmienia tylko czasowanie tego zachowania; kąt 90 stopni pozostaje niezmieniony. Rozdzielenie kąta i czasu ułatwia regulację tempa bez potrzeby przebudowy animacji.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

Zachowanie używa dwusekundowego czasu trwania, półsekundowego opóźnienia i licznika powtórzeń równego 3. Pierwsze i ostatnie 20 % czasu trwania są przeznaczone na przyspieszenie i zwolnienie.

Inne polityki powtórzeń to [RepeatDuration](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilendslide/), oraz [RepeatUntilNextClick](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilnextclick/); wybierz jedną politykę zamiast włączania ich wszystkich jednocześnie. [AutoReverse](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/autoreverse/) odtwarza animację wstecz po przejściu do przodu. Przyspieszenie i zwolnienie mają zastosowanie do ciągłych zmian, nie do dyskretnych przypisań czy poleceń.

## **Budowanie ścieżki ruchu**

Użyj [CreateMotionEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) aby utworzyć ruch. Jego [From](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotioneffect/to/), i [By](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotioneffect/by/) opisują współrzędne lub offsety w procentach. Aby uzyskać edytowalną trasę, utwórz [MotionPath](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/motionpath/) i przypisz ją do [IMotionEffect.Path](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotioneffect/path/). [IMotionPath](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotionpath/) przechowuje komendy ścieżki.

[MotionCommandPathType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/motioncommandpathtype/) wybiera operację:

| Polecenie | Punkty | Znaczenie |
| --- | --- | --- |
| MoveTo | Jeden | Ustaw początkową pozycję. |
| LineTo | Jeden | Przemieść się wzdłuż prostego odcinka do jego końcowego punktu. |
| CurveTo | Trzy | Podążaj po krzywej sześciennej zdefiniowanej przez dwa punkty kontrolne i punkt końcowy. |
| CloseLoop | Brak | Powróć do początkowej pozycji. |
| End | Brak | Zakończ ścieżkę. |

[MotionPathPointsType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/motionpathpointstype/) opisuje cechy edycji punktów, takie jak narożniki lub punkty gładkie. Nie zastępuje typu polecenia. Użyj typu punktu krzywej w przykładzie krzywej poniżej oraz typu punktu narożnika dla segmentów prostych.

Współrzędne ścieżki są znormalizowane do wymiarów slajdu: przemieszczenie X o 0,25 oznacza jedną czwartą szerokości slajdu, nie 0,25 punktu. Dodatni Y rośnie w dół. Polecenia bezwzględne określają pozycje w systemie współrzędnych ścieżki; polecenia względne określają offsety od bieżącej pozycji. To jest oddzielne od [Origin](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotioneffect/origin/), które wybiera ramę odniesienia ścieżki, oraz [PathEditMode](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotioneffect/patheditmode/), który kontroluje, jak ścieżka przemieszcza się wraz z ruchem kształtu.

### **Utwórz prostą ścieżkę**

Utwórz zachowanie ruchu z punktem początkowym, jednym segmentem prostym i poleceniem końcowym. [IMotionPath.Add](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotionpath/add/) przyjmuje typ polecenia, jego punkty, typ punktu oraz flagę współrzędnych względnych.

Polecenie początkowe ustawia (0, 0), a linia kończy się w (0.25, 0), dając trasie poziome przemieszczenie równe jednej czwartej szerokości slajdu. Polecenie końcowe nie posiada współrzędnych. Po przypisaniu ścieżki, dodanie zachowania ruchu do efektu łączy tę trasę z prostokątem.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` zawiera jedno zachowanie ruchu z trzema poleceniami ścieżki. Poniższe przykłady edycji plików korzystają z tej znanej struktury.

### **Porównaj współrzędne bezwzględne i względne**

Te dwa obiekty ścieżki opisują tę samą trasę. Polecenie bezwzględne kończy się w (0.3, 0.1); polecenie względne dodaje (0.1, 0.1) do bieżącej pozycji, czyli (0.2, 0).

Obie ścieżki zaczynają w tym samym miejscu. Dla linii względnej dodaj jej offsety X i Y do bieżącej pozycji, aby uzyskać punkt końcowy; dla linii bezwzględnej odczytaj punkt końcowy bezpośrednio. Przełączenie flagi bez konwersji współrzędnych opisałoby inną trasę.

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Przypisz jedną z tych ścieżek do zachowania ruchu, aby użyć jej w prezentacji. Ostatni argument logiczny wybiera współrzędne względne dla tego polecenia.

### **Zamień linię na krzywą**

Otwórz `motion.pptx` i zamień jej polecenie linii na krzywą sześcienną. Najpierw podaj dwa punkty kontrolne, a na końcu punkt docelowy.

Pozycja początkowa jest dostarczona przez poprzednie polecenie. Dwa pierwsze punkty kształtują krzywą, trzeci jest jej docelowym punktem; nie są to trzy kolejne cele. Aktualizacja typu polecenia, typu edycji punktów i tablicy punktów razem utrzymuje segment spójny z nową geometrią.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

Ścieżka w `curve.pptx` nadal ma trzy polecenia; jej środkowe polecenie teraz definiuje krzywą.

## **Inspekcja i edycja zapisanej ścieżki**

Każdy [IMotionCmdPath](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotioncmdpath/) udostępnia [Points](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotioncmdpath/pointstype/), oraz [IsRelative](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotioncmdpath/isrelative/). Poniższe przykłady używają znanej ścieżki z trzema poleceniami w `motion.pptx`. Dla dowolnych danych wejściowych najpierw zlokalizuj docelowy efekt i sprawdź typy poleceń oraz liczbę punktów przed edycją po indeksie.

### **Odczytaj polecenia i współrzędne**

Odczytaj ścieżkę bez jej modyfikacji. Polecenia End i CloseLoop nie wymagają punktów, więc przewiduj możliwość tablicy punktów równej null.

Wynik łączy każde polecenie z jego flagą współrzędnych względnych przed wypisaniem punktów. Umożliwia to odróżnienie punktu końcowego od offsetu przed zmianą ścieżki. Krzywa wypisałaby trzy punkty, natomiast prosta linia w tym pliku wypisuje tylko jeden.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

Lista zawiera punkt początkowy, bezwzględną linię kończącą się w (0.25, 0) oraz polecenie End.

### **Zmień punkt końcowy**

Otwórz `motion.pptx` i zamień tablicę punktów linii, aby przesunąć jej punkt końcowy.

W pliku wejściowym indeks 0 to polecenie początkowe, a indeks 1 to linia. Zamiana jedynego punktu linii zmienia jej docelowy punkt bez zmiany typu polecenia, czasu ani pozycji w kolekcji. Ponieważ polecenie używa współrzędnych bezwzględnych, nowa para określa pozycję, a nie dodatkowy offset.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

Linia w `motion-endpoint.pptx` kończy się w (0.4, 0.1); oryginalny plik pozostaje niezmieniony.

### **Zamień segment**

Użyj [Insert](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotionpath/insert/) i [RemoveAt](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/imotionpath/removeat/) aby zamienić linię w `motion.pptx`. Wstawienie przesuwa starą linię do indeksu 2.

To pokazuje zamianę obiektu polecenia zamiast edycji istniejących współrzędnych. Po wstawieniu kolekcja tymczasowo zawiera polecenie początkowe, nową linię, starą linię i polecenie End. Usunięcie indeksu 2 usuwa starą linię i pozostawia nową trasę.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

Zapisana ścieżka nadal ma trzy polecenia, przy czym nowa linia kończy się w (0.2, 0.1), a polecenie End jest ostatnie.

## **Modyfikacja i weryfikacja istniejącego zachowania**

Gdy indeks zachowania jest nieznany, wybierz je według typu. Ten przykład otwiera `rotation.pptx`, znajduje jego [IRotationEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/irotationeffect/), zmienia kąt i sprawdza zapisaną wartość po ponownym otwarciu.

Sprawdzenie typu pozwala pętli pominąć zachowania, które nie są obrotami. Drugi odczyt wczytuje zapisany plik do osobnego obiektu prezentacji, więc porównanie sprawdza zachowane dane, a nie wartość wciąż trzymaną w pamięci. Ten przykład wciąż zakłada, że znany efekt jest pierwszy w głównej sekwencji; wybór zachowania według typu nie lokalizuje właściwego efektu w dowolnej prezentacji.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

Wynik to `Rotation preserved: True`. Zastosuj ten sam wzorzec sprawdzania typu do innych zachowań. Dla pełnej weryfikacji zachowania, porównaj docelowy kształt, efekt, typy i kolejność zachowań, czasowanie oraz polecenia ścieżki. Używaj tolerancji numerycznej dla wartości zmiennoprzecinkowych. Dla prezentacji o nieznanej strukturze animacji, zobacz [Odczyt animacji kształtów](/slides/pl/net/shape-animation/#read-shape-animations) w celu przeglądu głównych i interaktywnych sekcji.

## **Kolejność zachowań, presety i odtwarzanie**

Kolejność w [IBehaviorCollection](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehaviorcollection/) jest zapisaną kolejnością operacji efektu. Nie jest to playlista, w której każde zachowanie automatycznie czeka na poprzednie. Czasowanie i otaczający efekt określają harmonogram. Zachowania mogą nakładać się na siebie, a operacje na tej samej właściwości mogą współdziałać przez [Additive](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehavior/additive/) i [Accumulate](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ibehavior/accumulate/). Nie używaj samodzielnego przestawiania kolekcji, aby zaplanować „przesuń, potem obróć”; używaj jawnego czasowania lub oddzielnych efektów, jak opisano w [Shape Animation](/slides/pl/net/shape-animation/).

Typ i podtyp efektu ([Type](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/type/) oraz [Subtype](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/subtype/)) opisują jego preset. Nie są pełnym opisem edytowanego drzewa zachowań. Wybierz preset i podtyp przed dostosowaniem zachowań: zmiana presetu może odbudować kolekcję i usunąć własne operacje. Na przykład zmiana spersonalizowanego efektu Spin na Fade może zastąpić jego zachowanie obrotu zachowaniami set i filter. Po zmianie presetu lub podtypu ponownie sprawdź kolekcję. Czyszczenie zachowań presetu może także usunąć operacje widoczności lub inicjalizacji, które preset wymaga. Przykłady celowo używają widocznych kształtów i zamieniają zachowania; nie odtwarzają pełnej implementacji każdego presetu.

## **Kompatybilność formatów**

Zachowane drzewo zachowań nie gwarantuje identycznego odtwarzania we wszystkich podglądarkach czy rendererach eksportu. Sprawdzaj osobno zapisane dane i wygenerowany wynik.

| Format lub wyjście | Co zweryfikować |
| --- | --- |
| PPTX | Używaj jako głównego formatu w tych przykładach. Otwórz ponownie, aby zweryfikować edytowalne drzewo zachowań, a następnie sprawdź odtwarzanie w docelowej wersji PowerPoint. |
| PPT | Reprezentacja w starszym formacie binarnym może różnić się od PPTX. Przetestuj osobny cykl zapisu‑i‑odczytu oraz odtwarzanie; nie wyciągaj wniosków o obsłudze każdej niestandardowej kombinacji na podstawie udanego wyniku PPTX. |
| PDF, PNG, JPEG i inne statyczne obrazy slajdów | Zawierają statyczną reprezentację slajdu, a nie odtwarzalną oś czasu zachowań ani gwarantowaną ostateczną klatkę animacji. |
| [HTML5](/slides/pl/net/export-to-html5/) | Może odtwarzać obsługiwane animacje, gdy animacja kształtu jest włączona w opcjach eksportu. Przetestuj niestandardowe kombinacje w przeglądarce. |
| [Animated GIF](/slides/pl/net/convert-powerpoint-to-animated-gif/) | Przechowuje wyrenderowane klatki, a nie edytowalne zachowania ani interakcje wyzwalane kliknięciem. Sprawdź rzeczywisty wyrenderowany ruch. |
| [Video](/slides/pl/net/convert-powerpoint-to-video/) | Renderuje klatki animacji i koduje je jako wideo. Obsługa jest ograniczona do [obsługiwanych animacji i efektów](/slides/pl/net/convert-powerpoint-to-video/#supported-animations-and-effects) renderera; polecenia i zdarzenia interaktywne nie stają się edytowalną osią czasu. |

## **FAQ**

**Dlaczego mój efekt zawiera zachowania, zanim je dodam?**  
Tworzenie predefiniowanego efektu może generować jego podstawowe operacje. Przejrzyj je, zanim zdecydujesz, czy rozszerzyć preset, czy zamienić jego zachowania.

**Czy przeniesienie zachowania na początek sprawia, że odtwarzane jest jako pierwsze?**  
Niekoniecznie. Kolejność w kolekcji nie zastępuje czasowania. Sprawdź opóźnienia, czasy trwania oraz interakcje między operacjami na tej samej właściwości.

**Dlaczego polecenie End nie ma punktów?**  
Oznacza koniec ścieżki i nie wymaga współrzędnych. Przy przeglądaniu ścieżki odczytanej z pliku sprawdź, czy tablica punktów jest nullem.

**Czy udana podróż w obie strony wystarczy, aby potwierdzić odtwarzanie?**  
Nie. Ponowne otwarcie potwierdza zachowanie właściwości, które sprawdziłeś. Przetestuj odtwarzacz pokazu slajdów lub eksport animacji osobno, aby potwierdzić zachowanie wizualne.