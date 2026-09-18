---
title: Tworzenie i modyfikacja niestandardowych zachowań animacji w C++
linktitle: Niestandardowa animacja
type: docs
weight: 151
url: /pl/cpp/custom-animation/
keywords:
- niestandardowa animacja
- zachowanie animacji
- ścieżka ruchu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Tworzenie, przeglądanie i modyfikowanie niestandardowych zachowań animacji oraz edytowalnych ścieżek ruchu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Niestandardowe zachowania animacji pozwalają kontrolować poszczególne operacje wewnątrz efektu animacji, takie jak zmiana koloru, obracanie kształtu lub podążanie edytowalną ścieżką ruchu. Ten przewodnik pokazuje, jak tworzyć i łączyć zachowania, konfigurować ich czas, przeglądać i modyfikować istniejące animacje oraz weryfikować, że ich właściwości przetrwają zapis i ponowne otwarcie prezentacji.

Aby uzyskać informacje o gotowych efektach i wyzwalaczach kliknięcia, zobacz [Animacja Kształtów](/slides/pl/cpp/shape-animation/).

## **Zrozumienie Modelu Animacji**

Animacja jest zorganizowana jako **Oś czasu → Sekwencja → Efekt → Zachowania**:

- Oś czasu slajdu [get_Timeline](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/get_timeline/) zawiera jego główną sekwencję i sekwencje interaktywne.
- [ISequence](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/isequence/) zawiera efekty, potencjalnie skierowane do różnych kształtów.
- [IEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/) identyfikuje docelowy kształt, zestaw ustawień wstępnych, podtyp i czas trwania efektu.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/get_behaviors/) zawiera operacje implementujące efekt: zmianę koloru, przemieszczanie, obracanie, ustawianie właściwości i inne.

## **Tworzenie pojedynczych zachowań**

Wywołaj [ISequence::AddEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/isequence/addeffect/), aby utworzyć efekt i uzyskać dostęp do jego kolekcji [get_Behaviors](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/get_behaviors/). Zestaw wstępny może automatycznie wypełnić tę kolekcję. Zachowaj jego operacje przy rozszerzaniu zestawu wstępnego lub użyj [Clear](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorcollection/clear/) przy świadomym ich zastąpieniu.

[IBehaviorFactory](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorfactory/) tworzy osiem typów zachowań zilustrowanych poniżej. Ruch jest opisany w sekcji [Budowanie ścieżki ruchu](#build-a-motion-path). Każdy przykład tworzenia jest samodzielnym kodem do uruchomienia w funkcji; późniejsze przykłady edycji podają, którego pliku wyjściowego używają.

### **Obrót**

Użyj [CreateRotationEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/), aby utworzyć obrót. [get_By](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/irotationeffect/get_by/) określa względny kąt w stopniach; [get_From](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/irotationeffect/get_from/) i [get_To](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/irotationeffect/get_to/) określają punkty końcowe.

Przykład zaczyna się od efektu Spin, zastępuje jego operacje zestawu wstępnego jednym zachowaniem obrotu i nadaje tej operacji dwusekundowy czas trwania. Względny kąt 90 stopni oznacza ćwierć obrotu względem początkowej orientacji kształtu, więc nie jest potrzebny explicite określony kąt początkowy.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` zawiera jeden kształt i jedno zachowanie obrotu. Kolekcja, synchronizacja oraz przykłady edycji obrotu poniżej używają tego pliku.

### **Skala**

Użyj [CreateScaleEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) z procentami X/Y: [get_From](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/iscaleeffect/get_from/) i [get_To](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/iscaleeffect/get_to/) opisują początkowy i końcowy rozmiar, natomiast [get_By](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/iscaleeffect/get_by/) opisuje względną zmianę. Tutaj 100 oznacza rozmiar oryginalny.

Przykład zwiększa oba wymiary z 100 % do 125 % w ciągu dwóch sekund. Użycie równych wartości poziomych i pionowych zachowuje proporcje kształtu; różne wartości rozciągną jedną z nich bardziej niż drugą.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Kolor**

Użyj [CreateColorEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/), aby zmienić wypełnienie z niebieskiego na pomarańczowy. [get_From](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/icoloreffect/get_from/) i [get_To](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/icoloreffect/get_to/) są kolorami; [get_By](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/icoloreffect/get_by/) jest przesunięciem koloru. [IBehavior::get_Properties](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehavior/get_properties/) określa atrybut podlegający animacji.

Wypełnienie kształtu jest początkowo ustawione na niebieskie, co odpowiada początkowemu kolorowi w animacji. Wybór atrybutu wypełnienia kolorem informuje zachowanie, którą część kształtu należy zmienić; same kolory końcowe nie określają tego atrybutu. Zapisany efekt opisuje dwu‑sekundowy przejściowy do pomarańczowego.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Filtr**

Użyj [CreateFilterEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/), aby wybrać zanikanie. [get_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ifiltereffect/get_subtype/) i [get_Reveal](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) określają filtr, kierunek oraz to, czy odsłonić czy ukryć kształt.

Przykład konfiguruje dwusekundowe zanikanie, które odsłania kształt przy pomocy podtypu „right‑direction”. Ustawienia filtru należą do zachowania wewnątrz efektu, więc są konfigurowane po usunięciu oryginalnych operacji zestawu wstępnego.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Właściwość**

Użyj [CreatePropertyEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/), aby animować krycie (opacity). [get_From](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ipropertyeffect/get_to/) i [get_By](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ipropertyeffect/get_by/) są łańcuchami znaków interpretowanymi przy użyciu [get_ValueType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) i [get_CalcMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/). Wybierz wartości końcowe lub względne przesunięcie zamiast ustawiać wszystkie trzy jednocześnie.

Tutaj wybranym atrybutem jest krycie, a łańcuchy liczbowe oznaczają zmianę z 25 % krycia do pełnego krycia. Interpolacja liniowa opisuje płynne przejście między tymi wartościami. Przy dostosowywaniu tego przykładu do innego atrybutu wybierz odpowiedni typ wartości i wartości końcowe stosowne do tego atrybutu.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Ustawienie**

Użyj [CreateSetEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/), aby przypisać widoczność poprzez [get_To](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/iseteffect/get_to/). Zachowanie typu Set nie interpoluje między punktami końcowymi.

Przykład wybiera atrybut widoczności i przypisuje łańcuch `visible` w momencie wykonania zachowania. W C++ należy opakować ten łańcuch w obiekt przed przekazaniem go do zachowania Set. Prostokąt jest już widoczny w tej minimalnej prezentacji, więc przypisanie może nie wywołać widocznej zmiany samo w sobie. Taka operacja jest przydatna jako część większego efektu, który także kontroluje moment ukrycia lub wyświetlenia kształtu.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Polecenie**

Użyj [CreateCommandEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) i skonfiguruj [get_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), oraz [get_ShapeTarget](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). Umieść nagranie WAV o nazwie `sample.wav` w katalogu roboczym. Ten przykład osadza je za pomocą [AddAudioFrameEmbedded](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) i przypisuje polecenie odtworzenia do klatki audio.

Klatka audio jest zarówno celem efektu, jak i celem polecenia. Łączy to żądanie odtworzenia z osadzonym nagraniem; sam łańcuch polecenia nie określa, który obiekt multimedialny ma być kontrolowany. Efekt jest skonfigurowany, aby rozpoczął się po kliknięciu podczas pokazu slajdów.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

Zapis zapisuje polecenie w pliku `command.pptx`; nie odtwarza ono nagrania. Odtwarzanie wymaga odtwarzacza pokazu slajdów, który obsługuje polecenie i jego docelowy zasób multimedialny.

## **Zarządzanie kolekcją zachowań**

[IBehaviorCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorcollection/) obsługuje [Add](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorcollection/remove/), oraz [RemoveAt](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). Ten przykład otwiera `rotation.pptx`, dodaje skalowanie, przesuwa je przed obrotem i usuwa obrót. Usunięcie i ponowne wstawienie tego samego obiektu zmienia jego pozycję w kolekcji bez tworzenia kopii.

Sekwencja edycji zmienia kolekcję z obrót‑skalowanie na skalowanie‑obrót, a następnie do samego skalowania. Indeksy odnoszą się do bieżącej kolekcji, więc usunięcie używa nowego indeksu obrotu po przestawieniu. Końcowe wyliczenie potwierdza, które zachowanie zostanie zapisane.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Wynik to `ScaleEffect`: pozostaje tylko skalowanie. Kolejność w kolekcji nie powoduje automatycznie kolejności odtwarzania jednego po drugim. Czyść kolekcję tylko wtedy, gdy zamierzasz zastąpić wszystkie jej operacje.

## **Konfigurowanie czasu zachowania**

[IBehavior::get_Timing](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehavior/get_timing/) udostępnia [ITiming](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/itiming/), niezależnie od [IEffect::get_Timing](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/get_timing/). Czas efektu planuje otaczający efekt; czas zachowania opisuje operację wewnątrz niego.

### **Ustawienie czasu trwania, opóźnienia, powtórzeń i przyspieszenia**

Otwórz `rotation.pptx` i ustaw [get_Duration](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/itiming/get_duration/) oraz [get_TriggerDelayTime](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) w sekundach, potem skonfiguruj [get_RepeatCount](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/itiming/get_repeatcount/). [get_Accelerate](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/itiming/get_accelerate/) i [get_Decelerate](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/itiming/get_decelerate/) są ułamkami czasu trwania; ich suma nie może przekroczyć 1.

Plik wejściowy to ten utworzony w przykładzie obrotu, w którym pierwsze zachowanie to obrót. Ten przykład zmienia wyłącznie czas tego zachowania; kąt 90° pozostaje niezmieniony. Oddzielenie kąta od czasu ułatwia dostosowanie tempa bez przebudowy animacji.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Zachowanie używa dwusekundowego czasu trwania, półsekundowego opóźnienia i liczby powtórzeń równej 3. Pierwsze i ostatnie 20 % jego czasu przeznaczone jest na przyspieszenie i zwolnienie.

Inne polityki powtórzeń obejmują [get_RepeatDuration](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), oraz [get_RepeatUntilNextClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); wybierz jedną politykę zamiast włączania ich wszystkich jednocześnie. [get_AutoReverse](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/itiming/get_autoreverse/) odtwarza animację wstecz po ukończeniu jej w przód. Przyspieszenie i zwolnienie dotyczą ciągłych zmian, a nie dyskretnych przypisań czy poleceń.

## **Budowanie ścieżki ruchu**

Użyj [CreateMotionEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/), aby utworzyć ruch. Jego [get_From](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotioneffect/get_to/), oraz [get_By](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotioneffect/get_by/) opisują współrzędne procentowe lub przesunięcia. Dla edytowalnej trasy utwórz [MotionPath](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/motionpath/) i przypisz ją do [IMotionEffect::get_Path](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotioneffect/get_path/). [IMotionPath](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotionpath/) przechowuje polecenia ścieżki.

[MotionCommandPathType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/motioncommandpathtype/) wybiera operację:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Ustaw początkową pozycję. |
| LineTo | One | Przemieść się prostą linią do punktu końcowego. |
| CurveTo | Three | Podążaj za krzywą sześcienną określoną dwoma punktami kontrolnymi i punktem końcowym. |
| CloseLoop | None | Powróć do pozycji początkowej. |
| End | None | Zakończ ścieżkę. |

[MotionPathPointsType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/motionpathpointstype/) opisuje charakterystykę edycji punktów, np. wierzchołki narożne lub wygładzone. Nie zastępuje typu polecenia. Użyj typu punktu krzywej dla przykładu krzywej poniżej oraz typu punktu narożnego dla segmentów prostych.

Współrzędne ścieżki są normalizowane względem wymiarów slajdu: przemieszczenie X wynoszące 0.25 oznacza jedną czwartą szerokości slajdu, nie 0.25 punktu. Dodatni Y rośnie w dół. Polecenia bezwzględne określają pozycje w układzie współrzędnych ścieżki; polecenia względne określają przesunięcia od bieżącej pozycji. To jest oddzielne od [get_Origin](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotioneffect/get_origin/), które wybiera ramę odniesienia ścieżki, oraz [get_PathEditMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/), które kontroluje, jak ścieżka porusza się przy przemieszczeniu kształtu.

### **Utworzenie prostej ścieżki**

Utwórz zachowanie ruchu z punktem początkowym, jednym segmentem prostym i poleceniem końcowym. [IMotionPath::Add](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotionpath/add/) przyjmuje typ polecenia, jego punkty, typ punktu oraz flagę współrzędnych względnych.

Polecenie początkowe ustawia (0, 0), a linia kończy się w (0.25, 0), dając trasę poziomego przesunięcia o jedną czwartą szerokości slajdu. Polecenie końcowe nie ma punktów współrzędnych. Po przypisaniu ścieżki, dodanie zachowania ruchu do efektu łączy tę trasę z prostokątem.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` zawiera jedno zachowanie ruchu z trzema poleceniami ścieżki. Poniższe przykłady edycji pliku używają tej znanej struktury.

### **Porównanie współrzędnych bezwzględnych i względnych**

Te dwa obiekty ścieżki opisują tę samą trasę. Polecenie bezwzględne kończy się w (0.3, 0.1); polecenie względne dodaje (0.1, 0.1) do bieżącej pozycji, czyli (0.2, 0).

Obie ścieżki zaczynają się w tej samej pozycji. Dla linii względnej należy dodać jej przesunięcia X i Y do bieżącej pozycji, aby uzyskać punkt końcowy; dla linii bezwzględnej odczytuje się punkt końcowy bezpośrednio. Zmiana flagi bez przeliczenia współrzędnych opisałaby inną trasę.

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

Przypisz dowolną z tych ścieżek do zachowania ruchu, aby użyć jej w prezentacji. Ostatni argument logiczny wybiera współrzędne względne dla tego polecenia.

### **Zastąpienie linii krzywą**

Otwórz `motion.pptx` i zamień jej polecenie linii na krzywą sześcienną. Najpierw podaj dwa punkty kontrolne, a następnie punkt końcowy.

Pozycja początkowa pochodzi z poprzedniego polecenia. Pierwsze dwa punkty kształtują krzywą, trzeci jest jej celem; nie są to trzy kolejne cele. Aktualizacja typu polecenia, typu edycji punktów i tablicy punktów jednocześnie utrzymuje segment spójny z nową geometrią.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Ścieżka w `curve.pptx` nadal ma trzy polecenia; jej środkowe polecenie teraz definiuje krzywą.

## **Przegląd i edycja zapisanej ścieżki**

Każdy [IMotionCmdPath](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotioncmdpath/) udostępnia [get_Points](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), oraz [get_IsRelative](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). Poniższe przykłady używają znanej trójpoleceniowej ścieżki w `motion.pptx`. Dla dowolnego wejścia najpierw zlokalizuj docelowy efekt i sprawdź typy poleceń oraz liczbę punktów przed edycją przez indeks.

### **Odczyt poleceń i współrzędnych**

Odczytaj ścieżkę bez jej zmiany. Polecenia końcowe i zamykające nie wymagają punktów, więc dopuszczalna jest pusta tablica punktów.

Wynik wymienia każde polecenie wraz z flagą współrzędnych względnych przed wypisaniem jego punktów. Umożliwia to odróżnienie punktu końcowego od przesunięcia przed modyfikacją ścieżki. Krzywa wypisze trzy punkty, natomiast prosta linia w tym pliku wypisze tylko jeden.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

Wymieniona jest pozycja początkowa, bezwzględna linia kończąca w (0.25, 0) oraz polecenie końcowe.

### **Zmiana punktu końcowego**

Otwórz `motion.pptx` i zamień tablicę punktów linii, aby przesunąć jej punkt końcowy.

W pliku wejściowym indeks 0 to polecenie początkowe, a indeks 1 to linia. Zastąpienie jednego punktu linii zmienia jej cel bez zmiany typu polecenia, czasu ani pozycji w kolekcji. Ponieważ polecenie używa współrzędnych bezwzględnych, nowa para określa pozycję, a nie dodatkowe przesunięcie.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Linia w `motion-endpoint.pptx` kończy się w (0.4, 0.1); oryginalny plik pozostaje niezmieniony.

### **Zastąpienie segmentu**

Użyj [Insert](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotionpath/insert/) i [RemoveAt](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/imotionpath/removeat/) aby zamienić linię w `motion.pptx`. Wstawienie przesuwa starą linię do indeksu 2.

Pokazuje to zastąpienie obiektu polecenia zamiast edytowania jego istniejących współrzędnych. Po wstawieniu kolekcja tymczasowo zawiera polecenie początkowe, nową linię, starą linię i polecenie końcowe. Usunięcie indeksu 2 usuwa starą linię, pozostawiając nową trasę.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Zapisana ścieżka nadal ma trzy polecenia, nowa linia kończy się w (0.2, 0.1), a polecenie końcowe jest ostatnie.

## **Modyfikacja i weryfikacja istniejącego zachowania**

Gdy indeks zachowania jest nieznany, wybierz je po typie. Ten przykład otwiera `rotation.pptx`, znajduje jego [IRotationEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/irotationeffect/), zmienia kąt i sprawdza zapisaną wartość po ponownym otwarciu.

Sprawdzenie typu pozwala pominąć zachowania, które nie są obrotami. Drugi odczyt ładuje zapisany plik do osobnego obiektu prezentacji, więc porównanie sprawdza utrwalone dane, a nie wartość wciąż trzymaną w pamięci. Założenie pozostaje, że znany efekt znajduje się na pierwszej pozycji w głównej sekwencji; wybieranie zachowania po typie nie lokalizuje właściwego efektu w dowolnej prezentacji.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

Wynik to `Rotation preserved: True`. Zastosuj ten sam wzorzec sprawdzania typu do innych zachowań. Dla pełnego sprawdzenia zachowania porównaj docelowy kształt, efekt, typy i kolejność zachowań, czas, oraz polecenia ścieżki. Użyj tolerancji numerycznej dla wartości zmiennoprzecinkowych. Dla prezentacji o nieznanym układzie animacji zobacz [Odczyt animacji kształtów](/slides/pl/cpp/shape-animation/#read-shape-animations) w celu przejścia przez główne i interaktywne sekwencje.

## **Kolejność zachowań, zestawy wstępne i odtwarzanie**

Kolejność w [IBehaviorCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehaviorcollection/) to zapisany porządek operacji efektu. Nie jest to lista odtwarzania, w której każde zachowanie automatycznie czeka na poprzednie. Czas i otaczający efekt decydują o harmonogramie. Zachowania mogą się nakładać, a operacje na tej samej właściwości mogą oddziaływać przez [get_Additive](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehavior/get_additive/) i [get_Accumulate](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ibehavior/get_accumulate/). Nie używaj samego przestawiania kolejności w kolekcji, aby zaplanować „przesuń, potem obróć”; użyj wyraźnego czasu lub oddzielnych efektów, jak opisano w [Animacja Kształtów](/slides/pl/cpp/shape-animation/).

Typ efektu [get_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/get_type/) i [get_Subtype](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/get_subtype/) opisują jego zestaw wstępny. Nie stanowią pełnego opisu edytowanego drzewa zachowań. Wybierz zestaw wstępny i podtyp przed dostosowaniem zachowań: zmiana zestawu wstępnego może odbudować kolekcję i usunąć twoje własne operacje. Na przykład zmiana dostosowanego efektu Spin na Fade może zastąpić zachowanie obrotu zachowaniami set i filter. Po zmianie zestawu wstępnego lub podtypu ponownie przejrzyj kolekcję. Czyszczenie zachowań zestawu wstępnego może także usunąć operacje widoczności lub inicjalizacji, które zestaw wymaga. Przykłady celowo używają widocznych kształtów i zamieniają zachowania; nie rekonstruują pełnej implementacji każdego zestawu wstępnego.

## **Zgodność formatów**

Zachowanie drzewa po zachowaniu nie gwarantuje identycznego odtwarzania w każdym przeglądarce lub silniku eksportu. Sprawdzaj oddzielnie zapisane dane i wygenerowany wynik.

| Format lub wyjście | Co weryfikować |
| --- | --- |
| PPTX | Używaj jako głównego formatu w tych przykładach. Otwórz ponownie, aby zweryfikować edytowalne drzewo zachowań, a następnie sprawdź odtwarzanie w docelowej wersji PowerPoint. |
| PPT | Starsza reprezentacja binarna może różnić się od PPTX. Przetestuj osobny cykl zapisu‑odczytu i odtwarzania; nie zakładaj wsparcia dla każdej niestandardowej kombinacji na podstawie pomyślnego wyniku PPTX. |
| PDF, PNG, JPEG i inne statyczne obrazy slajdów | Zawierają statyczną reprezentację slajdu, nie odtwarzalną oś czasu zachowań ani gwarantowaną ostateczną klatkę animacji. |
| [HTML5](/slides/pl/cpp/export-to-html5/) | Może odtwarzać obsługiwane animacje, gdy animacja kształtu jest włączona w opcjach eksportu. Testuj własne kombinacje w przeglądarce. |
| [Animated GIF](/slides/pl/cpp/convert-powerpoint-to-animated-gif/) | Przechowuje wyrenderowane klatki, a nie edytowalne zachowania ani interakcje wyzwalane kliknięciem. Sprawdź rzeczywisty wyrenderowany ruch. |
| [Video](/slides/pl/cpp/convert-powerpoint-to-video/) | Renderuje klatki animacji i koduje je jako wideo. Wsparcie ogranicza się do [obsługiwanych animacji i efektów](/slides/pl/cpp/convert-powerpoint-to-video/#supported-animations-and-effects); polecenia i zdarzenia interaktywne nie stają się edytowalną osią czasu. |

## **FAQ**

**Dlaczego mój efekt zawiera zachowania, zanim coś dodałem?**

Utworzenie gotowego efektu może stworzyć jego podstawowe operacje. Przejrzyj je, zanim zdecydujesz, czy rozszerzyć zestaw wstępny, czy zastąpić jego zachowania.

**Czy przeniesienie zachowania na początek spowoduje, że odtworzy się jako pierwsze?**

Niekoniecznie. Kolejność w kolekcji nie zastępuje czasu. Sprawdź opóźnienia, czasy trwania i interakcje między operacjami na tej samej właściwości.

**Dlaczego polecenie końcowe nie ma punktów?**

Oznacza koniec ścieżki i nie wymaga współrzędnych. Przy przeglądaniu ścieżki odczytanej z pliku sprawdzaj, czy tablica punktów jest pusta.

**Czy udany cykl zapisu‑odczytu wystarczy, aby potwierdzić odtwarzanie?**

Nie. Otworzenie ponownie potwierdza zachowanie sprawdzonych właściwości. Przetestuj odtwarzacz pokazu slajdów lub eksport animacji osobno, aby zweryfikować zachowanie wizualne.