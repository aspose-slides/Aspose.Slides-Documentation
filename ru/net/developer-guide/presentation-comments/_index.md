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
- ответ на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте комментариями презентаций с помощью Aspose.Slides для .NET: быстро и легко добавляйте, читайте, редактируйте и удаляйте комментарии в файлах PowerPoint."
---

В PowerPoint комментарий отображается как заметка или аннотация на слайде. При щелчке по комментарию его содержимое или сообщения раскрываются.  

## **Зачем добавлять комментарии в презентации?**

Вы можете использовать комментарии, чтобы дать обратную связь или общаться с коллегами при просмотре презентаций.

Чтобы позволить вам использовать комментарии в презентациях PowerPoint, Aspose.Slides для .NET предоставляет  

* Класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), который содержит коллекцию авторов (из свойства [CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index)). Авторы добавляют комментарии к слайдам.  
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection), который содержит коллекцию комментариев для отдельных авторов.  
* Класс [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment), который содержит информацию о авторах и их комментариях: кто добавил комментарий, время добавления, позиция комментария и т.д.  
* Класс [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor), который содержит информацию об отдельных авторах: имя автора, его инициалы, комментарии, связанные с именем автора, и т.д.  

## **Добавить комментарий к слайду**
Этот код C# показывает, как добавить комментарий к слайду в презентации PowerPoint:
```c#
// Создаёт экземпляр класса Presentation
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
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Добавляет комментарий к слайду для автора на слайде 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Получает ISlide 1
    ISlide slide = presentation.Slides[0];

    // Когда в качестве аргумента передаётся null, комментарии всех авторов добавляются к выбранному слайду
    IComment[] Comments = slide.GetSlideComments(author);

    // Получает комментарий с индексом 0 для слайда 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Выбирает коллекцию комментариев автора с индексом 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```


## **Получить комментарии слайда**
Этот код C# показывает, как получить существующий комментарий на слайде в презентации PowerPoint:
```c#
// Создаёт экземпляр класса Presentation
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```


## **Ответы на комментарии**
Родительский комментарий — это верхний или исходный комментарий в иерархии комментариев или ответов. С помощью свойства [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) (из интерфейса [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)) можно установить или получить родительский комментарий.  

Этот код C# показывает, как добавлять комментарии и получать ответы на них:
```c#
using (Presentation pres = new Presentation())
{
    // Добавляет комментарий
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Добавляет ответ к comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Добавляет ещё один ответ к comment1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Добавляет ответ к существующему ответу
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Отображает иерархию комментариев в консоли
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

    // Удаляет comment1 и все ответы к нему
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" title="Attention" %}} 
* При использовании метода [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) (из интерфейса [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)) для удаления комментария, также удаляются ответы на этот комментарий.  
* Если установка [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) приводит к циклической ссылке, будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).  
{{% /alert %}}

## **Добавить современный комментарий**

В 2021 году Microsoft представила *современные комментарии* в PowerPoint. Эта функция существенно улучшила совместную работу в PowerPoint. С помощью современных комментариев пользователи PowerPoint могут разрешать комментарии, привязывать их к объектам и тексту, а также участвовать во взаимодействиях гораздо проще, чем ранее.  

В [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/) мы реализовали поддержку современных комментариев, добавив класс [ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment). Методы [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) и [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) были добавлены в класс [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection).  

Этот код C# показывает, как добавить современный комментарий к слайду в презентации PowerPoint: 
```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
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
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // удаляем все комментарии, содержащие текст "comment 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
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


## **Часто задаваемые вопросы**

**Поддерживает ли Aspose.Slides статус, например «разрешён», для современных комментариев?**  
Да. [Современные комментарии](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/) предоставляют свойство [Status](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/status/). Вы можете читать и задавать состояние [комментария](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) (например, пометить его как разрешённый), и это состояние сохраняется в файле и распознаётся PowerPoint.

**Поддерживаются ли дискуссии в виде цепочек ответов и существует ли ограничение вложенности?**  
Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), что позволяет создавать произвольные цепочки ответов. API не объявляет конкретного ограничения глубины вложенности.

**В какой системе координат определяется позиция маркера комментария на слайде?**  
Позиция хранится как точка с плавающей запятой в системе координат слайда. Это позволяет разместить маркер комментария точно там, где необходимо.