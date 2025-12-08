---
title: Применить или изменить макеты слайдов в Python
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
- два содержимых
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
description: "Узнайте, как управлять и настраивать макеты слайдов в Aspose.Slides for Python через .NET. Изучите типы макетов, управление заполнителями, видимость нижних колонтитулов и манипулирование макетами с помощью примеров кода на Python."
---

## **Обзор**

Макет слайда определяет расположение полей‑заменителей и форматирование содержимого на слайде. Он управляет тем, какие заменители доступны и где они находятся. Макеты слайдов помогают быстро и последовательно создавать презентации — независимо от того, создаёте ли вы что‑то простое или более сложное. Некоторые из самых распространённых макетов слайдов в PowerPoint включают:

**Title Slide layout** – Включает два текстовых заменителя: один для заголовка и один для подзаголовка.

**Title and Content layout** – Содержит меньшее поле‑заменитель заголовка вверху и большее под ним для основного содержимого (например, текста, маркированных пунктов, диаграмм, изображений и прочего).

**Blank layout** – Не содержит заменителей, предоставляя полный контроль над созданием слайда с нуля.

Макеты слайдов являются частью главного слайда, который является верхнеуровневым слайдом и определяет стили макетов для презентации. Вы можете получить доступ к макетам слайдов и изменять их через главный слайд — либо по типу, имени, либо по уникальному идентификатору. Кроме того, можно редактировать конкретный макет слайда непосредственно в презентации.

Для работы с макетами слайдов в Aspose.Slides for Python вы можете использовать:

- Свойства, такие как [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) и [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) в классе [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
- Типы, такие как [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/) и [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Чтобы узнать больше о работе с главными слайдами, ознакомьтесь со статьёй [Manage PowerPoint Slide Masters in Python](/slides/ru/python-net/slide-master/).
{{% /alert %}}

## **Добавление макетов слайдов в презентации**

Для настройки внешнего вида и структуры ваших слайдов может потребоваться добавить новые макеты слайдов в презентацию. Aspose.Slides for Python позволяет проверить, существует ли уже конкретный макет, добавить новый при необходимости и использовать его для вставки слайдов на основе этого макета.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите доступ к [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/).
1. Проверьте, существует ли желаемый макет слайда в коллекции. Если нет, добавьте нужный макет слайда.
1. Добавьте пустой слайд на основе нового макета слайда.
1. Сохраните презентацию.

Следующий код Python демонстрирует, как добавить макет слайда в презентацию PowerPoint:
```python
import aspose.slides as slides

# Создать экземпляр класса Presentation для открытия файла презентации.
with slides.Presentation("sample.pptx") as presentation:
    # Пройти типы макетов слайдов, чтобы выбрать макет слайда.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Ситуация, когда презентация не содержит всех типов макетов.
        # Файл презентации содержит только макеты Blank и Custom.
        # Однако макеты с пользовательскими типами могут иметь узнаваемые имена,
        # такие как "Title", "Title and Content" и т.д., которые могут использоваться для выбора макета слайда.
        # Вы также можете опираться на набор типов фигур-заполнителей.
        # Например, титульный слайд должен содержать только тип заполнителя Title и т.д.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Добавить пустой слайд, используя добавленный макет слайда.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Сохранить презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Удаление неиспользуемых макетов слайдов**

Aspose.Slides предоставляет метод [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) из класса [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) для удаления нежелательных и неиспользуемых макетов слайдов.

Следующий код Python показывает, как удалить макет слайда из презентации PowerPoint:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Добавление заменителей в макеты слайдов**

Aspose.Slides предоставляет свойство [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/placeholder_manager/), которое позволяет добавлять новые заменители в макет слайда.

Этот менеджер содержит методы для следующих типов заменителей:

| PowerPoint Placeholder | Метод [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/) |
| ---------------------- | -------------------------------------------------------------------------------------------------------------------------------- |
| ![Содержание](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Содержание (вертикальное)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Текст](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Текст (вертикальный)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Изображение](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Диаграмма](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Таблица](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Медиа](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Онлайн‑изображение](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

Следующий код Python демонстрирует, как добавить новые фигуры‑заменители к макету «Blank»:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Получить пустой макет слайда.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Получить менеджер заполнителей макета слайда.
    placeholder_manager = layout.placeholder_manager

    # Добавить различные заполнители к пустому макету слайда.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Добавить новый слайд с пустым макетом.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![Заполнители на макете слайда](add_placeholders.png)

## **Установка видимости нижнего колонтитула для макета слайда**

В презентациях PowerPoint элементы нижнего колонтитула, такие как дата, номер слайда и пользовательский текст, могут отображаться или скрываться в зависимости от макета слайда. Aspose.Slides for Python позволяет управлять видимостью этих заменителей нижнего колонтитула. Это полезно, когда требуется, чтобы некоторые макеты отображали информацию нижнего колонтитула, а другие оставались чистыми и минимальными.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на макет слайда по его индексу.
1. Установите видимость заменителя нижнего колонтитула слайда.
1. Установите видимость заменителя номера слайда.
1. Установите видимость заменителя даты‑времени.
1. Сохраните презентацию.

Следующий код Python показывает, как установить видимость нижнего колонтитула слайда и выполнить связанные действия:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```


## **Установка видимости нижнего колонтитула для дочерних слайдов**

В презентациях PowerPoint элементы нижнего колонтитула, такие как дата, номер слайда и пользовательский текст, могут управляться на уровне главного слайда для обеспечения согласованности во всех макетах слайдов. Aspose.Slides for Python позволяет задавать видимость и содержимое этих заменителей нижнего колонтитула на главном слайде и распространять эти настройки на все дочерние макеты слайдов. Такой подход обеспечивает единообразную информацию нижнего колонтитула по всей презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на главный слайд по его индексу.
1. Установите видимость всех дочерних заменителей нижнего колонтитула вместе с главным.
1. Установите видимость всех дочерних заменителей номера слайда вместе с главным.
1. Установите видимость всех дочерних заменителей даты‑времени вместе с главным.
1. Сохраните презентацию.

Следующий код Python демонстрирует эту операцию:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**В чём разница между главным слайдом и макетом слайда?**

Главный слайд определяет общую тему и форматирование по умолчанию, тогда как макеты слайдов задают конкретные расстановки заменителей для разных типов содержимого.

**Могу ли я скопировать макет слайда из одной презентации в другую?**

Да, вы можете клонировать макет слайда из коллекции [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) одной презентации и вставить его в другую с помощью метода `add_clone`.

**Что происходит, если я удалю макет слайда, который всё ещё используется каким‑то слайдом?**

Если попытаться удалить макет слайда, который всё ещё referenced хотя бы одним слайдом в презентации, Aspose.Slides выдаст [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/). Чтобы избежать этого, используйте [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/), который безопасно удаляет только неиспользуемые макеты слайдов.