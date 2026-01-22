---
title: Конвертировать презентации PowerPoint в видео с помощью JavaScript
linktitle: PowerPoint в видео
type: docs
weight: 130
url: /ru/nodejs-java/convert-powerpoint-to-video/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как конвертировать презентации PowerPoint в видео с помощью JavaScript. Откройте для себя образцы кода и техники автоматизации, упрощающие ваш рабочий процесс."
---

Преобразуя вашу презентацию PowerPoint в видео, вы получаете 

* **Повышение доступности:** Все устройства (независимо от платформы) по умолчанию оснащены видеоплеерами, в отличие от приложений для открытия презентаций, поэтому пользователям проще открывать или воспроизводить видео.
* **Больший охват:** С помощью видео вы можете достичь широкой аудитории и предоставить ей информацию, которая иначе могла бы показаться утомительной в презентации. Большинство опросов и статистических данных показывают, что люди чаще просматривают и потребляют видео, чем другие формы контента, и обычно предпочитают именно его.

{{% alert color="primary" %}} 

Возможно, вам стоит проверить наш [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word), так как это живой и эффективный пример реализации процесса, описанного здесь.

{{% /alert %}} 

## **Преобразование PowerPoint в видео в Aspose.Slides**

Aspose.Slides поддерживает преобразование презентаций в видео.

* Используйте **Aspose.Slides** для создания набора кадров (из слайдов презентации), соответствующих определённому FPS (кадрам в секунду)
* Используйте стороннюю утилиту, например **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)), чтобы создать видео на основе кадров. 

### **Преобразовать PowerPoint в видео**

1. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html).
2. Запустите JavaScript‑код преобразования PowerPoint в видео.

Этот JavaScript‑код показывает, как преобразовать презентацию (содержащую схему и два анимационных эффекта) в видео:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Добавляет форму улыбки и затем анимирует её
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Настройте папку с бинарными файлами ffmpeg. Смотрите эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **Видеоэффекты**

Вы можете применять анимацию к объектам на слайдах и использовать переходы между слайдами. 

{{% alert color="primary" %}} 

Возможно, вам будет интересно ознакомиться со статьями: [Анимация PowerPoint](https://docs.aspose.com/slides/nodejs-java/powerpoint-animation/), [Анимация фигур](https://docs.aspose.com/slides/nodejs-java/shape-animation/), и [Эффект фигур](https://docs.aspose.com/slides/nodejs-java/shape-effect/).

{{% /alert %}} 

Анимация и переходы делают презентацию более захватывающей и интересной — и то же самое происходит с видео. Добавим ещё один слайд и переход в код для предыдущей презентации:
```javascript
// Добавляет форму улыбки и анимирует её
// ...
// Добавляет новый слайд и анимированный переход
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```


Aspose.Slides также поддерживает анимацию текста. Мы анимируем абзацы на объектах, которые будут появляться один за другим (с задержкой в одну секунду):
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Добавляет текст и анимацию
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Настройте папку с бинарными файлами ffmpeg. Смотрите эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **Классы конвертации видео**

Для выполнения задач по преобразованию PowerPoint в видео Aspose.Slides предоставляет классы [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) и [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) позволяет задать размер кадра для будущего видео через конструктор. Если передать экземпляр презентации, будет использован `Presentation.getSlideSize`, и он генерирует анимацию, которую использует [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/).

При генерации анимаций создаётся событие `NewAnimation` для каждой последующей анимации, которое имеет параметр плеера анимации презентации. Этот класс представляет плеер отдельной анимации.

Для работы с плеером анимации презентации используют методы `getDuration` (полная длительность анимации) и `setTimePosition`. Каждая позиция анимации задаётся в диапазоне *0 до длительности*, после чего метод `getFrame` возвращает BufferedImage, соответствующий состоянию анимации в данный момент:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Добавляет форму улыбки и анимирует её
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// начальное состояние анимации
            try {
                // битмап начального состояния анимации
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// final state of the animation
            try {
                // последний кадр анимации
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


Чтобы все анимации в презентации воспроизводились одновременно, используется класс [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/). Этот класс принимает экземпляр [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) и FPS для эффектов в конструкторе, после чего вызывает событие `FrameTick` для всех анимаций, чтобы они проигрывались:
```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


Затем сгенерированные кадры могут быть собраны в виде видео. См. раздел [Convert PowerPoint to Video](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Поддерживаемые анимации и эффекты**

**Вход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Появление** | ![not supported](x.png) | ![supported](v.png) |
| **Исчезание** | ![supported](v.png) | ![supported](v.png) |
| **Влёт** | ![supported](v.png) | ![supported](v.png) |
| **Плавный полёт** | ![supported](v.png) | ![supported](v.png) |
| **Разделение** | ![supported](v.png) | ![supported](v.png) |
| **Смахивание** | ![supported](v.png) | ![supported](v.png) |
| **Форма** | ![supported](v.png) | ![supported](v.png) |
| **Колесо** | ![supported](v.png) | ![supported](v.png) |
| **Случайные полосы** | ![supported](v.png) | ![supported](v.png) |
| **Рост и поворот** | ![not supported](x.png) | ![supported](v.png) |
| **Увеличение** | ![supported](v.png) | ![supported](v.png) |
| **Вращение** | ![supported](v.png) | ![supported](v.png) |
| **Отскок** | ![supported](v.png) | ![supported](v.png) |

**Эффект**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Пульс** | ![not supported](x.png) | ![supported](v.png) |
| **Цветовой пульс** | ![not supported](x.png) | ![supported](v.png) |
| **Качание** | ![supported](v.png) | ![supported](v.png) |
| **Вращение** | ![supported](v.png) | ![supported](v.png) |
| **Увеличение/Уменьшение** | ![not supported](x.png) | ![supported](v.png) |
| **Обесцвечивание** | ![not supported](x.png) | ![supported](v.png) |
| **Затемнение** | ![not supported](x.png) | ![supported](v.png) |
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
| **Исчезание** | ![supported](v.png) | ![supported](v.png) |
| **Вылет** | ![supported](v.png) | ![supported](v.png) |
| **Плавный вылет** | ![supported](v.png) | ![supported](v.png) |
| **Разделение** | ![supported](v.png) | ![supported](v.png) |
| **Смахивание** | ![supported](v.png) | ![supported](v.png) |
| **Форма** | ![supported](v.png) | ![supported](v.png) |
| **Случайные полосы** | ![supported](v.png) | ![supported](v.png) |
| **Уменьшение и поворот** | ![not supported](x.png) | ![supported](v.png) |
| **Увеличение** | ![supported](v.png) | ![supported](v.png) |
| **Вращение** | ![supported](v.png) | ![supported](v.png) |
| **Отскок** | ![supported](v.png) | ![supported](v.png) |

**Траектории движения**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Линии** | ![supported](v.png) | ![supported](v.png) |
| **Дуги** | ![supported](v.png) | ![supported](v.png) |
| **Повороты** | ![supported](v.png) | ![supported](v.png) |
| **Фигуры** | ![supported](v.png) | ![supported](v.png) |
| **Петли** | ![supported](v.png) | ![supported](v.png) |
| **Пользовательский путь** | ![supported](v.png) | ![supported](v.png) |

## **Часто задаваемые вопросы**

**Можно ли конвертировать презентации, защищённые паролем?**

Да, Aspose.Slides поддерживает работу с презентациями, защищёнными паролем. При обработке таких файлов необходимо указать правильный пароль, чтобы библиотека могла получить доступ к содержимому презентации.

**Поддерживает ли Aspose.Slides использование в облачных решениях?**

Да, Aspose.Slides можно интегрировать в облачные приложения и сервисы. Библиотека разработана для работы в серверных средах, обеспечивая высокую производительность и масштабируемость при пакетной обработке файлов.

**Есть ли ограничения по размеру презентаций при конвертации?**

Aspose.Slides способен обрабатывать презентации практически любого размера. Однако при работе с очень большими файлами могут потребоваться дополнительные системные ресурсы, и иногда рекомендуется оптимизировать презентацию для повышения производительности.