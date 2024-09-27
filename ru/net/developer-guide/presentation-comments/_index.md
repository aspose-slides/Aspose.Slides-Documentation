---
title: Комментарии к презентации
type: docs
weight: 100
url: /ru/net/presentation-comments/
keywords: "Комментарии, комментарии PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавление комментариев и ответов в презентации PowerPoint на C# или .NET"
---

В PowerPoint комментарий появляется в виде заметки или аннотации на слайде. Когда комментарий щелкают, его содержимое или сообщения раскрываются.

## **Зачем добавлять комментарии в презентации?**

Вы можете использовать комментарии, чтобы предоставить обратную связь или общаться с вашими коллегами при просмотре презентаций.

Чтобы вы могли использовать комментарии в презентациях PowerPoint, Aspose.Slides для .NET предоставляет

* Класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), который содержит коллекции авторов (из свойства [CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index)). Авторы добавляют комментарии к слайдам.
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection), который содержит коллекцию комментариев для отдельных авторов.
* Класс [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment), который содержит информацию об авторах и их комментариях: кто добавил комментарий, время добавления комментария, позиция комментария и т.д.
* Класс [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor), который содержит информацию о отдельных авторах: имя автора, его инициалы, комментарии, связанные с именем автора и т.д.

## **Добавить комментарий к слайду**
Этот код C# показывает, как добавить комментарий к слайду в презентации PowerPoint:

```c#
// Создает экземпляр класса Presentation
using (Presentation presentation = new Presentation())
{
    // Добавляет пустой слайд
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Добавляет автора
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Устанавливает позицию для комментариев
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Добавляет комментарий к слайду для автора на слайде 1
    author.Comments.AddComment("Привет, Jawad, это комментарий к слайду", presentation.Slides[0], point, DateTime.Now);

    // Добавляет комментарий к слайду для автора на слайде 2
    author.Comments.AddComment("Привет, Jawad, это второй комментарий к слайду", presentation.Slides[1], point, DateTime.Now);

    // Получает ISlide 1
    ISlide slide = presentation.Slides[0];

    // Когда null передается как аргумент, комментарии всех авторов извлекаются для выбранного слайда
    IComment[] Comments = slide.GetSlideComments(author);

    // Получает комментарий по индексу 0 для слайда 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Выбирает коллекцию комментариев автора по индексу 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Получить комментарии к слайду**
Этот код C# показывает, как получить существующий комментарий на слайде в презентации PowerPoint:

```c#
// Создает экземпляр класса Presentation
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " имеет комментарий: " + comment.Text + " с Автором: " + comment.Author.Name + " опубликованное в: " + comment.CreatedTime + "\n");
        }
    }
}
```


## **Ответы на комментарии**
Родительский комментарий — это верхний или оригинальный комментарий в иерархии комментариев или ответов. Используя свойство [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) (из интерфейса [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)), вы можете установить или получить родительский комментарий.

Этот код C# показывает, как добавлять комментарии и получать на них ответы:

```c#
using (Presentation pres = new Presentation())
{
    // Добавляет комментарий
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Автор_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("комментарий 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Добавляет ответ на comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Автор_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("ответ 1 на комментарий 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Добавляет другой ответ на comment1
    IComment reply2 = author2.Comments.AddComment("ответ 2 на комментарий 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Добавляет ответ на существующий ответ
    IComment subReply = author1.Comments.AddComment("подответ 3 на ответ 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("комментарий 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("комментарий 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("ответ 4 на комментарий 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Отображает иерархию комментариев на консоли
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // Удаляет comment1 и все ответы на него
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Внимание" %}} 

* Когда метод [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) (из интерфейса [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) используется для удаления комментария, ответы на комментарий также удаляются.
* Если настройка [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) приводит к циклической ссылке, будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **Добавить современный комментарий**

В 2021 году Microsoft представила *современные комментарии* в PowerPoint. Функция современных комментариев значительно улучшает сотрудничество в PowerPoint. С помощью современных комментариев пользователи PowerPoint могут гораздо легче решать комментарии, привязывать комментарии к объектам и текстам и участвовать в взаимодействиях.

В [Aspose Slides для .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/) мы реализовали поддержку современных комментариев, добавив класс [ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment). Методы [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) и [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) были добавлены в класс [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection).

Этот код C# показывает, как добавить современный комментарий к слайду в презентации PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Некоторый Автор", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("Это современный комментарий", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Удалить комментарий**

### **Удалить все комментарии и авторов**

Этот код C# показывает, как удалить все комментарии и авторов в презентации:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Удаляет все комментарии из презентации
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Удаляет всех авторов
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Удалить конкретные комментарии**

Этот код C# показывает, как удалить конкретные комментарии на слайде:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // добавляем комментарии...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Автор", "A");
    author.Comments.AddComment("комментарий 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("комментарий 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // удаляет все комментарии, содержащие текст "комментарий 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "комментарий 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```