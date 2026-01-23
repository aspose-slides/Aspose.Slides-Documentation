---
title: Применение анимаций фигур в презентациях с помощью PHP
linktitle: Анимация фигур
type: docs
weight: 60
url: /ru/php-java/shape-animation/
keywords:
- фигура
- анимация
- эффект
- анимированная фигура
- анимированный текст
- добавить анимацию
- получить анимацию
- извлечь анимацию
- добавить эффект
- получить эффект
- извлечь эффект
- звуковой эффект
- применить анимацию
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать и настраивать анимацию фигур в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java. Выделяйтесь!"
---

Анимации — это визуальные эффекты, которые можно применять к тексту, изображениям, фигурам или [диаграммам](https://docs.aspose.com/slides/php-java/animated-charts/). Они придают жизнь презентациям или их составляющим.

## **Зачем использовать анимации в презентациях?**

Используя анимации, вы можете

* контролировать поток информации
* подчёркивать важные моменты
* повысить интерес или участие вашей аудитории
* сделать контент проще для чтения, усвоения или обработки
* привлечь внимание читателей или зрителей к важным частям в презентации

PowerPoint предоставляет множество вариантов и инструментов для анимаций и анимационных эффектов в категориях **вход**, **выход**, **акцент** и **траектории движения**.

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями в пространстве имён `Aspose.Slides.Animation`,
* Aspose.Slides предоставляет более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype). Эти эффекты по сути такие же (или эквивалентные) эффекты, используемые в PowerPoint.

## **Применение анимации к TextBox**

Aspose.Slides для PHP через Java позволяет применять анимацию к тексту в фигуре.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
4. Добавьте текст в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) объекта `AutoShape`.
5. Получите основную последовательность эффектов.
6. Добавьте анимационный эффект к [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
7. Используйте метод `TextAnimation.setBuildType` и значение из перечисления `BuildType`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот PHP‑код демонстрирует, как применить эффект `Fade` к AutoShape и установить анимацию текста со значением *By 1st Level Paragraphs*:
```php
  # Создает экземпляр класса презентации, представляющего файл презентации.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет новую AutoShape с текстом
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Получает основную последовательность слайда.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Добавляет эффект анимации Fade к фигуре
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Анимирует текст фигуры по абзацам первого уровня
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Сохраняет файл PPTX на диск
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert color="primary"  %}} 
Помимо применения анимаций к тексту, вы также можете применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/). Смотрите [**Animated Text**](/slides/ru/php-java/animated-text/).
{{% /alert %}} 

## **Применение анимации к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) на слайде.
4. Получите основную последовательность эффектов.
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe).
6. Запишите презентацию на диск в виде файла PPTX.

Этот PHP‑код демонстрирует, как применить эффект `Fly` к рамке изображения:
```php
  # Создает экземпляр класса презентации, представляющего файл презентации.
  $pres = new Presentation();
  try {
    # Загружает изображение, которое будет добавлено в коллекцию изображений презентации
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Добавляет рамку изображения на слайд
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Получает основную последовательность слайда.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Добавляет анимационный эффект «Fly from Left» к рамке изображения
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Сохраняет файл PPTX на диск
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Применение анимации к Shape**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольную [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
4. Добавьте фаску [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) (когда этот объект будет щёлкнут, анимация будет воспроизведена).
5. Создайте последовательность эффектов для формы фаски.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды перемещения к `UserPath`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот PHP‑код демонстрирует, как применить эффект `PathFootball` (путь football) к фигуре:
```php
  # Создаёт экземпляр класса Presentation, представляющего файл PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Создаёт эффект PathFootball для существующей фигуры с нуля.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Добавляет анимационный эффект PathFootball
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Создаёт некую «кнопку».
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Создаёт последовательность эффектов для этой кнопки.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Создаёт пользовательский путь. Наш объект будет перемещён только после нажатия кнопки.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Добавляет команды перемещения, так как созданный путь пуст.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Записывает файл PPTX на диск
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получение анимационных эффектов, применённых к Shape**

Следующие примеры показывают, как использовать метод `getEffectsByShape` из класса [Sequence](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/) для получения всех анимационных эффектов, применённых к фигуре.

**Пример 1: Получение анимационных эффектов, применённых к фигуре на обычном слайде**

Ранее вы узнали, как добавлять анимационные эффекты к фигурам в презентациях PowerPoint. Приведённый пример кода показывает, как получить эффекты, применённые к первой фигуре на первом обычном слайде в презентации `AnimExample_out.pptx`.
```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Получает основную последовательность анимаций слайда.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Получает первую фигуру на первом слайде.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Получает анимационные эффекты, применённые к фигуре.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


**Пример 2: Получение всех анимационных эффектов, включающих унаследованные из заполнителей**

Если у фигуры на обычном слайде есть заполнитель(и), которые находятся на слайде макета и/или главном слайде, и к этим заполнителям добавлены анимационные эффекты, то все эффекты фигуры будут воспроизводиться во время показа слайдов, включая унаследованные из заполнителей.

Допустим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только форму нижнего колонтитула с текстом "Made with Aspose.Slides" и к которой применён эффект **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Также предположим, что эффект **Split** применён к заполнителю нижнего колонтитула на слайде **layout**.

![Layout shape animation effect](layout-shape-animation.png)

И, наконец, эффект **Fly In** применён к заполнителю нижнего колонтитула на слайде **master**.

![Master shape animation effect](master-shape-animation.png)

Следующий пример кода показывает, как использовать метод `getBasePlaceholder` из класса [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) для доступа к заполнителям фигуры и получения анимационных эффектов, применённых к фигуре нижнего колонтитула, включая унаследованные из заполнителей, расположенных на слайдах макета и главного слайда.
```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Получить анимационные эффекты фигуры на обычном слайде.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Получить анимационные эффекты заполнителя на слайде макета.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Получить анимационные эффекты заполнителя на главном слайде.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```

```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```


Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Полёт, снизу
Type: 134, subtype: 45            // Разделить, вертикально внутрь
Type: 126, subtype: 22            // Случайные полосы, горизонтальные
```


## **Методы изменения времени анимационного эффекта**

Aspose.Slides для PHP через Java позволяет изменять свойства Timing (тайминг) анимационного эффекта.

Это панель Animation Timing в Microsoft PowerPoint:

![example1_image](shape-animation.png)

- Выпадающий список **Start** в PowerPoint Timing соответствует методу [Timing::getTriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getTriggerType).
- Выпадающий список **Duration** в PowerPoint Timing соответствует методу [Timing::getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getDuration). Длительность анимации (в секундах) — это общее время, за которое анимация завершает один цикл.
- Выпадающий список **Delay** в PowerPoint Timing соответствует методу [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getTriggerDelayTime).

Так вы изменяете свойства Timing эффекта:

1. [Apply](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите необходимые новые значения, используя метод [Effect::getTiming](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#getTiming).
3. Сохраните изменённый файл PPTX.

Этот PHP‑код демонстрирует операцию:
```php
  # Создает экземпляр класса презентации, представляющего файл презентации.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Получает основную последовательность слайда.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Получает первый эффект основной последовательности.
    $effect = $sequence->get_Item(0);
    # Изменяет тип триггера эффекта на запуск по клику
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Изменяет длительность эффекта
    $effect->getTiming()->setDuration(3.0);
    # Изменяет задержку триггера эффекта
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Сохраняет файл PPTX на диск
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Звук анимационного эффекта**

Aspose.Slides предоставляет эти методы для работы со звуками в анимационных эффектах:

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Добавить звук анимационного эффекта**

Этот PHP‑код показывает, как добавить звук анимационного эффекта и остановить его, когда начинается следующий эффект:
```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Добавляет аудио в коллекцию аудио презентации
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # Получает основную последовательность слайда.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Получает первый эффект основной последовательности
    $firstEffect = $sequence->get_Item(0);
    # Проверяет эффект на отсутствие звука
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Добавляет звук к первому эффекту
      $firstEffect->setSound($effectSound);
    }
    # Получает первую интерактивную последовательность слайда.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Устанавливает флаг эффекта «Остановить предыдущий звук»
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Записывает файл PPTX на диск
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Извлечь звук анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу. 
3. Получите основную последовательность эффектов. 
4. Извлеките встроенный в каждый анимационный эффект [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-).

Этот PHP‑код показывает, как извлечь звук, вложенный в анимационный эффект:
```php
  # Создает экземпляр класса презентации, представляющего файл презентации.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Получает основную последовательность слайда.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Извлекает звук эффекта в массив байтов
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **После анимации**

Aspose.Slides для PHP через Java позволяет изменять свойство After animation (после анимации) анимационного эффекта.

![example1_image](shape-after-animation.png)

Выпадающий список PowerPoint Effect **After animation** соответствует этим методам: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAfterAnimationType)‑ метод, описывающий тип After animation:
  * В PowerPoint **More Colors** соответствует типу [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color);
  * В PowerPoint пункт **Don't Dim** соответствует типу [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (тип после анимации по умолчанию);
  * В PowerPoint пункт **Hide After Animation** соответствует типу [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * В PowerPoint пункт **Hide on Next Mouse Click** соответствует типу [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAfterAnimationColor)‑ метод, определяющий цвет после анимации. Этот метод работает вместе с типом [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color). Если вы измените тип на другой, цвет после анимации будет очищен.

Этот PHP‑код показывает, как изменить эффект After animation:
```php
  # Создает экземпляр класса презентации, представляющего файл презентации
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Получает первый эффект основной последовательности
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Изменяет тип After animation на Color
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Устанавливает цвет затемнения After animation
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Записывает файл PPTX на диск
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Анимировать текст**

Aspose.Slides предоставляет следующие методы для работы с блоком *Animate text* анимационного эффекта:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAnimateTextType)‑ описывает тип анимированного текста эффекта. Текст фигуры может анимироваться:
  * Все сразу ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce) тип)
  * По словам ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord) тип)
  * По буквам ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter) тип)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setDelayBetweenTextParts)‑ задаёт задержку между анимированными частями текста (словами или буквами). Положительное значение задаёт процент длительности эффекта. Отрицательное значение задаёт задержку в секундах.

Так вы меняете свойства Animate text эффекта:

1. [Apply](#apply-animation-to-shape) или получите анимационный эффект.
2. Используйте метод [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/textanimation/#setBuildType) и значение [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) для отключения режима анимации *By Paragraphs*.
3. Установите новые значения, используя методы [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAnimateTextType) и [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setDelayBetweenTextParts).
4. Сохраните изменённый файл PPTX.

Этот PHP‑код демонстрирует операцию:
```php
  # Создает экземпляр класса презентации, представляющего файл презентации.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Получает первый эффект основной последовательности
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Изменяет тип текстовой анимации эффекта на "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Изменяет тип анимации текста эффекта на "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Устанавливает задержку между словами в 20% длительности эффекта
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Записывает файл PPTX на диск
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Как я могу обеспечить сохранение анимаций при публикации презентации в веб?**

[Export to HTML5](/slides/ru/php-java/export-to-html5/) и включите [options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) , отвечающие за анимацию [shape](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) и [transition](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/). Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5‑версия делает.

**Как изменение порядка слоёв (z-order) фигур влияет на анимацию?**

Анимация и порядок рисования независимы: эффект контролирует время и тип появления/исчезновения, а [z-order](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) определяет, что что накладывает. Видимый результат формируется их комбинацией. (Это общее поведение PowerPoint; модель Aspose.Slides effects-and-shapes следует той же логике.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**

В общем случае [animations are supported](/slides/ru/php-java/convert-powerpoint-to-video/), но редкие случаи или специфические эффекты могут отображаться иначе. Рекомендуется тестировать используемые эффекты и версию библиотеки.