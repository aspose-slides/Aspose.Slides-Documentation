---
title: Комментарий
type: docs
weight: 230
url: /ru/net/examples/elements/comment/
keywords:
- пример комментария
- современный комментарий
- добавить комментарий
- доступ к комментарию
- удалить комментарий
- ответить на комментарий
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте комментариями слайдов в C# с помощью Aspose.Slides: добавляйте, читайте, отвечайте, редактируйте, удаляйте и работайте с вложенными комментариями для PowerPoint и OpenDocument."
---

Продемонстрировано добавление, чтение, удаление и ответы на современные комментарии с использованием **Aspose.Slides for .NET**.

## **Добавить современный комментарий**

Создайте комментарий, написанный пользователем, и сохраните презентацию.
```csharp
static void Add_Modern_Comment()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var author = pres.CommentAuthors.AddAuthor("User", "U1");
    author.Comments.AddModernComment("This is a modern comment", slide, null, new PointF(100, 100), DateTime.Now);

    pres.Save("modern_comment.pptx", SaveFormat.Pptx);
}
```


## **Доступ к современному комментарию**

Прочитайте современный комментарий из существующей презентации.
```csharp
static void Access_Modern_Comment()
{
    using var pres = new Presentation("modern_comment.pptx");
    var author = pres.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```


## **Удалить современный комментарий**

Удалите комментарий и сохраните обновлённый файл.
```csharp
static void Remove_Modern_Comment()
{
    using var pres = new Presentation("modern_comment.pptx");
    var author = pres.CommentAuthors[0];

    var comment = author.Comments[0];
    comment.Remove();

    pres.Save("modern_comment_removed.pptx", SaveFormat.Pptx);
}
```


## **Ответить на современный комментарий**

Добавьте ответы к основному современному комментарию.
```csharp
static void Reply_To_Modern_Comment()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var author = pres.CommentAuthors.AddAuthor("User", "U1");

    var parent = author.Comments.AddModernComment("Parent comment", slide, null, new PointF(100, 100), DateTime.Now);
    var reply1 = author.Comments.AddModernComment("Reply 1", slide, null, new PointF(110, 100), DateTime.Now);
    var reply2 = author.Comments.AddModernComment("Reply 2", slide, null, new PointF(120, 100), DateTime.Now);

    reply1.ParentComment = parent;
    reply2.ParentComment = parent;

    pres.Save("modern_comment_replies.pptx", SaveFormat.Pptx);
}
```
