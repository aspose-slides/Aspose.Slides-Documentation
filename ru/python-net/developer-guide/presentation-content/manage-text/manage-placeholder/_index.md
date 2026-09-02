---
title: Управление заполнителями презентаций в Python
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/python-net/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- графический заполнитель
- заполнитель диаграммы
- контентный заполнитель
- подсказочный текст
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как просматривать и редактировать текстовые, графические, диаграммные и контентные заполнители, а также понять наследование заполнителей с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Заполнитель — это форма, резервирующая место для определённого типа содержимого в шаблоне презентации. Типичные примеры — заполнители заголовка, основного текста, изображения, диаграммы и заполнитель общего назначения. В отличие от обычной формы, заполнитель может наследовать своё положение, размер, форматирование и другие параметры от слайда‑раскладки или слайда‑шаблона.

Aspose.Slides предоставляет информацию о заполнителе через свойство [Shape.placeholder](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/placeholder/). Это свойство возвращает объект [Placeholder](https://reference.aspose.com/slides/ru/python-net/aspose.slides/placeholder/) или `None` для обычной формы. Используйте [Placeholder.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/placeholder/type/) для определения того, что предполагается помещать в заполнитель.

Класс формы всё равно важен после определения типа заполнителя:

- Пустой текстовый, графический, диаграммный или контентный заполнитель обычно представлен объектом [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/).
- Заполненный графический заполнитель может быть представлен объектом [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/).
- Заполненный диаграммный заполнитель может быть представлен объектом [Chart](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/).
- Контентный заполнитель может содержать несколько видов содержимого. Проверяйте как [Placeholder.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/placeholder/type/), так и класс формы во время выполнения, а не делайте предположение, что каждый заполнитель — это [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/placeholder/type/) описывает роль заполнителя; он не гарантирует класс формы во время выполнения. Всегда проверяйте тип перед обращением к членам, специфичным для текста, изображения, диаграммы, таблицы или мультимедиа.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Слайд‑шаблон определяет переиспользуемые стили и, в некоторых случаях, заполнители уровня шаблона.
2. Слайд‑раскладка определяет расположение, используемое одним или несколькими обычными слайдами, и может наследовать параметры от шаблона.
3. Обычный слайд содержит заполнители для данного слайда и может наследовать их от своей раскладки.

Вызовите [Shape.get_base_placeholder](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/get_base_placeholder/) для перехода на один уровень выше по этой иерархии. Заполнитель обычного слайда обычно возвращает свой заполнитель‑раскладку; заполнитель раскладки может вернуть заполнитель‑шаблон. Метод возвращает `None`, когда у формы нет базового заполнителя.

В следующем примере перечисляются заполнители первого слайда и выводятся их базовые заполнители:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Редактирование заполнителя на обычном слайде создаёт или меняет локальное переопределение для этого слайда. Изменение соответствующей раскладки или шаблона может повлиять на все слайды, которые всё ещё наследуют эту настройку. Обычная локальная форма не имеет базового заполнителя и не начинает наследовать его только потому, что занимает те же координаты.

## **Изменение текста в заполнитель**

Заполнители заголовка, центрированного заголовка, подзаголовка, основного текста и текста обычно поддерживают текст. Перед использованием свойства [text_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/text_frame/) проверяйте, что форма — это [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/).

В этом примере обновляется первый заполнитель заголовка на первом слайде и сохраняется результат:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Такой подход позволяет избежать обработки графических, диаграммных, табличных или мультимедийных заполнителей как объектов [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/). Он также идентифицирует заполнитель по назначению, а не полагается на хрупкий индекс формы.

## **Установка подсказочного текста в раскладке**

Подсказочный текст — это инструкция, отображаемая в пустом заполнителе во время разработки, например *Нажмите, чтобы добавить заголовок*. Устанавливайте собственный подсказочный текст в заполнитель раскладки, а не пытаясь достучаться до него через коллекцию форм обычного слайда. Доступ к раскладке осуществляется через [Slide.layout_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/layout_slide/) и перебор [LayoutSlide.shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslide/shapes/).

В следующем примере изменяются подсказки заголовка и подзаголовка в раскладке, используемой первым слайдом:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Подсказочный текст — это не обычное содержимое слайда. Он предназначен для пустых заполнителей в приложениях редактирования, таких как PowerPoint. Как только пользователь или программа задаёт реальное содержимое, подсказка больше не отображается. Изменение подсказки также не заменяет существующий текст на слайдах, использующих эту раскладку.

## **Обновление графического заполнителя**

Существует два случая:

- Если графический заполнитель уже заполнен и представлен объектом [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/), замените изображение через [PictureFillFormat.picture](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/picture/) и [Picture.image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picture/image/).
- Если это всё ещё пустой заполнитель, добавьте графический фрейм в координаты заполнителя с помощью [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_picture_frame/) и удалите пустой заполнитель.

Следующий пример поддерживает оба случая и сохраняет презентацию:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Созданная для пустого заполнителя замена — это локальный графический фрейм, а не новый заполнитель, потому что свойство [Shape.placeholder](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/placeholder/) только для чтения. Он сохраняет зарезервированное положение, но больше не наследует поведение, специфичное для заполнителя. Если сохранение отношения заполнителя критично, подготовьте и заполните заполнитель в PowerPoint сначала, а затем обновите полученный [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) с помощью Aspose.Slides.

Для управления прозрачностью изображения, кадрированием и другими эффектами, специфичными для графики, см. статью [Manage Picture Frames](/slides/ru/python-net/picture-frame/). Эти операции относятся к графическому фрейму или заливке, а не к метаданным заполнителя.

## **Работа с диаграммными и контентными заполнителями**

Заполненный диаграммный заполнитель может быть представлен объектом [Chart](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/). В этом примере найден такой график по типу заполнителя и классу во время выполнения, изменён его заголовок и сохранён файл:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Обычно контентный заполнитель имеет тип [PlaceholderType.OBJECT](https://reference.aspose.com/slides/ru/python-net/aspose.slides/placeholdertype/). В PowerPoint он выступает как «лаунчер» для нескольких типов содержимого, включая диаграммы, таблицы, схемы, изображения и мультимедиа. После заполнения проверьте фактический класс формы, чтобы узнать, что именно она содержит. Специальные раскладки могут также раскрывать типы [PlaceholderType.CHART](https://reference.aspose.com/slides/ru/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/ru/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/ru/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/ru/python-net/aspose.slides/placeholdertype/), или [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/ru/python-net/aspose.slides/placeholdertype/).

Aspose.Slides не преобразует пустой заполнитель [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) в [Chart](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/) просто изменением [Placeholder.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/placeholder/type/); тип только для чтения. Чтобы программно заполнить пустую диаграмму или область контента, добавьте требуемый объект в координаты заполнителя, а затем удалите пустой заполнитель. Следующий пример делает это для диаграммы:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

Добавленная диаграмма — это обычная локальная диаграмма. Она занимает область заполнителя, но не наследует свойства от заполнителя раскладки. Используйте отдельные статьи по управлению диаграммами [chart management articles](/slides/ru/python-net/powerpoint-charts/), когда нужно заменить категории, серии или данные книги.

## **Полный пример: обновление текста или изображения**

В следующем сквозном примере открывается шаблон, ищется первый слайд для заполняющего заголовка или графики, проверяются типы заполнителя и формы, обновляется соответствующее содержимое и сохраняется результат. Пример сознательно избегает предположений о индексе формы и о том, что каждый заполнитель — это один и тот же класс формы.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Что такое базовый заполнитель?**

Базовый заполнитель — это соответствующая форма в раскладке или шаблоне, от которой наследуется другой заполнитель. Используйте [Shape.get_base_placeholder](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/get_base_placeholder/) для получения его. Обычная локальная форма возвращает `None`, потому что она не входит в иерархию заполнителей.

**Можно ли изменить все заголовки слайдов, отредактировав заполнитель в раскладке?**

Можно изменить наследуемое форматирование или подсказочный текст через раскладку, но фактическое содержимое заголовков хранится в обычных слайдах. Чтобы заменить реальный текст заголовка во всей презентации, переберите слайды и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, верхнего и нижнего колонтитулов?**

Используйте менеджеры верхних и нижних колонтитулов в соответствующем слайде, раскладке, шаблоне, заметках или раздаче. См. статью [Manage Presentation Header and Footer](/slides/ru/python-net/presentation-header-and-footer/) для полных примеров.