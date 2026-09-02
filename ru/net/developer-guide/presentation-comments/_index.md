---
title: Управление комментариями презентации в .NET
linktitle: Комментарии к презентации
type: docs
weight: 100
url: /ru/net/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии к презентации
- комментарии к слайдам
- добавить комментарий
- доступ к комментариям
- редактировать комментарий
- ответить на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте комментариями презентаций с помощью Aspose.Slides for .NET: добавляйте, читайте, редактируйте, отвечайте и удаляйте комментарии в PowerPoint‑презентациях быстро и легко."
---
## **Обзор**

Эта статья объясняет, как управлять комментариями презентаций с помощью Aspose.Slides for .NET. Она знакомит с основными типами, связанными с комментариями, и демонстрирует, как добавлять комментарии к слайдам, получать доступ к существующим комментариям, работать с ответами и современными комментариями, а также удалять комментарии из презентации.

Примеры охватывают типичные сценарии рецензирования и совместной работы в PowerPoint, такие как назначение комментариев авторам, чтение текста комментария и метаданных, построение цепочек ответов и удаление выбранных комментариев или всех комментариев.

В PowerPoint комментарии отображаются как аннотации на слайдах. Выбор комментария показывает его текст и связанное обсуждение.

## **Зачем добавлять комментарии к презентациям?**

Вы можете использовать комментарии для предоставления обратной связи и совместной работы с коллегами при рецензировании презентаций.

Aspose.Slides for .NET предоставляет следующие API для работы с комментариями:

* Класс [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation), который обеспечивает доступ к авторам комментариев презентации.
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/icommentcollection), представляющий комментарии, связанные с отдельным автором.
* Интерфейс [IComment](https://reference.aspose.com/slides/ru/net/aspose.slides/icomment), который предоставляет информацию о комментарии, включая автора, время создания, позицию и текст.
* Класс [CommentAuthor](https://reference.aspose.com/slides/ru/net/aspose.slides/commentauthor), который предоставляет информацию об авторе, включая его имя, инициалы и связанные комментарии.

## **Добавить комментарии к слайдам**
Следующий пример показывает, как добавить комментарии к слайдам в презентации PowerPoint:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");
var position = new PointF(0.2f, 0.2f);
var createdTime = DateTime.Now;

author.Comments.AddComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author.Comments.AddComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

var comments = firstSlide.GetSlideComments(author);
if (comments.Length > 0)
{
    var firstComment = comments[0];
    Console.WriteLine(firstComment.Text);

    var commentText = firstComment.Author.Comments[0].Text;
    Console.WriteLine(commentText);
}

presentation.Save("Comments_out.pptx", SaveFormat.Pptx);
```

## **Доступ к комментариям слайдов**
Следующий пример показывает, как получить доступ к существующим комментариям в презентации PowerPoint:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Comments1.pptx");

foreach (var author in presentation.CommentAuthors)
{
    foreach (var comment in author.Comments)
    {
        Console.WriteLine($"Slide: {comment.Slide.SlideNumber}");
        Console.WriteLine($"Comment: {comment.Text}");
        Console.WriteLine($"Author: {comment.Author.Name}");
        Console.WriteLine($"Posted at: {comment.CreatedTime}");
        Console.WriteLine();
    }
}
```

## **Ответы на комментарии**
Родительский комментарий — это исходный комментарий в верхней части иерархии ответов. Свойство [ParentComment](https://reference.aspose.com/slides/ru/net/aspose.slides/icomment/properties/parentcomment) интерфейса [IComment](https://reference.aspose.com/slides/ru/net/aspose.slides/icomment) позволяет получить или задать родителя комментария.

Следующий пример показывает, как добавить ответы и изучить получившуюся иерархию комментариев:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var comment1 = author1.Comments.AddComment("comment 1", slide, position, createdTime);

var author2 = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var reply1 = author2.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
reply1.ParentComment = comment1;

var reply2 = author2.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
reply2.ParentComment = comment1;

var subReply = author1.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = reply2;

author2.Comments.AddComment("comment 2", slide, position, createdTime);
var comment3 = author2.Comments.AddComment("comment 3", slide, position, createdTime);

var reply3 = author1.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
reply3.ParentComment = comment3;

var comments = slide.GetSlideComments(null);
for (var i = 0; i < comments.Length; i++)
{
    var comment = comments[i];
    while (comment.ParentComment != null)
    {
        Console.Write("\t");
        comment = comment.ParentComment;
    }

    Console.WriteLine($"{comments[i].Author.Name}: {comments[i].Text}");
}

presentation.Save("parent_comment.pptx", SaveFormat.Pptx);

comment1.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Внимание" %}} 

* При использовании метода [Remove](https://reference.aspose.com/slides/ru/net/aspose.slides/icomment/methods/remove) интерфейса [IComment](https://reference.aspose.com/slides/ru/net/aspose.slides/icomment) для удаления комментария удаляются также все ответы на этот комментарий.
* Если свойство [ParentComment](https://reference.aspose.com/slides/ru/net/aspose.slides/icomment/properties/parentcomment) создает кольцевую ссылку, выбрасывается исключение [PptxEditException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **Добавить современные комментарии**

Современные комментарии могут быть связаны с самим слайдом, с конкретной фигурой или с диапазоном текста внутри AutoShape. Метод [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/ru/net/aspose.slides/icommentcollection/addmoderncomment/) принимает аргумент [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/) в дополнение к слайду и координатам маркера комментария.

Когда в качестве аргумента shape передаётся `null`, комментарий считается комментариев уровня слайда. Его маркер позиционируется по указанным координатам, но не привязан к конкретной фигуре, поэтому [IModernComment.Shape](https://reference.aspose.com/slides/ru/net/aspose.slides/imoderncomment/shape/) возвращает `null`. Когда передаётся объект [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/), комментарий привязывается к этой фигуре. Координаты по‑прежнему определяют позицию маркера комментария на слайде, а привязку к фигуре можно получить через [IModernComment.Shape](https://reference.aspose.com/slides/ru/net/aspose.slides/imoderncomment/shape/).

### **Привязка современного комментария к фигуре**

Следующий пример создаёт как комментарий уровня слайда, так и современный комментарий, привязанный к конкретному AutoShape. Затем он считывает связанную фигуру из каждого комментария.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
shape.Name = "Revenue title";
shape.TextFrame.Text = "Quarterly revenue";

var createdTime = DateTime.Now;
var slideCommentPosition = new PointF(20, 20);
var shapeCommentPosition = new PointF(60, 60);
var slideComment = author.Comments.AddModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
var shapeComment = author.Comments.AddModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console.WriteLine(slideComment.Shape == null);
Console.WriteLine(shapeComment.Shape?.Name);

presentation.Save("modern_comments.pptx", SaveFormat.Pptx);
```

### **Привязка комментариев к различным типам фигур**

Любой объект слайда, реализующий [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/), может использоваться в качестве привязки к фигуре. Распространённые примеры включают [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/ru/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/ru/net/aspose.slides/iconnector/) и экземпляры [IGraphicalObject](https://reference.aspose.com/slides/ru/net/aspose.slides/igraphicalobject/) такие как диаграммы.

Следующий пример создаёт несколько общих типов фигур и связывает с каждой из них современный комментарий.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var createdTime = DateTime.Now;

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
autoShape.TextFrame.Text = "AutoShape";
var autoShapeCommentPosition = new PointF(30, 30);
author.Comments.AddModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

var imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
var imageData = Convert.FromBase64String(imageBase64);
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
var pictureCommentPosition = new PointF(230, 30);
author.Comments.AddModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

var groupShape = slide.Shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
var groupCommentPosition = new PointF(40, 150);
author.Comments.AddModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
var connectorCommentPosition = new PointF(240, 150);
author.Comments.AddModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
var chartCommentPosition = new PointF(420, 40);
author.Comments.AddModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation.Save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
```

### **Привязка комментария к тексту и установка его статуса**

Для современного комментария, связанного с [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/), свойство [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/ru/net/aspose.slides/imoderncomment/textselectionstart/) указывает начальную позицию выбранного текста во фрейме текста фигуры, а [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/ru/net/aspose.slides/imoderncomment/textselectionlength/) определяет длину выбора. Вместе эти свойства связывают комментарий с определённым диапазоном текста внутри AutoShape.

Свойство [IModernComment.Status](https://reference.aspose.com/slides/ru/net/aspose.slides/imoderncomment/status/) можно читать или изменять, задавая значение из перечисления [ModernCommentStatus](https://reference.aspose.com/slides/ru/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — конкретный статус современного комментария не определён.
- `Active` — комментарий активен.
- `Resolved` — комментарий отмечен как решённый.
- `Closed` — комментарий закрыт.

Следующий пример создаёт современный комментарий, привязанный к фигуре, связывает его с выбором текста, помечает как решённый, сохраняет презентацию и проверяет значения после повторного открытия файла.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputFile = "modern_comment_text_anchor.pptx";
const string shapeText = "Review the quarterly revenue forecast.";
const string selectedText = "quarterly revenue";
var expectedSelectionStart = shapeText.IndexOf(selectedText, StringComparison.Ordinal);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.Name = "Forecast text";
shape.TextFrame.Text = shapeText;

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var commentPosition = new PointF(60, 60);
var comment = author.Comments.AddModernComment("Verify this forecast wording.", slide, shape, commentPosition, DateTime.Now);
comment.TextSelectionStart = expectedSelectionStart;
comment.TextSelectionLength = selectedText.Length;
comment.Status = ModernCommentStatus.Resolved;

presentation.Save(outputFile, SaveFormat.Pptx);

using var reopenedPresentation = new Presentation(outputFile);
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedComments = reopenedSlide.GetSlideComments(null);

foreach (var reopenedComment in reopenedComments)
{
    if (reopenedComment is not IModernComment modernComment)
    {
        continue;
    }

    var shapeMatches = modernComment.Shape?.Name == "Forecast text";
    var selectionStartMatches = modernComment.TextSelectionStart == expectedSelectionStart;
    var selectionLengthMatches = modernComment.TextSelectionLength == selectedText.Length;
    var statusMatches = modernComment.Status == ModernCommentStatus.Resolved;

    Console.WriteLine($"Shape anchor preserved: {shapeMatches}");
    Console.WriteLine($"Text selection start preserved: {selectionStartMatches}");
    Console.WriteLine($"Text selection length preserved: {selectionLengthMatches}");
    Console.WriteLine($"Resolved status preserved: {statusMatches}");
}
```

### **Проверка существующих современных комментариев**

Чтобы изучить существующую презентацию, проверьте, какие комментарии реализуют [IModernComment](https://reference.aspose.com/slides/ru/net/aspose.slides/imoderncomment/), затем рассмотрите [IModernComment.Shape](https://reference.aspose.com/slides/ru/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/ru/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/ru/net/aspose.slides/imoderncomment/textselectionlength/) и [IModernComment.Status](https://reference.aspose.com/slides/ru/net/aspose.slides/imoderncomment/status/). `null` для фигуры указывает на комментарий уровня слайда. Для привязки к [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) свойства выбора текста определяют соответствующий диапазон во фрейме текста фигуры.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("comments.pptx");

foreach (var slide in presentation.Slides)
{
    var comments = slide.GetSlideComments(null);
    foreach (var comment in comments)
    {
        if (comment is not IModernComment modernComment)
        {
            continue;
        }

        Console.WriteLine($"Slide: {slide.SlideNumber}");
        Console.WriteLine($"Text: {modernComment.Text}");
        Console.WriteLine($"Status: {modernComment.Status}");

        var shape = modernComment.Shape;
        if (shape == null)
        {
            Console.WriteLine("Anchor: slide level");
        }
        else
        {
            Console.WriteLine($"Anchor shape: {shape.Name}");
            Console.WriteLine($"Anchor type: {shape.GetType().Name}");

            if (shape is IAutoShape)
            {
                Console.WriteLine($"Text selection start: {modernComment.TextSelectionStart}");
                Console.WriteLine($"Text selection length: {modernComment.TextSelectionLength}");
            }
        }

        Console.WriteLine();
    }
}
```

## **Удаление комментариев**

### **Удалить все комментарии и авторов комментариев**

Следующий пример показывает, как удалить все комментарии и их авторов из презентации:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("example.pptx");

foreach (var author in presentation.CommentAuthors)
{
    author.Comments.Clear();
}

presentation.CommentAuthors.Clear();
presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

### **Удалить конкретные комментарии**

Следующий пример показывает, как удалить определённые комментарии со слайда:

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Author", "A");
var createdTime = DateTime.Now;

var firstCommentPosition = new PointF(0.2f, 0.2f);
var secondCommentPosition = new PointF(0.3f, 0.2f);
author.Comments.AddComment("comment 1", slide, firstCommentPosition, createdTime);
author.Comments.AddComment("comment 2", slide, secondCommentPosition, createdTime);

foreach (var commentAuthor in presentation.CommentAuthors)
{
    var commentsToRemove = new List<IComment>();
    var comments = slide.GetSlideComments(commentAuthor);

    foreach (var comment in comments)
    {
        if (comment.Text == "comment 1")
        {
            commentsToRemove.Add(comment);
        }
    }

    foreach (var comment in commentsToRemove)
    {
        commentAuthor.Comments.Remove(comment);
    }
}

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Часто задаваемые вопросы**

**Поддерживает ли Aspose.Slides статус «Resolved» для современных комментариев?**

Да. Свойство [IModernComment.Status](https://reference.aspose.com/slides/ru/net/aspose.slides/imoderncomment/status/) можно читать и задавать значение перечисления [ModernCommentStatus](https://reference.aspose.com/slides/ru/net/aspose.slides/moderncommentstatus/), включая `Resolved`. Статус сохраняется в презентации и может быть прочитан после повторного открытия файла.

**Поддерживаются ли тематические обсуждения (цепочки ответов) и есть ли ограничение на их вложенность?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/ru/net/aspose.slides/comment/parentcomment/), что позволяет создавать цепочки ответов. API не определяет конкретного ограничения глубины вложения.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция маркера задаётся координатами с плавающей точкой в системе координат слайда, что позволяет точно размещать его на слайде.