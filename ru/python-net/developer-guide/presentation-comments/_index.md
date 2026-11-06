---
title: Управление комментариями презентаций в Python
linktitle: Комментарии к презентации
type: docs
weight: 100
url: /ru/python-net/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии к презентации
- комментарии слайда
- добавить комментарий
- доступ к комментариям
- редактировать комментарий
- ответить на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Управляйте комментариями презентаций с помощью Aspose.Slides for Python via .NET: добавляйте, читайте, редактируйте, отвечайте и удаляйте комментарии в презентациях PowerPoint."
---
## **Обзор**

Эта статья объясняет, как управлять комментариями презентаций с помощью Aspose.Slides for Python via .NET. Она знакомит с основными типами, связанными с комментариями, и демонстрирует, как добавлять комментарии на слайды, получать доступ к существующим комментариям, работать с ответами и современными комментариями, а также удалять комментарии из презентации.

Примеры охватывают типичные сценарии рецензирования и совместной работы в PowerPoint, такие как назначение комментариев авторам, чтение текста комментария и метаданных, построение цепочек ответов и удаление выбранных комментариев или всех комментариев.

В PowerPoint комментарии отображаются как аннотации на слайдах. Выбор комментария показывает его текст и связанное обсуждение.

Чтобы запросить отображение или скрытие комментариев при открытии презентации без изменения самих комментариев, см. [Показать или скрыть комментарии при открытии презентации](/slides/ru/python-net/presentation-view-properties/).

## **Зачем добавлять комментарии в презентации?**

Вы можете использовать комментарии для предоставления обратной связи и совместной работы с коллегами при рассмотрении презентаций.

Aspose.Slides for Python via .NET предоставляет следующие API для работы с комментариями:

* Класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) предоставляет доступ к авторам комментариев презентации.
* Класс [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) представляет комментарии, связанные с отдельным автором.
* Класс [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) предоставляет информацию о комментарии, включая его автора, время создания, позицию и текст.
* Класс [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) предоставляет информацию об авторе, включая его имя, инициалы и связанные комментарии.

## **Добавить комментарии к слайдам**

Пример создает два слайда и регистрирует автора комментария с помощью [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). Он использует [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) для размещения одного комментария на каждом слайде, затем получает комментарии первого слайда для этого автора с помощью [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/). Консоль выводит текст первого комментария дважды, демонстрируя доступ как через слайд, так и через автора, а сохранённая презентация содержит оба комментария.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Найти или создать автора комментариев**

Когда автоматический обзор обрабатывает одну и ту же презентацию неоднократно, ищите в её коллекции [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) перед добавлением автора. [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) сравнивает и имя, и инициалы и возвращает массив совпадающих авторов или пустой массив, если совпадений нет. В отличие от этого, [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) ищет только по имени, независимо от инициалов. Вызов [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) с уже существующим в коллекции именем и инициалами бросает исключение.

Пример требует файл презентации хотя бы с одним слайдом. На каждом из двух проходов он переиспользует первого подходящего автора или создаёт нового только если результат пуст. Если найдено несколько совпадений, выбирается первый элемент массива без объединения или удаления остальных авторов. Затем вызывается [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) для выбранного автора и сохраняется презентация. На втором проходе открывается вывод первого прохода и операция повторяется.

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

Второй проход добавляет ещё один комментарий без создания нового автора или удаления существующих комментариев. Итоговый файл `review_pass_2.pptx` содержит оба новых комментария наряду с любыми оригинальными. Переиспользование автора не удаляет дубликаты комментариев: чтобы избежать многократного добавления одинакового комментария, реализуйте отдельное обнаружение дубликатов перед его добавлением.

## **Получить доступ к комментариям слайдов**

Пример открывает существующую презентацию и читает её коллекцию [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/). Для каждого автора он перебирает [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) и выводит номер слайда, текст комментария, имя автора и время создания. Входная презентация должна содержать комментарии, чтобы получить вывод в консоль.

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **Ответить на комментарии**

Родительский комментарий — это исходный комментарий в верхушке иерархии ответов. Свойство [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) класса [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) позволяет получать или задавать родительский комментарий.

Пример создаёт комментарии от двух авторов и использует [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) для построения ответов, включая ответ на другой ответ. Передача `None` в [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) возвращает комментарии от всех авторов; консоль отступает каждую запись в соответствии с её глубиной в иерархии ответов. Пример сохраняет полное обсуждение, вызывает [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) для первого корневого комментария и сохраняет вторую презентацию без этого комментария и его ответов.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* При использовании метода [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) класса [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) для удаления комментария удаляются также все ответы на этот комментарий.
* Если свойство [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) создаёт циклическую ссылку, бросается [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Добавить современные комментарии**

Современные комментарии могут быть связаны непосредственно со слайдом, с конкретной фигурой или с диапазоном текста внутри AutoShape. Метод [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) принимает аргумент [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) дополнительно к слайду и координатам маркера комментария.

Когда в качестве аргумента shape передаётся `None`, комментарий считается комментариям уровня слайда. Его маркер позиционируется по указанным координатам, но он не привязан к конкретной фигуре, поэтому [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) возвращает `None`. При передаче [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) комментарий привязывается к этой фигуре. Координаты по‑прежнему определяют позицию маркера комментария на слайде, а привязку к фигуре можно получить через [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/).

### **Привязать современный комментарий к фигуре**

Пример дважды вызывает [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/): один раз с `None` в качестве фигуры для комментария уровня слайда и один раз с прямоугольником в качестве привязки. Чтение [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) выводит `True` для проверки null у комментария уровня слайда и `Revenue title` для привязанного комментария. Оба комментария сохраняются в презентации.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Привязать комментарии к различным типам фигур**

Любой объект слайда, наследующий от [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), может использоваться в качестве привязки. Частыми примерами являются [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) и экземпляры [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) такие как диаграммы.

Пример использует [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) для привязки комментария к каждому из пяти типов фигур: AutoShape, picture frame, группа, соединитель и диаграмма. Изображение вставлено как встроенные данные, поэтому внешнее изображение не требуется. Каждый комментарий имеет собственную позицию маркера, и сохранённая презентация сохраняет все пять привязок к фигурам.

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Привязать комментарий к тексту и задать его статус**

Для современного комментария, связанного с [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), свойство [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) указывает начальную позицию выбранного текста в текстовом фрейме фигуры, а [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) задаёт длину выделения. Вместе эти свойства связывают комментарий с конкретным диапазоном текста внутри AutoShape.

Свойство [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) можно читать или изменять, задавая значение из перечисления [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — статус современного комментария не определён.
- `ACTIVE` — комментарий активен.
- `RESOLVED` — комментарий решён.
- `CLOSED` — комментарий закрыт.

Пример привязывает современный комментарий к словам «quarterly revenue» в тексте прямоугольника. Он вычисляет нулевой индекс [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) из текста и задаёт [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) равным количеству выбранных символов. После установки [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) в `RESOLVED` презентация сохраняется и повторно открывается. Все четыре проверки в консоли должны вывести `True`, подтверждая, что привязка к фигуре, диапазон текста и статус сохранились.

```python
from datetime import datetime

import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = slides.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **Просмотр существующих современных комментариев**

Пример требует существующую презентацию, содержащую современные комментарии, и выводит их текст, статус и детали привязки. Чтобы проанализировать их, проверяйте, являются ли комментарии экземплярами [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/), затем изучайте [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) и [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). `None` в поле shape указывает на комментарий уровня слайда. Для привязки к [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) свойства выбора текста определяют соответствующий диапазон в текстовом фрейме фигуры.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **Удалить комментарии**

Aspose.Slides for Python via .NET позволяет удалить все комментарии и их авторов из презентации или удалить выбранные комментарии, оставив остальные. Ниже приведены примеры обеих подходов с сохранением обновлённой презентации.

### **Удалить все комментарии и их авторов**

Пример открывает существующую презентацию и вызывает [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) для каждого автора, затем вызывает [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) для удаления самих авторов. Сохранённая презентация не содержит ни комментариев, ни их авторов. Используйте презентацию с комментариями, чтобы увидеть эффект удаления.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Удалить конкретные комментарии**

Пример создаёт два комментария на одном слайде и использует [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) для поиска комментариев каждого автора. Он собирает комментарии, у которых текст равен «comment 1», перед вызовом [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/), избегая изменения коллекции во время выбора. Сохранённая презентация оставляет только «comment 2».

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Поддерживает ли Aspose.Slides статус "решено" для современных комментариев?**

Да. Свойство [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) можно читать и задавать значением из перечисления [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/), включая `RESOLVED`. Статус сохраняется в презентации и может быть прочитан после повторного открытия файла.

**Поддерживаются ли вложенные обсуждения (цепочки ответов) и есть ли ограничение по глубине вложенности?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/), что позволяет создавать цепочки ответов. API не задаёт конкретного ограничения глубины вложенности.

**В какой системе координат задаётся позиция маркера комментария на слайде?**

Позиция маркера задаётся параметрами с плавающей точкой в системе координат слайда, что позволяет точно размещать его на слайде.