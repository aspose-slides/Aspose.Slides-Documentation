---
title: Управление переходами слайдов в презентациях с помощью C++
linktitle: Переход слайда
type: docs
weight: 80
url: /ru/cpp/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- применить переход слайда
- расширенный переход слайда
- переход Morph
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое продвижение слайдов и кастомизируйте переход Morph и другие эффекты переходов с помощью Aspose.Slides для C++."
---
## **Обзор**

Переходы слайдов управляют тем, как слайды отображаются во время показа. С помощью Aspose.Slides для C++ вы можете выбирать эффект перехода для каждого слайда, настраивать продвижение по щелчку мыши или таймеру и корректировать параметры, специфичные для эффекта. В этой статье используются примеры на C++, показывающие, как применять переходы, задавать точную длительность перехода, управлять временем отображения слайдов и создавать переход Morph между двумя слайдами. Примеры также показывают, как сохранять настройки в файл PPTX.

## **Добавить переход к слайду**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и получите настройки перехода слайда через [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Вызовите [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) с значением из перечисления [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/), затем сохраните презентацию.

В следующем примере применяется переход Circle для первого слайда и переход Comb для второго. Используйте файл `input.pptx` с как минимум двумя слайдами.

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

Метод [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) интерфейса [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) управляет числом радиальных секторов, которые раскрывают целевой слайд. Вызовите [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) с параметром Wheel из [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) перед тем как получить [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) как [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/).

Этот пример создаёт две одинаковые пары слайдов: чёрный слайд, за которым следует слайд с золотым прямоугольником. В целевых слайдах используется количество спиц 1 и 8, при этом одинаковая скорость задаётся через [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) и явная длительность 8 000 мс задаётся через [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/), чтобы различие было легко заметить.

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

Откройте получившуюся презентацию в PowerPoint и запустите показ слайдов. Перейдите со слайда 1 на слайд 2, затем со слайда 3 на слайд 4. При воспроизведении в PowerPoint проверенное значение спиц 1 раскрывает слайд одним вращением по часовой стрелке; проверенное значение 8 раскрывает его восемью радиальными секторами одновременно. Содержимое целевых слайдов и время перехода одинаковы, различие только в числе раскрывающих секторов.

## **Fade Through Black с переходом Reveal**

Установите тип перехода целевого слайда в Reveal, затем вызовите [set_ThroughBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/set_throughblack/) на интерфейсе [IRevealTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/). Пример создаёт бирюзовый исходный слайд и коралловый целевой слайд, затем клонирует оба, чтобы можно было сравнить один и тот же двухсекундный переход с отключённым и включённым затемнением.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/SlideShowTransition/IRevealTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionLeftRightDirectionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto styleSlide = [](SharedPtr<ISlide> slide, Color background, const String& label)
{
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
    auto fill = slide->get_Background()->get_FillFormat();
    fill->set_FillType(FillType::Solid);
    fill->get_SolidFillColor()->set_Color(background);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(label);
    textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_FontHeight(44);
};

auto presentation = MakeObject<Presentation>();

auto source = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddClone(source);
styleSlide(source, Color::get_Teal(), u"Source");
styleSlide(destination, Color::get_Coral(), u"Destination");
presentation->get_Slides()->AddClone(source);
presentation->get_Slides()->AddClone(destination);

for (auto index : {1, 3})
{
    auto transition = presentation->get_Slide(index)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Reveal);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(2000);

    auto reveal = ExplicitCast<IRevealTransition>(transition->get_Value());
    reveal->set_Direction(TransitionLeftRightDirectionType::Left);
    reveal->set_ThroughBlack(index == 3);
}

presentation->Save(u"reveal-transitions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

В показе PowerPoint перейдите со слайда 1 на слайд 2. Бирюзовый слайд плавно переходит в коралловый. Затем перейдите со слайда 3 на слайд 4. Экран кратко затемняется почти до чёрного, после чего появляется коралловый слайд. Оба слайда сохраняют свои первоначальные цвета фона.

Ниже показаны кадры из PowerPoint с интервалом полсекунды. Сравните средний кадр в каждой строке, чтобы увидеть эффект настройки.

![Воспроизведение PowerPoint с отключённым ThroughBlack (верх) и включённым (низ). Только нижняя строка проходит через почти чёрный цвет.](reveal-through-black.png)

## **Добавить расширенный переход слайда**

Вы можете настроить, как долго слайд остаётся на экране и будет ли щелчок мышью продвигать показ. Следующие методы управляют этим поведением:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) позволяет зрителю переходить по щелчку мыши.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) включает автоматическое продвижение.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) задаёт задержку перед автоматическим продвижением в миллисекундах.

Включите как щелчок, так и таймер, чтобы зритель мог перейти по щелчку или ждать таймер. Чтобы использовать только таймер, вызовите [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) с `false`. Задержка управляет моментом продвижения показа; она не определяет длительность визуального эффекта перехода.

Этот пример назначает разные эффекты первым трём слайдам и включает автоматическое продвижение через 3, 5 и 7 секунд соответственно. Щелчки мышью также могут продвигать эти слайды. Используйте файл `input.pptx` с как минимум тремя слайдами.

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

Чтобы проверить, включено ли автоматическое продвижение по таймеру, вызовите [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Одно лишь сохранённое значение задержки не указывает, что таймер активен.

Следующий пример открывает файл, сохранённый выше, сообщает о каждом включённом таймере и отключает автоматическое продвижение для слайдов с задержкой более двух секунд. Для этих слайдов включаются щелчки мышью, после чего настройки сохраняются.

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

## **Точно управлять временем перехода**

Используйте [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) для указания точной длительности эффекта перехода в миллисекундах. Метод [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) слайда раскрывает эти настройки через интерфейс [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/):

| Метод | Назначение |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | Устанавливает длительность самого эффекта перехода в миллисекундах. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Задаёт задержку перед автоматическим переходом слайда в миллисекундах. Вызовите [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) с `true`, чтобы активировать таймер. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не задана. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) управляет только эффектом перехода; она не определяет, как долго слайд остаётся видимым. Настройку задержки автоматического продвижения следует задавать отдельно. Если явная длительность не указана, Aspose.Slides определяет длительность эффекта по типу перехода и значению, возвращаемому [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/).

<!-- visual-explanation:slide-transition:start -->
[![Отдельные полосы показывают длительность перехода 750 мс и настройку автоматического продвижения 5 000 мс.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Пример демонстрирует, что каждому слайду задаётся 750‑мс переход Fade и отдельно включается автоматическое продвижение через 5 000 мс. Длительность перехода управляет эффектом; продвижение определяет, когда покинуть слайд. Эти полосы являются схематичными настройками, а не измеренной объединённой временной шкалой.*
<!-- visual-explanation:slide-transition:end -->

### **Применить одинаковую длительность ко всем слайдам**

Для одинакового темпа примените одинаковый эффект и точную длительность ко всем слайдам. Этот пример загружает `input.pptx`, выбирает Fade из [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) и задаёт каждой переходу длительность 750 мс. Отдельно включается автоматическое продвижение через 5 000 мс и отключается продвижение щелчком мыши, после чего результат сохраняется в PPTX.

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

### **Задать разные длительности для отдельных слайдов**

Разные слайды могут использовать разные длительности эффектов. Например, используйте короткий переход для титульного слайда и более длительный для ввода раздела. Этот пример задаёт 500 мс для первого слайда и 1 200 мс для второго. Используйте файл `input.pptx` с как минимум двумя слайдами.

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

### **Координировать переходы с анимированным выводом**

При подготовке [анимированного GIF](/slides/ru/cpp/convert-powerpoint-to-animated-gif/), [HTML5‑презентации](/slides/ru/cpp/export-to-html5/) или [видео](/slides/ru/cpp/convert-powerpoint-to-video/), задавайте точные длительности переходов перед экспортом, чтобы соответствовать задуманному темпу. Например, используйте 600‑мс затухание между сценами и отдельно корректируйте задержку продвижения каждого слайда, чтобы оставить время для озвучки или содержимого.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствует 18 кадрам при 30 fps. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры времени выбранного формата экспорта и просмотрите результат, чтобы убедиться в синхронизации.

### **Прочитать существующую длительность перехода**

Вызовите [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) до изменения перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и значение, возвращаемое [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/), чтобы определить эту длительность. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте оригинальные настройки.

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

Переход Morph анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой эффект Morph, клонируйте слайд, переместите или измените размер объекта на клоне и примените переход Morph ко второму слайду. Это даёт анимировать соответствующие объекты между их исходным и изменённым состояниями.

Следующий пример создаёт слайд с текстовым прямоугольником, клонирует его и изменяет позицию и размер прямоугольника на клоне. Затем выбирает Morph из перечисления [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) для второго слайда. Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время показа.

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

## **Типы переходов Morph**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) управляет тем, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) обрабатывает каждую форму как единый объект.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя слова, где это возможно.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя символы, где это возможно.

Вызовите [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) с Morph перед доступом к [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/). Затем полученный объект предоставляет интерфейс [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/), метод [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) которого выбирает режим сопоставления.

Этот пример открывает презентацию, созданную в предыдущем разделе, и настраивает второй слайд для анимации Morph на основе слов.

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

## **Установить эффекты переходов**

Некоторые переходы раскрывают дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от выбранного типа перехода. Сначала задайте тип, затем используйте соответствующий интерфейс, полученный через [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/).

Следующий пример применяет переход Cut к первому слайду `input.pptx`. Он вызывает [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) с `true` через [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/), чтобы переход начинался с чёрного экрана.

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

Да. Предпочтительно использовать [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/), когда нужна точная длительность эффекта в миллисекундах. Используйте [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/), если достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) — Slow, Medium или Fast — и явная длительность не задаётся. Эти настройки управляют только эффектом перехода, независимо от задержки автоматического продвижения.

**Можно ли прикрепить аудио к переходу и заставить его зацикливаться?**

Да. Назначьте встроенное аудио с помощью [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/), вызовите [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) с параметром StartSound из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) и включите зацикливание через [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/). Аудио будет зацикливаться до следующего звукового события в показе.

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Пройдите в цикле коллекцию, возвращаемую методом [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) презентации, и вызовите [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) с одинаковым значением для перехода каждого слайда. Установите любые параметры времени и эффекта в том же цикле, чтобы поведение было одинаковым на всех слайдах.

**Как проверить, какой переход установлен на текущем слайде?**

Вызовите [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) у перехода, полученного через метод [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) слайда. Метод вернёт значение из перечисления [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/); None означает, что переход не задан.