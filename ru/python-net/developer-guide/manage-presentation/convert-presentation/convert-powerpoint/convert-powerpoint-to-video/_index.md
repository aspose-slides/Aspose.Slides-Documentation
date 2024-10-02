---
title: Конвертация PowerPoint в Видео
type: docs
weight: 130
url: /ru/python-net/convert-powerpoint-to-video/
keywords: "Конвертация PowerPoint, PPT, PPTX, Презентация, Видео, MP4, PPT в видео, PPT в MP4, Python, Aspose.Slides"
description: "Конвертация PowerPoint в Видео на Python"
---

Конвертировав вашу презентацию PowerPoint в видео, вы получите 

* **Увеличение доступности:** Все устройства (независимо от платформы) по умолчанию имеют встроенные видеоплееры, в отличие от приложений для открытия презентаций, поэтому пользователям легче открывать или воспроизводить видео.
* **Большее охват:** С помощью видео вы можете достичь широкой аудитории и донести до нее информацию, которая в противном случае могла бы показаться скучной в презентации. Большинство опросов и статистики предполагают, что люди больше смотрят и потребляют видео, чем другие формы контента, и обычно предпочитают такой контент.

{{% alert color="primary" %}} 

Вам может быть интересно проверить наш [**Онлайн-конвертер PowerPoint в Видео**](https://products.aspose.app/slides/conversion/ppt-to-word), так как это активная и эффективная реализация процесса, описанного здесь.

{{% /alert %}} 

## **Конвертация PowerPoint в Видео с помощью Aspose.Slides**

В [Aspose.Slides 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) мы реализовали поддержку конвертации презентаций в видео.

* Используйте Aspose.Slides для генерации набора кадров (из слайдов презентации), соответствующих определенному FPS (кадров в секунду)
* Используйте стороннюю утилиту, такую как ffmpeg, для создания видео на основе кадров.

### **Конвертация PowerPoint в Видео**

1. Используйте команду pip install для добавления Aspose.Slides в ваш проект:
   * выполните `pip install Aspose.Slides==24.4.0`
2. Скачайте ffmpeg [здесь](https://ffmpeg.org/download.html) или установите через менеджер пакетов.
3. Убедитесь, что ffmpeg в `PATH`, в противном случае запустите ffmpeg, используя полный пут к бинарнику (например, `C:\ffmpeg\ffmpeg.exe` на Windows или `/opt/ffmpeg/ffmpeg` на Linux)
4. Запустите код конвертации PowerPoint в видео.

Этот код на Python демонстрирует, как конвертировать презентацию (содержащую фигуру и два анимационных эффекта) в видео:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    smile = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)
    effect_in = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.TOP_LEFT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_out = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM_RIGHT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "smile.webm"]
    subprocess.call(cmd_line)
```

## **Виде efekty**

Вы можете применять анимации к объектам на слайдах и использовать переходы между слайдами.

{{% alert color="primary" %}} 

Вам может быть интересно прочитать эти статьи: [Анимация PowerPoint](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Анимация Фигур](https://docs.aspose.com/slides/python-net/shape-animation/), и [Эффект Фигуры](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

Анимации и переходы делают слайд-шоу более увлекательными и интересными — и они делают то же самое и для видео. Давайте добавим еще один слайд и переход к коду для предыдущей презентации:

```python
import aspose.pydrawing as drawing
# Добавляет фигуру смайла и анимирует ее
# ...
# Добавляет новый слайд и анимированный переход

new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides также поддерживает анимацию текстов. Так что мы анимируем абзацы на объектах, которые будут появляться один за другим (с задержкой, установленной на одну секунду):

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    # Добавляет текст и анимации
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose Slides для .NET"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("конвертация презентации PowerPoint с текстом в видео"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("абзац за абзацем"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = presentation.slides[0].timeline.main_sequence.add_effect(para1, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = presentation.slides[0].timeline.main_sequence.add_effect(para2, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Конвертирует кадры в видео
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Классы Конвертации Видео**

Чтобы позволить вам выполнять задачи по конвертации PowerPoint в видео, Aspose.Slides предоставляет [PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/).

PresentationEnumerableAnimationsGenerator позволяет вам установить размер кадра для видео (которое будет создано позже) и значение FPS (кадров в секунду) через его конструктор. Если вы передаете экземпляр презентации, будет использоваться `Presentation.SlideSize`.

Чтобы заставить все анимации в презентации воспроизводиться одновременно, используйте метод PresentationEnumerableAnimationsGenerator.enumerate_frames. Этот метод принимает коллекцию слайдов и позволяет последовательно получать [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/). Затем EnumerableFrameArgs.get_frame() позволяет вам получить кадр видео:

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Затем сгенерированные кадры могут быть собраны для создания видео. Смотрите раздел [Конвертация PowerPoint в Видео](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Поддерживаемые Анимации и Эффекты**


**Входные:**

| Тип Анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Появление** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Затухание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Влет** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Плавный Влет** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Разделение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Стирание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Фигура** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Колесо** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Случайные Полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Увеличение и Поворот** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Масштабирование** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Поворот** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Упругость** | ![поддерживается](v.png) | ![поддерживается](v.png) |


**Усиление:**

| Тип Анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Пульсация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цветовая Пульсация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Качение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вращение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Увеличение/Уменьшение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Десатурация** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Потемнение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Осветление** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Прозрачность** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет Объекта** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Дополнительный Цвет** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет Линии** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Цвет Заполнения** | ![не поддерживается](x.png) | ![поддерживается](v.png) |

**Выход:**

| Тип Анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Исчезление** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Затухание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Улетающий Эффект** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Плавный Улет** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Разделение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Стирание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Фигура** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Случайные Полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Уменьшение и Поворот** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Масштабирование** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Поворот** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Упругость** | ![поддерживается](v.png) | ![поддерживается](v.png) |

**Движущиеся Пути:**

| Тип Анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Линии** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Арки** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Повороты** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Формы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Петли** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Пользовательская Дорога** | ![поддерживается](v.png) | ![поддерживается](v.png) |

## **Поддерживаемые Эффекты Перехода Слайдов**

**Субтитры:**

| Тип Анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Морф** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Затухание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Толчок** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Тянущий Эффект** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Стирание** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Разделение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Раскрытие** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Случайные Полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Фигура** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Открытие** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Закрытие** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Вспышка** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Полосы** | ![поддерживается](v.png) | ![поддерживается](v.png) |

**Захватывающие:**

| Тип Анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Падение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Драпировка** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Занавес** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Ветер** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Престиж** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Фрактура** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Давление** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Сдергивание** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Сгибание Страницы** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Самолет** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Оригами** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Растворение** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Шашечница** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Заслон** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Часы** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Рябь** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Сот** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Сверкание** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Вихрь** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Резка** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Переключение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Переворот** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Галерея** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Куб** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Двери** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Коробка** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Гребень** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Масштабирование** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Случайный** | ![не поддерживается](x.png) | ![поддерживается](v.png) |

**Динамическое Содержимое:**

| Тип Анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Панорама** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Колесо Обозрения** | ![поддерживается](v.png) | ![поддерживается](v.png) |
| **Конвейер** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Вращение** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Орбита** | ![не поддерживается](x.png) | ![поддерживается](v.png) |
| **Полет** | ![поддерживается](v.png) | ![поддерживается](v.png) |
