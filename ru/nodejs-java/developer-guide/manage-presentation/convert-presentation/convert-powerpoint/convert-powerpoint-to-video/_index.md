---
title: Преобразовать PowerPoint в видео
type: docs
weight: 130
url: /ru/nodejs-java/convert-powerpoint-to-video/
keywords: "Конвертировать PowerPoint, PPT, PPTX, Презентация, Видео, MP4, PPT в видео, PPT в MP4, Java, Aspose.Slides"
description: "Конвертировать PowerPoint в видео с помощью JavaScript"
---

Преобразуя вашу презентацию PowerPoint в видео, вы получаете 

* **Повышение доступности:** Все устройства (независимо от платформы) по умолчанию оснащены видеоплеерами, в отличие от приложений для открытия презентаций, поэтому пользователям проще открывать или воспроизводить видео.
* **Больший охват:** С помощью видео вы можете достичь широкой аудитории и предоставить им информацию, которая иначе могла бы показаться скучной в презентации. Большинство опросов и статистических данных свидетельствуют, что люди смотрят и потребляют видео чаще, чем другие формы контента, и обычно предпочитают такой контент.

{{% alert color="primary" %}} 

Возможно, вам стоит ознакомиться с нашим [**Онлайн-конвертером PowerPoint в видео**](https://products.aspose.app/slides/conversion/ppt-to-word), так как это живой и эффективный пример реализации описанного процесса.

{{% /alert %}} 

## **Преобразование PowerPoint в видео в Aspose.Slides**

В [Aspose.Slides 22.11](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-22-11-release-notes/) мы внедрили поддержку преобразования презентаций в видео.

* Используйте **Aspose.Slides** для генерации набора кадров (из слайдов презентации), соответствующих определённому FPS (кадров в секунду)
* Используйте стороннюю утилиту, такую как **ffmpeg** ([для java](https://github.com/bramp/ffmpeg-cli-wrapper)), чтобы создать видео на основе этих кадров. 

### **Преобразовать PowerPoint в видео**

1. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html).
2. Запустите JavaScript‑код преобразования PowerPoint в видео.

Этот JavaScript‑код демонстрирует, как преобразовать презентацию (с рисунком и двумя эффектами анимации) в видео:
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
    // Настройте папку с бинарниками ffmpeg. См. эту страницу: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **Эффекты видео**

Вы можете применять анимацию к объектам на слайдах и использовать переходы между слайдами. 

{{% alert color="primary" %}} 

Вам может быть интересно ознакомиться со следующими статьями: [PowerPoint Animation](https://docs.aspose.com/slides/nodejs-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/nodejs-java/shape-animation/), и [Shape Effect](https://docs.aspose.com/slides/nodejs-java/shape-effect/).

{{% /alert %}} 

Анимации и переходы делают презентации более увлекательными и интересными — и то же самое происходит с видео. Добавим ещё один слайд и переход в код предыдущей презентации:
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


## **Классы преобразования видео**

Для выполнения задач по преобразованию PowerPoint в видео Aspose.Slides предоставляет классы [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) и [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) позволяет задать размер кадра для будущего видео через конструктор. Если передать экземпляр презентации, будет использован `Presentation.getSlideSize`, и он генерирует анимации, которые использует [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/).

При генерации анимаций для каждой последующей анимации создаётся событие `NewAnimation`, которому передаётся параметр [PresentationAnimationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationplayer/). Последний представляет собой класс, отвечающий за воспроизведение отдельной анимации.

Для работы с [PresentationAnimationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationplayer/) используются метод [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationplayer/#getDuration--) (полная продолжительность анимации) и метод [setTimePosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationplayer/#setTimePosition-double-). Позиция каждой анимации задаётся в диапазоне от *0 до duration*, после чего метод `getFrame` возвращает BufferedImage, соответствующее состоянию анимации в данный момент:
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
            animationPlayer.setTimePosition(animationPlayer.getDuration());// конечное состояние анимации
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


Чтобы все анимации в презентации воспроизводились одновременно, используется класс [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/). Этот класс принимает экземпляр [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) и FPS для эффектов в конструкторе, а затем вызывает событие `FrameTick` для всех анимаций, чтобы они запустились:
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


Затем сгенерированные кадры могут быть скомпилированы в видео. См. раздел [Convert PowerPoint to Video](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Поддерживаемые анимации и эффекты**

**Вход**:

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

**Акцент**:

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

**Выход**:

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

**Пути движения:**

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Arcs** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Turns** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Shapes** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Loops** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Custom Path** | ![поддерживается](v.png) | ![поддерживается](v.png) |

## **Часто задаваемые вопросы**

**Можно ли конвертировать презентации, защищённые паролем?**

Да, Aspose.Slides поддерживает работу с презентациями, защищёнными паролем. При обработке таких файлов необходимо указать правильный пароль, чтобы библиотека могла получить доступ к содержимому презентации.

**Поддерживает ли Aspose.Slides использование в облачных решениях?**

Да, Aspose.Slides можно интегрировать в облачные приложения и сервисы. Библиотека разработана для работы в серверных средах, обеспечивая высокую производительность и масштабируемость при пакетной обработке файлов.

**Есть ли ограничения по размеру презентаций при конвертации?**

Aspose.Slides способен обрабатывать презентации практически любого размера. Тем не менее, при работе с очень большими файлами могут потребоваться дополнительные системные ресурсы, и иногда рекомендуется оптимизировать презентацию для повышения производительности.