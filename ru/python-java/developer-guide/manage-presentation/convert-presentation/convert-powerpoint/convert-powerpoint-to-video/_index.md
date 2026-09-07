---
title: Преобразование презентаций PowerPoint в видео на Python
linktitle: PowerPoint в видео
type: docs
weight: 130
url: /ru/python-java/convert-powerpoint-to-video/
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
- Python
- Java
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint в MP4‑видео на Python через Java. Генерируйте кадры с помощью Aspose.Slides и кодируйте их с помощью FFmpeg, включая анимацию и переходы."
---
## **Обзор**

Преобразование презентации PowerPoint или OpenDocument в видео позволяет зрителям просматривать её содержимое в видеоплеере без открытия приложения для работы с презентациями. Aspose.Slides for Python via Java рендерит анимацию и переходы презентации в кадры‑изображения. Отдельный кодировщик, например FFmpeg, объединяет эти кадры в видеофайл.

{{% alert color="info" title="Примечание" %}}
Попробуйте онлайн‑конвертер [PowerPoint to Video converter](https://products.aspose.app/slides/ru/video), чтобы увидеть процесс преобразования презентации в видео в действии.
{{% /alert %}}

## **Преобразование PowerPoint в видео**

Конвертация состоит из двух этапов: генерация PNG‑кадров с выбранной частотой кадров, а затем кодирование последовательности изображений в MP4. Используйте одну и ту же частоту кадров на обоих этапах, чтобы сохранить синхронизацию анимации.

Перед запуском примера:

1. Установите [Aspose.Slides for Python via Java](/slides/ru/python-java/installation/).
2. Скачайте [FFmpeg](https://ffmpeg.org/download.html) и сделайте его исполняемый файл доступным в `PATH`. Пример использует сборку с кодеком `libx264`.
3. Запустите следующий код Python в записываемом каталоге.

Пример создает улыбающуюся фигуру с анимациями входа и выхода, рендерит кадры со скоростью 30 FPS и вызывает FFmpeg для создания `output.mp4`. Новый каталог кадров предотвращает включение кадров из предыдущих запусков в видео.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

Чтобы преобразовать существующий файл, инициализируйте [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) с указанием пути к нему и опустите операторы создания фигур и анимаций.

Команда FFmpeg считывает пронумерованную [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2), дополняет нечётные размеры до чётных значений и записывает видео H.264 с пиксельным форматом `yuv420p`. Параметр `-n` предотвращает перезапись существующего выходного файла. Сгенерированные PNG‑файлы остаются в каталоге кадров; удалите их, когда они больше не нужны.

{{% alert color="info" title="Примечание" %}}
Этот пример кодирует только кадры‑изображения. Он не добавляет закадровый голос или встроенный аудио‑трек презентации в выходное видео.
{{% /alert %}}

## **Видео‑эффекты**

Анимации управляют тем, как объекты слайда появляются, перемещаются или исчезают. Переходы определяют изменение между слайдами. Добавьте эти эффекты перед генерацией видеокадров.

Смотрите [PowerPoint Animation](/slides/ru/python-java/powerpoint-animation/), [Shape Animation](/slides/ru/python-java/shape-animation/), [Shape Effects](/slides/ru/python-java/shape-effect/), и [Slide Transitions](/slides/ru/python-java/slide-transition/).

### **Добавить переход слайда**

Следующий автономный пример создаёт презентацию из двух слайдов. Второй слайд имеет пурпурный фон и переход «push». Сохраните презентацию, а затем используйте её в качестве входных данных для примера генерации кадров выше.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Анимировать абзацы**

Текст может появляться абзац за абзацем. Этот пример создаёт три абзаца с последовательными эффектами появления «fade», каждый задерживается на одну секунду после предыдущего эффекта. Используйте сохранённый файл `paragraphs.pptx` в качестве входных данных для примера конвертации в видео.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Классы конвертации видео**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationanimationsgenerator/) генерирует события анимации для слайдов. При создании из презентации используется размер слайда презентации для кадров. Используйте [setDefaultDelay](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) для настройки задержки по умолчанию в миллисекундах.

[PresentationPlayer](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationplayer/) выбирает образцы сгенерированных анимаций с частотой кадров, переданной в его конструктор. Зарегистрируйте Python‑обратный вызов через JPype с помощью [setFrameTick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationplayer/#setFrameTick), затем вызовите [run](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationanimationsgenerator/#run) для генерации кадров. Первый пример использует собственный счётчик, начинающийся с нуля, чтобы имена файлов соответствовали последовательности ввода FFmpeg.

Для отдельных состояний анимации зарегистрируйте обратный вызов с помощью [setNewAnimation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). Обратный вызов получает проигрыватель анимации, который можно позиционировать в выбранный момент времени. Следующий пример сохраняет первый и последний кадры каждой сгенерированной анимации с уникальными именами файлов:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **Поддерживаемые анимации и эффекты**

В следующих таблицах суммирована поддержка рендеринга, описанная в статье о конвертации на Java. Предпросматривайте сгенерированные кадры, когда презентация использует эффекты, которые не поддерживаются.

**Вход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly In** | Yes | Yes |
| **Float In** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Wheel** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Grow & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**Акцент**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | No | Yes |
| **Color Pulse** | No | Yes |
| **Teeter** | Yes | Yes |
| **Spin** | Yes | Yes |
| **Grow/Shrink** | No | Yes |
| **Desaturate** | No | Yes |
| **Darken** | No | Yes |
| **Lighten** | No | Yes |
| **Transparency** | No | Yes |
| **Object Color** | No | Yes |
| **Complementary Color** | No | Yes |
| **Line Color** | No | Yes |
| **Fill Color** | No | Yes |

**Выход**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly Out** | Yes | Yes |
| **Float Out** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Shrink & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**Пути движения:**:

| Тип анимации | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Yes | Yes |
| **Arcs** | Yes | Yes |
| **Turns** | Yes | Yes |
| **Shapes** | Yes | Yes |
| **Loops** | Yes | Yes |
| **Custom Path** | Yes | Yes |

## **FAQ**

**Создаёт ли Aspose.Slides MP4‑файл напрямую?**

Нет. Aspose.Slides генерирует кадры презентации. Используйте видеокодировщик, например FFmpeg, чтобы объединить их в MP4‑файл.

**Почему видео воспроизводится быстрее или медленнее, чем ожидалось?**

Используйте одинаковое количество FPS для генерации кадров и частоты кадров входных данных кодировщика. Несоответствие изменяет длительность воспроизведения последовательности изображений.

**Могу ли я конвертировать защищённую паролем презентацию?**

Да. Укажите правильный пароль при [загрузке защищённой презентации](/slides/ru/python-java/password-protected-presentation/), затем генерируйте кадры из загруженного содержимого.

**Сохраняет ли этот процесс аудио презентации?**

Примеры экспортируют только кадры‑изображения, поэтому получившееся видео беззвучно. Чтобы включить аудио, добавьте аудиотрек отдельно при кодировании видео.

**Как уменьшить временное использование диска?**

Используйте меньший размер кадра или более низкое FPS и удаляйте временные PNG‑файлы после успешного кодирования. Проверяйте качество полученного видео при изменении любого из этих параметров.