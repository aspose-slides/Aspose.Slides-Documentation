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
- переход morph
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое продвижение слайдов и кастомизируйте переходы Morph и другие эффекты переходов с помощью Aspose.Slides для C++."
---
## **Обзор**

Переходы слайдов управляют тем, как слайды отображаются во время показа слайдов. С помощью Aspose.Slides для C++ вы можете выбирать эффект перехода для каждого слайда, настраивать переход по щелчку мыши или таймеру и корректировать параметры, специфичные для эффекта. В этой статье используются примеры на C++ для применения переходов, установки точных продолжительностей переходов, управления временем показа слайдов и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавить переход к слайду**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и получите доступ к настройкам перехода слайда через [get_SlideShowTransition](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Вызовите [set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_type/) с значением из перечисления [TransitionType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/transitiontype/), затем сохраните презентацию.

В следующем примере применяется переход Circle к первому слайду и переход Comb ко второму. Используйте файл `input.pptx` с как минимум двумя слайдами.

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

## **Добавить расширенный переход слайда**

- [set_AdvanceOnClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) позволяет зрителю переходить, щелкнув мышью.  
- [set_AdvanceAfter](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_advanceafter/) включает автоматический переход.  
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) задаёт задержку перед автоматическим переходом в миллисекундах.

Включите как щелчок, так и автоматический переход по таймеру, чтобы зритель мог перейти по щелчку мыши или ждать таймер. Чтобы использовать только таймер, вызовите [set_AdvanceOnClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) с `false`. Задержка определяет, когда шоу будет переходить; она не задаёт длительность визуального эффекта перехода.

В этом примере различным эффектам присваиваются первые три слайда, и включается автоматический переход через 3, 5 и 7 секунд соответственно. Щелчки мышью также могут переходить эти слайды. Используйте файл `input.pptx` с как минимум тремя слайдами.

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

Чтобы проверить, включён ли автоматический переход по таймеру, вызовите [get_AdvanceAfter](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Хранимая задержка сама по себе не указывает, что таймер активен.

Следующий пример открывает ранее сохранённый файл, сообщает о каждом включённом таймере и отключает автоматический переход для слайдов с задержкой более двух секунд. Для этих слайдов включаются щелчки мышью, после чего сохраняются обновлённые настройки.

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

## **Точно контролировать время перехода**

Используйте [set_Duration](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_duration/) чтобы задать точную длительность эффекта перехода в миллисекундах. Метод [get_SlideShowTransition](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) у слайда предоставляет эти настройки через [ISlideShowTransition](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/):

| Метод | Назначение |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_duration/) | Устанавливает длительность самого эффекта перехода в миллисекундах. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Задает задержку перед автоматическим переходом слайда в миллисекундах. Вызовите [set_AdvanceAfter](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_advanceafter/) с `true` чтобы активировать этот таймер. |
| [set_Speed](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_speed/) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[set_Duration](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_duration/) контролирует только эффект перехода; он не определяет, как долго слайд остаётся видимым. Настройте задержку автоматического перехода отдельно. Когда явная длительность не задана, Aspose.Slides определяет длительность эффекта по типу перехода и значению, возвращаемому [get_Speed](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/get_speed/).

### **Применить одинаковую длительность ко всем слайдам**

Для последовательного темпа примените одинаковый эффект и точную длительность ко всем слайдам. Этот пример загружает `input.pptx`, выбирает Fade из [TransitionType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/transitiontype/), и задаёт каждой переходу длительность 750 миллисекунд. Отдельно включается автоматический переход спустя 5 000 миллисекунд и отключается переход по щелчку мыши, после чего результат сохраняется в формате PPTX.

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

Разные слайды могут использовать разные длительности эффектов. Например, используйте короткий переход для титульного слайда и более длительный переход для введения раздела. Этот пример задаёт 500 миллисекунд для первого слайда и 1 200 миллисекунд для второго. Используйте файл `input.pptx` с как минимум двумя слайдами.

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

### **Скоординировать переходы с анимированным выводом**

При подготовке [анимированного GIF](/slides/ru/cpp/convert-powerpoint-to-animated-gif/), [презентации HTML5](/slides/ru/cpp/export-to-html5/) или [видео](/slides/ru/cpp/convert-powerpoint-to-video/), задайте точные длительности переходов перед экспортом, чтобы соответствовать задуманному темпу. Например, используйте плавный переход в 600 миллисекунд между сценами и отдельно настраивайте задержку перехода каждого слайда, чтобы обеспечить время для озвучки или контента.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 миллисекунд соответствует 18 кадрам при 30 кадрах в секунду. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры времени выбранного формата экспорта и просмотрите результат, чтобы убедиться в синхронизации.

### **Прочитать существующую длительность перехода**

Вызовите [get_Duration](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/get_duration/) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и значение, возвращаемое [get_Speed](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/get_speed/), чтобы определить эту длительность. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте исходные настройки.

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

Переход Morph анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой эффект Morph, клонируйте слайд, переместите или измените размер объекта в клоне и примените переход Morph ко второму слайду. Это позволяет анимировать соответствующие объекты между их исходным и изменённым состоянием.

В следующем примере создаётся слайд с текстовым прямоугольником, клонируется слайд и изменяется позиция и размер прямоугольника в клоне. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/transitiontype/). Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время показа слайдов.

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

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/transitionmorphtype/) задаёт, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/transitionmorphtype/) рассматривает каждую форму как отдельный объект.  
- [ByWord](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя слова, где это возможно.  
- [ByChar](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/transitionmorphtype/) анимирует текст, сопоставляя символы, где это возможно.

Вызовите [set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_type/) с Morph перед обращением к [get_Value](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/get_value/). Затем полученное значение предоставляет интерфейс [IMorphTransition](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/imorphtransition/), у которого метод [set_MorphType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) выбирает режим сопоставления.

В этом примере открывается презентация, созданная в предыдущем разделе, и настраивается второй слайд для использования морф‑анимации по словам.

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

## **Установить эффекты перехода**

Некоторые переходы предоставляют дополнительные параметры, например направление или старт из чёрного экрана. Доступные параметры зависят от выбранного типа перехода. Сначала задайте тип, затем используйте соответствующий интерфейс, возвращаемый [get_Value](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/get_value/).

В следующем примере к первому слайду `input.pptx` применяется переход Cut. Он вызывает [set_FromBlack](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) с `true` через [IOptionalBlackTransition](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/ioptionalblacktransition/), чтобы переход начинался с чёрного экрана.

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

Да. Предпочтительно использовать [set_Duration](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_duration/), когда требуется точная длительность эффекта в миллисекундах. Используйте [set_Speed](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_speed/), когда достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/transitionspeed/) — Slow, Medium или Fast, и явная длительность не задаётся. Эти настройки управляют эффектом перехода независимо от задержки автоматического перехода.

**Можно ли прикрепить аудио к переходу и заставить его зацикливаться?**

Да. Присвойте встроенный звук с помощью [set_Sound](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_sound/), вызовите [set_SoundMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_soundmode/) с параметром StartSound из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/transitionsoundmode/) и включите зацикливание с помощью [set_SoundLoop](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_soundloop/). Аудио будет повторяться до следующего звукового события в показе слайдов.

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Пройдите циклом по коллекции, возвращаемой методом [get_Slides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_slides/) презентации, и вызовите [set_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/set_type/) с тем же значением для перехода каждого слайда. Установите любые параметры времени и эффекта в том же цикле, чтобы поведение было согласованным на всех слайдах.

**Как проверить, какой переход в данный момент установлен на слайде?**

Вызовите [get_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideshowtransition/get_type/) у перехода, полученного методом [get_SlideShowTransition](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) слайда. Он возвращает значение из перечисления [TransitionType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.slideshow/transitiontype/); None означает, что переход не применён.