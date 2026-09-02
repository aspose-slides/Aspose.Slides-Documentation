---
title: "Применение анимации фигур в презентациях с использованием PHP"
linktitle: "Анимация фигур"
type: docs
weight: 60
url: /ru/php-java/shape-animation/
keywords:
  - "фигура"
  - "анимация"
  - "эффект"
  - "анимированная фигура"
  - "анимированный текст"
  - "добавить анимацию"
  - "получить анимацию"
  - "извлечь анимацию"
  - "добавить эффект"
  - "получить эффект"
  - "извлечь эффект"
  - "звук эффекта"
  - "применить анимацию"
  - "PowerPoint"
  - "презентация"
  - "PHP"
  - "Aspose.Slides"
description: "Узнайте, как добавлять, просматривать и настраивать анимацию фигур, их тайминг, звуки, поведение после анимации и анимированный текст с помощью Aspose.Slides for PHP via Java."
---
## **Обзор**

Aspose.Slides for PHP via Java представляет анимацию слайдов в виде эффектов на временной шкале слайда. Эффект имеет целевую форму, тип анимации и подтип, триггер, настройки времени и дополнительные свойства, такие как звук или поведение после анимации.

Временная шкала содержит два типа последовательностей:

- **Основная последовательность** воспроизводится при переходе к следующему слайду.
- **Интерактивная последовательность** начинается, когда её триггерная форма нажата.

Поскольку текстовые поля, изображения, диаграммы, таблицы и другие объекты слайда являются формами, вы используете один и тот же метод [Sequence::addEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sequence/addeffect/) для большинства содержимого слайда. Доступные эффекты перечислены в классе [EffectType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effecttype/).

## **Добавление анимации форм**

Чтобы добавить анимацию, получите основную последовательность слайда и вызовите [Sequence::addEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sequence/addeffect/) с целевой формой, типом эффекта, подтипом и триггером. Для эффекта, который начинается при нажатии на другую форму, создайте интерактивную последовательность, триггером которой будет эта другая форма.

Следующий пример создаёт оба типа анимации и сохраняет результат в `shape-animations.pptx`.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Click to animate this shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $entranceEffect = $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $entranceEffect->getTiming()->setDuration(1.5);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $presentation->save("shape-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Триггер определяет, когда начинается эффект:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effecttriggertype/) ждёт клика в основной последовательности или клика по триггерной форме в интерактивной последовательности.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effecttriggertype/) начинается одновременно с предшествующим эффектом.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effecttriggertype/) начинается после завершения предшествующего эффекта.

Чтобы анимировать изображение, диаграмму или другой тип формы, передайте этот объект в [Sequence::addEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sequence/addeffect/) вместо `$targetShape`. Для параметров группировки, специфичных для диаграмм, см. [Animated Charts](/slides/ru/php-java/animated-charts/).

## **Чтение анимации форм**

Используйте [Sequence::getEffectsByShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sequence/geteffectsbyshape/), когда известна целевая форма. Чтобы просмотреть каждый эффект, перечислите основную последовательность и все интерактивные последовательности. Перечисление позволяет не предполагать, что в последовательности есть эффект с индексом `0`.

Следующий пример создаёт форму с эффектами основной и интерактивной последовательностей, получает эффекты, направленные на форму, а затем перечисляет все последовательности на слайде.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function printSequence($label, $sequence)
{
    $effectCount = java_values($sequence->getCount());

    echo "  " . $label . ": " . $effectCount . " effect(s)" . PHP_EOL;

    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $targetShape = $effect->getTargetShape();
        $targetName = java_is_null($targetShape) ? "unknown" : java_values($targetShape->getName());
        $effectType = java_values($effect->getType());
        $effectSubtype = java_values($effect->getSubtype());
        $triggerType = java_values($effect->getTiming()->getTriggerType());
        echo "    type: " . $effectType . "; subtype: " . $effectSubtype . "; target: " . $targetName . "; trigger: " . $triggerType . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Animated shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $targetEffects = $mainSequence->getEffectsByShape($targetShape);
    $Array = new JavaClass("java.lang.reflect.Array");
    echo "The main sequence contains " . java_values($Array->getLength($targetEffects)) . " effect(s) for " . java_values($targetShape->getName()) . "." . PHP_EOL;

    printSequence("Main sequence", $mainSequence);

    $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
    $interactiveCount = java_values($interactiveSequences->getCount());
    for ($interactiveIndex = 0; $interactiveIndex < $interactiveCount; $interactiveIndex++) {
        $sequence = $interactiveSequences->get_Item($interactiveIndex);
        $sequenceTrigger = $sequence->getTriggerShape();
        $triggerName = java_is_null($sequenceTrigger) ? "unknown" : java_values($sequenceTrigger->getName());
        printSequence("Interactive sequence " . ($interactiveIndex + 1) . ", trigger: " . $triggerName, $sequence);
    }
} finally {
    $presentation->dispose();
}
```

Если нужны эффекты только для одной формы, сначала определите форму по имени, типу заполнителя или другому стабильному свойству; затем вызовите [Sequence::getEffectsByShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sequence/geteffectsbyshape/). Не предполагайте, что [ShapeCollection::get_Item](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/get_item/) с индексом `0` всегда является нужным объектом.

## **Работа с унаследованными эффектами заполнителей**

Заполнитель на обычном слайде может наследовать поведение анимации от соответствующего заполнителя на слайде‑макете и мастере. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getbaseplaceholder/) возвращает родительский заполнитель или `null`, если родитель отсутствует.

В примере презентации ниже нижний колонтитул имеет **Random Bars** на обычном слайде, **Split** на слайде‑макете и **Fly In** на мастере.

![Эффект анимации нижнего колонтитула на обычном слайде](slide-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на слайде‑макете](layout-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на мастере](master-shape-animation.png)

В следующем примере используется иерархия заполнителей из новой презентации. Он добавляет эффекты к заполняющему мастера, заполняющему макета и соответствующему заполняющему на обычном слайде. Каждый вызов [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/getbaseplaceholder/) проверяется перед использованием возвращённой формы.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

function findLayoutPlaceholderWithBase($layoutSlide)
{
    $shapes = $layoutSlide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_is_null($shape->getBasePlaceholder())) {
            return $shape;
        }
    }

    return null;
}

function findSlidePlaceholderWithBase($slide, $expectedBase)
{
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $basePlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($basePlaceholder) && java_values($basePlaceholder->equals($expectedBase))) {
            return $shape;
        }
    }

    return null;
}

function printEffects($source, $effects)
{
    $Array = new JavaClass("java.lang.reflect.Array");
    echo $source . ": " . java_values($Array->getLength($effects)) . " effect(s)" . PHP_EOL;

    foreach ($effects as $effect) {
        echo "  type: " . java_values($effect->getType()) . "; subtype: " . java_values($effect->getSubtype()) . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);
    $layoutPlaceholder = findLayoutPlaceholderWithBase($layoutSlide);

    if ($layoutPlaceholder === null) {
        throw new RuntimeException("The layout slide does not contain a placeholder linked to its master slide.");
    }

    $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
    $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->addEffect($masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    $layoutSlide->getTimeline()->getMainSequence()->addEffect($layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

    $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $slidePlaceholder = findSlidePlaceholderWithBase($slide, $layoutPlaceholder);

    if ($slidePlaceholder === null) {
        throw new RuntimeException("The slide does not contain a placeholder linked to its layout slide.");
    }

    $slide->getTimeline()->getMainSequence()->addEffect($slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
    printEffects("Normal slide", $slide->getTimeline()->getMainSequence()->getEffectsByShape($slidePlaceholder));

    $baseLayoutPlaceholder = $slidePlaceholder->getBasePlaceholder();
    if (!java_is_null($baseLayoutPlaceholder)) {
        printEffects("Layout slide", $layoutSlide->getTimeline()->getMainSequence()->getEffectsByShape($baseLayoutPlaceholder));

        $baseMasterPlaceholder = $baseLayoutPlaceholder->getBasePlaceholder();
        if (!java_is_null($baseMasterPlaceholder)) {
            printEffects("Master slide", $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($baseMasterPlaceholder));
        }
    }

    $presentation->save("placeholder-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Изменение времени анимации**

Диалоговое окно PowerPoint **Timing** соответствует свойствам класса [Timing](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/).

![Диалоговое окно Timing PowerPoint для эффекта анимации](shape-animation.png)

- **Start** соответствует [Timing::getTriggerType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/gettriggertype/).
- **Duration** соответствует [Timing::getDuration](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/getduration/), в секундах.
- **Delay** соответствует [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/gettriggerdelaytime/), в секундах.
- **Repeat** соответствует [Timing::getRepeatCount](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/getrepeatuntilnextclick/), или [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Rewind when done playing** соответствует [Timing::getRewind](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/getrewind/).

Этот самостоятельный пример добавляет эффект, изменяет его время через объект, возвращаемый [Sequence::addEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sequence/addeffect/), и сохраняет результат. Сохранение ссылки на возвращённый объект [Effect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effect/) избегает необходимости использовать индекс коллекции.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Timed animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    $effect->getTiming()->setDuration(2.0);
    $effect->getTiming()->setTriggerDelayTime(0.5);
    $effect->getTiming()->setRepeatUntilNextClick(false);
    $effect->getTiming()->setRepeatUntilEndSlide(false);
    $effect->getTiming()->setRepeatCount(2.0);
    $effect->getTiming()->setRewind(true);

    $presentation->save("shape-animation-timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Используйте один режим повторения намеренно. Сочетание счётчика повторов с флагом «until» может давать запутанные результаты в разных просмотрщиках. При изменении режимов повторения вызывайте [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/setrepeatuntilnextclick/) и [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/setrepeatuntilendslide/) перед [Timing::setRepeatCount](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/setrepeatcount/), потому что установка любого из флагов также меняет активный режим повторения.

## **Добавление и извлечение звуков анимации**

Эффект анимации может ссылаться на встроенный аудиофайл через [Effect::getSound](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effect/getsound/). [Effect::setStopPreviousSound](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effect/setstopprevioussound/) указывает эффекту остановить звук, начатый более ранним эффектом.

### **Добавление звука к эффекту**

Следующий пример ожидает локальный аудиофайл с именем `animation-sound.wav`. Он создаёт два эффекта, встраивает этот файл как звук первого эффекта и настраивает второй эффект на остановку звука. Он использует объекты, возвращаемые [Sequence::addEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sequence/addeffect/), поэтому индекс последовательности не требуется.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$Files = new JavaClass("java.nio.file.Files");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 100, 240, 80);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 400, 100, 240, 80);
    $firstShape->addTextFrame("Starts sound");
    $secondShape->addTextFrame("Stops sound");

    $sequence = $slide->getTimeline()->getMainSequence();
    $firstEffect = $sequence->addEffect($firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $secondEffect = $sequence->addEffect($secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $baseDirectory = getcwd();
    $audioPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "animation-sound.wav"))->toPath();
    $audioData = $Files->readAllBytes($audioPath);
    $effectSound = $presentation->getAudios()->addAudio($audioData);
    $firstEffect->setSound($effectSound);
    $secondEffect->setStopPreviousSound(true);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "shape-animation-sound.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Извлечение встроенных звуков эффекта**

Следующий пример ожидает локальную презентацию с именем `presentation-with-animation-sounds.pptx`. Он сканирует как основную, так и интерактивную последовательности и записывает каждый встроенный звук эффекта в каталог `extracted-animation-sounds`. Расширение выбирается из MIME‑типа аудио, предоставляемого [Audio::getContentType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/audio/getcontenttype/).

```php
use aspose\slides\Presentation;

function getAudioExtension($contentType)
{
    $normalizedType = strtolower($contentType === null ? "" : java_values($contentType));

    if ($normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if ($normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if ($normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if ($normalizedType === "audio/wav" || $normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds($sequence, $outputDirectory, $soundIndex)
{
    $effectCount = java_values($sequence->getCount());
    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $sound = $effect->getSound();
        if (java_is_null($sound)) {
            continue;
        }

        $extension = getAudioExtension($sound->getContentType());
        $outputPath = $outputDirectory->resolve("effect-sound-" . $soundIndex . $extension);
        $outputStream = new Java("java.io.FileOutputStream", $outputPath->toFile());
        try {
            $outputStream->write($sound->getBinaryData());
        } finally {
            $outputStream->close();
        }
        $soundIndex++;
    }

    return $soundIndex;
}

$baseDirectory = getcwd();
$inputPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "presentation-with-animation-sounds.pptx"))->toPath();
$outputDirectoryName = $baseDirectory . DIRECTORY_SEPARATOR . "extracted-animation-sounds";
if (!is_dir($outputDirectoryName)) {
    mkdir($outputDirectoryName, 0777, true);
}
$outputDirectory = (new Java("java.io.File", $outputDirectoryName))->toPath();

$presentation = new Presentation($inputPath->toString());
try {
    $soundIndex = 1;

    $slides = $presentation->getSlides();
    $slideCount = java_values($slides->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $slides->get_Item($slideIndex);
        $soundIndex = saveSounds($slide->getTimeline()->getMainSequence(), $outputDirectory, $soundIndex);

        $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
        $interactiveCount = java_values($interactiveSequences->getCount());
        for ($sequenceIndex = 0; $sequenceIndex < $interactiveCount; $sequenceIndex++) {
            $sequence = $interactiveSequences->get_Item($sequenceIndex);
            $soundIndex = saveSounds($sequence, $outputDirectory, $soundIndex);
        }
    }

    echo "Extracted " . ($soundIndex - 1) . " sound file(s) to " . java_values($outputDirectory->toAbsolutePath()->toString()) . "." . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Для больших аудио‑объектов используйте [Audio::getStream](https://reference.aspose.com/slides/ru/php-java/aspose.slides/audio/getstream/) и копируйте поток в файл вместо загрузки всего объекта в массив байт.

## **Установка поведения после анимации**

Опция **After animation** определяет, что происходит с формой после завершения её эффекта.

![Диалоговое окно параметров эффекта PowerPoint, показывающее настройки After animation](shape-after-animation.png)

Класс [AfterAnimationType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/afteranimationtype/) поддерживает оставлять форму без изменений, менять её цвет, скрывать её после анимации или скрывать её при следующем щелчке. Когда тип — [AfterAnimationType::Color](https://reference.aspose.com/slides/ru/php-java/aspose.slides/afteranimationtype/), также задайте [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effect/getafteranimationcolor/).

Этот самостоятельный пример создаёт эффект, задаёт его поведение после анимации через возвращённый объект эффекта и сохраняет результат.

```php
use aspose\slides\AfterAnimationType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Dim after animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->setAfterAnimationType(AfterAnimationType::Color);
    $effect->getAfterAnimationColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("shape-animation-after-effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Изменение типа от [AfterAnimationType::Color](https://reference.aspose.com/slides/ru/php-java/aspose.slides/afteranimationtype/) очищает настройку цвета после анимации.

## **Анимация текста**

Анимация текста имеет два связанных элемента управления:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textanimation/getbuildtype/) управляет тем, появляются ли абзацы вместе или по уровням абзаца.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effect/getanimatetexttype/) управляет тем, появляется ли текст целиком, по словам или по буквам. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effect/getdelaybetweentextparts/) задаёт задержку между словами или буквами. Положительное значение — процент от длительности эффекта; отрицательное значение — задержка в секундах.

Следующий самостоятельный пример анимирует слова в текстовом поле. [BuildType::AsOneObject](https://reference.aspose.com/slides/ru/php-java/aspose.slides/buildtype/) отключает построение по абзацам, чтобы параметр слова применялся к целому текстовому фрейму.

```php
use aspose\slides\AnimateTextType;
use aspose\slides\BuildType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 560, 100);
    $textBox->addTextFrame("Aspose.Slides animates this sentence word by word.");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    $effect->setAnimateTextType(AnimateTextType::ByWord);
    $effect->setDelayBetweenTextParts(20.0);

    $presentation->save("animated-text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Чтобы построить текстовое поле по абзацам, задайте [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/ru/php-java/aspose.slides/buildtype/) (или другой уровень абзаца). Чтобы задать отдельный эффект для одного абзаца, используйте перегрузку [Sequence::addEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sequence/addeffect/), принимающую объект [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/). См. [Animated Text](/slides/ru/php-java/animated-text/) для примеров уровня абзаца.

## **Заметки об экспорте и совместимости**

- Сохранение в PPT или PPTX сохраняет модель анимации, но финальное воспроизведение контролируется средством просмотра презентаций.
- PDF и статические изображения не воспроизводят анимацию. Используйте [HTML5 export](/slides/ru/php-java/export-to-html5/), анимированный GIF или [video conversion](/slides/ru/php-java/convert-powerpoint-to-video/), когда необходимо показать движение.
- Для HTML5 включите [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/html5options/setanimateshapes/), и при необходимости [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/html5options/setanimatetransitions/).
- Видеорендеринг поддерживает многие распространённые эффекты появления, акцентирования, завершения и пути движения, но не каждый эффект PowerPoint поддерживается. Проверьте текущий список [supported animations and effects](/slides/ru/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) и протестируйте критические презентации с вашей целевой версией Aspose.Slides.
- Продвинутые пользовательские эффекты и эффекты, импортированные из других форматов презентаций, могут сохраняться в файле, но отображаются иначе в PowerPoint, HTML5 или видео. Проверяйте экспортированный результат, а не только название эффекта.

## **FAQ**

**Почему анимация отображается в PowerPoint, но не в PDF?**

PDF — статический формат, поэтому анимация и переходы слайдов не воспроизводятся. Экспортируйте в HTML5, анимированный GIF или видео, когда необходимо сохранить движение.

**Почему эффект воспроизводится иначе в видео?**

Экспорт в видео рендерит анимацию, а не сохраняет оригинальное поведение PowerPoint. Некоторые сложные эффекты не поддерживаются или приближенно реализованы. Просмотрите таблицу поддерживаемых эффектов и протестируйте презентацию перед использованием в продакшн.

**Изменяет ли перемещение формы вперед или назад порядок её анимации?**

Нет. Порядок наложения (z‑order) управляет перекрытием, тогда как порядок последовательностей и триггеры управляют воспроизведением анимации. Измените временную шкалу, если нужен иной порядок воспроизведения.