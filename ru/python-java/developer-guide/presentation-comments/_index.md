---
title: Управление комментариями презентаций в Python через Java
linktitle: Комментарии к презентации
type: docs
weight: 100
url: /ru/python-java/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии презентации
- комментарии слайдов
- добавить комментарий
- доступ к комментариям
- редактировать комментарий
- ответить на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Управляйте комментариями презентаций с помощью Aspose.Slides for Python via Java: добавляйте, просматривайте, редактируйте, отвечайте и удаляйте комментарии в презентациях PowerPoint быстро и легко."
---
## **Обзор**

Эта статья объясняет, как управлять комментариями презентации с помощью Aspose.Slides for Python via Java. В ней рассматриваются основные типы, связанные с комментариями, и демонстрируется, как добавлять комментарии к слайдам, получать доступ к существующим комментариям, работать с ответами и современными комментариями, а также удалять комментарии из презентации.

Примеры охватывают типичные сценарии рецензирования и совместной работы в PowerPoint, такие как назначение комментариев авторам, чтение текста комментариев и метаданных, построение цепочек ответов и удаление выбранных комментариев или всех комментариев.

В PowerPoint комментарии отображаются как аннотации на слайдах. Выбор комментария показывает его текст и связанную дискуссию.

## **Зачем добавлять комментарии в презентации?**

Вы можете использовать комментарии для предоставления обратной связи и совместной работы с коллегами при проверке презентаций.

Aspose.Slides for Python via Java предоставляет следующие API для работы с комментариями:

* Класс [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) предоставляет доступ к авторам комментариев презентации.
* Класс [CommentCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/commentcollection/) представляет комментарии, связанные с отдельным автором.
* Класс [Comment](https://reference.aspose.com/slides/ru/python-java/aspose.slides/comment/) содержит информацию о комментарии, включая автора, время создания, позицию и текст.
* Класс [CommentAuthor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/commentauthor/) предоставляет информацию об авторе, включая его имя, инициалы и связанные комментарии.

## **Добавление комментариев к слайдам**

Следующий пример показывает, как добавить комментарии к слайдам в презентации PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))
    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Получение комментариев слайдов**

Следующий пример показывает, как получить доступ к существующим комментариям в презентации PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **Ответить на комментарии**

Родительский комментарий — это исходный комментарий в вершине иерархии ответов. Методы [Comment.getParentComment](https://reference.aspose.com/slides/ru/python-java/aspose.slides/comment/#getParentComment) и [Comment.setParentComment](https://reference.aspose.com/slides/ru/python-java/aspose.slides/comment/#setParentComment) позволяют получить или задать родительский комментарий.

Следующий пример показывает, как добавить ответы и исследовать получившуюся иерархию комментариев:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* При использовании метода [Comment.remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/comment/#remove) для удаления комментария также удаляются все ответы на этот комментарий.
* Если [Comment.setParentComment](https://reference.aspose.com/slides/ru/python-java/aspose.slides/comment/#setParentComment) создаёт круговую ссылку, генерируется исключение [PptxEditException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Добавление современных комментариев**

Современные комментарии могут быть связаны непосредственно со слайдом, с конкретной фигурой или с диапазоном текста внутри [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/). Метод [CommentCollection.addModernComment](https://reference.aspose.com/slides/ru/python-java/aspose.slides/commentcollection/#addModernComment) принимает аргумент [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/) в дополнение к слайду и координатам маркера комментария.

Если в качестве аргумента shape передаётся `None`, комментарий считается комментариев уровня слайда. Его маркер позиционируется согласно указанным координатам, но не привязан к какой‑либо фигуре, поэтому [ModernComment.getShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#getShape) возвращает `None`. Когда передаётся объект [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/), комментарий привязывается к этой фигуре. Координаты всё равно определяют положение маркера комментария на слайде, а связь с фигурой можно получить через [ModernComment.getShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#getShape).

### **Закрепить современный комментарий к фигуре**

Следующий пример создаёт как комментарий уровня слайда, так и современный комментарий, привязанный к конкретному [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/). Затем он считывает связанную фигуру из каждого комментария.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Закрепить комментарии к различным типам фигур**

Любой объект слайда, наследующийся от [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/), может использоваться в качестве привязки к фигуре. Распространённые примеры включают [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/ru/python-java/aspose.slides/connector/) и объекты [GraphicalObject](https://reference.aspose.com/slides/ru/python-java/aspose.slides/graphicalobject/), такие как диаграммы.

Следующий пример создаёт несколько распространённых типов фигур и связывает с каждой из них современный комментарий.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")
    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Закрепить комментарий к тексту и установить его статус**

Для современного комментария, связанного с [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/), методы [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#getTextSelectionStart) и [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#setTextSelectionStart) получают начальную позицию выбранного текста во фрейме текста фигуры. Методы [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#getTextSelectionLength) и [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#setTextSelectionLength) получают длину выделения. Совместно эти значения связывают комментарий с конкретным диапазоном текста внутри AutoShape.

Методы [ModernComment.getStatus](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#getStatus) и [ModernComment.setStatus](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#setStatus) получают значение из констант [ModernCommentStatus](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncommentstatus/#NotDefined) — конкретный статус современного комментария не определён.
- [Active](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncommentstatus/#Active) — комментарий активен.
- [Resolved](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncommentstatus/#Resolved) — комментарий разрешён.
- [Closed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncommentstatus/#Closed) — комментарий закрыт.

Следующий пример создаёт современный комментарий, привязанный к фигуре, связывает его с выделением текста, помечает как разрешённый, сохраняет презентацию и проверяет значения после повторного открытия файла.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **Проверка существующих современных комментариев**

Чтобы проанализировать существующую презентацию, определите, какие комментарии являются экземплярами [ModernComment](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/), затем изучите [ModernComment.getShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#getTextSelectionLength) и [ModernComment.getStatus](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#getStatus). Фигура `None` указывает на комментарий уровня слайда. Для привязки к [AutoShape] методы работы с выделением текста определяют соответствующий диапазон во фрейме текста фигуры.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **Удалить комментарии**

### **Удалить все комментарии и их авторов**

Следующий пример показывает, как удалить все комментарии и их авторов из презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Удалить конкретные комментарии**

Следующий пример показывает, как удалить конкретные комментарии со слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Поддерживает ли Aspose.Slides статус «разрешено» для современных комментариев?**

Да. Методы [ModernComment.getStatus](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#getStatus) и [ModernComment.setStatus](https://reference.aspose.com/slides/ru/python-java/aspose.slides/moderncomment/#setStatus) работают со значением из [ModernCommentStatus], включая `Resolved`. Статус сохраняется в презентации и может быть прочитан после повторного открытия файла.

**Поддерживаются ли вложенные обсуждения (цепочки ответов) и есть ли ограничение по глубине вложенности?**

Да. Каждый комментарий может ссылаться на свой [родительский комментарий](https://reference.aspose.com/slides/ru/python-java/aspose.slides/comment/#getParentComment), что позволяет создавать цепочки ответов. API не задаёт конкретного ограничения глубины вложения.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция маркера задаётся координатами с плавающей точкой в системе координат слайда, что позволяет точно разместить его на слайде.