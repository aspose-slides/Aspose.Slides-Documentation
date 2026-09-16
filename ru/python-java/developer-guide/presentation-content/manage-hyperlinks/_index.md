---
title: Управление гиперссылками презентации в Python через Java
linktitle: Управление гиперссылками
type: docs
weight: 20
url: /ru/python-java/manage-hyperlinks/
keywords:
- добавить URL
- добавить гиперссылку
- создать гиперссылку
- форматировать гиперссылку
- удалить гиперссылку
- обновить гиперссылку
- текстовая гиперссылка
- гиперссылка на слайд
- гиперссылка на фигуру
- гиперссылка на изображение
- гиперссылка на видео
- изменяемая гиперссылка
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Добавляйте, форматируйте, обновляйте и удаляйте гиперссылки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через Java, используя примеры на Python."
---
## **Введение**

Гиперссылка соединяет содержимое презентации с веб‑сайтом или местом внутри презентации. В PowerPoint гиперссылки обычно служат двум целям:

* Открыть веб‑сайт из текста, фигуры или медиа‑кадра.
* Перейти к другому слайду, например, из оглавления.

Aspose.Slides for Python via Java позволяет добавлять такие ссылки, управлять их внешним видом и звуком, обновлять свойства и удалять их. Приведённые ниже примеры показывают, как работать с гиперссылками на отдельных элементах и как получать доступ к гиперссылкам на уровне презентации, слайда или текстового кадра.

{{% alert color="info" title="Note" %}}

Вы также можете редактировать презентации с помощью [бесплатного онлайн‑редактора Aspose PowerPoint](https://products.aspose.app/slides/ru/editor).

{{% /alert %}} 

## **Добавление гиперссылок URL**

Вы можете присвоить URL‑адрес веб‑сайта тексту, фигуре или медиа‑кадру. Элемент, к которому вы назначаете гиперссылку, определяет область клика: часть текста связывает выбранный текст, а фигура или кадр — объект слайда.

### **Добавление гиперссылок URL к тексту**

Чтобы связать текст с веб‑сайтом, передайте объект [Hyperlink](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/) в метод [setHyperlinkClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/#setHyperlinkClick) части текста, как показано ниже. Щелкать можно будет только по этой части текста.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Добавление гиперссылок URL к фигурам и медиа‑кадрам**

Чтобы сделать фигуру или кадр кликабельными, вызовите у них метод [setHyperlinkClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#setHyperlinkClick). Гиперссылка принадлежит самому объекту, а не текстовой части внутри него.

Тот же подход применяется к кадрам изображений, аудио и видео: назначьте гиперссылку кадру и при необходимости вызовите [setTooltip](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setTooltip).

В следующем примере прямоугольник становится кликабельным:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Использование гиперссылок для создания оглавления**

Внутренние гиперссылки позволяют читателям переходить из оглавления к конкретному слайду. В следующем примере используется метод [setInternalHyperlinkClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) для связывания текста «Страница 2» на первом слайде со вторым слайдом.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Форматирование гиперссылок**

### **Цвет**

Метод [setColorSource](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setColorSource) класса [Hyperlink](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/) определяет, использует ли гиперссылка цвет гиперссылки презентации или форматирование части текста. Чтобы применить собственный цвет текста, выберите [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkcolorsource/) и задайте цвет заливки части. Эта возможность появилась в PowerPoint 2019; в более ранних версиях параметр не применяется.

В следующем примере добавляются две текстовые гиперссылки на один и тот же слайд. Первая использует красный цвет текста, вторая сохраняет цвет гиперссылки по умолчанию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Звук**

Гиперссылка может воспроизводить звук при активации или останавливать уже играющий звук. Используйте следующие методы для настройки этих действий:

- [Hyperlink.setSound](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setSound) задаёт аудио, связанное с гиперссылкой.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) определяет, будет ли активация гиперссылки останавливать предыдущий звук.

#### **Добавление звука к гиперссылке**

В следующем примере загружается файл `sampleaudio.wav` и связывается с кнопкой на первом слайде. Щелчок по кнопке воспроизводит звук и переходит к следующему слайду. Вторая фигура на том же слайде останавливает предыдущий звук при щелчке, не выполняя перехода.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Извлечение звука из гиперссылки**

В следующем примере открывается презентация, созданная выше, и считывается аудио гиперссылки первой фигуры в память с помощью методов [getSound](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#getSound) и [getBinaryData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Всплывающая подсказка и параметры взаимодействия**

После назначения гиперссылки тексту или фигуре вы можете вызвать следующие методы класса [Hyperlink](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/):

- [setTooltip](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setTooltip) задаёт текст подсказки, который отображается зрителю.
- [setTargetFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setTargetFrame) указывает целевой кадр внутри родительского HTML‑фреймсета, если применимо.
- [setHistory](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setHistory) определяет, будет ли активация ссылки добавлять её цель в список просмотренных гиперссылок.
- [setHighlightClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setHighlightClick) определяет, будет ли гиперссылка подсвечиваться при клике.

## **Удаление гиперссылок из презентаций**

Используйте метод [getAnyHyperlinks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) для получения контейнеров гиперссылок, включая ссылки на части текста, перед их изменением. В следующем примере удаляются оба типа активации с первого слайда. Чтобы удалить только один тип, вызовите лишь [removeHyperlinkClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) или [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); удаление действия щелчка не удаляет его аналог при наведении.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Для безусловного удаления метод [removeAllHyperlinks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) удаляет оба типа активации в выбранном диапазоне одним вызовом. Для выборочной очистки и охвата мастеров, макетов и заметок см. раздел [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Создание полного реестра гиперссылок**

Перед распространением презентации проинвентаризуйте её интерактивные действия и веб‑ссылки. Метод [getAnyHyperlinks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) возвращает контейнеры гиперссылок, такие как объекты [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/) и [PortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/), а не плоский список строк URL. Проверяйте как [getHyperlinkClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getHyperlinkClick), так и [getHyperlinkMouseOver](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getHyperlinkMouseOver) у каждого контейнера. Они независимы: один контейнер может предоставлять оба действия, поэтому полный отчёт требует до двух строк на контейнер.

Сканирование только гиперссылок уровня фигур может пропустить ссылки, прикреплённые к частям текста. Запрашивайте нужный диапазон и сохраняйте полученные контейнеры, чтобы позже обновить или удалить их действия.

### **Запрос диапазонов презентации, слайда и текстового кадра**

Класс [HyperlinkQueries](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/) доступен через свойства [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getHyperlinkQueries) и [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getHyperlinkQueries). Каждый диапазон поддерживает одинаковые запросы:

- [getHyperlinkClicks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) возвращает контейнеры с действием клика.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) возвращает контейнеры с действием наведения.
- [getAnyHyperlinks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) возвращает контейнеры с любым из действий или с обоими.

В следующем примере создаётся файл `hyperlink-audit-input.pptx` с внешней ссылкой‑клик, ссылкой‑наведение на файл, внутренней навигацией по слайду, ссылкой‑наведение на текст и макросом. Действия не выполняются. Три запроса работают в каждом диапазоне; счётчики отражают количество контейнеров, а не действий. Диапазон текстового кадра исключает собственные ссылки содержащей его фигуры.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Для данного примера запросы презентации и слайда возвращают по три контейнера клика, два контейнера наведения и три контейнера с любым действием. Запрос текстового кадра возвращает по одному контейнеру в каждой категории.

### **Классификация действий и назначений**

Используйте [Hyperlink.getActionType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#getActionType) для определения типа действия перед анализом назначения. Значения [HyperlinkActionType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkactiontype/) охватывают более чем просто веб‑навигацию:

| Значения | Значение для аудита |
| --- | --- |
| `Hyperlink` | Внешняя гиперссылка; проверьте URL и его схему. |
| `JumpSpecificSlide` | Внутренняя навигация к определённому слайду. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Встроенная навигация слайд‑шоу, работает в контексте показа. |
| `JumpEndShow`, `StartCustomSlideShow` | Завершить текущий показ или запустить пользовательский показ. |
| `StartMacro` | Выполнить макрос. |
| `StartProgram` | Запустить программу. |
| `OpenFile`, `OpenPresentation` | Открыть файл или другую презентацию; рассматривайте отдельно от веб‑URL. |
| `StartStopMedia` | Запустить или остановить воспроизведение медиа. |
| `NoAction`, `Unknown` | Нет навигационного действия или неопознанное действие, требующее проверки. |

Читаем внешние назначения через [getExternalUrl](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#getExternalUrl) и конкретные внутренние назначения через [getTargetSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#getTargetSlide). Внутренние действия и встроенные команды могут не иметь внешнего URL; пустой URL не означает отсутствие действия у контейнера. Сохраняйте значение, возвращаемое [getExternalUrlOriginal](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal), если оно отличается от нормализованного URL, и включайте всплывающую подсказку из [getTooltip](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#getTooltip), когда она доступна.

### **Отчёт, очистка и проверка гиперссылок**

Следующий пример на Python читает существующую презентацию (используйте файл, созданный выше), пишет `hyperlink-audit.json`, применяет политику, сохраняет `hyperlink-sanitized.pptx` и снова открывает её для повторной проверки обоих типов активаций. Он собирает контейнеры до их изменения и использует сравнение ссылок, чтобы не обрабатывать один и тот же контейнер дважды. Запросы презентации охватывают обычные слайды; для инвентаризации всего пакета дополнительно явно запрашиваются мастера, макеты, заметки и мастеры заметок/раздаточных материалов, если они присутствуют.

Отчёт фиксирует индекс слайда, начиная с 1, и [getSlideId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getSlideId), если он доступен. Метод [getSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getSlide) предоставляет владелец‑слайд для поддерживаемых контейнеров. У мастеров, макетов и заметок нет обычного индекса слайда и они идентифицируются по диапазону. Контейнеры фигур и форматирования текстовых частей помечаются отдельно; остальные типы сохраняют своё имя типа во время выполнения. Каждый контейнер получает локальный идентификатор отчёта, чтобы его два действия можно было сопоставить. В отчёте типы действий сохраняются как целочисленные константы, определённые перечислением Java.

Эта ограничительная политика позволяет только абсолютные HTTPS‑URL и корректные внутренние ссылки на слайды. Она отклоняет макросы, программы, файловые действия, другие действия слайд‑шоу, неизвестные действия и другие схемы URL. Такие отклонения – решения политики, а не вывод о безопасности Aspose.Slides. HTTPS сам по себе не гарантирует доверие: добавьте списки разрешённых хостов и другие проверки для вашего приложения. Проверяются как оригинальные, так и нормализованные внешние URL. Пример проверяет метаданные без перехода по ссылкам и без выполнения действий.

Для исправления контейнеров [getHyperlinkManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getHyperlinkManager) поддерживает методы [setExternalHyperlinkClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) и [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Здесь запрещённые внешние ссылки‑клик заменяются фиксированной HTTPS‑страницей; остальные запрещённые клики и действия‑наведения удаляются независимо. Установите `replace_external_clicks` в `False`, чтобы удалить все нарушения политики. Выберите страницу‑заменитель, управляемую приложением, перед развертыванием.

Флаг экспорта в отчёте использует консервативную политику проверки PDF: помечать действия‑наведение и всё, что не является внешней ссылкой или переходом к конкретному слайду, как потенциально неподдерживаемое. Это лишь подсказка для проверки, а не тест возможностей или гарантия, что непомеченные ссылки сохранятся при экспорте. Поддерживаемый экспорт в [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/python-java/convert-powerpoint-to-html/) может сохранять гиперссылки в зависимости от действия, параметров экспорта и программы‑просмотрщика. Растровые [изображения](/slides/ru/python-java/convert-powerpoint-to-png/) и [видео](/slides/ru/python-java/convert-powerpoint-to-video/) не могут сохранять интерактивные гиперссылки; помечайте каждое действие при аудите для этих форматов.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

С созданным выше входным файлом в отчёте будет пять строк действий. Ссылка‑наведение на файл и макрос‑клик удаляются, тогда как HTTPS‑ссылки и внутренняя навигация по слайдам сохраняются. Проверка выводит ноль запрещённых действий. Вход, содержащий запрещённый внешний URL‑клик, также демонстрирует ветку замены. Контейнер с разрешённым кликом и запрещённым наведением сохраняет своё действие‑клик.

Эта выборочная очистка отличается от [removeAllHyperlinks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), который удаляет оба типа активаций в выбранном диапазоне независимо от политики. Здесь проверка действий гиперссылок не удаляет встроенные VBA‑проекты, OLE‑объекты или другое активное содержание и не валидирует экспортированный PDF‑ или HTML‑файл.

## **FAQ**

**Как создать ссылку на раздел или его первый слайд?**

Разделы в PowerPoint группируют слайды, но внутренняя гиперссылка указывает конкретный слайд. Чтобы создать навигацию к разделу, связывайте её с первым слайдом этого раздела.

**Можно ли прикрепить гиперссылку к элементам шаблона слайда, чтобы она работала на всех слайдах?**

Да. Элементы шаблона и макета поддерживают гиперссылки. Ссылки на этих элементах доступны во время показа на слайдах, использующих соответствующий шаблон или макет.

**Сохраняются ли гиперссылки при экспорте в PDF, HTML, изображения или видео?**

Поддерживаемый экспорт в PDF и HTML может сохранять гиперссылки; растровые изображения и видео — нет. Смотрите замечания по экспорту в разделе [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).