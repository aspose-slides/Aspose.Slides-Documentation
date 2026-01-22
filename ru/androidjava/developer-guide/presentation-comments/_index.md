---
title: Управление комментариями презентаций на Android
linktitle: Комментарии к презентации
type: docs
weight: 100
url: /ru/androidjava/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии к презентации
- комментарии к слайду
- добавить комментарий
- доступ к комментарию
- редактировать комментарий
- ответ на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Мастерство управления комментариями презентаций с Aspose.Slides for Android via Java: быстро и легко добавляйте, читайте, редактируйте и удаляйте комментарии в файлах PowerPoint."
---

В PowerPoint комментарий отображается как заметка или аннотация на слайде. При щелчке по комментарию его содержимое или сообщения раскрываются. 

### **Почему добавлять комментарии в презентации?**

Вы можете использовать комментарии, чтобы предоставить обратную связь или пообщаться с коллегами при проверке презентаций.

Чтобы вы могли использовать комментарии в презентациях PowerPoint, Aspose.Slides for Android via Java предоставляет

* Класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), который содержит коллекцию авторов (из интерфейса [ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection)). Авторы добавляют комментарии к слайдам.
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection), который содержит коллекцию комментариев для отдельных авторов.
* Класс [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment), который содержит информацию об авторах и их комментариях: кто добавил комментарий, время добавления, позицию комментария и т.д.
* Класс [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor), который содержит информацию об отдельных авторах: имя автора, его инициалы, комментарии, связанные с именем автора, и т.д.

## **Добавление комментария к слайду**
Этот Java‑код показывает, как добавить комментарий к слайду в презентации PowerPoint:
```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Добавляет пустой слайд
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Добавляет автора
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Устанавливает позицию для комментариев
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Добавляет комментарий к слайду от автора на слайде 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Добавляет комментарий к слайду от автора на слайде 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Получает ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // При передаче null в качестве аргумента, комментарии всех авторов выводятся на выбранный слайд
    IComment[] Comments = slide.getSlideComments(author);

    // Получает комментарий с индексом 0 для слайда 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Выбирает коллекцию комментариев автора с индексом 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Доступ к комментариям слайда**
Этот Java‑код показывает, как получить существующий комментарий на слайде в презентации PowerPoint:
```java
// Создаёт экземпляр класса Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ответные комментарии**
Родительский комментарий — это верхний или оригинальный комментарий в иерархии комментариев или ответов. С помощью методов [getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--) или [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (из интерфейса [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)) вы можете задать или получить родительский комментарий.

Этот Java‑код показывает, как добавить комментарии и получить ответы на них:
```java
Presentation pres = new Presentation();
try {
    // Добавляет комментарий
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Добавляет ответ к comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Добавляет еще один ответ к comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Добавляет ответ к существующему ответу
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Отображает иерархию комментариев в консоли
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // Удаляет comment1 и все ответы на него
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" title="Внимание" %}} 

* При использовании метода [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--) (из интерфейса [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)) для удаления комментария удаляются и ответы на этот комментарий.
* Если при установке [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) возникает циклическая ссылка, будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

## **Добавление современного комментария**

В 2021 году Microsoft представила *современные комментарии* в PowerPoint. Функция современных комментариев существенно улучшает совместную работу в PowerPoint. С её помощью пользователи PowerPoint могут решать комментарии, привязывать их к объектам и текстам и гораздо легче взаимодействовать.

Aspose.Slides поддерживает современные комментарии через класс [ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment). В класс [CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection) добавлены методы [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) и [insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-).

Этот Java‑код показывает, как добавить современный комментарий к слайду в презентации PowerPoint: 
```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Удаление комментария**

### **Удалить все комментарии и авторов**

Этот Java‑код показывает, как удалить все комментарии и авторов в презентации:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Удаляет все комментарии из презентации
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Удаляет всех авторов
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


### **Удалить выбранные комментарии**

Этот Java‑код показывает, как удалить конкретные комментарии на слайде:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // добавляем комментарии...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // удалить все комментарии, содержащие текст "comment 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**Поддерживает ли Aspose.Slides статус «решено» для современных комментариев?**

Да. [Modern comments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/) предоставляют метод [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-); вы можете задать [состояние комментария](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) (например, пометить как решённое), и это состояние сохраняется в файле и распознаётся PowerPoint.

**Поддерживаются ли ветвленные обсуждения (цепочки ответов) и есть ли ограничение вложенности?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/comment/#getParentComment--), позволяя создавать произвольные цепочки ответов. API не объявляет конкретного ограничения глубины вложенности.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция хранится как точка с плавающей запятой в системе координат слайда. Это позволяет точно разместить маркер комментария в нужном месте.