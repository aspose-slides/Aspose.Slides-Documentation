---
title: Комментарии к презентации
type: docs
weight: 100
url: /ru/androidjava/presentation-comments/
keywords: "Комментарии, комментарии PowerPoint, презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Добавление комментариев и ответов в презентации PowerPoint на Java"
---

В PowerPoint комментарий отображается в виде заметки или аннотации на слайде. Когда вы нажимаете на комментарий, его содержимое или сообщения становятся видимыми.

### **Зачем добавлять комментарии в презентации?**

Вам может понадобиться использовать комментарии для предоставления обратной связи или общения с коллегами при просмотре презентаций.

Чтобы дать вам возможность использовать комментарии в презентациях PowerPoint, Aspose.Slides для Android через Java предоставляет

* Класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), который содержит коллекции авторов (из интерфейса [ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection)). Авторы добавляют комментарии на слайды.
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection), который содержит коллекцию комментариев для отдельных авторов.
* Класс [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment), который содержит информацию об авторах и их комментариях: кто добавил комментарий, время добавления комментария, позиция комментария и т.д.
* Класс [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor), который содержит информацию об отдельных авторах: имя автора, его инициалы, комментарии, связанные с именем автора и т.д.

## **Добавить комментарий к слайду**
Этот код на Java показывает, как добавить комментарий к слайду в презентации PowerPoint:

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

    // Добавляет комментарий к слайду для автора на слайде 1
    author.getComments().addComment("Привет, Jawad, это комментарий к слайду", pres.getSlides().get_Item(0), point, new Date());

    // Добавляет комментарий к слайду для автора на слайде 2
    author.getComments().addComment("Привет, Jawad, это второй комментарий к слайду", pres.getSlides().get_Item(1), point, new Date());

    // Получает ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Когда null передается в качестве аргумента, комментарии от всех авторов отображаются на выбранном слайде
    IComment[] Comments = slide.getSlideComments(author);

    // Получает комментарий по индексу 0 для слайда 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Выбирает коллекцию комментариев автора по индексу 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получение комментариев к слайду**
Этот код на Java показывает, как получить существующий комментарий на слайде в презентации PowerPoint:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " имеет комментарий: " + comment.getText() +
                    " от автора: " + comment.getAuthor().getName() + " размещен в: " + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ответ на комментарии**
Родительский комментарий — это верхний или оригинальный комментарий в иерархии комментариев или ответов. С помощью методов [getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--) или [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (из интерфейса [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)), вы можете установить или получить родительский комментарий.

Этот код на Java показывает, как добавлять комментарии и получать ответы на них:

```java
Presentation pres = new Presentation();
try {
    // Добавляет комментарий
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Автор_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("комментарий 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Добавляет ответ на comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Автор_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("ответ 1 на комментарий 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Добавляет другой ответ на comment1
    IComment reply2 = author2.getComments().addComment("ответ 2 на комментарий 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Добавляет ответ на существующий ответ
    IComment subReply = author1.getComments().addComment("подответ 3 на ответ 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("комментарий 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("комментарий 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("ответ 4 на комментарий 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
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

* Когда метод [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--) (из интерфейса [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)) используется для удаления комментария, ответы на комментарий также удаляются.
* Если установка [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) приводит к циклической ссылке, будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

## **Добавить современный комментарий**

В 2021 году Microsoft представила *современные комментарии* в PowerPoint. Эта функция значительно улучшает сотрудничество в PowerPoint. С помощью современных комментариев пользователи PowerPoint могут гораздо проще разрешать комментарии, привязывать их к объектам и текстам, а также взаимодействовать друг с другом.

В [Aspose Slides для Java 21.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-11-release-notes/) мы реализовали поддержку современных комментариев, добавив класс [ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment). Методы [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) и [insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) были добавлены в класс [CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection).

Этот код на Java показывает, как добавить современный комментарий к слайду в презентации PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Некоторые Автор", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("Это современный комментарий", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Удалить комментарий**

### **Удалить все комментарии и авторов**

Этот код на Java показывает, как удалить все комментарии и авторов в презентации:

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

### **Удалить определенные комментарии**

Этот код на Java показывает, как удалить определенные комментарии на слайде:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // добавляет комментарии...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Автор", "A");
    author.getComments().addComment("комментарий 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("комментарий 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // удаляет все комментарии, содержащие текст "комментарий 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("комментарий 1"))
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