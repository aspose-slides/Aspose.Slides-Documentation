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
- комментарии к презентации
- комментарии к слайду
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
description: "Управляйте комментариями презентаций с помощью Aspose.Slides для Python через Java: добавляйте, читайте, редактируйте, отвечайте и удаляйте комментарии в презентациях PowerPoint быстро и легко."
---
## **Обзор**

В этой статье объясняется, как управлять комментариями презентаций с помощью Aspose.Slides for Python via Java. Представлены основные типы, связанные с комментариями, и демонстрируется, как добавлять комментарии на слайды, получать доступ к существующим комментариям, работать с ответами и современными комментариями, а также удалять комментарии из презентации.

Примеры охватывают типичные сценарии рецензирования и совместной работы в PowerPoint, такие как присвоение комментариев авторам, чтение текста комментария и метаданных, построение цепочек ответов и удаление выбранных комментариев или всех комментариев.

В PowerPoint комментарии отображаются как аннотации на слайдах. Выбор комментария отображает его текст и связанную дискуссию.

Чтобы запросить отображение или скрытие комментариев при открытии презентации без изменения самих комментариев, см. [Показать или скрыть комментарии при открытии презентации](/slides/ru/python-java/presentation-view-properties/).

## **Зачем добавлять комментарии к презентациям?**

Вы можете использовать комментарии для предоставления обратной связи и совместной работы с коллегами при рецензировании презентаций.

Aspose.Slides for Python via Java предоставляет следующие API для работы с комментариями:

* Класс [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), который предоставляет доступ к авторам комментариев презентации.
* Класс [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/), представляющий комментарии, связанные с отдельным автором.
* Класс [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/), предоставляющий информацию о комментарии, включая его автора, время создания, позицию и текст.
* Класс [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/), предоставляющий информацию об авторе, включая его имя, инициалы и связанные комментарии.

## **Добавление комментариев на слайд**

Пример создает два слайда и регистрирует автора комментария с помощью [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor). Он использует [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) для размещения одного комментария на каждом слайде, затем получает комментарии первого слайда для этого автора через [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments). Консоль выводит текст первого комментария дважды, демонстрируя доступ как через слайд, так и через автора, а сохраненная презентация содержит оба комментария.

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

## **Поиск или создание автора комментария**

Когда автоматический обзор обрабатывает одну и ту же презентацию неоднократно, перед добавлением автора следует искать в коллекции, возвращаемой [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors). Метод [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) сопоставляет как имя, так и инициалы и возвращает массив соответствующих авторов или пустой массив, если совпадений нет. В отличие от него, [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) ищет только по имени, независимо от инициалов. Вызов [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) с именем и инициалами, уже присутствующими в коллекции, генерирует исключение.

Пример требует файл презентации как минимум с одним слайдом. На каждой из двух проходов он повторно использует первого найденного автора или создает нового только если результат пуст. Если найдено несколько соответствий, выбирается первый элемент массива без слияния или удаления остальных авторов. Затем вызывается [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) для выбранного автора и сохраняется презентация. Второй проход открывает вывод первого прохода и повторяет операцию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

Во втором проходе добавляется еще один комментарий без добавления нового автора и без удаления существующих комментариев. Финальный файл `review_pass_2.pptx` содержит оба новых комментария вместе с любыми оригинальными комментариями. Повторное использование автора не приводит к дедупликации комментариев: чтобы избежать многократного добавления одинакового комментария, реализуйте отдельное обнаружение дубликатов перед его добавлением.

## **Доступ к комментариям слайда**

Пример открывает существующую презентацию и читает коллекцию, возвращаемую [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors). Для каждого автора он перебирает коллекцию, возвращаемую [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments), и выводит номер слайда, текст комментария, имя автора и время создания. Входная презентация должна содержать комментарии, чтобы получить вывод в консоль.

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

## **Ответы на комментарии**

Родительский комментарий — это оригинальный комментарий в верхней части иерархии ответов. Методы [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) и [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) позволяют получить или установить родителя комментария.

Пример создает комментарии от двух авторов и использует [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) для построения ответов, включая ответ на другой ответ. Передача `None` в [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) получает комментарии от всех авторов; консоль отступает каждую запись в соответствии с её глубиной в иерархии ответов. Пример сохраняет полную дискуссию, вызывает [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) для первого корневого комментария и сохраняет вторую презентацию с этим комментарим и его ответами, удаленными.

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
* При использовании метода [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) для удаления комментария также удаляются все ответы на этот комментарий.
* Если [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) создает кольцевую ссылку, генерируется [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Добавление современных комментариев**

Современные комментарии могут быть связаны непосредственно со слайдом, с конкретной фигурой или с диапазоном текста внутри [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Метод [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) принимает аргумент [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) дополнительно к слайду и координатам маркера комментария.

Когда в качестве аргумента shape передается `None`, комментарий является комментариев уровня слайда. Его маркер позиционируется по заданным координатам, но не привязан к конкретной фигуре, поэтому [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) возвращает `None`. Когда передается [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/), комментарий привязывается к этой фигуре. Координаты по‑прежнему определяют позицию маркера комментария на слайде, а ассоциацию с фигурой можно получить через [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape).

### **Привязка современного комментария к фигуре**

Пример вызывает [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) дважды: один раз с фигурой `None` для комментария уровня слайда и один раз с прямоугольником в качестве привязки. Чтение [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) выводит `True` для проверки `None` у комментария уровня слайда и `Revenue title` для привязанного комментария. Оба комментария сохраняются вместе с презентацией.

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

### **Привязка комментариев к разным типам фигур**

Любой объект слайда, наследующий от [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/), может использоваться в качестве привязки фигурой. Распространённые примеры включают [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/) и [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) такие как диаграммы.

Пример использует [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) для связывания комментария с каждым из пяти типов фигур: AutoShape, рамкой изображения, группой, соединителем и диаграммой. Изображение встроено в данные, поэтому внешнее изображение не требуется. Каждый комментарий имеет собственную позицию маркера, и сохранённая презентация сохраняет все пять привязок фигур.

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

### **Привязка комментария к тексту и установка его статуса**

Для современного комментария, связанного с [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), методы [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) и [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) получают начальную позицию выбранного текста в текстовом кадре фигуры. Методы [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) и [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) получают длину выделения. Вместе эти значения связывают комментарий с конкретным диапазоном текста внутри AutoShape.

Методы [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) и [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) работают со значениями из констант [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — конкретный статус современного комментария не определён.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — комментарий активен.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — комментарий решён.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — комментарий закрыт.

Пример привязывает современный комментарий к словам «quarterly revenue» в тексте прямоугольника. Он вычисляет нулевой индекс начала выбора из текста и передаёт его в [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart), а затем использует [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) для указания количества выбранных символов. После вызова [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) с `Resolved` презентация сохраняется и повторно открывается. Четыре проверки в консоли должны вывести `True`, подтверждая, что привязка к фигуре, диапазон текста и статус сохранены.

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

### **Просмотр существующих современных комментариев**

Пример требует существующую презентацию, содержащую современные комментарии, и выводит их текст, статус и детали привязки. Чтобы проанализировать её, проверьте, какие комментарии являются экземплярами [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/), затем исследуйте [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) и [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus). `None` в качестве фигуры указывает на комментарий уровня слайда. Для привязки к [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) методы выбора текста определяют соответствующий диапазон в текстовом кадре фигуры.

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

## **Удаление комментариев**

Aspose.Slides for Python via Java позволяет удалить все комментарии и их авторов из презентации или удалить выбранные комментарии, оставив остальные. Ниже приведены примеры, демонстрирующие оба подхода, и сохраняющие обновлённую презентацию.

### **Удаление всех комментариев и их авторов**

Пример открывает существующую презентацию и вызывает [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) для каждого автора, затем вызывает [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) для удаления самих авторов. Сохранённая презентация не содержит ни комментариев, ни их авторов. Используйте презентацию с комментариями, чтобы увидеть удаление.

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

### **Удаление конкретных комментариев**

Пример создает два комментария на одном слайде и использует [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) для поиска комментариев каждого автора. Он собирает комментарии, у которых текст равен «comment 1», перед вызовом [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove), избегая изменений в коллекции во время выбора. Сохранённая презентация сохраняет только «comment 2».

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

**Поддерживает ли Aspose.Slides статус «решён» для современных комментариев?**

Да. Методы [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) и [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) работают со значением [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/), включая `Resolved`. Статус сохраняется в презентации и может быть прочитан после повторного открытия файла.

**Поддерживаются ли обсуждения в виде веток (цепочки ответов) и есть ли ограничение на вложенность?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment), позволяя создавать цепочки ответов. API не определяет конкретного ограничения глубины вложения.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция маркера задаётся координатами с плавающей запятой в системе координат слайда, что позволяет точно разместить его на слайде.