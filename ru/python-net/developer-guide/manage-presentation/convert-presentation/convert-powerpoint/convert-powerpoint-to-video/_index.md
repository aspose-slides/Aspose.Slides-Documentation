---
title: Переобразование презентаций PowerPoint в видео с помощью Python
linktitle: PowerPoint в видео
type: docs
weight: 130
url: /ru/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint в видео
- преобразовать PowerPoint в видео
- презентация в видео
- преобразовать презентацию в видео
- PPT в видео
- преобразовать PPT в видео
- PPTX в видео
- преобразовать PPTX в видео
- ODP в видео
- преобразовать ODP в видео
- PowerPoint в MP4
- преобразовать PowerPoint в MP4
- презентация в MP4
- преобразовать презентацию в MP4
- PPT в MP4
- преобразовать PPT в MP4
- PPTX в MP4
- преобразовать PPTX в MP4
- Преобразование PowerPoint в видео
- Преобразование презентации в видео
- Преобразование PPT в видео
- Преобразование PPTX в видео
- Преобразование ODP в видео
- Преобразование видео с помощью Python
- PowerPoint
- Python
- Aspose.Slides
description: "Узнайте, как преобразовать презентации PowerPoint и OpenDocument в видео с помощью Python. Откройте примеры кода и техники автоматизации для оптимизации рабочего процесса."
---

## **Обзор**

Преобразовав вашу презентацию PowerPoint или OpenDocument в видео, вы получаете:

**Повышенная доступность:** Все устройства, независимо от платформы, по умолчанию оснащены видеоплеерами, что упрощает пользователям открытие или воспроизведение видео по сравнению с традиционными приложениями для презентаций.

**Широкий охват:** Видео позволяют достичь более широкой аудитории и представить информацию в более увлекательном формате. Опросы и статистика показывают, что люди предпочитают просматривать и потреблять видеоконтент по сравнению с другими формами, делая ваше сообщение более воздействующим.

{{% alert color="primary" %}} 

Ознакомьтесь с нашим [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/video), потому что он предлагает живую и эффективную реализацию процесса, описанного здесь.

{{% /alert %}} 

В [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) мы реализовали поддержку преобразования презентаций в видео.

* Используйте Aspose.Slides for Python для генерации кадров из слайдов презентации с заданной частотой кадров (FPS).
* Затем используйте стороннюю утилиту, например ffmpeg, для объединения этих кадров в видео.

## **Преобразование презентации PowerPoint в видео**

1. Используйте команду pip install, чтобы добавить Aspose.Slides for Python в ваш проект: `pip install aspose-slides==24.4.0`
2. Скачайте ffmpeg с [здесь](https://ffmpeg.org/download.html) или установите его через менеджер пакетов.
3. Убедитесь, что ffmpeg находится в переменной `PATH`. В противном случае запускайте ffmpeg, указав полный путь к исполняемому файлу (например, `C:\ffmpeg\ffmpeg.exe` в Windows или `/opt/ffmpeg/ffmpeg` в Linux).
4. Запустите код преобразования PowerPoint в видео.

Этот код на Python демонстрирует, как преобразовать презентацию (содержащую фигуру и два эффекта анимации) в видео:
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

При преобразовании презентации PowerPoint в видео с помощью Aspose.Slides for Python вы можете применять различные видеoeффекты для улучшения визуального качества результата. Эти эффекты позволяют контролировать отображение слайдов в конечном видео, добавляя плавные переходы, анимацию и другие визуальные элементы. В этом разделе описаны доступные варианты видеoeффектов и показано, как их применять.

{{% alert color="primary" %}} 

Смотрите [PowerPoint Animation](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/python-net/shape-animation/), и [Shape Effect](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

Анимации и переходы делают слайдшоу более увлекательными и интересными — и то же самое происходит с видео. Добавим еще один слайд и переход в коде для предыдущей презентации:
```python
import aspose.pydrawing as drawing

# Добавьте форму улыбки и анимируйте её.
# ...

# Добавьте новый слайд и анимированный переход.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```


Aspose.Slides for Python также поддерживает текстовые анимации. В этом примере мы анимируем абзацы на объектах так, чтобы они появлялись последовательно с односекундной задержкой между ними:
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавьте текст и анимацию.
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

    # Преобразуйте кадры в видео.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```


## **Классы преобразования видео**

Для выполнения задач преобразования PowerPoint в видео Aspose.Slides for Python предоставляет [PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/).

`PresentationEnumerableAnimationsGenerator` позволяет задать размер кадра для будущего видео и значение FPS (кадров в секунду) через его конструктор. Если передать экземпляр презентации, будет использовано её `Presentation.SlideSize`.

Чтобы все анимации в презентации воспроизводились одновременно, используйте метод `PresentationEnumerableAnimationsGenerator.enumerate_frames`. Этот метод принимает коллекцию слайдов и последовательно возвращает [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/). Затем используйте `EnumerableFrameArgs.get_frame()` для получения каждого кадра видео.
```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


Затем полученные кадры могут быть объединены в видео. Подробности см. в разделе [Convert PowerPoint to Video](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Поддерживаемые анимации и эффекты**

При преобразовании презентации PowerPoint в видео с помощью Aspose.Slides for Python важно понимать, какие анимации и эффекты поддерживаются в выходном файле. Aspose.Slides поддерживает широкий спектр обычных входных, выходных и акцентных эффектов, таких как затухание, вылет, масштабирование и вращение. Однако некоторые сложные или пользовательские анимации могут не полностью сохраняться или отображаться иначе в финальном видео. Этот раздел описывает поддерживаемые анимации и эффекты.

**Входные**:

| Тип анимации | Aspose.Slides | PowerPoint |
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

**Акцентные**:

| Тип анимации | Aspose.Slides | PowerPoint |
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

**Выходные**:

| Тип анимации | Aspose.Slides | PowerPoint |
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

**Пути движения**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Поддерживаемые эффекты переходов слайдов**

Эффекты переходов слайдов играют важную роль в создании плавных и визуально привлекательных смен между слайдами в видео. Aspose.Slides for Python поддерживает разнообразные часто используемые эффекты переходов, помогая сохранить поток и стиль оригинальной презентации. Ниже перечислены поддерживаемые эффекты переходов.

**Тонкие**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Энергичные**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Динамический контент**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **Часто задаваемые вопросы**

**Можно ли конвертировать презентации, защищённые паролем?**

Да, Aspose.Slides for Python позволяет работать с презентациями, защищёнными паролем. При обработке таких файлов необходимо указать правильный пароль, чтобы библиотека смогла получить доступ к содержимому презентации.

**Поддерживает ли Aspose.Slides for Python использование в облачных решениях?**

Да, Aspose.Slides for Python может быть интегрирован в облачные приложения и сервисы. Библиотека спроектирована для работы в серверных средах, обеспечивая высокую производительность и масштабируемость при пакетной обработке файлов.

**Есть ли ограничения по размеру презентаций при конвертации?**

Aspose.Slides for Python способен обрабатывать презентации практически любого размера. Однако при работе с очень большими файлами могут потребоваться дополнительные системные ресурсы, и иногда рекомендуется оптимизировать презентацию для повышения производительности.