---
title: Применяйте или изменяйте макеты слайдов в Python
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/python-net/slide-layout/
keywords:
- макет слайда
- макет содержимого
- заполнитель
- дизайн презентации
- дизайн слайда
- неиспользуемый макет
- видимость нижнего колонтитула
- титульный слайд
- заголовок и содержимое
- заголовок раздела
- два объекта содержимого
- сравнение
- только заголовок
- пустой макет
- содержимое с подписью
- изображение с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Узнайте, как управлять и настраивать макеты слайдов в Aspose.Slides for Python via .NET. Изучите типы макетов, управление заполнителями, видимость нижнего колонтитула и манипулирование макетами на основе примеров кода на Python."
---

Макет слайда содержит заполнители и информацию о форматировании для всего содержимого, которое появляется на слайде. Макет определяет доступные заполнители содержимого и их расположение.

Макеты слайдов позволяют быстро создавать и оформлять презентации (будь они простыми или сложными). Вот некоторые из самых популярных макетов слайдов, используемых в презентациях PowerPoint:

* **Макет слайда с заголовком**. Этот макет состоит из двух текстовых заполнителей. Один заполнитель предназначен для заголовка, другой — для подзаголовка.
* **Макет заголовка и содержимого**. Этот макет содержит относительно небольшой заполнитель вверху для заголовка и более крупный заполнитель для основного содержимого (график, абзацы, маркированный или нумерованный список, изображения и т. д.).
* **Пустой макет**. Этот макет не содержит заполнителей, поэтому позволяет создавать элементы с нуля.

Так как мастер-слайд является верхним иерархическим слайдом, который хранит информацию о макетах слайдов, вы можете использовать мастер-слайд для доступа к макетам слайдов и внесения в них изменений. Макет слайда можно получить по типу или имени. Так же каждый слайд имеет уникальный идентификатор, который можно использовать для доступа к нему.

Также вы можете вносить изменения непосредственно в конкретный макет слайда в презентации.

* Чтобы позволить вам работать с макетами слайдов (включая те, что в мастер-слайдах), Aspose.Slides предоставляет такие свойства, как `layout_slides` и `masters` в классе [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
* Для выполнения связанных задач Aspose.Slides предоставляет [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/baseslideheaderfootermanager/) и многие другие типы.

{{% alert title="Информация" color="info" %}}

Для получения дополнительной информации о работе с мастер-слайдами в частности, смотрите статью [Мастер-слайд](https://docs.aspose.com/slides/python-net/slide-master/).

{{% /alert %}}

## **Добавить макет слайда в презентацию**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите доступ к [коллекции MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterlayoutslidecollection/).
1. Просмотрите существующие макеты слайдов, чтобы подтвердить, что необходимый макет слайда уже существует в коллекции макетов слайдов. В противном случае добавьте желаемый макет слайда.
1. Добавьте пустой слайд на основе нового макета слайда.
1. Сохраните презентацию.

Этот код на Python показывает, как добавить макет слайда в презентацию PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создает экземпляр класса Presentation, который представляет файл презентации
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Обходит типы макетов слайдов
    layoutSlides = presentation.masters[0].layout_slides
    layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)  
    if layoutSlide is None:
         layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE)

    if layoutSlide is None:
        # Ситуация, когда презентация не содержит некоторые типы макета.
        # Файл презентации содержит только пустые и нестандартные типы макетов.
        # Но макеты слайдов с нестандартными типами имеют разные имена слайдов,
        # такие как "Заголовок", "Заголовок и содержимое" и т. д. И эти
        # названия могут быть использованы для выбора макета слайда.
        # Вы также можете использовать набор типов форм заполнителей. Например,
        # макет слайда заголовка должен содержать только тип заполнителя заголовка и т. д.
        for titleAndObjectLayoutSlide in layoutSlides:
            if titleAndObjectLayoutSlide.name == "Заголовок и объект":
                layoutSlide = titleAndObjectLayoutSlide
                break

        if layoutSlide is None:
            for titleLayoutSlide in layoutSlides:
                if titleLayoutSlide.name == "Заголовок":
                    layoutSlide = titleLayoutSlide
                    break

            if layoutSlide is None:
                layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.BLANK)
                if layoutSlide is None:
                    layoutSlide = layoutSlides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Заголовок и объект")

    # Добавляет пустой слайд с добавленным макетом слайда
    presentation.slides.insert_empty_slide(0, layoutSlide)

    # Сохраняет презентацию на диск
    presentation.save("AddLayoutSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Удалить неиспользуемый макет слайда**

Aspose.Slides предоставляет метод `remove_unused_layout_slides` из класса [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/), который позволяет удалять нежелательные и неиспользуемые макеты слайдов. Этот код на Python показывает, как удалить макет слайда из презентации PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить размер и тип макета слайда**

Чтобы вы могли установить размер и тип для конкретного макета слайда, Aspose.Slides предоставляет свойства `type` и `size` (из класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)). Этот код на Python демонстрирует операцию:

```python
import aspose.slides as slides

# Создает экземпляр объекта Presentation, который представляет файл презентации 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # Устанавливает размер слайда для созданной презентации в соответствии с исходным
        auxPresentation.slide_size.set_size(presentation.slide_size.type, slides.SlideSizeScaleType.ENSURE_FIT)

        auxPresentation.slides.insert_clone(0, slide)
        auxPresentation.slides.remove_at(0)
        # Сохраняет презентацию на диск
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установите видимость нижнего колонтитула внутри слайда**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Установите заполнитель нижнего колонтитула слайда как видимый. 
1. Установите заполнитель даты и времени как видимый. 
1. Сохраните презентацию. 

Этот код на Python показывает, как установить видимость для нижнего колонтитула слайда (и выполнять связанные задачи):

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    headerFooterManager = presentation.slides[0].header_footer_manager
    # Свойство is_footer_visible используется для указания, что заполнитель нижнего колонтитула слайда отсутствует
    if not headerFooterManager.is_footer_visible: 
        # Метод set_footer_visibility используется для установки видимости заполняющего нижнего колонтитула слайда
        headerFooterManager.set_footer_visibility(True) 
        # Свойство is_slide_number_visible используется для указания, что заполнитель номера страницы слайда отсутствует
    if not headerFooterManager.is_slide_number_visible:  
        # Метод set_slide_number_visibility используется для установки видимости заполнителя номера страницы слайда
        headerFooterManager.set_slide_number_visibility(True) 
        # Свойство is_date_time_visible используется для указания, что заполнитель даты и времени слайда отсутствует
    if not headerFooterManager.is_date_time_visible: 
        # Метод set_date_time_visibility используется для установки видимости заполнителя даты и времени слайда 
        headerFooterManager.set_date_time_visibility(True)

    # Метод set_footer_text используется для установки текста для заполнителя нижнего колонтитула слайда 
    headerFooterManager.set_footer_text("Текст нижнего колонтитула") 
    # Метод set_date_time_text используется для установки текста для заполнителя даты и времени на слайде.
    headerFooterManager.set_date_time_text("Текст даты и времени") 

    # Сохраняет презентацию на диск
    presentation.save("Presentation.ppt", slides.export.SaveFormat.PPT)
```

## **Установите видимость нижнего колонтитула внутри слайда**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на мастер-слайд через его индекс. 
1. Установите видимость нижнего колонтитула мастер-слайда и всех нижних колонтитулов. 
1. Установите текст для мастер-слайда и всех нижних колонтитулов. 
1. Установите текст для мастер-слайда и всех заполнителей даты и времени. 
1. Сохраните презентацию. 

Этот код на Python демонстрирует операцию:

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    manager = presentation.masters[0].header_footer_manager
    manager.set_footer_and_child_footers_visibility(True) # Метод set_footer_and_child_footers_visibility используется для установки видимости нижнего колонтитула мастер-слайда и всех нижних колонтитулов
    manager.set_slide_number_and_child_slide_numbers_visibility(True) # Метод set_slide_number_and_child_slide_numbers_visibility используется для установки видимости номера страницы мастер-слайда и всех нижних номеров страниц
    manager.set_date_time_and_child_date_times_visibility(True) # Метод set_date_time_and_child_date_times_visibility используется для установки видимости дат и времени мастер-слайда и всех нижних заполнителей дат и времени

    manager.set_footer_and_child_footers_text("Текст нижнего колонтитула") # Метод set_footer_and_child_footers_text используется для установки текста для мастер-слайда и всех нижних колонтитулов
    manager.set_date_time_and_child_date_times_text("Текст даты и времени") # Метод set_date_time_and_child_date_times_text используется для установки текста для мастер-слайда и всех заполнителей даты и времени
```

## **Установите размер слайда с учетом масштабирования содержимого**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую слайд, размер которого вы хотите установить. 
1. Создайте другой экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для создания новой презентации. 
1. Получите ссылку на слайд (из первой презентации) через его индекс.
1. Установите заполнитель нижнего колонтитула как видимый. 
1. Установите заполнитель даты и времени как видимый. 
1. Сохраните презентацию. 

Этот код на Python демонстрирует операцию: 

```python
import aspose.slides as slides

# Создает экземпляр объекта Presentation, который представляет файл презентации 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # Устанавливает размер слайда для созданной презентации в соответствии с исходным
        presentation.slide_size.set_size(540, 720, slides.SlideSizeScaleType.ENSURE_FIT) # Метод set_size используется для установки размера слайда с масштабированием содержимого для обеспечения соответствия
        presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.MAXIMIZE) # Метод set_size используется для установки размера слайда с максимальным размером содержимого
                
        # Сохраняет презентацию на диск
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить размер страницы при генерации PDF**

Некоторые презентации (например, постеры) часто преобразуются в PDF документы. Если вы хотите преобразовать свою PowerPoint в PDF, чтобы получить наилучшие параметры печати и доступности, вы хотите установить свои слайды на размеры, подходящие для PDF документов (например, A4).

Aspose.Slides предоставляет класс [SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/), чтобы позволить вам указать предпочитаемые настройки для слайдов. Этот код на Python показывает, как использовать свойство `type` (из класса `SlideSize`), чтобы установить конкретный размер бумаги для слайдов в презентации:

```python
import aspose.slides as slides

# Создает экземпляр объекта Presentation, который представляет файл презентации  
with slides.Presentation() as presentation:
    # Устанавливает свойство SlideSize.Type 
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.ENSURE_FIT)

    # Устанавливает различные параметры для опций PDF
    opts = slides.export.PdfOptions()
    opts.sufficient_resolution = 600

    # Сохраняет презентацию на диск
    presentation.save("SetPDFPageSize_out.pdf", slides.export.SaveFormat.PDF, opts)
```