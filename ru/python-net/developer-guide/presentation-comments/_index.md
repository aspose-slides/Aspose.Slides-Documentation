---
title: Управление комментариями презентации в Python
linktitle: Комментарии к презентации
type: docs
weight: 100
url: /ru/python-net/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии презентации
- комментарии слайдов
- добавить комментарий
- получить комментарий
- редактировать комментарий
- ответ на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Управляйте комментариями презентаций с помощью Aspose.Slides для Python через .NET: добавляйте, читаете, редактируете, отвечайте и удаляйте комментарии в презентациях PowerPoint."
---
## **Обзор**

В этой статье объясняется, как управлять комментариями презентации с помощью Aspose.Slides для Python через .NET. Она вводит основные типы, связанные с комментариями, и демонстрирует, как добавлять комментарии к слайдам, получать доступ к существующим комментариям, работать с ответами и современными комментариями, а также удалять комментарии из презентации.

Примеры охватывают типичные сценарии рецензирования и совместной работы в PowerPoint, такие как назначение комментариев авторам, чтение текста комментария и метаданных, построение цепочек ответов и удаление выбранных комментариев или всех комментариев.

В PowerPoint комментарии отображаются как аннотации на слайдах. Выбор комментария отображает его текст и связанную дискуссию.

Чтобы запросить отображение или скрытие комментариев при открытии презентации без изменения самих комментариев, см. [Показать или скрыть комментарии при открытии презентации](/slides/ru/python-net/presentation-view-properties/).

## **Зачем добавлять комментарии к презентациям?**

Вы можете использовать комментарии для предоставления обратной связи и совместной работы с коллегами при рецензировании презентаций.

Aspose.Slides для Python через .NET предоставляет следующие API для работы с комментариями:

* Класс [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) предоставляет доступ к авторам комментариев презентации.
* Класс [CommentCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/commentcollection/) представляет комментарии, связанные с отдельным автором.
* Класс [Comment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/comment/) предоставляет информацию о комментарии, включая его автора, время создания, позицию и текст.
* Класс [CommentAuthor](https://reference.aspose.com/slides/ru/python-net/aspose.slides/commentauthor/) предоставляет информацию об авторе, включая его имя, инициалы и связанные комментарии.

## **Добавление комментариев к слайдам**

В следующем примере показано, как добавить комментарии к слайдам в презентации PowerPoint:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
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

## **Доступ к комментариям слайдов**

В следующем примере показано, как получить доступ к существующим комментариям в презентации PowerPoint:

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

## **Ответ на комментарии**

Родительский комментарий — это оригинальный комментарий в вершине иерархии ответов. Свойство [parent_comment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/comment/parent_comment/) класса [Comment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/comment/) позволяет получить или задать родительский комментарий.

В следующем примере показано, как добавить ответы и изучить получившуюся иерархию комментариев:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* При использовании метода [remove](https://reference.aspose.com/slides/ru/python-net/aspose.slides/comment/remove/) класса [Comment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/comment/) для удаления комментария также удаляются все ответы на этот комментарий.
* Если свойство [parent_comment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/comment/parent_comment/) создает круговую ссылку, будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Добавить современные комментарии**

Современные комментарии могут быть привязаны к самому слайду, к конкретной форме или к диапазону текста внутри AutoShape. Метод [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/commentcollection/add_modern_comment/) принимает аргумент [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/) в дополнение к слайду и координатам маркера комментария.

Когда в аргумент shape передаётся `None`, комментарий считается уровнем слайда. Его маркер позиционируется по указанным координатам, но не привязан к какой‑то форме, поэтому [ModernComment.shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncomment/shape/) возвращает `None`. Если передана [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/), комментарий привязывается к этой форме. Координаты по‑прежнему определяют положение маркера комментария на слайде, а привязку к форме можно получить через [ModernComment.shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncomment/shape/).

### **Закрепить современный комментарий за формой**

В следующем примере создаются как комментарий уровня слайда, так и современный комментарий, привязанный к конкретному AutoShape. Затем из каждого комментария считывается связанная форма.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Привязать комментарии к разным типам форм**

Любой объект слайда, производный от [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/), может использоваться в качестве привязки формы. Распространённые примеры включают [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/ru/python-net/aspose.slides/connector/) и экземпляры [GraphicalObject](https://reference.aspose.com/slides/ru/python-net/aspose.slides/graphicalobject/), такие как диаграммы.

В следующем примере создаются несколько распространённых типов форм и к каждому из них привязывается современный комментарий.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Привязать комментарий к тексту и установить его статус**

Для современного комментария, связанного с [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/), свойство [ModernComment.text_selection_start](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncomment/text_selection_start/) указывает стартовую позицию выбранного текста во фрейме текста формы, а свойство [ModernComment.text_selection_length](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncomment/text_selection_length/) задаёт длину выделения. Вместе эти свойства связывают комментарий с конкретным диапазоном текста внутри AutoShape.

Свойство [ModernComment.status](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncomment/status/) можно читать или изменять, задавая значение из перечисления [ModernCommentStatus](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — не определён конкретный статус современного комментария.
- `ACTIVE` — комментарий активен.
- `RESOLVED` — комментарий решён.
- `CLOSED` — комментарий закрыт.

В следующем примере создаётся современный комментарий, привязанный к форме, связывается с выделением текста, отмечается как решённый, сохраняется презентация и проверяются значения после повторного открытия файла.

```python
from datetime import datetime

import aspose.pydrawing as draw
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
    comment_position = draw.PointF(60, 60)
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

### **Проверить существующие современные комментарии**

Чтобы проанализировать существующую презентацию, определите, какие комментарии являются экземплярами [ModernComment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncomment/), затем изучите [ModernComment.shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncomment/text_selection_length/) и [ModernComment.status](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncomment/status/). `None` в свойстве shape указывает на комментарий уровня слайда. Для привязки к [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) свойства выбора текста определяют соответствующий диапазон во фрейме текста формы.

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

### **Удалить все комментарии и авторов комментариев**

В следующем примере показано, как удалить все комментарии и авторов комментариев из презентации:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Удалить конкретные комментарии**

В следующем примере показано, как удалить конкретные комментарии со слайда:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
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

## **Часто задаваемые вопросы**

**Поддерживает ли Aspose.Slides статус "решено" для современных комментариев?**

Да. Свойство [ModernComment.status](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncomment/status/) можно читать и задавать значение из перечисления [ModernCommentStatus](https://reference.aspose.com/slides/ru/python-net/aspose.slides/moderncommentstatus/), включая `RESOLVED`. Статус сохраняется в презентации и может быть считан повторно после повторного открытия файла.

**Поддерживаются ли вложенные обсуждения (цепочки ответов) и существует ли ограничение на глубину вложенности?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/comment/parent_comment/), что позволяет формировать цепочки ответов. API не задаёт конкретного ограничения на глубину вложенности.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция маркера определяется координатами с плавающей точкой в системе координат слайда, что позволяет точно разместить его на слайде.