---
title: Конвертация PowerPoint в видео
type: docs
weight: 130
url: /java/convert-powerpoint-to-video/
keywords: "Конвертировать PowerPoint, PPT, PPTX, Презентация, Видео, MP4, PPT в видео, PPT в MP4, Java, Aspose.Slides"
description: "Конвертация PowerPoint в видео на Java"
---

Преобразовав вашу презентацию PowerPoint в видео, вы сможете 

* **Увеличить доступность:** Все устройства (независимо от платформы) по умолчанию оснащены видеоплеерами, в отличие от приложений для открытия презентаций, поэтому пользователям проще открывать или воспроизводить видео.
* **Более широкий охват:** С помощью видео вы можете достичь широкой аудитории и донести до нее информацию, которая в противном случае могла бы показаться утомительной в презентации. Большинство опросов и статистических данных свидетельствуют о том, что люди чаще смотрят и потребляют видео, чем другие формы контента, и они, как правило, предпочитают такой контент.

{{% alert color="primary" %}} 

Вы можете проверить наш [**Онлайн-конвертер PowerPoint в видео**](https://products.aspose.app/slides/conversion/ppt-to-word), потому что это живое и эффективное осуществление процесса, описанного здесь.

{{% /alert %}} 

## **Конвертация PowerPoint в видео с помощью Aspose.Slides**

В [Aspose.Slides 22.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-22-11-release-notes/) мы реализовали поддержку конвертации презентации в видео. 

* Используйте **Aspose.Slides** для генерации набора кадров (из слайдов презентации), соответствующих определенному FPS (кадров в секунду).
* Используйте стороннюю утилиту, такую как **ffmpeg** ([для java](https://github.com/bramp/ffmpeg-cli-wrapper)), чтобы создать видео на основе кадров. 

### **Конвертация PowerPoint в видео**

1. Добавьте это в ваш файл POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html).

4. Запустите код Java для конвертации PowerPoint в видео.

Этот код Java демонстрирует, как конвертировать презентацию (содержащую фигуру и два анимационных эффекта) в видео:

```java
Presentation presentation = new Presentation();
try {
    // Добавляет смайлик и анимирует его
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

    // Настройте папку с исполняемыми файлами ffmpeg. См. эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **Видеоефекты**

Вы можете применять анимации к объектам на слайдах и использовать переходы между слайдами. 

{{% alert color="primary" %}} 

Вы также можете ознакомиться с этими статьями: [Анимация PowerPoint](https://docs.aspose.com/slides/java/powerpoint-animation/), [Анимация форм](https://docs.aspose.com/slides/java/shape-animation/), и [Эффект формы](https://docs.aspose.com/slides/java/shape-effect/).

{{% /alert %}} 

Анимации и переходы делают слайд-шоу более увлекательным и интересным — и то же самое можно сказать о видео. Давайте добавим еще один слайд и переход к коду предыдущей презентации:

```java
// Добавляет смайлик и анимирует его

// ...

// Добавляет новый слайд и анимированный переход

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides также поддерживает анимацию для текстов. Таким образом, мы можем анимировать абзацы на объектах, которые появятся один за другим (с установленной задержкой в одну секунду):

```java
Presentation presentation = new Presentation();
try {
    // Добавляет текст и анимации
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides для Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("конвертация PowerPoint Презентации с текстом в видео"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("постепенно"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

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

    // Настройте папку с исполняемыми файлами ffmpeg. См. эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
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

Чтобы выполнять задачи по конвертации PowerPoint в видео, Aspose.Slides предоставляет классы [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) и [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) позволяет вам устанавливать размер кадра для видео (которое будет создано позже) через свой конструктор. Если вы передадите экземпляр презентации, будет использован `Presentation.SlideSize`, и он генерирует анимации, которые использует [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/). 

Когда анимации генерируются, создается событие `NewAnimation` для каждой последующей анимации, которое имеет параметр [IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/). Последний представляет класс, который представляет игрока для отдельной анимации.

Для работы с [IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/) используются свойства [Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (общая длительность анимации) и метод [SetTimePosition](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Каждое положение анимации задается в пределах диапазона *0 до длительности*, а затем метод `GetFrame` вернет BufferedImage, который соответствует состоянию анимации в этот момент:

```java
Presentation presentation = new Presentation();
try {
    // Добавляет смайлик и анимирует его
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
            System.out.println(String.format("Общая длительность анимации: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // начальное состояние анимации
            try {
                // снимок начального состояния анимации
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // конечное состояние анимации
            try {
                // последний кадр анимации
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Чтобы воспроизвести все анимации в презентации одновременно, используется класс [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/). Этот класс принимает экземпляр [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) и FPS для эффектов в своем конструкторе и затем вызывает событие `FrameTick` для всех анимаций, чтобы их воспроизвести:

```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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
} finally {
    if (presentation != null) presentation.dispose();
}
```

Затем сгенерированные кадры могут быть скомпилированы для создания видео. См. раздел [Конвертация PowerPoint в видео](https://docs.aspose.com/slides/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Поддерживаемые анимации и эффекты**

**Вход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Появление** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Плавное появление** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Лететь внутрь** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Плавно внутрь** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Разделение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вытирание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Форма** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Колесо** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Случайные полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Увеличение и поворот** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Масштабирование** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Качание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Упругость** | ![поддерживается](v.png) | ![поддерживается](v.png) |

**Эмфаза**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Пульсация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цветовая пульсация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Качание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вращение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Рост/уменьшение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Обесцвечивание** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Углубление** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Освещение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Прозрачность** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет объекта** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Дополнительный цвет** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет линии** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет заливки** | ![не поддерживается](x.png) | ![поддерживается](v.png) |

**Выход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Исчезновение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Плавное исчезновение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Лететь наружу** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Плавно наружу** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Разделение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вытирание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Форма** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Случайные полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Сжатие и поворот** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Масштабирование** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Качание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Упругость** | ![поддерживается](v.png) | ![поддерживается](v.png) |

**Движущиеся пути:**

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Линии** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Арки** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Повороты** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Формы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Циклы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Настроенный путь** | ![поддерживается](v.png) | ![поддерживается](v.png) |