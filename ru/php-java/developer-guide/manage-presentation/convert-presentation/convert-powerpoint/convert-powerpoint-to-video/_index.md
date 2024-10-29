---
title: Конвертация PowerPoint в видео
type: docs
weight: 130
url: /ru/php-java/convert-powerpoint-to-video/
keywords: "Конвертировать PowerPoint, PPT, PPTX, Презентация, Видео, MP4, PPT в видео, PPT в MP4, Java, Aspose.Slides"
description: "Конвертация PowerPoint в видео "
---

Преобразуя вашу презентацию PowerPoint в видео, вы получаете

* **Увеличение доступности:** Все устройства (независимо от платформы) по умолчанию оснащены видеоплеерами по сравнению с приложениями для открытия презентаций, поэтому пользователям проще открывать или воспроизводить видео.
* **Больше охвата:** С помощью видео вы можете достичь широкой аудитории и нацелить информацию, которая в противном случае могла бы показаться утомительной в презентации. Большинство опросов и статистики показывают, что люди смотрят и потребляют видео больше, чем другие формы контента, и они в целом предпочитают такой контент.

{{% alert color="primary" %}} 

Вам может быть интересно проверить наш [**Онлайн-конвертер PowerPoint в видео**](https://products.aspose.app/slides/conversion/ppt-to-word), поскольку это живая и эффективная реализация процесса, описанного здесь.

{{% /alert %}} 

## **Конвертация PowerPoint в видео с помощью Aspose.Slides**

В [Aspose.Slides 22.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-22-11-release-notes/) мы реализовали поддержку конвертации презентаций в видео.

* Используйте **Aspose.Slides** для генерации набора кадров (из слайдов презентации), которые соответствуют определенному FPS (кадров в секунду)
* Используйте стороннюю утилиту, такую как **ffmpeg** ([для Java](https://github.com/bramp/ffmpeg-cli-wrapper)), для создания видео на основе кадров.

### **Конвертация PowerPoint в видео**

1. Добавьте это в ваш POM файл:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```php

```

2. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html).

4. Запустите PHP-код для конвертации PowerPoint в видео.

Этот PHP-код показывает, как конвертировать презентацию (содержащую фигуру и два анимационных эффекта) в видео:

```php
  $presentation = new Presentation();
  try {
    # Добавляет фигуру улыбки и затем анимирует ее
    $smile = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::SmileyFace, 110, 20, 500, 500);
    $mainSequence = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $effectIn = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubType::TopLeft, EffectTriggerType::AfterPrevious);
    $effectOut = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubType::BottomRight, EffectTriggerType::AfterPrevious);
    $effectIn->getTiming()->setDuration(2.0);
    $effectOut->setPresetClassType(EffectPresetClassType::Exit);
    $fps = 33;

    class FrameTick {
      function invoke($sender, $arg) {
            try {
                $frame = sprintf("frame_%04d.png", $sender->getFrameIndex());
                $arguments->getFrame()->save($frame, ImageFormat::Png);
                $frames->add($frame);
                } catch (JavaException $e) {
                  }
             }
    }

    $frames = new Java("java.util.ArrayList");
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    try {
      $player = new PresentationPlayer($animationsGenerator, $fps);
      try {
        $frameTick = java_closure(new FrameTick(), null, java("com.aspose.slides.PresentationPlayerFrameTick"));
        $player->setFrameTick($frameTick);
        $animationsGenerator->run($presentation->getSlides());
      } finally {
        if (!java_is_null($player)) {
          $player->dispose();
        }
      }
    } finally {
      if (!java_is_null($animationsGenerator)) {
        $animationsGenerator->dispose();
      }
    }
    # Настройте папку с бинарными файлами ffmpeg. См. эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```

## **Видеоеффекты**

Вы можете применять анимации к объектам на слайдах и использовать переходы между слайдами. 

{{% alert color="primary" %}} 

Вам могут быть интересны эти статьи: [Анимация PowerPoint](https://docs.aspose.com/slides/php-java/powerpoint-animation/), [Анимация фигур](https://docs.aspose.com/slides/php-java/shape-animation/) и [Эффект фигур](https://docs.aspose.com/slides/php-java/shape-effect/).

{{% /alert %}} 

Анимации и переходы делают слайд-шоу более увлекательным и интересным, и они делают то же самое для видео. Давайте добавим еще один слайд и переход в код для предыдущей презентации:

```php
  # Добавляет фигуру улыбки и анимирует ее
  # ...
  # Добавляет новый слайд и анимированный переход
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);

```

Aspose.Slides также поддерживает анимацию для текстов. Таким образом, мы анимируем параграфы на объектах, которые будут появляться один за другим (с заданной задержкой в одну секунду):

```php
  $presentation = new Presentation();
  try {
    # Добавляет текст и анимации
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 120, 300, 300);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Aspose Slides для Java"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("конвертировать презентацию PowerPoint с текстом в видео"));
    $para3 = new Paragraph();
    $para3->getPortions()->add(new Portion("параграф за параграфом"));
    $paragraphCollection = $autoShape->getTextFrame()->getParagraphs();
    $paragraphCollection->add($para1);
    $paragraphCollection->add($para2);
    $paragraphCollection->add($para3);
    $paragraphCollection->add(new Paragraph());
    $mainSequence = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $effect1 = $mainSequence->addEffect($para1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect2 = $mainSequence->addEffect($para2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect3 = $mainSequence->addEffect($para3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect4 = $mainSequence->addEffect($para3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect1->getTiming()->setTriggerDelayTime(1.0);
    $effect2->getTiming()->setTriggerDelayTime(1.0);
    $effect3->getTiming()->setTriggerDelayTime(1.0);
    $effect4->getTiming()->setTriggerDelayTime(1.0);
    $fps = 33;

    class FrameTick {
      function invoke($sender, $arg) {
            try {
                $frame = sprintf("frame_%04d.png", $sender->getFrameIndex());
                $arguments->getFrame()->save($frame, ImageFormat::Png);
                $frames->add($frame);
                } catch (JavaException $e) {
                  }
             }
    }

    $frames = new Java("java.util.ArrayList");
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    try {
      $player = new PresentationPlayer($animationsGenerator, $fps);
      try {
        $frameTick = java_closure(new FrameTick(), null, java("com.aspose.slides.PresentationPlayerFrameTick"));
        $player->setFrameTick($frameTick);
        $animationsGenerator->run($presentation->getSlides());
      } finally {
        if (!java_is_null($player)) {
          $player->dispose();
        }
      }
    } finally {
      if (!java_is_null($animationsGenerator)) {
        $animationsGenerator->dispose();
      }
    }
    # Настройте папку с бинарными файлами ffmpeg. См. эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```

## **Классы для конвертации видео**

Чтобы позволить вам выполнять задачи конвертации PowerPoint в видео, Aspose.Slides предоставляет классы [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) и [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) позволяет вам установить размер кадра для видео (которое будет создано позже) через свой конструктор. Если вы передадите экземпляр презентации, будет использован `Presentation.SlideSize`, и он генерирует анимации, которые использует [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/).

Когда анимации сгенерированы, для каждой последующей анимации генерируется событие `NewAnimation`, которое имеет параметр [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/). Последний является классом, который представляет плеер для отдельной анимации.

Для работы с [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/) используются свойства [Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#getDuration--) (общая продолжительность анимации) и метод [SetTimePosition](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Каждая позиция анимации устанавливается в диапазоне *0 до продолжительности*, а затем метод `GetFrame` вернет BufferedImage, который соответствует состоянию анимации в этот момент:

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationPlayer;
use aspose\slides\PresentationAnimationsGenerator;
use aspose\slides\ImageFormat;
use aspose\slides\ShapeType;
use aspose\slides\EffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectPresetClassType;

class PresentationAnimationPlayer {
    function invoke($animationPlayer) {
        echo(sprintf("Общая продолжительность анимации: %f", $animationPlayer->getDuration()));
        $animationPlayer->setTimePosition(0);// начальное состояние анимации
        try {
            # битмап начального состояния анимации
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// финальное состояние анимации
        try {
            # последний кадр анимации
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # Добавляет фигуру улыбки и анимирует ее
    $smile = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::SmileyFace, 110, 20, 500, 500);
    $mainSequence = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $effectIn = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    $effectOut = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    $effectIn->getTiming()->setDuration(2.0);
    $effectOut->setPresetClassType(EffectPresetClassType::Exit);
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    $presentationAnimation=java_closure(new PresentationAnimationPlayer(), null, java("com.aspose.slides.PresentationAnimationsGeneratorNewAnimation"));
    try {
        $animationsGenerator->setNewAnimation($presentationAnimation);
    } finally {
        if (!java_is_null($animationsGenerator)) {
            $animationsGenerator->dispose();
        }
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Чтобы все анимации в презентации воспроизводились одновременно, используется класс [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/). Этот класс принимает экземпляр [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) и FPS для эффектов в своем конструкторе, а затем вызывает событие `FrameTick` для всех анимаций, чтобы их воспроизвести:

```php

class FrameTick {
      function invoke($sender, $arg) {
            try {
                $arguments->getFrame()->save("frame_" . $sender->getFrameIndex() . ".png", ImageFormat::Png);
                } catch (JavaException $e) {
                  }
             }
    }

  $presentation = new Presentation("animated.pptx");
  try {
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    try {
      $player = new PresentationPlayer($animationsGenerator, 33);
      try {
        $frameTick = java_closure(new FrameTick(), null, java("com.aspose.slides.PresentationPlayerFrameTick"));
        $player->setFrameTick($frameTick);
        $animationsGenerator->run($presentation->getSlides());
      } finally {
        if (!java_is_null($player)) {
          $player->dispose();
        }
      }
    } finally {
      if (!java_is_null($animationsGenerator)) {
        $animationsGenerator->dispose();
      }
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Сгенерированные кадры затем могут быть скомпилированы для создания видео. См. раздел [Конвертация PowerPoint в видео](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Поддерживаемые анимации и эффекты**

**Вход:**

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Появление** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Затухание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вход с полета** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вход с параллели** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Разделение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Стирание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Форма** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Колесо** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Случайные полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Увеличение и поворот** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Приближение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Качание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Удар** | ![поддерживается](v.png) | ![поддерживается](v.png) |

**Эмоция:**

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Пульсация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цветовая пульсация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Качание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вращение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Увеличение/уменьшение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Десатурация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Темнение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Освещение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Прозрачность** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет объекта** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Дополнительный цвет** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет линии** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет заполнения** | ![не поддерживается](x.png) | ![поддерживается](v.png) |

**Выход:**

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Исчезновение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Затухание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Выход с полета** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Выход с параллели** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Разделение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Стирание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Форма** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Случайные полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Уменьшение и поворот** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Приближение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Качание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Удар** | ![поддерживается](v.png) | ![поддерживается](v.png) |

**Движущиеся пути:**

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Линии** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Арки** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Повороты** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Формы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Циклы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Пользовательский путь** | ![поддерживается](v.png) | ![поддерживается](v.png) |