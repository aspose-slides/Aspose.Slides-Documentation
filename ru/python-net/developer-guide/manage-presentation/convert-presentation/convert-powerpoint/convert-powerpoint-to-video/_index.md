---
title: Конвертировать презентации PowerPoint в видео на Python
linktitle: PowerPoint в видео
type: docs
weight: 130
url: /ru/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint в видео
- конвертировать PowerPoint в видео
- презентация в видео
- конвертировать презентацию в видео
- PPT в видео
- конвертировать PPT в видео
- PPTX в видео
- конвертировать PPTX в видео
- ODP в видео
- конвертировать ODP в видео
- PowerPoint в MP4
- конвертировать PowerPoint в MP4
- презентация в MP4
- конвертировать презентацию в MP4
- PPT в MP4
- конвертировать PPT в MP4
- PPTX в MP4
- конвертировать PPTX в MP4
- конвертация PowerPoint в видео
- конвертация презентации в видео
- конвертация PPT в видео
- конвертация PPTX в видео
- конвертация ODP в видео
- конвертация видео на Python
- PowerPoint
- Python
- Aspose.Slides
description: "Узнайте, как конвертировать презентации PowerPoint и OpenDocument в видео с помощью Python. Откройте примеры кода и методы автоматизации, чтобы оптимизировать ваш рабочий процесс."
---

## **Обзор**

Преобразовав вашу презентацию PowerPoint или OpenDocument в видео, вы получаете:

**Повышенная доступность:** Все устройства, независимо от платформы, по умолчанию оснащены видеоплеерами, что упрощает открытие и воспроизведение видео по сравнению с традиционными приложениями для презентаций.

**Более широкая аудитория:** Видео позволяют охватить большую аудиторию и представить информацию в более увлекательном формате. Опросы и статистика показывают, что люди предпочитают смотреть и потреблять видеоконтент другим формам, делая ваше сообщение более впечатляющим.

{{% alert color="primary" %}} 
Посмотрите наш [**Онлайн‑конвертер PowerPoint в Видео**](https://products.aspose.app/slides/video), который предлагает живую и эффективную реализацию процесса, описанного здесь.
{{% /alert %}} 

В [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) мы реализовали поддержку конвертации презентаций в видео.

* Используйте Aspose.Slides for Python для генерации кадров из слайдов презентации с заданной частотой кадров (FPS).
* Затем используйте стороннюю утилиту, такую как ffmpeg, для сборки этих кадров в видео.

## **Конвертировать презентацию PowerPoint в видео**

1. Добавьте Aspose.Slides for Python в проект с помощью команды pip install: `pip install aspose-slides==24.4.0`
2. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html) или установите его через менеджер пакетов.
3. Убедитесь, что ffmpeg находится в `PATH`. В противном случае запускайте ffmpeg, указав полный путь к бинарному файлу (например, `C:\ffmpeg\ffmpeg.exe` в Windows или `/opt/ffmpeg/ffmpeg` в Linux).
4. Запустите код конвертации PowerPoint в видео.

Этот Python‑код демонстрирует, как преобразовать презентацию (с фигурой и двумя эффектами анимации) в видео:
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```


## **Эффекты видео**

При конвертации презентации PowerPoint в видео с помощью Aspose.Slides for Python вы можете применять различные видеоеффекты, повышающие визуальное качество результата. Эти эффекты позволяют управлять внешним видом слайдов в финальном видео, добавляя плавные переходы, анимацию и другие визуальные элементы. В этом разделе описаны доступные варианты видеоеффектов и показано, как их применять.

{{% alert color="primary" %}} 
Смотрите [Анимацию PowerPoint](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Анимацию фигур](https://docs.aspose.com/slides/python-net/shape-animation/) и [Эффекты фигур](https://docs.aspose.com/slides/python-net/shape-effect/).
{{% /alert %}} 

Анимации и переходы делают слайд‑шоу более захватывающим и интересным — и то же самое происходит с видео. Добавим еще один слайд и переход в код предыдущей презентации:
```python
import aspose.pydrawing as drawing

# Добавить форму смайла и анимировать её.
# ...

# Добавить новый слайд и анимированный переход.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```


Aspose.Slides for Python также поддерживает анимацию текста. В этом примере мы анимируем абзацы объектов так, чтобы они появлялись последовательно с односекундной задержкой между ними:
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить текст и анимации.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Преобразовать кадры в видео.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```


## **Классы конвертации видео**

Для выполнения задач конвертации PowerPoint в видео Aspose.Slides for Python предоставляет [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` позволяет задать размер кадра для будущего видео и значение FPS (кадров в секунду) через конструктор. Если передать экземпляр презентации, будет использовано её `Presentation.SlideSize`.

Чтобы все анимации в презентации воспроизводились одновременно, используйте метод `PresentationEnumerableFramesGenerator.enumerate_frames`. Этот метод принимает коллекцию слайдов и последовательно возвращает [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/). Затем вызывайте `EnumerableFrameArgs.get_frame()` для получения каждого видеокадра.
```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


Сгенерированные кадры затем можно собрать в видео. Подробнее см. раздел [Конвертировать PowerPoint в Видео](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Поддерживаемые анимации и эффекты**

При конвертации презентации PowerPoint в видео с помощью Aspose.Slides for Python важно знать, какие анимации и эффекты сохраняются в выходном файле. Aspose.Slides поддерживает широкий набор стандартных эффектов появления, исчезновения и акцента, таких как затухание, вылет, увеличение и вращение. Однако некоторые сложные или пользовательские анимации могут быть частично потеряны или выглядеть иначе в конечном видео. Ниже перечислены поддерживаемые анимации и эффекты.

**Появление**:

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

**Исчезновение**:

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

**Траектории движения**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Arcs** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Turns** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Shapes** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Loops** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Custom Path** | ![поддерживается](v.png) | ![поддерживается](v.png) |

## **Поддерживаемые эффекты переходов слайдов**

Эффекты переходов между слайдами играют важную роль в создании плавных и визуально привлекательных смен в видео. Aspose.Slides for Python поддерживает множество распространенных эффектов переходов, помогая сохранить поток и стиль оригинальной презентации. Ниже перечислены поддерживаемые эффекты переходов.

**Тонкие**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Fade** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Push** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Pull** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Wipe** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Split** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Reveal** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Random Bars** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Shape** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Uncover** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Cover** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Flash** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Strips** | ![поддерживается](v.png) | ![поддерживается](v.png) |

**Энергичные**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Drape** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Curtains** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Wind** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Prestige** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Fracture** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Crush** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Peel Off** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Page Curl** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Airplane** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Origami** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Dissolve** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Checkerboard** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Blinds** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Clock** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Ripple** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Honeycomb** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Glitter** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Vortex** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Shred** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Switch** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Flip** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Gallery** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Cube** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Doors** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Box** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Comb** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Zoom** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Random** | ![не поддерживается](x.png) | ![поддерживается](v.png) |

**Динамический контент**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Ferris Wheel** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Conveyor** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Rotate** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Orbit** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Fly Through** | ![поддерживается](v.png) | ![поддерживается](v.png) |

## **Вопросы и ответы**

**Можно ли конвертировать презентации, защищённые паролем?**

Да, Aspose.Slides for Python поддерживает работу с презентациями, защищёнными паролем. При обработке таких файлов необходимо указать правильный пароль, чтобы библиотека могла получить доступ к содержимому презентации.

**Поддерживает ли Aspose.Slides for Python использование в облачных решениях?**

Да, Aspose.Slides for Python можно интегрировать в облачные приложения и сервисы. Библиотека разработана для работы в серверных средах, обеспечивая высокую производительность и масштабируемость при пакетной обработке файлов.

**Существуют ли ограничения по размеру презентаций при конвертации?**

Aspose.Slides for Python способна обрабатывать презентации практически любого размера. Однако при работе с очень большими файлами могут потребоваться дополнительные системные ресурсы, и иногда рекомендуется оптимизировать презентацию для повышения производительности.