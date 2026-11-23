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
description: "Применяйте переходы слайдов, настраивайте автоматическое продвижение слайдов и кастомизируйте Morph и другие эффекты перехода с помощью Aspose.Slides for PHP via Java."
---
## **Обзор**

Переходы между слайдами управляют тем, как слайды появляются во время показа. С помощью Aspose.Slides for PHP via Java вы можете выбирать эффект перехода для каждого слайда, настраивать переход по щелчку мыши или таймеру и регулировать параметры, специфичные для эффекта. В этой статье используются примеры на PHP для применения переходов, установки точных длительностей переходов, управления таймингом слайдов и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавить переход слайда**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и получите настройки перехода слайда через [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Используйте [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) со значением из перечисления [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), затем сохраните презентацию.

В следующем примере к первому слайду применяется переход Circle, а ко второму — переход Comb. Используйте файл `input.pptx` с как минимум двумя слайдами.

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

## **Wheel переход**

Метод [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) контролирует, сколько радиальных секторов открывает целевой слайд. Используйте [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) для выбора Wheel из [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), затем вызовите [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue), чтобы получить настройки [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

В примере создаются две одинаковые пары слайдов. Каждая пара начинается черным слайдом и заканчивается слайдом, покрытым золотым прямоугольником. Слайд 2 использует один сектор, а слайд 4 — восемь. Оба перехода используют одну и ту же медленную скорость, задаваемую через [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), и явную длительность 8 000 мс, задаваемую через [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

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

Откройте сохранённую презентацию в PowerPoint и запустите показ слайдов. Перейдите со слайда 1 на слайд 2, чтобы увидеть один вращающийся сектор по часовой стрелке. Затем перейдите со слайда 3 на слайд 4, чтобы увидеть восемь радиальных секторов, одновременно открывающих тот же прямоугольник.

## **Fade Through Black с переходом Reveal**

Установите тип перехода целевого слайда в Reveal, затем вызовите [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) у его настроек [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/). Пример создаёт бирюзовый исходный слайд и коралловый целевой слайд, затем клонирует оба. Каждая пара использует одинаковый двухсекундный переход Reveal. Только вторая пара затемняет экран через чёрный цвет.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Откройте сохранённую презентацию в PowerPoint и запустите показ слайдов. Перейдите со слайда 1 на слайд 2, чтобы увидеть плавный переход от бирюзового к коралловому. Затем перейдите со слайда 3 на слайд 4: экран кратко потемнеет почти до чёрного, после чего появляется коралловый слайд. Оба слайда сохраняют свои исходные цвета фона.

Ниже показаны кадры PowerPoint с интервалом полсекунды. Сравните средний кадр в каждой строке, чтобы увидеть эффект.

![Воспроизведение PowerPoint с отключённым (верх) и включённым (низ) Fade Through Black. Только нижняя строка проходит через почти чёрный цвет.](reveal-through-black.png)

## **Добавить расширенный переход слайда**

Вы можете настроить, насколько долго слайд остаётся на экране и будет ли щелчок мыши продвигать показ. Следующие методы управляют этим поведением:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) позволяет зрителю перейти дальше щелчком мыши.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) включает автоматический переход.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) задаёт задержку перед автоматическим переходом в миллисекундах.

Включите одновременно щелчок и таймер, чтобы зритель мог продвинуться кликом или дождаться таймера. Чтобы использовать только таймер, передайте `false` в [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Задержка управляет моментом перехода слайда; она не задаёт длительность визуального эффекта перехода.

В этом примере первым трем слайдам назначаются разные эффекты, а автоматический переход включён после 3, 5 и 7 секунд соответственно. Щелчок мышью также может продвигать эти слайды. Используйте файл `input.pptx` с как минимум тремя слайдами.

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

Чтобы проверить, включён ли таймер, вызовите [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Хранящаяся задержка сама по себе не указывает, что таймер активен.

Следующий пример открывает файл, сохранённый выше, выводит информацию о каждом включённом таймере и отключает автоматический переход для слайдов с задержкой более двух секунд. Для этих слайдов включается щелчок мыши, после чего настройки сохраняются.

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

Используйте [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration), чтобы задать точную длительность эффекта перехода в миллисекундах. Метод [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) слайда предоставляет эти настройки через [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Метод | Назначение |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Устанавливает длительность самого эффекта перехода в миллисекундах. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Задает задержку перед автоматическим переходом слайда в миллисекундах. Передайте `true` в [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter), чтобы активировать таймер. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) управляет только эффектом перехода; он не определяет, как долго слайд остаётся видимым. Задержку автоматического перехода настраивают отдельно. Если явная длительность не указана, Aspose.Slides определяет её исходя из типа перехода и значения, возвращённого [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Отдельные полосы показывают длительность 750 мс перехода и 5 000 мс автоматического перехода.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Пример задаёт каждому слайду 750 мс переход Fade и отдельно включает автоматический переход через 5 000 мс. Длительность управляет эффектом, а автоматический переход — моментом выхода со слайда. Эти полосы являются схематичными настройками, а не измеренной общей шкалой времени.*
<!-- visual-explanation:slide-transition:end -->

### **Применить одинаковую длительность ко всем слайдам**

Для согласованного темпа примените один и тот же эффект и точную длительность ко всем слайдам. В этом примере загружается `input.pptx`, выбирается Fade из [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), каждому переходу задаётся длительность 750 мс, автоматически включается переход через 5 000 мс и отключается переход по щелчку мыши, после чего результат сохраняется в PPTX.

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

Разные слайды могут иметь разные длительности эффектов. Например, короткий переход для заглавного слайда и более длительный для ввода раздела. В этом примере задаются 500 мс для первого слайда и 1 200 мс для второго. Используйте файл `input.pptx` с как минимум двумя слайдами.

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

При подготовке [animated GIF](/slides/ru/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/php-java/export-to-html5/) или [video](/slides/ru/php-java/convert-powerpoint-to-video/), задайте точные длительности переходов перед экспортом, чтобы соответствовать желаемому темпу. Например, используйте 600‑мс затухание между сценами и отдельно настройте задержку автоматического перехода каждого слайда, чтобы обеспечить время для озвучки или контента.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствует 18 кадрам при 30 fps. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры тайминга выбранного формата и просмотрите вывод для подтверждения синхронизации.

### **Прочитать существующую длительность перехода**

Вызовите [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) до изменения перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение задаёт сохранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и значение, возвращённое [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed), чтобы определить её. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте оригинальные настройки.

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

## **Morph переход**

Morph переход анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой Morph‑эффект, клонируйте слайд, переместите или измените размер объекта в клоне и примените Morph к второму слайду. Это даёт анимацию соответствующих объектов между их исходным и изменённым состоянием.

В следующем примере создаётся слайд с текстовым прямоугольником, клонируется, а в клоне меняются позиция и размер прямоугольника. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/). Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время показа.

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

## **Типы Morph переходов**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) управляет тем, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) рассматривает каждую фигуру как целый объект.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) анимирует текст, сопоставляя слова, когда это возможно.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) анимирует текст, сопоставляя символы, когда это возможно.

Используйте [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) для выбора Morph перед вызовом [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). Полученное значение предоставляет объект [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/), у которого метод [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) выбирает режим сопоставления.

В этом примере открывается презентация, созданная в предыдущем разделе, и конфигурируется второму слайду использование анимации Morph по словам.

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

Некоторые переходы предоставляют дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от выбранного через [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) перехода. Сначала задайте тип, затем используйте соответствующий объект перехода, полученный через [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

В следующем примере применяется переход Cut к первому слайду `input.pptx`. Через объект [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) вызывается [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack), чтобы переход начинался с чёрного экрана.

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

**Могу ли я управлять скоростью воспроизведения перехода слайда?**

Да. Предпочтительно используйте [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration), когда нужна точная длительность эффекта в миллисекундах. Используйте [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), когда достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) — Slow, Medium или Fast — и явная длительность не указана. Эти параметры управляют только эффектом перехода, независимо от задержки автоматического перехода.

**Могу ли я добавить звук к переходу и включить его зацикливание?**

Да. Присвойте встроенный звук через [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), передайте `StartSound` из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) в [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) и включите зацикливание с помощью [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) = `true`. Звук будет повторяться до следующего звукового события в показе.

**Как быстрее всего применить один и тот же переход ко всем слайдам?**

Пройдитесь в цикле по коллекции [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) презентации и вызовите [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) с тем же значением для перехода каждого слайда. В том же цикле задайте любые параметры тайминга и эффекта, чтобы поведение было одинаковым на всех слайдах.

**Как проверить, какой переход в данный момент установлен на слайде?**

Вызовите [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) у результата [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) слайда. Метод возвращает значение из перечисления [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); `None` означает, что переход не установлен.