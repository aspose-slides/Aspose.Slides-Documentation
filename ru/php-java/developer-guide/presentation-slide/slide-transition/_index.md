---
title: Управление переходами слайдов в презентациях с использованием PHP
linktitle: Переход слайда
type: docs
weight: 80
url: /ru/php-java/slide-transition/
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
- PHP
- Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое продвижение слайдов и кастомизируйте переход Morph и другие эффекты переходов с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Переходы слайдов управляют тем, как слайды появляются во время показа. С помощью Aspose.Slides для PHP через Java можно выбрать эффект перехода для каждого слайда, настроить продвижение по щелчку мыши или таймеру и отрегулировать параметры, специфичные для эффекта. В этой статье используются примеры PHP для применения переходов, установки точных длительностей переходов, управления временем показа слайдов и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавление перехода слайда**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и получите доступ к настройкам перехода слайда через [getSlideShowTransition](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/#getSlideShowTransition). Используйте [setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setType) со значением из перечисления [TransitionType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/transitiontype/), затем сохраните презентацию.

В следующем примере применяется переход Circle к первому слайду и переход Comb ко второму. Используйте файл `input.pptx` минимум с двумя слайдами.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Добавление расширенного перехода слайда**

Можно настроить, как долго слайд остается на экране и будет ли щелчок мыши продвигать показ слайдов. Следующие методы управляют этим поведением:

- [setAdvanceOnClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) позволяет пользователю продвигать слайд щелчком мыши.
- [setAdvanceAfter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) включает автоматическое продвижение.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) задает задержку перед автоматическим продвижением в миллисекундах.

Включите одновременно щелчок и таймер, чтобы пользователь мог перейти по щелчку или подождать таймер. Чтобы использовать только таймер, передайте `false` в [setAdvanceOnClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Задержка управляет моментом продвижения показа, но не задаёт длительность визуального эффекта перехода.

В этом примере различным слайдам назначаются разные эффекты, а автоматическое продвижение включается после 3, 5 и 7 секунд соответственно. По щелчку мыши эти слайды также могут продвигаться. Используйте файл `input.pptx` минимум с тремя слайдами.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Чтобы проверить, включено ли автоматическое продвижение по таймеру, вызовите [getAdvanceAfter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Хранение задержки само по себе не указывает, что таймер активен.

Следующий пример открывает файл, сохранённый выше, выводит информацию о каждом включённом таймере и отключает автоматическое продвижение для слайдов с задержкой более двух секунд. Для этих слайдов включается щелчок мышью, после чего настройки сохраняются.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Точное управление временем перехода**

Используйте [setDuration](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setDuration) для указания точной длительности эффекта перехода в миллисекундах. Метод [getSlideShowTransition](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/#getSlideShowTransition) слайда предоставляет доступ к этим настройкам через [SlideShowTransition](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/):

| Метод | Назначение |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setDuration) | Устанавливает длительность самих эффектов перехода в миллисекундах. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Задает задержку перед автоматическим продвижением слайда в миллисекундах. Передайте `true` в [setAdvanceAfter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter), чтобы активировать таймер. |
| [setSpeed](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setSpeed) | Выбирает предустановленную категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/ru/php-java/aspose.slides/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[setDuration](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setDuration) управляет только эффектом перехода; она не определяет, как долго слайд остаётся видимым. Задержку автоматического продвижения настраивайте отдельно. Если явная длительность не задана, Aspose.Slides определяет её из типа перехода и значения [getSpeed](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#getSpeed).

### **Применить одинаковую длительность ко всем слайдам**

Для согласованного темпа примените один и тот же эффект и точную длительность ко всем слайдам. Этот пример загружает `input.pptx`, выбирает Fade из [TransitionType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/transitiontype/) и задаёт каждой анимации длительность 750 миллисекунд. Затем он отдельно включает автоматическое продвижение после 5 000 миллисекунд и отключает продвижение щелчком мыши, после чего сохраняет результат в PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // Настройте автоматическое продвижение независимо от длительности эффекта.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Установка разных длительностей для отдельных слайдов**

Разные слайды могут использовать разные длительности эффектов. Например, можно задать короткий переход для титульного слайда и более длительный для введения раздела. Этот пример задаёт 500 мс для первого слайда и 1 200 мс для второго. Используйте файл `input.pptx` минимум с двумя слайдами.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Координация переходов с анимированным выводом**

При подготовке [анимированного GIF](/slides/ru/php-java/convert-powerpoint-to-animated-gif/), [презентации HTML5](/slides/ru/php-java/export-to-html5/) или [видео](/slides/ru/php-java/convert-powerpoint-to-video/), установите точные длительности переходов перед экспортом, чтобы соответствовать задуманному темпу. Например, используйте 600‑мс плавное исчезание между сценами и отдельно настройте задержку продвижения каждого слайда, чтобы обеспечить время для озвучки или контента.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствуют 18 кадрам при 30 fps. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и варианты таймингов выбранного формата и предварительно просмотрите результат для подтверждения синхронизации.

### **Чтение существующей длительности перехода**

Вызовите [getDuration](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#getDuration) до изменения перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не установлена; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и значение [getSpeed](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#getSpeed) для её расчёта. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте исходные настройки.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Переход Morph**

Переход Morph анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой эффект Morph, склонируйте слайд, переместите или измените размер объекта в копии и примените переход Morph ко второму слайду. Это даёт возможность анимировать соответствующие объекты между их исходным и изменённым состоянием.

В следующем примере создаётся слайд с текстовым прямоугольником, копируется, а в копии меняются позиция и размер прямоугольника. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/transitiontype/). Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время показа.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Типы перехода Morph**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/transitionmorphtype/) определяет, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/ru/php-java/aspose.slides/transitionmorphtype/#ByObject) рассматривает каждую форму как единый объект.
- [ByWord](https://reference.aspose.com/slides/ru/php-java/aspose.slides/transitionmorphtype/#ByWord) анимирует текст, сопоставляя слова, где это возможно.
- [ByChar](https://reference.aspose.com/slides/ru/php-java/aspose.slides/transitionmorphtype/#ByChar) анимирует текст, сопоставляя символы, где это возможно.

Используйте [setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setType) для выбора Morph перед вызовом [getValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#getValue). Полученное значение предоставляет объект [MorphTransition](https://reference.aspose.com/slides/ru/php-java/aspose.slides/morphtransition/), у которого метод [setMorphType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/morphtransition/#setMorphType) выбирает режим сопоставления.

В этом примере открывается презентация, созданная в предыдущем разделе, и настраивается второй слайд для анимации Morph на уровне слов.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Установка эффектов перехода**

Некоторые переходы раскрывают дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от выбранного перехода через [setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setType). Сначала задайте тип, затем используйте соответствующий объект перехода, полученный через [getValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#getValue).

В следующем примере применяется переход Cut к первому слайду `input.pptx`. Через [OptionalBlackTransition](https://reference.aspose.com/slides/ru/php-java/aspose.slides/optionalblacktransition/) вызывается [setFromBlack](https://reference.aspose.com/slides/ru/php-java/aspose.slides/optionalblacktransition/#setFromBlack), чтобы переход начинался с чёрного экрана.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Можно ли управлять скоростью воспроизведения перехода слайда?**

Да. Предпочтительно используйте [setDuration](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setDuration), когда нужна точная длительность эффекта в миллисекундах. Используйте [setSpeed](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setSpeed), когда достаточно предустановленной категории [TransitionSpeed](https://reference.aspose.com/slides/ru/php-java/aspose.slides/transitionspeed/) — Slow, Medium или Fast, и явная длительность не задаётся. Эти настройки управляют только эффектом перехода, независимо от задержки автоматического продвижения.

**Можно ли прикрепить звук к переходу и зациклить его?**

Да. Присвойте встроенный звук с помощью [setSound](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setSound), передайте `StartSound` из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/ru/php-java/aspose.slides/transitionsoundmode/) в [setSoundMode](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setSoundMode) и включите [setSoundLoop](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setSoundLoop) со значением `true`. Звук будет зацикливаться до следующего звукового события в показе.

**Как быстрее всего применить один и тот же переход ко всем слайдам?**

Пройдите в цикле коллекцию слайдов презентации через [getSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSlides) и вызовите [setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#setType) с одинаковым значением для перехода каждого слайда. Установите любые параметры времени и эффекта в том же цикле, чтобы поведение оставалось одинаковым для всех слайдов.

**Как проверить, какой переход сейчас установлен на слайде?**

Вызовите [getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideshowtransition/#getType) у результата [getSlideShowTransition](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/#getSlideShowTransition) слайда. Он вернёт значение из перечисления [TransitionType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/transitiontype/); `None` означает, что переход не применяется.