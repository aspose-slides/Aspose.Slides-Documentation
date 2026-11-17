---
title: Управление переходами слайдов в презентациях с помощью PHP
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
description: "Применяйте переходы слайдов, настраивайте автоматическое продвижение слайдов и настраивайте Morph и другие эффекты переходов с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Переходы слайдов контролируют, как слайды появляются во время показа слайдов. С помощью Aspose.Slides для PHP через Java вы можете выбрать эффект перехода для каждого слайда, настроить его продвижение по щелчку мыши или таймеру и скорректировать параметры, специфичные для эффекта. В этой статье используются примеры на PHP для применения переходов, установки точных длительностей переходов, управления временем показа слайда и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавить переход слайда**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и получите доступ к настройкам перехода слайда через [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Используйте [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) со значением из перечисления [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), затем сохраните презентацию.

В приведённом примере к первому слайду применяется переход Circle, а ко второму — переход Comb. Используйте файл `input.pptx` минимум с двумя слайдами.

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

## **Wheel Transition**

Метод [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) определяет, сколько радиальных секторов будет раскрывать целевой слайд. Используйте [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) для выбора Wheel из [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), затем вызовите [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) для доступа к настройкам [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

Пример создаёт две одинаковые пары слайдов. Каждая пара начинается чёрным слайдом и заканчивается слайдом, покрытым золотым прямоугольником. Слайд 2 использует одну спицу, а слайд 4 — восемь. Оба перехода используют одну и ту же медленную скорость, задаваемую через [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), и явную длительность 8 000 миллисекунд, задаваемую через [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Откройте сохранённую презентацию в PowerPoint и запустите показ слайдов. Перейдите со слайда 1 на слайд 2, чтобы увидеть одно вращение по часовой стрелке. Затем перейдите со слайда 3 на слайд 4, чтобы увидеть восемь радиальных секторов, раскрывающих один и тот же прямоугольник одновременно.

## **Добавить расширенный переход слайда**

Вы можете настроить, как долго слайд остаётся на экране и будет ли щелчок мыши продвигать показ слайдов. Следующие методы управляют этим поведением:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) позволяет зрителю переходить по щелчку мыши.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) включает автоматическое продвижение.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) задаёт задержку перед автоматическим продвижением в миллисекундах.

Включите оба типа продвижения, чтобы зритель мог перейти щелчком мыши или подождать таймер. Чтобы использовать только таймер, передайте `false` в [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Задержка управляет моментом продвижения показа; она не задаёт длительность визуального эффекта перехода.

В этом примере разным первым трем слайдам назначаются разные эффекты, а автоматическое продвижение включается через 3, 5 и 7 секунд соответственно. Щелчки мышью также могут продвигать эти слайды. Используйте файл `input.pptx` минимум с тремя слайдами.

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

Чтобы проверить, включено ли автоматическое продвижение, вызовите [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Хранится лишь задержка, без указания активности таймера.

Следующий пример открывает файл, сохранённый выше, сообщает о каждом включённом таймере и отключает автоматическое продвижение для слайдов с задержкой более двух секунд. Для этих слайдов включает щелчок мышью и сохраняет обновлённые настройки.

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

## **Точно контролировать время перехода**

Используйте [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) для указания точной длительности эффекта перехода в миллисекундах. Метод [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) слайда раскрывает эти настройки через объект [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Метод | Назначение |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Устанавливает длительность самого эффекта перехода в миллисекундах. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Задает задержку перед автоматическим продвижением слайда в миллисекундах. Передайте `true` в [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter), чтобы активировать этот таймер. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) управляет только эффектом перехода; он не определяет, как долго слайд остаётся видимым. Задержку автоматического продвижения следует настраивать отдельно. Если явная длительность не задана, Aspose.Slides определяет её исходя из типа перехода и значения [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Отдельные полосы указывают длительность перехода 750 мс и параметр автоматического продвижения 5 000 мс.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*В данном примере каждому слайду задаётся переход Fade длительностью 750 мс и отдельно включается автоматическое продвижение через 5 000 мс. Длительность перехода управляет эффектом; продвижение определяет, когда покидать слайд. Эти полосы являются схематичными настройками, а не измеренной общей временной шкалой.*  
<!-- visual-explanation:slide-transition:end -->

### **Применить одинаковую длительность ко всем слайдам**

Для единообразного темпа примените один и тот же эффект и точную длительность ко всем слайдам. В этом примере загружается `input.pptx`, выбирается Fade из [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), и каждой переходу задаётся длительность 750 миллисекунд. Отдельно включается автоматическое продвижение через 5 000 миллисекунд и отключается продвижение щелчком мыши, после чего результат сохраняется в PPTX.

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

### **Установить разные длительности для отдельных слайдов**

Разные слайды могут использовать разные длительности эффектов. Например, используйте короткий переход для титульного слайда и более длительный для вступления в раздел. В этом примере первая задержка задаётся в 500 мс, а вторая — 1 200 мс. Используйте файл `input.pptx` минимум с двумя слайдами.

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

### **Скоординировать переходы с анимированным выводом**

При подготовке [анимированного GIF](/slides/ru/php-java/convert-powerpoint-to-animated-gif/), [презентации HTML5](/slides/ru/php-java/export-to-html5/) или [видео](/slides/ru/php-java/convert-powerpoint-to-video/) задайте точные длительности переходов перед экспортом, чтобы они соответствовали требуемому темпу. Например, используйте плавный переход Fade длительностью 600 мс между сценами и отдельно задайте задержку автоматического продвижения каждого слайда, чтобы было время для озвучки или содержания.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствуют 18 кадрам при 30 кадрах в секунду. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры времени выбранного формата экспорта и просмотрите результат, чтобы убедиться в синхронизации.

### **Прочитать существующую длительность перехода**

Вызовите [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) до изменения перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение — это не рассчитываемая длительность воспроизведения: Aspose.Slides использует тип перехода и значение [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) для её определения. Установка типа перехода может инициализировать длительность, поэтому сначала ознакомьтесь с оригинальными настройками.

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

Переход Morph анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой эффект Morph, клонируйте слайд, переместите или измените размер объекта в копии и примените переход Morph к второму слайду. Это даёт анимацию соответствующих объектов между их исходным и изменённым состоянием.

В следующем примере создаётся слайд с текстовым прямоугольником, копируется, после чего позиция и размер прямоугольника изменяются в копии. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/). Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время показа слайдов.

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

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) управляет тем, как Morph сопоставляет и анимирует контент:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) рассматривает каждую форму как единый объект.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) анимирует текст, сопоставляя слова там, где это возможно.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) анимирует текст, сопоставляя символы там, где это возможно.

Используйте [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) для выбора Morph перед доступом к [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). Полученное значение предоставляет объект [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/), чей метод [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) выбирает режим сопоставления.

В этом примере открывается презентация, созданная в предыдущем разделе, и настраивается второй слайд для использования анимации Morph на основе слов.

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

## **Установить эффекты переходов**

Некоторые переходы раскрывают дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от выбранного через [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) перехода. Сначала задайте тип, затем используйте соответствующий объект перехода из [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

В следующем примере к первому слайду `input.pptx` применяется переход Cut. Через [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) вызывается [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack), чтобы переход начинался с чёрного экрана.

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

**Могу ли я контролировать скорость воспроизведения перехода слайда?**

Да. Предпочтительно используйте [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration), когда нужна точная длительность эффекта в миллисекундах. Используйте [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), когда достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) — Slow, Medium или Fast — и явная длительность не задаётся. Эти настройки управляют только эффектом перехода, независимо от задержки автоматического продвижения.

**Могу ли я прикрепить аудио к переходу и заставить его зацикливаться?**

Да. Назначьте встроенное аудио через [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), передайте `StartSound` из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) в [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) и включите [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) со значением `true`. Аудио будет зацикливаться до следующего звукового события в показе слайдов.

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Пройдитесь циклом по коллекции [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) презентации и вызовите [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) с тем же значением для перехода каждого слайда. Установите любые параметры времени и эффекта в том же цикле, чтобы поведение было одинаковым для всех слайдов.

**Как проверить, какой переход сейчас установлен на слайде?**

Вызовите [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) у результата [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) слайда. Метод возвращает значение из перечисления [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); `None` означает, что переход не задан.