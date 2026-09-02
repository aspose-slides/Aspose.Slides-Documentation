---
title: Применение или изменение макетов слайдов в Python
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
- заглавный слайд
- заголовок и содержимое
- заголовок раздела
- два содержания
- сравнение
- только заголовок
- пустой макет
- содержимое с подписью
- изображение с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Применяйте, создавайте и изменяйте макеты слайдов в Aspose.Slides для Python через .NET, добавляйте заполнители, удаляйте неиспользуемые макеты и управляйте видимостью нижнего колонтитула."
---
## **Обзор**

Схема слайда определяет позиции и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение схемы обеспечивает единообразную структуру слайдов, позволяя каждому слайду содержать собственное содержание.

Наиболее распространённые схемы включают:

- **Title Slide**: Содержит заполнители заголовка и подзаголовка.
- **Title and Content**: Содержит заполнитель заголовка и универсальный заполнитель содержимого.
- **Blank**: Не содержит заполнителей содержимого и полезен, когда каждую фигуру позиционируют вручную.

## **Понимание наследования схем**

Презентация имеет три связанных уровня:

1. A [Главный слайд](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslide/) определяет тему, общие форматирования, фон и общие объекты.
1. A [Схема слайда](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/) принадлежит главному слайду и определяет конкретное расположение заполнителей.
1. A [Обычный слайд](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/) использует одну схему и хранит содержимое, введённое для этого слайда.

Обычный слайд наследует тему и форматирование от своей схемы, а схема наследует их от главного слайда. Значение, установленное непосредственно на обычном слайде, переопределяет унаследованное значение на этом уровне. При создании обычного слайда его фигуры‑заполнители генерируются из выбранной схемы, тогда как содержимое, введённое в эти заполнители, принадлежит обычному слайду.

Добавьте необходимые заполнители в схему до создания из неё слайдов. Добавление другого заполнителя в схему позже не добавит автоматически соответствующую фигуру‑заполнитель в существующие обычные слайды.

У этой связи два важных последствия:

- Изменение унаследованного форматирования или геометрии существующего заполнителя в схеме может обновить каждый слайд, зависящий от неё. Перед редактированием схемы, уже используемой, проверьте её зависимые слайды и просмотрите получившуюся презентацию.
- Схему, которая всё ещё используется слайдом, нельзя удалить. Сначала переназначьте её зависимые слайды на другую схему или удалите только неиспользуемые схемы.

Для получения дополнительной информации о верхнем уровне этой иерархии см. [Слайд‑мастер](/slides/ru/python-net/slide-master/).

## **Выбор и применение схемы слайда**

Используйте тип схемы, когда презентация следует стандартным определениям схем PowerPoint. Имена схем редактируемы пользователем и могут быть локализованы, поэтому выбор по имени менее надёжен, если вы не контролируете исходный шаблон.

Следующий пример ищет **Title and Content** на первом главном слайде. Если эта схема недоступна, он преднамеренно переключается на **Blank**. Второй проверочный null необходим, потому что презентация может содержать только пользовательские схемы. Затем выбранная схема применяется к первому обычному слайду через свойство [Slide.layout_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/layout_slide/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Изменение схемы слайда не удаляет обычные фигуры, добавленные напрямую на слайд. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новой схемой могут измениться, поэтому проверяйте результат при переключении между существенно разными схемами.

## **Добавление схемы слайда**

Выбор и создание — отдельные операции. Предыдущий пример выбирает существующую схему; он её не создаёт. Чтобы создать схему, вызовите метод [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterlayoutslidecollection/add/) в коллекции схем целевого главного слайда.

Следующий пример всегда добавляет новую схему **Title and Content** с именем `Report Title and Content`, затем добавляет обычный слайд на её основе. Имена схем должны быть уникальными в пределах коллекции.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Добавляйте схему только тогда, когда шаблон действительно нуждается в ещё одной переиспользуемой структуре. Если подходящая схема уже существует, выберите и повторно используйте её вместо создания дубликата.

## **Добавление заполнителей в схему слайда**

Свойство [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/placeholder_manager/) предоставляет [LayoutPlaceholderManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/) для добавления фигур‑заполнителей в схему.

| Заполнитель PowerPoint | `LayoutPlaceholderManager` Method |
| ---------------------- | --------------------------------- |
| ![Содержание](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Содержание (Вертикальное)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Текст](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Текст (Вертикальное)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Изображение](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Диаграмма](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Таблица](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Медиа](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Онлайн‑изображение](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Следующий пример проверяет наличие схемы **Blank**, добавляет к ней четыре заполнителя, а затем создаёт обычный слайд, использующий изменённую схему. Порядок намеренный: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides мог сгенерировать соответствующие фигуры‑заполнители на этом слайде.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Заполнители на схеме слайда](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей схемы может затронуть зависимые слайды. Новый заполнитель схемы не добавляется автоматически в существующие обычные слайды. Тестируйте изменения схемы на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых схем слайдов**

Используйте метод [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) для удаления схем, на которые не ссылается ни один обычный слайд. Метод оставляет нетронутыми схемы, которые всё ещё используются.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Чтобы удалить конкретную схему, сначала используйте её свойство [has_depending_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/has_depending_slides/) или метод [get_depending_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/get_depending_slides/). Переназначьте все зависимые слайды до вызова [LayoutSlide.remove](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/remove/). Попытка удалить используемую схему вызывает [PptxEditException](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pptxeditexception/).

## **Управление отображением нижнего колонтитула в схеме слайда**

У схемы есть собственные заполнители нижнего колонтитула, номера слайда и даты/времени. Используйте свойство [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/header_footer_manager/) для управления этими заполнителями в одной схеме. Это полезно, когда, например, схемы содержимого должны показывать нижний колонтитул, а схемы заголовков — нет.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление отображением нижнего колонтитула в мастере и его дочерних схемах**

Чтобы применить одинаковые настройки нижних колонтитулов по всей иерархии мастера, используйте свойство [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslide/header_footer_manager/). Методы распространения [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslideheaderfootermanager/) работают на мастере и его зависимых схемах и обычных слайдах; они не направлены только на один обычный слайд.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**В чём разница между главным слайдом и схемой слайда?**

Главный слайд определяет тему презентации и общее форматирование. Схема слайда принадлежит главному слайду и задаёт один переиспользуемый набор размещения заполнителей. Обычные слайды используют эти схемы и хранят содержание, специфичное для каждого слайда.

**Можно ли скопировать схему слайда из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/globallayoutslidecollection/add_clone/). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходной схемой.

**Что происходит, когда я изменяю схему, которая уже используется?**

Зависимые слайды наследуют изменения схемы, если они не переопределили затронутое форматирование или объекты локально. Геометрия заполнителей и унаследованные стили могут измениться сразу на множестве слайдов. Используйте [get_depending_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/get_depending_slides/) для определения затронутых слайдов перед редактированием схемы.

**Что происходит, если я удаляю схему, которая всё ещё используется?**

Aspose.Slides генерирует [PptxEditException](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [remove_unused_layout_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) для удаления только неиспользуемых схем.