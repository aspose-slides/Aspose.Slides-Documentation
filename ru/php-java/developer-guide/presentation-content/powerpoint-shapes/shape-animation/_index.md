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
  - звук эффекта
  - применить анимацию
  - PowerPoint
  - презентация
  - PHP
  - Aspose.Slides
description: "Узнайте, как создавать и настраивать анимацию фигур в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java. Выделяйтесь!"
---

Анимации — это визуальные эффекты, которые можно применять к тексту, изображениям, фигурам или [charts](https://docs.aspose.com/slides/php-java/animated-charts/). Они оживляют презентации и их элементы.

## **Почему использовать анимации в презентациях?**

С помощью анимаций вы можете  

* контролировать поток информации  
* выделять важные моменты  
* повышать интерес или вовлечённость аудитории  
* делать контент легче читаемым, усваиваемым или обрабатываемым  
* привлекать внимание читателей или зрителей к важным частям презентации  

PowerPoint предоставляет множество параметров и инструментов для анимаций и анимационных эффектов в категориях **entrance**, **exit**, **emphasis** и **motion paths**.  

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями в пространстве имён `Aspose.Slides.Animation`,  
* Aspose.Slides содержит более **150 animation effects** в перечислении [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype). Эти эффекты по своей сути совпадают (или эквивалентны) эффектам PowerPoint.

## **Применить анимацию к TextBox**

Aspose.Slides for PHP via Java позволяет применить анимацию к тексту в фигуре.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).  
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Получите основную последовательность эффектов.  
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).  
7. Установите свойство `TextAnimation.BuildType` значением из перечисления `BuildType`.  
8. Запишите презентацию на диск в виде файла PPTX.  

Этот PHP‑код показывает, как применить эффект `Fade` к AutoShape и задать анимацию текста со значением *By 1st Level Paragraphs*:
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

Помимо анимации текста, вы можете анимировать отдельный [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph). Смотрите [**Animated Text**](/slides/ru/php-java/animated-text/).

{{% /alert %}} 

## **Применить анимацию к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) на слайде.  
4. Получите основную последовательность эффектов.  
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe).  
6. Запишите презентацию на диск в виде файла PPTX.  

Этот PHP‑код показывает, как применить эффект `Fly` к рамке изображения:
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
    # Добавляет эффект анимации Fly слева к рамке изображения
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


## **Применить анимацию к Shape**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).  
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) (при щелчке по объекту воспроизводится анимация).  
5. Создайте последовательность эффектов для bevel‑фигуры.  
6. Создайте пользовательский `UserPath`.  
7. Добавьте команды перемещения по `UserPath`.  
8. Запишите презентацию на диск в виде файла PPTX.  

Этот PHP‑код показывает, как применить эффект `PathFootball` (path football) к фигуре:
```php
  # Создает экземпляр класса Presentation, представляющего файл PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Создает эффект PathFootball для существующей фигуры с нуля.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Добавляет анимационный эффект PathFootball
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Создает некую "кнопку".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Создает последовательность эффектов для этой кнопки.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Создает пользовательский путь. Наш объект будет перемещён только после щелчка по кнопке.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Добавляет команды перемещения, так как созданный путь пуст.
    $motionBvh = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBvh->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBvh->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBvh->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Записывает файл PPTX на диск
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получить анимационные эффекты, применённые к Shape**

Ниже приведены примеры использования метода `getEffectsByShape` из класса [Sequence](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/) для получения всех анимационных эффектов, применённых к фигуре.

**Пример 1: Получить анимационные эффекты, применённые к фигуре на обычном слайде**

Ранее вы узнали, как добавить анимационные эффекты к фигурам в презентациях PowerPoint. Следующий пример кода показывает, как получить эффекты, применённые к первой фигуре на первом обычном слайде презентации `AnimExample_out.pptx`.
```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Получает основную последовательность анимации слайда.
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


**Пример 2: Получить все анимационные эффекты, включая унаследованные от заполнителей**

Если фигура на обычном слайде имеет заполнители, находящиеся на слайде‑макете и/или мастере, и к этим заполнителям добавлены анимационные эффекты, то все эффекты фигуры будут воспроизводиться во время показа, включая унаследованные.

Предположим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только нижний колонтитул с текстом «Made with Aspose.Slides», к которому применён эффект **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Также предположим, что к заполнителю нижнего колонтитула на **layout**‑слайде применён эффект **Split**.

![Layout shape animation effect](layout-shape-animation.png)

И, наконец, к заполнителю нижнего колонтитула на **master**‑слайде применён эффект **Fly In**.

![Master shape animation effect](master-shape-animation.png)

Следующий пример кода показывает, как с помощью метода `getBasePlaceholder` из класса [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) получить доступ к заполнителям фигуры и извлечь анимационные эффекты, применённые к фигуре нижнего колонтитула, включая унаследованные от заполнителей на layout‑ и master‑слайдах.
```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Получить анимационные эффекты фигуры на обычном слайде.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Получить анимационные эффекты заполнителя на слайде‑макете.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Получить анимационные эффекты заполнителя на мастер‑слайде.
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
Type: 47, subtype: 2              // Fly, Снизу
Type: 134, subtype: 45            // Split, Вертикальный вход
Type: 126, subtype: 22            // RandomBars, Горизонтальный
```


## **Изменение свойств тайминга анимационного эффекта**

Aspose.Slides for PHP via Java позволяет изменять свойства Timing анимационного эффекта.

Это панель Animation Timing в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Соответствия между таймингом PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--):

- Выпадающий список PowerPoint Timing **Start** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--).  
- Поле PowerPoint Timing **Duration** соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--). Длительность анимации (в секундах) — это общее время выполнения одного цикла.  
- Поле PowerPoint Timing **Delay** соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--).  

Как изменить свойства Timing эффекта:

1. [Apply](#apply-animation-to-shape) или получите анимационный эффект.  
2. Установите новые значения нужных вам свойств [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--).  
3. Сохраните изменённый PPTX‑файл.  

Пример кода на PHP:
```php
  # Создает экземпляр класса презентации, представляющего файл презентации.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Получает основную последовательность слайда.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Получает первый эффект основной последовательности.
    $effect = $sequence->get_Item(0);
    # Изменяет TriggerType эффекта, чтобы запускался по щелчку
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Изменяет длительность эффекта
    $effect->getTiming()->setDuration(3.0);
    # Изменяет время задержки запуска эффекта
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

Aspose.Slides предоставляет следующие свойства для работы со звуками в анимационных эффектах:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Добавить звук к анимационному эффекту**

Этот PHP‑код демонстрирует, как добавить звук к анимационному эффекту и остановить его при запуске следующего эффекта:
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
    # Устанавливает флаг эффекта "Stop previous sound"
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Записывает файл PPTX на диск
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Извлечь звук из анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Получите основную последовательность эффектов.  
4. Извлеките звук, заданный методом [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-), встроенный в каждый анимационный эффект.  

Этот PHP‑код показывает, как извлечь звук, встроенный в анимационный эффект:
```php
  # Создаёт экземпляр класса презентации, представляющего файл презентации.
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


## **After Animation**

Aspose.Slides for PHP via Java позволяет изменять свойство After animation анимационного эффекта.

Это панель Animation Effect и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список PowerPoint Effect **After animation** соответствует следующим свойствам:  

- Свойство [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-) описывает тип After animation:  
  * **More Colors** — тип [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color);  
  * **Don't Dim** — тип [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (значение по умолчанию);  
  * **Hide After Animation** — тип [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * **Hide on Next Mouse Click** — тип [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- Свойство [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) задаёт цвет после анимации и работает совместно с типом [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color). При смене типа цвет будет очищен.  

Пример кода на PHP, меняющий эффект After animation:
```php
  # Создает экземпляр класса презентации, представляющего файл презентации
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Получает первый эффект основной последовательности
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Меняет тип After animation на Color
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


## **Animate Text**

Aspose.Slides предоставляет свойства для работы с блоком *Animate text* анимационного эффекта:  

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) описывает тип анимации текста. Текст фигуры можно анимировать:  
  - Всё сразу ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce))  
  - По словам ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord))  
  - По буквам ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter))  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) задаёт задержку между частями анимированного текста (словами или буквами). Положительное значение указывает процент от длительности эффекта, отрицательное — задержку в секундах.  

Как изменить свойства Effect Animate text:

1. [Apply](#apply-animation-to-shape) или получите анимационный эффект.  
2. Установите свойство [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/itextanimation/#setBuildType-int-) в значение [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject), чтобы отключить режим *By Paragraphs*.  
3. Установите новые значения для свойств [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) и [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. Сохраните изменённый PPTX‑файл.  

Пример кода на PHP:
```php
  # Создаёт экземпляр класса презентации, представляющего файл презентации.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Получает первый эффект основной последовательности
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Изменяет тип анимации текста эффекта на "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Изменяет тип анимации текста эффекта на "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Устанавливает задержку между словами в 20% от длительности эффекта
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Сохраняет файл PPTX на диск
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Как обеспечить сохранность анимаций при публикации презентации в интернете?**

[Export to HTML5](/slides/ru/php-java/export-to-html5/) и включите [options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) отвечающие за анимацию [shape](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) и [transition](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/). Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5 — воспроизводит.

**Как изменение порядка слоёв (z‑order) фигур влияет на анимацию?**

Порядок анимации и порядок отрисовки независимы: эффект контролирует время и тип появления/исчезновения, а [z-order](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) определяет, что покрывает что. Видимый результат формируется их комбинацией. (Это общее поведение PowerPoint; модель Aspose.Slides effects‑and‑shapes следует той же логике.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**

В целом [animations are supported](/slides/ru/php-java/convert-powerpoint-to-video/), но редкие случаи или специфические эффекты могут отображаться иначе. Рекомендуется тестировать используемые эффекты и версию библиотеки.