---
title: Анимация Форм
type: docs
weight: 60
url: /ru/php-java/shape-animation/
keywords: "анимация PowerPoint, эффект анимации, применить анимацию, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Применить анимацию PowerPoint"
---

Анимации — это визуальные эффекты, которые можно применять к текстам, изображениям, фигурам или [диаграммам](https://docs.aspose.com/slides/php-java/animated-charts/). Они оживляют презентации или их составные части.

### **Почему стоит использовать анимации в презентациях?**

С помощью анимаций вы можете

* контролировать поток информации
* подчеркивать важные моменты
* увеличивать интерес или участие вашей аудитории
* облегчать восприятие или усвоение материала
* привлекать внимание ваших читателей или зрителей к важным частям презентации

PowerPoint предоставляет множество вариантов и инструментов для анимаций и эффектов анимации в категориях **вход**, **выход**, **акцент** и **движущиеся пути**.

### **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями в пространстве имен `Aspose.Slides.Animation`,
* Aspose.Slides предоставляет более **150 эффектов анимации** в перечислении [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype). Эти эффекты по сути такие же (или эквивалентные), как и эффекты, используемые в PowerPoint.

## **Применить анимацию к TextBox**

Aspose.Slides для PHP через Java позволяет вам применять анимацию к тексту в фигуре.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).
4. Добавьте текст к [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Получите основную последовательность эффектов.
6. Добавьте эффект анимации к [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).
7. Установите свойство `TextAnimation.BuildType` в значение из перечисления `BuildType`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот код PHP показывает, как применить эффект `Fade` к AutoShape и установить анимацию текста на значение *По 1-му уровню абзацев*:

```php
  # Создает экземпляр класса презентации, представляющего файл презентации.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Добавляет новую AutoShape с текстом
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Первый абзац \nВторой абзац \nТретий абзац");
    # Получает основную последовательность слайда.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Добавляет эффект анимации Fade к фигуре
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Анимирует текст фигуры по 1-му уровню абзацев
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

Кроме применения анимаций к тексту, вы также можете применять анимации к отдельному [абзацу](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph). См. [**Анимированный текст**](/slides/ru/php-java/animated-text/).

{{% /alert %}} 

## **Применить анимацию к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) на слайде.
4. Получите основную последовательность эффектов.
5. Добавьте эффект анимации к [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe).
6. Запишите презентацию на диск в виде файла PPTX.

Этот код PHP показывает, как применить эффект `Fly` к рамке изображения:

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
    # Добавляет эффект анимации Fly излево к рамке изображения
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

## **Применить анимацию к фигуре**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) (когда на этот объект щелкают, анимация воспроизводится).
5. Создайте последовательность эффектов на фигуре с закругленными краями.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды для перемещения по `UserPath`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот код PHP показывает, как применить эффект `PathFootball` (футбольная траектория) к фигуре:

```php
  # Создает экземпляр класса презентации, представляющего файл PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Создает эффект PathFootball для существующей фигуры с нуля.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Анимированный TextBox");
    # Добавляет эффект анимации PathFootBall
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Создает своего рода "кнопку".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Создает последовательность эффектов для этой кнопки.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Создает пользовательский путь. Наш объект будет перемещаться только после нажатия на кнопку.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Добавляет команды для перемещения, так как созданный путь пуст.
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

## **Получить примененные эффекты анимации к фигуре**

Вы можете решить узнать все эффекты анимации, примененные к одной фигуре.

Этот код PHP показывает, как получить все эффекты, примененные к конкретной фигуре:

```php
  # Создает экземпляр класса презентации, представляющего файл презентации.
  $pres = new Presentation("AnimExample_out.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Получает основную последовательность слайда.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Получает первую фигуру на слайде.
    $shape = $firstSlide->getShapes()->get_Item(0);
    # Получает все эффекты анимации, примененные к фигуре.
    $shapeEffects = $sequence->getEffectsByShape($shape);
    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("Фигура " . $shape->getName() . " имеет " . $Array->getLength($shapeEffects) . " эффекта анимации.");
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Изменить свойства времени эффекта анимации**

Aspose.Slides для PHP через Java позволяет вам изменять временные свойства эффекта анимации.

Это панель времени анимации в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Вот соответствия между временем PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) :

- Выпадающий список **Начало** времени PowerPoint соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--) .
- **Продолжительность** времени PowerPoint соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--) . Продолжительность анимации (в секундах) — это общее время, необходимое для завершения одного цикла анимации.
- **Задержка** времени PowerPoint соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--) .

Вот как вы изменить свойства времени эффекта:

1. [Примените](#apply-animation-to-shape) или получите эффект анимации.
2. Установите новые значения для необходимых вам свойств [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) .
3. Сохраните измененный файл PPTX.

Этот код PHP демонстрирует операцию:

```php
  # Создает экземпляр класса презентации, представляющего файл презентации.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Получает основную последовательность слайда.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Получает первый эффект основной последовательности.
    $effect = $sequence->get_Item(0);
    # Изменяет TriggerType эффекта на "сначала после нажатия"
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Изменяет продолжительность эффекта
    $effect->getTiming()->setDuration(3.0);
    # Изменяет TriggerDelayTime эффекта
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Сохраняет файл PPTX на диск
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Звук эффекта анимации**

Aspose.Slides предоставляет следующие свойства, чтобы вы могли работать со звуками в эффектах анимации: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Добавить звук эффекта анимации**

Этот код PHP показывает, как добавить звук к эффекту анимации и остановить его, когда начнется следующий эффект:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Добавляет аудио в коллекцию аудиофайлов презентации
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
    # Проверяет эффект на "Без звука"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Добавляет звук для первого эффекта
      $firstEffect->setSound($effectSound);
    }
    # Получает первую интерактивную последовательность слайда.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Устанавливает эффект "Остановить предыдущий звук"
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Записывает файл PPTX на диск
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Извлечь звук эффекта анимации**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Получите основную последовательность эффектов. 
4. Извлеките [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) звук, встроенный в каждый эффект анимации.

Этот код PHP показывает, как извлечь звук, встроенный в эффект анимации:

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
      # Извлекает звук эффекта в массиве байтов
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **После анимации**

Aspose.Slides для PHP через Java позволяет вам изменять свойства "После анимации" эффекта анимации.

Это панель эффектов анимации и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список **После анимации** эффекта PowerPoint соответствует следующим свойствам: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-) свойство, которое описывает тип после анимации :
  * PowerPoint **Дополнительные цвета** соответствует типу [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) ;
  * Элемент списка PowerPoint **Не затемнять** соответствует типу [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (тип по умолчанию после анимации);
  * Элемент PowerPoint **Скрыть после анимации** соответствует типу [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) ;
  * Элемент PowerPoint **Скрыть при следующем щелчке мышью** соответствует типу [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) ;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) свойство, которое определяет цвет после эффектов анимации. Это свойство работает в сочетании с типом [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) . Если вы измените тип на другой, цвет после анимации будет очищен.

Этот код PHP показывает, как изменить эффект после анимации:

```php
  # Создает экземпляр класса презентации, представляющего файл презентации.
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Получает первый эффект основной последовательности
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Изменяет тип анимации после нажатия на цвет
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Устанавливает цвет затемнения после анимации
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

Aspose.Slides предоставляет следующие свойства, позволяющие вам работать с блоком *Анимация текста* эффекта анимации:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) , который описывает тип анимации текста эффекта. Текст фигуры может быть анимирован:
  - Все сразу ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce) тип)
  - По словам ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord) тип)
  - По буквам ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter) тип)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) задает задержку между анимированными частями текста (словами или буквами). Положительное значение указывает на процент от длительности эффекта. Отрицательное значение указывает задержку в секундах.

Вот как вы можете изменить свойства анимации текста эффекта:

1. [Примените](#apply-animation-to-shape) или получите эффект анимации.
2. Установите свойство [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/itextanimation/#setBuildType-int-) в значение [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) , чтобы отключить режим анимации *По абзацам*.
3. Установите новые значения для свойств [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) и [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .
4. Сохраните измененный файл PPTX.

Этот код PHP демонстрирует операцию:

```php
  # Создает экземпляр класса презентации, представляющего файл презентации.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Получает первый эффект основной последовательности
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Изменяет тип анимации текста эффекта на "Как один объект"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Изменяет тип анимации текста эффекта на "По словам"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Устанавливает задержку между словами на 20% от длительности эффекта
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Записывает файл PPTX на диск
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```