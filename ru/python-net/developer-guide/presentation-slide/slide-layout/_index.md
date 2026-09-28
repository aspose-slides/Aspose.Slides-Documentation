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
- титульный слайд
- заголовок и содержимое
- заголовок раздела
- два блока содержимого
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

Макет слайда определяет позиции и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета обеспечивает слайдам согласованную структуру, одновременно позволяя каждому слайду содержать свой собственный контент.

Наиболее часто используемые макеты включают:

- **Title Slide**: Содержит заполнители заголовка и подзаголовка.
- **Title and Content**: Содержит заполнитель заголовка и универсальный заполнитель контента.
- **Blank**: Не содержит заполнителей контента и полезен, когда каждая форма будет позиционироваться вручную.

## **Понимание наследования макетов**

Презентация имеет три связанных уровня:

1. A [master slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslide/) определяет тему, общие форматирования, фон и общие объекты.
1. A [layout slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/) принадлежит мастеру и определяет определённую расстановку заполнителей.
1. A [normal slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/) использует один макет и сохраняет введённый для него контент.

Normal slide наследует тему и форматирование от своего макета, а макет наследуется от своего мастера. Значение, установленное непосредственно на normal slide, переопределяет унаследованное значение на этом уровне. При создании normal slide его формы‑заполнители генерируются из выбранного макета, тогда как контент, введённый в эти заполнители, принадлежит normal slide.

Добавьте требуемые заполнители в макет до создания слайдов из него. Добавление другого заполнителя в макет позже не добавляет автоматически соответствующую форму‑заполнитель в существующие normal slides.

У этой зависимости есть два важных следствия:

- Изменение унаследованного форматирования или геометрии существующего заполнителя в макете может обновить каждый слайд, зависящий от него. Перед редактированием макета, уже используемого, проверьте его зависимые слайды и просмотрите получившуюся презентацию.
- Макет, который всё ещё используется слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет или удалите только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии смотрите [Slide Master](/slides/ru/python-net/slide-master/).

Чтобы скрыть унаследованные логотипы или декоративные элементы мастера на одном слайде или через общий макет, смотрите [Control the Visibility of Master Graphics](/slides/ru/python-net/slide-master/). Пример сравнивает два слайда, использующие один и тот же мастер.

## **Выбор и применение макета слайда**

Используйте тип макета, когда презентация следует стандартным определениям макетов PowerPoint. Имена макетов редактируются пользователем и могут быть локализованы, поэтому выбор по имени менее надёжен, если вы не контролируете исходный шаблон.

Следующий пример ищет **Title and Content** в первом мастере. Если этот макет недоступен, он намеренно переключается на **Blank**. Второй проверка на null необходима, потому что презентация может содержать только пользовательские макеты. Выбранный макет затем применяется к первому normal slide через свойство [Slide.layout_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/layout_slide/).

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

Изменение макета слайда не удаляет обычные формы, добавленные непосредственно на слайд. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно разными макетами.

## **Добавление макета слайда**

Выбор и создание – отдельные операции. Предыдущий пример выбирает существующий макет; он не создаёт новый. Чтобы создать макет, вызовите метод [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterlayoutslidecollection/add/) у коллекции макетов целевого мастера.

Следующий пример всегда добавляет новый макет **Title and Content** с именем `Report Title and Content`, затем добавляет normal slide на его основе. Имена макетов должны быть уникальны в пределах коллекции.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Добавляйте макет только тогда, когда шаблон действительно нуждается в новой переиспользуемой структуре. Если подходящий макет уже существует, выберите и используйте его вместо создания дубликата.

## **Добавление заполнителей в макет слайда**

Свойство [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/placeholder_manager/) предоставляет [LayoutPlaceholderManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/) для добавления форм‑заполнителей в макет.

| Заполнитель PowerPoint | Метод `LayoutPlaceholderManager` |
| ---------------------- | --------------------------------- |
| ![Содержание](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Содержание (вертикальное)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Текст](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Текст (вертикальный)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Изображение](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Диаграмма](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Таблица](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Медиа](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Онлайн‑изображение](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Следующий пример проверяет, существует ли макет **Blank**, добавляет к нему четыре заполнителя и затем создаёт normal slide, использующий изменённый макет. Порядок намеренный: заполнители добавляются до создания normal slide, чтобы Aspose.Slides мог сгенерировать соответствующие формы‑заполнители на этом слайде.

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

![Заполнители на макете слайда](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей макета может влиять на зависимые слайды. Ново‑добавленный заполнитель макета не заполняет автоматически существующие normal slides. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетов слайдов**

Используйте метод [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) для удаления макетов, на которые не ссылаются normal slides. Метод оставляет макеты, всё ещё используемые, без изменений.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Чтобы удалить конкретный макет, сначала используйте его свойство [has_depending_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/has_depending_slides/) или метод [get_depending_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/get_depending_slides/). Переназначьте любые зависимые слайды перед вызовом [LayoutSlide.remove](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/remove/). Попытка удалить используемый макет вызывает [PptxEditException](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pptxeditexception/).

## **Управление видимостью нижнего колонтитула на макете слайда**

У макета есть свои собственные заполнители нижнего колонтитула, номера слайда и даты‑времени. Используйте свойство [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/header_footer_manager/) для управления этими заполнителями в одном макете. Это полезно, когда, например, макеты содержимого должны показывать нижний колонтитул, а макеты заголовков – нет.

Следующий пример безопасно выбирает макет и делает его элементы нижнего колонтитула видимыми:

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

## **Управление видимостью нижнего колонтитула на мастере и его дочерних макетах**

Чтобы применить согласованные настройки нижнего колонтитула по всей иерархии мастера, используйте свойство [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslide/header_footer_manager/). Методы распространения [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslideheaderfootermanager/) работают с мастером и его зависимыми макетами и normal slides; они не направлены только на один normal slide.

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

## **Часто задаваемые вопросы**

**В чем разница между master slide и layout slide?**

Master slide определяет тему презентации и общее форматирование. Layout slide принадлежит мастеру и задаёт одну переиспользуемую расстановку заполнителей. Normal slides используют эти макеты и хранят контент, специфичный для конкретного слайда.

**Могу ли я скопировать layout slide из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/globallayoutslidecollection/add_clone/). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходным макетом.

**Что происходит, когда я изменяю макет, который уже используется?**

Зависимые слайды наследуют изменения макета, если только они не переопределили затронутое форматирование или объекты локально. Геометрия заполнителей и унаследованные стили могут измениться сразу на многих слайдах. Используйте [get_depending_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/get_depending_slides/) для определения затронутых слайдов перед редактированием макета.

**Что происходит, если я удаляю макет, который всё ещё используется?**

Aspose.Slides вызывает [PptxEditException](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [remove_unused_layout_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) для удаления только не ссылочных макетов.