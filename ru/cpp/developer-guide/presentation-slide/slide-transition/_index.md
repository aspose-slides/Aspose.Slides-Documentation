---
title: "Управление переходами слайдов в презентациях с использованием C++"
linktitle: "Переход слайда"
type: docs
weight: 80
url: /ru/cpp/slide-transition/
keywords:
- "переход слайда"
- "добавить переход слайда"
- "применить переход слайда"
- "расширенный переход слайда"
- "переход Morph"
- "тип перехода"
- "эффект перехода"
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое продвижение слайдов и кастомизируйте Morph и другие эффекты переходов с помощью Aspose.Slides для C++."
---
## **Обзор**

Переходы слайдов управляют тем, как слайды появляются во время демонстрации. С помощью Aspose.Slides для C++ можно выбрать эффект перехода для каждого слайда, настроить переход по щелчку мыши или по таймеру и задать параметры, специфичные для эффекта. В этой статье используются примеры на C++ для применения переходов, установки точных длительностей переходов, управления временем показа слайдов и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавление перехода слайда**

Чтобы применить переход, загрузите презентацию с классом [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и получите доступ к настройкам перехода слайда через [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Вызовите [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) с значением из перечисления [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/), затем сохраните презентацию.

В следующем примере к первому слайду применяется переход Circle, а ко второму — Comb. Используйте файл `input.pptx` с как минимум двумя слайдами.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Переход Wheel**

Метод [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) интерфейса [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) задает количество радиальных секторов, раскрывающих целевой слайд. Вызовите [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) со значением Wheel из [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) перед доступом к [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) через [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/).

Этот пример создает две одинаковые пары слайдов: черный слайд, за которым следует слайд с золотым прямоугольником. В целевых слайдах используется количество спиц 1 и 8, с одинаковой скоростью, установленной через [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/), и явной длительностью 8 000 мс, установленной через [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/), чтобы разницу было легко увидеть.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Откройте полученную презентацию в PowerPoint и запустите демонстрацию. Перейдите слайда 1 к слайду 2, затем слайда 3 к слайду 4. При воспроизведении в PowerPoint проверенное значение спицы 1 раскрывает слайд одним вращением по часовой стрелке; значение 8 раскрывает его через восемь радиальных секторов одновременно. Содержание целевого слайда и время перехода одинаковы, поэтому различие заключается в количестве секторов раскрытия.

## **Добавление расширенного перехода слайда**

Можно настроить, как долго слайд остаётся на экране и будет ли щелчок мышью переключать демонстрацию. Следующие методы управляют этим поведением:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) позволяет зрителю переходить по щелчку мыши.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) включает автоматическое переключение.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) задаёт задержку перед автоматическим переходом в миллисекундах.

Включите оба способа — по щелчку и по таймеру — чтобы зритель мог перейти щелчком или ждать таймер. Чтобы использовать только таймер, вызовите [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) с `false`. Задержка определяет, когда демонстрация переходит к следующему слайду; она не задаёт длительность визуального эффекта перехода.

В этом примере разным эффектам присваиваются первые три слайда, а автоматическое переключение включается через 3, 5 и 7 секунд соответственно. Щелчки мышью также могут переключать эти слайды. Используйте файл `input.pptx` с минимум тремя слайдами.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

Чтобы проверить, включён ли таймер, вызовите [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Хранённая задержка сама по себе не указывает, что таймер активен.

Следующий пример открывает сохранённый выше файл, сообщает о каждом включённом таймере и отключает автоматическое переключение для слайдов с задержкой более двух секунд. Для этих слайдов включаются щелчки мышью, и сохранены обновлённые настройки.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Точное управление временем перехода**

Используйте [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) для указания точной длительности эффекта перехода в миллисекундах. Метод [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) слайда предоставляет эти настройки через интерфейс [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/):

| Метод | Назначение |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | Задаёт длительность самого эффекта перехода в миллисекундах. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Задаёт задержку перед автоматическим переходом слайда в миллисекундах. Вызовите [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) с `true`, чтобы активировать таймер. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) управляет только эффектом перехода; она не определяет, как долго слайд остаётся видимым. Задержку автоматического переключения следует настраивать отдельно. Если явная длительность не указана, Aspose.Slides определяет длительность эффекта исходя из типа перехода и значения, возвращаемого [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/).

<!-- visual-explanation:slide-transition:start -->
[![Отдельные полосы показывают длительность перехода 750 мс и установку автоматического переключения 5 000 мс.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Пример демонстрирует, что каждый слайд имеет 750‑мс переход Fade и отдельно включён автоматический переход через 5 000 мс. Длительность перехода управляет эффектом; автоматическое переключение управляет моментом выхода со слайда. Эти полосы являются схематичными настройками, а не измеренной комбинированной шкалой времени.*
<!-- visual-explanation:slide-transition:end -->

### **Применить одинаковую длительность ко всем слайдам**

Для единообразного темпа примените один и тот же эффект и точную длительность к каждому слайду. Этот пример загружает `input.pptx`, выбирает Fade из [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/), задаёт каждой переходу длительность 750 мс, отдельно включает автоматическое переключение через 5 000 мс и отключает переключение по щелчку мыши, затем сохраняет результат в PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // Настройте автоматическое продвижение независимо от длительности эффекта.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Установить разные длительности для отдельных слайдов**

Разные слайды могут использовать разные длительности эффектов. Например, короткий переход для титульного слайда и более длительный для вводного слайда раздела. Этот пример задаёт 500 мс для первого слайда и 1 200 мс для второго. Используйте файл `input.pptx` с минимум двумя слайдами.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Синхронизация переходов с анимированным выводом**

При подготовке [анимированного GIF](/slides/ru/cpp/convert-powerpoint-to-animated-gif/), [HTML5‑презентации](/slides/ru/cpp/export-to-html5/) или [видео](/slides/ru/cpp/convert-powerpoint-to-video/) задавайте точные длительности переходов перед экспортом, чтобы соответствовать заданному темпу. Например, используйте 600‑мс fade между сценами и отдельно регулируйте задержку перехода каждого слайда, чтобы дать время для озвучки или контента.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствуют 18 кадрам при 30 fps. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры времени выбранного формата и предварительно просмотрите результат для подтверждения синхронизации.

### **Чтение существующей длительности перехода**

Вызовите [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и значение, возвращаемое [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/), чтобы определить эту длительность. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте исходные настройки.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Переход Morph**

Переход Morph анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой эффект Morph, склонируйте слайд, переместите или измените размер объекта в копии и примените переход Morph ко второму слайду. Это даёт возможность анимировать соответствующие объекты между их исходным и изменённым состоянием.

В следующем примере создаётся слайд с прямоугольником текста, затем этот слайд клонируется, и позиция и размер прямоугольника изменяются в клоне. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/). Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время демонстрации.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Типы перехода Morph**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) управляет тем, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) рассматривает каждую форму как единый объект.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя слова, где это возможно.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя отдельные символы, где это возможно.

Вызовите [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) с Morph перед доступом к [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/). Затем полученный объект предоставляет интерфейс [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/), метод [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) которого выбирает режим сопоставления.

Этот пример открывает презентацию, созданную в предыдущем разделе, и настраивает второй слайд на анимацию Morph по словам.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Установка эффектов перехода**

Некоторые переходы предоставляют дополнительные параметры, такие как направление или начало эффекта из чёрного экрана. Доступные параметры зависят от выбранного типа перехода. Сначала задайте тип, затем используйте соответствующий интерфейс, возвращаемый [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/).

В следующем примере применяется переход Cut к первому слайду `input.pptx`. Он вызывает [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) с `true` через [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/), чтобы переход начинался с чёрного экрана.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **FAQ**

**Можно ли управлять скоростью воспроизведения перехода слайда?**

Да. Предпочтительно использовать [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/), когда требуется точная длительность эффекта в миллисекундах. Используйте [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/), если достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) — Slow, Medium или Fast — и явная длительность не задаётся. Эти настройки управляют только эффектом перехода, независимо от задержки автоматического переключения.

**Можно ли добавить звук к переходу и заставить его зацикливаться?**

Да. Назначьте встроенный звук с помощью [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/), вызовите [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) с `StartSound` из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) и включите зацикливание через [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/). Звук будет повторяться до следующего звукового события в демонстрации.

**Как быстрее всего применить один и тот же переход ко всем слайдам?**

Пройдитесь циклом по коллекции, возвращаемой методом [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) презентации, и вызовите [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) с одинаковым значением для перехода каждого слайда. Установите любые параметры времени и эффекта в том же цикле, чтобы поведение было согласованным на всех слайдах.

**Как проверить, какой переход установлен на текущем слайде?**

Вызовите [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) у перехода, полученного методом [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) слайда. Метод вернёт значение из перечисления [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/); `None` означает, что переход не задан.