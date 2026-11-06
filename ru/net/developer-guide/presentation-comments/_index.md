---
title: Управление комментариями презентации в .NET
linktitle: Комментарии к презентации
type: docs
weight: 100
url: /ru/net/presentation-comments/
keywords:
- комментарий
- современный комментарий
- Комментарии PowerPoint
- Комментарии презентации
- Комментарии слайдов
- добавить комментарий
- доступ к комментарию
- редактировать комментарий
- ответить на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте комментариями презентаций с помощью Aspose.Slides для .NET: быстро и легко добавляйте, читаете, редактируете, отвечаете и удаляете комментарии в презентациях PowerPoint."
---
## **Обзор**

В этой статье объясняется, как управлять комментариями презентации с помощью Aspose.Slides для .NET. Она вводит основные типы, связанные с комментариями, и демонстрирует, как добавлять комментарии на слайды, получать доступ к существующим комментариям, работать с ответами и современными комментариями, а также удалять комментарии из презентации.

Примеры охватывают типичные сценарии рецензирования и совместной работы в PowerPoint, такие как назначение комментариев авторам, чтение текста комментариев и метаданных, построение цепочек ответов и удаление выбранных комментариев или всех комментариев.

В PowerPoint комментарии отображаются как аннотации на слайдах. При выборе комментария отображаются его текст и связанная дискуссия.

Для того чтобы запросить отображение или скрытие комментариев при открытии презентации без изменения самих комментариев, см. [Показать или скрыть комментарии при открытии презентации](/slides/ru/net/presentation-view-properties/).

## **Зачем добавлять комментарии в презентации?**

Вы можете использовать комментарии для предоставления обратной связи и совместной работы с коллегами при рецензировании презентаций.

Aspose.Slides для .NET предоставляет следующие API для работы с комментариями:

* The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) класс, который предоставляет доступ к авторам комментариев презентации.
* The [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) интерфейс, который представляет комментарии, связанные с отдельным автором.
* The [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) интерфейс, который предоставляет информацию о комментарии, включая его автора, время создания, позицию и текст.
* The [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) класс, который предоставляет информацию об авторе, включая его имя, инициалы и связанные комментарии.

## **Добавление комментариев к слайдам**

Пример создает два слайда и регистрирует автора комментариев с помощью [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Он использует [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) чтобы разместить один комментарий на каждом слайде, затем получает комментарии первого слайда для этого автора с помощью [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). Консоль выводит текст первого комментария дважды, демонстрируя доступ как через слайд, так и через автора, а сохраненная презентация содержит оба комментария.

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

## **Найти или создать автора комментариев**

Когда автоматический обзор многократно обрабатывает одну и ту же презентацию, перед добавлением автора следует искать в её коллекции [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) сопоставляет и имя, и инициалы и возвращает массив соответствующих авторов, либо пустой массив, если совпадений нет. В отличие от этого, [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) ищет только по имени, независимо от инициалов. Вызов [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) с именем и инициалами, уже присутствующими в коллекции, генерирует исключение.

Пример требует файл презентации минимум с одним слайдом. На каждом из двух проходов он переиспользует первого совпадающего автора или создает нового лишь когда результат пустой. Если найдено несколько совпадений, выбирается первый элемент массива без объединения или удаления остальных авторов. Затем вызывается [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) для выбранного автора и сохраняется презентация. На втором проходе открывается вывод первого прохода и операция повторяется.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string authorName = "Reviewer";
const string authorInitials = "RV";

var inputFile = "input.pptx";
var position = new PointF(20, 20);

for (var pass = 1; pass <= 2; pass++)
{
    using var presentation = new Presentation(inputFile);

    var matches = presentation.CommentAuthors.FindByNameAndInitials(authorName, authorInitials);
    
    var author = matches.Length > 0 ? matches[0] : presentation.CommentAuthors.AddAuthor(authorName, authorInitials);
    author.Comments.AddComment("Please review this slide.", presentation.Slides[0], position, DateTime.Now);

    var outputFile = $"review_pass_{pass}.pptx";
    presentation.Save(outputFile, SaveFormat.Pptx);
    inputFile = outputFile;
}
```

Второй проход добавляет еще один комментарий без создания нового автора и без удаления существующих комментариев. Финальный файл, `review_pass_2.pptx`, содержит оба новых комментария вместе с любыми оригинальными комментариями. Повторное использование автора не объединяет дубликаты комментариев: чтобы избежать многократного добавления одного и того же комментария, реализуйте отдельное обнаружение дубликатов перед добавлением его.

## **Доступ к комментариям слайдов**

Пример открывает существующую презентацию и читает её коллекцию [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). Для каждого автора он проходит через [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) и выводит номер слайда, текст комментария, имя автора и время создания. Входная презентация должна содержать комментарии, чтобы получить вывод в консоль.

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

Основным (родительским) комментарием считается исходный комментарий в вершине иерархии ответов. Свойство [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) интерфейса [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) позволяет получить или задать родительский комментарий.

Пример создает комментарии от двух авторов и использует [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) для построения ответов, включая ответ на другой ответ. Передача `null` в [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) получает комментарии от всех авторов; консоль отступает каждую запись в соответствии с её глубиной в иерархии ответов. Пример сохраняет полную дискуссию, вызывая [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) для первого корневого комментария, и сохраняет вторую презентацию, в которой этот комментарий и его ответы удалены.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var originalAuthor = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var rootComment = originalAuthor.Comments.AddComment("comment 1", slide, position, createdTime);

var reviewer = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var firstReply = reviewer.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
firstReply.ParentComment = rootComment;

var secondReply = reviewer.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
secondReply.ParentComment = rootComment;

var subReply = originalAuthor.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = secondReply;

reviewer.Comments.AddComment("comment 2", slide, position, createdTime);
var separateComment = reviewer.Comments.AddComment("comment 3", slide, position, createdTime);

var separateReply = originalAuthor.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
separateReply.ParentComment = separateComment;

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

rootComment.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Предупреждение" %}}
* При использовании метода [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) интерфейса [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment), чтобы удалить комментарий, все ответы на этот комментарий также удаляются.
* Если свойство [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) создает циклическую ссылку, генерируется исключение [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).
{{% /alert %}}

## **Добавление современных комментариев**

Современные комментарии могут быть связаны со слайдом, с определенной фигурой или с диапазоном текста внутри AutoShape. Метод [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) принимает аргумент [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), помимо слайда и координат маркера комментария.

Когда в аргумент shape передается `null`, комментарий становится комментариев уровня слайда. Его маркер позиционируется заданными координатами, но не привязан к конкретной фигуре, поэтому [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) возвращает `null`. Когда передается [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), комментарий фиксируется к этой фигуре. Координаты по‑прежнему определяют положение маркера комментария на слайде, а ассоциацию с фигурой можно получить через [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Привязка современного комментария к фигуре**

Пример вызывает [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) дважды: один раз с фигурой `null` для комментария уровня слайда и один раз с прямоугольником в качестве привязки. Чтение [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) выводит `True` для проверки null у комментария уровня слайда и `Revenue title` для привязанного комментария. Оба комментария сохраняются вместе с презентацией.

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

Любой объект слайда, реализующий [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), может использоваться в качестве привязки к фигуре. Распространённые примеры включают [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/) и экземпляры [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/), такие как диаграммы.

Пример использует [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) для связывания комментария с каждым из пяти типов фигур: AutoShape, PictureFrame, Group, Connector и Chart. Изображение использует встроенные данные, поэтому внешний файл изображения не требуется. Каждый комментарий имеет своё собственное положение маркера, и сохранённая презентация сохраняет все пять привязок к фигурам.

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

Для современного комментария, связанного с [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), свойство [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) указывает начальную позицию выбранного текста во фрейме текста фигуры, а [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) задаёт длину выделения. Вместе эти свойства связывают комментарий с конкретным диапазоном текста внутри AutoShape.

Свойство [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) можно читать или изменять значением из перечисления [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — статус современного комментария не определён.
- `Active` — комментарий активен.
- `Resolved` — комментарий отмечен как решённый.
- `Closed` — комментарий закрыт.

Пример привязывает современный комментарий к словам «quarterly revenue» в тексте прямоугольника. Он вычисляет нулевой индекс [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) из текста и задаёт [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) равным количеству выбранных символов. После установки [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) в `Resolved`, презентация сохраняется и открывается заново. Четыре проверки в консоли должны вывести `True`, подтверждая, что привязка к фигуре, диапазон текста и статус были сохранены.

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

### **Исследование существующих современных комментариев**

Пример требует существующую презентацию, содержащую современные комментарии, и выводит их текст, статус и детали привязки. Для их изучения проверьте, какие комментарии реализуют [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), затем изучите [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) и [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). Фигура `null` указывает на комментарий уровня слайда. Для привязки к [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) свойства выбора текста определяют соответствующий диапазон во фрейме текста фигуры.

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

Aspose.Slides для .NET позволяет удалить все комментарии и их авторов из презентации или удалить выбранные комментарии, оставив остальные. Ниже приведённые примеры демонстрируют оба подхода и сохраняют обновлённую презентацию.

### **Удалить все комментарии и их авторов**

Пример открывает существующую презентацию и вызывает [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) для каждого автора, затем вызывает [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) для удаления самих авторов. Сохранённая презентация не содержит ни комментариев, ни их авторов. Используйте презентацию с комментариями, чтобы увидеть удаление.

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

Пример создаёт два комментария на одном слайде и использует [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) для поиска комментариев каждого автора. Он собирает комментарии, текст которых равен "comment 1", перед вызовом [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), избегая изменений в коллекции во время выбора. Сохранённая презентация сохраняет только "comment 2".

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

## **FAQ**

**Поддерживает ли Aspose.Slides статус «решён» для современных комментариев?**

Да. Свойство [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) можно читать и задавать значением из [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/), включая `Resolved`. Статус сохраняется в презентации и может быть вновь прочитан после повторного открытия файла.

**Поддерживаются ли дискуссии в виде веток (цепочки ответов) и существует ли ограничение вложенности?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), что позволяет создавать цепочки ответов. API не определяет конкретного ограничения глубины вложенности.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция маркера задаётся координатами с плавающей запятой в системе координат слайда, что позволяет точно разместить её на слайде.