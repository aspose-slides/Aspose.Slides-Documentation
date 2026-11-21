---
title: "Изменение размера и ориентации страницы заметок в Python через Java"
linktitle: "Размер страницы заметок"
type: docs
weight: 10
url: /ru/python-java/notes-size/
keywords:
- размер страницы заметок
- ориентация заметок
- альбомные заметки
- портретные заметки
- размер раздаточного материала
- PowerPoint
- презентация
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Чтение и изменение размеров страницы заметок в Aspose.Slides для Python через Java, переключение ориентации, проверка сохранённых размеров и экспорт заметок или раздаточного материала в PDF и изображения."
---
## **Обзор**

Используйте [Presentation.getNotesSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getNotesSize), чтобы получить доступ к настройкам страницы заметок презентации. Метод возвращает объект [NotesSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notessize/), у которого метод [setSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notessize/#setSize) задаёт размеры страницы. Хотя сам объект настроек нельзя заменить, вы можете задать новые размеры с помощью этого метода.

Ширина и высота указываются в **точках**, по 72 точки на дюйм. Например, 900 × 600 точек соответствуют 12,5 × 8⅓ дюйма. Эти настройки применяются к презентации, а не к заметкам отдельного слайда.

| Параметр | Назначение |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getNotesSize) | Контролирует размеры страницы заметок и размеры страницы, используемые при экспорте раздаточных материалов. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlideSize) | Контролирует размеры обычных слайдов презентации через [SlideSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidesize/). |

Изменение любой из этих настроек автоматически не меняет другую. Изменение ориентации страницы заметок также не вращает обычные слайды. Смотрите [Slide Size](/slides/ru/python-java/slide-size/), чтобы изменить размер обычных слайдов.

В примерах ниже используется существующий файл `sample.pptx`. Для примеров экспорта используйте презентацию, содержащую как минимум один слайд с заметками докладчика. Каждый пример можно запускать независимо.

## **Чтение размеров и ориентации страницы заметок**

Считайте ширину и высоту и сравните их, чтобы определить ориентацию: более широкая страница — альбомная, более высокая — портретная, а одинаковые размеры описывают квадратную страницу. Этот пример выводит фактические размеры в точках, не предполагая стандартный размер бумаги.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Переключить на альбомный режим без изменения размера бумаги**

Чтобы изменить только ориентацию, поменяйте местами текущие ширину и высоту. Это сохраняет длину обеих сторон, включая размеры пользовательской бумаги. Условие ниже предотвращает переключение уже альбомной страницы обратно в портретный режим и оставляет квадратную страницу без изменений.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Для портретной ориентации используйте то же присваивание, когда `size.getWidth() > size.getHeight()`. Не подставляйте размеры A4 или Letter, если только вы не хотите изменить размер бумаги.

## **Установить и проверить пользовательский размер страницы заметок**

Задайте оба параметра одновременно, затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) для записи презентации. Этот пример устанавливает альбомную страницу размером 900 × 600 точек, сохраняет её как PPTX и снова открывает сохранённый файл, чтобы проверить сохранённые значения. Сравнение допускает погрешность 0,01 точки для значений с плавающей запятой; это не гарантирует точность для каждого формата файла.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Ожидаемый результат: `900.0 x 600.0 points` и `Size preserved: True`. Проверка вновь открытой презентации подтверждает сохранённый файл, а не только настройки в памяти.

## **Экспорт заметок и раздаточных материалов**

Размеры страницы определяют доступную область для заметок или раздаточных макетов. Они не активируют эти макеты сами по себе: также необходимо настроить параметры экспорта. Экспорт обычных слайдов продолжает использовать размеры слайда.

### **Экспорт заметок в PDF и PNG**

Назначьте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/) параметру [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions), чтобы включить заметки в PDF. Этот пример также рендерит первый слайд с заметками в PNG с помощью [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage) и [RenderingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/renderingoptions/).

Режим [BottomTruncated](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notespositions/) оставляет заметки на одной странице; заметки, не помещающиеся полностью, могут быть усечены. PDF использует страницы размером 900 × 600 точек. При масштабе изображения 1 × 1, используемом ниже, PNG имеет размер 900 × 600 пикселей. Точки описывают геометрию страницы; пиксели описывают растровый вывод, размеры которого также зависят от масштаба рендеринга.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Для экспорта PDF с длинными заметками [BottomFull](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notespositions/) позволяет при необходимости создавать дополнительные страницы. Не используйте этот режим с вызовом одиночного слайда в виде изображения выше, который его не поддерживает. После изменения размеров проверьте результат на наличие усечённых заметок и размещение существующих объектов мастера заметок; изменение размеров страницы само по себе не гарантирует, что всё содержимое поместится. Смотрите [Convert PowerPoint to PDF with Notes](/slides/ru/python-java/convert-powerpoint-to-pdf-with-notes/) для получения дополнительной информации об экспорте заметок.

### **Экспорт раздаточных материалов в PDF**

Используйте [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/handoutlayoutingoptions/) для размещения нескольких миниатюр слайдов на одной странице. Приведённый пример устанавливает страницу размером 900 × 600 точек и использует [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ru/python-java/aspose.slides/handouttype/) для размещения до четырёх слайдов на странице. Горизонтальная предустановка управляет порядком слайдов; ориентация страницы берётся из её ширины и высоты.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Изменение размера страницы меняет область, доступную для сетки раздаточного материала, не изменяя размеры исходных слайдов. Для изображений раздаточных материалов используйте [Presentation.getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages) с раздаточным макетом, а не метод получения изображения отдельного слайда. В Aspose.Slides рендеринг раздаточных материалов уровня презентации использует размеры страницы заметок, тогда как вызов получения изображения отдельного слайда не создаёт страницу раздаточного материала. Смотрите [Handout Mode](/slides/ru/python-java/convert-powerpoint-in-handout-mode/) для вариантов макетов.

## **Размер страницы в просмотровщиках, экспорте и печати**

Сохраняйте различие между размером, хранящимся в презентации, размером экспортированной страницы и размером печатной бумаги:

- **Просмотрщики презентаций:** Просмотрщик может отображать или печатать заметки, используя свои правила компоновки. Если другое приложение сохраняет файл, откройте его снова и проверьте размеры; конвертация формата этим приложением может их нормализовать.
- **Форматы экспорта:** Приведённые выше примеры PDF с заметками и раздаточными материалами используют сконфигурированные размеры страницы. Растровые изображения используют целочисленные размеры в пикселях и масштаб рендеринга, поэтому дробные значения точек могут быть округлены в выводе изображения. Экспорт обычных слайдов не использует размер страницы заметок.
- **Драйверы принтеров:** Выбор бумаги, автоматическое вращение и настройки подгонки к странице могут изменить физический вывод без изменения размеров, хранящихся в презентации или PDF. Для конкретного размера бумаги согласуйте настройки принтера и проверьте предварительный просмотр печати.

## **FAQ**

**Можно ли задать размер заметок только для одного слайда?**

Размер страницы заметок — настройка уровня презентации. Отдельные слайды могут иметь разное содержимое заметок, но это свойство не предоставляет отдельный размер страницы для каждого слайда.

**Почему изменение ориентации заметок не изменило мои слайды?**

Страницы заметок и обычные слайды имеют независимые размеры. Используйте настройки размера обычных слайдов, когда хотите изменить размеры самих слайдов.

**Почему мой сохранённый или распечатанный результат имеет другой размер?**

Сначала откройте снова сохранённую презентацию и сравните её размеры заметок. Если они изменились, проверьте, изменило ли сохранение или конвертация файла в другом приложении настройки страницы. Если нет, проверьте макет экспорта, масштаб изображения, настройки просмотрщика и выбор бумаги принтером.