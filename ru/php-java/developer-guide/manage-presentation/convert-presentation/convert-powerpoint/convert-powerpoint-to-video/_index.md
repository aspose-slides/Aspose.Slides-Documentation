---
title: Конвертировать презентации PowerPoint в видео на PHP
linktitle: PowerPoint в видео
type: docs
weight: 130
url: /ru/php-java/convert-powerpoint-to-video/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в видео
- презентация в видео
- PPT в видео
- PPTX в видео
- PowerPoint в MP4
- презентация в MP4
- PPT в MP4
- PPTX в MP4
- сохранить PPT как MP4
- сохранить PPTX как MP4
- экспортировать PPT в MP4
- экспортировать PPTX в MP4
- конвертация видео
- PowerPoint
- PHP
- Aspose.Slides
description: "Узнайте, как конвертировать презентации PowerPoint в видео с помощью Aspose.Slides для PHP. Откройте примеры кода и техники автоматизации для оптимизации вашего рабочего процесса."
---

Преобразовав вашу презентацию PowerPoint в видео, вы получаете 

* **Повышение доступности:** Все устройства (независимо от платформы) по умолчанию оснащены видеоплеерами, в отличие от приложений для открытия презентаций, поэтому пользователям проще открывать или воспроизводить видео.
* **Более широкая аудитория:** С помощью видео вы можете охватить большую аудиторию и предоставить им информацию, которая иначе могла бы показаться утомительной в презентации. Большинство опросов и статистических данных показывают, что люди смотрят и потребляют видео чаще, чем другие формы контента, и они обычно предпочитают такой контент.

{{% alert color="primary" %}} 
Возможно, вам будет интересен наш [**Онлайн-конвертер PowerPoint в видео**](https://products.aspose.app/slides/conversion/ppt-to-word), так как это живой и эффективный пример реализации описанного процесса.
{{% /alert %}} 

## **Конвертация PowerPoint в видео в Aspose.Slides**

В [Aspose.Slides 22.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-22-11-release-notes/) мы реализовали поддержку конвертации презентаций в видео.

* Используйте **Aspose.Slides** для генерации набора кадров (из слайдов презентации), соответствующих определённому FPS (кадрам в секунду)
* Используйте стороннюю утилиту, например **ffmpeg** ([для java](https://github.com/bramp/ffmpeg-cli-wrapper)), чтобы создать видео на основе этих кадров.

### **Конвертировать PowerPoint в видео**

1. Добавьте следующее в ваш файл POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```php

```


2. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html).

4. Запустите PHP‑код для конвертации PowerPoint в видео.

Этот PHP‑код демонстрирует, как конвертировать презентацию (содержащую рисунок и два анимационных эффекта) в видео:
```php
  $presentation = new Presentation();
  try {
    # Добавляет форму улыбки и анимирует её
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
    # Настраивает каталог бинарных файлов ffmpeg. См. эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```


## **Видеоэффекты**

Вы можете применять анимацию к объектам на слайдах и использовать переходы между слайдами. 

{{% alert color="primary" %}} 
Возможно, вам будет интересно ознакомиться со следующими статьями: [Анимация PowerPoint](https://docs.aspose.com/slides/php-java/powerpoint-animation/), [Анимация фигур](https://docs.aspose.com/slides/php-java/shape-animation/), и [Эффекты фигур](https://docs.aspose.com/slides/php-java/shape-effect/).
{{% /alert %}} 

Анимации и переходы делают слайдшоу более захватывающими и интересными — и то же самое происходит с видео. Добавим ещё один слайд и переход в код для предыдущей презентации:
```php
  # Добавляет форму улыбки и анимирует её
  # ...
  # Добавляет новый слайд и анимированный переход
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);
```


Aspose.Slides также поддерживает анимацию текста. Поэтому мы анимируем абзацы на объектах, которые будут появляться один за другим (с задержкой в одну секунду):
```php
  $presentation = new Presentation();
  try {
    # Добавляет текст и анимацию
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 120, 300, 300);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Aspose Slides for Java"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("convert PowerPoint Presentation with text to video"));
    $para3 = new Paragraph();
    $para3->getPortions()->add(new Portion("paragraph by paragraph"));
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
    # Настраивает папку бинарных файлов ffmpeg. См. эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```


## **Классы конвертации видео**

Чтобы вы могли выполнять задачи по конвертации PowerPoint в видео, Aspose.Slides предоставляет классы [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) и [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/).

Класс [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) позволяет задать размер кадра для будущего видео через конструктор. Если передать экземпляр презентации, будет использован `Presentation.SlideSize`, и он генерирует анимацию, которую использует [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/).

При генерации анимаций создаётся событие `NewAnimation` для каждой последующей анимации, которое содержит параметр [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/). Этот параметр представляет класс, отвечающий за воспроизведение отдельной анимации.

Для работы с [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/) используются свойство [Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#getDuration--) (полная продолжительность анимации) и метод [SetTimePosition](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Каждая позиция задаётся в диапазоне от *0 до длительности*, после чего метод `GetFrame` возвращает `BufferedImage`, соответствующее состоянию анимации в данный момент:
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
        echo(sprintf("Animation total duration: %f", $animationPlayer->getDuration()));
        $animationPlayer->setTimePosition(0);// начальное состояние анимации
        try {
            # bitmap начального состояния анимации
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// конечное состояние анимации
        try {
            # последний кадр анимации
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # Добавляет форму улыбки и анимирует её
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


Чтобы все анимации в презентации воспроизводились одновременно, используется класс [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/). Этот класс принимает экземпляр [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) и FPS для эффектов в конструкторе, а затем вызывает событие `FrameTick` для всех анимаций, чтобы они были воспроизведены:
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


Затем сгенерированные кадры можно собрать в видеоролик. См. раздел [Convert PowerPoint to Video](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Поддерживаемые анимации и эффекты**

**Entrance**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Fade** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Fly In** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Float In** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Split** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Wipe** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Shape** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Wheel** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Random Bars** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Grow & Turn** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Zoom** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Swivel** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Bounce** | ![поддерживается](v.png) | ![поддерживается](v.png) |

**Emphasis**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Color Pulse** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Teeter** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Spin** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Grow/Shrink** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Desaturate** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Darken** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Lighten** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Transparency** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Object Color** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Complementary Color** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Line Color** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Fill Color** | ![не поддерживается](x.png) | ![поддерживается](v.png) |

**Exit**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Fade** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Fly Out** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Float Out** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Split** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Wipe** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Shape** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Random Bars** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Shrink & Turn** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Zoom** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Swivel** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Bounce** | ![поддерживается](v.png) | ![поддерживается](v.png) |

**Motion Paths**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Arcs** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Turns** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Shapes** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Loops** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Custom Path** | ![поддерживается](v.png) | ![поддерживается](v.png) |

## **FAQ**

**Можно ли конвертировать презентации, защищённые паролем?**

Да, Aspose.Slides позволяет работать с [презентациями, защищёнными паролем](/slides/ru/php-java/password-protected-presentation/). При обработке таких файлов необходимо указать правильный пароль, чтобы библиотека могла получить доступ к содержимому презентации.

**Поддерживает ли Aspose.Slides использование в облачных решениях?**

Да, Aspose.Slides можно интегрировать в облачные приложения и сервисы. Библиотека разработана для работы в серверных окружениях, обеспечивая высокую производительность и масштабируемость при пакетной обработке файлов.

**Есть ли ограничения по размеру презентаций при конвертации?**

Aspose.Slides способна обрабатывать презентации практически любого размера. Однако при работе с очень большими файлами может потребоваться дополнительный объём системных ресурсов, и иногда рекомендуется оптимизировать презентацию для повышения производительности.