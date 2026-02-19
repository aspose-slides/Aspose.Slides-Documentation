---
title: Комментарий
type: docs
weight: 230
url: /ru/net/examples/elements/comment/
keywords:
- комментарий
- современный комментарий
- добавить комментарий
- доступ к комментарию
- удалить комментарий
- ответить на комментарий
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работайте с комментариями слайдов в Aspose.Slides for .NET: добавляйте, отвечайте, редактируйте, решайте и экспортируйте комментарии в презентациях PPT, PPTX и ODP с примерами кода на C#."
---
В этой статье демонстрируется добавление, чтение, удаление и ответы на современные комментарии с использованием **Aspose.Slides for .NET**.

## **Добавить современный комментарий**

Создайте комментарий, написанный пользователем, и сохраните презентацию.

```csharp
static void AddModernComment()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var author = presentation.CommentAuthors.AddAuthor("User", "U1");
    author.Comments.AddModernComment("This is a modern comment", slide, null, new PointF(100, 100), DateTime.Now);

    presentation.Save("modern_comment.pptx", SaveFormat.Pptx);
}
```

## **Получить современный комментарий**

Прочитайте современный комментарий из существующей презентации.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Удалить современный комментарий**

Удалите комментарий и сохраните обновлённый файл.

```csharp
static void RemoveModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = author.Comments[0];
    comment.Remove();

    presentation.Save("modern_comment_removed.pptx", SaveFormat.Pptx);
}
```

## **Ответить на современный комментарий**

Добавьте ответы к родительскому современному комментарию.

```csharp
static void ReplyToModernComment()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var author = presentation.CommentAuthors.AddAuthor("User", "U1");

    var parentComment = author.Comments.AddModernComment("Parent comment", slide, null, new PointF(100, 100), DateTime.Now);
    var reply1 = author.Comments.AddModernComment("Reply 1", slide, null, new PointF(110, 100), DateTime.Now);
    var reply2 = author.Comments.AddModernComment("Reply 2", slide, null, new PointF(120, 100), DateTime.Now);

    reply1.ParentComment = parentComment;
    reply2.ParentComment = parentComment;

    presentation.Save("modern_comment_replies.pptx", SaveFormat.Pptx);
}
```