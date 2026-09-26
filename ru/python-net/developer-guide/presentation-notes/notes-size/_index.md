---
title: Изменение размера и ориентации страницы заметок в Python
linktitle: Размер страницы заметок
type: docs
weight: 10
url: /ru/python-net/notes-size/
keywords:
- размер страницы заметок
- ориентация заметок
- альбомные заметки
- книжные заметки
- размер раздаточного листа
- PowerPoint
- презентация
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Читать и изменять размеры страницы заметок в Aspose.Slides для Python через .NET, переключать ориентацию, проверять сохранённые размеры и экспортировать заметки или раздаточные листы в PDF и изображения."
---
## **Обзор**

Используйте [Presentation.notes_size](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/notes_size/) для доступа к настройкам страницы заметок презентации. Он возвращает объект [NotesSize](https://reference.aspose.com/slides/ru/python-net/aspose.slides/notessize/) , свойство [size](https://reference.aspose.com/slides/ru/python-net/aspose.slides/notessize/size/) которого доступно для записи. Хотя сам объект настроек доступен только для чтения, вы можете присваивать новые размеры его свойству size.

Ширина и высота задаются в **точках**, по 72 точки на дюйм. Например, 900 × 600 точек соответствует 12,5 × 8⅓ дюйма. Эти настройки применяются к презентации в целом, а не к заметкам отдельного слайда.

| Параметр | Назначение |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/notes_size/) | Контролирует размеры страницы заметок и размеры страницы, используемые при экспорте раздаточных материалов. |
| [Presentation.slide_size](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/slide_size/) | Контролирует размеры обычных слайдов презентации через [SlideSize](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidesize/). |

Изменение любого из этих параметров не меняет автоматически другой. Изменение ориентации страницы заметок также не вращает обычные слайды. См. [Slide Size](/slides/ru/python-net/slide-size/) для изменения размеров обычных слайдов.

Ниже приведённые примеры используют существующий файл `sample.pptx`. Для примеров экспорта используйте презентацию, содержащую хотя бы один слайд с заметками выступающего. Каждый пример можно запускать независимо.

## **Чтение размеров и ориентации страницы заметок**

Считайте ширину и высоту и сравните их, чтобы определить ориентацию: более широкая страница — альбомная, более высокая — книжная, одинаковые размеры описывают квадратную страницу. Этот пример выводит фактические размеры в точках, не предполагая стандартный размер бумаги.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Переход в альбомную ориентацию без изменения размера бумаги**

Чтобы изменить только ориентацию, поменяйте местами текущие ширину и высоту. Это сохраняет длины обеих сторон, в том числе пользовательского размера бумаги. Условие ниже предотвращает переключение уже альбомной страницы обратно в книжную и оставляет квадратную страницу без изменений.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Для книжной ориентации используйте то же присваивание, когда `size.width > size.height`. Не заменяйте размеры A4 или Letter, если только вы не хотите изменить размер бумаги.

## **Установка и проверка пользовательского размера страницы заметок**

Присвойте обе размеры одновременно, затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/) для записи презентации. Этот пример устанавливает альбомную страницу размером 900 × 600 точек, сохраняет её как PPTX и открывает сохранённый файл снова, чтобы проверить сохранённые значения. При сравнении допускается погрешность 0,01 точки для значений с плавающей запятой; это не гарантирует точность для всех форматов файлов.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

Ожидаемый результат: `900 x 600 points` и `Size preserved: True`. Проверка вновь открытой презентации подтверждает сохранённый файл, а не только настройки в памяти.

## **Экспорт заметок и раздаточных материалов**

Размеры страницы определяют доступную область для макетов заметок или раздаточных материалов. Они не активируют эти макеты сами по себе: необходимо также настроить параметры экспорта. Экспорт обычных слайдов по‑прежнему использует размеры слайда.

### **Экспорт заметок в PDF и PNG**

Присвойте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/notescommentslayoutingoptions/) свойству [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) чтобы включить заметки в PDF. Этот пример также рендерит первый слайд с заметками в PNG с помощью [Slide.get_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/get_image/) и [RenderingOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/renderingoptions/).

Режим [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/notespositions/) помещает заметки на одну страницу; заметки, которые не помещаются, могут быть усечены. PDF использует страницы размером 900 × 600 точек. При масштабе изображения 1 × 1, используемом ниже, PNG имеет размер 900 × 600 пикселей. Точки описывают геометрию страницы; пиксели — растровый вывод, размеры которого также зависят от масштаба рендеринга.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

При экспорте PDF с длинными заметками [BOTTOM_FULL](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/notespositions/) позволяет добавлять дополнительные страницы по мере необходимости. Не используйте этот режим с однослайдовым вызовом изображения выше, который его не поддерживает. После изменения размера проверьте вывод на наличие обрезанных заметок и расположения существующих объектов notes‑master; изменение только размеров страницы не гарантирует, что весь контент поместится. См. [Convert PowerPoint to PDF with Notes](/slides/ru/python-net/convert-powerpoint-to-pdf-with-notes/) для получения дополнительной информации об экспорте заметок.

### **Экспорт раздаточных листов в PDF**

Используйте [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/handoutlayoutingoptions/) для размещения нескольких миниатюр слайдов на одной странице. Далее пример задает страницу размером 900 × 600 точек и использует [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/handouttype/) для размещения до четырёх слайдов на страницу. Горизонтальная предустановка управляет порядком слайдов; ориентация страницы определяется её шириной и высотой.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Изменение размера страницы меняет область, доступную для сетки раздаточного листа, не меняя размеры исходных слайдов. Для изображений раздаточных листов используйте [Presentation.get_images](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/get_images/) с раздаточным макетом, а не метод получения изображения отдельного слайда. В Aspose.Slides рендеринг раздаточных листов на уровне презентации использует размеры страницы заметок, тогда как вызов получения изображения отдельного слайда не создаёт страницу раздаточного листа. См. [Handout Mode](/slides/ru/python-net/convert-powerpoint-in-handout-mode/) для вариантов макета.

## **Размер страницы в просмотрщиках, экспорте и печати**

Сохраните отдельными понятиями размер, сохранённый в презентации, размер экспортируемой страницы и размер печатной бумаги:

- **Просмотрщики презентаций:** Просмотрщик может отображать или печатать заметки, используя свои правила макета. Если другое приложение сохраняет файл, откройте его заново и проверьте размеры; конверсия формата в этом приложении может их нормализовать.
- **Форматы экспорта:** Приведённые выше примеры PDF заметок и раздаточных листов используют настроенные размеры страницы. Растровые изображения используют целочисленные размеры в пикселях и масштаб рендеринга, поэтому дробные значения точек могут быть округлены в выводе изображения. Экспорт обычных слайдов не применяет размер страницы заметок.
- **Драйверы принтера:** Выбор бумаги, автоматическое вращение и настройки «подгонки к странице» могут изменить физический вывод без изменения размеров, сохранённых в презентации или PDF. Для конкретного размера бумаги согласуйте настройки принтера и проверьте предварительный просмотр печати.

## **FAQ**

**Могу ли я задать размер заметок только для одного слайда?**

Размер страницы заметок задаётся на уровне презентации. Отдельные слайды могут иметь разный контент заметок, но это свойство не предоставляет отдельный размер страницы для каждого слайда.

**Почему изменение ориентации заметок не изменило мои слайды?**

Страницы заметок и обычные слайды имеют независимые размеры. Используйте настройки размера обычных слайдов, когда хотите изменить размеры самих слайдов.

**Почему мой сохранённый или печатный результат имеет другой размер?**

Сначала откройте сохранённую презентацию заново и сравните её размеры страниц заметок. Если они изменились, проверьте, изменило ли сохранение или конверсия файла в другом приложении настройки страницы. Если нет, проверьте макет экспорта, масштаб изображения, настройки просмотрщика и выбор бумаги принтера.