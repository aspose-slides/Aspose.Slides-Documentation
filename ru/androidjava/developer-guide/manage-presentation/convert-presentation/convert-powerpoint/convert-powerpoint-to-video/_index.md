---
title: Преобразование презентаций PowerPoint в видео на Android
linktitle: PowerPoint в видео
type: docs
weight: 130
url: /ru/androidjava/convert-powerpoint-to-video/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать PPT
- преобразовать PPTX
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
- Android
- Java
- Aspose.Slides
description: "Узнайте, как преобразовать презентации PowerPoint в видео на Java. Откройте образцы кода и методы автоматизации для упрощения вашего рабочего процесса."
---
## **Введение**

Преобразуя вашу презентацию PowerPoint в видео, вы получаете 

* **Повышение доступности:** Все устройства (независимо от платформы) по умолчанию оснащены видеоплеерами, в отличие от приложений для открытия презентаций, поэтому пользователям проще открывать или воспроизводить видео.
* **Больший охват:** С помощью видео вы можете охватить большую аудиторию и донести до неё информацию, которая иначе могла бы показаться скучной в презентации. Большинство опросов и статистических данных показывают, что люди смотрят и потребляют видео чаще, чем другие формы контента, и обычно предпочитают именно его.

## **Конвертация PowerPoint в видео в Aspose.Slides**

Aspose.Slides поддерживает конвертацию презентаций в видео.

* Используйте **Aspose.Slides**, чтобы генерировать набор кадров (из слайдов презентации), соответствующих определенному FPS (кадрам в секунду)
* Используйте стороннюю утилиту, такую как **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)), чтобы создать видео на основе кадров. 

### **Конвертировать PowerPoint в видео**

1. Добавьте это в ваш файл POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html).

3. Запустите Java‑код преобразования PowerPoint в видео.

Этот Java‑код показывает, как преобразовать презентацию (с фигурой и двумя эффектами анимации) в видео:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Добавляет форму улыбающегося лица и затем анимирует её
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

    // Настройте папку с бинарными файлами ffmpeg. См. эту страницу: https://github.com/bramp/ffmpeg-cli-wrapper
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

## **Видеоеффекты**

Вы можете применять анимацию к объектам на слайдах и использовать переходы между слайдами. 

{{% alert color="info" %}} 

Возможно, вам будет интересно посмотреть эти статьи: [PowerPoint Animation](https://docs.aspose.com/slides/ru/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/ru/androidjava/shape-animation/), и [Shape Effect](https://docs.aspose.com/slides/ru/androidjava/shape-effect/).

{{% /alert %}} 

Анимации и переходы делают слайды более захватывающими и интересными — и они делают то же самое для видео. Давайте добавим ещё один слайд и переход в код предыдущей презентации:
```java
import com.aspose.slides.*;
import java.awt.Color;

// Презентация с анимированной фигурой улыбки, созданной выше.
Presentation presentation = new Presentation();
try {
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

Aspose.Slides также поддерживает анимацию текста. Поэтому мы анимируем абзацы на объектах, которые появляются один за другим (с задержкой, установленной в одну секунду):
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Добавляет текст и анимацию
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

    // Настройте папку с бинарными файлами ffmpeg. См. эту страницу: https://github.com/bramp/ffmpeg-cli-wrapper
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

## **Классы конвертации видео**

Чтобы позволить вам выполнять задачи по преобразованию PowerPoint в видео, Aspose.Slides предоставляет классы [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationanimationsgenerator/) и [PresentationPlayer](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationanimationsgenerator/) позволяет задать размер кадра для будущего видео через конструктор. Если вы передадите экземпляр презентации, будет использован `Presentation.SlideSize`, и он генерирует анимацию, которую использует [PresentationPlayer](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationplayer/).

При генерации анимаций создаётся событие `NewAnimation` для каждой последующей анимации, которое имеет параметр [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationanimationplayer/). Последний представляет собой класс, являющийся плеером отдельной анимации.

Чтобы работать с [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationanimationplayer/), используются свойство [Duration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (полная длительность анимации) и метод [SetTimePosition](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Каждая позиция анимации задаётся в диапазоне от *0 до duration*, после чего метод `getFrame` возвращает [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/), соответствующий состоянию анимации в данный момент:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Добавляет форму улыбающегося лица и анимирует её
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

            animationPlayer.setTimePosition(0); // исходное состояние анимации
            // битмап исходного состояния анимации
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // конечное состояние анимации
            // последний кадр анимации
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Сгенерировать анимации. Вызываемый выше обратный вызов выполняется для каждой из них.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Чтобы воспроизвести все анимации презентации одновременно, используется класс [PresentationPlayer](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationplayer/). Этот класс принимает экземпляр [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationanimationsgenerator/) и FPS для эффектов в конструкторе, а затем вызывает событие `FrameTick` для всех анимаций, чтобы они воспроизводились:
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

Затем сгенерированные кадры можно собрать в видео. Смотрите раздел [Конвертировать PowerPoint в видео](https://docs.aspose.com/slides/ru/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Поддерживаемые анимации и эффекты**

**Вход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Появление** | ![not supported](x.png) | ![supported](v.png) |
| **Затухание** | ![supported](v.png) | ![supported](v.png) |
| **Вылет внутрь** | ![supported](v.png) | ![supported](v.png) |
| **Плавный вход** | ![supported](v.png) | ![supported](v.png) |
| **Разделение** | ![supported](v.png) | ![supported](v.png) |
| **Смахивание** | ![supported](v.png) | ![supported](v.png) |
| **Форма** | ![supported](v.png) | ![supported](v.png) |
| **Колесо** | ![supported](v.png) | ![supported](v.png) |
| **Случайные полосы** | ![supported](v.png) | ![supported](v.png) |
| **Увеличение и поворот** | ![not supported](x.png) | ![supported](v.png) |
| **Масштабирование** | ![supported](v.png) | ![supported](v.png) |
| **Вращение** | ![supported](v.png) | ![supported](v.png) |
| **Отскок** | ![supported](v.png) | ![supported](v.png) |

**Акцент**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Пульсация** | ![not supported](x.png) | ![supported](v.png) |
| **Цветовая пульсация** | ![not supported](x.png) | ![supported](v.png) |
| **Тряска** | ![supported](v.png) | ![supported](v.png) |
| **Вращение** | ![supported](v.png) | ![supported](v.png) |
| **Увеличение/Уменьшение** | ![not supported](x.png) | ![supported](v.png) |
| **Уменьшение насыщенности** | ![not supported](x.png) | ![supported](v.png) |
| **Темнение** | ![not supported](x.png) | ![supported](v.png) |
| **Осветление** | ![not supported](x.png) | ![supported](v.png) |
| **Прозрачность** | ![not supported](x.png) | ![supported](v.png) |
| **Цвет объекта** | ![not supported](x.png) | ![supported](v.png) |
| **Дополнительный цвет** | ![not supported](x.png) | ![supported](v.png) |
| **Цвет линии** | ![not supported](x.png) | ![supported](v.png) |
| **Цвет заливки** | ![not supported](x.png) | ![supported](v.png) |

**Выход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Исчезновение** | ![not supported](x.png) | ![supported](v.png) |
| **Затухание** | ![supported](v.png) | ![supported](v.png) |
| **Вылет наружу** | ![supported](v.png) | ![supported](v.png) |
| **Плавный выход** | ![supported](v.png) | ![supported](v.png) |
| **Разделение** | ![supported](v.png) | ![supported](v.png) |
| **Смахивание** | ![supported](v.png) | ![supported](v.png) |
| **Форма** | ![supported](v.png) | ![supported](v.png) |
| **Случайные полосы** | ![supported](v.png) | ![supported](v.png) |
| **Уменьшить и повернуть** | ![not supported](x.png) | ![supported](v.png) |
| **Масштабирование** | ![supported](v.png) | ![supported](v.png) |
| **Вращение** | ![supported](v.png) | ![supported](v.png) |
| **Отскок** | ![supported](v.png) | ![supported](v.png) |

**Пути движения**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Линии** | ![supported](v.png) | ![supported](v.png) |
| **Дуги** | ![supported](v.png) | ![supported](v.png) |
| **Повороты** | ![supported](v.png) | ![supported](v.png) |
| **Фигуры** | ![supported](v.png) | ![supported](v.png) |
| **Петли** | ![supported](v.png) | ![supported](v.png) |
| **Пользовательский путь** | ![supported](v.png) | ![supported](v.png) |

## **Часто задаваемые вопросы**

### Можно ли конвертировать защищённые паролем презентации?

Да, Aspose.Slides позволяет работать с [зашифрованными паролем презентациями](/slides/ru/androidjava/password-protected-presentation/). При обработке таких файлов необходимо указать правильный пароль, чтобы библиотека могла получить доступ к содержимому презентации.

### Поддерживает ли Aspose.Slides использование в облачных решениях?

Да, Aspose.Slides можно интегрировать в облачные приложения и сервисы. Библиотека разработана для работы в серверных средах, обеспечивая высокую производительность и масштабируемость при пакетной обработке файлов.

### Есть ли ограничения по размеру презентаций при конвертации?

Aspose.Slides способен работать с презентациями практически любого размера. Однако при работе с очень большими файлами может потребоваться дополнительное системное ресурсы, и иногда рекомендуется оптимизировать презентацию для повышения производительности.