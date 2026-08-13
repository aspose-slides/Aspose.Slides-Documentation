---
title: Преобразование презентаций PowerPoint в видео на Java
linktitle: PowerPoint в видео
type: docs
weight: 130
url: /ru/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "Узнайте, как конвертировать презентации PowerPoint в видео на Java. Ознакомьтесь с примерами кода и методами автоматизации для оптимизации вашего рабочего процесса."
---
## **Введение**

Преобразуя вашу презентацию PowerPoint или OpenDocument в видео, вы получаете:

**Повышенная доступность:** Все устройства, независимо от платформы, по умолчанию оснащены видеоплеерами, что упрощает пользователям открытие и воспроизведение видео по сравнению с традиционными приложениями для презентаций.

**Широкий охват:** Видео позволяют охватить большую аудиторию и представить информацию в более увлекательном формате. Опросы и статистика показывают, что люди предпочитают смотреть и потреблять видеоконтент, чем другие формы, что делает ваше сообщение более эффектным.

{{% alert color="info" %}} 
Возможно, вам стоит ознакомиться с нашим [**Конвертером PowerPoint в видео онлайн**](https://products.aspose.app/slides/ru/video), поскольку это живой и эффективный пример реализованного здесь процесса.
{{% /alert %}} 

## **Конвертация PowerPoint в видео в Aspose.Slides**

В [Aspose.Slides 22.11](https://docs.aspose.com/slides/ru/java/aspose-slides-for-java-22-11-release-notes/), мы добавили поддержку преобразования презентаций в видео. 

* Используйте **Aspose.Slides** для генерации набора кадров (из слайдов презентации), соответствующих определённому FPS (кадров в секунду)
* Используйте стороннюю утилиту, например **ffmpeg** ([для java](https://github.com/bramp/ffmpeg-cli-wrapper)), чтобы создать видео на основе этих кадров. 

### **Преобразовать PowerPoint в видео**

1. Добавьте следующее в ваш файл POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html).

4. Запустите код Java для конвертации PowerPoint в видео.

Этот Java‑код показывает, как преобразовать презентацию (с фигурой и двумя анимационными эффектами) в видео:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Добавляет форму улыбки и затем анимирует её
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Настраивает папку с бинарными файлами ffmpeg. См. эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Видеоэффекты**

Вы можете применять анимацию к объектам на слайдах и использовать переходы между слайдами. 

{{% alert color="info" %}} 
Обратите внимание на эти статьи: [Анимация PowerPoint](https://docs.aspose.com/slides/ru/java/powerpoint-animation/), [Анимация фигур](https://docs.aspose.com/slides/ru/java/shape-animation/), и [Эффекты фигур](https://docs.aspose.com/slides/ru/java/shape-effect/).
{{% /alert %}} 

Анимации и переходы делают демонстрации более увлекательными и интересными — то же самое относится и к видео. Добавим ещё один слайд и переход в код предыдущей презентации:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // Добавляет форму улыбки и анимирует её

    // ...

    // Добавляет новый слайд и анимированный переход

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides также поддерживает анимацию текста. Мы анимируем абзацы в объектах, которые будут появляться последовательно (задержка в одну секунду):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Добавляет текст и анимации
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Настраивает папку с бинарными файлами ffmpeg. См. эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Классы для конвертации видео**

Чтобы вы могли выполнять задачи конвертации PowerPoint в видео, Aspose.Slides предоставляет классы [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationanimationsgenerator/) и [PresentationPlayer](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationanimationsgenerator/) позволяет задать размер кадра для будущего видео через конструктор. Если передать экземпляр презентации, будет использован `Presentation.SlideSize`, а генерируемые анимации использует [PresentationPlayer](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationplayer/). 

При генерации анимаций для каждой последующей анимации создаётся событие `NewAnimation` с параметром [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationanimationplayer/). Этот класс представляет проигрыватель отдельной анимации.

Для работы с [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationanimationplayer/) используются свойство [Duration](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (полная длительность анимации) и метод [SetTimePosition](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Позиция каждой анимации задаётся в диапазоне *0 до длительности*, после чего метод `getFrame` возвращает [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/), соответствующий состоянию анимации в данный момент:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Добавляет форму улыбки и анимирует её
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));

            animationPlayer.setTimePosition(0); // начальное состояние анимации
            // битмап начального состояния анимации
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // конечное состояние анимации
            // последний кадр анимации
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // генерировать анимации - это то, что вызывает события, обработанные выше
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Чтобы все анимации в презентации воспроизводились одновременно, используется класс [PresentationPlayer](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationplayer/). Он принимает экземпляр [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentationanimationsgenerator/) и FPS для эффектов в конструкторе, а затем вызывает событие `FrameTick` для всех анимаций, чтобы они начали воспроизводиться:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Сгенерированные кадры затем можно собрать в видео. Смотрите раздел [Конвертировать PowerPoint в видео](https://docs.aspose.com/slides/ru/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Поддерживаемые анимации и эффекты**

**Вход**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Акцент**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Выход**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Траектории движения:**

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### Можно ли конвертировать презентации, защищённые паролем?

Да, Aspose.Slides позволяет работать с [презентациями, защищёнными паролем](/slides/ru/java/password-protected-presentation/). При обработке таких файлов необходимо указать правильный пароль, чтобы библиотека могла получить доступ к содержимому презентации.

### Поддерживает ли Aspose.Slides использование в облачных решениях?

Да, Aspose.Slides можно интегрировать в облачные приложения и сервисы. Библиотека разработана для работы в серверных средах, обеспечивая высокую производительность и масштабируемость при пакетной обработке файлов.

### Существуют ли ограничения по размеру презентаций при конвертации?

Aspose.Slides способен обрабатывать презентации практически любого размера. Однако при работе с очень большими файлами могут потребоваться дополнительные системные ресурсы, и иногда рекомендуется оптимизировать презентацию для повышения производительности.