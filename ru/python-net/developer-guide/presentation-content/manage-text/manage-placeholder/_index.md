---
title: Управление заполнителями презентации в Python
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/python-net/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- заполнитель содержимого
- текст подсказки
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как просматривать и редактировать текстовые, графические, диаграммные и содержательные заполнители, а также понять наследование заполнителей с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Заполнитель — это объект, который резервирует место для определённого типа содержимого в шаблоне презентации. Общие примеры: заголовок, основной текст, изображение, диаграмма и универсальный заполнитель содержимого. В отличие от обычного объекта, заполнитель может наследовать своё положение, размеры, форматирование и другие параметры от слайда‑макета или слайда‑шаблона.

Aspose.Slides предоставляет информацию о заполнителе через свойство [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/). Свойство возвращает объект [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) или `None` для обычного объекта. Используйте [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) — чтобы определить, какой тип содержимого ожидается в заполнителе.

Класс объекта всё равно имеет значение после того, как вы узнали тип заполнителя:

- Пустой текстовый, изображений, диаграмм или общий заполнитель обычно представлен объектом [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
- Заполненный заполнитель изображения может быть представлен объектом [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
- Заполненный заполнитель диаграммы может быть представлен объектом [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/).
- Заполнитель содержимого может содержать несколько видов контента. Проверяйте как [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/), так и класс объекта во время выполнения, а не предполагаете, что каждый заполнитель — это [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) описывает роль заполнителя; он не гарантирует класс объекта во время выполнения. Всегда проверяйте тип перед доступом к членам, специфичным для текста, изображения, диаграммы, таблицы или медиа.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Слайд‑шаблон определяет переиспользуемые стили и, в некоторых случаях, заполняющие объекты уровня шаблона.
2. Слайд‑макет определяет расположение, используемое одним или несколькими обычными слайдами, и может наследоваться от шаблона.
3. Обычный слайд содержит заполнители для этого слайда и может наследоваться от своего макета.

Вызовите [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) — чтобы перейти на один уровень выше в этой иерархии. Заполнитель обычного слайда обычно возвращает заполнитель своего макета; заполнитель макета может вернуть заполнитель шаблона. Метод возвращает `None`, когда у объекта нет базового заполнителя.

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

Редактирование заполнителя на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Редактирование связанного макета или шаблона может повлиять на все слайды, которые всё ещё наследуют эту настройку. Обычный локальный объект не имеет базового заполнителя и не начинает наследовать лишь потому, что занимает те же координаты.

## **Удаление статуса заполнителя**

При адаптации шаблона используйте [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) — чтобы оставить существующий объект как обычный объект. Его свойство [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) становится `None`, но объект остаётся в коллекции слайда. В отличие от этого, [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) удаляет объект из этой коллекции.

В следующем примере требуется файл `template.pptx` с минимум одним слайдом и непустым текстовым заполнителем на первом слайде. Используйте заполнитель с форматированием, унаследованным от его макета или шаблона, чтобы увидеть эффект удаления этой связи. Пример проверяет, что тот же объект остаётся, снова вызывает метод для теперь уже обычного объекта и сохраняет результат.

{{% alert color="warning" title="Warning" %}}
Удаление статуса заполнителя не сохраняет автоматически унаследованные параметры внешнего вида. Ниже приведённый пример намеренно оставляет эти параметры без изменений, поэтому итоговый файл может выглядеть иначе. Объект, позиция и размеры которого полностью унаследованы, может после вызова иметь нулевые координаты и размеры и стать невидимым, хотя останется в коллекции.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # Вызов метода для обычного объекта не оказывает эффекта.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

Для соответствующего заполнителя все три проверки выводят `True`. Текст остаётся, но унаследованные позиция, размер, поворот, шрифт, выравнивание абзаца, отступы текстового кадра, вертикальное привязывание, параметры заливки и линии могут измениться после удаления связи заполнителя. Например, унаследованное форматирование заголовка может вернуться к обычному текстовому форматированию. Смотрите раздел [Slide Layout](/slides/ru/python-net/slide-layout/) для более подробной информации о макетах.

Чтобы сохранить требуемый вид, зафиксируйте разрешённые позицию, размер и поворот до вызова и скопируйте необходимые эффективные значения форматирования в отдельные переменные. Получить эти значения можно через [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), и [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/). Не полагайтесь лишь на объекты эффективного форматирования, потому что их значения текстового форматирования могут измениться после удаления связи. Явно примените зафиксированные значения к обычному объекту позже, включая семейство шрифта, размер, стиль, цвет, параметры абзаца, настройки текстового кадра, заливку и линию, используемые в вашем шаблоне.

Унаследованная геометрия объекта также может потребовать явного указания через [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/). Для прямоугольного текстового заполнителя это означает назначить [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/); восстановление только заливки и линии может не восстановить видимый прямоугольник. Шаблоны с дополнительными эффектами или более сложным форматированием требуют аналогичной обработки этих параметров.

## **Изменение текста в заполнителе**

Заголовок, центрированный заголовок, подзаголовок, основной текст и текстовые заполнители обычно поддерживают текст. Проверьте, является ли объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), прежде чем использовать его свойство [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/).

Этот пример обновляет первый заполнитель заголовка на первом слайде и сохраняет результат:

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

Такой подход исключает обработку заполнителей изображений, диаграмм, таблиц или медиа как объектов [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Он также идентифицирует заполнитель по назначению, а не полагается на хрупкий индекс объекта.

## **Установка подсказки текста на макете**

Подсказка текста — это инструкция, отображаемая в пустом заполнителе во время разработки, например *Click to add title*. Устанавливайте пользовательскую подсказку на заполнителе макета, а не пытаясь достать её через обычную коллекцию объектов слайда. Доступ к макету получайте через [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) и перебирайте [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/).

Следующий пример изменяет подсказки заголовка и подзаголовка на макете, используемом первым слайдом:

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

Подсказка текста — это не обычное содержимое слайда. Она предназначена для пустых заполнителей в редакторах, таких как PowerPoint. Как только пользователь или программа предоставляют реальное содержимое, подсказка перестаёт отображаться. Изменение подсказки также не заменяет существующий текст на слайдах, использующих данный макет.

## **Обновление заполнителя изображения**

Существует два варианта обработки:

- Если заполнитель изображения уже заполнен и представлен объектом [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), замените изображение через [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) и [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/).
- Если это всё ещё пустой заполнитель, добавьте кадр изображения в координаты заполнителя с помощью [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) и удалите пустой заполнитель.

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

Замена, созданная для пустого заполнителя, представляет собой локальный кадр изображения, а не новый заполнитель, поскольку [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) только для чтения. Он сохраняет зарезервированное положение, но больше не наследует поведение, специфичное для заполнителя. Если сохранение связи заполнителя критично, сначала подготовьте и заполните заполнитель в PowerPoint, а затем обновите полученный [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) с помощью Aspose.Slides.

Для прозрачности изображения, обрезки и других эффектов, специфичных для изображений, смотрите раздел [Manage Picture Frames](/slides/ru/python-net/picture-frame/). Эти операции относятся к кадру изображения или заливке изображения, а не к метаданным заполнителя.

## **Работа с заполнителями диаграмм и содержимого**

Заполненный заполнитель диаграммы может быть представлен объектом [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/). В этом примере диаграмма находится одновременно по типу заполнителя и по классу во время выполнения, её заголовок меняется, а файл сохраняется:

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

Общий заполнитель содержимого обычно имеет тип [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/). В PowerPoint он служит запускателем для нескольких типов содержимого, включая диаграммы, таблицы, схемы, изображения и медиа. После заполнения проверьте фактический класс объекта, чтобы узнать, что в нём находится. Специфические макеты могут также использовать [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), или [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/).

Aspose.Slides не преобразует пустой заполнитель [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) в [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) простой сменой [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/); тип только для чтения. Чтобы программно заполнить пустую область диаграммы или содержимого, добавьте требуемый объект в координаты заполнителя, а затем удалите пустой заполнитель. Следующий пример делает это для диаграммы:

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

Добавленная диаграмма — это обычная локальная диаграмма. Она занимает область заполнителя, но не наследует параметры от макета. Используйте специализированные статьи по управлению диаграммами ([chart management articles](/slides/ru/python-net/powerpoint-charts/)), когда требуется заменить категории, серии или данные из рабочей книги.

## **Полный пример: обновление текста или изображения**

Следующий сквозной пример открывает шаблон, ищет на первом слайде либо заполнитель заголовка, либо заполнитель изображения, проверяет типы заполнителя и объекта, обновляет соответствующее содержимое и сохраняет результат. Пример намеренно избегает предположений о индексе объекта и не рассматривает каждый заполнитель как объект одного и того же класса.

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

Базовый заполнитель — это соответствующий объект на макете или шаблоне, от которого другой заполнитель наследует параметры. Используйте [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) — чтобы получить его. Обычный локальный объект возвращает `None`, потому что не входит в иерархию заполнителей.

**Могу ли я изменить все заголовки слайдов, отредактировав заполнитель макета?**

Через макет можно изменить унаследованное форматирование или текст подсказки, но существующее содержимое заголовков хранится на обычных слайдах. Чтобы заменить реальный текст заголовков по всей презентации, пройдите по всем слайдам и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, колонтитула и нижнего колонтитула?**

Используйте менеджеры колонтитулов и нижних колонтитулов на уровне соответствующего слайда, макета, шаблона, заметок или раздаточного листа. См. раздел [Manage Presentation Header and Footer](/slides/ru/python-net/presentation-header-and-footer/) для полных примеров.