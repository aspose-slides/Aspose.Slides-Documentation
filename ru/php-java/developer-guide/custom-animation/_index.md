---
title: Создание и изменение пользовательских анимационных поведений в PHP
linktitle: Пользовательская анимация
type: docs
weight: 151
url: /ru/php-java/custom-animation/
keywords:
- пользовательская анимация
- поведение анимации
- траектория движения
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте, просматривайте и изменяйте пользовательские анимационные поведения и редактируемые траектории движения в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Пользовательские анимационные поведения позволяют управлять отдельными операциями внутри анимационного эффекта, например изменением цвета, вращением фигуры или следованием по редактируемому траекторному пути. В этом руководстве показано, как создавать и комбинировать поведения, настраивать их тайминг, исследовать и изменять существующие анимации, а также проверять, сохраняются ли их свойства при сохранении и повторном открытии презентации.

Для предустановленных эффектов и триггеров щелчка см. [Shape Animation](/slides/ru/php-java/shape-animation/).

## **Понимание модели анимации**

Анимация организована как **Timeline → Sequence → Effect → Behaviors**:

- Каждый слайд имеет временную шкалу, содержащую его основную последовательность и интерактивные последовательности.
- [Sequence](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sequence/) содержит эффекты, потенциально направленные на разные фигуры.
- [Effect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effect/) определяет целевую фигуру, предустановку, подтип и тайминг эффекта.
- Коллекция, возвращаемая [Effect::getBehaviors](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effect/getbehaviors/), содержит операции, реализующие эффект: изменение цвета, перемещение, вращение, установка свойства и т.д.

## **Создание отдельных поведений**

Вызовите [Sequence::addEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sequence/addeffect/) для создания эффекта и доступа к коллекции [getBehaviors](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effect/getbehaviors/). Предустановка может автоматически заполнить эту коллекцию. Сохраняйте её операции при расширении предустановки или используйте [clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorcollection/clear/) при намеренной замене.

[BehaviorFactory](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorfactory/) создаёт восемь типов поведения, показанных ниже. Движение рассматривается в разделе [Build a Motion Path](#build-a-motion-path). Каждый фрагмент включает свои импорты и предполагает, что PHP/Java Bridge и библиотека Aspose.Slides PHP уже загружены. Примеры последующего редактирования указывают, какой файл вывода они используют.

### **Rotation**

Используйте [createRotationEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorfactory/createrotationeffect/) для создания вращения. [getBy](https://reference.aspose.com/slides/ru/php-java/aspose.slides/rotationeffect/getby/) задаёт относительный угол в градусах; [getFrom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/rotationeffect/getfrom/) и [getTo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/rotationeffect/getto/) задают конечные точки.

Пример начинается с эффекта Spin, заменяет его предустановленные операции одним поведением вращения и задаёт этой операции длительность в две секунды. Относительный угол 90 градусов обозначает четверть оборота от начальной ориентации фигуры, поэтому явный стартовый угол не нужен.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` содержит одну фигуру и одно поведение вращения. Коллекция, тайминг и примеры редактирования вращения ниже используют этот файл.

### **Scale**

Используйте [createScaleEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorfactory/createscaleeffect/) с процентами X/Y: [getFrom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/scaleeffect/getfrom/) и [getTo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/scaleeffect/getto/) описывают начальный и конечный размер, а [getBy](https://reference.aspose.com/slides/ru/php-java/aspose.slides/scaleeffect/getby/) описывает относительное изменение. Здесь 100 означает оригинальный размер.

Пример увеличивает обе размеры с 100 % до 125 % за две секунды. Использование одинаковых горизонтальных и вертикальных процентов сохраняет пропорции фигуры; разные проценты растянут одну из сторон сильнее.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Color**

Используйте [createColorEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorfactory/createcoloreffect/) для изменения заливки с синего на оранжевый. [getFrom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/coloreffect/getfrom/) и [getTo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/coloreffect/getto/) – это цвета; [getBy](https://reference.aspose.com/slides/ru/php-java/aspose.slides/coloreffect/getby/) – смещение цвета. [BehaviorPropertyCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorpropertycollection/) идентифицирует анимируемый атрибут.

Заливка фигуры инициализируется синим, соответствующим начальному цвету анимации. Выбор атрибута заливки сообщает поведению, какую часть фигуры менять; сами конечные цвета не указывают этот атрибут. Сохранённый эффект описывает переход к оранжевому за две секунды.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Filter**

Используйте [createFilterEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorfactory/createfiltereffect/) для выбора протирки. [getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filtereffect/getsubtype/), и [getReveal](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filtereffect/getreveal/) задают тип фильтра, направление и режим раскрытия/скрытия фигуры.

Этот пример конфигурирует двухсекундную протирку, раскрывающую фигуру с направлением вправо. Настройки фильтра принадлежат поведению внутри эффекта, поэтому они задаются после удаления оригинальных операций предустановки.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Property**

Используйте [createPropertyEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) для анимации непрозрачности. [getFrom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/propertyeffect/getto/), и [getBy](https://reference.aspose.com/slides/ru/php-java/aspose.slides/propertyeffect/getby/) – строки, интерпретируемые через [getValueType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/propertyeffect/getvaluetype/) и [getCalcMode](https://reference.aspose.com/slides/ru/php-java/aspose.slides/propertyeffect/getcalcmode/). Выбирайте конечные значения или относительное смещение, а не задавайте все три без разбора.

Здесь выбранный атрибут – непрозрачность, а числовые строки представляют изменение от 25 % непрозрачности к полной. Линейная интерполяция описывает плавный переход между этими значениями. При адаптации примера к другому атрибуту выберите соответствующий тип значения и конечные точки.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Set**

Используйте [createSetEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorfactory/createseteffect/) для задания видимости через [getTo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/seteffect/getto/). Поведение set не интерполирует между конечными точками.

Пример выбирает атрибут видимости и присваивает строку `visible` при выполнении поведения. Прямоугольник уже видим в этой минимальной презентации, поэтому присваивание может не дать очевидного визуального изменения само по себе. Такая операция полезна как часть более крупного эффекта, который также контролирует, когда фигура становится скрытой или видимой.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Command**

Используйте [createCommandEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorfactory/createcommandeffect/) и настройте [getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/ru/php-java/aspose.slides/commandeffect/getcommandstring/), и [getShapeTarget](https://reference.aspose.com/slides/ru/php-java/aspose.slides/commandeffect/getshapetarget/). Поместите WAV‑запись `sample.wav` в рабочий каталог. Этот пример встраивает её с помощью [addAudioFrameEmbedded](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addaudioframeembedded/) и привязывает команду воспроизведения к аудио‑рамке.

Аудио‑рамка одновременно является целью эффекта и командой. Это связывает запрос воспроизведения с вложённой записью; строка команды сама по себе не указывает, какой медиа‑объект управлять. Эффект сконфигурирован для запуска по щелчку во время показа.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Сохранение сохраняет команду в `command.pptx`; она не воспроизводит запись. Воспроизведение требует проигрывателя с поддержкой команды и её медиа‑цели.

## **Управление коллекцией поведений**

[BehaviorCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorcollection/) поддерживает [add](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorcollection/remove/), и [removeAt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorcollection/removeat/). Этот пример открывает `rotation.pptx`, добавляет масштабирование, перемещает его перед вращением и удаляет вращение. Удаление и повторное вставление того же объекта меняет его сохранённую позицию без создания копии.

Последовательность правок меняет коллекцию из rotation–scale в scale–rotation, а затем только в scale. Индексы относятся к текущей коллекции, поэтому удаление использует новый индекс вращения после переупорядочения. Финальное перечисление подтверждает, какое поведение будет сохранено.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Вывод: `ScaleEffect` – осталось только масштабирование. Порядок в коллекции сам по себе не планирует поведения одно за другим. Очищайте коллекцию только при полной замене её операций.

## **Настройка тайминга поведения**

Поведение имеет собственный [Timing](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/), независимый от тайминга, возвращаемого [Effect::getTiming](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effect/gettiming/). Тайминг эффекта планирует весь эффект; тайминг поведения описывает операцию внутри него.

### **Установка длительности, задержки, повторов и ускорения**

Откройте `rotation.pptx` и задайте длительность ([getDuration](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/getduration/)) и задержку триггера ([getTriggerDelayTime](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/gettriggerdelaytime/)) в секундах, затем настройте количество повторов через [setRepeatCount](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/getaccelerate/) и [getDecelerate](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/getdecelerate/) – доли от длительности; их сумма должна быть ≤ 1.

Входной файл – тот, что создан в примере вращения, где первое поведение известно как вращение. Этот пример меняет только тайминг этого поведения; угол 90° остаётся неизменным. Разделение угла и тайминга упрощает регулировку скорости без пересборки анимации.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Поведение использует длительность в две секунды, задержку полсекунды и количество повторов = 3. Первые и последние 20 % длительности отводятся ускорению и замедлению.

Другие политики повторов включают [getRepeatDuration](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/getrepeatuntilendslide/), и [getRepeatUntilNextClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/getrepeatuntilnextclick/); выбирайте одну политику, а не включайте их все сразу. [getAutoReverse](https://reference.aspose.com/slides/ru/php-java/aspose.slides/timing/getautoreverse/) воспроизводит анимацию в обратном порядке после прямого прохода. Ускорение и замедление применимы к непрерывным изменениям, а не к дискретным присваиваниям или командам.

## **Создание траектории движения**

Используйте [createMotionEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorfactory/createmotioneffect/) для создания движения. Его [getFrom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motioneffect/getto/), и [getBy](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motioneffect/getby/) описывают координаты или смещения в процентах. Для редактируемого маршрута создайте [MotionPath](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motionpath/) и присвойте его через [MotionEffect::setPath](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motioneffect/setpath/). [MotionPath](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motionpath/) хранит команды пути.

[MotionCommandPathType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motioncommandpathtype/) выбирает операцию:

| Команда | Точки | Значение |
| --- | --- | --- |
| MoveTo | Одна | Устанавливает начальную позицию. |
| LineTo | Одна | Перемещается по прямому отрезку к его конечной точке. |
| CurveTo | Три | Следует кубической кривой, заданной двумя контрольными точками и конечной точкой. |
| CloseLoop | Нет | Возвращается к начальной позиции. |
| End | Нет | Завершает путь. |

[MotionPathPointsType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motionpathpointstype/) описывает характеристики редактирования точек, такие как уголок или сглаженная точка. Это не заменяет тип команды. Для примера кривой ниже используйте тип точки «curve», а для прямых отрезков – тип «corner».

Координаты пути нормализованы к размерам слайда: смещение X = 0.25 означает одну четверть ширины слайда, а не 0.25 пункта. Положительный Y направлен вниз. Абсолютные команды задают позиции в системе координат пути; относительные — смещения от текущей позиции. Это отдельно от [getOrigin](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motioneffect/getorigin/), который выбирает референтную систему пути, и [getPathEditMode](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motioneffect/getpatheditmode/), контролирующего, как путь перемещается при перемещении фигуры.

### **Создание прямого пути**

Создайте поведение движения с начальной точкой, одним прямым сегментом и командой завершения. [MotionPath::add](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motionpath/add/) принимает тип команды, её точки, тип точек и флаг относительных координат.

Начальная команда устанавливает (0, 0), а линия заканчивается в (0.25, 0), давая горизонтальное смещение в одну четверть ширины слайда. Команда завершения не имеет координат. После присвоения пути добавление поведения движения к эффекту связывает данный маршрут с прямоугольником.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` содержит одно поведение движения с тремя командами пути. Примеры редактирования файлов ниже опираются на эту структуру.

### **Сравнение абсолютных и относительных координат**

Эти два объекта пути описывают один и тот же маршрут. Абсолютная команда заканчивается в (0.3, 0.1); относительная добавляет (0.1, 0.1) к текущей позиции, т.е. к (0.2, 0).

Оба пути начинаются в одной позиции. Для относительной линии добавьте её X и Y смещения к текущей позиции, получив конечную точку; для абсолютной линии точка конечная указана напрямую. Переключение флага без преобразования координат даст иной маршрут.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

Присвойте любой из путей поведению движения для использования в презентации. Последний логический аргумент выбирает относительные координаты для этой команды.

### **Замена линии кривой**

Откройте `motion.pptx` и замените её линию кубической кривой. Сначала укажите две контрольные точки, затем конечную точку.

Начальная позиция задаётся предыдущей командой. Первые две точки формируют кривую, а третья – её конечную точку; это не три последовательные цели. Обновление типа команды, типа редактирования точек и массива точек одновременно сохраняет согласованность сегмента с новой геометрией.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Путь в `curve.pptx` по‑прежнему имеет три команды; её средняя команда теперь определяет кривую.

## **Чтение и редактирование сохранённого пути**

Каждый [MotionCmdPath](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motioncmdpath/) раскрывает [getPoints](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motioncmdpath/getpointstype/), и [isRelative](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motioncmdpath/isrelative/). Ниже примеры работают с известным трёхкомандным путём в `motion.pptx`. Для произвольного ввода сначала найдите нужный эффект и проверьте типы команд и количество точек перед редактированием по индексу.

### **Чтение команд и координат**

Прочитайте путь без изменения. Команды End и CloseLoop не требуют точек, поэтому допускайте null‑массив точек.

Вывод сопоставляет каждый числовой тип команды с её флагом относительных координат, а затем перечисляет её точки. Это позволяет различать конечную точку и смещение до изменения пути. Кривая будет перечислять три точки, тогда как прямой отрезок в этом файле – только одну.

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Список содержит начальную точку, абсолютную линию, заканчивающуюся в (0.25, 0), и команду End.

### **Изменение конечной точки**

Откройте `motion.pptx` и замените массив точек линии, переместив её конечную точку.

В входном файле индекс 0 – начальная команда, индекс 1 – линия. Замена единственной точки линии меняет её пункт назначения без изменения типа команды, тайминга или позиции в коллекции. Поскольку команда использует абсолютные координаты, новая пара задаёт позицию, а не добавляемый смещение.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Линия в `motion-endpoint.pptx` заканчивается в (0.4, 0.1); оригинальный файл остаётся без изменений.

### **Замена сегмента**

Используйте [insert](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motionpath/insert/) и [removeAt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/motionpath/removeat/) для замены линии в `motion.pptx`. Вставка сдвигает старую линию к индексу 2.

Это демонстрирует замену объекта команды вместо редактирования её существующих координат. После вставки коллекция временно содержит: начальную команду, новую линию, старую линию и команду End. Удаление индекса 2 отбрасывает старую линию, оставляя новый маршрут на месте.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сохранённый путь всё ещё имеет три команды, новая линия заканчивается в (0.2, 0.1), а команда End остаётся последней.

## **Модификация и проверка существующего поведения**

Когда индекс поведения неизвестен, выберите его по типу. Этот пример открывает `rotation.pptx`, находит его [RotationEffect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/rotationeffect/), меняет угол и проверяет сохранённое значение после повторного открытия.

Проверка типа позволяет пропустить поведения, не являющиеся вращениями. Второе чтение загружает сохранённый файл в отдельный объект презентации, так что сравнение проверяет сохранённые данные, а не значение, оставшееся в памяти. Пример всё ещё предполагает, что известный эффект первый в основной последовательности; выбор поведения по типу не гарантирует нахождение правильного эффекта в произвольной презентации.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Вывод: `Rotation preserved: true`. Применяйте тот же шаблон проверки типа к другим поведениям. Для полной проверки сохранения сравните целевую фигуру, эффект, типы и порядок поведений, тайминг, команды пути. Для презентации с неизвестной анимационной разметкой см. [Read Shape Animations](/slides/ru/php-java/shape-animation/#read-shape-animations) для обхода основных и интерактивных последовательностей.

## **Порядок поведения, предустановки и воспроизведение**

Порядок в [BehaviorCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behaviorcollection/) – это сохранённый порядок операций эффекта. Это не плейлист, где каждое поведение автоматически ждёт предыдущее. Тайминг и охватывающий эффект определяют планирование. Поведения могут накладываться, а операции над одним и тем же свойством могут взаимодействовать через настройки [additive](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behavioradditivetype/) и [accumulation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/behavioraccumulatetype/). Не используйте только переупорядочивание коллекции для планирования «сначала перемещение, затем вращение»; применяйте явный тайминг или отдельные эффекты, как описано в [Shape Animation](/slides/ru/php-java/shape-animation/).

[getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effect/gettype/) и [getSubtype](https://reference.aspose.com/slides/ru/php-java/aspose.slides/effect/getsubtype/) эффекта описывают его предустановку. Это не полное описание отредактированного дерева поведения. Сначала выберите предустановку и подтип, затем настраивайте поведения: изменение предустановки может перестроить коллекцию и удалить ваши пользовательские операции. Например, изменение настроенного эффекта Spin на Fade может заменить его поведение вращения на поведения set и filter. После изменения предустановки или подтипа снова проверьте коллекцию. Очистка предустановленных поведений также может удалить операции видимости или инициализации, необходимые предустановке. Примеры намеренно используют видимые фигуры и заменяют поведения; они не воссоздают реализацию каждой предустановки полностью.

## **Совместимость форматов**

Сохранённое дерево поведения не гарантирует идентичное воспроизведение во всех просмотрщиках или экспортных рендерах. Проверяйте сохранённые данные и визуальный вывод отдельно.

| Формат или вывод | Что проверять |
| --- | --- |
| PPTX | Используйте как основной формат для этих примеров. Откройте заново, чтобы убедиться в сохранённом редактируемом дереве поведения, затем проверьте воспроизведение в целевой версии PowerPoint. |
| PPT | Устаревшее бинарное представление может отличаться от PPTX. Протестируйте отдельный цикл «сохранить‑и‑открыть» и воспроизведение; не делайте выводы о поддержке каждой пользовательской комбинации только из успешного вывода PPTX. |
| PDF, PNG, JPEG и другие статические изображения слайдов | Содержат статическое изображение слайда, а не воспроизводимую временную шкалу поведения или гарантированный конечный кадр анимации. |
| [HTML5](/slides/ru/php-java/export-to-html5/) | Может воспроизводить поддерживаемые анимации, если в опциях экспорта включена анимация фигур. Тестируйте пользовательские комбинации в браузере. |
| [Animated GIF](/slides/ru/php-java/convert-powerpoint-to-animated-gif/) | Сохраняет отрисованные кадры, а не редактируемые поведения или интерактивные клики. Проверьте фактическое отрисованное движение. |
| [Video](/slides/ru/php-java/convert-powerpoint-to-video/) | Рендерит кадры анимации и кодирует их в видео. Поддержка ограничена [поддерживаемыми анимациями и эффектами](/slides/ru/php-java/convert-powerpoint-to-video/#supported-animations-and-effects); команды и интерактивные события не превращаются в редактируемую временную шкалу. |

## **FAQ**

**Почему мой эффект уже содержит поведения, хотя я ничего не добавлял?**

Создание предустановленного эффекта может создать его базовые операции. Проверьте их, прежде чем решать, расширять предустановку или заменять её поведения.

**Если переместить поведение в начало, будет ли оно воспроизводиться первым?**

Не обязательно. Порядок в коллекции не заменяет тайминг. Проверьте задержки, длительности и взаимодействия между операциями над одним свойством.

**Почему у команды End нет точек?**

Она обозначает конец пути и не требует координат. При проверке пути, считанного из файла, учитывайте возможность null‑массива точек.

**Достаточно ли успешного «кругового» прохода, чтобы подтвердить воспроизведение?**

Нет. Открытие подтверждает сохранение проверенных свойств. Тестируйте проигрыватель слайд-шоу или анимированный экспорт отдельно, чтобы убедиться в визуальном поведении.