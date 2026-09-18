---
title: Создание и изменение пользовательских анимационных поведений в C++
linktitle: Пользовательская анимация
type: docs
weight: 151
url: /ru/cpp/custom-animation/
keywords:
- пользовательская анимация
- поведение анимации
- путь движения
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Создавайте, просматривайте и изменяйте пользовательские анимационные поведения и редактируемые пути движения в презентациях PowerPoint с помощью Aspose.Slides для C++."
---
## **Обзор**

Пользовательские анимационные поведения позволяют управлять отдельными операциями внутри анимационного эффекта, такими как изменение цвета, вращение фигуры или следование по редактируемому пути движения. В этом руководстве показывается, как создавать и комбинировать поведения, настраивать их тайминг, просматривать и изменять существующие анимации, а также проверять, сохраняются ли их свойства при сохранении и повторном открытии презентации.

Для предопределённых эффектов и триггеров щелчка см. [Анимация фигур](/slides/ru/cpp/shape-animation/).

## **Понимание модели анимации**

Анимация организована как **Timeline → Sequence → Effect → Behaviors**:

- Слайд содержит [get_Timeline](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/get_timeline/), в котором находятся его главная последовательность и интерактивные последовательности.
- [ISequence](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/isequence/) содержит эффекты, потенциально направленные на разные фигуры.
- [IEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/) определяет целевую фигуру, пресет, подтип и тайминг эффекта.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/get_behaviors/) хранит операции, реализующие эффект: изменение цвета, перемещение, вращение, установка свойства и т.д.

## **Создание отдельных поведений**

Вызовите [ISequence::AddEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/isequence/addeffect/) для создания эффекта и доступа к его коллекции [get_Behaviors](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/get_behaviors/). Пресет может автоматически заполнить эту коллекцию. Сохраняйте его операции при расширении пресета или используйте [Clear](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorcollection/clear/) при намеренной замене.

[IBehaviorFactory](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorfactory/) создаёт восемь типов поведений, показанных ниже. Движение рассматривается в разделе [Создание пути движения](#build-a-motion-path). Каждый пример создания — самостоятельный код, который можно выполнить внутри функции; примеры последующего редактирования указывают, какой файл вывода они используют.

### **Вращение**

Используйте [CreateRotationEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) для создания вращения. [get_By](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/irotationeffect/get_by/) задаёт относительный угол в градусах; [get_From](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/irotationeffect/get_from/) и [get_To](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/irotationeffect/get_to/) задают конечные точки.

Пример начинается с эффекта Spin, заменяет его операции пресета одним поведением вращения и задаёт этой операции продолжительность в две секунды. Относительный угол 90° представляет четверть оборота от исходной ориентации фигуры, поэтому начальный угол задавать явно не требуется.

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

`rotation.pptx` содержит одну фигуру и одно поведение вращения. Коллекция, тайминг и примеры редактирования вращения ниже используют этот файл.

### **Масштабирование**

Используйте [CreateScaleEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) с процентами по X/Y: [get_From](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/iscaleeffect/get_from/) и [get_To](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/iscaleeffect/get_to/) описывают начальный и конечный размер, а [get_By](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/iscaleeffect/get_by/) описывает относительное изменение. Здесь 100 означает исходный размер.

Пример увеличивает обе оси с 100 % до 125 % за две секунды. Использование одинаковых горизонтальных и вертикальных процентов сохраняет пропорции фигуры; разные проценты растянут одну ось сильнее другой.

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

### **Цвет**

Используйте [CreateColorEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) для изменения заливки с синего на оранжевый. [get_From](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/icoloreffect/get_from/) и [get_To](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/icoloreffect/get_to/) — это цвета; [get_By](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/icoloreffect/get_by/) — смещение цвета. [IBehavior::get_Properties](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehavior/get_properties/) определяет анимируемый атрибут.

Заливка фигуры изначально установлена в синий, соответствуя стартовому цвету анимации. Выбор атрибута заливки сообщает поведению, какую часть фигуры менять; сами конечные цвета не указывают атрибут. Сохранённый эффект описывает двухсекундный переход к оранжевому.

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

### **Фильтр**

Используйте [CreateFilterEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) для выбора затвора. [get_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ifiltereffect/get_subtype/) и [get_Reveal](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) задают тип фильтра, направление и то, раскрывать ли фигуру или скрывать её.

Этот пример настраивает двухсекундный затвор, раскрывающий фигуру справа. Параметры фильтра принадлежат поведению внутри эффекта, поэтому они конфигурируются после удаления оригинальных операций пресета.

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

### **Свойство**

Используйте [CreatePropertyEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) для анимации непрозрачности. [get_From](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ipropertyeffect/get_to/) и [get_By](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ipropertyeffect/get_by/) — строки, интерпретируемые через [get_ValueType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) и [get_CalcMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/). Выбирайте конечные значения или относительное смещение, а не задавайте все три без разбора.

Здесь выбран атрибут «opacity», а числовые строки представляют изменение от 25 % непрозрачности до полной. Линейная интерполяция описывает постепенное изменение между этими значениями. При адаптации примера к другому атрибуту выбирайте тип значения и конечные значения, подходящие этому атрибуту.

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

### **Установка**

Используйте [CreateSetEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) для задания видимости через [get_To](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/iseteffect/get_to/). Поведение «set» не интерполирует между конечными точками.

Пример выбирает атрибут видимости и присваивает строку `visible` при выполнении поведения. В C++ строку следует обернуть в объект перед передачей в поведение. Прямоугольник уже видим в этой минимальной презентации, поэтому присваивание может не вызвать заметного визуального изменения само по себе. Такая операция полезна в составе более крупного эффекта, который также управляет тем, когда фигура скрывается или становится видимой.

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

### **Команда**

Используйте [CreateCommandEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) и настройте [get_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/icommandeffect/get_commandstring/) и [get_ShapeTarget](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). Поместите WAV‑запись `sample.wav` в рабочий каталог. Пример встраивает её через [AddAudioFrameEmbedded](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) и привязывает команду воспроизведения к аудио‑кадру.

Аудио‑кадр является и целью эффекта, и целью команды. Это связывает запрос воспроизведения с встроенной записью; сама строка команды не указывает, какой медиа‑объект контролировать. Эффект настроен на запуск по щелчку во время показа слайдов.

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

Сохранение помещает команду в `command.pptx`; запись не воспроизводится. Для воспроизведения требуется проигрыватель слайд‑шоу, поддерживающий команду и её медиа‑цель.

## **Управление коллекцией поведений**

[IBehaviorCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorcollection/) поддерживает [Add](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorcollection/remove/), и [RemoveAt](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). Этот пример открывает `rotation.pptx`, добавляет масштабирование, перемещает его перед вращением и удаляет вращение. Удаление и повторное вставление того же объекта меняет его позицию без создания копии.

Последовательность правок меняет порядок коллекции с rotation–scale на scale–rotation, а затем оставляет только scale. Индексы относятся к текущей коллекции, поэтому удаление использует новый индекс вращения после переупорядочения. Финальное перечисление подтверждает, какое поведение будет сохранено.

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

Результат — `ScaleEffect`: остаётся только масштабирование. Сам по себе порядок коллекции не планирует поведения одно за другим. Очищать коллекцию имеет смысл только при полной замене её операций.

## **Настройка тайминга поведения**

[IBehavior::get_Timing](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehavior/get_timing/) открывает [ITiming](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/), независимо от [IEffect::get_Timing](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/get_timing/). Тайминг эффекта планирует весь эффект; тайминг поведения описывает отдельную операцию внутри него.

### **Установка длительности, задержки, повторения и ускорения**

Откройте `rotation.pptx` и задайте [get_Duration](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/get_duration/) и [get_TriggerDelayTime](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) в секундах, затем настройте [get_RepeatCount](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/get_repeatcount/). [get_Accelerate](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/get_accelerate/) и [get_Decelerate](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/get_decelerate/) — доли от длительности; их сумма не должна превышать 1.

Входной файл — тот, что был создан в примере вращения, где первое поведение известно как вращение. Пример меняет только тайминг этого поведения; угол 90° остаётся неизменным. Разделение угла и тайминга упрощает регулирование скорости без пересборки анимации.

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

Поведение использует двухсекундную длительность, полсекундную задержку и количество повторов 3. Первые и последние 20 % длительности отводятся под ускорение и замедление.

Другие политики повторов: [get_RepeatDuration](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), [get_RepeatUntilNextClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); выбирайте одну, а не включайте их все одновременно. [get_AutoReverse](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/itiming/get_autoreverse/) воспроизводит анимацию обратно после прямого прохода. Ускорение и замедление применимы к непрерывным изменениям, а не к дискретным присваиваниям или командам.

## **Создание пути движения**

Используйте [CreateMotionEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) для создания движения. Его [get_From](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotioneffect/get_to/) и [get_By](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotioneffect/get_by/) описывают координаты или смещения в процентах. Для редактируемого маршрута создайте [MotionPath](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/motionpath/) и назначьте его в [IMotionEffect::get_Path](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotioneffect/get_path/). [IMotionPath](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotionpath/) хранит команды пути.

[MotionCommandPathType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/motioncommandpathtype/) выбирает операцию:

| Команда | Точки | Значение |
| --- | --- | --- |
| MoveTo | One | Устанавливает начальную позицию. |
| LineTo | One | Перемещается по прямому сегменту к конечной точке. |
| CurveTo | Three | Следует кубической кривой, определённой двумя контрольными точками и конечной точкой. |
| CloseLoop | None | Возвращается к начальной позиции. |
| End | None | Завершает путь. |

[MotionPathPointsType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/motionpathpointstype/) описывает характеристики редактирования точек, такие как «угловая» или «плавная». Это не заменяет тип команды. Для примера кривой используйте тип точки «curve», а для прямых сегментов — тип «corner».

Координаты пути нормированы к размерам слайда: смещение X = 0.25 соответствует одной четверти ширины слайда, а не 0.25 pt. Положительный Y идёт вниз. Абсолютные команды задают позиции в системе координат пути; относительные команды задают смещения от текущей позиции. Это отдельно от [get_Origin](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotioneffect/get_origin/), который выбирает систему отсчёта пути, и [get_PathEditMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/), управляющего перемещением пути при перемещении фигуры.

### **Создание прямого пути**

Создайте поведение движения с начальной точкой, одним прямым сегментом и командой завершения. [IMotionPath::Add](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotionpath/add/) принимает тип команды, её точки, тип точки и флаг относительных координат.

Начальная команда устанавливает (0, 0), линия заканчивается в (0.25, 0), давая горизонтальное смещение в одну четверть ширины слайда. Команда завершения не имеет координатных точек. После назначения пути добавление поведения движения к эффекту связывает этот маршрут с прямоугольником.

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

`motion.pptx` содержит одно движение с тремя командами пути. Последующие примеры редактирования файлов используют эту известную структуру.

### **Сравнение абсолютных и относительных координат**

Эти два объекта пути описывают один и тот же маршрут. Абсолютная команда заканчивается в (0.3, 0.1); относительная добавляет (0.1, 0.1) к текущей позиции, получая (0.2, 0).

Оба пути начинаются в одинаковой позиции. Для относительной линии добавьте её X и Y к текущей позиции, чтобы получить конечную точку; для абсолютной линии читайте конечную точку напрямую. Переключение флага без преобразования координат даст иной маршрут.

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

Назначьте любой из путей поведению движения, чтобы использовать его в презентации. Последний логический аргумент выбирает относительные координаты для этой команды.

### **Замена линии на кривую**

Откройте `motion.pptx` и замените её линию кубической кривой. Сначала укажите две контрольные точки, затем конечную точку.

Начальная позиция задаётся предыдущей командой. Первые две точки формируют кривую, третья — её конечную точку; это не три последовательные конечные точки. Обновление типа команды, типа редактирования точек и массива точек одновременно сохраняет согласованность сегмента с новой геометрией.

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

Путь в `curve.pptx` всё ещё имеет три команды; её средняя команда теперь определяет кривую.

## **Чтение и редактирование сохранённого пути**

Каждый [IMotionCmdPath](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotioncmdpath/) раскрывает [get_Points](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), и [get_IsRelative](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). Примеры ниже используют известный трёхкомандный путь в `motion.pptx`. Для произвольного ввода сначала найдите нужный эффект и проверьте типы команд и количество точек перед редактированием по индексу.

### **Чтение команд и координат**

Прочитайте путь без изменений. Команды End и CloseLoop не требуют точек, поэтому допускается массив точек = null.

Вывод сопоставляет каждую команду с её флагом относительных координат, а затем перечисляет её точки. Это позволяет отличить конечную точку от смещения перед модификацией пути. Кривая будет перечислять три точки, тогда как прямая линия в этом файле — только одну.

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

В списке есть начальная точка, абсолютная линия, заканчивающаяся в (0.25, 0), и команда End.

### **Изменение конечной точки**

Откройте `motion.pptx` и замените массив точек линии, чтобы переместить её конечную точку.

Во входном файле индекс 0 — начальная команда, индекс 1 — линия. Замена единственной точки линии меняет её конечную позицию, не меняя тип команды, тайминг или позицию в коллекции. Поскольку команда использует абсолютные координаты, новая пара указывает позицию, а не добавочный смещение.

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

Линия в `motion-endpoint.pptx` заканчивается в (0.4, 0.1); оригинальный файл остаётся неизменным.

### **Замена сегмента**

Используйте [Insert](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotionpath/insert/) и [RemoveAt](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/imotionpath/removeat/) для замены линии в `motion.pptx`. Вставка сдвигает старую линию к индексу 2.

Это демонстрирует замену объекта команды, а не редактирование её координат. После вставки коллекция временно содержит начальную команду, новую линию, старую линию и команду End. Удаление индекса 2 убирает старую линию, оставаясь с новым маршрутом.

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

Сохранённый путь всё ещё имеет три команды, с новой линией, заканчивающейся в (0.2, 0.1), и командой End последней.

## **Изменение и проверка существующего поведения**

Когда индекс поведения неизвестен, выбирайте его по типу. Этот пример открывает `rotation.pptx`, находит его [IRotationEffect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/irotationeffect/), меняет угол и проверяет сохранённое значение после повторного открытия.

Проверка типа позволяет пропускать поведения, не являющиеся вращениями. Второй запуск читает сохранённый файл в отдельный объект презентации, поэтому сравнение проверяет сохранённые данные, а не значение, оставшееся в памяти. Пример всё ещё предполагает, что известный эффект является первым в главной последовательности; выбор поведения по типу не гарантирует нахождение нужного эффекта в произвольной презентации.

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

Вывод: `Rotation preserved: True`. Применяйте тот же паттерн проверки типов к другим поведениями. Для полной проверки сохранения сравните целевую фигуру, эффект, типы и порядок поведений, тайминг и команды пути. Используйте числовой допуск для значений с плавающей точкой. Для презентации с неизвестной анимационной схемой см. [Чтение анимаций фигур](/slides/ru/cpp/shape-animation/#read-shape-animations).

## **Порядок поведений, пресеты и воспроизведение**

Порядок в [IBehaviorCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehaviorcollection/) — это сохранённый порядок операций эффекта. Это не плейлист, где каждое последующее поведение автоматически ждёт предыдущее. Тайминг и охватывающий эффект определяют планирование. Поведения могут накладываться, а операции над одним свойством могут взаимодействовать через [get_Additive](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehavior/get_additive/) и [get_Accumulate](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ibehavior/get_accumulate/). Не используйте только переупорядочивание коллекции для планирования «переместить, затем повернуть»; применяйте явный тайминг или отдельные эффекты, как описано в [Анимация фигур](/slides/ru/cpp/shape-animation/).

[IEffect::get_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/get_type/) и [IEffect::get_Subtype](https://reference.aspose.com/slides/ru/cpp/aspose.slides.animation/ieffect/get_subtype/) описывают его пресет. Это не полное описание отредактированного дерева поведений. Сначала выберите пресет и подтип, затем настраивайте поведения: изменение пресета может пересоздать коллекцию и удалить ваши пользовательские операции. Например, изменение кастомного эффекта Spin на Fade может заменить его поведение вращения на set и filter. После изменения пресета или подтипа вновь проверьте коллекцию. Очистка пресет‑поведений также может удалить операции видимости или инициализации, необходимые пресету. Примеры сознательно используют видимые фигуры и заменяют их поведения, не перестраивая полную реализацию каждого пресета.

## **Совместимость форматов**

Сохранённое дерево поведений не гарантирует одинаковое воспроизведение во всех просмотрщиках или экспортных рендерах. Проверяйте сохранённые данные и полученный вывод отдельно.

| Формат или вывод | Что проверять |
| --- | --- |
| PPTX | Используйте как основной формат для этих примеров. Откройте его снова, чтобы убедиться в сохранности редактируемого дерева поведений, затем проверьте воспроизведение в требуемой версии PowerPoint. |
| PPT | Устаревшее бинарное представление может отличаться от PPTX. Выполните отдельный цикл сохранить‑и‑открыть и проверьте воспроизведение; не делайте выводы о поддержке всех пользовательских комбинаций только из успешного вывода PPTX. |
| PDF, PNG, JPEG и другие статические изображения слайдов | Содержат статическое представление слайда, а не проигрываемую временную шкалу поведения или гарантированный конечный кадр анимации. |
| [HTML5](/slides/ru/cpp/export-to-html5/) | Может воспроизводить поддерживаемые анимации, если в параметрах экспорта включена анимация фигур. Тестируйте пользовательские комбинации в браузере. |
| [Animated GIF](/slides/ru/cpp/convert-powerpoint-to-animated-gif/) | Сохраняет отрендеренные кадры, а не редактируемые поведения или интерактивные триггеры. Проверьте фактическое отрисованное движение. |
| [Video](/slides/ru/cpp/convert-powerpoint-to-video/) | Рендерит кадры анимации и кодирует их в видео. Поддержка ограничена [поддерживаемыми анимациями и эффектами](/slides/ru/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) рендера; команды и интерактивные события не становятся редактируемой временной шкалой. |

## **FAQ**

**Почему мой эффект содержит поведения, хотя я ничего не добавлял?**

Создание предопределённого эффекта может создать его базовые операции. Просмотрите их, прежде чем решать, расширять пресет или заменять его поведения.

**Перемещает ли поведение в начало коллекции его в первую очередь?**

Не обязательно. Порядок коллекции не заменяет тайминг. Проверяйте задержки, длительности и взаимодействия между операциями над одним свойством.

**Почему команда End не имеет точек?**

Она обозначает конец пути и не требует координат. При проверке пути, прочитанного из файла, учитывайте возможность null‑массива точек.

**Достаточен ли успешный круговой проход для подтверждения воспроизведения?**

Нет. Открытие подтверждает сохранность проверяемых свойств. Тестируйте проигрыватель слайд‑шоу или анимированный экспорт отдельно, чтобы убедиться в визуальном поведении.